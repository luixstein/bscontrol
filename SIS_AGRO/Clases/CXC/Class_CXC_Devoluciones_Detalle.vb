Option Strict On

Imports System.Data.SqlClient

Public Class Class_CXC_Devoluciones_Detalle

#Region "Campos"

#Region "Campos de la tabla"
    Private _ID_CXC_DEVOLUCION_DETALLE As Integer
    Private _FOLIO_DEVOLUCION As String
    Private _CODIGO_ARTICULO As String
    Private _ID_VENTA_DETALLE As Integer
    Private _CANTIDAD As Decimal
    Private _PRECIO As Decimal
    Private _COSTO As Decimal
    Private _IMPUESTO_PORCENTAJE As Decimal
    Private _IMPUESTO_IMPORTE As Decimal
    Private _IMPORTE As Decimal
    Private _IEPS_PORCENTAJE As Decimal
    Private _IEPS_UNITARIO As Decimal
    Private _IEPS_IMPORTE As Decimal
    Private _BASE_IEPS As Decimal
    Private _BASE_IVA As Decimal
    Private _PRECIO_TOTAL As Decimal
    Private _LISTA_SERIES As String
    Private _ID_SIS_CAT_IMPUESTOS As String
    Private _GRADO_TOXICIDAD As Integer
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
#End Region

#End Region

#Region "Propiedades"

#Region "Propiedades Campos de la tabla"

    Public Property ID_CXC_DEVOLUCION_DETALLE() As Integer
        Get
            Return Me._ID_CXC_DEVOLUCION_DETALLE
        End Get
        Set(ByVal Value As Integer)
            Me._ID_CXC_DEVOLUCION_DETALLE = Value
        End Set
    End Property

    Public Property FOLIO_DEVOLUCION() As String
        Get
            Return Me._FOLIO_DEVOLUCION
        End Get
        Set(ByVal Value As String)
            Me._FOLIO_DEVOLUCION = Value
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

    Public Property ID_VENTA_DETALLE() As Integer
        Get
            Return Me._ID_VENTA_DETALLE
        End Get
        Set(ByVal Value As Integer)
            Me._ID_VENTA_DETALLE = Value
        End Set
    End Property

    Public Property CANTIDAD() As Decimal
        Get
            Return Me._CANTIDAD
        End Get
        Set(ByVal Value As Decimal)
            Me._CANTIDAD = Value
        End Set
    End Property

    Public Property PRECIO() As Decimal
        Get
            Return Me._PRECIO
        End Get
        Set(ByVal Value As Decimal)
            Me._PRECIO = Value
        End Set
    End Property

    Public Property COSTO() As Decimal
        Get
            Return Me._COSTO
        End Get
        Set(ByVal Value As Decimal)
            Me._COSTO = Value
        End Set
    End Property

    Public Property IMPUESTO_PORCENTAJE() As Decimal
        Get
            Return Me._IMPUESTO_PORCENTAJE
        End Get
        Set(ByVal Value As Decimal)
            Me._IMPUESTO_PORCENTAJE = Value
        End Set
    End Property

    Public Property IMPUESTO_IMPORTE() As Decimal
        Get
            Return Me._IMPUESTO_IMPORTE
        End Get
        Set(ByVal Value As Decimal)
            Me._IMPUESTO_IMPORTE = Value
        End Set
    End Property

    Public Property IMPORTE() As Decimal
        Get
            Return Me._IMPORTE
        End Get
        Set(ByVal Value As Decimal)
            Me._IMPORTE = Value
        End Set
    End Property

    Public Property IEPS_PORCENTAJE() As Decimal
        Get
            Return Me._IEPS_PORCENTAJE
        End Get
        Set(ByVal Value As Decimal)
            Me._IEPS_PORCENTAJE = Value
        End Set
    End Property

    Public Property IEPS_UNITARIO() As Decimal
        Get
            Return Me._IEPS_UNITARIO
        End Get
        Set(ByVal Value As Decimal)
            Me._IEPS_UNITARIO = Value
        End Set
    End Property

    Public Property IEPS_IMPORTE() As Decimal
        Get
            Return Me._IEPS_IMPORTE
        End Get
        Set(ByVal Value As Decimal)
            Me._IEPS_IMPORTE = Value
        End Set
    End Property

    Public Property BASE_IEPS() As Decimal
        Get
            Return Me._BASE_IEPS
        End Get
        Set(ByVal Value As Decimal)
            Me._BASE_IEPS = Value
        End Set
    End Property

    Public Property BASE_IVA() As Decimal
        Get
            Return Me._BASE_IVA
        End Get
        Set(ByVal Value As Decimal)
            Me._BASE_IVA = Value
        End Set
    End Property

    Public Property PRECIO_TOTAL() As Decimal
        Get
            Return Me._PRECIO_TOTAL
        End Get
        Set(ByVal Value As Decimal)
            Me._PRECIO_TOTAL = Value
        End Set
    End Property

    Public Property LISTA_SERIES() As String
        Get
            Return Me._LISTA_SERIES
        End Get
        Set(ByVal Value As String)
            Me._LISTA_SERIES = Value
        End Set
    End Property

    Public Property ID_SIS_CAT_IMPUESTOS() As String
        Get
            Return Me._ID_SIS_CAT_IMPUESTOS
        End Get
        Set(ByVal Value As String)
            Me._ID_SIS_CAT_IMPUESTOS = Value
        End Set
    End Property

    Public Property GRADO_TOXICIDAD() As Integer
        Get
            Return Me._GRADO_TOXICIDAD
        End Get
        Set(ByVal Value As Integer)
            Me._GRADO_TOXICIDAD = Value
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
            Return "Class_CXC_Devoluciones_Detalle"
        End Get
    End Property
