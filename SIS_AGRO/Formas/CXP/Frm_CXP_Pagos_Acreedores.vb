Imports CrystalDecisions.CrystalReports.Engine

Public Class Frm_CXP_Pagos_Acreedores

#Region "Campos privados"
    Private oDocumento As New Class_CatDocumentos
#End Region

#Region "Propiedades"
    Public ReadOnly Property Nombre_Modulo() As String
        Get
            Return "Pagos a Acreedores."
        End Get
    End Property


#End Region

#Region "Campos públicos"
    Public Enum enumModoPago
        ACREEDOR
        PROVEEDOR
    End Enum

    Public ModoPago As enumModoPago
#End Region

#Region "Campos privados"
    Private dDiferenciaCambiaria As Double

    Private Enum enumEstados
        NUEVO
        GRABADO
        APLICADO
        CANCELADO
    End Enum

    Private Estado As enumEstados

    Private Child As New Frm_CXP_Autorizaciones
    Private bAutorizacionesConsultada As Boolean = False

    'Private oDocumento As New Class_CatDocumentos("CHB" & Usuario.Codigo_Plaza.ToString)
    Private oBancosCXP As New Class_Bancos_CXP
    Private oCxpAfectaDocumentos As New Class_CXP_Afecta_Documentos
    'Private oFormaPoliza As Frm_Contabilidad_Captura_Polizas
    Private oPolizaGlobal As Class_Contabilidad_Poliza_Global
    'Private _ModoPagoProveedores As Boolean = True

    Private FormaCargada As Boolean

    Private ClickSinEjecutar As Boolean = False
#End Region

#Region "Columnas Grid pagos"
    Private iGyFacturaProveedor As Integer = 1
    Private iGyFecha As Integer = 2
    Private iGyFolio As Integer = 3
    Private iGyMoneda As Integer = 4
    Private iGyTipoCambio As Integer = 5
    Private iGyImpuestoUSD As Integer = 6
    Private iGyTotalUSD As Integer = 7
    Private iGySaldoUSD As Integer = 8
    Private iGyConcepto As Integer = 9
    Private iGyImpuestoMXN As Integer = 10
    Private iGyTotalMXN As Integer = 11
    Private iGySaldoMXN As Integer = 12
    Private iGySaldoImpuesto As Integer = 13
    Private iGyRetencion As Integer = 14
    Private iGyPagarImpuesto As Integer = 15
    Private iGyPagoMXN As Integer = 16
    Private iGyPagoUSD As Integer = 17
    Private iGySeleccion As Integer = 18
    Private iGyCodigoDocumento As Integer = 19
    Private iGyAutorizado As Integer = 20
    'No se sabe para que se crearon estas columnas
    'Private iGyAbonarCXP1 As Integer = 15
    'Private iGyDiferencia1 As Integer = 15
    'Private iGySaldoUSDRestante As Integer = 15
    'Private iGySaldoMXPRestante As Integer = 15
    'Private iGyDiferencia2 As Integer = 15
    'Private iGyAbonarCXP2 As Integer = 15
#End Region

#Region "Columnas Grid embarques"
    'Private iGyFactura As Integer = 1
    Private iGyFolioEmbarque As Integer = 1
    Private iGyConceptoFlete As Integer = 2
    Private iGyTotalFlete As Integer = 3
    Private iGySaldoFlete As Integer = 4
    Private iGyPagoFlete As Integer = 5
    Private iGySeleccionFlete As Integer = 6
#End Region

#Region "Propiedades"
    'Public WriteOnly Property ModoPagoProveedores() As Boolean
    '    Set(ByVal Value As Boolean)
    '        Me._ModoPagoProveedores = Value
    '    End Set
    'End Property
#End Region

#Region "Opciones"
    Private Sub tsbNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbNuevo.Click
        Me.Inicializa()
        Me.Cambia_Estado(enumEstados.NUEVO)

        'If Me.oDocumento.SOLICITA_CUENTA_ORIGEN_RECURSOS = True Then
        '    Me.txtCuentaBancaria.Text = "0" '0=Cuenta protegida para estos casos donde no aplica una cuenta bancaria
        '    TxtCuentaBancaria_KeyDown(sender, New KeyEventArgs(Keys.Return))
        'End If
    End Sub

    Private Sub tsbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGrabar.Click
        If Me.ModoPago = enumModoPago.PROVEEDOR Then
            Me.Totales()
        Else
            If Me.CkbPagoFleteEmbarques.Checked = True Then
                Me.Totales()
            End If
        End If

        If Me.GestionaGrabar() = True Then
            Me.Consultar()
        End If
    End Sub

    Private Sub tsbCancelar_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCancelar.Click
        If Me.CancelaPagosCXP() = True Then
            Me.Consultar()
        End If
    End Sub

    Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click
        Me.Imprimir()
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub

    Private Sub btnAutorizaciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAutorizaciones.Click
        Me.Autorizaciones()
    End Sub

    Private Sub btnSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSiguiente.Click
        Me.SiguienteProveedor()
    End Sub

    Private Sub btnDocumentoAnterior_Click(sender As Object, e As EventArgs) Handles btnDocumentoAnterior.Click
        Me.Navegador("Anterior")
    End Sub

    Private Sub btnDocumentoSiguiente_Click(sender As Object, e As EventArgs) Handles btnDocumentoSiguiente.Click
        Me.Navegador("Siguiente")
    End Sub

    Private Sub tsbIvaAcreditable_Click(sender As Object, e As EventArgs) Handles tsbIvaAcreditable.Click
        Dim oIVA As New Frm_Contabilidad_IVA_Acreditable_Global
        oIVA.FolioPolizaConsultaExterior = Me.TxtFolio.Text
        oIVA.FechaPolizaConsultaExterior = Me.dtFecha.Value

        oIVA.ShowDialog()
        oIVA.Dispose()
    End Sub
#End Region

