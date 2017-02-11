Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class Cat_Nomina_CentroCosto
    Private oCentroCosto As New Class_CatCentroCostos

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
            Me.msgElemento = "Centro de costo"
            Me.msgElementos = "Centros de costos"
            Me.Run = False
            'Me.lstbElementos.ContextMenuStrip = Me.cMenuStripAccion
            Estado = enumEstados.CONSULTA
            Me.Cambia_Estado()
            Me.DesplegarElementos()
            Me.DesplegarCultivos()
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
        Me.TxtCodigoCentroCosto.Text = Me.oCentroCosto.CodigoSiguiente
    End Sub

    Private Sub tsbEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbEditar.Click
        Me.Estado = enumEstados.EDICION
        Me.Cambia_Estado()
    End Sub

    Private Sub tsbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGrabar.Click
        Dim sMsg As String = ""
        Select Case Me.Estado
            Case enumEstados.EDICION
                sMsg = " grabar las modificaciones del " & Me.msgElemento & " : " & Me.TxtCodigoCentroCosto.Text
            Case enumEstados.NUEVO
                sMsg = " agregar el " & Me.msgElemento & " : " & Me.TxtCodigoCentroCosto.Text
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
        Me.oCentroCosto.Imprimir_Listado()
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

                Me.TxtCodigoCentroCosto.Enabled = False
                Me.TxtNombreCentroCosto.Enabled = True
                Me.CboEstatus.Enabled = False
                Me.InicializaElemento()
                Me.TxtNombreCentroCosto.Focus()

            Case enumEstados.EDICION
                Me.gBoxInformacion.Enabled = True
                Me.gBoxBusquedaRapida.Enabled = False
                Me.tssLabelEstado.Text = "Edición"
                Me.tsbNuevo.Enabled = False
                Me.tsbEditar.Enabled = False
                Me.tsbGrabar.Enabled = True
                Me.tsbCancelar.Enabled = True

                Me.TxtCodigoCentroCosto.Enabled = False
                Me.TxtNombreCentroCosto.Enabled = True
                Me.CboEstatus.Enabled = True
                Me.TxtNombreCentroCosto.Focus()

            Case enumEstados.CONSULTA
                Me.gBoxInformacion.Enabled = False
                Me.gBoxBusquedaRapida.Enabled = True
                Me.tssLabelEstado.Text = "Consulta"
                Me.tsbNuevo.Enabled = True
                Me.tsbEditar.Enabled = False
                Me.tsbGrabar.Enabled = False
                Me.tsbCancelar.Enabled = False
                Me.txtFiltro.Focus()
                Me.CboEstatusFiltro.SelectedIndex = 0

        End Select
        Application.DoEvents()
    End Sub

    Private Sub InicializaElemento()
        Me.TxtCodigoCentroCosto.Text = ""
        Me.TxtNombreCentroCosto.Text = ""
        Me.txtCuentaContable.Text = ""
        Me.lblCuenta.Text = ""
        Me.CboEstatus.Text = "A"
    End Sub

    Private Sub DesplegarElementos()
        Dim oElementos As New Class_CatCentroCostos
        With Me.Grid
            .DataSource = oElementos.ObtenerElementosEstatus(Me.CboEstatusFiltro.Text)
            .Columns("CODIGO_CENTRO_COSTO").Width = 50
            .Columns("NOMBRE_CENTRO_COSTO").Width = 250
        End With
    End Sub

    Private Sub DesplegarCultivos()
        Dim oElementos As New Class_CatCultivos
        With Me.cboCultivo
            .DisplayMember = "NOMBRE_CULTIVO"
            .ValueMember = "CODIGO_CULTIVO"
            Dim dView As New Data.DataView(oElementos.ObtenerElementosParaCatalogos)
            dView.Sort = "NOMBRE_CULTIVO"
            .DataSource = dView
            If dView.Count > 0 Then
                .SelectedIndex = -1
            End If
        End With
    End Sub

    Private Sub LlenaElemento(ByVal iCodigo_Elemento As String)
        Dim sCodigo As String
        Me.oCentroCosto.CODIGO_CENTRO_COSTO = CInt(iCodigo_Elemento)
        If Me.oCentroCosto.Consultar Then
            With Me.oCentroCosto
                sCodigo = "0000" + iCodigo_Elemento
                Me.TxtCodigoCentroCosto.Text = sCodigo.Substring(Len(sCodigo) - 4)
                Me.TxtNombreCentroCosto.Text = .NOMBRE_CENTRO_COSTO.ToString
                Me.txtCuentaContable.Text = .CUENTA_CONTABLE.ToString
                Dim oCuentaContable = New Class_CatCuentas(.CUENTA_CONTABLE)
                Me.lblCuenta.Text = oCuentaContable.NOMBRE_CUENTA
                Me.CboEstatus.Text = .Estatus
                Me.chkContabilizarporactividad.Checked = CBool(.CONTABILIZAR_POR_ACTIVIDAD.ToString)
                If (.CODIGO_CULTIVO = "") Then
                    Me.cboCultivo.SelectedValue = 0
                Else
                    Me.cboCultivo.SelectedValue = CInt(.CODIGO_CULTIVO)
                End If
            End With
        End If
    End Sub

    Private Sub Grabar_Elemento()
        Dim Grabado As Boolean = False
        Dim CodigoCultivo As String
        If (CInt(cboCultivo.SelectedIndex) > 0) Then
            CodigoCultivo = (cboCultivo.SelectedValue).ToString
        Else
            CodigoCultivo = ""
        End If
        Select Case Me.Estado
            Case enumEstados.NUEVO, enumEstados.EDICION
                Me.oCentroCosto = New Class_CatCentroCostos
                Try
                    With Me.oCentroCosto
                        .CODIGO_CENTRO_COSTO = CInt(Me.TxtCodigoCentroCosto.Text)
                        .NOMBRE_CENTRO_COSTO = Me.TxtNombreCentroCosto.Text
                        .CUENTA_CONTABLE = Me.txtCuentaContable.Text
                        .Estatus = Me.CboEstatus.Text
                        .CODIGO_CULTIVO = CodigoCultivo
                        .CONTABILIZAR_POR_ACTIVIDAD = CBool(Me.chkContabilizarporactividad.Checked)
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
                                Me.TxtCodigoCentroCosto.Text = .CodigoSiguiente.ToString
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

