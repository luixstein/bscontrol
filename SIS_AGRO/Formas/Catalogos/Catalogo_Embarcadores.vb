Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class Catalogo_Embarcadores
    Dim oEmbarcadores As New Class_CatEmbarcadores

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

#Region "Constructor y destructor"
    'Inicializa al objeto.
    Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

        Try
            Me.msgElemento = "Embarcador"
            Me.msgElementos = "Embarcadores"
            Me.Run = False
            Estado = enumEstados.CONSULTA
            Me.DesplegarElementos()
            Me.Cambia_Estado()
            Me.CargaEstados()
            Me.cboEstado.SelectedValue = "SIN"
            Me.CboEstatus.SelectedIndex = 0
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

        Me.txtCodigoEmbarcador.Text = Me.oEmbarcadores.CodigoSiguiente
    End Sub

    Private Sub tsbEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbEditar.Click
        Me.Estado = enumEstados.EDICION
        Me.Cambia_Estado()
    End Sub

    Private Sub tsbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGrabar.Click
        Dim sMsg As String = ""
        Select Case Me.Estado
            Case enumEstados.EDICION
                sMsg = " grabar las modificaciones del " & Me.msgElemento & " : " & Me.txtCodigoEmbarcador.Text
            Case enumEstados.NUEVO
                sMsg = " agregar el " & Me.msgElemento & " : " & Me.txtCodigoEmbarcador.Text
        End Select
        sMsg = "Deseas " & sMsg & " ?"
        If MsgBox(sMsg, CType(CInt(MsgBoxStyle.Question) + CInt(MsgBoxStyle.YesNo), MsgBoxStyle)) = MsgBoxResult.Yes Then
            Me.Grabar_Elemento()
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
        Dim oElementos As New Class_CatClientes

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
                Me.tssLabelEstado.Text = "Agregando nuevo " & Me.msgElemento
                Me.tsbNuevo.Enabled = False
                Me.tsbEditar.Enabled = False
                Me.tsbGrabar.Enabled = True
                Me.tsbCancelar.Enabled = True

                Me.txtCodigoEmbarcador.Enabled = False
                Me.TxtNombreEmbarcador.Enabled = True
                Me.txtRfc.Enabled = True
                Me.txtCurp.Enabled = True
                Me.txtDomicilio.Enabled = True
                Me.txtCiudad.Enabled = True
                Me.cboEstado.Enabled = True
                Me.txtNumeroTelefono.Enabled = True
                Me.txtNumeroCelular.Enabled = True
                Me.TxtFax.Enabled = True
                Me.txtCodigoPostal.Enabled = True
                Me.txtRepresentante.Enabled = True
                Me.txtRfcRepresentante.Enabled = True
                Me.txtFda.Enabled = True
                Me.CboEstatus.Enabled = False

                Me.InicializaElemento()

                Me.TxtNombreEmbarcador.Focus()

            Case enumEstados.EDICION
                Me.gBoxInformacion.Enabled = True
                Me.gBoxBusquedaRapida.Enabled = False
                Me.tssLabelEstado.Text = "Edición"
                Me.tsbNuevo.Enabled = False
                Me.tsbEditar.Enabled = False
                Me.tsbGrabar.Enabled = True
                Me.tsbCancelar.Enabled = True

                Me.txtCodigoEmbarcador.Enabled = False
                Me.TxtNombreEmbarcador.Enabled = True
                Me.txtRfc.Enabled = True
                Me.txtCurp.Enabled = True
                Me.txtDomicilio.Enabled = True
                Me.txtCiudad.Enabled = True
                Me.cboEstado.Enabled = True
                Me.txtNumeroTelefono.Enabled = True
                Me.txtNumeroCelular.Enabled = True
                Me.TxtFax.Enabled = True
                Me.txtCodigoPostal.Enabled = True
                Me.txtRepresentante.Enabled = True
                Me.txtRfcRepresentante.Enabled = True
                Me.txtFda.Enabled = True
                Me.CboEstatus.Enabled = True

                Me.TxtNombreEmbarcador.Focus()

            Case Else
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
        Me.txtCodigoEmbarcador.Text = ""
        Me.TxtNombreEmbarcador.Text = ""
        Me.txtRfc.Text = ""
        Me.txtCurp.Text = ""
        Me.txtDomicilio.Text = ""
        Me.txtCiudad.Text = ""
        Me.txtNumeroTelefono.Text = ""
        Me.txtNumeroCelular.Text = ""
        Me.TxtFax.Text = ""
        Me.txtCodigoPostal.Text = ""
        Me.txtRepresentante.Text = ""
        Me.txtRfcRepresentante.Text = ""
        Me.txtFda.Text = ""
        Me.CboEstatus.SelectedIndex = 0
        Me.cboEstado.SelectedValue = "SIN"
    End Sub

    Private Sub DesplegarElementos()
        Dim oElementos As New Class_CatEmbarcadores
        With Me.Grid
            .DataSource = oElementos.ObtenerElementos
            .Columns("CODIGO_EMBARCADOR").Width = 50
            .Columns("NOMBRE_EMBARCADOR").Width = 250
        End With

    End Sub

    Private Sub LlenaElemento(ByVal iCodigo_Elemento As String)
        Dim oElemento As New Class_CatEmbarcadores
        oElemento.CODIGO_EMBARCADOR = iCodigo_Elemento
        If oElemento.Consultar Then
            With oElemento
                Me.txtCodigoEmbarcador.Text = .CODIGO_EMBARCADOR
                Me.TxtNombreEmbarcador.Text = .NOMBRE_EMBARCADOR
                Me.txtRfc.Text = .RFC
                Me.txtCurp.Text = .CURP
                Me.txtDomicilio.Text = .DOMICILIO
                Me.txtCiudad.Text = .CIUDAD
                Me.cboEstado.SelectedValue = .ESTADO
                Me.txtNumeroTelefono.Text = .TELEFONO
                Me.txtNumeroCelular.Text = .CELULAR
                Me.TxtFax.Text = .FAX
                Me.txtCodigoPostal.Text = .CODIGO_POSTAL
                Me.txtRepresentante.Text = .REPRESENTANTE
                Me.txtRfcRepresentante.Text = .RFC_REPRESENTANTE
                Me.txtFda.Text = .FDA
                Me.cboEstado.SelectedValue = .ESTADO
                If .Status = "A" Then
                    Me.CboEstatus.SelectedIndex = 0
                Else
                    Me.CboEstatus.SelectedIndex = 1
                End If
            End With
        End If
        oElemento = Nothing
    End Sub

    Private Sub Grabar_Elemento()
        Dim oElemento As New Class_CatEmbarcadores
        Dim Grabado As Boolean = False

        If txtLEN(Me.TxtNombreEmbarcador.Text) = False Then
            MsgBox("Asígne el nombre del embarcador", MsgBoxStyle.Exclamation, Me.Text)
            Me.TxtNombreEmbarcador.Focus()
            Exit Sub
        End If

        Select Case Me.Estado
            Case enumEstados.NUEVO, enumEstados.EDICION
                oElemento = New Class_CatEmbarcadores
                Try
                    With oElemento
                        .CODIGO_EMBARCADOR = Me.txtCodigoEmbarcador.Text
                        .NOMBRE_EMBARCADOR = Me.TxtNombreEmbarcador.Text
                        .RFC = Me.txtRfc.Text
                        .CURP = Me.txtCurp.Text
                        .DOMICILIO = Me.txtDomicilio.Text
                        .CIUDAD = Me.txtCiudad.Text
                        .ESTADO = Me.cboEstado.SelectedValue.ToString
                        .TELEFONO = Me.txtNumeroTelefono.Text
                        .CELULAR = Me.txtNumeroCelular.Text
                        .FAX = Me.TxtFax.Text
                        .CODIGO_POSTAL = Me.txtCodigoPostal.Text
                        .REPRESENTANTE = Me.txtRepresentante.Text
                        .RFC_REPRESENTANTE = Me.txtRfcRepresentante.Text
                        .FDA = Me.txtFda.Text
                        .Status = Strings.Left(Me.CboEstatus.Text, 1)

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

    Private Function LlenaComboEstatus() As Boolean
        Me.CboEstatus.Items.Add("A")
        Me.CboEstatus.Items.Add("B")

        Me.CboEstatus.SelectedItem = "A"

    End Function

    Private Sub CargaEstados()
        Dim oElementos As New Class_CatClientes
        With Me.cboEstado
            .DisplayMember = "NOMBRE_ESTADO"
            .ValueMember = "CODIGO_ESTADO"

            Dim dView As New Data.DataView(oElementos.ObtenerEstados)
            dView.Sort = "NOMBRE_ESTADO"
            .DataSource = dView
            If dView.Count > 0 Then
                .SelectedIndex = 0
            End If
        End With
    End Sub

    Private Function Consultar() As Boolean
        Dim sFolio As String = Me.txtCodigoEmbarcador.Text
        Me.InicializaElemento()
        Me.oEmbarcadores = New Class_CatEmbarcadores
        Me.oEmbarcadores.CODIGO_EMBARCADOR = Me.txtCodigoEmbarcador.Text

        If Me.oEmbarcadores.Consultar = False Then
            Me.Estado = enumEstados.NUEVO
            Me.Cambia_Estado()
            Exit Function
        Else
            With Me.oEmbarcadores
                Me.txtCodigoEmbarcador.Text = .CODIGO_EMBARCADOR
                Me.TxtNombreEmbarcador.Text = .NOMBRE_EMBARCADOR
                Me.txtRfc.Text = .RFC
                Me.txtCurp.Text = .CURP
                Me.txtDomicilio.Text = .DOMICILIO
                Me.txtCiudad.Text = .CIUDAD
                Me.cboEstado.SelectedValue = .ESTADO
                Me.txtNumeroTelefono.Text = .TELEFONO
                Me.txtNumeroCelular.Text = .CELULAR
                Me.TxtFax.Text = .FAX
                Me.txtCodigoPostal.Text = .CODIGO_POSTAL
                Me.txtRepresentante.Text = .REPRESENTANTE
                Me.txtRfcRepresentante.Text = .RFC_REPRESENTANTE
                Me.txtFda.Text = .FDA.ToString
                Me.CboEstatus.SelectedText = .Estatus
            End With

        End If
        Consultar = True

        Me.Estado = enumEstados.EDICION
        Me.Cambia_Estado()
    End Function

