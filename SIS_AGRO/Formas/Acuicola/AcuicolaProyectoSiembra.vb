Option Strict On

Public Class AcuicolaProyectoSiembra
    Private oProyecto As New Class_ProyectoSiembraAcuicola

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

#Region "Propiedades"
#Region "Propiedades de campos de sistema"
    Public ReadOnly Property Nombre_Clase() As String
        Get
            Return "Class_Acuicola_Parametros_Global"
        End Get
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
            Me.msgElemento = "proyecto de siembra"
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
        sMsg = "Deseas " & sMsg & Me.msgElemento & " ?"
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
        'Me.oProyecto.Imprimir_Listado()
        MsgBox("FALTA")
    End Sub
#End Region

#Region "Eventos de objetos"
#Region "Eventos de la lista de elementos"
    Private Sub Grid_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grid.CellClick
        Me.LlenaElemento(Me.Grid.CurrentRow.Cells("ID_PROYECTO_SIEMBRA").Value.ToString)
    End Sub

    Private Sub Grid_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grid.CellDoubleClick
        Me.Estado = enumEstados.EDICION
        Me.Cambia_Estado()
    End Sub
#End Region

#Region "Eventos de TxtFiltro"
    'Private Sub txtFiltro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFiltro.TextChanged
    '    Me.Grid.DataSource = Nothing
    '    Me.DesplegarElementos()
    'End Sub

    'Private Sub txtFiltro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFiltro.KeyPress
    '    txtNoBeep(e)
    '    txtNoComilla(e)
    'End Sub

    'Private Sub txtFiltro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFiltro.KeyDown
    '    If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Return Or e.KeyCode = Keys.Back Then
    '        Me.Grid.DataSource = Nothing
    '        Me.DesplegarElementos()
    '    End If
    'End Sub

    Private Sub cboEstatusFiltro_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEstatusFiltro.SelectedIndexChanged
        Me.Grid.DataSource = Nothing
        Me.DesplegarElementos()
    End Sub
#End Region

#Region "Eventos Genericos"
    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        txtNoBeep(e)
    End Sub

    Private Sub txt_Keydown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CboEstatus.KeyDown, cboDivision.KeyDown, txtCiclo.KeyDown, dtFecha.KeyDown, cboLote.KeyDown
        If e.KeyCode = Keys.Return Then
            txtTAB(e)
        End If
    End Sub

    Private Sub txtNumerosEnterosKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCiclo.KeyPress
        txtSoloNumerosEnteros(e)
        txtNoBeep(e)
    End Sub

    Private Sub txtNumerosDecimalKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHA.KeyPress
        Dim txt As TextBox = CType(sender, TextBox)
        txtSoloNumerosDecimales(e, txt.Text)
        txtNoBeep(e)
    End Sub
#End Region

#Region "Keydown específicos"
    Private Sub txtHA_KeyDown(sender As Object, e As KeyEventArgs) Handles txtHA.KeyDown
        '
    End Sub
