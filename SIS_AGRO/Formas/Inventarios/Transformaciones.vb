Option Strict On

Imports CrystalDecisions.CrystalReports.Engine

Public Class Transformaciones
    Private oInventarios As New Class_Inventarios_Global
    Private oDocumentos As Class_Cat_tiposDocumentos
    Private oArticulo As New Class_CatArticulos
    Private oFormula As New Class_CatFormulas
    Private oFormaDetalleCuentas As InventariosDetalleCuentasContables
    Private dtSeries As DataTable
    Private sCodigoConceptoInventario As String = ""
    Private Entrada As String = ""
    Private Salida As String = ""

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

#Region "Columnas grid series"
    Private igySeriePosicion As Short = 1
    Private igySerieCodigo As Short = 2
    Private igySerieDescripcion As Short = 3
    Private igySerieIdInventarioLotesCostos As Short = 4
    Private igySerieNumeroSerie As Short = 5
    Private igyIdProductoFinal As Short = 6
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

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtConcepto.KeyPress, TxtCodigoFormula.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub txtCantidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCantidad.KeyPress
        Dim txt As TextBox = CType(sender, TextBox)
        txtSoloNumerosDecimales(e, txt.Text)
        txtNoBeep(e)
    End Sub

    Private Sub txtCuentaContable_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCuentaContable.KeyPress
        txtSoloNumerosEnteros(e)
        txtNoBeep(e)
    End Sub

    Private Sub TxtCodigoFormula_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodigoFormula.KeyDown
        Dim sText As String

        Select Case e.KeyCode
            Case Keys.F6
BuscaFormula:
                Me.oFormula = New Class_CatFormulas
                sText = Me.oFormula.BusquedaVisual_PorDescripcion
                Me.TxtCodigoFormula.Text = sText
                GoTo nombreFormula

            Case Keys.Enter
