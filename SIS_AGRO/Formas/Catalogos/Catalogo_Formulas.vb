Option Strict On
Imports System.Data
Imports System.Data.SqlClient

Public Class Catalogo_Formulas
    Private oFormulas As New Class_CatFormulas

#Region "Campos"

#Region "Campos ligados a la tabla"

#End Region

#Region "Campos públicos"

#End Region

#Region "Campos privados"
    Private Enum enumEstados
        NUEVO
        EDICION
        CONSULTA
    End Enum

    Private Estado As enumEstados
    Private Run As Boolean
    Private msgElemento As String
    Private msgElementos As String
#End Region
#Region "Campos de sistema"
    Private _Nombre_Catalogo As String
    Private _Nombre_Reporte As String
    Private _Conexion As SqlConnection
    Private _QuerySelect As String
    Private _QueryOrder As String
#End Region

#End Region

#Region "Propiedades"

#Region "Propiedades Campos de la tabla"

#End Region

#Region "Propiedades de campos ligados a la tabla"

#End Region

#Region "Propiedades públicos"

#End Region

#Region "Propiedades de campos privados"

#End Region
#Region "Propiedades de campos de sistema"
    Public ReadOnly Property Nombre_Catalogo() As String
        Get
            Return Me._Nombre_Catalogo
        End Get
    End Property

    Public Property Nombre_Reporte() As String
        Get
            Return Me._Nombre_Reporte
        End Get
        Set(ByVal value As String)
            Me._Nombre_Reporte = value
        End Set
    End Property

#End Region

#End Region

#Region "Columnas Grid"
    Private iGyCodigoArticulo As Integer = 1
    Private iGyDescripcion As Integer = 2
    Private iGyUnidad As Integer = 3
    Private iGyCantidad As Integer = 4
    Private iGyIdFormulaDetalle As Integer = 5
#End Region

#Region "Constructor y destructor"
    'Inicializa al objeto.
    Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

        Try
            Me.msgElemento = "Fórmula"
            Me.msgElementos = "Fórmulas"
            Me.Run = False
            Estado = enumEstados.CONSULTA
            Me.Cambia_Estado()
            Me.InicializaElemento()
            Me.DesplegarElementos()
            Me.cboEstatusFiltro.SelectedIndex = 0
            Me.Run = True
        Catch ex As Exception
            HandleError(Me.Name, "New", ex)
        End Try

    End Sub

    Protected Overrides Sub Finalize()
        'Me._Conexion.Dispose()
        MyBase.Finalize()
    End Sub


#End Region

#Region "Opciones"
    Private Sub tsbNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbNuevo.Click
        Me.Estado = enumEstados.NUEVO
        Me.Cambia_Estado()
    End Sub

    Private Sub tsbEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbEditar.Click
        Me.Estado = enumEstados.EDICION
        Me.Cambia_Estado()
    End Sub

    Private Sub tsbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGrabar.Click
        If Me.Validar() = False Then
            Return
        End If

        Dim sMsg As String = ""
        Select Case Me.Estado
            Case enumEstados.EDICION
                sMsg = " grabar las modificaciones del "
            Case enumEstados.NUEVO
                sMsg = " agregar el "
            Case Else
                MsgBox("Me.Estado no válido.", MsgBoxStyle.Exclamation, Me.Text)
                Return
        End Select
        sMsg = "Deseas " & sMsg & Me.msgElemento & " : " & Me.TxtNombreFormula.Text & " ?"
        If MsgBox(sMsg, CType(CInt(MsgBoxStyle.Question) + CInt(MsgBoxStyle.YesNo), MsgBoxStyle), Me.Text) = MsgBoxResult.Yes Then
            Me.Grabar()
        End If
    End Sub

    Private Sub tsbCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCancelar.Click
        Me.Estado = enumEstados.CONSULTA
        Me.Cambia_Estado()
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub

    Private Sub tsbImprimirListado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimirListado.Click
        Me.oFormulas.Imprimir_Listado()
    End Sub
#End Region

