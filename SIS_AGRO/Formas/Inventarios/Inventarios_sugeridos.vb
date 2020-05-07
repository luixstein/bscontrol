Option Strict On

Public Class Inventarios_sugeridos

    Dim oInventariosSugeridos As Class_Inventarios_Sugeridos

#Region "Columnas grid"
    Private iGyClasificacionImportancia As Integer = 1
    Private iGyCodigoArticulo As Integer = 2
    Private iGyDescripcion As Integer = 3
    Private iGyVentasMes1 As Integer = 4
    Private iGyVentasMes2 As Integer = 5
    Private iGyVentasMes3 As Integer = 6
    Private iGyVentasMesPromedio As Integer = 7
    Private iGyExistencia As Integer = 8
    Private iGyTiempoEntregaDias As Integer = 9
    Private iGyMinimo As Integer = 10
    Private iGyReorden As Integer = 11
    Private iGyMaximo As Integer = 12
    Private iGyCoberturaActualDias As Integer = 13
    Private iGyFechaOrdenar As Integer = 14
    Private iGyPedidoSugerido As Integer = 15
    Private iGyBalanceInventario As Integer = 16

#End Region

#Region "Opciones"

    Private Sub tsbNuevo_Click(sender As Object, e As EventArgs) Handles tsbNuevo.Click
        Me.Inicializa()
    End Sub

#End Region

#Region "Eventos genericos"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigoAlmacen.KeyPress, TxtFiltro.KeyPress, GridArticulos.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub

#End Region

#Region "Eventos"

    Private Sub Inventarios_sugeridos_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Inicializa()
    End Sub

    Private Sub TxtCodigoAlmacen_TextChanged(sender As Object, e As EventArgs) Handles TxtCodigoAlmacen.TextChanged
        Me.InicializaGrid()
        Me.GbArticulos.Enabled = False
    End Sub

    Private Sub TxtCodigoAlmacen_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCodigoAlmacen.KeyDown
        Dim oAlmacenes As New Class_CatAlmacenes
        Select Case e.KeyCode
            Case Keys.F6
busca:
                Me.TxtCodigoAlmacen.Text = oAlmacenes.BusquedaVisual_PorDescripcion
            Case Keys.Enter
                oAlmacenes.CODIGO_ALMACEN = Me.TxtCodigoAlmacen.Text
                If oAlmacenes.Consultar() = False Then
                    GoTo busca
                End If

                Me.LblNombreAlmacen.Text = oAlmacenes.NOMBRE_ALMACEN
                Me.ConsultarArticulos()

        End Select
        txtTAB(e)
    End Sub

    Private Sub GridArticulos_KeyDown(Sender As Object, e As KeyEventArgs) Handles GridArticulos.KeyDown
        Me.GestionaGrid(e)
    End Sub

    Private Sub TxtFiltro_TextChanged(sender As Object, e As EventArgs) Handles TxtFiltro.TextChanged
        Me.GridArticulos.DataSource = Nothing
        Me.ConsultarArticulos(Me.TxtFiltro.Text)
    End Sub


#End Region

