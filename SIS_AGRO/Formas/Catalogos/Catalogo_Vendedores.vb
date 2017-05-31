Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Public Class Catalogo_Vendedores
    Dim oVentas As new Class_CatVendedores

#Region "Campos"


#Region "Campos de la tabla"
    Private _Codigo_Vendedor As Integer
    Private _Nombre_Vendedor As String
    Private _Estatus As String
#End Region

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
    Public Property Codigo_Vendedor() As Integer
        Get
            Return Me._Codigo_Vendedor
        End Get
        Set(ByVal value As Integer)
            Me._Codigo_Vendedor = value
        End Set
    End Property

    Public Property Nombre_Vendedor() As String
        Get
            Return Me._Nombre_Vendedor
        End Get
        Set(ByVal value As String)
            Me._Nombre_Vendedor = value
        End Set
    End Property

    Public Property Estatus() As String
        Get
            Return Me._Estatus
        End Get
        Set(ByVal value As String)
            Me._Estatus = value
        End Set
    End Property


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
            Me.msgElemento = "Vendedor"
            Me.msgElementos = "Vendedores"
            Me.Run = False
            'Me.lstbElementos.ContextMenuStrip = Me.cMenuStripAccion
            Estado = enumEstados.CONSULTA
            Me.Cambia_Estado()
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
        sMsg = "Deseas " & sMsg & Me.msgElemento & " : " & Me.TxtNombreVendedor.Text & " ?"
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
        Dim oElementos As New Class_CatVendedores
        oElementos.Imprimir_Listado()
        oElementos = Nothing
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

                    Me.TxtIDVendedor.Enabled = False
                    Me.TxtNombreVendedor.Enabled = True
                    Me.CboEstatus.Enabled = False
                    Me.txtCodigoCategoria.Enabled = True
                    Me.TxtCodigoCentroCosto.Enabled = True

                    Me.InicializaElemento()

                    Me.TxtIDVendedor.Text = oVentas.codigoSiguiente.ToString
                    Me.chkCrearCategoria.Visible = True : Me.chkCrearCategoria.Checked = False : Me.chkCrearCategoria.Checked = True 'esta como false y true para forzar a que hay cambio y se ejecute el evento del check
                    Me.TxtNombreVendedor.Focus()

                Case enumEstados.EDICION
                    Me.gBoxInformacion.Enabled = True
                    Me.gBoxBusquedaRapida.Enabled = False
                    Me.tssLabelEstado.Text = "Editando"
                    Me.tsbNuevo.Enabled = False
                    Me.tsbEditar.Enabled = False
                    Me.tsbGrabar.Enabled = True
                    Me.tsbCancelar.Enabled = True

                    Me.TxtIDVendedor.Enabled = False
                    Me.TxtNombreVendedor.Enabled = True
                    Me.CboEstatus.Enabled = True
                    Me.txtCodigoCategoria.Enabled = True
                    Me.chkCrearCategoria.Visible = False : Me.chkCrearCategoria.Checked = True : Me.chkCrearCategoria.Checked = False
                    Me.TxtCodigoCentroCosto.Enabled = True

                    Me.TxtNombreVendedor.Focus()

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
        Me.TxtIDVendedor.Text = ""
        Me.TxtNombreVendedor.Text = ""
        Me.CboEstatus.SelectedIndex = 0
        Me.txtCodigoCategoria.Text = ""
        Me.lblCategoria.Text = ""
        Me.txtTipoCategoria.Text = ""
        Me.lblTipoCategoria.Text = ""
        Me.chkCrearCategoria.Checked = False
        Me.TxtCodigoCentroCosto.Text = ""
        Me.LblNombreCentroCosto.Text = ""
    End Sub

    Private Sub DesplegarElementos()
        Try
            Dim oElementos As New Class_CatVendedores
            With Me.Grid
                .DataSource = oElementos.ObtenerElementos
                .Columns("CODIGO_VENDEDOR").Width = 30
                .Columns("NOMBRE_VENDEDOR").Width = 280
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarElementos", ex)
        End Try
    End Sub

    Private Sub LlenaElemento(ByVal iCodigo_Elemento As Integer)
        Try
            Dim oElemento As New Class_CatVendedores
            oElemento.CODIGO_VENDEDOR = iCodigo_Elemento
            If oElemento.Consultar = True Then
                With oElemento
                    Me.TxtIDVendedor.Text = .CODIGO_VENDEDOR.ToString
                    Me.TxtNombreVendedor.Text = .NOMBRE_VENDEDOR.ToString
                    If .Status = "A" Then
                        Me.CboEstatus.SelectedIndex = 0
                    Else
                        Me.CboEstatus.SelectedIndex = 1
                    End If
                    Me.txtCodigoCategoria.Text = .CODIGO_CATEGORIA
                    Dim sql As New Class_find("SELECT NOMBRE_CATEGORIA FROM CAT_CATEGORIAS WHERE CODIGO_CATEGORIA='" & Me.txtCodigoCategoria.Text & "' ")
                    If sql.Result1 = "" Then
                    Else
                        lblCategoria.Text = sql.Result1
                    End If

                    Me.TxtCodigoCentroCosto.Text = .CODIGO_CENTRO_COSTO.ToString
                    sql = New Class_find("SELECT NOMBRE_CENTRO_COSTO FROM NOMINA_CAT_CENTROS_COSTOS WHERE CODIGO_CENTRO_COSTO=" & Me.TxtCodigoCentroCosto.Text)
                    If sql.Result1 = "" Then
                    Else
                        LblNombreCentroCosto.Text = sql.Result1
                    End If

                End With
            End If
            oElemento = Nothing
        Catch ex As Exception
            HandleError(Me.Name, "LlenaElemento", ex)
        End Try
    End Sub

    Private Sub Grabar()
        Dim oElemento As New Class_CatVendedores
        Dim Grabado As Boolean = False
        Select Case Me.Estado
            Case enumEstados.NUEVO, enumEstados.EDICION
                oElemento = New Class_CatVendedores
                Try
                    With oElemento
                        .CODIGO_VENDEDOR = CInt(Me.TxtIDVendedor.Text)
                        .NOMBRE_VENDEDOR = Me.TxtNombreVendedor.Text
                        .Status = Strings.Left(Me.CboEstatus.Text, 1)
                        .CODIGO_CATEGORIA = Me.txtCodigoCategoria.Text
                        .CODIGO_CENTRO_COSTO = CInt(Me.TxtCodigoCentroCosto.Text)

                        Select Case Me.Estado
                            Case enumEstados.NUEVO
                                .GENERAR_CATEGORIA = Me.chkCrearCategoria.Checked
                                .CODIGO_TIPO_CATEGORIA = Me.txtTipoCategoria.Text
                                .Agregar = "1"
                                If .Insertar() = True Then
                                    Grabado = True
                                    Me.Estado = enumEstados.NUEVO
                                End If

                            Case enumEstados.EDICION
                                .GENERAR_CATEGORIA = False
                                .CODIGO_TIPO_CATEGORIA = ""
                                .Agregar = "0"
                                If .Actualizar() = True Then
                                    Grabado = True
                                    Me.Estado = enumEstados.CONSULTA
                                End If
                        End Select

                        If Grabado = True Then
                            MsgBox(Me.msgElemento & " grabado satisfactoriamente.", MsgBoxStyle.Information, Me.Name)
                            Me.Refrescar()
                            Me.Estado = enumEstados.CONSULTA
                            Me.Cambia_Estado()
                        End If

                    End With
                Catch ex As Exception
                    HandleError(Me.Name, "Grabar", ex)
                    Me.Estado = enumEstados.CONSULTA
                    Me.Cambia_Estado()
                Finally
                    oElemento = Nothing
                End Try
        End Select
    End Sub

    Private Function Validar() As Boolean
        Dim bResultado As Boolean = False
        Try
            If txtLEN(Me.TxtNombreVendedor.Text) = False Then
                MsgBox("Capture el nombre del vendedor.", MsgBoxStyle.Exclamation, Me.Text)
                Me.TxtNombreVendedor.Focus()
                Return False
            End If

            Select Case Me.chkCrearCategoria.Checked
                Case False
                    If txtLEN(Me.txtCodigoCategoria.Text) = False Then
                        MsgBox("Seleccione una categoria, en caso de no tener, puede usar la 0.", MsgBoxStyle.Exclamation, Me.Text)
                        Me.txtCodigoCategoria.Focus()
                        Return False
                    End If
                Case True
                    If txtLEN(Me.txtTipoCategoria.Text) = False Then
                        MsgBox("Seleccione el tipo de categoria.", MsgBoxStyle.Exclamation, Me.Text)
                        Me.txtTipoCategoria.Focus()
                        Return False
                    End If
            End Select

            If txtLEN(Me.TxtCodigoCentroCosto.Text) = False Then
                MsgBox("Capture un centro de costo.", MsgBoxStyle.Exclamation, Me.Text)
                Me.TxtCodigoCentroCosto.Focus()
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
        Me.LlenaElemento(CInt(Me.Grid.CurrentRow.Cells("CODIGO_VENDEDOR").Value.ToString))
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
    '        Me.LlenaElemento(CType(Val(0 & Me.lstbElementos.SelectedValue.ToString), Integer))
    '    End If
    'End Sub
