Option Strict On

Imports CrystalDecisions.CrystalReports.Engine

Public Class Transformaciones
    Private oInventarios As New Class_Inventarios_Global
    Private oDocumentos As Class_Cat_tiposDocumentos
    Private oArticulo As New Class_CatArticulos
    Private oFormaDetalleCuentas As InventariosDetalleCuentasContables

#Region "Columnas grid"
    Private iGyCodigo As Integer = 1
    Private iGyDescripcion As Integer = 2
    Private iGyUnidad As Integer = 3
    Private iGyCantidadOriginal As Integer = 4
    Private iGyCantidadTotal As Integer = 5
    Private iGyExistencia As Integer = 6
    Private iGyCosto As Integer = 7
    Private iGyTotal As Integer = 8
#End Region

    Private bAplicando As Boolean

#Region "Propiedades"

#End Region

#Region "Opciones"
    Private Sub tsbNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbNuevo.Click
        Me.Inicializa()
    End Sub

    Private Sub tsbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGrabar.Click
        Me.Grabar()
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub

#End Region

#Region "Eventos"
    Private Sub Inventarios_Movimientos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Inicializa()
        Me.DesplegarAlmacenes()
    End Sub

    Private Sub cboCentros_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        txtTAB(e)
    End Sub

    Private Sub CmbDocumento_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        txtTAB(e)
    End Sub
    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtConcepto.KeyPress, TxtCodigoArticulo.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub txtCantidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCantidad.KeyPress
        Dim txt As TextBox = CType(sender, TextBox)
        txtSoloNumerosDecimales(e, txt.Text)
        txtNoBeep(e)
    End Sub

    Private Sub TxtCodigoArticulo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodigoArticulo.KeyDown
        Dim sText As String

        Select Case e.KeyCode
            Case Keys.F6
BuscarArticulo:
                Me.oArticulo = New Class_CatArticulos
                sText = Me.oArticulo.BusquedaVisual_PorDescripcion

                If Me.ValidaArticulo(sText) = True Then
                    Me.TxtCodigoArticulo.Text = sText
                End If

            Case Keys.Enter
                Me.oArticulo = New Class_CatArticulos(Me.TxtCodigoArticulo.Text)
                If Me.oArticulo.Existe = False Then
                    Me.LblNombreProductoFinal.Text = "" : GoTo BuscarArticulo : Exit Sub
                End If

                If Me.ValidaArticulo(Me.TxtCodigoArticulo.Text) = True Then
                    LblNombreProductoFinal.Text = oArticulo.DESCRIPCION
                    Me.Consultar()
                    txtTAB(e)
                End If

        End Select
    End Sub

    Private Sub TxtConcepto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtConcepto.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter

        End Select
    End Sub

    Private Sub TxtCantidad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCantidad.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If valorNumerico(Me.TxtCantidad.Text) = 0 Then
                    MsgBox("La cantidad debe ser mayor a 0.", MsgBoxStyle.Exclamation, Me.Text)
                    Me.TxtCantidad.Focus()
                    Exit Sub
                End If

                Me.Totales()
                txtTAB(e)

        End Select
    End Sub

    Private Sub TxtCuentaContable_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCuentaContable.KeyDown
        Dim oCuentas As New Class_CatCuentas, sCuentaContable As String

        Select Case e.KeyCode
            Case Keys.Enter
                sCuentaContable = Me.TxtCuentaContable.Text

                oCuentas = New Class_CatCuentas(sCuentaContable)

                If oCuentas._Existe = True Then
                    Me.TxtCuentaContable.Text = oCuentas.CUENTA_CONTABLE
                    Me.LblNombreCuentaContable.Text = oCuentas.NOMBRE_CUENTA
                Else
                    Me.TxtCuentaContable.Text = ""
                    Me.LblNombreCuentaContable.Text = ""
                    GoTo BuscarCuentas : Exit Sub
                End If

            Case Keys.F6, Keys.F7
