Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class Catalogo_Productos
    Private oProducto As New Class_CatProductos

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
            Me.msgElemento = "Propietario"
            Me.msgElementos = "Propietarios"
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
        Me.TxtCodigo.Text = Me.oProducto.CodigoSiguiente.ToString
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
                sMsg = " grabar las modificaciones del " & Me.msgElemento & " : " & Me.TxtCodigo.Text
            Case enumEstados.NUEVO
                sMsg = " agregar el " & Me.msgElemento & " : " & Me.TxtCodigo.Text
        End Select
        sMsg = "Deseas " & sMsg & " ?"
        If MsgBox(sMsg, CType(CInt(MsgBoxStyle.Question) + CInt(MsgBoxStyle.YesNo), MsgBoxStyle)) = MsgBoxResult.Yes Then
            Call Grabar_Elemento()
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
        'Me.oEmpaque.Imprimir_Listado()
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
                Me.tssLabelEstado.Text = "Agregando"
                Me.tsbNuevo.Enabled = False
                Me.tsbEditar.Enabled = False
                Me.tsbGrabar.Enabled = True
                Me.tsbCancelar.Enabled = True

                Me.TxtCodigo.Enabled = False
                Me.TxtNombre.Enabled = True
                Me.TxtLimiteCredito.Enabled = True
                Me.TxtPlazo.Enabled = True
                Me.GridClientes.Enabled = False
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
                Me.TxtLimiteCredito.Enabled = True
                Me.TxtPlazo.Enabled = True
                Me.GridClientes.Enabled = True
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
    End Sub

    Private Sub InicializaElemento()
        Me.TxtCodigo.Text = ""
        Me.TxtNombre.Text = ""
        Me.TxtLimiteCredito.Text = ""
        Me.TxtPlazo.Text = ""
        Me.GridClientes.DataSource = Nothing
        Me.GridProveedores.DataSource = Nothing
    End Sub

    Private Sub DesplegarElementos()
        With Me.Grid
            .DataSource = oProducto.ObtenerElementosFiltro(Me.txtFiltro.Text)
            .Columns("CODIGO_PROPIETARIO").Width = 60
            .Columns("NOMBRE_PROPIETARIO").Width = 500
        End With
    End Sub

    'Private Sub DesplegarClientes()
    '    With Me.GridClientes
    '        .DataSource = oProducto.ObtenerRelacionPropietariosClientes(Me.TxtCodigo.Text)
    '        .Columns("CODIGO_CLIENTE").Width = 60
    '        .Columns("NOMBRE_CLIENTE").Width = 600
    '    End With
    'End Sub

    'Private Sub DesplegarProveedores()
    '    With Me.GridProveedores
    '        .DataSource = oProducto.ObtenerRelacionPropietariosProveedores(Me.TxtCodigo.Text)
    '        .Columns("CODIGO_PROVEEDOR").Width = 60
    '        .Columns("NOMBRE_PROVEEDOR").Width = 600
    '    End With
    'End Sub

    Private Sub LlenaElemento(ByVal sCodigo_Elemento As String)
        Me.oProducto.CODIGO_PRODUCTO = sCodigo_Elemento
        If Me.oProducto.Consultar Then
            With Me.oProducto
                Me.TxtCodigo.Text = .CODIGO_PRODUCTO.ToString
                Me.TxtNombre.Text = .NOMBRE_PRODUCTO.ToString

            End With

            'Me.DesplegarClientes()
            'Me.DesplegarProveedores()

        End If
    End Sub

    Private Sub Grabar_Elemento()
        Dim Grabado As Boolean = False
        Select Case Me.Estado
            Case enumEstados.NUEVO, enumEstados.EDICION
                Try
                    With Me.oProducto
                        .CODIGO_PRODUCTO = Me.TxtCodigo.Text
                        .NOMBRE_PRODUCTO = Me.TxtNombre.Text

                        Select Case Me.Estado
                            Case enumEstados.NUEVO
                                If .Insertar() Then
                                    Grabado = True
                                    Me.Estado = enumEstados.NUEVO
                                End If
                            Case enumEstados.EDICION
                                If .Actualizar() Then
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
                Finally

                End Try
        End Select
    End Sub

    Private Function Validar() As Boolean
        Dim bResultado As Boolean = False
        If txtLEN(Me.TxtNombre.Text) = False Then
            MsgBox("Agregue un nombre al Propietario.", MsgBoxStyle.Exclamation, Me.Text)
            Me.TxtNombre.Focus()
            Return bResultado
        End If

        If txtLEN(Me.TxtLimiteCredito.Text) = False Then
            MsgBox("Capture un límite de crédito.", MsgBoxStyle.Exclamation, Me.Text)
            Me.TxtLimiteCredito.Focus()
            Return bResultado
        End If

        If txtLEN(Me.TxtPlazo.Text) = False Then
            MsgBox("Capture un plazo.", MsgBoxStyle.Exclamation, Me.Text)
            Me.TxtPlazo.Focus()
            Return bResultado
        End If

        bResultado = True
        Return bResultado

    End Function

#End Region

#Region "Eventos de objetos"
#Region "Eventos de la lista de elementos"

    Private Sub Grid_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grid.CellClick
        Me.LlenaElemento(Me.Grid.CurrentRow.Cells("CODIGO_PRODUCTO").Value.ToString)
    End Sub

    Private Sub Grid_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grid.CellDoubleClick
        Me.Estado = enumEstados.EDICION
        Me.Cambia_Estado()
    End Sub
#End Region

#Region " Eventos de TxtFiltro"
    Private Sub txtFiltro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFiltro.TextChanged
        Me.DesplegarElementos()
    End Sub
    Private Sub txtFiltro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFiltro.KeyPress
        txtNoBeep(e)
        txtNoComilla(e)
    End Sub
    Private Sub txtFiltro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFiltro.KeyDown
        Me.DesplegarElementos()
    End Sub
#End Region

#Region "Eventos Genericos"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNombre.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub txt_Keydown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNombre.KeyDown, TxtLimiteCredito.KeyDown
        If e.KeyCode = Keys.Return Then
            txtTAB(e)
        End If
    End Sub

    Private Sub txtPlazo_Keydown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtPlazo.KeyDown
        If e.KeyCode = Keys.Return Then
            tsbGrabar.PerformClick()
        End If
    End Sub

    Private Sub txtNumericos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigo.KeyPress, TxtLimiteCredito.KeyPress
        Dim txt As TextBox = CType(sender, TextBox)
        txtSoloNumerosDecimales(e, txt.Text)
        txtNoBeep(e)
    End Sub

    Private Sub txtNumerosEnterosKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPlazo.KeyPress
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

#End Region

#Region "Validating específicos"

#End Region

    Private Sub CboFiltroHoja_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Refrescar()
    End Sub

#End Region


End Class