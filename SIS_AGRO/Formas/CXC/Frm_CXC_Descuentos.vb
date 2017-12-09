Option Strict On

Imports System.Data.SqlClient

Public Class Frm_CXC_Descuentos

#Region "Campos privados"
    Private Enum enumEstados
        NUEVO
        APLICADO
        CANCELADO
    End Enum

    Private oDocumento As New Class_CatDocumentos
    Private Estado As enumEstados

    Private oDescuentosCXC As New Class_CXC_Descuento
    Private oCliente As New Class_CatClientes

    Private ClickSinEjecutar As Boolean = False
    Private bDocumentosCargados As Boolean = False

    Private dtTotal As Double 'SUMA DE LO QUE SE HA APLICADO
    Private dtSubtotal As Double, dtIVA As Double

    Private sMonedaAnterior As String, dViewFormasPago As New Data.DataView
#End Region

#Region "Columnas grid"
    Private iGyFolio As Integer = 1
    Private iGyFechaFactura As Integer = 2
    Private iGyTipoCambio As Integer = 3
    Private iGyImporteFactura As Integer = 4
    Private iGySaldo As Integer = 5
    Private iGyDescuento As Integer = 6
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
        If Me.oDescuentosCXC.ESTATUS_DESCUENTO = "A" Then
            If Me.Cancelar = True Then  'Se cancelo el documento correctamente = true
                If Me.oDescuentosCXC.VERSION_ESQUEMA_XML > "2.2" AndAlso Me.oDocumento.TIMBRA_DOCUMENTO = True Then
                    Me.oDescuentosCXC.CancelarTimbre()
                End If
                Me.Consultar()
                Me.GestionaCambioEstado()
            End If
        Else
            MsgBox("El documento debe de estar en estatus de cancelado.", MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If
    End Sub

    Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click
        Me.oDescuentosCXC.Consultar()
        If txtLEN(Me.oDescuentosCXC.FOLIO_FISCAL_SAT + Me.oDescuentosCXC.FECHA_TIMBRADO_SAT + Me.oDescuentosCXC.NUMERO_SERIE_CERTIFICADO_SAT + Me.oDescuentosCXC.SELLO_SAT) = False AndAlso txtLEN(Me.oDescuentosCXC.CBB_IMAGE.ToString) = False _
            AndAlso Me.oDocumento.TIMBRA_DOCUMENTO = True Then
            MsgBox("El descuento no esta timbrado.", MsgBoxStyle.Exclamation, "Advertencia")
        End If
        Me.oDescuentosCXC.Imprimir()
    End Sub

    Private Sub tsbTimbrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbTimbrar.Click
        If Me.oDescuentosCXC.TIMBRADO_CFDI = "0" Then
            If Me.oDescuentosCXC.GeneraNotaCreditoElectronica(True, True) = True Then
                Me.Consultar()
            End If
        Else
            MsgBox("El documento ya esta timbrado.", MsgBoxStyle.Exclamation, Me.Text)
        End If
    End Sub

    Private Sub tsbRecuperarXMLPDF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRecuperarXMLPDF.Click
        Me.oDescuentosCXC.RecuperarXMLyPDF()
    End Sub

    Private Sub tsbCancelarTimbre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCancelarTimbre.Click
        If Me.oDescuentosCXC.CancelarTimbre = True Then
            Me.Consultar()
        End If
    End Sub

    Private Sub tsbEnviarCorreo_Click(sender As Object, e As EventArgs) Handles tsbEnviarCorreo.Click
        Me.EnviarCorreo()
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub

    Private Sub btnCargarFacturas_Click(sender As Object, e As EventArgs) Handles btnCargarFacturas.Click
        If Me.AgregarDocumentosClientes = True Then
            Me.TxtCodigoCliente.Enabled = False
            Me.cboMoneda.Enabled = False
            Me.chkVentaPublicoGeneral.Enabled = False
            Me.CboDocumento.Enabled = False
            Me.TxtFolio.Enabled = False
        Else
            Me.TxtCodigoCliente.Enabled = True
            Me.cboMoneda.Enabled = True
            Me.chkVentaPublicoGeneral.Enabled = True
        End If
    End Sub

    Private Sub btnNotaSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNotaSiguiente.Click
        Me.NavegadorNotas("Siguiente")
    End Sub

    Private Sub btnNotaAnterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNotaAnterior.Click
        Me.NavegadorNotas("Anterior")
    End Sub
#End Region

#Region "Eventos de objetos"
    Private Sub Frm_CXC_Descuentos_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If Me.Estado = enumEstados.NUEVO Then
            Me.TxtFolio.Focus()
        End If
    End Sub

    Private Sub Frm_CXC_Descuentos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.DesplegarDocumentos()

            Me.DesplegarMetodosPago()
            Me.DesplegarMonedas()
            Me.DesplegarFormasPago(False)
            Me.DesplegarUsoCFDIPersonasFisicas() 'Finalmente sólo se usará el fijo G02 que sta en fisicas y morales

            Me.Inicializa()
            Me.Cambia_Estado(enumEstados.NUEVO)

            If Empresa_Sistema.VERSION_ESQUEMA_CFD <= "3.2" Then
                Me.cboUsoCFDI.Visible = False : Me.lblDisplayUsoCFDI.Visible = False
                Me.cboMetodoPago.Visible = False : Me.lblDisplayMetodoPago.Visible = False
            End If
        Catch ex As Exception
            HandleError(Me.Name, "Frm_CXC_Descuentos_Load", ex)
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
                        Me.TxtCodigoCliente.Focus()
                    Else
                        Me.GeneraFolio()
                    End If
            End Select
        Catch ex As Exception
            HandleError(Me.Name, "TxtFolio_KeyDown", ex)
        End Try
    End Sub

    Private Sub TxtCodigoCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodigoCliente.KeyDown
        Try
            Dim sText As String
            Select Case e.KeyCode
                Case Keys.F6
Buscar:
                    sText = Me.oCliente.BusquedaVisual_PorDescripcion
                    If txtLEN(sText) = True Then Me.TxtCodigoCliente.Text = sText

                Case Keys.Enter
                    If txtLEN(Me.TxtCodigoCliente.Text) = False Then
                        Me.LblCliente.Text = ""
                        Me.TxtCodigoCliente.Focus()
                        GoTo Buscar : Exit Sub
                    End If

                    Me.oCliente = New Class_CatClientes(Me.TxtCodigoCliente.Text)
                    If Me.oCliente.Existe = False Then
                        'MsgBox("El código de Cliente que intenta buscar no existe o esta dado de baja, favor de intentar con otro código.", MsgBoxStyle.Exclamation, "Validación de Clientes")
                        Me.LblCliente.Text = "" : GoTo Buscar : Exit Sub
                    Else
                        Me.LblCliente.Text = Me.oCliente.NOMBRE_CLIENTE
                        Me.TxtCodigoCliente.Enabled = False
                        If Me.chkVentaPublicoGeneral.Checked = False Then
                            'If Me.ValidarDatosCliente() = False Then
                            '    Exit Sub
                            'End If
                        End If
                        Me.dtFecha.Focus()
                    End If
            End Select
        Catch ex As Exception
            HandleError(Me.Name, "TxtCodigoCliente_KeyDown", ex)
        End Try

    End Sub

    Private Sub TxtConcepto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtConcepto.KeyDown
        If e.KeyCode = Keys.Return Then
            'Me.Grid1.Cell(1, Me.iGyDescuento).SetFocus()
            If txtLEN(Me.TxtConcepto.Text) = False Then
                MsgBox("Asígne el concepto.", MsgBoxStyle.Exclamation, "Validación")
                Me.TxtConcepto.Focus()
                Exit Sub
            Else
                Me.TxtConcepto2.Focus()
            End If
        End If
    End Sub

    Private Sub TxtConcepto2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtConcepto2.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.Grid.Cell(1, Me.iGyFolio).SetFocus()
        End If
    End Sub

    Private Sub chkVentaPublicoGeneral_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles chkVentaPublicoGeneral.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                Me.dtFecha.Focus()
        End Select
    End Sub

    Private Sub LblPoliza_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LblPoliza.LinkClicked
        Dim Child As New Frm_Contabilidad_Captura_Polizas()
        Child.FolioPolizaConsultaExterior = Me.LblPoliza.Text
        Child.ShowDialog()
        Child.Dispose()
    End Sub

    'Private Sub Grid1_CellChanging(ByVal Sender As Object, ByVal e As FlexCell.Grid.CellChangingEventArgs) Handles Grid.CellChanging
    '    Try
    '        Dim Columna As Integer = e.Col, Renglon As Integer = e.Row
    '        Dim dPago As Double
    '        If e.Col = Me.iGyIVALocal And e.Row > 0 Then
    '            If Me.Grid.Cell(Renglon, Me.iGyIVALocal).Text = "1" And Me.ClickSinEjecutar = False Then
    '                dPago = valorNumerico(Me.Grid.Cell(Renglon, Me.iGySaldo).Text)
    '                If dPago > 0 Then
    '                    Me.ClickSinEjecutar = True
    '                    Me.Grid.Cell(Renglon, Me.iGyDescuento).Text = dPago.ToString
    '                    Me.ClickSinEjecutar = False
    '                End If
    '            Else
    '                Me.Grid.Cell(Renglon, Me.iGyDescuento).Text = "0"
    '            End If
    '        End If

    '        Me.Totales()

    '    Catch ex As Exception
    '        HandleError(Me.Name, "Grid1_CellChanging", ex)
    '    End Try
    'End Sub

    Private Sub Grid_KeyDown(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Grid.KeyDown
        Try
            Dim Columna As Integer = Me.Grid.Selection.FirstCol, Renglon As Integer = Me.Grid.Selection.FirstRow

            Dim dDescuento As Double, sFolio As String

            Select Case e.KeyCode
                Case Keys.Enter
                    Select Case Columna
                        Case Me.iGyDescuento
                            sFolio = Me.Grid.Cell(Renglon, Me.iGyFolio).Text
                            dDescuento = valorNumerico(Me.Grid.Cell(Renglon, Me.iGyDescuento).Text)
                            If dDescuento > 0 And txtLEN(Me.Grid.Cell(Renglon, Me.iGyFolio).Text) = True Then
                                Dim oVenta As New Class_Ventas_Global(sFolio)

                                If dDescuento > oVenta.SALDO Then
                                    MsgBox("El descuento total del documento: " & sFolio & " es mayor al saldo del documento, favor de revisar.", MsgBoxStyle.Exclamation, "Validación de Importes de CXC")
                                    Me.Grid.Cell(Renglon, Me.iGyDescuento).Text = ""
                                    Me.Grid.Cell(Renglon, Me.iGyDescuento).SetFocus()
                                    Me.CalculaImpuestosYTotales("CALCULAR")
                                    e.SuppressKeyPress = True
                                    Return
                                End If
                            End If

                            If Me.cboMoneda.Text = "USD" Then
                                Me.GestionaUSD()
                            End If

                            Me.CalculaImpuestosYTotales("CALCULAR")

                            'Se establece una columna antes porque el enter la brincará a la siguiente y de este modo quedamos en la columna descuento aunque mandemos el foco a saldo.
                            If Renglon < Me.Grid.Rows - 1 Then
                                Me.Grid.Cell(Renglon + 1, Me.iGySaldo).SetFocus()
                            Else
                                Me.Grid.Cell(1, Me.iGySaldo).SetFocus()
                            End If

                    End Select
            End Select

        Catch ex As Exception
            HandleError(Me.Name, "Grid_KeyDown", ex)
        End Try
    End Sub

    Private Sub CmbDocumento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboDocumento.SelectedIndexChanged
        'Me.oDescuentosCXC.CODIGO_DOCUMENTO = Me.CboDocumento.SelectedValue.ToString
        Me.oDocumento = New Class_CatDocumentos(Me.CboDocumento.SelectedValue.ToString)
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
        'If Me.oDocumento.AFECTA_CONTBILIDAD = True Then 'FACTURA
        '    Me.txtFolioEmbarque.Enabled = True
        'Else
        '    Me.txtFolioEmbarque.Enabled = False
        'End If
    End Sub

#Region "Eventos Genericos"
    Private Sub txt_Enter(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim oTexBox As TextBox = CType(sender, TextBox)
        oTexBox.SelectAll()
    End Sub

    Private Sub txt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtFecha.KeyDown, cboFormaPago.KeyDown, cboMetodoPago.KeyDown, cboUsoCFDI.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtNumerosDecimalKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTipoCambio.KeyPress
        Dim txt As TextBox = CType(sender, TextBox)
        txtSoloNumerosDecimales(e, txt.Text)
        txtNoBeep(e)
    End Sub

    Private Sub txtTextoKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFolio.KeyPress,
    dtFecha.KeyPress, TxtConcepto.KeyPress, TxtConcepto2.KeyPress, TxtCodigoCliente.KeyPress, chkVentaPublicoGeneral.KeyPress
        txtNoBeep(e)
    End Sub

#End Region

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

#End Region

#Region "Métodos y procedimientos"
    Private Sub Inicializa()
        Try
            Me.oDescuentosCXC = New Class_CXC_Descuento

            Me.TxtFolio.Text = ""
            Me.dtFecha.Value = Date.Now
            Me.TxtConcepto.Text = ""
            Me.TxtConcepto2.Text = ""
            Me.LblPoliza.Text = ""
            Me.LblStatus.Text = "N"
            Me.TxtCodigoCliente.Text = ""
            Me.LblCliente.Text = ""
            Me.cboMoneda.Text = "MXN"
            Me.txtTipoCambio.Text = ""
            Me.chkVentaPublicoGeneral.Checked = False

            Me.lblSubtotalDolares.Text = FormatImporteContable(0)
            Me.lblImpuestoDolares.Text = FormatImporteContable(0)
            Me.lblTotalDolares.Text = FormatImporteContable(0)

            Me.TxtSubTotal.Text = FormatImporteContable(0)
            Me.txtIEPS.Text = FormatImporteContable(0)
            Me.txtIEPSIncluido.Text = FormatImporteContable(0)
            Me.TxtImpuesto.Text = FormatImporteContable(0)
            Me.TxtTotal.Text = FormatImporteContable(0)
            Me.lblImpuestoPorcentaje.Text = "0.00"

            Me.GeneraFolio()
            Me.InicializaGrid()

            Me.DesplegarFormasPago(False)

            If Empresa_Sistema.VERSION_ESQUEMA_CFD <= "3.2" Then
                Me.cboFormaPago.SelectedValue = "NA" '01=EFECTIVO
            Else
                Me.cboFormaPago.SelectedValue = "99" '99=Por definir
            End If

            Me.cboMetodoPago.SelectedValue = "PUE"

            Me.cboUsoCFDI.SelectedValue = "G02" 'G02=Devoluciones, descuentos o bonificaciones

            Me.lblVersionCFDI.Text = ""

            'Estos no se gestionan en el cambiar el estado, se gestionan en el consultar
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
            FG_Grid_Limpiar(Grid)

            'Creamos el Grid
            Me.Grid.Rows = 2
            Me.Grid.Cols = 7
            Me.Grid.DisplayRowNumber = True

            Me.FormateaGrid()
        Catch ex As Exception
            HandleError(Me.Name, "InicializaGrid", ex)
        End Try
    End Sub

    Private Sub FormateaGrid()
        Try
            Me.Grid.Column(Me.iGyFolio).Width = 95
            Me.Grid.Column(Me.iGyFechaFactura).Width = 90
            Me.Grid.Column(Me.iGyTipoCambio).Width = 90
            Me.Grid.Column(Me.iGyImporteFactura).Width = 120
            Me.Grid.Column(Me.iGySaldo).Width = 120
            Me.Grid.Column(Me.iGyDescuento).Width = 120

            Me.Grid.Cell(0, Me.iGyFolio).Text = "FOLIO"
            Me.Grid.Cell(0, Me.iGyFechaFactura).Text = "FECHA VTA"
            Me.Grid.Cell(0, Me.iGyTipoCambio).Text = "TP CAMBIO"
            Me.Grid.Cell(0, Me.iGyImporteFactura).Text = "IMPORTE MXN"
            Me.Grid.Cell(0, Me.iGySaldo).Text = "SALDO MXN"
            Me.Grid.Cell(0, Me.iGyDescuento).Text = "DESCUENTO MXN"

            Me.Grid.Column(Me.iGyFechaFactura).CellType = FlexCell.CellTypeEnum.DateTime
            Me.Grid.Column(Me.iGyFechaFactura).FormatString = "dd-MMM-yy"

            Me.Grid.Column(Me.iGyImporteFactura).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
            Me.Grid.Column(Me.iGyImporteFactura).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.iGyImporteFactura).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
            Me.Grid.Column(Me.iGyImporteFactura).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.iGySaldo).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
            Me.Grid.Column(Me.iGySaldo).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.iGySaldo).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
            Me.Grid.Column(Me.iGySaldo).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.iGyDescuento).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
            Me.Grid.Column(Me.iGyDescuento).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.iGyDescuento).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
            Me.Grid.Column(Me.iGyDescuento).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Refresh()

            Me.Grid.Column(Me.iGyFolio).Locked = True
            Me.Grid.Column(Me.iGyFechaFactura).Locked = True
            Me.Grid.Column(Me.iGyTipoCambio).Locked = True
            Me.Grid.Column(Me.iGyImporteFactura).Locked = True
            Me.Grid.Column(Me.iGySaldo).Locked = True
            Me.Grid.Column(Me.iGyDescuento).Locked = False

        Catch ex As Exception
            HandleError(Me.Name, "FormateaGrid", ex)
        End Try
    End Sub

    Private Function AgregarDocumentosClientes() As Boolean
        Const sProcedure As String = "AgregarDocumentosClientes"
        Dim bResultado As Boolean = False

        Dim oCliente As Class_CatClientes, dt As New DataTable

        Try
            If Me.TxtCodigoCliente.TextLength = 0 Then
                MsgBox("Asígne el código del cliente.", MsgBoxStyle.Exclamation, sProcedure)
                Me.LblCliente.Text = ""
                Me.TxtCodigoCliente.Focus()
                Return False
            End If

            oCliente = New Class_CatClientes(Me.TxtCodigoCliente.Text)

            If oCliente.Existe = False Then
                MsgBox("El código de cliente que intenta buscar no existe o esta dado de baja, favor de intentar con otro código.", MsgBoxStyle.Exclamation, sProcedure)
                Me.LblCliente.Text = ""
                Me.TxtCodigoCliente.Focus()
                Return False
            End If

            If Me.cboMoneda.SelectedIndex = -1 Then
                MsgBox("Seleccione la moneda por favor.", vbExclamation, sProcedure)
                Me.cboMoneda.Focus()
                Return False
            End If

            dt = Me.oDescuentosCXC.ObtieneVentasConSaldo(Me.TxtCodigoCliente.Text, Me.cboMoneda.Text, Me.chkVentaPublicoGeneral.Checked, Me.oDocumento.CODIGO_TIPO_DOCUMENTO)

            If dt.Rows.Count = 0 Then
                MsgBox("No hay facturas con saldo.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            Me.Grid.AutoRedraw = False

            Me.InicializaGrid()
            Me.Grid.Rows = 1

            For Each dRow As DataRow In dt.Rows
                Me.Grid.AddItem(dRow("FOLIO_VENTA").ToString & Chr(9) & dRow("FECHA").ToString & Chr(9) & dRow("TIPO_DE_CAMBIO").ToString & Chr(9) & dRow("TOTAL").ToString & Chr(9) & dRow("SALDO").ToString & Chr(9) & "")
            Next

            bResultado = True
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        Finally
            Me.Grid.AutoRedraw = True
            Me.Grid.Refresh()
        End Try

        Return bResultado
    End Function

    'Private Sub Totales()
    '    Dim i As Integer, dDescuento As Double, dSubtotalNuevo As Double, dIVANuevo As Double
    '    Me.dtTotal = 0 : Me.dtSubtotal = 0 : Me.dtIVA = 0
    '    Try

    '        For i = 1 To Me.Grid.Rows - 1
    '            dDescuento = valorNumerico(Me.Grid.Cell(i, Me.iGyDescuento).Text)
    '            'dSubtotalNuevo = valorNumerico(Me.Grid.Cell(i, Me.iGySubtotalNuevo).Text)
    '            dSubtotalNuevo = valorNumerico(Me.Grid.Cell(i, Me.iGyDescuento).Text)
    '            dIVANuevo = valorNumerico(Me.Grid.Cell(i, Me.iGyIVANuevo).Text)
    '            If dDescuento > 0 Then
    '                Me.dtTotal = dtTotal + dDescuento
    '                Me.dtSubtotal = dtSubtotal + dSubtotalNuevo
    '                Me.dtIVA = dtIVA + dIVANuevo
    '            End If
    '        Next
    '        'me.txtImporte.Text = FormatImporteContable(FG_Grid_SumaCol(Me.Grid, CShort(Me.iGyDescuento)))

    '        'Me.CalculaImporteDolares()

    '        'FormatNumber(dtSubtotal, Empresa_Sistema.DECIMALES_CONTABILIDAD)
    '        'FormatNumber(dtIVA, Empresa_Sistema.DECIMALES_CONTABILIDAD)
    '        'FormatNumber(dtTotal, Empresa_Sistema.DECIMALES_CONTABILIDAD)

    '        'If DetectaModoIVA = False Then
    '        '    dtSubtotal = dtTotal
    '        '    dtIVA = 0
    '        '    dtTotal = dtTotal
    '        'End If

    '        Me.TxtSubTotal.Text = Format(dtSubtotal, "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD))
    '        Me.TxtImpuesto.Text = Format(dtIVA, "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD))
    '        Me.TxtTotal.Text = Format(dtTotal, "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD))

    '        'Me.TxtFalta.Text = Format(valorNumerico(Me.txtImporte.Text) - dtTotal, "###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD))

    '        Me.CalculaImporteDolares()

    '    Catch ex As Exception
    '        HandleError(Me.Name, "Totales", ex)
    '    End Try
    'End Sub

    Private Sub CalculaImporteDolares()
        Try
            Dim dTipoCambio As Decimal = valorNumericoD(Me.txtTipoCambio.Text)
            If valorNumericoD(Me.TxtTotal.Text) > 0 Then
                Me.lblSubtotalDolares.Text = FormatImporteContable(Redondear(valorNumerico(Me.TxtSubTotal.Text) / dTipoCambio, Empresa_Sistema.DECIMALES_CONTABILIDAD))
                Me.lblImpuestoDolares.Text = FormatImporteContable(Redondear(valorNumerico(Me.TxtImpuesto.Text) / dTipoCambio, Empresa_Sistema.DECIMALES_CONTABILIDAD))
                Me.lblTotalDolares.Text = FormatImporteContable(Redondear(valorNumerico(Me.TxtTotal.Text) / dTipoCambio, Empresa_Sistema.DECIMALES_CONTABILIDAD))
            Else
                Me.lblSubtotalDolares.Text = "0"
                Me.lblImpuestoDolares.Text = "0"
                Me.lblTotalDolares.Text = "0"
            End If
        Catch ex As Exception
            HandleError(Me.Name, "CalculaImporteDolares", ex)
        End Try
    End Sub

    Private Function GestionaGrabar() As Boolean
        Const sProcedure As String = "GestionaGrabar"
        Dim bResultado As Boolean = False

        Try

            'Validar permiso
            If Usuario.ValidaPermisoUsuarioDocumentoSinAfectacionInventarios(Me.oDocumento.CODIGO_DOCUMENTO) = False Then
                MsgBox("El usuario " & Usuario.Nombre_Usuario & " no tiene permiso para realizar el movimiento.", MsgBoxStyle.Information, Me.Text)
                Return False
            End If

            If MsgBox("Deseas grabar el documento con el folio : " & Me.TxtFolio.Text & "?", CType(vbYesNo + vbQuestion, MsgBoxStyle), "Grabar") = MsgBoxResult.No Then
                Return False
            End If

            Me.CalculaImpuestosYTotales("CALCULAR")

            If Me.Validar() = False Then
                Return False
            End If

            If Me.Grabar() = True Then
                bResultado = True

                If Empresa_Sistema.FELECTRONICA_ACTIVA = True AndAlso Me.oDocumento.TIMBRA_DOCUMENTO = True Then
                    Me.oDescuentosCXC = New Class_CXC_Descuento(Me.TxtFolio.Text) 'Refrescar documento para evitar algún error por dato no cargado.
                    Me.oDescuentosCXC.GeneraNotaCreditoElectronica(True, True)
                End If
            End If

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    Private Function Grabar() As Boolean
        Const sProcedure As String = "Grabar"
        Dim bResultado As Boolean = False
        Dim i As Integer
        Dim ListaDescuentos As String = ""
        Dim sMetodoPago As String, sUsoCFDI As String

        Try
            Me.GeneraFolio()

            Me.oDescuentosCXC = New Class_CXC_Descuento

            If Empresa_Sistema.VERSION_ESQUEMA_CFD <= "3.2" Then
                sMetodoPago = ""
                sUsoCFDI = ""
            Else
                sMetodoPago = Me.cboMetodoPago.SelectedValue.ToString
                sUsoCFDI = Me.cboUsoCFDI.SelectedValue.ToString
            End If

            For i = 1 To Me.Grid.Rows - 1
                If valorNumericoD(Me.Grid.Cell(i, iGyDescuento).Text) > 0 Then
                    ListaDescuentos = ListaDescuentos & Me.Grid.Cell(i, iGyFolio).Text & "," & valorNumericoD(Me.Grid.Cell(i, iGyDescuento).Text) & "|"
                End If
            Next

            With Me.oDescuentosCXC
                .FOLIO_DESCUENTO = Me.TxtFolio.Text
                .CODIGO_PLAZA = Usuario.Codigo_Plaza
                .CODIGO_DOCUMENTO = Me.CboDocumento.SelectedValue.ToString
                .CODIGO_CLIENTE = Me.TxtCodigoCliente.Text
                .SUBTOTAL = valorNumerico(Me.TxtSubTotal.Text)
                .IEPS_DESGLOSADO = valorNumerico(Me.txtIEPS.Text)
                .IEPS_INCLUIDO = valorNumerico(Me.txtIEPSIncluido.Text)
                .IVA = valorNumerico(Me.TxtImpuesto.Text)
                .TOTAL = valorNumerico(Me.TxtTotal.Text)
                .FECHA = Me.dtFecha.Value
                .CONCEPTO1 = Me.TxtConcepto.Text.ToUpper
                .CONCEPTO2 = Me.TxtConcepto2.Text.ToUpper
                .CODIGO_USUARIO_GRABO = Usuario.Codigo_Usuario
                .TIPO_DE_CAMBIO = valorNumerico(Me.txtTipoCambio.Text)
                .ES_POR_DEVOLUCION = "0"
                If Empresa_Sistema.FELECTRONICA_ACTIVA = True Then
                    .ES_COMPROBANTE_ELECTRONICO = "1"
                Else
                    .ES_COMPROBANTE_ELECTRONICO = "0"
                End If
                .ES_VENTA_PUBLICO_GENERAL = Convert.ToInt32(Me.chkVentaPublicoGeneral.Checked).ToString
                .CODIGO_METODO_PAGO = Me.cboFormaPago.SelectedValue.ToString
                .CODIGO_METODO_PAGO_EVENTO = sMetodoPago
                .CODIGO_USO_CFDI = sUsoCFDI
                .CODIGO_MONEDA_SAT = Me.cboMoneda.Text
                .LISTA_DESCUENTOS = ListaDescuentos
                .IMPUESTO_PORCENTAJE = valorNumerico(Me.lblImpuestoPorcentaje.Text)

                If .Grabar() = True Then
                    bResultado = True
                End If

                Me.TxtFolio.Text = .FOLIO_DESCUENTO
            End With

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    Private Function Validar() As Boolean
        Const sProcedure As String = "Validar"

        Dim bResultado As Boolean = False
        Dim oCliente As New Class_CatClientes()
        Dim i As Integer

        Try
            If Plaza.ValidarPeriodoTrabajo(Me.dtFecha.Value) = False Then
                Return False
            End If

            oCliente = New Class_CatClientes(Me.TxtCodigoCliente.Text)
            Me.LblCliente.Text = oCliente.NOMBRE_CLIENTE.ToString

            If oCliente.Existe = False Then
                MsgBox("El cliente no existe.", MsgBoxStyle.Exclamation, sProcedure)
                Me.TxtCodigoCliente.Focus()
                Return False
            ElseIf oCliente.ESTATUS = "B" Then
                MsgBox("El cliente esta dado de baja.", MsgBoxStyle.Exclamation, sProcedure)
                Me.TxtCodigoCliente.Focus()
                Return False
            End If

            'If Me.ckbVentaPublicoGeneral.Checked = False Then
            '    If Me.ValidarDatosCliente() = False Then
            '        Return False 
            '    End If
            'End If

            If txtLEN(Me.TxtConcepto.Text) = False Then
                MsgBox("Asigne un concepto de descuento.", MsgBoxStyle.Exclamation, sProcedure)
                Me.TxtConcepto.Focus()
                Return False
            End If

            If valorNumerico(Me.TxtTotal.Text) <= 0 Then
                MsgBox("El total debe ser mayor que cero.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            'If valorNumerico(Me.TxtFalta.Text) <> 0 Then
            '    MsgBox("El importe es diferente al descuento total.", MsgBoxStyle.Exclamation, sProcedure)
            '    Return False 
            'End If

            Dim clIvas As New Collection, bTieneVentasConIVA As Boolean, Contador As Integer = 0

            For i = 1 To Grid.Rows - 1
                If valorNumerico(Me.Grid.Cell(i, Me.iGyDescuento).Text) > 0 And txtLEN(Me.Grid.Cell(i, Me.iGyFolio).Text) = True Then
                    Dim sql As New Class_find("SELECT SALDO,IMPUESTO,IMPUESTO_PORCENTAJE FROM VENTA_GLOBAL WHERE FOLIO_VENTA='" & Me.Grid.Cell(i, Me.iGyFolio).Text & "'")
                    Me.Grid.Cell(i, Me.iGySaldo).Text = sql.Result1
                    If valorNumerico(Me.Grid.Cell(i, Me.iGyDescuento).Text) > valorNumerico(Me.Grid.Cell(i, Me.iGySaldo).Text) Then
                        MsgBox("El descuento en el renglón: " & i & " es mayor al saldo del documento.", MsgBoxStyle.Exclamation, sProcedure)
                        Me.Grid.Cell(i, Me.iGyDescuento).Text = "" '0.ToString
                        Me.Grid.Cell(i, Me.iGyDescuento).SetFocus()
                        Return False
                    ElseIf valorNumerico(Me.Grid.Cell(i, Me.iGyDescuento).Text) > valorNumerico(Me.Grid.Cell(i, Me.iGyImporteFactura).Text) Then
                        MsgBox("El descuento en el renglón: " & i & " es mayor al importe del documento.", MsgBoxStyle.Exclamation, sProcedure)
                        Me.Grid.Cell(i, Me.iGyDescuento).Text = "" '0.ToString
                        Me.Grid.Cell(i, Me.iGyDescuento).SetFocus()
                        Return False
                    End If

                    If valorNumerico(sql.Result2) > 0 Then
                        If FindCollection(clIvas, sql.Result3) = False Then
                            clIvas.Add(sql.Result3)
                        End If

                        bTieneVentasConIVA = True
                    End If

                    Contador += 1
                End If
            Next i

            'If Me.ckbDolares.Checked = True Then
            If Me.cboMoneda.Text = "USD" Then
                If valorNumerico(Me.txtTipoCambio.Text) = 0 Then
                    MsgBox("El tipo de cambio debe ser mayor a 0. Favor de revisar.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If
                If Contador > 1 Then
                    MsgBox("En los descuentos en USD sólo es permitido indicar una factura.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If
            End If

            If (valorNumerico(Me.txtIEPS.Text) > 0 And valorNumerico(Me.txtIEPSIncluido.Text) > 0) Then
                MsgBox("No se pueden mezclar facturas con IEPS incluido y desglosado en el mismo descuento.", vbExclamation, sProcedure)
                Return False
            End If

            If clIvas.Count > 1 Then
                MsgBox("No es válido tener en una misma nota de crédito ventas con diferentes porcentajes de impuestos(15, 16, etc sin contar el cero).", vbExclamation, sProcedure)
                Return False
            End If

            bResultado = True

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    Private Function FindCollection(ByRef cllCollection As Collection, ByVal sValor As String) As Boolean
        Const sProcedure As String = "FindCollection"
        Dim i As Integer
        Try
            For i = 1 To cllCollection.Count
                If sValor = cllCollection(i).ToString Then
                    Return True
                End If
            Next
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Function

    Private Function ValidarDatosCliente() As Boolean
        Try
            If txtLEN(Me.oCliente.NOMBRE_CLIENTE) = False Or Me.oCliente.NOMBRE_CLIENTE = "." Then
                MsgBox("El dato ''Nombre'' del cliente no esta capturado.", MsgBoxStyle.Exclamation, Me.Text)
                Me.TxtCodigoCliente.Focus()
                Return False
            ElseIf txtLEN(Me.oCliente.RFC) = False Or Me.oCliente.RFC = "." Then
                MsgBox("El dato ''RFC'' del cliente no esta capturado.", MsgBoxStyle.Exclamation, Me.Text)
                Me.TxtCodigoCliente.Focus()
                Return False
            ElseIf txtLEN(Me.oCliente.CALLE) = False Or Me.oCliente.CALLE = "." Then
                MsgBox("El dato ''Calle'' del cliente no esta capturado.", MsgBoxStyle.Exclamation, Me.Text)
                Me.TxtCodigoCliente.Focus()
                Return False
            ElseIf txtLEN(Me.oCliente.NUMERO_EXTERIOR) = False Or Me.oCliente.NUMERO_EXTERIOR = "." Then
                MsgBox("El dato ''Número exterior'' del cliente no esta capturado.", MsgBoxStyle.Exclamation, Me.Text)
                Me.TxtCodigoCliente.Focus()
                Return False
            ElseIf txtLEN(Me.oCliente.CIUDAD) = False Or Me.oCliente.CIUDAD = "." Then
                MsgBox("El dato ''Municipio'' del cliente no esta capturado.", MsgBoxStyle.Exclamation, Me.Text)
                Me.TxtCodigoCliente.Focus()
                Return False
            ElseIf txtLEN(Me.oCliente.ESTADO) = False Or Me.oCliente.ESTADO = "." Then
                MsgBox("El dato ''Estado'' del cliente no esta capturado.", MsgBoxStyle.Exclamation, Me.Text)
                Me.TxtCodigoCliente.Focus()
                Return False
            ElseIf txtLEN(Me.oCliente.PAIS) = False Or Me.oCliente.PAIS = "." Then
                MsgBox("El dato ''País'' del cliente no esta capturado.", MsgBoxStyle.Exclamation, Me.Text)
                Me.TxtCodigoCliente.Focus()
                Return False
            ElseIf txtLEN(Me.oCliente.CODIGO_POSTAL) = False Or Me.oCliente.CODIGO_POSTAL = "." Then
                MsgBox("El dato ''Código postal'' del cliente no esta capturado.", MsgBoxStyle.Exclamation, Me.Text)
                Me.TxtCodigoCliente.Focus()
                Return False
            End If
            Return True
        Catch ex As Exception
            HandleError(Me.Name, "ValidarDatosCliente", ex)
        End Try

    End Function

    Private Sub GestionaCambioEstado()
        Select Case Me.LblStatus.Text
            Case "A"
                Me.Cambia_Estado(enumEstados.APLICADO)
            Case "C"
                Me.Cambia_Estado(enumEstados.CANCELADO)
        End Select
    End Sub

    Private Function Consultar() As Boolean
        Dim bResultado As Boolean = False
        Dim sFolio As String = Me.TxtFolio.Text

        Try
            Me.tsbTimbrar.Visible = False
            Me.tsbCancelarTimbre.Visible = False
            Me.tsbRecuperarXMLPDF.Visible = False
            Me.tsbEnviarCorreo.Visible = False

            Me.Inicializa()
            Me.oDescuentosCXC = New Class_CXC_Descuento(sFolio)

            If Me.oDescuentosCXC.Existe = False Then
                Me.GeneraFolio()
                Me.Cambia_Estado(enumEstados.NUEVO)
                Me.CboDocumento.Enabled = False
                Me.TxtFolio.Enabled = False
                Return False
            Else
                Me.lblVersionCFDI.Text = "" & Me.oDescuentosCXC.VERSION_ESQUEMA_XML

                Me.DesplegarFormasPago(True) 'Para forzar a que muestre todos incluso los que están dados de baja porque al consultarlos fallaria si no estuvieran.

                Me.TxtFolio.Text = Me.oDescuentosCXC.FOLIO_DESCUENTO

                Me.CboDocumento.Enabled = False
                Me.TxtFolio.Enabled = False

                Me.dtFecha.Value = oDescuentosCXC.FECHA
                Me.LblStatus.Text = oDescuentosCXC.ESTATUS_DESCUENTO
                Me.TxtConcepto.Text = oDescuentosCXC.CONCEPTO1
                Me.TxtConcepto2.Text = oDescuentosCXC.CONCEPTO2
                Me.TxtCodigoCliente.Text = oDescuentosCXC.CODIGO_CLIENTE
                Me.LblCliente.Text = oDescuentosCXC.NOMBRE_CLIENTE
                Me.LblPoliza.Text = oDescuentosCXC.FOLIO_POLIZA.ToString

                Me.TxtSubTotal.Text = FormatImporteContable(oDescuentosCXC.SUBTOTAL)
                Me.txtIEPS.Text = FormatImporteContable(oDescuentosCXC.IEPS_DESGLOSADO)
                Me.txtIEPSIncluido.Text = FormatImporteContable(oDescuentosCXC.IEPS_INCLUIDO)
                Me.TxtImpuesto.Text = FormatImporteContable(oDescuentosCXC.IVA)
                Me.TxtTotal.Text = FormatImporteContable(oDescuentosCXC.TOTAL)
                Me.cboMoneda.Text = oDescuentosCXC.CODIGO_MONEDA_SAT
                Me.txtTipoCambio.Text = FormatTipoCambio(oDescuentosCXC.TIPO_DE_CAMBIO)

                If oDescuentosCXC.TIPO_DE_CAMBIO > 0 Then
                    Me.CalculaImporteDolares()
                End If

                Me.cboFormaPago.SelectedValue = Me.oDescuentosCXC.CODIGO_METODO_PAGO

                If txtLEN("" & Me.oDescuentosCXC.CODIGO_METODO_PAGO_EVENTO) = True Then
                    Me.cboMetodoPago.SelectedValue = Me.oDescuentosCXC.CODIGO_METODO_PAGO_EVENTO
                Else
                    Me.cboMetodoPago.SelectedIndex = -1
                End If

                If txtLEN("" & Me.oDescuentosCXC.CODIGO_USO_CFDI) = True Then
                    Me.cboUsoCFDI.SelectedValue = Me.oDescuentosCXC.CODIGO_USO_CFDI
                Else
                    Me.cboUsoCFDI.SelectedIndex = -1
                End If

                Me.tssElaboro.Text = "Elaboró : " & Me.oDescuentosCXC.NOMBRE_USUARIO_GRABO & " el " & Format(Me.oDescuentosCXC.FECHA_SERVIDOR, "dd-MMM-yyyy hh:mm tt")
                If Me.oDescuentosCXC.ESTATUS_DESCUENTO = "C" Then
                    Me.tssCancelo.Text = "Canceló : " & Me.oDescuentosCXC.NOMBRE_USUARIO_CANCELO & " el : " & Format(Me.oDescuentosCXC.FECHA_CANCELACION, "dd-MMM-yyyy hh:mm tt")
                End If

                Me.Grid.DataSource = Me.oDescuentosCXC.ObtenerDetalle
                Me.FormateaGrid()

                bResultado = True

                Me.GestionaCambioEstado()

                If Empresa_Sistema.FELECTRONICA_ACTIVA = True And oDocumento.TIMBRA_DOCUMENTO = True Then
                    If Me.oDescuentosCXC.TIMBRADO_CFDI = "0" AndAlso Me.oDescuentosCXC.TIMBRADO_DESCARTADO = "0" And Me.oDescuentosCXC.VERSION_ESQUEMA_XML <> "2.2" Then
                        Me.tsbTimbrar.Visible = True
                    ElseIf Me.oDescuentosCXC.ESTATUS_DESCUENTO = "C" AndAlso Me.oDescuentosCXC.TIMBRADO_CFDI = "1" AndAlso Me.oDescuentosCXC.TIMBRADO_DESCARTADO = "0" AndAlso Me.oDescuentosCXC.ESTATUS_CANCELACION_CFDI = "0" Then
                        Me.tsbCancelarTimbre.Visible = True
                    End If

                    If Me.oDescuentosCXC.TIMBRADO_CFDI = "1" Then
                        Me.tsbRecuperarXMLPDF.Visible = True
                        Me.tsbEnviarCorreo.Visible = True
                    End If
                End If
            End If

        Catch ex As Exception
            HandleError(Me.Name, "Consultar", ex)
        End Try

        Return bResultado
    End Function

    Private Function Cancelar() As Boolean
        Dim bResultado As Boolean = False
        'Dim oFirmaElectronica = New UtileriasFirmaElectronicaCancelacionMovimientosFueraPeriodo
        Dim oUtileriasCancela As New Class_UtileriasFirmaElectronicaCancelacion
        Dim oPoliza As New Class_Contabilidad_Poliza_Global
        'Dim sFolio As String = Me.TxtFolio.Text

        'Me.oBancosCXC = New Class_Bancos_CXC(sFolio)

        If MsgBox("Deseas cancelar el movimiento " & Me.TxtFolio.Text & " ?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "CancelaDescuentosCXC") = MsgBoxResult.No Then
            Return False
        End If

        If Usuario.ValidaPermisoUsuarioDocumentoSinAfectacionInventarios("NCG_CXC" & Usuario.Codigo_Plaza) = False Then
            MsgBox("El usuario " & Usuario.Nombre_Usuario & " no tiene permiso para realizar el movimiento.", MsgBoxStyle.Exclamation, Me.Text)
            Return False
        End If

        'no se ocupa por que para eso esta la interfaz
        'If PLAZA.ValidarPeriodoTrabajo(Date.Now) = False Then 'Para cancelar se valida con la fecha de la maquina
        '    Return False 
        'End If

        Select Case Me.LblStatus.Text
            Case "N"
                MsgBox("El documento no se ha grabado.", MsgBoxStyle.Exclamation, Me.Text)
                Return False
            Case "A"
                'No hay restricciones
            Case "C"
                MsgBox("Los documentos cancelados no se pueden volver a cancelar.", MsgBoxStyle.Exclamation, Me.Text)
                Return False
        End Select

        If Me.oDescuentosCXC.VERSION_ESQUEMA_XML <> Empresa_Sistema.VERSION_ESQUEMA_CFD Then
            MsgBox("La versión del esquema es diferente al actual. .", MsgBoxStyle.Exclamation, Me.Text)
            Return False
        End If

        Try
            oUtileriasCancela.FOLIO_DOCUMENTO = Me.TxtFolio.Text.ToUpper
            oUtileriasCancela.MODULO = "CXC"
            oUtileriasCancela.CODIGO_PLAZA = Usuario.Codigo_Plaza

            If oUtileriasCancela.GestionaCancelacion() = False Then
                Return False
            End If

            If oUtileriasCancela.CANCELA_DIRECTO = True Then

                Me.oDescuentosCXC.FECHA_CANCELACION = Now()

                If Me.oDescuentosCXC.CancelaDescuentoCXC() = False Then
                    MsgBox("Error al intentar cancelar el movimiento de documento de descuento.", MsgBoxStyle.Exclamation, Me.Text)
                    Return False
                End If
            Else
                oUtileriasCancela = New Class_UtileriasFirmaElectronicaCancelacion
                oUtileriasCancela.FOLIO_DOCUMENTO = Me.TxtFolio.Text
                oUtileriasCancela.FOLIO_POLIZA = Me.TxtFolio.Text.ToUpper
                oUtileriasCancela.CODIGO_DOCUMENTO = "NCG_CXC" & Usuario.Codigo_Plaza.ToString ' "DESC" ''Me.CmbDocumento.SelectedValue.ToString
                oUtileriasCancela.CODIGO_PLAZA = Usuario.Codigo_Plaza
                oUtileriasCancela.MODULO = "CXC"

                If oUtileriasCancela.AutorizaCancelacionMovimientosFueraPeriodo() = False Then
                    MsgBox("Error al tratar de autorizar la cancelación fuera del periodo.", MsgBoxStyle.Exclamation, Me.Text)
                    Return False
                End If

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
                End If

                Me.oDescuentosCXC.FECHA_CANCELACION = oUtileriasCancela.FECHA_CANCELACION

                If Me.oDescuentosCXC.CancelaDescuentoCXC() = False Then
                    MsgBox("Error al intentar cancelar el movimiento de documento de descuento.", MsgBoxStyle.Exclamation, Me.Text)
                    Return False
                End If

            End If

            MsgBox("Movimiento de descuento cancelado satisfactoriamente.", MsgBoxStyle.Information, Me.Text)
            bResultado = True

        Catch ex As Exception
            HandleError(Me.Name, "Cancelar", ex)
        End Try

        Return bResultado
    End Function

    Private Function BusquedaVisual_PorDescripcion() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de descuentos en CXC."
        f.sCampo = "FOLIO_DESCUENTO"
        f.sOrder = "FOLIO_DESCUENTO"
        f.sTable = "CXC_DESCUENTOS_GLOBAL"
        f.sQl = "SELECT FOLIO_DESCUENTO,TOTAL,FECHA FROM CXC_DESCUENTOS_GLOBAL WHERE CODIGO_PLAZA='" & Usuario.Codigo_Plaza & "' AND "
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
            'Me.TxtFolio.Text = Me.oDescuentosCXC.GeneraFolio
            Me.TxtFolio.Text = Me.oDocumento.GeneraFolio
        Catch ex As Exception
            HandleError(Me.Name, "GeneraFolio", ex)
        End Try
    End Sub

    Private Sub Cambia_Estado(ByVal pEstado As enumEstados)
        Try
            'Estos controles siempre deberán estar deshabilitados, se llenan automáticamente.
            Me.txtTipoCambio.Enabled = False
            Me.cboMetodoPago.Enabled = False
            Me.cboUsoCFDI.Enabled = False

            Me.Estado = pEstado
            Select Case Me.Estado
                Case enumEstados.NUEVO
                    Me.tsbGrabar.Enabled = True
                    Me.tsbCancelar.Enabled = False
                    Me.tsbImprimir.Enabled = False
                    Me.CboDocumento.Enabled = True
                    Me.dtFecha.Enabled = True
                    Me.TxtCodigoCliente.Enabled = True
                    Me.TxtConcepto.Enabled = True
                    Me.TxtConcepto2.Enabled = True
                    Me.cboMoneda.Enabled = True
                    Me.cboFormaPago.Enabled = True
                    Me.chkVentaPublicoGeneral.Enabled = True
                    Me.txtTipoCambio.Enabled = False
                    Me.tssEstado.Text = "Estado: agregando documento"
                    Me.tssElaboro.Visible = False
                    Me.tssCancelo.Visible = False
                    Me.Grid.Locked = False
                    Me.TxtFolio.Enabled = True
                    If Me.Visible = True Then
                        Me.TxtFolio.Focus()
                    End If

                    Me.btnCargarFacturas.Enabled = True

                Case enumEstados.APLICADO
                    Me.tsbGrabar.Enabled = False
                    Me.tsbCancelar.Enabled = True
                    Me.tsbImprimir.Enabled = True
                    Me.CboDocumento.Enabled = False
                    Me.dtFecha.Enabled = False
                    Me.TxtCodigoCliente.Enabled = False
                    Me.TxtConcepto.Enabled = False
                    Me.TxtConcepto2.Enabled = False
                    Me.cboMoneda.Enabled = False
                    Me.cboFormaPago.Enabled = False
                    Me.chkVentaPublicoGeneral.Enabled = False
                    Me.txtTipoCambio.Enabled = False
                    Me.tssEstado.Text = "Estado: consultando"
                    Me.tssElaboro.Visible = True
                    Me.tssCancelo.Visible = False
                    Me.Grid.Locked = True

                    Me.tsbImprimir.Select()
                    Me.btnCargarFacturas.Enabled = False

                Case enumEstados.CANCELADO
                    Me.tsbGrabar.Enabled = False
                    Me.tsbCancelar.Enabled = False
                    Me.tsbImprimir.Enabled = True
                    Me.CboDocumento.Enabled = False
                    Me.dtFecha.Enabled = False
                    Me.TxtCodigoCliente.Enabled = False
                    Me.TxtConcepto.Enabled = False
                    Me.TxtConcepto2.Enabled = False
                    Me.cboMoneda.Enabled = False
                    Me.cboFormaPago.Enabled = False
                    Me.chkVentaPublicoGeneral.Enabled = False
                    Me.txtTipoCambio.Enabled = False
                    Me.tssEstado.Text = "Estado: consultando"
                    Me.tssElaboro.Visible = True
                    Me.tssCancelo.Visible = True
                    Me.Grid.Locked = True

                    Me.tsbImprimir.Select()
                    Me.btnCargarFacturas.Enabled = False

            End Select
        Catch ex As Exception
            HandleError(Me.Name, "Cambia_Estado", ex)
        End Try
    End Sub

    Private Sub NavegadorNotas(ByVal sTipoDeBusqueda As String)
        Try
            Dim iFolio As Integer, sFolio As String
            If txtLEN(Me.TxtFolio.Text) = False Then
                Me.TxtFolio.Text = Me.oDescuentosCXC.GeneraFolio
            End If

            If sTipoDeBusqueda = "Anterior" Then
                sFolio = Me.TxtFolio.Text.Substring(0, Me.TxtFolio.Text.IndexOf("-"))
                iFolio = CInt(Strings.Right(Me.TxtFolio.Text, Len(Me.TxtFolio.Text) - (Len(sFolio) + 1))) ' Me.oVenta.FOLIO_NUMERICO
                iFolio = iFolio - 1
                sFolio = sFolio + "-" + iFolio.ToString

                Me.TxtFolio.Text = sFolio

                If iFolio > 0 Then
                    Me.Consultar()
                Else
                    Me.Inicializa()
                    Me.Cambia_Estado(enumEstados.NUEVO)
                End If

            ElseIf sTipoDeBusqueda = "Siguiente" Then
                sFolio = Me.TxtFolio.Text.Substring(0, Me.TxtFolio.Text.IndexOf("-"))
                iFolio = CInt(Strings.Right(Me.TxtFolio.Text, Len(Me.TxtFolio.Text) - (Len(sFolio) + 1)))
                iFolio = iFolio + 1
                sFolio = sFolio + "-" + iFolio.ToString

                Me.TxtFolio.Text = sFolio

                If iFolio > 0 Then
                    Me.Consultar()
                End If
            End If

        Catch ex As Exception
            HandleError(Me.Name, "NavegadorNotas", ex)
        End Try
    End Sub

    Private Function CalculaImpuestosYTotales(ByVal sAccion As String) As Boolean
        Dim dt As New DataTable
        Dim sFoliosConDescuento As String, i As Integer
        Try
            Dim Conexion As New SqlConnection(Empresa_Sistema.conexion)
            sFoliosConDescuento = "|"

            For i = 1 To Me.Grid.Rows - 1
                If valorNumericoD(Me.Grid.Cell(i, iGyDescuento).Text) > 0 Then
                    sFoliosConDescuento = sFoliosConDescuento & Me.Grid.Cell(i, iGyFolio).Text & "," & valorNumericoD(Me.Grid.Cell(i, iGyDescuento).Text) & "|"
                End If
            Next i

            If sFoliosConDescuento = "|" Then
                Me.TxtSubTotal.Text = FormatImporteContable(0)
                Me.txtIEPS.Text = FormatImporteContable(0)
                Me.txtIEPSIncluido.Text = FormatImporteContable(0)
                Me.TxtImpuesto.Text = FormatImporteContable(0)
                Me.TxtTotal.Text = FormatImporteContable(0)
                Me.lblImpuestoPorcentaje.Text = "0.00"
                Return True
            End If

            Using da As New SqlDataAdapter("MP_CXC_DESCUENTOS_CALCULA_IMPUESTOS_Y_TOTALES", Conexion)
                da.SelectCommand.CommandType = CommandType.StoredProcedure

                With da.SelectCommand
                    .Parameters.Add("@FOLIOS_CON_IMPORTES", SqlDbType.NVarChar, -1).Value = sFoliosConDescuento
                    .Parameters.Add("@FOLIO_DESCUENTO", SqlDbType.NVarChar, 15).Value = Me.TxtFolio.Text
                    .Parameters.Add("@ACCION", SqlDbType.NVarChar, 20).Value = sAccion
                End With

                da.Fill(dt)
            End Using

            If dt.Rows.Count > 0 Then
                Me.TxtSubTotal.Text = FormatImporteContable(CDbl(dt.Rows(0)("SUBTOTAL")))
                Me.txtIEPS.Text = FormatImporteContable(CDbl(dt.Rows(0)("IEPS_DESGLOSADO")))
                Me.txtIEPSIncluido.Text = FormatImporteContable(CDbl(dt.Rows(0)("IEPS_INCLUIDO")))
                Me.TxtImpuesto.Text = FormatImporteContable(CDbl(dt.Rows(0)("IVA")))
                Me.TxtTotal.Text = FormatImporteContable(CDbl(dt.Rows(0)("TOTAL")))
                Me.lblImpuestoPorcentaje.Text = FormatImporteContable(CDbl(dt.Rows(0)("IMPUESTO_PORCENTAJE")))
            End If

            If Me.cboMoneda.Text = "USD" Then
                Me.CalculaImporteDolares()
            End If

        Catch ex As Exception
            HandleError(Me.Name, "CalculaImpuestosYTotales", ex)
        End Try
    End Function

    Private Function GestionaUSD() As Boolean
        Try
            Dim Renglon As Integer = Me.Grid.Selection.FirstRow, i As Integer
            Me.txtTipoCambio.Text = Me.Grid.Cell(Renglon, Me.iGyTipoCambio).Text

            For i = 1 To Renglon - 1 'Elimina los descuentos anteriores al capturado
                Me.Grid.Cell(i, Me.iGyDescuento).Text = ""
            Next

            For i = Renglon + 1 To Me.Grid.Rows - 1 'Elimina los descuentos posteriores al capturado
                Me.Grid.Cell(i, Me.iGyDescuento).Text = ""
            Next

        Catch ex As Exception
            HandleError(Me.Name, "GestionaUSD", ex)
        End Try
    End Function

    Private Sub DesplegarDocumentos()
        Try
            With Me.CboDocumento
                .DisplayMember = "NOMBRE_TIPO_DOCUMENTO"
                .ValueMember = "CODIGO_DOCUMENTO"
                Dim dView As New Data.DataView(Me.oDocumento.ObtenerCodigosDocumentos("CXC", Usuario.Codigo_Plaza.ToString, " ESTATUS_DOCUMENTO='A' AND CODIGO_TIPO_DOCUMENTO IN('NCG_CXC','NRG_CXC')"))
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

    Private Sub DesplegarMetodosPago()
        Dim dView As New Data.DataView
        Try
            With Me.cboMetodoPago
                .DisplayMember = "NOMBRE_METODO_PAGO_EVENTO"
                .ValueMember = "CODIGO_METODO_PAGO_EVENTO"
                dView = New Data.DataView(dtMetodosPago)
                .DataSource = dView
                .SelectedValue = -1
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
                .SelectedIndex = -1
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarFormasPago", ex)
        End Try
    End Sub

    'Private Sub EstableceMetodoPago()
    '    Try
    '        If Empresa_Sistema.VERSION_ESQUEMA_CFD <= "3.2" Then
    '            If txtLEN(Me.TxtCodigoCliente.Text) = False Then
    '                Me.cboFormaPago.SelectedValue = "NA"
    '            End If
    '        Else
    '            MsgBox("falta ver el modo de poner el de la factura con descuento mas alto o que el usuario lo ponga.")
    '            'Ver el modo
    '            Me.cboFormaPago.SelectedValue = "99"
    '        End If
    '    Catch ex As Exception
    '        HandleError(Me.Name, "EstableceMetodoPago", ex)
    '    End Try
    'End Sub

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
            Me.oDescuentosCXC.EnviarCorreo()
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



