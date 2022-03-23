Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class Catalogo_Vehiculos
    Private oVehiculo As New Class_CatVehiculos

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
            Me.msgElemento = "Vehiculo"
            Me.msgElementos = "Vehiculos"
            Me.Run = False
            'Me.lstbElementos.ContextMenuStrip = Me.cMenuStripAccion
            Estado = enumEstados.CONSULTA
            Me.Cambia_Estado()
            Me.DesplegarElementos()
            Me.CboEstatusFiltro.SelectedIndex = 0
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
            Exit Sub
        End If

        Dim sMsg As String = ""
        Select Case Me.Estado
            Case enumEstados.EDICION
                sMsg = "grabar las modificaciones del "
            Case enumEstados.NUEVO
                sMsg = "agregar el "
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
        Me.oVehiculo.Imprimir_Listado()
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
                    Me.TxtCodigoCategoria.Enabled = True

                    Me.InicializaElemento()

                    Me.chkCrearCategoria.Visible = True : Me.chkCrearCategoria.Checked = False : Me.chkCrearCategoria.Checked = True 'esta como false y true para forzar a que hay cambio y se ejecute el evento del check

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
                    Me.TxtCodigoCategoria.Enabled = True

                    Me.chkCrearCategoria.Visible = False : Me.chkCrearCategoria.Checked = True : Me.chkCrearCategoria.Checked = False

                    Me.TxtNombre.Focus()

                Case enumEstados.CONSULTA
                    Me.gBoxInformacion.Enabled = False
                    Me.gBoxBusquedaRapida.Enabled = True
                    Me.tssLabelEstado.Text = "Consultando"
                    Me.tsbNuevo.Enabled = True
                    Me.tsbEditar.Enabled = False
                    Me.tsbGrabar.Enabled = False
                    Me.tsbCancelar.Enabled = False

                    Me.chkCrearCategoria.Visible = False : Me.chkCrearCategoria.Checked = True : Me.chkCrearCategoria.Checked = False

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
        Me.CboEstatus.SelectedIndex = 0
        Me.TxtCodigoCategoria.Text = ""
        Me.lblCategoria.Text = ""
        Me.txtTipoCategoria.Text = ""
        Me.lblTipoCategoria.Text = ""
        Me.chkCrearCategoria.Checked = False
    End Sub

    Private Sub DesplegarElementos()
        Try
            With Me.Grid
                .DataSource = oVehiculo.ObtenerElementosFiltro(Me.txtFiltro.Text, Me.CboEstatusFiltro.Text)
                .Columns("CODIGO_VEHICULO").Width = 30
                .Columns("NOMBRE_VEHICULO").Width = 200
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarElementos", ex)
        End Try
    End Sub

    Private Sub LlenaElemento(ByVal sCodigo_Elemento As String)
        Try
            Me.oVehiculo.Codigo_Vehiculo = sCodigo_Elemento
            If Me.oVehiculo.Consultar Then
                With Me.oVehiculo
                    Me.TxtCodigo.Text = .Codigo_Vehiculo.ToString
                    Me.TxtNombre.Text = .Nombre_Vehiculo.ToString
                    Me.TxtCodigoCategoria.Text = .Codigo_Categoria
                    Dim sql As New Class_find("SELECT NOMBRE_CATEGORIA FROM CAT_CATEGORIAS WHERE CODIGO_CATEGORIA='" & Me.TxtCodigoCategoria.Text & "' ")
                    If sql.Result1 = "" Then
                    Else
                        Me.lblCategoria.Text = sql.Result1
                    End If

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
                    With Me.oVehiculo
                        .CODIGO_VEHICULO = valorNumerico(Me.TxtCodigo.Text).ToString
                        .Nombre_Vehiculo = Me.TxtNombre.Text
                        .Estatus = Strings.Left(Me.CboEstatus.Text, 1)
                        .CODIGO_CATEGORIA = Me.TxtCodigoCategoria.Text

                        Select Case Me.Estado
                            Case enumEstados.NUEVO
                                .GENERAR_CATEGORIA = Me.chkCrearCategoria.Checked
                                .CODIGO_TIPO_CATEGORIA = Me.txtTipoCategoria.Text
                                If .Grabar("INSERTAR") = True Then
                                    Grabado = True
                                    Me.Estado = enumEstados.NUEVO
                                End If
                            Case enumEstados.EDICION
                                .GENERAR_CATEGORIA = False
                                .CODIGO_TIPO_CATEGORIA = ""
                                If .Grabar("ACTUALIZAR") = True Then
                                    Grabado = True
                                End If
                        End Select

                        Me.Estado = enumEstados.CONSULTA
                        If Grabado = True Then
                            MsgBox(Me.msgElemento & " grabado satisfactoriamente.", MsgBoxStyle.Information, Me.Name)
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
                MsgBox("Capture el nombre del vehículo.", MsgBoxStyle.Exclamation, Me.Text)
                Me.TxtNombre.Focus()
                Return bResultado
            End If

            Select Case Me.chkCrearCategoria.Checked
                Case False
                    If txtLEN(Me.TxtCodigoCategoria.Text) = False Then
                        MsgBox("Seleccione una categoria, en caso de no tener, puede usar la 0.", MsgBoxStyle.Exclamation, Me.Text)
                        Me.TxtCodigoCategoria.Focus()
                        Return False
                    End If
                Case True
                    If txtLEN(Me.txtTipoCategoria.Text) = False Then
                        MsgBox("Seleccione el tipo de categoria.", MsgBoxStyle.Exclamation, Me.Text)
                        Me.txtTipoCategoria.Focus()
                        Return False
                    End If
            End Select

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
        Me.LlenaElemento(Me.Grid.CurrentRow.Cells("CODIGO_VEHICULO").Value.ToString)
    End Sub

    Private Sub Grid_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grid.CellDoubleClick
        Me.Estado = enumEstados.EDICION
        Me.Cambia_Estado()
    End Sub
