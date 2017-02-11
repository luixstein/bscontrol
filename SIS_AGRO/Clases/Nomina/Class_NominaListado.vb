Option Strict On
Imports System.Data
Imports System.Data.SqlClient

Public Class Class_NominaListado

#Region "Campos"

#Region "Campos de la tabla"
    'Private _ID_NOMINA_LISTADO As Integer
    Private _CODIGO_TRABAJADOR As String
    Private _TURNO As String
    Private _TIPO As String
    Private _CODIGO_VEHICULO As String
    Private _FECHA As Date
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
    Dim _ID_NOMINA_LISTADO As Integer
    'Public Property ID_NOMINA_LISTADO() As Integer
    '    Get
    '        Return Me._ID_NOMINA_LISTADO
    '    End Get
    '    Set(ByVal Value As Integer)
    '        Me._ID_NOMINA_LISTADO = Value
    '    End Set
    'End Property

    Public Property CODIGO_TRABAJADOR() As String
        Get
            Return Me._CODIGO_TRABAJADOR
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_TRABAJADOR = Value
        End Set
    End Property

    Public Property TURNO() As String
        Get
            Return Me._TURNO
        End Get
        Set(ByVal Value As String)
            Me._TURNO = Value
        End Set
    End Property

    Public Property TIPO() As String
        Get
            Return Me._TIPO
        End Get
        Set(ByVal Value As String)
            Me._TIPO = Value
        End Set
    End Property

    Public Property CODIGO_VEHICULO() As String
        Get
            Return Me._CODIGO_VEHICULO
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_VEHICULO = Value
        End Set
    End Property

    Public Property FECHA() As Date
        Get
            Return Me._FECHA
        End Get
        Set(ByVal Value As Date)
            Me._FECHA = Value
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
            Me._Nombre_Clase = "Class_NominaListado"
            Return Me._Nombre_Clase
        End Get
    End Property
#End Region
#End Region

#Region "Constructor y destructor"
    Public Sub New()
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "SELECT ID_NOMINA_LISTADO,CODIGO_TRABAJADOR,TURNO,TIPO,CODIGO_VEHICULO,FECHA FROM NOMINA_LISTADO"
        Me._QueryOrder = " ORDER BY ID_NOMINA_LISTADO "

    End Sub

    'Public Sub New(ByVal iIdListado As Integer)
    '    Me.New()
    '    Me._ID_NOMINA_LISTADO = iIdListado
    '    Try
    '        If Me.Consultar = True Then
    '            Me._Existe = True
    '            'Else
    '            '   Throw New Exception("La cuenta bancaria no existe.")
    '        End If
    '    Catch ex As Exception
    '        HandleError(Me.Nombre_Clase, "New", ex)
    '    End Try
    'End Sub

    Protected Overrides Sub Finalize()
        'Me._Conexion.Dispose()
        MyBase.Finalize()
    End Sub
#End Region

#Region "Métodos y procedimientos"

    Public Function Insertar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_NOMINA_LISTADO_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_TRABAJADOR", SqlDbType.NVarChar, 10) : sqlParametro.Value = Me._CODIGO_TRABAJADOR
            sqlParametro = .Parameters.Add("@TURNO", SqlDbType.NVarChar, 10) : sqlParametro.Value = "" & Me._TURNO
            sqlParametro = .Parameters.Add("@TIPO", SqlDbType.NVarChar, 10) : sqlParametro.Value = "" & Me._TIPO
            sqlParametro = .Parameters.Add("@CODIGO_VEHICULO", SqlDbType.NVarChar, 10) : sqlParametro.Value = "" & CInt(Me._CODIGO_VEHICULO)
            sqlParametro = .Parameters.Add("@FECHA", SqlDbType.DateTime) : sqlParametro.Value = Me._FECHA

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
                'Me._ID_NOMINA_LISTADO = CInt(.Parameters("@ID_NOMINA_HOJA").Value)
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

    Public Function Consultar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand(Me._QuerySelect & " WHERE H.ID_NOMINA_HOJA ", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()
                If dReader.Read Then
                    'Me._ID_NOMINA_LISTADO = CInt(dReader("ID_NOMINA_LISTADO"))
                    Me._CODIGO_TRABAJADOR = "" & dReader("CODIGO_TRABAJADOR").ToString
                    Me._TURNO = "" & dReader("TURNO").ToString
                    Me._TIPO = "" & dReader("TIPO").ToString
                    Me._CODIGO_VEHICULO = "" & dReader("CODIGO_VEHICULO").ToString
                    Me._FECHA = CDate(dReader("FECHA"))

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

    Public Function ObtenerElementos(ByVal iIdDida As Integer) As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dsNominaHojas As New SqlDataAdapter("SELECT ISNULL(H.ID_NOMINA_HOJA,1) ID_NOMINA_HOJA, ISNULL(H.NUMERO_HOJA,1) NUMERO_HOJA FROM NOMINA_HOJAS H WHERE H.ID_NOMINA_DIA=" & iIdDida.ToString & Me._QueryOrder, Me._Conexion)
        Try
            dsNominaHojas.Fill(dTable)
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "ObtenerElementos", ex)
        Finally
            dsNominaHojas.Dispose()
        End Try
        Return dTable
    End Function

#End Region

End Class
