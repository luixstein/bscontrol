Option Strict On

Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient

Public Class Frm_CXC_Pagos

#Region "Campos privados"
    Private Enum enumEstados
        NUEVO
        APLICADO
        CANCELADO
    End Enum

    Private Estado As enumEstados

    Private oBancosCXC As New Class_Bancos_CXC
    Private oCxcAfectaDocumentos As New Class_CXC_Afecta_Documentos
    Private oFormaPoliza As Frm_Contabilidad_Captura_Polizas
    Private oPolizaGlobal As Class_Contabilidad_Poliza_Global
    Private oDocumento As Class_CatDocumentos

    Private ClickSinEjecutar As Boolean = False
    Private bDocumentosCargados As Boolean = False
    Private bConsultando As Boolean = False

#End Region

#Region "Columnas grid pago"
    Private iGyDocID_BANCOS_DETALLE As Integer = 1
    Private iGyDocCODIGO_FORMA_PAGO As Integer = 2
    Private iGyDocNOMBRE_FORMA_PAGO As Integer = 3
    Private iGyDocFOLIO_DETALLE As Integer = 4
    Private iGyDocCODIGO_BANCO_EMISOR_NACIONAL As Integer = 5
    Private iGyDocNOMBRE_BANCO_EMISOR_NACIONAL As Integer = 6
    Private iGyDocCUENTA_EMISOR As Integer = 7
    Private iGyDocFECHA As Integer = 8
    Private iGyDocRFC_EMISOR As Integer = 9
    Private iGyDocMONTO As Integer = 10
    Private iGyDocCODIGO_MONEDA_SAT As Integer = 11
    Private iGyDocCUENTA_BENEFICIARIO As Integer = 12
    Private iGyDocCODIGO_BANCO_DESTINO_NACIONAL As Integer = 13
    Private iGyDocES_BANCO_EXTRANJERO As Integer = 14
#End Region

#Region "Columnas grid venta"
    Private iGyVentaFOLIO_DETALLE As Integer = 1
    Private iGyVentaCodigoCliente As Integer = 2
    Private iGyVentaNombreCliente As Integer = 3
    Private iGyVentaFecha As Integer = 4
    Private iGyVentaFolio As Integer = 5
    Private iGyVentaMoneda As Integer = 6
    Private iGyVentaMedioPago As Integer = 7
    Private iGyVentaBanco As Integer = 8
    Private iGyVentaTotal As Integer = 9
    Private iGyVentaSaldo As Integer = 10
    Private iGyVentaTotalDlls As Integer = 11
    Private iGyVentaSaldoDlls As Integer = 12
    Private iGyVentaPago As Integer = 13
    Private iGyVentaPagoPesos As Integer = 14
    Private iGyVentaSeleccion As Integer = 15
    Private iGyVentaReferencia As Integer = 16
    Private iGyVentaFechaPago As Integer = 17
    Private iGyVentaIvaPorPagar As Integer = 18
    Private iGyVentaDiferencia As Integer = 19
    Private iGyVentaVersionCFDI As Integer = 20
    Private iGyVentaFormaPago As Integer = 21
    Private iGyVentaMetodoPago As Integer = 22
    Private iGyVentaImporteMonedaVenta As Integer = 23
    Private iGyVentaSaldoAnteriorMonedaVenta As Integer = 24
    Private iGyVentaSaldoAnteriorMonedaPago As Integer = 25
    Private iGyVentaEsFacturaElectronica As Integer = 26
#End Region

#Region "Opciones"
    Private Sub tsbNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbNuevo.Click
        Me.Inicializa()
        Me.Cambia_Estado(enumEstados.NUEVO)
    End Sub

    Private Sub tsbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGrabar.Click
        If Me.GestionaGrabar() = True Then
            Me.Consultar()
        End If
    End Sub

    Private Sub tsbCancelar_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCancelar.Click
        If Me.CancelaPagosCXC() = True Then
            Me.Consultar()
        End If
    End Sub

    Private Sub tsbImprimirPoliza_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimirPoliza.Click
        Me.ImprimirPoliza()
    End Sub

    Private Sub tsbImprimirComprobante_Click(sender As Object, e As EventArgs) Handles tsbImprimirComprobante.Click
        Me.ImprimirComprobante()
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub

    Private Sub btnDepositosAnterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDepositosAnterior.Click
        Me.NavegadorDepositos("Anterior")
    End Sub

    Private Sub btnDepositosSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDepositosSiguiente.Click
        Me.NavegadorDepositos("Siguiente")
    End Sub

    Private Sub btnAgregarDocumentosClientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarDocumentosClientes.Click
        'If Me.CkbAnticipo.Checked = True Then
        '    If txtLEN(Me.txtMonto.Text) = True And valorNumerico(Me.txtMonto.Text) > 0 Then
        '        Me.AgregarAnticipoClientes()
        '    Else
        '        MsgBox("El anticipo debe ser mayor a 0.", MsgBoxStyle.Exclamation, "Validación de Anticipos")
        '        Me.txtMonto.Focus()
        '    End If
        'Else
        If Me.AgregaDocumentoPago() = True Then
            Me.InicializaDocumentoPago()
        End If
        'End If
    End Sub

    Private Sub btnLimpiarDocumentoPagos_Click(sender As Object, e As EventArgs) Handles btnLimpiarDocumentoPagos.Click
        Me.InicializaDocumentoPago()
    End Sub

    Private Sub btnEliminarDocumentoPago_Click(sender As Object, e As EventArgs) Handles btnEliminarDocumentoPago.Click
        If Me.EliminarDocumentoPago = True Then
            Me.Totales()
        End If
    End Sub

    Private Sub btnAgregarCuentaBancariaCliente_Click(sender As Object, e As EventArgs) Handles btnAgregarCuentaBancariaCliente.Click
        'Dim oCuentas As New Catalogo_ClientesCuentasBancarias(Catalogo_ClientesCuentasBancarias.Accion.AGREGAR)
        If txtLEN(Me.TxtCodigoCliente.Text) = False Then
            MsgBox("Seleccione primero un cliente.", MsgBoxStyle.Exclamation, Me.Text)
            If Me.TxtCodigoCliente.Enabled = True Then
                Me.TxtCodigoCliente.Focus()
            End If
            Return
        Else
            Me.GestionaAltaEdicionCuentaBancariaCliente(True)
        End If
    End Sub

    Private Sub btnEditarCuentaBancariaCliente_Click(sender As Object, e As EventArgs) Handles btnEditarCuentaBancariaCliente.Click
        If cboCuentaEmisor.SelectedIndex = -1 Then
            MsgBox("Seleccione una cuenta para poder editarla.", MsgBoxStyle.Exclamation, Me.Text)
        Else
            Me.GestionaAltaEdicionCuentaBancariaCliente(False)
        End If
    End Sub

    Private Sub btnVerCFDIS_Click(sender As Object, e As EventArgs) Handles btnVerCFDIS.Click
        Try
            Dim oCFDIS As New Frm_CXC_CFDI_Pagos(Me.TxtFolio.Text)
            oCFDIS.ShowDialog()
            oCFDIS.Dispose()
        Catch ex As Exception
            HandleError(Me.Name, "btnVerCFDIS_Click", ex)
        End Try

    End Sub

    Private Sub cmdPruebaPagoCFDI_Click(sender As Object, e As EventArgs) Handles cmdPruebaPagoCFDI.Click
        'Me.oBancosCXC.GeneraPagosElectronicos()
        'GeneraPagoElectronico33Prueba()

        Me.TxtCuentaBancaria.Text = "1"
        TxtCuentaBancaria_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
        TxtFolio_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
        Me.TxtCodigoCliente.Text = "CN0002"
        TxtCodigoCliente_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
        Me.txtMonto.Text = "100"
        Me.txtFolioDetalle.Text = "x1"
        Me.chkVentasNoFiscales.Checked = True

    End Sub

    Private Sub cmdSeleccionaSPEI_Click(sender As Object, e As EventArgs) Handles cmdSeleccionaSPEI.Click
        Me.SeleccionarSPEI()
    End Sub

    Private Sub btnGenerarCFDIS_Click(sender As Object, e As EventArgs) Handles btnGenerarCFDIS.Click
        Dim bHuboTimbrados As Boolean = False

        If MsgBox("Desea generar el cfdi de pagos ?", vbQuestion Or MsgBoxStyle.YesNo, Me.Text) = vbYes Then
            If Me.ValidaVentasTimbradas = True Then
                If Me.oBancosCXC.GestionaCFDI() = True Then
                    bHuboTimbrados = Me.oBancosCXC.GeneraPagosElectronicos()
                End If
                Me.Consultar()
                If bHuboTimbrados = True Then
                    btnVerCFDIS_Click(sender, e)
                End If
            End If
        End If

    End Sub

#End Region

#Region "Eventos de objetos"
    Private Sub Frm_CXC_Pagos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.DesplegarDocumentos()
            Me.DesplegarBancos()
            Me.DesplegarMedioDePagos()
            Me.DesplegarMetodosPago()
            Me.DesplegarMonedas()

            Me.Inicializa()

            Me.Cambia_Estado(enumEstados.NUEVO)

            If My.Computer.Name = "PCSISTEMASJORGE" Then
                Me.cmdPruebaPagoCFDI.Visible = True
            Else
                Me.cmdPruebaPagoCFDI.Visible = False
            End If

        Catch ex As Exception
            HandleError(Me.Name, "Frm_CXC_Pagos_Load", ex)
        End Try
    End Sub

    Private Sub Frm_CXC_Pagos_Acreedores_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If Me.Estado = enumEstados.NUEVO And Me.TxtCuentaBancaria.Enabled = True Then
            Me.TxtCuentaBancaria.Focus()
        End If
    End Sub

    Private Sub CboDocumento_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboDocumento.SelectedIndexChanged
        Try
            'Me.oVenta.CODIGO_DOCUMENTO = Me.CboDocumento.SelectedValue.ToString
            Me.oDocumento = New Class_CatDocumentos(Me.CboDocumento.SelectedValue.ToString)
            Me.Inicializa()
            Me.Cambia_Estado(enumEstados.NUEVO)
        Catch ex As Exception
            HandleError(Me.Name, "CboDocumento_SelectedIndexChanged", ex)
        End Try
    End Sub

    Private Sub TxtCuentaBancaria_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCuentaBancaria.KeyDown
        Dim oCuentaBancaria As Class_CatCuentasBancarias

        Try
            Select Case e.KeyCode
                Case Keys.F6
busqueda_Visual:
                    oCuentaBancaria = New Class_CatCuentasBancarias
                    Dim sIdCodigoBanco As String = oCuentaBancaria.BusquedaVisual_PorDescripcionSoloActivos

                    If txtLEN(sIdCodigoBanco) = True Then
                        Me.TxtCuentaBancaria.Text = sIdCodigoBanco
                        GoTo enter : Exit Sub
                    End If

                Case Keys.Return

                    If txtLEN(Me.TxtCuentaBancaria.Text) = False Then
                        Me.LblCuentaBancaria.Text = ""
                        Me.LblCuentaContableCuentaBancaria.Text = ""
                        GoTo busqueda_Visual : Exit Sub
                    End If
enter:

                    oCuentaBancaria = New Class_CatCuentasBancarias(CInt(Me.TxtCuentaBancaria.Text))

                    If oCuentaBancaria.Existe = False Then
                        Me.LblCuentaBancaria.Text = ""
                        Me.LblCuentaContableCuentaBancaria.Text = ""
                        GoTo busqueda_Visual : Exit Sub
                    End If

                    Me.TxtCuentaBancaria.Enabled = False
                    Me.gbAgregaDocCliente.Enabled = True  'Se habilita hasta asignar una cuenta bancaria
                    Me.gbVentas.Enabled = True

                    Me.TxtCuentaBancaria.Text = oCuentaBancaria.ID_CUENTA_BANCARIA.ToString
                    Me.LblCuentaBancaria.Text = oCuentaBancaria.NOMBRE_CUENTA_BANCARIA.ToString
                    Me.LblCuentaContableCuentaBancaria.Text = oCuentaBancaria.CUENTA_CONTABLE_PESOS
                    Me.cboMoneda.SelectedIndex = -1
                    Me.cboMoneda.Text = oCuentaBancaria.CODIGO_MONEDA_SAT

                    Me.chkVentasNoFiscales.Enabled = False 'Siempre va estar deshabilitado, se va marcar sólo dependiendo de si la cuenta es o no fiscal. En el cambiar estado no cambia este valor
                    If oCuentaBancaria.ES_CUENTA_FISCAL = True Then 'Si es cuenta fiscal, sólo va permitir pagos de remisiones
                        Me.chkVentasNoFiscales.Checked = False
                        Me.lblEsCuentaFiscal.Text = "Sólo facturas"
                        Me.cboTipoVentas.Text = "MISMO RFC CLIENTE"
                    Else 'Si es cuenta no fiscal sólo va permitir pagos de remisiones
                        Me.chkVentasNoFiscales.Checked = True
                        Me.lblEsCuentaFiscal.Text = "Sólo remisiones"
                        Me.cboTipoVentas.Text = "MISMO CODIGO CLIENTE"
                    End If

                    Me.GeneraFolio()
                    Me.TxtFolio.Focus()

            End Select
        Catch ex As Exception
            HandleError(Me.Name, "TxtCuentaBancaria_KeyDown", ex)
        End Try
    End Sub

    Private Sub TxtFolio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtFolio.KeyDown
        Try
            Dim sText As String
            Select Case e.KeyCode
                Case Keys.F6
                    sText = BusquedaVisual_PorDescripcion()
                    If txtLEN(sText) = True Then
                        Me.TxtFolio.Text = sText
                        Me.Consultar()
                    End If
                Case Keys.Return
                    If txtLEN(Me.TxtFolio.Text) = True Then
                        If Me.Consultar() = True Then
                            Me.dtFecha.Focus()
                        End If
                    Else
                        Me.GeneraFolio()
                    End If

                    'If txtLEN(Me.TxtFolio.Text) = True Then
                    '    If Me.Consultar() = False Then
                    '        Me.GeneraFolio()
                    '    End If
                    'Else
                    '    Me.GeneraFolio()
                    'End If
                    'Me.dtFecha.Focus()
            End Select
        Catch ex As Exception
            HandleError(Me.Name, "TxtFolio_KeyDown", ex)
        End Try
    End Sub

    Private Sub TxtCodigoCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodigoCliente.KeyDown
        Dim oCliente As Class_CatClientes
        Try
            Select Case e.KeyCode
                Case Keys.F6
