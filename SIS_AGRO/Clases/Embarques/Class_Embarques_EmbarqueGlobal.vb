Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO

Public Class Class_Embarques_EmbarqueGlobal

#Region "Campos"

#Region "Campos de la tabla"
    Private _ID_EMB_EMBARQUE_GLOBAL As Integer
    Private _FOLIO_VIAJE As String
    Private _FOLIO_EMBARQUE As String
    Private _CODIGO_DOCUMENTO As String
    Private _CODIGO_MERCADO As String
    Private _ESTATUS_EMBARQUE As String
    Private _FOLIO_AARC As String
    Private _FECHA As Date
    Private _FECHA_SALIDA As Date
    Private _FECHA_ENTREGA As Date
    Private _FECHA_SERVIDOR As Date
    Private _CODIGO_DISTRIBUIDOR As String
    Private _CODIGO_EMBARCADOR As String
    Private _CODIGO_CLIENTE As String
    Private _CODIGO_TRANSPORTE As String
    Private _CODIGO_CHOFER As String
    Private _CODIGO_CAJA As String
    Private _OBSERVACIONES As String
    Private _CODIGO_ADUANA_EXTRANJERA As String
    Private _CODIGO_ADUANA_NACIONAL As String
    Private _TEMPERATURA As Double
    Private _SELLO As String
    Private _TOTAL_BULTOS As Integer
    Private _TOTAL_PESO As Double
    Private _TOTAL_DINERO As Double
    Private _CODIGO_USUARIO_GRABO As Integer
    Private _NOMBRE_USUARIO_GRABO As String
    Private _CODIGO_USUARIO_CANCELO As Integer
    Private _FECHA_CANCELACION As Date
    Private _NOMBRE_USUARIO_CANCELO As String
    Private _FECHA_CANCELACION_SERVIDOR As Date
    Private _FLETE_GENERADO As String
    Private _CODIGO_LUGAR_ENTREGA As Integer
    Private _SALIDA_EMPAQUE_GENERADA As String
    Private _IMPORTE_FLETE As Double
    Private _SALDO_FLETE As Double
    Private _CODIGO_ESTADO_DESTINO As String
    Private _FACTURA_GENERADA As Boolean
    Private _FLETE_IMPORTE As Double
    Private _CODIGO_ALMACEN As String
    Private _ENTRADA_ALMACEN_GENERADA As Boolean
    Private _FOLIO_ENTRADA_ALMACEN As String
    Private _FOLIO_VENTA As String
    Private _CODIGO_USUARIO_FACTURO As String
    Private _FOLIO_PEDIMENTO As String
    Private _CODIGO_EMPAQUE As String
#End Region

#Region "Campos ligados a la tabla"
    Private _Existe As Boolean 'lectura
    Private _CODIGO_TIPO_DOCUMENTO_FACTURA_EMBARQUE_EXTRANJERO As String
#End Region

#Region "Campos públicos"
    Public oEmbarqueDetalle As Class_Embarques_EmbarqueDetalle
#End Region

#Region "Campos privados"
    Private _oDocumento As Class_CatDocumentos
#End Region

#Region "Campos de sistema"
    Private _Nombre_Catalogo As String
    Private _Nombre_Formato As String
    Private _Nombre_Factura As String
    Private _Nombre_Manifiesto As String
    Private _Nombre_Control_Embarques As String
    Private _Conexion As SqlConnection
    Private _QuerySelect As String
    Private _QueryOrder As String
#End Region

#End Region

#Region "Propiedades"

