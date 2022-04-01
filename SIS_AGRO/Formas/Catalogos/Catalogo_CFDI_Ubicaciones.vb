Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Public Class Catalogo_CFDI_Ubicaciones
    Private oUbicacion As New Class_CatCfdiUbicaciones

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
            Me.msgElemento = "Ubicación"
            Me.msgElementos = "Ubicaciónes"
            Me.Run = False
            'Me.lstbElementos.ContextMenuStrip = Me.cMenuStripAccion
            Estado = enumEstados.CONSULTA
            Me.Cambia_Estado()
            Me.DesplegarElementos()
            Me.DesplegarPaises()
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
        Me.TxtCodigoUbicacion.Text = Me.oUbicacion.CodigoSiguiente
    End Sub

    Private Sub tsbEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbEditar.Click
        Me.Estado = enumEstados.EDICION
        Me.Cambia_Estado()
    End Sub

    Private Sub tsbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGrabar.Click
        Dim sMsg As String = ""
        Select Case Me.Estado
            Case enumEstados.EDICION
                sMsg = " grabar las modificaciones del " & Me.msgElemento & " : " & Me.TxtCodigoUbicacion.Text
            Case enumEstados.NUEVO
                sMsg = " agregar el " & Me.msgElemento & " : " & Me.TxtCodigoUbicacion.Text
        End Select
        sMsg = "Deseas " & sMsg & " ?"

        If Me.Validar() = False Then
            Exit Sub
        End If

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

    Private Sub tsbImprimirListado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

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

                Me.TxtCodigoUbicacion.Enabled = False
                Me.TxtCodigoCliente.Enabled = True
                Me.TxtIdUbicacion.Enabled = True
                Me.CboTipoUbicacion.Enabled = True
                Me.TxtNombreRemitenteDestinatario.Enabled = True
                Me.TxtRfcRemitenteDestinatario.Enabled = True
                Me.TxtNumeroIdentificacionRegistroFiscalExtranjero.Enabled = True
                Me.cboPaisResidenciaFiscal.Enabled = True
                Me.TxtDistanciaRecorrida.Enabled = True
                Me.TxtCalle.Enabled = True
                Me.TxtNumeroExterior.Enabled = True
                Me.TxtNumeroInterior.Enabled = True
                Me.TxtIdColonia.Enabled = True
                Me.TxtIdLocalidad.Enabled = True
                Me.TxtReferencia.Enabled = True
                Me.cboMunicipio.Enabled = True
                Me.CboEstatus.Enabled = True
                Me.cboPaisDomicilio.Enabled = True
                Me.TxtCodigoPostal.Enabled = True
                Me.CboEstatus.Enabled = False

                Me.InicializaElemento()
                Me.TxtCodigoCliente.Focus()

            Case enumEstados.EDICION
                Me.gBoxInformacion.Enabled = True
                Me.gBoxBusquedaRapida.Enabled = False
                Me.tssLabelEstado.Text = "Edición"
                Me.tsbNuevo.Enabled = False
                Me.tsbEditar.Enabled = False
                Me.tsbGrabar.Enabled = True
                Me.tsbCancelar.Enabled = True

                Me.TxtCodigoUbicacion.Enabled = False
                Me.TxtCodigoCliente.Enabled = True
                Me.TxtIdUbicacion.Enabled = True
                Me.CboTipoUbicacion.Enabled = True
                Me.TxtNombreRemitenteDestinatario.Enabled = True
                Me.TxtRfcRemitenteDestinatario.Enabled = True
                Me.TxtNumeroIdentificacionRegistroFiscalExtranjero.Enabled = True
                Me.cboPaisResidenciaFiscal.Enabled = True
                Me.TxtDistanciaRecorrida.Enabled = True
                Me.TxtCalle.Enabled = True
                Me.TxtNumeroExterior.Enabled = True
                Me.TxtNumeroInterior.Enabled = True
                Me.TxtIdColonia.Enabled = True
                Me.TxtIdLocalidad.Enabled = True
                Me.TxtReferencia.Enabled = True
                Me.cboMunicipio.Enabled = True
                Me.CboEstatus.Enabled = True
                Me.cboPaisDomicilio.Enabled = True
                Me.TxtCodigoPostal.Enabled = True
                Me.CboEstatus.Enabled = True

                Me.TxtCodigoCliente.Focus()

            Case enumEstados.CONSULTA
                Me.gBoxInformacion.Enabled = False
                Me.gBoxBusquedaRapida.Enabled = True
                Me.tssLabelEstado.Text = "Consulta"
                Me.tsbNuevo.Enabled = True
                Me.tsbEditar.Enabled = True
                Me.tsbGrabar.Enabled = False
                Me.tsbCancelar.Enabled = False
                Me.txtFiltro.Focus()
        End Select
        Application.DoEvents()
    End Sub

    Private Sub InicializaElemento()
        Me.TxtCodigoUbicacion.Text = ""
        Me.TxtCodigoCliente.Text = ""
        Me.LblDisplayNombreCliente.Text = ""
        Me.TxtIdUbicacion.Text = ""
        Me.CboTipoUbicacion.SelectedIndex = 0
        Me.TxtNombreRemitenteDestinatario.Text = ""
        Me.TxtRfcRemitenteDestinatario.Text = ""
        Me.TxtNumeroIdentificacionRegistroFiscalExtranjero.Text = ""
        Me.cboPaisResidenciaFiscal.SelectedIndex = -1
        Me.TxtDistanciaRecorrida.Text = "0.00"
        Me.TxtCalle.Text = ""
        Me.TxtNumeroExterior.Text = ""
        Me.TxtNumeroInterior.Text = ""
        Me.TxtIdColonia.Text = ""
        Me.TxtIdLocalidad.Text = ""
        Me.TxtReferencia.Text = ""
        Me.cboMunicipio.SelectedIndex = -1
        Me.cboEstado.SelectedIndex = -1
        Me.cboPaisDomicilio.SelectedIndex = -1
        Me.TxtCodigoPostal.Text = ""
        Me.CboEstatus.SelectedIndex = 0
    End Sub

    Private Sub DesplegarElementos()
        With Me.Grid
            .DataSource = oUbicacion.ObtenerElementosFiltro(Me.txtFiltro.Text, Me.cboEstatusFiltro.Text)
            .Columns("CODIGO_UBICACION").Width = 100
            .Columns("ID_UBICACION").Width = 250
        End With
    End Sub

    Private Sub DesplegarPaises()
        Try
            Me.cboEstado.DataSource = Nothing
            Me.cboMunicipio.DataSource = Nothing
            Dim oElementos As New Class_CatPaises
            With Me.cboPaisResidenciaFiscal
                .DisplayMember = "NOMBRE_PAIS"
                .ValueMember = "CODIGO_PAIS_SAT"
                Dim dView As New Data.DataView(oElementos.ObtenerElementos)
                dView.Sort = "NOMBRE_PAIS"
                .DataSource = dView
                .SelectedIndex = -1
            End With
            With Me.cboPaisDomicilio
                .DisplayMember = "NOMBRE_PAIS"
                .ValueMember = "CODIGO_PAIS_SAT"
                Dim dView As New Data.DataView(oElementos.ObtenerElementos)
                dView.Sort = "NOMBRE_PAIS"
                .DataSource = dView
                .SelectedIndex = -1
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarPaises", ex)
        End Try
    End Sub

    Private Sub DesplegarEstados()
        Try
            Me.cboEstado.DataSource = Nothing
            Me.cboMunicipio.DataSource = Nothing
            If Me.cboPaisDomicilio.SelectedIndex = -1 Then
                Return
            End If
            Dim oElementos As New Class_SisEstados
            With Me.cboEstado
                .DisplayMember = "NOMBRE_ESTADO"
                .ValueMember = "CODIGO_ESTADO_SAT"
                Dim dView As New Data.DataView(oElementos.ObtenerElementosEstadosSAT(Me.cboPaisDomicilio.SelectedValue.ToString))
                dView.Sort = "NOMBRE_ESTADO"
                .DataSource = dView
                .SelectedIndex = -1
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarEstados", ex)
        End Try
    End Sub

    Private Sub DesplegarMunicipios()
        Try
            Me.cboMunicipio.DataSource = Nothing
            If Me.cboEstado.SelectedIndex = -1 Then
                Return
            End If
            Dim oElementos As New Class_CatMunicipios
            With Me.cboMunicipio
                .DisplayMember = "NOMBRE_MUNICIPIO"
                .ValueMember = "CODIGO_MUNICIPIO"
                Dim dView As New Data.DataView(oElementos.ObtenerElementosPorEstadoSAT(Me.cboEstado.SelectedValue.ToString))
                dView.Sort = "NOMBRE_MUNICIPIO"
                .DataSource = dView
                .SelectedIndex = -1
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarMunicipios", ex)
        End Try
    End Sub

    Private Sub LlenaElemento(ByVal iCodigo_Elemento As Integer)
        Dim sql As Class_find
        Me.oUbicacion.CODIGO_UBICACION = iCodigo_Elemento

        If Me.oUbicacion.Consultar Then
            With Me.oUbicacion
                Me.TxtCodigoUbicacion.Text = .CODIGO_UBICACION.ToString

                Me.TxtCodigoCliente.Text = .CODIGO_CLIENTE.ToString
                sql = New Class_find("SELECT NOMBRE_CLIENTE FROM CAT_CLIENTE WHERE CODIGO_CLIENTE='" & .CODIGO_CLIENTE & "' ") : Me.LblDisplayNombreCliente.Text = sql.Result1

                Me.TxtIdUbicacion.Text = .ID_UBICACION.ToString
                Me.CboTipoUbicacion.Text = .TIPO_UBICACION
                Me.TxtNombreRemitenteDestinatario.Text = .NOMBRE_REMITENTE_DESTINATARIO
                Me.TxtRfcRemitenteDestinatario.Text = .RFC_REMITENTE_DESTINATARIO
                Me.TxtNumeroIdentificacionRegistroFiscalExtranjero.Text = .NUMERO_IDENTIFICACION_REGISTRO_FISCAL_EXTRANJERO
                Me.cboPaisResidenciaFiscal.SelectedValue = .CODIGO_PAIS_SAT_RESIDENCIA_FISCAL
                Me.TxtDistanciaRecorrida.Text = .DISTANCIA_RECORRIDA.ToString
                Me.TxtCalle.Text = .CALLE
                Me.TxtNumeroExterior.Text = .NUMERO_EXTERIOR
                Me.TxtNumeroInterior.Text = .NUMERO_INTERIOR

                Me.TxtIdColonia.Text = .ID_COLONIA.ToString
                sql = New Class_find("SELECT NOMBRE_COLONIA FROM CFDI_CAT_COLONIAS WHERE ID_COLONIA='" & .ID_COLONIA & "' ") : Me.LblNombreColonia.Text = sql.Result1

                Me.TxtIdLocalidad.Text = .ID_LOCALIDAD
                sql = New Class_find("SELECT NOMBRE_LOCALIDAD FROM CFDI_CAT_LOCALIDADES WHERE ID_LOCALIDAD='" & .ID_LOCALIDAD & "' ") : Me.LblNombreLocalidad.Text = sql.Result1

                Me.TxtReferencia.Text = .REFERENCIA
                Me.cboPaisDomicilio.SelectedValue = .CODIGO_PAIS_SAT_DOMICILIO
                Me.cboEstado.SelectedValue = .CODIGO_ESTADO_SAT
                Me.cboMunicipio.SelectedValue = .CODIGO_MUNICIPIO
                Me.TxtCodigoPostal.Text = .CODIGO_POSTAL

                If .ESTATUS = "A" Then
                    Me.CboEstatus.SelectedIndex = 0
                Else
                    Me.CboEstatus.SelectedIndex = 1
                End If

            End With
        End If
    End Sub

    Private Sub Grabar_Elemento()
        Dim Grabado As Boolean = False
        Select Case Me.Estado
            Case enumEstados.NUEVO, enumEstados.EDICION
                Try
                    With Me.oUbicacion
                        .CODIGO_UBICACION = CInt(Me.TxtCodigoUbicacion.Text)
                        .CODIGO_CLIENTE = Me.TxtCodigoCliente.Text
                        .ID_UBICACION = Me.TxtIdUbicacion.Text
                        .TIPO_UBICACION = Me.CboTipoUbicacion.Text
                        .NOMBRE_REMITENTE_DESTINATARIO = Me.TxtNombreRemitenteDestinatario.Text
                        .RFC_REMITENTE_DESTINATARIO = Me.TxtRfcRemitenteDestinatario.Text
                        .NUMERO_IDENTIFICACION_REGISTRO_FISCAL_EXTRANJERO = Me.TxtNumeroIdentificacionRegistroFiscalExtranjero.Text
                        .CODIGO_PAIS_SAT_RESIDENCIA_FISCAL = Me.cboPaisResidenciaFiscal.SelectedValue.ToString
                        .DISTANCIA_RECORRIDA = valorNumericoD(Me.TxtDistanciaRecorrida.Text)
                        .CALLE = Me.TxtCalle.Text
                        .NUMERO_EXTERIOR = Me.TxtNumeroExterior.Text
                        .NUMERO_INTERIOR = Me.TxtNumeroInterior.Text
                        .ID_COLONIA = Me.TxtIdColonia.Text
                        .ID_LOCALIDAD = Me.TxtIdLocalidad.Text
                        .REFERENCIA = Me.TxtReferencia.Text
                        .CODIGO_MUNICIPIO = CInt(Me.cboMunicipio.SelectedValue)
                        .CODIGO_ESTADO_SAT = Me.cboEstado.SelectedValue.ToString
                        .CODIGO_PAIS_SAT_DOMICILIO = Me.cboPaisDomicilio.SelectedValue.ToString
                        .CODIGO_POSTAL = Me.TxtCodigoPostal.Text
                        .ESTATUS = Strings.Left(Me.CboEstatus.Text, 1)
                        .CODIGO_USUARIO_CREO = Usuario.Codigo_Usuario.ToString
                        .FECHA_CREO = Date.Now
                        .CODIGO_USUARIO_MODIFICO = Usuario.Codigo_Usuario.ToString
                        .FECHA_MODIFICO = Date.Now
                        Select Case Me.Estado
                            Case enumEstados.NUEVO
                                If .Grabar("INSERTAR") Then
                                    Grabado = True
                                    Me.Estado = enumEstados.NUEVO
                                End If
                            Case enumEstados.EDICION
                                If .Grabar("ACTUALIZAR") Then
                                    Grabado = True
                                End If
                        End Select

                        Me.Estado = enumEstados.CONSULTA
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

                End Try
        End Select
    End Sub

    Private Function Validar() As Boolean
        Dim bResultado As Boolean = False

        If Me.CboTipoUbicacion.SelectedIndex = -1 Then
            MsgBox("Seleccione un tipo de ubicación.", MsgBoxStyle.Exclamation, Me.Name)
            Me.CboTipoUbicacion.Focus()
            Return bResultado
        End If

        If txtLEN(Me.TxtIdUbicacion.Text) = False Then
            MsgBox("Capture un ID de ubicación.", MsgBoxStyle.Exclamation, Me.Name)
            Me.TxtIdUbicacion.Focus()
            Return bResultado
        End If

        If txtLEN(Me.TxtNombreRemitenteDestinatario.Text) = False Then
            MsgBox("Capture un remitente de destinatario.", MsgBoxStyle.Exclamation, Me.Name)
            Me.TxtNombreRemitenteDestinatario.Focus()
            Return bResultado
        End If

        If txtLEN(Me.TxtRfcRemitenteDestinatario.Text) = False Then
            MsgBox("Capture un RFC de remitente de destinatario.", MsgBoxStyle.Exclamation, Me.Name)
            Me.TxtRfcRemitenteDestinatario.Focus()
            Return bResultado
        End If

        If txtLEN(Me.TxtNumeroIdentificacionRegistroFiscalExtranjero.Text) = False Then
            MsgBox("Capture un número de identificación de registro fiscal extranjero.", MsgBoxStyle.Exclamation, Me.Name)
            Me.TxtNumeroIdentificacionRegistroFiscalExtranjero.Focus()
            Return bResultado
        End If

        If txtLEN(Me.TxtDistanciaRecorrida.Text) = False Then
            Me.TxtDistanciaRecorrida.Text = "0"
        End If

        If txtLEN(Me.TxtCalle.Text) = False Then
            MsgBox("Capture una calle.", MsgBoxStyle.Exclamation, Me.Name)
            Me.TxtCalle.Focus()
            Return bResultado
        End If

        If txtLEN(Me.TxtNumeroExterior.Text) = False Then
            MsgBox("Capture un número exterior.", MsgBoxStyle.Exclamation, Me.Name)
            Me.TxtNumeroExterior.Focus()
            Return bResultado
        End If

        If txtLEN(Me.TxtReferencia.Text) = False Then
            MsgBox("Agregue una referencia.", MsgBoxStyle.Exclamation)
            Me.TxtReferencia.Focus()
            Return bResultado
        End If

        If Me.cboPaisDomicilio.SelectedIndex = -1 Then
            MsgBox("Asígne el país del domicilio.", MsgBoxStyle.Exclamation, Me.Name)
            Me.cboPaisDomicilio.Focus()
            Return bResultado
        End If

        If txtLEN(Me.TxtCodigoPostal.Text) = False Then
            MsgBox("Agregue un numero de hectareas", MsgBoxStyle.Exclamation, Me.Name)
            Me.TxtCodigoPostal.Focus()
            Return bResultado
        End If

        bResultado = True

        Return bResultado
    End Function