#End Region

#Region "Eventos de TxtFiltro y cboEstatusFiltro"
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

    Private Sub cboEstatusFiltro_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboEstatusFiltro.SelectedIndexChanged
        Me.Grid.DataSource = Nothing
        Me.DesplegarElementos()
    End Sub

#End Region

#Region "Eventos Genericos"
    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNombre.KeyPress, TxtCodigoCategoria.KeyPress, TxtCodigo.KeyPress, txtTipoCategoria.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub txt_Keydown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNombre.KeyDown, CboEstatus.KeyDown, chkCrearCategoria.KeyDown
        If e.KeyCode = Keys.Return Then
            txtTAB(e)
        End If
    End Sub

    Private Sub txtNumerosEnterosKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigoCategoria.KeyPress, txtTipoCategoria.KeyPress
        txtSoloNumerosEnteros(e)
        txtNoBeep(e)
    End Sub
#End Region

#Region "Keydown específicos"

    Private Sub txtCodigoCategoria_keyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodigoCategoria.KeyDown
        Try
            Dim oCategorias As New Class_CatCategorias

            Select Case e.KeyCode
                Case Keys.F6
Buscar:
                    Dim resultado As String
                    resultado = oCategorias.BusquedaVisual_PorDescripcion()
                    Me.TxtCodigoCategoria.Text = resultado
                    If txtLEN(resultado) = True Then
                        GoTo Enter : Exit Sub
                    Else
                        Me.lblCategoria.Text = "_"
                    End If

                Case Keys.Return
Enter:
                    If txtLEN(Me.TxtCodigoCategoria.Text) = False Then
                        Me.lblCategoria.Text = "_" ': GoTo Buscar : Exit Sub
                        txtTAB(e)
                        Return
                    End If

                    oCategorias = New Class_CatCategorias(Me.TxtCodigoCategoria.Text)
                    If oCategorias.Existe = True Then
                        Me.lblCategoria.Text = oCategorias.NOMBRE_CATEGORIA
                    Else
                        Me.lblCategoria.Text = "_" : GoTo Buscar : Exit Sub
                    End If

                    If Me.chkCrearCategoria.Visible = True Then
                        Me.chkCrearCategoria.Focus()
                    Else
                        tsbGrabar.PerformClick()
                    End If
            End Select
        Catch ex As Exception
            HandleError(Me.Name, "txtCodigoCategoria_keyDown", ex)
        End Try
    End Sub

    Private Sub txtTipoCategoria_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTipoCategoria.KeyDown
        Try
            Dim oTiposCategorias As New Class_CatTiposCategorias

            Select Case e.KeyCode
                Case Keys.F6
Buscar:
                    Dim resultado As String
                    resultado = oTiposCategorias.BusquedaVisual_PorDescripcion()
                    Me.txtTipoCategoria.Text = resultado
                    If txtLEN(resultado) = True Then
                        GoTo Enter : Exit Sub
                    End If

                Case Keys.Return
Enter:
                    If txtLEN(Me.txtTipoCategoria.Text) = False Then
                        Me.lblTipoCategoria.Text = "" : GoTo Buscar : Exit Sub
                    End If

                    oTiposCategorias = New Class_CatTiposCategorias(Me.txtTipoCategoria.Text)
                    If oTiposCategorias.Existe = True Then
                        Me.lblTipoCategoria.Text = oTiposCategorias.Nombre_Tipo_Categoria
                        tsbGrabar.PerformClick()
                    Else
                        Me.lblTipoCategoria.Text = "" : GoTo Buscar : Exit Sub
                    End If

                    tsbGrabar.PerformClick()

            End Select
        Catch ex As Exception
            HandleError(Me.Name, "txtTipoCategoria_KeyDown", ex)
        End Try
    End Sub
#End Region

#Region "Validating específicos"

#End Region

    Private Sub CboFiltroHoja_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Refrescar()
    End Sub

    Private Sub chkCrearCategoria_CheckedChanged(sender As Object, e As EventArgs) Handles chkCrearCategoria.CheckedChanged
        If Me.chkCrearCategoria.Checked = True AndAlso Me.Estado = enumEstados.NUEVO Then
            Me.txtTipoCategoria.Visible = True : Me.lblDisplayTipoCategoria.Visible = True : Me.lblTipoCategoria.Visible = True
            Me.TxtCodigoCategoria.Visible = False : Me.lblCodigoCategoria.Visible = False : Me.lblCodigoCategoria.Visible = False
        Else
            Me.txtTipoCategoria.Visible = False : Me.lblDisplayTipoCategoria.Visible = False : Me.lblTipoCategoria.Visible = False
            Me.TxtCodigoCategoria.Visible = True : Me.lblCodigoCategoria.Visible = True : Me.lblCodigoCategoria.Visible = True
        End If
    End Sub

#End Region

End Class