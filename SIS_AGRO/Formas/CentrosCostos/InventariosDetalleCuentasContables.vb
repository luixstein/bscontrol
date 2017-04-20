Option Strict On

Imports System.Data.SqlClient

Public Class InventariosDetalleCuentasContables

#Region "Campos"
    Private _FolioMovimientoInventario As String
    Private _IDAdicional As Integer
    Private _Importe As Double
    Private _CodigoArticulo As String

    Private bEditando As Boolean = False

    Private _dTablaPrepoliza As New DataTable
    Private bComboCargado As Boolean = False

    Private bFormaCargada As Boolean = False

#Region "Campos de sistema"
    Private _Conexion As SqlConnection
#End Region

#End Region

#Region "Columnas grid"
    'Private iGyIDAdicional As Integer = 1
    'Private iGyCodigoCultivo As Integer = 2
    'Private iGyNombreCultivo As Integer = 3
    'Private iGyHectareas As Integer = 4
    'Private iGyImporte As Integer = 5
    'Private iGyCuentaContable As Integer = 6
    'Private iGyNombreCuenta As Integer = 7
    'Private iGyCheck As Integer = 8
    'Private iGyCuentaParte1 As Integer = 9

    Private iGyIDAdicional As Integer = 1
    Private iGyCodigoCentroCosto As Integer = 2
    Private iGyNombreCentroCosto As Integer = 3
    Private iGyHectareas As Integer = 4
    Private iGyCantidad As Integer = 5
    Private iGyImporte As Integer = 6
    Private iGyCuentaContable As Integer = 7
    Private iGyNombreCuenta As Integer = 8
    Private iGyCheck As Integer = 9
    Private iGyCodigoCategoria As Integer = 10
    Private iGyCodigoConcepto As Integer = 11
#End Region

#Region "Propiedades"
    Public Property dTablaPrepoliza As DataTable
        Get
            Return Me._dTablaPrepoliza
        End Get
        Set(value As DataTable)
            Me._dTablaPrepoliza = value
        End Set
    End Property

    Public Property FolioMovimientoInventario As String
        Get
            Return Me._FolioMovimientoInventario
        End Get
        Set(value As String)
            Me._FolioMovimientoInventario = value
        End Set
    End Property

    Public Property IDAdicional As Integer
        Get
            Return Me._IDAdicional
        End Get
        Set(value As Integer)
            Me._IDAdicional = value
        End Set
    End Property

    Public Property Importe As Double
        Get
            Return Me._Importe
        End Get
        Set(value As Double)
            Me._Importe = value
        End Set
    End Property

    Public Property CodigoArticulo As String
        Get
            Return Me._CodigoArticulo
        End Get
        Set(value As String)
            Me._CodigoArticulo = value
        End Set
    End Property
#End Region

#Region "Opciones"
    Private Sub btnCalcular_Click(sender As Object, e As EventArgs) Handles btnCalcular.Click
        Me.Calcular()
    End Sub

    Private Sub btnChecarTodos_Click(sender As Object, e As EventArgs) Handles btnChecarTodos.Click
        Me.ChecarTodos()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If Me.GestionaGridPrePoliza() = True Then
            Me.Hide()
        End If
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        Me.txtTotalCantidad.Text = FormatCantidad(0).ToString
        Me.txtTotalImporte.Text = FormatImporteContable(0).ToString
        Me.EliminaRelacion(Me._IDAdicional)
        Me.ArticuloNuevo()
    End Sub
#End Region

#Region "Eventos de objetos"
    Private Sub InventariosDetalleCuentasContables_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Inicia()
    End Sub

    Private Sub InventariosDetalleCuentasContables_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = True 'Para que no se cierre nunca y exista en memoria desde donde fue llamada la forma
        Me.Hide()
    End Sub

    Private Sub Grid_CellChange(Sender As Object, e As FlexCell.Grid.CellChangeEventArgs) Handles Grid.CellChange
        If Me.bEditando = False AndAlso Me.bFormaCargada = True Then
            Select Case e.Col
                Case Me.iGyHectareas
                    'Si mueven el hectareaje hay que prorratear nuevamente
                    Me.Calcular()
                    'Aqui no hay Me.Totales() porque ya lo hace el Calcular
                Case Me.iGyCantidad
                    Me.CalcularPorCantidad()
                Case Me.iGyImporte
                    Me.Totales()
                Case Me.iGyCheck
                    Me.Calcular()
                    'Aqui no hay Me.Totales() porque ya lo hace el Calcular
            End Select
        End If
    End Sub

    Private Sub Grid_KeyDown(Sender As Object, e As KeyEventArgs) Handles Grid.KeyDown
        Dim Columna As Integer = Me.Grid.Selection.FirstCol, sText As String = ""
        Dim Renglon As Integer = Me.Grid.Selection.FirstRow
        Dim oCuenta As New Class_CatCuentas

        With Me.Grid
            Select Case e.KeyCode
                Case Keys.F6
