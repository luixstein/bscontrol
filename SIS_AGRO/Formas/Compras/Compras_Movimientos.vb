Option Strict On

Imports System.IO

Public Class Compras_Movimientos

#Region "Campos privados"
    Private oCompras As New Class_Compras_Global
    Private oProveedores As New Class_CatProveedores
    Private oDocumento As New Class_CatDocumentos
    Private oRequisicion As New Class_Requisiciones_Global

    Private bDocumentosCargados As Boolean
    Private bEsReferencia As Boolean
    Private bIVAModificado As Boolean
    Private Estado As enumEstados
    Private _ConsultaExterior As Boolean
    Private dPorcentajeIVAGlobal As Double = 0

    Private Enum enumEstados
        NUEVO
        GRABADO
        PARCIALMENTE_RECEPCIONADO
        PEDIDO
        APLICADO
        CANCELADO
    End Enum

    Private oFormaDetalleCuentas As InventariosDetalleCuentasContables
    Private dtSeries As DataTable
    Private bCrearonColumnas As Boolean = False
#End Region

#Region "Columnas grid compras"
    Private igyCodigo As Short = 1
    Private igyDescripcion As Short = 2
    Private igyCantidad As Short = 3
    Private igyPrecio As Short = 4
    Private igyPRECIO_USD As Short = 5
    Private igyCosto As Short = 6
    Private igyUnidad As Short = 7
    Private igyImpuestoPorcentaje As Short = 8
    Private igyImporte As Short = 9
    Private igyIMPORTE_USD As Short = 10
    Private igyMargenUtilidad As Short = 11
    Private igyCostoMercado As Short = 12
    Private igyPrecioVenta As Short = 13
    Private igyCuentaContable As Short = 14
    Private igyImpuestoImporte As Short = 15
    Private igyIMPUESTO_IMPORTE_USD As Short = 16
    Private igyIdArticulo As Short = 17
    Private iGyNombreCuentaContable As Integer = 18
    Private iGyBoton As Integer = 19
    Private iGyIDAdicional As Integer = 20
    Private igyIEPS_PORCENTAJE As Short = 21
    Private igyIEPS_UNITARIO As Short = 22
    Private igyIEPS_UNITARIO_USD As Short = 23
    Private igyIEPS_IMPORTE As Short = 24
    Private igyIEPS_IMPORTE_USD As Short = 25
    Private igyBASE_IEPS As Short = 26
    Private igyBASE_IEPS_USD As Short = 27
    Private igyBASE_IVA As Short = 28
    Private igyBASE_IVA_USD As Short = 29
    Private igyID_INVENTARIO_MOVIMIENTOS_DETALLE_ENTRADA As Short = 30
    Private igyIDRequisicionDetalle As Short = 31 'Eliminar despues
    Private igyEsRequisicion As Short = 32
#End Region

#Region "Columnas grid series"
    Private igySeriePosicion As Short = 1
    Private igySerieCodigo As Short = 2
    Private igySerieDescripcion As Short = 3
    Private igySerieNumeroSerie As Short = 4
#End Region

#Region "Columnas grid entradas"
    Private igyGridEFolioEntrada As Short = 1
    Private igyGridEFechaEntrada As Short = 2
    Private igyGridEEstaCancelado As Short = 3
    Private igyGridETotal As Short = 4
    Private igyGridEFlete As Short = 5
#End Region

#Region "Propiedades"
    Public WriteOnly Property ConsultaExterior() As Boolean
        Set(ByVal value As Boolean)
            Me._ConsultaExterior = value
        End Set
    End Property
#End Region

#Region "Opciones"
    Private Sub tsbNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbNuevo.Click
        Me.Inicializa()
        Me.Cambia_Estado(enumEstados.NUEVO)
    End Sub

    Private Sub tsbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGrabar.Click
        If Me.Grabar() = True Then
            Me.Consultar()
        End If
    End Sub

    Private Sub tsbAplicar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbAplicar.Click
        If Me.chkEsInventariable.Checked = False Then 'Sólo si es de servicios se valida la orden de compra, si es inven dentro el mismo aplicar hay validaciones para checar las entradas de inventarios.
            If Me.ValidarOrdenCompra() = False Then
                Return
            End If
        End If

        If Me.Aplicar() = True Then
            Me.Consultar()
        End If
    End Sub

    Private Sub tsbCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCancelar.Click
        If Me.oDocumento.AFECTA_CXP = True Then
            If Me.CancelarCompra = True Then
                Me.Consultar()
            End If
        Else
            If Me.CancelaOrdenCompra() = True Then
                Me.Consultar()
            End If
        End If
    End Sub

    Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click
        Me.oCompras.Imprimir()
    End Sub

    Private Sub tsbPasarOrdenACompra_Click(sender As Object, e As EventArgs) Handles tsbPasarOrdenACompra.Click
        If Me.chkEsInventariable.Checked = True Then
            MsgBox("No es posible pasar una orden de compra inventariable a compra, debe hacer la compra directo y relacionando las entradas de inventario.", vbExclamation, Me.Name)
        Else
            Me.PasarOrdenACompra()
        End If
    End Sub

    Private Sub tsbPedir_Click(sender As Object, e As EventArgs) Handles tsbPedir.Click
        If Me.PedirOrdenCompra() = True Then
            Me.Consultar()
        End If
    End Sub

    Private Sub tsbEditarOC_Click(sender As Object, e As EventArgs) Handles tsbEditarOC.Click
        If Me.EditarOrdenCompra() = True Then
            Me.Consultar()
        End If
    End Sub

    Private Sub tsbRecepcionarEntrada_Click(sender As Object, e As EventArgs) Handles tsbRecepcionarEntrada.Click
        Me.RecepcionarEntrada()
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub

    Private Sub btnDocumentoAnterior_Click(sender As Object, e As EventArgs) Handles btnDocumentoAnterior.Click
        Me.Navegador("Anterior")
    End Sub

    Private Sub btnDocumentoSiguiente_Click(sender As Object, e As EventArgs) Handles btnDocumentoSiguiente.Click
        Me.Navegador("Siguiente")
    End Sub

    Private Sub tsbEditarCostos_Click(sender As Object, e As EventArgs) Handles tsbEditarCostos.Click
        Try
            Dim oCostos As New FrmCostosEdicion(Me.txtFolioCompra.Text, Me.CboDocumento.SelectedValue.ToString)
            If oCostos.bMovimientoEncontrado = True Then
                oCostos.ShowDialog()
                oCostos.Dispose()
                Me.Consultar()
            End If
        Catch ex As Exception
            HandleError(Me.Name, "tsbEditarCostos_Click", ex)
        End Try
    End Sub

    Private Sub BtnActualizaFolioProv_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnActualizaFolioProv.Click
        If Me.ActualizaFolioProveedor() = True Then
            Me.Consultar()
        End If
    End Sub

    Private Sub btnActualizaConcepto_Click(sender As Object, e As EventArgs) Handles btnActualizaConcepto.Click
        If Me.ActualizaConcepto() = True Then
            Me.Consultar()
        End If
    End Sub

    Private Sub btnSeries_Click(sender As Object, e As EventArgs) Handles btnSeries.Click
        Me.PrepararSeries()
    End Sub

    Private Sub btnSeleccionarArchivoSeries_Click(sender As Object, e As EventArgs) Handles btnSeleccionarArchivoSeries.Click
        Me.GestionaArchivoSeries()
    End Sub

    Private Sub btnCopiarLote_Click(sender As Object, e As EventArgs) Handles btnCopiarLote.Click
        Me.CopiarLote()
    End Sub

    Private Sub tsbAgregarXML_Click(sender As Object, e As EventArgs) Handles tsbAgregarXML.Click
        Me.AgregarXML()
    End Sub

    Private Sub tsbAgregarPDF_Click(sender As Object, e As EventArgs) Handles tsbAgregarPDF.Click
        Me.AgregarPDF()
    End Sub

    Private Sub btnTraerTodasEntradasInventarios_Click(sender As Object, e As EventArgs) Handles btnTraerTodasEntradasInventarios.Click
        Me.TraerTodasEntradasInventarios()
    End Sub

    Private Sub btnAgregarTodasEntradasInventarios_Click(sender As Object, e As EventArgs) Handles btnAgregarTodasEntradasInventarios.Click
        Me.AgregarTodasEntradasInventarios()
    End Sub

    Private Sub btnAgregarSeleccionadaEntradasInventarios_Click(sender As Object, e As EventArgs) Handles btnAgregarSeleccionadaEntradasInventarios.Click
        Me.AgregarSeleccionadaEntradasInventarios()
    End Sub

    Private Sub btnBorrarTodasEntradasInventarios_Click(sender As Object, e As EventArgs) Handles btnBorrarTodasEntradasInventarios.Click
        Me.BorrarTodasEntradasInventarios()
    End Sub
#End Region

#Region "Eventos de objetos"
#Region "Eventos"
    Private Sub Compras_Movimientos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Me._ConsultaExterior = True Then
            Dim sfolio As String = Me.txtFolioCompra.Text
            Me.DesplegarDocumentos(False)
            Me.DesplegarAlmacenes()
            Me.DesplegarMonedas()
            Me.DesplegarTiposEnvio()
            Me.Consultar()
            Me.GestionaCambioEstado()
            Me.txtFolioCompra.Enabled = False
            Me.InicializaExterno()
        Else
            Me.DesplegarDocumentos()
            Me.DesplegarAlmacenes()
            Me.DesplegarMonedas()
            Me.DesplegarTiposEnvio()
            Me.Inicializa()
            Me.bCrearonColumnas = True

            Me.Cambia_Estado(enumEstados.NUEVO)
        End If

        If Empresa_Sistema.VALIDA_SERIES_REPETIDAS_EN_ENTRADAS = True Then
            Me.txtLote.Visible = False : Me.btnCopiarLote.Visible = False : Me.lblDisplayLote.Visible = False
        Else
            Me.txtLote.Visible = True : Me.btnCopiarLote.Visible = True : Me.lblDisplayLote.Visible = True
        End If

        If Empresa_Sistema.MODO_REQUISICIONES_INVENTARIO = False Then
            Me.tsbPedir.Visible = False
            Me.tsbEditarOC.Visible = False
            Me.LblRequisicion.Visible = False
            Me.TxtRequisicion.Visible = False
            Me.btnTraerDetalleRequisicion.Visible = False
            Me.btnMultiplesRequisiciones.Visible = False
        End If
    End Sub

    Private Sub CboDocumento_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CboDocumento.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.Send("{TAB}")
            Case Keys.Escape
                CboDocumento.Focus()
        End Select
    End Sub

    Private Sub CmbDocumento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboDocumento.SelectedIndexChanged
        Me.oDocumento = New Class_CatDocumentos(Me.CboDocumento.SelectedValue.ToString)
        Me.OcultarControles()

        Me.oCompras = New Class_Compras_Global(Me.CboDocumento.SelectedValue.ToString)
        If _ConsultaExterior = False Then
            Me.Inicializa()
            Me.Cambia_Estado(enumEstados.NUEVO)
            'Me.txtFolioCompra.Focus()
        End If

        If Empresa_Sistema.TIPO_CAMBIO_POR_DIA Then
            Me.ObtenerTipoCambioDia()
        End If

    End Sub

    Private Sub CboAlmacen_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CboAlmacen.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.Send("{TAB}")
        End Select
    End Sub

    Private Sub txtFolioCompra_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFolioCompra.KeyDown
        Select Case e.KeyCode
            Case Keys.F6
                If Me.oDocumento.AFECTA_CXP = True Then
                    Me.txtFolioCompra.Text = Me.oCompras.BusquedaVisual_Compras() 'Si es CO
                Else
                    Me.txtFolioCompra.Text = Me.oCompras.BusquedaVisual_OrdenesCompra() 'Si es OC
                End If
            Case Keys.F7
                If Me.oDocumento.AFECTA_CXP = True Then
                    Me.txtFolioCompra.Text = Me.oCompras.BusquedaVisual_ComprasPorFolioOC() 'Si es CO
                End If
            Case Keys.Enter
                Me.Consultar()
        End Select
    End Sub

    Private Sub TxtFolioOrdenCompra_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFolioOC.KeyDown
        Select Case e.KeyCode
            Case Keys.F6
Buscar:
                Me.txtFolioOC.Text = Me.oCompras.BusquedaVisual_OrdenesCompra("G")
            Case Keys.Enter
                If txtLEN(Me.txtFolioOC.Text) = False Then
                    GoTo Buscar : Exit Sub
                End If
                If Me.Consultar(True) = False Then
                    GoTo Buscar : Exit Sub
                End If
        End Select
    End Sub

    Private Sub txtFolioProveedor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFolioProveedor.KeyDown
        Select Case e.KeyCode
            Case Keys.F6
Buscar:
                Me.txtFolioCompra.Text = Me.oCompras.BusquedaVisual_FolioProveedor()
            Case Keys.Enter
                Me.txtFolioOC.Focus()
        End Select
    End Sub

    Private Sub TxtCodigoProveedor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProveedor.KeyDown
        Dim sText As String
        Select Case e.KeyCode
            Case Keys.F6
Buscar:
                sText = Me.oProveedores.BusquedaVisual_PorDescripcion
                If txtLEN(sText) = True Then Me.txtProveedor.Text = sText
            Case Keys.Enter
                If txtLEN(Me.txtProveedor.Text) = False Then
                    Me.lblProveedor.Text = "" : GoTo Buscar : Exit Sub
                End If

                Me.oProveedores = New Class_CatProveedores(Me.txtProveedor.Text)
                If Me.oProveedores.Existe = False Then
                    Me.lblProveedor.Text = "" : GoTo Buscar : Exit Sub
                End If

                If Mid(Me.oProveedores.CUENTA_CONTABLE, 1, 1) <> "2" Then
                    'or Me.oProveedores.NOMBRE_TIPO_PROVEEDOR
                    MsgBox("La cuenta contable del proveedor debe empezar con '2'.", MsgBoxStyle.Information, Me.Text)
                    Me.lblProveedor.Text = ""
                    Me.txtProveedor.Focus()
                    Exit Sub
                End If
                Me.lblProveedor.Text = Me.oProveedores.Nombre_Proveedor
                Me.txtPlazo.Text = Me.oProveedores.Plazo.ToString
                Me.dtpFechaVencimiento.Value = Me.DtpFecha.Value.AddDays(CDbl(Me.txtPlazo.Text))

                txtTAB(e)
        End Select
    End Sub

    Private Sub txtRequisicion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtRequisicion.KeyDown
        Select Case e.KeyCode
            Case Keys.F6
