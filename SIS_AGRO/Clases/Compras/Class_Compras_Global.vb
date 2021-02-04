Option Strict On

Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class Class_Compras_Global

#Region "Campos"

#Region "Campos de la tabla"
    Private _ID_COMPRA_GLOBAL As Integer
    Private _FOLIO_COMPRA As String
    Private _FOLIO_NUMERICO As Integer
    Private _CODIGO_DOCUMENTO As String
    Private _CODIGO_ALMACEN As String
    Private _CODIGO_PLAZA As Integer
    Private _FECHA As Date
    Private _FECHA_FACTURA_PROVEEDOR As Date
    Private _FECHA_SERVIDOR As Date
    Private _FOLIO_OC As String
    Private _FOLIO_PROVEEDOR As String
    Private _CODIGO_PROVEEDOR As String
    Private _PLAZO As Integer
    Private _FECHA_VENCIMIENTO As Date
    Private _SUBTOTAL As Double
    Private _IEPS_TOTAL_DESGLOSADO As Double
    Private _IMPUESTO As Double
    Private _TOTAL As Double
    Private _RETENCION_IVA As Double
    Private _RETENCION_ISR As Double
    Private _IMPUESTO_PORCENTAJE As Double
    Private _SALDO As Double
    Private _TIPO_DE_CAMBIO As Double
    Private _ESTATUS As String
    Private _ENTREGAR_A As String
    Private _SOLICITO As String
    Private _CONCEPTO As String
    Private _CON_CARGO_A As String
    Private _PREDIO As String
    Private _CONFIRMO As String
    Private _FOLIO_POLIZA As String
    Private _CODIGO_USUARIO_GRABO As Integer
    Private _NOMBRE_USUARIO_GRABO As String
    Private _CODIGO_USUARIO_CANCELO As Integer
    Private _NOMBRE_USUARIO_CANCELO As String
    Private _FECHA_CANCELACION As Date
    Private _FECHA_CANCELACION_SERVIDOR As Date
    Private _CONTRARECIBO_HECHO As String
    Private _FECHA_CONTRARECIBO As Date
    Private _FECHA_PROGRAMACION As Date
    Private _FOLIO_EMBARQUE As String
    Private _CODIGO_TIPO_GASTO As String
    Private _SALDO_IMPUESTO As Double
    Private _CODIGO_MONEDA As String

    Private _SUBTOTAL_USD As Double
    Private _IEPS_TOTAL_DESGLOSADO_USD As Double
    Private _IMPUESTO_USD As Double
    Private _RETENCION_IVA_USD As Double
    Private _RETENCION_ISR_USD As Double
    Private _TOTAL_DOLARES As Double
    Private _SALDO_DOLARES As Double

    Private _CONCEPTO_CANCELACION As String
    Private _COSTO As Double

    Private _FECHA_ENTREGA As Date
    Private _ES_INVENTARIABLE As Boolean
    Private _ES_FISCAL As Boolean

    Private _FOLIO_REQUISICION As String

    Private _CODIGO_TIPO_ENVIO As Integer
    Private _NOMBRE_TRANSPORTE As String

    Private _ID_NOMINA_TEMPORADA As Integer
#End Region

#Region "Campos ligados a la tabla"
    Private _Existe As Boolean 'lectura
    Private _TIENE_SERIES As Boolean = False
#End Region

#Region "Campos públicos"
    Public oComprasDetalle As Class_Compras_Detalle
#End Region

#Region "Campos privados"
    Private _oDocumento As Class_CatDocumentos
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
    Public ReadOnly Property ID_COMPRA_GLOBAL() As Integer
        Get
            Return Me._ID_COMPRA_GLOBAL
        End Get
    End Property

    Public Property FOLIO_COMPRA() As String
        Get
            Return Me._FOLIO_COMPRA
        End Get
        Set(ByVal Value As String)
            Me._FOLIO_COMPRA = Value
        End Set
    End Property

    Public ReadOnly Property FOLIO_NUMERICO() As Integer
        Get
            Return Me._FOLIO_NUMERICO
        End Get
    End Property

    Public Property CODIGO_DOCUMENTO() As String
        Get
            Return Me._CODIGO_DOCUMENTO
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_DOCUMENTO = Value
        End Set
    End Property

    Public Property CODIGO_ALMACEN() As String
        Get
            Return Me._CODIGO_ALMACEN
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_ALMACEN = Value
        End Set
    End Property

    Public Property CODIGO_PLAZA() As Integer
        Get
            Return Me._CODIGO_PLAZA
        End Get
        Set(ByVal Value As Integer)
            Me._CODIGO_PLAZA = Value
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

    Public Property FECHA_FACTURA_PROVEEDOR() As Date
        Get
            Return Me._FECHA_FACTURA_PROVEEDOR
        End Get
        Set(ByVal Value As Date)
            Me._FECHA_FACTURA_PROVEEDOR = Value
        End Set
    End Property

    Public ReadOnly Property FECHA_SERVIDOR() As Date
        Get
            Return Me._FECHA_SERVIDOR
        End Get
    End Property

    Public Property FOLIO_OC() As String
        Get
            Return Me._FOLIO_OC
        End Get
        Set(ByVal Value As String)
            Me._FOLIO_OC = Value
        End Set
    End Property

    Public Property FOLIO_PROVEEDOR() As String
        Get
            Return Me._FOLIO_PROVEEDOR
        End Get
        Set(ByVal Value As String)
            Me._FOLIO_PROVEEDOR = Value
        End Set
    End Property

    Public Property CODIGO_PROVEEDOR() As String
        Get
            Return Me._CODIGO_PROVEEDOR
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_PROVEEDOR = Value
        End Set
    End Property

    Public Property PLAZO() As Integer
        Get
            Return Me._PLAZO
        End Get
        Set(ByVal Value As Integer)
            Me._PLAZO = Value
        End Set
    End Property

    Public Property FECHA_VENCIMIENTO() As Date
        Get
            Return Me._FECHA_VENCIMIENTO
        End Get
        Set(ByVal Value As Date)
            Me._FECHA_VENCIMIENTO = Value
        End Set
    End Property

    Public Property SUBTOTAL() As Double
        Get
            Return Me._SUBTOTAL
        End Get
        Set(ByVal Value As Double)
            Me._SUBTOTAL = Value
        End Set
    End Property

    Public Property IEPS_TOTAL_DESGLOSADO() As Double
        Get
            Return Me._IEPS_TOTAL_DESGLOSADO
        End Get
        Set(ByVal Value As Double)
            Me._IEPS_TOTAL_DESGLOSADO = Value
        End Set
    End Property

    Public Property IMPUESTO() As Double
        Get
            Return Me._IMPUESTO
        End Get
        Set(ByVal Value As Double)
            Me._IMPUESTO = Value
        End Set
    End Property

    Public Property TOTAL() As Double
        Get
            Return Me._TOTAL
        End Get
        Set(ByVal Value As Double)
            Me._TOTAL = Value
        End Set
    End Property

    Public Property RETENCION_IVA() As Double
        Get
            Return Me._RETENCION_IVA
        End Get
        Set(ByVal Value As Double)
            Me._RETENCION_IVA = Value
        End Set
    End Property

    Public Property RETENCION_ISR() As Double
        Get
            Return Me._RETENCION_ISR
        End Get
        Set(ByVal Value As Double)
            Me._RETENCION_ISR = Value
        End Set
    End Property

    Public ReadOnly Property SALDO() As Double
        Get
            Return Me._SALDO
        End Get
    End Property

    Public ReadOnly Property SALDO_IMPUESTO() As Double
        Get
            Return Me._SALDO_IMPUESTO
        End Get
    End Property

    Public Property TIPO_DE_CAMBIO() As Double
        Get
            Return Me._TIPO_DE_CAMBIO
        End Get
        Set(ByVal Value As Double)
            Me._TIPO_DE_CAMBIO = Value
        End Set
    End Property

    Public ReadOnly Property ESTATUS() As String
        Get
            Return Me._ESTATUS
        End Get
    End Property

    Public Property ENTREGAR_A() As String
        Get
            Return Me._ENTREGAR_A
        End Get
        Set(ByVal Value As String)
            Me._ENTREGAR_A = Value
        End Set
    End Property

    Public Property SOLICITO() As String
        Get
            Return Me._SOLICITO
        End Get
        Set(ByVal Value As String)
            Me._SOLICITO = Value
        End Set
    End Property

    Public Property CONCEPTO() As String
        Get
            Return Me._CONCEPTO
        End Get
        Set(ByVal Value As String)
            Me._CONCEPTO = Value
        End Set
    End Property

    Public Property CON_CARGO_A() As String
        Get
            Return Me._CON_CARGO_A
        End Get
        Set(ByVal Value As String)
            Me._CON_CARGO_A = Value
        End Set
    End Property

    Public Property PREDIO() As String
        Get
            Return Me._PREDIO
        End Get
        Set(ByVal Value As String)
            Me._PREDIO = Value
        End Set
    End Property

    Public Property CONFIRMO() As String
        Get
            Return Me._CONFIRMO
        End Get
        Set(ByVal Value As String)
            Me._CONFIRMO = Value
        End Set
    End Property

    Public ReadOnly Property FOLIO_POLIZA() As String
        Get
            Return Me._FOLIO_POLIZA
        End Get
    End Property

    Public Property CODIGO_USUARIO_GRABO() As Integer
        Get
            Return Me._CODIGO_USUARIO_GRABO
        End Get
        Set(ByVal Value As Integer)
            Me._CODIGO_USUARIO_GRABO = Value
        End Set
    End Property

    Public ReadOnly Property NOMBRE_USUARIO_GRABO() As String
        Get
            Return Me._NOMBRE_USUARIO_GRABO
        End Get
    End Property

    Public Property CODIGO_USUARIO_CANCELO() As Integer
        Get
            Return Me._CODIGO_USUARIO_CANCELO
        End Get
        Set(ByVal Value As Integer)
            Me._CODIGO_USUARIO_CANCELO = Value
        End Set
    End Property

    Public ReadOnly Property NOMBRE_USUARIO_CANCELO() As String
        Get
            Return Me._NOMBRE_USUARIO_CANCELO
        End Get
    End Property

    Public Property FECHA_CANCELACION() As Date
        Get
            Return Me._FECHA_CANCELACION
        End Get
        Set(ByVal Value As Date)
            Me._FECHA_CANCELACION = Value
        End Set
    End Property

    Public ReadOnly Property FECHA_CANCELACION_SERVIDOR() As Date
        Get
            Return Me._FECHA_CANCELACION_SERVIDOR
        End Get
    End Property

    Public Property IMPUESTO_PORCENTAJE() As Double
        Get
            Return Me._IMPUESTO_PORCENTAJE
        End Get
        Set(ByVal Value As Double)
            Me._IMPUESTO_PORCENTAJE = Value
        End Set
    End Property

    Public Property CONTRARECIBO_HECHO() As String
        Get
            Return Me._CONTRARECIBO_HECHO
        End Get
        Set(ByVal value As String)
            Me._CONTRARECIBO_HECHO = value
        End Set
    End Property

    Public ReadOnly Property FECHA_CONTRARECIBO() As Date
        Get
            Return Me._FECHA_CONTRARECIBO
        End Get
    End Property

    Public Property FECHA_PROGRAMACION() As Date
        Get
            Return Me._FECHA_PROGRAMACION
        End Get
        Set(ByVal value As Date)
            Me._FECHA_PROGRAMACION = value
        End Set
    End Property

    Public Property FOLIO_EMBARQUE() As String
        Get
            Return Me._FOLIO_EMBARQUE
        End Get
        Set(ByVal value As String)
            Me._FOLIO_EMBARQUE = value
        End Set
    End Property

    Public Property CODIGO_TIPO_GASTO() As String
        Get
            Return Me._CODIGO_TIPO_GASTO
        End Get
        Set(ByVal value As String)
            Me._CODIGO_TIPO_GASTO = value
        End Set
    End Property

    Public Property CODIGO_MONEDA As String
        Get
            Return Me._CODIGO_MONEDA
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_MONEDA = Value
        End Set
    End Property

    Public Property SUBTOTAL_USD As Double
        Get
            Return Me._SUBTOTAL_USD
        End Get
        Set(ByVal Value As Double)
            Me._SUBTOTAL_USD = Value
        End Set
    End Property

    Public Property IEPS_TOTAL_DESGLOSADO_USD As Double
        Get
            Return Me._IEPS_TOTAL_DESGLOSADO_USD
        End Get
        Set(ByVal Value As Double)
            Me._IEPS_TOTAL_DESGLOSADO_USD = Value
        End Set
    End Property

    Public Property IMPUESTO_USD As Double
        Get
            Return Me._IMPUESTO_USD
        End Get
        Set(ByVal Value As Double)
            Me._IMPUESTO_USD = Value
        End Set
    End Property

    Public Property RETENCION_IVA_USD As Double
        Get
            Return Me._RETENCION_IVA_USD
        End Get
        Set(ByVal Value As Double)
            Me._RETENCION_IVA_USD = Value
        End Set
    End Property

    Public Property RETENCION_ISR_USD As Double
        Get
            Return Me._RETENCION_ISR_USD
        End Get
        Set(ByVal Value As Double)
            Me._RETENCION_ISR_USD = Value
        End Set
    End Property

    Public Property TOTAL_DOLARES() As Double
        Get
            Return Me._TOTAL_DOLARES
        End Get
        Set(ByVal Value As Double)
            Me._TOTAL_DOLARES = Value
        End Set
    End Property

    Public Property SALDO_DOLARES() As Double
        Get
            Return Me._SALDO_DOLARES
        End Get
        Set(ByVal Value As Double)
            Me._SALDO_DOLARES = Value
        End Set
    End Property

    Public Property CONCEPTO_CANCELACION() As String
        Get
            Return Me._CONCEPTO_CANCELACION
        End Get
        Set(ByVal Value As String)
            Me._CONCEPTO_CANCELACION = Value
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

    Public Property FECHA_ENTREGA() As Date
        Get
            Return Me._FECHA_ENTREGA
        End Get
        Set(value As Date)
            Me._FECHA_ENTREGA = value
        End Set
    End Property

    Public Property ES_INVENTARIABLE() As Boolean
        Get
            Return Me._ES_INVENTARIABLE
        End Get
        Set(value As Boolean)
            Me._ES_INVENTARIABLE = value
        End Set
    End Property

    Public Property ES_FISCAL() As Boolean
        Get
            Return Me._ES_FISCAL
        End Get
        Set(value As Boolean)
            Me._ES_FISCAL = value
        End Set
    End Property

    Public Property FOLIO_REQUISICION() As String
        Get
            Return Me._FOLIO_REQUISICION
        End Get
        Set(value As String)
            Me._FOLIO_REQUISICION = value
        End Set
    End Property

    Public Property CODIGO_TIPO_ENVIO() As Integer
        Get
            Return Me._CODIGO_TIPO_ENVIO
        End Get
        Set(value As Integer)
            Me._CODIGO_TIPO_ENVIO = value
        End Set
    End Property

    Public Property NOMBRE_TRANSPORTE() As String
        Get
            Return Me._NOMBRE_TRANSPORTE
        End Get
        Set(value As String)
            Me._NOMBRE_TRANSPORTE = value
        End Set
    End Property

    Public Property ID_NOMINA_TEMPORADA() As Integer
        Get
            Return Me._ID_NOMINA_TEMPORADA
        End Get
        Set(value As Integer)
            Me._ID_NOMINA_TEMPORADA = value
        End Set
    End Property

