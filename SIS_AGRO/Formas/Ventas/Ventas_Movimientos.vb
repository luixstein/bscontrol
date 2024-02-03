Option Strict On
Imports System.Web.Services.Description

Public Class Ventas_Movimientos

#Region "Campos privados"
    Private oVenta As New Class_Ventas_Global
    Private oDocumento As New Class_CatDocumentos
    Private oCliente As New Class_CatClientes
    Private oCuentas As New Class_CatCuentas
    Private oCentroCostos As New Class_CatCentroCostos

    Private Estado As enumEstados
    Private sTipoVenta As String = "NM" 'NORMAL
    Private sCodigoDocumentoFacturaExterno As String = ""

    Private dTotalSustitucion As Double = 0
    Private bVentaAutorizadaPorRegla As Boolean
    Private dPorcentajeIVAGlobal As Double = 0
    Private EsFacturaVariasRemisiones As Boolean = False

    Private Enum enumEstados
        NUEVO
        GRABADO
        SUSTITUIDO
        APLICADO
        CANCELADO
        PARCIALMENTE_RECEPCIONADO
        SUSTITUYENDO
    End Enum

    Private dTablaMetodosPago As DataTable
    Private dtSeries As DataTable

    Private bCargandoVenta As Boolean
    Private sTipoVentaAnterior As String, sMonedaAnterior As String, dViewFormasPago As New Data.DataView
    Private bClienteEsContribuyenteIEPS As Boolean = False, bCrearonColumnas As Boolean = False
    Private iDecimalesPrecio As Integer = 6
#End Region

#Region "Columnas grid ventas"
    Private igyCodigo As Short = 1
    Private igyTipoControlInventariable As Short = 2
    Private igyDescripcion As Short = 3
    Private igyCantidad As Short = 4
    Private igyPrecio As Short = 5
    Private igyPrecio_USD As Short = 6
    Private igyPRECIO_TOTAL As Short = 7
    Private igyPRECIO_TOTAL_USD As Short = 8
    Private igyUnidad As Short = 9
    Private igyCantidadKilos As Short = 10
    Private igyPrecioKilos As Short = 11
    Private igyImpuestoPorcentaje As Short = 12
    Private igyImporte As Short = 13
    Private igyImporte_USD As Short = 14
    Private igyImporteKilos As Short = 15
    Private igyCuentaContable As Short = 16
    Private igyImpuestoImporte As Short = 17
    Private igyImpuestoImporte_USD As Short = 18
    Private igyIdOrigen As Short = 19
    Private igyEsProductoKilos As Short = 20
    Private igyCodigoCentroCosto As Short = 21
    Private igyNombreCentroCosto As Short = 22
    Private igyIEPS_PORCENTAJE As Short = 23
    Private igyIEPS_UNITARIO As Short = 24
    Private igyIEPS_UNITARIO_USD As Short = 25
    Private igyIEPS_IMPORTE As Short = 26
    Private igyIEPS_IMPORTE_USD As Short = 27
    Private igyBASE_IEPS As Short = 28
    Private igyBASE_IEPS_USD As Short = 29
    Private igyBASE_IVA As Short = 30
    Private igyBASE_IVA_USD As Short = 31
    Private igyCosto As Short = 32
    Private igyUtilidadUnitaria As Short = 33
    Private igyUtilidadTotal As Short = 34
    Private igyUtilidadPorcentaje As Short = 35
    Private iGyID_SIS_CAT_IMPUESTOS As Short = 36
    Private iGyGRADO_TOXICIDAD As Short = 37
    Private iGyDESCUENTO_UNITARIO As Short = 38
    Private iGyDESCUENTO_UNITARIO_USD As Short = 39
    Private iGyDESCUENTO_IMPORTE As Short = 40
    Private iGyDESCUENTO_IMPORTE_USD As Short = 41
    Private iGyPRECIO_CON_DESCUENTO As Short = 42
    Private iGyPRECIO_CON_DESCUENTO_USD As Short = 43
    'Private  iGyIdSisCatImpuestosFlete As Short = 44
    'Private  iGyFletePorcentaje As Short = 45
    'Private  iGyFleteImporte As Short = 46
    'Private  iGyFleteImporte_USD As Short = 47
    Private iGyRETENCION_IVA_TIENE As Short = 44
    Private iGyRETENCION_IVA_PORCENTAJE As Short = 45
    Private iGyRETENCION_IVA_BASE As Short = 46
    Private iGyRETENCION_IVA_BASE_USD As Short = 47
    Private iGyRETENCION_IVA_IMPORTE As Short = 48
    Private iGyRETENCION_IVA_IMPORTE_USD As Short = 49
    Private iGyRETENCION_ISR_TIENE As Short = 50
    Private iGyRETENCION_ISR_PORCENTAJE As Short = 51
    Private iGyRETENCION_ISR_BASE As Short = 52
    Private iGyRETENCION_ISR_BASE_USD As Short = 53
    Private iGyRETENCION_ISR_IMPORTE As Short = 54
    Private iGyRETENCION_ISR_IMPORTE_USD As Short = 55
#End Region

#Region "Columnas grid series"
    Private igySeriePosicion As Short = 1
    Private igySerieCodigo As Short = 2
    Private igySerieDescripcion As Short = 3
    Private igySerieIdInventarioLotesCostos As Short = 4
    Private igySerieNumeroSerie As Short = 5
    Private igySerieIDOrigen As Short = 6
    Private igySerieFolioRemision As Short = 7
#End Region

#Region "Columnas grid CFDIs relacionados"
    Private iGyGRFolio As Short = 1
    Private iGyGRFecha As Short = 2
    Private iGyGRConcepto As Short = 3
    Private iGyGRUUID As Integer = 4
    Private iGyGRTotal As Short = 5
#End Region

#Region "Columnas grid Facturas varias remisiones"
    Private iGyFolio As Short = 1
    Private iGyFecha As Short = 2
    Private iGyTotal As Short = 3
    Private iGyMoneda As Short = 4
    Private iGyConcepto As Short = 5
#End Region

#Region "Columnas grid Entidades Complemento INE"
    Private iGyCodigoEntidad As Short = 1
    Private iGyNombreEntidad As Short = 2
    Private iGyCodigoAmbito As Short = 3
    Private iGyNombreAmbito As Short = 4
    Private iGyIdContabiliad As Short = 5
    Private iGyIdAdicional As Short = 6
#End Region

#Region "Campos/propiedades para facturas embarques extrajeros que se inician desde otra pantalla"
    Private _EsPorEmbarqueExtranjero As Boolean = False
    'Private sFolioEmbarqueExtranjero As String = ""
    Private _oEmbarqueExtranjero As Class_Embarques_EmbarqueGlobal
    Private _TipoCambioPorEmbarqueExtranjero As Double
    Private _ObservarcionesPorEmbarqueExtranjero As String
    Private _GrabadaFacturaEmbarqueExtranjero As Boolean = False
    'Private _FormaActivadaPorEmbarqueExtranjero As Boolean = False

    Public WriteOnly Property EsPorEmbarqueExtranjero As Boolean
        Set(value As Boolean)
            Me._EsPorEmbarqueExtranjero = value
        End Set
    End Property

    Public WriteOnly Property oEmbarqueExtranjero As Class_Embarques_EmbarqueGlobal
        Set(value As Class_Embarques_EmbarqueGlobal)
            Me._oEmbarqueExtranjero = value
        End Set
    End Property

    Public WriteOnly Property TipoCambioPorEmbarqueExtranjero As Double
        Set(value As Double)
            Me._TipoCambioPorEmbarqueExtranjero = value
        End Set
    End Property

    Public WriteOnly Property ObservarcionesPorEmbarqueExtranjero As String
        Set(value As String)
            Me._ObservarcionesPorEmbarqueExtranjero = value
        End Set
    End Property

    Public ReadOnly Property GrabadaFacturaEmbarqueExtranjero As Boolean
        Get
            Return Me._GrabadaFacturaEmbarqueExtranjero
        End Get
    End Property

#End Region

#Region "Opciones"
    Private Sub tsbNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbNuevo.Click
        Me.Inicializa()
        Me.Cambia_Estado(enumEstados.NUEVO)
        Me.sTipoVenta = "NM" 'NORMAL
        Me.sCodigoDocumentoFacturaExterno = ""
    End Sub

    Private Sub tsbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGrabar.Click
        If Me.Grabar() = True Then
            Me.Consultar()
        End If
    End Sub

    Private Sub tsbCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCancelar.Click
        Const sProcedure As String = "tsbCancelar_Click"
        Try
            If Me.oVenta.ESTATUS_VENTA = "A" Or Me.oVenta.ESTATUS_VENTA = "G" Then
                If Me.CancelarVenta = True Then  'Se cancelo el documento correctamente = true
                    'If Me.oVenta.VERSION_ESQUEMA_XML > "2.2" And oDocumento.TIMBRA_DOCUMENTO = True Then 'Si es CFDi
                    If Me.oVenta.VERSION_ESQUEMA_XML > "2.2" And txtLEN(Me.oVenta.FOLIO_FISCAL_SAT) = True Then 'Puede ser un documento no timbrable que le subieron un xml externo
                        Me.oVenta.CancelarTimbre()
                    End If
                    MsgBox("Movimiento cancelado satisfactoriamente.", MsgBoxStyle.Information, Me.Text)
                End If
                Me.Consultar()
                Me.GestionaCambioEstado()
            End If
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Sub tsbCotizacionRemision_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCotizacionRemision.Click
        sTipoVenta = "SCR" 'SUSTITUCION DE COTIZACION A REMISION
        Me.Consultar(True)
    End Sub

    Private Sub tsbCotizacionFactura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCotizacionFactura.Click
        Const sProcedure As String = "tsbCotizacionFactura_Click"
        Try
            sTipoVenta = "SCF" 'SUSTITUCION DE COTIZACION A FACTURA

            Dim oTF As New VentasSeleccionaTipoFactura
            oTF.ShowDialog()

            sCodigoDocumentoFacturaExterno = oTF.CboDocumento.SelectedValue.ToString

            If Me.Consultar(True) = True Then
                Me.EstableceCuentasContables()
                Me.Totales()
            End If
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Sub tsbRemisionVenta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRemisionVenta.Click
        Const sProcedure As String = "tsbRemisionVenta_Click"
        Try

            If oVenta.SiRemisionTieneMovimientosAbonoParaEvitarSustitucion(Me.txtFolio.Text) = True Then 'Aqui aún no se convierte a rem, entonces el folio sale del txtFolio
                Return
            End If

            sTipoVenta = "SR" 'SUSTITUCION DE REMISION

            Dim oTF As New VentasSeleccionaTipoFactura
            oTF.ShowDialog()

            sCodigoDocumentoFacturaExterno = oTF.CboDocumento.SelectedValue.ToString

            If Me.Consultar(True, False) = True Then
                Me.EstableceCuentasContables()
                Me.Totales()
                Me.tsbTimbrar.Visible = False

                If valorNumericoD(Me.lblDescuento.Text) > 0 Then
                    MsgBox("La remisión tenia descuento y este se heredó a la factura, revíse si va afectar el mismo descuento ." & vbCrLf & "(Si factura menos producto que en la remisión original usted debe establecer un descuento menor)", vbInformation, "Advertencia")
                End If

            End If

            'No lo puse porque entonces no se podrian poner comentarios en una sustitución
            'Me.Grid.Row(Me.Grid.Rows - 1).Locked = True  'Para bloquear la edición del último renglón

            'f6 que haria en una sust?, Queryable mejor no haya f6 , si borran de mas y quieren poner, Que le den nuevo y empiezen otra vez

            'Me.Grid.Locked = True
            'Me.Grid.Column(Me.igyCodigo).Locked = True 'No podrán cambiar códigos ni ponerlos con f6'ya no se ejecuta aqui porque ahora se cargan las remisiones con el método de varias remisiones y haya se bloquean celdas de códigos.
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Sub tsbFacturaACartaPorte_Click(sender As Object, e As EventArgs) Handles tsbFacturaACartaPorte.Click
        Const sProcedure As String = "tsbFacturaACartaPorte_Click"
        Try
            Dim oSQL As New Class_find("SELECT TOP 1 FOLIO_VENTA FROM VENTA_GLOBAL WHERE CODIGO_DOCUMENTO LIKE 'FT%' AND FOLIO_REFERENCIA='" & sReplace(Me.txtFolio.Text) & "' AND ESTATUS_VENTA='A' ORDER BY ID_VENTA_GLOBAL DESC")

            If txtLEN(oSQL.Result1) = True Then
                MsgBox("Esta factura ya fue convertida a una factura de traslado con carta porte con el folio " & oSQL.Result1, vbExclamation, sProcedure)
                Return
            End If

            sTipoVenta = "FT" 'FACTURA DE TRASLADO

            If Me.Consultar(True, True) = True Then
                Me.Totales()
                Me.tsbTimbrar.Visible = False
            End If

            Me.txtUsoCFDI.Text = "P01"
            Me.txtUsoCFDI.Enabled = False
            Me.cboMoneda.Text = "XXX"
            Me.cboMoneda.Enabled = False
            Me.cboFormaPago.SelectedIndex = -1
            Me.cboFormaPago.Enabled = False
            Me.cboMetodoPago.SelectedIndex = -1
            Me.chkTieneCCE.Checked = False
            Me.chkTieneCartaPorte.Checked = True

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click
        'If txtLEN(Me.oVenta.SELLO_DIGITAL) = False And Me.oDocumento.AFECTA_CONTABILIDAD = True Then
        'Me.oVenta.Consultar()
        'If Me.oVenta.VERSION_ESQUEMA_XML >= "3.2" Then
        '    If txtLEN(Me.oVenta.FOLIO_FISCAL_SAT + Me.oVenta.FECHA_TIMBRADO_SAT + Me.oVenta.NUMERO_SERIE_CERTIFICADO_SAT + Me.oVenta.SELLO_SAT) = False And txtLEN(Me.oVenta.CBB_IMAGE.ToString) = False And Me.oDocumento.TIMBRA_DOCUMENTO = True Then
        '        MsgBox("La factura debe de estar sellada para poder imprimir.", MsgBoxStyle.Exclamation, Me.Text)
        '        Exit Sub
        '    End If
        'End If
        If Me.oDocumento.TIMBRA_DOCUMENTO = True Then
            If txtLEN(Me.oVenta.FOLIO_FISCAL_SAT) = False Then
                MsgBox("Advertencia: esta venta no esta timbrada.", MsgBoxStyle.Exclamation, Me.Text)
            End If
        End If
        Me.oVenta.Imprimir()
    End Sub

    Private Sub tsbTimbrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbTimbrar.Click
        If Me.oVenta.TIMBRADO_CFDI = "0" Then
            If Me.oDocumento.TIMBRA_DOCUMENTO = False Then
                MsgBox("Este tipo de documento no es timbrable.", vbExclamation, Me.Text)
                Return
            End If
            If Me.oVenta.GeneraFacturaElectronica(True, True) = True Then
                Me.Consultar()
            Else
                MsgBox("Los datos digitales del documento no fueron generados correctamente. Avíse al depto. de sistemas.", vbExclamation, Me.Text)
            End If
        Else
            MsgBox("El documento ya esta timbrado.", MsgBoxStyle.Exclamation, Me.Text)
        End If
    End Sub

    Private Sub tsbCancelarTimbre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCancelarTimbre.Click
        If Me.oVenta.CancelarTimbre() = True Then
            MsgBox("Timbre cancelado satisfactoriamente.", MsgBoxStyle.Information, Me.Text)
            Me.Consultar()
        End If
    End Sub

    Private Sub tsbRecuperaFacturaElectronica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If Me.oVenta.TIMBRADO_CFDI = "0" Then
        '    If RecuperarFacturaElectronicaLocal(True) = True Then
        '        'ExportarAPdf()
        '    End If
        'End If
    End Sub

    Private Sub tsbRecuperarXMLPDF_Click(sender As Object, e As EventArgs) Handles tsbRecuperarXMLPDF.Click
        Me.oVenta.RecuperarXMLyPDF()
    End Sub

    Private Sub tsbEnviar_Click(sender As Object, e As EventArgs) Handles tsbEnviarCorreo.Click
        Me.EnviarCorreo()
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub

    Private Sub btnSeries_Click(sender As Object, e As EventArgs) Handles btnSeries.Click
        Me.PrepararSeries()
    End Sub

    Private Sub tsbSubirXML_Click(sender As Object, e As EventArgs) Handles tsbSubirXML.Click
        Me.SubirXML()
    End Sub
    Private Sub btnCartaPorte_Click(sender As Object, e As EventArgs) Handles btnCartaPorte.Click
        Me.GestionaCartaPorte()
    End Sub

    Private Sub btnAgregarRenglon_Click(sender As Object, e As EventArgs) Handles btnAgregarRenglon.Click
        Me.Grid.Rows += 1
    End Sub

    Private Sub btnMostrarMasColumnasGridSeries_Click(sender As Object, e As EventArgs) Handles btnMostrarMasColumnasGridSeries.Click
        Me.GridSeries.Column(Me.igySerieIdInventarioLotesCostos).Visible = Not (Me.GridSeries.Column(Me.igySerieIdInventarioLotesCostos).Visible)
        Me.GridSeries.Column(Me.igySerieIDOrigen).Visible = Not (Me.GridSeries.Column(Me.igySerieIDOrigen).Visible)
    End Sub

#End Region

#Region "Eventos de objetos"
    Private Sub Ventas_Movimientos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Const sProcedure As String = "Ventas_Movimientos_Load"
        Try
            Me.DesplegarAlmacenes()
            Me.DesplegarTiposMercados()
            Me.DesplegarVendedores()

            Me.DesplegarMetodosPago()
            Me.DesplegarMonedas()
            Me.DesplegarFormasPago(False)
            Me.DesplegarTiposNegociaciones()
            Me.DesplegarTiposCredito()
            Me.DesplegarTiposRelacionCFDI()
            Me.DesplegarRegimenesFiscales()
            Me.DesplegarIncoterm()

            Me.DesplegarDocumentos()

            Me.Inicializa()
            Me.bCrearonColumnas = True
            Me.GestionaMoneda()

            Me.Cambia_Estado(enumEstados.NUEVO)

            If Not Me._oEmbarqueExtranjero Is Nothing Then
                Me.GestionaFacturaEmbarqueExtranjero()
            End If

            If Empresa_Sistema.VERSION_ESQUEMA_CFD <= "3.2" Then
                Me.txtNumeroCuentaPago.Visible = True : Me.lblDisplayNumeroCuentaPago.Visible = True
                Me.txtUsoCFDI.Visible = False : Me.lblDisplayUsoCFDI.Visible = False
                Me.cboMetodoPago.Visible = False : Me.lblDisplayMetodoPago.Visible = False
                Me.cboRegimenFiscalEmisor.Visible = False : Me.lblDisplayRegimenFiscalEmisor.Visible = False
            Else '3.3 O Mayores
                Me.txtNumeroCuentaPago.Visible = False : Me.lblDisplayNumeroCuentaPago.Visible = False

                'Me.cboFormaPago.Enabled = False
                Me.cboFormaPago.SelectedValue = "99" '"99-Por definir"
            End If

            Me.ckbMostrarUtilidad.Checked = False

            If Usuario.VER_COSTOS = False Then
                Me.ckbMostrarUtilidad.Visible = False
            Else
                Me.ckbMostrarUtilidad.Visible = True
            End If

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Sub Ventas_Movimientos_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        ''If e.KeyCode = Keys.A  AndAlso (e.Control) Then
        'If e.Alt = True AndAlso e.Control = True AndAlso e.Shift = True AndAlso e.KeyCode = Keys.A Then
        '    MsgBox("eale")
        'End If
    End Sub

    Private Sub TxtCodigoCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCliente.KeyDown
        Dim sText As String = ""
        Select Case e.KeyCode
            Case Keys.F6
Buscar:
                If Empresa_Sistema.PERMITE_CLIENTES_MULTIPLAZA = True Then
                    sText = Me.oCliente.BusquedaVisual_PorDescripcionSinFiltroZona
                Else
                    sText = Me.oCliente.BusquedaVisualPlaza
                End If

                If txtLEN(sText) = True Then Me.TxtCliente.Text = sText
            Case Keys.Enter
                If txtLEN(Me.TxtCliente.Text) = False OrElse Me.ConsultarCliente() = False Then 'Con OrElse si la 1er condición se cumple no se evalua las siguientes
                    Me.lblCliente.Text = "" : GoTo Buscar : Exit Sub
                End If

                If Me.oDocumento.AFECTA_CONTABILIDAD = True Then
                    If Me.chkVentaPublicoGeneral.Checked = False Then
                        'If Me.ValidarDatosCliente() = False Then
                        '    Exit Sub
                        'End If
                    End If
                End If

                SendKeys.Send("{TAB}")
        End Select
    End Sub

    Private Sub CmbDocumento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboDocumento.SelectedIndexChanged
        Me.oVenta.CODIGO_DOCUMENTO = Me.CboDocumento.SelectedValue.ToString
        Me.oDocumento = New Class_CatDocumentos(Me.oVenta.CODIGO_DOCUMENTO)
        Me.Inicializa()
        Me.Cambia_Estado(enumEstados.NUEVO)

        'If Me.oDocumento.AFECTA_INVENTARIOS = False Then 'COTIZACION
        '    If Me.LblEstatus.Text = "G" Or Me.LblEstatus.Text = "R" Then
        '        Me.tsbCotizacionRemision.Visible = True
        '        Me.tsbCotizacionFactura.Visible = True
        '        Me.tsbRemisionVenta.Visible = False
        '    Else
        '        Me.tsbCotizacionRemision.Visible = False
        '        Me.tsbCotizacionFactura.Visible = False
        '        Me.tsbRemisionVenta.Visible = False
        '    End If

        'Else
        If Me.oDocumento.AFECTA_CONTABILIDAD = True Then 'FACTURA
            Me.txtFolioEmbarque.Enabled = True
        Else
            Me.txtFolioEmbarque.Enabled = False
            '    Me.tsbCotizacionRemision.Visible = False
            '    Me.tsbCotizacionFactura.Visible = False
            '    Me.tsbRemisionVenta.Visible = False
            'Else
            '    If Me.LblEstatus.Text = "A" Then
            '        Me.tsbCotizacionRemision.Visible = False 'REMISION
            '        Me.tsbCotizacionFactura.Visible = False
            '        Me.tsbRemisionVenta.Visible = True
            '    Else
            '        Me.tsbCotizacionRemision.Visible = False
            '        Me.tsbCotizacionFactura.Visible = False
            '        Me.tsbRemisionVenta.Visible = False
            '    End If
        End If

        If Empresa_Sistema.FELECTRONICA_ACTIVA = True And oDocumento.TIMBRA_DOCUMENTO = True Then
            Me.tpCFDIsRelacionados.Enabled = True
            Me.tpFacturasRemisiones.Enabled = True
        Else
            Me.tpCFDIsRelacionados.Enabled = False
            Me.tpFacturasRemisiones.Enabled = False
        End If

    End Sub

    Private Sub CmbAlmacen_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboAlmacen.SelectedIndexChanged
        'limpia()
    End Sub

    Private Sub DtpFecha_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dpFecha.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.Send("{TAB}")
            Case Keys.Escape
                CboAlmacen.Focus()
        End Select
    End Sub

    Private Sub TxtReferencia_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtReferencia.KeyDown
        Select Case e.KeyCode
            Case Keys.F6
                Me.txtFolio.Text = Me.oVenta.BusquedaVisual_PorFolio
            Case Keys.Enter
                If txtLEN(Me.TxtReferencia.Text) = True Then
                    Me.oVenta = New Class_Ventas_Global(Me.TxtReferencia.Text)
                    If Me.oVenta.Existe = True Then
                        Me.Consultar(True, True)
                    Else
                        SendKeys.Send("{TAB}")
                    End If
                Else
                    SendKeys.Send("{TAB}")
                End If
        End Select
    End Sub

    Private Sub DtpFechaVencimiento_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dpVencimiento.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.Send("{TAB}")
            Case Keys.Escape
                TxtReferencia.Focus()
        End Select
    End Sub

    Private Sub txtFolioEmbarque_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFolioEmbarque.KeyDown
        Dim oEmbarques As New Class_Embarques_EmbarqueGlobal, dTabla As DataTable
        Dim sText As String

        Select Case e.KeyCode
            Case Keys.F6
                sText = oEmbarques.BusquedaVisual_Embarques_Nacional
                If txtLEN(sText) = True Then Me.txtFolioEmbarque.Text = sText

            Case Keys.Enter
                If txtLEN(Me.txtFolioEmbarque.Text) = True Then
                    oEmbarques.FOLIO_EMBARQUE = Me.txtFolioEmbarque.Text
                    If oEmbarques.Consultar() = True Then

                        dTabla = oEmbarques.ObtenerDetalleFactura() '.Rows.Count

                        Me.Grid.Rows = 1
                        For Each dRow As DataRow In dTabla.Rows
                            'Me.Grid.AddItem(dRow(0).ToString & Chr(9) & dRow(1).ToString & Chr(9) & dRow(2).ToString & Chr(9) & dRow(3).ToString & Chr(9) &
                            '                dRow(4).ToString & Chr(9) & dRow(5).ToString & Chr(9) & dRow(6).ToString & Chr(9) & Plaza.CUENTA_CONTABLE_VENTAS.ToString + Me.cboTipoMercado.SelectedValue.ToString + "00" + dRow(7).ToString & Chr(9))

                            Me.Grid.AddItem(
                            dRow("CODIGO_ARTICULO").ToString & Chr(9) &
                            dRow("TIPO_CONTROL_INVENTARIO").ToString & Chr(9) &
                            dRow("DESCRIPCION").ToString & Chr(9) &
                            dRow("CANTIDAD_BULTOS_DETALLE").ToString & Chr(9) &
                            dRow("PRECIO_UNIDAD_BULTO").ToString & Chr(9) &
                            dRow("PRECIO_UNIDAD_BULTO").ToString & Chr(9) &
                            dRow("UNIDAD").ToString & Chr(9) &
                            dRow("CANTIDAD_KILOS").ToString & Chr(9) &
                            dRow("PRECIO_KILOS").ToString & Chr(9) &
                            "0.00" & Chr(9) &
                            "0.00" & Chr(9) &
                            "0.00" & Chr(9) &
                            Plaza.CUENTA_CONTABLE_VENTAS.ToString & Chr(9) &
                            "" & Chr(9) &
                            "" & Chr(9) &
                            "" & Chr(9) &
                            "0" & Chr(9) &
                            "SIN DEFINIR" & Chr(9))
                            'Plaza.CUENTA_CONTABLE_VENTAS.ToString + Me.cboTipoMercado.SelectedValue.ToString + dRow("CUENTA_CONTABLE_BASE").ToString & Chr(9) & 'En agr esta así, pero aquí la cuenta es general

                            'sSQL = "SELECT D.CODIGO_ARTICULO,MAX(A.DESCRIPCION) DESCRIPCION,SUM(D.CANTIDAD_BULTOS_DETALLE) CANTIDAD_BULTOS_DETALLE,D.PRECIO_UNIDAD_BULTO, " &
                            '"MAX(A.UNIDAD_VENTA) UNIDAD,0 CANTIDAD_KILOS,0 PRECIO_KILOS,0 IMPUESTO_PORCENTAJE,SUM(D.IMPORTE_BULTOS_DETALLE) IMPORTE_BULTOS_DETALLE,0 IMPORTE_KILOS,MAX(A.CODIGO_CULTIVO) CODIGO_CULTIVO, " &
                            '"ISNULL(MAX(U.CUENTA_CONTABLE_BASE),'XXXX') CUENTA_CONTABLE_BASE " &
                            '"FROM VW_EMB_EMBARQUE_DETALLE_EXTENDIDO EDET " &
                            '"INNER JOIN EMB_PALETS_DETALLE D ON(EDET.FOLIO_PALET=D.FOLIO_PALET) " &
                            '"INNER JOIN CAT_ARTICULOS A ON(D.CODIGO_ARTICULO=A.CODIGO_ARTICULO) " &
                            '"LEFT JOIN CAT_CULTIVOS U ON(A.CODIGO_CULTIVO=U.CODIGO_CULTIVO) " &
                            '"WHERE EDET.FOLIO_EMBARQUE='" & Me._FOLIO_EMBARQUE & "' " &
                            '"GROUP BY D.CODIGO_ARTICULO,D.PRECIO_UNIDAD_BULTO"
                        Next

                        Me.FormateaGrid()
                        Me.Totales()
                        Me.TxtConcepto.Focus()
                    Else
                        Me.txtFolioEmbarque.Text = ""
                        Me.TxtConcepto.Focus()
                    End If
                Else
                    Me.TxtConcepto.Focus()
                End If
        End Select
    End Sub

    Private Sub TxtConcepto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtConcepto.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If Me.Grid.Rows = 1 Then
                    Me.Grid.Rows += 1
                Else
                    Me.Grid.Cell(1, 1).SetFocus()
                End If
        End Select
    End Sub

    Private Sub TxtFolio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFolio.KeyDown
        Select Case e.KeyCode
            Case Keys.F6
                Me.txtFolio.Text = Me.oVenta.BusquedaVisual_PorFolio
            Case Keys.Enter
                If Me.Consultar() = False Then
                    Me.cboTipoNegociacion.Focus()
                End If
        End Select
    End Sub

    Private Sub Grid_KeyDown(ByVal Sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Grid.KeyDown
        Me.GestionaGrid(e)
    End Sub

    Private Sub cboMoneda_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMoneda.SelectedIndexChanged
        Try
            Me.GestionaMoneda()

            Select Case Me.cboTipoNegociacion.Text
                Case "CREDITO"
                    'No se cambia la forma de pago, debe seguir 99 siempre en crédito
                Case "CONTADO"
                    If txtLEN(Me.TxtCliente.Text) = True Then
                        Me.EstableceFormaPagoCliente()
                    End If
            End Select

        Catch ex As Exception
            HandleError(Me.Name, "cboMoneda_SelectedIndexChanged", ex)
        End Try
    End Sub

    Private Sub txtNumeroCuentaPago_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNumeroCuentaPago.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.dpFecha.Focus()
        End If
    End Sub

    Private Sub txtNumerosEnterosKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPlazo.KeyPress, txtNumeroCuentaPago.KeyPress
        txtSoloNumerosEnteros(e)
        txtNoBeep(e)
    End Sub

    Private Sub CboAlmacen_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboVendedor.KeyDown, txtPlazo.KeyDown, cboTipoNegociacion.KeyDown, cboTipoMercado.KeyDown,
    CboDocumento.KeyDown, CboAlmacen.KeyDown, chkVentaPublicoGeneral.KeyDown, cboFormaPago.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.Send("{TAB}")
        End Select
    End Sub

    Private Sub CboAlmacen_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboVendedor.KeyPress, cboTipoNegociacion.KeyPress, cboTipoMercado.KeyPress,
    CboDocumento.KeyPress, CboAlmacen.KeyPress, chkVentaPublicoGeneral.KeyPress, cboTipoMercado.KeyPress, txtNumeroCuentaPago.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub cboTipoNegociacion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoNegociacion.SelectedIndexChanged
        Try
            If sTipoVenta = "NM" Then
                If Me.cboTipoNegociacion.SelectedIndex <> -1 AndAlso Me.cboTipoNegociacion.SelectedValue.ToString = "1" Then 'CREDITO
                    Me.txtPlazo.Enabled = True
                Else
                    Me.txtPlazo.Enabled = False
                    Me.txtPlazo.Text = Plaza.PLAZO_VENTA_CONTADO.ToString
                End If
            End If

            If Me.cboTipoNegociacion.SelectedIndex <> -1 Then 'Si esta con -1 entonces .SelectedValue regresa null por eso no se pregunta
                If CInt(Me.cboTipoNegociacion.SelectedValue.ToString) = 1 Then 'CREDITO
                    Me.lblTipoCredito.Visible = True
                    Me.CboTipoCredito.Visible = True
                ElseIf CInt(Me.cboTipoNegociacion.SelectedValue) = 2 Then 'CONTADO
                    Me.lblTipoCredito.Visible = False
                    Me.CboTipoCredito.Visible = False
                End If
            End If

            Me.EstableceMetodoPago()

            sTipoVentaAnterior = Me.cboTipoNegociacion.Text
        Catch ex As Exception
            HandleError(Me.Name, "cboTipoNegociacion_SelectedIndexChanged", ex)
        End Try
    End Sub

    Private Sub txtPlazo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPlazo.TextChanged
        Me.dpVencimiento.Value = Me.dpFecha.Value.AddDays(valorNumerico(Me.txtPlazo.Text))
    End Sub

    Private Sub dpFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dpFecha.ValueChanged
        Me.dpVencimiento.Value = Me.dpFecha.Value.AddDays(valorNumerico(Me.txtPlazo.Text))

        If Empresa_Sistema.TIPO_CAMBIO_POR_DIA = True And Me.cboMoneda.Text = "USD" Then
            ObtenerTipoCambioDia()
        End If
    End Sub

    Private Sub LblPoliza_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LblPoliza.LinkClicked
        Dim Child As New Frm_Contabilidad_Captura_Polizas()
        Child.FolioPolizaConsultaExterior = Me.LblPoliza.Text
        Child.ShowDialog()
        Child.Dispose()
    End Sub

    Private Sub txtTipoCambio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTipoCambio.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                Me.Totales() 'Nota dentro lo formatea

                If Me.cboMoneda.Text = "USD" Then
                    If valorNumericoD(Me.txtTipoCambio.Text) <= 0 Then
                        Me.txtTipoCambio.Text = "0"
                        e.Handled = False
                        MsgBox("Capture el tipo de cambio por favor.", vbExclamation, Me.Name)
                        Return
                    End If
                End If

                If Me.TxtCliente.Enabled = True Then
                    Me.TxtCliente.Focus()
                End If
        End Select
    End Sub

    Private Sub txtTipoCambio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTipoCambio.KeyPress
        txtSoloNumerosDecimales(e, Me.txtTipoCambio.Text)
        txtNoBeep(e)
    End Sub

    Private Sub llblAgregarSeguimiento_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llblAgregarSeguimiento.LinkClicked
        If txtLEN(Me.TxtCliente.Text) = False Then
            MsgBox("Debe de asignar un cliente", MsgBoxStyle.Exclamation, Me.Text)
            Me.TxtCliente.Focus()
            Exit Sub
        End If

        Dim Child As New Frm_CXC_Seguimientos(Me.TxtCliente.Text)
        Child.txtNegocio.Text = Usuario.Codigo_Usuario.ToString
        Child.lblNombreNegocio.Text = Usuario.Nombre_Usuario
        'Child.sCodigoCliente = Me.TxtCliente.Text
        Child.ShowDialog()
        Child.Dispose()
    End Sub

    Private Sub cboFormaPago_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFormaPago.SelectedValueChanged
        Dim oFormaPago As New Class_CFD_CatFormasPago
        Try
            If Me.Estado = enumEstados.NUEVO Then
                If Me.cboFormaPago.SelectedValue Is Nothing Then
                    Exit Sub
                End If

                oFormaPago = New Class_CFD_CatFormasPago(Me.cboFormaPago.SelectedValue.ToString)
                If Me.Estado <> enumEstados.NUEVO Then
                    Exit Sub
                End If
                If oFormaPago.REQUIERE_NUMERO_CUENTA_PAGO = 1 Then
                    Me.txtNumeroCuentaPago.Enabled = True
                    Me.txtNumeroCuentaPago.Focus()
                Else
                    Me.txtNumeroCuentaPago.Enabled = False
                    Me.txtNumeroCuentaPago.Text = ""
                End If
            End If
        Catch ex As Exception
            HandleError(Me.Name, "cboFormaPago_SelectedValueChanged", ex)
        End Try
    End Sub

    Private Sub btnAgregaAddenda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregaAddenda.Click
        If oVenta.TIMBRADO_CFDI = "1" Then
            Dim Child As New Frm_AgregaAddenda()
            Child.FolioFactura = Me.txtFolio.Text
            Child.CodigoAlmacen = Me.oVenta.CODIGO_ALMACEN.ToString
            Child.CodigoDocumento = Me.oVenta.CODIGO_DOCUMENTO.ToString
            Child.ShowDialog()
            Child.Dispose()
        Else

        End If
    End Sub

    Private Sub btnFacturaSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFacturaSiguiente.Click
        Me.NavegadorFacturas("Siguiente")
    End Sub

    Private Sub btnFacturaAnterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFacturaAnterior.Click
        Me.NavegadorFacturas("Anterior")
    End Sub

    Private Sub GridSeries_KeyDown(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridSeries.KeyDown
        Me.GestionaGridSeries(e)
    End Sub

    Private Sub ckbMostrarUtilidad_CheckedChanged(sender As Object, e As EventArgs) Handles ckbMostrarUtilidad.CheckedChanged
        Me.CalculaUtilidad()

        If Me.ckbMostrarUtilidad.Checked = True Then
            Me.gbUtilidad.Visible = True
            Me.Grid.Column(Me.igyCosto).Visible = True
            Me.Grid.Column(Me.igyUtilidadUnitaria).Visible = True
            Me.Grid.Column(Me.igyUtilidadTotal).Visible = True
            Me.Grid.Column(Me.igyUtilidadPorcentaje).Visible = True
            Me.Grid.Cell(1, Me.igyUtilidadTotal).SetFocus()
        Else
            Me.gbUtilidad.Visible = False
            Me.Grid.Column(Me.igyCosto).Visible = False
            Me.Grid.Column(Me.igyUtilidadUnitaria).Visible = False
            Me.Grid.Column(Me.igyUtilidadTotal).Visible = False
            Me.Grid.Column(Me.igyUtilidadPorcentaje).Visible = False
            Me.Grid.Cell(1, Me.igyImporte).SetFocus()
        End If
    End Sub

    Private Sub cboMoneda_KeyDown(sender As Object, e As KeyEventArgs) Handles cboMoneda.KeyDown
        If Me.cboMoneda.Text = "USD" Then
            If Empresa_Sistema.TIPO_CAMBIO_POR_DIA = True Then
                ObtenerTipoCambioDia()
            End If

            If Me.txtTipoCambio.Enabled = True Then
                Me.txtTipoCambio.Focus()
            End If

        ElseIf Me.TxtCliente.Enabled = True Then
            Me.TxtCliente.Focus()
        End If
    End Sub

    'Private Sub cboUsoCFDI_KeyDown(sender As Object, e As KeyEventArgs)
    '    txtTAB(e)
    'End Sub

    Private Sub cboMetodoPago_KeyDown(sender As Object, e As KeyEventArgs) Handles cboMetodoPago.KeyDown
        txtTAB(e)
    End Sub

    Private Sub GridCFDIsRelacionados_KeyDown(ByVal Sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridCFDIsRelacionados.KeyDown
        Me.GestionaGridCFDIsRelacionados(e)
    End Sub

    Private Sub GridFacturasVariasRemisiones_KeyDown(ByVal Sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridFacturasVariasRemisiones.KeyDown
        Me.GestionaGridFacturasVariasRemisiones(e)
    End Sub

    Private Sub btnCargarRemisiones_Click(sender As Object, e As EventArgs) Handles btnCargarRemisiones.Click
        Me.CargaRemisionesCliente()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        MsgBox("Ya no se usa este botón que era mas bien para facturar varias remisiones cancelandolas primero.")
        'Me.CargaDetalleRemisiones()
    End Sub

    Private Sub btnAceptarRemisionesSeries_Click(sender As Object, e As EventArgs) Handles btnAceptarRemisionesSeries.Click
        Me.CargaDetalleRemisionesSeries()
    End Sub

    Private Sub txtRegimenFiscal_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRegimenFiscalReceptor.KeyDown
        Const sProcedure As String = "txtRegimenFiscal_KeyDown"
        Try
            Dim sText As String = "", oRegimenFiscal As Class_CFDCatTiposRegimenesFiscales
            Select Case e.KeyCode
                Case Keys.F6
Buscar:
                    If txtLEN(Me.TxtCliente.Text) = False Or txtLEN(Me.lblCliente.Text) = False Then
                        MsgBox("Seleccione primero el cliente.", MsgBoxStyle.Exclamation, sProcedure)
                        Me.txtRegimenFiscalReceptor.Text = "" : Me.lblRegimenFiscalReceptor.Text = ""
                        Me.txtUsoCFDI.Text = "" : Me.lblUsoCFDI.Text = ""
                        Return
                    End If

                    Me.oCliente = New Class_CatClientes(Me.TxtCliente.Text)

                    If Me.oCliente.Existe = False Then
                        MsgBox("El cliente no existe, favor de verificar.", MsgBoxStyle.Exclamation, sProcedure)
                        Me.lblCliente.Text = "" : Return
                    End If

                    oRegimenFiscal = New Class_CFDCatTiposRegimenesFiscales
                    sText = oRegimenFiscal.BusquedaVisual_PorDescripcion(Me.oCliente.TIPO_PERSONA)
                    If txtLEN(sText) = True Then Me.txtRegimenFiscalReceptor.Text = sText

                Case Keys.Enter
                    If txtLEN(Me.TxtCliente.Text) = False Or txtLEN(Me.lblCliente.Text) = False Then
                        MsgBox("Seleccione primero el cliente.", MsgBoxStyle.Exclamation, sProcedure)
                        Me.txtRegimenFiscalReceptor.Text = "" : Me.lblRegimenFiscalReceptor.Text = ""
                        Me.txtUsoCFDI.Text = "" : Me.lblUsoCFDI.Text = ""
                        Return
                    End If

                    If txtLEN(Me.txtRegimenFiscalReceptor.Text) = False Then
                        Me.lblRegimenFiscalReceptor.Text = "" : GoTo Buscar : Return
                    End If

                    oRegimenFiscal = New Class_CFDCatTiposRegimenesFiscales(Me.txtRegimenFiscalReceptor.Text)

                    Me.lblRegimenFiscalReceptor.Text = oRegimenFiscal.NOMBRE_REGIMEN_FISCAL 'Lo va consultar aunque pudiera no ser válido, mas abajo lo eliminará

                    Me.oCliente = New Class_CatClientes(Me.TxtCliente.Text)

                    If Me.oCliente.Existe = False Then
                        MsgBox("El cliente no existe, favor de verificar.", MsgBoxStyle.Exclamation, sProcedure)
                        Me.lblCliente.Text = "" : Return
                    End If

                    Dim sRFCCliente As String = ""
                    If Me.chkVentaPublicoGeneral.Checked = True Then
                        sRFCCliente = "XAXX010101000"
                    Else
                        sRFCCliente = Me.oCliente.RFC
                    End If

                    If oRegimenFiscal.EXISTE = False Then
                        Me.txtRegimenFiscalReceptor.Text = "" : Me.lblRegimenFiscalReceptor.Text = "" : GoTo Buscar : Exit Sub
                    ElseIf sRFCCliente = "XAXX010101000" Or sRFCCliente = "XEXX010101000" Then
                        If Me.txtRegimenFiscalReceptor.Text <> "616" Then 'El SAT así lo exige.
                            MsgBox("El régimen fiscal para clientes con RFC genérico XAXX010101000 ó XEXX010101000 debe ser 616=Sin obligaciones fiscales.", MsgBoxStyle.Exclamation, sProcedure)
                            Me.txtRegimenFiscalReceptor.Text = "" : Me.lblRegimenFiscalReceptor.Text = ""
                        End If
                    ElseIf oRegimenFiscal.ESTATUS = "B" Then
                        MsgBox("El régimen fiscal " & Me.lblRegimenFiscalReceptor.Text & " esta dado de baja.", MsgBoxStyle.Exclamation, sProcedure)
                        Me.txtRegimenFiscalReceptor.Text = "" : Me.lblRegimenFiscalReceptor.Text = ""
                    Else
                        Select Case Me.oCliente.TIPO_PERSONA
                            Case "F" 'FISICA
                                If oRegimenFiscal.APLICA_TIPO_FISICA = False Then
                                    MsgBox("El régimen " & Me.txtRegimenFiscalReceptor.Text & "-" & Me.lblRegimenFiscalReceptor.Text & " no aplica para personas físicas.", MsgBoxStyle.Exclamation, sProcedure)
                                    Me.txtRegimenFiscalReceptor.Text = "" : Me.lblRegimenFiscalReceptor.Text = ""
                                End If
                            Case "M" 'MORAL
                                If oRegimenFiscal.APLICA_TIPO_MORAL = False Then
                                    MsgBox("El régimen " & Me.txtRegimenFiscalReceptor.Text & "-" & Me.lblRegimenFiscalReceptor.Text & " no aplica para personas morales.", MsgBoxStyle.Exclamation, sProcedure)
                                    Me.txtRegimenFiscalReceptor.Text = "" : Me.lblRegimenFiscalReceptor.Text = ""
                                End If
                        End Select
                    End If

                    If txtLEN(Me.lblRegimenFiscalReceptor.Text) = False Then GoTo Buscar : Return

                    SendKeys.Send("{TAB}")
            End Select
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Sub txtUsoCFDI_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUsoCFDI.KeyDown
        Const sProcedure As String = "txtUsoCFDI_KeyDown"
        Try
            Dim sText As String = "", oUsoCFDI As Class_CFD_CatUsosCFDI

            Select Case e.KeyCode
                Case Keys.F6, Keys.Return
                    If txtLEN(Me.TxtCliente.Text) = False Or txtLEN(Me.lblCliente.Text) = False Then
                        MsgBox("Seleccione primero el cliente.", MsgBoxStyle.Exclamation, sProcedure)
                        Me.txtRegimenFiscalReceptor.Text = "" : Me.lblRegimenFiscalReceptor.Text = ""
                        Me.txtUsoCFDI.Text = "" : Me.lblUsoCFDI.Text = ""
                        Return
                    End If

                    Me.oCliente = New Class_CatClientes(Me.TxtCliente.Text)

                    If Me.oCliente.Existe = False Then
                        MsgBox("El cliente no existe, favor de verificar.", MsgBoxStyle.Exclamation, sProcedure)
                        Me.lblCliente.Text = "" : Return
                    End If

                    If txtLEN(Me.txtRegimenFiscalReceptor.Text) = False Then
                        MsgBox("Seleccione primero el régimen fiscal del cliente.", MsgBoxStyle.Exclamation, sProcedure)
                        Me.lblRegimenFiscalReceptor.Text = "" : Return
                    End If
            End Select

            Select Case e.KeyCode 'Nota, se pregunta otra vez para no repetir el código en común.
                Case Keys.F6
Buscar:
                    oUsoCFDI = New Class_CFD_CatUsosCFDI
                    sText = oUsoCFDI.BusquedaVisual_PorDescripcion(Me.oCliente.TIPO_PERSONA)
                    If txtLEN(sText) = True Then Me.txtUsoCFDI.Text = sText

                Case Keys.Enter
                    oUsoCFDI = New Class_CFD_CatUsosCFDI(Me.txtUsoCFDI.Text)

                    Me.lblUsoCFDI.Text = oUsoCFDI.NOMBRE_USO_CFDI 'Lo va consultar aunque pudiera no ser válido, mas abajo lo eliminará

                    If oUsoCFDI.EXISTE = False Then
                        Me.txtUsoCFDI.Text = "" : Me.lblUsoCFDI.Text = ""
                    ElseIf oUsoCFDI.ESTATUS = "B" Then
                        MsgBox("El uso del CFDI " & Me.lblUsoCFDI.Text & " esta dado de baja.", MsgBoxStyle.Exclamation, sProcedure)
                        Me.txtUsoCFDI.Text = "" : Me.lblUsoCFDI.Text = ""
                    Else
                        Select Case Me.oCliente.TIPO_PERSONA
                            Case "F" 'FISICA
                                If oUsoCFDI.APLICA_TIPO_FISICA = False Then
                                    MsgBox("El uso del CFDI " & Me.txtUsoCFDI.Text & "-" & Me.lblUsoCFDI.Text & " no aplica para personas físicas.", MsgBoxStyle.Exclamation, sProcedure)
                                    Me.txtUsoCFDI.Text = "" : Me.lblUsoCFDI.Text = ""
                                End If
                            Case "M" 'MORAL
                                If oUsoCFDI.APLICA_TIPO_MORAL = False Then
                                    MsgBox("El uso del CFDI " & Me.txtUsoCFDI.Text & "-" & Me.lblUsoCFDI.Text & " no aplica para personas morales.", MsgBoxStyle.Exclamation, sProcedure)
                                    Me.txtUsoCFDI.Text = "" : Me.lblUsoCFDI.Text = ""
                                End If
                        End Select
                    End If

                    If txtLEN(Me.lblUsoCFDI.Text) = False Then GoTo Buscar : Return

                    SendKeys.Send("{TAB}")
            End Select
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Sub BtnAgregarEntidad_Click(sender As Object, e As EventArgs) Handles BtnAgregarEntidad.Click
        Me.AgregarEntidad()
    End Sub

    Private Sub CboTipoProceso_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboTipoProceso.SelectedIndexChanged
        If Me.CboTipoProceso.Text = "Ordinario" Then 'Ordinario
            Me.CboTipoComite.Enabled = True
            Me.CboTipoComite.SelectedIndex = -1
            Me.GbEntidades.Enabled = False

        Else ' 2-Precampaña / 3-Campaña
            Me.CboTipoComite.Enabled = False
            Me.CboTipoComite.SelectedIndex = -1
            Me.TxtIdContabilidad.Enabled = False
            Me.TxtIdContabilidad.Text = ""

            Me.GbEntidades.Enabled = True
            Me.CboAmbito.Enabled = True

        End If
    End Sub

    Private Sub CboTipoComite_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboTipoComite.SelectedIndexChanged
        Me.GbEntidades.Enabled = True
        Me.CboAmbito.Enabled = False

        If Me.CboTipoComite.Text = "Ejecutivo Estatal" Then
            Me.TxtIdContabilidad.Enabled = False
            Me.TxtIdContabilidad.Text = ""

        Else 'Ejecutivo nacional / Directivo estatal
            Me.TxtIdContabilidad.Enabled = True
            Me.TxtIdContabilidad.Text = ""

            If Me.CboTipoComite.Text = "Ejecutivo Nacional" Then
                Me.GbEntidades.Enabled = False
            End If

        End If
    End Sub

    Private Sub btnEliminarDatosINE_Click(sender As Object, e As EventArgs) Handles btnEliminarDatosINE.Click
        If MsgBox("¿Deseas eliminar los datos capturados del complemento INE?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "Complemento INE") = MsgBoxResult.Yes Then
            Me.InicializaControlesComplementoINE()
            Me.InicializaGridEntidadesINE()
        End If
    End Sub

    Private Sub GridEntidades_KeyDown(ByVal Sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridEntidades.KeyDown
        Me.GestionaGridEntidades(e)
    End Sub

#End Region

#Region "Eventos genéricos"
    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dpFecha.KeyPress, dpVencimiento.KeyPress, TxtCliente.KeyPress, TxtConcepto.KeyPress,
        txtFolio.KeyPress, TxtReferencia.KeyPress, txtFolioEmbarque.KeyPress, TxtConceptoCancelacion.KeyPress, txtUsoCFDI.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub txtSoloNumerosEnteros_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRegimenFiscalReceptor.KeyPress, TxtIdContabilidad.KeyPress, TxtIdContabilidadEntidad.KeyPress
        txtSoloNumerosEnteros(e)
        txtNoBeep(e)
    End Sub
#End Region

#Region "Métodos y procedimientos"
    Private Sub Inicializa()
        Const sProcedure As String = "Inicializa"
        Try
            Me.txtFolio.Text = ""
            Me.TxtReferencia.Text = ""
            Me.TxtCliente.Text = ""
            Me.txtPlazo.Text = Plaza.PLAZO_VENTA_CONTADO.ToString
            Me.TxtConcepto.Text = ""
            Me.txtFolioEmbarque.Text = ""
            Me.txtNumeroCuentaPago.Text = ""
            Me.chkVentaPublicoGeneral.Checked = False
            Me.cboMoneda.Text = "MXN"
            Me.cboFormaPago.SelectedValue = "01" '01=Efectivo
            Me.cboRegimenFiscalEmisor.SelectedValue = Empresa_Sistema.CODIGO_REGIMEN_FISCAL

            Me.lblCliente.Text = ""
            Me.LblEstatus.Text = "NUEVO"
            Me.LblPoliza.Text = ""
            Me.lblSaldo.Text = FormatImporteContable(0)
            Me.lblSaldoDolares.Text = FormatImporteContable(0)
            Me.txtTipoCambio.Text = "0"

            Me.lblSubtotal.Text = FormatImporteContable(0)
            Me.lblDescuento.Text = FormatImporteContable(0)
            Me.lblIEPS.Text = FormatImporteContable(0)
            Me.lblIEPSIncluido.Text = FormatImporteContable(0)
            Me.lblImpuesto.Text = FormatImporteContable(0)
            Me.lblTotalRetencionIVA.Text = FormatImporteContable(0)
            Me.lblTotalRetencionISR.Text = FormatImporteContable(0)
            Me.lblTotal.Text = FormatImporteContable(0)

            Me.lblSubtotal_USD.Text = FormatImporteContable(0)
            Me.lblDescuento_USD.Text = FormatImporteContable(0)
            Me.lblIEPS_USD.Text = FormatImporteContable(0)
            Me.lblIEPSIncluido_USD.Text = FormatImporteContable(0)
            Me.lblImpuesto_USD.Text = FormatImporteContable(0)
            Me.lblTotalRetencionIVA_USD.Text = FormatImporteContable(0)
            Me.lblTotalRetencionISR_USD.Text = FormatImporteContable(0)
            Me.lblTotal_USD.Text = FormatImporteContable(0)

            Me.dpFecha.Value = Date.Now
            Me.dpVencimiento.Value = Me.dpFecha.Value.AddDays(CDbl(Me.txtPlazo.Text))

            Me.InicializaGrid()
            Me.InicializaGridSeries()

            Me.oVenta = New Class_Ventas_Global()
            Me.oVenta.CODIGO_DOCUMENTO = Me.CboDocumento.SelectedValue.ToString
            Me.GeneraFolio()

            Me.DesplegarFormasPago(False)
            Me.cboTipoNegociacion.SelectedIndex = -1
            Me.cboTipoNegociacion.Text = "CREDITO"
            'Me.EstableceMetodoPago()

            Me.dtSeries = New DataTable("Series")

            'Me.bEsReferencia = False

            If dViewFormasPago.Count > 0 And Empresa_Sistema.VERSION_ESQUEMA_CFD <= "3.2" Then
                Me.cboFormaPago.SelectedValue = "NA"
            End If

            Me.txtRegimenFiscalReceptor.Text = "" : Me.lblRegimenFiscalReceptor.Text = ""
            Me.txtUsoCFDI.Text = "" : Me.lblUsoCFDI.Text = ""

            Me.lblVersionCFDI.Text = ""
            Me.txtUUID.Text = ""

            'Estos no se gestionan en el cambiar el estado, se gestionan en el consultar
            Me.tsbTimbrar.Visible = False
            Me.tsbCancelarTimbre.Visible = False
            Me.tsbRecuperarXMLPDF.Visible = False
            Me.tsbEnviarCorreo.Visible = False
            Me.tsbSubirXML.Visible = False

            Me.TabControl1.SelectedIndex = 0
            Me.bClienteEsContribuyenteIEPS = False

            Me.lblConceptoCancelacion.Visible = False
            Me.TxtConceptoCancelacion.Visible = False

            Me.cboTipoRelacionCFDI.SelectedIndex = -1
            Me.InicializaGridCFDIsRelacionados()

            Me.InicializaGridFacturasVariasRemisiones()
            Me.EsFacturaVariasRemisiones = False

            Me.lblUtilidad.Text = "0.00"
            Me.lblPorcentajeUtilidad.Text = "0.00"
            If Me.oDocumento.CODIGO_TIPO_DOCUMENTO = "FT" Then 'Factura de traslado
                'Me.cboMoneda.Text = "XXX"
                Me.cboMoneda.SelectedIndex = -1 'Por no saber que moneda quiera el usuario grabar.
                Me.txtUsoCFDI.Text = "P01"
            End If

            Me.chkTieneCCE.Checked = False
            Me.chkTieneCartaPorte.Checked = False

            Me.InicializaControlesComplementoINE()

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Sub InicializaGrid()
        Const sProcedure As String = "InicializaGrid"
        Try
            Me.Grid.DataSource = Nothing
            FG_Grid_Limpiar(Me.Grid)
            Me.Grid.Rows = 2
            Me.Grid.Cols = 56
            Me.FormateaGrid()
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Sub FormateaGrid()
        Const sProcedure As String = "FormateaGrid"
        Try
            Me.Grid.AutoRedraw = False
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.Grid.Column(Me.igyCodigo).Width = 75
            Me.Grid.Column(Me.igyTipoControlInventariable).Width = 25
            Me.Grid.Column(Me.igyDescripcion).Width = 250
            Me.Grid.Column(Me.igyCantidad).Width = 90
            Me.Grid.Column(Me.igyPrecio).Width = 100
            Me.Grid.Column(Me.igyPrecio_USD).Visible = False : Me.Grid.Column(Me.igyPrecio_USD).Width = 100
            Me.Grid.Column(Me.igyPRECIO_TOTAL).Width = 100
            Me.Grid.Column(Me.igyPRECIO_TOTAL_USD).Visible = False : Me.Grid.Column(Me.igyPRECIO_TOTAL_USD).Width = 100
            Me.Grid.Column(Me.igyUnidad).Width = 75
            Me.Grid.Column(Me.igyCantidadKilos).Visible = False
            Me.Grid.Column(Me.igyPrecioKilos).Visible = False
            Me.Grid.Column(Me.igyImpuestoPorcentaje).Width = 70
            Me.Grid.Column(Me.igyImporte).Width = 100
            Me.Grid.Column(Me.igyImporte_USD).Visible = False : Me.Grid.Column(Me.igyImporte_USD).Width = 100
            Me.Grid.Column(Me.igyImporteKilos).Visible = False
            Me.Grid.Column(Me.igyCuentaContable).Width = 100
            Me.Grid.Column(Me.igyImpuestoImporte).Visible = False
            Me.Grid.Column(Me.igyImpuestoImporte_USD).Visible = False
            Me.Grid.Column(Me.igyIdOrigen).Visible = False
            Me.Grid.Column(Me.igyEsProductoKilos).Visible = False
            Me.Grid.Column(Me.igyCodigoCentroCosto).Width = 100
            Me.Grid.Column(Me.igyNombreCentroCosto).Width = 220
            Me.Grid.Column(Me.igyIEPS_PORCENTAJE).Visible = False
            Me.Grid.Column(Me.igyIEPS_UNITARIO).Visible = False
            Me.Grid.Column(Me.igyIEPS_UNITARIO_USD).Visible = False
            Me.Grid.Column(Me.igyIEPS_IMPORTE).Visible = False
            Me.Grid.Column(Me.igyIEPS_IMPORTE_USD).Visible = False
            Me.Grid.Column(Me.igyBASE_IEPS).Visible = False
            Me.Grid.Column(Me.igyBASE_IEPS_USD).Visible = False
            Me.Grid.Column(Me.igyBASE_IVA).Visible = False
            Me.Grid.Column(Me.igyBASE_IVA_USD).Visible = False
            Me.Grid.Column(Me.igyCosto).Width = 100
            Me.Grid.Column(Me.igyUtilidadUnitaria).Width = 100
            Me.Grid.Column(Me.igyUtilidadTotal).Width = 100
            Me.Grid.Column(Me.igyUtilidadPorcentaje).Width = 100
            Me.Grid.Column(Me.iGyID_SIS_CAT_IMPUESTOS).Visible = False
            Me.Grid.Column(Me.iGyGRADO_TOXICIDAD).Visible = False
            Me.Grid.Column(Me.iGyDESCUENTO_UNITARIO).Visible = False
            Me.Grid.Column(Me.iGyDESCUENTO_UNITARIO_USD).Visible = False
            Me.Grid.Column(Me.iGyDESCUENTO_IMPORTE).Width = 100
            Me.Grid.Column(Me.iGyDESCUENTO_IMPORTE_USD).Width = 100
            Me.Grid.Column(Me.iGyPRECIO_CON_DESCUENTO).Visible = False
            Me.Grid.Column(Me.iGyPRECIO_CON_DESCUENTO_USD).Visible = False
            'Me.Grid.Column(Me.iGyIdSisCatImpuestosFlete).Visible = False
            'Me.Grid.Column(Me.iGyFletePorcentaje).Visible = False
            'Me.Grid.Column(Me.iGyFleteImporte).Visible = False<
            'Me.Grid.Column(Me.iGyFleteImporte_USD).Visible = False
            Me.Grid.Column(Me.iGyRETENCION_IVA_TIENE).Visible = False
            Me.Grid.Column(Me.iGyRETENCION_IVA_PORCENTAJE).Visible = False
            Me.Grid.Column(Me.iGyRETENCION_IVA_BASE).Visible = False
            Me.Grid.Column(Me.iGyRETENCION_IVA_BASE_USD).Visible = False
            Me.Grid.Column(Me.iGyRETENCION_IVA_IMPORTE).Visible = False
            Me.Grid.Column(Me.iGyRETENCION_IVA_IMPORTE_USD).Visible = False
            Me.Grid.Column(Me.iGyRETENCION_ISR_TIENE).Visible = False
            Me.Grid.Column(Me.iGyRETENCION_ISR_PORCENTAJE).Visible = False
            Me.Grid.Column(Me.iGyRETENCION_ISR_BASE).Visible = False
            Me.Grid.Column(Me.iGyRETENCION_ISR_BASE_USD).Visible = False
            Me.Grid.Column(Me.iGyRETENCION_ISR_IMPORTE).Visible = False
            Me.Grid.Column(Me.iGyRETENCION_ISR_IMPORTE_USD).Visible = False
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.Grid.Cell(0, Me.igyCodigo).Text = "Código"
            Me.Grid.Cell(0, Me.igyTipoControlInventariable).Text = "Inv"
            Me.Grid.Cell(0, Me.igyDescripcion).Text = "Descripción"
            Me.Grid.Cell(0, Me.igyCantidad).Text = "Cantidad"
            Me.Grid.Cell(0, Me.igyPrecio).Text = "Precio"
            Me.Grid.Cell(0, Me.igyPrecio_USD).Text = "Precio_USD"
            Me.Grid.Cell(0, Me.igyPRECIO_TOTAL).Text = "Precio total"
            Me.Grid.Cell(0, Me.igyPRECIO_TOTAL_USD).Text = "Precio total_USD"
            Me.Grid.Cell(0, Me.igyUnidad).Text = "Unidad"
            Me.Grid.Cell(0, Me.igyCantidadKilos).Text = "Cantidad x Kg"
            Me.Grid.Cell(0, Me.igyPrecioKilos).Text = "Precio x Kg"
            Me.Grid.Cell(0, Me.igyImpuestoPorcentaje).Text = "IVA %"
            Me.Grid.Cell(0, Me.igyImporte).Text = "Importe"
            Me.Grid.Cell(0, Me.igyImporte_USD).Text = "Importe_USD"
            Me.Grid.Cell(0, Me.igyImporteKilos).Text = "Importe x Kg"
            Me.Grid.Cell(0, Me.igyCuentaContable).Text = "Cuenta Contable"
            Me.Grid.Cell(0, Me.igyImpuestoImporte).Text = "IVA"
            Me.Grid.Cell(0, Me.igyImpuestoImporte_USD).Text = "IVA_USD"
            Me.Grid.Cell(0, Me.igyIdOrigen).Text = "Id Articulo"
            Me.Grid.Cell(0, Me.igyEsProductoKilos).Text = "Es producto kilos"
            Me.Grid.Cell(0, Me.igyCodigoCentroCosto).Text = "Ccos"
            Me.Grid.Cell(0, Me.igyNombreCentroCosto).Text = "C.Costo"
            Me.Grid.Cell(0, Me.igyIEPS_PORCENTAJE).Text = "IEPS_%"
            Me.Grid.Cell(0, Me.igyIEPS_UNITARIO).Text = "IEPS_UNIT"
            Me.Grid.Cell(0, Me.igyIEPS_UNITARIO_USD).Text = "IEPS_UNIT_USD"
            Me.Grid.Cell(0, Me.igyIEPS_IMPORTE).Text = "IEPS_IMP"
            Me.Grid.Cell(0, Me.igyIEPS_IMPORTE_USD).Text = "IEPS_IMP_USD"
            Me.Grid.Cell(0, Me.igyBASE_IEPS).Text = "BASE_IEPS"
            Me.Grid.Cell(0, Me.igyBASE_IEPS_USD).Text = "BASE_IEPS_USD"
            Me.Grid.Cell(0, Me.igyBASE_IVA).Text = "BASE_IVA"
            Me.Grid.Cell(0, Me.igyBASE_IVA_USD).Text = "BASE_IVA_USD"
            Me.Grid.Cell(0, Me.igyCosto).Text = "Costo Unit"
            Me.Grid.Cell(0, Me.igyUtilidadUnitaria).Text = "Utilidad unitaria"
            Me.Grid.Cell(0, Me.igyUtilidadTotal).Text = "Utilidad total"
            Me.Grid.Cell(0, Me.igyUtilidadPorcentaje).Text = "% utilidad"
            Me.Grid.Cell(0, Me.iGyID_SIS_CAT_IMPUESTOS).Text = "IVA?"
            Me.Grid.Cell(0, Me.iGyGRADO_TOXICIDAD).Text = "GradoTox"
            Me.Grid.Cell(0, Me.iGyDESCUENTO_UNITARIO).Text = "DesUnit"
            Me.Grid.Cell(0, Me.iGyDESCUENTO_UNITARIO_USD).Text = "DesUnit_USD"
            Me.Grid.Cell(0, Me.iGyDESCUENTO_IMPORTE).Text = "Descuento"
            Me.Grid.Cell(0, Me.iGyDESCUENTO_IMPORTE_USD).Text = "Descuento_USD"
            Me.Grid.Cell(0, Me.iGyPRECIO_CON_DESCUENTO).Text = "PrecioCDes"
            Me.Grid.Cell(0, Me.iGyPRECIO_CON_DESCUENTO_USD).Text = "PrecioCDes_USD"
            'Me.Grid.Cell(0, Me.iGyIdSisCatImpuestosFlete).Text = "ID ImpuestoFlete"
            'Me.Grid.Cell(0, Me.iGyFletePorcentaje).Text = "Flete porcentaje"
            'Me.Grid.Cell(0, Me.iGyFleteImporte).Text = "Flete importe"
            'Me.Grid.Cell(0, Me.iGyFleteImporte_USD).Text = "Flete importe_USD"
            Me.Grid.Cell(0, Me.iGyRETENCION_IVA_TIENE).Text = "TieneIVARet"
            Me.Grid.Cell(0, Me.iGyRETENCION_IVA_PORCENTAJE).Text = "IVARet%"
            Me.Grid.Cell(0, Me.iGyRETENCION_IVA_BASE).Text = "IVARetBase"
            Me.Grid.Cell(0, Me.iGyRETENCION_IVA_BASE_USD).Text = "IVARetBaseUSD"
            Me.Grid.Cell(0, Me.iGyRETENCION_IVA_IMPORTE).Text = "IVARetImp"
            Me.Grid.Cell(0, Me.iGyRETENCION_IVA_IMPORTE_USD).Text = "IVARetImpUSD"
            Me.Grid.Cell(0, Me.iGyRETENCION_ISR_TIENE).Text = "TieneISRRet"
            Me.Grid.Cell(0, Me.iGyRETENCION_ISR_PORCENTAJE).Text = "ISRRet%"
            Me.Grid.Cell(0, Me.iGyRETENCION_ISR_BASE).Text = "ISRRetBase"
            Me.Grid.Cell(0, Me.iGyRETENCION_ISR_BASE_USD).Text = "ISRRetBaseUSD"
            Me.Grid.Cell(0, Me.iGyRETENCION_ISR_IMPORTE).Text = "ISRRetImp"
            Me.Grid.Cell(0, Me.iGyRETENCION_ISR_IMPORTE_USD).Text = "ISRRetImpUSD"

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.Grid.Column(Me.igyNombreCentroCosto).Alignment = FlexCell.AlignmentEnum.LeftCenter

            Me.Grid.Column(Me.igyCantidad).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.igyCantidad).DecimalLength = Empresa_Sistema.DECIMALES_CANTIDAD
            Me.Grid.Column(Me.igyCantidad).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.igyCantidadKilos).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.igyCantidadKilos).DecimalLength = Empresa_Sistema.DECIMALES_CANTIDAD
            Me.Grid.Column(Me.igyCantidadKilos).Alignment = FlexCell.AlignmentEnum.RightCenter

            'Me.Grid.Column(Me.igyPrecio).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_PRECIO)
            Me.Grid.Column(Me.igyPrecio).FormatString = "$ ###,###,##0." & StrDup(Me.iDecimalesPrecio, "0")
            Me.Grid.Column(Me.igyPrecio).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.igyPrecio).DecimalLength = Me.iDecimalesPrecio 'Empresa_Sistema.DECIMALES_PRECIO
            Me.Grid.Column(Me.igyPrecio).Alignment = FlexCell.AlignmentEnum.RightCenter

            'Me.Grid.Column(Me.igyPrecio_USD).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_PRECIO)
            Me.Grid.Column(Me.igyPrecio_USD).FormatString = "$ ###,###,##0." & StrDup(Me.iDecimalesPrecio, "0")
            Me.Grid.Column(Me.igyPrecio_USD).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.igyPrecio_USD).DecimalLength = Me.iDecimalesPrecio 'Empresa_Sistema.DECIMALES_PRECIO
            Me.Grid.Column(Me.igyPrecio_USD).Alignment = FlexCell.AlignmentEnum.RightCenter

            'Me.Grid.Column(Me.igyPRECIO_TOTAL).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_PRECIO)
            Me.Grid.Column(Me.igyPRECIO_TOTAL).FormatString = "$ ###,###,##0." & StrDup(Me.iDecimalesPrecio, "0")
            Me.Grid.Column(Me.igyPRECIO_TOTAL).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.igyPRECIO_TOTAL).DecimalLength = Me.iDecimalesPrecio 'Empresa_Sistema.DECIMALES_PRECIO
            Me.Grid.Column(Me.igyPRECIO_TOTAL).Alignment = FlexCell.AlignmentEnum.RightCenter

            'Me.Grid.Column(Me.igyPRECIO_TOTAL_USD).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_PRECIO)
            Me.Grid.Column(Me.igyPRECIO_TOTAL_USD).FormatString = "$ ###,###,##0." & StrDup(Me.iDecimalesPrecio, "0")
            Me.Grid.Column(Me.igyPRECIO_TOTAL_USD).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.igyPRECIO_TOTAL_USD).DecimalLength = Me.iDecimalesPrecio 'Empresa_Sistema.DECIMALES_PRECIO
            Me.Grid.Column(Me.igyPRECIO_TOTAL_USD).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.igyPrecioKilos).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_PRECIO)
            Me.Grid.Column(Me.igyPrecioKilos).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.igyPrecioKilos).DecimalLength = Empresa_Sistema.DECIMALES_PRECIO
            Me.Grid.Column(Me.igyPrecioKilos).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.igyImpuestoPorcentaje).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.igyImpuestoPorcentaje).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
            Me.Grid.Column(Me.igyImpuestoPorcentaje).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.igyImporte).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
            Me.Grid.Column(Me.igyImporte).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.igyImporte).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
            Me.Grid.Column(Me.igyImporte).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.igyImporte_USD).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
            Me.Grid.Column(Me.igyImporte_USD).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.igyImporte_USD).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
            Me.Grid.Column(Me.igyImporte_USD).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.igyImporteKilos).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
            Me.Grid.Column(Me.igyImporteKilos).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.igyImporteKilos).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
            Me.Grid.Column(Me.igyImporteKilos).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.igyCuentaContable).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.igyImpuestoImporte).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.igyImpuestoImporte).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
            Me.Grid.Column(Me.igyImpuestoImporte).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.igyImpuestoImporte_USD).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.igyImpuestoImporte_USD).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
            Me.Grid.Column(Me.igyImpuestoImporte_USD).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.igyIdOrigen).Mask = FlexCell.MaskEnum.Numeric

            Me.Grid.Column(Me.igyCosto).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
            Me.Grid.Column(Me.igyCosto).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.igyCosto).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
            Me.Grid.Column(Me.igyCosto).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.igyUtilidadUnitaria).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
            Me.Grid.Column(Me.igyUtilidadUnitaria).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.igyUtilidadUnitaria).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
            Me.Grid.Column(Me.igyUtilidadUnitaria).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.igyUtilidadTotal).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
            Me.Grid.Column(Me.igyUtilidadTotal).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.igyUtilidadTotal).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
            Me.Grid.Column(Me.igyUtilidadTotal).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.igyUtilidadPorcentaje).FormatString = "###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
            Me.Grid.Column(Me.igyUtilidadPorcentaje).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.igyUtilidadPorcentaje).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
            Me.Grid.Column(Me.igyUtilidadPorcentaje).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.iGyDESCUENTO_UNITARIO).FormatString = "$ ###,###,##0." & StrDup(Me.iDecimalesPrecio, "0")
            Me.Grid.Column(Me.iGyDESCUENTO_UNITARIO).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.iGyDESCUENTO_UNITARIO).DecimalLength = Me.iDecimalesPrecio 'Empresa_Sistema.DECIMALES_PRECIO
            Me.Grid.Column(Me.iGyDESCUENTO_UNITARIO).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.iGyDESCUENTO_IMPORTE).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
            Me.Grid.Column(Me.iGyDESCUENTO_IMPORTE).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.iGyDESCUENTO_IMPORTE).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
            Me.Grid.Column(Me.iGyDESCUENTO_IMPORTE).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.iGyPRECIO_CON_DESCUENTO).FormatString = "$ ###,###,##0." & StrDup(Me.iDecimalesPrecio, "0")
            Me.Grid.Column(Me.iGyPRECIO_CON_DESCUENTO).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.iGyPRECIO_CON_DESCUENTO).DecimalLength = Me.iDecimalesPrecio 'Empresa_Sistema.DECIMALES_PRECIO
            Me.Grid.Column(Me.iGyPRECIO_CON_DESCUENTO).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.iGyPRECIO_CON_DESCUENTO_USD).FormatString = "$ ###,###,##0." & StrDup(Me.iDecimalesPrecio, "0")
            Me.Grid.Column(Me.iGyPRECIO_CON_DESCUENTO_USD).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.iGyPRECIO_CON_DESCUENTO_USD).DecimalLength = Me.iDecimalesPrecio 'Empresa_Sistema.DECIMALES_PRECIO
            Me.Grid.Column(Me.iGyPRECIO_CON_DESCUENTO_USD).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.iGyPRECIO_CON_DESCUENTO_USD).FormatString = "$ ###,###,##0." & StrDup(Me.iDecimalesPrecio, "0")
            Me.Grid.Column(Me.iGyPRECIO_CON_DESCUENTO_USD).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.iGyPRECIO_CON_DESCUENTO_USD).DecimalLength = Me.iDecimalesPrecio 'Empresa_Sistema.DECIMALES_PRECIO
            Me.Grid.Column(Me.iGyPRECIO_CON_DESCUENTO_USD).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.iGyRETENCION_IVA_PORCENTAJE).FormatString = "0." & StrDup(6, "0")
            Me.Grid.Column(Me.iGyRETENCION_IVA_PORCENTAJE).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.iGyRETENCION_IVA_PORCENTAJE).DecimalLength = 6
            Me.Grid.Column(Me.iGyRETENCION_IVA_PORCENTAJE).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.iGyRETENCION_ISR_PORCENTAJE).FormatString = "0." & StrDup(6, "0")
            Me.Grid.Column(Me.iGyRETENCION_ISR_PORCENTAJE).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.iGyRETENCION_ISR_PORCENTAJE).DecimalLength = 6
            Me.Grid.Column(Me.iGyRETENCION_ISR_PORCENTAJE).Alignment = FlexCell.AlignmentEnum.RightCenter

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.Grid.Column(Me.igyCodigo).Locked = False
            Me.Grid.Column(Me.igyCantidad).Locked = False
            Me.Grid.Column(Me.igyCantidadKilos).Locked = False
            Me.Grid.Column(Me.igyCodigoCentroCosto).Locked = False
            Me.Grid.Column(Me.igyPrecio).Locked = False
            Me.Grid.Column(Me.igyDescripcion).Locked = True
            Me.Grid.Column(Me.igyTipoControlInventariable).Locked = True
            Me.Grid.Column(Me.igyImporte).Locked = True
            Me.Grid.Column(Me.igyImporte_USD).Locked = True
            Me.Grid.Column(Me.igyImpuestoPorcentaje).Locked = True
            Me.Grid.Column(Me.igyUnidad).Locked = True
            Me.Grid.Column(Me.igyCosto).Locked = True
            Me.Grid.Column(Me.igyUtilidadUnitaria).Locked = True
            Me.Grid.Column(Me.igyUtilidadTotal).Locked = True
            Me.Grid.Column(Me.igyUtilidadPorcentaje).Locked = True
            Me.Grid.Column(Me.igyPRECIO_TOTAL).Locked = True
            Me.Grid.Column(Me.igyPRECIO_TOTAL_USD).Locked = True

            'MsgBox("aqui falta ver si esta ok porque eso deberia definirse al cambiar el tipo de moneda, aunque si consultan habra que planear bien esto")
            If Usuario.PERMISO_CAMBIAR_PRECIO_VENTA = True Then
                Me.Grid.Column(Me.igyPrecio).Locked = False
                Me.Grid.Column(Me.igyPrecio_USD).Locked = False
            Else
                Me.Grid.Column(Me.igyPrecio).Locked = True
                Me.Grid.Column(Me.igyPrecio_USD).Locked = True
            End If

            Me.Grid.Column(Me.igyNombreCentroCosto).Locked = True
            Me.Grid.Column(Me.iGyID_SIS_CAT_IMPUESTOS).Locked = True
            Me.Grid.Column(Me.iGyGRADO_TOXICIDAD).Locked = True
            Me.Grid.Column(Me.iGyDESCUENTO_UNITARIO).Locked = True
            Me.Grid.Column(Me.iGyDESCUENTO_UNITARIO_USD).Locked = True
            Me.Grid.Column(Me.iGyPRECIO_CON_DESCUENTO).Locked = True
            Me.Grid.Column(Me.iGyPRECIO_CON_DESCUENTO_USD).Locked = True
            'Me.Grid.Column(Me.iGyIdSisCatImpuestosFlete).Locked = True
            'Me.Grid.Column(Me.iGyFletePorcentaje).Locked = True
            'Me.Grid.Column(Me.iGyFleteImporte).Locked = True
            'Me.Grid.Column(Me.iGyFleteImporte_USD).Locked = True
            Me.Grid.Column(Me.iGyRETENCION_IVA_TIENE).Locked = True
            Me.Grid.Column(Me.iGyRETENCION_IVA_PORCENTAJE).Locked = True
            Me.Grid.Column(Me.iGyRETENCION_IVA_BASE).Locked = True
            Me.Grid.Column(Me.iGyRETENCION_IVA_IMPORTE).Locked = True
            Me.Grid.Column(Me.iGyRETENCION_ISR_TIENE).Locked = True
            Me.Grid.Column(Me.iGyRETENCION_ISR_PORCENTAJE).Locked = True
            Me.Grid.Column(Me.iGyRETENCION_ISR_BASE).Locked = True
            Me.Grid.Column(Me.iGyRETENCION_ISR_IMPORTE).Locked = True

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.oDocumento.AFECTA_CXC = True Then
                Me.Grid.Column(Me.igyCuentaContable).Visible = False 'True
                Me.Grid.Column(Me.igyNombreCentroCosto).Visible = False  'True
            Else
                Me.Grid.Column(Me.igyCuentaContable).Visible = False
                Me.Grid.Column(Me.igyNombreCentroCosto).Visible = False
            End If

            If Me._EsPorEmbarqueExtranjero = True Then
                Me.Grid.Column(Me.igyPrecio).Locked = True 'Al ser un embarque el precio en mxn se bloquea porque el precio para timbrar será en usd.
                Me.Grid.Column(Me.igyPrecio_USD).Visible = True
                Me.Grid.Column(Me.igyImporte_USD).Visible = True
            End If

            If Me.ckbMostrarUtilidad.Checked = True Then
                Me.Grid.Column(Me.igyCosto).Visible = True
                Me.Grid.Column(Me.igyUtilidadUnitaria).Visible = True
                Me.Grid.Column(Me.igyUtilidadTotal).Visible = True
                Me.Grid.Column(Me.igyUtilidadPorcentaje).Visible = True
            Else
                Me.Grid.Column(Me.igyCosto).Visible = False
                Me.Grid.Column(Me.igyUtilidadUnitaria).Visible = False
                Me.Grid.Column(Me.igyUtilidadTotal).Visible = False
                Me.Grid.Column(Me.igyUtilidadPorcentaje).Visible = False
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
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
            Case "APLICADO"
                Me.Cambia_Estado(enumEstados.APLICADO)
            Case "SUSTITUIDO"
                Me.Cambia_Estado(enumEstados.SUSTITUIDO)
            Case "CANCELADO"
                Me.Cambia_Estado(enumEstados.CANCELADO)
            Case "SUSTITUYENDO"
                Me.Cambia_Estado(enumEstados.SUSTITUYENDO)
        End Select
    End Sub

    Private Sub Cambia_Estado(ByVal pEstado As enumEstados)
        Const sProcedure As String = "Cambia_Estado"
        Try
            Me.Estado = pEstado

            Me.cboTipoRelacionCFDI.Enabled = False
            Me.GridCFDIsRelacionados.Locked = True
            Me.tsbFacturaACartaPorte.Visible = False

            Me.chkTieneCCE.Enabled = False
            Me.chkTieneCCE.Visible = False
            Me.cboIncoterm.Enabled = False

            Me.chkTieneCartaPorte.Visible = False
            Me.btnCartaPorte.Visible = False
            Me.btnCartaPorte.Enabled = False

            Select Case Me.Estado
                Case enumEstados.NUEVO
                    Me.tsbNuevo.Enabled = True
                    Me.tsbCancelar.Enabled = False
                    Me.tsbImprimir.Enabled = False
                    Me.tsbGrabar.Enabled = True
                    Me.tsbEnviarCorreo.Enabled = False

                    Me.frmDatos.Enabled = True
                    Me.Grid.Locked = False

                    Me.GridSeries.Locked = True
                    If Me.oDocumento.AFECTA_INVENTARIOS = True Then
                        Me.GridSeries.Locked = False
                        Me.btnSeries.Visible = True
                    End If

                    Me.tsslEstado.Text = "Estado: Agregando nuevo movimiento"
                    Me.tsslElaboro.Visible = False : Me.tsslElaboro.Text = ""
                    Me.tsslCancelo.Visible = False : Me.tsslCancelo.Text = ""

                    Me.txtPlazo.Enabled = True
                    Me.dpVencimiento.Enabled = True

                    Me.btnAgregaAddenda.Visible = False

                    Me.tsbCotizacionFactura.Visible = False
                    Me.tsbCotizacionRemision.Visible = False
                    Me.tsbRemisionVenta.Visible = False

                    Me.TxtReferencia.Enabled = True
                    Me.TxtCliente.Enabled = True
                    Me.TxtConcepto.Enabled = True
                    Me.txtNumeroCuentaPago.Enabled = True
                    Me.chkVentaPublicoGeneral.Enabled = True
                    Me.cboMoneda.Enabled = True
                    Me.dpFecha.Enabled = True
                    'Me.cboFormaPago.Enabled = True
                    Me.cboVendedor.Enabled = True
                    Me.cboTipoMercado.Enabled = True
                    Me.cboTipoNegociacion.Enabled = True
                    Me.txtFolioEmbarque.Enabled = True
                    Me.llblAgregarSeguimiento.Enabled = True

                    Me.CboDocumento.Enabled = True
                    Me.txtFolio.Enabled = True
                    Me.CboAlmacen.Enabled = True

                    Me.lblTipoCredito.Enabled = True
                    Me.CboTipoCredito.Enabled = True

                    Me.cboMoneda.Enabled = True
                    Me.txtRegimenFiscalReceptor.Enabled = True
                    Me.txtUsoCFDI.Enabled = True
                    'Me.cboMetodoPago.Enabled = True
                    Me.cboRegimenFiscalEmisor.Enabled = True

                    Me.cboTipoRelacionCFDI.Enabled = True
                    Me.GridCFDIsRelacionados.Locked = False

                    Me.lblConceptoCancelacion.Visible = False
                    Me.TxtConceptoCancelacion.Visible = False

                    If Empresa_Sistema.CODIGO_VENDEDOR_POR_USUARIO = True AndAlso txtLEN(Usuario.CODIGO_VENDEDOR) = True Then
                        Me.cboVendedor.SelectedValue = Usuario.CODIGO_VENDEDOR
                    End If

                    Me.CboTipoProceso.Enabled = True
                    Me.CboTipoComite.Enabled = False
                    Me.TxtIdContabilidad.Enabled = False
                    Me.GbEntidades.Enabled = False
                    Me.GridEntidades.Locked = False

                    Me.EsFacturaVariasRemisiones = False
                    Me.btnAceptar.Enabled = True
                    Me.btnAceptarRemisionesSeries.Enabled = True
                    Me.btnCargarRemisiones.Enabled = True
                    If Me.oDocumento.CODIGO_TIPO_DOCUMENTO = "FT" Then 'Factura de traslado
                        Me.txtUsoCFDI.Text = "P01"
                        Me.txtUsoCFDI.Enabled = False

                        If Me.chkTieneCartaPorte.Checked = True Then
                            Me.cboMoneda.Text = "XXX"
                            Me.cboMoneda.Enabled = False
                        Else
                            Me.cboMoneda.SelectedIndex = -1
                            Me.cboMoneda.Enabled = True
                        End If

                        Me.cboFormaPago.SelectedIndex = -1 'No se permitirá seleccionar ninguna forma de pago
                        Me.cboFormaPago.Enabled = False
                        Me.cboMetodoPago.SelectedIndex = -1 'No se permitirá seleccionar ningún método de pago
                        Me.cboTipoNegociacion.SelectedValue = 1 '1=CREDITO
                        Me.cboTipoNegociacion.Enabled = False
                        Me.chkTieneCartaPorte.Visible = True
                        Me.chkTieneCartaPorte.Enabled = True
                    End If

                    If Me.oDocumento.TIMBRA_DOCUMENTO = True Then
                        Me.chkTieneCCE.Visible = True
                        Me.chkTieneCCE.Enabled = True
                        Me.cboIncoterm.Enabled = True
                    End If

                    If Me.Visible = True Then
                        Me.txtFolio.Focus()
                    End If

                Case enumEstados.GRABADO
                    Me.tsbNuevo.Enabled = True
                    Me.tsbGrabar.Enabled = True
                    Me.tsbCancelar.Enabled = True
                    Me.tsbImprimir.Enabled = True
                    Me.tsbEnviarCorreo.Enabled = False

                    Me.frmDatos.Enabled = True
                    Me.Grid.Locked = False
                    Me.GridSeries.Locked = True
                    Me.GridFacturasVariasRemisiones.Locked = True

                    Me.btnAgregaAddenda.Visible = False

                    Me.tsbCotizacionFactura.Visible = True
                    Me.tsbCotizacionRemision.Visible = True
                    Me.tsbRemisionVenta.Visible = False
                    Me.btnSeries.Visible = False

                    Me.tsslEstado.Text = "Estado: Consultando movimiento"
                    Me.tsslElaboro.Visible = True : Me.tsslElaboro.Text = "Elaboró: " + Me.oVenta.NOMBRE_USUARIO.ToUpper + " el " + Format(Me.dpFecha.Value, "dd/MMM/yy").ToUpper
                    Me.tsslCancelo.Visible = False : Me.tsslCancelo.Text = ""

                    Me.lblConceptoCancelacion.Visible = False
                    Me.TxtConceptoCancelacion.Visible = False

                    Me.CboTipoProceso.Enabled = False
                    Me.CboTipoComite.Enabled = False
                    Me.TxtIdContabilidad.Enabled = False
                    Me.GbEntidades.Enabled = False
                    Me.GridEntidades.Locked = True

                    Me.btnAceptar.Enabled = False
                    Me.btnAceptarRemisionesSeries.Enabled = False
                    Me.btnCargarRemisiones.Enabled = False

                    Me.TxtConcepto.Focus()

                Case enumEstados.SUSTITUIDO
                    Me.tsbNuevo.Enabled = True
                    Me.tsbGrabar.Enabled = False
                    Me.tsbCancelar.Enabled = True
                    Me.tsbImprimir.Enabled = True
                    Me.tsbEnviarCorreo.Enabled = False

                    Me.frmDatos.Enabled = True
                    Me.Grid.Locked = True
                    Me.GridSeries.Locked = True
                    Me.GridFacturasVariasRemisiones.Locked = True

                    Me.btnAgregaAddenda.Visible = False

                    Me.tsbCotizacionFactura.Visible = False
                    Me.tsbCotizacionRemision.Visible = False
                    Me.tsbRemisionVenta.Visible = False
                    Me.btnSeries.Visible = False

                    Me.tsslEstado.Text = "Estado: Consultando movimiento"
                    Me.tsslElaboro.Visible = True : Me.tsslElaboro.Text = "Elaboró: " + Me.oVenta.NOMBRE_USUARIO.ToUpper + " el " + Format(Me.dpFecha.Value, "dd/MMM/yy").ToUpper
                    Me.tsslCancelo.Visible = False : Me.tsslCancelo.Text = ""

                    Me.lblConceptoCancelacion.Visible = False
                    Me.TxtConceptoCancelacion.Visible = False

                    Me.CboTipoProceso.Enabled = False
                    Me.CboTipoComite.Enabled = False
                    Me.TxtIdContabilidad.Enabled = False
                    Me.GbEntidades.Enabled = False
                    Me.GridEntidades.Locked = True

                    Me.btnAceptar.Enabled = False
                    Me.btnAceptarRemisionesSeries.Enabled = False
                    Me.btnCargarRemisiones.Enabled = False

                    Me.tsbImprimir.Select()

                Case enumEstados.APLICADO
                    Me.tsbNuevo.Enabled = True
                    Me.tsbGrabar.Enabled = False
                    Me.tsbCancelar.Enabled = True
                    Me.tsbImprimir.Enabled = True
                    Me.tsbEnviarCorreo.Enabled = True

                    'Me.frmDatos.Enabled = False
                    Me.Grid.Locked = True
                    Me.GridSeries.Locked = True
                    Me.GridFacturasVariasRemisiones.Locked = True

                    If Me.oDocumento.AFECTA_CONTABILIDAD = True Then
                        Me.tsbCotizacionFactura.Visible = False
                        Me.tsbCotizacionRemision.Visible = False
                        Me.tsbRemisionVenta.Visible = False

                        Me.txtFolio.Enabled = False
                        Me.TxtReferencia.Enabled = False
                        Me.TxtCliente.Enabled = False
                        Me.txtPlazo.Enabled = False
                        Me.TxtConcepto.Enabled = False
                        Me.txtFolioEmbarque.Enabled = False
                        Me.txtNumeroCuentaPago.Enabled = False
                        Me.chkVentaPublicoGeneral.Enabled = False
                        Me.cboMoneda.Enabled = False
                        Me.dpFecha.Enabled = False
                        Me.dpVencimiento.Enabled = False
                        'Me.cboFormaPago.Enabled = False
                        Me.cboVendedor.Enabled = False
                        Me.CboAlmacen.Enabled = False
                        Me.CboDocumento.Enabled = False
                        Me.cboTipoMercado.Enabled = False
                        Me.cboTipoNegociacion.Enabled = False
                        Me.txtFolioEmbarque.Enabled = False
                        Me.llblAgregarSeguimiento.Enabled = False
                        Me.lblTipoCredito.Enabled = False
                        Me.CboTipoCredito.Enabled = False
                        Me.cboMoneda.Enabled = False
                        Me.txtRegimenFiscalReceptor.Enabled = False
                        Me.txtUsoCFDI.Enabled = False
                        'Me.cboMetodoPago.Enabled = False
                        Me.cboRegimenFiscalEmisor.Enabled = False
                    ElseIf Me.oDocumento.AFECTA_INVENTARIOS = True Then
                        Me.tsbCotizacionFactura.Visible = False
                        Me.tsbCotizacionRemision.Visible = False
                        Me.tsbRemisionVenta.Visible = True
                    Else
                        Me.tsbCotizacionFactura.Visible = False
                        Me.tsbCotizacionRemision.Visible = False
                        Me.tsbRemisionVenta.Visible = False
                    End If
                    If Me.oDocumento.AFECTA_CONTABILIDAD = True Then
                        Me.tsbFacturaACartaPorte.Visible = True
                    End If

                    Me.chkTieneCartaPorte.Enabled = False
                    If Me.oDocumento.CODIGO_TIPO_DOCUMENTO = "FT" Then
                        Me.chkTieneCartaPorte.Visible = True

                        If Me.oVenta.TIENE_COMPLEMENTO_CARTA_PORTE = True Or Me.oVenta.TIMBRADO_CFDI = "0" Then 'Si no esta timbrada va permitir grabar carta porte.
                            Me.btnCartaPorte.Visible = True
                            Me.btnCartaPorte.Enabled = True
                        End If
                    End If

                    If Me.chkTieneCCE.Checked = True Then
                        Me.chkTieneCCE.Visible = True
                        Me.cboIncoterm.Visible = True : Me.lblDisplayIncoterm.Visible = True
                    End If

                    'If Me.oVenta.ADDENDA = "1" Then
                    '    Me.btnAgregaAddenda.Visible = False
                    'Else
                    If Me.TxtCliente.Text = Empresa_Sistema.CODIGO_CLIENTE_SORIANA Then
                        Me.btnAgregaAddenda.Visible = True
                    Else
                        Me.btnAgregaAddenda.Visible = False
                    End If
                    'End If

                    Me.btnSeries.Visible = False

                    Me.tsslEstado.Text = "Estado: Consultando movimiento"
                    Me.tsslElaboro.Visible = True : Me.tsslElaboro.Text = "Elaboró: " + Me.oVenta.NOMBRE_USUARIO.ToUpper + " el " + Format(Me.dpFecha.Value, "dd/MMM/yy").ToUpper
                    Me.tsslCancelo.Visible = False : Me.tsslCancelo.Text = ""

                    Me.lblConceptoCancelacion.Visible = False
                    Me.TxtConceptoCancelacion.Visible = False

                    Me.CboTipoProceso.Enabled = False
                    Me.CboTipoComite.Enabled = False
                    Me.TxtIdContabilidad.Enabled = False
                    Me.GbEntidades.Enabled = False
                    Me.GridEntidades.Locked = True

                    Me.btnAceptar.Enabled = False
                    Me.btnAceptarRemisionesSeries.Enabled = False
                    Me.btnCargarRemisiones.Enabled = False

                    Me.tsbImprimir.Select()

                Case enumEstados.SUSTITUYENDO
                    Me.tsbNuevo.Enabled = True
                    Me.tsbGrabar.Enabled = True
                    Me.tsbCancelar.Enabled = False
                    Me.tsbImprimir.Enabled = False
                    Me.tsbEnviarCorreo.Enabled = False

                    Me.txtFolio.Enabled = False
                    Me.CboAlmacen.Enabled = False
                    Me.CboDocumento.Enabled = False

                    Me.btnAgregaAddenda.Visible = False
                    Me.frmDatos.Enabled = True
                    'Me.Grid.Locked = True 'De momento no se permiten editar cantidades, o precios
                    'Me.GridSeries.Locked = True 'De momento no permitimos manejo de series en sustituciones.
                    Me.GridSeries.Locked = False  'Ya permitimos manejo de series en sustituciones.
                    Me.GridFacturasVariasRemisiones.Locked = True

                    Me.tsbTimbrar.Visible = False
                    Me.tsbCotizacionFactura.Visible = False
                    Me.tsbCotizacionRemision.Visible = False
                    Me.tsbRemisionVenta.Visible = False
                    Me.btnSeries.Visible = False

                    Me.txtPlazo.Enabled = False
                    Me.dpVencimiento.Enabled = False

                    Me.tsslEstado.Text = "Estado: Sustituyendo movimiento"
                    Me.tsslElaboro.Visible = False : Me.tsslElaboro.Text = ""
                    Me.tsslCancelo.Visible = False : Me.tsslCancelo.Text = ""

                    Me.lblConceptoCancelacion.Visible = False
                    Me.TxtConceptoCancelacion.Visible = False

                    Me.btnAceptar.Enabled = False
                    Me.btnAceptarRemisionesSeries.Enabled = False
                    Me.btnCargarRemisiones.Enabled = False

                    Me.tsbImprimir.Select()

                    If sTipoVenta = "SR" Then 'Remision a venta 
                        Me.cboTipoRelacionCFDI.Enabled = True
                        Me.GridCFDIsRelacionados.Locked = False
                    End If

                Case enumEstados.CANCELADO
                    Me.tsbNuevo.Enabled = True
                    Me.tsbGrabar.Enabled = False
                    Me.tsbCancelar.Enabled = False
                    Me.tsbImprimir.Enabled = True
                    Me.tsbEnviarCorreo.Enabled = True

                    'Me.frmDatos.Enabled = False
                    Me.Grid.Locked = True
                    Me.GridSeries.Locked = True
                    Me.GridFacturasVariasRemisiones.Locked = True

                    Me.btnAgregaAddenda.Visible = False

                    Me.tsbCotizacionFactura.Visible = False
                    Me.tsbCotizacionRemision.Visible = False
                    Me.tsbRemisionVenta.Visible = False
                    Me.btnSeries.Visible = False

                    Me.tsslEstado.Text = "Estado: Consultando movimiento"
                    Me.tsslElaboro.Visible = True : Me.tsslElaboro.Text = "Elaboró: " + Me.oVenta.NOMBRE_USUARIO.ToUpper + " el " + Format(Me.dpFecha.Value, "dd/MMM/yy").ToUpper
                    Me.tsslCancelo.Visible = True : Me.tsslCancelo.Text = "Canceló: " + Me.oVenta.NOMBRE_USUARIO_CANCELO.ToUpper + " el " + Format(Me.oVenta.FECHA_CANCELACION, "dd/MMM/yy").ToUpper

                    Me.tsbImprimir.Select()

                    Me.txtFolio.Enabled = False
                    Me.TxtReferencia.Enabled = False
                    Me.TxtCliente.Enabled = False
                    Me.txtPlazo.Enabled = False
                    Me.TxtConcepto.Enabled = False
                    Me.txtFolioEmbarque.Enabled = False
                    Me.txtNumeroCuentaPago.Enabled = False
                    Me.chkVentaPublicoGeneral.Enabled = False
                    Me.cboMoneda.Enabled = False
                    Me.dpFecha.Enabled = False
                    Me.dpVencimiento.Enabled = False
                    Me.cboFormaPago.Enabled = False
                    Me.cboVendedor.Enabled = False
                    Me.CboAlmacen.Enabled = False
                    Me.CboDocumento.Enabled = False
                    Me.cboTipoMercado.Enabled = False
                    Me.cboTipoNegociacion.Enabled = False
                    Me.txtFolioEmbarque.Enabled = False
                    Me.llblAgregarSeguimiento.Enabled = False
                    Me.cboMoneda.Enabled = False
                    Me.txtRegimenFiscalReceptor.Enabled = False
                    Me.txtUsoCFDI.Enabled = False
                    Me.cboRegimenFiscalEmisor.Enabled = False

                    Me.lblConceptoCancelacion.Visible = True
                    Me.TxtConceptoCancelacion.Visible = True
                    Me.TxtConceptoCancelacion.ReadOnly = True

                    Me.CboTipoProceso.Enabled = False
                    Me.CboTipoComite.Enabled = False
                    Me.TxtIdContabilidad.Enabled = False
                    Me.GbEntidades.Enabled = False
                    Me.GridEntidades.Locked = True

                    Me.btnAceptar.Enabled = False
                    Me.btnAceptarRemisionesSeries.Enabled = False
                    Me.btnCargarRemisiones.Enabled = False
            End Select

            'Me.tsbSellarFacturaElectronica.Visible = False

            Application.DoEvents()

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Function Grabar() As Boolean
        Const sProcedure As String = "Grabar"
        Dim bResultado As Boolean = False
        Dim i As Integer, sMetodoPago As String = "", sUsoCFDI As String = "", sListaSeries As String = "", sCodigoTipoRelacionCFDI As String = "", sListaCFDIsRelacionados As String = "", sFormaPago As String = ""
        Dim sRFCReceptor As String = "", sNombreReceptor As String = "", sDomicilioFiscalReceptor As String = ""

        Try
            If Me._EsPorEmbarqueExtranjero = True Then
                'Revisar todo lo relacionado porque se quito funcionalidad de facturas de emabrques en varias partes.
                MsgBox("No esta de momento activada el control de embarques.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            If Me._EsPorEmbarqueExtranjero = False AndAlso MsgBox("Deseas grabar la " & Me.CboDocumento.Text & " con el folio : " & Me.txtFolio.Text & " ?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, sProcedure) = MsgBoxResult.No Then
                Return False
            End If

            If Me._EsPorEmbarqueExtranjero = False AndAlso oDocumento.ACCESIBLE_USUARIO = False Then
                MsgBox("Este documento no se puede grabar directamente.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            If oDocumento.AFECTA_INVENTARIOS = True Then
                If Me._EsPorEmbarqueExtranjero = False AndAlso Usuario.ValidaPermisoUsuarioDocumentoConAfectacionInventarios(Me.CboDocumento.SelectedValue.ToString, Me.CboAlmacen.SelectedValue.ToString) = False Then
                    MsgBox("El usuario " & Usuario.Nombre_Usuario & " no tiene permiso para realizar el movimiento.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If

                If Me._EsPorEmbarqueExtranjero = False Then
                    If Usuario.ValidaPermisoUsuarioDocumentoConAfectacionInventarios(Me.CboDocumento.SelectedValue.ToString, Me.CboAlmacen.SelectedValue.ToString) = False Then
                        MsgBox("El usuario " & Usuario.Nombre_Usuario & " no tiene permiso para realizar el movimiento.", MsgBoxStyle.Exclamation, sProcedure)
                        Return False
                    End If
                End If
            Else
                If Me._EsPorEmbarqueExtranjero = False AndAlso Usuario.ValidaPermisoUsuarioDocumentoSinAfectacionInventarios(Me.CboDocumento.SelectedValue.ToString) = False Then
                    MsgBox("El usuario " & Usuario.Nombre_Usuario & " no tiene permiso para realizar el movimiento.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If

                If Me._EsPorEmbarqueExtranjero = False Then
                    If Usuario.ValidaPermisoUsuarioDocumentoSinAfectacionInventarios(Me.CboDocumento.SelectedValue.ToString) = False Then
                        MsgBox("El usuario " & Usuario.Nombre_Usuario & " no tiene permiso para realizar el movimiento.", MsgBoxStyle.Exclamation, sProcedure)
                        Return False
                    End If
                End If
            End If

            Me.dtSeries.AcceptChanges()

            Me.Totales()

            If Me.AsignaCentrosCostos() = False Then
                Return False
            End If

            If Me.ValidarVenta() = False Then
                Return False
            End If

            'If Me.sTipoVenta <> "SR" And Me.oDocumento.AFECTA_CXC = True Then 'SR=SUSTITUCION DE REMISION
            '    If Me._EsPorEmbarqueExtranjero = False AndAlso Me.ValidarReglasCreditoplazo(True) = False Then
            '        Return False
            '    End If
            'End If

            If Me._EsPorEmbarqueExtranjero = True Or Me.sTipoVenta = "SR" Or valorNumericoD(Me.lblTotal.Text) = 0 Then 'SR=SUSTITUCION DE REMISION
                'Continúa si es embarque extranjero porque no afecta saldos, o si es sust de remisión porque la venta ya se realizó de todas formas.
            ElseIf Me.oDocumento.AFECTA_CXC = False Then 'Si el documento no afecta como pudiera ser una cotización
                Me.ValidarReglasCreditoplazo(True) 'Sólo entra en modo de advertencia pero dejará continuar grabar.
            ElseIf Me.oDocumento.AFECTA_CXC = True Then 'Si el documento si afecta
                If Me.ValidarReglasCreditoplazo(True) = False Then 'Si se validan las reglas de crédito.
                    Return False
                End If
            End If

            'If Me.oDocumento.AFECTA_CONTABILIDAD = True Then
            '    If Me.chkVentaPublicoGeneral.Checked = False Then
            '        '02Mar17, ya no se validaran datos del cliente desde aqui sino dentro de la fac electronica.
            '        'If Me.ValidarDatosCliente() = True Then
            '        '    If Me.oVenta.EsClienteDeContado(Me.oCliente.CUENTA_CONTABLE, Me.oCliente.CODIGO_ZONA.ToString) = True Then
            '        '        'If MsgBox("El sistema le generará una cuenta contable, ya no le podrá vender como público general, desea continuar?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "Grabar") = MsgBoxResult.No Then
            '        '        '    Return False
            '        '        'End If

            '        '        'If Me.oCliente.EstablecerCuentaContable = False Then
            '        '        '    MsgBox("No se pudo establecer la nueva cuenta contable de venta al cliente, avíse al departamento de sistemas.", MsgBoxStyle.Exclamation, sProcedure)
            '        '        '    Return False
            '        '        'End If
            '        '    End If
            '        'Else
            '        '    Return False
            '        'End If
            '    Else
            '        If Me.oVenta.EsClienteDeContado(Me.oCliente.CUENTA_CONTABLE, Me.oCliente.CODIGO_ZONA.ToString) = False Then
            '            MsgBox("El cliente no tiene asígnada una cuenta contable de contado, no se le puede vender como público general.", MsgBoxStyle.Exclamation, sProcedure)
            '            Return False
            '        End If
            '    End If

            'End If

            Me.oCliente = New Class_CatClientes(Me.TxtCliente.Text)

            If Me.oCliente.Existe = False Then
                MsgBox("El cliente no existe.", vbExclamation, sProcedure)
                Return False
            End If

            If Empresa_Sistema.VERSION_ESQUEMA_CFD <= "3.2" Then
                sMetodoPago = ""
                sUsoCFDI = ""
            Else
                If Me.chkVentaPublicoGeneral.Checked = True Then
                    sRFCReceptor = "XAXX010101000"
                    sNombreReceptor = "PUBLICO GENERAL" 'Ojo no es lo mismo que "PUBLICO EN GENERAL" que tiene la palabra "EN" y SAT lo valida diferente.
                Else
                    sRFCReceptor = Me.oCliente.RFC
                    sNombreReceptor = Me.oCliente.NOMBRE_CLIENTE
                End If

                'El SAT dice : Si el valor del atributo Rfc del receptor es "XAXX010101000" o "XEXX010101000", este atributo debe ser igual al valor del atributo LugarExpedicion.
                If sRFCReceptor = Empresa_Sistema.RFC_VENTA_PUBLICO_GENERAL Or sRFCReceptor = Empresa_Sistema.RFC_EXTRANJERO Then
                    sDomicilioFiscalReceptor = Plaza.CODIGO_POSTAL
                Else
                    sDomicilioFiscalReceptor = Me.oCliente.CODIGO_POSTAL
                End If
                If Me.oDocumento.CODIGO_TIPO_DOCUMENTO <> "FT" Then
                    sMetodoPago = Me.cboMetodoPago.SelectedValue.ToString
                    sFormaPago = Me.cboFormaPago.SelectedValue.ToString
                End If

                sUsoCFDI = Me.txtUsoCFDI.Text  'Me.cboUsoCFDI.SelectedValue.ToString

            End If

            If Me.cboTipoRelacionCFDI.SelectedIndex <> -1 Then
                If Me.HayCFDIsRelacionadosRepetidos() = True Then
                    Return False
                End If

                sCodigoTipoRelacionCFDI = Me.cboTipoRelacionCFDI.SelectedValue.ToString

                For i = 1 To Me.GridCFDIsRelacionados.Rows - 1
                    If txtLEN(Me.GridCFDIsRelacionados.Cell(i, Me.iGyGRFolio).Text) = True Then
                        sListaCFDIsRelacionados = sListaCFDIsRelacionados & Me.GridCFDIsRelacionados.Cell(i, iGyGRFolio).Text & ","
                    End If
                Next

                If txtLEN(sListaCFDIsRelacionados) = True Then
                    sListaCFDIsRelacionados = sListaCFDIsRelacionados.Substring(0, sListaCFDIsRelacionados.Length - 1) 'Para quitarle la última coma que sale sobrando.
                Else
                    MsgBox("Seleccionó un tipo de relación CFDI, pero no indicó cuales son los CFDIs relacionados.", vbExclamation, sProcedure)
                    Return False
                End If
            End If

            If Me.chkTieneCCE.Checked = True And Me.chkTieneCartaPorte.Checked = True Then
                MsgBox("De momento no esta permitido grabar facturas con ambos complementos CCE y CCP porque el CCP exige sea moneda en XXX y CCE necesita el tipo de cambio y precios en usd.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            If Me.chkTieneCartaPorte.Checked = True Then
                If Me.ValidaComplementoCartaPorte = False Then
                    Return False
                End If
            End If

            If Me.chkTieneCCE.Checked = True Then
                If Me.ValidaComplementoComercioExterior = False Then
                    Return False
                End If
            End If

            'If Me.EsFacturaVariasRemisiones = True Then 'Primero se deben cancelar las remisiones que se quieren facturar
            'MsgBox("FALTA se quitó de momento esta sección que cancela remisiones revisar luego")
            'Dim FoliosRemisiones As String = ""

            'For i = 1 To Me.GridFacturasVariasRemisiones.Rows - 1
            '    FoliosRemisiones = FoliosRemisiones & Me.GridFacturasVariasRemisiones.Cell(i, Me.iGyFolio).Text & "|"
            'Next

            'FoliosRemisiones = FoliosRemisiones.Substring(0, FoliosRemisiones.Length - 1) 'Para quitarle el último pipe que sale sobrando

            'oVenta.CODIGO_PLAZA = Plaza.CODIGO_PLAZA
            'oVenta.CODIGO_USUARIO_CANCELO = Usuario.Codigo_Usuario
            'oVenta.FECHA_CANCELACION = Date.Now
            'oVenta.CONCEPTO_CANCELACION = "CANCELACION POR FACTURACION DE VARIAS REMISIONES"

            'If oVenta.CancelaMultiplesRemisiones(FoliosRemisiones) = False Then
            '    MsgBox("Error al cancelar las remisiones que se quieren facturar.", MsgBoxStyle.Exclamation, Me.Name)
            '    Return False
            'End If
            'End If

            With Me.oVenta
                .FOLIO_VENTA = Me.txtFolio.Text.ToUpper
                .FECHA = Me.dpFecha.Value
                .FECHA_VENCIMIENTO = Me.dpVencimiento.Value
                .CODIGO_CLIENTE = Me.TxtCliente.Text.ToUpper
                .CODIGO_DOCUMENTO = Me.CboDocumento.SelectedValue.ToString
                .CODIGO_VENDEDOR = CInt(Me.cboVendedor.SelectedValue.ToString)
                .SUBTOTAL = valorNumerico(Me.lblSubtotal.Text)
                .DESCUENTO = valorNumerico(Me.lblDescuento.Text)
                .IMPUESTO = valorNumerico(Me.lblImpuesto.Text)
                .IEPS_TOTAL_DESGLOSADO = valorNumerico(Me.lblIEPS.Text)
                .IEPS_TOTAL_YA_INCLUIDO = valorNumerico(Me.lblIEPSIncluido.Text)
                .RETENCION_IVA = valorNumericoD(Me.lblTotalRetencionIVA.Text)
                .RETENCION_ISR = valorNumericoD(Me.lblTotalRetencionISR.Text)
                .TOTAL = valorNumerico(Me.lblTotal.Text)
                .TOTAL_SUSTITUCION = 0 'Ahora se graba dentro del stored MP_VENTA_AFECTA_SUSTITUCION_REMISION
                'If Me.sTipoVenta = "NM" Then
                '    .TOTAL_SUSTITUCION = 0
                'Else
                '    .TOTAL_SUSTITUCION = dTotalSustitucion
                'End If

                'Asi estaba cuando existian embarques
                'If Me._EsPorEmbarqueExtranjero = True Then
                '    .DESCUENTO = valorNumerico(Me.lblTotal.Text) 'Se invierten los valores para forzar a un total 0 usd porque es en consignacion
                '    .TOTAL = 0 'Se invierten los valores para forzar a un total 0 usd porque es en consignacion
                '    .SUBTOTAL_USD = valorNumerico(Me.lblTotal_USD.Text)
                '    .DESCUENTO_USD = valorNumerico(Me.lblTotal_USD.Text)
                'Else 'En facturas normales
                '    .DESCUENTO = valorNumerico(Me.lblDescuento.Text)
                '    .TOTAL = valorNumerico(Me.lblTotal.Text)
                '    .SUBTOTAL_USD = 0 'No aplica en facturas normales aunque estén en usd
                '    .DESCUENTO_USD = 0 'No aplica en facturas normales aunque estén en usd
                'End If

                If Me.cboMoneda.Text = "USD" Then
                    .TIPO_DE_CAMBIO = valorNumerico(Me.txtTipoCambio.Text)
                    .SUBTOTAL_USD = valorNumerico(Me.lblSubtotal_USD.Text)
                    .DESCUENTO_USD = valorNumerico(Me.lblDescuento_USD.Text)
                    .IMPUESTO_USD = valorNumerico(Me.lblImpuesto_USD.Text)
                    .IEPS_TOTAL_DESGLOSADO_USD = valorNumerico(Me.lblIEPS_USD.Text)
                    .IEPS_TOTAL_YA_INCLUIDO_USD = valorNumerico(Me.lblIEPSIncluido_USD.Text)
                    .RETENCION_IVA_USD = valorNumericoD(Me.lblTotalRetencionIVA_USD.Text)
                    .RETENCION_ISR_USD = valorNumericoD(Me.lblTotalRetencionISR_USD.Text)
                    .TOTAL_DOLARES = valorNumerico(Me.lblTotal_USD.Text)
                    .TOTAL_SUSTITUCION_USD = 0
                Else
                    .TIPO_DE_CAMBIO = 0
                    .SUBTOTAL_USD = 0
                    .DESCUENTO_USD = 0
                    .IMPUESTO_USD = 0
                    .IEPS_TOTAL_DESGLOSADO_USD = 0
                    .IEPS_TOTAL_YA_INCLUIDO_USD = 0
                    .RETENCION_IVA_USD = 0
                    .RETENCION_ISR_USD = 0
                    .TOTAL_DOLARES = 0
                    '.TOTAL_SUSTITUCION = 0, ya esta más arriba
                End If

                .COSTO = 0
                .CODIGO_USUARIO_GRABO = Usuario.Codigo_Usuario
                .FOLIO_REFERENCIA = Me.TxtReferencia.Text.ToUpper
                .CODIGO_ALMACEN = Me.CboAlmacen.SelectedValue.ToString
                .CONCEPTO = Me.TxtConcepto.Text.ToUpper
                .CODIGO_PLAZA = Plaza.CODIGO_PLAZA
                .CODIGO_TIPO_NEGOCIACION = CInt(Me.cboTipoNegociacion.SelectedValue.ToString)
                .FOLIO_POLIZA = Me.LblPoliza.Text.ToUpper
                .IMPUESTO_PORCENTAJE = Plaza.Impuesto_Porcentaje
                'If Empresa_Sistema.FELECTRONICA_ACTIVA = True And oDocumento.AFECTA_CONTABILIDAD = True And oDocumento.AFECTA_INVENTARIOS = True Then
                'If Empresa_Sistema.FELECTRONICA_ACTIVA = True And oDocumento.AFECTA_CONTABILIDAD = True And oDocumento.AFECTA_INVENTARIOS = True And oDocumento.TIMBRA_DOCUMENTO = True Then
                'If Empresa_Sistema.FELECTRONICA_ACTIVA = True And ((oDocumento.AFECTA_CONTABILIDAD = True And oDocumento.AFECTA_INVENTARIOS = True) Or Me._EsPorEmbarqueExtranjero = True) Then
                If Empresa_Sistema.FELECTRONICA_ACTIVA = True And (oDocumento.TIMBRA_DOCUMENTO = True Or Me._EsPorEmbarqueExtranjero = True) Then
                    .ES_FACTURA_ELECTRONICA = "1"
                Else
                    .ES_FACTURA_ELECTRONICA = "0"
                End If
                .CODIGO_TIPO_MERCADO = Me.cboTipoMercado.SelectedValue.ToString
                .FOLIO_REFERENCIA_USUARIO = ""
                .TIPO_VENTA = sTipoVenta

                .ES_VENTA_PUBLICO_GENERAL = Convert.ToInt32(Me.chkVentaPublicoGeneral.Checked).ToString
                .FOLIO_EMBARQUE = Me.txtFolioEmbarque.Text.ToUpper

                .CODIGO_METODO_PAGO = sFormaPago 'Me.cboFormaPago.SelectedValue.ToString
                .NUMERO_CUENTA_PAGO = Me.txtNumeroCuentaPago.Text
                .CODIGO_METODO_PAGO_EVENTO = sMetodoPago
                .CODIGO_USO_CFDI = sUsoCFDI.ToUpper
                .CODIGO_MONEDA_SAT = Me.cboMoneda.Text

                If .CODIGO_TIPO_NEGOCIACION = 1 Then ' CREDITO
                    .CODIGO_TIPO_CREDITO = Me.CboTipoCredito.SelectedValue.ToString
                ElseIf .CODIGO_TIPO_NEGOCIACION = 2 Then ' CONTADO
                    .CODIGO_TIPO_CREDITO = "NA"
                End If
                .TIENE_IEPS_DESGLOSADO = Me.bClienteEsContribuyenteIEPS
                .CODIGO_TIPO_RELACION_CFDI = sCodigoTipoRelacionCFDI
                .LISTA_CFDIS_RELACIONADOS = sListaCFDIsRelacionados
                .CODIGO_REGIMEN_FISCAL_EMISOR = Me.cboRegimenFiscalEmisor.SelectedValue.ToString
                .TIENE_COMPLEMENTO_CARTA_PORTE = Me.chkTieneCartaPorte.Checked
                .CODIGO_REGIMEN_FISCAL_RECEPTOR = Me.txtRegimenFiscalReceptor.Text
                .NOMBRE_RECEPTOR = sNombreReceptor
                .DOMICILIO_FISCAL_RECEPTOR = sDomicilioFiscalReceptor

                If Me.Estado = enumEstados.NUEVO Or Me.Estado = enumEstados.SUSTITUYENDO Then
                    If .Grabar("INSERTAR") = False Then
                        MsgBox("Error al tratar de insertar el movimiento de ventas.", MsgBoxStyle.Exclamation, sProcedure)
                        Return False
                    End If
                    Me.txtFolio.Text = Me.oVenta.FOLIO_VENTA 'Se asegura del cambio del folio en pantalla
                Else
                    If .Grabar("ACTUALIZAR") = False Then
                        MsgBox("Error al tratar de actualizar el movimiento de ventas.", MsgBoxStyle.Exclamation, sProcedure)
                        Return False
                    End If
                End If
                Me.Regenerar_dtSeries()  'Nota recuerde que dtSeries ya no esta ligado con datasource al grid asi que para usarlo antes hay que regenerarlo o bien trabajar directo con el gridSeries y no con dtSeries

                'se graba el detalle
                For i = 1 To Me.Grid.Rows - 1
                    If txtLEN(Me.Grid.Cell(i, Me.igyCodigo).Text) = True Then
                        .NuevoRenglon()
                        .oVentasDetalle.FOLIO_VENTA = Me.oVenta.FOLIO_VENTA.ToUpper
                        .oVentasDetalle.CODIGO_ARTICULO = Me.Grid.Cell(i, Me.igyCodigo).Text.ToUpper
                        .oVentasDetalle.CANTIDAD = valorNumerico(Me.Grid.Cell(i, Me.igyCantidad).Text)
                        .oVentasDetalle.UNIDAD_VENTA = Me.Grid.Cell(i, Me.igyUnidad).Text.ToUpper
                        .oVentasDetalle.IMPUESTO_PORCENTAJE = CDbl(valorNumerico(Me.Grid.Cell(i, Me.igyImpuestoPorcentaje).Text))
                        .oVentasDetalle.IMPUESTO_IMPORTE = valorNumerico(Me.Grid.Cell(i, Me.igyImpuestoImporte).Text)
                        .oVentasDetalle.IMPORTE = valorNumerico(Me.Grid.Cell(i, Me.igyImporte).Text)

                        If Me.sTipoVenta = "NM" Then
                            .oVentasDetalle.ID_ORIGEN = 0
                        Else
                            .oVentasDetalle.ID_ORIGEN = CInt(0 & Me.Grid.Cell(i, Me.igyIdOrigen).Text)
                        End If

                        .oVentasDetalle.CUENTA_CONTABLE = Me.Grid.Cell(i, Me.igyCuentaContable).Text
                        .oVentasDetalle.COMENTARIO = Me.Grid.Cell(i, Me.igyDescripcion).Text.ToUpper

                        .oVentasDetalle.CANTIDAD_KILOS = valorNumerico(Me.Grid.Cell(i, Me.igyCantidadKilos).Text)
                        .oVentasDetalle.PRECIO_KILOS = valorNumerico(Me.Grid.Cell(i, Me.igyPrecioKilos).Text)
                        .oVentasDetalle.IMPORTE_KILOS = valorNumerico(Me.Grid.Cell(i, Me.igyImporteKilos).Text)

                        Dim oArticulo As New Class_CatArticulos(Me.Grid.Cell(i, Me.igyCodigo).Text)
                        .oVentasDetalle.ES_PRODUCTO_KILOS = oArticulo.ES_PRODUCTO_KILOS.ToString

                        .oVentasDetalle.CODIGO_CENTRO_COSTO = Me.Grid.Cell(i, Me.igyCodigoCentroCosto).Text

                        If Me.dtSeries.Rows.Count > 0 Then
                            For Each dRow In Me.dtSeries.Select("POSICION='" & i.ToString & "'") 'Este campo es string si no se le ponen las comillas no funciona bien.
                                sListaSeries = sListaSeries & dRow("POSICION").ToString & "," & dRow("CODIGO_ARTICULO").ToString & "," & dRow("ID_INVENTARIO_LOTES_COSTOS").ToString & "," & dRow("NUMERO_SERIE").ToString & "," &
                                                             dRow("ID_ORIGEN").ToString & "," & dRow("FOLIO_REMISION").ToString & "|"
                            Next
                            If txtLEN(sListaSeries) = True Then
                                sListaSeries = sListaSeries.Substring(0, sListaSeries.Length - 1) 'Para quitarle el último pipe que sale sobrando.
                            End If
                        End If

                        .oVentasDetalle.LISTA_SERIES = sListaSeries

                        'nota ahora que de momento no hay embarques, estos se llenan mas abajo de diferente modo, ver notas
                        '.oVentasDetalle.PRECIO_USD = valorNumerico(Me.Grid.Cell(i, Me.igyPrecio_USD).Text 'nota ahora que de momento no hay embarques este dato no sale directo de la columna precio
                        '.oVentasDetalle.IMPORTE_USD = valorNumerico(Me.Grid.Cell(i, Me.igyImporte_USD).Text)

                        .oVentasDetalle.IEPS_PORCENTAJE = valorNumerico(Me.Grid.Cell(i, Me.igyIEPS_PORCENTAJE).Text)
                        .oVentasDetalle.IEPS_UNITARIO = valorNumerico(Me.Grid.Cell(i, Me.igyIEPS_UNITARIO).Text)
                        .oVentasDetalle.IEPS_IMPORTE = valorNumerico(Me.Grid.Cell(i, Me.igyIEPS_IMPORTE).Text)
                        .oVentasDetalle.BASE_IEPS = valorNumerico(Me.Grid.Cell(i, Me.igyBASE_IEPS).Text)
                        .oVentasDetalle.BASE_IVA = valorNumerico(Me.Grid.Cell(i, Me.igyBASE_IVA).Text)
                        .oVentasDetalle.PRECIO_TOTAL = valorNumerico(Me.Grid.Cell(i, Me.igyPRECIO_TOTAL).Text)
                        .oVentasDetalle.GRADO_TOXICIDAD = CInt(Me.Grid.Cell(i, Me.iGyGRADO_TOXICIDAD).Text)
                        .oVentasDetalle.ID_SIS_CAT_IMPUESTOS = Me.Grid.Cell(i, Me.iGyID_SIS_CAT_IMPUESTOS).Text

                        .oVentasDetalle.PRECIO_SIN_DESCUENTO = valorNumericoD(Me.Grid.Cell(i, Me.igyPrecio).Text) 'El precio tecleado no se graba en el campo precio en cambio se graba en precio_sin_descuento porque para reportear se ocupa el con_descuentos
                        .oVentasDetalle.PRECIO = valorNumericoD(Me.Grid.Cell(i, Me.iGyPRECIO_CON_DESCUENTO).Text) 'Este es el precio que se usa para reportear y debe venir con descuentos
                        '.oVentasDetalle.PRECIO = valorNumerico(Me.Grid.Cell(i, Me.igyPrecio).Text)
                        .oVentasDetalle.DESCUENTO_UNITARIO = valorNumericoD(Me.Grid.Cell(i, Me.iGyDESCUENTO_UNITARIO).Text)
                        .oVentasDetalle.DESCUENTO_IMPORTE = valorNumericoD(Me.Grid.Cell(i, Me.iGyDESCUENTO_IMPORTE).Text)

                        'If txtLEN(Me.Grid.Cell(i, Me.iGyIdSisCatImpuestosFlete).Text) = False Then
                        '   .oVentasDetalle.ID_SIS_CAT_IMPUESTOS_FLETE = "0" 'Sin flete
                        'Else
                        '  .oVentasDetalle.ID_SIS_CAT_IMPUESTOS_FLETE = Me.Grid.Cell(i, Me.iGyIdSisCatImpuestosFlete).Text
                        'End If
                        '.oVentasDetalle.RETENCION_IVA_IMPORTE = valorNumericoD(Me.Grid.Cell(i, Me.iGyFleteImporte).Text)
                        .oVentasDetalle.RETENCION_IVA_PORCENTAJE = valorNumericoD(Me.Grid.Cell(i, Me.iGyRETENCION_IVA_PORCENTAJE).Text)
                        .oVentasDetalle.RETENCION_IVA_BASE = valorNumericoD(Me.Grid.Cell(i, Me.iGyRETENCION_IVA_BASE).Text)
                        .oVentasDetalle.RETENCION_IVA_IMPORTE = valorNumericoD(Me.Grid.Cell(i, Me.iGyRETENCION_IVA_IMPORTE).Text)
                        .oVentasDetalle.RETENCION_ISR_PORCENTAJE = valorNumericoD(Me.Grid.Cell(i, Me.iGyRETENCION_ISR_PORCENTAJE).Text)
                        .oVentasDetalle.RETENCION_ISR_BASE = valorNumericoD(Me.Grid.Cell(i, Me.iGyRETENCION_ISR_BASE).Text)
                        .oVentasDetalle.RETENCION_ISR_IMPORTE = valorNumericoD(Me.Grid.Cell(i, Me.iGyRETENCION_ISR_IMPORTE).Text)

                        If Me.Grid.Cell(i, Me.igyTipoControlInventariable).Text = "NIV" Or Me.oDocumento.CODIGO_TIPO_DOCUMENTO = "CTZ" Then 'En cotizaciones se grabara el costo para poder calcular la utilidad en las consultas y al pasar de cotizacion a remision
                            .oVentasDetalle.COSTO = valorNumericoD(Me.Grid.Cell(i, Me.igyCosto).Text)
                        End If

                        ''''CAMPOS EN USD
                        .oVentasDetalle.IMPUESTO_IMPORTE_USD = valorNumerico(Me.Grid.Cell(i, Me.igyImpuestoImporte_USD).Text)
                        .oVentasDetalle.IMPORTE_USD = valorNumerico(Me.Grid.Cell(i, Me.igyImporte_USD).Text)
                        .oVentasDetalle.IEPS_UNITARIO_USD = valorNumerico(Me.Grid.Cell(i, Me.igyIEPS_UNITARIO_USD).Text)
                        .oVentasDetalle.IEPS_IMPORTE_USD = valorNumerico(Me.Grid.Cell(i, Me.igyIEPS_IMPORTE_USD).Text)
                        .oVentasDetalle.BASE_IEPS_USD = valorNumerico(Me.Grid.Cell(i, Me.igyBASE_IEPS_USD).Text)
                        .oVentasDetalle.BASE_IVA_USD = valorNumerico(Me.Grid.Cell(i, Me.igyBASE_IVA_USD).Text)
                        .oVentasDetalle.PRECIO_TOTAL_USD = valorNumerico(Me.Grid.Cell(i, Me.igyPRECIO_TOTAL_USD).Text)
                        .oVentasDetalle.PRECIO_SIN_DESCUENTO_USD = valorNumericoD(Me.Grid.Cell(i, Me.igyPrecio_USD).Text) 'Ver nota mas arriba de PRECIO_SIN_DESCUENTO(en MXN), mismo criterio.
                        .oVentasDetalle.PRECIO_USD = valorNumericoD(Me.Grid.Cell(i, Me.iGyPRECIO_CON_DESCUENTO_USD).Text) 'Ver nota mas arriba de PRECIO(en MXN); Revisar por si se habilita nuevamente los embarques
                        .oVentasDetalle.DESCUENTO_UNITARIO_USD = valorNumericoD(Me.Grid.Cell(i, Me.iGyDESCUENTO_UNITARIO_USD).Text)
                        .oVentasDetalle.DESCUENTO_IMPORTE_USD = valorNumericoD(Me.Grid.Cell(i, Me.iGyDESCUENTO_IMPORTE_USD).Text)
                        '.oVentasDetalle.RETENCION_IVA_IMPORTE_USD = valorNumericoD(Me.Grid.Cell(i, Me.iGyFleteImporte_USD).Text)
                        .oVentasDetalle.RETENCION_IVA_BASE_USD = valorNumericoD(Me.Grid.Cell(i, Me.iGyRETENCION_IVA_BASE_USD).Text)
                        .oVentasDetalle.RETENCION_IVA_IMPORTE_USD = valorNumericoD(Me.Grid.Cell(i, Me.iGyRETENCION_IVA_IMPORTE_USD).Text)
                        .oVentasDetalle.RETENCION_ISR_BASE_USD = valorNumericoD(Me.Grid.Cell(i, Me.iGyRETENCION_ISR_BASE_USD).Text)
                        .oVentasDetalle.RETENCION_ISR_IMPORTE_USD = valorNumericoD(Me.Grid.Cell(i, Me.iGyRETENCION_ISR_IMPORTE_USD).Text)

                        ''''

                        If .oVentasDetalle.GrabaRenglon = False Then
                            MsgBox("Error al tratar de grabar el detalle.", MsgBoxStyle.Exclamation, sProcedure)
                            Return False
                        End If

                        sListaSeries = ""
                    End If
                Next

                If oDocumento.AFECTA_INVENTARIOS = True Then
                    If Me.sTipoVenta = "SR" Then
                        .SUSTITUYE_REMISION = "1"
                    Else
                        .SUSTITUYE_REMISION = "0"
                    End If

                    If .AfectaInventarios = False Then
                        MsgBox("Error al tratar de afectar inventarios en el movimiento de ventas.", MsgBoxStyle.Exclamation, sProcedure)
                        Return False
                    End If
                End If

                If Me.sTipoVenta = "SCR" Or sTipoVenta = "SCF" Then 'SUSTITUCION DE COTIZACION A REMISION O FACTURA
                    If .AfectaSustitucionCotizacion = False Then
                        Return False
                    End If
                ElseIf Me.sTipoVenta = "SR" Then 'SUSTITUCION DE REMISION
                    If .AfectaSustitucionRemision = False Then
                        Return False
                    End If
                End If

                'Aqui deb estar la póliza para asegurarse que se termine de afectar la sustitución, antes esto estaba al final dentro de oDocumento.AFECTA_INVENTARIOS
                If oDocumento.AFECTA_CONTABILIDAD = True Then
                    If .AplicarPoliza = False Then
                        Return False
                    End If
                End If

                If Me.chkTieneCartaPorte.Checked = True Then
                    If Me.GestionaCartaPorte = False Then
                        If MsgBox("No grabó la carta porte, quiere aún así timbrar la factura sin carta porte?", vbQuestion Or MsgBoxStyle.YesNo, sProcedure) = MsgBoxResult.No Then
                            GoTo SaltarTimbrado
                        End If
                    End If
                End If

                If Me.chkTieneCCE.Checked = True Then
                    If .GrabaComplementoComercioExteriorDatos(Me.cboIncoterm.SelectedValue.ToString) = False Then
                        If MsgBox("No grabó la carta porte, quiere aún así timbrar la factura sin carta porte?", vbQuestion Or MsgBoxStyle.YesNo, sProcedure) = MsgBoxResult.No Then
                            GoTo SaltarTimbrado
                        End If
                    End If
                End If

                'Complemento INE
                If Me.CboTipoProceso.SelectedIndex <> -1 Then
                    'Graba complemento INE
                    If Me.GrabarComplementoINE(Me.txtFolio.Text) = False Then
                        MsgBox("Error al tratar de grabar el Complemento INE", MsgBoxStyle.Exclamation, sProcedure)
                        GoTo SaltarTimbrado
                    End If

                End If

                Dim bVentaTimbrada As Boolean = False
                If Empresa_Sistema.FELECTRONICA_ACTIVA = True And oDocumento.TIMBRA_DOCUMENTO = True Then
                    Me.oVenta = New Class_Ventas_Global(Me.txtFolio.Text) 'Refrescar documento para evitar algún error por dato no cargado.
                    bVentaTimbrada = Me.oVenta.GeneraFacturaElectronica(False, True)
                End If
SaltarTimbrado:

                If bVentaAutorizadaPorRegla = True Then
                    .VENTA_TOTAL = CDbl(Me.lblTotal.Text)
                    If .ConsumeReglas = False Then
                        Return False
                    End If
                End If

                If Me._EsPorEmbarqueExtranjero = True Then
                    If Me._oEmbarqueExtranjero.GeneraMarcaFactura(Me.txtFolio.Text, True) = False Then
                        MsgBox("Error al tratar de marcar el embarque como facturado.", MsgBoxStyle.Exclamation, sProcedure)
                    End If
                Else
                    If txtLEN(Me.txtFolioEmbarque.Text) = True Then
                        Dim oEmbarques As New Class_Embarques_EmbarqueGlobal()
                        oEmbarques.FOLIO_EMBARQUE = Me.txtFolioEmbarque.Text
                        If oEmbarques.GeneraMarcaFactura(Me.txtFolio.Text, True) = False Then
                            MsgBox("Error al tratar de marcar el embarque como facturado.", MsgBoxStyle.Exclamation, sProcedure)
                        End If
                    End If
                End If

                If Me.EsFacturaVariasRemisiones = True Then
                    For i = 1 To Me.GridFacturasVariasRemisiones.Rows - 1
                        If oVenta.GrabaRelacionRemisionFactura(Me.GridFacturasVariasRemisiones.Cell(i, Me.iGyFolio).Text) = False Then
                            MsgBox("Error al grabar la relación de la remisión " & Me.GridFacturasVariasRemisiones.Cell(i, Me.iGyFolio).Text, MsgBoxStyle.Exclamation, sProcedure)
                            Return False
                        End If
                    Next
                End If

                bResultado = True
                MsgBox("Movimiento de ventas grabado satisfactoriamente.", MsgBoxStyle.Information, sProcedure)

                If Me._EsPorEmbarqueExtranjero = True Then
                    Me._GrabadaFacturaEmbarqueExtranjero = True
                    Me.Hide()
                End If

                'Todo este código tiene que ver con la generación de la nota de crédito por aplicación de anticipo.
                'En el ValidarVenta nos aseguramos que en caso de ser tipo de relación 07 , sólo permita una factura de tipo anticipo de modo que al llegar aquí eso ya es un hecho.
                '(Revolver una de anticipo y una normal no es válido y el ValidarVenta no deja avanzar)
                If Me.cboTipoRelacionCFDI.SelectedIndex <> -1 AndAlso Me.cboTipoRelacionCFDI.SelectedValue.ToString = "07" Then '07=CFDI por aplicación de anticipo
                    Dim sFolioVentaAnticipo As String = "", iVentasRelacionadas As Integer = 0

                    For i = 1 To Me.GridCFDIsRelacionados.Rows - 1
                        If txtLEN(Me.GridCFDIsRelacionados.Cell(i, Me.iGyGRFolio).Text) = True Then
                            iVentasRelacionadas += 1
                            sFolioVentaAnticipo = Me.GridCFDIsRelacionados.Cell(i, iGyGRFolio).Text

                            Dim sSQL As String =
                            "SELECT * INTO #VW_SIS_CAT_DOCUMENTOS_EXTENDIDO FROM VW_SIS_CAT_DOCUMENTOS_EXTENDIDO " +
                            "SELECT DOC.ES_FACTURA_ANTICIPO " +
                            "FROM VENTA_GLOBAL ANT " +
                            "INNER JOIN #VW_SIS_CAT_DOCUMENTOS_EXTENDIDO DOC ON(ANT.CODIGO_DOCUMENTO=DOC.CODIGO_DOCUMENTO) " +
                            "WHERE ANT.FOLIO_VENTA='" + sFolioVentaAnticipo + "' "

                            Dim tFind As New Class_find(sSQL)

                            If tFind.Result1 = "1" Then 'Si DOC.ES_FACTURA_ANTICIPO='1' es decir que es una factura de tipo anticipo.
                                'bTieneFacturasTipoAnticipo = True
                                Exit For 'De momento sólo se permite relacionar una sóla factura de anticipo.
                            Else
                                sFolioVentaAnticipo = "" 'No es de tipo anticipo por eso se pierde el dato para no grabar por error la nota de crédito.
                            End If
                        End If
                    Next

                    If txtLEN(sFolioVentaAnticipo) = True Then
                        'Grabar nota de crédito por anticipo automática.
                        If .GrabaNotaCreditoPorAnticipo(sFolioVentaAnticipo) = True Then
                            If Empresa_Sistema.FELECTRONICA_ACTIVA = True AndAlso Me.oDocumento.TIMBRA_DOCUMENTO = True Then
                                If bVentaTimbrada = True Then
                                    Dim oDescuentosCXC As New Class_CXC_Descuento(.FOLIO_DESCUENTO_ANTICIPO)
                                    If oDescuentosCXC.GeneraNotaCreditoElectronica(True, True) = True Then
                                        'MsgBox("FALTA ofrecer mecanismo de impresión, quizás llamar a pantalla de descuentos precargada o abrir pdf")
                                        'Dim f As New Frm_CXC_Descuentos()
                                        oDescuentosCXC = New Class_CXC_Descuento(.FOLIO_DESCUENTO_ANTICIPO) 'Inicializamos nuevamente luego del timbrado.
                                        oDescuentosCXC.Imprimir()
                                    End If
                                Else
                                    MsgBox("Esta venta no fue timbrada por lo que tampoco fue timbrada la nota de crédito " & .FOLIO_DESCUENTO_ANTICIPO, MsgBoxStyle.Exclamation, sProcedure)
                                End If
                            End If
                        End If
                    End If
                End If
                'Deben reestablercese estos valores para que no se confunda la consulta
                Me.EsFacturaVariasRemisiones = False
                Me.sTipoVenta = "NM"

            End With

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    'Private Function GeneraFacturaElectronicaLocal(ByVal bMensajes As Boolean) As Boolean
    '    Dim bResultado As Boolean = False
    '    Dim sRutaXML As String
    '    Try
    '        'sRutaXML = sFelectronicaCarpetaXMLPDF & "\" & Me.txtFolio.Text & ".xml"
    '        sRutaXML = sFelectronicaCarpetaXMLSinTimbrar & "\" & Me.txtFolio.Text & ".xml"

    '        oVenta = New Class_Ventas_Global(Me.txtFolio.Text)
    '        If oVenta.TIMBRADO_CFDI = "0" Then
    '            If GeneraFacturaElectronica(Me.oVenta, bMensajes, sRutaXML, False) = False Then
    '                'MsgBox "moverle aqui cuando ya se vaya a poner el complemento en el timbre usar esta linea en vez de la anterior !!! "
    '                MsgBox("Los datos digitales del documento no fueron generados correctamente. Avíse al depto. de sistemas.", vbExclamation, Me.Text)
    '            Else
    '                bResultado = True
    '                'ExportaFormatoVentaPDF(Me.txtFolio.Text, "F")
    '            End If
    '            'Else
    '            '    Me.RecuperarFacturaElectronicaLocal(bMensajes)
    '        End If

    '    Catch ex As Exception
    '        HandleError(Me.Name, "GeneraFacturaElectronicaLocal", ex)
    '    End Try

    '    Return bResultado
    'End Function

    'Private Function RecuperarFacturaElectronicaLocal(ByVal bMensajes As Boolean) As Boolean
    '    Dim sRutaXML As String
    '    Try
    '        sRutaXML = sFelectronicaCarpetaXMLPDF & "\" & Me.txtFolio.Text & ".xml"
    '        If RecuperaFacturaElectronica(Me.txtFolio.Text, bMensajes, sRutaXML) = False Then
    '            MsgBox("Los datos digitales de la factura electrónica no fueron generados correctamente. Avíse al depto. de sistemas.", vbExclamation, Me.Text)
    '        Else
    '            RecuperarFacturaElectronicaLocal = True
    '            MsgBox("Los datos digitales de la factura electrónica fueron recuperados correctamente. ", MsgBoxStyle.Information, Me.Text)
    '            'ExportaFormatoVentaPDF(Me.txtFolio.Text, "F")
    '        End If
    '        Exit Function
    '    Catch ex As Exception
    '        HandleError(Me.Name, "RecuperarFacturaElectronicaLocal", ex)
    '    End Try
    'End Function

    Private Function CancelarVenta() As Boolean
        Const sProcedure As String = "CancelarVenta"
        Dim bResultado As Boolean = False
        Dim oFirmaElectronica = New UtileriasFirmaElectronicaCancelacionMovimientosFueraPeriodo
        Dim oUtileriasCancela As New Class_UtileriasFirmaElectronicaCancelacion
        Dim oPoliza As New Class_Contabilidad_Poliza_Global
        Dim sConceptoCancelacion As String = ""

        If Me._EsPorEmbarqueExtranjero = False AndAlso oDocumento.ACCESIBLE_USUARIO = False Then
            MsgBox("Este documento no se puede cancelar directamente.", MsgBoxStyle.Exclamation, Me.Text)
            Return False
        End If

        If Me.oDocumento.AFECTA_INVENTARIOS = True Then
            If Empresa_Sistema.VALIDAR_CANCELACION_VENTAS = True Then 'Si el parametro es True valida que tenga el permiso de cancelación de ventas
                If Usuario.ValidaPermisoUsuarioDocumentoConAfectacionInventarios("CV_VTA" & Usuario.Codigo_Plaza.ToString, Me.CboAlmacen.SelectedValue.ToString) = False Then
                    MsgBox("El usuario " & Usuario.Nombre_Usuario & " no tiene permiso para cancelar el documento.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If

            Else
                If Usuario.ValidaPermisoUsuarioDocumentoConAfectacionInventarios(Me.CboDocumento.SelectedValue.ToString, Me.CboAlmacen.SelectedValue.ToString) = False Then
                    MsgBox("El usuario " & Usuario.Nombre_Usuario & " no tiene permiso para realizar el movimiento.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If

            End If
        Else
            If Usuario.ValidaPermisoUsuarioDocumentoSinAfectacionInventarios(Me.CboDocumento.SelectedValue.ToString) = False Then
                MsgBox("El usuario " & Usuario.Nombre_Usuario & " no tiene permiso para realizar el movimiento.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If
        End If

        If MsgBox("Deseas cancelar el movimiento de " & Me.CboDocumento.Text & " ?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, sProcedure) = MsgBoxResult.No Then
            Return False
        End If

        Try
            oUtileriasCancela.FOLIO_DOCUMENTO = Me.txtFolio.Text.ToUpper
            oUtileriasCancela.MODULO = Me.oVenta.CODIGO_MODULO
            oUtileriasCancela.CODIGO_PLAZA = Usuario.Codigo_Plaza

            If oUtileriasCancela.GestionaCancelacion() = False Then
                Return False
            End If

            If oUtileriasCancela.CANCELA_DIRECTO = True Then
                Me.oVenta.FECHA_CANCELACION = Date.Now

                sConceptoCancelacion = InputBox("Ingrese el concepto de cancelación :", sProcedure)
                oVenta.CONCEPTO_CANCELACION = sConceptoCancelacion

                GoTo CANCELAR
            Else
                oUtileriasCancela = New Class_UtileriasFirmaElectronicaCancelacion
                oUtileriasCancela.FOLIO_DOCUMENTO = Me.txtFolio.Text
                oUtileriasCancela.FOLIO_POLIZA = Me.oVenta.FOLIO_POLIZA
                oUtileriasCancela.CODIGO_DOCUMENTO = Me.CboDocumento.SelectedValue.ToString
                oUtileriasCancela.CODIGO_PLAZA = Usuario.Codigo_Plaza
                oUtileriasCancela.MODULO = Me.oVenta.CODIGO_MODULO

                If oUtileriasCancela.AutorizaCancelacionMovimientosFueraPeriodo() = False Then
                    'MsgBox("Error al tratar de autorizar la cancelación fuera del periodo.", MsgBoxStyle.Exclamation, Me.Text)
                    Return False
                End If

                sConceptoCancelacion = oUtileriasCancela.CANCELACION_CONCEPTO
                oVenta.CONCEPTO_CANCELACION = sConceptoCancelacion

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

                    Me.oVenta.FECHA_CANCELACION = oUtileriasCancela.FECHA_CANCELACION
                    GoTo CANCELAR
                End If
            End If

CANCELAR:
            Select Case Me.oVenta.TIPO_VENTA
                Case "NM", "FT"
                    If Me.oVenta.Cancelar() = False Then
                        Return False
                    End If
                Case "SCF", "SCR" 'SUSTITUCION DE COTIZACION
                    If Me.oVenta.DesafectaSustitucionCotizacion() = False Then
                        Return False
                    End If
                Case "SR"  'SUSTITUCION DE REMISION
                    If Me.oVenta.DesafectaSustitucionRemision() = False Then
                        Return False
                    End If
                Case Else
                    MsgBox("El tipo de venta " & Me.oVenta.TIPO_VENTA & " no esta definido en el proceso de cancelación.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
            End Select

            If txtLEN(Me.txtFolioEmbarque.Text) = True Then
                Dim oEmbarques As New Class_Embarques_EmbarqueGlobal()
                oEmbarques.FOLIO_EMBARQUE = Me.txtFolioEmbarque.Text

                If oEmbarques.GeneraMarcaFactura(Me.txtFolio.Text, False) = False Then
                    MsgBox("Error al tratar de marcar el embarque como facturado.", MsgBoxStyle.Exclamation, sProcedure)
                End If
            End If

            'MsgBox("Movimiento de venta cancelado.", MsgBoxStyle.Information, sProcedure)
            bResultado = True

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    Private Function ValidarVenta() As Boolean
        Const sProcedure As String = "ValidarVenta"
        Dim bResultado As Boolean = False
        Dim sRFCReceptor As String = "", sNombreReceptor As String = "", sDomicilioFiscalReceptor As String = ""

        Try
            If Plaza.ValidarPeriodoTrabajo(Me.dpFecha.Value) = False Then
                Return False
            End If

            If txtLEN(Me.txtFolio.Text) = False Then
                MsgBox("Asígne el folio de la venta.", MsgBoxStyle.Exclamation, sProcedure)
                Me.txtFolio.Focus()
                Return False
            End If

            If txtLEN(Me.TxtReferencia.Text) = True Then
                Me.oVenta = New Class_Ventas_Global(Me.TxtReferencia.Text)
                If Me.oVenta.Existe = False Then
                    MsgBox("Asígne una referencia válida.", MsgBoxStyle.Exclamation, sProcedure)
                    Me.TxtReferencia.Focus()
                    Return False
                End If
            End If

            If txtLEN(Me.TxtCliente.Text) = False Then
                MsgBox("Asígne un cliente.", MsgBoxStyle.Exclamation, sProcedure)
                Me.TxtCliente.Focus()
                Return False
            End If

            Me.oCliente = New Class_CatClientes(Me.TxtCliente.Text)
            If Me.oCliente.Existe = False Then
                MsgBox("Asígne un cliente válido.", MsgBoxStyle.Exclamation, sProcedure)
                Me.TxtCliente.Focus()
                Return False
            End If
            If Me.cboMoneda.SelectedIndex = -1 Then
                MsgBox("Seleccione la moneda de la venta por favor.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            If Me.oDocumento.CODIGO_TIPO_DOCUMENTO <> "FT" Then 'FT=Factura de traslado
                If Me.cboMoneda.Text = "XXX" Then
                    MsgBox("La moneda de la venta debe ser diferente de XXX para facturas normales.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If
            Else 'Es factura de traslado
                If Me.chkTieneCartaPorte.Checked = True Then
                    If Me.cboMoneda.Text <> "XXX" Then
                        MsgBox("La moneda de la venta debe ser XXX cuando es una factura de traslado con complemento carta porte.", MsgBoxStyle.Exclamation, sProcedure)
                        Return False
                    End If
                Else
                    If Me.cboMoneda.Text = "XXX" Then
                        MsgBox("La moneda de la venta debe ser diferente de XXX cuando es una factura de traslado sin complemento carta porte.", MsgBoxStyle.Exclamation, sProcedure)
                        Return False
                    End If
                End If
            End If

            If Me.oDocumento.AFECTA_CONTABILIDAD = True Then
                If txtLEN(Me.oCliente.CUENTA_CONTABLE) = False Then
                    MsgBox("El cliente no tiene una cuenta contable en pesos asignada.", MsgBoxStyle.Exclamation, sProcedure)
                    Me.TxtCliente.Focus()
                    Return False
                End If
            End If

            Dim oVendedor As New Class_CatVendedores(Me.cboVendedor.SelectedValue.ToString)
            If oVendedor.Status = "B" Then
                MsgBox("El vendedor que asígnado a la venta esta dado de baja", MsgBoxStyle.Exclamation, sProcedure)
                Me.cboVendedor.Focus()
                Return False
            End If

            If Empresa_Sistema.FELECTRONICA_ACTIVA = True And oDocumento.TIMBRA_DOCUMENTO = True Then
                If Me.chkVentaPublicoGeneral.Checked = False Then
                    If ValidacionesRFC(Me.oCliente.RFC) = False Then
                        Return False
                    End If
                End If
            End If

            If Me.oDocumento.CODIGO_TIPO_DOCUMENTO <> "FT" Then 'Factura de traslado
                If Me.cboFormaPago.SelectedIndex = -1 Then
                    MsgBox("Asígne una forma de pago", MsgBoxStyle.Exclamation, sProcedure)
                    Me.cboFormaPago.Focus()
                    Return False
                End If
            End If

            If txtLEN(Me.txtFolioEmbarque.Text) = True Then
                Dim oEmbarques As New Class_Embarques_EmbarqueGlobal
                oEmbarques.FOLIO_EMBARQUE = Me.txtFolioEmbarque.Text
                If oEmbarques.Consultar() = False Then
                    MsgBox("El folio de embarque no existe, favor de verificar.", MsgBoxStyle.Exclamation, sProcedure)
                    Me.txtFolioEmbarque.Focus()
                    Return False
                End If

                'No se porque volvia a preguntar si desean grabar cuando ya se preguntó
                'If MsgBox("Deseas grabar la " & Me.CboDocumento.Text & " con el folio : " & Me.txtFolio.Text & " ?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, sProcedure) = MsgBoxResult.No Then
                '    Return False
                'End If

                If oEmbarques.FACTURA_GENERADA = True Then 'EL EMBARQUE YA TIENE UNA FACTURA ACTIVA
                    If MsgBox("El embarque ya tiene generada una factura, Deseas volver a facturar el embarque" & Me.txtFolioEmbarque.Text & " ?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, sProcedure) = MsgBoxResult.No Then
                        Me.txtFolioEmbarque.Focus()
                        Return False
                    End If
                End If
            End If

            If Me.cboMoneda.Text = "USD" Then
                If Me.oDocumento.AFECTA_CONTABILIDAD = True Then
                    If txtLEN(Me.oCliente.CUENTA_CONTABLE_DOLARES) = False Then
                        MsgBox("El cliente no tiene una cuenta contable en dólares asignada.", MsgBoxStyle.Exclamation, sProcedure)
                        Me.TxtCliente.Focus()
                        Return False
                    End If
                End If

                If valorNumerico(Me.txtTipoCambio.Text) <= 0 Then
                    MsgBox("Asígne el tipo de cambio.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If
            End If

            If Me.SiTieneRenglones() = False Then
                MsgBox("Asígne los artículos del movimiento.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            If Me.SiTieneCantidad() = False Then
                MsgBox("La cantidad de los artículos debe de ser mayor a cero.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            If Me.SiTieneImporte() = False Then 'Aquí esta implícito la misma validación del precio 0
                MsgBox("El importe de los renglones debe de ser mayor a cero.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            If Me.SiTieneProductosKG() = False Then
                MsgBox("La cantidad y/o de precio en kg de los renglones debe de ser mayor a cero.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            If Me.SiTieneIVA = False Then
                Return False
            End If

            If Me.oDocumento.CODIGO_TIPO_DOCUMENTO <> "FT" Then 'Factura de traslado
                If valorNumericoD(Me.lblSubtotal.Text) <= 0 Then
                    MsgBox("El subtotal debe ser mayor a cero.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If
            End If

            'Dim i As Integer
            'For i = 1 To Grid.Rows - 1
            '    If txtLEN(Me.Grid.Cell(i, Me.igyCodigo).Text) = True Then
            '        If Me.oCompras.ValidaCantidadDisponibleArticulo(CInt(Me.Grid.Cell(i, Me.igyIdOrigen).Text), CDbl(Me.Grid.Cell(i, Me.igyCantidad).Text)) = False Then
            '            MsgBox("La cantidad debe de ser menor al disponible.", MsgBoxStyle.Exclamation, Me.Text)
            '            Me.Grid.Cell(i, Me.igyCantidad).SetFocus()
            '            Return False
            '        End If
            '    End If
            'Next i

            Dim oFormaPago As New Class_CFD_CatFormasPago(Me.cboFormaPago.SelectedValue.ToString)

            If Me.oDocumento.CODIGO_TIPO_DOCUMENTO <> "FT" Then 'Factura de traslado
                If oFormaPago.ESTATUS = "B" Then
                    MsgBox("La forma de pago tiene estatus baja.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If
            End If

            If Me.oDocumento.AFECTA_CXC = True Then
                If Me.cboFormaPago.SelectedIndex = -1 Then
                    MsgBox("Seleccione una forma de pago.", MsgBoxStyle.Exclamation, sProcedure)
                    If Me.cboFormaPago.Enabled = True Then
                        Me.cboFormaPago.Focus()
                    End If
                    Return False
                End If

                'If Empresa_Sistema.VERSION_ESQUEMA_CFD <= "3.2" Then
                '    If oFormaPago.REQUIERE_NUMERO_CUENTA_PAGO = 1 Then
                '        If txtLEN(Me.txtNumeroCuentaPago.Text) = False Then
                '            If MsgBox("La forma de pago tiene opcional el número de cuenta de pago. Esta seguro de dejarlo en blanco ?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then
                '                Return False
                '            End If
                '        End If
                '    End If
                'Else
                If Me.cboMetodoPago.SelectedIndex = -1 Then
                    MsgBox("Seleccione un método de pago.", vbExclamation, sProcedure)
                    Return False
                End If

                If Me.cboFormaPago.SelectedIndex = -1 Then
                    MsgBox("Seleccione una forma de pago.", MsgBoxStyle.Exclamation, sProcedure)
                    If Me.cboFormaPago.Enabled = True Then
                        Me.cboFormaPago.Focus()
                    End If
                    Return False
                End If

                Select Case Me.cboTipoNegociacion.Text
                    Case "CONTADO"
                        'Se quitó la restricción, biologos ocupa facturar un auto a una aseguradora con PUE-99
                        'If Me.cboFormaPago.SelectedValue.ToString = "99" Then
                        '    MsgBox("La forma de pago no puede ser 99-Por definir porque al ser venta de ""contado"" entonces se sabe como se esta pagando el documento.", vbExclamation, sProcedure)
                        '    If Me.cboFormaPago.Enabled = True Then
                        '        Me.cboFormaPago.Focus()
                        '    End If
                        '    Return False
                        'End If
                    Case "CREDITO" 'SE PERMITIRA GRABAR A CREDITO CON OTRA FORMA DE PAGO
                        'If Me.cboFormaPago.SelectedValue.ToString <> "99" Then
                        '    MsgBox("La forma de pago debe ser 99-Por definir porque al ser venta de ""crédito"" no hay pago.", vbExclamation, sProcedure)
                        '    If Me.cboFormaPago.Enabled = True Then
                        '        Me.cboFormaPago.Focus()
                        '    End If
                        '    Return False
                        'End If
                End Select

                'If Me.cboUsoCFDI.SelectedIndex = -1 Then
                '    MsgBox("Seleccione el uso del CFDI.", vbExclamation, sProcedure)
                '    If Me.cboUsoCFDI.Enabled = True Then
                '        Me.cboUsoCFDI.Focus()
                '    End If
                '    Return False
                'End If
            End If

            If Me.cboRegimenFiscalEmisor.SelectedIndex = -1 Then
                MsgBox("Seleccione un régimen fiscal del ""Emisor"".", vbExclamation, sProcedure)
                Return False
            End If

            Me.oCliente = New Class_CatClientes(Me.TxtCliente.Text)

            If Me.oCliente.Existe = False Then
                MsgBox("El cliente no existe, verifique por favor.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            If Me.chkVentaPublicoGeneral.Checked = True Then
                sRFCReceptor = "XAXX010101000"
                sNombreReceptor = "PUBLICO GENERAL" 'Ojo no es lo mismo que "PUBLICO EN GENERAL" que tiene la palabra "EN" y SAT lo valida diferente.
            Else
                sRFCReceptor = Me.oCliente.RFC
                sNombreReceptor = Me.oCliente.NOMBRE_CLIENTE
            End If

            If txtLEN(sNombreReceptor) = False Then
                MsgBox("El nombre del cliente esta vacío, verifique por favor.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            'El SAT dice : Si el valor del atributo Rfc del receptor es "XAXX010101000" o "XEXX010101000", este atributo debe ser igual al valor del atributo LugarExpedicion.
            If sRFCReceptor = Empresa_Sistema.RFC_VENTA_PUBLICO_GENERAL Or sRFCReceptor = Empresa_Sistema.RFC_EXTRANJERO Then
                sDomicilioFiscalReceptor = Plaza.CODIGO_POSTAL

                If txtLEN(sDomicilioFiscalReceptor) = False Then
                    MsgBox("El cliente al tener el rfc XAXX010101000 ó XEXX010101000 el código postal debe ser igual que LugarExpedicion(Plaza para nosotros), y la plaza no tiene código postal.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If
            Else
                sDomicilioFiscalReceptor = Me.oCliente.CODIGO_POSTAL

                If txtLEN(sDomicilioFiscalReceptor) = False Then
                    MsgBox("El cliente debe tener código postal, verifique por favor.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If txtLEN(Me.txtRegimenFiscalReceptor.Text) = False Then
                MsgBox("Seleccione el régimen fiscal del ""Receptor"".", vbExclamation, sProcedure)
                Me.lblRegimenFiscalReceptor.Text = "" : Return False
            End If

            Dim oRegimenFiscalReceptor As New Class_CFDCatTiposRegimenesFiscales(Me.txtRegimenFiscalReceptor.Text), bRegimenFiscalReceptorInvalido As Boolean

            Me.lblRegimenFiscalReceptor.Text = oRegimenFiscalReceptor.NOMBRE_REGIMEN_FISCAL 'Lo va consultar aunque pudiera no ser válido, mas abajo lo eliminará

            If oRegimenFiscalReceptor.EXISTE = False Then
                MsgBox("El régimen fiscal del receptor no existe.", MsgBoxStyle.Exclamation, sProcedure)
                bRegimenFiscalReceptorInvalido = True
            ElseIf sRFCReceptor = "XAXX010101000" Or sRFCReceptor = "XEXX010101000" Then
                If Me.txtRegimenFiscalReceptor.Text <> "616" Then 'El SAT así lo exige.
                    MsgBox("El régimen fiscal para receptores con RFC genérico XAXX010101000 ó XEXX010101000 debe ser 616=Sin obligaciones fiscales.", MsgBoxStyle.Exclamation, sProcedure)
                    bRegimenFiscalReceptorInvalido = True
                End If
            ElseIf oRegimenFiscalReceptor.ESTATUS = "B" Then
                MsgBox("El régimen fiscal del receptor" & Me.lblRegimenFiscalReceptor.Text & " esta dado de baja.", MsgBoxStyle.Exclamation, sProcedure)
                bRegimenFiscalReceptorInvalido = True
            Else
                Select Case Me.oCliente.TIPO_PERSONA
                    Case "F" 'FISICA
                        If oRegimenFiscalReceptor.APLICA_TIPO_FISICA = False Then
                            MsgBox("El régimen fiscal del receptor " & Me.txtRegimenFiscalReceptor.Text & "-" & Me.lblRegimenFiscalReceptor.Text & " no aplica para personas físicas.", MsgBoxStyle.Exclamation, sProcedure)
                            bRegimenFiscalReceptorInvalido = True
                        End If
                    Case "M" 'MORAL
                        If oRegimenFiscalReceptor.APLICA_TIPO_MORAL = False Then
                            MsgBox("El régimen fiscal del receptor " & Me.txtRegimenFiscalReceptor.Text & "-" & Me.lblRegimenFiscalReceptor.Text & " no aplica para personas morales.", MsgBoxStyle.Exclamation, sProcedure)
                            bRegimenFiscalReceptorInvalido = True
                        End If
                End Select
            End If

            If bRegimenFiscalReceptorInvalido = True Then
                Me.txtRegimenFiscalReceptor.Text = "" : Me.lblRegimenFiscalReceptor.Text = "" : Return False
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'If Me.cboUsoCFDI.SelectedIndex = -1 Then
            If txtLEN(Me.txtUsoCFDI.Text) = False Then
                MsgBox("Seleccione un uso del CFDI.", vbExclamation, sProcedure)
                Me.lblUsoCFDI.Text = "" : Return False
            End If

            Dim oUsoCFDI As New Class_CFD_CatUsosCFDI(Me.txtUsoCFDI.Text), bUsoCFDIInvalido As Boolean

            Me.lblUsoCFDI.Text = oUsoCFDI.NOMBRE_USO_CFDI 'Lo va consultar aunque pudiera no ser válido, mas abajo lo eliminará

            If oUsoCFDI.EXISTE = False Then
                MsgBox("El uso del CFDI no existe.", MsgBoxStyle.Exclamation, sProcedure)
                bUsoCFDIInvalido = True
            ElseIf oUsoCFDI.ESTATUS = "B" Then
                MsgBox("El uso del CFDI " & Me.lblUsoCFDI.Text & " esta dado de baja.", MsgBoxStyle.Exclamation, sProcedure)
                bUsoCFDIInvalido = True
            Else
                Select Case Me.oCliente.TIPO_PERSONA
                    Case "F" 'FISICA
                        If oUsoCFDI.APLICA_TIPO_FISICA = False Then
                            MsgBox("El uso del CFDI " & Me.txtUsoCFDI.Text & "-" & Me.lblUsoCFDI.Text & " no aplica para personas físicas.", MsgBoxStyle.Exclamation, sProcedure)
                            bUsoCFDIInvalido = True
                        ElseIf oUsoCFDI.REGIMEN_FISCAL_RECEPTOR.Contains(Me.txtRegimenFiscalReceptor.Text) = False Then
                            MsgBox("El uso del CFDI " & Me.txtUsoCFDI.Text & "-" & Me.lblUsoCFDI.Text & " no aplica para el régimen fiscal del receptor " & Me.txtRegimenFiscalReceptor.Text & "-" & Me.lblRegimenFiscalReceptor.Text, vbExclamation, sProcedure)
                            bUsoCFDIInvalido = True
                        End If
                    Case "M" 'MORAL
                        If oUsoCFDI.APLICA_TIPO_MORAL = False Then
                            MsgBox("El uso del CFDI " & Me.txtUsoCFDI.Text & "-" & Me.lblUsoCFDI.Text & " no aplica para personas morales.", MsgBoxStyle.Exclamation, sProcedure)
                            bUsoCFDIInvalido = True
                        ElseIf oUsoCFDI.REGIMEN_FISCAL_RECEPTOR.Contains(Me.txtRegimenFiscalReceptor.Text) = False Then
                            MsgBox("El uso del CFDI " & Me.txtUsoCFDI.Text & "-" & Me.lblUsoCFDI.Text & " no aplica para el régimen fiscal del receptor " & Me.txtRegimenFiscalReceptor.Text & "-" & Me.lblRegimenFiscalReceptor.Text, vbExclamation, sProcedure)
                            bUsoCFDIInvalido = True
                        End If
                End Select
            End If

            If bUsoCFDIInvalido = True Then
                Me.txtUsoCFDI.Text = "" : Me.lblUsoCFDI.Text = "" : Return False
            End If

            If Me.chkVentaPublicoGeneral.Checked = False Then 'Se pregunta porque si es público general el nombre se asigna en automático como sNombreReceptor="PUBLICO GENERAL" 
                Dim sPatronInvalido As String = ""
                sPatronInvalido = Me.oCliente.TieneNombreClientePatronInvalido(Me.oCliente.NOMBRE_CLIENTE)
                If txtLEN(sPatronInvalido) = True Then
                    If MsgBox("El cliente tiene siglas como S.A. DE C.V. o alguna similar lo cual no es permitido desde la versión 4.0 " & vbCrLf &
                                            "Patrón inválido detectado " & sPatronInvalido & vbCrLf &
                                             "Es probable que no se timbre y tenga que cancelar la factura, seguro desea continuar ?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, sProcedure) = MsgBoxResult.No Then
                        Return False
                    End If
                End If
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'End If
            'End If

            If sTipoVenta <> "NM" Then
                If Me.ValidarDisponible() = False Then
                    Return False
                End If
            End If

            If Me.oDocumento.AFECTA_CONTABILIDAD = True Then
                If Me.ValidarCentrosCostos = False Then
                    Return False
                End If
            End If

            If Me.ValidaNumerosSerie = False Then
                Return False
            End If

            If Me.HaySeriesRepetidas = True Then
                Return False
            End If

            'If Me.sTipoVenta <> "SR" AndAlso Me.oDocumento.AFECTA_INVENTARIOS = True AndAlso Me.EsFacturaVariasRemisiones = False Then
            If Me.oDocumento.AFECTA_INVENTARIOS = True Then 'Dentro revisa porque puede ser sustitución con artículos agregados directos(adicionales que no vienen de sustituir remisiones) y tampoco importa ya EsFacturaVariasRemisiones
                If Me.ValidarExistencias() = False Then
                    Return False
                End If
            End If

            If Me.sTipoVenta = "SR" Then
                'Antes sólo se permitia sustituir una remisión, ahora varias y los folios estarán en el grid de remisiones.
                'If oVenta.SiRemisionTieneMovimientosAbonoParaEvitarSustitucion(Me.TxtReferencia.Text) = True Then 'Aqui ya se quiere convertir a remisión, entonces el folio sale del txtReferencia
                '    Return False
                'End If

                Dim bEstaRemisionSiSeUso As Boolean = False
                For i As Integer = 1 To Me.GridFacturasVariasRemisiones.Rows - 1
                    Dim sFolioRemision As String = Me.GridFacturasVariasRemisiones.Cell(i, Me.iGyFolio).Text
                    bEstaRemisionSiSeUso = False 'La inicializamos en cada vuelta

                    If txtLEN(sFolioRemision) = True Then
                        'Si la remisión no tiene al menos un renglón utilizado en el grid principal avisar que deben de borrarla del listado
                        For j As Integer = 1 To Me.Grid.Rows - 1
                            Dim iIDOrigen As Integer = CInt(0 & Me.Grid.Cell(j, Me.igyIdOrigen).Text)
                            If iIDOrigen > 0 Then
                                Dim oSQL As New Class_find("SELECT 1 FROM VENTA_DETALLE WHERE FOLIO_VENTA='" & sReplace(sFolioRemision) & "' AND ID_VENTA_DETALLE=" & iIDOrigen.ToString)
                                If oSQL.Result1 = "1" Then
                                    bEstaRemisionSiSeUso = True
                                    Exit For
                                End If
                            End If
                        Next

                        If bEstaRemisionSiSeUso = False Then
                            MsgBox("La remisión " & sFolioRemision & " no fue utilizada así que debe de empezar todo el proceso desde el principio y eliminar las remisiones que no se necesiten desde antes de Aceptar(cargarlas).", MsgBoxStyle.Exclamation, sProcedure)
                            Return False
                        End If
                        If oVenta.SiRemisionTieneMovimientosAbonoParaEvitarSustitucion(sFolioRemision) = True Then
                            Return False
                        End If
                    End If
                Next

                'Es sustitución de una sola remisión, se valida que tengan el mismo almacén ambos documentos.
                If txtLEN(Me.TxtReferencia.Text) = True Then
                    Dim oRemision As New Class_Ventas_Global(Me.TxtReferencia.Text)
                    If oRemision.Existe = False Then
                        MsgBox("La remisión que se quiere sustituir no existe.", MsgBoxStyle.Exclamation, sProcedure)
                        Return False
                    End If
                    If Me.CboAlmacen.SelectedValue.ToString <> oRemision.CODIGO_ALMACEN Then
                        MsgBox("El almacén de la factura debe ser igual que el almacén de la remisión.", MsgBoxStyle.Exclamation, sProcedure)
                        Return False
                    End If
                End If

            End If

            If Me.oDocumento.AFECTA_CONTABILIDAD = True Then
                If Me.SiTieneCuentaContable() = False Then
                    MsgBox("Asígne la cuenta contable a todos los renglones.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If

                If Me.ValidaCuentaContable = False Then
                    MsgBox("Cuenta contable inválida.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If
            End If

            If Me.ValidaDescuentos = False Then
                Return False
            End If

            If Me.ValidaPrecios = False Then
                Return False
            End If

            If Me.ValidaValorColumaCostoCapturaNoInventariables = False Then
                Me.GestionaColumaCostoCapturaNoInventariables()
                Return False
            End If

            If Me.oDocumento.ES_FACTURA_ANTICIPO = True Then
                'If Me.oDocumento.AFECTA_CONTABILIDAD = True Then
                'Esta factura no va afectar contabilidad, la póliza se afecta al momento del pago, pero sin embargo de una vez obligamos a que tenga cuenta contable anticipos.
                If txtLEN(Me.oCliente.CUENTA_CONTABLE_ANTICIPOS) = False Then
                    MsgBox("El cliente no tiene una cuenta contable de anticipos.", MsgBoxStyle.Exclamation, sProcedure)
                    Me.TxtCliente.Focus()
                    Return False
                End If
                'End If

                If Me.cboMetodoPago.SelectedValue.ToString <> "PUE" Then
                    MsgBox("El método de pago para anticipos debe ser PUE según el SAT.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If

                If Me.cboFormaPago.SelectedValue.ToString = "99" Then
                    MsgBox("La forma de pago no puede ser " & Me.cboFormaPago.Text & " porque éste es un anticipo y ya se sabe como se pagó, el SAT así lo indica.", vbExclamation, sProcedure)
                    If Me.cboFormaPago.Enabled = True Then
                        Me.cboFormaPago.Focus()
                    End If
                    Return False
                End If

                Dim sResultado As String = Me.TieneArticulosInventariables

                If txtLEN(sResultado) = True Then
                    MsgBox("En los anticipos no se permiten artículos inventariables los cuales son : " & vbCrLf & sResultado, MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If

                If valorNumericoD(Me.lblIEPS.Text) > 0 Or valorNumericoD(Me.lblIEPSIncluido.Text) > 0 Then
                    MsgBox("En los anticipos no se permite de momento el impuesto IEPS.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If

                If valorNumericoD(Me.lblTotalRetencionIVA.Text) > 0 Then
                    MsgBox("En los anticipos no se permite de momento la retención de IVA.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If

                If valorNumericoD(Me.lblTotalRetencionISR.Text) > 0 Then
                    MsgBox("En los anticipos no se permite de momento la retención de ISR.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If

            End If

            Dim bTieneFacturasTipoAnticipo As Boolean = False, iVentasRelacionadas As Integer = 0, iVentasAnticipos As Integer = 0

            'Detectar si es anticipo de los viejos(permiten relacionar varias y no deben ser fact. anticipo), o de los nuevos(sólo permiten relacionar uno y de tipo factura de anticipo)
            If Me.cboTipoRelacionCFDI.SelectedIndex <> -1 AndAlso Me.cboTipoRelacionCFDI.SelectedValue.ToString = "07" Then '07=CFDI por aplicación de anticipo
                Dim sFolioVentaRelacionada As String = ""

                For i = 1 To Me.GridCFDIsRelacionados.Rows - 1
                    If txtLEN(Me.GridCFDIsRelacionados.Cell(i, Me.iGyGRFolio).Text) = True Then
                        iVentasRelacionadas += 1
                        sFolioVentaRelacionada = Me.GridCFDIsRelacionados.Cell(i, iGyGRFolio).Text

                        Dim sSQL As String =
                                "SELECT * INTO #VW_SIS_CAT_DOCUMENTOS_EXTENDIDO FROM VW_SIS_CAT_DOCUMENTOS_EXTENDIDO " +
                                "SELECT DOC.ES_FACTURA_ANTICIPO " +
                                "FROM VENTA_GLOBAL ANT " +
                                "INNER JOIN #VW_SIS_CAT_DOCUMENTOS_EXTENDIDO DOC ON(ANT.CODIGO_DOCUMENTO=DOC.CODIGO_DOCUMENTO) " +
                                "WHERE ANT.FOLIO_VENTA='" + sFolioVentaRelacionada + "' "

                        Dim tFind As New Class_find(sSQL)

                        If tFind.Result1 = "1" Then 'Si DOC.ES_FACTURA_ANTICIPO='1' es decir que es una factura de tipo anticipo.
                            bTieneFacturasTipoAnticipo = True
                            Exit For
                        End If

                    End If
                Next
            End If

            'Notas
            'Aunque el código de arriba se asemeja(no es igual) a este debajo no tratar de unificar ya que el objetivo de arriba es saber si hay al menos una factura de anticipo.
            'No se pregunta por  bTieneFacturasTipoAnticipo = False porque entonces se ocupa anidar mas hacia dentro el if donde si sea de anticipo
            'En cambio por eso sl siguiente if empieza con If bTieneFacturasTipoAnticipo = True AndAlso
            'Si bTieneFacturasTipoAnticipo = True y el tipo de relación fuera otra<>07, no se limita su uso, y claro no va generar nota de crédito.

            If bTieneFacturasTipoAnticipo = True AndAlso Me.cboTipoRelacionCFDI.SelectedIndex <> -1 AndAlso Me.cboTipoRelacionCFDI.SelectedValue.ToString = "07" Then '07=CFDI por aplicación de anticipo
                Dim sFolioVentaAnticipo As String = ""

                For i = 1 To Me.GridCFDIsRelacionados.Rows - 1
                    If txtLEN(Me.GridCFDIsRelacionados.Cell(i, Me.iGyGRFolio).Text) = True Then
                        iVentasAnticipos += 1
                        sFolioVentaAnticipo = Me.GridCFDIsRelacionados.Cell(i, iGyGRFolio).Text
                    End If
                Next

                If iVentasAnticipos > 1 Then
                    MsgBox("De momento sólo puede relacionarse una sola factura de tipo anticipo.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If

                Dim Conexion As New SqlClient.SqlConnection(Empresa_Sistema.conexion)

                Dim sSQL As String =
                                "SELECT * INTO #VW_SIS_CAT_DOCUMENTOS_EXTENDIDO FROM VW_SIS_CAT_DOCUMENTOS_EXTENDIDO " +
                                "SELECT DOC.ES_FACTURA_ANTICIPO,ANT.CODIGO_MONEDA_SAT,ANT.ES_VENTA_PUBLICO_GENERAL,ANT.TOTAL TOTAL_MXN,ANT.TOTAL_DOLARES TOTAL_USD,ANT.IMPUESTO  " +
                                "FROM VENTA_GLOBAL ANT " +
                                "INNER JOIN #VW_SIS_CAT_DOCUMENTOS_EXTENDIDO DOC ON(ANT.CODIGO_DOCUMENTO=DOC.CODIGO_DOCUMENTO) " +
                                "WHERE ANT.FOLIO_VENTA='" + sFolioVentaAnticipo + "' "

                Dim dt As New DataTable
                Dim da As New SqlClient.SqlDataAdapter(sSQL, Conexion)
                da.Fill(dt)

                If dt.Rows.Count = 0 Then
                    MsgBox("No se encontró información de la venta " + sFolioVentaAnticipo, MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If

                If dt(0)("ES_FACTURA_ANTICIPO").ToString <> "1" Then
                    MsgBox("La factura " + sFolioVentaAnticipo + " no es de tipo anticipo.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If

                If dt(0)("CODIGO_MONEDA_SAT").ToString <> Me.cboMoneda.Text Then
                    MsgBox("La factura de anticipo(" + dt(0)("CODIGO_MONEDA_SAT").ToString + ") y esta factura(" + Me.cboMoneda.Text + ") deben tener la misma moneda.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If

                If dt(0)("ES_VENTA_PUBLICO_GENERAL").ToString <> Convert.ToInt32(Me.chkVentaPublicoGeneral.Checked).ToString Then
                    MsgBox("La factura de anticipo y esta factura deben ser ambas ventas normales, o ambas a público general.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If

                'Select Case dt(0)("CODIGO_MONEDA_SAT").ToString
                '    Case "MXN"
                '        If valorNumericoD(dt(0)("TOTAL_MXN").ToString) > valorNumericoD(Me.lblTotal.Text) Then
                '            MsgBox("El total MXN de la factura de anticipo de ser menor o igual que el total de la factura final." + vbCrLf +
                '                       "Anticipo.Total=" + FormatImporteContable(valorNumericoD(dt(0)("TOTAL_MXN").ToString)) + " MXN" + vbCrLf +
                '                       "FacturaFinal.Total=" + FormatImporteContable(valorNumericoD(Me.lblTotal.Text)) + " MXN" + vbCrLf, MsgBoxStyle.Exclamation, sProcedure)
                '            Return False
                '        End If
                '    Case "USD"
                '        If valorNumericoD(dt(0)("TOTAL_USD").ToString) > valorNumericoD(Me.lblTotal_USD.Text) Then
                '            MsgBox("El total USD de la factura de anticipo de ser menor o igual que el total de la factura final." + vbCrLf +
                '                       "Anticipo.Total=" + FormatImporteContable(valorNumericoD(dt(0)("TOTAL_USD").ToString)) + " USD" + vbCrLf +
                '                       "FacturaFinal.Total=" + FormatImporteContable(valorNumericoD(Me.lblTotal_USD.Text)) + " USD" + vbCrLf, MsgBoxStyle.Exclamation, sProcedure)
                '            Return False
                '        End If
                'End Select

                'If valorNumericoD(dt(0)("IMPUESTO").ToString) = 0 And valorNumericoD(Me.lblImpuesto.Text) > 0 Then
                '    MsgBox("La factura de anticipo no tiene IVA y esta factura si tiene, de momento esto no es posible.", MsgBoxStyle.Exclamation, sProcedure)
                '    Return False
                'ElseIf valorNumericoD(dt(0)("IMPUESTO").ToString) > 0 Then
                '    If valorNumericoD(Me.lblImpuesto.Text) = 0 Then
                '        MsgBox("La factura de anticipo si tiene IVA y esta factura no tiene, de momento esto no es posible.", MsgBoxStyle.Exclamation, sProcedure)
                '        Return False
                '    End If

                '    If valorNumericoD(dt(0)("IMPUESTO").ToString) > valorNumericoD(Me.lblImpuesto.Text) Then
                '        MsgBox("La factura de anticipo tiene un IVA mayor que esta factura, de momento esto no es posible.", MsgBoxStyle.Exclamation, sProcedure)
                '        Return False
                '    End If
                'End If

                'sSQL = "SELECT VTA.FOLIO_VENTA FROM VENTAS_CFDI_RELACIONADOS R " +
                '            "INNER JOIN VENTA_GLOBAL VTA ON(R.FOLIO_VENTA=VTA.FOLIO_VENTA) " +
                '            "WHERE R.FOLIO_VENTA_RELACIONADA='" + sFolioVentaAnticipo + "' " +
                '            "AND VTA.ESTATUS_VENTA='A' AND SALDO_ANTICIPO_DISPONIBLE=0"

                sSQL = "SELECT FOLIO_VENTA FROM VENTA_GLOBAL WHERE FOLIO_VENTA='" + sFolioVentaAnticipo + "' AND SALDO_ANTICIPO_DISPONIBLE=0"

                Dim oFind As New Class_find(sSQL)
                If txtLEN(oFind.Result1) = True Then
                    'MsgBox("La factura de anticipo " + sFolioVentaAnticipo + " ya fue utilizada en la factura " + oFind.Result1 + " que actualmente esta activa, no puede volver a relacionarse el mismo anticipo.", MsgBoxStyle.Exclamation, sProcedure)
                    MsgBox("La factura de anticipo " + sFolioVentaAnticipo + " ya no tiene saldo disponible para aplicar.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If

            End If

            'Complemento INE
            If Me.CboTipoProceso.SelectedIndex <> -1 Then
                If Me.ValidaDatosComplementoINE() = False Then
                    Return False
                End If
            End If

            bResultado = True

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    Private Function ValidarReglasCreditoplazo(ByVal bMostrarMensajes As Boolean) As Boolean
        Try
            'If Me.oDocumento.AFECTA_CXC = False Then
            '    Return True
            'End If

            Dim oSisAdministracionClientes = New Class_Sis_Administracion_Clientes
            oSisAdministracionClientes.CodigoCliente = Me.TxtCliente.Text
            oSisAdministracionClientes.TOTAL_VENTA = CDbl(Me.lblTotal.Text)

            If oSisAdministracionClientes.Consultar = False Then
                Return False
            End If

            bVentaAutorizadaPorRegla = False
            If oSisAdministracionClientes.VENTA_AUTORIZADA_POR_REGLA_CXC = "1" Then
                bVentaAutorizadaPorRegla = True
                Return True
            ElseIf oSisAdministracionClientes.TIENE_VENTAS_CONTADO_VENCIDAS = "1" Then
                If bMostrarMensajes = True Then
                    MsgBox("El cliente presenta ventas de contado vencidas, favor de contactar al depto de CXC.", vbExclamation, "ValidarReglasCreditoplazo")
                End If
                Return False
            Else
                Select Case Me.cboTipoNegociacion.Text
                    'Case "CONTADO"
                    '    If oSisAdministracionClientes.TIENE_VENTAS_CONTADO_VENCIDAS = "1" Then
                    '        return false
                    '    End If
                    Case "CREDITO"
                        If CDbl(oSisAdministracionClientes.SaldoVencido) > 0 Then
                            If bMostrarMensajes = True Then
                                MsgBox("El cliente presenta saldo vencido.", vbExclamation, "ValidarReglasCreditoplazo")
                            End If
                            Return False
                        End If
                End Select
            End If

            'If Me.oDocumento.AFECTA_INVENTARIOS = True Then
            '    If Me.sTipoVenta <> "SR" Then
            'SUSTITUCION DE COTIZACION A REMISION O FACTURA Y DE VENTA NORMAL
            If oSisAdministracionClientes.TIENE_CREDITO_SUFICIENTE = "0" And (Me.cboTipoNegociacion.Text = "CREDITO" Or Me.oDocumento.AFECTA_CXC = False) Then 'Si fuera cotización también avisará si no tiene crédito suficiente
                MsgBox("La venta que intenta realizar supera el límite de crédito del cliente. No es posible realizar este movimiento.", MsgBoxStyle.Exclamation, Me.Text)
                Return False
            End If
            '    End If
            'End If

            Return True
        Catch ex As Exception
            HandleError(Me.Name, "ValidarReglasCreditoplazo", ex)
        End Try
    End Function

    'Private Function ValidarDatosCliente() As Boolean
    '    Try
    '        If txtLEN(Me.oCliente.NOMBRE_CLIENTE) = False Or Me.oCliente.NOMBRE_CLIENTE = "." Then
    '            MsgBox("El dato ''Nombre'' del cliente no esta capturado.", MsgBoxStyle.Exclamation, Me.Text)
    '            Me.TxtCliente.Focus()
    '            Exit Function
    '        ElseIf txtLEN(Me.oCliente.RFC) = False Or Me.oCliente.RFC = "." Then
    '            MsgBox("El dato ''RFC'' del cliente no esta capturado.", MsgBoxStyle.Exclamation, Me.Text)
    '            Me.TxtCliente.Focus()
    '            Exit Function
    '        ElseIf txtLEN(Me.oCliente.CALLE) = False Or Me.oCliente.CALLE = "." Then
    '            MsgBox("El dato ''Calle'' del cliente no esta capturado.", MsgBoxStyle.Exclamation, Me.Text)
    '            Me.TxtCliente.Focus()
    '            Exit Function
    '        ElseIf txtLEN(Me.oCliente.NUMERO_EXTERIOR) = False Or Me.oCliente.NUMERO_EXTERIOR = "." Then
    '            MsgBox("El dato ''Número exterior'' del cliente no esta capturado.", MsgBoxStyle.Exclamation, Me.Text)
    '            Me.TxtCliente.Focus()
    '            Exit Function
    '        ElseIf txtLEN(Me.oCliente.CIUDAD) = False Or Me.oCliente.CIUDAD = "." Then
    '            MsgBox("El dato ''Municipio'' del cliente no esta capturado.", MsgBoxStyle.Exclamation, Me.Text)
    '            Me.TxtCliente.Focus()
    '            Exit Function
    '        ElseIf txtLEN(Me.oCliente.ESTADO) = False Or Me.oCliente.ESTADO = "." Then
    '            MsgBox("El dato ''Estado'' del cliente no esta capturado.", MsgBoxStyle.Exclamation, Me.Text)
    '            Me.TxtCliente.Focus()
    '            Exit Function
    '        ElseIf txtLEN(Me.oCliente.PAIS) = False Or Me.oCliente.PAIS = "." Then
    '            MsgBox("El dato ''País'' del cliente no esta capturado.", MsgBoxStyle.Exclamation, Me.Text)
    '            Me.TxtCliente.Focus()
    '            Exit Function
    '        ElseIf txtLEN(Me.oCliente.CODIGO_POSTAL) = False Or Me.oCliente.CODIGO_POSTAL = "." Then
    '            MsgBox("El dato ''Código postal'' del cliente no esta capturado.", MsgBoxStyle.Exclamation, Me.Text)
    '            Me.TxtCliente.Focus()
    '            Exit Function
    '        End If

    '        Return True

    '    Catch ex As Exception
    '        HandleError(Me.Name, "ValidarDatosCliente", ex)
    '    End Try
    'End Function

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
            If Me.oDocumento.NATURALEZA_INVENTARIOS = "EN" Then
                Return True
            End If

            For iRow = 1 To Me.Grid.Rows - 1
                dr = dt.NewRow()
                dr("CODIGO_ARTICULO") = Me.Grid.Cell(iRow, Me.igyCodigo).Text
                dr("DESCRIPCION") = Me.Grid.Cell(iRow, Me.igyDescripcion).Text
                dr("CANTIDAD") = valorNumerico(Me.Grid.Cell(iRow, Me.igyCantidad).Text)
                dt.Rows.Add(dr)
            Next

            For i = 1 To Me.Grid.Rows - 1
                If Len(Me.Grid.Cell(i, Me.igyCodigo).Text) > 0 Then
                    '"Si no" es una venta normal o es sustitución y es un artículo directo(adicional agregado manualmente que no proviene de la remisión)
                    If Not ((Me.sTipoVenta <> "SR") Or (Me.sTipoVenta = "SR" AndAlso valorNumericoD(Me.Grid.Cell(i, Me.igyIdOrigen).Text) = 0)) Then
                        Continue For 'Se salta este artículo.
                    End If
                    dExistencia = oInventarios.Existencia(Me.Grid.Cell(i, Me.igyCodigo).Text, Me.CboAlmacen.SelectedValue.ToString)
                    oArticulos = New Class_CatArticulos(Me.Grid.Cell(i, Me.igyCodigo).Text)
                    If oArticulos.INVENTARIABLE = "1" Then
                        If txtLEN(oArticulos.CODIGO_CULTIVO) = False Then
                            If dExistencia <= 0 Then
                                MsgBox("El artículo " & Me.Grid.Cell(i, Me.igyDescripcion).Text & " no tiene existencia. ", MsgBoxStyle.Exclamation, sProcedure)
                                Return False
                            Else
                                dCantidadSumadaPorArticulos = valorNumerico(dt.Compute("sum(CANTIDAD)", "CODIGO_ARTICULO='" & Me.Grid.Cell(i, Me.igyCodigo).Text & "'").ToString)

                                If valorNumerico(dCantidadSumadaPorArticulos.ToString) > valorNumerico(dExistencia.ToString) Then
                                    MsgBox("El artículo " & Me.Grid.Cell(i, Me.igyDescripcion).Text & " no tiene suficiente existencia." & vbCrLf &
                                           "Hay " & dExistencia.ToString & " de existencia en el almacén " & Me.CboAlmacen.Text, MsgBoxStyle.Exclamation, sProcedure)
                                    Return False
                                End If
                            End If
                        End If
                    End If
                End If
            Next i
            If Me.sTipoVenta <> "SR" Then 'Sólo si es una venta normal va revisar que haya series disponibles, si fuera sustitución se deben validar disponibes vs remisión(otro proceso que no es este)

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
            End If

            Return True
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Function

    Private Function ValidarDisponible() As Boolean
        Const sProcedure As String = "ValidarDisponible"
        Dim i As Integer, dDisponible As Decimal = 0
        Try
            For i = 1 To Me.Grid.Rows - 1
                If txtLEN(Me.Grid.Cell(i, Me.igyCodigo).Text) = True AndAlso valorNumericoD(Me.Grid.Cell(i, Me.igyIdOrigen).Text) > 0 Then
                    dDisponible = Me.oVenta.ObtenerDisponibleRenglon(CInt(Me.Grid.Cell(i, Me.igyIdOrigen).Text))
                    If valorNumericoD(Me.Grid.Cell(i, Me.igyCantidad).Text) > dDisponible Then
                        MsgBox("La cantidad del renglón #" & i.ToString & " es mayor al disponible que es de " & dDisponible.ToString, MsgBoxStyle.Exclamation, sProcedure)
                        Me.Grid.Cell(i, Me.igyCantidad).Text = "0"
                        Me.Totales()
                        Me.Grid.Refresh()
                        Me.Grid.Cell(i, Me.igyDescripcion).SetFocus()
                        Return False
                    End If
                End If
            Next
            Return True
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Function

    Private Function SiTieneCantidad() As Boolean
        Dim i As Integer
        Try
            For i = 1 To Me.Grid.Rows - 1
                If txtLEN(Me.Grid.Cell(i, Me.igyCodigo).Text) = True AndAlso Me.Grid.Cell(i, Me.igyCodigo).Text <> "-" Then
                    If valorNumerico(Me.Grid.Cell(i, Me.igyCantidad).Text) = 0 Then
                        Return False
                    End If
                End If
            Next
            Return True
        Catch ex As Exception
            HandleError(Me.Name, "SiTieneCantidad", ex)
        End Try
    End Function

    Private Function SiTieneProductosKG() As Boolean
        Dim i As Integer
        Try
            For i = 1 To Me.Grid.Rows - 1
                If txtLEN(Me.Grid.Cell(i, Me.igyCodigo).Text) = True Then
                    Dim oArticulo As New Class_CatArticulos
                    oArticulo = New Class_CatArticulos(Me.Grid.Cell(i, Me.igyCodigo).Text)
                    If oArticulo.ES_PRODUCTO_KILOS = "1" Then
                        If valorNumerico(Me.Grid.Cell(i, Me.igyCantidadKilos).Text) = 0 Then
                            Return False
                        End If
                        If valorNumerico(Me.Grid.Cell(i, Me.igyPrecioKilos).Text) = 0 Then
                            Return False
                        End If
                    End If
                End If
            Next

            Return True
        Catch ex As Exception
            HandleError(Me.Name, "SiTieneProductosKG", ex)
        End Try
    End Function

    Private Function SiTieneRenglones() As Boolean
        Try
            Dim i As Integer
            For i = 1 To Me.Grid.Rows - 1
                If txtLEN(Me.Grid.Cell(i, Me.igyCodigo).Text) = True Then
                    Return True
                End If
            Next
            Return False
        Catch ex As Exception
            HandleError(Me.Name, "SiTieneRenglones", ex)
        End Try
    End Function

    Private Function SiTieneImporte() As Boolean
        Try
            Dim i As Integer
            For i = 1 To Me.Grid.Rows - 1
                If txtLEN(Me.Grid.Cell(i, Me.igyCodigo).Text) = True AndAlso Me.Grid.Cell(i, Me.igyCodigo).Text <> "-" Then
                    If valorNumerico(Me.Grid.Cell(i, Me.igyImporte).Text) = 0 Then
                        Return False
                    End If
                End If
            Next
            Return True
        Catch ex As Exception
            HandleError(Me.Name, "SiTieneImporte", ex)
        End Try
    End Function

    Private Function SiTieneCuentaContable() As Boolean
        Try
            Dim i As Integer
            For i = 1 To Me.Grid.Rows - 1
                If txtLEN(Me.Grid.Cell(i, Me.igyCodigo).Text) = True AndAlso Me.Grid.Cell(i, Me.igyCodigo).Text <> "-" Then
                    If txtLEN(Me.Grid.Cell(i, Me.igyCuentaContable).Text) = False Then
                        Return False
                    End If
                End If
            Next
            Return True
        Catch ex As Exception
            HandleError(Me.Name, "SiTieneCuentaContable", ex)
        End Try
    End Function

    Private Function SiTieneIVA() As Boolean
        Dim bPrimerIVAEncontrado As Boolean ', bHayArticulos As Boolean = False
        'Dim oArticulos As Class_CatArticulos

        Dim i As Integer

        Try
            'For i = 1 To Me.Grid.Rows - 1
            '    If txtLEN(Me.Grid.Cell(i, Me.igyCodigo).Text) = True Then
            '        If txtLEN(Me.Grid.Cell(i, Me.igyCuentaContable).Text) = False Then
            '            SiTieneIVA = False
            '            Exit Function
            '        End If
            '    End If
            'Next

            For i = 1 To Me.Grid.Rows - 1
                If valorNumerico(Me.Grid.Cell(i, Me.igyImpuestoPorcentaje).Text) > 0 Then
                    If bPrimerIVAEncontrado = False Then
                        Me.dPorcentajeIVAGlobal = valorNumerico(Me.Grid.Cell(i, Me.igyImpuestoPorcentaje).Text)
                        bPrimerIVAEncontrado = True
                    Else
                        If dPorcentajeIVAGlobal <> valorNumerico(Me.Grid.Cell(i, Me.igyImpuestoPorcentaje).Text) Then
                            MsgBox("No se pueden tener diferentes porcentajes de IVA.", MsgBoxStyle.Exclamation, "SiTieneIVA")
                            Exit Function
                        End If
                    End If
                End If
            Next

            Return True

        Catch ex As Exception
            HandleError(Me.Name, "SiTieneIVA", ex)
        End Try
    End Function

    Private Function ValidaCuentaContable() As Boolean
        Try
            Dim i As Integer
            Me.oCuentas = New Class_CatCuentas

            For i = 1 To Me.Grid.Rows - 1
                If txtLEN(Me.Grid.Cell(i, Me.igyCodigo).Text) = True AndAlso Me.Grid.Cell(i, Me.igyCodigo).Text <> "-" Then
                    If Me.oCuentas.isCuentaContableValida(Me.Grid.Cell(i, Me.igyCuentaContable).Text.ToString) = False Then
                        Return False
                    End If
                End If
            Next

            Return True
        Catch ex As Exception
            HandleError(Me.Name, "ValidaCuentaContable", ex)
        End Try
    End Function

    Private Function ValidarCentrosCostos() As Boolean
        Const sProcedure As String = "ValidarCentrosCostos"
        Try
            Dim i As Integer
            With Me.Grid
                For i = 1 To .Rows - 1
                    If txtLEN(.Cell(i, Me.igyCodigo).Text) = True AndAlso Me.Grid.Cell(i, Me.igyCodigo).Text <> "-" Then
                        'If txtLEN(.Cell(i, Me.igyNombreCentroCosto).Text) = False Then
                        '    MsgBox("Asígne el centro de costos del renglón: " & i & " .", MsgBoxStyle.Exclamation, sProcedure)
                        '    Return False
                        'End If
                        If txtLEN(.Cell(i, Me.igyCodigoCentroCosto).Text) = False Then 'AsignarCentrosCostos se volvera a ejecutar al dar clic en grabar nuevamente
                            MsgBox("El renglón: " & i & " no tiene centro de costo, vuelva a dar click en Grabar.", MsgBoxStyle.Exclamation, sProcedure)
                            Return False
                        End If
                    End If
                Next
            End With
            Return True
        Catch ex As Exception
            HandleError(Me.Name, "ValidarCentrosCostos", ex)
        End Try
    End Function

    Private Function AsignaCentrosCostos() As Boolean
        Dim bResultado As Boolean = False
        Try
            Dim i As Integer
            Dim oVendedor As New Class_CatVendedores
            oVendedor.CODIGO_VENDEDOR = CInt(Me.cboVendedor.SelectedValue)

            If oVendedor.Consultar = False Then
                MsgBox("No se pudo recuperar el código de centro de costo del vendedor.", MsgBoxStyle.Exclamation, Me.Text)
                Return bResultado
            End If

            With Me.Grid
                For i = 1 To .Rows - 1
                    If txtLEN(.Cell(i, Me.igyCodigo).Text) = True AndAlso Me.Grid.Cell(i, Me.igyCodigo).Text <> "-" Then
                        .Cell(i, igyCodigoCentroCosto).Text = oVendedor.CODIGO_CENTRO_COSTO.ToString
                    End If
                Next
            End With

            bResultado = True
        Catch ex As Exception
            HandleError(Me.Name, "AsignaCentrosCostos", ex)
        End Try
        Return bResultado
    End Function

    Private Sub DesplegarDocumentos()
        Try
            With Me.CboDocumento
                .DisplayMember = "NOMBRE_TIPO_DOCUMENTO"
                .ValueMember = "CODIGO_DOCUMENTO"
                Dim dView As New Data.DataView(Me.oDocumento.ObtenerCodigosDocumentos(Me.oVenta.CODIGO_MODULO, Usuario.Codigo_Plaza.ToString, " ESTATUS_DOCUMENTO='A'"))
                dView.Sort = "ORDEN ASC"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedIndex = 0
                    'Me.bDocumentosCargados = True
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

    Private Sub DesplegarVendedores()
        Try
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
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarVendedores", ex)
        End Try
    End Sub

    Private Sub DesplegarTiposNegociaciones()
        Try
            Dim oElementos As New Class_CatTiposNegociaciones
            With Me.cboTipoNegociacion
                .DisplayMember = "NOMBRE_TIPO_NEGOCIACION"
                .ValueMember = "CODIGO_TIPO_NEGOCIACION"
                Dim dView As New Data.DataView(oElementos.ObtenerElementos)
                dView.Sort = "NOMBRE_TIPO_NEGOCIACION"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedValue = 1 '1=CREDITO
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarTiposNegociaciones", ex)
        End Try
    End Sub

    Private Sub DesplegarTiposCredito()
        Try
            Dim oElementos As New Class_CatTiposCreditos
            With Me.CboTipoCredito
                .DisplayMember = "NOMBRE_TIPO_CREDITO"
                .ValueMember = "CODIGO_TIPO_CREDITO"
                Dim dView As New Data.DataView(oElementos.ObtenerElementos)
                dView.Sort = "CODIGO_TIPO_CREDITO"
                .DataSource = dView
                .SelectedIndex = 0
            End With

        Catch ex As Exception
            HandleError(Me.Name, "DesplegarTiposCreditos", ex)
        End Try
    End Sub

    Private Sub DesplegarTiposMercados()
        Try
            Dim oElementos As New Class_TiposMercados
            With Me.cboTipoMercado
                .DisplayMember = "NOMBRE_TIPO_MERCADO"
                .ValueMember = "CODIGO_TIPO_MERCADO"
                Dim dView As New Data.DataView(oElementos.ObtenerElementos)
                dView.Sort = "NOMBRE_TIPO_MERCADO"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedIndex = 1
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarTiposMercados", ex)
        End Try
    End Sub

    Private Sub Totales()
        Const sProcedure As String = "Totales"
        Try
            Dim oArticulo As New Class_CatArticulos
            Dim i As Integer, dCantidad As Decimal, dPorcentajeIVA As Decimal, iIDOrigen As Integer = 0, dIEPS_PORCENTAJE As Decimal = 0, dTipoCambio As Decimal = 0

            Dim dtSubtotal As Decimal = 0, dtIEPS As Decimal = 0, dtImpuesto As Decimal = 0, dtTotal As Decimal = 0, dtDescuentos As Decimal = 0
            Dim sID_SIS_CAT_IMPUESTOS As String = "", sGRADO_TOXICIDAD As String = "0" '0=NO GRAVA IEPS
            'Dim sID_SIS_CAT_IMPUESTOS_FLETES As String = "", dPorcentajeFlete As Decimal

            Dim dPrecioCapturado As Decimal, dPrecioOriginal As Decimal, dImporte As Decimal, dImporteSustitucion As Decimal, dImporteTotal As Decimal = 0
            Dim dPrecioConDescuento As Decimal, dImporteConDescuento As Decimal, dDESCUENTO_UNITARIO As Decimal, dDESCUENTO_IMPORTE As Decimal
            Dim dIEPS_UNITARIO As Decimal = 0, dIEPS_IMPORTE As Decimal = 0, dBASE_IEPS As Decimal = 0, dBASE_IVA As Decimal = 0, dPRECIO_TOTAL As Decimal = 0, dIVA_IMPORTE As Decimal = 0
            'Dim dFLETE_IMPORTE As Decimal = 0, dtFLETE As Decimal = 0
            Dim dRETENCION_IVA_BASE As Decimal = 0, dRETENCION_IVA_PORCENTAJE As Decimal = 0, dRETENCION_IVA_IMPORTE As Decimal = 0, bRETENCION_IVA_TIENE As Boolean = False, dtRetencionIVA As Decimal = 0
            Dim dRETENCION_ISR_BASE As Decimal = 0, dRETENCION_ISR_PORCENTAJE As Decimal = 0, dRETENCION_ISR_IMPORTE As Decimal = 0, bRETENCION_ISR_TIENE As Boolean = False, dtRetencionISR As Decimal = 0

            Dim dPrecioCapturado_USD As Decimal = 0, dImporte_USD As Decimal, dImporteTotal_USD As Decimal = 0
            Dim dPrecioConDescuento_USD As Decimal = 0, dImporteConDescuento_USD As Decimal = 0, dDESCUENTO_UNITARIO_USD As Decimal = 0, dDESCUENTO_IMPORTE_USD As Decimal = 0
            Dim dIEPS_UNITARIO_USD As Decimal = 0, dIEPS_IMPORTE_USD As Decimal = 0, dBASE_IEPS_USD As Decimal = 0, dBASE_IVA_USD As Decimal = 0, dPRECIO_TOTAL_USD As Decimal = 0, dIVA_IMPORTE_USD As Decimal = 0
            'Dim dFLETE_IMPORTE_USD As Decimal = 0, dtFLETE_USD As Decimal = 0
            Dim dRETENCION_IVA_BASE_USD As Decimal = 0, dRETENCION_IVA_IMPORTE_USD As Decimal = 0, dtRetencionIVA_USD As Decimal = 0
            Dim dRETENCION_ISR_BASE_USD As Decimal = 0, dRETENCION_ISR_IMPORTE_USD As Decimal = 0, dtRetencionISR_USD As Decimal = 0

            Dim dtSubtotal_USD As Decimal = 0, dtIEPS_USD As Decimal = 0, dtImpuesto_USD As Decimal = 0, dtTotal_USD As Decimal = 0, dtDescuentos_USD As Decimal = 0

            dTipoCambio = valorNumericoD(Me.txtTipoCambio.Text)
            dTipoCambio = RedondearD(dTipoCambio, 4)
            Me.txtTipoCambio.Text = Format(dTipoCambio, "##0.0000")

            Me.lblSubtotal.Text = FormatImporteContable(0)
            Me.lblIEPSIncluido.Text = FormatImporteContable(0)
            Me.lblIEPS.Text = FormatImporteContable(0)
            Me.lblImpuesto.Text = FormatImporteContable(0)
            Me.lblTotalRetencionIVA.Text = FormatImporteContable(0)
            Me.lblTotalRetencionISR.Text = FormatImporteContable(0)
            Me.lblTotal.Text = FormatImporteContable(0)

            Me.lblSubtotal_USD.Text = FormatImporteContable(0)
            Me.lblIEPSIncluido_USD.Text = FormatImporteContable(0)
            Me.lblIEPS_USD.Text = FormatImporteContable(0)
            Me.lblImpuesto_USD.Text = FormatImporteContable(0)
            Me.lblTotalRetencionIVA_USD.Text = FormatImporteContable(0)
            Me.lblTotalRetencionISR_USD.Text = FormatImporteContable(0)
            Me.lblTotal_USD.Text = FormatImporteContable(0)

            dTotalSustitucion = 0

            For i = 1 To Me.Grid.Rows - 1
                If txtLEN(Me.Grid.Cell(i, Me.igyCodigo).Text) = False Then
                    Continue For
                End If

                oArticulo = New Class_CatArticulos(Me.Grid.Cell(i, Me.igyCodigo).Text)

                If txtLEN(Me.Grid.Cell(i, Me.igyCantidad).Text) = False Then
                    Continue For
                End If

                dCantidad = 0 : dPrecioCapturado = 0 : dPrecioConDescuento = 0 : iIDOrigen = 0 : dPorcentajeIVA = 0 : dIEPS_PORCENTAJE = 0 : sID_SIS_CAT_IMPUESTOS = "" : sGRADO_TOXICIDAD = "" : dImporteConDescuento = 0
                dBASE_IEPS = 0 : dIEPS_IMPORTE = 0 : dIEPS_UNITARIO = 0 : dBASE_IVA = 0 : dIVA_IMPORTE = 0 : dPRECIO_TOTAL = 0 : dPrecioOriginal = 0 : dImporte = 0 : dImporteTotal = 0 : dImporteSustitucion = 0
                dDESCUENTO_UNITARIO = 0 : dDESCUENTO_IMPORTE = 0
                dPrecioCapturado_USD = 0
                'dFLETE_IMPORTE = 0 : sID_SIS_CAT_IMPUESTOS_FLETES = "" : dPorcentajeFlete = 0
                dRETENCION_IVA_BASE = 0 : dRETENCION_IVA_PORCENTAJE = 0 : dRETENCION_IVA_IMPORTE = 0 : bRETENCION_IVA_TIENE = False
                dRETENCION_ISR_BASE = 0 : dRETENCION_ISR_PORCENTAJE = 0 : dRETENCION_ISR_IMPORTE = 0 : bRETENCION_ISR_TIENE = False
                dRETENCION_IVA_BASE_USD = 0 : dRETENCION_IVA_IMPORTE_USD = 0 : dtRetencionIVA_USD = 0
                dRETENCION_ISR_BASE_USD = 0 : dRETENCION_ISR_IMPORTE_USD = 0 : dtRetencionISR_USD = 0

                dCantidad = valorNumericoD(Me.Grid.Cell(i, Me.igyCantidad).Text)
                dPrecioCapturado = valorNumericoD(Me.Grid.Cell(i, Me.igyPrecio).Text)
                iIDOrigen = CInt(valorNumericoD(Me.Grid.Cell(i, Me.igyIdOrigen).Text))
                dPorcentajeIVA = valorNumericoD(Me.Grid.Cell(i, Me.igyImpuestoPorcentaje).Text)
                dIEPS_PORCENTAJE = valorNumericoD(Me.Grid.Cell(i, Me.igyIEPS_PORCENTAJE).Text)
                sID_SIS_CAT_IMPUESTOS = Me.Grid.Cell(i, Me.iGyID_SIS_CAT_IMPUESTOS).Text
                sGRADO_TOXICIDAD = Me.Grid.Cell(i, Me.iGyGRADO_TOXICIDAD).Text
                dDESCUENTO_UNITARIO = 0 'Se va calcular en base al descuento importe
                dDESCUENTO_IMPORTE = valorNumericoD(Me.Grid.Cell(i, Me.iGyDESCUENTO_IMPORTE).Text)
                'sID_SIS_CAT_IMPUESTOS_FLETES = Me.Grid.Cell(i, Me.iGyIdSisCatImpuestosFlete).Text
                'dPorcentajeFlete = valorNumericoD(Me.Grid.Cell(i, Me.iGyFletePorcentaje).Text)
                bRETENCION_IVA_TIENE = CBool(Me.Grid.Cell(i, Me.iGyRETENCION_IVA_TIENE).Text)
                dRETENCION_IVA_PORCENTAJE = valorNumericoD(Me.Grid.Cell(i, Me.iGyRETENCION_IVA_PORCENTAJE).Text)
                bRETENCION_ISR_TIENE = CBool(Me.Grid.Cell(i, Me.iGyRETENCION_ISR_TIENE).Text)
                dRETENCION_ISR_PORCENTAJE = valorNumericoD(Me.Grid.Cell(i, Me.iGyRETENCION_ISR_PORCENTAJE).Text)

                dPrecioCapturado_USD = valorNumericoD(Me.Grid.Cell(i, Me.igyPrecio_USD).Text)
                dDESCUENTO_UNITARIO_USD = 0 'Se va calcular en base al descuento importe
                dDESCUENTO_IMPORTE_USD = valorNumericoD(Me.Grid.Cell(i, Me.iGyDESCUENTO_IMPORTE_USD).Text)

                '''''''''''''''''''''''''''''''USD
                If Me.cboMoneda.Text = "USD" Then
                    ''''''''''''''''
                    'Calculamos los otros valores en MXN capturables(que si bien no se capturaron se emularán)
                    dPrecioCapturado = dPrecioCapturado_USD * dTipoCambio
                    dPrecioCapturado = RedondearD(dPrecioCapturado, Me.iDecimalesPrecio)

                    dDESCUENTO_IMPORTE = dDESCUENTO_IMPORTE_USD * dTipoCambio
                    dDESCUENTO_IMPORTE = RedondearD(dDESCUENTO_IMPORTE, Empresa_Sistema.DECIMALES_CONTABILIDAD)

                    Me.Grid.Cell(i, Me.igyPrecio).Text = dPrecioCapturado.ToString
                    Me.Grid.Cell(i, Me.iGyDESCUENTO_IMPORTE).Text = dDESCUENTO_IMPORTE.ToString

                    ''''''''''''''''

                    'De ahi en adelante todo el código equivale al código original en MXN que existia antes de capturar precios en USD
                    dImporte_USD = RedondearD((dCantidad * dPrecioCapturado_USD), Empresa_Sistema.DECIMALES_CONTABILIDAD)

                    If dDESCUENTO_IMPORTE_USD > 0 And dDESCUENTO_IMPORTE_USD > dImporte_USD Then
                        MsgBox("El descuento no puede ser mayor que el importe.", vbExclamation, sProcedure)
                        Me.Grid.Cell(i, Me.iGyDESCUENTO_IMPORTE_USD).Text = "0"
                        dDESCUENTO_IMPORTE_USD = 0
                    End If

                    If dCantidad > 0 Then
                        dDESCUENTO_UNITARIO_USD = RedondearD(dDESCUENTO_IMPORTE_USD / dCantidad, 6)
                    End If

                    dPrecioConDescuento_USD = dPrecioCapturado_USD - dDESCUENTO_UNITARIO_USD

                    'dImporteConDescuento_USD = RedondearD((dCantidad * dPrecioConDescuento_USD), 2)
                    dImporteConDescuento_USD = RedondearD((dCantidad * dPrecioConDescuento_USD), 6)

                    If sGRADO_TOXICIDAD <> "0" Then
                        dBASE_IEPS_USD = dImporteConDescuento_USD
                        dIEPS_IMPORTE_USD = RedondearD(dBASE_IEPS_USD * (dIEPS_PORCENTAJE / 100), 2) 'De momento este no se paso a mas decimales, habra que revisar estructura y factibilidad
                        dIEPS_UNITARIO_USD = CDec(Redondear(dPrecioConDescuento_USD * (dIEPS_PORCENTAJE / 100), 4))
                    End If

                    If sID_SIS_CAT_IMPUESTOS <> "N" Then 'N=No grava iva, si es <>N = Si grava iva ya sea al 0,16,Exento(aún siendo exento ó 0 hay que llenar la base iva)
                        dBASE_IVA_USD = dImporteConDescuento_USD + dIEPS_IMPORTE_USD
                        dIVA_IMPORTE_USD = RedondearD(dBASE_IVA_USD * ((dPorcentajeIVA / 100)), 2)
                    End If

                    'If sID_SIS_CAT_IMPUESTOS_FLETES <> "0" Then
                    '    dFLETE_IMPORTE_USD = RedondearD(dBASE_IVA_USD * ((dPorcentajeFlete / 100)), 2)
                    'End If

                    'Solo las personas morales se retienen iva e isr.
                    If Me.oCliente.TIPO_PERSONA = "M" Then
                        If bRETENCION_IVA_TIENE = True Then 'Si tiene retención iva
                            If dPorcentajeIVA = 0 Then
                                MsgBox("No puede llevar retención de IVA si el artículo del renglón #" & i.ToString & " no tiene IVA.", vbExclamation, sProcedure)
                                Me.lblTotal.Text = "0.00"
                                Exit Sub
                            End If
                            dRETENCION_IVA_BASE_USD = dImporteConDescuento_USD
                            dRETENCION_IVA_IMPORTE_USD = RedondearD(dRETENCION_IVA_BASE_USD * dRETENCION_IVA_PORCENTAJE, 2)
                        End If

                        If bRETENCION_ISR_TIENE = True Then 'Si tiene retención isr
                            'Nota no se valida esto porque hay rentas casa habilitación que retienen ISR pero no retienen IVA
                            'If dPorcentajeIVA = 0 Then
                            '    MsgBox("No puede llevar retención de ISR si el artículo del renglón #" & i.ToString & " no tiene IVA.", vbExclamation, sProcedure)
                            '    Me.lblTotal.Text = "0.00"
                            '    Exit Sub
                            'End If
                            dRETENCION_ISR_BASE_USD = dImporteConDescuento_USD
                            dRETENCION_ISR_IMPORTE_USD = RedondearD(dRETENCION_ISR_BASE_USD * dRETENCION_ISR_PORCENTAJE, 2)
                        End If
                    Else 'Es persona física
                        If bRETENCION_IVA_TIENE = True Then 'Si tiene retención iva
                            If dPorcentajeIVA = 0 Then
                                MsgBox("No puede llevar retención de IVA si el artículo del renglón #" & i.ToString & " no tiene IVA.", vbExclamation, sProcedure)
                                Me.lblTotal.Text = "0.00"
                                Exit Sub
                            ElseIf dPorcentajeIVA <> 0.06 Then
                                MsgBox("A las personas fisicas sólo se les puede facturar con iva retenido del 6% y este artículo tiene el " & dRETENCION_IVA_PORCENTAJE * 100.0 & "%", vbExclamation, sProcedure)
                                Me.lblTotal.Text = "0.00"
                                Exit Sub
                            End If
                            dRETENCION_IVA_BASE_USD = dImporteConDescuento_USD
                            dRETENCION_IVA_IMPORTE_USD = RedondearD(dRETENCION_IVA_BASE_USD * dRETENCION_IVA_PORCENTAJE, 2)
                        End If
                    End If

                    dPRECIO_TOTAL_USD = dPrecioCapturado_USD

                    If Me.bClienteEsContribuyenteIEPS = False And dPrecioCapturado_USD > 0 Then 'Cuando no es contribuyente se le adjunta al precio el ieps, es decir se le incluye
                        'dPRECIO_TOTAL_usd = RedondearD(dPrecioCapturado + dIEPS_UNITARIO, 3)
                        dPRECIO_TOTAL_USD = RedondearD(dPrecioCapturado_USD + dIEPS_UNITARIO_USD, 6)
                    End If

                    dImporteTotal_USD = RedondearD((dCantidad * dPRECIO_TOTAL_USD), Empresa_Sistema.DECIMALES_CONTABILIDAD)

                    Me.Grid.Cell(i, Me.igyPRECIO_TOTAL_USD).Text = dPRECIO_TOTAL_USD.ToString
                    Me.Grid.Cell(i, Me.igyIEPS_UNITARIO_USD).Text = dIEPS_UNITARIO_USD.ToString
                    Me.Grid.Cell(i, Me.igyBASE_IEPS_USD).Text = dBASE_IEPS_USD.ToString
                    Me.Grid.Cell(i, Me.igyIEPS_IMPORTE_USD).Text = dIEPS_IMPORTE_USD.ToString
                    Me.Grid.Cell(i, Me.igyBASE_IVA_USD).Text = dBASE_IVA_USD.ToString
                    Me.Grid.Cell(i, Me.igyImpuestoImporte_USD).Text = dIVA_IMPORTE_USD.ToString
                    Me.Grid.Cell(i, Me.iGyDESCUENTO_UNITARIO_USD).Text = dDESCUENTO_UNITARIO_USD.ToString
                    Me.Grid.Cell(i, Me.iGyPRECIO_CON_DESCUENTO_USD).Text = dPrecioConDescuento_USD.ToString
                    Me.Grid.Cell(i, Me.igyImporte_USD).Text = dImporteTotal_USD.ToString
                    'Me.Grid.Cell(i, Me.iGyFleteImporte_USD).Text = dFLETE_IMPORTE_USD.ToString
                    Me.Grid.Cell(i, Me.iGyRETENCION_IVA_BASE_USD).Text = dRETENCION_IVA_BASE_USD.ToString
                    Me.Grid.Cell(i, Me.iGyRETENCION_IVA_IMPORTE_USD).Text = dRETENCION_IVA_IMPORTE_USD.ToString
                    Me.Grid.Cell(i, Me.iGyRETENCION_ISR_BASE_USD).Text = dRETENCION_ISR_BASE_USD.ToString
                    Me.Grid.Cell(i, Me.iGyRETENCION_ISR_IMPORTE_USD).Text = dRETENCION_ISR_IMPORTE_USD.ToString

                    ''''''''''''''''''''''''''''''MXN(Este cálculo se hace en para calcular los valores en MXN a partir de los USD,note que también en moneda en MXN direco hace el cálculo-parecido)
                    'Redondeando a la misma cifra que si hubiera sido en MXN directo
                    dImporte = RedondearD(dImporte_USD * dTipoCambio, Empresa_Sistema.DECIMALES_CONTABILIDAD)

                    If dDESCUENTO_IMPORTE > 0 And dDESCUENTO_IMPORTE > dImporte Then
                        MsgBox("El descuento no puede ser mayor que el importe.", vbExclamation, sProcedure)
                        Me.Grid.Cell(i, Me.iGyDESCUENTO_IMPORTE).Text = "0"
                        dDESCUENTO_IMPORTE = 0
                    End If

                    If dCantidad > 0 Then
                        dDESCUENTO_UNITARIO = RedondearD(dDESCUENTO_UNITARIO_USD * dTipoCambio, 6)
                    End If

                    dPrecioConDescuento = dPrecioCapturado - dDESCUENTO_UNITARIO

                    dImporteConDescuento = RedondearD((dImporteConDescuento_USD * dTipoCambio), 6)

                    If sGRADO_TOXICIDAD <> "0" Then
                        dBASE_IEPS = RedondearD(dBASE_IEPS_USD * dTipoCambio, 6)
                        dIEPS_IMPORTE = RedondearD(dIEPS_IMPORTE_USD * dTipoCambio, 2) 'De momento este no se paso a mas decimales, habra que revisar estructura y factibilidad
                        dIEPS_UNITARIO = CDec(Redondear(dIEPS_UNITARIO_USD * dTipoCambio, 4))
                    End If

                    If sID_SIS_CAT_IMPUESTOS <> "N" Then 'N=No grava iva, si es <>N = Si grava iva ya sea al 0,16,Exento(aún siendo exento ó 0 hay que llenar la base iva)
                        dBASE_IVA = RedondearD(dBASE_IVA_USD * dTipoCambio, 6)
                        dIVA_IMPORTE = RedondearD(dIVA_IMPORTE_USD * dTipoCambio, 2)
                    End If

                    'If sID_SIS_CAT_IMPUESTOS_FLETES <> "0" Then
                    '    dFLETE_IMPORTE = RedondearD(dFLETE_IMPORTE_USD * dTipoCambio, 2)
                    'End If

                    'Solo las personas morales se retienen iva e isr.
                    If Me.oCliente.TIPO_PERSONA = "M" Then
                        If bRETENCION_IVA_TIENE = True Then 'Si tiene retención iva
                            If dPorcentajeIVA = 0 Then
                                MsgBox("No puede llevar retención de IVA si el artículo del renglón #" & i.ToString & " no tiene IVA.", vbExclamation, sProcedure)
                                Me.lblTotal.Text = "0.00"
                                Exit Sub
                            End If
                            dRETENCION_IVA_BASE = RedondearD(dRETENCION_IVA_BASE_USD * dTipoCambio, 6)
                            dRETENCION_IVA_IMPORTE = RedondearD(dRETENCION_IVA_IMPORTE_USD * dTipoCambio, 2)
                        End If

                        If bRETENCION_ISR_TIENE = True Then 'Si tiene retención isr
                            'Nota no se valida esto porque hay rentas casa habilitación que retienen ISR pero no retienen IVA
                            'If dPorcentajeIVA = 0 Then
                            '    MsgBox("No puede llevar retención de ISR si el artículo del renglón #" & i.ToString & " no tiene IVA.", vbExclamation, sProcedure)
                            '    Me.lblTotal.Text = "0.00"
                            '    Exit Sub
                            'End If
                            dRETENCION_ISR_BASE = RedondearD(dRETENCION_ISR_BASE_USD * dTipoCambio, 6)
                            dRETENCION_ISR_IMPORTE = RedondearD(dRETENCION_ISR_IMPORTE_USD * dTipoCambio, 2)
                        End If
                    Else 'Es persona física
                        'Note que ya no valida el 6% porque ya lo hizo mas arriba en la sección de dólares.
                        If bRETENCION_IVA_TIENE = True Then 'Si tiene retención iva
                            If dPorcentajeIVA = 0 Then
                                MsgBox("No puede llevar retención de IVA si el artículo del renglón #" & i.ToString & " no tiene IVA.", vbExclamation, sProcedure)
                                Me.lblTotal.Text = "0.00"
                                Exit Sub
                            End If
                            dRETENCION_IVA_BASE = RedondearD(dRETENCION_IVA_BASE_USD * dTipoCambio, 6)
                            dRETENCION_IVA_IMPORTE = RedondearD(dRETENCION_IVA_IMPORTE_USD * dTipoCambio, 2)
                        End If
                    End If

                    dPRECIO_TOTAL = dPrecioCapturado

                    If Me.bClienteEsContribuyenteIEPS = False And dPrecioCapturado > 0 Then 'Cuando no es contribuyente se le adjunta al precio el ieps, es decir se le incluye
                        dPRECIO_TOTAL = RedondearD(dPRECIO_TOTAL_USD * dTipoCambio, 6)
                    End If

                    'dImporteTotal = RedondearD((dCantidad * dPRECIO_TOTAL), Empresa_Sistema.DECIMALES_CONTABILIDAD)
                    dImporteTotal = RedondearD(dImporteTotal_USD * dTipoCambio, Empresa_Sistema.DECIMALES_CONTABILIDAD)

                Else '''''''''''''''''''''''''''MXN

                    dImporte = RedondearD((dCantidad * dPrecioCapturado), Empresa_Sistema.DECIMALES_CONTABILIDAD)

                    If dDESCUENTO_IMPORTE > 0 And dDESCUENTO_IMPORTE > dImporte Then
                        MsgBox("El descuento no puede ser mayor que el importe.", vbExclamation, sProcedure)
                        Me.Grid.Cell(i, Me.iGyDESCUENTO_IMPORTE).Text = "0"
                        dDESCUENTO_IMPORTE = 0
                    End If

                    If dCantidad > 0 Then
                        dDESCUENTO_UNITARIO = RedondearD(dDESCUENTO_IMPORTE / dCantidad, 6)
                    End If

                    dPrecioConDescuento = dPrecioCapturado - dDESCUENTO_UNITARIO

                    'dImporteConDescuento = RedondearD((dCantidad * dPrecioConDescuento), 2)
                    'dImporteConDescuento = RedondearD((dCantidad * dPrecioConDescuento), 6)
                    dImporteConDescuento = RedondearD((dCantidad * dPrecioConDescuento), 6)

                    If sGRADO_TOXICIDAD <> "0" Then
                        dBASE_IEPS = dImporteConDescuento
                        dIEPS_IMPORTE = RedondearD(dBASE_IEPS * (dIEPS_PORCENTAJE / 100), 2) 'De momento este no se paso a mas decimales, habra que revisar estructura y factibilidad
                        dIEPS_UNITARIO = CDec(Redondear(dPrecioConDescuento * (dIEPS_PORCENTAJE / 100), 4))
                    End If

                    If sID_SIS_CAT_IMPUESTOS <> "N" Then 'N=No grava iva, si es <>N = Si grava iva ya sea al 0,16,Exento(aún siendo exento ó 0 hay que llenar la base iva)
                        dBASE_IVA = dImporteConDescuento + dIEPS_IMPORTE
                        dIVA_IMPORTE = RedondearD(dBASE_IVA * ((dPorcentajeIVA / 100)), 2)
                    End If

                    'If sID_SIS_CAT_IMPUESTOS_FLETES <> "0" Then
                    ' dFLETE_IMPORTE = RedondearD(dBASE_IVA * ((dPorcentajeFlete / 100)), 2)
                    'End If

                    'Solo las personas morales se retienen iva e isr.
                    If Me.oCliente.TIPO_PERSONA = "M" Then
                        If bRETENCION_IVA_TIENE = True Then 'Si tiene retención iva
                            If dPorcentajeIVA = 0 Then
                                MsgBox("No puede llevar retención de IVA si el artículo del renglón #" & i.ToString & " no tiene IVA.", vbExclamation, sProcedure)
                                Me.lblTotal.Text = "0.00"
                                Exit Sub
                            End If
                            dRETENCION_IVA_BASE = dImporteConDescuento
                            dRETENCION_IVA_IMPORTE = RedondearD(dRETENCION_IVA_BASE * dRETENCION_IVA_PORCENTAJE, 2)
                        End If

                        If bRETENCION_ISR_TIENE = True Then 'Si tiene retención isr
                            'Nota no se valida esto porque hay rentas casa habilitación que retienen ISR pero no retienen IVA
                            'If dPorcentajeIVA = 0 Then
                            '    MsgBox("No puede llevar retención de ISR si el artículo del renglón #" & i.ToString & " no tiene IVA.", vbExclamation, sProcedure)
                            '    Me.lblTotal.Text = "0.00"
                            '    Exit Sub
                            'End If
                            dRETENCION_ISR_BASE = dImporteConDescuento
                            dRETENCION_ISR_IMPORTE = RedondearD(dRETENCION_ISR_BASE * dRETENCION_ISR_PORCENTAJE, 2)
                        End If
                    Else 'Es persona física
                        If bRETENCION_IVA_TIENE = True Then 'Si tiene retención iva
                            If dPorcentajeIVA = 0 Then
                                MsgBox("No puede llevar retención de IVA si el artículo del renglón #" & i.ToString & " no tiene IVA.", vbExclamation, sProcedure)
                                Me.lblTotal.Text = "0.00"
                                Exit Sub
                            ElseIf dRETENCION_IVA_PORCENTAJE <> 0.06 Then
                                MsgBox("A las personas fisicas sólo se les puede facturar con iva retenido del 6% y este artículo tiene el " & dRETENCION_IVA_PORCENTAJE * 100.0 & "%", vbExclamation, sProcedure)
                                Me.lblTotal.Text = "0.00"
                                Exit Sub
                            End If

                            dRETENCION_IVA_BASE = dImporteConDescuento
                            dRETENCION_IVA_IMPORTE = RedondearD(dRETENCION_IVA_BASE * dRETENCION_IVA_PORCENTAJE, 2)
                        End If
                    End If

                    dPRECIO_TOTAL = dPrecioCapturado

                    If Me.bClienteEsContribuyenteIEPS = False And dPrecioCapturado > 0 Then 'Cuando no es contribuyente se le adjunta al precio el ieps, es decir se le incluye
                        'dPRECIO_TOTAL = RedondearD(dPrecioCapturado + dIEPS_UNITARIO, 3)
                        dPRECIO_TOTAL = RedondearD(dPrecioCapturado + dIEPS_UNITARIO, 6)
                    End If

                    dImporteTotal = RedondearD((dCantidad * dPRECIO_TOTAL), Empresa_Sistema.DECIMALES_CONTABILIDAD)
                End If

                Me.Grid.Cell(i, Me.igyPRECIO_TOTAL).Text = dPRECIO_TOTAL.ToString
                Me.Grid.Cell(i, Me.igyIEPS_UNITARIO).Text = dIEPS_UNITARIO.ToString
                Me.Grid.Cell(i, Me.igyBASE_IEPS).Text = dBASE_IEPS.ToString
                Me.Grid.Cell(i, Me.igyIEPS_IMPORTE).Text = dIEPS_IMPORTE.ToString
                Me.Grid.Cell(i, Me.igyBASE_IVA).Text = dBASE_IVA.ToString
                Me.Grid.Cell(i, Me.igyImpuestoImporte).Text = dIVA_IMPORTE.ToString
                Me.Grid.Cell(i, Me.iGyDESCUENTO_UNITARIO).Text = dDESCUENTO_UNITARIO.ToString
                Me.Grid.Cell(i, Me.iGyPRECIO_CON_DESCUENTO).Text = dPrecioConDescuento.ToString
                Me.Grid.Cell(i, Me.igyImporte).Text = dImporteTotal.ToString
                'Me.Grid.Cell(i, Me.iGyFleteImporte).Text = dFLETE_IMPORTE.ToString
                Me.Grid.Cell(i, Me.iGyRETENCION_IVA_BASE).Text = dRETENCION_IVA_BASE.ToString
                Me.Grid.Cell(i, Me.iGyRETENCION_IVA_IMPORTE).Text = dRETENCION_IVA_IMPORTE.ToString
                Me.Grid.Cell(i, Me.iGyRETENCION_ISR_BASE).Text = dRETENCION_ISR_BASE.ToString
                Me.Grid.Cell(i, Me.iGyRETENCION_ISR_IMPORTE).Text = dRETENCION_ISR_IMPORTE.ToString

                'NOTA: Ahora todo lo relacionad a una sustitución, se genera y graba dentro del stored MP_VENTA_AFECTA_SUSTITUCION_REMISION
                'If Me.LblEstatus.Text <> "N" AndAlso sTipoVenta <> "NM" Then
                '    dPrecioOriginal = CDec(Me.oVenta.ObtenerPrecioOriginal(iIDOrigen))
                'Else
                '    dPrecioOriginal = 0 'dPrecio
                'End If
                'dImporteSustitucion = RedondearD((dPrecioOriginal * dCantidad), Empresa_Sistema.DECIMALES_CONTABILIDAD)
                'dImporteSustitucion = valorNumericoD(RedondearD(dImporteSustitucion * ((dPorcentajeIVA / 100) + 1), Empresa_Sistema.DECIMALES_CONTABILIDAD).ToString)
                'dTotalSustitucion = dTotalSustitucion + dImporteSustitucion

            Next i
            If Me.oDocumento.CODIGO_TIPO_DOCUMENTO = "FT" Then 'Factura de traslado
                Return 'No hay nada que calcular todos los totales serán en 0 aunque si haya importes(el sat si lo permite así en las facturas de traslado)
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''''''''''''''''''''TOTALES USD
            dtIEPS_USD = RedondearD(CDec(FG_Grid_SumaCol(Me.Grid, Me.igyIEPS_IMPORTE_USD)), Empresa_Sistema.DECIMALES_CONTABILIDAD)

            If Me.bClienteEsContribuyenteIEPS = True Then
                Me.lblIEPSIncluido_USD.Text = FormatImporteContable(0)
                Me.lblIEPS_USD.Text = FormatImporteContable(dtIEPS_USD)
            Else
                Me.lblIEPSIncluido_USD.Text = FormatImporteContable(dtIEPS_USD)
                Me.lblIEPS_USD.Text = FormatImporteContable(0)
                dtIEPS_USD = 0 'Se establece en 0 porque luego se le suma este valor al total y al ser includo entonces debe ser 0
            End If

            dtSubtotal_USD = RedondearD(CDec(FG_Grid_SumaCol(Me.Grid, Me.igyImporte_USD)), Empresa_Sistema.DECIMALES_CONTABILIDAD)
            dtDescuentos_USD = RedondearD(CDec(FG_Grid_SumaCol(Me.Grid, Me.iGyDESCUENTO_IMPORTE_USD)), Empresa_Sistema.DECIMALES_CONTABILIDAD)
            dtImpuesto_USD = RedondearD(CDec(FG_Grid_SumaCol(Me.Grid, Me.igyImpuestoImporte_USD)), Empresa_Sistema.DECIMALES_CONTABILIDAD)
            'dtFLETE_USD = RedondearD(CDec(FG_Grid_SumaCol(Me.Grid, Me.iGyFleteImporte_USD)), Empresa_Sistema.DECIMALES_CONTABILIDAD)
            dtRetencionIVA_USD = RedondearD(CDec(FG_Grid_SumaCol(Me.Grid, Me.iGyRETENCION_IVA_IMPORTE_USD)), Empresa_Sistema.DECIMALES_CONTABILIDAD)
            dtRetencionISR_USD = RedondearD(CDec(FG_Grid_SumaCol(Me.Grid, Me.iGyRETENCION_ISR_IMPORTE_USD)), Empresa_Sistema.DECIMALES_CONTABILIDAD)
            'dtTotal_USD = dtSubtotal_USD - dtDescuentos_USD + dtIEPS_USD + dtImpuesto_USD - dtFLETE_USD
            dtTotal_USD = dtSubtotal_USD - dtDescuentos_USD + dtIEPS_USD + dtImpuesto_USD - dtRetencionIVA_USD - dtRetencionISR_USD

            Me.lblSubtotal_USD.Text = FormatImporteContable(dtSubtotal_USD)
            Me.lblDescuento_USD.Text = FormatImporteContable(dtDescuentos_USD)
            Me.lblImpuesto_USD.Text = FormatImporteContable(dtImpuesto_USD)
            'Me.lblTotalRetencionIVA_USD.Text = FormatImporteContable(dtFLETE_USD)
            Me.lblTotalRetencionIVA_USD.Text = FormatImporteContable(dtRetencionIVA_USD)
            Me.lblTotalRetencionISR_USD.Text = FormatImporteContable(dtRetencionISR_USD)
            Me.lblTotal_USD.Text = FormatImporteContable(dtTotal_USD)


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''''''''''''''''''''TOTALES MXN
            dtIEPS = RedondearD(CDec(FG_Grid_SumaCol(Me.Grid, Me.igyIEPS_IMPORTE)), Empresa_Sistema.DECIMALES_CONTABILIDAD)

            If Me.bClienteEsContribuyenteIEPS = True Then
                Me.lblIEPSIncluido.Text = FormatImporteContable(0)
                Me.lblIEPS.Text = FormatImporteContable(dtIEPS)
            Else
                Me.lblIEPSIncluido.Text = FormatImporteContable(dtIEPS)
                Me.lblIEPS.Text = FormatImporteContable(0)
                dtIEPS = 0 'Se establece en 0 porque luego se le suma este valor al total y al ser includo entonces debe ser 0
            End If

            dtSubtotal = RedondearD(CDec(FG_Grid_SumaCol(Me.Grid, Me.igyImporte)), Empresa_Sistema.DECIMALES_CONTABILIDAD)
            dtDescuentos = RedondearD(CDec(FG_Grid_SumaCol(Me.Grid, Me.iGyDESCUENTO_IMPORTE)), Empresa_Sistema.DECIMALES_CONTABILIDAD)
            dtImpuesto = RedondearD(CDec(FG_Grid_SumaCol(Me.Grid, Me.igyImpuestoImporte)), Empresa_Sistema.DECIMALES_CONTABILIDAD)
            'dtFLETE = RedondearD(CDec(FG_Grid_SumaCol(Me.Grid, Me.iGyFleteImporte)), Empresa_Sistema.DECIMALES_CONTABILIDAD)
            dtRetencionIVA = RedondearD(CDec(FG_Grid_SumaCol(Me.Grid, Me.iGyRETENCION_IVA_IMPORTE)), Empresa_Sistema.DECIMALES_CONTABILIDAD)
            dtRetencionISR = RedondearD(CDec(FG_Grid_SumaCol(Me.Grid, Me.iGyRETENCION_ISR_IMPORTE)), Empresa_Sistema.DECIMALES_CONTABILIDAD)
            'dtTotal = dtSubtotal - dtDescuentos + dtIEPS + dtImpuesto - dtFLETE
            dtTotal = dtSubtotal - dtDescuentos + dtIEPS + dtImpuesto - dtRetencionIVA - dtRetencionISR

            Me.lblSubtotal.Text = FormatImporteContable(dtSubtotal)
            Me.lblDescuento.Text = FormatImporteContable(dtDescuentos)
            Me.lblImpuesto.Text = FormatImporteContable(dtImpuesto)
            'Me.lblTotalRetencionIVA.Text = FormatImporteContable(dtFLETE)
            Me.lblTotalRetencionIVA.Text = FormatImporteContable(dtRetencionIVA)
            Me.lblTotalRetencionISR.Text = FormatImporteContable(dtRetencionISR)
            Me.lblTotal.Text = FormatImporteContable(dtTotal)

            '20Sep19, al desarrollar para teclar precios en usd se quitó de momento la funcionalidad de embarques, que de querer usarse necesitará revisión
            'If dTipoCambio > 0 Then
            '    Me.lblSubtotal_USD.Text = FormatImporteContable(Redondear(valorNumerico(Me.lblSubtotal.Text) / dTipoCambio, Empresa_Sistema.DECIMALES_CONTABILIDAD))
            '    Me.lblImpuesto_USD.Text = FormatImporteContable(Redondear(valorNumerico(Me.lblImpuesto.Text) / dTipoCambio, Empresa_Sistema.DECIMALES_CONTABILIDAD))

            '    If Not Me._oEmbarqueExtranjero Is Nothing Then
            '        'Es por embarque extranjero, la columna se calculó desde que se obtuvieron los renglones y se debe hacer por siuma directa para no tener diferencias de decimales.
            '        Me.lblTotal_USD.Text = FormatImporteContable(Redondear(FG_Grid_SumaCol(Me.Grid, Me.igyImporte_USD), Empresa_Sistema.DECIMALES_CONTABILIDAD))
            '    Else
            '        Me.lblTotal_USD.Text = FormatImporteContable(Redondear(valorNumerico(Me.lblTotal.Text) / dTipoCambio, Empresa_Sistema.DECIMALES_CONTABILIDAD))
            '    End If
            'End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If dtTotal > 0 Then
                Me.cboMoneda.Enabled = False
                'Me.TxtCliente.Enabled =False 
            End If

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Sub GeneraFolio()
        'If Me.bDocumentosCargados = True Then
        Me.txtFolio.Text = Me.oVenta.GeneraFolioVentas
        'End If
    End Sub

    Private Function Consultar(Optional ByVal bEsReferencia As Boolean = False, Optional ByVal bEsRefrenciaSoloRenglones As Boolean = False) As Boolean
        Const sProcedure As String = "Consultar"
        Dim bResultado As Boolean = False
        Try
            Me.tsbTimbrar.Visible = False
            Me.tsbCancelarTimbre.Visible = False
            Me.tsbRecuperarXMLPDF.Visible = False
            Me.tsbEnviarCorreo.Visible = False
            Me.tsbSubirXML.Visible = False

            Dim sVenta As String = ""

            If sTipoVenta = "NM" And bEsReferencia = True Then
                sVenta = Me.TxtReferencia.Text
            Else
                sVenta = Me.txtFolio.Text
            End If

            Me.Inicializa()
            Dim oVentaLocal As New Class_Ventas_Global(sVenta)

            'Me.oVenta = New Class_Ventas_Global(sVenta)
            Me.oVenta = oVentaLocal

            If Me.oVenta.Existe = False Then
                Me.Cambia_Estado(enumEstados.NUEVO)
                Me.CboDocumento.Enabled = False
                Return False
            End If

            If sTipoVenta = "NM" And bEsReferencia = True And bEsRefrenciaSoloRenglones = True Then
                If Me.oDocumento.AFECTA_CONTABILIDAD = True AndAlso oVentaLocal.CODIGO_TIPO_DOCUMENTO = "REM" Then
                    MsgBox("Advertencia, este mecanismo no SUSTITUYE ó CONVIERTE la remisión en factura, es sólo para obtener su mismo detalle y si va necesitar inventario para facturar.", MsgBoxStyle.Information, sProcedure)
                End If
            End If

            Me.lblVersionCFDI.Text = "" & oVenta.VERSION_ESQUEMA_XML

            Me.DesplegarFormasPago(True) 'Para forzar a que muestre todos incluso los que están dados de baja porque al consultarlos fallaria si no estuvieran.

            If sTipoVenta = "NM" Then
                If bEsRefrenciaSoloRenglones = False Then 'Para que no nos cambie el código
                    Me.CboDocumento.SelectedValue = Me.oVenta.CODIGO_DOCUMENTO
                End If
                Me.oVenta = oVentaLocal 'Se hace de este modo porque si estan en un documento diferente al tecleado al cambiar el combo se inicializa y se pierde la venta cargada
            ElseIf sTipoVenta = "SCR" Then
                Me.CboDocumento.SelectedValue = "REM" + Plaza.CODIGO_PLAZA.ToString
                Me.GeneraFolio()
                Me.oVenta = oVentaLocal
            ElseIf sTipoVenta = "SR" Or sTipoVenta = "SCF" Then
                'Me.CboDocumento.SelectedValue = "FCT" + Plaza.CODIGO_PLAZA.ToString
                Me.CboDocumento.SelectedValue = sCodigoDocumentoFacturaExterno
                Me.oVenta = New Class_Ventas_Global(sVenta)
                'Me.GeneraFolio()'No se ocupa volver a regenerar al cambiar el documento se inicializó y se genero folio
                'Me.dpVencimiento.Value = Me.oVenta.FECHA_VENCIMIENTO
            ElseIf sTipoVenta = "FT" Then
                Me.CboDocumento.SelectedValue = "FT" & Plaza.CODIGO_PLAZA.ToString
                Me.oVenta = New Class_Ventas_Global(sVenta)
            End If

            Me.TxtCliente.Text = Me.oVenta.CODIGO_CLIENTE
            Me.TxtConcepto.Text = Me.oVenta.CONCEPTO
            Me.txtFolioEmbarque.Text = Me.oVenta.FOLIO_EMBARQUE

            Me.oCliente = New Class_CatClientes(Me.TxtCliente.Text)
            Me.lblCliente.Text = Me.oCliente.NOMBRE_CLIENTE
            Me.bClienteEsContribuyenteIEPS = CBool(Me.oCliente.ES_CONTRIBUYENTE_IEPS)

            If bEsReferencia = False Then
                Me.LblPoliza.Text = Me.oVenta.FOLIO_POLIZA
                Me.lblSaldo.Text = FormatImporteContable(Me.oVenta.SALDO)
                Me.lblSaldoDolares.Text = FormatImporteContable(Me.oVenta.SALDO_DOLARES)
            End If

            Me.lblSubtotal.Text = FormatImporteContable(Me.oVenta.SUBTOTAL)
            Me.lblDescuento.Text = FormatImporteContable(Me.oVenta.DESCUENTO)
            Me.lblImpuesto.Text = FormatImporteContable(Me.oVenta.IMPUESTO)
            Me.lblTotal.Text = FormatImporteContable(Me.oVenta.TOTAL)
            Me.lblIEPS.Text = FormatImporteContable(Me.oVenta.IEPS_TOTAL_DESGLOSADO)
            Me.lblIEPSIncluido.Text = FormatImporteContable(Me.oVenta.IEPS_TOTAL_YA_INCLUIDO)
            Me.lblTotalRetencionIVA.Text = FormatImporteContable(Me.oVenta.RETENCION_IVA)
            Me.lblTotalRetencionISR.Text = FormatImporteContable(Me.oVenta.RETENCION_ISR)

            Me.cboMoneda.Text = Me.oVenta.CODIGO_MONEDA_SAT 'Nota debe llenarse primero la moneda porque tiene evento change que llena la forma de pago segun el cte, y asi se consulta correcto.
            Me.txtTipoCambio.Text = Format(Me.oVenta.TIPO_DE_CAMBIO, "##0.0000")

            If Me.oVenta.TIPO_DE_CAMBIO > 0 Then
                'Me.lblSubtotal_USD.Text = FormatImporteContable(Me.oVenta.SUBTOTAL / Me.oVenta.TIPO_DE_CAMBIO).ToString
                'Me.lblImpuesto_USD.Text = FormatImporteContable(Me.oVenta.IMPUESTO / Me.oVenta.TIPO_DE_CAMBIO).ToString
                'Me.lblTotal_USD.Text = FormatImporteContable(Me.oVenta.TOTAL / Me.oVenta.TIPO_DE_CAMBIO).ToString

                Me.lblSubtotal_USD.Text = FormatImporteContable(Me.oVenta.SUBTOTAL_USD)
                Me.lblDescuento_USD.Text = FormatImporteContable(Me.oVenta.DESCUENTO_USD)
                Me.lblImpuesto_USD.Text = FormatImporteContable(Me.oVenta.IMPUESTO_USD)
                Me.lblTotal_USD.Text = FormatImporteContable(Me.oVenta.TOTAL_DOLARES)
                Me.lblIEPS_USD.Text = FormatImporteContable(Me.oVenta.IEPS_TOTAL_DESGLOSADO_USD)
                Me.lblIEPSIncluido_USD.Text = FormatImporteContable(Me.oVenta.IEPS_TOTAL_YA_INCLUIDO_USD)
                Me.lblTotalRetencionIVA_USD.Text = FormatImporteContable(Me.oVenta.RETENCION_IVA_USD)
                Me.lblTotalRetencionISR_USD.Text = FormatImporteContable(Me.oVenta.RETENCION_ISR_USD)
            End If

            Me.cboTipoMercado.SelectedValue = Me.oVenta.CODIGO_TIPO_MERCADO
            Me.cboTipoNegociacion.SelectedValue = Me.oVenta.CODIGO_TIPO_NEGOCIACION
            Me.CboAlmacen.SelectedValue = Me.oVenta.CODIGO_ALMACEN
            Me.cboVendedor.SelectedValue = Me.oVenta.CODIGO_VENDEDOR

            Me.TxtConceptoCancelacion.Text = Me.oVenta.CONCEPTO_CANCELACION

            'AgregaFormaPago99 'Así esta en vb6, pero aquí facilmente se quita el filtro y aparecerá el 99
            dViewFormasPago.RowFilter = ""

            Me.cboFormaPago.SelectedValue = Me.oVenta.CODIGO_METODO_PAGO
            Me.txtNumeroCuentaPago.Text = Me.oVenta.NUMERO_CUENTA_PAGO.ToString

            If txtLEN("" & Me.oVenta.CODIGO_METODO_PAGO_EVENTO) = True Then
                Me.cboMetodoPago.SelectedValue = Me.oVenta.CODIGO_METODO_PAGO_EVENTO
            Else
                Me.cboMetodoPago.SelectedIndex = -1
            End If

            Me.cboRegimenFiscalEmisor.SelectedValue = Me.oVenta.CODIGO_REGIMEN_FISCAL_EMISOR

            If Me.oVenta.ES_VENTA_PUBLICO_GENERAL = "1" Then
                Me.chkVentaPublicoGeneral.Checked = True
            Else
                Me.chkVentaPublicoGeneral.Checked = False
            End If

            If Me.oVenta.CODIGO_TIPO_CREDITO <> "NA" Then
                Me.CboTipoCredito.SelectedValue = Me.oVenta.CODIGO_TIPO_CREDITO
            End If

            If bEsReferencia = False Then
                Me.txtFolio.Text = Me.oVenta.FOLIO_VENTA.ToString.ToUpper
                Me.TxtReferencia.Text = Me.oVenta.FOLIO_REFERENCIA.ToString.ToUpper

                Select Case Me.oVenta.ESTATUS_VENTA.ToString.ToUpper
                    Case "N"
                        Me.LblEstatus.Text = "NUEVO"
                    Case "G"
                        Me.LblEstatus.Text = "GRABADO"
                    Case "A"
                        Me.LblEstatus.Text = "APLICADO"
                    Case "S"
                        Me.LblEstatus.Text = "SUSTITUIDO"
                    Case "C"
                        Me.LblEstatus.Text = "CANCELADO"
                    Case "SY"
                        Me.LblEstatus.Text = "SUSTITUYENDO"
                End Select

                Me.Grid.DataSource = Me.oVenta.ObtenerDetalle(False) 'Que si muestre comentarios
                Me.dpFecha.Value = CDate(Me.oVenta.FECHA)
                Me.txtUUID.Text = Me.oVenta.FOLIO_FISCAL_SAT

                Me.GridSeries.DataSource = Me.oVenta.ObtenerDetalleSeries
                Me.FormateaGridSeries()

                'Me.lblUtilidad.Text = FormatImporteContable(0 - Me.oVenta.COSTO, False)
                Me.CalculaUtilidad()

            Else 'Si se esta jalando una referencia
                Me.TxtReferencia.Text = Me.oVenta.FOLIO_VENTA.ToString.ToUpper
                Me.CboAlmacen.Enabled = False

                'Ante se hacia de este modo pero al ser con datasource no es posible agregar mas comentarios o tener control con algunas cosas
                'Me.Grid.DataSource = Me.oVenta.ObtenerDetalleSoloDisponibles

                If Me.sTipoVenta = "SR" Then
                    Me.InicializaGridFacturasVariasRemisiones()
                    Me.GridFacturasVariasRemisiones.Rows = 1

                    Me.GridFacturasVariasRemisiones.AddItem(oVenta.FOLIO_VENTA & Chr(9) & oVenta.FECHA & Chr(9) & oVenta.TOTAL.ToString & Chr(9) & oVenta.CODIGO_MONEDA_SAT & Chr(9) &
                                           oVenta.CONCEPTO & Chr(9))

                    Me.CargaDetalleRemisionesSeries()

                    GoTo salto 'Esto es porque ahora usamos el mismo mecanismo para cargar series si es una o varias remisiones. Y el código siguiente seria cuando se conviertan cotizaciones a venta(f/r)
                End If

                Dim dTabla As DataTable

                If bEsRefrenciaSoloRenglones = True Then
                    dTabla = Me.oVenta.ObtenerDetalle(False)
                Else
                    dTabla = Me.oVenta.ObtenerDetalleSoloDisponibles
                End If

                Me.InicializaGrid()
                Me.Grid.AutoRedraw = False
                Me.Grid.Rows = 1
                For Each dRow As DataRow In dTabla.Rows
                    Dim sCantidad As String = "", sPRECIO_CON_DESCUENTO As String = "", sPRECIO_CON_DESCUENTO_USD As String = "", sIDOrigen As String = ""
                    If bEsRefrenciaSoloRenglones = True Then
                        sCantidad = dRow("CANTIDAD").ToString
                        sPRECIO_CON_DESCUENTO = dRow("PRECIO_SIN_DESCUENTO").ToString
                        sPRECIO_CON_DESCUENTO_USD = dRow("PRECIO_SIN_DESCUENTO_USD").ToString
                        sIDOrigen = "" 'Al jalar simples renglones nada tiene que ya que ver el IDOrigen así que no se consulta porque además si se trae afecta al crear series porque no crearia series de este renglón
                    Else
                        sCantidad = dRow("DISPONIBLE").ToString
                        sPRECIO_CON_DESCUENTO = dRow("PRECIO").ToString
                        sPRECIO_CON_DESCUENTO_USD = dRow("PRECIO_USD").ToString
                        sIDOrigen = dRow("ID_VENTA_DETALLE").ToString 'Aquí si importa consultar el IDOrigen y se pone ID_VENTA_DETALLE porque ese es el origen que generó este renglón.
                    End If

                    'dCostoUnitario = CDbl(dRow("COSTO").ToString)
                    'If dCostoUnitario <= 0 AndAlso Empresa_Sistema.VENTAS_COSTO_DEFAULT_NO_INVENTARIABLES > 0 Then
                    '    dCostoUnitario = Empresa_Sistema.VENTAS_COSTO_DEFAULT_NO_INVENTARIABLES
                    'End If

                    Me.Grid.AddItem(dRow("CODIGO_ARTICULO").ToString & Chr(9) &
                                    dRow("TIPO_CONTROL_INVENTARIO").ToString & Chr(9) &
                                    dRow("DESCRIPCION").ToString & Chr(9) &
                                    sCantidad & Chr(9) &
                                    dRow("PRECIO_SIN_DESCUENTO").ToString & Chr(9) &
                                    dRow("PRECIO_SIN_DESCUENTO_USD").ToString & Chr(9) &
                                    dRow("PRECIO_TOTAL").ToString & Chr(9) &
                                    dRow("PRECIO_TOTAL_USD").ToString & Chr(9) &
                                    dRow("UNIDAD_VENTA").ToString & Chr(9) &
                                    dRow("CANTIDAD_KILOS").ToString & Chr(9) &
                                    dRow("PRECIO_KILOS").ToString & Chr(9) &
                                    dRow("IMPUESTO_PORCENTAJE").ToString & Chr(9) &
                                    dRow("IMPORTE").ToString & Chr(9) &
                                    dRow("IMPORTE_USD").ToString & Chr(9) &
                                    dRow("IMPORTE_KILOS").ToString & Chr(9) &
                                    dRow("CUENTA_CONTABLE").ToString & Chr(9) &
                                    dRow("IMPUESTO_IMPORTE").ToString & Chr(9) &
                                    dRow("IMPUESTO_IMPORTE_USD").ToString & Chr(9) &
                                    sIDOrigen & Chr(9) &
                                    dRow("ES_PRODUCTO_KILOS").ToString & Chr(9) &
                                    dRow("CODIGO_CENTRO_COSTO").ToString & Chr(9) &
                                    dRow("NOMBRE_CENTRO_COSTO").ToString & Chr(9) &
                                    dRow("IEPS_PORCENTAJE").ToString & Chr(9) &
                                    dRow("IEPS_UNITARIO").ToString & Chr(9) &
                                    dRow("IEPS_UNITARIO_USD").ToString & Chr(9) &
                                    dRow("IEPS_IMPORTE").ToString & Chr(9) &
                                    dRow("IEPS_IMPORTE_USD").ToString & Chr(9) &
                                    dRow("BASE_IEPS").ToString & Chr(9) &
                                    dRow("BASE_IEPS_USD").ToString & Chr(9) &
                                    dRow("BASE_IVA").ToString & Chr(9) &
                                    dRow("BASE_IVA_USD").ToString & Chr(9) &
                                    dRow("COSTO").ToString & Chr(9) &
                                    dRow("UTILIDAD_UNITARIA").ToString & Chr(9) &
                                    dRow("UTILIDAD_TOTAL").ToString & Chr(9) &
                                    dRow("UTILIDAD_PORCENTAJE").ToString & Chr(9) &
                                    dRow("ID_SIS_CAT_IMPUESTOS").ToString & Chr(9) &
                                    dRow("GRADO_TOXICIDAD").ToString & Chr(9) &
                                    dRow("DESCUENTO_UNITARIO").ToString & Chr(9) &
                                    dRow("DESCUENTO_UNITARIO_USD").ToString & Chr(9) &
                                    dRow("DESCUENTO_IMPORTE").ToString & Chr(9) &
                                    dRow("DESCUENTO_IMPORTE_USD").ToString & Chr(9) &
                                    sPRECIO_CON_DESCUENTO & Chr(9) &
                                    sPRECIO_CON_DESCUENTO_USD & Chr(9) &
                                    IIf(valorNumericoD(dRow("RETENCION_IVA_PORCENTAJE").ToString) > 0, "1", "0").ToString & Chr(9) &
                                    dRow("RETENCION_IVA_PORCENTAJE").ToString & Chr(9) &
                                    dRow("RETENCION_IVA_BASE").ToString & Chr(9) &
                                    dRow("RETENCION_IVA_BASE_USD").ToString & Chr(9) &
                                    dRow("RETENCION_IVA_IMPORTE").ToString & Chr(9) &
                                    dRow("RETENCION_IVA_IMPORTE_USD").ToString & Chr(9) &
                                    IIf(valorNumericoD(dRow("RETENCION_ISR_PORCENTAJE").ToString) > 0, "1", "0").ToString & Chr(9) &
                                    dRow("RETENCION_ISR_PORCENTAJE").ToString & Chr(9) &
                                    dRow("RETENCION_ISR_BASE").ToString & Chr(9) &
                                    dRow("RETENCION_ISR_BASE_USD").ToString & Chr(9) &
                                    dRow("RETENCION_ISR_IMPORTE").ToString & Chr(9) &
                                    dRow("RETENCION_ISR_IMPORTE_USD").ToString & Chr(9))

                    'dRow("ID_SIS_CAT_IMPUESTOS_FLETE").ToString & Chr(9) &
                    'dRow("RETENCION_IVA_PORCENTAJE").ToString & Chr(9) &
                    'dRow("RETENCION_IVA_IMPORTE").ToString & Chr(9) &
                    'dRow("RETENCION_IVA_IMPORTE_USD").ToString & Chr(9) &
                Next

                Me.Grid.Rows = Me.Grid.Rows + 1
salto:

                Me.dpFecha.Value = Date.Now

                If bEsRefrenciaSoloRenglones = True Then
                    Me.LblEstatus.Text = "NUEVO"
                Else
                    Me.LblEstatus.Text = "SUSTITUYENDO"
                End If

            End If
            If bEsRefrenciaSoloRenglones = True Then
                Me.EstableceCuentasContables()
            End If

            Me.FormateaGrid()

            If bEsReferencia = True Then 'Si estan jalando un doc en otro, va tratar de gestionar los costos de los no inventariables
                Me.GestionaColumaCostoCapturaNoInventariables() 'Va después de formatear el grid porque se oculta en el la columna costo
            End If

            Me.dpVencimiento.Value = Me.oVenta.FECHA_VENCIMIENTO
            Me.txtPlazo.Text = DateDiff(DateInterval.Day, Me.dpFecha.Value, Me.dpVencimiento.Value.AddDays(1)).ToString

            'Select Case Me.oCliente.TIPO_PERSONA
            '    Case "F"
            '        Me.DesplegarUsoCFDIPersonasFisicas()
            '    Case "M"
            '        Me.DesplegarUsoCFDIPersonasMorales()
            'End Select

            If txtLEN("" & Me.oVenta.CODIGO_USO_CFDI) = True Then
                'Me.cboUsoCFDI.SelectedValue = Me.oVenta.CODIGO_USO_CFDI
                Me.txtUsoCFDI.Text = Me.oVenta.CODIGO_USO_CFDI
                Dim oUsoCFDI As New Class_CFD_CatUsosCFDI(Me.oVenta.CODIGO_USO_CFDI)
                Me.lblUsoCFDI.Text = oUsoCFDI.NOMBRE_USO_CFDI
                oUsoCFDI = Nothing
            End If

            If txtLEN("" & Me.oVenta.CODIGO_REGIMEN_FISCAL_RECEPTOR) = True Then
                Me.txtRegimenFiscalReceptor.Text = Me.oVenta.CODIGO_REGIMEN_FISCAL_RECEPTOR
                Dim oRegimenFiscal As New Class_CFDCatTiposRegimenesFiscales(Me.oVenta.CODIGO_REGIMEN_FISCAL_RECEPTOR)
                Me.lblRegimenFiscalReceptor.Text = oRegimenFiscal.NOMBRE_REGIMEN_FISCAL
                oRegimenFiscal = Nothing
            End If

            If txtLEN("" & Me.oVenta.CODIGO_TIPO_RELACION_CFDI) = True Then
                Me.cboTipoRelacionCFDI.SelectedValue = Me.oVenta.CODIGO_TIPO_RELACION_CFDI

                Me.GridCFDIsRelacionados.DataSource = Me.oVenta.ObtieneFacturasRelacionadas
                Me.FormateaGridCFDIsRelacionados()
            Else
                Me.cboTipoRelacionCFDI.SelectedIndex = -1
            End If
            Me.chkTieneCCE.Checked = Me.oVenta.TIENE_COMPLEMENTO_COMERCIO_EXTERIOR
            Me.chkTieneCartaPorte.Checked = Me.oVenta.TIENE_COMPLEMENTO_CARTA_PORTE

            If Me.chkTieneCCE.Checked = True Then
                Me.cboIncoterm.SelectedValue = Me.oVenta.CODIGO_INCOTERM
            End If

            Me.txtFolio.Enabled = False
            If Me.sTipoVenta = "SR" Then
                'Ya no ejecutamos el código siguiente porque este documento es nuevo
                Me.TxtReferencia.Enabled = False
                Return bResultado
            End If

            'Si es cotizacion si permitira editar
            If Me.oVenta.CODIGO_DOCUMENTO = "CTZ" & Plaza.CODIGO_PLAZA.ToString And Me.oVenta.ESTATUS_VENTA = "G" Then
                Me.Grid.Locked = False
            End If

            If Empresa_Sistema.FELECTRONICA_ACTIVA = True Then
                If oDocumento.TIMBRA_DOCUMENTO = True Then
                    If Me.oVenta.TIMBRADO_CFDI = "0" AndAlso Me.oVenta.TIMBRADO_DESCARTADO = "0" AndAlso Me.oVenta.VERSION_ESQUEMA_XML <> "2.2" Then
                        Me.tsbTimbrar.Visible = True
                    End If
                End If

                '*Nota1:Puede ser que sea una factura recapturada de otro sistema y no es timbrable, pero pudieron haberle subido un xml externo
                If Me.oVenta.TIMBRADO_CFDI = "1" Then
                    Me.tsbRecuperarXMLPDF.Visible = True
                    Me.tsbEnviarCorreo.Visible = True
                End If

                'Sea o no timbrable el documento(recordar que hay facturas recapturas *Nota1) si esta cancelada y timbrada es prospecto para cancelarle el timbre
                If Me.oVenta.ESTATUS_VENTA = "C" AndAlso Me.oVenta.TIMBRADO_CFDI = "1" AndAlso Me.oVenta.TIMBRADO_DESCARTADO = "0" AndAlso Me.oVenta.ESTATUS_CANCELACION_CFDI = "0" Then
                    Me.tsbCancelarTimbre.Visible = True
                    MsgBox("Por favor cancele el timbre de este movimiento que actualmente esta cancelado.", MsgBoxStyle.Exclamation, sProcedure)
                End If
            End If

            'Si es una factura que no timbra(es recapturada de otro sistema)
            If Empresa_Sistema.FELECTRONICA_ACTIVA = True AndAlso oDocumento.TIMBRA_DOCUMENTO = False Then
                If (Me.oDocumento.CODIGO_DOCUMENTO Like "F*") = True Then
                    Me.tsbSubirXML.Visible = True
                End If
            End If

            Me.GridFacturasVariasRemisiones.DataSource = oVenta.ObtenerRelacionFacturasRemisiones(oVenta.FOLIO_VENTA)
            Me.FormateaGridFacturasVariasRemisiones()
            Me.GridFacturasVariasRemisiones.Locked = True

            'ComplementoINE
            Dim sql As New Class_find("SELECT FOLIO_VENTA FROM CFDI_COMPLEMENTO_INE_GLOBAL WHERE FOLIO_VENTA='" & Me.txtFolio.Text & "'")

            If txtLEN(sql.Result1) Then
                Dim oComplementoINEGlobal As New Class_ComplementoINE_Global(sql.Result1)
                Me.CboTipoProceso.SelectedValue = oComplementoINEGlobal.CODIGO_PROCESO
                If oComplementoINEGlobal.CODIGO_COMITE < 1 Then
                    Me.CboTipoComite.SelectedIndex = -1
                Else
                    Me.CboTipoComite.SelectedValue = oComplementoINEGlobal.CODIGO_COMITE
                End If

                Me.TxtIdContabilidad.Text = oComplementoINEGlobal.ID_CONTABILIDAD

                Me.InicializaGridEntidadesINE()
                Me.GridEntidades.DataSource = oComplementoINEGlobal.ObtenerDetalleEntidades
                Me.FormateaGridEntidadesINE()
            End If

            bResultado = True

            Me.GestionaCambioEstado()
            Me.GestionaMoneda()

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        Finally
            Me.Grid.AutoRedraw = True
            Me.Grid.Refresh()
        End Try

        Return bResultado
    End Function

    Private Function EstableceCuentasContables() As Boolean
        Try
            Dim i As Integer

            For i = 1 To Me.Grid.Rows - 1
                Dim oArticulos = New Class_CatArticulos(Me.Grid.Cell(i, Me.igyCodigo).Text)
                If oArticulos.Existe = True Then
                    Me.Grid.Cell(i, Me.igyCuentaContable).Text = Plaza.CUENTA_CONTABLE_VENTAS.ToString
                    'If txtLEN(oArticulos.CODIGO_CULTIVO) = True Then
                    '    'Me.Grid.Cell(I, Me.igyCuentaContable).Text = Plaza.CUENTA_CONTABLE_VENTAS.ToString + Me.cboTipoMercado.SelectedValue.ToString + "00" + oArticulos.CODIGO_CULTIVO.ToString 'En agr esta así, pero aquí la cuenta es general
                    '    Me.Grid.Cell(I, Me.igyCuentaContable).Text = Plaza.CUENTA_CONTABLE_VENTAS.ToString
                    'Else
                    '    Me.Grid.Cell(I, Me.igyCuentaContable).Text = ""
                    'End If
                End If
            Next

            Return True

        Catch ex As Exception
            HandleError(Me.Name, "EstableceCuentasContables", ex)
        End Try
    End Function

    Private Function GestionaColumaCostoCapturaNoInventariables() As Boolean
        Try
            Dim i As Integer, bEncontroNoInventariables As Boolean = False

            Me.Grid.AutoRedraw = False

            'Si el usuario no tiene acceso a ver costos borramos todos los costos de los que no sean no-inventariables(sólo estos podrá ver)
            'If Usuario.VER_COSTOS = False Then
            '    For i = 1 To Me.Grid.Rows - 1
            '        If Me.Grid.Cell(i, Me.igyTipoControlInventariable).Text <> "NIV" Then 'NIV=No inventariables
            '            Me.Grid.Cell(i, Me.igyCosto).Text = ""
            '        End If
            '    Next
            'End If

            'Nota no se puede juntar con el anterior ciclo porque aquél sólo aplica si no se tiene acceso a costos
            For i = 1 To Me.Grid.Rows - 1
                If Me.Grid.Cell(i, Me.igyTipoControlInventariable).Text = "NIV" Then
                    If Empresa_Sistema.VENTAS_COSTO_DEFAULT_NO_INVENTARIABLES > 0 Then
                        If valorNumerico(Me.Grid.Cell(i, Me.igyCosto).Text) <= 0 Then 'Si no tiene costo y la empresa tiene configurado por default se asigna
                            Me.Grid.Cell(i, Me.igyCosto).Text = Empresa_Sistema.VENTAS_COSTO_DEFAULT_NO_INVENTARIABLES.ToString
                        End If
                    End If
                    bEncontroNoInventariables = True
                    Exit For
                End If
            Next

            If bEncontroNoInventariables = True Then
                Me.Grid.Column(Me.igyCosto).Locked = False 'Permite que tecleen el costo
                Me.Grid.Column(Me.igyCosto).Visible = True

                Return True
            Else
                Me.Grid.Column(Me.igyCosto).Locked = True

                If Me.ckbMostrarUtilidad.Checked = False Then 'Solamente si no estaba el check oculta la columna, sino queda como ya estuviera
                    Me.Grid.Column(Me.igyCosto).Visible = False
                End If
            End If

        Catch ex As Exception
            HandleError(Me.Name, "GestionaColumaCostoCapturaNoInventariables", ex)
        Finally
            Me.Grid.AutoRedraw = True : Me.Grid.Refresh()
        End Try
    End Function

    Private Function ValidaValorColumaCostoCapturaNoInventariables() As Boolean
        Try
            Dim i As Integer, bEncontroNoInventariablesSinCosto As Boolean = False

            For i = 1 To Me.Grid.Rows - 1
                If Me.Grid.Cell(i, Me.igyTipoControlInventariable).Text = "NIV" AndAlso valorNumerico(Me.Grid.Cell(i, Me.igyCosto).Text) <= 0 Then
                    MsgBox("Capture por favor el costo del renglón " & i & " ya que es un artículo de servicio.", MsgBoxStyle.Exclamation, Me.Text)
                    bEncontroNoInventariablesSinCosto = True
                    Exit For
                End If
            Next

            If bEncontroNoInventariablesSinCosto = False Then
                Return True
            End If

        Catch ex As Exception
            HandleError(Me.Name, "ValidaValorColumaCostoCapturaNoInventariables", ex)
        End Try
    End Function

    Private Sub GestionaGrid(ByVal e As System.Windows.Forms.KeyEventArgs)
        Const sProcedure As String = "GestionaGrid"
        Try
            Dim Columna As Integer, Renglon As Integer
            Dim StrCod As String, sCuentaContable As String = "", dCantidad As Decimal, dPrecio As Decimal, sCodigoCentroCosto As String, dPrecio_USD As Decimal = 0
            Dim oArticulo As Class_CatArticulos

            'If Me.oDocumento.AFECTA_CXC = True And Me.Grid.Selection.FirstRow = Me.Grid.Rows - 1 Then
            '    Return
            'End If

            If Me.Grid.Row(Me.Grid.Selection.FirstRow).Locked = True Then 'Si esta bloqueado todo el renglón no se permite gestionarlo 
                Return
            End If

            Columna = Me.Grid.Selection.FirstCol
            Renglon = Me.Grid.Selection.FirstRow
            StrCod = Me.Grid.Cell(Renglon, Me.igyCodigo).Text
            dCantidad = valorNumericoD(Me.Grid.Cell(Renglon, Me.igyCantidad).Text)
            dPrecio = valorNumericoD(Me.Grid.Cell(Renglon, Me.igyPrecio).Text)
            dPrecio_USD = valorNumericoD(Me.Grid.Cell(Renglon, Me.igyPrecio_USD).Text)

            'ESTA VALIDACION SE PUSO PARA QUE A LOS PRODUCTOS AGRICOLAS NO LES PUEDAN CAMBIAR LA CUENTA CONTABLE CALCULADA AUTOMATICAMENTE
            If Columna = Me.igyCuentaContable Then
                If Me.oDocumento.AFECTA_CONTABILIDAD = False Then
                    Return
                Else
                    oArticulo = New Class_CatArticulos(StrCod)
                    If txtLEN(oArticulo.CODIGO_CULTIVO) = True Then
                        Return
                    End If
                End If
            End If

            Select Case e.KeyCode
                Case Keys.Enter

                    If StrCod = "-" Then
                        Return
                    End If

                    If Columna <> Me.igyCodigo Then
                        If txtLEN(Me.Grid.Cell(Renglon, Me.igyCodigo).Text) = False Then
                            MsgBox("Debe de asignar primero un artículo", MsgBoxStyle.Exclamation, sProcedure)
                            e.SuppressKeyPress = True
                            Return
                        End If
                    End If

                    Select Case Columna
                        Case Me.igyCodigo

                            If Me.Grid.Column(Me.igyCodigo).Locked = True Then 'Si esta bloqueada la columna código no permite gestionarla
                                Return
                            End If

                            If txtLEN(StrCod) = False Then
                                GoTo BuscaArticulos : Return
                            End If
LlenaLinea:
                            oArticulo = New Class_CatArticulos(StrCod)
                            If oArticulo.Existe = False Then
                                GoTo BuscaArticulos : Return
                            End If

                            If oArticulo.Existe = False Then
                                Me.Totales()
                                Return
                            End If

                            If txtLEN(Me.txtFolioEmbarque.Text) = False Then
                                Dim oPrecio As New tPrecioVenta
                                oPrecio = Me.oVenta.GestionaPrecioVenta(oArticulo.CODIGO_ARTICULO, Me.TxtCliente.Text, Me.CboAlmacen.SelectedValue.ToString)

                                Me.Grid.Cell(Renglon, Me.igyDescripcion).Text = oArticulo.DESCRIPCION
                                Me.Grid.Cell(Renglon, Me.igyTipoControlInventariable).Text = oArticulo.TIPO_CONTROL_INVENTARIO
                                Me.Grid.Cell(Renglon, Me.igyCantidad).Text = "0"
                                Me.Grid.Cell(Renglon, Me.igyPrecio).Text = oPrecio.Precio.ToString
                                Me.Grid.Cell(Renglon, Me.igyCosto).Text = oPrecio.Costo.ToString
                                Me.Grid.Cell(Renglon, Me.igyUnidad).Text = oArticulo.UNIDAD_VENTA
                                Me.Grid.Cell(Renglon, Me.igyIEPS_PORCENTAJE).Text = oArticulo.IEPS_PORCENTAJE.ToString

                                Me.GestionaColumaCostoCapturaNoInventariables()
                            Else
                                Dim oEmbarques As New Class_Embarques_EmbarqueGlobal()
                                oEmbarques.FOLIO_EMBARQUE = Me.txtFolioEmbarque.Text
                                If oEmbarques.Consultar() = False Then
                                    MsgBox("El folio de embarque no existe.", MsgBoxStyle.Exclamation, sProcedure)
                                    Me.txtFolioEmbarque.Text = ""
                                    Me.txtFolioEmbarque.Focus()
                                    Return
                                Else
                                    Me.Grid.Cell(Renglon, Me.igyDescripcion).Text = oArticulo.DESCRIPCION
                                    Me.Grid.Cell(Renglon, Me.igyUnidad).Text = oArticulo.UNIDAD_VENTA
                                End If
                            End If

                            Me.Grid.Cell(Renglon, Me.igyImpuestoPorcentaje).Text = oArticulo.IMPUESTO_PORCENTAJE.ToString
                            Me.Grid.Cell(Renglon, Me.iGyID_SIS_CAT_IMPUESTOS).Text = oArticulo.ID_SIS_CAT_IMPUESTOS
                            Me.Grid.Cell(Renglon, Me.iGyGRADO_TOXICIDAD).Text = oArticulo.GRADO_TOXICIDAD
                            'Me.Grid.Cell(Renglon, Me.iGyIdSisCatImpuestosFlete).Text = oArticulo.ID_SIS_CAT_IMPUESTOS_FLETE.ToString
                            'Me.Grid.Cell(Renglon, Me.iGyFletePorcentaje).Text = oArticulo.IMPUESTO_FLETE_PORCENTAJE.ToString
                            Me.Grid.Cell(Renglon, Me.iGyRETENCION_IVA_TIENE).Text = Convert.ToInt32(oArticulo.RETENCION_IVA_TIENE).ToString
                            Me.Grid.Cell(Renglon, Me.iGyRETENCION_IVA_PORCENTAJE).Text = oArticulo.RETENCION_IVA_PORCENTAJE.ToString
                            Me.Grid.Cell(Renglon, Me.iGyRETENCION_ISR_TIENE).Text = Convert.ToInt32(oArticulo.RETENCION_ISR_TIENE).ToString
                            Me.Grid.Cell(Renglon, Me.iGyRETENCION_ISR_PORCENTAJE).Text = oArticulo.RETENCION_ISR_PORCENTAJE.ToString


                            'If oArticulos.TIENE_IMPUESTO = "1" Then
                            '    Me.Grid.Cell(Renglon, Me.igyImpuestoPorcentaje).Text = Plaza.Impuesto_Porcentaje.ToString
                            'Else
                            '    Me.Grid.Cell(Renglon, Me.igyImpuestoPorcentaje).Text = "0"
                            'End If

                            If oArticulo.CODIGO_CULTIVO <> "" Then
                                Me.Grid.Cell(Renglon, Me.igyImpuestoImporte).Locked = True
                            Else
                                Me.Grid.Cell(Renglon, Me.igyImpuestoImporte).Locked = False
                            End If

                            If Me.oDocumento.AFECTA_CONTABILIDAD = True Then
                                'If txtLEN(oArticulos.CODIGO_CULTIVO) = True Then
                                'Dim Sql As New Class_find("SELECT CUENTA_CONTABLE_BASE FROM CAT_CULTIVOS Where CODIGO_CULTIVO='" & oArticulos.CODIGO_CULTIVO.ToString & "' AND CODIGO_PLAZA=" & Usuario.Codigo_Plaza)

                                'Me.Grid.Cell(Renglon, Me.igyCuentaContable).Text = Plaza.CUENTA_CONTABLE_VENTAS.ToString + Me.cboTipoMercado.SelectedValue.ToString + Sql.Result1 'En agr esta así, pero aquí la cuenta es general
                                Me.Grid.Cell(Renglon, Me.igyCuentaContable).Text = Plaza.CUENTA_CONTABLE_VENTAS.ToString
                                'Else
                                ' Me.Grid.Cell(Renglon, Me.igyCuentaContable).Text = ""
                                'End If
                            End If

                            If e.KeyCode = Keys.F6 Then
                                If valorNumericoD(Me.Grid.Cell(Renglon, Me.igyCantidad).Text) = 0 Then
                                    Me.Grid.Cell(Renglon, Me.igyCantidad).Text = ""
                                End If
                                Me.Grid.Cell(Renglon, Me.igyCantidad).SetFocus()  'Para que se vaya a igyPrecio_USD ponemos una celda anterior
                            Else 'Es por el enter
                                Me.Grid.Cell(Renglon, Me.igyDescripcion).SetFocus()  'Para que se vaya a igyPrecio_USD ponemos una celda anterior
                            End If

                            Me.Grid.Column(Me.igyDescripcion).Locked = True

                            Me.Totales()

                        Case Me.igyCantidad
                            If dCantidad <= 0 Then
                                MsgBox("La cantidad debe de ser mayor a 0.", MsgBoxStyle.Exclamation, sProcedure)
                                Me.Grid.Cell(Renglon, Me.igyDescripcion).SetFocus()
                                Return
                            End If

                            oArticulo = New Class_CatArticulos(StrCod)

                            If Me.sTipoVenta <> "NM" Then
                                If Me.ValidarDisponible() = False Then
                                    Return
                                End If
                            End If

                            If Me.oDocumento.AFECTA_INVENTARIOS = True Then 'And sTipoVenta <> "SR" Then
                                If Me.ValidarExistencias() = False Then
                                    Return
                                End If
                            End If
                            If Me.sTipoVenta = "SR" Then
                                Me.GestionaSeriesPosicion(Renglon, False)
                            End If

                            If Me.oDocumento.AFECTA_CXC = True Then
                                'If Me.oCompras.ValidaCantidadDisponibleArticulo(CInt(Me.Grid.Cell(Renglon, Me.igyIdOrigen).Text), dCantidad) = False Then
                                '    MsgBox("La cantidad debe de ser menor al disponible.", MsgBoxStyle.Exclamation, Me.Text)
                                '    Me.Grid.Cell(Renglon, Me.igyCantidad).Text = Me.oCompras.ObtenerDisponibleArticulo(CInt(Me.Grid.Cell(Renglon, Me.igyIdOrigen).Text)).ToString
                                '    Me.Grid.Refresh()
                                '    Return
                                'End If
                            End If

                            If Me.cboMoneda.Text = "USD" Then
                                Me.Grid.Cell(Renglon, Me.igyPrecio).SetFocus() 'Para que se vaya a igyPrecio_USD ponemos una celda anterior
                            End If

                        Case Me.igyPrecio
                            oArticulo = New Class_CatArticulos(StrCod)
                            If Me.cboMoneda.Text = "USD" Then
                                'Avanza de todas formas estará bloqueado                                    
                            Else
                                If dPrecio <= 0 Then
                                    MsgBox("El precio debe de ser mayor a 0.", MsgBoxStyle.Exclamation, sProcedure)
                                    Me.Grid.Cell(Renglon, Me.igyCantidad).SetFocus() 'Para que se vaya a igyPrecio ponemos una celda anterior
                                End If
                            End If

                        Case Me.igyPrecio_USD
                            oArticulo = New Class_CatArticulos(StrCod)
                            If dPrecio_USD <= 0 Then
                                MsgBox("El precio debe de ser mayor a 0.", MsgBoxStyle.Exclamation, sProcedure)
                                Me.Grid.Cell(Renglon, Me.igyPrecio).SetFocus() 'Para que se vaya a igyPrecio_USD ponemos una celda anterior
                            End If

                        Case Me.igyImpuestoPorcentaje
                            'Case Me.igyCuentaContable
                            '    'Dim oCuentas As New Class_CatCuentas(Me.Grid.Cell(Renglon, Me.igyCuentaContable).Text)

                            '    'If oCuentas._Existe = False Then
                            '    '    Me.Grid.Cell(Renglon, Me.igyCuentaContable).Text = ""
                            '    '    GoTo BuscarCuentas : Return
                            '    'End If
                            '    ''Me.Grid.Cell(Renglon + 1, Me.igyImporte).SetFocus()

                            '    If txtLEN(Me.Grid.Cell(Renglon, Me.igyCuentaContable).Text) = False Then
                            '        GoTo BuscarCuentas

                            '        Return
                            '    End If

                        Case Me.igyNombreCentroCosto
                            If txtLEN(Me.Grid.Cell(Renglon, Me.igyCodigoCentroCosto).Text) = False Then
                                GoTo buscaCentrosCostos

                                Return
                            End If
                            'Me.oCentroCostos = New Class_CatCentroCostos()

                            If Me.Grid.Rows - 1 = Renglon Then
                                Me.Grid.Rows = Me.Grid.Rows + 1
                            End If

                        Case Me.iGyDESCUENTO_IMPORTE
                            If Me.Grid.Column(Me.iGyDESCUENTO_IMPORTE).Locked = True Then
                                Exit Select
                            End If

                            Dim dDESCUENTO_IMPORTE As Decimal = valorNumericoD(Me.Grid.Cell(Renglon, Me.iGyDESCUENTO_IMPORTE).Text)
                            Dim dImporte As Decimal = RedondearD(dCantidad * dPrecio, 2)

                            If dDESCUENTO_IMPORTE < 0 Then
                                MsgBox("El descuento debe ser una cantidad positiva.", vbExclamation, sProcedure)
                                Me.Grid.Cell(Renglon, Me.iGyDESCUENTO_IMPORTE).Text = "0"
                            End If

                            If dDESCUENTO_IMPORTE > dImporte Then
                                MsgBox("El descuento no puede ser mayor que el importe.", vbExclamation, sProcedure)
                                Me.Grid.Cell(Renglon, Me.iGyDESCUENTO_IMPORTE).Text = "0"
                            End If

                        Case Me.iGyDESCUENTO_IMPORTE_USD
                            If Me.Grid.Column(Me.iGyDESCUENTO_IMPORTE_USD).Locked = True Then
                                Exit Select
                            End If

                            Dim dDESCUENTO_IMPORTE_USD As Decimal = valorNumericoD(Me.Grid.Cell(Renglon, Me.iGyDESCUENTO_IMPORTE_USD).Text)
                            Dim dImporte_USD As Decimal = RedondearD(dCantidad * dPrecio_USD, 2)

                            If dDESCUENTO_IMPORTE_USD < 0 Then
                                MsgBox("El descuento debe ser una cantidad positiva.", vbExclamation, sProcedure)
                                Me.Grid.Cell(Renglon, Me.iGyDESCUENTO_IMPORTE_USD).Text = "0"
                            End If

                            If dDESCUENTO_IMPORTE_USD > dImporte_USD Then
                                MsgBox("El descuento no puede ser mayor que el importe.", vbExclamation, sProcedure)
                                Me.Grid.Cell(Renglon, Me.iGyDESCUENTO_IMPORTE_USD).Text = "0"
                            End If

                    End Select

                    Select Case Columna
                        Case Me.igyCantidad
                            If Me.Grid.Rows = Renglon + 1 Then Me.Grid.Rows = Me.Grid.Rows + 1
                            'Case Else
                            '    If Me.Grid.Rows = Renglon + 1 Then Me.Grid.Rows = Me.Grid.Rows + 1
                    End Select

                    Me.Totales()
                    Me.CalculaUtilidad()

                Case Keys.F6
BuscaArticulos:
                    Select Case Columna
                        Case Me.igyCodigo 'Columna del Codigo de Articulo

                            If Me.Grid.Column(Me.igyCodigo).Locked = True Then 'Si esta bloqueada la columna código no permite gestionarla
                                Return
                            End If
                            If Me.sTipoVenta = "SR" Then
                                If valorNumericoD(Me.Grid.Cell(Renglon, Me.igyIdOrigen).Text) > 0 Then
                                    MsgBox("No es valido usar F6 en un renglón que proviene de una remisión.", MsgBoxStyle.Exclamation, sProcedure)
                                    Return
                                End If
                            End If

                            oArticulo = New Class_CatArticulos

                            If Me.oDocumento.AFECTA_INVENTARIOS = True Then
                                StrCod = oArticulo.BusquedaVisual_PorDescripcion_conExistencias(Me.CboAlmacen.SelectedValue.ToString, True)
                            Else
                                'StrCod = oArticulo.BusquedaVisual_PorDescripcion()'jorge quito, no encontr razón de porqué no mostrar existencias,y (aunque no tengan)
                                StrCod = oArticulo.BusquedaVisual_PorDescripcion_conExistencias(Me.CboAlmacen.SelectedValue.ToString, False)
                            End If

                            If txtLEN(StrCod) = True Then
                                Me.Grid.Cell(Renglon, Me.igyCodigo).Text = StrCod
                                GoTo LlenaLinea : Return
                            End If

                            '                        Case Me.igyCuentaContable 'Columna de la cuenta contable
                            'BuscarCuentas:
                            '                            sCuentaContable = Me.oCuentas.BusquedaVisual_PorCodigoFiltrandoTipoOperacion(, "4")
                            '                            If sCuentaContable = "" Then
                            '                                Return
                            '                            End If
                            '                            Me.Grid.Cell(Renglon, Me.igyCuentaContable).Text = sCuentaContable

                        Case Me.igyNombreCentroCosto
buscaCentrosCostos:
                            sCodigoCentroCosto = Me.oCentroCostos.BusquedaVisual_PorDescripcion()
                            If sCodigoCentroCosto = "" Then
                                Return
                            End If
                            oCentroCostos = New Class_CatCentroCostos(CInt(sCodigoCentroCosto))
                            Me.Grid.Cell(Renglon, Me.igyCodigoCentroCosto).Text = sCodigoCentroCosto
                            Me.Grid.Cell(Renglon, Me.igyNombreCentroCosto).Text = oCentroCostos.NOMBRE_CENTRO_COSTO
                    End Select

                    If Me.Grid.Rows = Renglon + 1 Then Me.Grid.Rows = Me.Grid.Rows + 1

                    'Case Keys.F7
                    '    sCuentaContable = Me.oCuentas.BusquedaVisual_PorNombreFiltrandoTipoOperacion()
                    '    If sCuentaContable = "" Then
                    '        Me.Grid.Cell(Renglon, Me.igyCuentaContable).Text = ""
                    '        Me.Grid.Refresh()
                    '        Return
                    '    End If
                    '    Me.Grid.Cell(Renglon, Me.igyCuentaContable).Text = sCuentaContable

                Case Keys.F7
                    Select Case Columna
                        Case Me.igyCodigo

                            If Me.Grid.Column(Me.igyCodigo).Locked = True Then 'Si esta bloqueada la columna código no permite gestionarla
                                Return
                            End If

                            oArticulo = New Class_CatArticulos
                            StrCod = oArticulo.BusquedaVisual_PorCodigo_conExistencias(Me.CboAlmacen.SelectedValue.ToString)
                            If txtLEN(StrCod) = True Then
                                Me.Grid.Cell(Renglon, Me.igyCodigo).Text = StrCod
                                GoTo LlenaLinea : Return
                            End If

                    End Select

                Case Keys.F9
                    If Columna = Me.igyCodigo Then
                        If Me.Grid.Column(Me.igyCodigo).Locked = True Then 'Si esta bloqueada la columna código no permite gestionarla
                            Return
                        End If

                        oArticulo = New Class_CatArticulos
                        StrCod = oArticulo.BusquedaVisual_PorDescripcion_conExistencias(Me.CboAlmacen.SelectedValue.ToString, False)
                        If txtLEN(StrCod) = True Then
                            Me.Grid.Cell(Renglon, Me.igyCodigo).Text = StrCod
                            GoTo LlenaLinea : Return
                        End If
                    End If

                Case Keys.F11
                    Select Case Columna
                        Case Me.igyCodigo

                            If Me.Grid.Column(Me.igyCodigo).Locked = True Then 'Si esta bloqueada la columna código no permite gestionarla
                                Return
                            End If

                            oArticulo = New Class_CatArticulos
                            StrCod = oArticulo.BusquedaVisualInventariablesConExistencia_PorDescripcion(Me.CboAlmacen.SelectedValue.ToString, True)
                            If txtLEN(StrCod) = True Then
                                Me.Grid.Cell(Renglon, Me.igyCodigo).Text = StrCod
                                GoTo LlenaLinea : Return
                            End If
                    End Select

                Case Keys.F8, Keys.Delete  'Borrar renglón
                    If (Me.Estado = enumEstados.NUEVO Or Me.Estado = enumEstados.GRABADO Or Me.Estado = enumEstados.SUSTITUYENDO) Then
                        Me.GestionaSeriesPosicion(Renglon, True) 'Elimina todas las series en caso de ser un artículo seriado
                        Me.Grid.Selection.DeleteByRow()
                        Me.Totales()
                    End If

                    'Case Keys.Delete 'Borrar renglón
                    'Return

                Case Keys.F4 'Comentarios

                    Dim oComentario As New Ventas_Comentarios
                    If StrCod = "-" Then 'Si el código anterior era comentario mostramos el mismo comentario para editarlo, si es un producto lo dejamos en blanco
                        oComentario.txtComentario.Text = Me.Grid.Cell(Renglon, Me.igyDescripcion).Text
                    End If
                    oComentario.ShowDialog()

                    If oComentario.Aceptar = True Then
                        Me.Grid.Cell(Renglon, Me.igyCodigo).Text = "-"
                        Me.Grid.Cell(Renglon, Me.igyDescripcion).Text = oComentario.txtComentario.Text

                        If Me.Grid.Rows = Renglon + 1 Then Me.Grid.Rows = Me.Grid.Rows + 1
                        'Me.Grid.Cell(Renglon + 1, Me.igyCodigo).SetFocus()

                        For i = Me.igyDescripcion + 1 To Me.Grid.Cols - 1
                            Me.Grid.Cell(Renglon, i).Locked = True 'Bloqueamos el resto de las columnas
                            Me.Grid.Cell(Renglon, i).Text = "" 'Eliminamos los datos del resto de las columnas
                        Next

                        Me.Grid.Cell(Renglon, Me.iGyGRADO_TOXICIDAD).Text = "0"
                        Me.Grid.Cell(Renglon, Me.iGyID_SIS_CAT_IMPUESTOS).Text = "0"

                    End If

                    Me.Totales() 'Por si a un renglón que ya tiene un artículo(con importe) le dan f4
                    oComentario.Dispose()

                Case Keys.F5 'Lista de precios
                    If txtLEN(StrCod) = False Then
                        Return
                    End If
                    Dim oPrecio As New VentasSeleccionPrecio(StrCod, Me.CboAlmacen.SelectedValue.ToString)
                    oPrecio.ShowDialog()
                    Me.Grid.Cell(Renglon, Me.igyPrecio).Text = oPrecio.PrecioSeleccionado.ToString
                    oPrecio.Dispose()
                    Me.Totales()
            End Select

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Sub NavegadorFacturas(ByVal sTipoDeBusqueda As String)
        Try
            Dim iFolio As Integer, sFolio As String
            If txtLEN(Me.txtFolio.Text) = False Then
                Me.txtFolio.Text = Me.oVenta.GeneraFolioVentas
            End If

            If sTipoDeBusqueda = "Anterior" Then
                sFolio = Me.txtFolio.Text.Substring(0, Me.txtFolio.Text.IndexOf("-"))
                iFolio = CInt(Strings.Right(Me.txtFolio.Text, Len(Me.txtFolio.Text) - (Len(sFolio) + 1))) ' Me.oVenta.FOLIO_NUMERICO
                iFolio = iFolio - 1
                sFolio = sFolio + "-" + iFolio.ToString

                Me.txtFolio.Text = sFolio

                If iFolio > 0 Then
                    Me.Consultar()
                Else
                    Me.Inicializa()
                    Me.Cambia_Estado(enumEstados.NUEVO)
                End If

            ElseIf sTipoDeBusqueda = "Siguiente" Then
                sFolio = Me.txtFolio.Text.Substring(0, Me.txtFolio.Text.IndexOf("-"))
                iFolio = CInt(Strings.Right(Me.txtFolio.Text, Len(Me.txtFolio.Text) - (Len(sFolio) + 1)))
                iFolio = iFolio + 1
                sFolio = sFolio + "-" + iFolio.ToString

                Me.txtFolio.Text = sFolio

                If iFolio > 0 Then
                    Me.Consultar()
                End If
            End If
        Catch ex As Exception
            HandleError(Me.Name, "NavegadorFacturas", ex)
        End Try
    End Sub

    Private Sub EnviarCorreo()
        Try
            Me.tsbEnviarCorreo.Enabled = False
            Me.tsbEnviarCorreo.Text = "Enviando..."
            Application.DoEvents()
            Me.oVenta.EnviarCorreo()
        Catch ex As Exception
            HandleError(Me.Name, "EnviarCorreo", ex)
        Finally
            Me.tsbEnviarCorreo.Text = "&Enviar correo"
            Me.tsbEnviarCorreo.Enabled = True
        End Try
        Application.DoEvents()
    End Sub

    Private Function ConsultarCliente() As Boolean
        Const sProcedure As String = "ConsultarCliente"
        Try
            Me.oCliente = New Class_CatClientes(Me.TxtCliente.Text)
            If Me.oCliente.Existe = False Then
                Me.lblCliente.Text = ""
                Return False
            End If

            Me.lblCliente.Text = Me.oCliente.NOMBRE_CLIENTE
            Me.txtPlazo.Text = Me.oCliente.DIAS_PLAZO.ToString
            Me.dpVencimiento.Value = Me.dpFecha.Value.AddDays(CDbl(Me.txtPlazo.Text))

            If Empresa_Sistema.CODIGO_VENDEDOR_POR_USUARIO = True AndAlso txtLEN(Usuario.CODIGO_VENDEDOR) = True Then
                Me.cboVendedor.SelectedValue = Usuario.CODIGO_VENDEDOR
            Else
                Me.cboVendedor.SelectedValue = Me.oCliente.CODIGO_VENDEDOR
            End If

            If sTipoVenta = "NM" Then 'Cuidado, aqui se estaba perdiendo el almacén que se obtuvo de la referencia en el caso de las sustituciones
                If Empresa_Sistema.CODIGO_ALMACEN_POR_CLIENTE AndAlso txtLEN(Me.oCliente.CODIGO_ALMACEN) = True Then
                    Me.CboAlmacen.SelectedValue = Me.oCliente.CODIGO_ALMACEN
                Else
                    Me.CboAlmacen.SelectedValue = Plaza.CODIGO_ALMACEN_PRINCIPAL
                End If
            End If

            Dim bEstableceFormaPago As Boolean

            If Empresa_Sistema.VERSION_ESQUEMA_CFD <= "3.2" Then
                bEstableceFormaPago = True
            Else
                If Me.cboMetodoPago.SelectedIndex <> -1 AndAlso Me.cboMetodoPago.SelectedValue.ToString = "PUE" Then 'Si es PPD recordemos que la forma de pago es obligatoriamente 99
                    bEstableceFormaPago = True
                End If
            End If
            Me.bClienteEsContribuyenteIEPS = CBool(Me.oCliente.ES_CONTRIBUYENTE_IEPS)
            If Me.oDocumento.CODIGO_TIPO_DOCUMENTO = "FT" Then 'Factura de traslado
                Dim oUsoCFDI As New Class_CFD_CatUsosCFDI("P01")
                Me.lblUsoCFDI.Text = oUsoCFDI.NOMBRE_USO_CFDI
                oUsoCFDI = Nothing

                Return True 'Nos salimos ya que la forma de pago y método de pago son fijas y ya están establecidas.
            Else
                If bEstableceFormaPago = True Then
                    Select Case Me.cboMoneda.Text
                        Case "MXN"
                            Me.cboFormaPago.SelectedValue = Me.oCliente.CODIGO_METODO_PAGO
                            Me.txtNumeroCuentaPago.Text = Me.oCliente.NUMERO_CUENTA_PAGO
                        Case "USD"
                            If txtLEN("" & Me.oCliente.CODIGO_METODO_PAGO_DOLARES) = True Then
                                Me.cboFormaPago.SelectedValue = Me.oCliente.CODIGO_METODO_PAGO_DOLARES
                                Me.txtNumeroCuentaPago.Text = Me.oCliente.NUMERO_CUENTA_PAGO_DOLARES
                            Else
                                Me.cboFormaPago.SelectedIndex = -1
                            End If
                    End Select
                End If

                Me.txtRegimenFiscalReceptor.Text = Me.oCliente.CODIGO_REGIMEN_FISCAL
                If txtLEN(Me.oCliente.CODIGO_REGIMEN_FISCAL) = True Then
                    Dim oRegimenFiscal As New Class_CFDCatTiposRegimenesFiscales(Me.oCliente.CODIGO_REGIMEN_FISCAL)
                    Me.lblRegimenFiscalReceptor.Text = oRegimenFiscal.NOMBRE_REGIMEN_FISCAL
                    oRegimenFiscal = Nothing
                End If

                Me.txtUsoCFDI.Text = Me.oCliente.CODIGO_USO_CFDI
                If txtLEN(Me.oCliente.CODIGO_USO_CFDI) = True Then
                    Dim oUsoCFDI As New Class_CFD_CatUsosCFDI(Me.oCliente.CODIGO_USO_CFDI)
                    Me.lblUsoCFDI.Text = oUsoCFDI.NOMBRE_USO_CFDI
                    oUsoCFDI = Nothing
                End If
            End If

            'Select Case Me.oCliente.TIPO_PERSONA
            '    Case "F"
            '        Me.DesplegarUsoCFDIPersonasFisicas()
            '    Case "M"
            '        Me.DesplegarUsoCFDIPersonasMorales()
            'End Select
            'Me.cboUsoCFDI.SelectedValue = Me.oCliente.CODIGO_USO_CFDI


            If Me.oDocumento.ES_FACTURA_ANTICIPO = True Then
                Me.cboTipoNegociacion.SelectedValue = "2" '1=Credito, 2=Contado , forzamos a contado porque al ser anticipo es contado-PUE según el SAT.
                Me.cboMetodoPago.SelectedValue = "PUE"
            Else
                Me.cboTipoNegociacion.SelectedValue = Me.oCliente.CODIGO_TIPO_NEGOCIACION
            End If

            Return True
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Function

    Private Function GestionaFacturaEmbarqueExtranjero() As Boolean
        Dim bResultado As Boolean = False
        Try
            Dim dTabla As DataTable
            Me.CboDocumento.SelectedValue = Me._oEmbarqueExtranjero.CODIGO_TIPO_DOCUMENTO_FACTURA_EMBARQUE_EXTRANJERO & Usuario.Codigo_Plaza.ToString
            Me.cboTipoMercado.SelectedValue = "0001" '0001=EXPORTACION

            Me.TxtCliente.Text = Me._oEmbarqueExtranjero.CODIGO_CLIENTE

            Me.ConsultarCliente()

            Me.cboMoneda.Text = "USD"
            Me.txtTipoCambio.Text = Me._TipoCambioPorEmbarqueExtranjero.ToString

            Me.cboFormaPago.SelectedValue = "NA" '99=Otros
            Me.txtNumeroCuentaPago.Text = ""

            dTabla = Me._oEmbarqueExtranjero.ObtenerDetalleFacturaEmbarqueExtranjero(Me._TipoCambioPorEmbarqueExtranjero)

            Me.Grid.Rows = 1
            For Each dRow As DataRow In dTabla.Rows
                Me.Grid.AddItem(dRow("CODIGO_ARTICULO").ToString & Chr(9) &
                                dRow("TIPO_CONTROL_INVENTARIO").ToString & Chr(9) &
                                dRow("DESCRIPCION").ToString & Chr(9) &
                                dRow("CANTIDAD_BULTOS_DETALLE").ToString & Chr(9) &
                                dRow("PRECIO_UNIDAD_BULTO").ToString & Chr(9) &
                                dRow("PRECIO_UNIDAD_BULTO").ToString & Chr(9) &
                                dRow("UNIDAD").ToString & Chr(9) &
                                dRow("CANTIDAD_KILOS").ToString & Chr(9) &
                                dRow("PRECIO_KILOS").ToString & Chr(9) &
                                "0.00" & Chr(9) &
                                "0.00" & Chr(9) &
                                "0.00" & Chr(9) &
                                Plaza.CUENTA_CONTABLE_VENTAS.ToString & Chr(9) &
                                "" & Chr(9) &
                                "" & Chr(9) &
                                "" & Chr(9) &
                                "0" & Chr(9) &
                                "SIN DEFINIR" & Chr(9) &
                                dRow("PRECIO_USD").ToString & Chr(9) &
                                dRow("IMPORTE_USD").ToString & Chr(9) &
                                "0" & Chr(9) &
                                "0" & Chr(9) &
                                "0" & Chr(9) &
                                "0" & Chr(9) &
                                "0" & Chr(9) &
                                "0" & Chr(9) &
                                "0" & Chr(9) &
                                "0" & Chr(9) &
                                "0" & Chr(9) &
                                dRow("ID_SIS_CAT_IMPUESTOS").ToString & Chr(9) &
                                dRow("GRADO_TOXICIDAD").ToString
                )
                'Plaza.CUENTA_CONTABLE_VENTAS.ToString + Me.cboTipoMercado.SelectedValue.ToString + dRow("CUENTA_CONTABLE_BASE").ToString & Chr(9) & 'En agr esta así, pero aquí la cuenta es general
            Next

            Me.FormateaGrid()
            Me.Totales()

            bResultado = True
        Catch ex As Exception
            HandleError(Me.Name, "GestionaFacturaEmbarqueExtranjero", ex)
        End Try
        Return bResultado
    End Function

    Private Sub Inicializa_dtSeries()
        Const sProcedure As String = "Inicializa_dtSeries"
        Try
            'Dim iUnidades As Integer

            'If IsNothing(Me.dtSeries) = False AndAlso Me.dtSeries.Rows.Count > 0 Then
            '    If MsgBox("Hay series ya especificadas, si continua tendrá que recapturar todas." & vbCrLf & "Esta seguro de continuar ?", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            '        Return
            '    End If
            'End If

            Me.dtSeries.Clear()
            Me.dtSeries = New DataTable("Series")
            With Me.dtSeries
                .Columns.Add("POSICION", GetType(String))
                .Columns.Add("CODIGO_ARTICULO", GetType(String))
                .Columns.Add("DESCRIPCION", GetType(String))
                .Columns.Add("ID_INVENTARIO_LOTES_COSTOS", GetType(String))
                .Columns.Add("NUMERO_SERIE", GetType(String))
                .Columns.Add("ID_ORIGEN", GetType(String))
                .Columns.Add("FOLIO_REMISION", GetType(String))
            End With
            Me.dtSeries.AcceptChanges()
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Sub PrepararSeries()
        Const sProcedure As String = "PrepararSeries"
        Try
            If Me.sTipoVenta = "SR" Then
                MsgBox("Al estar facturando varias remisiones no es válido usar este botón porque las series se crean en automático desde la opción de facturar varias remisiones, puede usar esta opción y empezar el proceso desde cero.", MsgBoxStyle.Information, sProcedure)
                Return
            End If

            If IsNothing(Me.dtSeries) = False AndAlso Me.dtSeries.Rows.Count > 0 Then
                If MsgBox("Hay series ya especificadas, si continua tendrá que recapturar todas." & vbCrLf & "Esta seguro de continuar ?", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo, sProcedure) = MsgBoxResult.No Then
                    Return
                End If
            End If

            Me.Inicializa_dtSeries()

            Dim dRow As DataRow

            For i = 1 To Me.Grid.Rows - 1
                If txtLEN(Me.Grid.Cell(i, Me.igyCodigo).Text) = True AndAlso Me.Grid.Cell(i, Me.igyCodigo).Text <> "-" AndAlso CInt(Me.Grid.Cell(i, Me.igyCantidad).Text) > 0 Then
                    Dim oArticulo As New Class_CatArticulos(Me.Grid.Cell(i, Me.igyCodigo).Text)
                    If oArticulo.Existe = True AndAlso oArticulo.ES_SERIALIZABLE = True AndAlso oArticulo.INVENTARIABLE = "1" AndAlso valorNumericoD(Me.Grid.Cell(i, Me.igyIdOrigen).Text) = 0 Then
                        For j = 1 To CInt(Me.Grid.Cell(i, Me.igyCantidad).Text)
                            dRow = Me.dtSeries.NewRow

                            dRow("POSICION") = i
                            dRow("CODIGO_ARTICULO") = Me.Grid.Cell(i, Me.igyCodigo).Text
                            dRow("DESCRIPCION") = Me.Grid.Cell(i, Me.igyDescripcion).Text
                            dRow("ID_INVENTARIO_LOTES_COSTOS") = ""
                            dRow("NUMERO_SERIE") = ""
                            dRow("ID_ORIGEN") = ""
                            dRow("FOLIO_REMISION") = ""

                            Me.dtSeries.Rows.Add(dRow)
                        Next
                    End If
                End If
            Next

            Me.dtSeries.AcceptChanges()

            'Me.GridSeries.DataSource = Me.dtSeries
            Me.InicializaGridSeries()
            Me.GridSeries.Rows = 1
            For Each dRow In Me.dtSeries.Rows
                Me.GridSeries.AddItem(dRow("POSICION").ToString & Chr(9) & dRow("CODIGO_ARTICULO").ToString & Chr(9) & dRow("DESCRIPCION").ToString & Chr(9) &
                                      dRow("ID_INVENTARIO_LOTES_COSTOS").ToString & Chr(9) & dRow("NUMERO_SERIE").ToString & Chr(9) &
                                      dRow("ID_ORIGEN").ToString & Chr(9) & dRow("FOLIO_REMISION").ToString & Chr(9))
            Next

            Me.FormateaGridSeries()
            If Me.dtSeries.Rows.Count > 0 Then

                Me.TabControl1.SelectedIndex = 1
            Else
                MsgBox("No hay artículos con series.", MsgBoxStyle.Exclamation, sProcedure)
            End If

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
            Me.GridSeries.Cols = 8
            Me.FormateaGridSeries()
            'Me.Grid.Cell(1, Me.iGyIDAdicional).Text = "1"
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Sub FormateaGridSeries()
        Const sProcedure As String = "FormateaGridSeries"
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

                .Column(Me.igySeriePosicion).Width = 50 ' False
                .Column(Me.igySerieCodigo).Width = 150
                .Column(Me.igySerieDescripcion).Width = 500
                .Column(Me.igySerieIdInventarioLotesCostos).Width = 50
                .Column(Me.igySerieNumeroSerie).Width = 250
                .Column(Me.igySerieIDOrigen).Width = 50
                .Column(Me.igySerieFolioRemision).Width = 75

                .Cell(0, Me.igySeriePosicion).Text = "Posición"
                .Cell(0, Me.igySerieCodigo).Text = "Código"
                .Cell(0, Me.igySerieDescripcion).Text = "Descripción"
                .Cell(0, Me.igySerieIdInventarioLotesCostos).Text = "Id lote"
                .Cell(0, Me.igySerieNumeroSerie).Text = "Número de serie"
                .Cell(0, Me.igySerieIDOrigen).Text = "IDOrigen"
                .Cell(0, Me.igySerieFolioRemision).Text = "FolioRemision"

                .Column(Me.igySeriePosicion).Locked = True
                .Column(Me.igySerieCodigo).Locked = True
                .Column(Me.igySerieDescripcion).Locked = True
                .Column(Me.igySerieIdInventarioLotesCostos).Locked = True
                .Column(Me.igySerieNumeroSerie).Locked = True

                .Column(Me.igySerieIDOrigen).Locked = True
                .Column(Me.igySerieFolioRemision).Locked = True

                'Aunque por default están ocultas pueden hacerse visibles con un botón
                .Column(Me.igySerieIdInventarioLotesCostos).Visible = False
                .Column(Me.igySerieIDOrigen).Visible = False


                .Row(.Rows - 1).Locked = True 'Para bloquear la edición del último renglón
            End With
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        Finally
            Me.GridSeries.AutoRedraw = True
            Me.GridSeries.Refresh()
        End Try
    End Sub

    Private Sub GestionaGridSeries(ByVal e As System.Windows.Forms.KeyEventArgs)
        Const sProcedure As String = "GestionaGridSeries"
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
                            If txtLEN(Me.GridSeries.Cell(Renglon, Me.igySerieFolioRemision).Text) = True Then
                                MsgBox("Esta serie al provenir de una remisión no puede modificarla, puede solamente quitarla con F8.", MsgBoxStyle.Exclamation, sProcedure)
                                Return
                            End If
busca_serie:
                            oSerie = New Class_Inventarios_Lotes_Series
                            sCodigoArticulo = .Cell(Renglon, Me.igySerieCodigo).Text
                            sLote = oSerie.BusquedaVisual(sCodigoArticulo, Me.CboAlmacen.SelectedValue.ToString)
                            If txtLEN(sLote) = True Then
                                If Me.RepiteSerie(Renglon, sLote) = False Then
                                    Me.EstableceSerie(Renglon, sLote)
                                End If
                            End If
                        End If

                    Case Keys.F7
                        If Columna = Me.igySerieNumeroSerie AndAlso txtLEN(.Cell(Renglon, Me.igySeriePosicion).Text) = True Then
                            If txtLEN(Me.GridSeries.Cell(Renglon, Me.igySerieFolioRemision).Text) = True Then
                                MsgBox("Esta serie al provenir de una remisión no puede modificarla, puede solamente quitarla.", MsgBoxStyle.Exclamation, sProcedure)
                                Return
                            End If
                            oSerie = New Class_Inventarios_Lotes_Series
                            sCodigoArticulo = .Cell(Renglon, Me.igySerieCodigo).Text
                            If txtLEN(sCodigoArticulo) = False Then
                                Return
                            End If

                            Dim lote As New Class_Inventarios_Lotes_Series.Lote
                            lote = oSerie.BusquedaVisualSeriesMultiplesFolio(sCodigoArticulo, Me.CboAlmacen.SelectedValue.ToString)

                            If txtLEN(lote.FolioMovimiento) = True Then

                                Dim dtSeriesLocal As DataTable = oSerie.ObtieneRenglonesSeriesFolio(lote.FolioMovimiento, sCodigoArticulo)
                                If dtSeriesLocal.Rows.Count = 0 Then
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
                                        Me.GridSeries.Cell(i, Me.igySerieIdInventarioLotesCostos).Text = dtSeriesLocal.Rows(iRowEncontrado)("ID_INVENTARIO_LOTES_COSTOS").ToString
                                        Me.GridSeries.Cell(i, Me.igySerieNumeroSerie).Text = dtSeriesLocal.Rows(iRowEncontrado)("NUMERO_SERIE").ToString
                                        iRowEncontrado += 1 'empieza desde el 0
                                    End If
                                Next


                            End If
                        End If
                    Case Keys.F8
                        Me.GridSeries.Selection.DeleteByRow()
                        Me.Regenerar_dtSeries()

                    Case Keys.Delete
                        e.SuppressKeyPress = True
                End Select
            End With

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Function CantidadArticulosPendientesSerie(ByVal sCodigoArticulo As String) As Integer
        Dim iArticulosEncontrados As Integer = 0
        Try
            For i = 1 To Me.GridSeries.Rows - 1
                If Me.GridSeries.Cell(i, Me.igySerieCodigo).Text = sCodigoArticulo AndAlso Me.GridSeries.Cell(i, Me.igyCodigo).Text <> "-" AndAlso txtLEN(Me.GridSeries.Cell(i, Me.igySerieIdInventarioLotesCostos).Text) = False Then
                    iArticulosEncontrados += 1
                End If
            Next
        Catch ex As Exception
            HandleError(Me.Name, "CantidadArticulosPendientesSerie", ex)
        End Try
        Return iArticulosEncontrados
    End Function

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

            'If Me.sTipoVenta = "SR" AndAlso dtSeriesTemp.Rows.Count > 0 Then
            '    MsgBox("Las sustituciones no soportan el manejo de series actualmente.", MsgBoxStyle.Exclamation, Me.Text)
            '    Return False
            'End If

            Me.Regenerar_dtSeries() 'Nota recuerde que dtSeries ya no esta ligado con datasource al grid asi que para usarlo antes hay que regenerarlo o bien trabajar directo con el gridSeries y no con dtSeries

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
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Validamos la disponibilidad de las series sustituidas en INVENTARIO_LOTES_SALIDAS
            'dRow campos: POSICION,CODIGO_ARTICULO,DESCRIPCION,ID_INVENTARIO_LOTES_COSTOS,NUMERO_SERIE,ID_ORIGEN,FOLIO_REMISION
            Dim oInventarios As New Class_Inventarios_Global

            If Me.sTipoVenta = "SR" Then
                For i = 1 To Me.Grid.Rows - 1
                    Dim sArticulo As String = Me.Grid.Cell(i, Me.igyCodigo).Text
                    Dim sIDOrigen As String = Me.Grid.Cell(i, Me.igyIdOrigen).Text, sIDInventarioLoteCosto As String = "", dDisponibleLoteSerieEnRemision As Decimal = 0
                    If txtLEN(sArticulo) = True AndAlso valorNumericoD(sIDOrigen) > 0 Then
                        For Each dRow In Me.dtSeries.Select("POSICION='" & i.ToString & "'") 'Este campo es string si no se le ponen las comillas no funciona bien.
                            sIDInventarioLoteCosto = dRow("ID_INVENTARIO_LOTES_COSTOS").ToString

                            'Nota aunque el campo se llame IDOrigen como renglón de factura, como renglón de remisión es IDVentaDetalle por eso se llama así el parámetro de la función.
                            dDisponibleLoteSerieEnRemision = oInventarios.DisponibleLoteSerieEnRemision(sIDOrigen, sIDInventarioLoteCosto)

                            If dDisponibleLoteSerieEnRemision < CDec("1") Then
                                MsgBox("El lote con la serie " & dRow("NUMERO_SERIE").ToString & " sustituida del artículo " & Me.Grid.Cell(i, Me.igyDescripcion).Text & " del renglón #" & i.ToString &
                                       " no tiene disponible(" & dDisponibleLoteSerieEnRemision.ToString & "), es decir no puede volver a facturarse porque ya se facturó.", MsgBoxStyle.Exclamation, sProcedure)
                                Return False
                            End If
                        Next
                    End If
                Next
            End If

            oInventarios = Nothing
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Return True
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Function

    Private Function ValidadGridSeries() As Boolean
        Dim bResultado As Boolean = False
        Try
            Dim RenglonRepetido As Integer
            Dim sRepetido As Boolean = False

            For i = 1 To Me.GridSeries.Rows - 1
                If (txtLEN(Me.GridSeries.Cell(i, Me.igySerieCodigo).Text) = True) And sRepetido = False Then
                    For z = i + 1 To Me.GridSeries.Rows - (i + 1)
                        If Me.GridSeries.Cell(i, Me.igySerieIdInventarioLotesCostos).Text = Me.GridSeries.Cell(z, Me.igySerieIdInventarioLotesCostos).Text Then
                            sRepetido = True
                            RenglonRepetido = z
                            Exit For
                        End If
                    Next
                Else
                    Exit For
                End If
            Next

            If sRepetido = True Then
                MsgBox("Hay una serie repetida " & Me.GridSeries.Cell(RenglonRepetido, igySerieNumeroSerie).Text & " en: " & Me.GridSeries.Cell(RenglonRepetido, igySerieCodigo).Text & " en el renglón " & RenglonRepetido, MsgBoxStyle.Exclamation)
                Me.GridSeries.Cell(RenglonRepetido, Me.igySerieNumeroSerie).SetFocus()
                Return False
            End If

            bResultado = True

        Catch ex As Exception
            HandleError(Me.Name, "ValidadGridSeries", ex)
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
                .Items.Add("XXX")
                .Text = "MXN"
                sMonedaAnterior = "MXN"
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarMonedas", ex)
        End Try
    End Sub

    Private Sub EstableceMetodoPago()
        Try
            If Me.oDocumento.CODIGO_TIPO_DOCUMENTO = "FT" Then 'Factura de traslado
                Return
            End If
            Select Case Me.cboTipoNegociacion.Text
                Case "CONTADO"
                    If bCargandoVenta = False Then
                        Me.cboMetodoPago.SelectedValue = "PUE"
                    End If
                    Me.cboMetodoPago.Enabled = False
                    Me.cboFormaPago.Enabled = True

                    If Empresa_Sistema.VERSION_ESQUEMA_CFD <= "3.2" Then
                        If txtLEN(Me.TxtCliente.Text) = False Then
                            Me.cboFormaPago.SelectedValue = "NA"
                        End If
                        Return
                    End If

                    'Se quitó la restricción, biologos ocupa facturar un auto a una aseguradora con PUE-99
                    'Quitamos el "99-Por definir" ya que sólo es para crédito
                    'dViewFormasPago.RowFilter = "CODIGO_METODO_PAGO<>'99'"

                    If txtLEN(Me.TxtCliente.Text) = True Then
                        If bCargandoVenta = False Then
                            If Me.oDocumento.CODIGO_TIPO_DOCUMENTO <> "FT" Then 'Factura de traslado
                                Me.EstableceFormaPagoCliente()
                            End If
                        End If
                        If Me.cboFormaPago.SelectedValue.ToString = "99" Then
                            Me.cboFormaPago.SelectedIndex = -1
                        End If
                    Else
                        Me.lblCliente.Text = ""
                        Me.cboFormaPago.SelectedIndex = -1 'Si no hay cliente no se selecciona ninguna forma de pago.
                    End If

                Case "CREDITO"

                    Me.cboMetodoPago.SelectedValue = "PPD"

                    If Empresa_Sistema.VERSION_ESQUEMA_CFD <= "3.2" Then
                        If txtLEN(Me.TxtCliente.Text) = False Then
                            Me.cboFormaPago.SelectedValue = "NA"
                        End If

                        Me.cboFormaPago.Enabled = True
                        Exit Sub
                    End If

                    '3.3 O Mayores
                    'Me.cboFormaPago.Enabled = False

                    'AgregaFormaPago99
                    dViewFormasPago.RowFilter = ""

                    If bCargandoVenta = False Then
                        Me.cboFormaPago.SelectedValue = "99"
                    End If

            End Select
        Catch ex As Exception
            HandleError(Me.Name, "EstableceMetodoPago", ex)
        End Try
    End Sub

    Private Sub EstableceFormaPagoCliente()
        Try
            Dim oCliente As New Class_CatClientes(Me.TxtCliente.Text)
            Select Case Me.cboMoneda.Text
                Case "MXN"
                    Me.cboFormaPago.SelectedValue = oCliente.CODIGO_METODO_PAGO
                    Me.txtNumeroCuentaPago.Text = oCliente.NUMERO_CUENTA_PAGO
                Case "USD"
                    Me.cboFormaPago.SelectedValue = oCliente.CODIGO_METODO_PAGO_DOLARES
                    Me.txtNumeroCuentaPago.Text = oCliente.NUMERO_CUENTA_PAGO_DOLARES
            End Select
        Catch ex As Exception
            HandleError(Me.Name, "EstableceFormaPagoCliente", ex)
        End Try
    End Sub

    'Private Sub DesplegarUsoCFDIPersonasFisicas()
    '    Try
    '        With Me.cboUsoCFDI
    '            .DisplayMember = "NOMBRE_USO_CFDI"
    '            .ValueMember = "CODIGO_USO_CFDI"
    '            Dim dView As New Data.DataView(dtUsosCFDIPersonasFisicas)
    '            dView.Sort = "NOMBRE_USO_CFDI"
    '            .DataSource = dView
    '            If dView.Count > 0 Then
    '                .SelectedIndex = 0
    '            End If
    '        End With
    '    Catch ex As Exception
    '        HandleError(Me.Name, "DesplegarUsoCFDIPersonasFisicas", ex)
    '    End Try
    'End Sub

    'Private Sub DesplegarUsoCFDIPersonasMorales()
    '    Try
    '        With Me.cboUsoCFDI
    '            .DisplayMember = "NOMBRE_USO_CFDI"
    '            .ValueMember = "CODIGO_USO_CFDI"
    '            Dim dView As New Data.DataView(dtUsosCFDIPersonasMorales)
    '            dView.Sort = "NOMBRE_USO_CFDI"
    '            .DataSource = dView
    '            If dView.Count > 0 Then
    '                .SelectedIndex = 0
    '            End If
    '        End With
    '    Catch ex As Exception
    '        HandleError(Me.Name, "DesplegarUsoCFDIPersonasMorales", ex)
    '    End Try
    'End Sub

    Private Sub CalculaUtilidad()
        Try
            Dim i As Integer, dUtilidadTotal As Decimal = 0, dUtilidadUnitaria As Decimal = 0, dCantidad As Decimal = 0, dImporte As Decimal = 0, dUtilidadPorcentaje As Decimal = 0
            Dim dtImporteTotal As Decimal = 0, dtUtilidadTotal As Decimal = 0, dtUtilidadPorcentaje As Decimal = 0
            'utilidad unitaria = precio - costo
            'utilidad total = importe - (costo * cantidad)
            '% utilidad = Utilidad total / importe
            With Me.Grid
                For i = 1 To .Rows - 1
                    If txtLEN(.Cell(i, Me.igyCodigo).Text) = True AndAlso .Cell(i, Me.igyCodigo).Text <> "-" Then
                        '.Cell(i, Me.igyUtilidadUnitaria).Text = (valorNumerico(.Cell(i, Me.igyPrecio).Text) - valorNumerico(.Cell(i, Me.igyCosto).Text)).ToString
                        '.Cell(i, Me.igyUtilidadTotal).Text = (valorNumerico(.Cell(i, Me.igyImporte).Text) - (valorNumerico(.Cell(i, Me.igyCosto).Text) * valorNumerico(.Cell(i, Me.igyCantidad).Text))).ToString
                        'If valorNumerico(.Cell(i, Me.igyImporte).Text) > 0 Then
                        '    .Cell(i, Me.igyUtilidadPorcentaje).Text = (valorNumerico(.Cell(i, Me.igyUtilidadTotal).Text) / valorNumerico(.Cell(i, Me.igyImporte).Text)).ToString
                        'End If

                        dCantidad = valorNumericoD(.Cell(i, Me.igyCantidad).Text)
                        dImporte = dCantidad * valorNumericoD(.Cell(i, Me.iGyPRECIO_CON_DESCUENTO).Text)

                        dUtilidadUnitaria = valorNumericoD(.Cell(i, Me.iGyPRECIO_CON_DESCUENTO).Text) - valorNumericoD(.Cell(i, Me.igyCosto).Text)
                        dUtilidadTotal = dUtilidadUnitaria * dCantidad

                        If dImporte > 0 Then
                            dUtilidadPorcentaje = (dUtilidadTotal / dImporte) * CDec(100)
                        End If

                        .Cell(i, Me.igyUtilidadUnitaria).Text = dUtilidadUnitaria.ToString
                        .Cell(i, Me.igyUtilidadTotal).Text = dUtilidadTotal.ToString
                        .Cell(i, Me.igyUtilidadPorcentaje).Text = dUtilidadPorcentaje.ToString

                        dtImporteTotal = dtImporteTotal + dImporte
                        dtUtilidadTotal = dtUtilidadTotal + dUtilidadTotal
                    End If
                Next
            End With

            If dtImporteTotal > 0 Then
                dtUtilidadPorcentaje = (dtUtilidadTotal / dtImporteTotal) * CDec(100)
            End If

            Me.lblUtilidad.Text = FormatImporteContable(dtUtilidadTotal, False)
            Me.lblPorcentajeUtilidad.Text = FormatImporteContable(dtUtilidadPorcentaje, False)

        Catch ex As Exception
            HandleError(Me.Name, "CalculaUtilidad", ex)
        End Try
    End Sub

    Private Sub DesplegarTiposRelacionCFDI()
        Try
            With Me.cboTipoRelacionCFDI
                .DisplayMember = "NOMBRE_TIPO_RELACION_CFDI"
                .ValueMember = "CODIGO_TIPO_RELACION_CFDI"
                Dim dView As New Data.DataView(dtTiposRelacionCFDI)
                dView.Sort = "NOMBRE_TIPO_RELACION_CFDI"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedIndex = -1
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarTiposRelacionCFDI", ex)
        End Try
    End Sub

    Private Sub InicializaGridCFDIsRelacionados()
        Try
            Me.GridCFDIsRelacionados.DataSource = Nothing
            FG_Grid_Limpiar(Me.GridCFDIsRelacionados)
            Me.GridCFDIsRelacionados.Rows = 2
            Me.GridCFDIsRelacionados.Cols = 6
            Me.FormateaGridCFDIsRelacionados()
        Catch ex As Exception
            HandleError(Me.Name, "InicializaGridCFDIsRelacionados", ex)
        End Try
    End Sub

    Private Sub FormateaGridCFDIsRelacionados()
        Try
            With Me.GridCFDIsRelacionados
                .AutoRedraw = False

                .Column(Me.iGyGRFolio).Width = 100
                .Column(Me.iGyGRFecha).Width = 80
                .Column(Me.iGyGRConcepto).Width = 300
                .Column(Me.iGyGRUUID).Width = 280
                .Column(Me.iGyGRTotal).Width = 100

                .Cell(0, Me.iGyGRFolio).Text = "Folio"
                .Cell(0, Me.iGyGRFecha).Text = "Fecha"
                .Cell(0, Me.iGyGRConcepto).Text = "Concepto"
                .Cell(0, Me.iGyGRUUID).Text = "UUID"
                .Cell(0, Me.iGyGRTotal).Text = "Total"

                .Column(Me.iGyGRFolio).Locked = False
                .Column(Me.iGyGRFecha).Locked = True
                .Column(Me.iGyGRConcepto).Locked = True
                .Column(Me.iGyGRUUID).Locked = True
                .Column(Me.iGyGRTotal).Locked = True

                .Column(Me.iGyGRFecha).CellType = FlexCell.CellTypeEnum.DateTime
                .Column(Me.iGyGRFecha).FormatString = "dd-MMM-yy"

                .Column(Me.iGyGRTotal).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
                .Column(Me.iGyGRTotal).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyGRTotal).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
                .Column(Me.iGyGRTotal).Alignment = FlexCell.AlignmentEnum.RightCenter

                .AutoRedraw = True
                .Refresh()

                '.Row(.Rows - 1).Locked = True 'Para bloquear la edición del último renglón
            End With
        Catch ex As Exception
            HandleError(Me.Name, "FormateaGridCFDIsRelacionados", ex)
        End Try
    End Sub

    Private Sub GestionaGridCFDIsRelacionados(ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            If Me.GridCFDIsRelacionados.Locked = True Then
                Return
            End If

            Dim Columna As Integer, Renglon As Integer, sFolio As String = "", oVenta As Class_Ventas_Global

            Columna = Me.GridCFDIsRelacionados.Selection.FirstCol
            Renglon = Me.GridCFDIsRelacionados.Selection.FirstRow
            sFolio = Me.GridCFDIsRelacionados.Cell(Renglon, Me.iGyGRFolio).Text

            Select Case e.KeyCode
                Case Keys.Enter

                    Select Case Columna
                        Case Me.iGyGRFolio
                            If txtLEN(sFolio) = False Then
                                GoTo BuscaVentas : Return
                            End If
LlenaLinea:
                            oVenta = New Class_Ventas_Global(sFolio)
                            If oVenta.Existe = False Then
                                GoTo BuscaVentas : Return
                            End If

                            Me.GridCFDIsRelacionados.Cell(Renglon, Me.iGyGRFecha).Text = oVenta.FECHA.ToString
                            Me.GridCFDIsRelacionados.Cell(Renglon, Me.iGyGRConcepto).Text = oVenta.CONCEPTO
                            Me.GridCFDIsRelacionados.Cell(Renglon, Me.iGyGRUUID).Text = oVenta.FOLIO_FISCAL_SAT
                            Me.GridCFDIsRelacionados.Cell(Renglon, Me.iGyGRTotal).Text = oVenta.TOTAL.ToString
                    End Select

                    If Me.GridCFDIsRelacionados.Rows - 1 = Renglon Then
                        Me.GridCFDIsRelacionados.Rows = Me.GridCFDIsRelacionados.Rows + 1
                    End If

                Case Keys.F6
BuscaVentas:
                    Select Case Columna
                        Case Me.iGyGRFolio
                            oVenta = New Class_Ventas_Global
                            sFolio = oVenta.BusquedaVisualFacturasClienteParaRelacionarCFDIs(Me.TxtCliente.Text)
                            If txtLEN(sFolio) = True Then
                                Me.GridCFDIsRelacionados.Cell(Renglon, Me.iGyGRFolio).Text = sFolio
                                GoTo LlenaLinea : Return
                            End If
                    End Select

                Case Keys.F8 'Borrar renglón
                    If (Me.Estado = enumEstados.NUEVO) Then
                        Me.GridCFDIsRelacionados.Selection.DeleteByRow()
                    End If

                Case Keys.Delete 'Borrar renglón
                    Return

            End Select

        Catch ex As Exception
            HandleError(Me.Name, "GestionaGridCFDIsRelacionados", ex)
        End Try
    End Sub

    Private Function HayCFDIsRelacionadosRepetidos() As Boolean
        Const sProcedure As String = "HayCFDIsRelacionadosRepetidos"
        Try
            Dim i As Integer, j As Integer, sFolio As String = ""
            For i = 1 To Me.GridCFDIsRelacionados.Rows - 1
                If txtLEN(Me.GridCFDIsRelacionados.Cell(i, Me.iGyGRFolio).Text) = True Then
                    sFolio = Me.GridCFDIsRelacionados.Cell(i, Me.iGyGRFolio).Text
                    For j = i + 1 To Me.GridCFDIsRelacionados.Rows - 1
                        If txtLEN(Me.GridCFDIsRelacionados.Cell(j, Me.iGyGRFolio).Text) = True Then
                            If sFolio = Me.GridCFDIsRelacionados.Cell(j, Me.iGyGRFolio).Text And Me.GridCFDIsRelacionados.Rows > 2 Then
                                MsgBox("El CFDI relacionado " & iGyGRFolio & " esta repetido en el renglón #" & i.ToString & " y en el #" & j.ToString, MsgBoxStyle.Exclamation, sProcedure)
                                Me.GridCFDIsRelacionados.Cell(i, Me.iGyGRFolio).SetFocus()
                                'Me.GridSemanaTrabajadores.Selection.DeleteByRow()
                                Return True
                            End If
                        End If
                    Next j
                End If
            Next i

            Return False
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Function

    Private Sub InicializaGridFacturasVariasRemisiones()
        Try
            Me.GridFacturasVariasRemisiones.DataSource = Nothing
            FG_Grid_Limpiar(Me.GridFacturasVariasRemisiones)
            Me.GridFacturasVariasRemisiones.Rows = 2
            Me.GridFacturasVariasRemisiones.Cols = 6
            Me.FormateaGridFacturasVariasRemisiones()
        Catch ex As Exception
            HandleError(Me.Name, "InicializaGridFacturasVariasRemisiones", ex)
        End Try
    End Sub

    Private Sub FormateaGridFacturasVariasRemisiones()
        Const sProcedure As String = "FormateaGridFacturasVariasRemisiones"
        Try
            With Me.GridFacturasVariasRemisiones
                .Column(Me.iGyFolio).Width = 120
                .Column(Me.iGyFecha).Width = 70
                .Column(Me.iGyTotal).Width = 100
                .Column(Me.iGyMoneda).Width = 70
                .Column(Me.iGyConcepto).Width = 660

                .Cell(0, Me.iGyFolio).Text = "Folio"
                .Cell(0, Me.iGyFecha).Text = "Fecha"
                .Cell(0, Me.iGyTotal).Text = "Total"
                .Cell(0, Me.iGyMoneda).Text = "Moneda"
                .Cell(0, Me.iGyConcepto).Text = "Concepto"

                .Column(Me.iGyFolio).Locked = True
                .Column(Me.iGyFecha).Locked = True
                .Column(Me.iGyTotal).Locked = True
                .Column(Me.iGyMoneda).Locked = True
                .Column(Me.iGyConcepto).Locked = True

                .Column(Me.iGyFecha).CellType = FlexCell.CellTypeEnum.DateTime
                .Column(Me.iGyFecha).FormatString = "dd-MMM-yy"

                .Column(Me.iGyTotal).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
                .Column(Me.iGyTotal).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyTotal).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
                .Column(Me.iGyTotal).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Locked = False

                .AutoRedraw = True
                .Refresh()
            End With
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        Finally
            Me.GridFacturasVariasRemisiones.AutoRedraw = True
            Me.GridFacturasVariasRemisiones.Refresh()
        End Try
    End Sub

    Private Sub GestionaGridFacturasVariasRemisiones(ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            With Me.GridFacturasVariasRemisiones
                Dim Renglon As Integer = .Selection.FirstRow
                Dim Columna As Integer = .Selection.FirstCol

                Select Case e.KeyCode
                    Case Keys.F8
                        .Selection.DeleteByRow()
                    Case Keys.Delete
                        Return
                End Select
            End With

        Catch ex As Exception
            HandleError(Me.Name, "GestionaGridFacturasVariasRemisiones", ex)
        End Try
    End Sub

    Private Sub CargaRemisionesCliente()
        Const sProcedure As String = "CargaRemisionesCliente"
        Try
            If txtLEN(Me.TxtCliente.Text) = False Then
                MsgBox("Capture un código de cliente.", MsgBoxStyle.Exclamation, sProcedure)
                Me.TxtCliente.Focus()
                Return
            End If

            'No usamos este método porque recordemos que el datasource no deja borrar renglones con código directamente al grid, sino a los datatable
            'Me.GridFacturasVariasRemisiones.DataSource = oVenta.ObtenerRemisionesCliente(Me.TxtCliente.Text)

            'Para evitar hacks mejor se elimina toda la información de ambos grids
            Me.InicializaGrid()
            Me.InicializaGridSeries()
            Me.Totales()
            Me.CalculaUtilidad()

            Dim dt As DataTable = oVenta.ObtenerRemisionesCliente(Me.TxtCliente.Text)
            Me.InicializaGridFacturasVariasRemisiones()

            Me.GridFacturasVariasRemisiones.AutoRedraw = False
            Me.GridFacturasVariasRemisiones.Rows = 1
            For Each dRow As DataRow In dt.Rows
                Me.GridFacturasVariasRemisiones.AddItem(dRow("FOLIO_VENTA").ToString & Chr(9) & dRow("FECHA").ToString & Chr(9) & dRow("TOTAL").ToString & Chr(9) & dRow("CODIGO_MONEDA_SAT").ToString & Chr(9) &
                                                          dRow("CONCEPTO").ToString & Chr(9))
            Next
            Me.FormateaGridFacturasVariasRemisiones()
            If dt.Rows.Count = 0 Then
                MsgBox("No hay remisiones que se puedan facturar.", MsgBoxStyle.Exclamation, sProcedure)
            End If
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        Finally
            Me.GridFacturasVariasRemisiones.AutoRedraw = True
            Me.GridFacturasVariasRemisiones.Refresh()
        End Try
    End Sub

    Private Sub CargaDetalleRemisiones()
        Dim i As Integer
        Dim FoliosRemisiones As String = ""

        Try
            Me.GridFacturasVariasRemisiones.Locked = True

            For i = 1 To Me.GridFacturasVariasRemisiones.Rows - 1
                FoliosRemisiones = FoliosRemisiones & "'" & Me.GridFacturasVariasRemisiones.Cell(i, Me.iGyFolio).Text & "',"
            Next

            FoliosRemisiones = Strings.Left(FoliosRemisiones, FoliosRemisiones.Length - 1) 'Quita la ultima coma

            Me.Grid.DataSource = oVenta.ObtenerDetalleVariasRemisiones(FoliosRemisiones)
            Me.FormateaGrid()

            Me.Totales()
            Me.CalculaUtilidad()

            With Me.Grid
                .Column(igyCodigo).Locked = True
                .Column(igyCantidad).Locked = True
                .Column(igyCantidadKilos).Locked = True
                .Column(igyCodigoCentroCosto).Locked = True
            End With
            Me.TabControl1.SelectTab(0) 'Muestra el tab de articulos

            EsFacturaVariasRemisiones = True
        Catch ex As Exception
            HandleError(Me.Name, "CargaDetalleRemisiones", ex)
        End Try
    End Sub

    Private Function ValidaDescuentos() As Boolean
        Const sProcedure As String = "ValidaDescuentos"
        Try
            Dim i As Integer, dCantidad As Decimal = 0, dPrecio As Decimal = 0, dImporte As Decimal = 0, dDescuento As Decimal = 0
            With Me.Grid
                For i = 1 To .Rows - 1
                    If txtLEN(.Cell(i, Me.igyCodigo).Text) = True AndAlso Me.Grid.Cell(i, Me.igyCodigo).Text <> "-" Then
                        dCantidad = valorNumericoD(.Cell(i, Me.igyCantidad).Text)
                        dPrecio = valorNumericoD(.Cell(i, Me.igyPrecio).Text)
                        dImporte = RedondearD(dCantidad * dPrecio, 2)
                        dDescuento = valorNumericoD(.Cell(i, Me.iGyDESCUENTO_IMPORTE).Text)

                        If dDescuento < 0 Then
                            MsgBox("El descuento debe ser una cantidad positiva, revise el renglón #" & i.ToString, vbExclamation, sProcedure)
                            Return False
                        End If

                        If dDescuento > dImporte Then
                            MsgBox("El descuento no puede ser mayor que el importe, revise el renglón #" & i.ToString, vbExclamation, sProcedure)
                            Return False
                        End If

                    End If
                Next
            End With

            Return True
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Function

    Private Function SubirXML() As Boolean
        Const sProcedure As String = "SubirXML"
        Dim bResultado As Boolean = False
        Try
            Dim OpenFileDialog1 As New OpenFileDialog(), sRutaXML As String = ""

            With OpenFileDialog1
                .Filter = "xml files (*.xml)|*.xml"
                .Title = "Seleccione un xml"
                .RestoreDirectory = True
                .Multiselect = False

                If .ShowDialog() = DialogResult.OK Then
                    sRutaXML = .FileName
                End If
            End With

            OpenFileDialog1.Dispose()

            If txtLEN(sRutaXML) = True Then
                bResultado = Me.oVenta.SubeXMLExterno(sRutaXML)
            End If

            If bResultado = True Then
                MsgBox("XML agregado satisfactoriamente.", MsgBoxStyle.Information, sProcedure)
                Me.Consultar()
            End If

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    Private Function ValidaPrecios() As Boolean
        Const sProcedure As String = "ValidaPrecios"
        Try
            Dim i As Integer, dPrecio As Decimal = 0, dCosto As Decimal = 0, dUtilidadPorcentaje As Decimal = 0
            Dim oPrecio As Class_CatPreciosVenta, oPrecioMatriz As Class_CatPreciosVenta

            With Me.Grid
                For i = 1 To .Rows - 1
                    If txtLEN(.Cell(i, Me.igyCodigo).Text) = True AndAlso Me.Grid.Cell(i, Me.igyCodigo).Text <> "-" Then
                        dPrecio = valorNumericoD(.Cell(i, Me.igyPrecio).Text)
                        dCosto = valorNumericoD(.Cell(i, Me.igyCosto).Text)
                        dUtilidadPorcentaje = valorNumericoD(.Cell(i, Me.igyUtilidadPorcentaje).Text)

                        If Empresa_Sistema.PORCENTAJE_UTLIDAD_VENTA_MINIMO > 0 Then 'Valida por porcentaje de utilidad
                            oPrecio = New Class_CatPreciosVenta(Me.Grid.Cell(i, Me.igyCodigo).Text, Plaza.CODIGO_PLAZA)
                            oPrecioMatriz = New Class_CatPreciosVenta(Me.Grid.Cell(i, Me.igyCodigo).Text, 1)

                            'Si el articulo existe en el catalogo se valida el porcentaje de ahi si no el de la empresa
                            If oPrecio.Existe And oPrecio.PORCENTAJE_MARGEN_UTILIDAD > 0 Then
                                If dUtilidadPorcentaje < oPrecio.PORCENTAJE_MARGEN_UTILIDAD Then
                                    Dim validaPass As New Frm_Contraseña_Cambio_Periodo
                                    validaPass.Mensaje = "El porcentaje de utilidad del artículo " & .Cell(i, Me.igyDescripcion).Text & " es menor que la utilidad minima configurada para el artículo (" & oPrecio.PORCENTAJE_MARGEN_UTILIDAD.ToString & "%)."
                                    validaPass.TipoContraseña = Frm_Contraseña_Cambio_Periodo.eTipoContraseña.PrecioMenorCosto
                                    validaPass.ShowDialog()

                                    If validaPass.bContraseñaValida = False Then
                                        Return False
                                    End If
                                    validaPass.Dispose()
                                End If

                            ElseIf oPrecioMatriz.Existe And oPrecioMatriz.PORCENTAJE_MARGEN_UTILIDAD > 0 Then
                                If dUtilidadPorcentaje < oPrecioMatriz.PORCENTAJE_MARGEN_UTILIDAD Then
                                    Dim validaPass As New Frm_Contraseña_Cambio_Periodo
                                    validaPass.Mensaje = "El porcentaje de utilidad del artículo " & .Cell(i, Me.igyDescripcion).Text & " es menor que la utilidad minima configurada para el artículo (" & oPrecioMatriz.PORCENTAJE_MARGEN_UTILIDAD.ToString & "%)."
                                    validaPass.TipoContraseña = Frm_Contraseña_Cambio_Periodo.eTipoContraseña.PrecioMenorCosto
                                    validaPass.ShowDialog()

                                    If validaPass.bContraseñaValida = False Then
                                        Return False
                                    End If
                                    validaPass.Dispose()
                                End If

                            Else
                                If dUtilidadPorcentaje < Empresa_Sistema.PORCENTAJE_UTLIDAD_VENTA_MINIMO Then
                                    Dim validaPass As New Frm_Contraseña_Cambio_Periodo
                                    validaPass.Mensaje = "El porcentaje de utilidad del artículo " & .Cell(i, Me.igyDescripcion).Text & " es menor que la utilidad minima configurada en la empresa (" & Empresa_Sistema.PORCENTAJE_UTLIDAD_VENTA_MINIMO.ToString & "%)."
                                    validaPass.TipoContraseña = Frm_Contraseña_Cambio_Periodo.eTipoContraseña.PrecioMenorCosto
                                    validaPass.ShowDialog()

                                    If validaPass.bContraseñaValida = False Then
                                        Return False
                                    End If
                                    validaPass.Dispose()
                                End If
                            End If

                            oPrecio = Nothing
                            oPrecioMatriz = Nothing

                        Else 'Validacion normal
                            If dPrecio < dCosto Then
                                Dim validaPass As New Frm_Contraseña_Cambio_Periodo
                                validaPass.Mensaje = "El precio del artículo " & .Cell(i, Me.igyDescripcion).Text & " es menor que el costo " &
                                Format(dCosto, "$ ###,###,##0." & StrDup(Me.iDecimalesPrecio, "0")) & vbCrLf &
                                 "Renglón #" & i.ToString
                                validaPass.TipoContraseña = Frm_Contraseña_Cambio_Periodo.eTipoContraseña.PrecioMenorCosto
                                validaPass.ShowDialog()

                                If validaPass.bContraseñaValida = False Then
                                    Return False
                                End If
                                validaPass.Dispose()
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

    Private Sub GestionaMoneda()
        Const sProcedure As String = "GestionaMoneda"
        Try
            If Me.cboMoneda.Text = "USD" Then
                Me.txtTipoCambio.Visible = True : Me.txtTipoCambio.Enabled = True : Me.lblDisplayTipoCambio.Visible = True
                Me.gbDolares.Visible = True
                If Me.oDocumento.AFECTA_CXC = True Then
                    Me.lblSaldoDolares.Visible = True : Me.lblDisplaySaldoDolares.Visible = True
                    Me.lblSaldo.Visible = True : Me.lblDisplaySaldo.Visible = True
                Else
                    Me.lblSaldoDolares.Visible = False : Me.lblDisplaySaldoDolares.Visible = False
                    Me.lblSaldo.Visible = False : Me.lblDisplaySaldo.Visible = False
                End If
                Me.lblIEPSIncluido_USD.Visible = True : Me.lblDisplayIEPSIncluido_USD.Visible = True

                If Me.bCrearonColumnas = True Then 'Esta esto porque por cuestiones de eventos se lanza primero este antes de inicializar la 1era vez la forma.
                    'Estas 3 columnas son editables, y se gestiona su bloqueo/desbloqueo según el tipo de moneda
                    Me.Grid.Column(Me.igyPrecio).Locked = True
                    Me.Grid.Column(Me.igyPrecio_USD).Locked = False
                    Me.Grid.Column(Me.iGyDESCUENTO_IMPORTE).Locked = True
                    Me.Grid.Column(Me.iGyDESCUENTO_IMPORTE_USD).Locked = False

                    Me.Grid.Column(Me.igyPrecio_USD).Visible = True
                    Me.Grid.Column(Me.igyPRECIO_TOTAL_USD).Visible = True
                    Me.Grid.Column(Me.igyImporte_USD).Visible = True
                    Me.Grid.Column(Me.iGyDESCUENTO_IMPORTE_USD).Visible = True

                    Me.Grid.Column(Me.igyPRECIO_TOTAL).Visible = False
                    Me.Grid.Column(Me.igyImporte).Visible = False
                    Me.Grid.Column(Me.iGyDESCUENTO_IMPORTE).Visible = False
                End If

                If Empresa_Sistema.TIPO_CAMBIO_POR_DIA = True Then
                    ObtenerTipoCambioDia()
                End If
            Else 'Es moneda en MXN o esta en blanco
                Me.txtTipoCambio.Text = "0"
                Me.txtTipoCambio.Visible = False : Me.txtTipoCambio.Enabled = False : Me.lblDisplayTipoCambio.Visible = False
                Me.gbDolares.Visible = False
                If Me.oDocumento.AFECTA_CXC = True Then
                    Me.lblSaldoDolares.Visible = False : Me.lblDisplaySaldoDolares.Visible = False
                    Me.lblSaldo.Visible = True : Me.lblDisplaySaldo.Visible = True
                Else
                    Me.lblSaldoDolares.Visible = False : Me.lblDisplaySaldoDolares.Visible = False
                    Me.lblSaldo.Visible = False : Me.lblDisplaySaldo.Visible = False
                End If
                Me.lblSaldoDolares.Visible = False : Me.lblDisplaySaldoDolares.Visible = False
                Me.lblIEPSIncluido_USD.Visible = False : Me.lblDisplayIEPSIncluido_USD.Visible = False


                If Me.bCrearonColumnas = True Then
                    'Estas 3 columnas son editables, y se gestiona su bloqueo/desbloqueo según el tipo de moneda
                    Me.Grid.Column(Me.igyPrecio).Locked = False
                    Me.Grid.Column(Me.igyPrecio_USD).Locked = True
                    Me.Grid.Column(Me.iGyDESCUENTO_IMPORTE).Locked = False
                    Me.Grid.Column(Me.iGyDESCUENTO_IMPORTE_USD).Locked = True

                    Me.Grid.Column(Me.igyPrecio_USD).Visible = False
                    Me.Grid.Column(Me.igyPRECIO_TOTAL_USD).Visible = False
                    Me.Grid.Column(Me.igyImporte_USD).Visible = False
                    Me.Grid.Column(Me.iGyDESCUENTO_IMPORTE_USD).Visible = False

                    Me.Grid.Column(Me.igyPRECIO_TOTAL).Visible = True
                    Me.Grid.Column(Me.igyImporte).Visible = True
                    Me.Grid.Column(Me.iGyDESCUENTO_IMPORTE).Visible = True
                End If
            End If

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Sub ObtenerTipoCambioDia()
        Dim oTipoCambio As New Class_CatTiposCambio(Me.dpFecha.Value)
        Me.txtTipoCambio.Enabled = False
        Me.txtTipoCambio.Text = "0"

        If oTipoCambio.Existe AndAlso oTipoCambio.TIPO_DE_CAMBIO > 0 Then
            Me.txtTipoCambio.Text = oTipoCambio.TIPO_DE_CAMBIO.ToString
        Else
            If Me.cboMoneda.Text = "USD" Then
                MsgBox("No se ha capturado el tipo de cambio del día.", MsgBoxStyle.Exclamation, Me.Text)
            End If
        End If
    End Sub

    Private Sub DesplegarRegimenesFiscales()
        Try
            Dim oRegimenes As New Class_CFDCatTiposRegimenesFiscales
            With Me.cboRegimenFiscalEmisor
                .DisplayMember = "NOMBRE_REGIMEN_FISCAL"
                .ValueMember = "CODIGO_REGIMEN_FISCAL"
                Dim dView As New Data.DataView(oRegimenes.ObtenerElementosSeleccionables)
                dView.Sort = "NOMBRE_REGIMEN_FISCAL"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedValue = Empresa_Sistema.CODIGO_REGIMEN_FISCAL.ToString
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarRegimenesFiscales", ex)
        End Try
    End Sub

    Private Function TieneArticulosInventariables() As String
        Const sProcedure As String = "TieneArticulosInventariables"
        Dim sResultado As String = ""
        Dim oArticulos As Class_CatArticulos
        Try
            For i = 1 To Me.Grid.Rows - 1
                If Len(Me.Grid.Cell(i, Me.igyCodigo).Text) > 0 Then
                    oArticulos = New Class_CatArticulos(Me.Grid.Cell(i, Me.igyCodigo).Text)
                    If oArticulos.INVENTARIABLE = "1" Then
                        sResultado = sResultado & Me.Grid.Cell(i, Me.igyCodigo).Text & "-" & Me.Grid.Cell(i, Me.igyDescripcion).Text & vbCrLf
                    End If
                End If
            Next i
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try

        Return sResultado
    End Function
    Private Sub btnTimbradoTrasladoPrueba_Click(sender As Object, e As EventArgs) Handles btnTimbradoTrasladoPrueba.Click
        'If Me.oVenta.GeneraFacturaElectronica(True, True) = True Then
        Dim oVenta As New Class_Ventas_Global("F-613")
        Dim sRutaXML As String = "C:\BsControl\FELECTRONICA\SEIN_ACU\Xmls_Pdfs\CULIACAN\F-613.xml"
        If FacturacionElectronica33.GeneraFacturaTrasladoElectronica33(oVenta, True, sRutaXML) Then
            MsgBox("bien")
        End If
    End Sub

    Private Function ValidaComplementoCartaPorte() As Boolean
        Const sProcedure As String = "ValidaComplementoCartaPorte"
        Dim bResultado As Boolean = False
        Try
            Dim oCliente As New Class_CatClientes(Me.TxtCliente.Text)

            If oCliente.RFC <> Empresa_Sistema.RFC Then
                MsgBox("Para las facturas de traslado el SAT exige que el Receptor.RFC(" & oCliente.RFC & ") debe ser igual que el Emisor.RFC(" & Empresa_Sistema.RFC & ") ", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            bResultado = True
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
        Return bResultado
    End Function

    Private Function GestionaCartaPorte() As Boolean
        Const sProcedure As String = "GestionaCartaPorte"
        Dim bResultado As Boolean = False
        Try
            Dim oPantallaCartaPorte As New Ventas_CartaPorte(Me.txtFolio.Text) '("F-613")
            oPantallaCartaPorte.ShowDialog()
            Dim oCartaPorte As New Class_CartaPorte(Me.txtFolio.Text)
            If oCartaPorte.Existe = True Then
                bResultado = True
            End If
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
        Return bResultado
    End Function

    Private Function CargaDetalleRemisionesSeries() As Boolean
        Const sProcedure As String = "CargaDetalleRemisionesSeries"
        Dim i As Integer, bResultado As Boolean
        Dim FoliosRemisiones As String = ""

        Try
            Me.GridFacturasVariasRemisiones.Locked = True 'Ya que se cargaron se bloquea la edición, si quieren pueden listar nuevamente.

            For i = 1 To Me.GridFacturasVariasRemisiones.Rows - 1
                If txtLEN(Me.GridFacturasVariasRemisiones.Cell(i, Me.iGyFolio).Text) = True Then
                    FoliosRemisiones = FoliosRemisiones & "'" & Me.GridFacturasVariasRemisiones.Cell(i, Me.iGyFolio).Text & "',"
                End If
            Next
            If txtLEN(FoliosRemisiones) = False Then
                MsgBox("Debe listar primero las remisiones", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            FoliosRemisiones = Strings.Left(FoliosRemisiones, FoliosRemisiones.Length - 1) 'Quita la ultima coma

            Me.InicializaGrid()
            Me.Grid.AutoRedraw = False
            Me.Grid.Rows = 1
            i = 1

            'Me.Grid.DataSource = oVenta.ObtenerDetalleVariasRemisionesSeries(FoliosRemisiones)
            'Es mejor hacerlo de esta forma para que pueda funcionar el F8
            Dim dtRenglones As DataTable = oVenta.ObtenerDetalleVariasRemisionesSeries(FoliosRemisiones)
            For Each dRow As DataRow In dtRenglones.Rows
                Me.Grid.AddItem(
dRow("CODIGO_ARTICULO").ToString & Chr(9) & dRow("TIPO_CONTROL_INVENTARIO").ToString & Chr(9) & dRow("DESCRIPCION").ToString & Chr(9) & dRow("DISPONIBLE").ToString & Chr(9) & dRow("PRECIO_SIN_DESCUENTO").ToString & Chr(9) &
dRow("PRECIO_SIN_DESCUENTO_USD").ToString & Chr(9) & dRow("PRECIO_TOTAL").ToString & Chr(9) & dRow("PRECIO_TOTAL_USD").ToString & Chr(9) & dRow("UNIDAD_VENTA").ToString & Chr(9) & dRow("CANTIDAD_KILOS").ToString & Chr(9) &
dRow("PRECIO_KILOS").ToString & Chr(9) & dRow("IMPUESTO_PORCENTAJE").ToString & Chr(9) & dRow("IMPORTE").ToString & Chr(9) & dRow("IMPORTE_USD").ToString & Chr(9) & dRow("IMPORTE_KILOS").ToString & Chr(9) &
dRow("CUENTA_CONTABLE").ToString & Chr(9) & dRow("IMPUESTO_IMPORTE").ToString & Chr(9) & dRow("IMPUESTO_IMPORTE_USD").ToString & Chr(9) & dRow("ID_ORIGEN").ToString & Chr(9) & dRow("ES_PRODUCTO_KILOS").ToString & Chr(9) &
dRow("CODIGO_CENTRO_COSTO").ToString & Chr(9) & dRow("NOMBRE_CENTRO_COSTO").ToString & Chr(9) & dRow("IEPS_PORCENTAJE").ToString & Chr(9) & dRow("IEPS_UNITARIO").ToString & Chr(9) & dRow("IEPS_UNITARIO_USD").ToString & Chr(9) &
dRow("IEPS_IMPORTE").ToString & Chr(9) & dRow("IEPS_IMPORTE_USD").ToString & Chr(9) & dRow("BASE_IEPS").ToString & Chr(9) & dRow("BASE_IEPS_USD").ToString & Chr(9) & dRow("BASE_IVA").ToString & Chr(9) &
dRow("BASE_IVA_USD").ToString & Chr(9) & dRow("COSTO").ToString & Chr(9) & dRow("UTILIDAD_UNITARIA").ToString & Chr(9) & dRow("UTILIDAD_TOTAL").ToString & Chr(9) & dRow("UTILIDAD_PORCENTAJE").ToString & Chr(9) &
dRow("ID_SIS_CAT_IMPUESTOS").ToString & Chr(9) & dRow("GRADO_TOXICIDAD").ToString & Chr(9) & dRow("DESCUENTO_UNITARIO").ToString & Chr(9) & dRow("DESCUENTO_UNITARIO_USD").ToString & Chr(9) & dRow("DESCUENTO_IMPORTE").ToString & Chr(9) &
dRow("DESCUENTO_IMPORTE_USD").ToString & Chr(9) & dRow("PRECIO_SIN_DESCUENTO").ToString & Chr(9) & dRow("PRECIO_SIN_DESCUENTO_USD").ToString & Chr(9) & dRow("RETENCION_IVA_TIENE").ToString & Chr(9) & dRow("RETENCION_IVA_PORCENTAJE").ToString & Chr(9) &
dRow("RETENCION_IVA_BASE").ToString & Chr(9) & dRow("RETENCION_IVA_BASE_USD").ToString & Chr(9) & dRow("RETENCION_IVA_IMPORTE").ToString & Chr(9) & dRow("RETENCION_IVA_IMPORTE_USD").ToString & Chr(9) & dRow("RETENCION_ISR_TIENE").ToString & Chr(9) &
dRow("RETENCION_ISR_PORCENTAJE").ToString & Chr(9) & dRow("RETENCION_ISR_BASE").ToString & Chr(9) & dRow("RETENCION_ISR_BASE_USD").ToString & Chr(9) & dRow("RETENCION_ISR_IMPORTE").ToString & Chr(9) & dRow("RETENCION_ISR_IMPORTE_USD").ToString & Chr(9)
)
                Me.Grid.Cell(i, Me.igyCodigo).Locked = True 'Bloqueamos la celda del código porque no es válido editar, si se ocupa quitar quelo hagan con f8, no es válido cambiar por otro código en este modo.
                i += 1
            Next

            Me.Grid.Rows += 1
            Me.FormateaGrid()
            Me.Totales()
            Me.CalculaUtilidad()

            'With Me.Grid
            '    .Column(igyCodigo).Locked = True
            '    .Column(igyCantidad).Locked = True
            '    .Column(igyCantidadKilos).Locked = True
            '    .Column(igyCodigoCentroCosto).Locked = True
            'End With

            Me.dtSeries = oVenta.ObtenerSeriesVariasRemisionesSeries(FoliosRemisiones)
            Me.RecargarGridSeries()

            Me.TabControl1.SelectTab(0) 'Muestra el tab de articulos

            Me.EsFacturaVariasRemisiones = True
            Me.sTipoVenta = "SR"
            bResultado = True
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        Finally
            Me.Grid.AutoRedraw = True
            Me.Grid.Refresh()
        End Try
        Return bResultado
    End Function

    Private Sub RecargarGridSeries()
        Const sProcedure As String = "RecargarSeries"
        Try
            Me.InicializaGridSeries()
            Me.GridSeries.Rows = 1
            For Each dRow As DataRow In Me.dtSeries.Rows
                Me.GridSeries.AddItem(dRow("POSICION").ToString & Chr(9) & dRow("CODIGO_ARTICULO").ToString & Chr(9) & dRow("DESCRIPCION").ToString & Chr(9) &
                                                  dRow("ID_INVENTARIO_LOTES_COSTOS").ToString & Chr(9) & dRow("NUMERO_SERIE").ToString & Chr(9) &
                                                  dRow("ID_ORIGEN").ToString & Chr(9) & dRow("FOLIO_REMISION").ToString & Chr(9))
            Next
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Sub Regenerar_dtSeries()
        Const sProcedure As String = "Regenerar_dtSeries"
        Try
            Me.Inicializa_dtSeries()
            For i As Integer = 1 To Me.GridSeries.Rows - 1
                If txtLEN(Me.GridSeries.Cell(i, Me.igySerieCodigo).Text) = True Then
                    Dim dRow As DataRow = Me.dtSeries.NewRow

                    dRow("POSICION") = Me.GridSeries.Cell(i, Me.igySeriePosicion).Text
                    dRow("CODIGO_ARTICULO") = Me.GridSeries.Cell(i, Me.igySerieCodigo).Text
                    dRow("DESCRIPCION") = Me.GridSeries.Cell(i, Me.igySerieDescripcion).Text
                    dRow("ID_INVENTARIO_LOTES_COSTOS") = Me.GridSeries.Cell(i, Me.igySerieIdInventarioLotesCostos).Text
                    dRow("NUMERO_SERIE") = Me.GridSeries.Cell(i, Me.igySerieNumeroSerie).Text
                    dRow("ID_ORIGEN") = Me.GridSeries.Cell(i, Me.igySerieIDOrigen).Text
                    dRow("FOLIO_REMISION") = Me.GridSeries.Cell(i, Me.igySerieFolioRemision).Text

                    Me.dtSeries.Rows.Add(dRow)
                End If
            Next
            Me.dtSeries.AcceptChanges()
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Function GestionaSeriesPosicion(ByVal iPosicion As Integer, bEliminarPosicion As Boolean) As Boolean
        Const sProcedure As String = "GestionaSeriesPosicion"
        Dim bResultado As Boolean = False
        Try
            Dim oArticulo As New Class_CatArticulos(Me.Grid.Cell(iPosicion, Me.igyCodigo).Text)
            If oArticulo.Existe = True AndAlso oArticulo.ES_SERIALIZABLE = True AndAlso oArticulo.INVENTARIABLE = "1" Then ' AndAlso valorNumericoD(Me.Grid.Cell(iPosicion, Me.igyIdOrigen).Text) = 0 Then
                Dim iCantidad As Integer = CInt(valorNumericoD(Me.Grid.Cell(iPosicion, Me.igyCantidad).Text))
                Dim iNumeroSeriesEncontradas As Integer = 0, iCantidadSeriesFaltantes As Integer = 0

                Me.Regenerar_dtSeries() 'Nota recuerde que dtSeries ya no esta ligado con datasource al grid asi que para usarlo antes hay que regenerarlo o bien trabajar directo con el gridSeries y no con dtSeries

                iNumeroSeriesEncontradas = CInt(Me.dtSeries.Compute("COUNT(POSICION)", "POSICION=" & iPosicion.ToString))

                If bEliminarPosicion = True AndAlso iNumeroSeriesEncontradas > 0 Then
                    MsgBox("Aviso, de este renglón hay series y se eliminarán automáticamente del listado de series.", MsgBoxStyle.Information, sProcedure)
                    For Each dRow As DataRow In Me.dtSeries.Select("POSICION='" & iPosicion.ToString & "'") 'Este campo es string si no se le ponen las comillas no funciona bien.
                        dRow.Delete()
                    Next

                    'Si se eliminó un renglón, todas las series hacia arriba de ese número hay que restarles al campo posición 1 es decir recorrerlas hacia abajo para que exista correspondencia.
                    For Each dRow As DataRow In Me.dtSeries.Select("POSICION>'" & iPosicion.ToString & "'") 'Este campo es string si no se le ponen las comillas no funciona bien.
                        dRow("POSICION") = CInt(dRow("POSICION")) - 1
                    Next

                    Me.dtSeries.AcceptChanges()
                    Me.RecargarGridSeries()
                    Return True 'Salimos del proceso por que lo siguiente ya no tiene que ver con eliminar la posición.
                End If

                If iCantidad < iNumeroSeriesEncontradas Then
                    MsgBox("Usted debe de borrar " & (iNumeroSeriesEncontradas - iCantidad).ToString & " series sobrantes con F8 de este artículo.", MsgBoxStyle.Information, sProcedure)

                ElseIf iCantidad > iNumeroSeriesEncontradas Then
                    If valorNumericoD(Me.Grid.Cell(iPosicion, Me.igyIdOrigen).Text) > 0 Then
                        'Esto sucede si por ejemplo facturan una remisión donde un artículo seriado tiene cantidad 2 , luego editan la cantidad a 1, borran con F8 una serie, y leugo ponen 2 en cantidad
                        'No tenemos forma fácil de regenerar esa serie asi que marcamos que deben reiniciar todo el proceso.
                        MsgBox("Este renglón proviene de una remisión y primero le bajó a la cantidad y ahora le subió, debe empezar desde cero todo el proceso de facturar varias remisiones.", MsgBoxStyle.Exclamation, sProcedure)
                        Return False
                    End If

                    iCantidadSeriesFaltantes = iCantidad - iNumeroSeriesEncontradas
                    MsgBox("Se van a crear en automático los espacios para las " & iCantidadSeriesFaltantes.ToString & " series faltantes, por favor indique el número de serie en cada espacio.", MsgBoxStyle.Information, sProcedure)

                    Dim dRow As DataRow
                    For i As Integer = 1 To iCantidadSeriesFaltantes
                        dRow = Me.dtSeries.NewRow

                        dRow("POSICION") = iPosicion
                        dRow("CODIGO_ARTICULO") = Me.Grid.Cell(iPosicion, Me.igyCodigo).Text
                        dRow("DESCRIPCION") = Me.Grid.Cell(iPosicion, Me.igyDescripcion).Text
                        dRow("ID_INVENTARIO_LOTES_COSTOS") = ""
                        dRow("NUMERO_SERIE") = ""
                        dRow("ID_ORIGEN") = ""
                        dRow("FOLIO_REMISION") = ""

                        Me.dtSeries.Rows.Add(dRow)
                    Next
                    Me.dtSeries.AcceptChanges()

                    Me.RecargarGridSeries()
                End If
            End If

            bResultado = True

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    Private Sub chkTieneCCE_CheckedChanged(sender As Object, e As EventArgs) Handles chkTieneCCE.CheckedChanged
        If Me.chkTieneCCE.Checked = True Then
            Me.cboIncoterm.Visible = True : Me.lblDisplayIncoterm.Visible = True
        Else
            Me.cboIncoterm.Visible = False : Me.lblDisplayIncoterm.Visible = False
        End If
    End Sub

    Private Sub chkTieneCartaPorte_CheckedChanged(sender As Object, e As EventArgs) Handles chkTieneCartaPorte.CheckedChanged
        If Me.chkTieneCartaPorte.Checked = True Then
            Me.cboMoneda.Text = "XXX"
            Me.cboMoneda.Enabled = False
        Else
            Me.cboMoneda.SelectedIndex = -1
            Me.cboMoneda.Enabled = True
        End If
    End Sub

    Public Function ValidaComplementoComercioExterior() As Boolean
        Dim bResultado As Boolean = False
        Const sProcedure As String = "ValidaComplementoComercioExterior"
        Try
            If Me.cboMoneda.Text <> "USD" Then
                MsgBox("La venta debe grabarse en USD.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            If valorNumericoD(Me.txtTipoCambio.Text) <= 0 Then
                MsgBox("Falta indicar el tipo de cambio.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            Dim oCliente As New Class_CatClientes(Me.TxtCliente.Text)

            If oCliente.RFC = Empresa_Sistema.RFC_EXTRANJERO Then
                If txtLEN(oCliente.NUMERO_IDENTIFICACION_REGISTRO_FISCAL_EXTRANJERO) = False Then
                    MsgBox("Al cliente le falta configurar el número de registro de identificación fiscal extranjero.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If

                If oCliente.NUMERO_IDENTIFICACION_REGISTRO_FISCAL_EXTRANJERO.Length < 6 Then
                    MsgBox("El número de registro de identificación fiscal extranjero del cliente debe ser 6 caracteres mínimo.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If
            End If

            For i = 1 To Me.Grid.Rows - 1
                If txtLEN(Me.Grid.Cell(i, Me.igyCodigo).Text) = True Then
                    Dim oArticulo As New Class_CatArticulos(Me.Grid.Cell(i, Me.igyCodigo).Text)
                    If oArticulo.FRACCION_ARANCELARIA.Length = 0 Then
                        MsgBox("El artículo " & oArticulo.CODIGO_ARTICULO & "-" & oArticulo.DESCRIPCION & " no tiene fracción arancelaria y es obligatoria para timbrar CCE.", MsgBoxStyle.Exclamation, sProcedure)
                        Return False
                    End If

                    If oArticulo.CODIGO_UNIDAD <> "KGM" AndAlso oArticulo.FACTOR_CONVERSION = 0 Then
                        MsgBox("El artículo " & oArticulo.CODIGO_ARTICULO & "-" & oArticulo.DESCRIPCION & " no es en kilos por lo que debe especificar el factor de conversión para poder calcular los valores a kilos para el CCE.", MsgBoxStyle.Exclamation, sProcedure)
                        Return False
                    End If
                End If
            Next

            If Me.cboIncoterm.SelectedIndex = -1 Then
                MsgBox("Seleccione el tipo de incoterm.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            bResultado = True

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    Private Sub DesplegarIncoterm()
        Const sProcedure As String = "DesplegarIncoterm"
        Dim dView As New Data.DataView
        Try
            Dim oIncoterm As New Class_CatCfdiIncoterm
            With Me.cboIncoterm
                .DisplayMember = "NOMBRE_INCOTERM"
                .ValueMember = "CODIGO_INCOTERM"
                dView = New Data.DataView(oIncoterm.ObtenerElementos)
                .DataSource = dView
                '.SelectedIndex = -1
                .SelectedValue = "DDP" 'DDP=ENTREGADA DERECHOS PAGADOS (LUGAR DE DESTINO CONVENIDO).
            End With
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Sub InicializaControlesComplementoINE()
        Me.TxtIdContabilidadEntidad.Text = ""
        Me.TxtIdContabilidad.Text = ""
        Me.InicializaGridEntidadesINE()
        Me.DesplegarProcesos()
        Me.DesplegarComites()
        Me.DesplegarEntidades()
        Me.DesplegarAmbitos()
        Me.CboTipoComite.Enabled = False
        Me.TxtIdContabilidad.Enabled = False
        Me.GbEntidades.Enabled = False

    End Sub

    Private Sub InicializaGridEntidadesINE()
        Try
            Me.GridEntidades.DataSource = Nothing
            FG_Grid_Limpiar(Me.GridEntidades)
            Me.GridEntidades.Rows = 1
            Me.GridEntidades.Cols = 7
            Me.FormateaGridEntidadesINE()
        Catch ex As Exception
            HandleError(Me.Name, "InicializaGridEntidadesINE", ex)
        End Try
    End Sub

    Private Sub FormateaGridEntidadesINE()
        Const sProcedure As String = "FormateaGridEntidadesINE"
        Try
            With Me.GridEntidades
                .AutoRedraw = False

                .Column(Me.iGyCodigoEntidad).Width = 50
                .Column(Me.iGyNombreEntidad).Width = 300
                .Column(Me.iGyCodigoAmbito).Width = 50
                .Column(Me.iGyNombreAmbito).Width = 150
                .Column(Me.iGyIdContabiliad).Width = 150
                .Column(Me.iGyIdAdicional).Width = 20

                .Cell(0, Me.iGyCodigoEntidad).Text = "CodigoEntidad"
                .Cell(0, Me.iGyNombreEntidad).Text = "Entidad"
                .Cell(0, Me.iGyCodigoAmbito).Text = "CodigoAmbito"
                .Cell(0, Me.iGyNombreAmbito).Text = "Ambito"
                .Cell(0, Me.iGyIdContabiliad).Text = "Clave Contabilidad"
                .Cell(0, Me.iGyIdAdicional).Text = "IdAdicional"

                .Column(Me.iGyCodigoEntidad).Locked = True
                .Column(Me.iGyNombreEntidad).Locked = True
                .Column(Me.iGyCodigoAmbito).Locked = True
                .Column(Me.iGyNombreAmbito).Locked = True
                .Column(Me.iGyIdContabiliad).Locked = True
                .Column(Me.iGyIdAdicional).Locked = True

                .Column(Me.iGyCodigoEntidad).Visible = False
                .Column(Me.iGyCodigoAmbito).Visible = False
                .Column(Me.iGyIdAdicional).Visible = False

                '.Locked = True

                .AutoRedraw = True
                .Refresh()
            End With
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        Finally
            Me.GridEntidades.AutoRedraw = True
            Me.GridEntidades.Refresh()
        End Try
    End Sub

    Private Sub GestionaGridEntidades(ByVal e As System.Windows.Forms.KeyEventArgs)
        Dim sProcedure As String = "GestionaGridEntidades"
        Try
            Select Case e.KeyCode
                Case Keys.F8, Keys.Delete
                    Me.GridEntidades.Selection.DeleteByRow()

            End Select
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Sub DesplegarProcesos()
        Try
            Dim oProcesos As New Class_INE_CatTipoProcesos
            With Me.CboTipoProceso
                .DisplayMember = "NOMBRE_PROCESO"
                .ValueMember = "CODIGO_PROCESO"
                Dim dView As New Data.DataView(oProcesos.ObtenerTipoProcesos)
                dView.Sort = "CODIGO_PROCESO"
                .DataSource = dView
                .SelectedIndex = -1

            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarProcesos", ex)
        End Try
    End Sub

    Private Sub DesplegarComites()
        Try
            Dim oComites As New Class_INE_CatTipoComites
            With Me.CboTipoComite
                .DisplayMember = "NOMBRE_COMITE"
                .ValueMember = "CODIGO_COMITE"
                Dim dView As New Data.DataView(oComites.ObtenerTipoComites)
                dView.Sort = "CODIGO_COMITE"
                .DataSource = dView
                .SelectedIndex = -1

            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarComites", ex)
        End Try
    End Sub

    Private Sub DesplegarEntidades()
        Try
            Dim oEntidades As New Class_INE_CatEntidades
            With Me.CboEntidad
                .DisplayMember = "NOMBRE_ENTIDAD"
                .ValueMember = "CODIGO_ENTIDAD"
                Dim dView As New Data.DataView(oEntidades.ObtenerEntidades)
                dView.Sort = "NOMBRE_ENTIDAD"
                .DataSource = dView
                .SelectedIndex = -1

            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarEntidades", ex)
        End Try
    End Sub

    Private Sub DesplegarAmbitos()
        Try
            Dim oAmbitos As New Class_INE_CatAmbitos
            With Me.CboAmbito
                .DisplayMember = "NOMBRE_AMBITO"
                .ValueMember = "CODIGO_AMBITO"
                Dim dView As New Data.DataView(oAmbitos.ObtenerAmbitos)
                dView.Sort = "CODIGO_AMBITO"
                .DataSource = dView
                .SelectedIndex = -1

            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarAmbito", ex)
        End Try
    End Sub

    Private Sub AgregarEntidad()
        Try
            If Me.CboEntidad.SelectedIndex < 0 Then
                MsgBox("Capture una Entidad.", MsgBoxStyle.Exclamation, "AgregarEntidad")
                Me.CboEntidad.Focus()
                Return
            End If

            With Me.GridEntidades
                .Rows = .Rows + 1
                Dim renglon = .Rows - 1

                .Cell(renglon, iGyCodigoEntidad).Text = Me.CboEntidad.SelectedValue.ToString
                .Cell(renglon, iGyNombreEntidad).Text = Me.CboEntidad.Text

                If Me.CboAmbito.SelectedIndex <> -1 Then 'Este campo puede ser omitido dependiendo del tipo de Proceso
                    .Cell(renglon, iGyCodigoAmbito).Text = Me.CboAmbito.SelectedValue.ToString
                    .Cell(renglon, iGyNombreAmbito).Text = Me.CboAmbito.Text
                Else
                    .Cell(renglon, iGyCodigoAmbito).Text = "0"
                    .Cell(renglon, iGyNombreAmbito).Text = ""
                End If
                .Cell(renglon, iGyIdContabiliad).Text = Me.TxtIdContabilidadEntidad.Text

            End With

            Me.TxtIdContabilidadEntidad.Text = ""

        Catch ex As Exception
            HandleError(Me.Name, "AgregarEntidad", ex)
        End Try
        
    End Sub

    Private Function GrabarComplementoINE(ByVal sFolioVenta As String) As Boolean
        Dim bResultado As Boolean = True
        Dim oComplementoINEGlobal As Class_ComplementoINE_Global
        Dim oComplementoINEDetalle As Class_ComplementoINE_Detalle

        Try
            oComplementoINEGlobal = New Class_ComplementoINE_Global(sFolioVenta)

            With oComplementoINEGlobal
                .FOLIO_VENTA = sFolioVenta
                .CODIGO_PROCESO = CInt(Me.CboTipoProceso.SelectedValue)
                If Me.CboTipoComite.SelectedIndex <> -1 Then
                    .CODIGO_COMITE = CInt(Me.CboTipoComite.SelectedValue)
                Else
                    .CODIGO_COMITE = 0
                End If

                .ID_CONTABILIDAD = Me.TxtIdContabilidad.Text

                If .Grabar() = False Then
                    MsgBox("Error al intentar grabar los datos globales del Complemento INE.", MsgBoxStyle.Exclamation, "GrabarComplementoINE")
                    Return bResultado
                End If

            End With

            'Agregar IdAdicional
            Dim IdAdicional As Integer = 1, Entidad As String = "", Ambito As Integer = 0

            For i As Integer = 1 To Me.GridEntidades.Rows - 1
                If txtLEN(Me.GridEntidades.Cell(i, Me.iGyIdAdicional).Text) = False Then
                    Entidad = Me.GridEntidades.Cell(i, Me.iGyCodigoEntidad).Text
                    Ambito = CInt(Me.GridEntidades.Cell(i, Me.iGyCodigoAmbito).Text)
                    Me.GridEntidades.Cell(i, Me.iGyIdAdicional).Text = IdAdicional.ToString

                    For j As Integer = 1 To Me.GridEntidades.Rows - 1
                        If Me.GridEntidades.Cell(j, Me.iGyCodigoEntidad).Text = Entidad And CInt(Me.GridEntidades.Cell(j, Me.iGyCodigoAmbito).Text) = Ambito Then
                            If txtLEN(Me.GridEntidades.Cell(j, Me.iGyIdAdicional).Text) = False Then
                                Me.GridEntidades.Cell(j, Me.iGyIdAdicional).Text = IdAdicional.ToString
                            End If
                        End If
                    Next

                    IdAdicional = IdAdicional + 1
                End If
                
            Next

            'Grabar detalle Entidades
            IdAdicional = 1

            For i = 1 To Me.GridEntidades.Rows - 1
                If Me.GridEntidades.Cell(i, Me.iGyIdAdicional).Text = IdAdicional.ToString Then
                    oComplementoINEDetalle = New Class_ComplementoINE_Detalle

                    With oComplementoINEDetalle
                        .FOLIO_VENTA = sFolioVenta
                        .CODIGO_ENTIDAD = Me.GridEntidades.Cell(i, Me.iGyCodigoEntidad).Text
                        .CODIGO_AMBITO = CInt(Me.GridEntidades.Cell(i, Me.iGyCodigoAmbito).Text)

                        If .GrabarDetalleEntidades() = False Then
                            MsgBox("Error al tratar de grabar el detalle de Entidades del Complemento INE", MsgBoxStyle.Exclamation, "GrabarComplementoINE")
                            Return bResultado
                        End If

                        'Graba el detalle de Contabilidad de esta entidad antes de continuar con las demas
                        For j = i To Me.GridEntidades.Rows - 1
                            If Me.GridEntidades.Cell(j, Me.iGyIdAdicional).Text = IdAdicional.ToString Then
                                With oComplementoINEDetalle
                                    .ID_CONTABILIDAD = Me.GridEntidades.Cell(j, Me.iGyIdContabiliad).Text

                                    If .GrabarDetalleContabilidades() = False Then
                                        MsgBox("Error al tratar de grabar el detalle de Contabilidades del Complemento INE", MsgBoxStyle.Exclamation, "GrabarComplementoINE")
                                        Return bResultado
                                    End If

                                End With
                            End If

                        Next

                        IdAdicional = IdAdicional + 1

                    End With
                End If
            Next

            bResultado = True
        Catch ex As Exception
            HandleError(Me.Name, "GrabarComplementoINE", ex)
        End Try
        Return bResultado
    End Function

    Private Function ValidaDatosComplementoINE() As Boolean
        Dim sProcedure As String = "ValidaDatosComplementoINE"

        Try
            If Me.CboTipoProceso.Text = "Ordinario" Then
                If Me.CboTipoComite.SelectedIndex < 0 Then
                    MsgBox("El proceso Ordinario requiere seleccionar un tipo de Comite.", MsgBoxStyle.Exclamation, sProcedure)
                    Me.CboTipoComite.Focus()
                    Return False
                End If

                Select Case Me.CboTipoComite.Text
                    Case "Ejecutivo Nacional"
                        If Me.GridEntidades.Rows > 1 Then
                            MsgBox("En el comite Ejecutivo Nacional se debe omitir capturar Entidades.", MsgBoxStyle.Exclamation, sProcedure)
                            Return False
                        End If

                    Case "Ejecutivo Estatal", "Directivo Estatal"

                        If Me.CboTipoComite.Text = "Ejecutivo Estatal" Then
                            If txtLEN(Me.TxtIdContabilidad.Text) Then
                                MsgBox("En el comite Ejecutivo Estatal se debe omitir la Clave de Contabilidad.", MsgBoxStyle.Exclamation, sProcedure)
                                Me.TxtIdContabilidad.Focus()
                                Return False
                            End If
                        End If

                        If Me.GridEntidades.Rows <= 1 Then
                            MsgBox("El comite Ejecutivo Estatal/Directivo Estatal requiere al menos una Entidad capturada.", MsgBoxStyle.Exclamation, sProcedure)
                            Me.CboEntidad.Focus()
                            Return False
                        End If

                        For i As Integer = 1 To Me.GridEntidades.Rows - 1
                            If txtLEN(Me.GridEntidades.Cell(1, Me.iGyNombreAmbito).Text) Then
                                MsgBox("El comite Ejecutivo Estatal/Directivo Estatal requiere que se omita el tipo de Ambito en la Entidad en el renglon " & i.ToString & ".", MsgBoxStyle.Exclamation, sProcedure)
                                Return False
                            End If
                        Next

                End Select

            Else 'Precampaña/Campaña
                If Me.CboTipoComite.SelectedIndex > 0 Then
                    MsgBox("En el proceso Precampaña/Campaña se debe omitir el tipo de Comite.", MsgBoxStyle.Exclamation, sProcedure)
                    Me.CboTipoComite.SelectedIndex = -1
                    Return False
                End If

                If txtLEN(Me.TxtIdContabilidad.Text) Then
                    MsgBox("En el proceso Precampaña/Campaña se debe omitir la Clave de Contabilidad.", MsgBoxStyle.Exclamation, sProcedure)
                    Me.TxtIdContabilidad.Focus()
                    Return False
                End If

                If Me.GridEntidades.Rows <= 1 Then
                    MsgBox("El tipo de proceso Precampaña/Campaña requiere al menos una Entidad capturada.", MsgBoxStyle.Exclamation, sProcedure)
                    Me.CboEntidad.Focus()
                    Return False
                End If

                For i As Integer = 1 To Me.GridEntidades.Rows - 1
                    If txtLEN(Me.GridEntidades.Cell(1, Me.iGyCodigoAmbito).Text) = False Then
                        MsgBox("El tipo de proceso Precampaña/Campaña requiere el tipo de Ambito en todas las Entidades. Capture el tipo de Ambito en el renglon " & i.ToString & ".", MsgBoxStyle.Exclamation, sProcedure)
                        Return False
                    End If
                Next
            End If

            Return True

        Catch ex As Exception
            HandleError(Me.Name, "ValidaDatosComplementoINE", ex)
        End Try

    End Function

#End Region

End Class