Option Strict On

Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports System.Collections.Specialized
Imports CrystalDecisions.Shared

Public Class Frm_CXC_Descuentos

#Region "Propiedades"
    Public ReadOnly Property Nombre_Modulo() As String
        Get
            Return "Descuentos."
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
    Private oDescuentosCXC As New Class_CXC_Descuento
    Private oCliente As New Class_CatClientes

#Region "Columnas grid"
    Private iGyFolio As Integer = 1
    Private iGyFechaVencimiento As Integer = 2
    Private iGySaldo As Integer = 3
    Private iGyCodigoCultivo As Integer = 4
    Private iGyNombreCultivo As Integer = 5
    Private iGyImporte As Integer = 6
    Private iGyDescuento As Integer = 7
    Private iGyIVALocal As Integer = 8
    Private iGySubtotalNuevo As Integer = 9
    Private iGyIVANuevo As Integer = 10
#End Region

    Private ClickSinEjecutar As Boolean = False
    Private bDocumentosCargados As Boolean = False

    Dim dtTotal As Double 'SUMA DE LO QUE SE HA APLICADO
    Dim dtSubtotal As Double, dtIVA As Double

#Region "Propiedades"

#End Region

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
    End Sub

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
            If Me.CancelaDescuentosCXC = True Then  'Se cancelo el documento correctamente = true
                'If Me.oDescuentosCXC.ESTATUS_CANCELACION_CFDI = "0" Then
                If Me.oDescuentosCXC.VERSION_ESQUEMA_XML > "2.2" Then 'Si no se cumbre no es CFDi (por lo tanto no tiene timbre)
                    Me.CancelarNotaCreditoElectronicaLocal()
                End If
                'End If
                Me.Consultar()
                MsgBox("Movimiento de descuento cancelado satisfactoriamente.", MsgBoxStyle.Information, Me.Text)
                Me.GestionaCambioEstado()
            End If
        Else
            Exit Sub
        End If
    End Sub

    Private Sub tsbImprimirPoliza_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click
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

#End Region

