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
        Dim sMsg As String = ""
        If ValidarCategoria() = True Then
            Select Case Me.Estado
                Case enumEstados.EDICION
                    sMsg = " grabar las modificaciones del " & Me.msgElemento & " : " & Me.TxtIDVendedor.Text
                Case enumEstados.NUEVO
                    sMsg = " agregar el " & Me.msgElemento & " : " & Me.TxtNombreVendedor.Text
            End Select
            sMsg = "Deseas " & sMsg & " ?"
            If MsgBox(sMsg, CType(CInt(MsgBoxStyle.Question) + CInt(MsgBoxStyle.YesNo), MsgBoxStyle)) = MsgBoxResult.Yes Then
                Call Grabar_Elemento()
            End If
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
        Select Case Me.Estado
            Case enumEstados.NUEVO
                Me.gBoxInformacion.Enabled = True
                Me.gBoxBusquedaRapida.Enabled = False
                Me.tssLabelEstado.Text = "Agregando nuevo " & Me.msgElemento
                Me.tsbNuevo.Enabled = False
                Me.tsbEditar.Enabled = False
                Me.tsbGrabar.Enabled = True
                Me.tsbCancelar.Enabled = True

                Me.TxtIDVendedor.Enabled = False
                Me.TxtNombreVendedor.Enabled = True
                Me.CboEstatus.Enabled = False
                Me.txtCodigoCategoria.Enabled = True

                Me.InicializaElemento()
                Me.TxtIDVendedor.Text = oVentas.codigoSiguiente.ToString
                TxtNombreVendedor.Focus()
            Case enumEstados.EDICION
                Me.gBoxInformacion.Enabled = True
                Me.gBoxBusquedaRapida.Enabled = False
                Me.tssLabelEstado.Text = "Edición"
                Me.tsbNuevo.Enabled = False
                Me.tsbEditar.Enabled = False
                Me.tsbGrabar.Enabled = True
                Me.tsbCancelar.Enabled = True


                Me.TxtIDVendedor.Enabled = False
                Me.TxtNombreVendedor.Enabled = True
                Me.CboEstatus.Enabled = True
                Me.txtCodigoCategoria.Enabled = True
                TxtNombreVendedor.Focus()

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
        Me.TxtIDVendedor.Text = ""
        Me.TxtNombreVendedor.Text = ""
        Me.CboEstatus.SelectedIndex = 0
        Me.txtCodigoCategoria.Text = ""
        Me.LblNombreCategoria.Text = ""
    End Sub


    Private Sub DesplegarElementos()
        Dim oElementos As New Class_CatVendedores
        With Me.Grid
            .DataSource = oElementos.ObtenerElementos
            .Columns("CODIGO_VENDEDOR").Width = 30
            .Columns("NOMBRE_VENDEDOR").Width = 300
        End With

    End Sub

    Private Sub LlenaElemento(ByVal iCodigo_Elemento As Integer)
        Dim oElemento As New Class_CatVendedores
        oElemento.Codigo_Vendedor = iCodigo_Elemento
        If oElemento.Consultar Then
            With oElemento
                Me.TxtIDVendedor.Text = .Codigo_Vendedor.ToString
                Me.TxtNombreVendedor.Text = .Nombre_Vendedor.ToString
                If .Status = "A" Then
                    Me.CboEstatus.SelectedIndex = 0
                Else
                    Me.CboEstatus.SelectedIndex = 1
                End If
                Me.txtCodigoCategoria.Text = .Codigo_Categoria
                Dim sql As New Class_find("Select NOMBRE_CATEGORIA From CAT_CATEGORIAS Where CODIGO_CATEGORIA='" & Me.txtCodigoCategoria.Text & "' ")
                If sql.Result1 = "" Then
                Else
                    LblNombreCategoria.Text = sql.Result1
                End If

            End With
        End If
        oElemento = Nothing
    End Sub

    Private Sub Grabar_Elemento()
        Dim oElemento As New Class_CatVendedores
        Dim Grabado As Boolean = False
        Select Case Me.Estado
            Case enumEstados.NUEVO, enumEstados.EDICION
                oElemento = New Class_CatVendedores
                Try
                    With oElemento
                        .Codigo_Vendedor = CInt(Me.TxtIDVendedor.Text)
                        .Nombre_Vendedor = Me.TxtNombreVendedor.Text
                        .Status = Strings.Left(Me.CboEstatus.Text, 1)
                        .Codigo_Categoria = Me.txtCodigoCategoria.Text

                        Select Case Me.Estado
                            Case enumEstados.NUEVO
                                .Agregar = "1"
                                If .Insertar() Then
                                    Grabado = True
                                    Me.Estado = enumEstados.NUEVO

                                End If
                            Case enumEstados.EDICION
                                .Agregar = "0"
                                If .Actualizar() Then
                                    Grabado = True
                                    Me.Estado = enumEstados.CONSULTA
                                End If
                        End Select

                        If Grabado Then
                            MsgBox(Me.msgElemento & " Grabado satisfactoriamente.", MsgBoxStyle.Information, Me.Name)
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

    Private Function ValidarCategoria() As Boolean
        Try
            If txtLEN(Me.txtCodigoCategoria.Text) = True Then
                Dim sql As New Class_find("SELECT 1 FROM CAT_CATEGORIAS WHERE CODIGO_CATEGORIA =" & Me.txtCodigoCategoria.Text & " AND ESTATUS='A'")
                If sql.Result1 = "1" Then
                    Return True
                Else
                    MsgBox("La categoria debe de tener estatus A", MsgBoxStyle.Exclamation)
                    Me.txtCodigoCategoria.Focus()
                    Exit Function
                End If
            Else
                MsgBox("Ingrese un codigo de Categoria.", MsgBoxStyle.Exclamation, Me.Text)
                Me.txtCodigoCategoria.Focus()
                Exit Function
            End If

        Catch ex As Exception
            HandleError(Me.Name, "ValidarCategoria", ex)
        End Try
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

