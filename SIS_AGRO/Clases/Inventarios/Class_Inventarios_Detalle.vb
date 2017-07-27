Option Strict On
Imports System.Data
Imports System.Data.SqlClient

Public Class Class_Inventarios_Detalle

#Region "Campos"

#Region "Campos de la tabla"
    Private _FOLIO_MOVIMIENTO_INVENTARIO As String
    Private _CODIGO_ARTICULO As String
    Private _CANTIDAD As Double
    Private _COSTO As Double
    Private _CUENTA_CONTABLE As String
    Private _IMPORTE As Decimal
    Private _ID_ADICIONAL As Integer = 0
    Private _LISTA_SERIES As String
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

    Public Property FOLIO_MOVIMIENTO_INVENTARIO() As String
        Get
            Return Me._FOLIO_MOVIMIENTO_INVENTARIO
        End Get
        Set(ByVal Value As String)
            Me._FOLIO_MOVIMIENTO_INVENTARIO = Value
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

    Public Property COSTO() As Double
        Get
            Return Me._COSTO
        End Get
        Set(ByVal Value As Double)
            Me._COSTO = Value
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

    Public Property IMPORTE() As Decimal
        Get
            Return Me._IMPORTE
        End Get
        Set(ByVal Value As Decimal)
            Me._IMPORTE = Value
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
        Me._QuerySelect = "Select * from INVENTARIO_MOVIMIENTOS_GLOBAL where "
        Me._QueryOrder = " Order by FOLIO_MOVIMIENTO_INVENTARIO"
    End Sub                                                         'Inicializa al objeto.

    Public Sub New(ByVal sfolioMovimientoInventario As String)
        Me.New()
        Try
            Me.FOLIO_MOVIMIENTO_INVENTARIO = sfolioMovimientoInventario
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
            .CommandText = "MP_INVENTARIOS_MOVIMIENTOS_GRABA_DETALLE"

            sqlParametro = .Parameters.Add("@FOLIO_MOVIMIENTO_INVENTARIO", SqlDbType.NVarChar, 15) : sqlParametro.Value = "" & Me._FOLIO_MOVIMIENTO_INVENTARIO.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_ARTICULO", SqlDbType.NVarChar, 16) : sqlParametro.Value = "" & Me._CODIGO_ARTICULO.ToUpper
            sqlParametro = .Parameters.Add("@COSTO", SqlDbType.Money) : sqlParametro.Value = Me._COSTO
            sqlParametro = .Parameters.Add("@CANTIDAD", SqlDbType.Money) : sqlParametro.Value = Me._CANTIDAD
            sqlParametro = .Parameters.Add("@CUENTA_CONTABLE", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._CUENTA_CONTABLE
            sqlParametro = .Parameters.Add("@IMPORTE", SqlDbType.Decimal) : sqlParametro.Value = Me._IMPORTE
            sqlParametro = .Parameters.Add("@ID_ADICIONAL", SqlDbType.Int) : sqlParametro.Value = Me._ID_ADICIONAL
            sqlParametro = .Parameters.Add("@LISTA_SERIES", SqlDbType.NVarChar) : sqlParametro.Value = Me._LISTA_SERIES.ToUpper

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

    Public Function Obtener_Costo(ByVal CODIGO_ARTICULO As String, ByVal CODIGO_ALMACEN As String, ByVal CANTIDAD As Double) As Decimal
        Dim dResultado As Decimal = 0
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_INVENTARIO_COSTEO_ARTICULOS"

            sqlParametro = .Parameters.Add("@COSTO_CALCULADO", SqlDbType.Money) : sqlParametro.Direction = ParameterDirection.Output
            sqlParametro = .Parameters.Add("@CODIGO_ARTICULO", SqlDbType.NVarChar, 16) : sqlParametro.Value = CODIGO_ARTICULO
            sqlParametro = .Parameters.Add("@CODIGO_ALMACEN", SqlDbType.NVarChar, 4) : sqlParametro.Value = CODIGO_ALMACEN
            sqlParametro = .Parameters.Add("@CANTIDAD", SqlDbType.Money) : sqlParametro.Value = CANTIDAD
            sqlParametro = .Parameters.Add("@SIMULACION_DE_COSTEO", SqlDbType.SmallInt) : sqlParametro.Value = 1
            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                If IsDBNull(.Parameters("@COSTO_CALCULADO").Value) Then
                    dResultado = 0
                Else
                    dResultado = CDec(.Parameters("@COSTO_CALCULADO").Value)
                End If
            Catch ex As Exception
                HandleError(Me._Nombre_Clase, "Obtener_Costo", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return dResultado
    End Function

    Public Function GrabaDetalleCentroCostos(ByVal sListaCuentas As String, ByVal sCodigoDocumento As String, ByVal dFecha As DateTime, ByVal bGenerarEnNegativo As Boolean) As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CENTRO_COSTOS_GRABA_DETALLE_CUENTAS_CONTABLES"

            sqlParametro = .Parameters.Add("@FOLIO_MOVIMIENTO", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_MOVIMIENTO_INVENTARIO.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_DOCUMENTO", SqlDbType.NVarChar, 10) : sqlParametro.Value = sCodigoDocumento
            sqlParametro = .Parameters.Add("@FECHA", SqlDbType.Date) : sqlParametro.Value = dFecha
            sqlParametro = .Parameters.Add("@LISTA_CUENTAS", SqlDbType.NVarChar, -1) : sqlParametro.Value = sListaCuentas
            sqlParametro = .Parameters.Add("@ESTATUS_COSTO", SqlDbType.Char) : sqlParametro.Value = "G" 'Queda grabado desde un inicio porque las inventarios no se aplican, primero se graban, se aplicará hasta que apliquen la salida.
            sqlParametro = .Parameters.Add("@GENERAR_EN_NEGATIVO", SqlDbType.Char, 1) : sqlParametro.Value = Convert.ToInt32(bGenerarEnNegativo)

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me._Nombre_Clase, "GrabaDetalleCentroCostos", ex)
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