#Region "Eventos de objetos"

    Private Sub Frm_CXC_Descuentos_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If Me.Estado = enumEstados.NUEVO Then
            Me.TxtFolio.Focus()
        End If
    End Sub

    Private Sub Frm_CXC_Descuentos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        'If (e.Control = True And e.KeyCode = Keys.F5) Then
        '    If Me.oDescuentosCXC.ESTATUS_DESCUENTO = "A" Then
        '        If Me.oDescuentosCXC.TIMBRADO_CFDI = "0" And Me.oDescuentosCXC.TIMBRADO_DESCARTADO = "0" Then
        '            If Me.tsbSellarNotaElectronica.Visible = True Then
        '                Me.tsbSellarNotaElectronica.Visible = False
        '                Me.tsbGeneraAcuseCancelacion.Visible = False
        '                'Me.tsbRecuperaNotaElectronica.Visible = False
        '            Else
        '                Me.tsbSellarNotaElectronica.Visible = True
        '                Me.tsbGeneraAcuseCancelacion.Visible = False
        '                'Me.tsbRecuperaNotaElectronica.Visible = True
        '            End If
        '        End If
        '    ElseIf Me.oDescuentosCXC.ESTATUS_DESCUENTO = "C" Then
        '        If Me.oDescuentosCXC.TIMBRADO_CFDI = "1" Then
        '            If Me.tsbGeneraAcuseCancelacion.Visible = True Then
        '                Me.tsbSellarNotaElectronica.Visible = False
        '                Me.tsbGeneraAcuseCancelacion.Visible = False
        '                'Me.tsbRecuperaNotaElectronica.Visible = False
        '            Else
        '                Me.tsbSellarNotaElectronica.Visible = False
        '                Me.tsbGeneraAcuseCancelacion.Visible = True
        '                'Me.tsbRecuperaNotaElectronica.Visible = True
        '            End If
        '        End If
        '    End If
        'End If
    End Sub

    Private Sub Frm_CXC_Descuentos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Inicializa()
        Me.Cambia_Estado(enumEstados.NUEVO)
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

                'If txtLEN(Me.TxtFolio.Text) = True Then
                '    If Me.Consultar() = False Then
                '        Me.GeneraFolio()
                '    End If
                'Else
                '    Me.GeneraFolio()
                'End If
                'Me.dtFecha.Focus()
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
                    If Me.ckbVentaPublicoGeneral.Checked = False Then
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

    'Private Sub txtImporte_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    '    'If e.KeyCode = Keys.Return Then
    '    '    If txtLEN(Me.txtImporte.Text) = True And valorNumerico(Me.txtImporte.Text) > 0 Then
    '    '        Me.txtImporte.Text = FormatImporteContable(CDbl(Me.txtImporte.Text))
    '    '        'Me.CalculaImporteDolares()
    '    '        'Me.AgregarDocumentosClientes()
    '    '        SendKeys.Send("{TAB}")
    '    '    Else
    '    '        MsgBox("El anticipo debe ser mayor a 0.", MsgBoxStyle.Exclamation, "Validación de Anticipos")
    '    '        Me.txtImporte.Focus()
    '    '    End If
    '    'End If
    'End Sub

    Private Sub ckbDolares_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ckbDolares.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.TxtConcepto.Focus()
        End If
    End Sub

    Private Sub ckbDolares_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckbDolares.CheckedChanged
        If Me.ckbDolares.Checked = True Then
            Me.txtTipoCambio.Enabled = True
            'Me.txtTotalDolares.Enabled = True
            Me.lblTipoCambio.Enabled = True
            Me.lblTotalDolares.Enabled = True
            Me.txtTipoCambio.Focus()
        Else
            Me.txtTipoCambio.Enabled = False : Me.txtTipoCambio.Text = ""
            'Me.txtTotalDolares.Enabled = False
            Me.lblTipoCambio.Enabled = False
            Me.lblTotalDolares.Enabled = False : Me.txtImporteDolares.Text = ""
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
            Me.dtFecha.Focus()
            'SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub chkVentaPublicoGeneral_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ckbVentaPublicoGeneral.KeyDown
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

    Private Sub Grid1_CellChanging(ByVal Sender As Object, ByVal e As FlexCell.Grid.CellChangingEventArgs) Handles Grid.CellChanging
        Try
            Dim Columna As Integer = e.Col, Renglon As Integer = e.Row
            Dim dPago As Double
            If e.Col = Me.iGyIVALocal And e.Row > 0 Then
                If Me.Grid.Cell(Renglon, Me.iGyIVALocal).Text = "1" And Me.ClickSinEjecutar = False Then
                    dPago = valorNumerico(Me.Grid.Cell(Renglon, Me.iGySaldo).Text)
                    If dPago > 0 Then
                        Me.ClickSinEjecutar = True
                        Me.Grid.Cell(Renglon, Me.iGyDescuento).Text = dPago.ToString
                        Me.ClickSinEjecutar = False
                    End If
                Else
                    Me.Grid.Cell(Renglon, Me.iGyDescuento).Text = "0"
                End If
            End If

            Me.Totales()

        Catch ex As Exception
            HandleError(Me.Name, "Grid1_CellChanging", ex)
        End Try
    End Sub

    Private Sub Grid_KeyDown(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Grid.KeyDown
        Try
            Dim Columna As Integer = Me.Grid.Selection.FirstCol, Renglon As Integer = Me.Grid.Selection.FirstRow
            Dim StrCod As String = Me.Grid.Cell(Renglon, Columna).Text

            Dim dPago As Double, dPagoDocumento As Double
            Dim sFolio As String

            Select Case e.KeyCode
                Case Keys.Enter
                    Select Case Columna
                        Case Me.iGyFolio
                            sFolio = Me.Grid.Cell(Renglon, Me.iGyFolio).Text
                            If txtLEN(sFolio) = True Then
                                Dim oVenta As New Class_Ventas_Global()
                                oVenta = New Class_Ventas_Global(sFolio)
                                If oVenta.Existe = True Then
                                    Me.CargaFactura(sFolio)
                                Else
                                    'Agregar al grid folios de ventas, que no hayan sido agregados, y en caso de que ya , en msg mostrarlo.
                                    sFolio = oBancosCXC.BusquedaVisual_FacturasClienteSaldo(Me.TxtCodigoCliente.Text)
                                    Me.Grid.Cell(Renglon, Me.iGyFolio).Text = sFolio
                                    Me.CargaFactura(sFolio)
                                End If
                            End If

                        Case Me.iGyDescuento
                            Dim i As Integer
                            sFolio = Me.Grid.Cell(Renglon, Me.iGyFolio).Text
                            For i = 1 To Me.Grid.Rows - 1
                                If sFolio = Me.Grid.Cell(i, Me.iGyFolio).Text Then
                                    dPagoDocumento += valorNumerico(Me.Grid.Cell(i, Me.iGyDescuento).Text)
                                End If
                            Next

                            dPago = valorNumerico(Me.Grid.Cell(Renglon, Me.iGyDescuento).Text)
                            If dPago > 0 And txtLEN(Me.Grid.Cell(Renglon, Me.iGyFolio).Text) = True Then
                                Dim oVenta As New Class_Ventas_Global()
                                oVenta = New Class_Ventas_Global(sFolio)

                                If dPagoDocumento > oVenta.SALDO Then 'valorNumerico(Me.Grid.Cell(Renglon, Me.iGySaldo).Text) Then
                                    MsgBox("El descuento total del documento: " & sFolio & " es mayor al saldo del documento, favor de revisar.", MsgBoxStyle.Exclamation, "Validación de Importes de CXC")
                                    Me.Grid.Cell(Renglon, Me.iGyDescuento).Text = "" ' 0.ToString
                                    Me.Grid.Cell(Renglon, Me.iGyDescuento).SetFocus()
                                    e.SuppressKeyPress = True
                                    Exit Sub
                                End If

                                If dPago > valorNumerico(Me.Grid.Cell(Renglon, Me.iGyImporte).Text) And Me.Grid.Locked = False Then 'valorNumerico(Me.Grid.Cell(Renglon, Me.iGyImporte).Text) 
                                    MsgBox("El descuento en el renglón: " & Renglon & " es mayor al importe del cultivo del documento, favor de revisar.", MsgBoxStyle.Exclamation, "Validación de Importes de CXC")
                                    Me.Grid.Cell(Renglon, Me.iGyDescuento).Text = "" '0.ToString
                                    Me.Grid.Cell(Renglon, Me.iGyDescuento).SetFocus()
                                    e.SuppressKeyPress = True
                                    Exit Sub
                                End If

                                If Me.Grid.Rows - 1 = Renglon Then
                                    Me.Grid.Cell(Renglon, Me.iGyDescuento).SetFocus()
                                    e.SuppressKeyPress = True
                                ElseIf Me.Grid.Rows - 2 >= Renglon And txtLEN(Me.Grid.Cell(Renglon + 1, Me.iGyFolio).Text) = True Then
                                    Me.Grid.Cell(Renglon + 1, Me.iGyDescuento).SetFocus()
                                    e.SuppressKeyPress = True
                                Else
                                    Me.Grid.Cell(Renglon + 1, Me.iGyFolio).SetFocus()
                                    e.SuppressKeyPress = True
                                End If
                            Else
                                If Me.Grid.Rows - 1 = Renglon Then
                                    Me.Grid.Cell(Renglon, Me.iGyFolio).SetFocus()
                                    e.SuppressKeyPress = True
                                ElseIf Me.Grid.Rows - 2 >= Renglon And txtLEN(Me.Grid.Cell(Renglon + 1, Me.iGyFolio).Text) = True Then
                                    Me.Grid.Cell(Renglon + 1, Me.iGyDescuento).SetFocus()
                                    e.SuppressKeyPress = True
                                Else
                                    Me.Grid.Cell(Renglon + 1, Me.iGyFolio).SetFocus()
                                    e.SuppressKeyPress = True
                                End If
                            End If
                    End Select

                Case Keys.F6
                    Select Case Columna
                        Case Me.iGyFolio
                            Me.AgregarDocumentosClientes()
                            Me.Grid.Cell(Renglon, Me.iGyDescuento).SetFocus()
                    End Select

                Case Keys.Delete, Keys.F8
                    Select Case Columna
                        Case Is <> Me.iGyDescuento
                            e.SuppressKeyPress = True
                    End Select
            End Select

            Me.Totales()

        Catch ex As Exception
            HandleError(Me.Name, "Grid_KeyDown", ex)
        End Try
    End Sub

    Private Sub BtnDistribuirDescuento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDistribuirDescuento.Click
        'Muestra el valor
        'MsgBox(FormatImporteContable(CDbl(Dato), True).ToString, vbInformation)
        Me.DistribucionDescuento()
    End Sub

    Private Sub btnNotaSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNotaSiguiente.Click
        NavegadorNotas("Siguiente")
    End Sub

    Private Sub btnNotaAnterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNotaAnterior.Click
        NavegadorNotas("Anterior")
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
    dtFecha.KeyPress, TxtConcepto.KeyPress, TxtConcepto2.KeyPress, TxtCodigoCliente.KeyPress, ckbVentaPublicoGeneral.KeyPress, ckbDolares.KeyPress
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
            Me.TxtConcepto2.Text = ""
            Me.LblPoliza.Text = ""
            Me.LblStatus.Text = "N"
            Me.TxtCodigoCliente.Text = ""
            Me.LblCliente.Text = ""
            Me.ckbDolares.Checked = False
            Me.txtTipoCambio.Text = ""
            Me.txtImporteDolares.Text = ""
            Me.ckbVentaPublicoGeneral.Checked = False

            Me.TxtSubTotal.Text = ""
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
            Me.Grid.Cols = 11
            Me.Grid.DisplayRowNumber = True

            Me.FormateaGrid()
        Catch ex As Exception
            HandleError(Me.Name, "InicializaGrid", ex)
        End Try
    End Sub

    Private Sub FormateaGrid()
        Try
            Me.Grid.Column(Me.iGyFolio).Width = 95
            Me.Grid.Column(Me.iGyFechaVencimiento).Width = 90
            Me.Grid.Column(Me.iGySaldo).Width = 120
            Me.Grid.Column(Me.iGyCodigoCultivo).Width = 80
            Me.Grid.Column(Me.iGyNombreCultivo).Width = 150
            Me.Grid.Column(Me.iGyImporte).Width = 120
            Me.Grid.Column(Me.iGyDescuento).Width = 120
            Me.Grid.Column(Me.iGyIVALocal).Width = 60
            Me.Grid.Column(Me.iGySubtotalNuevo).Width = 95

            Me.Grid.Cell(0, Me.iGyFolio).Text = "FOLIO"
            Me.Grid.Cell(0, Me.iGyFechaVencimiento).Text = "FECHA VTA"
            Me.Grid.Cell(0, Me.iGySaldo).Text = "SALDO"
            Me.Grid.Cell(0, Me.iGyCodigoCultivo).Text = "CDG. CULTIVO"
            Me.Grid.Cell(0, Me.iGyNombreCultivo).Text = "NOM. CULTIVO"
            Me.Grid.Cell(0, Me.iGyImporte).Text = "IMPORTE"
            Me.Grid.Cell(0, Me.iGyDescuento).Text = "APLICAR"

            Me.Grid.Cell(0, Me.iGyIVALocal).Text = "IVALOCAL"
            Me.Grid.Cell(0, Me.iGySubtotalNuevo).Text = "SUBTOTALNUEVO"
            Me.Grid.Cell(0, Me.iGyIVANuevo).Text = "IVANuevo"

            Me.Grid.Column(Me.iGyFechaVencimiento).CellType = FlexCell.CellTypeEnum.DateTime
            Me.Grid.Column(Me.iGyFechaVencimiento).FormatString = "dd-MMM-yy"

            Me.Grid.Column(Me.iGyImporte).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
            Me.Grid.Column(Me.iGyImporte).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.iGyImporte).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
            Me.Grid.Column(Me.iGyImporte).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.iGySaldo).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
            Me.Grid.Column(Me.iGySaldo).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.iGySaldo).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
            Me.Grid.Column(Me.iGySaldo).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.iGyDescuento).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
            Me.Grid.Column(Me.iGyDescuento).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.iGyDescuento).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
            Me.Grid.Column(Me.iGyDescuento).Alignment = FlexCell.AlignmentEnum.RightCenter

            'Me.Grid.Column(Me.iGyIVALocal).CellType = FlexCell.CellTypeEnum.CheckBox
            Me.Grid.Refresh()

            Me.Grid.Column(Me.iGyFolio).Locked = False
            Me.Grid.Column(Me.iGyFechaVencimiento).Locked = True
            Me.Grid.Column(Me.iGySaldo).Locked = True
            Me.Grid.Column(Me.iGyCodigoCultivo).Locked = True
            Me.Grid.Column(Me.iGyNombreCultivo).Locked = True
            Me.Grid.Column(Me.iGyImporte).Locked = True
            Me.Grid.Column(Me.iGyDescuento).Locked = False
            Me.Grid.Column(Me.iGyIVALocal).Locked = True
            Me.Grid.Column(Me.iGySubtotalNuevo).Locked = True
            Me.Grid.Column(Me.iGyIVANuevo).Locked = True

            Me.Grid.Column(Me.iGyIVALocal).Visible = False
            Me.Grid.Column(Me.iGySubtotalNuevo).Visible = False
            Me.Grid.Column(Me.iGyIVANuevo).Visible = False

            Me.FormateaColoresGrid()
        Catch ex As Exception
            HandleError(Me.Name, "FormateaGrid", ex)
        End Try
    End Sub

    Private Sub FormateaColoresGrid()
        Dim i As Integer, j As Integer, k As Integer, sCodigoFactura As String = ""
        Dim bcColor1 As Color = Color.Beige

        Try
            If txtLEN(sCodigoFactura) = False And Me.Grid.Rows - 1 = 1 Then
                For k = 1 To Me.Grid.Cols - 1
                    Me.Grid.Cell(1, k).BackColor = Color.Beige
                Next
            Else
                For i = 1 To Me.Grid.Rows - 1
                    sCodigoFactura = Me.Grid.Cell(i, Me.iGyFolio).Text
                    j = i + 1
                    If j > Me.Grid.Rows - 1 Then
                        Exit Sub
                    End If
                    For k = 1 To Me.Grid.Cols - 1
                        Me.Grid.Cell(i, k).BackColor = bcColor1
                    Next

                    If txtLEN(Me.Grid.Cell(j, Me.iGyFolio).Text) = True Then
                        If sCodigoFactura <> Me.Grid.Cell(j, Me.iGyFolio).Text And Me.Grid.Rows > 2 Then
                            If bcColor1 = Color.Beige Then
                                bcColor1 = Color.LightCyan
                            Else
                                bcColor1 = Color.Beige
                            End If

                            For k = 1 To Me.Grid.Cols - 1
                                Me.Grid.Cell(j, k).BackColor = bcColor1
                            Next
                        End If
                    End If
                Next i
            End If
        Catch ex As Exception
            HandleError(Me.Name, "FormateaColoresGrid", ex)
        End Try
    End Sub

    Private Sub AgregarDocumentosClientes()
        Dim sql As Class_find ', iRow As Integer
        Dim sText As String

        Try
            If Me.TxtCodigoCliente.TextLength = 0 Then
                MsgBox("Asígne el código del cliente.", MsgBoxStyle.Exclamation, Me.Text)
                Me.TxtCodigoCliente.Focus()
                Exit Sub
            Else
                sql = New Class_find("Select NOMBRE_CLIENTE,CUENTA_CONTABLE From CAT_CLIENTES Where CODIGO_CLIENTE='" & Me.TxtCodigoCliente.Text & "' AND ESTATUS='A' ")
                If sql.Result1 = "" Then
                    MsgBox("El código de cliente que intenta buscar no existe o esta dado de Baja, favor de intentar con otro código.", MsgBoxStyle.Critical, "Validación de Cliente")
                    Me.LblCliente.Text = ""
                    Me.TxtCodigoCliente.Focus()
                    Exit Sub
                End If
            End If

            'Me.BorraDocumentosSinPago()
            'For iRow = 1 To Me.Grid.Rows - 1
            '    If Me.Grid.Cell(iRow, Me.iGyFolio).Text.Length > 0 AndAlso Me.TxtCodigoCliente.Text = Me.Grid.Cell(iRow, Me.iGyFolio).Text Then
            '        If MsgBox("Ya asignó al cliente " & Me.TxtCodigoCliente.Text & " a la lista de pagos, esta seguro de volver agregarlo?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then
            '            Exit Sub
            '        Else
            '            Exit For
            '        End If
            '    End If
            'Next

            'Agregar al grid folios de ventas, que no hayan sido agregados, y en caso de que ya, en msg mostrarlo.
            sText = oBancosCXC.BusquedaVisual_FacturasClienteSaldo(Me.TxtCodigoCliente.Text)
            If txtLEN(sText) = True Then
                Me.CargaFactura(sText)
            End If

        Catch ex As Exception
            HandleError(Me.Name, "AgregarDocumentosClientes", ex)
        End Try

    End Sub

    Private Function CargaFactura(ByVal sFolioVenta As String) As Boolean
        Dim bResultado As Boolean = False
        Dim dTabla As DataTable
        Try
            dTabla = oBancosCXC.CargaFacturaClienteConSaldo(Me.TxtCodigoCliente.Text, sFolioVenta)

            If Me.Grid.Rows = 2 Then
                If txtLEN(Me.Grid.Cell(1, Me.iGyFolio).Text) = False And txtLEN(Me.Grid.Cell(1, Me.iGyDescuento).Text) = False Then
                    Me.Grid.Rows = 1
                End If
            Else
                Me.Grid.Rows = Me.Grid.Rows - 1
            End If

            If Me.ValidarFactura(sFolioVenta) = False Then
                Me.Grid.Rows = Me.Grid.Rows + 1
                Me.Grid.Cell(Me.Grid.Rows - 1, Me.iGyFolio).SetFocus()
                Exit Function
            End If

            For Each dRow As DataRow In dTabla.Rows
                Me.Grid.AddItem(dRow(0).ToString & Chr(9) & Format(CDate(dRow(1)), "dd-MMM-yyyy") & Chr(9) & dRow(2).ToString & Chr(9) & dRow(3).ToString & Chr(9) & _
                                dRow(4).ToString & Chr(9) & dRow(5).ToString & Chr(9) & dRow(6).ToString)
            Next

            Me.Grid.Rows = Me.Grid.Rows + 1
            'No es posible hace un datasource y luego intentar cambiar datos de celdas con codigo, no marca error pero no hace el cambio
            'Me.Grid1.DataSource = Me.oBancosCXC.CargaFacturasClienteConsSaldo(Me.TxtCodigoCliente.Text)
            'Me.Grid.Rows += 1  

            If dTabla.Rows.Count = 0 Then
                MsgBox("El proveedor no tiene compras con saldo.", MsgBoxStyle.Information, Me.Text)
            End If

            bResultado = True
            Me.FormateaGrid()
            'Me.Grid.Cell(Me.Grid.Rows - 1, Me.iGyDescuento).SetFocus()

        Catch ex As Exception
            HandleError(Me.Name, "CargaFactura", ex)
        End Try

        Return bResultado
    End Function

    Private Sub Totales()
        Dim i As Integer, dDescuento As Double, dSubtotalNuevo As Double, dIVANuevo As Double
        Me.dtTotal = 0 : Me.dtSubtotal = 0 : Me.dtIVA = 0
        Try

            For i = 1 To Me.Grid.Rows - 1
                dDescuento = valorNumerico(Me.Grid.Cell(i, Me.iGyDescuento).Text)
                'dSubtotalNuevo = valorNumerico(Me.Grid.Cell(i, Me.iGySubtotalNuevo).Text)
                dSubtotalNuevo = valorNumerico(Me.Grid.Cell(i, Me.iGyDescuento).Text)
                dIVANuevo = valorNumerico(Me.Grid.Cell(i, Me.iGyIVANuevo).Text)
                If dDescuento > 0 Then
                    Me.dtTotal = dtTotal + dDescuento
                    Me.dtSubtotal = dtSubtotal + dSubtotalNuevo
                    Me.dtIVA = dtIVA + dIVANuevo
                End If
            Next
            'me.txtImporte.Text = FormatImporteContable(FG_Grid_SumaCol(Me.Grid, CShort(Me.iGyDescuento)))

            'Me.CalculaImporteDolares()

            'FormatNumber(dtSubtotal, Empresa_Sistema.DECIMALES_CONTABILIDAD)
            'FormatNumber(dtIVA, Empresa_Sistema.DECIMALES_CONTABILIDAD)
            'FormatNumber(dtTotal, Empresa_Sistema.DECIMALES_CONTABILIDAD)

            'If DetectaModoIVA = False Then
            '    dtSubtotal = dtTotal
            '    dtIVA = 0
            '    dtTotal = dtTotal
            'End If

            Me.TxtSubTotal.Text = Format(dtSubtotal, "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD))
            Me.TxtImpuesto.Text = Format(dtIVA, "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD))
            Me.TxtTotal.Text = Format(dtTotal, "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD))

            'Me.TxtFalta.Text = Format(valorNumerico(Me.txtImporte.Text) - dtTotal, "###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD))

            Me.CalculaImporteDolares()

        Catch ex As Exception
            HandleError(Me.Name, "Totales", ex)
        End Try
    End Sub

    Private Function DetectaModoIVA() As Boolean
        Try
            Dim IndexRow As Integer, dImporte As Double, dIva As Double
            For IndexRow = 1 To Me.Grid.Rows - 1
                dImporte = valorNumerico(Me.Grid.Cell(IndexRow, Me.iGyDescuento).Text)
                dIva = valorNumerico(Me.Grid.Cell(IndexRow, Me.iGyIVALocal).Text)
                If dImporte > 0 And dIva > 0 Then
                    Return True
                End If
            Next
        Catch ex As Exception
            HandleError(Me.Name, "DetectaModoIVA", ex)
        End Try
    End Function

    Private Function GestionaModoIVA() As Boolean
        Dim bResultado As Boolean = False
        Try

            Dim IndexRow As Integer, sFolio As String, dIva As Double, dTotal As Double, bTieneIVA As Boolean
            Dim sql As Class_find

            If DetectaModoIVA() = False Then
                For IndexRow = 1 To Me.Grid.Rows - 1
                    Me.Grid.Cell(IndexRow, Me.iGySubtotalNuevo).Text = Format(0, "###,###,##0." & Empresa_Sistema.DECIMALES_CONTABILIDAD)
                    Me.Grid.Cell(IndexRow, Me.iGyIVANuevo).Text = Format(0, "###,###,##0." & Empresa_Sistema.DECIMALES_CONTABILIDAD)
                Next

                Exit Function
            End If

            For IndexRow = 1 To Me.Grid.Rows - 1
                dTotal = valorNumerico(Me.Grid.Cell(IndexRow, iGyDescuento).Text)
                dIva = valorNumerico(Me.Grid.Cell(IndexRow, iGyIVALocal).Text)
                If dIva = 0 Then
                    Me.Grid.Cell(IndexRow, iGySubtotalNuevo).Text = Format(dTotal, "###,###,##0." & Empresa_Sistema.DECIMALES_CONTABILIDAD)
                    Me.Grid.Cell(IndexRow, iGyIVANuevo).Text = Format(0, "###,###,##0." & Empresa_Sistema.DECIMALES_CONTABILIDAD)
                End If
            Next

            IndexRow = Me.Grid.Rows
            sFolio = Me.Grid.Cell(IndexRow, iGyFolio).Text
            dTotal = valorNumerico(Me.Grid.Cell(IndexRow, iGyDescuento).Text)
            bTieneIVA = CBool(IIf(valorNumerico(Me.Grid.Cell(IndexRow, iGyIVALocal).Text) > 0, True, False))

            If dTotal > 0 Then
                If bTieneIVA = True Then
                    sql = New Class_find("SELECT SUBTOTAL,IVA,TOTAL FROM DBO.FN_CXC_OBTIENE_DESGLOSE_DESCUENTO_VENTA_CON_IVA('" & sFolio & "','" & Usuario.Codigo_Plaza & "'," & dTotal & ")")

                    If dTotal <> valorNumerico(sql.Result3) Then
                        MsgBox("*Nota, esta venta tiene IVA y el sistema para poder calcularlo correctamente, cambió el importe capturado de " & Format(dTotal, "$###,###,##0." & Empresa_Sistema.DECIMALES_CONTABILIDAD) & " por " & Format(valorNumerico(sql.Result3), "$###,###,##0." & Empresa_Sistema.DECIMALES_CONTABILIDAD) & vbCrLf & _
                        "Si tiene dudas avíse al depto. de sistemas.", vbInformation, Me.Name)
                    End If

                    Me.Grid.Cell(IndexRow, Me.iGyDescuento).Text = Format(sql.Result3, "###,###,##0." & Empresa_Sistema.DECIMALES_CONTABILIDAD)
                    Me.Grid.Cell(IndexRow, Me.iGySubtotalNuevo).Text = Format(sql.Result1, "###,###,##0." & Empresa_Sistema.DECIMALES_CONTABILIDAD)
                    Me.Grid.Cell(IndexRow, Me.iGyIVANuevo).Text = Format(sql.Result2, "###,###,##0." & Empresa_Sistema.DECIMALES_CONTABILIDAD)
                End If
            End If

            bResultado = True

        Catch ex As Exception
            HandleError(Me.Name, "GestionaModoIVA", ex)
        End Try

        Return bResultado
    End Function

    Private Sub CalculaImporteDolares()
        Try
            If txtLEN(Me.TxtTotal.Text) = True And valorNumerico(Me.TxtTotal.Text) > 0 Then
                Me.txtTipoCambio.Text = valorNumerico(Me.txtTipoCambio.Text).ToString
                Me.txtTipoCambio.Text = Redondear(valorNumerico(Me.txtTipoCambio.Text), 4).ToString
                Me.txtImporteDolares.Text = (valorNumerico(Me.TxtTotal.Text) / valorNumerico(Me.txtTipoCambio.Text)).ToString
                Me.txtImporteDolares.Text = valorNumerico(Me.txtImporteDolares.Text).ToString
                Me.txtImporteDolares.Text = Redondear(valorNumerico(Me.txtImporteDolares.Text), 2).ToString
            Else
                Me.txtTipoCambio.Text = valorNumerico(Me.txtTipoCambio.Text).ToString
                Me.txtTipoCambio.Text = Redondear(valorNumerico(Me.txtTipoCambio.Text), 4).ToString
                Me.txtImporteDolares.Text = "0"
                Me.txtImporteDolares.Text = valorNumerico(Me.txtImporteDolares.Text).ToString
                Me.txtImporteDolares.Text = Redondear(valorNumerico(Me.txtImporteDolares.Text), 2).ToString
            End If
        Catch ex As Exception
            HandleError(Me.Name, "CalculaImporteDolares", ex)
        End Try
    End Sub

    Private Function GestionaGrabar() As Boolean
        Dim bResultado As Boolean = False
        Me.oPolizaGlobal = New Class_Contabilidad_Poliza_Global(Me.TxtFolio.Text)
        Try

            'Validar permiso
            If Usuario.ValidaPermisoUsuarioDocumentoSinAfectacionInventarios("NCG_CXC" & Usuario.Codigo_Plaza) = False Then
                MsgBox("El usuario " & Usuario.Nombre_Usuario & " no tiene permiso para realizar el movimiento.", MsgBoxStyle.Information, Me.Text)
                Exit Function
            End If

            If MsgBox("Deseas grabar el documento con el folio : " & Me.TxtFolio.Text & "?", CType(vbYesNo + vbQuestion, MsgBoxStyle), "Grabar") = MsgBoxResult.No Then
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
                    If Me.oDescuentosCXC.ActualizaFolioPoliza() = True Then
                        If Empresa_Sistema.FELECTRONICA_ACTIVA = True Then
                            If Me.GeneraNotaCreditoElectronica(False) = True Then
                                Me.oDescuentosCXC.ExportarAPdf()
                            End If
                        End If
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
        Dim i As Integer, dPago As Double, bDescuento As Boolean

        Try
            Me.GeneraFolio()

            'Me.oBancosCXC = New Class_Bancos_CXC
            Me.oDescuentosCXC = New Class_CXC_Descuento
            'If Me.oBancosCXC.Existe = True Then
            '    Exit Function
            'End If

            oDescuentosCXC.FOLIO_DESCUENTO = Me.TxtFolio.Text
            oDescuentosCXC.CODIGO_PLAZA = Usuario.Codigo_Plaza
            oDescuentosCXC.CODIGO_CLIENTE = Me.TxtCodigoCliente.Text
            oDescuentosCXC.SUBTOTAL = valorNumerico(Me.TxtSubTotal.Text)
            oDescuentosCXC.IVA = valorNumerico(Me.TxtImpuesto.Text)
            oDescuentosCXC.TOTAL = valorNumerico(Me.TxtTotal.Text)
            oDescuentosCXC.FECHA = Me.dtFecha.Value
            oDescuentosCXC.CONCEPTO1 = Me.TxtConcepto.Text.ToUpper
            oDescuentosCXC.CONCEPTO2 = Me.TxtConcepto2.Text.ToUpper
            oDescuentosCXC.CODIGO_USUARIO_GRABO = Usuario.Codigo_Usuario
            oDescuentosCXC.TIPO_DE_CAMBIO = valorNumerico(Me.txtTipoCambio.Text)
            oDescuentosCXC.ES_POR_DEVOLUCION = "0"
            If Empresa_Sistema.FELECTRONICA_ACTIVA = True Then
                oDescuentosCXC.ES_COMPROBANTE_ELECTRONICO = "1"
            Else
                oDescuentosCXC.ES_COMPROBANTE_ELECTRONICO = "0"
            End If
            oDescuentosCXC.ES_VENTA_PUBLICO_GENERAL = Convert.ToInt32(Me.ckbVentaPublicoGeneral.Checked).ToString

            oDescuentosCXC.InsertarDescuentos()

            Me.TxtFolio.Text = oDescuentosCXC.FOLIO_DESCUENTO

            Me.oCxcAfectaDocumentos = New Class_CXC_Afecta_Documentos

            Dim dt As New DataTable
            Dim dr As DataRow, sCodigoFactura As String, j As Integer, k As Integer

            dt.Columns.Add(New DataColumn("FOLIO_VENTA", GetType(String)))
            dt.Columns.Add(New DataColumn("SALDO", GetType(String)))
            dt.Columns.Add(New DataColumn("DESCUENTO", GetType(Decimal)))

            For iRow = 1 To Me.Grid.Rows - 1
                dr = dt.NewRow()
                dr("FOLIO_VENTA") = Me.Grid.Cell(iRow, Me.iGyFolio).Text
                dr("SALDO") = Me.Grid.Cell(iRow, Me.iGySaldo).Text
                dr("DESCUENTO") = valorNumerico(Me.Grid.Cell(iRow, Me.iGyDescuento).Text)
                dt.Rows.Add(dr)
            Next

            For i = 1 To Me.Grid.Rows - 1
                sCodigoFactura = Me.Grid.Cell(i, Me.iGyFolio).Text
                j = i + 1
                If valorNumerico(Me.Grid.Cell(i, Me.iGyDescuento).Text) > 0 Or bDescuento = True Then
                    If sCodigoFactura <> IIf(j > Me.Grid.Rows - 1, "", Me.Grid.Cell(j, Me.iGyFolio).Text).ToString And Me.Grid.Rows > 2 Then
                        oCxcAfectaDocumentos.FOLIO_CXC = "" 'Me.TxtFolio.Text
                        oCxcAfectaDocumentos.CODIGO_CLIENTE = Me.TxtCodigoCliente.Text
                        oCxcAfectaDocumentos.FECHA = Me.dtFecha.Value
                        'oCxcAfectaDocumentos.CODIGO_DOCUEMTO=""
                        oCxcAfectaDocumentos.CODIGO_PLAZA = Usuario.Codigo_Plaza
                        oCxcAfectaDocumentos.FOLIO_REFERENCIA = Me.Grid.Cell(i, Me.iGyFolio).Text 'folio de la compra
                        oCxcAfectaDocumentos.FOLIO_REFERENCIA_USUARIO = "" 'Folio factura Cliente de la venta, no tenemos
                        oCxcAfectaDocumentos.ID_MEDIO_PAGO = 0
                        oCxcAfectaDocumentos.CODIGO_BANCO = "NA"
                        oCxcAfectaDocumentos.CONCEPTO1 = Me.TxtConcepto.Text
                        oCxcAfectaDocumentos.CONCEPTO2 = ""
                        oCxcAfectaDocumentos.TOTAL = valorNumerico(dt.Compute("sum(DESCUENTO)", "FOLIO_VENTA='" & Me.Grid.Cell(i, Me.iGyFolio).Text & "'").ToString())
                        oCxcAfectaDocumentos.TIPO_DE_CAMBIO = valorNumerico(Me.txtTipoCambio.Text)
                        oCxcAfectaDocumentos.CODIGO_USUARIO_GRABO = Usuario.Codigo_Usuario
                        'oCxcAfectaDocumentos.CODIGO_MODULO="CXC"
                        bResultado = oCxcAfectaDocumentos.AfectaDocumentos()

                        oDescuentosCXC.InsertaDescuentoDetalle(oCxcAfectaDocumentos.FOLIO_CXC.ToString)
                        For k = 1 To Me.Grid.Rows - 1
                            dPago = valorNumerico(Me.Grid.Cell(k, Me.iGyDescuento).Text)
                            If dPago > 0 And sCodigoFactura = Me.Grid.Cell(k, Me.iGyFolio).Text Then
                                oDescuentosCXC.InsertaDescuentoCultivoDetalle(oCxcAfectaDocumentos.FOLIO_CXC, valorNumerico(Me.Grid.Cell(k, Me.iGyDescuento).Text), Me.Grid.Cell(k, Me.iGyCodigoCultivo).Text)
                            End If
                        Next k
                        bDescuento = False
                    Else
                        bDescuento = True
                    End If
                    'Else
                    '    bDescuento = True
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
                Exit Function
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
        Dim bResultado As Boolean = False
        Dim oCliente As New Class_CatClientes()
        Dim i As Integer

        Dim dDescuentoFactura As Double 'dt As DataTable = DirectCast(Me.Grid.DataSource, DataTable),
        Dim dt As New DataTable
        Dim dr As DataRow

        dt.Columns.Add(New DataColumn("FOLIO_VENTA", GetType(String)))
        dt.Columns.Add(New DataColumn("SALDO", GetType(String)))
        dt.Columns.Add(New DataColumn("DESCUENTO", GetType(Decimal)))

        For iRow = 1 To Me.Grid.Rows - 1
            dr = dt.NewRow()
            dr("FOLIO_VENTA") = Me.Grid.Cell(iRow, Me.iGyFolio).Text
            dr("SALDO") = Me.Grid.Cell(iRow, Me.iGySaldo).Text
            dr("DESCUENTO") = valorNumerico(Me.Grid.Cell(iRow, Me.iGyDescuento).Text)
            dt.Rows.Add(dr)
        Next

        Try
            If Plaza.ValidarPeriodoTrabajo(Me.dtFecha.Value) = False Then
                Exit Function
            End If

            oCliente = New Class_CatClientes(Me.TxtCodigoCliente.Text)

            If oCliente.Existe = False Or oCliente.Estatus = "B" Then
                MsgBox("El código de Cliente que intenta introducir no existe o esta dado de baja, favor de intentar con otro código.", MsgBoxStyle.Exclamation, "Validación de Clientees")
                Me.LblCliente.Text = ""
                Me.TxtCodigoCliente.Focus()
                Exit Function
            Else
                Me.LblCliente.Text = oCliente.NOMBRE_CLIENTE.ToString
            End If

            'If Me.ckbVentaPublicoGeneral.Checked = False Then
            '    If Me.ValidarDatosCliente() = False Then
            '        Exit Function
            '    End If
            'End If

            If txtLEN(Me.TxtConcepto.Text) = False Then
                MsgBox("Asigne un concepto de descuento.", MsgBoxStyle.Exclamation, Me.Nombre_Modulo)
                Me.TxtConcepto.Focus()
                Exit Function
            End If

            If valorNumerico(Me.TxtTotal.Text) <= 0 Then
                MsgBox("No asignó los documentos a pagar. El total a pagar debe ser mayor que cero.", MsgBoxStyle.Exclamation, Me.Nombre_Modulo)
                Exit Function
            End If

            'If valorNumerico(Me.TxtFalta.Text) <> 0 Then
            '    MsgBox("El importe es diferente al descuento total.", MsgBoxStyle.Exclamation, Me.Nombre_Modulo)
            '    Exit Function
            'End If

            For i = 1 To Grid.Rows - 1
                If valorNumerico(Me.Grid.Cell(i, Me.iGyDescuento).Text) > 0 And txtLEN(Me.Grid.Cell(i, Me.iGyFolio).Text) = True Then
                    Dim sql As New Class_find("SELECT SALDO,CODIGO_TIPO_MERCADO FROM VENTA_GLOBAL WHERE FOLIO_VENTA='" & Me.Grid.Cell(i, Me.iGyFolio).Text & "'")
                    Me.Grid.Cell(i, Me.iGySaldo).Text = sql.Result1
                    If valorNumerico(Me.Grid.Cell(i, Me.iGyDescuento).Text) > valorNumerico(Me.Grid.Cell(i, Me.iGySaldo).Text) Then
                        MsgBox("El pago en el renglón: " & i & " es mayor al saldo del documento favor de revisar.", MsgBoxStyle.Exclamation, "Validación de descuentos de CXC")
                        Me.Grid.Cell(i, Me.iGyDescuento).Text = "" '0.ToString
                        Me.Grid.Cell(i, Me.iGyDescuento).SetFocus()
                        Exit Function
                    ElseIf valorNumerico(Me.Grid.Cell(i, Me.iGyDescuento).Text) > valorNumerico(Me.Grid.Cell(i, Me.iGyImporte).Text) Then
                        MsgBox("El pago en el renglón: " & i & " es mayor al importe del documento favor de revisar.", MsgBoxStyle.Exclamation, "Validación de descuentos de CXC")
                        Me.Grid.Cell(i, Me.iGyDescuento).Text = "" '0.ToString
                        Me.Grid.Cell(i, Me.iGyDescuento).SetFocus()
                        Exit Function
                    ElseIf Me.ckbDolares.Checked = True And sql.Result2 = "0002" Then 'MERCADO NACIONAL
                        MsgBox("Los descuentos en dolares deben de ser a ventas de exportacion. Favor de revisar.", MsgBoxStyle.Exclamation, "Validación de descuentos de CXC")
                        Exit Function
                    ElseIf Me.ckbDolares.Checked = False And sql.Result2 = "0001" Then 'MERCADO exportacion
                        MsgBox("Los descuentos nacionales deben de ser a ventas de nacional. Favor de revisar.", MsgBoxStyle.Exclamation, "Validación de descuentos de CXC")
                        Exit Function
                    End If
                End If
            Next i

            If Me.ckbDolares.Checked = True Then
                If valorNumerico(Me.txtTipoCambio.Text) = 0 Then
                    MsgBox("El tipo de cambio debe ser mayor a 0. Favor de revisar.", MsgBoxStyle.Exclamation, "Validación de descuentos de CXC")
                    Exit Function
                End If
            End If

            For i = 1 To Me.Grid.Rows - 1
                If Len(Me.Grid.Cell(i, Me.iGyFolio).Text) > 0 Then
                    If txtLEN(Me.Grid.Cell(i, Me.iGyCodigoCultivo).Text) = True Then
                        dDescuentoFactura = valorNumerico(dt.Compute("sum(DESCUENTO)", "FOLIO_VENTA='" & Me.Grid.Cell(i, Me.iGyFolio).Text & "'").ToString)
                        Dim oVenta As New Class_Ventas_Global()
                        oVenta = New Class_Ventas_Global(Me.Grid.Cell(i, Me.iGyFolio).Text)

                        If valorNumerico(dDescuentoFactura.ToString) > oVenta.SALDO Then
                            MsgBox("El saldo de la factura " & Me.Grid.Cell(i, Me.iGyFolio).Text & " es menor al descuento.", MsgBoxStyle.Exclamation, "Validación de descuentos de CXC")
                            Exit Function
                        End If
                        'ElseIf valorNumerico(Me.Grid.Cell(i, Me.iGyDescuento).Text) > 0 Then
                        '    MsgBox("La factura que desea aplicar un descuento no tiene codigo de cultivo " & Me.Grid.Cell(i, Me.iGyFolio).Text & ".", MsgBoxStyle.Exclamation, "Validación de descuentos de CXC")
                        '    Me.Grid.Cell(i, Me.iGyDescuento).Text = ""
                        '    Exit Function
                    End If
                End If
            Next i

            bResultado = True

        Catch ex As Exception
            HandleError(Me.Name, "Validar", ex)
        End Try

        Return bResultado
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

    Private Function ValidaPrePoliza() As Boolean
        Dim bResultado As Boolean = False
        Dim oCliente As Class_CatClientes
        Dim oCuenta As Class_CatCuentas
        'Dim oVentas As Class_Ventas_Global
        Dim i As Integer, sCultivo As String = ""

        Try
            If ExisteDocumento(Me.TxtFolio.Text) = True Then
                MsgBox("El folio : " & Me.TxtFolio.Text & " ya existe, verifíquelo.", MsgBoxStyle.Exclamation, "Contabilizar")
                Exit Function
            End If

            'Me.GeneraFolio() 'No hay que generar folio nuevo porque se manda el folio del documento

            Me.oFormaPoliza = New Frm_Contabilidad_Captura_Polizas

            Me.oFormaPoliza.StartPosition = FormStartPosition.CenterScreen

            Me.oFormaPoliza.ChildParaGrabar = True
            Me.oFormaPoliza.CodigoDocumentoParaGrabar = "D"

            Me.oFormaPoliza.DtpFecha.Value = Me.dtFecha.Value
            Me.oFormaPoliza.TxtTotalCargos.Text = Me.TxtTotal.Text
            Me.oFormaPoliza.TxtTotalAbonos.Text = Me.TxtTotal.Text
            Me.oFormaPoliza.TxtConcepto1.Text = Me.TxtConcepto.Text

            Me.oFormaPoliza.lblFolioOrigen.Text = Me.TxtFolio.Text
            Me.oFormaPoliza.TxtFolio.Text = Me.TxtFolio.Text

            Me.oFormaPoliza.Grid1.Rows = 2
            Me.oFormaPoliza.Grid1.Cols = 9

            oCliente = New Class_CatClientes(Me.TxtCodigoCliente.Text)

            Me.oFormaPoliza.Grid1.Cell(1, 1).Text = oCliente.CUENTA_CONTABLE.ToString
            Me.oFormaPoliza.Grid1.Cell(1, 2).Text = oCliente.NOMBRE_CLIENTE
            Me.oFormaPoliza.Grid1.Cell(1, 3).Text = Me.Grid.Cell(2, Me.iGySubtotalNuevo).Text
            Me.oFormaPoliza.Grid1.Cell(1, 4).Text = "D"
            Me.oFormaPoliza.Grid1.Cell(1, 5).Text = "0"
            Me.oFormaPoliza.Grid1.Cell(1, 6).Text = Me.TxtTotal.Text

            'Me.oFormaPoliza.Grid1.Rows = Me.oFormaPoliza.Grid1.Rows + 3
            ''Pone los renglones segun el codigo de descuentos del cultivo 
            For i = 1 To Me.Grid.Rows - 1
                If Me.Grid.Cell(i, Me.iGyFolio).Text <> "" And valorNumerico(Me.Grid.Cell(i, Me.iGyDescuento).Text) > 0 Then

                    'La comersializadora es una cuenta fija y no va por cultivo
                    'If Empresa_Sistema.RFC = "LPR070917RT9" Then
                    '    sCultivo = "0000" + Me.Grid.Cell(i, Me.iGyCodigoCultivo).Text
                    '    oCuenta = New Class_CatCuentas("5100" & sCultivo.Substring(Len(sCultivo) - 4))
                    'Else
                    '    oCuenta = New Class_CatCuentas("510000020001")
                    'End If

                    sCultivo = "0000" + Me.Grid.Cell(i, Me.iGyCodigoCultivo).Text
                    oCuenta = New Class_CatCuentas("5100" & sCultivo.Substring(Len(sCultivo) - 4))

                    Me.oFormaPoliza.Grid1.Rows = Me.oFormaPoliza.Grid1.Rows + 1
                    If txtLEN(Me.Grid.Cell(i, Me.iGyCodigoCultivo).Text) = False Then
                        Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 1).Text = ""
                    Else
                        Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 1).Text = oCuenta.CUENTA_CONTABLE 'Plaza.CUENTA_DESCUENTOS_REBAJAS_NACIONALES & sCultivo.Substring(Len(sCultivo) - 4)
                        Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 2).Text = oCuenta.NOMBRE_CUENTA
                    End If
                    Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 3).Text = oCliente.NOMBRE_CLIENTE
                    Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 4).Text = "A"
                    Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 5).Text = Me.Grid.Cell(i, Me.iGyDescuento).Text
                    Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 6).Text = "0"
                End If
            Next i

            'poner el nombre del cliente al cual se le hiso el descuento
            'Me.AgregaPrepolizaIVAAcreditable()
            If Me.ckbDolares.Checked = True Then
                Me.CalculaImporteDolares()

                If txtLEN(oCliente.CUENTA_CONTABLE_DOLARES) = False Then
                    MsgBox("El cliente no tiene cuenta contable en dólares. Favor de revisar.", MsgBoxStyle.Exclamation, "Validación de descuentos de CXC")
                    Exit Function
                End If

                Me.oFormaPoliza.Grid1.Rows = Me.oFormaPoliza.Grid1.Rows + 1
                Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 1).Text = oCliente.CUENTA_CONTABLE_DOLARES
                Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 2).Text = oCliente.NOMBRE_CLIENTE
                Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 3).Text = Me.oFormaPoliza.TxtConcepto1.Text
                Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 4).Text = "A"
                Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 5).Text = Me.txtImporteDolares.Text
                Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 6).Text = "0"

                oCuenta = New Class_CatCuentas(Empresa_Sistema.CUENTA_CONTABLE_CLIENTES_CONTRA_CUENTA_DOLARES)
                Me.oFormaPoliza.Grid1.Rows = Me.oFormaPoliza.Grid1.Rows + 1
                Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 1).Text = oCuenta.CUENTA_CONTABLE
                Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 2).Text = oCuenta.NOMBRE_CUENTA
                Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 3).Text = Me.oFormaPoliza.TxtConcepto1.Text
                Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 4).Text = oCuenta.NATURALEZA_CONTABLE
                Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 5).Text = "0"
                Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 6).Text = Me.txtImporteDolares.Text
            End If

            Me.oFormaPoliza.lblEstatus.Text = "N"

            Me.oFormaPoliza.ShowDialog()

            bResultado = Me.oFormaPoliza.FormaValidaParaGrabarLlamadoExterior

        Catch ex As Exception
            HandleError(Me.Text, "ValidaPrePoliza", ex)
        Finally
            oCuenta = Nothing
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
                sCodigoDocumento = Me.Grid.Cell(i, Me.iGyFolio).Text
                dPago = valorNumerico(Me.Grid.Cell(i, Me.iGyDescuento).Text)
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
            'Me.oBancosCXC = New Class_Bancos_CXC(sFolio)
            Me.oDescuentosCXC = New Class_CXC_Descuento(sFolio)
            Me.oPolizaGlobal = New Class_Contabilidad_Poliza_Global(sFolio)

            If Me.oDescuentosCXC.Existe = False Then
                Me.GeneraFolio()
                Me.Cambia_Estado(enumEstados.NUEVO)
                Me.TxtFolio.Enabled = False
                Exit Function
            Else
                Me.TxtFolio.Text = Me.oDescuentosCXC.FOLIO_DESCUENTO
                Me.TxtFolio.Enabled = False

                Me.dtFecha.Value = oDescuentosCXC.FECHA
                Me.LblStatus.Text = oDescuentosCXC.ESTATUS_DESCUENTO
                'Me.LblPoliza.Text = oDescuentosCXC.FOLIO_POLIZA
                Me.TxtConcepto.Text = oDescuentosCXC.CONCEPTO1
                Me.TxtConcepto2.Text = oDescuentosCXC.CONCEPTO2
                Me.TxtCodigoCliente.Text = oDescuentosCXC.CODIGO_CLIENTE
                Me.LblCliente.Text = oDescuentosCXC.NOMBRE_CLIENTE
                Me.LblPoliza.Text = oDescuentosCXC.FOLIO_POLIZA.ToString
                If oDescuentosCXC.TIPO_DE_CAMBIO > 0 Then
                    Me.ckbDolares.Checked = True
                    Me.txtTipoCambio.Text = oDescuentosCXC.TIPO_DE_CAMBIO.ToString
                    Me.CalculaImporteDolares()
                End If
                Me.TxtSubTotal.Text = oDescuentosCXC.SUBTOTAL.ToString
                Me.TxtImpuesto.Text = oDescuentosCXC.IVA.ToString
                'Me.TxtTotal.Text = oDescuentosCXC.TOTAL.ToString
                Me.TxtTotal.Text = FormatImporteContable(oDescuentosCXC.TOTAL)

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

    'Private Function CargaVentasConSaldo() As Boolean
    '    Dim dTabla As DataTable
    '    Try
    '        dTabla = oBancosCXC.CargaVentasClienteConSaldo(Me.TxtCodigoCliente.Text)
    '        Me.Grid.Rows = 1
    '        For Each dRow As DataRow In dTabla.Rows
    '            Me.Grid.AddItem(dRow(0).ToString & Chr(9) & Format(CDate(dRow(1)), "dd-MMM-yyyy") & Chr(9) & dRow(2).ToString & Chr(9) & dRow(3).ToString & Chr(9) & dRow(4).ToString & Chr(9) & _
    '                            dRow(5).ToString & Chr(9) & dRow(6).ToString & Chr(9) & dRow(7).ToString & Chr(9) & dRow(8).ToString)
    '        Next

    '        'No es posible hace un datasource y luego intentar cambiar datos de celdas con codigo, no marca error pero no hace el cambio
    '        'Me.Grid1.DataSource = Me.oBancosCXC.CargaComprasClienteConSaldo(Me.TxtCodigoCliente.Text)
    '        'Me.Grid.Rows += 1

    '        If dTabla.Rows.Count = 0 Then
    '            MsgBox("El Cliente no tiene ventas con saldo.", MsgBoxStyle.Information, Me.Text)
    '        End If

    '        CargaVentasConSaldo = True
    '        Me.FormateaGrid()

    '    Catch ex As Exception
    '        HandleError(Me.Name, "CargaVentasConSaldo", ex)
    '    End Try
    'End Function

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

    Private Function CancelaDescuentosCXC() As Boolean
        Dim bResultado As Boolean = False
        'Dim oFirmaElectronica = New UtileriasFirmaElectronicaCancelacionMovimientosFueraPeriodo
        Dim oUtileriasCancela As New Class_UtileriasFirmaElectronicaCancelacion
        Dim oPoliza As New Class_Contabilidad_Poliza_Global
        'Dim sFolio As String = Me.TxtFolio.Text

        'Me.oBancosCXC = New Class_Bancos_CXC(sFolio)

        If MsgBox("Deseas cancelar el movimiento " & Me.TxtFolio.Text & " ?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "CancelaDescuentosCXC") = MsgBoxResult.No Then
            Exit Function
        End If

        If Usuario.ValidaPermisoUsuarioDocumentoSinAfectacionInventarios("NCG_CXC" & Usuario.Codigo_Plaza) = False Then
            MsgBox("El usuario " & Usuario.Nombre_Usuario & " no tiene permiso para realizar el movimiento.", MsgBoxStyle.Exclamation, Me.Text)
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

        If Me.oDescuentosCXC.VERSION_ESQUEMA_XML <> Empresa_Sistema.VERSION_ESQUEMA_CFD Then
            MsgBox("La versión del esquema es diferente al actual. .", MsgBoxStyle.Exclamation, Me.Text)
            Exit Function
        End If

        Try
            oUtileriasCancela.FOLIO_DOCUMENTO = Me.TxtFolio.Text.ToUpper
            oUtileriasCancela.MODULO = "CXC"
            oUtileriasCancela.CODIGO_PLAZA = Usuario.Codigo_Plaza

            If oUtileriasCancela.GestionaCancelacion() = False Then
                Exit Function
            End If

            If oUtileriasCancela.CANCELA_DIRECTO = True Then

                Me.oDescuentosCXC.FECHA_CANCELACION = Now()

                If Me.oDescuentosCXC.CancelaDescuentoCXC() = False Then
                    MsgBox("Error al intentar cancelar el movimiento de documento de descuento.", MsgBoxStyle.Exclamation, Me.Text)
                    Exit Function
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
                End If

                Me.oDescuentosCXC.FECHA_CANCELACION = oUtileriasCancela.FECHA_CANCELACION

                If Me.oDescuentosCXC.CancelaDescuentoCXC() = False Then
                    MsgBox("Error al intentar cancelar el movimiento de documento de descuento.", MsgBoxStyle.Exclamation, Me.Text)
                    Exit Function
                End If

            End If

            MsgBox("Movimiento de descuento cancelado satisfactoriamente.", MsgBoxStyle.Information, Me.Text)
            bResultado = True
        Catch ex As Exception
            HandleError(Me.Name, "CancelaDescuentosCXC", ex)
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
        Me.oBancosCXC.CODIGO_DOCUMENTO = "NCG_CXC" & Usuario.Codigo_Plaza.ToString
        Me.TxtFolio.Text = Me.oBancosCXC.GeneraFolio
    End Sub

    Private Sub Cambia_Estado(ByVal pEstado As enumEstados)
        Try
            Me.Estado = pEstado
            Select Case Me.Estado
                Case enumEstados.NUEVO
                    Me.tsbGrabar.Enabled = True
                    Me.tsbCancelar.Enabled = False
                    Me.tsbImprimir.Enabled = False
                    Me.dtFecha.Enabled = True
                    Me.TxtCodigoCliente.Enabled = True
                    Me.TxtConcepto.Enabled = True
                    Me.TxtConcepto2.Enabled = True
                    Me.ckbDolares.Enabled = True
                    Me.ckbVentaPublicoGeneral.Enabled = True
                    Me.txtTipoCambio.Enabled = False
                    Me.txtImporteDolares.Enabled = False
                    Me.tssEstado.Text = "Estado: agregando documento " & Me.Nombre_Modulo
                    Me.tssElaboro.Visible = False
                    Me.tssCancelo.Visible = False
                    Me.Grid.Locked = False
                    Me.TxtFolio.Enabled = True
                    If Me.Visible = True Then
                        Me.TxtFolio.Focus()
                    End If

                    Me.tsbSellarNotaElectronica.Visible = False
                    Me.tsbGeneraAcuseCancelacion.Visible = False

                Case enumEstados.APLICADO
                    Me.tsbGrabar.Enabled = False
                    Me.tsbCancelar.Enabled = True
                    Me.tsbImprimir.Enabled = True
                    Me.dtFecha.Enabled = False
                    Me.TxtCodigoCliente.Enabled = False
                    Me.TxtConcepto.Enabled = False
                    Me.TxtConcepto2.Enabled = False
                    Me.ckbDolares.Enabled = False
                    Me.ckbVentaPublicoGeneral.Enabled = False
                    Me.txtTipoCambio.Enabled = False
                    Me.txtImporteDolares.Enabled = False
                    Me.tssEstado.Text = "Estado: Consulta de " & Me.Nombre_Modulo
                    Me.tssElaboro.Visible = True
                    Me.tssCancelo.Visible = False
                    Me.Grid.Locked = True
                    Me.Grid.Cell(0, Me.iGyDescuento).Text = "DESCUENTO"
                    Me.Grid.Column(Me.iGyIVALocal).Visible = False

                    Me.tsbImprimir.Select()
                    If Me.oDescuentosCXC.VERSION_ESQUEMA_XML >= "3.2" Or Me.oDescuentosCXC.VERSION_ESQUEMA_XML = "" Or Me.oDescuentosCXC.VERSION_ESQUEMA_XML = "0" Then
                        If Me.oDescuentosCXC.TIMBRADO_CFDI = "0" And Me.oDescuentosCXC.TIMBRADO_DESCARTADO = "0" Then
                            Me.tsbSellarNotaElectronica.Visible = True
                            Me.tsbGeneraAcuseCancelacion.Visible = False
                        Else
                            Me.tsbSellarNotaElectronica.Visible = False
                        End If
                    Else
                        Me.tsbSellarNotaElectronica.Visible = False
                        Me.tsbGeneraAcuseCancelacion.Visible = False
                    End If

                Case enumEstados.CANCELADO
                    Me.tsbGrabar.Enabled = False
                    Me.tsbCancelar.Enabled = False
                    Me.tsbImprimir.Enabled = True
                    Me.dtFecha.Enabled = False
                    Me.TxtCodigoCliente.Enabled = False
                    Me.TxtConcepto.Enabled = False
                    Me.TxtConcepto2.Enabled = False
                    Me.ckbDolares.Enabled = False
                    Me.ckbVentaPublicoGeneral.Enabled = False
                    Me.txtTipoCambio.Enabled = False
                    Me.txtImporteDolares.Enabled = False
                    Me.tssEstado.Text = "Estado: Consulta de " & Me.Nombre_Modulo
                    Me.tssElaboro.Visible = True
                    Me.tssCancelo.Visible = True
                    Me.Grid.Locked = True
                    Me.Grid.Cell(0, Me.iGyDescuento).Text = "DESCUENTO"
                    Me.Grid.Column(Me.iGyIVALocal).Visible = False

                    Me.tsbImprimir.Select()
                    If Me.oDescuentosCXC.VERSION_ESQUEMA_XML >= "3.2" Or Me.oDescuentosCXC.VERSION_ESQUEMA_XML = "" Then
                        If Me.oDescuentosCXC.ESTATUS_CANCELACION_CFDI = "1" Then
                            Me.tsbSellarNotaElectronica.Visible = False
                            Me.tsbGeneraAcuseCancelacion.Visible = False
                        Else
                            Me.tsbGeneraAcuseCancelacion.Visible = True
                        End If
                    Else
                        Me.tsbSellarNotaElectronica.Visible = False
                        Me.tsbGeneraAcuseCancelacion.Visible = False
                    End If

            End Select
        Catch ex As Exception
            HandleError(Me.Name, "Cambia_Estado", ex)
        End Try
    End Sub

    Private Function ValidarFactura(Optional ByVal Codigo As String = "") As Boolean
        Dim bResultado As Boolean = False
        Dim i As Integer, j As Integer
        Dim sCodigoFactura As String = "", sCodigoCultivo As String = ""

        Try
            If txtLEN(Codigo) = False Then
                For i = 1 To Me.Grid.Rows - 1
                    sCodigoFactura = Me.Grid.Cell(i, Me.iGyFolio).Text
                    sCodigoCultivo = Me.Grid.Cell(i, Me.iGyCodigoCultivo).Text
                    For j = i + 1 To Me.Grid.Rows - 1
                        If txtLEN(Me.Grid.Cell(j, Me.iGyFolio).Text) = True Then
                            If sCodigoFactura = Me.Grid.Cell(j, Me.iGyFolio).Text And sCodigoCultivo = Me.Grid.Cell(j, Me.iGyCodigoCultivo).Text And Me.Grid.Rows > 2 Then
                                MsgBox("La factura que intenta introducir ya existe, favor de intentar con otro código.", MsgBoxStyle.Exclamation, "Validación de descuentos de CXC")
                                Me.Grid.Cell(i, Me.iGyFolio).SetFocus()
                                Exit Function
                            End If
                        End If
                    Next j
                Next i
            Else
                sCodigoFactura = Codigo

                For j = 1 To Me.Grid.Rows - 1
                    If txtLEN(Me.Grid.Cell(j, Me.iGyFolio).Text) = True Then
                        If sCodigoFactura = Me.Grid.Cell(j, Me.iGyFolio).Text And Me.Grid.Rows > 2 Then
                            MsgBox("La factura que intenta introducir ya existe, favor de intentar con otro código.", MsgBoxStyle.Exclamation, "Validación de descuentos de CXC")
                            Exit Function
                        End If
                    End If
                Next j
            End If

            bResultado = True
        Catch ex As Exception
            HandleError(Me.Name, "ValidarFactura", ex)
        End Try

        Return bResultado
    End Function

    Private Sub DistribucionDescuento()
        'Dim Dato As String, sFolio As String
        'Dim dTabla As DataTable
        'Dim Renglon As Integer = Me.Grid.Selection.FirstRow
        'sFolio = Me.Grid.Cell(Renglon, Me.iGyFolio).Text

        'If txtLEN(sFolio) = False Then
        '    MsgBox("Seleccione un renglon con folio de venta, favor de revisar.", MsgBoxStyle.Exclamation, "Distribución del descuento")
        '    Exit Sub
        'End If

        'Dim oVentas As New Class_Ventas_Global
        'oVentas = New Class_Ventas_Global(sFolio)

        'If oVentas.Existe = False Then
        '    MsgBox("El folio de venta no existe, favor de revisar.", MsgBoxStyle.Exclamation, "Distribución del descuento")
        '    Exit Sub
        'End If

        'Do
        '    Dato = InputBox("Ingresar la cantidad del descuento a distribuir", " Distribución del descuento ")
        'Loop Until valorNumerico(Dato) > 0 And valorNumerico(Dato) <= valorNumerico(Me.TxtFalta.Text) Or Dato = ""

        'If txtLEN(Dato) = False Then
        '    Exit Sub
        'End If

        'Try
        '    dTabla = oDescuentosCXC.DistribucionDescuentos(sFolio, CDbl(Dato))
        '    Dim i As Integer
        '    For Each dRow As DataRow In dTabla.Rows
        '        For i = 1 To Me.Grid.Rows - 1
        '            If txtLEN(Me.Grid.Cell(i, Me.iGyFolio).Text) = True Then
        '                If Me.Grid.Cell(i, Me.iGyFolio).Text = sFolio And Me.Grid.Cell(i, Me.iGyCodigoCultivo).Text = dRow(0).ToString Then
        '                    Me.Grid.Cell(i, Me.iGyDescuento).Text = dRow(1).ToString
        '                End If
        '            End If
        '        Next
        '    Next

        'Catch ex As Exception
        '    HandleError(Me.Name, "DistribucionDescuento", ex)
        'End Try
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

    'Private Function CalculaImpuestosYTotales(ByVal sAccion As String) As Boolean
    '    Try
    '        Dim cmd As New Command, rsD As New ADODB.Recordset, sFoliosConDescuento As String, i As Integer

    '        dtSubtotal = 0 : dtIVA = 0 : dtTotal = 0 : dtIEPSDesglosado = 0 : dtIEPSIIncluido = 0

    '        sFoliosConDescuento = "|"

    '        For i = 1 To Grid.Rows - 1
    '            If valorNumerico(Me.Grid.TextMatrix(i, iGyDescuento)) > 0 Then
    '                sFoliosConDescuento = sFoliosConDescuento & Me.Grid.TextMatrix(i, iGyFolio) & "," & valorNumerico(Me.Grid.TextMatrix(i, iGyDescuento)) & "|"
    '            End If
    '        Next i

    '        .CommandText = "MP_CXC_DESCUENTOS_CALCULA_IMPUESTOS_Y_TOTALES"

    '        .Parameters.Append.CreateParameter("@FOLIOS_CON_IMPORTES", adVarWChar, adParamInput, 4000, sFoliosConDescuento)
    '        .Parameters.Append.CreateParameter("@FOLIO_DESCUENTO", adVarWChar, adParamInput, 12, Me.TxtFolio.Text)
    '        .Parameters.Append.CreateParameter("@ACCION", adVarWChar, adParamInput, 20, sAccion)


    '        While Not rsD.EOF
    '            Me.lblSubTotal.Caption = "$ " & Format("" & rsD!subTotal, "###,###,##0." & empresa.frconta)
    '            Me.lbliva.Caption = "$ " & Format("" & rsD!iva, "###,###,##0." & empresa.frconta)
    '            Me.lbltotal.Caption = "$ " & Format("" & rsD!total, "###,###,##0." & empresa.frconta)

    '            Me.lblIEPS.Caption = "$ " & Format("" & rsD!IEPS_DESGLOSADO, "###,###,##0." & empresa.frconta)
    '            Me.lblIEPSIncluido.Caption = "$ " & Format("" & rsD!IEPS_INCLUIDO, "###,###,##0." & empresa.frconta)

    '            Me.lblTotalFaltante.Caption = "$ " & Format(valorNumerico(Me.TxtImporte.Text) - valorNumerico("" & rsD!total), "###,###,##0." & empresa.frconta)

    '            dtSubtotal = rsD!subTotal
    '            dtIVA = rsD!iva
    '            dtTotal = rsD!total
    '            dtIEPSDesglosado = rsD!IEPS_DESGLOSADO
    '            dtIEPSIIncluido = rsD!IEPS_INCLUIDO

    '            rsD.MoveNext()
    '        End While
    '        rsD.Close() : rsD = Nothing

    '        CalculaImpuestosYTotales = True

    '    Catch ex As Exception
    '        HandleError(Me.Name, "CalculaImpuestosYTotales", ex)
    '    End Try

    'End Function

#End Region

End Class



