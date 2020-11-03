Option Strict On

Public Class Catalogo_AgenciaAduanas
    Private oAgenciaAduanales As New Class_CatAgenciaAduanales

#Region "Campos privados"
    Private Enum enumEstados
        NUEVO
        EDICION
        CONSULTA
    End Enum

    Private Estado As enumEstados
    Private Run As Boolean
    Private msgElemento As String
#End Region

#Region "Constructor y destructor"
    'Inicializa al objeto.
    Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

        Try
            Me.msgElemento = "AgenciaAdiana"
            Me.Run = False
            Estado = enumEstados.CONSULTA
            Me.DesplegarElementos()
            Me.Cambia_Estado()
            Me.LlenaComboNacionalidad()
            Me.cboNacionalidad.Text = "MEXICANA"
            Me.CboEstatus.Text = "A"
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

        Me.TxtCodigoAgenciaAduanal.Text = Me.oAgenciaAduanales.CodigoSiguiente
    End Sub

    Private Sub tsbEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbEditar.Click
        Me.Estado = enumEstados.EDICION
        Me.Cambia_Estado()
    End Sub

    Private Sub tsbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGrabar.Click
        Dim sMsg As String = ""
        Select Case Me.Estado
            Case enumEstados.EDICION
                sMsg = " grabar las modificaciones del " & Me.msgElemento & " : " & Me.TxtCodigoAgenciaAduanal.Text
            Case enumEstados.NUEVO
                sMsg = " agregar el " & Me.msgElemento & " : " & Me.TxtCodigoAgenciaAduanal.Text
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
        Dim oElementos As New Class_CatAgenciaAduanales
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
                Me.tssLabelEstado.Text = "Agregando"
                Me.tsbNuevo.Enabled = False
                Me.tsbEditar.Enabled = False
                Me.tsbGrabar.Enabled = True
                Me.tsbCancelar.Enabled = True

                Me.TxtCodigoAgenciaAduanal.Enabled = False
                Me.TxtNombreAgenciaAduanal.Enabled = True
                Me.txtClaveAgenciaAduanal.Enabled = True
                Me.cboNacionalidad.Enabled = True
                Me.CboEstatus.Enabled = False
                Me.InicializaElemento()
                Me.TxtNombreAgenciaAduanal.Focus()

            Case enumEstados.EDICION
                Me.gBoxInformacion.Enabled = True
                Me.gBoxBusquedaRapida.Enabled = False
                Me.tssLabelEstado.Text = "Editando"
                Me.tsbNuevo.Enabled = False
                Me.tsbEditar.Enabled = False
                Me.tsbGrabar.Enabled = True
                Me.tsbCancelar.Enabled = True

                Me.TxtCodigoAgenciaAduanal.Enabled = False
                Me.TxtNombreAgenciaAduanal.Enabled = True
                Me.txtClaveAgenciaAduanal.Enabled = True
                Me.cboNacionalidad.Enabled = True
                Me.CboEstatus.Enabled = True
                Me.TxtNombreAgenciaAduanal.Focus()

            Case Else
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
        Me.TxtCodigoAgenciaAduanal.Text = ""
        Me.TxtNombreAgenciaAduanal.Text = ""
        Me.txtClaveAgenciaAduanal.Text = ""
        Me.cboNacionalidad.Text = "MEXICANA"
        Me.CboEstatus.SelectedIndex = 0
    End Sub

    Private Sub DesplegarElementos()
        Dim oElementos As New Class_CatAgenciaAduanales
        With Me.Grid
            .DataSource = oElementos.ObtenerElementos
            .Columns("CODIGO_ADUANA").Width = 70
            .Columns("NOMBRE_AGENCIA_ADUANA").Width = 200
        End With

    End Sub

    Private Sub LlenaElemento(ByVal iCodigo_Elemento As String)
        Dim oElemento As New Class_CatAgenciaAduanales
        oElemento.CODIGO_ADUANA = iCodigo_Elemento
        If oElemento.Consultar Then
            With oElemento
                Me.TxtCodigoAgenciaAduanal.Text = .CODIGO_ADUANA.ToString
                Me.TxtNombreAgenciaAduanal.Text = .NOMBRE_AGENCIA_ADUANA.ToString
                Me.txtClaveAgenciaAduanal.Text = .CLAVE_AGENCIA_ADUANA.ToString
                If .NACIONAL = "1" Then
                    Me.cboNacionalidad.Text = "MEXICANA"
                Else
                    Me.cboNacionalidad.Text = "ESTADOUNIDENSE"
                End If
                Me.cboNacionalidad.Text = .NACIONAL.ToString
                If .Estatus = "A" Then
                    Me.CboEstatus.SelectedIndex = 0
                Else
                    Me.CboEstatus.SelectedIndex = 1
                End If

            End With
        End If
        oElemento = Nothing
    End Sub

    Private Sub Grabar_Elemento()
        Dim oElemento As New Class_CatAgenciaAduanales
        Dim Grabado As Boolean = False

        If txtLEN(Me.TxtNombreAgenciaAduanal.Text) = False Then
            MsgBox("Asígne el nombre de la agencia aduanal", MsgBoxStyle.Exclamation, Me.Text)
            Me.TxtNombreAgenciaAduanal.Focus()
            Exit Sub
        End If

        Select Case Me.Estado
            Case enumEstados.NUEVO, enumEstados.EDICION
                oElemento = New Class_CatAgenciaAduanales
                Try
                    With oElemento
                        .CODIGO_ADUANA = Me.TxtCodigoAgenciaAduanal.Text
                        .NOMBRE_AGENCIA_ADUANA = Me.TxtNombreAgenciaAduanal.Text
                        .CLAVE_AGENCIA_ADUANA = Me.txtClaveAgenciaAduanal.Text
                        If Me.cboNacionalidad.Text = "MEXICANA" Then
                            .NACIONAL = "1"
                        Else
                            .NACIONAL = "0"
                        End If
                        .Estatus = Strings.Left(Me.CboEstatus.Text, 1)

                        Select Case Me.Estado
                            Case enumEstados.NUEVO
                                If .Insertar() Then
                                    Grabado = True
                                    Me.Estado = enumEstados.CONSULTA
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
                    oElemento = Nothing
                End Try
        End Select
    End Sub

    Private Function LlenaComboNacionalidad() As Boolean
        Me.cboNacionalidad.Items.Add("MEXICANA")
        Me.cboNacionalidad.Items.Add("ESTADOUNIDENSE")
        Me.cboNacionalidad.SelectedItem = "MEXICANA"
    End Function

    Private Function LlenaComboEstatus() As Boolean
        Me.CboEstatus.Items.Add("A")
        Me.CboEstatus.Items.Add("B")
        Me.CboEstatus.SelectedItem = "A"
    End Function

    Private Function Consultar() As Boolean
        Dim sFolio As String = Me.TxtCodigoAgenciaAduanal.Text
        Me.InicializaElemento()
        Me.oAgenciaAduanales = New Class_CatAgenciaAduanales
        Me.oAgenciaAduanales.CODIGO_ADUANA = Me.TxtCodigoAgenciaAduanal.Text

        If Me.oAgenciaAduanales.Consultar = False Then
            Me.Estado = enumEstados.NUEVO
            Me.Cambia_Estado()
            Exit Function
        Else
            With Me.oAgenciaAduanales
                Me.TxtCodigoAgenciaAduanal.Text = .CODIGO_ADUANA
                Me.TxtNombreAgenciaAduanal.Text = .NOMBRE_AGENCIA_ADUANA
                Me.txtClaveAgenciaAduanal.Text = .CLAVE_AGENCIA_ADUANA
                If .NACIONAL = "1" Then
                    Me.cboNacionalidad.Text = "MEXICANA"
                Else
                    Me.cboNacionalidad.Text = "ESTADOUNIDENSE"
                End If

                Me.CboEstatus.SelectedText = .Estatus
            End With

        End If
        Consultar = True

        Me.Estado = enumEstados.EDICION
        Me.Cambia_Estado()
    End Function

