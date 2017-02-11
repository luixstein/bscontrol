Option Strict On
Imports System.Data
Imports System.Data.SqlClient

Public Class Class_NominaHojaPercepciones

#Region "Campos"

#Region "Campos de la tabla"
    Private _ID_NOMINA_PERCEPCION As Integer
    Private _ID_NOMINA_HOJA As Integer
    Private _CODIGO_TRABAJADOR As String
    Private _PERCEPCION As Double
    Private _CODIGO_PERCEPCION As Integer
    Private _CAJAS_CORTADAS As Double
#End Region

#Region "Campos de sistema"
    Private _Nombre_Catalogo As String
    Private _Conexion As SqlConnection
    Private _QuerySelect As String
#End Region

#End Region

#Region "Propiedades"

#Region "Propiedades Campos de la tabla"
    Public Property ID_NOMINA_PERCEPCION() As Integer
        Get
            Return Me._ID_NOMINA_PERCEPCION
        End Get
        Set(ByVal value As Integer)
            Me._ID_NOMINA_PERCEPCION = value
        End Set
    End Property

    Public Property ID_NOMINA_HOJA() As Integer
        Get
            Return Me._ID_NOMINA_HOJA
        End Get
        Set(ByVal value As Integer)
            Me._ID_NOMINA_HOJA = value
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

    Public Property PERCEPCION() As Double
        Get
            Return Me._PERCEPCION
        End Get
        Set(ByVal value As Double)
            Me._PERCEPCION = value
        End Set
    End Property

    Public Property CODIGO_PERCEPCION() As Integer
        Get
            Return Me._CODIGO_PERCEPCION
        End Get
        Set(ByVal value As Integer)
            Me._CODIGO_PERCEPCION = value
        End Set
    End Property

    Public Property CAJAS_CORTADAS() As Double
        Get
            Return Me._CAJAS_CORTADAS
        End Get
        Set(ByVal value As Double)
            Me._CAJAS_CORTADAS = value
        End Set
    End Property
#End Region

#Region "Propiedad Nombre de Clase"
    Public ReadOnly Property Nombre_Clase() As String
        Get
            Return "Class_NominaHojaPercepciones"
        End Get
    End Property
#End Region

#End Region

#Region "Constructor y destructor"
    Public Sub New()
        Me._Nombre_Catalogo = "NOMINA_HOJAS_PERCEPCIONES"
        Me._Conexion = New SqlConnection(Empresa_Sistema.conexion)
        Me._QuerySelect = "SELECT * FROM NOMINA_HOJAS_PERCEPCIONES"
    End Sub

    Protected Overrides Sub Finalize()
        'Me._Conexion.Dispose()
        MyBase.Finalize()
    End Sub
#End Region

#Region "Métodos y procedimientos"

    Public Function GrabaDetallePercepcion(ByVal sAccion As String) As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_NOMINA_PERCEPCIONES_GRABA_PERCEPCION"

            sqlParametro = .Parameters.Add("@ID_NOMINA_PERCEPCION", SqlDbType.Int) : sqlParametro.Direction = ParameterDirection.InputOutput : sqlParametro.Value = Me._ID_NOMINA_PERCEPCION
            sqlParametro = .Parameters.Add("@ID_NOMINA_HOJA", SqlDbType.Int) : sqlParametro.Value = Me._ID_NOMINA_HOJA
            sqlParametro = .Parameters.Add("@CODIGO_TRABAJADOR", SqlDbType.NVarChar, 10) : sqlParametro.Value = Me._CODIGO_TRABAJADOR.ToString.ToUpper
            sqlParametro = .Parameters.Add("@PERCEPCION", SqlDbType.Decimal) : sqlParametro.Value = Me._PERCEPCION
            sqlParametro = .Parameters.Add("@CODIGO_PERCEPCION", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_PERCEPCION
            sqlParametro = .Parameters.Add("@ACCION", SqlDbType.NVarChar, 10) : sqlParametro.Value = sAccion.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CAJAS_CORTADAS", SqlDbType.Decimal) : sqlParametro.Value = Me._CAJAS_CORTADAS

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                Me._ID_NOMINA_PERCEPCION = CInt(.Parameters("@ID_NOMINA_PERCEPCION").Value)
                bResultado = True
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "GrabaDetallePercepcion", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With

        Return bResultado
    End Function

    Public Function EliminaDetallePercepcion() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_NOMINA_HOJA_PERCEPCION_ELIMINA"

            sqlParametro = .Parameters.Add("@ID_NOMINA_PERCEPCION", SqlDbType.Int) : sqlParametro.Value = Me._ID_NOMINA_PERCEPCION

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()

                bResultado = True
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "EliminaDetallePercepcion", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With

        Return bResultado
    End Function

#End Region

End Class
