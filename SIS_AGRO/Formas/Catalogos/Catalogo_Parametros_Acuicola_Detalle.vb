Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class Catalogo_Parametros_Acuicola_Detalle
    Private oParametroDetalle As New Class_CatParametrosAcuicolaDetalle

#Region "Campos"

#Region "Campos ligados a la tabla"

#End Region

#Region "Campos públicos"

#End Region

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
#Region "Campos de sistema"
    Private _Nombre_Catalogo As String
    Private _Nombre_Reporte As String
    Private _Conexion As SqlConnection
    Private _QuerySelect As String
    Private _QueryOrder As String
#End Region

#End Region

#Region "Propiedades"

#Region "Propiedades Campos de la tabla"

#End Region

#Region "Propiedades de campos ligados a la tabla"

#End Region

#Region "Propiedades públicos"

#End Region

#Region "Propiedades de campos privados"

#End Region
#Region "Propiedades de campos de sistema"
    Public ReadOnly Property Nombre_Catalogo() As String
        Get
            Return Me._Nombre_Catalogo
        End Get
    End Property

    Public Property Nombre_Reporte() As String
        Get
            Return Me._Nombre_Reporte
        End Get
        Set(ByVal value As String)
            Me._Nombre_Reporte = value
        End Set
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
            Me.msgElemento = "Parametro detalle"
            Me.msgElementos = "Parametros detalle"
            Me.Run = False
            'Me.lstbElementos.ContextMenuStrip = Me.cMenuStripAccion
            Estado = enumEstados.CONSULTA
            Me.Cambia_Estado()
            Me.DesplegarElementos()
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
        Me.Refrescar()
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub

    Private Sub tsbImprimirListado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimirListado.Click
        'Me.oParametroDetalle.Imprimir_Listado()
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

                    Me.TxtCodigoDivision.Enabled = True
                    Me.TxtCodigoLote.Enabled = True
                    Me.TxtNumeroCanastas.Enabled = True

                    Me.InicializaElemento()
                    Me.TxtCodigoLote.Focus()

                Case enumEstados.EDICION
                    Me.gBoxInformacion.Enabled = True
                    Me.gBoxBusquedaRapida.Enabled = False
                    Me.tssLabelEstado.Text = "Editando"
                    Me.tsbNuevo.Enabled = False
                    Me.tsbEditar.Enabled = False
                    Me.tsbGrabar.Enabled = True
                    Me.tsbCancelar.Enabled = True

                    Me.TxtCodigoDivision.Enabled = True
                    Me.TxtCodigoLote.Enabled = True
                    Me.TxtNumeroCanastas.Enabled = True
                    Me.TxtNumeroCanastas.Focus()

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
        Catch ex As Exception
            HandleError(Me.Name, "Cambia_Estado", ex)
        End Try
    End Sub

    Private Sub InicializaElemento()
        Me.txtID.Text = ""
        Me.TxtCodigoDivision.Text = ""
        Me.LblNombreDivision.Text = ""
        Me.TxtCodigoLote.Text = ""
        Me.lblNombreLote.Text = ""
        Me.TxtNumeroCanastas.Text = ""
    End Sub

    Private Sub DesplegarElementos()
        Try
            With Me.Grid
                .DataSource = oParametroDetalle.ObtenerElementosFiltro("%")
                .Columns("CODIGO_DIVISION").Width = 50
                .Columns("NOMBRE_DIVISION").Width = 200
                .Columns("CODIGO_LOTE").Width = 30
                .Columns("NOMBRE_LOTE").Width = 200
                .Columns("CODIGO_LOTE").Visible = False
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarElementos", ex)
        End Try
    End Sub

    Private Sub LlenaElemento(ByVal sCodigo_Division As String, ByVal sCodigo_Lote As String)
        Try
            Me.oParametroDetalle.Codigo_Division = CInt(sCodigo_Division)
            Me.oParametroDetalle.Codigo_Lote = sCodigo_Lote
            If Me.oParametroDetalle.Consultar Then
                With Me.oParametroDetalle
                    Me.txtID.Text = .Id_Cat_Parametros_Acuicola_Detalle.ToString
                    Me.TxtCodigoDivision.Text = .Codigo_Division.ToString
                    Me.TxtCodigoLote.Text = .Codigo_Lote.ToString
                    Me.TxtNumeroCanastas.Text = .Numero_Canastas.ToString

                    Dim sql As New Class_find("SELECT NOMBRE_DIVISION FROM CAT_DIVISIONES_ACUICOLA WHERE CODIGO_DIVISION='" & Me.TxtCodigoDivision.Text & "'")
                    If txtLEN(sql.Result1) = True Then
                        Me.LblNombreDivision.Text = sql.Result1
                    End If

                    sql = New Class_find("SELECT NOMBRE_LOTE FROM CAT_LOTES WHERE CODIGO_LOTE='" & Me.TxtCodigoLote.Text & "'")
                    If txtLEN(sql.Result1) = True Then
                        Me.lblNombreLote.Text = sql.Result1
                    End If

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
                Try
                    With Me.oParametroDetalle
                        .Codigo_Division = CInt(Me.TxtCodigoDivision.Text)
                        .Codigo_Lote = Me.TxtCodigoLote.Text
                        .Numero_Canastas = CInt(TxtNumeroCanastas.Text)

                        Select Case Me.Estado
                            Case enumEstados.NUEVO
                                If .Insertar() = True Then
                                    Grabado = True
                                    Me.Estado = enumEstados.NUEVO
                                End If
                            Case enumEstados.EDICION
                                .Id_Cat_Parametros_Acuicola_Detalle = CInt(Me.txtID.Text)

                                If .Actualizar() = True Then
                                    Grabado = True
                                End If
                        End Select

                        Me.Estado = enumEstados.CONSULTA

                        If Grabado = True Then
                            MsgBox(Me.msgElemento & " grabado satisfactoriamente.", MsgBoxStyle.Information, Me.Text)
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
            If txtLEN(Me.TxtCodigoLote.Text) = False Then
                MsgBox("Captúre el código de división.", MsgBoxStyle.Exclamation, Me.Text)
                Me.TxtCodigoLote.Focus()
                Return False
            End If

            If txtLEN(Me.TxtCodigoLote.Text) = False Then
                MsgBox("Captúre el código de lote.", MsgBoxStyle.Exclamation, Me.Text)
                Me.TxtCodigoLote.Focus()
                Return False
            End If

            oParametroDetalle = New Class_CatParametrosAcuicolaDetalle(Me.TxtCodigoDivision.Text, Me.TxtCodigoLote.Text)
            If oParametroDetalle.Existe = True Then
                MsgBox("Ya existe un parametro con la división " & Me.TxtCodigoDivision.Text & " " & Me.LblNombreDivision.Text & " y el lote " & Me.TxtCodigoLote.Text & " " & Me.lblNombreLote.Text, MsgBoxStyle.Exclamation, Me.Name)
                Me.TxtCodigoLote.Focus()
                Return False
            End If

            If txtLEN(Me.TxtNumeroCanastas.Text) = False Then
                MsgBox("Captúre el número de canastas.", MsgBoxStyle.Exclamation, Me.Text)
                Me.TxtNumeroCanastas.Focus()
                Return False
            End If

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
        Me.LlenaElemento(Me.Grid.CurrentRow.Cells("CODIGO_DIVISION").Value.ToString, Me.Grid.CurrentRow.Cells("CODIGO_LOTE").Value.ToString)
    End Sub

    Private Sub Grid_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grid.CellDoubleClick
        Me.Estado = enumEstados.EDICION
        Me.Cambia_Estado()
    End Sub
