Option Strict On

Public Class Catalogo_Remolques
    Private oRemolque As New Class_CatRemolques

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
            Me.msgElemento = "Remolque"
            Me.msgElementos = "Remolques"
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
        Me.TxtCodigoRemolque.Text = Me.oRemolque.CodigoSiguiente
    End Sub

    Private Sub tsbEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbEditar.Click
        Me.Estado = enumEstados.EDICION
        Me.Cambia_Estado()
    End Sub

    Private Sub tsbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGrabar.Click
        Dim sMsg As String = ""
        Select Case Me.Estado
            Case enumEstados.EDICION
                sMsg = " grabar las modificaciones del " & Me.msgElemento & " : " & Me.TxtCodigoRemolque.Text
            Case enumEstados.NUEVO
                sMsg = " agregar el " & Me.msgElemento & " : " & Me.TxtCodigoRemolque.Text
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

    Private Sub tsbImprimirListado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim oElementos As New Class_CatTransportes
        oElementos.Imprimir_Listado()
        oElementos = Nothing
    End Sub
#End Region

#Region "Métodos y procedimientos"
    Private Sub Refrescar()
        Me.DesplegarElementos()
    End Sub

    Private Sub Cambia_Estado()
        Const sProcedure As String = "Cambia_Estado"
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

                    Me.TxtCodigoRemolque.Enabled = False
                    Me.TxtNombre.Enabled = True
                    Me.TxtCodigoTipoRemolque.Enabled = True
                    Me.txtPlaca.Enabled = True
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

                    Me.TxtCodigoRemolque.Enabled = False
                    Me.TxtNombre.Enabled = True
                    Me.TxtCodigoTipoRemolque.Enabled = True
                    Me.txtPlaca.Enabled = True
                    Me.CboEstatus.Enabled = True

                Case enumEstados.CONSULTA
                    Me.gBoxInformacion.Enabled = False
                    Me.gBoxBusquedaRapida.Enabled = True
                    Me.tssLabelEstado.Text = "Consultando"
                    Me.tsbNuevo.Enabled = True
                    Me.tsbEditar.Enabled = True
                    Me.tsbGrabar.Enabled = False
                    Me.tsbCancelar.Enabled = False
                    Me.txtFiltro.Focus()
            End Select
            Application.DoEvents()
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Sub InicializaElemento()
        Const sProcedure As String = "InicializaElemento"
        Try
            Me.TxtCodigoRemolque.Text = ""
            Me.TxtNombre.Text = ""
            Me.TxtCodigoTipoRemolque.Text = ""
            Me.LblNombreTipoRemolque.Text = ""
            Me.txtPlaca.Text = ""
            Me.CboEstatus.SelectedIndex = 0
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Sub DesplegarElementos()
        Const sProcedure As String = "DesplegarElementos"
        Try
            Dim oElementos As New Class_CatRemolques
            With Me.Grid
                .DataSource = oElementos.ObtenerElementos()
                .Columns("CODIGO_REMOLQUE").Width = 50
                .Columns("NOMBRE_REMOLQUE").Width = 200
            End With
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Sub LlenaElemento(ByVal iCodigo_Elemento As String)
        Const sProcedure As String = "LlenaElemento"
        Try
            oRemolque = New Class_CatRemolques
            oRemolque.CODIGO_REMOLQUE = iCodigo_Elemento

            If oRemolque.Consultar = True Then
                With oRemolque
                    Me.TxtCodigoRemolque.Text = .CODIGO_REMOLQUE.ToString
                    Me.TxtNombre.Text = .NOMBRE_REMOLQUE
                    Me.txtPlaca.Text = .PLACA
                    Me.TxtCodigoTipoRemolque.Text = .CODIGO_TIPO_REMOLQUE.ToString

                    If txtLEN(Me.TxtCodigoTipoRemolque.Text) Then
                        Dim sql As New Class_find("SELECT NOMBRE_TIPO_REMOLQUE FROM CFDI_CAT_TIPOS_REMOLQUES WHERE CODIGO_TIPO_REMOLQUE='" & .CODIGO_TIPO_REMOLQUE & "' ")

                        If txtLEN(sql.Result1) Then
                            Me.LblNombreTipoRemolque.Text = sql.Result1.ToString
                        End If
                    End If

                    Me.txtPlaca.Text = .PLACA.ToString

                    If .ESTATUS = "A" Then
                        Me.CboEstatus.SelectedIndex = 0
                    Else
                        Me.CboEstatus.SelectedIndex = 1
                    End If

                End With
            End If
            oRemolque = Nothing
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Function Grabar_Elemento() As Boolean
        Const sProcedure As String = "Grabar_Elemento"

        oRemolque = New Class_CatRemolques
        Dim bResultado As Boolean = False

        If txtLEN(Me.TxtNombre.Text) = False Then
            MsgBox("Asígne el nombre del remolque.", MsgBoxStyle.Exclamation, sProcedure)
            Me.TxtNombre.Focus()
            Return False
        End If

        If txtLEN(Me.TxtCodigoTipoRemolque.Text) = False Then
            MsgBox("Asígne el código de tipo de remolque.", MsgBoxStyle.Exclamation, sProcedure)
            Me.TxtCodigoTipoRemolque.Focus()
            Return False
        End If

        If txtLEN(Me.txtPlaca.Text) = False Then
            MsgBox("Asígne la placa del remolque", MsgBoxStyle.Exclamation, sProcedure)
            Me.txtPlaca.Focus()
            Return False
        End If

        Select Case Me.Estado
            Case enumEstados.NUEVO, enumEstados.EDICION

                Try
                    With oRemolque
                        .CODIGO_REMOLQUE = Me.TxtCodigoRemolque.Text
                        .NOMBRE_REMOLQUE = Me.TxtNombre.Text
                        .CODIGO_TIPO_REMOLQUE = Me.TxtCodigoTipoRemolque.Text
                        .PLACA = Me.txtPlaca.Text.ToUpper
                        .ESTATUS = Strings.Left(Me.CboEstatus.Text, 1)
                        .CODIGO_USUARIO_CREO = Usuario.Codigo_Usuario.ToString
                        .FECHA_CREO = Date.Now
                        .CODIGO_USUARIO_MODIFICO = Usuario.Codigo_Usuario.ToString
                        .FECHA_MODIFICO = Date.Now

                        Select Case Me.Estado

                            Case enumEstados.NUEVO
                                If .Grabar("INSERTAR") Then
                                    bResultado = True
                                    Me.Estado = enumEstados.CONSULTA
                                End If
                            Case enumEstados.EDICION
                                If .Grabar("ACTUALIZAR") Then
                                    bResultado = True
                                    Me.Estado = enumEstados.CONSULTA
                                End If
                        End Select

                        If bResultado Then
                            MsgBox(Me.msgElemento & " Grabado satisfactoriamente.", MsgBoxStyle.Information, Me.Name)
                            Me.Refrescar()
                            Me.Cambia_Estado()
                        End If

                    End With
                Catch ex As Exception
                    HandleError(Me.Name, sProcedure, ex)
                    Me.Estado = enumEstados.CONSULTA
                    Me.Cambia_Estado()
                Finally
                    oRemolque = Nothing
                End Try
        End Select

        Return bResultado
    End Function

