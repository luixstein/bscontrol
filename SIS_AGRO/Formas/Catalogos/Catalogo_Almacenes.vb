Option Strict On
Imports System.Data
Imports System.Data.SqlClient

Public Class Catalogo_Almacenes
    Private oCuenta As New Class_CatCuentas
    Private oAlmacenes As New Class_CatAlmacenes

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
            Me.msgElemento = "Almacen"
            Me.msgElementos = "Almacenes"
            Me.Run = False
            'Me.lstbElementos.ContextMenuStrip = Me.cMenuStripAccion
            Estado = enumEstados.CONSULTA
            Me.Cambia_Estado()
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

        'Me.TxtCodigoAlmacen.Text = Me.oAlmacenes.CodigoSiguiente
        Me.txtCuentaContable.Text = Empresa_Sistema.CUENTA_CONTABLE_ALMACENES & Me.TxtCodigoAlmacen.Text
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
        sMsg = "Deseas " & sMsg & Me.msgElemento & " : " & Me.TxtNombreAlmacen.Text & " ?"
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
        Me.oAlmacenes.Imprimir_Listado()
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
                    Me.tssLabelEstado.Text = "Agregando nuevo " & Me.msgElemento
                    Me.tsbNuevo.Enabled = False
                    Me.tsbEditar.Enabled = False
                    Me.tsbGrabar.Enabled = True
                    Me.tsbCancelar.Enabled = True

                    Me.TxtCodigoAlmacen.Enabled = False
                    Me.TxtNombreAlmacen.Enabled = True
                    Me.txtCodigoZona.Enabled = True
                    Me.TxtCodigoCategoria.Enabled = True
                    Me.CboEstatus.Enabled = False
                    Me.txtCuentaContable.Visible = False : Me.lblDisplayCuentaContable.Visible = False : Me.lblNombreCuenta.Visible = False

                    Me.InicializaElemento()

                    Me.chkCrearCategoria.Visible = True : Me.chkCrearCategoria.Checked = False : Me.chkCrearCategoria.Checked = True 'esta como false y true para forzar a que hay cambio y se ejecute el evento del check

                    Me.TxtCodigoAlmacen.Focus()

                Case enumEstados.EDICION
                    Me.gBoxInformacion.Enabled = True
                    Me.gBoxBusquedaRapida.Enabled = False
                    Me.tssLabelEstado.Text = "Edición"
                    Me.tsbNuevo.Enabled = False
                    Me.tsbEditar.Enabled = False
                    Me.tsbGrabar.Enabled = True
                    Me.tsbCancelar.Enabled = True

                    Me.TxtCodigoAlmacen.Enabled = False
                    Me.TxtNombreAlmacen.Enabled = True
                    Me.CboEstatus.Enabled = True
                    Me.TxtCodigoCategoria.Enabled = True
                    Me.txtCodigoZona.Enabled = True
                    Me.txtCuentaContable.Visible = True : Me.lblDisplayCuentaContable.Visible = True : Me.lblNombreCuenta.Visible = True

                    Me.chkCrearCategoria.Visible = False : Me.chkCrearCategoria.Checked = True : Me.chkCrearCategoria.Checked = False

                    Me.TxtNombreAlmacen.Focus()

                Case enumEstados.CONSULTA

                    Me.gBoxInformacion.Enabled = False
                    Me.gBoxBusquedaRapida.Enabled = True
                    Me.tssLabelEstado.Text = "Consulta"
                    Me.tsbNuevo.Enabled = True
                    Me.tsbEditar.Enabled = False
                    Me.tsbGrabar.Enabled = False
                    Me.tsbCancelar.Enabled = False

                    Me.txtCuentaContable.Visible = True : Me.lblDisplayCuentaContable.Visible = True : Me.lblNombreCuenta.Visible = True

                    Me.chkCrearCategoria.Visible = False : Me.chkCrearCategoria.Checked = True : Me.chkCrearCategoria.Checked = False

                    Me.txtFiltro.Focus()

            End Select
            Application.DoEvents()
        Catch ex As Exception
            HandleError(Me.Name, "Cambia_Estado", ex)
        End Try
    End Sub

    Private Sub InicializaElemento()
        Me.TxtCodigoAlmacen.Text = ""
        Me.TxtNombreAlmacen.Text = ""
        Me.txtCuentaContable.Text = ""
        Me.lblNombreCuenta.Text = ""
        Me.txtCodigoZona.Text = ""
        Me.lblNombreZona.Text = ""
        Me.TxtCodigoCategoria.Text = ""
        Me.LblNombreCategoria.Text = ""
        Me.CboEstatus.SelectedIndex = 0
        Me.txtTipoCategoria.Text = ""
        Me.lblTipoCategoria.Text = ""
        Me.chkCrearCategoria.Checked = False
    End Sub

    Private Sub DesplegarElementos()
        Try
            With Me.Grid
                .DataSource = oAlmacenes.ObtenerElementosFiltro(Me.txtFiltro.Text, Me.cboEstatusFiltro.Text)
                .Columns("CODIGO_ALMACEN").Width = 50
                .Columns("NOMBRE_ALMACEN").Width = 200
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarElementos", ex)
        End Try
    End Sub

    Private Sub LlenaElemento(ByVal iCodigo_Elemento As String)
        Try
            Me.oAlmacenes.CODIGO_ALMACEN = iCodigo_Elemento
            If Me.oAlmacenes.Consultar Then
                With Me.oAlmacenes
                    Me.TxtCodigoAlmacen.Text = .CODIGO_ALMACEN.ToString
                    Me.TxtNombreAlmacen.Text = .NOMBRE_ALMACEN.ToString
                    Me.txtCuentaContable.Text = .CUENTA_CONTABLE
                    Dim sql As New Class_find("Select NOMBRE_CUENTA From CON_CAT_CUENTAS Where CUENTA_CONTABLE='" & txtCuentaContable.Text & "' ")
                    If sql.Result1 = "" Then
                    Else
                        lblNombreCuenta.Text = sql.Result1
                    End If
                    sql = Nothing

                    Me.txtCodigoZona.Text = .CODIGO_ZONA
                    sql = New Class_find("Select NOMBRE_ZONA From CAT_ZONAS Where CODIGO_ZONA='" & txtCodigoZona.Text & "' ")
                    If sql.Result1 = "" Then
                    Else
                        lblNombreZona.Text = sql.Result1
                    End If
                    sql = Nothing

                    Me.TxtCodigoCategoria.Text = .CODIGO_CATEGORIA
                    sql = New Class_find("Select NOMBRE_CATEGORIA From CAT_CATEGORIAS Where CODIGO_CATEGORIA='" & TxtCodigoCategoria.Text & "' ")
                    If sql.Result1 = "" Then
                    Else
                        LblNombreCategoria.Text = sql.Result1
                    End If
                    sql = Nothing

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
                    With Me.oAlmacenes

                        .CODIGO_ALMACEN = Me.TxtCodigoAlmacen.Text
                        .NOMBRE_ALMACEN = Me.TxtNombreAlmacen.Text
                        '.Cuenta_Contable = Me.txtCuentaContable.Text
                        .Estatus = Strings.Left(Me.CboEstatus.Text, 1)
                        .CODIGO_ZONA = Me.txtCodigoZona.Text
                        .CODIGO_CATEGORIA = Me.TxtCodigoCategoria.Text

                        Select Case Me.Estado
                            Case enumEstados.NUEVO
                                Me.oAlmacenes = New Class_CatAlmacenes

                                .GENERAR_CATEGORIA = Me.chkCrearCategoria.Checked
                                .CODIGO_TIPO_CATEGORIA = Me.txtTipoCategoria.Text

                                If .Insertar() = True Then
                                    Grabado = True
                                    Me.Estado = enumEstados.CONSULTA

                                End If
                            Case enumEstados.EDICION
                                Me.oAlmacenes = New Class_CatAlmacenes(Me.TxtCodigoAlmacen.Text)

                                If .NOMBRE_ALMACEN.ToUpper <> Me.TxtNombreAlmacen.Text.ToUpper Then
                                    If MsgBox("Modificó el nombre del almacén, automáticamente el sistema también cambiará el nombre de la cuenta contable." & vbCrLf & _
                                              "Desea continuar?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then
                                        Exit Sub
                                    End If
                                End If

                                .GENERAR_CATEGORIA = False
                                .CODIGO_TIPO_CATEGORIA = ""

                                If .Actualizar() = True Then
                                    Grabado = True
                                    Me.Estado = enumEstados.CONSULTA
                                End If
                        End Select

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
            If txtLEN(Me.TxtNombreAlmacen.Text) = False Then
                MsgBox("Asígne nombre al almacén", MsgBoxStyle.Exclamation, Me.Text)
                Me.TxtNombreAlmacen.Focus()
                Return bResultado
            End If

            If txtLEN(Me.txtCodigoZona.Text) = False Then
                Me.lblNombreZona.Text = ""
                MsgBox("Asígne un código de zona.", MsgBoxStyle.Exclamation, Me.Text)
                Me.txtCodigoZona.Focus()
                Return bResultado
            Else
                Dim sql1 As New Class_find("SELECT CODIGO_ZONA FROM CAT_ZONAS WHERE CODIGO_ZONA='" & Me.txtCodigoZona.Text & "' ")

                If txtLEN(sql1.Result1) = False Then
                    MsgBox("El código de zona no existe.", MsgBoxStyle.Exclamation, Me.Text)
                    Me.txtCodigoZona.Focus()
                    Return bResultado
                End If
            End If

            Select Case Me.chkCrearCategoria.Checked
                Case False
                    If txtLEN(Me.TxtCodigoCategoria.Text) = False Then
                        MsgBox("Seleccione una categoría, en caso de no tener, puede usar la 0.", MsgBoxStyle.Exclamation, Me.Text)
                        Me.TxtCodigoCategoria.Focus()
                        Return False
                    End If
                Case True
                    If txtLEN(Me.txtTipoCategoria.Text) = False Then
                        MsgBox("Seleccione el tipo de categoría.", MsgBoxStyle.Exclamation, Me.Text)
                        Me.txtTipoCategoria.Focus()
                        Return False
                    End If
            End Select

            'Me.oCuenta.CUENTA_CONTABLE = Me.txtCuentaContable.Text
            'If Me.oCuenta.Consultar = False Then
            '    MsgBox("La cuenta contable que intenta guardar no es válida, favor de revisar", MsgBoxStyle.Exclamation, "Validación de la cuenta contable")
            '    Me.txtCuentaContable.Focus()
            '    Exit Sub
            'End If
            'If oCuenta.isCuentaContableValida(Me.txtCuentaContable.Text, False) = False Then
            '    MsgBox("La cuenta contable del almacen debe de ser de mayor", MsgBoxStyle.Exclamation, Me.Text)
            '    Me.txtCuentaContable.Focus()
            '    Exit Sub
            'End If

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
        Me.LlenaElemento(Me.Grid.CurrentRow.Cells("CODIGO_ALMACEN").Value.ToString)
    End Sub

    Private Sub Grid_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grid.CellDoubleClick
        Me.Estado = enumEstados.EDICION
        Me.Cambia_Estado()
    End Sub
    'Private Sub lstbElementos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstbElementos.DoubleClick
    '    Me.Estado = enumEstados.EDICION
    '    Me.Cambia_Estado()
    'End Sub

    'Private Sub lstbElementos_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstbElementos.Enter
    '    If Me.lstbElementos.Items.Count > 0 Then
    '        Me.tsbEditar.Enabled = True
    '    End If
    'End Sub

    'Private Sub lstbElementos_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstbElementos.LostFocus
    '    Me.tsbEditar.Enabled = False
    'End Sub

    'Private Sub lstbElementos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstbElementos.SelectedIndexChanged
    '    If Me.lstbElementos.SelectedIndex >= 0 Then
    '        Me.LlenaElemento(Me.lstbElementos.SelectedValue.ToString)
    '    End If
    'End Sub
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

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNombreAlmacen.KeyPress, txtCodigoZona.KeyPress, CboEstatus.KeyPress, TxtCodigoCategoria.KeyPress, chkCrearCategoria.KeyPress, _
        txtTipoCategoria.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub txt_Keydown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNombreAlmacen.KeyDown, CboEstatus.KeyDown, chkCrearCategoria.KeyDown
        If e.KeyCode = Keys.Return Then
            txtTAB(e)
        End If
    End Sub

    Private Sub txtNumerosEnterosKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigoAlmacen.KeyPress, txtCuentaContable.KeyPress, txtCodigoZona.KeyPress, TxtCodigoCategoria.KeyPress, txtTipoCategoria.KeyPress
        txtSoloNumerosEnteros(e)
        txtNoBeep(e)
    End Sub
#End Region

#Region "Keydown específicos"
    Private Sub txtCodigoZona_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCodigoZona.KeyDown
        Try
            Dim oZonas As New Class_CatZonas

            Select Case e.KeyCode
                Case Keys.F6
Buscar:
                    Dim resultado As String
                    resultado = oZonas.BusquedaVisual_PorDescripcion()
                    Me.txtCodigoZona.Text = resultado
                    If txtLEN(resultado) = True Then
                        GoTo Enter : Exit Sub
                    End If

                Case Keys.Return
Enter:
                    If txtLEN(Me.txtCodigoZona.Text) = False Then
                        Me.lblNombreZona.Text = "" : GoTo Buscar : Exit Sub
                    End If

                    oZonas = New Class_CatZonas(Me.txtCodigoZona.Text)
                    If oZonas.Existe = True Then
                        Me.lblNombreZona.Text = oZonas.NOMBRE_ZONA
                        txtTAB(e)
                    Else
                        Me.lblNombreZona.Text = "" : GoTo Buscar : Exit Sub
                    End If

            End Select
        Catch ex As Exception
            HandleError(Me.Name, "txtCodigoZona_KeyDown", ex)
        End Try
    End Sub

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
                        Me.lblCodigoCategoria.Text = "_"
                    End If

                Case Keys.Return
Enter:
                    If txtLEN(Me.TxtCodigoCategoria.Text) = False Then
                        Me.lblCodigoCategoria.Text = "_" ': GoTo Buscar : Exit Sub
                        txtTAB(e)
                        Return
                    End If

                    oCategorias = New Class_CatCategorias(Me.TxtCodigoCategoria.Text)
                    If oCategorias.Existe = True Then
                        Me.lblCodigoCategoria.Text = oCategorias.NOMBRE_CATEGORIA
                    Else
                        Me.lblCodigoCategoria.Text = "_" : GoTo Buscar : Exit Sub
                    End If

                    If Me.chkCrearCategoria.Visible = True Then
                        Me.chkCrearCategoria.Focus()
                    Else
                        'tsbGrabar.PerformClick()
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

            End Select
        Catch ex As Exception
            HandleError(Me.Name, "txtTipoCategoria_KeyDown", ex)
        End Try
    End Sub
#End Region

#Region "Validating específicos"

#End Region

    Private Sub CboFiltroHoja_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Refrescar()
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

    '    Private Sub txtCuentaContable_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCuentaContable.KeyDown

    '        Select Case e.KeyCode
    '            Case Keys.F6
    'busqueda_Visual:

    '                Dim sCuenta As String = oCuenta.BusquedaVisual_PorDescripcion
    '                If sCuenta.Length > 0 Then
    '                    Me.txtCuentaContable.Text = sCuenta
    '                    sCuenta = Replace(sCuenta, "'", "''")
    '                    Dim sql As New Class_find("Select CUENTA_CONTABLE,NOMBRE_CUENTA From CON_CAT_CUENTAS Where CUENTA_CONTABLE='" & sCuenta & "' ")
    '                    Me.txtCuentaContable.Text = sCuenta
    '                    LblCuenta.Text = sql.Result2
    '                    sql = Nothing
    '                End If
    '            Case Keys.Return
    '                If oCuenta.isCuentaContableValida(Me.txtCuentaContable.Text, False) = False Then
    '                    MsgBox("La cuenta contable del almacen debe de ser de mayor", MsgBoxStyle.Exclamation, Me.Text)
    '                    Me.txtCuentaContable.Focus()
    '                    Exit Sub
    '                End If
    '                Dim sql As New Class_find("Select NOMBRE_CUENTA From CON_CAT_CUENTAS Where CUENTA_CONTABLE='" & txtCuentaContable.Text & "' ")
    '                If sql.Result1 = "" Then
    '                    GoTo busqueda_Visual
    '                Else
    '                    LblCuenta.Text = sql.Result1
    '                End If

    '                sql = Nothing

    '                Me.tsbGrabar.PerformClick()

    '        End Select
    '    End Sub

#End Region

End Class