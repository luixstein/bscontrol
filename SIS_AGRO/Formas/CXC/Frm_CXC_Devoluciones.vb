Option Strict On

Public Class Frm_CXC_Devoluciones

#Region "Campos privados"
    Private oDevolucion As New Class_CXC_Devoluciones_Global
    Private oVenta As New Class_Ventas_Global
    Private oDocumento As New Class_CatDocumentos
    Private oCliente As New Class_CatClientes
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
    Private dViewFormasPago As New Data.DataView
#End Region

#Region "Columnas grid ventas"
    Private igyCodigo As Short = 1
    Private igyTipoControlInventariable As Short = 2
    Private igyDescripcion As Short = 3
    Private igyCantidad As Short = 4
    Private igyPrecio As Short = 5
    Private igyPRECIO_TOTAL As Short = 6
    Private igyUnidad As Short = 7
    Private igyImpuestoPorcentaje As Short = 8
    Private igyImporte As Short = 9
    Private igyImpuestoImporte As Short = 10
    Private igyIdOrigen As Short = 11
    Private igyIEPS_PORCENTAJE As Short = 12
    Private igyIEPS_UNITARIO As Short = 13
    Private igyIEPS_IMPORTE As Short = 14
    Private igyBASE_IEPS As Short = 15
    Private igyBASE_IVA As Short = 16
#End Region

#Region "Columnas grid series"
    Private igySeriePosicion As Short = 1
    Private igySerieCodigo As Short = 2
    Private igySerieDescripcion As Short = 3
    Private igySerieIdInventarioLotesCostos As Short = 4
    Private igySerieNumeroSerie As Short = 5
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

    Private Sub tsbTimbrar_Click(sender As Object, e As EventArgs) Handles tsbTimbrar.Click
        If Me.oDevolucion.GeneraDevolucionElectronica(True, True) = True Then
            Me.Consultar()
        End If
    End Sub

    Private Sub tsbCancelarTimbre_Click(sender As Object, e As EventArgs) Handles tsbCancelarTimbre.Click
        If Me.oDevolucion.CancelarTimbre = True Then
            Me.Consultar()
        End If
    End Sub

    Private Sub tsbRecuperaXMLPdf_Click(sender As Object, e As EventArgs) Handles tsbRecuperarXMLPDF.Click
        Me.oDevolucion.RecuperarXMLyPDF()
    End Sub

    Private Sub tsbEnviarCorreo_Click(sender As Object, e As EventArgs) Handles tsbEnviarCorreo.Click
        Me.EnviarCorreo()
    End Sub

#End Region

#Region "Eventos de objetos"
    Private Sub Frm_CXC_Devoluciones_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.oDocumento = New Class_CatDocumentos("DEVV" & Usuario.Codigo_Plaza.ToString)

            Me.DesplegarMetodosPago()
            Me.DesplegarMonedas()
            Me.DesplegarFormasPago(False)
            Me.DesplegarUsoCFDIPersonasFisicas()

            Me.Inicializa()
            Me.Cambia_Estado(enumEstados.NUEVO)

        Catch ex As Exception
            HandleError(Me.Name, "Frm_CXC_Devoluciones_Load", ex)
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

    Private Sub txtFolioVenta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFolioVenta.KeyDown
        Dim sText As String
        Select Case e.KeyCode
            Case Keys.F6
