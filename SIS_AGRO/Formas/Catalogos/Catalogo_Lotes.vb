Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Public Class Catalogo_Lotes
    Private oLote As New Class_CatLotes

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
            Me.msgElemento = "Lote"
            Me.msgElementos = "Lotes"
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
        Me.TxtCodigo.Text = Me.oLote.CodigoSiguiente
    End Sub

    Private Sub tsbEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbEditar.Click
        Me.Estado = enumEstados.EDICION
        Me.Cambia_Estado()
    End Sub

    Private Sub tsbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGrabar.Click
        Dim sMsg As String = ""
        Select Case Me.Estado
            Case enumEstados.EDICION
                sMsg = " grabar las modificaciones del " & Me.msgElemento & " : " & Me.TxtCodigo.Text
            Case enumEstados.NUEVO
                sMsg = " agregar el " & Me.msgElemento & " : " & Me.TxtCodigo.Text
        End Select
        sMsg = "Deseas " & sMsg & " ?"

        If Me.Validar() = False Then
            Exit Sub
        End If

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
        Me.oLote.Imprimir_Listado()
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

                Me.TxtCodigo.Enabled = False
                Me.TxtNombre.Enabled = True
                Me.CboEstatus.Enabled = False
                Me.txtColindancia.Enabled = True
                Me.txtHectareas.Enabled = True
                Me.TxtLatitud.Enabled = True
                Me.TxtLongitud.Enabled = True

                Me.InicializaElemento()
                Me.TxtNombre.Focus()

            Case enumEstados.EDICION
                Me.gBoxInformacion.Enabled = True
                Me.gBoxBusquedaRapida.Enabled = False
                Me.tssLabelEstado.Text = "Edición"
                Me.tsbNuevo.Enabled = False
                Me.tsbEditar.Enabled = False
                Me.tsbGrabar.Enabled = True
                Me.tsbCancelar.Enabled = True

                Me.TxtCodigo.Enabled = False
                Me.TxtNombre.Enabled = True
                Me.CboEstatus.Enabled = True
                Me.txtColindancia.Enabled = True
                Me.txtHectareas.Enabled = True
                Me.TxtLatitud.Enabled = True
                Me.TxtLongitud.Enabled = True

                Me.TxtNombre.Focus()

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
        Me.TxtCodigo.Text = ""
        Me.TxtNombre.Text = ""
        Me.CboEstatus.SelectedIndex = 0
    End Sub

    Private Sub DesplegarElementos()
        With Me.Grid
            .DataSource = oLote.ObtenerElementosFiltro(Me.txtFiltro.Text, Me.cboEstatusFiltro.Text)
            .Columns("CODIGO_LOTE").Width = 100
            .Columns("NOMBRE_LOTE").Width = 250
        End With
    End Sub

    Private Sub LlenaElemento(ByVal sCodigo_Elemento As String)
        Me.oLote.Codigo_Lote = sCodigo_Elemento
        If Me.oLote.Consultar Then
            With Me.oLote
                Me.TxtCodigo.Text = .Codigo_Lote.ToString
                Me.TxtNombre.Text = .Nombre_Lote.ToString
                Me.txtColindancia.Text = .Colindancia.ToString
                Me.txtHectareas.Text = .Hectareas.ToString
                Me.TxtLatitud.Text = .Latitud.ToString
                Me.TxtLongitud.Text = .Longitud.ToString
                If .Estatus = "A" Then
                    Me.CboEstatus.SelectedIndex = 0
                Else
                    Me.CboEstatus.SelectedIndex = 1
                End If

            End With
        End If
    End Sub

    Private Sub Grabar_Elemento()
        Dim Grabado As Boolean = False
        Select Case Me.Estado
            Case enumEstados.NUEVO, enumEstados.EDICION
                Try
                    With Me.oLote
                        .Codigo_Lote = Me.TxtCodigo.Text
                        .Nombre_Lote = Me.TxtNombre.Text
                        .Colindancia = Me.txtColindancia.Text
                        .Hectareas = Me.txtHectareas.Text
                        .Latitud = Me.TxtLatitud.Text
                        .Longitud = Me.TxtLongitud.Text
                        .Estatus = Strings.Left(Me.CboEstatus.Text, 1)
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
            MsgBox("Agregue un nombre al lote", MsgBoxStyle.Exclamation)
            Me.TxtNombre.Focus()
            Return bResultado
        End If

        If txtLEN(Me.txtColindancia.Text) = False Then
            MsgBox("Agregue la colindancia", MsgBoxStyle.Exclamation)
            Me.txtColindancia.Focus()
            Return bResultado
        End If

        If txtLEN(Me.txtHectareas.Text) = False Then
            MsgBox("Agregue un numero de hectareas", MsgBoxStyle.Exclamation)
            Me.txtHectareas.Focus()
            Return bResultado
        End If

        bResultado = True

        Return bResultado
    End Function