#Region "Métodos y procedimientos"
    Private Sub Refrescar()
        Me.DesplegarElementos()
    End Sub

    Private Sub Cambia_Estado()
        Try
            Select Case Me.Estado
                Case enumEstados.NUEVO
                    Me.gBoxInformacion.Enabled = True
                    Me.gBoxBusquedaRapida.Enabled = False
                    Me.tssLabelEstado.Text = "Agregando"
                    Me.tsbNuevo.Enabled = False
                    Me.tsbEditar.Enabled = False
                    Me.tsbGrabar.Enabled = True
                    Me.tsbCancelar.Enabled = True

                    Me.TxtCodigoFormula.Enabled = False
                    Me.TxtNombreFormula.Enabled = True
                    Me.TxtCodigoArticulo.Enabled = True
                    Me.txtCostoProduccion.Enabled = True
                    Me.Grid1.Locked = False

                    Me.InicializaElemento()

                    Me.TxtCodigoFormula.Text = oFormulas.CodigoSiguiente()

                    Me.TxtCodigoFormula.Focus()

                Case enumEstados.EDICION
                    Me.gBoxInformacion.Enabled = True
                    Me.gBoxBusquedaRapida.Enabled = False
                    Me.tssLabelEstado.Text = "Editando"
                    Me.tsbNuevo.Enabled = False
                    Me.tsbEditar.Enabled = False
                    Me.tsbGrabar.Enabled = True
                    Me.tsbCancelar.Enabled = True

                    Me.TxtCodigoFormula.Enabled = False
                    Me.TxtNombreFormula.Enabled = True
                    Me.CboEstatus.Enabled = True
                    Me.TxtCodigoArticulo.Enabled = True
                    Me.txtCostoProduccion.Enabled = True
                    Me.Grid1.Locked = False

                    Me.TxtNombreFormula.Focus()

                Case enumEstados.CONSULTA

                    Me.gBoxInformacion.Enabled = False
                    Me.gBoxBusquedaRapida.Enabled = True
                    Me.tssLabelEstado.Text = "Consultando"
                    Me.tsbNuevo.Enabled = True
                    Me.tsbEditar.Enabled = False
                    Me.tsbGrabar.Enabled = False
                    Me.tsbCancelar.Enabled = False
                    Me.Grid1.Locked = True

                    Me.txtFiltro.Focus()

            End Select
            Application.DoEvents()
        Catch ex As Exception
            HandleError(Me.Name, "Cambia_Estado", ex)
        End Try
    End Sub

    Private Sub InicializaElemento()
        Me.TxtCodigoFormula.Text = ""
        Me.TxtNombreFormula.Text = ""
        Me.CboEstatus.SelectedIndex = 0
        Me.TxtCodigoArticulo.Text = ""
        Me.LblNombreProductoFinal.Text = ""
        Me.txtCostoProduccion.Text = "0.00"

        Me.InicializaGrid()

    End Sub

    Private Sub DesplegarElementos()
        Try
            With Me.Grid
                .DataSource = oFormulas.ObtenerElementosFiltro(Me.txtFiltro.Text, Me.cboEstatusFiltro.Text)
                .Columns("CODIGO_FORMULA").Width = 50
                .Columns("NOMBRE_FORMULA").Width = 350
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarElementos", ex)
        End Try
    End Sub

    Private Sub LlenaElemento(ByVal iCodigo_Elemento As String)
        Try
            Me.oFormulas.CODIGO_FORMULA = iCodigo_Elemento
            If Me.oFormulas.Consultar Then
                With Me.oFormulas
                    Me.TxtCodigoFormula.Text = .CODIGO_FORMULA.ToString
                    Me.TxtNombreFormula.Text = .NOMBRE_FORMULA.ToString
                    Me.TxtCodigoArticulo.Text = .CODIGO_ARTICULO.ToString
                    Me.txtCostoProduccion.Text = .PORCENTAJE_COSTO_PRODUCCION.ToString

                    Dim sql As New Class_find("SELECT DESCRIPCION FROM CAT_ARTICULOS WHERE CODIGO_ARTICULO='" & Me.TxtCodigoArticulo.Text & "'")
                    Me.LblNombreProductoFinal.Text = sql.Result1.ToString

                    If .Estatus = "A" Then
                        Me.CboEstatus.SelectedIndex = 0
                    Else
                        Me.CboEstatus.SelectedIndex = 1
                    End If

                    'Me.Grid1.DataSource = .ObtenerDetalle(.CODIGO_FORMULA)
                    'Consulta datos detalle
                    Dim dTabla As DataTable = .ObtenerDetalle(.CODIGO_FORMULA)
                    Me.Grid1.AutoRedraw = False
                    Me.Grid1.Rows = 1 'Trae dos porque en docs nuevos se pone un row en blanco, y si se dejan aqui dos agrega a partir del 3 y queda un hueco
                    For Each dRow As DataRow In dTabla.Rows
                        Me.Grid1.AddItem(dRow("CODIGO_ARTICULO").ToString & Chr(9) & dRow("DESCRIPCION").ToString & Chr(9) & dRow("UNIDAD_VENTA").ToString & Chr(9) & _
                                         dRow("CANTIDAD").ToString & Chr(9) & dRow("ID_FORMULA_DETALLE").ToString & Chr(9))
                    Next

                    Me.FormateaGrid()

                End With
            End If
        Catch ex As Exception
            HandleError(Me.Name, "LlenaElemento", ex)
        End Try
    End Sub

    Private Sub Grabar()
        Dim Grabado As Boolean = False
        Dim i As Integer, msg As String = ""

        Select Case Me.Estado
            Case enumEstados.NUEVO, enumEstados.EDICION
                Try
                    With Me.oFormulas

                        .CODIGO_FORMULA = Me.TxtCodigoFormula.Text
                        .NOMBRE_FORMULA = Me.TxtNombreFormula.Text
                        .CODIGO_ARTICULO = Me.TxtCodigoArticulo.Text
                        .Estatus = Strings.Left(Me.CboEstatus.Text, 1)
                        .PORCENTAJE_COSTO_PRODUCCION = CDec(Me.txtCostoProduccion.Text)

                        Select Case Me.Estado
                            Case enumEstados.NUEVO
                                If .Insertar() = True Then
                                    Grabado = True
                                End If
                            Case enumEstados.EDICION
                                If .Actualizar() = True Then
                                    Grabado = True
                                End If
                        End Select

                        'graba los ingredientes
                        For i = 1 To Me.Grid1.Rows - 1
                            If txtLEN(Me.Grid1.Cell(i, Me.iGyCodigoArticulo).Text) = True Then
                                .NuevoRenglon()
                                .oFormulasDetalle.CODIGO_FORMULA = Me.TxtCodigoFormula.Text
                                .oFormulasDetalle.CODIGO_ARTICULO = Me.Grid1.Cell(i, Me.iGyCodigoArticulo).Text
                                .oFormulasDetalle.CANTIDAD = valorNumerico(Me.Grid1.Cell(i, Me.iGyCantidad).Text)
                                .oFormulasDetalle.ID_FORMULA_DETALLE = Me.Grid1.Cell(i, Me.iGyIdFormulaDetalle).Text

                                Select Case Me.Estado
                                    Case enumEstados.NUEVO
                                        If .oFormulasDetalle.Insertar() = False Then
                                            MsgBox("Error al tratar de insertar el detalle.", MsgBoxStyle.Exclamation, Me.Text)
                                            Exit Sub
                                        End If
                                    Case enumEstados.EDICION
                                        If txtLEN(Me.Grid1.Cell(i, Me.iGyIdFormulaDetalle).Text) = True Then
                                            If .oFormulasDetalle.Actualizar() = False Then
                                                MsgBox("Error al tratar de actualizar el detalle.", MsgBoxStyle.Exclamation, Me.Text)
                                                Exit Sub
                                            End If
                                        Else 'Si no tiene id formula significa que se agrego un ingrediente nuevo a la formula y lo inserta
                                            If .oFormulasDetalle.Insertar() = False Then
                                                MsgBox("Error al tratar de insertar el detalle.", MsgBoxStyle.Exclamation, Me.Text)
                                                Exit Sub
                                            End If
                                        End If
                                        
                                End Select
                            End If
                        Next

                        If Grabado = True Then
                            MsgBox(Me.msgElemento & " grabada satisfactoriamente.", MsgBoxStyle.Information, Me.Name)
                            Me.Refrescar()
                            Me.Estado = enumEstados.CONSULTA
                            Me.Cambia_Estado()
                        End If

                    End With
                Catch ex As Exception
                    HandleError(Me.Name, "Grabar", ex)
                    Me.Estado = enumEstados.CONSULTA
                    Me.Cambia_Estado()
                End Try
        End Select
    End Sub

    Private Function Validar() As Boolean
        Dim bResultado As Boolean = False

        Try

            If txtLEN(Me.TxtNombreFormula.Text) = False Then
                MsgBox("Asígne nombre a la fórmula.", MsgBoxStyle.Exclamation, Me.Text)
                Me.TxtNombreFormula.Focus()
                Return bResultado
            End If

            If txtLEN(Me.TxtCodigoArticulo.Text) = False Then
                MsgBox("Asígne un producto final.", MsgBoxStyle.Exclamation, Me.Text)
                Me.TxtCodigoArticulo.Focus()
                Return bResultado
            End If

            If txtLEN(Me.txtCostoProduccion.Text) = False Then
                Me.txtCostoProduccion.Text = "0.00"
            End If

            If Me.Grid1.Rows < 2 Then
                MsgBox("La fórmula debe tener al menos un ingrediente.", MsgBoxStyle.Exclamation, Me.Text)
                Me.Grid1.Rows = 2
                Me.Grid1.Cell(1, Me.iGyCodigoArticulo).SetFocus()
                Return bResultado
            End If

            If txtLEN(Me.Grid1.Cell(1, Me.iGyCodigoArticulo).Text) = False Then
                MsgBox("La fórmula debe tener al menos un ingrediente.", MsgBoxStyle.Exclamation, Me.Text)
                Me.Grid1.Cell(1, Me.iGyCodigoArticulo).SetFocus()
                Return bResultado
            End If

            For i As Integer = 1 To Me.Grid1.Rows - 1
                If Me.Grid1.Cell(i, Me.iGyCodigoArticulo).Text = Me.TxtCodigoArticulo.Text Then
                    MsgBox("Los ingredientes deben ser distintos al producto final.", MsgBoxStyle.Exclamation, Me.Text)
                    Me.Grid1.Cell(i, Me.iGyCodigoArticulo).SetFocus()
                    Return bResultado
                End If
            Next

            bResultado = True
        Catch ex As Exception
            HandleError(Me.Name, "Validar", ex)
        End Try
        Return bResultado
    End Function

    Private Sub InicializaGrid()
        Try
            Me.Grid1.DataSource = Nothing
            FG_Grid_Limpiar(Me.Grid1)
            Me.Grid1.Rows = 2
            Me.FormateaGrid()
        Catch ex As Exception
            HandleError(Me.Text, "InicializaGrid", ex)
        End Try
    End Sub

    Private Sub FormateaGrid()
        With Me.Grid1
            .AutoRedraw = False
            .Cols = 6
            .DisplayFocusRect = False
            .DrawMode = FlexCell.DrawModeEnum.OwnerDraw
            .BorderStyle = FlexCell.BorderStyleEnum.FixedSingle
            .FixedRowColStyle = FlexCell.FixedRowColStyleEnum.Flat
            .GridColor = Color.FromArgb(148, 190, 231)

            .Cell(0, Me.iGyCodigoArticulo).Text = "Código"
            .Cell(0, Me.iGyDescripcion).Text = "Descripción"
            .Cell(0, Me.iGyUnidad).Text = "Unidad"
            .Cell(0, Me.iGyCantidad).Text = "Cantidad"
            .Cell(0, Me.iGyIdFormulaDetalle).Text = "Id formula detalle"

            .Column(Me.iGyCantidad).Mask = FlexCell.MaskEnum.Numeric
            .Column(Me.iGyCantidad).DecimalLength = Empresa_Sistema.DECIMALES_CANTIDAD
            .Column(Me.iGyCantidad).Alignment = FlexCell.AlignmentEnum.RightCenter

            .Column(Me.iGyDescripcion).Locked = True
            .Column(Me.iGyUnidad).Locked = True

            .Column(Me.iGyCodigoArticulo).Width = 80
            .Column(Me.iGyDescripcion).Width = 255
            .Column(Me.iGyUnidad).Width = 60
            .Column(Me.iGyCantidad).Width = 80

            .Column(Me.iGyIdFormulaDetalle).Visible = False

            .AutoRedraw = True
            .Refresh()
        End With
    End Sub

    Private Sub GestionaGrid(ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            Dim Columna As Integer, Renglon As Integer
            Dim StrCod As String, dCantidad As Double
            Dim oArticulos As Class_CatArticulos
            Dim i As Integer

            Columna = Me.Grid1.Selection.FirstCol
            Renglon = Me.Grid1.Selection.FirstRow
            StrCod = Me.Grid1.Cell(Renglon, Me.iGyCodigoArticulo).Text
            dCantidad = valorNumerico(Me.Grid1.Cell(Renglon, Me.iGyCantidad).Text)

            Select Case e.KeyCode
                Case Keys.Enter

                    Select Case Columna
                        Case Me.iGyCodigoArticulo
                            If txtLEN(StrCod) = False Then
                                GoTo BuscaArticulos
                            End If
LlenaLinea:
                            oArticulos = New Class_CatArticulos(StrCod)
                            If oArticulos.Existe = False Then
                                GoTo BuscaArticulos
                            End If

                            If StrCod = Me.TxtCodigoArticulo.Text Then
                                MsgBox("Los ingredientes deben ser distintos al producto final.", MsgBoxStyle.Exclamation, Me.Text)
                                GoTo BuscaArticulos
                            End If

                            For i = 1 To Me.Grid1.Rows - 1
                                If Me.Grid1.Cell(i, Me.iGyCodigoArticulo).Text = StrCod And i <> Renglon Then
                                    MsgBox("Ya existe ese ingrediente en el renglón " & i, MsgBoxStyle.Exclamation, Me.Text)
                                    Exit Sub
                                End If
                            Next

                            If StrCod = Empresa_Sistema.CODIGO_ARTICULO_NO_INVENTARIABLE_COMPRA_PROVEEDOR Then
                                Me.Grid1.Cell(Renglon, Me.iGyDescripcion).Text = ""
                                Me.Grid1.Cell(Renglon, Me.iGyUnidad).Text = ""
                                Me.Grid1.Cell(Renglon, Me.iGyCantidad).Text = "0"

                                Me.Grid1.Column(Me.iGyDescripcion).Locked = False
                                Me.Grid1.Column(Me.iGyUnidad).Locked = False
                            Else
                                If oArticulos.Existe = True Then
                                    Me.Grid1.Cell(Renglon, Me.iGyDescripcion).Text = oArticulos.DESCRIPCION
                                    Me.Grid1.Cell(Renglon, Me.iGyCantidad).Text = "0"
                                    Me.Grid1.Cell(Renglon, Me.iGyUnidad).Text = oArticulos.UNIDAD_VENTA

                                    Me.Grid1.Column(Me.iGyDescripcion).Locked = True
                                    Me.Grid1.Column(Me.iGyUnidad).Locked = True
                                End If
                            End If

                        Case Me.iGyCantidad
                            If dCantidad <= 0 Then
                                MsgBox("La cantidad debe de ser mayor a 0.", MsgBoxStyle.Exclamation, Me.Text)
                                Me.Grid1.Cell(Renglon, Me.iGyCantidad).SetFocus()
                                Exit Sub
                            End If

                            Me.Grid1.Rows = Me.Grid1.Rows + 1
                            Me.Grid1.Cell(Renglon + 1, Me.iGyIdFormulaDetalle).SetFocus()

                    End Select

                Case Keys.F2
                    Me.Grid1.Cell(Renglon, Me.iGyCodigoArticulo).Text = Empresa_Sistema.CODIGO_ARTICULO_NO_INVENTARIABLE_COMPRA_PROVEEDOR

                Case Keys.F6, Keys.F7

                    Select Case Columna
                        Case Me.iGyCodigoArticulo
                            If e.KeyCode = Keys.F6 Then
BuscaArticulos:
                                oArticulos = New Class_CatArticulos
                                StrCod = oArticulos.BusquedaVisualInventariables_PorDescripcion()
                                If txtLEN(StrCod) = True Then
                                    If StrCod = Me.TxtCodigoArticulo.Text Then
                                        MsgBox("Los ingredientes deben ser distintos al producto final.", MsgBoxStyle.Exclamation, Me.Text)
                                        GoTo BuscaArticulos
                                    End If

                                    For i = 1 To Me.Grid1.Rows - 1
                                        If Me.Grid1.Cell(i, Me.iGyCodigoArticulo).Text = StrCod And i <> Renglon Then
                                            MsgBox("Ya existe ese ingrediente en el renglón " & i, MsgBoxStyle.Exclamation, Me.Text)
                                            Exit Sub
                                        End If
                                    Next

                                    Me.Grid1.Cell(Renglon, Me.iGyCodigoArticulo).Text = StrCod
                                    GoTo LlenaLinea
                                End If
                            End If

                    End Select

                Case Keys.F8, Keys.Delete
                    If (Me.Estado = enumEstados.NUEVO Or Me.Estado = enumEstados.EDICION) Then
                        If Me.Estado = enumEstados.EDICION Then
                            Dim oFormulaDetalle As New Class_CatFormulas_Detalle

                            If oFormulaDetalle.EliminaIngrediente(CInt(Me.Grid1.Cell(Renglon, Me.iGyIdFormulaDetalle).Text)) = False Then
                                MsgBox("Error al tratar de eliminar el ingrediente.", MsgBoxStyle.Exclamation, Me.Text)
                                Exit Sub
                            End If

                        End If

                        Me.Grid1.Selection.DeleteByRow()
                    End If

            End Select

        Catch ex As Exception
            HandleError(Me.Name, "GestionaGrid", ex)
        End Try
    End Sub

    Private Function ValidarArticulo(ByVal iCodigo As String) As Boolean
        Dim bResultado As Boolean = False

        Dim sql As New Class_find("SELECT 1 FROM CAT_FORMULAS WHERE CODIGO_ARTICULO = '" & iCodigo & "'")

        If txtLEN(sql.Result1.ToString) = True Then
            MsgBox("Ya existe una fórmula para ese producto.", MsgBoxStyle.Exclamation, Me.Text)
            Me.TxtCodigoArticulo.Focus()
            Return bResultado
        End If

        bResultado = True
        Return bResultado

    End Function

#End Region

#Region "Eventos de objetos"
#Region "Eventos de la lista de elementos"
    Private Sub Grid_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grid.CellClick
        Me.LlenaElemento(Me.Grid.CurrentRow.Cells("CODIGO_FORMULA").Value.ToString)
        Me.tsbEditar.Enabled = True
    End Sub

    Private Sub Grid_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grid.CellDoubleClick
        Me.Estado = enumEstados.EDICION
        Me.Cambia_Estado()
    End Sub
#End Region

#Region "Eventos de TxtFiltro"
    Private Sub txtFiltro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFiltro.TextChanged
        Me.Grid.DataSource = Nothing
        Me.DesplegarElementos()
    End Sub

    Private Sub txtFiltro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFiltro.KeyPress
        txtNoBeep(e)
        txtNoComilla(e)
    End Sub

    Private Sub txtFiltro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFiltro.KeyDown
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Return Or e.KeyCode = Keys.Back Then
            Me.Grid.DataSource = Nothing
            Me.DesplegarElementos()
        End If
    End Sub

    Private Sub cboEstatusFiltro_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEstatusFiltro.SelectedIndexChanged
        Me.Grid.DataSource = Nothing
        Me.DesplegarElementos()
    End Sub
#End Region

#Region "Eventos Genericos"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNombreFormula.KeyPress, CboEstatus.KeyPress, TxtCodigoArticulo.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub txt_Keydown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNombreFormula.KeyDown, CboEstatus.KeyDown
        If e.KeyCode = Keys.Return Then
            txtTAB(e)
        End If
    End Sub

    Private Sub txtNumerosEnterosKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigoFormula.KeyPress
        txtSoloNumerosEnteros(e)
        txtNoBeep(e)
    End Sub

    Private Sub txtCantidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCostoProduccion.KeyPress
        Dim txt As TextBox = CType(sender, TextBox)
        txtSoloNumerosDecimales(e, txt.Text)
        txtNoBeep(e)
    End Sub
#End Region

#Region "Keydown específicos"
    Private Sub txtCodigoArticulo_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCodigoArticulo.KeyDown
        Dim sText As String
        Dim oArticulo As New Class_CatArticulos

        Select e.KeyCode
            Case Keys.F6
Buscar:
                sText = oArticulo.BusquedaVisual_PorDescripcion
                If txtLEN(sText) = True Then
                    If Me.ValidarArticulo(sText) = False Then
                        GoTo Buscar
                    End If

                    Me.TxtCodigoArticulo.Text = sText
                End If

            Case Keys.Enter

                If txtLEN(Me.TxtCodigoArticulo.Text) = True Then
                    oArticulo = New Class_CatArticulos(Me.TxtCodigoArticulo.Text)
                    If oArticulo.Existe = False Then
                        Me.LblNombreProductoFinal.Text = "" : GoTo Buscar : Exit Sub
                    End If

                    If Me.ValidarArticulo(Me.TxtCodigoArticulo.Text) = False Then
                        Me.LblNombreProductoFinal.Text = "" : GoTo Buscar : Exit Sub
                    End If

                    Me.LblNombreProductoFinal.Text = oArticulo.DESCRIPCION
                End If

                Me.Grid1.Cell(1, Me.iGyCodigoArticulo).SetFocus()

        End Select
    End Sub

    Private Sub Grid1_KeyDown(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Grid1.KeyDown
        Me.GestionaGrid(e)
    End Sub
#End Region

#Region "Validating específicos"

#End Region

#End Region

End Class