#Region "Métodos y procedimientos"

    Private Sub Inicializa()
        Me.TxtCodigoAlmacen.Text = ""
        Me.LblNombreAlmacen.Text = ""
        Me.TxtFiltro.Text = ""
        Me.InicializaGrid()
        Me.GbArticulos.Enabled = False
    End Sub

    Private Sub ConsultarArticulos(Optional ByVal sFiltro As String = "")
        oInventariosSugeridos = New Class_Inventarios_Sugeridos

        If txtLEN(Me.TxtCodigoAlmacen.Text) = False Then
            MsgBox("Capture un código de almacén", MsgBoxStyle.Exclamation, Me.Text)
            Me.TxtCodigoAlmacen.Focus()
            Exit Sub
        End If

        Dim dTabla As DataTable = oInventariosSugeridos.ObtenerElementosFiltro(Me.TxtCodigoAlmacen.Text, sFiltro)

        Me.GridArticulos.AutoRedraw = False
        Me.GridArticulos.Rows = 1
        For Each dRow As DataRow In dTabla.Rows
            Me.GridArticulos.AddItem(dRow("CLASIFICACION_IMPORTANCIA").ToString & Chr(9) &
                                     dRow("CODIGO_ARTICULO").ToString & Chr(9) &
                                     dRow("DESCRIPCION").ToString & Chr(9) &
                                     dRow("VENTAS_MES_1").ToString & Chr(9) &
                                     dRow("VENTAS_MES_2").ToString & Chr(9) &
                                     dRow("VENTAS_MES_3").ToString & Chr(9) &
                                     dRow("VENTAS_MES_PROMEDIO").ToString & Chr(9) &
                                     dRow("EXISTENCIA").ToString & Chr(9) &
                                     dRow("TIEMPO_ENTREGA_DIAS").ToString & Chr(9) &
                                     dRow("MINIMO").ToString & Chr(9) &
                                     dRow("REORDEN").ToString & Chr(9) &
                                     dRow("MAXIMO").ToString & Chr(9) &
                                     dRow("COBERTUDA_DIAS_ACTUAL").ToString & Chr(9) &
                                     Format(dRow("FECHA_ORDENAR"), "dd/mm/yyyy") & Chr(9) &
                                     dRow("PEDIDO_SUGERIDO").ToString & Chr(9) &
                                     dRow("BALANCE_INVENTARIO").ToString & Chr(9))
        Next

        Me.FormateaGrid()

        Me.GbArticulos.Enabled = True
    End Sub

    Private Function Grabar(ByVal sCodigoArticulo As String, ByVal sClasifiacionImportancia As String, ByVal iTiempoEntrega As Integer, ByVal dMax As Double, ByVal dReorden As Double, ByVal dMin As Double) As Boolean
        oInventariosSugeridos = New Class_Inventarios_Sugeridos

        If txtLEN(Me.TxtCodigoAlmacen.Text) = False Then
            MsgBox("Capture un codigo de almacén", MsgBoxStyle.Exclamation, Me.Text)
            Me.TxtCodigoAlmacen.Focus()
            Return False
        End If

        If txtLEN(sCodigoArticulo) = False Then
            MsgBox("No hay código de artículo", MsgBoxStyle.Exclamation, Me.Text)
            Return False
        End If

        If dMax < 0 Or dMin < 0 Or dReorden < 0 Or iTiempoEntrega < 0 Then
            MsgBox("No se pueden grabar cantidades negativas", MsgBoxStyle.Exclamation, Me.Text)
            Return False
        End If

        Try

            With oInventariosSugeridos
                .CODIGO_ALMACEN = Me.TxtCodigoAlmacen.Text
                .CODIGO_ARTICULO = sCodigoArticulo
                .CLASIFICACION_IMPORTANCIA = sClasifiacionImportancia
                .TIEMPO_ENTREGA_DIAS = iTiempoEntrega
                .MAXIMO = CDec(dMax)
                .REORDEN = CDec(dReorden)
                .MINIMO = CDec(dMin)

                If oInventariosSugeridos.Grabar() = False Then
                    MsgBox("Error al grabar el artículo " & sCodigoArticulo, MsgBoxStyle.Exclamation, Me.Text)
                    Return False
                End If
            End With

        Catch ex As Exception
            HandleError(Me.Name, "Grabar", ex)
        End Try
    End Function

    Private Sub GestionaGrid(ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            Dim Columna As Integer, Renglon As Integer
            Dim sCodigoArticulo, sClasificacionImportancia As String
            Dim dMaximo, dMinimo, dReorden As Double
            Dim iTiempoEntrega As Integer

            Columna = Me.GridArticulos.Selection.FirstCol
            Renglon = Me.GridArticulos.Selection.FirstRow

            sCodigoArticulo = Me.GridArticulos.Cell(Renglon, Me.iGyCodigoArticulo).Text
            sClasificacionImportancia = Me.GridArticulos.Cell(Renglon, Me.iGyClasificacionImportancia).Text
            iTiempoEntrega = CInt(Me.GridArticulos.Cell(Renglon, Me.iGyTiempoEntregaDias).Text)
            dMaximo = valorNumerico(Me.GridArticulos.Cell(Renglon, Me.iGyMaximo).Text)
            dReorden = valorNumerico(Me.GridArticulos.Cell(Renglon, Me.iGyReorden).Text)
            dMinimo = valorNumerico(Me.GridArticulos.Cell(Renglon, Me.iGyMinimo).Text)

            oInventariosSugeridos = New Class_Inventarios_Sugeridos

            Select Case e.KeyCode
                Case Keys.Enter

                    Select Case Columna
                        Case Me.iGyMaximo, Me.iGyMinimo, Me.iGyReorden, Me.iGyClasificacionImportancia, Me.iGyTiempoEntregaDias

                            Me.Grabar(sCodigoArticulo, sClasificacionImportancia, iTiempoEntrega, dMaximo, dReorden, dMinimo)

                            If Columna = Me.iGyTiempoEntregaDias Or Columna = Me.iGyReorden Then
                                Me.ConsultarArticulos(Me.TxtFiltro.Text)
                            ElseIf Columna = Me.iGyBalanceInventario Then
                                Me.GridArticulos.Cell(Renglon + 1, Me.iGyClasificacionImportancia).SetFocus()
                            End If

                    End Select

            End Select

        Catch ex As Exception
            HandleError(Me.Name, "GestionaGrid", ex)
        End Try
    End Sub

    Private Sub InicializaGrid()
        Try
            FG_Grid_Limpiar(Me.GridArticulos)
            Me.GridArticulos.Rows = 2
            Me.FormateaGrid()

        Catch ex As Exception
            HandleError(Me.Text, "InicializaGrid", ex)
        End Try
    End Sub

    Private Sub FormateaGrid()
        Try
            With Me.GridArticulos
                .AutoRedraw = False

                .Cols = 17

                .DisplayFocusRect = False
                .DrawMode = FlexCell.DrawModeEnum.OwnerDraw
                .BorderStyle = FlexCell.BorderStyleEnum.FixedSingle
                .FixedRowColStyle = FlexCell.FixedRowColStyleEnum.Flat

                .BackColor1 = Color.FromArgb(231, 235, 247)
                .BackColor2 = Color.FromArgb(239, 243, 255)
                .CellBorderColorFixed = Color.Black
                .GridColor = Color.FromArgb(148, 190, 231)

                .Cell(0, Me.iGyClasificacionImportancia).Text = "Clasificación importancia"
                .Cell(0, Me.iGyCodigoArticulo).Text = "Código"
                .Cell(0, Me.iGyDescripcion).Text = "Descripción"
                .Cell(0, Me.iGyVentasMes1).Text = "Ventas " & MonthName(Month(Date.Now) - 2)
                .Cell(0, Me.iGyVentasMes2).Text = "Ventas " & MonthName(Month(Date.Now) - 1)
                .Cell(0, Me.iGyVentasMes3).Text = "Ventas " & MonthName(Month(Date.Now))
                .Cell(0, Me.iGyVentasMesPromedio).Text = "Venta promedio mensual"
                .Cell(0, Me.iGyExistencia).Text = "Existencia"
                .Cell(0, Me.iGyTiempoEntregaDias).Text = "Tiempo de entrega dias"
                .Cell(0, Me.iGyMinimo).Text = "Minimo"
                .Cell(0, Me.iGyReorden).Text = "Reorden"
                .Cell(0, Me.iGyMaximo).Text = "Maximo"
                .Cell(0, Me.iGyCoberturaActualDias).Text = "Cobertura dias actual"
                .Cell(0, Me.iGyFechaOrdenar).Text = "Fecha a ordenar"
                .Cell(0, Me.iGyPedidoSugerido).Text = "Pedido sugerido"
                .Cell(0, Me.iGyBalanceInventario).Text = "Balance de inventarios"

                .Column(Me.iGyClasificacionImportancia).Width = 90
                .Column(Me.iGyCodigoArticulo).Width = 65
                .Column(Me.iGyDescripcion).Width = 300
                .Column(Me.iGyVentasMes1).Width = 80
                .Column(Me.iGyVentasMes2).Width = 80
                .Column(Me.iGyVentasMes3).Width = 80
                .Column(Me.iGyVentasMesPromedio).Width = 100
                .Column(Me.iGyExistencia).Width = 80
                .Column(Me.iGyTiempoEntregaDias).Width = 100
                .Column(Me.iGyMinimo).Width = 100
                .Column(Me.iGyReorden).Width = 100
                .Column(Me.iGyMaximo).Width = 100
                .Column(Me.iGyCoberturaActualDias).Width = 80
                .Column(Me.iGyFechaOrdenar).Width = 80
                .Column(Me.iGyPedidoSugerido).Width = 80
                .Column(Me.iGyBalanceInventario).Width = 100

                .Column(Me.iGyMaximo).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyMaximo).DecimalLength = Empresa_Sistema.DECIMALES_CANTIDAD
                .Column(Me.iGyMaximo).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGyReorden).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyReorden).DecimalLength = Empresa_Sistema.DECIMALES_CANTIDAD
                .Column(Me.iGyReorden).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGyMinimo).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyMinimo).DecimalLength = Empresa_Sistema.DECIMALES_CANTIDAD
                .Column(Me.iGyMinimo).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGyTiempoEntregaDias).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyTiempoEntregaDias).DecimalLength = 0
                .Column(Me.iGyTiempoEntregaDias).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGyClasificacionImportancia).Alignment = FlexCell.AlignmentEnum.CenterCenter
                .Column(Me.iGyVentasMes1).Alignment = FlexCell.AlignmentEnum.RightCenter
                .Column(Me.iGyVentasMes2).Alignment = FlexCell.AlignmentEnum.RightCenter
                .Column(Me.iGyVentasMes3).Alignment = FlexCell.AlignmentEnum.RightCenter
                .Column(Me.iGyVentasMesPromedio).Alignment = FlexCell.AlignmentEnum.RightCenter
                .Column(Me.iGyExistencia).Alignment = FlexCell.AlignmentEnum.RightCenter
                .Column(Me.iGyCoberturaActualDias).Alignment = FlexCell.AlignmentEnum.RightCenter
                .Column(Me.iGyPedidoSugerido).Alignment = FlexCell.AlignmentEnum.RightCenter
                .Column(Me.iGyFechaOrdenar).Alignment = FlexCell.AlignmentEnum.CenterCenter
                .Column(Me.iGyBalanceInventario).Alignment = FlexCell.AlignmentEnum.CenterCenter

                .Cell(0, Me.iGyClasificacionImportancia).Alignment = FlexCell.AlignmentEnum.LeftCenter
                .Cell(0, Me.iGyVentasMesPromedio).Alignment = FlexCell.AlignmentEnum.LeftCenter
                .Cell(0, Me.iGyCoberturaActualDias).Alignment = FlexCell.AlignmentEnum.LeftCenter
                .Cell(0, Me.iGyTiempoEntregaDias).Alignment = FlexCell.AlignmentEnum.LeftCenter
                .Cell(0, Me.iGyFechaOrdenar).Alignment = FlexCell.AlignmentEnum.LeftCenter
                .Cell(0, Me.iGyBalanceInventario).Alignment = FlexCell.AlignmentEnum.LeftCenter

                .Column(Me.iGyClasificacionImportancia).CellType = FlexCell.CellTypeEnum.ComboBox
                .ComboBox(Me.iGyClasificacionImportancia).DataSource = {"A", "B", "C"}

                .Column(Me.iGyCodigoArticulo).Locked = True
                .Column(Me.iGyDescripcion).Locked = True
                .Column(Me.iGyVentasMes1).Locked = True
                .Column(Me.iGyVentasMes2).Locked = True
                .Column(Me.iGyVentasMes3).Locked = True
                .Column(Me.iGyVentasMesPromedio).Locked = True
                .Column(Me.iGyExistencia).Locked = True
                .Column(Me.iGyCoberturaActualDias).Locked = True
                .Column(Me.iGyFechaOrdenar).Locked = True
                .Column(Me.iGyPedidoSugerido).Locked = True
                .Column(Me.iGyBalanceInventario).Locked = True

                .AutoRedraw = True
                .Refresh()
            End With

        Catch ex As Exception
            HandleError(Me.Name, "FormateaGrid", ex)
        End Try
    End Sub

#End Region

End Class