#End Region

#Region "Eventos de objetos"
#Region "Eventos de la lista de elementos"
    Private Sub Grid_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grid.CellClick
        Me.LlenaElemento(Me.Grid.CurrentRow.Cells("CODIGO_LOTE").Value.ToString)
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
            .DataSource = oLote.ObtenerElementosFiltro(Me.txtFiltro.Text, Me.cboEstatusFiltro.Text)
            .Columns("CODIGO_LOTE").Width = 50
            .Columns("NOMBRE_LOTE").Width = 200
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
                .DataSource = oLote.ObtenerElementosFiltro(Me.txtFiltro.Text, Me.cboEstatusFiltro.Text)
                .Columns("CODIGO_LOTE").Width = 50
                .Columns("NOMBRE_LOTE").Width = 200
            End With
        End If
    End Sub

    Private Sub cboEstatusFiltro_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEstatusFiltro.SelectedIndexChanged
        Me.Grid.DataSource = Nothing

        With Me.Grid
            .DataSource = oLote.ObtenerElementosFiltro(Me.txtFiltro.Text, Me.cboEstatusFiltro.Text)
            .Columns("CODIGO_LOTE").Width = 50
            .Columns("NOMBRE_LOTE").Width = 200
        End With
    End Sub
#End Region

#Region "Eventos Genericos"

    Private Sub CboEstatus_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CboEstatus.KeyDown
        If e.KeyCode = Keys.Return Then
            tsbGrabar.PerformClick()
        End If
    End Sub
    Private Sub txtLongitud_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtLongitud.KeyDown
        If e.KeyCode = Keys.Return Then
            Select Case Me.Estado
                Case enumEstados.NUEVO
                    tsbGrabar.PerformClick()
                Case enumEstados.EDICION
                    SendKeys.Send("{TAB}")
            End Select
        End If
    End Sub
    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CboEstatus.KeyPress, TxtNombre.KeyPress, txtColindancia.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub txt_Keydown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNombre.KeyDown, txtColindancia.KeyDown, txtHectareas.KeyDown, TxtLatitud.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtNumericos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigo.KeyPress, txtHectareas.KeyPress
        Dim txt As TextBox = CType(sender, TextBox)
        txtSoloNumerosDecimales(e, txt.Text)
        txtNoBeep(e)
    End Sub

    Private Sub Coordenadas_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtLatitud.KeyPress, TxtLongitud.KeyPress
        Dim txt As TextBox = CType(sender, TextBox)
        Dim resultado As Boolean = False

        If (Not (System.Char.IsDigit(e.KeyChar)) AndAlso Not (System.Char.IsControl(e.KeyChar)) AndAlso e.KeyChar <> "." AndAlso e.KeyChar <> "-") Then
            resultado = True
        End If

        If e.KeyChar = "." AndAlso CBool(InStr(txt.Text, ".")) Then
            resultado = True
        End If

        If e.KeyChar = "-" Then
            If CBool(InStr(txt.Text, "-")) Or txtLEN(txt.Text) = True Then
                resultado = True
            End If

        End If

        e.Handled = resultado
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