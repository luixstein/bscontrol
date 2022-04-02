Option Strict On

Imports System.Data.SqlClient

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
            Return
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

                    Me.txtMarca.Enabled = True
                    Me.txtPlaca.Enabled = True
                    Me.txtAnio.Enabled = True
                    Me.txtCodigoAutotransporte.Enabled = True
                    Me.txtCodigoPermisoSct.Enabled = True
                    Me.txtNumeroPermisoSct.Enabled = True
                    Me.txtNombreAseguradoraResponsabilidadCivil.Enabled = True
                    Me.txtPolizaResponsabilidadCivil.Enabled = True
                    Me.txtNombreAseguradoraMedioAmbiente.Enabled = True
                    Me.txtPolizaMedioAmbiente.Enabled = True
                    Me.txtNombreAseguradoraCarga.Enabled = True
                    Me.txtPolizaCarga.Enabled = True
                    Me.txtPrimaSeguro.Enabled = True

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

                    Me.txtMarca.Enabled = True
                    Me.txtPlaca.Enabled = True
                    Me.txtAnio.Enabled = True
                    Me.txtCodigoAutotransporte.Enabled = True
                    Me.txtCodigoPermisoSct.Enabled = True
                    Me.txtNumeroPermisoSct.Enabled = True
                    Me.txtNombreAseguradoraResponsabilidadCivil.Enabled = True
                    Me.txtPolizaResponsabilidadCivil.Enabled = True
                    Me.txtNombreAseguradoraMedioAmbiente.Enabled = True
                    Me.txtPolizaMedioAmbiente.Enabled = True
                    Me.txtNombreAseguradoraCarga.Enabled = True
                    Me.txtPolizaCarga.Enabled = True
                    Me.txtPrimaSeguro.Enabled = True

                    Me.chkCrearCategoria.Visible = False : Me.chkCrearCategoria.Checked = True : Me.chkCrearCategoria.Checked = False

                    Me.TxtNombre.Focus()

                Case enumEstados.CONSULTA
                    Me.gBoxInformacion.Enabled = False
                    Me.gBoxBusquedaRapida.Enabled = True
                    Me.tssLabelEstado.Text = "Consultando"
                    Me.tsbNuevo.Enabled = True
                    Me.tsbEditar.Enabled = True
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

        Me.txtMarca.Text = ""
        Me.txtPlaca.Text = ""
        Me.txtAnio.Text = ""
        Me.txtCodigoAutotransporte.Text = ""
        Me.LblNombreAutransporte.Text = ""
        Me.txtCodigoPermisoSct.Text = ""
        Me.LblNombreAutransporte.Text = ""
        Me.txtNumeroPermisoSct.Text = ""
        Me.txtNombreAseguradoraResponsabilidadCivil.Text = ""
        Me.txtPolizaResponsabilidadCivil.Text = ""
        Me.txtNombreAseguradoraMedioAmbiente.Text = ""
        Me.txtPolizaMedioAmbiente.Text = ""
        Me.txtNombreAseguradoraCarga.Text = ""
        Me.txtPolizaCarga.Text = ""
        Me.txtPrimaSeguro.Text = "0.00"
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
                    Me.TxtNombre.Text = .NOMBRE_VEHICULO.ToString

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

                    Me.txtMarca.Text = .MARCA
                    Me.txtPlaca.Text = .PLACA.ToString
                    Me.txtAnio.Text = .ANIO.ToString

                    Me.txtCodigoAutotransporte.Text = .CODIGO_AUTOTRANSPORTE
                    sql = New Class_find("SELECT NOMBRE_AUTOTRANSPORTE FROM CFDI_CAT_CONFIG_AUTOTRANSPORTE WHERE CODIGO_AUTOTRANSPORTE='" & .CODIGO_AUTOTRANSPORTE & "' ")
                    If sql.Result1 = "" Then
                    Else
                        Me.LblNombreAutransporte.Text = sql.Result1
                    End If

                    Me.txtCodigoPermisoSct.Text = .CODIGO_PERMISO_SCT
                    sql = New Class_find("SELECT NOMBRE_PERMISO_SCT FROM CFDI_CAT_TIPOS_PERMISOS_SCT WHERE CODIGO_PERMISO_SCT='" & .CODIGO_PERMISO_SCT & "' ")
                    If sql.Result1 = "" Then
                    Else
                        Me.LblNombrePermisoSct.Text = sql.Result1
                    End If

                    Me.txtNumeroPermisoSct.Text = .NUMERO_PERMISO_SCT
                    Me.txtNombreAseguradoraResponsabilidadCivil.Text = .NOMBRE_ASEGURADORA_RESPONSABILIDAD_CIVIL
                    Me.txtPolizaResponsabilidadCivil.Text = .POLIZA_RESPONSABILIDAD_CIVIL
                    Me.txtNombreAseguradoraMedioAmbiente.Text = .NOMBRE_ASEGURADORA_MEDIO_AMBIENTE
                    Me.txtPolizaMedioAmbiente.Text = .POLIZA_MEDIO_AMBIENTE
                    Me.txtNombreAseguradoraCarga.Text = .NOMBRE_ASEGURADORA_CARGA
                    Me.txtPolizaCarga.Text = .POLIZA_CARGA
                    Me.txtPrimaSeguro.Text = FormatImporteContable(.PRIMA_SEGURO)

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

                        .MARCA = Me.txtMarca.Text
                        .PLACA = Me.txtPlaca.Text
                        .ANIO = Me.txtAnio.Text
                        .CODIGO_AUTOTRANSPORTE = Me.txtCodigoAutotransporte.Text
                        .CODIGO_PERMISO_SCT = Me.txtCodigoPermisoSct.Text
                        .NUMERO_PERMISO_SCT = Me.txtNumeroPermisoSct.Text
                        .NOMBRE_ASEGURADORA_RESPONSABILIDAD_CIVIL = Me.txtNombreAseguradoraResponsabilidadCivil.Text
                        .POLIZA_RESPONSABILIDAD_CIVIL = Me.txtPolizaResponsabilidadCivil.Text
                        .NOMBRE_ASEGURADORA_MEDIO_AMBIENTE = Me.txtNombreAseguradoraMedioAmbiente.Text
                        .POLIZA_MEDIO_AMBIENTE = Me.txtPolizaMedioAmbiente.Text
                        .NOMBRE_ASEGURADORA_CARGA = Me.txtNombreAseguradoraCarga.Text
                        .POLIZA_CARGA = Me.txtPolizaCarga.Text
                        .PRIMA_SEGURO = valorNumericoD(Me.txtPrimaSeguro.Text)
                        .CODIGO_USUARIO_CREO = Usuario.Codigo_Usuario.ToString
                        .FECHA_CREO = Date.Now
                        .CODIGO_USUARIO_MODIFICO = Usuario.Codigo_Usuario.ToString
                        .FECHA_MODIFICO = Date.Now

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
        Const sProcedure As String = "Validar"
        Dim bResultado As Boolean = False
        Try
            If txtLEN(Me.TxtNombre.Text) = False Then
                MsgBox("Capture el nombre del vehículo.", MsgBoxStyle.Exclamation, sProcedure)
                Me.TxtNombre.Focus()
                Return bResultado
            End If

            Select Case Me.chkCrearCategoria.Checked
                Case False
                    If txtLEN(Me.TxtCodigoCategoria.Text) = False Then
                        MsgBox("Seleccione una categoria, en caso de no tener, puede usar la 0.", MsgBoxStyle.Exclamation, sProcedure)
                        Me.TxtCodigoCategoria.Focus()
                        Return False
                    End If
                Case True
                    If txtLEN(Me.txtTipoCategoria.Text) = False Then
                        MsgBox("Seleccione el tipo de categoria.", MsgBoxStyle.Exclamation, sProcedure)
                        Me.txtTipoCategoria.Focus()
                        Return False
                    End If
            End Select

            If txtLEN(Me.txtCodigoPermisoSct.Text) Then
                If txtLEN(Me.txtNumeroPermisoSct.Text) = False Then
                    MsgBox("Capture un código de permiso SCT.", MsgBoxStyle.Exclamation, sProcedure)
                    Me.txtNumeroPermisoSct.Focus()
                    Return False
                End If
            End If

            If txtLEN(Me.txtNumeroPermisoSct.Text) Then
                If txtLEN(Me.txtCodigoPermisoSct.Text) = False Then
                    MsgBox("Capture un número de permiso SCT.", MsgBoxStyle.Exclamation, sProcedure)
                    Me.txtCodigoPermisoSct.Focus()
                    Return False
                End If
            End If

            If txtLEN(Me.txtCodigoAutotransporte.Text) = False Then
                MsgBox("Capture un código de autotransporte.", MsgBoxStyle.Exclamation, sProcedure)
                Me.txtCodigoAutotransporte.Focus()
                Return False
            End If

            If txtLEN(Me.txtNombreAseguradoraResponsabilidadCivil.Text) = False Then
                MsgBox("Capture un nombre de aseguradora de responsabilidad civil.", MsgBoxStyle.Exclamation, sProcedure)
                Me.txtNombreAseguradoraResponsabilidadCivil.Focus()
                Return False
            End If

            If txtLEN(Me.txtPolizaResponsabilidadCivil.Text) = False Then
                MsgBox("Capture una poliza de aseguradora de responsabilidad civil.", MsgBoxStyle.Exclamation, sProcedure)
                Me.txtPolizaResponsabilidadCivil.Focus()
                Return False
            End If

            'If txtLEN(Me.txtNombreAseguradoraMedioAmbiente.Text) = False Then
            '    MsgBox("Capture un nombre de aseguradora de medio ambiente.", MsgBoxStyle.Exclamation,sProcedure)
            '    Me.txtNombreAseguradoraMedioAmbiente.Focus()
            '    Return False
            'End If

            'If txtLEN(Me.txtPolizaMedioAmbiente.Text) = False Then
            '    MsgBox("Capture una poliza de aseguradora de medio ambiente.", MsgBoxStyle.Exclamation,sProcedure)
            '    Me.txtPolizaMedioAmbiente.Focus()
            '    Return False
            'End If

            'If txtLEN(Me.txtNombreAseguradoraCarga.Text) = False Then
            '    MsgBox("Capture un nombre de aseguradora de carga.", MsgBoxStyle.Exclamation,sProcedure)
            '    Me.txtNombreAseguradoraCarga.Focus()
            '    Return False
            'End If

            'If txtLEN(Me.txtPolizaCarga.Text) = False Then
            '    MsgBox("Capture una poliza de aseguradora de carga.", MsgBoxStyle.Exclamation,sProcedure)
            '    Me.txtPolizaCarga.Focus()
            '    Return False
            'End If

            If txtLEN(Me.txtPrimaSeguro.Text) = False Then
                Me.txtPrimaSeguro.Text = "0"
            End If

            bResultado = True
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
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
    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNombre.KeyPress, TxtCodigoCategoria.KeyPress, TxtCodigo.KeyPress, txtTipoCategoria.KeyPress, txtCodigoAutotransporte.KeyPress, txtMarca.KeyPress, txtPlaca.KeyPress, txtCodigoPermisoSct.KeyPress, txtNumeroPermisoSct.KeyPress, _
        txtNombreAseguradoraResponsabilidadCivil.KeyPress, txtPolizaResponsabilidadCivil.KeyPress, txtNombreAseguradoraMedioAmbiente.KeyPress, txtPolizaMedioAmbiente.KeyPress, txtNombreAseguradoraCarga.KeyPress, txtPolizaCarga.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub txt_Keydown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNombre.KeyDown, CboEstatus.KeyDown, chkCrearCategoria.KeyDown, txtMarca.KeyDown, txtPlaca.KeyDown, txtAnio.KeyDown, txtNumeroPermisoSct.KeyDown, txtNombreAseguradoraResponsabilidadCivil.KeyDown, txtPolizaResponsabilidadCivil.KeyDown,
        txtNombreAseguradoraMedioAmbiente.KeyDown, txtPolizaMedioAmbiente.KeyDown, txtNombreAseguradoraCarga.KeyDown, txtPolizaCarga.KeyDown
        If e.KeyCode = Keys.Return Then
            txtTAB(e)
        End If
    End Sub

    Private Sub txtNumerosEnterosKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigoCategoria.KeyPress, txtTipoCategoria.KeyPress, txtAnio.KeyPress
        txtSoloNumerosEnteros(e)
        txtNoBeep(e)
    End Sub

    Private Sub txtNumerosDecimalesKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrimaSeguro.KeyPress
        Dim Txt As TextBox = CType(sender, TextBox)
        txtSoloNumerosDecimales(e, Txt.Text)
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
                        GoTo Enter : Return
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
                        Me.lblCategoria.Text = "_" : GoTo Buscar : Return
                    End If

                    txtTAB(e)

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
                        GoTo Enter : Return
                    End If

                Case Keys.Return
