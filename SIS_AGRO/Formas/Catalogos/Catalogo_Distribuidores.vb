Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class Catalogo_Distribuidores
    Private oDistribuidores As New Class_CatDistribuidores

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

#Region "Propiedades"

#End Region

#Region "Constructor y destructor"
    'Inicializa al objeto.
    Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

        Try
            Me.msgElemento = "Distribuidor"
            Me.msgElementos = "Distribuidores"
            Me.Run = False
            'Me.lstbElementos.ContextMenuStrip = Me.cMenuStripAccion
            Estado = enumEstados.CONSULTA
            Me.DesplegarElementos()
            Me.Cambia_Estado()
            Me.CboEstatus.Text = "A"
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

        Me.TxtCodDistribuidor.Text = Me.oDistribuidores.CodigoSiguiente
    End Sub

    Private Sub tsbEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbEditar.Click
        Me.Estado = enumEstados.EDICION
        Me.Cambia_Estado()
    End Sub

    Private Sub tsbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGrabar.Click
        Dim sMsg As String = ""
        Select Case Me.Estado
            Case enumEstados.EDICION
                sMsg = " grabar las modificaciones del " & Me.msgElemento & " : " & Me.TxtCodDistribuidor.Text
            Case enumEstados.NUEVO
                sMsg = " agregar el " & Me.msgElemento & " : " & Me.TxtCodDistribuidor.Text
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
        Dim oElementos As New Class_CatDistribuidores
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

                Me.TxtCodDistribuidor.Enabled = False
                Me.TxtNomDistribuidor.Enabled = True
                Me.txtDomicilio.Enabled = True
                Me.TxtCiudad.Enabled = True
                Me.TxtEstado.Enabled = True
                Me.TxtObservacion1.Enabled = True
                Me.TxtObservacion2.Enabled = True
                Me.TxtObservacion3.Enabled = True
                Me.CboEstatus.Enabled = False
                Me.InicializaElemento()

            Case enumEstados.EDICION
                Me.gBoxInformacion.Enabled = True
                Me.gBoxBusquedaRapida.Enabled = False
                Me.tssLabelEstado.Text = "Editando"
                Me.tsbNuevo.Enabled = False
                Me.tsbEditar.Enabled = False
                Me.tsbGrabar.Enabled = True
                Me.tsbCancelar.Enabled = True

                Me.TxtCodDistribuidor.Enabled = False
                Me.TxtNomDistribuidor.Enabled = True
                Me.txtDomicilio.Enabled = True
                Me.TxtCiudad.Enabled = True
                Me.TxtEstado.Enabled = True
                Me.TxtObservacion1.Enabled = True
                Me.TxtObservacion2.Enabled = True
                Me.TxtObservacion3.Enabled = True
                Me.CboEstatus.Enabled = True

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
        Me.TxtCodDistribuidor.Text = ""
        Me.TxtNomDistribuidor.Text = ""
        Me.txtDomicilio.Text = ""
        Me.TxtCiudad.Text = ""
        Me.TxtEstado.Text = ""
        Me.TxtObservacion1.Text = ""
        Me.TxtObservacion2.Text = ""
        Me.TxtObservacion3.Text = ""
        Me.CboEstatus.SelectedIndex = 0
    End Sub

    Private Sub DesplegarElementos()
        Dim oElementos As New Class_CatDistribuidores
        With Me.Grid
            .DataSource = oElementos.ObtenerElementos
            .Columns("CODIGO_DISTRIBUIDOR").Width = 50
            .Columns("NOMBRE_DISTRIBUIDOR").Width = 200
        End With

    End Sub

    Private Sub LlenaElemento(ByVal iCodigo_Elemento As String)
        Dim oElemento As New Class_CatDistribuidores
        oElemento.CODIGO_DISTRIBUIDOR = iCodigo_Elemento
        If oElemento.Consultar Then
            With oElemento
                Me.TxtCodDistribuidor.Text = .CODIGO_DISTRIBUIDOR.ToString
                Me.TxtNomDistribuidor.Text = .NOMBRE_DISTRIBUIDOR.ToString
                Me.txtDomicilio.Text = .DOMICILIO.ToString
                If .Estatus = "A" Then
                    Me.CboEstatus.SelectedIndex = 0
                Else
                    Me.CboEstatus.SelectedIndex = 1
                End If
                Me.TxtCiudad.Text = .CIUDAD.ToString
                Me.TxtObservacion1.Text = .OBSERVACION1
                Me.TxtObservacion2.Text = .OBSERVACION2.ToString
                Me.TxtObservacion3.Text = .OBSERVACION3

            End With
        End If
        oElemento = Nothing
    End Sub

    Private Sub Grabar_Elemento()
        Dim oElemento As New Class_CatDistribuidores
        Dim Grabado As Boolean = False

        If txtLEN(Me.TxtNomDistribuidor.Text) = False Then
            MsgBox("Asígne el nombre del distribuidor", MsgBoxStyle.Exclamation, Me.Text)
            Me.TxtNomDistribuidor.Focus()
            Exit Sub
        End If

        Select Case Me.Estado
            Case enumEstados.NUEVO, enumEstados.EDICION
                oElemento = New Class_CatDistribuidores
                Try
                    With oElemento
                        .CODIGO_DISTRIBUIDOR = Me.TxtCodDistribuidor.Text.ToUpper
                        .NOMBRE_DISTRIBUIDOR = Me.TxtNomDistribuidor.Text.ToUpper
                        .DOMICILIO = Me.txtDomicilio.Text.ToUpper
                        .ESTADO = Me.TxtEstado.Text.ToUpper
                        .CIUDAD = Me.TxtCiudad.Text.ToUpper
                        .OBSERVACION1 = Me.TxtObservacion1.Text.ToUpper
                        .OBSERVACION2 = Me.TxtObservacion2.Text.ToUpper
                        .OBSERVACION3 = Me.TxtObservacion3.Text.ToUpper
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
                    oElemento = Nothing
                End Try
        End Select
    End Sub

