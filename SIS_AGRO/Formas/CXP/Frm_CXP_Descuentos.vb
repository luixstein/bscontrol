Option Strict On
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports System.Collections.Specialized
Imports CrystalDecisions.Shared

Public Class Frm_CXP_Descuentos

#Region "Propiedades"
    Public ReadOnly Property Nombre_Modulo() As String
        Get
            Return "Descuentos cxp."
        End Get
    End Property
#End Region

    Private Enum enumEstados
        NUEVO
        APLICADO
        CANCELADO
    End Enum

    Private Estado As enumEstados

    Private oBancosCXP As New Class_Bancos_CXP
    Private oCxpAfectaDocumentos As New Class_CXP_Afecta_Documentos
    Private oFormaPoliza As Frm_Contabilidad_Captura_Polizas
    Private oPolizaGlobal As Class_Contabilidad_Poliza_Global
    Private oDescuentosCXP As New Class_CXP_Descuento
    Private oProveedores As New Class_CatProveedores

    Private iGyFolio As Integer = 1
    Private iGyFecha As Integer = 2
    'Private iGyFolioCompra As Integer 3
    'Private iGyConcepto As Integer 4
    Private iGyImporte As Integer = 3
    Private iGySaldo As Integer = 4
    Private iGySubtotalDescuento As Integer = 5
    Private iGyIVADescuento As Integer = 6
    Private iGyDescuento As Integer = 7
    Private iGyTieneIva As Integer = 8

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
        Inicializa()
        Me.Cambia_Estado(enumEstados.NUEVO)
    End Sub

    Private Sub tsbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGrabar.Click
        If Me.GestionaGrabar() = True Then
            Me.Consultar()
        End If
    End Sub

    Private Sub tsbCancelar_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCancelar.Click
        If Me.CancelaDescuentosCXP() = True Then
            Me.Consultar()
        End If
    End Sub

    Private Sub tsbImprimirPoliza_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click
        Me.Imprimir()
    End Sub

    'Private Sub tsbSellarFacturaElectronica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSellarNotaElectronica.Click
    '    If GeneraNotaCreditoElectronica(True) = True Then
    '        ExportarAPdf()
    '    End If
    'End Sub

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub

#End Region

