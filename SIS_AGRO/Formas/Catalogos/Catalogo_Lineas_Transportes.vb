Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class Catalogo_Lineas_Transportes
    Private oLineasTransportes As New Class_CatLineasTransportes

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
            Me.msgElemento = "LineaTansporte"
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

        Me.TxtCodigoLineaTransporte.Text = Me.oLineasTransportes.CodigoSiguiente
    End Sub

    Private Sub tsbEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbEditar.Click
        Me.Estado = enumEstados.EDICION
        Me.Cambia_Estado()
    End Sub

    Private Sub tsbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGrabar.Click
        Dim sMsg As String = ""
        Select Case Me.Estado
            Case enumEstados.EDICION
                sMsg = " grabar las modificaciones del " & Me.msgElemento & " : " & Me.TxtCodigoLineaTransporte.Text
            Case enumEstados.NUEVO
                sMsg = " agregar el " & Me.msgElemento & " : " & Me.TxtCodigoLineaTransporte.Text
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
        Dim oElementos As New Class_CatLineasTransportes
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

                Me.TxtCodigoLineaTransporte.Enabled = False
                Me.TxtNombreLineaTransporte.Enabled = True
                Me.CboEstatus.Enabled = False
                Me.InicializaElemento()
                Me.TxtNombreLineaTransporte.Focus()

            Case enumEstados.EDICION
                Me.gBoxInformacion.Enabled = True
                Me.gBoxBusquedaRapida.Enabled = False
                Me.tssLabelEstado.Text = "Edición"
                Me.tsbNuevo.Enabled = False
                Me.tsbEditar.Enabled = False
                Me.tsbGrabar.Enabled = True
                Me.tsbCancelar.Enabled = True

                Me.TxtCodigoLineaTransporte.Enabled = False
                Me.TxtNombreLineaTransporte.Enabled = True
                Me.CboEstatus.Enabled = True
                Me.TxtNombreLineaTransporte.Focus()

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
        Me.TxtCodigoLineaTransporte.Text = ""
        Me.TxtNombreLineaTransporte.Text = ""
        Me.txtCuentaContableFlete.Text = ""
        Me.CboEstatus.Text = "A"
    End Sub

    Private Sub DesplegarElementos()
        Dim oElementos As New Class_CatLineasTransportes
        With Me.Grid
            .DataSource = oElementos.ObtenerElementos
            .Columns("CODIGO_LINEA_TRANSPORTE").Width = 50
            .Columns("NOMBRE_LINEA_TRANSPORTE").Width = 200
        End With

    End Sub

    Private Sub LlenaElemento(ByVal iCodigo_Elemento As String)
        Dim oElemento As New Class_CatLineasTransportes
        Dim oCuentaContableFlete As New Class_CatCuentas
        oElemento.CODIGO_LINEA_TRANSPORTE = iCodigo_Elemento
        If oElemento.Consultar Then
            With oElemento
                Me.TxtCodigoLineaTransporte.Text = .CODIGO_LINEA_TRANSPORTE.ToString
                Me.TxtNombreLineaTransporte.Text = .NOMBRE_LINEA_TRANSPORTE.ToString
                Me.txtCuentaContableFlete.Text = .CUENTA_CONTABLE_FLETERO.ToString
                oCuentaContableFlete = New Class_CatCuentas(.CUENTA_CONTABLE_FLETERO.ToString)
                Me.LblCuentaFlete.Text = oCuentaContableFlete.NOMBRE_CUENTA
                Me.CboEstatus.Text = .Estatus
            End With
        End If
        oElemento = Nothing
    End Sub

    Private Sub Grabar_Elemento()
        Dim oElemento As New Class_CatLineasTransportes
        Dim Grabado As Boolean = False

        If txtLEN(Me.TxtNombreLineaTransporte.Text) = False Then
            MsgBox("Asígne el nombre de la linea de transporte", MsgBoxStyle.Exclamation, Me.Text)
            Me.TxtNombreLineaTransporte.Focus()
            Exit Sub
        End If

        Select Case Me.Estado
            Case enumEstados.NUEVO, enumEstados.EDICION
                oElemento = New Class_CatLineasTransportes
                Try
                    With oElemento
                        .CODIGO_LINEA_TRANSPORTE = Me.TxtCodigoLineaTransporte.Text
                        .NOMBRE_LINEA_TRANSPORTE = Me.TxtNombreLineaTransporte.Text
                        .CUENTA_CONTABLE_FLETERO = Me.txtCuentaContableFlete.Text
                        .Estatus = Me.CboEstatus.Text

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
        Dim sFolio As String = Me.TxtCodigoLineaTransporte.Text
        Me.InicializaElemento()
        Me.oLineasTransportes = New Class_CatLineasTransportes
        Me.oLineasTransportes.CODIGO_LINEA_TRANSPORTE = Me.TxtCodigoLineaTransporte.Text

        If Me.oLineasTransportes.Consultar = False Then
            Me.Estado = enumEstados.NUEVO
            Me.Cambia_Estado()
            Exit Function
        Else
            With Me.oLineasTransportes
                Me.TxtCodigoLineaTransporte.Text = .CODIGO_LINEA_TRANSPORTE
                Me.TxtNombreLineaTransporte.Text = .NOMBRE_LINEA_TRANSPORTE
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
        Me.LlenaElemento(Me.Grid.CurrentRow.Cells("CODIGO_LINEA_TRANSPORTE").Value.ToString)
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
        Dim oElementos As New Class_CatLineasTransportes
        Me.Grid.DataSource = Nothing

        With Me.Grid
            .DataSource = oElementos.ObtenerElementosFiltro(Me.txtFiltro.Text)
            .Columns("CODIGO_LINEA_TRANSPORTE").Width = 50
            .Columns("NOMBRE_LINEA_TRANSPORTE").Width = 200
        End With
    End Sub
    Private Sub txtFiltro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFiltro.KeyPress
        txtNoBeep(e)
        txtNoComilla(e)
    End Sub
    Private Sub txtFiltro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFiltro.KeyDown
        Dim oElementosFiltro As New Class_CatLineasTransportes
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Return Or e.KeyCode = Keys.Back Then
            Me.Grid.DataSource = Nothing

            With Me.Grid
                .DataSource = oElementosFiltro.ObtenerElementosFiltro(Me.txtFiltro.Text)
                .Columns("CODIGO_LINEA_TRANSPORTE").Width = 50
                .Columns("NOMBRE_LINEA_TRANSPORTE").Width = 200
            End With
        End If
    End Sub