#End Region

#Region "Eventos de objetos"
#Region "Eventos de la lista de elementos"
    Private Sub Grid_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grid.CellClick
        Me.LlenaElemento(Me.Grid.CurrentRow.Cells("CODIGO_REMOLQUE").Value.ToString)
    End Sub

    Private Sub Grid_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grid.CellDoubleClick
        Me.Estado = enumEstados.EDICION
        Me.Cambia_Estado()
    End Sub
#End Region

#Region " Eventos de TxtFiltro"
    Private Sub txtFiltro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFiltro.TextChanged
        Dim oElementos As New Class_CatTransportes
        Me.Grid.DataSource = Nothing

        With Me.Grid
            .DataSource = oElementos.ObtenerElementosFiltro(Me.txtFiltro.Text)
            .Columns("CODIGO_REMOLQUE").Width = 50
            .Columns("NOMBRE_REMOLQUE").Width = 200
        End With
    End Sub
    Private Sub txtFiltro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFiltro.KeyPress
        txtNoBeep(e)
        txtNoComilla(e)
    End Sub
    Private Sub txtFiltro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFiltro.KeyDown
        Dim oElementosFiltro As New Class_CatTransportes
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Return Or e.KeyCode = Keys.Back Then
            Me.Grid.DataSource = Nothing

            With Me.Grid
                .DataSource = oElementosFiltro.ObtenerElementosFiltro(Me.txtFiltro.Text)
                .Columns("CODIGO_REMOLQUE").Width = 50
                .Columns("NOMBRE_REMOLQUE").Width = 200
            End With
        End If
    End Sub
#End Region

#Region "Eventos Genericos"
    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNombre.KeyPress, TxtCodigoTipoRemolque.KeyPress, txtPlaca.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub txt_Keydown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPlaca.KeyDown, TxtNombre.KeyDown
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


#Region "Keydown específicos"
    Private Sub TxtCododigoRemolque_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodigoRemolque.KeyDown
        Select Case e.KeyCode
            Case Keys.Return
                txtTAB(e)
            Case Keys.Escape
        End Select
    End Sub

    Private Sub CboEstatus_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CboEstatus.KeyDown
        If e.KeyCode = Keys.Return Then
            tsbGrabar.PerformClick()
        End If
    End Sub

    Private Sub TxtCodigoTipoRemolque_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodigoTipoRemolque.KeyDown
        Dim oCfdiTiposRemolques As New Class_CfdiCatTiposRemolques

        Select Case e.KeyCode
            Case Keys.F6
busqueda_Visual:

                Dim sTipoRemolque As String = oCfdiTiposRemolques.BusquedaVisual_PorDescripcion
                If sTipoRemolque.Length > 0 Then
                    Me.TxtCodigoTipoRemolque.Text = sTipoRemolque
                    Dim sql As New Class_find("Select NOMBRE_TIPO_REMOLQUE FROM CFDI_CAT_TIPOS_REMOLQUES Where CODIGO_TIPO_REMOLQUE='" & sTipoRemolque & "' ")
                    Me.LblNombreTipoRemolque.Text = sql.Result1
                    sql = Nothing
                End If
            Case Keys.Return
                Dim sql As New Class_find("Select NOMBRE_TIPO_REMOLQUE FROM CFDI_CAT_TIPOS_REMOLQUES Where CODIGO_TIPO_REMOLQUE='" & Me.TxtCodigoTipoRemolque.Text & "' ")
                If sql.Result1 = "" Then
                    GoTo busqueda_Visual
                Else
                    Me.LblNombreTipoRemolque.Text = sql.Result1
                End If

                sql = Nothing

                tsbGrabar.PerformClick()

        End Select
    End Sub

#End Region

#Region "Validating específicos"

#End Region

    Private Sub CboFiltroHoja_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Refrescar()
    End Sub

#End Region

End Class