Buscar:
                    oCliente = New Class_CatClientes()

                    If Empresa_Sistema.PERMITE_CLIENTES_MULTIPLAZA = True Then
                        Me.TxtCodigoCliente.Text = oCliente.BusquedaVisual_PorDescripcionSinFiltroZona
                    Else
                        Me.TxtCodigoCliente.Text = oCliente.BusquedaVisual_PorDescripcion
                    End If

                    oCliente = Nothing

                Case Keys.Enter
                    If txtLEN(Me.TxtCodigoCliente.Text) = False Then
                        Me.LblCliente.Text = "" : Me.TxtCodigoCliente.Focus() : GoTo Buscar : Exit Sub
                    End If

                    oCliente = New Class_CatClientes(Me.TxtCodigoCliente.Text)
                    If oCliente.Existe = False Then
                        MsgBox("El código de Cliente que intenta buscar no existe o esta dado de baja, favor de intentar con otro código.", MsgBoxStyle.Exclamation, "Validación de Clientes")
                        Me.LblCliente.Text = "" : GoTo Buscar : Exit Sub
                    Else
                        'Me.LblCliente.Text = Sql.Result1
                        Me.LblCliente.Text = oCliente.NOMBRE_CLIENTE
                        Me.txtRFCEmisor.Text = oCliente.RFC
                        Me.lblRFCEmisor.Text = Me.LblCliente.Text
                        'Me.CboMedioDePago.Focus()
                        Me.cboFormaPago.Focus()

                        Me.CargaCuentasBancariasCliente()

                    End If
                    'sql = Nothing
            End Select
        Catch ex As Exception
            HandleError(Me.Name, "TxtCodigoCliente_KeyDown", ex)
        End Try
    End Sub

    Private Sub TxtConcepto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtConcepto.KeyDown
        If e.KeyCode = Keys.Return Then
            'Me.Grid1.Cell(1, Me.iGyPago).SetFocus()
            Me.TxtCodigoCliente.Focus()
        End If
    End Sub

    Private Sub cboMoneda_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMoneda.SelectedIndexChanged
        Try
            If Me.cboMoneda.Text = "USD" Then
                Me.txtTipoCambio.Enabled = True
                'Me.txtTotalDolares.Enabled = True
                Me.lblTipoCambio.Enabled = True
                ' Me.lblTotalDolares.Enabled = True
                Me.txtTipoCambio.Focus()

                'Me.Grid.Column(Me.iGyFolio).Width = 50
                'Me.Grid.Column(Me.iGyFecha).Width = 60
                Me.GridVentas.Column(Me.iGyVentaTotal).Visible = False
                Me.GridVentas.Column(Me.iGyVentaSaldo).Visible = False
                Me.GridVentas.Column(Me.iGyVentaTotalDlls).Visible = True
                Me.GridVentas.Column(Me.iGyVentaSaldoDlls).Visible = True
                Me.GridVentas.Column(Me.iGyVentaDiferencia).Visible = True
                Me.GridVentas.Column(Me.iGyVentaPagoPesos).Visible = True
            Else
                Me.txtTipoCambio.Enabled = False : Me.txtTipoCambio.Text = ""
                'Me.txtTotalDolares.Enabled = False
                Me.lblTipoCambio.Enabled = False
                'Me.lblTotalDolares.Enabled = False : Me.txtImporteDolares.Text = ""
                'Me.Grid.Column(Me.iGyFolio).Width = 95
                'Me.Grid.Column(Me.iGyFecha).Width = 90
                Me.GridVentas.Column(Me.iGyVentaTotal).Visible = True
                Me.GridVentas.Column(Me.iGyVentaSaldo).Visible = True
                Me.GridVentas.Column(Me.iGyVentaTotalDlls).Visible = False
                Me.GridVentas.Column(Me.iGyVentaSaldoDlls).Visible = False
                Me.GridVentas.Column(Me.iGyVentaDiferencia).Visible = False
                Me.GridVentas.Column(Me.iGyVentaPagoPesos).Visible = False
            End If
        Catch ex As Exception
            HandleError(Me.Name, "cboMoneda_SelectedIndexChanged", ex)
        End Try
    End Sub

    Private Sub txtTipoCambio_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTipoCambio.KeyDown
        Dim dTipoCambio As Decimal = 0
        If e.KeyCode = Keys.Return Then
            dTipoCambio = valorNumericoD(Me.txtTipoCambio.Text)
            dTipoCambio = RedondearD(dTipoCambio, 4)
            Me.txtTipoCambio.Text = Format(dTipoCambio, "##0.0000")

            If valorNumerico(Me.txtTipoCambio.Text) <= 0 Or valorNumerico(Me.txtTipoCambio.Text) > 30 Then
                MsgBox("Tipo de cambio incorrecto.", MsgBoxStyle.Exclamation, "Validación de tipo de cambio.")
                Me.txtTipoCambio.Text = Format(0, "##0.0000")
                Exit Sub
            Else
                Me.CalculaImporteDolares()
            End If
            Me.TxtConcepto.Focus()
            'SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtReferencia_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtReferencia.KeyDown
        If e.KeyCode = Keys.Return Then
            'Me.Grid1.Cell(1, Me.iGyPago).SetFocus()
            'Me.CkbAnticipo.Focus()
            Me.btnAgregarDocumentosClientes.Focus()
        End If
    End Sub

    'Private Sub CkbAnticipo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CkbAnticipo.CheckedChanged
    '    If Me.CkbAnticipo.Checked = True Then
    '        Me.txtAnticipo.Visible = True
    '        Me.lblDisplayAnticipo.Visible = True
    '        Me.txtAnticipo.Focus()
    '    Else
    '        Me.txtAnticipo.Visible = False
    '        Me.lblDisplayAnticipo.Visible = False
    '        Me.btnAgregarDocumentosClientes.Focus()
    '    End If
    'End Sub

    'Private Sub txtAnticipo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    '    If e.KeyCode = Keys.Return Then
    '        If txtLEN(Me.txtAnticipo.Text) = True Then
    '            Me.txtAnticipo.Text = FormatImporteContable(CDbl(Me.txtAnticipo.Text))
    '            'Me.CalculaImporteDolares()
    '            SendKeys.Send("{TAB}")
    '        End If
    '    End If
    'End Sub

    'Private Sub chkAnticipo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles chkAnticipo.KeyDown
    '    If e.KeyCode = Keys.Return Then
    '        If Me.chkAnticipo.Checked = True Then
    '            Me.btnAgregarDocumentosClientes.Focus()
    '        End If
    '    End If
    'End Sub

    Private Sub LblPoliza_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LblPoliza.LinkClicked
        Dim Child As New Frm_Contabilidad_Captura_Polizas()
        Child.FolioPolizaConsultaExterior = Me.LblPoliza.Text
        Child.ShowDialog()
        Child.Dispose()
    End Sub

    Private Sub Grid_KeyDown(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridVentas.KeyDown
        GestionaGrid(e)
    End Sub

    Private Sub txtRFCEmisor_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRFCEmisor.KeyDown
        Dim sText As String, oCliente As Class_CatClientes
        Try
            Select Case e.KeyCode
                Case Keys.F6
Buscar:
                    oCliente = New Class_CatClientes
                    sText = oCliente.BusquedaVisual_PorDescripcionRegresandoRFC(False)
                    If txtLEN(sText) = True Then Me.txtRFCEmisor.Text = sText

                Case Keys.Enter
                    If txtLEN(Me.txtRFCEmisor.Text) = False Then
                        Me.lblRFCEmisor.Text = "" : GoTo Buscar : Exit Sub
                    End If

                    Dim sql As New Class_find("SELECT NOMBRE_CLIENTE FROM CAT_CLIENTES WHERE RFC='" & sReplace(Me.txtRFCEmisor.Text) & "'")
                    Me.lblRFCEmisor.Text = sql.Result1
                    If txtLEN(Me.lblRFCEmisor.Text) = False Then
                        GoTo Buscar : Exit Sub
                    End If
                    txtTAB(e)
                    sql = Nothing

            End Select
        Catch ex As Exception
            HandleError(Me.Name, "txtRFCEmisor_KeyDown", ex)
        End Try
    End Sub

    Private Sub txtMonto_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMonto.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.txtMonto.Text = FormatImporteContable(valorNumerico(Me.txtMonto.Text))
            If valorNumerico(Me.txtMonto.Text) > 0 Then
                SendKeys.Send("{TAB}")
            Else
                MsgBox("Capture por favor el monto total del documento que esta capturando.", MsgBoxStyle.Exclamation, Me.Text)
            End If
        End If
    End Sub

    Private Sub cboFormaPago_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFormaPago.SelectedIndexChanged
        Try
            Dim bEsFormaPagoBancarizada As Boolean = False
            Dim oFormaPago As New Class_CFD_CatFormasPago

            If Me.cboFormaPago.SelectedIndex <> -1 Then
                oFormaPago = New Class_CFD_CatFormasPago(Me.cboFormaPago.SelectedValue.ToString)

                'If Me.cboFormaPago.SelectedValue.ToString = "02" Or Me.cboFormaPago.SelectedValue.ToString = "03" Then '02=CHEQUE NOMINATIVO, 03=TRANSFERENCIA ELECTRONICA DE FONDOS
                If oFormaPago.ES_BANCARIZADO = True Then
                    bEsFormaPagoBancarizada = True
                End If
            End If

            If bEsFormaPagoBancarizada = True Then
                Me.txtCuentaEmisor.Visible = True : Me.lblDisplayCuentaEmisor.Visible = True
                Me.CboBancos.Visible = True : Me.LblDisplayBanco.Visible = True

                If Me.cboFormaPago.SelectedValue.ToString = "02" Then '02=Cheque
                    Me.dtFechaCheque.Visible = True : Me.lblDisplayFechaCheque.Visible = True
                Else
                    Me.dtFechaCheque.Visible = False : Me.lblDisplayFechaCheque.Visible = False
                End If
                'If oFormaPago.PERMITE_SPEI = True Then
                '    Me.cmdSeleccionaSPEI.Visible = True
                '    Me.txtSPEI_cadenaCDA.Visible = True : Me.txtSPEI_numeroCertificado.Visible = True : Me.txtSPEI_sello.Visible = True
                'Else
                '    Me.cmdSeleccionaSPEI.Visible = False
                '    Me.txtSPEI_cadenaCDA.Visible = False : Me.txtSPEI_numeroCertificado.Visible = False : Me.txtSPEI_sello.Visible = False
                'End If
            Else
                Me.txtCuentaEmisor.Text = ""
                Me.CboBancos.SelectedIndex = -1
                Me.CboBancos.Visible = False : Me.LblDisplayBanco.Visible = False
                Me.txtCuentaEmisor.Visible = False : Me.lblDisplayCuentaEmisor.Visible = False
                Me.CboBancos.Visible = False : Me.LblDisplayBanco.Visible = False
                Me.dtFechaCheque.Visible = False : Me.lblDisplayFechaCheque.Visible = False
                Me.cmdSeleccionaSPEI.Visible = False
                Me.txtSPEI_cadenaCDA.Visible = False : Me.txtSPEI_numeroCertificado.Visible = False : Me.txtSPEI_sello.Visible = False
            End If
        Catch ex As Exception
            HandleError(Me.Name, "cboFormaPago_SelectedIndexChanged", ex)
        End Try
    End Sub

    Private Sub cboCuentaEmisor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCuentaEmisor.SelectedIndexChanged
        If Me.cboCuentaEmisor.SelectedIndex <> -1 Then
            Me.SeleccionaCuentaEmisor()
        End If
    End Sub


    Private Sub Grid1_CellChanging(ByVal Sender As Object, ByVal e As FlexCell.Grid.CellChangingEventArgs) Handles GridVentas.CellChanging
        Try
            Dim Columna As Integer = e.Col, Renglon As Integer = e.Row
            Dim dPago As Double
            If e.Col = Me.iGyVentaSeleccion And e.Row > 0 Then
                If Me.GridVentas.Cell(Renglon, Me.iGyVentaSeleccion).Text = "1" And Me.ClickSinEjecutar = False Then
                    If Me.cboMoneda.Text = "USD" Then
                        If valorNumerico(Me.txtTipoCambio.Text) <= 0 Or valorNumerico(Me.txtTipoCambio.Text) > 30 Then
                            MsgBox("Tipo de cambio incorrecto.", MsgBoxStyle.Exclamation, "Validación de tipo de cambio.")
                            Me.txtTipoCambio.Focus()
                            Exit Sub
                        End If

                        dPago = valorNumerico(Me.GridVentas.Cell(Renglon, Me.iGyVentaSaldoDlls).Text)
                        If dPago > 0 Then
                            Me.ClickSinEjecutar = True
                            Me.GridVentas.Cell(Renglon, Me.iGyVentaPago).Text = dPago.ToString
                            CalculaImportesPagoUSD(Renglon)
                            Me.ClickSinEjecutar = False
                        End If
                    Else
                        dPago = valorNumerico(Me.GridVentas.Cell(Renglon, Me.iGyVentaSaldo).Text)
                        If dPago > 0 Then
                            Me.ClickSinEjecutar = True
                            Me.GridVentas.Cell(Renglon, Me.iGyVentaPago).Text = dPago.ToString
                            CalculaImportesPagoMXN(Renglon)
                            Me.ClickSinEjecutar = False
                        End If
                    End If

                Else
                    Me.BorraPago(Renglon)
                End If
            End If

            If Me.bConsultando = False Then
                Me.Totales()
            End If

        Catch ex As Exception
            HandleError(Me.Name, "Grid1_CellChanging", ex)
        End Try
    End Sub

    Private Sub chkVentasNoFiscales_CheckedChanged(sender As Object, e As EventArgs) Handles chkVentasNoFiscales.CheckedChanged
        Select Case Me.chkVentasNoFiscales.Checked
            Case True
                'Me.chkAnticipo.Visible = True
                Me.btnGenerarCFDIS.Visible = False
                Me.btnVerCFDIS.Visible = False
            Case False
                'Me.chkAnticipo.Visible = False
                Me.btnGenerarCFDIS.Visible = True
                Me.btnVerCFDIS.Visible = True
        End Select
    End Sub

#Region "Eventos Genericos"
    Private Sub txt_Enter(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim oTexBox As TextBox = CType(sender, TextBox)
        oTexBox.SelectAll()
    End Sub

    Private Sub txt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CboDocumento.KeyDown, dtFecha.KeyDown, CboMedioDePago.KeyDown, CboBancos.KeyDown, cboFormaPago.KeyDown, txtFolioDetalle.KeyDown, txtCuentaEmisor.KeyDown, dtFechaPagoCliente.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtNumerosEnterosKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCuentaBancaria.KeyPress, txtCuentaEmisor.KeyPress
        txtSoloNumerosEnteros(e)
        txtNoBeep(e)
    End Sub

    Private Sub txtNumerosDecimalKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTipoCambio.KeyPress, txtMonto.KeyPress
        Dim txt As TextBox = CType(sender, TextBox)
        txtSoloNumerosDecimales(e, txt.Text)
        txtNoBeep(e)
    End Sub

    Private Sub txtTextoKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CboDocumento.KeyPress, TxtFolio.KeyPress,
    dtFecha.KeyPress, TxtConcepto.KeyPress, TxtCodigoCliente.KeyPress, TxtReferencia.KeyPress, txtFolioDetalle.KeyPress, txtCuentaEmisor.KeyPress, txtRFCEmisor.KeyPress, dtFechaPagoCliente.KeyPress
        txtNoBeep(e)
    End Sub
#End Region

#End Region

#Region "Métodos y procedimientos"
    Private Sub Inicializa()
        Try
            Me.TxtFolio.Text = ""
            Me.dtFecha.Value = Date.Now
            Me.TxtConcepto.Text = ""
            Me.LblPoliza.Text = ""
            Me.LblStatus.Text = "NUEVO"

            Me.TxtCodigoCliente.Text = ""
            Me.LblCliente.Text = ""
            Me.cboCuentaEmisor.DataSource = Nothing
            Me.CboBancos.SelectedIndex = -1
            'Me.CboMedioDePago.SelectedIndex = -1
            Me.CboMedioDePago.SelectedValue = 0
            Me.TxtReferencia.Text = ""
            Me.txtMonto.Text = "" : Me.chkAnticipo.Checked = False

            Me.TxtTotal.Text = ""

            Me.InicializaGridVentas()
            Me.lstClientesAgregados.Items.Clear()

            Me.InicializaDocumentoPago()
            Me.InicializaGridDocumentosPago()

            Me.GeneraFolio()

            Dim sMonedaAnterior As String = Me.cboMoneda.Text
            Me.cboMoneda.SelectedIndex = -1
            Me.cboMoneda.Text = sMonedaAnterior
            'Me.cboMoneda.Text = "MXN" no se debe inicializar por si dejaron seleccionada moneda en usd no debe perderse la moneda y demás datos de la cuenta
            Me.txtTipoCambio.Text = ""

            'Me.chkVentasNoFiscales.Checked = False'No se debe inicializar, cuando se consulta un doc, o cuando den enter a una cuenta se carga.
            'Me.lblEsCuentaFiscal.Text = "Sólo facturas'No se debe inicializar, cuando se consulta un doc, o cuando den enter a una cuenta se carga.

            Me.tssElaboro.Text = "Elaboró : "
            Me.tssCancelo.Text = "Canceló : "
            Me.tssFechaEmisionCFDI.Text = ""
        Catch ex As Exception
            HandleError(Me.Name, "Inicializa", ex)
        End Try
    End Sub

    Private Sub InicializaGridVentas()
        Try
            Me.GridVentas.DataSource = Nothing
            FG_Grid_Limpiar(GridVentas)

            'Creamos el Grid
            Me.GridVentas.Rows = 2
            Me.GridVentas.Cols = 27
            Me.GridVentas.DisplayRowNumber = True

            Me.FormateaGridVentas()
        Catch ex As Exception
            HandleError(Me.Name, "InicializaGrid", ex)
        End Try
    End Sub

    Private Sub InicializaGridDocumentosPago()
        Try
            With Me.GridDocumentosPago
                .DataSource = Nothing
                FG_Grid_Limpiar(Me.GridDocumentosPago)
                .Rows = 2
                .Cols = 15
                .DisplayRowNumber = True
                Me.FormateaGridDocumentosPago()
            End With
        Catch ex As Exception
            HandleError(Me.Name, "InicializaGridDocumentosPago", ex)
        End Try
    End Sub

    Private Sub FormateaGridVentas()
        Try
            'Me.Grid.Visible = False

            Me.GridVentas.Column(Me.iGyVentaFOLIO_DETALLE).Width = 80
            Me.GridVentas.Column(Me.iGyVentaCodigoCliente).Width = 45
            Me.GridVentas.Column(Me.iGyVentaNombreCliente).Width = 120
            Me.GridVentas.Column(Me.iGyVentaFecha).Width = 65
            Me.GridVentas.Column(Me.iGyVentaFolio).Width = 80
            Me.GridVentas.Column(Me.iGyVentaMoneda).Width = 50
            'Me.Grid.Column(Me.iGyMedioPago).Width = 95
            'Me.Grid.Column(Me.iGyBanco).Width = 80
            'Me.Grid.Column(Me.iGyReferencia).Width = 95
            Me.GridVentas.Column(Me.iGyVentaMedioPago).Visible = False
            Me.GridVentas.Column(Me.iGyVentaBanco).Visible = False
            Me.GridVentas.Column(Me.iGyVentaReferencia).Visible = False
            Me.GridVentas.Column(Me.iGyVentaTotal).Width = 80
            Me.GridVentas.Column(Me.iGyVentaSaldo).Width = 80
            Me.GridVentas.Column(Me.iGyVentaTotalDlls).Width = 80
            Me.GridVentas.Column(Me.iGyVentaSaldoDlls).Width = 80
            Me.GridVentas.Column(Me.iGyVentaPago).Width = 80
            Me.GridVentas.Column(Me.iGyVentaPagoPesos).Width = 80
            Me.GridVentas.Column(Me.iGyVentaSeleccion).Width = 60
            Me.GridVentas.Column(Me.iGyVentaDiferencia).Width = 80
            Me.GridVentas.Column(Me.iGyVentaIvaPorPagar).Width = 60
            Me.GridVentas.Column(Me.iGyVentaFechaPago).Width = 65
            Me.GridVentas.Column(Me.iGyVentaVersionCFDI).Width = 50
            Me.GridVentas.Column(Me.iGyVentaFormaPago).Width = 60
            Me.GridVentas.Column(Me.iGyVentaMetodoPago).Width = 60
            Me.GridVentas.Column(Me.iGyVentaImporteMonedaVenta).Width = 60
            Me.GridVentas.Column(Me.iGyVentaSaldoAnteriorMonedaPago).Width = 60
            Me.GridVentas.Column(Me.iGyVentaSaldoAnteriorMonedaVenta).Width = 60
            Me.GridVentas.Column(Me.iGyVentaEsFacturaElectronica).Width = 60

            Me.GridVentas.Cell(0, Me.iGyVentaFOLIO_DETALLE).Text = "Folio pago"
            Me.GridVentas.Cell(0, Me.iGyVentaCodigoCliente).Text = "Código"
            Me.GridVentas.Cell(0, Me.iGyVentaNombreCliente).Text = "Nombre"
            Me.GridVentas.Cell(0, Me.iGyVentaFecha).Text = "Fecha"
            Me.GridVentas.Cell(0, Me.iGyVentaFolio).Text = "Folio"
            Me.GridVentas.Cell(0, Me.iGyVentaMoneda).Text = "Moneda"
            Me.GridVentas.Cell(0, Me.iGyVentaMedioPago).Text = "Medio de pago"
            Me.GridVentas.Cell(0, Me.iGyVentaBanco).Text = "Banco"
            Me.GridVentas.Cell(0, Me.iGyVentaTotal).Text = "Total"
            Me.GridVentas.Cell(0, Me.iGyVentaSaldo).Text = "Saldo"
            Me.GridVentas.Cell(0, Me.iGyVentaTotalDlls).Text = "Total Dlls"
            Me.GridVentas.Cell(0, Me.iGyVentaSaldoDlls).Text = "Saldo Dlls"
            Me.GridVentas.Cell(0, Me.iGyVentaPago).Text = "Pagar"
            Me.GridVentas.Cell(0, Me.iGyVentaPagoPesos).Text = "Pagar Pesos"
            Me.GridVentas.Cell(0, Me.iGyVentaSeleccion).Text = "Selección"
            Me.GridVentas.Cell(0, Me.iGyVentaReferencia).Text = "Referencia"
            Me.GridVentas.Cell(0, Me.iGyVentaDiferencia).Text = "Diferencia"
            Me.GridVentas.Cell(0, Me.iGyVentaIvaPorPagar).Text = "IvaXPagar"
            Me.GridVentas.Cell(0, Me.iGyVentaFechaPago).Text = "Fecha pago"
            Me.GridVentas.Cell(0, Me.iGyVentaVersionCFDI).Text = "V.CFDI"
            Me.GridVentas.Cell(0, Me.iGyVentaFormaPago).Text = "F. Pago"
            Me.GridVentas.Cell(0, Me.iGyVentaMetodoPago).Text = "M. Pago"
            Me.GridVentas.Cell(0, Me.iGyVentaImporteMonedaVenta).Text = "ImporteMonedaVenta"
            Me.GridVentas.Cell(0, Me.iGyVentaSaldoAnteriorMonedaPago).Text = "SaldoAnteriorMonedaPago"
            Me.GridVentas.Cell(0, Me.iGyVentaSaldoAnteriorMonedaVenta).Text = "SaldoAnteriorMonedaVenta"
            Me.GridVentas.Cell(0, Me.iGyVentaEsFacturaElectronica).Text = "FacElec"

            Me.DespliegaCombosGrid()

            Me.GridVentas.Column(Me.iGyVentaFecha).CellType = FlexCell.CellTypeEnum.DateTime
            Me.GridVentas.Column(Me.iGyVentaFecha).FormatString = "dd-MMM-yy"

            Me.GridVentas.Column(Me.iGyVentaTotal).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
            Me.GridVentas.Column(Me.iGyVentaTotal).Mask = FlexCell.MaskEnum.Numeric
            Me.GridVentas.Column(Me.iGyVentaTotal).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
            Me.GridVentas.Column(Me.iGyVentaTotal).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.GridVentas.Column(Me.iGyVentaSaldo).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
            Me.GridVentas.Column(Me.iGyVentaSaldo).Mask = FlexCell.MaskEnum.Numeric
            Me.GridVentas.Column(Me.iGyVentaSaldo).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
            Me.GridVentas.Column(Me.iGyVentaSaldo).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.GridVentas.Column(Me.iGyVentaPago).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
            Me.GridVentas.Column(Me.iGyVentaPago).Mask = FlexCell.MaskEnum.Numeric
            Me.GridVentas.Column(Me.iGyVentaPago).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
            Me.GridVentas.Column(Me.iGyVentaPago).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.GridVentas.Column(Me.iGyVentaPagoPesos).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
            Me.GridVentas.Column(Me.iGyVentaPagoPesos).Mask = FlexCell.MaskEnum.Numeric
            Me.GridVentas.Column(Me.iGyVentaPagoPesos).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
            Me.GridVentas.Column(Me.iGyVentaPagoPesos).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.GridVentas.Column(Me.iGyVentaTotalDlls).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
            Me.GridVentas.Column(Me.iGyVentaTotalDlls).Mask = FlexCell.MaskEnum.Numeric
            Me.GridVentas.Column(Me.iGyVentaTotalDlls).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
            Me.GridVentas.Column(Me.iGyVentaTotalDlls).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.GridVentas.Column(Me.iGyVentaSaldoDlls).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
            Me.GridVentas.Column(Me.iGyVentaSaldoDlls).Mask = FlexCell.MaskEnum.Numeric
            Me.GridVentas.Column(Me.iGyVentaSaldoDlls).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
            Me.GridVentas.Column(Me.iGyVentaSaldoDlls).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.GridVentas.Column(Me.iGyVentaDiferencia).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
            Me.GridVentas.Column(Me.iGyVentaDiferencia).Mask = FlexCell.MaskEnum.Numeric
            Me.GridVentas.Column(Me.iGyVentaDiferencia).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
            Me.GridVentas.Column(Me.iGyVentaDiferencia).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.GridVentas.Column(Me.iGyVentaIvaPorPagar).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
            Me.GridVentas.Column(Me.iGyVentaIvaPorPagar).Mask = FlexCell.MaskEnum.Numeric
            Me.GridVentas.Column(Me.iGyVentaIvaPorPagar).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
            Me.GridVentas.Column(Me.iGyVentaIvaPorPagar).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.GridVentas.Column(Me.iGyVentaSeleccion).CellType = FlexCell.CellTypeEnum.CheckBox

            Me.GridVentas.Column(Me.iGyVentaFechaPago).CellType = FlexCell.CellTypeEnum.DateTime
            Me.GridVentas.Column(Me.iGyVentaFechaPago).FormatString = "dd-MMM-yy"

            Me.GridVentas.Refresh()

            Me.GridVentas.Column(Me.iGyVentaCodigoCliente).Locked = True
            Me.GridVentas.Column(Me.iGyVentaNombreCliente).Locked = True
            Me.GridVentas.Column(Me.iGyVentaFecha).Locked = True
            Me.GridVentas.Column(Me.iGyVentaFolio).Locked = True
            Me.GridVentas.Column(Me.iGyVentaMoneda).Locked = True
            Me.GridVentas.Column(Me.iGyVentaMedioPago).Locked = False
            Me.GridVentas.Column(Me.iGyVentaBanco).Locked = False
            Me.GridVentas.Column(Me.iGyVentaTotal).Locked = True
            Me.GridVentas.Column(Me.iGyVentaSaldo).Locked = True
            Me.GridVentas.Column(Me.iGyVentaTotalDlls).Locked = True
            Me.GridVentas.Column(Me.iGyVentaSaldoDlls).Locked = True
            Me.GridVentas.Column(Me.iGyVentaPago).Locked = False
            Me.GridVentas.Column(Me.iGyVentaPagoPesos).Locked = True
            Me.GridVentas.Column(Me.iGyVentaReferencia).Locked = False
            Me.GridVentas.Column(Me.iGyVentaDiferencia).Locked = True
            Me.GridVentas.Column(Me.iGyVentaTotalDlls).Visible = False
            Me.GridVentas.Column(Me.iGyVentaSaldoDlls).Visible = False
            Me.GridVentas.Column(Me.iGyVentaPagoPesos).Visible = False
            Me.GridVentas.Column(Me.iGyVentaDiferencia).Visible = False
            Me.GridVentas.Column(Me.iGyVentaIvaPorPagar).Visible = True
            Me.GridVentas.Column(Me.iGyVentaFechaPago).Visible = True
            Me.GridVentas.Column(Me.iGyVentaVersionCFDI).Visible = True
            Me.GridVentas.Column(Me.iGyVentaFormaPago).Visible = True
            Me.GridVentas.Column(Me.iGyVentaMetodoPago).Visible = True
            Me.GridVentas.Column(Me.iGyVentaImporteMonedaVenta).Visible = False
            Me.GridVentas.Column(Me.iGyVentaSaldoAnteriorMonedaPago).Visible = False
            Me.GridVentas.Column(Me.iGyVentaSaldoAnteriorMonedaVenta).Visible = False
            Me.GridVentas.Column(Me.iGyVentaEsFacturaElectronica).Visible = False

            'Me.Grid.Visible = True
        Catch ex As Exception
            HandleError(Me.Name, "FormateaGridVentas", ex)
            'Me.Grid.Visible = True
        End Try
    End Sub

    Private Sub FormateaGridDocumentosPago()
        Try
            With Me.GridDocumentosPago
                .Column(Me.iGyDocID_BANCOS_DETALLE).Visible = False
                .Column(Me.iGyDocCODIGO_FORMA_PAGO).Width = 80
                .Column(Me.iGyDocNOMBRE_FORMA_PAGO).Width = 110
                .Column(Me.iGyDocFOLIO_DETALLE).Width = 70
                .Column(Me.iGyDocCODIGO_BANCO_EMISOR_NACIONAL).Width = 100
                .Column(Me.iGyDocNOMBRE_BANCO_EMISOR_NACIONAL).Width = 110
                .Column(Me.iGyDocCUENTA_EMISOR).Width = 100
                .Column(Me.iGyDocFECHA).Width = 70
                .Column(Me.iGyDocRFC_EMISOR).Width = 90
                .Column(Me.iGyDocMONTO).Width = 80
                .Column(Me.iGyDocCODIGO_MONEDA_SAT).Width = 60
                .Column(Me.iGyDocCUENTA_BENEFICIARIO).Width = 0
                .Column(Me.iGyDocCODIGO_BANCO_DESTINO_NACIONAL).Width = 0
                .Column(Me.iGyDocES_BANCO_EXTRANJERO).Width = 0

                .Cell(0, Me.iGyDocID_BANCOS_DETALLE).Text = ""
                .Cell(0, Me.iGyDocCODIGO_FORMA_PAGO).Text = "Forma pago"
                .Cell(0, Me.iGyDocNOMBRE_FORMA_PAGO).Text = "Nombre"
                .Cell(0, Me.iGyDocFOLIO_DETALLE).Text = "Folio pago"
                .Cell(0, Me.iGyDocCODIGO_BANCO_EMISOR_NACIONAL).Text = "Banco origen"
                .Cell(0, Me.iGyDocNOMBRE_BANCO_EMISOR_NACIONAL).Text = "Nombre"
                .Cell(0, Me.iGyDocCUENTA_EMISOR).Text = "Cuenta emisor"
                .Cell(0, Me.iGyDocFECHA).Text = "Fecha"
                .Cell(0, Me.iGyDocRFC_EMISOR).Text = "RFC emisor"
                .Cell(0, Me.iGyDocMONTO).Text = "Monto"
                .Cell(0, Me.iGyDocCODIGO_MONEDA_SAT).Text = "Moneda"
                .Cell(0, Me.iGyDocCUENTA_BENEFICIARIO).Text = "Cuenta beneficiario"
                .Cell(0, Me.iGyDocCODIGO_BANCO_DESTINO_NACIONAL).Text = "Banco destino"
                .Cell(0, Me.iGyDocES_BANCO_EXTRANJERO).Text = "EsBancoExtranjero"

                .Column(Me.iGyDocFECHA).CellType = FlexCell.CellTypeEnum.DateTime
                .Column(Me.iGyDocFECHA).FormatString = "dd-MMM-yy"

                .Column(Me.iGyDocMONTO).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
                .Column(Me.iGyDocMONTO).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyDocMONTO).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
                .Column(Me.iGyDocMONTO).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Locked = True
                .Refresh()
            End With
        Catch ex As Exception
            HandleError(Me.Name, "FormateaGridDocumentosPago", ex)
        End Try
    End Sub

    Private Sub DespliegaCombosGrid()
        Try
            Dim dTabla As New DataTable("detalle"), da As SqlDataAdapter
            Dim sSQL As String = ("SELECT ID_MEDIO_PAGO,NOMBRE_MEDIO_PAGO FROM SIS_MEDIOS_PAGO ORDER BY NOMBRE_MEDIO_PAGO")

            da = New SqlDataAdapter(sSQL, Empresa_Sistema.conexion)
            da.Fill(dTabla)
            da.Dispose()

            Me.GridVentas.Column(Me.iGyVentaMedioPago).CellType = FlexCell.CellTypeEnum.ComboBox
            Me.GridVentas.ComboBox(Me.iGyVentaMedioPago).DataSource = dTabla
            Me.GridVentas.ComboBox(Me.iGyVentaMedioPago).DisplayMember = "NOMBRE_MEDIO_PAGO"
            Me.GridVentas.ComboBox(Me.iGyVentaMedioPago).ValueMember = "ID_MEDIO_PAGO"

            Dim dTabla1 As New DataTable("detalle1"), da1 As SqlDataAdapter
            Dim sSQL1 As String = ("SELECT CODIGO_BANCO,NOMBRE_BANCO FROM CAT_BANCOS ORDER BY NOMBRE_BANCO")

            da1 = New SqlDataAdapter(sSQL1, Empresa_Sistema.conexion)
            da1.Fill(dTabla1)
            da1.Dispose()

            Me.GridVentas.Column(Me.iGyVentaBanco).CellType = FlexCell.CellTypeEnum.ComboBox
            Me.GridVentas.ComboBox(Me.iGyVentaBanco).DataSource = dTabla1
            Me.GridVentas.ComboBox(Me.iGyVentaBanco).DisplayMember = "NOMBRE_BANCO"
            Me.GridVentas.ComboBox(Me.iGyVentaBanco).ValueMember = "CODIGO_BANCO"

        Catch ex As Exception
            HandleError(Me.Name, "DespliegaCombosGrid", ex)
        End Try

    End Sub

    Private Function AgregarDocumentosClientes() As Boolean
        Const sProcedure As String = "AgregarDocumentosClientes"
        Dim bResultado As Boolean = False
        Dim sql As Class_find, iRow As Integer
        Try
            If Me.TxtCodigoCliente.TextLength = 0 Then
                MsgBox("Asígne el código del cliente.", MsgBoxStyle.Exclamation, Me.Text)
                Me.TxtCodigoCliente.Focus()
                Return False
            Else
                sql = New Class_find("SELECT NOMBRE_CLIENTE,CUENTA_CONTABLE FROM CAT_CLIENTES WHERE CODIGO_CLIENTE='" & sReplace(Me.TxtCodigoCliente.Text) & "' AND ESTATUS='A'") 'AND CODIGO_ZONA=" & Usuario.Codigo_Plaza)
                If sql.Result1 = "" Then
                    MsgBox("El código de cliente que intenta buscar no existe o esta dado de Baja, favor de intentar con otro código.", MsgBoxStyle.Exclamation, sProcedure)
                    Me.LblCliente.Text = ""
                    Me.TxtCodigoCliente.Focus()
                    Return False
                End If
            End If

            If Me.CboMedioDePago.SelectedIndex = -1 Then
                MsgBox("Seleccione favor de un medio de pago.", MsgBoxStyle.Exclamation, sProcedure)
                Me.CboMedioDePago.Focus()
                Return False
            End If

            'If Me.chkAnticipo.Checked = True Then

            'Me.CargaAnticipo()

            'Me.GridVentas.Refresh()
            'Me.GridVentas.Locked = True
            'FALTA: Checar que columnas bloquear que no deberán cambiar en modo anticipo

            'Se va intentar mejor si cargar la ventas y lo que no apliquen preguntar si lo quieren como anticipo.

            'Else
            Me.BorraDocumentosSinPago()

            For iRow = 1 To Me.GridVentas.Rows - 1
                If Me.GridVentas.Cell(iRow, Me.iGyVentaCodigoCliente).Text.Length > 0 AndAlso Me.TxtCodigoCliente.Text = Me.GridVentas.Cell(iRow, Me.iGyVentaCodigoCliente).Text Then
                    If MsgBox("Ya asignó al cliente " & Me.TxtCodigoCliente.Text & " a la lista de pagos, esta seguro de volver agregarlo?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, sProcedure) = MsgBoxResult.No Then
                        Return False
                    Else
                        Exit For
                    End If
                End If
            Next

            'Agregar al grid folios de ventas, que no hayan sido agregados, y en caso de que ya , en msg mostrarlo.
            bResultado = Me.CargaFacturas()

            Me.GridVentas.Locked = False

            'End If

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    'FALTA: borrar este proceso que no se y Y CargaAnticipo
    'Private Sub AgregarAnticipoClientes()
    '    Dim sql As Class_find, iRow As Integer

    '    If Me.TxtCodigoCliente.TextLength = 0 Then
    '        MsgBox("Asígne el código del cliente.", MsgBoxStyle.Exclamation, Me.Text)
    '        Me.TxtCodigoCliente.Focus()
    '        Exit Sub
    '    Else
    '        sql = New Class_find("SELECT NOMBRE_CLIENTE,CUENTA_CONTABLE FROM CAT_CLIENTES WHERE CODIGO_CLIENTE='" & sReplace(Me.TxtCodigoCliente.Text) & "' AND ESTATUS='A' AND PLAZA=" & Usuario.Codigo_Plaza)
    '        If sql.Result1 = "" Then
    '            MsgBox("El código de cliente que intenta buscar no existe o esta dado de baja, favor de intentar con otro código.", MsgBoxStyle.Critical, "Validación de Clientes")
    '            Me.LblCliente.Text = ""
    '            Me.TxtCodigoCliente.Focus()
    '            Exit Sub
    '        End If
    '    End If

    '    If Me.CboMedioDePago.SelectedIndex = -1 Then
    '        MsgBox("Seleccione favor de un medio de pago.", MsgBoxStyle.Exclamation, "Validación de Medios de Pago")
    '        Me.CboMedioDePago.Focus()
    '        Exit Sub
    '    End If

    '    If Me.CboBancos.SelectedIndex = -1 Then
    '        MsgBox("Seleccione de favor un banco.", MsgBoxStyle.Exclamation, "Validación de bancos")
    '        Me.CboBancos.Focus()
    '        Exit Sub
    '    End If

    '    Me.BorraDocumentosSinPago()

    '    For iRow = 1 To Me.GridVentas.Rows - 1
    '        If Me.GridVentas.Cell(iRow, Me.iGyVentaCodigoCliente).Text.Length > 0 Then
    '            If Me.TxtCodigoCliente.Text = Me.GridVentas.Cell(iRow, Me.iGyVentaCodigoCliente).Text Then
    '                If MsgBox("Ya asignó al cliente " & Me.TxtCodigoCliente.Text & " a la lista de pagos, esta seguro de volver agregarlo?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then
    '                    Exit Sub
    '                Else
    '                    Exit For
    '                End If
    '            End If
    '        End If
    '    Next

    '    Me.CargaAnticipo()

    'End Sub

    Private Function CargaFacturas() As Boolean
        Const sProcedure As String = "CargaFacturas"
        Dim bResultado As Boolean = False

        Dim Conexion As New SqlConnection(Empresa_Sistema.conexion)
        Dim i As Integer = 1, oCliente As New Class_CatClientes, sMedioPago As String, oBanco As Class_CatBancos, sSaldoDlls As String = "", dFechaPagoDefault As Date
        Dim sql As Class_find, dTipoCambio As Decimal = valorNumericoD(Me.txtTipoCambio.Text)
        Dim cmd As SqlCommand, dReader As SqlDataReader, bHayVentasEnUSD As Boolean = False
        Dim sSQL As String = ""

        dFechaPagoDefault = CDate(Me.GridDocumentosPago.Cell(1, Me.iGyDocFECHA).Text)

        If dTipoCambio <= 0 Then
            dTipoCambio = 1
        End If

        Try
            Conexion.Open()

            oCliente = New Class_CatClientes(sReplace(Me.TxtCodigoCliente.Text))

            If oCliente.Existe = False Then
                Return False
            End If

            If Me.cboMoneda.Text = "MXN" Then
                'Si el pago es en MXN y hay facturas en USD, se necesita el tipo de cambio(aunque la cuenta bancaria este en MXN)

                'sSQL = "SELECT TOP 1 '1' HAY_VENTAS_EN_USD " &
                '                     "FROM VENTA_GLOBAL V WHERE V.CODIGO_CLIENTE='" & sReplace(Me.TxtCodigoCliente.Text) & "' AND SALDO>0 " & sSaldoDlls & " AND CODIGO_MONEDA_SAT='USD'"

                sSQL = "SELECT TOP 1 '1' HAY_VENTAS_EN_USD " &
                            "FROM VENTA_GLOBAL V " &
                            "LEFT JOIN VW_SIS_CAT_DOCUMENTOS_EXTENDIDO DOC ON(V.CODIGO_DOCUMENTO=DOC.CODIGO_DOCUMENTO) " &
                            "WHERE 1=1 "

                Select Case Me.cboTipoVentas.Text
                    Case "MISMO RFC CLIENTE"
                        sSQL = sSQL & " AND V.RFC_RECEPTOR='" & oCliente.RFC & "' "
                    Case "MISMO CODIGO CLIENTE"
                        sSQL = sSQL & " AND V.CODIGO_CLIENTE='" & sReplace(Me.TxtCodigoCliente.Text) & "' "
                End Select

                sSQL = sSQL & " AND V.SALDO>0 AND V.CODIGO_MONEDA_SAT='USD' " ' & " AND V.CODIGO_PLAZA=" & Plaza.CODIGO_PLAZA

                If Me.chkVentasNoFiscales.Checked = True Then
                    sSQL = sSQL & " AND DOC.AFECTA_CONTABILIDAD='0' " 'Para mostrar sólo remisiones, las cot no salen porque también se busca saldo>0 .
                Else
                    sSQL = sSQL & " AND DOC.CODIGO_DOCUMENTO LIKE 'F%' "
                End If

                cmd = New SqlCommand(sSQL, Conexion)

                With cmd
                    .CommandTimeout = 0
                    .CommandType = CommandType.Text
                    dReader = .ExecuteReader()
                    If dReader.HasRows = True Then
                        bHayVentasEnUSD = True
                    End If
                End With

                If bHayVentasEnUSD = True Then
                    dTipoCambio = CDec(valorNumericoD(InputBox("Capture aquí el tipo de cambio del pago (es un pago en MXN y hay facturas en USD)")))

                    If dTipoCambio <= 0 Or dTipoCambio > 30 Then
                        MsgBox("Tipo de cambio incorrecto.", MsgBoxStyle.Exclamation, sProcedure)
                        Return False
                    End If

                    Me.txtTipoCambio.Text = FormatTipoCambio(dTipoCambio)

                    Me.GridVentas.Column(Me.iGyVentaDiferencia).Visible = True
                    Me.GridVentas.Column(Me.iGyVentaPagoPesos).Visible = True

                End If

                dReader.Close()
            End If
        Catch ex As Exception
            HandleError(Me.Text, "CargaFacturas", ex)
        End Try


        'If Me.cboMoneda.Text = "USD" Then
        'sSaldoDlls = " AND SALDO_DOLARES>0 "
        'End If

        Dim sSQLSaldoMXN As String = ""

        If bHayVentasEnUSD = True Then
            sSQLSaldoMXN = "CASE WHEN CODIGO_MONEDA_SAT='USD' THEN ROUND((ROUND(V.SALDO/V.TIPO_DE_CAMBIO,2))*" & dTipoCambio.ToString & ",2) ELSE V.SALDO END SALDO_MXN,"
        Else
            sSQLSaldoMXN = "V.SALDO SALDO_MXN,"
        End If

        sSQL = "SELECT V.CODIGO_CLIENTE,CTE.NOMBRE_CLIENTE,V.FECHA,V.FOLIO_VENTA,V.CODIGO_MONEDA_SAT,V.TOTAL," &
                            sSQLSaldoMXN &
                            "V.TOTAL_DOLARES," &
                            "CASE WHEN V.CODIGO_MONEDA_SAT='USD' THEN ROUND(V.SALDO/V.TIPO_DE_CAMBIO,2) ELSE ROUND(V.SALDO/" & dTipoCambio.ToString & ",2) END SALDO_DOLARES," &
                            "CASE WHEN V.TOTAL=V.SALDO THEN V.IMPUESTO ELSE 0 END IVA, " &
                            "V.VERSION_ESQUEMA_XML,V.CODIGO_METODO_PAGO,V.CODIGO_METODO_PAGO_EVENTO,V.ES_FACTURA_ELECTRONICA " &
                            "FROM VENTA_GLOBAL V " &
                            "INNER JOIN CAT_CLIENTES CTE ON(V.CODIGO_CLIENTE=CTE.CODIGO_CLIENTE)" &
                            "LEFT JOIN VW_SIS_CAT_DOCUMENTOS_EXTENDIDO DOC ON(V.CODIGO_DOCUMENTO=DOC.CODIGO_DOCUMENTO) " &
                            "WHERE 1=1 "
        '"WHERE V.RFC_RECEPTOR='" & oCliente.RFC & "' AND V.SALDO>0 " & sSaldoDlls ' & " AND V.CODIGO_PLAZA=" & Plaza.CODIGO_PLAZA
        '"WHERE V.CODIGO_CLIENTE='" & sReplace(Me.TxtCodigoCliente.Text) & "' AND V.SALDO>0 " & sSaldoDlls ' & " AND V.CODIGO_PLAZA=" & Plaza.CODIGO_PLAZA

        Select Case Me.cboTipoVentas.Text
            Case "MISMO RFC CLIENTE"
                sSQL = sSQL & " AND V.RFC_RECEPTOR='" & oCliente.RFC & "' "
            Case "MISMO CODIGO CLIENTE"
                sSQL = sSQL & " AND V.CODIGO_CLIENTE='" & sReplace(Me.TxtCodigoCliente.Text) & "' "
        End Select

        sSQL = sSQL & " AND V.SALDO>0 " & sSaldoDlls ' & " AND V.CODIGO_PLAZA=" & Plaza.CODIGO_PLAZA

        If Me.chkVentasNoFiscales.Checked = True Then
            sSQL = sSQL & " AND DOC.AFECTA_CONTABILIDAD='0' " 'Para mostrar sólo remisiones, las cot no salen porque también se busca saldo>0 .
        Else
            sSQL = sSQL & " AND DOC.CODIGO_DOCUMENTO LIKE 'F%' "
        End If

        sSQL = sSQL & " ORDER BY V.FECHA"

        cmd = New SqlCommand(sSQL, Conexion)

        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try


                sql = New Class_find("SELECT NOMBRE_MEDIO_PAGO FROM SIS_MEDIOS_PAGO WHERE ID_MEDIO_PAGO=" & sReplace(Me.CboMedioDePago.SelectedValue.ToString) & " AND ESTATUS='A'")
                sMedioPago = sql.Result1

                If Me.cboFormaPago.SelectedValue.ToString = "02" Or Me.cboFormaPago.SelectedValue.ToString = "03" Then '02=CHEQUE NOMINATIVO, 03=TRANSFERENCIA ELECTRONICA DE FONDOS
                    If Me.CboBancos.SelectedIndex <> -1 Then
                        oBanco = New Class_CatBancos(Me.CboBancos.SelectedValue.ToString)
                    Else
                        oBanco = New Class_CatBancos("NA")
                    End If
                Else
                    oBanco = New Class_CatBancos("NA")
                End If

                dReader = .ExecuteReader()

                Me.GridVentas.AutoRedraw = False

                Me.InicializaGridVentas()
                i = Me.GridVentas.Rows - 1

                'Prepara un "posible" anticipo porque estos datos se pierden al darle al botón agregar, y si el cliente no tiene ventas con saldo no cargaria el grid y luego no se sabria de que cliente es el anticipo.
                If Me.chkVentasNoFiscales.Checked = True Then
                    'Evita cargar algunas columnas innesarias

                    Me.GridVentas.Cell(i, Me.iGyVentaFOLIO_DETALLE).Text = Me.txtFolioDetalle.Text.ToUpper
                    Me.GridVentas.Cell(i, Me.iGyVentaCodigoCliente).Text = oCliente.CODIGO_CLIENTE
                    Me.GridVentas.Cell(i, Me.iGyVentaNombreCliente).Text = oCliente.NOMBRE_CLIENTE
                    'Me.GridVentas.Cell(i, Me.iGyVentaFecha).Text = "?"
                    Me.GridVentas.Cell(i, Me.iGyVentaFolio).Text = "" 'No se indica ningún folio
                    'Me.GridVentas.Cell(i, Me.iGyVentaMoneda).Text ="?"
                    Me.GridVentas.Cell(i, Me.iGyVentaMedioPago).Text = Me.CboMedioDePago.Text
                    Me.GridVentas.Cell(i, Me.iGyVentaBanco).Text = oBanco.NOMBRE_BANCO  ' Me.CboBancos.Text
                    'Me.GridVentas.Cell(i, Me.iGyVentaTotal).Text = "?"
                    'Me.GridVentas.Cell(i, Me.iGyVentaSaldo).Text = "?"
                    'Me.GridVentas.Cell(i, Me.iGyVentaTotalDlls).Text = "?"
                    'Me.GridVentas.Cell(i, Me.iGyVentaSaldoDlls).Text = "?"
                    Me.GridVentas.Cell(i, Me.iGyVentaPago).Text = "0" 'No se sabe de momento cuanto va ser de anticipo hasta grabar y sacar la suma de lo no aplicado
                    Me.GridVentas.Cell(i, Me.iGyVentaPagoPesos).Text = "0"
                    Me.GridVentas.Cell(i, Me.iGyVentaDiferencia).Text = CStr(0)
                    Me.GridVentas.Cell(i, Me.iGyVentaSeleccion).Text = "0"
                    Me.GridVentas.Cell(i, Me.iGyVentaReferencia).Text = Me.TxtReferencia.Text
                    Me.GridVentas.Cell(i, Me.iGyVentaIvaPorPagar).Text = CStr(0)

                    Me.GridVentas.Cell(i, Me.iGyVentaFechaPago).Text = FormatFechaCorta(dFechaPagoDefault)  'CType(dFechaPagoDefault, String)
                    'Me.GridVentas.Cell(i, Me.iGyVentaVersionCFDI).Text = "?"
                    'Me.GridVentas.Cell(i, Me.iGyVentaFormaPago).Text = "?"
                    'Me.GridVentas.Cell(i, Me.iGyVentaMetodoPago).Text = "?"
                    Me.GridVentas.Cell(i, Me.iGyVentaImporteMonedaVenta).Text = "0"
                    Me.GridVentas.Cell(i, Me.iGyVentaSaldoAnteriorMonedaVenta).Text = "0"
                    Me.GridVentas.Cell(i, Me.iGyVentaSaldoAnteriorMonedaPago).Text = "0"
                    Me.GridVentas.Cell(i, Me.iGyVentaEsFacturaElectronica).Text = "0"

                    Me.GridVentas.Row(i).Locked = True 'No podrán editar este renglón, y además recuerde
                    Me.GridVentas.Row(i).Visible = False 'No se muestra al usuario cuando se esta haciendo el anticipo, no debe usarse para grabar un pago normal, sólo si hay anticipo

                    Me.GridVentas.Rows += 1
                    i = i + 1
                End If

                If dReader.HasRows = True Then

                    'Esto se usaria si es que se van a permitir agregar venta de otro cliente , de momento no es posible, el agregar sólo funciona una vez y deberian dar nuevo si queiren otras ventas.
                    'If Me.GridVentas.Cell(i, Me.iGyVentaCodigoCliente).Text.Length > 0 Then
                    '    Me.GridVentas.Rows += 1
                    '    i = i + 1
                    'End If

                    'Aquí carga ventas con saldo
                    While dReader.Read()

                        If ExisteYaDocumentoVenta(dReader("FOLIO_VENTA").ToString) = True Then
                            MsgBox("El folio de venta " & dReader("FOLIO_VENTA").ToString & " ya existe, no se volverá a agregar.", MsgBoxStyle.Exclamation, Me.Text)
                        Else
                            Me.GridVentas.Rows = Me.GridVentas.Rows + 1

                            Me.GridVentas.Cell(i, Me.iGyVentaFOLIO_DETALLE).Text = Me.txtFolioDetalle.Text.ToUpper
                            Me.GridVentas.Cell(i, Me.iGyVentaCodigoCliente).Text = dReader("CODIGO_CLIENTE").ToString 'oCliente.CODIGO_CLIENTE
                            Me.GridVentas.Cell(i, Me.iGyVentaNombreCliente).Text = dReader("NOMBRE_CLIENTE").ToString 'oCliente.NOMBRE_CLIENTE
                            Me.GridVentas.Cell(i, Me.iGyVentaFecha).Text = dReader("FECHA").ToString
                            Me.GridVentas.Cell(i, Me.iGyVentaFolio).Text = dReader("FOLIO_VENTA").ToString
                            Me.GridVentas.Cell(i, Me.iGyVentaMoneda).Text = dReader("CODIGO_MONEDA_SAT").ToString
                            Me.GridVentas.Cell(i, Me.iGyVentaMedioPago).Text = Me.CboMedioDePago.Text
                            Me.GridVentas.Cell(i, Me.iGyVentaBanco).Text = oBanco.NOMBRE_BANCO  ' Me.CboBancos.Text
                            Me.GridVentas.Cell(i, Me.iGyVentaTotal).Text = dReader("TOTAL").ToString
                            Me.GridVentas.Cell(i, Me.iGyVentaSaldo).Text = dReader("SALDO_MXN").ToString
                            Me.GridVentas.Cell(i, Me.iGyVentaTotalDlls).Text = dReader("TOTAL_DOLARES").ToString
                            Me.GridVentas.Cell(i, Me.iGyVentaSaldoDlls).Text = dReader("SALDO_DOLARES").ToString
                            Me.GridVentas.Cell(i, Me.iGyVentaPago).Text = CStr(0)
                            Me.GridVentas.Cell(i, Me.iGyVentaPagoPesos).Text = CStr(0)
                            Me.GridVentas.Cell(i, Me.iGyVentaDiferencia).Text = CStr(0)
                            Me.GridVentas.Cell(i, Me.iGyVentaSeleccion).Text = "0"
                            Me.GridVentas.Cell(i, Me.iGyVentaReferencia).Text = Me.TxtReferencia.Text
                            Me.GridVentas.Cell(i, Me.iGyVentaIvaPorPagar).Text = dReader("IVA").ToString

                            Me.GridVentas.Cell(i, Me.iGyVentaFechaPago).Text = FormatFechaCorta(dFechaPagoDefault)  'CType(dFechaPagoDefault, String)
                            Me.GridVentas.Cell(i, Me.iGyVentaVersionCFDI).Text = dReader("VERSION_ESQUEMA_XML").ToString
                            Me.GridVentas.Cell(i, Me.iGyVentaFormaPago).Text = dReader("CODIGO_METODO_PAGO").ToString
                            Me.GridVentas.Cell(i, Me.iGyVentaMetodoPago).Text = "" & dReader("CODIGO_METODO_PAGO_EVENTO").ToString
                            Me.GridVentas.Cell(i, Me.iGyVentaImporteMonedaVenta).Text = "0"
                            Me.GridVentas.Cell(i, Me.iGyVentaSaldoAnteriorMonedaVenta).Text = "0"
                            Me.GridVentas.Cell(i, Me.iGyVentaSaldoAnteriorMonedaPago).Text = "0"
                            Me.GridVentas.Cell(i, Me.iGyVentaEsFacturaElectronica).Text = dReader("ES_FACTURA_ELECTRONICA").ToString

                            i = i + 1
                        End If
                    End While

                    bResultado = True
                End If
                dReader.Close()

            Catch ex As Exception
                HandleError(Me.Text, sProcedure, ex)
            Finally
                Conexion.Close()
                cmd.Dispose()
                Me.GridVentas.AutoRedraw = True
                Me.GridVentas.Refresh()
            End Try
        End With

        Me.Totales()

        Return bResultado

    End Function

    'Private Sub CargaAnticipo()
    '    Dim Conexion As New SqlConnection(Empresa_Sistema.conexion)
    '    Dim i As Integer = 1, oCliente As Class_CatClientes, oBanco As Class_CatBancos

    '    Try
    '        Me.InicializaGridVentas()

    '        oCliente = New Class_CatClientes(sReplace(Me.TxtCodigoCliente.Text))

    '        i = Me.GridVentas.Rows - 1

    '        'Realmente este dato no se ocupa pero x estrucutura se registra, además que si es tarjeta bancaria si hay banco y sin embargo no no llega.
    '        If Me.cboFormaPago.SelectedValue.ToString = "02" Or Me.cboFormaPago.SelectedValue.ToString = "03" Then '02=CHEQUE NOMINATIVO, 03=TRANSFERENCIA ELECTRONICA DE FONDOS
    '            If Me.CboBancos.SelectedIndex <> -1 Then
    '                oBanco = New Class_CatBancos(Me.CboBancos.SelectedValue.ToString)
    '            Else
    '                oBanco = New Class_CatBancos("NA")
    '            End If
    '        Else
    '            oBanco = New Class_CatBancos("NA")
    '        End If

    '        Dim dFechaPagoDefault As Date = CDate(Me.GridDocumentosPago.Cell(1, Me.iGyDocFECHA).Text)

    '        Dim dPagoCapturado As Decimal = valorNumericoD(Me.txtMonto.Text)
    '        Dim dTipoCambioPago As Decimal = valorNumericoD(Me.txtTipoCambio.Text)
    '        Dim dPagoPesos As Decimal = 0

    '        If Me.cboMoneda.Text = "USD" Then
    '            dPagoPesos = RedondearD(CDec(dPagoCapturado * dTipoCambioPago), 2)
    '        Else
    '            dPagoPesos = dPagoCapturado
    '        End If

    '        'Me.GridVentas.Cell(i, Me.iGyCodigoCliente).Text = oCliente.CODIGO_CLIENTE
    '        'Me.GridVentas.Cell(i, Me.iGyNombreCliente).Text = oCliente.NOMBRE_CLIENTE.ToString
    '        'Me.GridVentas.Cell(i, Me.iGyFecha).Text = Me.dtFecha.Value.ToString
    '        'Me.GridVentas.Cell(i, Me.iGyFolio).Text = ""
    '        'Me.GridVentas.Cell(i, Me.iGyMedioPago).Text = Me.CboMedioDePago.Text
    '        'Me.GridVentas.Cell(i, Me.iGyBanco).Text = Me.CboBancos.Text
    '        'Me.GridVentas.Cell(i, Me.iGyTotal).Text = "0"
    '        'Me.GridVentas.Cell(i, Me.iGySaldo).Text = "0"
    '        'Me.GridVentas.Cell(i, Me.iGyTotalDlls).Text = "0"
    '        'Me.GridVentas.Cell(i, Me.iGySaldoDlls).Text = "0"
    '        'Me.GridVentas.Cell(i, Me.iGyPago).Text = Me.txtAnticipo.Text
    '        'Me.GridVentas.Cell(i, Me.iGyDiferencia).Text = "0"
    '        'Me.GridVentas.Cell(i, Me.iGySeleccion).Text = ""
    '        'Me.GridVentas.Cell(i, Me.iGyReferencia).Text = Me.TxtReferencia.Text
    '        'Me.GridVentas.Cell(i, Me.iGyIvaPorPagar).Text = "0"

    '        Me.GridVentas.Cell(i, Me.iGyVentaFOLIO_DETALLE).Text = Me.txtFolioDetalle.Text.ToUpper
    '        Me.GridVentas.Cell(i, Me.iGyVentaCodigoCliente).Text = oCliente.CODIGO_CLIENTE
    '        Me.GridVentas.Cell(i, Me.iGyVentaNombreCliente).Text = oCliente.NOMBRE_CLIENTE
    '        'Me.GridVentas.Cell(i, Me.iGyVentaFecha).Text = dReader("FECHA").ToString 
    '        'Me.GridVentas.Cell(i, Me.iGyVentaFolio).Text = dReader("FOLIO_VENTA").ToString 
    '        'Me.GridVentas.Cell(i, Me.iGyVentaMoneda).Text = dReader("CODIGO_MONEDA_SAT").ToString
    '        Me.GridVentas.Cell(i, Me.iGyVentaMedioPago).Text = Me.CboMedioDePago.Text
    '        Me.GridVentas.Cell(i, Me.iGyVentaBanco).Text = oBanco.NOMBRE_BANCO  ' Me.CboBancos.Text
    '        'Me.GridVentas.Cell(i, Me.iGyVentaTotal).Text = dReader("TOTAL").ToString
    '        'Me.GridVentas.Cell(i, Me.iGyVentaSaldo).Text = dReader("SALDO_MXN").ToString
    '        'Me.GridVentas.Cell(i, Me.iGyVentaTotalDlls).Text = dReader("TOTAL_DOLARES").ToString
    '        'Me.GridVentas.Cell(i, Me.iGyVentaSaldoDlls).Text = dReader("SALDO_DOLARES").ToString
    '        Me.GridVentas.Cell(i, Me.iGyVentaPago).Text = dPagoCapturado.ToString
    '        Me.GridVentas.Cell(i, Me.iGyVentaPagoPesos).Text = dPagoPesos.ToString
    '        Me.GridVentas.Cell(i, Me.iGyVentaDiferencia).Text = CStr(0)
    '        Me.GridVentas.Cell(i, Me.iGyVentaSeleccion).Text = "0"
    '        Me.GridVentas.Cell(i, Me.iGyVentaReferencia).Text = Me.TxtReferencia.Text
    '        'Me.GridVentas.Cell(i, Me.iGyVentaIvaPorPagar).Text = dReader("IVA").ToString

    '        Me.GridVentas.Cell(i, Me.iGyVentaFechaPago).Text = FormatFechaCorta(dFechaPagoDefault)  'CType(dFechaPagoDefault, String)
    '        'Me.GridVentas.Cell(i, Me.iGyVentaVersionCFDI).Text = dReader("VERSION_ESQUEMA_XML").ToString
    '        'Me.GridVentas.Cell(i, Me.iGyVentaFormaPago).Text = dReader("CODIGO_METODO_PAGO").ToString
    '        'Me.GridVentas.Cell(i, Me.iGyVentaMetodoPago).Text = "" & dReader("CODIGO_METODO_PAGO_EVENTO").ToString
    '        'Me.GridVentas.Cell(i, Me.iGyVentaImporteMonedaVenta).Text = "0"
    '        'Me.GridVentas.Cell(i, Me.iGyVentaSaldoAnteriorMonedaVenta).Text = "0"
    '        'Me.GridVentas.Cell(i, Me.iGyVentaSaldoAnteriorMonedaPago).Text = "0"
    '        'Me.GridVentas.Cell(i, Me.iGyVentaEsFacturaElectronica).Text = dReader("ES_FACTURA_ELECTRONICA").ToString


    '    Catch ex As Exception
    '        HandleError(Me.Text, "CargaAnticipo", ex)
    '    Finally
    '        Conexion.Close()
    '    End Try

    '    Totales()
    'End Sub

    Private Function ExisteYaDocumentoVenta(ByVal sFolioVenta As String) As Boolean
        Dim iRow As Integer
        For iRow = 1 To Me.GridVentas.Rows - 1
            If Me.GridVentas.Cell(iRow, Me.iGyVentaCodigoCliente).Text.Length > 0 Then
                If sFolioVenta = Me.GridVentas.Cell(iRow, Me.iGyVentaFolio).Text Then
                    ExisteYaDocumentoVenta = True
                    Exit Function
                End If
            End If
        Next iRow
    End Function

    Private Sub BorraDocumentosSinPago()
        Dim iRow As Integer = 1
        'Si solo ahy un renglon grid y esta en blanco no ahy nada que borrar
        If Me.GridVentas.Rows = 2 AndAlso Me.GridVentas.Cell(iRow, Me.iGyVentaCodigoCliente).Text.Length = 0 Then
            Exit Sub
        End If

        While iRow <= Me.GridVentas.Rows - 1
            If Me.GridVentas.Cell(iRow, Me.iGyVentaCodigoCliente).Text.Length > 0 AndAlso valorNumerico(Me.GridVentas.Cell(iRow, Me.iGyVentaPago).Text) = 0 Then
                Me.GridVentas.RemoveItem(iRow)
            Else
                iRow += 1
            End If
        End While

        Me.Totales()
        Application.DoEvents()
    End Sub

    Private Sub Totales()
        Try
            Me.TxtTotal.Text = FormatImporteContable(FG_Grid_SumaCol(Me.GridVentas, CShort(Me.iGyVentaPago)))

            'Me.CalculaImporteDolares()
            Me.TotalesLista()
        Catch ex As Exception
            HandleError(Me.Name, "Totales", ex)
        End Try

        'For I = 1 To Me.Grid1.Rows - 1
        '    If valorNumerico(Me.Grid1.Cell(I, 7).Text) > 0 Then
        '        Me.Grid1.Cell(I, 10).Text = valorNumerico(Me.Grid1.Cell(I, 7).Text) * (valorNumerico(Me.Grid1.Cell(I, 9).Text) / valorNumerico(Me.Grid1.Cell(I, 6).Text))
        '    End If
        'Next I

        'DIVA = FG_Grid_SumaCol(Me.Grid1, 10)
        'Me.TxtIVAAfecta.Text = FormatImporteContable(DIVA)
    End Sub

    Private Function GestionaGrabar() As Boolean
        Dim bResultado As Boolean = False
        Me.oPolizaGlobal = New Class_Contabilidad_Poliza_Global(Me.TxtFolio.Text)
        Try
            If MsgBox("Deseas grabar el documento " & Me.CboDocumento.Text & " con el folio : " & Me.TxtFolio.Text & "?", CType(vbYesNo + vbQuestion, MsgBoxStyle), "Grabar") = MsgBoxResult.No Then
                Return False
            End If

            Me.Totales()

            'Nota aqui dentro se reprocesa el saldo de las facturas para asegurarse tengan saldo antes de aplicar
            If Me.Validar() = False Then
                Return False
            End If

            If Me.chkVentasNoFiscales.Checked = False Then
                If Me.ValidaPrePoliza() = False Then
                    Return False
                End If

                If Me.Grabar() = True Then
                    'sobreescibir texbox folio y folio oringen de oFormaPoliza, aplicar la poliza, y actualizar folio_poliza en bancos global
                    Me.oFormaPoliza.TxtFolio.Text = Me.TxtFolio.Text
                    Me.oFormaPoliza.lblFolioOrigen.Text = Me.TxtFolio.Text
                    If Me.oFormaPoliza.Aplicar(False, False) = True Then
                        If Me.oBancosCXC.ActualizaFolioPoliza() = True Then
                            MsgBox("Movimiento grabado satisfactoriamente.", MsgBoxStyle.Information, Me.Text)
                        Else
                            MsgBox("Movimiento grabado sin relacionar el folio de la póliza.", MsgBoxStyle.Information, Me.Text)
                        End If
                        bResultado = True
                    Else
                        MsgBox("Movimiento grabado sin relacionar el folio de la póliza.", MsgBoxStyle.Information, Me.Text)
                    End If

                    If Me.oDocumento.TIMBRA_DOCUMENTO = True Then
                        If Me.oBancosCXC.GestionaCFDI() = True Then
                            Me.oBancosCXC.GeneraPagosElectronicos()
                        End If
                    End If
                End If

            Else 'No contabiliza, ni timbra
                bResultado = Me.Grabar()
                If bResultado = True Then
                    MsgBox("Movimiento grabado satisfactoriamente.", MsgBoxStyle.Information, Me.Text)
                End If
            End If

        Catch ex As Exception
            HandleError(Me.Name, "GestionaGrabar", ex)
        End Try

        Return bResultado

    End Function

    Private Function Grabar() As Boolean
        Const sProcedure As String = "Grabar"
        Dim bResultado As Boolean = False
        Dim i As Integer, dPago As Decimal, sFolioPago As String = ""
        Dim dTotalPago As Decimal = 0, dSumaPagos As Decimal = 0, dAnticipo As Decimal = 0

        Try
            dTotalPago = valorNumericoD(Me.GridDocumentosPago.Cell(1, Me.iGyDocMONTO).Text)

            For i = 1 To Me.GridVentas.Rows - 1
                dSumaPagos += valorNumericoD(Me.GridVentas.Cell(i, Me.iGyVentaPago).Text)
            Next

            If Me.chkVentasNoFiscales.Checked = True Then
                dAnticipo = dTotalPago - dSumaPagos

                If dAnticipo > 0 Then
                    'NOTA: se indica el renglón 1 y no la variable i fijo porque en ese renglón se documenta el anticipo

                    Me.GridVentas.Cell(1, Me.iGyVentaPago).Text = dAnticipo.ToString 'Para establecer el valor del anticipo como si fuera un pago
                    Me.GridVentas.Cell(1, Me.iGyVentaPagoPesos).Text = dAnticipo.ToString
                    If Me.cboMoneda.Text = "USD" Then
                        MsgBox("De momento no es compatible los anticipos en moneda USD.", vbExclamation, sProcedure)

                        'Me.GridVentas.Cell(1, Me.iGyVentaPago).Text = "QUE IRIA??"
                        'Me.GridVentas.Cell(1, Me.iGyVentaPagoPesos).Text = "QUE IRIA??"

                        Return False
                    End If

                    'Continua, generará un anticipo.
                End If
            End If

            Me.oBancosCXC = New Class_Bancos_CXC
            'If Me.oBancosCXC.Existe = True Then
            '    Exit Function
            'End If

            oBancosCXC.FOLIO_BANCO = Me.TxtFolio.Text
            oBancosCXC.ID_CUENTA_BANCARIA = CInt(Me.TxtCuentaBancaria.Text)
            oBancosCXC.TOTAL = valorNumerico(Me.TxtTotal.Text)
            oBancosCXC.CODIGO_DOCUMENTO = (Me.CboDocumento.SelectedValue.ToString)
            oBancosCXC.FECHA = Me.dtFecha.Value
            oBancosCXC.CONCEPTO1 = Me.TxtConcepto.Text.ToUpper
            oBancosCXC.CODIGO_PLAZA = Usuario.Codigo_Plaza
            If Me.cboMoneda.Text = "USD" Then
                oBancosCXC.TIPO_DE_CAMBIO = valorNumerico(Me.txtTipoCambio.Text)
                oBancosCXC.TOTAL_DOLARES = valorNumerico(Me.TxtTotal.Text)
                oBancosCXC.TOTAL = valorNumerico(Me.TxtTotal.Text) * valorNumerico(Me.txtTipoCambio.Text)
            Else
                oBancosCXC.TOTAL = valorNumerico(Me.TxtTotal.Text)
            End If
            oBancosCXC.CODIGO_MONEDA_SAT = Me.cboMoneda.Text

            If Me.GridDocumentosPago.Cell(1, Me.iGyDocCODIGO_FORMA_PAGO).Text = "02" Then '02=Cheque
                oBancosCXC.FECHA_CHEQUE = Me.dtFechaCheque.Value
            Else
                oBancosCXC.FECHA_CHEQUE = Me.dtFecha.Value 'Importa cuando es cheque, si es otro va grabar el que sea(no tiene importancia)
            End If

            oBancosCXC.ES_PAGO_VENTAS_NO_FISCALES = Me.chkVentasNoFiscales.Checked

            'Inserta en BANCOS_GLOBAL
            If oBancosCXC.Inserta_Global() = False Then '''''''''''''''''==========================Afectacion
                Return False
            End If

            Me.TxtFolio.Text = oBancosCXC.FOLIO_BANCO

            'Graba detalle de documentos de pago.
            Dim lID_BANCOS_DETALLE As Long
            With Me.GridDocumentosPago
                For i = 1 To .Rows - 1
                    sFolioPago = Me.GridDocumentosPago.Cell(i, Me.iGyDocFOLIO_DETALLE).Text.ToUpper

                    If txtLEN(sFolioPago) = True Then
                        'Inserta en BANCOS_DETALLE
                        lID_BANCOS_DETALLE = oBancosCXC.AgregaDocumentoPago(Me.TxtFolio.Text, .Cell(i, Me.iGyDocCODIGO_FORMA_PAGO).Text, .Cell(i, Me.iGyDocFOLIO_DETALLE).Text,
                                  .Cell(i, Me.iGyDocCODIGO_BANCO_EMISOR_NACIONAL).Text, .Cell(i, Me.iGyDocCUENTA_EMISOR).Text,
                                  CDate(.Cell(i, Me.iGyDocFECHA).Text), .Cell(i, Me.iGyDocRFC_EMISOR).Text, valorNumerico(.Cell(i, Me.iGyDocMONTO).Text),
                                 .Cell(i, Me.iGyDocCODIGO_MONEDA_SAT).Text, valorNumerico(txtTipoCambio.Text),
                                 .Cell(i, Me.iGyDocCUENTA_BENEFICIARIO).Text, .Cell(i, Me.iGyDocCODIGO_BANCO_DESTINO_NACIONAL).Text,
                                 IIf(.Cell(i, Me.iGyDocES_BANCO_EXTRANJERO).Text = "1", .Cell(i, Me.iGyDocNOMBRE_BANCO_EMISOR_NACIONAL).Text, "").ToString
                        ) 'El beneficiario es la empresa propia, el store lo llenará internamente

                        If lID_BANCOS_DETALLE = 0 Then
                            Return False
                        End If

                        .Cell(i, Me.iGyDocID_BANCOS_DETALLE).Text = lID_BANCOS_DETALLE.ToString
                    End If

                Next
            End With
            sFolioPago = ""

            'Graba pagos
            Me.oCxcAfectaDocumentos = New Class_CXC_Afecta_Documentos
            For i = 1 To Me.GridVentas.Rows - 1
                dPago = valorNumericoD(Me.GridVentas.Cell(i, Me.iGyVentaPago).Text)
                dSumaPagos += dPago
                If dPago > 0 Or (dAnticipo > 0 And i = 1) Then

                    oCxcAfectaDocumentos.FOLIO_CXC = "" 'Me.TxtFolio.Text
                    oCxcAfectaDocumentos.CODIGO_CLIENTE = Me.GridVentas.Cell(i, Me.iGyVentaCodigoCliente).Text
                    oCxcAfectaDocumentos.FECHA = Me.dtFecha.Value
                    oCxcAfectaDocumentos.FOLIO_REFERENCIA = Me.GridVentas.Cell(i, Me.iGyVentaFolio).Text 'folio de la compra
                    oCxcAfectaDocumentos.FOLIO_REFERENCIA_USUARIO = Me.GridVentas.Cell(i, Me.iGyVentaReferencia).Text 'Folio factura Cliente de la venta, no tenemos
                    oCxcAfectaDocumentos.CONCEPTO1 = Me.TxtConcepto.Text
                    oCxcAfectaDocumentos.CONCEPTO2 = ""
                    oCxcAfectaDocumentos.CODIGO_PLAZA = Usuario.Codigo_Plaza
                    If Me.cboMoneda.Text = "USD" Then
                        oCxcAfectaDocumentos.TOTAL_DOLARES = dPago

                        'If valorNumerico(Me.GridVentas.Cell(i, Me.iGyVentaTotalDlls).Text) <> valorNumerico(Me.GridVentas.Cell(i, Me.iGyVentaPago).Text) And valorNumerico(Me.GridVentas.Cell(i, Me.iGyVentaSaldoDlls).Text) <> valorNumerico(Me.GridVentas.Cell(i, Me.iGyVentaPago).Text) Then
                        '    'Si solo es un pago parcial el abono en pesos sera segun al tipo de cambio de la venta
                        '    Dim oVenta As New Class_Ventas_Global(Me.GridVentas.Cell(i, Me.iGyVentaFolio).Text)
                        '    oCxcAfectaDocumentos.TOTAL = valorNumerico(Me.GridVentas.Cell(i, Me.iGyVentaPago).Text) * oVenta.TIPO_DE_CAMBIO
                        'Else
                        '    oCxcAfectaDocumentos.TOTAL = valorNumerico(Me.GridVentas.Cell(i, Me.iGyVentaPagoPesos).Text) + valorNumerico(Me.GridVentas.Cell(i, Me.iGyVentaDiferencia).Text) 'dPago
                        'End If

                        '    oCxcAfectaDocumentos.TOTAL = valorNumerico(Me.GridVentas.Cell(i, Me.iGyVentaPagoPesos).Text)

                        'Else
                        '    oCxcAfectaDocumentos.TOTAL = dPago
                    Else 'MXN
                        If Me.GridVentas.Cell(i, Me.iGyVentaMoneda).Text = "USD" Then 'Si estan pagando en MXN una venta en USD, falta establecer el total_dolares para poder restarlo directamente en saldo_dolares de la misma
                            oCxcAfectaDocumentos.TOTAL_DOLARES = CDec(Me.GridVentas.Cell(i, Me.iGyVentaImporteMonedaVenta).Text)
                        End If
                    End If

                    oCxcAfectaDocumentos.TOTAL = valorNumerico(Me.GridVentas.Cell(i, Me.iGyVentaPagoPesos).Text)
                    oCxcAfectaDocumentos.IMPORTE_CAPTURADO = dPago

                    oCxcAfectaDocumentos.TIPO_DE_CAMBIO = valorNumerico(Me.txtTipoCambio.Text)
                    oCxcAfectaDocumentos.FOLIO_BANCO = Me.TxtFolio.Text 'Se tiene que poner el del texbox porque se regreso el folio al Inserta_Global
                    Dim sql As New Class_find("SELECT ID_MEDIO_PAGO FROM SIS_MEDIOS_PAGO WHERE NOMBRE_MEDIO_PAGO='" & Me.GridVentas.Cell(i, Me.iGyVentaMedioPago).Text & "'")
                    If txtLEN(sql.Result1) = True Then
                        oCxcAfectaDocumentos.ID_MEDIO_PAGO = CInt(sql.Result1)
                    End If
                    sql = New Class_find("SELECT CODIGO_BANCO FROM CAT_BANCOS WHERE NOMBRE_BANCO='" & Me.GridVentas.Cell(i, Me.iGyVentaBanco).Text & "'")
                    If txtLEN(sql.Result1) = True Then
                        oCxcAfectaDocumentos.CODIGO_BANCO = sql.Result1
                    End If

                    sFolioPago = Me.GridVentas.Cell(i, Me.iGyVentaFOLIO_DETALLE).Text.ToUpper
                    oCxcAfectaDocumentos.ID_BANCOS_DETALLE = ObtieneIDBancosDetalle(sFolioPago)

                    oCxcAfectaDocumentos.FECHA_PAGO = CDate(Me.GridVentas.Cell(i, Me.iGyVentaFechaPago).Text)
                    oCxcAfectaDocumentos.IMPORTE_MONEDA_VENTA = CDec(Me.GridVentas.Cell(i, Me.iGyVentaImporteMonedaVenta).Text)
                    oCxcAfectaDocumentos.SALDO_ANTERIOR_MONEDA_VENTA = CDec(Me.GridVentas.Cell(i, Me.iGyVentaSaldoAnteriorMonedaVenta).Text)
                    oCxcAfectaDocumentos.SALDO_ANTERIOR_MONEDA_PAGO = CDec(Me.GridVentas.Cell(i, Me.iGyVentaSaldoAnteriorMonedaPago).Text)

                    bResultado = oCxcAfectaDocumentos.InsertarPagosClientes() '''''''''''''''''==========================Afectacion
                End If
            Next i

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        Finally
            'Me.oBancosCXC = Nothing no hay porque borrarla
            Me.oCxcAfectaDocumentos = Nothing
        End Try

        Return bResultado
    End Function

    Private Function Validar() As Boolean
        Const sProcedure As String = "Validar"
        Dim bResultado As Boolean = False
        Try
            Dim i As Integer, dTipoCambio As Decimal = valorNumericoD(Me.txtTipoCambio.Text)

            If Plaza.ValidarPeriodoTrabajo(Me.dtFecha.Value) = False Then
                Return False
            End If

            If Usuario.ValidaPermisoUsuarioDocumentoSinAfectacionInventarios(Me.CboDocumento.SelectedValue.ToString) = False Then
                MsgBox("El usuario " & Usuario.Nombre_Usuario & " no tiene permiso para realizar el movimiento.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            If Me.cboMoneda.Text = "USD" Then
                If dTipoCambio <= 0 Or dTipoCambio > 30 Then
                    MsgBox("Tipo de cambio incorrecto.", MsgBoxStyle.Exclamation, sProcedure)
                    Me.txtTipoCambio.Focus()
                    Return False
                End If
            End If

            If txtLEN(Me.TxtCuentaBancaria.Text) = False Then
                MsgBox("Asíge la cuenta bancaria que recibe los fondos.", MsgBoxStyle.Exclamation, sProcedure)
                If Me.TxtCuentaBancaria.Enabled = True Then Me.TxtCuentaBancaria.Focus()
                Return False
            End If

            Dim oCuentaBancaria As New Class_CatCuentasBancarias(CInt(Me.TxtCuentaBancaria.Text))

            If oCuentaBancaria.Existe = False Then
                MsgBox("La cuenta bancaria no existe.", MsgBoxStyle.Exclamation, sProcedure)
                If Me.TxtCuentaBancaria.Enabled = True Then Me.TxtCuentaBancaria.Focus()
                Return False
            End If

            'If Len(oCuentaBancaria.NUMERO_CUENTA_BANCARIA) < 10 Then
            '    MsgBox("La cuenta bancaria que recibe los fondos debe de tener 10 dígitos mínimamente en el número de cuenta.", MsgBoxStyle.Exclamation, sProcedure)
            '    Return False
            'End If

            If Len(oCuentaBancaria.CLABE_INTERBANCARIA) <> 18 Then
                MsgBox("La cuenta bancaria que recibe los fondos debe de tener 18 dígitos en la clabe interbancaria.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            If Me.cboMoneda.Text = "USD" Then
                If txtLEN(oCuentaBancaria.CUENTA_CONTABLE_DOLARES.ToString) = False Then
                    MsgBox("La cuenta bancaria que intenta debe tener cuenta contable en dólares.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If
            End If

            'Se eliminó con el cambio de la contabilidad electronica, 24dic12
            'Dim sql As Class_find
            'Dim sql As New Class_find("SELECT 1 FROM CAT_CLIENTES WHERE CODIGO_CLIENTE='" & Me.TxtCodigoCliente.Text & "' AND ESTATUS='A' AND CODIGO_ZONA=" & Usuario.Codigo_Plaza)
            'If sql.Result1 = "" Then
            '    MsgBox("El código de Cliente que intenta buscar no existe o esta dado de baja, favor de intentar con otro código.", MsgBoxStyle.Exclamation, "Validación de Clientees")
            '    Me.LblCliente.Text = ""
            '    Me.TxtCodigoCliente.Focus()
            '    return false
            'Else
            '    Me.LblCliente.Text = sql.Result1
            'End If

            If valorNumerico(Me.TxtTotal.Text) <= 0 AndAlso Me.chkVentasNoFiscales.Checked = False Then
                MsgBox("No asignó los documentos a pagar. El total a pagar debe ser mayor que cero.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            For i = 1 To GridVentas.Rows - 1
                If Me.cboMoneda.Text = "USD" Then
                    If valorNumerico(Me.GridVentas.Cell(i, Me.iGyVentaPago).Text) > 0 And txtLEN(Me.GridVentas.Cell(i, Me.iGyVentaFolio).Text) = True Then

                        CalculaImportesPagoUSD(i)

                        'sql = New Class_find("SELECT CASE WHEN CODIGO_MONEDA_SAT='USD' THEN ROUND(SALDO/TIPO_DE_CAMBIO,2) ELSE ROUND(SALDO/" & dTipoCambio.ToString & ",2) END SALDO_DOLARES FROM VENTA_GLOBAL " &
                        '                     "WHERE FOLIO_VENTA='" & Me.GridVentas.Cell(i, Me.iGyVentaFolio).Text & "'")
                        'Me.GridVentas.Cell(i, Me.iGyVentaSaldoDlls).Text = sql.Result1

                        If valorNumerico(Me.GridVentas.Cell(i, Me.iGyVentaPago).Text) > valorNumerico(Me.GridVentas.Cell(i, Me.iGyVentaSaldoDlls).Text) Then
                            MsgBox("El pago en el renglón: " & i & " es mayor al saldo del documento favor de revisar.", MsgBoxStyle.Exclamation, sProcedure)
                            Return False
                        End If
                    End If

                Else 'MXN
                    If valorNumerico(Me.GridVentas.Cell(i, Me.iGyVentaPago).Text) > 0 And txtLEN(Me.GridVentas.Cell(i, Me.iGyVentaFolio).Text) = True Then
                        'sql = New Class_find("SELECT SALDO FROM VENTA_GLOBAL WHERE FOLIO_VENTA='" & Me.GridVentas.Cell(i, Me.iGyVentaFolio).Text & "'")
                        'Me.GridVentas.Cell(i, Me.iGyVentaSaldo).Text = sql.Result1

                        CalculaImportesPagoMXN(i)

                        If valorNumerico(Me.GridVentas.Cell(i, Me.iGyVentaPago).Text) > valorNumerico(Me.GridVentas.Cell(i, Me.iGyVentaSaldo).Text) Then
                            MsgBox("El pago en el renglón: " & i & " es mayor al saldo del documento favor de revisar.", MsgBoxStyle.Exclamation, sProcedure)
                            Return False
                        End If
                    End If
                End If
            Next i

            If Me.cboMoneda.Text = "USD" Then
                Me.CalculaImporteDolares()
            End If

            If Me.ValidaVentasTenganDocumentoPago = False Then
                Return False
            End If

            If Me.ValidaSumasDocumentoPagos = False Then
                Return False
            End If

            If Me.oDocumento.TIMBRA_DOCUMENTO = True Then
                If Me.chkVentasNoFiscales.Checked = False Then
                    If Me.ValidaVentasTimbradas = False Then
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

    Private Sub ImprimirPoliza()
        Dim StrFiltros As String = ""
        Dim FormatoDeReporte As String
        Dim Rpt As New ReportDocument
        Dim oReporte As Class_Reporte
        Try
            FormatoDeReporte = "RPT_FORMATO_CONTABILIDAD_POLIZA"
            oReporte = New Class_Reporte(FormatoDeReporte, Rpt, False)
            If Not oReporte.RptCargado Then
                Exit Sub
            End If
            Rpt.SetParameterValue("@FOLIO_POLIZA", Me.TxtFolio.Text)
            Dim frm As New Reporte(Rpt)
            frm.CRViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            frm.Show()
        Catch ex As Exception
            HandleError(Me.Name, "ImprimirPoliza", ex)
        Finally
            oReporte = Nothing
        End Try
    End Sub

    Private Sub GestionaCambioEstado()
        Select Case Me.LblStatus.Text
            Case "APLICADO"
                Me.Cambia_Estado(enumEstados.APLICADO)
            Case "CANCELADO"
                Me.Cambia_Estado(enumEstados.CANCELADO)
        End Select
    End Sub

    Private Sub DesplegarDocumentos()
        Try
            Dim oElementos As New Class_CatDocumentos
            With Me.CboDocumento
                .DisplayMember = "NOMBRE_TIPO_DOCUMENTO"
                .ValueMember = "CODIGO_DOCUMENTO"
                Dim dView As New Data.DataView(oElementos.ObtenerCodigosDocumentos("BAN", Usuario.Codigo_Plaza.ToString, " ESTATUS_DOCUMENTO='A' AND AFECTA_CXC='1' AND AFECTA_CONTABILIDAD='1'"))
                dView.Sort = "NOMBRE_TIPO_DOCUMENTO"
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

    Private Sub DesplegarMedioDePagos()
        Try
            Dim oElementos As New Class_CatMedioPago
            With Me.CboMedioDePago
                .DisplayMember = "NOMBRE_MEDIO_PAGO"
                .ValueMember = "ID_MEDIO_PAGO"
                Dim dView As New Data.DataView(oElementos.ObtenerElementos())
                'dView.Sort = "NOMBRE_MEDIO_PAGO"
                .DataSource = dView
                If dView.Count > 0 Then
                    '.SelectedIndex = -1
                    .SelectedValue = 0
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarMedioDePagos", ex)
        End Try
    End Sub

    Private Sub DesplegarMetodosPago()
        Try
            Dim oElementos As New Class_CFD_CatFormasPago
            With Me.cboFormaPago
                .DisplayMember = "NOMBRE_METODO_PAGO"
                .ValueMember = "CODIGO_METODO_PAGO"
                Dim dView As New Data.DataView(oElementos.ObtenerElementos())
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedIndex = -1
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Text, "DesplegarMetodosPago", ex)
        End Try
    End Sub

    Private Sub DesplegarBancos()
        Try
            Dim oElementos As New Class_CatBancos
            With Me.CboBancos
                .DisplayMember = "NOMBRE_BANCO"
                .ValueMember = "CODIGO_BANCO"
                Dim dView As New Data.DataView(oElementos.ObtenerElementos())
                dView.Sort = "NOMBRE_BANCO"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedIndex = -1
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Text, "DesplegarBancos", ex)
        End Try
    End Sub

    Private Sub DesplegarMonedas()
        Dim dView As New Data.DataView
        Try
            With Me.cboMoneda
                .Items.Add("MXN")
                .Items.Add("USD")
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarMonedas", ex)
        End Try
    End Sub

    Private Function ValidaPrePoliza() As Boolean
        Dim bResultado As Boolean = False
        Dim oCuentaBancaria As Class_CatCuentasBancarias
        Dim oCliente As Class_CatClientes
        Dim oContaCuenta As Class_CatCuentas

        Try
            If ExisteDocumento(Me.TxtFolio.Text) = True Then
                MsgBox("El folio del documento : " & Me.CboDocumento.Text & " ya existe, verifíquelo.", MsgBoxStyle.Exclamation, "Contabilizar")
                Exit Function
            End If

            'Me.GeneraFolio() 'No hay que generar folio nuevo porque se manda el folio del documento

            Me.oFormaPoliza = New Frm_Contabilidad_Captura_Polizas

            Me.oFormaPoliza.StartPosition = FormStartPosition.CenterScreen

            Me.oFormaPoliza.ChildParaGrabar = True
            Me.oFormaPoliza.CodigoDocumentoParaGrabar = "I"

            Me.oFormaPoliza.DtpFecha.Value = Me.dtFecha.Value
            Me.oFormaPoliza.TxtTotalCargos.Text = Me.TxtTotal.Text
            Me.oFormaPoliza.TxtTotalAbonos.Text = Me.TxtTotal.Text
            Me.oFormaPoliza.TxtConcepto1.Text = Me.TxtConcepto.Text
            Me.oFormaPoliza.lblFolioOrigen.Text = Me.TxtFolio.Text
            Me.oFormaPoliza.TxtFolio.Text = Me.TxtFolio.Text

            Me.oFormaPoliza.Grid1.Rows = 2
            Me.oFormaPoliza.Grid1.Cols = 7

            Dim i As Integer, R As Integer = 1, dPago As Double, ivaporpagar As Double = 0, dPerdidaGanancia As Double
            Dim oCuentasIVA As Class_find

            oCuentaBancaria = New Class_CatCuentasBancarias(CInt(Me.TxtCuentaBancaria.Text))

            If Me.cboMoneda.Text = "USD" Then

                oContaCuenta = New Class_CatCuentas(oCuentaBancaria.CUENTA_CONTABLE_PESOS.ToString)
                Me.oFormaPoliza.Grid1.Rows = Me.oFormaPoliza.Grid1.Rows + 1

                Me.oFormaPoliza.Grid1.Cell(R, 1).Text = oCuentaBancaria.CUENTA_CONTABLE_PESOS
                Me.oFormaPoliza.Grid1.Cell(R, 2).Text = oCuentaBancaria.NOMBRE_CUENTA_BANCARIA
                Me.oFormaPoliza.Grid1.Cell(R, 3).Text = "" 'oCliente.NOMBRE_CLIENTE
                Me.oFormaPoliza.Grid1.Cell(R, 4).Text = oContaCuenta.NATURALEZA_CONTABLE.ToString
                Me.oFormaPoliza.Grid1.Cell(R, 5).Text = (valorNumerico(Me.TxtTotal.Text) * valorNumerico(Me.txtTipoCambio.Text)).ToString
                Me.oFormaPoliza.Grid1.Cell(R, 6).Text = "0"
                R = R + 1

                For i = 1 To Me.GridVentas.Rows - 1
                    dPago = valorNumerico(Me.GridVentas.Cell(i, Me.iGyVentaPago).Text)

                    If dPago > 0 Then
                        If valorNumerico(Me.GridVentas.Cell(i, Me.iGyVentaTotalDlls).Text) <> valorNumerico(Me.GridVentas.Cell(i, Me.iGyVentaPago).Text) And valorNumerico(Me.GridVentas.Cell(i, Me.iGyVentaSaldoDlls).Text) <> valorNumerico(Me.GridVentas.Cell(i, Me.iGyVentaPago).Text) Then
                            MsgBox("El sistema a detectado un abono en dolares a una venta, favor de terminar de llenar la poliza.", MsgBoxStyle.Information, Me.Text)
                            Exit For
                        End If
                        dPerdidaGanancia = valorNumerico(Me.GridVentas.Cell(i, Me.iGyVentaDiferencia).Text)
                        Me.oFormaPoliza.Grid1.Rows = Me.oFormaPoliza.Grid1.Rows + 1

                        If valorNumerico(Me.GridVentas.Cell(i, Me.iGyVentaPago).Text) = valorNumerico(Me.GridVentas.Cell(i, Me.iGyVentaSaldoDlls).Text) Then
                            ivaporpagar = valorNumerico(Me.GridVentas.Cell(i, Me.iGyVentaIvaPorPagar).Text)
                        Else
                            ivaporpagar = 0
                        End If

                        oCliente = New Class_CatClientes(Me.GridVentas.Cell(i, Me.iGyVentaCodigoCliente).Text)
                        oContaCuenta = New Class_CatCuentas(oCliente.CUENTA_CONTABLE.ToString)

                        Me.oFormaPoliza.Grid1.Cell(R, 1).Text = oCliente.CUENTA_CONTABLE.ToString
                        Me.oFormaPoliza.Grid1.Cell(R, 2).Text = oCliente.NOMBRE_CLIENTE
                        Me.oFormaPoliza.Grid1.Cell(R, 3).Text = Me.GridVentas.Cell(i, Me.iGyVentaReferencia).Text
                        Me.oFormaPoliza.Grid1.Cell(R, 4).Text = oContaCuenta.NATURALEZA_CONTABLE.ToString
                        Me.oFormaPoliza.Grid1.Cell(R, 5).Text = "0"
                        Me.oFormaPoliza.Grid1.Cell(R, 6).Text = valorNumerico(Me.GridVentas.Cell(i, Me.iGyVentaSaldo).Text).ToString '(valorNumerico(Me.Grid.Cell(i, Me.iGySaldo).Text) + dPerdidaGanancia).ToString
                        R = R + 1

                        Me.oFormaPoliza.Grid1.Rows = Me.oFormaPoliza.Grid1.Rows + 1
                        Me.oFormaPoliza.Grid1.Cell(R, 1).Text = oCliente.CUENTA_CONTABLE_DOLARES.ToString
                        Me.oFormaPoliza.Grid1.Cell(R, 2).Text = oCliente.NOMBRE_CLIENTE
                        Me.oFormaPoliza.Grid1.Cell(R, 3).Text = Me.GridVentas.Cell(i, Me.iGyVentaReferencia).Text
                        Me.oFormaPoliza.Grid1.Cell(R, 4).Text = oContaCuenta.NATURALEZA_CONTABLE.ToString
                        Me.oFormaPoliza.Grid1.Cell(R, 5).Text = "0"
                        Me.oFormaPoliza.Grid1.Cell(R, 6).Text = valorNumerico(Me.GridVentas.Cell(i, Me.iGyVentaPago).Text).ToString '(valorNumerico(Me.Grid.Cell(i, Me.iGySaldo).Text) + dPerdidaGanancia).ToString
                        R = R + 1

                        Me.oFormaPoliza.Grid1.Rows = Me.oFormaPoliza.Grid1.Rows + 1
                        oContaCuenta = New Class_CatCuentas(Empresa_Sistema.CUENTA_CONTABLE_CLIENTES_CONTRA_CUENTA_DOLARES.ToString)
                        Me.oFormaPoliza.Grid1.Cell(R, 1).Text = Empresa_Sistema.CUENTA_CONTABLE_CLIENTES_CONTRA_CUENTA_DOLARES.ToString
                        Me.oFormaPoliza.Grid1.Cell(R, 2).Text = oContaCuenta.NOMBRE_CUENTA
                        Me.oFormaPoliza.Grid1.Cell(R, 3).Text = Me.GridVentas.Cell(i, Me.iGyVentaReferencia).Text
                        Me.oFormaPoliza.Grid1.Cell(R, 4).Text = oContaCuenta.NATURALEZA_CONTABLE.ToString
                        Me.oFormaPoliza.Grid1.Cell(R, 5).Text = valorNumerico(Me.GridVentas.Cell(i, Me.iGyVentaPago).Text).ToString
                        Me.oFormaPoliza.Grid1.Cell(R, 6).Text = "0"
                        R = R + 1

                        If valorNumerico(Me.GridVentas.Cell(i, Me.iGyVentaDiferencia).Text) <> 0 Then
                            Me.oFormaPoliza.Grid1.Rows = Me.oFormaPoliza.Grid1.Rows + 1

                            oContaCuenta = New Class_CatCuentas(Empresa_Sistema.CUENTA_CONTABLE_PERDIDA_GANACIA_CAMBIARIA)
                            Me.oFormaPoliza.Grid1.Cell(R, 1).Text = oContaCuenta.CUENTA_CONTABLE.ToString
                            Me.oFormaPoliza.Grid1.Cell(R, 2).Text = oContaCuenta.NOMBRE_CUENTA
                            Me.oFormaPoliza.Grid1.Cell(R, 3).Text = Me.GridVentas.Cell(i, Me.iGyVentaReferencia).Text
                            Me.oFormaPoliza.Grid1.Cell(R, 4).Text = oContaCuenta.NATURALEZA_CONTABLE.ToString

                            'If valorNumerico(Me.GridVentas.Cell(i, Me.iGyVentaDiferencia).Text) < 0 Then
                            '    Me.oFormaPoliza.Grid1.Cell(R, 5).Text = valorNumerico(Me.GridVentas.Cell(i, Me.iGyVentaDiferencia).Text).ToString
                            '    Me.oFormaPoliza.Grid1.Cell(R, 6).Text = "0"
                            'Else
                            '    Me.oFormaPoliza.Grid1.Cell(R, 5).Text = "0"
                            '    Me.oFormaPoliza.Grid1.Cell(R, 6).Text = (valorNumerico(Me.GridVentas.Cell(i, Me.iGyVentaDiferencia).Text) * -1).ToString
                            'End If

                            Me.oFormaPoliza.Grid1.Cell(R, 5).Text = "0"
                            Me.oFormaPoliza.Grid1.Cell(R, 6).Text = valorNumerico(Me.GridVentas.Cell(i, Me.iGyVentaDiferencia).Text).ToString

                            R = R + 1
                        End If

                        If ivaporpagar > 0 Then
                            Me.oFormaPoliza.Grid1.Rows = Me.oFormaPoliza.Grid1.Rows + 1

                            oCuentasIVA = New Class_find("SELECT I.CUENTA_CONTABLE_IVA_POR_PAGAR,I.CUENTA_CONTABLE_IVA_PENDIENTE_TRASLADAR " &
                           "FROM CON_IVA_POR_PAGAR_CATALOGO_CUENTAS I INNER JOIN VENTA_GLOBAL V ON(I.PORCENTAJE=V.IMPUESTO_PORCENTAJE) " &
                           "WHERE V.FOLIO_VENTA='" & Me.GridVentas.Cell(i, Me.iGyVentaFolio).Text & "'")

                            Dim oContaCuenta1 As New Class_CatCuentas
                            oContaCuenta1 = New Class_CatCuentas(oCuentasIVA.Result1) '"20400015"
                            Me.oFormaPoliza.Grid1.Cell(R, 1).Text = oContaCuenta1.CUENTA_CONTABLE
                            Me.oFormaPoliza.Grid1.Cell(R, 2).Text = oContaCuenta1.NOMBRE_CUENTA
                            Me.oFormaPoliza.Grid1.Cell(R, 3).Text = Me.GridVentas.Cell(i, Me.iGyVentaReferencia).Text
                            Me.oFormaPoliza.Grid1.Cell(R, 4).Text = oContaCuenta1.NATURALEZA_CONTABLE.ToString
                            Me.oFormaPoliza.Grid1.Cell(R, 5).Text = "0"
                            Me.oFormaPoliza.Grid1.Cell(R, 6).Text = ivaporpagar.ToString
                            R = R + 1

                            Dim oContaCuenta2 As New Class_CatCuentas
                            oContaCuenta2 = New Class_CatCuentas(oCuentasIVA.Result2) '"20400002"
                            Me.oFormaPoliza.Grid1.Rows = Me.oFormaPoliza.Grid1.Rows + 1
                            Me.oFormaPoliza.Grid1.Cell(R, 1).Text = oContaCuenta2.CUENTA_CONTABLE
                            Me.oFormaPoliza.Grid1.Cell(R, 2).Text = oContaCuenta2.NOMBRE_CUENTA
                            Me.oFormaPoliza.Grid1.Cell(R, 3).Text = Me.GridVentas.Cell(i, Me.iGyVentaReferencia).Text
                            Me.oFormaPoliza.Grid1.Cell(R, 4).Text = oContaCuenta2.NATURALEZA_CONTABLE.ToString
                            Me.oFormaPoliza.Grid1.Cell(R, 5).Text = ivaporpagar.ToString
                            Me.oFormaPoliza.Grid1.Cell(R, 6).Text = "0"
                            R = R + 1

                            oCuentasIVA = Nothing
                        End If

                        Me.oFormaPoliza.Grid1.Rows = Me.oFormaPoliza.Grid1.Rows + 1
                        oContaCuenta = New Class_CatCuentas(oCuentaBancaria.CUENTA_CONTABLE_DOLARES)
                        Me.oFormaPoliza.Grid1.Cell(R, 1).Text = oCuentaBancaria.CUENTA_CONTABLE_DOLARES.ToString
                        Me.oFormaPoliza.Grid1.Cell(R, 2).Text = oCuentaBancaria.NOMBRE_CUENTA_BANCARIA
                        Me.oFormaPoliza.Grid1.Cell(R, 3).Text = Me.GridVentas.Cell(i, Me.iGyVentaReferencia).Text
                        Me.oFormaPoliza.Grid1.Cell(R, 4).Text = oContaCuenta.NATURALEZA_CONTABLE.ToString
                        Me.oFormaPoliza.Grid1.Cell(R, 5).Text = valorNumerico(Me.GridVentas.Cell(i, Me.iGyVentaPago).Text).ToString
                        Me.oFormaPoliza.Grid1.Cell(R, 6).Text = "0"
                        R = R + 1

                        Me.oFormaPoliza.Grid1.Rows = Me.oFormaPoliza.Grid1.Rows + 1
                        oContaCuenta = New Class_CatCuentas(Empresa_Sistema.CUENTA_CONTABLE_CLIENTES_CONTRA_CUENTA_DOLARES.ToString)
                        Me.oFormaPoliza.Grid1.Cell(R, 1).Text = oContaCuenta.CUENTA_CONTABLE.ToString
                        Me.oFormaPoliza.Grid1.Cell(R, 2).Text = oContaCuenta.NOMBRE_CUENTA
                        Me.oFormaPoliza.Grid1.Cell(R, 3).Text = Me.GridVentas.Cell(i, Me.iGyVentaReferencia).Text
                        Me.oFormaPoliza.Grid1.Cell(R, 4).Text = oContaCuenta.NATURALEZA_CONTABLE.ToString
                        Me.oFormaPoliza.Grid1.Cell(R, 5).Text = "0"
                        Me.oFormaPoliza.Grid1.Cell(R, 6).Text = valorNumerico(Me.GridVentas.Cell(i, Me.iGyVentaPago).Text).ToString
                        R = R + 1
                    End If
                Next i

            Else 'MXN

                For i = 1 To Me.GridVentas.Rows - 1
                    If valorNumerico(Me.GridVentas.Cell(i, Me.iGyVentaPago).Text) = valorNumerico(Me.GridVentas.Cell(i, Me.iGyVentaSaldo).Text) Then
                        dPago = valorNumerico(Me.GridVentas.Cell(i, Me.iGyVentaPago).Text)
                        ivaporpagar = valorNumerico(Me.GridVentas.Cell(i, Me.iGyVentaIvaPorPagar).Text)
                    Else
                        dPago = valorNumerico(Me.GridVentas.Cell(i, Me.iGyVentaPago).Text)
                        ivaporpagar = 0
                    End If

                    If dPago > 0 Then
                        Me.oFormaPoliza.Grid1.Rows = Me.oFormaPoliza.Grid1.Rows + 1

                        oCliente = New Class_CatClientes(Me.GridVentas.Cell(i, Me.iGyVentaCodigoCliente).Text)
                        oContaCuenta = New Class_CatCuentas(oCliente.CUENTA_CONTABLE.ToString)

                        Me.oFormaPoliza.Grid1.Cell(R, 1).Text = oCliente.CUENTA_CONTABLE.ToString
                        Me.oFormaPoliza.Grid1.Cell(R, 2).Text = oCliente.NOMBRE_CLIENTE
                        Me.oFormaPoliza.Grid1.Cell(R, 3).Text = Me.GridVentas.Cell(i, Me.iGyVentaReferencia).Text
                        Me.oFormaPoliza.Grid1.Cell(R, 4).Text = oContaCuenta.NATURALEZA_CONTABLE.ToString
                        Me.oFormaPoliza.Grid1.Cell(R, 5).Text = "0"
                        Me.oFormaPoliza.Grid1.Cell(R, 6).Text = dPago.ToString
                        R = R + 1
                    End If

                    If ivaporpagar > 0 Then
                        Me.oFormaPoliza.Grid1.Rows = Me.oFormaPoliza.Grid1.Rows + 1

                        oCuentasIVA = New Class_find("SELECT I.CUENTA_CONTABLE_IVA_POR_PAGAR,I.CUENTA_CONTABLE_IVA_PENDIENTE_TRASLADAR " &
                                                   "FROM CON_IVA_POR_PAGAR_CATALOGO_CUENTAS I INNER JOIN VENTA_GLOBAL V ON(I.PORCENTAJE=V.IMPUESTO_PORCENTAJE) " &
                                                   "WHERE V.FOLIO_VENTA='" & Me.GridVentas.Cell(i, Me.iGyVentaFolio).Text & "'")

                        Dim oContaCuenta1 As New Class_CatCuentas
                        oContaCuenta1 = New Class_CatCuentas(oCuentasIVA.Result1) '"20400015"
                        Me.oFormaPoliza.Grid1.Cell(R, 1).Text = oContaCuenta1.CUENTA_CONTABLE
                        Me.oFormaPoliza.Grid1.Cell(R, 2).Text = oContaCuenta1.NOMBRE_CUENTA
                        Me.oFormaPoliza.Grid1.Cell(R, 3).Text = Me.GridVentas.Cell(i, Me.iGyVentaReferencia).Text
                        Me.oFormaPoliza.Grid1.Cell(R, 4).Text = oContaCuenta1.NATURALEZA_CONTABLE.ToString
                        Me.oFormaPoliza.Grid1.Cell(R, 5).Text = "0"
                        Me.oFormaPoliza.Grid1.Cell(R, 6).Text = ivaporpagar.ToString
                        R = R + 1

                        Dim oContaCuenta2 As New Class_CatCuentas
                        oContaCuenta2 = New Class_CatCuentas(oCuentasIVA.Result2) '"20400002"
                        Me.oFormaPoliza.Grid1.Rows = Me.oFormaPoliza.Grid1.Rows + 1
                        Me.oFormaPoliza.Grid1.Cell(R, 1).Text = oContaCuenta2.CUENTA_CONTABLE
                        Me.oFormaPoliza.Grid1.Cell(R, 2).Text = oContaCuenta2.NOMBRE_CUENTA
                        Me.oFormaPoliza.Grid1.Cell(R, 3).Text = Me.GridVentas.Cell(i, Me.iGyVentaReferencia).Text
                        Me.oFormaPoliza.Grid1.Cell(R, 4).Text = oContaCuenta2.NATURALEZA_CONTABLE.ToString
                        Me.oFormaPoliza.Grid1.Cell(R, 5).Text = ivaporpagar.ToString
                        Me.oFormaPoliza.Grid1.Cell(R, 6).Text = "0"
                        R = R + 1

                        oCuentasIVA = Nothing
                    End If
                Next i

                oContaCuenta = New Class_CatCuentas(oCuentaBancaria.CUENTA_CONTABLE_PESOS.ToString)
                Me.oFormaPoliza.Grid1.Rows = Me.oFormaPoliza.Grid1.Rows + 1
                Me.oFormaPoliza.Grid1.Cell(R, 1).Text = oCuentaBancaria.CUENTA_CONTABLE_PESOS
                Me.oFormaPoliza.Grid1.Cell(R, 2).Text = oCuentaBancaria.NOMBRE_CUENTA_BANCARIA
                Me.oFormaPoliza.Grid1.Cell(R, 3).Text = "" 'oCliente.NOMBRE_CLIENTE
                Me.oFormaPoliza.Grid1.Cell(R, 4).Text = oContaCuenta.NATURALEZA_CONTABLE.ToString
                Me.oFormaPoliza.Grid1.Cell(R, 5).Text = Me.TxtTotal.Text
                Me.oFormaPoliza.Grid1.Cell(R, 6).Text = "0"

            End If

            'Me.AgregaPrepolizaIVAAcreditable()

            Me.oFormaPoliza.lblEstatus.Text = "N"

            Me.oFormaPoliza.ShowDialog()

            bResultado = Me.oFormaPoliza.FormaValidaParaGrabarLlamadoExterior

        Catch ex As Exception
            HandleError(Me.Text, "ValidaPrePoliza", ex)
        Finally
            oCuentaBancaria = Nothing
            oCliente = Nothing
        End Try

        Return bResultado
    End Function

    Private Function AgregaPrepolizaIVAAcreditable() As Boolean
        Dim i As Integer, dPago As Double, sFolio As String, sCodigoDocumento As String ', dIvaImporte As Double
        Dim oCompra As Class_Compras_Global, dtImpuestosAbonos As New DataTable("tabla"), dtImpuestosCargos As New DataTable("tabla")
        Dim dA As SqlDataAdapter
        Try

            dtImpuestosCargos.Columns.Add("CUENTA_CONTABLE", GetType(String))
            dtImpuestosCargos.Columns.Add("NOMBRE_CUENTA", GetType(String))
            dtImpuestosCargos.Columns.Add("NATURALEZA", GetType(String))
            dtImpuestosCargos.Columns.Add("CARGO", GetType(Double))
            dtImpuestosCargos.Columns.Add("TIPO", GetType(String))
            dtImpuestosCargos.Columns.Add("PORCENTAJE", GetType(Double))

            dtImpuestosAbonos.Columns.Add("CUENTA_CONTABLE", GetType(String))
            dtImpuestosAbonos.Columns.Add("NOMBRE_CUENTA", GetType(String))
            dtImpuestosAbonos.Columns.Add("NATURALEZA", GetType(String))
            dtImpuestosAbonos.Columns.Add("ABONO", GetType(Double))
            dtImpuestosAbonos.Columns.Add("TIPO", GetType(String))
            dtImpuestosAbonos.Columns.Add("PORCENTAJE", GetType(Double))

            dA = New SqlDataAdapter("SELECT I.CUENTA_CONTABLE,C.NOMBRE_CUENTA,C.NATURALEZA_CONTABLE,0,0,I.TIPO,I.PORCENTAJE " &
                                    "FROM CON_IVA_ACREDITABLE_CATALOGO_CUENTAS I INNER JOIN CON_CAT_CUENTAS C ON(I.CUENTA_CONTABLE=C.CUENTA_CONTABLE) ORDER BY I.PORCENTAJE,I.TIPO", Empresa_Sistema.conexion)
            dA.Fill(dtImpuestosCargos)
            dA.Dispose()

            For i = 1 To Me.GridVentas.Rows - 1
                sFolio = Me.GridVentas.Cell(i, Me.iGyVentaFolio).Text
                sCodigoDocumento = Me.GridVentas.Cell(i, Me.iGyVentaCodigoCliente).Text
                dPago = valorNumerico(Me.GridVentas.Cell(i, Me.iGyVentaPago).Text)
                If txtLEN(sFolio) = True And dPago > 0 Then
                    oCompra = New Class_Compras_Global(sFolio, sCodigoDocumento)
                    If oCompra.IMPUESTO > 0 AndAlso (dPago - oCompra.SALDO) = 0 Then 'Si es el último pago(si quedará con saldo cero)
                        Dim dRowAbonoRenglon As DataRow
                        Dim dRowAbono() As Data.DataRow = dtImpuestosCargos.Select("PORCENTAJE=" & oCompra.IMPUESTO_PORCENTAJE & " AND TIPO='IVA_PENDIENTE_ACREDITAR'")
                        Dim dRowCargo() As Data.DataRow = dtImpuestosCargos.Select("PORCENTAJE=" & oCompra.IMPUESTO_PORCENTAJE & " AND TIPO='IVA_ACREDITABLE'")

                        'dIvaImporte = (dPago / oCompra.TOTAL) * oCompra.IMPUESTO_PORCENTAJE
                        'dIvaImporte = Redondear(dIvaImporte, Empresa_Sistema.DECIMALES_CONTABILIDAD)
                        'dRow(0)("ABONO") = valorNumerico(dRow(0)("ABONO").ToString) + dIvaImporte

                        dRowAbonoRenglon = dtImpuestosAbonos.NewRow

                        dRowAbonoRenglon("CUENTA_CONTABLE") = dRowAbono(0)("CUENTA_CONTABLE")
                        dRowAbonoRenglon("NOMBRE_CUENTA") = dRowAbono(0)("NOMBRE_CUENTA")
                        dRowAbonoRenglon("NATURALEZA") = dRowAbono(0)("NATURALEZA")
                        dRowAbonoRenglon("ABONO") = oCompra.IMPUESTO
                        dRowAbonoRenglon("TIPO") = dRowAbono(0)("TIPO")
                        dRowAbonoRenglon("PORCENTAJE") = dRowAbono(0)("PORCENTAJE")

                        dtImpuestosAbonos.Rows.Add(dRowAbonoRenglon)

                        dRowCargo(0)("CARGO") = valorNumerico(dRowCargo(0)("CARGO").ToString) + oCompra.IMPUESTO

                        dtImpuestosAbonos.AcceptChanges()
                        dtImpuestosCargos.AcceptChanges()

                    End If
                End If
            Next

            Dim iRow As Integer = 3
            For Each dRow As DataRow In dtImpuestosAbonos.Rows
                Me.oFormaPoliza.Grid1.Rows += 1
                Me.oFormaPoliza.Grid1.Cell(iRow, 1).Text = dRow("CUENTA_CONTABLE").ToString
                Me.oFormaPoliza.Grid1.Cell(iRow, 2).Text = dRow("NOMBRE_CUENTA").ToString
                Me.oFormaPoliza.Grid1.Cell(iRow, 3).Text = Me.TxtConcepto.Text
                Me.oFormaPoliza.Grid1.Cell(iRow, 4).Text = dRow("NATURALEZA").ToString
                Me.oFormaPoliza.Grid1.Cell(iRow, 5).Text = "0"
                Me.oFormaPoliza.Grid1.Cell(iRow, 6).Text = dRow("ABONO").ToString
                iRow += 1
            Next

            If dtImpuestosAbonos.Rows.Count > 0 Then
                For Each dRow As DataRow In dtImpuestosCargos.Select("CARGO<>0")
                    Me.oFormaPoliza.Grid1.Rows += 1
                    Me.oFormaPoliza.Grid1.Cell(iRow, 1).Text = dRow("CUENTA_CONTABLE").ToString
                    Me.oFormaPoliza.Grid1.Cell(iRow, 2).Text = dRow("NOMBRE_CUENTA").ToString
                    Me.oFormaPoliza.Grid1.Cell(iRow, 3).Text = Me.TxtConcepto.Text
                    Me.oFormaPoliza.Grid1.Cell(iRow, 4).Text = dRow("NATURALEZA").ToString
                    Me.oFormaPoliza.Grid1.Cell(iRow, 5).Text = dRow("CARGO").ToString
                    Me.oFormaPoliza.Grid1.Cell(iRow, 6).Text = "0"
                    iRow += 1
                Next
            End If

        Catch ex As Exception
            HandleError(Me.Text, "AgregaPrepolizaIVAAcreditable", ex)
        End Try
    End Function

    Private Function Consultar() As Boolean
        Const sProcedure As String = "Consultar"
        Dim bResultado As Boolean = False
        Dim sFolio As String = Me.TxtFolio.Text

        Try
            Me.GridVentas.Visible = False
            Me.Inicializa()
            Me.oBancosCXC = New Class_Bancos_CXC(sFolio)
            Me.oPolizaGlobal = New Class_Contabilidad_Poliza_Global(sFolio)

            If Me.oBancosCXC.Existe = False Then
                Me.GeneraFolio()
                Me.Cambia_Estado(enumEstados.NUEVO)
                Me.TxtFolio.Enabled = False

                If txtLEN(Me.TxtCuentaBancaria.Text) = True Then
                    'Me.TxtFolio.Enabled = False
                    Me.gbAgregaDocCliente.Enabled = True
                    Me.gbVentas.Enabled = True
                    Me.TxtCuentaBancaria.Enabled = False
                Else
                    'Me.TxtFolio.Enabled = True
                    Me.LblCuentaBancaria.Text = "" : Me.LblCuentaContableCuentaBancaria.Text = ""
                    Me.TxtCuentaBancaria.Enabled = True
                    Me.TxtCuentaBancaria.Focus()
                    MsgBox("Asíge por favor la cuenta bancaria.", MsgBoxStyle.Exclamation, sProcedure)
                End If

                Return False
            Else
                Me.bConsultando = True

                Me.TxtFolio.Text = Me.oBancosCXC.FOLIO_BANCO
                Me.TxtCuentaBancaria.Enabled = False
                Me.TxtFolio.Enabled = False

                Me.CboDocumento.SelectedValue = oBancosCXC.CODIGO_DOCUMENTO
                Me.dtFecha.Value = oBancosCXC.FECHA
                Me.dtFechaCheque.Value = oBancosCXC.FECHA_CHEQUE
                'Me.LblStatus.Text = oBancosCXC.ESTATUS
                Me.LblPoliza.Text = oBancosCXC.FOLIO_POLIZA
                Me.TxtConcepto.Text = oBancosCXC.CONCEPTO1
                Me.TxtCuentaBancaria.Text = oBancosCXC.ID_CUENTA_BANCARIA.ToString
                Me.LblCuentaBancaria.Text = oBancosCXC.NOMBRE_CUENTA_BANCARIA
                Me.LblCuentaContableCuentaBancaria.Text = oBancosCXC.CUENTA_BANCARIA_PESOS
                'me.TxtCodigoCliente.Text = oBancosCXC.CODIGO_Cliente
                'Me.LblCliente.Text = oBancosCXC.NOMBRE_Cliente
                Me.txtTipoCambio.Text = Format(oBancosCXC.TIPO_DE_CAMBIO, "##0.0000")
                Me.TxtTotal.Text = FormatImporteContable(oBancosCXC.TOTAL)

                Select Case oBancosCXC.ESTATUS
                    Case "A"
                        Me.LblStatus.Text = "APLICADO"
                    Case "C"
                        Me.LblStatus.Text = "CANCELADO"
                End Select

                Me.tssElaboro.Text = "Elaboró : " & Me.oBancosCXC.NOMBRE_USUARIO_GRABO & " el " & Format(Me.oBancosCXC.FECHA_SERVIDOR, "dd-MMM-yyyy hh:mm tt")
                If Me.oBancosCXC.ESTATUS = "C" Then
                    Me.tssCancelo.Text = "Canceló : " & Me.oBancosCXC.NOMBRE_USUARIO_CANCELO & " el : " & Format(Me.oBancosCXC.FECHA_DE_CANCELACION_SERVIDOR, "dd-MMM-yyyy hh:mm tt")
                End If
                Me.tssFechaEmisionCFDI.Text = "Fecha emisión CFDI : " & Format(Me.oBancosCXC.FECHA_EMISION_CFDI, "dd-MMM-yyyy hh:mm:ss tt")

                'Me.Grid.Visible = false
                Me.GridVentas.DataSource = Me.oBancosCXC.ObtenerDetalle
                Me.FormateaGridVentas()
                'Me.Grid.Visible = True

                Me.GridDocumentosPago.DataSource = Me.oBancosCXC.ObtenerDetalleDocumentosPago
                Me.FormateaGridDocumentosPago()

                'Para que haga el cambio de las columnas que se van a mostrar
                Me.cboMoneda.Text = oBancosCXC.CODIGO_MONEDA_SAT
                Me.chkVentasNoFiscales.Checked = oBancosCXC.ES_PAGO_VENTAS_NO_FISCALES

                If Me.chkVentasNoFiscales.Checked = False Then 'Si es cuenta fiscal(si no esta marcado el check)
                    Me.lblEsCuentaFiscal.Text = "Sólo facturas"
                Else 'Si es cuenta no fiscal sólo va permitir pagos de remisiones
                    Me.lblEsCuentaFiscal.Text = "Sólo remisiones"
                End If

                bResultado = True

                Me.GestionaCambioEstado()

                Me.bConsultando = False
                Me.TotalesLista()
            End If

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
            Me.bConsultando = False
            Me.GridVentas.Visible = True
        Finally
            Me.GridVentas.Visible = True
        End Try

        Return bResultado
    End Function

    'Private Function CargaVentasConSaldo() As Boolean
    '    Dim bResultado As Boolean = False
    '    Dim dTabla As DataTable
    '    Try
    '        dTabla = oBancosCXC.CargaVentasClienteConSaldo(Me.TxtCodigoCliente.Text)
    '        Me.GridVentas.Rows = 1
    '        For Each dRow As DataRow In dTabla.Rows
    '            Me.GridVentas.AddItem(dRow(0).ToString & Chr(9) & Format(CDate(dRow(1)), "dd-MMM-yyyy") & Chr(9) & dRow(2).ToString & Chr(9) & dRow(3).ToString & Chr(9) & dRow(4).ToString & Chr(9) &
    '                            dRow(5).ToString & Chr(9) & dRow(6).ToString & Chr(9) & dRow(7).ToString & Chr(9) & dRow(8).ToString)
    '        Next

    '        'No es posible hace un datasource y luego intentar cambiar datos de celdas con codigo, no marca error pero no hace el cambio
    '        'Me.Grid1.DataSource = Me.oBancosCXC.CargaComprasClienteConSaldo(Me.TxtCodigoCliente.Text)
    '        'Me.Grid.Rows += 1

    '        If dTabla.Rows.Count = 0 Then
    '            MsgBox("El Cliente no tiene ventas con saldo.", MsgBoxStyle.Information, Me.Text)
    '        End If

    '        bResultado = True
    '        Me.FormateaGrid()

    '    Catch ex As Exception
    '        HandleError(Me.Name, "CargaVentasConSaldo", ex)
    '    End Try

    '    Return bResultado
    'End Function

    Private Function ExisteDocumento(ByVal sFolio As String) As Boolean
        Try
            Dim sql As New Class_find("SELECT 1 FROM BANCOS_GLOBAL WHERE FOLIO_BANCO='" & sReplace(sFolio) & "'")
            If sql.Result1.Length > 0 Then
                ExisteDocumento = True
            End If
        Catch ex As Exception
            HandleError(Me.Name, "ExisteDocumento", ex)
        End Try
    End Function

    Private Function CancelaPagosCXC() As Boolean
        Const sProcedure As String = "CancelaPagosCXC"
        Dim bResultado As Boolean = False

        Dim oFirmaElectronica = New UtileriasFirmaElectronicaCancelacionMovimientosFueraPeriodo
        Dim oUtileriasCancela As New Class_UtileriasFirmaElectronicaCancelacion
        Dim oPoliza As New Class_Contabilidad_Poliza_Global
        'Dim sFolio As String = Me.TxtFolio.Text

        'Me.oBancosCXC = New Class_Bancos_CXC(sFolio)

        If MsgBox("Deseas cancelar el movimiento de " & Me.CboDocumento.Text & " ?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, sProcedure) = MsgBoxResult.No Then
            Return False
        End If

        If Usuario.ValidaPermisoUsuarioDocumentoSinAfectacionInventarios(Me.CboDocumento.SelectedValue.ToString) = False Then
            MsgBox("El usuario " & Usuario.Nombre_Usuario & " no tiene permiso para realizar este movimiento.", MsgBoxStyle.Exclamation, sProcedure)
            Return False
        End If

        'no se ocupa por que para eso esta la interfaz
        'If PLAZA.ValidarPeriodoTrabajo(Date.Now) = False Then 'Para cancelar se valida con la fecha de la maquina
        '    RETURN FALSE
        'End If

        Select Case Me.LblStatus.Text
            Case "NUEVO"
                MsgBox("El documento no se ha grabado.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            Case "APLICADO"
                'No hay restricciones
            Case "CANCELADO"
                MsgBox("Los documentos cancelados no se pueden volver a cancelar.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
        End Select

        Try
            oUtileriasCancela.FOLIO_DOCUMENTO = Me.TxtFolio.Text.ToUpper
            oUtileriasCancela.MODULO = Me.oBancosCXC.CODIGO_MODULO
            oUtileriasCancela.CODIGO_PLAZA = Usuario.Codigo_Plaza

            If oUtileriasCancela.GestionaCancelacion() = False Then
                Return False
            End If

            If oUtileriasCancela.CANCELA_DIRECTO = True Then
                Me.oBancosCXC.FECHA_DE_CANCELACION = Date.Now
                If Me.oBancosCXC.CancelaBancosCXC() = False Then
                    Return False
                Else
                    bResultado = True
                End If
            Else
                oUtileriasCancela = New Class_UtileriasFirmaElectronicaCancelacion
                oUtileriasCancela.FOLIO_DOCUMENTO = Me.TxtFolio.Text
                oUtileriasCancela.FOLIO_POLIZA = Me.oBancosCXC.FOLIO_POLIZA
                oUtileriasCancela.CODIGO_DOCUMENTO = Me.CboDocumento.SelectedValue.ToString
                oUtileriasCancela.CODIGO_PLAZA = Usuario.Codigo_Plaza
                oUtileriasCancela.MODULO = Me.oBancosCXC.CODIGO_MODULO

                If oUtileriasCancela.AutorizaCancelacionMovimientosFueraPeriodo() = False Then
                    MsgBox("Error al tratar de autorizar la cancelación fuera del periodo.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If

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

                    Me.oBancosCXC.FECHA_DE_CANCELACION = oUtileriasCancela.FECHA_CANCELACION

                    If Me.oBancosCXC.CancelaBancosCXC() = False Then
                        MsgBox("Error al intentar cancelar el movimiento de documento de banco.", MsgBoxStyle.Exclamation, sProcedure)
                        Return False
                    Else
                        bResultado = True
                    End If
                End If
            End If

            If bResultado = True Then
                If Me.oDocumento.TIMBRA_DOCUMENTO = True And Me.oBancosCXC.CFDIS_GENERADOS = True Then
                    Me.oBancosCXC.CancelaPagosElectronicos()
                End If

                MsgBox("Movimiento de bancos cancelado satisfactoriamente.", MsgBoxStyle.Information, sProcedure)
            End If

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    Private Function BusquedaVisual_PorDescripcion() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de pagos CXC en bancos."
        f.sCampo = "BAN_FOLIO_BANCO"
        f.sOrder = "BAN_FOLIO_BANCO"
        f.sTable = "VW_BANCOS_GLOBAL_CON_CXC_GLOBAL"
        f.sQl = "Select Distinct BAN_FOLIO_BANCO Folio_BANCO, CXC_NOMBRE_CLIENTE NOMBRE_CLIENTE, BAN_CONCEPTO CONCEPTO,BAN_FECHA FECHA,ban_total TOTAL_PAGO From VW_BANCOS_GLOBAL_CON_CXC_GLOBAL Where 1=1 AND CXC_CODIGO_PLAZA=" & Usuario.Codigo_Plaza & " And "
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

    Private Sub GeneraFolio()
        Try
            If Me.bDocumentosCargados = True Then
                Me.oBancosCXC.CODIGO_DOCUMENTO = Me.CboDocumento.SelectedValue.ToString
                Me.TxtFolio.Text = Me.oBancosCXC.GeneraFolio
            End If
        Catch ex As Exception
            HandleError(Me.Name, "GeneraFolio", ex)
        End Try
    End Sub

    Private Sub Cambia_Estado(ByVal pEstado As enumEstados)
        Try

            Me.gbAgregaDocCliente.Enabled = False 'Se habilita hasta asignar una cuenta bancaria

            Me.Estado = pEstado
            Select Case Me.Estado
                Case enumEstados.NUEVO
                    Me.tsbGrabar.Enabled = True
                    Me.tsbCancelar.Enabled = False
                    Me.tsbImprimirPoliza.Enabled = False
                    Me.tsbImprimirComprobante.Enabled = False
                    Me.CboDocumento.Enabled = True
                    Me.dtFecha.Enabled = True
                    Me.cboMoneda.Enabled = False
                    'Me.txtTipoCambio.Enabled = False'No se cambia para dejar el último estado
                    Me.TxtConcepto.Enabled = True
                    Me.TxtTotal.Enabled = False
                    Me.tssEstado.Text = "Estado: agregando documento " & Me.CboDocumento.Text
                    Me.tssElaboro.Visible = False
                    Me.tssCancelo.Visible = False
                    Me.tssFechaEmisionCFDI.Visible = False
                    Me.GridVentas.Locked = False
                    Me.TxtFolio.Enabled = True
                    Me.TxtCuentaBancaria.Enabled = True
                    If Me.Visible = True Then
                        Me.TxtCuentaBancaria.Focus()
                    End If
                    Me.gbAgregaDocCliente.Enabled = False
                    Me.gbVentas.Enabled = False
                    Me.btnEliminarDocumentoPago.Enabled = True
                    Me.btnVerCFDIS.Enabled = False
                    Me.btnGenerarCFDIS.Enabled = False
                    Me.chkVentasNoFiscales.Enabled = False' Antes estaba true, pero ahora como se llena sólo dependiendo de si la cuenta es o no fiscal, nunca se habilita

                    'Me.gbTotales.Enabled = True

                Case enumEstados.APLICADO
                    Me.tsbGrabar.Enabled = False
                    Me.tsbCancelar.Enabled = True
                    Me.tsbImprimirPoliza.Enabled = True
                    Me.tsbImprimirComprobante.Enabled = True
                    Me.CboDocumento.Enabled = False
                    Me.dtFecha.Enabled = False
                    Me.cboMoneda.Enabled = False
                    Me.txtTipoCambio.Enabled = False
                    Me.TxtConcepto.Enabled = False
                    Me.TxtTotal.Enabled = False
                    Me.tssEstado.Text = "Estado: Consulta de " & Me.CboDocumento.Text
                    Me.tssElaboro.Visible = True
                    Me.tssCancelo.Visible = False
                    Me.tssFechaEmisionCFDI.Visible = True
                    Me.GridVentas.Locked = True
                    Me.GridVentas.Cell(0, Me.iGyVentaPago).Text = "Pagado"
                    Me.GridVentas.Column(Me.iGyVentaSeleccion).Visible = False
                    Me.gbAgregaDocCliente.Enabled = False
                    Me.gbVentas.Enabled = True 'Para que lo puedan recorrer
                    'Me.gbTotales.Enabled = False
                    Me.btnEliminarDocumentoPago.Enabled = False
                    'Me.btnGenerarCFDIS.Enabled = True
                    If Me.oBancosCXC.CFDIS_GENERADOS = True Then
                        Me.btnVerCFDIS.Enabled = True
                        Me.btnGenerarCFDIS.Enabled = False
                    Else
                        Me.btnVerCFDIS.Enabled = False
                        Me.btnGenerarCFDIS.Enabled = True
                    End If
                    Me.chkVentasNoFiscales.Enabled = False

                    Me.tsbImprimirPoliza.Select()

                Case enumEstados.CANCELADO
                    Me.tsbGrabar.Enabled = False
                    Me.tsbCancelar.Enabled = False
                    Me.tsbImprimirPoliza.Enabled = True
                    Me.tsbImprimirComprobante.Enabled = True
                    Me.CboDocumento.Enabled = False
                    Me.dtFecha.Enabled = False
                    Me.cboMoneda.Enabled = False
                    Me.txtTipoCambio.Enabled = False
                    Me.TxtConcepto.Enabled = False
                    Me.TxtTotal.Enabled = False
                    Me.tssEstado.Text = "Estado: Consulta de " & Me.CboDocumento.Text
                    Me.tssElaboro.Visible = True
                    Me.tssCancelo.Visible = True
                    Me.tssFechaEmisionCFDI.Visible = True
                    Me.GridVentas.Locked = True
                    Me.GridVentas.Cell(0, Me.iGyVentaPago).Text = "Pagado"
                    Me.GridVentas.Column(Me.iGyVentaSeleccion).Visible = False
                    Me.gbAgregaDocCliente.Enabled = False
                    Me.gbVentas.Enabled = True 'Para que lo puedan recorrer
                    'Me.gbTotales.Enabled = False
                    Me.btnEliminarDocumentoPago.Enabled = False
                    If Me.oBancosCXC.CFDIS_GENERADOS = True Then
                        Me.btnVerCFDIS.Enabled = True
                        Me.btnGenerarCFDIS.Enabled = False
                    Else
                        Me.btnVerCFDIS.Enabled = False
                        Me.btnGenerarCFDIS.Enabled = False
                    End If
                    Me.chkVentasNoFiscales.Enabled = False

                    Me.tsbImprimirPoliza.Select()

            End Select
        Catch ex As Exception
            HandleError(Me.Name, "Cambia_Estado", ex)
        End Try
    End Sub

    Private Function NavegadorDepositos(ByVal sTipoDeBusqueda As String) As Boolean
        Try
            'No se ocupa la cuenta para navegar
            'If txtLEN(Me.TxtCuentaBancaria.Text) = False Then
            '    MsgBox("Asígne la cuenta bancaria.", MsgBoxStyle.Exclamation, Me.Text)
            '    Me.TxtCuentaBancaria.Focus()
            '    Exit Function
            'End If

            Dim iFolio As Integer, sFolio As String, iPosicion As Integer, sFolioParte2 As String
            If txtLEN(Me.TxtFolio.Text) = False Then
                Me.TxtFolio.Text = Me.oBancosCXC.GeneraFolio
            End If

            If sTipoDeBusqueda = "Anterior" Then
                iPosicion = Me.TxtFolio.Text.IndexOf("-")
                sFolio = Me.TxtFolio.Text.Substring(0, iPosicion)
                iFolio = CInt(Strings.Right(Me.TxtFolio.Text, Len(Me.TxtFolio.Text) - (Len(sFolio) + 1))) ' Me.oVenta.FOLIO_NUMERICO
                iFolio = iFolio - 1

                'sFolioParte2 = "000000" + iFolio.ToString
                'sFolio = sFolio + "-" + sFolioParte2.Substring(Len(sFolioParte2) - 6)

                sFolioParte2 = Format(iFolio, New String(CChar("0"), Me.TxtFolio.Text.Substring(3, Me.TxtFolio.TextLength - iPosicion - 1).Length))
                sFolio = sFolio + "-" + sFolioParte2 'sFolio + "-" + iFolio.ToString

                Me.TxtFolio.Text = sFolio

                If iFolio > 0 Then
                    Me.Consultar()
                Else
                    Me.Inicializa()
                    Me.Cambia_Estado(enumEstados.NUEVO)
                End If

            ElseIf sTipoDeBusqueda = "Siguiente" Then
                iPosicion = Me.TxtFolio.Text.IndexOf("-")
                sFolio = Me.TxtFolio.Text.Substring(0, iPosicion)
                iFolio = CInt(Strings.Right(Me.TxtFolio.Text, Len(Me.TxtFolio.Text) - (Len(sFolio) + 1)))
                iFolio = iFolio + 1

                'sFolioParte2 = "000000" + iFolio.ToString
                'sFolio = sFolio + "-" + sFolioParte2.Substring(Len(sFolioParte2) - 6)

                sFolioParte2 = Format(iFolio, New String(CChar("0"), Me.TxtFolio.Text.Substring(3, Me.TxtFolio.TextLength - iPosicion - 1).Length))
                sFolio = sFolio + "-" + sFolioParte2 'sFolio + "-" + iFolio.ToString

                Me.TxtFolio.Text = sFolio

                If iFolio > 0 Then
                    Me.Consultar()
                End If
            End If

            NavegadorDepositos = True
        Catch ex As Exception
            HandleError(Me.Name, "NavegadorDepositos", ex)
        End Try
    End Function

    Private Sub TotalesLista()
        Dim i As Integer, dPago As Double, sCodigoClientes As String, oCliente As Class_CatClientes
        Me.lstClientesAgregados.Items.Clear()

        For i = 1 To Me.GridVentas.Rows - 1
            sCodigoClientes = Me.GridVentas.Cell(i, Me.iGyVentaCodigoCliente).Text
            dPago = valorNumerico(Me.GridVentas.Cell(i, Me.iGyVentaPago).Text)
            If sCodigoClientes.Length > 0 AndAlso dPago > 0 Then
                Dim item As ListViewItem = Me.lstClientesAgregados.FindItemWithText(sCodigoClientes)

                If item Is Nothing Then
                    oCliente = New Class_CatClientes(sCodigoClientes)

                    item = New ListViewItem(sCodigoClientes)
                    item.SubItems.Add(oCliente.NOMBRE_CLIENTE)
                    item.SubItems.Add(FormatCurrency(dPago, 2))

                    Me.lstClientesAgregados.Items.Add(item)
                Else
                    item.SubItems(2).Text = FormatCurrency(valorNumerico(item.SubItems(2).Text) + dPago, 2)
                End If
            End If
        Next
    End Sub

    Private Function InicializaDocumentoPago() As Boolean
        Try
            Me.TxtCodigoCliente.Text = "" : Me.LblCliente.Text = ""
            Me.cboFormaPago.SelectedValue = "03" '03=Transferencia
            Me.txtFolioDetalle.Text = ""
            Me.CboBancos.SelectedIndex = -1
            Me.txtCuentaEmisor.Text = ""
            Me.txtRFCEmisor.Text = "" : Me.lblRFCEmisor.Text = ""
            Me.dtFechaPagoCliente.Value = Date.Now
            Me.dtFechaCheque.Value = Date.Now
            'Me.txtBeneficiario.Text = ""
            Me.txtMonto.Text = ""
            Me.TxtReferencia.Text = ""
            Me.chkAnticipo.Checked = False
            Me.cboCuentaEmisor.DataSource = Nothing
            Me.chkEsBancoExtranjero.Checked = False
            Me.chkVentasNoFiscales.Enabled = False
            Me.TxtCodigoCliente.Focus()
        Catch ex As Exception
            HandleError(Me.Name, "InicializaDocumentoPago", ex)
        End Try
    End Function

    Private Function AgregaDocumentoPago() As Boolean
        Const sProcedure As String = "AgregaDocumentoPago"
        Dim bResultado As Boolean = True

        Dim oCuentaBancaria As Class_CatCuentasBancarias

        Try
            If txtLEN(Me.TxtCuentaBancaria.Text) = False Then
                MsgBox("Asígne por favor la cuenta bancaria.", MsgBoxStyle.Exclamation, sProcedure)
                If Me.TxtCuentaBancaria.Enabled = True Then
                    Me.TxtCuentaBancaria.Focus()
                End If
                Return False
            End If

            oCuentaBancaria = New Class_CatCuentasBancarias(CInt(Me.TxtCuentaBancaria.Text))

            If Me.GridDocumentosPago.Rows > 2 Then 'Si de algún modo ya tienen mas de un pago, le vamos diciendo que no se permite otro
                MsgBox("Sólo es permitido agregar un sólo documento en esta sección.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            Else 'Si tiene uno sólo pero falta ver si tiene datos
                If txtLEN(Me.GridDocumentosPago.Cell(1, Me.iGyDocFECHA).Text) = True Then
                    MsgBox("Sólo es permitido agregar un sólo documento en esta sección.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If
            End If

            If Me.cboFormaPago.SelectedIndex = -1 Then
                MsgBox("Seleccione la forma de pago.", MsgBoxStyle.Exclamation, sProcedure)
                Me.cboFormaPago.Focus()
                Return False
            End If

            If valorNumerico(Me.txtMonto.Text) <= 0 Then
                MsgBox("Capture el monto.", MsgBoxStyle.Exclamation, sProcedure)
                Me.txtMonto.Focus()
                Return False
            End If

            If Me.cboMoneda.SelectedIndex = -1 Then
                MsgBox("Asígne el tipo de moneda.", MsgBoxStyle.Exclamation, sProcedure)
                'aqui no hay focus porque esta enabled false.
                Return False
            End If

            If txtLEN(Me.txtFolioDetalle.Text) = False Then
                MsgBox("Asígne el folio cheque/transferencia/ficha.", MsgBoxStyle.Exclamation, sProcedure)
                Me.txtFolioDetalle.Focus()
                Return False
            End If

            Dim oFormaPago As New Class_CFD_CatFormasPago(Me.cboFormaPago.SelectedValue.ToString)

            If oFormaPago.ES_BANCARIZADO = True Then

                If txtLEN(Me.txtCuentaEmisor.Text) = False Then
                    MsgBox("Asígne la cuenta del emisor.", vbExclamation, Me.Name)
                    Me.txtCuentaEmisor.Focus()
                    Return False
                End If

                If Len(Me.txtCuentaEmisor.Text) <> oFormaPago.DIGITOS Then
                    MsgBox("La cuenta del emisor debe ser de " & oFormaPago.DIGITOS.ToString & " dígitos para esta forma de pago.", vbExclamation, Me.Name)
                    Me.txtCuentaEmisor.Focus()
                    Return False
                End If

                If oCuentaBancaria.CLABE_INTERBANCARIA.Length <> 18 Then
                    MsgBox("La clabe interbancaria de la cuenta destino(la que recibe los fondos) debe ser de 18 dígitos.", vbExclamation, Me.Name)
                    Return False
                End If
                If Me.chkEsBancoExtranjero.Checked = False Then
                    If Me.CboBancos.SelectedIndex = -1 Then
                        MsgBox("Asígne el banco de la cuenta bancaria.", vbExclamation, sProcedure)
                        Me.CboBancos.Focus()
                        Return False
                    End If
                End If

            Else
                If txtLEN(Me.txtCuentaEmisor.Text) = True Then
                    MsgBox("La cuenta del emisor debe estar en blanco para esta forma de pago.", vbExclamation, Me.Name)
                    Me.txtCuentaEmisor.Focus()
                    Return False
                End If
            End If

            'If Me.cboFormaPago.SelectedValue.ToString = "02" Or Me.cboFormaPago.SelectedValue.ToString = "03" Then '02=CHEQUE NOMINATIVO, 03=TRANSFERENCIA ELECTRONICA DE FONDOS
            '    If Me.CboBancos.SelectedIndex = -1 Then
            '        MsgBox("Asígne el banco de la cuenta bancaria.", vbExclamation, sProcedure)
            '        Me.CboBancos.Focus()
            '        Return False
            '    End If

            '    'If Me.cboMetodoPago.SelectedValue.ToString = "02" Then '02=CHEQUE NOMINATIVO
            '    '    If txtLEN(Me.txtCuentaEmisor.Text) = False Then
            '    '        MsgBox("Asígne la cuenta del emisor.", vbExclamation, sProcedure)
            '    '        Me.txtCuentaEmisor.Focus()
            '    '        Return False
            '    '    End If
            '    'End If

            '    If txtLEN(Me.txtCuentaEmisor.Text) = False Then
            '        MsgBox("Asígne la cuenta del emisor.", vbExclamation, sProcedure)
            '        Me.txtCuentaEmisor.Focus()
            '        Return False
            '    End If
            'End If

            ''si es transferencia la cuenta emisor es opcional(en la contabilidad electrónica, aunque en el complemento de pagos es opcional, es una ambiguedad por eso se pide como oblitario en ch/tr)
            'If txtLEN(Me.txtCuentaEmisor.Text) = True And Len(Me.txtCuentaEmisor.Text) < 10 Then
            '    MsgBox("La cuenta del emisor debe ser de mínimamente de 10 dígitos, si no la tiene puede dejarla en blanco(cuando no es ch/tr).", vbExclamation, Me.Name)
            '    Return False
            'End If

            'If txtLEN(Me.txtBeneficiario.Text) = False Then
            '    MsgBox "Asigne el beneficiario.", vbExclamation, sProcedure
            '    Me.txtBeneficiario.SetFocus
            '    return false
            'End If

            If txtLEN(Me.txtRFCEmisor.Text) = False Then
                MsgBox("Asígne el RFC del emisor.", vbExclamation, sProcedure)
                Me.txtRFCEmisor.Focus()
                Return False
            End If

            If Len(Me.txtRFCEmisor.Text) < 12 Then
                MsgBox("RFC del emisor inválido.", vbExclamation, sProcedure)
                Me.txtRFCEmisor.Focus()
                Return False
            End If

            Dim sql As New Class_find("SELECT 1 FROM CAT_CLIENTES WHERE RFC='" & sReplace(Me.txtRFCEmisor.Text) & "'")
            If txtLEN(sql.Result1) = False Then
                MsgBox("El RFC del cliente no existe o esta dado de baja.", vbExclamation, sProcedure)
                Me.txtRFCEmisor.Focus()
                Return False
            End If

            If Me.cboMoneda.Text = "USD" Then
                If valorNumerico(Me.txtTipoCambio.Text) = 0 Then
                    MsgBox("Asigne el tipo de cambio del documento de pago.", vbExclamation, sProcedure)
                    Me.txtTipoCambio.Focus()
                    Return False
                End If
            End If

            If Me.ExisteFolioPago(Me.txtFolioDetalle.Text) = True Then
                MsgBox("El folio de pago ya existe.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            With Me.GridDocumentosPago
                Dim r As Integer = .Rows - 1

                .Rows += 1
                .Cell(r, Me.iGyDocID_BANCOS_DETALLE).Text = ""
                .Cell(r, Me.iGyDocCODIGO_FORMA_PAGO).Text = Me.cboFormaPago.SelectedValue.ToString
                .Cell(r, Me.iGyDocNOMBRE_FORMA_PAGO).Text = Me.cboFormaPago.Text
                .Cell(r, Me.iGyDocFOLIO_DETALLE).Text = Me.txtFolioDetalle.Text.ToUpper

                'If Me.cboFormaPago.SelectedValue.ToString = "02" Or Me.cboFormaPago.SelectedValue.ToString = "03" Then '02=CHEQUE NOMINATIVO, 03=TRANSFERENCIA ELECTRONICA DE FONDOS
                If oFormaPago.ES_BANCARIZADO = True Then
                    Dim oCuentaEmisor As New Class_CatClientesCuentasBancarias(Me.cboCuentaEmisor.SelectedValue.ToString)

                    If Me.chkEsBancoExtranjero.Checked = False Then 'Es banco nacional
                        .Cell(r, Me.iGyDocCODIGO_BANCO_EMISOR_NACIONAL).Text = Me.CboBancos.SelectedValue.ToString
                        .Cell(r, Me.iGyDocNOMBRE_BANCO_EMISOR_NACIONAL).Text = Me.CboBancos.Text
                    Else 'Es banco extranjero
                        .Cell(r, Me.iGyDocCODIGO_BANCO_EMISOR_NACIONAL).Text = "" 'Los bancos extranjeros no tienen código(ni catálogo), solamente tiene nombre y este es tecleado cada vez.
                        .Cell(r, Me.iGyDocNOMBRE_BANCO_EMISOR_NACIONAL).Text = oCuentaEmisor.NOMBRE_BANCO_EMISOR_EXTRANJERO
                    End If
                    .Cell(r, Me.iGyDocCUENTA_EMISOR).Text = Me.txtCuentaEmisor.Text.ToUpper
                    .Cell(r, Me.iGyDocCUENTA_BENEFICIARIO).Text = oCuentaBancaria.CLABE_INTERBANCARIA 'Cuenta nuestra
                    .Cell(r, Me.iGyDocCODIGO_BANCO_DESTINO_NACIONAL).Text = oCuentaBancaria.CODIGO_BANCO
                    .Cell(r, Me.iGyDocES_BANCO_EXTRANJERO).Text = Convert.ToInt32(Me.chkEsBancoExtranjero.Checked).ToString
                End If

                '.Cell(r, Me.iGyDocFECHA).Text = Format(Me.dtFechaDetalle.Value, "dd-MMM-yyyy")
                .Cell(r, Me.iGyDocFECHA).Text = Me.dtFechaPagoCliente.Value.ToString
                .Cell(r, Me.iGyDocRFC_EMISOR).Text = Me.txtRFCEmisor.Text.ToUpper
                .Cell(r, Me.iGyDocMONTO).Text = valorNumerico(Me.txtMonto.Text).ToString
                .Cell(r, Me.iGyDocCODIGO_MONEDA_SAT).Text = Me.cboMoneda.Text

            End With

            bResultado = True

            Me.AgregarDocumentosClientes()

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    Private Function ExisteFolioPago(ByVal sFolioPago As String) As Boolean
        Dim bResultado As Boolean = False
        Try
            With Me.GridDocumentosPago
                For i = 1 To .Rows - 1
                    If .Cell(i, Me.iGyDocFOLIO_DETALLE).Text.ToUpper = sFolioPago.ToUpper Then
                        bResultado = True
                        Exit For
                    End If
                Next
            End With
        Catch ex As Exception
            HandleError(Me.Name, "ExisteFolioPago", ex)
        End Try
        Return bResultado
    End Function

    Private Function ObtieneIDBancosDetalle(ByVal sFolioPago As String) As Long
        Dim Resultado As Long
        Try
            With Me.GridDocumentosPago
                For i = 1 To .Rows - 1
                    If .Cell(i, Me.iGyDocFOLIO_DETALLE).Text.ToUpper = sFolioPago.ToUpper Then
                        Resultado = CLng(.Cell(i, Me.iGyDocID_BANCOS_DETALLE).Text)
                        Exit For
                    End If
                Next
            End With
        Catch ex As Exception
            HandleError(Me.Name, "ObtieneIDBancosDetalle", ex)
        End Try
        Return Resultado
    End Function

    Private Function EliminarDocumentoPago() As Boolean
        Dim bResultado As Boolean = False, sFolioPago As String, iRow As Integer = 1
        Try
            With Me.GridDocumentosPago
                If .ActiveCell.Row > 0 Then
                    sFolioPago = .Cell(.ActiveCell.Row, Me.iGyDocFOLIO_DETALLE).Text

                    If txtLEN(sFolioPago) = False Then
                        MsgBox("Seleccione un pago para poder eliminarlo.", MsgBoxStyle.Exclamation, Me.Text)
                        Exit Function
                    End If

                    Me.GridVentas.AutoRedraw = False

                    'Eliminar facturas
                    While iRow <= Me.GridVentas.Rows - 1
                        If Me.GridVentas.Cell(iRow, Me.iGyVentaFOLIO_DETALLE).Text.ToUpper = sFolioPago.ToUpper Then
                            Me.GridVentas.RemoveItem(iRow)
                        Else
                            iRow += 1
                        End If
                    End While

                    'Elminar pago
                    .RemoveItem(.ActiveCell.Row)

                    bResultado = True
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "ExisteFolioPago", ex)
        Finally
            Me.GridVentas.AutoRedraw = False
            Me.GridVentas.Refresh()
        End Try
        Return bResultado
    End Function

    Private Function ValidaVentasTenganDocumentoPago() As Boolean
        Dim bResultado As Boolean = False, sFolioPago As String, dPago As Double
        Try
            For i = 1 To Me.GridVentas.Rows - 1
                sFolioPago = Me.GridVentas.Cell(i, Me.iGyVentaFOLIO_DETALLE).Text.ToUpper
                dPago = valorNumerico(Me.GridVentas.Cell(i, Me.iGyVentaPago).Text)
                If dPago > 0 AndAlso txtLEN(sFolioPago) = False Then
                    MsgBox("La factura del renglón #" & i & " no le capturó el folio del pago(cheque/transferencia/ficha).", MsgBoxStyle.Exclamation, Me.Text)
                    Exit For
                End If

                If Me.ExisteFolioPago(sFolioPago) = False Then
                    MsgBox("El folio de pago de la factura del renglón #" & i & "  no existe.", MsgBoxStyle.Exclamation, Me.Text)
                    Exit For
                End If
            Next
            bResultado = True
        Catch ex As Exception
            HandleError(Me.Name, "ValidaVentasTenganDocumentoPago", ex)
        End Try
        Return bResultado
    End Function

    Private Function ValidaSumasDocumentoPagos() As Boolean
        Dim bResultado As Boolean = False, sFolioPago As String, iPago As Integer = 1, iFact As Integer = 1, dTotalPago As Decimal = 0, dDetallePago As Decimal = 0
        Try
            For iPago = 1 To Me.GridDocumentosPago.Rows - 1
                sFolioPago = Me.GridDocumentosPago.Cell(iPago, Me.iGyDocFOLIO_DETALLE).Text.ToUpper
                If txtLEN(sFolioPago) = True Then
                    dTotalPago = valorNumericoD(Me.GridDocumentosPago.Cell(iPago, Me.iGyDocMONTO).Text)
                    'Recorre las facturas y acumula el pago de los abonos de un pago.
                    For iFact = 1 To Me.GridVentas.Rows - 1
                        If sFolioPago = Me.GridVentas.Cell(iFact, Me.iGyVentaFOLIO_DETALLE).Text.ToUpper Then
                            dDetallePago += valorNumericoD(Me.GridVentas.Cell(iFact, Me.iGyVentaPago).Text)
                        End If
                    Next
                    dDetallePago = RedondearD(dDetallePago, Empresa_Sistema.DECIMALES_CONTABILIDAD)

                    If dDetallePago > dTotalPago Then
                        MsgBox("El total de los abonos del pago " & sFolioPago & " es mayor al total del pago.", MsgBoxStyle.Exclamation, Me.Text)
                        Return False
                    End If

                    If dDetallePago < dTotalPago Then
                        If Me.chkVentasNoFiscales.Checked = True Then
                            Dim dAnticipo As Decimal = 0
                            dAnticipo = RedondearD(dTotalPago - dDetallePago, 2)

                            If MsgBox("Le falta aplicar " & FormatImporteContable(dAnticipo, True) & " quiere generarlo como anticipo ?", vbQuestion Or MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then
                                Return False
                            End If

                        Else
                            MsgBox("El total de los abonos del pago " & sFolioPago & " es menor que el total del pago.", MsgBoxStyle.Exclamation, Me.Text)
                            Return False
                        End If

                    End If
                End If
                dTotalPago = 0
                dDetallePago = 0
            Next
            bResultado = True
        Catch ex As Exception
            HandleError(Me.Name, "ValidaSumasDocumentoPagos", ex)
        End Try
        Return bResultado
    End Function

    Private Function CargaCuentasBancariasCliente() As Boolean
        Dim bResultado As Boolean = False
        Try
            Dim oElementos As New Class_CatClientesCuentasBancarias()
            With Me.cboCuentaEmisor
                .DisplayMember = "CUENTA_CLIENTE"
                .ValueMember = "ID_CUENTA"
                Dim dView As New Data.DataView(oElementos.ObtenerElementos(Me.TxtCodigoCliente.Text))
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedIndex = 0
                End If
            End With
            bResultado = True
        Catch ex As Exception
            HandleError(Me.Name, "CargaCuentasBancariasCliente", ex)
        End Try
        Return bResultado
    End Function

    Private Function SeleccionaCuentaEmisor() As Boolean
        Dim bResultado As Boolean = False
        Try
            Dim oCuenta As New Class_CatClientesCuentasBancarias(Me.cboCuentaEmisor.SelectedValue.ToString)
            Me.cboFormaPago.SelectedValue = oCuenta.CODIGO_METODO_PAGO
            Me.txtCuentaEmisor.Text = oCuenta.CUENTA
            Me.CboBancos.SelectedValue = oCuenta.CODIGO_BANCO
            Me.chkEsBancoExtranjero.Checked = oCuenta.ES_BANCO_EXTRANJERO
            bResultado = True
        Catch ex As Exception
            HandleError(Me.Name, "SeleccionaCuentaEmisor", ex)
        End Try
        Return bResultado
    End Function

    Private Function GestionaAltaEdicionCuentaBancariaCliente(ByVal bAlta As Boolean) As Boolean
        Dim bResultado As Boolean = False
        Try
            Dim oCuenta As New Catalogo_ClientesCuentasBancarias
            Select Case bAlta
                Case True
                    oCuenta.ACCION = Catalogo_ClientesCuentasBancarias.EACCION.AGREGAR
                Case False
                    oCuenta.ACCION = Catalogo_ClientesCuentasBancarias.EACCION.EDITAR
                    oCuenta.ID_CUENTA = Me.cboCuentaEmisor.SelectedValue.ToString
            End Select
            oCuenta.CODIGO_CLIENTE = Me.TxtCodigoCliente.Text

            oCuenta.ShowDialog()

            If oCuenta.ID_CUENTA IsNot Nothing Then
                Me.CargaCuentasBancariasCliente()
                Me.cboCuentaEmisor.SelectedValue = oCuenta.ID_CUENTA
                'Me.SeleccionaCuentaEmisor() 'Se tiene que poner porque cuando se edita una cuenta falta refrescar el combo
            End If

            oCuenta.Dispose()

            bResultado = True

        Catch ex As Exception
            HandleError(Me.Name, "GestionaAltaEdicionCuentaBancariaCliente", ex)
        End Try

        Return bResultado
    End Function

    Private Sub CalculaImporteDolares()
        Try
            Dim i As Integer, dPago As Double
            For i = 1 To Me.GridVentas.Rows - 1
                dPago = valorNumerico(Me.GridVentas.Cell(i, Me.iGyVentaPago).Text)
                If dPago > 0 Then
                    Me.CalculaImportesPagoUSD(i)
                End If
            Next i
        Catch ex As Exception
            HandleError(Me.Name, "CalculaImporteDolares", ex)
        End Try
    End Sub

    Private Sub CalculaImportesPagoUSD(ByVal Renglon As Integer)
        Try
            Dim oVenta As New Class_Ventas_Global '(Me.GridVentas.Cell(Renglon, Me.iGyVentaFolio).Text)
            oVenta.FOLIO_VENTA = Me.GridVentas.Cell(Renglon, Me.iGyVentaFolio).Text
            oVenta.ConsultarSinFiltrarPlaza()
            Dim dTipoCambioPago As Decimal, dPesosViejos As Decimal, dPesosNuevos As Decimal, dDiferencia As Decimal, dImporteMonedaVenta As Decimal, dSaldoAnteriorMonedaVenta As Decimal, dSaldoAnteriorMonedaPago As Decimal
            Dim dSaldoUSD As Decimal, dPagoUSD As Decimal

            dPagoUSD = valorNumericoD(Me.GridVentas.Cell(Renglon, Me.iGyVentaPago).Text)
            dTipoCambioPago = valorNumericoD(Me.txtTipoCambio.Text)
            dPesosNuevos = RedondearD(CDec(dPagoUSD * dTipoCambioPago), 2)

            If oVenta.CODIGO_MONEDA_SAT = "MXN" Then
                dSaldoUSD = RedondearD(CDec(oVenta.SALDO) / dTipoCambioPago, 2) 'Es una factura en MXN, no tiene un saldo en USD, pero así lo virtualizamos

                'If dPesosNuevos > oVenta.SALDO Then'Si por diferencia de decimales se pasan lo pesos a afectar, se ajustan(esto porque se esta pagando en usd una vta en mxn)
                If dSaldoUSD = dPagoUSD Then 'Si están pagado los dólares a tpcam actual, entonces están saldando
                    dPesosNuevos = CDec(oVenta.SALDO)
                End If

                dPesosViejos = dPesosNuevos

                dImporteMonedaVenta = dPesosNuevos
                dSaldoAnteriorMonedaVenta = CDec(oVenta.SALDO)
                dSaldoAnteriorMonedaPago = dSaldoUSD

            Else 'USD
                dPesosViejos = RedondearD(CDec(dPagoUSD * oVenta.TIPO_DE_CAMBIO), 2)

                'dSaldoUSD = RedondearD(CDec(oVenta.SALDO) / CDec(oVenta.TIPO_DE_CAMBIO), 2)
                dSaldoUSD = CDec(oVenta.SALDO_DOLARES) 'Ahora el saldo en usd ya no se calcula, ya esta definido en el campo, aunque falta revisar que lo afecte descuentos(y cancelacion) y devoluciones(y cancelación)

                dImporteMonedaVenta = dPagoUSD
                dSaldoAnteriorMonedaVenta = dSaldoUSD
                dSaldoAnteriorMonedaPago = dSaldoUSD
            End If

            dDiferencia = dPesosNuevos - dPesosViejos

            'Me.GridVentas.Cell(Renglon, Me.iGyVentaSaldo).Text'No se necesita refrescar porque este dato no importa al ser un pago en USD el que importa es el saldo en MXN
            Me.GridVentas.Cell(Renglon, Me.iGyVentaSaldoDlls).Text = dSaldoUSD.ToString
            Me.GridVentas.Cell(Renglon, Me.iGyVentaPagoPesos).Text = dPesosViejos.ToString
            Me.GridVentas.Cell(Renglon, Me.iGyVentaDiferencia).Text = dDiferencia.ToString
            Me.GridVentas.Cell(Renglon, Me.iGyVentaImporteMonedaVenta).Text = dImporteMonedaVenta.ToString
            Me.GridVentas.Cell(Renglon, Me.iGyVentaSaldoAnteriorMonedaVenta).Text = dSaldoAnteriorMonedaVenta.ToString
            Me.GridVentas.Cell(Renglon, Me.iGyVentaSaldoAnteriorMonedaPago).Text = dSaldoAnteriorMonedaPago.ToString

        Catch ex As Exception
            HandleError(Me.Name, "CalculaImportesPagoUSD", ex)
        End Try
    End Sub

    Private Sub CalculaImportesPagoMXN(ByVal Renglon As Integer)
        Try
            Dim oVenta As New Class_Ventas_Global '(Me.GridVentas.Cell(Renglon, Me.iGyVentaFolio).Text)
            oVenta.FOLIO_VENTA = Me.GridVentas.Cell(Renglon, Me.iGyVentaFolio).Text
            oVenta.ConsultarSinFiltrarPlaza()
            Dim dTipoCambioPago As Decimal, dPesosViejos As Decimal, dPesosNuevos As Decimal, dDiferencia As Decimal, dImporteMonedaVenta As Decimal, dSaldoAnteriorMonedaVenta As Decimal, dSaldoAnteriorMonedaPago As Decimal
            Dim dSaldoUSD As Decimal, dPagoUSD As Decimal, dSaldoMXN As Decimal

            dPesosNuevos = valorNumericoD(Me.GridVentas.Cell(Renglon, Me.iGyVentaPago).Text)
            dTipoCambioPago = valorNumericoD(Me.txtTipoCambio.Text)

            If oVenta.CODIGO_MONEDA_SAT = "USD" Then
                'dSaldoUSD = RedondearD(CDec(oVenta.SALDO) / CDec(oVenta.TIPO_DE_CAMBIO), 2) 'Si bien hay un oVenta.SALDO_DOLARES, no se confia en este dato porque no se si se afecte con descuentos y otros movs
                dSaldoUSD = CDec(oVenta.SALDO_DOLARES) 'Ahora el saldo en usd ya no se calcula, ya esta definido en el campo, aunque falta revisar que lo afecte descuentos(y cancelacion) y devoluciones(y cancelación)
                dSaldoMXN = RedondearD(dSaldoUSD * dTipoCambioPago, 2) 'Actualizamos el saldo en MXN a tipo de cambio actual(los pesos que nos debe ahora son otros)
                dPagoUSD = RedondearD(dPesosNuevos / dTipoCambioPago, 2) 'Simulamos que fuimos al banco a cambiar los mxn por usd
                dPesosViejos = RedondearD(dPagoUSD * CDec(oVenta.TIPO_DE_CAMBIO), 2) 'Esto es lo que realmente se va abonar en cxc

                dImporteMonedaVenta = dPagoUSD
                dSaldoAnteriorMonedaVenta = dSaldoUSD
                dSaldoAnteriorMonedaPago = dSaldoMXN

            Else 'MXN
                dPesosViejos = dPesosNuevos
                dSaldoMXN = CDec(oVenta.SALDO)

                dImporteMonedaVenta = dPesosNuevos
                dSaldoAnteriorMonedaVenta = CDec(oVenta.SALDO)
                dSaldoAnteriorMonedaPago = CDec(oVenta.SALDO)
            End If

            dDiferencia = dPesosNuevos - dPesosViejos

            Me.GridVentas.Cell(Renglon, Me.iGyVentaSaldo).Text = dSaldoMXN.ToString 'Actualizamos el saldo de la venta por si esta variando mientras capturan
            Me.GridVentas.Cell(Renglon, Me.iGyVentaPagoPesos).Text = dPesosViejos.ToString
            Me.GridVentas.Cell(Renglon, Me.iGyVentaDiferencia).Text = dDiferencia.ToString
            Me.GridVentas.Cell(Renglon, Me.iGyVentaImporteMonedaVenta).Text = dImporteMonedaVenta.ToString
            Me.GridVentas.Cell(Renglon, Me.iGyVentaSaldoAnteriorMonedaVenta).Text = dSaldoAnteriorMonedaVenta.ToString
            Me.GridVentas.Cell(Renglon, Me.iGyVentaSaldoAnteriorMonedaPago).Text = dSaldoAnteriorMonedaPago.ToString

        Catch ex As Exception
            HandleError(Me.Name, "CalculaImportesPagoMXN", ex)
        End Try
    End Sub

    Private Sub GestionaGrid(ByVal e As System.Windows.Forms.KeyEventArgs)
        Const sProcedure As String = "GestionaGrid"
        Try
            Dim Columna As Integer = Me.GridVentas.Selection.FirstCol, Renglon As Integer = Me.GridVentas.Selection.FirstRow
            Dim StrCod As String = Me.GridVentas.Cell(Renglon, Columna).Text
            Dim dTipoCambioPago As Decimal ', dPesosViejos As Decimal, dPesosNuevos As Decimal, dDiferencia As Decimal

            Dim dPago As Double

            Select Case e.KeyCode
                Case Keys.Enter
                    Select Case Columna
                        'Case 1, 2, 3, 4, 5, 6
                        '    Me.Grid1.Cell(Renglon, Columna).SetFocus()
                        'Case 6
                        '    Me.Grid1.Cell(Renglon, 6).SetFocus()

                        Case Me.iGyVentaPago
                            dPago = valorNumerico(Me.GridVentas.Cell(Renglon, Me.iGyVentaPago).Text)
                            dTipoCambioPago = valorNumericoD(Me.txtTipoCambio.Text)

                            If dPago > 0 And txtLEN(Me.GridVentas.Cell(Renglon, Me.iGyVentaFolio).Text) = True Then
                                If Me.cboMoneda.Text = "USD" Then
                                    If dPago > valorNumerico(Me.GridVentas.Cell(Renglon, Me.iGyVentaSaldoDlls).Text) And Me.GridVentas.Locked = False Then
                                        MsgBox("El pago en el renglón: " & Renglon & " es mayor al saldo del documento favor de revisar.", MsgBoxStyle.Exclamation, sProcedure)
                                        Me.GridVentas.Cell(Renglon, Me.iGyVentaPago).Text = "0.00"
                                        Me.GridVentas.Cell(Renglon, Me.iGyVentaPago).SetFocus()
                                        Me.BorraPago(Renglon)
                                        Exit Sub
                                    End If

                                    Me.CalculaImportesPagoUSD(Renglon)

                                Else 'MXN
                                    If dPago > valorNumerico(Me.GridVentas.Cell(Renglon, Me.iGyVentaSaldo).Text) And Me.GridVentas.Locked = False Then
                                        MsgBox("El pago en el renglón: " & Renglon & " es mayor al saldo del documento favor de revisar.", MsgBoxStyle.Exclamation, sProcedure)
                                        Me.GridVentas.Cell(Renglon, Me.iGyVentaPago).Text = "0.00"
                                        Me.GridVentas.Cell(Renglon, Me.iGyVentaPago).SetFocus()
                                        Me.BorraPago(Renglon)
                                        Exit Sub
                                    End If

                                    Me.CalculaImportesPagoMXN(Renglon)

                                End If

                            ElseIf dPago > 0 And Me.GridVentas.Rows = Renglon Then
                                Me.GridVentas.Rows = Me.GridVentas.Rows + 1

                            ElseIf dPago = 0 Then
                                Me.BorraPago(Renglon)
                            End If
                    End Select

                Case Keys.F8
                    If Me.GridVentas.Rows > 2 Then
                        Me.GridVentas.Selection.DeleteByRow()
                        'e.SuppressKeyPress = True
                    Else
                        Me.InicializaGridVentas()
                    End If
            End Select
            Me.Totales()

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Sub BorraPago(ByVal Renglon As Integer)
        Try
            Me.GridVentas.Cell(Renglon, Me.iGyVentaPago).Text = "0"
            Me.GridVentas.Cell(Renglon, Me.iGyVentaPagoPesos).Text = "0"
            Me.GridVentas.Cell(Renglon, Me.iGyVentaDiferencia).Text = "0"
            Me.GridVentas.Cell(Renglon, Me.iGyVentaImporteMonedaVenta).Text = "0"
            Me.GridVentas.Cell(Renglon, Me.iGyVentaSaldoAnteriorMonedaVenta).Text = "0"
            Me.GridVentas.Cell(Renglon, Me.iGyVentaSaldoAnteriorMonedaPago).Text = "0"
        Catch ex As Exception
            HandleError(Me.Name, "BorraPago", ex)
        End Try
    End Sub

    Private Function SeleccionarSPEI() As Boolean
        Try
            Dim OpenFileDialog1 As New OpenFileDialog(), sRutaXML As String = ""

            With OpenFileDialog1
                '.InitialDirectory = My.Settings.Ruta & FolderRpt
                .Filter = "xml files (*.xml)|*.xml"
                .Title = "Seleccione un xml de tipo SPEI"
                .RestoreDirectory = True
                .Multiselect = False

                If .ShowDialog() = DialogResult.OK Then
                    sRutaXML = .FileName
                End If
            End With

            OpenFileDialog1.Dispose()

            If txtLEN(sRutaXML) = True Then
                Me.ObtieneDatosSPEI(sRutaXML)
            End If

        Catch ex As Exception
            HandleError(Me.Name, "SeleccionarSPEI", ex)
        End Try
    End Function

    Private Function ObtieneDatosSPEI(ByVal sRutaXML As String) As Boolean
        Const sProcedure As String = "ObtieneDatosSPEI"
        Dim bResultado As Boolean = False

        Try
            Dim xmlDoc As MSXML2.DOMDocument60

            'sRutaXML = "E:\_Documentacion\_Sellos digitales fact ele PASSA\CFDI 3.3 y complemento pagos\ComplementoPagos\spei_CEP-20170518-8846CAP3201705180451295223.xml"

            Me.txtSPEI_numeroCertificado.Text = ""
            Me.txtSPEI_sello.Text = ""
            Me.txtSPEI_cadenaCDA.Text = ""

            xmlDoc = New MSXML2.DOMDocument60
            xmlDoc.load(sRutaXML)

            Dim Nodo As MSXML2.IXMLDOMNode

            Nodo = xmlDoc.selectSingleNode("//@numeroCertificado")
            If Not (Nodo Is Nothing) Then
                Me.txtSPEI_numeroCertificado.Text = Nodo.text
            Else
                MsgBox("El xml seleccionado no es de tipo SPEI.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            Nodo = xmlDoc.selectSingleNode("//@sello")
            If Not (Nodo Is Nothing) Then
                Me.txtSPEI_sello.Text = Nodo.text
            End If

            Nodo = xmlDoc.selectSingleNode("//@cadenaCDA")
            If Not (Nodo Is Nothing) Then
                Me.txtSPEI_cadenaCDA.Text = Nodo.text
            End If

            Nodo = xmlDoc.selectSingleNode("/SPEI_Tercero/Ordenante/@Cuenta")
            If Not (Nodo Is Nothing) Then
                Me.txtCuentaEmisor.Text = Nodo.text
            End If

            Nodo = xmlDoc.selectSingleNode("/SPEI_Tercero/Ordenante/@RFC")
            If Not (Nodo Is Nothing) Then
                Me.txtRFCEmisor.Text = Nodo.text
            End If

            Nodo = xmlDoc.selectSingleNode("/SPEI_Tercero/Beneficiario/@MontoPago")
            If Not (Nodo Is Nothing) Then
                Me.txtMonto.Text = FormatImporteContable(valorNumericoD(Nodo.text))
            End If

            Nodo = xmlDoc.selectSingleNode("//@FechaOperacion")
            If Not (Nodo Is Nothing) Then
                Me.dtFechaPagoCliente.Value = CDate(Nodo.text)
            End If

            Me.CboBancos.SelectedValue = Me.txtCuentaEmisor.Text.Substring(0, 3)

            'Set Nodo = xmlDoc.selectSingleNode("/SPEI_Tercero/Beneficiario/@Cuenta")'Así podemos extraer datos de los otros nodos del spei

            bResultado = True

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    Private Function ValidaVentasTimbradas() As Boolean
        Dim bResultado As Boolean = False, dPago As Double, sFacturas As String = ""
        Try
            For i = 1 To Me.GridVentas.Rows - 1
                dPago = valorNumerico(Me.GridVentas.Cell(i, Me.iGyVentaPago).Text)
                If dPago > 0 Then

                    'Si es una factura electrónica de crédito y no esta timbrada
                    If Me.GridVentas.Cell(i, Me.iGyVentaEsFacturaElectronica).Text = "1" And Me.GridVentas.Cell(i, Me.iGyVentaFormaPago).Text = "99" And Me.GridVentas.Cell(i, Me.iGyVentaMetodoPago).Text = "PPD" And
                        txtLEN(Me.GridVentas.Cell(i, Me.iGyVentaVersionCFDI).Text) = False Then

                        sFacturas = sFacturas & Me.GridVentas.Cell(i, Me.iGyVentaFolio).Text & ","
                    End If
                End If
            Next

            If txtLEN(sFacturas) = True Then
                If MsgBox("Las facturas " & sFacturas & " no estan timbradas. Si usted continua estas facturas no va formar parte del pago timbrado. " & vbCrLf &
                               "Seguro desea continuar ?", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then
                    Return False
                End If
            End If

            bResultado = True
        Catch ex As Exception
            HandleError(Me.Name, "ValidaVentasTimbradas", ex)
        End Try

        Return bResultado
    End Function

    Private Sub ImprimirComprobante()
        Dim StrFiltros As String = ""
        Dim FormatoDeReporte As String
        Dim Rpt As New ReportDocument
        Dim oReporte As Class_Reporte
        Try
            FormatoDeReporte = "DEPOSITO_CXC"
            oReporte = New Class_Reporte(FormatoDeReporte, Rpt, False)
            If Not oReporte.RptCargado Then
                Exit Sub
            End If
            Rpt.SetParameterValue("@FOLIO_BANCO", Me.TxtFolio.Text)
            Dim frm As New Reporte(Rpt)
            frm.CRViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            frm.Show()
        Catch ex As Exception
            HandleError(Me.Name, "ImprimirComprobante", ex)
        Finally
            oReporte = Nothing
        End Try
    End Sub

#End Region

End Class