Enter:
                    If txtLEN(Me.txtTipoCategoria.Text) = False Then
                        Me.lblTipoCategoria.Text = "" : GoTo Buscar : Return
                    End If

                    oTiposCategorias = New Class_CatTiposCategorias(Me.txtTipoCategoria.Text)
                    If oTiposCategorias.Existe = True Then
                        Me.lblTipoCategoria.Text = oTiposCategorias.Nombre_Tipo_Categoria
                    Else
                        Me.lblTipoCategoria.Text = "" : GoTo Buscar : Return
                    End If

                    txtTAB(e)

            End Select
        Catch ex As Exception
            HandleError(Me.Name, "txtTipoCategoria_KeyDown", ex)
        End Try
    End Sub

    Private Sub txtCodigoAutotransporte_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCodigoAutotransporte.KeyDown
        Dim oAutotransporte As New Class_CfdiCatConfigAutotransporte
        Try
            Select Case e.KeyCode
                Case Keys.F6
Buscar:
                    Dim sAutotransporte As String = oAutotransporte.BusquedaVisual_PorDescripcion()
                    If txtLEN(sAutotransporte) = True Then
                        Me.txtCodigoAutotransporte.Text = sAutotransporte
                        GoTo Enter : Return
                    End If

                Case Keys.Enter
                    If txtLEN(Me.txtCodigoAutotransporte.Text) = False Then
                        Me.LblNombreAutransporte.Text = ""
                        GoTo Buscar : Return
                    End If
