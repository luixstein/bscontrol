Option Strict On

Public Class Frm_CXP_Devoluciones

#Region "Campos privados"
    Private oDevolucion As New Class_CXP_Devoluciones_Global
    Private oCompra As New Class_Compras_Global
    Private oDocumento As New Class_CatDocumentos
    Private oProveedor As New Class_CatProveedores
    Private oCuentas As New Class_CatCuentas

    Private Estado As enumEstados

    Private dPorcentajeIVAGlobal As Double = 0

    Private Enum enumEstados
        NUEVO
        GRABADO
        APLICADO
        CANCELADO
    End Enum

    Private dTablaMetodosPago As DataTable
    Private dtSeries As DataTable
#End Region

#Region "Columnas grid compras"
    Private igyCodigo As Short = 1
    Private igyTipoControlInventariable As Short = 2
    Private igyDescripcion As Short = 3
    Private igyCantidad As Short = 4
    Private igyPrecio As Short = 5
    'Private igyPRECIO_TOTAL As Short = 6
    Private igyUnidad As Short = 6
    Private igyImpuestoPorcentaje As Short = 7
    Private igyImporte As Short = 8
    Private igyImpuestoImporte As Short = 9
    Private igyIdOrigen As Short = 10
    Private igyIEPS_PORCENTAJE As Short = 11
    Private igyIEPS_UNITARIO As Short = 12
    Private igyIEPS_IMPORTE As Short = 13
    Private igyBASE_IEPS As Short = 14
    Private igyBASE_IVA As Short = 15
#End Region

#Region "Columnas grid series"
    Private igySeriePosicion As Short = 1
    Private igySerieCodigo As Short = 2
    Private igySerieDescripcion As Short = 3
    Private igySerieIdInventarioLotesCostos As Short = 4
    Private igySerieNumeroSerie As Short = 5
    Private igySerieIdOrigen As Short = 6
#End Region

#Region "Opciones"
    Private Sub tsbNuevo_Click(sender As Object, e As EventArgs) Handles tsbNuevo.Click
        Me.Inicializa()
        Me.Cambia_Estado(enumEstados.NUEVO)
    End Sub

    Private Sub tsbGrabar_Click(sender As Object, e As EventArgs) Handles tsbGrabar.Click
        If Me.Grabar = True Then
            Me.Consultar()
        End If
    End Sub

    Private Sub tsbCancelar_Click(sender As Object, e As EventArgs) Handles tsbCancelar.Click
        If Me.Cancelar = True Then
            Me.Consultar()
        End If
    End Sub

    Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
        Me.Imprimir()
    End Sub

    Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub

    Private Sub btnAnterior_Click(sender As Object, e As EventArgs) Handles btnAnterior.Click
        Me.NavegadorNotas("Anterior")
    End Sub

    Private Sub btnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click
        Me.NavegadorNotas("Siguiente")
    End Sub

    Private Sub btnSeries_Click(sender As Object, e As EventArgs) Handles btnSeries.Click
        Me.PrepararSeries()
    End Sub
#End Region

#Region "Eventos de objetos"
    Private Sub Frm_CXP_Devoluciones_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.oDocumento = New Class_CatDocumentos("DEVC" & Usuario.Codigo_Plaza.ToString)
            Me.Inicializa()
            Me.Cambia_Estado(enumEstados.NUEVO)
        Catch ex As Exception
            HandleError(Me.Name, "Frm_CXP_Devoluciones_Load", ex)
        End Try
    End Sub

    Private Sub txtFolioDevolucion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFolioDevolucion.KeyDown
        Dim sText As String
        Select Case e.KeyCode
            Case Keys.F6
                sText = Me.oDevolucion.BusquedaVisual_PorFolio()
                If txtLEN(sText) = True Then
                    Me.txtFolioDevolucion.Text = sText
                    Me.Consultar()
                End If
            Case Keys.Return
                If txtLEN(Me.txtFolioDevolucion.Text) = True Then
                    Me.Consultar()
                Else
                    Me.GeneraFolio()
                End If
        End Select
    End Sub

    Private Sub txtFolioVenta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFolioCompra.KeyDown
        Dim sText As String
        Select Case e.KeyCode
            Case Keys.F6