#Region "Propiedades Campos de la tabla"
    Public Property FOLIO_VIAJE() As String
        Get
            Return Me._FOLIO_VIAJE
        End Get
        Set(ByVal Value As String)
            Me._FOLIO_VIAJE = Value
        End Set
    End Property

    Public Property FOLIO_EMBARQUE() As String
        Get
            Return Me._FOLIO_EMBARQUE
        End Get
        Set(ByVal Value As String)
            Me._FOLIO_EMBARQUE = Value
        End Set
    End Property

    Public Property ID_EMB_EMBARQUE_GLOBAL() As Integer
        Get
            Return Me._ID_EMB_EMBARQUE_GLOBAL
        End Get
        Set(ByVal Value As Integer)
            Me._ID_EMB_EMBARQUE_GLOBAL = Value
        End Set
    End Property

    Public Property CODIGO_DOCUMENTO() As String
        Get
            Return Me._CODIGO_DOCUMENTO
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_DOCUMENTO = Value
        End Set
    End Property

    Public Property CODIGO_MERCADO() As String
        Get
            Return Me._CODIGO_MERCADO
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_MERCADO = Value
        End Set
    End Property

    Public Property ESTATUS_EMBARQUE() As String
        Get
            Return Me._ESTATUS_EMBARQUE
        End Get
        Set(ByVal Value As String)
            Me._ESTATUS_EMBARQUE = Value
        End Set
    End Property

    Public Property FOLIO_AARC() As String
        Get
            Return Me._FOLIO_AARC
        End Get
        Set(ByVal Value As String)
            Me._FOLIO_AARC = Value
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

    Public Property FECHA_SALIDA() As Date
        Get
            Return Me._FECHA_SALIDA
        End Get
        Set(ByVal Value As Date)
            Me._FECHA_SALIDA = Value
        End Set
    End Property

    Public Property FECHA_ENTREGA() As Date
        Get
            Return Me._FECHA_ENTREGA
        End Get
        Set(ByVal Value As Date)
            Me._FECHA_ENTREGA = Value
        End Set
    End Property

    Public ReadOnly Property FECHA_SERVIDOR() As Date
        Get
            Return Me._FECHA_SERVIDOR
        End Get
    End Property

    Public Property CODIGO_DISTRIBUIDOR() As String
        Get
            Return Me._CODIGO_DISTRIBUIDOR
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_DISTRIBUIDOR = Value
        End Set
    End Property

    Public Property CODIGO_EMBARCADOR() As String
        Get
            Return Me._CODIGO_EMBARCADOR
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_EMBARCADOR = Value
        End Set
    End Property

    Public Property CODIGO_CLIENTE() As String
        Get
            Return Me._CODIGO_CLIENTE
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_CLIENTE = Value
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

    Public Property CODIGO_CHOFER() As String
        Get
            Return Me._CODIGO_CHOFER
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_CHOFER = Value
        End Set
    End Property

    Public Property CODIGO_CAJA() As String
        Get
            Return Me._CODIGO_CAJA
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_CAJA = Value
        End Set
    End Property

    Public Property OBSERVACIONES() As String
        Get
            Return Me._OBSERVACIONES
        End Get
        Set(ByVal Value As String)
            Me._OBSERVACIONES = Value
        End Set
    End Property

    Public Property CODIGO_ADUANA_EXTRANJERA() As String
        Get
            Return Me._CODIGO_ADUANA_EXTRANJERA
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_ADUANA_EXTRANJERA = Value
        End Set
    End Property

    Public Property CODIGO_ADUANA_NACIONAL() As String
        Get
            Return Me._CODIGO_ADUANA_NACIONAL
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_ADUANA_NACIONAL = Value
        End Set
    End Property

    Public Property TEMPERATURA() As Double
        Get
            Return Me._TEMPERATURA
        End Get
        Set(ByVal value As Double)
            Me._TEMPERATURA = value
        End Set
    End Property

    Public Property SELLO() As String
        Get
            Return Me._SELLO
        End Get
        Set(ByVal Value As String)
            Me._SELLO = Value
        End Set
    End Property

    Public Property TOTAL_BULTOS() As Integer
        Get
            Return Me._TOTAL_BULTOS
        End Get
        Set(ByVal value As Integer)
            Me._TOTAL_BULTOS = value
        End Set
    End Property

    Public Property TOTAL_PESO() As Double
        Get
            Return Me._TOTAL_PESO
        End Get
        Set(ByVal value As Double)
            Me._TOTAL_PESO = value
        End Set
    End Property

    Public Property TOTAL_DINERO() As Double
        Get
            Return Me._TOTAL_DINERO
        End Get
        Set(ByVal value As Double)
            Me._TOTAL_DINERO = value
        End Set
    End Property

    Public Property CODIGO_USUARIO_GRABO() As Integer
        Get
            Return Me._CODIGO_USUARIO_GRABO
        End Get
        Set(ByVal value As Integer)
            Me._CODIGO_USUARIO_GRABO = value
        End Set
    End Property

    Public Property NOMBRE_USUARIO_GRABO() As String
        Get
            Return Me._NOMBRE_USUARIO_GRABO
        End Get
        Set(ByVal value As String)
            Me._NOMBRE_USUARIO_GRABO = value
        End Set
    End Property

    Public Property CODIGO_USUARIO_CANCELO() As Integer
        Get
            Return Me._CODIGO_USUARIO_CANCELO
        End Get
        Set(ByVal value As Integer)
            Me._CODIGO_USUARIO_CANCELO = value
        End Set
    End Property

    Public Property NOMBRE_USUARIO_CANCELO() As String
        Get
            Return Me._NOMBRE_USUARIO_CANCELO
        End Get
        Set(ByVal value As String)
            Me._NOMBRE_USUARIO_CANCELO = value
        End Set
    End Property

    Public Property FECHA_CANCELACION() As Date
        Get
            Return Me._FECHA_CANCELACION
        End Get
        Set(ByVal Value As Date)
            Me._FECHA_CANCELACION = Value
        End Set
    End Property

    Public Property FLETE_GENERADO() As String
        Get
            Return Me._FLETE_GENERADO
        End Get
        Set(ByVal value As String)
            Me._FLETE_GENERADO = value
        End Set
    End Property

    Public Property CODIGO_LUGAR_ENTREGA() As Integer
        Get
            Return Me._CODIGO_LUGAR_ENTREGA
        End Get
        Set(ByVal value As Integer)
            Me._CODIGO_LUGAR_ENTREGA = value
        End Set
    End Property

    Public Property SALIDA_EMPAQUE_GENERADA() As String
        Get
            Return Me._SALIDA_EMPAQUE_GENERADA
        End Get
        Set(ByVal value As String)
            Me._SALIDA_EMPAQUE_GENERADA = value
        End Set
    End Property

    Public Property IMPORTE_FLETE() As Double
        Get
            Return Me._IMPORTE_FLETE
        End Get
        Set(ByVal value As Double)
            Me._IMPORTE_FLETE = value
        End Set
    End Property

    Public Property SALDO_FLETE() As Double
        Get
            Return Me._SALDO_FLETE
        End Get
        Set(ByVal value As Double)
            Me._SALDO_FLETE = value
        End Set
    End Property

    Public Property CODIGO_ESTADO_DESTINO() As String
        Get
            Return Me._CODIGO_ESTADO_DESTINO
        End Get
        Set(ByVal value As String)
            Me._CODIGO_ESTADO_DESTINO = value
        End Set
    End Property

    Public ReadOnly Property FACTURA_GENERADA() As Boolean
        Get
            Return Me._FACTURA_GENERADA
        End Get
    End Property

    Public ReadOnly Property FOLIO_VENTA() As String
        Get
            Return Me._FOLIO_VENTA
        End Get
    End Property

    Public Property FLETE_IMPORTE() As Double
        Get
            Return Me._FLETE_IMPORTE
        End Get
        Set(ByVal value As Double)
            Me._FLETE_IMPORTE = value
        End Set
    End Property

    Public Property CODIGO_ALMACEN As String
        Get
            Return Me._CODIGO_ALMACEN
        End Get
        Set(ByVal value As String)
            Me._CODIGO_ALMACEN = value
        End Set
    End Property

    Public ReadOnly Property ENTRADA_ALMACEN_GENERADA As Boolean
        Get
            Return Me._ENTRADA_ALMACEN_GENERADA
        End Get
    End Property

    Public ReadOnly Property FOLIO_ENTRADA_ALMACEN As String
        Get
            Return Me._FOLIO_ENTRADA_ALMACEN
        End Get
    End Property

    Public Property CODIGO_USUARIO_FACTURO() As String
        Get
            Return Me._CODIGO_USUARIO_FACTURO
        End Get
        Set(value As String)
            Me._CODIGO_USUARIO_FACTURO = value
        End Set
    End Property

    Public Property FOLIO_PEDIMENTO() As String
        Get
            Return Me._FOLIO_PEDIMENTO
        End Get
        Set(value As String)
            Me._FOLIO_PEDIMENTO = value
        End Set
    End Property

    Public Property CODIGO_EMPAQUE() As String
        Get
            Return Me._CODIGO_EMPAQUE
        End Get
        Set(value As String)
            Me._CODIGO_EMPAQUE = value
        End Set
    End Property

#End Region

#Region "Propiedades de campos ligados a la tabla"
    Public ReadOnly Property Existe() As Boolean
        Get
            Return Me._Existe
        End Get
    End Property
    Public ReadOnly Property CODIGO_TIPO_DOCUMENTO_FACTURA_EMBARQUE_EXTRANJERO As String
        Get
            Return Me._CODIGO_TIPO_DOCUMENTO_FACTURA_EMBARQUE_EXTRANJERO
        End Get
    End Property
#End Region

#Region "Propiedades públicos"
    Public ReadOnly Property CODIGO_MODULO() As String
        Get
            Return "EMB"
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

    Public Property Nombre_Formato() As String
        Get
            Return Me._Nombre_Formato
        End Get
        Set(ByVal value As String)
            Me._Nombre_Formato = value
        End Set
    End Property

    Public Property Nombre_Factura() As String
        Get
            Return Me._Nombre_Factura
        End Get
        Set(ByVal value As String)
            Me._Nombre_Factura = value
        End Set
    End Property

    Public Property Nombre_Manifiesto() As String
        Get
            Return Me._Nombre_Manifiesto
        End Get
        Set(ByVal value As String)
            Me._Nombre_Manifiesto = value
        End Set
    End Property

    Public Property Nombre_Control_Embarques() As String
        Get
            Return Me._Nombre_Control_Embarques
        End Get
        Set(ByVal value As String)
            Me._Nombre_Control_Embarques = value
        End Set
    End Property

