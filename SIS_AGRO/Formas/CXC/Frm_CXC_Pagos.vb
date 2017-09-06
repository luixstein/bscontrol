Option Strict On
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient

Public Class Frm_CXC_Pagos

#Region "Propiedades"
    Public ReadOnly Property Nombre_Modulo() As String
        Get
            Return "Pagos a Acreedores."
        End Get
    End Property
#End Region

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

    Private iGyCodigoCliente As Integer = 1
    Private iGyNombreCliente As Integer = 2
    Private iGyFecha As Integer = 3
    Private iGyFolio As Integer = 4
    Private iGyMedioPago As Integer = 5
    Private iGyBanco As Integer = 6
    Private iGyTotal As Integer = 7
    Private iGySaldo As Integer = 8
    Private iGyTotalDlls As Integer = 9
    Private iGySaldoDlls As Integer = 10
    Private iGyPago As Integer = 11
    Private iGyPagoPesos As Integer = 12
    Private iGySeleccion As Integer = 13
    Private iGyReferencia As Integer = 14
    Private iGyDiferencia As Integer = 15
    Private iGyIvaPorPagar As Integer = 16

    Private ClickSinEjecutar As Boolean = False
    Private bDocumentosCargados As Boolean = False

#Region "Propiedades"
    'Public WriteOnly Property ModoPagoClientees() As Boolean
    '    Set(ByVal Value As Boolean)
    '        Me._ModoPagoClientees = Value
    '    End Set
    'End Property
#End Region

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
    End Sub

#Region "Opciones"
    Private Sub tsbNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbNuevo.Click
        Inicializa()
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

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub

    Private Sub btnAgregarDocumentosClientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarDocumentosClientes.Click
        If txtLEN(Me.TxtCuentaBancaria.Text) = False Then
            MsgBox("Asígne la cuenta bancaria de donde sale el pago.", MsgBoxStyle.Exclamation, Me.Text)
            Me.TxtCuentaBancaria.Focus()
            Return
        End If
        If Me.CkbAnticipo.Checked = True Then
            If txtLEN(Me.txtAnticipo.Text) = True And valorNumerico(Me.txtAnticipo.Text) > 0 Then
                Me.AgregarAnticipoClientes()
            Else
                MsgBox("El anticipo debe ser mayor a 0.", MsgBoxStyle.Exclamation, "Validación de Anticipos")
                Me.txtAnticipo.Focus()
            End If
        Else
            Me.AgregarDocumentosClientes()
        End If
    End Sub
#End Region

#Region "Eventos de objetos"

    Private Sub Frm_CXC_Pagos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.DesplegarDocumentos()
        Me.DesplegarBancos()
        Me.DesplegarMedioDePagos()

        Me.Inicializa()

        Me.Cambia_Estado(enumEstados.NUEVO)
    End Sub

    Private Sub Frm_CXC_Pagos_Acreedores_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If Me.Estado = enumEstados.NUEVO And Me.TxtCuentaBancaria.Enabled = True Then
            Me.TxtCuentaBancaria.Focus()
        End If
    End Sub

    Private Sub CmbDocumento_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbDocumento.SelectedIndexChanged
        Me.Inicializa()
        Me.Cambia_Estado(enumEstados.NUEVO)
    End Sub

    Private Sub TxtCuentaBancaria_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCuentaBancaria.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.F6
busqueda_Visual:
                    Dim oIdCodigoBanco As New Class_CatCuentasBancarias
                    Dim sIdCodigoBanco As String = oIdCodigoBanco.BusquedaVisual_PorDescripcion
                    If txtLEN(sIdCodigoBanco) = True Then
                        Me.TxtCuentaBancaria.Text = sIdCodigoBanco
                        sIdCodigoBanco = Replace(sIdCodigoBanco, "'", "''")
                        Dim sql As New Class_find("Select NOMBRE_CUENTA_BANCARIA,CUENTA_CONTABLE_PESOS,CUENTA_CONTABLE_DOLARES,CODIGO_BANCO From CAT_CUENTAS_BANCARIAS Where ID_CUENTA_BANCARIA=" & sIdCodigoBanco & "")
                        Me.TxtCuentaBancaria.Text = sIdCodigoBanco.ToString
                        Me.LblCuentaBancaria.Text = sql.Result1
                        Me.LblCuentaContableCuentaBancaria.Text = sql.Result2

                        Me.GeneraFolio()
                    End If

                Case Keys.Return
                    Dim sql As New Class_find("Select NOMBRE_CUENTA_BANCARIA,CUENTA_CONTABLE_PESOS,CUENTA_CONTABLE_DOLARES,CODIGO_BANCO From CAT_CUENTAS_BANCARIAS Where ID_CUENTA_BANCARIA=" & valorNumerico(Me.TxtCuentaBancaria.Text) & "")
                    If sql.Result1 = "" Then
                        Me.LblCuentaBancaria.Text = ""
                        Me.LblCuentaContableCuentaBancaria.Text = ""

                        GoTo busqueda_Visual
                    Else
                        Me.LblCuentaBancaria.Text = sql.Result1
                        Me.LblCuentaContableCuentaBancaria.Text = sql.Result2
                        Me.GeneraFolio()
                        Me.TxtFolio.Focus()
                    End If
                    sql = Nothing

                    'Me.TxtFolio.Focus()
                    'SendKeys.Send("{TAB}")

                Case Keys.Escape
                    Me.CmbDocumento.Focus()
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
        Try
            Select Case e.KeyCode
                Case Keys.F6