#End Region

#Region "Eventos de objetos"

#Region "Eventos de la lista de elementos"
    Private Sub Grid_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grid.CellClick
        Me.LlenaElemento(Me.Grid.CurrentRow.Cells("CODIGO_CENTRO_COSTO").Value.ToString)
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

#Region " Eventos de TxtFiltro y CboEstatusFiltro"
    Private Sub txtFiltro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFiltro.TextChanged
        Dim oElementos As New Class_CatCentroCostos
        Me.Grid.DataSource = Nothing

        With Me.Grid
            .DataSource = oElementos.ObtenerElementosFiltro(Me.txtFiltro.Text, Me.CboEstatusFiltro.Text)
            .Columns("CODIGO_CENTRO_COSTO").Width = 50
            .Columns("NOMBRE_CENTRO_COSTO").Width = 250
        End With
    End Sub
    Private Sub txtFiltro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFiltro.KeyPress
        txtNoBeep(e)
        txtNoComilla(e)
    End Sub
    Private Sub txtFiltro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFiltro.KeyDown
        Dim oElementosFiltro As New Class_CatCentroCostos
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Return Or e.KeyCode = Keys.Back Then
            Me.Grid.DataSource = Nothing

            With Me.Grid
                .DataSource = oElementosFiltro.ObtenerElementosFiltro(Me.txtFiltro.Text, Me.CboEstatusFiltro.Text)
                .Columns("CODIGO_CENTRO_COSTO").Width = 50
                .Columns("NOMBRE_CENTRO_COSTO").Width = 250
            End With
        End If
    End Sub

    Private Sub CboEstatusFiltro_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboEstatusFiltro.SelectedIndexChanged
        Dim oElementos As New Class_CatCentroCostos
        Me.Grid.DataSource = Nothing

        With Me.Grid
            .DataSource = oElementos.ObtenerElementosFiltro(Me.txtFiltro.Text, Me.CboEstatusFiltro.Text)
            .Columns("CODIGO_CENTRO_COSTO").Width = 50
            .Columns("NOMBRE_CENTRO_COSTO").Width = 250
        End With
    End Sub
#End Region

#Region "Eventos Genericos"
    Private Sub CboEstatus_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CboEstatus.KeyDown
        'If e.KeyCode = Keys.Return Then
        '    Me.cboCultivo.Focus()
        'End If
    End Sub
    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CboEstatus.KeyPress, TxtNombreCentroCosto.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub txt_Keydown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNombreCentroCosto.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.CboEstatus.Focus()
        End If
    End Sub

    Private Sub txtNumericos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigoCentroCosto.KeyPress
        Dim txt As TextBox = CType(sender, TextBox)
        txtNoBeep(e)
    End Sub
    Private Sub txtNumerosEnterosKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCuentaContable.KeyPress
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
    Private Sub txtCuentaContable_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCuentaContable.KeyDown
        Dim oCuenta As New Class_CatCuentas
        oCuenta = New Class_CatCuentas
        Select Case e.KeyCode
            Case Keys.F6
busqueda_Visual:

                Dim sCuenta As String = oCuenta.BusquedaVisual_PorDescripcion
                If sCuenta.Length > 0 Then
                    Me.txtCuentaContable.Text = sCuenta
                    sCuenta = Replace(sCuenta, "'", "''")
                    oCuenta = New Class_CatCuentas(sCuenta)
                    Me.txtCuentaContable.Text = sCuenta
                    lblCuenta.Text = oCuenta.NOMBRE_CUENTA
                End If
            Case Keys.Return
                If oCuenta.isCuentaContableValida(Me.txtCuentaContable.Text) = False Then
                    MsgBox("La cuenta contable del centro de costos debe de ser de operación", MsgBoxStyle.Exclamation, Me.Text)
                    Me.txtCuentaContable.Focus()
                    Exit Sub
                End If
                oCuenta = New Class_CatCuentas(Me.txtCuentaContable.Text)

                If oCuenta.Consultar = False Then
                    GoTo busqueda_Visual
                Else
                    lblCuenta.Text = oCuenta.NOMBRE_CUENTA
                    If Me.Estado = enumEstados.EDICION Then
                        SendKeys.Send("{TAB}")
                    Else
                        tsbGrabar.PerformClick()
                    End If
                End If
        End Select
    End Sub

    Private Sub cboCultivo_KeyDown(sender As Object, e As KeyEventArgs) Handles cboCultivo.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.chkContabilizarporactividad.Focus()
        End If
    End Sub

    Private Sub chkContabilizarporactividad_KeyDown(sender As Object, e As KeyEventArgs) Handles chkContabilizarporactividad.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.tsbGrabar.PerformClick()
        End If
    End Sub
#End Region

#Region "Validating específicos"

#End Region

    Private Sub CboFiltroHoja_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Refrescar()
    End Sub

#End Region

End Class