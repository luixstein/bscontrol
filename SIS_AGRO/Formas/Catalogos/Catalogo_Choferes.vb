Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class Catalogo_Choferes
    Private oChoferes As New Class_CatChoferes

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
            Me.msgElemento = "Chofer"
            Me.Run = False
            Estado = enumEstados.CONSULTA
            Me.DesplegarElementos()
            Me.Cambia_Estado()
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

        Me.TxtCodigoChofer.Text = Me.oChoferes.CodigoSiguiente
    End Sub

    Private Sub tsbEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbEditar.Click
        Me.Estado = enumEstados.EDICION
        Me.Cambia_Estado()
    End Sub

    Private Sub tsbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGrabar.Click
        Dim sMsg As String = ""
        Select Case Me.Estado
            Case enumEstados.EDICION
                sMsg = " grabar las modificaciones del " & Me.msgElemento & " : " & Me.TxtCodigoChofer.Text
            Case enumEstados.NUEVO
                sMsg = " agregar el " & Me.msgElemento & " : " & Me.TxtCodigoChofer.Text
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
        Dim oElementos As New Class_CatChoferes
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

                Me.TxtCodigoChofer.Enabled = False
                Me.TxtNombreChofer.Enabled = True
                Me.CboEstatus.Enabled = False
                Me.InicializaElemento()
                Me.TxtCodigoChofer.Focus()

                Me.InicializaElemento()

                Me.TxtNombreChofer.Focus()

            Case enumEstados.EDICION
                Me.gBoxInformacion.Enabled = True
                Me.gBoxBusquedaRapida.Enabled = False
                Me.tssLabelEstado.Text = "Edición"
                Me.tsbNuevo.Enabled = False
                Me.tsbEditar.Enabled = False
                Me.tsbGrabar.Enabled = True
                Me.tsbCancelar.Enabled = True

                Me.TxtCodigoChofer.Enabled = False
                Me.TxtNombreChofer.Enabled = True
                Me.CboEstatus.Enabled = True

                Me.TxtNombreChofer.Focus()

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
        Me.TxtCodigoChofer.Text = ""
        Me.TxtNombreChofer.Text = ""
        Me.txtLiciencia.Text = ""
        Me.txtVisa.Text = ""
        Me.txtRfc.Text = ""
        Me.txtDomicilio.Text = ""
        Me.txtTelefono.Text = ""
        Me.CboEstatus.Text = "A"
    End Sub

    Private Sub DesplegarElementos()
        Dim oElementos As New Class_CatChoferes
        With Me.Grid
            .DataSource = oElementos.ObtenerElementos
            .Columns("CODIGO_CHOFER").Width = 50
            .Columns("NOMBRE_CHOFER").Width = 250
        End With

    End Sub

    Private Sub LlenaElemento(ByVal iCodigo_Elemento As String)
        Dim oElemento As New Class_CatChoferes
        oElemento.CODIGO_CHOFER = iCodigo_Elemento
        If oElemento.Consultar Then
            With oElemento
                Me.TxtCodigoChofer.Text = .CODIGO_CHOFER.ToString
                Me.TxtNombreChofer.Text = .NOMBRE_CHOFER.ToString
                Me.txtLiciencia.Text = .LICENCIA.ToString
                Me.txtVisa.Text = .VISA.ToString
                Me.txtRfc.Text = .RFC.ToString
                Me.txtDomicilio.Text = .DOMICILIO.ToString
                Me.CboEstatus.Text = .Estatus
                Me.txtTelefono.Text = .TELEFONO.ToString
            End With
        End If
        oElemento = Nothing
    End Sub

    Private Sub Grabar_Elemento()
        Dim oElemento As New Class_CatChoferes
        Dim Grabado As Boolean = False

        If txtLEN(Me.TxtNombreChofer.Text) = False Then
            MsgBox("Asígne el nombre del chofer", MsgBoxStyle.Exclamation, Me.Text)
            Me.TxtNombreChofer.Focus()
            Exit Sub
        End If

        If txtLEN(Me.txtLiciencia.Text) = False Then
            MsgBox("Asígne la licencia del chofer", MsgBoxStyle.Exclamation, Me.Text)
            Me.txtLiciencia.Focus()
            Exit Sub
        End If

        Select Case Me.Estado
            Case enumEstados.NUEVO, enumEstados.EDICION
                oElemento = New Class_CatChoferes
                Try
                    With oElemento
                        .CODIGO_CHOFER = Me.TxtCodigoChofer.Text
                        .NOMBRE_CHOFER = Me.TxtNombreChofer.Text
                        .LICENCIA = Me.txtLiciencia.Text
                        .VISA = Me.txtVisa.Text
                        .RFC = Me.txtRfc.Text
                        .DOMICILIO = Me.txtDomicilio.Text
                        .Estatus = Me.CboEstatus.Text
                        .TELEFONO = Me.txtTelefono.Text

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

    Private Function Consultar() As Boolean
        Dim sFolio As String = Me.TxtCodigoChofer.Text
        Me.InicializaElemento()
        Me.oChoferes = New Class_CatChoferes
        Me.oChoferes.CODIGO_CHOFER = Me.TxtCodigoChofer.Text

        If Me.oChoferes.Consultar = False Then
            Me.Estado = enumEstados.NUEVO
            Me.Cambia_Estado()
            Exit Function
        Else
            With Me.oChoferes
                Me.TxtCodigoChofer.Text = .CODIGO_CHOFER
                Me.TxtNombreChofer.Text = .NOMBRE_CHOFER
                Me.txtLiciencia.Text = .LICENCIA
                Me.txtVisa.Text = .VISA
                Me.txtRfc.Text = .RFC
                Me.txtDomicilio.Text = .DOMICILIO
                Me.CboEstatus.SelectedText = .Estatus
                Me.txtTelefono.Text = .TELEFONO.ToString
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
        Me.LlenaElemento(Me.Grid.CurrentRow.Cells("CODIGO_CHOFER").Value.ToString)
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
        Dim oElementos As New Class_CatChoferes
        Me.Grid.DataSource = Nothing

        With Me.Grid
            .DataSource = oElementos.ObtenerElementosFiltro(Me.txtFiltro.Text)
            .Columns("CODIGO_CHOFER").Width = 50
            .Columns("NOMBRE_CHOFER").Width = 250
        End With
    End Sub
    Private Sub txtFiltro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFiltro.KeyPress
        txtNoBeep(e)
        txtNoComilla(e)
    End Sub

    Private Sub txtFiltro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFiltro.KeyDown
        Dim oElementosFiltro As New Class_CatChoferes
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Return Or e.KeyCode = Keys.Back Then
            Me.Grid.DataSource = Nothing

            With Me.Grid
                .DataSource = oElementosFiltro.ObtenerElementosFiltro(Me.txtFiltro.Text)
                .Columns("CODIGO_CHOFER").Width = 50
                .Columns("NOMBRE_CHOFER").Width = 250
            End With
        End If
    End Sub