nombreFormula:
                If txtLEN(Me.TxtCodigoFormula.Text) = False Then
                    Exit Sub
                End If

                Me.oFormula = New Class_CatFormulas(Me.TxtCodigoFormula.Text)
                If Me.oFormula.Existe = False Then
                    Me.LblNombreProductoFinal.Text = "" : Me.LblCodigoArticulo.Text = "" : Me.txtPorcentajeCosto.Text = "0" : GoTo BuscaFormula : Exit Sub
                End If

                LblNombreProductoFinal.Text = oFormula.NOMBRE_FORMULA
                Me.txtPorcentajeCosto.Text = oFormula.PORCENTAJE_COSTO_PRODUCCION.ToString
                'Me.LblCodigoArticulo.Text = Me.oFormula.CODIGO_ARTICULO
                Me.oArticulo = New Class_CatArticulos(Me.oFormula.CODIGO_ARTICULO)
                Me.LblCodigoArticulo.Text = Me.oArticulo.DESCRIPCION 'Me.LblCodigoArticulo.Text & " " & Me.oArticulo.DESCRIPCION
                Me.Consultar()
                txtTAB(e)

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

                Me.oFormula = New Class_CatFormulas(Me.TxtCodigoFormula.Text)

                If Me.ArticuloSeriable(oFormula.CODIGO_ARTICULO) = True Then
                    Me.TxtCantidad.Text = CInt(Me.TxtCantidad.Text).ToString
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
                    Me.lblNombreCuentaContable.Text = oCuentas.NOMBRE_CUENTA
                Else
                    Me.TxtCuentaContable.Text = ""
                    Me.lblNombreCuentaContable.Text = ""
                    GoTo BuscarCuentas : Exit Sub
                End If

                txtTAB(e)

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
                        Me.lblNombreCuentaContable.Text = oCuentas.NOMBRE_CUENTA
                    End If
                End If

        End Select
    End Sub

    Private Sub CboAlmacen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboAlmacen1.SelectedIndexChanged, cboAlmacen2.SelectedIndexChanged
        If txtLEN(Me.TxtCodigoFormula.Text) = True Then
            Me.Consultar()
        End If

    End Sub

    Private Sub btnDetallarSeries_Click(sender As Object, e As EventArgs) Handles btnDetallarSeries.Click
        Me.PrepararSeries()
    End Sub

    Private Sub GridSeries_KeyDown(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridSeries.KeyDown
        Me.GestionaGridSeries(e)
    End Sub

#End Region

#Region "Métodos y procedimientos"

    Private Sub Inicializa()
        Try
            Me.tsbGrabar.Enabled = True
            Me.CboAlmacen1.Enabled = True
            Me.cboAlmacen2.Enabled = True

            Me.TxtCodigoFormula.Enabled = True
            Me.TxtExistencia.Enabled = True
            Me.TxtCuentaContable.Enabled = True
            Me.TxtCantidad.Enabled = True
            Me.TxtConcepto.Enabled = True
            Me.txtCostoMateriaPrima.Enabled = True
            Me.txtPorcentajeCosto.Enabled = True
            Me.txtCostoProduccion.Enabled = True
            Me.TxtCostoTotal.Enabled = True
            Me.TxtCostoUnitario.Enabled = True
            Me.Grid1.Enabled = True

            Me.TxtCodigoFormula.Text = ""
            Me.LblNombreProductoFinal.Text = ""
            Me.TxtExistencia.Text = "0.00"
            Me.TxtCantidad.Text = "0.00"
            Me.TxtCuentaContable.Text = ""
            Me.lblNombreCuentaContable.Text = ""

            Me.TxtConcepto.Text = ""
            Me.TxtCuentaContable.Text = ""
            Me.LblCodigoArticulo.Text = ""

            Me.txtCostoMateriaPrima.Text = "$ 0.00"
            Me.txtPorcentajeCosto.Text = "0"
            Me.txtCostoProduccion.Text = "$ 0.00"
            Me.TxtCostoTotal.Text = "$ 0.00"
            Me.TxtCostoUnitario.Text = "$ 0.00"

            Me.Grid1.DataSource = Nothing

            Me.TxtExistencia.ReadOnly = True
            Me.txtCostoMateriaPrima.ReadOnly = True
            Me.txtPorcentajeCosto.ReadOnly = True
            Me.txtCostoProduccion.ReadOnly = True
            Me.TxtCostoUnitario.ReadOnly = True
            Me.TxtCostoTotal.ReadOnly = True

            Me.TxtCuentaContable.Text = Empresa_Sistema.CUENTA_CONTABLE_COSTO_VENTAS
            Dim oCuentas As New Class_CatCuentas(Empresa_Sistema.CUENTA_CONTABLE_COSTO_VENTAS)
            lblNombreCuentaContable.Text = oCuentas.NOMBRE_CUENTA

            Me.InicializaGrid()
            Me.InicializaGridSeries()

            Me.Grid1.Visible = True
            Me.Grid1.Locked = True
            'Me.GridSeries.Locked = True

            Me.dtSeries = New DataTable("Series")

            Me.TxtCodigoFormula.Focus()

        Catch ex As Exception
            HandleError(Me.Name, "Inicializa", ex)
        End Try
    End Sub

    Private Sub InicializaGrid()
        Try
            FG_Grid_Limpiar(Me.Grid1)
            Me.Grid1.Rows = 2
            Me.FormateaGrid()

        Catch ex As Exception
            HandleError(Me.Text, "InicializaGrid", ex)
        End Try
    End Sub

    Private Sub InicializaGridSeries()
        Try
            FG_Grid_Limpiar(Me.GridSeries)
            Me.GridSeries.Rows = 2
            Me.FormateaGridSeries()

        Catch ex As Exception
            HandleError(Me.Text, "InicializaGridSeries", ex)
        End Try
    End Sub

    Function Grabar() As Boolean
        Dim bResultado As Boolean = False
        Dim sListaSeries As String = ""

        If txtLEN(Me.TxtCodigoFormula.Text) = False Then
            MsgBox("Inserte un código fórmula para el producto final.", MsgBoxStyle.Exclamation, Me.Text)
            Me.TxtCodigoFormula.Focus()
            Exit Function
        End If

        If valorNumerico(Me.TxtCantidad.Text) = 0 Then
            MsgBox("La cantidad debe ser mayor a 0.", MsgBoxStyle.Exclamation, Me.Text)
            Me.TxtCantidad.Focus()
            Exit Function
        End If

        Me.oFormula = New Class_CatFormulas(Me.TxtCodigoFormula.Text)
        If Me.ArticuloSeriable(Me.oFormula.CODIGO_ARTICULO) = True Then
            Me.TxtCantidad.Text = CInt(Me.TxtCantidad.Text).ToString
            If MsgBox("El producto final es serializable y solo puede darse entrada en cantidad entera, por lo que la cantidad a la que se le dara entrada " & _
            "es " & Me.TxtCantidad.Text & ", desea continuar con la transformación?", CType(vbYesNo + vbQuestion, MsgBoxStyle), Me.Name) = MsgBoxResult.No Then
                Me.TxtCantidad.Focus()
                Exit Function
            End If
        End If

        If Usuario.ValidaPermisoUsuarioTiposDocumentosConAfectaInventarios("TRANS", Me.CboAlmacen1.SelectedValue.ToString, "") = False Then
            MsgBox("El usuario " & Usuario.Nombre_Usuario & " no tiene permiso para realizar la transformacion.", MsgBoxStyle.Information, Me.Text)
            Exit Function
        End If

        If Me.SiTieneRenglones() = False Then
            MsgBox("La fórmula no tiene ingredientes.", MsgBoxStyle.Exclamation, Me.Text)
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

        If Me.ValidaNumerosSerie() = False Then
            Exit Function
        End If

        If Me.HaySeriesRepetidas = True Then
            Exit Function
        End If

        Dim sql As New Class_find("SELECT CODIGO_CONCEPTO_INVENTARIOS FROM CAT_CONCEPTOS_INVENTARIOS WHERE NOMBRE_CONCEPTO_INVENTARIOS='MATERIA PRIMA'")
        sCodigoConceptoInventario = sql.Result1

        Me.Totales()

        'Salida de ingredientes
        If Me.GrabaSalidaIngredientes() = False Then
            Exit Function
        End If

        'Entrada de producto final
        If Me.GrabaEntradaProductoFinal() = False Then
            Exit Function
        End If

        'Graba la relación del folio de entrada y salida de la transformación
        Me.oInventarios = New Class_Inventarios_Global
        If Me.oInventarios.GrabarRegistroTransformacion(Entrada, Salida, Usuario.Codigo_Usuario) = False Then
            MsgBox("No se grabó el registro de la transformación, avise al departamento de sistemas.", MsgBoxStyle.Exclamation, Me.Text)
        End If

        bResultado = True

        MsgBox("Transformación realizada exitosamente.", MsgBoxStyle.Information, Me.Text)

        Me.tsbGrabar.Enabled = False
        Me.CboAlmacen1.Enabled = False
        Me.cboAlmacen2.Enabled = False
        Me.TxtCodigoFormula.Enabled = False
        Me.TxtExistencia.Enabled = False
        Me.TxtCantidad.Enabled = False
        Me.TxtConcepto.Enabled = False
        Me.txtCostoMateriaPrima.Enabled = False
        Me.txtPorcentajeCosto.Enabled = False
        Me.txtCostoProduccion.Enabled = False
        Me.TxtCostoUnitario.Enabled = False
        Me.TxtCostoTotal.Enabled = False
        Me.TxtCuentaContable.Enabled = False

        Return bResultado

    End Function

    Private Function GrabaSalidaIngredientes() As Boolean
        Dim bResultado As Boolean = False
        Dim folioSalida As String
        Me.oInventarios = New Class_Inventarios_Global
        Dim sListaSeries As String = ""

        Try
            With oInventarios
                .FOLIO_MOVIMIENTO_INVENTARIO = ""
                .CODIGO_TIPO_DOCUMENTO = "SAI"
                .FOLIO_REFERENCIA = ""
                .CODIGO_ALMACEN1 = "" & Me.CboAlmacen1.SelectedValue.ToString()
                .FECHA = Now
                .CONCEPTO = "SALIDA POR TRANSFORMACIÓN PARA " & Me.LblNombreProductoFinal.Text & " : " & Me.TxtConcepto.Text
                .CODIGO_USUARIO = CInt("" & Usuario.Codigo_Usuario)
                .CODIGO_PLAZA = Usuario.Codigo_Plaza
                .TOTAL = valorNumericoD(Me.TxtCostoTotal.Text)
                .FOLIO_EMBARQUE = ""
                .CODIGO_CONCEPTO_INVENTARIOS = CInt(sCodigoConceptoInventario)

                If .Grabar("INSERTAR") = False Then
                    MsgBox("Error al tratar de insertar el movimiento de salida de inventario.", MsgBoxStyle.Exclamation, Me.Text)
                    Exit Function
                End If
                folioSalida = .FOLIO_MOVIMIENTO_INVENTARIO
                Salida = folioSalida

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

                        If Me.dtSeries.Rows.Count > 0 Then
                            For Each dRow In Me.dtSeries.Select("POSICION='" & i.ToString & "'")
                                sListaSeries = sListaSeries & dRow("POSICION").ToString & "," & dRow("CODIGO_ARTICULO").ToString & "," & dRow("ID_INVENTARIO_LOTES_COSTOS").ToString & "," & dRow("NUMERO_SERIE").ToString & "|"
                            Next

                            If txtLEN(sListaSeries) = True Then
                                sListaSeries = sListaSeries.Substring(0, sListaSeries.Length - 1) 'Para quitarle el último pipe que sale sobrando.
                            End If
                        End If

                        .oInventariosDetalle.LISTA_SERIES = sListaSeries

                        If .oInventariosDetalle.GrabaRenglon() = False Then
                            MsgBox("Error al tratar de grabar el detalle de la salida de inventario.", MsgBoxStyle.Exclamation, Me.Text)
                            Exit Function
                        End If

                    End If

                    sListaSeries = ""
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
        Dim folioEntrada As String, codigoProductoFinal As String = ""
        Me.oInventarios = New Class_Inventarios_Global
        Dim sListaSeries As String = ""
        Dim sListaSeriesCompleta As String = ""
        Dim sListaSeriesBase As String = ""

        Try
            Me.oFormula = New Class_CatFormulas(Me.TxtCodigoFormula.Text)
            If Me.oFormula.Existe Then
                codigoProductoFinal = Me.oFormula.CODIGO_ARTICULO
            End If

            With oInventarios
                .FOLIO_MOVIMIENTO_INVENTARIO = ""
                .CODIGO_TIPO_DOCUMENTO = "ENI"
                .FOLIO_REFERENCIA = ""
                .CODIGO_ALMACEN1 = "" & Me.cboAlmacen2.SelectedValue.ToString()
                .FECHA = Now
                .CONCEPTO = "ENTRADA POR TRANSFORMACIÓN PARA " & Me.LblNombreProductoFinal.Text & " : " & Me.TxtConcepto.Text
                .CODIGO_USUARIO = CInt("" & Usuario.Codigo_Usuario)
                .CODIGO_PLAZA = Usuario.Codigo_Plaza
                .TOTAL = valorNumericoD(Me.TxtCostoTotal.Text)
                .FOLIO_EMBARQUE = ""
                .CODIGO_CONCEPTO_INVENTARIOS = CInt(sCodigoConceptoInventario)

                If .Grabar("INSERTAR") = False Then
                    MsgBox("Error al tratar de insertar el movimiento de entrada de inventario.", MsgBoxStyle.Exclamation, Me.Text)
                    Exit Function
                End If
                folioEntrada = .FOLIO_MOVIMIENTO_INVENTARIO
                Entrada = folioEntrada

                'se graba el detalle
                .NuevoRenglon()
                .oInventariosDetalle.FOLIO_MOVIMIENTO_INVENTARIO = .FOLIO_MOVIMIENTO_INVENTARIO
                .oInventariosDetalle.CODIGO_ARTICULO = codigoProductoFinal
                .oInventariosDetalle.CANTIDAD = valorNumerico(Me.TxtCantidad.Text)
                .oInventariosDetalle.COSTO = valorNumerico(Me.TxtCostoUnitario.Text)
                .oInventariosDetalle.CUENTA_CONTABLE = Me.TxtCuentaContable.Text
                .oInventariosDetalle.IMPORTE = CDec(valorNumerico(Me.TxtCostoTotal.Text))
                .oInventariosDetalle.ID_ADICIONAL = 1

                If Me.dtSeries.Rows.Count > 0 Then
                    sListaSeriesBase = "1," & codigoProductoFinal & ",0,"

                    For i = 1 To CInt(Me.TxtCantidad.Text)

                        For Each dRow In Me.dtSeries.Select("ID_PRODUCTO_FINAL='" & i.ToString & "'")
                            sListaSeries = sListaSeries & dRow("NUMERO_SERIE").ToString & "-"
                        Next

                        If txtLEN(sListaSeries) = True Then
                            sListaSeries = sListaSeries.Substring(0, sListaSeries.Length - 1) 'Para quitarle la ultima coma que sale sobrando.
                            sListaSeriesCompleta = sListaSeriesCompleta & sListaSeriesBase & sListaSeries & "|"
                        End If

                        sListaSeries = ""

                    Next

                    sListaSeriesCompleta = sListaSeriesCompleta.Substring(0, sListaSeriesCompleta.Length - 1) 'Para quitarle el ultimo pipe que sale sobrando.

                End If

                .oInventariosDetalle.LISTA_SERIES = sListaSeriesCompleta

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
            Dim dTabla As DataTable = oFormula.ObtenerDetalleParaTransformaciones(Me.TxtCodigoFormula.Text, Me.CboAlmacen1.SelectedValue.ToString)

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

            oFormula.CODIGO_FORMULA = Me.TxtCodigoFormula.Text
            oFormula.Consultar()

            If oFormula.ES_CONFIDENCIAL Then
                Me.Grid1.Visible = False
            Else
                Me.Grid1.Visible = True
            End If

        Catch ex As Exception
            HandleError(Me.Text, "ConsultarIngredientes", ex)
        End Try

    End Sub

    Private Sub ConsultaExistenciaProductoFinal() 'La existencia se consulta en el almacen del producto terminado seleccionado
        Try
            Dim sql As New Class_find("SELECT E.EXISTENCIA FROM INVENTARIO_EXISTENCIA_ARTICULOS E INNER JOIN CAT_FORMULAS F ON(E.CODIGO_ARTICULO=F.CODIGO_ARTICULO) WHERE F.CODIGO_FORMULA = " & Me.TxtCodigoFormula.Text & " AND E.CODIGO_ALMACEN = '" & Me.cboAlmacen2.SelectedValue.ToString & "'")
            If txtLEN(sql.Result1.ToString) = True Then
                Me.TxtExistencia.Text = sql.Result1.ToString
            Else
                Me.TxtExistencia.Text = "0.00"
            End If

        Catch ex As Exception
            HandleError(Me.Text, "ConsultaExistenciaProductoFinal", ex)
        End Try
    End Sub

    Private Sub DesplegarAlmacenes()
        Try
            Dim oElementos As New Class_CatAlmacenes
            With Me.CboAlmacen1
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

            With Me.cboAlmacen2
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
                .Column(Me.iGyCantidadOriginal).DecimalLength = 5 'Empresa_Sistema.DECIMALES_CANTIDAD
                .Column(Me.iGyCantidadOriginal).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGyCantidadTotal).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyCantidadTotal).DecimalLength = 5 'Empresa_Sistema.DECIMALES_CANTIDAD
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

    Private Sub FormateaGridSeries()
        Try
            With Me.GridSeries
                .AutoRedraw = False
                .Cols = 7

                .DisplayFocusRect = False
                .DrawMode = FlexCell.DrawModeEnum.OwnerDraw
                .BorderStyle = FlexCell.BorderStyleEnum.FixedSingle
                .FixedRowColStyle = FlexCell.FixedRowColStyleEnum.Flat

                .Column(Me.igySeriePosicion).Visible = False
                .Column(Me.igySerieCodigo).Width = 130
                .Column(Me.igySerieDescripcion).Width = 370
                .Column(Me.igySerieIdInventarioLotesCostos).Visible = False
                .Column(Me.igySerieNumeroSerie).Width = 250
                .Column(Me.igyIdProductoFinal).Visible = False

                .Cell(0, Me.igySeriePosicion).Text = "Posición"
                .Cell(0, Me.igySerieCodigo).Text = "Código"
                .Cell(0, Me.igySerieDescripcion).Text = "Descripción"
                .Cell(0, Me.igySerieIdInventarioLotesCostos).Text = "Id lote"
                .Cell(0, Me.igySerieNumeroSerie).Text = "Número de serie"
                .Cell(0, Me.igyIdProductoFinal).Text = "Numero de producto final"

                .Column(Me.igySeriePosicion).Locked = True
                .Column(Me.igySerieCodigo).Locked = True
                .Column(Me.igySerieDescripcion).Locked = True
                .Column(Me.igySerieIdInventarioLotesCostos).Locked = True
                .Column(Me.igySerieNumeroSerie).Locked = True
                .Column(Me.igyIdProductoFinal).Locked = True

                .AutoRedraw = True
                .Refresh()

                .Row(.Rows - 1).Locked = True 'Para bloquear la edición del último renglón

            End With
        Catch ex As Exception
            HandleError(Me.Name, "FormateaGridSeries", ex)
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

            Me.txtCostoMateriaPrima.Text = FormatImporteContable(FG_Grid_SumaCol(Me.Grid1, CShort(Me.iGyTotal))).ToString
            Me.txtCostoProduccion.Text = FormatImporteContable(valorNumerico(Me.txtCostoMateriaPrima.Text) * (valorNumerico(Me.txtPorcentajeCosto.Text)) / 100).ToString
            Me.TxtCostoTotal.Text = FormatImporteContable(valorNumerico(Me.txtCostoMateriaPrima.Text) + valorNumerico(Me.txtCostoProduccion.Text)).ToString
            Me.TxtCostoUnitario.Text = FormatImporteContable(valorNumerico(Me.TxtCostoTotal.Text) / valorNumerico(Me.TxtCantidad.Text)).ToString

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

    Private Function ValidaExistenciaIngredientes() As Boolean
        Const sProcedure = "ValidaExistenciaIngredientes"
        Dim bResultado As Boolean = False
        Dim dCantidadSumadaPorArticulos As Double, dExistencia As Double
        Dim i As Integer, sCodigoArticulo As String = ""
        Me.oInventarios = New Class_Inventarios_Global
        Me.oFormula = New Class_CatFormulas(Me.TxtCodigoFormula.Text)

        Try
            For i = 1 To Me.Grid1.Rows - 1
                sCodigoArticulo = Me.Grid1.Cell(i, Me.iGyCodigo).Text
                If txtLEN(sCodigoArticulo) = True Then
                    Me.oArticulo = New Class_CatArticulos(sCodigoArticulo)
                    If Me.oArticulo.INVENTARIABLE <> "0" Then
                        dExistencia = Me.oInventarios.Existencia(sCodigoArticulo, Me.CboAlmacen1.SelectedValue.ToString)
                        If dExistencia <= 0 Then
                            Me.Show()
                            If Me.oFormula.ES_CONFIDENCIAL Then
                                MsgBox("No hay suficiente existencia de materias primas.", MsgBoxStyle.Exclamation, sProcedure)
                            Else
                                MsgBox("El artículo " & Me.Grid1.Cell(i, Me.iGyCodigo).Text & " " & Me.Grid1.Cell(i, Me.iGyDescripcion).Text & " no tiene existencia. ", MsgBoxStyle.Exclamation, sProcedure)
                            End If

                            Exit Function

                        Else
                            dCantidadSumadaPorArticulos = CDbl(Me.Grid1.Cell(i, Me.iGyCantidadTotal).Text)

                            If valorNumerico(dCantidadSumadaPorArticulos.ToString) > valorNumerico(dExistencia.ToString) Then
                                Me.Show()
                                If Me.oFormula.ES_CONFIDENCIAL Then
                                    MsgBox("No hay suficiente existencia de materias primas.", MsgBoxStyle.Exclamation, sProcedure)
                                Else
                                    MsgBox("El Artículo " & Me.Grid1.Cell(i, Me.iGyCodigo).Text & " " & Me.Grid1.Cell(i, Me.iGyDescripcion).Text & " no tiene suficiente existencia.", MsgBoxStyle.Exclamation, sProcedure)
                                End If

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

    Private Sub GestionaGridSeries(ByVal e As System.Windows.Forms.KeyEventArgs)
        Dim sLote As String = "", sCodigoArticulo As String = ""
        Dim oSerie As Class_Inventarios_Lotes_Series
        Try
            With Me.GridSeries
                Dim Renglon As Integer = .Selection.FirstRow
                Dim Columna As Integer = .Selection.FirstCol

                Select Case e.KeyCode
                    Case Keys.Return
                        If Columna = Me.igySerieNumeroSerie AndAlso txtLEN(.Cell(Renglon, Me.igySeriePosicion).Text) = True Then
                            sLote = .Cell(Renglon, Me.igySerieIdInventarioLotesCostos).Text
                            If txtLEN(sLote) = False Then
                                GoTo busca_serie
                                Return
                            End If

                            If Me.EstableceSerie(Renglon, sLote) = True Then
                                If Renglon + 1 < .Rows Then
                                    .Cell(Renglon + 1, Me.igySerieDescripcion).SetFocus()
                                Else
                                    .Cell(1, Me.igySerieDescripcion).SetFocus()
                                End If
                            End If
                        End If

                    Case Keys.F6
                        If Columna = Me.igySerieNumeroSerie AndAlso txtLEN(.Cell(Renglon, Me.igySeriePosicion).Text) = True Then
