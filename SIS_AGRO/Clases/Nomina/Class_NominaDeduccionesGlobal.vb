Option Strict On

Imports System.Data.SqlClient

Public Class Class_NominaDeduccionesGlobal

#Region "Campos"

#Region "Campos de la tabla"
    Private _ID_DEDUCCION_GLOBAL As Integer
    Private _CODIGO_TIPO_DEDUCCION As Integer
    Private _ID_NOMINA_SEMANA As Integer
    Private _CODIGO_TRABAJADOR As String
    'Private _NUMERO_SEMANA As Integer
    Private _IMPORTE As Double
    Private _SALDO As Double
    Private _FECHA_SERVIDOR As Date
    Private _CODIGO_USUARIO_GRABO As Integer
    Private _NOMBRE_USUARIO_GRABO As String
    Private _ID_NOMIA_PERCEPCION As Integer
    Private _DESCUENTO_SEMANAL As Double
    Private _CONCEPTO As String
#End Region

#Region "Campos ligados a la tabla"
    Private _Existe As Boolean 'lectura
    Private _CODIGO_X_TEMPORADA As String
#End Region

#Region "Clase Detalle"
    Public oDeduccionDetalle As New Class_NominaDeduccionesDetalle
#End Region

#Region "Campos de sistema"
    Private _Nombre_Catalogo As String
    Private _Conexion As SqlConnection
    Private _QuerySelect As String
#End Region

#End Region

#Region "Propiedades"

#Region "Propiedades Campos de la tabla"
    Public Property ID_DEDUCCION_GLOBAL() As Integer
        Get
            Return Me._ID_DEDUCCION_GLOBAL
        End Get
        Set(ByVal value As Integer)
            Me._ID_DEDUCCION_GLOBAL = value
        End Set
    End Property

    Public Property CODIGO_TIPO_DEDUCCION() As Integer
        Get
            Return Me._CODIGO_TIPO_DEDUCCION
        End Get
        Set(ByVal value As Integer)
            Me._CODIGO_TIPO_DEDUCCION = value
        End Set
    End Property

    Public Property ID_NOMINA_SEMANA() As Integer
        Get
            Return Me._ID_NOMINA_SEMANA
        End Get
        Set(ByVal value As Integer)
            Me._ID_NOMINA_SEMANA = value
        End Set
    End Property

    Public Property CODIGO_TRABAJADOR() As String
        Get
            Return Me._CODIGO_TRABAJADOR
        End Get
        Set(ByVal value As String)
            Me._CODIGO_TRABAJADOR = value
        End Set
    End Property

    'Public Property NUMERO_SEMANA() As Integer
    '    Get
    '        Return Me._NUMERO_SEMANA
    '    End Get
    '    Set(ByVal value As Integer)
    '        Me._NUMERO_SEMANA = value
    '    End Set
    'End Property

    Public Property IMPORTE() As Double
        Get
            Return Me._IMPORTE
        End Get
        Set(ByVal value As Double)
            Me._IMPORTE = value
        End Set
    End Property

    Public Property SALDO() As Double
        Get
            Return Me._SALDO
        End Get
        Set(ByVal value As Double)
            Me._SALDO = value
        End Set
    End Property

    Public Property FECHA_SERVIDOR() As Date
        Get
            Return Me._FECHA_SERVIDOR
        End Get
        Set(ByVal value As Date)
            Me._FECHA_SERVIDOR = value
        End Set
    End Property

    Public Property CODIGO_USUARIO_GRABO() As Integer
        Get
            Return Me._CODIGO_USUARIO_GRABO
        End Get
        Set(ByVal value As Integer)
            Me._CODIGO_USUARIO_GRABO = value
        End Set
    End Property

    Public Property NOMBRE_USUARIO_GRABO() As String
        Get
            Return Me._NOMBRE_USUARIO_GRABO
        End Get
        Set(ByVal value As String)
            Me._NOMBRE_USUARIO_GRABO = value
        End Set
    End Property

    Public Property ID_NOMIA_PERCEPCION() As Integer
        Get
            Return Me._ID_NOMIA_PERCEPCION
        End Get
        Set(ByVal value As Integer)
            Me._ID_NOMIA_PERCEPCION = value
        End Set
    End Property

    Public Property DESCUENTO_SEMANAL() As Double
        Get
            Return Me._DESCUENTO_SEMANAL
        End Get
        Set(ByVal value As Double)
            Me._DESCUENTO_SEMANAL = value
        End Set
    End Property

    Public Property CONCEPTO() As String
        Get
            Return Me._CONCEPTO
        End Get
        Set(ByVal value As String)
            Me._CONCEPTO = value
        End Set
    End Property
