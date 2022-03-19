Option Strict On

Imports System.Data.SqlClient

Public Class Class_CartaPorte

#Region "Campos"
#Region "Campos de la tabla"
    Private _ID_CFDI_CARTA_PORTE_GLOBAL As Integer
    Private _FOLIO_VENTA As String
    Private _VERSION As String
    Private _TRANSPORTE_INTERNACIONAL As String
    Private _ENTRADA_SALIDA_MERCANCIA As String
    Private _CODIGO_PAIS_SAT As String
    Private _CODIGO_TRANSPORTE As String
    Private _TOTAL_DISTANCIA_RECORRIDA As Decimal
    Private _PESO_BRUTO_TOTAL As Decimal
    Private _CODIGO_UNIDAD_PESO As String
    Private _NUMERO_TOTAL_MERCANCIAS As Integer
    Private _CODIGO_VEHICULO As Integer
    Private _CODIGO_REMOLQUE_1 As String
    Private _CODIGO_REMOLQUE_2 As String
#End Region

#Region "Campos ligados a la tabla"
    Private _LISTA_UBICACIONES As String
    Private _LISTA_MERCANCIAS As String
    Private _LISTA_FIGURAS_TRANSPORTE As String
    Private _LISTA_FIGURAS_PARTES_TRANSPORTE As String
#End Region

#Region "Campos de sistema"
    Private _Conexion As SqlConnection
#End Region

#End Region

#Region "Propiedades"

#Region "Propiedades campos de la tabla"
    Public ReadOnly Property ID_CFDI_CARTA_PORTE_GLOBAL() As Integer
        Get
            Return Me._ID_CFDI_CARTA_PORTE_GLOBAL
        End Get
    End Property

    Public Property FOLIO_VENTA() As String
        Get
            Return Me._FOLIO_VENTA
        End Get
        Set(ByVal Value As String)
            Me._FOLIO_VENTA = Value
        End Set
    End Property

    Public Property VERSION() As String
        Get
            Return Me._VERSION
        End Get
        Set(ByVal Value As String)
            Me._VERSION = Value
        End Set
    End Property

    Public Property TRANSPORTE_INTERNACIONAL() As String
        Get
            Return Me._TRANSPORTE_INTERNACIONAL
        End Get
        Set(ByVal Value As String)
            Me._TRANSPORTE_INTERNACIONAL = Value
        End Set
    End Property

    Public Property ENTRADA_SALIDA_MERCANCIA() As String
        Get
            Return Me._ENTRADA_SALIDA_MERCANCIA
        End Get
        Set(ByVal Value As String)
            Me._ENTRADA_SALIDA_MERCANCIA = Value
        End Set
    End Property

    Public Property CODIGO_PAIS_SAT() As String
        Get
            Return Me._CODIGO_PAIS_SAT
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_PAIS_SAT = Value
        End Set
    End Property

    Public Property CODIGO_TRANSPORTE() As String
        Get
            Return Me._CODIGO_TRANSPORTE
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_TRANSPORTE = Value
        End Set
    End Property

    Public Property TOTAL_DISTANCIA_RECORRIDA() As Decimal
        Get
            Return Me._TOTAL_DISTANCIA_RECORRIDA
        End Get
        Set(ByVal Value As Decimal)
            Me._TOTAL_DISTANCIA_RECORRIDA = Value
        End Set
    End Property

    Public Property PESO_BRUTO_TOTAL() As Decimal
        Get
            Return Me._PESO_BRUTO_TOTAL
        End Get
        Set(ByVal Value As Decimal)
            Me._PESO_BRUTO_TOTAL = Value
        End Set
    End Property

    Public Property CODIGO_UNIDAD_PESO() As String
        Get
            Return Me._CODIGO_UNIDAD_PESO
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_UNIDAD_PESO = Value
        End Set
    End Property

    Public Property NUMERO_TOTAL_MERCANCIAS() As Integer
        Get
            Return Me._NUMERO_TOTAL_MERCANCIAS
        End Get
        Set(ByVal Value As Integer)
            Me._NUMERO_TOTAL_MERCANCIAS = Value
        End Set
    End Property

    Public Property CODIGO_VEHICULO() As Integer
        Get
            Return Me._CODIGO_VEHICULO
        End Get
        Set(ByVal Value As Integer)
            Me._CODIGO_VEHICULO = Value
        End Set
    End Property

    Public Property CODIGO_REMOLQUE_1() As String
        Get
            Return Me._CODIGO_REMOLQUE_1
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_REMOLQUE_1 = Value
        End Set
    End Property

    Public Property CODIGO_REMOLQUE_2() As String
        Get
            Return Me._CODIGO_REMOLQUE_2
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_REMOLQUE_2 = Value
        End Set
    End Property
#End Region

#Region "Propiedades de campos ligados a la tabla"
    Public Property LISTA_UBICACIONES() As String
        Get
            Return Me._LISTA_UBICACIONES
        End Get
        Set(ByVal Value As String)
            Me._LISTA_UBICACIONES = Value
        End Set
    End Property

    Public Property LISTA_MERCANCIAS() As String
        Get
            Return Me._LISTA_MERCANCIAS
        End Get
        Set(ByVal Value As String)
            Me._LISTA_MERCANCIAS = Value
        End Set
    End Property

    Public Property LISTA_FIGURAS_TRANSPORTE() As String
        Get
            Return Me._LISTA_FIGURAS_TRANSPORTE
        End Get
        Set(ByVal Value As String)
            Me._LISTA_FIGURAS_TRANSPORTE = Value
        End Set
    End Property

    Public Property LISTA_FIGURAS_PARTES_TRANSPORTE() As String
        Get
            Return Me._LISTA_FIGURAS_PARTES_TRANSPORTE
        End Get
        Set(ByVal Value As String)
            Me._LISTA_FIGURAS_PARTES_TRANSPORTE = Value
        End Set
    End Property