BuscarCuentas:
                If e.KeyCode = Keys.F6 Then
                    sCuentaContable = oCuentas.BusquedaVisual_PorCodigo()
                Else
                    sCuentaContable = oCuentas.BusquedaVisual_PorDescripcion()
                End If

                If txtLEN(sCuentaContable) = True Then
                    oCuentas = New Class_CatCuentas(sCuentaContable)
                    If oCuentas._Existe = True Then
                        Me.TxtCuentaContable.Text = oCuentas.CUENTA_CONTABLE
                        Me.LblNombreCuentaContable.Text = oCuentas.NOMBRE_CUENTA
                    End If
                End If

        End Select
    End Sub
#End Region

#Region "Métodos y procedimientos"

    Private Sub Inicializa()
        Try
            Me.TxtCodigoArticulo.Text = ""
            Me.LblNombreProductoFinal.Text = ""
            Me.TxtExistencia.Text = "0.00"
            Me.TxtCantidad.Text = "0.00"
            Me.TxtCosto.Text = "$ 0.00"
            Me.TxtCostoTotal.Text = "$ 0.00"
            Me.TxtConcepto.Text = ""
            Me.TxtTotal.Text = "$ 0.00"
            Me.TxtCuentaContable.Text = ""
            Me.LblNombreCuentaContable.Text = ""
            Me.Grid1.DataSource = Nothing

            Me.TxtExistencia.ReadOnly = True
            Me.TxtCosto.ReadOnly = True
            Me.TxtCostoTotal.ReadOnly = True
            Me.TxtTotal.ReadOnly = True

            Me.InicializaGrid()

            Me.Grid1.Locked = True

        Catch ex As Exception
            HandleError(Me.Name, "Inicializa", ex)
        End Try
    End Sub

    Private Sub InicializaGrid()
        Try
            FG_Grid_Limpiar(Me.Grid1)
            Me.Grid1.Rows = 2
            Me.FormateaGrid()
            'Me.Totales()

        Catch ex As Exception
            HandleError(Me.Text, "InicializaGrid", ex)
        End Try
    End Sub

    Function Grabar() As Boolean
        Dim bResultado As Boolean = False
        Dim sListaSeries As String = ""

        If txtLEN(Me.TxtCodigoArticulo.Text) = False Then
            MsgBox("Inserte un código de producto final.", MsgBoxStyle.Exclamation, Me.Text)
            Me.TxtCodigoArticulo.Focus()
            Exit Function
        End If

        If Me.ValidaArticulo(Me.TxtCodigoArticulo.Text) = False Then
            Exit Function
        End If

        If valorNumerico(Me.TxtCantidad.Text) = 0 Then
            MsgBox("La cantidad debe ser mayor a 0.", MsgBoxStyle.Exclamation, Me.Text)
            Me.TxtCantidad.Focus()
            Exit Function
        End If

        If Usuario.ValidaPermisoUsuarioTiposDocumentosConAfectaInventarios("SAI", Me.CboAlmacen.SelectedValue.ToString.ToString, "") = False Then
            MsgBox("El usuario " & Usuario.Nombre_Usuario & " no tiene permiso para realizar salida de almacén.", MsgBoxStyle.Information, Me.Text)
            Exit Function
        End If

        If Usuario.ValidaPermisoUsuarioTiposDocumentosConAfectaInventarios("ENI", Me.CboAlmacen.SelectedValue.ToString.ToString, "") = False Then
            MsgBox("El usuario " & Usuario.Nombre_Usuario & " no tiene permiso para realizar entrada de almacén.", MsgBoxStyle.Information, Me.Text)
            Exit Function
        End If

        If Me.ValidaExistenciaIngredientes() = False Then
            Exit Function
        End If

        If txtLEN(Me.TxtCuentaContable.Text) = False Then
            MsgBox("Asígne una cuenta contable.", MsgBoxStyle.Exclamation, Me.Text)
            Me.TxtCuentaContable.Focus()
            Exit Function
        End If

        Me.Totales()

        'Salida de ingredientes
        If Me.GrabaSalidaIngredientes() = False Then
            Exit Function
        End If

        'Entrada de producto final
        If Me.GrabaEntradaProductoFinal() = False Then
            Exit Function
        End If

        bResultado = True

        MsgBox("Transformación realizada exitosamente.", MsgBoxStyle.Exclamation, Me.Text)
        Return bResultado

    End Function

    Private Function GrabaSalidaIngredientes() As Boolean
        Dim bResultado As Boolean = False
        Dim folioSalida As String
        Me.oInventarios = New Class_Inventarios_Global

        Try
            With oInventarios
                .FOLIO_MOVIMIENTO_INVENTARIO = ""
                .CODIGO_TIPO_DOCUMENTO = "SAI"
                .FOLIO_REFERENCIA = ""
                .CODIGO_ALMACEN1 = "" & Me.CboAlmacen.SelectedValue.ToString()
                .FECHA = Now
                .CONCEPTO = "" & Me.TxtConcepto.Text
                .CODIGO_USUARIO = CInt("" & Usuario.Codigo_Usuario)
                .CODIGO_PLAZA = Usuario.Codigo_Plaza
                .TOTAL = valorNumerico(Me.TxtTotal.Text)
                .FOLIO_EMBARQUE = ""

                If .Insertar() = False Then
                    MsgBox("Error al tratar de insertar el movimiento de salida de inventario.", MsgBoxStyle.Exclamation, Me.Text)
                    Exit Function
                End If
                folioSalida = .FOLIO_MOVIMIENTO_INVENTARIO

                'se graba el detalle
                For i = 1 To Me.Grid1.Rows - 1
                    If txtLEN(Me.Grid1.Cell(i, Me.iGyCodigo).Text) = True Then
                        .NuevoRenglon()
                        .oInventariosDetalle.FOLIO_MOVIMIENTO_INVENTARIO = .FOLIO_MOVIMIENTO_INVENTARIO
                        .oInventariosDetalle.CODIGO_ARTICULO = Me.Grid1.Cell(i, Me.iGyCodigo).Text
                        .oInventariosDetalle.CANTIDAD = valorNumerico(Me.Grid1.Cell(i, Me.iGyCantidadTotal).Text)
                        .oInventariosDetalle.COSTO = valorNumerico(Me.Grid1.Cell(i, Me.iGyCosto).Text)
                        .oInventariosDetalle.CUENTA_CONTABLE = Me.TxtCuentaContable.Text
                        .oInventariosDetalle.IMPORTE = CDec(valorNumerico(Me.Grid1.Cell(i, Me.iGyTotal).Text.ToString))
                        .oInventariosDetalle.ID_ADICIONAL = i 'CInt(valorNumerico(Me.Grid1.Cell(i, Me.iGyIDAdicional).Text))
                        .oInventariosDetalle.LISTA_SERIES = ""

                        If .oInventariosDetalle.GrabaRenglon() = False Then
                            MsgBox("Error al tratar de grabar el detalle de la salida de inventario.", MsgBoxStyle.Exclamation, Me.Text)
                            Exit Function
                        End If

                    End If
                Next

                Dim sListaCuentas As String = ""

                If IsNothing(Me.oFormaDetalleCuentas) = False Then 'Si no esta vacia, osea si existe
                    Me.oFormaDetalleCuentas.FolioMovimientoInventario = folioSalida 'Hasta aqui la forma auxuliar no tenia el folio
                    sListaCuentas = Me.oFormaDetalleCuentas.ObtieneListaDetalleCuentas()
                End If

                If txtLEN(sListaCuentas) = True Then
                    .oInventariosDetalle.GrabaDetalleCentroCostos(sListaCuentas, "SAI" & Usuario.Codigo_Plaza, Now, CBool(IIf(Me.oDocumentos.NATURALEZA_INVENTARIOS = "EN", True, False)))
                End If

            End With

            Me.oInventarios = New Class_Inventarios_Global(folioSalida)

            bResultado = Me.oInventarios.Aplicar()
            If bResultado = True Then
                If Me.oInventarios.AplicarPoliza() = False Then
                    MsgBox("Error al intentar aplicar la poliza de salida.", MsgBoxStyle.Exclamation, Me.Text)
                End If
            Else
                MsgBox("Error al intentar aplicar el movimiento de salida de inventario.", MsgBoxStyle.Exclamation, Me.Text)
            End If

            bResultado = True
            'MsgBox("Transformación realizada satisfactoriamente.", MsgBoxStyle.Information, Me.Text)

        Catch ex As Exception
            HandleError(Me.Name, "GrabaSalidaIngredientes", ex)
            Me.Consultar()
        Finally
            Me.oInventarios = Nothing
        End Try

        Return bResultado

    End Function

    Private Function GrabaEntradaProductoFinal() As Boolean
        Dim bResultado As Boolean = False
        Dim folioEntrada As String
        Me.oInventarios = New Class_Inventarios_Global

        Try
            With oInventarios
                .FOLIO_MOVIMIENTO_INVENTARIO = ""
                .CODIGO_TIPO_DOCUMENTO = "ENI"
                .FOLIO_REFERENCIA = ""
                .CODIGO_ALMACEN1 = "" & Me.CboAlmacen.SelectedValue.ToString()
                .FECHA = Now
                .CONCEPTO = "" & Me.TxtConcepto.Text
                .CODIGO_USUARIO = CInt("" & Usuario.Codigo_Usuario)
                .CODIGO_PLAZA = Usuario.Codigo_Plaza
                .TOTAL = valorNumerico(Me.TxtTotal.Text)
                .FOLIO_EMBARQUE = ""

                If .Insertar() = False Then
                    MsgBox("Error al tratar de insertar el movimiento de entrada de inventario.", MsgBoxStyle.Exclamation, Me.Text)
                    Exit Function
                End If
                folioEntrada = .FOLIO_MOVIMIENTO_INVENTARIO

                'se graba el detalle
                .NuevoRenglon()
                .oInventariosDetalle.FOLIO_MOVIMIENTO_INVENTARIO = .FOLIO_MOVIMIENTO_INVENTARIO
                .oInventariosDetalle.CODIGO_ARTICULO = Me.TxtCodigoArticulo.Text
                .oInventariosDetalle.CANTIDAD = valorNumerico(Me.TxtCantidad.Text)
                .oInventariosDetalle.COSTO = valorNumerico(Me.TxtCosto.Text)
                .oInventariosDetalle.CUENTA_CONTABLE = "103000010002" 'Me.Grid1.Cell(i, Me.iGyCuentaContable).Text.ToString
                .oInventariosDetalle.IMPORTE = CDec(valorNumerico(Me.TxtCostoTotal.Text))
                .oInventariosDetalle.ID_ADICIONAL = 1
                .oInventariosDetalle.LISTA_SERIES = ""

                If .oInventariosDetalle.GrabaRenglon() = False Then
                    MsgBox("Error al tratar de grabar el detalle de la entrada de inventario.", MsgBoxStyle.Exclamation, Me.Text)
                    Exit Function
                End If

                Dim sListaCuentas As String = ""

                If IsNothing(Me.oFormaDetalleCuentas) = False Then 'Si no esta vacia, osea si existe
                    Me.oFormaDetalleCuentas.FolioMovimientoInventario = folioEntrada 'Hasta aqui la forma auxuliar no tenia el folio
                    sListaCuentas = Me.oFormaDetalleCuentas.ObtieneListaDetalleCuentas()
                End If

                If txtLEN(sListaCuentas) = True Then
                    .oInventariosDetalle.GrabaDetalleCentroCostos(sListaCuentas, "ENI" & Usuario.Codigo_Plaza, Now, CBool(IIf(Me.oDocumentos.NATURALEZA_INVENTARIOS = "EN", True, False)))
                End If

            End With

            Me.oInventarios = New Class_Inventarios_Global(folioEntrada)

            bResultado = Me.oInventarios.Aplicar()
            If bResultado = True Then
                If Me.oInventarios.AplicarPoliza() = False Then
                    MsgBox("Error al intentar aplicar la poliza de entrada.", MsgBoxStyle.Exclamation, Me.Text)
                End If
            Else
                MsgBox("Error al intentar aplicar el movimiento de entrada de inventario.", MsgBoxStyle.Exclamation, Me.Text)
            End If

            bResultado = True
            'MsgBox("Transformación realizada satisfactoriamente.", MsgBoxStyle.Information, Me.Text)

        Catch ex As Exception
            HandleError(Me.Name, "GrabaEntradaProductoFinal", ex)
            Me.Consultar()
        Finally
            Me.oInventarios = Nothing
        End Try

        Return bResultado
    End Function

    Private Sub Consultar()
        Try
            Me.ConsultaExistenciaProductoFinal()
            Me.TxtCantidad.Text = "1.00"
            Me.ConsultaIngredientes()
            Me.Totales()

        Catch ex As Exception
            HandleError(Me.Text, "Consultar", ex)
        End Try
    End Sub

    Private Sub ConsultaIngredientes()
        Dim oFormula As New Class_CatFormulas

        Try
            Dim dTabla As DataTable = oFormula.ObtenerDetalleParaTransformaciones(Me.TxtCodigoArticulo.Text, Me.CboAlmacen.SelectedValue.ToString)
            Me.Grid1.AutoRedraw = False
            Me.Grid1.Rows = 1 'Trae dos porque en docs nuevos se pone un row en blanco, y si se dejan aqui dos agrega a partir del 3 y queda un hueco
            For Each dRow As DataRow In dTabla.Rows
                Me.Grid1.AddItem(dRow("CODIGO_ARTICULO").ToString & Chr(9) & dRow("DESCRIPCION").ToString & Chr(9) & dRow("UNIDAD_VENTA").ToString & Chr(9) & dRow("CANTIDAD_ORIGINAL").ToString & Chr(9) & dRow("CANTIDAD_TOTAL").ToString & Chr(9) & dRow("EXISTENCIA").ToString & Chr(9) & _
                                dRow("COSTO").ToString & Chr(9) & dRow("TOTAL").ToString & Chr(9))
            Next

            Me.Grid1.AutoRedraw = True
            Me.Grid1.Refresh()

            For i As Integer = 1 To Grid1.Rows - 1
                Me.Grid1.Cell(i, Me.iGyCantidadTotal).Text = (valorNumerico(Me.Grid1.Cell(i, Me.iGyCantidadOriginal).Text) * valorNumerico(Me.TxtCantidad.Text)).ToString
            Next
            Me.FormateaGrid()

        Catch ex As Exception
            HandleError(Me.Text, "ConsultarIngredientes", ex)
        End Try

    End Sub

    Private Sub ConsultaExistenciaProductoFinal()
        Try
            Dim sql As New Class_find("SELECT EXISTENCIA FROM INVENTARIO_EXISTENCIA_ARTICULOS WHERE CODIGO_ARTICULO = '" & Me.TxtCodigoArticulo.Text & "' AND CODIGO_ALMACEN = '" & Me.CboAlmacen.SelectedValue.ToString & "'")
            Me.TxtExistencia.Text = sql.Result1.ToString

        Catch ex As Exception
            HandleError(Me.Text, "ConsultaExistenciaProductoFinal", ex)
        End Try
    End Sub

    Private Function ValidarExistencias() As Boolean
        Const sProcedure As String = "Validación de existencias de Articulos"
        Dim bResultado As Boolean = False
        Dim dCantidadSumadaPorArticulos As Double, dExistencia As Double
        Dim i As Integer, sCodigoArticulo As String = ""

        Try

            For i = 1 To Me.Grid1.Rows - 1
                sCodigoArticulo = Me.Grid1.Cell(i, Me.iGyCodigo).Text
                If txtLEN(sCodigoArticulo) = True Then
                    Me.oArticulo = New Class_CatArticulos(sCodigoArticulo)
                    If Me.oArticulo.INVENTARIABLE <> "0" Then
                        dExistencia = oInventarios.Existencia(sCodigoArticulo, Me.CboAlmacen.SelectedValue.ToString)
                        If dExistencia <= 0 Then
                            Me.Show()
                            MsgBox("El artículo " & Me.Grid1.Cell(i, Me.iGyDescripcion).Text & " que intenta agregar no tiene existencia. ", MsgBoxStyle.Exclamation, sProcedure)
                            Exit Function
                        Else
                            dCantidadSumadaPorArticulos = CDbl(Me.Grid1.Cell(i, Me.iGyCantidadTotal).Text)

                            If valorNumerico(dCantidadSumadaPorArticulos.ToString) > valorNumerico(dExistencia.ToString) Then
                                Me.Show()
                                MsgBox("El Artículo " & Me.Grid1.Cell(i, Me.iGyDescripcion).Text & " no tiene suficiente existencia.", MsgBoxStyle.Exclamation, sProcedure)
                                Exit Function
                            End If
                        End If
                    End If
                End If
            Next i

            bResultado = True
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    Private Sub DesplegarAlmacenes()
        Try
            Dim oElementos As New Class_CatAlmacenes
            With Me.CboAlmacen
                .DisplayMember = "NOMBRE_ALMACEN"

                .ValueMember = "CODIGO_ALMACEN"

                Dim dView As New Data.DataView(oElementos.ObtenerAlmacenes)
                dView.Sort = "NOMBRE_ALMACEN"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedIndex = 0
                End If
                .SelectedValue = Usuario.Codigo_Almacen
            End With

        Catch ex As Exception
            HandleError(Me.Name, "DesplegarAlmacenes", ex)
        End Try
    End Sub

    Private Sub FormateaGrid()
        Try
            With Me.Grid1
                .AutoRedraw = False

                .Cols = 9

                .DisplayFocusRect = False
                .DrawMode = FlexCell.DrawModeEnum.OwnerDraw
                .BorderStyle = FlexCell.BorderStyleEnum.FixedSingle
                .FixedRowColStyle = FlexCell.FixedRowColStyleEnum.Flat

                .BackColor1 = Color.FromArgb(231, 235, 247)
                .BackColor2 = Color.FromArgb(239, 243, 255)
                .CellBorderColorFixed = Color.Black
                .GridColor = Color.FromArgb(148, 190, 231)

                .Cell(0, Me.iGyCodigo).Text = "Código"
                .Cell(0, Me.iGyDescripcion).Text = "Descripción"
                .Cell(0, Me.iGyUnidad).Text = "Unidad"
                .Cell(0, Me.iGyCantidadOriginal).Text = "Cant. original"
                .Cell(0, Me.iGyCantidadTotal).Text = "Cant. total"
                .Cell(0, Me.iGyExistencia).Text = "Existencia"
                .Cell(0, Me.iGyCosto).Text = "Costo"
                .Cell(0, Me.iGyTotal).Text = "Total"

                .Column(Me.iGyCantidadOriginal).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyCantidadOriginal).DecimalLength = Empresa_Sistema.DECIMALES_CANTIDAD
                .Column(Me.iGyCantidadOriginal).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGyCantidadTotal).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyCantidadTotal).DecimalLength = Empresa_Sistema.DECIMALES_CANTIDAD
                .Column(Me.iGyCantidadTotal).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGyExistencia).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyExistencia).DecimalLength = Empresa_Sistema.DECIMALES_CANTIDAD
                .Column(Me.iGyExistencia).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGyCosto).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyCosto).DecimalLength = Empresa_Sistema.DECIMALES_PRECIO
                .Column(Me.iGyCosto).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGyTotal).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyTotal).DecimalLength = Empresa_Sistema.DECIMALES_PRECIO
                .Column(Me.iGyTotal).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGyCodigo).Width = 70
                .Column(Me.iGyDescripcion).Width = 210
                .Column(Me.iGyUnidad).Width = 50
                .Column(Me.iGyCantidadOriginal).Width = 80
                .Column(Me.iGyCantidadTotal).Width = 80
                .Column(Me.iGyExistencia).Width = 80
                .Column(Me.iGyCosto).Width = 100
                .Column(Me.iGyTotal).Width = 95

                .Locked = True

                .AutoRedraw = True
                .Refresh()
            End With

        Catch ex As Exception
            HandleError(Me.Name, "FormateaGrid", ex)
        End Try
    End Sub

    Private Sub Totales()
        Try
            Dim I As Integer
            Dim Dcantidad As Double, DPrecio As Double, dImporte As Double
            For I = 1 To Me.Grid1.Rows - 1
                If Len("" & Me.Grid1.Cell(I, Me.iGyCantidadTotal).Text) > 0 Then
                    Dcantidad = Val(0 & Me.Grid1.Cell(I, Me.iGyCantidadTotal).Text)
                    DPrecio = Val(0 & Me.Grid1.Cell(I, Me.iGyCosto).Text)

                    If Dcantidad > 0 Then
                        dImporte = (DPrecio * Dcantidad)
                        dImporte = Redondear(dImporte)
                        Me.Grid1.Cell(I, Me.iGyTotal).Text = dImporte.ToString
                    End If
                End If
            Next I

            For I = 1 To Grid1.Rows - 1
                Me.Grid1.Cell(I, Me.iGyCantidadTotal).Text = (valorNumerico(Me.Grid1.Cell(I, Me.iGyCantidadOriginal).Text) * valorNumerico(Me.TxtCantidad.Text)).ToString
                Me.Grid1.Cell(I, Me.iGyTotal).Text = (valorNumerico(Me.Grid1.Cell(I, Me.iGyCantidadTotal).Text) * valorNumerico(Me.Grid1.Cell(I, Me.iGyCosto).Text)).ToString
            Next

            If valorNumerico(Me.TxtCosto.Text) = 0 Then
                Me.TxtCosto.Text = FormatImporteContable(FG_Grid_SumaCol(Me.Grid1, CShort(Me.iGyTotal))).ToString
            End If

            Me.TxtCostoTotal.Text = FormatImporteContable(valorNumerico(Me.TxtCosto.Text) * valorNumerico(Me.TxtCantidad.Text)).ToString
            Me.TxtTotal.Text = FormatImporteContable(FG_Grid_SumaCol(Me.Grid1, CShort(Me.iGyTotal))).ToString

        Catch ex As Exception
            HandleError(Me.Name, "Totales", ex)
        End Try
    End Sub

    Private Function SiTieneRenglones() As Boolean
        Dim bResultado As Boolean = False
        Dim i As Integer
        Try
            For i = 1 To Me.Grid1.Rows - 1
                If txtLEN(Me.Grid1.Cell(i, Me.iGyCodigo).Text) = True Then
                    Return True
                End If
            Next
            bResultado = False
        Catch ex As Exception
            HandleError(Me.Name, "SiTieneRenglones", ex)
        End Try
        Return bResultado
    End Function

    Private Function ValidaArticulo(ByVal sCodigo As String) As Boolean
        Dim bResultado As Boolean = False

        Dim sql As New Class_find("SELECT 1 FROM CAT_FORMULAS WHERE CODIGO_ARTICULO='" & sCodigo & "'")

        If txtLEN(sql.Result1.ToString) = False Then
            MsgBox("No existe ninguna fórmula para ese producto.", MsgBoxStyle.Exclamation, Me.Text)
            Return bResultado
        End If

        bResultado = True
        Return bResultado
    End Function

    Private Function ValidaExistenciaIngredientes() As Boolean
        Const sProcedure = "ValidaExistenciaIngredientes"
        Dim bResultado As Boolean = False
        Dim dCantidadSumadaPorArticulos As Double, dExistencia As Double
        Dim i As Integer, sCodigoArticulo As String = ""
        Me.oInventarios = New Class_Inventarios_Global

        Try
            For i = 1 To Me.Grid1.Rows - 1
                sCodigoArticulo = Me.Grid1.Cell(i, Me.iGyCodigo).Text
                If txtLEN(sCodigoArticulo) = True Then
                    Me.oArticulo = New Class_CatArticulos(sCodigoArticulo)
                    If Me.oArticulo.INVENTARIABLE <> "0" Then
                        dExistencia = Me.oInventarios.Existencia(sCodigoArticulo, Me.CboAlmacen.SelectedValue.ToString)
                        If dExistencia <= 0 Then
                            Me.Show()
                            MsgBox("El artículo " & Me.Grid1.Cell(i, Me.iGyDescripcion).Text & " no tiene existencia. ", MsgBoxStyle.Exclamation, sProcedure)
                            Exit Function
                        Else
                            dCantidadSumadaPorArticulos = CDbl(Me.Grid1.Cell(i, Me.iGyCantidadTotal).Text)

                            If valorNumerico(dCantidadSumadaPorArticulos.ToString) > valorNumerico(dExistencia.ToString) Then
                                Me.Show()
                                MsgBox("El Artículo " & Me.Grid1.Cell(i, Me.iGyDescripcion).Text & " no tiene suficiente existencia.", MsgBoxStyle.Exclamation, sProcedure)
                                Exit Function
                            End If
                        End If
                    End If
                End If
            Next i

            bResultado = True
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try

        Return bResultado
    End Function

#End Region

End Class