#End Region

#Region "Eventos Genericos"

    'Private Sub txt_Keydown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNombreLineaTransporte.KeyDown ', txtRfc.KeyDown, txtCurp.KeyDown
    '    If e.KeyCode = Keys.Return Then
    '        Select Case Me.Estado
    '            Case enumEstados.EDICION
    '                SendKeys.Send("{TAB}")
    '            Case enumEstados.NUEVO
    '                SendKeys.Send("{TAB}")
    '        End Select
    '    End If
    'End Sub

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

    Private Sub TxtNombreLineaTransporte_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNombreLineaTransporte.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.txtCuentaContableFlete.Focus()
        End If

    End Sub

    Private Sub txtCuentaContableFlete_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCuentaContableFlete.KeyDown
        Select Case e.KeyCode
            Case Keys.F6
busqueda_Visual:
                Dim oCuenta As New Class_CatCuentas
                Dim sCuenta As String = oCuenta.BusquedaVisual_PorCodigoFiltrandoTipoOperacion
                If sCuenta.Length > 0 Then
                    Me.txtCuentaContableFlete.Text = sCuenta
                    sCuenta = Replace(sCuenta, "'", "''")
                    Dim sql As New Class_find("Select CUENTA_CONTABLE,NOMBRE_CUENTA From CON_CAT_CUENTAS Where CUENTA_CONTABLE='" & sCuenta & "' AND ESMAYOR=0 ")
                    Me.txtCuentaContableFlete.Text = sCuenta
                    Me.LblCuentaFlete.Text = sql.Result2
                    sql = Nothing
                End If

            Case Keys.F7
                Dim oCuenta As New Class_CatCuentas
                Dim sCuenta As String = oCuenta.BusquedaVisual_PorNombreFiltrandoTipoOperacion
                If sCuenta.Length > 0 Then
                    Me.txtCuentaContableFlete.Text = sCuenta
                    sCuenta = Replace(sCuenta, "'", "''")
                    Dim sql As New Class_find("Select CUENTA_CONTABLE,NOMBRE_CUENTA From CON_CAT_CUENTAS Where CUENTA_CONTABLE='" & sCuenta & "' AND ESMAYOR=0 ")
                    Me.txtCuentaContableFlete.Text = sCuenta
                    Me.LblCuentaFlete.Text = sql.Result2
                    sql = Nothing
                End If

            Case Keys.Return
                Dim sql As New Class_find("Select NOMBRE_CUENTA From CON_CAT_CUENTAS Where CUENTA_CONTABLE='" & Me.txtCuentaContableFlete.Text & "' AND ESMAYOR=0  ")
                If sql.Result1 = "" Then
                    Me.txtCuentaContableFlete.Text = ""
                    Me.LblCuentaFlete.Text = ""
                Else
                    Me.LblCuentaFlete.Text = sql.Result1
                End If

                sql = Nothing

                Select Case Me.Estado
                    Case enumEstados.EDICION
                        Me.CboEstatus.Focus()
                    Case enumEstados.NUEVO
                        tsbGrabar.PerformClick()
                End Select

        End Select

    End Sub

End Class