#End Region

#Region "Propiedades de sistema"
    Private ReadOnly Property NombreClase() As String
        Get
            Return "Class_CartaPorte"
        End Get
    End Property
#End Region

#End Region

#Region "Constructor y destructor"
    Public Sub New()
        Me._Conexion = New SqlConnection(Empresa_Sistema.conexion)
    End Sub
#End Region

#Region "Métodos y procedimientos"
    Public Function Grabar(ByVal sAccion As String) As Boolean
        Const sProcedure As String = "Grabar"
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter

        Try
            With cmd
                .Connection = Me._Conexion
                .CommandTimeout = 0
                .CommandType = CommandType.StoredProcedure
                .CommandText = "MP_CFDI_CARTA_PORTE_GRABA"

                sqlParametro = .Parameters.Add("@ACCION", SqlDbType.NVarChar, 20) : sqlParametro.Value = sAccion 'INSERTAR,ACTUALIZAR
                sqlParametro = .Parameters.Add("@ID_CFDI_CARTA_PORTE_GLOBAL", SqlDbType.Int) : sqlParametro.Value = Me._ID_CFDI_CARTA_PORTE_GLOBAL : sqlParametro.Direction = ParameterDirection.InputOutput
                sqlParametro = .Parameters.Add("@FOLIO_VENTA", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_VENTA
                sqlParametro = .Parameters.Add("@VERSION", SqlDbType.NVarChar, 3) : sqlParametro.Value = Me._VERSION
                sqlParametro = .Parameters.Add("@TRANSPORTE_INTERNACIONAL", SqlDbType.NVarChar, 2) : sqlParametro.Value = Me._TRANSPORTE_INTERNACIONAL
                sqlParametro = .Parameters.Add("@ENTRADA_SALIDA_MERCANCIA", SqlDbType.NVarChar, 10) : sqlParametro.Value = Me._ENTRADA_SALIDA_MERCANCIA
                sqlParametro = .Parameters.Add("@CODIGO_PAIS_SAT", SqlDbType.NVarChar, 4) : sqlParametro.Value = Me._CODIGO_PAIS_SAT
                sqlParametro = .Parameters.Add("@CODIGO_TRANSPORTE", SqlDbType.NVarChar, 2) : sqlParametro.Value = Me._CODIGO_TRANSPORTE
                sqlParametro = .Parameters.Add("@TOTAL_DISTANCIA_RECORRIDA", SqlDbType.Decimal) : sqlParametro.Value = Me._TOTAL_DISTANCIA_RECORRIDA
                sqlParametro = .Parameters.Add("@PESO_BRUTO_TOTAL", SqlDbType.Decimal) : sqlParametro.Value = Me._PESO_BRUTO_TOTAL
                sqlParametro = .Parameters.Add("@CODIGO_UNIDAD_PESO", SqlDbType.NVarChar, 10) : sqlParametro.Value = Me._CODIGO_UNIDAD_PESO
                sqlParametro = .Parameters.Add("@NUMERO_TOTAL_MERCANCIAS", SqlDbType.Int) : sqlParametro.Value = Me._NUMERO_TOTAL_MERCANCIAS
                sqlParametro = .Parameters.Add("@CODIGO_VEHICULO", SqlDbType.Int) : sqlParametro.Value = Me._CODIGO_VEHICULO
                sqlParametro = .Parameters.Add("@CODIGO_REMOLQUE_1", SqlDbType.NVarChar, 3) : sqlParametro.Value = Me._CODIGO_REMOLQUE_1
                sqlParametro = .Parameters.Add("@CODIGO_REMOLQUE_2", SqlDbType.NVarChar, 3) : sqlParametro.Value = Me._CODIGO_REMOLQUE_2
                sqlParametro = .Parameters.Add("@LISTA_UBICACIONES", SqlDbType.NVarChar, -1) : sqlParametro.Value = Me._LISTA_UBICACIONES
                sqlParametro = .Parameters.Add("@LISTA_MERCANCIAS", SqlDbType.NVarChar, -1) : sqlParametro.Value = Me._LISTA_MERCANCIAS
                sqlParametro = .Parameters.Add("@LISTA_FIGURAS_TRANSPORTE", SqlDbType.NVarChar, -1) : sqlParametro.Value = Me._LISTA_FIGURAS_TRANSPORTE
                sqlParametro = .Parameters.Add("@LISTA_FIGURAS_PARTES_TRANSPORTE", SqlDbType.NVarChar, -1) : sqlParametro.Value = Me._LISTA_FIGURAS_PARTES_TRANSPORTE

                Me._Conexion.Open()
                .ExecuteNonQuery()

                If sAccion = "INSERTAR" Then
                    Me._ID_CFDI_CARTA_PORTE_GLOBAL = CInt(.Parameters("@ID_CFDI_CARTA_PORTE_GLOBAL").Value.ToString) 'Se asegura el cambio del folio
                End If

                bResultado = True

                Me._Conexion.Close()
            End With

        Catch ex As Exception
            HandleError(Me.NombreClase, sProcedure, ex)
        Finally
            cmd.Dispose()
            sqlParametro = Nothing
        End Try

        Return bResultado

    End Function
#End Region

End Class