#End Region

#Region "Eventos de objetos"

#Region "Eventos de la lista de elementos"
    Private Sub Grid_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grid.CellClick
        Me.LlenaElemento(Me.Grid.CurrentRow.Cells("CODIGO_EMBARCADOR").Value.ToString)
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
        Dim oElementos As New Class_CatEmbarcadores
        Me.Grid.DataSource = Nothing

        With Me.Grid
            .DataSource = oElementos.ObtenerElementosFiltro(Me.txtFiltro.Text)
            .Columns("CODIGO_EMBARCADOR").Width = 50
            .Columns("NOMBRE_EMBARCADOR").Width = 250
        End With
    End Sub
    Private Sub txtFiltro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFiltro.KeyPress
        txtNoBeep(e)
        txtNoComilla(e)
    End Sub
    Private Sub txtFiltro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFiltro.KeyDown
        Dim oElementosFiltro As New Class_CatEmbarcadores
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Return Or e.KeyCode = Keys.Back Then
            Me.Grid.DataSource = Nothing

            With Me.Grid
                .DataSource = oElementosFiltro.ObtenerElementosFiltro(Me.txtFiltro.Text)
                .Columns("CODIGO_EMBARCADOR").Width = 50
                .Columns("NOMBRE_EMBARCADOR").Width = 250
            End With
        End If
    End Sub