#End Region

#Region "Propiedades de campos ligados a la tabla"
    Public ReadOnly Property Existe() As Boolean
        Get
            Return Me._Existe
        End Get
    End Property

    Public ReadOnly Property CODIGO_X_TEMPORADA() As String
        Get
            Return Me._CODIGO_X_TEMPORADA
        End Get
    End Property
#End Region

#Region "Propiedad Nombre de Clase"
    Public ReadOnly Property Nombre_Clase() As String
        Get
            Return "Class_NominaDeduccionesGlobal"
        End Get
    End Property
#End Region

#End Region

#Region "Constructor y destructor"
    Public Sub New()
        Me._Nombre_Catalogo = "NOMINA_DEDUCCIONES_GLOBAL"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion

        Me._QuerySelect = "SELECT G.*,U.NOMBRE_USUARIO NOMBRE_USUARIO_GRABO,T.CODIGO_X_TEMPORADA " &
                            "FROM NOMINA_DEDUCCIONES_GLOBAL G " &
                            "INNER JOIN NOMINA_CAT_TRABAJADORES T ON(G.CODIGO_TRABAJADOR=T.CODIGO_TRABAJADOR) " &
                            "INNER JOIN SIS_USUARIOS U ON(G.CODIGO_USUARIO_GRABO=U.CODIGO_USUARIO) "

        Me.oDeduccionDetalle = New Class_NominaDeduccionesDetalle
    End Sub

    Public Sub New(ByVal iIdDeduccion As Integer)
        Me.New()
        Me._ID_DEDUCCION_GLOBAL = iIdDeduccion

        Try
            If Me.Consultar = True Then
                Me._Existe = True
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "New", ex)
        End Try
    End Sub

    Protected Overrides Sub Finalize()
        'Me._Conexion.Dispose()
        MyBase.Finalize()
    End Sub
#End Region

