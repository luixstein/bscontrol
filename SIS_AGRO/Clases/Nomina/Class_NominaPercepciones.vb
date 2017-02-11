Option Strict On
Imports System.Data
Imports System.Data.SqlClient

Public Class Class_NominaPercepciones

#Region "Campos"

#Region "Campos de la tabla"
    Private _SEMANA As Integer
    Private _NUMERO_DIA As Integer
#End Region

#Region "Campos ligados a la tabla"
    Private _Existe As Boolean 'lectura
#End Region

#Region "Campos de sistema"
    Private _Nombre_Catalogo As String
    Private _Conexion As SqlConnection
    Private _QuerySelect As String
#End Region

#End Region

#Region "Propiedades"

#Region "Propiedades Campos de la tabla"
    Public Property NUMERO_DIA() As Integer
        Get
            Return Me._NUMERO_DIA
        End Get
        Set(ByVal value As Integer)
            Me._NUMERO_DIA = value
        End Set
    End Property

    Public Property SEMANA() As Integer
        Get
            Return Me._SEMANA
        End Get
        Set(ByVal value As Integer)
            Me._SEMANA = value
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

#Region "Propiedad Nombre de Clase"
    Public ReadOnly Property Nombre_Clase() As String
        Get
            Return "Class_NominaPercepciones"
        End Get
    End Property
#End Region

#End Region

#Region "Constructor y destructor"
    Public Sub New()
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
    End Sub

    Public Sub New(ByVal folio As Integer)
        'Me.New()
        'Me._ID_EMB_BULTOS_EMPACADOS = folio
        'Try
        '    If Me.Consultar = True Then
        '        Me._Existe = True
        '        'Else
        '        '   Throw New Exception("La cuenta bancaria no existe.")
        '    End If
        'Catch ex As Exception
        '    HandleError(Me.Nombre_Clase, "New", ex)
        'End Try
    End Sub

    Protected Overrides Sub Finalize()
        'Me._Conexion.Dispose()
        MyBase.Finalize()
    End Sub
#End Region

