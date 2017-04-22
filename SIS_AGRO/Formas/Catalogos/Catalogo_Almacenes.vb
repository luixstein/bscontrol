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
        Dim sMsg As String = ""
        Select Case Me.Estado
            Case enumEstados.EDICION
                sMsg = " grabar las modificaciones del " & Me.msgElemento & " : " & Me.TxtCodigoAlmacen.Text
            Case enumEstados.NUEVO
                sMsg = " agregar el " & Me.msgElemento & " : " & Me.TxtCodigoAlmacen.Text
        End Select
        sMsg = "Deseas " & sMsg & " ?"
        If MsgBox(sMsg, CType(CInt(MsgBoxStyle.Question) + CInt(MsgBoxStyle.YesNo), MsgBoxStyle)) = MsgBoxResult.Yes Then
            Call Grabar_Elemento()
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
        Select Case Me.Estado
            Case enumEstados.NUEVO
                Me.gBoxInformacion.Enabled = True
                Me.gBoxBusquedaRapida.Enabled = False
                Me.tssLabelEstado.Text = "Agregando una nueva " & Me.msgElemento
                Me.tsbNuevo.Enabled = False
                Me.tsbEditar.Enabled = False
                Me.tsbGrabar.Enabled = True
                Me.tsbCancelar.Enabled = True

                Me.TxtCodigoAlmacen.Enabled = False
                Me.TxtNombreAlmacen.Enabled = True
                Me.txtCodigoZona.Enabled = True
                Me.CboEstatus.Enabled = False
                Me.InicializaElemento()
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
                Me.txtCodigoZona.Enabled = True
                Me.TxtNombreAlmacen.Focus()

            Case enumEstados.CONSULTA

                Me.gBoxInformacion.Enabled = False
                Me.gBoxBusquedaRapida.Enabled = True
                Me.tssLabelEstado.Text = "Consulta"
                Me.tsbNuevo.Enabled = True
                Me.tsbEditar.Enabled = False
                Me.tsbGrabar.Enabled = False
                Me.tsbCancelar.Enabled = False
                Me.txtFiltro.Focus()

        End Select
        Application.DoEvents()
    End Sub

    Private Sub InicializaElemento()
        Me.TxtCodigoAlmacen.Text = ""
        Me.TxtNombreAlmacen.Text = ""
        Me.txtCuentaContable.Text = ""
        Me.LblCuenta.Text = ""
        Me.txtCodigoZona.Text = ""
        Me.lblNombreZona.Text = ""
        Me.CboEstatus.SelectedIndex = 0
    End Sub

    Private Sub DesplegarElementos()
        With Me.Grid
            .DataSource = oAlmacenes.ObtenerElementosFiltro(Me.txtFiltro.Text, Me.cboEstatusFiltro.Text)
            .Columns("CODIGO_ALMACEN").Width = 50
            .Columns("NOMBRE_ALMACEN").Width = 200
        End With
    End Sub

    Private Sub LlenaElemento(ByVal iCodigo_Elemento As String)
        Me.oAlmacenes.Codigo_Almacen = iCodigo_Elemento
        If Me.oAlmacenes.Consultar Then
            With Me.oAlmacenes
                Me.TxtCodigoAlmacen.Text = .Codigo_Almacen.ToString
                Me.TxtNombreAlmacen.Text = .Nombre_Almacen.ToString
                Me.txtCuentaContable.Text = .Cuenta_Contable
                Dim sql As New Class_find("Select NOMBRE_CUENTA From CON_CAT_CUENTAS Where CUENTA_CONTABLE='" & txtCuentaContable.Text & "' ")
                If sql.Result1 = "" Then
                Else
                    LblCuenta.Text = sql.Result1
                End If
                sql = Nothing

                Me.txtCodigoZona.Text = .Codigo_Zona
                sql = New Class_find("Select NOMBRE_ZONA From CAT_ZONAS Where CODIGO_ZONA='" & txtCodigoZona.Text & "' ")
                If sql.Result1 = "" Then
                Else
                    lblNombreZona.Text = sql.Result1
                End If
                sql = Nothing



                If .Estatus = "A" Then
                    Me.CboEstatus.SelectedIndex = 0
                Else
                    Me.CboEstatus.SelectedIndex = 1
                End If

            End With
        End If
    End Sub

    Private Sub Grabar_Elemento()
        If Validar() = False Then
            Exit Sub
        End If

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

        Dim Grabado As Boolean = False
        Select Case Me.Estado
            Case enumEstados.NUEVO, enumEstados.EDICION
                Try
                    With Me.oAlmacenes
                        Select Case Me.Estado
                            Case enumEstados.NUEVO
                                Me.oAlmacenes = New Class_CatAlmacenes

                                .Codigo_Almacen = Me.TxtCodigoAlmacen.Text
                                .Nombre_Almacen = Me.TxtNombreAlmacen.Text
                                '.Cuenta_Contable = Me.txtCuentaContable.Text
                                .Estatus = Strings.Left(Me.CboEstatus.Text, 1)
                                .Codigo_Zona = Me.txtCodigoZona.Text
                                If .Insertar() Then
                                    Grabado = True
                                    Me.Estado = enumEstados.CONSULTA

                                End If
                            Case enumEstados.EDICION
                                Me.oAlmacenes = New Class_CatAlmacenes(Me.TxtCodigoAlmacen.Text)

                                If .Nombre_Almacen.ToUpper <> Me.TxtNombreAlmacen.Text.ToUpper Then
                                    If MsgBox("Modificó el nombre del almacén, automáticamente el sistema también cambiará el nombre de la cuenta contable." & vbCrLf & _
                                              "Desea continuar?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then
                                        Exit Sub
                                    End If
                                End If

                                .Nombre_Almacen = Me.TxtNombreAlmacen.Text
                                '.Cuenta_Contable = Me.txtCuentaContable.Text
                                .Estatus = Me.CboEstatus.Text

                                If .Actualizar() Then
                                    Grabado = True
                                    Me.Estado = enumEstados.CONSULTA
                                End If
                        End Select

                        If Grabado = True Then
                            MsgBox(Me.msgElemento & " Grabado satisfactoriamente.", MsgBoxStyle.Information, Me.Name)
                            Me.Refrescar()
                            Me.Cambia_Estado()
                        End If

                    End With
                Catch ex As Exception
                    HandleError(Me.Name, "Grabar", ex)
                    Me.Estado = enumEstados.CONSULTA
                    Me.Cambia_Estado()
                Finally

                End Try
        End Select
    End Sub

    Private Function Validar() As Boolean
        Dim bResultado As Boolean = False

        If txtLEN(Me.TxtNombreAlmacen.Text) = False Then
            MsgBox("Asígne nombre al almacen", MsgBoxStyle.Exclamation, Me.Text)
            Me.TxtNombreAlmacen.Focus()
            Return bResultado
        End If

        If txtLEN(Me.txtCodigoZona.Text) = False Then
            MsgBox("Asígne un codigo de zona.", MsgBoxStyle.Exclamation, Me.Text)
            Me.txtCodigoZona.Focus()
            Return bResultado
        Else
            Dim sql1 As New Class_find("SELECT CODIGO_ZONA FROM CAT_ZONAS WHERE CODIGO_ZONA='" & Me.txtCodigoZona.Text & "' ")

            If txtLEN(sql1.Result1) = False Then
                MsgBox("El codígo de Zona no existe.", MsgBoxStyle.Exclamation, Me.Text)
                Me.txtCodigoZona.Focus()
                Return bResultado
            End If
        End If

        bResultado = True
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

#Region " Eventos de TxtFiltro"
    Private Sub txtFiltro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFiltro.TextChanged
        Me.Grid.DataSource = Nothing

        With Me.Grid
            .DataSource = oAlmacenes.ObtenerElementosFiltro(Me.txtFiltro.Text, Me.cboEstatusFiltro.Text)
            .Columns("CODIGO_ALMACEN").Width = 50
            .Columns("NOMBRE_ALMACEN").Width = 200
        End With
    End Sub
    Private Sub txtFiltro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFiltro.KeyPress
        txtNoBeep(e)
        txtNoComilla(e)
    End Sub
    Private Sub txtFiltro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFiltro.KeyDown
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Return Or e.KeyCode = Keys.Back Then
            Me.Grid.DataSource = Nothing

            With Me.Grid
                .DataSource = oAlmacenes.ObtenerElementosFiltro(Me.txtFiltro.Text, Me.cboEstatusFiltro.Text)
                .Columns("CODIGO_ALMACEN").Width = 50
                .Columns("NOMBRE_ALMACEN").Width = 200
            End With
        End If
    End Sub

    Private Sub cboEstatusFiltro_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEstatusFiltro.SelectedIndexChanged
        Me.Grid.DataSource = Nothing

        With Me.Grid
            .DataSource = oAlmacenes.ObtenerElementosFiltro(Me.txtFiltro.Text, Me.cboEstatusFiltro.Text)
            .Columns("CODIGO_ALMACEN").Width = 50
            .Columns("NOMBRE_ALMACEN").Width = 200
        End With
    End Sub
#End Region

#Region "Eventos Genericos"

    Private Sub CboEstatus_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CboEstatus.KeyDown
        If e.KeyCode = Keys.Return Then
            tsbGrabar.PerformClick()
        End If
    End Sub
    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CboEstatus.KeyPress, TxtNombreAlmacen.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub txt_Keydown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNombreAlmacen.KeyDown, txtCuentaContable.KeyDown
        If e.KeyCode = Keys.Return Then
            Select Case Me.Estado
                Case enumEstados.EDICION
                    SendKeys.Send("{TAB}")
                Case enumEstados.NUEVO
                    SendKeys.Send("{TAB}")
            End Select
        End If
    End Sub

    Private Sub txtNumericos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigoAlmacen.KeyPress, TxtNombreAlmacen.KeyPress, txtCuentaContable.KeyPress
        Dim txt As TextBox = CType(sender, TextBox)
        txtNoBeep(e)
    End Sub

    Private Sub txtNumericos_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        Dim t As TextBox
        t = CType(sender, TextBox)
        If Not IsNumeric(t.Text) Then
            t.Text = Val(t.Text).ToString
        Else
            Me.ErrorProvider.Clear()
        End If
    End Sub
#End Region


#Region "Keydown específicos"
    Private Sub TxtCodigoZona_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCodigoZona.KeyDown
        Dim oZonas As New Class_CatZonas
        Select Case e.KeyCode
            Case Keys.F6
busca:
                Me.txtCodigoZona.Text = oZonas.BusquedaVisual_PorDescripcion
                oZonas.Codigo_Zona = CInt(Me.txtCodigoZona.Text)
                oZonas.Consultar()
                Me.lblNombreZona.Text = oZonas.Nombre_Zona
            Case Keys.Enter
                oZonas.Codigo_Zona = CInt(Me.txtCodigoZona.Text)
                If oZonas.Consultar() = False Then
                    GoTo busca
                End If
                Me.lblNombreZona.Text = oZonas.Nombre_Zona
        End Select
        txtTAB(e)
    End Sub
#End Region

#Region "Validating específicos"

#End Region

    Private Sub CboFiltroHoja_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Refrescar()
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