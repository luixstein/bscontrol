Option Strict On
Imports System.Data
Imports System.Data.SqlClient

Public Class Class_Compras_Detalle

#Region "Campos"

#Region "Campos de la tabla"
    Private _FOLIO_COMPRA As String
    Private _ID_COMPRA_DETALLE As Integer
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
    Private _ID_ADICIONAL As Integer = 0
    Private _LISTA_SERIES As String

    Private _IEPS_PORCENTAJE As Double
    Private _IEPS_UNITARIO As Double
    Private _IEPS_IMPORTE As Double
    Private _BASE_IEPS As Double
    Private _BASE_IVA As Double
    Private _COSTO As Double

    Private _PRECIO_USD As Decimal
    Private _IMPORTE_USD As Decimal
    Private _IMPUESTO_IMPORTE_USD As Decimal
    Private _IEPS_UNITARIO_USD As Decimal
    Private _IEPS_IMPORTE_USD As Decimal
    Private _BASE_IEPS_USD As Decimal
    Private _BASE_IVA_USD As Decimal
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
    Public Property FOLIO_COMPRA() As String
        Get
            Return Me._FOLIO_COMPRA
        End Get
        Set(ByVal Value As String)
            Me._FOLIO_COMPRA = Value
        End Set
    End Property

    Public ReadOnly Property ID_COMPRA_DETALLE() As Integer
        Get
            Return Me._ID_COMPRA_DETALLE
        End Get
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

    Public ReadOnly Property DISPONIBLE() As Double
        Get
            Return Me._DISPONIBLE
        End Get
    End Property

    Public Property PRECIO() As Double
        Get
            Return Me._PRECIO
        End Get
        Set(ByVal Value As Double)
            Me._PRECIO = Value
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

    Public Property ID_ADICIONAL() As Integer
        Get
            Return Me._ID_ADICIONAL
        End Get
        Set(ByVal Value As Integer)
            Me._ID_ADICIONAL = Value
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

    Public Property COSTO() As Double
        Get
            Return Me._COSTO
        End Get
        Set(value As Double)
            Me._COSTO = value
        End Set
    End Property

    Public Property PRECIO_USD() As Decimal
        Get
            Return Me._PRECIO_USD
        End Get
        Set(value As Decimal)
            Me._PRECIO_USD = value
        End Set
    End Property

    Public Property IMPORTE_USD() As Decimal
        Get
            Return Me._IMPORTE_USD
        End Get
        Set(value As Decimal)
            Me._IMPORTE_USD = value
        End Set
    End Property

    Public Property IMPUESTO_IMPORTE_USD() As Decimal
        Get
            Return Me._IMPUESTO_IMPORTE_USD
        End Get
        Set(value As Decimal)
            Me._IMPUESTO_IMPORTE_USD = value
        End Set
    End Property

    Public Property IEPS_UNITARIO_USD() As Decimal
        Get
            Return Me._IEPS_UNITARIO_USD
        End Get
        Set(value As Decimal)
            Me._IEPS_UNITARIO_USD = value
        End Set
    End Property

    Public Property IEPS_IMPORTE_USD() As Decimal
        Get
            Return Me._IEPS_IMPORTE_USD
        End Get
        Set(value As Decimal)
            Me._IEPS_IMPORTE_USD = value
        End Set
    End Property

    Public Property BASE_IEPS_USD() As Decimal
        Get
            Return Me._BASE_IEPS_USD
        End Get
        Set(value As Decimal)
            Me._BASE_IEPS_USD = value
        End Set
    End Property

    Public Property BASE_IVA_USD() As Decimal
        Get
            Return Me._BASE_IVA_USD
        End Get
        Set(value As Decimal)
            Me._BASE_IVA_USD = value
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
        Me._Nombre_Catalogo = "COMPRA_DETALLE"
        Me._Conexion = New SqlConnection(Empresa_Sistema.conexion)
        Me._QuerySelect = "SELECT * FROM COMPRA_DETALLE WHERE "
        Me._QueryOrder = " ORDER BY ID_COMPRA_DETALLE"
    End Sub

    Protected Overrides Sub Finalize()
        'Me._Conexion.Dispose()
        MyBase.Finalize()
    End Sub
#End Region