#End Region

#Region "Eventos de TxtFiltro"
    Private Sub txtFiltro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFiltro.TextChanged
        Dim oElementos As New Class_CatVendedores
        Me.Grid.DataSource = Nothing
        Me.DesplegarElementos()
    End Sub

    Private Sub txtFiltro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFiltro.KeyPress
        txtNoBeep(e)
        txtNoComilla(e)
    End Sub

    Private Sub txtFiltro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFiltro.KeyDown
        Dim oElementosFiltro As New Class_CatVendedores
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Return Or e.KeyCode = Keys.Back Then
            Me.Grid.DataSource = Nothing
            Me.DesplegarElementos()
        End If
    End Sub
#End Region

#Region "Eventos Genericos"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CboEstatus.KeyPress, TxtNombreVendedor.KeyPress, txtCodigoCategoria.KeyPress, txtTipoCategoria.KeyPress, TxtIDVendedor.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub txt_Keydown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNombreVendedor.KeyDown, CboEstatus.KeyDown, chkCrearCategoria.KeyDown
        If e.KeyCode = Keys.Return Then
            txtTAB(e)
        End If
    End Sub


    Private Sub txtNumerosEnterosKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigoCategoria.KeyPress, txtTipoCategoria.KeyPress, TxtCodigoCentroCosto.KeyPress
        txtSoloNumerosEnteros(e)
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

    Private Sub txtCodigoCategoria_keyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigoCategoria.KeyDown
        Try
            Dim oCategorias As New Class_CatCategorias

            Select Case e.KeyCode
                Case Keys.F6
