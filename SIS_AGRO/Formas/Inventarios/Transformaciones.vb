Option Strict On

Imports CrystalDecisions.CrystalReports.Engine

Public Class Transformaciones
    Private Estado As enumEstados
    Private oInventarios As New Class_Inventarios_Global
    Private oDocumentos As Class_Cat_tiposDocumentos
    Private oArticulos As New Class_CatArticulos

#Region "Columnas grid"
    Private iGyCodigo As Integer = 1
    Private iGyDescripcion As Integer = 2
    Private iGyUnidad As Integer = 3
    Private iGyCantidad As Integer = 4
    Private iGyExistencia As Integer = 5
    Private iGyCosto As Integer = 6
    Private iGyTotal As Integer = 7
#End Region

    Private bAplicando As Boolean

    Private Enum enumEstados
        NUEVO
        GRABADO
        APLICADO
        CANCELADO
    End Enum

#Region "Propiedades"

#End Region

#Region "Opciones"
    Private Sub tsbNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbNuevo.Click
        Me.Inicializa()
    End Sub

    Private Sub tsbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGrabar.Click
        If Me.Grabar() = True Then
 
        End If
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

    Private Sub TxtCodigoArticulo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodigoArticulo.KeyDown
        Dim oArticulo As New Class_CatArticulos
        Dim sText As String

        Select Case e.KeyCode
            Case Keys.F6
BuscarArticulo:
                sText = oArticulo.BusquedaVisual_PorDescripcion

                If Me.ValidaArticulo(sText) = False Then
                    GoTo BuscarArticulo
                End If
                Me.TxtCodigoArticulo.Text = sText

            Case Keys.Enter
                oArticulo = New Class_CatArticulos(Me.TxtCodigoArticulo.Text)
                If oArticulo.Existe = False Then
                    Me.LblNombreProductoFinal.Text = "" : GoTo BuscarArticulo : Exit Sub
                End If

                If Me.ValidaArticulo(Me.TxtCodigoArticulo.Text) = False Then
                    Me.LblNombreProductoFinal.Text = "" : GoTo BuscarArticulo : Exit Sub
                End If

                LblNombreProductoFinal.Text = oArticulo.DESCRIPCION
                Me.ConsultaIngredientes()

                txtTAB(e)
        End Select
    End Sub

    Private Sub TxtConcepto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtConcepto.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter

        End Select
    End Sub

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtConcepto.KeyPress, TxtCodigoArticulo.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub txtCantidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCantidad.KeyPress
        Dim txt As TextBox = CType(sender, TextBox)
        txtSoloNumerosDecimales(e, txt.Text)
        txtNoBeep(e)
    End Sub

#End Region

