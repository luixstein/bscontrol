Option Strict On
Imports System.Data
Imports System.Data.SqlClient

Public Class Class_NominaMovimientoSua

#Region "Campos"

#Region "Campos de la tabla"
    Private _ID_NOMINA_SEMANA As Integer
    Private _CODIGO_TRABAJADOR As String
    Private _FECHA_ALTA As Date
    Private _NOMBRE_TXT_ALTA As String
    Private _INTEGRACION_SUA_ALTA As String
    Private _ESTATUS_BAJA As String
    Private _FECHA_BAJA As Date
    Private _NOMBRE_TXT_BAJA As String
    Private _INTEGRACION_SUA_BAJA As String
#End Region

#Region "Campos ligados a la tabla"
    Private _Existe As Boolean 'lectura
#End Region

#Region "Campos públicos"

#End Region

#Region "Campos privados"

#End Region

#Region "Campos de sistema"
    Private _Nombre_Clase As String
    Private _Conexion As SqlConnection
    Private _QuerySelect As String
    Private _QueryOrder As String
#End Region
#End Region

#Region "Propiedades"

#Region "Propiedades Campos de la tabla"
    Public Property ID_NOMINA_SEMANA() As Integer
        Get
            Return Me._ID_NOMINA_SEMANA
        End Get
        Set(ByVal Value As Integer)
            Me._ID_NOMINA_SEMANA = Value
        End Set
    End Property

    Public Property CODIGO_TRABAJADOR() As String
        Get
            Return Me._CODIGO_TRABAJADOR
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_TRABAJADOR = Value
        End Set
    End Property

    Public Property FECHA_ALTA() As Date
        Get
            Return Me._FECHA_ALTA
        End Get
        Set(ByVal Value As Date)
            Me._FECHA_ALTA = Value
        End Set
    End Property

    Public Property NOMBRE_TXT_ALTA() As String
        Get
            Return Me._NOMBRE_TXT_ALTA
        End Get
        Set(ByVal Value As String)
            Me._NOMBRE_TXT_ALTA = Value
        End Set
    End Property

    Public Property INTEGRACION_SUA_ALTA() As String
        Get
            Return Me._INTEGRACION_SUA_ALTA
        End Get
        Set(ByVal Value As String)
            Me._INTEGRACION_SUA_ALTA = Value
        End Set
    End Property

    Public Property ESTATUS_BAJA() As String
        Get
            Return Me._ESTATUS_BAJA
        End Get
        Set(ByVal Value As String)
            Me._ESTATUS_BAJA = Value
        End Set
    End Property

    Public Property FECHA_BAJA() As Date
        Get
            Return Me._FECHA_BAJA
        End Get
        Set(ByVal Value As Date)
            Me._FECHA_BAJA = Value
        End Set
    End Property

    Public Property NOMBRE_TXT_BAJA() As String
        Get
            Return Me._NOMBRE_TXT_BAJA
        End Get
        Set(ByVal Value As String)
            Me._NOMBRE_TXT_BAJA = Value
        End Set
    End Property

    Public Property INTEGRACION_SUA_BAJA() As String
        Get
            Return Me._INTEGRACION_SUA_BAJA
        End Get
        Set(ByVal Value As String)
            Me._INTEGRACION_SUA_BAJA = Value
        End Set
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
    'Public ReadOnly Property CODIGO_MODULO() As String
    '    Get
    '        Return "" 'NOMINA
    '    End Get
    'End Property
#End Region

#Region "Propiedades de campos privados"

#End Region

#Region "Propiedades de campos de sistema"
    Public ReadOnly Property Nombre_Clase() As String
        Get
            Me._Nombre_Clase = "Class_NominaMovimientoSua"
            Return Me._Nombre_Clase
        End Get
    End Property
#End Region

#End Region

#Region "Constructor y destructor"
    Public Sub New(ByVal iIdSemana As Integer, ByVal sTrabajador As String)
        Me.New()
        Me._ID_NOMINA_SEMANA = iIdSemana
        Me._CODIGO_TRABAJADOR = sTrabajador
        Try
            If Me.Consultar = True Then
                Me._Existe = True
                'Else
                '   Throw New Exception("La cuenta bancaria no existe.")
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "New", ex)
        End Try
    End Sub

    Public Sub New()
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "SELECT* FROM NOMINA_MOVIMIENTOS_IMSS "
        Me._QueryOrder = " ORDER BY FECHA_ALTA,CODIGO_TRABAJADOR "
    End Sub

    Protected Overrides Sub Finalize()
        'Me._Conexion.Dispose()
        MyBase.Finalize()
    End Sub
