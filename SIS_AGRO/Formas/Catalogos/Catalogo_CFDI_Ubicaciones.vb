Option Strict On

Imports System.Data.SqlClient

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
        Const sProcedure As String = "Cambia_Estado"
        Try
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
                    Me.TxtIdUbicacion.Enabled = False
                    Me.CboTipoUbicacion.Enabled = True
                    Me.TxtNombreRemitenteDestinatario.Enabled = True
                    Me.TxtRfcRemitenteDestinatario.Enabled = True
                    Me.TxtDistanciaRecorrida.Enabled = True
                    Me.TxtCalle.Enabled = True
                    Me.TxtNumeroExterior.Enabled = True
                    Me.TxtNumeroInterior.Enabled = True
                    Me.TxtIdColonia.Enabled = True
                    Me.TxtIdLocalidad.Enabled = True
                    Me.TxtReferencia.Enabled = True
                    Me.TxtMunicipio.Enabled = True
                    Me.TxtEstado.Enabled = True
                    Me.TxtPaisDomicilio.Enabled = True
                    Me.TxtCodigoPostal.Enabled = True
                    Me.TxtNumeroIdentificacionRegistroFiscalExtranjero.Enabled = True
                    Me.TxtPaisResidenciaFiscal.Enabled = True
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
                    Me.TxtIdUbicacion.Enabled = False
                    Me.CboTipoUbicacion.Enabled = False
                    Me.TxtNombreRemitenteDestinatario.Enabled = True
                    Me.TxtRfcRemitenteDestinatario.Enabled = True
                    Me.TxtDistanciaRecorrida.Enabled = True
                    Me.TxtCalle.Enabled = True
                    Me.TxtNumeroExterior.Enabled = True
                    Me.TxtNumeroInterior.Enabled = True
                    Me.TxtIdColonia.Enabled = True
                    Me.TxtIdLocalidad.Enabled = True
                    Me.TxtReferencia.Enabled = True
                    Me.TxtMunicipio.Enabled = True
                    Me.TxtEstado.Enabled = True
                    Me.TxtPaisDomicilio.Enabled = True
                    Me.TxtCodigoPostal.Enabled = True
                    Me.TxtNumeroIdentificacionRegistroFiscalExtranjero.Enabled = True
                    Me.TxtPaisResidenciaFiscal.Enabled = True
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
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Sub InicializaElemento()
        Const sProcedure As String = "InicializaElemento"
        Try
            Me.TxtCodigoUbicacion.Text = ""
            Me.TxtCodigoCliente.Text = ""
            Me.LblDisplayNombreCliente.Text = ""
            Me.TxtIdUbicacion.Text = ""
            Me.CboTipoUbicacion.SelectedIndex = 0
            Me.TxtNombreRemitenteDestinatario.Text = ""
            Me.TxtRfcRemitenteDestinatario.Text = ""
            Me.TxtNumeroIdentificacionRegistroFiscalExtranjero.Text = ""
            Me.TxtPaisResidenciaFiscal.Text = "" : Me.LblNombrePaisResidenciaFiscal.Text = ""
            Me.TxtDistanciaRecorrida.Text = "0.00"
            Me.TxtCalle.Text = ""
            Me.TxtNumeroExterior.Text = ""
            Me.TxtNumeroInterior.Text = ""
            Me.TxtIdColonia.Text = "" : Me.LblNombreColonia.Text = ""
            Me.TxtIdLocalidad.Text = "" : Me.LblNombreLocalidad.Text = ""
            Me.TxtReferencia.Text = ""
            Me.TxtMunicipio.Text = "" : Me.LblNombreMunicipio.Text = ""
            Me.TxtEstado.Text = "" : Me.LblNombreEstado.Text = ""
            Me.TxtPaisDomicilio.Text = "MEX" : Me.LblNombrePaisDomicilio.Text = "MEXICO"
            Me.TxtCodigoPostal.Text = ""
            Me.CboEstatus.SelectedIndex = 0
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Sub DesplegarElementos()
        Const sProcedure As String = "DesplegarElementos"
        Try
            With Me.Grid
                .DataSource = oUbicacion.ObtenerElementosFiltro(Me.txtFiltro.Text, Me.cboEstatusFiltro.Text)
                .Columns("CODIGO_UBICACION").Width = 50
                .Columns("ID_UBICACION").Width = 100
                .Columns("NOMBRE_REMITENTE_DESTINATARIO").Width = 250
            End With
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Sub LlenaElemento(ByVal iCodigo_Elemento As Integer)
        Const sProcedure As String = "LlenaElemento"
        Try
            Me.InicializaElemento()

            Dim sql As Class_find
            Me.oUbicacion = New Class_CatCfdiUbicaciones(iCodigo_Elemento)

            If Me.oUbicacion.Existe Then
                With Me.oUbicacion
                    Me.TxtCodigoUbicacion.Text = .CODIGO_UBICACION.ToString

                    Me.TxtCodigoCliente.Text = .CODIGO_CLIENTE.ToString
                    If txtLEN(Me.TxtCodigoCliente.Text) Then
                        sql = New Class_find("SELECT NOMBRE_CLIENTE FROM CAT_CLIENTES WHERE CODIGO_CLIENTE='" & .CODIGO_CLIENTE & "' ")
                        If txtLEN(sql.Result1) Then
                            Me.LblDisplayNombreCliente.Text = sql.Result1
                        End If
                    End If

                    Me.TxtIdUbicacion.Text = .ID_UBICACION.ToString
                    Me.CboTipoUbicacion.Text = .TIPO_UBICACION
                    Me.TxtNombreRemitenteDestinatario.Text = .NOMBRE_REMITENTE_DESTINATARIO
                    Me.TxtRfcRemitenteDestinatario.Text = .RFC_REMITENTE_DESTINATARIO
                    Me.TxtNumeroIdentificacionRegistroFiscalExtranjero.Text = .NUMERO_IDENTIFICACION_REGISTRO_FISCAL_EXTRANJERO
                    Me.TxtDistanciaRecorrida.Text = .DISTANCIA_RECORRIDA.ToString
                    Me.TxtCalle.Text = .CALLE
                    Me.TxtNumeroExterior.Text = .NUMERO_EXTERIOR
                    Me.TxtNumeroInterior.Text = .NUMERO_INTERIOR
                    Me.TxtReferencia.Text = .REFERENCIA
                    Me.TxtCodigoPostal.Text = .CODIGO_POSTAL

                    Me.TxtPaisResidenciaFiscal.Text = .CODIGO_PAIS_SAT_RESIDENCIA_FISCAL
                    If txtLEN(Me.TxtPaisResidenciaFiscal.Text) Then
                        sql = New Class_find("SELECT NOMBRE_PAIS FROM CAT_PAISES WHERE CODIGO_PAIS_SAT='" & .CODIGO_PAIS_SAT_RESIDENCIA_FISCAL & "' ")
                        If txtLEN(sql.Result1) Then
                            Me.LblNombrePaisResidenciaFiscal.Text = sql.Result1
                        End If
                    End If

                    Me.TxtPaisDomicilio.Text = .CODIGO_PAIS_SAT_DOMICILIO
                    If txtLEN(Me.TxtPaisDomicilio.Text) Then
                        sql = New Class_find("SELECT NOMBRE_PAIS FROM CAT_PAISES WHERE CODIGO_PAIS_SAT='" & .CODIGO_PAIS_SAT_DOMICILIO & "' ")
                        If txtLEN(sql.Result1) Then
                            Me.LblNombrePaisDomicilio.Text = sql.Result1
                        End If
                    End If

                    Me.TxtEstado.Text = .CODIGO_ESTADO_SAT
                    If txtLEN(Me.TxtEstado.Text) Then
                        sql = New Class_find("SELECT NOMBRE_ESTADO FROM SIS_ESTADOS WHERE CODIGO_ESTADO_SAT='" & .CODIGO_ESTADO_SAT & "' ")
                        If txtLEN(sql.Result1) Then
                            Me.LblNombreEstado.Text = sql.Result1
                        End If
                    End If

                    Me.TxtMunicipio.Text = .CODIGO_MUNICIPIO
                    If txtLEN(Me.TxtMunicipio.Text) Then
                        sql = New Class_find("SELECT NOMBRE_MUNICIPIO FROM CAT_MUNICIPIOS WHERE CODIGO_MUNICIPIO=" & .CODIGO_MUNICIPIO & " ")
                        If txtLEN(sql.Result1) Then
                            Me.LblNombreMunicipio.Text = sql.Result1
                        End If
                    End If

                    Me.TxtIdColonia.Text = .ID_COLONIA
                    If txtLEN(Me.TxtIdColonia.Text) Then
                        sql = New Class_find("SELECT NOMBRE_COLONIA FROM CFDI_CAT_COLONIAS WHERE ID_COLONIA='" & .ID_COLONIA & "' ")
                        If txtLEN(sql.Result1) Then
                            Me.LblNombreColonia.Text = sql.Result1
                        End If
                    End If

                    Me.TxtIdLocalidad.Text = .ID_LOCALIDAD
                    If txtLEN(Me.TxtIdLocalidad.Text) Then
                        sql = New Class_find("SELECT NOMBRE_LOCALIDAD FROM CFDI_CAT_LOCALIDADES WHERE ID_LOCALIDAD='" & .ID_LOCALIDAD & "' ")
                        If txtLEN(sql.Result1) Then
                            Me.LblNombreLocalidad.Text = sql.Result1
                        End If
                    End If

                    If .ESTATUS = "A" Then
                        Me.CboEstatus.SelectedIndex = 0
                    Else
                        Me.CboEstatus.SelectedIndex = 1
                    End If

                End With
            End If
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Function Grabar_Elemento() As Boolean
        Const sProcedure As String = "Grabar_Elemento"
        Dim bResultado As Boolean = False
        Select Case Me.Estado
            Case enumEstados.NUEVO, enumEstados.EDICION
                Try
                    With Me.oUbicacion
                        '.CODIGO_UBICACION = CInt(Me.TxtCodigoUbicacion.Text)
                        .CODIGO_CLIENTE = Me.TxtCodigoCliente.Text
                        '.ID_UBICACION = Me.TxtIdUbicacion.Text
                        .TIPO_UBICACION = Me.CboTipoUbicacion.Text
                        .NOMBRE_REMITENTE_DESTINATARIO = Me.TxtNombreRemitenteDestinatario.Text
                        .RFC_REMITENTE_DESTINATARIO = Me.TxtRfcRemitenteDestinatario.Text
                        .NUMERO_IDENTIFICACION_REGISTRO_FISCAL_EXTRANJERO = Me.TxtNumeroIdentificacionRegistroFiscalExtranjero.Text
                        .CODIGO_PAIS_SAT_RESIDENCIA_FISCAL = Me.TxtPaisResidenciaFiscal.Text
                        .DISTANCIA_RECORRIDA = valorNumericoD(Me.TxtDistanciaRecorrida.Text)
                        .CALLE = Me.TxtCalle.Text
                        .NUMERO_EXTERIOR = Me.TxtNumeroExterior.Text
                        .NUMERO_INTERIOR = Me.TxtNumeroInterior.Text
                        .ID_COLONIA = Me.TxtIdColonia.Text
                        .ID_LOCALIDAD = Me.TxtIdLocalidad.Text
                        .REFERENCIA = Me.TxtReferencia.Text
                        .CODIGO_MUNICIPIO = Me.TxtMunicipio.Text
                        .CODIGO_ESTADO_SAT = Me.TxtEstado.Text
                        .CODIGO_PAIS_SAT_DOMICILIO = Me.TxtPaisDomicilio.Text
                        .CODIGO_POSTAL = Me.TxtCodigoPostal.Text
                        .ESTATUS = Strings.Left(Me.CboEstatus.Text, 1)
                        .CODIGO_USUARIO_CREO = Usuario.Codigo_Usuario.ToString
                        .FECHA_CREO = Date.Now
                        .CODIGO_USUARIO_MODIFICO = Usuario.Codigo_Usuario.ToString
                        .FECHA_MODIFICO = Date.Now
                        Select Case Me.Estado
                            Case enumEstados.NUEVO
                                If .Grabar("INSERTAR") Then
                                    bResultado = True
                                    Me.Estado = enumEstados.NUEVO
                                End If
                            Case enumEstados.EDICION
                                If .Grabar("ACTUALIZAR") Then
                                    bResultado = True
                                End If
                        End Select

                        Me.Estado = enumEstados.CONSULTA

                        If bResultado = True Then
                            MsgBox(Me.msgElemento & " Grabado satisfactoriamente.", MsgBoxStyle.Information, sProcedure)
                            Me.Refrescar()
                            Me.Cambia_Estado()
                        End If

                    End With
                Catch ex As Exception
                    HandleError(Me.Name, sProcedure, ex)
                    Me.Estado = enumEstados.CONSULTA
                    Me.Cambia_Estado()
                End Try
        End Select

        Return bResultado
    End Function

    Private Function Validar() As Boolean
        Const sProcedure As String = "Validar"
        Dim bResultado As Boolean = False

        Try
            If Me.CboTipoUbicacion.SelectedIndex = -1 Then
                MsgBox("Seleccione un tipo de ubicación.", MsgBoxStyle.Exclamation, sProcedure)
                Me.CboTipoUbicacion.Focus()
                Return False
            End If

            If txtLEN(Me.TxtNombreRemitenteDestinatario.Text) = False Then
                MsgBox("Capture un remitente de destinatario.", MsgBoxStyle.Exclamation, sProcedure)
                Me.TxtNombreRemitenteDestinatario.Focus()
                Return False
            End If

            If txtLEN(Me.TxtRfcRemitenteDestinatario.Text) = False Then
                MsgBox("Capture un RFC de remitente de destinatario.", MsgBoxStyle.Exclamation, sProcedure)
                Me.TxtRfcRemitenteDestinatario.Focus()
                Return False
            End If

            If txtLEN(Me.TxtDistanciaRecorrida.Text) = False Then
                Me.TxtDistanciaRecorrida.Text = "0"
            End If

            'Validaciones de domicilio
            If txtLEN(Me.TxtCodigoPostal.Text) = False Then
                MsgBox("Capture un código postal.", MsgBoxStyle.Exclamation, sProcedure)
                Me.TxtCodigoPostal.Focus()
                Return False
            End If

            If txtLEN(Me.TxtPaisDomicilio.Text) = False Then
                MsgBox("Capture el país del domicilio.", MsgBoxStyle.Exclamation, sProcedure)
                Me.TxtPaisDomicilio.Focus()
                Return False
            End If

            If txtLEN(Me.TxtEstado.Text) = False Then
                MsgBox("Capture el estado.", MsgBoxStyle.Exclamation, sProcedure)
                Me.TxtEstado.Focus()
                Return False
            End If

            'If txtLEN(Me.TxtCalle.Text) = False Then
            '    MsgBox("Capture una calle.", MsgBoxStyle.Exclamation, sProcedure)
            '    Me.TxtCalle.Focus()
            '    Return bResultado
            'End If

            'If txtLEN(Me.TxtNumeroExterior.Text) = False Then
            '    MsgBox("Capture un número exterior.", MsgBoxStyle.Exclamation, sProcedure)
            '    Me.TxtNumeroExterior.Focus()
            '    Return bResultado
            'End If

            If Me.ValidaRelacionDatosDomicilio() = False Then
                Return False
            End If

            bResultado = True

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    Private Function ValidaRelacionDatosDomicilio() As Boolean
        Const sProcedure As String = "ValidaRelacionDatosDomicilio"
        Dim bResultado As Boolean = False
        Dim sQuery As String

        Try
            'sQuery = "SELECT TOP 1 1 " &
            '         "FROM CAT_PAISES P " &
            '         "INNER JOIN SIS_ESTADOS E ON(P.CODIGO_PAIS_SAT=E.CODIGO_PAIS_SAT) " &
            '         "INNER JOIN CAT_MUNICIPIOS M ON(E.CODIGO_ESTADO=M.CODIGO_ESTADO) " &
            '         "INNER JOIN CFDI_CAT_LOCALIDADES L ON(E.CODIGO_ESTADO=L.CODIGO_ESTADO) " &
            '         "INNER JOIN CFDI_CAT_CODIGOS_POSTALES CP ON(L.CODIGO_LOCALIDAD=CP.CODIGO_LOCALIDAD) " &
            '         "INNER JOIN CFDI_CAT_COLONIAS C ON(CP.CODIGO_POSTAL=C.CODIGO_POSTAL) " &
            '         "WHERE CP.CODIGO_POSTAL='" & Me.TxtCodigoPostal.Text & "' AND P.CODIGO_PAIS_SAT='" & Me.TxtPaisDomicilio.Text & "' AND E.CODIGO_ESTADO_SAT='" & Me.TxtEstado.Text & "' " 'Campos obligatorios

            ''Campos opcionales
            'If txtLEN(Me.TxtMunicipio.Text) Then
            '    sQuery = sQuery + "AND M.CODIGO_MUNICIPIO=" & Me.TxtMunicipio.Text & " "

            '    If txtLEN(Me.TxtIdLocalidad.Text) Then
            '        sQuery = sQuery + "AND L.ID_LOCALIDAD=" & Me.TxtIdLocalidad.Text & " "

            '        If txtLEN(Me.TxtIdColonia.Text) Then
            '            sQuery = sQuery + "AND C.ID_COLONIA=" & Me.TxtIdColonia.Text & " "
            '        End If
            '    End If
            'End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            sQuery = "SELECT TOP 1 1 " &
                     "FROM CAT_PAISES P " &
                     "INNER JOIN SIS_ESTADOS E ON(P.CODIGO_PAIS_SAT=E.CODIGO_PAIS_SAT) " &
                     "WHERE P.CODIGO_PAIS_SAT='" & sReplace(Me.TxtPaisDomicilio.Text) & "' AND E.CODIGO_ESTADO_SAT='" & sReplace(Me.TxtEstado.Text) & "' " 'Campos obligatorios

            Dim sql As New Class_find(sQuery)

            If txtLEN(sql.Result1) = False Then
                MsgBox("No coinciden los datos de domicilio país y estado.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.TxtPaisDomicilio.Text = "MEX" Then
                sQuery = "SELECT TOP 1 1 " &
                         "FROM CFDI_CAT_CODIGOS_POSTALES CP " &
                         "INNER JOIN SIS_ESTADOS E ON(CP.CODIGO_ESTADO_SAT=E.CODIGO_ESTADO_SAT) " &
                         "LEFT JOIN CAT_MUNICIPIOS M ON(CP.CODIGO_MUNICIPIO_SAT=M.CODIGO_MUNICIPIO_SAT AND E.CODIGO_ESTADO=M.CODIGO_ESTADO) " &
                         "LEFT JOIN CFDI_CAT_COLONIAS COL ON(CP.CODIGO_POSTAL=COL.CODIGO_POSTAL) " &
                         "LEFT JOIN CFDI_CAT_LOCALIDADES LOC ON(CP.CODIGO_LOCALIDAD=LOC.CODIGO_LOCALIDAD AND E.CODIGO_ESTADO_SAT=LOC.CODIGO_ESTADO_SAT) " &
                         "WHERE CP.CODIGO_POSTAL='" & sReplace(Me.TxtCodigoPostal.Text) & "' AND CP.CODIGO_ESTADO_SAT='" & Me.TxtEstado.Text & "' "

                If txtLEN(Me.TxtMunicipio.Text) = True Then
                    sQuery = sQuery + " AND M.CODIGO_MUNICIPIO=" & sReplace(Me.TxtMunicipio.Text) & " "
                End If

                If txtLEN(Me.TxtIdLocalidad.Text) = True Then
                    sQuery = sQuery + " AND LOC.ID_LOCALIDAD=" & sReplace(Me.TxtIdLocalidad.Text) & " "
                End If

                If txtLEN(Me.TxtIdColonia.Text) = True Then
                    sQuery = sQuery + " AND COL.ID_COLONIA=" & sReplace(Me.TxtIdColonia.Text) & " "
                End If

                sql = New Class_find(sQuery)

                If txtLEN(sql.Result1) = False Then
                    MsgBox("No coinciden los datos de domicilio para este código postal según el SAT, verifique la tabla de este código postal.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            bResultado = True

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try

        Return bResultado
    End Function

#End Region

#Region "Eventos de objetos"

#Region "Eventos de la lista de elementos"
    Private Sub Grid_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grid.CellClick
        Me.LlenaElemento(CInt(Me.Grid.CurrentRow.Cells("CODIGO_UBICACION").Value))
    End Sub

    Private Sub Grid_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grid.CellDoubleClick
        Me.Estado = enumEstados.EDICION
        Me.Cambia_Estado()
    End Sub
#End Region

#Region "Eventos de TxtFiltro"
    Private Sub txtFiltro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFiltro.TextChanged
        Const sProcedure As String = "txtFiltro_TextChanged"
        Try
            Me.Grid.DataSource = Nothing

            With Me.Grid
                .DataSource = oUbicacion.ObtenerElementosFiltro(Me.txtFiltro.Text, Me.cboEstatusFiltro.Text)
                .Columns("CODIGO_UBICACION").Width = 50
                .Columns("ID_UBICACION").Width = 100
                .Columns("NOMBRE_REMITENTE_DESTINATARIO").Width = 250
            End With
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Sub txtFiltro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFiltro.KeyPress
        txtNoBeep(e)
        txtNoComilla(e)
    End Sub

    Private Sub txtFiltro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFiltro.KeyDown
        Const sProcedure As String = "txtFiltro_KeyDown"
        Try
            If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Return Or e.KeyCode = Keys.Back Then
                Me.Grid.DataSource = Nothing

                With Me.Grid
                    .DataSource = oUbicacion.ObtenerElementosFiltro(Me.txtFiltro.Text, Me.cboEstatusFiltro.Text)
                    .Columns("CODIGO_UBICACION").Width = 50
                    .Columns("ID_UBICACION").Width = 100
                    .Columns("NOMBRE_REMITENTE_DESTINATARIO").Width = 250
                End With
            End If
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Sub cboEstatusFiltro_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEstatusFiltro.SelectedIndexChanged
        Const sProcedure As String = "cboEstatusFiltro_SelectedIndexChanged"
        Try
            Me.Grid.DataSource = Nothing

            With Me.Grid
                .DataSource = oUbicacion.ObtenerElementosFiltro(Me.txtFiltro.Text, Me.cboEstatusFiltro.Text)
                .Columns("CODIGO_UBICACION").Width = 50
                .Columns("ID_UBICACION").Width = 100
                .Columns("NOMBRE_REMITENTE_DESTINATARIO").Width = 250
            End With
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub
#End Region

#Region "Eventos Genericos"
    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CboEstatus.KeyPress, TxtCodigoCliente.KeyPress, TxtReferencia.KeyPress, TxtCalle.KeyPress, TxtNumeroExterior.KeyPress,
        TxtNumeroInterior.KeyPress, TxtNombreRemitenteDestinatario.KeyPress, TxtRfcRemitenteDestinatario.KeyPress, TxtNumeroIdentificacionRegistroFiscalExtranjero.KeyPress,
           TxtIdUbicacion.KeyPress, TxtPaisDomicilio.KeyPress, TxtPaisResidenciaFiscal.KeyPress, TxtEstado.KeyPress, TxtMunicipio.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub txt_Keydown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNombreRemitenteDestinatario.KeyDown, TxtRfcRemitenteDestinatario.KeyDown, TxtDistanciaRecorrida.KeyDown, TxtReferencia.KeyDown,
        TxtCodigoPostal.KeyDown, TxtNumeroIdentificacionRegistroFiscalExtranjero.KeyDown, TxtCalle.KeyDown, TxtNumeroExterior.KeyDown, TxtNumeroInterior.KeyDown, CboTipoUbicacion.KeyDown
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
                    Me.TxtNombreRemitenteDestinatario.Text = oCliente.NOMBRE_CLIENTE
                    Me.TxtRfcRemitenteDestinatario.Text = oCliente.RFC
                    Me.TxtNumeroIdentificacionRegistroFiscalExtranjero.Text = oCliente.NUMERO_IDENTIFICACION_REGISTRO_FISCAL_EXTRANJERO
                    Me.TxtPaisDomicilio.Text = oCliente.CODIGO_PAIS_SAT

                    txtTAB(e)
            End Select

        Catch ex As Exception
            HandleError(Me.Name, "txtCodigoCliente_KeyDown", ex)
        End Try
    End Sub

    Private Sub txtIdColonia_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtIdColonia.KeyDown
        Dim oColonia As New Class_CfdiCatColonias
        Try
            If txtLEN(Me.TxtCodigoPostal.Text) = False Then
                MsgBox("Asígne un código postal.", MsgBoxStyle.Exclamation, "txtIdColonia_KeyDown")
                Me.TxtIdColonia.Text = "" : Me.LblNombreColonia.Text = ""
                Exit Sub
            End If

            Select Case e.KeyCode
                Case Keys.F6
Buscar:
                    Dim sColonia = oColonia.BusquedaVisual_PorDescripcion(Me.TxtCodigoPostal.Text)
                    If txtLEN(sColonia) = True Then
                        Me.TxtIdColonia.Text = sColonia
                        GoTo Enter : Return
                    End If

                Case Keys.Enter
                    If txtLEN(Me.TxtIdColonia.Text) = False Then
                        Me.LblNombreColonia.Text = ""
                        'GoTo Buscar : Return
                        txtTAB(e) : Return
                    End If
Enter:
                    oColonia = New Class_CfdiCatColonias(Me.TxtIdColonia.Text, Me.TxtCodigoPostal.Text)

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
        Const sProcedure As String = "txtIdLocalidad_KeyDown"
        Dim oLocalidad As New Class_CfdiCatLocalidades
        Try
            Select Case e.KeyCode
                Case Keys.F6
                    If txtLEN(Me.TxtEstado.Text) = False Then
                        Me.LblNombreEstado.Text = ""
                        MsgBox("Seleccione primero el estado.", MsgBoxStyle.Exclamation, sProcedure)
                        Return
                    End If
Buscar:
                    Dim sLocalidad = oLocalidad.BusquedaVisual_PorDescripcion(Me.TxtEstado.Text)
                    If txtLEN(sLocalidad) = True Then
                        Me.TxtIdLocalidad.Text = sLocalidad
                        GoTo Enter : Return
                    End If

                Case Keys.Enter
                    If txtLEN(Me.TxtIdLocalidad.Text) = False Then
                        Me.LblNombreLocalidad.Text = ""
                        'GoTo Buscar : Return
                        txtTAB(e) : Return
                    End If

                    If txtLEN(Me.TxtEstado.Text) = False Then
                        Me.LblNombreEstado.Text = ""
                        MsgBox("Seleccione primero el estado.", MsgBoxStyle.Exclamation, sProcedure)
                        Return
                    End If
Enter:
                    oLocalidad = New Class_CfdiCatLocalidades(Me.TxtIdLocalidad.Text, Me.TxtEstado.Text)

                    If oLocalidad.Existe = False Then
                        Me.LblNombreLocalidad.Text = ""
                        GoTo Buscar : Return
                    ElseIf oLocalidad.ESTATUS = "B" Then
                        MsgBox("La localidad " & Me.TxtIdLocalidad.Text & " está dada de baja.", MsgBoxStyle.Exclamation, sProcedure)
                        GoTo Buscar : Return
                    End If

                    Me.LblNombreLocalidad.Text = oLocalidad.NOMBRE_LOCALIDAD

                    txtTAB(e)
            End Select

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Sub TxtPaisDomicilio_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtPaisDomicilio.KeyDown
        Dim oPais As New Class_CatPaises
        Try
            Select Case e.KeyCode
                Case Keys.F6
Buscar:
                    Dim sPais = oPais.BusquedaVisual_PorDescripcion()
                    If txtLEN(sPais) = True Then
                        Me.TxtPaisDomicilio.Text = sPais
                        GoTo Enter : Return
                    End If

                Case Keys.Enter
                    If txtLEN(Me.TxtPaisDomicilio.Text) = False Then
                        Me.LblNombrePaisDomicilio.Text = ""
                        GoTo Buscar : Return
                    End If
Enter:
                    oPais = New Class_CatPaises(TxtPaisDomicilio.Text)

                    If oPais.Existe = False Then
                        Me.LblNombrePaisDomicilio.Text = ""
                        GoTo Buscar : Return
                    ElseIf oPais.ESTATUS = "B" Then
                        MsgBox("El país " & TxtPaisDomicilio.Text & " está dado de baja.", MsgBoxStyle.Exclamation, Me.Text)
                        GoTo Buscar : Return
                    End If

                    Me.LblNombrePaisDomicilio.Text = oPais.NOMBRE_PAIS

                    txtTAB(e)
            End Select

        Catch ex As Exception
            HandleError(Me.Name, "TxtPaisDomicilio_KeyDown", ex)
        End Try
    End Sub

    Private Sub TxtPaisResidenciaFiscal_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtPaisResidenciaFiscal.KeyDown
        Dim oPais As New Class_CatPaises
        Try
            Select Case e.KeyCode
                Case Keys.F6
Buscar:
                    Dim sPais = oPais.BusquedaVisual_PorDescripcion()
                    If txtLEN(sPais) = True Then
                        Me.TxtPaisResidenciaFiscal.Text = sPais
                        GoTo Enter : Return
                    End If

                Case Keys.Enter
                    If txtLEN(Me.TxtPaisResidenciaFiscal.Text) = False Then
                        Me.LblNombrePaisResidenciaFiscal.Text = ""
                        'GoTo Buscar : Return
                        Me.tsbGrabar.PerformClick() : Return
                    End If
Enter:
                    oPais = New Class_CatPaises(TxtPaisResidenciaFiscal.Text)

                    If oPais.Existe = False Then
                        Me.LblNombrePaisResidenciaFiscal.Text = ""
                        GoTo Buscar : Return
                    ElseIf oPais.ESTATUS = "B" Then
                        MsgBox("El país " & TxtPaisResidenciaFiscal.Text & " está dado de baja.", MsgBoxStyle.Exclamation, Me.Text)
                        GoTo Buscar : Return
                    End If

                    Me.LblNombrePaisResidenciaFiscal.Text = oPais.NOMBRE_PAIS

                    txtTAB(e)
            End Select

        Catch ex As Exception
            HandleError(Me.Name, "TxtPaisResidenciaFiscal_KeyDown", ex)
        End Try
    End Sub

    Private Sub TxtEstado_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtEstado.KeyDown
        Dim oEstado As New Class_SisEstados
        Try
            If txtLEN(Me.TxtPaisDomicilio.Text) = False Then
                MsgBox("Asígne un código de país.", MsgBoxStyle.Exclamation, "TxtEstado_KeyDown")
                Me.TxtEstado.Text = "" : Me.LblNombreEstado.Text = ""
                Exit Sub
            End If

            Select Case e.KeyCode
                Case Keys.F6
Buscar:
                    Dim sEstado = oEstado.BusquedaVisual_PorDescripcion(Me.TxtPaisDomicilio.Text)
                    If txtLEN(sEstado) = True Then
                        Me.TxtEstado.Text = sEstado
                        GoTo Enter : Return
                    End If

                Case Keys.Enter
                    If txtLEN(Me.TxtEstado.Text) = False Then
                        Me.LblNombreEstado.Text = ""
                        GoTo Buscar : Return
                    End If
Enter:
                    oEstado = New Class_SisEstados(TxtEstado.Text, Me.TxtPaisDomicilio.Text)

                    If oEstado.Existe = False Then
                        Me.LblNombreEstado.Text = ""
                        GoTo Buscar : Return
                    End If

                    Me.LblNombreEstado.Text = oEstado.NOMBRE_ESTADO

                    txtTAB(e)
            End Select

        Catch ex As Exception
            HandleError(Me.Name, "TxtEstado_KeyDown", ex)
        End Try
    End Sub

    Private Sub TxtMunicipio_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtMunicipio.KeyDown
        Dim oMunicipio As New Class_CatMunicipios
        Try
            If txtLEN(Me.TxtEstado.Text) = False Then
                MsgBox("Asígne un código de estado.", MsgBoxStyle.Exclamation, "TxtMunicipio_KeyDown")
                Me.TxtMunicipio.Text = "" : Me.LblNombreMunicipio.Text = ""
                Exit Sub
            End If

            Select Case e.KeyCode
                Case Keys.F6
Buscar:
                    Dim sMunicipio = oMunicipio.BusquedaVisual_PorDescripcion(Me.TxtEstado.Text)
                    If txtLEN(sMunicipio) = True Then
                        Me.TxtMunicipio.Text = sMunicipio
                        GoTo Enter : Return
                    End If

                Case Keys.Enter
                    If txtLEN(Me.TxtMunicipio.Text) = False Then
                        Me.LblNombreMunicipio.Text = ""
                        'GoTo Buscar : Return
                        txtTAB(e) : Return
                    End If
Enter:
                    oMunicipio = New Class_CatMunicipios(TxtMunicipio.Text, Me.TxtEstado.Text)

                    If oMunicipio.Existe = False Then
                        Me.LblNombreMunicipio.Text = ""
                        GoTo Buscar : Return
                    ElseIf oMunicipio.ESTATUS = "B" Then
                        MsgBox("El municipio " & TxtMunicipio.Text & " está dado de baja.", MsgBoxStyle.Exclamation, Me.Text)
                        GoTo Buscar : Return
                    End If

                    Me.LblNombreMunicipio.Text = oMunicipio.NOMBRE_MUNICIPIO

                    txtTAB(e)
            End Select

        Catch ex As Exception
            HandleError(Me.Name, "TxtMunicipio_KeyDown", ex)
        End Try
    End Sub

    Private Sub CboEstatus_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CboEstatus.KeyDown
        If e.KeyCode = Keys.Return Then
            tsbGrabar.PerformClick()
        End If
    End Sub

#End Region

#End Region

End Class