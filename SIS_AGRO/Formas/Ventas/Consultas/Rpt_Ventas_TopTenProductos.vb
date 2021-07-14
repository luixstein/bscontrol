Option Strict On

Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class Rpt_Ventas_TopTenProductos
    Private oClientes As New Class_CatClientes

#Region "Columnas grid productos"
    Private igyCodigo As Short = 1
    Private igyDescripcion As Short = 2
    Private igyCantidad As Short = 3
    Private igyVenta As Short = 4
    Private igyCosto As Short = 5
    Private igyUtilidad As Short = 6
    Private igyP_Utilidad As Short = 7
    Private igyPrecioUnitario As Short = 8
    Private igyCostoUnitario As Short = 9
    Private igyUtilidadUnitaria As Short = 10
    Private igyParticipacionUtilidad As Short = 11
    Private igyAcumuladoUtilidad As Short = 12
    Private igyParticipacionVenta As Short = 13
    Private igyAcumuladoVenta As Short = 14
    'Private igyUtilidadBruta As Short = 15
    'Private igyUtilidadBrutaPorcentaje As Short = 16
#End Region

#Region "Columnas grid clientes"
    Private igyPTCCodigo As Short = 1
    Private igyPTCDescripcion As Short = 2
    Private igyPTCVenta As Short = 3
    Private igyPTCPorcParticipacion As Short = 4
    Private igyPTCPorcAcumulada As Short = 5
    Private igyPTCVentaNetaDolares As Short = 6
    Private igyPTCVentaNetaPesos As Short = 7
    Private igyPTCPrecioPromDolares As Short = 8
    Private igyPTCPrecioPromPesos As Short = 9
    Private igyPTCImporteTotalPesos As Short = 10
#End Region

#Region "Campos privados"
    Private _TopTenConsultaExteriorSemana1 As String
    Private _TopTenConsultaExteriorSemana2 As String
    Private _TopTenConsultaExteriorDia1 As String
    Private _TopTenConsultaExteriorDia2 As String
    Private _TopTenConsultaExteriorCodCultivo As String
    Private _TopTenConsultaExteriorPresentacion As String = ""
    Private _TopTenConsultaExteriorCliente As String = ""
    Private _TopTenConsultaExteriorTipoCambio As Double
    Private _TopTenConsultaExteriorZona As String
    Private _TopTenConsultaExteriorMercado As String

    Private _ConsultaExterior As Boolean = False
#End Region

#Region "Campos públicos"
    Public Enum enumModoAgrupado
        CLIENTES
        PRODUCTOS
    End Enum

    Public ModoAgrupado As enumModoAgrupado = enumModoAgrupado.PRODUCTOS
#End Region

#Region "Propiedades"
    Public WriteOnly Property TopTenConsultaExteriorSemana1() As String
        Set(ByVal Value As String)
            Me._TopTenConsultaExteriorSemana1 = Value
        End Set
    End Property

    Public WriteOnly Property TopTenConsultaExteriorSemana2() As String
        Set(ByVal Value As String)
            Me._TopTenConsultaExteriorSemana2 = Value
        End Set
    End Property
    Public WriteOnly Property TopTenConsultaExteriorDia1() As String
        Set(ByVal Value As String)
            Me._TopTenConsultaExteriorDia1 = Value
        End Set
    End Property
    Public WriteOnly Property TopTenConsultaExteriorDia2() As String
        Set(ByVal Value As String)
            Me._TopTenConsultaExteriorDia2 = Value
        End Set
    End Property

    Public WriteOnly Property TopTenConsultaExteriorCodCultivo() As String
        Set(ByVal Value As String)
            Me._TopTenConsultaExteriorCodCultivo = Value
        End Set
    End Property

    Public WriteOnly Property TopTenConsultaExteriorPresentacion() As String
        Set(ByVal Value As String)
            Me._TopTenConsultaExteriorPresentacion = Value
        End Set
    End Property

    Public WriteOnly Property TopTenConsultaExteriorCliente() As String
        Set(ByVal Value As String)
            Me._TopTenConsultaExteriorCliente = Value
        End Set
    End Property

    Public WriteOnly Property TopTenConsultaExteriorTipoCambio() As Double
        Set(ByVal Value As Double)
            Me._TopTenConsultaExteriorTipoCambio = Value
        End Set
    End Property

    Public WriteOnly Property TopTenConsultaExteriorZona() As String
        Set(ByVal Value As String)
            Me._TopTenConsultaExteriorZona = Value
        End Set
    End Property

    Public WriteOnly Property TopTenConsultaExteriorMercado() As String
        Set(ByVal Value As String)
            Me._TopTenConsultaExteriorMercado = Value
        End Set
    End Property

    Public WriteOnly Property ConsultaExterior() As Boolean
        Set(ByVal Value As Boolean)
            Me._ConsultaExterior = Value
        End Set
    End Property
#End Region

#Region "Opciones"
    Private Sub tsbConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbConsultar.Click
        Me.Consultar()
    End Sub

    Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click
        Me.Imprimir()
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub
#End Region