#End Region

#Region "Eventos Genericos"
    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CboEstatus.KeyPress, txtDomicilio.KeyPress, TxtNombreChofer.KeyPress, txtLiciencia.KeyPress, txtVisa.KeyPress, txtRfc.KeyPress, txtTelefono.KeyPress
        txtNoBeep(e)
    End Sub

    'Private Sub txt_Keydown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNombreChofer.KeyDown, txtLiciencia.KeyDown, txtVisa.KeyDown, txtRfc.KeyDown
    '    If e.KeyCode = Keys.Return Then
    '        SendKeys.Send("{TAB}")
    '    End If
    'End Sub

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
    Private Sub TxtNombreChofer_Keydown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNombreChofer.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.txtLiciencia.Focus()
        End If
    End Sub

    Private Sub txtLiciencia_Keydown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLiciencia.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.txtVisa.Focus()
        End If
    End Sub

    Private Sub txtVisa_Keydown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtVisa.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.txtRfc.Focus()
        End If
    End Sub

    Private Sub txtRfc_Keydown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRfc.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.txtDomicilio.Focus()
        End If
    End Sub

    Private Sub txtDomicilio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDomicilio.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.txtTelefono.Focus()
        End If
    End Sub

    Private Sub txtTelefono_Keydown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTelefono.KeyDown
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

    Private Sub CboFiltroHoja_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Refrescar()
    End Sub

#End Region

    #End Region
    
End Class