Buscar:
                Me.TxtRequisicion.Text = Me.oRequisicion.BusquedaVisual_Requisiciones()
            Case Keys.Enter
                oRequisicion = New Class_Requisiciones_Global(Me.TxtRequisicion.Text)
                If oRequisicion.Existe = False Then
                    GoTo Buscar
                End If

                Me.TxtRequisicion.Text = oRequisicion.FOLIO_REQUISICION
                Me.btnTraerDetalleRequisicion.Focus()
        End Select
    End Sub

    Private Sub btnTraerDetalleRequisicion_Click(sender As Object, e As EventArgs) Handles btnTraerDetalleRequisicion.Click
        Me.TraerDetalleRequisicion()
        Me.TxtRequisicion.Enabled = False
    End Sub

    Private Sub btnMultiplesRequisiciones_Click(sender As Object, e As EventArgs) Handles btnMultiplesRequisiciones.Click
        Me.TraerDetalleMultiplesRequisiciones()
    End Sub

    Private Sub txtEntregarA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEntregarA.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.Send("{TAB}")
        End Select
    End Sub

    Private Sub txtSolicito_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSolicito.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.Send("{TAB}")
        End Select
    End Sub

    Private Sub txtConCargoA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtConCargoA.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.Send("{TAB}")
        End Select
    End Sub

    Private Sub txtPredio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPredio.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.Send("{TAB}")
        End Select
    End Sub

    Private Sub txtConfirmo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtConfirmo.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.Send("{TAB}")
        End Select
    End Sub

    Private Sub TxtConcepto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtConcepto.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                Me.Grid.Cell(1, 1).SetFocus()
            Case Keys.Escape
                Me.dtpFechaVencimiento.Focus()
        End Select
    End Sub

    Private Sub DtpFecha_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtpFecha.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.Send("{TAB}")
            Case Keys.Escape
                Me.CboAlmacen.Focus()
        End Select
    End Sub

    Private Sub DtpFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtpFecha.ValueChanged
        Me.dtpFechaVencimiento.Value = Me.DtpFecha.Value.AddDays(CDbl(Me.txtPlazo.Text))
        Me.DtpFechaFacturaProveedor.Value = Me.DtpFecha.Value

        If Empresa_Sistema.TIPO_CAMBIO_POR_DIA = True Then
            Me.ObtenerTipoCambioDia()
            Me.Totales()
        End If
    End Sub

    Private Sub txtPlazo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPlazo.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                Me.dtpFechaVencimiento.Value = Me.DtpFecha.Value.AddDays(CDbl(Me.txtPlazo.Text))
        End Select
    End Sub

    Private Sub DtpFechaVencimiento_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpFechaVencimiento.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.Send("{TAB}")
            Case Keys.Escape
                Me.txtPlazo.Focus()
        End Select
    End Sub

    Private Sub cboMoneda_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMoneda.SelectedIndexChanged
        Me.GestionaMoneda(True)
    End Sub

    Private Sub txtTipoCambio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTipoCambio.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                Me.txtTipoCambio.Text = Format(valorNumericoD(Me.txtTipoCambio.Text), "##0.0000")
                'Me.TotalesUSD()
                Me.Totales()
                If Empresa_Sistema.CONTROL_COSTOS_COMPRAS = True Then
                    Me.InicializaCostos()
                End If
                SendKeys.Send("{TAB}")
        End Select
    End Sub

    Private Sub Grid_CellChange(Sender As Object, e As FlexCell.Grid.CellChangeEventArgs) Handles Grid.CellChange
        If Me.Grid.ActiveCell.Col = Me.igyCantidad Or Me.Grid.ActiveCell.Col = Me.igyPrecio AndAlso Me.Estado = enumEstados.NUEVO Then
            Me.Totales()
        End If
    End Sub

    Private Sub Grid_KeyDown(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Grid.KeyDown
        Me.GestionaGrid(e)
    End Sub

    Private Sub Grid_ButtonClick(ByVal Sender As System.Object, ByVal e As FlexCell.Grid.ButtonClickEventArgs) Handles Grid.ButtonClick
        Me.GestionaDetalleCuentas()
    End Sub

    Private Sub Grid_Enter(sender As Object, e As EventArgs) Handles Grid.Enter
        If Me.cboMoneda.Text = "USD" Then
            If valorNumericoD(Me.txtTipoCambio.Text) <= 0 Then
                MsgBox("Asígne el tipo de cambio por favor.", MsgBoxStyle.Exclamation, Me.Text)
                If Me.txtTipoCambio.Enabled = True Then
                    Me.txtTipoCambio.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub TxtRetencion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRetencionIVA.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                Me.Totales()
            Case Keys.Escape
                txtTAB(e)
        End Select
    End Sub

    Private Sub txtIVA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtIVA.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                Me.txtIVA.Text = FormatImporteContable(valorNumericoD(Me.txtIVA.Text), True)
                'Me.txtTotal.Text = FormatImporteContable((valorNumerico(Me.TxtSubTotal.Text) + valorNumerico(Me.txtIVA.Text)) - valorNumerico(Me.txtRetencionIVA.Text) - valorNumerico(Me.txtRetencionISR.Text))
                Me.Totales(True)
                Me.bIVAModificado = True
        End Select
    End Sub

    Private Sub txtIVA_USD_KeyDown(sender As Object, e As KeyEventArgs) Handles txtIVA_USD.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                Me.txtIVA_USD.Text = FormatImporteContable(valorNumericoD(Me.txtIVA_USD.Text), True)
                'Me.txtTotal_USD.Text = FormatImporteContable((valorNumerico(Me.TxtSubTotal_USD.Text) + valorNumerico(Me.txtIVA_USD.Text)) - valorNumerico(Me.txtRetencionIVA_USD.Text) - valorNumerico(Me.txtRetencionISR_USD.Text))
                Me.Totales(True)
                Me.bIVAModificado = True
        End Select
    End Sub

    Private Sub GridSeries_KeyDown(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridSeries.KeyDown
        Me.GestionaGridSeries(e)
    End Sub

    Private Sub txtFolioOC_Inventarios_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFolioOC_Inventarios.KeyDown
        Select Case e.KeyCode
            Case Keys.F6
Buscar:
                Me.txtFolioOC_Inventarios.Text = Me.oCompras.BusquedaVisual_OrdenesCompraParaInventarios()
            Case Keys.Enter
                If txtLEN(Me.txtFolioOC_Inventarios.Text) = False Then
                    GoTo Buscar : Exit Sub
                End If
                Me.btnTraerTodasEntradasInventarios.Focus()
        End Select
    End Sub

    Private Sub chkEsInventariable_CheckedChanged(sender As Object, e As EventArgs) Handles chkEsInventariable.CheckedChanged
        If Me.chkEsInventariable.Checked = True Then
            Me.gbEntradas.Enabled = True
        Else
            Me.gbEntradas.Enabled = False
        End If
    End Sub

#End Region

#Region "Eventos Genericos"
    Private Sub txtTextoKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFolioCompra.KeyPress, txtFolioOC.KeyPress, txtProveedor.KeyPress, txtFolioProveedor.KeyPress,
    txtEntregarA.KeyPress, txtSolicito.KeyPress, TxtConcepto.KeyPress, txtConCargoA.KeyPress, txtPredio.KeyPress, txtConfirmo.KeyPress,
    DtpFecha.KeyPress, dtpFechaVencimiento.KeyPress, txtFolioOC_Inventarios.KeyPress, TxtRequisicion.KeyPress, btnTraerDetalleRequisicion.KeyPress, btnMultiplesRequisiciones.KeyPress, TxtNombreTransporte.KeyPress, CboTipoEnvio.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub txtSoloNumerosEnteros_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPlazo.KeyPress
        txtSoloNumerosEnteros(e)
        txtNoBeep(e)
    End Sub

    Private Sub txttxtSoloNumerosDecimales_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTipoCambio.KeyPress, txtIVA.KeyPress, txtIVA_USD.KeyPress, txtRetencionIVA.KeyPress, txtRetencionIVA_USD.KeyPress,
            txtRetencionISR.KeyPress, txtRetencionISR_USD.KeyPress
        Dim txt As TextBox = CType(sender, TextBox)
        txtSoloNumerosDecimales(e, txt.Text)
        txtNoBeep(e)
    End Sub

    Private Sub LblPoliza_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LblPoliza.LinkClicked
        Dim Child As New Frm_Contabilidad_Captura_Polizas()
        Child.FolioPolizaConsultaExterior = Me.LblPoliza.Text
        Child.ShowDialog()
        Child.Dispose()
    End Sub

#End Region

#End Region

#Region "Métodos y procedimientos"
    Private Sub Inicializa()
        Try
            Me.txtFolioCompra.Text = ""
            Me.txtFolioOC.Text = ""
            Me.txtFolioProveedor.Text = ""
            Me.txtProveedor.Text = ""
            Me.lblProveedor.Text = ""

            'Me.chkImprimirDolares.Checked = False
            Me.txtTipoCambio.Text = "0"

            Me.txtEntregarA.Text = ""
            Me.txtSolicito.Text = ""
            Me.TxtConcepto.Text = ""
            Me.txtConCargoA.Text = ""
            Me.txtPredio.Text = ""
            Me.txtConfirmo.Text = ""

            Me.chkEsInventariable.Checked = True
            Me.chkEsFiscal.Checked = False

            Me.dPorcentajeIVAGlobal = 0

            Me.txtSaldo_MXP.Text = FormatImporteContable(0)
            Me.txtSaldo_USD.Text = FormatImporteContable(0)

            Me.lblIVAcalculado.Text = "0" : Me.lblIVAcalculado.Visible = True
            Me.lblIVAcalculado_USD.Text = "0" : Me.lblIVAcalculado_USD.Visible = True

            Me.TxtSubTotal.Text = FormatImporteContable(0)
            Me.txtIEPS.Text = FormatImporteContable(0)
            Me.txtIVA.Text = FormatImporteContable(0)
            Me.txtTotal.Text = FormatImporteContable(0)
            Me.txtRetencionIVA.Text = FormatImporteContable(0)
            Me.txtRetencionISR.Text = FormatImporteContable(0)

            Me.TxtSubTotal_USD.Text = FormatImporteContable(0)
            Me.txtIEPS_USD.Text = FormatImporteContable(0)
            Me.txtIVA_USD.Text = FormatImporteContable(0)
            Me.txtTotal_USD.Text = FormatImporteContable(0)
            Me.txtRetencionIVA_USD.Text = FormatImporteContable(0)
            Me.txtRetencionISR_USD.Text = FormatImporteContable(0)

            Me.InicializaGrid()
            Me.InicializaGridSeries()
            Me.InicializaGridEntradas()

            Me.DtpFecha.Value = Date.Now
            Me.DtpFechaFacturaProveedor.Value = Date.Now
            Me.DtpFechaFacturaProveedor.Enabled = False
            Me.dtpFechaEntrega.Value = Date.Now
            Me.txtPlazo.Text = "30"
            Me.dtpFechaVencimiento.Value = Date.Now.AddDays(CDbl(Me.txtPlazo.Text))
            Me.LblEstatus.Text = "NUEVO"
            Me.LblPoliza.Text = ""

            Me.oCompras = New Class_Compras_Global(Me.CboDocumento.SelectedValue.ToString)
            Me.oProveedores = New Class_CatProveedores
            'Me.oDocumento = New Class_CatDocumentos(Me.CboDocumento.SelectedValue.ToString)

            Me.GeneraFolio()

            Me.bEsReferencia = False

            Me.oFormaDetalleCuentas = Nothing 'New InventariosDetalleCuentasContables

            Me.dtSeries = New DataTable("Series")

            Me.txtFolioOC_Inventarios.Text = ""
            Me.lstEntradasInventarios.Items.Clear()

            Me.TxtRequisicion.Text = ""

            Me.CboTipoEnvio.SelectedIndex = -1
            Me.TxtNombreTransporte.Text = ""

            Me.TabControl1.SelectedIndex = 0
        Catch ex As Exception
            HandleError(Me.Name, "Inicializa", ex)
        End Try
    End Sub

    Private Sub InicializaExterno()
        Try
            Me.tsbNuevo.Enabled = False
            Me.txtSolicito.Enabled = False
            'Me.TxtConcepto.Enabled = False
            Me.TxtConcepto.ReadOnly = True
            Me.txtConCargoA.Enabled = False
            Me.txtPredio.Enabled = False
            Me.txtConfirmo.Enabled = False

            Me.BtnActualizaFolioProv.Enabled = True
            Me.btnActualizaConcepto.Enabled = True
            'Me.DtpFecha.Value = Date.Now
            'Me.DtpFechaFacturaProveedor.Value = Date.Now
            'Me.txtPlazo.Text = "30"
            'Me.dtpFechaVencimiento.Value = Date.Now.AddDays(CDbl(Me.txtPlazo.Text))
            'Me.LblEstatus.Text = "N"
            'Me.LblPoliza.Text = ""

            'Me.TxtSubTotal.Text = FormatImporteContable(0)
            'Me.txtIVA.Text = FormatImporteContable(0)
            'Me.TxtRetencion.Text = FormatImporteContable(0)
            'Me.txtTotal.Text = FormatImporteContable(0)
            'Me.txtSaldo.Text = FormatImporteContable(0)
            'Me.dPorcentajeIVAGlobal = 0
            'Me.lblIVAcalculado.Text = "0" : Me.lblIVAcalculado.Visible = True

            'Me.InicializaGrid()

            'Me.oCompras = New Class_Compras_Global(Me.CboDocumento.SelectedValue.ToString)
            'Me.oProveedores = New Class_CatProveedores
            ''Me.oDocumento = New Class_CatDocumentos(Me.CboDocumento.SelectedValue.ToString)

            'Me.GeneraFolio()

            Me.bEsReferencia = False
        Catch ex As Exception
            HandleError(Me.Name, "Inicializa", ex)
        End Try
    End Sub

    Private Sub InicializaGrid()
        Try
            Me.Grid.DataSource = Nothing
            FG_Grid_Limpiar(Me.Grid)
            Me.Grid.Rows = 2
            Me.Grid.Cols = 33
            Me.FormateaGrid()
            Me.Grid.Cell(1, Me.iGyIDAdicional).Text = "1"
        Catch ex As Exception
            HandleError(Me.Name, "InicializaGrid", ex)
        End Try
    End Sub

    Private Sub FormateaGrid()
        Try
            With Me.Grid
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                .AutoRedraw = False

                '.DefaultFont = New Font("Tahoma", 8)
                .DisplayFocusRect = False
                '.DisplayDateTimeMask = True
                '.ExtendLastCol = True
                .DrawMode = FlexCell.DrawModeEnum.OwnerDraw
                .BorderStyle = FlexCell.BorderStyleEnum.FixedSingle
                .FixedRowColStyle = FlexCell.FixedRowColStyleEnum.Flat

                '.Rows = 2
                '.Cols = 33
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                .Column(Me.igyCodigo).Width = 75
                .Column(Me.igyDescripcion).Width = 250
                .Column(Me.igyCantidad).Width = 90
                .Column(Me.igyPrecio).Width = 100
                .Column(Me.igyPRECIO_USD).Width = 100
                .Column(Me.igyCosto).Width = 100
                .Column(Me.igyUnidad).Width = 75
                .Column(Me.igyImpuestoPorcentaje).Width = 70
                .Column(Me.igyImporte).Width = 100
                .Column(Me.igyIMPORTE_USD).Width = 100
                .Column(Me.igyMargenUtilidad).Width = 70
                .Column(Me.igyCostoMercado).Width = 100
                .Column(Me.igyPrecioVenta).Width = 100
                .Column(Me.igyCuentaContable).Width = 100
                .Column(Me.igyImpuestoImporte).Width = 100
                .Column(Me.igyIMPUESTO_IMPORTE_USD).Width = 100
                .Column(Me.igyIdArticulo).Width = 100
                .Column(Me.iGyNombreCuentaContable).Width = 70
                .Column(Me.iGyBoton).Width = 70
                .Column(Me.iGyIDAdicional).Width = 100
                .Column(Me.igyIEPS_PORCENTAJE).Width = 100
                .Column(Me.igyIEPS_UNITARIO).Width = 100
                .Column(Me.igyIEPS_UNITARIO_USD).Width = 100
                .Column(Me.igyIEPS_IMPORTE).Width = 100
                .Column(Me.igyIEPS_IMPORTE_USD).Width = 100
                .Column(Me.igyBASE_IEPS).Width = 100
                .Column(Me.igyBASE_IEPS_USD).Width = 100
                .Column(Me.igyBASE_IVA).Width = 100
                .Column(Me.igyBASE_IVA_USD).Width = 100
                .Column(Me.igyID_INVENTARIO_MOVIMIENTOS_DETALLE_ENTRADA).Width = 100
                .Column(Me.igyIDRequisicionDetalle).Width = 80
                .Column(Me.igyEsRequisicion).Width = 40

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                .Cell(0, Me.igyCodigo).Text = "Código"
                .Cell(0, Me.igyDescripcion).Text = "Descripción"
                .Cell(0, Me.igyCantidad).Text = "Cantidad"
                .Cell(0, Me.igyPrecio).Text = "Precio"
                .Cell(0, Me.igyPRECIO_USD).Text = "Precio_USD"
                .Cell(0, Me.igyCosto).Text = "Costo"
                .Cell(0, Me.igyUnidad).Text = "Unidad"
                .Cell(0, Me.igyImpuestoPorcentaje).Text = "IVA %"
                .Cell(0, Me.igyImporte).Text = "Importe"
                .Cell(0, Me.igyIMPORTE_USD).Text = "Importe_USD"
                .Cell(0, Me.igyMargenUtilidad).Text = "% Margen utilidad"
                .Cell(0, Me.igyCostoMercado).Text = "Costo mercado"
                .Cell(0, Me.igyPrecioVenta).Text = "Precio venta"
                .Cell(0, Me.igyCuentaContable).Text = "Cuenta Contable"
                .Cell(0, Me.igyImpuestoImporte).Text = "IVA"
                .Cell(0, Me.igyIMPUESTO_IMPORTE_USD).Text = "IVA_USD"
                .Cell(0, Me.igyIdArticulo).Text = "Id Articulo"
                .Cell(0, Me.iGyNombreCuentaContable).Text = "Nombre cuenta"
                .Cell(0, Me.iGyBoton).Text = "Costos"
                .Cell(0, Me.iGyIDAdicional).Text = "IdAdicional"
                .Cell(0, Me.igyIEPS_PORCENTAJE).Text = "IEPS_PORCENTAJE"
                .Cell(0, Me.igyIEPS_UNITARIO).Text = "IEPS_UNITARIO"
                .Cell(0, Me.igyIEPS_UNITARIO_USD).Text = "IEPS_UNITARIO_USD"
                .Cell(0, Me.igyIEPS_IMPORTE).Text = "IEPS_IMPORTE"
                .Cell(0, Me.igyIEPS_IMPORTE_USD).Text = "IEPS_IMPORTE_USD"
                .Cell(0, Me.igyBASE_IEPS).Text = "BASE_IEPS"
                .Cell(0, Me.igyBASE_IEPS_USD).Text = "BASE_IEPS_USD"
                .Cell(0, Me.igyBASE_IVA).Text = "BASE_IVA"
                .Cell(0, Me.igyBASE_IVA_USD).Text = "BASE_IVA_USD"
                .Cell(0, Me.igyID_INVENTARIO_MOVIMIENTOS_DETALLE_ENTRADA).Text = "ID_INVENTARIO_MOVIMIENTOS_DETALLE_ENTRADA"
                .Cell(0, Me.igyIDRequisicionDetalle).Text = "ID_REQUISICION_DETALLE" 'ELIMINAR ESTA COLUMNA DESPUES, YA NO SE UTILIZARA
                .Cell(0, Me.igyEsRequisicion).Text = "Es requisicion"

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                .Column(Me.igyCantidad).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.igyCantidad).DecimalLength = Empresa_Sistema.DECIMALES_CANTIDAD
                .Column(Me.igyCantidad).Alignment = FlexCell.AlignmentEnum.RightCenter

                '.Column(Me.igyPrecio).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_PRECIO)
                .Column(Me.igyPrecio).FormatString = "$ ###,###,##0." & StrDup(6, "0")
                .Column(Me.igyPrecio).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.igyPrecio).DecimalLength = 6 ' Empresa_Sistema.DECIMALES_PRECIO
                .Column(Me.igyPrecio).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.igyPRECIO_USD).FormatString = "$ ###,###,##0." & StrDup(6, "0")
                .Column(Me.igyPRECIO_USD).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.igyPRECIO_USD).DecimalLength = 6 ' Empresa_Sistema.DECIMALES_PRECIO
                .Column(Me.igyPRECIO_USD).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.igyCosto).FormatString = "$ ###,###,##0." & StrDup(6, "0")
                .Column(Me.igyCosto).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.igyCosto).DecimalLength = 6 ' Empresa_Sistema.DECIMALES_PRECIO
                .Column(Me.igyCosto).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.igyImpuestoPorcentaje).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.igyImpuestoPorcentaje).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
                .Column(Me.igyImpuestoPorcentaje).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.igyImporte).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
                .Column(Me.igyImporte).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.igyImporte).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
                .Column(Me.igyImporte).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.igyIMPORTE_USD).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
                .Column(Me.igyIMPORTE_USD).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.igyIMPORTE_USD).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
                .Column(Me.igyIMPORTE_USD).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.igyCuentaContable).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.igyImpuestoImporte).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.igyImpuestoImporte).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
                .Column(Me.igyImpuestoImporte).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.igyIMPUESTO_IMPORTE_USD).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.igyIMPUESTO_IMPORTE_USD).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
                .Column(Me.igyIMPUESTO_IMPORTE_USD).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.igyMargenUtilidad).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.igyMargenUtilidad).DecimalLength = 2
                .Column(Me.igyMargenUtilidad).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.igyCostoMercado).FormatString = "$ ###,###,##0." & StrDup(3, "0")
                .Column(Me.igyCostoMercado).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.igyCostoMercado).DecimalLength = 3 ' Empresa_Sistema.DECIMALES_PRECIO
                .Column(Me.igyCostoMercado).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.igyPrecioVenta).FormatString = "$ ###,###,##0." & StrDup(3, "0")
                .Column(Me.igyPrecioVenta).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.igyPrecioVenta).DecimalLength = 3 ' Empresa_Sistema.DECIMALES_PRECIO
                .Column(Me.igyPrecioVenta).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.igyIdArticulo).Mask = FlexCell.MaskEnum.Numeric
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                .Column(Me.igyImporte).Locked = True
                .Column(Me.igyIMPORTE_USD).Locked = True

                If bEsReferencia = True Then
                    .Column(Me.igyCodigo).Locked = True
                    .Column(Me.igyDescripcion).Locked = True
                    .Column(Me.igyCantidad).Locked = False
                    .Column(Me.igyPrecio).Locked = True
                    .Column(Me.igyUnidad).Locked = True
                    .Column(Me.igyImpuestoPorcentaje).Locked = True
                    .Column(Me.igyImporte).Locked = True
                    .Column(Me.igyCuentaContable).Locked = False
                    .Column(Me.igyImpuestoImporte).Locked = True
                Else
                    .Column(Me.igyCodigo).Locked = False
                    .Column(Me.igyPrecio).Locked = False
                    .Column(Me.igyUnidad).Locked = False
                    .Column(Me.igyImpuestoPorcentaje).Locked = False
                End If

                .Column(Me.iGyNombreCuentaContable).Locked = True
                .Column(Me.iGyIDAdicional).Locked = True
                .Column(Me.igyID_INVENTARIO_MOVIMIENTOS_DETALLE_ENTRADA).Locked = True
                .Column(Me.igyIDRequisicionDetalle).Locked = True
                .Column(Me.igyEsRequisicion).Locked = True

                .Column(Me.igyMargenUtilidad).Locked = True
                .Column(Me.igyCostoMercado).Locked = False
                .Column(Me.igyPrecioVenta).Locked = False

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                .Column(Me.igyImpuestoImporte).Visible = False
                .Column(Me.igyIMPUESTO_IMPORTE_USD).Visible = False
                .Column(Me.igyIdArticulo).Visible = False

                If Me.oDocumento.AFECTA_CXP = True Then
                    .Column(Me.iGyBoton).Visible = True
                    .Column(Me.iGyNombreCuentaContable).Visible = True
                Else
                    .Column(Me.iGyBoton).Visible = False
                    .Column(Me.iGyNombreCuentaContable).Visible = False
                End If

                .Column(Me.iGyIDAdicional).Visible = False

                .Column(Me.igyIEPS_PORCENTAJE).Visible = False
                .Column(Me.igyIEPS_UNITARIO).Visible = False
                .Column(Me.igyIEPS_UNITARIO_USD).Visible = False
                .Column(Me.igyIEPS_IMPORTE).Visible = False
                .Column(Me.igyIEPS_IMPORTE_USD).Visible = False
                .Column(Me.igyBASE_IEPS).Visible = False
                .Column(Me.igyBASE_IEPS_USD).Visible = False
                .Column(Me.igyBASE_IVA).Visible = False
                .Column(Me.igyBASE_IVA_USD).Visible = False
                .Column(Me.igyID_INVENTARIO_MOVIMIENTOS_DETALLE_ENTRADA).Visible = False
                .Column(Me.igyIDRequisicionDetalle).Visible = False
                .Column(Me.igyEsRequisicion).Visible = False

                .Column(Me.igyCosto).Visible = False 'Se utilizara la nueva función de costos

                .Column(Me.igyMargenUtilidad).Visible = False
                .Column(Me.igyCostoMercado).Visible = False
                .Column(Me.igyPrecioVenta).Visible = False

                If Empresa_Sistema.CONTROL_COSTOS_COMPRAS = True And Me.oDocumento.AFECTA_CXP = True Then
                    .Column(Me.igyMargenUtilidad).Visible = True
                    .Column(Me.igyCostoMercado).Visible = True
                    .Column(Me.igyPrecioVenta).Visible = True
                End If
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                .Column(Me.iGyBoton).CellType = FlexCell.CellTypeEnum.Button
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End With
        Catch ex As Exception
            HandleError(Me.Name, "FormateaGrid", ex)
        Finally
            Me.Grid.AutoRedraw = True
            Me.Grid.Refresh()
        End Try
    End Sub

    Private Sub GestionaCambioEstado()
        Select Case Me.LblEstatus.Text
            Case "NUEVO"
                Me.Cambia_Estado(enumEstados.NUEVO)
            Case "GRABADO"
                Me.Cambia_Estado(enumEstados.GRABADO)
            Case "PARCIALMENTE RECEPCIONADO"
                Me.Cambia_Estado(enumEstados.PARCIALMENTE_RECEPCIONADO)
            Case "PEDIDO"
                Me.Cambia_Estado(enumEstados.PEDIDO)
            Case "APLICADO"
                Me.Cambia_Estado(enumEstados.APLICADO)
            Case "CANCELADO"
                Me.Cambia_Estado(enumEstados.CANCELADO)
        End Select
    End Sub

    Private Sub Cambia_Estado(ByVal pEstado As enumEstados)
        Try
            Me.Estado = pEstado

            Me.tsbRecepcionarEntrada.Visible = False
            Me.tsbAgregarXML.Visible = False
            Me.tsbAgregarPDF.Visible = False
            'Me.tpEntradas.Enabled = False
            Me.chkEsInventariable.Enabled = False
            Me.btnTraerTodasEntradasInventarios.Enabled = False
            Me.btnAgregarTodasEntradasInventarios.Enabled = False
            Me.btnAgregarSeleccionadaEntradasInventarios.Enabled = False
            Me.btnBorrarTodasEntradasInventarios.Enabled = False
            Me.chkEsFiscal.Visible = False

            Select Case Me.Estado
                Case enumEstados.NUEVO
                    Me.tsbNuevo.Enabled = True
                    Me.tsbCancelar.Enabled = False
                    Me.tsbImprimir.Enabled = False
                    Me.tsbPasarOrdenACompra.Visible = False
                    Me.tsbEditarCostos.Visible = False
                    Me.tsbPedir.Visible = False
                    Me.tsbEditarOC.Visible = False
                    Me.chkEsInventariable.Enabled = True

                    If Me.oDocumento.AFECTA_CXP = True Then
                        Me.tsbGrabar.Enabled = False
                        Me.tsbAplicar.Enabled = True
                        Me.DtpFecha.Enabled = True
                        Me.CboAlmacen.Enabled = False
                        Me.CboDocumento.Enabled = True
                        Me.txtFolioCompra.Enabled = True
                        Me.txtFolioOC.Enabled = True
                        Me.txtProveedor.Enabled = False
                        Me.txtFolioProveedor.Enabled = True
                        Me.txtEntregarA.Enabled = False
                        Me.txtSolicito.Enabled = True 'changed
                        Me.txtConCargoA.Enabled = True 'changed
                        Me.txtPredio.Enabled = True 'changed
                        Me.txtConfirmo.Enabled = True 'changed

                        'Me.tpEntradas.Enabled = True' NO SIRVE PONERLO EN FALSE Y LUEGO DE ALGUN MODO EL HABILKTIAR LA PESTAÑA EN EL OCULTA HACE ENABLED EL GROUP COMPELTO
                        Me.btnTraerTodasEntradasInventarios.Enabled = True
                        Me.btnAgregarTodasEntradasInventarios.Enabled = True
                        Me.btnAgregarSeleccionadaEntradasInventarios.Enabled = True
                        Me.btnBorrarTodasEntradasInventarios.Enabled = True

                        Me.txtTipoCambio.Enabled = True 'changed
                        Me.txtPlazo.Enabled = True
                        'Me.TxtRetencion.Enabled = False
                        'Me.TxtConcepto.Enabled = False
                        Me.TxtConcepto.ReadOnly = False 'changed
                        Me.Grid.Locked = False
                        Me.GridSeries.Locked = False
                        Me.DtpFechaFacturaProveedor.Enabled = False
                        Me.cboMoneda.Enabled = False
                        Me.BtnActualizaFolioProv.Visible = False
                        Me.btnActualizaConcepto.Visible = False
                        Me.txtIVA.Enabled = True
                        Me.btnSeries.Enabled = True
                        Me.btnSeleccionarArchivoSeries.Enabled = True
                        Me.dtpFechaEntrega.Enabled = True

                        Me.tsslEstado.Text = "Estado: Agregando nuevo movimiento"
                        Me.tsslElaboro.Visible = False : Me.tsslElaboro.Text = ""
                        Me.tsslCancelo.Visible = False : Me.tsslCancelo.Text = ""
                        Me.DtpFechaFacturaProveedor.Visible = True : Me.lblDisplayFechaFacturaProveedor.Visible = True

                        Me.LblRequisicion.Visible = False
                        Me.TxtRequisicion.Visible = False
                        Me.btnTraerDetalleRequisicion.Visible = False
                        Me.btnMultiplesRequisiciones.Visible = False

                        If Me.Visible = True Then
                            If Me.bEsReferencia = False Then
                                Me.txtFolioCompra.Focus()
                            Else
                                Me.txtFolioProveedor.Focus()
                            End If
                        End If
                    Else 'oc
                        Me.tsbGrabar.Enabled = True
                        Me.tsbAplicar.Enabled = False
                        Me.DtpFecha.Enabled = True
                        Me.CboAlmacen.Enabled = True
                        Me.CboDocumento.Enabled = True
                        Me.txtFolioCompra.Enabled = True
                        Me.txtFolioOC.Enabled = True
                        Me.txtProveedor.Enabled = True
                        Me.txtFolioProveedor.Enabled = True
                        Me.txtEntregarA.Enabled = True
                        Me.txtSolicito.Enabled = True
                        Me.txtConCargoA.Enabled = True
                        Me.txtPredio.Enabled = True
                        Me.txtConfirmo.Enabled = True

                        Me.txtTipoCambio.Enabled = False
                        Dim sender As New Object, e As New EventArgs
                        cboMoneda_SelectedIndexChanged(sender, e) 'Al ser oc, en el nuevo puede quedar bloqueado el tpcam, de este modo refrescamos

                        Me.txtPlazo.Enabled = True
                        'Me.TxtRetencion.Enabled = True
                        'Me.TxtConcepto.Enabled = True
                        Me.TxtConcepto.ReadOnly = False
                        Me.Grid.Locked = False
                        Me.GridSeries.Locked = True
                        Me.DtpFechaFacturaProveedor.Enabled = False
                        Me.cboMoneda.Enabled = True
                        Me.BtnActualizaFolioProv.Visible = False
                        Me.btnActualizaConcepto.Visible = False
                        Me.txtIVA.Enabled = True
                        Me.btnSeries.Enabled = False
                        Me.btnSeleccionarArchivoSeries.Enabled = False

                        Me.tsslEstado.Text = "Estado: Agregando nuevo movimiento"
                        Me.tsslElaboro.Visible = False : Me.tsslElaboro.Text = ""
                        Me.tsslCancelo.Visible = False : Me.tsslCancelo.Text = ""
                        Me.DtpFechaFacturaProveedor.Visible = False : Me.lblDisplayFechaFacturaProveedor.Visible = False
                        Me.dtpFechaEntrega.Enabled = True

                        If Empresa_Sistema.MODO_REQUISICIONES_INVENTARIO Then
                            Me.LblRequisicion.Visible = True
                            Me.TxtRequisicion.Visible = True
                            Me.btnTraerDetalleRequisicion.Visible = True
                            Me.btnMultiplesRequisiciones.Visible = True
                        End If

                        Me.TxtRequisicion.Enabled = True
                        Me.btnTraerDetalleRequisicion.Enabled = True
                        Me.btnMultiplesRequisiciones.Enabled = True

                        Me.CboTipoEnvio.Enabled = True
                        Me.TxtNombreTransporte.Enabled = True

                        If Me.Visible = True Then
                            Me.txtFolioCompra.Focus()
                        End If
                    End If

                    Me.LblConceptoCancelacion.Visible = False
                    Me.TxtConceptoCancelacion.Visible = False

                Case enumEstados.GRABADO
                    Me.tsbNuevo.Enabled = True
                    Me.tsbGrabar.Enabled = True
                    Me.tsbAplicar.Enabled = False
                    Me.tsbCancelar.Enabled = True
                    Me.tsbImprimir.Enabled = True
                    Me.tsbPasarOrdenACompra.Visible = False
                    Me.tsbEditarCostos.Visible = False

                    If Empresa_Sistema.MODO_REQUISICIONES_INVENTARIO = True Then
                        'Me.tsbPedir.Visible = True la visibilidad se controlara desde consultar
                        Me.tsbPedir.Enabled = True
                    End If

                    Me.txtTipoCambio.Enabled = False
                    If Me.oDocumento.AFECTA_CXP = False Then 'Si no afecta, entonces es una oc y si se permite el botón.
                        Me.tsbPasarOrdenACompra.Visible = True
                        Me.tsbRecepcionarEntrada.Visible = True

                        'Dim sender As New Object, e As New EventArgs
                        'cboMoneda_SelectedIndexChanged(sender, e) 'Al ser oc, en el nuevo puede quedar bloqueado el tpcam, de este modo refrescamos
                    End If

                    Me.DtpFecha.Enabled = True
                    Me.CboAlmacen.Enabled = True
                    Me.CboDocumento.Enabled = False
                    Me.txtFolioCompra.Enabled = False
                    Me.txtFolioOC.Enabled = True
                    Me.txtProveedor.Enabled = True
                    Me.txtFolioProveedor.Enabled = True
                    Me.txtEntregarA.Enabled = True
                    Me.txtSolicito.Enabled = True
                    Me.txtConCargoA.Enabled = True
                    Me.txtPredio.Enabled = True
                    Me.txtConfirmo.Enabled = True
                    Me.chkEsInventariable.Enabled = True

                    Me.txtPlazo.Enabled = True
                    'Me.TxtRetencion.Enabled = True
                    'Me.TxtConcepto.Enabled = True
                    Me.TxtConcepto.ReadOnly = False
                    Me.Grid.Locked = False
                    Me.DtpFechaFacturaProveedor.Enabled = False
                    Me.BtnActualizaFolioProv.Visible = False
                    Me.btnActualizaConcepto.Visible = False
                    Me.txtIVA.Enabled = True
                    Me.btnSeries.Enabled = False
                    Me.btnSeleccionarArchivoSeries.Enabled = False

                    Me.tsslEstado.Text = "Estado: Consultando movimiento"
                    Me.tsslElaboro.Visible = True : Me.tsslElaboro.Text = "Elaboró: " + Me.oCompras.NOMBRE_USUARIO_GRABO.ToUpper + " el " + Format(Me.DtpFecha.Value, "dd/MMM/yy").ToUpper
                    Me.tsslCancelo.Visible = False : Me.tsslCancelo.Text = ""
                    Me.DtpFechaFacturaProveedor.Visible = False : Me.lblDisplayFechaFacturaProveedor.Visible = False

                    Me.LblConceptoCancelacion.Visible = False
                    Me.TxtConceptoCancelacion.Visible = False
                    Me.dtpFechaEntrega.Enabled = True

                    Me.TxtRequisicion.Enabled = False
                    Me.btnTraerDetalleRequisicion.Enabled = False
                    Me.btnMultiplesRequisiciones.Enabled = False

                    Me.CboTipoEnvio.Enabled = True
                    Me.TxtNombreTransporte.Enabled = True

                    Me.TxtConcepto.Focus()

                Case enumEstados.APLICADO, enumEstados.PARCIALMENTE_RECEPCIONADO, enumEstados.PEDIDO
                    Me.tsbNuevo.Enabled = True
                    Me.tsbGrabar.Enabled = False
                    Me.tsbAplicar.Enabled = False
                    Me.tsbCancelar.Enabled = True
                    Me.tsbImprimir.Enabled = True
                    Me.tsbPasarOrdenACompra.Visible = False
                    Me.tsbPedir.Visible = False
                    If Me.Estado <> enumEstados.PEDIDO Then
                        Me.tsbEditarOC.Visible = False
                    End If

                    If Me.Estado = enumEstados.PEDIDO Then
                        Me.tsbRecepcionarEntrada.Visible = True
                    End If

                    If Me.Estado = enumEstados.APLICADO And Me.oDocumento.AFECTA_CXP = True Then
                        Me.tsbEditarCostos.Visible = True

                        Me.tsbAgregarXML.Visible = True
                        Me.tsbAgregarPDF.Visible = True

                        Me.chkEsFiscal.Visible = True
                    End If

                    Me.DtpFecha.Enabled = False
                    Me.CboAlmacen.Enabled = False
                    Me.CboDocumento.Enabled = False
                    Me.txtFolioCompra.Enabled = False
                    Me.txtFolioOC.Enabled = False
                    Me.txtProveedor.Enabled = False
                    Me.txtEntregarA.Enabled = False
                    Me.txtSolicito.Enabled = False
                    Me.txtConCargoA.Enabled = False
                    Me.txtPredio.Enabled = False
                    Me.txtConfirmo.Enabled = False

                    Me.txtTipoCambio.Enabled = False
                    Me.txtPlazo.Enabled = False
                    'Me.TxtRetencion.Enabled = False
                    'Me.TxtConcepto.Enabled = False
                    Me.TxtConcepto.ReadOnly = True

                    Me.TxtRequisicion.Enabled = False
                    Me.btnTraerDetalleRequisicion.Enabled = False
                    Me.btnMultiplesRequisiciones.Enabled = False

                    Me.CboTipoEnvio.Enabled = False
                    Me.TxtNombreTransporte.Enabled = False

                    Me.Grid.Locked = True
                    Me.GridSeries.Locked = True
                    If Me.oDocumento.AFECTA_CXP = True Then
                        Me.DtpFechaFacturaProveedor.Visible = True : Me.lblDisplayFechaFacturaProveedor.Visible = True
                        'Me.TxtRequisicion.Visible = False
                        'Me.LblRequisicion.Visible = False
                        'Me.btnTraerDetalleRequisicion.Visible = False
                        'Me.TxtRequisicion.Enabled = False
                        ' Me.btnTraerDetalleRequisicion.Enabled = False
                    Else
                        Me.DtpFechaFacturaProveedor.Visible = False : Me.lblDisplayFechaFacturaProveedor.Visible = False
                    End If

                    Me.txtIVA.Enabled = False
                    Me.btnSeries.Enabled = False
                    Me.btnSeleccionarArchivoSeries.Enabled = False

                    Me.tsslEstado.Text = "Estado: Consultando movimiento"
                    Me.tsslElaboro.Visible = True : Me.tsslElaboro.Text = "Elaboró: " + Me.oCompras.NOMBRE_USUARIO_GRABO.ToUpper + " el " + Format(Me.DtpFecha.Value, "dd/MMM/yy").ToUpper
                    Me.tsslCancelo.Visible = False : Me.tsslCancelo.Text = ""
                    'Me.DtpFechaFacturaProveedor.Visible = True : Me.lblDisplayFechaFacturaProveedor.Visible = True
                    Me.DtpFechaFacturaProveedor.Enabled = False
                    Me.cboMoneda.Enabled = False
                    Me.txtFolioProveedor.Enabled = False

                    Me.tsbImprimir.Select()

                    Me.LblConceptoCancelacion.Visible = False
                    Me.TxtConceptoCancelacion.Visible = False
                    Me.dtpFechaEntrega.Enabled = False

                Case enumEstados.CANCELADO
                    Me.tsbNuevo.Enabled = True
                    Me.tsbGrabar.Enabled = False
                    Me.tsbAplicar.Enabled = False
                    Me.tsbCancelar.Enabled = False
                    Me.tsbImprimir.Enabled = True
                    Me.tsbEditarCostos.Visible = False
                    Me.tsbPedir.Visible = False
                    Me.tsbEditarOC.Visible = False

                    If Me.oDocumento.AFECTA_CXP = True Then
                        Me.tsbEditarCostos.Visible = True

                        Me.tsbAgregarXML.Visible = True
                        Me.tsbAgregarPDF.Visible = True
                        Me.chkEsFiscal.Visible = True
                    End If

                    Me.DtpFecha.Enabled = False
                    Me.CboAlmacen.Enabled = False
                    Me.CboDocumento.Enabled = False
                    Me.txtFolioCompra.Enabled = False
                    Me.txtFolioOC.Enabled = False
                    Me.txtProveedor.Enabled = False
                    Me.txtFolioProveedor.Enabled = False
                    Me.txtEntregarA.Enabled = False
                    Me.txtSolicito.Enabled = False
                    Me.txtConCargoA.Enabled = False
                    Me.txtPredio.Enabled = False
                    Me.txtConfirmo.Enabled = False

                    Me.txtTipoCambio.Enabled = False
                    Me.txtPlazo.Enabled = False
                    'Me.TxtRetencion.Enabled = False
                    'Me.TxtConcepto.Enabled = False
                    Me.TxtConcepto.ReadOnly = True
                    Me.Grid.Locked = True
                    Me.GridSeries.Locked = True
                    Me.DtpFechaFacturaProveedor.Enabled = False
                    Me.cboMoneda.Enabled = False
                    Me.BtnActualizaFolioProv.Visible = False
                    Me.btnActualizaConcepto.Visible = False
                    Me.txtIVA.Enabled = False
                    Me.btnSeries.Enabled = False
                    Me.btnSeleccionarArchivoSeries.Enabled = False

                    Me.TxtRequisicion.Enabled = False
                    Me.btnTraerDetalleRequisicion.Enabled = False
                    Me.btnMultiplesRequisiciones.Enabled = False

                    Me.CboTipoEnvio.Enabled = False
                    Me.TxtNombreTransporte.Enabled = False

                    Me.tsslEstado.Text = "Estado: Consultando movimiento"
                    Me.tsslElaboro.Visible = True : Me.tsslElaboro.Text = "Elaboró: " + Me.oCompras.NOMBRE_USUARIO_GRABO.ToUpper + " el " + Format(Me.DtpFecha.Value, "dd/MMM/yy").ToUpper
                    Me.tsslCancelo.Visible = True : Me.tsslCancelo.Text = "Canceló: " + Me.oCompras.NOMBRE_USUARIO_CANCELO.ToUpper + " el " + Format(Me.oCompras.FECHA_CANCELACION, "dd/MMM/yy").ToUpper

                    If Me.oDocumento.AFECTA_CXP = True Then
                        Me.DtpFechaFacturaProveedor.Visible = True : Me.lblDisplayFechaFacturaProveedor.Visible = True
                        'Me.LblRequisicion.Visible = False : Me.TxtRequisicion.Visible = True : Me.btnTraerDetalleRequisicion.Visible = True
                    Else
                        Me.DtpFechaFacturaProveedor.Visible = False : Me.lblDisplayFechaFacturaProveedor.Visible = False
                        'Me.LblRequisicion.Visible = False : Me.TxtRequisicion.Visible = True : Me.btnTraerDetalleRequisicion.Visible = True
                    End If

                    Me.dtpFechaEntrega.Enabled = False

                    Me.tsbImprimir.Select()

                    Me.LblConceptoCancelacion.Visible = True
                    Me.TxtConceptoCancelacion.Visible = True
                    'Me.TxtConceptoCancelacion.Enabled = False
                    Me.TxtConceptoCancelacion.ReadOnly = True

            End Select

            Me.OcultarControles()

            Application.DoEvents()

        Catch ex As Exception
            HandleError(Me.Name, "Cambia_Estado", ex)
        End Try
    End Sub

    Private Function Grabar() As Boolean
        Const sProcedure As String = "Grabar"
        Dim bResultado As Boolean = False
        Dim i As Integer

        If MsgBox("Deseas grabar la " & Me.CboDocumento.Text & " con el folio : " & Me.txtFolioCompra.Text & " ?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "Grabar") = MsgBoxResult.No Then
            Return False
        End If

        If Me.oDocumento.AFECTA_INVENTARIOS = True Then
            If Usuario.ValidaPermisoUsuarioDocumentoConAfectacionInventarios(Me.CboDocumento.SelectedValue.ToString, Me.CboAlmacen.SelectedValue.ToString) = False Then
                MsgBox("El usuario " & Usuario.Nombre_Usuario & " no tiene permiso para realizar el movimiento.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If
        Else
            If Usuario.ValidaPermisoUsuarioDocumentoSinAfectacionInventarios(Me.CboDocumento.SelectedValue.ToString) = False Then
                MsgBox("El usuario " & Usuario.Nombre_Usuario & " no tiene permiso para realizar el movimiento.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If
        End If

        If Me.Totales(True) = False Then
            Return False
        End If

        If Me.ValidarOrdenCompra() = False Then
            Return False
        End If

        If Empresa_Sistema.VALIDAR_LIMITE_CREDITO_PROVEEDORES = True Then
            Dim saldoProveedor As Decimal = 0
            oProveedores = New Class_CatProveedores(Me.txtProveedor.Text)

            Dim sql As New Class_find("SELECT ISNULL(SUM(SALDO),0) AS SALDO FROM COMPRA_GLOBAL WHERE CODIGO_PROVEEDOR='" & Me.txtProveedor.Text & "'")
            saldoProveedor = CDec(sql.Result1) + CDec(Me.txtTotal.Text)

            If saldoProveedor > oProveedores.LIMITE_CREDITO Then
                MsgBox("La compra que intenta realizar más el saldo del proveedor " & vbCrLf & "son " & FormatImporteContable(saldoProveedor) &
                       " y supera al límite de crédito de " & FormatImporteContable(oProveedores.LIMITE_CREDITO) & ". " & vbCrLf &
                       "No es posible realizar este movimiento.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If
        End If

        If Empresa_Sistema.MODO_REQUISICIONES_INVENTARIO AndAlso Me.chkEsInventariable.Checked Then

            'Valida que tenga folio de requisicion
            If txtLEN(Me.TxtRequisicion.Text) = False And Usuario.PERMISO_GRABAR_OC_SIN_REQUISICION = "0" Then
                MsgBox("Asígne un folio de requisición.", MsgBoxStyle.Exclamation, sProcedure)
                Me.TxtRequisicion.Focus()
                Return False
            End If

            'Valida pero dejará grabar aunque no haya disponible de requisición, por eso no pregunta por true/false
            Me.ValidaDisponiblesRequisicion(False)
        End If
        
        Try
            With Me.oCompras
                .FOLIO_COMPRA = Me.txtFolioCompra.Text
                .CODIGO_DOCUMENTO = Me.CboDocumento.SelectedValue.ToString
                .CODIGO_ALMACEN = Me.CboAlmacen.SelectedValue.ToString
                .CODIGO_PLAZA = Plaza.CODIGO_PLAZA
                .FECHA = Me.DtpFecha.Value
                .CODIGO_PROVEEDOR = Me.txtProveedor.Text
                .PLAZO = CInt(Me.txtPlazo.Text)
                .FECHA_VENCIMIENTO = Me.dtpFechaVencimiento.Value
                .SUBTOTAL = valorNumerico(Me.TxtSubTotal.Text)
                .IEPS_TOTAL_DESGLOSADO = valorNumerico(Me.txtIEPS.Text)
                .IMPUESTO = valorNumerico(Me.txtIVA.Text)
                .TOTAL = valorNumerico(Me.txtTotal.Text)
                .RETENCION_IVA = valorNumerico(Me.txtRetencionIVA.Text)
                .IMPUESTO_PORCENTAJE = dPorcentajeIVAGlobal
                .TIPO_DE_CAMBIO = CDbl(IIf(Me.cboMoneda.SelectedIndex = 1, valorNumerico(Me.txtTipoCambio.Text), 0))
                .ENTREGAR_A = Me.txtEntregarA.Text
                .SOLICITO = Me.txtSolicito.Text
                .CONCEPTO = Me.TxtConcepto.Text
                .CON_CARGO_A = Me.txtConCargoA.Text
                .PREDIO = Me.txtPredio.Text
                .CONFIRMO = Me.txtConfirmo.Text
                .FECHA_ENTREGA = Me.dtpFechaEntrega.Value

                If Empresa_Sistema.CONTROL_COSTOS_COMPRAS = True Then
                    Dim CostoTotal As Double = 0, z As Integer
                    For z = 1 To Me.Grid.Rows - 1
                        CostoTotal = CostoTotal + (valorNumerico(Me.Grid.Cell(z, Me.igyCantidad).Text) * valorNumerico(Me.Grid.Cell(z, Me.igyCosto).Text))
                    Next
                    .COSTO = CostoTotal
                End If

                .CODIGO_MONEDA = IIf(Me.cboMoneda.Text = "USD", "2", "1").ToString '1=MXN,2=USD
                .SUBTOTAL_USD = valorNumerico(Me.TxtSubTotal_USD.Text)
                .IEPS_TOTAL_DESGLOSADO_USD = valorNumerico(Me.txtIEPS_USD.Text)
                .IMPUESTO_USD = valorNumerico(Me.txtIVA_USD.Text)
                .TOTAL_DOLARES = valorNumerico(Me.txtTotal_USD.Text)
                .RETENCION_IVA_USD = valorNumerico(Me.txtRetencionIVA_USD.Text)
                .RETENCION_ISR_USD = valorNumerico(Me.txtRetencionISR_USD.Text)
                .ES_INVENTARIABLE = Me.chkEsInventariable.Checked
                .FOLIO_REQUISICION = Me.TxtRequisicion.Text
                .NOMBRE_TRANSPORTE = Me.TxtNombreTransporte.Text

                If CInt(Me.CboTipoEnvio.SelectedValue) > 0 Then
                    .CODIGO_TIPO_ENVIO = CInt(Me.CboTipoEnvio.SelectedValue)
                End If

                If Me.Estado = enumEstados.NUEVO Then
                    If .GrabarOrdenCompraGlobal("INSERTAR") = False Then
                        MsgBox("Error al tratar de insertar el movimiento de compras.", MsgBoxStyle.Exclamation, sProcedure)
                        Return False
                    End If
                    Me.txtFolioCompra.Text = .FOLIO_COMPRA
                Else 'Se esta consultando por tanto ya existe.
                    If .GrabarOrdenCompraGlobal("ACTUALIZAR") = False Then
                        MsgBox("Error al tratar de actualizar el movimiento de compras.", MsgBoxStyle.Exclamation, sProcedure)
                        Return False
                    End If
                End If

                'se graba el detalle
                For i = 1 To Me.Grid.Rows - 1
                    If txtLEN(Me.Grid.Cell(i, Me.igyCodigo).Text) = True Then
                        .NuevoRenglon()

                        .oComprasDetalle.FOLIO_COMPRA = .FOLIO_COMPRA.ToString
                        .oComprasDetalle.CODIGO_ARTICULO = Me.Grid.Cell(i, Me.igyCodigo).Text.ToUpper
                        .oComprasDetalle.DESCRIPCION = Me.Grid.Cell(i, Me.igyDescripcion).Text.ToUpper
                        .oComprasDetalle.CANTIDAD = valorNumerico(Me.Grid.Cell(i, Me.igyCantidad).Text)
                        .oComprasDetalle.PRECIO = valorNumerico(Me.Grid.Cell(i, Me.igyPrecio).Text)
                        .oComprasDetalle.UNIDAD_VENTA = Me.Grid.Cell(i, Me.igyUnidad).Text.ToUpper
                        .oComprasDetalle.IMPUESTO_PORCENTAJE = valorNumerico(Me.Grid.Cell(i, Me.igyImpuestoPorcentaje).Text)
                        .oComprasDetalle.IMPUESTO_IMPORTE = Val(Me.Grid.Cell(i, Me.igyImpuestoImporte).Text)
                        .oComprasDetalle.IMPORTE = Val(Me.Grid.Cell(i, Me.igyImporte).Text)
                        .oComprasDetalle.IEPS_PORCENTAJE = valorNumerico(Me.Grid.Cell(i, Me.igyIEPS_PORCENTAJE).Text)
                        .oComprasDetalle.IEPS_UNITARIO = valorNumerico(Me.Grid.Cell(i, Me.igyIEPS_UNITARIO).Text)
                        .oComprasDetalle.IEPS_IMPORTE = valorNumerico(Me.Grid.Cell(i, Me.igyIEPS_IMPORTE).Text)
                        .oComprasDetalle.BASE_IEPS = valorNumerico(Me.Grid.Cell(i, Me.igyBASE_IEPS).Text)
                        .oComprasDetalle.BASE_IVA = valorNumerico(Me.Grid.Cell(i, Me.igyBASE_IVA).Text)
                        .oComprasDetalle.ES_REQUISICION = CInt(valorNumerico(Me.Grid.Cell(i, Me.igyEsRequisicion).Text))
                        'Ya no se grabara el id de requisicion
                        '.oComprasDetalle.ID_REQUISICION_DETALLE = CInt(valorNumerico(Me.Grid.Cell(i, Me.igyIDRequisicionDetalle).Text))

                        If Empresa_Sistema.CONTROL_COSTOS_COMPRAS = True Then
                            .oComprasDetalle.COSTO = valorNumerico(Me.Grid.Cell(i, Me.igyCosto).Text)
                        Else
                            .oComprasDetalle.COSTO = 0
                        End If

                        If Me.cboMoneda.Text = "USD" Then
                            .oComprasDetalle.PRECIO_USD = valorNumericoD(Me.Grid.Cell(i, Me.igyPRECIO_USD).Text)
                            .oComprasDetalle.IMPUESTO_IMPORTE_USD = valorNumericoD(Me.Grid.Cell(i, Me.igyIMPUESTO_IMPORTE_USD).Text)
                            .oComprasDetalle.IMPORTE_USD = valorNumericoD(Me.Grid.Cell(i, Me.igyIMPORTE_USD).Text)
                            .oComprasDetalle.IEPS_UNITARIO_USD = valorNumericoD(Me.Grid.Cell(i, Me.igyIEPS_UNITARIO_USD).Text)
                            .oComprasDetalle.IEPS_IMPORTE_USD = valorNumericoD(Me.Grid.Cell(i, Me.igyIEPS_IMPORTE_USD).Text)
                            .oComprasDetalle.BASE_IEPS_USD = valorNumericoD(Me.Grid.Cell(i, Me.igyBASE_IEPS_USD).Text)
                            .oComprasDetalle.BASE_IVA_USD = valorNumericoD(Me.Grid.Cell(i, Me.igyBASE_IVA_USD).Text)
                        Else 'Por seguridad mejor no se toma del grid(que deberia ser 0, pero si se quedara inicializado), (en el gestiona moneda se borran cuando cambian a mxn)
                            .oComprasDetalle.PRECIO_USD = 0
                            .oComprasDetalle.IMPUESTO_IMPORTE_USD = 0
                            .oComprasDetalle.IMPORTE_USD = 0
                            .oComprasDetalle.IEPS_UNITARIO_USD = 0
                            .oComprasDetalle.IEPS_IMPORTE_USD = 0
                            .oComprasDetalle.BASE_IEPS_USD = 0
                            .oComprasDetalle.BASE_IVA_USD = 0
                        End If

                        If .oComprasDetalle.GrabaRenglonOrdenCompra() = False Then
                            MsgBox("Error al tratar de grabar el detalle.", MsgBoxStyle.Exclamation, sProcedure)
                            Return False
                        End If
                    End If
                Next

                bResultado = True
                Me.txtFolioCompra.Text = .FOLIO_COMPRA.ToString
                MsgBox("Documento grabado satisfactoriamente.", MsgBoxStyle.Information, sProcedure)

            End With
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    Private Function Aplicar() As Boolean
        Const sProcedure As String = "Aplicar"
        Dim bResultado As Boolean = False
        Dim i As Integer, sListaIDsDetalle As String = "", sListaSeries As String = ""

        If MsgBox("Deseas aplicar la " & Me.CboDocumento.Text & " con el folio : " & Me.txtFolioCompra.Text & " ?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, sProcedure) = MsgBoxResult.No Then
            Return False
        End If

        If Usuario.ValidaPermisoUsuarioDocumentoConAfectacionInventarios(Me.CboDocumento.SelectedValue.ToString, Me.CboAlmacen.SelectedValue.ToString) = False Then
            MsgBox("El usuario " & Usuario.Nombre_Usuario & " no tiene permiso para realizar el movimiento.", MsgBoxStyle.Exclamation, sProcedure)
            Return False
        End If

        If Me.ValidarCompra() = False Then
            Return False
        End If

        Try
            Me.Totales()

            Dim oAlmacen As New Class_CatAlmacenes(Me.CboAlmacen.SelectedValue.ToString)

            With Me.oCompras
                .FOLIO_COMPRA = Me.txtFolioCompra.Text
                .CODIGO_DOCUMENTO = Me.CboDocumento.SelectedValue.ToString
                .CODIGO_ALMACEN = Me.CboAlmacen.SelectedValue.ToString
                .CODIGO_PLAZA = Plaza.CODIGO_PLAZA
                .FECHA = Me.DtpFecha.Value
                .FECHA_FACTURA_PROVEEDOR = Me.DtpFechaFacturaProveedor.Value
                .FOLIO_OC = Me.txtFolioOC.Text
                .FOLIO_PROVEEDOR = Me.txtFolioProveedor.Text
                .CODIGO_PROVEEDOR = Me.txtProveedor.Text
                .PLAZO = CInt(Me.txtPlazo.Text)
                .FECHA_VENCIMIENTO = Me.dtpFechaVencimiento.Value
                .SUBTOTAL = valorNumerico(Me.TxtSubTotal.Text)
                .IMPUESTO = valorNumerico(Me.txtIVA.Text)
                .TOTAL = valorNumerico(Me.txtTotal.Text)
                .RETENCION_IVA = valorNumerico(Me.txtRetencionIVA.Text)
                .IMPUESTO_PORCENTAJE = dPorcentajeIVAGlobal
                .TIPO_DE_CAMBIO = CDbl(IIf(Me.cboMoneda.SelectedIndex = 1, valorNumerico(Me.txtTipoCambio.Text), 0))
                .ENTREGAR_A = Me.txtEntregarA.Text
                .SOLICITO = Me.txtSolicito.Text
                .CONCEPTO = Me.TxtConcepto.Text
                .CON_CARGO_A = Me.txtConCargoA.Text
                .PREDIO = Me.txtPredio.Text
                .CONFIRMO = Me.txtConfirmo.Text

                If Empresa_Sistema.CONTROL_COSTOS_COMPRAS = True Then
                    Dim CostoTotal As Double = 0, z As Integer

                    For z = 1 To Me.Grid.Rows - 1
                        CostoTotal = CostoTotal + (valorNumerico(Me.Grid.Cell(z, Me.igyCantidad).Text) * valorNumerico(Me.Grid.Cell(z, Me.igyCosto).Text))
                    Next

                    .COSTO = CostoTotal
                End If

                .FECHA_ENTREGA = Me.dtpFechaEntrega.Value
                .CODIGO_MONEDA = IIf(Me.cboMoneda.Text = "USD", "2", "1").ToString '1=MXN,2=USD
                .SUBTOTAL_USD = valorNumerico(Me.TxtSubTotal_USD.Text)
                .IEPS_TOTAL_DESGLOSADO_USD = valorNumerico(Me.txtIEPS_USD.Text)
                .IMPUESTO_USD = valorNumerico(Me.txtIVA_USD.Text)
                .TOTAL_DOLARES = valorNumerico(Me.txtTotal_USD.Text)
                .RETENCION_IVA_USD = valorNumerico(Me.txtRetencionIVA_USD.Text)
                .RETENCION_ISR_USD = valorNumerico(Me.txtRetencionISR_USD.Text)
                .ES_INVENTARIABLE = Me.chkEsInventariable.Checked
                .ES_FISCAL = oAlmacen.ES_FISCAL

                If .GrabaCompraGlobal() = False Then
                    MsgBox("Error al tratar de grabar el global de la compra, abortará el proceso.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If
                Me.txtFolioCompra.Text = .FOLIO_COMPRA

                'se graba el detalle
                For i = 1 To Me.Grid.Rows - 1
                    If txtLEN(Me.Grid.Cell(i, Me.igyCodigo).Text) = False Then
                        Continue For
                    End If

                    .NuevoRenglon()

                    .oComprasDetalle.FOLIO_COMPRA = .FOLIO_COMPRA.ToString
                    .oComprasDetalle.CODIGO_ARTICULO = Me.Grid.Cell(i, Me.igyCodigo).Text.ToUpper
                    .oComprasDetalle.CANTIDAD = valorNumerico(Me.Grid.Cell(i, Me.igyCantidad).Text)
                    .oComprasDetalle.PRECIO = valorNumerico(Me.Grid.Cell(i, Me.igyPrecio).Text)
                    .oComprasDetalle.UNIDAD_VENTA = Me.Grid.Cell(i, Me.igyUnidad).Text.ToUpper
                    .oComprasDetalle.IMPUESTO_PORCENTAJE = valorNumerico(Me.Grid.Cell(i, Me.igyImpuestoPorcentaje).Text)
                    .oComprasDetalle.IMPUESTO_IMPORTE = valorNumerico(Me.Grid.Cell(i, Me.igyImpuestoImporte).Text)
                    .oComprasDetalle.IMPORTE = valorNumerico(Me.Grid.Cell(i, Me.igyImporte).Text)
                    .oComprasDetalle.ID_ORIGEN = CInt(Me.Grid.Cell(i, Me.igyIdArticulo).Text)
                    .oComprasDetalle.CUENTA_CONTABLE = Me.Grid.Cell(i, Me.igyCuentaContable).Text
                    .oComprasDetalle.ID_ADICIONAL = CInt(valorNumerico(Me.Grid.Cell(i, Me.iGyIDAdicional).Text))

                    If Me.dtSeries.Rows.Count > 0 Then
                        For Each dRow In Me.dtSeries.Select("POSICION='" & i.ToString & "'")
                            sListaSeries = sListaSeries & dRow("POSICION").ToString & "," & dRow("CODIGO_ARTICULO").ToString & "," & dRow("NUMERO_SERIE").ToString & "|"
                        Next
                        If txtLEN(sListaSeries) = True Then
                            sListaSeries = sListaSeries.Substring(0, sListaSeries.Length - 1) 'Para quitarle el último pipe que sale sobrando.
                        End If
                    End If

                    .oComprasDetalle.LISTA_SERIES = sListaSeries

                    .oComprasDetalle.IEPS_PORCENTAJE = valorNumerico(Me.Grid.Cell(i, Me.igyIEPS_PORCENTAJE).Text)
                    .oComprasDetalle.IEPS_UNITARIO = valorNumerico(Me.Grid.Cell(i, Me.igyIEPS_UNITARIO).Text)
                    .oComprasDetalle.IEPS_IMPORTE = valorNumerico(Me.Grid.Cell(i, Me.igyIEPS_IMPORTE).Text)
                    .oComprasDetalle.BASE_IEPS = valorNumerico(Me.Grid.Cell(i, Me.igyBASE_IEPS).Text)
                    .oComprasDetalle.BASE_IVA = valorNumerico(Me.Grid.Cell(i, Me.igyBASE_IVA).Text)
                    .oComprasDetalle.COSTO = valorNumerico(Me.Grid.Cell(i, Me.igyCosto).Text)
                    .oComprasDetalle.MARGEN_UTILIDAD = valorNumericoD(Me.Grid.Cell(i, Me.igyMargenUtilidad).Text)
                    .oComprasDetalle.COSTO_MERCADO = valorNumericoD(Me.Grid.Cell(i, Me.igyCostoMercado).Text)
                    .oComprasDetalle.PRECIO_VENTA = valorNumericoD(Me.Grid.Cell(i, Me.igyPrecioVenta).Text)

                    If Me.cboMoneda.Text = "USD" Then
                        .oComprasDetalle.PRECIO_USD = valorNumericoD(Me.Grid.Cell(i, Me.igyPRECIO_USD).Text)
                        .oComprasDetalle.IMPUESTO_IMPORTE_USD = valorNumericoD(Me.Grid.Cell(i, Me.igyIMPUESTO_IMPORTE_USD).Text)
                        .oComprasDetalle.IMPORTE_USD = valorNumericoD(Me.Grid.Cell(i, Me.igyIMPORTE_USD).Text)
                        .oComprasDetalle.IEPS_UNITARIO_USD = valorNumericoD(Me.Grid.Cell(i, Me.igyIEPS_UNITARIO_USD).Text)
                        .oComprasDetalle.IEPS_IMPORTE_USD = valorNumericoD(Me.Grid.Cell(i, Me.igyIEPS_IMPORTE_USD).Text)
                        .oComprasDetalle.BASE_IEPS_USD = valorNumericoD(Me.Grid.Cell(i, Me.igyBASE_IEPS_USD).Text)
                        .oComprasDetalle.BASE_IVA_USD = valorNumericoD(Me.Grid.Cell(i, Me.igyBASE_IVA_USD).Text)
                    Else 'Por seguridad mejor no se toma del grid(que deberia ser 0, pero si se quedara inicializado), (en el gestiona moneda se borran cuando cambian a mxn)
                        .oComprasDetalle.PRECIO_USD = 0
                        .oComprasDetalle.IMPUESTO_IMPORTE_USD = 0
                        .oComprasDetalle.IMPORTE_USD = 0
                        .oComprasDetalle.IEPS_UNITARIO_USD = 0
                        .oComprasDetalle.IEPS_IMPORTE_USD = 0
                        .oComprasDetalle.BASE_IEPS_USD = 0
                        .oComprasDetalle.BASE_IVA_USD = 0
                    End If

                    .oComprasDetalle.ID_INVENTARIO_MOVIMIENTOS_DETALLE_ENTRADA = CInt(0 & valorNumerico(Me.Grid.Cell(i, Me.igyID_INVENTARIO_MOVIMIENTOS_DETALLE_ENTRADA).Text))

                    If .oComprasDetalle.GrabaRenglonCompra() = False Then
                        MsgBox("Error al tratar de grabar el detalle.", MsgBoxStyle.Exclamation, sProcedure)
                        Return False
                        'Else
                        '    ya no se ocuparia esto, porque las series ya estan especificadas en el mismo renglon
                        '    sListaIDsDetalle = sListaIDsDetalle & i.ToString & "," & .oComprasDetalle.ID_COMPRA_DETALLE.ToString & "|"
                    End If

                    sListaSeries = ""
                Next

                'For i = 1 To Me.GridSeries.Rows - 1
                '    If txtLEN(Me.GridSeries.Cell(i, Me.igySerieCodigo).Text) = True Then
                '        sListaSeries = sListaSeries & Me.GridSeries.Cell(i, Me.igySeriePosicion).Text & "," & Me.GridSeries.Cell(i, Me.igySerieCodigo).Text & "," & Me.GridSeries.Cell(i, Me.igySerieNumeroSerie).Text & "|"
                '    End If
                'Next

                'If txtLEN(sListaSeries) = True Then
                '    sListaSeries = sListaSeries.Substring(0, sListaSeries.Length - 1) 'Para quitarle el último pipe que sale sobrando.
                'End If
                'If txtLEN(sListaIDsDetalle) = True Then
                '    sListaIDsDetalle = sListaIDsDetalle.Substring(0, sListaIDsDetalle.Length - 1) 'Para quitarle el último pipe que sale sobrando.
                'End If

                'If Me.oCompras.AfectaInventarioCompra(sListaIDsDetalle, sListaSeries) = False Then
                '    MsgBox("Error al tratar de afectar el inventario.", MsgBoxStyle.Exclamation, Me.Text)
                '    RETURN FALSE
                'End If

                If Me.chkEsInventariable.Checked = True Then
                    'Nota, Ya no se afecta inventarios de ninguna forma al aplicar(porque ahora se hacen entradas en inventario), pero si a los disponibles cuando no es inventariable.
                    'If Me.oCompras.AfectaInventarioCompra() = False Then
                    '    MsgBox("Error al tratar de afectar el inventario.", MsgBoxStyle.Exclamation, sProcedure)
                    '    Return False
                    'End If
                    For i = 1 To Me.GridEntradas.Rows - 1
                        If txtLEN(Me.GridEntradas.Cell(i, Me.igyGridEFolioEntrada).Text) = True Then
                            .GrabaRelacionEntradaInventario(Me.GridEntradas.Cell(i, Me.igyGridEFolioEntrada).Text)
                        End If
                    Next
                Else 'Es de servicios(las oc's se convierten en co's y si se lleva el control de los disponibles del modo anterior)
                    If Me.oCompras.AfectaCantidadesDisponiblesOrdenCompra(False) = False Then
                        MsgBox("Error al tratar de afectar las cantidades disponibles de la orden de compra.", MsgBoxStyle.Exclamation, sProcedure)
                        Return False
                    End If
                End If

                Dim sListaCuentas As String = ""

                If oAlmacen.ES_FISCAL = True Then
                    If IsNothing(Me.oFormaDetalleCuentas) = False Then 'Si no esta vacia(osea que si existe)
                        Me.oFormaDetalleCuentas.FolioMovimientoInventario = Me.txtFolioCompra.Text 'Hasta aqui la forma auxiliar no tenia el folio
                        sListaCuentas = Me.oFormaDetalleCuentas.ObtieneListaDetalleCuentas()
                    End If

                    If txtLEN(sListaCuentas) = True Then
                        .oComprasDetalle.GrabaDetalleCentroCostos(sListaCuentas, Me.CboDocumento.SelectedValue.ToString, Me.DtpFecha.Value)
                    End If

                    If Me.oCompras.AfectaContabilidadCompra = False Then
                        MsgBox("Error al tratar de afectar contabilidad.", MsgBoxStyle.Exclamation, sProcedure)
                        Return False
                    End If
                End If

                bResultado = True

                MsgBox("Movimiento de compras aplicado satisfactoriamente.", MsgBoxStyle.Information, sProcedure)

            End With

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    Private Function ActualizaFolioProveedor() As Boolean
        Try
            If Usuario.ValidaPermisoUsuarioDocumentoConAfectacionInventarios(Me.CboDocumento.SelectedValue.ToString, Me.CboAlmacen.SelectedValue.ToString) = False Then
                MsgBox("El usuario " & Usuario.Nombre_Usuario & " no tiene permiso para realizar el movimiento.", MsgBoxStyle.Information, Me.Text)
                Exit Function
            End If

            Dim sFolioProv As String
            sFolioProv = InputBox("Proporcione el nuevo folio de la factura del proveedor", "Folio de proveedor")
            If String.IsNullOrEmpty(sFolioProv) Then
                Exit Function
            Else
                Me.oCompras.FOLIO_PROVEEDOR = sFolioProv
                Me.oCompras.ActualizaFolioProveedor()
            End If
            Return True
        Catch ex As Exception
            HandleError(Me.Name, "AcualizaFolioProveedor", ex)
        End Try
    End Function

    Private Function Consultar(Optional ByVal bEsReferencia As Boolean = False, Optional ByVal bPasandoOCaCO As Boolean = False) As Boolean
        Const sProcedure As String = ""
        Dim bResultado As Boolean = False
        Dim sCompra As String = Me.txtFolioCompra.Text
        Dim sOrdenCompra As String = Me.txtFolioOC.Text

        Try
            If _ConsultaExterior = True Then
                Me.InicializaExterno()
            Else
                Me.Inicializa()
            End If

            Me.bEsReferencia = bEsReferencia

            If Me.bEsReferencia = False Then
                Me.oCompras = New Class_Compras_Global(sCompra, Me.CboDocumento.SelectedValue.ToString)
            Else
                Me.oCompras = New Class_Compras_Global(sOrdenCompra, Me.oCompras.ObtieneCodigoDocumentoOrdenCompra(sOrdenCompra))
            End If

            If Me.oCompras.Existe = False Then
                Me.Cambia_Estado(enumEstados.NUEVO)
                Me.txtFolioCompra.Enabled = False
                Me.CboDocumento.Enabled = False
                Return False
            End If

            Me.cboMoneda.SelectedValue = Me.oCompras.CODIGO_MONEDA
            Me.txtTipoCambio.Text = Format(Me.oCompras.TIPO_DE_CAMBIO, "##0.0000")
            Me.DtpFecha.Value = CDate(Me.oCompras.FECHA) 'Va aqui porque puede ejecutar el cambio de tpca y nos totalizaria

            If bEsReferencia = False Then
                Me.txtFolioCompra.Text = Me.oCompras.FOLIO_COMPRA.ToString.ToUpper
                Me.txtFolioOC.Text = Me.oCompras.FOLIO_OC.ToString.ToUpper

                Select Case Me.oCompras.ESTATUS.ToString.ToUpper
                    Case "N"
                        Me.LblEstatus.Text = "NUEVO"
                    Case "G"
                        Me.LblEstatus.Text = "GRABADO"
                    Case "R"
                        Me.LblEstatus.Text = "PARCIALMENTE RECEPCIONADO"
                    Case "P"
                        Me.LblEstatus.Text = "PEDIDO"
                    Case "A"
                        Me.LblEstatus.Text = "APLICADO"
                    Case "C"
                        Me.LblEstatus.Text = "CANCELADO"
                End Select

                Me.txtFolioProveedor.Text = Me.oCompras.FOLIO_PROVEEDOR.ToString.ToUpper

                Me.TxtRequisicion.Text = Me.oCompras.FOLIO_REQUISICION

                Me.tsbEditarOC.Visible = False
                If Me.oDocumento.AFECTA_CXP = False And txtLEN(Me.TxtRequisicion.Text) = True And Me.LblEstatus.Text = "PEDIDO" Then
                    Me.tsbEditarOC.Visible = True
                End If

                If Me.oCompras.CODIGO_TIPO_ENVIO > 0 Then
                    Me.CboTipoEnvio.SelectedValue = Me.oCompras.CODIGO_TIPO_ENVIO
                End If

                Me.TxtNombreTransporte.Text = Me.oCompras.NOMBRE_TRANSPORTE

                Me.Grid.DataSource = Me.oCompras.ObtenerDetalle

                For i = 1 To Me.Grid.Rows - 1
                    If Me.Grid.Cell(i, Me.igyCodigo).Text = "-" Then 'Si es comentario
                        For j = Me.igyDescripcion + 1 To Me.Grid.Cols - 1
                            Me.Grid.Cell(i, j).Locked = True 'Bloqueamos el resto de las columnas

                            If j <> iGyIDAdicional Then
                                Me.Grid.Cell(i, j).Text = "" 'Eliminamos los datos del resto de las columnas excepto el IDAdicional
                            End If
                        Next
                    End If
                Next

                'If Me.oDocumento.AFECTA_CXP = True Then
                '    Me.Grid.DataSource = Me.oCompras.ObtenerDetalle
                'Else
                '    Me.Grid.DataSource = Me.oCompras.ObtenerDetalleOrdenCompra
                'End If

                Me.GridSeries.DataSource = Me.oCompras.ObtenerDetalleSeries
                Me.FormateaGridSeries()
            Else
                Me.txtFolioOC.Text = Me.oCompras.FOLIO_COMPRA.ToString.ToUpper
                Me.txtFolioCompra.Enabled = False
                Me.Grid.DataSource = Me.oCompras.ObtenerDetalleOrdenCompra
            End If

            Me.CboAlmacen.SelectedValue = Me.oCompras.CODIGO_ALMACEN
            Me.txtProveedor.Text = Me.oCompras.CODIGO_PROVEEDOR
            Me.oProveedores = New Class_CatProveedores(Me.oCompras.CODIGO_PROVEEDOR)
            Me.lblProveedor.Text = oProveedores.Nombre_Proveedor.ToUpper

            Me.txtPlazo.Text = Me.oCompras.PLAZO.ToString
            Me.dtpFechaVencimiento.Value = CDate(Me.oCompras.FECHA_VENCIMIENTO)
            Me.chkEsInventariable.Checked = Me.oCompras.ES_INVENTARIABLE
            Me.chkEsFiscal.Checked = Me.oCompras.ES_FISCAL

            'Esto va antes de los totales, porque se va ejecutar el checked de los dolares
            'Me.cboMoneda.SelectedValue = Me.oCompras.CODIGO_MONEDA
            'Me.txtTipoCambio.Text = Format(Me.oCompras.TIPO_DE_CAMBIO, "##0.0000")
            'If Me.oCompras.TIPO_DE_CAMBIO > 0 Then
            '    Me.txtTipoCambio.Text = Me.oCompras.TIPO_DE_CAMBIO.ToString
            '    Me.cboMoneda.SelectedIndex = 1
            'Else
            '    Me.txtTipoCambio.Text = "0"
            '    Me.cboMoneda.SelectedIndex = 0
            'End If

            If bEsReferencia = False Then 'Estos datos no tienen que llenarse si se esta aplicando una oc(jalando a una co)
                Me.TxtSubTotal.Text = FormatImporteContable(Me.oCompras.SUBTOTAL)
                Me.txtIEPS.Text = FormatImporteContable(Me.oCompras.IEPS_TOTAL_DESGLOSADO)
                Me.txtIVA.Text = FormatImporteContable(Me.oCompras.IMPUESTO)
                Me.txtRetencionIVA.Text = FormatImporteContable(Me.oCompras.RETENCION_IVA)
                Me.txtRetencionISR.Text = FormatImporteContable(Me.oCompras.RETENCION_ISR)
                Me.txtTotal.Text = FormatImporteContable(Me.oCompras.TOTAL)

                Me.TxtSubTotal_USD.Text = FormatImporteContable(Me.oCompras.SUBTOTAL_USD)
                Me.txtIEPS_USD.Text = FormatImporteContable(Me.oCompras.IEPS_TOTAL_DESGLOSADO_USD)
                Me.txtIVA_USD.Text = FormatImporteContable(Me.oCompras.IMPUESTO_USD)
                Me.txtRetencionIVA_USD.Text = FormatImporteContable(Me.oCompras.RETENCION_IVA_USD)
                Me.txtRetencionISR_USD.Text = FormatImporteContable(Me.oCompras.RETENCION_ISR_USD)
                Me.txtTotal_USD.Text = FormatImporteContable(Me.oCompras.TOTAL_DOLARES)

                Me.txtSaldo_MXP.Text = FormatImporteContable(Me.oCompras.SALDO)
                Me.txtSaldo_USD.Text = FormatImporteContable(Me.oCompras.SALDO_DOLARES)

            Else 'Se jaló una referencia y se debe recalcular los totales.
                Me.Totales()
            End If

            If Me.oCompras.CODIGO_TIPO_GASTO = "3" Then
                Me.LblPoliza.Text = Me.oCompras.FOLIO_EMBARQUE
            Else
                Me.LblPoliza.Text = Me.oCompras.FOLIO_POLIZA
            End If

            Me.txtEntregarA.Text = Me.oCompras.ENTREGAR_A.ToString.ToUpper
            Me.txtSolicito.Text = Me.oCompras.SOLICITO.ToString.ToUpper
            Me.TxtConcepto.Text = Me.oCompras.CONCEPTO.ToString.ToUpper
            Me.txtConCargoA.Text = Me.oCompras.CON_CARGO_A.ToString.ToUpper
            Me.txtPredio.Text = Me.oCompras.PREDIO.ToString.ToUpper
            Me.txtConfirmo.Text = Me.oCompras.CONFIRMO.ToString.ToUpper
            Me.txtConCargoA.Text = Me.oCompras.CON_CARGO_A.ToString.ToUpper
            Me.txtPredio.Text = Me.oCompras.PREDIO.ToString.ToUpper
            Me.txtConfirmo.Text = Me.oCompras.CONFIRMO.ToString.ToUpper
            Me.txtFolioProveedor.Text = Me.oCompras.FOLIO_PROVEEDOR
            Me.TxtConceptoCancelacion.Text = Me.oCompras.CONCEPTO_CANCELACION

            Me.dtpFechaVencimiento.Value = Me.DtpFecha.Value.AddDays(CDbl(Me.txtPlazo.Text))
            Me.dtpFechaEntrega.Value = CDate(Me.oCompras.FECHA_ENTREGA)

            If Me.oCompras.FECHA_FACTURA_PROVEEDOR = Nothing Then
                Me.DtpFechaFacturaProveedor.Value = Now
            Else
                Me.DtpFechaFacturaProveedor.Value = CDate(Me.oCompras.FECHA_FACTURA_PROVEEDOR)
            End If

            Me.FormateaGrid()

            If Me.ValidaEsRequisicion() = False Then
                Me.TxtRequisicion.Visible = False : Me.LblRequisicion.Visible = False : Me.btnTraerDetalleRequisicion.Visible = False : Me.btnMultiplesRequisiciones.Visible = False
                Me.tsbPedir.Visible = False
            Else
                Me.TxtRequisicion.Visible = True : Me.LblRequisicion.Visible = True : Me.btnTraerDetalleRequisicion.Visible = True : Me.btnMultiplesRequisiciones.Visible = True
                Me.tsbPedir.Visible = True
            End If

            If Me.oDocumento.AFECTA_CXP = True Then
                Me.Grid.Row(Me.Grid.Rows - 1).Locked = True
                If Me.LblEstatus.Text = "NUEVO" Then
                    If Me.EstableceCuentaContableAlmacen() = False Then
                        MsgBox("No se pudieron establecer las cuentas contables de los artículos inventariables.", MsgBoxStyle.Information, sProcedure)
                    End If
                End If

                Dim sUUID As String = Me.oCompras.UUID
                If txtLEN(sUUID) = True Then
                    Me.tsbAgregarXML.Text = "Ver XML"

                    Dim oPoliza As New Class_Contabilidad_Poliza_Global(Me.txtFolioCompra.Text)
                    If oPoliza.Existe = False Then
                        Return False
                    End If

                    If oPoliza.TienePDF(sUUID) = True Then
                        Me.tsbAgregarPDF.Text = "Ver PDF"
                    Else
                        Me.tsbAgregarPDF.Text = "Agregar PDF"
                    End If

                    oPoliza = Nothing
                Else
                    Me.tsbAgregarXML.Text = "Agregar XML"
                    Me.tsbAgregarPDF.Text = "Agregar PDF"
                End If
            End If

            bResultado = True

            If bEsReferencia = True Then
                If Me.oCompras.ESTATUS = "A" Then
                    MsgBox("La oc especificada ya esta aplicada en la compra(s) " & Me.oCompras.ListaComprasAplicaronOc(Me.txtFolioOC.Text), MsgBoxStyle.Exclamation, sProcedure)
                End If
            End If

            If Me.oDocumento.AFECTA_CXP = True Then
                Me.GridEntradas.DataSource = Me.oCompras.ObtieneListadoEntradas
            Else
                Me.GridEntradas.DataSource = Me.oCompras.ObtieneListadoEntradasOrdenCompra
            End If

            Me.FormateaGridEntradas()

            Me.GestionaCambioEstado()
            Me.GestionaMoneda()
            Me.OcultarControles()

            Me.txtFolioCompra.Enabled = False

            If bPasandoOCaCO = True Then 'Si estan convieriendo una oc de no inv a compra, de inmediato quitamos check y bloqueamos.
                Me.chkEsInventariable.Checked = False
                Me.chkEsInventariable.Enabled = False
            End If

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        Finally
            Application.DoEvents()
        End Try

        Return bResultado
    End Function

    Private Function CancelarCompra() As Boolean
        Const sProcedure As String = "CancelarCompra"
        Dim bResultado As Boolean = False

        Dim oFirmaElectronica = New UtileriasFirmaElectronicaCancelacionMovimientosFueraPeriodo
        Dim oUtileriasCancela As New Class_UtileriasFirmaElectronicaCancelacion
        Dim oPoliza As New Class_Contabilidad_Poliza_Global
        Dim sConceptoCancelacion As String = ""
        Dim bCancelarEntradas As Boolean = False

        If MsgBox("Deseas cancelar el movimiento de " & Me.CboDocumento.Text & " ?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, sProcedure) = MsgBoxResult.No Then
            Return False
        End If

        If _ConsultaExterior = True Then
            If Usuario.ValidaPermisoUsuarioDocumentoConAfectacionInventarios("CO" & Plaza.CODIGO_PLAZA.ToString, Me.CboAlmacen.SelectedValue.ToString) = False Then
                MsgBox("El usuario " & Usuario.Nombre_Usuario & " no tiene permiso para realizar el movimiento de inventarios.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If
        Else
            If Usuario.ValidaPermisoUsuarioDocumentoConAfectacionInventarios(Me.CboDocumento.SelectedValue.ToString, Me.CboAlmacen.SelectedValue.ToString) = False Then
                MsgBox("El usuario " & Usuario.Nombre_Usuario & " no tiene permiso para realizar el movimiento de inventarios.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If
        End If

        If Me.oCompras.ES_INVENTARIABLE = True Then
            If Me.oCompras.ObtieneListadoEntradas.Rows.Count = 0 Then 'Si no tienen entradas esta compra es del modo anterior(donde una oc se convertia en oc, y la misma co era la entrada) y si afectarán existencias.
                If Me.oCompras.ValidaExistencias() = False Then
                    Return False
                End If
            Else
                'Continua, no hay validación de existencias, porque el cancelar una compra del nuevo modo(con entradas de inventarios) no afecta existencias(pero si disponibles si es del modo anterior por eso continua y dentro
                'del stored de cancelación la distingue para no afectar existencias sino solamente disponibles).
                If MsgBox("La compra tiene ENTRADAS DE INVENTARIO POR RECEPCION, Desea cancelarlas ?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, sProcedure) = MsgBoxResult.Yes Then
                    bCancelarEntradas = True
                End If
            End If
        End If

        'no se ocupa por que para eso esta la interfaz
        'If PLAZA.ValidarPeriodoTrabajo(Me.oCompras.FECHA) = False Then 'Para cancelar se valida con la fecha de la maquina
        '    return false
        'End If

        Try
            oUtileriasCancela.FOLIO_DOCUMENTO = Me.txtFolioCompra.Text.ToUpper
            oUtileriasCancela.MODULO = Me.oCompras.CODIGO_MODULO
            oUtileriasCancela.CODIGO_PLAZA = Usuario.Codigo_Plaza

            If oUtileriasCancela.GestionaCancelacion() = False Then
                Return False
            End If

            If oUtileriasCancela.CANCELA_DIRECTO = True Then
                Me.oCompras.FECHA_CANCELACION = Date.Now

                sConceptoCancelacion = InputBox("Ingrese un concepto de cancelación :", "Concepto de cancelación")
                Me.oCompras.CONCEPTO_CANCELACION = sConceptoCancelacion

                If Me.oCompras.CancelaCompra() = False Then
                    MsgBox("Error al intentar cancelar el compra.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If
            Else
                oUtileriasCancela = New Class_UtileriasFirmaElectronicaCancelacion
                oUtileriasCancela.FOLIO_DOCUMENTO = Me.txtFolioCompra.Text
                oUtileriasCancela.FOLIO_POLIZA = Me.oCompras.FOLIO_POLIZA
                oUtileriasCancela.CODIGO_DOCUMENTO = Me.CboDocumento.SelectedValue.ToString
                oUtileriasCancela.CODIGO_PLAZA = Usuario.Codigo_Plaza
                oUtileriasCancela.MODULO = Me.oCompras.CODIGO_MODULO

                If oUtileriasCancela.AutorizaCancelacionMovimientosFueraPeriodo() = False Then
                    'MsgBox("Error al tratar de autorizar la cancelación fuera del periodo.", MsgBoxStyle.Exclamation, Me.Text)
                    Return False
                End If

                sConceptoCancelacion = oUtileriasCancela.CANCELACION_CONCEPTO
                Me.oCompras.CONCEPTO_CANCELACION = sConceptoCancelacion

                'si no se autorizo
                If oUtileriasCancela.CANCELACION_AUTORIZO = False Then
                    MsgBox("No se autorizó la cancelación de movimiento.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If

                If oUtileriasCancela.GestionaCancelacionConInterfaz() = False Then
                    MsgBox("Error al gestionar la cancelacion con interfaz", MsgBoxStyle.Information, sProcedure)
                    Return False
                Else
                    If oUtileriasCancela.ES_FECHA_CANCELACION_VALIDA = "0" Then
                        MsgBox("La fecha de cancelación debe de ser mayor o igual a la fecha del documento y debe estar en el mismo ejercicio.", vbExclamation, sProcedure)
                        Return False
                    End If

                    Me.oCompras.FECHA_CANCELACION = oUtileriasCancela.FECHA_CANCELACION

                    If Me.oCompras.CancelaCompra() = False Then
                        MsgBox("Error al intentar cancelar el compra.", MsgBoxStyle.Exclamation, sProcedure)
                        Return False
                    End If
                End If
            End If

            'Cancelar entradas
            If bCancelarEntradas = True Then
                Dim oInventarios As Class_Inventarios_Global
                Dim bEntradaNoCancelada As Boolean = False
                Dim foliosNoCancelados As String = ""

                For i = 1 To Me.GridEntradas.Rows - 1
                    If txtLEN(Me.GridEntradas.Cell(i, Me.igyGridEFolioEntrada).Text) Then
                        oInventarios = New Class_Inventarios_Global(Me.GridEntradas.Cell(i, Me.igyGridEFolioEntrada).Text)

                        If oInventarios.Existe = True Then
                            If oInventarios.ValidaExistencias() = False Then
                                foliosNoCancelados = foliosNoCancelados & Me.GridEntradas.Cell(i, Me.igyGridEFolioEntrada).Text & ","
                                bEntradaNoCancelada = True
                                Continue For
                            End If

                            oInventarios.FECHA_CANCELACION = Me.oCompras.FECHA_CANCELACION
                            If oInventarios.Cancelar() = False Then
                                foliosNoCancelados = foliosNoCancelados & Me.GridEntradas.Cell(i, Me.igyGridEFolioEntrada).Text & ","
                                bEntradaNoCancelada = True
                            End If
                        End If

                    End If
                Next

                If bEntradaNoCancelada Then
                    foliosNoCancelados = foliosNoCancelados.Substring(0, foliosNoCancelados.Length - 1) 'Quita la ultima coma
                    MsgBox("Las entradas " & foliosNoCancelados & " no pudieron ser canceladas, debera hacerse manualmente.", MsgBoxStyle.Exclamation, sProcedure)
                End If

            End If

            MsgBox("Compra cancelada satisfactoriamente.", MsgBoxStyle.Information, sProcedure)
            bResultado = True

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    Private Function CancelaOrdenCompra() As Boolean
        Const sProcedure As String = "CancelaOrdenCompra"
        Dim bResultado As Boolean = False
        Dim sConceptoCancelacion As String = ""
        Dim bAfectarRequisicion As Boolean = False

        Try
            If MsgBox("Deseas Cancelar el documento " & CboDocumento.Text & "  con el Folio: " & txtFolioCompra.Text & "?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, sProcedure) = MsgBoxResult.No Then
                Return False
            End If

            If Usuario.ValidaPermisoUsuarioDocumentoSinAfectacionInventarios(Me.CboDocumento.SelectedValue.ToString) = False Then
                MsgBox("El usuario " & Usuario.Nombre_Usuario & " no tiene permiso para realizar el movimiento.", MsgBoxStyle.Information, sProcedure)
                Return False
            End If

            'No se necesita
            'If PLAZA.ValidarPeriodoTrabajo(Me.DtpFecha.Value) = False Then
            '    return false
            'End If

            Select Case Me.oCompras.ESTATUS
                Case "C"
                    MsgBox("No se puede cancelar la order de compra por que ya esta cancelada.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                Case "R"
                    MsgBox("No se puede cancelar la orden de compra si esta parcialmente recepcionada.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                Case "A"
                    MsgBox("No se puede cancelar la orden de compra si esta aplicada.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
            End Select

            If Me.oCompras.ESTATUS = "P" Then
                'Evita que se afecten requisiciones de oc grabadas pero no pedidas
                bAfectarRequisicion = True
            End If

            sConceptoCancelacion = InputBox("Ingrese un concepto de cancelación :", "Concepto de cancelación")
            Me.oCompras.CONCEPTO_CANCELACION = sConceptoCancelacion

            If Me.oCompras.CancelaOrdenCompra = False Then
                Return False
            End If

            If Empresa_Sistema.MODO_REQUISICIONES_INVENTARIO AndAlso bAfectarRequisicion Then
                'If Me.oCompras.AfectaRequisicionesOrdenCompra(True) = False Then 'Desafecta requisiciones
                If Me.oCompras.AfectaRequisicionesOrdenCompra("CANCELAR_OC") = False Then 'Desafecta requisiciones
                    MsgBox("Error al devolver el disponible a las requisiciones de inventario.", MsgBoxStyle.Exclamation, sProcedure)
                    MsgBox("Avise al departamento de sistemas.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If
            End If

            MsgBox("Orden de compra cancelada satisfactoriamente.", MsgBoxStyle.Information, sProcedure)
            bResultado = True

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    Private Function ValidarOrdenCompra() As Boolean
        Const sProcedure As String = "ValidarOrdenCompra"
        Dim bPrimerIVAEncontrado As Boolean, bHayArticulos As Boolean = False, bHayArticulosRequeridos As Boolean = False
        Dim oArticulos As Class_CatArticulos

        Try
            If Plaza.ValidarPeriodoTrabajo(Me.DtpFecha.Value) = False Then
                Return False
            End If

            If txtLEN(Me.txtFolioCompra.Text) = False Then
                MsgBox("Asigne un folio válido.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            If txtLEN(Me.txtProveedor.Text) = False Then
                MsgBox("Asigne un proveedor.", MsgBoxStyle.Exclamation, sProcedure)
                Me.txtProveedor.Focus()
                Return False
            End If

            Me.oProveedores = New Class_CatProveedores(Me.txtProveedor.Text)
            If Me.oProveedores.Existe = False Then
                MsgBox("Asigne un proveedor válido.", MsgBoxStyle.Exclamation, sProcedure)
                Me.txtProveedor.Focus()
                Return False
            End If

            Dim sql As New Class_find("Select T.REALIZA_COMPRAS_GASTOS_PAGOS FROM CAT_PROVEEDORES P INNER JOIN SIS_TIPOS_PROVEEDORES T On(P.CODIGO_TIPO_PROVEEDOR=T.CODIGO_TIPO_PROVEEDOR)" &
                                      " WHERE P.CODIGO_PROVEEDOR='" & Me.txtProveedor.Text & "'")
            If sql.Result1 = "0" Then
                MsgBox("El proveedor " & Me.txtProveedor.Text & "no puede realizar movimientos de compras.", MsgBoxStyle.Information, Me.Text)
                Me.txtProveedor.Focus()
                Return False
            End If

            If txtLEN(Me.oProveedores.CUENTA_CONTABLE) = False Then
                MsgBox("El proveedor no tiene una cuenta contable en pesos asignada.", MsgBoxStyle.Exclamation, sProcedure)
                Me.txtProveedor.Focus()
                Return False
            End If

            If Mid(Me.oProveedores.CUENTA_CONTABLE, 1, 1) <> "2" Then
                'or Me.oProveedores.NOMBRE_TIPO_PROVEEDOR
                MsgBox("La cuenta contable del proveedor debe empezar con '2'.", MsgBoxStyle.Information, Me.Text)
                Me.lblProveedor.Text = ""
                Me.txtProveedor.Focus()
                Return False
            End If

            If Me.cboMoneda.Text = "USD" Then
                If txtLEN(Me.oProveedores.CUENTA_CONTABLE_DOLARES) = False Then
                    MsgBox("El proveedor no tiene una cuenta contable en dólares asignada.", MsgBoxStyle.Exclamation, sProcedure)
                    Me.txtProveedor.Focus()
                    Return False
                End If

                If valorNumericoD(Me.txtTipoCambio.Text) <= 0 Then
                    MsgBox("Capture el tipo de cambio.", MsgBoxStyle.Exclamation, sProcedure)
                    If Me.txtTipoCambio.Enabled = True Then
                        Me.txtTipoCambio.Focus()
                    End If
                    Return False
                End If

                If Not (valorNumericoD(Me.txtTipoCambio.Text) >= 15 And valorNumericoD(Me.txtTipoCambio.Text) <= 40) Then
                    MsgBox("El tipo de cambio se sale del rango de 15 a 40.", MsgBoxStyle.Exclamation, sProcedure)
                    If Me.txtTipoCambio.Enabled = True Then
                        Me.txtTipoCambio.Focus()
                    End If
                    Return False
                End If
            End If

            'If txtLEN(Me.txtEntregarA.Text) = False Then
            '    MsgBox("Asigne el nombre de la persona a la que se le va a entregar.", MsgBoxStyle.Exclamation, sProcedure)
            '    Me.txtEntregarA.Focus()
            '    return false
            'End If

            'If txtLEN(Me.txtSolicito.Text) = False Then
            '    MsgBox("Asigne el nombre de la persona que solicitó.", MsgBoxStyle.Exclamation, sProcedure)
            '    Me.txtSolicito.Focus()
            '    return false
            'End If

            'If txtLEN(Me.txtConCargoA.Text) = False Then
            '    MsgBox("Asigne el cargo a.", MsgBoxStyle.Exclamation, sProcedure)
            '    Me.txtConCargoA.Focus()
            '    return false
            'End If

            'If txtLEN(Me.txtPredio.Text) = False Then
            '    MsgBox("Asigne un predio válido.", MsgBoxStyle.Exclamation, sProcedure)
            '    Me.txtPredio.Focus()
            '    return false
            'End If

            'If txtLEN(Me.txtConfirmo.Text) = False Then
            '    MsgBox("Asigne el nombre de la persona que confirmo los precios.", MsgBoxStyle.Exclamation, sProcedure)
            '    Me.txtConfirmo.Focus()
            '    return false
            'End If

            Me.dPorcentajeIVAGlobal = 0

            Dim i As Integer, sArticulo As String = ""
            For i = 1 To Me.Grid.Rows - 1
                sArticulo = Me.Grid.Cell(i, Me.igyCodigo).Text

                If txtLEN(sArticulo) = True And sArticulo <> "-" Then ' "-" es para comentarios
                    oArticulos = New Class_CatArticulos(sArticulo)

                    If oArticulos.Existe = False Then
                        MsgBox("El artículo no existe.", MsgBoxStyle.Exclamation, sProcedure)
                        Me.Grid.Cell(i, Me.igyCodigo).SetFocus()
                        Return False
                    End If

                    If txtLEN(Me.Grid.Cell(i, Me.igyDescripcion).Text) = False Then
                        MsgBox("El artículo no tiene descripción.", MsgBoxStyle.Exclamation, sProcedure)
                        Me.Grid.Cell(i, Me.igyDescripcion).SetFocus()
                        Return False
                    End If

                    If valorNumerico(Me.Grid.Cell(i, Me.igyCantidad).Text) <= 0 Then
                        MsgBox("La cantidad del artículo debe de ser mayor a 0.", MsgBoxStyle.Exclamation, sProcedure)
                        Me.Grid.Cell(i, Me.igyCantidad).SetFocus()
                        Return False
                    End If

                    If valorNumerico(Me.Grid.Cell(i, Me.igyPrecio).Text) <= 0 Then
                        MsgBox("El precio del artículo debe de ser mayor a 0.", MsgBoxStyle.Exclamation, sProcedure)
                        Me.Grid.Cell(i, Me.igyPrecio).SetFocus()
                        Return False
                    End If

                    If txtLEN(Me.Grid.Cell(i, Me.igyUnidad).Text) = False Then
                        MsgBox("El artículo no tiene unidad de venta.", MsgBoxStyle.Exclamation, sProcedure)
                        Me.Grid.Cell(i, Me.igyUnidad).SetFocus()
                        Return False
                    End If

                    If txtLEN(Me.Grid.Cell(i, Me.igyImpuestoPorcentaje).Text) = False Then
                        MsgBox("El artículo no tiene un porcentaje de iva.", MsgBoxStyle.Exclamation, sProcedure)
                        Me.Grid.Cell(i, Me.igyImpuestoPorcentaje).SetFocus()
                        Return False
                    End If

                    If valorNumerico(Me.Grid.Cell(i, Me.igyImpuestoPorcentaje).Text) > 0 Then
                        If bPrimerIVAEncontrado = False Then
                            Me.dPorcentajeIVAGlobal = valorNumerico(Me.Grid.Cell(i, Me.igyImpuestoPorcentaje).Text)
                            bPrimerIVAEncontrado = True
                        Else
                            If dPorcentajeIVAGlobal <> valorNumerico(Me.Grid.Cell(i, Me.igyImpuestoPorcentaje).Text) Then
                                MsgBox("No se pueden tener diferentes porcentajes de IVA.", MsgBoxStyle.Exclamation, sProcedure)
                                Return False
                            End If
                        End If
                    End If

                    If valorNumerico(Me.Grid.Cell(i, Me.igyEsRequisicion).Text) > 0 Then 'If valorNumerico(Me.Grid.Cell(i, Me.igyIDRequisicionDetalle).Text) > 0 Then
                        bHayArticulosRequeridos = True
                    End If

                    bHayArticulos = True
                End If
            Next i

            If Me.chkEsInventariable.Checked = False Then 'Si es de servicios
                If Me.ValidaQueTodosSeanNoInventariables(True) = False Then 'Todos deben ser no inv
                    Return False
                End If
            Else 'Es inventariable, pueden ser todos inv, o revueltos, pero no puros noinv
                If Me.ValidaQueTodosSeanNoInventariables(False) = True Then
                    MsgBox("Este es un documento inventariable y agregó solamente artículos no inventariables.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If
            End If

            If bHayArticulos = False Then
                MsgBox("Captúre el detalle del movimiento.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            If Empresa_Sistema.MODO_REQUISICIONES_INVENTARIO AndAlso bHayArticulosRequeridos = False Then
                'Evita que se grabe folio o texto si no se agregaron articulos de la requisicion al grid
                Me.TxtRequisicion.Text = ""
            End If


        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try

        Return True
    End Function

    Private Function ValidarCompra() As Boolean
        Const sProcedure As String = "ValidarCompra"
        Try
            Dim bTieneRenglones As Boolean = False
            Dim bPrimerIVAEncontrado As Boolean = False
            Dim oArticulos As Class_CatArticulos

            If Plaza.ValidarPeriodoTrabajo(Me.DtpFecha.Value) = False Then
                Return False
            End If

            'Esto esta contenido de mejor modo en ValidaCuentasContable
            'Dim oArticulos As Class_CatArticulos
            'For i = 1 To Me.Grid.Rows - 1
            '    If txtLEN(Me.Grid.Cell(i, Me.igyCodigo).Text) = True Then
            '        oArticulos = New Class_CatArticulos(Me.Grid.Cell(i, Me.igyCodigo).Text)
            '        If oArticulos.INVENTARIABLE = "0" Then
            '            If Mid(Me.Grid.Cell(i, Me.igyCuentaContable).Text, 1, 4) = Empresa_Sistema.CUENTA_CONTABLE_ALMACENES.ToString Then
            '                MsgBox("La cuenta para los artículos no inventariables no debe de empezar con " & Empresa_Sistema.CUENTA_CONTABLE_ALMACENES.ToString & "." & vbCrLf & _
            '                       "Revíse el renglón #" & i, MsgBoxStyle.Exclamation, Me.Text)
            '                Return False
            '            End If
            '            If Microsoft.VisualBasic.Left(Me.Grid.Cell(i, Me.igyCuentaContable).Text, 1) <> "1" Then
            '                MsgBox("La cuenta para los artículos no inventariables debe empezar con 1." & vbCrLf & _
            '                        "Revíse el renglón #" & i, MsgBoxStyle.Exclamation, Me.Text)
            '                Return False
            '            End If
            '        End If
            '    End If
            'Next

            For i = 1 To Me.Grid.Rows - 1
                If txtLEN(Me.Grid.Cell(i, Me.igyCodigo).Text) = True Then
                    bTieneRenglones = True
                    Exit For
                End If
            Next

            If bTieneRenglones = False Then
                MsgBox("No hay artículos agregados, favor de revisar.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            If Me.chkEsInventariable.Checked = True Then
                If Me.TieneAgregadasEntradasInventario() = False Then
                    MsgBox("Este documento es inventariable y usted no detalló entradas de inventarios, favor de revisar.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If

                If Me.ValidaEntradasInventario = False Then
                    Return False
                End If

                If Me.ValidaDisponiblesEntradaOC = False Then
                    Return False
                End If

                If Me.cboMoneda.Text = "USD" Then
                    If valorNumericoD(Me.txtTipoCambio.Text) <= 0 Then
                        MsgBox("Capture el tipo de cambio.", MsgBoxStyle.Exclamation, sProcedure)
                        If Me.txtTipoCambio.Enabled = True Then
                            Me.txtTipoCambio.Focus()
                        End If
                        Return False
                    End If
                End If


                'Aqui se hacen algunas validaciones en el grid de articulos como en ValidarOrdenCompra()
                Me.dPorcentajeIVAGlobal = 0

                Dim i As Integer, sArticulo As String = ""
                For i = 1 To Me.Grid.Rows - 1
                    sArticulo = Me.Grid.Cell(i, Me.igyCodigo).Text

                    If txtLEN(sArticulo) = True And sArticulo <> "-" Then ' "-" es para comentarios
                        oArticulos = New Class_CatArticulos(sArticulo)

                        If valorNumerico(Me.Grid.Cell(i, Me.igyCantidad).Text) <= 0 Then
                            MsgBox("La cantidad del artículo debe de ser mayor a 0.", MsgBoxStyle.Exclamation, sProcedure)
                            Me.Grid.Cell(i, Me.igyCantidad).SetFocus()
                            Return False
                        End If

                        If valorNumerico(Me.Grid.Cell(i, Me.igyPrecio).Text) <= 0 Then
                            MsgBox("El precio del artículo debe de ser mayor a 0.", MsgBoxStyle.Exclamation, sProcedure)
                            Me.Grid.Cell(i, Me.igyPrecio).SetFocus()
                            Return False
                        End If

                        If txtLEN(Me.Grid.Cell(i, Me.igyImpuestoPorcentaje).Text) = False Then
                            MsgBox("El artículo no tiene un porcentaje de iva.", MsgBoxStyle.Exclamation, sProcedure)
                            Me.Grid.Cell(i, Me.igyImpuestoPorcentaje).SetFocus()
                            Return False
                        End If

                        If valorNumerico(Me.Grid.Cell(i, Me.igyImpuestoPorcentaje).Text) > 0 Then
                            If bPrimerIVAEncontrado = False Then
                                Me.dPorcentajeIVAGlobal = valorNumerico(Me.Grid.Cell(i, Me.igyImpuestoPorcentaje).Text)
                                bPrimerIVAEncontrado = True
                            Else
                                If dPorcentajeIVAGlobal <> valorNumerico(Me.Grid.Cell(i, Me.igyImpuestoPorcentaje).Text) Then
                                    MsgBox("No se pueden tener diferentes porcentajes de IVA.", MsgBoxStyle.Exclamation, sProcedure)
                                    Return False
                                End If
                            End If
                        End If

                        If Empresa_Sistema.CONTROL_COSTOS_COMPRAS = True Then
                            Dim costo As Double = valorNumerico(Me.Grid.Cell(i, Me.igyPrecio).Text), precioVenta As Double = valorNumerico(Me.Grid.Cell(i, Me.igyPrecioVenta).Text)
                            If (precioVenta / costo) < 0.5 Then
                                MsgBox("El precio de venta del artículo " & Me.Grid.Cell(i, Me.igyCodigo).Text & " debe ser de al menos el 50% del costo.", MsgBoxStyle.Exclamation, sProcedure)
                                Me.Grid.Cell(i, Me.igyPrecioVenta).SetFocus()
                                Return False
                            End If

                        End If

                    End If
                Next i

                'Ya no se validan series en ningún momento , porque estas ese llevan ahora en las entradas.
                ''Nota aqui no se pregunta antes si hay rows en dtSeries, porque puede ser que no le hayan dado al botón, en la siguiente validación si.
                'If Me.ValidaNumerosSerie = False Then
                '    Return False
                'End If

                'If IsNothing(Me.dtSeries) = False AndAlso Me.dtSeries.Rows.Count > 0 Then

                '    'NOTA: cuando sea false VALIDA_SERIES_REPETIDAS_EN_ENTRADAS no entrará a las dos validaciones internas debido a :
                '    'Sobre validar HaySeriesRepetidas - Es porque en vez de usar series usan lotes, ejemplo se le compra a x proveedor 50 kilos de x producto del lote rh-587, las 50 unidades deberán tener el mismo lote
                '    'Y sobre validar HaySeriesConExistenciasMismoArticulo - Al usar lotes es posible que en un compra pongan serie "2016", y en otra compra otra vez repitan "2016"( es más factible que se repitan entre diferentes compras)

                '    If Empresa_Sistema.VALIDA_SERIES_REPETIDAS_EN_ENTRADAS = True Then

                '        If Me.HaySeriesRepetidas = True Then
                '            Return False
                '        End If

                '        If Me.HaySeriesConExistenciasMismoArticulo = True Then
                '            Return False
                '        End If
                '    End If
                'End If

            Else 'Es de servicio
                If Me.TieneAgregadasEntradasInventario() = True Then
                    MsgBox("Este documento es no inventariable y usted detalló salidas de inventarios, favor de revisar.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If

                If txtLEN(Me.txtFolioOC.Text) = False Then
                    MsgBox("Asígne la orden de compra de referencia.", MsgBoxStyle.Exclamation, sProcedure)
                    Me.txtFolioOC.Focus()
                    Return False
                End If

                Me.oCompras = New Class_Compras_Global(Me.txtFolioOC.Text, Me.oCompras.ObtieneCodigoDocumentoOrdenCompra(Me.txtFolioOC.Text))

                If Me.oCompras.Existe = False Then
                    MsgBox("Asígne una orden de compra válida.", MsgBoxStyle.Exclamation, sProcedure)
                    Me.txtFolioOC.Focus()
                    Return False
                End If

                If Me.ValidaDisponiblesOCaCO = False Then
                    Return False
                End If
            End If

            Dim oAlmacen As New Class_CatAlmacenes(Me.CboAlmacen.SelectedValue.ToString)

            If oAlmacen.ES_FISCAL = True Then
                If Me.ValidaCuentasContables = False Then
                    Return False
                End If
            End If

            If Me.cboMoneda.Text = "USD" Then
                If valorNumericoD(Me.txtTipoCambio.Text) <= 0 Then
                    MsgBox("Capture el tipo de cambio.", MsgBoxStyle.Exclamation, sProcedure)
                    If Me.txtTipoCambio.Enabled = True Then
                        Me.txtTipoCambio.Focus()
                    End If
                    Return False
                End If
            End If

            If valorNumericoD(Me.txtTotal.Text) <= 0 Then
                MsgBox("El total de la compra no puede ser cero.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            Return True

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try

    End Function

    Private Function Contabilizar() As Boolean
        Return True
    End Function

    Private Sub DesplegarDocumentos(Optional ByVal bAccesibileUsuarios As Boolean = True)
        Try
            With Me.CboDocumento
                .DisplayMember = "NOMBRE_TIPO_DOCUMENTO"
                .ValueMember = "CODIGO_DOCUMENTO"
                Dim dView As New Data.DataView(Me.oDocumento.ObtenerCodigosDocumentos(Me.oCompras.CODIGO_MODULO, Usuario.Codigo_Plaza.ToString, IIf(bAccesibileUsuarios = True, " ESTATUS_DOCUMENTO='A'  AND ACCESIBLE_USUARIO='1' ", " ESTATUS_DOCUMENTO='A' AND ACCESIBLE_USUARIO='0' ").ToString))
                dView.Sort = "NOMBRE_TIPO_DOCUMENTO DESC"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedIndex = 0
                    Me.bDocumentosCargados = True
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarDocumentos", ex)
        End Try
    End Sub

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
                    .SelectedValue = Plaza.CODIGO_ALMACEN_PRINCIPAL 'Usuario.Codigo_Almacen
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarAlmacenes", ex)
        End Try
    End Sub

    Private Sub DesplegarMonedas()
        Try
            Dim oMoneda As New Class_CatMonedas
            Dim dTable As New DataTable

            With Me.cboMoneda
                .DisplayMember = "CODIGO_MONEDA_SAT"
                .ValueMember = "CODIGO_MONEDA"
                dTable = oMoneda.ObtenerElementos
                dTable.Rows(2).Delete() 'Quita Euros del DataTable
                .DataSource = dTable
                .SelectedValue = 1 '1=MXN
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarMonedas", ex)
        End Try
    End Sub

    Private Sub DesplegarTiposEnvio()
        Try
            Dim oTipoEnvio As New Class_CatTiposEnvios

            With Me.CboTipoEnvio
                .DisplayMember = "NOMBRE_TIPO_ENVIO"
                .ValueMember = "CODIGO_TIPO_ENVIO"
                Dim dView As New Data.DataView(oTipoEnvio.ObtenerElementos)
                dView.Sort = "NOMBRE_TIPO_ENVIO"
                .DataSource = dView
                .SelectedIndex = -1
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarTiposEnvio", ex)
        End Try
    End Sub

    Private Function Totales(Optional ByVal bIva As Boolean = False) As Boolean
        Const sProcedure As String = "Totales"
        Dim bResultado As Boolean = False
        Try
            Dim i As Integer, dTipoCambio As Decimal = 0
            Dim dCantidad As Decimal, dPrecio As Decimal, dPorcentajeIVA As Decimal, dImporte As Decimal
            Dim dIEPS_PORCENTAJE As Decimal = 0, dIEPS_UNITARIO As Decimal = 0, dIEPS_IMPORTE As Decimal = 0, dBASE_IEPS As Decimal = 0, dBASE_IVA As Decimal = 0, dIVA_IMPORTE As Decimal = 0

            Dim dPrecio_USD As Decimal = 0, dImporte_USD As Decimal = 0
            Dim dIEPS_UNITARIO_USD As Decimal = 0, dIEPS_IMPORTE_USD As Decimal = 0, dBASE_IEPS_USD As Decimal = 0, dBASE_IVA_USD As Decimal = 0, dIVA_IMPORTE_USD As Decimal = 0

            Dim oArticulo As New Class_CatArticulos

            Dim dtSubtotal As Decimal = 0, dtIEPS As Decimal = 0, dtImpuesto As Decimal = 0, dtTotal As Decimal = 0, dtRetencionIVA As Decimal = 0, dtRetencionISR As Decimal = 0
            Dim dtSubtotal_USD As Decimal = 0, dtIEPS_USD As Decimal = 0, dtImpuesto_USD As Decimal = 0, dtTotal_USD As Decimal = 0, dtRetencionIVA_USD As Decimal = 0, dtRetencionISR_USD As Decimal = 0

            dTipoCambio = valorNumericoD(Me.txtTipoCambio.Text)
            dTipoCambio = RedondearD(dTipoCambio, 4)
            Me.txtTipoCambio.Text = Format(dTipoCambio, "##0.0000")

            Me.TxtSubTotal.Text = FormatImporteContable(0)
            Me.txtIEPS.Text = FormatImporteContable(0)
            'Me.txtIVA.Text = FormatImporteContable(0)'No se inicializa porque puede venir modificado
            Me.txtTotal.Text = FormatImporteContable(0)

            Me.TxtSubTotal_USD.Text = FormatImporteContable(0)
            Me.txtIEPS_USD.Text = FormatImporteContable(0)
            'Me.txtIVA_USD.Text = FormatImporteContable(0)
            Me.txtTotal_USD.Text = FormatImporteContable(0)

            For i = 1 To Me.Grid.Rows - 1
                If txtLEN(Me.Grid.Cell(i, Me.igyCodigo).Text) = False Then
                    Continue For
                End If

                oArticulo = New Class_CatArticulos(Me.Grid.Cell(i, Me.igyCodigo).Text)

                If txtLEN(Me.Grid.Cell(i, Me.igyCantidad).Text) = False Then
                    Continue For
                End If

                dCantidad = 0 : dPrecio = 0 : dPorcentajeIVA = 0 : dIEPS_PORCENTAJE = 0 : dIEPS_UNITARIO = 0 : dBASE_IEPS = 0 : dIEPS_IMPORTE = 0 : dBASE_IVA = 0 : dIVA_IMPORTE = 0 : dImporte = 0

                dCantidad = valorNumericoD(Me.Grid.Cell(i, Me.igyCantidad).Text)
                dPrecio = valorNumericoD(Me.Grid.Cell(i, Me.igyPrecio).Text)
                dPrecio_USD = valorNumericoD(Me.Grid.Cell(i, Me.igyPRECIO_USD).Text)
                dPorcentajeIVA = valorNumericoD(Me.Grid.Cell(i, Me.igyImpuestoPorcentaje).Text)
                dIEPS_PORCENTAJE = valorNumericoD(Me.Grid.Cell(i, Me.igyIEPS_PORCENTAJE).Text)

                '''''''''''''''''''''''''''''''USD
                If Me.cboMoneda.Text = "USD" Then
                    ''''''''''''''''
                    'Calculamos los otros valores en MXN capturables(que si bien no se capturaron se emularán)
                    dPrecio = dPrecio_USD * dTipoCambio
                    dPrecio = RedondearD(dPrecio, Empresa_Sistema.DECIMALES_CANTIDAD)

                    Me.Grid.Cell(i, Me.igyPrecio).Text = dPrecio.ToString
                    ''''''''''''''''
                    dIEPS_UNITARIO_USD = RedondearD(dPrecio_USD * (dIEPS_PORCENTAJE / 100), 4)
                    'dBASE_IEPS_USD = Redondear((dPrecio_USD * dCantidad), 2)
                    dBASE_IEPS_USD = RedondearD((dPrecio_USD * dCantidad), 6)
                    dIEPS_IMPORTE_USD = RedondearD(dBASE_IEPS_USD * (dIEPS_PORCENTAJE / 100), 2) 'De momento este no se paso a mas decimales, habra que revisar estructura y factibilidad
                    dBASE_IVA_USD = dIEPS_IMPORTE_USD + dBASE_IEPS_USD
                    dIVA_IMPORTE_USD = RedondearD(dBASE_IVA_USD * ((dPorcentajeIVA / 100)), 2)

                    dImporte_USD = RedondearD((dPrecio_USD * dCantidad), Empresa_Sistema.DECIMALES_CONTABILIDAD) 'no hacemos nada con este valor de momento

                    Me.Grid.Cell(i, Me.igyIMPORTE_USD).Text = dImporte_USD.ToString
                    Me.Grid.Cell(i, Me.igyIEPS_UNITARIO_USD).Text = dIEPS_UNITARIO_USD.ToString
                    Me.Grid.Cell(i, Me.igyBASE_IEPS_USD).Text = dBASE_IEPS_USD.ToString
                    Me.Grid.Cell(i, Me.igyIEPS_IMPORTE_USD).Text = dIEPS_IMPORTE_USD.ToString
                    Me.Grid.Cell(i, Me.igyBASE_IVA_USD).Text = dBASE_IVA_USD.ToString
                    Me.Grid.Cell(i, Me.igyIMPUESTO_IMPORTE_USD).Text = dIVA_IMPORTE_USD.ToString

                    ''''''''''''''''''''''''''''''MXN(Este cálculo se hace en para calcular los valores en MXN a partir de los USD,note que también en moneda en MXN direco hace el cálculo-parecido)
                    dIEPS_UNITARIO = RedondearD(dIEPS_UNITARIO_USD * dTipoCambio, 4)
                    'dBASE_IEPS = Redondear((dBASE_IEPS_USD * dTipoCambio), 2)
                    dBASE_IEPS = RedondearD((dBASE_IEPS_USD * dTipoCambio), 6)
                    dIEPS_IMPORTE = RedondearD(dIEPS_IMPORTE * dTipoCambio, 2) 'De momento este no se paso a mas decimales, habra que revisar estructura y factibilidad
                    dBASE_IVA = dIEPS_IMPORTE + dBASE_IEPS
                    dIVA_IMPORTE = RedondearD(dIVA_IMPORTE_USD * dTipoCambio, 2)

                    dImporte = RedondearD((dImporte_USD * dTipoCambio), Empresa_Sistema.DECIMALES_CONTABILIDAD) 'no hacemos nada con este valor de momento

                Else ''''''''''''''''''''''''''MXN
                    dIEPS_UNITARIO = RedondearD(dPrecio * (dIEPS_PORCENTAJE / 100), 4)
                    'dBASE_IEPS = Redondear((dPrecio * dCantidad), 2)
                    dBASE_IEPS = RedondearD((dPrecio * dCantidad), 6)
                    dIEPS_IMPORTE = RedondearD(dBASE_IEPS * (dIEPS_PORCENTAJE / 100), 2) 'De momento este no se paso a mas decimales, habra que revisar estructura y factibilidad
                    dBASE_IVA = dIEPS_IMPORTE + dBASE_IEPS
                    dIVA_IMPORTE = RedondearD(dBASE_IVA * ((dPorcentajeIVA / 100)), 2)

                    dImporte = RedondearD((dPrecio * dCantidad), Empresa_Sistema.DECIMALES_CONTABILIDAD) 'no hacemos nada con este valor de momento
                End If

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
            Next i

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''''''''''''''''''''TOTALES USD
            dtSubtotal_USD = RedondearD(CDec(FG_Grid_SumaCol(Me.Grid, Me.igyIMPORTE_USD)), Empresa_Sistema.DECIMALES_CONTABILIDAD)
            dtIEPS_USD = RedondearD(CDec(FG_Grid_SumaCol(Me.Grid, Me.igyIEPS_IMPORTE_USD)), Empresa_Sistema.DECIMALES_CONTABILIDAD)
            dtImpuesto_USD = RedondearD(CDec(FG_Grid_SumaCol(Me.Grid, Me.igyIMPUESTO_IMPORTE_USD)), Empresa_Sistema.DECIMALES_CONTABILIDAD)
            dtRetencionIVA_USD = RedondearD(valorNumericoD(Me.txtRetencionIVA_USD.Text), Empresa_Sistema.DECIMALES_CONTABILIDAD)
            dtRetencionISR_USD = RedondearD(valorNumericoD(Me.txtRetencionISR_USD.Text), Empresa_Sistema.DECIMALES_CONTABILIDAD)

            Me.TxtSubTotal_USD.Text = FormatImporteContable(dtSubtotal_USD)
            Me.txtIEPS_USD.Text = FormatImporteContable(dtIEPS_USD)
            Me.lblIVAcalculado_USD.Text = FormatImporteContable(dtImpuesto_USD) 'Este siempre será el iva con el cálculo de la información en el grid y sirve para ver que tan diferente es del txtIva que puede ser manipulado.
            'Me.txtIVA_USD.Text = FormatImporteContable(dtImpuesto_USD)'No se pone todavia en el txt, dependende del modo de bIva
            Me.txtRetencionIVA_USD.Text = FormatImporteContable(dtRetencionIVA_USD)
            Me.txtRetencionISR_USD.Text = FormatImporteContable(dtRetencionISR_USD)

            If Me.cboMoneda.Text = "USD" Then
                If bIva = False Then
                    'If valorNumerico(Me.lblIVAcalculado.Text) > 0 And valorNumerico(Me.txtIVA.Text) = 0 Then
                    Me.txtIVA_USD.Text = FormatImporteContable(Redondear(FG_Grid_SumaCol(Me.Grid, Me.igyIMPUESTO_IMPORTE_USD), Empresa_Sistema.DECIMALES_CONTABILIDAD))

                    'Nota si no se manipuló el iva en USD directamente, el iva en MXN si es la suma de los renglones(si no es la mult iva usd x tpcam), de lo contrario la póliza puede haber diferencias.
                    dtImpuesto = RedondearD(CDec(FG_Grid_SumaCol(Me.Grid, Me.igyImpuestoImporte)), Empresa_Sistema.DECIMALES_CONTABILIDAD)
                Else
                    Me.txtIVA_USD.Text = FormatImporteContable(RedondearD(valorNumericoD(Me.txtIVA_USD.Text), Empresa_Sistema.DECIMALES_CONTABILIDAD)) 'Es posible iva tecleado se deja aunque se redondea a 2 cifras decimales
                    'ElseIf valorNumerico(Me.lblIVAcalculado.Text) <> valorNumerico(Me.txtIVA.Text) Then
                    'If valorNumerico(Me.txtIVA.Text) > valorNumerico(Me.lblIVAcalculado.Text) - 1 And valorNumerico(Me.txtIVA.Text) > valorNumerico(Me.lblIVAcalculado.Text) + 1 Then
                    If Not (valorNumerico(Me.txtIVA_USD.Text) >= valorNumerico(Me.lblIVAcalculado_USD.Text) - 1 And valorNumerico(Me.txtIVA_USD.Text) <= valorNumerico(Me.lblIVAcalculado_USD.Text) + 1) Then
                        MsgBox("El IVA asignado no es correcto(puede manipularse hasta +- un peso), favor de verificar.", MsgBoxStyle.Exclamation, sProcedure)
                        Me.txtIVA_USD.Focus()
                        Return False
                    End If
                    'End If

                    'Nota el impuesto en MXN va ser conversión directa de del usd por si lo editaron manualmente.
                    dtImpuesto = RedondearD(dtImpuesto_USD * dTipoCambio, Empresa_Sistema.DECIMALES_CONTABILIDAD)
                End If

                dtImpuesto_USD = valorNumericoD(Me.txtIVA_USD.Text) 'Sobreecribe el impuesto con que quedó finalmente(ya se manual o calculado).

                Me.txtIVA.Text = FormatImporteContable(dtImpuesto)
            End If

            dtTotal_USD = dtSubtotal_USD + dtIEPS_USD + dtImpuesto_USD - dtRetencionIVA_USD - dtRetencionISR_USD
            dtTotal_USD = RedondearD(dtTotal_USD, Empresa_Sistema.DECIMALES_CONTABILIDAD) 'De todas formas se redondea porque a veces al hacer restas aparecen tropos.
            Me.txtTotal_USD.Text = FormatImporteContable(dtTotal_USD)

            'Me.TotalesUSD()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''''''''''''''''''''TOTALES MXN
            dtSubtotal = RedondearD(CDec(FG_Grid_SumaCol(Me.Grid, Me.igyImporte)), Empresa_Sistema.DECIMALES_CONTABILIDAD)
            dtIEPS = RedondearD(CDec(FG_Grid_SumaCol(Me.Grid, Me.igyIEPS_IMPORTE)), Empresa_Sistema.DECIMALES_CONTABILIDAD)
            If Me.cboMoneda.Text = "MXN" Then
                dtImpuesto = CDec(Redondear(FG_Grid_SumaCol(Me.Grid, Me.igyImpuestoImporte), Empresa_Sistema.DECIMALES_CONTABILIDAD))
                'Nota si fuera en USd ya viene calculado este dato.
            End If

            dtRetencionIVA = RedondearD(valorNumericoD(Me.txtRetencionIVA.Text), Empresa_Sistema.DECIMALES_CONTABILIDAD)
            dtRetencionISR = RedondearD(valorNumericoD(Me.txtRetencionISR.Text), Empresa_Sistema.DECIMALES_CONTABILIDAD)

            Me.TxtSubTotal.Text = FormatImporteContable(dtSubtotal)
            Me.txtIEPS.Text = FormatImporteContable(dtIEPS)
            Me.lblIVAcalculado.Text = FormatImporteContable(dtImpuesto)
            'Me.txtIVA.Text = FormatImporteContable(Redondear(FG_Grid_SumaCol(Me.Grid, Me.igyImpuestoImporte), Empresa_Sistema.DECIMALES_CONTABILIDAD))'No se pone todavia en el txt, dependende del modo de bIva
            Me.txtRetencionIVA.Text = FormatImporteContable(dtRetencionIVA)
            Me.txtRetencionISR.Text = FormatImporteContable(dtRetencionISR)

            If Me.cboMoneda.Text = "MXN" Then 'Nota se pregunta algo similiar en la parte de los usd, no se mezclan funcionalidad por el orden de como se leen los elementos.
                If bIva = False Then
                    'If valorNumerico(Me.lblIVAcalculado.Text) > 0 And valorNumerico(Me.txtIVA.Text) = 0 Then
                    Me.txtIVA.Text = FormatImporteContable(Redondear(FG_Grid_SumaCol(Me.Grid, Me.igyImpuestoImporte), Empresa_Sistema.DECIMALES_CONTABILIDAD))
                Else
                    Me.txtIVA.Text = FormatImporteContable(valorNumerico(Me.txtIVA.Text))
                    'ElseIf valorNumerico(Me.lblIVAcalculado.Text) <> valorNumerico(Me.txtIVA.Text) Then
                    'If valorNumerico(Me.txtIVA.Text) > valorNumerico(Me.lblIVAcalculado.Text) - 1 And valorNumerico(Me.txtIVA.Text) > valorNumerico(Me.lblIVAcalculado.Text) + 1 Then
                    If Not (valorNumerico(Me.txtIVA.Text) >= valorNumerico(Me.lblIVAcalculado.Text) - 1 And valorNumerico(Me.txtIVA.Text) <= valorNumerico(Me.lblIVAcalculado.Text) + 1) Then
                        MsgBox("El IVA asignado no es correcto, favor de verificar.", MsgBoxStyle.Exclamation, Me.Name)
                        Me.txtIVA.Focus()
                        Return False
                    End If
                    'End If
                End If

                dtImpuesto = valorNumericoD(Me.txtIVA.Text) 'Sobreecribe el impuesto con que quedó finalmente(ya se manual o calculado).
            End If

            dtTotal = dtSubtotal + dtIEPS + dtImpuesto - dtRetencionIVA - dtRetencionISR
            dtTotal = RedondearD(dtTotal, Empresa_Sistema.DECIMALES_CONTABILIDAD) 'De todas formas se redondea porque a veces al hacer restas aparecen tropos.

            Me.txtTotal.Text = FormatImporteContable(dtTotal)

            bResultado = True

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    'Private Sub TotalesUSD()
    '    Try
    '        Dim dTipoCambio As Double = valorNumerico(Me.txtTipoCambio.Text)
    '        Dim dSubtotalUSD As Double = 0, dIVAUSD As Double = 0, dTotalUSD As Double = 0

    '        If dTipoCambio > 0 And Me.cboMoneda.SelectedIndex = 1 Then 'Si no esta chequeado en usd , no va entrar aqui y van a quedan en ceros(simulando que se inicilizaron)
    '            dSubtotalUSD = Redondear(valorNumerico(Me.TxtSubTotal.Text) / dTipoCambio, Empresa_Sistema.DECIMALES_CONTABILIDAD)
    '            dIVAUSD = Redondear(valorNumerico(Me.txtIVA.Text) / dTipoCambio, Empresa_Sistema.DECIMALES_CONTABILIDAD)
    '            dTotalUSD = Redondear(valorNumerico(Me.txtTotal.Text) / dTipoCambio, Empresa_Sistema.DECIMALES_CONTABILIDAD)
    '        End If

    '        Me.TxtSubTotal_USD.Text = FormatImporteContable(dSubtotalUSD)
    '        Me.txtIVA_USD.Text = FormatImporteContable(dIVAUSD)
    '        Me.txtTotal_USD.Text = FormatImporteContable(dTotalUSD)

    '    Catch ex As Exception
    '        HandleError(Me.Name, "TotalesUSD", ex)
    '    End Try
    'End Sub

    Private Function GeneraFolio() As Boolean
        Try
            If Me.bDocumentosCargados = True Then
                Me.txtFolioCompra.Text = Me.oCompras.GeneraFolio
            End If
            Return txtLEN(Me.txtFolioCompra.Text)
        Catch ex As Exception
            HandleError(Me.Name, "GeneraFolio", ex)
        End Try
    End Function

    Private Sub GestionaGrid(ByVal e As System.Windows.Forms.KeyEventArgs)
        Const sProcedure As String = "GestionaGrid"
        Try
            Dim Columna As Integer, Renglon As Integer
            Dim StrCod As String, sCuentaContable As String, dCantidad As Decimal, dPrecio As Decimal, dPrecio_USD As Decimal = 0
            Dim oArticulo As Class_CatArticulos
            Dim oCuentas As New Class_CatCuentas 'Class_VWCatDeudoresDiversos

            If Me.oDocumento.AFECTA_CXP = True And Me.Grid.Selection.FirstRow = Me.Grid.Rows - 1 Then
                Return
            End If

            If Not (Me.Estado = enumEstados.NUEVO Or Me.Estado = enumEstados.GRABADO) Then
                Return
            End If

            Columna = Me.Grid.Selection.FirstCol
            Renglon = Me.Grid.Selection.FirstRow
            StrCod = Me.Grid.Cell(Renglon, Me.igyCodigo).Text
            dCantidad = valorNumericoD(Me.Grid.Cell(Renglon, Me.igyCantidad).Text)
            dPrecio = valorNumericoD(Me.Grid.Cell(Renglon, Me.igyPrecio).Text)
            dPrecio_USD = valorNumericoD(Me.Grid.Cell(Renglon, Me.igyPRECIO_USD).Text)

            'ESTA VALIDACION SE PUSO PARA QUE A LOS ARTICULOS INVENTARIABLES NO LES PUEDAN CAMBIAR LA CUENTA CONTABLE CALCULADA AUTOMATICAMENTE
            If Columna = Me.igyCuentaContable Then
                oArticulo = New Class_CatArticulos(StrCod)
                If oArticulo.INVENTARIABLE = "1" Then
                    e.SuppressKeyPress = True
                    Return
                End If
            End If

            Select Case e.KeyCode
                Case Keys.Enter
                    If StrCod = "-" Then
                        Return
                    End If

                    Select Case Columna
                        Case Me.igyCodigo
                            If txtLEN(StrCod) = False Then
                                GoTo BuscaArticulos : Return
                            End If
LlenaLinea:
                            oArticulo = New Class_CatArticulos(StrCod)
                            If oArticulo.Existe = False Then
                                GoTo BuscaArticulos : Return
                            End If

                            If StrCod = Empresa_Sistema.CODIGO_ARTICULO_NO_INVENTARIABLE_COMPRA_PROVEEDOR Then
                                Me.Grid.Cell(Renglon, Me.igyDescripcion).Text = ""
                                Me.Grid.Cell(Renglon, Me.igyCantidad).Text = "0"
                                Me.Grid.Cell(Renglon, Me.igyPrecio).Text = "0"
                                Me.Grid.Cell(Renglon, Me.igyPRECIO_USD).Text = "0"
                                Me.Grid.Cell(Renglon, Me.igyUnidad).Text = "PZA"
                                Me.Grid.Cell(Renglon, Me.igyImpuestoPorcentaje).Text = "0"

                                Me.Grid.Column(Me.igyDescripcion).Locked = False
                                Me.Grid.Column(Me.igyUnidad).Locked = False
                            Else
                                If oArticulo.Existe = True Then
                                    Me.Grid.Cell(Renglon, Me.igyDescripcion).Text = oArticulo.DESCRIPCION
                                    Me.Grid.Cell(Renglon, Me.igyCantidad).Text = "0"
                                    Me.Grid.Cell(Renglon, Me.igyPrecio).Text = "0" 'traer el ultimo precio del mismo proveedor y mismo articulo"
                                    Me.Grid.Cell(Renglon, Me.igyPRECIO_USD).Text = "0" 'traer el ultimo precio del mismo proveedor y mismo articulo"
                                    Me.Grid.Cell(Renglon, Me.igyUnidad).Text = oArticulo.UNIDAD_VENTA
                                    Me.Grid.Cell(Renglon, Me.igyMargenUtilidad).Text = oArticulo.MARGEN_UTILIDAD.ToString

                                    'If oArticulos.TIENE_IMPUESTO = "1" Then
                                    '    Me.Grid.Cell(Renglon, Me.igyImpuestoPorcentaje).Text = Plaza.Impuesto_Porcentaje.ToString
                                    'Else
                                    '    Me.Grid.Cell(Renglon, Me.igyImpuestoPorcentaje).Text = "0"
                                    'End If
                                    Me.Grid.Cell(Renglon, Me.igyImpuestoPorcentaje).Text = oArticulo.IMPUESTO_PORCENTAJE.ToString

                                    Me.Grid.Column(Me.igyDescripcion).Locked = True
                                    Me.Grid.Column(Me.igyUnidad).Locked = True
                                    Me.Grid.Column(Me.igyMargenUtilidad).Locked = True

                                    Me.Grid.Cell(Renglon, Me.igyIEPS_PORCENTAJE).Text = oArticulo.IEPS_PORCENTAJE.ToString
                                End If
                            End If

                            Me.Totales()

                        Case Me.igyCantidad
                            If dCantidad <= 0 Then
                                MsgBox("La cantidad debe de ser mayor a 0.", MsgBoxStyle.Exclamation, sProcedure)
                                Me.Grid.Cell(Renglon, Me.igyCantidad).SetFocus()
                                Return
                            End If

                            If Me.oDocumento.AFECTA_CXP = True Then
                                If Me.chkEsInventariable.Checked = True Then 'Valida disponible en la entrada por recepcion
                                    If Me.oCompras.ValidaCantidadDisponibleArticuloInventario(CInt(Me.Grid.Cell(Renglon, Me.igyID_INVENTARIO_MOVIMIENTOS_DETALLE_ENTRADA).Text), dCantidad) = False Then
                                        MsgBox("La cantidad debe de ser menor al disponible.", MsgBoxStyle.Exclamation, sProcedure)
                                        Me.Grid.Cell(Renglon, Me.igyCantidad).Text = Me.oCompras.ObtenerDisponibleArticuloInventario(CInt(Me.Grid.Cell(Renglon, Me.igyIdArticulo).Text)).ToString
                                        Me.Grid.Refresh()
                                        Return
                                    End If

                                Else 'Proceso normal de antes
                                    If Me.oCompras.ValidaCantidadDisponibleArticulo(CInt(Me.Grid.Cell(Renglon, Me.igyIdArticulo).Text), dCantidad) = False Then
                                        MsgBox("La cantidad debe de ser menor al disponible.", MsgBoxStyle.Exclamation, sProcedure)
                                        Me.Grid.Cell(Renglon, Me.igyCantidad).Text = Me.oCompras.ObtenerDisponibleArticulo(CInt(Me.Grid.Cell(Renglon, Me.igyIdArticulo).Text)).ToString
                                        Me.Grid.Refresh()
                                        Return
                                    End If
                                End If

                            End If

                            If Empresa_Sistema.MODO_REQUISICIONES_INVENTARIO = True AndAlso Me.chkEsInventariable.Checked = True AndAlso txtLEN(Me.TxtRequisicion.Text) = True Then
                                'Solo validara los renglones de la requisición
                                If valorNumerico(Me.Grid.Cell(Renglon, Me.igyEsRequisicion).Text) = 0 Then   'If valorNumerico(Me.Grid.Cell(Renglon, Me.igyIDRequisicionDetalle).Text) = 0 Then
                                    Return
                                End If

                                'Valida el disponible de requisicion pero deja avanzar aunque no haya suficiente
                                Dim dCantidadDisponible As Decimal = Me.oRequisicion.CantidadDisponible(Me.Grid.Cell(Renglon, Me.igyCodigo).Text, Me.CboAlmacen.SelectedValue.ToString) 'Me.oRequisicion.CantidadDisponible(Me.Grid.Cell(Renglon, Me.igyCodigo).Text, Me.TxtRequisicion.Text)

                                If dCantidad > dCantidadDisponible Then
                                    MsgBox("La cantidad capturada del artículo " & Me.Grid.Cell(Renglon, Me.igyDescripcion).Text & " en el renglón " & Renglon.ToString & " es mayor a la requerida pendiente de pedir que es de " &
                                         dCantidadDisponible.ToString & " en el almacén " & Me.CboAlmacen.Text & ".", MsgBoxStyle.Exclamation, "Advertencia")
                                End If
                            End If

                            If Me.cboMoneda.Text = "USD" Then
                                Me.Grid.Cell(Renglon, Me.igyPrecio).SetFocus() 'Para que se vaya a igyPrecio_USD ponemos una celda anterior
                            End If

                        Case Me.igyPrecio
                            If Me.cboMoneda.Text = "USD" Then
                                'Avanza de todas formas estará bloqueado                                    
                            Else
                                If dPrecio <= 0 Then
                                    MsgBox("El precio debe de ser mayor a 0.", MsgBoxStyle.Exclamation, sProcedure)
                                    Me.Grid.Cell(Renglon, Me.igyPrecio).SetFocus()
                                End If
                            End If

                            If Empresa_Sistema.CONTROL_COSTOS_COMPRAS = True AndAlso Me.Estado = enumEstados.NUEVO Then
                                Me.Grid.Cell(Renglon, Me.igyCosto).Text = Me.Grid.Cell(Renglon, Me.igyPrecio).Text
                                Me.Grid.Cell(Renglon, Me.igyCostoMercado).Text = Me.Grid.Cell(Renglon, Me.igyPrecio).Text
                                CalculaPrecioVenta(Renglon, valorNumericoD(Me.Grid.Cell(Renglon, Me.igyMargenUtilidad).Text))
                            End If

                        Case Me.igyPRECIO_USD
                            oArticulo = New Class_CatArticulos(StrCod)
                            If dPrecio_USD <= 0 Then
                                MsgBox("El precio debe de ser mayor a 0.", MsgBoxStyle.Exclamation, sProcedure)
                                Me.Grid.Cell(Renglon, Me.igyPrecio).SetFocus() 'Para que se vaya a igyPrecio_USD ponemos una celda anterior
                            End If

                        Case Me.igyCostoMercado
                            If Empresa_Sistema.CONTROL_COSTOS_COMPRAS = True Then
                                CalculaPrecioVenta(Renglon, valorNumericoD(Me.Grid.Cell(Renglon, Me.igyMargenUtilidad).Text))
                            End If

                        Case Me.igyImpuestoPorcentaje
                            'Me.Totales()'Ya se hace al final para todas las columnas.

                        Case Me.igyCuentaContable 'Enter
                            'oCuentas = New Class_VWCatDeudoresDiversos(Me.Grid.Cell(Renglon, Me.igyCuentaContable).Text) ' Class_CatCuentas(Me.Grid.Cell(Renglon, Me.igyCuentaContable).Text)

                            sCuentaContable = Me.Grid.Cell(Renglon, Me.igyCuentaContable).Text

                            If sCuentaContable.StartsWith("1") = False Then
                                Me.Grid.Cell(Renglon, Me.igyCuentaContable).Text = ""
                                Me.Grid.Cell(Renglon, Me.iGyNombreCuentaContable).Text = ""
                                MsgBox("La cuenta contable del renglón : " & Renglon & " debe ser del rango de las miles(que empiezen con 1).", MsgBoxStyle.Exclamation, Me.Name)
                                Return
                            End If

                            oCuentas = New Class_CatCuentas(sCuentaContable)

                            If oCuentas._Existe = True Then
                                Me.Grid.Cell(Renglon, Me.igyCuentaContable).Text = oCuentas.CUENTA_CONTABLE
                                Me.Grid.Cell(Renglon, Me.iGyNombreCuentaContable).Text = oCuentas.NOMBRE_CUENTA
                            Else
                                Me.Grid.Cell(Renglon, Me.igyCuentaContable).Text = ""
                                Me.Grid.Cell(Renglon, Me.iGyNombreCuentaContable).Text = ""
                                GoTo BuscarCuentas : Return
                            End If

                            Me.Grid.Cell(Renglon + 1, Me.igyImporte).SetFocus()

                    End Select

                    Select Case Columna
                        Case Me.igyImpuestoPorcentaje
                            If Me.Grid.Rows = Renglon + 1 Then
                                Me.Grid.Rows = Me.Grid.Rows + 1
                            End If

                            Me.Grid.Cell(Renglon + 1, Me.iGyIDAdicional).Text = (valorNumerico(Me.Grid.Cell(Renglon, Me.iGyIDAdicional).Text) + 1).ToString
                    End Select

                    'Me.Totales(True)
                    Me.Totales()

                    'Calculo del precio venta, al final para asegurar que se calcule el precio mxn primero
                    If Empresa_Sistema.CONTROL_COSTOS_COMPRAS = True Then
                        Select Case Columna
                            Case Me.igyPrecio, Me.igyPRECIO_USD
                                'Me.Grid.Cell(Renglon, Me.igyCostoMercado).Text = Me.Grid.Cell(Renglon, Me.igyPrecio).Text
                                Dim Precio As Double = valorNumerico(Me.Grid.Cell(Renglon, Me.igyPrecio).Text) 'Si no se convierte a numero primero no copia el texto a la columna costoMercado
                                Me.Grid.Cell(Renglon, Me.igyCostoMercado).Text = Precio.ToString
                                CalculaPrecioVenta(Renglon, valorNumerico(Me.Grid.Cell(Renglon, Me.igyMargenUtilidad).Text))
                        End Select
                    End If

                Case Keys.F2 'Establece el artículo para no inventariables.
                    Me.Grid.Cell(Renglon, Me.igyCodigo).Text = Empresa_Sistema.CODIGO_ARTICULO_NO_INVENTARIABLE_COMPRA_PROVEEDOR

                Case Keys.F6, Keys.F7
BuscaArticulos:
                    Select Case Columna
                        Case Me.igyCodigo
                            If e.KeyCode = Keys.F6 Then
                                oArticulo = New Class_CatArticulos
                                'StrCod = oArticulo.BusquedaVisualInventariables_PorDescripcion()
                                StrCod = oArticulo.BusquedaVisual_PorDescripcion_conExistencias(Me.CboAlmacen.SelectedValue.ToString, False)
                                If txtLEN(StrCod) = True Then
                                    Me.Grid.Cell(Renglon, Me.igyCodigo).Text = StrCod
                                    GoTo LlenaLinea
                                End If

                            ElseIf e.KeyCode = Keys.F7 Then
                                oArticulo = New Class_CatArticulos
                                StrCod = oArticulo.BusquedaVisualInventariables_PorCodigo()
                                If txtLEN(StrCod) = True Then
                                    Me.Grid.Cell(Renglon, Me.igyCodigo).Text = StrCod
                                    GoTo LlenaLinea
                                End If
                            End If

                        Case Me.igyCuentaContable
BuscarCuentas:
                            oArticulo = New Class_CatArticulos(Me.Grid.Cell(Renglon, Me.igyCodigo).Text)

                            If e.KeyCode = Keys.F6 Then
                                sCuentaContable = oCuentas.BusquedaVisual_PorCodigoConLike("1") '.BusquedaVisual_PorCodigoFiltrandoTipoOperacion()
                            Else
                                sCuentaContable = oCuentas.BusquedaVisual_PorDescripcionConLike("1") 'f7
                            End If

                            If sCuentaContable = "" Then
                                Return
                            End If

                            If oArticulo.INVENTARIABLE = "0" Then
                                If Mid(sCuentaContable, 1, 4) = Empresa_Sistema.CUENTA_CONTABLE_ALMACENES.ToString Then
                                    MsgBox("La cuenta para los artículos no inventariables no deben de empezar con " & Empresa_Sistema.CUENTA_CONTABLE_ALMACENES.ToString & ".", MsgBoxStyle.Exclamation, sProcedure)
                                    Return
                                End If
                            End If

                            'oCuentas = New Class_VWCatDeudoresDiversos(sCuentaContable)
                            oCuentas = New Class_CatCuentas(sCuentaContable)
                            Me.Grid.Cell(Renglon, Me.igyCuentaContable).Text = oCuentas.CUENTA_CONTABLE
                            Me.Grid.Cell(Renglon, Me.iGyNombreCuentaContable).Text = oCuentas.NOMBRE_CUENTA

                    End Select

                    'Case Keys.F7
                    'BuscarCuentas:
                    '                    sCuentaContable = Me.oCuentas.BusquedaVisual_PorNombreFiltrandoTipoOperacion()
                    '                    If sCuentaContable = "" Then
                    '                        Me.Grid.Cell(Renglon, Me.igyCuentaContable).Text = ""
                    '                        Me.Grid.Refresh()
                    '                        return
                    '                    End If

                    '                    oArticulos = New Class_CatArticulos(Me.Grid.Cell(Renglon, Me.igyCodigo).Text)

                    '                    If oArticulos.INVENTARIABLE = "0" Then
                    '                        If Mid(sCuentaContable, 1, 4) = Empresa_Sistema.CUENTA_CONTABLE_ALMACENES.ToString Then
                    '                            MsgBox("La cuenta para los artículos no inventariables no deben de empezar con " & Empresa_Sistema.CUENTA_CONTABLE_ALMACENES.ToString & ".", MsgBoxStyle.Exclamation, sProcedure)
                    '                            return
                    '                        End If
                    '                    End If

                    '                    Me.Grid.Cell(Renglon, Me.igyCuentaContable).Text = sCuentaContable

                Case Keys.F8, Keys.Delete 'Elimina el renglón seleccionado.
                    If (Me.Estado = enumEstados.NUEVO Or Me.Estado = enumEstados.GRABADO) Then
                        Dim IDAdicional As Integer = 0
                        If txtLEN(Me.Grid.Cell(Renglon, Me.iGyIDAdicional).Text) = True Then
                            IDAdicional = CInt(Me.Grid.Cell(Renglon, Me.iGyIDAdicional).Text)
                        End If

                        'MsgBox(Me.Grid.Rows.ToString)
                        Me.Grid.Selection.DeleteByRow()
                        'MsgBox(Me.Grid.Rows.ToString)
                        Me.Totales()

                        If IDAdicional > 0 Then
                            Me.EliminaDetalleCuentasContables(IDAdicional)
                        End If

                    End If

                Case Keys.F4 'Comentarios
                    If Me.oDocumento.AFECTA_CXP = True Then 'Los comentarios sólo son permitidos en las órdenes de compra.
                        Return
                    End If

                    Dim oComentario As New Ventas_Comentarios
                    If StrCod = "-" Then 'Si el código anterior era comentario mostramos el mismo comentario para editarlo, si es un producto lo dejamos en blanco
                        oComentario.txtComentario.Text = Me.Grid.Cell(Renglon, Me.igyDescripcion).Text
                    End If
                    oComentario.ShowDialog()

                    If oComentario.Aceptar = True Then
                        Me.Grid.Cell(Renglon, Me.igyCodigo).Text = "-"
                        Me.Grid.Cell(Renglon, Me.igyDescripcion).Text = oComentario.txtComentario.Text
                        Me.Grid.Cell(Renglon, Me.iGyIDAdicional).Text = (valorNumerico(Me.Grid.Cell(Renglon, Me.iGyIDAdicional).Text)).ToString

                        If Me.Grid.Rows = Renglon + 1 Then
                            Me.Grid.Rows = Me.Grid.Rows + 1
                            Me.Grid.Cell(Renglon + 1, Me.iGyIDAdicional).Text = (valorNumerico(Me.Grid.Cell(Renglon, Me.iGyIDAdicional).Text) + 1).ToString
                        End If

                        'Me.Grid.Cell(Renglon + 1, Me.igyCodigo).SetFocus()

                        For i = Me.igyDescripcion + 1 To Me.Grid.Cols - 1
                            Me.Grid.Cell(Renglon, i).Locked = True 'Bloqueamos el resto de las columnas

                            If i <> iGyIDAdicional Then
                                Me.Grid.Cell(Renglon, i).Text = "" 'Eliminamos los datos del resto de las columnas
                            End If
                        Next

                        'Me.Grid.Cell(Renglon, Me.iGyGRADO_TOXICIDAD).Text = "0"
                        'Me.Grid.Cell(Renglon, Me.iGyID_SIS_CAT_IMPUESTOS).Text = "0"
                        '
                    End If

                    Me.Totales() 'Por si a un renglón que ya tiene un artículo(con importe) le dan f4
                    oComentario.Dispose()
            End Select

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Sub CalculaPrecioVenta(ByVal iRenglon As Integer, ByVal dMargenUtilidad As Double)
        Const sProcedure As String = ""
        Try
            Dim dPrecioVenta As Decimal = 0
            dPrecioVenta = CDec(Math.Round(CDbl((valorNumericoD(Me.Grid.Cell(iRenglon, Me.igyCostoMercado).Text) * (1 + (dMargenUtilidad / 100)))), 3))
            Me.Grid.Cell(iRenglon, Me.igyPrecioVenta).Text = dPrecioVenta.ToString
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Sub InicializaCostos()
        Const sProcedure As String = "InicializaCostos"
        Try
            Dim i As Integer, sArticulo As String = ""
            For i = 1 To Me.Grid.Rows - 1
                sArticulo = Me.Grid.Cell(i, Me.igyCodigo).Text

                If txtLEN(sArticulo) = True And sArticulo <> "-" Then
                    Dim Precio As Decimal = valorNumericoD(Me.Grid.Cell(i, Me.igyPrecio).Text) 'Si no se convierte a numero primero no copia el texto a la columna costoMercado

                    Me.Grid.Cell(i, Me.igyCostoMercado).Text = Precio.ToString
                    Me.CalculaPrecioVenta(i, valorNumerico(Me.Grid.Cell(i, Me.igyMargenUtilidad).Text))
                End If
            Next
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Sub OcultarControles()
        Try
            If Me.oDocumento.AFECTA_CXP = True Then
                Me.txtFolioOC.Visible = True : Me.lblDisplayFolioOC.Visible = True
                Me.txtFolioProveedor.Visible = True : Me.lblDisplayFolioProveedor.Visible = True
                Me.txtSaldo_MXP.Visible = True : Me.lblDisplaySaldo_MXP.Visible = True
                Me.txtSaldo_USD.Visible = True : Me.lblDisplaySaldo_USD.Visible = True
                Me.BtnActualizaFolioProv.Visible = True
                Me.btnActualizaConcepto.Visible = True
                Me.LblPoliza.Visible = True : Me.lblDilplayPoliza.Visible = True

                If Me.Grid.Cols > 1 Then
                    Me.Grid.Column(Me.igyCuentaContable).Visible = True
                End If
                Me.tsbGrabar.Visible = False
                Me.tsbAplicar.Visible = True
                Me.tpSeries.Enabled = True

                Me.LblDisplayTipoEnvio.Visible = False : Me.CboTipoEnvio.Visible = False
                Me.LblDisplayTransporte.Visible = False : Me.TxtNombreTransporte.Visible = False

                Me.TabControl1.TabPages(2).Enabled = True 'Entradas inventarios
            Else
                Me.txtFolioOC.Visible = False : Me.lblDisplayFolioOC.Visible = False
                Me.txtFolioProveedor.Visible = False : Me.lblDisplayFolioProveedor.Visible = False
                Me.txtSaldo_MXP.Visible = False : Me.lblDisplaySaldo_MXP.Visible = False
                Me.txtSaldo_USD.Visible = False : Me.lblDisplaySaldo_USD.Visible = False
                Me.BtnActualizaFolioProv.Visible = False
                Me.btnActualizaConcepto.Visible = False
                Me.LblPoliza.Visible = False : Me.lblDilplayPoliza.Visible = False

                If Me.Grid.Cols > 1 Then
                    Me.Grid.Column(Me.igyCuentaContable).Visible = False
                End If
                Me.tsbGrabar.Visible = True
                Me.tsbAplicar.Visible = False
                Me.tpSeries.Enabled = False

                Me.LblDisplayTipoEnvio.Visible = True : Me.CboTipoEnvio.Visible = True
                Me.LblDisplayTransporte.Visible = True : Me.TxtNombreTransporte.Visible = True

                Me.TabControl1.TabPages(2).Enabled = False 'Entradas inventarios

                If Empresa_Sistema.MODO_REQUISICIONES_INVENTARIO = False Then
                    Me.LblRequisicion.Visible = False
                    Me.TxtRequisicion.Visible = False
                    Me.btnTraerDetalleRequisicion.Visible = False
                    Me.btnMultiplesRequisiciones.Visible = False
                End If

            End If
        Catch ex As Exception
            HandleError(Me.Name, "OcultarControles", ex)
        End Try
    End Sub

    Private Function SiTieneCuentaContable() As Boolean
        Dim i As Integer
        For i = 1 To Me.Grid.Rows - 1
            If txtLEN(Me.Grid.Cell(i, Me.igyCodigo).Text) = True Then
                If txtLEN(Me.Grid.Cell(i, Me.igyCuentaContable).Text) = False Then
                    SiTieneCuentaContable = False
                    Exit Function
                End If
            End If
        Next
        Return True
    End Function

    Private Function ValidaCuentasContables() As Boolean
        Dim bResultado As Boolean = False
        Const sProcedure As String = "ValidaCuentasContables"
        Dim i As Integer, sCuentaContable As String = ""

        Try
            Dim oCuentas As New Class_CatCuentas

            For i = 1 To Me.Grid.Rows - 1
                If txtLEN(Me.Grid.Cell(i, Me.igyCodigo).Text) = True Then

                    Dim oArticulo As New Class_CatArticulos(Me.Grid.Cell(i, Me.igyCodigo).Text)

                    sCuentaContable = Me.Grid.Cell(i, Me.igyCuentaContable).Text

                    If oArticulo.INVENTARIABLE = "0" Then
                        If txtLEN(sCuentaContable) = True Then

                            If Not (IsNothing(Me.oFormaDetalleCuentas) = True) Then

                                If Me.oFormaDetalleCuentas.ValidaCuentaTengaDetalle(CInt(Me.Grid.Cell(i, Me.iGyIDAdicional).Text)) = True Then
                                    MsgBox("El renglón : " & i & " tiene cuenta directa y detalle de cuentas, no puede tener ambos.", MsgBoxStyle.Exclamation, sProcedure)
                                    Return False
                                End If

                            End If

                            'MsgBox("Quite la cuenta contable del renglón #" & i & " , no se puede tener cuenta directa y también en detalle(la que se establece con el botón)." & vbCrLf & _
                            '       "Revíse el renglón #" & i, MsgBoxStyle.Exclamation, sProcedure)
                            'Return False

                            'Dim oDeudor As New Class_VWCatDeudoresDiversos(sCuentaContable)
                            'If oDeudor.EXISTE = False Then
                            '    MsgBox("El renglón : " & i & " tiene un deudor que no existe.", MsgBoxStyle.Exclamation, sProcedure)
                            '    Return False
                            'End If

                            If sCuentaContable.StartsWith("1") = False Then
                                MsgBox("La cuenta contable del renglón : " & i & " debe ser del rango de las miles(que empiezen con 1)." & vbCrLf &
                                "O debe en vez de poner cuenta, detallar con el botón de centros de costos.", MsgBoxStyle.Exclamation, Me.Name)
                                Return False
                            End If

                            oCuentas = New Class_CatCuentas(sCuentaContable)

                            If oCuentas._Existe = False Then
                                MsgBox("La cuenta contable del renglón : " & i & " no existe.", MsgBoxStyle.Exclamation, sProcedure)
                                Return False
                            Else
                                If oCuentas.ESMAYOR = "1" Then
                                    MsgBox("La cuenta contable del renglón : " & i & " es de mayor.", MsgBoxStyle.Exclamation, sProcedure)
                                    Return False
                                End If
                                'If (Me.Grid.Cell(i, Me.igyCuentaContable).Text Like Empresa_Sistema.CUENTA_CONTABLE_ALMACENES & "*") = False Then
                                '    MsgBox("La cuenta para los artículos inventariables debe de empezar con " & Empresa_Sistema.CUENTA_CONTABLE_ALMACENES & "." & vbCrLf & _
                                '           "Revíse el renglón #" & i, MsgBoxStyle.Exclamation, Me.Text)
                                '    Return False
                                'End If
                            End If

                        Else

                            If IsNothing(Me.oFormaDetalleCuentas) = True Then
                                MsgBox("No ha especificado el detalle de la cuentas contables con el botón." & vbCrLf &
                                       "Revíse el renglón #" & i, MsgBoxStyle.Exclamation, sProcedure)
                                Return False
                            End If

                            If Me.oFormaDetalleCuentas.ValidaCuentaTengaDetalle(CInt(Me.Grid.Cell(i, Me.iGyIDAdicional).Text)) = False Then
                                MsgBox("No ha especificado el detalle de la cuentas contables con el botón." & vbCrLf &
                                       "Revíse el renglón #" & i, MsgBoxStyle.Exclamation, sProcedure)
                                Return False
                            End If
                        End If


                    Else 'Si es inventariable

                        If sCuentaContable.StartsWith("1") = False Then
                            MsgBox("La cuenta contable del renglón : " & i & " debe ser del rango de las miles(que empiezen con 1)." & vbCrLf &
                            "O debe en vez de poner cuenta, detallar con el botón de centros de costos.", MsgBoxStyle.Exclamation, Me.Name)
                            Return False
                        End If

                        oCuentas = New Class_CatCuentas(sCuentaContable)

                        If oCuentas._Existe = False Then
                            MsgBox("La cuenta contable del renglón : " & i & " no existe.", MsgBoxStyle.Exclamation, sProcedure)
                            Return False
                        ElseIf oCuentas.ESMAYOR = "1" Then
                            MsgBox("La cuenta contable del renglón : " & i & " es de mayor.", MsgBoxStyle.Exclamation, sProcedure)
                            Return False
                        ElseIf (Me.Grid.Cell(i, Me.igyCuentaContable).Text Like Empresa_Sistema.CUENTA_CONTABLE_ALMACENES & "*") = False Then
                            MsgBox("La cuenta para los artículos inventariables debe de empezar con " & Empresa_Sistema.CUENTA_CONTABLE_ALMACENES & "." & vbCrLf &
                                   "Revíse el renglón #" & i, MsgBoxStyle.Exclamation, Me.Text)
                            Return False
                        End If

                    End If

                End If
            Next
            bResultado = True
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
        Return bResultado
    End Function

    Private Function EstableceCuentaContableAlmacen() As Boolean
        Try
            Dim oAlmacenes As New Class_CatAlmacenes(Me.CboAlmacen.SelectedValue.ToString), i As Integer, sCuentaContable As String = "", oCuenta As Class_CatCuentas
            Dim oArticulos As Class_CatArticulos

            For i = 1 To Me.Grid.Rows - 1
                If txtLEN(Me.Grid.Cell(i, Me.igyCodigo).Text) = True Then
                    oArticulos = New Class_CatArticulos(Me.Grid.Cell(i, Me.igyCodigo).Text)
                    If oArticulos.INVENTARIABLE = "1" Then
                        sCuentaContable = oAlmacenes.CUENTA_CONTABLE.ToString '+ oArticulos.ObtenerFamiliaArticulo(Me.Grid.Cell(i, Me.igyCodigo).Text).ToString 'Se quitó el nivel de familia dentro de la cuenta de almacenes nov/2020
                        oCuenta = New Class_CatCuentas(sCuentaContable)

                        Me.Grid.Cell(i, Me.igyCuentaContable).Text = sCuentaContable
                        If oCuenta._Existe = True Then
                            Me.Grid.Cell(i, Me.iGyNombreCuentaContable).Text = oCuenta.NOMBRE_CUENTA
                        Else
                            Me.Grid.Cell(i, Me.iGyNombreCuentaContable).Text = ""
                        End If

                    End If
                End If
            Next

            Return True
        Catch ex As Exception
            HandleError(Me.Name, "EstableceCuentaContableAlmacen", ex)
        End Try
    End Function

    Private Function Navegador(ByVal sTipoDeBusqueda As String) As Boolean
        Dim bResultado As Boolean = False
        Try
            Dim iFolio As Integer, sFolio As String, iPosicion As Integer, sFolioParte2 As String
            If txtLEN(Me.txtFolioCompra.Text) = False Then
                If GeneraFolio() = False OrElse txtLEN(Me.txtFolioCompra.Text) = False Then
                    Exit Function
                End If
            End If

            If sTipoDeBusqueda = "Anterior" Then
                iPosicion = Me.txtFolioCompra.Text.IndexOf("-")
                sFolio = Me.txtFolioCompra.Text.Substring(0, iPosicion)
                iFolio = CInt(Strings.Right(Me.txtFolioCompra.Text, Len(Me.txtFolioCompra.Text) - (Len(sFolio) + 1))) ' Me.oVenta.FOLIO_NUMERICO
                iFolio = iFolio - 1
                sFolioParte2 = Format(iFolio, New String(CChar("0"), Me.txtFolioCompra.Text.Substring(3, Me.txtFolioCompra.TextLength - iPosicion - 1).Length))
                sFolio = sFolio + "-" + sFolioParte2 'sFolio + "-" + iFolio.ToString
                Me.txtFolioCompra.Text = sFolio

                If txtLEN(sFolio) = True Then
                    Me.Consultar()
                Else
                    Me.Inicializa()
                    Me.Cambia_Estado(enumEstados.NUEVO)
                    Me.GeneraFolio()
                    Me.txtFolioCompra.Focus()
                End If

            ElseIf sTipoDeBusqueda = "Siguiente" Then
                iPosicion = Me.txtFolioCompra.Text.IndexOf("-")
                sFolio = Me.txtFolioCompra.Text.Substring(0, iPosicion)
                iFolio = CInt(Strings.Right(Me.txtFolioCompra.Text, Len(Me.txtFolioCompra.Text) - (Len(sFolio) + 1))) ' Me.oVenta.FOLIO_NUMERICO
                iFolio = iFolio + 1
                sFolioParte2 = Format(iFolio, New String(CChar("0"), Me.txtFolioCompra.Text.Substring(3, Me.txtFolioCompra.TextLength - iPosicion - 1).Length))
                sFolio = sFolio + "-" + sFolioParte2 'sFolio + "-" + iFolio.ToString
                Me.txtFolioCompra.Text = sFolio

                If txtLEN(sFolio) = True Then
                    Me.Consultar()
                Else
                    Me.Inicializa()
                    Me.Cambia_Estado(enumEstados.NUEVO)
                    Me.GeneraFolio()
                    Me.txtFolioCompra.Focus()
                End If
            End If

            bResultado = True
        Catch ex As Exception
            HandleError(Me.Name, "Navegador", ex)
        End Try

        Return bResultado
    End Function

    Private Sub PasarOrdenACompra()
        Dim sFolioOC As String = Me.txtFolioCompra.Text
        Try
            Me.Inicializa()
            Me.CboDocumento.SelectedValue = "CO" & Usuario.Codigo_Plaza.ToString
            Me.Cambia_Estado(enumEstados.NUEVO)
            Me.txtFolioOC.Text = sFolioOC
            Me.Consultar(True, True)
        Catch ex As Exception
            HandleError(Me.Name, "PasarOrdenACompra", ex)
        End Try
    End Sub

    Private Sub GestionaDetalleCuentas()
        Dim iRenglon As Integer = 0, sArticulo As String = ""
        Try
            iRenglon = Me.Grid.ActiveCell.Row
            sArticulo = Me.Grid.Cell(iRenglon, Me.igyCodigo).Text

            If txtLEN(sArticulo) = False Then
                MsgBox("No ha capturado el artículo.", MsgBoxStyle.Exclamation, Me.Text)
                Return
            End If

            If valorNumerico(Me.Grid.Cell(iRenglon, Me.igyImporte).Text) = 0 Then
                MsgBox("No ha capturado el artículo con su cantidad y precio.", MsgBoxStyle.Exclamation, Me.Text)
                Return
            End If

            Dim oArticulos As New Class_CatArticulos(sArticulo)

            If oArticulos.INVENTARIABLE = "1" Then
                MsgBox("El artículo es inventariable, la cuenta contable se calcula automáticamente.", MsgBoxStyle.Exclamation, Me.Text)
                Return
            End If

            'Solo si esta vacia la crea, para que siga existiendo en memoria ( con hide se oculta en la forma secundaria, para seguir trabajando con ella al volver el control a esta forma)
            If IsNothing(Me.oFormaDetalleCuentas) = True Then
                Me.oFormaDetalleCuentas = New InventariosDetalleCuentasContables(Me.txtFolioCompra.Text)
            End If

            With Me.oFormaDetalleCuentas
                .IDAdicional = CInt(Me.Grid.Cell(iRenglon, Me.iGyIDAdicional).Text) 'iRenglon
                .Importe = valorNumerico(Me.Grid.Cell(iRenglon, Me.igyImporte).Text)
                .txtArticulo.Text = Me.Grid.Cell(iRenglon, Me.igyDescripcion).Text
                .txtCantidad.Text = Me.Grid.Cell(iRenglon, Me.igyCantidad).Text
                .txtCosto.Text = Me.Grid.Cell(iRenglon, Me.igyPrecio).Text
                .txtImporte.Text = FormatImporteContable(.Importe, False)
                .CodigoArticulo = Me.Grid.Cell(iRenglon, Me.igyCodigo).Text
                .ShowDialog()

                'If .TieneDetalleCuentas = True Then
                'If .GestionoRenglon = True Then
                If .ValidaCuentaTengaDetalle(.IDAdicional) Then
                    Me.Grid.Cell(iRenglon, Me.igyCuentaContable).Text = ""
                    Me.Grid.Cell(iRenglon, Me.iGyNombreCuentaContable).Text = "Tiene detalle -->>"
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "GestionaDetalleCuentas", ex)
        End Try
    End Sub

    Private Function EliminaDetalleCuentasContables(ByVal IDAdicional As Integer) As Integer
        Try
            If IsNothing(Me.oFormaDetalleCuentas) = False Then 'Si no esta vacia, osea si existe
                Me.oFormaDetalleCuentas.EliminaRelacion(IDAdicional)
            End If
        Catch ex As Exception
            HandleError(Me.Name, "EliminaDetalleCuentasContables", ex)
        End Try
    End Function

    Private Function ActualizaConcepto() As Boolean
        Try
            If Usuario.ValidaPermisoUsuarioDocumentoConAfectacionInventarios(Me.CboDocumento.SelectedValue.ToString, Me.CboAlmacen.SelectedValue.ToString) = False Then
                MsgBox("El usuario " & Usuario.Nombre_Usuario & " no tiene permiso para realizar el movimiento.", MsgBoxStyle.Information, Me.Text)
                Exit Function
            End If

            Dim sConcepto As String
            sConcepto = InputBox("Proporcione el nuevo concepto de la compra", "Concepto de compra")
            If String.IsNullOrEmpty(sConcepto) Then
                Exit Function
            Else
                Me.oCompras.CONCEPTO = sConcepto.ToUpper
                If Me.oCompras.ActualizaConcepto = True Then
                    MsgBox("Concepto actualizado satisfactoramente.", MsgBoxStyle.Information, Me.Text)
                    Me.TxtConcepto.Text = Me.oCompras.CONCEPTO
                End If
            End If

            Return True

        Catch ex As Exception
            HandleError(Me.Name, "ActualizaConcepto", ex)
        End Try
    End Function

    Private Sub PrepararSeries()
        Try
            'Dim iUnidades As Integer

            If IsNothing(Me.dtSeries) = False AndAlso Me.dtSeries.Rows.Count > 0 Then
                If MsgBox("Hay series ya especificadas, si continua tendrá que recapturar todas." & vbCrLf & "Esta seguro de continuar ?", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    Return
                End If
            End If

            Me.dtSeries = New DataTable("Series")
            With Me.dtSeries
                .Columns.Add("POSICION", GetType(String))
                .Columns.Add("CODIGO_ARTICULO", GetType(String))
                .Columns.Add("DESCRIPCION", GetType(String))
                .Columns.Add("NUMERO_SERIE", GetType(String))
            End With
            Me.dtSeries.AcceptChanges()

            Dim dRow As DataRow

            For i = 1 To Me.Grid.Rows - 1
                If txtLEN(Me.Grid.Cell(i, Me.igyCodigo).Text) = True AndAlso CInt(Me.Grid.Cell(i, Me.igyCantidad).Text) > 0 Then
                    Dim oArticulo As New Class_CatArticulos(Me.Grid.Cell(i, Me.igyCodigo).Text)
                    If oArticulo.Existe = True AndAlso oArticulo.ES_SERIALIZABLE = True AndAlso oArticulo.INVENTARIABLE = "1" Then
                        For j = 1 To CInt(Me.Grid.Cell(i, Me.igyCantidad).Text)
                            dRow = Me.dtSeries.NewRow

                            dRow("POSICION") = i
                            dRow("CODIGO_ARTICULO") = Me.Grid.Cell(i, Me.igyCodigo).Text
                            dRow("DESCRIPCION") = Me.Grid.Cell(i, Me.igyDescripcion).Text
                            dRow("NUMERO_SERIE") = ""

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
            Me.GridSeries.Cols = 5
            Me.FormateaGridSeries()
            'Me.Grid.Cell(1, Me.iGyIDAdicional).Text = "1"
        Catch ex As Exception
            HandleError(Me.Name, "InicializaGridSeries", ex)
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
                .Column(Me.igySerieCodigo).Width = 150
                .Column(Me.igySerieDescripcion).Width = 500
                .Column(Me.igySerieNumeroSerie).Width = 250

                .Cell(0, Me.igySeriePosicion).Text = "Posición"
                .Cell(0, Me.igySerieCodigo).Text = "Código"
                .Cell(0, Me.igySerieDescripcion).Text = "Descripción"
                .Cell(0, Me.igySerieNumeroSerie).Text = "Número de serie"

                .Column(Me.igySeriePosicion).Locked = True
                .Column(Me.igySerieCodigo).Locked = True
                .Column(Me.igySerieDescripcion).Locked = True

                .AutoRedraw = True
                .Refresh()

                .Row(.Rows - 1).Locked = True 'Para bloquear la edición del último renglón
            End With
        Catch ex As Exception
            HandleError(Me.Name, "FormateaGridSeries", ex)
        End Try
    End Sub

    Private Sub GestionaGridSeries(ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            Dim Renglon As Integer = Me.GridSeries.Selection.FirstRow
            Dim Columna As Integer = Me.GridSeries.Selection.FirstCol
            Select Case e.KeyCode
                Case Keys.Return
                    If Columna = Me.igySerieNumeroSerie Then
                        If Renglon + 1 < Me.GridSeries.Rows Then
                            Me.GridSeries.Cell(Renglon + 1, Me.igySerieDescripcion).SetFocus()
                        Else
                            Me.GridSeries.Cell(1, Me.igySerieDescripcion).SetFocus()
                        End If
                    End If

                Case Keys.Delete
                    e.SuppressKeyPress = True
            End Select
        Catch ex As Exception
            HandleError(Me.Name, "GestionaGridSeries", ex)
        End Try
    End Sub

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
                If txtLEN(Me.Grid.Cell(i, Me.igyCodigo).Text) = True AndAlso CInt(Me.Grid.Cell(i, Me.igyCantidad).Text) > 0 Then
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

    Private Function CantidadArticulosSerie(ByVal sCodigoArticulo As String) As Integer
        Dim iArticulosEncontrados As Integer = 0
        Try
            For i = 1 To Me.GridSeries.Rows - 1
                If Me.GridSeries.Cell(i, Me.igySerieCodigo).Text = sCodigoArticulo Then
                    iArticulosEncontrados += 1
                End If
            Next
        Catch ex As Exception
            HandleError(Me.Name, "CantidadArticulosSerie", ex)
        End Try
        Return iArticulosEncontrados
    End Function

    Private Function GestionaArchivoSeries() As Boolean
        Dim bResultado As Boolean = False
        Dim sRutaArchivo As String = "", sTextLine As String = "", sArticulo As String = "", iRenglon As Integer = 0
        Dim iSeriesEstablecidas As Integer = 0, iArticulosEncontrados As Integer = 0, i As Integer = 1, iEstablecidos As Integer = 0
        Try
            'iRenglon = Me.GridSeries.ActiveCell.Row
            iRenglon = Me.GridSeries.Selection.FirstRow

            If iRenglon = 0 Then
                MsgBox("Seleccione un artículo en la pantalla de series.", MsgBoxStyle.Exclamation, Me.Text)
                Return False
            End If

            sArticulo = Me.GridSeries.Cell(iRenglon, Me.igySerieCodigo).Text

            If txtLEN(sArticulo) = False Then
                MsgBox("Seleccione un artículo en la pantalla de series.", MsgBoxStyle.Exclamation, Me.Text)
                Me.tpSeries.Focus()
                Return False
            End If

            sRutaArchivo = Me.SeleccionarArchivo

            If txtLEN(sRutaArchivo) = False Then
                Return False
            End If

            iArticulosEncontrados = Me.CantidadArticulosSerie(sArticulo)

            Using reader As StreamReader = New StreamReader(sRutaArchivo)
                sTextLine = reader.ReadLine

                Do While (Not sTextLine Is Nothing) Or Not (iEstablecidos <= iArticulosEncontrados)
                    If txtLEN(sTextLine) = True Then
                        For i = i To Me.GridSeries.Rows - 1
                            If Me.GridSeries.Cell(i, Me.igySerieCodigo).Text = sArticulo Then
                                Me.GridSeries.Cell(i, Me.igySerieNumeroSerie).Text = sTextLine
                                iEstablecidos += 1
                                i += 1
                                Exit For
                            End If
                        Next
                    End If
                    sTextLine = reader.ReadLine
                Loop
            End Using

        Catch ex As Exception
            HandleError(Me.Name, "GestionaArchivoSeries", ex)
        End Try

        Return bResultado
    End Function

    Private Function SeleccionarArchivo() As String
        Dim sRutaArchivo As String = ""
        Try
            With OpenFileDialog1
                '.InitialDirectory = Me.txtRutaArchivo.Text
                .Filter = "txt files (*.txt)|*.txt"
                '.FilterIndex = 2
                .RestoreDirectory = True
                .FileName = ""
                .Multiselect = False
                .DefaultExt = ".txt"

                If .ShowDialog() = DialogResult.OK Then
                    sRutaArchivo = .FileName
                End If

            End With
        Catch ex As Exception
            HandleError(Me.Name, "Seleccionar", ex)
        End Try

        Return sRutaArchivo
    End Function

    Private Function HaySeriesRepetidas() As Boolean
        Dim RenglonRepetido As Integer

        Try
            Me.dtSeries.AcceptChanges()

            For i = 1 To Me.GridSeries.Rows - 1
                If txtLEN(Me.GridSeries.Cell(i, Me.igySerieCodigo).Text) = True Then
                    For z = i + 1 To Me.GridSeries.Rows - 1
                        If Me.GridSeries.Cell(i, Me.igySerieNumeroSerie).Text = Me.GridSeries.Cell(z, Me.igySerieNumeroSerie).Text Then
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

    Private Function HaySeriesConExistenciasMismoArticulo() As Boolean
        Dim bResultado As Boolean = False, sListaSeries As String = ""
        Try
            'Me.GridSeries.AutoValidate = Windows.Forms.AutoValidate.EnablePreventFocusChange

            If Me.dtSeries.Rows.Count > 0 Then
                For Each dRow In Me.dtSeries.Select("")
                    sListaSeries = sListaSeries & dRow("CODIGO_ARTICULO").ToString & "," & dRow("NUMERO_SERIE").ToString & "|"
                Next
                If txtLEN(sListaSeries) = True Then
                    sListaSeries = sListaSeries.Substring(0, sListaSeries.Length - 1) 'Para quitarle el último pipe que sale sobrando.
                End If

                Dim sResultado As String = Me.oCompras.HaySeriesConExistenciasMismoArticulo(sListaSeries)

                If txtLEN(sResultado) = True Then
                    MsgBox("Hay existencias con las mismas series de los siguientes artículos : " & vbCrLf & sResultado, vbExclamation, Me.Text)
                    Return True
                End If

            End If
        Catch ex As Exception
            HandleError(Me.Name, "HaySeriesConExistenciasMismoArticulo", ex)
        End Try

        Return False
    End Function

    Private Sub CopiarLote()
        Dim sProcedure As String = "CopiarLote"
        Try
            If Me.GridSeries.ActiveCell.Row <= 0 Then
                MsgBox("Debe seleccionar un renglón para copiarle este lote a todos los artículos iguales al seleccionado.", MsgBoxStyle.Exclamation, sProcedure)
                Return
            End If

            Dim sArticulo As String = Me.GridSeries.Cell(Me.GridSeries.ActiveCell.Row, Me.igySerieCodigo).Text

            For i = 1 To Me.GridSeries.Rows - 1
                If Me.GridSeries.Cell(i, Me.igySerieCodigo).Text = sArticulo Then
                    Me.GridSeries.Cell(i, igySerieNumeroSerie).Text = Me.txtLote.Text
                End If
            Next

            MsgBox("Listo", MsgBoxStyle.Information, sProcedure)
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Function AgregarXML() As Boolean
        Dim bResultado As Boolean = False
        Dim sProcedure As String = "AgregarXML"
        Dim oPoliza As Class_Contabilidad_Poliza_Global

        Try
            oPoliza = New Class_Contabilidad_Poliza_Global(Me.txtFolioCompra.Text)
            If oPoliza.Existe = False Then
                Return False
            End If

            Select Case Me.tsbAgregarXML.Text
                Case "Agregar XML"
                    Dim sRutaXML As String = oPoliza.BuscarXML(New Class_CatProveedores(Me.txtProveedor.Text).RFC, True)

                    If txtLEN(sRutaXML) = True Then
                        bResultado = oPoliza.AgregarXMLPDF(sRutaXML, "") 'Mandamos sin pdf
                    End If

                    If bResultado = True Then
                        Me.tsbAgregarXML.Text = "Ver XML"
                    End If

                Case "Ver XML"
                    Dim sUUID As String = Me.oCompras.UUID

                    If txtLEN(sUUID) = False Then
                        MsgBox("No se encontró el UUID de la compra", MsgBoxStyle.Exclamation, sProcedure)
                        Return False
                    End If

                    bResultado = oPoliza.AbrirXML(sUUID)

            End Select

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        Finally
            oPoliza = Nothing
            Application.DoEvents()
        End Try

        Return bResultado
    End Function

    Private Function AgregarPDF() As Boolean
        Dim bResultado As Boolean = False
        Dim sProcedure As String = "AgregarPDF"
        Dim oPoliza As Class_Contabilidad_Poliza_Global

        Try
            Dim sUUID As String = Me.oCompras.UUID
            Dim sRutaPDF As String = ""

            If txtLEN(sUUID) = False Then
                MsgBox("Esta compra no tiene relacionado ningún XML.", vbExclamation, sProcedure)
                Return False
            End If

            oPoliza = New Class_Contabilidad_Poliza_Global(Me.txtFolioCompra.Text)
            If oPoliza.Existe = False Then
                Return False
            End If

            Select Case Me.tsbAgregarPDF.Text
                Case "Agregar PDF"
                    sRutaPDF = oPoliza.BuscarPDF()

                    If txtLEN(sRutaPDF) = True Then
                        bResultado = oPoliza.AgregarPDF(sUUID, sRutaPDF)
                    End If

                    If bResultado = True Then
                        Me.tsbAgregarPDF.Text = "Ver PDF"
                    End If

                    oPoliza = Nothing

                Case "Ver PDF"
                    oPoliza.AbrirPDF(sUUID)
            End Select

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        Finally
            oPoliza = Nothing
            Application.DoEvents()
        End Try

        Return bResultado
    End Function

    Private Sub ObtenerTipoCambioDia()
        Const sProcedure As String = "ObtenerTipoCambioDia"
        Try
            If Me.Estado = enumEstados.NUEVO Or Me.Estado = enumEstados.GRABADO Then
                Dim oTipoCambio As New Class_CatTiposCambio(Me.DtpFecha.Value)
                Me.txtTipoCambio.Text = "0"

                If oTipoCambio.Existe AndAlso oTipoCambio.TIPO_DE_CAMBIO > 0 Then
                    Me.txtTipoCambio.Text = oTipoCambio.TIPO_DE_CAMBIO.ToString
                Else
                    If Me.cboMoneda.SelectedIndex = 1 Then
                        MsgBox("No se ha capturado el tipo de cambio del día.", MsgBoxStyle.Exclamation, Me.Text)
                    End If
                End If
            End If
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Sub GestionaMoneda(Optional ByVal bInicializa As Boolean = False) 'creado falta usar, la idea es que del consultar no inicializa, pero si del cambiar en el combo
        Const sProcedure As String = "GestionaMoneda"
        Try
            If bInicializa = True Then 'De momento no se permite tener lleno el grid y cambiar de moneda, es mas complicado tener que andar inicializando los valores separados (globales grid) de monedas alternas.
                Me.InicializaGrid()
                Me.InicializaGridSeries()
                Me.Totales()
            End If

            If Me.cboMoneda.Text = "USD" Then
                Me.txtTipoCambio.Visible = True : Me.LblDisplayTipoCambio.Visible = True
                Me.gbUSD.Visible = True

                If Me.Estado = enumEstados.NUEVO Or Me.Estado = enumEstados.GRABADO Then
                    Me.txtTipoCambio.Enabled = True
                End If

                If Me.oDocumento.AFECTA_CXP = True Then
                    Me.txtSaldo_USD.Visible = True : Me.lblDisplaySaldo_USD.Visible = True
                    Me.txtSaldo_MXP.Visible = True : Me.lblDisplaySaldo_MXP.Visible = True
                Else
                    Me.txtSaldo_USD.Visible = False : Me.lblDisplaySaldo_USD.Visible = False
                    Me.txtSaldo_MXP.Visible = False : Me.lblDisplaySaldo_MXP.Visible = False
                End If

                If Me.bCrearonColumnas = True Then 'Esta esto porque por cuestiones de eventos se lanza primero este antes de inicializar la 1era vez la forma.
                    'Estas 3 columnas son editables, y se gestiona su bloqueo/desbloqueo según el tipo de moneda
                    Me.Grid.Column(Me.igyPrecio).Locked = True 'Se bloquea el precio en MXM
                    Me.Grid.Column(Me.igyPRECIO_USD).Locked = False 'Se habilita el precio en USD

                    Me.Grid.Column(Me.igyPRECIO_USD).Visible = True
                    Me.Grid.Column(Me.igyIMPORTE_USD).Visible = True
                    Me.Grid.Column(Me.igyImporte).Visible = False
                End If

                Me.txtIVA.ReadOnly = True 'Si se está en modo USD no será editable el de MXN
                Me.txtIVA_USD.ReadOnly = False

                If Empresa_Sistema.TIPO_CAMBIO_POR_DIA = True Then
                    Me.ObtenerTipoCambioDia()
                End If

            Else 'Es moneda en MXN o esta en blanco
                Me.txtTipoCambio.Text = "0"
                Me.txtTipoCambio.Visible = False : Me.txtTipoCambio.Enabled = False : Me.LblDisplayTipoCambio.Visible = False
                Me.gbUSD.Visible = False
                If Me.oDocumento.AFECTA_CXC = True Then
                    Me.txtSaldo_USD.Visible = False : Me.lblDisplaySaldo_USD.Visible = False
                    Me.txtSaldo_MXP.Visible = True : Me.lblDisplaySaldo_MXP.Visible = True
                Else
                    Me.txtSaldo_USD.Visible = False : Me.lblDisplaySaldo_USD.Visible = False
                    Me.txtSaldo_MXP.Visible = False : Me.lblDisplaySaldo_MXP.Visible = False
                End If

                If Me.bCrearonColumnas = True Then
                    'Estas 3 columnas son editables, y se gestiona su bloqueo/desbloqueo según el tipo de moneda
                    Me.Grid.Column(Me.igyPrecio).Locked = False 'Se habilita el precio en MXN
                    Me.Grid.Column(Me.igyPRECIO_USD).Locked = True 'Se bloquea el precio en USD

                    Me.Grid.Column(Me.igyPRECIO_USD).Visible = False
                    Me.Grid.Column(Me.igyIMPORTE_USD).Visible = False
                    Me.Grid.Column(Me.igyImporte).Visible = True
                End If

                Me.txtIVA.ReadOnly = False 'Si se está en modo MXN no será editable el de USD
                Me.txtIVA_USD.ReadOnly = True

                For i As Integer = 1 To Me.Grid.Rows - 1
                    Me.Grid.Cell(i, Me.igyPRECIO_USD).Text = "0"
                    Me.Grid.Cell(i, Me.igyIMPORTE_USD).Text = "0"
                    Me.Grid.Cell(i, Me.igyIMPUESTO_IMPORTE_USD).Text = "0"
                    Me.Grid.Cell(i, Me.igyIEPS_UNITARIO_USD).Text = "0"
                    Me.Grid.Cell(i, Me.igyIEPS_IMPORTE_USD).Text = "0"
                    Me.Grid.Cell(i, Me.igyBASE_IEPS_USD).Text = "0"
                    Me.Grid.Cell(i, Me.igyBASE_IVA_USD).Text = "0"
                Next

            End If

            'Me.Totales()
            'Me.TotalesUSD()
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Function ValidaDisponiblesOCaCO() As Boolean
        Const sProcedure As String = "ValidaDisponiblesOCaCO"
        Try
            Dim i As Integer
            For i = 1 To Grid.Rows - 1
                If txtLEN(Me.Grid.Cell(i, Me.igyCodigo).Text) = True Then
                    If Me.oCompras.ValidaCantidadDisponibleArticulo(CInt(Me.Grid.Cell(i, Me.igyIdArticulo).Text), CDbl(Me.Grid.Cell(i, Me.igyCantidad).Text)) = False Then
                        MsgBox("La cantidad debe de ser menor al disponible de la orden de compra en el renglón #" & i.ToString, MsgBoxStyle.Exclamation, sProcedure)
                        Me.Grid.Cell(i, Me.igyCantidad).SetFocus()
                        Return False
                    End If
                End If
            Next i

            Return True
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Function

    Private Function ValidaDisponiblesEntradaOC() As Boolean
        Const sProcedure As String = "ValidaDisponiblesEntradaOC"
        Try
            Dim i As Integer
            For i = 1 To Grid.Rows - 1
                If txtLEN(Me.Grid.Cell(i, Me.igyCodigo).Text) = True Then
                    If Me.oCompras.ValidaCantidadDisponibleArticuloInventario(CInt(Me.Grid.Cell(i, Me.igyID_INVENTARIO_MOVIMIENTOS_DETALLE_ENTRADA).Text), CDbl(Me.Grid.Cell(i, Me.igyCantidad).Text)) = False Then
                        MsgBox("La cantidad debe de ser menor al disponible de la entrada por recepión en el renglón #" & i.ToString, MsgBoxStyle.Exclamation, sProcedure)
                        Me.Grid.Cell(i, Me.igyCantidad).SetFocus()
                        Return False
                    End If
                End If
            Next i

            Return True
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Function

    Private Function TraerTodasEntradasInventarios() As Boolean
        Const sProcedure As String = "TraerTodasEntradasInventarios"
        Try
            If txtLEN(Me.txtFolioOC_Inventarios.Text) = False Then
                MsgBox("Capture el folio de la orden de compra.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            Dim oOrdenCompraLocal As New Class_Compras_Global(Me.txtFolioOC_Inventarios.Text, "OC" & Usuario.Codigo_Plaza.ToString)

            If oOrdenCompraLocal.Existe = False Then
                MsgBox("La orden de compra indicada no existe.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            'La 1era vez el proveedor va estar en blanco, desde la segunda vez ya estará cargado con el proveedor de la 1er oc agregada.
            If txtLEN(Me.txtProveedor.Text) = False Then
                Me.txtProveedor.Text = oOrdenCompraLocal.CODIGO_PROVEEDOR
                Me.lblProveedor.Text = New Class_CatProveedores(Me.txtProveedor.Text).Nombre_Proveedor
                Me.txtPlazo.Text = New Class_CatProveedores(Me.txtProveedor.Text).Plazo.ToString
            End If

            If oOrdenCompraLocal.CODIGO_PROVEEDOR <> Me.txtProveedor.Text Then
                MsgBox("El proveedor de la orden de compra no es igual al de la compra que esta elaborando.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            Me.cboMoneda.SelectedValue = oOrdenCompraLocal.CODIGO_MONEDA

            If Me.TieneAgregadasEntradasInventario() = False Then
                Me.CboAlmacen.SelectedValue = oOrdenCompraLocal.CODIGO_ALMACEN
                Me.cboMoneda.Text = oOrdenCompraLocal.CODIGO_MONEDA
            Else
                If oOrdenCompraLocal.CODIGO_ALMACEN <> Me.CboAlmacen.SelectedValue.ToString Then
                    MsgBox("El almacén de la orden de compra no es igual al de la compra que esta elaborando.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If
            End If

            Me.lstEntradasInventarios.Items.Clear()
            For Each dRow As DataRow In Me.oCompras.ObtieneEntradasOC(Me.txtFolioOC_Inventarios.Text).Rows
                Dim sFolioEntrada As String = String.Format("{0},{1}", dRow("FOLIO_MOVIMIENTO_INVENTARIO").ToString, dRow("FECHA").ToString)

                Dim bYaExiste As Boolean = False
                For Each i In lstEntradasInventarios.Items
                    If i.ToString = sFolioEntrada Then
                        MsgBox("Ya existe en el listado el folio " & sFolioEntrada, vbExclamation, sProcedure)
                        bYaExiste = True
                    End If
                Next
                If bYaExiste = False Then
                    Me.lstEntradasInventarios.Items.Add(sFolioEntrada)
                End If
            Next

            Me.txtFolioOC_Inventarios.Text = ""
            Me.txtFolioOC_Inventarios.Focus()

            Return True
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Function

    Private Sub InicializaGridEntradas()
        Const sProcedure As String = "InicializaGridEntradas"
        Try
            Me.GridEntradas.DataSource = Nothing
            FG_Grid_Limpiar(Me.GridEntradas)
            Me.GridEntradas.Rows = 2
            Me.GridEntradas.Cols = 6
            Me.FormateaGridEntradas()
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Sub FormateaGridEntradas()
        Const sProcedure As String = "FormateaGridEntradas"
        Try
            With Me.GridEntradas
                .AutoRedraw = False

                '.DefaultFont = New Font("Tahoma", 8)
                .DisplayFocusRect = False
                '.DisplayDateTimeMask = True
                '.ExtendLastCol = True
                .DrawMode = FlexCell.DrawModeEnum.OwnerDraw
                .BorderStyle = FlexCell.BorderStyleEnum.FixedSingle
                .FixedRowColStyle = FlexCell.FixedRowColStyleEnum.Flat

                .Column(Me.igyGridEFolioEntrada).Width = 100
                .Column(Me.igyGridEFechaEntrada).Width = 80
                .Column(Me.igyGridEEstaCancelado).Width = 100
                .Column(Me.igyGridETotal).Width = 80
                .Column(Me.igyGridEFlete).Width = 80

                .Cell(0, Me.igyGridEFolioEntrada).Text = "Entrada"
                .Cell(0, Me.igyGridEFechaEntrada).Text = "Fecha"
                .Cell(0, Me.igyGridEEstaCancelado).Text = "Estatus"
                .Cell(0, Me.igyGridETotal).Text = "Total"
                .Cell(0, Me.igyGridEFlete).Text = "Flete"

                .Column(Me.igyGridEFolioEntrada).Locked = True
                .Column(Me.igyGridEFechaEntrada).Locked = True
                .Column(Me.igyGridEEstaCancelado).Locked = True
                .Column(Me.igyGridETotal).Locked = True
                .Column(Me.igyGridEFlete).Locked = True

                .Column(Me.igyGridETotal).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
                .Column(Me.igyGridETotal).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.igyGridETotal).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
                .Column(Me.igyGridETotal).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.igyGridEFlete).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
                .Column(Me.igyGridEFlete).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.igyGridEFlete).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
                .Column(Me.igyGridEFlete).Alignment = FlexCell.AlignmentEnum.RightCenter

                .AutoRedraw = True
                .Refresh()

                .Row(.Rows - 1).Locked = True 'Para bloquear la edición del último renglón
            End With
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Function TieneAgregadasEntradasInventario() As Boolean
        Const sProcedure As String = "TieneAgregadasEntradasInventario"
        Try
            For i As Integer = 1 To Me.GridEntradas.Rows - 1
                If txtLEN(Me.GridEntradas.Cell(i, Me.igyGridEFolioEntrada).Text) = True Then
                    Return True
                End If
            Next
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
        Return False
    End Function

    Private Function AgregarTodasEntradasInventarios() As Boolean
        Const sProcedure As String = "AgregarTodasEntradasInventarios"
        Try
            Dim sFolioEntrada As String = "", sFecha As String = ""

            If Me.lstEntradasInventarios.Items.Count = 0 Then
                MsgBox("No hay ninguna entrada en el listado.", vbExclamation, sProcedure)
                Return False
            End If

            For Each i In Me.lstEntradasInventarios.Items
                sFolioEntrada = Split(i.ToString, ",")(0).ToString
                For j As Integer = 1 To Me.GridEntradas.Rows - 1
                    If sFolioEntrada = Me.GridEntradas.Cell(j, Me.igyGridEFolioEntrada).Text Then
                        MsgBox("La entrada " & sFolioEntrada & " ya se agregó al listado.", vbExclamation, sProcedure)
                        Return False
                    End If
                Next
            Next

            For Each i In Me.lstEntradasInventarios.Items
                Dim oEntrada As New Class_Inventarios_Global(sFolioEntrada)

                sFolioEntrada = Split(i.ToString, ",")(0).ToString
                sFecha = Split(i.ToString, ",")(1).ToString

                Me.GridEntradas.Rows += 1
                Me.GridEntradas.Cell(Me.GridEntradas.Rows - 2, Me.igyGridEFolioEntrada).Text = sFolioEntrada
                Me.GridEntradas.Cell(Me.GridEntradas.Rows - 2, Me.igyGridEFechaEntrada).Text = sFecha
                Me.GridEntradas.Cell(Me.GridEntradas.Rows - 2, Me.igyGridEEstaCancelado).Text = IIf(oEntrada.ESTA_CANCELADO = "1", "CANCELADO", "ACTIVO").ToString
                Me.GridEntradas.Cell(Me.GridEntradas.Rows - 2, Me.igyGridETotal).Text = oEntrada.COSTO_TOTAL_BASE.ToString
                Me.GridEntradas.Cell(Me.GridEntradas.Rows - 2, Me.igyGridEFlete).Text = oEntrada.FLETE_TOTAL.ToString
            Next

            If Me.GeneraGridArticulosEntradasInventarios() = True Then
                Me.lstEntradasInventarios.Items.Clear()
                Return True
            End If

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Function

    Private Function AgregarSeleccionadaEntradasInventarios() As Boolean
        Const sProcedure As String = "AgregarSeleccionadaEntradasInventarios"
        Try
            Dim sFolioEntrada As String = "", sFecha As String = ""

            If Me.lstEntradasInventarios.Items.Count = 0 Then
                MsgBox("No hay ninguna entrada en el listado.", vbExclamation, sProcedure)
                Return False
            End If

            If IsNothing(Me.lstEntradasInventarios.SelectedItem) = True Then
                MsgBox("Falta que seleccione alguna entrada.", vbExclamation, sProcedure)
                Return False
            End If

            sFolioEntrada = Split(Me.lstEntradasInventarios.SelectedItem.ToString, ",")(0).ToString
            sFecha = Split(Me.lstEntradasInventarios.SelectedItem.ToString, ",")(1).ToString

            For j As Integer = 1 To Me.GridEntradas.Rows - 1
                If sFolioEntrada = Me.GridEntradas.Cell(j, Me.igyGridEFolioEntrada).Text Then
                    MsgBox("La entrada " & sFolioEntrada & " ya se agregó al listado.", vbExclamation, sProcedure)
                    Return False
                End If
            Next

            Dim oEntrada As New Class_Inventarios_Global(sFolioEntrada)

            Me.GridEntradas.Rows += 1
            Me.GridEntradas.Cell(Me.GridEntradas.Rows - 2, Me.igyGridEFolioEntrada).Text = sFolioEntrada
            Me.GridEntradas.Cell(Me.GridEntradas.Rows - 2, Me.igyGridEFechaEntrada).Text = sFecha
            Me.GridEntradas.Cell(Me.GridEntradas.Rows - 2, Me.igyGridEEstaCancelado).Text = IIf(oEntrada.ESTA_CANCELADO = "1", "CANCELADO", "ACTIVO").ToString
            Me.GridEntradas.Cell(Me.GridEntradas.Rows - 2, Me.igyGridETotal).Text = oEntrada.COSTO_TOTAL_BASE.ToString
            Me.GridEntradas.Cell(Me.GridEntradas.Rows - 2, Me.igyGridEFlete).Text = oEntrada.FLETE_TOTAL.ToString

            If Me.GeneraGridArticulosEntradasInventarios() = True Then
                Me.lstEntradasInventarios.Items.RemoveAt(Me.lstEntradasInventarios.SelectedIndex)
                Return True
            End If

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Function

    Private Function GeneraGridArticulosEntradasInventarios() As Boolean
        Const sProcedure As String = "GeneraGridArticulosEntradasInventarios"
        Try
            Dim i As Integer = 0, sFolioEntrada As String = "", sListaFoliosEntradas As String = ""

            Me.InicializaGrid()
            Me.InicializaGridSeries()
            Me.Totales()

            Me.Grid.Rows = 1 'Porque al inicializar tiene 2

            For i = 1 To Me.GridEntradas.Rows - 1
                sFolioEntrada = Me.GridEntradas.Cell(i, Me.igyGridEFolioEntrada).Text

                If txtLEN(sFolioEntrada) = True Then
                    sListaFoliosEntradas &= sFolioEntrada & "|"
                End If
            Next

            Dim oInventarios As New Class_Inventarios_Global, dTabla As New DataTable

            'Me.Grid.DataSource = oInventarios.ObtenerDetalleDisponiblesEntradasPorOrdenCompra(sListaFoliosEntradas)
            dTabla = oInventarios.ObtenerDetalleDisponiblesEntradasPorOrdenCompra(sListaFoliosEntradas)

            Me.Grid.AutoRedraw = False

            For Each dRow As DataRow In dTabla.Rows
                Me.Grid.AddItem(
                dRow("CODIGO_ARTICULO").ToString & Chr(9) &
                dRow("DESCRIPCION").ToString & Chr(9) &
                dRow("CANTIDAD").ToString & Chr(9) &
                dRow("PRECIO").ToString & Chr(9) &
                dRow("PRECIO_USD").ToString & Chr(9) &
                dRow("COSTO").ToString & Chr(9) &
                dRow("UNIDAD_VENTA").ToString & Chr(9) &
                dRow("IMPUESTO_PORCENTAJE").ToString & Chr(9) &
                dRow("IMPORTE").ToString & Chr(9) &
                dRow("IMPORTE_USD").ToString & Chr(9) &
                dRow("MARGEN_UTILIDAD").ToString & Chr(9) &
                dRow("COSTO_MERCADO").ToString & Chr(9) &
                dRow("PRECIO_VENTA").ToString & Chr(9) &
                dRow("CUENTA_CONTABLE").ToString & Chr(9) &
                dRow("IMPUESTO_IMPORTE").ToString & Chr(9) &
                dRow("IMPUESTO_IMPORTE_USD").ToString & Chr(9) &
                dRow("ID_COMPRA_DETALLE").ToString & Chr(9) &
                dRow("NOMBRE_CUENTA").ToString & Chr(9) &
                dRow("Boton").ToString & Chr(9) &
                dRow("ID_ADICIONAL").ToString & Chr(9) &
                dRow("IEPS_PORCENTAJE").ToString & Chr(9) &
                dRow("IEPS_UNITARIO").ToString & Chr(9) &
                dRow("IEPS_UNITARIO_USD").ToString & Chr(9) &
                dRow("IEPS_IMPORTE").ToString & Chr(9) &
                dRow("IEPS_IMPORTE_USD").ToString & Chr(9) &
                dRow("BASE_IEPS").ToString & Chr(9) &
                dRow("BASE_IEPS_USD").ToString & Chr(9) &
                dRow("BASE_IVA").ToString & Chr(9) &
                dRow("BASE_IVA_USD").ToString & Chr(9) &
                dRow("ID_INVENTARIO_MOVIMIENTOS_DETALLE").ToString & Chr(9) &
                dRow("ID_REQUISICION_DETALLE").ToString & Chr(9) &
                dRow("ES_REQUISICION").ToString & Chr(9))
            Next

            Me.FormateaGrid()
            Me.GestionaMoneda()

            Me.Totales()

            If Empresa_Sistema.CONTROL_COSTOS_COMPRAS = True Then
                Me.InicializaCostos()
            End If

            Me.EstableceCuentaContableAlmacen()

            Me.chkEsInventariable.Checked = True
            Me.chkEsInventariable.Enabled = False 'Lo bloqueamos para que no haya hack

            Return True
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        Finally
            Me.Grid.AutoRedraw = True
            Me.Grid.Refresh()
        End Try
    End Function

    Private Sub BorrarTodasEntradasInventarios()
        Const sProcedure As String = "BorrarTodasEntradasInventarios"
        Try
            Me.txtFolioOC_Inventarios.Text = ""
            Me.lstEntradasInventarios.Items.Clear()
            Me.InicializaGrid()
            Me.InicializaGridSeries()
            Me.InicializaGridEntradas()
            Me.Totales()
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Function ValidaQueTodosSeanNoInventariables(ByVal bEnviarMsg As Boolean) As Boolean
        Const sProcedure As String = "ValidaQueTodosSeanNoInventariables"
        Try
            Dim i As Integer, sArticulo As String = ""
            For i = 1 To Me.Grid.Rows - 1
                sArticulo = Me.Grid.Cell(i, Me.igyCodigo).Text
                If txtLEN(sArticulo) = True And sArticulo <> "-" Then '"-" es para comentarios
                    Dim oArticulo As New Class_CatArticulos(sArticulo)
                    If oArticulo.INVENTARIABLE = "1" Then 'Con un artículo que sea inventariable podemos decir de inmediato que no todos son no inventariables.
                        If bEnviarMsg = True Then
                            MsgBox("El artículo del renglón #" & i.ToString & " es inventariable.", vbExclamation, sProcedure)
                        End If
                        Return False
                    End If
                End If
            Next i

            Return True
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Function

    Private Function RecepcionarEntrada() As Boolean
        Const sProcedure As String = "RecepcionarEntrada"
        Try
            Dim sFolioOC As String = Me.txtFolioCompra.Text

            If Me.chkEsInventariable.Checked = False Then
                MsgBox("Esta orden no es inventariable.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            If Empresa_Sistema.MODO_REQUISICIONES_INVENTARIO And txtLEN(Me.TxtRequisicion.Text) AndAlso oCompras.ESTATUS <> "P" Then
                MsgBox("Las ordenes de compra con requisición deben estar pedidas para poder recibir la entrada de almacén.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            Dim oInventario As New Inventarios_Movimientos
            oInventario.StartPosition = FormStartPosition.CenterScreen

            oInventario.LlamadoExteriorRecepcionarEntradaOrdenCompra = True
            oInventario.CodigoDocumentoParaGrabar = "ER" 'ER=ENTRADA RECEPCION COMPRA
            oInventario.FolioOrdenCompra = Me.txtFolioCompra.Text
            oInventario.CodigoAlmacenOrdenCompra = Me.CboAlmacen.SelectedValue.ToString
            oInventario.Moneda = Me.cboMoneda.SelectedValue.ToString
            'oInventario.TipoCambio = valorNumericoD(Me.txtTipoCambio.Text)

            oInventario.ShowDialog()
            oInventario.Visible = False

            If oInventario.AplicadoExterior = True Then 'Si se aplicó la entrada de inventarios, simulamos que el usuario va capturar la factura(compra) precargando los datos.
                Me.Inicializa()
                Me.CboDocumento.SelectedValue = "CO" & Usuario.Codigo_Plaza.ToString
                Me.Cambia_Estado(enumEstados.NUEVO)

                If Empresa_Sistema.TIPO_CAMBIO_POR_DIA Then
                    Me.ObtenerTipoCambioDia()
                End If

                Me.txtFolioOC_Inventarios.Text = sFolioOC
                If Me.TraerTodasEntradasInventarios() = True Then
                    Me.AgregarTodasEntradasInventarios()
                End If
                Me.TabControl1.SelectedIndex = 0

                Dim sender As New Object, e As New EventArgs
            End If

            oInventario.Dispose()

            Return True
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Function

    Private Function PedirOrdenCompra() As Boolean
        Const sProcedure As String = "PedirOrdenCompra"
        Try
            Dim sFolioOC As String = Me.txtFolioCompra.Text

            'If txtLEN(Me.TxtRequisicion.Text) = False Then
            '    MsgBox("La orden de compra no tiene requisición.", MsgBoxStyle.Exclamation, sProcedure)
            '    Return False
            'End If

            If Me.ValidaEsRequisicion() = False Then
                MsgBox("La orden de compra no tiene requisción.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            If Me.chkEsInventariable.Checked = False Then
                MsgBox("Esta orden no es inventariable.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            If Me.oCompras.ESTATUS = "P" Then
                MsgBox("La orden de compra ya esta pedida.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            If Usuario.ValidaPermisoUsuarioDocumentoSinAfectacionInventarios(Me.CboDocumento.SelectedValue.ToString) = False Then
                MsgBox("El usuario " & Usuario.Nombre_Usuario & " no tiene permiso para realizar el movimiento.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            'Me.oRequisicion = New Class_Requisiciones_Global(Me.TxtRequisicion.Text)

            '***Ya no se necesitara preguntar por el estatus de la requisicion, porque descontara de las requisiciones disponibles, se preguntara en el ValidaDisponiblesRequisicion() ***
            'If oRequisicion.ESTATUS = "A" Then
            '    If MsgBox("La requisición " & Me.TxtRequisicion.Text & " ya no tiene disponible, desea pedir la orden de compra ?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "Pedir orden de compra") = MsgBoxResult.No Then
            '        Return False
            '    End If
            'End If

            'Preguntará si quieren continuar y pedir la oc aunque no haya disponible suficiente
            If Me.ValidaDisponiblesRequisicion(True) = False Then
                Return False
            End If

            'Aqui afectar las requisiciones
            'If Me.oCompras.AfectaRequisicionesOrdenCompra() = False Then
            If Me.oCompras.AfectaRequisicionesOrdenCompra("PEDIR_OC") = False Then
                MsgBox("Error al tratar de afectar el disponible de las requisiciones de inventario.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            MsgBox("Pedido realizado satisfactoriamente.", MsgBoxStyle.Information, sProcedure)
            Return True

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Function

    Private Function EditarOrdenCompra() As Boolean
        Const sProcedure As String = "EditarOrdenCompra"
        Try
            Dim sFolioOC As String = Me.txtFolioCompra.Text

            If txtLEN(Me.TxtRequisicion.Text) = False Then
                MsgBox("La orden de compra no tiene requisición.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            If Me.chkEsInventariable.Checked = False Then
                MsgBox("Esta orden no es inventariable.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            If Me.oCompras.ESTATUS = "G" Then
                MsgBox("La orden de compra ya esta editable.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            If Usuario.ValidaPermisoUsuarioDocumentoSinAfectacionInventarios(Me.CboDocumento.SelectedValue.ToString) = False Then
                MsgBox("El usuario " & Usuario.Nombre_Usuario & " no tiene permiso para realizar el movimiento.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            'De momento sólo dejará editar la oc si todos los renglones tiene intacto su disponible.
            If Me.oCompras.TieneDisponiblesIncompletos() = True Then
                MsgBox("Esta orden de compra no tiene completas sus cantidades disponibles, no podrá editarla.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            'Aqui afectar las requisiciones
            If Me.oCompras.AfectaRequisicionesOrdenCompra("EDITAR_OC") = False Then
                Return False
            End If

            MsgBox("OC lista para ser editada.", MsgBoxStyle.Information, sProcedure)
            Return True

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Function

    Private Sub TraerDetalleRequisicion()
        Const sProcedure As String = "TraerDetalleRequisicion"
        Try
            Me.InicializaGrid()

            If txtLEN(Me.TxtRequisicion.Text) = False Then
                Exit Sub
            End If

            Me.oRequisicion = New Class_Requisiciones_Global(Me.TxtRequisicion.Text)

            If Me.oRequisicion.Existe = False Then
                MsgBox("El folio de requisición no existe.", MsgBoxStyle.Exclamation, sProcedure)
                Exit Sub
            End If

            Me.CboAlmacen.SelectedValue = oRequisicion.CODIGO_ALMACEN

            Dim dTable As DataTable = oRequisicion.ObtenerDetalleParaOrdenCompra()
            Dim i As Integer = 1
            For Each dRow As DataRow In dTable.Rows
                With Me.Grid
                    .Cell(i, Me.igyCodigo).Text = dRow("CODIGO_ARTICULO").ToString
                    .Cell(i, Me.igyDescripcion).Text = dRow("DESCRIPCION").ToString
                    .Cell(i, Me.igyCantidad).Text = dRow("DISPONIBLE").ToString
                    .Cell(i, Me.igyPrecio).Text = "0"
                    .Cell(i, Me.igyPRECIO_USD).Text = "0"
                    .Cell(i, Me.igyUnidad).Text = dRow("UNIDAD_VENTA").ToString
                    .Cell(i, Me.igyImpuestoPorcentaje).Text = dRow("IMPUESTO_PORCENTAJE").ToString
                    .Cell(i, Me.igyIEPS_PORCENTAJE).Text = dRow("IEPS_PORCENTAJE").ToString
                    '.Cell(i, Me.igyIDRequisicionDetalle).Text = dRow("ID_REQUISICION_DETALLE").ToString 
                    .Cell(i, Me.iGyIDAdicional).Text = i.ToString
                    .Cell(i, Me.igyEsRequisicion).Text = "1"
                End With

                Me.Grid.Rows += 1
                i += 1
            Next

            Me.Grid.Column(Me.igyDescripcion).Locked = True
            Me.Grid.Column(Me.igyUnidad).Locked = True

            Me.Totales()

            If Me.cboMoneda.Text = "USD" Then
                Me.Grid.Column(Me.igyPrecio).Locked = True
                Me.Grid.Cell(1, Me.igyPRECIO_USD).SetFocus()
            Else
                Me.Grid.Cell(1, Me.igyPrecio).SetFocus()
            End If

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Sub TraerDetalleMultiplesRequisiciones()
        Const sProcedure As String = "TraerDetalleMultiplesRequisiciones"
        Dim dTable As DataTable
        Try
            'Primero abrir forma de articulos requeridos
            Dim R As New RequisicionesDetalleOrdenCompra

            R.CodigoAlmacen = Me.CboAlmacen.SelectedValue.ToString
            R.ShowDialog()

            If R.Agregado = False Then
                Exit Sub
            End If

            dTable = R.dArticulosRequeridos

            R.Dispose()

            Me.InicializaGrid()

            Dim i As Integer = 1
            For Each dRow As DataRow In dTable.Rows
                With Me.Grid
                    .Cell(i, Me.igyCodigo).Text = dRow("CODIGO_ARTICULO").ToString
                    .Cell(i, Me.igyDescripcion).Text = dRow("DESCRIPCION").ToString
                    .Cell(i, Me.igyCantidad).Text = dRow("CANTIDAD").ToString
                    .Cell(i, Me.igyPrecio).Text = "0"
                    .Cell(i, Me.igyPRECIO_USD).Text = "0"
                    .Cell(i, Me.igyUnidad).Text = dRow("UNIDAD_VENTA").ToString
                    .Cell(i, Me.igyImpuestoPorcentaje).Text = dRow("IMPUESTO_PORCENTAJE").ToString
                    .Cell(i, Me.igyIEPS_PORCENTAJE).Text = dRow("IEPS_PORCENTAJE").ToString
                    '.Cell(i, Me.igyIDRequisicionDetalle).Text = dRow("ID_REQUISICION_DETALLE").ToString 
                    .Cell(i, Me.iGyIDAdicional).Text = i.ToString
                    .Cell(i, Me.igyEsRequisicion).Text = "1"
                End With

                Me.Grid.Rows += 1
                i += 1
            Next

            Me.Grid.Column(Me.igyDescripcion).Locked = True
            Me.Grid.Column(Me.igyUnidad).Locked = True

            Me.Totales()

            If Me.cboMoneda.Text = "USD" Then
                Me.Grid.Column(Me.igyPrecio).Locked = True
                Me.Grid.Cell(1, Me.igyPRECIO_USD).SetFocus()
            Else
                Me.Grid.Cell(1, Me.igyPrecio).SetFocus()
            End If

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Function ValidaEntradasInventario() As Boolean
        Const sProcedure As String = "ValidaEntradasInventario"
        Dim bResultado As Boolean = False
        Try
            Dim sFolioEntrada As String = ""
            For i As Integer = 1 To Me.GridEntradas.Rows - 1
                sFolioEntrada = Me.GridEntradas.Cell(i, Me.igyGridEFolioEntrada).Text
                If txtLEN(sFolioEntrada) = True Then
                    Dim oEntrada As New Class_Inventarios_Global(sFolioEntrada)

                    If oEntrada.Existe = False Then
                        MsgBox("No se encontró la entrada " & sFolioEntrada, vbExclamation, sProcedure)
                        Return False
                    ElseIf oEntrada.ESTA_CANCELADO = "1" Then
                        MsgBox("La entrada " & sFolioEntrada & " esta cancelada.", vbExclamation, sProcedure)
                        Return False
                    ElseIf oEntrada.ESTATUS <> "A" Then
                        MsgBox("La entrada " & sFolioEntrada & " no esta en estatus de aplicada.", vbExclamation, sProcedure)
                        Return False
                    End If

                End If
            Next

            bResultado = True
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    Private Function ValidaDisponiblesRequisicion(ByVal bPreguntarSiAvanzar As Boolean) As Boolean
        Const sProcedure As String = "ValidaDisponiblesRequisicion"
        Dim msgArticulos As String = "", mostrarMsgArticulos As Boolean = False
        Try
            Dim i As Integer
            For i = 1 To Me.Grid.Rows - 1
                'Solo validara renglones de la requisición
                If valorNumerico(Me.Grid.Cell(i, Me.igyEsRequisicion).Text) > 0 Then    'If valorNumerico(Me.Grid.Cell(i, Me.igyIDRequisicionDetalle).Text) > 0 Then
                    Dim dCantidadDisponible As Decimal = oRequisicion.CantidadDisponible(Me.Grid.Cell(i, Me.igyCodigo).Text, Me.CboAlmacen.SelectedValue.ToString)    'oRequisicion.CantidadDisponible(Me.Grid.Cell(i, Me.igyCodigo).Text, Me.TxtRequisicion.Text)
                    Dim dCantidadPedir As Decimal = valorNumericoD(Me.Grid.Cell(i, Me.igyCantidad).Text)
                    If dCantidadPedir > dCantidadDisponible Then
                        msgArticulos = msgArticulos & " " & Me.Grid.Cell(i, Me.igyDescripcion).Text & " (Disponible en requisición " & dCantidadDisponible.ToString & "),"

                        mostrarMsgArticulos = True
                        'MsgBox("La cantidad requerida disponible para el artículo " & Me.Grid.Cell(i, Me.igyDescripcion).Text & " en el renglón " & i.ToString & " es menor a la capturada. " &
                        '    "Hay requerida solamente la cantidad de " & dCantidadDisponible & " .", MsgBoxStyle.Exclamation, sProcedure)
                        'Me.Grid.Cell(i, Me.igyCantidad).SetFocus()
                        'Return False
                    End If
                End If
            Next i

            If mostrarMsgArticulos = True Then
                msgArticulos = Trim(msgArticulos.Substring(0, msgArticulos.Length - 1)) 'Quita la ultima coma
                msgArticulos = "Las cantidades capturadas de los siguientes artículos son mayores a las requeridas pendientes por pedir en el almacén " & Me.CboAlmacen.Text & " :" & vbCrLf & msgArticulos & " ."

                If bPreguntarSiAvanzar = True Then
                    msgArticulos = msgArticulos & vbCrLf & "Quiere continuar de todas formas ?"
                    If MsgBox(msgArticulos, MsgBoxStyle.Question Or vbYesNo, sProcedure) = MsgBoxResult.No Then
                        Return False
                    End If
                Else
                    MsgBox(msgArticulos, MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If
            End If

            Return True
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try

    End Function

    Private Function ValidaEsRequisicion() As Boolean
        'Si una OC se puede pedir solo si tiene un folio requisicion, o articulos con EsRequisicion=1 (cuando es de multiples requisiciones)

        If txtLEN(Me.TxtRequisicion.Text) Then
            Return True
        End If

        For i As Integer = 1 To Me.Grid.Rows - 1
            If Me.Grid.Cell(i, Me.igyEsRequisicion).Text = "1" Then
                Return True
            End If
        Next

        Return False
    End Function

#End Region

End Class