#End Region

#End Region

#Region "Constructor y destructor"
    Public Sub New(ByVal sCodigoDocumento As String)
        Me.New()

        Me._CODIGO_DOCUMENTO = sCodigoDocumento
        Me._oDocumento = New Class_CatDocumentos(sCodigoDocumento)
    End Sub

    Public Sub New(ByVal sFolio As String, ByVal sCodigoDocumento As String)
        Me.New(sCodigoDocumento)
        Try
            Me._FOLIO_EMBARQUE = sFolio
            Me._CODIGO_DOCUMENTO = sCodigoDocumento
            If Me.Consultar = True Then
                Me._Existe = True
            End If
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "New", ex)
        End Try
    End Sub

    Public Sub New(ByVal sFolio As String, Optional ByVal bVacio As Boolean = True)
        Me.New()
        Try
            Me._FOLIO_EMBARQUE = sFolio
            If Me.Consultar = True Then
                Me._Existe = True
            End If
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "New", ex)
        End Try
    End Sub

    Public Sub New()
        Me._Nombre_Catalogo = "EMB_EMBARQUE_GLOBAL"
        Me._Nombre_Formato = "RPT_FORMATO_EMBARQUES_CARTA_RESPONSIVA"
        Me._Nombre_Factura = "RPT_FORMATO_EMBARQUES_FACTURA"
        Me._Nombre_Manifiesto = "RPT_FORMATO_EMBARQUES_MANIFIESTO"
        Me._Nombre_Control_Embarques = "RPT_FORMATO_EMBARQUES_DISTRIBUCION_CARGA"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "SELECT G.*,U1.NOMBRE_USUARIO NOMBRE_USUARIO_GRABO,U2.NOMBRE_USUARIO NOMBRE_USUARIO_CANCELO,VD.ES_FACTURA_EMBARQUE_EXTRANJERO, " &
        "VD.CODIGO_TIPO_DOCUMENTO_FACTURA_EMBARQUE_EXTRANJERO " &
        "FROM EMB_EMBARQUE_GLOBAL G " &
        "INNER JOIN SIS_USUARIOS U1 ON(G.CODIGO_USUARIO_GRABO=U1.CODIGO_USUARIO) " &
        "LEFT JOIN SIS_USUARIOS U2 ON(G.CODIGO_USUARIO_CANCELO=U2.CODIGO_USUARIO) " &
        "INNER JOIN VW_SIS_CAT_DOCUMENTOS_EXTENDIDO VD ON(G.CODIGO_DOCUMENTO=VD.CODIGO_DOCUMENTO)"
        Me._QueryOrder = " ORDER BY FOLIO_EMBARQUE "
        Me.oEmbarqueDetalle = New Class_Embarques_EmbarqueDetalle
    End Sub

    Protected Overrides Sub Finalize()
        'Me._Conexion.Dispose()
        MyBase.Finalize()
    End Sub
#End Region