#End Region

#Region " Eventos de TxtFiltro"
    Private Sub txtFiltro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFiltro.TextChanged
        Dim oElementos As New Class_CatParametrosAcuicolaDetalle
        Me.Grid.DataSource = Nothing

        With Me.Grid
            .DataSource = oElementos.ObtenerElementosFiltro(Me.txtFiltro.Text)
            .Columns("CODIGO_DIVISION").Width = 50
            .Columns("NOMBRE_DIVISION").Width = 200
            .Columns("CODIGO_LOTE").Width = 30
            .Columns("NOMBRE_LOTE").Width = 200
            .Columns("CODIGO_LOTE").Visible = False
        End With
    End Sub

    Private Sub txtFiltro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFiltro.KeyPress
        txtNoBeep(e)
        txtNoComilla(e)
    End Sub

    Private Sub txtFiltro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFiltro.KeyDown
        Dim oElementosFiltro As New Class_CatParametrosAcuicolaDetalle
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Return Or e.KeyCode = Keys.Back Then
            Me.Grid.DataSource = Nothing

            With Me.Grid
                .DataSource = oElementosFiltro.ObtenerElementosFiltro(Me.txtFiltro.Text)
                .Columns("CODIGO_DIVISION").Width = 50
                .Columns("NOMBRE_DIVISION").Width = 200
                .Columns("CODIGO_LOTE").Width = 30
                .Columns("NOMBRE_LOTE").Width = 200
                .Columns("CODIGO_LOTE").Visible = False
            End With
        End If
    End Sub