busca:
                sText = Me.oCompra.BusquedaVisual_Compras
                If txtLEN(sText) = True Then
                    Me.txtFolioCompra.Text = sText
                    Me.CargarCompra()
                End If
            Case Keys.Return
                If txtLEN(Me.txtFolioCompra.Text) = True Then
                    Me.CargarCompra()
                Else
                    GoTo busca : Exit Sub
                End If
        End Select
    End Sub

    Private Sub Grid_KeyDown(ByVal Sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Grid.KeyDown
        Me.GestionaGrid(e)
    End Sub

    Private Sub GridSeries_KeyDown(ByVal Sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridSeries.KeyDown
        Me.GestionaGridSeries(e)
    End Sub

    Private Sub dtFecha_KeyDown(sender As Object, e As KeyEventArgs) Handles dtFecha.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.txtConcepto.Focus()
        End If
    End Sub

    Private Sub txtConcepto_KeyDown(sender As Object, e As KeyEventArgs) Handles txtConcepto.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.Grid.Focus()
        End If
    End Sub

#Region "Eventos Genericos"
    Private Sub txt_Enter(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim oTexBox As TextBox = CType(sender, TextBox)
        oTexBox.SelectAll()
    End Sub

    Private Sub txt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtNumerosDecimalKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim txt As TextBox = CType(sender, TextBox)
        txtSoloNumerosDecimales(e, txt.Text)
        txtNoBeep(e)
    End Sub

    Private Sub txtTextoKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFolioDevolucion.KeyPress, txtFolioCompra.KeyPress, txtFolioDescuento.KeyPress, dtFecha.KeyPress, txtConcepto.KeyPress
        txtNoBeep(e)
    End Sub
#End Region
#End Region

#Region "Métodos y procedimientos"
    Private Sub Inicializa()
        Try
            Me.txtFolioDevolucion.Text = ""
            Me.txtFolioCompra.Text = ""
            Me.txtFolioDescuento.Text = ""
            Me.dtFecha.Value = Date.Now
            Me.txtProveedor.Text = "" : Me.lblProveedor.Text = ""
            Me.txtConcepto.Text = ""
            Me.txtAlmacen.Text = "" : Me.lblAlmacen.Text = ""
            Me.lblEstatus.Text = "N"
            Me.lblPoliza.Text = ""
            Me.txtTipoCambio.Text = "0"

            Me.chkDolares.Checked = False

            Me.lblSubtotalDolares.Text = FormatImporteContable(0)
            Me.lblImpuestoDolares.Text = FormatImporteContable(0)
            Me.lblTotalDolares.Text = FormatImporteContable(0)
            Me.lblSubtotal.Text = FormatImporteContable(0)
            Me.lblImpuesto.Text = FormatImporteContable(0)
            Me.lblTotal.Text = FormatImporteContable(0)
            Me.txtSaldo.Text = ""

            Me.InicializaGrid()
            Me.InicializaGridSeries()

            Me.oDevolucion.CODIGO_DOCUMENTO = "DEVC" & Usuario.Codigo_Plaza
            Me.GeneraFolio()

            Me.dtSeries = New DataTable("Series")

            Me.TabControl1.SelectedIndex = 0

        Catch ex As Exception
            HandleError(Me.Name, "Inicializa", ex)
        End Try
    End Sub

    Private Sub InicializaGrid()
        Try
            Me.Grid.DataSource = Nothing
            FG_Grid_Limpiar(Me.Grid)
            Me.Grid.Rows = 2
            Me.FormateaGrid()
        Catch ex As Exception
            HandleError(Me.Name, "InicializaGrid", ex)
        End Try
    End Sub

    Private Sub PrepararSeries()
        Try
            'Dim iUnidades As Integer
            If IsNothing(Me.dtSeries) = False AndAlso Me.dtSeries.Rows.Count > 0 Then
                If MsgBox("Hay series ya especificadas, si continua tendrá que recapturar todas." & vbCrLf & "Esta seguro de continuar ?", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    Return
                End If
            End If

            Me.dtSeries.Clear()
            Me.dtSeries = New DataTable("Series")
            With Me.dtSeries
                .Columns.Add("POSICION", GetType(String))
                .Columns.Add("CODIGO_ARTICULO", GetType(String))
                .Columns.Add("DESCRIPCION", GetType(String))
                .Columns.Add("ID_INVENTARIO_LOTES_COSTOS", GetType(String))
                .Columns.Add("NUMERO_SERIE", GetType(String))
                .Columns.Add("ID_COMPRA_DETALLE", GetType(String))
            End With
            Me.dtSeries.AcceptChanges()

            Dim dRow As DataRow

            For i = 1 To Me.Grid.Rows - 1
                If txtLEN(Me.Grid.Cell(i, Me.igyCodigo).Text) = True AndAlso Me.Grid.Cell(i, Me.igyCodigo).Text <> "-" AndAlso CInt(Me.Grid.Cell(i, Me.igyCantidad).Text) > 0 Then
                    Dim oArticulo As New Class_CatArticulos(Me.Grid.Cell(i, Me.igyCodigo).Text)
                    If oArticulo.Existe = True AndAlso oArticulo.ES_SERIALIZABLE = True AndAlso oArticulo.INVENTARIABLE = "1" Then
                        For j = 1 To CInt(Me.Grid.Cell(i, Me.igyCantidad).Text)
                            dRow = Me.dtSeries.NewRow

                            dRow("POSICION") = i
                            dRow("CODIGO_ARTICULO") = Me.Grid.Cell(i, Me.igyCodigo).Text
                            dRow("DESCRIPCION") = Me.Grid.Cell(i, Me.igyDescripcion).Text
                            dRow("ID_INVENTARIO_LOTES_COSTOS") = ""
                            dRow("NUMERO_SERIE") = ""
                            dRow("ID_COMPRA_DETALLE") = Me.Grid.Cell(i, Me.igyIdOrigen).Text

                            Me.dtSeries.Rows.Add(dRow)
                        Next
                    End If
                End If
            Next

            Me.dtSeries.AcceptChanges()

            Me.GridSeries.DataSource = Me.dtSeries

            Me.FormateaGridSeries()

            Me.TabControl1.SelectedIndex = 1

        Catch ex As Exception
            HandleError(Me.Name, "PrepararSeries", ex)
        End Try
    End Sub

    Private Sub InicializaGridSeries()
        Try
            Me.GridSeries.DataSource = Nothing
            FG_Grid_Limpiar(Me.GridSeries)
            Me.GridSeries.Rows = 2
            Me.GridSeries.Cols = 7
            Me.FormateaGridSeries()
            'Me.Grid.Cell(1, Me.iGyIDAdicional).Text = "1"
        Catch ex As Exception
            HandleError(Me.Name, "InicializaGridSeries", ex)
        End Try
    End Sub

    Private Sub FormateaGrid()
        Try
            Me.Grid.AutoRedraw = False
            Me.Grid.Cols = 16

            Me.Grid.Column(Me.igyCodigo).Width = 75
            Me.Grid.Column(Me.igyDescripcion).Width = 250
            Me.Grid.Column(Me.igyTipoControlInventariable).Width = 25
            Me.Grid.Column(Me.igyCantidad).Width = 90
            Me.Grid.Column(Me.igyPrecio).Width = 100
            Me.Grid.Column(Me.igyUnidad).Width = 75
            Me.Grid.Column(Me.igyImpuestoPorcentaje).Width = 70
            Me.Grid.Column(Me.igyImporte).Width = 100
            Me.Grid.Column(Me.igyImpuestoImporte).Width = 100
            Me.Grid.Column(Me.igyIdOrigen).Width = 100

            Me.Grid.Cell(0, Me.igyCodigo).Text = "Código"
            Me.Grid.Cell(0, Me.igyDescripcion).Text = "Descripción"
            Me.Grid.Cell(0, Me.igyTipoControlInventariable).Text = "Inv"
            Me.Grid.Cell(0, Me.igyCantidad).Text = "Cant devuelta"
            Me.Grid.Cell(0, Me.igyPrecio).Text = "Precio"
            'Me.Grid.Cell(0, Me.igyPRECIO_TOTAL).Text = "Precio total"
            Me.Grid.Cell(0, Me.igyUnidad).Text = "Unidad"
            Me.Grid.Cell(0, Me.igyImpuestoPorcentaje).Text = "IVA %"
            Me.Grid.Cell(0, Me.igyImporte).Text = "Importe"
            Me.Grid.Cell(0, Me.igyImpuestoImporte).Text = "IVA"
            Me.Grid.Cell(0, Me.igyIdOrigen).Text = "Id Articulo"

            Me.Grid.Column(Me.igyCantidad).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.igyCantidad).DecimalLength = Empresa_Sistema.DECIMALES_CANTIDAD
            Me.Grid.Column(Me.igyCantidad).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.igyPrecio).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_PRECIO)
            Me.Grid.Column(Me.igyPrecio).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.igyPrecio).DecimalLength = Empresa_Sistema.DECIMALES_PRECIO
            Me.Grid.Column(Me.igyPrecio).Alignment = FlexCell.AlignmentEnum.RightCenter

            'Me.Grid.Column(Me.igyPRECIO_TOTAL).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_PRECIO)
            'Me.Grid.Column(Me.igyPRECIO_TOTAL).Mask = FlexCell.MaskEnum.Numeric
            'Me.Grid.Column(Me.igyPRECIO_TOTAL).DecimalLength = Empresa_Sistema.DECIMALES_PRECIO
            'Me.Grid.Column(Me.igyPRECIO_TOTAL).Alignment = FlexCell.AlignmentEnum.RightCenter

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

            Me.Grid.Column(Me.igyCodigo).Locked = True
            Me.Grid.Column(Me.igyTipoControlInventariable).Locked = True
            Me.Grid.Column(Me.igyDescripcion).Locked = True
            Me.Grid.Column(Me.igyCantidad).Locked = False
            Me.Grid.Column(Me.igyPrecio).Locked = True
            'Me.Grid.Column(Me.igyPRECIO_TOTAL).Locked = True
            Me.Grid.Column(Me.igyUnidad).Locked = True
            Me.Grid.Column(Me.igyImpuestoPorcentaje).Locked = True
            Me.Grid.Column(Me.igyImporte).Locked = True
            Me.Grid.Column(Me.igyImpuestoImporte).Visible = False
            Me.Grid.Column(Me.igyIdOrigen).Visible = False
            Me.Grid.Column(Me.igyIEPS_PORCENTAJE).Visible = False
            Me.Grid.Column(Me.igyIEPS_UNITARIO).Visible = False
            Me.Grid.Column(Me.igyIEPS_IMPORTE).Visible = False
            Me.Grid.Column(Me.igyBASE_IEPS).Visible = False
            Me.Grid.Column(Me.igyBASE_IVA).Visible = False

        Catch ex As Exception
            HandleError(Me.Name, "FormateaGrid", ex)
        Finally
            Me.Grid.AutoRedraw = True
            Me.Grid.Refresh()
        End Try
    End Sub

    Private Sub FormateaGridSeries()
        Try
            With Me.GridSeries
                .AutoRedraw = False

                '.DefaultFont = New Font("Tahoma", 8)
                .DisplayFocusRect = False
                '.DisplayDateTimeMask = True
                '.ExtendLastCol = True
                .DrawMode = FlexCell.DrawModeEnum.OwnerDraw
                .BorderStyle = FlexCell.BorderStyleEnum.FixedSingle
                .FixedRowColStyle = FlexCell.FixedRowColStyleEnum.Flat

                .Column(Me.igySeriePosicion).Visible = False
                .Column(Me.igySerieCodigo).Width = 130
                .Column(Me.igySerieDescripcion).Width = 450
                .Column(Me.igySerieIdInventarioLotesCostos).Visible = False
                .Column(Me.igySerieNumeroSerie).Width = 250

                .Cell(0, Me.igySeriePosicion).Text = "Posición"
                .Cell(0, Me.igySerieCodigo).Text = "Código"
                .Cell(0, Me.igySerieDescripcion).Text = "Descripción"
                .Cell(0, Me.igySerieIdInventarioLotesCostos).Text = "Id lote"
                .Cell(0, Me.igySerieNumeroSerie).Text = "Número de serie"

                .Column(Me.igySeriePosicion).Locked = True
                .Column(Me.igySerieCodigo).Locked = True
                .Column(Me.igySerieDescripcion).Locked = True
                .Column(Me.igySerieIdInventarioLotesCostos).Locked = True
                .Column(Me.igySerieNumeroSerie).Locked = True

                .Column(Me.igySerieIdOrigen).Visible = False

                .AutoRedraw = True
                .Refresh()

                .Row(.Rows - 1).Locked = True 'Para bloquear la edición del último renglón
            End With
        Catch ex As Exception
            HandleError(Me.Name, "FormateaGridSeries", ex)
        End Try
    End Sub

    Private Sub GestionaCambioEstado()
        Select Case Me.lblEstatus.Text
            Case "N"
                Me.Cambia_Estado(enumEstados.NUEVO)
            Case "G"
                Me.Cambia_Estado(enumEstados.GRABADO)
            Case "A"
                Me.Cambia_Estado(enumEstados.APLICADO)
            Case "C"
                Me.Cambia_Estado(enumEstados.CANCELADO)
        End Select
    End Sub

    Private Sub Cambia_Estado(ByVal pEstado As enumEstados)
        Try
            Me.Estado = pEstado

            Select Case Me.Estado
                Case enumEstados.NUEVO
                    Me.tsbNuevo.Enabled = True
                    Me.tsbCancelar.Enabled = False
                    Me.tsbImprimir.Enabled = False
                    Me.tsbGrabar.Enabled = True

                    Me.Grid.Locked = True 'Se habilitará hasta que asignen un folio de venta para consultar sus disponibles.

                    Me.GridSeries.Locked = True
                    If Me.oDocumento.AFECTA_INVENTARIOS = True Then
                        Me.GridSeries.Locked = False
                        Me.btnSeries.Visible = True
                    End If

                    Me.txtFolioDevolucion.Enabled = True
                    Me.txtFolioCompra.Enabled = True
                    Me.txtConcepto.Enabled = True
                    Me.dtFecha.Enabled = True

                    Me.tssEstado.Text = "Estado: Agregando nuevo movimiento"

                    If Me.Visible = True Then
                        Me.txtFolioDevolucion.Focus()
                    End If

                Case enumEstados.APLICADO
                    Me.tsbNuevo.Enabled = True
                    Me.tsbGrabar.Enabled = False
                    Me.tsbCancelar.Enabled = True
                    Me.tsbImprimir.Enabled = True

                    Me.Grid.Locked = True
                    Me.GridSeries.Locked = True
                    Me.btnSeries.Visible = False

                    Me.txtFolioDevolucion.Enabled = False
                    Me.txtFolioCompra.Enabled = False
                    Me.txtConcepto.Enabled = False
                    Me.dtFecha.Enabled = False

                    Me.tssEstado.Text = "Estado: Consultando movimiento"

                    Me.tsbImprimir.Select()

                Case enumEstados.CANCELADO
                    Me.tsbNuevo.Enabled = True
                    Me.tsbGrabar.Enabled = False
                    Me.tsbCancelar.Enabled = False
                    Me.tsbImprimir.Enabled = True

                    Me.Grid.Locked = True
                    Me.GridSeries.Locked = True
                    Me.btnSeries.Visible = False

                    Me.txtFolioDevolucion.Enabled = False
                    Me.txtFolioCompra.Enabled = False
                    Me.txtConcepto.Enabled = False
                    Me.dtFecha.Enabled = False

                    Me.tssEstado.Text = "Estado: Consultando movimiento"

                    Me.tsbImprimir.Select()
            End Select

            Application.DoEvents()

        Catch ex As Exception
            HandleError(Me.Name, "Cambia_Estado", ex)
        End Try
    End Sub

    Private Sub GeneraFolio()
        'If Me.bDocumentosCargados = True Then
        Me.txtFolioDevolucion.Text = Me.oDocumento.GeneraFolio
        'End If
    End Sub

    Private Function CargarCompra() As Boolean
        Dim bResultado As Boolean = False
        Try
            Me.oCompra = New Class_Compras_Global(Me.txtFolioCompra.Text, "CO" & Usuario.Codigo_Plaza.ToString)

            If Me.oCompra.Existe = False Then
                MsgBox("No existe la compra indicada.", MsgBoxStyle.Exclamation, Me.Text)
                Return False
            End If

            oProveedor = New Class_CatProveedores(Me.oCompra.CODIGO_PROVEEDOR)
            Dim oAlmacen As New Class_CatAlmacenes(Me.oCompra.CODIGO_ALMACEN)
            Me.txtProveedor.Text = Me.oCompra.CODIGO_PROVEEDOR
            Me.lblProveedor.Text = Me.oProveedor.Nombre_Proveedor
            Me.txtAlmacen.Text = Me.oCompra.CODIGO_ALMACEN
            Me.lblAlmacen.Text = oAlmacen.NOMBRE_ALMACEN
            Me.txtTipoCambio.Text = Me.oCompra.TIPO_DE_CAMBIO.ToString

            Me.txtSaldo.Text = FormatImporteContable(Me.oCompra.SALDO)

            Dim dTabla As DataTable = Me.oCompra.ObtenerDetalleDisponiblesParaDevolucion
            If dTabla.Rows.Count = 0 Then
                MsgBox("No hay disponibles en la compra para devolver.", MsgBoxStyle.Exclamation, Me.Text)
                Return False
            End If

            Me.Grid.Locked = False
            Me.Grid.DataSource = dTabla
            Me.FormateaGrid()
            Me.Grid.Row(Me.Grid.Rows - 1).Locked = True 'Para bloquear la edición del último rengló que sale automáticamente.

            Me.txtFolioDevolucion.Enabled = False 'Se bloqueda por si quedó habilitado.
            Me.txtFolioCompra.Enabled = False 'Se bloquea, si se ocupa cambiar que le den nuevo.

            Me.Totales()

            bResultado = True
        Catch ex As Exception
            HandleError(Me.Name, "CargarCompra", ex)
        End Try
        Return bResultado
    End Function

    Private Function Consultar() As Boolean
        Dim bResultado As Boolean = False
        Dim sFolio As String = Me.txtFolioDevolucion.Text

        Try
            Me.Inicializa()
            Me.oDevolucion = New Class_CXP_Devoluciones_Global(sFolio)

            If Me.oDevolucion.Existe = False Then
                Me.GeneraFolio()
                Me.Cambia_Estado(enumEstados.NUEVO)
                Me.txtFolioDevolucion.Enabled = False
                Return False
            Else
                Me.txtFolioDevolucion.Enabled = False

                Me.oCompra = New Class_Compras_Global(Me.oDevolucion.FOLIO_COMPRA)

                With oDevolucion
                    Me.txtFolioDevolucion.Text = .FOLIO_DEVOLUCION
                    Me.txtFolioCompra.Text = .FOLIO_COMPRA
                    Me.txtFolioDescuento.Text = .FOLIO_DESCUENTO_DEVOLUCION

                    Me.dtFecha.Value = .FECHA
                    Me.txtProveedor.Text = .CODIGO_PROVEEDOR
                    Me.lblProveedor.Text = .NOMBRE_PROVEEDOR
                    Me.txtConcepto.Text = .CONCEPTO
                    Me.lblEstatus.Text = .ESTATUS_DEVOLUCION
                    Me.lblPoliza.Text = .FOLIO_POLIZA
                    Me.txtAlmacen.Text = .CODIGO_ALMACEN
                    Me.lblAlmacen.Text = .NOMBRE_ALMACEN

                    Me.txtTipoCambio.Text = FormatTipoCambio(.TIPO_DE_CAMBIO)
                    Me.lblSubtotal.Text = FormatImporteContable(.SUBTOTAL)
                    Me.lblIEPS.Text = FormatImporteContable(.IEPS_DESGLOSADO)
                    Me.lblIEPSIncluido.Text = FormatImporteContable(.IEPS_INCLUIDO)
                    Me.lblImpuesto.Text = FormatImporteContable(.IMPUESTO)
                    Me.lblTotal.Text = FormatImporteContable(.TOTAL)
                    'Me.cboMoneda.Text = .MONEDA

                    If .TIPO_DE_CAMBIO > 0 Then
                        Me.chkDolares.Checked = True
                        Me.CalculaImporteDolares()
                    End If

                    Me.tssElaboro.Text = "Elaboró : " & .NOMBRE_USUARIO_GRABO & " el " & Format(.FECHA_SERVIDOR, "dd-MMM-yyyy hh:mm tt")
                    If .ESTATUS_DEVOLUCION = "C" Then
                        Me.tssCancelo.Text = "Canceló : " & .NOMBRE_USUARIO_CANCELO & " el : " & Format(.FECHA_CANCELACION, "dd-MMM-yyyy hh:mm tt")
                    End If

                    Me.txtSaldo.Text = FormatImporteContable(Me.oCompra.SALDO)

                    Me.Grid.DataSource = .ObtenerDetalle

                    Me.GridSeries.DataSource = .ObtenerDetalleSeries
                End With

                Me.FormateaGrid()
                Me.FormateaGridSeries()

                bResultado = True

                Me.GestionaCambioEstado()
            End If
        Catch ex As Exception
            HandleError(Me.Name, "Consultar", ex)
        End Try

        Return bResultado
    End Function

    Private Function Grabar() As Boolean
        Dim bResultado As Boolean = False
        Dim i As Integer, sListaSeries As String = ""

        Try
            If Me.Validar = False Then
                Return False
            End If

            Me.GeneraFolio()

            Me.oDevolucion = New Class_CXP_Devoluciones_Global

            With Me.oDevolucion
                .FOLIO_COMPRA = Me.txtFolioCompra.Text
                .FECHA = Me.dtFecha.Value
                .CODIGO_DOCUMENTO = Me.oDocumento.CODIGO_DOCUMENTO
                .CONCEPTO = Me.txtConcepto.Text
                .TIPO_DE_CAMBIO = valorNumericoD(Me.txtTipoCambio.Text)
                .SUBTOTAL = valorNumericoD(Me.lblSubtotal.Text)
                .IMPUESTO = valorNumericoD(Me.lblImpuesto.Text)
                .TOTAL = valorNumericoD(Me.lblTotal.Text)
                .IEPS_DESGLOSADO = valorNumericoD(Me.lblIEPS.Text)
                .IEPS_INCLUIDO = valorNumericoD(Me.lblIEPSIncluido.Text)
                .IMPUESTO_PORCENTAJE = CDec(IIf(valorNumericoD(Me.lblImpuesto.Text) > 0, "16", "0"))

                If .GrabaDevolucionGlobal = False Then
                    Return False
                End If

                Me.txtFolioDevolucion.Text = .FOLIO_DEVOLUCION

                Dim dCantidad As Decimal

                For i = 1 To Me.Grid.Rows - 1
                    dCantidad = valorNumericoD(Me.Grid.Cell(i, Me.igyCantidad).Text)
                    If dCantidad > 0 Then
                        .NuevoRenglon()

                        If Me.dtSeries.Rows.Count > 0 Then
                            For Each dRow In Me.dtSeries.Select("POSICION='" & i.ToString & "'")
                                sListaSeries = sListaSeries & dRow("POSICION").ToString & "," & dRow("CODIGO_ARTICULO").ToString & "," & dRow("ID_INVENTARIO_LOTES_COSTOS").ToString & "," & dRow("NUMERO_SERIE").ToString & "|"
                            Next
                            If txtLEN(sListaSeries) = True Then
                                sListaSeries = sListaSeries.Substring(0, sListaSeries.Length - 1) 'Para quitarle el último pipe que sale sobrando.
                            End If
                        End If

                        .oDetalle.FOLIO_DEVOLUCION = .FOLIO_DEVOLUCION
                        .oDetalle.CODIGO_ARTICULO = Me.Grid.Cell(i, Me.igyCodigo).Text.ToUpper
                        .oDetalle.ID_COMPRA_DETALLE = CInt(Me.Grid.Cell(i, Me.igyIdOrigen).Text)
                        .oDetalle.CANTIDAD = valorNumericoD(Me.Grid.Cell(i, Me.igyCantidad).Text)
                        .oDetalle.PRECIO = valorNumericoD(Me.Grid.Cell(i, Me.igyPrecio).Text)
                        .oDetalle.IMPUESTO_PORCENTAJE = valorNumericoD(Me.Grid.Cell(i, Me.igyImpuestoPorcentaje).Text)
                        .oDetalle.IMPUESTO_IMPORTE = valorNumericoD(Me.Grid.Cell(i, Me.igyImpuestoImporte).Text)
                        .oDetalle.IMPORTE = valorNumericoD(Me.Grid.Cell(i, Me.igyImporte).Text)
                        .oDetalle.IEPS_PORCENTAJE = valorNumericoD(Me.Grid.Cell(i, Me.igyIEPS_PORCENTAJE).Text)
                        .oDetalle.IEPS_UNITARIO = valorNumericoD(Me.Grid.Cell(i, Me.igyIEPS_UNITARIO).Text)
                        .oDetalle.IEPS_IMPORTE = valorNumericoD(Me.Grid.Cell(i, Me.igyIEPS_IMPORTE).Text)
                        .oDetalle.BASE_IEPS = valorNumericoD(Me.Grid.Cell(i, Me.igyBASE_IEPS).Text)
                        .oDetalle.BASE_IVA = valorNumericoD(Me.Grid.Cell(i, Me.igyBASE_IVA).Text)
                        '.oDetalle.PRECIO_TOTAL = valorNumericoD(Me.Grid.Cell(i, Me.igyPRECIO_TOTAL).Text)
                        .oDetalle.LISTA_SERIES = sListaSeries

                        If .oDetalle.GrabaRenglon = False Then
                            MsgBox("Error al tratar de grabar el detalle.", MsgBoxStyle.Exclamation, Me.Text)
                            Exit Function
                        End If

                        sListaSeries = ""
                    End If
                Next

                .AfectaInventarios()

                'FALTA:Contabilidad
                'PREGUNTAR SI ES EL DOC DE LA VENTA AFECTO A CONTA Y DECIR QUE NO AFECTARA A CONTA, QUE AVISEA SISTEMAs?

                'FALTA:Timbrado

            End With

            bResultado = True
        Catch ex As Exception
            HandleError(Me.Name, "Grabar", ex)
        End Try

        Return bResultado
    End Function

    Private Function Cancelar() As Boolean
        MsgBox("FALTA:Cancelar", vbExclamation)
    End Function

    Private Sub Imprimir()
        Me.oDevolucion.Consultar()
        'If txtLEN(Me.oDevolucion.FOLIO_FISCAL_SAT + Me.oDevolucion.FECHA_TIMBRADO_SAT + Me.oDevolucion.NUMERO_SERIE_CERTIFICADO_SAT + Me.oDevolucion.SELLO_SAT) = False AndAlso txtLEN(Me.oDevolucion.CBB_IMAGE.ToString) = False _
        '    AndAlso Me.oDocumento.TIMBRA_DOCUMENTO = True Then
        '    MsgBox("La devolución no esta timbrada.", MsgBoxStyle.Exclamation, "Advertencia")
        'End If
        Me.oDevolucion.Imprimir()
    End Sub

    Private Sub CalculaImporteDolares()
        Try
            Dim dUSD As Decimal = 0
            If valorNumerico(Me.txtTipoCambio.Text) > 0 Then
                'Me.lblSubtotalDolares.Text = FormatImporteContable(Me.oDevolucion.SUBTOTAL / Me.oDevolucion.TIPO_DE_CAMBIO).ToString
                'Me.lblImpuestoDolares.Text = FormatImporteContable(Me.oDevolucion.IMPUESTO / Me.oDevolucion.TIPO_DE_CAMBIO).ToString
                'Me.lblTotalDolares.Text = FormatImporteContable(Me.oDevolucion.TOTAL / Me.oDevolucion.TIPO_DE_CAMBIO).ToString

                Me.lblSubtotalDolares.Text = FormatImporteContable(Redondear(valorNumerico(Me.lblSubtotal.Text) / valorNumerico(Me.txtTipoCambio.Text), Empresa_Sistema.DECIMALES_CONTABILIDAD))
                Me.lblImpuestoDolares.Text = FormatImporteContable(Redondear(valorNumerico(Me.lblImpuesto.Text) / valorNumerico(Me.txtTipoCambio.Text), Empresa_Sistema.DECIMALES_CONTABILIDAD))
                Me.lblTotalDolares.Text = FormatImporteContable(Redondear(valorNumerico(Me.lblTotal.Text) / valorNumerico(Me.txtTipoCambio.Text), Empresa_Sistema.DECIMALES_CONTABILIDAD))

            Else
                Me.lblSubtotalDolares.Text = "0"
                Me.lblImpuestoDolares.Text = "0"
                Me.lblTotalDolares.Text = "0"
            End If
        Catch ex As Exception
            HandleError(Me.Name, "CalculaImporteDolares", ex)
        End Try
    End Sub

    Private Sub NavegadorNotas(ByVal sTipoDeBusqueda As String)
        Try
            Dim iFolio As Integer, sFolio As String
            If txtLEN(Me.txtFolioDevolucion.Text) = False Then
                Me.txtFolioDevolucion.Text = Me.oDocumento.GeneraFolio
            End If

            If sTipoDeBusqueda = "Anterior" Then
                sFolio = Me.txtFolioDevolucion.Text.Substring(0, Me.txtFolioDevolucion.Text.IndexOf("-"))
                iFolio = CInt(Strings.Right(Me.txtFolioDevolucion.Text, Len(Me.txtFolioDevolucion.Text) - (Len(sFolio) + 1))) ' Me.oVenta.FOLIO_NUMERICO
                iFolio = iFolio - 1
                sFolio = sFolio + "-" + iFolio.ToString

                Me.txtFolioDevolucion.Text = sFolio

                If iFolio > 0 Then
                    Me.Consultar()
                Else
                    Me.Inicializa()
                    Me.Cambia_Estado(enumEstados.NUEVO)
                End If

            ElseIf sTipoDeBusqueda = "Siguiente" Then
                sFolio = Me.txtFolioDevolucion.Text.Substring(0, Me.txtFolioDevolucion.Text.IndexOf("-"))
                iFolio = CInt(Strings.Right(Me.txtFolioDevolucion.Text, Len(Me.txtFolioDevolucion.Text) - (Len(sFolio) + 1)))
                iFolio = iFolio + 1
                sFolio = sFolio + "-" + iFolio.ToString

                Me.txtFolioDevolucion.Text = sFolio

                If iFolio > 0 Then
                    Me.Consultar()
                End If
            End If

        Catch ex As Exception
            HandleError(Me.Name, "NavegadorNotas", ex)
        End Try
    End Sub

    'Private Sub Totales()
    '    Try
    '        Dim i As Integer, dCantidad As Decimal, dPrecio As Decimal, dPorcentajeIVA As Decimal, dImporte As Decimal, iIDOrigen As Integer = 0, dImporteTotal As Double = 0
    '        Dim oArticulo As New Class_CatArticulos
    '        Dim dIEPS_PORCENTAJE As Decimal = 0, dIEPS_UNITARIO As Decimal = 0, dIEPS_IMPORTE As Decimal = 0, dBASE_IEPS As Decimal = 0, dBASE_IVA As Decimal = 0, dIVA_IMPORTE As Decimal = 0
    '        Dim dtSubtotal As Decimal = 0, dtIEPS As Decimal = 0, dtImpuesto As Decimal = 0, dtTotal As Decimal = 0

    '        Me.lblSubtotal.Text = FormatImporteContable(0)
    '        Me.lblIEPSIncluido.Text = FormatImporteContable(0)
    '        Me.lblIEPS.Text = FormatImporteContable(0)
    '        Me.lblImpuesto.Text = FormatImporteContable(0)
    '        Me.lblTotal.Text = FormatImporteContable(0)

    '        Me.lblSubtotalDolares.Text = FormatImporteContable(0)
    '        Me.lblImpuestoDolares.Text = FormatImporteContable(0)
    '        Me.lblTotalDolares.Text = FormatImporteContable(0)

    '        For i = 1 To Me.Grid.Rows - 1
    '            If txtLEN(Me.Grid.Cell(i, Me.igyCodigo).Text) = True Then
    '                oArticulo = New Class_CatArticulos(Me.Grid.Cell(i, Me.igyCodigo).Text)

    '                If txtLEN(Me.Grid.Cell(i, Me.igyCantidad).Text) = True Then
    '                    dCantidad = valorNumericoD(Me.Grid.Cell(i, Me.igyCantidad).Text)
    '                    dPrecio = valorNumericoD(Me.Grid.Cell(i, Me.igyPrecio).Text)
    '                    iIDOrigen = CInt(valorNumericoD(Me.Grid.Cell(i, Me.igyIdOrigen).Text))
    '                    dPorcentajeIVA = valorNumericoD(Me.Grid.Cell(i, Me.igyImpuestoPorcentaje).Text)

    '                    dIEPS_PORCENTAJE = CDec(valorNumerico(Me.Grid.Cell(i, Me.igyIEPS_PORCENTAJE).Text))
    '                    dIEPS_UNITARIO = CDec(Redondear(dPrecio * (dIEPS_PORCENTAJE / 100), 4))

    '                    dBASE_IEPS = RedondearD((dPrecio * dCantidad), 2)

    '                    dIEPS_IMPORTE = RedondearD(dBASE_IEPS * (dIEPS_PORCENTAJE / 100), 2)
    '                    dBASE_IVA = dIEPS_IMPORTE + dBASE_IEPS
    '                    dIVA_IMPORTE = RedondearD(dBASE_IVA * ((dPorcentajeIVA / 100)), 2)
    '                    'dPRECIO_TOTAL = dPrecio

    '                    Me.Grid.Cell(i, Me.igyIEPS_UNITARIO).Text = dIEPS_UNITARIO.ToString
    '                    Me.Grid.Cell(i, Me.igyBASE_IEPS).Text = dBASE_IEPS.ToString
    '                    Me.Grid.Cell(i, Me.igyIEPS_IMPORTE).Text = dIEPS_IMPORTE.ToString
    '                    Me.Grid.Cell(i, Me.igyBASE_IVA).Text = dBASE_IVA.ToString
    '                    Me.Grid.Cell(i, Me.igyImpuestoImporte).Text = dIVA_IMPORTE.ToString

    '                    'If Me.oCliente.ES_CONTRIBUYENTE_IEPS = "0" And dPrecio > 0 Then 'Cuando no es contribuyente se le adjunta al precio el ieps, es decir se le incluye
    '                    'dPRECIO_TOTAL = RedondearD(dPrecio + dIEPS_UNITARIO, 3)
    '                    'End If

    '                    'Me.Grid.Cell(i, Me.igyPRECIO_TOTAL).Text = dPRECIO_TOTAL.ToString

    '                    dImporte = RedondearD((dPrecio * dCantidad), Empresa_Sistema.DECIMALES_CONTABILIDAD) 'no hacemos nada con este valor de momento
    '                    'dImporteTotal = RedondearD((dPRECIO_TOTAL * dCantidad), Empresa_Sistema.DECIMALES_CONTABILIDAD)

    '                    Me.Grid.Cell(i, Me.igyImporte).Text = dImporte.ToString
    '                End If

    '            End If
    '        Next i

    '        dtIEPS = RedondearD(CDec(FG_Grid_SumaCol(Me.Grid, Me.igyIEPS_IMPORTE)), Empresa_Sistema.DECIMALES_CONTABILIDAD)

    '        'If Me.oCliente.ES_CONTRIBUYENTE_IEPS = "1" Then
    '        Me.lblIEPSIncluido.Text = FormatImporteContable(0)
    '        Me.lblIEPS.Text = FormatImporteContable(dtIEPS)
    '        'Else
    '        '    Me.lblIEPSIncluido.Text = FormatImporteContable(dtIEPS)
    '        '    Me.lblIEPS.Text = FormatImporteContable(0)
    '        '    dtIEPS = 0 'Se establece en 0 porque luego se le suma este valor al total y al ser includo entonces debe ser 0
    '        'End If

    '        dtSubtotal = RedondearD(CDec(FG_Grid_SumaCol(Me.Grid, Me.igyImporte)), Empresa_Sistema.DECIMALES_CONTABILIDAD)
    '        dtImpuesto = RedondearD(CDec(FG_Grid_SumaCol(Me.Grid, Me.igyImpuestoImporte)), Empresa_Sistema.DECIMALES_CONTABILIDAD)
    '        dtTotal = dtSubtotal + dtIEPS + dtImpuesto

    '        Me.lblSubtotal.Text = FormatImporteContable(dtSubtotal)
    '        Me.lblImpuesto.Text = FormatImporteContable(dtImpuesto)
    '        Me.lblTotal.Text = FormatImporteContable(dtTotal)

    '        If valorNumerico(Me.txtTipoCambio.Text) > 0 Then
    '            Me.CalculaImporteDolares()
    '        End If

    '    Catch ex As Exception
    '        HandleError(Me.Name, "Totales", ex)
    '    End Try
    'End Sub

    Private Function Totales(Optional ByVal bIva As Boolean = False) As Boolean
        Dim bResultado As Boolean = False
        Try
            Dim i As Integer
            Dim dCantidad As Double, dPrecio As Double, dPorcentajeIVA As Double, dImporte As Double
            Dim dIEPS_PORCENTAJE As Double = 0, dIEPS_UNITARIO As Double = 0, dIEPS_IMPORTE As Double = 0, dBASE_IEPS As Double = 0, dBASE_IVA As Double = 0, dPRECIO_TOTAL As Double = 0, dIVA_IMPORTE As Double = 0
            Dim IvaCalculado As String = ""

            Me.lblSubtotal.Text = FormatImporteContable(0)
            Me.lblIEPS.Text = FormatImporteContable(0)
            'Me.txtIVA.Text = FormatImporteContable(0)
            Me.lblTotal.Text = FormatImporteContable(0)

            Me.lblSubtotalDolares.Text = FormatImporteContable(0)
            Me.lblImpuestoDolares.Text = FormatImporteContable(0)
            Me.lblTotalDolares.Text = FormatImporteContable(0)

            For i = 1 To Me.Grid.Rows - 1
                If txtLEN(Me.Grid.Cell(i, Me.igyCantidad).Text) = True Then
                    dCantidad = valorNumerico(Me.Grid.Cell(i, Me.igyCantidad).Text)
                    dPrecio = valorNumerico(Me.Grid.Cell(i, Me.igyPrecio).Text)
                    dPorcentajeIVA = valorNumerico(Me.Grid.Cell(i, Me.igyImpuestoPorcentaje).Text)

                    dIEPS_PORCENTAJE = valorNumerico(Me.Grid.Cell(i, Me.igyIEPS_PORCENTAJE).Text)
                    dIEPS_UNITARIO = Redondear(dPrecio * (dIEPS_PORCENTAJE / 100), 4)
                    dBASE_IEPS = Redondear((dPrecio * dCantidad), 2)
                    dIEPS_IMPORTE = Redondear(dBASE_IEPS * (dIEPS_PORCENTAJE / 100), 2)
                    dBASE_IVA = dIEPS_IMPORTE + dBASE_IEPS
                    dIVA_IMPORTE = Redondear(dBASE_IVA * ((dPorcentajeIVA / 100)), 2)

                    dImporte = Redondear((dPrecio * dCantidad), Empresa_Sistema.DECIMALES_CONTABILIDAD) 'no hacemos nada con este valor de momento

                    Me.Grid.Cell(i, Me.igyImporte).Text = dImporte.ToString
                    Me.Grid.Cell(i, Me.igyIEPS_UNITARIO).Text = dIEPS_UNITARIO.ToString
                    Me.Grid.Cell(i, Me.igyBASE_IEPS).Text = dBASE_IEPS.ToString
                    Me.Grid.Cell(i, Me.igyIEPS_IMPORTE).Text = dIEPS_IMPORTE.ToString
                    Me.Grid.Cell(i, Me.igyBASE_IVA).Text = dBASE_IVA.ToString
                    Me.Grid.Cell(i, Me.igyImpuestoImporte).Text = dIVA_IMPORTE.ToString

                    'If dCantidad > 0 Then
                    '    dImporte = Redondear((dPrecio * dCantidad), Empresa_Sistema.DECIMALES_CONTABILIDAD)
                    '    Me.Grid.Cell(i, Me.igyImporte).Text = dImporte.ToString
                    '    Me.Grid.Cell(i, Me.igyImpuestoImporte).Text = Redondear(dImporte * ((dPorcentajeIVA / 100)), Empresa_Sistema.DECIMALES_CONTABILIDAD).ToString
                    'Else
                    '    Me.Grid.Cell(i, Me.igyImporte).Text = "0"
                    '    Me.Grid.Cell(i, Me.igyImpuestoImporte).Text = "0"
                    'End If
                End If
            Next i

            Me.lblSubtotal.Text = FormatImporteContable(Redondear(FG_Grid_SumaCol(Me.Grid, Me.igyImporte), Empresa_Sistema.DECIMALES_CONTABILIDAD))

            Me.lblIEPS.Text = FormatImporteContable(Redondear(FG_Grid_SumaCol(Me.Grid, Me.igyIEPS_IMPORTE), Empresa_Sistema.DECIMALES_CONTABILIDAD))

            IvaCalculado = FormatImporteContable(Redondear(FG_Grid_SumaCol(Me.Grid, Me.igyImpuestoImporte), Empresa_Sistema.DECIMALES_CONTABILIDAD))
            'Me.txtIVA.Text = FormatImporteContable(Redondear(FG_Grid_SumaCol(Me.Grid, Me.igyImpuestoImporte), Empresa_Sistema.DECIMALES_CONTABILIDAD))

            'Se quitó de momento funcionalidad para poder editar el iva total a mano, hay que rediseñar solución. 24abr
            If bIva = False Then
                'If valorNumerico(Me.lblIVAcalculado.Text) > 0 And valorNumerico(Me.txtIVA.Text) = 0 Then
                Me.lblImpuesto.Text = FormatImporteContable(Redondear(FG_Grid_SumaCol(Me.Grid, Me.igyImpuestoImporte), Empresa_Sistema.DECIMALES_CONTABILIDAD))
            Else
                Me.lblImpuesto.Text = FormatImporteContable(valorNumerico(Me.lblImpuesto.Text))
                'ElseIf valorNumerico(Me.lblIVAcalculado.Text) <> valorNumerico(Me.txtIVA.Text) Then
                If valorNumerico(Me.lblImpuesto.Text) > valorNumerico(IvaCalculado) - 1 And valorNumerico(Me.lblImpuesto.Text) > valorNumerico(IvaCalculado) + 1 Then
                    MsgBox("El IVA asignado no es correcto, favor de verificar.", MsgBoxStyle.Exclamation, Me.Name)
                    Me.lblImpuesto.Focus()
                    Return False
                End If
                'End If
            End If

            'Me.lblTotal.Text = FormatImporteContable((valorNumerico(Me.lblSubtotal.Text) + valorNumerico(Me.lblIEPS.Text) + valorNumerico(Me.lblImpuesto.Text)) - valorNumerico(Me.lblRetencion.Text))
            Me.lblTotal.Text = FormatImporteContable((valorNumerico(Me.lblSubtotal.Text) + valorNumerico(Me.lblIEPS.Text) + valorNumerico(Me.lblImpuesto.Text)))

            Me.TotalesUSD()

            bResultado = True

        Catch ex As Exception
            HandleError(Me.Name, "Totales", ex)
        End Try

        Return bResultado
    End Function

    Private Sub TotalesUSD()
        Try
            Dim dTipoCambio As Double = valorNumerico(Me.txtTipoCambio.Text)
            Dim dSubtotalUSD As Double = 0, dIVAUSD As Double = 0, dTotalUSD As Double = 0

            If dTipoCambio > 0 And Me.chkDolares.Checked = True Then 'Si no esta chequeado en usd , no va entrar aqui y van a quedan en ceros(simulando que se inicilizaron)
                dSubtotalUSD = Redondear(valorNumerico(Me.lblSubtotal.Text) / dTipoCambio, Empresa_Sistema.DECIMALES_CONTABILIDAD)
                dIVAUSD = Redondear(valorNumerico(Me.lblImpuesto.Text) / dTipoCambio, Empresa_Sistema.DECIMALES_CONTABILIDAD)
                dTotalUSD = Redondear(valorNumerico(Me.lblTotal.Text) / dTipoCambio, Empresa_Sistema.DECIMALES_CONTABILIDAD)
            End If

            Me.lblSubtotalDolares.Text = FormatImporteContable(dSubtotalUSD)
            Me.lblImpuestoDolares.Text = FormatImporteContable(dIVAUSD)
            Me.lblTotalDolares.Text = FormatImporteContable(dTotalUSD)

        Catch ex As Exception
            HandleError(Me.Name, "TotalesUSD", ex)
        End Try
    End Sub

    Private Sub GestionaGrid(ByVal e As System.Windows.Forms.KeyEventArgs)
        Dim sProcedure As String = "GestionaGrid"
        Try
            Dim Columna As Integer, Renglon As Integer, dCantidad As Decimal

            Columna = Me.Grid.Selection.FirstCol
            Renglon = Me.Grid.Selection.FirstRow
            dCantidad = CDec(valorNumerico(Me.Grid.Cell(Renglon, Me.igyCantidad).Text))

            Select Case e.KeyCode
                Case Keys.Enter
                    Select Case Columna
                        Case Me.igyCantidad
                            If dCantidad <= 0 Then
                                Me.Grid.Cell(Renglon, Me.igyCantidad).Text = "0"
                                Me.Grid.Refresh()
                                'MsgBox("La cantidad debe de ser mayor a 0.", MsgBoxStyle.Exclamation, sProcedure)
                                Me.Grid.Cell(Renglon, Me.igyDescripcion).SetFocus()
                                GoTo Sigue
                            End If
                            If Me.ValidarDisponible(Renglon) = False Then
                                Me.Grid.Cell(Renglon, Me.igyCantidad).Text = "0"
                                Me.Grid.Refresh() 'Si no se pone , no se refresca el 0 de inmediato, hasta que se mueva el foco al parecer.
                                Me.Grid.Cell(Renglon, Me.igyDescripcion).SetFocus()
                                GoTo Sigue
                            End If
                    End Select
