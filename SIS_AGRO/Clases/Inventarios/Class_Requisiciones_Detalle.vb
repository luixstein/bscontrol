Option Strict On

Imports System.Data.SqlClient

Public Class Class_Requisiciones_Detalle

#Region "Campos"

#Region "Campos de la tabla"
    Private _FOLIO_REQUISICION As String
    Private _CODIGO_ARTICULO As String
    Private _CANTIDAD As Double
    Private _DISPONIBLE As Double
    Private _CANTIDAD_ANULADA As Double
#End Region

#Region "Campos ligados a la tabla"

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

    Public Property FOLIO_REQUISICION() As String
        Get
            Return Me._FOLIO_REQUISICION
        End Get
        Set(ByVal Value As String)
            Me._FOLIO_REQUISICION = Value
        End Set
    End Property

    Public Property CODIGO_ARTICULO() As String
        Get
            Return Me._CODIGO_ARTICULO
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_ARTICULO = Value
        End Set
    End Property

    Public Property CANTIDAD() As Double
        Get
            Return Me._CANTIDAD
        End Get
        Set(ByVal Value As Double)
            Me._CANTIDAD = Value
        End Set
    End Property

    Public Property DISPONIBLE() As Double
        Get
            Return Me._DISPONIBLE
        End Get
        Set(value As Double)
            Me._DISPONIBLE = value
        End Set
    End Property

    Public Property CANTIDAD_ANULADA() As Double
        Get
            Return Me._CANTIDAD_ANULADA
        End Get
        Set(ByVal Value As Double)
            Me._CANTIDAD_ANULADA = Value
        End Set
    End Property

#End Region

#Region "Propiedades de campos ligados a la tabla"

#End Region

#Region "Propiedades públicos"

#End Region

#Region "Propiedades de campos privados"

#End Region

#Region "Propiedades de campos de sistema"
    Public ReadOnly Property Nombre_Clase() As String
        Get
            Return "Class_Inventarios_Detalle"
        End Get
    End Property
#End Region

#End Region

#Region "Constructor y destructor"
    Public Sub New()
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "Select * from REQUISICIONES_GLOBAL where "
        Me._QueryOrder = " Order by FOLIO_REQUISICION"
    End Sub                                                         'Inicializa al objeto.

    Public Sub New(ByVal sFolioRequisicion As String)
        Me.New()
        Try
            Me.FOLIO_REQUISICION = sFolioRequisicion
            'If Me.Consultar = False Then
            '    Throw New Exception("El folio de movimiento de inventarios no existe.")
            'End If
        Catch ex As Exception
            HandleError(Me._Nombre_Clase, "New", ex)
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
    Public Function GrabaRenglon() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_REQUISICIONES_DETALLE_GRABA"

            sqlParametro = .Parameters.Add("@FOLIO_REQUISICION", SqlDbType.NVarChar, 15) : sqlParametro.Value = "" & Me._FOLIO_REQUISICION.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_ARTICULO", SqlDbType.NVarChar, 16) : sqlParametro.Value = "" & Me._CODIGO_ARTICULO.ToUpper
            sqlParametro = .Parameters.Add("@CANTIDAD", SqlDbType.Money) : sqlParametro.Value = Me._CANTIDAD

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me._Nombre_Clase, "GrabaRenglon", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Function AnularRenglon() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_REQUISICIONES_ANULA_DETALLE"

            sqlParametro = .Parameters.Add("@FOLIO_REQUISICION", SqlDbType.NVarChar, 15) : sqlParametro.Value = "" & Me._FOLIO_REQUISICION.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_ARTICULO", SqlDbType.NVarChar, 16) : sqlParametro.Value = "" & Me._CODIGO_ARTICULO.ToUpper
            sqlParametro = .Parameters.Add("@CANTIDAD_ANULADA", SqlDbType.Decimal) : sqlParametro.Value = Me._CANTIDAD_ANULADA

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me._Nombre_Clase, "AnularRenglon", ex)
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