#End Region

#Region "Eventos Genericos"

    Private Sub txt_Keydown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNumeroCanastas.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.tsbGrabar.PerformClick()
        End If
    End Sub

    Private Sub txtNumerosEnterosKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNumeroCanastas.KeyPress, TxtCodigoDivision.KeyPress, TxtCodigoLote.KeyPress
        txtSoloNumerosEnteros(e)
        txtNoBeep(e)
    End Sub

#End Region

#Region "Keydown específicos"
    Private Sub TxtCodigoLote_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCodigoLote.KeyDown
        Dim sText As String
        Dim oLote As New Class_CatLotes

        Select Case e.KeyCode
            Case Keys.F6
Buscar:
                sText = oLote.BusquedaVisual_PorDescripcion
                If txtLEN(sText) = True Then
                    Me.TxtCodigoLote.Text = sText
                End If

            Case Keys.Enter

                If txtLEN(Me.TxtCodigoLote.Text) = True Then
                    oLote.Codigo_Lote = Me.TxtCodigoLote.Text
                    If oLote.Consultar = True Then
                        Me.lblNombreLote.Text = oLote.Nombre_Lote
                        txtTAB(e)
                    Else
                        Me.lblNombreLote.Text = "" : GoTo Buscar : Exit Sub
                    End If

                End If

        End Select
    End Sub

    Private Sub TxtCodigoDivision_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCodigoDivision.KeyDown
        Dim sText As String
        Dim oDivision As New Class_CatDivisionesAcuicola

        Select Case e.KeyCode
            Case Keys.F6
Buscar:
                sText = oDivision.BusquedaVisual_PorDescripcion
                If txtLEN(sText) = True Then
                    Me.TxtCodigoDivision.Text = sText
                End If

            Case Keys.Enter

                If txtLEN(Me.TxtCodigoDivision.Text) = True Then
                    oDivision.Codigo_Division = Me.TxtCodigoDivision.Text
                    If oDivision.Consultar = True Then
                        Me.LblNombreDivision.Text = oDivision.Nombre_Division
                        txtTAB(e)
                    Else
                        Me.LblNombreDivision.Text = "" : GoTo Buscar : Exit Sub
                    End If

                End If

        End Select
    End Sub
#End Region

#Region "Validating específicos"

#End Region

    Private Sub CboFiltroHoja_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Refrescar()
    End Sub

#End Region

End Class