Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class Cat_Nomina_UnidadMedicaFamiliar
    Private oUnidadMedica As New Class_CatUnidadMedicaFamiliar

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
            Me.msgElemento = "Unidad medica familiar"
            Me.msgElementos = "Unidades medicas familiares"
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
        MyBase.Finalize()
    End Sub


#End Region

#Region "Opciones"
    Private Sub tsbNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbNuevo.Click
        Me.Estado = enumEstados.NUEVO
        Me.Cambia_Estado()
        Me.TxtCodigoUnidadMedica.Text = Me.oUnidadMedica.CodigoSiguiente
    End Sub

    Private Sub tsbEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbEditar.Click
        Me.Estado = enumEstados.EDICION
        Me.Cambia_Estado()
    End Sub

    Private Sub tsbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGrabar.Click
        Dim sMsg As String = ""
        Select Case Me.Estado
            Case enumEstados.EDICION
                sMsg = " grabar las modificaciones del " & Me.msgElemento & " : " & Me.TxtCodigoUnidadMedica.Text
            Case enumEstados.NUEVO
                sMsg = " agregar el " & Me.msgElemento & " : " & Me.TxtCodigoUnidadMedica.Text
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
        Me.oUnidadMedica.Imprimir_Listado()
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

                Me.TxtCodigoUnidadMedica.Enabled = True
                Me.TxtNombreUnidadMedica.Enabled = True
                Me.CboEstatus.Enabled = False
                Me.InicializaElemento()
                Me.TxtCodigoUnidadMedica.Focus()

            Case enumEstados.EDICION
                Me.gBoxInformacion.Enabled = True
                Me.gBoxBusquedaRapida.Enabled = False
                Me.tssLabelEstado.Text = "Edición"
                Me.tsbNuevo.Enabled = False
                Me.tsbEditar.Enabled = False
                Me.tsbGrabar.Enabled = True
                Me.tsbCancelar.Enabled = True

                Me.TxtCodigoUnidadMedica.Enabled = False
                Me.TxtNombreUnidadMedica.Enabled = True
                Me.CboEstatus.Enabled = True
                Me.TxtNombreUnidadMedica.Focus()

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
        Me.TxtCodigoUnidadMedica.Text = ""
        Me.TxtNombreUnidadMedica.Text = ""
        Me.CboEstatus.Text = "A"
    End Sub

    Private Sub DesplegarElementos()
        With Me.Grid
            .DataSource = oUnidadMedica.ObtenerElementos
            .Columns("CODIGO_UNIDAD_MEDICA_FAMILIAR").Width = 50
            .Columns("NOMBRE_UNIDAD_MEDICA_FAMILIAR").Width = 200
        End With
    End Sub

    Private Sub LlenaElemento(ByVal iCodigo_Elemento As String)
        Dim sCodigo As String
        Me.oUnidadMedica.CODIGO_UNIDAD_MEDICA_FAMILIAR = CInt(iCodigo_Elemento)
        If Me.oUnidadMedica.Consultar Then
            With Me.oUnidadMedica
                sCodigo = "000" + iCodigo_Elemento
                Me.TxtCodigoUnidadMedica.Text = sCodigo.Substring(Len(sCodigo) - 3).ToString
                Me.TxtNombreUnidadMedica.Text = .NOMBRE_UNIDAD_MEDICA_FAMILIAR.ToString
                Me.CboEstatus.Text = .Estatus
            End With
        End If
    End Sub

    Private Sub Grabar_Elemento()
        Dim Grabado As Boolean = False
        Select Case Me.Estado
            Case enumEstados.NUEVO, enumEstados.EDICION
                Me.oUnidadMedica = New Class_CatUnidadMedicaFamiliar
                Try
                    With Me.oUnidadMedica
                        .CODIGO_UNIDAD_MEDICA_FAMILIAR = CInt(Me.TxtCodigoUnidadMedica.Text)
                        .NOMBRE_UNIDAD_MEDICA_FAMILIAR = Me.TxtNombreUnidadMedica.Text
                        .Estatus = Me.CboEstatus.Text
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

#End Region

#Region "Eventos de objetos"
#Region "Eventos de la lista de elementos"
    Private Sub Grid_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grid.CellClick
        Me.LlenaElemento(Me.Grid.CurrentRow.Cells("CODIGO_UNIDAD_MEDICA_FAMILIAR").Value.ToString)
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
            .DataSource = oUnidadMedica.ObtenerElementosFiltro(Me.txtFiltro.Text)
            .Columns("CODIGO_UNIDAD_MEDICA_FAMILIAR").Width = 50
            .Columns("NOMBRE_UNIDAD_MEDICA_FAMILIAR").Width = 200
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
                .DataSource = oUnidadMedica.ObtenerElementosFiltro(Me.txtFiltro.Text)
                .Columns("CODIGO_UNIDAD_MEDICA_FAMILIAR").Width = 50
                .Columns("NOMBRE_UNIDAD_MEDICA_FAMILIAR").Width = 200
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
    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CboEstatus.KeyPress, TxtNombreUnidadMedica.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub txt_Keydown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNombreUnidadMedica.KeyDown
        If e.KeyCode = Keys.Return Then
            Select Case Me.Estado
                Case enumEstados.EDICION
                    SendKeys.Send("{TAB}")
                Case enumEstados.NUEVO
                    tsbGrabar.PerformClick()
            End Select
        End If
    End Sub

    Private Sub txtNumericos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigoUnidadMedica.KeyPress
        Dim txt As TextBox = CType(sender, TextBox)
        txtNoBeep(e)
    End Sub

    Private Sub txtNumerosEnterosKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigoUnidadMedica.KeyPress
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