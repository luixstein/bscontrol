Option Strict On

Public Class AcuicolaProyectoSiembra
    Private oProyecto As New Class_ProyectoSiembraAcuicola

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

#Region "Propiedades"
#Region "Propiedades de campos de sistema"
    Public ReadOnly Property Nombre_Clase() As String
        Get
            Return "Class_Acuicola_Parametros_Global"
        End Get
    End Property
#End Region
#End Region

#Region "Constructor y destructor"
    'Inicializa al objeto.
    Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

        Try
            Me.DesplegarDivisiones()
            Me.DesplegarLotes()
            Me.DesplegarAños()

            Me.msgElemento = "proyecto de siembra"
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
        'Me._Conexion.Dispose()
        MyBase.Finalize()
    End Sub
#End Region

#Region "Opciones"
    Private Sub tsbNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbNuevo.Click
        Me.Estado = enumEstados.NUEVO
        Me.Cambia_Estado()
    End Sub

    Private Sub tsbEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbEditar.Click
        Me.Estado = enumEstados.EDICION
        Me.Cambia_Estado()
    End Sub

    Private Sub tsbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGrabar.Click
        If Me.Validar() = False Then
            Return
        End If

        Dim sMsg As String = ""
        Select Case Me.Estado
            Case enumEstados.EDICION
                sMsg = " grabar las modificaciones del "
            Case enumEstados.NUEVO
                sMsg = " agregar el "
            Case Else
                MsgBox("Me.Estado no válido.", MsgBoxStyle.Exclamation, Me.Text)
                Return
        End Select
        sMsg = "Deseas " & sMsg & Me.msgElemento & " ?"
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
        'Me.oProyecto.Imprimir_Listado()
        MsgBox("FALTA")
    End Sub
#End Region

#Region "Eventos de objetos"

    Private Sub AcuicolaProyectoSiembra_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Me.DesplegarDivisiones()
        'Me.DesplegarLotes()
        'Me.DesplegarAños()
    End Sub

    Private Sub CboEstatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboEstatus.SelectedIndexChanged
        If Me.CboEstatus.Text = "T" Then
            Me.GbCierreCiclo.Visible = True
        Else
            Me.GbCierreCiclo.Visible = False
            Me.DtFechaCierre.Value = Date.Now
            Me.TxtFolioEntrada.Text = ""
            Me.TxtKilosCosechados.Text = ""
        End If
    End Sub

#Region "Eventos de la lista de elementos"
    Private Sub Grid_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grid.CellClick
        Me.LlenaElemento(Me.Grid.CurrentRow.Cells("ID_PROYECTO_SIEMBRA").Value.ToString)
    End Sub

    Private Sub Grid_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grid.CellDoubleClick
        Me.Estado = enumEstados.EDICION
        Me.Cambia_Estado()
    End Sub
#End Region

#Region "Eventos de TxtFiltro"
    'Private Sub txtFiltro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFiltro.TextChanged
    '    Me.Grid.DataSource = Nothing
    '    Me.DesplegarElementos()
    'End Sub

    'Private Sub txtFiltro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFiltro.KeyPress
    '    txtNoBeep(e)
    '    txtNoComilla(e)
    'End Sub

    'Private Sub txtFiltro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFiltro.KeyDown
    '    If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Return Or e.KeyCode = Keys.Back Then
    '        Me.Grid.DataSource = Nothing
    '        Me.DesplegarElementos()
    '    End If
    'End Sub

    Private Sub cboEstatusFiltro_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEstatusFiltro.SelectedIndexChanged
        Me.Grid.DataSource = Nothing
        Me.DesplegarElementos()
    End Sub

    Private Sub cboAñoFiltro_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboAñoFiltro.SelectedIndexChanged
        Me.Grid.DataSource = Nothing
        Me.DesplegarElementos()
    End Sub

#End Region

#Region "Eventos Genericos"
    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        txtNoBeep(e)
    End Sub

    Private Sub txt_Keydown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CboEstatus.KeyDown, cboDivision.KeyDown, txtCiclo.KeyDown, dtFecha.KeyDown, cboLote.KeyDown
        If e.KeyCode = Keys.Return Then
            txtTAB(e)
        End If
    End Sub

    Private Sub txtNumerosEnterosKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCiclo.KeyPress
        txtSoloNumerosEnteros(e)
        txtNoBeep(e)
    End Sub

    Private Sub txtNumerosDecimalKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHA.KeyPress
        Dim txt As TextBox = CType(sender, TextBox)
        txtSoloNumerosDecimales(e, txt.Text)
        txtNoBeep(e)
    End Sub
