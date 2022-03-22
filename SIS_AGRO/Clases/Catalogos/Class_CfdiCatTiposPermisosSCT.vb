Imports System.Data
Imports System.Data.SqlClient

Public Class Class_CfdiCatTiposPermisosSCT
    Inherits Class_Catalogos

#Region "Campos"

#Region "Campos de la tabla"
    Private _CODIGO_PERMISO_SCT As String
    Private _NOMBRE_PERMISO_SCT As String
    Private _LISTA_CODIGOS_TRANSPORTE As String

#End Region

#Region "Campos ligados a la tabla"
    Private _Existe As Boolean
#End Region

#Region "Campos públicos"

#End Region

#Region "Campos privados"

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
    Public ReadOnly Property CODIGO_PERMISO_SCT() As String
        Get
            Return Me._CODIGO_PERMISO_SCT
        End Get
    End Property

    Public ReadOnly Property NOMBRE_PERMISO_SCT() As String
        Get
            Return Me._NOMBRE_PERMISO_SCT
        End Get
    End Property

    Public ReadOnly Property LISTA_CODIGOS_TRANSPORTE() As String
        Get
            Return Me._LISTA_CODIGOS_TRANSPORTE
        End Get
    End Property

#End Region

#Region "Propiedades de campos ligados a la tabla"
    Public ReadOnly Property Existe() As Boolean
        Get
            Return Me._Existe
        End Get
    End Property
#End Region

#Region "Propiedades públicos"

#End Region

#Region "Propiedades de campos privados"

#End Region

#Region "Propiedades de campos de sistema"

    Public Overrides ReadOnly Property Nombre_Catalogo() As String
        Get
            Return Me._Nombre_Catalogo
        End Get
    End Property

    Public Overrides Property Nombre_Reporte() As String
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

    Public Sub New()
        Me._Nombre_Catalogo = "CFDI_CAT_TIPOS_PERMISOS_SCT"
        Me._Nombre_Reporte = "RPT_CATALOGO_CFDI_TIPOS_PERMISOS_SCT"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "Select * From CFDI_CAT_TIPOS_PERMISOS_SCT"
        Me._QueryOrder = " Order by NOMBRE_PERMISO_SCT"
    End Sub                                                         'Inicializa al objeto.

    Public Sub New(ByVal sCodigoPermisoSCT As String)
        Me.New()
        Try
            Me._CODIGO_PERMISO_SCT = sCodigoPermisoSCT
            If Me.Consultar = True Then
                Me._Existe = True

            End If
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "New", ex)
        End Try
    End Sub

    Protected Overrides Sub Finalize()
        'Me._Conexion.Dispose()
        MyBase.Finalize()
    End Sub
#End Region

#Region "Opciones"

#End Region

