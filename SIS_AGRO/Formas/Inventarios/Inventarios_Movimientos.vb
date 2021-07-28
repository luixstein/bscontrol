Option Strict On

Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine

Public Class Inventarios_Movimientos

#Region "Campos privados"
    Private _LlamadoExteriorGenerarSalidaEmbarque As Boolean
    Private _CodigoDocumentoParaGrabar As String
    Private _AplicadoExterior As Boolean
    Private _FolioEmbarque As String
    Private _ConsultaExteriorSalida As Boolean
    Private _CodigoAlmacenHappy As String

    Private _LlamadoExteriorRecepcionarEntradaOrdenCompra As Boolean
    Private _FolioOrdenCompra As String
    Private _CodigoAlmacenOrdenCompra As String
    Private OcTieneRequisicion As Boolean
    Private _Moneda As String
    Private _TipoCambio As Decimal

    Private Estado As enumEstados
    Private oInventarios As New Class_Inventarios_Global
    Private oDocumentos As Class_Cat_tiposDocumentos
    Private oArticulos As New Class_CatArticulos
    Private dtSeries As DataTable

    'Private bAplicando As Boolean
    Private Consultando As Boolean = False
    Private oPalet As Class_Embarques_PaletsGlobal
    Private oFormaDetalleCuentas As InventariosDetalleCuentasContables

    Private Enum enumEstados
        NUEVO
        GRABADO
        APLICADO
        CANCELADO
    End Enum
#End Region

#Region "Columnas grid"
    Private iGyCodigo As Integer = 1
    Private iGyDescripcion As Integer = 2
    Private iGyCantidad As Integer = 3
    Private iGyCosto As Integer = 4 'en db es COSTO_DETALLE_BASE
    Private iGyImporte As Integer = 5 'en db es IMPORTE_BASE
    Private iGyBoton As Integer = 6
    Private iGyCuentaContable As Integer = 7
    Private iGyNombreCuentaContable As Integer = 8
    Private iGyIDAdicional As Integer = 9
    Private iGyFleteDetalleImporte As Integer = 10
    Private iGyCostoMasFlete As Integer = 11 'en db es COSTO
    Private iGyImporteMasFlete As Integer = 12 'en db es IMPORTE
    Private iGyIDCompraDetalle As Integer = 13
    Private iGyDisponible As Integer = 14
    Private iGyID_INVENTARIO_LOTES_COSTOS As Integer = 15
    Private iGyCostoUSD As Integer = 16 'No se graba en la base de datos , es sólo para calcular el Precio normal cuando se trata de una entrada que viene por recepción de compra en usd 
#End Region

#Region "Columnas grid series"
    Private igySeriePosicion As Short = 1
    Private igySerieCodigo As Short = 2
    Private igySerieDescripcion As Short = 3
    Private igySerieIdInventarioLotesCostos As Short = 4
    Private igySerieNumeroSerie As Short = 5
#End Region

#Region "Propiedades"
    Public WriteOnly Property LlamadoExteriorGenerarSalidaEmbarque() As Boolean
        Set(ByVal Value As Boolean)
            Me._LlamadoExteriorGenerarSalidaEmbarque = Value
        End Set
    End Property

    Public WriteOnly Property CodigoDocumentoParaGrabar() As String
        Set(ByVal Value As String)
            Me._CodigoDocumentoParaGrabar = Value
        End Set
    End Property

    Public ReadOnly Property AplicadoExterior() As Boolean
        Get
            Return Me._AplicadoExterior
        End Get
    End Property

    Public Property FolioEmbarque() As String
        Get
            Return Me._FolioEmbarque
        End Get
        Set(ByVal value As String)
            Me._FolioEmbarque = value
        End Set
    End Property

    Public WriteOnly Property ConsultaExteriorSalida() As Boolean
        Set(ByVal value As Boolean)
            Me._ConsultaExteriorSalida = value
        End Set
    End Property

    Public WriteOnly Property CodigoAlmacenHappy() As String
        Set(ByVal Value As String)
            Me._CodigoAlmacenHappy = Value
        End Set
    End Property

    Public Property FolioOrdenCompra() As String
        Get
            Return Me._FolioOrdenCompra
        End Get
        Set(ByVal value As String)
            Me._FolioOrdenCompra = value
        End Set
    End Property

    Public Property CodigoAlmacenOrdenCompra() As String
        Get
            Return Me._CodigoAlmacenOrdenCompra
        End Get
        Set(ByVal value As String)
            Me._CodigoAlmacenOrdenCompra = value
        End Set
    End Property

    Public Property Moneda() As String
        Get
            Return Me._Moneda
        End Get
        Set(ByVal value As String)
            Me._Moneda = value
        End Set
    End Property

    Public Property TipoCambio() As Decimal
        Get
            Return Me._TipoCambio
        End Get
        Set(ByVal value As Decimal)
            Me._TipoCambio = value
        End Set
    End Property

    Public WriteOnly Property LlamadoExteriorRecepcionarEntradaOrdenCompra() As Boolean
        Set(ByVal Value As Boolean)
            Me._LlamadoExteriorRecepcionarEntradaOrdenCompra = Value
        End Set
    End Property

#End Region

#Region "Opciones"
    Private Sub tsbNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbNuevo.Click
        Me.Inicializa()
        Me.Cambia_Estado(enumEstados.NUEVO)
    End Sub

    Private Sub tsbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGrabar.Click
        'Me.bAplicando = False
        If txtLEN(Me.TxtFolio.Text) = True Then
            If Me.Grabar() = True Then
                If Me.Consultar() = True Then
                    'Me.Cambia_Estado(enumEstados.GRABADO)
                End If
            End If
        End If
    End Sub

    Private Sub tsbAplicar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbAplicar.Click
        If Me.Estado = enumEstados.NUEVO Then
            If Me.Grabar(False) = True Then
                If Me.Consultar() = True Then
                    Me.GestionaAplicacion()
                End If
            End If
        Else
            Me.GestionaAplicacion()
        End If
    End Sub

    Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click
        Me.Imprimir()
    End Sub

    Private Sub tsbCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCancelar.Click

        'Nota, ahora estas validaciones se hacen en base al campo es_cancelable que se validan dentro del cancelar.

        'If Me.oInventarios.CODIGO_TIPO_DOCUMENTO = "ENI" Or Me.oInventarios.CODIGO_TIPO_DOCUMENTO = "SAI" Or Me.oInventarios.CODIGO_TIPO_DOCUMENTO = "ER" Then 'ENI=ENTRADA,SAI=SALIDA,ER=ENTRADA RECEPCION COMPRA
        '    If Me.Cancelar() = True Then
        '        Me.Consultar()
        '    End If
        'ElseIf Me.oInventarios.CODIGO_TIPO_DOCUMENTO = "TRI" Or Me.oInventarios.CODIGO_TIPO_DOCUMENTO = "TRF" Or Me.oInventarios.CODIGO_TIPO_DOCUMENTO = "TRLT" Then
        '    If Me.Estado <> enumEstados.GRABADO Then
        '        MsgBox("Las transferencias son cancelables sólo si están en estatus de grabado. Si esta aplicada debe hacer una transferencia contraria.", vbExclamation, Me.Name)
        '        Return
        '    Else
        '        If Me.Cancelar() = True Then
        '            Me.Consultar()
        '        End If
        '    End If
        'Else
        '    MsgBox("Este documento no es cancelable.", vbExclamation, Me.Name)
        'End If

        If Me.Cancelar() = True Then
            Me.Consultar()
        End If

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
            Dim oCostos As New FrmCostosEdicion(Me.TxtFolio.Text, Me.CboDocumento.SelectedValue.ToString & Usuario.Codigo_Plaza)
            If oCostos.bMovimientoEncontrado = True Then
                oCostos.ShowDialog()
                oCostos.Dispose()
                Me.Consultar()
            End If
        Catch ex As Exception
            HandleError(Me.Name, "tsbEditarCostos_Click", ex)
        End Try
    End Sub

    Private Sub btnConsultarOrdenCompra_Click(sender As Object, e As EventArgs) Handles btnConsultarOrdenCompra.Click
        Me.ConsultarOrdenCompra()
    End Sub

    Private Sub btnNuevaOrdenCompra_Click(sender As Object, e As EventArgs) Handles btnNuevaOrdenCompra.Click
        Me.InicializaOrdenCompra()
    End Sub

    Private Sub btnProrratearFleteOrdenCompra_Click(sender As Object, e As EventArgs) Handles btnProrratearFleteOrdenCompra.Click
        Me.ProrratearFlete()
    End Sub
#End Region

