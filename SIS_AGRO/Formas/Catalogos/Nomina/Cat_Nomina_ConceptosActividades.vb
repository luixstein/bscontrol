Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class Cat_Nomina_ConceptosActividades
    Private oActividad As New Class_CatConceptosActividades

#Region "Campos"

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

#End Region

#Region "Constructor y destructor"
    'Inicializa al objeto.
    Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Try
            Me.msgElemento = "Actividad"
            Me.msgElementos = "Actividades"
            Me.Run = False
            'Me.lstbElementos.ContextMenuStrip = Me.cMenuStripAccion
            Estado = enumEstados.CONSULTA
            Me.Cambia_Estado()
            Me.DesplegarElementos()
            Me.DesplegarElementosSubActividad()
            Me.Run = True
        Catch ex As Exception
            HandleError(Me.Name, "New", ex)
        End Try
    End Sub



    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
#End Region

#Region "Opciones"
    Private Sub tsbNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbNuevo.Click
        Me.Estado = enumEstados.NUEVO
        Me.Cambia_Estado()
        Me.TxtCodigoConceptoActividad.Text = Me.oActividad.CodigoSiguiente
    End Sub

    Private Sub tsbEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbEditar.Click
        Me.Estado = enumEstados.EDICION
        Me.Cambia_Estado()
    End Sub

    Private Sub tsbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGrabar.Click
        Dim sMsg As String = ""
        Select Case Me.Estado
            Case enumEstados.EDICION
                sMsg = " grabar las modificaciones del " & Me.msgElemento & " : " & Me.TxtCodigoConceptoActividad.Text
            Case enumEstados.NUEVO
                sMsg = " agregar el " & Me.msgElemento & " : " & Me.TxtCodigoConceptoActividad.Text
        End Select
        sMsg = "Deseas " & sMsg & " ?"
        If MsgBox(sMsg, CType(CInt(MsgBoxStyle.Question) + CInt(MsgBoxStyle.YesNo), MsgBoxStyle)) = MsgBoxResult.Yes Then
            Me.Grabar_Elemento()
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
        Me.oActividad.Imprimir_Listado()
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

                Me.TxtCodigoConceptoActividad.Enabled = False
                Me.TxtDescripcion.Enabled = True
                Me.CboEstatus.Enabled = False
                Me.InicializaElemento()
                Me.TxtCodigoConceptoActividad.Focus()
                Me.btnAgregaSubActividad.Enabled = False
                Me.btnEditarSubActividad.Enabled = False
                Me.lstbSubActividades.DataSource = Nothing

            Case enumEstados.EDICION
                Me.gBoxInformacion.Enabled = True
                Me.gBoxBusquedaRapida.Enabled = False
                Me.tssLabelEstado.Text = "Edición"
                Me.tsbNuevo.Enabled = False
                Me.tsbEditar.Enabled = False
                Me.tsbGrabar.Enabled = True
                Me.tsbCancelar.Enabled = True

                Me.TxtCodigoConceptoActividad.Enabled = False
                Me.TxtDescripcion.Enabled = True
                Me.CboEstatus.Enabled = True
                Me.TxtDescripcion.Focus()
                Me.btnAgregaSubActividad.Enabled = True
                Me.btnEditarSubActividad.Enabled = True

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
        Me.TxtCodigoConceptoActividad.Text = ""
        Me.TxtDescripcion.Text = ""
        Me.CboEstatus.SelectedIndex = 0
    End Sub

    Private Sub DesplegarElementos()
        With Me.Grid
            .DataSource = oActividad.ObtenerElementos
            .Columns("CODIGO_CONCEPTO_ACTIVIDAD").Width = 50
            .Columns("NOMBRE_CONCEPTO_ACTIVIDAD").Width = 200
        End With
    End Sub

    Private Sub DesplegarElementosSubActividad()
        Dim oSubActividades As New Class_CatActividades
        With Me.lstbSubActividades
            .DisplayMember = "NOMBRE_ACTIVIDAD"
            .ValueMember = "CODIGO_ACTIVIDAD"
            Dim dView As Data.DataView
            If Me.Run = False Then
                If Me.Grid.Rows.Count > 0 Then
                    dView = New Data.DataView(oSubActividades.ObtenerElementosSubActividades(Me.Grid.Item(0, 0).Value.ToString)) 'Envia el primer codigo_concepto_actividad de la lista del grid
                End If
            Else
                dView = New Data.DataView(oSubActividades.ObtenerElementosSubActividades(Me.Grid.CurrentRow.Cells("CODIGO_CONCEPTO_ACTIVIDAD").Value.ToString))
            End If

            If IsNothing(dView) = False Then
                dView.Sort = "NOMBRE_ACTIVIDAD"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedIndex = -1
                End If
            End If

        End With
    End Sub

    Private Sub LlenaElemento(ByVal sCodigo_Elemento As String)
        Dim sCodigo As String
        Me.oActividad.CODIGO_CONCEPTO_ACTIVIDAD = sCodigo_Elemento
        If Me.oActividad.Consultar Then
            With Me.oActividad
                sCodigo = "000" + sCodigo_Elemento
                Me.TxtCodigoConceptoActividad.Text = sCodigo.Substring(Len(sCodigo) - 3).ToString
                Me.TxtDescripcion.Text = .NOMBRE_CONCEPTO_ACTIVIDAD.ToString
                Me.DesplegarElementosSubActividad()
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

        If txtLEN(Me.TxtDescripcion.Text) = False Then
            MsgBox("Asigne un nombre a la actividad.", MsgBoxStyle.Exclamation, Me.Name)
            Exit Sub
        End If

        Select Case Me.Estado
            Case enumEstados.NUEVO, enumEstados.EDICION
                Me.oActividad = New Class_CatConceptosActividades
                Try
                    With Me.oActividad
                        .CODIGO_CONCEPTO_ACTIVIDAD = Me.TxtCodigoConceptoActividad.Text
                        .NOMBRE_CONCEPTO_ACTIVIDAD = Me.TxtDescripcion.Text
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
                                    Me.Estado = enumEstados.CONSULTA
                                End If
                        End Select

                        If Grabado Then
                            MsgBox(Me.msgElemento & " Grabado satisfactoriamente.", MsgBoxStyle.Information, Me.Name)
                            Me.Refrescar()
                            Me.Cambia_Estado()
                            If Me.Estado = enumEstados.NUEVO Then
                                Me.TxtCodigoConceptoActividad.Text = .CodigoSiguiente.ToString
                            End If
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

    Private Sub btnAgregaSubActividad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregaSubActividad.Click
        Dim Child As New Cat_Nomina_Actividades
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.txtConcepto.Text = Me.TxtDescripcion.Text
        Child.CodigoConcepto = Me.TxtCodigoConceptoActividad.Text
        Child.ChildParaGrabar = True
        Child.ShowDialog()
        Child.Dispose()
        Me.DesplegarElementosSubActividad()
    End Sub

    Private Sub btnEditarSubActividad_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEditarSubActividad.Click
        If CInt(Me.lstbSubActividades.SelectedValue) > 0 Then
            Dim Child As New Cat_Nomina_Actividades
            Child.StartPosition = FormStartPosition.CenterScreen
            Child.txtConcepto.Text = Me.TxtDescripcion.Text
            Child.CodigoConcepto = Me.TxtCodigoConceptoActividad.Text
            'Child.txtCodigoConcepto.Text = Me.TxtCodigoConceptoActividad.Text
            Child.TxtCodigoActividad.Text = Me.lstbSubActividades.SelectedValue.ToString
            Child.ChildParaGrabar = False
            Child.ShowDialog()
            Child.Dispose()
            Me.DesplegarElementosSubActividad()
        Else
            MsgBox("Seleccione una sub-actividad.", MsgBoxStyle.Exclamation, Me.Name)
            Exit Sub
        End If
    End Sub