#Region "Métodos y procedimientos"

    Public Overrides Function Insertar() As Boolean
        Dim bResultado As Boolean = False
        'Dim cmd As New SqlCommand
        'Dim sqlParametro As SqlParameter
        'With cmd
        '    .Connection = Me._Conexion
        '    .CommandTimeout = 0
        '    .CommandType = CommandType.StoredProcedure
        '    .CommandText = "MP_CFDI_CAT_UBICACIONES_GRABA"

        '    sqlParametro = .Parameters.Add("@CODIGO_UBICACION", SqlDbType.Int) : sqlParametro.Value = CInt(Me._CODIGO_UBICACION) : sqlParametro.Direction = ParameterDirection.InputOutput
        '    sqlParametro = .Parameters.Add("@CODIGO_CLIENTE", SqlDbType.NVarChar, 8) : sqlParametro.Value = Me._CODIGO_CLIENTE.ToString.ToUpper
        '    sqlParametro = .Parameters.Add("@ESTATUS", SqlDbType.Char, 1) : sqlParametro.Value = Me.Estatus
        '    sqlParametro = .Parameters.Add("@TIPO_UBICACION", SqlDbType.NVarChar, 10) : sqlParametro.Value = Me._TIPO_UBICACION.ToString.ToUpper
        '    sqlParametro = .Parameters.Add("@ID_UBICACION", SqlDbType.NVarChar, 8) : sqlParametro.Value = Me._ID_UBICACION.ToString.ToUpper
        '    sqlParametro = .Parameters.Add("@RFC_REMITENTE_DESTINATARIO", SqlDbType.NVarChar, 13) : sqlParametro.Value = Me._RFC_REMITENTE_DESTINATARIO.ToString.ToUpper
        '    sqlParametro = .Parameters.Add("@NOMBRE_REMITENTE_DESTINATARIO", SqlDbType.NVarChar, 254) : sqlParametro.Value = Me._NOMBRE_REMITENTE_DESTINATARIO.ToUpper
        '    sqlParametro = .Parameters.Add("@NUMERO_IDENTIFICACION_REGISTRO_FISCAL_EXTRANJERO", SqlDbType.NVarChar, 40) : sqlParametro.Value = Me._NUMERO_IDENTIFICACION_REGISTRO_FISCAL_EXTRANJERO.ToUpper
        '    sqlParametro = .Parameters.Add("@CODIGO_PAIS_SAT_RESIDENCIA_FISCAL", SqlDbType.NVarChar, 4) : sqlParametro.Value = Me._CODIGO_PAIS_SAT_RESIDENCIA_FISCAL.ToUpper
        '    sqlParametro = .Parameters.Add("@DISTANCIA_RECORRIDA", SqlDbType.Decimal) : sqlParametro.Value = valorNumericoD(Me._DISTANCIA_RECORRIDA)
        '    sqlParametro = .Parameters.Add("@CALLE", SqlDbType.NVarChar, 100) : sqlParametro.Value = Me._CALLE.ToUpper
        '    sqlParametro = .Parameters.Add("@NUMERO_EXTERIOR", SqlDbType.NVarChar, 55) : sqlParametro.Value = Me._NUMERO_EXTERIOR.ToUpper
        '    sqlParametro = .Parameters.Add("@NUMERO_INTERIOR", SqlDbType.NVarChar, 55) : sqlParametro.Value = Me._NUMERO_INTERIOR.ToUpper
        '    sqlParametro = .Parameters.Add("@ID_COLONIA", SqlDbType.Int) : sqlParametro.Value = CInt(Me._ID_COLONIA)
        '    sqlParametro = .Parameters.Add("@ID_LOCALIDAD", SqlDbType.Int) : sqlParametro.Value = CInt(Me._ID_LOCALIDAD)
        '    sqlParametro = .Parameters.Add("@REFERENCIA", SqlDbType.NVarChar, 250) : sqlParametro.Value = Me._REFERENCIA.ToUpper
        '    sqlParametro = .Parameters.Add("@CODIGO_MUNICIPIO", SqlDbType.SmallInt) : sqlParametro.Value = CInt(Me._CODIGO_MUNICIPIO)
        '    sqlParametro = .Parameters.Add("@CODIGO_ESTADO_SAT", SqlDbType.NVarChar, 4) : sqlParametro.Value = Me._CODIGO_ESTADO_SAT.ToUpper
        '    sqlParametro = .Parameters.Add("@CODIGO_PAIS_SAT_DOMICILIO", SqlDbType.NVarChar, 4) : sqlParametro.Value = Me._CODIGO_PAIS_SAT_DOMICILIO.ToUpper
        '    sqlParametro = .Parameters.Add("@CODIGO_POSTAL", SqlDbType.NVarChar, 12) : sqlParametro.Value = Me._CODIGO_POSTAL.ToUpper
        '    sqlParametro = .Parameters.Add("@CODIGO_USUARIO_CREO", SqlDbType.SmallInt) : sqlParametro.Value = CInt(Me._CODIGO_USUARIO_CREO)
        '    sqlParametro = .Parameters.Add("@FECHA_CREO", SqlDbType.DateTime) : sqlParametro.Value = Me._FECHA_CREO
        '    sqlParametro = .Parameters.Add("@CODIGO_USUARIO_MODIFICO", SqlDbType.SmallInt) : sqlParametro.Value = CInt(Me._CODIGO_USUARIO_MODIFICO)
        '    sqlParametro = .Parameters.Add("@FECHA_MODIFICO", SqlDbType.DateTime) : sqlParametro.Value = Me._FECHA_MODIFICO
        '    sqlParametro = .Parameters.Add("@ACCION", SqlDbType.NVarChar, 20) : sqlParametro.Value = "INSERTAR"
        '    Try
        '        Me._Conexion.Open()
        '        .ExecuteNonQuery()
        '        bResultado = True
        '        Me._CODIGO_UBICACION = "" & .Parameters("@CODIGO_UBICACION").Value.ToString
        '    Catch ex As Exception
        '        HandleError(Me._Nombre_Catalogo, "Insertar", ex)
        '    Finally
        '        Me._Conexion.Close()
        '        cmd.Dispose()
        '        sqlParametro = Nothing
        '    End Try
        'End With
        Return bResultado
    End Function

    Public Overrides Function Actualizar() As Boolean
        Dim bResultado As Boolean = False
        'Dim cmd As New SqlCommand
        'Dim sqlParametro As SqlParameter
        'With cmd
        '    .Connection = Me._Conexion
        '    .CommandTimeout = 0
        '    .CommandType = CommandType.StoredProcedure
        '    .CommandText = "MP_CAT_VEHICULOS_GRABA"

        '    sqlParametro = .Parameters.Add("@CODIGO_UBICACION", SqlDbType.Int) : sqlParametro.Value = CInt(Me._CODIGO_UBICACION)
        '    sqlParametro = .Parameters.Add("@CODIGO_CLIENTE", SqlDbType.NVarChar, 8) : sqlParametro.Value = Me._CODIGO_CLIENTE.ToString.ToUpper
        '    sqlParametro = .Parameters.Add("@ESTATUS", SqlDbType.Char, 1) : sqlParametro.Value = Me.Estatus
        '    sqlParametro = .Parameters.Add("@TIPO_UBICACION", SqlDbType.NVarChar, 10) : sqlParametro.Value = Me._TIPO_UBICACION.ToString.ToUpper
        '    sqlParametro = .Parameters.Add("@ID_UBICACION", SqlDbType.NVarChar, 8) : sqlParametro.Value = Me._ID_UBICACION.ToString.ToUpper
        '    sqlParametro = .Parameters.Add("@RFC_REMITENTE_DESTINATARIO", SqlDbType.NVarChar, 13) : sqlParametro.Value = Me._RFC_REMITENTE_DESTINATARIO.ToString.ToUpper
        '    sqlParametro = .Parameters.Add("@NOMBRE_REMITENTE_DESTINATARIO", SqlDbType.NVarChar, 254) : sqlParametro.Value = Me._NOMBRE_REMITENTE_DESTINATARIO.ToUpper
        '    sqlParametro = .Parameters.Add("@NUMERO_IDENTIFICACION_REGISTRO_FISCAL_EXTRANJERO", SqlDbType.NVarChar, 40) : sqlParametro.Value = Me._NUMERO_IDENTIFICACION_REGISTRO_FISCAL_EXTRANJERO.ToUpper
        '    sqlParametro = .Parameters.Add("@CODIGO_PAIS_SAT_RESIDENCIA_FISCAL", SqlDbType.NVarChar, 4) : sqlParametro.Value = Me._CODIGO_PAIS_SAT_RESIDENCIA_FISCAL.ToUpper
        '    sqlParametro = .Parameters.Add("@DISTANCIA_RECORRIDA", SqlDbType.Decimal) : sqlParametro.Value = valorNumericoD(Me._DISTANCIA_RECORRIDA)
        '    sqlParametro = .Parameters.Add("@CALLE", SqlDbType.NVarChar, 100) : sqlParametro.Value = Me._CALLE.ToUpper
        '    sqlParametro = .Parameters.Add("@NUMERO_EXTERIOR", SqlDbType.NVarChar, 55) : sqlParametro.Value = Me._NUMERO_EXTERIOR.ToUpper
        '    sqlParametro = .Parameters.Add("@NUMERO_INTERIOR", SqlDbType.NVarChar, 55) : sqlParametro.Value = Me._NUMERO_INTERIOR.ToUpper
        '    sqlParametro = .Parameters.Add("@ID_COLONIA", SqlDbType.Int) : sqlParametro.Value = CInt(Me._ID_COLONIA)
        '    sqlParametro = .Parameters.Add("@ID_LOCALIDAD", SqlDbType.Int) : sqlParametro.Value = CInt(Me._ID_LOCALIDAD)
        '    sqlParametro = .Parameters.Add("@REFERENCIA", SqlDbType.NVarChar, 250) : sqlParametro.Value = Me._REFERENCIA.ToUpper
        '    sqlParametro = .Parameters.Add("@CODIGO_MUNICIPIO", SqlDbType.SmallInt) : sqlParametro.Value = CInt(Me._CODIGO_MUNICIPIO)
        '    sqlParametro = .Parameters.Add("@CODIGO_ESTADO_SAT", SqlDbType.NVarChar, 4) : sqlParametro.Value = Me._CODIGO_ESTADO_SAT.ToUpper
        '    sqlParametro = .Parameters.Add("@CODIGO_PAIS_SAT_DOMICILIO", SqlDbType.NVarChar, 4) : sqlParametro.Value = Me._CODIGO_PAIS_SAT_DOMICILIO.ToUpper
        '    sqlParametro = .Parameters.Add("@CODIGO_POSTAL", SqlDbType.NVarChar, 12) : sqlParametro.Value = Me._CODIGO_POSTAL.ToUpper
        '    sqlParametro = .Parameters.Add("@CODIGO_USUARIO_CREO", SqlDbType.SmallInt) : sqlParametro.Value = CInt(Me._CODIGO_USUARIO_CREO)
        '    sqlParametro = .Parameters.Add("@FECHA_CREO", SqlDbType.DateTime) : sqlParametro.Value = Me._FECHA_CREO
        '    sqlParametro = .Parameters.Add("@CODIGO_USUARIO_MODIFICO", SqlDbType.SmallInt) : sqlParametro.Value = CInt(Me._CODIGO_USUARIO_MODIFICO)
        '    sqlParametro = .Parameters.Add("@FECHA_MODIFICO", SqlDbType.DateTime) : sqlParametro.Value = Me._FECHA_MODIFICO
        '    sqlParametro = .Parameters.Add("@ACCION", SqlDbType.NVarChar, 20) : sqlParametro.Value = "ACTUALIZAR"
        '    Try
        '        Me._Conexion.Open()
        '        .ExecuteNonQuery()
        '        bResultado = True
        '    Catch ex As Exception
        '        HandleError(Me._Nombre_Catalogo, "Actualizar", ex)
        '    Finally
        '        Me._Conexion.Close()
        '        cmd.Dispose()
        '        sqlParametro = Nothing
        '    End Try
        'End With
        Return bResultado
    End Function

    Public Overrides Function Consultar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand("Select * from CFDI_CAT_TIPOS_PERMISOS_SCT Where CODIGO_PERMISO_SCT='" & sReplace(Me._CODIGO_PERMISO_SCT) & "'", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._CODIGO_PERMISO_SCT = "" & dReader("CODIGO_PERMISO_SCST").ToString
                    Me._NOMBRE_PERMISO_SCT = "" & dReader("NOMBRE_PERMISO_SCST").ToString
                    Me._LISTA_CODIGOS_TRANSPORTE = "" & dReader("LISTA_CODIGOS_TRANSPORTE")

                    bResultado = True
                End If
                dReader.Close()
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "Consultar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
            End Try
        End With
        Return bResultado
    End Function

    Public Overrides Function ObtenerElementos() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter(Me._QuerySelect & Me._QueryOrder, Me._Conexion)
        Try
            da.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementos", ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerElementosParaReportes() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter(Me._QuerySelect & Me._QueryOrder, Me._Conexion)
        Try
            da.Fill(dTable)
            dTable.Rows.Add("-1", "TODOS")
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementosParaReportes", ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerElementosFiltro(ByVal Filtro As String) As System.Data.DataTable
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter("SELECT CODIGO_PERMISO_SCT,NOMBRE_PERMISO_SCT FROM CFDI_CAT_TIPOS_PERMISOS_SCT WHERE NOMBRE_PERMISO_SCT LIKE '" & Filtro.ToString & "%' ORDER BY NOMBRE_PERMISO_SCT", Me._Conexion)
        Try
            da.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementosFiltro", ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

    Public Overrides Function BusquedaVisual_PorCodigo() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de permisos SCT por codigo."
        f.sCampo = "CODIGO_PERMISO_SCT"
        f.sOrder = "NOMBRE_PERMISO_SCT"
        f.sTable = "CFDI_CAT_TIPOS_PERMISOS_SCT"
        f.sQl = "Select CODIGO_PERMISOS_SCT,NOMBRE_PERMISOS_SCT From CFDI_CAT_TIPOS_PERMISOS_SCT Where 1=1 And"
        f.Inicia("")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "BusquedaVisual_PorCodigo", ex)
        End Try
        Return Resultado
    End Function

    Public Overrides Function BusquedaVisual_PorDescripcion() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de permisos SCT por nombre."
        f.sCampo = "NOMBRE_PERMISO_SCT"
        f.sOrder = "NOMBRE_PERMISO_SCT"
        f.sTable = "CFDI_CAT_TIPOS_PERMISOS_SCT"
        f.sQl = "Select CODIGO_PERMISO_SCT,NOMBRE_PERMISO_SCT From CFDI_CAT_TIPOS_PERMISOS_SCT Where 1=1 And"
        f.Inicia("")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "BusquedaVisual_PorDescripcion", ex)
        End Try
        Return Resultado
    End Function

#End Region

#Region "Eventos de objetos"


#Region "Eventos de la lista de elementos"

#End Region

#Region " Eventos de TxtFiltro"

#End Region

#Region "Eventos Genericos"

#End Region


#Region "Keydown específicos"


#End Region

#Region "Validating específicos"

#End Region



#End Region

End Class