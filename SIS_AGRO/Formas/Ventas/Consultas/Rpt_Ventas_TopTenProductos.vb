Option Strict On

Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class Rpt_Ventas_TopTenProductos
    Private oClientes As New Class_CatClientes

    'Private igyCodigo As Short = 1
    'Private igyDescripcion As Short = 2
    'Private igyCantidad As Short = 3
    'Private igyPresentacion As Short = 4
    'Private igyImporte As Short = 4
    'Private igyPrecioPromedio As Short = 5
    'Private igyPorcParticipacion As Short = 6
    'Private igyPartAcumulada As Short = 7
    'Private igyImporteTotalDolares As Short = 8
    'Private igyImporteTotalPesos As Short = 9
    'Private igyPrecioPromedioDolares As Short = 10
    'Private igyPrecioPromedioPesos As Short = 11

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
    Private igyUtilidadBruta As Short = 15
    Private igyUtilidadBrutaPorcentaje As Short = 16

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

    Public Enum enumModoAgrupado
        CLIENTES
        PRODUCTOS
    End Enum

    Public ModoAgrupado As enumModoAgrupado

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

    Private Sub Inicializa()
        'Me.TxtFolio.Text = ""
        'Me.LblStatus.Text = "N"
        'Me.LblPoliza.Text = ""
        'Me.dtFecha.Value = Date.Now
        'Me.TxtCodigoProveedor.Text = ""
        'Me.LblProveedor.Text = ""
        Me.CboZona.SelectedValue = "T"
        Me.RbtnCategoria.Checked = True

        If Me.ModoAgrupado = enumModoAgrupado.PRODUCTOS Then
            '    Me.InicializaGrid()
            '    Me.lblDisplayAgrupado.Visible = True
            Me.txtSum1.Visible = True
            Me.txtSum2.Visible = True
            'Me.txtSum3.Visible = True
            Me.txtSum4.Visible = True
            'Me.txtSum5.Visible = True
            'Me.txtSum6.Visible = False
        Else
            '    Me.lblDisplayAgrupado.Visible = False
            Me.txtSum1.Visible = True
            Me.txtSum2.Visible = False
            'Me.txtSum3.Visible = False
            Me.txtSum4.Visible = False
            'Me.txtSum5.Visible = False
            'Me.txtSum6.Visible = True
        End If
    End Sub

    'Private Sub DesplegarCultivos()
    '    Dim oElementos As New Class_CatCultivos
    '    With Me.cboCultivo
    '        .DisplayMember = "NOMBRE_CULTIVO"
    '        .ValueMember = "CODIGO_CULTIVO"

    '        Dim dView As New Data.DataView(oElementos.ObtenerElementosParaReportes)
    '        dView.Sort = "NOMBRE_CULTIVO"
    '        .DataSource = dView
    '        .Text = "TODOS"
    '    End With
    'End Sub

    'Private Sub DesplegarSemana1()
    '    Dim oElementos As New Class_CatCultivos
    '    With Me.CboSemana1
    '        .DisplayMember = "SEMANA"
    '        .ValueMember = "FECHA1"
    '        Dim dView As New Data.DataView(oElementos.ObtenerSemanas("1"))
    '        dView.Sort = "SEMANA"
    '        .DataSource = dView
    '    End With
    'End Sub

    'Private Sub DesplegarSemana2()
    '    Dim oElementos As New Class_CatCultivos
    '    With Me.CboSemana2
    '        .DisplayMember = "SEMANA"
    '        .ValueMember = "FECHA2"
    '        Dim dView As New Data.DataView(oElementos.ObtenerSemanas("2"))
    '        dView.Sort = "SEMANA"
    '        .DataSource = dView
    '    End With
    'End Sub

    Private Sub DesplegarZona()
        Dim oElementos As New Class_CatZonas
        With Me.CboZona
            .DisplayMember = "NOMBRE_ZONA"
            .ValueMember = "CODIGO_ZONA"
            Dim dView As New Data.DataView(oElementos.ObtenerZonasParaReportes())
            dView.Sort = "NOMBRE_ZONA"
            .DataSource = dView
        End With
    End Sub

    'Private Sub DesplegarMercado()
    '    Dim oElementos As New Class_CatTiposMercados
    '    With Me.cboMercado
    '        .DisplayMember = "NOMBRE_MERCADO"
    '        .ValueMember = "CODIGO_TIPO_MERCADO"
    '        Dim dView As New Data.DataView(oElementos.ObtenerTiposMercadosParaReportes())
    '        dView.Sort = "NOMBRE_MERCADO"
    '        .DataSource = dView
    '        .Text = "TODOS"
    '    End With
    'End Sub

    Private Sub DesplegarDocumentos()
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
    End Sub

    Private Sub DesplegarOrden()
        '$UTILIDAD,%UTILIDAD,$VENTA,DESCRI 
        Dim Items As New List(Of String)
        Items.Add("$UTILIDAD")
        Items.Add("%UTILIDAD")
        Items.Add("$VENTA")
        Items.Add("DESCRI")

        cboOrden.DataSource = Items
        cboOrden.SelectedIndex = 0

    End Sub

    Private Sub DesplegarTipoPago()
        Dim oElementos As New Class_CatTiposNegociaciones
        With Me.cboTipoPago
            .DisplayMember = "NOMBRE_TIPO_NEGOCIACION"
            .ValueMember = "CODIGO_TIPO_NEGOCIACION"
            Dim dView As New Data.DataView(oElementos.ObtenerTiposNegociacionesParaReportes)
            dView.Sort = "NOMBRE_TIPO_NEGOCIACION"
            .DataSource = dView
            .SelectedValue = "T"
        End With
    End Sub


    Private Sub Rpt_Ventas_TopTenProductos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.DesplegarCultivos()
        'Me.DesplegarSemana1()
        'Me.DesplegarSemana2()
        'Me.DesplegarMercado()
        Me.DesplegarZona()
        Me.DesplegarDocumentos()
        Me.DesplegarOrden()
        Me.DesplegarTipoPago()


        'Me.CboSemana1.Text = "2011-26" '& DatePart("ww", TemporadaActiva.FECHA1, FirstDayOfWeek.Sunday, FirstWeekOfYear.FirstFullWeek).ToString
        'Me.CboSemana2.Text = Format(Now, "yyyy-") & Format(CInt(DatePart("ww", Now, FirstDayOfWeek.Sunday, FirstWeekOfYear.FirstFullWeek).ToString) - 1, "00")

        Me.DtFechaDesde.Value = FechaActualINI()
        Me.DtFechaHasta.Value = Now

        'Me.cboCultivo.Focus()

        Me.Inicializa()
        Me.InicializaGrid()

        If Me._ConsultaExterior = True Then
            'Me.CboSemana1.SelectedValue = Me._TopTenConsultaExteriorSemana1.ToString
            'Me.CboSemana2.SelectedValue = Me._TopTenConsultaExteriorSemana2.ToString
            Me.DtFechaDesde.Value = CDate(Me._TopTenConsultaExteriorDia1)
            Me.DtFechaHasta.Value = CDate(Me._TopTenConsultaExteriorDia2)
            'Me.cboCultivo.SelectedValue = Me._TopTenConsultaExteriorCodCultivo.ToString
            Me.TxtCliente.Text = Me._TopTenConsultaExteriorCliente.ToString
            'Me.txtTipoCambio.Text = Me._TopTenConsultaExteriorTipoCambio.ToString
            Me.CboZona.SelectedValue = Me._TopTenConsultaExteriorZona.ToString
            'Me.cboMercado.SelectedValue = Me._TopTenConsultaExteriorMercado.ToString

            Me.GroupBox1.Enabled = False
            Me.Consultar()
            'Child.TopTenConsultaExteriorPresentacion 
        End If

        If Me.ModoAgrupado = enumModoAgrupado.CLIENTES Then
            Me.Text = "Reporte TopTen de Clientes"
        End If
    End Sub

    Private Sub tsbConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbConsultar.Click
        Me.Consultar()
    End Sub

    Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click
        Me.Imprimir()
    End Sub

    Private Sub Grid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Grid.DoubleClick 'Habilitar cuando se actualice el stored de top ten clientes
        'Dim Columna As Integer, Renglon As Integer, vdg As String

        'Columna = Me.Grid.Selection.FirstCol
        'Renglon = Me.Grid.Selection.FirstRow
        ''If Columna = Me.igyPresentacion Then
        ''    Exit Sub
        ''End If

        'If Me._ConsultaExterior = True Then
        '    Exit Sub
        'End If

        'vdg = Me.Grid.Cell(Renglon, Me.igyCodigo).Text 'Grid.Rows(Renglon).Cell("FOLIO_POLIZA")

        'Dim Child As New Rpt_Ventas_TopTenProductos()
        ''Child.TopTenConsultaExteriorSemana1 = Me.CboSemana1.SelectedValue.ToString
        ''Child.TopTenConsultaExteriorSemana2 = Me.CboSemana2.SelectedValue.ToString
        'Child.TopTenConsultaExteriorDia1 = Me.DtFechaDesde.Value.ToString
        'Child.TopTenConsultaExteriorDia2 = Me.DtFechaHasta.Value.ToString
        ''Child.TopTenConsultaExteriorPresentacion = Me.Grid.Cell(Renglon, Me.igyPresentacion).Text

        'If Me.ModoAgrupado = enumModoAgrupado.CLIENTES Then
        '    Child.ModoAgrupado = Rpt_Ventas_TopTenProductos.enumModoAgrupado.PRODUCTOS
        '    'Child.TopTenConsultaExteriorCodCultivo = Me.cboCultivo.SelectedValue.ToString
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

    Private Sub InicializaGrid()
        Me.Grid.DataSource = Nothing
        FG_Grid_Limpiar(Me.Grid)

        Me.Grid.Rows = 2
        'Me.Grid.Cols = 13

        If Me.ModoAgrupado = enumModoAgrupado.PRODUCTOS Then
            Me.Grid.Cols = 17
            Me.FormateaGrid()
        Else
            Me.Grid.Cols = 10
            Me.FormateaGrid2()
        End If
    End Sub

    Private Sub FormateaGrid()
        'Me.Grid.Column(Me.igyCodigo).Width = 70
        'Me.Grid.Column(Me.igyDescripcion).Width = 300
        'Me.Grid.Column(Me.igyCantidad).Width = 100
        'Me.Grid.Column(Me.igyPresentacion).Width = 80
        'Me.Grid.Column(Me.igyImporte).Width = 80
        'Me.Grid.Column(Me.igyPrecioPromedio).Width = 80
        'Me.Grid.Column(Me.igyPorcParticipacion).Width = 80
        'Me.Grid.Column(Me.igyPartAcumulada).Width = 80
        'Me.Grid.Column(Me.igyImporteTotalDolares).Width = 80
        'Me.Grid.Column(Me.igyImporteTotalPesos).Width = 80
        'Me.Grid.Column(Me.igyPrecioPromedioDolares).Width = 80
        'Me.Grid.Column(Me.igyPrecioPromedioPesos).Width = 80

        'Me.Grid.Cell(0, Me.igyCodigo).Text = "Código"
        'Me.Grid.Cell(0, Me.igyDescripcion).Text = "Descripción"
        'Me.Grid.Cell(0, Me.igyCantidad).Text = "Cant."
        'Me.Grid.Cell(0, Me.igyPresentacion).Text = "Presentación."
        'Me.Grid.Cell(0, Me.igyImporte).Text = "Venta."
        'Me.Grid.Cell(0, Me.igyPrecioPromedio).Text = "Precio prom."
        'Me.Grid.Cell(0, Me.igyPorcParticipacion).Text = "Part."
        'Me.Grid.Cell(0, Me.igyPartAcumulada).Text = "Part. Acum."
        'Me.Grid.Cell(0, Me.igyImporteTotalDolares).Text = "Importe total dolares."
        'Me.Grid.Cell(0, Me.igyImporteTotalPesos).Text = "Importe total pesos."
        'Me.Grid.Cell(0, Me.igyPrecioPromedioDolares).Text = "Precio prom. dolares"
        'Me.Grid.Cell(0, Me.igyPrecioPromedioPesos).Text = "Precio prom. pesos"

        'Me.Grid.Column(Me.igyPresentacion).Alignment = FlexCell.AlignmentEnum.CenterCenter
        'Me.Grid.Column(Me.igyPorcParticipacion).Alignment = FlexCell.AlignmentEnum.RightCenter
        'Me.Grid.Column(Me.igyPartAcumulada).Alignment = FlexCell.AlignmentEnum.RightCenter

        'Me.Grid.Column(Me.igyCantidad).Mask = FlexCell.MaskEnum.Numeric
        'Me.Grid.Column(Me.igyCantidad).DecimalLength = 0
        'Me.Grid.Column(Me.igyCantidad).Alignment = FlexCell.AlignmentEnum.RightCenter

        'Me.Grid.Column(Me.igyPrecioPromedio).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
        'Me.Grid.Column(Me.igyPrecioPromedio).Mask = FlexCell.MaskEnum.Numeric
        'Me.Grid.Column(Me.igyPrecioPromedio).DecimalLength = Empresa_Sistema.DECIMALES_PRECIO
        'Me.Grid.Column(Me.igyPrecioPromedio).Alignment = FlexCell.AlignmentEnum.RightCenter

        'Me.Grid.Column(Me.igyImporteTotalDolares).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
        'Me.Grid.Column(Me.igyImporteTotalDolares).Mask = FlexCell.MaskEnum.Numeric
        'Me.Grid.Column(Me.igyImporteTotalDolares).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
        'Me.Grid.Column(Me.igyImporteTotalDolares).Alignment = FlexCell.AlignmentEnum.RightCenter

        'Me.Grid.Column(Me.igyImporte).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
        'Me.Grid.Column(Me.igyImporte).Mask = FlexCell.MaskEnum.Numeric
        'Me.Grid.Column(Me.igyImporte).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
        'Me.Grid.Column(Me.igyImporte).Alignment = FlexCell.AlignmentEnum.RightCenter

        'Me.Grid.Column(Me.igyCodigo).Visible = True
        'Me.Grid.Column(Me.igyDescripcion).Visible = True

        'Me.Grid.Column(Me.igyCantidad).Visible = True
        'Me.Grid.Column(Me.igyPresentacion).Visible = True
        'Me.Grid.Column(Me.igyImporte).Visible = True
        'Me.Grid.Column(Me.igyPorcParticipacion).Visible = True
        'Me.Grid.Column(Me.igyPartAcumulada).Visible = True
        'Me.Grid.Column(Me.igyPrecioPromedio).Visible = True

        'Me.Grid.Column(Me.igyImporteTotalDolares).Visible = False
        'Me.Grid.Column(Me.igyImporteTotalPesos).Visible = False
        'Me.Grid.Column(Me.igyPrecioPromedioDolares).Visible = False
        'Me.Grid.Column(Me.igyPrecioPromedioPesos).Visible = False

        'Me.Grid.Column(Me.igyCodigo).Locked = True
        'Me.Grid.Column(Me.igyDescripcion).Locked = True
        'Me.Grid.Column(Me.igyCantidad).Locked = True
        'Me.Grid.Column(Me.igyPresentacion).Locked = True
        'Me.Grid.Column(Me.igyImporte).Locked = True
        'Me.Grid.Column(Me.igyPrecioPromedio).Locked = True
        'Me.Grid.Column(Me.igyPorcParticipacion).Locked = True
        'Me.Grid.Column(Me.igyPartAcumulada).Locked = True
        'Me.Grid.Column(Me.igyImporteTotalDolares).Locked = True
        'Me.Grid.Column(Me.igyImporteTotalPesos).Locked = True
        'Me.Grid.Column(Me.igyPrecioPromedioDolares).Locked = True
        'Me.Grid.Column(Me.igyPrecioPromedioPesos).Locked = True

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
        Me.Grid.Column(Me.igyUtilidadBruta).Width = 100
        Me.Grid.Column(Me.igyUtilidadBrutaPorcentaje).Width = 100

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
        Me.Grid.Cell(0, Me.igyUtilidadBruta).Text = "Utilidad bruta"
        Me.Grid.Cell(0, Me.igyUtilidadBrutaPorcentaje).Text = "% uti. bruta"

        Me.Grid.Column(Me.igyCantidad).Mask = FlexCell.MaskEnum.Numeric
        Me.Grid.Column(Me.igyCantidad).DecimalLength = 0
        Me.Grid.Column(Me.igyCantidad).Alignment = FlexCell.AlignmentEnum.RightCenter

        Me.Grid.Column(Me.igyP_Utilidad).Alignment = FlexCell.AlignmentEnum.RightCenter
        Me.Grid.Column(Me.igyUtilidadUnitaria).Alignment = FlexCell.AlignmentEnum.RightCenter
        Me.Grid.Column(Me.igyParticipacionUtilidad).Alignment = FlexCell.AlignmentEnum.RightCenter
        Me.Grid.Column(Me.igyParticipacionVenta).Alignment = FlexCell.AlignmentEnum.RightCenter
        Me.Grid.Column(Me.igyUtilidadBruta).Alignment = FlexCell.AlignmentEnum.RightCenter
        Me.Grid.Column(Me.igyUtilidadBrutaPorcentaje).Alignment = FlexCell.AlignmentEnum.RightCenter

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

        Me.Grid.Column(Me.igyPrecioUnitario).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
        Me.Grid.Column(Me.igyPrecioUnitario).Mask = FlexCell.MaskEnum.Numeric
        Me.Grid.Column(Me.igyPrecioUnitario).DecimalLength = Empresa_Sistema.DECIMALES_PRECIO
        Me.Grid.Column(Me.igyPrecioUnitario).Alignment = FlexCell.AlignmentEnum.RightCenter

        Me.Grid.Column(Me.igyCostoUnitario).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
        Me.Grid.Column(Me.igyCostoUnitario).Mask = FlexCell.MaskEnum.Numeric
        Me.Grid.Column(Me.igyCostoUnitario).DecimalLength = Empresa_Sistema.DECIMALES_PRECIO
        Me.Grid.Column(Me.igyCostoUnitario).Alignment = FlexCell.AlignmentEnum.RightCenter

        Me.Grid.Column(Me.igyUtilidad).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
        Me.Grid.Column(Me.igyUtilidad).Mask = FlexCell.MaskEnum.Numeric
        Me.Grid.Column(Me.igyUtilidad).DecimalLength = Empresa_Sistema.DECIMALES_PRECIO
        Me.Grid.Column(Me.igyUtilidad).Alignment = FlexCell.AlignmentEnum.RightCenter

        Me.Grid.Column(Me.igyAcumuladoUtilidad).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
        Me.Grid.Column(Me.igyAcumuladoUtilidad).Mask = FlexCell.MaskEnum.Numeric
        Me.Grid.Column(Me.igyAcumuladoUtilidad).DecimalLength = Empresa_Sistema.DECIMALES_PRECIO
        Me.Grid.Column(Me.igyAcumuladoUtilidad).Alignment = FlexCell.AlignmentEnum.RightCenter

        Me.Grid.Column(Me.igyAcumuladoVenta).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
        Me.Grid.Column(Me.igyAcumuladoVenta).Mask = FlexCell.MaskEnum.Numeric
        Me.Grid.Column(Me.igyAcumuladoVenta).DecimalLength = Empresa_Sistema.DECIMALES_PRECIO
        Me.Grid.Column(Me.igyAcumuladoVenta).Alignment = FlexCell.AlignmentEnum.RightCenter

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
        Me.Grid.Column(Me.igyUtilidadBruta).Visible = True
        Me.Grid.Column(Me.igyUtilidadBrutaPorcentaje).Visible = True

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
        Me.Grid.Column(Me.igyUtilidadBruta).Locked = True
        Me.Grid.Column(Me.igyUtilidadBrutaPorcentaje).Locked = True
    End Sub

    Private Sub FormateaGrid2()
        Me.Grid.Column(Me.igyPTCCodigo).Width = 70
        Me.Grid.Column(Me.igyPTCDescripcion).Width = 300
        Me.Grid.Column(Me.igyPTCVenta).Width = 100
        Me.Grid.Column(Me.igyPTCPorcParticipacion).Width = 80
        Me.Grid.Column(Me.igyPTCPorcAcumulada).Width = 80
        Me.Grid.Column(Me.igyPTCVentaNetaDolares).Width = 100
        Me.Grid.Column(Me.igyPTCVentaNetaPesos).Width = 100
        Me.Grid.Column(Me.igyPTCPrecioPromDolares).Width = 80
        Me.Grid.Column(Me.igyPTCPrecioPromPesos).Width = 80
        'Me.Grid.Column(Me.igyImporteTotalPesos).Width = 80

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

    End Sub

    Public Sub Totales()
        If Me.ModoAgrupado = enumModoAgrupado.PRODUCTOS Then
            Me.txtSum1.Text = FormatNumber(FG_Grid_SumaCol(Me.Grid, CShort(Me.igyCantidad)), 0)
            Me.txtSum4.Text = FormatImporteContable(FG_Grid_SumaCol(Me.Grid, CShort(Me.igyVenta)))
            Me.txtSum2.Text = FormatImporteContable(CDbl(Me.Grid.Cell(1, Me.igyCosto).Text))
        Else
            'Me.txtSum1.Text = FormatImporteContable(FG_Grid_SumaCol(Me.Grid, CShort(Me.igyCantidad)))
            'Me.txtSum3.Text = FormatImporteContable(CDbl(Me.Grid.Cell(1, Me.igyPTCVentaNetaDolares).Text))
            'Me.txtSum4.Text = FormatImporteContable(Me.Grid.Cell(2, Me.igyPTCVentaNetaPesos).Text)
            'Me.txtSum4.Text = FormatImporteContable(FG_Grid_SumaCol(Me.Grid, CShort(Me.igyCantidad)))
            'Me.txtSum5.Text = FormatImporteContable(FG_Grid_SumaCol(Me.Grid, CShort(Me.igyCantidad)))
            'Me.txtSum6.Text = FormatImporteContable(CDbl(Me.Grid.Cell(1, Me.igyPTCVentaNetaPesos).Text))
        End If
    End Sub

    Private Function Validar() As Boolean
        If Me.RbtnCategoria.Checked = True Then
            If txtLEN(Me.TxtCategoria.Text) = False Then
                MsgBox("Capture una categoría.", MsgBoxStyle.Exclamation, Me.Text)
                Me.TxtCategoria.Focus()
                Return False
            End If
        End If

        If Me.RbtnPorcentaje.Checked = True Then
            If txtLEN(Me.TxtPorcentaje.Text) = False Then
                MsgBox("Capture un porcentaje.", MsgBoxStyle.Exclamation, Me.Text)
                Me.TxtPorcentaje.Focus()
                Return False
            End If
        End If

        If txtLEN(Me.TxtUtilidadMaxima.Text) = False Then
            MsgBox("Capture la utilidad maxima.", MsgBoxStyle.Exclamation, Me.Text)
            Me.TxtUtilidadMaxima.Focus()
            Return False
        End If

        Return True
    End Function

    Public Sub Consultar()
        Dim dt As New DataTable
        Try
            If txtLEN(Me.TxtCliente.Text) = True Then
                Me.oClientes = New Class_CatClientes(Me.TxtCliente.Text)
                If Me.oClientes.Existe = False Then
                    MsgBox("El cliente no existe.", MsgBoxStyle.Information, Me.Text)
                    Me.TxtCliente.Focus()
                    Exit Sub
                Else
                    Me.lblNombreCliente.Text = Me.oClientes.NOMBRE_CLIENTE.ToString
                End If
            End If

            If Me.ValidarPeriodo = False Then
                Exit Sub
            End If

            If Me.Validar() = False Then

                Exit Sub
            End If

            Dim sqlParametro As New SqlParameter

            If Me.ModoAgrupado = enumModoAgrupado.PRODUCTOS Then
                'Using da As New SqlDataAdapter("MP_RPT_Q_VENTAS_TOP_PRODUCTOS", Empresa_Sistema.conexion)
                '    da.SelectCommand.CommandType = CommandType.StoredProcedure
                '    dt = New DataTable
                '    With da.SelectCommand
                '        .Parameters.Add("@CODIGO_CLIENTE", SqlDbType.NVarChar, 8) : sqlParametro.Value = Me.TxtCliente.Text
                '        .Parameters.Add("@CODIGO_DOCUMENTO", SqlDbType.NVarChar, 10) : sqlParametro.Value = Me.CboDocumento.SelectedValue
                '        .Parameters.Add("@FECHA1", SqlDbType.NVarChar, 20) : sqlParametro.Value = Format(Me.DtFechaDesde.Value, "yyyy-dd-MM")
                '        .Parameters.Add("@FECHA2", SqlDbType.NVarChar, 20) : sqlParametro.Value = Format(Me.DtFechaHasta.Value, "yyyy-dd-MM")
                '        .Parameters.Add("@CODIGO_ZONA", SqlDbType.NVarChar, 2) : sqlParametro.Value = Me.CboZona.SelectedValue.ToString
                '        .Parameters.Add("@PORCENTAJE", SqlDbType.SmallInt) : sqlParametro.Value = CInt(Me.TxtPorcentaje.Text)
                '        .Parameters.Add("@DESCRIPCION", SqlDbType.NVarChar, 30) : sqlParametro.Value = Me.TxtDescripcion.Text.ToUpper
                '        .Parameters.Add("@MIN", SqlDbType.NVarChar, 4) : sqlParametro.Value = Me.TxtMin.Text
                '        .Parameters.Add("@TIPO_PAGO", SqlDbType.NVarChar, 1) : sqlParametro.Value = Me.cboTipoPago.SelectedValue.ToString
                '        .Parameters.Add("@UTILIDAD_MAXIMA", SqlDbType.SmallInt) : sqlParametro.Value = CInt(Me.TxtUtilidadMaxima.Text)
                '        .Parameters.Add("@CATEGORIA", SqlDbType.NVarChar, 4) : sqlParametro.Value = Me.TxtCategoria.Text
                '        .Parameters.Add("@FILTRAR_VALOR", SqlDbType.NVarChar, 1) : sqlParametro.Value = IIf(Me.RbtnCategoria.Checked = True, "C", "P")
                '        .Parameters.Add("@CODIGOS_PRODUCTOS", SqlDbType.NVarChar, 2000) : sqlParametro.Value = Me.CboZona.SelectedValue.ToString
                '        .Parameters.Add("@ORDEN", SqlDbType.NVarChar, 30) : sqlParametro.Value = Me.CboZona.SelectedValue.ToString
                '        '.Parameters.Add("@COD_USU_EJECUTO", SqlDbType.NVarChar, 2) : sqlParametro.Value = 1 'Usuario.Codigo_Usuario.ToString
                '        '.Parameters.Add("@SISTEMA", SqlDbType.NVarChar, 20) : sqlParametro.Value = "BS"
                '    End With

                '    da.Fill(dt)
                'End Using
                Using connection As SqlConnection = New SqlConnection(Empresa_Sistema.conexion)
                    Dim command As SqlCommand
                    Dim da As SqlDataAdapter

                    command = New SqlCommand("MP_RPT_Q_VENTAS_TOP_PRODUCTOS", connection)
                    command.CommandType = CommandType.StoredProcedure
                    da = New SqlDataAdapter(command)
                    dt = New DataTable
                    With command.Parameters
                        .Add(New SqlParameter("@CODIGO_CLIENTE", SqlDbType.NVarChar, 8)).Value = Me.TxtCliente.Text
                        .Add(New SqlParameter("@CODIGO_DOCUMENTO", SqlDbType.NVarChar, 10)).Value = Me.CboDocumento.SelectedValue.ToString
                        .Add(New SqlParameter("@FECHA1", SqlDbType.NVarChar, 20)).Value = Format(Me.DtFechaDesde.Value, "yyyy-dd-MM")
                        .Add(New SqlParameter("@FECHA2", SqlDbType.NVarChar, 20)).Value = Format(Me.DtFechaHasta.Value, "yyyy-dd-MM")
                        .Add(New SqlParameter("@CODIGO_ZONA", SqlDbType.NVarChar, 2)).Value = Me.CboZona.SelectedValue.ToString
                        .Add(New SqlParameter("@PORCENTAJE", SqlDbType.SmallInt)).Value = IIf(txtLEN(Me.TxtPorcentaje.Text), CInt(Me.TxtPorcentaje.Text), 0)
                        .Add(New SqlParameter("@DESCRIPCION", SqlDbType.NVarChar, 30)).Value = Me.TxtDescripcion.Text.ToUpper
                        .Add(New SqlParameter("@MIN", SqlDbType.NVarChar, 4)).Value = Me.TxtMin.Text
                        .Add(New SqlParameter("@TIPO_PAGO", SqlDbType.NVarChar, 1)).Value = Me.cboTipoPago.SelectedValue.ToString
                        .Add(New SqlParameter("@UTILIDAD_MAXIMA", SqlDbType.SmallInt)).Value = CInt(Me.TxtUtilidadMaxima.Text)
                        .Add(New SqlParameter("@CATEGORIA", SqlDbType.NVarChar, 4)).Value = Me.TxtCategoria.Text
                        .Add(New SqlParameter("@FILTRAR_VALOR", SqlDbType.NVarChar, 1)).Value = IIf(Me.RbtnCategoria.Checked = True, "C", "P")
                        .Add(New SqlParameter("@CODIGOS_PRODUCTOS", SqlDbType.NVarChar, 2000)).Value = Me.TxtCodigosProductos.Text.ToUpper
                        .Add(New SqlParameter("@ORDEN", SqlDbType.NVarChar, 30)).Value = Me.cboOrden.SelectedValue
                        .Add(New SqlParameter("@COD_USU_EJECUTO", SqlDbType.NVarChar, 2)).Value = Usuario.Codigo_Usuario.ToString
                        .Add(New SqlParameter("@SISTEMA", SqlDbType.NVarChar, 20)).Value = "BS"
                    End With

                    da.Fill(dt)

                End Using
            Else
                Using da As New SqlDataAdapter("MP_RPT_Q_TOPTEN_CLIENTES", Empresa_Sistema.conexion) 'Falta actualizar el stored
                    da.SelectCommand.CommandType = CommandType.StoredProcedure

                    With da.SelectCommand
                        '.Parameters.Add("@FECHA1_SEMANA", SqlDbType.NVarChar, 8) : sqlParametro.Value = Me.CboSemana1.Text
                        '.Parameters.Add("@FECHA2_SEMANA", SqlDbType.NVarChar, 8) : sqlParametro.Value = Me.CboSemana2.Text
                        .Parameters.Add("@FECHA1_DIA", SqlDbType.NVarChar, 20) : sqlParametro.Value = Format(Me.DtFechaDesde.Value, "yyyy-dd-MM")
                        .Parameters.Add("@FECHA2_DIA", SqlDbType.NVarChar, 20) : sqlParametro.Value = Format(Me.DtFechaHasta.Value, "yyyy-dd-MM")
                        '.Parameters.Add("@CODIGO_CULTIVO", SqlDbType.NVarChar, 4) : sqlParametro.Value = Me.cboCultivo.SelectedValue.ToString()
                        .Parameters.Add("@UNIDAD_VENTA", SqlDbType.NVarChar, 10) : sqlParametro.Value = Me._TopTenConsultaExteriorPresentacion.ToString
                        .Parameters.Add("@CODIGO_CLIENTE", SqlDbType.NVarChar, 8) : sqlParametro.Value = Me.TxtCliente.Text
                        '.Parameters.Add("@TIPO_CAMBIO", SqlDbType.Decimal) : sqlParametro.Value = valorNumerico(Me.txtTipoCambio.Text)
                        .Parameters.Add("@CODIGO_ZONA", SqlDbType.NVarChar, 2) : sqlParametro.Value = Me.CboZona.SelectedValue.ToString
                        '.Parameters.Add("@CODIGO_TIPO_MERCADO", SqlDbType.NVarChar, 4) : sqlParametro.Value = Me.cboMercado.SelectedValue.ToString
                    End With

                    da.Fill(dt)
                End Using
            End If

            dt.Columns.Remove("EMPRESA_NOMBRE")
            dt.Columns.Remove("EMPRESA_DOMICILIO")
            dt.Columns.Remove("EMPRESA_CIUDAD")
            dt.Columns.Remove("EMPRESA_ESTADO")
            dt.Columns.Remove("EMPRESA_RFC")
            dt.Columns.Remove("EMPRESA_TELEFONO")
            dt.Columns.Remove("IDTRANS")
            dt.Columns.Remove("FILTROS_TEXTO")

            If Me.ModoAgrupado = enumModoAgrupado.PRODUCTOS Then
                Me.Grid.Rows = 1
                For Each dRow As DataRow In dt.Rows
                    Me.Grid.AddItem(dRow(0).ToString & Chr(9) & dRow(1).ToString & Chr(9) & dRow(2).ToString & Chr(9) & dRow(3).ToString & Chr(9) & dRow(4).ToString & Chr(9) & _
                                    dRow(5).ToString & Chr(9) & dRow(6).ToString & Chr(9) & dRow(7).ToString & Chr(9) & dRow(8).ToString & Chr(9) & dRow(9).ToString & Chr(9) & _
                                    dRow(10).ToString & Chr(9) & dRow(11).ToString & Chr(9) & dRow(12).ToString & Chr(9) & dRow(13).ToString & Chr(9) & dRow(14).ToString & Chr(9) & _
                                    dRow(15).ToString & Chr(9))
                Next
            Else
                Me.Grid.Rows = 1
                For Each dRow As DataRow In dt.Rows
                    Me.Grid.AddItem(dRow(0).ToString & Chr(9) & dRow(1).ToString & Chr(9) & dRow(2).ToString & Chr(9) & dRow(3).ToString & Chr(9) & dRow(4).ToString & Chr(9) & _
                                    dRow(5).ToString & Chr(9) & dRow(6).ToString & Chr(9) & dRow(7).ToString & Chr(9) & dRow(8).ToString & Chr(9))
                Next
            End If

            If Me.Grid.Rows = 1 Then
                Me.Grid.Rows = 2
                Me.txtSum1.Text = FormatNumber(0)
                'Me.txtSum5.Text = FormatImporteContable(0)
                'Me.txtSum3.Text = FormatImporteContable(0)
                Me.txtSum4.Text = FormatImporteContable(0)
                Me.txtSum2.Text = FormatImporteContable(0)
            Else
                Me.Totales()
            End If

            dt.Dispose()
            'Me.Totales()

        Catch ex As Exception
            HandleError(Me.Name, "Consultar", ex)
        End Try
    End Sub


    Private Sub Imprimir()
        Dim FormatoDeReporte As String = ""
        Dim Rpt As ReportDocument
        Rpt = New ReportDocument
        Dim oReporte As New Class_Reporte
        Try
            If txtLEN(Me.TxtCliente.Text) = True Then
                Me.oClientes = New Class_CatClientes(Me.TxtCliente.Text)
                If Me.oClientes.Existe = False Then
                    MsgBox("El cliente no existe.", MsgBoxStyle.Information, Me.Text)
                    Me.TxtCliente.Focus()
                    Exit Sub
                End If
            End If

            If Me.ValidarPeriodo = False Then
                Exit Sub
            End If
            If Me.ModoAgrupado = enumModoAgrupado.PRODUCTOS Then

                FormatoDeReporte = "RPT_MP_Q_VENTAS_TOP_PRODUCTOS"

                oReporte = New Class_Reporte(FormatoDeReporte, Rpt)
                Rpt.SetParameterValue("@CODIGO_CLIENTE", Me.TxtCliente.Text)
                Rpt.SetParameterValue("@CODIGO_DOCUMENTO", Me.CboDocumento.SelectedValue)
                Rpt.SetParameterValue("@FECHA1", Format(Me.DtFechaDesde.Value, "yyyy-dd-MM"))
                Rpt.SetParameterValue("@FECHA2", Format(Me.DtFechaHasta.Value, "yyyy-dd-MM"))
                Rpt.SetParameterValue("@CODIGO_ZONA", Me.CboZona.SelectedValue.ToString())
                Rpt.SetParameterValue("@PORCENTAJE", CInt(Me.TxtPorcentaje.Text))
                Rpt.SetParameterValue("@DESCRIPCION", Me.TxtDescripcion.Text.ToUpper)
                Rpt.SetParameterValue("@MIN", CInt(Me.TxtMin.Text))
                Rpt.SetParameterValue("@TIPO_PAGO", Me.cboTipoPago.SelectedValue.ToString)
                Rpt.SetParameterValue("@UTILIDAD_MAXIMA", CInt(Me.TxtUtilidadMaxima.Text))
                Rpt.SetParameterValue("@CATEGORIA", Me.TxtCategoria.Text)
                Rpt.SetParameterValue("@FILTRAR_VALOR", IIf(Me.RbtnCategoria.Checked = True, "C", "P"))
                Rpt.SetParameterValue("@CODIGOS_PRODUCTOS", Me.TxtCodigosProductos.Text.ToUpper)
                Rpt.SetParameterValue("@ORDEN", Me.cboOrden.SelectedValue)
                Rpt.SetParameterValue("@COD_USU_EJECUTO", Usuario.Codigo_Usuario.ToString)
                Rpt.SetParameterValue("@SISTEMA", "BS")
            Else
                FormatoDeReporte = "RPT_MP_Q_TOPTEN_CLIENTES" 'Falta actualizar el stored

                oReporte = New Class_Reporte(FormatoDeReporte, Rpt)
                'Rpt.SetParameterValue("@FECHA1_SEMANA", Me.CboSemana1.Text)
                'Rpt.SetParameterValue("@FECHA2_SEMANA", Me.CboSemana2.Text)
                Rpt.SetParameterValue("@FECHA1_DIA", Format(Me.DtFechaDesde.Value, "yyyy-dd-MM"))
                Rpt.SetParameterValue("@FECHA2_DIA", Format(Me.DtFechaHasta.Value, "yyyy-dd-MM"))
                'Rpt.SetParameterValue("@CODIGO_CULTIVO", Me.cboCultivo.SelectedValue.ToString())
                Rpt.SetParameterValue("@UNIDAD_VENTA", Me._TopTenConsultaExteriorPresentacion.ToString)
                Rpt.SetParameterValue("@CODIGO_CLIENTE", Me.TxtCliente.Text)
                'Rpt.SetParameterValue("@TIPO_CAMBIO", valorNumerico(Me.txtTipoCambio.Text))
                Rpt.SetParameterValue("@CODIGO_ZONA", Me.CboZona.SelectedValue)
                'Rpt.SetParameterValue("@CODIGO_TIPO_MERCADO", Me.cboMercado.SelectedValue)
            End If

            Dim frm As New Reporte(Rpt)
            frm.CRViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            frm.Show()
        Catch ex As Exception
            HandleError(Me.Name, "Consultar", ex)
        Finally
            oReporte = Nothing
        End Try
    End Sub

    Private Function ValidarPeriodo() As Boolean
        Me.DtFechaDesde.Enabled = False
        Me.DtFechaDesde.Enabled = True

        Me.DtFechaHasta.Enabled = False
        Me.DtFechaHasta.Enabled = True

        If Me.DtFechaDesde.Value > Me.DtFechaHasta.Value Then
            MsgBox("Rango de fechas inválidas.", MsgBoxStyle.Exclamation, Me.Name)
            Me.DtFechaDesde.Focus()
            Exit Function
        End If
        ValidarPeriodo = True
    End Function

    Private Sub cboCultivo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCliente.KeyPress, TxtCodigosProductos.KeyPress, TxtDescripcion.KeyPress, TxtCategoria.KeyPress, TxtPorcentaje.KeyPress, TxtMin.KeyPress, TxtUtilidadMaxima.KeyPress, DtFechaDesde.KeyPress, DtFechaHasta.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub cboCultivo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtFechaDesde.KeyDown, CboZona.KeyDown, TxtDescripcion.KeyDown, TxtPorcentaje.KeyDown, TxtMin.KeyDown, TxtUtilidadMaxima.KeyDown, cboTipoPago.KeyDown, CboDocumento.KeyDown, cboOrden.KeyDown
        If e.KeyCode = Keys.Return Then
            txtTAB(e)
        End If
    End Sub

    Private Sub dtFechaHaste_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtFechaHasta.KeyDown
        If e.KeyCode = Keys.Return Then
            tsbConsultar.PerformClick()
        End If
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub

    Private Sub TxtCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCliente.KeyDown
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
    End Sub

    Private Sub TxtCategoria_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCategoria.KeyDown
        Dim oCategoria As New Class_CatCategorias
        Dim sText As String
        Select Case e.KeyCode
            Case Keys.F6