#Region "Eventos"
    Private Sub Rpt_Ventas_TopTenProductos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.DesplegarZona()
            Me.DesplegarDocumentos()
            Me.DesplegarOrden()
            Me.DesplegarTipoPago()

            Me.DtFechaDesde.Value = FechaActualINI()
            Me.DtFechaHasta.Value = Now
            Me.txtTipoCambio.Text = "0"

            Me.Inicializa()
            Me.InicializaGrid()
            'Me.ocultarElementos()

            If Me._ConsultaExterior = True Then
                Me.DtFechaDesde.Value = CDate(Me._TopTenConsultaExteriorDia1)
                Me.DtFechaHasta.Value = CDate(Me._TopTenConsultaExteriorDia2)
                Me.TxtCliente.Text = Me._TopTenConsultaExteriorCliente.ToString
                Me.CboZona.SelectedValue = Me._TopTenConsultaExteriorZona.ToString

                Me.GroupBox1.Enabled = False
                Me.Consultar()
            End If

            Select Case Me.ModoAgrupado
                Case enumModoAgrupado.PRODUCTOS
                    Me.Text = "TopTen de Productos"
                Case enumModoAgrupado.CLIENTES
                    Me.Text = "TopTen de Clientes"
            End Select

        Catch ex As Exception
            HandleError(Me.Name, "Rpt_Ventas_TopTenProductos_Load", ex)
        End Try
    End Sub

    Private Sub Grid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Grid.DoubleClick 'Habilitar cuando se actualice el stored de top ten clientes
        'Dim Columna As Integer, Renglon As Integer, vdg As String

        'Columna = Me.Grid.Selection.FirstCol
        'Renglon = Me.Grid.Selection.FirstRow

        'If Me._ConsultaExterior = True Then
        '    Exit Sub
        'End If

        'vdg = Me.Grid.Cell(Renglon, Me.igyCodigo).Text

        'Dim Child As New Rpt_Ventas_TopTenProductos()
        'Child.TopTenConsultaExteriorDia1 = Me.DtFechaDesde.Value.ToString
        'Child.TopTenConsultaExteriorDia2 = Me.DtFechaHasta.Value.ToString

        'If Me.ModoAgrupado = enumModoAgrupado.CLIENTES Then
        '    Child.ModoAgrupado = Rpt_Ventas_TopTenProductos.enumModoAgrupado.PRODUCTOS
        '    Child.TopTenConsultaExteriorCliente = vdg
        'Else
        '    Child.ModoAgrupado = Rpt_Ventas_TopTenProductos.enumModoAgrupado.CLIENTES
        '    Child.TopTenConsultaExteriorCodCultivo = vdg
        '    Child.TopTenConsultaExteriorCliente = Me.TxtCliente.Text
        'End If

        ''Child.TopTenConsultaExteriorTipoCambio = CDbl(Me.txtTipoCambio.Text)
        'Child.TopTenConsultaExteriorZona = Me.CboZona.SelectedValue.ToString
        ''Child.TopTenConsultaExteriorMercado = Me.cboMercado.SelectedValue.ToString
        'Child.ConsultaExterior = True

        'Child.ShowDialog()
        'Child.Dispose()
    End Sub

    Private Sub dtFechaHaste_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtFechaHasta.KeyDown
        If e.KeyCode = Keys.Return Then
            tsbConsultar.PerformClick()
        End If
    End Sub

    Private Sub TxtCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCliente.KeyDown
        Try
            Dim sText As String
            Select Case e.KeyCode
                Case Keys.F6
Buscar:
                    sText = Me.oClientes.BusquedaVisual_PorDescripcion
                    If txtLEN(sText) = True Then Me.TxtCliente.Text = sText
                Case Keys.Enter
                    If txtLEN(Me.TxtCliente.Text) = False Then
                        Me.lblNombreCliente.Text = "" : Me.tsbConsultar.PerformClick() : Exit Sub
                    End If

                    Me.oClientes = New Class_CatClientes(Me.TxtCliente.Text)
                    If Me.oClientes.Existe = False Then
                        Me.lblNombreCliente.Text = "" : GoTo Buscar : Exit Sub
                    End If

                    Me.lblNombreCliente.Text = Me.oClientes.NOMBRE_CLIENTE.ToString
                    'Me.txtTipoCambio.Focus()
            End Select
            Me.TxtCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            txtTAB(e)
        Catch ex As Exception
            HandleError(Me.Name, "TxtCliente_KeyDown", ex)
        End Try
    End Sub

    Private Sub TxtCodigosProductosKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodigosProductos.KeyDown
        Try
            Dim oProductos As New Class_CatArticulos
            Dim sText As String
            Select Case e.KeyCode
                Case Keys.F6
Buscar:
                    sText = oProductos.BusquedaVisual_PorDescripcion
                    If txtLEN(sText) = True Then Me.TxtCodigosProductos.Text = sText
                Case Keys.Enter
                    If txtLEN(TxtCodigosProductos.Text) = True Then
                        oProductos = New Class_CatArticulos(Me.TxtCodigosProductos.Text)
                        If oProductos.Existe = False Then
                            GoTo Buscar : Exit Sub
                        End If
                    End If
            End Select
            txtTAB(e)
        Catch ex As Exception
            HandleError(Me.Name, "TxtCodigosProductosKeyDown", ex)
        End Try
    End Sub

    Private Sub chkFiltrarPorUtilidad_CheckedChanged(sender As Object, e As EventArgs) Handles chkFiltrarPorUtilidad.CheckedChanged
        Me.gFiltrarUtilidad.Enabled = Me.chkFiltrarPorUtilidad.Checked
    End Sub

#End Region