Sigue:
                    Me.Totales()

            End Select

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Sub GestionaGridSeries(ByVal e As System.Windows.Forms.KeyEventArgs)
        Dim sLote As String = "", sCodigoArticulo As String = ""
        Dim oSerie As Class_Inventarios_Lotes_Series
        Try
            With Me.GridSeries
                Dim Renglon As Integer = .Selection.FirstRow
                Dim Columna As Integer = .Selection.FirstCol
                Select Case e.KeyCode
                    Case Keys.Return
                        If Columna = Me.igySerieNumeroSerie AndAlso txtLEN(.Cell(Renglon, Me.igySeriePosicion).Text) = True Then
                            sLote = .Cell(Renglon, Me.igySerieIdInventarioLotesCostos).Text
                            If txtLEN(sLote) = False Then
                                GoTo busca_serie
                                Return
                            End If

                            If Me.EstableceSerie(Renglon, sLote) = True Then
                                If Renglon + 1 < .Rows Then
                                    .Cell(Renglon + 1, Me.igySerieDescripcion).SetFocus()
                                Else
                                    .Cell(1, Me.igySerieDescripcion).SetFocus()
                                End If
                            End If
                        End If

                    Case Keys.F6
                        If Columna = Me.igySerieNumeroSerie AndAlso txtLEN(.Cell(Renglon, Me.igySeriePosicion).Text) = True Then
