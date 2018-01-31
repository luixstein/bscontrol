Option Strict On

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
    Private bClienteEsContribuyenteIEPS As Boolean = False
#End Region

#Region "Columnas grid ventas"
    Private igyCodigo As Short = 1
    Private igyTipoControlInventariable As Short = 2
    Private igyDescripcion As Short = 3
    Private igyCantidad As Short = 4
    Private igyPrecio As Short = 5
    Private igyPRECIO_TOTAL As Short = 6
    Private igyUnidad As Short = 7
    Private igyCantidadKilos As Short = 8
    Private igyPrecioKilos As Short = 9
    Private igyImpuestoPorcentaje As Short = 10
    Private igyImporte As Short = 11
    Private igyImporteKilos As Short = 12
    Private igyCuentaContable As Short = 13
    Private igyImpuestoImporte As Short = 14
    Private igyIdOrigen As Short = 15
    Private igyEsProductoKilos As Short = 16
    Private igyCodigoCentroCosto As Short = 17
    Private igyNombreCentroCosto As Short = 18
    Private igyPrecioUSD As Short = 19
    Private igyImporteUSD As Short = 20
    Private igyIEPS_PORCENTAJE As Short = 21
    Private igyIEPS_UNITARIO As Short = 22
    Private igyIEPS_IMPORTE As Short = 23
    Private igyBASE_IEPS As Short = 24
    Private igyBASE_IVA As Short = 25
    Private igyCosto As Short = 26
    Private igyUtilidadUnitaria As Short = 27
    Private igyUtilidadTotal As Short = 28
    Private igyUtilidadPorcentaje As Short = 29
    Private iGyID_SIS_CAT_IMPUESTOS As Short = 30
    Private iGyGRADO_TOXICIDAD As Short = 31
#End Region

#Region "Columnas grid series"
    Private igySeriePosicion As Short = 1
    Private igySerieCodigo As Short = 2
    Private igySerieDescripcion As Short = 3
    Private igySerieIdInventarioLotesCostos As Short = 4
    Private igySerieNumeroSerie As Short = 5
#End Region

#Region "Campos/propiedades para facturas embarques extrajeros que se incian desde otra pantalla"
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
        If Me.oDocumento.AFECTA_CXC = True Then 'El Documento tiene que estar no cancelado para llegar aqui
            If Me.oVenta.ESTATUS_VENTA = "A" Then
                If Me.CancelarVenta = True Then  'Se cancelo el documento correctamente = true
                    If Me.oVenta.VERSION_ESQUEMA_XML > "2.2" And oDocumento.TIMBRA_DOCUMENTO = True Then 'Si es CFDi
                        Me.oVenta.CancelarTimbre()
                    End If
                    MsgBox("Movimiento de venta cancelado satisfactoriamente.", MsgBoxStyle.Information, Me.Text)
                End If
                Me.Consultar()
                Me.GestionaCambioEstado()
            End If
        End If
    End Sub

    Private Sub tsbCotizacionRemision_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCotizacionRemision.Click
        sTipoVenta = "SCR" 'SUSTITUCION DE COTIZACION A REMISION
        Me.Consultar(True)
    End Sub

    Private Sub tsbCotizacionFactura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCotizacionFactura.Click
        sTipoVenta = "SCF" 'SUSTITUCION DE COTIZACION A FACTURA

        Dim oTF As New VentasSeleccionaTipoFactura
        oTF.ShowDialog()

        sCodigoDocumentoFacturaExterno = oTF.CboDocumento.SelectedValue.ToString

        If Me.Consultar(True) = True Then
            Me.EstableceCuentasContables()
            Me.Totales()
        End If
    End Sub

    Private Sub tsbRemisionVenta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRemisionVenta.Click
        sTipoVenta = "SR" 'SUSTITUCION DE REMISION

        Dim oTF As New VentasSeleccionaTipoFactura
        oTF.ShowDialog()

        sCodigoDocumentoFacturaExterno = oTF.CboDocumento.SelectedValue.ToString

        If Me.Consultar(True) = True Then
            Me.EstableceCuentasContables()
            Me.Totales()
        End If

        Me.Grid.Locked = True
    End Sub

    Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click
        'If txtLEN(Me.oVenta.SELLO_DIGITAL) = False And Me.oDocumento.AFECTA_CONTABILIDAD = True Then
        Me.oVenta.Consultar()
        If Me.oVenta.VERSION_ESQUEMA_XML >= "3.2" Then
            If txtLEN(Me.oVenta.FOLIO_FISCAL_SAT + Me.oVenta.FECHA_TIMBRADO_SAT + Me.oVenta.NUMERO_SERIE_CERTIFICADO_SAT + Me.oVenta.SELLO_SAT) = False And txtLEN(Me.oVenta.CBB_IMAGE.ToString) = False And Me.oDocumento.TIMBRA_DOCUMENTO = True Then
                MsgBox("La factura debe de estar sellada para poder imprimir.", MsgBoxStyle.Exclamation, Me.Text)
                Exit Sub
            End If
        End If
        Me.oVenta.Imprimir()
    End Sub

    Private Sub tsbTimbrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbTimbrar.Click
        If Me.oVenta.TIMBRADO_CFDI = "0" Then
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
            Me.tsbCancelarTimbre.Enabled = False
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
#End Region

#Region "Eventos de objetos"
    Private Sub Ventas_Movimientos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.DesplegarAlmacenes()
            Me.DesplegarTiposMercados()
            Me.DesplegarVendedores()

            Me.DesplegarMetodosPago()
            Me.DesplegarMonedas()
            Me.DesplegarFormasPago(False)
            Me.DesplegarTiposNegociaciones()
            Me.DesplegarTiposCredito()

            Me.DesplegarDocumentos()

            Me.Inicializa()

            Me.Cambia_Estado(enumEstados.NUEVO)

            If Not Me._oEmbarqueExtranjero Is Nothing Then
                Me.GestionaFacturaEmbarqueExtranjero()
            End If

            If Empresa_Sistema.VERSION_ESQUEMA_CFD <= "3.2" Then
                Me.txtNumeroCuentaPago.Visible = True : Me.lblDisplayNumeroCuentaPago.Visible = True
                Me.cboUsoCFDI.Visible = False : Me.lblDisplayUsoCFDI.Visible = False
                Me.cboMetodoPago.Visible = False : Me.lblDisplayMetodoPago.Visible = False
            Else '3.3 O Mayores
                Me.txtNumeroCuentaPago.Visible = False : Me.lblDisplayNumeroCuentaPago.Visible = False

                Me.cboFormaPago.Enabled = False
                Me.cboFormaPago.SelectedValue = "99" '"99-Por definir"
            End If

            Me.ckbMostrarUtilidad.Checked = False

            If Usuario.VER_COSTOS = False Then
                Me.ckbMostrarUtilidad.Visible = False
            Else
                Me.ckbMostrarUtilidad.Visible = True
            End If

        Catch ex As Exception
            HandleError(Me.Name, "Ventas_Movimientos_Load", ex)
        End Try
    End Sub

    Private Sub Ventas_Movimientos_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        ''If e.KeyCode = Keys.A  AndAlso (e.Control) Then
        'If e.Alt = True AndAlso e.Control = True AndAlso e.Shift = True AndAlso e.KeyCode = Keys.A Then
        '    MsgBox("eale")
        'End If
    End Sub

    Private Sub TxtCodigoCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCliente.KeyDown
        Dim sText As String
        Select Case e.KeyCode
            Case Keys.F6
