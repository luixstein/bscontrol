Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class Catalogo_Lugares_Entrega
    Private oLugaresEntrega As New Class_CatLugaresEntrega

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
            Me.msgElemento = "Lugar de entrega"
            Me.Run = False
            Estado = enumEstados.CONSULTA
            Me.DesplegarElementos()
            Me.Cambia_Estado()
            'Me.CboEstatus.Text = "A"
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

        Me.TxtCodigoLugarEntrega.Text = Me.oLugaresEntrega.CodigoSiguiente
    End Sub

    Private Sub tsbEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbEditar.Click
        Me.Estado = enumEstados.EDICION
        Me.Cambia_Estado()
    End Sub

    Private Sub tsbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGrabar.Click
        Dim sMsg As String = ""
        Select Case Me.Estado
            Case enumEstados.EDICION
                sMsg = " grabar las modificaciones del " & Me.msgElemento & " : " & Me.TxtCodigoLugarEntrega.Text
            Case enumEstados.NUEVO
                sMsg = " agregar el " & Me.msgElemento & " : " & Me.TxtCodigoLugarEntrega.Text
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
        Dim oElementos As New Class_CatLugaresEntrega
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

                Me.TxtCodigoLugarEntrega.Enabled = False
                Me.TxtNombreLugarEntrega.Enabled = True
                'Me.CboEstatus.Enabled = False
                Me.InicializaElemento()
                Me.TxtCodigoLugarEntrega.Focus()

                Me.InicializaElemento()

                Me.TxtNombreLugarEntrega.Focus()

            Case enumEstados.EDICION
                Me.gBoxInformacion.Enabled = True
                Me.gBoxBusquedaRapida.Enabled = False
                Me.tssLabelEstado.Text = "Editando"
                Me.tsbNuevo.Enabled = False
                Me.tsbEditar.Enabled = False
                Me.tsbGrabar.Enabled = True
                Me.tsbCancelar.Enabled = True

                Me.TxtCodigoLugarEntrega.Enabled = False
                Me.TxtNombreLugarEntrega.Enabled = True
                'me.CboEstatus.Enabled = True

                Me.TxtNombreLugarEntrega.Focus()

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
        Me.TxtCodigoLugarEntrega.Text = ""
        Me.TxtNombreLugarEntrega.Text = ""
        Me.txtImporteFlete.Text = ""
    End Sub

    Private Sub DesplegarElementos()
        Dim oElementos As New Class_CatLugaresEntrega
        With Me.Grid
            .DataSource = oElementos.ObtenerElementosParaReportes
            .Columns("CODIGO_LUGAR_ENTREGA").Width = 50
            .Columns("NOMBRE_LUGAR_ENTREGA").Width = 200
        End With

    End Sub

    Private Sub LlenaElemento(ByVal iCodigo_Elemento As String)
        Dim oElemento As New Class_CatLugaresEntrega
        oElemento.CODIGO_LUGAR_ENTREGA = iCodigo_Elemento
        If oElemento.Consultar Then
            With oElemento
                Me.TxtCodigoLugarEntrega.Text = .CODIGO_LUGAR_ENTREGA.ToString
                Me.TxtNombreLugarEntrega.Text = .NOMBRE_LUGAR_ENTREGA.ToString
                Me.txtImporteFlete.Text = FormatImporteContable(.IMPORTE_FLETE).ToString
            End With
        End If
        oElemento = Nothing
    End Sub

    Private Sub Grabar_Elemento()
        Dim oElemento As New Class_CatLugaresEntrega
        Dim Grabado As Boolean = False

        If txtLEN(Me.TxtNombreLugarEntrega.Text) = False Then
            MsgBox("Asígne el nombre del lugar de entrega.", MsgBoxStyle.Exclamation, Me.Text)
            Me.TxtNombreLugarEntrega.Focus()
            Exit Sub
        End If

        If txtLEN(Me.txtImporteFlete.Text) = False Then
            MsgBox("Capture un importe de flete.", MsgBoxStyle.Exclamation, Me.Text)
            Me.txtImporteFlete.Focus()
            Exit Sub
        End If

        Select Case Me.Estado
            Case enumEstados.NUEVO, enumEstados.EDICION
                oElemento = New Class_CatLugaresEntrega
                Try
                    With oElemento
                        .CODIGO_LUGAR_ENTREGA = Me.TxtCodigoLugarEntrega.Text
                        .NOMBRE_LUGAR_ENTREGA = Me.TxtNombreLugarEntrega.Text
                        .IMPORTE_FLETE = CDec(Me.txtImporteFlete.Text)

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

    Private Function Consultar() As Boolean
        Dim sFolio As String = Me.TxtCodigoLugarEntrega.Text
        Me.InicializaElemento()
        Me.oLugaresEntrega = New Class_CatLugaresEntrega
        Me.oLugaresEntrega.CODIGO_LUGAR_ENTREGA = Me.TxtCodigoLugarEntrega.Text

        If Me.oLugaresEntrega.Consultar = False Then
            Me.Estado = enumEstados.NUEVO
            Me.Cambia_Estado()
            Exit Function
        Else
            With Me.oLugaresEntrega
                Me.TxtCodigoLugarEntrega.Text = .CODIGO_LUGAR_ENTREGA
                Me.TxtNombreLugarEntrega.Text = .NOMBRE_LUGAR_ENTREGA
                Me.txtImporteFlete.Text = CStr(.IMPORTE_FLETE)
                'Me.CboEstatus.SelectedText = .Estatus
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
        Me.LlenaElemento(Me.Grid.CurrentRow.Cells("CODIGO_LUGAR_ENTREGA").Value.ToString)
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
        Dim oElementos As New Class_CatLugaresEntrega
        Me.Grid.DataSource = Nothing

        With Me.Grid
            .DataSource = oElementos.ObtenerElementosFiltro(Me.txtFiltro.Text)
            .Columns("CODIGO_LUGAR_ENTREGA").Width = 50
            .Columns("NOMBRE_LUGAR_ENTREGA").Width = 200
        End With
    End Sub
    Private Sub txtFiltro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFiltro.KeyPress
        txtNoBeep(e)
        txtNoComilla(e)
    End Sub

    Private Sub txtFiltro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFiltro.KeyDown
        Dim oElementosFiltro As New Class_CatLugaresEntrega
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Return Or e.KeyCode = Keys.Back Then
            Me.Grid.DataSource = Nothing

            With Me.Grid
                .DataSource = oElementosFiltro.ObtenerElementosFiltro(Me.txtFiltro.Text)
                .Columns("CODIGO_LUGAR_ENTREGA").Width = 50
                .Columns("NOMBRE_LUGAR_ENTREGA").Width = 200
            End With
        End If
    End Sub
#End Region

#Region "Eventos Genericos"
    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNombreLugarEntrega.KeyPress, txtImporteFlete.KeyPress
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
    Private Sub TxtNombreLugarEntrega_Keydown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNombreLugarEntrega.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.txtImporteFlete.Focus()
        End If
    End Sub

    Private Sub txtImporteFlete_Keydown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtImporteFlete.KeyDown
        If e.KeyCode = Keys.Return Then
            If txtLEN(Me.txtImporteFlete.Text) Then
                Me.txtImporteFlete.Text = FormatImporteContable(CDbl(Me.txtImporteFlete.Text))
            End If
            tsbGrabar.PerformClick()
        End If
    End Sub
#End Region

    Private Sub CboFiltroHoja_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Refrescar()
    End Sub

    Private Sub txtNumerosDecimalKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtImporteFlete.KeyPress
        Dim txt As TextBox = CType(sender, TextBox)
        txtSoloNumerosDecimales(e, txt.Text)
        txtNoBeep(e)
    End Sub
#End Region

End Class