#Region "Métodos y procedimientos"
    Public Function Consultar() As Boolean
        'Dim cmd As New SqlCommand("SELECT DATEADD(DAY,((DATEDIFF(DAY,FECHA1,GETDATE())/7))*7,FECHA1) FECHA1_SEMANA_ACTUAL,DATEADD(DAY, " & _
        '                          "((DATEDIFF(DAY,FECHA1,GETDATE())/7))*7,FECHA1)+6 FECHA2_SEMANA_ACTUAL, " & _
        '                          "(DATEDIFF(DAY,FECHA1,GETDATE())/7)+1 NUMERO_SEMANA_ACTUAL " & _
        '                          "FROM NOMINA_TEMPORADAS WHERE ID_NOMINA_TEMPORADA=" & Plaza.NOMINA_ID_NOMINA_TEMPORADA_ACTIVA, Me._Conexion)
        'Dim dReader As SqlDataReader
        ''Dim sqlParametro As SqlParameter
        'With cmd
        '    .CommandTimeout = 0
        '    .CommandType = CommandType.Text
        '    Try
        '        Me._Conexion.Open()

        '        dReader = .ExecuteReader()
        '        If dReader.Read Then
        '            Me._SEMANA = CType(dReader("FECHA"), Date)
        '            Me._NUMERO_DIA = CType(dReader("CODIGO_EMPAQUE"), String)

        '            Consultar = True
        '        End If
        '        dReader.Close()
        '    Catch ex As Exception
        '        HandleError(Me.Nombre_Clase, "Consultar", ex)
        '    Finally
        '        Me._Conexion.Close()
        '        cmd.Dispose()
        '    End Try
        'End With
    End Function

    Public Function Insertar() As Boolean
        'Dim cmd As New SqlCommand
        'Dim sqlParametro As SqlParameter
        'With cmd
        '    .Connection = Me._Conexion
        '    .CommandTimeout = 0
        '    .CommandType = CommandType.StoredProcedure
        '    .CommandText = "MP_EMB_BULTOS_EMPACADOS_GRABA_ENTRADA"

        '    sqlParametro = .Parameters.Add("@ID_EMB_BULTOS_EMPACADOS", SqlDbType.Int) : sqlParametro.Direction = ParameterDirection.Input : sqlParametro.Value = Me._ID_EMB_BULTOS_EMPACADOS
        '    sqlParametro = .Parameters.Add("@FECHA", SqlDbType.DateTime) : sqlParametro.Value = Me._FECHA
        '    sqlParametro = .Parameters.Add("@CODIGO_EMPAQUE", SqlDbType.NVarChar, (8)) : sqlParametro.Value = Me._CODIGO_EMPAQUE
        '    sqlParametro = .Parameters.Add("@CODIGO_ARTICULO", SqlDbType.NVarChar, (16)) : sqlParametro.Value = Me._CODIGO_ARTICULO
        '    sqlParametro = .Parameters.Add("@CANTIDAD_ENTRADA", SqlDbType.Decimal) : sqlParametro.Value = Me._CANTIDAD_ENTRADA
        '    sqlParametro = .Parameters.Add("@CODIGO_USUARIO_GRABO", SqlDbType.Int) : sqlParametro.Value = Usuario.Codigo_Usuario
        '    'sqlParametro = .Parameters.Add("@FOLIO_PALET_ORIGEN", SqlDbType.NVarChar, (15)) : sqlParametro.Direction = ParameterDirection.Input : sqlParametro.Value = Me._FOLIO_PALET_ORIGEN
        '    'sqlParametro = .Parameters.Add("@FOLIO_PALET_ARMADO", SqlDbType.NVarChar, (15)) : sqlParametro.Direction = ParameterDirection.Input : sqlParametro.Value = Me._FOLIO_PALET_ARMADO
        '    'sqlParametro = .Parameters.Add("@ES_POR_ENTRADA_SOBRANTE_PRODUCCION", SqlDbType.Char, (1)) : sqlParametro.Value = Me._ES_POR_ENTRADA_SOBRANTE

        '    Try
        '        Me._Conexion.Open()
        '        .ExecuteNonQuery()
        '        Insertar = True
        '    Catch ex As Exception
        '        HandleError(Me.Nombre_Clase, "Insertar", ex)
        '    Finally
        '        Me._Conexion.Close()
        '        cmd.Dispose()
        '        sqlParametro = Nothing
        '    End Try
        'End With
    End Function

    Public Function Eliminar() As Boolean
        'Dim cmd As New SqlCommand
        'Dim sqlParametro As SqlParameter
        'With cmd
        '    .Connection = Me._Conexion
        '    .CommandTimeout = 0
        '    .CommandType = CommandType.StoredProcedure
        '    .CommandText = "MP_EMB_BULTOS_EMPACADOS_ELIMINA_ENTRADA"

        '    sqlParametro = .Parameters.Add("@ID_EMB_BULTOS_EMPACADOS", SqlDbType.SmallInt) : sqlParametro.Value = Me._ID_EMB_BULTOS_EMPACADOS
        '    Try
        '        Me._Conexion.Open()
        '        .ExecuteNonQuery()
        '        Eliminar = True
        '    Catch ex As Exception
        '        HandleError(Me.Nombre_Clase, "Eliminar", ex)
        '    Finally
        '        Me._Conexion.Close()
        '        cmd.Dispose()
        '        sqlParametro = Nothing
        '    End Try
        'End With
    End Function

    Public Function ObtenerSemana() As System.Data.DataTable
        Dim dt As New DataTable
        Try
            Dim da As New SqlDataAdapter("MP_NOMINA_PERCEPCIONES_OBTIENE_SEMANA_POR_DIA", Me._Conexion)
            da.SelectCommand.CommandType = CommandType.StoredProcedure

            With da.SelectCommand
                .Parameters.Add("@CODIGO_PLAZA", SqlDbType.SmallInt).Value = Plaza.CODIGO_PLAZA
                .Parameters.Add("@ID_NOMINA_TEMPORADA", SqlDbType.SmallInt).Value = Plaza.NOMINA_ID_NOMINA_TEMPORADA_ACTIVA
            End With

            da.Fill(dt)
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "ObtenerSemana", ex)
        Finally

        End Try
        ObtenerSemana = dt
    End Function

    Public Function ObtenerHojasDia() As System.Data.DataTable
        Dim dt As New DataTable
        Try
            Dim da As New SqlDataAdapter("MP_NOMINA_PERCEPCIONES_HOJAS_POR_DIA", Me._Conexion)
            da.SelectCommand.CommandType = CommandType.StoredProcedure

            With da.SelectCommand
                .Parameters.Add("@ID_NOMINA_TEMPORADA", SqlDbType.SmallInt).Value = Plaza.NOMINA_ID_NOMINA_TEMPORADA_ACTIVA
                .Parameters.Add("@NUMERO_DIA", SqlDbType.SmallInt).Value = Me._NUMERO_DIA
                .Parameters.Add("@NUMERO_SEMANA", SqlDbType.SmallInt).Value = Me._SEMANA
            End With

            da.Fill(dt)
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "ObtenerHojasDia", ex)
        Finally

        End Try
        ObtenerHojasDia = dt
    End Function

#End Region
End Class