#Region " Eventos de TxtFiltro"
    Private Sub txtFiltro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFiltro.TextChanged
        Dim oElementos As New Class_CatVendedores
        Me.Grid.DataSource = Nothing

        With Me.Grid
            .DataSource = oElementos.ObtenerElementosFiltro(Me.txtFiltro.Text)
            .Columns("CODIGO_VENDEDOR").Width = 30
            .Columns("NOMBRE_VENDEDOR").Width = 300
        End With
    End Sub
    Private Sub txtFiltro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFiltro.KeyPress
        txtNoBeep(e)
        txtNoComilla(e)
    End Sub
    Private Sub txtFiltro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFiltro.KeyDown
        Dim oElementosFiltro As New Class_CatVendedores
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Return Or e.KeyCode = Keys.Back Then
            Me.Grid.DataSource = Nothing

            With Me.Grid
                .DataSource = oElementosFiltro.ObtenerElementosFiltro(Me.txtFiltro.Text)
                .Columns("CODIGO_VENDEDOR").Width = 30
                .Columns("NOMBRE_VENDEDOR").Width = 300
            End With
        End If
    End Sub
#End Region

#Region "Eventos Genericos"

    Private Sub CboEstatus_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CboEstatus.KeyDown
        If e.KeyCode = Keys.Return Then
            tsbGrabar.PerformClick()
        End If
    End Sub
    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CboEstatus.KeyPress, TxtNombreVendedor.KeyPress, txtCodigoCategoria.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub txt_Keydown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNombreVendedor.KeyDown
        If e.KeyCode = Keys.Return Then
            Select Case Me.Estado
                Case enumEstados.EDICION
                    SendKeys.Send("{TAB}")
                Case enumEstados.NUEVO
                    SendKeys.Send("{TAB}")
            End Select
        End If
    End Sub

    Private Sub cbo_Keydown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Return Then
            Select Case Me.Estado
                Case enumEstados.EDICION
                    SendKeys.Send("{TAB}")
                Case enumEstados.NUEVO
                    tsbGrabar.PerformClick()
            End Select
        End If
    End Sub

    Private Sub txtNumericos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtIDVendedor.KeyPress
        Dim txt As TextBox = CType(sender, TextBox)
        txtSoloNumerosDecimales(e, txt.Text)
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
    Private Sub TxtCodigoCategoria_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCodigoCategoria.KeyDown
        Dim oCategorias As New Class_CatCategorias
        Select Case e.KeyCode
            Case Keys.F6
busca:
                Me.txtCodigoCategoria.Text = oCategorias.BusquedaVisual_PorDescripcion
                oCategorias.Codigo_Categoria = Me.txtCodigoCategoria.Text
                oCategorias.Consultar()
                Me.LblNombreCategoria.Text = oCategorias.Nombre_Categoria
            Case Keys.Enter
                oCategorias.Codigo_Categoria = Me.txtCodigoCategoria.Text
                If oCategorias.Consultar() = False Then
                    GoTo busca
                End If
                Me.LblNombreCategoria.Text = oCategorias.Nombre_Categoria
        End Select
        txtTAB(e)
    End Sub
#End Region

#Region "Validating específicos"

#End Region

    Private Sub CboFiltroHoja_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Refrescar()
    End Sub

#End Region


End Class