#End Region

#End Region

#Region "Constructor y destructor"
    Public Sub New()
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
    End Sub

    Protected Overrides Sub Finalize()
        'Me._Conexion.Dispose()
        MyBase.Finalize()
    End Sub
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
            .CommandText = "MP_CXC_DEVOLUCIONES_GRABA_DETALLE"

            sqlParametro = .Parameters.Add("@FOLIO_DEVOLUCION", SqlDbType.NVarChar, 15) : sqlParametro.Value = "" & Me._FOLIO_DEVOLUCION
            sqlParametro = .Parameters.Add("@CODIGO_ARTICULO", SqlDbType.NVarChar, 16) : sqlParametro.Value = "" & Me._CODIGO_ARTICULO
            sqlParametro = .Parameters.Add("@ID_VENTA_DETALLE", SqlDbType.Int) : sqlParametro.Value = Me._ID_VENTA_DETALLE
            sqlParametro = .Parameters.Add("@CANTIDAD", SqlDbType.Decimal) : sqlParametro.Value = "" & Me._CANTIDAD
            sqlParametro = .Parameters.Add("@PRECIO", SqlDbType.Decimal) : sqlParametro.Value = Me._PRECIO
            sqlParametro = .Parameters.Add("@IMPUESTO_PORCENTAJE", SqlDbType.Decimal) : sqlParametro.Value = Me._IMPUESTO_PORCENTAJE
            sqlParametro = .Parameters.Add("@IMPUESTO_IMPORTE", SqlDbType.Decimal) : sqlParametro.Value = Me._IMPUESTO_IMPORTE
            sqlParametro = .Parameters.Add("@IMPORTE", SqlDbType.Decimal) : sqlParametro.Value = Me._IMPORTE
            sqlParametro = .Parameters.Add("@IEPS_PORCENTAJE", SqlDbType.Decimal) : sqlParametro.Value = Me._IEPS_PORCENTAJE
            sqlParametro = .Parameters.Add("@IEPS_UNITARIO", SqlDbType.Decimal) : sqlParametro.Value = Me._IEPS_UNITARIO
            sqlParametro = .Parameters.Add("@IEPS_IMPORTE", SqlDbType.Decimal) : sqlParametro.Value = Me._IEPS_IMPORTE
            sqlParametro = .Parameters.Add("@BASE_IEPS", SqlDbType.Decimal) : sqlParametro.Value = Me._BASE_IEPS
            sqlParametro = .Parameters.Add("@BASE_IVA", SqlDbType.Decimal) : sqlParametro.Value = Me._BASE_IVA
            sqlParametro = .Parameters.Add("@PRECIO_TOTAL", SqlDbType.Decimal) : sqlParametro.Value = Me._PRECIO_TOTAL
            sqlParametro = .Parameters.Add("@LISTA_SERIES", SqlDbType.NVarChar, -1) : sqlParametro.Value = Me._LISTA_SERIES
            sqlParametro = .Parameters.Add("@GRADO_TOXICIDAD", SqlDbType.SmallInt) : sqlParametro.Value = Me._GRADO_TOXICIDAD
            sqlParametro = .Parameters.Add("@ID_SIS_CAT_IMPUESTOS", SqlDbType.NVarChar, 2) : sqlParametro.Value = Me._ID_SIS_CAT_IMPUESTOS

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

#End Region

End Class