#Region "Eventos Genericos"
    Private Sub txt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCliente.KeyPress, TxtCodigosProductos.KeyPress, TxtDescripcion.KeyPress, txtPorcentajeUtilidad.KeyPress, txtUtilidadMaxima.KeyPress, DtFechaDesde.KeyPress, DtFechaHasta.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub txt_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtFechaDesde.KeyDown, CboZona.KeyDown, TxtDescripcion.KeyDown, txtPorcentajeUtilidad.KeyDown, txtUtilidadMaxima.KeyDown, cboTipoPago.KeyDown, CboDocumento.KeyDown, cboOrden.KeyDown
        If e.KeyCode = Keys.Return Then
            txtTAB(e)
        End If
    End Sub

    Private Sub txtNumerosEnterosKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPorcentajeUtilidad.KeyPress, txtUtilidadMaxima.KeyPress
        txtSoloNumerosEnteros(e)
        txtNoBeep(e)
    End Sub

    Private Sub txtSoloNumerosDecimales_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTipoCambio.KeyPress
        Dim txt As TextBox = CType(sender, TextBox)
        txtSoloNumerosDecimales(e, txt.Text)
        txtNoBeep(e)
    End Sub
#End Region

#Region "Métodos y procedimientos"
    Private Sub Inicializa()
        Try
            Me.CboZona.SelectedValue = "T"

            Select Case Me.ModoAgrupado
                Case enumModoAgrupado.PRODUCTOS
                    '    Me.InicializaGrid()
                    '    Me.lblDisplayAgrupado.Visible = True
                    Me.txtSum1.Visible = True
                    Me.txtSum2.Visible = True
                    'Me.txtSum3.Visible = True
                    Me.txtSum4.Visible = True
                'Me.txtSum5.Visible = True
                'Me.txtSum6.Visible = False
                Case enumModoAgrupado.CLIENTES
                    '    Me.lblDisplayAgrupado.Visible = False
                    Me.txtSum1.Visible = True
                    Me.txtSum2.Visible = False
                    'Me.txtSum3.Visible = False
                    Me.txtSum4.Visible = False
                    'Me.txtSum5.Visible = False
                    'Me.txtSum6.Visible = True
            End Select

        Catch ex As Exception
            HandleError(Me.Name, "Inicializa", ex)
        End Try
    End Sub

    Private Sub DesplegarZona()
        Try
            Dim oElementos As New Class_CatZonas
            With Me.CboZona
                .DisplayMember = "NOMBRE_ZONA"
                .ValueMember = "CODIGO_ZONA"
                Dim dView As New Data.DataView(oElementos.ObtenerZonasParaReportes())
                dView.Sort = "NOMBRE_ZONA"
                .DataSource = dView
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarZona", ex)
        End Try
    End Sub

    Private Sub DesplegarDocumentos()
        Try
            Dim oElementos As New Class_CatDocumentos
            With Me.CboDocumento
                .DisplayMember = "NOMBRE_TIPO_DOCUMENTO"
                .ValueMember = "CODIGO_DOCUMENTO"
                Dim dView As New Data.DataView(oElementos.ObtenerCodigosDocumentos("VTA", Usuario.Codigo_Plaza.ToString))
                dView.Table.Rows.Add("T", "TODOS")
                dView.Sort = "NOMBRE_TIPO_DOCUMENTO"
                .DataSource = dView
                .SelectedValue = "T"
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarDocumentos", ex)
        End Try
    End Sub

    Private Sub DesplegarOrden()
        Try
            '$UTILIDAD,%UTILIDAD,$VENTA,DESCRI 
            Dim Items As New List(Of String)
            Items.Add("$UTILIDAD")
            Items.Add("%UTILIDAD")
            Items.Add("$VENTA")
            Items.Add("DESCRI")

            Me.cboOrden.DataSource = Items
            Me.cboOrden.SelectedIndex = 0
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarOrden", ex)
        End Try
    End Sub

    Private Sub DesplegarTipoPago()
        Try
            Dim oElementos As New Class_CatTiposNegociaciones
            With Me.cboTipoPago
                .DisplayMember = "NOMBRE_TIPO_NEGOCIACION"
                .ValueMember = "CODIGO_TIPO_NEGOCIACION"
                Dim dView As New Data.DataView(oElementos.ObtenerTiposNegociacionesParaReportes)
                dView.Sort = "NOMBRE_TIPO_NEGOCIACION"
                .DataSource = dView
                .SelectedValue = "T"
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarTipoPago", ex)
        End Try
    End Sub

    Private Sub InicializaGrid()
        Try
            Me.Grid.DataSource = Nothing
            FG_Grid_Limpiar(Me.Grid)

            Me.Grid.Rows = 2
            'Me.Grid.Cols = 13

            If Me.ModoAgrupado = enumModoAgrupado.PRODUCTOS Then
                Me.Grid.Cols = 15
                Me.FormateaGrid()
            Else
                Me.Grid.Cols = 10
                Me.FormateaGrid2()
            End If
        Catch ex As Exception
            HandleError(Me.Name, "InicializaGrid", ex)
        End Try
    End Sub

    Private Sub FormateaGrid()
        Try
            Me.Grid.FrozenCols = 2

            Me.Grid.Column(Me.igyCodigo).Width = 70
            Me.Grid.Column(Me.igyDescripcion).Width = 300
            Me.Grid.Column(Me.igyCantidad).Width = 100
            Me.Grid.Column(Me.igyVenta).Width = 100
            Me.Grid.Column(Me.igyCosto).Width = 100
            Me.Grid.Column(Me.igyUtilidad).Width = 100
            Me.Grid.Column(Me.igyP_Utilidad).Width = 100
            Me.Grid.Column(Me.igyPrecioUnitario).Width = 100
            Me.Grid.Column(Me.igyCostoUnitario).Width = 100
            Me.Grid.Column(Me.igyUtilidadUnitaria).Width = 100
            Me.Grid.Column(Me.igyParticipacionUtilidad).Width = 100
            Me.Grid.Column(Me.igyAcumuladoUtilidad).Width = 100
            Me.Grid.Column(Me.igyParticipacionVenta).Width = 100
            Me.Grid.Column(Me.igyAcumuladoVenta).Width = 100
            'Me.Grid.Column(Me.igyUtilidadBruta).Width = 100
            'Me.Grid.Column(Me.igyUtilidadBrutaPorcentaje).Width = 100

            Me.Grid.Cell(0, Me.igyCodigo).Text = "Código"
            Me.Grid.Cell(0, Me.igyDescripcion).Text = "Descripción"
            Me.Grid.Cell(0, Me.igyCantidad).Text = "Cant."
            Me.Grid.Cell(0, Me.igyVenta).Text = "Venta"
            Me.Grid.Cell(0, Me.igyCosto).Text = "Costo"
            Me.Grid.Cell(0, Me.igyUtilidad).Text = "Utilidad"
            Me.Grid.Cell(0, Me.igyP_Utilidad).Text = "% Util."
            Me.Grid.Cell(0, Me.igyPrecioUnitario).Text = "Precio uni."
            Me.Grid.Cell(0, Me.igyCostoUnitario).Text = "Costo uni."
            Me.Grid.Cell(0, Me.igyUtilidadUnitaria).Text = "Utilidad uni."
            Me.Grid.Cell(0, Me.igyParticipacionUtilidad).Text = "Participacion uti."
            Me.Grid.Cell(0, Me.igyAcumuladoUtilidad).Text = "Acumulado uti."
            Me.Grid.Cell(0, Me.igyParticipacionVenta).Text = "Participacion vta."
            Me.Grid.Cell(0, Me.igyAcumuladoVenta).Text = "Acumulativo vta."
            'Me.Grid.Cell(0, Me.igyUtilidadBruta).Text = "Utilidad bruta"
            'Me.Grid.Cell(0, Me.igyUtilidadBrutaPorcentaje).Text = "% uti. bruta"

            Me.Grid.Column(Me.igyCantidad).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.igyCantidad).DecimalLength = 0
            Me.Grid.Column(Me.igyCantidad).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.igyVenta).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
            Me.Grid.Column(Me.igyVenta).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.igyVenta).DecimalLength = Empresa_Sistema.DECIMALES_PRECIO
            Me.Grid.Column(Me.igyVenta).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.igyCosto).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
            Me.Grid.Column(Me.igyCosto).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.igyCosto).DecimalLength = Empresa_Sistema.DECIMALES_PRECIO
            Me.Grid.Column(Me.igyCosto).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.igyUtilidad).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
            Me.Grid.Column(Me.igyUtilidad).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.igyUtilidad).DecimalLength = Empresa_Sistema.DECIMALES_PRECIO
            Me.Grid.Column(Me.igyUtilidad).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.igyP_Utilidad).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.igyPrecioUnitario).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
            Me.Grid.Column(Me.igyPrecioUnitario).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.igyPrecioUnitario).DecimalLength = Empresa_Sistema.DECIMALES_PRECIO
            Me.Grid.Column(Me.igyPrecioUnitario).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.igyCostoUnitario).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
            Me.Grid.Column(Me.igyCostoUnitario).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.igyCostoUnitario).DecimalLength = Empresa_Sistema.DECIMALES_PRECIO
            Me.Grid.Column(Me.igyCostoUnitario).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.igyUtilidadUnitaria).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
            Me.Grid.Column(Me.igyUtilidadUnitaria).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.igyUtilidadUnitaria).DecimalLength = Empresa_Sistema.DECIMALES_PRECIO
            Me.Grid.Column(Me.igyUtilidadUnitaria).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.igyParticipacionUtilidad).FormatString = "##0.00 %"
            Me.Grid.Column(Me.igyParticipacionUtilidad).Mask = FlexCell.MaskEnum.Numeric
            'Me.Grid.Column(Me.igyParticipacionUtilidad).DecimalLength = Empresa_Sistema.DECIMALES_PRECIO
            Me.Grid.Column(Me.igyParticipacionUtilidad).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.igyAcumuladoUtilidad).FormatString = "##0.00 %"
            Me.Grid.Column(Me.igyAcumuladoUtilidad).Mask = FlexCell.MaskEnum.Numeric
            'Me.Grid.Column(Me.igyAcumuladoUtilidad).DecimalLength = Empresa_Sistema.DECIMALES_PRECIO
            Me.Grid.Column(Me.igyAcumuladoUtilidad).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.igyParticipacionVenta).FormatString = "##0.00 %"
            Me.Grid.Column(Me.igyParticipacionVenta).Mask = FlexCell.MaskEnum.Numeric
            'Me.Grid.Column(Me.igyParticipacionVenta).DecimalLength = Empresa_Sistema.DECIMALES_PRECIO
            Me.Grid.Column(Me.igyParticipacionVenta).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.igyAcumuladoVenta).FormatString = "##0.00 %"
            Me.Grid.Column(Me.igyAcumuladoVenta).Mask = FlexCell.MaskEnum.Numeric
            'Me.Grid.Column(Me.igyAcumuladoVenta).DecimalLength = Empresa_Sistema.DECIMALES_PRECIO
            Me.Grid.Column(Me.igyAcumuladoVenta).Alignment = FlexCell.AlignmentEnum.RightCenter

            'Me.Grid.Column(Me.igyUtilidadBruta).Alignment = FlexCell.AlignmentEnum.RightCenter
            'Me.Grid.Column(Me.igyUtilidadBrutaPorcentaje).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.igyCodigo).Visible = True
            Me.Grid.Column(Me.igyDescripcion).Visible = True
            Me.Grid.Column(Me.igyCantidad).Visible = True
            Me.Grid.Column(Me.igyVenta).Visible = True
            Me.Grid.Column(Me.igyCosto).Visible = True
            Me.Grid.Column(Me.igyUtilidad).Visible = True
            Me.Grid.Column(Me.igyP_Utilidad).Visible = True
            Me.Grid.Column(Me.igyPrecioUnitario).Visible = True
            Me.Grid.Column(Me.igyCostoUnitario).Visible = True
            Me.Grid.Column(Me.igyUtilidadUnitaria).Visible = True
            Me.Grid.Column(Me.igyParticipacionUtilidad).Visible = True
            Me.Grid.Column(Me.igyAcumuladoUtilidad).Visible = True
            Me.Grid.Column(Me.igyParticipacionVenta).Visible = True
            Me.Grid.Column(Me.igyAcumuladoVenta).Visible = True
            'Me.Grid.Column(Me.igyUtilidadBruta).Visible = True
            'Me.Grid.Column(Me.igyUtilidadBrutaPorcentaje).Visible = True

            Me.Grid.Column(Me.igyCodigo).Locked = True
            Me.Grid.Column(Me.igyDescripcion).Locked = True
            Me.Grid.Column(Me.igyCantidad).Locked = True
            Me.Grid.Column(Me.igyVenta).Locked = True
            Me.Grid.Column(Me.igyCosto).Locked = True
            Me.Grid.Column(Me.igyUtilidad).Locked = True
            Me.Grid.Column(Me.igyP_Utilidad).Locked = True
            Me.Grid.Column(Me.igyPrecioUnitario).Locked = True
            Me.Grid.Column(Me.igyCostoUnitario).Locked = True
            Me.Grid.Column(Me.igyUtilidadUnitaria).Locked = True
            Me.Grid.Column(Me.igyParticipacionUtilidad).Locked = True
            Me.Grid.Column(Me.igyAcumuladoUtilidad).Locked = True
            Me.Grid.Column(Me.igyParticipacionVenta).Locked = True
            Me.Grid.Column(Me.igyAcumuladoVenta).Locked = True
            'Me.Grid.Column(Me.igyUtilidadBruta).Locked = True
            'Me.Grid.Column(Me.igyUtilidadBrutaPorcentaje).Locked = True

        Catch ex As Exception
            HandleError(Me.Name, "FormateaGrid", ex)
        End Try
    End Sub

    Private Sub FormateaGrid2()
        Try
            Me.Grid.Column(Me.igyPTCCodigo).Width = 70
            Me.Grid.Column(Me.igyPTCDescripcion).Width = 300
            Me.Grid.Column(Me.igyPTCVenta).Width = 100
            Me.Grid.Column(Me.igyPTCPorcParticipacion).Width = 80
            Me.Grid.Column(Me.igyPTCPorcAcumulada).Width = 80
            Me.Grid.Column(Me.igyPTCVentaNetaDolares).Width = 100
            Me.Grid.Column(Me.igyPTCVentaNetaPesos).Width = 100
            Me.Grid.Column(Me.igyPTCPrecioPromDolares).Width = 80
            Me.Grid.Column(Me.igyPTCPrecioPromPesos).Width = 80

            Me.Grid.Cell(0, Me.igyPTCCodigo).Text = "Código"
            Me.Grid.Cell(0, Me.igyPTCDescripcion).Text = "Descripción"
            Me.Grid.Cell(0, Me.igyPTCVenta).Text = "Venta."
            Me.Grid.Cell(0, Me.igyPTCPorcParticipacion).Text = "Porc. part.."
            Me.Grid.Cell(0, Me.igyPTCPorcAcumulada).Text = "Part. Acum."
            Me.Grid.Cell(0, Me.igyPTCVentaNetaDolares).Text = "Total dolares."
            Me.Grid.Cell(0, Me.igyPTCVentaNetaPesos).Text = "Total pesos."

            Me.Grid.Column(Me.igyPTCPorcParticipacion).Alignment = FlexCell.AlignmentEnum.RightCenter
            Me.Grid.Column(Me.igyPTCPorcAcumulada).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.igyPTCVenta).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
            Me.Grid.Column(Me.igyPTCVenta).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.igyPTCVenta).DecimalLength = Empresa_Sistema.DECIMALES_PRECIO
            Me.Grid.Column(Me.igyPTCVenta).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.igyPTCVentaNetaDolares).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
            Me.Grid.Column(Me.igyPTCVentaNetaDolares).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.igyPTCVentaNetaDolares).DecimalLength = 2
            Me.Grid.Column(Me.igyPTCVentaNetaDolares).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.igyPTCVentaNetaPesos).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
            Me.Grid.Column(Me.igyPTCVentaNetaPesos).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.igyPTCVentaNetaPesos).DecimalLength = 2
            Me.Grid.Column(Me.igyPTCVentaNetaPesos).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.igyPTCCodigo).Visible = True
            Me.Grid.Column(Me.igyPTCDescripcion).Visible = True
            Me.Grid.Column(Me.igyPTCVenta).Visible = True
            Me.Grid.Column(Me.igyPTCPorcParticipacion).Visible = True
            Me.Grid.Column(Me.igyPTCPorcAcumulada).Visible = True
            Me.Grid.Column(Me.igyPTCVentaNetaDolares).Visible = False
            Me.Grid.Column(Me.igyPTCVentaNetaPesos).Visible = False
            Me.Grid.Column(Me.igyPTCPrecioPromDolares).Visible = False
            Me.Grid.Column(Me.igyPTCPrecioPromPesos).Visible = False

            Me.Grid.Column(Me.igyPTCCodigo).Locked = True
            Me.Grid.Column(Me.igyPTCDescripcion).Locked = True
            Me.Grid.Column(Me.igyPTCVenta).Locked = True
            Me.Grid.Column(Me.igyPTCPorcParticipacion).Locked = True
            Me.Grid.Column(Me.igyPTCPorcAcumulada).Locked = True
            Me.Grid.Column(Me.igyPTCVentaNetaDolares).Locked = True
            Me.Grid.Column(Me.igyPTCVentaNetaPesos).Locked = True
            Me.Grid.Column(Me.igyPTCPrecioPromDolares).Locked = True
            Me.Grid.Column(Me.igyPTCPrecioPromPesos).Locked = True

        Catch ex As Exception
            HandleError(Me.Name, "FormateaGrid2", ex)
        End Try
    End Sub

    Public Sub Totales()
        Try
            If Me.ModoAgrupado = enumModoAgrupado.PRODUCTOS Then
                Me.txtSum1.Text = FormatNumber(FG_Grid_SumaCol(Me.Grid, CShort(Me.igyCantidad)), 0)
                Me.txtSum4.Text = FormatImporteContable(FG_Grid_SumaCol(Me.Grid, CShort(Me.igyVenta)))
                Me.txtSum2.Text = FormatImporteContable(CDbl(Me.Grid.Cell(1, Me.igyCosto).Text))
            Else
                Me.txtSum1.Text = FormatImporteContable(FG_Grid_SumaCol(Me.Grid, CShort(Me.igyPTCVenta)))
            End If

        Catch ex As Exception
            HandleError(Me.Name, "Totales", ex)
        End Try
    End Sub

    Private Function Validar() As Boolean
        Try
            If Me._ConsultaExterior = True Then
                Return True
            End If

            If ModoAgrupado = enumModoAgrupado.PRODUCTOS Then
                If Me.chkFiltrarPorUtilidad.Checked = True Then
                    If txtLEN(Me.txtPorcentajeUtilidad.Text) = False Then
                        MsgBox("Capture un porcentaje.", MsgBoxStyle.Exclamation, Me.Name)
                        Me.txtPorcentajeUtilidad.Focus()
                        Return False
                    End If
                End If

                If txtLEN(Me.txtUtilidadMaxima.Text) = False Then
                    MsgBox("Capture la utilidad máxima.", MsgBoxStyle.Exclamation, Me.Name)
                    Me.txtUtilidadMaxima.Focus()
                    Return False
                End If
            Else
                If txtLEN(Me.txtTipoCambio.Text) = False Then
                    Me.txtTipoCambio.Text = "0"
                End If
            End If

            Return True

        Catch ex As Exception
            HandleError(Me.Name, "Validar", ex)
        End Try
    End Function

    Public Sub Consultar()
        Dim dt As New DataTable
        Try
            If txtLEN(Me.TxtCliente.Text) = True Then
                Me.oClientes = New Class_CatClientes(Me.TxtCliente.Text)
                If Me.oClientes.Existe = False Then
                    MsgBox("El cliente no existe.", MsgBoxStyle.Exclamation, Me.Name)
                    Me.TxtCliente.Focus()
                    Return
                Else
                    Me.lblNombreCliente.Text = Me.oClientes.NOMBRE_CLIENTE.ToString
                End If
            End If

            If Me.ValidarPeriodo() = False Then
                Return
            End If

            If Me.Validar() = False Then
                Return
            End If

            Dim sqlParametro As New SqlParameter

            Select Case Me.ModoAgrupado
                Case enumModoAgrupado.PRODUCTOS
                    Using connection As SqlConnection = New SqlConnection(Empresa_Sistema.conexion)
                        Dim command As New SqlCommand("MP_RPT_Q_VENTAS_TOP_PRODUCTOS", connection)
                        command.CommandType = CommandType.StoredProcedure
                        Dim da As New SqlDataAdapter(command)

                        With command.Parameters
                            .Add(New SqlParameter("@CODIGO_CLIENTE", SqlDbType.NVarChar, 8)).Value = Me.TxtCliente.Text
                            .Add(New SqlParameter("@CODIGO_DOCUMENTO", SqlDbType.NVarChar, 10)).Value = Me.CboDocumento.SelectedValue.ToString
                            .Add(New SqlParameter("@FECHA1", SqlDbType.NVarChar, 20)).Value = Format(Me.DtFechaDesde.Value, "yyyy-dd-MM")
                            .Add(New SqlParameter("@FECHA2", SqlDbType.NVarChar, 20)).Value = Format(Me.DtFechaHasta.Value, "yyyy-dd-MM")
                            .Add(New SqlParameter("@CODIGO_ZONA", SqlDbType.NVarChar, 30)).Value = Me.CboZona.SelectedValue.ToString
                            .Add(New SqlParameter("@DESCRIPCION", SqlDbType.NVarChar, 30)).Value = Me.TxtDescripcion.Text.ToUpper
                            .Add(New SqlParameter("@FILRAR_POR_UTILIDAD", SqlDbType.Char, 1)).Value = Convert.ToInt32(Me.chkFiltrarPorUtilidad.Checked).ToString
                            .Add(New SqlParameter("@TIPO_UTILIDAD", SqlDbType.NVarChar, 20)).Value = IIf(Me.rbMinimo.Checked = True, "MINIMA", "MAXIMA").ToString
                            .Add(New SqlParameter("@PORCENTAJE_UTILIDAD", SqlDbType.Decimal)).Value = valorNumericoD(Me.txtPorcentajeUtilidad.Text)
                            .Add(New SqlParameter("@TIPO_PAGO", SqlDbType.Char, 1)).Value = Me.cboTipoPago.SelectedValue.ToString
                            .Add(New SqlParameter("@UTILIDAD_MAXIMA", SqlDbType.SmallInt)).Value = CInt(Me.txtUtilidadMaxima.Text)
                            .Add(New SqlParameter("@CODIGOS_PRODUCTOS", SqlDbType.NVarChar, 2000)).Value = Me.TxtCodigosProductos.Text.ToUpper
                            .Add(New SqlParameter("@ORDEN", SqlDbType.NVarChar, 30)).Value = Me.cboOrden.SelectedValue
                        End With

                        da.Fill(dt)
                        dt.Columns.Remove("IDTRANS")
                    End Using

                Case enumModoAgrupado.CLIENTES
                    Using connection As SqlConnection = New SqlConnection(Empresa_Sistema.conexion)
                        Dim command As New SqlCommand("MP_RPT_Q_TOPTEN_CLIENTES", connection)
                        command.CommandType = CommandType.StoredProcedure
                        Dim da As New SqlDataAdapter(command)

                        With command.Parameters
                            .Add("@FECHA1_DIA", SqlDbType.NVarChar, 20).Value = Format(Me.DtFechaDesde.Value, "yyyy-dd-MM")
                            .Add("@FECHA2_DIA", SqlDbType.NVarChar, 20).Value = Format(Me.DtFechaHasta.Value, "yyyy-dd-MM")
                            .Add("@UNIDAD_VENTA", SqlDbType.NVarChar, 10).Value = Me._TopTenConsultaExteriorPresentacion.ToString
                            .Add("@CODIGO_CLIENTE", SqlDbType.NVarChar, 8).Value = Me.TxtCliente.Text
                            .Add("@TIPO_CAMBIO", SqlDbType.Decimal).Value = valorNumerico(Me.txtTipoCambio.Text)
                            .Add("@CODIGO_ZONA", SqlDbType.NVarChar, 2).Value = Me.CboZona.SelectedValue.ToString
                        End With

                        da.Fill(dt)
                    End Using
            End Select

            dt.Columns.Remove("EMPRESA_NOMBRE")
            dt.Columns.Remove("EMPRESA_DOMICILIO")
            dt.Columns.Remove("EMPRESA_CIUDAD")
            dt.Columns.Remove("EMPRESA_ESTADO")
            dt.Columns.Remove("EMPRESA_RFC")
            dt.Columns.Remove("EMPRESA_TELEFONO")
            dt.Columns.Remove("FILTROS_TEXTO")
            dt.Columns.Remove("UTILIDAD_BRUTA")
            dt.Columns.Remove("UTILIDAD_BRUTA_PORCENTAJE")

            Me.Grid.Rows = 1 'Con esto simulamos una inicialización del grid.

            Me.Grid.AutoRedraw = False

            If Me.ModoAgrupado = enumModoAgrupado.PRODUCTOS Then
                For Each dRow As DataRow In dt.Rows
                    Me.Grid.AddItem(dRow("CODIGO").ToString & Chr(9) & dRow("DESCRIPCION").ToString & Chr(9) & dRow("CANTIDAD").ToString & Chr(9) & dRow("VENTA").ToString & Chr(9) & dRow("COSTO").ToString & Chr(9) &
                                    dRow("UTILIDAD").ToString & Chr(9) & dRow("P_UTILIDAD").ToString & Chr(9) & dRow("PRECIO_UNITARIO").ToString & Chr(9) & dRow("COSTO_UNITARIO").ToString & Chr(9) & dRow("UTILIDAD_UNITARIA").ToString & Chr(9) &
                                   valorNumericoD(dRow("PARTICIPACION_UTILIDAD").ToString) / valorNumericoD("100.00") & Chr(9) &
                                   valorNumericoD(dRow("ACUMULADO_UTILIDAD").ToString) / valorNumericoD("100.00") & Chr(9) &
                                   valorNumericoD(dRow("PARTICIPACION_VENTA").ToString) / valorNumericoD("100.00") & Chr(9) &
                                   valorNumericoD(dRow("ACUMULADO_VENTA").ToString) / valorNumericoD("100.00") & Chr(9)) ' & dRow(14).ToString & Chr(9) &
                    'dRow(15).ToString & Chr(9))
                Next
            Else
                For Each dRow As DataRow In dt.Rows
                    Me.Grid.AddItem(dRow(0).ToString & Chr(9) & dRow(1).ToString & Chr(9) & dRow(2).ToString & Chr(9) & dRow(3).ToString & Chr(9) & dRow(4).ToString & Chr(9) &
                                    dRow(5).ToString & Chr(9) & dRow(6).ToString & Chr(9) & dRow(7).ToString & Chr(9) & dRow(8).ToString & Chr(9))
                Next
            End If

            If Me.Grid.Rows = 1 Then
                Me.Grid.Rows = 2
                Me.txtSum1.Text = FormatNumber(0)
                Me.txtSum4.Text = FormatImporteContable(0)
                Me.txtSum2.Text = FormatImporteContable(0)
            Else
                Me.Totales()
            End If

            dt.Dispose()

        Catch ex As Exception
            HandleError(Me.Name, "Consultar", ex)
        Finally
            Me.Grid.AutoRedraw = True
            Me.Grid.Refresh()
        End Try
    End Sub

    Private Sub Imprimir()
        Dim FormatoDeReporte As String = ""
        Dim Rpt As New ReportDocument
        Dim oReporte As New Class_Reporte
        Try
            If txtLEN(Me.TxtCliente.Text) = True Then
                Me.oClientes = New Class_CatClientes(Me.TxtCliente.Text)
                If Me.oClientes.Existe = False Then
                    MsgBox("El cliente no existe.", MsgBoxStyle.Information, Me.Name)
                    Me.TxtCliente.Focus()
                    Return
                End If
            End If

            If Me.ValidarPeriodo = False Then
                Return
            End If

            Select Case Me.ModoAgrupado
                Case enumModoAgrupado.PRODUCTOS
                    FormatoDeReporte = "RPT_MP_Q_VENTAS_TOP_PRODUCTOS"

                    oReporte = New Class_Reporte(FormatoDeReporte, Rpt)
                    Rpt.SetParameterValue("@CODIGO_CLIENTE", Me.TxtCliente.Text)
                    Rpt.SetParameterValue("@CODIGO_DOCUMENTO", Me.CboDocumento.SelectedValue)
                    Rpt.SetParameterValue("@FECHA1", Format(Me.DtFechaDesde.Value, "yyyy-dd-MM"))
                    Rpt.SetParameterValue("@FECHA2", Format(Me.DtFechaHasta.Value, "yyyy-dd-MM"))
                    Rpt.SetParameterValue("@CODIGO_ZONA", Me.CboZona.SelectedValue.ToString())
                    Rpt.SetParameterValue("@DESCRIPCION", Me.TxtDescripcion.Text.ToUpper)
                    Rpt.SetParameterValue("@FILRAR_POR_UTILIDAD", Convert.ToInt32(Me.chkFiltrarPorUtilidad.Checked).ToString)
                    Rpt.SetParameterValue("@TIPO_UTILIDAD", IIf(Me.rbMinimo.Checked = True, "MINIMA", "MAXIMO").ToString)
                    Rpt.SetParameterValue("@PORCENTAJE_UTILIDAD", Me.txtPorcentajeUtilidad.Text)
                    Rpt.SetParameterValue("@TIPO_PAGO", Me.cboTipoPago.SelectedValue.ToString)
                    Rpt.SetParameterValue("@UTILIDAD_MAXIMA", CInt(Me.txtUtilidadMaxima.Text))
                    Rpt.SetParameterValue("@CODIGOS_PRODUCTOS", Me.TxtCodigosProductos.Text.ToUpper)
                    Rpt.SetParameterValue("@ORDEN", Me.cboOrden.SelectedValue)

                Case enumModoAgrupado.CLIENTES
                    FormatoDeReporte = "RPT_MP_Q_TOPTEN_CLIENTES"

                    oReporte = New Class_Reporte(FormatoDeReporte, Rpt)
                    Rpt.SetParameterValue("@FECHA1_DIA", Format(Me.DtFechaDesde.Value, "yyyy-dd-MM"))
                    Rpt.SetParameterValue("@FECHA2_DIA", Format(Me.DtFechaHasta.Value, "yyyy-dd-MM"))
                    Rpt.SetParameterValue("@UNIDAD_VENTA", Me._TopTenConsultaExteriorPresentacion.ToString)
                    Rpt.SetParameterValue("@CODIGO_CLIENTE", Me.TxtCliente.Text)
                    Rpt.SetParameterValue("@TIPO_CAMBIO", valorNumerico(Me.txtTipoCambio.Text))
                    Rpt.SetParameterValue("@CODIGO_ZONA", Me.CboZona.SelectedValue)
            End Select

            Dim frm As New Reporte(Rpt)
            frm.CRViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            frm.Show()

        Catch ex As Exception
            HandleError(Me.Name, "Imprimir", ex)
        Finally
            oReporte = Nothing
        End Try
    End Sub

    Private Function ValidarPeriodo() As Boolean
        Try
            Me.DtFechaDesde.Enabled = False
            Me.DtFechaDesde.Enabled = True

            Me.DtFechaHasta.Enabled = False
            Me.DtFechaHasta.Enabled = True

            If Me.DtFechaDesde.Value > Me.DtFechaHasta.Value Then
                MsgBox("Rango de fechas inválidas.", MsgBoxStyle.Exclamation, Me.Name)
                Me.DtFechaDesde.Focus()
                Return False
            End If

            Return True
        Catch ex As Exception
            HandleError(Me.Name, "ValidarPeriodo", ex)
        End Try
    End Function

#End Region

End Class