#Region "Métodos y procedimientos"
    Public Function GrabaRenglonOrdenCompra() As Boolean
        Const sProcedure As String = "GrabaRenglonOrdenCompra"
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_COMPRAS_GRABA_ORDEN_COMPRA_DETALLE"

            sqlParametro = .Parameters.Add("@FOLIO_COMPRA", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_COMPRA
            sqlParametro = .Parameters.Add("@CODIGO_ARTICULO", SqlDbType.NVarChar, 16) : sqlParametro.Value = Me._CODIGO_ARTICULO
            sqlParametro = .Parameters.Add("@DESCRIPCION", SqlDbType.NVarChar, 80) : sqlParametro.Value = Me._DESCRIPCION
            sqlParametro = .Parameters.Add("@CANTIDAD", SqlDbType.Decimal) : sqlParametro.Value = Me._CANTIDAD
            sqlParametro = .Parameters.Add("@PRECIO", SqlDbType.Decimal) : sqlParametro.Value = Me._PRECIO
            sqlParametro = .Parameters.Add("@UNIDAD_VENTA", SqlDbType.NVarChar, 5) : sqlParametro.Value = Me._UNIDAD_VENTA
            sqlParametro = .Parameters.Add("@IMPUESTO_PORCENTAJE", SqlDbType.Decimal) : sqlParametro.Value = Me._IMPUESTO_PORCENTAJE
            sqlParametro = .Parameters.Add("@IMPUESTO_IMPORTE", SqlDbType.Decimal) : sqlParametro.Value = Me._IMPUESTO_IMPORTE
            sqlParametro = .Parameters.Add("@IMPORTE", SqlDbType.Decimal) : sqlParametro.Value = Me._IMPORTE
            sqlParametro = .Parameters.Add("@IEPS_PORCENTAJE", SqlDbType.Decimal) : sqlParametro.Value = Me._IEPS_PORCENTAJE
            sqlParametro = .Parameters.Add("@IEPS_UNITARIO", SqlDbType.Decimal) : sqlParametro.Value = Me._IEPS_UNITARIO
            sqlParametro = .Parameters.Add("@IEPS_IMPORTE", SqlDbType.Decimal) : sqlParametro.Value = Me._IEPS_IMPORTE
            sqlParametro = .Parameters.Add("@BASE_IEPS", SqlDbType.Decimal) : sqlParametro.Value = Me._BASE_IEPS
            sqlParametro = .Parameters.Add("@BASE_IVA", SqlDbType.Decimal) : sqlParametro.Value = Me._BASE_IVA
            sqlParametro = .Parameters.Add("@COSTO", SqlDbType.Decimal) : sqlParametro.Value = Me._COSTO
            sqlParametro = .Parameters.Add("@PRECIO_USD", SqlDbType.Decimal) : sqlParametro.Value = Me._PRECIO_USD
            sqlParametro = .Parameters.Add("@IMPORTE_USD", SqlDbType.Decimal) : sqlParametro.Value = Me._IMPORTE_USD
            sqlParametro = .Parameters.Add("@IMPUESTO_IMPORTE_USD", SqlDbType.Decimal) : sqlParametro.Value = Me._IMPUESTO_IMPORTE_USD
            sqlParametro = .Parameters.Add("@IEPS_UNITARIO_USD", SqlDbType.Decimal) : sqlParametro.Value = Me._IEPS_UNITARIO_USD
            sqlParametro = .Parameters.Add("@IEPS_IMPORTE_USD", SqlDbType.Decimal) : sqlParametro.Value = Me._IEPS_IMPORTE_USD
            sqlParametro = .Parameters.Add("@BASE_IEPS_USD", SqlDbType.Decimal) : sqlParametro.Value = Me._BASE_IEPS_USD
            sqlParametro = .Parameters.Add("@BASE_IVA_USD", SqlDbType.Decimal) : sqlParametro.Value = Me._BASE_IVA_USD

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, sProcedure, ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Function GrabaRenglonCompra() As Boolean
        Const sProcedure As String = "GrabaRenglonCompra"
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_COMPRAS_GRABA_COMPRA_DETALLE"

            sqlParametro = .Parameters.Add("@FOLIO_COMPRA", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_COMPRA
            sqlParametro = .Parameters.Add("@CODIGO_ARTICULO", SqlDbType.NVarChar, 16) : sqlParametro.Value = Me._CODIGO_ARTICULO
            sqlParametro = .Parameters.Add("@CANTIDAD", SqlDbType.Decimal) : sqlParametro.Value = Me._CANTIDAD
            sqlParametro = .Parameters.Add("@PRECIO", SqlDbType.Decimal) : sqlParametro.Value = Me._PRECIO
            sqlParametro = .Parameters.Add("@UNIDAD_VENTA", SqlDbType.NVarChar, 5) : sqlParametro.Value = Me._UNIDAD_VENTA
            sqlParametro = .Parameters.Add("@IMPUESTO_PORCENTAJE", SqlDbType.Decimal) : sqlParametro.Value = Me._IMPUESTO_PORCENTAJE
            sqlParametro = .Parameters.Add("@IMPUESTO_IMPORTE", SqlDbType.Decimal) : sqlParametro.Value = Me._IMPUESTO_IMPORTE
            sqlParametro = .Parameters.Add("@IMPORTE", SqlDbType.Decimal) : sqlParametro.Value = Me._IMPORTE
            sqlParametro = .Parameters.Add("@ID_ORIGEN", SqlDbType.Int) : sqlParametro.Value = Me._ID_ORIGEN
            sqlParametro = .Parameters.Add("@CUENTA_CONTABLE", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._CUENTA_CONTABLE
            sqlParametro = .Parameters.Add("@ES_COMPRA_SERVICIO", SqlDbType.Char, 1) : sqlParametro.Value = "0"
            sqlParametro = .Parameters.Add("@CODIGO_CENTRO_COSTO", SqlDbType.SmallInt) : sqlParametro.Value = 0
            sqlParametro = .Parameters.Add("@ID_ADICIONAL", SqlDbType.Int) : sqlParametro.Value = Me._ID_ADICIONAL
            sqlParametro = .Parameters.Add("@ID_COMPRA_DETALLE", SqlDbType.Int) : sqlParametro.Value = Me._ID_COMPRA_DETALLE : sqlParametro.Direction = ParameterDirection.Output
            sqlParametro = .Parameters.Add("@LISTA_SERIES", SqlDbType.NVarChar, -1) : sqlParametro.Value = Me._LISTA_SERIES
            sqlParametro = .Parameters.Add("@IEPS_PORCENTAJE", SqlDbType.Decimal) : sqlParametro.Value = Me._IEPS_PORCENTAJE
            sqlParametro = .Parameters.Add("@IEPS_UNITARIO", SqlDbType.Decimal) : sqlParametro.Value = Me._IEPS_UNITARIO
            sqlParametro = .Parameters.Add("@IEPS_IMPORTE", SqlDbType.Decimal) : sqlParametro.Value = Me._IEPS_IMPORTE
            sqlParametro = .Parameters.Add("@BASE_IEPS", SqlDbType.Decimal) : sqlParametro.Value = Me._BASE_IEPS
            sqlParametro = .Parameters.Add("@BASE_IVA", SqlDbType.Decimal) : sqlParametro.Value = Me._BASE_IVA
            sqlParametro = .Parameters.Add("COSTO", SqlDbType.Decimal) : sqlParametro.Value = Me._COSTO

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()

                Me._ID_COMPRA_DETALLE = CInt(.Parameters("@ID_COMPRA_DETALLE").Value)

                bResultado = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, sProcedure, ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Function GrabaDetalleCentroCostos(ByVal sListaCuentas As String, ByVal sCodigoDocumento As String, ByVal dFecha As DateTime) As Boolean
        Const sProcedure As String = "GrabaDetalleCentroCostos"
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CENTRO_COSTOS_GRABA_DETALLE_CUENTAS_CONTABLES"

            sqlParametro = .Parameters.Add("@FOLIO_MOVIMIENTO", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_COMPRA.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_DOCUMENTO", SqlDbType.NVarChar, 10) : sqlParametro.Value = sCodigoDocumento
            sqlParametro = .Parameters.Add("@FECHA", SqlDbType.Date) : sqlParametro.Value = dFecha
            sqlParametro = .Parameters.Add("@LISTA_CUENTAS", SqlDbType.NVarChar, -1) : sqlParametro.Value = sListaCuentas
            sqlParametro = .Parameters.Add("@ESTATUS_COSTO", SqlDbType.Char) : sqlParametro.Value = "A" 'Queda aplicado desde un inicio porque las compras no se graban, se aplican(afectan directamente)
            sqlParametro = .Parameters.Add("@GENERAR_EN_NEGATIVO", SqlDbType.Char, 1) : sqlParametro.Value = "0"

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, sProcedure, ex)
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



