Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class Frm_Embarques_ConfiguracionPesoEnvase
    Private oPesoEnvase As New Class_Embarques_ConfiguracionPesoEnvase

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

    Private iGyCodigoCultivo As Integer = 0
    Private iGyNombreCultivo As Integer = 1
    Private iGyCodigoTamaño As Integer = 2
    Private iGyNombreTamaño As Integer = 3
    Private iGyCodigoTipoEnvase As Integer = 4
    Private iGyNombreTipoEnvase As Integer = 5
    Private iGyEquivalencia As Integer = 6

#Region "Constructor y destructor"
    'Inicializa al objeto.
    Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

        Try
            Me.msgElemento = "Peso"
            Me.msgElementos = "Pesos"
            Me.Run = False
            'Me.lstbElementos.ContextMenuStrip = Me.cMenuStripAccion
            Estado = enumEstados.CONSULTA
            Me.Cambia_Estado()
            Me.DesplegarElementos()
            Me.DesplegarCultivos()
            Me.DesplegarTiposTamaños()
            Me.DesplegarTiposEnvases()
            Me.TxtPeso.Text = ""
            Me.rdbNombreCultivo.Checked = True
            Me.FormateaGrid()
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
        Me.TxtPeso.Text = ""
    End Sub

    Private Sub tsbEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbEditar.Click
        Me.Estado = enumEstados.EDICION
        Me.Cambia_Estado()
    End Sub

    Private Sub tsbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGrabar.Click
        Dim sMsg As String = ""
        Select Case Me.Estado
            Case enumEstados.EDICION
                sMsg = " grabar las modificaciones del " & Me.msgElemento & " : " '& Me.TxtCodigoLinea.Text
            Case enumEstados.NUEVO
                sMsg = " agregar el " & Me.msgElemento & " : " ' & Me.TxtCodigoLinea.Text
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
        Me.oPesoEnvase.Imprimir_Listado()
    End Sub
#End Region

#Region "Eventos de objetos"

#Region "Eventos de la lista de elementos"

    Private Sub Grid_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grid.CellClick
        Me.LlenaElemento(Me.Grid.CurrentRow.Cells("CODIGO_CULTIVO").Value.ToString, CInt(Me.Grid.CurrentRow.Cells("CODIGO_TIPO_ENVASE").Value), CInt(Me.Grid.CurrentRow.Cells("CODIGO_TIPO_TAMAÑO").Value))
    End Sub

    Private Sub Grid_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grid.CellDoubleClick
        Me.Estado = enumEstados.EDICION
        Me.Cambia_Estado()
    End Sub

    'Private Sub lstbElementos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Me.Estado = enumEstados.EDICION
    '    Me.Cambia_Estado()
    'End Sub

    'Private Sub lstbElementos_Enter(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If Me.lstbElementos.Items.Count > 0 Then
    '        Me.tsbEditar.Enabled = True
    '    End If
    'End Sub

    'Private Sub lstbElementos_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Me.tsbEditar.Enabled = False
    'End Sub

    'Private Sub lstbElementos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If Me.lstbElementos.SelectedIndex >= 0 Then
    '        Me.LlenaElemento(Me.lstbElementos.SelectedValue.ToString)
    '    End If
    'End Sub
#End Region

#Region " Eventos de TxtFiltro"
    Private Sub txtFiltro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtfiltro.TextChanged
        Dim oElementos As New Class_Embarques_ConfiguracionPesoEnvase
        Me.Grid.DataSource = Nothing
        With Me.Grid
            If rdbNombreCultivo.Checked = True Then
                .DataSource = oElementos.ObtenerElementosFiltroCultivo(Me.txtfiltro.Text)
            Else
                .DataSource = oElementos.ObtenerElementosFiltroNombreEnvase(Me.txtfiltro.Text)
            End If
            .Columns("CULTIVO").Width = 100
            .Columns("ENVASE").Width = 100
        End With
        Me.FormateaGrid()
    End Sub
    Private Sub txtFiltro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtfiltro.KeyPress
        txtNoBeep(e)
        txtNoComilla(e)
    End Sub
    Private Sub txtFiltro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtfiltro.KeyDown
        Dim oElementosFiltro As New Class_Embarques_ConfiguracionPesoEnvase
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Return Or e.KeyCode = Keys.Back Then
            Me.Grid.DataSource = Nothing

            With Me.Grid
                If rdbNombreCultivo.Checked = True Then
                    .DataSource = oElementosFiltro.ObtenerElementosFiltroCultivo(Me.txtfiltro.Text)
                Else
                    .DataSource = oElementosFiltro.ObtenerElementosFiltroNombreEnvase(Me.txtfiltro.Text)
                End If
                .Columns("CULTIVO").Width = 100
                .Columns("ENVASE").Width = 100
            End With
        End If
        Me.FormateaGrid()
    End Sub
#End Region