Buscar:
                sText = oCategoria.BusquedaVisual_PorDescripcion
                If txtLEN(sText) = True Then Me.TxtCategoria.Text = sText
            Case Keys.Enter
                oCategoria = New Class_CatCategorias(Me.TxtCategoria.Text)
                If oCategoria.Existe = False Then
                    GoTo Buscar : Exit Sub
                End If

        End Select
        txtTAB(e)
    End Sub

    Private Sub TxtCodigosProductosKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodigosProductos.KeyDown
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
    End Sub

    Private Sub RbtnCategoria_CheckedChanged(sender As Object, e As EventArgs) Handles RbtnCategoria.CheckedChanged
        If Me.RbtnCategoria.Checked = True Then
            Me.TxtCategoria.Enabled = True
            Me.TxtPorcentaje.Enabled = False
        Else
            Me.TxtCategoria.Enabled = False
            Me.TxtPorcentaje.Enabled = True
        End If
    End Sub

    Private Sub txtNumerosEnterosKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMin.KeyPress, TxtUtilidadMaxima.KeyPress, TxtCategoria.KeyPress, TxtPorcentaje.KeyPress
        txtSoloNumerosEnteros(e)
        txtNoBeep(e)
    End Sub

    'Private Sub txtTipoCambio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    '    If e.KeyCode = Keys.Enter Then
    '        Me.tsbConsultar.PerformClick()
    '    End If
    'End Sub

    'Private Sub txtTipoCambio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    '    Dim txt As TextBox = CType(sender, TextBox)
    '    txtSoloNumerosDecimales(e, txt.Text)
    '    txtNoBeep(e)
    'End Sub

    Private Sub CboSemana1_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'Dim sql As Class_find
        'sql = New Class_find("SELECT FECHA1,FECHA2 FROM EMB_CAT_RANGOS_LOTES_MASTRONARDI " & _
        '"WHERE REPLACE(LEFT(CAST(((NUMERO_SEMANA/100.00)+AÑO) AS NVARCHAR),7),'.','-')='" & Me.CboSemana1.Text.ToString & "'")
        'If txtLEN(sql.Result1) = True Then
        '    Me.DtFechaDesde.Value = CDate(sql.Result1)
        'End If
    End Sub

    Private Sub CboSemana2_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'Dim sql As Class_find
        'sql = New Class_find("SELECT FECHA2 FROM EMB_CAT_RANGOS_LOTES_MASTRONARDI " & _
        '"WHERE REPLACE(LEFT(CAST(((NUMERO_SEMANA/100.00)+AÑO) AS NVARCHAR),7),'.','-')='" & Me.CboSemana2.Text.ToString & "'")
        'If txtLEN(sql.Result1) = True Then
        '    Me.DtFechaHasta.Value = CDate(sql.Result1)
        'End If
    End Sub

    'Private Sub DtFechaDesde_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DtFechaDesde.KeyPress
    '    Dim sql As Class_find
    '    sql = New Class_find("select CAST(AÑO AS NVARCHAR) + '-' +  RIGHT('0' + CAST(NUMERO_SEMANA AS NVARCHAR),2) from EMB_CAT_RANGOS_LOTES_MASTRONARDI where '" & Format(Me.DtFechaDesde.Value, "yyyy-dd-MM").ToString & "' BETWEEN FECHA1 and FECHA2 ")
    '    If txtLEN(sql.Result1) = True Then
    '        Me.CboSemana1.Text = sql.Result1
    '    End If
    'End Sub

    'Private Sub DtFechaHasta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DtFechaHasta.KeyPress
    '    Dim sql As Class_find

    '    sql = New Class_find("select CAST(AÑO AS NVARCHAR) + '-' +  RIGHT('0' + CAST(NUMERO_SEMANA AS NVARCHAR),2) from EMB_CAT_RANGOS_LOTES_MASTRONARDI where '" & Format(Me.DtFechaHasta.Value, "yyyy-dd-MM").ToString & "' BETWEEN FECHA1 and FECHA2 ")
    '    If txtLEN(sql.Result1) = True Then
    '        Me.CboSemana2.Text = sql.Result1
    '    End If
    'End Sub

    'Private Sub DtFechaDesde_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DtFechaDesde.ValueChanged
    '    Dim sql As Class_find
    '    sql = New Class_find("select CAST(AÑO AS NVARCHAR) + '-' +  RIGHT('0' + CAST(NUMERO_SEMANA AS NVARCHAR),2) from EMB_CAT_RANGOS_LOTES_MASTRONARDI where '" & Format(Me.DtFechaDesde.Value, "yyyy-dd-MM").ToString & "' BETWEEN FECHA1 and FECHA2 ")
    '    If txtLEN(sql.Result1) = True Then
    '        Me.CboSemana1.Text = sql.Result1
    '    End If
    'End Sub

    'Private Sub DtFechaHasta_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DtFechaHasta.ValueChanged
    '    Dim sql As Class_find
    '    sql = New Class_find("select CAST(AÑO AS NVARCHAR) + '-' +  RIGHT('0' + CAST(NUMERO_SEMANA AS NVARCHAR),2) from EMB_CAT_RANGOS_LOTES_MASTRONARDI where '" & Format(Me.DtFechaHasta.Value, "yyyy-dd-MM").ToString & "' BETWEEN FECHA1 and FECHA2 ")
    '    If txtLEN(sql.Result1) = True Then
    '        Me.CboSemana2.Text = sql.Result1
    '    End If
    'End Sub
End Class