#Region "Eventos de objetos"
    Private Sub Frm_CXC_Pagos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.DesplegarDocumentos()
            Me.DesplegarDocumentosProveedor()
            Me.DesplegarTiposPago()
            Me.DesplegarMonedas()

            Me.dtFecha.Value = Date.Now

            Me.Inicializa()

            Select Case Me.ModoPago
                Case enumModoPago.PROVEEDOR
                    Me.Text = "Pagos a proveedores"
                    Me.LblDisplayProveedor.Text = "Proveedor"
                    Me.lblNombreMonedaDestino.Visible = False

                    Me.gbGlobal.Controls.Remove(Me.TxtImporte) : Me.gbCompras.Controls.Add(Me.TxtImporte)
                    Me.gbGlobal.Controls.Remove(Me.LblDisplayImporte) : Me.gbCompras.Controls.Add(Me.LblDisplayImporte)

                    Me.TxtImporte.Location = New Point(777, 297) : Me.LblDisplayImporte.Location = New Point(700, 275)
                    Me.LblDisplayImporte.Text = "Total :" : Me.TxtImporte.Enabled = False

                Case enumModoPago.ACREEDOR
                    Me.Text = "Traspasos entre cuentas"
                    Me.LblDisplayProveedor.Text = "Cuenta destino :"
                    Me.lblNombreMonedaDestino.Visible = True

                    Me.CkbPagoFleteEmbarques.Visible = False 'True ' De momento no se usa, tambien se puede provisionar desde gastos y conta recibos
                    Me.CkbPagoFleteEmbarques.Checked = False
                    Me.ckbAbonoCuentaBeneficiario.Visible = False
                    Me.CboFacturasRecibidas.Visible = False : Me.lblFacturasRecibidas.Visible = False

                    Me.Grid1.Height = 70
                    Me.Grid1.Rows = 1

                    Me.cboDocumento.SelectedValue = "TRB" & Usuario.Codigo_Plaza.ToString
                    Me.cboTipoPago.SelectedValue = 26 '26=T. INTERBANCARIAS
            End Select

            Me.FormaCargada = True

            Me.Cambia_Estado(enumEstados.NUEVO)

        Catch ex As Exception
            HandleError(Me.Name, "Frm_CXC_Pagos_Load", ex)
        End Try
    End Sub

    Private Sub Frm_CXP_Pagos_Acreedores_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If Me.Estado = enumEstados.NUEVO And Me.txtCuentaBancaria.Enabled = True Then
            Me.txtCuentaBancaria.Focus()
        End If
    End Sub

    Private Sub Grid1_Click(ByVal Sender As Object, ByVal e As System.EventArgs) Handles Grid1.Click
        Try
            If Me.Grid1.ActiveCell.ImageKey = "Image1" Then
                Me.Grid1.ActiveCell.SetImage("Image2")

                Me.SetRowVisible(Me.Grid1.ActiveCell.Row + 1, Me.Grid1.ActiveCell.Row + CInt(Me.Grid1.Cell(Me.Grid1.ActiveCell.Row, 2).Text), True)

            ElseIf Grid1.ActiveCell.ImageKey = "Image2" Then
                Me.Grid1.ActiveCell.SetImage("Image1")

                Me.SetRowVisible(Me.Grid1.ActiveCell.Row + 1, Me.Grid1.ActiveCell.Row + CInt(Me.Grid1.Cell(Me.Grid1.ActiveCell.Row, 2).Text), False)
            End If
        Catch ex As Exception
            HandleError(Me.Name, "Grid1_Click", ex)
        End Try
    End Sub

    Private Sub cboDocumento_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDocumento.SelectedIndexChanged
        Me.oDocumento = New Class_CatDocumentos(Me.cboDocumento.SelectedValue.ToString)
        Me.Inicializa()
        Me.Cambia_Estado(enumEstados.NUEVO)

        'If Me.oDocumento.SOLICITA_CUENTA_ORIGEN_RECURSOS = True Then
        '    Me.txtCuentaContableOrigenRecursos.Visible = True : Me.lblCuentaContableOrigenRecursos.Visible = True : Me.lblDisplayCuentaContableOrigenRecursos.Visible = True
        '    'Me.txtCuentaBancaria.Visible = False : Me.lblCuentaBancaria.Visible = False : Me.lblDisplayCuentaBancaria.Visible = False
        '    Me.txtCuentaBancaria.Enabled = False : Me.lblCuentaBancaria.Enabled = False : Me.lblDisplayCuentaBancaria.Enabled = False

        '    Me.txtCuentaBancaria.Text = "0" '0=Cuenta protegida para estos casos donde no aplica una cuenta bancaria
        '    TxtCuentaBancaria_KeyDown(sender, New KeyEventArgs(Keys.Return))
        'Else
        '    Me.txtCuentaContableOrigenRecursos.Visible = False : Me.lblCuentaContableOrigenRecursos.Visible = False : Me.lblDisplayCuentaContableOrigenRecursos.Visible = False
        '    'Me.txtCuentaBancaria.Visible = True : Me.lblCuentaBancaria.Visible = True : Me.lblDisplayCuentaBancaria.Visible = True
        '    Me.txtCuentaBancaria.Enabled = True : Me.lblCuentaBancaria.Enabled = True : Me.lblDisplayCuentaBancaria.Enabled = True
        'End If
    End Sub

    Private Sub Grid2_KeyDown(ByVal Sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Grid2.KeyDown
        Me.GestionaGrid(e)
    End Sub

    Private Sub TxtCuentaBancaria_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCuentaBancaria.KeyDown
        Dim oCuentaBancaria As Class_CatCuentasBancarias

        Try
            Select Case e.KeyCode
                Case Keys.F6
busqueda_Visual:
                    oCuentaBancaria = New Class_CatCuentasBancarias
                    Dim sIdCodigoBanco As String = oCuentaBancaria.BusquedaVisual_PorDescripcionSoloActivos

                    If txtLEN(sIdCodigoBanco) = True Then
                        Me.txtCuentaBancaria.Text = sIdCodigoBanco
                        GoTo enter : Exit Sub
                    End If

                Case Keys.Return
                    If txtLEN(Me.txtCuentaBancaria.Text) = False Then
                        Me.lblCuentaBancaria.Text = ""
                        Me.lblNombreMonedaOrigen.Text = ""
                        GoTo busqueda_Visual : Exit Sub
                    End If
enter:
                    oCuentaBancaria = New Class_CatCuentasBancarias(Me.txtCuentaBancaria.Text)

                    If oCuentaBancaria.Existe = False Then
                        GoTo busqueda_Visual : Exit Sub
                    End If

                    Me.txtCuentaBancaria.Text = oCuentaBancaria.ID_CUENTA_BANCARIA
                    Me.lblCuentaBancaria.Text = oCuentaBancaria.NOMBRE_CUENTA_BANCARIA
                    Me.lblNombreMonedaOrigen.Text = oCuentaBancaria.NOMBRE_MONEDA
                    If oCuentaBancaria.CODIGO_MONEDA <> "1" Then '1=pesos
                        Me.cboMoneda.SelectedValue = 2 'USD 'Nota, aqui es SelectedValue y no SelectedIndex
                    Else 'MXN
                        Me.cboMoneda.SelectedValue = 1 'MXN
                    End If

                    Me.txtCuentaContableOrigenRecursos.Text = oCuentaBancaria.CUENTA_CONTABLE_PESOS
                    Dim oCuentaContable As New Class_CatCuentas(Me.txtCuentaContableOrigenRecursos.Text)
                    If oCuentaContable.EXISTE = True Then
                        Me.lblCuentaContableOrigenRecursos.Text = oCuentaContable.NOMBRE_CUENTA
                    End If
                    oCuentaContable = Nothing

                    Me.GeneraFolio()

                Case Keys.Escape
                    Me.cboDocumento.Focus()
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
                        Me.Consultar()
                        Me.dtFecha.Focus()
                    Else
                        Me.GeneraFolio()
                    End If

            End Select
        Catch ex As Exception
            HandleError(Me.Name, "TxtFolio_KeyDown", ex)
        End Try
    End Sub

    Private Sub TxtCodigoProveedor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodigoProveedor.KeyDown
        Dim oProveedores As Class_CatProveedores, sCodigoProveedor As String = ""
        Try
            Select Case e.KeyCode
                Case Keys.F6
                    Select Case Me.ModoPago
                        Case enumModoPago.PROVEEDOR
buscar_proveedor:
                            oProveedores = New Class_CatProveedores
                            sCodigoProveedor = oProveedores.BusquedaVisual_PorDescripcion()
                            If txtLEN(sCodigoProveedor) = True Then
                                Me.TxtCodigoProveedor.Text = sCodigoProveedor
                                Me.LblProveedor.Text = ""
                            End If

                        Case enumModoPago.ACREEDOR
buscar_acreedor:
                            oProveedores = New Class_CatProveedores
                            sCodigoProveedor = oProveedores.BusquedaVisual_PorDescripcion_TiposCuentasBancarias
                            If txtLEN(sCodigoProveedor) = True Then
                                Me.TxtCodigoProveedor.Text = sCodigoProveedor
                                Me.LblProveedor.Text = ""
                            End If
                    End Select

                Case Keys.Enter

                    Select Case Me.ModoPago
                        Case enumModoPago.PROVEEDOR
                            If txtLEN(Me.TxtCodigoProveedor.Text) = False Then
                                Me.LblProveedor.Text = ""
                                Me.TxtCodigoProveedor.Focus()
                                GoTo buscar_proveedor : Exit Sub
                            End If

                            oProveedores = New Class_CatProveedores(Me.TxtCodigoProveedor.Text)
                            If oProveedores.Existe = False Then
                                Me.LblProveedor.Text = ""
                                Me.TxtCodigoProveedor.Focus()
                                GoTo buscar_proveedor : Exit Sub
                            End If

                            Me.LblProveedor.Text = oProveedores.Nombre_Proveedor

                            If txtLEN(oProveedores.CUENTA_CONTABLE) = False Then
                                MsgBox("El proveedor/cuenta destino no tiene cuenta contable asiginda, favor de asignarle una.", MsgBoxStyle.Exclamation, Me.Text)
                                Exit Sub
                            End If

                            If Me.ValidaProveedor() = False Then
                                Exit Sub
                            End If

                            Me.CargaComprasConSaldo()
                            Me.cboTipoPago.Focus()

                        Case enumModoPago.ACREEDOR
                            If txtLEN(Me.TxtCodigoProveedor.Text) = False Then
                                Me.LblProveedor.Text = ""
                                Me.TxtCodigoProveedor.Focus()
                                GoTo buscar_acreedor : Exit Sub
                            End If

                            oProveedores = New Class_CatProveedores(Me.TxtCodigoProveedor.Text)
                            If oProveedores.Existe = False Then
                                Me.LblProveedor.Text = ""
                                Me.TxtCodigoProveedor.Focus()
                                GoTo buscar_acreedor : Exit Sub
                            End If

                            Me.LblProveedor.Text = oProveedores.Nombre_Proveedor

                            If Me.ValidaProveedor() = False Then
                                Exit Sub
                            End If

                            'Esto va aquí porque si ponen un proveedor de pagos(no traspasos) va fallar
                            Me.lblNombreMonedaDestino.Text = oProveedores.CuentaBancaria.NOMBRE_MONEDA

                            Me.TxtImporte.Focus()
                    End Select

                Case Keys.F4
                    Dim Child As New Catalogo_Proveedores()
                    Child.tsbNuevo.PerformClick()
                    Child.ShowDialog()
                    Child.Dispose()
            End Select

        Catch ex As Exception
            HandleError(Me.Name, "TxtCodigoProveedor_KeyDown", ex)
        Finally
            oProveedores = Nothing
        End Try
    End Sub


    Private Sub TxtImporte_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtImporte.KeyDown
        Try
            If e.KeyCode = Keys.Return Then
                If valorNumerico(Me.TxtImporte.Text) > 0 Then
                    Me.TxtImporte.Text = FormatImporteContable(CDbl(Me.TxtImporte.Text))
                    'If Me.ckbDolares.Checked = True Then
                    If Me.cboMoneda.SelectedValue = 2 Then
                        Me.txtTipoCambio.Focus()
                        Me.CalculaImporteDolares()
                        'If txtLEN(Me.TxtImporte.Text) = True And valorNumerico(Me.TxtImporte.Text) > 0 Then
                        '    Me.txtTipoCambio.Text = valorNumerico(Me.txtTipoCambio.Text).ToString
                        '    Me.txtTipoCambio.Text = Redondear(valorNumerico(Me.txtTipoCambio.Text), 4).ToString
                        '    Me.txtImporteDolares.Text = (valorNumerico(Me.TxtImporte.Text) / valorNumerico(Me.txtTipoCambio.Text)).ToString
                        '    Me.txtImporteDolares.Text = valorNumerico(Me.txtImporteDolares.Text).ToString
                        '    Me.txtImporteDolares.Text = Redondear(valorNumerico(Me.txtImporteDolares.Text), 2).ToString
                        'Else
                        '    Me.txtTipoCambio.Text = valorNumerico(Me.txtTipoCambio.Text).ToString
                        '    Me.txtTipoCambio.Text = Redondear(valorNumerico(Me.txtTipoCambio.Text), 4).ToString
                        '    Me.txtImporteDolares.Text = "0"
                        '    Me.txtImporteDolares.Text = valorNumerico(Me.txtImporteDolares.Text).ToString
                        '    Me.txtImporteDolares.Text = Redondear(valorNumerico(Me.txtImporteDolares.Text), 2).ToString
                        'End If
                    Else
                        SendKeys.Send("{TAB}")
                    End If
                End If
            End If
        Catch ex As Exception
            HandleError(Me.Name, "TxtImporte_KeyDown", ex)
        End Try
    End Sub

    Private Sub txtTipoCambio_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTipoCambio.KeyDown
        Try
            If e.KeyCode = Keys.Return Then
                If valorNumerico(Me.txtTipoCambio.Text) < 0 Or valorNumerico(Me.txtTipoCambio.Text) > 25 Then
                    MsgBox("Tipo de cambio incorrecto", MsgBoxStyle.Information, "Validación de tipo de cambio")
                    Exit Sub
                Else
                    Me.CalculaImporteDolares()
                End If

                If Me.ModoPago = enumModoPago.PROVEEDOR Then
                    Me.TxtCodigoProveedor.Focus()
                Else
                    Me.TxtConcepto.Focus()
                End If
            End If
        Catch ex As Exception
            HandleError(Me.Name, "txtTipoCambio_KeyDown", ex)
        End Try
    End Sub

    Private Sub TxtConcepto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtConcepto.KeyDown
        Try
            If Me.ModoPago = enumModoPago.PROVEEDOR Then
                If e.KeyCode = Keys.Return Then
                    Me.Grid1.Cell(1, Me.iGyPagoMXN).SetFocus()
                End If
            Else
                If e.KeyCode = Keys.Return Then
                    If Me.CkbPagoFleteEmbarques.Checked = True Then
                        Me.Grid2.Cell(1, Me.iGyFolioEmbarque).SetFocus()
                    Else
                        Me.tsbGrabar.PerformClick()
                    End If
                End If
            End If
        Catch ex As Exception
            HandleError(Me.Name, "TxtConcepto_KeyDown", ex)
        End Try
    End Sub

    Private Sub LblPoliza_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LblPoliza.LinkClicked
        Dim Child As New Frm_Contabilidad_Captura_Polizas()
        Child.FolioPolizaConsultaExterior = Me.LblPoliza.Text
        Child.ShowDialog()
        Child.Dispose()
        Me.Consultar()
    End Sub

    Private Sub Grid_CellChanging(ByVal Sender As Object, ByVal e As FlexCell.Grid.CellChangingEventArgs) Handles Grid1.CellChanging
        Try
            Dim Columna As Integer = e.Col, Renglon As Integer = e.Row
            Dim dPago As Double, dPagoImpuesto As Double, dTipoCambioCO As Double, dImpuesto As Decimal, dTotalMXN As Decimal

            If Me.ModoPago = enumModoPago.PROVEEDOR Then
                If e.Col = Me.iGySeleccion And e.Row > 0 Then
                    If Me.Grid1.Cell(Renglon, Me.iGySeleccion).Text = "1" And Me.ClickSinEjecutar = False Then
                        dPago = valorNumerico(Me.Grid1.Cell(Renglon, Me.iGySaldoMXN).Text)
                        'dPagoImpuesto = valorNumerico(Me.Grid1.Cell(Renglon, Me.iGySaldoImpuesto).Text)
                        dImpuesto = valorNumerico(Me.Grid1.Cell(Renglon, Me.iGyImpuestoMXN).Text)
                        dTotalMXN = valorNumerico(Me.Grid1.Cell(Renglon, Me.iGyTotalMXN).Text)
                        If dPago > 0 Then
                            Me.ClickSinEjecutar = True

                            'If valorNumerico(Me.Grid1.Cell(Renglon, Me.iGyRetencion).Text) > 0 Then
                            '    Me.Grid1.Cell(Renglon, Me.iGyPagoMXP).Text = dPago.ToString '- valorNumerico(Me.Grid1.Cell(Renglon, Me.iGyRetencion).Text)
                            '    Me.Grid1.Cell(Renglon, Me.iGyPagarImpuesto).Text = valorNumerico(Me.Grid1.Cell(Renglon, Me.iGySaldoImpuesto).Text)
                            'Else
                            '    Me.Grid1.Cell(Renglon, Me.iGyPagoMXP).Text = dPago.ToString
                            '    Me.Grid1.Cell(Renglon, Me.iGyPagarImpuesto).Text = dPagoImpuesto
                            'End If

                            dPagoImpuesto = RedondearD((dPago / dTotalMXN) * dImpuesto, 2)

                            Me.Grid1.Cell(Renglon, Me.iGyPagoMXN).Text = dPago.ToString
                            Me.Grid1.Cell(Renglon, Me.iGyPagarImpuesto).Text = dPagoImpuesto

                            dTipoCambioCO = valorNumerico(Me.Grid1.Cell(Renglon, Me.iGyTipoCambio).Text)

                            If dTipoCambioCO > 0 Then
                                Me.Grid1.Cell(Renglon, Me.iGyPagoUSD).Text = Redondear(dPago / dTipoCambioCO, 2) 'En base al tipo de cambio de la compra
                            End If

                            Me.ClickSinEjecutar = False
                        End If
                    Else
                        Me.Grid1.Cell(Renglon, Me.iGyPagoMXN).Text = "0"
                        Me.Grid1.Cell(Renglon, Me.iGyPagoUSD).Text = "0"
                        Me.Grid1.Cell(Renglon, Me.iGyPagarImpuesto).Text = "0"
                    End If
                End If

                Me.Totales()
            Else
                If e.Col = Me.iGySeleccionFlete And e.Row > 0 Then
                    If Me.Grid2.Cell(Renglon, Me.iGySeleccionFlete).Text = "1" And Me.ClickSinEjecutar = False Then
                        dPago = valorNumerico(Me.Grid2.Cell(Renglon, Me.iGySaldoFlete).Text)
                        If dPago > 0 Then
                            Me.ClickSinEjecutar = True
                            Me.Grid2.Cell(Renglon, Me.iGyPagoFlete).Text = dPago.ToString
                            Me.ClickSinEjecutar = False
                        End If
                    Else
                        Me.Grid2.Cell(Renglon, Me.iGyPagoFlete).Text = "0"
                    End If
                End If
                Me.Totales()
            End If

        Catch ex As Exception
            HandleError(Me.Name, "Grid_CellChanging", ex)
        End Try
    End Sub

    Private Sub Grid1_KeyDown(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Grid1.KeyDown
        Try
            Dim Columna As Integer = Me.Grid1.Selection.FirstCol, Renglon As Integer = Me.Grid1.Selection.FirstRow
            Dim StrCod As String = Me.Grid1.Cell(Renglon, Columna).Text, dTipoCambioCO As Decimal = 0, dTipoCambioPago As Decimal = 0

            Dim dPagoMXN As Decimal = 0, dTotalMXN As Decimal = 0, dImpuestoMXN As Decimal = 0, dIvaPagoMXN As Decimal = 0, sMonedaCompra As String = ""
            Dim dPagoUSD As Decimal = 0, dTotalUSD As Decimal = 0, dImpuestoUSD As Decimal = 0

            Select Case e.KeyCode
                Case Keys.Enter
                    dTipoCambioPago = valorNumericoD(Me.txtTipoCambio.Text)

                    Select Case Columna
                        'Case 1, 2, 3, 4, 5, 6
                        '    Me.Grid1.Cell(Renglon, Columna).SetFocus()
                        'Case 6
                        '    Me.Grid1.Cell(Renglon, 6).SetFocus()

                        Case Me.iGyPagoMXN
                            dImpuestoMXN = valorNumericoD(Me.Grid1.Cell(Renglon, Me.iGyImpuestoMXN).Text)
                            dTotalMXN = valorNumericoD(Me.Grid1.Cell(Renglon, Me.iGyTotalMXN).Text)
                            dPagoMXN = valorNumerico(Me.Grid1.Cell(Renglon, Me.iGyPagoMXN).Text)
                            dTipoCambioCO = valorNumerico(Me.Grid1.Cell(Renglon, Me.iGyTipoCambio).Text)

                            If dPagoMXN = 0 Then
                                Me.Grid1.Cell(Renglon, Me.iGyPagoUSD).Text = "0"
                            ElseIf dPagoMXN > 0 And txtLEN(Me.Grid1.Cell(Renglon, Me.iGyFolio).Text) = True Then
                                If dPagoMXN > valorNumerico(Me.Grid1.Cell(Renglon, Me.iGySaldoMXN).Text) And Me.Grid1.Locked = False Then
                                    MsgBox("El pago en el renglón: " & Renglon & " es mayor al saldo del documento favor de revisar.", MsgBoxStyle.Exclamation, "Validación de Importes de CXP")
                                    Me.Grid1.Cell(Renglon, Me.iGyPagoMXN).SetFocus()
                                    Return
                                End If

                                dIvaPagoMXN = RedondearD((dPagoMXN / dTotalMXN) * dImpuestoMXN, 2)
                                Me.Grid1.Cell(Renglon, Me.iGyPagarImpuesto).Text = dIvaPagoMXN.ToString

                                If dTipoCambioCO > 0 Then
                                    Me.Grid1.Cell(Renglon, Me.iGyPagoUSD).Text = Redondear(dPagoMXN / dTipoCambioCO, 2) 'En base al tipo de cambio de la compra
                                End If

                            ElseIf dPagoMXN > 0 And Me.Grid1.Rows = Renglon Then
                                Me.Grid1.Rows = Me.Grid1.Rows + 1
                            End If

                        Case Me.iGyPagoUSD
                            sMonedaCompra = Me.Grid1.Cell(Renglon, Me.iGyMoneda).Text
                            dImpuestoUSD = valorNumericoD(Me.Grid1.Cell(Renglon, Me.iGyImpuestoUSD).Text)
                            dTotalUSD = valorNumericoD(Me.Grid1.Cell(Renglon, Me.iGyTotalUSD).Text)
                            dTipoCambioCO = valorNumerico(Me.Grid1.Cell(Renglon, Me.iGyTipoCambio).Text)
                            dPagoUSD = valorNumericoD(Me.Grid1.Cell(Renglon, Me.iGyPagoUSD).Text)

                            'Sólo si están pagando usd y tecleando usd hacemos el cálculo sugerido(el usuario podrá editarlo)
                            'Si estuvieran pagando el pesos el cálculo ya se hizo al teclear los MXN y dar enter.
                            If Me.cboMoneda.Text = "DOLARES" Then
                                If sMonedaCompra = "USD" Then
                                    dIvaPagoMXN = RedondearD((dPagoUSD / dTotalUSD) * dImpuestoUSD, 2) * dTipoCambioPago
                                    Me.Grid1.Cell(Renglon, Me.iGyPagarImpuesto).Text = dIvaPagoMXN.ToString
                                Else
                                    MsgBox("Esta pagando en USD una venta en MXN, de momento usted calcule y capture manualmente el IVA a pagar en MXN por favor y comuníque a sistemas cómo hace el cálculo.", MsgBoxStyle.Exclamation, Me.Text)
                                End If
                            End If

                    End Select

                    Me.Totales()

            End Select

        Catch ex As Exception
            HandleError(Me.Name, "Grid1_KeyDown", ex)
        End Try
    End Sub

    'Private Sub ckbDolares_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckbDolares.CheckedChanged
    '    If Me.ckbDolares.Checked = True Then
    '        Me.txtTipoCambio.Enabled = True
    '        'Me.txtTotalDolares.Enabled = True
    '        Me.lblTipoCambio.Enabled = True
    '        Me.lblTotalDolares.Enabled = True
    '        Me.txtTipoCambio.Focus()
    '    Else
    '        Me.txtTipoCambio.Enabled = False : Me.txtTipoCambio.Text = ""
    '        'Me.txtTotalDolares.Enabled = False
    '        Me.lblTipoCambio.Enabled = False
    '        Me.lblTotalDolares.Enabled = False : Me.txtImporteDolares.Text = ""
    '    End If
    'End Sub

    Private Sub CkbPagoFleteEmbarques_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CkbPagoFleteEmbarques.CheckedChanged
        If Me.ModoPago = enumModoPago.ACREEDOR Then
            If Me.CkbPagoFleteEmbarques.Checked = True Then
                'Me.Size = New Size(1100, 580)
                Me.gbFleteEmbarques.Visible = True
                Me.Grid2.Visible = True
                Me.gbFleteEmbarques.BringToFront()
                Me.gbCompras.SendToBack()
                'Me.gbFleteEmbarques.Location = New Point(6, 253)
                Me.gbFleteEmbarques.Location = New Point(10, 335)
                Me.gbFleteEmbarques.Height = 185
                Me.Grid2.Height = 160
                Me.TxtImporte.Enabled = False
                Me.Grid2.Cell(1, Me.iGyFolioEmbarque).SetFocus()
            Else
                'Me.Size = New Size(1100, 313)
                Me.gbFleteEmbarques.Visible = False
                Me.Grid2.Visible = False
                Me.InicializaGrid2()
                Me.TxtImporte.Enabled = True
                Me.TxtConcepto.Focus()
            End If
        End If
    End Sub

    Private Sub dtFecha_ValueChanged(sender As Object, e As EventArgs) Handles dtFecha.ValueChanged
        Me.ObtieneTipoCambioDia()
    End Sub

    Private Sub cboMoneda_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboMoneda.SelectedValueChanged
        If Me.cboMoneda.SelectedValue = 2 Then
            If Empresa_Sistema.TIPO_CAMBIO_POR_DIA = True Then
                Me.ObtieneTipoCambioDia()
            End If
        End If
    End Sub

    Private Sub txtCuentaContableOrigenRecursos_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCuentaContableOrigenRecursos.KeyDown
        Dim oCuenta As New Class_CatCuentas

        Try
            Select Case e.KeyCode
                Case Keys.F6
busqueda_visual:
                    oCuenta = New Class_CatCuentas
                    Dim sCuenta As String = oCuenta.BusquedaVisual_PorCodigoFiltrandoTipoOperacion()

                    If txtLEN(sCuenta) = True Then
                        Me.txtCuentaContableOrigenRecursos.Text = sCuenta
                        GoTo enter : Return
                    End If

                Case Keys.F7
                    oCuenta = New Class_CatCuentas
                    Dim sCuenta As String = oCuenta.BusquedaVisual_PorNombreFiltrandoTipoOperacion()

                    If txtLEN(sCuenta) = True Then
                        Me.txtCuentaContableOrigenRecursos.Text = sCuenta
                        GoTo enter : Return
                    End If

                Case Keys.Return
                    If txtLEN(Me.txtCuentaContableOrigenRecursos.Text) = False Then
                        Me.lblCuentaContableOrigenRecursos.Text = ""
                        GoTo busqueda_visual : Return
                    End If
enter:
                    oCuenta = New Class_CatCuentas(Me.txtCuentaContableOrigenRecursos.Text)

                    If oCuenta.EXISTE = False Then
                        GoTo busqueda_visual : Return
                    ElseIf oCuenta.ESMAYOR = "1" Then
                        MsgBox("La cuenta contable indicada es de mayor, debe seleccionar cuenta de operación.", MsgBoxStyle.Exclamation, Me.Text)
                        Me.txtCuentaContableOrigenRecursos.Text = ""
                        Me.lblCuentaContableOrigenRecursos.Text = ""
                        GoTo busqueda_visual : Return
                    End If

                    Me.txtCuentaContableOrigenRecursos.Text = oCuenta.CUENTA_CONTABLE
                    Me.lblCuentaContableOrigenRecursos.Text = oCuenta.NOMBRE_CUENTA

                    Me.dtFecha.Focus()
            End Select

        Catch ex As Exception
            HandleError(Me.Name, "txtCuentaContableOrigenRecursos_KeyDown", ex)
        End Try
    End Sub

#End Region

#Region "Eventos Genericos"
    Private Sub txt_Enter(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim oTexBox As TextBox = CType(sender, TextBox)
        oTexBox.SelectAll()
    End Sub

    Private Sub txt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboDocumento.KeyDown, dtFecha.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtNumerosEnterosKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCuentaBancaria.KeyPress, txtCuentaContableOrigenRecursos.KeyPress
        txtSoloNumerosEnteros(e)
        txtNoBeep(e)
    End Sub

    Private Sub txtNumerosDecimalKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtImporte.KeyPress, txtTipoCambio.KeyPress
        Dim txt As TextBox = CType(sender, TextBox)
        txtSoloNumerosDecimales(e, txt.Text)
        txtNoBeep(e)
    End Sub

    Private Sub txtTextoKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboDocumento.KeyPress, TxtFolio.KeyPress,
                                dtFecha.KeyPress, TxtCodigoProveedor.KeyPress, TxtConcepto.KeyPress
        txtNoBeep(e)
    End Sub
#End Region

#Region "Métodos y procedimientos"
    Private Sub Inicializa()
        Try
            Me.TxtFolio.Text = ""
            Me.LblStatus.Text = "NUEVO"
            Me.LblPoliza.Text = ""

            Me.txtTipoCambio.Text = ""
            Me.dtFecha.Value = Date.Now
            Me.ObtieneTipoCambioDia()

            Me.TxtCodigoProveedor.Text = ""
            Me.LblProveedor.Text = ""
            Me.lblNombreMonedaDestino.Text = ""
            Me.TxtImporte.Text = ""
            Me.TxtConcepto.Text = ""

            Me.ckbAbonoCuentaBeneficiario.Checked = True
            Me.txtImporteDolares.Text = ""
            Me.CboFacturasRecibidas.SelectedValue = "N"

            If txtLEN(Empresa_Sistema.CODIGO_CONCEPTO_PAGO_CXP_DEFAULT) = True Then
                Me.cboTipoPago.SelectedValue = Empresa_Sistema.CODIGO_CONCEPTO_PAGO_CXP_DEFAULT
            Else
                Me.cboTipoPago.SelectedIndex = -1
            End If

            Me.txtCuentaContableOrigenRecursos.Text = ""
            Me.lblCuentaContableOrigenRecursos.Text = ""

            'No se inicializa nada que tenga que ver con la cuenta bancaria para simular que se va seguir usando la misma
            'Me.ckbDolares.Checked = False
            'Me.CkbPagoFleteEmbarques.Checked = True
            'Me.TxtCuentaBancaria.Text = ""
            'Me.LblCuentaBancaria.Text = ""
            'Me.lblNombreMonedaOrigen.Text = ""

            Me.InicializaGrid()

            If Me.ModoPago = enumModoPago.ACREEDOR Then
                Me.InicializaGrid2()
                Me.cboTipoPago.SelectedValue = 26 '26=T. INTERBANCARIAS
            End If

        Catch ex As Exception
            HandleError(Me.Name, "Inicializa", ex)
        End Try
    End Sub

    Private Sub InicializaGrid()
        Try
            Me.Grid1.AutoRedraw = False
            Me.Grid1.DataSource = Nothing
            FG_Grid_Limpiar(Grid1)

            'Creamos el Grid
            Me.Grid1.Rows = 2
            Me.Grid1.Cols = 21
            Me.Grid1.DisplayRowNumber = True

            Me.FormateaGrid()
        Catch ex As Exception
            HandleError(Me.Name, "InicializaGrid", ex)
        Finally
            Me.Grid1.AutoRedraw = True
            Me.Grid1.Refresh()
        End Try
    End Sub

    Private Sub InicializaGrid2()
        Try
            Me.Grid2.DataSource = Nothing
            FG_Grid_Limpiar(Grid2)

            'Creamos el Grid
            Me.Grid2.Rows = 2
            Me.Grid2.Cols = 7
            Me.Grid2.DisplayRowNumber = True

            Me.FormateaGridFletes()
        Catch ex As Exception
            HandleError(Me.Name, "InicializaGrid2", ex)
        End Try
    End Sub

    Private Sub FormateaGrid()
        Try
            With Me.Grid1
                .AutoRedraw = False

                .Column(Me.iGyFacturaProveedor).Width = 60
                .Column(Me.iGyFecha).Width = 70
                .Column(Me.iGyFolio).Width = 70
                .Column(Me.iGyMoneda).Width = 30
                .Column(Me.iGyTipoCambio).Width = 50
                .Column(Me.iGyTotalUSD).Width = 70
                .Column(Me.iGySaldoUSD).Width = 70
                .Column(Me.iGyImpuestoUSD).Width = 70
                .Column(Me.iGyConcepto).Width = 100 '200
                .Column(Me.iGyTotalMXN).Width = 80
                .Column(Me.iGySaldoMXN).Width = 80
                .Column(Me.iGySaldoImpuesto).Visible = False '.Column(Me.iGySaldoImpuesto).Width = 60
                .Column(Me.iGyImpuestoMXN).Width = 70
                .Column(Me.iGyRetencion).Width = 60
                .Column(Me.iGyPagarImpuesto).Width = 80
                .Column(Me.iGyPagoMXN).Width = 80
                .Column(Me.iGyPagoUSD).Width = 70
                .Column(Me.iGySeleccion).Width = 55
                .Column(Me.iGyCodigoDocumento).Visible = False
                .Column(Me.iGyAutorizado).Width = 60

                '.Column(Me.iGyPagoDlls).Width = 70
                '.Column(Me.iGyTotalDlls).Width = 80
                '.Column(Me.iGySaldoDlls).Width = 80
                '.Column(Me.iGyDiferencia).Width = 80

                .Cell(0, Me.iGyFacturaProveedor).Text = "Fac. Prov."
                .Cell(0, Me.iGyFecha).Text = "Fecha"
                .Cell(0, Me.iGyFolio).Text = "Folio"
                .Cell(0, Me.iGyMoneda).Text = "Mon"
                .Cell(0, Me.iGyTipoCambio).Text = "TpCam"
                .Cell(0, Me.iGyTotalUSD).Text = "Total USD"
                .Cell(0, Me.iGySaldoUSD).Text = "Saldo USD"
                .Cell(0, Me.iGyImpuestoUSD).Text = "IVA USD"
                .Cell(0, Me.iGyConcepto).Text = "Concepto"
                .Cell(0, Me.iGyTotalMXN).Text = "Total MXN"
                .Cell(0, Me.iGySaldoMXN).Text = "Saldo MXN"
                .Cell(0, Me.iGySaldoImpuesto).Text = "Saldo Imp."
                .Cell(0, Me.iGyImpuestoMXN).Text = "IVA MXN"
                .Cell(0, Me.iGyRetencion).Text = "Retencion"
                .Cell(0, Me.iGyPagarImpuesto).Text = "IVA Pagar MXN"
                .Cell(0, Me.iGyPagoMXN).Text = "Pagar MXN"
                .Cell(0, Me.iGyPagoUSD).Text = "Pagar USD"
                .Cell(0, Me.iGySeleccion).Text = "Selección"
                .Cell(0, Me.iGyCodigoDocumento).Text = "CodigoDocumento "
                .Cell(0, Me.iGyAutorizado).Text = "Autorizado"

                '.Cell(0, Me.iGyTotalDlls).Text = "Total Dlls"
                '.Cell(0, Me.iGySaldoDlls).Text = "Saldo Dlls"
                '.Cell(0, Me.iGyPagoDlls).Text = "Pagar Dlls"
                '.Cell(0, Me.iGyDiferencia).Text = "Diferencia"

                .Column(Me.iGyFecha).CellType = FlexCell.CellTypeEnum.DateTime
                .Column(Me.iGyFecha).FormatString = "dd-MMM-yy"

                .Column(Me.iGyTipoCambio).FormatString = "###,###,##0.0000"
                .Column(Me.iGyTipoCambio).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyTipoCambio).DecimalLength = 4
                .Column(Me.iGyTipoCambio).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGyTotalUSD).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
                .Column(Me.iGyTotalUSD).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyTotalUSD).DecimalLength = 2
                .Column(Me.iGyTotalUSD).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGySaldoUSD).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
                .Column(Me.iGySaldoUSD).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGySaldoUSD).DecimalLength = 2
                .Column(Me.iGySaldoUSD).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGyImpuestoUSD).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
                .Column(Me.iGyImpuestoUSD).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyImpuestoUSD).DecimalLength = 2
                .Column(Me.iGyImpuestoUSD).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGyTotalMXN).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
                .Column(Me.iGyTotalMXN).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyTotalMXN).DecimalLength = 2
                .Column(Me.iGyTotalMXN).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGySaldoMXN).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
                .Column(Me.iGySaldoMXN).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGySaldoMXN).DecimalLength = 2
                .Column(Me.iGySaldoMXN).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGySaldoImpuesto).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
                .Column(Me.iGySaldoImpuesto).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGySaldoImpuesto).DecimalLength = 2
                .Column(Me.iGySaldoImpuesto).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGyImpuestoMXN).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
                .Column(Me.iGyImpuestoMXN).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyImpuestoMXN).DecimalLength = 2
                .Column(Me.iGyImpuestoMXN).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGyRetencion).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
                .Column(Me.iGyRetencion).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyRetencion).DecimalLength = 2
                .Column(Me.iGyRetencion).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGyPagarImpuesto).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
                .Column(Me.iGyPagarImpuesto).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyPagarImpuesto).DecimalLength = 2
                .Column(Me.iGyPagarImpuesto).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGyPagoMXN).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
                .Column(Me.iGyPagoMXN).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyPagoMXN).DecimalLength = 2
                .Column(Me.iGyPagoMXN).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGyPagoUSD).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
                .Column(Me.iGyPagoUSD).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyPagoUSD).DecimalLength = 2
                .Column(Me.iGyPagoUSD).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGyAutorizado).CellType = FlexCell.CellTypeEnum.DateTime
                .Column(Me.iGyAutorizado).FormatString = "dd-MMM-yy"
                .Column(Me.iGyAutorizado).Visible = False

                .Column(Me.iGySeleccion).CellType = FlexCell.CellTypeEnum.CheckBox

                '.Column(Me.iGyPagoDlls).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
                '.Column(Me.iGyPagoDlls).Mask = FlexCell.MaskEnum.Numeric
                '.Column(Me.iGyPagoDlls).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
                '.Column(Me.iGyPagoDlls).Alignment = FlexCell.AlignmentEnum.RightCenter

                '.Column(Me.iGyTotalDlls).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
                '.Column(Me.iGyTotalDlls).Mask = FlexCell.MaskEnum.Numeric
                '.Column(Me.iGyTotalDlls).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
                '.Column(Me.iGyTotalDlls).Alignment = FlexCell.AlignmentEnum.RightCenter

                '.Column(Me.iGySaldoDlls).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
                '.Column(Me.iGySaldoDlls).Mask = FlexCell.MaskEnum.Numeric
                '.Column(Me.iGySaldoDlls).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
                '.Column(Me.iGySaldoDlls).Alignment = FlexCell.AlignmentEnum.RightCenter

                '.Column(Me.iGyDiferencia).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
                '.Column(Me.iGyDiferencia).Mask = FlexCell.MaskEnum.Numeric
                '.Column(Me.iGyDiferencia).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
                '.Column(Me.iGyDiferencia).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGyFacturaProveedor).Locked = True
                .Column(Me.iGyFecha).Locked = True
                .Column(Me.iGyFolio).Locked = True
                .Column(Me.iGyMoneda).Locked = True
                .Column(Me.iGyTipoCambio).Locked = True
                .Column(Me.iGyTotalUSD).Locked = True
                .Column(Me.iGySaldoUSD).Locked = True
                .Column(Me.iGyImpuestoUSD).Locked = True
                .Column(Me.iGyConcepto).Locked = True
                .Column(Me.iGyTotalMXN).Locked = True
                .Column(Me.iGySaldoMXN).Locked = True
                .Column(Me.iGySaldoImpuesto).Locked = True
                .Column(Me.iGyImpuestoMXN).Locked = True

                '.Column(Me.iGyPagoDlls).Locked = True
                '.Column(Me.iGyTotalDlls).Locked = True
                '.Column(Me.iGySaldoDlls).Locked = True
                '.Column(Me.iGyDiferencia).Locked = True

                '.Column(Me.iGyTotalDlls).Visible = False
                '.Column(Me.iGySaldoDlls).Visible = False
                '.Column(Me.iGyPagoDlls).Visible = False
                '.Column(Me.iGyDiferencia).Visible = False

                'If Me.ModoPago = enumModoPago.PROVEEDOR Then
                '    .Column(Me.iGyAutorizado).Locked = True
                '    .Column(Me.iGyAutorizado).Visible = True
                'Else
                '    .Column(Me.iGyAutorizado).Locked = False
                '    .Column(Me.iGyAutorizado).Visible = False
                'End If
            End With

        Catch ex As Exception
            HandleError(Me.Name, "FormateaGrid", ex)
        Finally
            Me.Grid1.AutoRedraw = False
            Me.Grid1.Refresh()
        End Try
    End Sub

    Private Sub FormateaGridFletes()
        Try
            With Me.Grid2
                '.Column(Me.iGyFactura).Width = 130
                .Column(Me.iGyFolioEmbarque).Width = 130
                .Column(Me.iGyConceptoFlete).Width = 300
                .Column(Me.iGyTotalFlete).Width = 90
                .Column(Me.iGySaldoFlete).Width = 90
                .Column(Me.iGyPagoFlete).Width = 90
                .Column(Me.iGySeleccionFlete).Width = 70

                '.Cell(0, Me.iGyFactura).Text = "Folio Factura"
                .Cell(0, Me.iGyFolioEmbarque).Text = "Folio embarque"
                .Cell(0, Me.iGyConceptoFlete).Text = "Concepto"
                .Cell(0, Me.iGyTotalFlete).Text = "Total"
                .Cell(0, Me.iGySaldoFlete).Text = "Saldo"
                .Cell(0, Me.iGyPagoFlete).Text = "Pagar"
                .Cell(0, Me.iGySeleccionFlete).Text = "Seleccion"

                .Column(Me.iGyTotalFlete).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
                .Column(Me.iGyTotalFlete).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyTotalFlete).DecimalLength = 2
                .Column(Me.iGyTotalFlete).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGySaldoFlete).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
                .Column(Me.iGySaldoFlete).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGySaldoFlete).DecimalLength = 2
                .Column(Me.iGySaldoFlete).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGyPagoFlete).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
                .Column(Me.iGyPagoFlete).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyPagoFlete).DecimalLength = 2
                .Column(Me.iGyPagoFlete).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGySeleccionFlete).CellType = FlexCell.CellTypeEnum.CheckBox
                '.Column(Me.iGyCodigoDocumento).Visible = False

                '.Column(Me.iGyFactura).Locked = False
                .Column(Me.iGyFolioEmbarque).Locked = False
                .Column(Me.iGyConceptoFlete).Locked = True
                .Column(Me.iGyTotalFlete).Locked = True
                .Column(Me.iGySaldoFlete).Locked = True

                .Refresh()

            End With

        Catch ex As Exception
            HandleError(Me.Name, "FormateaGridFletes", ex)
        End Try
    End Sub

    Private Sub SetRowVisible(ByVal Row1 As Integer, ByVal Row2 As Integer, ByVal Value As Boolean)
        Try
            Dim i As Integer
            Me.Grid1.AutoRedraw = False
            For i = Row1 To Row2
                Me.Grid1.Row(i).Visible = Value
            Next
            Me.Grid1.AutoRedraw = True
            Me.Grid1.Refresh()
        Catch ex As Exception
            HandleError(Me.Name, "SetRowVisible", ex)
        End Try
    End Sub

    Private Sub Totales()
        Try
            If Me.LblStatus.Text = "NUEVO" And Me.ModoPago = enumModoPago.ACREEDOR Then ' And Me.CkbPagoFleteEmbarques.Checked = False Then
                Exit Sub
            ElseIf Me.ModoPago = enumModoPago.PROVEEDOR Then
                Me.TxtImporte.Text = FormatImporteContable(FG_Grid_SumaCol(Me.Grid1, CShort(Me.iGyPagoMXN))) 'Esté total ya consideró la retención en Gastos
            End If

            If Me.LblStatus.Text = "NUEVO" And Me.CkbPagoFleteEmbarques.Checked = True Then
                If Me.ModoPago = enumModoPago.ACREEDOR Then
                    Me.TxtImporte.Text = FormatImporteContable(FG_Grid_SumaCol(Me.Grid2, CShort(Me.iGyPagoFlete)))
                Else
                    Me.TxtImporte.Text = FormatImporteContable(FG_Grid_SumaCol(Me.Grid1, CShort(Me.iGyPagoMXN)))
                End If
            End If

            Me.CalculaImporteDolares()

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

    Private Sub CalculaImporteDolares()
        Dim dTipoCambio As Double, dTotalUSD As Double = 0, dTotalMXN As Double = 0
        Try
            dDiferenciaCambiaria = 0
            dTipoCambio = Redondear(valorNumerico(Me.txtTipoCambio.Text), 4).ToString()
            Select Case Me.ModoPago
                Case enumModoPago.PROVEEDOR
                    dTotalMXN = FG_Grid_SumaCol(Me.Grid1, CShort(Me.iGyPagoMXN))
                    If Me.lblNombreMonedaOrigen.Text = "PESOS" Then
                        dTotalUSD = FG_Grid_SumaCol(Me.Grid1, CShort(Me.iGyPagoUSD))
                        If dTotalUSD <> 0 Then
                            dDiferenciaCambiaria = Redondear(Redondear(dTotalUSD * dTipoCambio) - dTotalMXN)
                        End If
                    Else
                        ' si la moneda origen no es pesos el total de lo pagado en cualquier moneda en el grid saldra en usd
                        dTotalUSD = FG_Grid_Suma_Calculo_Usd(Me.Grid1, iGyPagoMXN, iGyPagoUSD, dTipoCambio)
                        dDiferenciaCambiaria = Redondear(Redondear(dTotalUSD * dTipoCambio) - dTotalMXN)
                    End If


                    Me.txtImporteDolares.Text = FormatImporteContable(dTotalUSD)

                Case enumModoPago.ACREEDOR
                    Me.txtTipoCambio.Text = Format(dTipoCambio, "###,##0.0000")
                    dTotalMXN = valorNumerico(Me.TxtImporte.Text)

                    If dTotalMXN > 0 Then
                        dTotalUSD = Redondear(dTotalMXN / dTipoCambio, 2)
                    End If
                    Me.txtImporteDolares.Text = FormatImporteContable(dTotalUSD)
            End Select

        Catch ex As Exception
            HandleError(Me.Name, "CalculaImporteDolares", ex)
        End Try
    End Sub

    Private Function GestionaGrabar() As Boolean
        Dim bResultado As Boolean = False

        Try
            If MsgBox("Deseas grabar el documento " & Me.cboDocumento.Text & " con el folio : " & Me.TxtFolio.Text & "?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Grabar") = MsgBoxResult.No Then
                Return False
            End If

            If Me.Validar() = False Then
                Return False
            End If

            'If Me.ValidaPrePoliza() = False Then
            '    Exit Function
            'End If

            'If Me.Grabar() = True Then
            '    'sobreescibir texbox folio y folio oringen de oFormaPoliza, aplicar la poliza, y actualizar folio_poliza en bancos global
            '    Me.oFormaPoliza.TxtFolio.Text = Me.TxtFolio.Text
            '    Me.oFormaPoliza.lblFolioOrigen.Text = Me.TxtFolio.Text
            '    Me.oPolizaGlobal.CODIGO_LISTA_FACTURAS_RECIBIDAS = Me.oFormaPoliza.CboFacturasRecibidas.SelectedValue.ToString
            '    If Me.oFormaPoliza.Aplicar(False, False) = True Then
            '        If Me.oBancosCXP.ActualizaFolioPoliza() = True Then
            '            If Me.oPolizaGlobal.AsignaFacturasPoliza() = True Then
            '                MsgBox("Movimiento grabado satisfactoriamente.", MsgBoxStyle.Information, Me.Text)
            '            End If
            '        Else
            '            MsgBox("Movimiento grabado sin relacionar el folio de la póliza.", MsgBoxStyle.Information, Me.Text)
            '        End If
            '        bResultado = True
            '    Else
            '        MsgBox("Movimiento grabado sin relacionar el folio de la póliza.", MsgBoxStyle.Information, Me.Text)
            '    End If
            'End If

            If Me.Grabar() = True Then
                Me.oPolizaGlobal = New Class_Contabilidad_Poliza_Global(Me.TxtFolio.Text)
                Me.oPolizaGlobal.CODIGO_LISTA_FACTURAS_RECIBIDAS = "N"

                'se elimina por que ahora se hace desde MP_CONTABILIDAD_ASIENTO_REPETITIVO_BANCOS_PAGOS
                'If Me.oBancosCXP.ActualizaFolioPoliza() = True Then
                '    If Me.oPolizaGlobal.AsignaFacturasPoliza() = True Then
                '        MsgBox("Movimiento grabado satisfactoriamente.", MsgBoxStyle.Information, Me.Text)
                '    End If
                'Else
                '    MsgBox("Movimiento grabado sin relacionar el folio de la póliza.", MsgBoxStyle.Information, Me.Text)
                'End If

                bResultado = True
            End If

        Catch ex As Exception
            HandleError(Me.Name, "GestionaGrabar", ex)
        End Try

        Return bResultado
    End Function

    Private Function Grabar() As Boolean
        Dim bResultado As Boolean = False, bResultadoParcial As Boolean = False
        Dim i As Integer
        Dim oProveedor As Class_CatProveedores

        Try
            oProveedor = New Class_CatProveedores(Me.TxtCodigoProveedor.Text)

            Me.GeneraFolio()

            Me.oBancosCXP = New Class_Bancos_CXP
            'If Me.oBancosCXP.Existe = True Then
            '    Exit Function
            'End If

            Dim oCuentaOrigen As New Class_CatCuentasBancarias(Me.txtCuentaBancaria.Text)

            With oBancosCXP
                .FOLIO_BANCO = Me.TxtFolio.Text
                .ID_CUENTA_BANCARIA = CInt(Me.txtCuentaBancaria.Text)
                ' Si la diferencia es positia hubo perdida y se le suma a los pesos
                .TOTAL = valorNumerico(Me.TxtImporte.Text) + dDiferenciaCambiaria
                .CODIGO_DOCUMENTO = (Me.cboDocumento.SelectedValue.ToString)
                .FECHA = Me.dtFecha.Value
                .CONCEPTO1 = Me.TxtConcepto.Text.ToUpper
                .CODIGO_PLAZA = Usuario.Codigo_Plaza
                .ABONO_CUENTA_BENEFICIARIO = Convert.ToInt32(Me.ckbAbonoCuentaBeneficiario.Checked).ToString
                .TIPO_DE_CAMBIO = valorNumerico(Me.txtTipoCambio.Text)
                .TOTAL_DOLARES = valorNumerico(Me.txtImporteDolares.Text)

                If Me.ModoPago = enumModoPago.PROVEEDOR Then
                    .CODIGO_CONCEPTO_PAGO_CXP = Me.cboTipoPago.SelectedValue.ToString
                Else
                    .CODIGO_CONCEPTO_PAGO_CXP = 1
                End If

                If oCuentaOrigen.ES_CUENTA_FISCAL = True Then
                    .ES_PAGO_VENTAS_NO_FISCALES = False 'Es fiscal(Va negado para los que si son fiscales)
                Else
                    .ES_PAGO_VENTAS_NO_FISCALES = True 'Es no fiscal
                End If

                'If Me.oDocumento.SOLICITA_CUENTA_ORIGEN_RECURSOS = True Then
                .CUENTA_CONTABLE_ORIGEN_RECURSOS = Me.txtCuentaContableOrigenRecursos.Text
                'Else
                '.CUENTA_CONTABLE_ORIGEN_RECURSOS = ""
                'End If

                If .Inserta_Global = False Then
                    Return False
                End If

                Me.TxtFolio.Text = .FOLIO_BANCO
            End With

            Dim oCuentaBancaria As New Class_CatCuentasBancarias(Me.txtCuentaBancaria.Text)

            Me.oCxpAfectaDocumentos = New Class_CXP_Afecta_Documentos
            If Me.ModoPago = enumModoPago.PROVEEDOR Then
                For i = 1 To Me.Grid1.Rows - 1
                    If valorNumerico(Me.Grid1.Cell(i, Me.iGyPagoMXN).Text) > 0 Then
                        With oCxpAfectaDocumentos
                            .FOLIO_CXP = "" 'Me.TxtFolio.Text
                            .CODIGO_PROVEEDOR = Me.TxtCodigoProveedor.Text
                            .FECHA = Me.dtFecha.Value
                            .FOLIO_REFERENCIA = Me.Grid1.Cell(i, Me.iGyFolio).Text 'folio de la compra
                            .FOLIO_REFERENCIA_USUARIO = Me.Grid1.Cell(i, Me.iGyFacturaProveedor).Text 'Folio factura proveedor de la compra, no tenemos
                            .CONCEPTO1 = Me.TxtConcepto.Text
                            .CONCEPTO2 = ""
                            .CODIGO_PLAZA = Usuario.Codigo_Plaza
                            .TOTAL = valorNumerico(Me.Grid1.Cell(i, Me.iGyPagoMXN).Text)
                            .RETENCION_IVA = valorNumerico(Me.Grid1.Cell(i, Me.iGyRetencion).Text)
                            .TIPO_DE_CAMBIO = valorNumerico(Me.txtTipoCambio.Text)
                            .FOLIO_BANCO = Me.TxtFolio.Text 'Se tiene que poner el del texbox porque se regreso el folio al Inserta_Global
                            .MODULO = "CXP"
                            .CODIGO_MONEDA = oCuentaBancaria.CODIGO_MONEDA
                            .TOTAL_USD = valorNumerico(Me.Grid1.Cell(i, Me.iGyPagoUSD).Text)
                            .IMPUESTO = valorNumerico(Me.Grid1.Cell(i, Me.iGyPagarImpuesto).Text)

                            bResultadoParcial = .InsertarPagosProveedoresAcreedores(Class_CXP_Afecta_Documentos.enumModoPago.PROVEEDOR)
                        End With
                    End If
                Next i
            Else
                If Me.CkbPagoFleteEmbarques.Checked = True Then
                    For i = 1 To Me.Grid2.Rows - 1
                        If valorNumerico(Me.Grid2.Cell(i, Me.iGyPagoFlete).Text) > 0 Then
                            With oCxpAfectaDocumentos
                                .FOLIO_CXP = "" 'Me.TxtFolio.Text
                                .CODIGO_PROVEEDOR = Me.TxtCodigoProveedor.Text
                                .FECHA = Me.dtFecha.Value
                                .FOLIO_REFERENCIA = Me.Grid2.Cell(i, Me.iGyFolioEmbarque).Text 'folio de la compra
                                .FOLIO_REFERENCIA_USUARIO = "" 'Me.Grid2.Cell(i, Me.iGyFactura).Text 'Folio factura proveedor de la compra, no tenemos
                                .CONCEPTO1 = Me.TxtConcepto.Text
                                .CONCEPTO2 = ""
                                .CODIGO_PLAZA = Usuario.Codigo_Plaza
                                .TOTAL = valorNumerico(Me.Grid2.Cell(i, Me.iGyPagoFlete).Text)
                                .TIPO_DE_CAMBIO = valorNumerico(Me.txtTipoCambio.Text)
                                .FOLIO_BANCO = Me.TxtFolio.Text 'Se tiene que poner el del texbox porque se regreso el folio al Inserta_Global
                                .MODULO = "CXP"
                                .CODIGO_MONEDA = oCuentaBancaria.CODIGO_MONEDA
                                '.TOTAL_USD = 0 valorNumerico(Me.Grid1.Cell(i, Me.iGyPagoUSD).Text), DE MOMENTO NO SE USA ESTE LLAMADO DE TODAS FORMAS 01JUL17

                                bResultadoParcial = .InsertarPagosProveedoresAcreedores(Class_CXP_Afecta_Documentos.enumModoPago.ACREEDOR)

                                .AplicaRelacionBancosCXPFletes(Me.Grid2.Cell(i, Me.iGyFolioEmbarque).Text, valorNumerico(Me.Grid2.Cell(i, Me.iGyPagoFlete).Text))
                            End With
                        End If
                    Next i
                Else
                    With oCxpAfectaDocumentos
                        .FOLIO_CXP = "" 'Me.TxtFolio.Text
                        .CODIGO_PROVEEDOR = Me.TxtCodigoProveedor.Text
                        .FECHA = Me.dtFecha.Value
                        .FOLIO_REFERENCIA = ""
                        .FOLIO_REFERENCIA_USUARIO = ""
                        .CONCEPTO1 = Me.TxtConcepto.Text
                        .CONCEPTO2 = ""
                        .CODIGO_PLAZA = Usuario.Codigo_Plaza
                        .TOTAL = valorNumerico(Me.TxtImporte.Text)
                        .TIPO_DE_CAMBIO = valorNumerico(Me.txtTipoCambio.Text)
                        .FOLIO_BANCO = Me.TxtFolio.Text
                        .MODULO = "CXP"
                        .CODIGO_MONEDA = oCuentaBancaria.CODIGO_MONEDA
                        .TOTAL_USD = valorNumerico(Me.txtImporteDolares.Text)

                        bResultadoParcial = .InsertarPagosProveedoresAcreedores(Class_CXP_Afecta_Documentos.enumModoPago.ACREEDOR)
                    End With
                End If
            End If

            If bResultadoParcial = False Then
                Return False
            End If

            bResultado = True

            If oCuentaOrigen.ES_CUENTA_FISCAL = True Then
                Me.oBancosCXP.GeneraPoliza(Me.CboFacturasRecibidas.SelectedValue.ToString)
            End If

        Catch ex As Exception
            HandleError(Me.Name, "Grabar", ex)
        Finally
            'Me.oBancosCXP = Nothing no hay porque borrarla
            Me.oCxpAfectaDocumentos = Nothing
        End Try

        Return bResultado
    End Function

    Private Function Validar() As Boolean
        Dim bResultado As Boolean = False
        Dim sProcedure As String = "Validar"
        Dim oCuentaOrigen As Class_CatCuentasBancarias
        Dim oProveedor As Class_CatProveedores

        Try
            If Plaza.ValidarPeriodoTrabajo(Me.dtFecha.Value) = False Then
                Return False
            End If

            If Usuario.ValidaPermisoUsuarioDocumentoSinAfectacionInventarios(Me.cboDocumento.SelectedValue.ToString) = False Then
                MsgBox("El usuario " & Usuario.Nombre_Usuario & " no tiene permiso para realizar el movimiento.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            If txtLEN(Me.txtCuentaBancaria.Text) = False Then
                MsgBox("Asígne la cuenta origen.", MsgBoxStyle.Exclamation, sProcedure)
                Me.txtCuentaBancaria.Focus()
                Return False
            End If

            If txtLEN(Me.TxtCodigoProveedor.Text) = False Then
                MsgBox("Asígne el proveedor/cuenta destino.", MsgBoxStyle.Exclamation, sProcedure)
                Me.TxtCodigoProveedor.Focus()
                Return False
            End If

            If Me.ValidaProveedor() = False Then
                Return False
            End If

            oCuentaOrigen = New Class_CatCuentasBancarias(Me.txtCuentaBancaria.Text)
            If oCuentaOrigen.Existe = False Then
                MsgBox("La cuenta origen no existe.", MsgBoxStyle.Exclamation, sProcedure)
                Me.txtCuentaBancaria.Focus()
                Return False
            End If

            'If Me.oDocumento.SOLICITA_CUENTA_ORIGEN_RECURSOS = True Then
            If oCuentaOrigen.ES_CUENTA_FISCAL = True Then
                If txtLEN(Me.txtCuentaContableOrigenRecursos.Text) = False Then
                    MsgBox("Asígne la cuenta contable origen de los recursos.", MsgBoxStyle.Exclamation, Me.Text)
                    Return False
                End If
                Dim oCuentaContable As New Class_CatCuentas(Me.txtCuentaContableOrigenRecursos.Text)
                If oCuentaContable.EXISTE = False Then
                    MsgBox("La cuenta contable origen de los recursos no existe.", MsgBoxStyle.Exclamation, Me.Text)
                    Return False
                ElseIf oCuentaContable.ESMAYOR = "1" Then
                    MsgBox("La cuenta contable origen de los recursos es una cuenta de mayor, cambiela por una cuenta de operaciones.", MsgBoxStyle.Exclamation, Me.Text)
                    Return False
                End If
            End If

            oProveedor = New Class_CatProveedores(Me.TxtCodigoProveedor.Text)
            If oProveedor.Existe = False Then
                MsgBox("El proveedor/cuenta destino no existe o esta dado de baja.", MsgBoxStyle.Exclamation, sProcedure)
                Me.LblProveedor.Text = ""
                Return False
            End If

            If txtLEN(oCuentaOrigen.CUENTA_CONTABLE_PESOS) = False Then
                MsgBox("La cuenta origen no tiene cuenta contable en MXP.", MsgBoxStyle.Exclamation, sProcedure)
                Me.txtCuentaBancaria.Focus()
                Return False
            End If

            If txtLEN(oProveedor.CUENTA_CONTABLE) = False Then
                MsgBox("El proveedor/cuenta destino no tiene cuenta contable en MXP.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            If Me.ModoPago = enumModoPago.PROVEEDOR Then
                If valorNumerico(Me.TxtImporte.Text) <= 0 Then
                    MsgBox("No asignó los documentos a pagar. El total a pagar debe ser mayor que cero.", MsgBoxStyle.Exclamation, Me.Nombre_Modulo)
                    Return False
                End If

                Dim i As Integer, oCompra As Class_Compras_Global
                For i = 1 To Grid1.Rows - 1
                    If valorNumerico(Me.Grid1.Cell(i, Me.iGyPagoMXN).Text) > 0 And txtLEN(Me.Grid1.Cell(i, Me.iGyFolio).Text) = True Then
                        If valorNumerico(Me.Grid1.Cell(i, Me.iGyPagoMXN).Text) > valorNumerico(Me.Grid1.Cell(i, Me.iGySaldoMXN).Text) Then
                            MsgBox("El pago en el renglón: " & i & " es mayor al saldo del documento favor de revisar.", MsgBoxStyle.Exclamation, "Validación de Importes de CXP")
                            Return False
                        End If

                        'Nota aunque sabemos que el nombre correcto de la moneda en pesos es MXN, en el sistema en la tabla se graba como MXP
                        If Me.Grid1.Cell(i, Me.iGyMoneda).Text <> "MXP" AndAlso txtLEN(oProveedor.CUENTA_CONTABLE_DOLARES) = False Then
                            MsgBox("El proveedor/cuenta destino no tiene cuenta contable en moneda extranjera.", MsgBoxStyle.Exclamation, sProcedure)
                            Return False
                        End If

                        oCompra = New Class_Compras_Global(Me.Grid1.Cell(i, Me.iGyFolio).Text, Me.Grid1.Cell(i, Me.iGyCodigoDocumento).Text)

                        If oCuentaOrigen.ES_CUENTA_FISCAL <> oCompra.ES_FISCAL Then
                            If oCuentaOrigen.ES_CUENTA_FISCAL = True Then
                                MsgBox("Esta cuenta bancaria es ""fiscal"" y la compra " & oCompra.FOLIO_COMPRA & " es no fiscal, no puede hacer el pago.", MsgBoxStyle.Exclamation, sProcedure)
                            Else
                                MsgBox("Esta cuenta bancaria es ""no fiscal"" y la compra " & oCompra.FOLIO_COMPRA & " es fiscal, no puede hacer el pago.", MsgBoxStyle.Exclamation, sProcedure)
                            End If

                            Return False
                        End If

                    End If
                Next i
            End If

            If Me.ModoPago = enumModoPago.ACREEDOR And Me.CkbPagoFleteEmbarques.Checked = True Then
                If valorNumerico(Me.TxtImporte.Text) <= 0 Then
                    MsgBox("No asignó los documentos a pagar. El total a pagar debe ser mayor que cero.", MsgBoxStyle.Exclamation, Me.Nombre_Modulo)
                    Return False
                End If

                If Me.ValidarEmbarques() = False Then
                    Return False
                End If
            End If

            If Me.lblNombreMonedaOrigen.Text = "DOLARES" Or Me.lblNombreMonedaDestino.Text = "DOLARES" Then
                Me.CalculaImporteDolares()
                If valorNumerico(Me.txtTipoCambio.Text) <= 0 Then
                    MsgBox("Asígne el tipo de cambio.", MsgBoxStyle.Exclamation, sProcedure)
                    Me.txtTipoCambio.Focus()
                    Return False
                End If

                If oCuentaOrigen.CODIGO_MONEDA <> 1 Then
                    If txtLEN(oCuentaOrigen.CUENTA_CONTABLE_DOLARES) = False Then
                        MsgBox("La cuenta origen no tiene cuenta contable en moneda extranjera.", MsgBoxStyle.Exclamation, sProcedure)
                        Return False
                    End If
                End If
            End If

            If valorNumerico(Me.txtImporteDolares.Text) > 0 Then
                If valorNumerico(Me.txtTipoCambio.Text) <= 0 Then
                    MsgBox("Asígne el tipo de cambio.", MsgBoxStyle.Exclamation, sProcedure)
                    Me.txtTipoCambio.Focus()
                    Return False
                End If
            End If

            If Me.ModoPago = enumModoPago.PROVEEDOR Then
                If Me.cboTipoPago.SelectedIndex = -1 Then
                    MsgBox("Asígne el tipo de pago.", MsgBoxStyle.Exclamation, sProcedure)
                    Me.cboTipoPago.Focus()
                    Return False
                End If
            End If

            bResultado = True

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    Private Sub Imprimir()
        Dim Rpt As New ReportDocument
        Dim oReporte As Class_Reporte
        Try
            oReporte = New Class_Reporte(Me.oBancosCXP.Nombre_Formato, Rpt, False)
            If Not oReporte.RptCargado Then
                Exit Sub
            End If
            Rpt.SetParameterValue(0, Me.TxtFolio.Text)

            Dim frm As New Reporte(Rpt)
            frm.CRViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            frm.Show()
        Catch ex As Exception
            HandleError(Me.Name, "Imprimir", ex)
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
            With Me.cboDocumento
                .DisplayMember = "NOMBRE_TIPO_DOCUMENTO"
                .ValueMember = "CODIGO_DOCUMENTO"
                Dim dView As New Data.DataView(oElementos.ObtenerCodigosDocumentos("BAN", Usuario.Codigo_Plaza.ToString, " ESTATUS_DOCUMENTO='A' AND AFECTA_CXP=1"))
                dView.Sort = "NOMBRE_TIPO_DOCUMENTO"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedIndex = 0
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarDocumentos", ex)
        End Try
    End Sub

    Private Sub DesplegarDocumentosProveedor()
        Try
            Dim oElementos As New Class_Contabilidad_ListaFacturasRecibidas
            With Me.CboFacturasRecibidas
                .DisplayMember = "NOMBRE_LISTA_FACTURAS_RECIBIDAS"
                .ValueMember = "CODIGO_LISTA_FACTURAS_RECIBIDAS"
                Dim dView As New Data.DataView(oElementos.ListaFacturasRecibidas())
                dView.Sort = "NOMBRE_LISTA_FACTURAS_RECIBIDAS"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedIndex = 0
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarDocumentosProveedor", ex)
        End Try
    End Sub

    Private Sub DesplegarTiposPago()
        Try
            Dim oElementos As New Class_CXPCatalogoConceptosPagos
            With Me.cboTipoPago
                .DisplayMember = "NOMBRE_CONCEPTO_PAGO_CXP"
                .ValueMember = "CODIGO_CONCEPTO_PAGO_CXP"
                Dim dView As New Data.DataView(oElementos.ObtenerElementos)
                dView.Sort = "NOMBRE_CONCEPTO_PAGO_CXP"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedIndex = -1
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarTiposPago", ex)
        End Try
    End Sub

    Private Sub DesplegarMonedas()
        Try
            Dim oMoneda As New Class_CatMonedas
            Dim dTable As New DataTable
            With Me.cboMoneda
                .DisplayMember = "NOMBRE"
                .ValueMember = "CODIGO_MONEDA"
                dTable = oMoneda.ObtenerElementos
                dTable.Rows(2).Delete() 'Quita Euros del DataTable
                .DataSource = dTable
                .SelectedValue = 1 '1=MXN,2=USD
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarMonedas", ex)
        End Try
    End Sub

    'Private Function ValidaPrePoliza() As Boolean
    '    Dim bResultado As Boolean = False

    '    Dim oCuentaBancaria As Class_CatCuentasBancarias
    '    Dim oProveedor As Class_CatProveedores
    '    Dim oContaCuenta As Class_CatCuentas

    '    Try
    '        'If ExisteDocumento(Me.TxtFolio.Text) = True Then
    '        ' MsgBox("El folio del documento : " & Me.CmbDocumento.Text & " ya existe, verifíquelo.", MsgBoxStyle.Exclamation, "Contabilizar")
    '        ' Exit Function
    '        ' End If

    '        'Me.GeneraFolio() 'No hay que generar folio nuevo porque se manda el folio del documento

    '        oCuentaBancaria = New Class_CatCuentasBancarias(CInt(Me.TxtCuentaBancaria.Text))
    '        oProveedor = New Class_CatProveedores(Me.TxtCodigoProveedor.Text)

    '        Me.oFormaPoliza = New Frm_Contabilidad_Captura_Polizas

    '        Me.oFormaPoliza.StartPosition = FormStartPosition.CenterScreen

    '        Me.oFormaPoliza.ChildParaGrabar = True
    '        Me.oFormaPoliza.CodigoDocumentoParaGrabar = "E"
    '        Me.oFormaPoliza.CodigoDocumentoProveedorParaGrabar = Me.CboFacturasRecibidas.SelectedValue.ToString

    '        'If Me.ModoPago = enumModoPago.ACREEDOR Then
    '        Me.oFormaPoliza.EsAcreedor = True
    '        Me.oFormaPoliza.ImporteAcreedor = valorNumerico(Me.TxtImporte.Text)
    '        Me.oFormaPoliza.CuentaBancaria = CInt(Me.TxtCuentaBancaria.Text)
    '        'End If

    '        Me.oFormaPoliza.DtpFecha.Value = Me.dtFecha.Value
    '        Me.oFormaPoliza.TxtTotalCargos.Text = Me.TxtImporte.Text
    '        Me.oFormaPoliza.TxtTotalAbonos.Text = Me.TxtImporte.Text
    '        Me.oFormaPoliza.TxtConcepto1.Text = Me.TxtConcepto.Text
    '        Me.oFormaPoliza.lblFolioOrigen.Text = Me.TxtFolio.Text
    '        Me.oFormaPoliza.TxtFolio.Text = Me.TxtFolio.Text

    '        Me.oFormaPoliza.Grid1.Rows = 2
    '        Me.oFormaPoliza.Grid1.Cols = 9

    '        Me.oFormaPoliza.Grid1.Rows = Me.oFormaPoliza.Grid1.Rows + 1

    '        Me.oFormaPoliza.Grid1.Cell(1, 1).Text = oProveedor.CUENTA_CONTABLE.ToString
    '        Me.oFormaPoliza.Grid1.Cell(1, 2).Text = oProveedor.Nombre_Proveedor
    '        Me.oFormaPoliza.Grid1.Cell(1, 3).Text = Me.oFormaPoliza.TxtConcepto1.Text
    '        Me.oFormaPoliza.Grid1.Cell(1, 4).Text = "D"
    '        If valorNumerico(Me.txtRetencion.Text) > 0 Then
    '            Me.oFormaPoliza.Grid1.Cell(1, 5).Text = (valorNumerico(Me.TxtImporte.Text) + valorNumerico(Me.txtRetencion.Text)).ToString
    '        Else
    '            Me.oFormaPoliza.Grid1.Cell(1, 5).Text = Me.TxtImporte.Text
    '        End If
    '        Me.oFormaPoliza.Grid1.Cell(1, 6).Text = "0"

    '        Me.oFormaPoliza.Grid1.Rows = Me.oFormaPoliza.Grid1.Rows + 1
    '        Me.oFormaPoliza.Grid1.Cell(2, 1).Text = oCuentaBancaria.CUENTA_CONTABLE_PESOS
    '        Me.oFormaPoliza.Grid1.Cell(2, 2).Text = oCuentaBancaria.NOMBRE_CUENTA_BANCARIA
    '        Me.oFormaPoliza.Grid1.Cell(2, 3).Text = oProveedor.Nombre_Proveedor
    '        Me.oFormaPoliza.Grid1.Cell(2, 4).Text = "D"
    '        Me.oFormaPoliza.Grid1.Cell(2, 5).Text = "0"
    '        Me.oFormaPoliza.Grid1.Cell(2, 6).Text = Me.TxtImporte.Text

    '        If Me.ModoPago = enumModoPago.PROVEEDOR Then
    '            Me.AgregaPrepolizaIVAAcreditable()
    '        End If

    '        If valorNumerico(Me.txtRetencion.Text) > 0 Then
    '            'Me.oFormaPoliza.Grid1.Rows = Me.oFormaPoliza.Grid1.Rows + 1
    '            Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 1).Text = "20400001"
    '            Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 2).Text = "IVA RETENIDO"
    '            Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 3).Text = Me.oFormaPoliza.TxtConcepto1.Text
    '            Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 4).Text = "D"
    '            Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 5).Text = "0"
    '            Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 6).Text = Me.txtRetencion.Text
    '            Me.oFormaPoliza.Grid1.Rows = Me.oFormaPoliza.Grid1.Rows + 1
    '        End If

    '        If Me.ckbDolares.Checked = True Then

    '            If Me.ckbVentasDolares.Checked = False Then

    '                'Me.oFormaPoliza.Grid1.Rows = Me.oFormaPoliza.Grid1.Rows + 1
    '                Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 1).Text = oProveedor.CUENTA_CONTABLE_DOLARES
    '                Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 2).Text = oProveedor.Nombre_Proveedor
    '                Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 3).Text = Me.oFormaPoliza.TxtConcepto1.Text
    '                Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 4).Text = "A"
    '                Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 5).Text = Me.txtImporteDolares.Text
    '                Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 6).Text = "0"


    '                oContaCuenta = New Class_CatCuentas(Empresa_Sistema.CUENTA_CONTABLE_PROVEEDORES_CONTRA_CUENTA_DOLARES)
    '                Me.oFormaPoliza.Grid1.Rows = Me.oFormaPoliza.Grid1.Rows + 1
    '                Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 1).Text = oContaCuenta.CUENTA_CONTABLE
    '                Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 2).Text = oContaCuenta.NOMBRE_CUENTA
    '                Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 3).Text = Me.oFormaPoliza.TxtConcepto1.Text
    '                Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 4).Text = oContaCuenta.NATURALEZA_CONTABLE
    '                Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 5).Text = "0"
    '                Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 6).Text = Me.txtImporteDolares.Text

    '                Me.oFormaPoliza.Grid1.Rows = Me.oFormaPoliza.Grid1.Rows + 1
    '            End If

    '            oContaCuenta = New Class_CatCuentas(Empresa_Sistema.CUENTA_CONTABLE_CONTRA_CUENTA_DOLARES)

    '            Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 1).Text = oContaCuenta.CUENTA_CONTABLE
    '            Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 2).Text = oContaCuenta.NOMBRE_CUENTA
    '            Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 3).Text = Me.oFormaPoliza.TxtConcepto1.Text
    '            Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 4).Text = oContaCuenta.NATURALEZA_CONTABLE
    '            Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 5).Text = Me.txtImporteDolares.Text
    '            Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 6).Text = "0"

    '            Me.oFormaPoliza.Grid1.Rows = Me.oFormaPoliza.Grid1.Rows + 1
    '            Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 1).Text = oCuentaBancaria.CUENTA_CONTABLE_DOLARES
    '            Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 2).Text = oCuentaBancaria.NOMBRE_CUENTA_BANCARIA
    '            Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 3).Text = oProveedor.Nombre_Proveedor
    '            Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 4).Text = "D"
    '            Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 5).Text = "0"
    '            Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 6).Text = Me.txtImporteDolares.Text

    '        End If

    '        Me.oFormaPoliza.lblEstatus.Text = "N"

    '        Me.oFormaPoliza.ShowDialog()

    '        bResultado = Me.oFormaPoliza.FormaValidaParaGrabarLlamadoExterior

    '        If Me.oFormaPoliza.RecalcularImporte = True Then
    '            Me.TxtImporte.Text = Me.oFormaPoliza.ImporteAcreedor.ToString
    '        End If

    '    Catch ex As Exception
    '        HandleError(Me.Text, "ValidaPrePoliza", ex)
    '    Finally
    '        oCuentaBancaria = Nothing
    '        oProveedor = Nothing
    '    End Try

    '    Return bResultado
    'End Function

    'Private Function AgregaPrepolizaIVAAcreditable() As Boolean
    '    Dim i As Integer, dPago As Double, sFolio As String, sCodigoDocumento As String ', dIvaImporte As Double
    '    Dim oCompra As Class_Compras_Global, dtImpuestosAbonos As New DataTable("tabla"), dtImpuestosCargos As New DataTable("tabla")
    '    Dim dA As SqlDataAdapter
    '    Try

    '        dtImpuestosCargos.Columns.Add("CUENTA_CONTABLE", GetType(String))
    '        dtImpuestosCargos.Columns.Add("NOMBRE_CUENTA", GetType(String))
    '        dtImpuestosCargos.Columns.Add("NATURALEZA", GetType(String))
    '        dtImpuestosCargos.Columns.Add("CARGO", GetType(Double))
    '        dtImpuestosCargos.Columns.Add("TIPO", GetType(String))
    '        dtImpuestosCargos.Columns.Add("PORCENTAJE", GetType(Double))

    '        dtImpuestosAbonos.Columns.Add("CUENTA_CONTABLE", GetType(String))
    '        dtImpuestosAbonos.Columns.Add("NOMBRE_CUENTA", GetType(String))
    '        dtImpuestosAbonos.Columns.Add("NATURALEZA", GetType(String))
    '        dtImpuestosAbonos.Columns.Add("ABONO", GetType(Double))
    '        dtImpuestosAbonos.Columns.Add("TIPO", GetType(String))
    '        dtImpuestosAbonos.Columns.Add("PORCENTAJE", GetType(Double))

    '        dA = New SqlDataAdapter("SELECT I.CUENTA_CONTABLE,C.NOMBRE_CUENTA,C.NATURALEZA_CONTABLE,0,0,I.TIPO,I.PORCENTAJE " & _
    '                                "FROM CON_IVA_ACREDITABLE_CATALOGO_CUENTAS I INNER JOIN CON_CAT_CUENTAS C ON(I.CUENTA_CONTABLE=C.CUENTA_CONTABLE) ORDER BY I.PORCENTAJE,I.TIPO", Empresa_Sistema.conexion)
    '        dA.Fill(dtImpuestosCargos)
    '        dA.Dispose()

    '        For i = 1 To Me.Grid1.Rows - 1
    '            sFolio = Me.Grid1.Cell(i, Me.iGyFolio).Text
    '            sCodigoDocumento = Me.Grid1.Cell(i, Me.iGyCodigoDocumento).Text
    '            dPago = valorNumerico(Me.Grid1.Cell(i, Me.iGyPagoMXP).Text)
    '            If txtLEN(sFolio) = True And dPago > 0 Then
    '                oCompra = New Class_Compras_Global(sFolio, sCodigoDocumento)
    '                If oCompra.SALDO_IMPUESTO > 0 AndAlso (dPago - oCompra.SALDO) = 0 Then 'Si es el último pago(si quedará con saldo cero)
    '                    Dim dRowAbonoRenglon As DataRow
    '                    Dim dRowAbono() As Data.DataRow = dtImpuestosCargos.Select("PORCENTAJE=" & oCompra.IMPUESTO_PORCENTAJE & " AND TIPO='IVA_PENDIENTE_ACREDITAR'")
    '                    Dim dRowCargo() As Data.DataRow = dtImpuestosCargos.Select("PORCENTAJE=" & oCompra.IMPUESTO_PORCENTAJE & " AND TIPO='IVA_ACREDITABLE'")

    '                    'dIvaImporte = (dPago / oCompra.TOTAL) * oCompra.IMPUESTO_PORCENTAJE
    '                    'dIvaImporte = Redondear(dIvaImporte, Empresa_Sistema.DECIMALES_CONTABILIDAD)
    '                    'dRow(0)("ABONO") = valorNumerico(dRow(0)("ABONO").ToString) + dIvaImporte

    '                    dRowAbonoRenglon = dtImpuestosAbonos.NewRow

    '                    dRowAbonoRenglon("CUENTA_CONTABLE") = dRowAbono(0)("CUENTA_CONTABLE")
    '                    dRowAbonoRenglon("NOMBRE_CUENTA") = dRowAbono(0)("NOMBRE_CUENTA")
    '                    dRowAbonoRenglon("NATURALEZA") = dRowAbono(0)("NATURALEZA")
    '                    dRowAbonoRenglon("ABONO") = oCompra.SALDO_IMPUESTO
    '                    dRowAbonoRenglon("TIPO") = dRowAbono(0)("TIPO")
    '                    dRowAbonoRenglon("PORCENTAJE") = dRowAbono(0)("PORCENTAJE")

    '                    dtImpuestosAbonos.Rows.Add(dRowAbonoRenglon)

    '                    dRowCargo(0)("CARGO") = valorNumerico(dRowCargo(0)("CARGO").ToString) + oCompra.SALDO_IMPUESTO

    '                    dtImpuestosAbonos.AcceptChanges()
    '                    dtImpuestosCargos.AcceptChanges()

    '                End If
    '            End If
    '        Next

    '        Dim iRow As Integer = 3
    '        For Each dRow As DataRow In dtImpuestosAbonos.Rows
    '            Me.oFormaPoliza.Grid1.Rows += 1
    '            Me.oFormaPoliza.Grid1.Cell(iRow, 1).Text = dRow("CUENTA_CONTABLE").ToString
    '            Me.oFormaPoliza.Grid1.Cell(iRow, 2).Text = dRow("NOMBRE_CUENTA").ToString
    '            Me.oFormaPoliza.Grid1.Cell(iRow, 3).Text = Me.TxtConcepto.Text
    '            Me.oFormaPoliza.Grid1.Cell(iRow, 4).Text = dRow("NATURALEZA").ToString
    '            Me.oFormaPoliza.Grid1.Cell(iRow, 5).Text = "0"
    '            Me.oFormaPoliza.Grid1.Cell(iRow, 6).Text = dRow("ABONO").ToString
    '            iRow += 1
    '        Next

    '        If dtImpuestosAbonos.Rows.Count > 0 Then
    '            For Each dRow As DataRow In dtImpuestosCargos.Select("CARGO<>0")
    '                Me.oFormaPoliza.Grid1.Rows += 1
    '                Me.oFormaPoliza.Grid1.Cell(iRow, 1).Text = dRow("CUENTA_CONTABLE").ToString
    '                Me.oFormaPoliza.Grid1.Cell(iRow, 2).Text = dRow("NOMBRE_CUENTA").ToString
    '                Me.oFormaPoliza.Grid1.Cell(iRow, 3).Text = Me.TxtConcepto.Text
    '                Me.oFormaPoliza.Grid1.Cell(iRow, 4).Text = dRow("NATURALEZA").ToString
    '                Me.oFormaPoliza.Grid1.Cell(iRow, 5).Text = dRow("CARGO").ToString
    '                Me.oFormaPoliza.Grid1.Cell(iRow, 6).Text = "0"
    '                iRow += 1
    '            Next
    '        End If

    '    Catch ex As Exception
    '        HandleError(Me.Text, "AgregaPrepolizaIVAAcreditable", ex)
    '    End Try
    'End Function

    Private Function Consultar() As Boolean
        Dim bResultado As Boolean = False

        Dim sFolio As String = Me.TxtFolio.Text

        Try
            'Respaldamos la cuenta contable y su nombre porque se perderán en el inicializa
            Dim sCuentaContable As String = Me.txtCuentaContableOrigenRecursos.Text, sNombreCuentaContable As String = Me.lblCuentaContableOrigenRecursos.Text

            Me.Inicializa()

            'Reestablecemos los datos perdidos
            Me.txtCuentaContableOrigenRecursos.Text = sCuentaContable
            Me.lblCuentaContableOrigenRecursos.Text = sNombreCuentaContable

            Me.oBancosCXP = New Class_Bancos_CXP(sFolio)
            If txtLEN(Me.oBancosCXP.FOLIO_POLIZA) = True Then
                Me.oPolizaGlobal = New Class_Contabilidad_Poliza_Global(sFolio)
            End If

            If Me.oBancosCXP.Existe = False Then
                Me.GeneraFolio()
                Me.Cambia_Estado(enumEstados.NUEVO)
                Me.txtCuentaBancaria.Enabled = False
                Me.TxtFolio.Enabled = False
                Return False
            Else
                Me.TxtFolio.Text = Me.oBancosCXP.FOLIO_BANCO
                Me.txtCuentaBancaria.Enabled = False
                Me.txtCuentaContableOrigenRecursos.Enabled = False
                Me.TxtFolio.Enabled = False

                Me.cboDocumento.SelectedValue = oBancosCXP.CODIGO_DOCUMENTO
                Me.dtFecha.Value = oBancosCXP.FECHA
                Me.LblPoliza.Text = oBancosCXP.FOLIO_POLIZA
                Me.TxtConcepto.Text = oBancosCXP.CONCEPTO1

                Select Case oBancosCXP.ESTATUS
                    Case "A"
                        Me.LblStatus.Text = "APLICADO"
                    Case "C"
                        Me.LblStatus.Text = "CANCELADO"
                End Select

                Me.txtCuentaBancaria.Text = oBancosCXP.ID_CUENTA_BANCARIA.ToString
                Me.lblCuentaBancaria.Text = oBancosCXP.NOMBRE_CUENTA_BANCARIA
                Me.lblNombreMonedaOrigen.Text = oBancosCXP.NOMBRE_MONEDA

                Me.txtCuentaContableOrigenRecursos.Text = oBancosCXP.CUENTA_CONTABLE_ORIGEN_RECURSOS
                Me.lblCuentaContableOrigenRecursos.Text = oBancosCXP.NOMBRE_CUENTA_CONTABLE_ORIGEN_RECURSOS

                Dim oProveedor As New Class_CatProveedores(oBancosCXP.CODIGO_PROVEEDOR)

                Me.TxtCodigoProveedor.Text = oBancosCXP.CODIGO_PROVEEDOR
                Me.LblProveedor.Text = oProveedor.Nombre_Proveedor
                If Not (oProveedor.CuentaBancaria Is Nothing) Then
                    Me.lblNombreMonedaDestino.Text = oProveedor.CuentaBancaria.NOMBRE_MONEDA
                End If

                Me.ckbAbonoCuentaBeneficiario.Checked = CBool(Convert.ToInt32(Me.oBancosCXP.ABONO_CUENTA_BENEFICIARIO).ToString)

                'Esto debe ir antes de establecer el tpcambio porque al cambiar entre monedas pudiera cambiarse en automático al del dia seleccionado.
                If Me.oBancosCXP.CODIGO_MONEDA_SAT = "MXN" Then
                    Me.cboMoneda.SelectedValue = 1 '1=MXN
                Else
                    Me.cboMoneda.SelectedValue = 2 '2=USD
                End If

                Me.txtTipoCambio.Text = Format(oBancosCXP.TIPO_DE_CAMBIO, "###,##0.0000")
                Me.txtImporteDolares.Text = FormatImporteContable(oBancosCXP.TOTAL_DOLARES)

                Me.txtRetencion.Text = FormatImporteContable(oBancosCXP.RETENCION)
                Me.oBancosCXP.Consultar() 'No identificado porque esta consultado nuevamente porque ya consultó en Me.oBancosCXP = New Class_Bancos_CXP(sFolio), será porque se pierde/inicializa información al cambiar la moneda?

                If txtLEN(Me.oBancosCXP.FOLIO_POLIZA) = False Then
                    Me.CboFacturasRecibidas.SelectedValue = "N"
                Else
                    Me.CboFacturasRecibidas.SelectedValue = oPolizaGlobal.CODIGO_LISTA_FACTURAS_RECIBIDAS.ToString
                End If

                Me.cboTipoPago.SelectedValue = oBancosCXP.CODIGO_CONCEPTO_PAGO_CXP

                Me.tssElaboro.Text = "Elaboró : " & Me.oBancosCXP.NOMBRE_USUARIO_GRABO & " el " & Format(Me.oBancosCXP.FECHA_SERVIDOR, "dd-MMM-yyyy hh:mm tt")
                If Me.oBancosCXP.ESTATUS = "C" Then
                    Me.tssCancelo.Text = "Canceló : " & Me.oBancosCXP.NOMBRE_USUARIO_CANCELO & " el : " & Format(Me.oBancosCXP.FECHA_DE_CANCELACION_SERVIDOR, "dd-MMM-yyyy hh:mm tt")
                End If

                Me.Grid1.DataSource = Me.oBancosCXP.ObtenerDetalle
                Me.FormateaGrid()

                'Se quitó todo esto de momento porque no hay flete, ademas para que consulte el renglón aunque sea un traspaso.
                'If Me.ModoPago = enumModoPago.PROVEEDOR Then
                '    Me.Grid1.DataSource = Me.oBancosCXP.ObtenerDetalle
                '    Me.FormateaGrid()
                'Else
                '    If oBancosCXP.ConsultarBancosCXPFletes(Me.oBancosCXP.FOLIO_BANCO.ToString) = True Then
                '        Me.CkbPagoFleteEmbarques.Checked = True
                '        Me.CkbPagoFleteEmbarques.Enabled = False

                '        'Me.Grid2.DataSource = Me.oBancosCXP.ObtenerDetalleBancosCXPFletes

                '        Dim dTabla As DataTable ', dTabla1 As DataTable
                '        'dTabla = Me.oBancosCXP.ObtenerDetalle '.Rows.Count
                '        dTabla = Me.oBancosCXP.ObtenerDetalleBancosCXPFletes
                '        'Me.Grid2.Rows = 1
                '        'For Each daRow As DataRow In dTabla.Rows
                '        '    Me.Grid2.AddItem(daRow(0).ToString & Chr(9) & daRow(4).ToString & Chr(9))
                '        'Next
                '        Me.Grid2.Rows = 1
                '        For Each dRow As DataRow In dTabla.Rows
                '            Me.Grid2.AddItem(dRow(0).ToString & Chr(9) & dRow(1).ToString & Chr(9) & dRow(2).ToString & Chr(9) & dRow(3).ToString & Chr(9) & dRow(4).ToString & Chr(9))
                '        Next

                '        Me.FormateaGridFletes()
                '    Else
                '        Me.CkbPagoFleteEmbarques.Checked = False
                '    End If
                'End If

                If oBancosCXP.RETENCION > 0 Then
                    Me.TxtImporte.Text = FormatImporteContable(oBancosCXP.TOTAL - oBancosCXP.RETENCION)
                Else
                    Me.TxtImporte.Text = FormatImporteContable(oBancosCXP.TOTAL)
                End If

                bResultado = True

                Me.GestionaCambioEstado()
            End If

        Catch ex As Exception
            HandleError(Me.Name, "Consultar", ex)
        End Try

        Return bResultado
    End Function

    Private Function CargaComprasConSaldo() As Boolean
        Dim bResultado As Boolean = False
        Dim dTabla As DataTable
        Dim oCompras As New Class_Compras_Global

        Try
            dTabla = oBancosCXP.CargaComprasProveedorConSaldo(Me.TxtCodigoProveedor.Text)

            Me.Grid1.AutoRedraw = False
            Me.Grid1.Rows = 1

            'Nota(Descartada, ver nota2), para el concepto se usó Replace(dRow("CONCEPTO").ToString, vbTab, " ").ToString  porque puede hacer conceptos que tengan incrustados tabs y este método ocupa los tabs para separar campos
            'Nota2, Pero ese método de usar Replace como función regresa nothing si la cadena esta vacia asi que se usará esta forma dRow("CONCEPTO").ToString.Replace(vbTab, " ").ToString

            For Each dRow As DataRow In dTabla.Rows
                Me.Grid1.AddItem(dRow("FOLIO_PROVEEDOR").ToString & Chr(9) & dRow("FECHA").ToString & Chr(9) & dRow("FOLIO_COMPRA").ToString & Chr(9) & dRow("NOMBRE_MONEDA_CO").ToString & Chr(9) & dRow("TIPO_DE_CAMBIO").ToString & Chr(9) &
                                 dRow("IMPUESTO_USD").ToString & Chr(9) & dRow("TOTAL_DOLARES").ToString & Chr(9) & dRow("SALDO_DOLARES").ToString & Chr(9) & dRow("CONCEPTO").ToString.Replace(vbTab, " ").ToString & Chr(9) &
                                 dRow("IMPUESTO").ToString & Chr(9) & dRow("TOTAL").ToString & Chr(9) & dRow("SALDO").ToString & Chr(9) & dRow("SALDO_IMPUESTO").ToString & Chr(9) &
                                 dRow("RETENCION_IVA").ToString & Chr(9) & dRow("PAGAR_IMPUESTO").ToString & Chr(9) & dRow("PAGAR").ToString & Chr(9) & dRow("PAGO_USD") & Chr(9) &
                                 dRow("SELECCION").ToString & Chr(9) & dRow("CODIGO_DOCUMENTO").ToString & Chr(9) & dRow("AUTORIZADO").ToString & Chr(9))
            Next

            'No es posible hace un datasource y luego intentar cambiar datos de celdas con codigo, no marca error pero no hace el cambio
            dTabla.DefaultView.AllowDelete = False
            dTabla.DefaultView.AllowNew = False

            'Me.Grid1.DataSource = Me.oBancosCXP.CargaComprasProveedorConSaldo(Me.TxtCodigoProveedor.Text)
            'Me.Grid1.Rows += 1

            If dTabla.Rows.Count = 0 Then
                MsgBox("El proveedor no tiene compras con saldo.", MsgBoxStyle.Information, Me.Text)
            End If

            bResultado = True
            Me.FormateaGrid()

        Catch ex As Exception
            HandleError(Me.Name, "CargaComprasConSaldo", ex)
        Finally
            Me.Grid1.AutoRedraw = True
            Me.Grid1.Refresh()
        End Try

        Return bResultado
    End Function

    'Private Function CargaEmbarquesConSaldoFlete() As Boolean
    '    Dim dTabla As DataTable
    '    Dim oEmbarques As New Class_Embarques_EmbarqueGlobal

    '    Try

    '        dTabla = oEmbarques.CargaComprasProveedorConSaldo(Me.TxtCodigoProveedor.Text)
    '        Me.Grid1.Rows = 1
    '        For Each dRow As DataRow In dTabla.Rows
    '            Me.Grid1.AddItem(dRow(0).ToString & Chr(9) & Format(CDate(dRow(1)), "dd-MMM-yyyy") & Chr(9) & dRow(2).ToString & Chr(9) & dRow(3).ToString & Chr(9) & dRow(4).ToString & Chr(9) & _
    '                            dRow(5).ToString & Chr(9) & dRow(6).ToString & Chr(9) & dRow(7).ToString & Chr(9) & dRow(8).ToString)
    '        Next

    '        'No es posible hace un datasource y luego intentar cambiar datos de celdas con codigo, no marca error pero no hace el cambio
    '        'Me.Grid1.DataSource = Me.oBancosCXP.CargaComprasProveedorConSaldo(Me.TxtCodigoProveedor.Text)
    '        Me.Grid1.Rows += 1

    '        If dTabla.Rows.Count = 0 Then
    '            MsgBox("El proveedor no tiene compras con saldo.", MsgBoxStyle.Information, Me.Text)
    '        End If

    '        CargaEmbarquesConSaldoFlete = True
    '        Me.FormateaGrid()

    '    Catch ex As Exception
    '        HandleError(Me.Name, "CargaEmbarquesConSaldoFlete", ex)
    '    End Try
    'End Function


    Private Function ExisteDocumento(ByVal sFolio As String) As Boolean
        Try
            Dim sql As New Class_find("SELECT 1 FROM BANCOS_GLOBAL WHERE FOLIO_BANCO='" & sReplace(sFolio) & "' AND CODIGO_PLAZA= " & Plaza.CODIGO_PLAZA & " ")
            If sql.Result1.Length > 0 Then
                Return True
            End If
        Catch ex As Exception
            HandleError(Me.Name, "ExisteDocumento", ex)
        End Try
    End Function

    Private Function CancelaPagosCXP() As Boolean
        Const sProcedure As String = "CancelaPagosCXP"
        Dim bResultado As Boolean = False
        Dim oFirmaElectronica = New UtileriasFirmaElectronicaCancelacionMovimientosFueraPeriodo
        Dim oUtileriasCancela As New Class_UtileriasFirmaElectronicaCancelacion
        Dim oPoliza As New Class_Contabilidad_Poliza_Global
        'Dim sFolio As String = Me.TxtFolio.Text

        'Me.oBancosCXP = New Class_Bancos_CXP(sFolio)

        If MsgBox("Deseas cancelar el movimiento de " & Me.cboDocumento.Text & " ?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, sProcedure) = MsgBoxResult.No Then
            Return False
        End If

        If Usuario.ValidaPermisoUsuarioDocumentoSinAfectacionInventarios(Me.cboDocumento.SelectedValue.ToString) = False Then
            MsgBox("El usuario " & Usuario.Nombre_Usuario & " no tiene permiso para realizar el movimiento de inventarios.", MsgBoxStyle.Exclamation, sProcedure)
            Return False
        End If

        'no se ocupa por que para eso esta la interfaz
        'If PLAZA.ValidarPeriodoTrabajo(Date.Now) = False Then 'Para cancelar se valida con la fecha de la maquina
        '    return false
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
            oUtileriasCancela.MODULO = Me.oBancosCXP.CODIGO_MODULO
            oUtileriasCancela.CODIGO_PLAZA = Usuario.Codigo_Plaza

            If oUtileriasCancela.GestionaCancelacion() = False Then
                Return False
            End If

            If oUtileriasCancela.CANCELA_DIRECTO = True Then
                Me.oBancosCXP.FECHA_DE_CANCELACION = Date.Now
                If Me.oBancosCXP.CancelaBancosCxp() = False Then
                    Return False
                End If
            Else
                oUtileriasCancela = New Class_UtileriasFirmaElectronicaCancelacion
                oUtileriasCancela.FOLIO_DOCUMENTO = Me.TxtFolio.Text
                oUtileriasCancela.FOLIO_POLIZA = Me.oBancosCXP.FOLIO_POLIZA
                oUtileriasCancela.CODIGO_DOCUMENTO = Me.cboDocumento.SelectedValue.ToString
                oUtileriasCancela.CODIGO_PLAZA = Usuario.Codigo_Plaza
                oUtileriasCancela.MODULO = Me.oBancosCXP.CODIGO_MODULO

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

                    Me.oBancosCXP.FECHA_DE_CANCELACION = oUtileriasCancela.FECHA_CANCELACION

                    If Me.oBancosCXP.CancelaBancosCxp() = False Then
                        MsgBox("Error al intentar cancelar el movimiento de documento de banco.", MsgBoxStyle.Exclamation, sProcedure)
                        Return False
                    End If

                    'If Me.oBancosCXP.CancelaBancosCxpFletes() = False Then
                    '    MsgBox("Error al intentar cancelar el movimiento de salgo de fletes.", MsgBoxStyle.Exclamation, sProcedure)
                    '    return false
                    'End If
                End If
            End If

            If oBancosCXP.ConsultarBancosCXPFletes(Me.oBancosCXP.FOLIO_BANCO.ToString) = True Then
                If Me.oBancosCXP.CancelaBancosCxpFletes() = False Then
                    MsgBox("Error al intentar cancelar el movimiento de salgo de fletes.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If
            End If

            MsgBox("Movimiento de bancos cancelado satisfactoriamente.", MsgBoxStyle.Information, sProcedure)

            bResultado = True

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    Private Function BusquedaVisual_PorDescripcion() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de pagos CXP en bancos."
        f.sCampo = "FOLIO_BANCO"
        f.sOrder = "FOLIO_BANCO"
        f.sTable = "VW_BANCOS_GLOBAL_CON_CXP_GLOBAL"
        f.sQl = "SELECT DISTINCT FOLIO_BANCO,NOMBRE_PROVEEDOR,CONCEPTO,FECHA,TOTAL_PAGO,ESTATUS FROM VW_BANCOS_GLOBAL_CON_CXP_GLOBAL WHERE 1=1 AND CODIGO_PLAZA=" & Plaza.CODIGO_PLAZA & " AND "
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
            If FormaCargada = False Then Exit Function
            Me.TxtFolio.Text = ""

            If txtCuentaBancaria.TextLength = 0 Then
                Me.txtCuentaBancaria.Enabled = True
                Me.txtCuentaBancaria.Focus()
                Exit Function
            Else
                Dim oCuentaBancaria As New Class_CatCuentasBancarias(CInt(Me.txtCuentaBancaria.Text))
                If oCuentaBancaria.Existe = False Then
                    If Me.txtCuentaBancaria.Enabled = True Then Me.txtCuentaBancaria.Focus()
                    MsgBox("La cuenta bancaria capturada no existe, verifíquela.", MsgBoxStyle.Exclamation, Me.Nombre_Modulo)
                    oCuentaBancaria = Nothing
                    Exit Function
                End If
                oCuentaBancaria = Nothing
            End If

            Me.txtCuentaBancaria.Enabled = False
            Me.oBancosCXP.CODIGO_DOCUMENTO = Me.cboDocumento.SelectedValue.ToString

            Select Case Microsoft.VisualBasic.Left(Me.oBancosCXP.CODIGO_DOCUMENTO, 3)
                Case "CHB"
                    Me.TxtFolio.Text = Me.oBancosCXP.GeneraFolioCheque(CInt(valorNumerico(Me.txtCuentaBancaria.Text)))
                Case Else
                    Me.TxtFolio.Text = Me.oBancosCXP.GeneraFolio()
            End Select

            'Select Case Me.oBancosCXP.CODIGO_DOCUMENTO
            '    Case "CHB1", "CHB2"
            '        Me.TxtFolio.Text = Me.oBancosCXP.GeneraFolioCheque(CInt(valorNumerico(Me.TxtCuentaBancaria.Text)))
            '    Case "TRB1", "TRB2"
            '        Me.TxtFolio.Text = Me.oBancosCXP.GeneraFolio()
            'End Select

            Return True

        Catch ex As Exception
            HandleError(Me.Name, "GeneraFolio", ex)
        End Try
    End Function

    Private Sub Cambia_Estado(ByVal pEstado As enumEstados)
        Try
            Me.Estado = pEstado
            Select Case Me.Estado
                Case enumEstados.NUEVO
                    Me.tsbGrabar.Enabled = True
                    Me.tsbCancelar.Enabled = False
                    Me.tsbImprimir.Enabled = False
                    Me.tsbIvaAcreditable.Enabled = False

                    Select Case Me.ModoPago
                        Case enumModoPago.PROVEEDOR
                            Me.cboDocumento.Enabled = True
                            Me.cboTipoPago.Enabled = True
                            Me.lblDisplayTipoPago.Enabled = True
                        Case enumModoPago.ACREEDOR
                            Me.cboDocumento.Enabled = True ' False
                            Me.cboTipoPago.Visible = False
                            Me.lblDisplayTipoPago.Enabled = False
                    End Select

                    Me.dtFecha.Enabled = True
                    Me.TxtCodigoProveedor.Enabled = True
                    Me.TxtConcepto.Enabled = True
                    'Me.ckbAbonoCuentaBeneficiario.Checked = True
                    Me.ckbAbonoCuentaBeneficiario.Enabled = True
                    Me.CkbPagoFleteEmbarques.Checked = False
                    Me.CkbPagoFleteEmbarques.Enabled = True
                    If Me.ModoPago = enumModoPago.PROVEEDOR Then
                        Me.TxtImporte.Enabled = False
                    Else
                        Me.TxtImporte.Enabled = True
                    End If
                    Me.tssEstado.Text = "Estado: agregando documento " & Me.cboDocumento.Text
                    Me.tssElaboro.Visible = False
                    Me.tssCancelo.Visible = False
                    Me.Grid1.Locked = False
                    Me.TxtFolio.Enabled = True
                    Me.txtCuentaBancaria.Enabled = True
                    Me.txtCuentaContableOrigenRecursos.Enabled = True
                    'Me.ckbDolares.Enabled = False
                    Me.cboMoneda.Enabled = False

                    If Empresa_Sistema.TIPO_CAMBIO_POR_DIA = True Then
                        Me.txtTipoCambio.Enabled = False
                    Else
                        Me.txtTipoCambio.Enabled = True
                    End If

                    Me.txtImporteDolares.Enabled = False
                    Me.CboFacturasRecibidas.Enabled = True
                    Me.lblFacturasRecibidas.Enabled = True

                    If Me.Visible = True Then
                        Me.txtCuentaBancaria.Focus()
                    End If
                    Me.Grid2.Locked = False

                Case enumEstados.APLICADO
                    Me.tsbGrabar.Enabled = False
                    Me.tsbCancelar.Enabled = True
                    Me.tsbImprimir.Enabled = True
                    Me.tsbIvaAcreditable.Enabled = True

                    Me.cboDocumento.Enabled = False
                    Me.dtFecha.Enabled = False
                    'Me.ckbDolares.Enabled = False
                    Me.cboMoneda.Enabled = False
                    Me.txtTipoCambio.Enabled = False
                    Me.txtImporteDolares.Enabled = False
                    Me.TxtCodigoProveedor.Enabled = False
                    Me.TxtConcepto.Enabled = False
                    Me.TxtImporte.Enabled = False
                    Me.CboFacturasRecibidas.Enabled = False
                    Me.lblFacturasRecibidas.Enabled = False
                    Me.cboTipoPago.Enabled = False
                    Me.lblDisplayTipoPago.Enabled = False
                    Me.tssEstado.Text = "Estado: Consulta de " & Me.cboDocumento.Text
                    Me.tssElaboro.Visible = True
                    Me.tssCancelo.Visible = False
                    Me.Grid1.Locked = True
                    Me.ckbAbonoCuentaBeneficiario.Enabled = False
                    Me.CkbPagoFleteEmbarques.Enabled = False
                    If Me.ModoPago = enumModoPago.PROVEEDOR Then
                        'Me.Grid1.Cell(0, Me.iGyPagoMXP).Text = "Pagado"
                        Me.Grid1.Column(Me.iGySeleccion).Visible = False
                    End If
                    Me.tsbImprimir.Select()
                    Me.Grid2.Locked = True

                Case enumEstados.CANCELADO
                    Me.tsbGrabar.Enabled = False
                    Me.tsbCancelar.Enabled = False
                    Me.tsbImprimir.Enabled = True
                    Me.tsbIvaAcreditable.Enabled = False

                    Me.cboDocumento.Enabled = False
                    Me.dtFecha.Enabled = False
                    'Me.ckbDolares.Enabled = False
                    Me.cboMoneda.Enabled = False
                    Me.txtTipoCambio.Enabled = False
                    Me.txtImporteDolares.Enabled = False
                    Me.TxtCodigoProveedor.Enabled = False
                    Me.TxtConcepto.Enabled = False
                    Me.TxtImporte.Enabled = False
                    Me.CboFacturasRecibidas.Enabled = False
                    Me.lblFacturasRecibidas.Enabled = False
                    Me.cboTipoPago.Enabled = False
                    Me.lblDisplayTipoPago.Enabled = False
                    Me.tssEstado.Text = "Estado: Consulta de " & Me.cboDocumento.Text
                    Me.tssElaboro.Visible = True
                    Me.tssCancelo.Visible = True
                    Me.Grid1.Locked = True
                    Me.ckbAbonoCuentaBeneficiario.Enabled = False
                    Me.CkbPagoFleteEmbarques.Enabled = False
                    If Me.ModoPago = enumModoPago.PROVEEDOR Then
                        Me.Grid1.Cell(0, Me.iGyPagoMXN).Text = "Pagado"
                        Me.Grid1.Column(Me.iGySeleccion).Visible = False
                    End If
                    Me.tsbImprimir.Select()
                    Me.Grid2.Locked = True
            End Select

        Catch ex As Exception
            HandleError(Me.Name, "Cambia_Estado", ex)
        End Try
    End Sub

    Private Sub GestionaGrid(ByVal e As System.Windows.Forms.KeyEventArgs)
        Dim Columna As Integer, Renglon As Integer
        Dim StrCod As String, dImporte As Double, dPago As Double
        Dim oEmbarque As Class_Embarques_EmbarqueGlobal

        If Me.Estado = enumEstados.CANCELADO Then
            Exit Sub
        End If

        Try
            Columna = Me.Grid2.Selection.FirstCol
            Renglon = Me.Grid2.Selection.FirstRow
            StrCod = Me.Grid2.Cell(Renglon, Me.iGyFolioEmbarque).Text
            'iBultos = valorNumerico(Me.Grid2.Cell(Renglon, Me.igyBultos).Text)
            dImporte = valorNumerico(Me.Grid2.Cell(Renglon, Me.iGySaldoFlete).Text)

            Select Case e.KeyCode
                Case Keys.Enter
                    Select Case Columna
                        Case Me.iGyFolioEmbarque

                            'If Me.Grid2.Cell(Renglon, Me.iGySaldoFlete).Text = "SI" Then
                            '    Exit Sub
                            'End If

                            If txtLEN(StrCod) = False Then
                                GoTo BuscaEmbarque
                            End If
LlenaLinea:
                            oEmbarque = New Class_Embarques_EmbarqueGlobal() '"EMB"& Usuario.Codigo_Plaza)
                            oEmbarque.FOLIO_EMBARQUE = StrCod
                            If oEmbarque.Consultar() = False Then
                                GoTo BuscaEmbarque
                            End If
                            Dim oPoliza As New Class_Contabilidad_Poliza_Global(StrCod)
                            If oPoliza.Existe = False Then
                                'GoTo BuscaEmbarque
                                MsgBox("La póliza de flete no existe", MsgBoxStyle.Information, "Validación de embarques")
                                Exit Sub
                            End If

                            'Dim sql As New Class_find("SELECT CANTIDAD_TOTAL_PALET,PESO_TOTAL_PALET,IMPORTE_TOTAL_PALET, " & _
                            '"CASE WHEN ISNULL( SALIDA_EMPAQUE_GENERADA,'0')='0' THEN 'NO' ELSE 'SI' END AS SALIDA_EMPAQUE_GENERADA     " & _
                            '"FROM EMB_PALETS_GLOBAL Where FOLIO_PALET='" & StrCod & "'")

                            'Me.Grid2.Cell(Renglon, Me.iGyFactura).Text = ""
                            Me.Grid2.Cell(Renglon, Me.iGyFolioEmbarque).Text = oEmbarque.FOLIO_EMBARQUE
                            Me.Grid2.Cell(Renglon, Me.iGyConceptoFlete).Text = oPoliza.CONCEPTO1.ToString
                            Me.Grid2.Cell(Renglon, Me.iGyTotalFlete).Text = oEmbarque.IMPORTE_FLETE.ToString
                            Me.Grid2.Cell(Renglon, Me.iGySaldoFlete).Text = oEmbarque.SALDO_FLETE.ToString
                            Me.Grid2.Cell(Renglon, Me.iGyPagoFlete).Text = ""

                            If Me.ValidarEmbarques(Renglon, Me.Grid2.Cell(Renglon, Me.iGyFolioEmbarque).Text) = False Then
                                e.SuppressKeyPress = True
                                Exit Sub
                            End If

                            Me.Totales()

                        Case Me.iGyPagoFlete
                            dPago = valorNumerico(Me.Grid2.Cell(Renglon, Me.iGyPagoFlete).Text)
                            If dPago > 0 And txtLEN(Me.Grid2.Cell(Renglon, Me.iGyFolioEmbarque).Text) = True Then
                                If dPago > valorNumerico(Me.Grid2.Cell(Renglon, Me.iGySaldoFlete).Text) And Me.Grid2.Locked = False Then
                                    MsgBox("El pago en el renglón: " & Renglon & " es mayor al saldo del flete favor de revisar.", MsgBoxStyle.Exclamation, "Validación de Importes de CXP")
                                    Me.Grid2.Cell(Renglon, Me.iGyPagoFlete).SetFocus()
                                    e.SuppressKeyPress = True
                                    Exit Sub
                                End If
                            ElseIf dPago <= 0 Then
                                MsgBox("La cantidad debe de ser mayor a 0.", MsgBoxStyle.Exclamation, Me.Text)
                                Me.Grid2.Cell(Renglon, Me.iGyPagoFlete).SetFocus()
                                e.SuppressKeyPress = True
                                Exit Sub
                            End If

                        Case Me.iGySeleccionFlete
                            If Me.Grid2.Rows = Renglon + 1 Then
                                Me.Grid2.Rows = Me.Grid2.Rows + 1
                            End If

                    End Select
                    Me.Totales()

                Case Keys.F6
                    'If Me.Grid2.Cell(Renglon, Me.igySalida).Text = "SI" Then
                    '    Exit Sub
                    'End If
BuscaEmbarque:
                    If Columna = Me.iGyFolioEmbarque Then
                        oEmbarque = New Class_Embarques_EmbarqueGlobal
                        StrCod = oEmbarque.BusquedaVisual_Embarques_Extranjeros_SaldoFletes
                        If txtLEN(StrCod) = True Then
                            GoTo LlenaLinea
                        End If
                    End If

                Case Keys.F8 ', Keys.Delete
                    If (Me.Estado = enumEstados.NUEVO) Then
                        If Me.Grid2.Rows > 2 Then
                            Me.Grid2.Selection.DeleteByRow()
                            e.SuppressKeyPress = True
                        Else
                            'Me.Grid2.Cell(Renglon, Me.iGyFactura).Text = ""
                            Me.Grid2.Cell(Renglon, Me.iGyFolioEmbarque).Text = ""
                            Me.Grid2.Cell(Renglon, Me.iGyConceptoFlete).Text = ""
                            Me.Grid2.Cell(Renglon, Me.iGyTotalFlete).Text = ""
                            Me.Grid2.Cell(Renglon, Me.iGySaldoFlete).Text = ""
                            Me.Grid2.Cell(Renglon, Me.iGyPagoFlete).Text = ""
                            Me.Grid2.Cell(Renglon, Me.iGySeleccionFlete).Text = ""
                        End If
                    End If
                    Me.Totales()

                    Me.FormateaGridFletes()
            End Select
            'Me.Grid.Refresh()

        Catch ex As Exception
            HandleError(Me.Name, "GestionaGrid", ex)
        End Try
    End Sub

    Private Function ValidarEmbarques(Optional ByVal Renglon As Integer = 2, Optional ByVal Codigo As String = "") As Boolean
        Try
            Dim i As Integer, j As Integer
            Dim sCodigoEmbarque As String = ""

            For i = 1 To Me.Grid2.Rows - 1
                If txtLEN(Me.Grid2.Cell(i, Me.iGyFolioEmbarque).Text) = True Then
                    Dim sql As New Class_find("SELECT 1 FROM EMB_EMBARQUE_GLOBAL WHERE FOLIO_EMBARQUE='" & Me.Grid2.Cell(i, Me.iGyFolioEmbarque).Text & "' AND ESTATUS_EMBARQUE='A'")
                    If sql.Result1 = "" Then
                        MsgBox("El embarque que intenta introducir en el renglón: " & i & " no existe ó esta cancelado, favor de intentar con otro embarque.", MsgBoxStyle.Exclamation, "Validación de embarques")
                        Return False
                    ElseIf sql.Result1 = "1" Then
                        Dim sql1 As New Class_find("SELECT SALDO_FLETE FROM EMB_EMBARQUE_GLOBAL WHERE FOLIO_EMBARQUE='" & Me.Grid2.Cell(i, Me.iGyFolioEmbarque).Text & "'")
                        If valorNumerico(sql1.Result1) < valorNumerico(Me.Grid2.Cell(i, Me.iGyPagoFlete).Text) Then
                            MsgBox("El pago en el renglón: " & i & " es mayor al saldo del flete favor de revisar.", MsgBoxStyle.Exclamation, "Validación de Importes de CXP")
                            Me.Grid2.Cell(i, Me.iGyPagoFlete).Text = ""
                            Me.Grid2.Cell(i, Me.iGyPagoFlete).SetFocus()
                            Return False
                        End If
                    End If
                End If
            Next i

            If txtLEN(Codigo) = False Then
                For i = 1 To Me.Grid2.Rows - 1
                    sCodigoEmbarque = Me.Grid2.Cell(i, Me.iGyFolioEmbarque).Text
                    For j = i + 1 To Me.Grid2.Rows - 1
                        If txtLEN(Me.Grid2.Cell(j, Me.iGyFolioEmbarque).Text) = True Then
                            If sCodigoEmbarque = Me.Grid2.Cell(j, Me.iGyFolioEmbarque).Text And Me.Grid2.Rows > 2 Then
                                MsgBox("El embarque que intenta introducir en el renglón:  " & i & " ya existe en el renglon " & j.ToString & ", favor de intentar con otro código.", MsgBoxStyle.Exclamation, "Validación de embarques")
                                Me.Grid2.Cell(i, Me.iGyFolioEmbarque).SetFocus()
                                Return False
                            End If
                        End If
                    Next j
                    'sCodigoProducto = Me.Grid.Cell(i, Me.igyCodigo).Text
                Next i
            Else
                sCodigoEmbarque = Codigo

                For j = 1 To Renglon - 1 'Me.Grid.Rows - 1
                    If txtLEN(Me.Grid2.Cell(j, Me.iGyFolioEmbarque).Text) = True Then
                        If sCodigoEmbarque = Me.Grid2.Cell(j, Me.iGyFolioEmbarque).Text And Me.Grid2.Rows > 2 Then
                            MsgBox("El embarque que intenta introducir en el renglón: " & Renglon & " ya existe, favor de intentar con otro embarque.", MsgBoxStyle.Exclamation, "Validación de embarque")
                            Me.Grid2.Cell(Renglon, Me.iGyFolioEmbarque).Text = ""
                            Me.Grid2.Cell(Renglon, Me.iGyConceptoFlete).Text = ""
                            Me.Grid2.Cell(Renglon, Me.iGyTotalFlete).Text = ""
                            Me.Grid2.Cell(Renglon, Me.iGySaldoFlete).Text = ""
                            Me.Grid2.Cell(Renglon, Me.iGyPagoFlete).Text = ""
                            Me.Grid2.Cell(Renglon, Me.iGyFolioEmbarque).SetFocus()
                            Return False
                        End If
                    End If
                Next j

                For j = Renglon + 1 To Me.Grid2.Rows - 1
                    If txtLEN(Me.Grid2.Cell(j, Me.iGyFolioEmbarque).Text) = True Then
                        If sCodigoEmbarque = Me.Grid2.Cell(j, Me.iGyFolioEmbarque).Text And Me.Grid2.Rows > 2 Then
                            MsgBox("El embarque que intenta introducir en el renglón: " & Renglon & " ya existe, favor de intentar con otro palet.", MsgBoxStyle.Exclamation, "Validación de embarque")
                            Me.Grid2.Cell(Renglon, Me.iGyFolioEmbarque).Text = ""
                            Me.Grid2.Cell(Renglon, Me.iGyConceptoFlete).Text = ""
                            Me.Grid2.Cell(Renglon, Me.iGyTotalFlete).Text = ""
                            Me.Grid2.Cell(Renglon, Me.iGySaldoFlete).Text = ""
                            Me.Grid2.Cell(Renglon, Me.iGyPagoFlete).Text = ""
                            Me.Grid2.Cell(Renglon, Me.iGyFolioEmbarque).SetFocus()
                            Return False
                        End If
                    End If
                Next j
            End If

            Return True

        Catch ex As Exception
            HandleError(Me.Name, "ValidarEmbarques", ex)
        End Try
    End Function

    Private Function ValidaProveedor() As Boolean 'Valida que el codigo de proveedor no sea el de la cuenta bancaria
        Dim bResultado As Boolean = False
        Try
            Dim oCuentaBancaria As Class_CatCuentasBancarias, oTipoProveedor As Class_SisTiposProveedores, oProveedor As Class_CatProveedores

            If txtLEN(Me.txtCuentaBancaria.Text) = False Then
                MsgBox("Falta que asígne la cuenta bancaria.", MsgBoxStyle.Exclamation, Me.Text)
                Return False
            End If

            oCuentaBancaria = New Class_CatCuentasBancarias(Me.txtCuentaBancaria.Text)
            If oCuentaBancaria.Existe = False Then
                MsgBox("No existe la cuenta bancaria asignada.", MsgBoxStyle.Exclamation, Me.Text)
                Return False
            End If

            If txtLEN(Me.TxtCodigoProveedor.Text) = False Then
                MsgBox("Falta que asígne el proveedor.", MsgBoxStyle.Exclamation, Me.Text)
                Return False
            End If

            oProveedor = New Class_CatProveedores(Me.TxtCodigoProveedor.Text)

            If txtLEN(Me.TxtCodigoProveedor.Text) = False Then
                MsgBox("No existe el proveedor asignado.", MsgBoxStyle.Exclamation, Me.Text)
                Return False
            End If

            If Me.TxtCodigoProveedor.Text = oCuentaBancaria.CODIGO_PROVEEDOR Then
                MsgBox("No se puede hacer un traspaso de una cuenta bancaria asi misma.", MsgBoxStyle.Exclamation, Me.Text)
                If Me.TxtCodigoProveedor.Enabled = True Then Me.TxtCodigoProveedor.Focus()
                Return False
            End If

            oTipoProveedor = New Class_SisTiposProveedores(oProveedor.Codigo_Tipo_Proveedor)

            Select Case Me.ModoPago
                Case enumModoPago.PROVEEDOR
                    If oTipoProveedor.REALIZA_COMPRAS_GASTOS_PAGOS = False Then
                        MsgBox("No se pueden realizar pagos al proveedor " & Me.TxtCodigoProveedor.Text & " por el tipo de proveedor : " & oTipoProveedor.Nombre_Tipo_Proveedor, MsgBoxStyle.Exclamation, Me.Text)
                        If Me.TxtCodigoProveedor.Enabled = True Then Me.TxtCodigoProveedor.Focus()
                        Return False
                    End If

                Case enumModoPago.ACREEDOR
                    If oTipoProveedor.REALIZA_TRASPASOS_ENTRE_CUENTAS = False Then
                        MsgBox("No se pueden realizar traspasos a la cuenta " & Me.TxtCodigoProveedor.Text & " por el tipo de proveedor : " & oTipoProveedor.Nombre_Tipo_Proveedor, MsgBoxStyle.Exclamation, Me.Text)
                        If Me.TxtCodigoProveedor.Enabled = True Then Me.TxtCodigoProveedor.Focus()
                        Return False
                    End If

                    If txtLEN(oProveedor.CuentaBancaria.ID_CUENTA_BANCARIA) = False Then
                        MsgBox("El proveedor debe estar relacionado a una cuenta bancaria.", MsgBoxStyle.Exclamation, Me.Text)
                        If Me.TxtCodigoProveedor.Enabled = True Then Me.TxtCodigoProveedor.Focus()
                        Return False
                    End If
            End Select

            'If txtLEN(Me.TxtCodigoProveedor.Text) = True Then
            '    Dim sql As New Class_find("SELECT CODIGO_PROVEEDOR FROM CAT_CUENTAS_BANCARIAS WHERE ID_CUENTA_BANCARIA=" & Me.TxtCuentaBancaria.Text)
            '    If Me.TxtCodigoProveedor.Text = (sql.Result1).ToString Then
            '        MsgBox("No se puede hacer un traspaso de una cuenta bancaria asi misma.", MsgBoxStyle.Exclamation, Me.Text)
            '        Me.TxtCodigoProveedor.Text = ""
            '        Me.TxtCodigoProveedor.Focus()
            '        sql = Nothing
            '        Return bResultado
            '    End If

            '    sql = New Class_find("SELECT T.REALIZA_COMPRAS_GASTOS_PAGOS FROM CAT_PROVEEDORES P INNER JOIN SIS_TIPOS_PROVEEDORES T ON(P.CODIGO_TIPO_PROVEEDOR=T.CODIGO_TIPO_PROVEEDOR) " &
            '                         "WHERE P.CODIGO_PROVEEDOR='" & Me.TxtCodigoProveedor.Text & "'")
            '    If sql.Result1 = "0" Then
            '        MsgBox("No se pueden realizar pagos al proveedor " & Me.TxtCodigoProveedor.Text, MsgBoxStyle.Information, Me.Text)
            '        Me.TxtCodigoProveedor.Text = ""
            '        Me.TxtCodigoProveedor.Focus()
            '        sql = Nothing
            '        Return bResultado
            '    End If
            'End If

            bResultado = True
        Catch ex As Exception
            HandleError(Me.Name, "ValidarProveedor", ex)
        End Try
        Return bResultado
    End Function

    Private Sub Autorizaciones()
        Try
            ' Dim Child As New Frm_CXP_Autorizaciones
            Child = New Frm_CXP_Autorizaciones
            Child.StartPosition = FormStartPosition.CenterScreen
            Child.ShowDialog()
            Child.Visible = False
            bAutorizacionesConsultada = True

            If Child.CODIGO_PROVEEDOR Is Nothing Then
                Exit Sub
            End If
            If txtLEN(Child.CODIGO_PROVEEDOR.ToString) = True Then
                Me.TxtCodigoProveedor.Text = Child.CODIGO_PROVEEDOR.ToString
                Me.LblProveedor.Text = Child.Grid1.Cell(Child.iRenglonSeleccionado, 2).Text
                Me.CargaComprasConSaldo()
            End If
        Catch ex As Exception
            HandleError(Me.Name, "Autorizaciones", ex)
        End Try
    End Sub

    Private Sub SiguienteProveedor()
        Try
            If bAutorizacionesConsultada = False Then
                'Exit Sub
                Child = New Frm_CXP_Autorizaciones
                Child.StartPosition = FormStartPosition.CenterScreen
                Child.Show()
                Child.Visible = False
                Child.iRenglonSeleccionado = 0
                bAutorizacionesConsultada = True
            End If

            If Child.Visible = False Then
                Dim sCodigoProveedor As String = ""

                Me.tsbNuevo.PerformClick()
                Dim i As Integer = Child.iRenglonSeleccionado + 1

                If i > Child.Grid1.Rows - 1 Then
                    Exit Sub
                End If
                If Child.Grid1.Cell(Child.iRenglonSeleccionado + 1, 1).Text = "" Then
                    Exit Sub
                End If
                sCodigoProveedor = Child.Grid1.Cell(Child.iRenglonSeleccionado + 1, 1).Text
                Me.TxtCodigoProveedor.Text = sCodigoProveedor
                Me.LblProveedor.Text = Child.Grid1.Cell(Child.iRenglonSeleccionado + 1, 2).Text
                Me.CargaComprasConSaldo()
            End If

        Catch ex As Exception
            HandleError(Me.Name, "SiguienteProveedor", ex)
        End Try
    End Sub

    Private Sub Navegador(ByVal sTipoDeBusqueda As String)
        Try
            Dim iFolio As Integer, sFolio As String, iPosicion As Integer, sFolioParte2 As String
            If txtLEN(Me.TxtFolio.Text) = False Then
                If GeneraFolio() = False OrElse txtLEN(Me.TxtFolio.Text) = False Then
                    Exit Sub
                End If
            End If

            If sTipoDeBusqueda = "Anterior" Then
                If Me.TxtFolio.Text.Contains("-") Then
                    iPosicion = Me.TxtFolio.Text.IndexOf("-")
                    sFolio = Me.TxtFolio.Text.Substring(0, iPosicion)
                    iFolio = CInt(Strings.Right(Me.TxtFolio.Text, Len(Me.TxtFolio.Text) - (Len(sFolio) + 1))) ' Me.oVenta.FOLIO_NUMERICO
                    iFolio = iFolio - 1
                    sFolioParte2 = Format(iFolio, New String("0", Me.TxtFolio.Text.Substring(3, Me.TxtFolio.TextLength - iPosicion - 1).Length))
                    sFolio = sFolio + "-" + sFolioParte2 'sFolio + "-" + iFolio.ToString
                    Me.TxtFolio.Text = sFolio
                Else
                    sFolio = Me.TxtFolio.Text.TrimEnd("0", "1", "2", "3", "4", "5", "6", "7", "8", "9")
                    iFolio = CInt(Strings.Right(Me.TxtFolio.Text, Len(Me.TxtFolio.Text) - Len(sFolio)))
                    iFolio = iFolio - 1
                    sFolioParte2 = Format(iFolio, New String("0", Me.TxtFolio.Text.Substring(0, Me.TxtFolio.TextLength - CInt(Len(sFolio))).Length))
                    sFolio = sFolio + sFolioParte2
                    Me.TxtFolio.Text = sFolio
                End If

                If txtLEN(sFolio) = True Then
                    Me.Consultar()
                Else
                    Me.Inicializa()
                    Me.Cambia_Estado(enumEstados.NUEVO)
                    Me.GeneraFolio()
                    Me.TxtFolio.Focus()
                End If

            ElseIf sTipoDeBusqueda = "Siguiente" Then
                If Me.TxtFolio.Text.Contains("-") Then
                    iPosicion = Me.TxtFolio.Text.IndexOf("-")
                    sFolio = Me.TxtFolio.Text.Substring(0, iPosicion)
                    iFolio = CInt(Strings.Right(Me.TxtFolio.Text, Len(Me.TxtFolio.Text) - (Len(sFolio) + 1))) ' Me.oVenta.FOLIO_NUMERICO
                    iFolio = iFolio + 1
                    sFolioParte2 = Format(iFolio, New String("0", Me.TxtFolio.Text.Substring(3, Me.TxtFolio.TextLength - iPosicion - 1).Length))
                    sFolio = sFolio + "-" + sFolioParte2 'sFolio + "-" + iFolio.ToString
                    Me.TxtFolio.Text = sFolio
                Else
                    sFolio = Me.TxtFolio.Text.TrimEnd("0", "1", "2", "3", "4", "5", "6", "7", "8", "9")
                    iFolio = CInt(Strings.Right(Me.TxtFolio.Text, Len(Me.TxtFolio.Text) - Len(sFolio)))
                    iFolio = iFolio + 1
                    sFolioParte2 = Format(iFolio, New String("0", Me.TxtFolio.Text.Substring(0, Me.TxtFolio.TextLength - CInt(Len(sFolio))).Length))
                    sFolio = sFolio + sFolioParte2
                    Me.TxtFolio.Text = sFolio
                End If

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
            HandleError(Me.Name, "Navegador", ex)
        End Try
    End Sub

    Private Sub ObtieneTipoCambioDia()
        Try
            Dim oTipoCambio As New Class_CatTiposCambio(Me.dtFecha.Value)

            If Empresa_Sistema.TIPO_CAMBIO_POR_DIA = True Then
                Me.txtTipoCambio.Enabled = False
                Me.txtTipoCambio.Text = "0"

                If oTipoCambio.Existe AndAlso oTipoCambio.TIPO_DE_CAMBIO > 0 Then
                    Me.txtTipoCambio.Text = Format(oTipoCambio.TIPO_DE_CAMBIO, "###,##0.0000")
                Else
                    If Me.cboMoneda.SelectedValue = 2 Then
                        MsgBox("No se ha capturado el tipo de cambio del día.", MsgBoxStyle.Exclamation, Me.Text)
                    End If
                End If
            Else
                If oTipoCambio.Existe = True Then
                    Me.txtTipoCambio.Text = Format(oTipoCambio.TIPO_DE_CAMBIO, "###,##0.0000")
                End If
            End If

            oTipoCambio = Nothing
        Catch ex As Exception
            HandleError(Me.Name, "ObtieneTipoCambioDia", ex)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim oVisorXML As New Frm_CFDI_VisorXML("81259726-bbea-4271-80a6-4c83f1e25d63")
        oVisorXML.Show()
    End Sub

#End Region

End Class