#End Region

#Region "Eventos de objetos"
    Private Sub cboPais_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPaisDomicilio.SelectedIndexChanged
        Me.DesplegarEstados()
    End Sub

    Private Sub cboEstado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEstado.SelectedIndexChanged
        Me.DesplegarMunicipios()
    End Sub

#Region "Eventos de la lista de elementos"
    Private Sub Grid_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grid.CellClick
        Me.LlenaElemento(CInt(Me.Grid.CurrentRow.Cells("CODIGO_UBICACION").Value))
    End Sub

    Private Sub Grid_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grid.CellDoubleClick
        Me.Estado = enumEstados.EDICION
        Me.Cambia_Estado()
    End Sub
#End Region

#Region " Eventos de TxtFiltro"
    Private Sub txtFiltro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFiltro.TextChanged
        Me.Grid.DataSource = Nothing

        With Me.Grid
            .DataSource = oUbicacion.ObtenerElementosFiltro(Me.txtFiltro.Text, Me.cboEstatusFiltro.Text)
            .Columns("CODIGO_UBICACION").Width = 50
            .Columns("ID_UBICACION").Width = 200
        End With
    End Sub
    Private Sub txtFiltro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFiltro.KeyPress
        txtNoBeep(e)
        txtNoComilla(e)
    End Sub
    Private Sub txtFiltro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFiltro.KeyDown
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Return Or e.KeyCode = Keys.Back Then
            Me.Grid.DataSource = Nothing

            With Me.Grid
                .DataSource = oUbicacion.ObtenerElementosFiltro(Me.txtFiltro.Text, Me.cboEstatusFiltro.Text)
                .Columns("CODIGO_UBICACION").Width = 50
                .Columns("ID_UBICACION").Width = 200
            End With
        End If
    End Sub

    Private Sub cboEstatusFiltro_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEstatusFiltro.SelectedIndexChanged
        Me.Grid.DataSource = Nothing

        With Me.Grid
            .DataSource = oUbicacion.ObtenerElementosFiltro(Me.txtFiltro.Text, Me.cboEstatusFiltro.Text)
            .Columns("CODIGO_UBICACION").Width = 50
            .Columns("ID_UBICACION").Width = 200
        End With
    End Sub
