Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class Catalogo_Relacion_Parametros_Acuicola_Documentos
    Private oRelacion As New Class_CatRelParametrosAcuicolaDocumentos

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
    Private iGyPosicion As Integer = 1
    Private iGyCodigoParametro As Integer = 2
    Private iGyNombreParametro As Integer = 3
    Private iGyBorrar As Integer = 4
    Private iGyNuevo As Integer = 5
#End Region

#Region "Constructor y destructor"
    'Inicializa al objeto.
    Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

        Try
            Me.msgElemento = "Relación"
            Me.msgElementos = "Relaciones"
            Me.Run = False
            Estado = enumEstados.CONSULTA
            Me.Cambia_Estado()
            Me.InicializaElemento()
            Me.DesplegarElementos()
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
        sMsg = "Deseas " & sMsg & Me.msgElemento & " del documento " & Me.lblNombreTipoDocumento.Text & " ?"
        If MsgBox(sMsg, CType(CInt(MsgBoxStyle.Question) + CInt(MsgBoxStyle.YesNo), MsgBoxStyle), Me.Text) = MsgBoxResult.Yes Then
            Me.Grabar()
        End If
    End Sub

    Private Sub tsbCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCancelar.Click
        Me.Estado = enumEstados.CONSULTA
        Me.Cambia_Estado()
        Me.Refrescar()
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub

    Private Sub tsbImprimirListado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimirListado.Click
        'Me.oConcepto.Imprimir_Listado()
    End Sub
#End Region