Buscar:
                    Dim Busqueda = New Busqueda_General("CODIGO_CLIENTE AS CODIGO,NOMBRE_CLIENTE AS NOMBRE", "CAT_CLIENTES", "1=1 AND ESTATUS='A' and codigo_zona= " & Usuario.Codigo_Plaza, "NOMBRE", "NOMBRE_CLIENTE")
                    Busqueda.ShowDialog()
                    Me.TxtCodigoCliente.Text = "" & Busqueda.Tag.ToString
                    Busqueda.Dispose()

                Case Keys.Enter
                    If txtLEN(Me.TxtCodigoCliente.Text) = False Then
                        Me.LblCliente.Text = ""
                        Me.TxtCodigoCliente.Focus()
                        GoTo Buscar
                        Exit Sub
                    End If
                    Dim sql As New Class_find("SELECT NOMBRE_CLIENTE,CUENTA_CONTABLE,CUENTA_CONTABLE_DOLARES FROM CAT_CLIENTES WHERE CODIGO_CLIENTE='" & Me.TxtCodigoCliente.Text & "' AND ESTATUS='A' and codigo_zona= " & Usuario.Codigo_Plaza)
                    If sql.Result1 = "" Then
                        MsgBox("El código de Cliente que intenta buscar no existe o esta dado de baja, favor de intentar con otro código.", MsgBoxStyle.Exclamation, "Validación de Clientes")
                        Me.LblCliente.Text = ""
                        GoTo Buscar : Exit Sub
                    Else
                        Me.LblCliente.Text = sql.Result1
                        Me.CboMedioDePago.Focus()
                    End If
                    sql = Nothing
            End Select
        Catch ex As Exception
            HandleError(Me.Name, "TxtCodigoCliente_KeyDown", ex)
        End Try
    End Sub

    Private Sub TxtImporte_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Return Then
            Me.TxtTotal.Text = FormatImporteContable(CDbl(Me.TxtTotal.Text))
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtConcepto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtConcepto.KeyDown
        If e.KeyCode = Keys.Return Then
            'Me.Grid1.Cell(1, Me.iGyPago).SetFocus()
            Me.TxtCodigoCliente.Focus()
        End If
    End Sub

    'Private Sub ckbDolares_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckbDolares.CheckedChanged
    '    If Me.ckbDolares.Checked = True Then
    '        Me.txtTipoCambio.Enabled = True
    '        'Me.txtTotalDolares.Enabled = True
    '        Me.lblTipoCambio.Enabled = True
    '        ' Me.lblTotalDolares.Enabled = True
    '        Me.txtTipoCambio.Focus()

    '        Me.Grid.Column(Me.iGyFolio).Width = 50
    '        Me.Grid.Column(Me.iGyFecha).Width = 60
    '        Me.Grid.Column(Me.iGyTotal).Visible = False
    '        Me.Grid.Column(Me.iGySaldo).Visible = False
    '        Me.Grid.Column(Me.iGyTotalDlls).Visible = True
    '        Me.Grid.Column(Me.iGySaldoDlls).Visible = True
    '        Me.Grid.Column(Me.iGyDiferencia).Visible = True
    '        Me.Grid.Column(Me.iGyPagoPesos).Visible = True
    '    Else
    '        Me.txtTipoCambio.Enabled = False : Me.txtTipoCambio.Text = ""
    '        'Me.txtTotalDolares.Enabled = False
    '        Me.lblTipoCambio.Enabled = False
    '        'Me.lblTotalDolares.Enabled = False : Me.txtImporteDolares.Text = ""
    '        Me.Grid.Column(Me.iGyFolio).Width = 95
    '        Me.Grid.Column(Me.iGyFecha).Width = 90
    '        Me.Grid.Column(Me.iGyTotal).Visible = True
    '        Me.Grid.Column(Me.iGySaldo).Visible = True
    '        Me.Grid.Column(Me.iGyTotalDlls).Visible = False
    '        Me.Grid.Column(Me.iGySaldoDlls).Visible = False
    '        Me.Grid.Column(Me.iGyDiferencia).Visible = False
    '        Me.Grid.Column(Me.iGyPagoPesos).Visible = False
    '    End If
    'End Sub

    Private Sub cboMoneda_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMoneda.SelectedIndexChanged
        If Me.cboMoneda.SelectedIndex = 1 Then
            Me.txtTipoCambio.Enabled = True
            Me.lblTipoCambio.Enabled = True
            Me.txtTipoCambio.Focus()

            Me.Grid.Column(Me.iGyFolio).Width = 50
            Me.Grid.Column(Me.iGyFecha).Width = 60
            Me.Grid.Column(Me.iGyTotal).Visible = False
            Me.Grid.Column(Me.iGySaldo).Visible = False
            Me.Grid.Column(Me.iGyTotalDlls).Visible = True
            Me.Grid.Column(Me.iGySaldoDlls).Visible = True
            Me.Grid.Column(Me.iGyDiferencia).Visible = True
            Me.Grid.Column(Me.iGyPagoPesos).Visible = True
        Else
            Me.txtTipoCambio.Enabled = False : Me.txtTipoCambio.Text = ""
            Me.lblTipoCambio.Enabled = False
            Me.Grid.Column(Me.iGyFolio).Width = 95
            Me.Grid.Column(Me.iGyFecha).Width = 90
            Me.Grid.Column(Me.iGyTotal).Visible = True
            Me.Grid.Column(Me.iGySaldo).Visible = True
            Me.Grid.Column(Me.iGyTotalDlls).Visible = False
            Me.Grid.Column(Me.iGySaldoDlls).Visible = False
            Me.Grid.Column(Me.iGyDiferencia).Visible = False
            Me.Grid.Column(Me.iGyPagoPesos).Visible = False
        End If
    End Sub

    Private Sub txtTipoCambio_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTipoCambio.KeyDown
        If e.KeyCode = Keys.Return Then
            If valorNumerico(Me.txtTipoCambio.Text) <= 0 Or valorNumerico(Me.txtTipoCambio.Text) > 20 Then
                MsgBox("Tipo de cambio incorrecto", MsgBoxStyle.Information, "Validación de tipo de cambio")
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
            Me.CkbAnticipo.Focus()
        End If
    End Sub

    Private Sub CkbAnticipo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CkbAnticipo.CheckedChanged
        If Me.CkbAnticipo.Checked = True Then
            Me.txtAnticipo.Visible = True
            Me.lblDisplayAnticipo.Visible = True
            Me.txtAnticipo.Focus()
        Else
            Me.txtAnticipo.Visible = False
            Me.lblDisplayAnticipo.Visible = False
            Me.btnAgregarDocumentosClientes.Focus()
        End If
    End Sub

    Private Sub txtAnticipo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAnticipo.KeyDown
        If e.KeyCode = Keys.Return Then
            If txtLEN(Me.txtAnticipo.Text) = True Then
                Me.txtAnticipo.Text = FormatImporteContable(CDbl(Me.txtAnticipo.Text))
                'Me.CalculaImporteDolares()
                SendKeys.Send("{TAB}")
            End If
        End If
    End Sub

    Private Sub CkbAnticipo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CkbAnticipo.KeyDown
        If e.KeyCode = Keys.Return Then
            If Me.CkbAnticipo.Checked = False Then
                Me.btnAgregarDocumentosClientes.Focus
            End If
        End If
    End Sub

    Private Sub LblPoliza_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LblPoliza.LinkClicked
        Dim Child As New Frm_Contabilidad_Captura_Polizas()
        Child.FolioPolizaConsultaExterior = Me.LblPoliza.Text
        Child.ShowDialog()
        Child.Dispose()
    End Sub

    Private Sub Grid1_CellChanging(ByVal Sender As Object, ByVal e As FlexCell.Grid.CellChangingEventArgs) Handles Grid.CellChanging
        Try
            Dim Columna As Integer = e.Col, Renglon As Integer = e.Row
            Dim dPago As Double
            If e.Col = Me.iGySeleccion And e.Row > 0 Then
                If Me.Grid.Cell(Renglon, Me.iGySeleccion).Text = "1" And Me.ClickSinEjecutar = False Then
                    'If Me.ckbDolares.Checked = True Then
                    If Me.cboMoneda.SelectedIndex = 1 Then
                        If valorNumerico(Me.txtTipoCambio.Text) <= 0 Or valorNumerico(Me.txtTipoCambio.Text) > 20 Then
                            MsgBox("Tipo de cambio incorrecto", MsgBoxStyle.Information, "Validación de tipo de cambio")
                            Me.txtTipoCambio.Focus()
                            Exit Sub
                        End If
                        dPago = valorNumerico(Me.Grid.Cell(Renglon, Me.iGySaldoDlls).Text)
                        If dPago > 0 Then
                            Me.ClickSinEjecutar = True
                            Me.Grid.Cell(Renglon, Me.iGyPago).Text = dPago.ToString
                            Me.Grid.Cell(Renglon, Me.iGyPagoPesos).Text = (valorNumerico(Me.Grid.Cell(Renglon, Me.iGyPago).Text) * valorNumerico(Me.txtTipoCambio.Text)).ToString
                            Me.Grid.Cell(Renglon, Me.iGyDiferencia).Text = ((valorNumerico(Me.Grid.Cell(Renglon, Me.iGySaldo).Text) - valorNumerico(Me.Grid.Cell(Renglon, Me.iGyPagoPesos).Text)) * -1).ToString
                            Me.ClickSinEjecutar = False
                        End If
                    Else
                        dPago = valorNumerico(Me.Grid.Cell(Renglon, Me.iGySaldo).Text)
                        If dPago > 0 Then
                            Me.ClickSinEjecutar = True
                            Me.Grid.Cell(Renglon, Me.iGyPago).Text = dPago.ToString
                            Me.ClickSinEjecutar = False
                        End If
                    End If

                Else
                    Me.Grid.Cell(Renglon, Me.iGyPago).Text = "0"
                    Me.Grid.Cell(Renglon, Me.iGyPagoPesos).Text = "0"
                    Me.Grid.Cell(Renglon, Me.iGyDiferencia).Text = "0"
                End If
            End If

            Me.Totales()

        Catch ex As Exception
            HandleError(Me.Name, "Grid1_CellChanging", ex)
        End Try
    End Sub

    Private Sub Grid1_KeyDown(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Grid.KeyDown
        Try
            Dim Columna As Integer = Me.Grid.Selection.FirstCol, Renglon As Integer = Me.Grid.Selection.FirstRow
            Dim StrCod As String = Me.Grid.Cell(Renglon, Columna).Text

            Dim dPago As Double

            Select Case e.KeyCode
                Case Keys.Enter
                    Select Case Columna
                        'Case 1, 2, 3, 4, 5, 6
                        '    Me.Grid1.Cell(Renglon, Columna).SetFocus()
                        'Case 6
                        '    Me.Grid1.Cell(Renglon, 6).SetFocus()

                        Case Me.iGyPago
                            dPago = valorNumerico(Me.Grid.Cell(Renglon, Me.iGyPago).Text)
                            If dPago > 0 And txtLEN(Me.Grid.Cell(Renglon, Me.iGyFolio).Text) = True Then
                                'If Me.ckbDolares.Checked = False Then
                                If Me.cboMoneda.SelectedIndex = 0 Then
                                    If dPago > valorNumerico(Me.Grid.Cell(Renglon, Me.iGySaldo).Text) And Me.Grid.Locked = False Then
                                        MsgBox("El pago en el renglón: " & Renglon & " es mayor al saldo del documento favor de revisar.", MsgBoxStyle.Exclamation, "Validación de Importes de CXC")
                                        Me.Grid.Cell(Renglon, Me.iGyPago).SetFocus()
                                        Exit Sub
                                    End If
                                Else
                                    If dPago > valorNumerico(Me.Grid.Cell(Renglon, Me.iGySaldoDlls).Text) And Me.Grid.Locked = False Then
                                        MsgBox("El pago en el renglón: " & Renglon & " es mayor al saldo del documento favor de revisar.", MsgBoxStyle.Exclamation, "Validación de Importes de CXC")
                                        Me.Grid.Cell(Renglon, Me.iGyPago).SetFocus()
                                        Exit Sub
                                    End If
                                    If valorNumerico(Me.Grid.Cell(Renglon, Me.iGyTotalDlls).Text) <> valorNumerico(Me.Grid.Cell(Renglon, Me.iGyPago).Text) And valorNumerico(Me.Grid.Cell(Renglon, Me.iGySaldoDlls).Text) <> valorNumerico(Me.Grid.Cell(Renglon, Me.iGyPago).Text) Then
                                        'Si solo es un pago parcial el abono en pesos sera segun al tipo de cambio de la venta
                                        Dim oVenta As New Class_Ventas_Global
                                        oVenta = New Class_Ventas_Global(Me.Grid.Cell(Renglon, Me.iGyFolio).Text)
                                        Me.Grid.Cell(Renglon, Me.iGyPagoPesos).Text = (valorNumerico(Me.Grid.Cell(Renglon, Me.iGyPago).Text) * oVenta.TIPO_DE_CAMBIO).ToString
                                        Me.Grid.Cell(Renglon, Me.iGyDiferencia).Text = ((valorNumerico(Me.Grid.Cell(Renglon, Me.iGySaldo).Text) - valorNumerico(Me.Grid.Cell(Renglon, Me.iGyPagoPesos).Text)) * -1).ToString
                                    Else
                                        Me.Grid.Cell(Renglon, Me.iGyPagoPesos).Text = (valorNumerico(Me.Grid.Cell(Renglon, Me.iGyPago).Text) * valorNumerico(Me.txtTipoCambio.Text)).ToString
                                        Me.Grid.Cell(Renglon, Me.iGyDiferencia).Text = ((valorNumerico(Me.Grid.Cell(Renglon, Me.iGySaldo).Text) - valorNumerico(Me.Grid.Cell(Renglon, Me.iGyPagoPesos).Text)) * -1).ToString
                                    End If
                                End If
                            ElseIf dPago > 0 And Me.Grid.Rows = Renglon Then
                                Me.Grid.Rows = Me.Grid.Rows + 1
                            End If
                    End Select
                Case Keys.F8
                    If Me.Grid.Rows > 2 Then
                        Me.Grid.Selection.DeleteByRow()
                        'e.SuppressKeyPress = True
                    Else
                        Me.InicializaGrid()
                    End If
            End Select
            Me.Totales()

        Catch ex As Exception
            HandleError(Me.Name, "Grid1_KeyDown", ex)
        End Try
    End Sub

    Private Sub TotalesLista()
        Dim i As Integer, dPago As Double, sCodigoClientes As String, oCliente As Class_CatClientes

        Try
            Me.lstClientesAgregados.Items.Clear()

            For i = 1 To Me.Grid.Rows - 1
                sCodigoClientes = Me.Grid.Cell(i, Me.iGyCodigoCliente).Text
                dPago = valorNumerico(Me.Grid.Cell(i, Me.iGyPago).Text)
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

        Catch ex As Exception
            HandleError(Me.Name, "TotalesLista", ex)
        End Try
    End Sub

    Private Sub btnDepositosAnterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDepositosAnterior.Click
        Me.NavegadorDepositos("Anterior")
    End Sub

    Private Sub btnDepositosSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDepositosSiguiente.Click
        Me.NavegadorDepositos("Siguiente")
    End Sub

#Region "Eventos Genericos"
    Private Sub txt_Enter(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim oTexBox As TextBox = CType(sender, TextBox)
        oTexBox.SelectAll()
    End Sub

    Private Sub txt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbDocumento.KeyDown, dtFecha.KeyDown, CboMedioDePago.KeyDown, CboBancos.KeyDown, cboMoneda.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtNumerosEnterosKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCuentaBancaria.KeyPress
        txtSoloNumerosEnteros(e)
        txtNoBeep(e)
    End Sub

    Private Sub txtNumerosDecimalKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAnticipo.KeyPress
        Dim txt As TextBox = CType(sender, TextBox)
        txtSoloNumerosDecimales(e, txt.Text)
        txtNoBeep(e)
    End Sub

    Private Sub txtTextoKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CmbDocumento.KeyPress, TxtFolio.KeyPress, _
    dtFecha.KeyPress, TxtConcepto.KeyPress, TxtCodigoCliente.KeyPress, TxtReferencia.KeyPress
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
            Me.LblStatus.Text = "N"

            Me.TxtCodigoCliente.Text = ""
            Me.LblCliente.Text = ""
            Me.CboBancos.SelectedIndex = -1
            Me.CboMedioDePago.SelectedIndex = -1
            Me.TxtReferencia.Text = ""
            Me.txtAnticipo.Text = "" : Me.CkbAnticipo.Checked = False
            'Me.ckbDolares.Checked = False : Me.txtTipoCambio.Text = ""
            Me.TxtTotal.Text = ""

            Me.InicializaGrid()

            Me.DesplegarMonedas()
            Me.cboMoneda.SelectedIndex = 0 : Me.txtTipoCambio.Text = ""

            Me.lstClientesAgregados.Items.Clear()
        Catch ex As Exception
            HandleError(Me.Name, "Inicializa", ex)
        End Try
    End Sub

    Private Sub InicializaGrid()
        Try
            Me.Grid.DataSource = Nothing
            FG_Grid_Limpiar(Grid)

            'Creamos el Grid
            Me.Grid.Rows = 2
            Me.Grid.Cols = 17
            Me.Grid.DisplayRowNumber = True

            Me.FormateaGrid()
        Catch ex As Exception
            HandleError(Me.Name, "Inicializa", ex)
        End Try
    End Sub

    Private Sub FormateaGrid()
        Try
            Me.Grid.Column(Me.iGyCodigoCliente).Width = 45
            Me.Grid.Column(Me.iGyNombreCliente).Width = 120
            Me.Grid.Column(Me.iGyFecha).Width = 90
            Me.Grid.Column(Me.iGyFolio).Width = 95
            Me.Grid.Column(Me.iGyMedioPago).Width = 95
            Me.Grid.Column(Me.iGyBanco).Width = 80
            Me.Grid.Column(Me.iGyTotal).Width = 80
            Me.Grid.Column(Me.iGySaldo).Width = 80
            Me.Grid.Column(Me.iGyTotalDlls).Width = 80
            Me.Grid.Column(Me.iGySaldoDlls).Width = 80
            Me.Grid.Column(Me.iGyPago).Width = 80
            Me.Grid.Column(Me.iGyPagoPesos).Width = 80
            Me.Grid.Column(Me.iGySeleccion).Width = 60
            Me.Grid.Column(Me.iGyReferencia).Width = 95
            Me.Grid.Column(Me.iGyDiferencia).Width = 80
            Me.Grid.Column(Me.iGyIvaPorPagar).Width = 80

            Me.Grid.Cell(0, Me.iGyCodigoCliente).Text = "Código"
            Me.Grid.Cell(0, Me.iGyNombreCliente).Text = "Nombre"
            Me.Grid.Cell(0, Me.iGyFecha).Text = "Fecha"
            Me.Grid.Cell(0, Me.iGyFolio).Text = "Folio"
            Me.Grid.Cell(0, Me.iGyMedioPago).Text = "Medio de pago"
            Me.Grid.Cell(0, Me.iGyBanco).Text = "Banco"
            Me.Grid.Cell(0, Me.iGyTotal).Text = "Total"
            Me.Grid.Cell(0, Me.iGySaldo).Text = "Saldo"
            Me.Grid.Cell(0, Me.iGyTotalDlls).Text = "Total Dlls"
            Me.Grid.Cell(0, Me.iGySaldoDlls).Text = "Saldo Dlls"
            Me.Grid.Cell(0, Me.iGyPago).Text = "Pagar"
            Me.Grid.Cell(0, Me.iGyPagoPesos).Text = "Pagar Pesos"
            Me.Grid.Cell(0, Me.iGySeleccion).Text = "Selección"
            Me.Grid.Cell(0, Me.iGyReferencia).Text = "Referencia"
            Me.Grid.Cell(0, Me.iGyDiferencia).Text = "Diferencia"
            Me.Grid.Cell(0, Me.iGyIvaPorPagar).Text = "IvaPorPagar"

            Me.DespliegaCombosGrid()

            Me.Grid.Column(Me.iGyFecha).CellType = FlexCell.CellTypeEnum.DateTime
            Me.Grid.Column(Me.iGyFecha).FormatString = "dd-MMM-yy"

            Me.Grid.Column(Me.iGyTotal).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
            Me.Grid.Column(Me.iGyTotal).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.iGyTotal).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
            Me.Grid.Column(Me.iGyTotal).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.iGySaldo).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
            Me.Grid.Column(Me.iGySaldo).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.iGySaldo).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
            Me.Grid.Column(Me.iGySaldo).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.iGyPago).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
            Me.Grid.Column(Me.iGyPago).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.iGyPago).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
            Me.Grid.Column(Me.iGyPago).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.iGyPagoPesos).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
            Me.Grid.Column(Me.iGyPagoPesos).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.iGyPagoPesos).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
            Me.Grid.Column(Me.iGyPagoPesos).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.iGyTotalDlls).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
            Me.Grid.Column(Me.iGyTotalDlls).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.iGyTotalDlls).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
            Me.Grid.Column(Me.iGyTotalDlls).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.iGySaldoDlls).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
            Me.Grid.Column(Me.iGySaldoDlls).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.iGySaldoDlls).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
            Me.Grid.Column(Me.iGySaldoDlls).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.iGyDiferencia).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
            Me.Grid.Column(Me.iGyDiferencia).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.iGyDiferencia).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
            Me.Grid.Column(Me.iGyDiferencia).Alignment = FlexCell.AlignmentEnum.RightCenter


            Me.Grid.Column(Me.iGyIvaPorPagar).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
            Me.Grid.Column(Me.iGyIvaPorPagar).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.iGyIvaPorPagar).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
            Me.Grid.Column(Me.iGyIvaPorPagar).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.iGySeleccion).CellType = FlexCell.CellTypeEnum.CheckBox

            Me.Grid.Refresh()

            Me.Grid.Column(Me.iGyCodigoCliente).Locked = True
            Me.Grid.Column(Me.iGyNombreCliente).Locked = True
            Me.Grid.Column(Me.iGyFecha).Locked = True
            Me.Grid.Column(Me.iGyFolio).Locked = True
            Me.Grid.Column(Me.iGyMedioPago).Locked = False
            Me.Grid.Column(Me.iGyBanco).Locked = False
            Me.Grid.Column(Me.iGyTotal).Locked = True
            Me.Grid.Column(Me.iGySaldo).Locked = True
            Me.Grid.Column(Me.iGyTotalDlls).Locked = True
            Me.Grid.Column(Me.iGySaldoDlls).Locked = True
            Me.Grid.Column(Me.iGyPago).Locked = False
            Me.Grid.Column(Me.iGyPagoPesos).Locked = True
            Me.Grid.Column(Me.iGyReferencia).Locked = False
            Me.Grid.Column(Me.iGyDiferencia).Locked = True
            Me.Grid.Column(Me.iGyTotalDlls).Visible = False
            Me.Grid.Column(Me.iGySaldoDlls).Visible = False
            Me.Grid.Column(Me.iGyPagoPesos).Visible = False
            Me.Grid.Column(Me.iGyDiferencia).Visible = False
            Me.Grid.Column(Me.iGyIvaPorPagar).Visible = True

        Catch ex As Exception
            HandleError(Me.Name, "FormateaGrid", ex)
        End Try
    End Sub

    Private Sub DespliegaCombosGrid()
        Try
            Dim dTabla As New DataTable("detalle"), da As SqlDataAdapter
            Dim sSQL As String = ("SELECT ID_MEDIO_PAGO,NOMBRE_MEDIO_PAGO FROM SIS_MEDIOS_PAGO ORDER BY NOMBRE_MEDIO_PAGO")

            da = New SqlDataAdapter(sSQL, Empresa_Sistema.conexion)
            da.Fill(dTabla)
            da.Dispose()

            Me.Grid.Column(Me.iGyMedioPago).CellType = FlexCell.CellTypeEnum.ComboBox
            Me.Grid.ComboBox(Me.iGyMedioPago).DataSource = dTabla
            Me.Grid.ComboBox(Me.iGyMedioPago).DisplayMember = "NOMBRE_MEDIO_PAGO"
            Me.Grid.ComboBox(Me.iGyMedioPago).ValueMember = "ID_MEDIO_PAGO"

            Dim dTabla1 As New DataTable("detalle1"), da1 As SqlDataAdapter
            Dim sSQL1 As String = ("SELECT CODIGO_BANCO,NOMBRE_BANCO FROM CAT_BANCOS ORDER BY NOMBRE_BANCO")

            da1 = New SqlDataAdapter(sSQL1, Empresa_Sistema.conexion)
            da1.Fill(dTabla1)
            da1.Dispose()

            Me.Grid.Column(Me.iGyBanco).CellType = FlexCell.CellTypeEnum.ComboBox
            Me.Grid.ComboBox(Me.iGyBanco).DataSource = dTabla1
            Me.Grid.ComboBox(Me.iGyBanco).DisplayMember = "NOMBRE_BANCO"
            Me.Grid.ComboBox(Me.iGyBanco).ValueMember = "CODIGO_BANCO"

        Catch ex As Exception
            HandleError(Me.Name, "DespliegaCombosGrid", ex)
        End Try
        
    End Sub

    Private Sub AgregarDocumentosClientes()
        Dim sql As Class_find, iRow As Integer

        Try
            If Me.TxtCodigoCliente.TextLength = 0 Then
                MsgBox("Asígne el código del cliente.", MsgBoxStyle.Exclamation, Me.Text)
                Me.TxtCodigoCliente.Focus()
                Exit Sub
            Else
                sql = New Class_find("Select NOMBRE_CLIENTE,CUENTA_CONTABLE From CAT_CLIENTES Where CODIGO_CLIENTE='" & sReplace(Me.TxtCodigoCliente.Text) & "' AND ESTATUS='A' AND CODIGO_ZONA=" & Usuario.Codigo_Plaza)
                If sql.Result1 = "" Then
                    MsgBox("El código de cliente que intenta buscar no existe o esta dado de Baja, favor de intentar con otro código.", MsgBoxStyle.Critical, "Validación de Cliente")
                    Me.LblCliente.Text = ""
                    Me.TxtCodigoCliente.Focus()
                    Exit Sub
                End If
            End If

            If Me.CboMedioDePago.SelectedIndex = -1 Then
                MsgBox("Seleccione favor de un medio de pago.", MsgBoxStyle.Critical, "Validación de Medios de Pago")
                Me.CboMedioDePago.Focus()
                Exit Sub
            End If

            If Me.CboBancos.SelectedIndex = -1 Then
                MsgBox("Seleccione de favor un banco.", MsgBoxStyle.Critical, "Validación de bancos")
                Me.CboBancos.Focus()
                Exit Sub
            End If

            Me.BorraDocumentosSinPago()

            For iRow = 1 To Me.Grid.Rows - 1
                If Me.Grid.Cell(iRow, Me.iGyCodigoCliente).Text.Length > 0 AndAlso Me.TxtCodigoCliente.Text = Me.Grid.Cell(iRow, Me.iGyCodigoCliente).Text Then
                    If MsgBox("Ya asignó al cliente " & Me.TxtCodigoCliente.Text & " a la lista de pagos, esta seguro de volver agregarlo?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then
                        Exit Sub
                    Else
                        Exit For
                    End If
                End If
            Next

            'Agregar al grid folios de ventas, que no hayan sido agregados, y en caso de que ya , en msg mostrarlo.

            Me.CargaFacturas()

        Catch ex As Exception
            HandleError(Me.Name, "AgregarDocumentosClientes", ex)
        End Try
    End Sub

    Private Sub AgregarAnticipoClientes()
        Dim sql As Class_find, iRow As Integer

        Try
            If Me.TxtCodigoCliente.TextLength = 0 Then
                MsgBox("Asígne el código del cliente.", MsgBoxStyle.Exclamation, Me.Text)
                Me.TxtCodigoCliente.Focus()
                Exit Sub
            Else
                sql = New Class_find("SELECT NOMBRE_CLIENTE,CUENTA_CONTABLE FROM CAT_CLIENTES WHERE CODIGO_CLIENTE='" & sReplace(Me.TxtCodigoCliente.Text) & "' AND ESTATUS='A'")
                If sql.Result1 = "" Then
                    MsgBox("El código de cliente que intenta buscar no existe o esta dado de baja, favor de intentar con otro código.", MsgBoxStyle.Critical, "Validación de Clientes")
                    Me.LblCliente.Text = ""
                    Me.TxtCodigoCliente.Focus()
                    Exit Sub
                End If
            End If

            If Me.CboMedioDePago.SelectedIndex = -1 Then
                MsgBox("Seleccione favor de un medio de pago.", MsgBoxStyle.Exclamation, "Validación de Medios de Pago")
                Me.CboMedioDePago.Focus()
                Exit Sub
            End If

            If Me.CboBancos.SelectedIndex = -1 Then
                MsgBox("Seleccione de favor un banco.", MsgBoxStyle.Exclamation, "Validación de bancos")
                Me.CboBancos.Focus()
                Exit Sub
            End If

            Me.BorraDocumentosSinPago()

            For iRow = 1 To Me.Grid.Rows - 1
                If Me.Grid.Cell(iRow, Me.iGyCodigoCliente).Text.Length > 0 Then
                    If Me.TxtCodigoCliente.Text = Me.Grid.Cell(iRow, Me.iGyCodigoCliente).Text Then
                        If MsgBox("Ya asignó al cliente " & Me.TxtCodigoCliente.Text & " a la lista de pagos, esta seguro de volver agregarlo?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then
                            Exit Sub
                        Else
                            Exit For
                        End If
                    End If
                End If
            Next

            Me.CargaAnticipo()

        Catch ex As Exception
            HandleError(Me.Text, "AgregarAnticipoClientes", ex)
        End Try

    End Sub

    Private Sub CargaFacturas()
        Dim Conexion As New SqlConnection(Empresa_Sistema.conexion)
        Dim i As Integer = 1, oCliente As Class_CatClientes, sMedioPago As String, oBanco As Class_CatBancos, sSaldoDlls As String = ""
        Dim sql As Class_find

        'If Me.ckbDolares.Checked = True Then
        '    sSaldoDlls = "AND SALDO_DOLARES>0 "
        'End If

        If Me.cboMoneda.SelectedIndex = 1 Then
            sSaldoDlls = "AND SALDO_DOLARES>0 "
        End If
        Dim cmd As New SqlCommand("SELECT FECHA,FOLIO_VENTA,TOTAL,SALDO,TOTAL_DOLARES,SALDO_DOLARES, CASE WHEN TOTAL=SALDO THEN IMPUESTO ELSE 0 END IVA " & _
                                  "FROM VENTA_GLOBAL WHERE CODIGO_CLIENTE='" & sReplace(Me.TxtCodigoCliente.Text) & "' AND SALDO>0 " & sSaldoDlls & " AND CODIGO_PLAZA=" & Plaza.CODIGO_PLAZA & " ORDER BY FECHA", Conexion)

        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                oCliente = New Class_CatClientes(sReplace(Me.TxtCodigoCliente.Text))

                sql = New Class_find("SELECT NOMBRE_MEDIO_PAGO FROM SIS_MEDIOS_PAGO WHERE ID_MEDIO_PAGO=" & sReplace(Me.CboMedioDePago.SelectedValue.ToString) & " AND ESTATUS='A'")
                sMedioPago = sql.Result1

                oBanco = New Class_CatBancos(Me.CboBancos.SelectedValue.ToString)

                Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.HasRows Then

                    i = Me.Grid.Rows - 1

                    If Me.Grid.Cell(i, Me.iGyCodigoCliente).Text.Length > 0 Then
                        i = i + 1
                    End If

                    While dReader.Read()

                        If ExisteYaDocumentoVenta(dReader("FOLIO_VENTA").ToString) = True Then
                            MsgBox("El folio de venta " & dReader("FOLIO_VENTA").ToString & " ya existe, no se volverá a agregar.", MsgBoxStyle.Exclamation, Me.Text)
                        Else
                            Me.Grid.Rows = Me.Grid.Rows + 1

                            Me.Grid.Cell(i, Me.iGyCodigoCliente).Text = oCliente.CODIGO_CLIENTE
                            Me.Grid.Cell(i, Me.iGyNombreCliente).Text = oCliente.NOMBRE_CLIENTE
                            Me.Grid.Cell(i, Me.iGyFecha).Text = dReader("FECHA").ToString
                            Me.Grid.Cell(i, Me.iGyFolio).Text = dReader("FOLIO_VENTA").ToString
                            Me.Grid.Cell(i, Me.iGyMedioPago).Text = Me.CboMedioDePago.Text
                            Me.Grid.Cell(i, Me.iGyBanco).Text = Me.CboBancos.Text
                            Me.Grid.Cell(i, Me.iGyTotal).Text = dReader("TOTAL").ToString
                            Me.Grid.Cell(i, Me.iGySaldo).Text = dReader("SALDO").ToString
                            Me.Grid.Cell(i, Me.iGyTotalDlls).Text = dReader("TOTAL_DOLARES").ToString
                            Me.Grid.Cell(i, Me.iGySaldoDlls).Text = dReader("SALDO_DOLARES").ToString
                            Me.Grid.Cell(i, Me.iGyPago).Text = CStr(0)
                            Me.Grid.Cell(i, Me.iGyPagoPesos).Text = CStr(0)
                            Me.Grid.Cell(i, Me.iGyDiferencia).Text = CStr(0)
                            Me.Grid.Cell(i, Me.iGySeleccion).Text = Me.CboMedioDePago.SelectedValue.ToString
                            Me.Grid.Cell(i, Me.iGyReferencia).Text = Me.TxtReferencia.Text
                            Me.Grid.Cell(i, Me.iGyIvaPorPagar).Text = dReader("IVA").ToString

                            i = i + 1
                        End If
                    End While
                End If
                dReader.Close()

                Me.Totales()

            Catch ex As Exception
                HandleError(Me.Text, "CargaFacturas", ex)
            Finally
                Conexion.Close()
                cmd.Dispose()
            End Try
        End With
    End Sub

    Private Sub CargaAnticipo()
        Dim Conexion As New SqlConnection(Empresa_Sistema.conexion)
        Dim i As Integer = 1, oCliente As Class_CatClientes

        Try
            oCliente = New Class_CatClientes(sReplace(Me.TxtCodigoCliente.Text))

            i = Me.Grid.Rows - 1
            Me.Grid.Rows = Me.Grid.Rows + 1

            Me.Grid.Cell(i, Me.iGyCodigoCliente).Text = oCliente.CODIGO_CLIENTE
            Me.Grid.Cell(i, Me.iGyNombreCliente).Text = oCliente.NOMBRE_CLIENTE.ToString
            Me.Grid.Cell(i, Me.iGyFecha).Text = Me.dtFecha.Value.ToString
            Me.Grid.Cell(i, Me.iGyFolio).Text = ""
            Me.Grid.Cell(i, Me.iGyMedioPago).Text = Me.CboMedioDePago.Text
            Me.Grid.Cell(i, Me.iGyBanco).Text = Me.CboBancos.Text
            Me.Grid.Cell(i, Me.iGyTotal).Text = "0"
            Me.Grid.Cell(i, Me.iGySaldo).Text = "0"
            Me.Grid.Cell(i, Me.iGyTotalDlls).Text = "0"
            Me.Grid.Cell(i, Me.iGySaldoDlls).Text = "0"
            Me.Grid.Cell(i, Me.iGyPago).Text = Me.txtAnticipo.Text
            Me.Grid.Cell(i, Me.iGyDiferencia).Text = "0"
            Me.Grid.Cell(i, Me.iGySeleccion).Text = ""
            Me.Grid.Cell(i, Me.iGyReferencia).Text = Me.TxtReferencia.Text
            Me.Grid.Cell(i, Me.iGyIvaPorPagar).Text = "0"

            Me.Totales()

        Catch ex As Exception
            HandleError(Me.Text, "CargaAnticipo", ex)
        Finally
            Conexion.Close()
        End Try
    End Sub

    Private Function ExisteYaDocumentoVenta(ByVal sFolioVenta As String) As Boolean
        Dim iRow As Integer
        For iRow = 1 To Me.Grid.Rows - 1
            If Me.Grid.Cell(iRow, Me.iGyCodigoCliente).Text.Length > 0 Then
                If sFolioVenta = Me.Grid.Cell(iRow, Me.iGyFolio).Text Then
                    Return True
                End If
            End If
        Next iRow
    End Function

    Private Sub BorraDocumentosSinPago()
        Try
            Dim iRow As Integer = 1
            'Si solo ahy un renglon grid y esta en blanco no ahy nada que borrar
            If Me.Grid.Rows = 2 AndAlso Me.Grid.Cell(iRow, Me.iGyCodigoCliente).Text.Length = 0 Then
                Exit Sub
            End If

            While iRow <= Me.Grid.Rows - 1
                If Me.Grid.Cell(iRow, Me.iGyCodigoCliente).Text.Length > 0 AndAlso valorNumerico(Me.Grid.Cell(iRow, Me.iGyPago).Text) = 0 Then
                    Me.Grid.RemoveItem(iRow)
                Else
                    iRow += 1
                End If
            End While

            Me.Totales()
            Application.DoEvents()

        Catch ex As Exception
            HandleError(Me.Name, "BorraDocumentosSinPago", ex)
        End Try
    End Sub

    Private Sub Totales()
        Try
            Me.TxtTotal.Text = FormatImporteContable(FG_Grid_SumaCol(Me.Grid, CShort(Me.iGyPago)))

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
            If MsgBox("Deseas grabar el documento " & Me.CmbDocumento.Text & " con el folio : " & Me.TxtFolio.Text & "?", CType(vbYesNo + vbQuestion, MsgBoxStyle), "Grabar") = MsgBoxResult.No Then
                Exit Function
            End If

            Me.Totales()

            If Me.Validar() = False Then
                Exit Function
            End If

            If Me.ValidaPrePoliza() = False Then
                Exit Function
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
            End If

        Catch ex As Exception
            HandleError(Me.Name, "GestionaGrabar", ex)
        End Try

        Return bResultado
    End Function

    Private Function Grabar() As Boolean
        Dim bResultado As Boolean = False
        Dim i As Integer, dPago As Double

        Try
            Me.GeneraFolio()

            Me.oBancosCXC = New Class_Bancos_CXC
            'If Me.oBancosCXC.Existe = True Then
            '    Exit Function
            'End If

            oBancosCXC.FOLIO_BANCO = Me.TxtFolio.Text
            oBancosCXC.ID_CUENTA_BANCARIA = CInt(Me.TxtCuentaBancaria.Text)
            oBancosCXC.TOTAL = valorNumerico(Me.TxtTotal.Text)
            oBancosCXC.CODIGO_DOCUMENTO = (Me.CmbDocumento.SelectedValue.ToString)
            oBancosCXC.FECHA = Me.dtFecha.Value
            oBancosCXC.CONCEPTO1 = Me.TxtConcepto.Text.ToUpper
            oBancosCXC.CODIGO_PLAZA = Usuario.Codigo_Plaza
            'If Me.ckbDolares.Checked = True Then
            If Me.cboMoneda.SelectedIndex = 1 Then
                oBancosCXC.TIPO_DE_CAMBIO = valorNumerico(Me.txtTipoCambio.Text)
                oBancosCXC.TOTAL_DOLARES = valorNumerico(Me.TxtTotal.Text)
                oBancosCXC.TOTAL = valorNumerico(Me.TxtTotal.Text) * valorNumerico(Me.txtTipoCambio.Text)
            Else
                oBancosCXC.TOTAL = valorNumerico(Me.TxtTotal.Text)
            End If
            oBancosCXC.Inserta_Global()
            Me.TxtFolio.Text = oBancosCXC.FOLIO_BANCO

            Me.oCxcAfectaDocumentos = New Class_CXC_Afecta_Documentos
            For i = 1 To Me.Grid.Rows - 1
                dPago = valorNumerico(Me.Grid.Cell(i, Me.iGyPago).Text)
                If dPago > 0 Then
                    oCxcAfectaDocumentos.FOLIO_CXC = "" 'Me.TxtFolio.Text
                    oCxcAfectaDocumentos.CODIGO_CLIENTE = Me.Grid.Cell(i, Me.iGyCodigoCliente).Text
                    oCxcAfectaDocumentos.FECHA = Me.dtFecha.Value
                    oCxcAfectaDocumentos.FOLIO_REFERENCIA = Me.Grid.Cell(i, Me.iGyFolio).Text 'folio de la compra
                    oCxcAfectaDocumentos.FOLIO_REFERENCIA_USUARIO = Me.Grid.Cell(i, Me.iGyReferencia).Text 'Folio factura Cliente de la venta, no tenemos
                    oCxcAfectaDocumentos.CONCEPTO1 = Me.TxtConcepto.Text
                    oCxcAfectaDocumentos.CONCEPTO2 = ""
                    oCxcAfectaDocumentos.CODIGO_PLAZA = Usuario.Codigo_Plaza
                    'If Me.ckbDolares.Checked = True Then
                    If Me.cboMoneda.SelectedIndex = 1 Then
                        oCxcAfectaDocumentos.TOTAL_DOLARES = dPago
                        If valorNumerico(Me.Grid.Cell(i, Me.iGyTotalDlls).Text) <> valorNumerico(Me.Grid.Cell(i, Me.iGyPago).Text) And valorNumerico(Me.Grid.Cell(i, Me.iGySaldoDlls).Text) <> valorNumerico(Me.Grid.Cell(i, Me.iGyPago).Text) Then
                            'Si solo es un pago parcial el abono en pesos sera segun al tipo de cambio de la venta
                            Dim oVenta As New Class_Ventas_Global
                            oVenta = New Class_Ventas_Global(Me.Grid.Cell(i, Me.iGyFolio).Text)
                            oCxcAfectaDocumentos.TOTAL = valorNumerico(Me.Grid.Cell(i, Me.iGyPago).Text) * oVenta.TIPO_DE_CAMBIO
                        Else
                            oCxcAfectaDocumentos.TOTAL = valorNumerico(Me.Grid.Cell(i, Me.iGyPagoPesos).Text) + valorNumerico(Me.Grid.Cell(i, Me.iGyDiferencia).Text) 'dPago
                        End If
                    Else
                        oCxcAfectaDocumentos.TOTAL = dPago
                    End If
                    oCxcAfectaDocumentos.TIPO_DE_CAMBIO = valorNumerico(Me.txtTipoCambio.Text)
                    oCxcAfectaDocumentos.FOLIO_BANCO = Me.TxtFolio.Text 'Se tiene que poner el del texbox porque se regreso el folio al Inserta_Global
                    Dim sql As New Class_find("SELECT ID_MEDIO_PAGO FROM SIS_MEDIOS_PAGO WHERE NOMBRE_MEDIO_PAGO='" & Me.Grid.Cell(i, Me.iGyMedioPago).Text & "'")
                    If txtLEN(sql.Result1) = True Then
                        oCxcAfectaDocumentos.ID_MEDIO_PAGO = CInt(sql.Result1)
                    End If
                    sql = New Class_find("SELECT CODIGO_BANCO FROM CAT_BANCOS WHERE NOMBRE_BANCO='" & Me.Grid.Cell(i, Me.iGyBanco).Text & "'")
                    If txtLEN(sql.Result1) = True Then
                        oCxcAfectaDocumentos.CODIGO_BANCO = sql.Result1
                    End If
                    bResultado = oCxcAfectaDocumentos.InsertarPagosClientes()
                End If
            Next i

        Catch ex As Exception
            HandleError(Me.Name, "Grabar", ex)
        Finally
            'Me.oBancosCXC = Nothing no hay porque borrarla
            Me.oCxcAfectaDocumentos = Nothing
        End Try

        Return bResultado
    End Function

    Private Function Validar() As Boolean
        Dim bResultado As Boolean = False
        Try
            If Plaza.ValidarPeriodoTrabajo(Me.dtFecha.Value) = False Then
                Exit Function
            End If

            If Usuario.ValidaPermisoUsuarioDocumentoSinAfectacionInventarios(Me.CmbDocumento.SelectedValue.ToString) = False Then
                MsgBox("El usuario " & Usuario.Nombre_Usuario & " no tiene permiso para realizar el movimiento.", MsgBoxStyle.Information, Me.Text)
                Exit Function
            End If

            Dim oCuentaBancaria As New Class_CatCuentasBancarias
            oCuentaBancaria = New Class_CatCuentasBancarias(CInt(Me.TxtCuentaBancaria.Text))

            If oCuentaBancaria.Existe = True Then
                'If Me.ckbDolares.Checked = True Then
                If Me.cboMoneda.SelectedIndex = 1 Then
                    If txtLEN(oCuentaBancaria.CUENTA_CONTABLE_DOLARES.ToString) = False Then
                        MsgBox("La cuenta bancaria que intenta debe tener cuenta en dolares, favor de intentar con otro codigo", MsgBoxStyle.Exclamation, "Validación de Cuentas Bancarias")
                        Me.TxtCuentaBancaria.Focus()
                        Exit Function
                    End If
                End If
            Else
                MsgBox("La cuenta bancaria que intenta buscar no existe, favor de intentar con otro codigo", MsgBoxStyle.Exclamation, "Validación de Cuentas Bancarias")
                Me.TxtCuentaBancaria.Focus()
                Exit Function
            End If

            Dim sql As New Class_find("SELECT 1 FROM CAT_CLIENTES WHERE CODIGO_CLIENTE='" & Me.TxtCodigoCliente.Text & "' AND ESTATUS='A' AND CODIGO_ZONA=" & Usuario.Codigo_Plaza)
            If sql.Result1 = "" Then
                MsgBox("El código de Cliente que intenta buscar no existe o esta dado de baja, favor de intentar con otro código.", MsgBoxStyle.Exclamation, "Validación de Clientees")
                Me.LblCliente.Text = ""
                Me.TxtCodigoCliente.Focus()
                Exit Function
            Else
                Me.LblCliente.Text = sql.Result1
            End If

            If valorNumerico(Me.TxtTotal.Text) <= 0 Then
                MsgBox("No asignó los documentos a pagar. El total a pagar debe ser mayor que cero.", MsgBoxStyle.Exclamation, Me.Nombre_Modulo)
                Exit Function
            End If

            Dim i As Integer
            For i = 1 To Grid.Rows - 1
                'If Me.ckbDolares.Checked = False Then
                If Me.cboMoneda.SelectedIndex = 0 Then
                    If valorNumerico(Me.Grid.Cell(i, Me.iGyPago).Text) > 0 And txtLEN(Me.Grid.Cell(i, Me.iGyFolio).Text) = True Then
                        sql = New Class_find("SELECT SALDO FROM VENTA_GLOBAL WHERE FOLIO_VENTA='" & Me.Grid.Cell(i, Me.iGyFolio).Text & "'")
                        Me.Grid.Cell(i, Me.iGySaldo).Text = sql.Result1
                        If valorNumerico(Me.Grid.Cell(i, Me.iGyPago).Text) > valorNumerico(Me.Grid.Cell(i, Me.iGySaldo).Text) Then
                            MsgBox("El pago en el renglón: " & i & " es mayor al saldo del documento favor de revisar.", MsgBoxStyle.Exclamation, "Validación de Importes de CXC")
                            Exit Function
                        End If
                    End If
                Else
                    If valorNumerico(Me.Grid.Cell(i, Me.iGyPago).Text) > 0 And txtLEN(Me.Grid.Cell(i, Me.iGyFolio).Text) = True Then
                        sql = New Class_find("SELECT SALDO_DOLARES FROM VENTA_GLOBAL WHERE FOLIO_VENTA='" & Me.Grid.Cell(i, Me.iGyFolio).Text & "'")
                        Me.Grid.Cell(i, Me.iGySaldoDlls).Text = sql.Result1
                        If valorNumerico(Me.Grid.Cell(i, Me.iGyPago).Text) > valorNumerico(Me.Grid.Cell(i, Me.iGySaldoDlls).Text) Then
                            MsgBox("El pago en el renglón: " & i & " es mayor al saldo del documento favor de revisar.", MsgBoxStyle.Exclamation, "Validación de Importes de CXC")
                            Exit Function
                        End If
                    End If
                End If
            Next i

            'If Me.ckbDolares.Checked = True Then
            If Me.cboMoneda.SelectedIndex = 1 Then
                If valorNumerico(Me.txtTipoCambio.Text) <= 0 Or valorNumerico(Me.txtTipoCambio.Text) > 20 Then
                    MsgBox("Tipo de cambio incorrecto", MsgBoxStyle.Information, "Validación de tipo de cambio")
                    Me.txtTipoCambio.Focus()
                    Exit Function
                Else
                    Me.CalculaImporteDolares()
                End If
            End If
            bResultado = True

        Catch ex As Exception
            HandleError(Me.Name, "Validar", ex)
        End Try

        Return bResultado
    End Function

    Private Sub CalculaImporteDolares()
        Dim i As Integer, dPago As Double
        Try
            For i = 1 To Me.Grid.Rows - 1
                dPago = valorNumerico(Me.Grid.Cell(i, Me.iGyPago).Text)
                If dPago > 0 Then
                    Dim oVenta As New Class_Ventas_Global
                    oVenta = New Class_Ventas_Global(Me.Grid.Cell(i, Me.iGyFolio).Text)
                    Me.Grid.Cell(i, Me.iGyPagoPesos).Text = (dPago * valorNumerico(Me.txtTipoCambio.Text)).ToString
                    Me.Grid.Cell(i, Me.iGyDiferencia).Text = ((valorNumerico(Me.Grid.Cell(i, Me.iGyPagoPesos).Text) - valorNumerico(Me.Grid.Cell(i, Me.iGySaldo).Text)) * -1).ToString
                End If
            Next i
        Catch ex As Exception
            HandleError(Me.Name, "CalculaImporteDolares", ex)
        End Try
    End Sub

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
            Case "A"
                Me.Cambia_Estado(enumEstados.APLICADO)
            Case "C"
                Me.Cambia_Estado(enumEstados.CANCELADO)
        End Select
    End Sub

    Private Sub DesplegarDocumentos()
        Try
            Dim oElementos As New Class_CatDocumentos
            With Me.CmbDocumento
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
                    .SelectedIndex = -1
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarMedioDePagos", ex)
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
            HandleError(Me.Name, "DesplegarBancos", ex)
        End Try
    End Sub

    Private Sub DesplegarMonedas()
        Dim oMoneda As New Class_CatMonedas
        Dim dTable As New DataTable

        With Me.cboMoneda
            .DisplayMember = "NOMBRE"
            .ValueMember = "CODIGO_MONEDA"
            dTable = oMoneda.ObtenerElementos
            dTable.Rows(2).Delete() 'Quita Euros del DataTable
            .DataSource = dTable
            If .Items.Count > 0 Then
                .SelectedIndex = 0
            End If
        End With
    End Sub

    Private Function ValidaPrePoliza() As Boolean
        Dim bResultado As Boolean = False

        Dim oCuentaBancaria As Class_CatCuentasBancarias
        Dim oCliente As Class_CatClientes
        Dim oContaCuenta As Class_CatCuentas

        Try
            If ExisteDocumento(Me.TxtFolio.Text) = True Then
                MsgBox("El folio del documento : " & Me.CmbDocumento.Text & " ya existe, verifíquelo.", MsgBoxStyle.Exclamation, "Contabilizar")
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
            Me.oFormaPoliza.Grid1.Cols = 9

            oCuentaBancaria = New Class_CatCuentasBancarias(CInt(Me.TxtCuentaBancaria.Text))
            'If Me.ckbDolares.Checked = False Then
            If Me.cboMoneda.SelectedIndex = 0 Then
                Dim i As Integer, R As Integer = 1, dPago As Double, ivaporpagar As Double = 0
                For i = 1 To Me.Grid.Rows - 1
                    If valorNumerico(Me.Grid.Cell(i, Me.iGyPago).Text) = valorNumerico(Me.Grid.Cell(i, Me.iGySaldo).Text) Then
                        dPago = valorNumerico(Me.Grid.Cell(i, Me.iGyPago).Text)
                        ivaporpagar = valorNumerico(Me.Grid.Cell(i, Me.iGyIvaPorPagar).Text)
                    Else
                        dPago = valorNumerico(Me.Grid.Cell(i, Me.iGyPago).Text)
                        ivaporpagar = 0
                    End If

                    If dPago > 0 Then
                        Me.oFormaPoliza.Grid1.Rows = Me.oFormaPoliza.Grid1.Rows + 1

                        oCliente = New Class_CatClientes(Me.Grid.Cell(i, Me.iGyCodigoCliente).Text)
                        oContaCuenta = New Class_CatCuentas(oCliente.CUENTA_CONTABLE.ToString)

                        Me.oFormaPoliza.Grid1.Cell(R, 1).Text = oCliente.CUENTA_CONTABLE.ToString
                        Me.oFormaPoliza.Grid1.Cell(R, 2).Text = oCliente.NOMBRE_CLIENTE
                        Me.oFormaPoliza.Grid1.Cell(R, 3).Text = Me.Grid.Cell(i, Me.iGyReferencia).Text
                        Me.oFormaPoliza.Grid1.Cell(R, 4).Text = oContaCuenta.NATURALEZA_CONTABLE.ToString
                        Me.oFormaPoliza.Grid1.Cell(R, 5).Text = "0"
                        Me.oFormaPoliza.Grid1.Cell(R, 6).Text = dPago.ToString
                        R = R + 1
                    End If

                    If ivaporpagar > 0 Then
                        Me.oFormaPoliza.Grid1.Rows = Me.oFormaPoliza.Grid1.Rows + 1

                        Dim oContaCuenta1 As New Class_CatCuentas
                        oContaCuenta1 = New Class_CatCuentas("20400015")
                        Me.oFormaPoliza.Grid1.Cell(R, 1).Text = oContaCuenta1.CUENTA_CONTABLE
                        Me.oFormaPoliza.Grid1.Cell(R, 2).Text = oContaCuenta1.NOMBRE_CUENTA
                        Me.oFormaPoliza.Grid1.Cell(R, 3).Text = Me.Grid.Cell(i, Me.iGyReferencia).Text
                        Me.oFormaPoliza.Grid1.Cell(R, 4).Text = oContaCuenta1.NATURALEZA_CONTABLE.ToString
                        Me.oFormaPoliza.Grid1.Cell(R, 5).Text = "0"
                        Me.oFormaPoliza.Grid1.Cell(R, 6).Text = ivaporpagar.ToString
                        R = R + 1

                        Dim oContaCuenta2 As New Class_CatCuentas
                        oContaCuenta2 = New Class_CatCuentas("20400002")
                        Me.oFormaPoliza.Grid1.Rows = Me.oFormaPoliza.Grid1.Rows + 1
                        Me.oFormaPoliza.Grid1.Cell(R, 1).Text = oContaCuenta2.CUENTA_CONTABLE
                        Me.oFormaPoliza.Grid1.Cell(R, 2).Text = oContaCuenta2.NOMBRE_CUENTA
                        Me.oFormaPoliza.Grid1.Cell(R, 3).Text = Me.Grid.Cell(i, Me.iGyReferencia).Text
                        Me.oFormaPoliza.Grid1.Cell(R, 4).Text = oContaCuenta2.NATURALEZA_CONTABLE.ToString
                        Me.oFormaPoliza.Grid1.Cell(R, 5).Text = ivaporpagar.ToString
                        Me.oFormaPoliza.Grid1.Cell(R, 6).Text = "0"
                        R = R + 1
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
            Else 'Pago en dolares

                Dim i As Integer, R As Integer = 1, dPago As Double, dPerdidaGanancia As Double

                oContaCuenta = New Class_CatCuentas(oCuentaBancaria.CUENTA_CONTABLE_PESOS.ToString)
                Me.oFormaPoliza.Grid1.Rows = Me.oFormaPoliza.Grid1.Rows + 1

                Me.oFormaPoliza.Grid1.Cell(R, 1).Text = oCuentaBancaria.CUENTA_CONTABLE_PESOS
                Me.oFormaPoliza.Grid1.Cell(R, 2).Text = oCuentaBancaria.NOMBRE_CUENTA_BANCARIA
                Me.oFormaPoliza.Grid1.Cell(R, 3).Text = "" 'oCliente.NOMBRE_CLIENTE
                Me.oFormaPoliza.Grid1.Cell(R, 4).Text = oContaCuenta.NATURALEZA_CONTABLE.ToString
                Me.oFormaPoliza.Grid1.Cell(R, 5).Text = (valorNumerico(Me.TxtTotal.Text) * valorNumerico(Me.txtTipoCambio.Text)).ToString
                Me.oFormaPoliza.Grid1.Cell(R, 6).Text = "0"
                R = R + 1

                For i = 1 To Me.Grid.Rows - 1
                    dPago = valorNumerico(Me.Grid.Cell(i, Me.iGyPago).Text)

                    If dPago > 0 Then
                        If valorNumerico(Me.Grid.Cell(i, Me.iGyTotalDlls).Text) <> valorNumerico(Me.Grid.Cell(i, Me.iGyPago).Text) And valorNumerico(Me.Grid.Cell(i, Me.iGySaldoDlls).Text) <> valorNumerico(Me.Grid.Cell(i, Me.iGyPago).Text) Then
                            MsgBox("El sistema a detectado un abono en dolares a una compra, favor de terminar de llenar la poliza.", MsgBoxStyle.Information, Me.Text)
                            Exit For
                        End If
                        dPerdidaGanancia = valorNumerico(Me.Grid.Cell(i, Me.iGyDiferencia).Text)
                        Me.oFormaPoliza.Grid1.Rows = Me.oFormaPoliza.Grid1.Rows + 1

                        oCliente = New Class_CatClientes(Me.Grid.Cell(i, Me.iGyCodigoCliente).Text)
                        oContaCuenta = New Class_CatCuentas(oCliente.CUENTA_CONTABLE.ToString)

                        Me.oFormaPoliza.Grid1.Cell(R, 1).Text = oCliente.CUENTA_CONTABLE.ToString
                        Me.oFormaPoliza.Grid1.Cell(R, 2).Text = oCliente.NOMBRE_CLIENTE
                        Me.oFormaPoliza.Grid1.Cell(R, 3).Text = Me.Grid.Cell(i, Me.iGyReferencia).Text
                        Me.oFormaPoliza.Grid1.Cell(R, 4).Text = oContaCuenta.NATURALEZA_CONTABLE.ToString
                        Me.oFormaPoliza.Grid1.Cell(R, 5).Text = "0"
                        Me.oFormaPoliza.Grid1.Cell(R, 6).Text = valorNumerico(Me.Grid.Cell(i, Me.iGySaldo).Text).ToString '(valorNumerico(Me.Grid.Cell(i, Me.iGySaldo).Text) + dPerdidaGanancia).ToString
                        R = R + 1

                        Me.oFormaPoliza.Grid1.Rows = Me.oFormaPoliza.Grid1.Rows + 1
                        Me.oFormaPoliza.Grid1.Cell(R, 1).Text = oCliente.CUENTA_CONTABLE_DOLARES.ToString
                        Me.oFormaPoliza.Grid1.Cell(R, 2).Text = oCliente.NOMBRE_CLIENTE
                        Me.oFormaPoliza.Grid1.Cell(R, 3).Text = Me.Grid.Cell(i, Me.iGyReferencia).Text
                        Me.oFormaPoliza.Grid1.Cell(R, 4).Text = oContaCuenta.NATURALEZA_CONTABLE.ToString
                        Me.oFormaPoliza.Grid1.Cell(R, 5).Text = "0"
                        Me.oFormaPoliza.Grid1.Cell(R, 6).Text = valorNumerico(Me.Grid.Cell(i, Me.iGyPago).Text).ToString '(valorNumerico(Me.Grid.Cell(i, Me.iGySaldo).Text) + dPerdidaGanancia).ToString
                        R = R + 1

                        Me.oFormaPoliza.Grid1.Rows = Me.oFormaPoliza.Grid1.Rows + 1
                        oContaCuenta = New Class_CatCuentas(Empresa_Sistema.CUENTA_CONTABLE_CLIENTES_CONTRA_CUENTA_DOLARES.ToString)
                        Me.oFormaPoliza.Grid1.Cell(R, 1).Text = Empresa_Sistema.CUENTA_CONTABLE_CLIENTES_CONTRA_CUENTA_DOLARES.ToString
                        Me.oFormaPoliza.Grid1.Cell(R, 2).Text = oContaCuenta.NOMBRE_CUENTA
                        Me.oFormaPoliza.Grid1.Cell(R, 3).Text = Me.Grid.Cell(i, Me.iGyReferencia).Text
                        Me.oFormaPoliza.Grid1.Cell(R, 4).Text = oContaCuenta.NATURALEZA_CONTABLE.ToString
                        Me.oFormaPoliza.Grid1.Cell(R, 5).Text = valorNumerico(Me.Grid.Cell(i, Me.iGyPago).Text).ToString
                        Me.oFormaPoliza.Grid1.Cell(R, 6).Text = "0"
                        R = R + 1

                        If valorNumerico(Me.Grid.Cell(i, Me.iGyDiferencia).Text) <> 0 Then
                            Me.oFormaPoliza.Grid1.Rows = Me.oFormaPoliza.Grid1.Rows + 1

                            oContaCuenta = New Class_CatCuentas(Empresa_Sistema.CUENTA_CONTABLE_PERDIDA_GANACIA_CAMBIARIA)
                            Me.oFormaPoliza.Grid1.Cell(R, 1).Text = oContaCuenta.CUENTA_CONTABLE.ToString
                            Me.oFormaPoliza.Grid1.Cell(R, 2).Text = oContaCuenta.NOMBRE_CUENTA
                            Me.oFormaPoliza.Grid1.Cell(R, 3).Text = Me.Grid.Cell(i, Me.iGyReferencia).Text
                            Me.oFormaPoliza.Grid1.Cell(R, 4).Text = oContaCuenta.NATURALEZA_CONTABLE.ToString
                            If valorNumerico(Me.Grid.Cell(i, Me.iGyDiferencia).Text) < 0 Then
                                Me.oFormaPoliza.Grid1.Cell(R, 5).Text = valorNumerico(Me.Grid.Cell(i, Me.iGyDiferencia).Text).ToString
                                Me.oFormaPoliza.Grid1.Cell(R, 6).Text = "0"
                            Else
                                Me.oFormaPoliza.Grid1.Cell(R, 5).Text = "0"
                                Me.oFormaPoliza.Grid1.Cell(R, 6).Text = (valorNumerico(Me.Grid.Cell(i, Me.iGyDiferencia).Text) * -1).ToString
                            End If
                            R = R + 1
                        End If

                        Me.oFormaPoliza.Grid1.Rows = Me.oFormaPoliza.Grid1.Rows + 1
                        oContaCuenta = New Class_CatCuentas(oCuentaBancaria.CUENTA_CONTABLE_DOLARES)
                        Me.oFormaPoliza.Grid1.Cell(R, 1).Text = oCuentaBancaria.CUENTA_CONTABLE_DOLARES.ToString
                        Me.oFormaPoliza.Grid1.Cell(R, 2).Text = oCuentaBancaria.NOMBRE_CUENTA_BANCARIA
                        Me.oFormaPoliza.Grid1.Cell(R, 3).Text = Me.Grid.Cell(i, Me.iGyReferencia).Text
                        Me.oFormaPoliza.Grid1.Cell(R, 4).Text = oContaCuenta.NATURALEZA_CONTABLE.ToString
                        Me.oFormaPoliza.Grid1.Cell(R, 5).Text = valorNumerico(Me.Grid.Cell(i, Me.iGyPago).Text).ToString
                        Me.oFormaPoliza.Grid1.Cell(R, 6).Text = "0"
                        R = R + 1

                        Me.oFormaPoliza.Grid1.Rows = Me.oFormaPoliza.Grid1.Rows + 1
                        oContaCuenta = New Class_CatCuentas(Empresa_Sistema.CUENTA_CONTABLE_CLIENTES_CONTRA_CUENTA_DOLARES.ToString)
                        Me.oFormaPoliza.Grid1.Cell(R, 1).Text = oContaCuenta.CUENTA_CONTABLE.ToString
                        Me.oFormaPoliza.Grid1.Cell(R, 2).Text = oContaCuenta.NOMBRE_CUENTA
                        Me.oFormaPoliza.Grid1.Cell(R, 3).Text = Me.Grid.Cell(i, Me.iGyReferencia).Text
                        Me.oFormaPoliza.Grid1.Cell(R, 4).Text = oContaCuenta.NATURALEZA_CONTABLE.ToString
                        Me.oFormaPoliza.Grid1.Cell(R, 5).Text = "0"
                        Me.oFormaPoliza.Grid1.Cell(R, 6).Text = valorNumerico(Me.Grid.Cell(i, Me.iGyPago).Text).ToString
                        R = R + 1
                    End If
                Next i
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

            dA = New SqlDataAdapter("SELECT I.CUENTA_CONTABLE,C.NOMBRE_CUENTA,C.NATURALEZA_CONTABLE,0,0,I.TIPO,I.PORCENTAJE " & _
                                    "FROM CON_IVA_ACREDITABLE_CATALOGO_CUENTAS I INNER JOIN CON_CAT_CUENTAS C ON(I.CUENTA_CONTABLE=C.CUENTA_CONTABLE) ORDER BY I.PORCENTAJE,I.TIPO", Empresa_Sistema.conexion)
            dA.Fill(dtImpuestosCargos)
            dA.Dispose()

            For i = 1 To Me.Grid.Rows - 1
                sFolio = Me.Grid.Cell(i, Me.iGyFolio).Text
                sCodigoDocumento = Me.Grid.Cell(i, Me.iGyCodigoCliente).Text
                dPago = valorNumerico(Me.Grid.Cell(i, Me.iGyPago).Text)
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
        Dim bResultado As Boolean = False
        Dim sFolio As String = Me.TxtFolio.Text

        Try
            Me.Inicializa()
            Me.oBancosCXC = New Class_Bancos_CXC(sFolio)
            Me.oPolizaGlobal = New Class_Contabilidad_Poliza_Global(sFolio)

            If Me.oBancosCXC.Existe = False Then
                Me.GeneraFolio()
                Me.Cambia_Estado(enumEstados.NUEVO)
                Me.TxtCuentaBancaria.Enabled = False
                Me.TxtFolio.Enabled = False
                Exit Function
            Else
                Me.TxtFolio.Text = Me.oBancosCXC.FOLIO_BANCO
                Me.TxtCuentaBancaria.Enabled = False
                Me.TxtFolio.Enabled = False

                Me.CmbDocumento.SelectedValue = oBancosCXC.CODIGO_DOCUMENTO
                Me.dtFecha.Value = oBancosCXC.FECHA
                Me.LblStatus.Text = oBancosCXC.ESTATUS
                Me.LblPoliza.Text = oBancosCXC.FOLIO_POLIZA
                Me.TxtConcepto.Text = oBancosCXC.CONCEPTO1
                Me.TxtCuentaBancaria.Text = oBancosCXC.ID_CUENTA_BANCARIA.ToString
                Me.LblCuentaBancaria.Text = oBancosCXC.NOMBRE_CUENTA_BANCARIA
                Me.LblCuentaContableCuentaBancaria.Text = oBancosCXC.CUENTA_BANCARIA_PESOS
                'me.TxtCodigoCliente.Text = oBancosCXC.CODIGO_Cliente
                'Me.LblCliente.Text = oBancosCXC.NOMBRE_Cliente
                Me.txtTipoCambio.Text = oBancosCXC.TIPO_DE_CAMBIO.ToString
                Me.TxtTotal.Text = FormatImporteContable(oBancosCXC.TOTAL)
                Me.tssElaboro.Text = "Elaboró : " & Me.oBancosCXC.NOMBRE_USUARIO_GRABO & " el " & Format(Me.oBancosCXC.FECHA_SERVIDOR, "dd-MMM-yyyy hh:mm tt")
                If Me.oBancosCXC.ESTATUS = "C" Then
                    Me.tssCancelo.Text = "Canceló : " & Me.oBancosCXC.NOMBRE_USUARIO_CANCELO & " el : " & Format(Me.oBancosCXC.FECHA_DE_CANCELACION_SERVIDOR, "dd-MMM-yyyy hh:mm tt")
                End If

                Me.Grid.DataSource = Me.oBancosCXC.ObtenerDetalle
                Me.FormateaGrid()
                'Para que haga el cambio de las columnas que se van a mostrar
                If valorNumerico(oBancosCXC.TIPO_DE_CAMBIO.ToString) > 0 Then
                    'Me.ckbDolares.Checked = True
                    Me.cboMoneda.SelectedIndex = 1
                End If

                bResultado = True

                Me.GestionaCambioEstado()
            End If
        Catch ex As Exception
            HandleError(Me.Name, "Consultar", ex)
        End Try

        Return bResultado
    End Function

    Private Function CargaVentasConSaldo() As Boolean
        Dim bResultado As Boolean = False
        Dim dTabla As DataTable
        Try
            dTabla = oBancosCXC.CargaVentasClienteConSaldo(Me.TxtCodigoCliente.Text)
            Me.Grid.Rows = 1
            For Each dRow As DataRow In dTabla.Rows
                Me.Grid.AddItem(dRow(0).ToString & Chr(9) & Format(CDate(dRow(1)), "dd-MMM-yyyy") & Chr(9) & dRow(2).ToString & Chr(9) & dRow(3).ToString & Chr(9) & dRow(4).ToString & Chr(9) & _
                                dRow(5).ToString & Chr(9) & dRow(6).ToString & Chr(9) & dRow(7).ToString & Chr(9) & dRow(8).ToString)
            Next

            'No es posible hace un datasource y luego intentar cambiar datos de celdas con codigo, no marca error pero no hace el cambio
            'Me.Grid1.DataSource = Me.oBancosCXC.CargaComprasClienteConSaldo(Me.TxtCodigoCliente.Text)
            'Me.Grid.Rows += 1

            If dTabla.Rows.Count = 0 Then
                MsgBox("El Cliente no tiene ventas con saldo.", MsgBoxStyle.Information, Me.Text)
            End If

            bResultado = True
            Me.FormateaGrid()

        Catch ex As Exception
            HandleError(Me.Name, "CargaVentasConSaldo", ex)
        End Try

        Return bResultado
    End Function

    Private Function ExisteDocumento(ByVal sFolio As String) As Boolean
        Try
            Dim sql As New Class_find("SELECT 1 FROM BANCOS_GLOBAL WHERE FOLIO_BANCO='" & sReplace(sFolio) & "'")
            If sql.Result1.Length > 0 Then
                Return True
            End If
        Catch ex As Exception
            HandleError(Me.Name, "ExisteDocumento", ex)
        End Try
    End Function

    Private Function CancelaPagosCXC() As Boolean
        Dim bResultado As Boolean = False
        Dim oFirmaElectronica = New UtileriasFirmaElectronicaCancelacionMovimientosFueraPeriodo
        Dim oUtileriasCancela As New Class_UtileriasFirmaElectronicaCancelacion
        Dim oPoliza As New Class_Contabilidad_Poliza_Global
        'Dim sFolio As String = Me.TxtFolio.Text

        'Me.oBancosCXC = New Class_Bancos_CXC(sFolio)

        If MsgBox("Deseas cancelar el movimiento de " & Me.CmbDocumento.Text & " ?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "CancelarCompra") = MsgBoxResult.No Then
            Exit Function
        End If

        If Usuario.ValidaPermisoUsuarioDocumentoSinAfectacionInventarios(Me.CmbDocumento.SelectedValue.ToString) = False Then
            MsgBox("El usuario " & Usuario.Nombre_Usuario & " no tiene permiso para realizar el movimiento de inventarios.", MsgBoxStyle.Exclamation, Me.Text)
            Exit Function
        End If

        'no se ocupa por que para eso esta la interfaz
        'If PLAZA.ValidarPeriodoTrabajo(Date.Now) = False Then 'Para cancelar se valida con la fecha de la maquina
        '    Exit Function
        'End If

        Select Case Me.LblStatus.Text
            Case "N"
                MsgBox("El documento no se ha grabado.", MsgBoxStyle.Exclamation, Me.Text)
                Exit Function
            Case "A"
                'No hay restricciones
            Case "C"
                MsgBox("Los documentos cancelados no se pueden volver a cancelar.", MsgBoxStyle.Exclamation, Me.Text)
                Exit Function
        End Select

        Try
            oUtileriasCancela.FOLIO_DOCUMENTO = Me.TxtFolio.Text.ToUpper
            oUtileriasCancela.MODULO = Me.oBancosCXC.CODIGO_MODULO
            oUtileriasCancela.CODIGO_PLAZA = Usuario.Codigo_Plaza

            If oUtileriasCancela.GestionaCancelacion() = False Then
                Exit Function
            End If

            If oUtileriasCancela.CANCELA_DIRECTO = True Then
                Me.oBancosCXC.FECHA_DE_CANCELACION = Date.Now
                If Me.oBancosCXC.CancelaBancosCXC() = False Then
                    Exit Function
                End If
            Else
                oUtileriasCancela = New Class_UtileriasFirmaElectronicaCancelacion
                oUtileriasCancela.FOLIO_DOCUMENTO = Me.TxtFolio.Text
                oUtileriasCancela.FOLIO_POLIZA = Me.oBancosCXC.FOLIO_POLIZA
                oUtileriasCancela.CODIGO_DOCUMENTO = Me.CmbDocumento.SelectedValue.ToString
                oUtileriasCancela.CODIGO_PLAZA = Usuario.Codigo_Plaza
                oUtileriasCancela.MODULO = Me.oBancosCXC.CODIGO_MODULO

                If oUtileriasCancela.AutorizaCancelacionMovimientosFueraPeriodo() = False Then
                    MsgBox("Error al tratar de autorizar la cancelación fuera del periodo.", MsgBoxStyle.Exclamation, Me.Text)
                    Exit Function
                End If

                'si no se autorizo
                If oUtileriasCancela.CANCELACION_AUTORIZO = False Then
                    MsgBox("No se autorizó la cancelación de movimiento.", MsgBoxStyle.Exclamation, Me.Text)
                    Exit Function
                End If

                If oUtileriasCancela.GestionaCancelacionConInterfaz() = False Then
                    MsgBox("Error al gestionar la cancelacion con interfaz", MsgBoxStyle.Information, Me.Text)
                    Exit Function
                Else
                    If oUtileriasCancela.ES_FECHA_CANCELACION_VALIDA = "0" Then
                        MsgBox("La fecha de cancelación debe de ser mayor o igual a la fecha del documento y debe estar en el mismo ejercicio.", vbExclamation, Me.Text)
                        Exit Function
                    End If

                    Me.oBancosCXC.FECHA_DE_CANCELACION = oUtileriasCancela.FECHA_CANCELACION

                    If Me.oBancosCXC.CancelaBancosCXC() = False Then
                        MsgBox("Error al intentar cancelar el movimiento de documento de banco.", MsgBoxStyle.Exclamation, Me.Text)
                        Exit Function
                    End If
                End If
            End If

            MsgBox("Movimiento de bancos cancelado satisfactoriamente.", MsgBoxStyle.Information, Me.Text)
            bResultado = True

        Catch ex As Exception
            HandleError(Me.Name, "CancelaPagosCXC", ex)
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
        If Me.bDocumentosCargados = True Then
            Me.oBancosCXC.CODIGO_DOCUMENTO = Me.CmbDocumento.SelectedValue.ToString
            Me.TxtFolio.Text = Me.oBancosCXC.GeneraFolio
        End If
    End Sub

    Private Sub Cambia_Estado(ByVal pEstado As enumEstados)
        Try
            Me.Estado = pEstado
            Select Case Me.Estado
                Case enumEstados.NUEVO
                    Me.tsbGrabar.Enabled = True
                    Me.tsbCancelar.Enabled = False
                    Me.tsbImprimirPoliza.Enabled = False
                    Me.CmbDocumento.Enabled = True
                    Me.dtFecha.Enabled = True
                    'Me.ckbDolares.Enabled = True
                    Me.cboMoneda.Enabled = True
                    Me.txtTipoCambio.Enabled = False
                    Me.TxtConcepto.Enabled = True
                    Me.TxtTotal.Enabled = False
                    Me.tssEstado.Text = "Estado: agregando documento " & Me.CmbDocumento.Text
                    Me.tssElaboro.Visible = False
                    Me.tssCancelo.Visible = False
                    Me.Grid.Locked = False
                    Me.TxtFolio.Enabled = True
                    Me.TxtCuentaBancaria.Enabled = True
                    If Me.Visible = True Then
                        Me.TxtCuentaBancaria.Focus()
                    End If
                    Me.gbAgregaDocCliente.Enabled = True
                    Me.gbTotales.Enabled = True

                Case enumEstados.APLICADO
                    Me.tsbGrabar.Enabled = False
                    Me.tsbCancelar.Enabled = True
                    Me.tsbImprimirPoliza.Enabled = True
                    Me.CmbDocumento.Enabled = False
                    Me.dtFecha.Enabled = False
                    'Me.ckbDolares.Enabled = False
                    Me.cboMoneda.Enabled = False
                    Me.txtTipoCambio.Enabled = False
                    Me.TxtConcepto.Enabled = False
                    Me.TxtTotal.Enabled = False
                    Me.tssEstado.Text = "Estado: Consulta de " & Me.CmbDocumento.Text
                    Me.tssElaboro.Visible = True
                    Me.tssCancelo.Visible = False
                    Me.Grid.Locked = True
                    Me.Grid.Cell(0, Me.iGyPago).Text = "Pagado"
                    Me.Grid.Column(Me.iGySeleccion).Visible = False
                    Me.gbAgregaDocCliente.Enabled = False
                    Me.gbTotales.Enabled = False

                    Me.tsbImprimirPoliza.Select()

                Case enumEstados.CANCELADO
                    Me.tsbGrabar.Enabled = False
                    Me.tsbCancelar.Enabled = False
                    Me.tsbImprimirPoliza.Enabled = True
                    Me.CmbDocumento.Enabled = False
                    Me.dtFecha.Enabled = False
                    'Me.ckbDolares.Enabled = False
                    Me.cboMoneda.Enabled = False
                    Me.txtTipoCambio.Enabled = False
                    Me.TxtConcepto.Enabled = False
                    Me.TxtTotal.Enabled = False
                    Me.tssEstado.Text = "Estado: Consulta de " & Me.CmbDocumento.Text
                    Me.tssElaboro.Visible = True
                    Me.tssCancelo.Visible = True
                    Me.Grid.Locked = True
                    Me.Grid.Cell(0, Me.iGyPago).Text = "Pagado"
                    Me.Grid.Column(Me.iGySeleccion).Visible = False
                    Me.gbAgregaDocCliente.Enabled = False
                    Me.gbTotales.Enabled = False

                    Me.tsbImprimirPoliza.Select()

            End Select
        Catch ex As Exception
            HandleError(Me.Name, "Cambia_Estado", ex)
        End Try
    End Sub

    Private Sub NavegadorDepositos(ByVal sTipoDeBusqueda As String)
        Try
            Dim iFolio As Integer, sFolio As String, iPosicion As Integer, sFolioParte2 As String
            If txtLEN(Me.TxtFolio.Text) = False Then
                'Me.TxtFolio.Text = Me.oBancosCXC.GeneraFolio
                Me.GeneraFolio()
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
                    If Me.Consultar() = False Then
                        Me.TxtCuentaBancaria.Text = ""
                        Me.LblCuentaBancaria.Text = ""
                        Me.LblCuentaContableCuentaBancaria.Text = ""
                        Me.Inicializa()
                        Me.Cambia_Estado(enumEstados.NUEVO)
                        Me.TxtCuentaBancaria.Focus()
                    End If
                End If
            End If

        Catch ex As Exception
            HandleError(Me.Name, "NavegadorDepositos", ex)
        End Try
    End Sub

#End Region

End Class