busca_serie:
                            oSerie = New Class_Inventarios_Lotes_Series
                            sCodigoArticulo = .Cell(Renglon, Me.igySerieCodigo).Text
                            sLote = oSerie.BusquedaVisual(sCodigoArticulo, Me.CboAlmacen1.SelectedValue.ToString)
                            If txtLEN(sLote) = True Then
                                If RepiteSerie(Renglon, sLote) = False Then
                                    Me.EstableceSerie(Renglon, sLote)
                                End If
                            End If
                        End If

                    Case Keys.F7
                        If Columna = Me.igySerieNumeroSerie AndAlso txtLEN(.Cell(Renglon, Me.igySeriePosicion).Text) = True Then
                            oSerie = New Class_Inventarios_Lotes_Series
                            sCodigoArticulo = .Cell(Renglon, Me.igySerieCodigo).Text
                            If txtLEN(sCodigoArticulo) = False Then
                                Return
                            End If

                            Dim lote As New Class_Inventarios_Lotes_Series.Lote
                            lote = oSerie.BusquedaVisualSeriesMultiplesFolio(sCodigoArticulo, Me.CboAlmacen1.SelectedValue.ToString)

                            If txtLEN(lote.FolioMovimiento) = True Then

                                Dim dtSeries As DataTable = oSerie.ObtieneRenglonesSeriesFolio(lote.FolioMovimiento, sCodigoArticulo)
                                If dtSeries.Rows.Count = 0 Then
                                    MsgBox("No se encontraron series disponibles del artículo " & sCodigoArticulo & " del folio " & lote.FolioMovimiento, MsgBoxStyle.Exclamation, Me.Text)
                                    Return
                                End If

                                Dim i As Integer, iArticulosPendientes As Integer = Me.CantidadArticulosPendientesSerie(sCodigoArticulo) 'iArticulosEncontrados As Integer
                                Dim iSeriesUsadas As Double = lote.Cantidad, iRowEncontrado As Integer = 0
                                For i = 1 To Me.GridSeries.Rows - 1
                                    If iArticulosPendientes <= 0 Or iSeriesUsadas <= 0 Then
                                        Exit For
                                    End If
                                    If Me.GridSeries.Cell(i, Me.igySerieCodigo).Text = sCodigoArticulo AndAlso txtLEN(Me.GridSeries.Cell(i, Me.igySerieIdInventarioLotesCostos).Text) = False Then
                                        iArticulosPendientes -= 1
                                        iSeriesUsadas -= 1
                                        Me.GridSeries.Cell(i, Me.igySerieIdInventarioLotesCostos).Text = dtSeries.Rows(iRowEncontrado)("ID_INVENTARIO_LOTES_COSTOS").ToString
                                        Me.GridSeries.Cell(i, Me.igySerieNumeroSerie).Text = dtSeries.Rows(iRowEncontrado)("NUMERO_SERIE").ToString
                                        iRowEncontrado += 1 'empieza desde el 0
                                    End If
                                Next
                            End If
                        End If

                    Case Keys.Delete
                        e.SuppressKeyPress = True

                End Select
            End With

        Catch ex As Exception
            HandleError(Me.Name, "GestionaGridSeries", ex)
        End Try
    End Sub

    Private Sub PrepararSeries()
        Try

            If IsNothing(Me.dtSeries) = False AndAlso Me.dtSeries.Rows.Count > 0 Then
                If MsgBox("Hay series ya especificadas, si continua tendrá que recapturar todas." & vbCrLf & "Esta seguro de continuar ?", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    Return
                End If
            End If

            Me.dtSeries.Clear()
            Me.dtSeries = New DataTable("Series")
            With Me.dtSeries
                .Columns.Add("POSICION", GetType(String))
                .Columns.Add("CODIGO_ARTICULO", GetType(String))
                .Columns.Add("DESCRIPCION", GetType(String))
                .Columns.Add("ID_INVENTARIO_LOTES_COSTOS", GetType(String))
                .Columns.Add("NUMERO_SERIE", GetType(String))
                .Columns.Add("ID_PRODUCTO_FINAL", GetType(String))
            End With
            Me.dtSeries.AcceptChanges()

            Dim dRow As DataRow

            Dim n As Integer = 0, count As Integer = 0, idProductoFinal As Integer = 0

            For i = 1 To Me.Grid1.Rows - 1
                If txtLEN(Me.Grid1.Cell(i, Me.iGyCodigo).Text) = True Then 'AndAlso Me.Grid1.Cell(i, Me.iGyCodigo).Text <> "-" AndAlso CInt(Me.Grid1.Cell(i, Me.iGyCantidadTotal).Text) > 0 Then
                    Dim oArticulo As New Class_CatArticulos(Me.Grid1.Cell(i, Me.iGyCodigo).Text)
                    If oArticulo.Existe = True AndAlso oArticulo.ES_SERIALIZABLE = True AndAlso oArticulo.INVENTARIABLE = "1" Then
                        idProductoFinal = 1
                        count = 0

                        For j = 1 To CInt(Me.Grid1.Cell(i, Me.iGyCantidadTotal).Text)
                            n = CInt(Me.Grid1.Cell(i, Me.iGyCantidadOriginal).Text)

                            dRow = Me.dtSeries.NewRow

                            dRow("POSICION") = i
                            dRow("CODIGO_ARTICULO") = Me.Grid1.Cell(i, Me.iGyCodigo).Text
                            dRow("DESCRIPCION") = Me.Grid1.Cell(i, Me.iGyDescripcion).Text
                            dRow("ID_INVENTARIO_LOTES_COSTOS") = ""
                            dRow("NUMERO_SERIE") = ""
                            dRow("ID_PRODUCTO_FINAL") = idProductoFinal

                            Me.dtSeries.Rows.Add(dRow)

                            count = count + 1
                            If count = n Then
                                count = 0
                                idProductoFinal = idProductoFinal + 1
                            End If
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

    Private Function EstableceSerie(ByVal Renglon As Integer, ByVal ID_INVENTARIO_LOTES_COSTOS As String) As Boolean
        Try
            Dim oSerie As New Class_Inventarios_Lotes_Series(ID_INVENTARIO_LOTES_COSTOS)
            If oSerie.Existe = True Then
                Me.GridSeries.Cell(Renglon, Me.igySerieIdInventarioLotesCostos).Text = oSerie.ID_INVENTARIO_LOTES_COSTOS
                Me.GridSeries.Cell(Renglon, Me.igySerieNumeroSerie).Text = oSerie.NUMERO_SERIE
                Return True
            End If
        Catch ex As Exception
            HandleError(Me.Name, "EstableceSerie", ex)
        End Try
    End Function

    Private Function RepiteSerie(ByVal Renglon As Integer, ByVal ID_INVENTARIO_LOTES_COSTOS As String) As Boolean
        Dim RenglonRepetido As Integer
        Try
            Me.dtSeries.AcceptChanges()

            For i = 1 To Me.GridSeries.Rows - 1
                If i <> Renglon Then
                    If txtLEN(Me.GridSeries.Cell(i, Me.igySerieCodigo).Text) = True Then
                        If ID_INVENTARIO_LOTES_COSTOS = Me.GridSeries.Cell(i, Me.igySerieIdInventarioLotesCostos).Text Then
                            RenglonRepetido = i

                            MsgBox("La serie " & Me.GridSeries.Cell(RenglonRepetido, igySerieNumeroSerie).Text & _
                                   " del artículo " & Me.GridSeries.Cell(RenglonRepetido, igySerieCodigo).Text & " esta repetida en el renglón " & RenglonRepetido & "." & vbCrLf & _
                                   "", MsgBoxStyle.Exclamation)
                            Me.GridSeries.Cell(RenglonRepetido, Me.igySerieNumeroSerie).SetFocus()

                            Return True

                        End If

                    End If
                End If

            Next
        Catch ex As Exception
            HandleError(Me.Name, "RepiteSerie", ex)
        End Try
    End Function

    Private Function CantidadArticulosPendientesSerie(ByVal sCodigoArticulo As String) As Integer
        Dim iArticulosEncontrados As Integer = 0
        Try
            For i = 1 To Me.GridSeries.Rows - 1
                If Me.GridSeries.Cell(i, Me.igySerieCodigo).Text = sCodigoArticulo AndAlso Me.GridSeries.Cell(i, Me.iGyCodigo).Text <> "-" AndAlso txtLEN(Me.GridSeries.Cell(i, Me.igySerieIdInventarioLotesCostos).Text) = False Then
                    iArticulosEncontrados += 1
                End If
            Next
        Catch ex As Exception
            HandleError(Me.Name, "CantidadArticulosPendientesSerie", ex)
        End Try
        Return iArticulosEncontrados
    End Function

    Private Function ArticuloSeriable(ByVal sCodigoArticulo As String) As Boolean
        Dim bResultado As Boolean = False

        Try
            Me.oArticulo = New Class_CatArticulos(sCodigoArticulo)

            If oArticulo.ES_SERIALIZABLE = True Then
                bResultado = True
            End If

        Catch ex As Exception
            HandleError(Me.Name, "ArticuloSeriable", ex)
        End Try

        Return bResultado
    End Function

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

            For i = 1 To Me.Grid1.Rows - 1
                If txtLEN(Me.Grid1.Cell(i, Me.iGyCodigo).Text) = True AndAlso Me.Grid1.Cell(i, Me.iGyCodigo).Text <> "-" AndAlso CInt(Me.Grid1.Cell(i, Me.iGyCantidadTotal).Text) > 0 Then
                    Dim oArticulo As New Class_CatArticulos(Me.Grid1.Cell(i, Me.iGyCodigo).Text)
                    If oArticulo.Existe = True AndAlso oArticulo.ES_SERIALIZABLE = True AndAlso oArticulo.INVENTARIABLE = "1" Then
                        For j = 1 To CInt(Me.Grid1.Cell(i, Me.iGyCantidadTotal).Text)
                            dRow = dtSeriesTemp.NewRow

                            dRow("POSICION") = i
                            dRow("CODIGO_ARTICULO") = Me.Grid1.Cell(i, Me.iGyCodigo).Text
                            dRow("DESCRIPCION") = Me.Grid1.Cell(i, Me.iGyDescripcion).Text

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

    Private Function HaySeriesRepetidas() As Boolean
        Dim RenglonRepetido As Integer

        Try
            Me.dtSeries.AcceptChanges()

            For i = 1 To Me.GridSeries.Rows - 1
                If txtLEN(Me.GridSeries.Cell(i, Me.igySerieCodigo).Text) = True Then
                    For z = i + 1 To Me.GridSeries.Rows - 1
                        If Me.GridSeries.Cell(i, Me.igySerieIdInventarioLotesCostos).Text = Me.GridSeries.Cell(z, Me.igySerieIdInventarioLotesCostos).Text Then
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

#End Region

End Class