#End Region

#Region "Propiedades de campos ligados a la tabla"
    Public ReadOnly Property Existe() As Boolean
        Get
            Return Me._Existe
        End Get
    End Property

    Public ReadOnly Property TIENE_SERIES() As Boolean
        Get
            Return Me._TIENE_SERIES
        End Get
    End Property
#End Region

#Region "Propiedades públicos"
    Public ReadOnly Property CODIGO_MODULO() As String
        Get
            Return "CMP"
        End Get
    End Property
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
    Public Sub New(ByVal sCodigoDocumento As String)
        Me._Nombre_Catalogo = "COMPRAS_GLOBAL"
        Me._Nombre_Reporte = "RPT_FORMATO_COMPRAS"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "SELECT G.*,U1.NOMBRE_USUARIO NOMBRE_USUARIO_GRABO,U2.NOMBRE_USUARIO NOMBRE_USUARIO_CANCELO, " &
        "ISNULL((SELECT TOP 1 '1' FROM COMPRA_DETALLE WHERE FOLIO_COMPRA=G.FOLIO_COMPRA AND LEN(LISTA_SERIES)>0),0) TIENE_SERIES " &
        "FROM COMPRA_GLOBAL G " &
        "INNER JOIN SIS_USUARIOS U1 ON(G.CODIGO_USUARIO_GRABO=U1.CODIGO_USUARIO) " &
        "LEFT JOIN SIS_USUARIOS U2 ON(G.CODIGO_USUARIO_CANCELO=U2.CODIGO_USUARIO) "
        Me._QueryOrder = " ORDER BY FOLIO_COMPRA"
        Me.oComprasDetalle = New Class_Compras_Detalle
        Me._CODIGO_DOCUMENTO = sCodigoDocumento
        Me._oDocumento = New Class_CatDocumentos(sCodigoDocumento)
    End Sub

    Public Sub New(ByVal sFolio As String, ByVal sCodigoDocumento As String)
        Me.New(sCodigoDocumento)
        Try
            Me._FOLIO_COMPRA = sFolio
            Me._CODIGO_DOCUMENTO = sCodigoDocumento
            If Me.Consultar = True Then
                Me._Existe = True
            End If
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "New", ex)
        End Try
    End Sub

    Public Sub New()
        Me._Nombre_Catalogo = "COMPRAS_GLOBAL"
        Me._Nombre_Reporte = "RPT_COMPRA.rpt"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "SELECT G.*,U1.NOMBRE_USUARIO NOMBRE_USUARIO_GRABO,U2.NOMBRE_USUARIO NOMBRE_USUARIO_CANCELO FROM COMPRA_GLOBAL G " &
        "INNER JOIN SIS_USUARIOS U1 ON(G.CODIGO_USUARIO_GRABO=U1.CODIGO_USUARIO) " &
        "LEFT JOIN SIS_USUARIOS U2 ON(G.CODIGO_USUARIO_CANCELO=U2.CODIGO_USUARIO) "
        Me._QueryOrder = " ORDER BY FOLIO_COMPRA"
        Me.oComprasDetalle = New Class_Compras_Detalle
    End Sub

    Protected Overrides Sub Finalize()
        'Me._Conexion.Dispose()
        MyBase.Finalize()
    End Sub
#End Region