#End Region

#Region "Eventos de objetos"
#Region "Eventos de la lista de elementos"

    Private Sub Grid_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grid.CellClick
        Me.LlenaElemento(Me.Grid.CurrentRow.Cells("CODIGO_DISTRIBUIDOR").Value.ToString)
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
        Dim oElementos As New Class_CatDistribuidores
        Me.Grid.DataSource = Nothing

        With Me.Grid
            .DataSource = oElementos.ObtenerElementosFiltro(Me.txtFiltro.Text)
            .Columns("CODIGO_DISTRIBUIDOR").Width = 50
            .Columns("NOMBRE_DISTRIBUIDOR").Width = 200
        End With
    End Sub
    Private Sub txtFiltro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFiltro.KeyPress
        txtNoBeep(e)
        txtNoComilla(e)
    End Sub
    Private Sub txtFiltro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFiltro.KeyDown
        Dim oElementosFiltro As New Class_CatDistribuidores
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Return Or e.KeyCode = Keys.Back Then
            Me.Grid.DataSource = Nothing

            With Me.Grid
                .DataSource = oElementosFiltro.ObtenerElementosFiltro(Me.txtFiltro.Text)
                .Columns("CODIGO_DISTRIBUIDOR").Width = 50
                .Columns("NOMBRE_DISTRIBUIDOR").Width = 200
            End With
        End If
    End Sub
#End Region

#Region "Eventos Genericos"
    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNomDistribuidor.KeyPress, _
    txtDomicilio.KeyPress, TxtCiudad.KeyPress, TxtEstado.KeyPress, TxtObservacion1.KeyPress, TxtObservacion2.KeyPress, TxtObservacion3.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub txt_Keydown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNomDistribuidor.KeyDown
        If e.KeyCode = Keys.Return Then
            Select Case Me.Estado
                Case enumEstados.EDICION
                    SendKeys.Send("{TAB}")
                Case enumEstados.NUEVO
                    SendKeys.Send("{TAB}")
            End Select
        End If
    End Sub

    Private Sub txtNumericos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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
            'Me.ErrorProvider.Clear()
        End If
    End Sub
#End Region

#Region "Keydown específicos"

    Private Sub TxtCodDistribuidor_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodDistribuidor.KeyDown
        Select Case e.KeyCode
            Case Keys.Return
                txtTAB(e)
            Case Keys.Escape
        End Select
    End Sub

    Private Sub txtDomicilio_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDomicilio.KeyDown
        Select Case e.KeyCode
            Case Keys.Return
                txtTAB(e)
            Case Keys.Escape
                Me.TxtNomDistribuidor.Focus()
        End Select
    End Sub

    Private Sub TxtCiudad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCiudad.KeyDown
        Select Case e.KeyCode
            Case Keys.Return
                txtTAB(e)
            Case Keys.Escape
                Me.txtDomicilio.Focus()
        End Select
    End Sub

    Private Sub TxtEstado_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtEstado.KeyDown
        Select Case e.KeyCode
            Case Keys.Return
                txtTAB(e)
            Case Keys.Escape
                Me.TxtCiudad.Focus()
        End Select
    End Sub

    Private Sub TxtObservacion1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtObservacion1.KeyDown
        Select Case e.KeyCode
            Case Keys.Return
                txtTAB(e)
            Case Keys.Escape
                Me.TxtCiudad.Focus()
        End Select
    End Sub

    Private Sub TxtObservacion2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtObservacion2.KeyDown
        Select Case e.KeyCode
            Case Keys.Return
                txtTAB(e)
            Case Keys.Escape
                Me.TxtObservacion1.Focus()
        End Select
    End Sub

    Private Sub TxtObservacion3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtObservacion3.KeyDown
        If e.KeyCode = Keys.Return Then
            Select Case Me.Estado
                Case enumEstados.EDICION
                    Me.CboEstatus.Focus()
                Case enumEstados.NUEVO
                    tsbGrabar.PerformClick()
            End Select
        End If
    End Sub

    Private Sub CboEstatus_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CboEstatus.KeyDown
        If e.KeyCode = Keys.Return Then
            tsbGrabar.PerformClick()
        End If
    End Sub
#End Region

#Region "Validating específicos"

#End Region

    Private Sub CboFiltroHoja_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Refrescar()
    End Sub

#End Region


End Class