#End Region

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

                    Me.CboEstatus.Enabled = True
                    Me.cboDivision.Enabled = True
                    Me.txtCiclo.Enabled = True
                    Me.dtFecha.Enabled = True
                    Me.cboLote.Enabled = True
                    Me.txtHA.Enabled = True

                    Me.InicializaElemento()

                    Me.cboDivision.Focus()

                Case enumEstados.EDICION
                    Me.gBoxInformacion.Enabled = True
                    Me.gBoxBusquedaRapida.Enabled = False
                    Me.tssLabelEstado.Text = "Editando"
                    Me.tsbNuevo.Enabled = False
                    Me.tsbEditar.Enabled = False
                    Me.tsbGrabar.Enabled = True
                    Me.tsbCancelar.Enabled = True

                    Me.CboEstatus.Enabled = True
                    Me.cboDivision.Enabled = False
                    Me.txtCiclo.Enabled = False
                    Me.dtFecha.Enabled = True
                    Me.cboLote.Enabled = False
                    Me.txtHA.Enabled = True

                    Me.txtHA.Focus()

                Case enumEstados.CONSULTA

                    Me.gBoxInformacion.Enabled = False
                    Me.gBoxBusquedaRapida.Enabled = True
                    Me.tssLabelEstado.Text = "Consultando"
                    Me.tsbNuevo.Enabled = True
                    Me.tsbEditar.Enabled = False
                    Me.tsbGrabar.Enabled = False
                    Me.tsbCancelar.Enabled = False

                    'Me.txtFiltro.Focus()

            End Select
            Application.DoEvents()
        Catch ex As Exception
            HandleError(Me.Name, "Cambia_Estado", ex)
        End Try
    End Sub

    Private Sub InicializaElemento()
        Try
            Me.CboEstatus.SelectedIndex = 0
            Me.cboDivision.SelectedIndex = -1
            Me.txtCiclo.Text = ""
            Me.dtFecha.Value = Date.Now
            Me.cboLote.SelectedIndex = -1
            Me.txtHA.Text = ""
        Catch ex As Exception
            HandleError(Me.Name, "InicializaElemento", ex)
        End Try
    End Sub

    Private Sub DesplegarElementos()
        'Try
        '    With Me.Grid
        '        .DataSource = oProyecto.ObtenerElementosFiltro(Me.txtFiltro.Text, Me.cboEstatusFiltro.Text)
        '        .Columns("CODIGO_ALMACEN").Width = 50
        '        .Columns("NOMBRE_ALMACEN").Width = 200
        '        .Columns("NOMBRE_ALMACEN").Width = 200
        '        .Columns("NOMBRE_ALMACEN").Width = 200
        '        .Columns("NOMBRE_ALMACEN").Width = 200
        '        .Columns("NOMBRE_ALMACEN").Width = 200
        '        .Columns("NOMBRE_ALMACEN").Width = 200
        '    End With
        'Catch ex As Exception
        '    HandleError(Me.Name, "DesplegarElementos", ex)
        'End Try
    End Sub

    Private Sub LlenaElemento(ByVal iCodigo_Elemento As String)
        'Try
        '    Me.oProyecto.CODIGO_ALMACEN = iCodigo_Elemento
        '    If Me.oProyecto.Consultar Then
        '        With Me.oProyecto
        '            Me.TxtCodigoAlmacen.Text = .CODIGO_ALMACEN.ToString
        '            Me.TxtNombreAlmacen.Text = .NOMBRE_ALMACEN.ToString
        '            Me.txtCuentaContable.Text = .CUENTA_CONTABLE
        '            Dim sql As New Class_find("Select NOMBRE_CUENTA From CON_CAT_CUENTAS Where CUENTA_CONTABLE='" & txtCuentaContable.Text & "' ")
        '            If sql.Result1 = "" Then
        '            Else
        '                lblNombreCuenta.Text = sql.Result1
        '            End If
        '            sql = Nothing

        '            Me.txtCodigoZona.Text = .CODIGO_ZONA
        '            sql = New Class_find("Select NOMBRE_ZONA From CAT_ZONAS Where CODIGO_ZONA='" & txtCodigoZona.Text & "' ")
        '            If sql.Result1 = "" Then
        '            Else
        '                lblNombreZona.Text = sql.Result1
        '            End If
        '            sql = Nothing

        '            Me.TxtCodigoCategoria.Text = .CODIGO_CATEGORIA
        '            sql = New Class_find("Select NOMBRE_CATEGORIA From CAT_CATEGORIAS Where CODIGO_CATEGORIA='" & TxtCodigoCategoria.Text & "' ")
        '            If sql.Result1 = "" Then
        '            Else
        '                LblNombreCategoria.Text = sql.Result1
        '            End If
        '            sql = Nothing

        '            If .Estatus = "A" Then
        '                Me.CboEstatus.SelectedIndex = 0
        '            Else
        '                Me.CboEstatus.SelectedIndex = 1
        '            End If

        '        End With
        '    End If
        'Catch ex As Exception
        '    HandleError(Me.Name, "LlenaElemento", ex)
        'End Try
    End Sub

    Private Sub Grabar()
        'Dim Grabado As Boolean = False
        'Select Case Me.Estado
        '    Case enumEstados.NUEVO, enumEstados.EDICION
        '        Try
        '            With Me.oProyecto

        '                .CODIGO_ALMACEN = Me.TxtCodigoAlmacen.Text
        '                .NOMBRE_ALMACEN = Me.TxtNombreAlmacen.Text
        '                '.Cuenta_Contable = Me.txtCuentaContable.Text
        '                .Estatus = Strings.Left(Me.CboEstatus.Text, 1)
        '                .CODIGO_ZONA = Me.txtCodigoZona.Text
        '                .CODIGO_CATEGORIA = Me.TxtCodigoCategoria.Text

        '                Select Case Me.Estado
        '                    Case enumEstados.NUEVO
        '                        Me.oProyecto = New Class_CatAlmacenes

        '                        .GENERAR_CATEGORIA = Me.chkCrearCategoria.Checked
        '                        .CODIGO_TIPO_CATEGORIA = Me.txtTipoCategoria.Text

        '                        If .Insertar() = True Then
        '                            Grabado = True
        '                            Me.Estado = enumEstados.CONSULTA

        '                        End If
        '                    Case enumEstados.EDICION
        '                        Me.oProyecto = New Class_CatAlmacenes(Me.TxtCodigoAlmacen.Text)

        '                        If .NOMBRE_ALMACEN.ToUpper <> Me.TxtNombreAlmacen.Text.ToUpper Then
        '                            If MsgBox("Modificó el nombre del almacén, automáticamente el sistema también cambiará el nombre de la cuenta contable." & vbCrLf &
        '                                      "Desea continuar?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then
        '                                Exit Sub
        '                            End If
        '                        End If

        '                        .GENERAR_CATEGORIA = False
        '                        .CODIGO_TIPO_CATEGORIA = ""

        '                        If .Actualizar() = True Then
        '                            Grabado = True
        '                            Me.Estado = enumEstados.CONSULTA
        '                        End If
        '                End Select

        '                If Grabado = True Then
        '                    MsgBox(Me.msgElemento & " grabado satisfactoriamente.", MsgBoxStyle.Information, Me.Name)
        '                    Me.Refrescar()
        '                    Me.Cambia_Estado()
        '                End If

        '            End With
        '        Catch ex As Exception
        '            HandleError(Me.Name, "Grabar", ex)
        '            Me.Estado = enumEstados.CONSULTA
        '            Me.Cambia_Estado()
        '        End Try
        'End Select
    End Sub

    Private Function Validar() As Boolean
        '    Dim bResultado As Boolean = False

        '    Try
        '        If txtLEN(Me.TxtNombreAlmacen.Text) = False Then
        '            MsgBox("Asígne nombre al almacén", MsgBoxStyle.Exclamation, Me.Text)
        '            Me.TxtNombreAlmacen.Focus()
        '            Return bResultado
        '        End If

        '        If txtLEN(Me.txtCodigoZona.Text) = False Then
        '            Me.lblNombreZona.Text = ""
        '            MsgBox("Asígne un código de zona.", MsgBoxStyle.Exclamation, Me.Text)
        '            Me.txtCodigoZona.Focus()
        '            Return bResultado
        '        Else
        '            Dim sql1 As New Class_find("SELECT CODIGO_ZONA FROM CAT_ZONAS WHERE CODIGO_ZONA='" & Me.txtCodigoZona.Text & "' ")

        '            If txtLEN(sql1.Result1) = False Then
        '                MsgBox("El código de zona no existe.", MsgBoxStyle.Exclamation, Me.Text)
        '                Me.txtCodigoZona.Focus()
        '                Return bResultado
        '            End If
        '        End If

        '        Select Case Me.chkCrearCategoria.Checked
        '            Case False
        '                If txtLEN(Me.TxtCodigoCategoria.Text) = False Then
        '                    MsgBox("Seleccione una categoría, en caso de no tener, puede usar la 0.", MsgBoxStyle.Exclamation, Me.Text)
        '                    Me.TxtCodigoCategoria.Focus()
        '                    Return False
        '                End If
        '            Case True
        '                If txtLEN(Me.txtTipoCategoria.Text) = False Then
        '                    MsgBox("Seleccione el tipo de categoría.", MsgBoxStyle.Exclamation, Me.Text)
        '                    Me.txtTipoCategoria.Focus()
        '                    Return False
        '                End If
        '        End Select

        '        'Me.oCuenta.CUENTA_CONTABLE = Me.txtCuentaContable.Text
        '        'If Me.oCuenta.Consultar = False Then
        '        '    MsgBox("La cuenta contable que intenta guardar no es válida, favor de revisar", MsgBoxStyle.Exclamation, "Validación de la cuenta contable")
        '        '    Me.txtCuentaContable.Focus()
        '        '    Exit Sub
        '        'End If
        '        'If oCuenta.isCuentaContableValida(Me.txtCuentaContable.Text, False) = False Then
        '        '    MsgBox("La cuenta contable del almacen debe de ser de mayor", MsgBoxStyle.Exclamation, Me.Text)
        '        '    Me.txtCuentaContable.Focus()
        '        '    Exit Sub
        '        'End If

        '        bResultado = True
        '    Catch ex As Exception
        '        HandleError(Me.Name, "Validar", ex)
        '    End Try
        '    Return bResultado
    End Function

    Private Sub DesplegarDivisiones()
        Dim oDivisiones As New Class_CatDivisionesAcuicola
        Try
            With Me.cboDivision
                .DisplayMember = "NOMBRE_DIVISION"
                .ValueMember = "CODIGO_DIVISION"
                Dim dView As New Data.DataView(oDivisiones.ObtenerElementosActivos)
                dView.Sort = "NOMBRE_DIVISION"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedIndex = -1
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarDivisiones", ex)
        End Try
    End Sub

#End Region

End Class