#End Region

#Region "Eventos Genericos"

    Private Sub CboEstatus_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CboEstatus.KeyDown
        If e.KeyCode = Keys.Return Then
            tsbGrabar.PerformClick()
        End If
    End Sub

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CboEstatus.KeyPress, TxtCodigoCliente.KeyPress, TxtReferencia.KeyPress, TxtCalle.KeyPress, TxtNumeroExterior.KeyPress, TxtNumeroInterior.KeyPress, TxtNombreRemitenteDestinatario.KeyPress, TxtRfcRemitenteDestinatario.KeyPress, TxtNumeroIdentificacionRegistroFiscalExtranjero.KeyPress, _
           TxtIdUbicacion.KeyPress

        txtNoBeep(e)
    End Sub

    Private Sub txt_Keydown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodigoCliente.KeyDown, TxtReferencia.KeyDown, TxtCodigoPostal.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtNumericos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDistanciaRecorrida.KeyPress
        Dim txt As TextBox = CType(sender, TextBox)
        txtSoloNumerosDecimales(e, txt.Text)
        txtNoBeep(e)
    End Sub

    Private Sub txtNumerosEnteros_KeyPres(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigoPostal.KeyPress, TxtIdColonia.KeyPress, TxtIdLocalidad.KeyPress, TxtCodigoUbicacion.KeyPress
        txtSoloNumerosEnteros(e)
        txtNoBeep(e)
    End Sub

    Private Sub txtNumericos_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        Dim t As TextBox
        t = CType(sender, TextBox)
        If Not IsNumeric(t.Text) Then
            t.Text = Val(t.Text).ToString
        Else
            Me.ErrorProvider.Clear()
        End If
    End Sub
#End Region


#Region "Keydown específicos"

    Private Sub txtCodigoCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCodigoCliente.KeyDown
        Dim oCliente As New Class_CatClientes
        Try
            Select Case e.KeyCode
                Case Keys.F6
Buscar:
                    Dim sCliente As String = oCliente.BusquedaVisual_PorDescripcion()
                    If txtLEN(sCliente) = True Then
                        Me.TxtCodigoCliente.Text = sCliente
                        GoTo Enter : Return
                    End If

                Case Keys.Enter
                    If txtLEN(Me.TxtCodigoCliente.Text) = False Then
                        Me.LblDisplayNombreCliente.Text = ""
                        GoTo Buscar : Return
                    End If
Enter:
                    oCliente = New Class_CatClientes(Me.TxtCodigoCliente.Text)

                    If oCliente.Existe = False Then
                        Me.LblDisplayNombreCliente.Text = ""
                        GoTo Buscar : Return
                    ElseIf oCliente.ESTATUS = "B" Then
                        MsgBox("El cliente " & Me.TxtCodigoCliente.Text & " está dado de baja.", MsgBoxStyle.Exclamation, Me.Text)
                        GoTo Buscar : Return
                    End If

                    Me.LblDisplayNombreCliente.Text = oCliente.NOMBRE_CLIENTE

                    txtTAB(e)
            End Select

        Catch ex As Exception
            HandleError(Me.Name, "txtCodigoCliente_KeyDown", ex)
        End Try
    End Sub

    Private Sub txtIdColonia_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtIdColonia.KeyDown
        Dim oColonia As New Class_CfdiCatColonias
        Try
            Select Case e.KeyCode
                Case Keys.F6
Buscar:
                    Dim sColonia = oColonia.BusquedaVisual_PorDescripcion()
                    If txtLEN(sColonia) = True Then
                        Me.TxtIdColonia.Text = sColonia
                        GoTo Enter : Return
                    End If

                Case Keys.Enter
                    If txtLEN(Me.TxtIdColonia.Text) = False Then
                        Me.LblNombreColonia.Text = ""
                        GoTo Buscar : Return
                    End If
Enter:
                    oColonia = New Class_CfdiCatColonias(Me.TxtIdColonia.Text)

                    If oColonia.Existe = False Then
                        Me.LblNombreColonia.Text = ""
                        GoTo Buscar : Return
                    ElseIf oColonia.ESTATUS = "B" Then
                        MsgBox("La colonia " & Me.TxtIdColonia.Text & " está dada de baja.", MsgBoxStyle.Exclamation, Me.Text)
                        GoTo Buscar : Return
                    End If

                    Me.LblNombreColonia.Text = oColonia.NOMBRE_COLONIA

                    txtTAB(e)
            End Select

        Catch ex As Exception
            HandleError(Me.Name, "txtIdColonia_KeyDown", ex)
        End Try
    End Sub

    Private Sub txtIdLocalidad_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtIdLocalidad.KeyDown
        Dim oLocalidad As New Class_CfdiCatLocalidades
        Try
            Select Case e.KeyCode
                Case Keys.F6
Buscar:
                    Dim sLocalidad = oLocalidad.BusquedaVisual_PorDescripcion()
                    If txtLEN(sLocalidad) = True Then
                        Me.TxtIdLocalidad.Text = sLocalidad
                        GoTo Enter : Return
                    End If

                Case Keys.Enter
                    If txtLEN(Me.TxtIdLocalidad.Text) = False Then
                        Me.LblNombreLocalidad.Text = ""
                        GoTo Buscar : Return
                    End If
Enter:
                    oLocalidad = New Class_CfdiCatLocalidades(TxtIdLocalidad.Text)

                    If oLocalidad.Existe = False Then
                        Me.LblNombreLocalidad.Text = ""
                        GoTo Buscar : Return
                    ElseIf oLocalidad.ESTATUS = "B" Then
                        MsgBox("La localidad " & TxtIdLocalidad.Text & " está dada de baja.", MsgBoxStyle.Exclamation, Me.Text)
                        GoTo Buscar : Return
                    End If

                    Me.LblNombreLocalidad.Text = oLocalidad.NOMBRE_LOCALIDAD

                    txtTAB(e)
            End Select

        Catch ex As Exception
            HandleError(Me.Name, "txtIdLocalidad_KeyDown", ex)
        End Try
    End Sub

#End Region

#Region "Validating específicos"

#End Region

    Private Sub CboFiltroHoja_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Refrescar()
    End Sub

#End Region


End Class