busca_serie:
                            oSerie = New Class_Inventarios_Lotes_Series
                            sCodigoArticulo = .Cell(Renglon, Me.igySerieCodigo).Text
                            'sLote = oDevolucion.BusquedaVisualSeriesDevolucion(Me.txtFolioCompra.Text, sCodigoArticulo)
                            sLote = oDevolucion.BusquedaVisualSeriesDevolucion(Me.txtFolioCompra.Text, sCodigoArticulo, .Cell(Renglon, Me.igySerieIdOrigen).Text)
                            If txtLEN(sLote) = True Then
                                If RepiteSerie(Renglon, sLote) = False Then
                                    Me.EstableceSerie(Renglon, sLote)
                                End If
                            End If
                        End If

                        'Case Keys.F7
                        '    If Columna = Me.igySerieNumeroSerie AndAlso txtLEN(.Cell(Renglon, Me.igySeriePosicion).Text) = True Then
                        '        oSerie = New Class_Inventarios_Lotes_Series
                        '        sCodigoArticulo = .Cell(Renglon, Me.igySerieCodigo).Text
                        '        If txtLEN(sCodigoArticulo) = False Then
                        '            Return
                        '        End If

                        '        Dim lote As New Class_Inventarios_Lotes_Series.Lote
                        '        lote = oSerie.BusquedaVisualSeriesMultiplesFolio(sCodigoArticulo, oVenta.CODIGO_ALMACEN)

                        '        If txtLEN(lote.FolioMovimiento) = True Then

                        '            Dim dtSeries As DataTable = oSerie.ObtieneRenglonesSeriesFolio(lote.FolioMovimiento, sCodigoArticulo)
                        '            If dtSeries.Rows.Count = 0 Then
                        '                MsgBox("No se encontraron series disponibles del artículo " & sCodigoArticulo & " del folio " & lote.FolioMovimiento, MsgBoxStyle.Exclamation, Me.Text)
                        '                Return
                        '            End If

                        '            Dim i As Integer, iArticulosPendientes As Integer = Me.CantidadArticulosPendientesSerie(sCodigoArticulo) 'iArticulosEncontrados As Integer
                        '            Dim iSeriesUsadas As Double = lote.Cantidad, iRowEncontrado As Integer = 0
                        '            For i = 1 To Me.GridSeries.Rows - 1
                        '                If iArticulosPendientes <= 0 Or iSeriesUsadas <= 0 Then
                        '                    Exit For
                        '                End If
                        '                If Me.GridSeries.Cell(i, Me.igySerieCodigo).Text = sCodigoArticulo AndAlso txtLEN(Me.GridSeries.Cell(i, Me.igySerieIdInventarioLotesCostos).Text) = False Then
                        '                    iArticulosPendientes -= 1
                        '                    iSeriesUsadas -= 1
                        '                    Me.GridSeries.Cell(i, Me.igySerieIdInventarioLotesCostos).Text = dtSeries.Rows(iRowEncontrado)("ID_INVENTARIO_LOTES_COSTOS").ToString
                        '                    Me.GridSeries.Cell(i, Me.igySerieNumeroSerie).Text = dtSeries.Rows(iRowEncontrado)("NUMERO_SERIE").ToString
                        '                    iRowEncontrado += 1 'empieza desde el 0
                        '                End If
                        '            Next


                        '        End If
                        '    End If

                    Case Keys.Delete
                        e.SuppressKeyPress = True 'No es válido eliminar renglones del grid de series.
                End Select
            End With

        Catch ex As Exception
            HandleError(Me.Name, "GestionaGridSeries", ex)
        End Try
    End Sub

    Private Function EstableceSerie(ByVal Renglon As Integer, ByVal ID_INVENTARIO_LOTES_COSTOS As String) As Boolean
        Try
            Dim oSerie As New Class_Inventarios_Lotes_Series(ID_INVENTARIO_LOTES_COSTOS)
            If oSerie.Existe = True Then
                Me.GridSeries.Cell(Renglon, Me.igySerieIdInventarioLotesCostos).Text = oSerie.ID_INVENTARIO_LOTES_COSTOS
                Me.GridSeries.Cell(Renglon, Me.igySerieNumeroSerie).Text = oSerie.NUMERO_SERIE
                Return True
            End If
        Catch ex As Exception
            HandleError(Me.Name, "EstableceSerie", ex)
        End Try
    End Function

    Private Function RepiteSerie(ByVal Renglon As Integer, ByVal ID_INVENTARIO_LOTES_COSTOS As String) As Boolean
        Dim RenglonRepetido As Integer
        Try
            Me.dtSeries.AcceptChanges()

            For i = 1 To Me.GridSeries.Rows - 1
                If i <> Renglon Then
                    If txtLEN(Me.GridSeries.Cell(i, Me.igySerieCodigo).Text) = True Then
                        If ID_INVENTARIO_LOTES_COSTOS = Me.GridSeries.Cell(i, Me.igySerieIdInventarioLotesCostos).Text Then
                            RenglonRepetido = i

                            MsgBox("La serie " & Me.GridSeries.Cell(RenglonRepetido, igySerieNumeroSerie).Text &
                                   " del artículo " & Me.GridSeries.Cell(RenglonRepetido, igySerieCodigo).Text & " esta repetida en el renglón " & RenglonRepetido & "." & vbCrLf &
                                   "", MsgBoxStyle.Exclamation)
                            Me.GridSeries.Cell(RenglonRepetido, Me.igySerieNumeroSerie).SetFocus()

                            Return True

                        End If

                    End If
                End If

            Next
        Catch ex As Exception
            HandleError(Me.Name, "RepiteSerie", ex)
        End Try
    End Function

    Private Function Validar() As Boolean
        Dim sProcedure As String = "Validar"
        Dim bResultado As Boolean = False
        Try
            If Usuario.ValidaPermisoUsuarioDocumentoConAfectacionInventarios(Me.oDocumento.CODIGO_DOCUMENTO, Me.txtAlmacen.Text) = False Then
                MsgBox("El usuario " & Usuario.Nombre_Usuario & " no tiene permiso para realizar el movimiento.", MsgBoxStyle.Information, Me.Text)
                Exit Function
            End If

            If Me.lblEstatus.Text <> "N" Then
                MsgBox("Debe de estar en un estado de nuevo para grabar este documento.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            Me.oCompra = New Class_Compras_Global(Me.txtFolioCompra.Text, "CO" & Usuario.Codigo_Plaza.ToString)
            If oCompra.ESTATUS <> "A" Then
                MsgBox("La compra debe de estar en estatus de aplicado(A), actualmente esta en (" & Me.oCompra.ESTATUS & ")", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            If txtLEN(Me.txtConcepto.Text) = False Then
                MsgBox("Captúre por favor un concepto.", MsgBoxStyle.Exclamation, sProcedure)
                Me.txtConcepto.Focus()
                Return False
            End If

            If Me.ValidarDisponibles = False Then
                Return False
            End If

            If Me.ValidarExistencias = False Then
                Return False
            End If

            Me.Totales()

            If valorNumerico(Me.lblTotal.Text) <= 0 Then
                MsgBox("El total debe ser mayor a cero.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            If Me.oCompra.TIENE_SERIES = True Then

                If Me.ValidaNumerosSerie = False Then
                    Return False
                End If

                If Me.HaySeriesRepetidas = True Then
                    Return False
                End If

                'Nota, las validaciones de disponibles de series en los lotes de costos exactos se hacen en el ValidaExistencia
            End If

            bResultado = True
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    Private Function ValidarDisponible(ByVal Renglon As Integer) As Boolean
        Dim bResultado As Boolean = False
        Dim dDisponible As Decimal
        Try
            dDisponible = Me.oCompra.ObtenerDisponibleRenglon(CInt(Me.Grid.Cell(Renglon, Me.igyIdOrigen).Text))
            If valorNumericoD(Me.Grid.Cell(Renglon, Me.igyCantidad).Text) > dDisponible Then
                MsgBox("La cantidad del renglón #" & Renglon & " es mayor al disponible.", MsgBoxStyle.Exclamation, "ValidarDisponible")
                Return False
            End If

            bResultado = True
        Catch ex As Exception
            HandleError(Me.Name, "ValidarDisponible", ex)
        End Try
        Return bResultado
    End Function

    Private Function ValidarDisponibles() As Boolean
        Dim bResultado As Boolean = False, bHayCantidadesNoDisponibles As Boolean = False
        Dim i As Integer
        Try
            i = 1
            If txtLEN(Me.Grid.Cell(i, Me.igyCodigo).Text) = True Then
                If ValidarDisponible(i) = False Then
                    bHayCantidadesNoDisponibles = True
                End If
            End If

            If bHayCantidadesNoDisponibles = False Then
                bResultado = True
            End If

        Catch ex As Exception
            HandleError(Me.Name, "ValidarDisponibles", ex)
        End Try
        Return bResultado
    End Function

    Private Function HaySeriesRepetidas() As Boolean
        Dim RenglonRepetido As Integer

        Try
            Me.dtSeries.AcceptChanges()

            For i = 1 To Me.GridSeries.Rows - 1
                If txtLEN(Me.GridSeries.Cell(i, Me.igySerieCodigo).Text) = True Then
                    For z = i + 1 To Me.GridSeries.Rows - 1
                        If Me.GridSeries.Cell(i, Me.igySerieIdInventarioLotesCostos).Text = Me.GridSeries.Cell(z, Me.igySerieIdInventarioLotesCostos).Text Then
                            RenglonRepetido = z

                            MsgBox("La serie " & Me.GridSeries.Cell(RenglonRepetido, igySerieNumeroSerie).Text &
                                   " del artículo " & Me.GridSeries.Cell(RenglonRepetido, igySerieCodigo).Text & " esta repetida en el renglón " & RenglonRepetido & "." & vbCrLf &
                                   "", MsgBoxStyle.Exclamation)
                            Me.GridSeries.Cell(RenglonRepetido, Me.igySerieNumeroSerie).SetFocus()

                            Return True

                        End If
                    Next
                End If
            Next
        Catch ex As Exception
            HandleError(Me.Name, "HaySeriesRepetidas", ex)
        End Try

        Return False
    End Function

    Private Function ValidaNumerosSerie() As Boolean
        Try
            Dim dtSeriesTemp As New DataTable("Series")
            With dtSeriesTemp
                .Columns.Add("POSICION", GetType(String))
                .Columns.Add("CODIGO_ARTICULO", GetType(String))
                .Columns.Add("DESCRIPCION", GetType(String))
            End With
            dtSeriesTemp.AcceptChanges()

            Dim dRow As DataRow, i As Integer

            For i = 1 To Me.Grid.Rows - 1
                If txtLEN(Me.Grid.Cell(i, Me.igyCodigo).Text) = True AndAlso Me.Grid.Cell(i, Me.igyCodigo).Text <> "-" AndAlso CInt(Me.Grid.Cell(i, Me.igyCantidad).Text) > 0 Then
                    Dim oArticulo As New Class_CatArticulos(Me.Grid.Cell(i, Me.igyCodigo).Text)
                    If oArticulo.Existe = True AndAlso oArticulo.ES_SERIALIZABLE = True AndAlso oArticulo.INVENTARIABLE = "1" Then
                        For j = 1 To CInt(Me.Grid.Cell(i, Me.igyCantidad).Text)
                            dRow = dtSeriesTemp.NewRow

                            dRow("POSICION") = i
                            dRow("CODIGO_ARTICULO") = Me.Grid.Cell(i, Me.igyCodigo).Text
                            dRow("DESCRIPCION") = Me.Grid.Cell(i, Me.igyDescripcion).Text

                            dtSeriesTemp.Rows.Add(dRow)
                        Next
                    End If
                End If
            Next

            dtSeriesTemp.AcceptChanges()

            If Me.dtSeries.Rows.Count <> dtSeriesTemp.Rows.Count Then
                MsgBox("Tiene que volver a detallar todas las series porque no corresponden los artículos.", MsgBoxStyle.Exclamation)
                Return False
            End If

            i = 0
            For Each d As DataRow In dtSeriesTemp.Rows
                If d("POSICION").ToString <> Me.dtSeries.Rows(i)("POSICION").ToString Then
                    MsgBox("Tiene que volver a detallar todas las series porque no corresponden los artículos.", MsgBoxStyle.Exclamation)
                    Return False
                ElseIf d("CODIGO_ARTICULO").ToString <> Me.dtSeries.Rows(i)("CODIGO_ARTICULO").ToString Then
                    MsgBox("Tiene que volver a detallar todas las series porque no corresponden los artículos.", MsgBoxStyle.Exclamation)
                    Return False
                End If
                i += 1
            Next

            For Each d As DataRow In Me.dtSeries.Rows
                If txtLEN(d("NUMERO_SERIE").ToString) = False Then
                    MsgBox("Faltan de capturar series, favor de revisar.", MsgBoxStyle.Exclamation)
                    Return False
                End If
            Next

            Return True
        Catch ex As Exception
            HandleError(Me.Name, "ValidaNumerosSerie", ex)
        End Try
    End Function

    Private Function ValidarExistencias() As Boolean
        Const sProcedure As String = "ValidarExistencias"

        Dim dCantidadSumadaPorArticulos As Double, dExistencia As Double
        Dim i As Integer
        Dim oInventarios As New Class_Inventarios_Global
        Dim oArticulos As New Class_CatArticulos

        Dim dt As New DataTable
        Dim dr As DataRow

        dt.Columns.Add(New DataColumn("CODIGO_ARTICULO", GetType(String)))
        dt.Columns.Add(New DataColumn("DESCRIPCION", GetType(String)))
        dt.Columns.Add(New DataColumn("CANTIDAD", GetType(Decimal)))

        Try

            For iRow = 1 To Me.Grid.Rows - 1
                dr = dt.NewRow()
                dr("CODIGO_ARTICULO") = Me.Grid.Cell(iRow, Me.igyCodigo).Text
                dr("DESCRIPCION") = Me.Grid.Cell(iRow, Me.igyDescripcion).Text
                dr("CANTIDAD") = valorNumerico(Me.Grid.Cell(iRow, Me.igyCantidad).Text)
                dt.Rows.Add(dr)
            Next

            For i = 1 To Me.Grid.Rows - 1
                If Len(Me.Grid.Cell(i, Me.igyCodigo).Text) > 0 Then
                    dExistencia = oInventarios.Existencia(Me.Grid.Cell(i, Me.igyCodigo).Text, Me.txtAlmacen.Text)
                    oArticulos = New Class_CatArticulos(Me.Grid.Cell(i, Me.igyCodigo).Text)
                    If oArticulos.INVENTARIABLE = "1" Then
                        If dExistencia <= 0 Then
                            MsgBox("El artículo " & Me.Grid.Cell(i, Me.igyDescripcion).Text & " no tiene existencia. ", MsgBoxStyle.Exclamation, sProcedure)
                            Return False
                        Else
                            dCantidadSumadaPorArticulos = valorNumerico(dt.Compute("sum(CANTIDAD)", "CODIGO_ARTICULO='" & Me.Grid.Cell(i, Me.igyCodigo).Text & "'").ToString)

                            If valorNumerico(dCantidadSumadaPorArticulos.ToString) > valorNumerico(dExistencia.ToString) Then
                                MsgBox("El Artículo " & Me.Grid.Cell(i, Me.igyDescripcion).Text & " no tiene suficiente existencia.", MsgBoxStyle.Exclamation, sProcedure)
                                Return False
                            End If
                        End If
                    End If
                End If
            Next i

            'Aqui valida disponibles de lotes
            With Me.GridSeries
                For i = 1 To .Rows - 1
                    If Len(.Cell(i, Me.igySeriePosicion).Text) > 0 Then
                        If Len(.Cell(i, Me.igySerieIdInventarioLotesCostos).Text) > 0 Then
                            dExistencia = oInventarios.ExistenciaLoteSerie(.Cell(i, Me.igySerieIdInventarioLotesCostos).Text)
                            If dExistencia < 1 Then
                                MsgBox("El Artículo " & .Cell(i, Me.igySerieDescripcion).Text & " con la serie " & .Cell(i, Me.igySerieNumeroSerie).Text & " no tiene suficiente existencia.", MsgBoxStyle.Exclamation, sProcedure)
                                Return False
                            End If
                        End If
                    End If
                Next
            End With

            Return True
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Function

#End Region

End Class