Buscar:
                sText = Me.oCliente.BusquedaVisualPlaza
                If txtLEN(sText) = True Then Me.TxtCliente.Text = sText
            Case Keys.Enter
                If txtLEN(Me.TxtCliente.Text) = False Then
                    Me.lblCliente.Text = "" : GoTo Buscar : Exit Sub
                End If

                If Me.ConsultarCliente() = False Then
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

    Private Sub TxtFolioReferencia_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtReferencia.KeyDown
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
                If Consultar() = False Then
                    Me.cboTipoNegociacion.Focus()
                End If
        End Select
    End Sub

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dpFecha.KeyPress, dpVencimiento.KeyPress, TxtCliente.KeyPress, TxtConcepto.KeyPress,
        txtFolio.KeyPress, TxtReferencia.KeyPress, txtFolioEmbarque.KeyPress, TxtConceptoCancelacion.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub Grid_KeyDown(ByVal Sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Grid.KeyDown
        Me.GestionaGrid(e)
    End Sub

    Private Sub cboMoneda_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMoneda.SelectedIndexChanged
        Try
            If Me.cboMoneda.Text = "USD" Then
                Me.txtTipoCambio.Visible = True : Me.txtTipoCambio.Enabled = True : Me.lblDisplayTipoCambio.Visible = True
                Me.gbDolares.Visible = True

                If txtLEN(Me.TxtCliente.Text) = True Then
                    Me.EstableceFormaPagoCliente()
                End If
            Else
                Me.txtTipoCambio.Visible = False : Me.txtTipoCambio.Enabled = False : Me.lblDisplayTipoCambio.Visible = False
                Me.gbDolares.Visible = False

                If txtLEN(Me.TxtCliente.Text) = True Then
                    Me.EstableceFormaPagoCliente()
                End If
            End If
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
                If Me.cboTipoNegociacion.SelectedIndex <> -1 AndAlso Me.cboTipoNegociacion.SelectedValue.ToString = "1" Then
                    Me.txtPlazo.Enabled = True
                Else
                    Me.txtPlazo.Enabled = False
                    Me.txtPlazo.Text = Plaza.PLAZO_VENTA_CONTADO.ToString
                End If
            End If

            If CInt(cboTipoNegociacion.SelectedValue) = 1 Then ' CREDITO
                Me.LblTipoCredito.Visible = True
                Me.CboTipoCredito.Visible = True
            ElseIf CInt(cboTipoNegociacion.SelectedValue) = 2 Then ' CONTADO
                Me.LblTipoCredito.Visible = False
                Me.CboTipoCredito.Visible = False
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
                Totales()
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
        If Me.ckbMostrarUtilidad.Checked = True Then
            Me.Grid.Column(Me.igyCosto).Visible = True
            Me.Grid.Column(Me.igyUtilidadUnitaria).Visible = True
            Me.Grid.Column(Me.igyUtilidadTotal).Visible = True
            Me.Grid.Column(Me.igyUtilidadPorcentaje).Visible = True
            Me.Grid.Cell(1, Me.igyUtilidadTotal).SetFocus()
        Else
            Me.Grid.Column(Me.igyCosto).Visible = False
            Me.Grid.Column(Me.igyUtilidadUnitaria).Visible = False
            Me.Grid.Column(Me.igyUtilidadTotal).Visible = False
            Me.Grid.Column(Me.igyUtilidadPorcentaje).Visible = False
            Me.Grid.Cell(1, Me.igyImporte).SetFocus()
        End If
    End Sub

    Private Sub cboMoneda_KeyDown(sender As Object, e As KeyEventArgs) Handles cboMoneda.KeyDown
        If Me.cboMoneda.Text = "USD" And Me.txtTipoCambio.Enabled = True Then
            Me.txtTipoCambio.Focus()
        ElseIf Me.TxtCliente.Enabled = True Then
            Me.TxtCliente.Focus()
        End If
    End Sub

    Private Sub cboUsoCFDI_KeyDown(sender As Object, e As KeyEventArgs) Handles cboUsoCFDI.KeyDown
        txtTAB(e)
    End Sub

    Private Sub cboMetodoPago_KeyDown(sender As Object, e As KeyEventArgs) Handles cboMetodoPago.KeyDown
        txtTAB(e)
    End Sub
#End Region

#Region "Métodos y procedimientos"
    Private Sub Inicializa()
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

            Me.lblCliente.Text = ""
            Me.LblEstatus.Text = "N"
            Me.LblPoliza.Text = ""
            Me.lblSaldo.Text = FormatImporteContable(0)
            Me.txtTipoCambio.Text = "0"
            Me.lblSubtotalDolares.Text = FormatImporteContable(0)
            Me.lblImpuestoDolares.Text = FormatImporteContable(0)
            Me.lblTotalDolares.Text = FormatImporteContable(0)
            Me.lblSubtotal.Text = FormatImporteContable(0)
            Me.lblImpuesto.Text = FormatImporteContable(0)
            Me.lblTotal.Text = FormatImporteContable(0)

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

            Me.lblVersionCFDI.Text = ""

            'Estos no se gestionan en el cambiar el estado, se gestionan en el consultar
            Me.tsbTimbrar.Visible = False
            Me.tsbCancelarTimbre.Visible = False
            Me.tsbRecuperarXMLPDF.Visible = False
            Me.tsbEnviarCorreo.Visible = False

            Me.TabControl1.SelectedIndex = 0
            Me.bClienteEsContribuyenteIEPS = False

            Me.lblConceptoCancelacion.Visible = False
            Me.TxtConceptoCancelacion.Visible = False

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

    Private Sub FormateaGrid()
        Try
            Me.Grid.AutoRedraw = False
            Me.Grid.Cols = 32
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.Grid.Column(Me.igyCodigo).Width = 75
            Me.Grid.Column(Me.igyTipoControlInventariable).Width = 25
            Me.Grid.Column(Me.igyDescripcion).Width = 250
            Me.Grid.Column(Me.igyCantidad).Width = 90
            Me.Grid.Column(Me.igyPrecio).Width = 100
            Me.Grid.Column(Me.igyPRECIO_TOTAL).Width = 100
            Me.Grid.Column(Me.igyCantidadKilos).Visible = False
            Me.Grid.Column(Me.igyUnidad).Width = 75
            Me.Grid.Column(Me.igyPrecioKilos).Visible = False
            Me.Grid.Column(Me.igyImpuestoPorcentaje).Width = 70
            Me.Grid.Column(Me.igyImporte).Width = 100
            Me.Grid.Column(Me.igyImporteKilos).Visible = False
            Me.Grid.Column(Me.igyCuentaContable).Width = 100
            Me.Grid.Column(Me.igyImpuestoImporte).Visible = False
            Me.Grid.Column(Me.igyIdOrigen).Visible = False
            Me.Grid.Column(Me.igyEsProductoKilos).Visible = False
            Me.Grid.Column(Me.igyCodigoCentroCosto).Width = 100
            Me.Grid.Column(Me.igyNombreCentroCosto).Width = 220
            Me.Grid.Column(Me.igyPrecioUSD).Width = 100
            Me.Grid.Column(Me.igyImporteUSD).Width = 100
            Me.Grid.Column(Me.igyIEPS_PORCENTAJE).Visible = False
            Me.Grid.Column(Me.igyIEPS_UNITARIO).Visible = False
            Me.Grid.Column(Me.igyIEPS_IMPORTE).Visible = False
            Me.Grid.Column(Me.igyBASE_IEPS).Visible = False
            Me.Grid.Column(Me.igyBASE_IVA).Visible = False
            Me.Grid.Column(Me.igyCosto).Width = 100
            Me.Grid.Column(Me.igyUtilidadUnitaria).Width = 100
            Me.Grid.Column(Me.igyUtilidadTotal).Width = 100
            Me.Grid.Column(Me.igyUtilidadPorcentaje).Width = 100
            Me.Grid.Column(Me.iGyID_SIS_CAT_IMPUESTOS).Visible = False  'Ocultar
            Me.Grid.Column(Me.iGyGRADO_TOXICIDAD).Visible = False  'Ocultar
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.Grid.Cell(0, Me.igyCodigo).Text = "Código"
            Me.Grid.Cell(0, Me.igyTipoControlInventariable).Text = "Inv"
            Me.Grid.Cell(0, Me.igyDescripcion).Text = "Descripción"
            Me.Grid.Cell(0, Me.igyCantidad).Text = "Cantidad"
            Me.Grid.Cell(0, Me.igyPrecio).Text = "Precio"
            Me.Grid.Cell(0, Me.igyPRECIO_TOTAL).Text = "Precio total"
            Me.Grid.Cell(0, Me.igyCantidadKilos).Text = "Cantidad x Kg"
            Me.Grid.Cell(0, Me.igyUnidad).Text = "Unidad"
            Me.Grid.Cell(0, Me.igyPrecioKilos).Text = "Precio x Kg"
            Me.Grid.Cell(0, Me.igyImpuestoPorcentaje).Text = "IVA %"
            Me.Grid.Cell(0, Me.igyImporte).Text = "Importe"
            Me.Grid.Cell(0, Me.igyImporteKilos).Text = "Importe x Kg"
            Me.Grid.Cell(0, Me.igyCuentaContable).Text = "Cuenta Contable"
            Me.Grid.Cell(0, Me.igyImpuestoImporte).Text = "IVA"
            Me.Grid.Cell(0, Me.igyIdOrigen).Text = "Id Articulo"
            Me.Grid.Cell(0, Me.igyEsProductoKilos).Text = "Es producto kilos"
            Me.Grid.Cell(0, Me.igyCodigoCentroCosto).Text = "Ccos"
            Me.Grid.Cell(0, Me.igyNombreCentroCosto).Text = "C.Costo"
            Me.Grid.Cell(0, Me.igyPrecioUSD).Text = "PrecioUSD"
            Me.Grid.Cell(0, Me.igyImporteUSD).Text = "ImporteUSD"
            Me.Grid.Cell(0, Me.igyIEPS_PORCENTAJE).Text = "IEPS_%"
            Me.Grid.Cell(0, Me.igyIEPS_UNITARIO).Text = "IEPS_UNIT"
            Me.Grid.Cell(0, Me.igyIEPS_IMPORTE).Text = "IEPS_IMP"
            Me.Grid.Cell(0, Me.igyBASE_IEPS).Text = "BASE_IEPS"
            Me.Grid.Cell(0, Me.igyBASE_IVA).Text = "BASE_IVA"
            Me.Grid.Cell(0, Me.igyCosto).Text = "Costo"
            Me.Grid.Cell(0, Me.igyUtilidadUnitaria).Text = "Utilidad unitaria"
            Me.Grid.Cell(0, Me.igyUtilidadTotal).Text = "Utilidad total"
            Me.Grid.Cell(0, Me.igyUtilidadPorcentaje).Text = "% utilidad"
            Me.Grid.Cell(0, Me.iGyID_SIS_CAT_IMPUESTOS).Text = "IVA?"
            Me.Grid.Cell(0, Me.iGyGRADO_TOXICIDAD).Text = "GradoTox"
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.Grid.Column(Me.igyNombreCentroCosto).Alignment = FlexCell.AlignmentEnum.LeftCenter

            Me.Grid.Column(Me.igyCantidad).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.igyCantidad).DecimalLength = Empresa_Sistema.DECIMALES_CANTIDAD
            Me.Grid.Column(Me.igyCantidad).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.igyCantidadKilos).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.igyCantidadKilos).DecimalLength = Empresa_Sistema.DECIMALES_CANTIDAD
            Me.Grid.Column(Me.igyCantidadKilos).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.igyPrecio).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_PRECIO)
            Me.Grid.Column(Me.igyPrecio).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.igyPrecio).DecimalLength = Empresa_Sistema.DECIMALES_PRECIO
            Me.Grid.Column(Me.igyPrecio).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.igyPRECIO_TOTAL).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_PRECIO)
            Me.Grid.Column(Me.igyPRECIO_TOTAL).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.igyPRECIO_TOTAL).DecimalLength = Empresa_Sistema.DECIMALES_PRECIO
            Me.Grid.Column(Me.igyPRECIO_TOTAL).Alignment = FlexCell.AlignmentEnum.RightCenter

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

            Me.Grid.Column(Me.igyImporteKilos).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
            Me.Grid.Column(Me.igyImporteKilos).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.igyImporteKilos).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
            Me.Grid.Column(Me.igyImporteKilos).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.igyCuentaContable).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.igyImpuestoImporte).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.igyImpuestoImporte).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
            Me.Grid.Column(Me.igyImpuestoImporte).Alignment = FlexCell.AlignmentEnum.RightCenter

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
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.Grid.Column(Me.igyDescripcion).Locked = True
            Me.Grid.Column(Me.igyTipoControlInventariable).Locked = True
            Me.Grid.Column(Me.igyImporte).Locked = True
            Me.Grid.Column(Me.igyImpuestoPorcentaje).Locked = True
            Me.Grid.Column(Me.igyUnidad).Locked = True
            Me.Grid.Column(Me.igyCosto).Locked = True
            Me.Grid.Column(Me.igyUtilidadUnitaria).Locked = True
            Me.Grid.Column(Me.igyUtilidadTotal).Locked = True
            Me.Grid.Column(Me.igyUtilidadPorcentaje).Locked = True
            Me.Grid.Column(Me.igyPRECIO_TOTAL).Locked = True

            If Usuario.PERMISO_CAMBIAR_PRECIO_VENTA = True Then
                Me.Grid.Column(Me.igyPrecio).Locked = False
            Else
                Me.Grid.Column(Me.igyPrecio).Locked = True
            End If

            Me.Grid.Column(Me.igyNombreCentroCosto).Locked = True
            Me.Grid.Column(Me.iGyID_SIS_CAT_IMPUESTOS).Locked = True
            Me.Grid.Column(Me.iGyGRADO_TOXICIDAD).Locked = True
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
                Me.Grid.Column(Me.igyPrecioUSD).Visible = True
                Me.Grid.Column(Me.igyImporteUSD).Visible = True
            Else
                Me.Grid.Column(Me.igyPrecioUSD).Visible = False
                Me.Grid.Column(Me.igyImporteUSD).Visible = False
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
            HandleError(Me.Name, "FormateaGrid", ex)
        Finally
            Me.Grid.AutoRedraw = True
            Me.Grid.Refresh()
        End Try
    End Sub

    Private Sub GestionaCambioEstado()
        Select Case Me.LblEstatus.Text
            Case "N"
                Me.Cambia_Estado(enumEstados.NUEVO)
            Case "G"
                Me.Cambia_Estado(enumEstados.GRABADO)
            Case "A"
                Me.Cambia_Estado(enumEstados.APLICADO)
            Case "S"
                Me.Cambia_Estado(enumEstados.SUSTITUIDO)
            Case "C"
                Me.Cambia_Estado(enumEstados.CANCELADO)
            Case "SY"
                Me.Cambia_Estado(enumEstados.SUSTITUYENDO)
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

                    Me.LblTipoCredito.Enabled = True
                    Me.CboTipoCredito.Enabled = True

                    Me.cboMoneda.Enabled = True
                    Me.cboUsoCFDI.Enabled = True
                    'Me.cboMetodoPago.Enabled = True

                    Me.lblConceptoCancelacion.Visible = False
                    Me.TxtConceptoCancelacion.Visible = False

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

                    Me.TxtConcepto.Focus()

                Case enumEstados.SUSTITUIDO
                    Me.tsbNuevo.Enabled = True
                    Me.tsbGrabar.Enabled = False
                    Me.tsbCancelar.Enabled = True
                    Me.tsbImprimir.Enabled = True
                    Me.tsbEnviarCorreo.Enabled = False

                    Me.frmDatos.Enabled = False
                    Me.Grid.Locked = True
                    Me.GridSeries.Locked = True

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
                        Me.cboFormaPago.Enabled = False
                        Me.cboVendedor.Enabled = False
                        Me.CboAlmacen.Enabled = False
                        Me.CboDocumento.Enabled = False
                        Me.cboTipoMercado.Enabled = False
                        Me.cboTipoNegociacion.Enabled = False
                        Me.txtFolioEmbarque.Enabled = False
                        Me.llblAgregarSeguimiento.Enabled = False
                        Me.LblTipoCredito.Enabled = False
                        Me.CboTipoCredito.Enabled = False
                        Me.cboMoneda.Enabled = False
                        Me.cboUsoCFDI.Enabled = False
                        'Me.cboMetodoPago.Enabled = False

                    ElseIf Me.oDocumento.AFECTA_INVENTARIOS = True Then
                        Me.tsbCotizacionFactura.Visible = False
                        Me.tsbCotizacionRemision.Visible = False
                        Me.tsbRemisionVenta.Visible = True
                    Else
                        Me.tsbCotizacionFactura.Visible = False
                        Me.tsbCotizacionRemision.Visible = False
                        Me.tsbRemisionVenta.Visible = False
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
                    Me.GridSeries.Locked = True 'De momento no permitimos manejo de series en sustituciones.

                    Me.tsbCotizacionFactura.Visible = False
                    Me.tsbCotizacionRemision.Visible = False
                    Me.tsbRemisionVenta.Visible = False
                    Me.btnSeries.Visible = False

                    Me.txtPlazo.Enabled = False
                    Me.dpVencimiento.Enabled = False
                    Me.tsslEstado.Text = "Estado: Sustituyendo movimiento"
                    Me.tsslElaboro.Visible = True : Me.tsslElaboro.Text = "Elaboró: " + Me.oVenta.NOMBRE_USUARIO.ToUpper + " el " + Format(Me.dpFecha.Value, "dd/MMM/yy").ToUpper
                    Me.tsslCancelo.Visible = False : Me.tsslCancelo.Text = ""

                    Me.lblConceptoCancelacion.Visible = False
                    Me.TxtConceptoCancelacion.Visible = False

                    Me.tsbImprimir.Select()

                Case enumEstados.CANCELADO
                    Me.tsbNuevo.Enabled = True
                    Me.tsbGrabar.Enabled = False
                    Me.tsbCancelar.Enabled = False
                    Me.tsbImprimir.Enabled = True
                    Me.tsbEnviarCorreo.Enabled = True

                    'Me.frmDatos.Enabled = False
                    Me.Grid.Locked = True
                    Me.GridSeries.Locked = True

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
                    Me.cboUsoCFDI.Enabled = False

                    Me.lblConceptoCancelacion.Visible = True
                    Me.TxtConceptoCancelacion.Visible = True
                    Me.TxtConceptoCancelacion.ReadOnly = True

            End Select

            'Me.tsbSellarFacturaElectronica.Visible = False

            Application.DoEvents()

        Catch ex As Exception
            HandleError(Me.Name, "Cambia_Estado", ex)
        End Try
    End Sub

    Function Grabar() As Boolean
        Const sProcedure As String = "Grabar"
        Dim bResultado As Boolean = False
        Dim i As Integer, sMetodoPago As String = "", sUsoCFDI As String = "", sListaSeries As String = ""

        Try

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

            If Me.sTipoVenta <> "SR" And Me.oDocumento.AFECTA_CXC = True Then
                If Me._EsPorEmbarqueExtranjero = False AndAlso Me.ValidarReglasCreditoplazo(True) = False Then
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

            If Empresa_Sistema.VERSION_ESQUEMA_CFD <= "3.2" Then
                sMetodoPago = ""
                sUsoCFDI = ""
            Else
                sMetodoPago = Me.cboMetodoPago.SelectedValue.ToString
                sUsoCFDI = Me.cboUsoCFDI.SelectedValue.ToString
            End If

            With Me.oVenta
                .FOLIO_VENTA = Me.txtFolio.Text.ToUpper
                .FECHA = Me.dpFecha.Value
                .FECHA_VENCIMIENTO = Me.dpVencimiento.Value
                .CODIGO_CLIENTE = Me.TxtCliente.Text.ToUpper
                .CODIGO_DOCUMENTO = Me.CboDocumento.SelectedValue.ToString
                .CODIGO_VENDEDOR = CInt(Me.cboVendedor.SelectedValue.ToString)

                .SUBTOTAL = valorNumerico(Me.lblSubtotal.Text)
                .IMPUESTO = valorNumerico(Me.lblImpuesto.Text)

                If Me._EsPorEmbarqueExtranjero = True Then
                    .DESCUENTO = valorNumerico(Me.lblTotal.Text) 'Se invierten los valores para forzar a un total 0 usd porque es en consignacion
                    .TOTAL = 0 'Se invierten los valores para forzar a un total 0 usd porque es en consignacion
                    .SUBTOTAL_USD = valorNumerico(Me.lblTotalDolares.Text)
                    .DESCUENTO_USD = valorNumerico(Me.lblTotalDolares.Text)
                Else 'En facturas normales
                    .DESCUENTO = 0
                    .TOTAL = valorNumerico(Me.lblTotal.Text)
                    .SUBTOTAL_USD = 0 'No aplica en facturas normales aunque estén en usd
                    .DESCUENTO_USD = 0 'No aplica en facturas normales aunque estén en usd
                End If

                If Me.cboMoneda.Text = "USD" Then
                    .TIPO_DE_CAMBIO = valorNumerico(Me.txtTipoCambio.Text)
                    .TOTAL_DOLARES = valorNumerico(Me.lblTotalDolares.Text)
                Else
                    .TIPO_DE_CAMBIO = 0
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
                If Empresa_Sistema.FELECTRONICA_ACTIVA = True And ((oDocumento.AFECTA_CONTABILIDAD = True And oDocumento.AFECTA_INVENTARIOS = True) Or Me._EsPorEmbarqueExtranjero = True) Then
                    .ES_FACTURA_ELECTRONICA = "1"
                Else
                    .ES_FACTURA_ELECTRONICA = "0"
                End If
                .CODIGO_TIPO_MERCADO = Me.cboTipoMercado.SelectedValue.ToString
                .FOLIO_REFERENCIA_USUARIO = ""
                .TIPO_VENTA = sTipoVenta

                .TOTAL_SUSTITUCION = 0 'Ahora se graba dentor del stored MP_VENTA_AFECTA_SUSTITUCION_REMISION
                'If Me.sTipoVenta = "NM" Then
                '    .TOTAL_SUSTITUCION = 0
                'Else
                '    .TOTAL_SUSTITUCION = dTotalSustitucion
                'End If

                .ES_VENTA_PUBLICO_GENERAL = Convert.ToInt32(Me.chkVentaPublicoGeneral.Checked).ToString
                .FOLIO_EMBARQUE = Me.txtFolioEmbarque.Text.ToUpper

                .IEPS_TOTAL_DESGLOSADO = valorNumerico(Me.lblIEPS.Text)
                .IEPS_TOTAL_YA_INCLUIDO = valorNumerico(Me.lblIEPSIncluido.Text)

                .CODIGO_METODO_PAGO = Me.cboFormaPago.SelectedValue.ToString
                .NUMERO_CUENTA_PAGO = Me.txtNumeroCuentaPago.Text
                .CODIGO_METODO_PAGO_EVENTO = sMetodoPago
                .CODIGO_USO_CFDI = sUsoCFDI
                .CODIGO_MONEDA_SAT = Me.cboMoneda.Text

                If .CODIGO_TIPO_NEGOCIACION = 1 Then ' CREDITO
                    .CODIGO_TIPO_CREDITO = Me.CboTipoCredito.SelectedValue.ToString

                ElseIf .CODIGO_TIPO_NEGOCIACION = 2 Then ' CONTADO
                    .CODIGO_TIPO_CREDITO = "NA"
                End If
                .TIENE_IEPS_DESGLOSADO = Me.bClienteEsContribuyenteIEPS

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

                'se graba el detalle
                For i = 1 To Me.Grid.Rows - 1
                    If txtLEN(Me.Grid.Cell(i, Me.igyCodigo).Text) = True Then
                        .NuevoRenglon()
                        .oVentasDetalle.FOLIO_VENTA = Me.oVenta.FOLIO_VENTA.ToUpper
                        .oVentasDetalle.CODIGO_ARTICULO = Me.Grid.Cell(i, Me.igyCodigo).Text.ToUpper
                        .oVentasDetalle.CANTIDAD = valorNumerico(Me.Grid.Cell(i, Me.igyCantidad).Text)
                        .oVentasDetalle.PRECIO = valorNumerico(Me.Grid.Cell(i, Me.igyPrecio).Text)
                        .oVentasDetalle.UNIDAD_VENTA = Me.Grid.Cell(i, Me.igyUnidad).Text.ToUpper
                        .oVentasDetalle.IMPUESTO_PORCENTAJE = CDbl(valorNumerico(Me.Grid.Cell(i, Me.igyImpuestoPorcentaje).Text))
                        .oVentasDetalle.IMPUESTO_IMPORTE = valorNumerico(Me.Grid.Cell(i, Me.igyImpuestoImporte).Text)
                        .oVentasDetalle.IMPORTE = valorNumerico(Me.Grid.Cell(i, Me.igyImporte).Text)

                        If Me.sTipoVenta = "NM" Then
                            .oVentasDetalle.ID_ORIGEN = 0
                        Else
                            .oVentasDetalle.ID_ORIGEN = CInt(Me.Grid.Cell(i, Me.igyIdOrigen).Text)
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
                            For Each dRow In Me.dtSeries.Select("POSICION='" & i.ToString & "'")
                                sListaSeries = sListaSeries & dRow("POSICION").ToString & "," & dRow("CODIGO_ARTICULO").ToString & "," & dRow("ID_INVENTARIO_LOTES_COSTOS").ToString & "," & dRow("NUMERO_SERIE").ToString & "|"
                            Next
                            If txtLEN(sListaSeries) = True Then
                                sListaSeries = sListaSeries.Substring(0, sListaSeries.Length - 1) 'Para quitarle el último pipe que sale sobrando.
                            End If
                        End If

                        .oVentasDetalle.LISTA_SERIES = sListaSeries

                        .oVentasDetalle.PRECIO_USD = valorNumerico(Me.Grid.Cell(i, Me.igyPrecioUSD).Text)
                        .oVentasDetalle.IMPORTE_USD = valorNumerico(Me.Grid.Cell(i, Me.igyImporteUSD).Text)

                        .oVentasDetalle.IEPS_PORCENTAJE = valorNumerico(Me.Grid.Cell(i, Me.igyIEPS_PORCENTAJE).Text)
                        .oVentasDetalle.IEPS_UNITARIO = valorNumerico(Me.Grid.Cell(i, Me.igyIEPS_UNITARIO).Text)
                        .oVentasDetalle.IEPS_IMPORTE = valorNumerico(Me.Grid.Cell(i, Me.igyIEPS_IMPORTE).Text)
                        .oVentasDetalle.BASE_IEPS = valorNumerico(Me.Grid.Cell(i, Me.igyBASE_IEPS).Text)
                        .oVentasDetalle.BASE_IVA = valorNumerico(Me.Grid.Cell(i, Me.igyBASE_IVA).Text)
                        .oVentasDetalle.PRECIO_TOTAL = valorNumerico(Me.Grid.Cell(i, Me.igyPRECIO_TOTAL).Text)
                        .oVentasDetalle.GRADO_TOXICIDAD = CInt(Me.Grid.Cell(i, Me.iGyGRADO_TOXICIDAD).Text)
                        .oVentasDetalle.ID_SIS_CAT_IMPUESTOS = Me.Grid.Cell(i, Me.iGyID_SIS_CAT_IMPUESTOS).Text

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

                    If oDocumento.AFECTA_CONTABILIDAD = True Then
                        If .AplicarPoliza = False Then
                            Return False
                        End If
                    End If
                End If

                If Empresa_Sistema.FELECTRONICA_ACTIVA = True And oDocumento.TIMBRA_DOCUMENTO = True Then
                    Me.oVenta = New Class_Ventas_Global(Me.txtFolio.Text) 'Refrescar documento para evitar algún error por dato no cargado.
                    Me.oVenta.GeneraFacturaElectronica(False, True)
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

                bResultado = True
                MsgBox("Movimiento de ventas grabado satisfactoriamente.", MsgBoxStyle.Information, sProcedure)

                If Me._EsPorEmbarqueExtranjero = True Then
                    Me._GrabadaFacturaEmbarqueExtranjero = True
                    Me.Hide()
                End If
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
        Dim bResultado As Boolean = False
        Dim oFirmaElectronica = New UtileriasFirmaElectronicaCancelacionMovimientosFueraPeriodo
        Dim oUtileriasCancela As New Class_UtileriasFirmaElectronicaCancelacion
        Dim oPoliza As New Class_Contabilidad_Poliza_Global
        Dim sConceptoCancelacion As String = ""

        If Me._EsPorEmbarqueExtranjero = False AndAlso oDocumento.ACCESIBLE_USUARIO = False Then
            MsgBox("Este documento no se puede cancelar directamente.", MsgBoxStyle.Exclamation, Me.Text)
            Return False
        End If

        If MsgBox("Deseas cancelar el movimiento de " & Me.CboDocumento.Text & " ?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "CancelarVenta") = MsgBoxResult.No Then
            Return False
        End If

        If Usuario.ValidaPermisoUsuarioDocumentoConAfectacionInventarios(Me.CboDocumento.SelectedValue.ToString, Me.CboAlmacen.SelectedValue.ToString) = False Then
            MsgBox("El usuario " & Usuario.Nombre_Usuario & " no tiene permiso para realizar el movimiento.", MsgBoxStyle.Exclamation, Me.Text)
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

                sConceptoCancelacion = InputBox("Ingrese el concepto de cancelación :", "Concepto de cancelación")
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
                    MsgBox("No se autorizó la cancelación de movimiento.", MsgBoxStyle.Exclamation, Me.Text)
                    Return False
                End If

                If oUtileriasCancela.GestionaCancelacionConInterfaz() = False Then
                    MsgBox("Error al gestionar la cancelacion con interfaz", MsgBoxStyle.Information, Me.Text)
                    Return False
                Else
                    If oUtileriasCancela.ES_FECHA_CANCELACION_VALIDA = "0" Then
                        MsgBox("La fecha de cancelación debe de ser mayor o igual a la fecha del documento y debe estar en el mismo ejercicio.", vbExclamation, Me.Text)
                        Return False
                    End If

                    Me.oVenta.FECHA_CANCELACION = oUtileriasCancela.FECHA_CANCELACION
                    GoTo CANCELAR
                End If
            End If

CANCELAR:
            Select Case Me.oVenta.TIPO_VENTA
                Case "NM"
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
                    MsgBox("El tipo de venta " & Me.oVenta.TIPO_VENTA & " no esta definido en el proceso de cancelación.", MsgBoxStyle.Exclamation, Me.Text)
                    Return False
            End Select

            If txtLEN(Me.txtFolioEmbarque.Text) = True Then
                Dim oEmbarques As New Class_Embarques_EmbarqueGlobal()
                oEmbarques.FOLIO_EMBARQUE = Me.txtFolioEmbarque.Text

                If oEmbarques.GeneraMarcaFactura(Me.txtFolio.Text, False) = False Then
                    MsgBox("Error al tratar de marcar el embarque como facturado.", MsgBoxStyle.Information, Me.Text)
                End If
            End If

            'MsgBox("Movimiento de venta cancelado.", MsgBoxStyle.Information, Me.Text)
            bResultado = True

        Catch ex As Exception
            HandleError(Me.Name, "Cancelar", ex)
        End Try

        Return bResultado
    End Function

    Private Function ValidarVenta() As Boolean
        Const sProcedure As String = "ValidarVenta"
        Dim bResultado As Boolean = False

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

            If Me.oDocumento.AFECTA_CONTABILIDAD = True Then
                If txtLEN(Me.oCliente.CUENTA_CONTABLE) = False Then
                    MsgBox("El cliente no tiene una cuenta contable en pesos asignada.", MsgBoxStyle.Exclamation, sProcedure)
                    Me.TxtCliente.Focus()
                    Return False
                End If
            End If

            If Me.cboFormaPago.SelectedIndex = -1 Then
                MsgBox("Asígne una forma de pago", MsgBoxStyle.Exclamation, sProcedure)
                Me.cboFormaPago.Focus()
                Return False
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

            If Me.SiTieneImporte() = False Then
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

            If oFormaPago.ESTATUS = "B" Then
                MsgBox("La forma de pago tiene estatus baja.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            If Me.oDocumento.AFECTA_CXC = True Then
                If Me.cboFormaPago.SelectedIndex = -1 Then
                    MsgBox("Seleccione una forma de pago.", MsgBoxStyle.Exclamation, sProcedure)
                    If Me.cboFormaPago.Enabled = True Then
                        Me.cboFormaPago.Focus()
                    End If
                    Return False
                End If

                If Empresa_Sistema.VERSION_ESQUEMA_CFD <= "3.2" Then
                    If oFormaPago.REQUIERE_NUMERO_CUENTA_PAGO = 1 Then
                        If txtLEN(Me.txtNumeroCuentaPago.Text) = False Then
                            If MsgBox("La forma de pago tiene opcional el número de cuenta de pago. Esta seguro de dejarlo en blanco ?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then
                                Return False
                            End If
                        End If
                    End If
                Else
                    If Me.cboFormaPago.SelectedIndex = -1 Then
                        MsgBox("Seleccione un método de pago.", MsgBoxStyle.Exclamation, sProcedure)
                        If Me.cboFormaPago.Enabled = True Then
                            Me.cboFormaPago.Focus()
                        End If
                        Return False
                    End If

                    Select Case Me.cboTipoNegociacion.Text
                        Case "CONTADO"
                            If Me.cboFormaPago.SelectedValue.ToString = "99" Then
                                MsgBox("La forma de pago no puede ser 99-Por definir porque al ser venta de ""contado"" entonces se sabe como se esta pagando el documento.", vbExclamation, sProcedure)
                                If Me.cboFormaPago.Enabled = True Then
                                    Me.cboFormaPago.Focus()
                                End If
                                Return False
                            End If
                        Case "CREDITO"
                            If Me.cboFormaPago.SelectedValue.ToString <> "99" Then
                                MsgBox("La forma de pago debe ser 99-Por definir porque al ser venta de ""crédito"" no hay pago.", vbExclamation, sProcedure)
                                If Me.cboFormaPago.Enabled = True Then
                                    Me.cboFormaPago.Focus()
                                End If
                                Return False
                            End If
                    End Select

                    If Me.cboUsoCFDI.SelectedIndex = -1 Then
                        MsgBox("Seleccione el uso del CFDI.", vbExclamation, sProcedure)
                        If Me.cboUsoCFDI.Enabled = True Then
                            Me.cboUsoCFDI.Focus()
                        End If
                        Return False
                    End If
                End If
            End If

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

            If Me.oDocumento.AFECTA_INVENTARIOS = True Then
                If Me.ValidarExistencias() = False Then
                    Return False
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
            End If

            bResultado = True

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    Private Function ValidarReglasCreditoplazo(ByVal bMostrarMensajes As Boolean) As Boolean
        Try
            If Me.oDocumento.AFECTA_CXC = False Then
                Return True
            End If

            Dim oSisAdministracionClientes = New Class_Sis_Administracion_Clientes
            oSisAdministracionClientes.CodigoCliente = Me.TxtCliente.Text
            oSisAdministracionClientes.TOTAL_VENTA = CDbl(Me.lblTotal.Text)

            If oSisAdministracionClientes.Consultar = False Then
                Exit Function
            End If

            bVentaAutorizadaPorRegla = False
            If oSisAdministracionClientes.VENTA_AUTORIZADA_POR_REGLA_CXC = "1" Then
                bVentaAutorizadaPorRegla = True
                ValidarReglasCreditoplazo = True
                Exit Function
            ElseIf oSisAdministracionClientes.TIENE_VENTAS_CONTADO_VENCIDAS = "1" Then
                If bMostrarMensajes = True Then
                    MsgBox("El cliente presenta ventas de contado vencidas, favor de contactar al depto de CXC.", vbExclamation, "ValidarReglasCreditoplazo")
                End If
                Exit Function
            Else
                Select Case Me.cboTipoNegociacion.Text
                    'Case "CONTADO"
                    '    If oSisAdministracionClientes.TIENE_VENTAS_CONTADO_VENCIDAS = "1" Then
                    '        Exit Function
                    '    End If
                    Case "CREDITO"
                        If CDbl(oSisAdministracionClientes.SaldoVencido) > 0 Then
                            If bMostrarMensajes = True Then
                                MsgBox("El cliente presenta saldo vencido.", vbExclamation, "ValidarReglasCreditoplazo")
                            End If
                            Exit Function
                        End If
                End Select
            End If

            If Me.oDocumento.AFECTA_INVENTARIOS = True Then
                If Me.sTipoVenta <> "SR" Then
                    'SUSTITUCION DE COTIZACION A REMISION O FACTURA Y DE VENTA NORMAL
                    If oSisAdministracionClientes.TIENE_CREDITO_SUFICIENTE = "0" And Me.cboTipoNegociacion.Text = "CREDITO" Then
                        MsgBox("La venta que intenta realizar supera el limite de credito del cliente. No es posible realizar este movimiento.", MsgBoxStyle.Exclamation, Me.Text)
                        Exit Function
                    End If
                End If
            End If

            Return True
        Catch ex As Exception
            HandleError(Me.Name, "ValidarReglasCreditoplazo", ex)
        End Try
    End Function

    Private Function ValidarDatosCliente() As Boolean
        Try
            If txtLEN(Me.oCliente.NOMBRE_CLIENTE) = False Or Me.oCliente.NOMBRE_CLIENTE = "." Then
                MsgBox("El dato ''Nombre'' del cliente no esta capturado.", MsgBoxStyle.Exclamation, Me.Text)
                Me.TxtCliente.Focus()
                Exit Function
            ElseIf txtLEN(Me.oCliente.RFC) = False Or Me.oCliente.RFC = "." Then
                MsgBox("El dato ''RFC'' del cliente no esta capturado.", MsgBoxStyle.Exclamation, Me.Text)
                Me.TxtCliente.Focus()
                Exit Function
            ElseIf txtLEN(Me.oCliente.CALLE) = False Or Me.oCliente.CALLE = "." Then
                MsgBox("El dato ''Calle'' del cliente no esta capturado.", MsgBoxStyle.Exclamation, Me.Text)
                Me.TxtCliente.Focus()
                Exit Function
            ElseIf txtLEN(Me.oCliente.NUMERO_EXTERIOR) = False Or Me.oCliente.NUMERO_EXTERIOR = "." Then
                MsgBox("El dato ''Número exterior'' del cliente no esta capturado.", MsgBoxStyle.Exclamation, Me.Text)
                Me.TxtCliente.Focus()
                Exit Function
            ElseIf txtLEN(Me.oCliente.CIUDAD) = False Or Me.oCliente.CIUDAD = "." Then
                MsgBox("El dato ''Municipio'' del cliente no esta capturado.", MsgBoxStyle.Exclamation, Me.Text)
                Me.TxtCliente.Focus()
                Exit Function
            ElseIf txtLEN(Me.oCliente.ESTADO) = False Or Me.oCliente.ESTADO = "." Then
                MsgBox("El dato ''Estado'' del cliente no esta capturado.", MsgBoxStyle.Exclamation, Me.Text)
                Me.TxtCliente.Focus()
                Exit Function
            ElseIf txtLEN(Me.oCliente.PAIS) = False Or Me.oCliente.PAIS = "." Then
                MsgBox("El dato ''País'' del cliente no esta capturado.", MsgBoxStyle.Exclamation, Me.Text)
                Me.TxtCliente.Focus()
                Exit Function
            ElseIf txtLEN(Me.oCliente.CODIGO_POSTAL) = False Or Me.oCliente.CODIGO_POSTAL = "." Then
                MsgBox("El dato ''Código postal'' del cliente no esta capturado.", MsgBoxStyle.Exclamation, Me.Text)
                Me.TxtCliente.Focus()
                Exit Function
            End If

            Return True

        Catch ex As Exception
            HandleError(Me.Name, "ValidarDatosCliente", ex)
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
                    dExistencia = oInventarios.Existencia(Me.Grid.Cell(i, Me.igyCodigo).Text, Me.CboAlmacen.SelectedValue.ToString)
                    oArticulos = New Class_CatArticulos(Me.Grid.Cell(i, Me.igyCodigo).Text)
                    If oArticulos.INVENTARIABLE = "1" Then
                        If txtLEN(oArticulos.CODIGO_CULTIVO) = False Then
                            If dExistencia <= 0 Then
                                MsgBox("El artículo " & Me.Grid.Cell(i, Me.igyDescripcion).Text & " no tiene existencia. ", MsgBoxStyle.Exclamation, sProcedure)
                                Exit Function
                            Else
                                dCantidadSumadaPorArticulos = valorNumerico(dt.Compute("sum(CANTIDAD)", "CODIGO_ARTICULO='" & Me.Grid.Cell(i, Me.igyCodigo).Text & "'").ToString)

                                If valorNumerico(dCantidadSumadaPorArticulos.ToString) > valorNumerico(dExistencia.ToString) Then
                                    MsgBox("El Artículo " & Me.Grid.Cell(i, Me.igyDescripcion).Text & " no tiene suficiente existencia.", MsgBoxStyle.Exclamation, sProcedure)
                                    Exit Function
                                End If
                            End If
                        End If
                    End If
                End If
            Next i

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

    Private Function ValidarDisponible() As Boolean
        Dim i As Integer, dDisponible As Double
        Try
            i = 1
            If txtLEN(Me.Grid.Cell(i, Me.igyCodigo).Text) = True Then
                dDisponible = Me.oVenta.ObtenerDisponibleRenglon(CInt(Me.Grid.Cell(i, Me.igyIdOrigen).Text))
                If valorNumericoD(Me.Grid.Cell(i, Me.igyCantidad).Text) > dDisponible Then
                    MsgBox("La cantidad del renglón #" & i & " es mayor al disponible.", MsgBoxStyle.Exclamation, "ValidarDisponibles")
                    Me.Grid.Cell(i, Me.igyDescripcion).SetFocus()
                    Return False
                End If
            End If
            Return True
        Catch ex As Exception
            HandleError(Me.Name, "ValidarDisponibles", ex)
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
        Try
            Dim i As Integer, dCantidad As Decimal, dPrecioCapturado As Decimal, dPrecioOriginal As Decimal, dPorcentajeIVA As Decimal, dImporte As Decimal, dImporteSustitucion As Decimal, iIDOrigen As Integer = 0, dImporteTotal As Double = 0
            Dim oArticulo As New Class_CatArticulos
            Dim dIEPS_PORCENTAJE As Decimal = 0, dIEPS_UNITARIO As Decimal = 0, dIEPS_IMPORTE As Decimal = 0, dBASE_IEPS As Decimal = 0, dBASE_IVA As Decimal = 0, dPRECIO_TOTAL As Decimal = 0, dIVA_IMPORTE As Decimal = 0
            Dim dtSubtotal As Decimal = 0, dtIEPS As Decimal = 0, dtImpuesto As Decimal = 0, dtTotal As Decimal = 0
            Dim sID_SIS_CAT_IMPUESTOS As String = "", sGRADO_TOXICIDAD As String = "0" '0=NO GRAVA IEPS, Es este sistema no hay ieps de modo que lo forzamos a que no tengan para los cálculos.
            Dim dPrecioConDescuento As Decimal, dImporteConDescuento As Decimal

            Me.lblSubtotal.Text = FormatImporteContable(0)
            Me.lblIEPSIncluido.Text = FormatImporteContable(0)
            Me.lblIEPS.Text = FormatImporteContable(0)
            Me.lblImpuesto.Text = FormatImporteContable(0)
            Me.lblTotal.Text = FormatImporteContable(0)

            Me.lblSubtotalDolares.Text = FormatImporteContable(0)
            Me.lblImpuestoDolares.Text = FormatImporteContable(0)
            Me.lblTotalDolares.Text = FormatImporteContable(0)

            dTotalSustitucion = 0

            For i = 1 To Me.Grid.Rows - 1
                If txtLEN(Me.Grid.Cell(i, Me.igyCodigo).Text) = True Then
                    oArticulo = New Class_CatArticulos(Me.Grid.Cell(i, Me.igyCodigo).Text)
                    'If oArticulo.ES_PRODUCTO_KILOS = "0" Then
                    If txtLEN(Me.Grid.Cell(i, Me.igyCantidad).Text) = True Then

                        dCantidad = 0 : dPrecioCapturado = 0 : dPrecioConDescuento = 0 : iIDOrigen = 0 : dPorcentajeIVA = 0 : dIEPS_PORCENTAJE = 0 : sID_SIS_CAT_IMPUESTOS = "" : dImporteConDescuento = 0
                        dBASE_IEPS = 0 : dIEPS_IMPORTE = 0 : dIEPS_UNITARIO = 0 : dBASE_IVA = 0 : dIVA_IMPORTE = 0 : dPRECIO_TOTAL = 0 : dPrecioOriginal = 0 : dImporte = 0 : dImporteTotal = 0 : dImporteSustitucion = 0

                        dCantidad = valorNumericoD(Me.Grid.Cell(i, Me.igyCantidad).Text)
                        dPrecioCapturado = valorNumericoD(Me.Grid.Cell(i, Me.igyPrecio).Text)
                        dPrecioConDescuento = dPrecioCapturado
                        iIDOrigen = CInt(valorNumericoD(Me.Grid.Cell(i, Me.igyIdOrigen).Text))
                        dPorcentajeIVA = valorNumericoD(Me.Grid.Cell(i, Me.igyImpuestoPorcentaje).Text)
                        dIEPS_PORCENTAJE = valorNumericoD(Me.Grid.Cell(i, Me.igyIEPS_PORCENTAJE).Text)
                        sID_SIS_CAT_IMPUESTOS = Me.Grid.Cell(i, Me.iGyID_SIS_CAT_IMPUESTOS).Text
                        sGRADO_TOXICIDAD = Me.Grid.Cell(i, Me.iGyGRADO_TOXICIDAD).Text

                        dImporteConDescuento = RedondearD((dCantidad * dPrecioConDescuento), 2)

                        If sGRADO_TOXICIDAD <> "0" Then
                            dBASE_IEPS = dImporteConDescuento
                            dIEPS_IMPORTE = RedondearD(dBASE_IEPS * (dIEPS_PORCENTAJE / 100), 2)
                            dIEPS_UNITARIO = CDec(Redondear(dPrecioCapturado * (dIEPS_PORCENTAJE / 100), 4))
                        End If

                        If sID_SIS_CAT_IMPUESTOS <> "N" Then 'N=No grava iva, si es <>N = Si grava iva ya sea al 0,16,Exento(aún siendo exento ó 0 hay que llenar la base iva)
                            dBASE_IVA = dImporteConDescuento + dIEPS_IMPORTE
                            dIVA_IMPORTE = RedondearD(dBASE_IVA * ((dPorcentajeIVA / 100)), 2)
                        End If

                        dPRECIO_TOTAL = dPrecioCapturado

                        If Me.bClienteEsContribuyenteIEPS = False And dPrecioCapturado > 0 Then 'Cuando no es contribuyente se le adjunta al precio el ieps, es decir se le incluye
                            dPRECIO_TOTAL = RedondearD(dPrecioCapturado + dIEPS_UNITARIO, 3)
                        End If

                        Me.Grid.Cell(i, Me.igyPRECIO_TOTAL).Text = dPRECIO_TOTAL.ToString
                        Me.Grid.Cell(i, Me.igyIEPS_UNITARIO).Text = dIEPS_UNITARIO.ToString
                        Me.Grid.Cell(i, Me.igyBASE_IEPS).Text = dBASE_IEPS.ToString
                        Me.Grid.Cell(i, Me.igyIEPS_IMPORTE).Text = dIEPS_IMPORTE.ToString
                        Me.Grid.Cell(i, Me.igyBASE_IVA).Text = dBASE_IVA.ToString
                        Me.Grid.Cell(i, Me.igyImpuestoImporte).Text = dIVA_IMPORTE.ToString

                        'If Me.LblEstatus.Text <> "N" Then
                        If Me.LblEstatus.Text <> "N" AndAlso sTipoVenta <> "NM" Then
                            dPrecioOriginal = CDec(Me.oVenta.ObtenerPrecioOriginal(iIDOrigen))
                        Else
                            dPrecioOriginal = 0 'dPrecio
                        End If

                        'If dCantidad > 0 Then
                        dImporte = RedondearD((dCantidad * dPrecioCapturado), Empresa_Sistema.DECIMALES_CONTABILIDAD) 'no hacemos nada con este valor de momento
                        dImporteTotal = RedondearD((dCantidad * dPRECIO_TOTAL), Empresa_Sistema.DECIMALES_CONTABILIDAD)

                        dImporteSustitucion = RedondearD((dPrecioOriginal * dCantidad), Empresa_Sistema.DECIMALES_CONTABILIDAD)
                        dImporteSustitucion = valorNumericoD(RedondearD(dImporteSustitucion * ((dPorcentajeIVA / 100) + 1), Empresa_Sistema.DECIMALES_CONTABILIDAD).ToString)
                        dTotalSustitucion = dTotalSustitucion + dImporteSustitucion

                        'Me.Grid.Cell(i, Me.igyImporte).Text = dImporteTotal.ToString
                        Me.Grid.Cell(i, Me.igyImporte).Text = dImporteTotal.ToString
                        'Me.lblSubtotal.Text = FormatImporteContable(valorNumerico(Me.lblSubtotal.Text) + dImporte)

                        'Me.Grid.Cell(i, Me.igyImpuestoImporte).Text = Redondear(dImporte * ((dPorcentajeIVA / 100)), Empresa_Sistema.DECIMALES_CONTABILIDAD).ToString
                        '    'Else
                        'Me.Grid.Cell(i, Me.igyImporte).Text = "0"
                        'Me.Grid.Cell(i, Me.igyImpuestoImporte).Text = "0"
                        'End If
                    End If

                    'Else
                    '    If txtLEN(Me.Grid.Cell(I, Me.igyCantidadKilos).Text) = True Then
                    '        dCantidad = valorNumerico(Me.Grid.Cell(I, Me.igyCantidadKilos).Text)
                    '        dPrecio = valorNumerico(Me.Grid.Cell(I, Me.igyPrecioKilos).Text)
                    '        iIDOrigen = CInt(valorNumerico(Me.Grid.Cell(I, Me.igyIdOrigen).Text))

                    '        'If Me.LblEstatus.Text <> "N" Then
                    '        If Me.LblEstatus.Text <> "N" AndAlso sTipoVenta <> "NM" Then
                    '            dPrecioOriginal = Me.oVenta.ObtenerPrecioOriginal(iIDOrigen)
                    '        Else
                    '            dPrecioOriginal = valorNumerico(Me.Grid.Cell(I, Me.igyPrecio).Text)
                    '        End If

                    '        dPorcentajeIVA = valorNumerico(Me.Grid.Cell(I, Me.igyImpuestoPorcentaje).Text)
                    '        If dCantidad > 0 Then
                    '            dImporte = Redondear((dPrecio * dCantidad), Empresa_Sistema.DECIMALES_CONTABILIDAD)

                    '            dImporteSustitucion = Redondear((dPrecioOriginal * valorNumerico(Me.Grid.Cell(I, Me.igyCantidadKilos).Text)), Empresa_Sistema.DECIMALES_CONTABILIDAD)
                    '            dImporteSustitucion = valorNumerico(Redondear(dImporteSustitucion * ((dPorcentajeIVA / 100) + 1), Empresa_Sistema.DECIMALES_CONTABILIDAD).ToString)
                    '            dTotalSustitucion = dTotalSustitucion + dImporteSustitucion

                    '            Me.Grid.Cell(I, Me.igyImporteKilos).Text = dImporte.ToString
                    '            Me.lblSubtotal.Text = FormatImporteContable(valorNumerico(Me.lblSubtotal.Text) + dImporte)

                    '            Me.Grid.Cell(I, Me.igyImpuestoImporte).Text = Redondear((valorNumerico(Me.Grid.Cell(I, Me.igyCantidad).Text) * valorNumerico(Me.Grid.Cell(I, Me.igyPrecio).Text)) * ((dPorcentajeIVA / 100)), Empresa_Sistema.DECIMALES_CONTABILIDAD).ToString
                    '        Else
                    '            Me.Grid.Cell(I, Me.igyImporteKilos).Text = "0"
                    '            Me.Grid.Cell(I, Me.igyImpuestoImporte).Text = "0"
                    '        End If
                    '    End If
                    'End If
                End If
            Next i

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
            dtImpuesto = RedondearD(CDec(FG_Grid_SumaCol(Me.Grid, Me.igyImpuestoImporte)), Empresa_Sistema.DECIMALES_CONTABILIDAD)
            dtTotal = dtSubtotal + dtIEPS + dtImpuesto

            Me.lblSaldo.Text = FormatImporteContable(valorNumerico(Me.lblSaldo.Text))

            Me.lblSubtotal.Text = FormatImporteContable(dtSubtotal)
            Me.lblImpuesto.Text = FormatImporteContable(dtImpuesto)
            Me.lblTotal.Text = FormatImporteContable(dtTotal)

            If valorNumerico(Me.txtTipoCambio.Text) > 0 Then
                Me.lblSubtotalDolares.Text = FormatImporteContable(Redondear(valorNumerico(Me.lblSubtotal.Text) / valorNumerico(Me.txtTipoCambio.Text), Empresa_Sistema.DECIMALES_CONTABILIDAD))
                Me.lblImpuestoDolares.Text = FormatImporteContable(Redondear(valorNumerico(Me.lblImpuesto.Text) / valorNumerico(Me.txtTipoCambio.Text), Empresa_Sistema.DECIMALES_CONTABILIDAD))

                If Not Me._oEmbarqueExtranjero Is Nothing Then
                    'Es por embarque extranjero, la columna se calculó desde que se obtuvieron los renglones y se debe hacer por siuma directa para no tener diferencias de decimales.
                    Me.lblTotalDolares.Text = FormatImporteContable(Redondear(FG_Grid_SumaCol(Me.Grid, Me.igyImporteUSD), Empresa_Sistema.DECIMALES_CONTABILIDAD))
                Else
                    Me.lblTotalDolares.Text = FormatImporteContable(Redondear(valorNumerico(Me.lblTotal.Text) / valorNumerico(Me.txtTipoCambio.Text), Empresa_Sistema.DECIMALES_CONTABILIDAD))
                End If
            End If

        Catch ex As Exception
            HandleError(Me.Name, "Totales", ex)
        End Try
    End Sub

    Private Sub GeneraFolio()
        'If Me.bDocumentosCargados = True Then
        Me.txtFolio.Text = Me.oVenta.GeneraFolioVentas
        'End If
    End Sub

    Private Function Consultar(Optional ByVal bEsReferencia As Boolean = False, Optional ByVal bEsRefrenciaSoloRenglones As Boolean = False) As Boolean
        Dim bResultado As Boolean = False
        Try
            Me.tsbTimbrar.Visible = False
            Me.tsbCancelarTimbre.Visible = False
            Me.tsbRecuperarXMLPDF.Visible = False
            Me.tsbEnviarCorreo.Visible = False

            Dim sVenta As String = ""

            If sTipoVenta = "NM" And bEsReferencia = True Then
                sVenta = Me.TxtReferencia.Text
            Else
                sVenta = Me.txtFolio.Text
            End If

            Me.Inicializa()
            Me.oVenta = New Class_Ventas_Global(sVenta)

            If Me.oVenta.Existe = False Then
                Me.Cambia_Estado(enumEstados.NUEVO)
                Me.CboDocumento.Enabled = False
                Return False
            Else
                Me.lblVersionCFDI.Text = "" & oVenta.VERSION_ESQUEMA_XML

                Me.DesplegarFormasPago(True) 'Para forzar a que muestre todos incluso los que están dados de baja porque al consultarlos fallaria si no estuvieran.

                If sTipoVenta = "NM" Then
                    Me.CboDocumento.SelectedValue = Me.oVenta.CODIGO_DOCUMENTO
                ElseIf sTipoVenta = "SCR" Then
                    Me.CboDocumento.SelectedValue = "REM" + Plaza.CODIGO_PLAZA.ToString
                    Me.GeneraFolio()
                ElseIf sTipoVenta = "SR" Or sTipoVenta = "SCF" Then
                    'Me.CboDocumento.SelectedValue = "FCT" + Plaza.CODIGO_PLAZA.ToString
                    Me.CboDocumento.SelectedValue = sCodigoDocumentoFacturaExterno
                    Me.GeneraFolio()
                    'Me.dpVencimiento.Value = Me.oVenta.FECHA_VENCIMIENTO
                End If

                Me.TxtCliente.Text = Me.oVenta.CODIGO_CLIENTE
                Me.TxtConcepto.Text = Me.oVenta.CONCEPTO
                Me.txtFolioEmbarque.Text = Me.oVenta.FOLIO_EMBARQUE

                Me.oCliente = New Class_CatClientes(Me.TxtCliente.Text)
                Me.lblCliente.Text = Me.oCliente.NOMBRE_CLIENTE

                If bEsReferencia = False Then
                    Me.LblPoliza.Text = Me.oVenta.FOLIO_POLIZA
                    Me.lblSaldo.Text = FormatImporteContable(Me.oVenta.SALDO)
                End If

                Me.lblSubtotal.Text = FormatImporteContable(Me.oVenta.SUBTOTAL)
                Me.lblImpuesto.Text = FormatImporteContable(Me.oVenta.IMPUESTO)
                Me.lblTotal.Text = FormatImporteContable(Me.oVenta.TOTAL)
                Me.lblIEPS.Text = FormatImporteContable(Me.oVenta.IEPS_TOTAL_DESGLOSADO)
                Me.lblIEPSIncluido.Text = FormatImporteContable(Me.oVenta.IEPS_TOTAL_YA_INCLUIDO)

                Me.cboMoneda.Text = Me.oVenta.CODIGO_MONEDA_SAT 'Nota debe llenarse primero la moneda porque tiene evento change que llena la forma de pago segpun el cte, y asi se consulta correcto.
                Me.txtTipoCambio.Text = Me.oVenta.TIPO_DE_CAMBIO.ToString

                If Me.oVenta.TIPO_DE_CAMBIO > 0 Then
                    Me.lblSubtotalDolares.Text = FormatImporteContable(Me.oVenta.SUBTOTAL / Me.oVenta.TIPO_DE_CAMBIO).ToString
                    Me.lblImpuestoDolares.Text = FormatImporteContable(Me.oVenta.IMPUESTO / Me.oVenta.TIPO_DE_CAMBIO).ToString
                    Me.lblTotalDolares.Text = FormatImporteContable(Me.oVenta.TOTAL / Me.oVenta.TIPO_DE_CAMBIO).ToString
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
                    Me.LblEstatus.Text = Me.oVenta.ESTATUS_VENTA.ToString.ToUpper
                    Me.Grid.DataSource = Me.oVenta.ObtenerDetalle(False) 'Que si muestre comentarios
                    Me.dpFecha.Value = CDate(Me.oVenta.FECHA)

                    Me.GridSeries.DataSource = Me.oVenta.ObtenerDetalleSeries
                    Me.FormateaGridSeries()
                Else
                    Me.TxtReferencia.Text = Me.oVenta.FOLIO_VENTA.ToString.ToUpper
                    Me.CboAlmacen.Enabled = False
                    Me.Grid.DataSource = Me.oVenta.ObtenerDetalleSoloDisponibles
                    Me.dpFecha.Value = Date.Now

                    If bEsRefrenciaSoloRenglones = True Then
                        Me.LblEstatus.Text = "N"
                    Else
                        Me.LblEstatus.Text = "SY"
                    End If
                End If

                Me.FormateaGrid()
                Me.dpVencimiento.Value = Me.oVenta.FECHA_VENCIMIENTO
                Me.txtPlazo.Text = DateDiff(DateInterval.Day, Me.dpFecha.Value, Me.dpVencimiento.Value.AddDays(1)).ToString

                Select Case Me.oCliente.TIPO_PERSONA
                    Case "F"
                        Me.DesplegarUsoCFDIPersonasFisicas()
                    Case "M"
                        Me.DesplegarUsoCFDIPersonasMorales()
                End Select

                If txtLEN("" & Me.oVenta.CODIGO_USO_CFDI) = True Then
                    Me.cboUsoCFDI.SelectedValue = Me.oVenta.CODIGO_USO_CFDI
                End If
            End If

            bResultado = True

            Me.GestionaCambioEstado()

            Me.txtFolio.Enabled = False

            If Empresa_Sistema.FELECTRONICA_ACTIVA = True And oDocumento.TIMBRA_DOCUMENTO = True Then
                If Me.oVenta.TIMBRADO_CFDI = "0" AndAlso Me.oVenta.TIMBRADO_DESCARTADO = "0" And Me.oVenta.VERSION_ESQUEMA_XML <> "2.2" Then
                    Me.tsbTimbrar.Visible = True
                ElseIf Me.oVenta.ESTATUS_VENTA = "C" AndAlso Me.oVenta.TIMBRADO_CFDI = "1" AndAlso Me.oVenta.TIMBRADO_DESCARTADO = "0" AndAlso Me.oVenta.ESTATUS_CANCELACION_CFDI = "0" Then
                    Me.tsbCancelarTimbre.Visible = True
                End If

                If Me.oVenta.TIMBRADO_CFDI = "1" Then
                    Me.tsbRecuperarXMLPDF.Visible = True
                    Me.tsbEnviarCorreo.Visible = True
                End If
            End If

        Catch ex As Exception
            HandleError(Me.Name, "Consultar", ex)
        End Try

        Return bResultado
    End Function

    Private Function EstableceCuentasContables() As Boolean
        Try
            Dim I As Integer

            For I = 1 To Me.Grid.Rows - 1
                Dim oArticulos = New Class_CatArticulos(Me.Grid.Cell(I, Me.igyCodigo).Text)
                If oArticulos.Existe = True Then
                    Me.Grid.Cell(I, Me.igyCuentaContable).Text = Plaza.CUENTA_CONTABLE_VENTAS.ToString
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

    Private Sub GestionaGrid(ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            Dim Columna As Integer, Renglon As Integer
            Dim StrCod As String, sCuentaContable As String = "", dCantidad As Decimal, dPrecio As Decimal, sCodigoCentroCosto As String
            Dim oArticulo As Class_CatArticulos

            'If Me.oDocumento.AFECTA_CXC = True And Me.Grid.Selection.FirstRow = Me.Grid.Rows - 1 Then
            '    Return
            'End If

            Columna = Me.Grid.Selection.FirstCol
            Renglon = Me.Grid.Selection.FirstRow
            StrCod = Me.Grid.Cell(Renglon, Me.igyCodigo).Text
            dCantidad = CDec(valorNumerico(Me.Grid.Cell(Renglon, Me.igyCantidad).Text))
            dPrecio = CDec(valorNumerico(Me.Grid.Cell(Renglon, Me.igyPrecio).Text))

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
                            Else
                                Dim oEmbarques As New Class_Embarques_EmbarqueGlobal()
                                oEmbarques.FOLIO_EMBARQUE = Me.txtFolioEmbarque.Text
                                If oEmbarques.Consultar() = False Then
                                    MsgBox("El folio de embarque no existe.", MsgBoxStyle.Exclamation, Me.Text)
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

                            Me.Grid.Column(Me.igyDescripcion).Locked = True

                            Me.Totales()

                        Case Me.igyCantidad  'Cantidad
                            oArticulo = New Class_CatArticulos(StrCod)
                            If dCantidad <= 0 And oArticulo.ES_PRODUCTO_KILOS = "0" Then
                                MsgBox("La cantidad debe de ser mayor a 0.", MsgBoxStyle.Exclamation, Me.Text)
                                Me.Grid.Cell(Renglon, Me.igyDescripcion).SetFocus()
                                Return
                            End If

                            If sTipoVenta <> "NM" Then
                                If ValidarDisponible() = False Then
                                    Return
                                End If
                            End If

                            If Me.oDocumento.AFECTA_INVENTARIOS = True Then
                                If ValidarExistencias() = False Then
                                    Return
                                End If
                            End If

                            If Me.oDocumento.AFECTA_CXC = True Then
                                'If Me.oCompras.ValidaCantidadDisponibleArticulo(CInt(Me.Grid.Cell(Renglon, Me.igyIdOrigen).Text), dCantidad) = False Then
                                '    MsgBox("La cantidad debe de ser menor al disponible.", MsgBoxStyle.Exclamation, Me.Text)
                                '    Me.Grid.Cell(Renglon, Me.igyCantidad).Text = Me.oCompras.ObtenerDisponibleArticulo(CInt(Me.Grid.Cell(Renglon, Me.igyIdOrigen).Text)).ToString
                                '    Me.Grid.Refresh()
                                '    Return
                                'End If
                            End If

                        Case Me.igyPrecio  'Cantidad
                            oArticulo = New Class_CatArticulos(StrCod)
                            If dPrecio <= 0 And oArticulo.ES_PRODUCTO_KILOS = "0" Then
                                MsgBox("El precio debe de ser mayor a 0.", MsgBoxStyle.Exclamation, Me.Text)
                                Me.Grid.Cell(Renglon, Me.igyCantidad).SetFocus()
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

                    End Select

                    Select Case Columna
                        Case Me.igyCantidad
                            If Me.Grid.Rows = Renglon + 1 Then Me.Grid.Rows = Me.Grid.Rows + 1
                            'Case Else
                            '    If Me.Grid.Rows = Renglon + 1 Then Me.Grid.Rows = Me.Grid.Rows + 1
                    End Select

                    Me.Totales()

                Case Keys.F6
BuscaArticulos:
                    Select Case Columna
                        Case Me.igyCodigo 'Columna del Codigo de Articulo
                            oArticulo = New Class_CatArticulos
                            StrCod = oArticulo.BusquedaVisual_PorDescripcion_conExistencias(Me.CboAlmacen.SelectedValue.ToString)
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

                Case Keys.F8 'Borrar renglón
                    If (Me.Estado = enumEstados.NUEVO Or Me.Estado = enumEstados.GRABADO) Then
                        Me.Grid.Selection.DeleteByRow()
                        Me.Totales()
                    End If

                Case Keys.Delete 'Borrar renglón
                    Return

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
                        Me.Grid.Cell(Renglon + 1, Me.igyCodigo).SetFocus()

                        For i = Me.igyDescripcion + 1 To Me.Grid.Cols - 1
                            Me.Grid.Cell(Renglon, i).Locked = True 'Bloqueamos el resto de las columnas
                            Me.Grid.Cell(Renglon, i).Text = "" 'Eliminamos los datos del resto de las columnas
                        Next

                    End If

                    Me.Totales() 'Por si a un renglón que ya tiene un artículo(con importe) le dan f4
                    oComentario.Dispose()

                Case Keys.F5 'Lista de precios
                    If txtLEN(StrCod) = False Then
                        Return
                    End If
                    Dim oPrecio As New VentasSeleccionPrecio(StrCod)
                    oPrecio.ShowDialog()
                    Me.Grid.Cell(Renglon, Me.igyPrecio).Text = oPrecio.PrecioSeleccionado.ToString
                    oPrecio.Dispose()
                    Me.Totales()
            End Select

        Catch ex As Exception
            HandleError(Me.Name, "GestionaGrid", ex)
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
        Try
            Me.oCliente = New Class_CatClientes(Me.TxtCliente.Text)
            If Me.oCliente.Existe = False Then
                Me.lblCliente.Text = ""
                Return False
            End If

            Me.lblCliente.Text = Me.oCliente.NOMBRE_CLIENTE
            Me.txtPlazo.Text = Me.oCliente.DIAS_PLAZO.ToString
            Me.dpVencimiento.Value = Me.dpFecha.Value.AddDays(CDbl(Me.txtPlazo.Text))
            Me.cboVendedor.SelectedValue = Me.oCliente.CODIGO_VENDEDOR

            Dim bEstableceFormaPago As Boolean

            If Empresa_Sistema.VERSION_ESQUEMA_CFD <= "3.2" Then
                bEstableceFormaPago = True
            Else
                If Me.cboMetodoPago.SelectedValue.ToString = "PUE" Then 'Si es PPD recordemos que la forma de pago es obligatoriamente 99
                    bEstableceFormaPago = True
                End If
            End If

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

            Select Case Me.oCliente.TIPO_PERSONA
                Case "F"
                    Me.DesplegarUsoCFDIPersonasFisicas()
                Case "M"
                    Me.DesplegarUsoCFDIPersonasMorales()
            End Select
            Me.cboUsoCFDI.SelectedValue = Me.oCliente.CODIGO_USO_CFDI

            Me.bClienteEsContribuyenteIEPS = CBool(Me.oCliente.ES_CONTRIBUYENTE_IEPS)

            Return True
        Catch ex As Exception
            HandleError(Me.Name, "ConsultarCliente", ex)
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
            Me.GridSeries.Cols = 6
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
                                    MsgBox("No se encontraron series disponibles del artículo " & sCodigoArticulo & " del folio " & lote.FolioMovimiento, MsgBoxStyle.Exclamation, Me.Text)
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
            HandleError(Me.Name, "GestionaGridSeries", ex)
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

            If Me.sTipoVenta = "SR" AndAlso dtSeriesTemp.Rows.Count > 0 Then
                MsgBox("Las sustituciones no soportan el manejo de series actualmente.", MsgBoxStyle.Exclamation, Me.Text)
                Return False
            End If

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
                .Text = "MXN"
                sMonedaAnterior = "MXN"
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarMonedas", ex)
        End Try
    End Sub

    Private Sub EstableceMetodoPago()
        Try
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

                    'Quitamos el "99-Por definir" ya que sólo es para crédito
                    dViewFormasPago.RowFilter = "CODIGO_METODO_PAGO<>'99'"

                    If txtLEN(Me.TxtCliente.Text) = True Then
                        If bCargandoVenta = False Then
                            Me.EstableceFormaPagoCliente()
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
                    Me.cboFormaPago.Enabled = False

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

    Private Sub DesplegarUsoCFDIPersonasMorales()
        Try
            With Me.cboUsoCFDI
                .DisplayMember = "NOMBRE_USO_CFDI"
                .ValueMember = "CODIGO_USO_CFDI"
                Dim dView As New Data.DataView(dtUsosCFDIPersonasMorales)
                dView.Sort = "NOMBRE_USO_CFDI"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedIndex = 0
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarUsoCFDIPersonasMorales", ex)
        End Try
    End Sub
#End Region

End Class