#Region "Métodos y procedimientos"

    Public Function Actualizar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_EMB_EMBARQUE_GRABA_GLOBAL"

            sqlParametro = .Parameters.Add("@FOLIO_EMBARQUE ", SqlDbType.NVarChar, 15) : sqlParametro.Value = "" & Me._FOLIO_EMBARQUE
            sqlParametro = .Parameters.Add("@CODIGO_DOCUMENTO", SqlDbType.NVarChar, 10) : sqlParametro.Value = "" & Me._CODIGO_DOCUMENTO
            sqlParametro = .Parameters.Add("@CODIGO_MERCADO", SqlDbType.Char, 1) : sqlParametro.Value = "" & Me._CODIGO_MERCADO
            sqlParametro = .Parameters.Add("@FOLIO_AARC", SqlDbType.NVarChar, 8) : sqlParametro.Value = Me._FOLIO_AARC
            sqlParametro = .Parameters.Add("@CODIGO_PLAZA", SqlDbType.SmallInt) : sqlParametro.Value = Plaza.CODIGO_PLAZA
            sqlParametro = .Parameters.Add("@FECHA", SqlDbType.DateTime) : sqlParametro.Value = "" & Me._FECHA
            sqlParametro = .Parameters.Add("@FECHA_SALIDA", SqlDbType.DateTime) : sqlParametro.Value = "" & Me._FECHA_SALIDA
            sqlParametro = .Parameters.Add("@FECHA_ENTREGA", SqlDbType.DateTime) : sqlParametro.Value = "" & Me._FECHA_ENTREGA
            sqlParametro = .Parameters.Add("@CODIGO_DISTRIBUIDOR", SqlDbType.NVarChar, 8) : sqlParametro.Value = "" & Me._CODIGO_DISTRIBUIDOR
            'sqlParametro = .Parameters.Add("@CODIGO_PRODUCTOR", SqlDbType.NVarChar, 8) : sqlParametro.Value = "" & Me._CODIGO_PRODUCTOR
            sqlParametro = .Parameters.Add("@CODIGO_EMBARCADOR", SqlDbType.NVarChar, 8) : sqlParametro.Value = "" & Me._CODIGO_EMBARCADOR
            sqlParametro = .Parameters.Add("@CODIGO_CLIENTE", SqlDbType.NVarChar, 8) : sqlParametro.Value = "" & Me._CODIGO_CLIENTE
            sqlParametro = .Parameters.Add("@CODIGO_TRANSPORTE", SqlDbType.NVarChar, 8) : sqlParametro.Value = "" & Me._CODIGO_TRANSPORTE
            sqlParametro = .Parameters.Add("@CODIGO_CHOFER", SqlDbType.NVarChar, 8) : sqlParametro.Value = "" & Me._CODIGO_CHOFER
            sqlParametro = .Parameters.Add("@CODIGO_CAJA", SqlDbType.NVarChar, 8) : sqlParametro.Value = "" & Me._CODIGO_CAJA
            sqlParametro = .Parameters.Add("@OBSERVACIONES", SqlDbType.NVarChar, 200) : sqlParametro.Value = Me._OBSERVACIONES.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_ADUANA_EXTRANJERA", SqlDbType.NVarChar, 8) : sqlParametro.Value = Me._CODIGO_ADUANA_EXTRANJERA
            sqlParametro = .Parameters.Add("@CODIGO_ADUANA_NACIONAL", SqlDbType.NVarChar, 8) : sqlParametro.Value = Me._CODIGO_ADUANA_NACIONAL
            sqlParametro = .Parameters.Add("@TEMPERATURA", SqlDbType.Money) : sqlParametro.Value = Me._TEMPERATURA
            sqlParametro = .Parameters.Add("@SELLO", SqlDbType.NVarChar, 30) : sqlParametro.Value = Me._SELLO.ToUpper
            sqlParametro = .Parameters.Add("@TOTAL_PESO", SqlDbType.Money) : sqlParametro.Value = Me._TOTAL_PESO
            sqlParametro = .Parameters.Add("@TOTAL_DINERO", SqlDbType.Money) : sqlParametro.Value = Me._TOTAL_DINERO
            sqlParametro = .Parameters.Add("@TOTAL_BULTOS", SqlDbType.Int) : sqlParametro.Value = Me._TOTAL_BULTOS
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO_GRABO", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Usuario
            sqlParametro = .Parameters.Add("@CODIGO_LUGAR_ENTREGA", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_LUGAR_ENTREGA
            sqlParametro = .Parameters.Add("@CODIGO_ESTADO_DESTINO", SqlDbType.NVarChar, 2) : sqlParametro.Value = Me._CODIGO_ESTADO_DESTINO
            sqlParametro = .Parameters.Add("@FLETE_IMPORTE", SqlDbType.Decimal) : sqlParametro.Value = Me._FLETE_IMPORTE
            sqlParametro = .Parameters.Add("@CODIGO_ALMACEN", SqlDbType.NVarChar, 4) : sqlParametro.Value = Me._CODIGO_ALMACEN
            sqlParametro = .Parameters.Add("@CODIGO_EMPAQUE", SqlDbType.NVarChar, 2) : sqlParametro.Value = Me._CODIGO_EMPAQUE
            sqlParametro = .Parameters.Add("@ACCION", SqlDbType.NVarChar, 20) : sqlParametro.Value = "ACTUALIZAR"

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "Actualizar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With

        Return bResultado
    End Function

    Public Function Insertar(ByVal sAccion As String) As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_EMB_EMBARQUE_GRABA_GLOBAL"

            sqlParametro = .Parameters.Add("@FOLIO_EMBARQUE ", SqlDbType.NVarChar, 15) : sqlParametro.Direction = ParameterDirection.InputOutput : sqlParametro.Value = Me._FOLIO_EMBARQUE
            sqlParametro = .Parameters.Add("@CODIGO_DOCUMENTO", SqlDbType.NVarChar, 10) : sqlParametro.Value = "" & Me._CODIGO_DOCUMENTO
            sqlParametro = .Parameters.Add("@CODIGO_MERCADO", SqlDbType.Char, 1) : sqlParametro.Value = "" & Me._CODIGO_MERCADO
            sqlParametro = .Parameters.Add("@FOLIO_AARC", SqlDbType.NVarChar, 8) : sqlParametro.Value = "" & Me._FOLIO_AARC
            sqlParametro = .Parameters.Add("@CODIGO_PLAZA", SqlDbType.SmallInt) : sqlParametro.Value = Plaza.CODIGO_PLAZA
            sqlParametro = .Parameters.Add("@FECHA", SqlDbType.DateTime) : sqlParametro.Value = "" & Me._FECHA
            sqlParametro = .Parameters.Add("@FECHA_SALIDA", SqlDbType.DateTime) : sqlParametro.Value = "" & Me._FECHA_SALIDA
            sqlParametro = .Parameters.Add("@FECHA_ENTREGA", SqlDbType.DateTime) : sqlParametro.Value = "" & Me._FECHA_ENTREGA
            sqlParametro = .Parameters.Add("@CODIGO_DISTRIBUIDOR", SqlDbType.NVarChar, 8) : sqlParametro.Value = "" & Me._CODIGO_DISTRIBUIDOR
            sqlParametro = .Parameters.Add("@CODIGO_EMBARCADOR", SqlDbType.NVarChar, 8) : sqlParametro.Value = "" & Me._CODIGO_EMBARCADOR
            sqlParametro = .Parameters.Add("@CODIGO_CLIENTE", SqlDbType.NVarChar, 8) : sqlParametro.Value = "" & Me._CODIGO_CLIENTE
            sqlParametro = .Parameters.Add("@CODIGO_TRANSPORTE", SqlDbType.NVarChar, 8) : sqlParametro.Value = "" & Me._CODIGO_TRANSPORTE
            sqlParametro = .Parameters.Add("@CODIGO_CHOFER", SqlDbType.NVarChar, 8) : sqlParametro.Value = "" & Me._CODIGO_CHOFER
            sqlParametro = .Parameters.Add("@CODIGO_CAJA", SqlDbType.NVarChar, 8) : sqlParametro.Value = "" & Me._CODIGO_CAJA
            sqlParametro = .Parameters.Add("@OBSERVACIONES", SqlDbType.NVarChar, 200) : sqlParametro.Value = Me._OBSERVACIONES.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_ADUANA_EXTRANJERA", SqlDbType.NVarChar, 8) : sqlParametro.Value = Me._CODIGO_ADUANA_EXTRANJERA
            sqlParametro = .Parameters.Add("@CODIGO_ADUANA_NACIONAL", SqlDbType.NVarChar, 8) : sqlParametro.Value = Me._CODIGO_ADUANA_NACIONAL
            sqlParametro = .Parameters.Add("@TEMPERATURA", SqlDbType.Money) : sqlParametro.Value = Me._TEMPERATURA
            sqlParametro = .Parameters.Add("@SELLO", SqlDbType.NVarChar, 30) : sqlParametro.Value = Me._SELLO.ToUpper
            sqlParametro = .Parameters.Add("@TOTAL_PESO", SqlDbType.Money) : sqlParametro.Value = Me._TOTAL_PESO
            sqlParametro = .Parameters.Add("@TOTAL_DINERO", SqlDbType.Money) : sqlParametro.Value = Me._TOTAL_DINERO
            sqlParametro = .Parameters.Add("@TOTAL_BULTOS", SqlDbType.Int) : sqlParametro.Value = Me._TOTAL_BULTOS
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO_GRABO", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Usuario
            sqlParametro = .Parameters.Add("@CODIGO_LUGAR_ENTREGA", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_LUGAR_ENTREGA
            sqlParametro = .Parameters.Add("@CODIGO_ESTADO_DESTINO", SqlDbType.NVarChar, 2) : sqlParametro.Value = Me._CODIGO_ESTADO_DESTINO
            sqlParametro = .Parameters.Add("@FLETE_IMPORTE", SqlDbType.Decimal) : sqlParametro.Value = Me._FLETE_IMPORTE
            sqlParametro = .Parameters.Add("@CODIGO_ALMACEN", SqlDbType.NVarChar, 4) : sqlParametro.Value = Me._CODIGO_ALMACEN
            sqlParametro = .Parameters.Add("@CODIGO_EMPAQUE", SqlDbType.NVarChar, 2) : sqlParametro.Value = Me._CODIGO_EMPAQUE
            sqlParametro = .Parameters.Add("@ACCION", SqlDbType.NVarChar, 20) : sqlParametro.Value = sAccion

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
                Me._FOLIO_EMBARQUE = "" & .Parameters("@FOLIO_EMBARQUE ").Value.ToString
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "Insertar", ex)
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
            'Me._oDocumento.CODIGO_DOCUMENTO = Me.CODIGO_MODULO & Me._CODIGO_MERCADO & Usuario.Codigo_Plaza
            Me._oDocumento.GeneraFolio()
            sResultado = Me._oDocumento.FOLIO
            Me._FOLIO_EMBARQUE = Me._oDocumento.FOLIO
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "GeneraFolio", ex)
        End Try
        Return sResultado
    End Function

    Public Function GeneraFolioEmbarqueAdicional() As String
        Dim sResultado As String = ""
        Try
            Dim oSql As New Class_find("SELECT dbo.FN_EMB_EMBARQUES_GENERA_FOLIO_ADICIONAL('" & Me._FOLIO_VIAJE & "')")
            sResultado = oSql.Result1
            Me._FOLIO_EMBARQUE = _oDocumento.FOLIO
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "GeneraFolioEmbarqueAdicional", ex)
        End Try
        Return sResultado
    End Function

    Public Function GeneraFolioAARC() As String
        Dim sResultado As String = ""
        Dim iFolioAARC As Integer = 0 ', sFolioAARC As String
        'Dim Resultado As String = ""
        Try
            Dim sql As New Class_find("SELECT MAX(FOLIO_AARC) FROM EMB_EMBARQUE_GLOBAL")
            If sql.Result1 = "" Then
                iFolioAARC = 1
            Else
                iFolioAARC = CType(sql.Result1, Integer) + 1
            End If
            sResultado = iFolioAARC.ToString

            'sFolioAARC = "0000" + iFolioAARC.ToString '00005658
            'Resultado = sFolioAARC.Substring(Len(sFolioAARC) - 4)

        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "GeneraFolioAARC", ex)
        End Try

        Return sResultado
    End Function

    Public Function Cancela() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_EMB_EMBARQUE_CANCELA"

            sqlParametro = .Parameters.Add("@FOLIO_EMBARQUE ", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me.FOLIO_EMBARQUE
            sqlParametro = .Parameters.Add("@FECHA_DE_CANCELACION", SqlDbType.SmallDateTime) : sqlParametro.Value = Me._FECHA_CANCELACION
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO_CANCELO", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Usuario

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "Cancela", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With

        Return bResultado
    End Function

    Public Function Consultar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand(Me._QuerySelect & " WHERE G.FOLIO_EMBARQUE ='" & sReplace(Me._FOLIO_EMBARQUE) & "' AND G.CODIGO_PLAZA=" & Plaza.CODIGO_PLAZA & " ", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()
                If dReader.Read Then
                    Me._ID_EMB_EMBARQUE_GLOBAL = CInt(dReader("ID_EMB_EMBARQUE_GLOBAL"))
                    Me._FOLIO_VIAJE = "" & dReader("FOLIO_VIAJE").ToString
                    Me._FOLIO_EMBARQUE = "" & dReader("FOLIO_EMBARQUE").ToString
                    Me._CODIGO_DOCUMENTO = dReader("CODIGO_DOCUMENTO").ToString
                    Me._CODIGO_MERCADO = dReader("CODIGO_MERCADO").ToString
                    Me._FOLIO_AARC = dReader("FOLIO_AARC").ToString
                    Me._FECHA = CDate(dReader("FECHA"))
                    Me._FECHA_SERVIDOR = CDate(dReader("FECHA_SERVIDOR"))
                    Me._CODIGO_DISTRIBUIDOR = dReader("CODIGO_DISTRIBUIDOR").ToString
                    Me._ESTATUS_EMBARQUE = dReader("ESTATUS_EMBARQUE").ToString
                    Me._CODIGO_EMBARCADOR = dReader("CODIGO_EMBARCADOR").ToString
                    Me._CODIGO_CLIENTE = dReader("CODIGO_CLIENTE").ToString
                    Me._CODIGO_TRANSPORTE = dReader("CODIGO_TRANSPORTE").ToString
                    Me._CODIGO_CHOFER = dReader("CODIGO_CHOFER").ToString
                    Me._CODIGO_CAJA = dReader("CODIGO_CAJA").ToString
                    Me._TOTAL_BULTOS = CInt(dReader("TOTAL_BULTOS"))
                    Me._TOTAL_PESO = CDbl(dReader("TOTAL_PESO"))
                    Me._TOTAL_DINERO = CDbl(dReader("TOTAL_DINERO"))
                    Me._OBSERVACIONES = dReader("OBSERVACIONES").ToString
                    Me._TEMPERATURA = CInt(dReader("TEMPERATURA").ToString)
                    Me._SELLO = dReader("SELLO").ToString
                    Me._CODIGO_USUARIO_GRABO = CInt(dReader("CODIGO_USUARIO_GRABO"))
                    Me._NOMBRE_USUARIO_GRABO = dReader("NOMBRE_USUARIO_GRABO").ToString
                    Me._FECHA_SALIDA = CDate(dReader("FECHA_SALIDA"))
                    Me._FECHA_ENTREGA = CDate(dReader("FECHA_ENTREGA"))
                    If Me._CODIGO_MERCADO = "E" Then
                        Me._CODIGO_ADUANA_EXTRANJERA = dReader("CODIGO_ADUANA_EXTRANJERA").ToString
                        Me._CODIGO_ADUANA_NACIONAL = dReader("CODIGO_ADUANA_NACIONAL").ToString
                        Me._FLETE_GENERADO = dReader("FLETE_GENERADO").ToString
                    End If
                    If Me._ESTATUS_EMBARQUE = "C" Then
                        Me._CODIGO_USUARIO_CANCELO = CInt(dReader("CODIGO_USUARIO_CANCELO"))
                        Me._NOMBRE_USUARIO_CANCELO = dReader("NOMBRE_USUARIO_CANCELO").ToString
                        Me._FECHA_CANCELACION = CDate(dReader("FECHA_DE_CANCELACION"))
                        Me._FECHA_CANCELACION_SERVIDOR = CDate(dReader("FECHA_DE_CANCELACION_SERVIDOR"))
                    End If
                    If txtLEN("" & dReader("CODIGO_LUGAR_ENTREGA").ToString) = False Then
                        Me._CODIGO_LUGAR_ENTREGA = 0
                    Else
                        Me._CODIGO_LUGAR_ENTREGA = CInt(dReader("CODIGO_LUGAR_ENTREGA").ToString)
                    End If
                    Me._SALIDA_EMPAQUE_GENERADA = dReader("SALIDA_EMPAQUE_GENERADA").ToString
                    Me._IMPORTE_FLETE = CDbl(dReader("IMPORTE_FLETE"))
                    Me._SALDO_FLETE = CDbl(dReader("SALDO_FLETE"))

                    If txtLEN("" & dReader("CODIGO_ESTADO_DESTINO").ToString) = False Then
                        Me._CODIGO_ESTADO_DESTINO = ""
                    Else
                        Me._CODIGO_ESTADO_DESTINO = dReader("CODIGO_ESTADO_DESTINO").ToString
                    End If
                    Me._FACTURA_GENERADA = CBool(dReader("FACTURA_GENERADA").ToString)
                    Me._FOLIO_VENTA = "" & dReader("FOLIO_VENTA").ToString
                    Me._CODIGO_USUARIO_FACTURO = "" & dReader("CODIGO_USUARIO_FACTURO").ToString
                    Me._FLETE_IMPORTE = CDbl(dReader("FLETE_IMPORTE").ToString)
                    Me._CODIGO_ALMACEN = dReader("CODIGO_ALMACEN").ToString
                    Me._ENTRADA_ALMACEN_GENERADA = CBool(dReader("ENTRADA_ALMACEN_GENERADA").ToString)
                    Me._FOLIO_ENTRADA_ALMACEN = dReader("FOLIO_ENTRADA_ALMACEN").ToString
                    Me._CODIGO_TIPO_DOCUMENTO_FACTURA_EMBARQUE_EXTRANJERO = "" & dReader("CODIGO_TIPO_DOCUMENTO_FACTURA_EMBARQUE_EXTRANJERO").ToString
                    Me._FOLIO_PEDIMENTO = "" & dReader("FOLIO_PEDIMENTO").ToString
                    Me._CODIGO_EMPAQUE = "" & dReader("CODIGO_EMPAQUE").ToString

                    bResultado = True
                End If
                dReader.Close()
            Catch ex As Exception
                HandleError(Me.Nombre_Catalogo, "Consultar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
            End Try
        End With

        Return bResultado
    End Function

    Public Function GenerarFlete() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_EMB_EMBARQUE_GENERA_FLETE"

            sqlParametro = .Parameters.Add("@CODIGO_PLAZA", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Plaza
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO_GRABO", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Usuario
            sqlParametro = .Parameters.Add("@FOLIO_EMBARQUE ", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_EMBARQUE

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "GenerarFlete", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With

        Return bResultado
    End Function

    Public Function EliminarFlete() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_EMB_EMBARQUE_ELIMINA_FLETE"

            sqlParametro = .Parameters.Add("@FOLIO_EMBARQUE ", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_EMBARQUE

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "EliminarFlete", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With

        Return bResultado
    End Function

    Public Function CambiarPrecios(ByVal sCodigoArticulo As String, ByVal dNuevoPrecio As Double) As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_EMB_EMBARQUE_GRABA_CAMBIO_PRECIO_PALETS"

            sqlParametro = .Parameters.Add("@FOLIO_EMBARQUE ", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_EMBARQUE
            sqlParametro = .Parameters.Add("@CODIGO_ARTICULO", SqlDbType.NVarChar, 16) : sqlParametro.Value = sCodigoArticulo
            sqlParametro = .Parameters.Add("@PRECIO_UNIDAD_BULTO", SqlDbType.Money) : sqlParametro.Value = dNuevoPrecio

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "CambiarPrecios", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With

        Return bResultado
    End Function

    Public Function ObtenerDetalle() As DataTable
        Dim dTabla As New DataTable("detalle"), da As SqlDataAdapter
        Dim sSQL As String
        sSQL = "SELECT FOLIO_PALET,CANTIDAD_TOTAL_PALET,PESO_TOTAL_PALET,IMPORTE_TOTAL_PALET," &
        "CASE WHEN ISNULL( SALIDA_EMPAQUE_GENERADA,'0')='0' THEN 'NO' ELSE 'SI' END AS SALIDA_EMPAQUE_GENERADA,GENERARA_SALIDA " &
        "FROM VW_EMB_EMBARQUE_DETALLE_EXTENDIDO WHERE FOLIO_EMBARQUE= '" & Me._FOLIO_EMBARQUE & "' " &
        " ORDER BY ID_EMB_EMBARQUE_DETALLE "
        Try
            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dTabla)
            da.Dispose()
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "ObtenerDetalle", ex)
        End Try
        Return dTabla
    End Function

    Public Function ObtenerDetalleFactura() As DataTable
        Dim dTabla As New DataTable("detalle"), da As SqlDataAdapter
        Dim sSQL As String
        sSQL = "SELECT D.CODIGO_ARTICULO,CASE WHEN MAX(A.ES_SERIALIZABLE)='1' THEN 'SER' WHEN MAX(A.INVENTARIABLE)='1' THEN 'INV' ELSE 'NIV' END TIPO_CONTROL_INVENTARIO, " &
        "MAX(A.DESCRIPCION) DESCRIPCION,SUM(D.CANTIDAD_BULTOS_DETALLE) CANTIDAD_BULTOS_DETALLE,D.PRECIO_UNIDAD_BULTO, " &
        "MAX(A.UNIDAD_VENTA) UNIDAD,0 CANTIDAD_KILOS,0 PRECIO_KILOS,0 IMPUESTO_PORCENTAJE,SUM(D.IMPORTE_BULTOS_DETALLE) IMPORTE_BULTOS_DETALLE,0 IMPORTE_KILOS,MAX(A.CODIGO_CULTIVO) CODIGO_CULTIVO, " &
        "ISNULL(MAX(U.CUENTA_CONTABLE_BASE),'XXXX') CUENTA_CONTABLE_BASE " &
        "FROM VW_EMB_EMBARQUE_DETALLE_EXTENDIDO EDET " &
        "INNER JOIN EMB_PALETS_DETALLE D ON(EDET.FOLIO_PALET=D.FOLIO_PALET) " &
        "INNER JOIN CAT_ARTICULOS A ON(D.CODIGO_ARTICULO=A.CODIGO_ARTICULO) " &
        "LEFT JOIN CAT_CULTIVOS U ON(A.CODIGO_CULTIVO=U.CODIGO_CULTIVO) " &
        "WHERE EDET.FOLIO_EMBARQUE='" & Me._FOLIO_EMBARQUE & "' " &
        "GROUP BY D.CODIGO_ARTICULO,D.PRECIO_UNIDAD_BULTO"

        Try
            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dTabla)
            da.Dispose()
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "ObtenerDetalleFactura", ex)
        End Try
        Return dTabla
    End Function

    Public Function ObtenerDetalleFacturaEmbarqueExtranjero(ByVal dTipoCambio As Double) As DataTable
        Dim dTabla As New DataTable("detalle"), da As SqlDataAdapter
        Dim sSQL As String
        sSQL = "SELECT D.CODIGO_ARTICULO,CASE WHEN MAX(A.ES_SERIALIZABLE)='1' THEN 'SER' WHEN MAX(A.INVENTARIABLE)='1' THEN 'INV' ELSE 'NIV' END TIPO_CONTROL_INVENTARIO, " &
            "MAX(A.DESCRIPCION) + CASE WHEN MAX(U.ALIAS_EXTRANJERO) IS NOT NULL THEN ' ('+ MAX(U.ALIAS_EXTRANJERO) +')'  ELSE '' END DESCRIPCION, " &
            "SUM(D.CANTIDAD_BULTOS_DETALLE) CANTIDAD_BULTOS_DETALLE,D.PRECIO_UNIDAD_BULTO*" & Format(dTipoCambio, "###.0000") & " PRECIO_UNIDAD_BULTO, " &
            "MAX(A.UNIDAD_VENTA) UNIDAD,0 CANTIDAD_KILOS,0 PRECIO_KILOS,0 IMPUESTO_PORCENTAJE,SUM(D.IMPORTE_BULTOS_DETALLE) IMPORTE_BULTOS_DETALLE,0 IMPORTE_KILOS,MAX(A.CODIGO_CULTIVO) CODIGO_CULTIVO, " &
            "ISNULL(MAX(U.CUENTA_CONTABLE_BASE),'XXXX') CUENTA_CONTABLE_BASE, " &
            "D.PRECIO_UNIDAD_BULTO PRECIO_USD,ROUND(SUM(D.CANTIDAD_BULTOS_DETALLE)*D.PRECIO_UNIDAD_BULTO,2) IMPORTE_USD," &
            "MAX(A.ID_SIS_CAT_IMPUESTOS) ID_SIS_CAT_IMPUESTOS,MAX(A.GRADO_TOXICIDAD) GRADO_TOXICIDAD " &
            "FROM VW_EMB_EMBARQUE_DETALLE_EXTENDIDO EDET " &
            "INNER JOIN EMB_PALETS_DETALLE D ON(EDET.FOLIO_PALET=D.FOLIO_PALET) " &
            "INNER JOIN CAT_ARTICULOS A ON(D.CODIGO_ARTICULO=A.CODIGO_ARTICULO) " &
            "LEFT JOIN CAT_CULTIVOS U ON(A.CODIGO_CULTIVO=U.CODIGO_CULTIVO) " &
            "WHERE EDET.FOLIO_EMBARQUE='" & Me._FOLIO_EMBARQUE & "' " &
            "GROUP BY D.CODIGO_ARTICULO,D.PRECIO_UNIDAD_BULTO"

        'Asi se pone en la factura fake de embarques.
        'SELECT EDET.FOLIO_EMBARQUE,D.CODIGO_ARTICULO,MAX(A.DESCRIPCION)+' ('+ MAX(A.ALIAS_EXTRANJERO) +')' DESCRIPCION,SUM(D.CANTIDAD_BULTOS_DETALLE) CANTIDAD_BULTOS_DETALLE,D.PRECIO_UNIDAD_BULTO,D.PESO_UNIDAD_BULTO,  
        'SUM(D.PESO_BULTOS_DETALLE) PESO_BULTOS_DETALLE,SUM(D.IMPORTE_BULTOS_DETALLE) IMPORTE_BULTOS_DETALLE  
        'FROM VW_EMB_EMBARQUE_DETALLE_EXTENDIDO EDET  
        'INNER JOIN EMB_PALETS_DETALLE D ON(EDET.FOLIO_PALET=D.FOLIO_PALET)  
        'INNER JOIN VW_CAT_PRODUCTOS_AGRICOLAS A ON(D.CODIGO_ARTICULO=A.CODIGO_ARTICULO)  
        'WHERE EDET.FOLIO_EMBARQUE=@FOLIO_EMBARQUE
        'GROUP BY EDET.FOLIO_EMBARQUE,D.CODIGO_ARTICULO,D.PRECIO_UNIDAD_BULTO,D.PESO_UNIDAD_BULTO 

        Try
            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dTabla)
            da.Dispose()
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "ObtenerDetalleFacturaEmbarqueExtranjero", ex)
        End Try
        Return dTabla
    End Function

    'Public Function ObtenerTipoEmbarque() As System.Data.DataTable
    '    Dim dTabla As New DataTable
    '    Dim dsTipoEmbarque As New SqlDataAdapter("SELECT CODIGO_MERCADO,NOMBRE_MERCADO FROM EMB_CAT_MERCADOS ORDER BY NOMBRE_MERCADO", Me._Conexion)
    '    Try
    '        dsTipoEmbarque.Fill(dTabla)
    '    Catch ex As Exception
    '        HandleError(Me.Nombre_Catalogo, "ObtenerTipoEmbarque", ex)
    '    End Try
    '    ObtenerTipoEmbarque = dTabla
    'End Function

    Public Function ObtenerEstatusEmbarques() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dsEstatusEmbarques As New SqlDataAdapter("SELECT ESTATUS_EMBARQUE,ESTATUS_COMPLETO from EMB_CAT_ESTATUS ", Me._Conexion)

        Try
            dsEstatusEmbarques.Fill(dTable)
            dTable.Rows.Add("T", "TODOS")
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerEstatusEmbarques", ex)
        Finally
            dsEstatusEmbarques.Dispose()
        End Try
        Return dTable
    End Function

    Public Function BusquedaVisual_Embarques_Nacional() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de embarques nacional por folio."
        f.sCampo = "FOLIO_EMBARQUE"
        f.sOrder = "FECHA"
        f.sTable = "EMB_EMBARQUE_GLOBAL"
        f.sQl = "SELECT G.FOLIO_EMBARQUE,G.FECHA,G.ESTATUS_EMBARQUE FROM EMB_EMBARQUE_GLOBAL G  " &
        "INNER JOIN VW_SIS_CAT_DOCUMENTOS_EXTENDIDO T ON(G.CODIGO_DOCUMENTO=T.CODIGO_DOCUMENTO) " &
        "WHERE T.CODIGO_DOCUMENTO='" & Me.CODIGO_MODULO & "N" & Plaza.CODIGO_PLAZA & "' AND "

        f.Inicia("")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "BusquedaVisual_Embarques_Nacional", ex)
        End Try
        Return Resultado
    End Function

    Public Function BusquedaVisual_Embarques_Extranjeros() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de embarques al extranjero por folio."
        f.sCampo = "FOLIO_EMBARQUE "
        f.sOrder = "FECHA"
        f.sTable = "EMB_EMBARQUE_GLOBAL"
        f.sQl = "SELECT G.FOLIO_EMBARQUE,G.FOLIO_AARC,G.FECHA,G.ESTATUS_EMBARQUE FROM EMB_EMBARQUE_GLOBAL G  " &
        "INNER JOIN VW_SIS_CAT_DOCUMENTOS_EXTENDIDO T ON(G.CODIGO_DOCUMENTO=T.CODIGO_DOCUMENTO) " &
        "WHERE T.CODIGO_DOCUMENTO='" & Me.CODIGO_MODULO & "E" & Plaza.CODIGO_PLAZA & "' "
        f.Inicia("")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "BusquedaVisual_Embarques_Extranjeros", ex)
        End Try
        Return Resultado
    End Function

    Public Function BusquedaVisual_Embarques_Extranjeros_SaldoFletes() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de embarques al extranjero con saldo de fletes."
        f.sCampo = "FOLIO_EMBARQUE "
        f.sOrder = "FECHA"
        f.sTable = "EMB_EMBARQUE_GLOBAL"
        f.sQl = "SELECT G.FOLIO_EMBARQUE,P.NOMBRE_DISTRIBUIDOR,G.FECHA, G.IMPORTE_FLETE,G.SALDO_FLETE FROM EMB_EMBARQUE_GLOBAL G " &
        "INNER JOIN CAT_DISTRIBUIDORES P ON(G.CODIGO_DISTRIBUIDOR =P.CODIGO_DISTRIBUIDOR) " &
        "INNER JOIN VW_SIS_CAT_DOCUMENTOS_EXTENDIDO T ON(G.CODIGO_DOCUMENTO=T.CODIGO_DOCUMENTO) " &
        "WHERE T.CODIGO_DOCUMENTO='" & Me.CODIGO_MODULO & "E" & Plaza.CODIGO_PLAZA & "' AND G.SALDO_FLETE>0 AND G.ESTATUS_EMBARQUE='A' AND "

        f.Inicia("")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "BusquedaVisual_Embarques_Extranjeros_SaldoFletes", ex)
        End Try
        Return Resultado
    End Function

    Public Sub NuevoRenglon()
        Me.oEmbarqueDetalle = New Class_Embarques_EmbarqueDetalle
    End Sub

    Public Function MarcaSalidaEmpaqueGenerada(Optional ByVal bMarcar As Boolean = True) As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_EMB_GENERA_MARCA_SALIDA_EMBARQUE"

            sqlParametro = .Parameters.Add("@FOLIO_EMBARQUE", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_EMBARQUE
            sqlParametro = .Parameters.Add("@MARCAR", SqlDbType.NVarChar, 1) : sqlParametro.Value = Convert.ToInt32(bMarcar)

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me.Nombre_Catalogo, "MarcaSalidaEmpaqueGenerada", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With

        Return bResultado
    End Function

    Public Function GeneraMarcaFactura(ByVal sFolioVenta As String, ByVal bMarcar As Boolean) As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_VENTA_GENERA_MARCA_EMBARQUE_FACTURA"

            sqlParametro = .Parameters.Add("@FOLIO_EMBARQUE ", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_EMBARQUE
            sqlParametro = .Parameters.Add("@FOLIO_VENTA", SqlDbType.NVarChar, 15) : sqlParametro.Value = sFolioVenta
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO_FACTURO", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Usuario
            sqlParametro = .Parameters.Add("@MARCA", SqlDbType.Char) : sqlParametro.Value = Convert.ToInt32(bMarcar)

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "GeneraMarcaFactura", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With

        Return bResultado
    End Function

    Public Function EmbarquesSinFletes() As System.Data.DataTable
        Dim dt As New DataTable
        Try
            Dim da As New SqlDataAdapter("MP_RPT_EMBARQUES_FLETES_SIN_GENERAR", Me._Conexion)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            With da.SelectCommand
                .Parameters.Add("@CODIGO_PLAZA", SqlDbType.SmallInt) : .Parameters("@CODIGO_PLAZA").Value = CInt(Usuario.Codigo_Plaza)
            End With
            da.Fill(dt)
            dt.Columns.Remove("EMPRESA_NOMBRE")
            dt.Columns.Remove("EMPRESA_DOMICILIO")
            dt.Columns.Remove("EMPRESA_CIUDAD")
            dt.Columns.Remove("EMPRESA_ESTADO")
            dt.Columns.Remove("EMPRESA_RFC")
            dt.Columns.Remove("EMPRESA_TELEFONO")

            dt.Columns.Remove("CODIGO_CLIENTE")
            dt.Columns.Remove("NOMBRE_LINEA_TRANSPORTE")
            dt.Columns.Remove("CUENTA_CONTABLE_FLETERO")
            dt.Columns.Remove("NOMBRE_LUGAR_ENTREGA")
            dt.Columns.Remove("FLETE_GENERADO")

        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "EmbarquesSinFletes", ex)
        End Try
        Return dt
    End Function

    Public Function ValidaEmbarqueFacturaExtanjero() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        Dim dReader As SqlDataReader
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_EMBARQUE_VALIDA_FACTURA_EXTRANJERO"

            sqlParametro = .Parameters.Add("@FOLIO_EMBARQUE ", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_EMBARQUE

            Try
                Me._Conexion.Open()
                dReader = cmd.ExecuteReader()

                If dReader.Read = True Then
                    If txtLEN(dReader("RESULTADO").ToString) = True Then
                        MsgBox("" & dReader("RESULTADO").ToString, MsgBoxStyle.Exclamation, "ValidaEmbarqueFacturaExtanjero")
                    Else
                        bResultado = True
                    End If
                End If

            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "ValidaEmbarqueFacturaExtanjero", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Function GeneraTXTEnvio() As String
        Dim bResultado As String = ""
        Dim dt As New DataTable, PathArchivo As String = "", strStreamW As Stream = Nothing, strStreamWriter As StreamWriter = Nothing, sCarpeta As String = ""
        Try
            Dim da As New SqlDataAdapter("MP_EMBARQUES_GENERA_TXT", Me._Conexion)
            da.SelectCommand.CommandType = CommandType.StoredProcedure

            With da.SelectCommand
                .Parameters.Add("@FOLIO_EMBARQUE", SqlDbType.NVarChar, 15).Value = Me._FOLIO_EMBARQUE
            End With

            da.Fill(dt)

            sCarpeta = My.Settings.Ruta & "\Embarque"
            PathArchivo = sCarpeta & "\" & Me._FOLIO_EMBARQUE & ".txt"

            If Directory.Exists(sCarpeta) = False Then
                Directory.CreateDirectory(sCarpeta)
            End If

            If isExisteArchivo(PathArchivo) = True Then
                File.Delete(PathArchivo)
            End If
            strStreamW = File.Create(PathArchivo)

            strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default) ' tipo de codificacion para escritura

            For Each r As DataRow In dt.Rows
                strStreamWriter.WriteLine(r("TEXTO").ToString)
            Next
            strStreamWriter.Close()
            strStreamW.Close()
            strStreamW.Dispose()
            strStreamW.Dispose()

            bResultado = PathArchivo
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "GeneraTXTEnvio", ex)
        End Try

        Return bResultado
    End Function

    Public Function GenerarEntradaInventario() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_EMB_EMBARQUE_GENERA_ENTRADA_ALMACEN"

            sqlParametro = .Parameters.Add("@FOLIO_EMBARQUE ", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_EMBARQUE
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Usuario

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "GenerarEntradaInventario", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Function GrabaFolioPedimento(ByVal sFolioPedimento As String) As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_EMB_EMBARQUE_GRABA_FOLIO_PEDIMENTO"

            sqlParametro = .Parameters.Add("@FOLIO_EMBARQUE ", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_EMBARQUE
            sqlParametro = .Parameters.Add("@FOLIO_PEDIMENTO", SqlDbType.NVarChar, 30) : sqlParametro.Value = sFolioPedimento

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "GrabaFolioPedimento", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With

        Return bResultado
    End Function

    Public Function GrabarSalidaMaterialEmpaque() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_EMB_GENERA_SALIDA_MATERIAL_EMPAQUE"

            sqlParametro = .Parameters.Add("@FOLIO_EMBARQUE ", SqlDbType.NVarChar, 15) : sqlParametro.Value = "" & Me._FOLIO_EMBARQUE
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Usuario

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "GrabarSalidaMaterialEmpaque", ex)
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