#Region "Métodos y procedimientos"
    Private Sub Refrescar()
        'Me.DesplegarElementos()
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
                    Me.Grid1.Locked = False

                    Me.TxtCodigoTipoDocumento.Enabled = True

                    Me.InicializaElemento()
                    Me.TxtCodigoTipoDocumento.Focus()

                Case enumEstados.EDICION
                    Me.gBoxInformacion.Enabled = True
                    Me.gBoxBusquedaRapida.Enabled = False
                    Me.tssLabelEstado.Text = "Editando"
                    Me.tsbNuevo.Enabled = False
                    Me.tsbEditar.Enabled = False
                    Me.tsbGrabar.Enabled = True
                    Me.tsbCancelar.Enabled = True

                    Me.TxtCodigoTipoDocumento.Enabled = False
                    Me.TxtCodigoTipoDocumento.Focus()

                    Me.Grid1.Locked = False
                    Me.Grid1.Rows = Me.Grid1.Rows + 1

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
        Me.TxtCodigoTipoDocumento.Text = ""

        Me.InicializaGrid()
    End Sub

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

            .Cell(0, Me.iGyPosicion).Text = "Posición"
            .Cell(0, Me.iGyCodigoParametro).Text = "Código articulo"
            .Cell(0, Me.iGyNombreParametro).Text = "Nombre parametro"
            .Cell(0, Me.iGyBorrar).Text = "Borrar"
            .Cell(0, Me.iGyNuevo).Text = "Nuevo"

            .Column(Me.iGyPosicion).Mask = FlexCell.MaskEnum.DefaultMask
            .Column(Me.iGyPosicion).DecimalLength = 0 'Empresa_Sistema.DECIMALES_CANTIDAD
            .Column(Me.iGyPosicion).Alignment = FlexCell.AlignmentEnum.RightCenter

            .Column(Me.iGyPosicion).Locked = True
            .Column(Me.iGyNombreParametro).Locked = True

            .Column(Me.iGyPosicion).Width = 30
            .Column(Me.iGyCodigoParametro).Width = 30
            .Column(Me.iGyNombreParametro).Width = 250
            .Column(Me.iGyBorrar).Width = 10
            .Column(Me.iGyNuevo).Width = 10

            .Column(Me.iGyBorrar).Visible = False
            .Column(Me.iGyNuevo).Visible = False

            .Column(Me.iGyCodigoParametro).Locked = False

            .AutoRedraw = True
            .Refresh()
        End With
    End Sub

    Private Sub GestionaGrid(ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            Dim Columna As Integer, Renglon As Integer
            Dim StrCod As String ', dCantidad As Double
            Dim oParametros As Class_CatParametrosAcuicola
            Dim i As Integer

            Columna = Me.Grid1.Selection.FirstCol
            Renglon = Me.Grid1.Selection.FirstRow
            StrCod = Me.Grid1.Cell(Renglon, Me.iGyCodigoParametro).Text
            'dCantidad = valorNumerico(Me.Grid1.Cell(Renglon, Me.i).Text)

            Select Case e.KeyCode
                Case Keys.Enter

                    Select Case Columna
                        Case Me.iGyCodigoParametro
                            If txtLEN(StrCod) = False Then
                                GoTo BuscaParametros
                            End If
LlenaLinea:
                            oParametros = New Class_CatParametrosAcuicola(StrCod)
                            If oParametros.Existe = False Then
                                GoTo BuscaParametros
                            End If

                            For i = 1 To Me.Grid1.Rows - 1
                                If Me.Grid1.Cell(i, Me.iGyCodigoParametro).Text = StrCod And i <> Renglon And Me.Grid1.Cell(i, Me.iGyBorrar).Text = "0" Then
                                    MsgBox("Ya existe ese parametro en el renglón " & i, MsgBoxStyle.Exclamation, Me.Text)
                                    Exit Sub
                                End If
                            Next

                            If oParametros.Existe = True Then
                                Me.Grid1.Cell(Renglon, Me.iGyNombreParametro).Text = oParametros.Nombre_Parametro

                                Dim sql As New Class_find("SELECT ISNULL(MAX(POSICION),0) + 1 FROM CAT_REL_PARAMETROS_ACUICOLA_DOCUMENTOS")

                                If txtLEN(sql.Result1) = True Then
                                    Me.Grid1.Cell(Renglon, Me.iGyPosicion).Text = sql.Result1
                                End If

                                Me.Grid1.Column(Me.iGyNombreParametro).Locked = True
                                Me.Grid1.Column(Me.iGyPosicion).Locked = True

                            End If

                            Me.Grid1.Cell(Renglon, iGyBorrar).Text = "0"
                            Me.Grid1.Cell(Renglon, iGyNuevo).Text = "1"

                    End Select

                Case Keys.F6, Keys.F7

                    Select Case Columna
                        Case Me.iGyCodigoParametro
                            If e.KeyCode = Keys.F6 Then
BuscaParametros:
                                oParametros = New Class_CatParametrosAcuicola
                                StrCod = oParametros.BusquedaVisual_PorDescripcion
                                If txtLEN(StrCod) = True Then

                                    For i = 1 To Me.Grid1.Rows - 1
                                        If Me.Grid1.Cell(i, Me.iGyCodigoParametro).Text = StrCod And i <> Renglon And Me.Grid1.Cell(i, Me.iGyBorrar).Text = "0" Then
                                            MsgBox("Ya existe ese parametro en el renglón " & i, MsgBoxStyle.Exclamation, Me.Text)
                                            Exit Sub
                                        End If
                                    Next

                                    Me.Grid1.Cell(Renglon, Me.iGyCodigoParametro).Text = StrCod
                                    GoTo LlenaLinea
                                End If
                            End If

                    End Select

                Case Keys.F8, Keys.Delete
                    If Me.Estado = enumEstados.EDICION Then
                        If txtLEN(Me.Grid1.Cell(Renglon, Me.iGyCodigoParametro).Text) Then
                            Me.Grid1.Cell(Renglon, Me.iGyBorrar).Text = "1" 'El renglon queda pendiente para eliminarse al grabar
                            Me.Grid1.Cell(Renglon, iGyNuevo).Text = "0"
                            Me.Grid1.Row(Renglon).Visible = False
                        End If

                    ElseIf Me.Estado = enumEstados.NUEVO Then
                        Me.Grid1.Selection.DeleteByRow()
                        If Me.Grid1.Rows = 1 Then Me.Grid1.Rows = 2
                    End If

            End Select

        Catch ex As Exception
            HandleError(Me.Name, "GestionaGrid", ex)
        End Try
    End Sub

    Private Sub DesplegarElementos()
        Try
            With Me.Grid
                .DataSource = oRelacion.ObtenerElementosFiltro("%")
                .Columns("CODIGO_TIPO_DOCUMENTO").Width = 50
                .Columns("NOMBRE_TIPO_DOCUMENTO").Width = 200
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarElementos", ex)
        End Try
    End Sub

    Private Sub LlenaElemento(ByVal sCodigo_Elemento As String)
        Try
            Me.TxtCodigoTipoDocumento.Text = sCodigo_Elemento

            Dim sql As New Class_find("SELECT NOMBRE_TIPO_DOCUMENTO FROM SIS_TIPOS_DOCUMENTOS WHERE CODIGO_TIPO_DOCUMENTO='" & Me.TxtCodigoTipoDocumento.Text & "'")

            If txtLEN(sql.Result1) = True Then
                Me.lblNombreTipoDocumento.Text = sql.Result1
            End If

            Dim dTabla As DataTable = oRelacion.ObtenerDetalle(Me.TxtCodigoTipoDocumento.Text)
            Me.Grid1.AutoRedraw = False
            Me.Grid1.Rows = 1 'Trae dos porque en docs nuevos se pone un row en blanco, y si se dejan aqui dos agrega a partir del 3 y queda un hueco
            For Each dRow As DataRow In dTabla.Rows
                Me.Grid1.AddItem(dRow("POSICION").ToString & Chr(9) & dRow("CODIGO_PARAMETRO").ToString & Chr(9) & dRow("NOMBRE_PARAMETRO").ToString & Chr(9) & "0" & Chr(9) & "0" & Chr(9)) '0 es para la columna Borrar y Nuevo
            Next

            If Me.Grid1.Rows = 1 Then Me.Grid1.Rows = 2

            Me.FormateaGrid()
        Catch ex As Exception
            HandleError(Me.Name, "LlenaElemento", ex)
        End Try
    End Sub

    Private Sub Grabar()
        Dim Grabado As Boolean = False
        Select Case Me.Estado
            Case enumEstados.NUEVO, enumEstados.EDICION
                Try
                    'With Me.oRelacion
                    '    .Codigo_Tipo_Documento = Me.TxtCodigoTipoDocumento.Text

                    For i = 1 To Me.Grid1.Rows - 1
                        If txtLEN(Me.Grid1.Cell(i, Me.iGyCodigoParametro).Text) = True Then
                            oRelacion = New Class_CatRelParametrosAcuicolaDocumentos

                            With oRelacion
                                .Codigo_Tipo_Documento = Me.TxtCodigoTipoDocumento.Text
                                .Codigo_Parametro = Me.Grid1.Cell(i, Me.iGyCodigoParametro).Text
                                .Posicion = CInt(Me.Grid1.Cell(i, Me.iGyPosicion).Text)

                                Select Case Me.Estado
                                    Case enumEstados.NUEVO
                                        If .Insertar() = False Then
                                            MsgBox("Error al tratar de insertar la relación.", MsgBoxStyle.Exclamation, Me.Text)
                                            Exit Sub
                                        End If

                                    Case enumEstados.EDICION
                                        If txtLEN(Me.Grid1.Cell(i, Me.iGyCodigoParametro).Text) = True And Me.Grid1.Cell(i, iGyNuevo).Text = "0" And Me.Grid1.Cell(i, Me.iGyBorrar).Text = "1" Then
                                            If .Eliminar() = False Then
                                                MsgBox("Error al tratar de eliminar la relación.", MsgBoxStyle.Exclamation, Me.Text)
                                                Exit Sub
                                            End If
                                        ElseIf txtLEN(Me.Grid1.Cell(i, Me.iGyCodigoParametro).Text) = True And Me.Grid1.Cell(i, iGyNuevo).Text = "0" And Me.Grid1.Cell(i, Me.iGyBorrar).Text = "0" Then
                                            If .Actualizar() = False Then
                                                MsgBox("Error al tratar de actualizar la relación.", MsgBoxStyle.Exclamation, Me.Text)
                                                Exit Sub
                                            End If
                                        ElseIf Me.Grid1.Cell(i, iGyNuevo).Text = "1" Then
                                            If .Insertar() = False Then
                                                MsgBox("Error al tratar de insertar la relación.", MsgBoxStyle.Exclamation, Me.Text)
                                                Exit Sub
                                            End If
                                        End If

                                End Select
                            End With
                        End If
                    Next

                    Grabado = True

                    If Grabado = True Then
                        MsgBox(Me.msgElemento & " grabado satisfactoriamente.", MsgBoxStyle.Information, Me.Text)
                        Me.Refrescar()
                        Me.Estado = enumEstados.CONSULTA
                        Me.Cambia_Estado()
                    End If

                    'End With
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
            If txtLEN(Me.TxtCodigoTipoDocumento.Text) = False Then
                MsgBox("Captúre un código de documento.", MsgBoxStyle.Exclamation, Me.Text)
                Me.TxtCodigoTipoDocumento.Focus()
                Return False
            End If

            bResultado = True
        Catch ex As Exception
            HandleError(Me.Name, "Validar", ex)
        End Try

        Return bResultado
    End Function

#End Region

#Region "Eventos de objetos"
#Region "Eventos de la lista de elementos"

    Private Sub Grid_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grid.CellClick
        Me.LlenaElemento(Me.Grid.CurrentRow.Cells("CODIGO_TIPO_DOCUMENTO").Value.ToString)
    End Sub

    Private Sub Grid_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grid.CellDoubleClick
        Me.Estado = enumEstados.EDICION
        Me.Cambia_Estado()
    End Sub
#End Region

#Region " Eventos de TxtFiltro"
    Private Sub txtFiltro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFiltro.TextChanged
        Dim oElementos As New Class_CatRelParametrosAcuicolaDocumentos
        Me.Grid.DataSource = Nothing

        With Me.Grid
            .DataSource = oElementos.ObtenerElementosFiltro(Me.txtFiltro.Text)
            .Columns("CODIGO_TIPO_DOCUMENTO").Width = 50
            .Columns("NOMBRE_TIPO_DOCUMENTO").Width = 200
        End With
    End Sub

    Private Sub txtFiltro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFiltro.KeyPress
        txtNoBeep(e)
        txtNoComilla(e)
    End Sub

    Private Sub txtFiltro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFiltro.KeyDown
        Dim oElementosFiltro As New Class_CatRelParametrosAcuicolaDocumentos
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Return Or e.KeyCode = Keys.Back Then
            Me.Grid.DataSource = Nothing

            With Me.Grid
                .DataSource = oElementosFiltro.ObtenerElementosFiltro(Me.txtFiltro.Text)
                .Columns("CODIGO_TIPO_DOCUMENTO").Width = 50
                .Columns("NOMBRE_TIPO_DOCUMENTO").Width = 200
            End With
        End If
    End Sub
#End Region

#Region "Eventos Genericos"
    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        txtNoBeep(e)
    End Sub

    Private Sub txt_Keydown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Return Then
            txtTAB(e)
        End If
    End Sub

    Private Sub txtNumerosEnterosKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigoTipoDocumento.KeyPress
        txtSoloNumerosEnteros(e)
        txtNoBeep(e)
    End Sub

#End Region

#Region "Keydown específicos"
    Private Sub CboEstatus_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Return Then
            tsbGrabar.PerformClick()
        End If
    End Sub

    Private Sub Grid1_KeyDown(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Grid1.KeyDown
        Me.GestionaGrid(e)
    End Sub

    Private Sub TxtCodigoTipoDocumento_KeyDown(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodigoTipoDocumento.KeyDown
        Dim sText As String
        'oRelacion = New Class_CatRelParametrosAcuicolaDocumentos

        Select Case e.KeyCode
            Case Keys.F6
Buscar:
                sText = oRelacion.BusquedaVisual_Docs_Acuicola_PorDescripcion
                If txtLEN(sText) = True Then
                    Me.TxtCodigoTipoDocumento.Text = sText
                End If

            Case Keys.Enter

                If txtLEN(Me.TxtCodigoTipoDocumento.Text) = True Then
                    Dim sql As New Class_find("SELECT CODIGO_TIPO_DOCUMENTO,NOMBRE_TIPO_DOCUMENTO FROM SIS_TIPOS_DOCUMENTOS WHERE CODIGO_MODULO = 'ACU' AND CODIGO_TIPO_DOCUMENTO='" & Me.TxtCodigoTipoDocumento.Text & "'")
                    If txtLEN(sql.Result1) = True Then
                        Me.TxtCodigoTipoDocumento.Text = sql.Result1
                        Me.lblNombreTipoDocumento.Text = sql.Result2
                    End If

                End If

                Me.Grid1.Cell(1, Me.iGyCodigoParametro).SetFocus()

        End Select
    End Sub
#End Region

#Region "Validating específicos"

#End Region

    Private Sub CboFiltroHoja_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Refrescar()
    End Sub

#End Region

End Class