Enter:
                    oAutotransporte = New Class_CfdiCatConfigAutotransporte(Me.txtCodigoAutotransporte.Text)

                    If oAutotransporte.Existe = False Then
                        Me.LblNombreAutransporte.Text = ""
                        GoTo Buscar : Return
                    End If

                    Me.LblNombreAutransporte.Text = oAutotransporte.NOMBRE_AUTOTRANSPORTE

                    txtTAB(e)
            End Select

        Catch ex As Exception
            HandleError(Me.Name, "txtCodigoAutotransporte_KeyDown", ex)
        End Try
    End Sub

    Private Sub txtCodigoPermisoSct_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCodigoPermisoSct.KeyDown
        Dim oPermisoSct As New Class_CfdiCatTiposPermisosSCT
        Try
            Select Case e.KeyCode
                Case Keys.F6
Buscar:
                    Dim sPermisoSct As String = oPermisoSct.BusquedaVisual_PorDescripcion()
                    If txtLEN(sPermisoSct) = True Then
                        Me.txtCodigoPermisoSct.Text = sPermisoSct
                        GoTo Enter : Return
                    End If

                Case Keys.Enter
                    If txtLEN(Me.txtCodigoPermisoSct.Text) = False Then
                        Me.LblNombrePermisoSct.Text = ""
                        GoTo Buscar : Return
                    End If
Enter:
                    oPermisoSct = New Class_CfdiCatTiposPermisosSCT(Me.txtCodigoPermisoSct.Text)

                    If oPermisoSct.Existe = False Then
                        Me.LblNombrePermisoSct.Text = ""
                        GoTo Buscar : Return
                    End If

                    Me.LblNombrePermisoSct.Text = oPermisoSct.NOMBRE_PERMISO_SCT

                    txtTAB(e)
            End Select

        Catch ex As Exception
            HandleError(Me.Name, "txtCodigoPermisoSct_KeyDown", ex)
        End Try
    End Sub

    Private Sub txtPrimaSeguro_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPrimaSeguro.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.txtPrimaSeguro.Text = FormatImporteContable(valorNumericoD(Me.txtPrimaSeguro.Text))
            tsbGrabar.PerformClick()
        End If
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