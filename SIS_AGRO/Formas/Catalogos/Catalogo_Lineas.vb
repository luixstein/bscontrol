Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class Catalogo_Lineas
    Private oLineas As New Class_CatLineas

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
            Me.msgElemento = "Linea"
            Me.msgElementos = "Lineas"
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
        MyBase.Finalize()
    End Sub
#End Region

#Region "Opciones"
    Private Sub tsbNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbNuevo.Click
        Me.Estado = enumEstados.NUEVO
        Me.Cambia_Estado()
        'Me.TxtCodigoLinea.Text = Me.oLineas.CodigoSiguiente
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
                sMsg = " grabar las modificaciones de la "
            Case enumEstados.NUEVO
                sMsg = " agregar la "
            Case Else
                MsgBox("Me.Estado no válido.", MsgBoxStyle.Exclamation, Me.Text)
                Return
        End Select
        sMsg = "Deseas " & sMsg & Me.msgElemento & " : " & Me.TxtNombreLinea.Text & " ?"
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
        Me.oLineas.Imprimir_Listado()
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

                    Me.TxtCodigoLinea.Enabled = False
                    Me.TxtNombreLinea.Enabled = True
                    Me.CboEstatus.Enabled = False

                    Me.InicializaElemento()

                    Me.chkCrearConcepto.Visible = True : Me.chkCrearConcepto.Checked = False : Me.chkCrearConcepto.Checked = True 'esta como false y true para forzar a que hay cambio y se ejecute el evento del check

                    Me.TxtCodigoLinea.Focus()

                Case enumEstados.EDICION
                    Me.gBoxInformacion.Enabled = True
                    Me.gBoxBusquedaRapida.Enabled = False
                    Me.tssLabelEstado.Text = "Editando"
                    Me.tsbNuevo.Enabled = False
                    Me.tsbEditar.Enabled = False
                    Me.tsbGrabar.Enabled = True
                    Me.tsbCancelar.Enabled = True

                    Me.TxtCodigoLinea.Enabled = False
                    Me.TxtNombreLinea.Enabled = True
                    Me.CboEstatus.Enabled = True

                    Me.chkCrearConcepto.Visible = False : Me.chkCrearConcepto.Checked = True : Me.chkCrearConcepto.Checked = False

                    Me.TxtNombreLinea.Focus()

                Case enumEstados.CONSULTA
                    Me.gBoxInformacion.Enabled = False
                    Me.gBoxBusquedaRapida.Enabled = True
                    Me.tssLabelEstado.Text = "Consultando"
                    Me.tsbNuevo.Enabled = True
                    Me.tsbEditar.Enabled = False
                    Me.tsbGrabar.Enabled = False
                    Me.tsbCancelar.Enabled = False

                    Me.chkCrearConcepto.Visible = False : Me.chkCrearConcepto.Checked = True : Me.chkCrearConcepto.Checked = False

                    Me.txtFiltro.Focus()

            End Select
            Application.DoEvents()
        Catch ex As Exception
            HandleError(Me.Name, "Cambia_Estado", ex)
        End Try
    End Sub

    Private Sub InicializaElemento()
        Me.TxtCodigoLinea.Text = ""
        Me.TxtNombreLinea.Text = ""
        Me.CboEstatus.SelectedIndex = 0
        Me.txtCodigoConcepto.Text = ""
        Me.lblNombreConcepto.Text = "_"
        Me.chkCrearConcepto.Checked = False
    End Sub

    Private Sub DesplegarElementos()
        Try
            With Me.Grid
                .DataSource = oLineas.ObtenerElementosFiltro(Me.txtFiltro.Text, Me.cboEstatusFiltro.Text)
                .Columns("CODIGO_LINEA").Width = 50
                .Columns("NOMBRE_LINEA").Width = 280
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarElementos", ex)
        End Try
    End Sub

    Private Sub LlenaElemento(ByVal iCodigo_Elemento As String)
        Try
            Me.oLineas.Codigo_Linea = iCodigo_Elemento
            If Me.oLineas.Consultar Then
                With Me.oLineas
                    Me.TxtCodigoLinea.Text = .Codigo_Linea.ToString
                    Me.TxtNombreLinea.Text = .Nombre_Linea.ToString
                    If .Estatus = "A" Then
                        Me.CboEstatus.SelectedIndex = 0
                    Else
                        Me.CboEstatus.SelectedIndex = 1
                    End If
                    Me.txtCodigoConcepto.Text = .CODIGO_CONCEPTO
                    Dim oConceptos As New Class_CatConceptos
                    oConceptos.Codigo_Concepto = Me.txtCodigoConcepto.Text
                    oConceptos.Consultar()
                    Me.lblNombreConcepto.Text = oConceptos.Nombre_Concepto
                End With
            End If
        Catch ex As Exception
            HandleError(Me.Name, "LlenaElemento", ex)
        End Try
    End Sub

    Private Sub Grabar()
        Dim Grabado As Boolean = False
        Select Case Me.Estado
            Case enumEstados.NUEVO, enumEstados.EDICION
                Me.oLineas = New Class_CatLineas
                Try
                    With Me.oLineas
                        .Codigo_Linea = Me.TxtCodigoLinea.Text
                        .Nombre_Linea = Me.TxtNombreLinea.Text
                        .Estatus = Strings.Left(Me.CboEstatus.Text, 1)
                        .CODIGO_CONCEPTO = Me.txtCodigoConcepto.Text

                        Select Case Me.Estado
                            Case enumEstados.NUEVO
                                .GENERAR_CONCEPTO = Me.chkCrearConcepto.Checked
                                If .Insertar() = True Then
                                    Grabado = True
                                    Me.Estado = enumEstados.NUEVO
                                End If
                            Case enumEstados.EDICION
                                .GENERAR_CONCEPTO = False
                                If .Actualizar() = True Then
                                    Grabado = True
                                    Me.Estado = enumEstados.CONSULTA
                                End If
                        End Select

                        If Grabado = True Then
                            MsgBox(Me.msgElemento & " grabada satisfactoriamente.", MsgBoxStyle.Information, Me.Name)
                            Me.Refrescar()
                            Me.Cambia_Estado()
                        End If
                    End With
                Catch ex As Exception
                    HandleError(Me.Name, "Grabar", ex)
                    Me.Estado = enumEstados.CONSULTA
                    Me.Cambia_Estado()
                End Try
        End Select
    End Sub

    Private Function Validar() As Boolean
        Dim bResultado As Boolean = False

        Try
            If txtLEN(Me.TxtNombreLinea.Text) = False Then
                MsgBox("Captúre el nombre de la línea.", MsgBoxStyle.Exclamation, Me.Text)
                Me.TxtNombreLinea.Focus()
                Return False
            End If

            Select Case Me.chkCrearConcepto.Checked
                Case False
                    If txtLEN(Me.txtCodigoConcepto.Text) = False Then
                        MsgBox("Seleccione un concepto, en caso de no tener, puede usar el 0.", MsgBoxStyle.Exclamation, Me.Text)
                        Me.txtCodigoConcepto.Focus()
                        Return False
                    End If
                Case True
                    'No hay nada que validar
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
        Me.LlenaElemento(Me.Grid.CurrentRow.Cells("CODIGO_LINEA").Value.ToString)
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

