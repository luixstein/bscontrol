Imports System.Data.SqlClient

Public Class Class_CatMonedas

#Region "Campos"

#Region "Campos de la tabla"
    Private _Codigo_Moneda As Integer
    Private _Nombre As String
    Private _Abreviacion As String
    Private _TPCAM As Decimal
    Private _Estatus As String
    Private _Codigo_Formato_Letra As String
    Private _Codigo_Moneda_SAT As String

#End Region

#Region "Campos ligados a la tabla"

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
    Public Property Codigo_Moneda() As Integer
        Get
            Return Me._Codigo_Moneda
        End Get
        Set(ByVal Value As Integer)
            Me._Codigo_Moneda = Value
        End Set
    End Property

    Public Property Nombre() As String
        Get
            Return Me._Nombre
        End Get
        Set(ByVal Value As String)
            Me._Nombre = Value
        End Set
    End Property
    Public Property Abreviacion() As String
        Get
            Return Me._Abreviacion
        End Get
        Set(ByVal Value As String)
            Me._Abreviacion = Value
        End Set
    End Property
    Public Property TPCAM() As Decimal
        Get
            Return Me._TPCAM
        End Get
        Set(ByVal Value As Decimal)
            Me._TPCAM = Value
        End Set
    End Property
    Public Property Estatus() As String
        Get
            Return Me._Estatus
        End Get
        Set(ByVal Value As String)
            Me._Estatus = Value
        End Set
    End Property
    Public Property Codigo_Formato_Letra() As String
        Get
            Return Me._Codigo_Formato_Letra
        End Get
        Set(ByVal Value As String)
            Me._Codigo_Formato_Letra = Value
        End Set
    End Property
    Public Property Codigo_Moneda_SAT() As String
        Get
            Return Me._Codigo_Moneda_SAT
        End Get
        Set(ByVal Value As String)
            Me._Codigo_Moneda_SAT = Value
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
    Public Sub New()
        Me._Nombre_Catalogo = "CATALOGO_MONEDAS"
        Me._Nombre_Reporte = ""
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "SELECT CODIGO_MONEDA,NOMBRE,ABREVIACION,TPCAM,ESTATUS,CODIGO_FORMATO_LETRA,CODIGO_MONEDA_SAT FROM CATALOGO_MONEDAS"
        Me._QueryOrder = " Order by CODIGO_MONEDA"
    End Sub                                                         'Inicializa al objeto.

    Protected Overrides Sub Finalize()
        'Me._Conexion.Dispose()
        MyBase.Finalize()
    End Sub
#End Region

#Region "Opciones"

#End Region

#Region "Métodos y procedimientos"
    Public Function ObtenerElementos() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter("SELECT CODIGO_MONEDA,NOMBRE,ABREVIACION,TPCAM,ESTATUS,CODIGO_FORMATO_LETRA,CODIGO_MONEDA_SAT from CATALOGO_MONEDAS ORDER BY CODIGO_MONEDA", Me._Conexion)
        Try
            da.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementos", ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function
#End Region

End Class