#Region "Eventos Genericos"

    Private Sub txtTextoKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        txtNoBeep(e)
    End Sub

    Private Sub txtNumerosEnterosKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        txtSoloNumerosEnteros(e)
        txtNoBeep(e)
    End Sub

    Private Sub txtNumerosDecimalKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPeso.KeyPress
        Dim txt As TextBox = CType(sender, TextBox)
        txtSoloNumerosDecimales(e, txt.Text)
        txtNoBeep(e)
    End Sub

    Private Sub Cbo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.Send("{TAB}")
        End Select
    End Sub
#End Region

#Region "Keydown específicos"

    Private Sub TxtPeso_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtPeso.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.TxtPeso.Text = FormatNumber(CDbl(Me.TxtPeso.Text), 2)
            tsbGrabar.PerformClick()
        End If
    End Sub
#End Region

#Region "Validating específicos"

#End Region

    Private Sub CboFiltroHoja_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtfiltro.KeyPress
        Refrescar()
    End Sub

#End Region

#Region "Métodos y procedimientos"
    Private Sub Refrescar()
        Me.DesplegarElementos()
    End Sub

    Private Sub Cambia_Estado()
        'Dim iIndex As Integer
        Select Case Me.Estado
            Case enumEstados.NUEVO
                Me.gBoxInformacion.Enabled = True
                Me.gBoxBusquedaRapida.Enabled = False
                Me.tssLabelEstado.Text = "Agregando una nueva " & Me.msgElemento
                Me.tsbNuevo.Enabled = False
                Me.tsbEditar.Enabled = False
                Me.tsbGrabar.Enabled = True
                Me.tsbCancelar.Enabled = True

                Me.cboCultivo.Enabled = True
                Me.CboTipoTamaño.Enabled = True
                Me.CboTipoEnvase.Enabled = True
                Me.TxtPeso.Enabled = True

                Me.InicializaElemento()

            Case enumEstados.EDICION
                Me.gBoxInformacion.Enabled = True
                Me.gBoxBusquedaRapida.Enabled = False
                Me.tssLabelEstado.Text = "Edición"
                Me.tsbNuevo.Enabled = False
                Me.tsbEditar.Enabled = False
                Me.tsbGrabar.Enabled = True
                Me.tsbCancelar.Enabled = True

                Me.cboCultivo.Enabled = False
                Me.CboTipoTamaño.Enabled = False
                Me.CboTipoEnvase.Enabled = False
                Me.TxtPeso.Enabled = True
                Me.TxtPeso.Focus()

            Case enumEstados.CONSULTA
                Me.gBoxInformacion.Enabled = False
                Me.gBoxBusquedaRapida.Enabled = True
                Me.tssLabelEstado.Text = "Consulta"
                Me.tsbNuevo.Enabled = True
                Me.tsbEditar.Enabled = False
                Me.tsbGrabar.Enabled = False
                Me.tsbCancelar.Enabled = False
                If Me.Run Then
                    'If Me.lstbElementos.SelectedIndex < 0 Then
                    'Me.lstbElementos.SelectedIndex = 0
                    'Else
                    '  iIndex = Me.lstbElementos.SelectedIndex
                    '   Me.lstbElementos.SelectedIndex = -1
                    ' Me.lstbElementos.SelectedIndex = iIndex
                    'End If
                End If
                Me.txtfiltro.Focus()

        End Select
        Application.DoEvents()
    End Sub

    Private Sub InicializaElemento()
        Me.cboCultivo.SelectedIndex = -1
        Me.CboTipoTamaño.SelectedIndex = -1
        Me.CboTipoEnvase.SelectedIndex = -1
        Me.TxtPeso.Text = ""
        Me.rdbNombreCultivo.Checked = True
        Me.FormateaGrid()
    End Sub

    Private Sub FormateaGrid()
        Me.Grid.Columns(Me.iGyCodigoCultivo).Visible = False
        Me.Grid.Columns(Me.iGyCodigoTamaño).Visible = False
        Me.Grid.Columns(Me.iGyCodigoTipoEnvase).Visible = False

        Me.Grid.Columns(Me.iGyNombreCultivo).Width = 200
        Me.Grid.Columns(Me.iGyNombreTamaño).Width = 150
        Me.Grid.Columns(Me.iGyNombreTipoEnvase).Width = 80
        Me.Grid.Columns(Me.iGyEquivalencia).Width = 80
    End Sub

    Private Sub DesplegarElementos()
        Dim oElementos As New Class_Embarques_ConfiguracionPesoEnvase
        With Me.Grid
            .DataSource = oElementos.ObtenerElementos
            .Columns("CODIGO_CULTIVO").Width = 100
            .Columns("CULTIVO").Width = 200
            .Columns("CODIGO_TIPO_TAMAÑO").Width = 100
            .Columns("TAMAÑO").Width = 150
            .Columns("CODIGO_TIPO_ENVASE").Width = 100
            .Columns("ENVASE").Width = 100
            .Columns("PESO").Width = 80
        End With
    End Sub

    Private Sub DesplegarCultivos()
        Dim oElementos As New Class_CatCultivos
        With Me.cboCultivo
            .DisplayMember = "NOMBRE_CULTIVO"
            .ValueMember = "CODIGO_CULTIVO"

            Dim dView As New Data.DataView(oElementos.ObtenerElementos)
            dView.Sort = "NOMBRE_CULTIVO"
            .DataSource = dView
            If dView.Count > 0 Then
                .SelectedIndex = -1
            End If
        End With
    End Sub

    Private Sub DesplegarTiposTamaños()
        Dim oTipoTamaño = New Class_CatTiposTamaños
        With Me.CboTipoTamaño
            .DisplayMember = "NOMBRE_TIPO_TAMAÑO"
            .ValueMember = "CODIGO_TIPO_TAMAÑO"
            Dim dView As New Data.DataView(oTipoTamaño.ObtenerElementos)
            dView.Sort = "NOMBRE_TIPO_TAMAÑO"
            .DataSource = dView
            If dView.Count > 0 Then
                .SelectedIndex = -1
            End If
        End With
    End Sub

    Private Sub DesplegarTiposEnvases()
        Dim oTipoTamaño = New Class_CatTiposEnvases
        With Me.CboTipoEnvase
            .DisplayMember = "NOMBRE_TIPO_ENVASE"
            .ValueMember = "CODIGO_TIPO_ENVASE"
            Dim dView As New Data.DataView(oTipoTamaño.ObtenerElementos)
            dView.Sort = "NOMBRE_TIPO_ENVASE"
            .DataSource = dView
            If dView.Count > 0 Then
                .SelectedIndex = -1
            End If
        End With
    End Sub

    Private Sub LlenaElemento(ByVal iCodigo_Cultivo As String, ByVal iCodigo_Tipo_Envase As Integer, ByVal iCodigo_Tipo_Tamaño As Integer)
        Dim oElemento As New Class_Embarques_ConfiguracionPesoEnvase
        oElemento.CODIGO_CULTIVO = iCodigo_Cultivo
        oElemento.CODIGO_TIPO_TAMAÑO = iCodigo_Tipo_Tamaño
        oElemento.CODIGO_TIPO_ENVASE = iCodigo_Tipo_Envase
        If oElemento.Consultar Then
            With oElemento

                Dim oSubCuentas As New Class_find("Select CODIGO_CULTIVO, CODIGO_TIPO_TAMAÑO, CODIGO_TIPO_ENVASE, PESO FROM EMB_CONFIGURACION_PESO_ENVASE " & _
                                                  "WHERE CODIGO_CULTIVO='" & .CODIGO_CULTIVO & "' AND CODIGO_TIPO_ENVASE=" & .CODIGO_TIPO_ENVASE)
                Me.cboCultivo.SelectedValue = .CODIGO_CULTIVO
                Me.CboTipoTamaño.SelectedValue = .CODIGO_TIPO_tamaño
                Me.CboTipoEnvase.SelectedValue = .CODIGO_TIPO_ENVASE
                Me.TxtPeso.Text = .PESO.ToString
            End With
        End If
        oElemento = Nothing

    End Sub

    Private Sub Grabar_Elemento()
        Dim Grabado As Boolean = False
        ' Dim iIndex As Integer = Me.lstbElementos.SelectedIndex

        If txtLEN(Me.TxtPeso.Text) = False Then
            MsgBox("Captúre un valor de peso.", MsgBoxStyle.Information, Me.Name)
            Exit Sub
        End If

        If txtLEN(Me.cboCultivo.SelectedValue.ToString) = False Then
            MsgBox("Seleccione un cultivo.", MsgBoxStyle.Information, Me.Name)
            Exit Sub
        End If

        If txtLEN(Me.CboTipoTamaño.SelectedValue.ToString) = False Then
            MsgBox("Seleccione un tamaño.", MsgBoxStyle.Information, Me.Name)
            Exit Sub
        End If

        If txtLEN(Me.CboTipoEnvase.SelectedValue.ToString) = False Then
            MsgBox("Seleccione un envase.", MsgBoxStyle.Information, Me.Name)
            Exit Sub
        End If

        Select Case Me.Estado
            Case enumEstados.NUEVO, enumEstados.EDICION
                Me.oPesoEnvase = New Class_Embarques_ConfiguracionPesoEnvase
                Try
                    With Me.oPesoEnvase
                        .CODIGO_CULTIVO = Me.cboCultivo.SelectedValue.ToString
                        .CODIGO_TIPO_ENVASE = CInt(Me.CboTipoEnvase.SelectedValue)
                        .CODIGO_TIPO_TAMAÑO = CInt(Me.CboTipoTamaño.SelectedValue)
                        .PESO = CDbl(Me.TxtPeso.Text)
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
                    'Me.lstbElementos.SelectedIndex = -1
                    'Me.lstbElementos.SelectedIndex = iIndex
                Finally
                    oPesoEnvase = Nothing
                End Try
        End Select
    End Sub

#End Region

End Class