#Region "Eventos de TxtFiltro y cboEstatusFiltro"
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

    Private Sub txt_Keydown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CboEstatus.KeyDown, chkCrearConcepto.KeyDown
        If e.KeyCode = Keys.Return Then
            txtTAB(e)
        End If
    End Sub

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CboEstatus.KeyPress, TxtNombreLinea.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub txtNumerosEnterosKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigoConcepto.KeyPress, TxtCodigoLinea.KeyPress
        txtSoloNumerosEnteros(e)
        txtNoBeep(e)
    End Sub

#End Region

#Region "Keydown específicos"

    Private Sub txtNombreLinea_Keydown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNombreLinea.KeyDown
        If e.KeyCode = Keys.Return Then
            Select Case Me.Estado
                Case enumEstados.NUEVO
                    tsbGrabar.PerformClick()
                Case enumEstados.EDICION
                    txtTAB(e)
            End Select
        End If
    End Sub

    Private Sub txtCodigoConcepto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigoConcepto.KeyDown
        Dim oConceptos As New Class_CatConceptos

        If e.KeyCode = Keys.F6 Then
            Dim resultado As String
            resultado = oConceptos.BusquedaVisual_PorDescripcion()
            Me.txtCodigoConcepto.Text = resultado : GoTo Buscar : Exit Sub
        End If
        If e.KeyCode = Keys.Return Then
Buscar:
            If txtLEN(Me.txtCodigoConcepto.Text) = True Then
                oConceptos.Codigo_Concepto = Me.txtCodigoConcepto.Text
                oConceptos.Consultar()
                Me.lblNombreConcepto.Text = oConceptos.Nombre_Concepto
                tsbGrabar.PerformClick()
            End If

        End If
    End Sub
#End Region

#Region "Validating específicos"

#End Region

    Private Sub CboFiltroHoja_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Refrescar()
    End Sub

    Private Sub chkCrearConcepto_CheckedChanged(sender As Object, e As EventArgs) Handles chkCrearConcepto.CheckedChanged
        If Me.chkCrearConcepto.Checked = True AndAlso Me.Estado = enumEstados.NUEVO Then
            Me.txtCodigoConcepto.Visible = False : Me.lblCodigoConcepto.Visible = False : Me.lblNombreConcepto.Visible = False
        Else
            Me.txtCodigoConcepto.Visible = True : Me.lblCodigoConcepto.Visible = True : Me.lblNombreConcepto.Visible = True
        End If
    End Sub
#End Region

End Class