Buscar:
                    Dim resultado As String
                    resultado = oCategorias.BusquedaVisual_PorDescripcion()
                    Me.txtCodigoCategoria.Text = resultado
                    If txtLEN(resultado) = True Then
                        GoTo Enter : Exit Sub
                    Else
                        Me.lblCategoria.Text = "_"
                    End If

                Case Keys.Return
Enter:
                    If txtLEN(Me.txtCodigoCategoria.Text) = False Then
                        Me.lblCategoria.Text = "_" ': GoTo Buscar : Exit Sub
                        txtTAB(e)
                        Return
                    End If

                    oCategorias = New Class_CatCategorias(Me.txtCodigoCategoria.Text)
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
                        'tsbGrabar.PerformClick()
                    Else
                        Me.lblTipoCategoria.Text = "" : GoTo Buscar : Exit Sub
                    End If

            End Select
        Catch ex As Exception
            HandleError(Me.Name, "txtTipoCategoria_KeyDown", ex)
        End Try
    End Sub

    Private Sub txtCodigoCentroCosto_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCodigoCentroCosto.KeyDown
        Try
            Dim oCentroCosto As New Class_CatCentroCostos

            Select Case e.KeyCode
                Case Keys.F6
Buscar:
                    Dim resultado As String
                    resultado = oCentroCosto.BusquedaVisual_PorDescripcion()
                    Me.TxtCodigoCentroCosto.Text = resultado
                    If txtLEN(resultado) = True Then
                        GoTo Enter : Exit Sub
                    End If

                Case Keys.Return
Enter:
                    If txtLEN(Me.TxtCodigoCentroCosto.Text) = False Then
                        Me.LblNombreCentroCosto.Text = "" : GoTo Buscar : Exit Sub
                    End If

                    oCentroCosto = New Class_CatCentroCostos(CInt(Me.TxtCodigoCentroCosto.Text))
                    If oCentroCosto.EXISTE = True Then
                        Me.LblNombreCentroCosto.Text = oCentroCosto.NOMBRE_CENTRO_COSTO
                        tsbGrabar.PerformClick()
                    Else
                        Me.LblNombreCentroCosto.Text = "" : GoTo Buscar : Exit Sub
                    End If

            End Select
        Catch ex As Exception
            HandleError(Me.Name, "txtCodigoCentroCosto_KeyDown", ex)
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
            Me.txtCodigoCategoria.Visible = False : Me.lblCodigoCategoria.Visible = False : Me.lblCategoria.Visible = False
        Else
            Me.txtTipoCategoria.Visible = False : Me.lblDisplayTipoCategoria.Visible = False : Me.lblTipoCategoria.Visible = False
            Me.txtCodigoCategoria.Visible = True : Me.lblCodigoCategoria.Visible = True : Me.lblCategoria.Visible = True
        End If
    End Sub

#End Region

End Class