#End Region

#Region "Eventos Genericos"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNombreEmbarcador.KeyPress, txtRfc.KeyPress, txtCurp.KeyPress, txtDomicilio.KeyPress, txtCiudad.KeyPress, cboEstado.KeyPress, txtNumeroTelefono.KeyPress, _
    txtNumeroCelular.KeyPress, TxtFax.KeyPress, txtCodigoPostal.KeyPress, txtCodigoPostal.KeyPress, TxtNombreEmbarcador.KeyPress, txtRfcRepresentante.KeyPress, txtFda.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub txt_Keydown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNombreEmbarcador.KeyDown, txtRfc.KeyDown, txtCurp.KeyDown, _
        txtDomicilio.KeyDown, txtCiudad.KeyDown, cboEstado.KeyDown, txtNumeroTelefono.KeyDown, txtNumeroCelular.KeyDown, TxtFax.KeyDown, txtCodigoPostal.KeyDown, txtRepresentante.KeyDown, txtRfcRepresentante.KeyDown
        If e.KeyCode = Keys.Return Then
            Select Case Me.Estado
                Case enumEstados.EDICION
                    SendKeys.Send("{TAB}")
                Case enumEstados.NUEVO
                    SendKeys.Send("{TAB}")
            End Select
        End If
    End Sub

    Private Sub txtNumericos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumeroCelular.KeyPress, txtNumeroTelefono.KeyPress, TxtFax.KeyPress
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

#End Region

    Private Sub CboFiltroHoja_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Refrescar()
    End Sub

    Private Sub CboEstatus_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CboEstatus.KeyDown
        If e.KeyCode = Keys.Return Then
            tsbGrabar.PerformClick()
        End If
    End Sub

    Private Sub txtFda_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFda.KeyDown
        If e.KeyCode = Keys.Return Then
            Select Case Me.Estado
                Case enumEstados.EDICION
                    SendKeys.Send("{TAB}")
                Case enumEstados.NUEVO
                    tsbGrabar.PerformClick()
            End Select
        End If

    End Sub

End Class