#End Region

#Region "Keydown específicos"
    Private Sub txtHA_KeyDown(sender As Object, e As KeyEventArgs) Handles txtHA.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.tsbGrabar.PerformClick()
        End If
    End Sub
#End Region

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

                    Me.CboEstatus.Enabled = False 'Solo se puede agregar con estatus A
                    Me.cboDivision.Enabled = True
                    Me.txtCiclo.Enabled = True
                    Me.dtFecha.Enabled = True
                    Me.cboLote.Enabled = True
                    Me.txtHA.Enabled = True
                    Me.GbCierreCiclo.Enabled = True

                    Me.InicializaElemento()

                    Me.cboDivision.Focus()

                Case enumEstados.EDICION
                    Me.gBoxInformacion.Enabled = True
                    Me.gBoxBusquedaRapida.Enabled = False
                    Me.tssLabelEstado.Text = "Editando"
                    Me.tsbNuevo.Enabled = False
                    Me.tsbEditar.Enabled = False
                    Me.tsbGrabar.Enabled = True
                    Me.tsbCancelar.Enabled = True

                    Me.CboEstatus.Enabled = True
                    Me.cboDivision.Enabled = False
                    Me.txtCiclo.Enabled = False
                    Me.dtFecha.Enabled = True
                    Me.cboLote.Enabled = False
                    Me.txtHA.Enabled = True
                    Me.GbCierreCiclo.Enabled = True

                    Me.txtHA.Focus()

                Case enumEstados.CONSULTA

                    Me.gBoxInformacion.Enabled = False
                    Me.gBoxBusquedaRapida.Enabled = True
                    Me.tssLabelEstado.Text = "Consultando"
                    Me.tsbNuevo.Enabled = True
                    Me.tsbEditar.Enabled = False
                    Me.tsbGrabar.Enabled = False
                    Me.tsbCancelar.Enabled = False
                    Me.GbCierreCiclo.Enabled = False

                    'Me.txtFiltro.Focus()

            End Select
            Application.DoEvents()
        Catch ex As Exception
            HandleError(Me.Name, "Cambia_Estado", ex)
        End Try
    End Sub

    Private Sub InicializaElemento()
        Try
            Me.CboEstatus.SelectedIndex = 0
            Me.cboDivision.SelectedIndex = -1
            Me.txtCiclo.Text = ""
            Me.dtFecha.Value = Date.Now
            Me.cboLote.SelectedIndex = -1
            Me.txtHA.Text = ""
        Catch ex As Exception
            HandleError(Me.Name, "InicializaElemento", ex)
        End Try
    End Sub

    Private Sub DesplegarElementos()
        Try
            With Me.Grid
                .DataSource = oProyecto.ObtenerElementosFiltro(Me.cboEstatusFiltro.Text, Me.cboAñoFiltro.Text)
                .Columns("ID_PROYECTO_SIEMBRA").Width = 50
                .Columns("Ciclo").Width = 100
                .Columns("Fecha inicio").Width = 110
                .Columns("División").Width = 220
                .Columns("Lote").Width = 100
                .Columns("HA").Width = 50
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarElementos", ex)
        End Try
    End Sub

    Private Sub LlenaElemento(ByVal iCodigo_Elemento As String)
        Try
            Me.oProyecto = New Class_ProyectoSiembraAcuicola(CInt(iCodigo_Elemento))
            If Me.oProyecto.Consultar = True Then
                With Me.oProyecto
                    Me.txtIDProyectoSiembra.Text = .ID_PROYECTO_SIEMBRA.ToString
                    Me.CboEstatus.Text = .ESTATUS
                    Me.cboDivision.SelectedValue = .CODIGO_DIVISION.ToString
                    Me.txtCiclo.Text = .CICLO.ToString
                    Me.dtFecha.Value = .FECHA_INICIO
                    Me.cboLote.SelectedValue = .CODIGO_LOTE
                    Me.txtHA.Text = .HA.ToString

                    If .ESTATUS = "T" Then
                        Me.DtFechaCierre.Value = .FECHA_CIERRE
                        Me.TxtKilosCosechados.Text = .KILOS_COSECHADOS.ToString
                        Me.TxtFolioEntrada.Text = .FOLIO_ENTRADA
                    End If

                End With
            End If
        Catch ex As Exception
            HandleError(Me.Name, "LlenaElemento", ex)
        End Try
    End Sub

    Private Sub Grabar()
        Dim bResultado As Boolean = False
        Select Case Me.Estado
            Case enumEstados.NUEVO, enumEstados.EDICION
                Try
                    With Me.oProyecto
                        .ID_PROYECTO_SIEMBRA = CInt("0" & Me.txtIDProyectoSiembra.Text)
                        .CICLO = CInt(Me.txtCiclo.Text)
                        .FECHA_INICIO = Me.dtFecha.Value
                        .CODIGO_DIVISION = CInt(Me.cboDivision.SelectedValue.ToString)
                        .CODIGO_LOTE = Me.cboLote.SelectedValue.ToString
                        .HA = valorNumericoD(Me.txtHA.Text)
                        .ESTATUS = Me.CboEstatus.Text

                        .FECHA_CIERRE = Me.DtFechaCierre.Value
                        .KILOS_COSECHADOS = valorNumericoD(Me.TxtKilosCosechados.Text)
                        .FOLIO_ENTRADA = Me.TxtFolioEntrada.Text

                        Select Case Me.Estado
                            Case enumEstados.NUEVO
                                If .Grabar("INSERTAR") = True Then
                                    bResultado = True
                                    Me.Estado = enumEstados.CONSULTA
                                End If
                            Case enumEstados.EDICION
                                If .Grabar("ACTUALIZAR") = True Then
                                    bResultado = True
                                    Me.Estado = enumEstados.CONSULTA
                                End If
                        End Select

                    End With

                    If bResultado = True Then
                        MsgBox(Me.msgElemento & " grabado satisfactoriamente.", MsgBoxStyle.Information, Me.Name)
                        Me.Refrescar()
                        Me.Cambia_Estado()
                    End If

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
            If Me.cboDivision.SelectedIndex = -1 Then
                MsgBox("Seleccione la división.", MsgBoxStyle.Exclamation, Me.Text)
                Return False
            End If

            If valorNumericoD(Me.txtCiclo.Text) <= 0 Then
                MsgBox("Asíge el ciclo.", MsgBoxStyle.Exclamation, Me.Text)
                Return False
            End If

            If Me.cboLote.SelectedIndex = -1 Then
                MsgBox("Seleccione el estanque.", MsgBoxStyle.Exclamation, Me.Text)
                Return False
            End If

            If valorNumericoD(Me.txtHA.Text) <= 0 Then
                MsgBox("Asíge las hectáreas.", MsgBoxStyle.Exclamation, Me.Text)
                Return False
            End If

            If Me.CboEstatus.Text = "T" Then

                If valorNumericoD(Me.TxtKilosCosechados.Text) <= 0 Then
                    MsgBox("Asígne los kilos cosechados.", MsgBoxStyle.Exclamation, Me.Text)
                    Me.TxtKilosCosechados.Focus()
                    Return False
                End If

                If txtLEN(Me.TxtFolioEntrada.Text) = False Then
                    MsgBox("Asígne el folio de entrada.", MsgBoxStyle.Exclamation, Me.Text)
                    Me.TxtFolioEntrada.Focus()
                    Return False
                End If

            End If

            bResultado = True

        Catch ex As Exception
            HandleError(Me.Name, "Validar", ex)
        End Try

        Return bResultado
    End Function

    Private Sub DesplegarDivisiones()
        Dim oDivisiones As New Class_CatDivisionesAcuicola
        Try
            With Me.cboDivision
                .DisplayMember = "NOMBRE_DIVISION"
                .ValueMember = "CODIGO_DIVISION"
                Dim dView As New Data.DataView(oDivisiones.ObtenerElementosActivos)
                dView.Sort = "NOMBRE_DIVISION"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedIndex = -1
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarDivisiones", ex)
        End Try
    End Sub

    Private Sub DesplegarLotes()
        Dim oLotes As New Class_CatLotes
        Try
            With Me.cboLote
                .DisplayMember = "NOMBRE_LOTE"
                .ValueMember = "CODIGO_LOTE"
                Dim dView As New Data.DataView(oLotes.ObtenerElementosActivos)
                dView.Sort = "NOMBRE_LOTE"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedIndex = -1
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarLotes", ex)
        End Try
    End Sub

    Private Sub DesplegarAños()
        Try
            For i = 2000 To 2200
                Me.cboAñoFiltro.Items.Add(i.ToString)
            Next
            Me.cboAñoFiltro.Text = Date.Now.Year.ToString
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarLotes", ex)
        End Try
    End Sub

#End Region

End Class