#Region "Eventos"
    Private Sub Inventarios_Movimientos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim dTabla As DataTable
        'Dim dCajaCarton As Boolean
        Try
            Me.DesplegarMonedas()

            If Me._LlamadoExteriorGenerarSalidaEmbarque = True Then

                Me.InicializaExterno()

                Me.TxtFolio.Text = Me._FolioEmbarque
                Me.Consultar()

                If Me.lblStatus.Text = "A" Then
                    Me.tsbEditarCostos.Enabled = True
                End If

                Return

                'Este era el código que estaba cuando se hacia una salida por cada palet.
                'Me.InicializaExterno()
                'Dim oPalet = New Class_Embarques_PaletsGlobal(Me.TxtFolioReferencia.Text)

                'Dim sql As New Class_find("SELECT count(CODIGO_ARTICULO) articulos,max(CODIGO_ARTICULO) FROM EMB_PALETS_DETALLE " & _
                '            "WHERE FOLIO_PALET='" & Me.TxtFolioReferencia.Text & "'")

                'If sql.Result1 = "1" Then
                '    Dim sql1 As New Class_find("SELECT 1 FROM CAT_PRODUCTOS_AGRICOLAS_FORMULAS_EMPAQUE WHERE CLAVE='CAJA_CARTON' AND CODIGO_PRODUCTO='" & sql.Result2 & "'")

                '    If sql1.Result1 = "1" Then
                '        dCajaCarton = True
                '    Else
                '        MsgBox("El producto no tiene configurado el material de empaque.", MsgBoxStyle.Information, "Aplicando Movimientos de Inventarios")
                '    End If

                '    dTabla = oPalet.ObtenerDetalleSalidaInventario(Me._FolioEmbarque) '.Rows.Count
                '    Me.Grid1.Rows = 1
                '    For Each dRow As DataRow In dTabla.Rows
                '        Me.Grid1.AddItem(dRow(0).ToString & Chr(9) & dRow(1).ToString & Chr(9) & dRow(2).ToString & Chr(9) & dRow(3).ToString & Chr(9) & dRow(4).ToString & Chr(9) & _
                '                        dRow(5).ToString & Chr(9))
                '    Next
                'End If

                'Me.FormateaGrid()

                'If Me.Grid1.Rows = 1 Then
                '    InicializaGrid()
                'End If

                'Me.Totales()
                'Me.Grid1.Focus()
                'Me.Visible = False

                'If dCajaCarton = True Then
                '    Me.tsbAplicar.PerformClick()
                'Else
                '    Me.Visible = True
                'End If


            ElseIf Me._ConsultaExteriorSalida = True Then
                Me.InicializaExterno()
                Dim sql As New Class_find("SELECT MAX(FOLIO_MOVIMIENTO_INVENTARIO)FOLIO_MOVIMIENTO_INVENTARIO FROM INVENTARIO_MOVIMIENTOS_GLOBAL WHERE FOLIO_REFERENCIA='" & Me.TxtFolioReferencia.Text & "' AND ESTA_CANCELADO='0'")
                Me.TxtFolio.Text = sql.Result1.ToString
                Me.Consultar()
                Me.tsbNuevo.Enabled = False
                Me.tsbCancelar.Enabled = False

            ElseIf Me._LlamadoExteriorRecepcionarEntradaOrdenCompra = True Then
                Me.Inicializa()
                Me.DesplegarDocumentos()
                Me.DesplegarAlmacenes()
                Me.DesplegarConceptosInventarios()
                Me.Cambia_Estado(enumEstados.NUEVO)

                Me.CboDocumento.SelectedValue = Me._CodigoDocumentoParaGrabar
                Me.txtFolioOrdenCompra.Text = Me._FolioOrdenCompra
                Me.CboAlmacen.SelectedValue = Me._CodigoAlmacenOrdenCompra
                Me.cboMoneda.SelectedValue = Me._Moneda
                'Me.txtTipoCambio.Text = Me._TipoCambio.ToString
                Me.ConsultarOrdenCompra()

                Me.tsbNuevo.Enabled = False
                Me.tsbCancelar.Enabled = False
                Me.TxtFolio.Enabled = False
                Me.btnDocumentoAnterior.Enabled = False
                Me.btnDocumentoSiguiente.Enabled = False

                Me.cboMoneda.Visible = True : Me.lblDisplayMoneda.Visible = True
                Me.txtTipoCambio.Visible = True : Me.lblDisplayTipoCambio.Visible = True

            Else
                Me.Inicializa()
                Me.DesplegarDocumentos()
                Me.DesplegarAlmacenes()
                Me.DesplegarConceptosInventarios()
                Me.Cambia_Estado(enumEstados.NUEVO)
            End If

            Me.ObtenerTipoCambioDia()

        Catch ex As Exception
            HandleError(Me.Name, "Inventarios_Movimientos_Load", ex)
        End Try
    End Sub

    Private Sub Grid1_KeyDown(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Grid1.KeyDown
        Me.GestionaGrid(e)
    End Sub

    Private Sub GridSeries_KeyDown(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridSeries.KeyDown
        Me.GestionaGridSeries(e)
    End Sub

    Private Sub BtnSeries_Click(sender As Object, e As EventArgs) Handles btnSeries.Click
        Me.PrepararSeries()
    End Sub

    Private Sub btnSeleccionarArchivoSeries_Click(sender As Object, e As EventArgs) Handles btnSeleccionarArchivoSeries.Click
        Me.GestionaArchivoSeries()
    End Sub

    Private Sub Grid_ButtonClick(ByVal Sender As System.Object, ByVal e As FlexCell.Grid.ButtonClickEventArgs) Handles Grid1.ButtonClick
        Me.GestionaDetalleCuentas()
    End Sub

    Private Sub CmbAlmacenDestino_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CboAlmacenDestino.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.Send("{TAB}")
            Case Keys.Escape
                Me.CboAlmacen.Focus()
        End Select
    End Sub

    Private Sub cboCentros_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        txtTAB(e)
    End Sub

    Private Sub CmbDocumento_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CboDocumento.KeyDown
        txtTAB(e)
    End Sub

    Private Sub CmbDocumento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboDocumento.SelectedIndexChanged
        If Me.Consultando = False Then
            Me.GeneraFolio()

            Me.InicializaGrid()
            Me.InicializaGridSeries()
        End If

        Me.OcultaControles()
    End Sub

    Private Sub CmbAlmacen_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CboAlmacen.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.Send("{TAB}")
            Case Keys.Escape
                Me.CboDocumento.Focus()
        End Select
    End Sub

    Private Sub CmbAlmacen_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboAlmacen.SelectedIndexChanged
        Me.GeneraFolio()
    End Sub

    Private Sub DtpFecha_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtpFecha.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.Send("{TAB}")
            Case Keys.Escape
                Me.CboAlmacen.Focus()
        End Select
    End Sub

    Private Sub TxtFolioReferencia_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtFolioReferencia.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.Send("{TAB}")
            Case Keys.Escape
                Me.DtpFecha.Focus()
        End Select
    End Sub

    Private Sub TxtConcepto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtConcepto.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                Me.Grid1.Cell(1, 1).SetFocus()
            Case Keys.Escape
                Me.TxtFolioReferencia.Focus()
        End Select
    End Sub

    Private Sub TxtFolio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtFolio.KeyDown
        Select Case e.KeyCode
            Case Keys.F6
                Me.TxtFolio.Text = BusquedaVisual_PorDescripcion()
            Case Keys.Enter
                If Consultar() = False Then
                    Me.GeneraFolio()
                    Me.TxtFolioReferencia.Focus()
                End If
            Case Keys.Escape
                Me.CboAlmacen.Focus()
        End Select
    End Sub

    Private Sub txtFolioEmbarque_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFolioEmbarque.KeyDown
        Try
            Dim oEmbarque As Class_Embarques_EmbarqueGlobal

            Select Case e.KeyCode
                Case Keys.F6
busca:
                    oEmbarque = New Class_Embarques_EmbarqueGlobal
                    Me.txtFolioEmbarque.Text = oEmbarque.BusquedaVisual_Embarques_Nacional
                Case Keys.Enter
                    If txtLEN(Me.txtFolioEmbarque.Text) = False Then
                        GoTo busca : Exit Sub
                    Else
                        If Me.ValidaEmbarque = False Then
                            Me.txtFolioEmbarque.Text = ""
                            GoTo busca : Exit Sub
                        End If
                    End If
            End Select
        Catch ex As Exception
            HandleError(Me.Name, "txtFolioEmbarque_KeyDown", ex)
        End Try
    End Sub

    Private Sub LblPoliza_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblPoliza.LinkClicked
        Dim Child As New Frm_Contabilidad_Captura_Polizas()
        Child.FolioPolizaConsultaExterior = Me.lblPoliza.Text
        Child.ShowDialog()
        Child.Dispose()
    End Sub

    Private Sub txtFolioOrdenCompra_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFolioOrdenCompra.KeyDown
        Select Case e.KeyCode
            Case Keys.F6
buscar:
                Dim oCompras As New Class_Compras_Global()
                Me.txtFolioOrdenCompra.Text = oCompras.BusquedaVisual_OrdenesCompra() 'Si es OC
            Case Keys.Return
                If txtLEN(Me.txtFolioOrdenCompra.Text) = True Then
                    Me.btnConsultarOrdenCompra.Focus()
                Else
                    GoTo buscar : Exit Sub
                End If
        End Select
    End Sub

    Private Sub txtFlete_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFleteOrdenCompra.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.txtFleteOrdenCompra.Text = FormatImporteContable(valorNumericoD(Me.txtFleteOrdenCompra.Text))
            Me.btnProrratearFleteOrdenCompra.Focus()
        End If
    End Sub

    Private Sub CboConceptoInventario_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboConceptoInventario.SelectedIndexChanged
        If Empresa_Sistema.ES_ACUICOLA = True And (Me.oDocumentos.CODIGO_TIPO_DOCUMENTO = "ENI" Or Me.oDocumentos.CODIGO_TIPO_DOCUMENTO = "SAI") Then
            If Me.CboConceptoInventario.Text = "MATERIA PRIMA" Then
                Me.LblFolioOrdenProduccion.Visible = True
                Me.TxtFolioOrdenProduccion.Visible = True
            Else
                Me.LblFolioOrdenProduccion.Visible = False
                Me.TxtFolioOrdenProduccion.Visible = False
                Me.TxtFolioOrdenProduccion.Text = ""
            End If

        End If
    End Sub

    Private Sub txtCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCliente.KeyDown
        Dim sText As String = ""
        Dim oCliente As Class_CatClientes
        Select Case e.KeyCode
            Case Keys.F6
Buscar:
                oCliente = New Class_CatClientes
                If Empresa_Sistema.PERMITE_CLIENTES_MULTIPLAZA = True Then
                    sText = oCliente.BusquedaVisual_PorDescripcionSinFiltroZona
                Else
                    sText = oCliente.BusquedaVisualPlaza
                End If

                If txtLEN(sText) = True Then Me.txtCliente.Text = sText
            Case Keys.Enter
                If txtLEN(Me.txtCliente.Text) = False Then
                    Me.lblCliente.Text = "" : Exit Sub
                End If

                oCliente = New Class_CatClientes(Me.txtCliente.Text)

                If oCliente.Existe = False Then
                    Me.lblCliente.Text = "" : GoTo Buscar : Exit Sub
                End If

                Me.lblCliente.Text = oCliente.NOMBRE_CLIENTE

                If Me.TxtConcepto.Enabled = True Then
                    Me.TxtConcepto.Focus()
                End If
        End Select
    End Sub

    Private Sub DtpFecha_ValueChanged(sender As Object, e As EventArgs) Handles DtpFecha.ValueChanged
        If Empresa_Sistema.TIPO_CAMBIO_POR_DIA = True Then
            Me.ObtenerTipoCambioDia()
            Me.Totales()
        End If
    End Sub

#Region "Eventos Genericos"
    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DtpFecha.KeyPress, TxtConcepto.KeyPress, TxtFolio.KeyPress, TxtFolioReferencia.KeyPress, txtFolioEmbarque.KeyPress,
        txtFolioOrdenCompra.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub txtSoloNumerosDecimales_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFleteOrdenCompra.KeyPress
        Dim txt As TextBox = CType(sender, TextBox)
        txtSoloNumerosDecimales(e, txt.Text)
        txtNoBeep(e)
    End Sub
#End Region

#End Region

#Region "Métodos y procedimientos"

    Private Sub Cambia_Estado(ByVal pEstado As enumEstados)
        Const sProcedure As String = "Cambia_Estado"
        Try
            Me.Estado = pEstado

            'Me.gbOrdenCompra.Visible = False
            Me.btnConsultarOrdenCompra.Enabled = False
            Me.btnProrratearFleteOrdenCompra.Enabled = False
            Me.btnNuevaOrdenCompra.Enabled = False
            Me.txtFolioOrdenCompra.Enabled = False
            Me.txtFleteOrdenCompra.Enabled = False

            Select Case Me.Estado
                Case enumEstados.NUEVO
                    Me.tsslEstado.Text = "ESTADO: AGREGANDO NUEVO MOVIMIENTO"
                    Me.tsslElaboro.Text = ""
                    Me.tsslCancelo.Text = ""
                    Me.tsbNuevo.Enabled = True
                    Me.tsbGrabar.Enabled = True
                    Me.tsbAplicar.Enabled = True
                    Me.tsbCancelar.Enabled = False
                    Me.tsbImprimir.Enabled = False
                    Me.tsbEditarCostos.Visible = False
                    Me.CboDocumento.Enabled = True
                    Me.DtpFecha.Enabled = True
                    Me.CboAlmacen.Enabled = True
                    Me.TxtFolio.Enabled = True
                    Me.TxtFolioReferencia.Enabled = True
                    Me.TxtConcepto.Enabled = True
                    Me.CboDocumento.Enabled = True
                    Me.CboAlmacenDestino.Enabled = True
                    Me.cboAlmacenEntradaFinanciera.Enabled = True
                    Me.txtFolioEmbarque.Enabled = True
                    Me.Grid1.Locked = False
                    Me.GridSeries.Locked = False
                    Me.btnSeries.Enabled = True
                    Me.btnSeleccionarArchivoSeries.Enabled = True
                    Me.CboConceptoInventario.Enabled = True
                    Me.TxtFolioOrdenProduccion.Enabled = True
                    Me.txtCliente.Enabled = True

                    Me.OcultaControles()

                    'If Me.oDocumentos.CODIGO_TIPO_DOCUMENTO = "ER" Then
                    '    Me.gbOrdenCompra.Visible = True
                    '    Me.Grid1.Locked = True 'No deja ingresarle nada hasta que agreguen una orden de compra con el botón
                    'End If

                    If Me.Visible = True Then
                        Me.TxtFolio.Focus()
                    End If

                Case enumEstados.GRABADO
                    If Me._LlamadoExteriorGenerarSalidaEmbarque = True And txtLEN(Me.FolioEmbarque) = True Then
                        Return 'Los controles ya se activaron/desactivaron en el inicializaExterno
                    End If

                    Me.tsslEstado.Text = "ESTADO: CONSULTANDO MOVIMIENTO"
                    Me.tsslCancelo.Text = ""
                    Me.tsbNuevo.Enabled = True
                    Me.tsbGrabar.Enabled = True
                    Me.tsbAplicar.Enabled = True
                    Me.tsbCancelar.Enabled = True
                    Me.tsbImprimir.Enabled = True
                    Me.tsbEditarCostos.Visible = False
                    Me.CboDocumento.Enabled = False
                    Me.DtpFecha.Enabled = False
                    Me.CboAlmacen.Enabled = False
                    Me.TxtFolio.Enabled = False
                    Me.TxtFolioReferencia.Enabled = True
                    Me.TxtConcepto.Enabled = True
                    Me.CboDocumento.Enabled = False
                    Me.CboAlmacenDestino.Enabled = False
                    Me.txtFolioEmbarque.Enabled = True
                    Me.Grid1.Locked = False
                    Me.GridSeries.Locked = False
                    Me.btnSeries.Enabled = True
                    Me.btnSeleccionarArchivoSeries.Enabled = True
                    Me.CboConceptoInventario.Enabled = False
                    Me.TxtFolioOrdenProduccion.Enabled = True
                    Me.txtCliente.Enabled = True

                    Me.OcultaControles()

                    'If Me.oDocumentos.CODIGO_TIPO_DOCUMENTO = "ER" Then
                    '    Me.gbOrdenCompra.Visible = True
                    '    Me.Grid1.Locked = False  'Si ya existe entonces ya establecieron una orden de compra.
                    'End If

                    Me.TxtConcepto.Focus()

                Case enumEstados.APLICADO
                    Me.tsslEstado.Text = "ESTADO: CONSULTANDO MOVIMIENTO"
                    Me.tsslCancelo.Text = ""
                    Me.tsbNuevo.Enabled = True
                    Me.tsbGrabar.Enabled = False
                    Me.tsbAplicar.Enabled = False
                    Me.tsbCancelar.Enabled = True
                    Me.tsbImprimir.Enabled = True
                    Me.tsbEditarCostos.Visible = True
                    Me.DtpFecha.Enabled = False
                    Me.CboAlmacen.Enabled = False
                    Me.TxtFolio.Enabled = False
                    Me.TxtFolioReferencia.Enabled = False
                    Me.TxtConcepto.Enabled = False
                    Me.CboDocumento.Enabled = False
                    Me.CboAlmacenDestino.Enabled = False
                    Me.cboAlmacenEntradaFinanciera.Enabled = False
                    Me.txtFolioEmbarque.Enabled = False
                    Me.Grid1.Locked = True
                    Me.btnSeries.Enabled = False
                    Me.btnSeleccionarArchivoSeries.Enabled = False
                    Me.GridSeries.Locked = True
                    Me.CboConceptoInventario.Enabled = False
                    Me.TxtFolioOrdenProduccion.Enabled = False
                    Me.txtCliente.Enabled = False

                    Me.tsbImprimir.Select()

                Case enumEstados.CANCELADO
                    Me.tsslEstado.Text = "ESTADO: CONSULTANDO MOVIMIENTO"
                    Me.tsbNuevo.Enabled = True
                    Me.tsbGrabar.Enabled = False
                    Me.tsbAplicar.Enabled = False
                    Me.tsbCancelar.Enabled = False
                    Me.tsbImprimir.Enabled = True
                    Me.tsbEditarCostos.Visible = False
                    Me.DtpFecha.Enabled = False
                    Me.CboAlmacen.Enabled = False
                    Me.TxtFolio.Enabled = False
                    Me.TxtFolioReferencia.Enabled = False
                    Me.TxtConcepto.Enabled = False
                    Me.CboDocumento.Enabled = False
                    Me.CboAlmacenDestino.Enabled = False
                    Me.cboAlmacenEntradaFinanciera.Enabled = False
                    Me.txtFolioEmbarque.Enabled = False
                    Me.Grid1.Locked = True
                    Me.btnSeries.Enabled = False
                    Me.btnSeleccionarArchivoSeries.Enabled = False
                    Me.GridSeries.Locked = False
                    Me.CboConceptoInventario.Enabled = False
                    Me.TxtFolioOrdenProduccion.Enabled = False
                    Me.txtCliente.Enabled = False

                    Me.tsbImprimir.Select()
            End Select
            Application.DoEvents()

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Sub Inicializa()
        Const sProcedure As String = "Inicializa"
        Try
            Me.TxtFolio.Text = ""
            Me.txtTotal.Text = ""
            Me.txtTotalMasFlete.Text = ""
            Me.txtTotalCantidad.Text = ""
            Me.TxtFolioReferencia.Text = ""
            Me.TxtConcepto.Text = ""
            Me.DtpFecha.Value = Date.Now
            Me.Grid1.DataSource = Nothing
            Me.lblPoliza.Text = ""

            Me.InicializaGrid()
            Me.InicializaGridSeries()

            Me.DtpFecha.Value = Date.Now
            Me.TxtConcepto.Text = ""
            Me.lblStatus.Text = ""

            Me.txtFolioEmbarque.Text = ""

            Me.TxtFolioOrdenProduccion.Text = ""
            Me.TxtFolioOrdenProduccion.Visible = False
            Me.LblFolioOrdenProduccion.Visible = False

            Me.txtCliente.Text = "" : Me.lblCliente.Text = ""

            Me.GeneraFolio()

            Me.TxtFolioReferencia.Focus()

            Me.oFormaDetalleCuentas = Nothing 'New InventariosDetalleCuentasContables

            Me.dtSeries = New DataTable("Series")

            Me.txtFolioOrdenCompra.Text = ""
            Me.txtFleteOrdenCompra.Text = ""
            Me.txtProveedor.Text = ""
            Me.dtpFechaEntrega.Value = Date.Now
            Me.cboEntradasAnterioresOrdenCompra.DataSource = Nothing

            Me.cboAlmacenEntradaFinanciera.SelectedIndex = -1
            Me.txtFolioEntradaFinanciera.Text = ""

            Me.TabControl1.SelectedIndex = 0

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Sub InicializaExterno()
        Const sProcedure As String = "InicializaExterno"
        Try
            Me.DesplegarDocumentos(False)
            Me.DesplegarAlmacenes()
            Me.DesplegarConceptosInventarios()

            Me.CboDocumento.SelectedValue = Me._CodigoDocumentoParaGrabar.ToString

            'Me.oPalet = New Class_Embarques_PaletsGlobal(Me.TxtFolioReferencia.Text) 'El folio de la referencia desde afuera se lleno con el folio de palet
            'Me.CboAlmacen.SelectedValue = oPalet.CODIGO_ALMACEN
            'Me.DtpFecha.Value = oPalet.FECHA

            If txtLEN(Me._CodigoAlmacenHappy) = True Then
                Me.TxtConcepto.Text = "TRANSFERENCIA EMPAQUE PALET " & Me.TxtFolioReferencia.Text
                Me.CboAlmacenDestino.Visible = True
            Else
                Me.TxtConcepto.Text = "SALIDA EMPAQUE PALET " & Me.TxtFolioReferencia.Text
                Me.CboAlmacenDestino.Visible = False
            End If

            Me.lblPoliza.Text = ""

            Me.InicializaGrid()

            Me.tsbNuevo.Enabled = False
            Me.tsbGrabar.Enabled = False
            Me.tsbAplicar.Enabled = True
            Me.tsbCancelar.Enabled = False
            Me.tsbImprimir.Enabled = False
            Me.tsbEditarCostos.Enabled = False

            Me.DtpFecha.Enabled = False
            Me.CboAlmacen.Enabled = False
            Me.TxtFolio.Enabled = False
            Me.TxtFolioReferencia.Enabled = False
            Me.CboDocumento.Enabled = False
            Me.CboAlmacenDestino.Enabled = False
            Me.Grid1.Locked = False
            Me.tsslEstado.Text = "ESTADO: AGREGANDO NUEVO MOVIMIENTO"
            Me.tsslElaboro.Text = ""
            Me.tsslCancelo.Visible = False

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Sub InicializaGrid()
        Const sProcedure As String = "InicializaGrid"
        Try
            FG_Grid_Limpiar(Me.Grid1)
            Me.Grid1.Rows = 2
            Me.FormateaGrid()
            Me.Totales()

            Me.Grid1.Cell(1, Me.iGyIDAdicional).Text = "1"
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Sub InicializaRenglonGrid(ByVal iRenglon As Integer)
        Try
            With Me.Grid1
                .Cell(iRenglon, Me.iGyCodigo).Text = ""
                .Cell(iRenglon, Me.iGyDescripcion).Text = ""
                .Cell(iRenglon, Me.iGyCantidad).Text = "0"
                .Cell(iRenglon, Me.iGyCosto).Text = ""
                .Cell(iRenglon, Me.iGyImporte).Text = ""
                .Cell(iRenglon, Me.iGyBoton).Text = ""
                .Cell(iRenglon, Me.iGyCuentaContable).Text = ""
                .Cell(iRenglon, Me.iGyNombreCuentaContable).Text = ""
                '.Cell(iRenglon, Me.iGyIDAdicional).Text = "" 'Para que no se borre el id que ya tenga calculado
                .Cell(iRenglon, Me.iGyCostoMasFlete).Text = ""
                .Cell(iRenglon, Me.iGyFleteDetalleImporte).Text = ""
                .Cell(iRenglon, Me.iGyImporteMasFlete).Text = ""
                .Cell(iRenglon, Me.iGyIDCompraDetalle).Text = ""
                .Cell(iRenglon, Me.iGyDisponible).Text = ""
                .Cell(iRenglon, Me.iGyID_INVENTARIO_LOTES_COSTOS).Text = ""
            End With
        Catch ex As Exception
            HandleError(Me.Name, "InicializaRenglonGrid", ex)
        End Try
    End Sub

    Private Sub GestionaGrid(ByVal e As System.Windows.Forms.KeyEventArgs)
        Const sProcedure As String = "GestionaGrid"
        Try
            Dim Columna As Integer, Renglon As Integer
            Dim StrCod As String, DCosto As Double, sCuentaContable As String, sCodArticulo As String = "", sNaturalezaInventarios As String, dExistencia As Double, dCantidad As Double, iID_INVENTARIO_LOTES_COSTOS As Integer = 0
            Dim oCuentas As New Class_CatCuentas 'Class_VWCatDeudoresDiversos

            Me.oArticulos = New Class_CatArticulos

            Columna = Me.Grid1.Selection.FirstCol
            Renglon = Me.Grid1.Selection.FirstRow
            StrCod = Me.Grid1.Cell(Renglon, iGyCodigo).Text

            Select Case e.KeyCode
                Case Keys.Enter
                    dCantidad = valorNumerico(Me.Grid1.Cell(Renglon, iGyCantidad).Text)
                    iID_INVENTARIO_LOTES_COSTOS = CInt(valorNumerico(Me.Grid1.Cell(Renglon, Me.iGyID_INVENTARIO_LOTES_COSTOS).Text))

                    If txtLEN(StrCod) = False Then
                        GoTo ArticuloEnBlanco
                    End If

                    Me.oArticulos = New Class_CatArticulos(StrCod)

                    If Me.oArticulos.Existe = False Then
ArticuloEnBlanco:
                        Me.InicializaRenglonGrid(Renglon)

                        If Me.oDocumentos.AFECTA_LOTES_SELECCIONADOS = True Then
                            GoTo BuscaArticulosPorLotes
                        Else
                            GoTo BuscaArticulos
                        End If

                        Return
                    End If

                    If oArticulos.ESTATUS = "B" Then
                        MsgBox("Este artículo esta dado de baja.", vbExclamation, sProcedure)
                        Me.InicializaRenglonGrid(Renglon)
                        Return
                    End If

                    sNaturalezaInventarios = oInventarios.NaturalezaInventarios(Me.CboDocumento.SelectedValue.ToString)

                    Select Case Columna
                        Case Me.iGyCodigo

                            If Me.oDocumentos.AFECTA_LOTES_SELECCIONADOS = True Then
                                If iID_INVENTARIO_LOTES_COSTOS <= 0 Then
                                    Me.InicializaRenglonGrid(Renglon)
                                    GoTo BuscaArticulosPorLotes
                                    Return
                                Else
                                    'No hace nada, no es necesario recargar los valores ya que no pueden cambiar excepto la cantidad(el costo hay que bloquearlo).
                                End If

                            Else
                                If Me.oArticulos.DESCRIPCION = "" Then
                                    MsgBox("El código de artículo que intenta buscar no existe o esta dado de baja, favor de intentar con otro código.", MsgBoxStyle.Exclamation, sProcedure)
                                    Me.Grid1.Cell(Renglon, iGyCodigo).SetFocus()
                                    Return
                                Else
                                    DCosto = 0
                                    If sNaturalezaInventarios = "SA" Then
                                        Me.Grid1.Column(Me.iGyCosto).Locked = True
                                        DCosto = Me.oInventarios.oInventariosDetalle.Obtener_Costo(StrCod, Me.CboAlmacen.SelectedValue.ToString, 1)
                                    Else
                                        Me.Grid1.Column(Me.iGyCosto).Locked = False
                                    End If
                                    Me.Grid1.Cell(Renglon, Me.iGyDescripcion).Text = Me.oArticulos.DESCRIPCION
                                    Me.Grid1.Cell(Renglon, Me.iGyCosto).Text = DCosto.ToString
                                    If Me._LlamadoExteriorGenerarSalidaEmbarque = False Then
                                        Me.Grid1.Cell(Renglon, Me.iGyCantidad).Text = "0"
                                        Me.Grid1.Cell(Renglon, Me.iGyImporte).Text = "0"
                                    End If
                                End If
                            End If

                            Me.oArticulos = Nothing

                        Case Me.iGyCantidad
                            If sNaturalezaInventarios = "SA" Then
                                'Dim sql3 As New Class_find("Select Existencia From INVENTARIO_EXISTENCIA_ARTICULOS Where CODIGO_Articulo='" & Grid1.Cell(Renglon, iGyCodigo).Text & "' and Codigo_Almacen='" & CboAlmacen.SelectedValue.ToString & "'")
                                'If valorNumerico(sql3.Result1) < valorNumerico(StrCod) Then
                                If Me.oArticulos.INVENTARIABLE <> "0" Then

                                    If Me.oDocumentos.AFECTA_LOTES_SELECCIONADOS = True Then
                                        dExistencia = oInventarios.ExistenciaLoteSerie(Me.Grid1.Cell(Renglon, Me.iGyID_INVENTARIO_LOTES_COSTOS).Text)
                                    Else
                                        dExistencia = oInventarios.Existencia(Me.Grid1.Cell(Renglon, Me.iGyCodigo).Text, Me.CboAlmacen.SelectedValue.ToString)
                                    End If

                                    If dCantidad > dExistencia Then 'if capturaron>existencia
                                        Dim dDiferencia As Double = dCantidad - dExistencia
                                        MsgBox("El artículo que intenta agregar no tiene suficiente existencia." & vbCrLf &
                                                "Existencia " & Format(dExistencia, "###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CANTIDAD)) & ", faltan " & Format(dDiferencia, "###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CANTIDAD)), MsgBoxStyle.Exclamation, "Validación de existencias")
                                        'Me.Grid1.Cell(Renglon, Me.iGyCantidad).Text = "0"
                                        'Me.Grid1.Cell(Renglon, Me.iGyDescripcion).SetFocus()
                                        'Me.Totales()
                                    End If
                                End If
                            End If

                            If Not (Me.oDocumentos.CODIGO_TIPO_DOCUMENTO = "ER" Or Me.oDocumentos.AFECTA_LOTES_SELECCIONADOS = True) Then 'Para las entradas por recepción de compras o documentos que afectan lotes selecionados no se sobreescribe ni pierde el costp.
                                DCosto = valorNumerico(Me.oInventarios.oInventariosDetalle.Obtener_Costo(Me.Grid1.Cell(Renglon, Me.iGyCodigo).Text, Me.CboAlmacen.SelectedValue.ToString, valorNumerico(Me.Grid1.Cell(Renglon, Me.iGyCantidad).Text)).ToString)
                                Me.Grid1.Cell(Renglon, Me.iGyCosto).Text = DCosto.ToString
                            End If

                        Case Me.iGyCuentaContable 'Enter
                            If Me.oDocumentos.ES_TRANSFERENCIA <> "1" Then
                                sCuentaContable = Me.Grid1.Cell(Renglon, Me.iGyCuentaContable).Text

                                'If sCuentaContable.StartsWith("1") = False Then
                                '    Me.Grid1.Cell(Renglon, Me.iGyCuentaContable).Text = ""
                                '    Me.Grid1.Cell(Renglon, Me.iGyNombreCuentaContable).Text = ""
                                '    MsgBox("La cuenta contable del renglón : " & Renglon & " debe ser del rango de las miles(que empiezen con 1).", MsgBoxStyle.Exclamation, Me.Name)
                                '    Return
                                'End If

                                If sCuentaContable = "0" Then
                                    MsgBox("No se puede utilizar la cuenta contable 0 en movimientos de inventario.", MsgBoxStyle.Exclamation, sProcedure)
                                    Me.Grid1.Cell(Renglon, Me.iGyCuentaContable).Text = ""
                                    Exit Sub
                                End If

                                oCuentas = New Class_CatCuentas(sCuentaContable) 'Class_VWCatDeudoresDiversos(sCuentaContable) 

                                If oCuentas._Existe = True Then
                                    Me.Grid1.Cell(Renglon, Me.iGyCuentaContable).Text = oCuentas.CUENTA_CONTABLE
                                    Me.Grid1.Cell(Renglon, Me.iGyNombreCuentaContable).Text = oCuentas.NOMBRE_CUENTA
                                Else
                                    Me.Grid1.Cell(Renglon, Me.iGyCuentaContable).Text = ""
                                    Me.Grid1.Cell(Renglon, Me.iGyNombreCuentaContable).Text = ""
                                    GoTo BuscarCuentas : Exit Sub
                                End If

                            End If

                    End Select

                    If Me.Grid1.Rows = Renglon + 1 Then 'Si se está en el último renglón, se agrega un renglón más.
                        Me.Grid1.Rows = Me.Grid1.Rows + 1
                        Me.Grid1.Cell(Renglon + 1, Me.iGyIDAdicional).Text = (CInt(Me.Grid1.Cell(Renglon, Me.iGyIDAdicional).Text) + 1).ToString
                    End If

                    'Select Case Columna
                    '    Case Me.iGyCodigo
                    '        Me.Grid1.Cell(Renglon, Me.iGyDescripcion).SetFocus()
                    '    Case Me.iGyCuentaContable
                    '        Me.Grid1.Cell(Renglon + 1, iGyCodigo).SetFocus()
                    '    Case Else
                    '        Me.Grid1.Cell(Renglon, Columna).SetFocus()
                    'End Select

                    Me.Totales()

                Case Keys.F6, Keys.F7

                    If (txtLEN(StrCod) = False And Columna = Me.iGyCuentaContable) Or (Me.oDocumentos.CODIGO_TIPO_DOCUMENTO = "ER") Then
                        Return
                    End If

                    Select Case Columna
                        Case Me.iGyCodigo
                            If Me.oDocumentos.AFECTA_LOTES_SELECCIONADOS = True Then
BuscaArticulosPorLotes:
                                Dim tLote As New Class_Inventarios_Global.tBusquedaLotes
                                tLote = Me.oInventarios.BusquedaVisual_Lotes(Me.CboAlmacen.SelectedValue.ToString)

                                If txtLEN(tLote.CodigoArticulo) = True Then
                                    If Me.RepiteLote(Renglon, tLote.ID_INVENTARIO_LOTES_COSTOS) = True Then
                                        Return
                                    End If

                                    Me.oArticulos = New Class_CatArticulos(tLote.CodigoArticulo)

                                    Me.InicializaRenglonGrid(Renglon)

                                    Me.Grid1.Cell(Renglon, Me.iGyCodigo).Text = tLote.CodigoArticulo
                                    Me.Grid1.Cell(Renglon, Me.iGyDescripcion).Text = Me.oArticulos.DESCRIPCION
                                    Me.Grid1.Cell(Renglon, Me.iGyCosto).Text = tLote.Costo.ToString
                                    Me.Grid1.Cell(Renglon, Me.iGyID_INVENTARIO_LOTES_COSTOS).Text = tLote.ID_INVENTARIO_LOTES_COSTOS
                                End If

                            Else
                                If e.KeyCode = Keys.F6 Then
BuscaArticulos:
                                    sCodArticulo = Me.oArticulos.BusquedaVisualInventariablesConExistencia_PorDescripcion(Me.CboAlmacen.SelectedValue.ToString)
                                ElseIf e.KeyCode = Keys.F7 Then
                                    sCodArticulo = Me.oArticulos.BusquedaVisualInventariablesConExistencia_PorCodigo(Me.CboAlmacen.SelectedValue.ToString)
                                End If

                                If txtLEN(sCodArticulo) = True Then
                                    Me.Grid1.Cell(Renglon, Me.iGyDescripcion).Text = Me.oArticulos.BuscarNombreArticulo(sCodArticulo)
                                    Me.Grid1.Cell(Renglon, Me.iGyCodigo).Text = sCodArticulo
                                    Me.Grid1.Cell(Renglon, Me.iGyCosto).Text = DCosto.ToString
                                    If Me._LlamadoExteriorGenerarSalidaEmbarque = False Then
                                        Me.Grid1.Cell(Renglon, Me.iGyImporte).Text = "0"
                                        Me.Grid1.Cell(Renglon, Me.iGyCantidad).Text = "0"
                                    End If
                                End If
                                Me.Grid1.Cell(Renglon, iGyCodigo).SetFocus()
                            End If

                        Case Me.iGyCuentaContable
                            If Me.oDocumentos.ES_TRANSFERENCIA = "1" Then
                                Exit Sub
                            Else
BuscarCuentas:
                                'If e.KeyCode = Keys.F6 Then
                                '    sCuentaContable = oCuentas.BusquedaVisual_PorCodigoConLike("1")
                                'Else 'F7
                                '    sCuentaContable = oCuentas.BusquedaVisual_PorDescripcionConLike("1")
                                'End If

                                If e.KeyCode = Keys.F6 Then
                                    sCuentaContable = oCuentas.BusquedaVisual_PorCodigo
                                Else 'F7
                                    sCuentaContable = oCuentas.BusquedaVisual_PorDescripcion
                                End If
                            End If

                            If sCuentaContable = "" Then
                                Return
                            End If

                            If txtLEN(sCuentaContable) = True Then
                                'oCuentas = New Class_VWCatDeudoresDiversos(sCuentaContable)
                                oCuentas = New Class_CatCuentas(sCuentaContable)
                                If oCuentas._Existe = True Then
                                    Me.Grid1.Cell(Renglon, Me.iGyCuentaContable).Text = oCuentas.CUENTA_CONTABLE
                                    Me.Grid1.Cell(Renglon, Me.iGyNombreCuentaContable).Text = oCuentas.NOMBRE_CUENTA
                                    Me.Grid1.Cell(Renglon + 1, iGyCodigo).SetFocus()
                                End If
                            End If
                    End Select

                    '            Case Keys.F7
                    'BuscarCuentas:
                    '                Columna = Me.Grid1.Selection.FirstCol
                    '                Renglon = Me.Grid1.Selection.FirstRow

                    '                If Me.oDocumentos.ES_TRANSFERENCIA = "1" Then
                    '                    Exit Sub
                    '                Else
                    '                    sCuentaContable = Me.oCuentas.BusquedaVisual_PorCodigoFiltrandoTipoOperacion()
                    '                    If txtLEN(sCuentaContable) = True Then
                    '                        Me.oCuentas = New Class_CatCuentas(sCuentaContable)
                    '                        If Me.oCuentas._Existe = True Then
                    '                            Me.Grid1.Cell(Renglon, Me.iGyCuentaContable).Text = Me.oCuentas.CUENTA_CONTABLE
                    '                            Me.Grid1.Cell(Renglon, Me.iGyNombreCuentaContable).Text = Me.oCuentas.NOMBRE_CUENTA_NIVELES_COMPLETOS
                    '                            Me.Grid1.Cell(Renglon + 1, iGyCodigo).SetFocus()
                    '                        End If
                    '                    End If
                    '                End If

                Case Keys.F8, Keys.Delete
                    If Me._LlamadoExteriorGenerarSalidaEmbarque = True Then
                        MsgBox("No se permiten eliminar renglones en las salidas de empaque de embarques.", MsgBoxStyle.Exclamation, sProcedure)
                        e.SuppressKeyPress = True
                        Return
                    End If

                    If (Me.Estado = enumEstados.NUEVO Or Me.Estado = enumEstados.GRABADO) Then
                        Dim IDAdicional As Integer = CInt(Me.Grid1.Cell(Renglon, Me.iGyIDAdicional).Text)

                        Me.Grid1.Selection.DeleteByRow()
                        e.SuppressKeyPress = True
                        Me.Totales()
                        If Me.Grid1.Rows = 1 Then
                            Me.InicializaGrid() 'Para que reestablesca el idAdicional desde el 1
                        End If

                        Me.EliminaDetalleCuentasContables(IDAdicional)
                    End If
            End Select

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Function Grabar(Optional ByVal bMensaje As Boolean = True) As Boolean
        Const sProcedure As String = "Grabar"
        Dim bResultado As Boolean = False
        Dim i As Integer
        Dim sListaSeries As String = ""

        If Me.oDocumentos.ES_TRANSFERENCIA = "1" Then
            If Me.CboAlmacenDestino.SelectedIndex = -1 Then
                MsgBox("Seleccione el almacén destino.", vbExclamation, sProcedure)
                Return False
            End If

            If Me.CboAlmacen.SelectedValue.ToString = Me.CboAlmacenDestino.SelectedValue.ToString Then
                MsgBox("El almacén origen y destino deben ser diferentes en las transferencias.", vbExclamation, sProcedure)
                Return False
            End If

            If Usuario.ValidaPermisoUsuarioTiposDocumentosConAfectaInventarios(Me.CboDocumento.SelectedValue.ToString, Me.CboAlmacen.SelectedValue.ToString, Me.CboAlmacenDestino.SelectedValue.ToString) = False Then
                'MsgBox("El usuario " & Usuario.Nombre_Usuario & " no tiene permiso para realizar la transferencia.", MsgBoxStyle.Information, sProcedure)
                Return False
            End If
        Else
            If Usuario.ValidaPermisoUsuarioTiposDocumentosConAfectaInventarios(Me.CboDocumento.SelectedValue.ToString, Me.CboAlmacen.SelectedValue.ToString, "") = False Then
                'MsgBox("El usuario " & Usuario.Nombre_Usuario & " no tiene permiso para realizar el movimiento de inventarios.", MsgBoxStyle.Information, sProcedure)
                Return False
            End If
        End If

        'If Me.bAplicando = False Then
        If bMensaje = True Then
            If MsgBox("Deseas grabar el movimiento de " & Me.CboDocumento.Text & "?", CType(vbYesNo + vbQuestion, MsgBoxStyle), sProcedure) = MsgBoxResult.No Then
                Return False
            End If
        End If

        If Plaza.ValidarPeriodoTrabajo(Me.DtpFecha.Value) = False Then 'Para grabar se valida con la fecha que el usuario tiene en el datepicker
            Return False
        End If

        If Me.SiTieneRenglones() = False Then
            MsgBox("Asígne los artículos del movimiento.", MsgBoxStyle.Exclamation, sProcedure)
            Return False
        End If

        If txtLEN(Me.txtFolioEmbarque.Text) = True Then
            If Me.ValidaEmbarque = False Then
                Me.txtFolioEmbarque.Focus()
                Return False
            End If
        End If

        Dim oAlmacenOrigen As New Class_CatAlmacenes(Me.CboAlmacen.SelectedValue.ToString)
        Dim oAlmacenDestino As New Class_CatAlmacenes(Me.CboAlmacenDestino.SelectedValue.ToString)
        Dim oAlmacenEntradaFinanciera As New Class_CatAlmacenes 'No se le pasa el código todavia.

        If Me.oDocumentos.ES_TRANSFERENCIA <> "1" AndAlso oAlmacenOrigen.ES_FISCAL = True Then 'Sólo si es almacén es fiscal se afecta a la contabilidad
            If Me.ValidaCuentasContable = False Then
                Return False
            End If
        End If

        If Me.SiTieneCantidad() = False Then
            MsgBox("La cantidad de los artículos debe de ser mayor a cero.", MsgBoxStyle.Exclamation, sProcedure)
            Return False
        End If

        If Me.ValidaNumerosSerie() = False Then
            Return False
        End If

        If Me.HaySeriesRepetidas = True Then
            Return False
        End If

        If Me.oDocumentos.AFECTA_INVENTARIOS = "1" AndAlso txtLEN(Me.txtCliente.Text) = True Then
            Dim oCliente As New Class_CatClientes(Me.txtCliente.Text)
            If oCliente.Existe = False Then
                MsgBox("El cliente asignado no existe.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If
        Else
            Me.txtCliente.Text = "" 'Sólo aplica para movimientos de inventario tipo salidas.
        End If

        Me.Totales()

        If Me.ValidaFlete() = False Then
            Return False
        End If

        If Me.oDocumentos.CODIGO_TIPO_DOCUMENTO = "ER" Then
            If Me.ValidaOrdenCompra = False Then
                Return False
            End If
        End If

        If Empresa_Sistema.ES_ACUICOLA = True Then
            If txtLEN(Me.TxtFolioOrdenProduccion.Text) = True Then
                Dim sql As New Class_find("SELECT FOLIO_MOVIMIENTO_INVENTARIO FROM INVENTARIO_MOVIMIENTOS_GLOBAL WHERE ESTA_CANCELADO='0' AND ESTATUS='A' AND FOLIO_ORDEN_PRODUCCION='" & Me.TxtFolioOrdenProduccion.Text & "'")
                If txtLEN(sql.Result1) Then
                    MsgBox("El folio de orden de producción ya fue capturado en " & sql.Result1, MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If
            End If
        End If

        If Me.oDocumentos.CODIGO_TIPO_DOCUMENTO = "TRF" Then
            oAlmacenEntradaFinanciera = New Class_CatAlmacenes(Me.cboAlmacenEntradaFinanciera.SelectedValue.ToString)

            If oAlmacenOrigen.ES_FISCAL = False Then
                MsgBox("En una transferencia de este tipo el almacén origen debe ser de tipo fiscal.", vbExclamation, sProcedure)
                Return False
            End If

            If oAlmacenDestino.ES_FISCAL = False Then
                MsgBox("En una transferencia de este tipo el almacén destino debe ser de tipo fiscal.", vbExclamation, sProcedure)
                Return False
            End If

            If oAlmacenEntradaFinanciera.ES_FISCAL = True Then
                MsgBox("En una transferencia de este tipo el almacén de entrada debe ser de tipo financiero.", vbExclamation, sProcedure)
                Return False
            End If
        End If

        If Me.oDocumentos.ES_TRANSFERENCIA = "1" And oAlmacenOrigen.ES_FISCAL <> oAlmacenDestino.ES_FISCAL Then
            MsgBox("El almacén origen y destino deben ser del mismo tipo(fiscales o financieros).", vbExclamation, sProcedure)
            Return False
        End If

        If Me.oDocumentos.CODIGO_TIPO_DOCUMENTO = "ER" Then
            If Me.cboMoneda.Text = "USD" Then
                If valorNumericoD(Me.txtTipoCambio.Text) <= 0 Then
                    MsgBox("El tipo de cambio no puede ser cero en esta entrada que proviene de una orden de compra en USD.", vbExclamation, sProcedure)
                    Return False
                End If
            End If
        End If

        If valorNumericoD(Me.txtTotal.Text) <= 0 Then
            MsgBox("El total no puede ser cero.", vbExclamation, sProcedure)
            Return False
        End If

        'Me.oInventarios = New Class_Inventarios_Global

        Select Case Me.Estado
            Case enumEstados.NUEVO, enumEstados.GRABADO
                Me.oInventarios = New Class_Inventarios_Global
                Try
                    With oInventarios
                        .FOLIO_MOVIMIENTO_INVENTARIO = Me.TxtFolio.Text.ToUpper
                        .CODIGO_TIPO_DOCUMENTO = "" & Me.CboDocumento.SelectedValue.ToString()

                        If Me.oDocumentos.CODIGO_TIPO_DOCUMENTO = "ER" Then 'ER=Entrada por compra
                            .FOLIO_REFERENCIA = Me.txtFolioOrdenCompra.Text 'Se graba el folio de la orden de compra como folio de referencias.
                        Else
                            .FOLIO_REFERENCIA = Me.TxtFolioReferencia.Text
                        End If

                        .CODIGO_ALMACEN1 = "" & Me.CboAlmacen.SelectedValue.ToString()
                        If Me.oDocumentos.ES_TRANSFERENCIA = "1" Then
                            .CODIGO_ALMACEN2 = "" & Me.CboAlmacenDestino.SelectedValue.ToString()
                        End If
                        .FECHA = Me.DtpFecha.Value
                        .CONCEPTO = "" & Me.TxtConcepto.Text
                        .CODIGO_USUARIO = CInt("" & Usuario.Codigo_Usuario)
                        .CODIGO_PLAZA = Usuario.Codigo_Plaza
                        .TOTAL = valorNumericoD(Me.txtTotalMasFlete.Text)
                        .FOLIO_EMBARQUE = Me.txtFolioEmbarque.Text
                        .CODIGO_CONCEPTO_INVENTARIOS = CInt(Me.CboConceptoInventario.SelectedValue)
                        .COSTO_TOTAL_BASE = valorNumericoD(Me.txtTotal.Text)
                        .FLETE_TOTAL = valorNumericoD(Me.txtTotalFlete.Text)
                        If Me.oDocumentos.CODIGO_TIPO_DOCUMENTO = "TRF" Then
                            .CODIGO_ALMACEN_ENTRADA_FINANCIERA = Me.cboAlmacenEntradaFinanciera.SelectedValue.ToString
                        Else
                            .CODIGO_ALMACEN_ENTRADA_FINANCIERA = ""
                        End If
                        .FOLIO_ORDEN_PRODUCCION = Me.TxtFolioOrdenProduccion.Text.ToUpper
                        .CODIGO_CLIENTE = Me.txtCliente.Text
                        .TIPO_DE_CAMBIO = valorNumericoD(Me.txtTipoCambio.Text)

                        Select Case Me.Estado
                            Case enumEstados.NUEVO
                                If .Grabar("INSERTAR") = False Then
                                    MsgBox("Error al tratar de agregar el movimiento de inventario.", MsgBoxStyle.Exclamation, sProcedure)
                                    Return False
                                End If
                                Me.TxtFolio.Text = .FOLIO_MOVIMIENTO_INVENTARIO

                            Case enumEstados.GRABADO
                                If .Grabar("ACTUALIZAR") = False Then
                                    MsgBox("Error al tratar de actualizar el movimiento de inventario.", MsgBoxStyle.Exclamation, sProcedure)
                                    Return False
                                End If
                        End Select

                        'se graba el detalle
                        For i = 1 To Me.Grid1.Rows - 1
                            If txtLEN(Me.Grid1.Cell(i, Me.iGyCodigo).Text) = True Then
                                .NuevoRenglon()

                                .oInventariosDetalle.FOLIO_MOVIMIENTO_INVENTARIO = .FOLIO_MOVIMIENTO_INVENTARIO
                                .oInventariosDetalle.CODIGO_ARTICULO = Me.Grid1.Cell(i, Me.iGyCodigo).Text
                                .oInventariosDetalle.CANTIDAD = valorNumerico(Me.Grid1.Cell(i, Me.iGyCantidad).Text)
                                .oInventariosDetalle.COSTO = valorNumerico(Me.Grid1.Cell(i, Me.iGyCostoMasFlete).Text)
                                .oInventariosDetalle.CUENTA_CONTABLE = Me.Grid1.Cell(i, Me.iGyCuentaContable).Text.ToString
                                .oInventariosDetalle.IMPORTE = CDec(valorNumerico(Me.Grid1.Cell(i, Me.iGyImporteMasFlete).Text.ToString))
                                .oInventariosDetalle.ID_ADICIONAL = CInt(valorNumerico(Me.Grid1.Cell(i, Me.iGyIDAdicional).Text))

                                If Me.dtSeries.Rows.Count > 0 Then
                                    For Each dRow In Me.dtSeries.Select("POSICION='" & i.ToString & "'")
                                        sListaSeries = sListaSeries & dRow("POSICION").ToString & "," & dRow("CODIGO_ARTICULO").ToString & "," & dRow("ID_INVENTARIO_LOTES_COSTOS").ToString & "," & dRow("NUMERO_SERIE").ToString & "|"
                                    Next

                                    If txtLEN(sListaSeries) = True Then
                                        sListaSeries = sListaSeries.Substring(0, sListaSeries.Length - 1) 'Para quitarle el último pipe que sale sobrando.
                                    End If
                                End If
                                .oInventariosDetalle.LISTA_SERIES = sListaSeries

                                .oInventariosDetalle.FLETE_DETALLE_IMPORTE = valorNumericoD(Me.Grid1.Cell(i, Me.iGyFleteDetalleImporte).Text.ToString)
                                .oInventariosDetalle.COSTO_DETALLE_BASE = valorNumericoD(Me.Grid1.Cell(i, Me.iGyCosto).Text.ToString)
                                .oInventariosDetalle.IMPORTE_BASE = valorNumericoD(Me.Grid1.Cell(i, Me.iGyImporte).Text.ToString)
                                .oInventariosDetalle.ID_COMPRA_DETALLE = CInt("0" & Me.Grid1.Cell(i, Me.iGyIDCompraDetalle).Text)
                                .oInventariosDetalle.ID_INVENTARIO_LOTES_COSTOS = CInt("0" & Me.Grid1.Cell(i, Me.iGyID_INVENTARIO_LOTES_COSTOS).Text)
                                .oInventariosDetalle.COSTO_USD = valorNumericoD(Me.Grid1.Cell(i, Me.iGyCostoUSD).Text)

                                If .oInventariosDetalle.GrabaRenglon() = False Then
                                    MsgBox("Error al tratar de grabar el detalle.", MsgBoxStyle.Exclamation, sProcedure)
                                    Return False
                                End If

                                sListaSeries = ""
                            End If
                        Next

                        Dim sListaCuentas As String = ""

                        If IsNothing(Me.oFormaDetalleCuentas) = False Then 'Si no esta vacia, osea si existe
                            Me.oFormaDetalleCuentas.FolioMovimientoInventario = Me.TxtFolio.Text 'Hasta aqui la forma auxuliar no tenia el folio
                            sListaCuentas = Me.oFormaDetalleCuentas.ObtieneListaDetalleCuentas()
                        End If

                        If txtLEN(sListaCuentas) = True Then
                            .oInventariosDetalle.GrabaDetalleCentroCostos(sListaCuentas, Me.CboDocumento.SelectedValue.ToString & Usuario.Codigo_Plaza, Me.DtpFecha.Value, CBool(IIf(Me.oDocumentos.NATURALEZA_INVENTARIOS = "EN", True, False)))
                        End If

                        bResultado = True
                        'If Me.bAplicando = False Then
                        If bMensaje = True Then
                            MsgBox("Movimiento de inventario grabado satisfactoriamente.", MsgBoxStyle.Information, sProcedure)
                        End If
                    End With

                Catch ex As Exception
                    HandleError(Me.Name, sProcedure, ex)
                    Me.Consultar()
                Finally
                    Me.oInventarios = Nothing
                End Try
        End Select

        Return bResultado
    End Function

    Function Aplicar() As Boolean
        Const sProcedure As String = "Aplicar"
        Dim bResultado As Boolean = False
        Try
            If Me._LlamadoExteriorGenerarSalidaEmbarque = False Then
                If MsgBox("Deseas aplicar el movimiento de " & CboDocumento.Text & "?", CType(vbYesNo + vbQuestion, MsgBoxStyle), sProcedure) = MsgBoxResult.No Then
                    Return False
                End If

                If Me.Grabar(False) = False Then 'Razón no identificada de porque cuando se trata de exterior lo graba despues de validar, y cuando es normal lo graba antes de validar
                    Return False
                End If
            End If

            'If SiTieneCuentaContable() = False Then
            '    MsgBox("Asígne la cuenta contable de todos los renglones.", MsgBoxStyle.Exclamation, sProcedure)
            '    return false
            'End If

            Dim oAlmacenOrigen As New Class_CatAlmacenes(Me.CboAlmacen.SelectedValue.ToString)

            'Me.oDocumentos = New Class_Cat_tiposDocumentos(Me.CboDocumento.SelectedValue.ToString)
            If Me.oDocumentos.ES_TRANSFERENCIA <> "1" AndAlso oAlmacenOrigen.ES_FISCAL = True Then 'Sólo si es almacén es fiscal se afecta a la contabilidad
                If Me.ValidaCuentasContable = False Then
                    Return False
                End If
            End If

            'If Me.SiTieneImporte() = False Then
            '    MsgBox("El importe de los renglones debe de ser mayor a cero.", MsgBoxStyle.Exclamation, sProcedure)
            '    return false
            'End If

            Me.Totales()

            'If valorNumerico(Me.txtTotal.Text) = 0 Then
            '    MsgBox("El importe total debe de ser mayor a cero.", MsgBoxStyle.Exclamation, sProcedure)
            '    return false
            'End If

            If Me._LlamadoExteriorGenerarSalidaEmbarque = True Then
                If Me.Grabar(False) = False Then 'Razón no identificada de porque cuando se trata de exterior lo graba despues de validar, y cuando es normal lo graba antes de validar
                    Return False
                End If
            Else
                If Me.oDocumentos.ES_TRANSFERENCIA = "1" Then
                    If Me.EstableceCuentaContableAlmacenDestino() = False Then
                        MsgBox("Error al tratar de asígnar la cuenta contable del almacen destino.", MsgBoxStyle.Exclamation, sProcedure)
                        Return False
                    End If
                End If
            End If

            Me.oInventarios = New Class_Inventarios_Global(Me.TxtFolio.Text)

            bResultado = Me.oInventarios.Aplicar()
            If bResultado = True Then
                If Me.oDocumentos.AFECTA_CONTABILIDAD = "1" AndAlso oAlmacenOrigen.ES_FISCAL = True Then 'Sólo si el almacén es fiscal genera la póliza.
                    If Me.oInventarios.AplicarPoliza() = False Then
                        MsgBox("Error al intentar aplicar la póliza.", MsgBoxStyle.Exclamation, sProcedure)
                    End If
                End If
            End If

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    Private Function Cancelar() As Boolean
        Const sProcedure As String = "Cancelar"
        Dim bResultado As Boolean = False
        Dim EsTransformacion As Boolean = False

        Dim oFirmaElectronica As New UtileriasFirmaElectronicaCancelacionMovimientosFueraPeriodo
        Dim oUtileriasCancela As New Class_UtileriasFirmaElectronicaCancelacion
        Dim oPoliza As New Class_Contabilidad_Poliza_Global

        'Posibles valores de ES_CANCELABLE, 0=No es cancelable de ningún modo, 1=Cancelación que generará en automático un movimiento contrario, 2=Cancelable sólo si está en estatus=G

        If Me.oDocumentos.ES_CANCELABLE = "0" Then
            MsgBox("Este documento no se puede cancelar directamente por el usuario.", MsgBoxStyle.Exclamation, sProcedure)
            Return False
        ElseIf Me.oDocumentos.ES_CANCELABLE = "2" Then '2=Cancelable sólo si está en estatus=G
            If Me.oInventarios.ESTATUS <> "G" Then
                MsgBox("Este documento sólo se puede cancelar si esta en estatus de (G)Grabado.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If
        End If

        If Me.oDocumentos.ES_TRANSFERENCIA = "1" Then
            If Usuario.ValidaPermisoUsuarioTiposDocumentosConAfectaInventarios(Me.CboDocumento.SelectedValue.ToString, Me.CboAlmacen.SelectedValue.ToString, Me.CboAlmacenDestino.SelectedValue.ToString) = False Then
                'Nota, la propia validación ya regresa mensaje
                'MsgBox("El usuario " & Usuario.Nombre_Usuario & " no tiene permiso para realizar la transferencia.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If
        Else
            If Usuario.ValidaPermisoUsuarioTiposDocumentosConAfectaInventarios(Me.CboDocumento.SelectedValue.ToString, Me.CboAlmacen.SelectedValue.ToString, "") = False Then
                'Nota, la propia validación ya regresa mensaje
                'MsgBox("El usuario " & Usuario.Nombre_Usuario & " no tiene permiso para realizar el movimiento de inventarios.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If
        End If

        If Me.ValidaEsTransformacion(Me.TxtFolio.Text, Me.oInventarios.CODIGO_TIPO_DOCUMENTO) Then
            EsTransformacion = True

            'La salida de transformacion no se puede cancelar directamente
            If Me.oInventarios.CODIGO_TIPO_DOCUMENTO = "SAI" Then
                Dim sql As New Class_find("SELECT FOLIO_ENTRADA_TRANSFORMACION FROM INVENTARIOS_TRANSFORMACIONES_RELACION_ENTRADAS_SALIDAS WHERE FOLIO_SALIDA_TRANSFORMACION='" & Me.TxtFolio.Text & "' ")
                MsgBox("Las salidas por transformación no se pueden cancelar directamente, debe cancelarse desde la entrada " & sql.Result1 & " para que se cancele la salida automaticamente.", MsgBoxStyle.Exclamation, Me.Text)
                Return False
            End If
        End If

        If (Me.oInventarios.CODIGO_TIPO_DOCUMENTO = "ENI" Or Me.oInventarios.CODIGO_TIPO_DOCUMENTO = "ER") And Me.oInventarios.ESTATUS = "A" Then
            If Me.oInventarios.CODIGO_TIPO_DOCUMENTO = "ER" Then 'Valida que la entrada no tenga compras aplicadas
                If Me.ValidaComprasEntradasRecepcion() = False Then
                    Return False
                End If
            End If

            If oInventarios.ValidaExistencias() = False Then 'Esta funcion porque tambien valida series
                Return False
            End If
        End If

        If MsgBox("Deseas cancelar el movimiento de " & Me.CboDocumento.Text & "?", CType(vbYesNo + vbQuestion, MsgBoxStyle), sProcedure) = MsgBoxResult.No Then
            Return False
        End If

        'If PLAZA.ValidarPeriodoTrabajo(Date.Now) = False Then 'Para cancelar se valida con la fecha de la maquina
        '    return false
        'End If

        Try
            oUtileriasCancela.FOLIO_DOCUMENTO = Me.TxtFolio.Text.ToUpper
            oUtileriasCancela.MODULO = Me.oInventarios.CODIGO_MODULO
            oUtileriasCancela.CODIGO_PLAZA = Usuario.Codigo_Plaza

            If oUtileriasCancela.GestionaCancelacion() = False Then
                Return False
            End If

            If oUtileriasCancela.CANCELA_DIRECTO = True Then
                Me.oInventarios.FECHA_CANCELACION = Date.Now

                If EsTransformacion = False Then
                    If Me.oInventarios.Cancelar() = False Then
                        Return False
                    End If
                Else
                    'Si es una entrada por transformacion usara otro metodo que cancelara la salida de materia prima tambien
                    If Me.oInventarios.CancelarTransformacion() = False Then
                        Return False
                    End If
                End If
            Else
                oUtileriasCancela = New Class_UtileriasFirmaElectronicaCancelacion
                oUtileriasCancela.FOLIO_DOCUMENTO = Me.TxtFolio.Text
                oUtileriasCancela.FOLIO_POLIZA = Me.oInventarios.FOLIO_POLIZA
                oUtileriasCancela.CODIGO_DOCUMENTO = Me.CboDocumento.SelectedValue.ToString
                oUtileriasCancela.CODIGO_PLAZA = Usuario.Codigo_Plaza
                oUtileriasCancela.MODULO = Me.oInventarios.CODIGO_MODULO

                If oUtileriasCancela.AutorizaCancelacionMovimientosFueraPeriodo() = False Then
                    'MsgBox("Error al tratar de autorizar la cancelación fuera del periodo.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If

                'si no se autorizo
                If oUtileriasCancela.CANCELACION_AUTORIZO = False Then
                    MsgBox("No se autorizó la cancelación de movimiento.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If

                If oUtileriasCancela.GestionaCancelacionConInterfaz() = False Then
                    MsgBox("Error al gestionar la cancelacion con interfaz", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                Else
                    If oUtileriasCancela.ES_FECHA_CANCELACION_VALIDA = "0" Then
                        MsgBox("La fecha de cancelación debe de ser mayor o igual a la fecha del documento y debe estar en el mismo ejercicio.", vbExclamation, sProcedure)
                        Return False
                    End If

                    Me.oInventarios.FECHA_CANCELACION = oUtileriasCancela.FECHA_CANCELACION  'CDate(Format(oUtileriasCancela.CANCELACION_NUEVA_FECHA_CANCELACION, "dd/MM/yyyy")) + " " + CDate(Format(Now, "hh:mm"))
                    'oPoliza.ID_CON_PERIODO = oUtileriasCancela.PERIODO_CANCELACION_INTERFAZ

                    If EsTransformacion = False Then
                        If Me.oInventarios.Cancelar() = False Then
                            MsgBox("Error al intentar cancelar el movimiento de inventario.", MsgBoxStyle.Exclamation, sProcedure)
                            Return False
                        End If
                    Else
                        'Si es una entrada por transformacion usara otro metodo que cancelara la salida de materia prima tambien
                        If Me.oInventarios.CancelarTransformacion() = False Then
                            MsgBox("Error al intentar cancelar el movimiento de inventario.", MsgBoxStyle.Exclamation, sProcedure)
                            Return False
                        End If
                    End If

                End If
            End If

            MsgBox("Movimiento de inventario cancelado satisfactoriamente.", MsgBoxStyle.Information, sProcedure)
            bResultado = True

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    Private Function ValidarExistencias() As Boolean
        Const sProcedure As String = "ValidarExistencias"
        Dim bResultado As Boolean = False

        Dim dCantidadSumadaPorArticulos As Double, dExistencia As Double, dCantidad As Decimal = 0, dDiferencia As Double = 0
        Dim i As Integer, sCodigoArticulo As String = ""

        Try
            'If oInventarios.NATURALEZA_INVENTARIOS = "EN" Then
            '    ValidarExistencias = True
            '    return false
            'End If

            'Este método ya no funciona porque le grid no se llena con datasource sino con ciclo, porque con datasource ya no funciona el f8, no borra
            'Dim dt As DataTable = DirectCast(Me.Grid1.DataSource, DataTable)

            For i = 1 To Me.Grid1.Rows - 1
                sCodigoArticulo = Me.Grid1.Cell(i, Me.iGyCodigo).Text
                dCantidad = valorNumericoD(Me.Grid1.Cell(i, Me.iGyCantidad).Text)

                If txtLEN(sCodigoArticulo) = True Then
                    Me.oArticulos = New Class_CatArticulos(sCodigoArticulo)
                    If Me.oArticulos.INVENTARIABLE <> "0" Then

                        If Me.oDocumentos.AFECTA_LOTES_SELECCIONADOS = True Then
                            dExistencia = oInventarios.ExistenciaLoteSerie(Me.Grid1.Cell(i, Me.iGyID_INVENTARIO_LOTES_COSTOS).Text)
                        Else
                            dExistencia = oInventarios.Existencia(sCodigoArticulo, Me.CboAlmacen.SelectedValue.ToString)
                        End If

                        If dExistencia <= 0 Then
                            Me.Show()
                            MsgBox("El artículo " & Me.Grid1.Cell(i, Me.iGyDescripcion).Text & " del renglón #" & i.ToString & " no tiene existencia. ", MsgBoxStyle.Exclamation, sProcedure)
                            Return False
                        Else
                            If Me.oDocumentos.AFECTA_LOTES_SELECCIONADOS = True Then
                                'Aqui no es necesario computar o agrupar por artículo porque al ser un lote especifico se evalua el disponible del mismo.

                                If dCantidad > dExistencia Then 'if capturaron>existencia
                                    dDiferencia = Redondear(dCantidad - dExistencia, Empresa_Sistema.DECIMALES_CANTIDAD)
                                    MsgBox("El artículo " & Me.Grid1.Cell(i, Me.iGyDescripcion).Text & " del renglón #" & i.ToString & " no tiene suficiente existencia." & vbCrLf &
                                            "Existencia ''del lote'' " & Format(dExistencia, "###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CANTIDAD)) &
                                            ", faltan " & Format(dDiferencia, "###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CANTIDAD)), MsgBoxStyle.Exclamation, sProcedure)

                                    Return False
                                End If

                            Else
                                If Me._LlamadoExteriorGenerarSalidaEmbarque = False Then
                                    'dCantidadSumadaPorArticulos = CDbl(dt.Compute("sum(CANTIDAD)", "CODIGO_ARTICULO='" & Me.Grid1.Cell(i, Me.iGyCodigo).Text & "'"))
                                    dCantidadSumadaPorArticulos = FG_Grid_ComputeCol(Me.Grid1, sCodigoArticulo, Me.iGyCodigo, Me.iGyCantidad)
                                Else
                                    dCantidadSumadaPorArticulos = CDbl(Me.Grid1.Cell(i, Me.iGyCantidad).Text)
                                End If

                                If dCantidadSumadaPorArticulos > dExistencia Then
                                    dDiferencia = Redondear(dCantidadSumadaPorArticulos - dExistencia, Empresa_Sistema.DECIMALES_CANTIDAD)

                                    Me.Show()
                                    MsgBox("El artículo " & Me.Grid1.Cell(i, Me.iGyDescripcion).Text & " del renglón #" & i.ToString & " no tiene suficiente existencia." & vbCrLf &
                                            "Existencia " & Format(dExistencia, "###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CANTIDAD)) &
                                            ", faltan " & Format(dDiferencia, "###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CANTIDAD)), MsgBoxStyle.Exclamation, sProcedure)
                                    Return False
                                End If
                            End If

                        End If
                    End If
                End If
            Next i

            bResultado = True
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    Private Sub Imprimir()
        Dim StrFiltros As String = ""
        Dim FormatoDeReporte As String
        Dim Rpt As New ReportDocument
        Dim oReporte As Class_Reporte
        Try
            If Me.oDocumentos.CODIGO_TIPO_DOCUMENTO = "TRI" Or Me.oDocumentos.CODIGO_TIPO_DOCUMENTO = "TRF" Then
                FormatoDeReporte = "RPT_FORMATO_INVENTARIO_TRANSFERENCIA"
            Else
                FormatoDeReporte = "RPT_FORMATO_MOVIMIENTO_INVENTARIO"
            End If

            oReporte = New Class_Reporte(FormatoDeReporte, Rpt, False)
            If Not oReporte.RptCargado Then
                Exit Sub
            End If
            Rpt.SetParameterValue("@FOLIO_MOVIMIENTO_INVENTARIO", Me.TxtFolio.Text)

            If FormatoDeReporte = "RPT_FORMATO_MOVIMIENTO_INVENTARIO" Then
                Rpt.SetParameterValue("@CODIGO_USUARIO", Usuario.Codigo_Usuario)
            End If

            Dim frm As New Reporte(Rpt)
            frm.CRViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            frm.Show()
        Catch ex As Exception
            HandleError(Me.Name, "Imprimir", ex)
        Finally
            oReporte = Nothing
        End Try
    End Sub

    Private Sub DesplegarDocumentos(Optional ByVal bAccesibileUsuarios As Boolean = True)
        Try
            Dim oElementos As New Class_CatDocumentos
            With Me.CboDocumento
                .DisplayMember = "NOMBRE_TIPO_DOCUMENTO"
                .ValueMember = "CODIGO_TIPO_DOCUMENTO"
                Dim dView As New Data.DataView(oElementos.ObtenerTipoDocumentos("INV", Usuario.Codigo_Plaza.ToString, IIf(bAccesibileUsuarios = True, " ESTATUS_DOCUMENTO='A' AND ACCESIBLE_USUARIO='1' ", " ESTATUS_DOCUMENTO='A' ").ToString))
                dView.Sort = "NOMBRE_TIPO_DOCUMENTO"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedIndex = 0
                End If
                '.SelectedValue = Usuario.Codigo_Almacen
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarDocumentos", ex)
        End Try
    End Sub

    Private Sub DesplegarAlmacenes()
        Try
            Dim oElementos As New Class_CatAlmacenes
            With Me.CboAlmacen
                .DisplayMember = "NOMBRE_ALMACEN"
                .ValueMember = "CODIGO_ALMACEN"
                Dim dView As New Data.DataView(oElementos.ObtenerAlmacenes)
                dView.Sort = "NOMBRE_ALMACEN"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedIndex = 0
                End If
                .SelectedValue = Usuario.Codigo_Almacen
            End With

            With Me.CboAlmacenDestino
                .DisplayMember = "NOMBRE_ALMACEN"
                .ValueMember = "CODIGO_ALMACEN"
                Dim dView As New Data.DataView(oElementos.ObtenerAlmacenes)
                dView.Sort = "NOMBRE_ALMACEN"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedIndex = 0
                End If
                .SelectedValue = Usuario.Codigo_Almacen
            End With

            With Me.cboAlmacenEntradaFinanciera
                .DisplayMember = "NOMBRE_ALMACEN"
                .ValueMember = "CODIGO_ALMACEN"
                Dim dView As New Data.DataView(oElementos.ObtenerAlmacenes)
                dView.Sort = "NOMBRE_ALMACEN"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedIndex = 0
                End If
                .SelectedValue = Usuario.Codigo_Almacen
            End With

            Me.GeneraFolio()
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarAlmacenes", ex)
        End Try
    End Sub

    Private Sub DesplegarConceptosInventarios()
        Try
            Dim oElementos As New Class_CatConceptosInventarios
            With Me.CboConceptoInventario
                .DisplayMember = "NOMBRE_CONCEPTO_INVENTARIOS"
                .ValueMember = "CODIGO_CONCEPTO_INVENTARIOS"
                Dim dView As New Data.DataView(oElementos.ObtenerElementos)
                dView.Sort = "NOMBRE_CONCEPTO_INVENTARIOS"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedIndex = 0
                End If
                .SelectedValue = 0
            End With

            Me.GeneraFolio()
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarConceptosInventarios", ex)
        End Try
    End Sub

    Private Function BusquedaVisual_PorDescripcion() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de Inventarios."
        f.sCampo = "FOLIO_MOVIMIENTO_INVENTARIO"
        f.sOrder = "FOLIO_MOVIMIENTO_INVENTARIO"
        f.sTable = "INVENTARIO_MOVIMIENTOS_GLOBAL"
        f.sQl = "Select FOLIO_MOVIMIENTO_INVENTARIO AS FOLIO,CODIGO_TIPO_DOCUMENTO AS DOCUMENTO,TOTAL From INVENTARIO_MOVIMIENTOS_GLOBAL Where 1=1 And CODIGO_TIPO_DOCUMENTO IN (select CODIGO_TIPO_DOCUMENTO from sis_tipos_documentos WHERE CODIGO_MODULO='INV') AND "
        f.Inicia("")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            End If
        Catch ex As Exception
            HandleError(Me.Name, "BusquedaVisual_PorDescripcion", ex)
        End Try
        Return Resultado
    End Function

    Private Function GeneraFolio() As Boolean
        Try
            If Me.Consultando = True Then
                Return False
            End If

            Dim sFolio As String = ""
            If Me.CboAlmacen.Items.Count = 0 Or Me.CboDocumento.Items.Count = 0 Then
                Exit Function
            End If

            If Me._LlamadoExteriorGenerarSalidaEmbarque = True And Me._ConsultaExteriorSalida = False Then
                'Dim sCaracter As String = "", VarString As String = ""
                'Dim sql As New Class_find("select max(FOLIO_MOVIMIENTO_INVENTARIO)FOLIO_MOVIMIENTO_INVENTARIO from INVENTARIO_MOVIMIENTOS_GLOBAL where  FOLIO_REFERENCIA='" & Me.TxtFolioReferencia.Text & "'")
                'sFolio = Me.TxtFolioReferencia.Text
                'If InStr(sFolio, "-") > 0 Then
                '    sFolio = Strings.Right(Me.TxtFolioReferencia.Text, 6)
                'End If

                'If txtLEN(sql.Result1) = True Then

                '    VarString = sql.Result1.ToString
                '    sCaracter = VarString.Substring(3, 1)
                '    If txtLEN(sCaracter) = False And IsNumeric(sCaracter) = True Then
                '        sCaracter = "A"
                '    Else
                '        sCaracter = Chr(Asc(sCaracter) + 1)
                '    End If
                'End If
                ''Me.TxtFolio.Text = Empresa_Sistema.CODIGO_TIPO_DOCUMENTO_SALIDA_EMPAQUE.ToString & sCaracter & Me.CboAlmacen.SelectedValue.ToString & "-" & sFolio
                'Me.TxtFolio.Text = _CodigoDocumentoParaGrabar.ToString & sCaracter & Me.CboAlmacen.SelectedValue.ToString & "-" & sFolio

            ElseIf Me._LlamadoExteriorGenerarSalidaEmbarque = False And Me._ConsultaExteriorSalida = False Then
                Me.oInventarios = New Class_Inventarios_Global
                Me.oInventarios.CODIGO_TIPO_DOCUMENTO = Me.CboDocumento.SelectedValue.ToString
                Me.oInventarios.CODIGO_ALMACEN1 = Me.CboAlmacen.SelectedValue.ToString

                Me.TxtFolio.Text = Me.oInventarios.GeneraFolioInventarios()
            End If
        Catch ex As Exception
            HandleError(Me.Name, "GeneraFolio", ex)
        End Try
    End Function

    Private Function Consultar() As Boolean
        Dim bResultado As Boolean = False
        Try

            Me.oInventarios = New Class_Inventarios_Global()
            Dim sFolio As String = Me.TxtFolio.Text

            If Me._LlamadoExteriorGenerarSalidaEmbarque = True And txtLEN(Me.FolioEmbarque) = True Then
                'No debe inicializar, ya se ejecutó el inicializaExterno
            Else
                Me.Inicializa()
            End If

            Me.oInventarios.FOLIO_MOVIMIENTO_INVENTARIO = sFolio

            If Me.oInventarios.Consultar = False Then
                Me.Cambia_Estado(enumEstados.NUEVO)
                Return False
            End If

            Me.Consultando = True

            If Me.CboDocumento.SelectedValue.ToString <> oInventarios.CODIGO_TIPO_DOCUMENTO Then
                Me.GeneraFolio()
                Return False
            End If

            Me.TxtFolio.Text = oInventarios.FOLIO_MOVIMIENTO_INVENTARIO.ToUpper
            Me.CboDocumento.SelectedValue = oInventarios.CODIGO_TIPO_DOCUMENTO.ToUpper

            Me.lblStatus.Text = oInventarios.ESTATUS.ToUpper
            Me.CboAlmacen.SelectedValue = oInventarios.CODIGO_ALMACEN1.ToUpper

            If oInventarios.CODIGO_TIPO_DOCUMENTO.ToString.ToUpper = "TRI" Or oInventarios.CODIGO_TIPO_DOCUMENTO.ToString.ToUpper = "TRF" Or oInventarios.CODIGO_TIPO_DOCUMENTO.ToString.ToUpper = "TRLT" Then
                Me.CboAlmacenDestino.SelectedValue = oInventarios.CODIGO_ALMACEN2.ToUpper
            End If

            If oInventarios.CODIGO_TIPO_DOCUMENTO.ToString.ToUpper = "TRF" Then
                Me.cboAlmacenEntradaFinanciera.SelectedValue = oInventarios.CODIGO_ALMACEN_ENTRADA_FINANCIERA
                Me.txtFolioEntradaFinanciera.Text = oInventarios.FOLIO_ENTRADA_FINANCIERA
            End If

            Me.TxtFolioReferencia.Text = oInventarios.FOLIO_REFERENCIA.ToUpper
            Me.TxtConcepto.Text = oInventarios.CONCEPTO.ToUpper
            Me.txtTotal.Text = FormatImporteContable(oInventarios.COSTO_TOTAL_BASE)
            Me.lblPoliza.Text = oInventarios.FOLIO_POLIZA
            Me.DtpFecha.Value = CDate(oInventarios.FECHA)
            Me.txtFolioEmbarque.Text = oInventarios.FOLIO_EMBARQUE
            Me.CboConceptoInventario.SelectedValue = oInventarios.CODIGO_CONCEPTO_INVENTARIOS
            Me.TxtFolioOrdenProduccion.Text = oInventarios.FOLIO_ORDEN_PRODUCCION

            Me.txtTotalMasFlete.Text = FormatImporteContable(oInventarios.TOTAL)

            If Me.CboDocumento.SelectedValue.ToString = "ER" Or Me.CboDocumento.SelectedValue.ToString = "TRI" Or oInventarios.CODIGO_TIPO_DOCUMENTO.ToString.ToUpper = "TRF" Or oInventarios.CODIGO_TIPO_DOCUMENTO.ToString.ToUpper = "TRLT" Then
                Me.txtFolioOrdenCompra.Text = oInventarios.FOLIO_REFERENCIA
                Me.txtFleteOrdenCompra.Text = FormatImporteContable(oInventarios.FLETE_TOTAL)
                Me.txtTotalFlete.Text = FormatImporteContable(oInventarios.FLETE_TOTAL)
            End If

            Me.txtCliente.Text = oInventarios.CODIGO_CLIENTE

            If txtLEN(oInventarios.CODIGO_CLIENTE) = True Then
                Dim oCliente As New Class_CatClientes(oInventarios.CODIGO_CLIENTE)
                Me.lblCliente.Text = oCliente.NOMBRE_CLIENTE
                oCliente = Nothing
            End If

            Me.Grid1.Visible = True

            'Si es una salida por transformación y tiene formula confidencial oculta el grid si el usuario no tiene permiso de verla
            If Me.oInventarios.CODIGO_TIPO_DOCUMENTO = "SAI" Then
                If Me.ValidaEsTransformacion(Me.TxtFolio.Text, Me.oInventarios.CODIGO_TIPO_DOCUMENTO) Then

                    Dim sql As New Class_find("SELECT CODIGO_FORMULA FROM INVENTARIOS_TRANSFORMACIONES_RELACION_ENTRADAS_SALIDAS WHERE FOLIO_SALIDA_TRANSFORMACION='" & Me.TxtFolio.Text & "'")
                    Dim oFormula As New Class_CatFormulas(sql.Result1)

                    If oFormula.ES_CONFIDENCIAL And Usuario.PERMISOS_FORMULAS_CONFIDENCIALES = False Then
                        Me.Grid1.Visible = False
                    End If

                End If
            End If

            'Consulta datos detalle
            'Me.Grid1.DataSource = Me.oInventarios.ObtenerDetalle
            Dim dTabla As DataTable = Me.oInventarios.ObtenerDetalle
            Me.Grid1.AutoRedraw = False
            Me.Grid1.Rows = 1 'Trae dos porque en docs nuevos se pone un row en blanco, y si se dejan aqui dos agrega a partir del 3 y queda un hueco
            For Each dRow As DataRow In dTabla.Rows
                Me.Grid1.AddItem(dRow("CODIGO_ARTICULO").ToString & Chr(9) & dRow("DESCRIPCION").ToString & Chr(9) & dRow("CANTIDAD").ToString & Chr(9) & dRow("COSTO_DETALLE_BASE").ToString & Chr(9) & dRow("IMPORTE_BASE").ToString & Chr(9) &
                                dRow("Boton").ToString & Chr(9) & dRow("CUENTA_CONTABLE").ToString & Chr(9) & dRow("NOMBRE_CUENTA").ToString & Chr(9) & dRow("ID_ADICIONAL").ToString & Chr(9) &
                                dRow("FLETE_DETALLE_IMPORTE").ToString & Chr(9) & dRow("COSTO_DETALLE").ToString & Chr(9) & dRow("IMPORTE_BASE").ToString & Chr(9) & dRow("ID_COMPRA_DETALLE").ToString & Chr(9) & dRow("DISPONIBLE").ToString & Chr(9) &
                                dRow("ID_INVENTARIO_LOTES_COSTOS").ToString & Chr(9) & dRow("COSTO_USD").ToString & Chr(9))
            Next

            If Me.lblStatus.Text = "G" Then
                Me.Grid1.Rows = Me.Grid1.Rows + 1

                If dTabla.Rows.Count > 0 Then
                    Me.Grid1.Cell(Me.Grid1.Rows - 1, Me.iGyIDAdicional).Text = (CInt(Me.Grid1.Cell(Me.Grid1.Rows - 2, Me.iGyIDAdicional).Text) + 1).ToString
                Else
                    Me.Grid1.Cell(Me.Grid1.Rows - 1, Me.iGyIDAdicional).Text = "1"
                End If

            End If

            Me.Grid1.AutoRedraw = True
            Me.Grid1.Refresh()
            Me.FormateaGrid()

            Me.dtSeries = oInventarios.ObtenerDetalleSeries(Me.TxtFolio.Text)
            Me.GridSeries.DataSource = dtSeries
            Me.FormateaGridSeries()

            'Aqui ya esta locked true igySerieNumeroSerie(lo hizo en el FormateaGridSeries)
            If dtSeries.Rows.Count > 0 Then 'En este punto esta bloqueado el campo para teclear la serie
                If Me.CboDocumento.SelectedValue.ToString = "ENI" Or Me.CboDocumento.SelectedValue.ToString = "ER" Then
                    Me.GridSeries.Column(Me.igySerieNumeroSerie).Locked = False
                End If
                'Nota si fueran salidas o transferencias no se ocupa desbloquedar porqu dejaria teclear y no es asi, debe ser con F6 la selección, y el F6 funciona aún con locked true
            End If

            'Me.Totales() 'Nota, no debemos totalizar al consultar porque pudieramos ocultar errores de grabado si es que los hay, como nos pasó cuando no actualizabamos el importe de salidas aplicadas

            Me.txtTotalCantidad.Text = FormatCantidad(FG_Grid_SumaCol(Me.Grid1, CShort(Me.iGyCantidad))) 'Esta valor no se graba en el total, por eso se calcula aquí

            Me.oFormaDetalleCuentas = New InventariosDetalleCuentasContables(Me.TxtFolio.Text)

            If Me.oFormaDetalleCuentas.dTablaPrepoliza.Rows.Count = 0 Then
                Me.oFormaDetalleCuentas = Nothing 'Forza para dejarla vacia
            Else
                'Consultar
            End If

            bResultado = True

            If Me.lblStatus.Text = "G" Then
                Me.Estado = enumEstados.GRABADO
            ElseIf Me.lblStatus.Text = "A" Then
                Me.Estado = enumEstados.APLICADO
            ElseIf Me.lblStatus.Text = "C" Then
                Me.Estado = enumEstados.CANCELADO
            End If

            Me.Cambia_Estado(Me.Estado)

            Me.tsslElaboro.Text = "ELABORO: " + Me.oInventarios.NOMBRE_USUARIO.ToUpper + " EL " + Format(Me.DtpFecha.Value, "dd/MMM/yy")

            If Me.lblStatus.Text = "C" Then
                Me.tsslCancelo.Text = "CANCELO: " + Me.oInventarios.NOMBRE_USUARIO_CANCELO.ToUpper + " EL " + Format(Me.oInventarios.FECHA_CANCELACION, "dd/MMM/yy")
            End If

        Catch ex As Exception
            HandleError(Me.Name, "Consultar", ex)
        Finally
            Me.Consultando = False
        End Try

        Return bResultado
    End Function

    'Private Sub FormateaGrid()
    '    Try
    '        Me.Grid1.Cols = 8

    '        Me.Grid1.Column(Me.iGyCodigo).Width = 100
    '        Me.Grid1.Column(Me.iGyDescripcion).Width = 190
    '        Me.Grid1.Column(Me.iGyCantidad).Width = 80
    '        Me.Grid1.Column(Me.iGyCosto).Width = 100
    '        Me.Grid1.Column(Me.iGyImporte).Width = 100
    '        Me.Grid1.Column(Me.iGyCuentaContable).Width = 110
    '        Me.Grid1.Column(Me.iGyNombreCuentaContable).Width = 220

    '        Me.Grid1.Cell(0, Me.iGyCodigo).Text = "Codigo"
    '        Me.Grid1.Cell(0, Me.iGyDescripcion).Text = "Descripcion"
    '        Me.Grid1.Cell(0, Me.iGyCantidad).Text = "Cantidad"
    '        Me.Grid1.Cell(0, Me.iGyCosto).Text = "Costo"
    '        Me.Grid1.Cell(0, Me.iGyImporte).Text = "Total"
    '        Me.Grid1.Cell(0, Me.iGyCuentaContable).Text = "CuentaContable"
    '        Me.Grid1.Cell(0, Me.iGyNombreCuentaContable).Text = "Nombre cuenta"

    '        Me.Grid1.Column(Me.iGyCantidad).Mask = FlexCell.MaskEnum.Numeric
    '        Me.Grid1.Column(Me.iGyCantidad).DecimalLength = Empresa_Sistema.DECIMALES_CANTIDAD
    '        Me.Grid1.Column(Me.iGyCantidad).Alignment = FlexCell.AlignmentEnum.RightCenter

    '        Me.Grid1.Column(Me.iGyCosto).Mask = FlexCell.MaskEnum.Numeric
    '        Me.Grid1.Column(Me.iGyCosto).DecimalLength = Empresa_Sistema.DECIMALES_PRECIO
    '        Me.Grid1.Column(Me.iGyCosto).Alignment = FlexCell.AlignmentEnum.RightCenter

    '        Me.Grid1.Column(Me.iGyImporte).Mask = FlexCell.MaskEnum.Numeric
    '        Me.Grid1.Column(Me.iGyImporte).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
    '        Me.Grid1.Column(Me.iGyImporte).Alignment = FlexCell.AlignmentEnum.RightCenter

    '        Me.Grid1.Column(Me.iGyCuentaContable).Alignment = FlexCell.AlignmentEnum.RightCenter
    '        Me.Grid1.Column(Me.iGyDescripcion).Locked = True
    '        Me.Grid1.Column(Me.iGyImporte).Locked = True

    '    Catch ex As Exception
    '        HandleError(Me.Name, "FormateaGrid", ex)
    '    End Try
    'End Sub

    Private Sub FormateaGrid()
        Try
            With Me.Grid1
                .AutoRedraw = False
                .Cols = 17
                '.DefaultFont = New Font("Tahoma", 8)
                .DisplayFocusRect = False
                '.DisplayDateTimeMask = True
                '.ExtendLastCol = True
                .DrawMode = FlexCell.DrawModeEnum.OwnerDraw
                .BorderStyle = FlexCell.BorderStyleEnum.FixedSingle
                .FixedRowColStyle = FlexCell.FixedRowColStyleEnum.Flat

                '.BackColorFixed = Color.FromArgb(90, 158, 214)
                '.BackColorFixedSel = Color.FromArgb(110, 180, 230)
                '.BackColorBkg = Color.FromArgb(90, 158, 214)
                .BackColor1 = Color.FromArgb(231, 235, 247)
                .BackColor2 = Color.FromArgb(239, 243, 255)
                .CellBorderColorFixed = Color.Black
                .GridColor = Color.FromArgb(148, 190, 231)

                .Cell(0, Me.iGyCodigo).Text = "Codigo"
                .Cell(0, Me.iGyDescripcion).Text = "Descripcion"
                .Cell(0, Me.iGyCantidad).Text = "Cantidad"
                .Cell(0, Me.iGyCosto).Text = "Costo"
                .Cell(0, Me.iGyImporte).Text = "Total"
                .Cell(0, Me.iGyBoton).Text = "Costos"
                .Cell(0, Me.iGyCuentaContable).Text = "CuentaContable"
                .Cell(0, Me.iGyNombreCuentaContable).Text = "Nombre cuenta"
                .Cell(0, Me.iGyIDAdicional).Text = "IDAdicional"
                .Cell(0, Me.iGyCostoMasFlete).Text = "Costo+Flete"
                .Cell(0, Me.iGyFleteDetalleImporte).Text = "FleteImporte"
                .Cell(0, Me.iGyImporteMasFlete).Text = "Importe+Flete"
                .Cell(0, Me.iGyIDCompraDetalle).Text = "IDCompraDetalle"
                .Cell(0, Me.iGyDisponible).Text = "Disponible"
                .Cell(0, Me.iGyID_INVENTARIO_LOTES_COSTOS).Text = "ID_INVENTARIO_LOTES_COSTOS"
                .Cell(0, Me.iGyCostoUSD).Text = "CostoUSD" 'De momento este costo sólo se usa cuando son entradas por recepción de compras.

                .Column(Me.iGyCantidad).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyCantidad).DecimalLength = Empresa_Sistema.DECIMALES_CANTIDAD
                .Column(Me.iGyCantidad).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGyDisponible).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyDisponible).DecimalLength = Empresa_Sistema.DECIMALES_CANTIDAD
                .Column(Me.iGyDisponible).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGyCosto).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyCosto).DecimalLength = Empresa_Sistema.DECIMALES_PRECIO
                .Column(Me.iGyCosto).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGyImporte).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyImporte).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
                .Column(Me.iGyImporte).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGyCuentaContable).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGyFleteDetalleImporte).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyFleteDetalleImporte).DecimalLength = Empresa_Sistema.DECIMALES_PRECIO
                .Column(Me.iGyFleteDetalleImporte).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGyCostoMasFlete).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyCostoMasFlete).DecimalLength = Empresa_Sistema.DECIMALES_PRECIO
                .Column(Me.iGyCostoMasFlete).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGyImporteMasFlete).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyImporteMasFlete).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
                .Column(Me.iGyImporteMasFlete).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGyCostoUSD).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyCostoUSD).DecimalLength = Empresa_Sistema.DECIMALES_PRECIO
                .Column(Me.iGyCostoUSD).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGyBoton).CellType = FlexCell.CellTypeEnum.Button

                .Column(Me.iGyDescripcion).Locked = True
                .Column(Me.iGyImporte).Locked = True
                .Column(Me.iGyNombreCuentaContable).Locked = True
                .Column(Me.iGyIDAdicional).Locked = True
                .Column(Me.iGyCostoMasFlete).Locked = True
                .Column(Me.iGyImporteMasFlete).Locked = True
                .Column(Me.iGyIDCompraDetalle).Locked = True
                .Column(Me.iGyCostoUSD).Locked = True

                .Column(Me.iGyCodigo).Width = 100
                .Column(Me.iGyDescripcion).Width = 190
                .Column(Me.iGyCantidad).Width = 80
                .Column(Me.iGyCosto).Width = 100
                .Column(Me.iGyImporte).Width = 100
                .Column(Me.iGyCuentaContable).Width = 110
                .Column(Me.iGyNombreCuentaContable).Width = 220
                .Column(Me.iGyIDAdicional).Visible = False
                .Column(Me.iGyCostoMasFlete).Visible = False
                .Column(Me.iGyImporteMasFlete).Visible = False
                .Column(Me.iGyIDCompraDetalle).Visible = False
                .Column(Me.iGyDisponible).Visible = False
                .Column(Me.iGyID_INVENTARIO_LOTES_COSTOS).Visible = False
                .Column(Me.iGyCostoUSD).Visible = False

            End With

        Catch ex As Exception
            HandleError(Me.Name, "FormateaGrid", ex)
        Finally
            Me.Grid1.AutoRedraw = True
            Me.Grid1.Refresh()
        End Try
    End Sub

    Private Sub Totales()
        Const sProcedure As String = "Totales"
        Try
            If Me.Grid1.Cols < Me.iGyID_INVENTARIO_LOTES_COSTOS Then 'Si aún no se inicializa el grid no totalizar nada porque fallaria al no tener todavia creadas todas las coumnas.
                Return
            End If

            Dim i As Integer
            Dim dCantidad As Decimal = 0, dCosto As Decimal = 0, dImporte As Decimal = 0, dFleteImporte As Decimal = 0, dCostoMasFlete As Decimal = 0, dImporteMasFlete As Decimal = 0, dCostoUSD As Decimal = 0
            Dim dFleteTotal As Decimal = 0
            For i = 1 To Me.Grid1.Rows - 1
                If Len("" & Me.Grid1.Cell(i, Me.iGyCantidad).Text) > 0 Then
                    dCantidad = valorNumericoD(0 & Me.Grid1.Cell(i, Me.iGyCantidad).Text)
                    dCosto = valorNumericoD(0 & Me.Grid1.Cell(i, Me.iGyCosto).Text)
                    dFleteImporte = valorNumericoD(0 & Me.Grid1.Cell(i, Me.iGyFleteDetalleImporte).Text)
                    dCostoUSD = valorNumericoD(0 & Me.Grid1.Cell(i, Me.iGyCostoUSD).Text)

                    If dCostoUSD > 0 And Me._LlamadoExteriorRecepcionarEntradaOrdenCompra = True Then
                        dCosto = RedondearD(dCostoUSD * valorNumericoD(Me.txtTipoCambio.Text), Empresa_Sistema.DECIMALES_PRECIO)
                        Me.Grid1.Cell(i, Me.iGyCosto).Text = dCosto.ToString
                    End If

                    '.Column(Me.iGyCosto).DecimalLength = Empresa_Sistema.DECIMALES_PRECIO
                    '.Column(Me.iGyImporte).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD

                    If dFleteImporte > 0 Then
                        dCostoMasFlete = dCosto + (dFleteImporte / dCantidad) 'Calcula un flete unitario en esta división (que no se usa para el importe total para no tener tropos)
                    Else
                        dCostoMasFlete = dCosto
                    End If

                    If dCantidad > 0 Then
                        dImporte = (dCosto * dCantidad)
                        dImporte = RedondearD(dImporte, Empresa_Sistema.DECIMALES_CONTABILIDAD)
                        dImporteMasFlete = dImporte + dFleteImporte

                        Me.Grid1.Cell(i, Me.iGyImporte).Text = dImporte.ToString
                        Me.Grid1.Cell(i, Me.iGyCostoMasFlete).Text = dCostoMasFlete.ToString
                        Me.Grid1.Cell(i, Me.iGyImporteMasFlete).Text = dImporteMasFlete.ToString
                    Else
                        Me.Grid1.Cell(i, Me.iGyImporte).Text = ""
                        Me.Grid1.Cell(i, Me.iGyFleteDetalleImporte).Text = ""
                        Me.Grid1.Cell(i, Me.iGyCostoMasFlete).Text = ""
                        Me.Grid1.Cell(i, Me.iGyImporteMasFlete).Text = ""

                        dFleteImporte = 0 'Para que si habia no se vaya acumular
                    End If

                    dFleteTotal += dFleteImporte
                End If
            Next i

            dFleteTotal = RedondearD(dFleteTotal, Empresa_Sistema.DECIMALES_CONTABILIDAD)

            Me.txtTotalCantidad.Text = FG_Grid_SumaCol(Me.Grid1, CShort(Me.iGyCantidad)).ToString
            Me.txtTotal.Text = FormatImporteContable(FG_Grid_SumaCol(Me.Grid1, CShort(Me.iGyImporte))).ToString
            Me.txtTotalMasFlete.Text = FormatImporteContable(FG_Grid_SumaCol(Me.Grid1, CShort(Me.iGyImporteMasFlete))).ToString
            Me.txtTotalFlete.Text = FormatImporteContable(dFleteTotal)

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Function GrabarPoliza() As Boolean
        Const sProcedure As String = "GrabarPoliza"
        Dim Bgrabado As Boolean = False
        Dim Error1 As String = ""

        If oInventarios.NATURALEZA_INVENTARIOS <> "EN" Then
            If Me.ValidarExistencias = False Then
                Exit Function
            End If
        End If

        Me.Totales()

        Select Case Me.Estado
            Case enumEstados.NUEVO, enumEstados.GRABADO
                Try
                    If oInventarios.AplicarPoliza() = True Then
                        MsgBox("La póliza fue grabada y contabilizada con éxito.", MsgBoxStyle.Information, sProcedure)
                    Else
                        MsgBox("La póliza no pudo grabarse.", MsgBoxStyle.Exclamation, sProcedure)
                    End If

                Catch ex As Exception
                    HandleError(Me.Name, sProcedure, ex)
                    Me.Estado = enumEstados.NUEVO
                    Me.Cambia_Estado(Me.Estado)
                Finally
                    'oPoliza = Nothing
                End Try
        End Select
    End Function

    Private Function SiTieneRenglones() As Boolean
        Const sProcedure As String = "SiTieneRenglones"
        Dim bResultado As Boolean = False
        Dim i As Integer
        Try
            For i = 1 To Me.Grid1.Rows - 1
                If txtLEN(Me.Grid1.Cell(i, Me.iGyCodigo).Text) = True Then
                    Return True
                End If
            Next
            bResultado = False
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
        Return bResultado
    End Function

    'Private Function SiTieneCuentaContable() As Boolean
    '    Dim i As Integer
    '    For i = 1 To Me.Grid1.Rows - 1
    '        If txtLEN(Me.Grid1.Cell(i, Me.iGyCodigo).Text) = True Then
    '            If txtLEN(Me.Grid1.Cell(i, Me.iGyCuentaContable).Text) = False Then
    '                SiTieneCuentaContable = False
    '                Exit Function
    '            End If
    '        End If
    '    Next
    '    SiTieneCuentaContable = True
    'End Function

    'Private Function ValidaCuentaContable() As Boolean
    '    Dim i As Integer
    '    Me.oCuentas = New Class_CatCuentas

    '    For i = 1 To Me.Grid1.Rows - 1
    '        If txtLEN(Me.Grid1.Cell(i, Me.iGyCodigo).Text) = True Then
    '            Me.oCuentas.CUENTA_CONTABLE = Me.Grid1.Cell(i, Me.iGyCuentaContable).Text
    '            If Me.oCuentas.Consultar = False Then
    '                MsgBox("La cuenta contable del renglón : " & i & " no existe.", MsgBoxStyle.Exclamation, Me.Name)
    '                Exit Function
    '            Else
    '                If Me.oCuentas.isCuentaContableValida(Me.Grid1.Cell(i, Me.iGyCuentaContable).Text.ToString) = False Then
    '                    MsgBox("La cuenta contable del renglón : " & i & " es inválida para poder usarse.", MsgBoxStyle.Exclamation, Me.Name)
    '                    ValidaCuentaContable = False
    '                    Exit Function
    '                End If
    '            End If
    '        End If
    '    Next
    '    ValidaCuentaContable = True
    'End Function

    Private Function ValidaCuentasContable() As Boolean
        Const sProcedure As String = "ValidaCuentasContable"
        Dim bResultado As Boolean = False
        Dim i As Integer, sCuentaContable As String = ""
        Try
            Dim oCuentas = New Class_CatCuentas

            For i = 1 To Me.Grid1.Rows - 1
                If txtLEN(Me.Grid1.Cell(i, Me.iGyCodigo).Text) = True Then

                    'If IsNothing(Me.oFormaDetalleCuentas) = True Then
                    '    MsgBox("vacio Me.oFormaDetalleCuentas ???")
                    'End If

                    sCuentaContable = Me.Grid1.Cell(i, Me.iGyCuentaContable).Text

                    If sCuentaContable = "0" Then
                        MsgBox("No se puede utilizar la cuenta contable 0 en movimientos de inventario.", MsgBoxStyle.Exclamation, sProcedure)
                        Me.Grid1.Cell(i, Me.iGyCuentaContable).SetFocus()
                        Exit Function
                    End If

                    If IsNothing(Me.oFormaDetalleCuentas) = False AndAlso Me.oFormaDetalleCuentas.ValidaCuentaTengaDetalle(CInt(Me.Grid1.Cell(i, Me.iGyIDAdicional).Text)) = True Then 'Si es que tiene detalle de cuenta en la otra forma

                        'No bajar la segunda validacion despues del andalso porque si no no va entrar al else si e sun renglón que tien su cuenta en el grid normal y no el oculto
                        'Si es que tiene detalle de cuenta en la otra forma y si tambien se haya el id del renglon(puede haber renglones que no tengan, esos que no tienen no entran aqui si se tiene que preguntar)
                        'No hay que hacer
                        'MsgBox("andale")

                        If txtLEN(sCuentaContable) = True Then
                            MsgBox("Quite la cuenta contable del renglón : " & i & " , no se puede tener cuenta directa y también en detalle(la que se establece con el botón).", MsgBoxStyle.Exclamation, sProcedure)
                            Return False
                        End If

                    Else
                        If txtLEN(sCuentaContable) = False Then
                            MsgBox("Asígne la cuenta contable del renglón : " & i & " .", MsgBoxStyle.Exclamation, sProcedure)
                            Return False
                        End If

                        'If sCuentaContable.StartsWith("1") = False Then
                        '    MsgBox("La cuenta contable del renglón : " & i & " debe ser del rango de las miles(que empiezen con 1)." & vbCrLf & _
                        '    "O debe en vez de poner cuenta, detallar con el botón de centros de costos.", MsgBoxStyle.Exclamation, sProcedure)
                        '    Return False
                        'End If

                        oCuentas = New Class_CatCuentas(sCuentaContable)

                        If oCuentas._Existe = False Then
                            MsgBox("La cuenta contable del renglón : " & i & " no existe.", MsgBoxStyle.Exclamation, sProcedure)
                            Return False
                        ElseIf oCuentas.ESMAYOR = "1" Then
                            MsgBox("La cuenta contable del renglón : " & i & " es de mayor.", MsgBoxStyle.Exclamation, sProcedure)
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

    Private Function SiTieneImporte() As Boolean
        Const sProcedure As String = "SiTieneImporte"
        Dim bResultado As Boolean = False
        Try
            Dim i As Integer
            For i = 1 To Me.Grid1.Rows - 1
                If txtLEN(Me.Grid1.Cell(i, Me.iGyCodigo).Text) = True Then
                    If valorNumerico(Me.Grid1.Cell(i, Me.iGyImporte).Text) = 0 Then
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

    Private Function SiTieneCantidad() As Boolean
        Const sProcedure As String = "SiTieneCantidad"
        Dim bResultado As Boolean = False
        Try
            Dim i As Integer
            For i = 1 To Me.Grid1.Rows - 1
                If txtLEN(Me.Grid1.Cell(i, Me.iGyCodigo).Text) = True Then
                    If valorNumerico(Me.Grid1.Cell(i, Me.iGyCantidad).Text) = 0 Then
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

    Private Sub OcultaControles()
        Const sProcedure As String = "OcultaControles"
        Try
            Me.oDocumentos = New Class_Cat_tiposDocumentos(Me.CboDocumento.SelectedValue.ToString)

            Me.Grid1.Column(Me.iGyCosto).Locked = False
            Me.Grid1.Column(Me.iGyCodigo).Locked = False

            If Me.oDocumentos.CODIGO_TIPO_DOCUMENTO = "ER" Or Me.oDocumentos.NATURALEZA_INVENTARIOS = "SA" Then
                Me.Grid1.Column(Me.iGyCosto).Locked = True
            End If

            If Me.oDocumentos.CODIGO_TIPO_DOCUMENTO = "SALT" Or Me.oDocumentos.CODIGO_TIPO_DOCUMENTO = "TRLT" Then
                Me.Grid1.Column(Me.iGyCodigo).Locked = True
            End If

            If Me.oDocumentos.ES_TRANSFERENCIA = "1" Then
                Me.CboAlmacenDestino.Visible = True : Me.lblDisplayAlmacenDestino.Visible = True : Me.lblCodigoAlmacenDestino.Visible = True
                If Me.oDocumentos.CODIGO_TIPO_DOCUMENTO = "TRF" Then 'TRF=TRANSFERENCIA_FINANCIERA 
                    Me.cboAlmacenEntradaFinanciera.Visible = True : Me.lblDisplayAlmacenEntradaFinanciera.Visible = True
                    Me.CboAlmacenDestino.SelectedValue = Plaza.CODIGO_ALMACEN_FACTURACION
                    If Me.Estado = enumEstados.NUEVO Then Me.cboAlmacenEntradaFinanciera.SelectedValue = Plaza.CODIGO_ALMACEN_FINANCIERO
                    Me.txtFolioEntradaFinanciera.Visible = True : Me.lblDisplayFolioEntradaFinanciera.Visible = True
                Else
                    Me.cboAlmacenEntradaFinanciera.Visible = False : Me.lblDisplayAlmacenEntradaFinanciera.Visible = False
                    Me.txtFolioEntradaFinanciera.Visible = False : Me.lblDisplayFolioEntradaFinanciera.Visible = False
                End If
                If Me._LlamadoExteriorGenerarSalidaEmbarque = False And Me._ConsultaExteriorSalida = False Then
                    Me.Grid1.Column(Me.iGyCuentaContable).Locked = True
                    Me.Grid1.Column(Me.iGyImporte).Locked = True
                End If
                If txtLEN(Me._CodigoAlmacenHappy) = True Then
                    Me.CboAlmacenDestino.SelectedValue = Me._CodigoAlmacenHappy
                End If
                Me.tsbCancelar.Visible = False
                If Me.Estado = enumEstados.GRABADO Then
                    Me.tsbCancelar.Visible = True
                End If
                Me.txtFolioEmbarque.Visible = True : Me.lblDisplayFolioEmbarque.Visible = True
                'Me.GridSeries.Column(Me.igySerieNumeroSerie).Locked = True
            Else
                Me.CboAlmacenDestino.Visible = False : Me.lblDisplayAlmacenDestino.Visible = False : Me.lblCodigoAlmacenDestino.Visible = False
                Me.cboAlmacenEntradaFinanciera.Visible = False : Me.lblDisplayAlmacenEntradaFinanciera.Visible = False
                Me.txtFolioEntradaFinanciera.Visible = False : Me.lblDisplayFolioEntradaFinanciera.Visible = False
                If Me._LlamadoExteriorGenerarSalidaEmbarque = False And Me._ConsultaExteriorSalida = False Then
                    Me.Grid1.Column(Me.iGyCuentaContable).Locked = False
                End If
                Me.tsbCancelar.Visible = True
                Me.txtFolioEmbarque.Text = "" 'Se forza a blanco por si tenia algo capturado.
                Me.txtFolioEmbarque.Visible = False : Me.lblDisplayFolioEmbarque.Visible = False
                'Me.GridSeries.Column(Me.igySerieNumeroSerie).Locked = True
            End If

            Me.gbOrdenCompra.Visible = False
            'Me.Grid1.Locked = False
            'Me.Grid1.Column(Me.iGyCodigo).Locked = False
            Me.Grid1.Column(Me.iGyFleteDetalleImporte).Visible = False
            Me.Grid1.Column(Me.iGyCostoMasFlete).Visible = False
            Me.Grid1.Column(Me.iGyImporteMasFlete).Visible = False

            Me.btnConsultarOrdenCompra.Enabled = False
            Me.btnProrratearFleteOrdenCompra.Enabled = False
            Me.btnNuevaOrdenCompra.Enabled = False
            Me.txtFolioOrdenCompra.Enabled = False

            If Me.oDocumentos.CODIGO_TIPO_DOCUMENTO = "ER" Or Me.oDocumentos.CODIGO_TIPO_DOCUMENTO = "TRI" Or Me.oDocumentos.CODIGO_TIPO_DOCUMENTO = "TRF" Or Me.oDocumentos.CODIGO_TIPO_DOCUMENTO = "TRLT" Then
                Me.gbOrdenCompra.Visible = True
                'Me.Grid1.Locked = True
                'Me.Grid1.Column(Me.iGyCodigo).Locked = True
                Me.Grid1.Column(Me.iGyFleteDetalleImporte).Visible = True
                Me.Grid1.Column(Me.iGyCostoMasFlete).Visible = True
                Me.Grid1.Column(Me.iGyImporteMasFlete).Visible = True

                Me.btnProrratearFleteOrdenCompra.Enabled = True
                Me.txtFleteOrdenCompra.Enabled = True

                If Me.oDocumentos.CODIGO_TIPO_DOCUMENTO = "ER" Then
                    Me.btnConsultarOrdenCompra.Enabled = True
                    Me.btnNuevaOrdenCompra.Enabled = True
                    Me.txtFolioOrdenCompra.Enabled = True
                End If
            End If

            If Empresa_Sistema.ES_ACUICOLA Then
                If (Me.oDocumentos.CODIGO_TIPO_DOCUMENTO = "ENI" Or Me.oDocumentos.CODIGO_TIPO_DOCUMENTO = "SAI") And Me.CboConceptoInventario.Text = "MATERIA PRIMA" Then
                    Me.LblFolioOrdenProduccion.Visible = True
                    Me.TxtFolioOrdenProduccion.Visible = True
                Else
                    Me.LblFolioOrdenProduccion.Visible = False
                    Me.TxtFolioOrdenProduccion.Visible = False
                    Me.TxtFolioOrdenProduccion.Text = ""
                End If
            End If

            If Me.oDocumentos.NATURALEZA_INVENTARIOS = "SA" Then
                Me.txtCliente.Visible = True : Me.lblCliente.Visible = True : Me.lblDisplayCliente.Visible = True
            Else
                Me.txtCliente.Visible = False : Me.lblCliente.Visible = False : Me.lblDisplayCliente.Visible = False
            End If

            'Revisar luego si lockear columnas, aqui es problemático hacerlo porque puede ser que desbloquee columnas o controles que deberian estar bloqueadas(que manipula el cambiar estado)

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Function ValidaEmbarque() As Boolean
        Const sProcedure As String = "ValidaEmbarque"
        Dim bResultado As Boolean = False
        Try
            Dim oEmbarque As New Class_Embarques_EmbarqueGlobal(Me.txtFolioEmbarque.Text, True)
            If oEmbarque.Existe = False Then
                MsgBox("El folio de embarque no existe.", MsgBoxStyle.Exclamation, sProcedure)
            Else
                Dim oSql As New Class_find("SELECT 1 FROM INVENTARIO_MOVIMIENTOS_GLOBAL WHERE FOLIO_EMBARQUE='" & sReplace(Me.txtFolioEmbarque.Text) & "' AND FOLIO_MOVIMIENTO_INVENTARIO<>'" & sReplace(Me.TxtFolio.Text) & "'")
                If txtLEN(oSql.Result1) = True Then
                    MsgBox("El folio de embarque ya fue usado en otro movimiento, no es posible repetirlo.", MsgBoxStyle.Exclamation, sProcedure)
                Else
                    bResultado = True
                End If
            End If
            oEmbarque = Nothing
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
        Return bResultado
    End Function

    Private Sub Navegador(ByVal sTipoDeBusqueda As String)
        Const sProcedure As String = "Navegador"
        Try
            Dim iFolio As Integer, sFolio As String, iPosicion As Integer, sFolioParte2 As String
            If txtLEN(Me.TxtFolio.Text) = False Then
                If GeneraFolio() = False OrElse txtLEN(Me.TxtFolio.Text) = False Then
                    Exit Sub
                End If
            End If

            If sTipoDeBusqueda = "Anterior" Then
                iPosicion = Me.TxtFolio.Text.IndexOf("-")
                sFolio = Me.TxtFolio.Text.Substring(0, iPosicion)
                iFolio = CInt(Strings.Right(Me.TxtFolio.Text, Len(Me.TxtFolio.Text) - (Len(sFolio) + 1))) ' Me.oVenta.FOLIO_NUMERICO
                iFolio = iFolio - 1
                sFolioParte2 = Format(iFolio, New String(CChar("0"), Me.TxtFolio.Text.Substring(3, Me.TxtFolio.TextLength - iPosicion - 1).Length))
                sFolio = sFolio + "-" + sFolioParte2 'sFolio + "-" + iFolio.ToString
                Me.TxtFolio.Text = sFolio

                If txtLEN(sFolio) = True Then
                    Me.Consultar()
                Else
                    Me.Inicializa()
                    Me.Cambia_Estado(enumEstados.NUEVO)
                    Me.GeneraFolio()
                    Me.TxtFolio.Focus()
                End If

            ElseIf sTipoDeBusqueda = "Siguiente" Then
                iPosicion = Me.TxtFolio.Text.IndexOf("-")
                sFolio = Me.TxtFolio.Text.Substring(0, iPosicion)
                iFolio = CInt(Strings.Right(Me.TxtFolio.Text, Len(Me.TxtFolio.Text) - (Len(sFolio) + 1))) ' Me.oVenta.FOLIO_NUMERICO
                iFolio = iFolio + 1
                sFolioParte2 = Format(iFolio, New String(CChar("0"), Me.TxtFolio.Text.Substring(3, Me.TxtFolio.TextLength - iPosicion - 1).Length))
                sFolio = sFolio + "-" + sFolioParte2 'sFolio + "-" + iFolio.ToString
                Me.TxtFolio.Text = sFolio

                If txtLEN(sFolio) = True Then
                    Me.Consultar()
                Else
                    Me.Inicializa()
                    Me.Cambia_Estado(enumEstados.NUEVO)
                    Me.GeneraFolio()
                    Me.TxtFolio.Focus()
                End If
            End If
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Sub GestionaDetalleCuentas()
        Const sProcedure As String = "GestionaDetalleCuentas"
        Dim iRenglon As Integer = 0
        Try
            iRenglon = Me.Grid1.ActiveCell.Row 'Me.Grid1.Selection.FirstRow
            'iRenglon = CInt(Me.Grid1.Cell(Me.Grid1.ActiveCell.Row, Me.iGyIDAdicional).Text)

            If valorNumerico(Me.Grid1.Cell(iRenglon, Me.iGyImporte).Text) = 0 Then
                MsgBox("No ha capturado el artículo con su cantidad y precio.", MsgBoxStyle.Exclamation, sProcedure)
                Exit Sub
            End If

            'Solo si esta vacia la crea, para que siga existiendo en memoria ( con hide se oculta en la forma secundaria, para seguir trabajando con ella al volver el control a esta forma)
            If IsNothing(Me.oFormaDetalleCuentas) = True Then
                Me.oFormaDetalleCuentas = New InventariosDetalleCuentasContables(Me.TxtFolio.Text)
            End If

            With Me.oFormaDetalleCuentas
                .IDAdicional = CInt(Me.Grid1.Cell(iRenglon, Me.iGyIDAdicional).Text) 'iRenglon
                .Importe = valorNumerico(Me.Grid1.Cell(iRenglon, Me.iGyImporte).Text)
                .txtArticulo.Text = Me.Grid1.Cell(iRenglon, Me.iGyDescripcion).Text
                .txtCantidad.Text = Me.Grid1.Cell(iRenglon, Me.iGyCantidad).Text
                .txtCosto.Text = Me.Grid1.Cell(iRenglon, Me.iGyCosto).Text
                .txtImporte.Text = FormatImporteContable(.Importe, False)
                .CodigoArticulo = Me.Grid1.Cell(iRenglon, Me.iGyCodigo).Text
                .ShowDialog()

                'If .TieneDetalleCuentas = True Then
                'If .GestionoRenglon = True Then
                If .ValidaCuentaTengaDetalle(.IDAdicional) Then
                    Me.Grid1.Cell(iRenglon, Me.iGyCuentaContable).Text = ""
                    Me.Grid1.Cell(iRenglon, Me.iGyNombreCuentaContable).Text = "Tiene detalle -->>"
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Function EliminaDetalleCuentasContables(ByVal IDAdicional As Integer) As Integer
        Const sProcedure As String = "EliminaDetalleCuentasContables"
        Try
            If IsNothing(Me.oFormaDetalleCuentas) = False Then 'Si no esta vacia, osea si existe
                Me.oFormaDetalleCuentas.EliminaRelacion(IDAdicional)
            End If
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Function

    Private Sub GestionaAplicacion()
        Const sProcedure As String = "GestionaAplicacion"
        Try
            'Me.bAplicando = True

            If Me.oInventarios.NATURALEZA_INVENTARIOS <> "EN" Then
                If Me.ValidarExistencias() = False Then
                    Return
                End If
            End If

            Dim oAlmacenOrigen As New Class_CatAlmacenes(Me.CboAlmacen.SelectedValue.ToString)

            'Me.oDocumentos = New Class_Cat_tiposDocumentos(Me.CboDocumento.SelectedValue.ToString)
            If Me.oDocumentos.ES_TRANSFERENCIA = "1" AndAlso oAlmacenOrigen.ES_FISCAL = True Then 'Sólo si es almacén es fiscal se afecta a la contabilidad
                If Me.EstableceCuentaContableAlmacenDestino() = False Then
                    MsgBox("Error al tratar de asígnar la cuenta contable del almacén destino.", MsgBoxStyle.Exclamation, sProcedure)
                    Return
                End If
            End If

            If Me.oDocumentos.CODIGO_TIPO_DOCUMENTO = "ER" Then
                If Me.ValidaCantidadesDisponiblesOrdenCompra() = False Then
                    Return
                End If
            End If

            If Me.Aplicar() = True Then
                If Me._LlamadoExteriorGenerarSalidaEmbarque = True Then

                    'Se quitó 17dic16 porque ahora se hace una sola salida para todo el embarque y se marca desde el mismo embarque
                    'Me.oPalet.MarcaSalidaPalet()

                    Me._AplicadoExterior = True
                    'MsgBox("El movimiento de Inventario fue Aplicado con exito", MsgBoxStyle.Information, sProcedure)
                    Me.Close()
                    Return

                ElseIf Me._LlamadoExteriorRecepcionarEntradaOrdenCompra = True Then
                    Me._AplicadoExterior = True
                    'MsgBox("El movimiento de Inventario fue Aplicado con exito", MsgBoxStyle.Information, sProcedure)
                    Me.Close()
                    Return

                End If

                MsgBox("El movimiento de inventario fue aplicado con éxito", MsgBoxStyle.Information, sProcedure)
                Me.Consultar()
            Else
                If Me._LlamadoExteriorGenerarSalidaEmbarque = False Then
                    Me.Consultar()
                Else
                    Me.Visible = True
                End If
            End If
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Sub PrepararSeries()
        Const sProcedure As String = "PrepararSeries"
        Try
            'Dim iUnidades As Integer

            If IsNothing(Me.dtSeries) = False AndAlso Me.dtSeries.Rows.Count > 0 Then
                If MsgBox("Hay series ya especificadas, si continua tendrá que recapturar todas." & vbCrLf & "Esta seguro de continuar ?", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo, sProcedure) = MsgBoxResult.No Then
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
            End With
            Me.dtSeries.AcceptChanges()

            Dim dRow As DataRow

            For i = 1 To Me.Grid1.Rows - 1
                If txtLEN(Me.Grid1.Cell(i, Me.iGyCodigo).Text) = True AndAlso Me.Grid1.Cell(i, Me.iGyCodigo).Text <> "-" AndAlso CInt(Me.Grid1.Cell(i, Me.iGyCantidad).Text) > 0 Then
                    Dim oArticulo As New Class_CatArticulos(Me.Grid1.Cell(i, Me.iGyCodigo).Text)
                    If oArticulo.Existe = True AndAlso oArticulo.ES_SERIALIZABLE = True AndAlso oArticulo.INVENTARIABLE = "1" Then
                        For j = 1 To CInt(Me.Grid1.Cell(i, Me.iGyCantidad).Text)
                            dRow = Me.dtSeries.NewRow

                            dRow("POSICION") = i
                            dRow("CODIGO_ARTICULO") = Me.Grid1.Cell(i, Me.iGyCodigo).Text
                            dRow("DESCRIPCION") = Me.Grid1.Cell(i, Me.iGyDescripcion).Text
                            dRow("ID_INVENTARIO_LOTES_COSTOS") = ""
                            dRow("NUMERO_SERIE") = ""

                            Me.dtSeries.Rows.Add(dRow)
                        Next
                    End If
                End If
            Next

            Me.dtSeries.AcceptChanges()

            Me.GridSeries.DataSource = Me.dtSeries

            Me.FormateaGridSeries()

            If Me.dtSeries.Rows.Count > 0 Then
                'If Me.CboDocumento.Text = "ENTRADA" Then
                'Para salidas o transferencias no se ocupa locked porque usa el f6 y este no se bloquea con locked
                If Me.CboDocumento.SelectedValue.ToString = "ENI" Or Me.CboDocumento.SelectedValue.ToString = "ER" Then 'ENI=Entrada directam, ER=Entrada compra.
                    Me.GridSeries.Column(Me.igySerieNumeroSerie).Locked = False
                End If

                Me.TabControl1.SelectedIndex = 1
            Else
                Me.GridSeries.Column(Me.igySerieNumeroSerie).Locked = True
                MsgBox("No hay series por detallar.", MsgBoxStyle.Exclamation, sProcedure)
            End If

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Sub FormateaGridSeries()
        Const sProcedure As String = "FormateaGridSeries"
        Try
            With Me.GridSeries
                .AutoRedraw = False

                .DisplayFocusRect = False
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
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Sub InicializaGridSeries()
        Const sProcedure As String = "InicializaGridSeries"
        Try
            Me.GridSeries.DataSource = Nothing
            FG_Grid_Limpiar(Me.GridSeries)
            Me.GridSeries.Rows = 2
            Me.GridSeries.Cols = 6
            Me.FormateaGridSeries()
            'Me.Grid.Cell(1, Me.iGyIDAdicional).Text = "1"
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Sub GestionaGridSeries(ByVal e As System.Windows.Forms.KeyEventArgs)
        Const sProcedure As String = "GestionaGridSeries"
        Dim sLote As String = "", sCodigoArticulo As String = ""
        Dim oSerie As Class_Inventarios_Lotes_Series
        Try
            If Me.dtSeries.Rows.Count = 0 Then
                Return
            End If

            If Not (Me.lblStatus.Text = "G" Or Me.lblStatus.Text = "") Then 'Si no es G=Grabado, ""=Blanco para nuevo
                Return
            End If

            With Me.GridSeries
                Dim Renglon As Integer = .Selection.FirstRow
                Dim Columna As Integer = .Selection.FirstCol

                'If Me.CboDocumento.Text = "ENTRADA" Then
                If Me.CboDocumento.SelectedValue.ToString = "ENI" Or Me.CboDocumento.SelectedValue.ToString = "ER" Then 'Se sale porque se permite teclear directo, y la duplicación se valuid al grabar asi que 
                    'este gestiona sirve mas para las salidas y transferencias.
                    Exit Sub
                End If

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
                            sLote = oSerie.BusquedaVisual(sCodigoArticulo, Me.CboAlmacen.SelectedValue.ToString)
                            If txtLEN(sLote) = True Then
                                If RepiteSerie(Renglon, sLote) = False Then
                                    Me.EstableceSerie(Renglon, sLote)
                                End If
                            End If
                        End If

                    Case Keys.F7
                        If Columna = Me.igySerieNumeroSerie AndAlso txtLEN(.Cell(Renglon, Me.igySeriePosicion).Text) = True Then
                            oSerie = New Class_Inventarios_Lotes_Series
                            sCodigoArticulo = .Cell(Renglon, Me.igySerieCodigo).Text
                            If txtLEN(sCodigoArticulo) = False Then
                                Return
                            End If

                            Dim lote As New Class_Inventarios_Lotes_Series.Lote
                            lote = oSerie.BusquedaVisualSeriesMultiplesFolio(sCodigoArticulo, Me.CboAlmacen.SelectedValue.ToString)

                            If txtLEN(lote.FolioMovimiento) = True Then

                                Dim dtSeries As DataTable = oSerie.ObtieneRenglonesSeriesFolio(lote.FolioMovimiento, sCodigoArticulo)
                                If dtSeries.Rows.Count = 0 Then
                                    MsgBox("No se encontraron series disponibles del artículo " & sCodigoArticulo & " del folio " & lote.FolioMovimiento, MsgBoxStyle.Exclamation, sProcedure)
                                    Return
                                End If

                                Dim i As Integer, iArticulosPendientes As Integer = Me.CantidadArticulosPendientesSerie(sCodigoArticulo) 'iArticulosEncontrados As Integer
                                Dim iSeriesUsadas As Double = lote.Cantidad, iRowEncontrado As Integer = 0
                                For i = 1 To Me.GridSeries.Rows - 1
                                    If iArticulosPendientes <= 0 Or iSeriesUsadas <= 0 Then
                                        Exit For
                                    End If
                                    If Me.GridSeries.Cell(i, Me.igySerieCodigo).Text = sCodigoArticulo AndAlso txtLEN(Me.GridSeries.Cell(i, Me.igySerieIdInventarioLotesCostos).Text) = False Then
                                        iArticulosPendientes -= 1
                                        iSeriesUsadas -= 1
                                        Me.GridSeries.Cell(i, Me.igySerieIdInventarioLotesCostos).Text = dtSeries.Rows(iRowEncontrado)("ID_INVENTARIO_LOTES_COSTOS").ToString
                                        Me.GridSeries.Cell(i, Me.igySerieNumeroSerie).Text = dtSeries.Rows(iRowEncontrado)("NUMERO_SERIE").ToString
                                        iRowEncontrado += 1 'empieza desde el 0
                                    End If
                                Next


                            End If
                        End If

                    Case Keys.Delete
                        e.SuppressKeyPress = True
                End Select

            End With

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Function EstableceSerie(ByVal Renglon As Integer, ByVal ID_INVENTARIO_LOTES_COSTOS As String) As Boolean
        Const sProcedure As String = "EstableceSerie"
        Try
            Dim oSerie As New Class_Inventarios_Lotes_Series(ID_INVENTARIO_LOTES_COSTOS)
            If oSerie.Existe = True Then
                Me.GridSeries.Cell(Renglon, Me.igySerieIdInventarioLotesCostos).Text = oSerie.ID_INVENTARIO_LOTES_COSTOS
                Me.GridSeries.Cell(Renglon, Me.igySerieNumeroSerie).Text = oSerie.NUMERO_SERIE
                Return True
            End If
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Function

    Private Function RepiteSerie(ByVal Renglon As Integer, ByVal ID_INVENTARIO_LOTES_COSTOS As String) As Boolean
        Const sProcedure As String = "RepiteSerie"
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
                                   "", MsgBoxStyle.Exclamation, sProcedure)
                            Me.GridSeries.Cell(RenglonRepetido, Me.igySerieNumeroSerie).SetFocus()

                            Return True

                        End If
                    End If
                End If
            Next
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Function

    Private Function CantidadArticulosPendientesSerie(ByVal sCodigoArticulo As String) As Integer
        Const sProcedure As String = "CantidadArticulosPendientesSerie"
        Dim iArticulosEncontrados As Integer = 0
        Try
            For i = 1 To Me.GridSeries.Rows - 1
                If Me.GridSeries.Cell(i, Me.igySerieCodigo).Text = sCodigoArticulo AndAlso Me.GridSeries.Cell(i, Me.iGyCodigo).Text <> "-" AndAlso txtLEN(Me.GridSeries.Cell(i, Me.igySerieIdInventarioLotesCostos).Text) = False Then
                    iArticulosEncontrados += 1
                End If
            Next
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
        Return iArticulosEncontrados
    End Function

    Private Function ValidaNumerosSerie() As Boolean
        Const sProcedure As String = "ValidaNumerosSerie"
        Try
            Dim dtSeriesTemp As New DataTable("Series")
            With dtSeriesTemp
                .Columns.Add("POSICION", GetType(String))
                .Columns.Add("CODIGO_ARTICULO", GetType(String))
                .Columns.Add("DESCRIPCION", GetType(String))
            End With
            dtSeriesTemp.AcceptChanges()

            Dim dRow As DataRow, i As Integer

            For i = 1 To Me.Grid1.Rows - 1
                If txtLEN(Me.Grid1.Cell(i, Me.iGyCodigo).Text) = True AndAlso Me.Grid1.Cell(i, Me.iGyCodigo).Text <> "-" AndAlso CInt(Me.Grid1.Cell(i, Me.iGyCantidad).Text) > 0 Then
                    Dim oArticulo As New Class_CatArticulos(Me.Grid1.Cell(i, Me.iGyCodigo).Text)
                    If oArticulo.Existe = True AndAlso oArticulo.ES_SERIALIZABLE = True AndAlso oArticulo.INVENTARIABLE = "1" Then
                        For j = 1 To CInt(Me.Grid1.Cell(i, Me.iGyCantidad).Text)
                            dRow = dtSeriesTemp.NewRow

                            dRow("POSICION") = i
                            dRow("CODIGO_ARTICULO") = Me.Grid1.Cell(i, Me.iGyCodigo).Text
                            dRow("DESCRIPCION") = Me.Grid1.Cell(i, Me.iGyDescripcion).Text

                            dtSeriesTemp.Rows.Add(dRow)
                        Next
                    End If
                End If
            Next

            dtSeriesTemp.AcceptChanges()

            If Me.dtSeries.Rows.Count <> dtSeriesTemp.Rows.Count Then
                MsgBox("Tiene que volver a detallar todas las series porque no corresponden los artículos.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            i = 0
            For Each d As DataRow In dtSeriesTemp.Rows
                If d("POSICION").ToString <> Me.dtSeries.Rows(i)("POSICION").ToString Then
                    MsgBox("Tiene que volver a detallar todas las series porque no corresponden los artículos.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                ElseIf d("CODIGO_ARTICULO").ToString <> Me.dtSeries.Rows(i)("CODIGO_ARTICULO").ToString Then
                    MsgBox("Tiene que volver a detallar todas las series porque no corresponden los artículos.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If
                i += 1
            Next

            For Each d As DataRow In Me.dtSeries.Rows
                If txtLEN(d("NUMERO_SERIE").ToString) = False Then
                    MsgBox("Faltan de capturar series, favor de revisar.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If
            Next

            Return True
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Function

    Private Function HaySeriesRepetidas() As Boolean
        Const sProcedure As String = "HaySeriesRepetidas"
        Dim RenglonRepetido As Integer

        Try
            Me.dtSeries.AcceptChanges()

            If Me.CboDocumento.SelectedValue.ToString = "ENI" Or Me.CboDocumento.SelectedValue.ToString = "ER" Then 'ENI=Entrada, ER=Entrada recepcion compras
                For i = 1 To Me.GridSeries.Rows - 1
                    If txtLEN(Me.GridSeries.Cell(i, Me.igySerieCodigo).Text) = True Then
                        For z = i + 1 To Me.GridSeries.Rows - 1
                            If Me.GridSeries.Cell(i, Me.igySerieNumeroSerie).Text = Me.GridSeries.Cell(z, Me.igySerieNumeroSerie).Text Then
                                RenglonRepetido = z

                                MsgBox("La serie " & Me.GridSeries.Cell(RenglonRepetido, igySerieNumeroSerie).Text &
                                       " del artículo " & Me.GridSeries.Cell(RenglonRepetido, igySerieCodigo).Text & " esta repetida en el renglón " & RenglonRepetido & "." & vbCrLf &
                                       "", MsgBoxStyle.Exclamation, sProcedure)
                                Me.GridSeries.Cell(RenglonRepetido, Me.igySerieNumeroSerie).SetFocus()

                                Return True

                            End If
                        Next
                    End If
                Next
            Else 'Compara Id inventarios lotes costos
                For i = 1 To Me.GridSeries.Rows - 1
                    If txtLEN(Me.GridSeries.Cell(i, Me.igySerieCodigo).Text) = True Then
                        For z = i + 1 To Me.GridSeries.Rows - 1
                            If Me.GridSeries.Cell(i, Me.igySerieIdInventarioLotesCostos).Text = Me.GridSeries.Cell(z, Me.igySerieIdInventarioLotesCostos).Text Then
                                RenglonRepetido = z

                                MsgBox("La serie " & Me.GridSeries.Cell(RenglonRepetido, igySerieNumeroSerie).Text &
                                       " del artículo " & Me.GridSeries.Cell(RenglonRepetido, igySerieCodigo).Text & " esta repetida en el renglón " & RenglonRepetido & "." & vbCrLf &
                                       "", MsgBoxStyle.Exclamation, sProcedure)
                                Me.GridSeries.Cell(RenglonRepetido, Me.igySerieNumeroSerie).SetFocus()

                                Return True

                            End If
                        Next
                    End If
                Next
            End If
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try

        Return False
    End Function

    Private Function ConsultarOrdenCompra() As Boolean
        Const sProcedure As String = "ConsultarOrdenCompra"
        Dim bResultado As Boolean = False
        Try
            If txtLEN(Me.txtFolioOrdenCompra.Text) = False Then
                MsgBox("Indique el folio de la orden de compra.", MsgBoxStyle.Exclamation, sProcedure)
                If Me.txtFolioOrdenCompra.Enabled = True Then
                    Me.txtFolioOrdenCompra.Focus()
                End If
                Return False
            End If

            Dim oOrdenCompra As New Class_Compras_Global(Me.txtFolioOrdenCompra.Text, "OC" & Plaza.CODIGO_PLAZA.ToString)

            If oOrdenCompra.Existe = False Then
                MsgBox("La orden de compra no existe.", MsgBoxStyle.Exclamation, sProcedure)
                If Me.txtFolioOrdenCompra.Enabled = True Then
                    Me.txtFolioOrdenCompra.Focus()
                End If
                Return False
            End If

            Me.OcTieneRequisicion = ValidaOcTieneRequisicion(oOrdenCompra.FOLIO_COMPRA)

            If Empresa_Sistema.MODO_REQUISICIONES_INVENTARIO And Me.OcTieneRequisicion Then    'If Empresa_Sistema.MODO_REQUISICIONES_INVENTARIO And txtLEN(oOrdenCompra.FOLIO_REQUISICION) Then
                'Solo validara estatus P para OC con requisicion
                If Not (oOrdenCompra.ESTATUS = "P" Or oOrdenCompra.ESTATUS = "R") Then
                    MsgBox("La orden de compra tiene requisición de inventario, debe estar en estatus P(Pedida) o R(Parcialmente recepcionada) para hacer la entrada.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If

            Else
                If Not (oOrdenCompra.ESTATUS = "G" Or oOrdenCompra.ESTATUS = "R") Then
                    MsgBox("La orden de compra no esta en estatus G(Grabada) o R(Parcialmente recepcionada).", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If
            End If
            

            Dim oOC As New Class_find("SELECT OC.FOLIO_COMPRA FROM COMPRA_GLOBAL OC INNER JOIN VW_SIS_CAT_DOCUMENTOS_EXTENDIDO DOC ON(OC.CODIGO_DOCUMENTO=DOC.CODIGO_DOCUMENTO) " &
            "WHERE OC.FOLIO_COMPRA='" & sReplace(Me.txtFolioOrdenCompra.Text) & "' AND DOC.CODIGO_TIPO_DOCUMENTO='OC' ")

            If txtLEN(oOC.Result1) = False Then
                MsgBox("Este documento no es una orden de compra.", vbExclamation, sProcedure)
                Return False
            End If

            If Me.CboAlmacen.SelectedValue.ToString <> oOrdenCompra.CODIGO_ALMACEN Then
                MsgBox("La orden de compra tiene el almacén " & oOrdenCompra.CODIGO_ALMACEN & " y es diferente al que tiene seleccionado en este movimiento.", vbExclamation, sProcedure)
                Return False
            End If

            Dim oProveedor As New Class_CatProveedores(oOrdenCompra.CODIGO_PROVEEDOR)

            Me.txtProveedor.Text = oOrdenCompra.CODIGO_PROVEEDOR & "-" & oProveedor.Nombre_Proveedor
            Me.dtpFechaEntrega.Value = oOrdenCompra.FECHA_ENTREGA

            Me.cboEntradasAnterioresOrdenCompra.DataSource = oOrdenCompra.ObtieneEntradasAnterioresOrdenCompra(Me.txtFolioOrdenCompra.Text) 'Llenar combo entradas anteriores
            Me.cboEntradasAnterioresOrdenCompra.DisplayMember = "INFORMACION"
            Me.cboEntradasAnterioresOrdenCompra.ValueMember = "FOLIO_MOVIMIENTO_INVENTARIO"

            Me.InicializaGrid()
            Me.InicializaGridSeries()
            Me.OcultaControles()

            'Dim dTabla As DataTable = oOrdenCompra.ObtenerDetalleDisponiblesOrdenCompra(Me.txtFolioOrdenCompra.Text, Me.cboMoneda.Text, valorNumericoD(Me.txtTipoCambio.Text))
            Dim dTabla As DataTable = oOrdenCompra.ObtenerDetalleDisponiblesOrdenCompra(Me.txtFolioOrdenCompra.Text)

            Me.Grid1.AutoRedraw = False
            Me.Grid1.Rows = 1
            For Each dRow As DataRow In dTabla.Rows
                Me.Grid1.AddItem(dRow("CODIGO_ARTICULO").ToString & Chr(9) &
                                 dRow("DESCRIPCION").ToString & Chr(9) &
                                 dRow("CANTIDAD").ToString & Chr(9) &
                                 dRow("COSTO_DETALLE").ToString & Chr(9) &
                                 dRow("IMPORTE").ToString & Chr(9) &
                                dRow("Boton").ToString & Chr(9) &
                                dRow("CUENTA_CONTABLE").ToString & Chr(9) &
                                dRow("NOMBRE_CUENTA").ToString & Chr(9) &
                                dRow("ID_ADICIONAL").ToString & Chr(9) &
                                "0" & Chr(9) &
                                dRow("COSTO_DETALLE").ToString & Chr(9) &
                                dRow("IMPORTE").ToString & Chr(9) &
                                dRow("ID_COMPRA_DETALLE").ToString & Chr(9) &
                                "" & Chr(9) &
                                "" & Chr(9) &
                                dRow("PRECIO_USD").ToString & Chr(9)) 'El 0 es para el flete pero todavia no lo calculamos

            Next

            bResultado = True

            If valorNumericoD(Me.txtFleteOrdenCompra.Text) > 0 Then
                Me.ProrratearFlete()
            Else
                Me.Totales()
            End If

            Me.EstableceCuentaContableAlmacenDestino()

            Me.Grid1.Locked = False 'Podria estar bloqueado si era un docto nuevo

            Me.txtFolioOrdenCompra.Enabled = False
            Me.btnConsultarOrdenCompra.Enabled = False

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        Finally
            Me.Grid1.AutoRedraw = True
            Me.Grid1.Refresh()
        End Try

        Return bResultado
    End Function

    Private Sub InicializaOrdenCompra()
        Const sProcedure As String = "InicializaOrdenCompra"
        Try
            'Estos datos que se establezcan en blanco deberán también establecerse en el inicializa normal
            Me.txtFolioOrdenCompra.Text = ""
            Me.txtFleteOrdenCompra.Text = ""
            Me.txtProveedor.Text = ""
            Me.dtpFechaEntrega.Value = Date.Now
            Me.cboEntradasAnterioresOrdenCompra.DataSource = Nothing

            Me.InicializaGrid()
            Me.InicializaGridSeries()

            Me.txtFolioOrdenCompra.Enabled = True
            Me.txtFolioOrdenCompra.Focus()

            Me.btnConsultarOrdenCompra.Enabled = True

            Me.Totales()
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Function ProrratearFlete() As Boolean
        Const sProcedure As String = "ProrratearFlete"
        Dim bResultado As Boolean = False
        Try
            Dim dFleteTotal As Decimal = valorNumericoD(Me.txtFleteOrdenCompra.Text)
            Dim dCantidadTotal As Decimal = CDec(FG_Grid_SumaCol(Me.Grid1, CShort(Me.iGyCantidad)))
            Dim dCantidad As Decimal = 0, dCosto As Decimal = 0, dFleteImporte As Decimal = 0

            If dFleteTotal <= 0 Then
                MsgBox("Falta capturar el flete total.", vbExclamation, sProcedure)
                Return False
            End If

            If dCantidadTotal <= 0 Then
                MsgBox("El total de la cantidad de todos los artículos es de 0, no se puede calcular el prorrateo.", vbExclamation, sProcedure)
                Return False
            End If

            For i As Integer = 1 To Me.Grid1.Rows - 1
                If txtLEN(Me.Grid1.Cell(i, Me.iGyCodigo).Text) = False Then
                    Continue For
                End If

                dCantidad = valorNumericoD(Me.Grid1.Cell(i, Me.iGyCantidad).Text)
                dCosto = valorNumericoD(Me.Grid1.Cell(i, Me.iGyCosto).Text)
                dFleteImporte = RedondearD((dCantidad / dCantidadTotal) * dFleteTotal, Empresa_Sistema.DECIMALES_CONTABILIDAD)

                Me.Grid1.Cell(i, Me.iGyFleteDetalleImporte).Text = dFleteImporte.ToString

                'Esto se hace en el totales
                'Me.Grid1.Cell(i, Me.iGyCostoMasFlete).Text = RedondearD(dCosto + (dFleteImporte / dCantidad), Empresa_Sistema.DECIMALES_PRECIO).ToString 'Simula un flete unitario para tener un costo mas flete(que no se usa para importe-flete por tropos)
                'Me.Grid1.Cell(i, Me.iGyImporteMasFlete).Text = (valorNumericoD(Me.Grid1.Cell(i, Me.iGyImporte).Text) + dFleteImporte).ToString
            Next

            bResultado = True

            Me.Totales()

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    Private Function ValidaFlete() As Boolean
        Const sProcedure As String = "ValidaFlete"
        Try
            Dim dFlete As Decimal = CDec(FG_Grid_SumaCol(Me.Grid1, CShort(Me.iGyFleteDetalleImporte)))
            Dim dDiferencia As Decimal = RedondearD(valorNumericoD(Me.txtFleteOrdenCompra.Text) - dFlete, 2)
            If dDiferencia <> 0 Then
                MsgBox("La suma de los fletes de los artículos es de " & FormatImporteContable(dFlete) & " y la especificada es de " & FormatImporteContable(valorNumericoD(Me.txtFleteOrdenCompra.Text)), vbExclamation, sProcedure)
                Return False
            End If

            Return True
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Function

    'Esta originalmente esta función en vez del nueva que esta mas completa.
    'Private Function EstableceCuentaContableAlmacenDestino() As Boolean
    '    Dim bResultado As Boolean = False
    '    Dim i As Integer
    '    Try
    '        Dim oAlmacenes = New Class_CatAlmacenes(Me.CboAlmacenDestino.SelectedValue.ToString)
    '        Dim oArticulos = New Class_CatArticulos

    '        For i = 1 To Me.Grid1.Rows - 1
    '            If txtLEN(Me.Grid1.Cell(i, Me.iGyCodigo).Text) = True Then
    '                Me.Grid1.Cell(i, Me.iGyCuentaContable).Text = oAlmacenes.CUENTA_CONTABLE.ToString + oArticulos.ObtenerFamiliaArticulo(Me.Grid1.Cell(i, Me.iGyCodigo).Text).ToString
    '            End If
    '        Next
    '        bResultado = True
    '    Catch ex As Exception
    '        HandleError(Me.Name, "EstableceCuentaContableAlmacenDestino", ex)
    '    End Try
    '    Return bResultado
    'End Function

    Private Function EstableceCuentaContableAlmacenDestino() As Boolean
        Const sProcedure As String = "EstableceCuentaContableAlmacenDestino"
        Try
            Dim oAlmacenes As New Class_CatAlmacenes(Me.CboAlmacenDestino.SelectedValue.ToString), i As Integer, sCuentaContable As String = "", oCuenta As Class_CatCuentas
            Dim oArticulos As Class_CatArticulos

            For i = 1 To Me.Grid1.Rows - 1
                If txtLEN(Me.Grid1.Cell(i, Me.iGyCodigo).Text) = True Then
                    oArticulos = New Class_CatArticulos(Me.Grid1.Cell(i, Me.iGyCodigo).Text)
                    If oArticulos.INVENTARIABLE = "1" Then
                        sCuentaContable = oAlmacenes.CUENTA_CONTABLE.ToString '+ oArticulos.ObtenerFamiliaArticulo(Me.Grid1.Cell(i, Me.iGyCodigo).Text).ToString 'Se quitó el nivel familia dentro de las cuentas de almacén. NOV/2020
                        oCuenta = New Class_CatCuentas(sCuentaContable)

                        Me.Grid1.Cell(i, Me.iGyCuentaContable).Text = sCuentaContable
                        If oCuenta._Existe = True Then
                            Me.Grid1.Cell(i, Me.iGyNombreCuentaContable).Text = oCuenta.NOMBRE_CUENTA
                        Else
                            Me.Grid1.Cell(i, Me.iGyNombreCuentaContable).Text = ""
                        End If

                    End If
                End If
            Next

            Return True
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Function

    Private Function ValidaCantidadesDisponiblesOrdenCompra() As Boolean
        Const sProcedure As String = "ValidaCantidadesDisponiblesOrdenCompra"
        Try
            Dim i As Integer, IDCompraDetalle As Integer = 0

            Dim oOC As New Class_Compras_Global(Me.txtFolioOrdenCompra.Text, "OC" & Plaza.CODIGO_PLAZA.ToString)

            If oOC.Existe = False Then
                MsgBox("Asígne una orden de compra válida.", MsgBoxStyle.Exclamation, sProcedure)
                Me.txtFolioOrdenCompra.Focus()
                Return False
            End If

            For i = 1 To Me.Grid1.Rows - 1
                If txtLEN(Me.Grid1.Cell(i, Me.iGyCodigo).Text) = True Then
                    IDCompraDetalle = CInt(Me.Grid1.Cell(i, Me.iGyIDCompraDetalle).Text)

                    If IDCompraDetalle <= 0 Then
                        MsgBox("El renglón #" & i.ToString & " no esta relacionado a un renglón de la orden de compra.", MsgBoxStyle.Exclamation, sProcedure)
                        Return False
                    End If

                    'Valida que el IDCompraDetalle le pertenezca a la orden de compra seleccionada.
                    If oOC.ValidaExistaIDCompraDetalle(IDCompraDetalle) = False Then
                        MsgBox("El id de compra detalle del renglón " & i.ToString & " no corresponde a esta orden de compra.", MsgBoxStyle.Exclamation, sProcedure)
                        Return False
                    End If

                    If oOC.ValidaCantidadDisponibleArticulo(IDCompraDetalle, CDbl(Me.Grid1.Cell(i, Me.iGyCantidad).Text)) = False Then
                        MsgBox("La cantidad debe de ser menor al disponible.", MsgBoxStyle.Exclamation, sProcedure)
                        Me.Grid1.Cell(i, Me.iGyCantidad).SetFocus()
                        Return False
                    End If
                End If
            Next i

            Return True
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Function

    Private Function GestionaArchivoSeries() As Boolean
        Const sProcedure As String = "GestionaArchivoSeries"
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
                Me.TpSeries.Focus()
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
            HandleError(Me.Name, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    Private Function SeleccionarArchivo() As String
        Const sProcedure As String = "SeleccionarArchivo"
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
            HandleError(Me.Name, sProcedure, ex)
        End Try

        Return sRutaArchivo
    End Function

    Private Function CantidadArticulosSerie(ByVal sCodigoArticulo As String) As Integer
        Const sProcedure As String = "CantidadArticulosSerie"
        Dim iArticulosEncontrados As Integer = 0
        Try
            For i = 1 To Me.GridSeries.Rows - 1
                If Me.GridSeries.Cell(i, Me.igySerieCodigo).Text = sCodigoArticulo Then
                    iArticulosEncontrados += 1
                End If
            Next
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
        Return iArticulosEncontrados
    End Function

    Private Function ValidaOrdenCompra() As Boolean
        Const sProcedure As String = "ValidaOrdenCompra"
        Dim bResultado As Boolean = False
        Try
            If txtLEN(Me.txtFolioOrdenCompra.Text) = False Then
                MsgBox("Indique el folio de la orden de compra.", MsgBoxStyle.Exclamation, sProcedure)
                If Me.txtFolioOrdenCompra.Enabled = True Then
                    Me.txtFolioOrdenCompra.Focus()
                End If
                Return False
            End If

            Dim oOrdenCompra As New Class_Compras_Global(Me.txtFolioOrdenCompra.Text, "OC" & Plaza.CODIGO_PLAZA.ToString)

            If oOrdenCompra.Existe = False Then
                MsgBox("La orden de compra no existe.", MsgBoxStyle.Exclamation, sProcedure)
                If Me.txtFolioOrdenCompra.Enabled = True Then
                    Me.txtFolioOrdenCompra.Focus()
                End If
                Return False
            End If

            Me.OcTieneRequisicion = ValidaOcTieneRequisicion(Me.txtFolioOrdenCompra.Text)

            If Empresa_Sistema.MODO_REQUISICIONES_INVENTARIO AndAlso Me.OcTieneRequisicion Then    'If Empresa_Sistema.MODO_REQUISICIONES_INVENTARIO AndAlso txtLEN(oOrdenCompra.FOLIO_REQUISICION) Then
                'Solo validara estatus P para OC con requisicion
                If Not (oOrdenCompra.ESTATUS = "P" Or oOrdenCompra.ESTATUS = "R") Then
                    MsgBox("La orden de compra tiene requisición de inventario, debe estar en estatus P(Pedida) o R(Parcialmente recepcionada) para hacer la entrada.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If

            Else
                If Not (oOrdenCompra.ESTATUS = "G" Or oOrdenCompra.ESTATUS = "R") Then
                    MsgBox("La orden de compra no esta en estatus G(Grabada) o R(Parcialmente recepcionada).", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If
            End If

            Dim oOC As New Class_find("SELECT OC.FOLIO_COMPRA FROM COMPRA_GLOBAL OC INNER JOIN VW_SIS_CAT_DOCUMENTOS_EXTENDIDO DOC ON(OC.CODIGO_DOCUMENTO=DOC.CODIGO_DOCUMENTO) " &
            "WHERE OC.FOLIO_COMPRA='" & sReplace(Me.txtFolioOrdenCompra.Text) & "' AND DOC.CODIGO_TIPO_DOCUMENTO='OC' ")

            If txtLEN(oOC.Result1) = False Then
                MsgBox("Este documento no es una orden de compra.", vbExclamation, sProcedure)
                Return False
            End If

            If Me.CboAlmacen.SelectedValue.ToString <> oOrdenCompra.CODIGO_ALMACEN Then
                MsgBox("La orden de compra tiene el almacén " & oOrdenCompra.CODIGO_ALMACEN & " y es diferente al que tiene seleccionado en este movimiento.", vbExclamation, sProcedure)
                Return False
            End If

            If Me.ValidaCantidadesDisponiblesOrdenCompra() = False Then
                Return False
            End If

            bResultado = True

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    Private Function ValidaComprasEntradasRecepcion() As Boolean
        Dim sql As New Class_find("SELECT C.FOLIO_COMPRA FROM COMPRAS_RELACION_ENTRADAS_INVENTARIOS R INNER JOIN COMPRA_GLOBAL C ON(C.FOLIO_COMPRA=R.FOLIO_COMPRA) " &
                                  "WHERE C.ESTATUS = 'A' AND R.FOLIO_MOVIMIENTO_INVENTARIO = '" & Me.TxtFolio.Text & "'")

        If txtLEN(sql.Result1) Then
            MsgBox("No se puede cancelar la entrada por recepción porque esta aplicada en la compra " & sql.Result1, MsgBoxStyle.Exclamation, Me.Text)
            Return False
        End If

        Return True
    End Function

    Private Function ValidaEsTransformacion(ByVal sFolio As String, ByVal sCodigoTipoDocumento As String) As Boolean
        Dim tipoFolio As String = "", resultado As String = ""

        'Los movimientos de las transformacione son entradas y salidas normales
        If sCodigoTipoDocumento = "ENI" Then
            tipoFolio = "FOLIO_ENTRADA_TRANSFORMACION"
        ElseIf sCodigoTipoDocumento = "SAI" Then
            tipoFolio = "FOLIO_SALIDA_TRANSFORMACION"
        End If

        If txtLEN(tipoFolio) Then
            Dim sql As New Class_find("SELECT " & tipoFolio & " FROM INVENTARIOS_TRANSFORMACIONES_RELACION_ENTRADAS_SALIDAS WHERE " & tipoFolio & "='" & sFolio & "' ")
            resultado = sql.Result1
        End If

        Return txtLEN(resultado)

    End Function

    Private Function ValidaOcTieneRequisicion(ByVal sFolioOc As String) As Boolean
        Dim oCompras As Class_Compras_Global

        Try
            oCompras = New Class_Compras_Global(sFolioOc, "OC" & Plaza.CODIGO_PLAZA.ToString)

            'Para que una OC se tenga requsicion debe tener folio de requisicion o al menos un renglon que sea ES_REQUISICION=1
            If txtLEN(oCompras.FOLIO_REQUISICION) Then
                Return True
            End If

            Dim sql As New Class_find("SELECT ES_REQUISICION FROM COMPRA_DETALLE WHERE ES_REQUISICION IS NOT NULL AND FOLIO_COMPRA='" & sFolioOc & "'")

            If sql.Result1 = "1" Then
                Return True
            End If

            Return False

        Catch ex As Exception
            HandleError(Me.Name, "ValidaOcTieneRequisicion", ex)
        End Try
    End Function

    Private Function RepiteLote(ByVal Renglon As Integer, ByVal ID_INVENTARIO_LOTES_COSTOS As String) As Boolean
        Const sProcedure As String = "RepiteLote"
        Dim RenglonRepetido As Integer
        Try
            For i = 1 To Me.Grid1.Rows - 1
                If i <> Renglon Then
                    If txtLEN(Me.Grid1.Cell(i, Me.iGyID_INVENTARIO_LOTES_COSTOS).Text) = True Then
                        If ID_INVENTARIO_LOTES_COSTOS = Me.Grid1.Cell(i, Me.iGyID_INVENTARIO_LOTES_COSTOS).Text Then
                            RenglonRepetido = i

                            MsgBox("El lote del artículo " & Me.Grid1.Cell(RenglonRepetido, iGyCodigo).Text & " esta repetido en el renglón " & RenglonRepetido & "." & vbCrLf &
                                   "No es válido repetir lotes.", MsgBoxStyle.Exclamation, sProcedure)
                            Me.Grid1.Cell(RenglonRepetido, Me.iGyCodigo).SetFocus()

                            Return True
                        End If
                    End If
                End If
            Next
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Function

    Private Sub DesplegarMonedas()
        Const sProcedure As String = "DesplegarMonedas"
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
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Sub ObtenerTipoCambioDia()
        Const sProcedure As String = "ObtenerTipoCambioDia"
        Try
            If Me.Estado = enumEstados.NUEVO Or Me.Estado = enumEstados.GRABADO Then
                Dim oTipoCambio As New Class_CatTiposCambio(Me.DtpFecha.Value)
                Me.txtTipoCambio.Text = "0"

                If oTipoCambio.Existe = True AndAlso oTipoCambio.TIPO_DE_CAMBIO > 0 Then
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

    Private Sub Inventarios_Movimientos_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        'If Me._LlamadoExteriorRecepcionarEntradaOrdenCompra = True Then
        '    Stop
        '    MsgBox("totalizar aqui ?")
        'End If
    End Sub

#End Region

End Class