#End Region

#Region "Eventos de objetos"
#Region "Eventos de la lista de elementos"
    Private Sub Grid_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grid.CellClick
        Me.LlenaElemento(Me.Grid.CurrentRow.Cells("CODIGO_CONCEPTO_ACTIVIDAD").Value.ToString)
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
            .DataSource = oActividad.ObtenerElementosFiltro(Me.txtFiltro.Text)
            .Columns("CODIGO_CONCEPTO_ACTIVIDAD").Width = 50
            .Columns("NOMBRE_CONCEPTO_ACTIVIDAD").Width = 200
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
                .DataSource = oActividad.ObtenerElementosFiltro(Me.txtFiltro.Text)
                .Columns("CODIGO_CONCEPTO_ACTIVIDAD").Width = 50
                .Columns("NOMBRE_CONCEPTO_ACTIVIDAD").Width = 200
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
    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CboEstatus.KeyPress, TxtDescripcion.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub txt_Keydown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDescripcion.KeyDown
        If e.KeyCode = Keys.Return Then
            Select Case Me.Estado
                Case enumEstados.EDICION
                    SendKeys.Send("{TAB}")
                Case enumEstados.NUEVO
                    SendKeys.Send("{TAB}")
            End Select
        End If
    End Sub

    Private Sub txtNumericos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigoConceptoActividad.KeyPress
        Dim txt As TextBox = CType(sender, TextBox)
        txtNoBeep(e)
    End Sub

    Private Sub txtNumerosEnterosKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigoConceptoActividad.KeyPress
        txtSoloNumerosEnteros(e)
        txtNoBeep(e)
    End Sub

    Private Sub txtNumericos_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        Dim t As TextBox
        t = CType(sender, TextBox)
        If Not IsNumeric(t.Text) Then
            t.Text = Val(t.Text).ToString
        Else
            'Me.ErrorProvider.Clear()
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