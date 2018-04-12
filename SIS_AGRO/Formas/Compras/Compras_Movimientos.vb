Option Strict On

Imports System.IO

Public Class Compras_Movimientos

#Region "Campos privados"
    Private oCompras As New Class_Compras_Global
    Private oProveedores As New Class_CatProveedores
    Private oDocumento As New Class_CatDocumentos

    Private bDocumentosCargados As Boolean
    Private bEsReferencia As Boolean
    Private bIVAModificado As Boolean
    Private Estado As enumEstados

    Private _ConsultaExterior As Boolean

    Private dPorcentajeIVAGlobal As Double = 0

    Private Enum enumEstados
        NUEVO
        GRABADO
        PARCIALMENTE_RECEPCIONADO
        APLICADO
        CANCELADO
    End Enum

    Private oFormaDetalleCuentas As InventariosDetalleCuentasContables

    Private dtSeries As DataTable
#End Region

#Region "Columnas grid compras"
    Private igyCodigo As Short = 1
    Private igyDescripcion As Short = 2
    Private igyCantidad As Short = 3
    Private igyPrecio As Short = 4
    Private igyUnidad As Short = 5
    Private igyImpuestoPorcentaje As Short = 6
    Private igyImporte As Short = 7
    Private igyCuentaContable As Short = 8
    Private igyImpuestoImporte As Short = 9
    Private igyIdArticulo As Short = 10
    Private iGyNombreCuentaContable As Integer = 11
    Private iGyBoton As Integer = 12
    Private iGyIDAdicional As Integer = 13

    Private igyIEPS_PORCENTAJE As Short = 14
    Private igyIEPS_UNITARIO As Short = 15
    Private igyIEPS_IMPORTE As Short = 16
    Private igyBASE_IEPS As Short = 17
    Private igyBASE_IVA As Short = 18
#End Region

#Region "Columnas grid series"
    Private igySeriePosicion As Short = 1
    Private igySerieCodigo As Short = 2
    Private igySerieDescripcion As Short = 3
    Private igySerieNumeroSerie As Short = 4
#End Region

#Region "Propiedades"
    Public WriteOnly Property ConsultaExterior() As Boolean
        Set(ByVal value As Boolean)
            Me._ConsultaExterior = value
        End Set
    End Property
#End Region

#Region "Opciones"
    Private Sub tsbNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbNuevo.Click
        Me.Inicializa()
        Me.Cambia_Estado(enumEstados.NUEVO)
    End Sub

    Private Sub tsbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGrabar.Click
        If Me.Grabar() = True Then
            Me.Consultar()
        End If
    End Sub

    Private Sub tsbAplicar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbAplicar.Click
        If Me.ValidarOrdenCompra() = True Then
            If Me.Aplicar() = True Then
                Me.Consultar()
            End If
        End If
    End Sub

    Private Sub tsbCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCancelar.Click
        If Me.oDocumento.AFECTA_CXP = True Then
            If Me.CancelarCompra = True Then
                Me.Consultar()
            End If
        Else
            If Me.CancelaOrdenCompra() = True Then
                Me.Consultar()
            End If
        End If
    End Sub

    Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click
        Me.oCompras.Imprimir()
    End Sub

    Private Sub tsbPasarOrdenACompra_Click(sender As Object, e As EventArgs) Handles tsbPasarOrdenACompra.Click
        Me.PasarOrdenACompra()
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
            Dim oCostos As New FrmCostosEdicion(Me.txtFolioCompra.Text, Me.CboDocumento.SelectedValue.ToString)
            If oCostos.bMovimientoEncontrado = True Then
                oCostos.ShowDialog()
                oCostos.Dispose()
                Me.Consultar()
            End If
        Catch ex As Exception
            HandleError(Me.Name, "tsbEditarCostos_Click", ex)
        End Try
    End Sub

    Private Sub BtnActualizaFolioProv_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnActualizaFolioProv.Click
        If Me.ActualizaFolioProveedor() = True Then
            Me.Consultar()
        End If
    End Sub

    Private Sub btnActualizaConcepto_Click(sender As Object, e As EventArgs) Handles btnActualizaConcepto.Click
        If Me.ActualizaConcepto() = True Then
            Me.Consultar()
        End If
    End Sub

    Private Sub btnSeries_Click(sender As Object, e As EventArgs) Handles btnSeries.Click
        Me.PrepararSeries()
    End Sub

    Private Sub btnSeleccionarArchivoSeries_Click(sender As Object, e As EventArgs) Handles btnSeleccionarArchivoSeries.Click
        Me.GestionaArchivoSeries()
    End Sub

    Private Sub btnCopiarLote_Click(sender As Object, e As EventArgs) Handles btnCopiarLote.Click
        Me.CopiarLote
    End Sub
#End Region

#Region "Eventos de objetos"
#Region "Eventos"
    Private Sub Compras_Movimientos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Me._ConsultaExterior = True Then
            Dim sfolio As String = Me.txtFolioCompra.Text
            Me.DesplegarDocumentos(False)
            Me.DesplegarAlmacenes()
            Me.DesplegarMonedas()
            Me.Consultar()
            Me.GestionaCambioEstado()
            Me.txtFolioCompra.Enabled = False
            Me.InicializaExterno()
        Else
            Me.DesplegarDocumentos()
            Me.DesplegarAlmacenes()
            Me.DesplegarMonedas()
            Me.Inicializa()
            Me.Cambia_Estado(enumEstados.NUEVO)
        End If

        If Empresa_Sistema.VALIDA_SERIES_REPETIDAS_EN_ENTRADAS = True Then
            Me.txtLote.Visible = False : Me.btnCopiarLote.Visible = False : Me.lblDisplayLote.Visible = False
        Else
            Me.txtLote.Visible = True : Me.btnCopiarLote.Visible = True : Me.lblDisplayLote.Visible = True
        End If
    End Sub

    Private Sub CboDocumento_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CboDocumento.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.Send("{TAB}")
            Case Keys.Escape
                CboDocumento.Focus()
        End Select
    End Sub

    Private Sub CmbDocumento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboDocumento.SelectedIndexChanged
        Me.oDocumento = New Class_CatDocumentos(Me.CboDocumento.SelectedValue.ToString)
        Me.OcultarControles()

        Me.oCompras = New Class_Compras_Global(Me.CboDocumento.SelectedValue.ToString)
        If _ConsultaExterior = False Then
            Me.Inicializa()
            Me.Cambia_Estado(enumEstados.NUEVO)
            'Me.txtFolioCompra.Focus()
        End If
    End Sub

    Private Sub CboAlmacen_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CboAlmacen.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.Send("{TAB}")
        End Select
    End Sub

    Private Sub txtFolioCompra_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFolioCompra.KeyDown
        Select Case e.KeyCode
            Case Keys.F6
                If Me.oDocumento.AFECTA_CXP = True Then
                    Me.txtFolioCompra.Text = Me.oCompras.BusquedaVisual_Compras() 'Si es CO
                Else
                    Me.txtFolioCompra.Text = Me.oCompras.BusquedaVisual_OrdenesCompra() 'Si es OC
                End If
            Case Keys.F7
                If Me.oDocumento.AFECTA_CXP = True Then
                    Me.txtFolioCompra.Text = Me.oCompras.BusquedaVisual_ComprasPorFolioOC() 'Si es CO
                End If
            Case Keys.Enter
                Me.Consultar()
        End Select
    End Sub

    Private Sub TxtFolioOrdenCompra_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFolioOC.KeyDown
        Select Case e.KeyCode
            Case Keys.F6
Buscar:
                Me.txtFolioOC.Text = Me.oCompras.BusquedaVisual_OrdenesCompra("G")
            Case Keys.Enter
                If txtLEN(Me.txtFolioOC.Text) = False Then
                    GoTo Buscar : Exit Sub
                End If
                If Me.Consultar(True) = False Then
                    GoTo Buscar : Exit Sub
                End If
        End Select
    End Sub

    Private Sub txtFolioProveedor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFolioProveedor.KeyDown
        Select Case e.KeyCode
            Case Keys.F6
Buscar:
                Me.txtFolioCompra.Text = Me.oCompras.BusquedaVisual_FolioProveedor()
            Case Keys.Enter
                Me.txtFolioOC.Focus()
        End Select
    End Sub

    Private Sub TxtCodigoProveedor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProveedor.KeyDown
        Dim sText As String
        Select Case e.KeyCode
            Case Keys.F6
