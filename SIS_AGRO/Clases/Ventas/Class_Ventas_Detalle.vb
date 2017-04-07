Option Strict On
Imports System.Data
Imports System.Data.SqlClient

Public Class Class_Ventas_Detalle

#Region "Campos"

#Region "Campos de la tabla"
    Private _ID_VENTA_DETALLE As Integer
    Private _FOLIO_VENTA As String
    Private _CODIGO_ARTICULO As String
    Private _DESCRIPCION As String
    Private _CANTIDAD As Double
    Private _DISPONIBLE As Double
    Private _PRECIO As Double
    Private _UNIDAD_VENTA As String
    Private _IMPUESTO_PORCENTAJE As Double
    Private _IMPUESTO_IMPORTE As Double
    Private _IMPORTE As Double
    Private _ID_ORIGEN As Integer
    Private _CUENTA_CONTABLE As String
    Private _COMENTARIO As String
    Private _COSTO As Double
    Private _PRECIO_NUEVO As Double
    Private _CANTIDAD_KILOS As Double
    Private _PRECIO_KILOS As Double
    Private _IMPORTE_KILOS As Double
    Private _ES_PRODUCTO_KILOS As String
    Private _CODIGO_CENTRO_COSTO As String
    Private _LISTA_SERIES As String
    Private _PRECIO_USD As Double
    Private _IMPORTE_USD As Double

    Private _IEPS_PORCENTAJE As Double
    Private _IEPS_UNITARIO As Double
    Private _IEPS_IMPORTE As Double
    Private _BASE_IEPS As Double
    Private _BASE_IVA As Double
    Private _PRECIO_TOTAL As Double
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

    Public Property ID_VENTA_DETALLE() As Integer
        Get
            Return Me._ID_VENTA_DETALLE
        End Get
        Set(ByVal Value As Integer)
            Me._ID_VENTA_DETALLE = Value
        End Set
    End Property

    Public Property FOLIO_VENTA() As String
        Get
            Return Me._FOLIO_VENTA
        End Get
        Set(ByVal Value As String)
            Me._FOLIO_VENTA = Value
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

    Public Property DESCRIPCION() As String
        Get
            Return Me._DESCRIPCION
        End Get
        Set(ByVal Value As String)
            Me._DESCRIPCION = Value
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
        Set(ByVal Value As Double)
            Me._DISPONIBLE = Value
        End Set
    End Property

    Public Property PRECIO() As Double
        Get
            Return Me._PRECIO
        End Get
        Set(ByVal Value As Double)
            Me._PRECIO = Value
        End Set
    End Property

    Public Property COSTO() As Double
        Get
            Return Me._COSTO
        End Get
        Set(ByVal Value As Double)
            Me._COSTO = Value
        End Set
    End Property

    Public Property UNIDAD_VENTA() As String
        Get
            Return Me._UNIDAD_VENTA
        End Get
        Set(ByVal Value As String)
            Me._UNIDAD_VENTA = Value
        End Set
    End Property

    Public Property IMPUESTO_PORCENTAJE() As Double
        Get
            Return Me._IMPUESTO_PORCENTAJE
        End Get
        Set(ByVal Value As Double)
            Me._IMPUESTO_PORCENTAJE = Value
        End Set
    End Property

    Public Property IMPUESTO_IMPORTE() As Double
        Get
            Return Me._IMPUESTO_IMPORTE
        End Get
        Set(ByVal Value As Double)
            Me._IMPUESTO_IMPORTE = Value
        End Set
    End Property

    Public Property IMPORTE() As Double
        Get
            Return Me._IMPORTE
        End Get
        Set(ByVal Value As Double)
            Me._IMPORTE = Value
        End Set
    End Property

    Public Property ID_ORIGEN() As Integer
        Get
            Return Me._ID_ORIGEN
        End Get
        Set(ByVal Value As Integer)
            Me._ID_ORIGEN = Value
        End Set
    End Property

    Public Property CUENTA_CONTABLE() As String
        Get
            Return Me._CUENTA_CONTABLE
        End Get
        Set(ByVal Value As String)
            Me._CUENTA_CONTABLE = Value
        End Set
    End Property

    Public Property COMENTARIO() As String
        Get
            Return Me._COMENTARIO
        End Get
        Set(ByVal Value As String)
            Me._COMENTARIO = Value
        End Set
    End Property

    Public Property PRECIO_NUEVO() As Double
        Get
            Return Me._PRECIO_NUEVO
        End Get
        Set(ByVal Value As Double)
            Me._PRECIO_NUEVO = Value
        End Set
    End Property

    Public Property CANTIDAD_KILOS() As Double
        Get
            Return Me._CANTIDAD_KILOS
        End Get
        Set(ByVal Value As Double)
            Me._CANTIDAD_KILOS = Value
        End Set
    End Property

    Public Property PRECIO_KILOS() As Double
        Get
            Return Me._PRECIO_KILOS
        End Get
        Set(ByVal Value As Double)
            Me._PRECIO_KILOS = Value
        End Set
    End Property

    Public Property IMPORTE_KILOS() As Double
        Get
            Return Me._IMPORTE_KILOS
        End Get
        Set(ByVal Value As Double)
            Me._IMPORTE_KILOS = Value
        End Set
    End Property

    Public Property ES_PRODUCTO_KILOS() As String
        Get
            Return Me._ES_PRODUCTO_KILOS
        End Get
        Set(ByVal Value As String)
            Me._ES_PRODUCTO_KILOS = Value
        End Set
    End Property

    Public Property CODIGO_CENTRO_COSTO() As String
        Get
            Return Me._CODIGO_CENTRO_COSTO
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_CENTRO_COSTO = Value
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

    Public Property PRECIO_USD() As Double
        Get
            Return Me._PRECIO_USD
        End Get
        Set(ByVal Value As Double)
            Me._PRECIO_USD = Value
        End Set
    End Property

    Public Property IMPORTE_USD() As Double
        Get
            Return Me._IMPORTE_USD
        End Get
        Set(ByVal Value As Double)
            Me._IMPORTE_USD = Value
        End Set
    End Property

    Public Property IEPS_PORCENTAJE() As Double
        Get
            Return Me._IEPS_PORCENTAJE
        End Get
        Set(ByVal Value As Double)
            Me._IEPS_PORCENTAJE = Value
        End Set
    End Property

    Public Property IEPS_UNITARIO() As Double
        Get
            Return Me._IEPS_UNITARIO
        End Get
        Set(ByVal Value As Double)
            Me._IEPS_UNITARIO = Value
        End Set
    End Property

    Public Property IEPS_IMPORTE() As Double
        Get
            Return Me._IEPS_IMPORTE
        End Get
        Set(ByVal Value As Double)
            Me._IEPS_IMPORTE = Value
        End Set
    End Property

    Public Property BASE_IEPS() As Double
        Get
            Return Me._BASE_IEPS
        End Get
        Set(ByVal Value As Double)
            Me._BASE_IEPS = Value
        End Set
    End Property

    Public Property BASE_IVA() As Double
        Get
            Return Me._BASE_IVA
        End Get
        Set(ByVal Value As Double)
            Me._BASE_IVA = Value
        End Set
    End Property

    Public Property PRECIO_TOTAL() As Double
        Get
            Return Me._PRECIO_TOTAL
        End Get
        Set(ByVal Value As Double)
            Me._PRECIO_TOTAL = Value
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
        Me._QuerySelect = "Select * from VENTA_DETALLE where "
        Me._QueryOrder = " Order by ID_VENTA_DETALLE"
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
        If Len(Me._CODIGO_CENTRO_COSTO) < 1 Then
            Me._CODIGO_CENTRO_COSTO = "0"
        End If
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_VENTA_GRABA_VENTA_DETALLE"

            sqlParametro = .Parameters.Add("@FOLIO_VENTA", SqlDbType.NVarChar, 15) : sqlParametro.Value = "" & Me._FOLIO_VENTA
            sqlParametro = .Parameters.Add("@CODIGO_ARTICULO", SqlDbType.NVarChar, 16) : sqlParametro.Value = "" & Me._CODIGO_ARTICULO
            sqlParametro = .Parameters.Add("@CANTIDAD", SqlDbType.Decimal) : sqlParametro.Value = "" & Me._CANTIDAD
            sqlParametro = .Parameters.Add("@PRECIO", SqlDbType.Decimal) : sqlParametro.Value = Me._PRECIO
            sqlParametro = .Parameters.Add("@UNIDAD_VENTA", SqlDbType.NVarChar, 10) : sqlParametro.Value = Me._UNIDAD_VENTA
            sqlParametro = .Parameters.Add("@IMPUESTO_PORCENTAJE", SqlDbType.Decimal) : sqlParametro.Value = Me._IMPUESTO_PORCENTAJE
            sqlParametro = .Parameters.Add("@IMPUESTO_IMPORTE", SqlDbType.Decimal) : sqlParametro.Value = Me._IMPUESTO_IMPORTE
            sqlParametro = .Parameters.Add("@IMPORTE", SqlDbType.Decimal) : sqlParametro.Value = Me._IMPORTE
            sqlParametro = .Parameters.Add("@ID_ORIGEN", SqlDbType.Int) : sqlParametro.Value = Me._ID_ORIGEN
            sqlParametro = .Parameters.Add("@CUENTA_CONTABLE", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._CUENTA_CONTABLE
            sqlParametro = .Parameters.Add("@COMENTARIO", SqlDbType.NVarChar, 500) : sqlParametro.Value = Me._COMENTARIO
            sqlParametro = .Parameters.Add("@CANTIDAD_KILOS", SqlDbType.Decimal) : sqlParametro.Value = "" & Me._CANTIDAD_KILOS
            sqlParametro = .Parameters.Add("@PRECIO_KILOS", SqlDbType.Decimal) : sqlParametro.Value = Me._PRECIO_KILOS
            sqlParametro = .Parameters.Add("@IMPORTE_KILOS", SqlDbType.Decimal) : sqlParametro.Value = Me._IMPORTE_KILOS
            sqlParametro = .Parameters.Add("@ES_PRODUCTO_KILOS", SqlDbType.Char, 1) : sqlParametro.Value = Me._ES_PRODUCTO_KILOS
            sqlParametro = .Parameters.Add("@CODIGO_CENTRO_COSTO", SqlDbType.SmallInt) : sqlParametro.Value = CInt(Me._CODIGO_CENTRO_COSTO)
            sqlParametro = .Parameters.Add("@LISTA_SERIES", SqlDbType.NVarChar, -1) : sqlParametro.Value = Me._LISTA_SERIES
            sqlParametro = .Parameters.Add("@PRECIO_USD", SqlDbType.Decimal) : sqlParametro.Value = Me._PRECIO_USD
            sqlParametro = .Parameters.Add("@IMPORTE_USD", SqlDbType.Decimal) : sqlParametro.Value = Me._IMPORTE_USD
            sqlParametro = .Parameters.Add("@IEPS_PORCENTAJE", SqlDbType.Decimal) : sqlParametro.Value = Me._IEPS_PORCENTAJE
            sqlParametro = .Parameters.Add("@IEPS_UNITARIO", SqlDbType.Decimal) : sqlParametro.Value = Me._IEPS_UNITARIO
            sqlParametro = .Parameters.Add("@IEPS_IMPORTE", SqlDbType.Decimal) : sqlParametro.Value = Me._IEPS_IMPORTE
            sqlParametro = .Parameters.Add("@BASE_IEPS", SqlDbType.Decimal) : sqlParametro.Value = Me._BASE_IEPS
            sqlParametro = .Parameters.Add("@BASE_IVA", SqlDbType.Decimal) : sqlParametro.Value = Me._BASE_IVA
            sqlParametro = .Parameters.Add("@PRECIO_TOTAL", SqlDbType.Decimal) : sqlParametro.Value = Me._PRECIO_TOTAL

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

    Public Function ActualizaPrecioRemision() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_VENTA_REMISIONES_ACTUALIZA_PRECIO_RENGLON"

            sqlParametro = .Parameters.Add("@FOLIO_REMISION", SqlDbType.NVarChar, 15) : sqlParametro.Value = "" & Me._FOLIO_VENTA
            sqlParametro = .Parameters.Add("@CODIGO_PLAZA", SqlDbType.SmallInt) : sqlParametro.Value = Plaza.CODIGO_PLAZA
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Usuario
            sqlParametro = .Parameters.Add("@ID_VENTA_DETALLE", SqlDbType.Int) : sqlParametro.Value = Me._ID_VENTA_DETALLE
            sqlParametro = .Parameters.Add("@PRECIO_NUEVO", SqlDbType.Decimal) : sqlParametro.Value = Me._PRECIO_NUEVO
            sqlParametro = .Parameters.Add("@IMPORTE", SqlDbType.Decimal) : sqlParametro.Value = Me._IMPORTE
            sqlParametro = .Parameters.Add("@IMPUESTO_IMPORTE", SqlDbType.Decimal) : sqlParametro.Value = Me._IMPUESTO_IMPORTE

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me._Nombre_Clase, "ActualizaPrecioRemision", ex)
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