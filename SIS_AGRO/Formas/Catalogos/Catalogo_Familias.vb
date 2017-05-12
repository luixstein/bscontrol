Option Strict On

Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class Catalogo_Familias
    Private oFamilias As New Class_CatFamilias

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
            Me.msgElemento = "Familia"
            Me.msgElementos = "Familias"
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
        'Me.TxtCodigoFamilia.Text = Me.oFamilias.CodigoSiguiente'No se ocupa mostrar un código, es un elemento nuevo
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
        sMsg = "Deseas " & sMsg & Me.msgElemento & " : " & Me.TxtNombreFamilia.Text & " ?"
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
        Me.oFamilias.Imprimir_Listado()
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
                    Me.tssLabelEstado.Text = "Agregando nueva " & Me.msgElemento
                    Me.tsbNuevo.Enabled = False
                    Me.tsbEditar.Enabled = False
                    Me.tsbGrabar.Enabled = True
                    Me.tsbCancelar.Enabled = True

                    Me.TxtCodigoFamilia.Enabled = False
                    Me.TxtNombreFamilia.Enabled = True
                    Me.CboEstatus.Enabled = False
                    Me.txtCodigoCategoria.Text = ""

                    Me.InicializaElemento()

                    Me.chkCrearCategoria.Visible = True : Me.chkCrearCategoria.Checked = False : Me.chkCrearCategoria.Checked = True 'esta como false y true para forzar a que hay cambio y se ejecute el evento del check

                    Me.TxtNombreFamilia.Focus()

                Case enumEstados.EDICION
                    Me.gBoxInformacion.Enabled = True
                    Me.gBoxBusquedaRapida.Enabled = False
                    Me.tssLabelEstado.Text = "Edición"
                    Me.tsbNuevo.Enabled = False
                    Me.tsbEditar.Enabled = False
                    Me.tsbGrabar.Enabled = True
                    Me.tsbCancelar.Enabled = True

                    Me.TxtCodigoFamilia.Enabled = False
                    Me.TxtNombreFamilia.Enabled = True
                    Me.CboEstatus.Enabled = True

                    Me.chkCrearCategoria.Visible = False : Me.chkCrearCategoria.Checked = True : Me.chkCrearCategoria.Checked = False

                    Me.TxtNombreFamilia.Focus()

                Case enumEstados.CONSULTA
                    Me.gBoxInformacion.Enabled = False
                    Me.gBoxBusquedaRapida.Enabled = True
                    Me.tssLabelEstado.Text = "Consulta"
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
        Me.TxtCodigoFamilia.Text = ""
        Me.TxtNombreFamilia.Text = ""
        Me.CboEstatus.SelectedIndex = 0
        Me.txtCodigoCategoria.Text = ""
        Me.lblCategoria.Text = "_"
        Me.txtTipoCategoria.Text = ""
        Me.lblTipoCategoria.Text = ""
        Me.chkCrearCategoria.Checked = False
    End Sub

    Private Sub DesplegarElementos()
        Try
            With Me.Grid
                .DataSource = oFamilias.ObtenerElementosFiltro(Me.txtFiltro.Text, Me.cboEstatusFiltro.Text)
                .Columns("CODIGO_FAMILIA").Width = 50
                .Columns("NOMBRE_FAMILIA").Width = 300
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarElementos", ex)
        End Try
    End Sub

    Private Sub LlenaElemento(ByVal sCodigo_Elemento As String)
        Try
            Me.oFamilias.Codigo_Familia = sCodigo_Elemento
            If Me.oFamilias.Consultar = True Then
                With Me.oFamilias
                    Me.TxtCodigoFamilia.Text = .Codigo_Familia.ToString
                    Me.TxtNombreFamilia.Text = .Nombre_Familia.ToString
                    If .Estatus = "A" Then
                        Me.CboEstatus.SelectedIndex = 0
                    Else
                        Me.CboEstatus.SelectedIndex = 1
                    End If
                    Me.txtCodigoCategoria.Text = .CODIGO_CATEGORIA
                End With
                Dim oCategoria As New Class_CatCategorias
                oCategoria.CODIGO_CATEGORIA = Me.txtCodigoCategoria.Text
                If oCategoria.Consultar() = True Then
                    Me.lblCategoria.Text = oCategoria.NOMBRE_CATEGORIA
                End If
            End If
        Catch ex As Exception
            HandleError(Me.Name, "LlenaElemento", ex)
        End Try
    End Sub

    Private Sub Grabar()
        Dim Grabado As Boolean = False
        Try
            Select Case Me.Estado
                Case enumEstados.NUEVO, enumEstados.EDICION
                    With Me.oFamilias
                        .Codigo_Familia = Me.TxtCodigoFamilia.Text
                        .Nombre_Familia = Me.TxtNombreFamilia.Text
                        .Estatus = Strings.Left(Me.CboEstatus.Text, 1)
                        .CODIGO_CATEGORIA = Me.txtCodigoCategoria.Text

                        Select Case Me.Estado
                            Case enumEstados.NUEVO
                                Me.oFamilias = New Class_CatFamilias

                                .GENERAR_CATEGORIA = Me.chkCrearCategoria.Checked
                                .CODIGO_TIPO_CATEGORIA = Me.txtTipoCategoria.Text

                                If .Insertar() = True Then
                                    Grabado = True
                                    Me.Estado = enumEstados.NUEVO
                                End If

                            Case enumEstados.EDICION
                                Me.oFamilias = New Class_CatFamilias(Me.TxtCodigoFamilia.Text)

                                If .Nombre_Familia.ToUpper <> Me.TxtNombreFamilia.Text.ToUpper Then
                                    If MsgBox("Modificó el nombre de la familia, automáticamente el sistema cambiará los nombres de las subcuentas contables por cada almacén." & vbCrLf & _
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
                            MsgBox(Me.msgElemento & " grabada satisfactoriamente.", MsgBoxStyle.Information, Me.Text)
                            Me.Refrescar()
                            Me.Cambia_Estado()
                        End If

                    End With

            End Select
        Catch ex As Exception
            HandleError(Me.Name, "Grabar", ex)
            Me.Estado = enumEstados.CONSULTA
            Me.Cambia_Estado()
        End Try
    End Sub

    Private Function Validar() As Boolean
        Dim bResultado As Boolean = False
        Try
            If txtLEN(Me.TxtNombreFamilia.Text) = False Then
                MsgBox("Captúre el nombre de la familia.", MsgBoxStyle.Exclamation, Me.Text)
                Me.TxtNombreFamilia.Focus()
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
        Me.LlenaElemento(Me.Grid.CurrentRow.Cells("CODIGO_FAMILIA").Value.ToString)
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
    '        Me.LlenaElemento(CType(Val(0 & Me.lstbElementos.SelectedValue.ToString), String))
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
    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CboEstatus.KeyPress, TxtNombreFamilia.KeyPress, txtCodigoCategoria.KeyPress, TxtCodigoFamilia.KeyPress, txtTipoCategoria.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub txt_Keydown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNombreFamilia.KeyDown, CboEstatus.KeyDown, chkCrearCategoria.KeyDown
        If e.KeyCode = Keys.Return Then
            txtTAB(e)
        End If
    End Sub

    Private Sub txtNumerosEnterosKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigoCategoria.KeyPress, txtTipoCategoria.KeyPress
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
                        Me.lblCategoria.Text = oCategorias.Nombre_Categoria
                    Else
                        Me.lblCategoria.Text = "_" : GoTo Buscar : Exit Sub
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
            Me.txtCodigoCategoria.Visible = False : Me.LblCodigoCategoria.Visible = False : Me.lblCategoria.Visible = False
        Else
            Me.txtTipoCategoria.Visible = False : Me.lblDisplayTipoCategoria.Visible = False : Me.lblTipoCategoria.Visible = False
            Me.txtCodigoCategoria.Visible = True : Me.LblCodigoCategoria.Visible = True : Me.lblCategoria.Visible = True
        End If
    End Sub

#End Region

End Class