#Region "Eventos de objetos"

    Private Sub Frm_CXP_Descuentos_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If Me.Estado = enumEstados.NUEVO Then
            Me.TxtFolio.Focus()
        End If
    End Sub

    Private Sub Frm_CXP_Descuentos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
                    Me.TxtCodigoProveedor.Focus()
                Else
                    Me.GeneraFolio()
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
    '            Me.TxtCodigoProveedor.Focus()
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

            If Empresa_Sistema.TIPO_CAMBIO_POR_DIA = True Then
                ObtenerTipoCambioDia()
            End If
        Else
            Me.txtTipoCambio.Enabled = False : Me.txtTipoCambio.Text = ""
            'Me.txtTotalDolares.Enabled = False
            Me.lblTipoCambio.Enabled = False
            Me.lblTotalDolares.Enabled = False : Me.txtImporteDolares.Text = ""
        End If
    End Sub

    Private Sub dtFecha_ValueChanged(sender As Object, e As EventArgs) Handles dtFecha.ValueChanged
        If Empresa_Sistema.TIPO_CAMBIO_POR_DIA = True Then
            ObtenerTipoCambioDia()
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

    Private Sub LblPoliza_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LblPoliza.LinkClicked
        Dim Child As New Frm_Contabilidad_Captura_Polizas()
        Child.FolioPolizaConsultaExterior = Me.LblPoliza.Text
        Child.ShowDialog()
        Child.Dispose()
    End Sub

    'Private Sub Grid1_CellChanging(ByVal Sender As Object, ByVal e As FlexCell.Grid.CellChangingEventArgs) Handles Grid.CellChanging
    '    Try
    '        Dim Columna As Integer = e.Col, Renglon As Integer = e.Row
    '        'Dim dPago As Double
    '        'If e.Col = Me.iGyIVALocal And e.Row > 0 Then
    '        '    If Me.Grid.Cell(Renglon, Me.iGyIVALocal).Text = "1" And Me.ClickSinEjecutar = False Then
    '        '        dPago = valorNumerico(Me.Grid.Cell(Renglon, Me.iGySaldo).Text)
    '        '        If dPago > 0 Then
    '        '            Me.ClickSinEjecutar = True
    '        '            Me.Grid.Cell(Renglon, Me.iGyDescuento).Text = dPago.ToString
    '        '            Me.ClickSinEjecutar = False
    '        '        End If
    '        '    Else
    '        '        Me.Grid.Cell(Renglon, Me.iGyDescuento).Text = "0"
    '        '    End If
    '        'End If




    '    Catch ex As Exception
    '        HandleError(Me.Name, "Grid1_CellChanging", ex)
    '    End Try
    'End Sub

    Private Sub Grid_KeyDown(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Grid.KeyDown
        Try
            Dim Columna As Integer = Me.Grid.Selection.FirstCol, Renglon As Integer = Me.Grid.Selection.FirstRow
            Dim StrCod As String = Me.Grid.Cell(Renglon, Columna).Text

            'Dim dPago As Double, dPagoDocumento As Double
            'Dim sFolio As String

            'If Columna = iGySubtotalDescuento Or Columna = iGyIVADescuento Then
            '    Me.Totales()
            'End If

            If Me.Grid.Locked = True Then
                Exit Sub
            End If

            If Columna = iGyIVADescuento Then
                If valorNumerico(Me.Grid.Cell(Renglon, Me.iGyTieneIva).Text) < 0 Then
                    If e.KeyCode <> Keys.Enter Then
                        Me.Grid.Cell(Renglon, Me.iGyIVADescuento).Text = "0"
                        e.SuppressKeyPress = True
                        Exit Sub
                    End If
                End If
            End If

            Select Case e.KeyCode
                Case Keys.Enter
                    Select Case Columna
                        Case Me.iGyIVADescuento
                            Me.Totales()

                        Case Me.iGySubtotalDescuento
                            Me.Totales()
                            'If Columna = iGySubtotalDescuento Or Columna = iGyIVADescuento Then
                            'Me.Totales()
                            'End If
                            'sFolio = Me.Grid.Cell(Renglon, Me.iGyFolio).Text
                            'If txtLEN(sFolio) = True Then
                            '    Dim oVenta As New Class_Ventas_Global()
                            '    oVenta = New Class_Ventas_Global(sFolio)
                            '    If oVenta.Existe = True Then
                            '        Me.CargaCompra(sFolio)
                            '    Else
                            '        'Agregar al grid folios de ventas, que no hayan sido agregados, y en caso de que ya , en msg mostrarlo.
                            '        'sFolio = oBancosCXP.BusquedaVisual_FacturasClienteSaldo(Me.TxtCodigoProveedor.Text)
                            '        Me.Grid.Cell(Renglon, Me.iGyFolio).Text = sFolio
                            '        Me.CargaCompra(sFolio)
                            '    End If
                            'End If

                            'Case Me.iGyFolio
                            '    sFolio = Me.Grid.Cell(Renglon, Me.iGyFolio).Text
                            '    If txtLEN(sFolio) = True Then
                            '        Dim oVenta As New Class_Ventas_Global()
                            '        oVenta = New Class_Ventas_Global(sFolio)
                            '        If oVenta.Existe = True Then
                            '            Me.CargaCompra(sFolio)
                            '        Else
                            '            'Agregar al grid folios de ventas, que no hayan sido agregados, y en caso de que ya , en msg mostrarlo.
                            '            'sFolio = oBancosCXP.BusquedaVisual_FacturasClienteSaldo(Me.TxtCodigoProveedor.Text)
                            '            Me.Grid.Cell(Renglon, Me.iGyFolio).Text = sFolio
                            '            Me.CargaCompra(sFolio)
                            '        End If
                            '    End If

                            '    Case Me.iGyDescuento
                            '        Dim i As Integer
                            '        sFolio = Me.Grid.Cell(Renglon, Me.iGyFolio).Text
                            '        For i = 1 To Me.Grid.Rows - 1
                            '            If sFolio = Me.Grid.Cell(i, Me.iGyFolio).Text Then
                            '                dPagoDocumento += valorNumerico(Me.Grid.Cell(i, Me.iGyDescuento).Text)
                            '            End If
                            '        Next

                            '        dPago = valorNumerico(Me.Grid.Cell(Renglon, Me.iGyDescuento).Text)
                            '        If dPago > 0 And txtLEN(Me.Grid.Cell(Renglon, Me.iGyFolio).Text) = True Then
                            '            Dim oVenta As New Class_Ventas_Global()
                            '            oVenta = New Class_Ventas_Global(sFolio)

                            '            If dPagoDocumento > oVenta.SALDO Then 'valorNumerico(Me.Grid.Cell(Renglon, Me.iGySaldo).Text) Then
                            '                MsgBox("El descuento total del documento: " & sFolio & " es mayor al saldo del documento, favor de revisar.", MsgBoxStyle.Exclamation, "Validación de Importes de CXP")
                            '                Me.Grid.Cell(Renglon, Me.iGyDescuento).Text = "" ' 0.ToString
                            '                Me.Grid.Cell(Renglon, Me.iGyDescuento).SetFocus()
                            '                e.SuppressKeyPress = True
                            '                Exit Sub
                            '            End If

                            '            If dPago > valorNumerico(Me.Grid.Cell(Renglon, Me.iGyImporte).Text) And Me.Grid.Locked = False Then 'valorNumerico(Me.Grid.Cell(Renglon, Me.iGyImporte).Text) 
                            '                MsgBox("El descuento en el renglón: " & Renglon & " es mayor al importe del cultivo del documento, favor de revisar.", MsgBoxStyle.Exclamation, "Validación de Importes de CXP")
                            '                Me.Grid.Cell(Renglon, Me.iGyDescuento).Text = "" '0.ToString
                            '                Me.Grid.Cell(Renglon, Me.iGyDescuento).SetFocus()
                            '                e.SuppressKeyPress = True
                            '                Exit Sub
                            '            End If

                            '            If Me.Grid.Rows - 1 = Renglon Then
                            '                Me.Grid.Cell(Renglon, Me.iGyDescuento).SetFocus()
                            '                e.SuppressKeyPress = True
                            '            ElseIf Me.Grid.Rows - 2 >= Renglon And txtLEN(Me.Grid.Cell(Renglon + 1, Me.iGyFolio).Text) = True Then
                            '                Me.Grid.Cell(Renglon + 1, Me.iGyDescuento).SetFocus()
                            '                e.SuppressKeyPress = True
                            '            Else
                            '                Me.Grid.Cell(Renglon + 1, Me.iGyFolio).SetFocus()
                            '                e.SuppressKeyPress = True
                            '            End If
                            '        Else
                            '            If Me.Grid.Rows - 1 = Renglon Then
                            '                Me.Grid.Cell(Renglon, Me.iGyFolio).SetFocus()
                            '                e.SuppressKeyPress = True
                            '            ElseIf Me.Grid.Rows - 2 >= Renglon And txtLEN(Me.Grid.Cell(Renglon + 1, Me.iGyFolio).Text) = True Then
                            '                Me.Grid.Cell(Renglon + 1, Me.iGyDescuento).SetFocus()
                            '                e.SuppressKeyPress = True
                            '            Else
                            '                Me.Grid.Cell(Renglon + 1, Me.iGyFolio).SetFocus()
                            '                e.SuppressKeyPress = True
                            '            End If
                            '        End If
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
    Private Sub btnDocumentoAnterior_Click(sender As Object, e As EventArgs) Handles btnDocumentoAnterior.Click
        Navegador("Anterior")
    End Sub

    Private Sub btnDocumentoSiguiente_Click(sender As Object, e As EventArgs) Handles btnDocumentoSiguiente.Click
        Navegador("Siguiente")
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
    dtFecha.KeyPress, TxtConcepto.KeyPress, TxtConcepto2.KeyPress, TxtCodigoProveedor.KeyPress, ckbDolares.KeyPress
        txtNoBeep(e)
    End Sub
#End Region

#End Region

#Region "Métodos y procedimientos"
    Private Sub Inicializa()

        Me.TxtFolio.Text = ""
        Me.dtFecha.Value = Date.Now
        Me.TxtConcepto.Text = ""
        Me.TxtConcepto2.Text = ""
        Me.LblPoliza.Text = ""
        Me.LblStatus.Text = "NUEVO"
        Me.TxtCodigoProveedor.Text = ""
        Me.LblProveedor.Text = ""
        Me.ckbDolares.Checked = False
        Me.txtTipoCambio.Text = ""
        Me.txtImporteDolares.Text = ""

        Me.TxtSubTotal.Text = ""
        Me.TxtImpuesto.Text = ""
        Me.TxtTotal.Text = ""

        Me.GeneraFolio()
        Me.InicializaGrid()

    End Sub

    Private Sub InicializaGrid()
        Me.Grid.DataSource = Nothing
        FG_Grid_Limpiar(Grid)

        'Creamos el Grid
        Me.Grid.Rows = 2
        Me.Grid.Cols = 9
        Me.Grid.DisplayRowNumber = True

        Me.FormateaGrid()
    End Sub

    Private Sub FormateaGrid()

        Me.Grid.Column(Me.iGyFolio).Width = 95
        Me.Grid.Column(Me.iGyFecha).Width = 90
        Me.Grid.Column(Me.iGySaldo).Width = 120
        Me.Grid.Column(Me.iGyImporte).Width = 120
        Me.Grid.Column(Me.iGyDescuento).Width = 120
        Me.Grid.Column(Me.iGyIVADescuento).Width = 120
        Me.Grid.Column(Me.iGySubtotalDescuento).Width = 120
        Me.Grid.Column(Me.iGyTieneIva).Width = 0

        Me.Grid.Cell(0, Me.iGyFolio).Text = "FOLIO"
        Me.Grid.Cell(0, Me.iGyFecha).Text = "FECHA"

        Me.Grid.Cell(0, Me.iGySaldo).Text = "SALDO"
        Me.Grid.Cell(0, Me.iGyImporte).Text = "IMPORTE"
        Me.Grid.Cell(0, Me.iGyDescuento).Text = "DESCUENTO"

        'Me.Grid.Cell(0, Me.iGyIVALocal).Text = "IVA LOCAL"
        Me.Grid.Cell(0, Me.iGySubtotalDescuento).Text = "SUBTOTAL"
        Me.Grid.Cell(0, Me.iGyIVADescuento).Text = "IVA"
        Me.Grid.Cell(0, Me.iGyTieneIva).Text = "TIENE_IVA"

        Me.Grid.Column(Me.iGyFecha).CellType = FlexCell.CellTypeEnum.DateTime
        Me.Grid.Column(Me.iGyFecha).FormatString = "dd-MMM-yy"

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

        Me.Grid.Column(Me.iGySubtotalDescuento).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
        Me.Grid.Column(Me.iGySubtotalDescuento).Mask = FlexCell.MaskEnum.Numeric
        Me.Grid.Column(Me.iGySubtotalDescuento).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
        Me.Grid.Column(Me.iGySubtotalDescuento).Alignment = FlexCell.AlignmentEnum.RightCenter

        Me.Grid.Column(Me.iGyIVADescuento).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
        Me.Grid.Column(Me.iGyIVADescuento).Mask = FlexCell.MaskEnum.Numeric
        Me.Grid.Column(Me.iGyIVADescuento).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
        Me.Grid.Column(Me.iGyIVADescuento).Alignment = FlexCell.AlignmentEnum.RightCenter

        'Me.Grid.Column(Me.iGyIVALocal).CellType = FlexCell.CellTypeEnum.CheckBox

        Me.Grid.Refresh()

        Me.Grid.Column(Me.iGyFolio).Locked = True
        Me.Grid.Column(Me.iGyFecha).Locked = True
        Me.Grid.Column(Me.iGySaldo).Locked = True
        Me.Grid.Column(Me.iGyImporte).Locked = True
        Me.Grid.Column(Me.iGyDescuento).Locked = True
        Me.Grid.Column(Me.iGySubtotalDescuento).Locked = False
        Me.Grid.Column(Me.iGyIVADescuento).Locked = False

        Me.FormateaColoresGrid()

    End Sub

    Private Sub FormateaColoresGrid()
        Dim i As Integer, j As Integer, k As Integer, sCodigoFactura As String = ""
        Dim bcColor1 As Color = Color.Beige

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
    End Sub

    Private Function CargaCompras(ByVal sCodigoProveedor As String) As Boolean
        Dim dTabla As DataTable
        Try
                dTabla = oBancosCXP.CargaComprasProveedorConSaldoParaDescuentos(sCodigoProveedor)

            If Me.Grid.Rows = 2 Then
                If txtLEN(Me.Grid.Cell(1, Me.iGyFolio).Text) = False And txtLEN(Me.Grid.Cell(1, Me.iGyDescuento).Text) = False Then
                    Me.Grid.Rows = 1
                End If
            Else
                Me.Grid.Rows = Me.Grid.Rows - 1
            End If

            'If Me.ValidarFactura(sFolioVenta) = False Then
            '    Me.Grid.Rows = Me.Grid.Rows + 1
            '    Me.Grid.Cell(Me.Grid.Rows - 1, Me.iGyFolio).SetFocus()
            '    Exit Function
            'End If

            For Each dRow As DataRow In dTabla.Rows
                Me.Grid.AddItem(dRow(2).ToString & Chr(9) & Format(CDate(dRow(1)), "dd-MMM-yyyy") & Chr(9) & dRow(4).ToString & Chr(9) & dRow(5).ToString & Chr(9) & "0" & Chr(9) & "0" & Chr(9) & "0" & Chr(9) & dRow(9).ToString & Chr(9))
            Next

            Me.Grid.Rows = Me.Grid.Rows + 1
            'No es posible hace un datasource y luego intentar cambiar datos de celdas con codigo, no marca error pero no hace el cambio
            'Me.Grid1.DataSource = Me.oBancosCXC.CargaFacturasClienteConsSaldo(Me.TxtCodigoProveedor.Text)
            'Me.Grid.Rows += 1  

            If dTabla.Rows.Count = 0 Then
                MsgBox("El proveedor no tiene compras con saldo.", MsgBoxStyle.Information, Me.Text)
            End If

            CargaCompras = True
            Me.FormateaGrid()
            'Me.Grid.Cell(Me.Grid.Rows - 1, Me.iGyDescuento).SetFocus()

        Catch ex As Exception
            HandleError(Me.Name, "CargaCompras", ex)
        End Try
    End Function

    Private Sub Totales()
        Dim i As Integer, dDescuento As Double, dSubtotal As Double, dIVA As Double
        Me.dtTotal = 0 : Me.dtSubtotal = 0 : Me.dtIVA = 0
        Try

            For i = 1 To Me.Grid.Rows - 1
                dSubtotal = valorNumerico(Me.Grid.Cell(i, Me.iGySubtotalDescuento).Text)
                dIVA = valorNumerico(Me.Grid.Cell(i, Me.iGyIVADescuento).Text)
                dDescuento = dSubtotal + dIVA
                If dDescuento > 0 Then
                    Me.dtSubtotal = dtSubtotal + dSubtotal
                    Me.dtIVA = dtIVA + dIVA
                    Me.dtTotal = Me.dtTotal + dDescuento

                    Me.Grid.Cell(i, Me.iGyDescuento).Text = dDescuento.ToString
                End If
            Next

            FormatNumber(dtSubtotal, Empresa_Sistema.DECIMALES_CONTABILIDAD)
            FormatNumber(dtIVA, Empresa_Sistema.DECIMALES_CONTABILIDAD)
            FormatNumber(dtTotal, Empresa_Sistema.DECIMALES_CONTABILIDAD)

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
                'dIva = valorNumerico(Me.Grid.Cell(IndexRow, Me.iGyIVALocal).Text)
                If dImporte > 0 And dIva > 0 Then
                    DetectaModoIVA = True
                    Exit Function
                End If
            Next
            Exit Function

        Catch ex As Exception
            HandleError(Me.Name, "DetectaModoIVA", ex)
        End Try
    End Function

    Private Function GestionaModoIVA() As Boolean
        Try

            'Dim IndexRow As Integer, sFolio As String, dIva As Double, dTotal As Double, bTieneIVA As Boolean
            'Dim sql As Class_find

            'If DetectaModoIVA() = False Then
            '    For IndexRow = 1 To Me.Grid.Rows - 1
            '        Me.Grid.Cell(IndexRow, Me.iGySubtotalNuevo).Text = Format(0, "###,###,##0." & Empresa_Sistema.DECIMALES_CONTABILIDAD)
            '        Me.Grid.Cell(IndexRow, Me.iGyIVANuevo).Text = Format(0, "###,###,##0." & Empresa_Sistema.DECIMALES_CONTABILIDAD)
            '    Next

            '    Exit Function
            'End If

            'For IndexRow = 1 To Me.Grid.Rows - 1
            '    dTotal = valorNumerico(Me.Grid.Cell(IndexRow, iGyDescuento).Text)
            '    'dIva = valorNumerico(Me.Grid.Cell(IndexRow, iGyIVALocal).Text)
            '    If dIva = 0 Then
            '        Me.Grid.Cell(IndexRow, iGySubtotalNuevo).Text = Format(dTotal, "###,###,##0." & Empresa_Sistema.DECIMALES_CONTABILIDAD)
            '        Me.Grid.Cell(IndexRow, iGyIVANuevo).Text = Format(0, "###,###,##0." & Empresa_Sistema.DECIMALES_CONTABILIDAD)
            '    End If
            'Next

            'IndexRow = Me.Grid.Rows
            'sFolio = Me.Grid.Cell(IndexRow, iGyFolio).Text
            'dTotal = valorNumerico(Me.Grid.Cell(IndexRow, iGyDescuento).Text)
            ''bTieneIVA = CBool(IIf(valorNumerico(Me.Grid.Cell(IndexRow, iGyIVALocal).Text) > 0, True, False))

            'If dTotal > 0 Then
            '    If bTieneIVA = True Then
            '        'sql = New Class_find("SELECT SUBTOTAL,IVA,TOTAL FROM DBO.FN_CXC_OBTIENE_DESGLOSE_DESCUENTO_VENTA_CON_IVA('" & sFolio & "','" & Usuario.Codigo_Plaza & "'," & dTotal & ")")

            '        'If dTotal <> valorNumerico(sql.Result3) Then
            '        '    MsgBox("*Nota, esta venta tiene IVA y el sistema para poder calcularlo correctamente, cambió el importe capturado de " & Format(dTotal, "$###,###,##0." & Empresa_Sistema.DECIMALES_CONTABILIDAD) & " por " & Format(valorNumerico(sql.Result3), "$###,###,##0." & Empresa_Sistema.DECIMALES_CONTABILIDAD) & vbCrLf & _
            '        '    "Si tiene dudas avíse al depto. de sistemas.", vbInformation, Me.Name)
            '        'End If

            '        Me.Grid.Cell(IndexRow, Me.iGyDescuento).Text = Format(sql.Result3, "###,###,##0." & Empresa_Sistema.DECIMALES_CONTABILIDAD)
            '        Me.Grid.Cell(IndexRow, Me.iGySubtotalNuevo).Text = Format(sql.Result1, "###,###,##0." & Empresa_Sistema.DECIMALES_CONTABILIDAD)
            '        Me.Grid.Cell(IndexRow, Me.iGyIVANuevo).Text = Format(sql.Result2, "###,###,##0." & Empresa_Sistema.DECIMALES_CONTABILIDAD)
            '    End If
            'End If

            GestionaModoIVA = True

            Exit Function
        Catch ex As Exception
            HandleError(Me.Name, "GestionaModoIVA", ex)
        End Try
    End Function

    Private Sub CalculaImporteDolares()
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

    End Sub

    Private Function GestionaGrabar() As Boolean
        Me.oPolizaGlobal = New Class_Contabilidad_Poliza_Global(Me.TxtFolio.Text)
        Try

            If Usuario.ValidaPermisoUsuarioDocumentoSinAfectacionInventarios("NCG_CXP" & Usuario.Codigo_Plaza) = False Then
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
                    If Me.oDescuentosCXP.ActualizaFolioPoliza() = True Then
                        'If Empresa_Sistema.FELECTRONICA_ACTIVA = True Then
                        '    'If GeneraNotaCreditoElectronica(False) = True Then
                        '    '    ExportarAPdf()
                        '    'End If
                        'End If
                        MsgBox("Movimiento grabado satisfactoriamente.", MsgBoxStyle.Information, Me.Text)
                    Else
                        MsgBox("Movimiento grabado sin relacionar el folio de la póliza.", MsgBoxStyle.Information, Me.Text)
                    End If
                    GestionaGrabar = True
                Else
                    MsgBox("Movimiento grabado sin relacionar el folio de la póliza.", MsgBoxStyle.Information, Me.Text)
                End If
            End If
        Catch ex As Exception
            HandleError(Me.Name, "GestionaGrabar", ex)
        End Try

    End Function

    Private Function Grabar() As Boolean
        Dim i As Integer, bDescuento As Boolean 'dPago As Double

        Try
            Me.GeneraFolio()

            'Me.oBancosCXC = New Class_Bancos_CXC
            Me.oDescuentosCXP = New Class_CXP_Descuento
            'If Me.oBancosCXC.Existe = True Then
            '    Exit Function
            'End If

            oDescuentosCXP.FOLIO_DESCUENTO = Me.TxtFolio.Text
            oDescuentosCXP.CODIGO_PLAZA = Usuario.Codigo_Plaza
            oDescuentosCXP.CODIGO_CLIENTE = Me.TxtCodigoProveedor.Text
            oDescuentosCXP.SUBTOTAL = valorNumerico(Me.TxtSubTotal.Text)
            oDescuentosCXP.IVA = valorNumerico(Me.TxtImpuesto.Text)
            oDescuentosCXP.TOTAL = valorNumerico(Me.TxtTotal.Text)
            oDescuentosCXP.FECHA = Me.dtFecha.Value
            oDescuentosCXP.CONCEPTO1 = Me.TxtConcepto.Text.ToUpper
            oDescuentosCXP.CONCEPTO2 = Me.TxtConcepto2.Text.ToUpper
            oDescuentosCXP.CODIGO_USUARIO_GRABO = Usuario.Codigo_Usuario
            oDescuentosCXP.TIPO_DE_CAMBIO = valorNumerico(Me.txtTipoCambio.Text)
            oDescuentosCXP.ES_POR_DEVOLUCION = "0"
            If Empresa_Sistema.FELECTRONICA_ACTIVA = True Then
                oDescuentosCXP.ES_COMPROBANTE_ELECTRONICO = "1"
            Else
                oDescuentosCXP.ES_COMPROBANTE_ELECTRONICO = "0"
            End If
            oDescuentosCXP.ES_VENTA_PUBLICO_GENERAL = "0"

            If oDescuentosCXP.InsertarDescuentos() = False Then
                Exit Function
            End If

            Me.TxtFolio.Text = oDescuentosCXP.FOLIO_DESCUENTO

            Me.oCxpAfectaDocumentos = New Class_CXP_Afecta_Documentos

            Dim dt As New DataTable
            Dim sCodigoCompra As String, j As Integer ', k As Integer,dr As DataRow

            'dt.Columns.Add(New DataColumn("FOLIO_VENTA", GetType(String)))
            'dt.Columns.Add(New DataColumn("SALDO", GetType(String)))
            'dt.Columns.Add(New DataColumn("DESCUENTO", GetType(Decimal)))

            'For iRow = 1 To Me.Grid.Rows - 1
            '    dr = dt.NewRow()
            '    dr("FOLIO_VENTA") = Me.Grid.Cell(iRow, Me.iGyFolio).Text
            '    dr("SALDO") = Me.Grid.Cell(iRow, Me.iGySaldo).Text
            '    dr("DESCUENTO") = valorNumerico(Me.Grid.Cell(iRow, Me.iGyDescuento).Text)
            '    dt.Rows.Add(dr)
            'Next

            For i = 1 To Me.Grid.Rows - 1
                sCodigoCompra = Me.Grid.Cell(i, Me.iGyFolio).Text
                j = i + 1
                If valorNumerico(Me.Grid.Cell(i, Me.iGyDescuento).Text) > 0 Or bDescuento = True Then
                    If sCodigoCompra <> IIf(j > Me.Grid.Rows - 1, "", Me.Grid.Cell(j, Me.iGyFolio).Text).ToString And Me.Grid.Rows > 2 Then
                        oCxpAfectaDocumentos.FOLIO_CXP = "" 'Me.TxtFolio.Text
                        oCxpAfectaDocumentos.CODIGO_PROVEEDOR = Me.TxtCodigoProveedor.Text
                        oCxpAfectaDocumentos.FECHA = Me.dtFecha.Value
                        'oCxpAfectaDocumentos.CODIGO_DOCUEMTO=""
                        oCxpAfectaDocumentos.CODIGO_PLAZA = Usuario.Codigo_Plaza
                        oCxpAfectaDocumentos.FOLIO_REFERENCIA = Me.Grid.Cell(i, Me.iGyFolio).Text 'folio de la compra
                        oCxpAfectaDocumentos.FOLIO_REFERENCIA_USUARIO = "" 'Folio factura Cliente de la venta, no tenemos
                        'oCxpAfectaDocumentos.ID_MEDIO_PAGO = 0
                        'oCxpAfectaDocumentos.CODIGO_BANCO = "NA"
                        oCxpAfectaDocumentos.CONCEPTO1 = Me.TxtConcepto.Text
                        oCxpAfectaDocumentos.CONCEPTO2 = ""
                        oCxpAfectaDocumentos.SUBTOTAL = valorNumerico(Me.Grid.Cell(i, Me.iGySubtotalDescuento).Text)
                        oCxpAfectaDocumentos.IMPUESTO = valorNumerico(Me.Grid.Cell(i, Me.iGyIVADescuento).Text)
                        oCxpAfectaDocumentos.TOTAL = valorNumerico(Me.Grid.Cell(i, Me.iGyDescuento).Text)
                        oCxpAfectaDocumentos.TIPO_DE_CAMBIO = valorNumerico(Me.txtTipoCambio.Text)
                        oCxpAfectaDocumentos.CODIGO_USUARIO_GRABO = Usuario.Codigo_Usuario
                        'oCxpAfectaDocumentos.CODIGO_MODULO = "CXP"
                        Grabar = oCxpAfectaDocumentos.AfectaDocumentos()

                        oDescuentosCXP.InsertaDescuentoDetalle(oCxpAfectaDocumentos.FOLIO_CXP.ToString)
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
            Me.oCxpAfectaDocumentos = Nothing
        End Try

    End Function

    Private Sub ExportarAPdf()
        Dim Rpt As ReportDocument
        Rpt = New ReportDocument
        Dim oReporte As Class_Reporte
        Try

            oReporte = New Class_Reporte("RPT_FORMATO_CXP_NOTA_DESCUENTO_LAND", Rpt, False)

            If Not oReporte.RptCargado Then
                Exit Sub
            End If

            oDescuentosCXP = New Class_CXP_Descuento(Me.TxtFolio.Text)
            If oDescuentosCXP.Existe = False Then
                MsgBox("NO FOLIO DE VENTA NO EXISTE", MsgBoxStyle.Information, Me.Text)
                Exit Sub
            End If

            Rpt.SetParameterValue("@FOLIO_DESCUENTO", Me.TxtFolio.Text)

            Rpt.ExportToDisk(ExportFormatType.PortableDocFormat, sFelectronicaCarpetaXMLPDF & "\" & Me.oDescuentosCXP.FOLIO_DESCUENTO.ToString & ".PDF")
        Catch ex As Exception
            HandleError(Me.Name, "ExportarAPdf", ex)
        Finally
            oReporte = Nothing
        End Try
    End Sub

    'Private Function GeneraNotaCreditoElectronica(ByVal bMensaje As Boolean) As Boolean
    '    Dim sRutaXML As String
    '    Try
    '        sRutaXML = sFelectronicaCarpetaXMLPDF & "\" & Me.TxtFolio.Text & ".xml"
    '        If GeneraNotaCreditoCXCElectronica(Me.TxtFolio.Text, bMensaje, sRutaXML) = False Then
    '            MsgBox("Los datos digitales de la nota electrónica no fueron generados correctamente. Avíse al depto. de sistemas.", vbExclamation, Me.Text)
    '        Else
    '            GeneraNotaCreditoElectronica = True
    '            'ExportaFormatoVentaPDF(Me.txtFolio.Text, "F")GeneraNotaCreditoCXCElectronica
    '        End If
    '        Exit Function
    '    Catch ex As Exception
    '        HandleError(Me.Name, "GeneraNotaCreditoElectronica", ex)
    '    End Try
    'End Function

    Private Function Validar() As Boolean
        Dim oProveedor As New Class_CatProveedores()
        Dim i As Integer

        'Dim dDescuentoFactura As Double 'dt As DataTable = DirectCast(Me.Grid.DataSource, DataTable),
        Dim dt As New DataTable
        Dim dr As DataRow

        dt.Columns.Add(New DataColumn("FOLIO_COMPRA", GetType(String)))
        dt.Columns.Add(New DataColumn("SALDO", GetType(String)))
        dt.Columns.Add(New DataColumn("DESCUENTO", GetType(Decimal)))

        For iRow = 1 To Me.Grid.Rows - 1
            dr = dt.NewRow()
            dr("FOLIO_COMPRA") = Me.Grid.Cell(iRow, Me.iGyFolio).Text
            dr("SALDO") = Me.Grid.Cell(iRow, Me.iGySaldo).Text
            dr("DESCUENTO") = valorNumerico(Me.Grid.Cell(iRow, Me.iGyDescuento).Text)
            dt.Rows.Add(dr)
        Next

        Try
            If Plaza.ValidarPeriodoTrabajo(Me.dtFecha.Value) = False Then
                Exit Function
            End If

            oProveedor = New Class_CatProveedores(Me.TxtCodigoProveedor.Text)

            If oProveedor.Existe = False Or oProveedor.Estatus = "B" Then
                MsgBox("El código de PROVEEDOR que intenta introducir no existe o esta dado de baja, favor de intentar con otro código.", MsgBoxStyle.Exclamation, "Validación de PROVEEDORES")
                Me.LblProveedor.Text = ""
                Me.TxtCodigoProveedor.Focus()
                Exit Function
            Else
                Me.LblProveedor.Text = oProveedor.Nombre_Proveedor.ToString
            End If

            If Me.ValidarDatosProveedor() = False Then
                Exit Function
            End If

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
                    Dim sql As New Class_find("SELECT SALDO FROM COMPRA_GLOBAL WHERE FOLIO_COMPRA='" & Me.Grid.Cell(i, Me.iGyFolio).Text & "'")
                    Me.Grid.Cell(i, Me.iGySaldo).Text = sql.Result1
                    If valorNumerico(Me.Grid.Cell(i, Me.iGyDescuento).Text) > valorNumerico(Me.Grid.Cell(i, Me.iGySaldo).Text) Then
                        MsgBox("El pago en el renglón: " & i & " es mayor al saldo del documento favor de revisar.", MsgBoxStyle.Exclamation, "Validación de descuentos de CXP")
                        Me.Grid.Cell(i, Me.iGyDescuento).Text = "" '0.ToString
                        Me.Grid.Cell(i, Me.iGyDescuento).SetFocus()
                        Exit Function
                    ElseIf valorNumerico(Me.Grid.Cell(i, Me.iGyDescuento).Text) > valorNumerico(Me.Grid.Cell(i, Me.iGyImporte).Text) Then
                        MsgBox("El pago en el renglón: " & i & " es mayor al importe del documento favor de revisar.", MsgBoxStyle.Exclamation, "Validación de descuentos de CXP")
                        Me.Grid.Cell(i, Me.iGyDescuento).Text = "" '0.ToString
                        Me.Grid.Cell(i, Me.iGyDescuento).SetFocus()
                        Exit Function
                        'ElseIf Me.ckbDolares.Checked = True And sql.Result2 = "0002" Then 'MERCADO NACIONAL
                        '    MsgBox("Los descuentos en dolares deben de ser a ventas de exportacion. Favor de revisar.", MsgBoxStyle.Exclamation, "Validación de descuentos de CXP")
                        '    Exit Function
                        'ElseIf Me.ckbDolares.Checked = False And sql.Result2 = "0001" Then 'MERCADO exportacion
                        '    MsgBox("Los descuentos nacionales deben de ser a ventas de nacional. Favor de revisar.", MsgBoxStyle.Exclamation, "Validación de descuentos de CXP")
                        '    Exit Function
                    End If
                End If
            Next i

            If Me.ckbDolares.Checked = True Then
                If valorNumerico(Me.txtTipoCambio.Text) = 0 Then
                    MsgBox("El tipo de cambio debe ser mayor a 0. Favor de revisar.", MsgBoxStyle.Exclamation, "Validación de descuentos de CXP")
                    Exit Function
                End If
            End If

            For i = 1 To Me.Grid.Rows - 1
                'If Len(Me.Grid.Cell(i, Me.iGyFolio).Text) > 0 Then
                '    If txtLEN(Me.Grid.Cell(i, Me.iGyCodigoCultivo).Text) = True Then
                '        dDescuentoFactura = valorNumerico(dt.Compute("sum(DESCUENTO)", "FOLIO_VENTA='" & Me.Grid.Cell(i, Me.iGyFolio).Text & "'").ToString)
                '        Dim oVenta As New Class_Ventas_Global()
                '        oVenta = New Class_Ventas_Global(Me.Grid.Cell(i, Me.iGyFolio).Text)

                '        If valorNumerico(dDescuentoFactura.ToString) > oVenta.SALDO Then
                '            MsgBox("El saldo de la factura " & Me.Grid.Cell(i, Me.iGyFolio).Text & " es menor al descuento.", MsgBoxStyle.Exclamation, "Validación de descuentos de CXP")
                '            Exit Function
                '        End If
                '    ElseIf valorNumerico(Me.Grid.Cell(i, Me.iGyDescuento).Text) > 0 Then
                '        MsgBox("La factura que desea aplicar un descuento no tiene codigo de cultivo " & Me.Grid.Cell(i, Me.iGyFolio).Text & ".", MsgBoxStyle.Exclamation, "Validación de descuentos de CXP")
                '        Me.Grid.Cell(i, Me.iGyDescuento).Text = ""
                '        Exit Function
                '    End If
                'End If
            Next i

            Validar = True

        Catch ex As Exception
            HandleError(Me.Name, "Validar", ex)
        End Try
    End Function

    Private Function ValidarDatosProveedor() As Boolean

        If txtLEN(Me.TxtCodigoProveedor.Text) = False Then
            MsgBox("Asigne un proveedor.", MsgBoxStyle.Exclamation, "ValidarDatosProveedor")
            Me.TxtCodigoProveedor.Focus()
            Exit Function
        End If

        Me.oProveedores = New Class_CatProveedores(Me.TxtCodigoProveedor.Text)
        If Me.oProveedores.Existe = False Then
            MsgBox("Asigne un proveedor válido.", MsgBoxStyle.Exclamation, "ValidarDatosProveedor")
            Me.TxtCodigoProveedor.Focus()
            Exit Function
        End If

        If txtLEN(Me.oProveedores.CUENTA_CONTABLE) = False Then
            MsgBox("El proveedor no tiene una cuenta contable en pesos asignada.", MsgBoxStyle.Exclamation, "ValidarDatosProveedor")
            Me.TxtCodigoProveedor.Focus()
            Exit Function
        End If

        If Mid(Me.oProveedores.CUENTA_CONTABLE, 1, 1) <> "2" Then
            'or Me.oProveedores.NOMBRE_TIPO_PROVEEDOR
            MsgBox("La cuenta contable del proveedor debe empesar con '2'.", MsgBoxStyle.Information, Me.Text)
            Me.LblProveedor.Text = ""
            Me.TxtCodigoProveedor.Focus()
            Exit Function
        End If

        ValidarDatosProveedor = True
    End Function

    Private Sub Imprimir()
        Dim StrFiltros As String = ""
        Dim FormatoDeReporte As String
        Dim Rpt As ReportDocument
        Rpt = New ReportDocument
        Dim oReporte As Class_Reporte
        Try
            FormatoDeReporte = "RPT_FORMATO_CXP_NOTA_DESCUENTO"
            oReporte = New Class_Reporte(FormatoDeReporte, Rpt, False)
            If Not oReporte.RptCargado Then
                Exit Sub
            End If
            Rpt.SetParameterValue("@FOLIO_DESCUENTO", Me.TxtFolio.Text)
            Dim frm As New Reporte(Rpt)
            frm.CRViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            frm.Show()
        Catch ex As Exception
            HandleError(Me.Name, "Impresión de Descuentos", ex)
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

    Private Function ValidaPrePoliza() As Boolean
        Dim oProveedor As Class_CatProveedores
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

            oProveedor = New Class_CatProveedores(Me.TxtCodigoProveedor.Text)
            oCuenta = New Class_CatCuentas(oProveedor.CUENTA_CONTABLE)

            Me.oFormaPoliza.Grid1.Cell(1, 1).Text = oProveedor.CUENTA_CONTABLE.ToString
            Me.oFormaPoliza.Grid1.Cell(1, 2).Text = oProveedor.Nombre_Proveedor
            Me.oFormaPoliza.Grid1.Cell(1, 3).Text = Me.TxtConcepto.Text.ToUpper
            Me.oFormaPoliza.Grid1.Cell(1, 4).Text = oCuenta.NATURALEZA_CONTABLE
            Me.oFormaPoliza.Grid1.Cell(1, 5).Text = Me.TxtTotal.Text
            Me.oFormaPoliza.Grid1.Cell(1, 6).Text = "0"

            'Me.oFormaPoliza.Grid1.Rows = Me.oFormaPoliza.Grid1.Rows + 3
            ''Pone los renglones segun el codigo de descuentos del cultivo 
            For i = 1 To Me.Grid.Rows - 1
                If Me.Grid.Cell(i, Me.iGyFolio).Text <> "" And valorNumerico(Me.Grid.Cell(i, Me.iGyDescuento).Text) > 0 Then
                    'For Each dRow As DataRow In dTable.Rows
                    'sCultivo = "0000" + Me.Grid.Cell(i, Me.iGyCodigoCultivo).Text
                    'oCuenta = New Class_CatCuentas("5200")
                    oCuenta = New Class_CatCuentas(Plaza.CUENTA_DESCUENTOS_REBAJAS_NACIONALES)

                    Me.oFormaPoliza.Grid1.Rows = Me.oFormaPoliza.Grid1.Rows + 1

                    Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 1).Text = oCuenta.CUENTA_CONTABLE
                    Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 2).Text = oCuenta.NOMBRE_CUENTA

                    Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 3).Text = Me.TxtConcepto.Text.ToUpper
                    Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 4).Text = oCuenta.NATURALEZA_CONTABLE
                    Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 5).Text = "0"
                    Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 6).Text = Me.Grid.Cell(i, Me.iGySubtotalDescuento).Text

                    If valorNumerico(Me.Grid.Cell(i, Me.iGyTieneIva).Text) > 0 Then
                        If valorNumerico(Me.Grid.Cell(i, Me.iGyTieneIva).Text) = 16 Then
                            oCuenta = New Class_CatCuentas("10600001")
                        Else
                            oCuenta = New Class_CatCuentas("10600002")
                        End If

                        Me.oFormaPoliza.Grid1.Rows = Me.oFormaPoliza.Grid1.Rows + 1

                        Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 1).Text = oCuenta.CUENTA_CONTABLE
                        Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 2).Text = oCuenta.NOMBRE_CUENTA

                        Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 3).Text = Me.TxtConcepto.Text.ToUpper
                        Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 4).Text = oCuenta.NATURALEZA_CONTABLE
                        Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 5).Text = "0"
                        Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 6).Text = Me.Grid.Cell(i, Me.iGyIVADescuento).Text
                    End If
                    
                End If
            Next i

            'poner el nombre del cliente al cual se le hiso el descuento
            'Me.AgregaPrepolizaIVAAcreditable()
            If Me.ckbDolares.Checked = True Then
                If txtLEN(oProveedor.CUENTA_CONTABLE_DOLARES) = False Then
                    Me.CalculaImporteDolares()
                    MsgBox("El proveedor no tiene cuenta contable en dolares. Favor de revisar.", MsgBoxStyle.Exclamation, "Validación de descuentos de CXP")
                    Exit Function
                End If
                oCuenta = New Class_CatCuentas(oProveedor.CUENTA_CONTABLE)

                Me.oFormaPoliza.Grid1.Rows = Me.oFormaPoliza.Grid1.Rows + 1
                Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 1).Text = oProveedor.CUENTA_CONTABLE_DOLARES
                Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 2).Text = oProveedor.Nombre_Proveedor
                Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 3).Text = Me.oFormaPoliza.TxtConcepto1.Text.ToUpper
                Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 4).Text = oCuenta.NATURALEZA_CONTABLE
                Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 5).Text = Me.txtImporteDolares.Text
                Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 6).Text = "0"

                oCuenta = New Class_CatCuentas(Empresa_Sistema.CUENTA_CONTABLE_CLIENTES_CONTRA_CUENTA_DOLARES)
                Me.oFormaPoliza.Grid1.Rows = Me.oFormaPoliza.Grid1.Rows + 1
                Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 1).Text = oCuenta.CUENTA_CONTABLE
                Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 2).Text = oCuenta.NOMBRE_CUENTA
                Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 3).Text = Me.oFormaPoliza.TxtConcepto1.Text.ToUpper
                Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 4).Text = oCuenta.NATURALEZA_CONTABLE
                Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 5).Text = "0"
                Me.oFormaPoliza.Grid1.Cell(Me.oFormaPoliza.Grid1.Rows - 1, 6).Text = Me.txtImporteDolares.Text
            End If

            Me.oFormaPoliza.lblEstatus.Text = "N"

            Me.oFormaPoliza.ShowDialog()

            ValidaPrePoliza = Me.oFormaPoliza.FormaValidaParaGrabarLlamadoExterior

        Catch ex As Exception
            HandleError(Me.Text, "ValidaPrePoliza", ex)
        Finally
            oCuenta = Nothing
            oProveedor = Nothing
        End Try

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
        Dim sFolio As String = Me.TxtFolio.Text

        Try
            Me.Inicializa()
            'Me.oBancosCXC = New Class_Bancos_CXC(sFolio)
            Me.oDescuentosCXP = New Class_CXP_Descuento(sFolio)
            Me.oPolizaGlobal = New Class_Contabilidad_Poliza_Global(sFolio)

            If Me.oDescuentosCXP.Existe = False Then
                Me.GeneraFolio()
                Me.Cambia_Estado(enumEstados.NUEVO)
                Me.TxtFolio.Enabled = False
                Exit Function
            Else
                Me.TxtFolio.Text = Me.oDescuentosCXP.FOLIO_DESCUENTO
                Me.TxtFolio.Enabled = False

                Me.dtFecha.Value = oDescuentosCXP.FECHA

                Select Case oDescuentosCXP.ESTATUS_DESCUENTO
                    Case "A"
                        Me.LblStatus.Text = "APLICADO"
                    Case "C"
                        Me.LblStatus.Text = "CANCELADO"
                End Select
                'Me.LblPoliza.Text = oDescuentosCXP.FOLIO_POLIZA
                Me.TxtConcepto.Text = oDescuentosCXP.CONCEPTO1
                Me.TxtConcepto2.Text = oDescuentosCXP.CONCEPTO2
                Me.TxtCodigoProveedor.Text = oDescuentosCXP.CODIGO_CLIENTE
                Me.LblProveedor.Text = oDescuentosCXP.NOMBRE_CLIENTE
                Me.LblPoliza.Text = oDescuentosCXP.FOLIO_POLIZA.ToString
                If oDescuentosCXP.TIPO_DE_CAMBIO > 0 Then
                    Me.ckbDolares.Checked = True
                    Me.txtTipoCambio.Text = oDescuentosCXP.TIPO_DE_CAMBIO.ToString
                    Me.CalculaImporteDolares()
                End If
                Me.TxtSubTotal.Text = FormatImporteContable(oDescuentosCXP.SUBTOTAL)
                Me.TxtImpuesto.Text = FormatImporteContable(oDescuentosCXP.IVA)
                'Me.TxtTotal.Text = oDescuentosCXP.TOTAL.ToString
                Me.TxtTotal.Text = FormatImporteContable(oDescuentosCXP.TOTAL)

                Me.tssElaboro.Text = "Elaboró : " & Me.oDescuentosCXP.NOMBRE_USUARIO_GRABO & " el " & Format(Me.oDescuentosCXP.FECHA_SERVIDOR, "dd-MMM-yyyy hh:mm tt")
                If Me.oDescuentosCXP.ESTATUS_DESCUENTO = "C" Then
                    Me.tssCancelo.Text = "Canceló : " & Me.oDescuentosCXP.NOMBRE_USUARIO_CANCELO & " el : " & Format(Me.oDescuentosCXP.FECHA_CANCELACION, "dd-MMM-yyyy hh:mm tt")
                End If

                Me.Grid.DataSource = Me.oDescuentosCXP.ObtenerDetalle
                Me.FormateaGrid()

                Consultar = True

                Me.GestionaCambioEstado()
            End If
        Catch ex As Exception
            HandleError(Me.Name, "Consultar", ex)
        End Try

    End Function

    'Private Function CargaVentasConSaldo() As Boolean
    '    Dim dTabla As DataTable
    '    Try
    '        dTabla = oBancosCXC.CargaVentasClienteConSaldo(Me.TxtCodigoProveedor.Text)
    '        Me.Grid.Rows = 1
    '        For Each dRow As DataRow In dTabla.Rows
    '            Me.Grid.AddItem(dRow(0).ToString & Chr(9) & Format(CDate(dRow(1)), "dd-MMM-yyyy") & Chr(9) & dRow(2).ToString & Chr(9) & dRow(3).ToString & Chr(9) & dRow(4).ToString & Chr(9) & _
    '                            dRow(5).ToString & Chr(9) & dRow(6).ToString & Chr(9) & dRow(7).ToString & Chr(9) & dRow(8).ToString)
    '        Next

    '        'No es posible hace un datasource y luego intentar cambiar datos de celdas con codigo, no marca error pero no hace el cambio
    '        'Me.Grid1.DataSource = Me.oBancosCXC.CargaComprasClienteConSaldo(Me.TxtCodigoProveedor.Text)
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
                ExisteDocumento = True
            End If
        Catch ex As Exception
            HandleError(Me.Name, "ExisteDocumento", ex)
        End Try
    End Function

    Private Function CancelaDescuentosCXP() As Boolean
        'Dim oFirmaElectronica = New UtileriasFirmaElectronicaCancelacionMovimientosFueraPeriodo
        'Dim oUtileriasCancela As New Class_UtileriasFirmaElectronicaCancelacion
        Dim oPoliza As New Class_Contabilidad_Poliza_Global
        'Dim sFolio As String = Me.TxtFolio.Text

        'Me.oBancosCXC = New Class_Bancos_CXC(sFolio)

        If MsgBox("Deseas cancelar el movimiento " & Me.TxtFolio.Text & " ?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "CancelaDescuentosCXP") = MsgBoxResult.No Then
            Exit Function
        End If

        If Usuario.ValidaPermisoUsuarioDocumentoSinAfectacionInventarios("NCG_CXP" & Usuario.Codigo_Plaza) = False Then
            MsgBox("El usuario " & Usuario.Nombre_Usuario & " no tiene permiso para realizar el movimiento.", MsgBoxStyle.Exclamation, Me.Text)
            Exit Function
        End If

        'no se ocupa por que para eso esta la interfaz
        'If PLAZA.ValidarPeriodoTrabajo(Date.Now) = False Then 'Para cancelar se valida con la fecha de la maquina
        '    Exit Function
        'End If

        Select Case Me.LblStatus.Text
            Case "NUEVO"
                MsgBox("El documento no se ha grabado.", MsgBoxStyle.Exclamation, Me.Text)
                Exit Function
            Case "APLICADO"
                'No hay restricciones
            Case "CANCELADO"
                MsgBox("Los documentos cancelados no se pueden volver a cancelar.", MsgBoxStyle.Exclamation, Me.Text)
                Exit Function
        End Select

        Try
            'oUtileriasCancela.FOLIO_DOCUMENTO = Me.TxtFolio.Text.ToUpper
            'oUtileriasCancela.MODULO = Me.oBancosCXC.CODIGO_MODULO
            'oUtileriasCancela.CODIGO_PLAZA = Usuario.Codigo_Plaza

            'If oUtileriasCancela.GestionaCancelacion() = False Then
            '    Exit Function
            'End If

            'If oUtileriasCancela.CANCELA_DIRECTO = True Then
            '    Me.oBancosCXC.FECHA_DE_CANCELACION = Date.Now
            '    If Me.oBancosCXC.CancelaBancosCXC() = False Then
            '        Exit Function
            '    End If
            'Else
            '    oUtileriasCancela = New Class_UtileriasFirmaElectronicaCancelacion
            '    oUtileriasCancela.FOLIO_DOCUMENTO = Me.TxtFolio.Text
            '    oUtileriasCancela.FOLIO_POLIZA = Me.oBancosCXC.FOLIO_POLIZA
            '    oUtileriasCancela.CODIGO_DOCUMENTO = "DESC" ''Me.CmbDocumento.SelectedValue.ToString
            '    oUtileriasCancela.CODIGO_PLAZA = Usuario.Codigo_Plaza
            '    oUtileriasCancela.MODULO = Me.oBancosCXC.CODIGO_MODULO

            '    If oUtileriasCancela.AutorizaCancelacionMovimientosFueraPeriodo() = False Then
            '        MsgBox("Error al tratar de autorizar la cancelación fuera del periodo.", MsgBoxStyle.Exclamation, Me.Text)
            '        Exit Function
            '    End If

            '    'si no se autorizo
            '    If oUtileriasCancela.CANCELACION_AUTORIZO = False Then
            '        MsgBox("No se autorizó la cancelación de movimiento.", MsgBoxStyle.Exclamation, Me.Text)
            '        Exit Function
            '    End If

            '    If oUtileriasCancela.GestionaCancelacionConInterfaz() = False Then
            '        MsgBox("Error al gestionar la cancelacion con interfaz", MsgBoxStyle.Information, Me.Text)
            '        Exit Function
            '    Else
            '        If oUtileriasCancela.ES_FECHA_CANCELACION_VALIDA = "0" Then
            '            MsgBox("La fecha de cancelación debe de ser mayor o igual a la fecha del documento y debe estar en el mismo ejercicio.", vbExclamation, Me.Text)
            '            Exit Function
            '        End If

            Me.oDescuentosCXP.FECHA_CANCELACION = Now '(Now, "yyyy-dd-MM") 'oUtileriasCancela.FECHA_CANCELACION

            If Me.oDescuentosCXP.CancelaDescuentoCXP() = False Then
                MsgBox("Error al intentar cancelar el movimiento de documento de descuento.", MsgBoxStyle.Exclamation, Me.Text)
                Exit Function
            End If
            '    End If
            'End If

            MsgBox("Movimiento de descuento cancelado satisfactoriamente.", MsgBoxStyle.Information, Me.Text)
            CancelaDescuentosCXP = True
        Catch ex As Exception
            HandleError(Me.Name, "CancelaDescuentosCXP", ex)
        End Try
    End Function

    Private Function BusquedaVisual_PorDescripcion() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de descuentos en CXP."
        f.sCampo = "FOLIO_DESCUENTO"
        f.sOrder = "FOLIO_DESCUENTO"
        f.sTable = "CXP_DESCUENTOS_GLOBAL"
        f.sQl = "SELECT FOLIO_DESCUENTO,TOTAL,FECHA FROM CXP_DESCUENTOS_GLOBAL WHERE CODIGO_PLAZA='" & Usuario.Codigo_Plaza & "' AND "
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
        Me.oBancosCXP.CODIGO_DOCUMENTO = "NCG_CXP" & Usuario.Codigo_Plaza.ToString
        Me.TxtFolio.Text = Me.oBancosCXP.GeneraFolio
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
                    Me.TxtCodigoProveedor.Enabled = True
                    Me.TxtConcepto.Enabled = True
                    Me.TxtConcepto2.Enabled = True
                    Me.ckbDolares.Enabled = True
                    'Me.ckbVentaPublicoGeneral.Enabled = True
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

                Case enumEstados.APLICADO
                    Me.tsbGrabar.Enabled = False
                    Me.tsbCancelar.Enabled = True
                    Me.tsbImprimir.Enabled = True
                    Me.dtFecha.Enabled = False
                    Me.TxtCodigoProveedor.Enabled = False
                    Me.TxtConcepto.Enabled = False
                    Me.TxtConcepto2.Enabled = False
                    Me.ckbDolares.Enabled = False
                    'Me.ckbVentaPublicoGeneral.Enabled = False
                    Me.txtTipoCambio.Enabled = False
                    Me.txtImporteDolares.Enabled = False
                    Me.tssEstado.Text = "Estado: Consulta de " & Me.Nombre_Modulo
                    Me.tssElaboro.Visible = True
                    Me.tssCancelo.Visible = False
                    Me.Grid.Locked = True
                    Me.Grid.Cell(0, Me.iGyDescuento).Text = "DESCUENTO"
                    'Me.Grid.Column(Me.iGyIVALocal).Visible = False

                    Me.tsbImprimir.Select()

                Case enumEstados.CANCELADO
                    Me.tsbGrabar.Enabled = False
                    Me.tsbCancelar.Enabled = False
                    Me.tsbImprimir.Enabled = True
                    Me.dtFecha.Enabled = False
                    Me.TxtCodigoProveedor.Enabled = False
                    Me.TxtConcepto.Enabled = False
                    Me.TxtConcepto2.Enabled = False
                    Me.ckbDolares.Enabled = False
                    'Me.ckbVentaPublicoGeneral.Enabled = False
                    Me.txtTipoCambio.Enabled = False
                    Me.txtImporteDolares.Enabled = False
                    Me.tssEstado.Text = "Estado: Consulta de " & Me.Nombre_Modulo
                    Me.tssElaboro.Visible = True
                    Me.tssCancelo.Visible = True
                    Me.Grid.Locked = True
                    Me.Grid.Cell(0, Me.iGyDescuento).Text = "DESCUENTO"
                    'Me.Grid.Column(Me.iGyIVALocal).Visible = False

                    Me.tsbImprimir.Select()

            End Select
        Catch ex As Exception
            HandleError(Me.Name, "Cambia_Estado", ex)
        End Try
    End Sub

    Private Function ValidarFactura(Optional ByVal Codigo As String = "") As Boolean
        Dim i As Integer, j As Integer
        Dim sCodigoFactura As String = "", sCodigoCultivo As String = ""

        If txtLEN(Codigo) = False Then
            For i = 1 To Me.Grid.Rows - 1
                sCodigoFactura = Me.Grid.Cell(i, Me.iGyFolio).Text
                'sCodigoCultivo = Me.Grid.Cell(i, Me.iGyCodigoCultivo).Text
                For j = i + 1 To Me.Grid.Rows - 1
                    If txtLEN(Me.Grid.Cell(j, Me.iGyFolio).Text) = True Then
                        'If sCodigoFactura = Me.Grid.Cell(j, Me.iGyFolio).Text And sCodigoCultivo = Me.Grid.Cell(j, Me.iGyCodigoCultivo).Text And Me.Grid.Rows > 2 Then
                        '    MsgBox("La factura que intenta introducir ya existe, favor de intentar con otro código.", MsgBoxStyle.Exclamation, "Validación de descuentos de CXP")
                        '    Me.Grid.Cell(i, Me.iGyFolio).SetFocus()
                        '    Exit Function
                        'End If
                    End If
                Next j
            Next i
        Else
            sCodigoFactura = Codigo

            For j = 1 To Me.Grid.Rows - 1
                If txtLEN(Me.Grid.Cell(j, Me.iGyFolio).Text) = True Then
                    If sCodigoFactura = Me.Grid.Cell(j, Me.iGyFolio).Text And Me.Grid.Rows > 2 Then
                        MsgBox("La factura que intenta introducir ya existe, favor de intentar con otro código.", MsgBoxStyle.Exclamation, "Validación de descuentos de CXP")
                        Exit Function
                    End If
                End If
            Next j
        End If

        ValidarFactura = True
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
        '    dTabla = oDescuentosCXP.DistribucionDescuentos(sFolio, CDbl(Dato))
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

#End Region

    Private Sub TxtCodigoProveedor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodigoProveedor.KeyDown
        Dim sText As String
        Select Case e.KeyCode
            Case Keys.F6
Buscar:
                sText = Me.oProveedores.BusquedaVisual_PorDescripcion
                If txtLEN(sText) = True Then Me.TxtCodigoProveedor.Text = sText
            Case Keys.Enter
                If txtLEN(Me.TxtCodigoProveedor.Text) = False Then
                    Me.LblProveedor.Text = "" : GoTo Buscar : Exit Sub
                End If

                Me.oProveedores = New Class_CatProveedores(Me.TxtCodigoProveedor.Text)
                If Me.oProveedores.Existe = False Then
                    Me.LblProveedor.Text = "" : GoTo Buscar : Exit Sub
                End If

                If Mid(Me.oProveedores.CUENTA_CONTABLE, 1, 1) <> "2" Then
                    'or Me.oProveedores.NOMBRE_TIPO_PROVEEDOR
                    MsgBox("La cuenta contable del proveedor debe empesar con '2'.", MsgBoxStyle.Information, Me.Text)
                    Me.LblProveedor.Text = ""
                    Me.TxtCodigoProveedor.Focus()
                    Exit Sub
                End If
                Me.LblProveedor.Text = Me.oProveedores.Nombre_Proveedor

                If CargaCompras(Me.TxtCodigoProveedor.Text) = True Then
                    txtTAB(e)
                    Me.TxtCodigoProveedor.Enabled = False
                End If

        End Select
    End Sub
    Private Function Navegador(ByVal sTipoDeBusqueda As String) As Boolean
        Dim bResultado As Boolean = False
        Try
            Dim iFolio As Integer, sFolio As String, iPosicion As Integer, sFolioParte2 As String
            'If txtLEN(Me.TxtFolio.Text) = False Then
            '    If GeneraFolio() = False OrElse txtLEN(Me.TxtFolio.Text) = False Then
            '        Exit Function
            '    End If
            'End If

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

            bResultado = True
        Catch ex As Exception
            HandleError(Me.Name, "Navegador", ex)
        End Try

        Return bResultado
    End Function

    Private Sub ObtenerTipoCambioDia()
        Dim oTipoCambio As New Class_CatTiposCambio(Me.dtFecha.Value)
        Me.txtTipoCambio.Enabled = False
        Me.txtTipoCambio.Text = "0"

        If oTipoCambio.Existe AndAlso oTipoCambio.TIPO_DE_CAMBIO > 0 Then
            Me.txtTipoCambio.Text = oTipoCambio.TIPO_DE_CAMBIO.ToString
        Else
            If Me.ckbDolares.Checked = True Then
                MsgBox("No se ha capturado el tipo de cambio del día.", MsgBoxStyle.Exclamation, Me.Text)
            End If
        End If

    End Sub

End Class