#End Region

#Region "Métodos y procedimientos"

    Public Function Actualizar() As Boolean
    
    End Function

    Public Function Insertar() As Boolean
       
    End Function

    Public Function Consultar() As Boolean
        Dim cmd As New SqlCommand(Me._QuerySelect & " WHERE ID_NOMINA_SEMANA=" & Me._ID_NOMINA_SEMANA.ToString & " AND CODIGO_TRABAJADOR=" & Me._CODIGO_TRABAJADOR, Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()
                If dReader.Read Then
                    Me._FECHA_ALTA = CDate(dReader("FECHA_ALTA"))
                    Me._NOMBRE_TXT_ALTA = "" & dReader("NOMBRE_TXT_ALTA").ToString
                    Me._INTEGRACION_SUA_ALTA = "" & dReader("INTEGRACION_SUA_ALTA").ToString
                    Me._ESTATUS_BAJA = "" & dReader("ESTATUS_BAJA").ToString
                    Me._FECHA_BAJA = CDate(dReader("FECHA_BAJA"))
                    Me._NOMBRE_TXT_BAJA = "" & dReader("NOMBRE_TXT_BAJA").ToString
                    Me._INTEGRACION_SUA_BAJA = "" & dReader("INTEGRACION_SUA_BAJA").ToString

                    Consultar = True
                End If
                dReader.Close()
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "Consultar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
            End Try
        End With
    End Function

    Public Function ObtenerDetalle(ByVal sNombreTxt As String) As DataTable
        Dim dTable As New DataTable
        Dim sNombre As String

        sNombre = "AND (M.NOMBRE_TXT_ALTA='" & sNombreTxt & "' OR M.NOMBRE_TXT_BAJA='" & sNombreTxt & "')"

        Dim dsNominaArchivosAlta As New SqlDataAdapter("SELECT M.CODIGO_TRABAJADOR, T.APELLIDO_PATERNO, T.APELLIDO_MATERNO, T.NOMBRE_TRABAJADOR,M.FECHA_ALTA " & _
        ",M.NOMBRE_TXT_ALTA,M.INTEGRACION_SUA_ALTA,M.ESTATUS_BAJA,M.FECHA_BAJA,M.NOMBRE_TXT_BAJA,M.INTEGRACION_SUA_BAJA " & _
        "FROM NOMINA_MOVIMIENTOS_IMSS M INNER JOIN NOMINA_CAT_TRABAJADORES T ON (M.CODIGO_TRABAJADOR=T.CODIGO_TRABAJADOR) " & _
        "WHERE M.ID_NOMINA_SEMANA=" & Me._ID_NOMINA_SEMANA.ToString & sNombre, Me._Conexion)
        Try
            dsNominaArchivosAlta.Fill(dTable)
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "ObtenerElementos", ex)
        Finally
            dsNominaArchivosAlta.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerElementos() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim SqlArchivos As String

        SqlArchivos = "SELECT DISTINCT(NOMBRE_TXT_ALTA)+ CASE WHEN INTEGRACION_SUA_ALTA='1' THEN ' INTEGRADO' ELSE '' END NOMBRE_TXT,'ALTA' TIPO_MOVIMIENTO " & _
                      "FROM NOMINA_MOVIMIENTOS_IMSS WHERE LEN(NOMBRE_TXT_ALTA)>0 AND ID_NOMINA_SEMANA=" & Me._ID_NOMINA_SEMANA.ToString & _
                      "UNION " & _
                      "SELECT DISTINCT(NOMBRE_TXT_BAJA)+ CASE WHEN INTEGRACION_SUA_BAJA='1' THEN ' INTEGRADO' ELSE '' END,'BAJA' " & _
                      "FROM NOMINA_MOVIMIENTOS_IMSS WHERE LEN(NOMBRE_TXT_BAJA)>0 AND ID_NOMINA_SEMANA=" & Me._ID_NOMINA_SEMANA.ToString

        Dim dsNominaArchivos As New SqlDataAdapter(SqlArchivos, Me._Conexion)

        Try
            dsNominaArchivos.Fill(dTable)
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "ObtenerElementos", ex)
        Finally
            dsNominaArchivos.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerMovimientosTrabajador(ByVal sCodigoTrabajador As String) As System.Data.DataTable
        Dim dTable As New DataTable
        Dim SqlArchivos As String

        SqlArchivos = "SELECT ISNULL(FECHA_ALTA,'') fecha_movimiento,'ALTA' TIPO_MOVIMIENTO ,ID_MOVIMIENTO " & _
                      "FROM NOMINA_MOVIMIENTOS_IMSS WHERE LEN(NOMBRE_TXT_ALTA)>0 AND CODIGO_TRABAJADOR='" & sCodigoTrabajador & "' " & _
                      "UNION " & _
                      "SELECT ISNULL(FECHA_BAJA,''),'BAJA',ID_MOVIMIENTO " & _
                      "FROM NOMINA_MOVIMIENTOS_IMSS WHERE LEN(NOMBRE_TXT_BAJA)>0 AND CODIGO_TRABAJADOR='" & sCodigoTrabajador & "' " & _
                      "order by ID_MOVIMIENTO"

        Dim dsNominaArchivos As New SqlDataAdapter(SqlArchivos, Me._Conexion)

        Try
            dsNominaArchivos.Fill(dTable)
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "ObtenerMovimientosTrabajador", ex)
        Finally
            dsNominaArchivos.Dispose()
        End Try
        Return dTable
    End Function

    Public Function EliminaElementos(ByVal sNombreTxt As String, ByVal sMovimiento As String) As Boolean
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_NOMINA_AFILIACIONES_ELIMINA_MOVIMIENTOS_SEMANA_IMSS"

            sqlParametro = .Parameters.Add("@ID_NOMINA_SEMANA", SqlDbType.Int) : sqlParametro.Value = Me._ID_NOMINA_SEMANA
            sqlParametro = .Parameters.Add("@NOMBRE_TXT", SqlDbType.NVarChar, 225) : sqlParametro.Value = sNombreTxt
            sqlParametro = .Parameters.Add("@TIPO_MOVIMIENTO", SqlDbType.NVarChar, 5) : sqlParametro.Value = sMovimiento

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                EliminaElementos = True
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "EliminaElementos", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
    End Function

    Public Function EliminarMovimientoRechazado(ByVal sCodigoTrabajador As String, ByVal sNombreTxt As String, ByVal sMovimiento As String) As Boolean
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_NOMINA_INTEGRACION_MOVIMIENTOS_SEMANA_IMSS_ELIMINA_RECHAZADO"

            sqlParametro = .Parameters.Add("@ID_NOMINA_SEMANA", SqlDbType.Int) : sqlParametro.Value = Me._ID_NOMINA_SEMANA
            sqlParametro = .Parameters.Add("@NOMBRE_TXT", SqlDbType.NVarChar, 225) : sqlParametro.Value = sNombreTxt
            sqlParametro = .Parameters.Add("@TIPO_MOVIMIENTO", SqlDbType.NVarChar, 5) : sqlParametro.Value = sMovimiento
            sqlParametro = .Parameters.Add("@CODIGO_TRABAJADOR", SqlDbType.NVarChar, 10) : sqlParametro.Value = sCodigoTrabajador

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                EliminarMovimientoRechazado = True
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "EliminarMovimientoRechazado", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
    End Function

    Public Function Integracion(ByVal sNombreTxt As String, ByVal sMovimiento As String) As Boolean
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_NOMINA_AFILICACIONES_ELIMINA_MOVIMIENTOS_SEMANA_IMSS"

            sqlParametro = .Parameters.Add("@ID_NOMINA_SEMANA", SqlDbType.Int) : sqlParametro.Value = Me._ID_NOMINA_SEMANA
            sqlParametro = .Parameters.Add("@NOMBRE_TXT", SqlDbType.NVarChar, 225) : sqlParametro.Value = sNombreTxt
            sqlParametro = .Parameters.Add("@TIPO_MOVIMIENTO", SqlDbType.NVarChar, 5) : sqlParametro.Value = sMovimiento

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                Integracion = True
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "Integracion", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
    End Function

    Public Function IntegraMovimientos(ByVal sNombreTxt As String, ByVal sMovimiento As String) As Boolean
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_NOMINA_INTEGRACION_MOVIMIENTOS_SEMANA_IMSS"

            sqlParametro = .Parameters.Add("@ID_NOMINA_SEMANA", SqlDbType.Int) : sqlParametro.Value = Me._ID_NOMINA_SEMANA
            sqlParametro = .Parameters.Add("@NOMBRE_TXT", SqlDbType.NVarChar, 225) : sqlParametro.Value = sNombreTxt
            sqlParametro = .Parameters.Add("@TIPO_MOVIMIENTO", SqlDbType.NVarChar, 5) : sqlParametro.Value = sMovimiento

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                IntegraMovimientos = True
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "IntegraMovimientos", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
    End Function

    Public Function EditaMovimientosIntegrados(ByVal sMovimiento As String, ByVal sFecha As String, ByVal sFechaNueva As String, ByVal sCodigoTrabajador As String, ByVal sAccion As String) As Boolean
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_NOMINA_INTEGRACION_MOVIMIENTOS_SEMANA_IMSS_EDITAR"

            'sqlParametro = .Parameters.Add("@ID_NOMINA_TEMPORADA", SqlDbType.SmallInt) : sqlParametro.Value = Plaza.NOMINA_ID_NOMINA_TEMPORADA_ACTIVA
            'sqlParametro = .Parameters.Add("@NUMERO_SEMANA", SqlDbType.SmallInt) : sqlParametro.Value = Me._NUMERO_SEMANA
            sqlParametro = .Parameters.Add("@TIPO_MOVIMIENTO", SqlDbType.NVarChar, 5) : sqlParametro.Value = sMovimiento
            sqlParametro = .Parameters.Add("@FECHA_MOVIMIENTO", SqlDbType.NVarChar, 20) : sqlParametro.Value = sFecha
            sqlParametro = .Parameters.Add("@FECHA_MOVIMIENTO_NUEVA", SqlDbType.NVarChar, 20) : sqlParametro.Value = sFechaNueva
            sqlParametro = .Parameters.Add("@CODIGO_TRABAJADOR", SqlDbType.NVarChar, 10) : sqlParametro.Value = sCodigoTrabajador
            sqlParametro = .Parameters.Add("@ACCION", SqlDbType.NVarChar, 225) : sqlParametro.Value = sAccion

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                EditaMovimientosIntegrados = True
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "EditaMovimientosIntegrados", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
    End Function

    Public Function InsertaMovimientosImss(ByVal sMovimiento As String, ByVal sFecha As String, ByVal sNombreTxt As String, ByVal sCodigoTrabajador As String, ByVal iIdMovimiento As String) As Boolean
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_NOMINA_MOVIMIENTOS_IMSS_GRABA"

            sqlParametro = .Parameters.Add("@ID_NOMINA_SEMANA", SqlDbType.Int) : sqlParametro.Value = Me._ID_NOMINA_SEMANA
            sqlParametro = .Parameters.Add("@NOMBRE_TXT", SqlDbType.NVarChar, 225) : sqlParametro.Value = sNombreTxt
            sqlParametro = .Parameters.Add("@TIPO_MOVIMIENTO", SqlDbType.NVarChar, 5) : sqlParametro.Value = sMovimiento
            sqlParametro = .Parameters.Add("@FECHA_MOVIMIENTO", SqlDbType.NVarChar, 20) : sqlParametro.Value = Format(CDate(sFecha), "yyyy-dd-MM")
            sqlParametro = .Parameters.Add("@CODIGO_TRABAJADOR", SqlDbType.NVarChar, 10) : sqlParametro.Value = sCodigoTrabajador
            sqlParametro = .Parameters.Add("@ID_MOVIMIENTO", SqlDbType.NVarChar, 10) : sqlParametro.Value = iIdMovimiento
            'sqlParametro = .Parameters.Add("@ACCION", SqlDbType.NVarChar, 225) : sqlParametro.Value = sAccion

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                InsertaMovimientosImss = True
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "InsertaMovimientosImss", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
    End Function

    Public Function ValidaInformacionIMSSTrabajador(ByVal sCodigoTrabajador As String, ByVal idSemana As Integer) As System.Data.DataTable
        Dim dTable As New DataTable
        Dim SqlArchivos As String

        SqlArchivos = "SELECT * FROM DBO.FN_NOMINA_AFILIACIONES_VALIDA_INFORMACION_IMSS_TRABAJADOR('" & sCodigoTrabajador & "'," & idSemana & ")"

        Dim dsNominaArchivos As New SqlDataAdapter(SqlArchivos, Me._Conexion)

        Try
            dsNominaArchivos.Fill(dTable)
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "ValidaInformacionIMSSTrabajador", ex)
        Finally
            dsNominaArchivos.Dispose()
        End Try
        Return dTable
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