#Region "Métodos y procedimientos"

    Private Sub Inicializa()
        Try
            Me.TxtCodigoArticulo.Text = ""
            Me.LblNombreProductoFinal.Text = ""
            Me.TxtExistencia.Text = ""
            Me.TxtCantidad.Text = ""
            Me.TxtCosto.Text = ""
            Me.TxtCostoTotal.Text = ""
            Me.TxtConcepto.Text = ""
            Me.TxtTotal.Text = ""
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
            Me.Totales()

        Catch ex As Exception
            HandleError(Me.Text, "InicializaGrid", ex)
        End Try
    End Sub

    Function Grabar() As Boolean
        Dim bResultado As Boolean = False
        Dim i As Integer
        Dim sListaSeries As String = ""

        'If Usuario.ValidaPermisoUsuarioTiposDocumentosConAfectaInventarios(Me.CboDocumento.SelectedValue.ToString, Me.CboAlmacen.SelectedValue.ToString, Me.CboAlmacenDestino.SelectedValue.ToString) = False Then
        '    'MsgBox("El usuario " & Usuario.Nombre_Usuario & " no tiene permiso para realizar la transferencia.", MsgBoxStyle.Information, Me.Text)
        '    Exit Function
        'End If

        If SiTieneRenglones() = False Then
            MsgBox("Asígne los artículos del movimiento.", MsgBoxStyle.Exclamation, Me.Text)
            Exit Function
        End If

        If Me.SiTieneCantidad() = False Then
            MsgBox("La cantidad de los artículos debe de ser mayor a cero.", MsgBoxStyle.Exclamation, Me.Text)
            Exit Function
        End If

        Me.Totales()

        Select Case Me.Estado
            Case enumEstados.NUEVO, enumEstados.GRABADO
                Me.oInventarios = New Class_Inventarios_Global
                Try
                    With oInventarios
                        .CODIGO_ALMACEN1 = "" & Me.CboAlmacen.SelectedValue.ToString()
                        .CONCEPTO = "" & Me.TxtConcepto.Text
                        .CODIGO_USUARIO = CInt("" & Usuario.Codigo_Usuario)
                        .CODIGO_PLAZA = Usuario.Codigo_Plaza

                        Select Case Me.Estado
                            Case enumEstados.NUEVO
                                If .Insertar() = False Then
                                    MsgBox("Error al tratar de insertar el movimiento de inventario.", MsgBoxStyle.Exclamation, Me.Text)
                                    Exit Function
                                End If

                            Case enumEstados.GRABADO
                                If Me.oInventarios.Actualizar() = False Then
                                    MsgBox("Error al tratar de actualizar el movimiento de inventario.", MsgBoxStyle.Exclamation, Me.Text)
                                    Exit Function
                                End If
                        End Select

                        'se graba el detalle
                        For i = 1 To Me.Grid1.Rows - 1
                            If txtLEN(Me.Grid1.Cell(i, Me.iGyCodigo).Text) = True Then
                                .NuevoRenglon()
                                .oInventariosDetalle.FOLIO_MOVIMIENTO_INVENTARIO = .FOLIO_MOVIMIENTO_INVENTARIO
                                .oInventariosDetalle.CODIGO_ARTICULO = Me.Grid1.Cell(i, Me.iGyCodigo).Text
                                .oInventariosDetalle.CANTIDAD = valorNumerico(Me.Grid1.Cell(i, Me.iGyCantidad).Text)
                                .oInventariosDetalle.COSTO = valorNumerico(Me.Grid1.Cell(i, Me.iGyCosto).Text)

                                .oInventariosDetalle.LISTA_SERIES = sListaSeries

                                If .oInventariosDetalle.GrabaRenglon() = False Then
                                    MsgBox("Error al tratar de grabar el detalle.", MsgBoxStyle.Exclamation, Me.Text)
                                    Exit Function
                                End If

                                sListaSeries = ""
                            End If
                        Next

                        Dim sListaCuentas As String = ""

                        bResultado = True
                        If Me.bAplicando = False Then
                            MsgBox("Movimiento de inventario grabado satisfactoriamente.", MsgBoxStyle.Information, Me.Text)
                        End If
                    End With
                Catch ex As Exception
                    HandleError(Me.Name, "Grabar", ex)
                Finally
                    Me.oInventarios = Nothing
                End Try
        End Select

            Return bResultado
    End Function

    Private Sub ConsultaIngredientes()
        Dim oFormula As New Class_CatFormulas()

        Try
            Me.Grid1.DataSource = oFormula.ObtenerDetalleParaTransformaciones(Me.TxtCodigoArticulo.Text, Me.CboAlmacen.SelectedValue.ToString)
            Me.FormateaGrid()
            Me.Totales()

        Catch ex As Exception
            HandleError(Me.Text, "ConsultarIngredientes", ex)
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
                    Me.oArticulos = New Class_CatArticulos(sCodigoArticulo)
                    If Me.oArticulos.INVENTARIABLE <> "0" Then
                        dExistencia = oInventarios.Existencia(sCodigoArticulo, Me.CboAlmacen.SelectedValue.ToString)
                        If dExistencia <= 0 Then
                            Me.Show()
                            MsgBox("El artículo " & Me.Grid1.Cell(i, Me.iGyDescripcion).Text & " que intenta agregar no tiene existencia. ", MsgBoxStyle.Exclamation, sProcedure)
                            Exit Function
                        Else 
                            dCantidadSumadaPorArticulos = CDbl(Me.Grid1.Cell(i, Me.iGyCantidad).Text)

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

                .Cols = 8

                .DisplayFocusRect = False
                .DrawMode = FlexCell.DrawModeEnum.OwnerDraw
                .BorderStyle = FlexCell.BorderStyleEnum.FixedSingle
                .FixedRowColStyle = FlexCell.FixedRowColStyleEnum.Flat

                .BackColor1 = Color.FromArgb(231, 235, 247)
                .BackColor2 = Color.FromArgb(239, 243, 255)
                .CellBorderColorFixed = Color.Black
                .GridColor = Color.FromArgb(148, 190, 231)

                .Cell(0, Me.iGyCodigo).Text = "Codigo"
                .Cell(0, Me.iGyDescripcion).Text = "Descripcion"
                .Cell(0, Me.iGyUnidad).Text = "Unidad"
                .Cell(0, Me.iGyCantidad).Text = "Cantidad"
                .Cell(0, Me.iGyExistencia).Text = "Existencia"
                .Cell(0, Me.iGyCosto).Text = "Costo"
                .Cell(0, Me.iGyTotal).Text = "Total"

                .Column(Me.iGyCantidad).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyCantidad).DecimalLength = Empresa_Sistema.DECIMALES_CANTIDAD
                .Column(Me.iGyCantidad).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGyExistencia).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyExistencia).DecimalLength = Empresa_Sistema.DECIMALES_CANTIDAD
                .Column(Me.iGyExistencia).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGyCosto).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyCosto).DecimalLength = Empresa_Sistema.DECIMALES_PRECIO
                .Column(Me.iGyCosto).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGyTotal).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyTotal).DecimalLength = Empresa_Sistema.DECIMALES_PRECIO
                .Column(Me.iGyTotal).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGyCodigo).Width = 100
                .Column(Me.iGyDescripcion).Width = 190
                .Column(Me.iGyUnidad).Width = 80
                .Column(Me.iGyCantidad).Width = 80
                .Column(Me.iGyExistencia).Width = 80
                .Column(Me.iGyCosto).Width = 100
                .Column(Me.iGyTotal).Width = 90

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
                If Len("" & Me.Grid1.Cell(I, Me.iGyCantidad).Text) > 0 Then
                    Dcantidad = Val(0 & Me.Grid1.Cell(I, Me.iGyCantidad).Text)
                    DPrecio = Val(0 & Me.Grid1.Cell(I, Me.iGyCosto).Text)

                    If Dcantidad > 0 Then
                        dImporte = (DPrecio * Dcantidad)
                        dImporte = Redondear(dImporte)
                        Me.Grid1.Cell(I, Me.iGyTotal).Text = dImporte.ToString
                    End If
                End If
            Next I

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

    Private Function SiTieneImporte() As Boolean
        Dim bResultado As Boolean = False
        Try
            Dim i As Integer
            For i = 1 To Me.Grid1.Rows - 1
                If txtLEN(Me.Grid1.Cell(i, Me.iGyCodigo).Text) = True Then
                    'If valorNumerico(Me.Grid1.Cell(i, Me.iGyImporte).Text) = 0 Then
                    '    Return False
                    'End If
                End If
            Next
            bResultado = True
        Catch ex As Exception
            HandleError(Me.Name, "SiTieneImporte", ex)
        End Try
        Return bResultado
    End Function

    Private Function SiTieneCantidad() As Boolean
        Dim bResultado As Boolean = False
        Try
            Dim i As Integer
            For i = 1 To Me.Grid1.Rows - 1
                If txtLEN(Me.Grid1.Cell(i, Me.iGyCodigo).Text) = True Then
                    If valorNumerico(Me.Grid1.Cell(i, Me.iGyCantidad).Text) = 0 Then
                        Return False
                    End If
                End If
            Next
            bResultado = True
        Catch ex As Exception
            HandleError(Me.Name, "SiTieneCantidad", ex)
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

#End Region

End Class