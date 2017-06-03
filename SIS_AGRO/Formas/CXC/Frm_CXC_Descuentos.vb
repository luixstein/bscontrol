Option Strict On

Imports System.Data.SqlClient

Public Class Frm_CXC_Descuentos

    Private Enum enumEstados
        NUEVO
        APLICADO
        CANCELADO
    End Enum

#Region "Campos privados"
    Private oDocumento As New Class_CatDocumentos
    Private Estado As enumEstados

    Private oDescuentosCXC As New Class_CXC_Descuento
    Private oCliente As New Class_CatClientes

    Private ClickSinEjecutar As Boolean = False
    Private bDocumentosCargados As Boolean = False

    Private dtTotal As Double 'SUMA DE LO QUE SE HA APLICADO
    Private dtSubtotal As Double, dtIVA As Double
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
                'If Me.oDescuentosCXC.ESTATUS_CANCELACION_CFDI = "0" Then
                If Me.oDescuentosCXC.VERSION_ESQUEMA_XML > "2.2" AndAlso Me.oDocumento.TIMBRA_DOCUMENTO = True Then 'Si no se cumbre no es CFDi (por lo tanto no tiene timbre)
                    Me.CancelarNotaCreditoElectronicaLocal()
                End If
                'End If
                Me.Consultar()
                Me.GestionaCambioEstado()
            End If
        End If
    End Sub

    Private Sub tsbImprimirPoliza_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click

        MsgBox("Falta crear los formatos de nc y cr", vbExclamation, Me.Text)
        Return

        Me.oDescuentosCXC.Consultar()
        If txtLEN(Me.oDescuentosCXC.FOLIO_FISCAL_SAT + Me.oDescuentosCXC.FECHA_TIMBRADO_SAT + Me.oDescuentosCXC.NUMERO_SERIE_CERTIFICADO_SAT + Me.oDescuentosCXC.SELLO_SAT) = False And Me.oDescuentosCXC.CBB_IMAGE Is Nothing Then
            MsgBox("El descuento debe de estar sellado para poder imprimir", MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If
        Me.oDescuentosCXC.Imprimir()
    End Sub

    Private Sub tsbSellarFacturaElectronica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSellarNotaElectronica.Click
        If Me.oDescuentosCXC.TIMBRADO_CFDI = "0" Then
            If Me.GeneraNotaCreditoElectronica(True) = True Then
                Me.oDescuentosCXC.ExportarAPdf()
                Me.Consultar()
            End If
        Else
            MsgBox("El documento ya esta timbrado.", MsgBoxStyle.Exclamation, Me.Text)
        End If
    End Sub

    Private Sub tsbRecuperaNotaElectronica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRecuperaNotaElectronica.Click
        'If RecuperarNotaCreditoElectronicaLocal(True) = True Then
        '    'ExportarAPdf()
        'End If
    End Sub

    Private Sub tsbGeneraAcuseCancelacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGeneraAcuseCancelacion.Click
        If Me.oDescuentosCXC.ESTATUS_DESCUENTO = "C" And Me.oDescuentosCXC.TIMBRADO_DESCARTADO = "0" Then
            If Me.oDescuentosCXC.ESTATUS_CANCELACION_CFDI = "0" Then
                If Me.oDescuentosCXC.VERSION_ESQUEMA_XML > "2.2" Then 'Si no se cumbre no es CFDi (por lo tanto no tiene timbre)
                    If Me.CancelarNotaCreditoElectronicaLocal() = True Then
                        MsgBox("El documento digital se canceló correctamente.", MsgBoxStyle.Exclamation, Me.Text)
                    End If
                End If
            Else
                MsgBox("El documento ya tiene acuse de cancelación.", MsgBoxStyle.Exclamation, Me.Text)
            End If
        Else
            MsgBox("El documento no esta cancelado o el tiembre esta descartado.", MsgBoxStyle.Exclamation, Me.Text)
        End If
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
            Me.Inicializa()
            Me.Cambia_Estado(enumEstados.NUEVO)
        Catch ex As Exception
            HandleError(Me.Name, "Frm_CXC_Descuentos_Load", ex)
        End Try
    End Sub

    Private Sub TxtFolio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtFolio.KeyDown
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
    End Sub

    Private Sub TxtCodigoCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodigoCliente.KeyDown
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

    End Sub

    'Private Sub txtTipoCambio_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTipoCambio.KeyDown
    '    If e.KeyCode = Keys.Return Then
    '        If valorNumerico(Me.txtTipoCambio.Text) < 0 Or valorNumerico(Me.txtTipoCambio.Text) > 20 Then
    '            MsgBox("Tipo de cambio incorrecto", MsgBoxStyle.Information, "Validación de tipo de cambio")
    '            Exit Sub
    '        Else
    '            Me.CalculaImporteDolares()
    '            'If txtLEN(Me.TxtImporte.Text) = True And valorNumerico(Me.TxtImporte.Text) > 0 Then
    '            '    Me.txtTipoCambio.Text = valorNumerico(Me.txtTipoCambio.Text).ToString
    '            '    Me.txtTipoCambio.Text = Redondear(valorNumerico(Me.txtTipoCambio.Text), 4).ToString
    '            '    Me.txtImporteDolares.Text = (valorNumerico(Me.TxtImporte.Text) / valorNumerico(Me.txtTipoCambio.Text)).ToString
    '            '    Me.txtImporteDolares.Text = valorNumerico(Me.txtImporteDolares.Text).ToString
    '            '    Me.txtImporteDolares.Text = Redondear(valorNumerico(Me.txtImporteDolares.Text), 2).ToString
    '            'Else
    '            '    Me.txtTipoCambio.Text = valorNumerico(Me.txtTipoCambio.Text).ToString
    '            '    Me.txtTipoCambio.Text = Redondear(valorNumerico(Me.txtTipoCambio.Text), 4).ToString
    '            '    Me.txtImporteDolares.Text = "0"
    '            '    Me.txtImporteDolares.Text = valorNumerico(Me.txtImporteDolares.Text).ToString
    '            '    Me.txtImporteDolares.Text = Redondear(valorNumerico(Me.txtImporteDolares.Text), 2).ToString
    '        End If

    '        If Me.ModoPago = enumModoPago.Cliente Then
    '            Me.TxtCodigoCliente.Focus()
    '        Else
    '            Me.TxtConcepto.Focus()
    '        End If
    '        'SendKeys.Send("{TAB}")
    '    End If
    'End Sub

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

    'Private Sub ckbDolares_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ckbDolares.KeyDown
    '    If e.KeyCode = Keys.Return Then
    '        Me.TxtConcepto.Focus()
    '    End If
    'End Sub

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

    'Private Sub txtTipoCambio_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTipoCambio.KeyDown
    '    If e.KeyCode = Keys.Return Then
    '        If valorNumerico(Me.txtTipoCambio.Text) <= 0 Or valorNumerico(Me.txtTipoCambio.Text) > 20 Then
    '            MsgBox("Tipo de cambio incorrecto", MsgBoxStyle.Information, "Validación de tipo de cambio")
    '            Exit Sub
    '        Else
    '            Me.CalculaImporteDolares()
    '        End If
    '        Me.dtFecha.Focus()
    '        'SendKeys.Send("{TAB}")
    '    End If
    'End Sub

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
                                Me.GestionaUSD
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

    Private Sub txt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtFecha.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtNumerosDecimalKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTipoCambio.KeyPress, txtImporteDolares.KeyPress
        Dim txt As TextBox = CType(sender, TextBox)
        txtSoloNumerosDecimales(e, txt.Text)
        txtNoBeep(e)
    End Sub

    Private Sub txtTextoKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFolio.KeyPress, _
    dtFecha.KeyPress, TxtConcepto.KeyPress, TxtConcepto2.KeyPress, TxtCodigoCliente.KeyPress, chkVentaPublicoGeneral.KeyPress, ckbDolares.KeyPress
        txtNoBeep(e)
    End Sub
#End Region

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
            Me.ckbDolares.Checked = False
            Me.cboMoneda.Text = "MXN"
            Me.txtTipoCambio.Text = ""
            Me.txtImporteDolares.Text = ""
            Me.chkVentaPublicoGeneral.Checked = False

            Me.TxtSubTotal.Text = ""
            Me.txtIEPS.Text = ""
            Me.txtIEPSIncluido.Text = ""
            Me.TxtImpuesto.Text = ""
            Me.TxtTotal.Text = ""

            Me.GeneraFolio()
            Me.InicializaGrid()
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
            'Private iGyFolio As Integer = 1
            'Private iGyFechaFactura As Integer = 2
            'Private iGyImporteFactura As Integer = 3
            'Private iGySaldo As Integer = 4
            'Private iGyDescuento As Integer = 5

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
                MsgBox("El código de cliente que intenta buscar no existe o esta dado de Baja, favor de intentar con otro código.", MsgBoxStyle.Critical, sProcedure)
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

            Me.Grid.AutoRedraw = True
            Me.Grid.Refresh()

            bResultado = True
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
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
            Dim dUSD As Decimal = 0
            If valorNumericoD(Me.TxtTotal.Text) > 0 Then
                dUSD = valorNumericoD(Me.TxtTotal.Text) / valorNumericoD(Me.txtTipoCambio.Text)
                Me.txtImporteDolares.Text = FormatImporteContable(RedondearD(dUSD, 2))
            Else
                Me.txtImporteDolares.Text = "0"
            End If
        Catch ex As Exception
            HandleError(Me.Name, "CalculaImporteDolares", ex)
        End Try
    End Sub

    Private Function GestionaGrabar() As Boolean
        Dim bResultado As Boolean = False

        Try

            'Validar permiso
            If Usuario.ValidaPermisoUsuarioDocumentoSinAfectacionInventarios(Me.CboDocumento.SelectedValue.ToString) = False Then
                MsgBox("El usuario " & Usuario.Nombre_Usuario & " no tiene permiso para realizar el movimiento.", MsgBoxStyle.Information, Me.Text)
                Return False
            End If

            If MsgBox("Deseas grabar el documento con el folio : " & Me.TxtFolio.Text & "?", CType(vbYesNo + vbQuestion, MsgBoxStyle), "Grabar") = MsgBoxResult.No Then
                Return False
            End If

            'Me.Totales()
            Me.CalculaImpuestosYTotales("CALCULAR")

            If Me.Validar() = False Then
                Return False
            End If

            'If Me.ValidaPrePoliza() = False Then
            '    RETURN FALSE
            'End If

            If Me.Grabar() = True Then
                ''sobreescibir texbox folio y folio oringen de oFormaPoliza, aplicar la poliza, y actualizar folio_poliza en bancos global
                'Me.oFormaPoliza.TxtFolio.Text = Me.TxtFolio.Text
                'Me.oFormaPoliza.lblFolioOrigen.Text = Me.TxtFolio.Text
                'If Me.oFormaPoliza.Aplicar(False, False) = True Then
                '    If Me.oDescuentosCXC.ActualizaFolioPoliza() = True Then
                '        If Empresa_Sistema.FELECTRONICA_ACTIVA = True Then
                '            If Me.GeneraNotaCreditoElectronica(False) = True Then
                '                Me.oDescuentosCXC.ExportarAPdf()
                '            End If
                '        End If
                '        MsgBox("Movimiento grabado satisfactoriamente.", MsgBoxStyle.Information, Me.Text)
                '    Else
                '        MsgBox("Movimiento grabado sin relacionar el folio de la póliza.", MsgBoxStyle.Information, Me.Text)
                '    End If
                '    bResultado = True
                'Else
                '    MsgBox("Movimiento grabado sin relacionar el folio de la póliza.", MsgBoxStyle.Information, Me.Text)
                'End If

                bResultado = True

                If Empresa_Sistema.FELECTRONICA_ACTIVA = True AndAlso Me.oDocumento.TIMBRA_DOCUMENTO = True Then
                    If Me.GeneraNotaCreditoElectronica(False) = True Then
                        Me.oDescuentosCXC.ExportarAPdf()
                    End If
                End If
            End If
        Catch ex As Exception
            HandleError(Me.Name, "GestionaGrabar", ex)
        End Try

        Return bResultado
    End Function

    Private Function Grabar() As Boolean
        Dim bResultado As Boolean = False
        Dim i As Integer
        Dim ListaDescuentos As String = ""

        Try
            Me.GeneraFolio()

            Me.oDescuentosCXC = New Class_CXC_Descuento

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
                .ES_COMPROBANTE_ELECTRONICO = IIf(Empresa_Sistema.FELECTRONICA_ACTIVA = True, "1", "0").ToString
                .ES_VENTA_PUBLICO_GENERAL = Convert.ToInt32(Me.chkVentaPublicoGeneral.Checked).ToString
                .MONEDA = Me.cboMoneda.Text
                .LISTA_DESCUENTOS = ListaDescuentos

                If .InsertarDescuentos() = True Then
                    bResultado = True
                End If

                Me.TxtFolio.Text = .FOLIO_DESCUENTO
            End With

        Catch ex As Exception
            HandleError(Me.Name, "Grabar", ex)
        End Try

        Return bResultado
    End Function

    Private Function GeneraNotaCreditoElectronica(ByVal bMensaje As Boolean) As Boolean
        Dim bResultado As Boolean = False
        Dim sRutaXML As String
        Try
            'sRutaXML = sFelectronicaCarpetaXMLPDF & "\" & Me.TxtFolio.Text & ".xml"
            sRutaXML = sFelectronicaCarpetaXMLSinTimbrar & "\" & Me.TxtFolio.Text & ".xml"

            oDescuentosCXC = New Class_CXC_Descuento(Me.TxtFolio.Text)
            If GeneraNotaCreditoCXCElectronica(Me.oDescuentosCXC, bMensaje, sRutaXML) = False Then
                MsgBox("Los datos digitales de la nota electrónica no fueron generados correctamente. Avíse al depto. de sistemas.", vbExclamation, Me.Text)
            Else
                bResultado = True
                'ExportaFormatoVentaPDF(Me.txtFolio.Text, "F")GeneraNotaCreditoCXCElectronica
            End If
        Catch ex As Exception
            HandleError(Me.Name, "GeneraNotaCreditoElectronica", ex)
        End Try

        Return bResultado
    End Function

    Private Function CancelarNotaCreditoElectronicaLocal() As Boolean
        Try
            If CancelarCFDIDescuento(Me.oDescuentosCXC, TipoComprobante.NOTA_CREDITO_CXC) = False Then
                MsgBox("Los datos digitales del documento no fueron cancelados correctamente. Avíse al depto. de sistemas.", vbExclamation, Me.Text)
                Return False
            End If

            Return True
        Catch ex As Exception
            HandleError(Me.Name, "CancelarNotaCreditoElectronicaLocal", ex)
        End Try
    End Function

    'Private Function RecuperarNotaCreditoElectronicaLocal(ByVal bMensajes As Boolean) As Boolean
    '    Dim sRutaXML As String
    '    Try
    '        sRutaXML = sFelectronicaCarpetaXMLPDF & "\" & Me.TxtFolio.Text & ".xml"
    '        If RecuperaNotaElectronica(Me.TxtFolio.Text, bMensajes, sRutaXML) = False Then
    '            MsgBox("Los datos digitales de la nota electrónica no fueron generados correctamente. Avíse al depto. de sistemas.", vbExclamation, Me.Text)
    '        Else
    '            RecuperarNotaCreditoElectronicaLocal = True
    '            'ExportaFormatoVentaPDF(Me.txtFolio.Text, "F")
    '            MsgBox("Los datos digitales de la nota electrónica fueron recuperados correctamente. ", MsgBoxStyle.Information, Me.Text)
    '        End If
    '        Exit Function
    '    Catch ex As Exception
    '        HandleError(Me.Name, "RecuperarNotaCreditoElectronicaLocal", ex)
    '    End Try
    'End Function

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

            If oCliente.Existe = False Or oCliente.Estatus = "B" Then
                MsgBox("El código de Cliente que intenta introducir no existe o esta dado de baja, favor de intentar con otro código.", MsgBoxStyle.Exclamation, sProcedure)
                Me.LblCliente.Text = ""
                Me.TxtCodigoCliente.Focus()
                Return False
            Else
                Me.LblCliente.Text = oCliente.NOMBRE_CLIENTE.ToString
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
            '    MsgBox("El importe es diferente al descuento total.", MsgBoxStyle.Exclamation, Me.Nombre_Modulo)
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
                Exit Function
            ElseIf txtLEN(Me.oCliente.RFC) = False Or Me.oCliente.RFC = "." Then
                MsgBox("El dato ''RFC'' del cliente no esta capturado.", MsgBoxStyle.Exclamation, Me.Text)
                Me.TxtCodigoCliente.Focus()
                Exit Function
            ElseIf txtLEN(Me.oCliente.CALLE) = False Or Me.oCliente.CALLE = "." Then
                MsgBox("El dato ''Calle'' del cliente no esta capturado.", MsgBoxStyle.Exclamation, Me.Text)
                Me.TxtCodigoCliente.Focus()
                Exit Function
            ElseIf txtLEN(Me.oCliente.NUMERO_EXTERIOR) = False Or Me.oCliente.NUMERO_EXTERIOR = "." Then
                MsgBox("El dato ''Número exterior'' del cliente no esta capturado.", MsgBoxStyle.Exclamation, Me.Text)
                Me.TxtCodigoCliente.Focus()
                Exit Function
            ElseIf txtLEN(Me.oCliente.CIUDAD) = False Or Me.oCliente.CIUDAD = "." Then
                MsgBox("El dato ''Municipio'' del cliente no esta capturado.", MsgBoxStyle.Exclamation, Me.Text)
                Me.TxtCodigoCliente.Focus()
                Exit Function
            ElseIf txtLEN(Me.oCliente.ESTADO) = False Or Me.oCliente.ESTADO = "." Then
                MsgBox("El dato ''Estado'' del cliente no esta capturado.", MsgBoxStyle.Exclamation, Me.Text)
                Me.TxtCodigoCliente.Focus()
                Exit Function
            ElseIf txtLEN(Me.oCliente.PAIS) = False Or Me.oCliente.PAIS = "." Then
                MsgBox("El dato ''País'' del cliente no esta capturado.", MsgBoxStyle.Exclamation, Me.Text)
                Me.TxtCodigoCliente.Focus()
                Exit Function
            ElseIf txtLEN(Me.oCliente.CODIGO_POSTAL) = False Or Me.oCliente.CODIGO_POSTAL = "." Then
                MsgBox("El dato ''Código postal'' del cliente no esta capturado.", MsgBoxStyle.Exclamation, Me.Text)
                Me.TxtCodigoCliente.Focus()
                Exit Function
            End If
        Catch ex As Exception
            HandleError(Me.Name, "ValidarDatosCliente", ex)
        End Try

        Return True
    End Function

    Private Sub GestionaCambioEstado()
        Select Case Me.LblStatus.Text
            Case "A"
                Me.Cambia_Estado(enumEstados.APLICADO)
            Case "C"
                Me.Cambia_Estado(enumEstados.CANCELADO)
        End Select
    End Sub

    'Private Function ValidaPrePoliza() As Boolean
    '    Dim bResultado As Boolean = False
    '    Dim oCliente As Class_CatClientes
    '    Dim oCuenta As Class_CatCuentas
    '    'Dim oVentas As Class_Ventas_Global
    '    Dim i As Integer, sCultivo As String = ""

    '    Try
    '        If ExisteDocumento(Me.TxtFolio.Text) = True Then
    '            MsgBox("El folio : " & Me.TxtFolio.Text & " ya existe, verifíquelo.", MsgBoxStyle.Exclamation, "Contabilizar")
    '            Exit Function
    '        End If

    '        'Me.GeneraFolio() 'No hay que generar folio nuevo porque se manda el folio del documento

    '        Me.oFormaPoliza = New Frm_Contabilidad_Captura_Polizas

    '        Me.oFormaPoliza.StartPosition = FormStartPosition.CenterScreen

    '        Me.oFormaPoliza.ChildParaGrabar = True
    '        Me.oFormaPoliza.CodigoDocumentoParaGrabar = "D"

    '        Me.oFormaPoliza.DtpFecha.Value = Me.dtFecha.Value
    '        Me.oFormaPoliza.TxtTotalCargos.Text = Me.TxtTotal.Text
    '        Me.oFormaPoliza.TxtTotalAbonos.Text = Me.TxtTotal.Text
    '        Me.oFormaPoliza.TxtConcepto1.Text = Me.TxtConcepto.Text

    '        Me.oFormaPoliza.lblFolioOrigen.Text = Me.TxtFolio.Text
    '        Me.oFormaPoliza.TxtFolio.Text = Me.TxtFolio.Text

    '        Me.oFormaPoliza.Grid1.Rows = 2
    '        Me.oFormaPoliza.Grid1.Cols = 9

    '        oCliente = New Class_CatClientes(Me.TxtCodigoCliente.Text)

    '        Me.oFormaPoliza.Grid1.Cell(1, 1).Text = oCliente.CUENTA_CONTABLE.ToString
    '        Me.oFormaPoliza.Grid1.Cell(1, 2).Text = oCliente.NOMBRE_CLIENTE
    '        Me.oFormaPoliza.Grid1.Cell(1, 3).Text = Me.Grid.Cell(2, Me.iGySubtotalNuevo).Text
    '        Me.oFormaPoliza.Grid1.Cell(1, 4).Text = "D"
    '        Me.oFormaPoliza.Grid1.Cell(1, 5).Text = "0"
    '        Me.oFormaPoliza.Grid1.Cell(1, 6).Text = Me.TxtTotal.Text

    '        'Me.oFormaPoliza.Grid1.Rows = Me.oFormaPoliza.Grid1.Rows + 3
    '        ''Pone los renglones segun el codigo de descuentos del cultivo 
    '        For i = 1 To Me.Grid.Rows - 1
    '            If Me.Grid.Cell(i, Me.iGyFolio).Text <> "" And valorNumerico(Me.Grid.Cell(i, Me.iGyDescuento).Text) > 0 Then

    '                'La comersializadora es una cuenta fija y no va por cultivo
    '                'If Empresa_Sistema.RFC = "LPR070917RT9" Then
    '                '    sCultivo = "0000" + Me.Grid.Cell(i, Me.iGyCodigoCultivo).Text
    '                '    oCuenta = New Class_CatCuentas("5100" & sCultivo.Substring(Len(sCultivo) - 4))
    '                'Else
    '                '    oCuenta = New Class_CatCuentas("510000020001")
    '                'End If

    '                sCultivo = "0000" + Me.Grid.Cell(i, Me.iGyCodigoCultivo).Text
    '                oCuenta = New Class_CatCuentas("5100" & sCultivo.Substring(Len(sCultivo) - 4))

    '                Me.oFormaPoliza.Grid1.Rows = Me.oFormaPoliza.Grid1.Rows + 1
    '                If txtLEN(Me.Grid.Cell(i, Me.iGyCodigoCultivo).Text) = False Then
    '                    Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 1).Text = ""
    '                Else
    '                    Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 1).Text = oCuenta.CUENTA_CONTABLE 'Plaza.CUENTA_DESCUENTOS_REBAJAS_NACIONALES & sCultivo.Substring(Len(sCultivo) - 4)
    '                    Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 2).Text = oCuenta.NOMBRE_CUENTA
    '                End If
    '                Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 3).Text = oCliente.NOMBRE_CLIENTE
    '                Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 4).Text = "A"
    '                Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 5).Text = Me.Grid.Cell(i, Me.iGyDescuento).Text
    '                Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 6).Text = "0"
    '            End If
    '        Next i

    '        'poner el nombre del cliente al cual se le hiso el descuento
    '        'Me.AgregaPrepolizaIVAAcreditable()
    '        If Me.ckbDolares.Checked = True Then
    '            Me.CalculaImporteDolares()

    '            If txtLEN(oCliente.CUENTA_CONTABLE_DOLARES) = False Then
    '                MsgBox("El cliente no tiene cuenta contable en dólares. Favor de revisar.", MsgBoxStyle.Exclamation, "Validación de descuentos de CXC")
    '                Exit Function
    '            End If

    '            Me.oFormaPoliza.Grid1.Rows = Me.oFormaPoliza.Grid1.Rows + 1
    '            Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 1).Text = oCliente.CUENTA_CONTABLE_DOLARES
    '            Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 2).Text = oCliente.NOMBRE_CLIENTE
    '            Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 3).Text = Me.oFormaPoliza.TxtConcepto1.Text
    '            Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 4).Text = "A"
    '            Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 5).Text = Me.txtImporteDolares.Text
    '            Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 6).Text = "0"

    '            oCuenta = New Class_CatCuentas(Empresa_Sistema.CUENTA_CONTABLE_CLIENTES_CONTRA_CUENTA_DOLARES)
    '            Me.oFormaPoliza.Grid1.Rows = Me.oFormaPoliza.Grid1.Rows + 1
    '            Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 1).Text = oCuenta.CUENTA_CONTABLE
    '            Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 2).Text = oCuenta.NOMBRE_CUENTA
    '            Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 3).Text = Me.oFormaPoliza.TxtConcepto1.Text
    '            Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 4).Text = oCuenta.NATURALEZA_CONTABLE
    '            Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 5).Text = "0"
    '            Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 6).Text = Me.txtImporteDolares.Text
    '        End If

    '        Me.oFormaPoliza.lblEstatus.Text = "N"

    '        Me.oFormaPoliza.ShowDialog()

    '        bResultado = Me.oFormaPoliza.FormaValidaParaGrabarLlamadoExterior

    '    Catch ex As Exception
    '        HandleError(Me.Text, "ValidaPrePoliza", ex)
    '    Finally
    '        oCuenta = Nothing
    '        oCliente = Nothing
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

    '        For i = 1 To Me.Grid.Rows - 1
    '            sFolio = Me.Grid.Cell(i, Me.iGyFolio).Text
    '            sCodigoDocumento = Me.Grid.Cell(i, Me.iGyFolio).Text
    '            dPago = valorNumerico(Me.Grid.Cell(i, Me.iGyDescuento).Text)
    '            If txtLEN(sFolio) = True And dPago > 0 Then
    '                oCompra = New Class_Compras_Global(sFolio, sCodigoDocumento)
    '                If oCompra.IMPUESTO > 0 AndAlso (dPago - oCompra.SALDO) = 0 Then 'Si es el último pago(si quedará con saldo cero)
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
    '                    dRowAbonoRenglon("ABONO") = oCompra.IMPUESTO
    '                    dRowAbonoRenglon("TIPO") = dRowAbono(0)("TIPO")
    '                    dRowAbonoRenglon("PORCENTAJE") = dRowAbono(0)("PORCENTAJE")

    '                    dtImpuestosAbonos.Rows.Add(dRowAbonoRenglon)

    '                    dRowCargo(0)("CARGO") = valorNumerico(dRowCargo(0)("CARGO").ToString) + oCompra.IMPUESTO

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
            Me.Inicializa()
            Me.oDescuentosCXC = New Class_CXC_Descuento(sFolio)

            If Me.oDescuentosCXC.Existe = False Then
                Me.GeneraFolio()
                Me.Cambia_Estado(enumEstados.NUEVO)
                Me.CboDocumento.Enabled = False
                Me.TxtFolio.Enabled = False
                Exit Function
            Else
                Me.CboDocumento.Enabled = False
                Me.TxtFolio.Enabled = False

                Me.TxtFolio.Text = Me.oDescuentosCXC.FOLIO_DESCUENTO

                Me.dtFecha.Value = oDescuentosCXC.FECHA
                Me.LblStatus.Text = oDescuentosCXC.ESTATUS_DESCUENTO
                'Me.LblPoliza.Text = oDescuentosCXC.FOLIO_POLIZA
                Me.TxtConcepto.Text = oDescuentosCXC.CONCEPTO1
                Me.TxtConcepto2.Text = oDescuentosCXC.CONCEPTO2
                Me.TxtCodigoCliente.Text = oDescuentosCXC.CODIGO_CLIENTE
                Me.LblCliente.Text = oDescuentosCXC.NOMBRE_CLIENTE
                Me.LblPoliza.Text = oDescuentosCXC.FOLIO_POLIZA.ToString

                Me.txtTipoCambio.Text = FormatTipoCambio(oDescuentosCXC.TIPO_DE_CAMBIO)
                Me.TxtSubTotal.Text = FormatImporteContable(oDescuentosCXC.SUBTOTAL)
                Me.txtIEPS.Text = FormatImporteContable(oDescuentosCXC.IEPS_DESGLOSADO)
                Me.txtIEPSIncluido.Text = FormatImporteContable(oDescuentosCXC.IEPS_INCLUIDO)
                Me.TxtImpuesto.Text = FormatImporteContable(oDescuentosCXC.IVA)
                Me.TxtTotal.Text = FormatImporteContable(oDescuentosCXC.TOTAL)
                Me.cboMoneda.Text = oDescuentosCXC.MONEDA

                If oDescuentosCXC.TIPO_DE_CAMBIO > 0 Then
                    Me.ckbDolares.Checked = True
                    Me.CalculaImporteDolares()
                End If

                Me.tssElaboro.Text = "Elaboró : " & Me.oDescuentosCXC.NOMBRE_USUARIO_GRABO & " el " & Format(Me.oDescuentosCXC.FECHA_SERVIDOR, "dd-MMM-yyyy hh:mm tt")
                If Me.oDescuentosCXC.ESTATUS_DESCUENTO = "C" Then
                    Me.tssCancelo.Text = "Canceló : " & Me.oDescuentosCXC.NOMBRE_USUARIO_CANCELO & " el : " & Format(Me.oDescuentosCXC.FECHA_CANCELACION, "dd-MMM-yyyy hh:mm tt")
                End If

                Me.Grid.DataSource = Me.oDescuentosCXC.ObtenerDetalle
                Me.FormateaGrid()

                bResultado = True

                Me.GestionaCambioEstado()
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
        'Me.TxtFolio.Text = Me.oDescuentosCXC.GeneraFolio
        Me.TxtFolio.Text = Me.oDocumento.GeneraFolio
    End Sub

    Private Sub Cambia_Estado(ByVal pEstado As enumEstados)
        Try
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
                    Me.ckbDolares.Enabled = True
                    Me.cboMoneda.Enabled = True
                    Me.chkVentaPublicoGeneral.Enabled = True
                    Me.txtTipoCambio.Enabled = False
                    Me.txtImporteDolares.Enabled = False
                    Me.tssEstado.Text = "Estado: agregando documento"
                    Me.tssElaboro.Visible = False
                    Me.tssCancelo.Visible = False
                    Me.Grid.Locked = False
                    Me.TxtFolio.Enabled = True
                    If Me.Visible = True Then
                        Me.TxtFolio.Focus()
                    End If

                    Me.tsbSellarNotaElectronica.Visible = False
                    Me.tsbGeneraAcuseCancelacion.Visible = False
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
                    Me.ckbDolares.Enabled = False
                    Me.cboMoneda.Enabled = False
                    Me.chkVentaPublicoGeneral.Enabled = False
                    Me.txtTipoCambio.Enabled = False
                    Me.txtImporteDolares.Enabled = False
                    Me.tssEstado.Text = "Estado: consultando"
                    Me.tssElaboro.Visible = True
                    Me.tssCancelo.Visible = False
                    Me.Grid.Locked = True

                    Me.tsbImprimir.Select()
                    If Me.oDescuentosCXC.VERSION_ESQUEMA_XML >= "3.2" Or Me.oDescuentosCXC.VERSION_ESQUEMA_XML = "" Or Me.oDescuentosCXC.VERSION_ESQUEMA_XML = "0" Then
                        If Me.oDescuentosCXC.TIMBRADO_CFDI = "0" And Me.oDescuentosCXC.TIMBRADO_DESCARTADO = "0" And Me.oDocumento.TIMBRA_DOCUMENTO = True Then
                            Me.tsbSellarNotaElectronica.Visible = True
                            Me.tsbGeneraAcuseCancelacion.Visible = False
                        Else
                            Me.tsbSellarNotaElectronica.Visible = False
                        End If
                    Else
                        Me.tsbSellarNotaElectronica.Visible = False
                        Me.tsbGeneraAcuseCancelacion.Visible = False
                    End If
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
                    Me.ckbDolares.Enabled = False
                    Me.cboMoneda.Enabled = False
                    Me.chkVentaPublicoGeneral.Enabled = False
                    Me.txtTipoCambio.Enabled = False
                    Me.txtImporteDolares.Enabled = False
                    Me.tssEstado.Text = "Estado: consultando"
                    Me.tssElaboro.Visible = True
                    Me.tssCancelo.Visible = True
                    Me.Grid.Locked = True

                    Me.tsbImprimir.Select()
                    If Me.oDescuentosCXC.VERSION_ESQUEMA_XML >= "3.2" Or Me.oDescuentosCXC.VERSION_ESQUEMA_XML = "" Then
                        If Me.oDescuentosCXC.ESTATUS_CANCELACION_CFDI = "1" Then
                            Me.tsbSellarNotaElectronica.Visible = False
                            Me.tsbGeneraAcuseCancelacion.Visible = False
                        ElseIf Me.oDocumento.TIMBRA_DOCUMENTO = True Then
                            Me.tsbGeneraAcuseCancelacion.Visible = True
                        End If
                    Else
                        Me.tsbSellarNotaElectronica.Visible = False
                        Me.tsbGeneraAcuseCancelacion.Visible = False
                    End If

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


#End Region

End Class