buscar:
                    If Columna = Me.iGyCuentaContable Then
                        Renglon = .Selection.FirstRow

                        sText = oCuenta.BusquedaVisual_PorCodigoFiltrandoTipoOperacion()

                        If txtLEN(sText) = True Then
                            oCuenta = New Class_CatCuentas(sText)
                            .Cell(Renglon, Me.iGyCuentaContable).Text = sText
                            .Cell(Renglon, Me.iGyNombreCuenta).Text = oCuenta.NOMBRE_CUENTA
                        End If

                        oCuenta = Nothing
                    End If

                Case Keys.Return
                    If Columna = Me.iGyCuentaContable Then
                        sText = Me.Grid.Cell(Renglon, Me.iGyCuentaContable).Text

                        If txtLEN(sText) = True Then
                            oCuenta = New Class_CatCuentas(sText)
                            If oCuenta._Existe = True Then
                                .Cell(Renglon, Me.iGyCuentaContable).Text = sText
                                .Cell(Renglon, Me.iGyNombreCuenta).Text = oCuenta.NOMBRE_CUENTA
                            Else
                                .Cell(Renglon, Me.iGyCuentaContable).Text = ""
                                .Cell(Renglon, Me.iGyNombreCuenta).Text = ""
                                GoTo buscar : Exit Sub
                            End If
                        Else
                            .Cell(Renglon, Me.iGyCuentaContable).Text = ""
                            .Cell(Renglon, Me.iGyNombreCuenta).Text = ""
                            GoTo buscar : Exit Sub
                        End If
                    End If

            End Select
        End With
    End Sub

    'Private Sub cboConceptoProduccion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboConceptoProduccion.SelectedIndexChanged
    '    If Me.bComboCargado = True Then
    '        If Me.ExisteArticulo = True Then
    '            Dim dRow() As DataRow
    '            dRow = Me.dTablaPrepoliza.Select("IDAdicional=" & IDAdicional) 'Esto regresa un arreglo de rows

    '            'si cambio el concepto porque el que ya tenia, hay que borrar grid
    '            If Me.cboConceptoProduccion.SelectedValue.ToString <> dRow(0)("CodigoConceptoProduccion").ToString Then
    '                Me.EliminaRelacion(Me._IDAdicional)
    '                Me.ArticuloNuevo()
    '            End If
    '        Else
    '            'aqui no elimina relacion porque no existe, pero si hay que establecer como articulo new
    '            Me.ArticuloNuevo()
    '        End If
    '    End If
    'End Sub

    Private Sub cboCategoria_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCategoria.SelectedIndexChanged
        If Me.bComboCargado = True Then
            If Me.ExisteArticulo = True Then
                Dim dRow() As DataRow
                dRow = Me.dTablaPrepoliza.Select("IDAdicional=" & IDAdicional) 'Esto regresa un arreglo de rows

                'si cambio la categoria se borra de la tabla
                If Me.cboCategoria.SelectedValue.ToString <> dRow(0)("CODIGO_CATEGORIA").ToString Then
                    Me.EliminaRelacion(Me._IDAdicional)
                    Me.ArticuloNuevo()
                End If
            Else
                'aqui no elimina relacion porque no existe, pero si hay que establecer como articulo new
                Me.ArticuloNuevo()
            End If
        End If
    End Sub

    Private Sub cboConcepto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboConcepto.SelectedIndexChanged
        If Me.bComboCargado = True Then
            If Me.ExisteArticulo = True Then
                Dim dRow() As DataRow
                dRow = Me.dTablaPrepoliza.Select("IDAdicional=" & IDAdicional) 'Esto regresa un arreglo de rows

                'si cambio concepto se borra de la tabla
                If Me.cboConcepto.SelectedValue.ToString <> dRow(0)("CODIGO_CONCEPTO").ToString Then
                    Me.EliminaRelacion(Me._IDAdicional)
                    Me.ArticuloNuevo()
                End If
            Else
                'aqui no elimina relacion porque no existe, pero si hay que establecer como articulo new
                Me.ArticuloNuevo()
            End If
        End If
    End Sub
#End Region