Buscar:
                sText = Me.oProveedores.BusquedaVisual_PorDescripcion
                If txtLEN(sText) = True Then Me.txtProveedor.Text = sText
            Case Keys.Enter
                If txtLEN(Me.txtProveedor.Text) = False Then
                    Me.lblProveedor.Text = "" : GoTo Buscar : Exit Sub
                End If

                Me.oProveedores = New Class_CatProveedores(Me.txtProveedor.Text)
                If Me.oProveedores.Existe = False Then
                    Me.lblProveedor.Text = "" : GoTo Buscar : Exit Sub
                End If

                If Mid(Me.oProveedores.CUENTA_CONTABLE, 1, 1) <> "2" Then
                    'or Me.oProveedores.NOMBRE_TIPO_PROVEEDOR
                    MsgBox("La cuenta contable del proveedor debe empezar con '2'.", MsgBoxStyle.Information, Me.Text)
                    Me.lblProveedor.Text = ""
                    Me.txtProveedor.Focus()
                    Exit Sub
                End If
                Me.lblProveedor.Text = Me.oProveedores.Nombre_Proveedor
                Me.txtPlazo.Text = Me.oProveedores.Plazo.ToString
                Me.dtpFechaVencimiento.Value = Me.DtpFecha.Value.AddDays(CDbl(Me.txtPlazo.Text))

                txtTAB(e)
        End Select
    End Sub
    Private Sub txtEntregarA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEntregarA.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.Send("{TAB}")
        End Select
    End Sub

    Private Sub txtSolicito_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSolicito.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.Send("{TAB}")
        End Select
    End Sub

    Private Sub txtConCargoA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtConCargoA.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.Send("{TAB}")
        End Select
    End Sub

    Private Sub txtPredio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPredio.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.Send("{TAB}")
        End Select
    End Sub

    Private Sub txtConfirmo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtConfirmo.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.Send("{TAB}")
        End Select
    End Sub

    Private Sub TxtConcepto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtConcepto.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                Me.Grid.Cell(1, 1).SetFocus()
            Case Keys.Escape
                Me.dtpFechaVencimiento.Focus()
        End Select
    End Sub

    Private Sub DtpFecha_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtpFecha.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.Send("{TAB}")
            Case Keys.Escape
                Me.CboAlmacen.Focus()
        End Select
    End Sub

    Private Sub DtpFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtpFecha.ValueChanged
        Me.dtpFechaVencimiento.Value = Me.DtpFecha.Value.AddDays(CDbl(Me.txtPlazo.Text))
    End Sub

    Private Sub txtPlazo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPlazo.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                Me.dtpFechaVencimiento.Value = Me.DtpFecha.Value.AddDays(CDbl(Me.txtPlazo.Text))
        End Select
    End Sub

    Private Sub DtpFechaVencimiento_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpFechaVencimiento.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.Send("{TAB}")
            Case Keys.Escape
                Me.txtPlazo.Focus()
        End Select
    End Sub

    Private Sub cboMoneda_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMoneda.SelectedIndexChanged
        If Me.cboMoneda.SelectedIndex = 1 Then
            Me.txtTipoCambio.Enabled = True
            Me.gbUSD.Visible = True
        Else
            Me.txtTipoCambio.Enabled = False
            Me.gbUSD.Visible = False
        End If
        Me.TotalesUSD()
    End Sub

    Private Sub txtTipoCambio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTipoCambio.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                Me.TotalesUSD()
                SendKeys.Send("{TAB}")
        End Select
    End Sub

    Private Sub Grid_CellChange(Sender As Object, e As FlexCell.Grid.CellChangeEventArgs) Handles Grid.CellChange
        If Me.Grid.ActiveCell.Col = Me.igyCantidad Or Me.Grid.ActiveCell.Col = Me.igyPrecio AndAlso Me.Estado = enumEstados.NUEVO Then
            Me.Totales()
        End If
    End Sub

    Private Sub Grid_KeyDown(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Grid.KeyDown
        Me.GestionaGrid(e)
    End Sub

    Private Sub Grid_ButtonClick(ByVal Sender As System.Object, ByVal e As FlexCell.Grid.ButtonClickEventArgs) Handles Grid.ButtonClick
        Me.GestionaDetalleCuentas()
    End Sub

    Private Sub TxtRetencion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtRetencion.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                Me.Totales()
            Case Keys.Escape
                txtTAB(e)
        End Select
    End Sub

    Private Sub txtIVA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtIVA.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                Me.txtTotal.Text = FormatImporteContable((valorNumerico(Me.TxtSubTotal.Text) + valorNumerico(Me.txtIVA.Text)) - valorNumerico(Me.TxtRetencion.Text))
                Me.bIVAModificado = True
        End Select
    End Sub

    Private Sub GridSeries_KeyDown(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridSeries.KeyDown
        Me.GestionaGridSeries(e)
    End Sub
#End Region

#Region "Eventos Genericos"
    Private Sub txtTextoKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFolioCompra.KeyPress, txtFolioOC.KeyPress, txtProveedor.KeyPress, txtFolioProveedor.KeyPress, _
    txtEntregarA.KeyPress, txtSolicito.KeyPress, TxtConcepto.KeyPress, txtConCargoA.KeyPress, txtPredio.KeyPress, txtConfirmo.KeyPress, _
    DtpFecha.KeyPress, dtpFechaVencimiento.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub txtNumerosEnterosKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPlazo.KeyPress
        txtSoloNumerosEnteros(e)
        txtNoBeep(e)
    End Sub

    Private Sub txtNumerosDecimalKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtRetencion.KeyPress, txtTipoCambio.KeyPress, txtIVA.KeyPress
        Dim txt As TextBox = CType(sender, TextBox)
        txtSoloNumerosDecimales(e, txt.Text)
        txtNoBeep(e)
    End Sub

    Private Sub LblPoliza_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LblPoliza.LinkClicked
        Dim Child As New Frm_Contabilidad_Captura_Polizas()
        Child.FolioPolizaConsultaExterior = Me.LblPoliza.Text
        Child.ShowDialog()
        Child.Dispose()
    End Sub

#End Region
#End Region

#Region "Métodos y procedimientos"
    Private Sub Inicializa()
        Try
            Me.txtFolioCompra.Text = ""
            Me.txtFolioOC.Text = ""
            Me.txtFolioProveedor.Text = ""
            Me.txtProveedor.Text = ""
            Me.lblProveedor.Text = ""

            'Me.chkImprimirDolares.Checked = False
            Me.txtTipoCambio.Text = "0"

            Me.txtEntregarA.Text = ""
            Me.txtSolicito.Text = ""
            Me.TxtConcepto.Text = ""
            Me.txtConCargoA.Text = ""
            Me.txtPredio.Text = ""
            Me.txtConfirmo.Text = ""

            Me.DtpFecha.Value = Date.Now
            Me.DtpFechaFacturaProveedor.Value = Date.Now
            Me.txtPlazo.Text = "30"
            Me.dtpFechaVencimiento.Value = Date.Now.AddDays(CDbl(Me.txtPlazo.Text))
            Me.LblEstatus.Text = "N"
            Me.LblPoliza.Text = ""

            Me.TxtSubTotal.Text = FormatImporteContable(0)
            Me.txtIEPS.Text = FormatImporteContable(0)
            Me.txtIVA.Text = FormatImporteContable(0)
            Me.TxtRetencion.Text = FormatImporteContable(0)
            Me.txtTotal.Text = FormatImporteContable(0)
            Me.txtSaldoMXP.Text = FormatImporteContable(0)
            Me.txtSaldoUSD.Text = FormatImporteContable(0)
            Me.dPorcentajeIVAGlobal = 0
            Me.lblIVAcalculado.Text = "0" : Me.lblIVAcalculado.Visible = True

            Me.TxtSubTotalUSD.Text = FormatImporteContable(0)
            Me.txtIVAUSD.Text = FormatImporteContable(0)
            Me.txtTotalUSD.Text = FormatImporteContable(0)

            Me.InicializaGrid()
            Me.InicializaGridSeries()

            Me.oCompras = New Class_Compras_Global(Me.CboDocumento.SelectedValue.ToString)
            Me.oProveedores = New Class_CatProveedores
            'Me.oDocumento = New Class_CatDocumentos(Me.CboDocumento.SelectedValue.ToString)

            Me.GeneraFolio()

            Me.bEsReferencia = False

            Me.oFormaDetalleCuentas = Nothing 'New InventariosDetalleCuentasContables

            Me.dtSeries = New DataTable("Series")

            Me.TabControl1.SelectedIndex = 0
        Catch ex As Exception
            HandleError(Me.Name, "Inicializa", ex)
        End Try
    End Sub

    Private Sub InicializaExterno()
        Try
            Me.tsbNuevo.Enabled = False
            Me.txtSolicito.Enabled = False
            'Me.TxtConcepto.Enabled = False
            Me.TxtConcepto.ReadOnly = True
            Me.txtConCargoA.Enabled = False
            Me.txtPredio.Enabled = False
            Me.txtConfirmo.Enabled = False

            Me.BtnActualizaFolioProv.Enabled = True
            Me.btnActualizaConcepto.Enabled = True
            'Me.DtpFecha.Value = Date.Now
            'Me.DtpFechaFacturaProveedor.Value = Date.Now
            'Me.txtPlazo.Text = "30"
            'Me.dtpFechaVencimiento.Value = Date.Now.AddDays(CDbl(Me.txtPlazo.Text))
            'Me.LblEstatus.Text = "N"
            'Me.LblPoliza.Text = ""

            'Me.TxtSubTotal.Text = FormatImporteContable(0)
            'Me.txtIVA.Text = FormatImporteContable(0)
            'Me.TxtRetencion.Text = FormatImporteContable(0)
            'Me.txtTotal.Text = FormatImporteContable(0)
            'Me.txtSaldo.Text = FormatImporteContable(0)
            'Me.dPorcentajeIVAGlobal = 0
            'Me.lblIVAcalculado.Text = "0" : Me.lblIVAcalculado.Visible = True

            'Me.InicializaGrid()

            'Me.oCompras = New Class_Compras_Global(Me.CboDocumento.SelectedValue.ToString)
            'Me.oProveedores = New Class_CatProveedores
            ''Me.oDocumento = New Class_CatDocumentos(Me.CboDocumento.SelectedValue.ToString)

            'Me.GeneraFolio()

            Me.bEsReferencia = False
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
            Me.Grid.Cell(1, Me.iGyIDAdicional).Text = "1"
        Catch ex As Exception
            HandleError(Me.Name, "InicializaGrid", ex)
        End Try
    End Sub

    Private Sub FormateaGrid()
        Try
            With Me.Grid
                .AutoRedraw = False

                '.DefaultFont = New Font("Tahoma", 8)
                .DisplayFocusRect = False
                '.DisplayDateTimeMask = True
                '.ExtendLastCol = True
                .DrawMode = FlexCell.DrawModeEnum.OwnerDraw
                .BorderStyle = FlexCell.BorderStyleEnum.FixedSingle
                .FixedRowColStyle = FlexCell.FixedRowColStyleEnum.Flat

                .Rows = 2
                .Cols = 19

                .Column(Me.igyCodigo).Width = 75
                .Column(Me.igyDescripcion).Width = 250
                .Column(Me.igyCantidad).Width = 90
                .Column(Me.igyPrecio).Width = 100
                .Column(Me.igyUnidad).Width = 75
                .Column(Me.igyImpuestoPorcentaje).Width = 70
                .Column(Me.igyImporte).Width = 100
                .Column(Me.igyCuentaContable).Width = 100
                .Column(Me.igyImpuestoImporte).Width = 100
                .Column(Me.igyIdArticulo).Width = 100

                If Me.oDocumento.AFECTA_CXP = True Then
                    .Column(Me.iGyBoton).Visible = True
                    .Column(Me.iGyNombreCuentaContable).Width = 70
                    .Column(Me.iGyBoton).Width = 70
                    .Column(Me.iGyIDAdicional).Visible = False '.Column(Me.iGyIDAdicional).Width = 70
                Else
                    .Column(Me.iGyBoton).Visible = False
                    .Column(Me.iGyNombreCuentaContable).Visible = False
                    .Column(Me.iGyBoton).Visible = False
                    .Column(Me.iGyIDAdicional).Visible = False
                End If

                .Cell(0, Me.igyCodigo).Text = "Código"
                .Cell(0, Me.igyDescripcion).Text = "Descripción"
                .Cell(0, Me.igyCantidad).Text = "Cantidad"
                .Cell(0, Me.igyPrecio).Text = "Precio"
                .Cell(0, Me.igyUnidad).Text = "Unidad"
                .Cell(0, Me.igyImpuestoPorcentaje).Text = "IVA %"
                .Cell(0, Me.igyImporte).Text = "Importe"
                .Cell(0, Me.igyCuentaContable).Text = "Cuenta Contable"
                .Cell(0, Me.igyImpuestoImporte).Text = "IVA"
                .Cell(0, Me.igyIdArticulo).Text = "Id Articulo"
                .Cell(0, Me.iGyNombreCuentaContable).Text = "Nombre cuenta"
                .Cell(0, Me.iGyBoton).Text = "Costos"
                .Cell(0, Me.iGyIDAdicional).Text = "IdAdicional"

                .Column(Me.igyCantidad).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.igyCantidad).DecimalLength = Empresa_Sistema.DECIMALES_CANTIDAD
                .Column(Me.igyCantidad).Alignment = FlexCell.AlignmentEnum.RightCenter

                '.Column(Me.igyPrecio).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_PRECIO)
                .Column(Me.igyPrecio).FormatString = "$ ###,###,##0." & StrDup(6, "0")
                .Column(Me.igyPrecio).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.igyPrecio).DecimalLength = 6 ' Empresa_Sistema.DECIMALES_PRECIO
                .Column(Me.igyPrecio).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.igyImpuestoPorcentaje).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.igyImpuestoPorcentaje).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
                .Column(Me.igyImpuestoPorcentaje).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.igyImporte).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
                .Column(Me.igyImporte).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.igyImporte).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
                .Column(Me.igyImporte).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.igyCuentaContable).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.igyImpuestoImporte).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.igyImpuestoImporte).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
                .Column(Me.igyImpuestoImporte).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.igyIdArticulo).Mask = FlexCell.MaskEnum.Numeric

                .Column(Me.igyImporte).Locked = True
                .Column(Me.igyImpuestoImporte).Visible = False
                .Column(Me.igyIdArticulo).Visible = False

                If bEsReferencia = True Then
                    .Column(Me.igyCodigo).Locked = True
                    .Column(Me.igyDescripcion).Locked = True
                    .Column(Me.igyCantidad).Locked = False
                    .Column(Me.igyPrecio).Locked = True
                    .Column(Me.igyUnidad).Locked = True
                    .Column(Me.igyImpuestoPorcentaje).Locked = True
                    .Column(Me.igyImporte).Locked = True
                    .Column(Me.igyCuentaContable).Locked = False
                    .Column(Me.igyImpuestoImporte).Locked = True
                Else
                    .Column(Me.igyCodigo).Locked = False
                    .Column(Me.igyPrecio).Locked = False
                    .Column(Me.igyUnidad).Locked = False
                    .Column(Me.igyImpuestoPorcentaje).Locked = False
                End If

                .Column(Me.iGyNombreCuentaContable).Locked = True
                .Column(Me.iGyIDAdicional).Locked = True

                .Column(Me.iGyBoton).CellType = FlexCell.CellTypeEnum.Button

                .Column(Me.igyIEPS_PORCENTAJE).Visible = False
                .Column(Me.igyIEPS_UNITARIO).Visible = False
                .Column(Me.igyIEPS_IMPORTE).Visible = False
                .Column(Me.igyBASE_IEPS).Visible = False
                .Column(Me.igyBASE_IVA).Visible = False

                .AutoRedraw = True
                .Refresh()
            End With
        Catch ex As Exception
            HandleError(Me.Name, "FormateaGrid", ex)
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
            Case "C"
                Me.Cambia_Estado(enumEstados.CANCELADO)
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
                    Me.tsbPasarOrdenACompra.Visible = False
                    Me.tsbEditarCostos.Visible = False

                    If Me.oDocumento.AFECTA_CXP = True Then
                        Me.tsbGrabar.Enabled = False
                        Me.tsbAplicar.Enabled = True
                        Me.DtpFecha.Enabled = True
                        Me.CboAlmacen.Enabled = False
                        Me.CboDocumento.Enabled = True
                        Me.txtFolioCompra.Enabled = True
                        Me.txtFolioOC.Enabled = True
                        Me.txtProveedor.Enabled = False
                        Me.txtFolioProveedor.Enabled = True
                        Me.txtEntregarA.Enabled = False
                        Me.txtSolicito.Enabled = False
                        Me.txtTipoCambio.Enabled = False
                        Me.txtPlazo.Enabled = True
                        'Me.TxtRetencion.Enabled = False
                        'Me.TxtConcepto.Enabled = False
                        Me.TxtConcepto.ReadOnly = True
                        Me.txtConCargoA.Enabled = False
                        Me.txtPredio.Enabled = False
                        Me.txtConfirmo.Enabled = False
                        Me.Grid.Locked = False
                        Me.GridSeries.Locked = False
                        Me.DtpFechaFacturaProveedor.Enabled = True
                        Me.cboMoneda.Enabled = False
                        Me.BtnActualizaFolioProv.Visible = False
                        Me.btnActualizaConcepto.Visible = False
                        Me.txtIVA.Enabled = True
                        Me.btnSeries.Enabled = True
                        Me.btnSeleccionarArchivoSeries.Enabled = True

                        Me.tsslEstado.Text = "Estado: Agregando nuevo movimiento"
                        Me.tsslElaboro.Visible = False : Me.tsslElaboro.Text = ""
                        Me.tsslCancelo.Visible = False : Me.tsslCancelo.Text = ""
                        Me.DtpFechaFacturaProveedor.Visible = True : Me.lblDisplayFechaFacturaProveedor.Visible = True

                        If Me.Visible = True Then
                            If Me.bEsReferencia = False Then
                                Me.txtFolioCompra.Focus()
                            Else
                                Me.txtFolioProveedor.Focus()
                            End If
                        End If
                    Else 'oc
                        Me.tsbGrabar.Enabled = True
                        Me.tsbAplicar.Enabled = False
                        Me.DtpFecha.Enabled = True
                        Me.CboAlmacen.Enabled = True
                        Me.CboDocumento.Enabled = True
                        Me.txtFolioCompra.Enabled = True
                        Me.txtFolioOC.Enabled = True
                        Me.txtProveedor.Enabled = True
                        Me.txtFolioProveedor.Enabled = True
                        Me.txtEntregarA.Enabled = True
                        Me.txtSolicito.Enabled = True
                        Me.txtTipoCambio.Enabled = False
                        Me.txtPlazo.Enabled = True
                        'Me.TxtRetencion.Enabled = True
                        'Me.TxtConcepto.Enabled = True
                        Me.TxtConcepto.ReadOnly = False
                        Me.txtConCargoA.Enabled = True
                        Me.txtPredio.Enabled = True
                        Me.txtConfirmo.Enabled = True
                        Me.Grid.Locked = False
                        Me.GridSeries.Locked = True
                        Me.DtpFechaFacturaProveedor.Enabled = False
                        Me.cboMoneda.Enabled = True
                        Me.BtnActualizaFolioProv.Visible = False
                        Me.btnActualizaConcepto.Visible = False
                        Me.txtIVA.Enabled = True
                        Me.btnSeries.Enabled = False
                        Me.btnSeleccionarArchivoSeries.Enabled = False

                        Me.tsslEstado.Text = "Estado: Agregando nuevo movimiento"
                        Me.tsslElaboro.Visible = False : Me.tsslElaboro.Text = ""
                        Me.tsslCancelo.Visible = False : Me.tsslCancelo.Text = ""
                        Me.DtpFechaFacturaProveedor.Visible = False : Me.lblDisplayFechaFacturaProveedor.Visible = False

                        If Me.Visible = True Then
                            Me.txtFolioCompra.Focus()
                        End If
                    End If

                    Me.LblConceptoCancelacion.Visible = False
                    Me.TxtConceptoCancelacion.Visible = False

                Case enumEstados.GRABADO
                    Me.tsbNuevo.Enabled = True
                    Me.tsbGrabar.Enabled = True
                    Me.tsbAplicar.Enabled = False
                    Me.tsbCancelar.Enabled = True
                    Me.tsbImprimir.Enabled = True
                    Me.tsbPasarOrdenACompra.Visible = False
                    Me.tsbEditarCostos.Visible = False

                    If Me.oDocumento.AFECTA_CXP = False Then 'Si no afecta, entonces es una oc y si se permite el botón.
                        Me.tsbPasarOrdenACompra.Visible = True
                    End If

                    Me.DtpFecha.Enabled = True
                    Me.CboAlmacen.Enabled = True
                    Me.CboDocumento.Enabled = False
                    Me.txtFolioCompra.Enabled = False
                    Me.txtFolioOC.Enabled = True
                    Me.txtProveedor.Enabled = True
                    Me.txtFolioProveedor.Enabled = True
                    Me.txtEntregarA.Enabled = True
                    Me.txtSolicito.Enabled = True
                    Me.txtTipoCambio.Enabled = False
                    Me.txtPlazo.Enabled = True
                    'Me.TxtRetencion.Enabled = True
                    'Me.TxtConcepto.Enabled = True
                    Me.TxtConcepto.ReadOnly = False
                    Me.Grid.Locked = False
                    Me.DtpFechaFacturaProveedor.Enabled = False
                    Me.BtnActualizaFolioProv.Visible = False
                    Me.btnActualizaConcepto.Visible = False
                    Me.txtIVA.Enabled = True
                    Me.btnSeries.Enabled = False
                    Me.btnSeleccionarArchivoSeries.Enabled = False

                    Me.tsslEstado.Text = "Estado: Consultando movimiento"
                    Me.tsslElaboro.Visible = True : Me.tsslElaboro.Text = "Elaboró: " + Me.oCompras.NOMBRE_USUARIO_GRABO.ToUpper + " el " + Format(Me.DtpFecha.Value, "dd/MMM/yy").ToUpper
                    Me.tsslCancelo.Visible = False : Me.tsslCancelo.Text = ""
                    Me.DtpFechaFacturaProveedor.Visible = False : Me.lblDisplayFechaFacturaProveedor.Visible = False

                    Me.LblConceptoCancelacion.Visible = False
                    Me.TxtConceptoCancelacion.Visible = False

                    Me.TxtConcepto.Focus()

                Case enumEstados.APLICADO, enumEstados.PARCIALMENTE_RECEPCIONADO
                    Me.tsbNuevo.Enabled = True
                    Me.tsbGrabar.Enabled = False
                    Me.tsbAplicar.Enabled = False
                    Me.tsbCancelar.Enabled = True
                    Me.tsbImprimir.Enabled = True
                    Me.tsbPasarOrdenACompra.Visible = False

                    If Me.Estado = enumEstados.APLICADO And Me.oDocumento.AFECTA_CXP = True Then
                        Me.tsbEditarCostos.Visible = True
                    End If

                    Me.DtpFecha.Enabled = False
                    Me.CboAlmacen.Enabled = False
                    Me.CboDocumento.Enabled = False
                    Me.txtFolioCompra.Enabled = False
                    Me.txtFolioOC.Enabled = False
                    Me.txtProveedor.Enabled = False
                    Me.txtEntregarA.Enabled = False
                    Me.txtSolicito.Enabled = False
                    Me.txtTipoCambio.Enabled = False
                    Me.txtPlazo.Enabled = False
                    'Me.TxtRetencion.Enabled = False
                    'Me.TxtConcepto.Enabled = False
                    Me.TxtConcepto.ReadOnly = True
                    Me.Grid.Locked = True
                    Me.GridSeries.Locked = True
                    If Me.oDocumento.AFECTA_CXP = True Then
                        Me.DtpFechaFacturaProveedor.Visible = True : Me.lblDisplayFechaFacturaProveedor.Visible = True
                    Else
                        Me.DtpFechaFacturaProveedor.Visible = False : Me.lblDisplayFechaFacturaProveedor.Visible = False
                    End If

                    Me.txtIVA.Enabled = False
                    Me.btnSeries.Enabled = False
                    Me.btnSeleccionarArchivoSeries.Enabled = False

                    Me.tsslEstado.Text = "Estado: Consultando movimiento"
                    Me.tsslElaboro.Visible = True : Me.tsslElaboro.Text = "Elaboró: " + Me.oCompras.NOMBRE_USUARIO_GRABO.ToUpper + " el " + Format(Me.DtpFecha.Value, "dd/MMM/yy").ToUpper
                    Me.tsslCancelo.Visible = False : Me.tsslCancelo.Text = ""
                    'Me.DtpFechaFacturaProveedor.Visible = True : Me.lblDisplayFechaFacturaProveedor.Visible = True
                    Me.DtpFechaFacturaProveedor.Enabled = False
                    Me.txtFolioProveedor.Enabled = False

                    Me.tsbImprimir.Select()

                    Me.LblConceptoCancelacion.Visible = False
                    Me.TxtConceptoCancelacion.Visible = False

                Case enumEstados.CANCELADO
                    Me.tsbNuevo.Enabled = True
                    Me.tsbGrabar.Enabled = False
                    Me.tsbAplicar.Enabled = False
                    Me.tsbCancelar.Enabled = False
                    Me.tsbImprimir.Enabled = True
                    Me.tsbEditarCostos.Visible = False

                    Me.DtpFecha.Enabled = False
                    Me.CboAlmacen.Enabled = False
                    Me.CboDocumento.Enabled = False
                    Me.txtFolioCompra.Enabled = False
                    Me.txtFolioOC.Enabled = False
                    Me.txtProveedor.Enabled = False
                    Me.txtFolioProveedor.Enabled = False
                    Me.txtEntregarA.Enabled = False
                    Me.txtSolicito.Enabled = False
                    Me.txtTipoCambio.Enabled = False
                    Me.txtPlazo.Enabled = False
                    'Me.TxtRetencion.Enabled = False
                    'Me.TxtConcepto.Enabled = False
                    Me.TxtConcepto.ReadOnly = True
                    Me.Grid.Locked = True
                    Me.GridSeries.Locked = True
                    Me.DtpFechaFacturaProveedor.Enabled = False
                    Me.BtnActualizaFolioProv.Visible = False
                    Me.btnActualizaConcepto.Visible = False
                    Me.txtIVA.Enabled = False
                    Me.btnSeries.Enabled = False
                    Me.btnSeleccionarArchivoSeries.Enabled = False

                    Me.tsslEstado.Text = "Estado: Consultando movimiento"
                    Me.tsslElaboro.Visible = True : Me.tsslElaboro.Text = "Elaboró: " + Me.oCompras.NOMBRE_USUARIO_GRABO.ToUpper + " el " + Format(Me.DtpFecha.Value, "dd/MMM/yy").ToUpper
                    Me.tsslCancelo.Visible = True : Me.tsslCancelo.Text = "Canceló: " + Me.oCompras.NOMBRE_USUARIO_CANCELO.ToUpper + " el " + Format(Me.oCompras.FECHA_CANCELACION, "dd/MMM/yy").ToUpper
                    If Me.oDocumento.AFECTA_CXP = True Then
                        Me.DtpFechaFacturaProveedor.Visible = True : Me.lblDisplayFechaFacturaProveedor.Visible = True
                    Else
                        Me.DtpFechaFacturaProveedor.Visible = False : Me.lblDisplayFechaFacturaProveedor.Visible = False
                    End If

                    Me.tsbImprimir.Select()

                    Me.LblConceptoCancelacion.Visible = True
                    Me.TxtConceptoCancelacion.Visible = True
                    'Me.TxtConceptoCancelacion.Enabled = False
                    Me.TxtConceptoCancelacion.ReadOnly = True

            End Select

            Me.OcultarControles()

            Application.DoEvents()

        Catch ex As Exception
            HandleError(Me.Name, "Cambia_Estado", ex)
        End Try
    End Sub

    Function Grabar() As Boolean
        Dim bResultado As Boolean = False
        Dim i As Integer

        If MsgBox("Deseas grabar la " & Me.CboDocumento.Text & " con el folio : " & Me.txtFolioCompra.Text & " ?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "Grabar") = MsgBoxResult.No Then
            Return False
        End If

        If Me.oDocumento.AFECTA_INVENTARIOS = True Then
            If Usuario.ValidaPermisoUsuarioDocumentoConAfectacionInventarios(Me.CboDocumento.SelectedValue.ToString, Me.CboAlmacen.SelectedValue.ToString) = False Then
                MsgBox("El usuario " & Usuario.Nombre_Usuario & " no tiene permiso para realizar el movimiento.", MsgBoxStyle.Exclamation, Me.Text)
                Return False
            End If
        Else
            If Usuario.ValidaPermisoUsuarioDocumentoSinAfectacionInventarios(Me.CboDocumento.SelectedValue.ToString) = False Then
                MsgBox("El usuario " & Usuario.Nombre_Usuario & " no tiene permiso para realizar el movimiento.", MsgBoxStyle.Exclamation, Me.Text)
                Return False
            End If
        End If

        If Me.Totales(True) = False Then
            Return False
        End If

        If Me.ValidarOrdenCompra() = False Then
            Return False
        End If

        Try
            With Me.oCompras
                .FOLIO_COMPRA = Me.txtFolioCompra.Text
                .CODIGO_DOCUMENTO = Me.CboDocumento.SelectedValue.ToString
                .CODIGO_ALMACEN = Me.CboAlmacen.SelectedValue.ToString
                .CODIGO_PLAZA = Plaza.CODIGO_PLAZA
                .FECHA = Me.DtpFecha.Value
                .CODIGO_PROVEEDOR = Me.txtProveedor.Text
                .PLAZO = CInt(Me.txtPlazo.Text)
                .FECHA_VENCIMIENTO = Me.dtpFechaVencimiento.Value
                .SUBTOTAL = valorNumerico(Me.TxtSubTotal.Text)
                .IEPS_TOTAL_DESGLOSADO = valorNumerico(Me.txtIEPS.Text)
                .IMPUESTO = valorNumerico(Me.txtIVA.Text)
                .TOTAL = valorNumerico(Me.txtTotal.Text)
                .RETENCION = valorNumerico(Me.TxtRetencion.Text)
                .IMPUESTO_PORCENTAJE = dPorcentajeIVAGlobal
                .TIPO_DE_CAMBIO = CDbl(IIf(Me.cboMoneda.SelectedIndex = 1, valorNumerico(Me.txtTipoCambio.Text), 0))
                .ENTREGAR_A = Me.txtEntregarA.Text
                .SOLICITO = Me.txtSolicito.Text
                .CONCEPTO = Me.TxtConcepto.Text
                .CON_CARGO_A = Me.txtConCargoA.Text
                .PREDIO = Me.txtPredio.Text
                .CONFIRMO = Me.txtConfirmo.Text

                If Me.Estado = enumEstados.NUEVO Then
                    If .InsertarOrdenCompra() = False Then
                        MsgBox("Error al tratar de insertar el movimiento de compras.", MsgBoxStyle.Exclamation, Me.Text)
                        Return False
                    End If
                    Me.txtFolioCompra.Text = .FOLIO_COMPRA
                Else
                    If .ActualizarOrdenCompra() = False Then
                        MsgBox("Error al tratar de actualizar el movimiento de compras.", MsgBoxStyle.Exclamation, Me.Text)
                        Return False
                    End If
                End If

                'se graba el detalle
                For i = 1 To Me.Grid.Rows - 1
                    If txtLEN(Me.Grid.Cell(i, Me.igyCodigo).Text) = True Then
                        .NuevoRenglon()
                        .oComprasDetalle.FOLIO_COMPRA = .FOLIO_COMPRA.ToString
                        .oComprasDetalle.CODIGO_ARTICULO = Me.Grid.Cell(i, Me.igyCodigo).Text.ToUpper
                        .oComprasDetalle.DESCRIPCION = Me.Grid.Cell(i, Me.igyDescripcion).Text.ToUpper
                        .oComprasDetalle.CANTIDAD = valorNumerico(Me.Grid.Cell(i, Me.igyCantidad).Text)
                        .oComprasDetalle.PRECIO = valorNumerico(Me.Grid.Cell(i, Me.igyPrecio).Text)
                        .oComprasDetalle.UNIDAD_VENTA = Me.Grid.Cell(i, Me.igyUnidad).Text.ToUpper
                        .oComprasDetalle.IMPUESTO_PORCENTAJE = valorNumerico(Me.Grid.Cell(i, Me.igyImpuestoPorcentaje).Text)
                        .oComprasDetalle.IMPUESTO_IMPORTE = Val(Me.Grid.Cell(i, Me.igyImpuestoImporte).Text)
                        .oComprasDetalle.IMPORTE = Val(Me.Grid.Cell(i, Me.igyImporte).Text)

                        .oComprasDetalle.IEPS_PORCENTAJE = valorNumerico(Me.Grid.Cell(i, Me.igyIEPS_PORCENTAJE).Text)
                        .oComprasDetalle.IEPS_UNITARIO = valorNumerico(Me.Grid.Cell(i, Me.igyIEPS_UNITARIO).Text)
                        .oComprasDetalle.IEPS_IMPORTE = valorNumerico(Me.Grid.Cell(i, Me.igyIEPS_IMPORTE).Text)
                        .oComprasDetalle.BASE_IEPS = valorNumerico(Me.Grid.Cell(i, Me.igyBASE_IEPS).Text)
                        .oComprasDetalle.BASE_IVA = valorNumerico(Me.Grid.Cell(i, Me.igyBASE_IVA).Text)

                        If .oComprasDetalle.GrabaRenglonOrdenCompra() = False Then
                            MsgBox("Error al tratar de grabar el detalle.", MsgBoxStyle.Exclamation, Me.Text)
                            Return False
                        End If
                    End If
                Next
                bResultado = True
                Me.txtFolioCompra.Text = .FOLIO_COMPRA.ToString
                MsgBox("Movimiento de compras grabado satisfactoriamente.", MsgBoxStyle.Information, Me.Text)

            End With
        Catch ex As Exception
            HandleError(Me.Name, "Grabar", ex)
        End Try

        Return bResultado
    End Function

    Function Aplicar() As Boolean
        Dim bResultado As Boolean = False
        Dim i As Integer, sListaIDsDetalle As String = "", sListaSeries As String = ""

        If MsgBox("Deseas aplicar la " & Me.CboDocumento.Text & " con el folio : " & Me.txtFolioCompra.Text & " ?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "Aplicar") = MsgBoxResult.No Then
            Return False
        End If

        If Usuario.ValidaPermisoUsuarioDocumentoConAfectacionInventarios(Me.CboDocumento.SelectedValue.ToString, Me.CboAlmacen.SelectedValue.ToString) = False Then
            MsgBox("El usuario " & Usuario.Nombre_Usuario & " no tiene permiso para realizar el movimiento.", MsgBoxStyle.Exclamation, Me.Text)
            Return False
        End If

        If Me.ValidarCompra() = False Then
            Return False
        End If

        Try
            With Me.oCompras
                .FOLIO_COMPRA = Me.txtFolioCompra.Text
                .CODIGO_DOCUMENTO = Me.CboDocumento.SelectedValue.ToString
                .CODIGO_ALMACEN = Me.CboAlmacen.SelectedValue.ToString
                .CODIGO_PLAZA = Plaza.CODIGO_PLAZA
                .FECHA = Me.DtpFecha.Value
                .FECHA_FACTURA_PROVEEDOR = Me.DtpFechaFacturaProveedor.Value
                .FOLIO_OC = Me.txtFolioOC.Text
                .FOLIO_PROVEEDOR = Me.txtFolioProveedor.Text
                .CODIGO_PROVEEDOR = Me.txtProveedor.Text
                .PLAZO = CInt(Me.txtPlazo.Text)
                .FECHA_VENCIMIENTO = Me.dtpFechaVencimiento.Value
                .SUBTOTAL = valorNumerico(Me.TxtSubTotal.Text)
                .IMPUESTO = valorNumerico(Me.txtIVA.Text)
                .TOTAL = valorNumerico(Me.txtTotal.Text)
                .RETENCION = valorNumerico(Me.TxtRetencion.Text)
                .IMPUESTO_PORCENTAJE = dPorcentajeIVAGlobal
                .TIPO_DE_CAMBIO = valorNumerico(Me.txtTipoCambio.Text)
                .ENTREGAR_A = Me.txtEntregarA.Text
                .SOLICITO = Me.txtSolicito.Text
                .CONCEPTO = Me.TxtConcepto.Text
                .CON_CARGO_A = Me.txtConCargoA.Text
                .PREDIO = Me.txtPredio.Text
                .CONFIRMO = Me.txtConfirmo.Text

                If .GrabaCompraGlobal() = False Then
                    MsgBox("Error al tratar de aplicar el movimiento de compras.", MsgBoxStyle.Exclamation, Me.Text)
                    Return False
                End If
                Me.txtFolioCompra.Text = .FOLIO_COMPRA

                'se graba el detalle
                For i = 1 To Me.Grid.Rows - 1
                    If txtLEN(Me.Grid.Cell(i, Me.igyCodigo).Text) = True Then
                        .NuevoRenglon()
                        .oComprasDetalle.FOLIO_COMPRA = .FOLIO_COMPRA.ToString
                        .oComprasDetalle.CODIGO_ARTICULO = Me.Grid.Cell(i, Me.igyCodigo).Text.ToUpper
                        .oComprasDetalle.CANTIDAD = valorNumerico(Me.Grid.Cell(i, Me.igyCantidad).Text)
                        .oComprasDetalle.PRECIO = valorNumerico(Me.Grid.Cell(i, Me.igyPrecio).Text)
                        .oComprasDetalle.UNIDAD_VENTA = Me.Grid.Cell(i, Me.igyUnidad).Text.ToUpper
                        .oComprasDetalle.IMPUESTO_PORCENTAJE = valorNumerico(Me.Grid.Cell(i, Me.igyImpuestoPorcentaje).Text)
                        .oComprasDetalle.IMPUESTO_IMPORTE = valorNumerico(Me.Grid.Cell(i, Me.igyImpuestoImporte).Text)
                        .oComprasDetalle.IMPORTE = valorNumerico(Me.Grid.Cell(i, Me.igyImporte).Text)
                        .oComprasDetalle.ID_ORIGEN = CInt(Me.Grid.Cell(i, Me.igyIdArticulo).Text)
                        .oComprasDetalle.CUENTA_CONTABLE = Me.Grid.Cell(i, Me.igyCuentaContable).Text
                        .oComprasDetalle.ID_ADICIONAL = CInt(valorNumerico(Me.Grid.Cell(i, Me.iGyIDAdicional).Text))

                        If Me.dtSeries.Rows.Count > 0 Then
                            For Each dRow In Me.dtSeries.Select("POSICION=" & i.ToString)
                                sListaSeries = sListaSeries & dRow("POSICION").ToString & "," & dRow("CODIGO_ARTICULO").ToString & "," & dRow("NUMERO_SERIE").ToString & "|"
                            Next
                            If txtLEN(sListaSeries) = True Then
                                sListaSeries = sListaSeries.Substring(0, sListaSeries.Length - 1) 'Para quitarle el último pipe que sale sobrando.
                            End If
                        End If

                        .oComprasDetalle.LISTA_SERIES = sListaSeries

                        .oComprasDetalle.IEPS_PORCENTAJE = valorNumerico(Me.Grid.Cell(i, Me.igyIEPS_PORCENTAJE).Text)
                        .oComprasDetalle.IEPS_UNITARIO = valorNumerico(Me.Grid.Cell(i, Me.igyIEPS_UNITARIO).Text)
                        .oComprasDetalle.IEPS_IMPORTE = valorNumerico(Me.Grid.Cell(i, Me.igyIEPS_IMPORTE).Text)
                        .oComprasDetalle.BASE_IEPS = valorNumerico(Me.Grid.Cell(i, Me.igyBASE_IEPS).Text)
                        .oComprasDetalle.BASE_IVA = valorNumerico(Me.Grid.Cell(i, Me.igyBASE_IVA).Text)

                        If .oComprasDetalle.GrabaRenglonCompra() = False Then
                            MsgBox("Error al tratar de grabar el detalle.", MsgBoxStyle.Exclamation, Me.Text)
                            Return False
                            'Else
                            '    ya no se ocuparia esto, porque las series ya estan especificadas en el mismo renglon
                            '    sListaIDsDetalle = sListaIDsDetalle & i.ToString & "," & .oComprasDetalle.ID_COMPRA_DETALLE.ToString & "|"
                        End If
                    End If

                    sListaSeries = ""
                Next

                'For i = 1 To Me.GridSeries.Rows - 1
                '    If txtLEN(Me.GridSeries.Cell(i, Me.igySerieCodigo).Text) = True Then
                '        sListaSeries = sListaSeries & Me.GridSeries.Cell(i, Me.igySeriePosicion).Text & "," & Me.GridSeries.Cell(i, Me.igySerieCodigo).Text & "," & Me.GridSeries.Cell(i, Me.igySerieNumeroSerie).Text & "|"
                '    End If
                'Next

                'If txtLEN(sListaSeries) = True Then
                '    sListaSeries = sListaSeries.Substring(0, sListaSeries.Length - 1) 'Para quitarle el último pipe que sale sobrando.
                'End If
                'If txtLEN(sListaIDsDetalle) = True Then
                '    sListaIDsDetalle = sListaIDsDetalle.Substring(0, sListaIDsDetalle.Length - 1) 'Para quitarle el último pipe que sale sobrando.
                'End If

                'If Me.oCompras.AfectaInventarioCompra(sListaIDsDetalle, sListaSeries) = False Then
                '    MsgBox("Error al tratar de afectar el inventario.", MsgBoxStyle.Exclamation, Me.Text)
                '    RETURN FALSE
                'End If

                If Me.oCompras.AfectaInventarioCompra() = False Then
                    MsgBox("Error al tratar de afectar el inventario.", MsgBoxStyle.Exclamation, Me.Text)
                    Return False
                End If

                Me.txtFolioCompra.Text = .FOLIO_COMPRA.ToString

                Dim sListaCuentas As String = ""

                If IsNothing(Me.oFormaDetalleCuentas) = False Then 'Si no esta vacia, osea si existe
                    Me.oFormaDetalleCuentas.FolioMovimientoInventario = Me.txtFolioCompra.Text 'Hasta aqui la forma auxiliar no tenia el folio
                    sListaCuentas = Me.oFormaDetalleCuentas.ObtieneListaDetalleCuentas()
                End If

                If txtLEN(sListaCuentas) = True Then
                    .oComprasDetalle.GrabaDetalleCentroCostos(sListaCuentas, Me.CboDocumento.SelectedValue.ToString, Me.DtpFecha.Value)
                End If

                If Me.oCompras.AfectaContabilidadCompra = False Then
                    MsgBox("Error al tratar de afectar contabilidad.", MsgBoxStyle.Exclamation, Me.Text)
                    Return False
                End If

                bResultado = True

                MsgBox("Movimiento de compras aplicado satisfactoriamente.", MsgBoxStyle.Information, Me.Text)

            End With
        Catch ex As Exception
            HandleError(Me.Name, "Aplicar", ex)
        End Try

        Return bResultado
    End Function

    Private Function ActualizaFolioProveedor() As Boolean
        Try
            If Usuario.ValidaPermisoUsuarioDocumentoConAfectacionInventarios(Me.CboDocumento.SelectedValue.ToString, Me.CboAlmacen.SelectedValue.ToString) = False Then
                MsgBox("El usuario " & Usuario.Nombre_Usuario & " no tiene permiso para realizar el movimiento.", MsgBoxStyle.Information, Me.Text)
                Exit Function
            End If

            Dim sFolioProv As String
            sFolioProv = InputBox("Proporcione el nuevo folio de la factura del proveedor", "Folio de proveedor")
            If String.IsNullOrEmpty(sFolioProv) Then
                Exit Function
            Else
                Me.oCompras.FOLIO_PROVEEDOR = sFolioProv
                Me.oCompras.ActualizaFolioProveedor()
            End If
            Return True
        Catch ex As Exception
            HandleError(Me.Name, "AcualizaFolioProveedor", ex)
        End Try
    End Function

    Private Function Consultar(Optional ByVal bEsReferencia As Boolean = False) As Boolean
        Dim bResultado As Boolean = False
        Dim sCompra As String = Me.txtFolioCompra.Text
        Dim sOrdenCompra As String = Me.txtFolioOC.Text

        Try
            If _ConsultaExterior = True Then
                Me.InicializaExterno()
            Else
                Me.Inicializa()
            End If

            Me.bEsReferencia = bEsReferencia

            If Me.bEsReferencia = False Then
                Me.oCompras = New Class_Compras_Global(sCompra, Me.CboDocumento.SelectedValue.ToString)
            Else
                Me.oCompras = New Class_Compras_Global(sOrdenCompra, Me.oCompras.ObtieneCodigoDocumentoOrdenCompra(sOrdenCompra))
            End If

            If Me.oCompras.Existe = False Then
                Me.Cambia_Estado(enumEstados.NUEVO)
                Me.txtFolioCompra.Enabled = False
                Me.CboDocumento.Enabled = False
                Return False
            Else
                If bEsReferencia = False Then
                    Me.txtFolioCompra.Text = Me.oCompras.FOLIO_COMPRA.ToString.ToUpper
                    Me.txtFolioOC.Text = Me.oCompras.FOLIO_OC.ToString.ToUpper
                    Me.LblEstatus.Text = Me.oCompras.ESTATUS.ToString.ToUpper
                    Me.txtFolioProveedor.Text = Me.oCompras.FOLIO_PROVEEDOR.ToString.ToUpper

                    Me.Grid.DataSource = Me.oCompras.ObtenerDetalle
                    'If Me.oDocumento.AFECTA_CXP = True Then
                    '    Me.Grid.DataSource = Me.oCompras.ObtenerDetalle
                    'Else
                    '    Me.Grid.DataSource = Me.oCompras.ObtenerDetalleOrdenCompra
                    'End If

                    Me.GridSeries.DataSource = Me.oCompras.ObtenerDetalleSeries
                    Me.FormateaGridSeries()

                Else
                    Me.txtFolioOC.Text = Me.oCompras.FOLIO_COMPRA.ToString.ToUpper
                    Me.txtFolioCompra.Enabled = False
                    Me.Grid.DataSource = Me.oCompras.ObtenerDetalleOrdenCompra
                End If

                Me.CboAlmacen.SelectedValue = Me.oCompras.CODIGO_ALMACEN
                Me.txtProveedor.Text = Me.oCompras.CODIGO_PROVEEDOR
                Me.oProveedores = New Class_CatProveedores(Me.oCompras.CODIGO_PROVEEDOR)
                Me.lblProveedor.Text = oProveedores.Nombre_Proveedor.ToUpper

                Me.txtPlazo.Text = Me.oCompras.PLAZO.ToString
                Me.dtpFechaVencimiento.Value = CDate(Me.oCompras.FECHA_VENCIMIENTO)

                'Esto va antes de los totales, porque se va ejecutar el checked de los dolares
                If Me.oCompras.TIPO_DE_CAMBIO > 0 Then
                    Me.txtTipoCambio.Text = Me.oCompras.TIPO_DE_CAMBIO.ToString
                    Me.cboMoneda.SelectedIndex = 1
                Else
                    Me.txtTipoCambio.Text = "0"
                    Me.cboMoneda.SelectedIndex = 0
                End If

                If bEsReferencia = False Then 'Estos datos no tienen que llenarse si se esta aplicando una oc(jalando a una co)
                    Me.TxtSubTotal.Text = FormatImporteContable(Me.oCompras.SUBTOTAL)
                    Me.txtIEPS.Text = FormatImporteContable(Me.oCompras.IEPS_TOTAL_DESGLOSADO)
                    Me.txtIVA.Text = FormatImporteContable(Me.oCompras.IMPUESTO)
                    Me.TxtRetencion.Text = FormatImporteContable(Me.oCompras.RETENCION)
                    Me.txtTotal.Text = FormatImporteContable(Me.oCompras.TOTAL)
                    Me.txtSaldoMXP.Text = FormatImporteContable(Me.oCompras.SALDO)
                    Me.txtSaldoUSD.Text = FormatImporteContable(Me.oCompras.SALDO_DOLARES)

                    Me.TxtSubTotalUSD.Text = FormatImporteContable(Me.oCompras.SUBTOTAL_USD)
                    Me.txtIVAUSD.Text = FormatImporteContable(Me.oCompras.IMPUESTO_USD)
                    Me.txtTotalUSD.Text = FormatImporteContable(Me.oCompras.TOTAL_DOLARES)
                Else
                    Me.Totales()
                End If

                If Me.oCompras.CODIGO_TIPO_GASTO = "3" Then
                    Me.LblPoliza.Text = Me.oCompras.FOLIO_EMBARQUE
                Else
                    Me.LblPoliza.Text = Me.oCompras.FOLIO_POLIZA
                End If

                Me.txtEntregarA.Text = Me.oCompras.ENTREGAR_A.ToString.ToUpper
                Me.txtSolicito.Text = Me.oCompras.SOLICITO.ToString.ToUpper
                Me.TxtConcepto.Text = Me.oCompras.CONCEPTO.ToString.ToUpper
                Me.txtConCargoA.Text = Me.oCompras.CON_CARGO_A.ToString.ToUpper
                Me.txtPredio.Text = Me.oCompras.PREDIO.ToString.ToUpper
                Me.txtConfirmo.Text = Me.oCompras.CONFIRMO.ToString.ToUpper
                Me.txtConCargoA.Text = Me.oCompras.CON_CARGO_A.ToString.ToUpper
                Me.txtPredio.Text = Me.oCompras.PREDIO.ToString.ToUpper
                Me.txtConfirmo.Text = Me.oCompras.CONFIRMO.ToString.ToUpper
                Me.txtFolioProveedor.Text = Me.oCompras.FOLIO_PROVEEDOR
                Me.TxtConceptoCancelacion.Text = Me.oCompras.CONCEPTO_CANCELACION

                Me.DtpFecha.Value = CDate(Me.oCompras.FECHA)
                Me.dtpFechaVencimiento.Value = Me.DtpFecha.Value.AddDays(CDbl(Me.txtPlazo.Text))

                If Me.oCompras.FECHA_FACTURA_PROVEEDOR = Nothing Then
                    Me.DtpFechaFacturaProveedor.Value = Now
                Else
                    Me.DtpFechaFacturaProveedor.Value = CDate(Me.oCompras.FECHA_FACTURA_PROVEEDOR)
                End If

                Me.FormateaGrid()

                If Me.oDocumento.AFECTA_CXP = True Then
                    Me.Grid.Row(Me.Grid.Rows - 1).Locked = True
                    If Me.LblEstatus.Text = "N" Then
                        If EstableceCuentaContableAlmacenDestino() = False Then
                            MsgBox("No se pudieron establecer las cuentas contables de los articulos inventariables.", MsgBoxStyle.Information, Me.Text)
                        End If
                    End If
                End If
            End If

            bResultado = True

            If bEsReferencia = True Then
                If Me.oCompras.ESTATUS = "A" Then
                    MsgBox("La oc especificada ya esta aplicada en la compra(s) " & Me.oCompras.ListaComprasAplicaronOc(Me.txtFolioOC.Text), MsgBoxStyle.Exclamation, Me.Text)
                End If
            End If

            Me.GestionaCambioEstado()
            Me.txtFolioCompra.Enabled = False

        Catch ex As Exception
            HandleError(Me.Name, "Consultar", ex)
        End Try

        Return bResultado
    End Function

    Private Function CancelarCompra() As Boolean
        Dim bResultado As Boolean = False

        Dim oFirmaElectronica = New UtileriasFirmaElectronicaCancelacionMovimientosFueraPeriodo
        Dim oUtileriasCancela As New Class_UtileriasFirmaElectronicaCancelacion
        Dim oPoliza As New Class_Contabilidad_Poliza_Global
        Dim sConceptoCancelacion As String = ""

        If MsgBox("Deseas cancelar el movimiento de " & Me.CboDocumento.Text & " ?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "CancelarCompra") = MsgBoxResult.No Then
            Exit Function
        End If

        If _ConsultaExterior = True Then
            If Usuario.ValidaPermisoUsuarioDocumentoConAfectacionInventarios("CO" & Plaza.CODIGO_PLAZA.ToString, Me.CboAlmacen.SelectedValue.ToString) = False Then
                MsgBox("El usuario " & Usuario.Nombre_Usuario & " no tiene permiso para realizar el movimiento de inventarios.", MsgBoxStyle.Exclamation, Me.Text)
                Exit Function
            End If
        Else
            If Usuario.ValidaPermisoUsuarioDocumentoConAfectacionInventarios(Me.CboDocumento.SelectedValue.ToString, Me.CboAlmacen.SelectedValue.ToString) = False Then
                MsgBox("El usuario " & Usuario.Nombre_Usuario & " no tiene permiso para realizar el movimiento de inventarios.", MsgBoxStyle.Exclamation, Me.Text)
                Exit Function
            End If
        End If

        If Me.oCompras.ValidaExistencias() = False Then
            Exit Function
        End If

        'no se ocupa por que para eso esta la interfaz
        'If PLAZA.ValidarPeriodoTrabajo(Me.oCompras.FECHA) = False Then 'Para cancelar se valida con la fecha de la maquina
        '    Exit Function
        'End If

        Try
            oUtileriasCancela.FOLIO_DOCUMENTO = Me.txtFolioCompra.Text.ToUpper
            oUtileriasCancela.MODULO = Me.oCompras.CODIGO_MODULO
            oUtileriasCancela.CODIGO_PLAZA = Usuario.Codigo_Plaza

            If oUtileriasCancela.GestionaCancelacion() = False Then
                Exit Function
            End If

            If oUtileriasCancela.CANCELA_DIRECTO = True Then
                Me.oCompras.FECHA_CANCELACION = Date.Now

                sConceptoCancelacion = InputBox("Ingrese un concepto de cancelación :", "Conepto de cancelación")
                Me.oCompras.CONCEPTO_CANCELACION = sConceptoCancelacion

                If Me.oCompras.CancelaCompra() = False Then
                    Exit Function
                End If
            Else
                oUtileriasCancela = New Class_UtileriasFirmaElectronicaCancelacion
                oUtileriasCancela.FOLIO_DOCUMENTO = Me.txtFolioCompra.Text
                oUtileriasCancela.FOLIO_POLIZA = Me.oCompras.FOLIO_POLIZA
                oUtileriasCancela.CODIGO_DOCUMENTO = Me.CboDocumento.SelectedValue.ToString
                oUtileriasCancela.CODIGO_PLAZA = Usuario.Codigo_Plaza
                oUtileriasCancela.MODULO = Me.oCompras.CODIGO_MODULO

                If oUtileriasCancela.AutorizaCancelacionMovimientosFueraPeriodo() = False Then
                    'MsgBox("Error al tratar de autorizar la cancelación fuera del periodo.", MsgBoxStyle.Exclamation, Me.Text)
                    Exit Function
                End If

                sConceptoCancelacion = oUtileriasCancela.CANCELACION_CONCEPTO
                Me.oCompras.CONCEPTO_CANCELACION = sConceptoCancelacion

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

                    Me.oCompras.FECHA_CANCELACION = oUtileriasCancela.FECHA_CANCELACION

                    If Me.oCompras.CancelaCompra() = False Then
                        MsgBox("Error al intentar cancelar el movimiento de inventario.", MsgBoxStyle.Exclamation, Me.Text)
                        Exit Function
                    End If
                End If
            End If

            MsgBox("Compra cancelada satisfactoriamente.", MsgBoxStyle.Information, Me.Text)
            bResultado = True
        Catch ex As Exception
            HandleError(Me.Name, "CancelarCompra", ex)
        End Try

        Return bResultado
    End Function

    Private Function CancelaOrdenCompra() As Boolean
        Dim bResultado As Boolean = False
        Dim sConceptoCancelacion As String = ""

        Try
            If MsgBox("Deseas Cancelar el documento " & CboDocumento.Text & "  con el Folio: " & txtFolioCompra.Text & "?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "CancelaOrdenCompra") = MsgBoxResult.No Then
                Exit Function
            End If

            If Usuario.ValidaPermisoUsuarioDocumentoSinAfectacionInventarios(Me.CboDocumento.SelectedValue.ToString) = False Then
                MsgBox("El usuario " & Usuario.Nombre_Usuario & " no tiene permiso para realizar el movimiento.", MsgBoxStyle.Information, Me.Text)
                Exit Function
            End If

            'No se necesita
            'If PLAZA.ValidarPeriodoTrabajo(Me.DtpFecha.Value) = False Then
            '    Exit Function
            'End If

            Select Case Me.oCompras.ESTATUS
                Case "C"
                    MsgBox("No se puede cancelar la order de compra por que ya esta cancelada.", MsgBoxStyle.Exclamation, "CancelaOrdenCompra")
                    Exit Function
                Case "R"
                    MsgBox("No se puede cancelar la orden de compra si esta parcialmente recepcionada.", MsgBoxStyle.Exclamation, "CancelaOrdenCompra")
                    Exit Function
                Case "A"
                    MsgBox("No se puede cancelar la orden de compra si esta aplicada.", MsgBoxStyle.Exclamation, "CancelaOrdenCompra")
                    Exit Function
            End Select

            sConceptoCancelacion = InputBox("Ingrese un concepto de cancelación :", "Concepto de cancelación")
            Me.oCompras.CONCEPTO_CANCELACION = sConceptoCancelacion

            If Me.oCompras.CancelaOrdenCompra = False Then
                Exit Function
            End If

            MsgBox("La orden de compra fue cancelada exitosamente.", MsgBoxStyle.Information, "CancelaOrdenCompra")
            bResultado = True

        Catch ex As Exception
            HandleError(Me.Name, "CancelaOrdenCompra", ex)
        End Try

        Return bResultado
    End Function

    Private Function ValidarOrdenCompra() As Boolean
        Dim bPrimerIVAEncontrado As Boolean, bHayArticulos As Boolean = False
        Dim oArticulos As Class_CatArticulos

        Try
            If Plaza.ValidarPeriodoTrabajo(Me.DtpFecha.Value) = False Then
                Exit Function
            End If

            If txtLEN(Me.txtFolioCompra.Text) = False Then
                MsgBox("Asigne un folio válido.", MsgBoxStyle.Exclamation, "ValidarOrdenCompra")
                Exit Function
            End If

            If txtLEN(Me.txtProveedor.Text) = False Then
                MsgBox("Asigne un proveedor.", MsgBoxStyle.Exclamation, "ValidarOrdenCompra")
                Me.txtProveedor.Focus()
                Exit Function
            End If

            Me.oProveedores = New Class_CatProveedores(Me.txtProveedor.Text)
            If Me.oProveedores.Existe = False Then
                MsgBox("Asigne un proveedor válido.", MsgBoxStyle.Exclamation, "ValidarOrdenCompra")
                Me.txtProveedor.Focus()
                Exit Function
            End If

            Dim sql As New Class_find("SELECT T.REALIZA_COMPRAS_GASTOS_PAGOS FROM CAT_PROVEEDORES P INNER JOIN SIS_TIPOS_PROVEEDORES T ON(P.CODIGO_TIPO_PROVEEDOR=T.CODIGO_TIPO_PROVEEDOR)" &
                                      " WHERE P.CODIGO_PROVEEDOR='" & Me.txtProveedor.Text & "'")
            If sql.Result1 = "0" Then
                MsgBox("El proveedor " & Me.txtProveedor.Text & "no puede realizar movimientos de compras.", MsgBoxStyle.Information, Me.Text)
                Me.txtProveedor.Focus()
                Exit Function
            End If

            If txtLEN(Me.oProveedores.CUENTA_CONTABLE) = False Then
                MsgBox("El proveedor no tiene una cuenta contable en pesos asignada.", MsgBoxStyle.Exclamation, "ValidarOrdenCompra")
                Me.txtProveedor.Focus()
                Exit Function
            End If

            If Mid(Me.oProveedores.CUENTA_CONTABLE, 1, 1) <> "2" Then
                'or Me.oProveedores.NOMBRE_TIPO_PROVEEDOR
                MsgBox("La cuenta contable del proveedor debe empezar con '2'.", MsgBoxStyle.Information, Me.Text)
                Me.lblProveedor.Text = ""
                Me.txtProveedor.Focus()
                Exit Function
            End If

            If Me.cboMoneda.SelectedIndex = 1 Then
                If txtLEN(Me.oProveedores.CUENTA_CONTABLE_DOLARES) = False Then
                    MsgBox("El proveedor no tiene una cuenta contable en dólares asignada.", MsgBoxStyle.Exclamation, "ValidarOrdenCompra")
                    Me.txtProveedor.Focus()
                    Exit Function
                End If
            End If

            'If txtLEN(Me.txtEntregarA.Text) = False Then
            '    MsgBox("Asigne el nombre de la persona a la que se le va a entregar.", MsgBoxStyle.Exclamation, "ValidarOrdenCompra")
            '    Me.txtEntregarA.Focus()
            '    Exit Function
            'End If

            'If txtLEN(Me.txtSolicito.Text) = False Then
            '    MsgBox("Asigne el nombre de la persona que solicitó.", MsgBoxStyle.Exclamation, "ValidarOrdenCompra")
            '    Me.txtSolicito.Focus()
            '    Exit Function
            'End If

            'If txtLEN(Me.txtConCargoA.Text) = False Then
            '    MsgBox("Asigne el cargo a.", MsgBoxStyle.Exclamation, "ValidarOrdenCompra")
            '    Me.txtConCargoA.Focus()
            '    Exit Function
            'End If

            'If txtLEN(Me.txtPredio.Text) = False Then
            '    MsgBox("Asigne un predio válido.", MsgBoxStyle.Exclamation, "ValidarOrdenCompra")
            '    Me.txtPredio.Focus()
            '    Exit Function
            'End If

            'If txtLEN(Me.txtConfirmo.Text) = False Then
            '    MsgBox("Asigne el nombre de la persona que confirmo los precios.", MsgBoxStyle.Exclamation, "ValidarOrdenCompra")
            '    Me.txtConfirmo.Focus()
            '    Exit Function
            'End If

            Me.dPorcentajeIVAGlobal = 0

            Dim i As Integer
            For i = 1 To Grid.Rows - 1
                If txtLEN(Me.Grid.Cell(i, Me.igyCodigo).Text) = True Then
                    oArticulos = New Class_CatArticulos(Me.Grid.Cell(i, Me.igyCodigo).Text)

                    If oArticulos.Existe = False Then
                        MsgBox("El artículo no existe.", MsgBoxStyle.Exclamation, "ValidarOrdenCompra")
                        Me.Grid.Cell(i, Me.igyCodigo).SetFocus()
                        Exit Function
                    End If

                    If txtLEN(Me.Grid.Cell(i, Me.igyDescripcion).Text) = False Then
                        MsgBox("El artículo no tiene descripción.", MsgBoxStyle.Exclamation, "ValidarOrdenCompra")
                        Me.Grid.Cell(i, Me.igyDescripcion).SetFocus()
                        Exit Function
                    End If

                    If valorNumerico(Me.Grid.Cell(i, Me.igyCantidad).Text) <= 0 Then
                        MsgBox("La cantidad del artículo debe de ser mayor a 0.", MsgBoxStyle.Exclamation, "ValidarOrdenCompra")
                        Me.Grid.Cell(i, Me.igyCantidad).SetFocus()
                        Exit Function
                    End If

                    If valorNumerico(Me.Grid.Cell(i, Me.igyPrecio).Text) <= 0 Then
                        MsgBox("El precio del artículo debe de ser mayor a 0.", MsgBoxStyle.Exclamation, "ValidarOrdenCompra")
                        Me.Grid.Cell(i, Me.igyPrecio).SetFocus()
                        Exit Function
                    End If

                    If txtLEN(Me.Grid.Cell(i, Me.igyUnidad).Text) = False Then
                        MsgBox("El artículo no tiene unidad de venta.", MsgBoxStyle.Exclamation, "ValidarOrdenCompra")
                        Me.Grid.Cell(i, Me.igyUnidad).SetFocus()
                        Exit Function
                    End If

                    If txtLEN(Me.Grid.Cell(i, Me.igyImpuestoPorcentaje).Text) = False Then
                        MsgBox("El artículo no tiene un porcentaje de iva.", MsgBoxStyle.Exclamation, "ValidarOrdenCompra")
                        Me.Grid.Cell(i, Me.igyImpuestoPorcentaje).SetFocus()
                        Exit Function
                    End If

                    If valorNumerico(Me.Grid.Cell(i, Me.igyImpuestoPorcentaje).Text) > 0 Then
                        If bPrimerIVAEncontrado = False Then
                            Me.dPorcentajeIVAGlobal = valorNumerico(Me.Grid.Cell(i, Me.igyImpuestoPorcentaje).Text)
                            bPrimerIVAEncontrado = True
                        Else
                            If dPorcentajeIVAGlobal <> valorNumerico(Me.Grid.Cell(i, Me.igyImpuestoPorcentaje).Text) Then
                                MsgBox("No se pueden tener diferentes porcentajes de IVA.", MsgBoxStyle.Exclamation, "ValidarOrdenCompra")
                                Exit Function
                            End If
                        End If
                    End If

                    bHayArticulos = True
                End If
            Next i

            If bHayArticulos = False Then
                MsgBox("Captúre el detalle del movimiento.", MsgBoxStyle.Exclamation, Me.Text)
                Exit Function
            End If

        Catch ex As Exception
            HandleError(Me.Name, "ValidarOrdenCompra", ex)
        End Try

        Return True
    End Function

    Private Function ValidarCompra() As Boolean
        Const sProcedure As String = "ValidarCompra"
        Try
            If Plaza.ValidarPeriodoTrabajo(Me.DtpFecha.Value) = False Then
                Return False
            End If

            If txtLEN(Me.txtFolioOC.Text) = False Then
                MsgBox("Asígne la orden de compra de referencia.", MsgBoxStyle.Exclamation, sProcedure)
                Me.txtFolioOC.Focus()
                Return False
            End If

            Me.oCompras = New Class_Compras_Global(Me.txtFolioOC.Text, Me.oCompras.ObtieneCodigoDocumentoOrdenCompra(Me.txtFolioOC.Text))

            If Me.oCompras.Existe = False Then
                MsgBox("Asígne una orden de compra válida.", MsgBoxStyle.Exclamation, sProcedure)
                Me.txtFolioOC.Focus()
                Return False
            End If

            Dim i As Integer
            For i = 1 To Grid.Rows - 1
                If txtLEN(Me.Grid.Cell(i, Me.igyCodigo).Text) = True Then
                    If Me.oCompras.ValidaCantidadDisponibleArticulo(CInt(Me.Grid.Cell(i, Me.igyIdArticulo).Text), CDbl(Me.Grid.Cell(i, Me.igyCantidad).Text)) = False Then
                        MsgBox("La cantidad debe de ser menor al disponible.", MsgBoxStyle.Exclamation, sProcedure)
                        Me.Grid.Cell(i, Me.igyCantidad).SetFocus()
                        Return False
                    End If
                End If
            Next i

            If Me.ValidaCuentasContables = False Then
                Return False
            End If

            'Esto esta contenido de mejor modo en ValidaCuentasContable
            'Dim oArticulos As Class_CatArticulos
            'For i = 1 To Me.Grid.Rows - 1
            '    If txtLEN(Me.Grid.Cell(i, Me.igyCodigo).Text) = True Then
            '        oArticulos = New Class_CatArticulos(Me.Grid.Cell(i, Me.igyCodigo).Text)
            '        If oArticulos.INVENTARIABLE = "0" Then
            '            If Mid(Me.Grid.Cell(i, Me.igyCuentaContable).Text, 1, 4) = Empresa_Sistema.CUENTA_CONTABLE_ALMACENES.ToString Then
            '                MsgBox("La cuenta para los artículos no inventariables no debe de empezar con " & Empresa_Sistema.CUENTA_CONTABLE_ALMACENES.ToString & "." & vbCrLf & _
            '                       "Revíse el renglón #" & i, MsgBoxStyle.Exclamation, Me.Text)
            '                Return False
            '            End If
            '            If Microsoft.VisualBasic.Left(Me.Grid.Cell(i, Me.igyCuentaContable).Text, 1) <> "1" Then
            '                MsgBox("La cuenta para los artículos no inventariables debe empezar con 1." & vbCrLf & _
            '                        "Revíse el renglón #" & i, MsgBoxStyle.Exclamation, Me.Text)
            '                Return False
            '            End If
            '        End If
            '    End If
            'Next

            'Nota aqui no se pregunta antes si hay rows en dtSeries, porque puede ser que no le hayan dado al botón, en la siguiente validación si.
            If Me.ValidaNumerosSerie = False Then
                Return False
            End If

            If IsNothing(Me.dtSeries) = False AndAlso Me.dtSeries.Rows.Count > 0 Then

                'NOTA: cuando sea false VALIDA_SERIES_REPETIDAS_EN_ENTRADAS no entrará a las dos validaciones internas debido a :
                'Sobre validar HaySeriesRepetidas - Es porque en vez de usar series usan lotes, ejemplo se le compra a x proveedor 50 kilos de x producto del lote rh-587, las 50 unidades deberán tener el mismo lote
                'Y sobre validar HaySeriesConExistenciasMismoArticulo - Al usar lotes es posible que en un compra pongan serie "2016", y en otra compra otra vez repitan "2016"( es más factible que se repitan entre diferentes compras)

                If Empresa_Sistema.VALIDA_SERIES_REPETIDAS_EN_ENTRADAS = True Then

                    If Me.HaySeriesRepetidas = True Then
                        Return False
                    End If

                    If Me.HaySeriesConExistenciasMismoArticulo = True Then
                        Return False
                    End If
                End If

            End If

            Return True

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try

    End Function

    Private Function Contabilizar() As Boolean
        Return True
    End Function

    Private Sub DesplegarDocumentos(Optional ByVal bAccesibileUsuarios As Boolean = True)
        Try
            With Me.CboDocumento
                .DisplayMember = "NOMBRE_TIPO_DOCUMENTO"
                .ValueMember = "CODIGO_DOCUMENTO"
                Dim dView As New Data.DataView(Me.oDocumento.ObtenerCodigosDocumentos(Me.oCompras.CODIGO_MODULO, Usuario.Codigo_Plaza.ToString, IIf(bAccesibileUsuarios = True, " ESTATUS_DOCUMENTO='A'  AND ACCESIBLE_USUARIO='1' ", " ESTATUS_DOCUMENTO='A' AND ACCESIBLE_USUARIO='0' ").ToString))
                dView.Sort = "NOMBRE_TIPO_DOCUMENTO DESC"
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

    Private Sub DesplegarMonedas()
        Dim oMoneda As New Class_CatMonedas
        Dim dTable As New DataTable

        With Me.cboMoneda
            .DisplayMember = "NOMBRE"
            .ValueMember = "CODIGO_MONEDA"
            dTable = oMoneda.ObtenerElementos
            dTable.Rows(2).Delete() 'Quita Euros del DataTable
            .DataSource = dTable
            .SelectedValue = 1
        End With
    End Sub

    Private Function Totales(Optional ByVal bIva As Boolean = False) As Boolean
        Dim bResultado As Boolean = False
        Try
            Dim i As Integer
            Dim dCantidad As Double, dPrecio As Double, dPorcentajeIVA As Double, dImporte As Double
            Dim dIEPS_PORCENTAJE As Double = 0, dIEPS_UNITARIO As Double = 0, dIEPS_IMPORTE As Double = 0, dBASE_IEPS As Double = 0, dBASE_IVA As Double = 0, dPRECIO_TOTAL As Double = 0, dIVA_IMPORTE As Double = 0

            Me.TxtSubTotal.Text = FormatImporteContable(0)
            Me.txtIEPS.Text = FormatImporteContable(0)
            'Me.txtIVA.Text = FormatImporteContable(0)
            Me.txtTotal.Text = FormatImporteContable(0)

            Me.TxtSubTotalUSD.Text = FormatImporteContable(0)
            Me.txtIVAUSD.Text = FormatImporteContable(0)
            Me.txtTotalUSD.Text = FormatImporteContable(0)

            For i = 1 To Me.Grid.Rows - 1
                If txtLEN(Me.Grid.Cell(i, Me.igyCantidad).Text) = True Then
                    dCantidad = valorNumerico(Me.Grid.Cell(i, Me.igyCantidad).Text)
                    dPrecio = valorNumerico(Me.Grid.Cell(i, Me.igyPrecio).Text)
                    dPorcentajeIVA = valorNumerico(Me.Grid.Cell(i, Me.igyImpuestoPorcentaje).Text)

                    dIEPS_PORCENTAJE = valorNumerico(Me.Grid.Cell(i, Me.igyIEPS_PORCENTAJE).Text)
                    dIEPS_UNITARIO = Redondear(dPrecio * (dIEPS_PORCENTAJE / 100), 4)
                    'dBASE_IEPS = Redondear((dPrecio * dCantidad), 2)
                    dBASE_IEPS = Redondear((dPrecio * dCantidad), 6)
                    dIEPS_IMPORTE = Redondear(dBASE_IEPS * (dIEPS_PORCENTAJE / 100), 2) 'De momento este no se paso a mas decimales, habra que revisar estructura y factibilidad
                    dBASE_IVA = dIEPS_IMPORTE + dBASE_IEPS
                    dIVA_IMPORTE = Redondear(dBASE_IVA * ((dPorcentajeIVA / 100)), 2)

                    dImporte = Redondear((dPrecio * dCantidad), Empresa_Sistema.DECIMALES_CONTABILIDAD) 'no hacemos nada con este valor de momento

                    Me.Grid.Cell(i, Me.igyImporte).Text = dImporte.ToString
                    Me.Grid.Cell(i, Me.igyIEPS_UNITARIO).Text = dIEPS_UNITARIO.ToString
                    Me.Grid.Cell(i, Me.igyBASE_IEPS).Text = dBASE_IEPS.ToString
                    Me.Grid.Cell(i, Me.igyIEPS_IMPORTE).Text = dIEPS_IMPORTE.ToString
                    Me.Grid.Cell(i, Me.igyBASE_IVA).Text = dBASE_IVA.ToString
                    Me.Grid.Cell(i, Me.igyImpuestoImporte).Text = dIVA_IMPORTE.ToString

                    'If dCantidad > 0 Then
                    '    dImporte = Redondear((dPrecio * dCantidad), Empresa_Sistema.DECIMALES_CONTABILIDAD)
                    '    Me.Grid.Cell(i, Me.igyImporte).Text = dImporte.ToString
                    '    Me.Grid.Cell(i, Me.igyImpuestoImporte).Text = Redondear(dImporte * ((dPorcentajeIVA / 100)), Empresa_Sistema.DECIMALES_CONTABILIDAD).ToString
                    'Else
                    '    Me.Grid.Cell(i, Me.igyImporte).Text = "0"
                    '    Me.Grid.Cell(i, Me.igyImpuestoImporte).Text = "0"
                    'End If
                End If
            Next i

            Me.TxtSubTotal.Text = FormatImporteContable(Redondear(FG_Grid_SumaCol(Me.Grid, Me.igyImporte), Empresa_Sistema.DECIMALES_CONTABILIDAD))

            Me.txtIEPS.Text = FormatImporteContable(Redondear(FG_Grid_SumaCol(Me.Grid, Me.igyIEPS_IMPORTE), Empresa_Sistema.DECIMALES_CONTABILIDAD))

            Me.lblIVAcalculado.Text = FormatImporteContable(Redondear(FG_Grid_SumaCol(Me.Grid, Me.igyImpuestoImporte), Empresa_Sistema.DECIMALES_CONTABILIDAD))
            'Me.txtIVA.Text = FormatImporteContable(Redondear(FG_Grid_SumaCol(Me.Grid, Me.igyImpuestoImporte), Empresa_Sistema.DECIMALES_CONTABILIDAD))

            'Se quitó de momento funcionalidad para poder editar el iva total a mano, hay que rediseñar solución. 24abr
            If bIva = False Then
                'If valorNumerico(Me.lblIVAcalculado.Text) > 0 And valorNumerico(Me.txtIVA.Text) = 0 Then
                Me.txtIVA.Text = FormatImporteContable(Redondear(FG_Grid_SumaCol(Me.Grid, Me.igyImpuestoImporte), Empresa_Sistema.DECIMALES_CONTABILIDAD))
            Else
                Me.txtIVA.Text = FormatImporteContable(valorNumerico(Me.txtIVA.Text))
                'ElseIf valorNumerico(Me.lblIVAcalculado.Text) <> valorNumerico(Me.txtIVA.Text) Then
                If valorNumerico(Me.txtIVA.Text) > valorNumerico(Me.lblIVAcalculado.Text) - 1 And valorNumerico(Me.txtIVA.Text) > valorNumerico(Me.lblIVAcalculado.Text) + 1 Then
                    MsgBox("El IVA asignado no es correcto, favor de verificar.", MsgBoxStyle.Exclamation, Me.Name)
                    Me.txtIVA.Focus()
                    Return False
                End If
                'End If
            End If

            Me.txtTotal.Text = FormatImporteContable((valorNumerico(Me.TxtSubTotal.Text) + valorNumerico(Me.txtIEPS.Text) + valorNumerico(Me.txtIVA.Text)) - valorNumerico(Me.TxtRetencion.Text))

            Me.TotalesUSD()

            bResultado = True

        Catch ex As Exception
            HandleError(Me.Name, "Totales", ex)
        End Try

        Return bResultado
    End Function

    Private Sub TotalesUSD()
        Try
            Dim dTipoCambio As Double = valorNumerico(Me.txtTipoCambio.Text)
            Dim dSubtotalUSD As Double = 0, dIVAUSD As Double = 0, dTotalUSD As Double = 0

            If dTipoCambio > 0 And Me.cboMoneda.SelectedIndex = 1 Then 'Si no esta chequeado en usd , no va entrar aqui y van a quedan en ceros(simulando que se inicilizaron)
                dSubtotalUSD = Redondear(valorNumerico(Me.TxtSubTotal.Text) / dTipoCambio, Empresa_Sistema.DECIMALES_CONTABILIDAD)
                dIVAUSD = Redondear(valorNumerico(Me.txtIVA.Text) / dTipoCambio, Empresa_Sistema.DECIMALES_CONTABILIDAD)
                dTotalUSD = Redondear(valorNumerico(Me.txtTotal.Text) / dTipoCambio, Empresa_Sistema.DECIMALES_CONTABILIDAD)
            End If

            Me.TxtSubTotalUSD.Text = FormatImporteContable(dSubtotalUSD)
            Me.txtIVAUSD.Text = FormatImporteContable(dIVAUSD)
            Me.txtTotalUSD.Text = FormatImporteContable(dTotalUSD)

        Catch ex As Exception
            HandleError(Me.Name, "TotalesUSD", ex)
        End Try
    End Sub

    Private Function GeneraFolio() As Boolean
        Try
            If Me.bDocumentosCargados = True Then
                Me.txtFolioCompra.Text = Me.oCompras.GeneraFolio
            End If
            Return txtLEN(Me.txtFolioCompra.Text)
        Catch ex As Exception
            HandleError(Me.Name, "TotalesUSD", ex)
        End Try
    End Function

    Private Sub GestionaGrid(ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            Dim Columna As Integer, Renglon As Integer
            Dim StrCod As String, sCuentaContable As String, dCantidad As Double, dPrecio As Double
            Dim oArticulo As Class_CatArticulos
            Dim oCuentas As New Class_CatCuentas 'Class_VWCatDeudoresDiversos

            If Me.oDocumento.AFECTA_CXP = True And Me.Grid.Selection.FirstRow = Me.Grid.Rows - 1 Then
                Exit Sub
            End If

            Columna = Me.Grid.Selection.FirstCol
            Renglon = Me.Grid.Selection.FirstRow
            StrCod = Me.Grid.Cell(Renglon, Me.igyCodigo).Text
            dCantidad = valorNumerico(Me.Grid.Cell(Renglon, Me.igyCantidad).Text)
            dPrecio = valorNumerico(Me.Grid.Cell(Renglon, Me.igyPrecio).Text)

            'ESTA VALIDACION SE PUSO PARA QUE A LOS ARTICULOS INVENTARIABLES NO LES PUEDAN CAMBIAR LA CUENTA CONTABLE CALCULADA AUTOMATICAMENTE
            If Columna = Me.igyCuentaContable Then
                oArticulo = New Class_CatArticulos(StrCod)
                If oArticulo.INVENTARIABLE = "1" Then
                    e.SuppressKeyPress = True
                    Exit Sub
                End If
            End If

            Select Case e.KeyCode
                Case Keys.Enter

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

                            If StrCod = Empresa_Sistema.CODIGO_ARTICULO_NO_INVENTARIABLE_COMPRA_PROVEEDOR Then
                                Me.Grid.Cell(Renglon, Me.igyDescripcion).Text = ""
                                Me.Grid.Cell(Renglon, Me.igyCantidad).Text = "0"
                                Me.Grid.Cell(Renglon, Me.igyPrecio).Text = "0"
                                Me.Grid.Cell(Renglon, Me.igyUnidad).Text = "PZA"
                                Me.Grid.Cell(Renglon, Me.igyImpuestoPorcentaje).Text = "0"

                                Me.Grid.Column(Me.igyDescripcion).Locked = False
                                Me.Grid.Column(Me.igyUnidad).Locked = False
                            Else
                                If oArticulo.Existe = True Then
                                    Me.Grid.Cell(Renglon, Me.igyDescripcion).Text = oArticulo.DESCRIPCION
                                    Me.Grid.Cell(Renglon, Me.igyCantidad).Text = "0"
                                    Me.Grid.Cell(Renglon, Me.igyPrecio).Text = "0" 'traer el ultimo precio del mismo proveedor y mismo articulo"
                                    Me.Grid.Cell(Renglon, Me.igyUnidad).Text = oArticulo.UNIDAD_VENTA

                                    'If oArticulos.TIENE_IMPUESTO = "1" Then
                                    '    Me.Grid.Cell(Renglon, Me.igyImpuestoPorcentaje).Text = Plaza.Impuesto_Porcentaje.ToString
                                    'Else
                                    '    Me.Grid.Cell(Renglon, Me.igyImpuestoPorcentaje).Text = "0"
                                    'End If
                                    Me.Grid.Cell(Renglon, Me.igyImpuestoPorcentaje).Text = oArticulo.IMPUESTO_PORCENTAJE.ToString

                                    Me.Grid.Column(Me.igyDescripcion).Locked = True
                                    Me.Grid.Column(Me.igyUnidad).Locked = True

                                    Me.Grid.Cell(Renglon, Me.igyIEPS_PORCENTAJE).Text = oArticulo.IEPS_PORCENTAJE.ToString
                                End If
                            End If

                            Me.Totales()

                        Case Me.igyCantidad
                            If dCantidad <= 0 Then
                                MsgBox("La cantidad debe de ser mayor a 0.", MsgBoxStyle.Exclamation, Me.Text)
                                Me.Grid.Cell(Renglon, Me.igyCantidad).SetFocus()
                                Exit Sub
                            End If

                            If Me.oDocumento.AFECTA_CXP = True Then
                                If Me.oCompras.ValidaCantidadDisponibleArticulo(CInt(Me.Grid.Cell(Renglon, Me.igyIdArticulo).Text), dCantidad) = False Then
                                    MsgBox("La cantidad debe de ser menor al disponible.", MsgBoxStyle.Exclamation, Me.Text)
                                    Me.Grid.Cell(Renglon, Me.igyCantidad).Text = Me.oCompras.ObtenerDisponibleArticulo(CInt(Me.Grid.Cell(Renglon, Me.igyIdArticulo).Text)).ToString
                                    Me.Grid.Refresh()
                                    Exit Sub
                                End If
                            End If

                        Case Me.igyPrecio
                            If dPrecio <= 0 Then
                                MsgBox("El precio debe de ser mayor a 0.", MsgBoxStyle.Exclamation, Me.Text)
                                Me.Grid.Cell(Renglon, Me.igyPrecio).SetFocus()
                            End If

                        Case Me.igyImpuestoPorcentaje
                            Me.Totales()

                        Case Me.igyCuentaContable 'Enter
                            'oCuentas = New Class_VWCatDeudoresDiversos(Me.Grid.Cell(Renglon, Me.igyCuentaContable).Text) ' Class_CatCuentas(Me.Grid.Cell(Renglon, Me.igyCuentaContable).Text)

                            sCuentaContable = Me.Grid.Cell(Renglon, Me.igyCuentaContable).Text

                            If sCuentaContable.StartsWith("1") = False Then
                                Me.Grid.Cell(Renglon, Me.igyCuentaContable).Text = ""
                                Me.Grid.Cell(Renglon, Me.iGyNombreCuentaContable).Text = ""
                                MsgBox("La cuenta contable del renglón : " & Renglon & " debe ser del rango de las miles(que empiezen con 1).", MsgBoxStyle.Exclamation, Me.Name)
                                Return
                            End If

                            oCuentas = New Class_CatCuentas(sCuentaContable)

                            If oCuentas._Existe = True Then
                                Me.Grid.Cell(Renglon, Me.igyCuentaContable).Text = oCuentas.CUENTA_CONTABLE
                                Me.Grid.Cell(Renglon, Me.iGyNombreCuentaContable).Text = oCuentas.NOMBRE_CUENTA
                            Else
                                Me.Grid.Cell(Renglon, Me.igyCuentaContable).Text = ""
                                Me.Grid.Cell(Renglon, Me.iGyNombreCuentaContable).Text = ""
                                GoTo BuscarCuentas : Exit Sub
                            End If

                            Me.Grid.Cell(Renglon + 1, Me.igyImporte).SetFocus()

                    End Select

                    Select Case Columna
                        Case Me.igyImpuestoPorcentaje
                            If Me.Grid.Rows = Renglon + 1 Then Me.Grid.Rows = Me.Grid.Rows + 1
                            Me.Grid.Cell(Renglon + 1, Me.iGyIDAdicional).Text = (valorNumerico(Me.Grid.Cell(Renglon, Me.iGyIDAdicional).Text) + 1).ToString
                    End Select

                    Me.Totales(True)

                Case Keys.F2
                    Me.Grid.Cell(Renglon, Me.igyCodigo).Text = Empresa_Sistema.CODIGO_ARTICULO_NO_INVENTARIABLE_COMPRA_PROVEEDOR

                Case Keys.F6, Keys.F7
BuscaArticulos:
                    Select Case Columna
                        Case Me.igyCodigo
                            If e.KeyCode = Keys.F6 Then
                                oArticulo = New Class_CatArticulos
                                StrCod = oArticulo.BusquedaVisualInventariables_PorDescripcion()
                                If txtLEN(StrCod) = True Then
                                    Me.Grid.Cell(Renglon, Me.igyCodigo).Text = StrCod
                                    GoTo LlenaLinea
                                End If
                            End If
                        Case Me.igyCuentaContable
BuscarCuentas:
                            oArticulo = New Class_CatArticulos(Me.Grid.Cell(Renglon, Me.igyCodigo).Text)

                            If e.KeyCode = Keys.F6 Then
                                sCuentaContable = oCuentas.BusquedaVisual_PorCodigoConLike("1") '.BusquedaVisual_PorCodigoFiltrandoTipoOperacion()
                            Else
                                sCuentaContable = oCuentas.BusquedaVisual_PorDescripcionConLike("1") 'f7
                            End If

                            If sCuentaContable = "" Then
                                Return
                            End If

                            If oArticulo.INVENTARIABLE = "0" Then
                                If Mid(sCuentaContable, 1, 4) = Empresa_Sistema.CUENTA_CONTABLE_ALMACENES.ToString Then
                                    MsgBox("La cuenta para los artículos no inventariables no deben de empezar con " & Empresa_Sistema.CUENTA_CONTABLE_ALMACENES.ToString & ".", MsgBoxStyle.Exclamation, Me.Text)
                                    Return
                                End If
                            End If

                            'oCuentas = New Class_VWCatDeudoresDiversos(sCuentaContable)
                            oCuentas = New Class_CatCuentas(sCuentaContable)
                            Me.Grid.Cell(Renglon, Me.igyCuentaContable).Text = oCuentas.CUENTA_CONTABLE
                            Me.Grid.Cell(Renglon, Me.iGyNombreCuentaContable).Text = oCuentas.NOMBRE_CUENTA

                    End Select

                    'Case Keys.F7
                    'BuscarCuentas:
                    '                    sCuentaContable = Me.oCuentas.BusquedaVisual_PorNombreFiltrandoTipoOperacion()
                    '                    If sCuentaContable = "" Then
                    '                        Me.Grid.Cell(Renglon, Me.igyCuentaContable).Text = ""
                    '                        Me.Grid.Refresh()
                    '                        Exit Sub
                    '                    End If

                    '                    oArticulos = New Class_CatArticulos(Me.Grid.Cell(Renglon, Me.igyCodigo).Text)

                    '                    If oArticulos.INVENTARIABLE = "0" Then
                    '                        If Mid(sCuentaContable, 1, 4) = Empresa_Sistema.CUENTA_CONTABLE_ALMACENES.ToString Then
                    '                            MsgBox("La cuenta para los artículos no inventariables no deben de empezar con " & Empresa_Sistema.CUENTA_CONTABLE_ALMACENES.ToString & ".", MsgBoxStyle.Exclamation, Me.Text)
                    '                            Exit Sub
                    '                        End If
                    '                    End If

                    '                    Me.Grid.Cell(Renglon, Me.igyCuentaContable).Text = sCuentaContable

                Case Keys.F8, Keys.Delete
                    If (Me.Estado = enumEstados.NUEVO Or Me.Estado = enumEstados.GRABADO) Then
                        Dim IDAdicional As Integer = CInt(Me.Grid.Cell(Renglon, Me.iGyIDAdicional).Text)

                        'MsgBox(Me.Grid.Rows.ToString)
                        Me.Grid.Selection.DeleteByRow()
                        'MsgBox(Me.Grid.Rows.ToString)
                        Me.Totales()

                        Me.EliminaDetalleCuentasContables(IDAdicional)
                    End If
            End Select

        Catch ex As Exception
            HandleError(Me.Name, "GestionaGrid", ex)
        End Try
    End Sub

    Private Sub OcultarControles()
        If Me.oDocumento.AFECTA_CXP = True Then
            Me.txtFolioOC.Visible = True : Me.lblDisplayFolioOC.Visible = True
            Me.txtFolioProveedor.Visible = True : Me.lblDisplayFolioProveedor.Visible = True
            Me.txtSaldoMXP.Visible = True : Me.lblDisplaySaldoMXP.Visible = True
            Me.txtSaldoUSD.Visible = True : Me.lblDisplaySaldoUSD.Visible = True
            Me.BtnActualizaFolioProv.Visible = True
            Me.btnActualizaConcepto.Visible = True

            If Me.Grid.Cols > 1 Then
                Me.Grid.Column(Me.igyCuentaContable).Visible = True
            End If
            Me.tsbGrabar.Visible = False
            Me.tsbAplicar.Visible = True
            Me.tpSeries.Enabled = True
        Else
            Me.txtFolioOC.Visible = False : Me.lblDisplayFolioOC.Visible = False
            Me.txtFolioProveedor.Visible = False : Me.lblDisplayFolioProveedor.Visible = False
            Me.txtSaldoMXP.Visible = False : Me.lblDisplaySaldoMXP.Visible = False
            Me.txtSaldoUSD.Visible = False : Me.lblDisplaySaldoUSD.Visible = False
            Me.BtnActualizaFolioProv.Visible = False
            Me.btnActualizaConcepto.Visible = False

            If Me.Grid.Cols > 1 Then
                Me.Grid.Column(Me.igyCuentaContable).Visible = False
            End If
            Me.tsbGrabar.Visible = True
            Me.tsbAplicar.Visible = False
            Me.tpSeries.Enabled = False
        End If
    End Sub

    Private Function SiTieneCuentaContable() As Boolean
        Dim i As Integer
        For i = 1 To Me.Grid.Rows - 1
            If txtLEN(Me.Grid.Cell(i, Me.igyCodigo).Text) = True Then
                If txtLEN(Me.Grid.Cell(i, Me.igyCuentaContable).Text) = False Then
                    SiTieneCuentaContable = False
                    Exit Function
                End If
            End If
        Next
        Return True
    End Function

    Private Function ValidaCuentasContables() As Boolean
        Dim bResultado As Boolean = False
        Const sProcedure As String = "ValidaCuentasContables"
        Dim i As Integer, sCuentaContable As String = ""
        Try
            Dim oCuentas As New Class_CatCuentas

            For i = 1 To Me.Grid.Rows - 1
                If txtLEN(Me.Grid.Cell(i, Me.igyCodigo).Text) = True Then

                    Dim oArticulo As New Class_CatArticulos(Me.Grid.Cell(i, Me.igyCodigo).Text)

                    sCuentaContable = Me.Grid.Cell(i, Me.igyCuentaContable).Text

                    If oArticulo.INVENTARIABLE = "0" Then
                        If txtLEN(sCuentaContable) = True Then

                            If Not (IsNothing(Me.oFormaDetalleCuentas) = True) Then

                                If Me.oFormaDetalleCuentas.ValidaCuentaTengaDetalle(CInt(Me.Grid.Cell(i, Me.iGyIDAdicional).Text)) = True Then
                                    MsgBox("El renglón : " & i & " tiene cuenta directa y detalle de cuentas, no puede tener ambos.", MsgBoxStyle.Exclamation, sProcedure)
                                    Return False
                                End If

                            End If

                            'MsgBox("Quite la cuenta contable del renglón #" & i & " , no se puede tener cuenta directa y también en detalle(la que se establece con el botón)." & vbCrLf & _
                            '       "Revíse el renglón #" & i, MsgBoxStyle.Exclamation, sProcedure)
                            'Return False

                            'Dim oDeudor As New Class_VWCatDeudoresDiversos(sCuentaContable)
                            'If oDeudor.EXISTE = False Then
                            '    MsgBox("El renglón : " & i & " tiene un deudor que no existe.", MsgBoxStyle.Exclamation, sProcedure)
                            '    Return False
                            'End If

                            If sCuentaContable.StartsWith("1") = False Then
                                MsgBox("La cuenta contable del renglón : " & i & " debe ser del rango de las miles(que empiezen con 1)." & vbCrLf & _
                                "O debe en vez de poner cuenta, detallar con el botón de centros de costos.", MsgBoxStyle.Exclamation, Me.Name)
                                Return False
                            End If

                            oCuentas = New Class_CatCuentas(sCuentaContable)

                            If oCuentas._Existe = False Then
                                MsgBox("La cuenta contable del renglón : " & i & " no existe.", MsgBoxStyle.Exclamation, sProcedure)
                                Return False
                            Else
                                If oCuentas.ESMAYOR = "1" Then
                                    MsgBox("La cuenta contable del renglón : " & i & " es de mayor.", MsgBoxStyle.Exclamation, sProcedure)
                                    Return False
                                End If
                                'If (Me.Grid.Cell(i, Me.igyCuentaContable).Text Like Empresa_Sistema.CUENTA_CONTABLE_ALMACENES & "*") = False Then
                                '    MsgBox("La cuenta para los artículos inventariables debe de empezar con " & Empresa_Sistema.CUENTA_CONTABLE_ALMACENES & "." & vbCrLf & _
                                '           "Revíse el renglón #" & i, MsgBoxStyle.Exclamation, Me.Text)
                                '    Return False
                                'End If
                            End If

                        Else

                            If IsNothing(Me.oFormaDetalleCuentas) = True Then
                                MsgBox("No ha especificado el detalle de la cuentas contables con el botón." & vbCrLf & _
                                       "Revíse el renglón #" & i, MsgBoxStyle.Exclamation, sProcedure)
                                Return False
                            End If

                            If Me.oFormaDetalleCuentas.ValidaCuentaTengaDetalle(CInt(Me.Grid.Cell(i, Me.iGyIDAdicional).Text)) = False Then
                                MsgBox("No ha especificado el detalle de la cuentas contables con el botón." & vbCrLf & _
                                       "Revíse el renglón #" & i, MsgBoxStyle.Exclamation, sProcedure)
                                Return False
                            End If
                        End If


                    Else 'Si es inventariable

                        If sCuentaContable.StartsWith("1") = False Then
                            MsgBox("La cuenta contable del renglón : " & i & " debe ser del rango de las miles(que empiezen con 1)." & vbCrLf & _
                            "O debe en vez de poner cuenta, detallar con el botón de centros de costos.", MsgBoxStyle.Exclamation, Me.Name)
                            Return False
                        End If

                        oCuentas = New Class_CatCuentas(sCuentaContable)

                        If oCuentas._Existe = False Then
                            MsgBox("La cuenta contable del renglón : " & i & " no existe.", MsgBoxStyle.Exclamation, sProcedure)
                            Return False
                        ElseIf oCuentas.ESMAYOR = "1" Then
                            MsgBox("La cuenta contable del renglón : " & i & " es de mayor.", MsgBoxStyle.Exclamation, sProcedure)
                            Return False
                        ElseIf (Me.Grid.Cell(i, Me.igyCuentaContable).Text Like Empresa_Sistema.CUENTA_CONTABLE_ALMACENES & "*") = False Then
                            MsgBox("La cuenta para los artículos inventariables debe de empezar con " & Empresa_Sistema.CUENTA_CONTABLE_ALMACENES & "." & vbCrLf & _
                                   "Revíse el renglón #" & i, MsgBoxStyle.Exclamation, Me.Text)
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

    Private Function EstableceCuentaContableAlmacenDestino() As Boolean
        Try
            Dim oAlmacenes As New Class_CatAlmacenes(Me.CboAlmacen.SelectedValue.ToString), i As Integer, sCuentaContable As String = "", oCuenta As Class_CatCuentas
            Dim oArticulos As Class_CatArticulos

            For i = 1 To Me.Grid.Rows - 1
                If txtLEN(Me.Grid.Cell(i, Me.igyCodigo).Text) = True Then
                    oArticulos = New Class_CatArticulos(Me.Grid.Cell(i, Me.igyCodigo).Text)
                    If oArticulos.INVENTARIABLE = "1" Then
                        sCuentaContable = oAlmacenes.Cuenta_Contable.ToString + oArticulos.ObtenerFamiliaArticulo(Me.Grid.Cell(i, Me.igyCodigo).Text).ToString
                        oCuenta = New Class_CatCuentas(sCuentaContable)

                        Me.Grid.Cell(i, Me.igyCuentaContable).Text = sCuentaContable
                        If oCuenta._Existe = True Then
                            Me.Grid.Cell(i, Me.iGyNombreCuentaContable).Text = oCuenta.NOMBRE_CUENTA
                        Else
                            Me.Grid.Cell(i, Me.iGyNombreCuentaContable).Text = ""
                        End If

                    End If
                End If
            Next

            Return True
        Catch ex As Exception
            HandleError(Me.Name, "EstableceCuentaContableAlmacenDestino", ex)
        End Try
    End Function

    Private Function Navegador(ByVal sTipoDeBusqueda As String) As Boolean
        Dim bResultado As Boolean = False
        Try
            Dim iFolio As Integer, sFolio As String, iPosicion As Integer, sFolioParte2 As String
            If txtLEN(Me.txtFolioCompra.Text) = False Then
                If GeneraFolio() = False OrElse txtLEN(Me.txtFolioCompra.Text) = False Then
                    Exit Function
                End If
            End If

            If sTipoDeBusqueda = "Anterior" Then
                iPosicion = Me.txtFolioCompra.Text.IndexOf("-")
                sFolio = Me.txtFolioCompra.Text.Substring(0, iPosicion)
                iFolio = CInt(Strings.Right(Me.txtFolioCompra.Text, Len(Me.txtFolioCompra.Text) - (Len(sFolio) + 1))) ' Me.oVenta.FOLIO_NUMERICO
                iFolio = iFolio - 1
                sFolioParte2 = Format(iFolio, New String(CChar("0"), Me.txtFolioCompra.Text.Substring(3, Me.txtFolioCompra.TextLength - iPosicion - 1).Length))
                sFolio = sFolio + "-" + sFolioParte2 'sFolio + "-" + iFolio.ToString
                Me.txtFolioCompra.Text = sFolio

                If txtLEN(sFolio) = True Then
                    Me.Consultar()
                Else
                    Me.Inicializa()
                    Me.Cambia_Estado(enumEstados.NUEVO)
                    Me.GeneraFolio()
                    Me.txtFolioCompra.Focus()
                End If

            ElseIf sTipoDeBusqueda = "Siguiente" Then
                iPosicion = Me.txtFolioCompra.Text.IndexOf("-")
                sFolio = Me.txtFolioCompra.Text.Substring(0, iPosicion)
                iFolio = CInt(Strings.Right(Me.txtFolioCompra.Text, Len(Me.txtFolioCompra.Text) - (Len(sFolio) + 1))) ' Me.oVenta.FOLIO_NUMERICO
                iFolio = iFolio + 1
                sFolioParte2 = Format(iFolio, New String(CChar("0"), Me.txtFolioCompra.Text.Substring(3, Me.txtFolioCompra.TextLength - iPosicion - 1).Length))
                sFolio = sFolio + "-" + sFolioParte2 'sFolio + "-" + iFolio.ToString
                Me.txtFolioCompra.Text = sFolio

                If txtLEN(sFolio) = True Then
                    Me.Consultar()
                Else
                    Me.Inicializa()
                    Me.Cambia_Estado(enumEstados.NUEVO)
                    Me.GeneraFolio()
                    Me.txtFolioCompra.Focus()
                End If
            End If

            bResultado = True
        Catch ex As Exception
            HandleError(Me.Name, "Navegador", ex)
        End Try

        Return bResultado
    End Function

    Private Sub PasarOrdenACompra()
        Dim sFolioOC As String = Me.txtFolioCompra.Text
        Try
            Me.Inicializa()
            Me.CboDocumento.SelectedValue = "CO" & Usuario.Codigo_Plaza.ToString
            Me.Cambia_Estado(enumEstados.NUEVO)
            Me.txtFolioOC.Text = sFolioOC
            Me.Consultar(True)
        Catch ex As Exception
            HandleError(Me.Name, "PasarOrdenACompra", ex)
        End Try
    End Sub

    Private Sub GestionaDetalleCuentas()
        Dim iRenglon As Integer = 0, sArticulo As String = ""
        Try
            iRenglon = Me.Grid.ActiveCell.Row
            sArticulo = Me.Grid.Cell(iRenglon, Me.igyCodigo).Text

            If txtLEN(sArticulo) = False Then
                MsgBox("No ha capturado el artículo.", MsgBoxStyle.Exclamation, Me.Text)
                Return
            End If

            If valorNumerico(Me.Grid.Cell(iRenglon, Me.igyImporte).Text) = 0 Then
                MsgBox("No ha capturado el artículo con su cantidad y precio.", MsgBoxStyle.Exclamation, Me.Text)
                Return
            End If

            Dim oArticulos As New Class_CatArticulos(sArticulo)

            If oArticulos.INVENTARIABLE = "1" Then
                MsgBox("El artículo es inventariable, la cuenta contable se calcula automáticamente.", MsgBoxStyle.Exclamation, Me.Text)
                Return
            End If

            'Solo si esta vacia la crea, para que siga existiendo en memoria ( con hide se oculta en la forma secundaria, para seguir trabajando con ella al volver el control a esta forma)
            If IsNothing(Me.oFormaDetalleCuentas) = True Then
                Me.oFormaDetalleCuentas = New InventariosDetalleCuentasContables(Me.txtFolioCompra.Text)
            End If

            With Me.oFormaDetalleCuentas
                .IDAdicional = CInt(Me.Grid.Cell(iRenglon, Me.iGyIDAdicional).Text) 'iRenglon
                .Importe = valorNumerico(Me.Grid.Cell(iRenglon, Me.igyImporte).Text)
                .txtArticulo.Text = Me.Grid.Cell(iRenglon, Me.igyDescripcion).Text
                .txtCantidad.Text = Me.Grid.Cell(iRenglon, Me.igyCantidad).Text
                .txtCosto.Text = Me.Grid.Cell(iRenglon, Me.igyPrecio).Text
                .txtImporte.Text = FormatImporteContable(.Importe, False)
                .CodigoArticulo = Me.Grid.Cell(iRenglon, Me.igyCodigo).Text
                .ShowDialog()

                'If .TieneDetalleCuentas = True Then
                'If .GestionoRenglon = True Then
                If .ValidaCuentaTengaDetalle(.IDAdicional) Then
                    Me.Grid.Cell(iRenglon, Me.igyCuentaContable).Text = ""
                    Me.Grid.Cell(iRenglon, Me.iGyNombreCuentaContable).Text = "Tiene detalle -->>"
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "GestionaDetalleCuentas", ex)
        End Try
    End Sub

    Private Function EliminaDetalleCuentasContables(ByVal IDAdicional As Integer) As Integer
        Try
            If IsNothing(Me.oFormaDetalleCuentas) = False Then 'Si no esta vacia, osea si existe
                Me.oFormaDetalleCuentas.EliminaRelacion(IDAdicional)
            End If
        Catch ex As Exception
            HandleError(Me.Name, "EliminaDetalleCuentasContables", ex)
        End Try
    End Function

    Private Function ActualizaConcepto() As Boolean
        Try
            If Usuario.ValidaPermisoUsuarioDocumentoConAfectacionInventarios(Me.CboDocumento.SelectedValue.ToString, Me.CboAlmacen.SelectedValue.ToString) = False Then
                MsgBox("El usuario " & Usuario.Nombre_Usuario & " no tiene permiso para realizar el movimiento.", MsgBoxStyle.Information, Me.Text)
                Exit Function
            End If

            Dim sConcepto As String
            sConcepto = InputBox("Proporcione el nuevo concepto de la compra", "Concepto de compra")
            If String.IsNullOrEmpty(sConcepto) Then
                Exit Function
            Else
                Me.oCompras.CONCEPTO = sConcepto.ToUpper
                If Me.oCompras.ActualizaConcepto = True Then
                    MsgBox("Concepto actualizado satisfactoramente.", MsgBoxStyle.Information, Me.Text)
                    Me.TxtConcepto.Text = Me.oCompras.CONCEPTO
                End If
            End If

            Return True

        Catch ex As Exception
            HandleError(Me.Name, "ActualizaConcepto", ex)
        End Try
    End Function

    Private Sub PrepararSeries()
        Try
            'Dim iUnidades As Integer

            If IsNothing(Me.dtSeries) = False AndAlso Me.dtSeries.Rows.Count > 0 Then
                If MsgBox("Hay series ya especificadas, si continua tendrá que recapturar todas." & vbCrLf & "Esta seguro de continuar ?", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    Return
                End If
            End If

            Me.dtSeries = New DataTable("Series")
            With Me.dtSeries
                .Columns.Add("POSICION", GetType(String))
                .Columns.Add("CODIGO_ARTICULO", GetType(String))
                .Columns.Add("DESCRIPCION", GetType(String))
                .Columns.Add("NUMERO_SERIE", GetType(String))
            End With
            Me.dtSeries.AcceptChanges()

            Dim dRow As DataRow

            For i = 1 To Me.Grid.Rows - 1
                If txtLEN(Me.Grid.Cell(i, Me.igyCodigo).Text) = True AndAlso CInt(Me.Grid.Cell(i, Me.igyCantidad).Text) > 0 Then
                    Dim oArticulo As New Class_CatArticulos(Me.Grid.Cell(i, Me.igyCodigo).Text)
                    If oArticulo.Existe = True AndAlso oArticulo.ES_SERIALIZABLE = True AndAlso oArticulo.INVENTARIABLE = "1" Then
                        For j = 1 To CInt(Me.Grid.Cell(i, Me.igyCantidad).Text)
                            dRow = Me.dtSeries.NewRow

                            dRow("POSICION") = i
                            dRow("CODIGO_ARTICULO") = Me.Grid.Cell(i, Me.igyCodigo).Text
                            dRow("DESCRIPCION") = Me.Grid.Cell(i, Me.igyDescripcion).Text
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
            Me.GridSeries.Cols = 5
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
                .Column(Me.igySerieCodigo).Width = 150
                .Column(Me.igySerieDescripcion).Width = 500
                .Column(Me.igySerieNumeroSerie).Width = 250

                .Cell(0, Me.igySeriePosicion).Text = "Posición"
                .Cell(0, Me.igySerieCodigo).Text = "Código"
                .Cell(0, Me.igySerieDescripcion).Text = "Descripción"
                .Cell(0, Me.igySerieNumeroSerie).Text = "Número de serie"

                .Column(Me.igySeriePosicion).Locked = True
                .Column(Me.igySerieCodigo).Locked = True
                .Column(Me.igySerieDescripcion).Locked = True

                .AutoRedraw = True
                .Refresh()

                .Row(.Rows - 1).Locked = True 'Para bloquear la edición del último renglón
            End With
        Catch ex As Exception
            HandleError(Me.Name, "FormateaGridSeries", ex)
        End Try
    End Sub

    Private Sub GestionaGridSeries(ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            Dim Renglon As Integer = Me.GridSeries.Selection.FirstRow
            Dim Columna As Integer = Me.GridSeries.Selection.FirstCol
            Select Case e.KeyCode
                Case Keys.Return
                    If Columna = Me.igySerieNumeroSerie Then
                        If Renglon + 1 < Me.GridSeries.Rows Then
                            Me.GridSeries.Cell(Renglon + 1, Me.igySerieDescripcion).SetFocus()
                        Else
                            Me.GridSeries.Cell(1, Me.igySerieDescripcion).SetFocus()
                        End If
                    End If

                Case Keys.Delete
                    e.SuppressKeyPress = True
            End Select
        Catch ex As Exception
            HandleError(Me.Name, "GestionaGridSeries", ex)
        End Try
    End Sub

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
                If txtLEN(Me.Grid.Cell(i, Me.igyCodigo).Text) = True AndAlso CInt(Me.Grid.Cell(i, Me.igyCantidad).Text) > 0 Then
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

    Private Function CantidadArticulosSerie(ByVal sCodigoArticulo As String) As Integer
        Dim iArticulosEncontrados As Integer = 0
        Try
            For i = 1 To Me.GridSeries.Rows - 1
                If Me.GridSeries.Cell(i, Me.igySerieCodigo).Text = sCodigoArticulo Then
                    iArticulosEncontrados += 1
                End If
            Next
        Catch ex As Exception
            HandleError(Me.Name, "CantidadArticulosSerie", ex)
        End Try
        Return iArticulosEncontrados
    End Function

    Private Function GestionaArchivoSeries() As Boolean
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
                Me.tpSeries.Focus()
                Return False
            End If

            sRutaArchivo = Me.Seleccionar

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
            HandleError(Me.Name, "GestionaArchivoSeries", ex)
        End Try

        Return bResultado
    End Function

    Private Function Seleccionar() As String
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
            HandleError(Me.Name, "Seleccionar", ex)
        End Try
        Return sRutaArchivo
    End Function

    Private Function HaySeriesRepetidas() As Boolean
        Dim RenglonRepetido As Integer

        Try
            Me.dtSeries.AcceptChanges()

            For i = 1 To Me.GridSeries.Rows - 1
                If txtLEN(Me.GridSeries.Cell(i, Me.igySerieCodigo).Text) = True Then
                    For z = i + 1 To Me.GridSeries.Rows - 1
                        If Me.GridSeries.Cell(i, Me.igySerieNumeroSerie).Text = Me.GridSeries.Cell(z, Me.igySerieNumeroSerie).Text Then
                            RenglonRepetido = z

                            MsgBox("La serie " & Me.GridSeries.Cell(RenglonRepetido, igySerieNumeroSerie).Text & _
                                   " del artículo " & Me.GridSeries.Cell(RenglonRepetido, igySerieCodigo).Text & " esta repetida en el renglón " & RenglonRepetido & "." & vbCrLf & _
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

    Private Function HaySeriesConExistenciasMismoArticulo() As Boolean
        Dim bResultado As Boolean = False, sListaSeries As String = ""
        Try
            'Me.GridSeries.AutoValidate = Windows.Forms.AutoValidate.EnablePreventFocusChange

            If Me.dtSeries.Rows.Count > 0 Then
                For Each dRow In Me.dtSeries.Select("")
                    sListaSeries = sListaSeries & dRow("CODIGO_ARTICULO").ToString & "," & dRow("NUMERO_SERIE").ToString & "|"
                Next
                If txtLEN(sListaSeries) = True Then
                    sListaSeries = sListaSeries.Substring(0, sListaSeries.Length - 1) 'Para quitarle el último pipe que sale sobrando.
                End If

                Dim sResultado As String = Me.oCompras.HaySeriesConExistenciasMismoArticulo(sListaSeries)

                If txtLEN(sResultado) = True Then
                    MsgBox("Hay existencias con las mismas series de los siguientes artículos : " & vbCrLf & sResultado, vbExclamation, Me.Text)
                    Return True
                End If

            End If
        Catch ex As Exception
            HandleError(Me.Name, "HaySeriesConExistenciasMismoArticulo", ex)
        End Try

        Return False
    End Function

    Private Sub CopiarLote()
        Dim sProcedure As String = "CopiarLote"
        Try
            If Me.GridSeries.ActiveCell.Row <= 0 Then
                MsgBox("Debe seleccionar un renglón para copiarle este lote a todos los artículos iguales al seleccionado.", MsgBoxStyle.Exclamation, sProcedure)
                Return
            End If

            Dim sArticulo As String = Me.GridSeries.Cell(Me.GridSeries.ActiveCell.Row, Me.igySerieCodigo).Text

            For i = 1 To Me.GridSeries.Rows - 1
                If Me.GridSeries.Cell(i, Me.igySerieCodigo).Text = sArticulo Then
                    Me.GridSeries.Cell(i, igySerieNumeroSerie).Text = Me.txtLote.Text
                End If
            Next

            MsgBox("Listo", MsgBoxStyle.Information, sProcedure)
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

#End Region
End Class