#End Region

#Region "Eventos de objetos"
    Private Sub CboEstatus_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CboEstatus.KeyDown
        If e.KeyCode = Keys.Return Then
            tsbGrabar.PerformClick()
        End If
    End Sub

    Private Sub cboNacionalidad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboNacionalidad.KeyDown
        If e.KeyCode = Keys.Return Then
            Select Case Me.Estado
                Case enumEstados.EDICION
                    SendKeys.Send("{TAB}")
                Case enumEstados.NUEVO
                    tsbGrabar.PerformClick()
            End Select
        End If

    End Sub

#Region "Eventos de la lista de elementos"
    Private Sub Grid_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grid.CellClick
        Me.LlenaElemento(Me.Grid.CurrentRow.Cells("CODIGO_ADUANA").Value.ToString)
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
        Dim oElementos As New Class_CatAgenciaAduanales
        Me.Grid.DataSource = Nothing

        With Me.Grid
            .DataSource = oElementos.ObtenerElementosFiltro(Me.txtFiltro.Text)
            .Columns("CODIGO_ADUANA").Width = 70
            .Columns("NOMBRE_AGENCIA_ADUANA").Width = 200
        End With
    End Sub
    Private Sub txtFiltro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFiltro.KeyPress
        txtNoBeep(e)
        txtNoComilla(e)
    End Sub
    Private Sub txtFiltro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFiltro.KeyDown
        Dim oElementosFiltro As New Class_CatAgenciaAduanales
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Return Or e.KeyCode = Keys.Back Then
            Me.Grid.DataSource = Nothing

            With Me.Grid
                .DataSource = oElementosFiltro.ObtenerElementosFiltro(Me.txtFiltro.Text)
                .Columns("CODIGO_ADUANA").Width = 70
                .Columns("NOMBRE_AGENCIA_ADUANA").Width = 200
            End With
        End If
    End Sub
#End Region

#Region "Eventos Genericos"

    Private Sub txt_Keydown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNombreAgenciaAduanal.KeyDown, txtClaveAgenciaAduanal.KeyDown
        If e.KeyCode = Keys.Return Then
            Select Case Me.Estado
                Case enumEstados.EDICION
                    SendKeys.Send("{TAB}")
                Case enumEstados.NUEVO
                    SendKeys.Send("{TAB}")
            End Select
        End If
    End Sub

#End Region

#End Region

End Class