#Region "Métodos y procedimientos"
    Public Function Consultar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand(Me._QuerySelect & " WHERE G.ID_DEDUCCION_GLOBAL=" & Me._ID_DEDUCCION_GLOBAL.ToString, Me._Conexion)
        Dim dReader As SqlDataReader
        'Dim sqlParametro As SqlParameter
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()

                dReader = .ExecuteReader()
                If dReader.Read Then
                    'Me._ID_DEDUCCION_GLOBAL = CType(dReader("ID_DEDUCCION_GLOBAL"), Integer)
                    Me._CODIGO_TIPO_DEDUCCION = CType(dReader("CODIGO_TIPO_DEDUCCION"), Integer)
                    Me._ID_NOMINA_SEMANA = CType(dReader("ID_NOMINA_SEMANA"), Integer)
                    Me._CODIGO_TRABAJADOR = Trim("" & dReader("CODIGO_TRABAJADOR").ToString)
                    Me._CODIGO_X_TEMPORADA = Trim("" & dReader("CODIGO_X_TEMPORADA").ToString)
                    'Me._NUMERO_SEMANA = CType(dReader("NUMERO_SEMANA"), Integer)
                    Me._IMPORTE = CType(dReader("IMPORTE"), Double)
                    Me._SALDO = CType(dReader("SALDO"), Double)
                    Me._FECHA_SERVIDOR = CType(dReader("FECHA_SERVIDOR"), Date)
                    Me._CODIGO_USUARIO_GRABO = CType(dReader("CODIGO_USUARIO_GRABO"), Integer)
                    Me._NOMBRE_USUARIO_GRABO = CType(dReader("NOMBRE_USUARIO_GRABO"), String)
                    If txtLEN(dReader("ID_NOMINA_PERCEPCION").ToString) = True Then
                        Me._ID_NOMIA_PERCEPCION = CType(dReader("ID_NOMINA_PERCEPCION"), Integer)
                    End If
                    Me._DESCUENTO_SEMANAL = CType(dReader("DESCUENTO_SEMANAL"), Double)
                    Me._CONCEPTO = dReader("CONCEPTO").ToString

                    bResultado = True
                End If
                dReader.Close()
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "Consultar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
            End Try
        End With
        Return bResultado
    End Function

    Public Function Insertar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_NOMINA_DEDUCCIONES_GLOBAL_GRABA"

            sqlParametro = .Parameters.Add("@ID_DEDUCCION_GLOBAL", SqlDbType.Int) : sqlParametro.Direction = ParameterDirection.InputOutput : sqlParametro.Value = Me._ID_DEDUCCION_GLOBAL
            sqlParametro = .Parameters.Add("@ID_NOMINA_SEMANA", SqlDbType.SmallInt) : sqlParametro.Value = Me._ID_NOMINA_SEMANA
            sqlParametro = .Parameters.Add("@CODIGO_TIPO_DEDUCCION", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_TIPO_DEDUCCION
            sqlParametro = .Parameters.Add("@CODIGO_TRABAJADOR", SqlDbType.NVarChar, 10) : sqlParametro.Value = Me._CODIGO_TRABAJADOR
            sqlParametro = .Parameters.Add("@IMPORTE", SqlDbType.Decimal) : sqlParametro.Value = Me._IMPORTE
            sqlParametro = .Parameters.Add("@SALDO", SqlDbType.Decimal) : sqlParametro.Value = Me._SALDO
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO_GRABO", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Usuario
            sqlParametro = .Parameters.Add("@ID_NOMINA_PERCEPCION", SqlDbType.Int) : sqlParametro.Value = Me._ID_NOMIA_PERCEPCION
            sqlParametro = .Parameters.Add("@DESCUENTO_SEMANAL", SqlDbType.Decimal) : sqlParametro.Value = Me._DESCUENTO_SEMANAL
            sqlParametro = .Parameters.Add("@CONCEPTO", SqlDbType.NVarChar, 300) : sqlParametro.Value = Me._CONCEPTO
            sqlParametro = .Parameters.Add("@ACCION", SqlDbType.NVarChar, 20) : sqlParametro.Value = "INSERTAR"

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                Me._ID_DEDUCCION_GLOBAL = CInt(.Parameters("@ID_DEDUCCION_GLOBAL").Value)
                bResultado = True
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "Insertar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Function Actualizar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_NOMINA_DEDUCCIONES_GLOBAL_GRABA"

            sqlParametro = .Parameters.Add("@ID_DEDUCCION_GLOBAL", SqlDbType.Int) : sqlParametro.Direction = ParameterDirection.InputOutput : sqlParametro.Value = Me._ID_DEDUCCION_GLOBAL
            sqlParametro = .Parameters.Add("@CODIGO_TIPO_DEDUCCION", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_TIPO_DEDUCCION
            sqlParametro = .Parameters.Add("@ID_NOMINA_SEMANA", SqlDbType.SmallInt) : sqlParametro.Value = Me._ID_NOMINA_SEMANA
            sqlParametro = .Parameters.Add("@CODIGO_TRABAJADOR", SqlDbType.NVarChar, 10) : sqlParametro.Value = Me._CODIGO_TRABAJADOR
            sqlParametro = .Parameters.Add("@IMPORTE", SqlDbType.Decimal) : sqlParametro.Value = Me._IMPORTE
            sqlParametro = .Parameters.Add("@SALDO", SqlDbType.Decimal) : sqlParametro.Value = Me._SALDO
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO_GRABO", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Usuario
            sqlParametro = .Parameters.Add("@ID_NOMINA_PERCEPCION", SqlDbType.Int) : sqlParametro.Value = Me._ID_NOMIA_PERCEPCION
            sqlParametro = .Parameters.Add("@DESCUENTO_SEMANAL", SqlDbType.Decimal) : sqlParametro.Value = Me._DESCUENTO_SEMANAL
            sqlParametro = .Parameters.Add("@CONCEPTO", SqlDbType.NVarChar, 300) : sqlParametro.Value = Me._CONCEPTO
            sqlParametro = .Parameters.Add("@ACCION", SqlDbType.NVarChar, 20) : sqlParametro.Value = "ACTUALIZAR"

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                Me._ID_DEDUCCION_GLOBAL = CInt(.Parameters("@ID_DEDUCCION_GLOBAL").Value)
                bResultado = True
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "Actualizar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Function EliminaDeduccion() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_NOMINA_DEDUCCIONES_BORRA"

            sqlParametro = .Parameters.Add("@ID_DEDUCCION_GLOBAL", SqlDbType.Int) : sqlParametro.Value = Me._ID_DEDUCCION_GLOBAL

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()

                bResultado = True
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "EliminaDeduccion", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Function SaldarDeducciones() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_NOMINA_DEDUCCIONES_SALDAR_DESCUENTO"

            sqlParametro = .Parameters.Add("@ID_DEDUCCION_GLOBAL", SqlDbType.Int) : sqlParametro.Value = Me._ID_DEDUCCION_GLOBAL

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()

                bResultado = True
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "SaldarDeducciones", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Function ObtenerDetalle() As DataTable
        Dim dTabla As New DataTable("detalle"), da As SqlDataAdapter
        Dim sSQL As String
        sSQL = "SELECT ID_DEDUCCION_DETALLE,NUMERO_SEMANA,DESCUENTO,AMORTIZACION,ESTATUS_ABONADO,0 FROM NOMINA_DEDUCCIONES_DETALLE " & _
        "WHERE ID_DEDUCCION_GLOBAL= " & Me._ID_DEDUCCION_GLOBAL.ToString & _
        " ORDER BY NUMERO_SEMANA " 'ID_NOMINA_TEMPORADA,
        Try
            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dTabla)
            da.Dispose()
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "ObtenerDetalle", ex)
        End Try
        Return dTabla
    End Function

    Public Function ObtenerElementos() As DataTable
        Dim dTabla As New DataTable, da As SqlDataAdapter
        Dim sSQL As String
        sSQL = "SELECT G.CODIGO_X_TEMPORADA,G.NOMBRE_COMPLETO_APELLIDO, " &
                "MAX(D.NOMBRE_TIPO_DEDUCCION) NOMBRE_TIPO_DEDUCCION,MAX(FECHA_SERVIDOR) FECHA_SERVIDOR,SUM(IMPORTE) IMPORTE,SUM(SALDO) SALDO " &
                "FROM VW_NOMINA_DEDUCCIONES_GLOBAL_EXTENDIDA G " &
                "INNER JOIN NOMINA_CAT_TIPOS_DEDUCCIONES D ON (G.CODIGO_TIPO_DEDUCCION=D.CODIGO_TIPO_DEDUCCION) " &
                "WHERE G.SALDO>0 AND G.CODIGO_PLAZA=" & Usuario.Codigo_Plaza.ToString & " " &
                "GROUP BY CODIGO_X_TEMPORADA,NOMBRE_COMPLETO_APELLIDO " &
                "ORDER BY NOMBRE_COMPLETO_APELLIDO,NOMBRE_TIPO_DEDUCCION,IMPORTE,SALDO"
        'ID_NOMINA_TEMPORADA= " & Plaza.oSisPlazaNomina.NOMINA_ID_NOMINA_TEMPORADA_ACTIVA.ToString & " AND
        Try
            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dTabla)
            da.Dispose()
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "ObtenerElementos", ex)
        End Try
        Return dTabla
    End Function

    Public Sub NuevoRenglon()
        Me.oDeduccionDetalle = New Class_NominaDeduccionesDetalle
    End Sub
#End Region

End Class