busca:
                sText = Me.oVenta.BusquedaVisual_PorFolio()
                If txtLEN(sText) = True Then
                    Me.txtFolioVenta.Text = sText
                    Me.CargarVenta()
                End If
            Case Keys.Return
                If txtLEN(Me.txtFolioVenta.Text) = True Then
                    Me.CargarVenta()
                Else
                    GoTo busca : Exit Sub
                End If
        End Select
    End Sub

    Private Sub Grid_KeyDown(ByVal Sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Grid.KeyDown
        Me.GestionaGrid(e)
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

    Private Sub cboMoneda_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMoneda.SelectedIndexChanged
        Try
            If Me.cboMoneda.Text = "USD" Then
                Me.txtTipoCambio.Visible = True : Me.txtTipoCambio.Enabled = True : Me.lblDisplayTipoCambio.Visible = True
                Me.gbDolares.Visible = True
            Else
                Me.txtTipoCambio.Visible = False : Me.txtTipoCambio.Enabled = False : Me.lblDisplayTipoCambio.Visible = False
                Me.gbDolares.Visible = False
            End If
        Catch ex As Exception
            HandleError(Me.Name, "cboMoneda_SelectedIndexChanged", ex)
        End Try
    End Sub

    Private Sub LblPoliza_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblPoliza.LinkClicked
        Dim Child As New Frm_Contabilidad_Captura_Polizas()
        Child.FolioPolizaConsultaExterior = Me.lblPoliza.Text
        Child.ShowDialog()
        Child.Dispose()
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

    Private Sub txtTextoKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFolioDevolucion.KeyPress, txtFolioVenta.KeyPress, txtFolioDescuento.KeyPress, dtFecha.KeyPress, txtConcepto.KeyPress
        txtNoBeep(e)
    End Sub
#End Region

#End Region

#Region "Métodos y procedimientos"
    Private Sub Inicializa()
        Try
            Me.txtFolioDevolucion.Text = ""
            Me.txtFolioVenta.Text = ""
            Me.txtFolioDescuento.Text = ""
            Me.dtFecha.Value = Date.Now
            Me.txtCliente.Text = "" : Me.lblCliente.Text = ""
            Me.txtConcepto.Text = ""
            Me.txtAlmacen.Text = "" : Me.lblAlmacen.Text = ""
            Me.lblEstatus.Text = "N"
            Me.lblPoliza.Text = ""
            Me.txtTipoCambio.Text = "0"

            Me.chkVentaPublicoGeneral.Checked = False

            Me.lblSubtotalDolares.Text = FormatImporteContable(0)
            Me.lblImpuestoDolares.Text = FormatImporteContable(0)
            Me.lblTotalDolares.Text = FormatImporteContable(0)
            Me.lblSubtotal.Text = FormatImporteContable(0)
            Me.lblImpuesto.Text = FormatImporteContable(0)
            Me.lblTotal.Text = FormatImporteContable(0)
            Me.txtSaldo.Text = ""

            Me.InicializaGrid()
            Me.InicializaGridSeries()

            Me.oDevolucion.CODIGO_DOCUMENTO = "DEVV" & Usuario.Codigo_Plaza
            Me.GeneraFolio()

            Me.dtSeries = New DataTable("Series")

            Me.cboMoneda.Text = "MXN"

            Me.DesplegarFormasPago(False)
            Me.cboFormaPago.SelectedValue = "99" ' "99-Por definir"  '99=Por definir
            Me.cboMetodoPago.SelectedValue = "PUE" ' "PUE-Pago en una sola exhibición"
            Me.cboUsoCFDI.SelectedValue = "G02" ' "G02-Devoluciones, descuentos o bonificaciones"
            Me.lblVersionCFDI.Text = ""

            Me.TabControl1.SelectedIndex = 0

            'Estos gestionan su visibilidad en el consultar
            Me.tsbTimbrar.Visible = False
            Me.tsbCancelarTimbre.Visible = False
            Me.tsbRecuperarXMLPDF.Visible = False
            Me.tsbEnviarCorreo.Visible = False

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

    Private Sub InicializaGridSeries()
        Try
            Me.GridSeries.DataSource = Nothing
            FG_Grid_Limpiar(Me.GridSeries)
            Me.GridSeries.Rows = 2
            Me.GridSeries.Cols = 6
            Me.FormateaGridSeries()
            'Me.Grid.Cell(1, Me.iGyIDAdicional).Text = "1"
        Catch ex As Exception
            HandleError(Me.Name, "InicializaGridSeries", ex)
        End Try
    End Sub

    Private Sub FormateaGrid()
        Try
            Me.Grid.AutoRedraw = False
            Me.Grid.Cols = 17

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
            Me.Grid.Cell(0, Me.igyPRECIO_TOTAL).Text = "Precio total"
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

            Me.Grid.Column(Me.igyPRECIO_TOTAL).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_PRECIO)
            Me.Grid.Column(Me.igyPRECIO_TOTAL).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.igyPRECIO_TOTAL).DecimalLength = Empresa_Sistema.DECIMALES_PRECIO
            Me.Grid.Column(Me.igyPRECIO_TOTAL).Alignment = FlexCell.AlignmentEnum.RightCenter

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
            Me.Grid.Column(Me.igyPRECIO_TOTAL).Locked = True
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

            Me.cboUsoCFDI.Enabled = False
            Me.cboFormaPago.Enabled = False
            Me.cboMetodoPago.Enabled = False

            Me.chkVentaPublicoGeneral.Enabled = False

            Select Case Me.Estado
                Case enumEstados.NUEVO
                    Me.tsbNuevo.Enabled = True
                    Me.tsbCancelar.Enabled = False
                    Me.tsbImprimir.Enabled = False
                    Me.tsbGrabar.Enabled = True
                    Me.tsbEnviarCorreo.Enabled = False

                    Me.Grid.Locked = True 'Se habilitará hasta que asignen un folio de venta para consultar sus disponibles.

                    Me.GridSeries.Locked = True
                    If Me.oDocumento.AFECTA_INVENTARIOS = True Then
                        Me.GridSeries.Locked = False
                        Me.btnSeries.Visible = True
                    End If

                    Me.txtFolioDevolucion.Enabled = True
                    Me.txtFolioVenta.Enabled = True
                    Me.txtConcepto.Enabled = True
                    Me.dtFecha.Enabled = True

                    Me.cboFormaPago.Enabled = True

                    Me.tssEstado.Text = "Estado: Agregando nuevo movimiento"

                    If Me.Visible = True Then
                        Me.txtFolioDevolucion.Focus()
                    End If

                Case enumEstados.APLICADO
                    Me.tsbNuevo.Enabled = True
                    Me.tsbGrabar.Enabled = False
                    Me.tsbCancelar.Enabled = True
                    Me.tsbImprimir.Enabled = True
                    Me.tsbEnviarCorreo.Enabled = True

                    Me.Grid.Locked = True
                    Me.GridSeries.Locked = True
                    Me.btnSeries.Visible = False

                    Me.txtFolioDevolucion.Enabled = False
                    Me.txtFolioVenta.Enabled = False
                    Me.txtConcepto.Enabled = False
                    Me.dtFecha.Enabled = False

                    Me.tssEstado.Text = "Estado: Consultando movimiento"

                    Me.tsbImprimir.Select()

                Case enumEstados.CANCELADO
                    Me.tsbNuevo.Enabled = True
                    Me.tsbGrabar.Enabled = False
                    Me.tsbCancelar.Enabled = False
                    Me.tsbImprimir.Enabled = True
                    Me.tsbEnviarCorreo.Enabled = True

                    Me.Grid.Locked = True
                    Me.GridSeries.Locked = True
                    Me.btnSeries.Visible = False

                    Me.txtFolioDevolucion.Enabled = False
                    Me.txtFolioVenta.Enabled = False
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

    Private Function CargarVenta() As Boolean
        Dim bResultado As Boolean = False
        Try
            Me.oVenta = New Class_Ventas_Global(Me.txtFolioVenta.Text)

            If Me.oVenta.Existe = False Then
                MsgBox("No existe la venta indicada.", MsgBoxStyle.Exclamation, Me.Name)
                Return False
            End If

            oCliente = New Class_CatClientes(Me.oVenta.CODIGO_CLIENTE)
            Dim oAlmacen As New Class_CatAlmacenes(Me.oVenta.CODIGO_ALMACEN)
            Me.txtCliente.Text = Me.oVenta.CODIGO_CLIENTE
            Me.lblCliente.Text = Me.oCliente.NOMBRE_CLIENTE
            Me.txtAlmacen.Text = Me.oVenta.CODIGO_ALMACEN
            Me.lblAlmacen.Text = oAlmacen.NOMBRE_ALMACEN
            Me.txtTipoCambio.Text = Me.oVenta.TIPO_DE_CAMBIO.ToString
            Me.chkVentaPublicoGeneral.Checked = CBool(Me.oVenta.ES_VENTA_PUBLICO_GENERAL)
            Me.txtSaldo.Text = FormatImporteContable(Me.oVenta.SALDO)

            Dim dTabla As DataTable = Me.oVenta.ObtenerDetalleDisponiblesParaDevolucion
            If dTabla.Rows.Count = 0 Then
                MsgBox("No hay disponibles en la venta para devolver.", MsgBoxStyle.Exclamation, Me.Name)
                Return False
            End If

            Me.Grid.Locked = False
            Me.Grid.DataSource = dTabla
            Me.FormateaGrid()
            Me.Grid.Row(Me.Grid.Rows - 1).Locked = True 'Para bloquear la edición del último rengló que sale automáticamente.

            Me.txtFolioDevolucion.Enabled = False 'Se bloqueda por si quedó habilitado.
            Me.txtFolioVenta.Enabled = False 'Se bloquea, si se ocupa cambiar que le den nuevo.

            Me.Totales()

            bResultado = True
        Catch ex As Exception
            HandleError(Me.Name, "CargarVenta", ex)
        End Try

        Return bResultado
    End Function

    Private Function Consultar() As Boolean
        Dim bResultado As Boolean = False
        Dim sFolio As String = Me.txtFolioDevolucion.Text

        Try
            Me.tsbTimbrar.Visible = False
            Me.tsbCancelarTimbre.Visible = False
            Me.tsbRecuperarXMLPDF.Visible = False
            Me.tsbEnviarCorreo.Visible = False

            Me.Inicializa()
            Me.oDevolucion = New Class_CXC_Devoluciones_Global(sFolio)

            If Me.oDevolucion.Existe = False Then
                Me.GeneraFolio()
                Me.Cambia_Estado(enumEstados.NUEVO)
                Me.txtFolioDevolucion.Enabled = False
                Return False
            End If

            Me.txtFolioDevolucion.Enabled = False

            Me.oVenta = New Class_Ventas_Global(Me.oDevolucion.FOLIO_VENTA)

            With oDevolucion
                Me.lblVersionCFDI.Text = "" & Me.oDevolucion.VERSION_ESQUEMA_XML
                Me.DesplegarFormasPago(True) 'Para forzar a que muestre todos incluso los que están dados de baja porque al consultarlos fallaria si no estuvieran.

                Me.txtFolioDevolucion.Text = .FOLIO_DEVOLUCION
                Me.txtFolioVenta.Text = .FOLIO_VENTA
                Me.txtFolioDescuento.Text = .FOLIO_DESCUENTO_DEVOLUCION

                Me.dtFecha.Value = .FECHA
                Me.txtCliente.Text = .CODIGO_CLIENTE
                Me.lblCliente.Text = .NOMBRE_CLIENTE
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

                Me.cboMoneda.Text = .CODIGO_MONEDA_SAT
                Me.txtTipoCambio.Text = .TIPO_DE_CAMBIO.ToString

                If .TIPO_DE_CAMBIO > 0 Then
                    Me.CalculaImporteDolares()
                End If

                If txtLEN("" & .CODIGO_METODO_PAGO_EVENTO) = True Then
                    Me.cboFormaPago.SelectedValue = .CODIGO_METODO_PAGO
                Else
                    Me.cboFormaPago.SelectedIndex = -1
                End If

                If txtLEN("" & .CODIGO_METODO_PAGO_EVENTO) = True Then
                    Me.cboMetodoPago.SelectedValue = .CODIGO_METODO_PAGO_EVENTO
                Else
                    Me.cboMetodoPago.SelectedIndex = -1
                End If

                If txtLEN("" & .CODIGO_USO_CFDI) = True Then
                    Me.cboUsoCFDI.SelectedValue = .CODIGO_USO_CFDI
                Else
                    Me.cboUsoCFDI.SelectedIndex = -1
                End If

                Me.tssElaboro.Text = "Elaboró : " & .NOMBRE_USUARIO_GRABO & " el " & Format(.FECHA_SERVIDOR, "dd-MMM-yyyy hh:mm tt")
                If .ESTATUS_DEVOLUCION = "C" Then
                    Me.tssCancelo.Text = "Canceló : " & .NOMBRE_USUARIO_CANCELO & " el : " & Format(.FECHA_CANCELACION, "dd-MMM-yyyy hh:mm tt")
                End If

                Me.txtSaldo.Text = FormatImporteContable(Me.oVenta.SALDO)

                Me.Grid.DataSource = .ObtenerDetalle
            End With

            Me.FormateaGrid()

            bResultado = True

            Me.GestionaCambioEstado()

            If Empresa_Sistema.FELECTRONICA_ACTIVA = True And oDocumento.TIMBRA_DOCUMENTO = True Then
                If Me.oDevolucion.TIMBRADO_CFDI = "0" AndAlso Me.oDevolucion.TIMBRADO_DESCARTADO = "0" AndAlso Me.oDevolucion.VERSION_ESQUEMA_XML <> "2.2" AndAlso Me.oVenta.TIMBRADO_CFDI = "1" Then 'Pregunta por campos de la dev y de la factura(de ambos)
                    Me.tsbTimbrar.Visible = True
                ElseIf Me.oDevolucion.ESTATUS_DEVOLUCION = "C" AndAlso Me.oDevolucion.TIMBRADO_CFDI = "1" AndAlso Me.oDevolucion.TIMBRADO_DESCARTADO = "0" AndAlso Me.oDevolucion.ESTATUS_CANCELACION_CFDI = "0" Then
                    Me.tsbCancelarTimbre.Visible = True
                End If

                If Me.oDevolucion.TIMBRADO_CFDI = "1" Then
                    Me.tsbRecuperarXMLPDF.Visible = True
                    Me.tsbEnviarCorreo.Visible = True
                End If
            End If

        Catch ex As Exception
            HandleError(Me.Name, "Consultar", ex)
        End Try

        Return bResultado
    End Function

    Private Function Grabar() As Boolean
        Const sProcedure As String = "Grabar"
        Dim bResultado As Boolean = False

        Dim i As Integer, sListaSeries As String = "", bTimbrar As Boolean = False

        Try
            If Me.Validar = False Then
                Return False
            End If

            Me.GeneraFolio()

            Me.oDevolucion = New Class_CXC_Devoluciones_Global

            With Me.oDevolucion
                .FOLIO_VENTA = Me.txtFolioVenta.Text
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

                If Empresa_Sistema.FELECTRONICA_ACTIVA = True And oDocumento.TIMBRA_DOCUMENTO = True Then
                    If Me.oVenta.TIMBRADO_CFDI = "1" Then 'Si se timbró la venta, se considera que la dev será electrónica, nota también hay dev de remisiones que no afectaton timbre.
                        .ES_COMPROBANTE_ELECTRONICO = "1"
                        bTimbrar = True
                    Else
                        If MsgBox("La factura no fue timbrada de modo que esta devolución tampoco será timbrada, seguro desea continuar de todas formas ?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, Me.Name) = MsgBoxResult.No Then
                            Return False
                        End If
                    End If
                Else
                    .ES_COMPROBANTE_ELECTRONICO = "0"
                End If

                .ES_A_PUBLICO_GENERAL = Convert.ToInt32(Me.chkVentaPublicoGeneral.Checked).ToString
                .CODIGO_METODO_PAGO = Me.cboFormaPago.SelectedValue.ToString
                .CODIGO_METODO_PAGO_EVENTO = Me.cboMetodoPago.SelectedValue.ToString
                .CODIGO_USO_CFDI = Me.cboUsoCFDI.SelectedValue.ToString
                .CODIGO_MONEDA_SAT = Me.cboMoneda.Text

                If .GrabaDevolucionGlobal = False Then
                    Return False
                End If

                Me.txtFolioDevolucion.Text = .FOLIO_DEVOLUCION

                Dim dCantidad As Decimal

                For i = 1 To Me.Grid.Rows - 1
                    dCantidad = valorNumericoD(Me.Grid.Cell(i, Me.igyCantidad).Text)
                    If dCantidad > 0 Then
                        .NuevoRenglon()

                        .oDetalle.FOLIO_DEVOLUCION = .FOLIO_DEVOLUCION
                        .oDetalle.CODIGO_ARTICULO = Me.Grid.Cell(i, Me.igyCodigo).Text.ToUpper
                        .oDetalle.ID_VENTA_DETALLE = CInt(Me.Grid.Cell(i, Me.igyIdOrigen).Text)
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
                        .oDetalle.PRECIO_TOTAL = valorNumericoD(Me.Grid.Cell(i, Me.igyPRECIO_TOTAL).Text)
                        .oDetalle.LISTA_SERIES = sListaSeries

                        If .oDetalle.GrabaRenglon = False Then
                            MsgBox("Error al tratar de grabar el detalle.", MsgBoxStyle.Exclamation, sProcedure)
                            Return False
                        End If

                        sListaSeries = ""
                    End If
                Next

                If oDocumento.AFECTA_INVENTARIOS = True Then
                    .AfectaInventarios()
                End If

                Dim oDocumentoVenta As New Class_CatDocumentos(Me.oVenta.CODIGO_DOCUMENTO)

                If oDocumento.AFECTA_CONTABILIDAD = True AndAlso oDocumentoVenta.AFECTA_CONTABILIDAD = True Then 'Si ambos documentos deben afectar a conta se hace la póliza
                    If .AplicarPoliza = False Then
                        Return False
                    End If
                End If

                If Empresa_Sistema.FELECTRONICA_ACTIVA = True And bTimbrar = True Then
                    Me.oDevolucion = New Class_CXC_Devoluciones_Global(Me.txtFolioDevolucion.Text) 'Refrescar documento para evitar algún error por dato no cargado.
                    Me.oDevolucion.GeneraDevolucionElectronica(False, True)
                End If

            End With

            bResultado = True

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    Private Function Cancelar() As Boolean
        MsgBox("FALTA:Cancelar", vbExclamation)
        Return False
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

    Private Sub Totales()
        Try
            Dim i As Integer, dCantidad As Decimal, dPrecio As Decimal, dPorcentajeIVA As Decimal, dImporte As Decimal, iIDOrigen As Integer = 0, dImporteTotal As Double = 0
            Dim oArticulo As New Class_CatArticulos
            Dim dIEPS_PORCENTAJE As Decimal = 0, dIEPS_UNITARIO As Decimal = 0, dIEPS_IMPORTE As Decimal = 0, dBASE_IEPS As Decimal = 0, dBASE_IVA As Decimal = 0, dPRECIO_TOTAL As Decimal = 0, dIVA_IMPORTE As Decimal = 0
            Dim dtSubtotal As Decimal = 0, dtIEPS As Decimal = 0, dtImpuesto As Decimal = 0, dtTotal As Decimal = 0

            Me.lblSubtotal.Text = FormatImporteContable(0)
            Me.lblIEPSIncluido.Text = FormatImporteContable(0)
            Me.lblIEPS.Text = FormatImporteContable(0)
            Me.lblImpuesto.Text = FormatImporteContable(0)
            Me.lblTotal.Text = FormatImporteContable(0)

            Me.lblSubtotalDolares.Text = FormatImporteContable(0)
            Me.lblImpuestoDolares.Text = FormatImporteContable(0)
            Me.lblTotalDolares.Text = FormatImporteContable(0)

            For i = 1 To Me.Grid.Rows - 1
                If txtLEN(Me.Grid.Cell(i, Me.igyCodigo).Text) = True Then
                    oArticulo = New Class_CatArticulos(Me.Grid.Cell(i, Me.igyCodigo).Text)

                    If txtLEN(Me.Grid.Cell(i, Me.igyCantidad).Text) = True Then
                        dCantidad = valorNumericoD(Me.Grid.Cell(i, Me.igyCantidad).Text)
                        dPrecio = valorNumericoD(Me.Grid.Cell(i, Me.igyPrecio).Text)
                        iIDOrigen = CInt(valorNumericoD(Me.Grid.Cell(i, Me.igyIdOrigen).Text))
                        dPorcentajeIVA = valorNumericoD(Me.Grid.Cell(i, Me.igyImpuestoPorcentaje).Text)

                        dIEPS_PORCENTAJE = CDec(valorNumerico(Me.Grid.Cell(i, Me.igyIEPS_PORCENTAJE).Text))
                        dIEPS_UNITARIO = CDec(Redondear(dPrecio * (dIEPS_PORCENTAJE / 100), 4))

                        dBASE_IEPS = RedondearD((dPrecio * dCantidad), 2)

                        dIEPS_IMPORTE = RedondearD(dBASE_IEPS * (dIEPS_PORCENTAJE / 100), 2)
                        dBASE_IVA = dIEPS_IMPORTE + dBASE_IEPS
                        dIVA_IMPORTE = RedondearD(dBASE_IVA * ((dPorcentajeIVA / 100)), 2)
                        dPRECIO_TOTAL = dPrecio

                        Me.Grid.Cell(i, Me.igyIEPS_UNITARIO).Text = dIEPS_UNITARIO.ToString
                        Me.Grid.Cell(i, Me.igyBASE_IEPS).Text = dBASE_IEPS.ToString
                        Me.Grid.Cell(i, Me.igyIEPS_IMPORTE).Text = dIEPS_IMPORTE.ToString
                        Me.Grid.Cell(i, Me.igyBASE_IVA).Text = dBASE_IVA.ToString
                        Me.Grid.Cell(i, Me.igyImpuestoImporte).Text = dIVA_IMPORTE.ToString

                        If Me.oCliente.ES_CONTRIBUYENTE_IEPS = "0" And dPrecio > 0 Then 'Cuando no es contribuyente se le adjunta al precio el ieps, es decir se le incluye
                            dPRECIO_TOTAL = RedondearD(dPrecio + dIEPS_UNITARIO, 3)
                        End If

                        Me.Grid.Cell(i, Me.igyPRECIO_TOTAL).Text = dPRECIO_TOTAL.ToString

                        dImporte = RedondearD((dPrecio * dCantidad), Empresa_Sistema.DECIMALES_CONTABILIDAD) 'no hacemos nada con este valor de momento
                        dImporteTotal = RedondearD((dPRECIO_TOTAL * dCantidad), Empresa_Sistema.DECIMALES_CONTABILIDAD)

                        Me.Grid.Cell(i, Me.igyImporte).Text = dImporteTotal.ToString
                    End If

                End If
            Next i

            dtIEPS = RedondearD(CDec(FG_Grid_SumaCol(Me.Grid, Me.igyIEPS_IMPORTE)), Empresa_Sistema.DECIMALES_CONTABILIDAD)

            If Me.oCliente.ES_CONTRIBUYENTE_IEPS = "1" Then
                Me.lblIEPSIncluido.Text = FormatImporteContable(0)
                Me.lblIEPS.Text = FormatImporteContable(dtIEPS)
            Else
                Me.lblIEPSIncluido.Text = FormatImporteContable(dtIEPS)
                Me.lblIEPS.Text = FormatImporteContable(0)
                dtIEPS = 0 'Se establece en 0 porque luego se le suma este valor al total y al ser includo entonces debe ser 0
            End If

            dtSubtotal = RedondearD(CDec(FG_Grid_SumaCol(Me.Grid, Me.igyImporte)), Empresa_Sistema.DECIMALES_CONTABILIDAD)
            dtImpuesto = RedondearD(CDec(FG_Grid_SumaCol(Me.Grid, Me.igyImpuestoImporte)), Empresa_Sistema.DECIMALES_CONTABILIDAD)
            dtTotal = dtSubtotal + dtIEPS + dtImpuesto

            Me.lblSubtotal.Text = FormatImporteContable(dtSubtotal)
            Me.lblImpuesto.Text = FormatImporteContable(dtImpuesto)
            Me.lblTotal.Text = FormatImporteContable(dtTotal)

            If valorNumerico(Me.txtTipoCambio.Text) > 0 Then
                Me.CalculaImporteDolares()
            End If

        Catch ex As Exception
            HandleError(Me.Name, "Totales", ex)
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

            Me.oVenta = New Class_Ventas_Global(Me.txtFolioVenta.Text)
            If oVenta.ESTATUS_VENTA <> "A" Then
                MsgBox("La venta debe de estar en estatus de aplicado(A), actualmente esta en (" & Me.oVenta.ESTATUS_VENTA & ")", MsgBoxStyle.Exclamation, sProcedure)
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

            Me.Totales()

            If valorNumerico(Me.lblTotal.Text) <= 0 Then
                MsgBox("El total debe ser mayor a cero.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            'FALTA:Validaciones de disponibles de series
            If Me.oVenta.TIENE_SERIES = True Then
                MsgBox("FALTA:Validaciones de disponibles de series", vbExclamation, sProcedure)
                Return False
            End If

            'FALTA:Validaciones de datos fiscales si se va timbrar

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
            dDisponible = Me.oVenta.ObtenerDisponibleRenglon(CInt(Me.Grid.Cell(Renglon, Me.igyIdOrigen).Text))
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

    Private Sub DesplegarFormasPago(ByVal bTodos As Boolean)
        'Dim dViewFormasPago As New Data.DataView
        Try
            With Me.cboFormaPago
                .DisplayMember = "NOMBRE_METODO_PAGO"
                .ValueMember = "CODIGO_METODO_PAGO"

                If bTodos = True Then
                    dViewFormasPago = New Data.DataView(dtFormasPagoTodas)
                Else
                    dViewFormasPago = New Data.DataView(dtFormasPagoActivas)
                End If

                .DataSource = dViewFormasPago
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarFormasPago", ex)
        End Try
    End Sub

    Private Sub DesplegarMetodosPago()
        Dim dView As New Data.DataView
        Try
            With Me.cboMetodoPago
                .DisplayMember = "NOMBRE_METODO_PAGO_EVENTO"
                .ValueMember = "CODIGO_METODO_PAGO_EVENTO"
                dView = New Data.DataView(dtMetodosPago)
                .DataSource = dView
                .SelectedIndex = -1
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarMetodosPago", ex)
        End Try
    End Sub

    Private Sub DesplegarMonedas()
        Dim dView As New Data.DataView
        Try
            With Me.cboMoneda
                .Items.Add("MXN")
                .Items.Add("USD")
                .Text = "MXN"
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarMonedas", ex)
        End Try
    End Sub

    Private Sub DesplegarUsoCFDIPersonasFisicas()
        Try
            With Me.cboUsoCFDI
                .DisplayMember = "NOMBRE_USO_CFDI"
                .ValueMember = "CODIGO_USO_CFDI"
                Dim dView As New Data.DataView(dtUsosCFDIPersonasFisicas)
                dView.Sort = "NOMBRE_USO_CFDI"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedIndex = 0
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarUsoCFDIPersonasFisicas", ex)
        End Try
    End Sub

    Private Sub EnviarCorreo()
        Try
            Me.tsbEnviarCorreo.Enabled = False
            Me.tsbEnviarCorreo.Text = "Enviando..."
            Application.DoEvents()
            Me.oDevolucion.EnviarCorreo()
        Catch ex As Exception
            HandleError(Me.Name, "EnviarCorreo", ex)
        Finally
            Me.tsbEnviarCorreo.Text = "&Enviar correo"
            Me.tsbEnviarCorreo.Enabled = True
        End Try
        Application.DoEvents()
    End Sub

#End Region

End Class