#Region "Métodos y procedimientos"
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Public Sub New(ByVal sFolioMovimientoInventario As String)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion

        Me._FolioMovimientoInventario = sFolioMovimientoInventario
        Me.dTablaPrepoliza = Me.ObtenerDetalleCuentasContables
    End Sub

    Private Function ObtenerDetalleCuentasContables() As DataTable
        Dim dt As New DataTable
        Try
            'Using da As New SqlDataAdapter("SELECT R.ID_ADICIONAL IDAdicional,R.CODIGO_CULTIVO CodigoCultivo,U.NOMBRE_CULTIVO NombreCultivo,R.HAS Hectareas,R.IMPORTE," & _
            '                               "R.CUENTA_CONTABLE CuentaContable,DBO.FN_CONTABILIDAD_NOMBRE_CUENTA_NIVELES_COMPLETOS(R.CUENTA_CONTABLE) NombreCuenta,CAST('1' AS SMALLINT) [Check],R.Cuenta_Parte1 CuentaParte1,R.CODIGO_CONCEPTO_COSTO_PRODUCCION CodigoConceptoProduccion " & _
            '                               "FROM INVENTARIO_DETALLE_CUENTAS_CONTABLES R " & _
            '                               "INNER JOIN CAT_CULTIVOS U ON(R.CODIGO_CULTIVO=U.CODIGO_CULTIVO) " & _
            '                               "INNER JOIN CON_CAT_CUENTAS C ON(R.CUENTA_CONTABLE=C.CUENTA_CONTABLE) " & _
            '                               "WHERE FOLIO_MOVIMIENTO_INVENTARIO=@FOLIO_MOVIMIENTO_INVENTARIO ", Me._Conexion)

            Using da As New SqlDataAdapter("SELECT R.ID_ADICIONAL IDAdicional,R.CODIGO_CENTRO_COSTO,CC.NOMBRE_CENTRO_COSTO,R.HAS Hectareas,R.CANTIDAD,R.IMPORTE, " & _
                                            "R.CUENTA_CONTABLE CuentaContable,DBO.FN_CONTABILIDAD_NOMBRE_CUENTA_NIVELES_COMPLETOS(R.CUENTA_CONTABLE) NombreCuenta,CAST('1' AS SMALLINT) [Check], " & _
                                            "R.CODIGO_CATEGORIA,R.CODIGO_CONCEPTO " & _
                                            "FROM CENTRO_COSTOS_MOVIMIENTOS_DETALLE R " & _
                                            "INNER JOIN CON_CAT_CUENTAS C ON(R.CUENTA_CONTABLE=C.CUENTA_CONTABLE) " & _
                                            "INNER JOIN NOMINA_CAT_CENTROS_COSTOS CC ON(R.CODIGO_CENTRO_COSTO=CC.CODIGO_CENTRO_COSTO) " & _
                                            "WHERE R.FOLIO_MOVIMIENTO=@FOLIO_MOVIMIENTO_INVENTARIO ", Me._Conexion)

                da.SelectCommand.CommandType = CommandType.Text

                With da.SelectCommand
                    .Parameters.Add("@FOLIO_MOVIMIENTO_INVENTARIO", SqlDbType.NVarChar, 15).Value = Me._FolioMovimientoInventario
                End With

                da.Fill(dt)
            End Using

        Catch ex As Exception
            HandleError(Me.Name, "ObtenerDetalleCuentasContables", ex)
        Finally

        End Try
        Return dt
    End Function

    Private Sub Inicia()
        Try
            'If bComboCargado = False Then
            '    Me.DesplegarConceptoCostosProduccion()
            'End If

            If bComboCargado = False Then
                Me.DesplegarCategorias()
                Me.DesplegarConceptos()
                Me.bComboCargado = True
            End If

            'Inicializa para un artículo.
            Me.Grid.DataSource = Nothing
            Me.txtTotalHectareas.Text = "0"
            Me.txtTotalCantidad.Text = FormatCantidad(0).ToString
            Me.txtTotalImporte.Text = FormatImporteContable(0).ToString

            If Me.dTablaPrepoliza.Rows.Count > 0 Then 'Si hay cualquier artículo
                Me.RecargaArticuloPrevio()
            Else 'No se esta consultando uno previo

                Dim oArticulo As New Class_CatArticulos(Me._CodigoArticulo)

                Dim oFamilia As Class_CatFamilias
                Dim oLinea As Class_CatLineas

                If txtLEN(oArticulo.CODIGO_FAMILIA) = True Then
                    oFamilia = New Class_CatFamilias(oArticulo.CODIGO_FAMILIA)
                    Me.cboCategoria.SelectedValue = oFamilia.CODIGO_CATEGORIA
                End If

                If txtLEN(oArticulo.CODIGO_LINEA) = True Then
                    oLinea = New Class_CatLineas(oArticulo.CODIGO_LINEA)
                    Me.cboConcepto.SelectedValue = oLinea.CODIGO_CONCEPTO
                End If

                Me.CreaTablaVacia()
                Me.ArticuloNuevo()
                'Me.SeleccionaConceptoProduccion()
            End If

            Me.GridPrePoliza.DataSource = Me.dTablaPrepoliza 'Esto es para poder ver en un grid alterno como va quedando la tabla en general(hay que hacer visible el grid)

            Me.bFormaCargada = True
        Catch ex As Exception
            HandleError(Me.Name, "Inicia", ex)
        End Try
    End Sub

    'Private Sub DesplegarConceptoCostosProduccion()
    '    Try
    '        'Dim sql As New Class_find("SELECT CODIGO_CONCEPTO_COSTO_PRODUCCION, C.CODIGO_ARTICULO, C.CODIGO_FAMILIA from CAT_ARTICULOS C INNER JOIN CAT_FAMILIAS P ON(C.CODIGO_FAMILIA = P.CODIGO_FAMILIA) WHERE C.CODIGO_ARTICULO = '" & CodigoArticulo & "'")
    '        Dim oElementos As New Class_CatConceptoCostosProduccion
    '        With Me.cboConceptoProduccion
    '            .DisplayMember = "NOMBRE_CONCEPTO_COSTO_PRODUCCION"
    '            .ValueMember = "CODIGO_CONCEPTO_COSTO_PRODUCCION"
    '            Dim dView As New Data.DataView(oElementos.ObtenerElementos)
    '            dView.Sort = "NOMBRE_CONCEPTO_COSTO_PRODUCCION"
    '            .DataSource = dView
    '            'If Len(sql.Result1) > 0 Then
    '            '    Me.cboConceptoProduccion.SelectedValue = sql.Result1
    '            'Else
    '            Me.cboConceptoProduccion.SelectedIndex = -1
    '            'End If

    '            bComboCargado = True

    '        End With
    '    Catch ex As Exception
    '        HandleError(Me.Name, "DesplegarConceptoCostosProduccion", ex)
    '    End Try
    'End Sub

    'Private Sub SeleccionaConceptoProduccion()
    '    Dim sql As New Class_find("SELECT CODIGO_CONCEPTO_COSTO_PRODUCCION, C.CODIGO_ARTICULO, C.CODIGO_FAMILIA from CAT_ARTICULOS C INNER JOIN CAT_FAMILIAS P ON(C.CODIGO_FAMILIA = P.CODIGO_FAMILIA) WHERE C.CODIGO_ARTICULO = '" & CodigoArticulo & "'")
    '    If Len(sql.Result1) > 0 Then
    '        Me.cboConceptoProduccion.SelectedValue = sql.Result1
    '    Else
    '        Me.cboConceptoProduccion.SelectedIndex = -1
    '    End If
    'End Sub

    Private Sub FormateaGrid()
        Me.bFormaCargada = False
        Try
            'With Me.Grid
            '    .Column(Me.iGyCodigoCultivo).Locked = True
            '    .Column(Me.iGyCheck).CellType = FlexCell.CellTypeEnum.CheckBox

            '    .Column(Me.iGyIDAdicional).Visible = False '.Column(Me.iGyIDAdicional).Width = 20
            '    .Column(Me.iGyCodigoCultivo).Width = 50
            '    .Column(Me.iGyNombreCultivo).Width = 180
            '    .Column(Me.iGyHectareas).Width = 50
            '    .Column(Me.iGyImporte).Width = 80
            '    .Column(Me.iGyCuentaContable).Width = 100
            '    .Column(Me.iGyNombreCuenta).Width = 350
            '    .Column(Me.iGyCheck).Width = 50
            '    .Column(Me.iGyCuentaParte1).Visible = False

            '    .Cell(0, Me.iGyIDAdicional).Text = "IDAdicional"
            '    .Cell(0, Me.iGyCodigoCultivo).Text = "Código"
            '    .Cell(0, Me.iGyNombreCultivo).Text = "Cultivo"
            '    .Cell(0, Me.iGyHectareas).Text = "Has"
            '    .Cell(0, Me.iGyImporte).Text = "Importe"
            '    .Cell(0, Me.iGyCuentaContable).Text = "Cuenta"
            '    .Cell(0, Me.iGyNombreCuenta).Text = "Nombre"
            '    .Cell(0, Me.iGyCheck).Text = "Check"
            '    .Cell(0, Me.iGyCuentaParte1).Text = "CuentaParte1"

            '    .Column(Me.iGyHectareas).Alignment = FlexCell.AlignmentEnum.RightCenter
            '    .Column(Me.iGyImporte).Alignment = FlexCell.AlignmentEnum.RightCenter

            '    .Column(Me.iGyImporte).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
            'End With

            With Me.Grid
                .Column(Me.iGyNombreCentroCosto).Locked = True
                .Column(Me.iGyCuentaContable).Locked = True
                .Column(Me.iGyNombreCuenta).Locked = True

                .Column(Me.iGyCheck).CellType = FlexCell.CellTypeEnum.CheckBox

                .Column(Me.iGyIDAdicional).Visible = False
                .Column(Me.iGyCodigoCentroCosto).Width = 50
                .Column(Me.iGyNombreCentroCosto).Width = 300
                .Column(Me.iGyHectareas).Width = 50
                .Column(Me.iGyCantidad).Width = 80
                .Column(Me.iGyImporte).Width = 80
                .Column(Me.iGyCuentaContable).Width = 40
                .Column(Me.iGyNombreCuenta).Width = 280
                .Column(Me.iGyCheck).Width = 50
                .Column(Me.iGyCodigoCategoria).Visible = False
                .Column(Me.iGyCodigoConcepto).Visible = False

                .Cell(0, Me.iGyIDAdicional).Text = "IDAdicional"
                .Cell(0, Me.iGyCodigoCentroCosto).Text = "Código"
                .Cell(0, Me.iGyNombreCentroCosto).Text = "Centro costo"
                .Cell(0, Me.iGyHectareas).Text = "Has"
                .Cell(0, Me.iGyCantidad).Text = "Cantidad"
                .Cell(0, Me.iGyImporte).Text = "Importe"
                .Cell(0, Me.iGyCuentaContable).Text = "Cuenta"
                .Cell(0, Me.iGyNombreCuenta).Text = "Nombre"
                .Cell(0, Me.iGyCheck).Text = "Check"

                .Column(Me.iGyHectareas).Alignment = FlexCell.AlignmentEnum.RightCenter
                .Column(Me.iGyImporte).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGyCantidad).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyCantidad).DecimalLength = Empresa_Sistema.DECIMALES_CANTIDAD
                .Column(Me.iGyCantidad).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGyImporte).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
                .Column(Me.iGyImporte).Locked = True

            End With
        Catch ex As Exception
            HandleError(Me.Name, "FormateaGrid", ex)
        Finally
            Me.bFormaCargada = True
        End Try
    End Sub

    Private Sub ArticuloNuevo() 'Se llamaba GetProyectoSiembra
        Dim dTabla As New DataTable("ProyectoSiembra"), dA As SqlDataAdapter
        Try
            'dA = New SqlDataAdapter("SELECT " & Me._IDAdicional & " IDAdicional,CODIGO_CULTIVO Código,NOMBRE_CULTIVO Cultivo,HECTAREAS_SEMBRADAS Has,0.00 Importe,'' Cuenta,'' Nombre,'0' [Check],'5010'+CUENTA_CONTABLE_BASE PARTE1_CUENTA " & _
            '                        "FROM VW_PROYECTO_SIEMBRA_EXTENDIDO " & _
            '                        "WHERE ID_CON_EJERCICIO=" & Plaza.ID_CON_EJERCICIO, Me._Conexion)

            dA = New SqlDataAdapter("SELECT " & Me._IDAdicional & " IDAdicional,CC.CODIGO_CENTRO_COSTO,CC.NOMBRE_CENTRO_COSTO,ISNULL(PV.HECTAREAS_SEMBRADAS,1) Has,0.000 CANTIDAD,0.00 IMPORTE,'' CUENTA_CONTABLE,'' NOMBRE_CUENTA,'0' [Check], " & _
                                    "'' CODIGO_CATEGORIA,'' CODIGO_CONCEPTO " & _
                                    "FROM NOMINA_CAT_CENTROS_COSTOS CC " & _
                                    "LEFT JOIN VW_PROYECTO_SIEMBRA_EXTENDIDO PV ON(CC.CODIGO_CENTRO_COSTO=PV.CODIGO_CENTRO_COSTO AND PV.ID_CON_EJERCICIO=" & Plaza.ID_CON_EJERCICIO & ") " & _
                                    "WHERE CC.ESTATUS_CENTRO_COSTO='A' " & _
                                    "ORDER BY CC.NOMBRE_CENTRO_COSTO", Me._Conexion)


            dA.Fill(dTabla)
            dA.Dispose()

            Me.Grid.AutoRedraw = False
            Me.Grid.DataSource = dTabla

            Me.Grid.Row(Me.Grid.Rows - 1).Locked = True

            Me.FormateaGrid()

            Me.Grid.AutoRedraw = True
            Me.Grid.Refresh()

        Catch ex As Exception
            HandleError(Me.Name, "ArticuloNuevo", ex)
        End Try
    End Sub

    Private Function Calcular() As Boolean
        Dim bResultado As Boolean = False
        Try
            Dim i As Integer, sCuenta As String = "", oCuenta As Class_CatCuentas, dSumaHectareas As Double = 0

            If Me.cboCategoria.SelectedIndex = -1 Then
                MsgBox("Seleccione la categoría por favor.", MsgBoxStyle.Exclamation, Me.Text)
                Me.cboCategoria.Focus()
                Return False
            End If

            If Me.cboConcepto.SelectedIndex = -1 Then
                MsgBox("Seleccione el concepto por favor.", MsgBoxStyle.Exclamation, Me.Text)
                Me.cboConcepto.Focus()
                Return False
            End If

            Dim oCategorias As New Class_CatCategorias(Me.cboCategoria.SelectedValue.ToString)

            sCuenta = oCategorias.CODIGO_TIPO_CATEGORIA

            Me.Grid.AutoRedraw = False
            Me.bEditando = True

            For i = 1 To Me.Grid.Rows - 1
                If Me.Grid.Cell(i, Me.iGyCheck).Text = "1" Then
                    'sCuenta = Me.Grid.Cell(i, Me.iGyCuentaParte1).Text & Me.cboConceptoProduccion.SelectedValue.ToString

                    oCuenta = New Class_CatCuentas(sCuenta)
                    Me.Grid.Cell(i, Me.iGyCuentaContable).Text = oCuenta.CUENTA_CONTABLE

                    If oCuenta._Existe = True Then
                        Me.Grid.Cell(i, Me.iGyNombreCuenta).Text = oCuenta.NOMBRE_CUENTA_NIVELES_COMPLETOS
                    Else
                        Me.Grid.Cell(i, Me.iGyNombreCuenta).Text = "ESTA CUENTA NO EXISTE !!!"
                    End If

                    dSumaHectareas += valorNumerico(Me.Grid.Cell(i, Me.iGyHectareas).Text)
                End If
            Next

            For i = 1 To Me.Grid.Rows - 1
                Me.Grid.Cell(i, Me.iGyCantidad).Text = "0.000"
                Me.Grid.Cell(i, Me.iGyImporte).Text = "0.00"
                If Me.Grid.Cell(i, Me.iGyCheck).Text = "1" Then
                    Me.Grid.Cell(i, Me.iGyCantidad).Text = FormatCantidad(((valorNumerico(Me.Grid.Cell(i, Me.iGyHectareas).Text) / dSumaHectareas) * valorNumerico(Me.txtCantidad.Text)))
                    Me.Grid.Cell(i, Me.iGyImporte).Text = (valorNumerico(Me.Grid.Cell(i, Me.iGyCantidad).Text) * valorNumerico(Me.txtCosto.Text)).ToString
                    'Me.Grid.Cell(i, Me.iGyImporte).Text = FormatImporteContable((Me._Importe / dSumaHectareas) * valorNumerico(Me.Grid.Cell(i, Me.iGyHectareas).Text), False)
                End If
            Next

            Me.Totales()

            Me.Grid.AutoRedraw = True
            Me.Grid.Refresh()

            bResultado = True
        Catch ex As Exception
            HandleError(Me.Name, "Calcular", ex)
        Finally
            Me.bEditando = False
        End Try

        Return bResultado
    End Function

    Private Sub CalcularPorCantidad()
        Try
            Dim i As Integer, sCuenta As String = "", oCuenta As Class_CatCuentas, dSumaHectareas As Double = 0
            Dim oCategorias As New Class_CatCategorias(Me.cboCategoria.SelectedValue.ToString)

            i = Me.Grid.ActiveCell.Row
            sCuenta = oCategorias.Codigo_Tipo_Categoria

            oCuenta = New Class_CatCuentas(sCuenta)
            Me.Grid.Cell(i, Me.iGyCuentaContable).Text = oCuenta.CUENTA_CONTABLE

            If oCuenta._Existe = True Then
                Me.Grid.Cell(i, Me.iGyNombreCuenta).Text = oCuenta.NOMBRE_CUENTA_NIVELES_COMPLETOS
            Else
                Me.Grid.Cell(i, Me.iGyNombreCuenta).Text = "ESTA CUENTA NO EXISTE !!!"
            End If

            Me.Grid.Cell(i, Me.iGyImporte).Text = (valorNumerico(Me.Grid.Cell(i, Me.iGyCantidad).Text) * valorNumerico(Me.txtCosto.Text)).ToString

            Me.Totales()
        Catch ex As Exception
            HandleError(Me.Name, "CalcularPorCantidad", ex)
        End Try
    End Sub

    Private Sub Totales()
        Try
            Me.txtTotalHectareas.Text = FG_Grid_SumaCol(Me.Grid, CShort(Me.iGyHectareas)).ToString
            Me.txtTotalCantidad.Text = FormatCantidad(FG_Grid_SumaCol(Me.Grid, CShort(Me.iGyCantidad))).ToString
            Me.txtTotalImporte.Text = FormatImporteContable(FG_Grid_SumaCol(Me.Grid, CShort(Me.iGyImporte))).ToString
        Catch ex As Exception
            HandleError(Me.Name, "Totales", ex)
        End Try
    End Sub

    Private Sub ChecarTodos()
        Try
            'If Me.cboConceptoProduccion.SelectedIndex = -1 Then
            '    MsgBox("Seleccione un concepto.", MsgBoxStyle.Exclamation, Me.Text)
            '    Me.cboConceptoProduccion.Focus()
            '    Exit Sub
            'End If

            If Me.cboCategoria.SelectedIndex = -1 Then
                MsgBox("Seleccione la categoría por favor.", MsgBoxStyle.Exclamation, Me.Text)
                Me.cboCategoria.Focus()
                Return
            End If

            If Me.cboConcepto.SelectedIndex = -1 Then
                MsgBox("Seleccione el concepto por favor.", MsgBoxStyle.Exclamation, Me.Text)
                Me.cboConcepto.Focus()
                Return
            End If

            Me.Grid.AutoRedraw = False
            Me.bEditando = True
            For i = 1 To Me.Grid.Rows - 1
                Me.Grid.Cell(i, Me.iGyCheck).Text = "1"
            Next
            Me.Calcular()
            Me.Grid.AutoRedraw = True
            Me.Grid.Refresh()
        Catch ex As Exception
            HandleError(Me.Name, "ChecarTodos", ex)
        Finally
            Me.bEditando = False
        End Try
    End Sub

    Private Sub CreaTablaVacia()
        Try
            Me.dTablaPrepoliza = New DataTable("TablaPrepoliza")

            'Me.dTablaPrepoliza.Columns.Add("IDAdicional", GetType(Integer))
            'Me.dTablaPrepoliza.Columns.Add("CodigoCultivo", GetType(String))
            'Me.dTablaPrepoliza.Columns.Add("NombreCultivo", GetType(String))
            'Me.dTablaPrepoliza.Columns.Add("Hectareas", GetType(String))
            'Me.dTablaPrepoliza.Columns.Add("Importe", GetType(Double))
            'Me.dTablaPrepoliza.Columns.Add("CuentaContable", GetType(String))
            'Me.dTablaPrepoliza.Columns.Add("NombreCuenta", GetType(String))
            'Me.dTablaPrepoliza.Columns.Add("Check", GetType(String))
            'Me.dTablaPrepoliza.Columns.Add("CuentaParte1", GetType(String))
            'Me.dTablaPrepoliza.Columns.Add("CodigoConceptoProduccion", GetType(String))

            Me.dTablaPrepoliza.Columns.Add("IDAdicional", GetType(Integer))
            Me.dTablaPrepoliza.Columns.Add("CODIGO_CENTRO_COSTO", GetType(String))
            Me.dTablaPrepoliza.Columns.Add("NOMBRE_CENTRO_COSTO", GetType(String))
            Me.dTablaPrepoliza.Columns.Add("Hectareas", GetType(String))
            Me.dTablaPrepoliza.Columns.Add("Cantidad", GetType(Double))
            Me.dTablaPrepoliza.Columns.Add("Importe", GetType(Double))
            Me.dTablaPrepoliza.Columns.Add("CuentaContable", GetType(String))
            Me.dTablaPrepoliza.Columns.Add("NombreCuenta", GetType(String))
            Me.dTablaPrepoliza.Columns.Add("Check", GetType(String))
            Me.dTablaPrepoliza.Columns.Add("CODIGO_CATEGORIA", GetType(String))
            Me.dTablaPrepoliza.Columns.Add("CODIGO_CONCEPTO", GetType(String))

            Me.dTablaPrepoliza.AcceptChanges()

        Catch ex As Exception
            HandleError(Me.Name, "CreaTablaVacia", ex)
        End Try
    End Sub

    Private Function GestionaGridPrePoliza() As Boolean
        Dim bResultado As Boolean = False
        Try
            Me.Totales()

            If valorNumerico(Me.txtCantidad.Text) <> valorNumerico(Me.txtTotalCantidad.Text) Then
                MsgBox("El total de la cantidad no es igual que la cantidad de la salida.", MsgBoxStyle.Exclamation, Me.Text)
                Exit Function
            End If

            Dim dDiferenciaImporte As Double
            dDiferenciaImporte = valorNumerico(Me.txtImporte.Text) - valorNumerico(Me.txtTotalImporte.Text)

            If Math.Abs(dDiferenciaImporte) > 1 Then
                MsgBox("El total del importe se pasa por mas de un peso sobre importe original.", MsgBoxStyle.Exclamation, Me.Text)
                Exit Function
            End If

            For i = 1 To Me.Grid.Rows - 1
                If Me.Grid.Cell(i, Me.iGyNombreCuenta).Text = "ESTA CUENTA NO EXISTE !!!" Then
                    MsgBox("La cuenta contable del renglón #" & i & " no existe.", MsgBoxStyle.Exclamation, Me.Text)
                    Return False
                End If
                If valorNumerico(Me.Grid.Cell(i, Me.iGyImporte).Text) > 0 Then
                    If Me.Grid.Cell(i, Me.iGyNombreCuenta).Text = "" Then
                        MsgBox("La cuenta contable del renglón #" & i & " no existe.", MsgBoxStyle.Exclamation, Me.Text)
                        Return False
                    End If
                End If
            Next

            Dim dRow As DataRow

            'Ya existian en memoria, se borran y se agregan otra vez por si los modificaron
            Me.EliminaRelacion(Me._IDAdicional)

            For i = 1 To Me.Grid.Rows - 1
                '    If txtLEN(Me.Grid.Cell(i, Me.iGyCodigoCultivo).Text) = True Then ' Se usan todos los renglones aunque no hayan chekeado
                '        dRow = Me.dTablaPrepoliza.NewRow

                '        dRow("IDAdicional") = Me._IDAdicional
                '        dRow("CodigoCultivo") = Me.Grid.Cell(i, Me.iGyCodigoCultivo).Text
                '        dRow("NombreCultivo") = Me.Grid.Cell(i, Me.iGyNombreCultivo).Text
                '        dRow("Hectareas") = Me.Grid.Cell(i, Me.iGyHectareas).Text
                '        dRow("Importe") = Me.Grid.Cell(i, Me.iGyImporte).Text
                '        dRow("CuentaContable") = Me.Grid.Cell(i, Me.iGyCuentaContable).Text
                '        dRow("NombreCuenta") = Me.Grid.Cell(i, Me.iGyNombreCuenta).Text
                '        dRow("Check") = Me.Grid.Cell(i, Me.iGyCheck).Text
                '        dRow("CuentaParte1") = Me.Grid.Cell(i, Me.iGyCuentaParte1).Text
                '        dRow("CodigoConceptoProduccion") = Me.cboConceptoProduccion.SelectedValue

                '        Me.dTablaPrepoliza.Rows.Add(dRow)

                '        'Me._GestionoRenglon = True
                '    End If


                If txtLEN(Me.Grid.Cell(i, Me.iGyCodigoCentroCosto).Text) = True Then ' Se usan todos los renglones aunque no hayan chekeado
                    dRow = Me.dTablaPrepoliza.NewRow

                    dRow("IDAdicional") = Me._IDAdicional
                    dRow("CODIGO_CENTRO_COSTO") = Me.Grid.Cell(i, Me.iGyCodigoCentroCosto).Text
                    dRow("NOMBRE_CENTRO_COSTO") = Me.Grid.Cell(i, Me.iGyNombreCentroCosto).Text
                    dRow("Hectareas") = Me.Grid.Cell(i, Me.iGyHectareas).Text
                    dRow("Cantidad") = Me.Grid.Cell(i, Me.iGyCantidad).Text
                    dRow("Importe") = Me.Grid.Cell(i, Me.iGyImporte).Text
                    dRow("CuentaContable") = Me.Grid.Cell(i, Me.iGyCuentaContable).Text
                    dRow("NombreCuenta") = Me.Grid.Cell(i, Me.iGyNombreCuenta).Text
                    dRow("Check") = Me.Grid.Cell(i, Me.iGyCheck).Text
                    dRow("CODIGO_CATEGORIA") = Me.cboCategoria.SelectedValue
                    dRow("CODIGO_CONCEPTO") = Me.cboConcepto.SelectedValue

                    Me.dTablaPrepoliza.Rows.Add(dRow)

                    'Me._GestionoRenglon = True
                End If

            Next

            Me.dTablaPrepoliza.AcceptChanges()

            bResultado = True
        Catch ex As Exception
            HandleError(Me.Name, "GestionaGridPrePoliza", ex)
        End Try

        Return bResultado
    End Function

    ''' <summary>
    ''' Recarga los renglones todos los renglones chequeados y no chequeados del Articulo
    ''' </summary>
    Private Function RecargaArticuloPrevio() As Boolean
        Me.Grid.Enabled = True
        Dim bResultado As Boolean = False
        Try
            Me.bEditando = True

            Me.Grid.AutoRedraw = False

            Dim dT As DataTable

            'Where t.Field(Of String)("IDAdicional") = Me._IDAdicional.ToString _

            'linq
            Dim query = _
            From t In Me.dTablaPrepoliza.AsEnumerable() _
            Where t.Field(Of Integer)("IDAdicional") = Me._IDAdicional _
            Select t 'Este t funciona como select *, si se le detallan los campos como en otros linq el query.CopyToDataTable() no funciona, no reconoce esta propiedad

            If query.Any = True Then
                dT = query.CopyToDataTable()
                'Me.cboConceptoProduccion.SelectedValue = dT.Rows(0)("CodigoConceptoProduccion").ToString

                Me.cboCategoria.SelectedValue = dT.Rows(0)("CODIGO_CATEGORIA").ToString
                Me.cboConcepto.SelectedValue = dT.Rows(0)("CODIGO_CONCEPTO").ToString
            Else
                dT = Me.dTablaPrepoliza.Clone() 'Clona solo la estructura
                'Me.SeleccionaConceptoProduccion()

                Dim oArticulo As New Class_CatArticulos(Me._CodigoArticulo)

                Dim oFamilia As Class_CatFamilias
                Dim oLinea As Class_CatLineas

                If txtLEN(oArticulo.CODIGO_FAMILIA) = True Then
                    oFamilia = New Class_CatFamilias(oArticulo.CODIGO_FAMILIA)
                    Me.cboCategoria.SelectedValue = oFamilia.CODIGO_CATEGORIA
                End If

                If txtLEN(oArticulo.CODIGO_LINEA) = True Then
                    oLinea = New Class_CatLineas(oArticulo.CODIGO_LINEA)
                    Me.cboConcepto.SelectedValue = oLinea.CODIGO_CONCEPTO
                End If

            End If
            dT.AcceptChanges()

            Me.Grid.DataSource = dT

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Este si funciona pero hace dos veces la consulta
            'Dim iRows As Integer = Me.dTablaPrepoliza.Select("IDAdicional=" & Me._IDAdicional.ToString).Length
            'If iRows > 0 Then
            '    Me.Grid.DataSource = Me.dTablaPrepoliza.Select("IDAdicional=" & Me._IDAdicional.ToString).CopyToDataTable
            'End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            'este falla si no hay registros!!!
            'Dim dT As DataTable = Me.dTablaPrepoliza.Select("IDAdicional=" & Me._IDAdicional.ToString).CopyToDataTable
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            'No funciona porque no es tabla es un arreglo de rows
            'Dim dT As DataRow() = Me.dTablaPrepoliza.Select("IDAdicional=" & Me._IDAdicional.ToString)
            'Me.Grid.DataSource = dT 
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            'MsgBox(dT.Columns(4).ColumnName & " - " & dT.Columns(4).DataType.ToString)

            If dT.Rows.Count > 0 Then
                Me.Grid.Row(Me.Grid.Rows - 1).Locked = True

                Me.FormateaGrid()

                Me.Grid.AutoRedraw = True
                Me.Grid.Refresh()
            Else
                Me.ArticuloNuevo()
                'Me.CreaTablaVacia() ' no se debe regenerar en blanco porque se perderian datos previos
            End If

            Me.Totales()

            bResultado = True

        Catch ex As Exception
            HandleError(Me.Name, "RecargaArticuloPrevio", ex)
        Finally
            Me.bEditando = False
        End Try

        Return bResultado
    End Function

    Private Function ExisteArticulo() As Boolean
        If Me.dTablaPrepoliza.Rows.Count > 0 Then
            If Me.dTablaPrepoliza.Select("IDAdicional=" & IDAdicional).Any = True Then
                Return True
            End If
        End If
    End Function

    Public Function EliminaRelacion(ByVal IDAdicional As Integer) As Boolean
        Try
            If Me.dTablaPrepoliza.Rows.Count > 0 Then
                Dim dView As New DataView(Me.dTablaPrepoliza)
                dView.RowFilter = "IDAdicional=" & IDAdicional

                For Each dRowV As DataRowView In dView
                    dRowV.Delete()
                Next

                Me.dTablaPrepoliza.AcceptChanges()
            End If
        Catch ex As Exception
            HandleError(Me.Name, "EliminaRelacion", ex)
        End Try
    End Function

    Public Function ObtieneListaDetalleCuentas() As String
        Dim sResultado As String = ""
        Try
            For Each dRow As DataRow In Me.dTablaPrepoliza.Rows
                'sResultado = sResultado & dRow("").ToString & "," & dRow("").ToString & "," & "|"
                If txtLEN(dRow("CuentaContable").ToString) = True Then

                    'sResultado = String.Concat(sResultado, Me._FolioMovimientoInventario, ",", dRow("IDAdicional").ToString, ",", dRow("CodigoCultivo").ToString, ",", dRow("Hectareas").ToString, ",", _
                    '                           dRow("Importe").ToString, ",", dRow("CuentaContable").ToString, ",", dRow("CuentaParte1").ToString, ",", dRow("CodigoConceptoProduccion").ToString, "|")

                    sResultado = String.Concat(sResultado, Me._FolioMovimientoInventario, ",", dRow("IDAdicional").ToString, ",", dRow("CODIGO_CENTRO_COSTO").ToString, ",", dRow("CODIGO_CATEGORIA").ToString, ",", _
                                               dRow("CODIGO_CONCEPTO").ToString, ",", dRow("Hectareas").ToString, ",", dRow("Cantidad").ToString, ",", dRow("Importe").ToString, ",", dRow("CuentaContable").ToString, "|")

                End If
            Next
            If txtLEN(sResultado) = True Then
                sResultado = sResultado.Substring(0, sResultado.Length - 1)
            End If
        Catch ex As Exception
            HandleError(Me.Name, "ObtieneListaDetalleCuentas", ex)
        End Try
        Return sResultado
    End Function

    Public Function ValidaCuentaTengaDetalle(ByVal IDAdicional As Integer) As Boolean
        Try
            If Me.dTablaPrepoliza.Select("IDAdicional=" & IDAdicional.ToString).Length > 0 Then
                Return True
            End If
        Catch ex As Exception
            HandleError(Me.Name, "ValidaCuentaTengaDetalle", ex)
        End Try
    End Function

    Private Sub DesplegarCategorias()
        Try
            Dim oElementos As New Class_CatCategorias
            With Me.cboCategoria
                .DisplayMember = "NOMBRE_CATEGORIA"
                .ValueMember = "CODIGO_CATEGORIA"
                Dim dView As New Data.DataView(oElementos.ObtenerElementos)
                dView.Sort = "NOMBRE_CATEGORIA"
                .DataSource = dView
                .SelectedIndex = -1
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarCategorias", ex)
        End Try
    End Sub

    Private Sub DesplegarConceptos()
        Try
            Dim oElementos As New Class_CatConceptos
            With Me.cboConcepto
                .DisplayMember = "NOMBRE_CONCEPTO"
                .ValueMember = "CODIGO_CONCEPTO"
                Dim dView As New Data.DataView(oElementos.ObtenerElementos)
                dView.Sort = "NOMBRE_CONCEPTO"
                .DataSource = dView
                .SelectedIndex = -1
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarConceptos", ex)
        End Try
    End Sub
#End Region

End Class