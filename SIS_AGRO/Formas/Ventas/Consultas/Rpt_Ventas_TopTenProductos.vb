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
    Private igyUtilidadPorcentaje As Short = 7
    Private igyPrecioUnitario As Short = 8
    Private igyCostoUnitario As Short = 9
    Private igyUtilidadUnitaria As Short = 10
    Private igyParticipacionUtilidad As Short = 11
    Private igyAcumuladoUtilidad As Short = 12
    Private igyParticipacionVenta As Short = 13
    Private igyAcumuladoVenta As Short = 14
#End Region

#Region "Columnas grid clientes"
    Private igyCtesCodigo As Short = 1
    Private igyCtesNombreCliente As Short = 2
    Private igyCtesCantidad As Short = 3
    Private igyCtesVenta As Short = 4
    Private igyCtesCosto As Short = 5
    Private igyCtesUtilidad As Short = 6
    Private igyCtesUtilidadPorcentaje As Short = 7
    Private igyCtesParticipacionUtilidad As Short = 8
    Private igyCtesAcumuladoUtilidad As Short = 9
    Private igyCtesParticipacionVenta As Short = 10
    Private igyCtesAcumuladoVenta As Short = 11
    Private igyCtesNumeroProductos As Short = 12
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
            If Me._ConsultaExterior = True Then
                'Me.DtFechaDesde.Value = CDate(Me._TopTenConsultaExteriorDia1)
                'Me.DtFechaHasta.Value = CDate(Me._TopTenConsultaExteriorDia2)
                'Me.TxtCliente.Text = Me._TopTenConsultaExteriorCliente.ToString
                'Me.CboZona.SelectedValue = Me._TopTenConsultaExteriorZona.ToString

                Me.GroupBox1.Enabled = False
                Me.Consultar()
            Else
                'Esto debe ir aquí para que no se pierdan la reutilización de los mismos controles sin usar variables, se hacen dos show, el 1ero incializa , el segundo ya no
                Me.Inicializa()
                Me.InicializaGrid()
                'Me.ocultarElementos()
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
        Try
            Dim Columna As Integer, Renglon As Integer

            Columna = Me.Grid.Selection.FirstCol
            Renglon = Me.Grid.Selection.FirstRow

            Dim Child As New Rpt_Ventas_TopTenProductos

            Select Case Me.ModoAgrupado
                Case enumModoAgrupado.PRODUCTOS
                    Child.ModoAgrupado = Rpt_Ventas_TopTenProductos.enumModoAgrupado.CLIENTES
                Case enumModoAgrupado.CLIENTES
                    Child.ModoAgrupado = Rpt_Ventas_TopTenProductos.enumModoAgrupado.PRODUCTOS
            End Select

            Child.StartPosition = FormStartPosition.CenterScreen
            Child.Show() 'Esto corre el form load una primera vez

            With Child
                .ConsultaExterior = True
                .TxtCliente.Text = Me.TxtCliente.Text
                .CboZona.SelectedValue = Me.CboZona.SelectedValue
                '.TxtDescripcion.Text = Me.TxtDescripcion.Text
                .TxtCodigosProductos.Text = Me.TxtCodigosProductos.Text
                .DtFechaDesde.Value = Me.DtFechaDesde.Value
                .DtFechaHasta.Value = Me.DtFechaHasta.Value
                '.chkFiltrarPorUtilidad.Checked = Me.chkFiltrarPorUtilidad.Checked
                '.rbMinimo.Checked = Me.rbMinimo.Checked
                '.rbMaximo.Checked = Me.rbMaximo.Checked
                '.txtPorcentajeUtilidad.Text = Me.txtPorcentajeUtilidad.Text
                '.txtUtilidadMaxima.Text = Me.txtUtilidadMaxima.Text
                .cboTipoPago.SelectedValue = Me.cboTipoPago.SelectedValue
                .cboOrden.Text = Me.cboOrden.Text
                .CboDocumento.SelectedValue = Me.CboDocumento.SelectedValue
            End With

            Select Case Me.ModoAgrupado
                Case enumModoAgrupado.PRODUCTOS
                    Child.ModoAgrupado = Rpt_Ventas_TopTenProductos.enumModoAgrupado.CLIENTES

                    If Renglon > 0 AndAlso Columna > 0 Then
                        Child.TxtCodigosProductos.Text = Me.Grid.Cell(Renglon, Me.igyCodigo).Text
                    End If

                Case enumModoAgrupado.CLIENTES
                    Child.ModoAgrupado = Rpt_Ventas_TopTenProductos.enumModoAgrupado.PRODUCTOS

                    If Renglon > 0 AndAlso Columna > 0 Then
                        Child.TxtCliente.Text = Me.Grid.Cell(Renglon, Me.igyCtesCodigo).Text
                    End If
            End Select

            Child.Visible = False 'Se ocupa para poder hacer show de nuevo ahora con dialog.
            Child.ShowDialog() 'Esto corre el form load por 2da vez.
            Child.Dispose()

        Catch ex As Exception
            HandleError(Me.Name, "Grid_DoubleClick", ex)
        End Try


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
            Me.DesplegarZona()
            Me.DesplegarDocumentos()
            Me.DesplegarOrden()
            Me.DesplegarTipoPago()

            Me.DtFechaDesde.Value = FechaActualINI()
            Me.DtFechaHasta.Value = Now
            Me.txtTipoCambio.Text = "0"

            Me.CboZona.SelectedValue = "T"

            Me.txtTotalCantidad.Text = FormatNumber(0, 0)
            Me.txtTotalVenta.Text = FormatImporteContable(0)
            Me.txtTotalCosto.Text = FormatImporteContable(0)
            Me.txtTotalUtilidad.Text = FormatImporteContable(0)

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

            Select Case Me.ModoAgrupado
                Case enumModoAgrupado.PRODUCTOS
                    Me.Grid.Cols = 15
                    Me.FormateaGridToptenProductos()
                Case enumModoAgrupado.CLIENTES
                    Me.Grid.Cols = 13
                    Me.FormateaGridToptenClientes()
            End Select

        Catch ex As Exception
            HandleError(Me.Name, "InicializaGrid", ex)
        End Try
    End Sub

    Private Sub FormateaGridToptenProductos()
        Try
            With Me.Grid
                .FrozenCols = 2 'Para que las columnas código y nombre queden estáticas sin moverse.

                .Column(Me.igyCodigo).Width = 70
                .Column(Me.igyDescripcion).Width = 300
                .Column(Me.igyCantidad).Width = 100
                .Column(Me.igyVenta).Width = 100
                .Column(Me.igyCosto).Width = 100
                .Column(Me.igyUtilidad).Width = 100
                .Column(Me.igyUtilidadPorcentaje).Width = 100
                .Column(Me.igyPrecioUnitario).Width = 100
                .Column(Me.igyCostoUnitario).Width = 100
                .Column(Me.igyUtilidadUnitaria).Width = 100
                .Column(Me.igyParticipacionUtilidad).Width = 100
                .Column(Me.igyAcumuladoUtilidad).Width = 100
                .Column(Me.igyParticipacionVenta).Width = 100
                .Column(Me.igyAcumuladoVenta).Width = 100
                '.Column(Me.igyUtilidadBruta).Width = 100
                '.Column(Me.igyUtilidadBrutaPorcentaje).Width = 100

                .Cell(0, Me.igyCodigo).Text = "Código"
                .Cell(0, Me.igyDescripcion).Text = "Descripción"
                .Cell(0, Me.igyCantidad).Text = "Cant."
                .Cell(0, Me.igyVenta).Text = "Venta"
                .Cell(0, Me.igyCosto).Text = "Costo"
                .Cell(0, Me.igyUtilidad).Text = "Utilidad"
                .Cell(0, Me.igyUtilidadPorcentaje).Text = "% Util."
                .Cell(0, Me.igyPrecioUnitario).Text = "Precio uni."
                .Cell(0, Me.igyCostoUnitario).Text = "Costo uni."
                .Cell(0, Me.igyUtilidadUnitaria).Text = "Utilidad uni."
                .Cell(0, Me.igyParticipacionUtilidad).Text = "Participacion uti."
                .Cell(0, Me.igyAcumuladoUtilidad).Text = "Acumulado uti."
                .Cell(0, Me.igyParticipacionVenta).Text = "Participacion vta."
                .Cell(0, Me.igyAcumuladoVenta).Text = "Acumulativo vta."
                '.Cell(0, Me.igyUtilidadBruta).Text = "Utilidad bruta"
                '.Cell(0, Me.igyUtilidadBrutaPorcentaje).Text = "% uti. bruta"

                .Column(Me.igyCantidad).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.igyCantidad).DecimalLength = 0
                .Column(Me.igyCantidad).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.igyVenta).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
                .Column(Me.igyVenta).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.igyVenta).DecimalLength = Empresa_Sistema.DECIMALES_PRECIO
                .Column(Me.igyVenta).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.igyCosto).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
                .Column(Me.igyCosto).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.igyCosto).DecimalLength = Empresa_Sistema.DECIMALES_PRECIO
                .Column(Me.igyCosto).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.igyUtilidad).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
                .Column(Me.igyUtilidad).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.igyUtilidad).DecimalLength = Empresa_Sistema.DECIMALES_PRECIO
                .Column(Me.igyUtilidad).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.igyUtilidadPorcentaje).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.igyPrecioUnitario).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
                .Column(Me.igyPrecioUnitario).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.igyPrecioUnitario).DecimalLength = Empresa_Sistema.DECIMALES_PRECIO
                .Column(Me.igyPrecioUnitario).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.igyCostoUnitario).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
                .Column(Me.igyCostoUnitario).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.igyCostoUnitario).DecimalLength = Empresa_Sistema.DECIMALES_PRECIO
                .Column(Me.igyCostoUnitario).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.igyUtilidadUnitaria).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
                .Column(Me.igyUtilidadUnitaria).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.igyUtilidadUnitaria).DecimalLength = Empresa_Sistema.DECIMALES_PRECIO
                .Column(Me.igyUtilidadUnitaria).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.igyParticipacionUtilidad).FormatString = "##0.00 %"
                .Column(Me.igyParticipacionUtilidad).Mask = FlexCell.MaskEnum.Numeric
                '.Column(Me.igyParticipacionUtilidad).DecimalLength = Empresa_Sistema.DECIMALES_PRECIO
                .Column(Me.igyParticipacionUtilidad).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.igyAcumuladoUtilidad).FormatString = "##0.00 %"
                .Column(Me.igyAcumuladoUtilidad).Mask = FlexCell.MaskEnum.Numeric
                '.Column(Me.igyAcumuladoUtilidad).DecimalLength = Empresa_Sistema.DECIMALES_PRECIO
                .Column(Me.igyAcumuladoUtilidad).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.igyParticipacionVenta).FormatString = "##0.00 %"
                .Column(Me.igyParticipacionVenta).Mask = FlexCell.MaskEnum.Numeric
                '.Column(Me.igyParticipacionVenta).DecimalLength = Empresa_Sistema.DECIMALES_PRECIO
                .Column(Me.igyParticipacionVenta).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.igyAcumuladoVenta).FormatString = "##0.00 %"
                .Column(Me.igyAcumuladoVenta).Mask = FlexCell.MaskEnum.Numeric
                '.Column(Me.igyAcumuladoVenta).DecimalLength = Empresa_Sistema.DECIMALES_PRECIO
                .Column(Me.igyAcumuladoVenta).Alignment = FlexCell.AlignmentEnum.RightCenter

                '.Column(Me.igyUtilidadBruta).Alignment = FlexCell.AlignmentEnum.RightCenter
                '.Column(Me.igyUtilidadBrutaPorcentaje).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Locked = True

            End With
        Catch ex As Exception
            HandleError(Me.Name, "FormateaGridToptenProductos", ex)
        End Try
    End Sub

    Private Sub FormateaGridToptenClientes()
        Try
            With Me.Grid
                .FrozenCols = 2 'Para que las columnas código y nombre queden estáticas sin moverse.

                .Column(Me.igyCtesCodigo).Width = 70
                .Column(Me.igyCtesNombreCliente).Width = 300
                .Column(Me.igyCtesCantidad).Width = 100
                .Column(Me.igyCtesVenta).Width = 100
                .Column(Me.igyCtesCosto).Width = 100
                .Column(Me.igyCtesUtilidad).Width = 100
                .Column(Me.igyCtesUtilidadPorcentaje).Width = 100
                .Column(Me.igyCtesParticipacionUtilidad).Width = 100
                .Column(Me.igyCtesAcumuladoUtilidad).Width = 100
                .Column(Me.igyCtesParticipacionVenta).Width = 100
                .Column(Me.igyCtesAcumuladoVenta).Width = 100
                .Column(Me.igyCtesNumeroProductos).Width = 100

                .Cell(0, Me.igyCtesCodigo).Text = "Código"
                .Cell(0, Me.igyCtesNombreCliente).Text = "Cliente"
                .Cell(0, Me.igyCtesCantidad).Text = "Cant."
                .Cell(0, Me.igyCtesVenta).Text = "Venta."
                .Cell(0, Me.igyCtesCosto).Text = "Costo"
                .Cell(0, Me.igyCtesUtilidad).Text = "Utilidad"
                .Cell(0, Me.igyCtesUtilidadPorcentaje).Text = "% Util."
                .Cell(0, Me.igyCtesParticipacionUtilidad).Text = "Participacion uti."
                .Cell(0, Me.igyCtesAcumuladoUtilidad).Text = "Acumulado uti."
                .Cell(0, Me.igyCtesParticipacionVenta).Text = "Participacion vta."
                .Cell(0, Me.igyCtesAcumuladoVenta).Text = "Acumulativo vta."
                .Cell(0, Me.igyCtesNumeroProductos).Text = "# Prods."

                .Column(Me.igyCtesCantidad).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.igyCtesCantidad).DecimalLength = 0
                .Column(Me.igyCtesCantidad).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.igyCtesVenta).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
                .Column(Me.igyCtesVenta).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.igyCtesVenta).DecimalLength = Empresa_Sistema.DECIMALES_PRECIO
                .Column(Me.igyCtesVenta).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.igyCtesCosto).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
                .Column(Me.igyCtesCosto).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.igyCtesCosto).DecimalLength = Empresa_Sistema.DECIMALES_PRECIO
                .Column(Me.igyCtesCosto).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.igyCtesUtilidad).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
                .Column(Me.igyCtesUtilidad).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.igyCtesUtilidad).DecimalLength = Empresa_Sistema.DECIMALES_PRECIO
                .Column(Me.igyCtesUtilidad).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.igyCtesUtilidadPorcentaje).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.igyCtesParticipacionUtilidad).FormatString = "##0.00 %"
                .Column(Me.igyCtesParticipacionUtilidad).Mask = FlexCell.MaskEnum.Numeric
                '.Column(Me.igyCtesParticipacionUtilidad).DecimalLength = Empresa_Sistema.DECIMALES_PRECIO
                .Column(Me.igyCtesParticipacionUtilidad).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.igyCtesAcumuladoUtilidad).FormatString = "##0.00 %"
                .Column(Me.igyCtesAcumuladoUtilidad).Mask = FlexCell.MaskEnum.Numeric
                '.Column(Me.igyCtesAcumuladoUtilidad).DecimalLength = Empresa_Sistema.DECIMALES_PRECIO
                .Column(Me.igyCtesAcumuladoUtilidad).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.igyCtesParticipacionVenta).FormatString = "##0.00 %"
                .Column(Me.igyCtesParticipacionVenta).Mask = FlexCell.MaskEnum.Numeric
                '.Column(Me.igyCtesParticipacionVenta).DecimalLength = Empresa_Sistema.DECIMALES_PRECIO
                .Column(Me.igyCtesParticipacionVenta).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.igyCtesAcumuladoVenta).FormatString = "##0.00 %"
                .Column(Me.igyCtesAcumuladoVenta).Mask = FlexCell.MaskEnum.Numeric
                '.Column(Me.igyCtesAcumuladoVenta).DecimalLength = Empresa_Sistema.DECIMALES_PRECIO
                .Column(Me.igyCtesAcumuladoVenta).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.igyCtesNumeroProductos).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Locked = True
            End With
        Catch ex As Exception
            HandleError(Me.Name, "FormateaGridToptenClientes", ex)
        End Try
    End Sub

    Public Sub Totales()
        Try
            Select Case Me.ModoAgrupado
                Case enumModoAgrupado.PRODUCTOS
                    Me.txtTotalCantidad.Text = FormatNumber(FG_Grid_SumaCol(Me.Grid, CShort(Me.igyCantidad)), 0)
                    Me.txtTotalVenta.Text = FormatImporteContable(FG_Grid_SumaCol(Me.Grid, CShort(Me.igyVenta)))
                    Me.txtTotalCosto.Text = FormatImporteContable(FG_Grid_SumaCol(Me.Grid, CShort(Me.igyCosto)))
                    Me.txtTotalUtilidad.Text = FormatImporteContable(FG_Grid_SumaCol(Me.Grid, CShort(Me.igyUtilidad)))
                Case enumModoAgrupado.CLIENTES
                    Me.txtTotalCantidad.Text = FormatNumber(FG_Grid_SumaCol(Me.Grid, CShort(Me.igyCtesCantidad)), 0)
                    Me.txtTotalVenta.Text = FormatImporteContable(FG_Grid_SumaCol(Me.Grid, CShort(Me.igyCtesVenta)))
                    Me.txtTotalCosto.Text = FormatImporteContable(FG_Grid_SumaCol(Me.Grid, CShort(Me.igyCtesCosto)))
                    Me.txtTotalUtilidad.Text = FormatImporteContable(FG_Grid_SumaCol(Me.Grid, CShort(Me.igyCtesUtilidad)))
            End Select

        Catch ex As Exception
            HandleError(Me.Name, "Totales", ex)
        End Try
    End Sub

    Private Function Validar() As Boolean
        Try
            If Me._ConsultaExterior = True Then
                Return True
            End If

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
                            .Add(New SqlParameter("@FILTRAR_POR_UTILIDAD", SqlDbType.Char, 1)).Value = Convert.ToInt32(Me.chkFiltrarPorUtilidad.Checked).ToString
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
                            .Add(New SqlParameter("@CODIGO_CLIENTE", SqlDbType.NVarChar, 8)).Value = Me.TxtCliente.Text
                            .Add(New SqlParameter("@CODIGO_DOCUMENTO", SqlDbType.NVarChar, 10)).Value = Me.CboDocumento.SelectedValue.ToString
                            .Add(New SqlParameter("@FECHA1", SqlDbType.NVarChar, 20)).Value = Format(Me.DtFechaDesde.Value, "yyyy-dd-MM")
                            .Add(New SqlParameter("@FECHA2", SqlDbType.NVarChar, 20)).Value = Format(Me.DtFechaHasta.Value, "yyyy-dd-MM")
                            .Add(New SqlParameter("@CODIGO_ZONA", SqlDbType.NVarChar, 30)).Value = Me.CboZona.SelectedValue.ToString
                            .Add(New SqlParameter("@DESCRIPCION", SqlDbType.NVarChar, 30)).Value = Me.TxtDescripcion.Text.ToUpper
                            .Add(New SqlParameter("@FILTRAR_POR_UTILIDAD", SqlDbType.Char, 1)).Value = Convert.ToInt32(Me.chkFiltrarPorUtilidad.Checked).ToString
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
                                    dRow("UTILIDAD").ToString & Chr(9) & dRow("UTILIDAD_PORCENTAJE").ToString & Chr(9) & dRow("PRECIO_UNITARIO").ToString & Chr(9) & dRow("COSTO_UNITARIO").ToString & Chr(9) & dRow("UTILIDAD_UNITARIA").ToString & Chr(9) &
                                   valorNumericoD(dRow("PARTICIPACION_UTILIDAD").ToString) / valorNumericoD("100.00") & Chr(9) &
                                   valorNumericoD(dRow("ACUMULADO_UTILIDAD").ToString) / valorNumericoD("100.00") & Chr(9) &
                                   valorNumericoD(dRow("PARTICIPACION_VENTA").ToString) / valorNumericoD("100.00") & Chr(9) &
                                   valorNumericoD(dRow("ACUMULADO_VENTA").ToString) / valorNumericoD("100.00") & Chr(9))
                Next
            Else
                For Each dRow As DataRow In dt.Rows
                    Me.Grid.AddItem(dRow("CODIGO_CLIENTE").ToString & Chr(9) & dRow("NOMBRE_CLIENTE").ToString & Chr(9) & dRow("CANTIDAD").ToString & Chr(9) & dRow("VENTA").ToString & Chr(9) & dRow("COSTO").ToString & Chr(9) &
                                    dRow("UTILIDAD").ToString & Chr(9) & dRow("UTILIDAD_PORCENTAJE").ToString & Chr(9) &
                                   valorNumericoD(dRow("PARTICIPACION_UTILIDAD").ToString) / valorNumericoD("100.00") & Chr(9) &
                                   valorNumericoD(dRow("ACUMULADO_UTILIDAD").ToString) / valorNumericoD("100.00") & Chr(9) &
                                   valorNumericoD(dRow("PARTICIPACION_VENTA").ToString) / valorNumericoD("100.00") & Chr(9) &
                                   valorNumericoD(dRow("ACUMULADO_VENTA").ToString) / valorNumericoD("100.00") & Chr(9) &
                                   dRow("NUMERO_PRODUCTOS").ToString)
                Next
            End If

            If Me.Grid.Rows = 1 Then
                Me.Grid.Rows = 2
                Me.txtTotalCantidad.Text = FormatNumber(0)
                Me.txtTotalVenta.Text = FormatImporteContable(0)
                Me.txtTotalCosto.Text = FormatImporteContable(0)
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
                    FormatoDeReporte = "RPT_MP_Q_TOPTEN_PRODUCTOS" ' "RPT_MP_Q_VENTAS_TOP_PRODUCTOS"

                    oReporte = New Class_Reporte(FormatoDeReporte, Rpt)

                    Rpt.SetParameterValue("@CODIGO_CLIENTE", Me.TxtCliente.Text)
                    Rpt.SetParameterValue("@CODIGO_DOCUMENTO", Me.CboDocumento.SelectedValue)
                    Rpt.SetParameterValue("@FECHA1", Format(Me.DtFechaDesde.Value, "yyyy-dd-MM"))
                    Rpt.SetParameterValue("@FECHA2", Format(Me.DtFechaHasta.Value, "yyyy-dd-MM"))
                    Rpt.SetParameterValue("@CODIGO_ZONA", Me.CboZona.SelectedValue.ToString())
                    Rpt.SetParameterValue("@DESCRIPCION", Me.TxtDescripcion.Text.ToUpper)
                    Rpt.SetParameterValue("@FILTRAR_POR_UTILIDAD", Convert.ToInt32(Me.chkFiltrarPorUtilidad.Checked).ToString)
                    Rpt.SetParameterValue("@TIPO_UTILIDAD", IIf(Me.rbMinimo.Checked = True, "MINIMA", "MAXIMA").ToString)
                    Rpt.SetParameterValue("@PORCENTAJE_UTILIDAD", valorNumericoD(Me.txtPorcentajeUtilidad.Text))
                    Rpt.SetParameterValue("@TIPO_PAGO", Me.cboTipoPago.SelectedValue.ToString)
                    Rpt.SetParameterValue("@UTILIDAD_MAXIMA", CInt(Me.txtUtilidadMaxima.Text))
                    Rpt.SetParameterValue("@CODIGOS_PRODUCTOS", Me.TxtCodigosProductos.Text.ToUpper)
                    Rpt.SetParameterValue("@ORDEN", Me.cboOrden.SelectedValue)

                Case enumModoAgrupado.CLIENTES
                    FormatoDeReporte = "RPT_MP_Q_TOPTEN_CLIENTES"

                    oReporte = New Class_Reporte(FormatoDeReporte, Rpt)

                    Rpt.SetParameterValue("@CODIGO_CLIENTE", Me.TxtCliente.Text)
                    Rpt.SetParameterValue("@CODIGO_DOCUMENTO", Me.CboDocumento.SelectedValue)
                    Rpt.SetParameterValue("@FECHA1", Format(Me.DtFechaDesde.Value, "yyyy-dd-MM"))
                    Rpt.SetParameterValue("@FECHA2", Format(Me.DtFechaHasta.Value, "yyyy-dd-MM"))
                    Rpt.SetParameterValue("@CODIGO_ZONA", Me.CboZona.SelectedValue.ToString())
                    Rpt.SetParameterValue("@DESCRIPCION", Me.TxtDescripcion.Text.ToUpper)
                    Rpt.SetParameterValue("@FILTRAR_POR_UTILIDAD", Convert.ToInt32(Me.chkFiltrarPorUtilidad.Checked).ToString)
                    Rpt.SetParameterValue("@TIPO_UTILIDAD", IIf(Me.rbMinimo.Checked = True, "MINIMA", "MAXIMO").ToString)
                    Rpt.SetParameterValue("@PORCENTAJE_UTILIDAD", Me.txtPorcentajeUtilidad.Text)
                    Rpt.SetParameterValue("@TIPO_PAGO", Me.cboTipoPago.SelectedValue.ToString)
                    Rpt.SetParameterValue("@UTILIDAD_MAXIMA", CInt(Me.txtUtilidadMaxima.Text))
                    Rpt.SetParameterValue("@CODIGOS_PRODUCTOS", Me.TxtCodigosProductos.Text.ToUpper)
                    Rpt.SetParameterValue("@ORDEN", Me.cboOrden.SelectedValue)
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