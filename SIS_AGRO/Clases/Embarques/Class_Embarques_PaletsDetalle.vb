Option Strict On
Imports System.Data
Imports System.Data.SqlClient

Public Class Class_Embarques_PaletsDetalle

#Region "Campos"

#Region "Campos de la tabla"
    Private _ID_EMB_PALETS_DETALLE As Integer
    Private _FOLIO_PALET As String
    Private _CODIGO_ARTICULO As String
    Private _CANTIDAD_BULTOS_DETALLE As Integer
    Private _PESO_UNIDAD_BULTO As Double
    Private _PESO_BULTOS_DETALLE As Double
    Private _PRECIO_UNIDAD_BULTO As Double
    Private _IMPORTE_BULTOS_DETALLE As Double

#End Region

#Region "Campos de sistema"
    Private _Nombre_Catalogo As String
    Private _Conexion As SqlConnection
    Private _QuerySelect As String
#End Region

#End Region

#Region "Propiedades"

#Region "Propiedades Campos de la tabla"
    Public ReadOnly Property ID_EMB_PALETS_DETALLE() As Integer
        Get
            Return Me._ID_EMB_PALETS_DETALLE
        End Get
    End Property

    Public Property FOLIO_PALET() As String
        Get
            Return Me._FOLIO_PALET
        End Get
        Set(ByVal value As String)
            Me._FOLIO_PALET = value
        End Set
    End Property

    Public Property CODIGO_ARTICULO() As String
        Get
            Return Me._CODIGO_ARTICULO
        End Get
        Set(ByVal value As String)
            Me._CODIGO_ARTICULO = value
        End Set
    End Property

    Public Property PESO_UNIDAD_BULTO() As Double
        Get
            Return Me._PESO_UNIDAD_BULTO
        End Get
        Set(ByVal value As Double)
            Me._PESO_UNIDAD_BULTO = value
        End Set
    End Property

    Public Property PESO_BULTOS_DETALLE() As Double
        Get
            Return Me._PESO_BULTOS_DETALLE
        End Get
        Set(ByVal value As Double)
            Me._PESO_BULTOS_DETALLE = value
        End Set
    End Property

    Public Property CANTIDAD_BULTOS_DETALLE() As Integer
        Get
            Return Me._CANTIDAD_BULTOS_DETALLE
        End Get
        Set(ByVal value As Integer)
            Me._CANTIDAD_BULTOS_DETALLE = value
        End Set
    End Property

    Public Property PRECIO_UNIDAD_BULTO() As Double
        Get
            Return Me._PRECIO_UNIDAD_BULTO
        End Get
        Set(ByVal value As Double)
            Me._PRECIO_UNIDAD_BULTO = value
        End Set
    End Property

    Public Property IMPORTE_BULTOS_DETALLE() As Double
        Get
            Return Me._IMPORTE_BULTOS_DETALLE
        End Get
        Set(ByVal value As Double)
            Me._IMPORTE_BULTOS_DETALLE = value
        End Set
    End Property

#End Region

#Region "Propiedad Nombre de Clase"
    Public ReadOnly Property Nombre_Clase() As String
        Get
            Return "Class_Embarques_PaletsDetalle"
        End Get
    End Property
#End Region

#End Region

#Region "Constructor y destructor"
    Public Sub New()
        Me._Nombre_Catalogo = "EMB_PALETS_DETALLE"
        Me._Conexion = New SqlConnection(Empresa_Sistema.conexion)
        Me._QuerySelect = "SELECT * FROM EMB_PALETS_DETALLE"
    End Sub

    Protected Overrides Sub Finalize()
        'Me._Conexion.Dispose()
        MyBase.Finalize()
    End Sub
#End Region

#Region "Métodos y procedimientos"
    Public Function GrabaDetallePalet() As Boolean
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_EMB_PALETS_DETALLE_GRABA"
            sqlParametro = .Parameters.Add("@FOLIO_PALET", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_PALET
            sqlParametro = .Parameters.Add("@CODIGO_ARTICULO", SqlDbType.NVarChar, 16) : sqlParametro.Value = Me._CODIGO_ARTICULO
            sqlParametro = .Parameters.Add("@CANTIDAD_BULTOS_DETALLE", SqlDbType.Int) : sqlParametro.Value = Me._CANTIDAD_BULTOS_DETALLE
            sqlParametro = .Parameters.Add("@PESO_UNIDAD_BULTO", SqlDbType.Decimal) : sqlParametro.Value = Me._PESO_UNIDAD_BULTO
            sqlParametro = .Parameters.Add("@PESO_BULTOS_DETALLE", SqlDbType.Decimal) : sqlParametro.Value = Me._PESO_BULTOS_DETALLE
            sqlParametro = .Parameters.Add("@PRECIO_UNIDAD_BULTO", SqlDbType.Decimal) : sqlParametro.Value = Me._PRECIO_UNIDAD_BULTO
            sqlParametro = .Parameters.Add("@IMPORTE_BULTOS_DETALLE", SqlDbType.Decimal) : sqlParametro.Value = Me._IMPORTE_BULTOS_DETALLE

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                GrabaDetallePalet = True
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "GrabaDetallePalet", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
    End Function

#End Region

End Class