#Region "Métodos y procedimientos"
    Public Function GrabarOrdenCompraGlobal(ByVal sAccion As String) As Boolean
        Const sProcedure As String = "GrabarOrdenCompraGlobal"
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_COMPRAS_GRABA_ORDEN_COMPRA_GLOBAL"

            sqlParametro = .Parameters.Add("@ACCION", SqlDbType.NVarChar, 15) : sqlParametro.Value = sAccion '"INSERTAR"  "ACTUALIZAR"
            sqlParametro = .Parameters.Add("@FOLIO_COMPRA", SqlDbType.NVarChar, 15) : sqlParametro.Value = "" & Me._FOLIO_COMPRA : sqlParametro.Direction = ParameterDirection.InputOutput
            sqlParametro = .Parameters.Add("@CODIGO_DOCUMENTO", SqlDbType.NVarChar, 10) : sqlParametro.Value = "" & Me._CODIGO_DOCUMENTO
            sqlParametro = .Parameters.Add("@CODIGO_ALMACEN", SqlDbType.NVarChar, 4) : sqlParametro.Value = "" & Me._CODIGO_ALMACEN
            sqlParametro = .Parameters.Add("@CODIGO_PLAZA", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_PLAZA
            sqlParametro = .Parameters.Add("@FECHA", SqlDbType.DateTime) : sqlParametro.Value = "" & Me._FECHA
            sqlParametro = .Parameters.Add("@CODIGO_PROVEEDOR", SqlDbType.NVarChar, 8) : sqlParametro.Value = "" & Me._CODIGO_PROVEEDOR
            sqlParametro = .Parameters.Add("@PLAZO", SqlDbType.Int) : sqlParametro.Value = Me._PLAZO
            sqlParametro = .Parameters.Add("@FECHA_VENCIMIENTO", SqlDbType.DateTime) : sqlParametro.Value = "" & Me._FECHA_VENCIMIENTO
            sqlParametro = .Parameters.Add("@SUBTOTAL", SqlDbType.Decimal) : sqlParametro.Value = Me._SUBTOTAL
            sqlParametro = .Parameters.Add("@IEPS_TOTAL_DESGLOSADO", SqlDbType.Decimal) : sqlParametro.Value = Me._IEPS_TOTAL_DESGLOSADO
            sqlParametro = .Parameters.Add("@IMPUESTO", SqlDbType.Decimal) : sqlParametro.Value = Me._IMPUESTO
            sqlParametro = .Parameters.Add("@TOTAL", SqlDbType.Decimal) : sqlParametro.Value = Me._TOTAL
            sqlParametro = .Parameters.Add("@RETENCION_IVA", SqlDbType.Decimal) : sqlParametro.Value = Me._RETENCION_IVA
            sqlParametro = .Parameters.Add("@RETENCION_ISR", SqlDbType.Decimal) : sqlParametro.Value = Me._RETENCION_ISR
            sqlParametro = .Parameters.Add("@IMPUESTO_PORCENTAJE", SqlDbType.Decimal) : sqlParametro.Value = Me._IMPUESTO_PORCENTAJE
            sqlParametro = .Parameters.Add("@TIPO_DE_CAMBIO", SqlDbType.Decimal) : sqlParametro.Value = Me.TIPO_DE_CAMBIO
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO_GRABO", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Usuario
            sqlParametro = .Parameters.Add("@ENTREGAR_A", SqlDbType.NVarChar, 80) : sqlParametro.Value = Me._ENTREGAR_A.ToUpper
            sqlParametro = .Parameters.Add("@SOLICITO", SqlDbType.NVarChar, 80) : sqlParametro.Value = Me._SOLICITO.ToUpper
            sqlParametro = .Parameters.Add("@CONCEPTO", SqlDbType.NVarChar, 1000) : sqlParametro.Value = Me._CONCEPTO.ToUpper
            sqlParametro = .Parameters.Add("@CON_CARGO_A", SqlDbType.NVarChar, 80) : sqlParametro.Value = Me._CON_CARGO_A.ToUpper
            sqlParametro = .Parameters.Add("@PREDIO", SqlDbType.NVarChar, 80) : sqlParametro.Value = Me._PREDIO.ToUpper
            sqlParametro = .Parameters.Add("@CONFIRMO", SqlDbType.NVarChar, 80) : sqlParametro.Value = Me._CONFIRMO.ToUpper
            sqlParametro = .Parameters.Add("@COSTO", SqlDbType.Decimal) : sqlParametro.Value = Me._COSTO
            sqlParametro = .Parameters.Add("@FECHA_ENTREGA", SqlDbType.DateTime) : sqlParametro.Value = "" & Me._FECHA_ENTREGA
            sqlParametro = .Parameters.Add("@CODIGO_MONEDA", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_MONEDA
            sqlParametro = .Parameters.Add("@SUBTOTAL_USD", SqlDbType.Decimal) : sqlParametro.Value = Me._SUBTOTAL_USD
            sqlParametro = .Parameters.Add("@IEPS_TOTAL_DESGLOSADO_USD", SqlDbType.Decimal) : sqlParametro.Value = Me._IEPS_TOTAL_DESGLOSADO_USD
            sqlParametro = .Parameters.Add("@IMPUESTO_USD", SqlDbType.Decimal) : sqlParametro.Value = Me._IMPUESTO_USD
            sqlParametro = .Parameters.Add("@TOTAL_DOLARES", SqlDbType.Decimal) : sqlParametro.Value = Me._TOTAL_DOLARES
            sqlParametro = .Parameters.Add("@RETENCION_IVA_USD", SqlDbType.Decimal) : sqlParametro.Value = Me._RETENCION_IVA_USD
            sqlParametro = .Parameters.Add("@RETENCION_ISR_USD", SqlDbType.Decimal) : sqlParametro.Value = Me._RETENCION_ISR_USD
            sqlParametro = .Parameters.Add("@ES_INVENTARIABLE", SqlDbType.Char, 1) : sqlParametro.Value = Convert.ToInt32(Me._ES_INVENTARIABLE)
            sqlParametro = .Parameters.Add("@FOLIO_REQUISICION", SqlDbType.NVarChar, 15) : sqlParametro.Value = "" & Me._FOLIO_REQUISICION
            sqlParametro = .Parameters.Add("@CODIGO_TIPO_ENVIO", SqlDbType.Int) : sqlParametro.Value = IIf(Me._CODIGO_TIPO_ENVIO > 0, Me._CODIGO_TIPO_ENVIO, DBNull.Value)
            sqlParametro = .Parameters.Add("@NOMBRE_TRANSPORTE", SqlDbType.NVarChar, 200) : sqlParametro.Value = "" & Me._NOMBRE_TRANSPORTE.ToUpper

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
                Me._FOLIO_COMPRA = "" & .Parameters("@FOLIO_COMPRA").Value.ToString
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

    Public Function GrabaCompraGlobal() As Boolean
        Const sProcedure As String = "GrabaCompraGlobal"
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_COMPRAS_GRABA_COMPRA_GLOBAL"

            sqlParametro = .Parameters.Add("@FOLIO_COMPRA", SqlDbType.NVarChar, 15) : sqlParametro.Value = "" & Me._FOLIO_COMPRA : sqlParametro.Direction = ParameterDirection.InputOutput
            sqlParametro = .Parameters.Add("@CODIGO_DOCUMENTO", SqlDbType.NVarChar, 10) : sqlParametro.Value = "" & Me._CODIGO_DOCUMENTO
            sqlParametro = .Parameters.Add("@CODIGO_ALMACEN", SqlDbType.NVarChar, 4) : sqlParametro.Value = "" & Me._CODIGO_ALMACEN
            sqlParametro = .Parameters.Add("@CODIGO_PLAZA", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_PLAZA
            sqlParametro = .Parameters.Add("@FECHA", SqlDbType.DateTime) : sqlParametro.Value = "" & Me._FECHA
            sqlParametro = .Parameters.Add("@FECHA_FACTURA_PROVEEDOR", SqlDbType.DateTime) : sqlParametro.Value = "" & Me._FECHA_FACTURA_PROVEEDOR
            sqlParametro = .Parameters.Add("@FOLIO_OC", SqlDbType.NVarChar, 15) : sqlParametro.Value = "" & Me._FOLIO_OC
            sqlParametro = .Parameters.Add("@FOLIO_PROVEEDOR", SqlDbType.NVarChar, 30) : sqlParametro.Value = "" & Me._FOLIO_PROVEEDOR
            sqlParametro = .Parameters.Add("@CODIGO_PROVEEDOR", SqlDbType.NVarChar, 8) : sqlParametro.Value = "" & Me._CODIGO_PROVEEDOR
            sqlParametro = .Parameters.Add("@PLAZO", SqlDbType.Int) : sqlParametro.Value = Me._PLAZO
            sqlParametro = .Parameters.Add("@FECHA_VENCIMIENTO", SqlDbType.DateTime) : sqlParametro.Value = "" & Me._FECHA_VENCIMIENTO
            sqlParametro = .Parameters.Add("@SUBTOTAL", SqlDbType.Decimal) : sqlParametro.Value = Me._SUBTOTAL
            sqlParametro = .Parameters.Add("@IEPS_TOTAL_DESGLOSADO", SqlDbType.Decimal) : sqlParametro.Value = Me._IEPS_TOTAL_DESGLOSADO
            sqlParametro = .Parameters.Add("@IMPUESTO", SqlDbType.Decimal) : sqlParametro.Value = Me._IMPUESTO
            sqlParametro = .Parameters.Add("@TOTAL", SqlDbType.Decimal) : sqlParametro.Value = Me._TOTAL
            sqlParametro = .Parameters.Add("@RETENCION_IVA", SqlDbType.Decimal) : sqlParametro.Value = Me._RETENCION_IVA
            sqlParametro = .Parameters.Add("@RETENCION_ISR", SqlDbType.Decimal) : sqlParametro.Value = Me._RETENCION_ISR
            sqlParametro = .Parameters.Add("@IMPUESTO_PORCENTAJE", SqlDbType.Decimal) : sqlParametro.Value = Me._IMPUESTO_PORCENTAJE
            sqlParametro = .Parameters.Add("@TIPO_DE_CAMBIO", SqlDbType.Decimal) : sqlParametro.Value = Me.TIPO_DE_CAMBIO
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO_GRABO", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Usuario
            sqlParametro = .Parameters.Add("@ES_COMPRA_SERVICIO", SqlDbType.Char, 1) : sqlParametro.Value = "0"
            sqlParametro = .Parameters.Add("@ENTREGAR_A", SqlDbType.NVarChar, 80) : sqlParametro.Value = Me._ENTREGAR_A.ToUpper
            sqlParametro = .Parameters.Add("@SOLICITO", SqlDbType.NVarChar, 80) : sqlParametro.Value = Me._SOLICITO.ToUpper
            sqlParametro = .Parameters.Add("@CONCEPTO", SqlDbType.NVarChar, 1000) : sqlParametro.Value = Me._CONCEPTO.ToUpper
            sqlParametro = .Parameters.Add("@CON_CARGO_A", SqlDbType.NVarChar, 80) : sqlParametro.Value = Me._CON_CARGO_A.ToUpper
            sqlParametro = .Parameters.Add("@PREDIO", SqlDbType.NVarChar, 80) : sqlParametro.Value = Me._PREDIO.ToUpper
            sqlParametro = .Parameters.Add("@CONFIRMO", SqlDbType.NVarChar, 80) : sqlParametro.Value = Me._CONFIRMO.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_TIPO_GASTO", SqlDbType.NVarChar, 80) : sqlParametro.Value = "2" 'CON ORDEN DE COMPRA
            sqlParametro = .Parameters.Add("@COSTO", SqlDbType.Decimal) : sqlParametro.Value = Me._COSTO
            sqlParametro = .Parameters.Add("@FECHA_ENTREGA", SqlDbType.DateTime) : sqlParametro.Value = "" & Me._FECHA_ENTREGA
            sqlParametro = .Parameters.Add("@CODIGO_MONEDA", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_MONEDA
            sqlParametro = .Parameters.Add("@SUBTOTAL_USD", SqlDbType.Decimal) : sqlParametro.Value = Me._SUBTOTAL_USD
            sqlParametro = .Parameters.Add("@IEPS_TOTAL_DESGLOSADO_USD", SqlDbType.Decimal) : sqlParametro.Value = Me._IEPS_TOTAL_DESGLOSADO_USD
            sqlParametro = .Parameters.Add("@IMPUESTO_USD", SqlDbType.Decimal) : sqlParametro.Value = Me._IMPUESTO_USD
            sqlParametro = .Parameters.Add("@TOTAL_DOLARES", SqlDbType.Decimal) : sqlParametro.Value = Me._TOTAL_DOLARES
            sqlParametro = .Parameters.Add("@RETENCION_IVA_USD", SqlDbType.Decimal) : sqlParametro.Value = Me._RETENCION_IVA_USD
            sqlParametro = .Parameters.Add("@RETENCION_ISR_USD", SqlDbType.Decimal) : sqlParametro.Value = Me._RETENCION_ISR_USD
            sqlParametro = .Parameters.Add("@ES_INVENTARIABLE", SqlDbType.Char, 1) : sqlParametro.Value = Convert.ToInt32(Me._ES_INVENTARIABLE)
            sqlParametro = .Parameters.Add("@ES_FISCAL", SqlDbType.Char, 1) : sqlParametro.Value = Convert.ToInt32(Me._ES_FISCAL)

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
                Me._FOLIO_COMPRA = "" & .Parameters("@FOLIO_COMPRA").Value.ToString
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

    Public Function GrabaCompraGlobalSinOrden(ByVal sListaCentrosCostos As String, ByVal sListaActivos As String) As Boolean
        Const sProcedure As String = "GrabaCompraGlobalSinOrden"
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_COMPRAS_GENERA_COMPRA_REVISION_CXP_SIN_ORDEN_COMPRA"

            sqlParametro = .Parameters.Add("@FOLIO_COMPRA", SqlDbType.NVarChar, 15) : sqlParametro.Value = "" & Me._FOLIO_COMPRA : sqlParametro.Direction = ParameterDirection.InputOutput
            sqlParametro = .Parameters.Add("@CODIGO_DOCUMENTO", SqlDbType.NVarChar, 10) : sqlParametro.Value = "" & Me._CODIGO_DOCUMENTO
            sqlParametro = .Parameters.Add("@CODIGO_ALMACEN", SqlDbType.NVarChar, 4) : sqlParametro.Value = "" & Me._CODIGO_ALMACEN
            sqlParametro = .Parameters.Add("@CODIGO_PLAZA", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_PLAZA
            sqlParametro = .Parameters.Add("@FECHA", SqlDbType.DateTime) : sqlParametro.Value = "" & Me._FECHA
            sqlParametro = .Parameters.Add("@FECHA_FACTURA_PROVEEDOR", SqlDbType.DateTime) : sqlParametro.Value = "" & Me._FECHA_FACTURA_PROVEEDOR
            sqlParametro = .Parameters.Add("@FOLIO_PROVEEDOR", SqlDbType.NVarChar, 30) : sqlParametro.Value = "" & Me._FOLIO_PROVEEDOR
            sqlParametro = .Parameters.Add("@CODIGO_PROVEEDOR", SqlDbType.NVarChar, 8) : sqlParametro.Value = "" & Me._CODIGO_PROVEEDOR
            sqlParametro = .Parameters.Add("@FECHA_VENCIMIENTO", SqlDbType.DateTime) : sqlParametro.Value = "" & Me._FECHA_VENCIMIENTO
            sqlParametro = .Parameters.Add("@SUBTOTAL", SqlDbType.Decimal) : sqlParametro.Value = Me._SUBTOTAL
            sqlParametro = .Parameters.Add("@IMPUESTO_DINERO", SqlDbType.Decimal) : sqlParametro.Value = Me._IMPUESTO
            sqlParametro = .Parameters.Add("@TOTAL", SqlDbType.Decimal) : sqlParametro.Value = Me._TOTAL
            sqlParametro = .Parameters.Add("@RETENCION_IVA", SqlDbType.Decimal) : sqlParametro.Value = Me._RETENCION_IVA
            sqlParametro = .Parameters.Add("@RETENCION_ISR", SqlDbType.Decimal) : sqlParametro.Value = Me._RETENCION_ISR
            sqlParametro = .Parameters.Add("@IMPUESTO_PORCENTAJE", SqlDbType.Decimal) : sqlParametro.Value = Me._IMPUESTO_PORCENTAJE
            sqlParametro = .Parameters.Add("@TIPO_DE_CAMBIO", SqlDbType.Decimal) : sqlParametro.Value = Me._TIPO_DE_CAMBIO
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO_GRABO", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Usuario
            sqlParametro = .Parameters.Add("@CONCEPTO", SqlDbType.NVarChar, 1000) : sqlParametro.Value = Me._CONCEPTO.ToUpper
            sqlParametro = .Parameters.Add("@FECHA_PROGRAMACION", SqlDbType.DateTime) : sqlParametro.Value = Me._FECHA_PROGRAMACION
            sqlParametro = .Parameters.Add("@FOLIO_EMBARQUE", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_EMBARQUE
            sqlParametro = .Parameters.Add("@LISTA_CENTROS_COSTOS", SqlDbType.NVarChar, 4000) : sqlParametro.Value = sListaCentrosCostos
            sqlParametro = .Parameters.Add("@LISTA_ACTIVOS", SqlDbType.NVarChar, 4000) : sqlParametro.Value = sListaActivos
            sqlParametro = .Parameters.Add("@ES_FISCAL", SqlDbType.Char, 1) : sqlParametro.Value = Convert.ToInt32(Me._ES_FISCAL)
            sqlParametro = .Parameters.Add("@ID_NOMINA_TEMPORADA", SqlDbType.SmallInt) : sqlParametro.Value = Me._ID_NOMINA_TEMPORADA

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
                Me._FOLIO_COMPRA = "" & .Parameters("@FOLIO_COMPRA").Value.ToString
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

    'Public Function AfectaInventarioCompra(ByVal sListaIDsDetalle As String, ByVal sListaSeries As String) As Boolean
    Public Function AfectaInventarioCompra() As Boolean
        Const sProcedure As String = "AfectaInventarioCompra"
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_INVENTARIOS_AFECTA_COMPRA"

            sqlParametro = .Parameters.Add("@FOLIO_COMPRA", SqlDbType.NVarChar, 15) : sqlParametro.Value = "" & Me._FOLIO_COMPRA
            'sqlParametro = .Parameters.Add("@LISTA_IDS", SqlDbType.NVarChar, -1) : sqlParametro.Value = sListaIDsDetalle
            'sqlParametro = .Parameters.Add("@LISTA_SERIES", SqlDbType.NVarChar, -1) : sqlParametro.Value = sListaSeries

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

    Public Function AfectaCantidadesDisponiblesOrdenCompra(ByVal bEsCancelacion As Boolean) As Boolean
        Const sProcedure As String = "AfectaCantidadesDisponiblesOrdenCompra"
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_COMPRAS_AFECTA_CANTIDADES_PENDIENTES_POR_RECIBIR_ORDEN_COMPRA"

            sqlParametro = .Parameters.Add("@FOLIO_COMPRA", SqlDbType.NVarChar, 15) : sqlParametro.Value = "" & Me._FOLIO_COMPRA
            sqlParametro = .Parameters.Add("@CANCELACION", SqlDbType.Char, 1) : sqlParametro.Value = Convert.ToInt32(bEsCancelacion)

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

    Public Function AfectaContabilidadCompra() As Boolean
        Const sProcedure As String = "AfectaContabilidadCompra"
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CONTABILIDAD_ASIENTO_REPETITIVO_COMPRA"

            sqlParametro = .Parameters.Add("@FOLIO_COMPRA", SqlDbType.NVarChar, 15) : sqlParametro.Value = "" & Me._FOLIO_COMPRA

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

    Public Function GeneraFolio() As String
        Dim sResultado As String = ""
        Try
            Me._oDocumento.GeneraFolio()
            sResultado = Me._oDocumento.FOLIO
            Me._FOLIO_COMPRA = _oDocumento.FOLIO
            Me._FOLIO_NUMERICO = CInt(_oDocumento.FOLIO_NUMERICO)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "GeneraFolio", ex)
        End Try
        Return sResultado
    End Function

    Public Function CancelaOrdenCompra() As Boolean
        Const sProcedure As String = "CancelaOrdenCompra"
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter

        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_COMPRA_CANCELA_ORDEN_COMPRA"

            sqlParametro = .Parameters.Add("@FOLIO_COMPRA", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me.FOLIO_COMPRA
            sqlParametro = .Parameters.Add("@CODIGO_PLAZA", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Plaza
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Usuario
            sqlParametro = .Parameters.Add("@FECHA_CANCELACION_COMPRA", SqlDbType.SmallDateTime) : sqlParametro.Value = Now
            sqlParametro = .Parameters.Add("@CONCEPTO_CANCELACION", SqlDbType.NVarChar, 1000) : sqlParametro.Value = Me._CONCEPTO_CANCELACION.ToUpper
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

    Public Function CancelaCompra() As Boolean
        Const sProcedure As String = "CancelaCompra"
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter

        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_COMPRAS_CANCELA_COMPRA"

            sqlParametro = .Parameters.Add("@FOLIO_COMPRA", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me.FOLIO_COMPRA
            sqlParametro = .Parameters.Add("@CODIGO_PLAZA", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Plaza
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO_CANCELO", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Usuario
            sqlParametro = .Parameters.Add("@FECHA_CANCELACION", SqlDbType.SmallDateTime) : sqlParametro.Value = Me.FECHA_CANCELACION
            sqlParametro = .Parameters.Add("@CONCEPTO_CANCELACION", SqlDbType.NVarChar, 1000) : sqlParametro.Value = Me._CONCEPTO_CANCELACION.ToUpper

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

    'Public Function AfectaRequisicionesOrdenCompra(Optional ByVal bCancelar As Boolean = False) As Boolean
    Public Function AfectaRequisicionesOrdenCompra(ByVal sAccion As String) As Boolean
        Const sProcedure As String = "AfectaRequisicionesOrdenCompra"
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter

        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            '.CommandText = "MP_COMPRAS_ORDEN_COMPRA_AFECTA_CANTIDADES_PENDIENTES_REQUISICIONES"
            .CommandText = "MP_COMPRAS_ORDEN_COMPRA_AFECTA_CANTIDADES_PENDIENTES_REQUISICIONES_POR_ARTICULO"

            sqlParametro = .Parameters.Add("@FOLIO_ORDEN_COMPRA", SqlDbType.NVarChar, 16) : sqlParametro.Value = Me.FOLIO_COMPRA
            sqlParametro = .Parameters.Add("@ACCION", SqlDbType.NVarChar, 20) : sqlParametro.Value = sAccion
            'sqlParametro = .Parameters.Add("@CANCELA", SqlDbType.Char) : sqlParametro.Value = IIf(bCancelar, "1", "0")

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

    Public Function Consultar() As Boolean
        Const sProcedure As String = "Consultar"
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand(Me._QuerySelect & " WHERE G.FOLIO_COMPRA='" & sReplace(Me._FOLIO_COMPRA) & "' AND CODIGO_DOCUMENTO='" & sReplace(Me._CODIGO_DOCUMENTO) & "'  AND G.CODIGO_PLAZA=" & Plaza.CODIGO_PLAZA & " ", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()
                If dReader.Read Then
                    Me._ID_COMPRA_GLOBAL = CInt(dReader("ID_COMPRA_GLOBAL"))
                    Me._FOLIO_COMPRA = dReader("FOLIO_COMPRA").ToString
                    Me._CODIGO_DOCUMENTO = dReader("CODIGO_DOCUMENTO").ToString
                    Me._CODIGO_ALMACEN = dReader("CODIGO_ALMACEN").ToString
                    Me._CODIGO_PLAZA = CInt(dReader("CODIGO_PLAZA"))
                    Me._FECHA = CDate(dReader("FECHA"))
                    If txtLEN(dReader("FECHA_FACTURA_PROVEEDOR").ToString) = True Then
                        Me._FECHA_FACTURA_PROVEEDOR = CDate(dReader("FECHA_FACTURA_PROVEEDOR"))
                    End If
                    If txtLEN(dReader("FECHA_PROGRAMACION").ToString) = True Then
                        Me._FECHA_PROGRAMACION = CDate(dReader("FECHA_PROGRAMACION"))
                    End If
                    Me._FECHA_SERVIDOR = CDate(dReader("FECHA_SERVIDOR"))
                    Me._FOLIO_OC = dReader("FOLIO_OC").ToString
                    Me._FOLIO_PROVEEDOR = dReader("FOLIO_PROVEEDOR").ToString
                    Me._CODIGO_PROVEEDOR = dReader("CODIGO_PROVEEDOR").ToString
                    Me._PLAZO = CInt(dReader("PLAZO"))
                    Me._FECHA_VENCIMIENTO = CDate(dReader("FECHA_VENCIMIENTO"))
                    Me._SUBTOTAL = CDbl(dReader("SUBTOTAL"))
                    Me._IEPS_TOTAL_DESGLOSADO = CDbl(dReader("IEPS_TOTAL_DESGLOSADO"))
                    Me._IMPUESTO = CDbl(dReader("IMPUESTO"))
                    Me._IMPUESTO_PORCENTAJE = CDbl(dReader("IMPUESTO_PORCENTAJE"))
                    Me._TOTAL = CDbl(dReader("TOTAL"))
                    Me._RETENCION_IVA = CDbl(dReader("RETENCION_IVA"))
                    Me._RETENCION_ISR = CDbl(dReader("RETENCION_ISR"))
                    Me._SALDO = CDbl(dReader("SALDO"))
                    Me._TIPO_DE_CAMBIO = CDbl(dReader("TIPO_DE_CAMBIO"))
                    Me._ESTATUS = dReader("ESTATUS").ToString
                    Me._ENTREGAR_A = dReader("ENTREGAR_A").ToString
                    Me._SOLICITO = dReader("SOLICITO").ToString
                    Me._CONCEPTO = dReader("CONCEPTO").ToString
                    Me._CON_CARGO_A = dReader("CON_CARGO_A").ToString
                    Me._PREDIO = dReader("PREDIO").ToString
                    Me._CONFIRMO = dReader("CONFIRMO").ToString
                    Me._FOLIO_POLIZA = "" & dReader("FOLIO_POLIZA").ToString
                    Me._CODIGO_USUARIO_GRABO = CInt(dReader("CODIGO_USUARIO_GRABO"))
                    Me._NOMBRE_USUARIO_GRABO = dReader("NOMBRE_USUARIO_GRABO").ToString
                    If Me._ESTATUS = "C" Then
                        Me._CODIGO_USUARIO_CANCELO = CInt(dReader("CODIGO_USUARIO_CANCELO"))
                        Me._NOMBRE_USUARIO_CANCELO = dReader("NOMBRE_USUARIO_CANCELO").ToString
                        Me._FECHA_CANCELACION = CDate(dReader("FECHA_CANCELACION"))
                        Me._FECHA_CANCELACION_SERVIDOR = CDate(dReader("FECHA_CANCELACION_SERVIDOR"))
                    End If
                    Me._FOLIO_EMBARQUE = dReader("FOLIO_EMBARQUE").ToString
                    Me._CODIGO_TIPO_GASTO = dReader("CODIGO_TIPO_GASTO").ToString
                    Me._SALDO_IMPUESTO = CDbl(dReader("SALDO_IMPUESTO"))
                    Me._CODIGO_MONEDA = dReader("CODIGO_MONEDA").ToString

                    Me._SUBTOTAL_USD = CDbl(dReader("SUBTOTAL_USD"))
                    Me._IEPS_TOTAL_DESGLOSADO_USD = CDbl(dReader("IEPS_TOTAL_DESGLOSADO_USD"))
                    Me._IMPUESTO_USD = CDbl(dReader("IMPUESTO_USD"))
                    Me._RETENCION_IVA_USD = CDbl(dReader("RETENCION_IVA_USD"))
                    Me._RETENCION_ISR_USD = CDbl(dReader("RETENCION_ISR_USD"))
                    Me._TOTAL_DOLARES = CDbl(dReader("TOTAL_DOLARES"))
                    Me._SALDO_DOLARES = CDbl(dReader("SALDO_DOLARES"))

                    Me._TIENE_SERIES = CBool(dReader("TIENE_SERIES"))
                    Me._CONCEPTO_CANCELACION = dReader("CONCEPTO_CANCELACION").ToString
                    Me._FECHA_ENTREGA = CDate(dReader("FECHA_ENTREGA"))

                    Me._ES_INVENTARIABLE = CBool(dReader("ES_INVENTARIABLE"))
                    Me._ES_FISCAL = CBool(dReader("ES_FISCAL"))

                    Me._FOLIO_REQUISICION = "" & dReader("FOLIO_REQUISICION").ToString

                    If txtLEN(dReader("CODIGO_TIPO_ENVIO").ToString) Then
                        Me._CODIGO_TIPO_ENVIO = CInt(dReader("CODIGO_TIPO_ENVIO"))
                    End If

                    Me._NOMBRE_TRANSPORTE = "" & dReader("NOMBRE_TRANSPORTE").ToString

                    Me._ID_NOMINA_TEMPORADA = CInt(dReader("ID_NOMINA_TEMPORADA"))

                    bResultado = True
                End If
                dReader.Close()
            Catch ex As Exception
                HandleError(Me.Nombre_Catalogo, sProcedure, ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
            End Try
        End With

        Return bResultado
    End Function

    Public Function ObtenerDetalle() As DataTable
        Dim dTabla As New DataTable("detalle"), da As SqlDataAdapter
        Dim sSQL As String

        'Las primeras 3 líneas construyen una tabla que nos trae al menos una cuenta del detalle para poder indicar que si tiene detalle, se hace así y no en el mismo select principal porque se tendria que andar agrupando y haciendo varios max
        sSQL = "With DC(ID_ADICIONAL, CUENTA_CONTABLE) " &
                "AS " &
                "(SELECT ID_ADICIONAL,MAX(CUENTA_CONTABLE) FROM CENTRO_COSTOS_MOVIMIENTOS_DETALLE WHERE FOLIO_MOVIMIENTO='" & Me._FOLIO_COMPRA & "' GROUP BY FOLIO_MOVIMIENTO,ID_ADICIONAL) " &
                "SELECT R.CODIGO_ARTICULO,R.DESCRIPCION,R.CANTIDAD,R.PRECIO,R.PRECIO_USD,R.COSTO,R.UNIDAD_VENTA,R.IMPUESTO_PORCENTAJE,R.IMPORTE,R.IMPORTE_USD,R.CUENTA_CONTABLE,R.IMPUESTO_IMPORTE,R.IMPUESTO_IMPORTE_USD,R.ID_COMPRA_DETALLE, " &
                "CASE WHEN DC.CUENTA_CONTABLE IS NOT NULL THEN 'Tiene detalle -->>' ELSE C.NOMBRE_CUENTA END NOMBRE_CUENTA, " &
                "'' Boton,R.ID_ADICIONAL, " &
                "R.IEPS_PORCENTAJE,R.IEPS_UNITARIO,R.IEPS_UNITARIO_USD,R.IEPS_IMPORTE,R.IEPS_IMPORTE_USD,R.BASE_IEPS,R.BASE_IEPS_USD,R.BASE_IVA,R.BASE_IVA_USD,R.ID_INVENTARIO_MOVIMIENTOS_DETALLE_ENTRADA,R.ID_REQUISICION_DETALLE,R.ES_REQUISICION " &
                "FROM COMPRA_DETALLE R " &
                "LEFT JOIN CON_CAT_CUENTAS C ON(R.CUENTA_CONTABLE=C.CUENTA_CONTABLE) " &
                "LEFT JOIN DC ON(R.ID_ADICIONAL=DC.ID_ADICIONAL) " &
                "WHERE R.FOLIO_COMPRA='" & Me._FOLIO_COMPRA & "' " &
                "ORDER BY R.ID_COMPRA_DETALLE " 'NOTA NO SE DEBE ORDENAR POR DESCRIPCION PORQUE NOS VA MOVER EL IDADICIONAL PARA LO DEL CENTRO DE COSTOS
        Try
            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dTabla)
            da.Dispose()
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "ObtenerDetalle", ex)
        End Try
        Return dTabla
    End Function

    Public Function ObtenerDetalleOrdenCompra() As DataTable
        Dim dTabla As New DataTable("detalle"), da As SqlDataAdapter
        Dim sSQL As String
        sSQL = "SELECT R.CODIGO_ARTICULO,R.DESCRIPCION,R.DISPONIBLE,R.PRECIO,R.PRECIO_USD,R.COSTO,R.UNIDAD_VENTA,R.IMPUESTO_PORCENTAJE,R.IMPORTE,R.IMPORTE_USD,R.CUENTA_CONTABLE,R.IMPUESTO_IMPORTE,R.IMPUESTO_IMPORTE_USD,R.ID_COMPRA_DETALLE, " &
            "'' NOMBRE_CUENTA,'' Boton,ROW_NUMBER() OVER(ORDER BY R.ID_COMPRA_DETALLE) ID_ADICIONAL, " &
            "R.IEPS_PORCENTAJE,R.IEPS_UNITARIO,R.IEPS_UNITARIO_USD,R.IEPS_IMPORTE,R.IEPS_IMPORTE_USD,R.BASE_IEPS,R.BASE_IEPS_USD,R.BASE_IVA,R.BASE_IVA_USD,R.ID_INVENTARIO_MOVIMIENTOS_DETALLE_ENTRADA,R.ID_REQUISICION_DETALLE,R.ES_REQUISICION " &
            "FROM COMPRA_DETALLE R " &
            "WHERE R.FOLIO_COMPRA='" & Me._FOLIO_COMPRA & "' " &
            "AND R.DISPONIBLE>0 " &
            "ORDER BY R.ID_COMPRA_DETALLE " 'NOTA NO SE DEBE ORDENAR POR DESCRIPCION PORQUE NOS VA MOVER EL IDADICIONAL PARA LO DEL CENTRO DE COSTOS
        Try
            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dTabla)
            da.Dispose()
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "ObtenerDetalleOrdenCompra", ex)
        End Try
        Return dTabla
    End Function

    Public Function ObtenerDetalleCostos() As DataTable
        Dim dTabla As New DataTable("detalle"), da As SqlDataAdapter
        Dim sSQL As String

        sSQL = "SELECT '' TIPO,R.CODIGO_CENTRO_COSTO,CC.NOMBRE_CENTRO_COSTO,R.CODIGO_CATEGORIA,CA.NOMBRE_CATEGORIA,R.CODIGO_CONCEPTO,CO.NOMBRE_CONCEPTO,R.IMPORTE,R.IVA_IMPORTE,R.RENTECION_IVA,R.RETENCION_ISR,R.IEPS,R.TOTAL," &
                "R.CUENTA_CONTABLE,R.UUID,'','','','',R.ID_CENTRO_COSTOS_MOVIMIENTOS_DETALLE " &
                "FROM CENTRO_COSTOS_MOVIMIENTOS_DETALLE R " &
                "INNER JOIN NOMINA_CAT_CENTROS_COSTOS CC ON(R.CODIGO_CENTRO_COSTO=CC.CODIGO_CENTRO_COSTO) " &
                "INNER JOIN CAT_CATEGORIAS CA ON(R.CODIGO_CATEGORIA=CA.CODIGO_CATEGORIA) " &
                "INNER JOIN CAT_CONCEPTOS CO ON(R.CODIGO_CONCEPTO=CO.CODIGO_CONCEPTO) " &
                "WHERE R.FOLIO_MOVIMIENTO='" & Me._FOLIO_COMPRA & "' " &
                "ORDER BY R.ID_CENTRO_COSTOS_MOVIMIENTOS_DETALLE "
        Try
            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dTabla)
            da.Dispose()
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "ObtenerDetalleCostos", ex)
        End Try
        Return dTabla
    End Function

    Public Function ObtenerDetalleGastosActivos() As DataTable
        Dim dTabla As New DataTable("detalle"), da As SqlDataAdapter
        Dim sSQL As String

        sSQL = "SELECT R.CUENTA_CONTABLE,DBO.FN_CONTABILIDAD_NOMBRE_CUENTA_NIVELES_COMPLETOS(R.CUENTA_CONTABLE) NOMBRE_CUENTA_NIVELES_COMPLETOS,R.IMPORTE,R.IVA_IMPORTE,R.IVA_IMPORTE,R.RENTECION_IVA,R.RETENCION_ISR,R.IEPS,R.TOTAL," &
                "R.UUID,'','','','',R.ID_GASTOS_DETALLE " &
                "FROM GASTOS_DETALLE R " &
                "LEFT JOIN CON_CAT_CUENTAS C ON(R.CUENTA_CONTABLE=C.CUENTA_CONTABLE) " &
                "WHERE R.FOLIO_MOVIMIENTO='" & Me._FOLIO_COMPRA & "' " &
                "ORDER BY R.ID_GASTOS_DETALLE"
        Try
            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dTabla)
            da.Dispose()
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "ObtenerDetalleGastosActivos", ex)
        End Try
        Return dTabla
    End Function

    Public Function ObtenerDetalleSeries() As DataTable
        Dim dTabla As New DataTable("detalle"), da As SqlDataAdapter
        Dim sSQL As String

        ''Nota en la consulta, la posición no importa(de todas formas no se grabó, depende del id inv detale finalmente)
        'sSQL = "SELECT 1 POSICION,I.CODIGO_ARTICULO,A.DESCRIPCION,I.NUMERO_SERIE " & _
        '    "FROM INVENTARIO_MOVIMIENTOS_DETALLE I " & _
        '    "INNER JOIN CAT_ARTICULOS A ON(I.CODIGO_ARTICULO=A.CODIGO_ARTICULO) " & _
        '    "WHERE I.FOLIO_MOVIMIENTO_INVENTARIO='" & Me._FOLIO_COMPRA & "' " & _
        '    "ORDER BY I.ID_INVENTARIO_MOVIMIENTOS_DETALLE"

        sSQL = "SELECT 1 POSICION,I.CODIGO_ARTICULO,A.DESCRIPCION,I.NUMERO_SERIE " &
        "FROM INVENTARIO_LOTES_COSTOS I " &
        "INNER JOIN CAT_ARTICULOS A ON(I.CODIGO_ARTICULO=A.CODIGO_ARTICULO) " &
        "WHERE I.FOLIO_MOVIMIENTO_INVENTARIO='" & Me._FOLIO_COMPRA & "' AND LEN(I.NUMERO_SERIE)>0  " &
        "ORDER BY I.ID_INVENTARIO_MOVIMIENTOS_DETALLE"

        Try
            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dTabla)
            da.Dispose()
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "ObtenerDetalleSeries", ex)
        End Try
        Return dTabla
    End Function

    Public Function ValidaExistencias() As Boolean
        Dim bResultado As Boolean = False
        Dim dTabla As DataTable
        'Dim sql As Class_find
        Dim sSQL As String, da As SqlDataAdapter
        Try
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''Primero evaluamos los artículos que no son seriados.
            sSQL = "SELECT I.CODIGO_ARTICULO,MAX(A.DESCRIPCION) DESCRIPCION,SUM(I.CANTIDAD) CANTIDAD,MAX(ALM.NOMBRE_ALMACEN) NOMBRE_ALMACEN " &
                "FROM INVENTARIO_MOVIMIENTOS_DETALLE I " &
                "INNER JOIN INVENTARIO_MOVIMIENTOS_GLOBAL G ON(I.FOLIO_MOVIMIENTO_INVENTARIO=G.FOLIO_MOVIMIENTO_INVENTARIO) " &
                "INNER JOIN INVENTARIO_LOTES_COSTOS L ON(I.ID_INVENTARIO_MOVIMIENTOS_DETALLE=L.ID_INVENTARIO_MOVIMIENTOS_DETALLE) " &
                "INNER JOIN CAT_ARTICULOS A ON(I.CODIGO_ARTICULO=A.CODIGO_ARTICULO) " &
                "LEFT JOIN INVENTARIO_EXISTENCIA_ARTICULOS E ON(I.CODIGO_ARTICULO=E.CODIGO_ARTICULO AND G.CODIGO_ALMACEN1=E.CODIGO_ALMACEN) " &
                "INNER JOIN CAT_ALMACENES ALM ON(G.CODIGO_ALMACEN1=ALM.CODIGO_ALMACEN) " &
                "WHERE I.FOLIO_MOVIMIENTO_INVENTARIO='" & Me._FOLIO_COMPRA & "' AND LEN(L.NUMERO_SERIE)=0 " &
                "GROUP BY I.CODIGO_ARTICULO " &
                "HAVING SUM(I.CANTIDAD)>ISNULL(MAX(E.EXISTENCIA),0) "

            dTabla = New DataTable("detalle")
            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dTabla)
            da.Dispose()

            For Each dRow As DataRow In dTabla.Rows
                MsgBox("No hay existencia suficiente del artículo " & dRow("DESCRIPCION").ToString & " en el almacén " & dRow("NOMBRE_ALMACEN").ToString & ".", MsgBoxStyle.Exclamation, Me.Nombre_Catalogo)
                Return False
            Next
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            'Luego los que si son seriados.
            sSQL = "SELECT I.CODIGO_ARTICULO,A.DESCRIPCION,I.CANTIDAD,C.NUMERO_SERIE " &
                "FROM INVENTARIO_MOVIMIENTOS_DETALLE I " &
                "INNER JOIN INVENTARIO_LOTES_COSTOS C ON(I.ID_INVENTARIO_MOVIMIENTOS_DETALLE=C.ID_INVENTARIO_MOVIMIENTOS_DETALLE) " &
                "INNER JOIN CAT_ARTICULOS A ON(I.CODIGO_ARTICULO=A.CODIGO_ARTICULO) " &
                "WHERE I.FOLIO_MOVIMIENTO_INVENTARIO='" & Me._FOLIO_COMPRA & "' AND LEN(C.NUMERO_SERIE)>0 AND C.CANTIDAD_ORIGINAL>C.CANTIDAD_DISPONIBLE"

            dTabla = New DataTable("detalle")
            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dTabla)
            da.Dispose()

            For Each dRow As DataRow In dTabla.Rows
                MsgBox("No hay existencia suficiente del artículo " & dRow("DESCRIPCION").ToString & " con el número de serie " & dRow("NUMERO_SERIE").ToString & ".", MsgBoxStyle.Exclamation, Me.Nombre_Catalogo)
                Return False
            Next
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            'Esta validación es simple protección para evitar que catexis quede negativo, digamos que un seriado tiene disp en costos, pero no en caexis
            'Esta validación es la validación base que ya existia para validar agrupando por artículos por si repiten renglones en el movimiento, se suman y se validan vs catexis

            sSQL = "SELECT I.CODIGO_ARTICULO,MAX(A.DESCRIPCION) DESCRIPCION,SUM(I.CANTIDAD) CANTIDAD,ISNULL(MAX(E.EXISTENCIA),0)EXISTENCIA,MAX(ALM.NOMBRE_ALMACEN) NOMBRE_ALMACEN " &
            "FROM INVENTARIO_MOVIMIENTOS_DETALLE I " &
            "INNER JOIN INVENTARIO_MOVIMIENTOS_GLOBAL G ON(I.FOLIO_MOVIMIENTO_INVENTARIO=G.FOLIO_MOVIMIENTO_INVENTARIO) " &
            "INNER JOIN CAT_ARTICULOS A ON(I.CODIGO_ARTICULO=A.CODIGO_ARTICULO) " &
            "LEFT JOIN INVENTARIO_EXISTENCIA_ARTICULOS E ON(I.CODIGO_ARTICULO=E.CODIGO_ARTICULO AND G.CODIGO_ALMACEN1=E.CODIGO_ALMACEN) " &
            "INNER JOIN CAT_ALMACENES ALM ON(G.CODIGO_ALMACEN1=ALM.CODIGO_ALMACEN) " &
            "WHERE I.FOLIO_MOVIMIENTO_INVENTARIO='" & Me._FOLIO_COMPRA & "'" &
            "GROUP BY I.CODIGO_ARTICULO " &
            "HAVING SUM(I.CANTIDAD)>ISNULL(MAX(E.EXISTENCIA),0) "

            dTabla = New DataTable("detalle")
            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dTabla)
            da.Dispose()

            For Each dRow As DataRow In dTabla.Rows
                MsgBox("No hay existencia suficiente del artículo " & dRow("DESCRIPCION").ToString & " en el almacén " & dRow("NOMBRE_ALMACEN").ToString & ".", MsgBoxStyle.Exclamation, Me.Nombre_Catalogo)
                Return False
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            'Dim oAlmacenes As New Class_CatAlmacenes(Me._CODIGO_ALMACEN)
            'dTabla = Me.ObtenerDetalleInventarios

            ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''Primero evaluamos los artículos que no son seriados.
            'sSQL = "SELECT CODIGO_ARTICULO,SUM(CANTIDAD) CANTIDAD FROM INVENTARIO_MOVIMIENTOS_DETALLE WHERE FOLIO_MOVIMIENTO_INVENTARIO='" & Me._FOLIO_COMPRA & "' AND LEN(NUMERO_SERIE)=0 GROUP BY CODIGO_ARTICULO "

            'dTabla = New DataTable("detalle")
            'da = New SqlDataAdapter(sSQL, Me._Conexion)
            'da.Fill(dTabla)
            'da.Dispose()

            'For Each dRow As DataRow In dTabla.Rows
            '    sql = New Class_find("SELECT EXISTENCIA FROM INVENTARIO_EXISTENCIA_ARTICULOS WHERE CODIGO_ARTICULO='" & dRow(0).ToString & "' AND CODIGO_ALMACEN='" & Me._CODIGO_ALMACEN & "' ")

            '    If CDbl(dRow("CANTIDAD")) > CDbl(sql.Result1) Then
            '        Dim oArticulos As New Class_CatArticulos(dRow(0).ToString)

            '        MsgBox("No hay existencia suficiente del artículo " & oArticulos.DESCRIPCION & " en el almacén " & oAlmacenes.Nombre_Almacen & ".", MsgBoxStyle.Exclamation, Me.Nombre_Catalogo)
            '        Return False
            '    End If
            'Next
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Luego los que si son seriados.
            'sSQL = "SELECT I.CODIGO_ARTICULO,A.DESCRIPCION,I.CANTIDAD,I.NUMERO_SERIE " & _
            '    "FROM INVENTARIO_MOVIMIENTOS_DETALLE I " & _
            '    "LEFT JOIN INVENTARIO_LOTES_COSTOS C ON(I.ID_INVENTARIO_MOVIMIENTOS_DETALLE=C.ID_INVENTARIO_MOVIMIENTOS_DETALLE) " & _
            '    "INNER JOIN CAT_ARTICULOS A ON(I.CODIGO_ARTICULO=A.CODIGO_ARTICULO) " & _
            '    "WHERE I.FOLIO_MOVIMIENTO_INVENTARIO='" & Me._FOLIO_COMPRA & "' AND LEN(I.NUMERO_SERIE)>0 AND I.CANTIDAD<>ISNULL(C.CANTIDAD_DISPONIBLE,0)"

            ''Tiene que estar al 100 el lote completo de toda la compra
            'sSQL = "SELECT C.CODIGO_ARTICULO,A.DESCRIPCION " & _
            '"FROM INVENTARIO_LOTES_COSTOS C " & _
            '"INNER JOIN CAT_ARTICULOS A ON(C.CODIGO_ARTICULO=A.CODIGO_ARTICULO) " & _
            '"WHERE C.FOLIO_MOVIMIENTO_INVENTARIO='" & Me._FOLIO_COMPRA & "' AND C.CANTIDAD_ORIGINAL<>C.CANTIDAD_DISPONIBLE " & _
            '"ORDER BY C.ID_INVENTARIO_LOTES_COSTOS"

            'dTabla = New DataTable("detalle")
            'da = New SqlDataAdapter(sSQL, Me._Conexion)
            'da.Fill(dTabla)
            'da.Dispose()

            'For Each dRow As DataRow In dTabla.Rows
            '    'MsgBox("No hay existencia suficiente del artículo " & dRow("DESCRIPCION").ToString & " con el número de serie" & dRow("NUMERO_SERIE").ToString & ".", MsgBoxStyle.Exclamation, Me.Nombre_Catalogo)
            '    MsgBox("No hay existencia suficiente del artículo " & dRow("DESCRIPCION").ToString & " del lote exacto de la compra.", MsgBoxStyle.Exclamation, Me.Nombre_Catalogo)
            '    Return False
            'Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            bResultado = True

        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "ValidaExistencias", ex)
        End Try

        Return bResultado
    End Function

    'Public Function ObtenerDetalleInventarios() As DataTable
    '    Dim dTabla As New DataTable("detalle"), da As SqlDataAdapter
    '    Dim sSQL As String

    '    sSQL = "SELECT CODIGO_ARTICULO,SUM(CANTIDAD) CANTIDAD FROM INVENTARIO_MOVIMIENTOS_DETALLE WHERE FOLIO_MOVIMIENTO_INVENTARIO='" & Me._FOLIO_COMPRA & "' GROUP BY CODIGO_ARTICULO "
    '    Try
    '        da = New SqlDataAdapter(sSQL, Me._Conexion)
    '        da.Fill(dTabla)
    '        da.Dispose()

    '    Catch ex As Exception
    '        HandleError(Me.Nombre_Catalogo, "ObtenerDetalleInventarios", ex)
    '    End Try
    '    Return dTabla
    'End Function

    Public Function BusquedaVisual_Compras() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de compras por folio."
        f.sCampo = "FOLIO_COMPRA"
        f.sOrder = "FECHA DESC"
        f.sTable = "COMPRA_GLOBAL"
        f.sQl = "SELECT G.FOLIO_COMPRA,G.FOLIO_OC,P.NOMBRE_PROVEEDOR,G.FECHA,G.ESTATUS FROM COMPRA_GLOBAL G " & _
        "INNER JOIN CAT_PROVEEDORES P ON(G.CODIGO_PROVEEDOR =P.CODIGO_PROVEEDOR) " & _
        "INNER JOIN VW_SIS_CAT_DOCUMENTOS_EXTENDIDO T ON(G.CODIGO_DOCUMENTO=T.CODIGO_DOCUMENTO) " & _
        "WHERE T.CODIGO_DOCUMENTO LIKE 'CO%' AND T.AFECTA_CONTABILIDAD='1' AND G.CODIGO_PLAZA=" & Plaza.CODIGO_PLAZA & " AND "

        f.Inicia("")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "BusquedaVisual_Compras", ex)
        End Try
        Return Resultado
    End Function

    Public Function BusquedaVisual_ComprasPorFolioOC() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de compras por folio de referencia."
        f.sCampo = "FOLIO_OC"
        f.sOrder = "FECHA DESC"
        f.sTable = "COMPRA_GLOBAL"
        f.sQl = "SELECT G.FOLIO_OC,G.FOLIO_COMPRA,P.NOMBRE_PROVEEDOR,G.FECHA,G.ESTATUS FROM COMPRA_GLOBAL G " & _
        "INNER JOIN CAT_PROVEEDORES P ON(G.CODIGO_PROVEEDOR =P.CODIGO_PROVEEDOR) " & _
        "INNER JOIN VW_SIS_CAT_DOCUMENTOS_EXTENDIDO T ON(G.CODIGO_DOCUMENTO=T.CODIGO_DOCUMENTO) " & _
        "WHERE T.CODIGO_DOCUMENTO LIKE 'CO%' AND T.AFECTA_CONTABILIDAD='1' AND G.CODIGO_PLAZA=" & Plaza.CODIGO_PLAZA & " AND "

        f.Inicia("")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 1), String)
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "BusquedaVisual_ComprasPorFolioOC", ex)
        End Try
        Return Resultado
    End Function

    Public Function BusquedaVisual_OrdenesCompra(Optional ByVal sEstatus As String = "") As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de compras por folio."
        f.sCampo = "FOLIO_COMPRA"
        f.sOrder = "FECHA DESC"
        f.sTable = "COMPRA_GLOBAL"
        f.sQl = "SELECT G.FOLIO_COMPRA,P.NOMBRE_PROVEEDOR,G.FECHA,G.ESTATUS FROM COMPRA_GLOBAL G " &
        "INNER JOIN CAT_PROVEEDORES P ON(G.CODIGO_PROVEEDOR =P.CODIGO_PROVEEDOR) " &
        "INNER JOIN VW_SIS_CAT_DOCUMENTOS_EXTENDIDO T ON(G.CODIGO_DOCUMENTO=T.CODIGO_DOCUMENTO) " &
        "WHERE T.CODIGO_DOCUMENTO LIKE 'OC%' AND T.AFECTA_CONTABILIDAD='0' AND G.CODIGO_PLAZA=" & Plaza.CODIGO_PLAZA & " AND "

        If txtLEN(sEstatus) = True Then
            f.sQl = f.sQl & " G.ESTATUS='" & sEstatus & "' AND "
        End If

        f.Inicia("")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "BusquedaVisual_OrdenesCompra", ex)
        End Try
        Return Resultado
    End Function

    Public Function BusquedaVisual_OrdenesCompraParaInventarios() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de compras por folio."
        f.sCampo = "FOLIO_COMPRA"
        f.sOrder = "FECHA ASC"
        f.sTable = "COMPRA_GLOBAL"

        'Solo trae las OC que tienen entradas con disponible 
        f.sQl = "SELECT C.FOLIO_COMPRA FOLIO_COMPRA,P.NOMBRE_PROVEEDOR,C.FECHA,C.ESTATUS " &
                "FROM COMPRA_GLOBAL C INNER JOIN CAT_PROVEEDORES P ON(C.CODIGO_PROVEEDOR=P.CODIGO_PROVEEDOR) " &
                "WHERE C.FOLIO_COMPRA IN(SELECT FOLIO_REFERENCIA FROM INVENTARIO_MOVIMIENTOS_GLOBAL G " &
                    "INNER JOIN INVENTARIO_MOVIMIENTOS_DETALLE D ON(G.FOLIO_MOVIMIENTO_INVENTARIO=D.FOLIO_MOVIMIENTO_INVENTARIO) " &
                    "WHERE G.CODIGO_TIPO_DOCUMENTO='ER' AND G.ESTA_CANCELADO='0' AND D.DISPONIBLE>0) " &
                "AND C.CODIGO_PLAZA=" & Plaza.CODIGO_PLAZA & " AND C.ESTATUS NOT IN('G','P','C') AND "

        f.Inicia("")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "BusquedaVisual_OrdenesCompraParaInventarios", ex)
        End Try
        Return Resultado
    End Function

    Public Function BusquedaVisual_FolioProveedor() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de compras por folio de proveedor."
        f.sCampo = "FOLIO_PROVEEDOR"
        f.sOrder = "FECHA"
        f.sTable = "COMPRA_GLOBAL"
        f.sQl = "SELECT G.FOLIO_COMPRA,P.NOMBRE_PROVEEDOR,G.FOLIO_PROVEEDOR,G.FECHA,G.ESTATUS,G.CODIGO_DOCUMENTO FROM COMPRA_GLOBAL G " & _
        "INNER JOIN CAT_PROVEEDORES P ON(G.CODIGO_PROVEEDOR =P.CODIGO_PROVEEDOR) " & _
        "INNER JOIN VW_SIS_CAT_DOCUMENTOS_EXTENDIDO T ON(G.CODIGO_DOCUMENTO=T.CODIGO_DOCUMENTO) " & _
        "WHERE T.CODIGO_DOCUMENTO LIKE 'CO%' AND T.AFECTA_CONTABILIDAD='1' AND G.CODIGO_PLAZA=" & Plaza.CODIGO_PLAZA & " AND "

        f.Inicia("")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "BusquedaVisual_FolioProveedor", ex)
        End Try
        Return Resultado
    End Function

    Public Function BusquedaVisualInventariables_PorDescripcion() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de Articulos por Descripción."
        f.sCampo = "Descripcion"
        f.sOrder = "Descripcion"
        f.sTable = "Cat_Articulos"
        f.sQl = "Select CODIGO_ARTICULO,Descripcion From Cat_Articulos Where 1=1 And Protegido=0 AND INVENTARIABLE='1' AND"
        f.Inicia("")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "BusquedaVisualInventariables_PorDescripcion", ex)
        End Try
        Return Resultado
    End Function

    Public Function ObtieneCodigoDocumentoOrdenCompra(ByVal sOrdenCompra As String) As String
        Dim Resultado As String = ""
        Try
            Dim sql As New Class_find("SELECT CODIGO_DOCUMENTO FROM COMPRA_GLOBAL WHERE FOLIO_COMPRA='" & sOrdenCompra & "' ")
            If sql.Result1 <> "" Then
                Resultado = sql.Result1
            End If
            sql = Nothing
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "ObtieneCodigoDocumentoOrdenCompra", ex)
        End Try
        Return Resultado
    End Function

    Public Function ValidaCantidadDisponibleArticulo(ByVal IDCompraDetalle As Integer, ByVal dCantidad As Double) As Boolean
        Dim dDisponible As String = ""
        Try
            Dim sql As New Class_find("SELECT DISPONIBLE FROM COMPRA_DETALLE WHERE ID_COMPRA_DETALLE=" & IDCompraDetalle)
            If txtLEN(sql.Result1) = True Then
                If dCantidad <= CDbl(sql.Result1) Then
                    Return True
                End If
            End If
            sql = Nothing
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "ValidaCantidadDisponibleArticulo", ex)
        End Try
    End Function

    Public Function ValidaCantidadDisponibleArticuloInventario(ByVal IdInventarioDetalle As Integer, ByVal dCantidad As Double) As Boolean
        Dim dDisponible As String = ""
        Try
            Dim sql As New Class_find("SELECT DISPONIBLE FROM INVENTARIO_MOVIMIENTOS_DETALLE WHERE ID_INVENTARIO_MOVIMIENTOS_DETALLE=" & IdInventarioDetalle)
            If txtLEN(sql.Result1) = True Then
                If dCantidad <= CDbl(sql.Result1) Then
                    Return True
                End If
            End If
            sql = Nothing
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "ValidaCantidadDisponibleArticuloInventario", ex)
        End Try
    End Function

    Public Function ValidaExistaIDCompraDetalle(ByVal IDCompraDetalle As Integer) As Boolean
        Dim dDisponible As String = ""
        Try
            Dim sql As New Class_find("SELECT 1 FROM COMPRA_DETALLE WHERE FOLIO_COMPRA='" & Me._FOLIO_COMPRA & "' AND ID_COMPRA_DETALLE=" & IDCompraDetalle)
            If txtLEN(sql.Result1) = True Then
                Return True
            End If
            sql = Nothing
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "ValidaExistaIDCompraDetalle", ex)
        End Try
    End Function

    Public Function ObtenerDisponibleArticulo(ByVal sIdArticulo As Integer) As Double
        Try
            Dim sql As New Class_find("SELECT DISPONIBLE FROM COMPRA_DETALLE WHERE ID_COMPRA_DETALLE=" & sIdArticulo)
            If sql.Result1 <> "" Then
                Return CDbl(sql.Result1)
            Else
                Return 0
            End If
            sql = Nothing
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "ObtenerDisponibleArticulo", ex)
        End Try
    End Function

    Public Function ObtenerDisponibleArticuloInventario(ByVal sIdArticulo As Integer) As Double
        Try
            Dim sql As New Class_find("SELECT DISPONIBLE FROM INVENTARIO_MOVIMIENTOS_DETALLE WHERE ID_COMPRA_DETALLE=" & sIdArticulo)
            If sql.Result1 <> "" Then
                Return CDbl(sql.Result1)
            Else
                Return 0
            End If
            sql = Nothing
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "ObtenerDisponibleArticuloInventario", ex)
        End Try
    End Function

    Public Function BuscarNombreUsuario(ByVal sCodigoUsuario As String) As String
        Dim Resultado As String = ""
        Try
            Dim sql As New Class_find("select NOMBRE_USUARIO from SIS_USUARIOS WHERE CODIGO_USUARIO ='" & sCodigoUsuario & "' ")
            If sql.Result1 <> "" Then
                Resultado = sql.Result1
            End If
            sql = Nothing
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "BuscarNombreUsuario", ex)
        End Try
        Return Resultado
    End Function

    'Public Function NaturalezaInventarios(ByVal sCodigoDocumento As String) As String
    '    Dim Resultado As String = ""
    '    Try
    '        Dim sql As New Class_find("SELECT NATURALEZA_INVENTARIOS FROM SIS_TIPOS_DOCUMENTOS WHERE CODIGO_TIPO_DOCUMENTO='" & sCodigoDocumento & "' ")
    '        If sql.Result1 <> "" Then
    '            Resultado = sql.Result1
    '        End If
    '        sql = Nothing
    '    Catch ex As Exception
    '        HandleError(Me.Nombre_Catalogo, "BuscarNaturalezaInventarios", ex)
    '    End Try
    '    Return Resultado
    'End Function

    Public Function AplicarPoliza() As Boolean
        Dim bResultado As Boolean = True
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CONTABILIDAD_ASIENTO_REPETITIVO_INVENTARIO_MOVIMIENTOS_GLOBAL"

            sqlParametro = .Parameters.Add("@FOLIO_MOVIMIENTO_INVENTARIO", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me.FOLIO_COMPRA.ToUpper
            'sqlParametro = .Parameters.Add("@CODIGO_USUARIO", SqlDbType.SmallInt) : sqlParametro.Value = "" & Me.CODIGO_USUARIO
            'sqlParametro = .Parameters.Add("@ID_EJERCICIO", SqlDbType.SmallInt) : sqlParametro.Value = Empresa_Sistema.ID_CON_EJERCICIO
            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "AplicarPoliza", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Function ActualizaFolioProveedor() As Boolean
        Dim bResultado As Boolean = True
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_COMRAS_ACTUALIZA_FOLIO_PROVEEDOR"

            sqlParametro = .Parameters.Add("@FOLIO_COMPRA", SqlDbType.NVarChar, 15) : sqlParametro.Value = "" & Me._FOLIO_COMPRA
            sqlParametro = .Parameters.Add("@FOLIO_PROVEEDOR", SqlDbType.NVarChar, 30) : sqlParametro.Value = "" & Me._FOLIO_PROVEEDOR

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "ActualizaFolioProveedor", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Function ActualizaDatosContraRecibos() As Boolean
        Dim bResultado As Boolean = True
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_COMPRAS_ACTUALIZA_DATOS_PROVEEDOR"

            sqlParametro = .Parameters.Add("@FOLIO_COMPRA", SqlDbType.NVarChar, 15) : sqlParametro.Value = "" & Me._FOLIO_COMPRA
            sqlParametro = .Parameters.Add("@FOLIO_PROVEEDOR", SqlDbType.NVarChar, 30) : sqlParametro.Value = "" & Me._FOLIO_PROVEEDOR
            sqlParametro = .Parameters.Add("@FECHA_FACTURA_PROVEEDOR", SqlDbType.DateTime) : sqlParametro.Value = Me._FECHA_FACTURA_PROVEEDOR
            sqlParametro = .Parameters.Add("@FECHA_PROGRAMACION", SqlDbType.DateTime) : sqlParametro.Value = Me._FECHA_PROGRAMACION

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "ActualizaDatosContraRecibos", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Function CargaComprashechasProveedor(ByVal CodigoProveedor As String, ByVal iTipoCompra As Integer, ByVal sCodigoAlmacen As String, ByVal bConSaldo As Boolean) As DataTable
        Dim dTabla As New DataTable("detalle"), da As SqlDataAdapter
        Dim sSaldo As String = ""
        If bConSaldo = True Then
            sSaldo = "AND SALDO<>0"
        End If
        Dim sSQL As String = ("SELECT FOLIO_COMPRA,FOLIO_OC,ISNULL(FOLIO_EMBARQUE,'') FOLIO_EMBARQUE,ISNULL(Convert(varchar(10),FECHA, 103),'') FECHA,ISNULL(Convert(varchar(10),FECHA_CONTRARECIBO, 103),'')," &
                              "ISNULL(Convert(varchar(10),FECHA_PROGRAMACION, 103),''), " &
                              "FOLIO_PROVEEDOR, ISNULL(Convert(varchar(10),FECHA_FACTURA_PROVEEDOR, 103),''),SALDO,SUBTOTAL,IMPUESTO,RETENCION_IVA,TOTAL,CONCEPTO,CODIGO_TIPO_GASTO,ISNULL(CONTRARECIBO_HECHO ,'0'),IMPUESTO_PORCENTAJE " &
                              "FROM COMPRA_GLOBAL " &
                              "WHERE CODIGO_PROVEEDOR='" & sReplace(CodigoProveedor) & "' AND CODIGO_PLAZA=" & Plaza.CODIGO_PLAZA & " AND CODIGO_TIPO_GASTO=" & iTipoCompra.ToString &
                              " AND CODIGO_ALMACEN='" & sCodigoAlmacen & "' " & sSaldo &
                              " ORDER BY CAST(FECHA AS DATETIME)")
        Try
            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dTabla)
            da.Dispose()
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "CargaComprashechasProveedor", ex)
        End Try
        Return dTabla
    End Function

    Public Function CargaComprashechas(ByVal CodigoProveedor As String, ByVal STipoCompra As String, ByVal sCodigoAlmacen As String, ByVal sAutorizados As String) As System.Data.DataTable
        Dim dt As New DataTable
        Try
            Dim da As New SqlDataAdapter("MP_COMPRAS_CON_SALDOS_CXP", Me._Conexion)
            da.SelectCommand.CommandType = CommandType.StoredProcedure

            With da.SelectCommand
                .Parameters.Add("@CODIGO_PLAZA", SqlDbType.SmallInt).Value = Usuario.Codigo_Plaza
                .Parameters.Add("@CODIGO_PROVEEDOR", SqlDbType.NVarChar, 8).Value = CodigoProveedor.ToString
                .Parameters.Add("@CODIGO_ALMACEN", SqlDbType.NVarChar, 4).Value = sCodigoAlmacen.ToString
                .Parameters.Add("@CODIGO_TIPO_GASTO", SqlDbType.NVarChar, 2).Value = IIf(STipoCompra.ToString = "0", "T", STipoCompra.ToString).ToString
                .Parameters.Add("@PAGOS_AUTORIZADOS", SqlDbType.NVarChar, 2).Value = sAutorizados.ToString
            End With

            da.Fill(dt)
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "CargaComprashechas", ex)
        End Try
        Return dt
    End Function

    Public Function ObtenerTiposGastos() As DataTable
        Dim dTabla As New DataTable("detalle"), da As SqlDataAdapter
        Dim sSQL As String = ("SELECT CODIGO_TIPO_GASTO,NOMBRE_TIPO_GASTO FROM COMPRAS_CAT_TIPOS_GASTOS ")
        Try
            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dTabla)
            da.Dispose()
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "ObtenerTiposGastos", ex)
        End Try
        Return dTabla
    End Function

    Public Function ObtenerTiposGastosParaRevision() As DataTable
        Dim dTabla As New DataTable("detalle"), da As SqlDataAdapter
        Dim sSQL As String = ("SELECT CODIGO_TIPO_GASTO,NOMBRE_TIPO_GASTO FROM COMPRAS_CAT_TIPOS_GASTOS where CODIGO_TIPO_GASTO<>4")
        'Dim sSQL As String = ("SELECT CODIGO_TIPO_GASTO,NOMBRE_TIPO_GASTO FROM COMPRAS_CAT_TIPOS_GASTOS")
        Try
            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dTabla)
            da.Dispose()
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "ObtenerTiposGastosParaRevision", ex)
        End Try
        Return dTabla
    End Function

    Public Sub NuevoRenglon()
        Me.oComprasDetalle = New Class_Compras_Detalle
    End Sub

    Public Function ListaComprasAplicaronOc(ByVal sFolioOC As String) As String
        Dim dTabla As New DataTable("detalle"), da As SqlDataAdapter, sResultado As String = ""
        Dim sSQL As String
        sSQL = "DECLARE @FOLIOS_COMPRAS NVARCHAR(500)='' " & _
        "SELECT @FOLIOS_COMPRAS=@FOLIOS_COMPRAS + FOLIO_COMPRA + ',' FROM COMPRA_GLOBAL WHERE FOLIO_OC='" & sReplace(sFolioOC) & "' " & _
        "SELECT @FOLIOS_COMPRAS FOLIOS_COMPRAS"
        Try
            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dTabla)
            If dTabla.Rows.Count > 0 Then
                sResultado = dTabla.Rows(0)(0).ToString
            End If
            da.Dispose()
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "ListaComprasAplicaronOc", ex)
        End Try
        Return sResultado
    End Function

    Public Function ActualizaConcepto() As Boolean
        Dim bResultado As Boolean = True
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_COMRAS_ACTUALIZA_CONCEPTO"

            sqlParametro = .Parameters.Add("@FOLIO_COMPRA", SqlDbType.NVarChar, 15) : sqlParametro.Value = "" & Me._FOLIO_COMPRA
            sqlParametro = .Parameters.Add("@CONCEPTO", SqlDbType.NVarChar, 1000) : sqlParametro.Value = "" & Me._CONCEPTO

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "ActualizaConcepto", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Function HaySeriesConExistenciasMismoArticulo(ByVal sListaSeries As String) As String
        Dim sResultado As String = ""
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_COMPRAS_VALIDA_HAY_EXISTENCIAS_SERIES_MISMOS_ARTICULOS"

            sqlParametro = .Parameters.Add("@LISTA", SqlDbType.NVarChar, -1) : sqlParametro.Value = sListaSeries
            sqlParametro = .Parameters.Add("@RESULTADO", SqlDbType.NVarChar, -1) : sqlParametro.Value = "" : sqlParametro.Direction = ParameterDirection.InputOutput

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                sResultado = "" & .Parameters("@RESULTADO").Value.ToString
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "HaySeriesConExistenciasMismoArticulo", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return sResultado
    End Function

    Public Function ObtenerDetalleDisponiblesParaDevolucion() As DataTable
        Dim dTabla As New DataTable("detalle"), da As SqlDataAdapter
        Dim sSQL As String

        Try

            sSQL = "SELECT R.CODIGO_ARTICULO, " &
            "CASE WHEN A.ES_SERIALIZABLE = '1' THEN 'SER' WHEN A.INVENTARIABLE= '1' THEN 'INV' ELSE 'NIV' END TIPO_CONTROL_INVENTARIO, " &
            "R.DESCRIPCION,R.DISPONIBLE,R.PRECIO,R.UNIDAD_VENTA,R.IMPUESTO_PORCENTAJE,R.IMPORTE," &
            "R.IMPUESTO_IMPORTE,R.ID_COMPRA_DETALLE," &
            "R.IEPS_PORCENTAJE,R.IEPS_UNITARIO,R.IEPS_IMPORTE,R.BASE_IEPS,R.BASE_IVA " &
            "FROM COMPRA_DETALLE R " &
            "INNER JOIN CAT_ARTICULOS A ON(R.CODIGO_ARTICULO=A.CODIGO_ARTICULO) " &
            "WHERE R.FOLIO_COMPRA='" & Me._FOLIO_COMPRA & "' AND R.DISPONIBLE>0 " &
            "ORDER BY R.ID_COMPRA_DETALLE "

            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dTabla)
            da.Dispose()

        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "ObtenerDetalleDisponiblesParaDevolucion", ex)
        End Try
        Return dTabla
    End Function

    Public Function ObtenerDisponibleRenglon(ByVal iIdArticulo As Integer) As Decimal
        Try
            Dim Disponible As New Class_find("SELECT DISPONIBLE FROM COMPRA_DETALLE WHERE ID_COMPRA_DETALLE=" & iIdArticulo.ToString)
            Return valorNumericoD(Disponible.Result1)
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "ObtenerDisponibleRenglon", ex)
        End Try
    End Function

    Public Sub Imprimir()
        Dim Rpt As New ReportDocument
        Dim oReporte As Class_Reporte
        Try
            oReporte = New Class_Reporte(Me.Nombre_Reporte, Rpt, False)
            If Not oReporte.RptCargado Then
                Exit Sub
            End If
            Rpt.SetParameterValue("@FOLIO_COMPRA", Me.FOLIO_COMPRA)

            Dim frm As New Reporte(Rpt)
            frm.CRViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            frm.ShowDialog()
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "Imprimir", ex)
        Finally
            oReporte = Nothing
        End Try
    End Sub

    Public Function UUID() As String
        Const sProcedure As String = "UUID"
        Dim sResultado As String = ""
        Try
            ''Selecciona el 1er uuid que tenga relacionadola compra partiendo primero de tipo I=Ingreso, y si no hay ingreso tomaria la 1era que encuentre de cualquier tipo
            'sResultado = New Class_find("SELECT TOP 1 RX.UUID FROM CONTABILIDAD_POLIZA_RELACION_XML RX " &
            '                                        "INNER JOIN EXPEDIENTES_BS..XML_REPOSITORIO_GLOBAL XRP ON(RX.UUID=XRP.UUID)" &
            '                                        "WHERE RX.FOLIO_POLIZA ='" & Me._FOLIO_COMPRA & "' " &
            '                                        "ORDER BY CASE WHEN XRP.TIPO_DE_COMPROBANTE='I' THEN 1 ELSE 2 END,RX.ID_POLIZA_RELACION_XML").Result1

            sResultado = New Class_find("SELECT TOP 1 RX.UUID FROM CONTABILIDAD_POLIZA_RELACION_XML RX " &
                                                    "INNER JOIN EXPEDIENTES_BS..XML_REPOSITORIO_GLOBAL XRP ON(RX.UUID=XRP.UUID)" &
                                                    "WHERE RX.FOLIO_POLIZA ='" & Me._FOLIO_COMPRA & "' " &
                                                    "AND XRP.TIPO_DE_COMPROBANTE='I'" &
                                                    "ORDER BY RX.ID_POLIZA_RELACION_XML").Result1

        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, sProcedure, ex)
        End Try

        Return sResultado
    End Function

    Public Function ObtieneEntradasOC(ByVal sFolioOrdenCompra As String) As DataTable
        Dim dTabla As New DataTable("detalle"), da As SqlDataAdapter
        Dim sSQL As String = ("SELECT G.FOLIO_MOVIMIENTO_INVENTARIO,DBO.FN_FORMAT_FECHA_CORTO(MAX(FECHA))FECHA " &
                              "FROM INVENTARIO_MOVIMIENTOS_GLOBAL G INNER JOIN INVENTARIO_MOVIMIENTOS_DETALLE D ON(G.FOLIO_MOVIMIENTO_INVENTARIO=D.FOLIO_MOVIMIENTO_INVENTARIO) " &
                              "WHERE CODIGO_TIPO_DOCUMENTO LIKE 'ER%' AND ESTA_CANCELADO='0' AND ESTATUS='A' AND FOLIO_REFERENCIA='" & sFolioOrdenCompra & "' " &
                              "AND D.DISPONIBLE > 0 GROUP BY G.FOLIO_MOVIMIENTO_INVENTARIO ORDER BY FECHA ")
        Try
            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dTabla)
            da.Dispose()
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "ObtieneEntradasOC", ex)
        End Try
        Return dTabla
    End Function

    Public Function ObtieneListadoEntradas() As DataTable
        Dim dTabla As New DataTable("detalle"), da As SqlDataAdapter
        Dim sSQL As String = ("SELECT R.FOLIO_MOVIMIENTO_INVENTARIO,DBO.FN_FORMAT_FECHA_CORTO(G.FECHA)FECHA,CASE WHEN G.ESTA_CANCELADO='1' THEN 'CANCELADO' ELSE 'ACTIVO' END ESTA_CANCELADO,G.COSTO_TOTAL_BASE,G.FLETE_TOTAL " &
                              "FROM COMPRAS_RELACION_ENTRADAS_INVENTARIOS R " &
                              "INNER JOIN INVENTARIO_MOVIMIENTOS_GLOBAL G ON(R.FOLIO_MOVIMIENTO_INVENTARIO=G.FOLIO_MOVIMIENTO_INVENTARIO)" &
                              "WHERE R.FOLIO_COMPRA='" & Me._FOLIO_COMPRA & "' " &
                              "ORDER BY R.ID")
        Try
            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dTabla)
            da.Dispose()
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "ObtieneListadoEntradas", ex)
        End Try
        Return dTabla
    End Function

    Public Function ObtieneListadoEntradasOrdenCompra() As DataTable
        Dim dTabla As New DataTable("detalle"), da As SqlDataAdapter
        Dim sSQL As String = ("SELECT G.FOLIO_MOVIMIENTO_INVENTARIO,DBO.FN_FORMAT_FECHA_CORTO(G.FECHA)FECHA,CASE WHEN G.ESTA_CANCELADO='1' THEN 'CANCELADO' ELSE 'ACTIVO' END ESTA_CANCELADO,G.COSTO_TOTAL_BASE,G.FLETE_TOTAL  " &
                              "FROM INVENTARIO_MOVIMIENTOS_GLOBAL G " &
                              "WHERE G.CODIGO_TIPO_DOCUMENTO='ER' AND G.FOLIO_REFERENCIA='" & Me._FOLIO_COMPRA & "' " &
                              "ORDER BY G.ID_INVENTARIO_MOVIMIENTOS_GLOBAL")
        Try
            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dTabla)
            da.Dispose()
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "ObtieneListadoEntradasOrdenCompra", ex)
        End Try
        Return dTabla
    End Function

    Public Function ObtenerDetalleDisponiblesOrdenCompra(ByVal sFolioOrdenCompra As String) As DataTable
        Dim dTabla As New DataTable("detalle")
        Dim sSQL As String

        Try
            sSQL = "SELECT R.CODIGO_ARTICULO,A.DESCRIPCION,R.DISPONIBLE CANTIDAD,R.PRECIO COSTO_DETALLE,R.IMPORTE,'' CUENTA_CONTABLE,'' NOMBRE_CUENTA, " &
                    "'' Boton,ROW_NUMBER() OVER(ORDER BY R.ID_COMPRA_DETALLE) ID_ADICIONAL,R.ID_COMPRA_DETALLE " &
                    "FROM COMPRA_DETALLE R  " &
                    "INNER JOIN CAT_ARTICULOS A ON(A.CODIGO_ARTICULO=R.CODIGO_ARTICULO)  " &
                    "WHERE R.FOLIO_COMPRA=@FOLIO_ORDEN_COMPRA AND R.DISPONIBLE>0 AND A.INVENTARIABLE='1' " &
                    "ORDER BY R.ID_COMPRA_DETALLE"

            Using da As New SqlDataAdapter(sSQL, Me._Conexion)
                da.SelectCommand.CommandType = CommandType.Text

                With da.SelectCommand
                    .Parameters.Add("@FOLIO_ORDEN_COMPRA", SqlDbType.NVarChar, 15).Value = sFolioOrdenCompra
                End With

                da.Fill(dTabla)
            End Using

        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "ObtenerDetalleDisponiblesOrdenCompra", ex)
        End Try

        Return dTabla
    End Function

    Public Function ObtieneEntradasAnterioresOrdenCompra(ByVal sFolioOrdenCompra As String) As DataTable
        Const sProcedure As String = "ObtieneEntradasAnterioresOrdenCompra"
        Dim dTabla As New DataTable("detalle")
        Dim sSQL As String

        Try
            sSQL = "SELECT FOLIO_MOVIMIENTO_INVENTARIO,FOLIO_MOVIMIENTO_INVENTARIO+','+DBO.FN_FORMAT_FECHA_CORTO(FECHA)+','+CASE WHEN ESTA_CANCELADO='1' THEN 'CANCELADO' ELSE 'ACTIVO' END INFORMACION " &
                "FROM INVENTARIO_MOVIMIENTOS_GLOBAL " &
                "WHERE CODIGO_TIPO_DOCUMENTO='ER' AND FOLIO_REFERENCIA=@FOLIO_ORDEN_COMPRA " &
                "ORDER BY FECHA"

            Using da As New SqlDataAdapter(sSQL, Me._Conexion)
                da.SelectCommand.CommandType = CommandType.Text

                With da.SelectCommand
                    .Parameters.Add("@FOLIO_ORDEN_COMPRA", SqlDbType.NVarChar, 15).Value = sFolioOrdenCompra
                End With

                da.Fill(dTabla)
            End Using

        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, sProcedure, ex)
        End Try

        Return dTabla
    End Function

    Public Function GrabaRelacionEntradaInventario(ByVal sFolioEntradaInventario As String) As Boolean
        Const sProcedure As String = "GrabaRelacionEntradaInventario"
        Dim bResultado As Boolean = True
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_COMPRAS_GRABA_RELACION_ENTRADA_INVENTARIO"

            sqlParametro = .Parameters.Add("@FOLIO_COMPRA", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_COMPRA
            sqlParametro = .Parameters.Add("@FOLIO_MOVIMIENTO_INVENTARIO", SqlDbType.NVarChar, 15) : sqlParametro.Value = sFolioEntradaInventario

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

    Public Function TieneDisponiblesIncompletos() As Boolean
        Const sProcedure As String = "TieneDisponiblesIncompletos"
        Dim bResultado As Boolean = False
        Try
            'Si tiene al menos un renglón donde su cantidad es diferentes al disponible, entonces esta incompleto.
            Dim oSQL As New Class_find("SELECT TOP 1 1 FROM COMPRA_DETALLE WHERE FOLIO_COMPRA='" & sReplace(Me._FOLIO_COMPRA) & "' AND CANTIDAD<>DISPONIBLE")
            If oSQL.Result1 = "1" Then
                bResultado = True
            End If
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, sProcedure, ex)
        End Try
        Return bResultado
    End Function
#End Region

End Class