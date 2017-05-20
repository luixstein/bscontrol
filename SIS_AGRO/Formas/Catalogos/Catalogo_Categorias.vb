Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class Catalogo_Categorias
    Private oCategoria As New Class_CatCategorias

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

#Region "Constructor y destructor"
    'Inicializa al objeto.
    Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

        Try
            Me.msgElemento = "Categoria"
            Me.msgElementos = "Categorias"
            Me.Run = False
            'Me.lstbElementos.ContextMenuStrip = Me.cMenuStripAccion
            Estado = enumEstados.CONSULTA
            Me.Cambia_Estado()
            Me.DesplegarElementos()
            Me.DesplegarTiposCategorias()
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
        Me.TxtCodigo.Text = Me.oCategoria.CodigoSiguiente
        Me.CboEstatus.Enabled = True
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
                sMsg = " grabar las modificaciones de la "
            Case enumEstados.NUEVO
                sMsg = " agregar la "
            Case Else
                MsgBox("Me.Estado no válido.", MsgBoxStyle.Exclamation, Me.Text)
                Return
        End Select
        sMsg = "Deseas " & sMsg & Me.msgElemento & " : " & Me.TxtNombre.Text & " ?"
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
        Me.oCategoria.Imprimir_Listado()
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

                    Me.TxtCodigo.Enabled = False
                    Me.TxtNombre.Enabled = True
                    Me.CboEstatus.Enabled = False

                    Me.InicializaElemento()
                    Me.TxtNombre.Focus()

                Case enumEstados.EDICION
                    Me.gBoxInformacion.Enabled = True
                    Me.gBoxBusquedaRapida.Enabled = False
                    Me.tssLabelEstado.Text = "Editando"
                    Me.tsbNuevo.Enabled = False
                    Me.tsbEditar.Enabled = False
                    Me.tsbGrabar.Enabled = True
                    Me.tsbCancelar.Enabled = True

                    Me.TxtCodigo.Enabled = False
                    Me.TxtNombre.Enabled = True
                    Me.CboEstatus.Enabled = True
                    Me.TxtNombre.Focus()

                Case enumEstados.CONSULTA
                    Me.gBoxInformacion.Enabled = False
                    Me.gBoxBusquedaRapida.Enabled = True
                    Me.tssLabelEstado.Text = "Consultando"
                    Me.tsbNuevo.Enabled = True
                    Me.tsbEditar.Enabled = False
                    Me.tsbGrabar.Enabled = False
                    Me.tsbCancelar.Enabled = False
                    Me.txtFiltro.Focus()
            End Select
            Application.DoEvents()
        Catch ex As Exception
            HandleError(Me.Name, "Cambia_Estado", ex)
        End Try
    End Sub

    Private Sub InicializaElemento()
        Me.TxtCodigo.Text = ""
        Me.TxtNombre.Text = ""
        Me.CboTipoCategoria.SelectedIndex = -1
        Me.CboEstatus.SelectedIndex = 0
    End Sub

    Private Sub DesplegarElementos()
        Try
            With Me.Grid
                .DataSource = oCategoria.ObtenerElementosFiltro(Me.txtFiltro.Text, Me.cboEstatusFiltro.Text)
                .Columns("CODIGO_CATEGORIA").Width = 50
                .Columns("NOMBRE_CATEGORIA").Width = 250
                .Columns("NOMBRE_TIPO_CATEGORIA").Width = 250
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarElementos", ex)
        End Try
    End Sub

    Private Sub DesplegarTiposCategorias()
        Try
            Dim oElementos As New Class_CatTiposCategorias
            With Me.CboTipoCategoria
                .DisplayMember = "NOMBRE_TIPO_CATEGORIA"
                .ValueMember = "CODIGO_TIPO_CATEGORIA"
                Dim dView As New Data.DataView(oElementos.ObtenerElementos)
                dView.Sort = "NOMBRE_TIPO_CATEGORIA"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedIndex = 1
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarTiposCategorias", ex)
        End Try
    End Sub

    Private Sub LlenaElemento(ByVal sCodigo_Elemento As String)
        Try
            Me.oCategoria.Codigo_Categoria = sCodigo_Elemento
            If Me.oCategoria.Consultar Then
                With Me.oCategoria
                    Me.TxtCodigo.Text = .Codigo_Categoria.ToString
                    Me.TxtNombre.Text = .Nombre_Categoria.ToString
                    Me.CboTipoCategoria.SelectedValue = .Codigo_Tipo_Categoria
                    If .Estatus = "A" Then
                        Me.CboEstatus.SelectedIndex = 0
                    Else
                        Me.CboEstatus.SelectedIndex = 1
                    End If
                End With
            End If
        Catch ex As Exception
            HandleError(Me.Name, "LlenaElemento", ex)
        End Try
    End Sub

    Private Sub Grabar()
        Dim Grabado As Boolean = False
        Select Case Me.Estado
            Case enumEstados.NUEVO, enumEstados.EDICION
                Try
                    With Me.oCategoria
                        .CODIGO_CATEGORIA = Me.TxtCodigo.Text
                        .NOMBRE_CATEGORIA = Me.TxtNombre.Text
                        .CODIGO_TIPO_CATEGORIA = Me.CboTipoCategoria.SelectedValue.ToString
                        .Estatus = Strings.Left(Me.CboEstatus.Text, 1)

                        Select Case Me.Estado
                            Case enumEstados.NUEVO
                                If .Insertar() = True Then
                                    Grabado = True
                                    Me.Estado = enumEstados.NUEVO
                                End If
                            Case enumEstados.EDICION
                                If .Actualizar() = True Then
                                    Grabado = True
                                End If
                        End Select

                        Me.Estado = enumEstados.CONSULTA
                        If Grabado Then
                            MsgBox(Me.msgElemento & " Grabado satisfactoriamente.", MsgBoxStyle.Information, Me.Name)
                            Me.Refrescar()
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
            If txtLEN(Me.TxtNombre.Text) = False Then
                MsgBox("Capture el nombre de la categoría.", MsgBoxStyle.Exclamation, Me.Text)
                Me.TxtNombre.Focus()
                Return False
            End If

            If Me.CboTipoCategoria.SelectedIndex = -1 Then
                MsgBox("Seleccione el tipo de categoria.", MsgBoxStyle.Exclamation, Me.Text)
                Me.CboTipoCategoria.Focus()
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
        Me.LlenaElemento(Me.Grid.CurrentRow.Cells("CODIGO_CATEGORIA").Value.ToString)
    End Sub

    Private Sub Grid_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grid.CellDoubleClick
        Me.Estado = enumEstados.EDICION
        Me.Cambia_Estado()
    End Sub
#End Region

#Region " Eventos de TxtFiltro"
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
    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CboEstatus.KeyPress, TxtNombre.KeyPress, CboTipoCategoria.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub txt_Keydown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNombre.KeyDown
        If e.KeyCode = Keys.Return Then
            txtTAB(e)
        End If
    End Sub
#End Region

#Region "Keydown específicos"
    Private Sub CboTipoCategoria_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CboTipoCategoria.KeyDown
        If e.KeyCode = Keys.Return Then
            Select Case Me.Estado
                Case enumEstados.NUEVO
                    tsbGrabar.PerformClick()
                Case enumEstados.EDICION
                    txtTAB(e)
            End Select
        End If
    End Sub

    Private Sub CboEstatus_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CboEstatus.KeyDown
        If e.KeyCode = Keys.Return Then
            tsbGrabar.PerformClick()
        End If
    End Sub
#End Region

#Region "Validating específicos"

#End Region

    Private Sub CboFiltroHoja_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Refrescar()
    End Sub

#End Region

End Class