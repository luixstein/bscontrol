Option Strict On

Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Net.Mail
Imports System.Net.Security
Imports System.Security.Cryptography.X509Certificates
Imports System.Net

Public Class tPrecioVenta
    Public Precio As Decimal = 0
    Public Costo As Decimal = 0
End Class

Public Class Class_Ventas_Global

#Region "Campos"

#Region "Campos de la tabla"
    Private _ID_VENTA_GLOBAL As Integer
    Private _FOLIO_VENTA As String
    Private _FECHA As Date
    Private _FECHA_VENCIMIENTO As Date
    Private _FECHA_SERVIDOR As Date
    Private _CODIGO_CLIENTE As String
    Private _CODIGO_DOCUMENTO As String
    Private _CODIGO_VENDEDOR As Integer
    Private _SUBTOTAL As Double
    Private _DESCUENTO As Double
    Private _IEPS_TOTAL_DESGLOSADO As Double
    Private _IEPS_TOTAL_YA_INCLUIDO As Double
    Private _IMPUESTO As Double
    Private _TOTAL As Double
    Private _SALDO As Double
    Private _COSTO As Double
    Private _ESTATUS_VENTA As String
    Private _CODIGO_USUARIO_GRABO As Integer
    Private _FOLIO_REFERENCIA As String
    Private _TIPO_DE_CAMBIO As Double
    Private _CODIGO_ALMACEN As String
    Private _CONCEPTO As String
    Private _CODIGO_PLAZA As Integer
    Private _CODIGO_TIPO_NEGOCIACION As Integer
    Private _FOLIO_POLIZA As String
    Private _IMPUESTO_PORCENTAJE As Double
    Private _ES_FACTURA_ELECTRONICA As String
    Private _FOLIO_NUMERICO As Integer
    Private _SERIE As String
    'Private _IDCATALOGO_FOLIO_FELECTRONICA As Integer
    Private _CADENA_ORIGINAL As String
    Private _SELLO_DIGITAL As String
    'Private _SELLO_REPROCESADO As String
    Private _SUSTITUYE_REMISION As String
    Private _CODIGO_TIPO_MERCADO As String
    Private _NOMBRE_USUARIO As String
    Private _FECHA_CANCELACION As Date
    Private _FECHA_CANCELACION_SERVIDOR As Date
    Private _FOLIO_REFERENCIA_USUARIO As String
    Private _NOMBRE_USUARIO_CANCELO As String
    Private _CODIGO_USUARIO_CANCELO As Integer
    Private _TIPO_VENTA As String
    Private _ES_VENTA_PUBLICO_GENERAL As String
    Private _TOTAl_SUSTITUCION As Double
    Private _FOLIO_EMBARQUE As String
    Private _VENTA_TOTAL As Double
    Private _CONDICIONES_DE_PAGO As String
    Private _CODIGO_TIPO_CREDITO As String
    Private _ID_SIS_CFD_CATALOGO_CERTIFICADOS As String
    Private _CODIGO_METODO_PAGO As String
    Private _NUMERO_CUENTA_PAGO As String
    'Private _RETENCION As Double
    Private _ADDENDA As String
    Private _FOLIO_FISCAL_SAT As String
    Private _FECHA_TIMBRADO_SAT As String
    Private _NUMERO_SERIE_CERTIFICADO_SAT As String
    Private _SELLO_SAT As String
    Private _CBB_IMAGE As String
    Private _TIMBRADO_CFDI As String
    Private _ESTATUS_CANCELACION_CFDI As String
    Private _TIMBRADO_DESCARTADO As String
    Private _VERSION_ESQUEMA_XML As String
    Private _TIENE_COMPLEMENTO_COMERCIO_EXTERIOR As Boolean
    Private _CODIGO_REGIMEN_FISCAL As String
    Private _CODIGO_METODO_PAGO_EVENTO As String
    Private _CODIGO_USO_CFDI As String
    Private _RFC_RECEPTOR As String
    Private _CODIGO_MONEDA_SAT As String
    Private _CONCEPTO_CANCELACION As String
    Private _TIENE_IEPS_DESGLOSADO As Boolean
    Private _CODIGO_TIPO_RELACION_CFDI As String
    Private _LISTA_CFDIS_RELACIONADOS As String
    Private _TOTAL_DOLARES As Double
    Private _SALDO_DOLARES As Double
    Private _SUBTOTAL_USD As Double
    Private _DESCUENTO_USD As Double
    Private _IMPUESTO_USD As Double
    Private _TOTAL_SUSTITUCION_USD As Double
    Private _IEPS_TOTAL_DESGLOSADO_USD As Double
    Private _IEPS_TOTAL_YA_INCLUIDO_USD As Double
    Private _RETENCION_IVA As Decimal
    Private _RETENCION_IVA_USD As Decimal
    Private _RETENCION_ISR As Decimal
    Private _RETENCION_ISR_USD As Decimal
    Private _FOLIO_DESCUENTO_ANTICIPO As String
    Private _TIENE_COMPLEMENTO_CARTA_PORTE As Boolean
#End Region

#Region "Campos ligados a la tabla"
    Private _Existe As Boolean 'lectura
    Private _Nombre_Formato As String
    'CFD
    Private _NOMBRE_METODO_PAGO As String
    Private _NOMBRE_REGIMEN_FISCAL As String
    Private _FELECTRONICA_CER As String
    Private _FELECTRONICA_KEY As String
    Private _FELECTRONICA_CONTRASENIA_CLAVE_PRIVADA As String
    Private _ES_FACTURA_EMBARQUE_EXTRANJERO As Boolean = False
    Private _TIENE_SERIES As Boolean = False

    Private _CODIGO_TIPO_DOCUMENTO As String
#End Region

#Region "Campos públicos"
    Public oVentasDetalle As Class_Ventas_Detalle
#End Region

#Region "Campos privados"

#End Region

#Region "Campos de sistema"
    Private _Nombre_Catalogo As String
    Private _Conexion As SqlConnection
    Private _QuerySelect As String
    Private _QueryOrder As String

    Private Declare Function IsNetworkAlive Lib "SENSAPI.DLL" (ByRef lpdwFlags As Long) As Long
#End Region

#End Region

#Region "Propiedades"

#Region "Propiedades Campos de la tabla"

    Public ReadOnly Property ID_VENTA_GLOBAL() As Integer
        Get
            Return Me._ID_VENTA_GLOBAL
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

    Public Property FECHA_CANCELACION() As Date
        Get
            Return Me._FECHA_CANCELACION
        End Get
        Set(ByVal Value As Date)
            Me._FECHA_CANCELACION = Value
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

    Public Property FECHA_VENCIMIENTO() As Date
        Get
            Return Me._FECHA_VENCIMIENTO
        End Get
        Set(ByVal Value As Date)
            Me._FECHA_VENCIMIENTO = Value
        End Set
    End Property

    Public ReadOnly Property FECHA_SERVIDOR() As Date
        Get
            Return Me._FECHA_SERVIDOR
        End Get
        'Set(ByVal Value As Date)
        '    Me._FECHA_SERVIDOR = Value
        'End Set
    End Property

    Public ReadOnly Property FECHA_CANCELACION_SERVIDOR() As Date
        Get
            Return Me._FECHA_CANCELACION_SERVIDOR
        End Get
    End Property

    Public Property CODIGO_CLIENTE() As String
        Get
            Return Me._CODIGO_CLIENTE
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_CLIENTE = Value
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

    Public Property CODIGO_VENDEDOR() As Integer
        Get
            Return Me._CODIGO_VENDEDOR
        End Get
        Set(ByVal Value As Integer)
            Me._CODIGO_VENDEDOR = Value
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

    Public Property IEPS_TOTAL_YA_INCLUIDO() As Double
        Get
            Return Me._IEPS_TOTAL_YA_INCLUIDO
        End Get
        Set(ByVal Value As Double)
            Me._IEPS_TOTAL_YA_INCLUIDO = Value
        End Set
    End Property

    Public Property DESCUENTO() As Double
        Get
            Return Me._DESCUENTO
        End Get
        Set(ByVal Value As Double)
            Me._DESCUENTO = Value
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

    Public Property SALDO() As Double
        Get
            Return Me._SALDO
        End Get
        Set(ByVal Value As Double)
            Me._SALDO = Value
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

    Public Property ESTATUS_VENTA() As String
        Get
            Return Me._ESTATUS_VENTA
        End Get
        Set(ByVal Value As String)
            Me._ESTATUS_VENTA = Value
        End Set
    End Property

    Public Property CODIGO_USUARIO_GRABO() As Integer
        Get
            Return Me._CODIGO_USUARIO_GRABO
        End Get
        Set(ByVal Value As Integer)
            Me._CODIGO_USUARIO_GRABO = Value
        End Set
    End Property

    Public Property FOLIO_REFERENCIA() As String
        Get
            Return Me._FOLIO_REFERENCIA
        End Get
        Set(ByVal Value As String)
            Me._FOLIO_REFERENCIA = Value
        End Set
    End Property

    Public Property TIPO_DE_CAMBIO() As Double
        Get
            Return Me._TIPO_DE_CAMBIO
        End Get
        Set(ByVal Value As Double)
            Me._TIPO_DE_CAMBIO = Value
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

    Public Property CONCEPTO() As String
        Get
            Return Me._CONCEPTO
        End Get
        Set(ByVal Value As String)
            Me._CONCEPTO = Value
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

    Public Property CODIGO_TIPO_NEGOCIACION() As Integer
        Get
            Return Me._CODIGO_TIPO_NEGOCIACION
        End Get
        Set(ByVal Value As Integer)
            Me._CODIGO_TIPO_NEGOCIACION = Value
        End Set
    End Property

    Public Property FOLIO_POLIZA() As String
        Get
            Return Me._FOLIO_POLIZA
        End Get
        Set(ByVal Value As String)
            Me._FOLIO_POLIZA = Value
        End Set
    End Property

    'Public Property RETENCION() As Double
    '    Get
    '        Return Me._RETENCION
    '    End Get
    '    Set(ByVal Value As Double)
    '        Me._RETENCION = Value
    '    End Set
    'End Property

    Public Property IMPUESTO_PORCENTAJE() As Double
        Get
            Return Me._IMPUESTO_PORCENTAJE
        End Get
        Set(ByVal Value As Double)
            Me._IMPUESTO_PORCENTAJE = Value
        End Set
    End Property

    Public Property ES_FACTURA_ELECTRONICA() As String
        Get
            Return Me._ES_FACTURA_ELECTRONICA
        End Get
        Set(ByVal Value As String)
            Me._ES_FACTURA_ELECTRONICA = Value
        End Set
    End Property

    Public ReadOnly Property FOLIO_NUMERICO() As Integer
        Get
            Return Me._FOLIO_NUMERICO
        End Get
    End Property

    Public ReadOnly Property SERIE() As String
        Get
            Return Me._SERIE
        End Get
    End Property

    'Public ReadOnly Property IDCATALOGO_FOLIO_FELECTRONICA() As Integer
    '    Get
    '        Return Me._IDCATALOGO_FOLIO_FELECTRONICA
    '    End Get
    '    'Set(ByVal Value As Integer)
    '    '    Me._IDCATALOGO_FOLIO_FELECTRONICA = Value
    '    'End Set
    'End Property

    Public ReadOnly Property ID_SIS_CFD_CATALOGO_CERTIFICADOS() As String
        Get
            Return Me._ID_SIS_CFD_CATALOGO_CERTIFICADOS
        End Get
        'Set(ByVal Value As String)
        '    Me._ID_SIS_CFD_CATALOGO_CERTIFICADOS = Value
        'End Set
    End Property

    Public ReadOnly Property CADENA_ORIGINAL() As String
        Get
            Return Me._CADENA_ORIGINAL
        End Get
        'Set(ByVal Value As String)
        '    Me._CADENA_ORIGINAL = Value
        'End Set
    End Property

    Public ReadOnly Property SELLO_DIGITAL() As String
        Get
            Return Me._SELLO_DIGITAL
        End Get
        'Set(ByVal Value As String)
        '    Me._SELLO_DIGITAL = Value
        'End Set
    End Property

    'Public ReadOnly Property SELLO_REPROCESADO() As String
    '    Get
    '        Return Me._SELLO_REPROCESADO
    '    End Get
    '    'Set(ByVal Value As String)
    '    '    Me._SELLO_REPROCESADO = Value
    '    'End Set
    'End Property

    Public Property SUSTITUYE_REMISION() As String
        Get
            Return Me._SUSTITUYE_REMISION
        End Get
        Set(ByVal Value As String)
            Me._SUSTITUYE_REMISION = Value
        End Set
    End Property

    Public Property CODIGO_TIPO_MERCADO() As String
        Get
            Return Me._CODIGO_TIPO_MERCADO
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_TIPO_MERCADO = Value
        End Set
    End Property

    Public ReadOnly Property NOMBRE_USUARIO() As String
        Get
            Return Me._NOMBRE_USUARIO
        End Get
    End Property

    Public Property FOLIO_REFERENCIA_USUARIO() As String
        Get
            Return Me._FOLIO_REFERENCIA_USUARIO
        End Get
        Set(ByVal Value As String)
            Me._FOLIO_REFERENCIA_USUARIO = Value
        End Set
    End Property

    Public Property NOMBRE_USUARIO_CANCELO() As String
        Get
            Return Me._NOMBRE_USUARIO_CANCELO
        End Get
        Set(ByVal Value As String)
            Me._NOMBRE_USUARIO_CANCELO = Value
        End Set
    End Property

    Public Property CODIGO_USUARIO_CANCELO() As Integer
        Get
            Return Me._CODIGO_USUARIO_CANCELO
        End Get
        Set(ByVal Value As Integer)
            Me._CODIGO_USUARIO_CANCELO = Value
        End Set
    End Property

    Public Property TIPO_VENTA() As String
        Get
            Return Me._TIPO_VENTA
        End Get
        Set(ByVal Value As String)
            Me._TIPO_VENTA = Value
        End Set
    End Property

    Public Property ES_VENTA_PUBLICO_GENERAL() As String
        Get
            Return Me._ES_VENTA_PUBLICO_GENERAL
        End Get
        Set(ByVal Value As String)
            Me._ES_VENTA_PUBLICO_GENERAL = Value
        End Set
    End Property

    Public Property TOTAL_SUSTITUCION() As Double
        Get
            Return Me._TOTAl_SUSTITUCION
        End Get
        Set(ByVal Value As Double)
            Me._TOTAl_SUSTITUCION = Value
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

    Public Property VENTA_TOTAL() As Double
        Get
            Return Me._VENTA_TOTAL
        End Get
        Set(ByVal Value As Double)
            Me._VENTA_TOTAL = Value
        End Set
    End Property

    Public Property CONDICIONES_DE_PAGO() As String
        Get
            Return Me._CONDICIONES_DE_PAGO
        End Get
        Set(ByVal Value As String)
            Me._CONDICIONES_DE_PAGO = Value
        End Set
    End Property

    Public Property CODIGO_TIPO_CREDITO() As String
        Get
            Return Me._CODIGO_TIPO_CREDITO
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_TIPO_CREDITO = Value
        End Set
    End Property

    Public Property CODIGO_METODO_PAGO() As String
        Get
            Return Me._CODIGO_METODO_PAGO
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_METODO_PAGO = Value
        End Set
    End Property

    Public Property NUMERO_CUENTA_PAGO() As String
        Get
            Return Me._NUMERO_CUENTA_PAGO
        End Get
        Set(ByVal Value As String)
            Me._NUMERO_CUENTA_PAGO = Value
        End Set
    End Property

    'ADDENDA
    Public Property ADDENDA() As String
        Get
            Return Me._ADDENDA
        End Get
        Set(ByVal Value As String)
            Me._ADDENDA = Value
        End Set
    End Property

    Public ReadOnly Property FOLIO_FISCAL_SAT() As String
        Get
            Return Me._FOLIO_FISCAL_SAT
        End Get
    End Property

    Public ReadOnly Property FECHA_TIMBRADO_SAT() As String
        Get
            Return Me._FECHA_TIMBRADO_SAT
        End Get
    End Property

    Public ReadOnly Property NUMERO_SERIE_CERTIFICADO_SAT() As String
        Get
            Return Me._NUMERO_SERIE_CERTIFICADO_SAT
        End Get
    End Property

    Public ReadOnly Property SELLO_SAT() As String
        Get
            Return Me._SELLO_SAT
        End Get
    End Property

    Public ReadOnly Property CBB_IMAGE() As String
        Get
            Return Me._CBB_IMAGE
        End Get
    End Property

    'Public ReadOnly Property FOLIO_FISCAL_CANCELACION_SAT() As String
    '    Get
    '        Return Me._FOLIO_FISCAL_CANCELACION_SAT
    '    End Get
    'End Property

    Public ReadOnly Property TIMBRADO_CFDI() As String
        Get
            Return Me._TIMBRADO_CFDI
        End Get
    End Property

    Public ReadOnly Property ESTATUS_CANCELACION_CFDI() As String
        Get
            Return Me._ESTATUS_CANCELACION_CFDI
        End Get
    End Property

    Public ReadOnly Property TIMBRADO_DESCARTADO() As String
        Get
            Return Me._TIMBRADO_DESCARTADO
        End Get
    End Property

    Public ReadOnly Property VERSION_ESQUEMA_XML() As String
        Get
            Return Me._VERSION_ESQUEMA_XML
        End Get
    End Property

    Public ReadOnly Property TIENE_COMPLEMENTO_COMERCIO_EXTERIOR() As Boolean
        Get
            Return Me._TIENE_COMPLEMENTO_COMERCIO_EXTERIOR
        End Get
    End Property

    Public Property CODIGO_REGIMEN_FISCAL() As String
        Get
            Return Me._CODIGO_REGIMEN_FISCAL
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_REGIMEN_FISCAL = Value
        End Set
    End Property

    Public Property CODIGO_METODO_PAGO_EVENTO() As String
        Get
            Return Me._CODIGO_METODO_PAGO_EVENTO
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_METODO_PAGO_EVENTO = Value
        End Set
    End Property

    Public Property CODIGO_USO_CFDI() As String
        Get
            Return Me._CODIGO_USO_CFDI
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_USO_CFDI = Value
        End Set
    End Property

    Public ReadOnly Property RFC_RECEPTOR() As String
        Get
            Return Me._RFC_RECEPTOR
        End Get
    End Property

    Public Property CODIGO_MONEDA_SAT() As String
        Get
            Return Me._CODIGO_MONEDA_SAT
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_MONEDA_SAT = Value
        End Set
    End Property

    Public Property CONCEPTO_CANCELACION() As String
        Get
            Return Me._CONCEPTO_CANCELACION
        End Get
        Set(Value As String)
            Me._CONCEPTO_CANCELACION = Value
        End Set
    End Property

    Public Property TIENE_IEPS_DESGLOSADO() As Boolean
        Get
            Return Me._TIENE_IEPS_DESGLOSADO
        End Get
        Set(Value As Boolean)
            Me._TIENE_IEPS_DESGLOSADO = Value
        End Set
    End Property

    Public Property CODIGO_TIPO_RELACION_CFDI() As String
        Get
            Return Me._CODIGO_TIPO_RELACION_CFDI
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_TIPO_RELACION_CFDI = Value
        End Set
    End Property

    Public Property LISTA_CFDIS_RELACIONADOS() As String
        Get
            Return Me._LISTA_CFDIS_RELACIONADOS
        End Get
        Set(ByVal Value As String)
            Me._LISTA_CFDIS_RELACIONADOS = Value
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

    Public Property SUBTOTAL_USD() As Double
        Get
            Return Me._SUBTOTAL_USD
        End Get
        Set(ByVal Value As Double)
            Me._SUBTOTAL_USD = Value
        End Set
    End Property

    Public Property DESCUENTO_USD() As Double
        Get
            Return Me._DESCUENTO_USD
        End Get
        Set(ByVal Value As Double)
            Me._DESCUENTO_USD = Value
        End Set
    End Property

    ''------
    Public Property IMPUESTO_USD() As Double
        Get
            Return Me._IMPUESTO_USD
        End Get
        Set(ByVal Value As Double)
            Me._IMPUESTO_USD = Value
        End Set
    End Property

    Public Property TOTAL_SUSTITUCION_USD() As Double
        Get
            Return Me._TOTAL_SUSTITUCION_USD
        End Get
        Set(ByVal Value As Double)
            Me._TOTAL_SUSTITUCION_USD = Value
        End Set
    End Property

    Public Property IEPS_TOTAL_DESGLOSADO_USD() As Double
        Get
            Return Me._IEPS_TOTAL_DESGLOSADO_USD
        End Get
        Set(ByVal Value As Double)
            Me._IEPS_TOTAL_DESGLOSADO_USD = Value
        End Set
    End Property

    Public Property IEPS_TOTAL_YA_INCLUIDO_USD() As Double
        Get
            Return Me._IEPS_TOTAL_YA_INCLUIDO_USD
        End Get
        Set(ByVal Value As Double)
            Me._IEPS_TOTAL_YA_INCLUIDO_USD = Value
        End Set
    End Property

    Public Property RETENCION_IVA() As Decimal
        Get
            Return Me._RETENCION_IVA
        End Get
        Set(ByVal Value As Decimal)
            Me._RETENCION_IVA = Value
        End Set
    End Property

    Public Property RETENCION_IVA_USD() As Decimal
        Get
            Return Me._RETENCION_IVA_USD
        End Get
        Set(ByVal Value As Decimal)
            Me._RETENCION_IVA_USD = Value
        End Set
    End Property

    Public Property RETENCION_ISR() As Decimal
        Get
            Return Me._RETENCION_ISR
        End Get
        Set(ByVal Value As Decimal)
            Me._RETENCION_ISR = Value
        End Set
    End Property

    Public Property RETENCION_ISR_USD() As Decimal
        Get
            Return Me._RETENCION_ISR_USD
        End Get
        Set(ByVal Value As Decimal)
            Me._RETENCION_ISR_USD = Value
        End Set
    End Property

    Public Property FOLIO_DESCUENTO_ANTICIPO() As String
        Get
            Return Me._FOLIO_DESCUENTO_ANTICIPO
        End Get
        Set(ByVal Value As String)
            Me._FOLIO_DESCUENTO_ANTICIPO = Value
        End Set
    End Property

    Public Property TIENE_COMPLEMENTO_CARTA_PORTE() As Boolean
        Get
            Return Me._TIENE_COMPLEMENTO_CARTA_PORTE
        End Get
        Set(ByVal Value As Boolean)
            Me._TIENE_COMPLEMENTO_CARTA_PORTE = Value
        End Set
    End Property
#End Region

#Region "Propiedades de campos ligados a la tabla"
    Public ReadOnly Property Existe() As Boolean
        Get
            Return Me._Existe
        End Get
    End Property

    Public ReadOnly Property Nombre_Formato() As String
        Get
            Return Me._Nombre_Formato
        End Get
    End Property

    Public ReadOnly Property CODIGO_MODULO() As String
        Get
            Return "VTA"
        End Get
    End Property

    'CFD
    Public ReadOnly Property NOMBRE_METODO_PAGO() As String
        Get
            Return Me._NOMBRE_METODO_PAGO
        End Get
    End Property

    'CFD
    Public ReadOnly Property NOMBRE_REGIMEN_FISCAL() As String
        Get
            Return Me._NOMBRE_REGIMEN_FISCAL
        End Get
    End Property

    Public ReadOnly Property FELECTRONICA_CER() As String
        Get
            Return Me._FELECTRONICA_CER
        End Get
    End Property

    Public ReadOnly Property FELECTRONICA_KEY() As String
        Get
            Return Me._FELECTRONICA_KEY
        End Get
    End Property

    Public ReadOnly Property FELECTRONICA_CONTRASENIA_CLAVE_PRIVADA() As String
        Get
            Return Me._FELECTRONICA_CONTRASENIA_CLAVE_PRIVADA
        End Get
    End Property

    Public ReadOnly Property ES_FACTURA_EMBARQUE_EXTRANJERO() As Boolean
        Get
            Return Me._ES_FACTURA_EMBARQUE_EXTRANJERO
        End Get
    End Property

    Public ReadOnly Property TIENE_SERIES() As Boolean
        Get
            Return Me._TIENE_SERIES
        End Get
    End Property

    Public ReadOnly Property CODIGO_TIPO_DOCUMENTO() As String
        Get
            Return Me._CODIGO_TIPO_DOCUMENTO
        End Get
    End Property
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
#End Region

#End Region

#Region "Constructor y destructor"
    Public Sub New()
        Me._Nombre_Catalogo = "VENTA_GLOBAL"

        'Me._Nombre_Reporte = "RPT_FORMATO_FACTURA_ELECTRONICA_" & Strings.Right(Empresa_Sistema.BaseDatos, Len(Empresa_Sistema.BaseDatos) - Len("AGROCONTROL_"))

        Me._Conexion = New SqlConnection(Empresa_Sistema.conexion)

        oVentasDetalle = New Class_Ventas_Detalle
    End Sub

    Public Sub New(ByVal sfolioVenta As String, Optional ByVal bFiltrarPlaza As Boolean = True)
        Me.New()
        Try
            Me._FOLIO_VENTA = sfolioVenta
            If Me.Consultar(bFiltrarPlaza) = False Then
                'Throw New Exception("El documento de venta no existe.")
            Else
                Me._Existe = True
            End If
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "New", ex)
        End Try
    End Sub

    Protected Overrides Sub Finalize()
        'Me._Conexion.Dispose()
        MyBase.Finalize()
    End Sub
#End Region

#Region "Métodos y procedimientos"
    Public Function Grabar(ByVal sAccion As String) As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter

        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_VENTA_GRABA_GLOBAL"

            sqlParametro = .Parameters.Add("@FOLIO_VENTA", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_VENTA : sqlParametro.Direction = ParameterDirection.InputOutput
            sqlParametro = .Parameters.Add("@FECHA", SqlDbType.DateTime) : sqlParametro.Value = "" & Me._FECHA
            sqlParametro = .Parameters.Add("@FECHA_VENCIMIENTO", SqlDbType.DateTime) : sqlParametro.Value = "" & Me._FECHA_VENCIMIENTO
            sqlParametro = .Parameters.Add("@CODIGO_CLIENTE", SqlDbType.NVarChar, 8) : sqlParametro.Value = "" & Me._CODIGO_CLIENTE
            sqlParametro = .Parameters.Add("@CODIGO_DOCUMENTO", SqlDbType.NVarChar, 10) : sqlParametro.Value = "" & Me._CODIGO_DOCUMENTO
            sqlParametro = .Parameters.Add("@CODIGO_VENDEDOR", SqlDbType.SmallInt) : sqlParametro.Value = "" & Me._CODIGO_VENDEDOR
            sqlParametro = .Parameters.Add("@SUBTOTAL", SqlDbType.Decimal) : sqlParametro.Value = Me._SUBTOTAL
            sqlParametro = .Parameters.Add("@DESCUENTO", SqlDbType.Decimal) : sqlParametro.Value = Me._DESCUENTO
            sqlParametro = .Parameters.Add("@IMPUESTO", SqlDbType.Decimal) : sqlParametro.Value = Me._IMPUESTO
            sqlParametro = .Parameters.Add("@TOTAL", SqlDbType.Decimal) : sqlParametro.Value = Me._TOTAL
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO", SqlDbType.SmallInt) : sqlParametro.Value = "" & Me._CODIGO_USUARIO_GRABO
            sqlParametro = .Parameters.Add("@FOLIO_REFERENCIA", SqlDbType.NVarChar, 15) : sqlParametro.Value = "" & Me._FOLIO_REFERENCIA.ToUpper
            sqlParametro = .Parameters.Add("@FOLIO_REFERENCIA_USUARIO", SqlDbType.NVarChar, 15) : sqlParametro.Value = "" & Me._FOLIO_REFERENCIA_USUARIO.ToUpper
            sqlParametro = .Parameters.Add("@TIPO_DE_CAMBIO", SqlDbType.Decimal) : sqlParametro.Value = Me._TIPO_DE_CAMBIO
            sqlParametro = .Parameters.Add("@CODIGO_ALMACEN", SqlDbType.NVarChar, 4) : sqlParametro.Value = "" & Me._CODIGO_ALMACEN
            sqlParametro = .Parameters.Add("@CONCEPTO", SqlDbType.NVarChar, 4000) : sqlParametro.Value = "" & Me._CONCEPTO
            sqlParametro = .Parameters.Add("@CODIGO_PLAZA", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_PLAZA
            sqlParametro = .Parameters.Add("@CODIGO_TIPO_NEGOCIACION", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_TIPO_NEGOCIACION
            sqlParametro = .Parameters.Add("@IMPUESTO_PORCENTAJE", SqlDbType.Decimal) : sqlParametro.Value = Me._IMPUESTO_PORCENTAJE
            sqlParametro = .Parameters.Add("@ES_FACTURA_ELECTRONICA", SqlDbType.NVarChar, 1) : sqlParametro.Value = "" & Me._ES_FACTURA_ELECTRONICA
            sqlParametro = .Parameters.Add("@CODIGO_TIPO_MERCADO", SqlDbType.NVarChar, 4) : sqlParametro.Value = "" & Me._CODIGO_TIPO_MERCADO
            sqlParametro = .Parameters.Add("@TOTAL_SUSTITUCION", SqlDbType.Decimal) : sqlParametro.Value = Me._TOTAl_SUSTITUCION
            sqlParametro = .Parameters.Add("@TIPO_VENTA", SqlDbType.NVarChar, 5) : sqlParametro.Value = Me._TIPO_VENTA
            sqlParametro = .Parameters.Add("@ES_VENTA_PUBLICO_GENERAL", SqlDbType.NVarChar, 1) : sqlParametro.Value = "" & Me._ES_VENTA_PUBLICO_GENERAL
            'sqlParametro = .Parameters.Add("@FOLIO_EMBARQUE", SqlDbType.NVarChar, 15) : sqlParametro.Value = "" & Me._FOLIO_EMBARQUE
            sqlParametro = .Parameters.Add("@TOTAL_DOLARES", SqlDbType.Decimal) : sqlParametro.Value = Me._TOTAL_DOLARES
            sqlParametro = .Parameters.Add("@CODIGO_METODO_PAGO", SqlDbType.NVarChar, 2) : sqlParametro.Value = "" & Me._CODIGO_METODO_PAGO
            sqlParametro = .Parameters.Add("@NUMERO_CUENTA_PAGO", SqlDbType.NVarChar, 40) : sqlParametro.Value = "" & Me._NUMERO_CUENTA_PAGO
            sqlParametro = .Parameters.Add("@SUBTOTAL_USD", SqlDbType.Decimal) : sqlParametro.Value = Me._SUBTOTAL_USD
            sqlParametro = .Parameters.Add("@DESCUENTO_USD", SqlDbType.Decimal) : sqlParametro.Value = Me._DESCUENTO_USD
            sqlParametro = .Parameters.Add("@IEPS_TOTAL_DESGLOSADO", SqlDbType.Decimal) : sqlParametro.Value = Me._IEPS_TOTAL_DESGLOSADO
            sqlParametro = .Parameters.Add("@IEPS_TOTAL_YA_INCLUIDO", SqlDbType.Decimal) : sqlParametro.Value = Me._IEPS_TOTAL_YA_INCLUIDO
            sqlParametro = .Parameters.Add("@CODIGO_TIPO_CREDITO", SqlDbType.NVarChar, 2) : sqlParametro.Value = Me._CODIGO_TIPO_CREDITO
            sqlParametro = .Parameters.Add("@CODIGO_METODO_PAGO_EVENTO", SqlDbType.NVarChar, 4) : sqlParametro.Value = "" & Me._CODIGO_METODO_PAGO_EVENTO
            sqlParametro = .Parameters.Add("@CODIGO_USO_CFDI", SqlDbType.NVarChar, 4) : sqlParametro.Value = "" & Me._CODIGO_USO_CFDI
            sqlParametro = .Parameters.Add("@CODIGO_MONEDA_SAT", SqlDbType.NVarChar, 3) : sqlParametro.Value = "" & Me._CODIGO_MONEDA_SAT
            sqlParametro = .Parameters.Add("@TIENE_IEPS_DESGLOSADO", SqlDbType.Char, 1) : sqlParametro.Value = Convert.ToInt32(Me._TIENE_IEPS_DESGLOSADO)
            sqlParametro = .Parameters.Add("@CODIGO_TIPO_RELACION_CFDI", SqlDbType.NVarChar, 2) : sqlParametro.Value = Me._CODIGO_TIPO_RELACION_CFDI
            sqlParametro = .Parameters.Add("@LISTA_CFDIS_RELACIONADOS", SqlDbType.NVarChar, -1) : sqlParametro.Value = Me._LISTA_CFDIS_RELACIONADOS
            sqlParametro = .Parameters.Add("@IMPUESTO_USD", SqlDbType.Decimal) : sqlParametro.Value = Me._IMPUESTO_USD
            sqlParametro = .Parameters.Add("@TOTAL_SUSTITUCION_USD", SqlDbType.Decimal) : sqlParametro.Value = Me._TOTAL_SUSTITUCION_USD
            sqlParametro = .Parameters.Add("@IEPS_TOTAL_DESGLOSADO_USD", SqlDbType.Decimal) : sqlParametro.Value = Me._IEPS_TOTAL_DESGLOSADO_USD
            sqlParametro = .Parameters.Add("@IEPS_TOTAL_YA_INCLUIDO_USD", SqlDbType.Decimal) : sqlParametro.Value = Me._IEPS_TOTAL_YA_INCLUIDO_USD
            sqlParametro = .Parameters.Add("@RETENCION_IVA", SqlDbType.Decimal) : sqlParametro.Value = Me._RETENCION_IVA
            sqlParametro = .Parameters.Add("@RETENCION_IVA_USD", SqlDbType.Decimal) : sqlParametro.Value = Me._RETENCION_IVA_USD
            sqlParametro = .Parameters.Add("@RETENCION_ISR", SqlDbType.Decimal) : sqlParametro.Value = Me._RETENCION_ISR
            sqlParametro = .Parameters.Add("@RETENCION_ISR_USD", SqlDbType.Decimal) : sqlParametro.Value = Me._RETENCION_ISR_USD
            sqlParametro = .Parameters.Add("@CODIGO_REGIMEN_FISCAL", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_REGIMEN_FISCAL
            sqlParametro = .Parameters.Add("@TIENE_COMPLEMENTO_CARTA_PORTE", SqlDbType.Char, 1) : sqlParametro.Value = Convert.ToInt32(Me._TIENE_COMPLEMENTO_CARTA_PORTE).ToString
            sqlParametro = .Parameters.Add("@ACCION", SqlDbType.NVarChar, 20) : sqlParametro.Value = sAccion 'INSERTAR,ACTUALIZAR

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()

                If sAccion = "INSERTAR" Then
                    Me._FOLIO_VENTA = "" & .Parameters("@FOLIO_VENTA").Value.ToString 'Se asegura el cambio del folio
                End If

                bResultado = True

            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "Grabar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Function AfectaInventarios() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_VENTA_AFECTA_INVENTARIOS"

            sqlParametro = .Parameters.Add("@FOLIO_VENTA", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_VENTA
            sqlParametro = .Parameters.Add("@SUSTITUYE_REMISION", SqlDbType.Char, 1) : sqlParametro.Value = Me._SUSTITUYE_REMISION
            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "AfectaInventarios", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With

        Return bResultado
    End Function

    Public Function Enviado(ByVal sFolio As String) As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_DOCUMENTO_ENVIADO"

            sqlParametro = .Parameters.Add("@FOLIO_DOCUMENTO", SqlDbType.NVarChar, 15) : sqlParametro.Value = sFolio

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "Enviado", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Function Cancelar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_VENTA_CANCELA"

            sqlParametro = .Parameters.Add("@FOLIO_VENTA", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_VENTA
            sqlParametro = .Parameters.Add("@CODIGO_DOCUMENTO", SqlDbType.NVarChar, 10) : sqlParametro.Value = Me._CODIGO_DOCUMENTO
            sqlParametro = .Parameters.Add("@CODIGO_PLAZA", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Plaza
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Usuario
            sqlParametro = .Parameters.Add("@FECHA_CANCELACION", SqlDbType.DateTime) : sqlParametro.Value = Me._FECHA_CANCELACION
            sqlParametro = .Parameters.Add("@CONCEPTO_CANCELACION", SqlDbType.NVarChar, 120) : sqlParametro.Value = Me._CONCEPTO_CANCELACION.ToUpper

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "Cancelar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Function ActualizaPrecioTotalGlobal() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_VENTA_REMISIONES_ACTUALIZA_PRECIO_TOTAL_GLOBAL"

            sqlParametro = .Parameters.Add("@FOLIO_VENTA", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_VENTA
            sqlParametro = .Parameters.Add("@CODIGO_PLAZA", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Plaza
            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "ActualizaPrecioTotalGlobal", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Function ActualizaCostoTotalGlobal() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_VENTA_MODIFICA_COSTO_GLOBAL"

            sqlParametro = .Parameters.Add("@FOLIO_VENTA", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_VENTA

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "ActualizaCostoTotalGlobal", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Function Consultar(Optional ByVal bFiltrarPlaza As Boolean = True) As Boolean
        Dim bResultado As Boolean = False

        Dim sSQL As String = ""

        sSQL = "SELECT G.* " &
            ",U1.NOMBRE_USUARIO NOMBRE_USUARIO_GRABO,U2.NOMBRE_USUARIO NOMBRE_USUARIO_CANCELO,CFD.FELECTRONICA_CER,CFD.FELECTRONICA_KEY,CFD.CONTRASEÑA, " &
            "MP.NOMBRE_METODO_PAGO,RF.NOMBRE_REGIMEN_FISCAL," &
            "(SELECT MAX(FOLIO_EMBARQUE) FROM EMB_EMBARQUE_GLOBAL WHERE FOLIO_VENTA=G.FOLIO_VENTA) FOLIO_EMBARQUE,DOC.NOMBRE_FORMATO,DOC.ES_FACTURA_EMBARQUE_EXTRANJERO, " &
            "ISNULL((SELECT TOP 1 '1' FROM VENTA_DETALLE WHERE FOLIO_VENTA=G.FOLIO_VENTA AND LEN(LISTA_SERIES)>0),0) TIENE_SERIES,DOC.CODIGO_TIPO_DOCUMENTO " &
            "FROM VENTA_GLOBAL G " &
            "LEFT JOIN CFD_CAT_METODOS_PAGO MP ON(G.CODIGO_METODO_PAGO=MP.CODIGO_METODO_PAGO) " &
            "INNER JOIN CDF_CAT_TIPOS_REGIMENES_FISCALES RF ON(G.CODIGO_REGIMEN_FISCAL=RF.CODIGO_REGIMEN_FISCAL) " &
            "INNER JOIN SIS_USUARIOS U1 ON(G.CODIGO_USUARIO_GRABO=U1.CODIGO_USUARIO) " &
            "LEFT JOIN SIS_USUARIOS U2 ON(G.CODIGO_USUARIO_CANCELO=U2.CODIGO_USUARIO) " &
            "LEFT JOIN SIS_CFD_CATALOGO_CERTIFICADOS CFD ON(G.ID_SIS_CFD_CATALOGO_CERTIFICADOS=CFD.ID_SIS_CFD_CATALOGO_CERTIFICADOS) " &
            "INNER JOIN VW_SIS_CAT_DOCUMENTOS_EXTENDIDO DOC ON(G.CODIGO_DOCUMENTO=DOC.CODIGO_DOCUMENTO) " &
            "WHERE G.FOLIO_VENTA='" & Replace(Me._FOLIO_VENTA, "'", "''") & "' "

        If bFiltrarPlaza Then
            sSQL = sSQL & "AND G.CODIGO_PLAZA=" & Plaza.CODIGO_PLAZA & " "
        End If

        Dim cmd As New SqlCommand(sSQL, Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._ID_VENTA_GLOBAL = CInt(dReader("ID_VENTA_GLOBAL"))
                    Me._FOLIO_VENTA = "" & dReader("FOLIO_VENTA").ToString()
                    Me._FECHA = CDate(dReader("FECHA"))
                    Me._FECHA_VENCIMIENTO = CDate(dReader("FECHA_VENCIMIENTO"))
                    Me._FECHA_SERVIDOR = CDate(dReader("FECHA_SERVIDOR"))
                    Me._CODIGO_CLIENTE = "" & dReader("CODIGO_CLIENTE").ToString()
                    Me._CODIGO_DOCUMENTO = "" & dReader("CODIGO_DOCUMENTO").ToString()
                    Me._CODIGO_VENDEDOR = CInt(dReader("CODIGO_VENDEDOR"))
                    Me._FOLIO_VENTA = "" & dReader("FOLIO_VENTA").ToString()
                    Me._SUBTOTAL = CDec(dReader("SUBTOTAL"))
                    Me._IMPUESTO = CDec(dReader("IMPUESTO"))
                    Me._TOTAL = CDec(dReader("TOTAL"))
                    Me._DESCUENTO = CDec(dReader("DESCUENTO"))
                    Me._SALDO = CDec(dReader("SALDO"))
                    Me._COSTO = CDec(dReader("COSTO"))
                    Me._CONDICIONES_DE_PAGO = "" & dReader("CONDICIONES_DE_PAGO").ToString()
                    Me._ESTATUS_VENTA = "" & dReader("ESTATUS_VENTA").ToString()
                    Me._CODIGO_USUARIO_GRABO = CInt(dReader("CODIGO_USUARIO_GRABO"))
                    Me._FOLIO_REFERENCIA = "" & dReader("FOLIO_REFERENCIA").ToString()
                    Me._TIPO_DE_CAMBIO = CDec(dReader("TIPO_DE_CAMBIO"))
                    Me._CODIGO_ALMACEN = "" & dReader("CODIGO_ALMACEN").ToString()
                    Me._CONCEPTO = "" & dReader("CONCEPTO").ToString()
                    Me._CODIGO_PLAZA = (CInt(dReader("CODIGO_PLAZA")))
                    Me._CODIGO_TIPO_NEGOCIACION = CInt(dReader("CODIGO_TIPO_NEGOCIACION"))
                    Me._FOLIO_POLIZA = "" & dReader("FOLIO_POLIZA").ToString()
                    Me._IMPUESTO_PORCENTAJE = CDec(dReader("IMPUESTO_PORCENTAJE"))
                    Me._ES_FACTURA_ELECTRONICA = "" & dReader("ES_FACTURA_ELECTRONICA").ToString()
                    Me._FOLIO_NUMERICO = CInt("" & dReader("FOLIO_NUMERICO").ToString())
                    Me._SERIE = "" & dReader("SERIE").ToString()
                    'Me._IDCATALOGO_FOLIO_FELECTRONICA = CInt(valorNumerico(dReader("IDCATALOGO_FOLIO_FELECTRONICA").ToString))
                    Me._ID_SIS_CFD_CATALOGO_CERTIFICADOS = "" & dReader("ID_SIS_CFD_CATALOGO_CERTIFICADOS").ToString()
                    Me._CADENA_ORIGINAL = "" & dReader("CADENA_ORIGINAL").ToString()
                    Me._SELLO_DIGITAL = "" & dReader("SELLO_DIGITAL").ToString()
                    'Me._SELLO_REPROCESADO = "" & dReader("SELLO_REPROCESADO").ToString()
                    Me._CODIGO_TIPO_MERCADO = "" & dReader("CODIGO_TIPO_MERCADO").ToString()
                    Me._NOMBRE_USUARIO = "" & dReader("NOMBRE_USUARIO_GRABO").ToString()
                    Me._FOLIO_REFERENCIA_USUARIO = "" & dReader("FOLIO_REFERENCIA_USUARIO").ToString()
                    If Me._ESTATUS_VENTA = "C" Then
                        Me._CODIGO_USUARIO_CANCELO = CInt(dReader("CODIGO_USUARIO_CANCELO"))
                        Me._NOMBRE_USUARIO_CANCELO = dReader("NOMBRE_USUARIO_CANCELO").ToString
                        Me._FECHA_CANCELACION = CDate(dReader("FECHA_DE_CANCELACION"))
                        Me._FECHA_CANCELACION_SERVIDOR = CDate(dReader("FECHA_DE_CANCELACION_SERVIDOR"))
                    End If
                    Me._TIPO_VENTA = "" & dReader("TIPO_VENTA").ToString()
                    Me._SALDO_DOLARES = CDec(dReader("SALDO_DOLARES"))
                    Me._TOTAL_DOLARES = CDec(dReader("TOTAL_DOLARES"))
                    Me._SUBTOTAL_USD = CDec(dReader("SUBTOTAL_USD"))
                    Me._DESCUENTO_USD = CDec(dReader("DESCUENTO_USD"))
                    Me._ES_VENTA_PUBLICO_GENERAL = "" & dReader("ES_VENTA_PUBLICO_GENERAL").ToString()
                    Me._FOLIO_EMBARQUE = "" & dReader("FOLIO_EMBARQUE").ToString()
                    Me._CODIGO_METODO_PAGO = dReader("CODIGO_METODO_PAGO").ToString
                    Me._NOMBRE_METODO_PAGO = "" & dReader("NOMBRE_METODO_PAGO").ToString()
                    Me._NOMBRE_REGIMEN_FISCAL = "" & dReader("NOMBRE_REGIMEN_FISCAL").ToString()
                    Me._NUMERO_CUENTA_PAGO = "" & dReader("NUMERO_CUENTA_PAGO").ToString()
                    Me._FELECTRONICA_CER = "" & dReader("FELECTRONICA_CER").ToString
                    Me._FELECTRONICA_KEY = "" & dReader("FELECTRONICA_KEY").ToString
                    Me._FELECTRONICA_CONTRASENIA_CLAVE_PRIVADA = IIf(txtLEN("" & dReader("CONTRASEÑA").ToString) = True, Decrypt("" & dReader("CONTRASEÑA").ToString, "r7"), "").ToString
                    'Me._RETENCION = CDec(dReader("RETENCION"))
                    Me._ADDENDA = "" & dReader("ADDENDA").ToString
                    Me._FOLIO_FISCAL_SAT = "" & dReader("FOLIO_FISCAL_SAT").ToString
                    Me._FECHA_TIMBRADO_SAT = "" & dReader("FECHA_TIMBRADO_SAT").ToString
                    Me._NUMERO_SERIE_CERTIFICADO_SAT = "" & dReader("NUMERO_SERIE_CERTIFICADO_SAT").ToString
                    Me._SELLO_SAT = IIf(txtLEN("" & dReader("SELLO_SAT").ToString) = True, "" & dReader("SELLO_SAT").ToString, "").ToString
                    If txtLEN("" & dReader("CBB_IMAGE").ToString) = True Then
                        Me._CBB_IMAGE = "" & dReader("CBB_IMAGE").ToString
                    Else
                        Me._CBB_IMAGE = "" '& dReader("CBB_IMAGE").ToString
                    End If
                    Me._TIMBRADO_CFDI = "" & dReader("TIMBRADO_CFDI").ToString
                    Me._ESTATUS_CANCELACION_CFDI = "" & dReader("ESTATUS_CANCELACION_CFDI").ToString
                    Me._TIMBRADO_DESCARTADO = "" & dReader("TIMBRADO_DESCARTADO").ToString
                    Me._VERSION_ESQUEMA_XML = "" & dReader("VERSION_ESQUEMA_XML").ToString
                    Me._SERIE = "" & Trim(dReader("SERIE").ToString)
                    Me._TIENE_COMPLEMENTO_COMERCIO_EXTERIOR = CBool(dReader("TIENE_COMPLEMENTO_COMERCIO_EXTERIOR").ToString)
                    Me._CODIGO_REGIMEN_FISCAL = ("" & dReader("CODIGO_REGIMEN_FISCAL").ToString)
                    Me._ES_FACTURA_EMBARQUE_EXTRANJERO = CBool(dReader("ES_FACTURA_EMBARQUE_EXTRANJERO"))
                    Me._Nombre_Formato = "" & Trim(dReader("NOMBRE_FORMATO").ToString)
                    Me._IEPS_TOTAL_DESGLOSADO = CDbl(dReader("IEPS_TOTAL_DESGLOSADO"))
                    Me._IEPS_TOTAL_YA_INCLUIDO = CDbl(dReader("IEPS_TOTAL_YA_INCLUIDO"))
                    Me._TIENE_SERIES = CBool(dReader("TIENE_SERIES"))
                    Me._CODIGO_TIPO_CREDITO = "" & dReader("CODIGO_TIPO_CREDITO").ToString()
                    Me._CODIGO_METODO_PAGO_EVENTO = "" & dReader("CODIGO_METODO_PAGO_EVENTO").ToString
                    Me._CODIGO_USO_CFDI = "" & dReader("CODIGO_USO_CFDI").ToString
                    Me._RFC_RECEPTOR = "" & dReader("RFC_RECEPTOR").ToString
                    Me._CODIGO_MONEDA_SAT = "" & dReader("CODIGO_MONEDA_SAT").ToString
                    Me._CONCEPTO_CANCELACION = "" & dReader("CONCEPTO_CANCELACION").ToString
                    Me._TIENE_IEPS_DESGLOSADO = CBool(dReader("TIENE_IEPS_DESGLOSADO").ToString)
                    Me._CODIGO_TIPO_RELACION_CFDI = "" & dReader("CODIGO_TIPO_RELACION_CFDI").ToString
                    Me._IMPUESTO_USD = CDec(dReader("IMPUESTO_USD"))
                    Me._TOTAL_SUSTITUCION_USD = CDec(dReader("TOTAL_SUSTITUCION_USD"))
                    Me._IEPS_TOTAL_DESGLOSADO_USD = CDec(dReader("IEPS_TOTAL_DESGLOSADO_USD"))
                    Me._IEPS_TOTAL_YA_INCLUIDO_USD = CDec(dReader("IEPS_TOTAL_YA_INCLUIDO_USD"))
                    Me._RETENCION_IVA = CDec(dReader("RETENCION_IVA"))
                    Me._RETENCION_IVA_USD = CDec(dReader("RETENCION_IVA_USD"))
                    Me._RETENCION_ISR = CDec(dReader("RETENCION_ISR"))
                    Me._RETENCION_ISR_USD = CDec(dReader("RETENCION_ISR_USD"))
                    Me._FOLIO_DESCUENTO_ANTICIPO = "" & dReader("FOLIO_DESCUENTO_ANTICIPO").ToString
                    Me._CODIGO_TIPO_DOCUMENTO = dReader("CODIGO_TIPO_DOCUMENTO").ToString
                    Me._TIENE_COMPLEMENTO_CARTA_PORTE = CBool(dReader("TIENE_COMPLEMENTO_CARTA_PORTE"))

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

    Public Function ConsultarSinFiltrarPlaza() As Boolean
        Dim bResultado As Boolean = False

        Dim sSQL As String = ""

        sSQL = "SELECT G.* " &
            ",U1.NOMBRE_USUARIO NOMBRE_USUARIO_GRABO,U2.NOMBRE_USUARIO NOMBRE_USUARIO_CANCELO,CFD.FELECTRONICA_CER,CFD.FELECTRONICA_KEY,CFD.CONTRASEÑA, " &
            "MP.NOMBRE_METODO_PAGO,RF.NOMBRE_REGIMEN_FISCAL,G.SERIE," &
            "(SELECT MAX(FOLIO_EMBARQUE) FROM EMB_EMBARQUE_GLOBAL WHERE FOLIO_VENTA=G.FOLIO_VENTA) FOLIO_EMBARQUE,DOC.NOMBRE_FORMATO,DOC.ES_FACTURA_EMBARQUE_EXTRANJERO, " &
            "ISNULL((SELECT TOP 1 '1' FROM VENTA_DETALLE WHERE FOLIO_VENTA=G.FOLIO_VENTA AND LEN(LISTA_SERIES)>0),0) TIENE_SERIES " &
            "FROM VENTA_GLOBAL G " &
            "INNER JOIN CFD_CAT_METODOS_PAGO MP ON(G.CODIGO_METODO_PAGO=MP.CODIGO_METODO_PAGO) " &
            "INNER JOIN CDF_CAT_TIPOS_REGIMENES_FISCALES RF ON(G.CODIGO_REGIMEN_FISCAL=RF.CODIGO_REGIMEN_FISCAL) " &
            "INNER JOIN SIS_USUARIOS U1 ON(G.CODIGO_USUARIO_GRABO=U1.CODIGO_USUARIO) " &
            "LEFT JOIN SIS_USUARIOS U2 ON(G.CODIGO_USUARIO_CANCELO=U2.CODIGO_USUARIO) " &
            "LEFT JOIN SIS_CFD_CATALOGO_CERTIFICADOS CFD ON(G.ID_SIS_CFD_CATALOGO_CERTIFICADOS=CFD.ID_SIS_CFD_CATALOGO_CERTIFICADOS) " &
            "INNER JOIN VW_SIS_CAT_DOCUMENTOS_EXTENDIDO DOC ON(G.CODIGO_DOCUMENTO=DOC.CODIGO_DOCUMENTO) " &
            "WHERE G.FOLIO_VENTA='" & Replace(Me._FOLIO_VENTA, "'", "''") & "' "

        Dim cmd As New SqlCommand(sSQL, Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._ID_VENTA_GLOBAL = CInt(dReader("ID_VENTA_GLOBAL"))
                    Me._FOLIO_VENTA = "" & dReader("FOLIO_VENTA").ToString()
                    Me._FECHA = CDate(dReader("FECHA"))
                    Me._FECHA_VENCIMIENTO = CDate(dReader("FECHA_VENCIMIENTO"))
                    Me._FECHA_SERVIDOR = CDate(dReader("FECHA_SERVIDOR"))
                    Me._CODIGO_CLIENTE = "" & dReader("CODIGO_CLIENTE").ToString()
                    Me._CODIGO_DOCUMENTO = "" & dReader("CODIGO_DOCUMENTO").ToString()
                    Me._CODIGO_VENDEDOR = CInt(dReader("CODIGO_VENDEDOR"))
                    Me._FOLIO_VENTA = "" & dReader("FOLIO_VENTA").ToString()
                    Me._SUBTOTAL = CDec(dReader("SUBTOTAL"))
                    Me._IMPUESTO = CDec(dReader("IMPUESTO"))
                    Me._TOTAL = CDec(dReader("TOTAL"))
                    Me._DESCUENTO = CDec(dReader("DESCUENTO"))
                    Me._SALDO = CDec(dReader("SALDO"))
                    Me._COSTO = CDec(dReader("COSTO"))
                    Me._CONDICIONES_DE_PAGO = "" & dReader("CONDICIONES_DE_PAGO").ToString()
                    Me._ESTATUS_VENTA = "" & dReader("ESTATUS_VENTA").ToString()
                    Me._CODIGO_USUARIO_GRABO = CInt(dReader("CODIGO_USUARIO_GRABO"))
                    Me._FOLIO_REFERENCIA = "" & dReader("FOLIO_REFERENCIA").ToString()
                    Me._TIPO_DE_CAMBIO = CDec(dReader("TIPO_DE_CAMBIO"))
                    Me._CODIGO_ALMACEN = "" & dReader("CODIGO_ALMACEN").ToString()
                    Me._CONCEPTO = "" & dReader("CONCEPTO").ToString()
                    Me._CODIGO_PLAZA = (CInt(dReader("CODIGO_PLAZA")))
                    Me._CODIGO_TIPO_NEGOCIACION = CInt(dReader("CODIGO_TIPO_NEGOCIACION"))
                    Me._FOLIO_POLIZA = "" & dReader("FOLIO_POLIZA").ToString()
                    Me._IMPUESTO_PORCENTAJE = CDec(dReader("IMPUESTO_PORCENTAJE"))
                    Me._ES_FACTURA_ELECTRONICA = "" & dReader("ES_FACTURA_ELECTRONICA").ToString()
                    Me._FOLIO_NUMERICO = CInt("" & dReader("FOLIO_NUMERICO").ToString())
                    Me._SERIE = "" & dReader("SERIE").ToString()
                    'Me._IDCATALOGO_FOLIO_FELECTRONICA = CInt(valorNumerico(dReader("IDCATALOGO_FOLIO_FELECTRONICA").ToString))
                    Me._ID_SIS_CFD_CATALOGO_CERTIFICADOS = "" & dReader("ID_SIS_CFD_CATALOGO_CERTIFICADOS").ToString()
                    Me._CADENA_ORIGINAL = "" & dReader("CADENA_ORIGINAL").ToString()
                    Me._SELLO_DIGITAL = "" & dReader("SELLO_DIGITAL").ToString()
                    'Me._SELLO_REPROCESADO = "" & dReader("SELLO_REPROCESADO").ToString()
                    Me._CODIGO_TIPO_MERCADO = "" & dReader("CODIGO_TIPO_MERCADO").ToString()
                    Me._NOMBRE_USUARIO = "" & dReader("NOMBRE_USUARIO_GRABO").ToString()
                    Me._FOLIO_REFERENCIA_USUARIO = "" & dReader("FOLIO_REFERENCIA_USUARIO").ToString()
                    If Me._ESTATUS_VENTA = "C" Then
                        Me._CODIGO_USUARIO_CANCELO = CInt(dReader("CODIGO_USUARIO_CANCELO"))
                        Me._NOMBRE_USUARIO_CANCELO = dReader("NOMBRE_USUARIO_CANCELO").ToString
                        Me._FECHA_CANCELACION = CDate(dReader("FECHA_DE_CANCELACION"))
                        Me._FECHA_CANCELACION_SERVIDOR = CDate(dReader("FECHA_DE_CANCELACION_SERVIDOR"))
                    End If
                    Me._TIPO_VENTA = "" & dReader("TIPO_VENTA").ToString()
                    Me._SALDO_DOLARES = CDec(dReader("SALDO_DOLARES"))
                    Me._TOTAL_DOLARES = CDec(dReader("TOTAL_DOLARES"))
                    Me._SUBTOTAL_USD = CDec(dReader("SUBTOTAL_USD"))
                    Me._DESCUENTO_USD = CDec(dReader("DESCUENTO_USD"))
                    Me._ES_VENTA_PUBLICO_GENERAL = "" & dReader("ES_VENTA_PUBLICO_GENERAL").ToString()
                    Me._FOLIO_EMBARQUE = "" & dReader("FOLIO_EMBARQUE").ToString()
                    Me._CODIGO_METODO_PAGO = dReader("CODIGO_METODO_PAGO").ToString
                    Me._NOMBRE_METODO_PAGO = "" & dReader("NOMBRE_METODO_PAGO").ToString()
                    Me._NOMBRE_REGIMEN_FISCAL = "" & dReader("NOMBRE_REGIMEN_FISCAL").ToString()
                    Me._NUMERO_CUENTA_PAGO = "" & dReader("NUMERO_CUENTA_PAGO").ToString()
                    Me._FELECTRONICA_CER = "" & dReader("FELECTRONICA_CER").ToString
                    Me._FELECTRONICA_KEY = "" & dReader("FELECTRONICA_KEY").ToString
                    Me._FELECTRONICA_CONTRASENIA_CLAVE_PRIVADA = IIf(txtLEN("" & dReader("CONTRASEÑA").ToString) = True, Decrypt("" & dReader("CONTRASEÑA").ToString, "r7"), "").ToString
                    'Me._RETENCION = CDec(dReader("RETENCION"))
                    Me._ADDENDA = "" & dReader("ADDENDA").ToString
                    Me._FOLIO_FISCAL_SAT = "" & dReader("FOLIO_FISCAL_SAT").ToString
                    Me._FECHA_TIMBRADO_SAT = "" & dReader("FECHA_TIMBRADO_SAT").ToString
                    Me._NUMERO_SERIE_CERTIFICADO_SAT = "" & dReader("NUMERO_SERIE_CERTIFICADO_SAT").ToString
                    Me._SELLO_SAT = IIf(txtLEN("" & dReader("SELLO_SAT").ToString) = True, "" & dReader("SELLO_SAT").ToString, "").ToString
                    If txtLEN("" & dReader("CBB_IMAGE").ToString) = True Then
                        Me._CBB_IMAGE = "" & dReader("CBB_IMAGE").ToString
                    Else
                        Me._CBB_IMAGE = "" '& dReader("CBB_IMAGE").ToString
                    End If
                    Me._TIMBRADO_CFDI = "" & dReader("TIMBRADO_CFDI").ToString
                    Me._ESTATUS_CANCELACION_CFDI = "" & dReader("ESTATUS_CANCELACION_CFDI").ToString
                    Me._TIMBRADO_DESCARTADO = "" & dReader("TIMBRADO_DESCARTADO").ToString
                    Me._VERSION_ESQUEMA_XML = "" & dReader("VERSION_ESQUEMA_XML").ToString
                    Me._SERIE = "" & Trim(dReader("SERIE").ToString)
                    Me._TIENE_COMPLEMENTO_COMERCIO_EXTERIOR = CBool(dReader("TIENE_COMPLEMENTO_COMERCIO_EXTERIOR").ToString)
                    Me._CODIGO_REGIMEN_FISCAL = "" & Trim(dReader("CODIGO_REGIMEN_FISCAL").ToString)
                    Me._ES_FACTURA_EMBARQUE_EXTRANJERO = CBool(dReader("ES_FACTURA_EMBARQUE_EXTRANJERO"))
                    Me._Nombre_Formato = "" & Trim(dReader("NOMBRE_FORMATO").ToString)
                    Me._IEPS_TOTAL_DESGLOSADO = CDbl(dReader("IEPS_TOTAL_DESGLOSADO"))
                    Me._IEPS_TOTAL_YA_INCLUIDO = CDbl(dReader("IEPS_TOTAL_YA_INCLUIDO"))
                    Me._TIENE_SERIES = CBool(dReader("TIENE_SERIES"))
                    Me._CODIGO_TIPO_CREDITO = "" & dReader("CODIGO_TIPO_CREDITO").ToString()
                    Me._CODIGO_METODO_PAGO_EVENTO = "" & dReader("CODIGO_METODO_PAGO_EVENTO").ToString
                    Me._CODIGO_USO_CFDI = "" & dReader("CODIGO_USO_CFDI").ToString
                    Me._RFC_RECEPTOR = "" & dReader("RFC_RECEPTOR").ToString
                    Me._CODIGO_MONEDA_SAT = "" & dReader("CODIGO_MONEDA_SAT").ToString
                    Me._CONCEPTO_CANCELACION = "" & dReader("CONCEPTO_CANCELACION").ToString
                    Me._TIENE_IEPS_DESGLOSADO = CBool(dReader("TIENE_IEPS_DESGLOSADO").ToString)
                    Me._CODIGO_TIPO_RELACION_CFDI = "" & dReader("CODIGO_TIPO_RELACION_CFDI").ToString
                    Me._RETENCION_IVA = CDec(dReader("RETENCION_IVA"))

                    Me._IMPUESTO_USD = CDec(dReader("IMPUESTO_USD"))
                    Me._TOTAL_SUSTITUCION_USD = CDec(dReader("TOTAL_SUSTITUCION_USD"))
                    Me._IEPS_TOTAL_DESGLOSADO_USD = CDec(dReader("IEPS_TOTAL_DESGLOSADO_USD"))
                    Me._IEPS_TOTAL_YA_INCLUIDO_USD = CDec(dReader("IEPS_TOTAL_YA_INCLUIDO_USD"))
                    Me._RETENCION_IVA_USD = CDec(dReader("RETENCION_IVA_USD"))

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

    Public Function ObtenerDetalle(Optional ByVal bSinComentarios As Boolean = True) As DataTable
        Dim dTabla As New DataTable("detalle"), da As SqlDataAdapter
        Dim sSQL As String

        Try
            'sSQL = "SELECT R.CODIGO_ARTICULO, " &
            '    "CASE WHEN A.ES_SERIALIZABLE = '1' THEN 'SER' WHEN A.INVENTARIABLE= '1' THEN 'INV' ELSE 'NIV' END TIPO_CONTROL_INVENTARIO, " &
            '    "R.DESCRIPCION,R.CANTIDAD,R.PRECIO_SIN_DESCUENTO,R.PRECIO_TOTAL,R.UNIDAD_VENTA,ISNULL(R.CANTIDAD_KILOS,0) CANTIDAD_KILOS,ISNULL(R.PRECIO_KILOS,0) PRECIO_KILOS,R.IMPUESTO_PORCENTAJE,R.IMPORTE,ISNULL(R.IMPORTE_KILOS,0) IMPORTE_KILOS, " &
            '    "R.CUENTA_CONTABLE,R.IMPUESTO_IMPORTE,R.ID_VENTA_DETALLE,R.ES_PRODUCTO_KILOS,R.CODIGO_CENTRO_COSTO,CC.NOMBRE_CENTRO_COSTO,R.PRECIO_USD,R.IMPORTE_USD, " &
            '    "R.IEPS_PORCENTAJE,R.IEPS_UNITARIO,R.IEPS_IMPORTE,R.BASE_IEPS,R.BASE_IVA,R.COSTO,(R.PRECIO - R.COSTO) UTILIDAD_UNITARIA,((R.PRECIO-R.COSTO)*R.CANTIDAD) UTILIDAD_TOTAL,CASE WHEN R.PRECIO > 0 THEN (((R.PRECIO-R.COSTO)/R.PRECIO)*100) ELSE 0 END UTILIDA_PORCENTAJE, " &
            '    "R.ID_SIS_CAT_IMPUESTOS,R.GRADO_TOXICIDAD,R.DESCUENTO_UNITARIO,R.DESCUENTO_IMPORTE,R.PRECIO_SIN_DESCUENTO, " &
            '    "R.ID_SIS_CAT_IMPUESTOS_FLETE,F.PORCENTAJE RETENCION_IVA_PORCENTAJE,R.RETENCION_IVA_IMPORTE " &
            '    "FROM VENTA_DETALLE R " &
            '    "INNER JOIN CAT_ARTICULOS A ON(R.CODIGO_ARTICULO=A.CODIGO_ARTICULO) " &
            '    "INNER JOIN NOMINA_CAT_CENTROS_COSTOS CC ON(R.CODIGO_CENTRO_COSTO=CC.CODIGO_CENTRO_COSTO) " &
            '    "LEFT JOIN SIS_CAT_IMPUESTOS_FLETES F ON(R.ID_SIS_CAT_IMPUESTOS_FLETE=F.ID_SIS_CAT_IMPUESTOS_FLETE) " &
            '    "WHERE R.FOLIO_VENTA='" & Me._FOLIO_VENTA & "' " &
            '    IIf(bSinComentarios = True, " AND R.CODIGO_ARTICULO<>'-' ", " ").ToString &
            '    "ORDER BY R.ID_VENTA_DETALLE"

            '"R.COSTO,(R.PRECIO - R.COSTO) UTILIDAD_UNITARIA,((R.PRECIO-R.COSTO)*R.CANTIDAD) UTILIDAD_TOTAL,CASE WHEN R.PRECIO > 0 THEN (((R.PRECIO-R.COSTO)/R.PRECIO)*100) ELSE 0 END UTILIDA_PORCENTAJE, " &

            'Campos en la tabla PRECIO=Es el precio tecleado con descuento

            sSQL = "SELECT R.CODIGO_ARTICULO, " &
                "CASE WHEN A.ES_SERIALIZABLE = '1' THEN 'SER' WHEN A.INVENTARIABLE= '1' THEN 'INV' ELSE 'NIV' END TIPO_CONTROL_INVENTARIO," &
                "R.DESCRIPCION," &
                "R.CANTIDAD," &
                "R.PRECIO_SIN_DESCUENTO," &
                "R.PRECIO_SIN_DESCUENTO_USD," &
                "R.PRECIO_TOTAL," &
                "R.PRECIO_TOTAL_USD," &
                "R.UNIDAD_VENTA," &
                "ISNULL(R.CANTIDAD_KILOS,0) CANTIDAD_KILOS," &
                "ISNULL(R.PRECIO_KILOS,0) PRECIO_KILOS," &
                "R.IMPUESTO_PORCENTAJE," &
                "R.IMPORTE," &
                "R.IMPORTE_USD," &
                "ISNULL(R.IMPORTE_KILOS,0) IMPORTE_KILOS," &
                "R.CUENTA_CONTABLE," &
                "R.IMPUESTO_IMPORTE," &
                "R.IMPUESTO_IMPORTE_USD," &
                "R.ID_VENTA_DETALLE," &
                "R.ES_PRODUCTO_KILOS," &
                "R.CODIGO_CENTRO_COSTO," &
                "CC.NOMBRE_CENTRO_COSTO," &
                "R.IEPS_PORCENTAJE," &
                "R.IEPS_UNITARIO," &
                "R.IEPS_UNITARIO_USD," &
                "R.IEPS_IMPORTE," &
                "R.IEPS_IMPORTE_USD," &
                "R.BASE_IEPS," &
                "R.BASE_IEPS_USD," &
                "R.BASE_IVA," &
                "R.BASE_IVA_USD," &
                "R.COSTO," &
                "(R.PRECIO - R.COSTO) UTILIDAD_UNITARIA," &
                "((R.PRECIO-R.COSTO)*R.CANTIDAD) UTILIDAD_TOTAL," &
                "CASE WHEN R.PRECIO > 0 THEN (((R.PRECIO-R.COSTO)/R.PRECIO)*100) ELSE 0 END UTILIDAD_PORCENTAJE, " &
                "R.ID_SIS_CAT_IMPUESTOS," &
                "R.GRADO_TOXICIDAD," &
                "R.DESCUENTO_UNITARIO," &
                "R.DESCUENTO_UNITARIO_USD," &
                "R.DESCUENTO_IMPORTE," &
                "R.DESCUENTO_IMPORTE_USD," &
                "R.PRECIO_SIN_DESCUENTO," &
                "R.PRECIO_SIN_DESCUENTO_USD, " &
                "CASE WHEN R.RETENCION_IVA_PORCENTAJE>0 THEN '1' ELSE 0 END RETENCION_IVA_TIENE," &
                "R.RETENCION_IVA_PORCENTAJE," &
                "R.RETENCION_IVA_BASE," &
                "R.RETENCION_IVA_BASE_USD," &
                "R.RETENCION_IVA_IMPORTE," &
                "R.RETENCION_IVA_IMPORTE_USD," &
                "CASE WHEN R.RETENCION_ISR_PORCENTAJE>0 THEN '1' ELSE 0 END RETENCION_ISR_TIENE," &
                "R.RETENCION_ISR_PORCENTAJE," &
                "R.RETENCION_ISR_BASE," &
                "R.RETENCION_ISR_BASE_USD," &
                "R.RETENCION_ISR_IMPORTE," &
                "R.RETENCION_ISR_IMPORTE_USD " &
                "FROM VENTA_DETALLE R " &
                "INNER JOIN CAT_ARTICULOS A ON(R.CODIGO_ARTICULO=A.CODIGO_ARTICULO) " &
                "INNER JOIN NOMINA_CAT_CENTROS_COSTOS CC ON(R.CODIGO_CENTRO_COSTO=CC.CODIGO_CENTRO_COSTO) " &
                "WHERE R.FOLIO_VENTA='" & Me._FOLIO_VENTA & "' " &
                IIf(bSinComentarios = True, " AND R.CODIGO_ARTICULO<>'-' ", " ").ToString &
                "ORDER BY R.ID_VENTA_DETALLE"

            '"R.ID_SIS_CAT_IMPUESTOS_FLETE," &
            '"F.PORCENTAJE RETENCION_IVA_PORCENTAJE," &
            '"R.RETENCION_IVA_IMPORTE," &
            '"R.RETENCION_IVA_IMPORTE_USD " &
            '"LEFT JOIN SIS_CAT_IMPUESTOS_FLETES F ON(R.ID_SIS_CAT_IMPUESTOS_FLETE=F.ID_SIS_CAT_IMPUESTOS_FLETE) " &

            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dTabla)
            da.Dispose()

        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "ObtenerDetalle", ex)
        End Try
        Return dTabla
    End Function

    Public Function ObtenerDetalleParaCFDI(ByVal sFolioVenta As String, Optional ByVal bSinComentarios As Boolean = True) As DataTable
        Dim dTabla As New DataTable("detalle"), da As SqlDataAdapter
        Dim sSQL As String
        Dim DetallarSeries As String

        Try
            'sSQL = "SELECT R.CODIGO_ARTICULO,R.DESCRIPCION,R.CANTIDAD,R.PRECIO,R.PRECIO_TOTAL,R.PRECIO_TOTAL_USD,R.UNIDAD_VENTA,ISNULL(R.CANTIDAD_KILOS,0) CANTIDAD_KILOS,ISNULL(R.PRECIO_KILOS,0) PRECIO_KILOS,R.IMPUESTO_PORCENTAJE,R.IMPORTE," &
            '    "ISNULL(R.IMPORTE_KILOS,0) IMPORTE_KILOS,R.CUENTA_CONTABLE,R.IMPUESTO_IMPORTE,R.IMPUESTO_IMPORTE_USD,R.ID_VENTA_DETALLE,R.ES_PRODUCTO_KILOS,R.PRECIO_USD,R.IMPORTE_USD," &
            '    "A.CODIGO_PRODUCTO_SERVICIO,A.CODIGO_UNIDAD,R.IEPS_PORCENTAJE,R.IEPS_UNITARIO,R.IEPS_IMPORTE,R.IEPS_IMPORTE_USD,R.BASE_IEPS,R.BASE_IEPS_USD,R.BASE_IVA,R.BASE_IVA_USD," &
            '    "R.ID_SIS_CAT_IMPUESTOS,R.GRADO_TOXICIDAD,R.DESCUENTO_UNITARIO,R.DESCUENTO_IMPORTE,R.DESCUENTO_IMPORTE_USD," &
            '    "R.RETENCION_IVA_PORCENTAJE,R.RETENCION_IVA_BASE,R.RETENCION_IVA_BASE_USD,R.RETENCION_IVA_IMPORTE,R.RETENCION_IVA_IMPORTE_USD," &
            '    "R.RETENCION_ISR_PORCENTAJE,R.RETENCION_ISR_BASE,R.RETENCION_ISR_BASE_USD,R.RETENCION_ISR_IMPORTE,R.RETENCION_ISR_IMPORTE_USD " &
            '    "FROM VENTA_DETALLE R " &
            '    "INNER JOIN CAT_ARTICULOS A On(R.CODIGO_ARTICULO=A.CODIGO_ARTICULO) " &
            '    "WHERE R.FOLIO_VENTA='" & Me._FOLIO_VENTA & "' " &
            '    IIf(bSinComentarios = True, " AND R.CODIGO_ARTICULO<>'-' ", " ").ToString &
            '    "ORDER BY R.ID_VENTA_DETALLE"

            Dim sql As New Class_find("SELECT DETALLAR_SERIES_CFDI FROM CAT_CLIENTES C INNER JOIN VENTA_GLOBAL V ON(C.CODIGO_CLIENTE=V.CODIGO_CLIENTE) WHERE V.FOLIO_VENTA='" & sFolioVenta & "'")

            DetallarSeries = sql.Result1

            sSQL = "EXEC MP_VENTA_OBTIENE_DETALLE_PARA_CFDI @FOLIO_VENTA = '" & sFolioVenta & "', @CONCATENAR_SERIES_DESCRIPCION='" & DetallarSeries & "'"

            '"R.ID_SIS_CAT_IMPUESTOS_FLETE,R.RETENCION_IVA_IMPORTE,R.RETENCION_IVA_IMPORTE_USD,F.PORCENTAJE RETENCION_IVA_PORCENTAJE " &
            '"LEFT JOIN SIS_CAT_IMPUESTOS_FLETES F ON(R.ID_SIS_CAT_IMPUESTOS_FLETE=F.ID_SIS_CAT_IMPUESTOS_FLETE) " &

            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dTabla)
            da.Dispose()

        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "ObtenerDetalleParaCFDI", ex)
        End Try

        Return dTabla
    End Function

    Public Function ObtenerDetalleSoloDisponibles() As DataTable
        Dim dTabla As New DataTable("detalle"), da As SqlDataAdapter
        Dim sSQL As String

        Try
            'sSQL = "select CODIGO_ARTICULO,DESCRIPCION,DISPONIBLE,PRECIO,UNIDAD_VENTA,IMPUESTO_PORCENTAJE,IMPORTE,0,CUENTA_CONTABLE,IMPUESTO_IMPORTE,ID_VENTA_DETALLE from VENTA_DETALLE WHERE FOLIO_VENTA='" & Me._FOLIO_VENTA & "' AND DISPONIBLE>0 Order by ID_VENTA_DETALLE "

            sSQL = "SELECT R.CODIGO_ARTICULO, " &
            "CASE WHEN A.ES_SERIALIZABLE = '1' THEN 'SER' WHEN A.INVENTARIABLE= '1' THEN 'INV' ELSE 'NIV' END TIPO_CONTROL_INVENTARIO, " &
            "R.DESCRIPCION," &
            "R.DISPONIBLE," &
            "R.PRECIO_SIN_DESCUENTO," &
            "R.PRECIO_SIN_DESCUENTO_USD," &
            "R.PRECIO_TOTAL," &
            "R.PRECIO_TOTAL_USD," &
            "R.UNIDAD_VENTA," &
            "ISNULL(R.CANTIDAD_KILOS,0) CANTIDAD_KILOS," &
            "ISNULL(R.PRECIO_KILOS,0) PRECIO_KILOS," &
            "R.IMPUESTO_PORCENTAJE," &
            "R.IMPORTE," &
            "R.IMPORTE_USD, " &
            "ISNULL(R.IMPORTE_KILOS,0) IMPORTE_KILOS," &
            "R.CUENTA_CONTABLE," &
            "R.IMPUESTO_IMPORTE," &
            "R.IMPUESTO_IMPORTE_USD," &
            "R.ID_VENTA_DETALLE," &
            "R.ES_PRODUCTO_KILOS," &
            "R.CODIGO_CENTRO_COSTO," &
            "CC.NOMBRE_CENTRO_COSTO," &
            "R.IEPS_PORCENTAJE," &
            "R.IEPS_UNITARIO," &
            "R.IEPS_UNITARIO_USD," &
            "R.IEPS_IMPORTE," &
            "R.IEPS_IMPORTE_USD," &
            "R.BASE_IEPS," &
            "R.BASE_IEPS_USD," &
            "R.BASE_IVA," &
            "R.BASE_IVA_USD," &
            "R.COSTO," &
            "(R.PRECIO - R.COSTO) UTILIDAD_UNITARIA," &
            "((R.PRECIO-R.COSTO)*R.DISPONIBLE) UTILIDAD_TOTAL," &
            "CASE WHEN R.PRECIO > 0 THEN (((R.PRECIO-R.COSTO)/R.PRECIO)*100) ELSE 0 END UTILIDAD_PORCENTAJE," &
            "R.ID_SIS_CAT_IMPUESTOS," &
            "R.GRADO_TOXICIDAD," &
            "R.DESCUENTO_UNITARIO," &
            "R.DESCUENTO_UNITARIO_USD," &
            "R.DESCUENTO_IMPORTE," &
            "R.DESCUENTO_IMPORTE_USD," &
            "R.PRECIO," &
            "R.PRECIO_USD," &
            "CASE WHEN R.RETENCION_IVA_PORCENTAJE>0 THEN '1' ELSE 0 END RETENCION_IVA_TIENE," &
            "R.RETENCION_IVA_PORCENTAJE," &
            "R.RETENCION_IVA_BASE," &
            "R.RETENCION_IVA_BASE_USD," &
            "R.RETENCION_IVA_IMPORTE," &
            "R.RETENCION_IVA_IMPORTE_USD," &
            "CASE WHEN R.RETENCION_ISR_PORCENTAJE>0 THEN '1' ELSE 0 END RETENCION_ISR_TIENE," &
            "R.RETENCION_ISR_PORCENTAJE," &
            "R.RETENCION_ISR_BASE," &
            "R.RETENCION_ISR_BASE_USD," &
            "R.RETENCION_ISR_IMPORTE," &
            "R.RETENCION_ISR_IMPORTE_USD " &
            "FROM VENTA_DETALLE R " &
            "INNER JOIN CAT_ARTICULOS A ON(R.CODIGO_ARTICULO=A.CODIGO_ARTICULO) " &
            "INNER JOIN NOMINA_CAT_CENTROS_COSTOS CC ON(R.CODIGO_CENTRO_COSTO=CC.CODIGO_CENTRO_COSTO) " &
            "WHERE R.FOLIO_VENTA='" & Me._FOLIO_VENTA & "' AND R.DISPONIBLE>0 " &
            "ORDER BY R.ID_VENTA_DETALLE "

            '"R.ID_SIS_CAT_IMPUESTOS_FLETE," &
            '"F.PORCENTAJE RETENCION_IVA_PORCENTAJE," &
            '"R.RETENCION_IVA_IMPORTE," &
            '"R.RETENCION_IVA_IMPORTE_USD " &
            '"LEFT JOIN SIS_CAT_IMPUESTOS_FLETES F ON(R.ID_SIS_CAT_IMPUESTOS_FLETE=F.ID_SIS_CAT_IMPUESTOS_FLETE) " &

            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dTabla)
            da.Dispose()

        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "ObtenerDetalleSoloDisponibles", ex)
        End Try
        Return dTabla
    End Function

    Public Function ObtenerDetalleParaComercioExterior() As DataTable
        Dim dTabla As New DataTable("detalle"), da As SqlDataAdapter
        Dim sSQL As String

        Try
            'sSQL = "SELECT R.CODIGO_ARTICULO,R.DESCRIPCION,ISNULL(V.FRACCION_ARANCELARIA,'')FRACCION_ARANCELARIA,R.CANTIDAD,ROUND(R.PRECIO/G.TIPO_DE_CAMBIO,2) PRECIO_USD,(R.CANTIDAD*R.PRECIO)/G.TIPO_DE_CAMBIO IMPORTE_USD, " & _
            sSQL = "SELECT R.CODIGO_ARTICULO,R.DESCRIPCION,ISNULL(V.FRACCION_ARANCELARIA,'')FRACCION_ARANCELARIA,R.CANTIDAD,PRECIO_USD,IMPORTE_USD, " &
                "ISNULL(V.NOMBRE_CULTIVO,'') NOMBRE_CULTIVO,A.PESO " &
                "FROM VENTA_DETALLE R " &
                "INNER JOIN VENTA_GLOBAL G ON(R.FOLIO_VENTA=G.FOLIO_VENTA) " &
                "LEFT JOIN CAT_ARTICULOS A ON(R.CODIGO_ARTICULO=A.CODIGO_ARTICULO) " &
                "LEFT JOIN CAT_CULTIVOS V ON(A.CODIGO_CULTIVO=V.CODIGO_CULTIVO) " &
                "WHERE G.FOLIO_VENTA='" & Me._FOLIO_VENTA & "' " &
                "ORDER BY R.DESCRIPCION"

            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dTabla)
            da.Dispose()

        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "ObtenerDetalleParaComercioExterior", ex)
        End Try

        Return dTabla
    End Function

    Public Function ObtenerDetalleSeries() As DataTable
        Dim dTabla As New DataTable("detalle"), da As SqlDataAdapter
        Dim sSQL As String

        'Private igySeriePosicion As Short = 1
        'Private igySerieCodigo As Short = 2
        'Private igySerieDescripcion As Short = 3
        'Private igySerieIdInventarioLotesCostos As Short = 4
        'Private igySerieNumeroSerie As Short = 5


        sSQL = "SELECT 1 POSICION,I.CODIGO_ARTICULO,A.DESCRIPCION,S.ID_INVENTARIO_LOTES_COSTOS,C.NUMERO_SERIE " &
        "FROM INVENTARIO_MOVIMIENTOS_DETALLE I " &
        "INNER JOIN INVENTARIO_LOTES_SALIDAS S ON(I.ID_INVENTARIO_MOVIMIENTOS_DETALLE=S.ID_INVENTARIO_MOVIMIENTOS_DETALLE) " &
        "INNER JOIN INVENTARIO_LOTES_COSTOS C ON(S.ID_INVENTARIO_LOTES_COSTOS=C.ID_INVENTARIO_LOTES_COSTOS) " &
        "INNER JOIN CAT_ARTICULOS A ON(I.CODIGO_ARTICULO=A.CODIGO_ARTICULO) " &
        "WHERE I.FOLIO_MOVIMIENTO_INVENTARIO='" & Me._FOLIO_VENTA & "' AND LEN(C.NUMERO_SERIE)>0 " &
        "ORDER BY S.ID_INVENTARIO_LOTES_SALIDAS "

        Try
            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dTabla)
            da.Dispose()
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "ObtenerDetalleSeries", ex)
        End Try
        Return dTabla
    End Function

    Public Function ObtenerDetalleCambiarCosto() As DataTable
        Dim dTabla As New DataTable("detalle"), da As SqlDataAdapter
        Dim sSQL As String

        Try
            sSQL = "SELECT R.CODIGO_ARTICULO, " &
                "R.DESCRIPCION,R.CANTIDAD,R.COSTO,R.PRECIO_TOTAL,R.UNIDAD_VENTA,R.IMPUESTO_PORCENTAJE, " &
                "R.IMPUESTO_IMPORTE,R.IMPORTE,R.ID_VENTA_DETALLE " &
                "FROM VENTA_DETALLE R " &
                "INNER JOIN CAT_ARTICULOS A ON(R.CODIGO_ARTICULO=A.CODIGO_ARTICULO) " &
                "WHERE R.FOLIO_VENTA='" & Me._FOLIO_VENTA & "' " &
                "ORDER BY R.ID_VENTA_DETALLE"
            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dTabla)
            da.Dispose()

        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "ObtenerDetalle", ex)
        End Try
        Return dTabla

    End Function

    Public Function ObtenerDisponibleRenglon(ByVal iIdArticulo As Integer) As Decimal
        Try
            Dim Disponible As New Class_find("SELECT DISPONIBLE FROM VENTA_DETALLE WHERE ID_VENTA_DETALLE=" & iIdArticulo.ToString)
            Return valorNumericoD(Disponible.Result1)
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "ObtenerDisponibleRenglon", ex)
        End Try
    End Function

    Public Function ObtenerPrecioOriginal(ByVal iIdArticulo As Integer) As Decimal
        Try
            Dim Disponible As New Class_find("select PRECIO FROM VENTA_DETALLE WHERE ID_VENTA_DETALLE=" & iIdArticulo)
            Return CDec(valorNumerico(Disponible.Result1))
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "ObtenerPrecioOriginal", ex)
        End Try
    End Function

    Public Function ObtenerDetalleDisponiblesParaDevolucion() As DataTable
        Dim dTabla As New DataTable("detalle"), da As SqlDataAdapter
        Dim sSQL As String
        Try
            sSQL = "SELECT R.CODIGO_ARTICULO, " &
            "CASE WHEN A.ES_SERIALIZABLE = '1' THEN 'SER' WHEN A.INVENTARIABLE= '1' THEN 'INV' ELSE 'NIV' END TIPO_CONTROL_INVENTARIO, " &
            "R.DESCRIPCION,/*R.DISPONIBLE*/CAST(0 AS DECIMAL(18,3))DISPONIBLE,R.PRECIO,R.PRECIO_TOTAL,R.UNIDAD_VENTA,R.IMPUESTO_PORCENTAJE,R.IMPORTE," &
            "R.IMPUESTO_IMPORTE,R.ID_VENTA_DETALLE," &
            "R.IEPS_PORCENTAJE,R.IEPS_UNITARIO,R.IEPS_IMPORTE,R.BASE_IEPS,R.BASE_IVA, " &
            "R.ID_SIS_CAT_IMPUESTOS,R.GRADO_TOXICIDAD,R.RETENCION_IVA_BASE,R.RETENCION_IVA_IMPORTE,R.RETENCION_IVA_PORCENTAJE,R.RETENCION_ISR_BASE,R.RETENCION_ISR_IMPORTE,R.RETENCION_ISR_PORCENTAJE " &
            "FROM VENTA_DETALLE R " &
            "INNER JOIN CAT_ARTICULOS A ON(R.CODIGO_ARTICULO=A.CODIGO_ARTICULO) " &
            "WHERE R.FOLIO_VENTA='" & Me._FOLIO_VENTA & "' AND R.DISPONIBLE>0 " &
            "ORDER BY R.ID_VENTA_DETALLE "

            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dTabla)
            da.Dispose()

        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "ObtenerDetalleDisponiblesParaDevolucion", ex)
        End Try
        Return dTabla
    End Function

    Public Function ObtenerRemisionesCliente(ByVal sCodigoCliente As String) As DataTable
        Dim dTabla As New DataTable("remisiones"), da As SqlDataAdapter
        Dim sSQL As String

        sSQL = "SELECT V.FOLIO_VENTA,DBO.FN_FECHA_SIN_HORA(V.FECHA),V.TOTAL,V.CODIGO_MONEDA_SAT FROM VENTA_GLOBAL V INNER JOIN SIS_CAT_DOCUMENTOS D ON(V.CODIGO_DOCUMENTO=D.CODIGO_DOCUMENTO) " & _
               "WHERE D.CODIGO_TIPO_DOCUMENTO = 'REM' AND V.ESTATUS_VENTA = 'A' AND V.CODIGO_CLIENTE = '" & sCodigoCliente & "' ORDER BY V.FECHA "

        Try
            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dTabla)
            da.Dispose()
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "ObtenerRemisionesCliente", ex)
        End Try
        Return dTabla
    End Function

    Public Function ObtenerDetalleVariasRemisiones(ByVal sFoliosRemisiones As String) As DataTable
        Dim dTabla As New DataTable("detalleRemisiones"), da As SqlDataAdapter
        Dim sSQL As String

        Try

            sSQL = "SELECT R.CODIGO_ARTICULO, " &
                   "CASE WHEN MAX(A.ES_SERIALIZABLE) = '1' THEN 'SER' WHEN MAX(A.INVENTARIABLE)= '1' THEN 'INV' ELSE 'NIV' END TIPO_CONTROL_INVENTARIO," &
                   "MAX(R.DESCRIPCION) DESCRIPCION," &
                   "SUM(R.CANTIDAD) CANTIDAD," &
                   "MAX(R.PRECIO_SIN_DESCUENTO) PRECIO_SIN_DESCUENTO," &
                   "MAX(R.PRECIO_SIN_DESCUENTO_USD) PRECIO_SIN_DESCUENTO_USD," &
                   "MAX(R.PRECIO_TOTAL) PRECIO_TOTAL," &
                   "MAX(R.PRECIO_TOTAL_USD) PRECIO_TOTAL_USD," &
                   "MAX(R.UNIDAD_VENTA) UNIDAD_VENTA," &
                   "ISNULL(SUM(R.CANTIDAD_KILOS),0) CANTIDAD_KILOS," &
                   "ISNULL(MAX(R.PRECIO_KILOS),0) PRECIO_KILOS," &
                   "MAX(R.IMPUESTO_PORCENTAJE) IMPUESTO_PORCENTAJE," &
                   "SUM(R.IMPORTE) IMPORTE," &
                   "SUM(R.IMPORTE_USD) IMPORTE_USD," &
                   "ISNULL(SUM(R.IMPORTE_KILOS),0) IMPORTE_KILOS," &
                   "(SELECT CUENTA_CONTABLE_VENTAS FROM SIS_PLAZAS WHERE CODIGO_PLAZA=" & Plaza.CODIGO_PLAZA & ") CUENTA_CONTABLE," &
                   "SUM(R.IMPUESTO_IMPORTE) IMPUESTO_IMPORTE," &
                   "SUM(R.IMPUESTO_IMPORTE_USD) IMPUESTO_IMPORTE_USD," &
                   "'' ID_VENTA_DETALLE," &
                   "MAX(R.ES_PRODUCTO_KILOS) ES_PRODUCTO_KILOS," &
                   "MAX(R.CODIGO_CENTRO_COSTO) CODIGO_CENTRO_COSTO," &
                   "MAX(CC.NOMBRE_CENTRO_COSTO) NOMBRE_CENTRO_COSTO," &
                   "MAX(R.IEPS_PORCENTAJE) IEPS_PORCENTAJE," &
                   "MAX(R.IEPS_UNITARIO) IEPS_UNITARIO," &
                   "MAX(R.IEPS_UNITARIO_USD) IEPS_UNITARIO_USD," &
                   "SUM(R.IEPS_IMPORTE) IEPS_IMPORTE," &
                   "SUM(R.IEPS_IMPORTE_USD) IEPS_IMPORTE_USD," &
                   "SUM(R.BASE_IEPS) BASE_IEPS," &
                   "SUM(R.BASE_IEPS_USD) BASE_IEPS_USD," &
                   "SUM(R.BASE_IVA) BASE_IVA," &
                   "SUM(R.BASE_IVA_USD) BASE_IVA_USD," &
                   "MAX(R.COSTO) COSTO," &
                   "(R.PRECIO - MAX(R.COSTO)) UTILIDAD_UNITARIA," &
                   "((R.PRECIO-MAX(R.COSTO))*SUM(R.CANTIDAD)) UTILIDAD_TOTAL," &
                   "CASE WHEN R.PRECIO > 0 THEN (((R.PRECIO-MAX(R.COSTO))/R.PRECIO)*100) ELSE 0 END UTILIDAD_PORCENTAJE," &
                   "MAX(R.ID_SIS_CAT_IMPUESTOS) ID_SIS_CAT_IMPUESTOS," &
                   "MAX(R.GRADO_TOXICIDAD) GRADO_TOXICIDAD," &
                   "MAX(R.DESCUENTO_UNITARIO) DESCUENTO_UNITARIO," &
                   "MAX(R.DESCUENTO_UNITARIO_USD) DESCUENTO_UNITARIO_USD," &
                   "SUM(R.DESCUENTO_IMPORTE) DESCUENTO_IMPORTE," &
                   "SUM(R.DESCUENTO_IMPORTE_USD) DESCUENTO_IMPORTE_USD," &
                   "MAX(R.PRECIO_SIN_DESCUENTO) PRECIO_SIN_DESCUENTO," &
                   "MAX(R.PRECIO_SIN_DESCUENTO_USD) PRECIO_SIN_DESCUENTO_USD, " &
                   "CASE WHEN MAX(R.RETENCION_IVA_PORCENTAJE)>0 THEN '1' ELSE 0 END RETENCION_IVA_TIENE/*ESTE NO ES UN CAMPO DE VENTA_DETALLE POR ESO SE DETERMINA*/," &
                   "MAX(R.RETENCION_IVA_PORCENTAJE) RETENCION_IVA_PORCENTAJE," &
                   "SUM(R.RETENCION_IVA_BASE) RETENCION_IVA_BASE," &
                   "SUM(R.RETENCION_IVA_BASE_USD) RETENCION_IVA_BASE_USD," &
                   "SUM(R.RETENCION_IVA_IMPORTE) RETENCION_IVA_IMPORTE," &
                   "SUM(R.RETENCION_IVA_IMPORTE_USD) RETENCION_IVA_IMPORTE_USD," &
                   "CASE WHEN MAX(R.RETENCION_ISR_PORCENTAJE)>0 THEN '1' ELSE 0 END RETENCION_ISR_TIENE/*ESTE NO ES UN CAMPO DE VENTA_DETALLE POR ESO SE DETERMINA*/," &
                   "MAX(R.RETENCION_ISR_PORCENTAJE) RETENCION_ISR_PORCENTAJE," &
                   "SUM(R.RETENCION_ISR_BASE) RETENCION_ISR_BASE," &
                   "SUM(R.RETENCION_ISR_BASE_USD) RETENCION_ISR_BASE_USD," &
                   "SUM(R.RETENCION_ISR_IMPORTE) RETENCION_ISR_IMPORTE," &
                   "SUM(R.RETENCION_ISR_IMPORTE_USD) RETENCION_ISR_IMPORTE_USD " &
                   "FROM VENTA_DETALLE R " &
                   "INNER JOIN CAT_ARTICULOS A ON(R.CODIGO_ARTICULO=A.CODIGO_ARTICULO) " &
                   "INNER JOIN NOMINA_CAT_CENTROS_COSTOS CC ON(R.CODIGO_CENTRO_COSTO=CC.CODIGO_CENTRO_COSTO) " &
                   "WHERE R.FOLIO_VENTA IN(" & sFoliosRemisiones & ") " &
                   "GROUP BY R.CODIGO_ARTICULO,R.PRECIO ORDER BY MAX(R.DESCRIPCION) "

            '"MAX(R.ID_SIS_CAT_IMPUESTOS_FLETE) ID_SIS_CAT_IMPUESTOS_FLETE," &
            '"MAX(F.PORCENTAJE) RETENCION_IVA_PORCENTAJE," &
            '"SUM(R.RETENCION_IVA_IMPORTE) RETENCION_IVA_IMPORTE," &
            '"SUM(R.RETENCION_IVA_IMPORTE_USD) RETENCION_IVA_IMPORTE_USD " &
            '"LEFT JOIN SIS_CAT_IMPUESTOS_FLETES F ON(R.ID_SIS_CAT_IMPUESTOS_FLETE=F.ID_SIS_CAT_IMPUESTOS_FLETE) " &

            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dTabla)
            da.Dispose()

        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "ObtenerDetalleVariasRemisiones", ex)
        End Try
        Return dTabla
    End Function

    Public Function ObtenerRelacionFacturasRemisiones(ByVal sFolioFactura As String) As DataTable
        Dim dTabla As New DataTable("RelacionFacturasRemisiones"), da As SqlDataAdapter
        Dim sSQL As String

        Try

            sSQL = "SELECT G.FOLIO_VENTA,DBO.FN_FECHA_SIN_HORA(G.FECHA) FECHA,G.TOTAL,G.CODIGO_MONEDA_SAT " & _
                   "FROM VENTAS_RELACION_FACTURAS_REMISIONES R INNER JOIN VENTA_GLOBAL G ON(R.FOLIO_REMISION=G.FOLIO_VENTA) WHERE R.FOLIO_FACTURA='" & sFolioFactura & "' ORDER BY FECHA"

            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dTabla)
            da.Dispose()

        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "ObtenerRelacionFacturasRemisiones", ex)
        End Try
        Return dTabla
    End Function

    Public Function EsClienteDeContado(ByVal sCuentaContable As String, ByVal sCodigoZona As String) As Boolean
        Dim bResultado As Boolean = False
        Try
            Dim sSql As String = ""

            If sCodigoZona <> "1" Then
                sSql = "SELECT 1 FROM SIS_PLAZAS WHERE CODIGO_PLAZA=" & Usuario.Codigo_Plaza.ToString & " AND CUENTA_CONTABLE_CONTADO_EXPORTACION='" & sCuentaContable & "'"
            Else
                sSql = "SELECT 1 FROM SIS_PLAZAS WHERE CODIGO_PLAZA=" & Usuario.Codigo_Plaza.ToString & " AND CUENTA_CONTABLE_CONTADO_NACIONAL='" & sCuentaContable & "'"
            End If
            Dim sql As New Class_find(sSql)

            If sql.Result1 <> "" Then
                bResultado = True
            Else
                bResultado = False
            End If
            sql = Nothing
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "EsClienteDeContado", ex)
        End Try

        Return bResultado
    End Function

    Public Function BusquedaVisual_PorFolio() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de ventas por Código."
        f.sCampo = "VG.FOLIO_VENTA"
        f.sOrder = "VG.FECHA"
        f.sTable = "VENTA_GLOBAL"
        f.sQl = "SELECT VG.FOLIO_VENTA,CTE.NOMBRE_CLIENTE,VG.CODIGO_CLIENTE,DBO.FN_FORMAT_FECHA_CORTO(VG.FECHA) FECHA FROM VENTA_GLOBAL VG INNER JOIN CAT_CLIENTES CTE ON(VG.CODIGO_CLIENTE=CTE.CODIGO_CLIENTE) WHERE VG.CODIGO_PLAZA=" & Plaza.CODIGO_PLAZA & " AND "
        f.Inicia("")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "BusquedaVisual_PorFolio", ex)
        End Try
        Return Resultado
    End Function

    Public Function BusquedaVisual_Remiciones_PorCodigo() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de ventas por Código."
        f.sCampo = "FOLIO_VENTA"
        f.sOrder = "FECHA"
        f.sTable = "VENTA_GLOBAL"
        f.sQl = "Select FOLIO_VENTA,FECHA,CODIGO_CLIENTE From VENTA_GLOBAL Where CODIGO_DOCUMENTO LIKE 'REM%' and 1=1 AND CODIGO_PLAZA=" & Plaza.CODIGO_PLAZA & " AND "
        f.Inicia("")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "BusquedaVisual_Remiciones_PorCodigo", ex)
        End Try
        Return Resultado
    End Function

    Public Function BusquedaVisual_PorDescripcion() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de ventas por referencia."
        f.sCampo = "FOLIO_REFERENCIA"
        f.sOrder = "FECHA"
        f.sTable = "VENTA_GLOBAL"
        f.sQl = "Select FOLIO_VENTA,FECHA,CODIGO_CLIENTE From VENTA_GLOBAL Where 1=1 AND CODIGO_PLAZA=" & Plaza.CODIGO_PLAZA & " AND "
        f.Inicia("")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "BusquedaVisual_PorDescripcion", ex)
        End Try
        Return Resultado
    End Function

    Public Function GeneraFolioVentas() As String
        Dim sResultado As String = ""
        Dim Conexion As New SqlConnection(Empresa_Sistema.conexion)
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter

        With cmd
            .Connection = Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_UTILERIAS_GENERA_FOLIO_DOCUMENTO"

            sqlParametro = .Parameters.Add("@CODIGO_DOCUMENTO", SqlDbType.NVarChar, 10) : sqlParametro.Value = Me._CODIGO_DOCUMENTO
            sqlParametro = .Parameters.Add("@VFOLIO", SqlDbType.NVarChar, 15) : sqlParametro.Direction = ParameterDirection.Output
            sqlParametro = .Parameters.Add("@FOLIO_NUMERICO", SqlDbType.BigInt) : sqlParametro.Direction = ParameterDirection.Output

            Try
                Conexion.Open()
                .ExecuteNonQuery()

                sResultado = "" & .Parameters("@VFOLIO").Value.ToString
                Me._FOLIO_NUMERICO = CInt(.Parameters("@FOLIO_NUMERICO").Value.ToString)
            Catch ex As Exception
                HandleError(Me.Nombre_Catalogo, "GeneraFolioVentas", ex)
            Finally
                Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With

        Return sResultado
    End Function

    Public Function AplicarPoliza() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CONTABILIDAD_ASIENTO_REPETITIVO_VENTA"

            sqlParametro = .Parameters.Add("@FOLIO_VENTA", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_VENTA
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

    Public Function AfectaSustitucionRemision() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_VENTA_AFECTA_SUSTITUCION_REMISION"

            sqlParametro = .Parameters.Add("@FOLIO_REMISION", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_REFERENCIA
            sqlParametro = .Parameters.Add("@FOLIO_FACTURA", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_VENTA
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Usuario

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "AfectaSustitucionRemision", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With

        Return bResultado
    End Function

    Public Function AfectaSustitucionCotizacion() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_VENTA_AFECTA_SUSTITUCION_COTIZACION"

            sqlParametro = .Parameters.Add("@FOLIO_COTIZACION", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_REFERENCIA
            sqlParametro = .Parameters.Add("@FOLIO_FACTURA", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_VENTA
            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "AfectaSustitucionCotizacion", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With

        Return bResultado
    End Function

    Public Function DesafectaSustitucionCotizacion() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_VENTA_DESAFECTA_SUSTITUCION_COTIZACION"

            sqlParametro = .Parameters.Add("@FOLIO_COTIZACION", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_REFERENCIA
            sqlParametro = .Parameters.Add("@FOLIO_FACTURA", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_VENTA
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Usuario
            sqlParametro = .Parameters.Add("@FECHA_CANCELACION", SqlDbType.DateTime) : sqlParametro.Value = Me._FECHA_CANCELACION
            sqlParametro = .Parameters.Add("@CONCEPTO_CANCELACION", SqlDbType.NVarChar, 120) : sqlParametro.Value = Me._CONCEPTO_CANCELACION
            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "DesafectaSustitucionCotizacion", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With

        Return bResultado
    End Function

    Public Function DesafectaSustitucionRemision() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_VENTA_DESAFECTA_SUSTITUCION_REMISION"

            sqlParametro = .Parameters.Add("@FOLIO_REMISION", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_REFERENCIA
            sqlParametro = .Parameters.Add("@FOLIO_FACTURA", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_VENTA
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Usuario
            sqlParametro = .Parameters.Add("@FECHA_CANCELACION", SqlDbType.DateTime) : sqlParametro.Value = Me._FECHA_CANCELACION
            sqlParametro = .Parameters.Add("@CONCEPTO_CANCELACION", SqlDbType.NVarChar, 120) : sqlParametro.Value = Me._CONCEPTO_CANCELACION
            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "DesafectaSustitucionRemision", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With

        Return bResultado
    End Function

    Public Function ConsumeReglas() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_SISADMIN_CLIENTES_AFECTA_IMPORTES_RESULTANTES_REGLA_CXC"

            sqlParametro = .Parameters.Add("@CODIGO_CLIENTE", SqlDbType.NVarChar, 8) : sqlParametro.Value = "" & Me._CODIGO_CLIENTE
            sqlParametro = .Parameters.Add("@VENTA", SqlDbType.Decimal) : sqlParametro.Value = Me.VENTA_TOTAL
            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "ConsumeReglas", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With

        Return bResultado
    End Function

    Public Sub NuevoRenglon()
        Me.oVentasDetalle = New Class_Ventas_Detalle
    End Sub

    Public Function BusquedaVisual_PorCliente(Optional ByVal sCodigoCliente As String = "") As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de ventas del cliente."
        f.sCampo = "CODIGO_CLIENTE"
        f.sOrder = "FECHA"
        f.sTable = "VENTA_GLOBAL"
        f.sQl = "SELECT V.FOLIO_VENTA,N.NOMBRE_TIPO_NEGOCIACION,V.FECHA,V.TOTAL FROM VENTA_GLOBAL V " &
        "INNER JOIN VENTAS_CAT_TIPOS_NEGOCIACION N ON(V.CODIGO_TIPO_NEGOCIACION=N.CODIGO_TIPO_NEGOCIACION) " &
        "WHERE V.CODIGO_CLIENTE='" & sCodigoCliente.ToString & "' AND " 'V.CODIGO_TIPO_NEGOCIACION=2 And "

        f.Inicia("")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            End If
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "BusquedaVisual_PorCliente", ex)
        End Try
        Return Resultado
    End Function

    Public Function BusquedaVisualFacturasCliente(ByVal sCodigoCliente As String) As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de ventas del cliente."
        f.sCampo = "V.FOLIO_VENTA"
        f.sOrder = "V.FECHA DESC"
        f.sTable = "VENTA_GLOBAL"
        f.sQl = "SELECT V.FOLIO_VENTA,V.ESTATUS_VENTA,DBO.FN_FORMAT_FECHA_CORTO(V.FECHA)FECHA,V.CONCEPTO,DBO.fn_FormatoNum(V.TOTAL,1,2) TOTAL,V.FOLIO_FISCAL_SAT FROM VENTA_GLOBAL V " &
        "WHERE V.CODIGO_CLIENTE='" & sCodigoCliente.ToString & "' AND "
        f.arrayWidthColumns = New Integer() {100, 60, 70, 250, 100, 300}
        f.Inicia("")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            End If
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "BusquedaVisualFacturasCliente", ex)
        End Try
        Return Resultado
    End Function

    Public Function BusquedaVisualFacturasClienteParaRelacionarCFDIs(ByVal sCodigoCliente As String) As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de ventas del cliente."
        f.sCampo = "V.FOLIO_VENTA"
        f.sOrder = "V.FECHA DESC"
        f.sTable = "VENTA_GLOBAL"
        f.sQl = "SELECT V.FOLIO_VENTA,V.ESTATUS_VENTA,DBO.FN_FORMAT_FECHA_CORTO(V.FECHA)FECHA,V.CONCEPTO,DBO.fn_FormatoNum(V.TOTAL,1,2) TOTAL,V.FOLIO_FISCAL_SAT " +
        "FROM VENTA_GLOBAL V " +
        "WHERE V.CODIGO_CLIENTE='" & sCodigoCliente.ToString & "' AND LEN(V.FOLIO_FISCAL_SAT)>0 AND V.ESTATUS_VENTA='A' AND " 'Busca sólo ventas timbradas.
        f.arrayWidthColumns = New Integer() {100, 60, 70, 250, 100, 300}
        f.Inicia("")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            End If
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "BusquedaVisualFacturasClienteParaRelacionarCFDIs", ex)
        End Try
        Return Resultado
    End Function

    'Public Function ObtenerTopTenCliente() As DataTable
    '    Dim dt As New DataTable
    '    Try

    '        Dim da As New SqlDataAdapter("MP_RPT_VENTAS_RESUMEN_EXTRANJERO_NACIONAL_CLIENTE", Me._Conexion)
    '        da.SelectCommand.CommandType = CommandType.StoredProcedure

    '        With da.SelectCommand
    '            .Parameters.Add("@FECHA1_SEMANA", Me._fe)
    '            .Parameters.Add("@FECHA2_SEMANA", Me.CboSemana2.Text)
    '            .Parameters.Add("@FECHA1_DIA", Format(Me.DtFechaDesde.Value, "yyyy-dd-MM"))
    '            .Parameters.Add("@FECHA2_DIA", Format(Me.DtFechaHasta.Value, "yyyy-dd-MM"))
    '            .Parameters.Add("@CODIGO_CULTIVO", Me.cboCultivo.SelectedValue.ToString())
    '            .Parameters.Add("@CODIGO_CLIENTE", Me.TxtCliente.Text)
    '            .Parameters.Add("@AGRUPADO_POR", IIf(Me.RdbCliente.Checked = True, "CLIENTE", "CULTIVO"))
    '            .Parameters.Add("@TIPO_CAMBIO", valorNumerico(Me.txtTipoCambio.Text))
    '            .Parameters.Add("@CODIGO_ZONA_EXTRANJERO", "1")
    '            .Parameters.Add("@CODIGO_ZONA_NACIONAL", "2")
    '        End With

    '        da.Fill(dt)

    '    Catch ex As Exception
    '        HandleError(Me.Nombre_Clase, "ObtenerTopTenCliente", ex)
    '    End Try
    'End Function

    Public Function ObtenerPresentaciones() As DataTable
        Dim dTabla As New DataTable, da As SqlDataAdapter
        Dim sSQL As String

        Try
            sSQL = "SELECT DISTINCT(A.UNIDAD_VENTA) UNIDAD_VENTA FROM VENTA_DETALLE R INNER JOIN VW_CAT_PRODUCTOS_AGRICOLAS A ON(R.CODIGO_ARTICULO=A.CODIGO_ARTICULO)" & _
                   "UNION SELECT 'BTO'"
            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dTabla)
            dTabla.Rows.Add("TODOS")
            da.Dispose()
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerPresentaciones", ex)
        End Try
        Return dTabla
    End Function

    Public Function RecuperaXML(ByVal sRutaXML As String) As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        Dim docXml As Xml.XmlDocument = New Xml.XmlDocument

        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_VENTAS_CFD_RECUPERA_CADENA_XML"

            sqlParametro = .Parameters.Add("@FOLIO_VENTA", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_VENTA
            sqlParametro = .Parameters.Add("@CADENA_XML", SqlDbType.Xml) : sqlParametro.Direction = ParameterDirection.Output : sqlParametro.Value = "" 'XmlDoc.OuterXml
            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()

                'Agrega al documento XML la cadena que ya esta grabada
                docXml.LoadXml(.Parameters("@CADENA_XML").Value.ToString)
                'Crea el nodo principal o primera linea <?xml version="1.0"?>
                Dim Nodo As Xml.XmlDeclaration
                Nodo = docXml.CreateXmlDeclaration("1.0", "utf-8", Nothing)
                'Agrega el nodo al documento
                Dim root As Xml.XmlElement = docXml.DocumentElement
                docXml.InsertBefore(Nodo, root)

                docXml.Save(sRutaXML)
                ConvierteXMLUTF8(sRutaXML)

                bResultado = True

            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "RecuperaXML", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With

        Return bResultado

    End Function

    Public Function RecuperaXML() As String
        Dim sResultado As String = ""
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        Dim docXml As Xml.XmlDocument

        If Me._Conexion.State = ConnectionState.Open Then
            Me._Conexion.Close()
        End If

        Try
            With cmd
                .Connection = _Conexion
                .CommandTimeout = 0
                .CommandType = CommandType.StoredProcedure
                .CommandText = "MP_VENTAS_CFD_RECUPERA_CADENA_XML"

                sqlParametro = .Parameters.Add("@FOLIO_VENTA", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_VENTA
                sqlParametro = .Parameters.Add("@CADENA_XML", SqlDbType.Xml) : sqlParametro.Direction = ParameterDirection.Output : sqlParametro.Value = "" 'XmlDoc.OuterXml

                _Conexion.Open()
                .ExecuteNonQuery()

                'Agrega al documento XML la cadena que ya esta grabada
                docXml = New Xml.XmlDocument
                docXml.LoadXml(.Parameters("@CADENA_XML").Value.ToString)

                'Crea el nodo principal o primera linea <?xml version="1.0"?>
                Dim Nodo As Xml.XmlDeclaration
                Nodo = docXml.CreateXmlDeclaration("1.0", "utf-8", Nothing)
                'Agrega el nodo al documento
                Dim root As Xml.XmlElement = docXml.DocumentElement
                docXml.InsertBefore(Nodo, root)
                'docXml.Save(sRutaXML)

                sResultado = docXml.InnerXml

                'If txtLEN(docXml.InnerXml) = True Then
                '    bResultado = True
                'End If

            End With
            cmd = Nothing
            _Conexion.Close()

        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "RecuperaXML", ex)
        End Try

        Return sResultado
    End Function

    Public Sub Imprimir()
        Dim Rpt As New ReportDocument
        Dim oReporte As Class_Reporte
        Try
            If Me._Existe = False Then
                MsgBox("NO FOLIO DE VENTA NO EXISTE", MsgBoxStyle.Exclamation, "Imprimir")
                Exit Sub
            End If

            If Me._VERSION_ESQUEMA_XML >= "3.2" Or txtLEN(Me._VERSION_ESQUEMA_XML) = False Then 'Se pregunta por vacio por si no se ha cargado la versión en el objecto.
                oReporte = New Class_Reporte(Me._Nombre_Formato, Rpt, False)
            Else
                oReporte = New Class_Reporte(Me._Nombre_Formato & "_CFD", Rpt, False)
            End If

            If Not oReporte.RptCargado Then
                Exit Sub
            End If

            Rpt.SetParameterValue("@FOLIO_VENTA", Me._FOLIO_VENTA)

            Dim frm As New Reporte(Rpt)
            frm.CRViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            frm.Show()

        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "Imprimir", ex)
        End Try
    End Sub

    Public Function ExportarAPdf(Optional ByVal sRutaPDF As String = "") As Boolean
        Dim bResultado As Boolean = False
        Dim Rpt As New ReportDocument
        Dim oReporte As Class_Reporte

        Try
            If txtLEN(sRutaPDF) = False Then 'Si no trae un nombre en especifico lo crea con el nombre del folio
                sRutaPDF = sFelectronicaCarpetaXMLPDF & "\" & Me._FOLIO_VENTA.ToString & ".PDF"
            End If

            If Me.VERSION_ESQUEMA_XML >= "3.2" Or txtLEN(Me._VERSION_ESQUEMA_XML) = False Then 'Se pregunta por vacio por si no se ha cargado la versión en el objecto.
                oReporte = New Class_Reporte(Me._Nombre_Formato, Rpt, False)
            Else
                oReporte = New Class_Reporte(Me._Nombre_Formato & "_CFD", Rpt, False)
            End If

            Rpt.SetParameterValue("@FOLIO_VENTA", Me._FOLIO_VENTA)

            If Not oReporte.RptCargado Then
                Exit Function
            End If

            Rpt.ExportToDisk(ExportFormatType.PortableDocFormat, sRutaPDF)

            bResultado = True

        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ExportarAPdf", ex)
        Finally
            oReporte = Nothing
        End Try
        Return bResultado
    End Function

    Public Function EnviarCorreo() As Boolean
        Const sProcedure As String = "EnviarCorreo"
        Dim Ret As Long, tabla() As String, n As Integer, archivos As String = sFelectronicaCarpetaXMLPDF & "\"
        Dim oCliente As Class_CatClientes
        Dim MyMailMsg As New Net.Mail.MailMessage

        Try
            oCliente = New Class_CatClientes(Me._CODIGO_CLIENTE)

            If txtLEN(oCliente.CORREO_CLIENTE) = False Then
                MsgBox("El cliente no tiene correo configurado.", MsgBoxStyle.Exclamation, sProcedure)
                Dim oActualizar As New Catalogo_Clientes_ActualizaCorreo(oCliente)
                oActualizar.ShowDialog()
                If oActualizar.bActualizado = False Then
                    Return False
                End If
            End If

            tabla = Split(oCliente.CORREO_CLIENTE, ";")

            For n = 0 To UBound(tabla, 1)
                If IsEmailSyntaxValid(tabla(n)) = False Then
                    MsgBox("El correo no es válido, favor de verificar.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If
            Next

            'Si el Api retorna 0 quiere decir que no hay ningun tipo de conexión de Red
            If IsNetworkAlive(Ret) = 0 Then
                MsgBox("No existe conexión a internet. Por favor revise su conexión e inténtelo nuevamente.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            If txtLEN(Usuario.CORREO_USUARIO) = False Then
                MsgBox("El usuario : " & Usuario.Nombre_Usuario & " no tiene correo configurado.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            MyMailMsg.Subject = "FACTURAS DE " & Empresa_Sistema.NOMBRE_EMPRESA

            For n = 0 To UBound(tabla, 1)
                MyMailMsg.To.Add(tabla(n))
            Next

            MyMailMsg.From = New MailAddress(Usuario.CORREO_USUARIO.ToString)
            MyMailMsg.Priority = MailPriority.Normal
            MyMailMsg.Body = "FACTURA " & Me._FOLIO_VENTA

            'MyMailMsg.IsBodyHtml = False
            'MyMailMsg.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure

            Dim SMTP As New SmtpClient()
            SMTP.Host = Usuario.SERVIDOR_CORREO_REMITENTE
            SMTP.EnableSsl = Usuario.USAR_SSL_REMITENTE
            SMTP.Port = CInt(Usuario.PUERTO_REMITENTE)

            SMTP.Credentials = New System.Net.NetworkCredential(Usuario.CORREO_USUARIO.ToString, Usuario.CLAVE_CORREO.ToString)

            Dim sRutaXML As String = "", sNombreXmlTimbrado As String = ""
            Dim sRutaPDF As String = ""

            If txtLEN(oCliente.FORMATO_NOMBRE_XML) = True Then
                Select Case oCliente.FORMATO_NOMBRE_XML
                    Case "RFCemisor-Serie-FolioNumerico"
                        sNombreXmlTimbrado = Empresa_Sistema.RFC & "-" & Me.SERIE & "-" & Me.FOLIO_NUMERICO
                    Case "RFCemisor-Fecha-SerieFolio"
                        sNombreXmlTimbrado = Empresa_Sistema.RFC & Format(Me.FECHA, "yyyyddMM") & Me.SERIE & Me.FOLIO_NUMERICO
                End Select
            Else
                sNombreXmlTimbrado = Me._FOLIO_VENTA
            End If

            sRutaXML = sFelectronicaCarpetaXmlsTimbrados & "\" & sNombreXmlTimbrado & ".xml"
            sRutaPDF = archivos.ToString & sNombreXmlTimbrado & ".PDF"

            If Me.RecuperaXML(sRutaXML) = True Then
                If Me.ExportarAPdf(sRutaPDF) = False Then
                    MsgBox("No se logró generar el PDF de la factura : " & Me._FOLIO_VENTA & ". Avíse al depto. de sistemas.", vbExclamation, sProcedure)
                    Return False
                End If
            Else
                MsgBox("No se logró recuperar el XML de la factura : " & Me._FOLIO_VENTA & ". Avíse al depto. de sistemas.", vbExclamation, sProcedure)
                Return False
            End If

            Me.Enviado(Me._FOLIO_VENTA)

            Dim msa As New Attachment(sRutaPDF)
            MyMailMsg.Attachments.Add(msa)
            msa = New Attachment(sRutaXML)
            MyMailMsg.Attachments.Add(msa)

            ServicePointManager.ServerCertificateValidationCallback = Function(s As Object, certificate As X509Certificate, chain As X509Chain, sslPolicyErrors As SslPolicyErrors) True

            SMTP.Send(MyMailMsg)

            MsgBox("Tu E-Mail se ha enviado exitosamente.", MsgBoxStyle.Information, sProcedure)

            Return True

        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, sProcedure, ex)
        End Try
    End Function

    Public Function ValidarComercioExterior() As Boolean
        Dim bResultado As Boolean = False
        Const sProcedure As String = "ValidarComercioExterior"
        Try

            If Me.Consultar() = False Then
                Return False
            End If

            If Me._TIENE_COMPLEMENTO_COMERCIO_EXTERIOR = True Then
                MsgBox("La venta ya tiene grabado le complemento del comercio exterior.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            If Me._TIPO_DE_CAMBIO <= 0 Then
                MsgBox("La venta debió grabarse en USD.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            Dim oCliente As New Class_CatClientes(Me._CODIGO_CLIENTE)

            If txtLEN(oCliente.NUMERO_IDENTIFICACION_REGISTRO_FISCAL_EXTRANJERO) = False Then
                MsgBox("Al cliente le falta configurar el número de registro de identificación fiscal extranjero.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            If oCliente.NUMERO_IDENTIFICACION_REGISTRO_FISCAL_EXTRANJERO.Length < 6 Then
                MsgBox("El número de registro de identificación fiscal extranjero del cliente debe ser 6 caracteres mínimo.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            Dim dRows() As DataRow = Me.ObtenerDetalleParaComercioExterior.Select("LEN(FRACCION_ARANCELARIA)=0")

            If dRows.Length > 0 Then

                For i As Integer = 0 To dRows.Length - 1

                    If txtLEN(dRows(i)("NOMBRE_CULTIVO").ToString) = False Then
                        MsgBox("El artículo " & dRows(i)("DESCRIPCION").ToString & " no tiene cultivo y por tanto tampoco fracción arancelaria.", MsgBoxStyle.Exclamation, sProcedure)
                    ElseIf txtLEN(dRows(i)("FRACCION_ARANCELARIA").ToString) = False Then
                        MsgBox("El artículo " & dRows(i)("DESCRIPCION").ToString & " tiene el cultivo " & dRows(i)("NOMBRE_CULTIVO").ToString & " que no tiene fracción arancelaria.", MsgBoxStyle.Exclamation, sProcedure)
                    End If

                Next

                Return False
            End If

            bResultado = True

        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    Public Function GeneraXmlComercioExterior10() As String
        Const sProcedure As String = "GeneraXmlComercioExterior10"
        Dim sXmlComercioExterior As String = ""
        Try

            If Me.ValidarComercioExterior() = False Then
                Return ""
            End If

            Dim oCliente As New Class_CatClientes(Me._CODIGO_CLIENTE)

            Dim cfdiComercioExterior As New Class_CFDI_cce_ComercioExterior

            With cfdiComercioExterior
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                .Version = "1.0"
                .TipoOperacion = "2"
                .ClaveDePedimento = "A1"

                .CertificadoOrigen = "0"
                .NumCertificadoOrigen = ""
                .NumeroExportadorConfiable = ""
                .Incoterm = "DAP" 'DAP=ENTREGADA EN LUGAR
                .Subdivision = "0"

                .Observaciones = ""
                .TipoCambioUSD = Format(Me._TIPO_DE_CAMBIO, "######.0000")
                .TotalUSD = Format(Me._TOTAL_DOLARES, "######.00")

                .bTieneEmisor = False

                .Receptor.NumRegIdTrib = oCliente.NUMERO_IDENTIFICACION_REGISTRO_FISCAL_EXTRANJERO

                .bTieneDestinatario = False
                'Estos se habilitarian si se llevara destinatario
                '.Destinatario.NumRegIdTrib = oCliente.NUMERO_IDENTIFICACION_REGISTRO_FISCAL_EXTRANJERO
                '.Destinatario.Domicilio.Calle = oCliente.CALLE
                '.Destinatario.Domicilio.Estado = oCliente.CODIGO_ESTADO_SAT
                '.Destinatario.Domicilio.Pais = oCliente.PAIS
                '.Destinatario.Domicilio.CodigoPostal = oCliente.CODIGO_POSTAL
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                'Ciclo a los artículos

                For Each dRow As DataRow In Me.ObtenerDetalleParaComercioExterior.Rows
                    .Mercancia.NoIdentificacion = dRow("CODIGO_ARTICULO").ToString
                    .Mercancia.FraccionArancelaria = dRow("FRACCION_ARANCELARIA").ToString
                    .Mercancia.CantidadAduana = Format(valorNumerico(dRow("CANTIDAD").ToString), "######.000")
                    .Mercancia.UnidadAduana = "20" '20=CAJA
                    .Mercancia.ValorUnitarioAduana = Format(valorNumerico(dRow("PRECIO_USD").ToString), "######.00")
                    .Mercancia.ValorDolares = Format(valorNumerico(dRow("IMPORTE_USD").ToString), "######.00")
                    .Mercancia.Add(.Mercancia.NoIdentificacion)
                Next

                'Ejemplo manual.

                '.Mercancia.NoIdentificacion = "ARTI1"
                '.Mercancia.FraccionArancelaria = "030711"
                '.Mercancia.CantidadAduana = "1000.000"
                '.Mercancia.UnidadAduana = "20" '20=CAJA
                '.Mercancia.ValorUnitarioAduana = "3.50"
                '.Mercancia.ValorDolares = "3500.00"
                '.Mercancia.Add(.Mercancia.NoIdentificacion)

                '.Mercancia.NoIdentificacion = "ARTI2"
                '.Mercancia.FraccionArancelaria = "056644"
                '.Mercancia.CantidadAduana = "2000.000"
                '.Mercancia.UnidadAduana = "20" '20=CAJA
                '.Mercancia.ValorUnitarioAduana = "3.00"
                '.Mercancia.ValorDolares = "6000.00"
                '.Mercancia.Add(.Mercancia.NoIdentificacion)

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                sXmlComercioExterior = .GenerarCadenaXMLComercioExterior()

                If txtLEN(sXmlComercioExterior) = False Then
                    MsgBox("No se pudo generar XML del comercio exterior.", MsgBoxStyle.Exclamation, Me._Nombre_Catalogo)
                End If

            End With

        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, sProcedure, ex)
        End Try

        Return sXmlComercioExterior
    End Function

    Public Function GeneraXmlComercioExterior11() As String
        Const sProcedure As String = "GeneraXmlComercioExterior11"
        Dim sXmlComercioExterior As String = ""
        Try

            If Me.ValidarComercioExterior() = False Then
                Return ""
            End If

            Dim oCliente As New Class_CatClientes(Me._CODIGO_CLIENTE)

            Dim cfdiComercioExterior As New Class_CFDI_cce_ComercioExterior11

            With cfdiComercioExterior
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                .Version = "1.1"
                .MotivoTraslado = ""
                .TipoOperacion = "2"
                .ClaveDePedimento = "A1"

                .CertificadoOrigen = "0"
                .NumCertificadoOrigen = ""
                .NumeroExportadorConfiable = ""
                .Incoterm = "DAP" 'DAP=ENTREGADA EN LUGAR
                .Subdivision = "0"

                .Observaciones = ""
                .TipoCambioUSD = FormatTipoCambio(Me._TIPO_DE_CAMBIO, False)
                .TotalUSD = Format(Me._TOTAL_DOLARES, "######.00")

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'MsgBox("bTieneEmisor=true este no lo podiamos en 32, pongo solo los obligatorios")
                .bTieneEmisor = True
                '.Emisor.Curp = ""
                .Emisor.Domicilio.Calle = Empresa_Sistema.CALLE
                .Emisor.Domicilio.NumeroExterior = Empresa_Sistema.NUMERO_EXTERIOR
                '.Emisor.Domicilio.NumeroInterior = ""
                '.Emisor.Domicilio.Colonia = ""
                '.Emisor.Domicilio.Localidad = ""
                '.Emisor.Domicilio.Referencia = ""
                .Emisor.Domicilio.Municipio = Empresa_Sistema.CODIGO_MUNICIPIO_SAT
                .Emisor.Domicilio.Estado = Empresa_Sistema.CODIGO_ESTADO_SAT
                .Emisor.Domicilio.Pais = Empresa_Sistema.CODIGO_PAIS_SAT
                .Emisor.Domicilio.CodigoPostal = Empresa_Sistema.CODIGO_POSTAL
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                .bTienePropietario = False
                '.Propietario.NumRegIdTrib = ""
                '.Propietario.ResidenciaFiscal = ""

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                .bTieneReceptor = True

                '"752491201"  farsmestbest,"205582956" 'nidia
                '.Receptor.NumRegIdTrib = oCliente.NUMERO_IDENTIFICACION_REGISTRO_FISCAL_EXTRANJERO'El atributo cce11:ComercioExterior:Receptor:NumRegIdTrib no debe registrarse si la versión de CFDI es 3.3. 

                .Receptor.Domicilio.Calle = fElectronicaValidaCampo(oCliente.CALLE)
                .Receptor.Domicilio.NumeroExterior = fElectronicaValidaCampo(oCliente.NUMERO_EXTERIOR)
                .Receptor.Domicilio.NumeroInterior = fElectronicaValidaCampo(oCliente.NUMERO_INTERIOR)
                .Receptor.Domicilio.Colonia = fElectronicaValidaCampo(oCliente.COLONIA)
                .Receptor.Domicilio.Localidad = fElectronicaValidaCampo(oCliente.LOCALIDAD)
                '.Receptor.Domicilio.Referencia = ""
                .Receptor.Domicilio.Municipio = fElectronicaValidaCampo(oCliente.CIUDAD)
                .Receptor.Domicilio.Estado = fElectronicaValidaCampo(oCliente.CODIGO_ESTADO_SAT)
                .Receptor.Domicilio.Pais = fElectronicaValidaCampo(oCliente.CODIGO_PAIS_SAT)
                .Receptor.Domicilio.CodigoPostal = fElectronicaValidaCampo(oCliente.CODIGO_POSTAL.ToString)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                .bTieneDestinatario = False
                'Estos se habilitarian si se llevara destinatario
                '.Destinatario.NumRegIdTrib = oCliente.NUMERO_IDENTIFICACION_REGISTRO_FISCAL_EXTRANJERO
                '.Destinatario.Nombre =oCliente.NOMBRE_CLIENTE 
                '.Destinatario.Domicilio.Calle = oCliente.CALLE
                '.Destinatario.Domicilio.NumeroExterior = oCliente.NUMERO_EXTERIOR
                '.Destinatario.Domicilio.NumeroInterior = oCliente.NUMERO_INTERIOR
                '.Destinatario.Domicilio.Colonia = "?"
                '.Destinatario.Domicilio.Localidad = "?"
                '.Destinatario.Domicilio.Referencia = "?"
                '.Destinatario.Domicilio.Municipio = "?"
                '.Destinatario.Domicilio.Estado = oCliente.CODIGO_ESTADO_SAT
                '.Destinatario.Domicilio.Pais = oCliente.PAIS
                '.Destinatario.Domicilio.CodigoPostal = oCliente.CODIGO_POSTAL

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                'Ciclo a los artículos

                Dim dCantidadAduana As Decimal, dValorUnitarioAduana As Decimal, dValorDolares As Decimal, dPesoxCaja As Decimal, dValorDolaresNuevo As Decimal

                For Each dRow As DataRow In Me.ObtenerDetalleParaComercioExterior.Rows
                    .Mercancia.NoIdentificacion = dRow("CODIGO_ARTICULO").ToString
                    .Mercancia.FraccionArancelaria = dRow("FRACCION_ARANCELARIA").ToString

                    dCantidadAduana = CDec(dRow("CANTIDAD").ToString)
                    dValorUnitarioAduana = CDec(dRow("PRECIO_USD").ToString)
                    dValorDolares = CDec(dRow("IMPORTE_USD").ToString)
                    dPesoxCaja = CDec(dRow("PESO").ToString)

                    If dPesoxCaja = 0 Then
                        MsgBox("El producto " & dRow("CODIGO_ARTICULO").ToString & "-" & dRow("DESCRIPCION").ToString & " no tiene configurado el peso x caja." & vbCrLf &
                               "Debe hacerlo para hacer la conversión a kilos para la aduana en el complemento exterior.", MsgBoxStyle.Exclamation, sProcedure)
                        Return ""
                    End If

                    dValorUnitarioAduana = RedondearD(dValorUnitarioAduana / dPesoxCaja, 2)
                    dCantidadAduana = RedondearD(dValorDolares / dValorUnitarioAduana, 3)

                    'dValorDolares='Este se queda como orignalmente es, y así se va poner en el ValorDolares, aunque la multiplicación no de el valor exacto.
                    dValorDolaresNuevo = RedondearD(dCantidadAduana * dValorUnitarioAduana, 2)

                    If dValorDolaresNuevo <> dValorDolares Then
                        If MsgBox("El campo ValorDolares(en datos de aduana) es diferente al del concepto original. Seguro quiere continuar así ?" & vbCrLf &
                                   "Concepto.Importe=" & dValorDolares & vbCrLf & "ValorDolares=" & dValorDolaresNuevo.ToString, MsgBoxStyle.Question Or MsgBoxStyle.YesNo, sProcedure) = MsgBoxResult.No Then
                            Return ""
                        End If
                    End If

                    'MsgBox("quite de momento la unidad al parecer es incompatible, o nos dirá que pongamos kilos ? MATRIX DE ERRORES CCE209")
                    '.Mercancia.UnidadAduana = "20" '20=CAJA,01=KILO
                    .Mercancia.UnidadAduana = "01"

                    .Mercancia.CantidadAduana = Format(dCantidadAduana, "#####0.000")
                    .Mercancia.ValorUnitarioAduana = Format(dValorUnitarioAduana, "#####0.00")
                    .Mercancia.ValorDolares = Format(dValorDolares, "#####0.00")
                    .Mercancia.Add(.Mercancia.NoIdentificacion)
                Next

                'Ejemplo manual.

                '.Mercancia.NoIdentificacion = "ARTI1"
                '.Mercancia.FraccionArancelaria = "030711"
                '.Mercancia.CantidadAduana = "1000.000"
                '.Mercancia.UnidadAduana = "20" '20=CAJA
                '.Mercancia.ValorUnitarioAduana = "3.50"
                '.Mercancia.ValorDolares = "3500.00"
                '.Mercancia.Add(.Mercancia.NoIdentificacion)

                '.Mercancia.NoIdentificacion = "ARTI2"
                '.Mercancia.FraccionArancelaria = "056644"
                '.Mercancia.CantidadAduana = "2000.000"
                '.Mercancia.UnidadAduana = "20" '20=CAJA
                '.Mercancia.ValorUnitarioAduana = "3.00"
                '.Mercancia.ValorDolares = "6000.00"
                '.Mercancia.Add(.Mercancia.NoIdentificacion)

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                'MsgBox("hay que ver si meteremos o no validaciones tipo proveedor")
                'If .ValidacionesProveedorComplementoExterior = False Then
                '    Return ""
                'End If

            End With

            sXmlComercioExterior = cfdiComercioExterior.GenerarCadenaXMLComercioExterior()

            If txtLEN(sXmlComercioExterior) = False Then
                MsgBox("No se logró generar el XML del comercio exterior.", MsgBoxStyle.Exclamation, Me._Nombre_Catalogo)
            End If

        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, sProcedure, ex)
        End Try

        Return sXmlComercioExterior
    End Function

    Public Function CancelarTimbre() As Boolean
        Dim bResultado As Boolean = False
        Const sProcedure As String = "CancelarTimbre"
        Try
            If Me.Consultar() = False Then 'Refrescamos la factura para tener los datos mas nuevos.
                Return False
            End If

            If Me._ESTATUS_VENTA <> "C" Then
                MsgBox("El documento no esta cancelado.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            If Me._TIMBRADO_DESCARTADO = "1" Then
                MsgBox("El timbre esta descartado.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            If Me._ESTATUS_CANCELACION_CFDI = "1" Then
                MsgBox("El timbre ya esta cancelado.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            Dim sCadenaXML As String = Me.RecuperaXML()
            If txtLEN(sCadenaXML) = False Then
                MsgBox("No se logró recuperar el xml para poder cancelar el timbre.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            bResultado = CancelarCFDI(Me.FOLIO_VENTA, Me.SERIE, Me.FOLIO_NUMERICO, Me.FOLIO_FISCAL_SAT, Me.TIMBRADO_CFDI, TipoComprobante.FACTURA_VENTA, sCadenaXML)

        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    Public Function GeneraFacturaElectronica(ByVal bMensajes As Boolean, ByVal bGenerarPDF As Boolean) As Boolean
        Dim bResultado As Boolean = False
        Const sProcedure As String = "GeneraFacturaElectronica"
        Dim sRutaXML As String

        Try
            sRutaXML = sFelectronicaCarpetaXMLPDF & "\" & Me._FOLIO_VENTA & ".xml"

            If Me._TIMBRADO_CFDI = "0" Then
                If Empresa_Sistema.VERSION_ESQUEMA_CFD <= "3.2" Then
                    bResultado = FacturacionElectronica.GeneraFacturaElectronica(Me, bMensajes, sRutaXML)
                Else
                    If Me._CODIGO_TIPO_DOCUMENTO = "FT" Then 'Factura de traslado
                        bResultado = FacturacionElectronica33.GeneraFacturaTrasladoElectronica33(Me, bMensajes, sRutaXML)
                    Else
                        bResultado = FacturacionElectronica33.GeneraFacturaElectronica33(Me, bMensajes, sRutaXML)
                    End If
                End If

                If bResultado = False Then
                    MsgBox("Los datos digitales del documento no fueron generados correctamente. Avíse al depto. de sistemas.", vbExclamation, sProcedure)
                Else
                    bResultado = True

                    'Actualiza el rfc_receptor en la factura para registrar el rfc exacto con el que la timbraron porque puede ser que hayan grabado con un rfc que no es válido, y ese dato se queda incorrecto para cuando ya lo corrigen
                    'en el catálgo de clientes.
                    Me.ActualizaRFCReceptor()

                    If bGenerarPDF = True Then
                        Me.ExportarAPdf()
                    End If

                End If
                'Else
                '    Me.RecuperarFacturaElectronicaLocal(bMensajes)
            Else
                MsgBox("La factura ya esta timbrada.", vbExclamation, sProcedure)
            End If
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, sProcedure, ex)
        End Try
        Return bResultado
    End Function

    Public Function ObtenerImpuestosIEPS() As DataTable
        Const sProcedure As String = "ObtenerImpuestosIEPS"
        Dim dTabla As New DataTable("detalle"), da As SqlDataAdapter
        Dim sSQL As String

        Try
            sSQL = "SELECT R.IEPS_PORCENTAJE,SUM(R.IEPS_IMPORTE) SUMA_IEPS_IMPORTE " &
                        "FROM VENTA_GLOBAL G INNER JOIN VENTA_DETALLE R ON(G.FOLIO_VENTA=R.FOLIO_VENTA) " &
                        "WHERE G.FOLIO_VENTA='" & Me._FOLIO_VENTA & "' AND R.IEPS_PORCENTAJE>0 " &
                        "GROUP BY R.IEPS_PORCENTAJE ORDER BY R.IEPS_PORCENTAJE"
            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dTabla)
            da.Dispose()

        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, sProcedure, ex)
        End Try
        Return dTabla
    End Function

    Public Function GestionaPrecioVenta(ByVal CodigoArticulo As String, ByVal CodigoCliente As String, ByVal CodigoAlmacen As String) As tPrecioVenta
        Const sProcedure As String = "GestionaPrecioVenta"
        Dim oPrecioVenta As New tPrecioVenta
        Dim dt As New DataTable
        Try
            Using da As New SqlDataAdapter("MP_VENTA_GESTIONA_PRECIO", Me._Conexion)
                da.SelectCommand.CommandType = CommandType.StoredProcedure

                With da.SelectCommand
                    .Parameters.Add("@CODIGO_ARTICULO", SqlDbType.NVarChar, 16).Value = CodigoArticulo
                    .Parameters.Add("@CODIGO_CLIENTE", SqlDbType.NVarChar, 8).Value = CodigoCliente
                    .Parameters.Add("@CODIGO_ALMACEN", SqlDbType.NVarChar, 4).Value = CodigoAlmacen
                End With

                da.Fill(dt)
            End Using
            oPrecioVenta.Precio = CDec(dt.Rows(0)("PRECIO").ToString)
            oPrecioVenta.Costo = CDec(dt.Rows(0)("COSTO").ToString)
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, sProcedure, ex)
        End Try
        Return oPrecioVenta
    End Function

    Public Function RecuperarXMLyPDF() As Boolean
        Const sProcedure As String = "RecuperarXMLyPDF"
        Dim bResultado As Boolean = False

        Dim oCliente As Class_CatClientes

        Try
            oCliente = New Class_CatClientes(Me._CODIGO_CLIENTE)

            Dim sRutaXML As String = "", sNombreXmlTimbrado As String = ""
            Dim sRutaPDF As String = "", archivos As String = sFelectronicaCarpetaXMLPDF & "\"

            If txtLEN(oCliente.FORMATO_NOMBRE_XML) = True Then
                Select Case oCliente.FORMATO_NOMBRE_XML
                    Case "RFCemisor-Serie-FolioNumerico"
                        sNombreXmlTimbrado = Empresa_Sistema.RFC & "-" & Me._SERIE & "-" & Me._FOLIO_NUMERICO
                    Case "RFCemisor-Fecha-SerieFolio"
                        sNombreXmlTimbrado = Empresa_Sistema.RFC & Format(Me._FOLIO_VENTA, "yyyyddMM") & Me._SERIE & Me._FOLIO_NUMERICO
                End Select
            Else
                sNombreXmlTimbrado = Me._FOLIO_VENTA
            End If

            sRutaXML = sFelectronicaCarpetaXmlsTimbrados & "\" & sNombreXmlTimbrado & ".xml"
            sRutaPDF = archivos.ToString & sNombreXmlTimbrado & ".PDF"

            If Me.RecuperaXML(sRutaXML) = True Then
                Process.Start(sRutaXML) 'Para abrir el xml
                If Me.ExportarAPdf(sRutaPDF) = False Then
                    MsgBox("Se logró recuperar el XML pero no se logró generar el PDF del documento : " & Me._FOLIO_VENTA & ". Avíse al depto. de sistemas.", vbExclamation, sProcedure)
                    Return False
                Else
                    bResultado = True
                End If
            Else
                MsgBox("No se logró recuperar el XML y PDF del documento : " & Me._FOLIO_VENTA & ". Avíse al depto. de sistemas.", vbExclamation, sProcedure)
                Return False
            End If

        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    Public Function ObtieneFacturasRelacionadas() As DataTable
        Dim dTabla As New DataTable("detalle"), da As SqlDataAdapter
        Dim sSQL As String

        sSQL = "SELECT F.FOLIO_VENTA,F.FECHA,F.CONCEPTO,F.FOLIO_FISCAL_SAT,F.TOTAL " &
                "FROM VENTAS_CFDI_RELACIONADOS VR " &
                "INNER JOIN VENTA_GLOBAL F ON(VR.FOLIO_VENTA_RELACIONADA=F.FOLIO_VENTA) " &
                "WHERE VR.FOLIO_VENTA='" & Me.FOLIO_VENTA & "'" &
                "ORDER BY F.FECHA"

        Try
            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dTabla)

            da.Dispose()
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "ObtieneFacturasRelacionadas", ex)
        End Try

        Return dTabla
    End Function

    Public Function SubeXMLExterno(ByVal sRutaXML As String) As Boolean
        Const sProcedure As String = "SubeXMLExterno"
        Dim bResultado As Boolean = False
        Try
            Dim oCFDI As New CFDIXML.ClassCFDI(sRutaXML, True)
            Dim oDocumento As New Class_CatDocumentos(Me._CODIGO_DOCUMENTO)
            Dim oCliente As New Class_CatClientes(Me._CODIGO_CLIENTE)
            Dim oSQL As Class_find

            If oCFDI.XMLCargado = False Then
                Return False
            End If

            If oDocumento.TIMBRA_DOCUMENTO = True Then
                MsgBox("La venta debe ser no timbrable, con esto se evita poder subir xml externos a ventas normales timbradas.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            If (oDocumento.CODIGO_DOCUMENTO Like "F*") = False Then
                MsgBox("La venta debe ser tipo factura.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            If txtLEN(Me._FOLIO_FISCAL_SAT) = True Then
                If MsgBox("Esta venta ya tiene ligado un XML con el UUID " & Me._FOLIO_FISCAL_SAT & ", esta seguro de querer cambiar el xml anterior por este nuevo xml?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, sProcedure) = MsgBoxResult.No Then
                    Return False
                End If
            End If

            If txtLEN(oCFDI.ComplementoTFD.UUID) = False Then
                MsgBox("El XML no tiene el UUID.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            If oCFDI.Comprobante.TipoDeComprobante <> "I" Then
                MsgBox("El XML no es del tipo Ingreso.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            If oCFDI.Emisor.rfc <> Empresa_Sistema.RFC Then
                MsgBox("El RFC del emisor del XML(" & oCFDI.Emisor.rfc & ") es diferente al RFC de la empresa(" & Empresa_Sistema.RFC & ").", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            If oCFDI.Receptor.rfc <> oCliente.RFC Then
                MsgBox("El RFC del receptor del XML(" & oCFDI.Receptor.rfc & ") es diferente al RFC del cliente(" & oCliente.RFC & ").", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            If Me._ESTATUS_VENTA = "C" And Me._ESTATUS_CANCELACION_CFDI = "1" Then
                MsgBox("Esta venta ya tiene ligado un xml y esta cancelado el timbre, no es válido ponerle otro xml o se perderia la referencia de la cancelación del 1er xml.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            oSQL = New Class_find("SELECT FOLIO_VENTA FROM VENTA_GLOBAL WHERE FOLIO_FISCAL_SAT='" & sReplace(oCFDI.ComplementoTFD.UUID) & "'")
            If txtLEN(oSQL.Result1) = True Then
                If MsgBox("Ya existe una venta con el folio " & oSQL.Result1 & " con este xml registrado." & vbCrLf &
                          "Esta seguro de relacionarlo(si lo hace va tener este xml asociado a más de una venta) ?", vbQuestion Or MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    Return False
                End If
            End If
            oSQL = Nothing

            Select Case oCFDI.Comprobante.Moneda
                Case "MXN"
                    If oCFDI.Comprobante.Total <> Me._TOTAL Then
                        If MsgBox("El total del comprobante del xml es de " & FormatImporteContable(oCFDI.Comprobante.Total) & " MXN y el total de esta venta es de " & FormatImporteContable(Me._TOTAL) & vbCrLf &
                                  "Esta seguro de relacionar este xml?", vbQuestion Or MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                            Return False
                        End If
                    End If
                Case "USD"
                    If oCFDI.Comprobante.Total <> Me._TOTAL_DOLARES Then
                        If MsgBox("El total del comprobante del xml es de " & FormatImporteContable(oCFDI.Comprobante.Total) & " USD y el total de esta venta es de " & FormatImporteContable(Me._TOTAL_DOLARES) & vbCrLf &
                                  "Esta seguro de relacionar este xml?", vbQuestion Or MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                            Return False
                        End If
                    End If
                Case Else
                    MsgBox("De momento este sistema no soporta monedas diferentes de MXN/USD.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
            End Select

            'Busca el certificado
            Dim sID_SIS_CFD_CATALOGO_CERTIFICADOS As String = "" ', sIDCATALOGO_FOLIO_FELECTRONICA As String = ""
            oSQL = New Class_find("SELECT ID_SIS_CFD_CATALOGO_CERTIFICADOS FROM SIS_CFD_CATALOGO_CERTIFICADOS WHERE NUMERO_CERTIFICADO='" & sReplace(oCFDI.Comprobante.NoCertificado) & "'")
            sID_SIS_CFD_CATALOGO_CERTIFICADOS = oSQL.Result1
            If txtLEN(sID_SIS_CFD_CATALOGO_CERTIFICADOS) = False Then
                MsgBox("No se encontró en la tabla SIS_CFD_CATALOGO_CERTIFICADOS el certificado " & oCFDI.Comprobante.NoCertificado & ". " & vbCrLf &
                       "Avíse al depto. de sistemas.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If
            oSQL = Nothing

            Dim cmd As New SqlCommand
            Dim sqlParametro As SqlParameter

            With cmd
                .Connection = Me._Conexion
                .CommandTimeout = 0
                .CommandType = CommandType.StoredProcedure
                .CommandText = "MP_VENTAS_CFD_GRABA_XML_EXTERNO"

                Try
                    Me._Conexion.Open()

                    sqlParametro = .Parameters.Add("@FOLIO_VENTA", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_VENTA
                    sqlParametro = .Parameters.Add("@CADENA_XML", SqlDbType.Xml) : sqlParametro.Value = oCFDI.XMLSinDeclaracion
                    sqlParametro = .Parameters.Add("@CODIGO_USUARIO_AGREGO_XML_EXTERNO", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Usuario
                    sqlParametro = .Parameters.Add("@FOLIO_NUMERICO", SqlDbType.Int) : sqlParametro.Value = oCFDI.Comprobante.Folio
                    sqlParametro = .Parameters.Add("@SERIE", SqlDbType.NVarChar, 10) : sqlParametro.Value = oCFDI.Comprobante.Serie
                    'sqlParametro = .Parameters.Add("@IDCATALOGO_FOLIO_FELECTRONICA", SqlDbType.SmallInt) : sqlParametro.Value = sIDCATALOGO_FOLIO_FELECTRONICA
                    sqlParametro = .Parameters.Add("@ID_SIS_CFD_CATALOGO_CERTIFICADOS", SqlDbType.SmallInt) : sqlParametro.Value = sID_SIS_CFD_CATALOGO_CERTIFICADOS
                    sqlParametro = .Parameters.Add("@VERSION_ESQUEMA_XML", SqlDbType.NVarChar, 6) : sqlParametro.Value = oCFDI.Comprobante.Version
                    sqlParametro = .Parameters.Add("@NUMERO_CERTIFICADO_DIGITAL", SqlDbType.NVarChar, 50) : sqlParametro.Value = oCFDI.Comprobante.NoCertificado
                    sqlParametro = .Parameters.Add("@CADENA_ORIGINAL", SqlDbType.NVarChar, 4000) : sqlParametro.Value = ""
                    sqlParametro = .Parameters.Add("@SELLO_DIGITAL", SqlDbType.NVarChar, 2000) : sqlParametro.Value = oCFDI.Comprobante.Sello
                    sqlParametro = .Parameters.Add("@FOLIO_FISCAL_SAT", SqlDbType.NVarChar, 50) : sqlParametro.Value = oCFDI.ComplementoTFD.UUID
                    sqlParametro = .Parameters.Add("@FECHA_TIMBRADO_SAT", SqlDbType.NVarChar, 20) : sqlParametro.Value = oCFDI.ComplementoTFD.FechaTimbrado
                    sqlParametro = .Parameters.Add("@NUMERO_SERIE_CERTIFICADO_SAT", SqlDbType.NVarChar, 20) : sqlParametro.Value = oCFDI.ComplementoTFD.NoCertificadoSAT
                    sqlParametro = .Parameters.Add("@SELLO_SAT", SqlDbType.NVarChar, 500) : sqlParametro.Value = oCFDI.ComplementoTFD.SelloSAT
                    sqlParametro = .Parameters.Add("@CBB_IMAGE", SqlDbType.Image) : sqlParametro.Value = oCFDI.ComplementoTFD.CBBImage
                    sqlParametro = .Parameters.Add("@RFCPROVCERTIF", SqlDbType.NVarChar, 13) : sqlParametro.Value = oCFDI.ComplementoTFD.RfcProvCertif
                    sqlParametro = .Parameters.Add("@LEYENDA", SqlDbType.NVarChar, 200) : sqlParametro.Value = oCFDI.ComplementoTFD.Leyenda

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

            oCFDI = Nothing
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, sProcedure, ex)
        End Try
        Return bResultado
    End Function

    Public Function SiRemisionTieneMovimientosAbonoParaEvitarSustitucion(ByVal sFolioRemision As String) As Boolean
        Const sProcedure As String = "SiRemisionTieneMovimientosAbonoParaEvitarSustitucion"
        Dim bResultado As Boolean = False
        Try
            'Dim oVenta As New Class_Ventas_Global(sFolioRemision)
            Dim sql As New Class_find("SELECT TOP 1 FOLIO_CXC + ' - ' + DOC.NOMBRE_TIPO_DOCUMENTO FROM CXC_GLOBAL C " &
                                      "INNER JOIN VW_SIS_CAT_DOCUMENTOS_EXTENDIDO DOC ON(C.CODIGO_DOCUMENTO=DOC.CODIGO_DOCUMENTO) " &
                                      "WHERE C.FOLIO_REFERENCIA='" & sReplace(sFolioRemision) & "' AND DOC.NATURALEZA_CXC='A' AND DOC.CODIGO_TIPO_DOCUMENTO NOT IN('SV_VTA','DD') AND ESTATUS_CXC='A' ")
            'Nota, si permite que ya exista alguna sustitución(SV_VTA), o que sea una descuento x devolución(DD porque esta afecta al disp)

            If txtLEN(sql.Result1) = True Then
                MsgBox("La remisión tiene al menos un movimiento de abono(" & sql.Result1 & "), por lo cual no se puede sustituir. Cancele el movimiento de abono primero.", MsgBoxStyle.Exclamation, sProcedure)
                bResultado = True
            End If

        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, sProcedure, ex)
        End Try
        Return bResultado
    End Function

    Public Function ActualizaRFCReceptor() As Boolean
        Const sProcedure As String = "ActualizaRFCReceptor"
        Dim bResultado As Boolean = False
        Try
            Dim sReceptorRFC As String = ""
            If Me.ES_VENTA_PUBLICO_GENERAL = "1" Then
                sReceptorRFC = Empresa_Sistema.RFC_VENTA_PUBLICO_GENERAL
            Else
                Dim oCliente As New Class_CatClientes(Me.CODIGO_CLIENTE)
                sReceptorRFC = fElectronicaValidaCampo(Replace(oCliente.RFC, "-", ""))
            End If

            Dim cmd As New SqlCommand
            Dim sqlParametro As SqlParameter

            With cmd
                .Connection = Me._Conexion
                .CommandTimeout = 0
                .CommandType = CommandType.StoredProcedure
                .CommandText = "MP_VENTAS_ACTUALIZA_RFC_RECEPTOR"

                Try
                    Me._Conexion.Open()

                    sqlParametro = .Parameters.Add("@FOLIO_VENTA", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_VENTA
                    sqlParametro = .Parameters.Add("@RFC_RECEPTOR", SqlDbType.NVarChar, 13) : sqlParametro.Value = sReceptorRFC
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

        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, sProcedure, ex)
        End Try
        Return bResultado
    End Function

    Public Function CancelaMultiplesRemisiones(ByVal sFoliosRemision As String) As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_VENTA_CANCELA_MULTIPLES_REMISIONES"

            sqlParametro = .Parameters.Add("@LISTA_FOLIOS_REMISIONES", SqlDbType.NVarChar) : sqlParametro.Value = sFoliosRemision
            sqlParametro = .Parameters.Add("@CODIGO_PLAZA", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Plaza
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Usuario
            sqlParametro = .Parameters.Add("@FECHA_CANCELACION", SqlDbType.DateTime) : sqlParametro.Value = Me._FECHA_CANCELACION
            sqlParametro = .Parameters.Add("@CONCEPTO_CANCELACION", SqlDbType.NVarChar, 120) : sqlParametro.Value = Me._CONCEPTO_CANCELACION.ToUpper

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "CancelaMultiplesRemisiones", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Function GrabaRelacionRemisionFactura(ByVal sFolioRemision As String) As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_VENTAS_RELACION_FACTURAS_REMISIONES_GRABA"

            sqlParametro = .Parameters.Add("@FOLIO_FACTURA", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_VENTA
            sqlParametro = .Parameters.Add("@FOLIO_REMISION", SqlDbType.NVarChar, 15) : sqlParametro.Value = sFolioRemision

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "GrabaRelacionRemisionFactura", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Function GrabaNotaCreditoPorAnticipo(ByVal sFolioFacturaAnticipo As String) As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CXC_DESCUENTO_ANTICIPO_GRABA_GLOBAL"

            sqlParametro = .Parameters.Add("@FOLIO_VENTA_FINAL", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_VENTA
            sqlParametro = .Parameters.Add("@FOLIO_VENTA_ANTICIPO", SqlDbType.NVarChar, 15) : sqlParametro.Value = sFolioFacturaAnticipo
            sqlParametro = .Parameters.Add("@CODIGO_PLAZA", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Plaza
            sqlParametro = .Parameters.Add("@FOLIO_DESCUENTO", SqlDbType.NVarChar, 15) : sqlParametro.Value = "" : sqlParametro.Direction = ParameterDirection.InputOutput

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()

                Me._FOLIO_DESCUENTO_ANTICIPO = "" & .Parameters("@FOLIO_DESCUENTO").Value.ToString 'Se asegura el cambio del folio

                bResultado = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "GrabaNotaCreditoPorAnticipo", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Friend Function CargaValoresComplementoCartaPorte20() As cComplementoCartaPorte20
        Const sProcedure As String = "CargaValoresComplementoCartaPorte20"
        Dim CCP As New cComplementoCartaPorte20

        Try
            'Crear clases de carta porte, o hacer selects simulando que esta en si es la clase
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim da As SqlDataAdapter
            Dim sSQL As String = ""

            sSQL = "SELECT G.* " &
            "FROM CFDI_CARTA_PORTE_GLOBAL G " &
            "WHERE G.FOLIO_VENTA='" & Replace(Me._FOLIO_VENTA, "'", "''") & "' "

            da = New SqlDataAdapter(sSQL, Me._Conexion)
            Dim dtCartaPorte As New DataTable(""), dRowCartaPorte As DataRow
            da.Fill(dtCartaPorte)
            da.Dispose()

            If dtCartaPorte.Rows.Count = 0 Then
                MsgBox("No se encontraron los datos globales de la carta porte.", MsgBoxStyle.Exclamation, sProcedure)
                Return CCP
            End If

            dRowCartaPorte = dtCartaPorte.Rows(0)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            sSQL = "SELECT D.FECHA_HORA_SALIDA_LLEGADA,D.DISTANCIA_RECORRIDA," &
                    "D.TIPO_UBICACION,U.ID_UBICACION,U.RFC_REMITENTE_DESTINATARIO,U.NOMBRE_REMITENTE_DESTINATARIO,U.NUMERO_IDENTIFICACION_REGISTRO_FISCAL_EXTRANJERO,U.CODIGO_PAIS_SAT_RESIDENCIA_FISCAL," &
                    "U.CALLE,U.NUMERO_EXTERIOR,U.NUMERO_INTERIOR,COL.CODIGO_COLONIA,LOC.CODIGO_LOCALIDAD,U.REFERENCIA,MUN.CODIGO_MUNICIPIO_SAT,EST.CODIGO_ESTADO_SAT,U.CODIGO_PAIS_SAT_DOMICILIO,U.CODIGO_POSTAL " &
                    "FROM CFDI_CARTA_PORTE_DETALLE_UBICACIONES D " &
                    "INNER JOIN CFDI_CAT_UBICACIONES U ON(D.CODIGO_UBICACION=U.CODIGO_UBICACION) " &
                    "LEFT JOIN CFDI_CAT_COLONIAS COL ON(U.ID_COLONIA=COL.ID_COLONIA) " &
                    "LEFT JOIN CFDI_CAT_LOCALIDADES LOC ON(U.ID_LOCALIDAD=LOC.ID_LOCALIDAD) " &
                    "LEFT JOIN CAT_MUNICIPIOS MUN ON(U.CODIGO_MUNICIPIO=MUN.CODIGO_MUNICIPIO) " &
                    "LEFT JOIN SIS_ESTADOS EST ON(U.CODIGO_ESTADO_SAT=EST.CODIGO_ESTADO_SAT) " &
                    "WHERE D.ID_CFDI_CARTA_PORTE_GLOBAL=" & dRowCartaPorte("ID_CFDI_CARTA_PORTE_GLOBAL").ToString  ' drCartaPorte("ID_CFDI_CARTA_PORTE_GLOBAL").ToString

            da = New SqlDataAdapter(sSQL, Me._Conexion)
            Dim dtUbicaciones As New DataTable("")
            da.Fill(dtUbicaciones)
            da.Dispose()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            sSQL = "SELECT D.* " &
                    "FROM CFDI_CARTA_PORTE_DETALLE_MERCANCIAS D " &
                    "WHERE D.ID_CFDI_CARTA_PORTE_GLOBAL=" & dRowCartaPorte("ID_CFDI_CARTA_PORTE_GLOBAL").ToString & " " &
                    "ORDER BY ID_CFDI_CARTA_PORTE_DETALLE_MERCANCIAS"

            da = New SqlDataAdapter(sSQL, Me._Conexion)
            Dim dtMercancias As New DataTable("")
            da.Fill(dtMercancias)
            da.Dispose()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            sSQL = "SELECT V.* " &
                    "FROM CAT_VEHICULOS V " &
                    "WHERE V.CODIGO_VEHICULO=" & dRowCartaPorte("CODIGO_VEHICULO").ToString

            da = New SqlDataAdapter(sSQL, Me._Conexion)
            Dim dtVehiculo As New DataTable("")
            da.Fill(dtVehiculo)
            da.Dispose()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim dtRemolque1 As New DataTable("")
            If txtLEN(dRowCartaPorte("CODIGO_REMOLQUE_1").ToString) = True Then
                sSQL = "SELECT R.* " &
                        "FROM CAT_REMOLQUES R " &
                        "WHERE R.CODIGO_REMOLQUE=" & dRowCartaPorte("CODIGO_REMOLQUE_1").ToString

                da = New SqlDataAdapter(sSQL, Me._Conexion)
                da.Fill(dtRemolque1)
                da.Dispose()
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim dtRemolque2 As New DataTable("")
            If txtLEN(dRowCartaPorte("CODIGO_REMOLQUE_2").ToString) = True Then
                sSQL = "SELECT R.* " &
                        "FROM CAT_REMOLQUES R " &
                        "WHERE R.CODIGO_REMOLQUE=" & dRowCartaPorte("CODIGO_REMOLQUE_2").ToString

                da = New SqlDataAdapter(sSQL, Me._Conexion)
                da.Fill(dtRemolque2)
                da.Dispose()
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            sSQL = "SELECT D.ID_CFDI_CARTA_PORTE_DETALLE_FIGURAS_TRANSPORTE,F.*, " &
                    "COL.CODIGO_COLONIA,LOC.CODIGO_LOCALIDAD,MUN.CODIGO_MUNICIPIO_SAT,EST.CODIGO_ESTADO_SAT " &
                    "FROM CFDI_CARTA_PORTE_DETALLE_FIGURAS_TRANSPORTE D " &
                    "INNER JOIN CFDI_CAT_FIGURAS_TRANSPORTE F ON(D.CODIGO_FIGURA_TRANSPORTE=F.CODIGO_FIGURA_TRANSPORTE) " &
                    "LEFT JOIN CFDI_CAT_COLONIAS COL ON(F.ID_COLONIA=COL.ID_COLONIA) " &
                    "LEFT JOIN CFDI_CAT_LOCALIDADES LOC ON(F.ID_LOCALIDAD=LOC.ID_LOCALIDAD) " &
                    "LEFT JOIN CAT_MUNICIPIOS MUN ON(F.CODIGO_MUNICIPIO=MUN.CODIGO_MUNICIPIO) " &
                    "LEFT JOIN SIS_ESTADOS EST ON(F.CODIGO_ESTADO_SAT=EST.CODIGO_ESTADO_SAT) " &
                    "WHERE D.ID_CFDI_CARTA_PORTE_GLOBAL=" & dRowCartaPorte("ID_CFDI_CARTA_PORTE_GLOBAL").ToString & " " &
                    "ORDER BY D.ID_CFDI_CARTA_PORTE_DETALLE_FIGURAS_TRANSPORTE"

            da = New SqlDataAdapter(sSQL, Me._Conexion)
            Dim dtFiguras As New DataTable("")
            da.Fill(dtFiguras)
            da.Dispose()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            With CCP
                .Version = "" & dRowCartaPorte("VERSION").ToString
                .TranspInternac = "" & dRowCartaPorte("TRANSPORTE_INTERNACIONAL").ToString
                .EntradaSalidaMerc = "" & dRowCartaPorte("ENTRADA_SALIDA_MERCANCIA").ToString
                .PaisOrigenDestino = "" & dRowCartaPorte("CODIGO_PAIS_SAT").ToString
                .ViaEntradaSalida = "" & dRowCartaPorte("CODIGO_TRANSPORTE").ToString
                .TotalDistRec = Format(valorNumericoD(dRowCartaPorte("TOTAL_DISTANCIA_RECORRIDA").ToString), "#0.00")
            End With

            'Ciclo ubicaciones
            For Each dRow As DataRow In dtUbicaciones.Rows
                Dim oUbicacion As New cCCPUbicacion
                With oUbicacion
                    .TipoUbicacion = "" & dRow("TIPO_UBICACION").ToString
                    .IDUbicacion = "" & dRow("ID_UBICACION").ToString
                    .RFCRemitenteDestinatario = "" & dRow("RFC_REMITENTE_DESTINATARIO").ToString
                    .NombreRemitenteDestinatario = "" & dRow("NOMBRE_REMITENTE_DESTINATARIO").ToString
                    .NumRegIdTrib = "" & dRow("NUMERO_IDENTIFICACION_REGISTRO_FISCAL_EXTRANJERO").ToString
                    .ResidenciaFiscal = "" & dRow("CODIGO_PAIS_SAT_RESIDENCIA_FISCAL").ToString
                    .NumEstacion = "" 'Omitido de momento
                    .NombreEstacion = "" 'Omitido de momento
                    .NavegacionTrafico = "" 'Omitido de momento
                    .FechaHoraSalidaLlegada = FormateaFechaSAT(CType(dRow("FECHA_HORA_SALIDA_LLEGADA"), Date))
                    .TipoEstacion = "" 'Omitido de momento
                    .DistanciaRecorrida = Format(valorNumericoD(dRow("DISTANCIA_RECORRIDA").ToString), "#0.00")

                    With .Domicilio
                        .Calle = "" & dRow("CALLE").ToString
                        .NumeroExterior = "" & dRow("NUMERO_EXTERIOR").ToString
                        .NumeroInterior = "" & dRow("NUMERO_INTERIOR").ToString
                        .Colonia = "" & dRow("CODIGO_COLONIA").ToString
                        .Localidad = "" & dRow("CODIGO_LOCALIDAD").ToString
                        .Referencia = "" & dRow("REFERENCIA").ToString
                        .Municipio = "" & dRow("CODIGO_MUNICIPIO_SAT").ToString
                        .Estado = "" & dRow("CODIGO_ESTADO_SAT").ToString
                        .Pais = "" & dRow("CODIGO_PAIS_SAT_DOMICILIO").ToString
                        .CodigoPostal = "" & dRow("CODIGO_POSTAL").ToString
                    End With
                End With

                CCP.Ubicaciones.Add(oUbicacion)
            Next

            'Estos campos aunque sean tipo global mercancia estan en el global de la tabla carta porte.
            With CCP.Mercancias
                .PesoBrutoTotal = Format(valorNumericoD(dRowCartaPorte("PESO_BRUTO_TOTAL").ToString), "#0.000")
                .UnidadPeso = "" & dRowCartaPorte("CODIGO_UNIDAD_PESO").ToString
                .PesoNetoTotal = "" 'Omitido de momento  "#0.000"
                .NumTotalMercancias = "" & dRowCartaPorte("NUMERO_TOTAL_MERCANCIAS").ToString
                .CargoPorTasacion = "" 'Omitido de momento  "#0.00"

                For Each dRow As DataRow In dtMercancias.Rows
                    Dim oMercancia As New cCCPMercancia
                    With oMercancia
                        .BienesTransp = "" & dRow("CODIGO_PRODUCTO_SERVICIO").ToString
                        .ClaveSTCC = "" 'Omitido de momento
                        .Descripcion = "" & dRow("DESCRIPCION").ToString
                        .Cantidad = Format(valorNumericoD(dRow("CANTIDAD").ToString), "#0.000")
                        .ClaveUnidad = "" & dRow("CODIGO_UNIDAD").ToString
                        .Unidad = "" & dRow("UNIDAD").ToString
                        .Dimensiones = "" 'Omitido de momento
                        .MaterialPeligroso = "" 'Omitido de momento
                        .CveMaterialPeligroso = "" 'Omitido de momento
                        .Embalaje = "" 'Omitido de momento
                        .DescripEmbalaje = "" 'Omitido de momento
                        .PesoEnKg = Format(valorNumericoD(dRow("PESO_EN_KG").ToString), "#0.000")
                        .ValorMercancia = IIf(valorNumericoD(dRow("VALOR_MERCANCIA").ToString) > 0, Format(valorNumericoD(dRow("VALOR_MERCANCIA").ToString), "#0.00"), "").ToString
                        .Moneda = "" & dRow("CODIGO_MONEDA_SAT").ToString
                        .FraccionArancelaria = "" 'Omitido de momento
                        .UUIDComercioExt = "" 'Omitido de momento

                        '.Pedimentos 'Omitido de momento Nodo
                        '.GuiasIdentificacion 'Omitido de momento Nodo
                        '.CantidadesTransporta 'Omitido de momento Nodo
                        '.DetalleMercancia 'Omitido de momento Nodo
                    End With
                    .Add(oMercancia)
                Next

                For Each dRow As DataRow In dtVehiculo.Rows 'Siempre va leer un sólo registro
                    With .Autotransporte
                        .PermSCT = "" & dRow("CODIGO_PERMISO_SCT").ToString
                        .NumPermisoSCT = "" & dRow("NUMERO_PERMISO_SCT").ToString

                        .IdentificacionVehicular.ConfigVehicular = "" & dRow("CODIGO_AUTOTRANSPORTE").ToString
                        .IdentificacionVehicular.PlacaVM = "" & dRow("PLACA").ToString
                        .IdentificacionVehicular.AnioModeloVM = "" & dRow("ANIO").ToString

                        .Seguros.AseguraRespCivil = "" & dRow("NOMBRE_ASEGURADORA_RESPONSABILIDAD_CIVIL").ToString
                        .Seguros.PolizaRespCivil = "" & dRow("POLIZA_RESPONSABILIDAD_CIVIL").ToString
                        .Seguros.AseguraMedAmbiente = "" & dRow("NOMBRE_ASEGURADORA_MEDIO_AMBIENTE").ToString
                        .Seguros.PolizaMedAmbiente = "" & dRow("POLIZA_MEDIO_AMBIENTE").ToString
                        .Seguros.AseguraCarga = "" & dRow("NOMBRE_ASEGURADORA_CARGA").ToString
                        .Seguros.PolizaCarga = "" & dRow("POLIZA_CARGA").ToString
                        .Seguros.PrimaSeguro = IIf(valorNumericoD(dRow("PRIMA_SEGURO").ToString) > 0, Format(valorNumericoD(dRow("PRIMA_SEGURO").ToString), "#0.00"), "").ToString

                        If txtLEN("" & dRowCartaPorte("CODIGO_REMOLQUE_1").ToString) = True Then
                            .Remolques.Add(dtRemolque1.Rows(0)("CODIGO_TIPO_REMOLQUE").ToString, dtRemolque1.Rows(0)("PLACA").ToString)
                        End If

                        If txtLEN("" & dRowCartaPorte("CODIGO_REMOLQUE_2").ToString) = True Then
                            .Remolques.Add(dtRemolque2.Rows(0)("CODIGO_TIPO_REMOLQUE").ToString, dtRemolque1.Rows(0)("PLACA").ToString)
                        End If
                    End With
                Next

            End With 'Fin CCP.Mercancias

            For Each dRow As DataRow In dtFiguras.Rows
                Dim oFigura As New cCCPTipoFigura

                With oFigura
                    .TipoFigura = "" & dRow("CODIGO_TIPO_FIGURA_TRANSPORTE").ToString
                    .RFCFigura = "" & dRow("RFC").ToString
                    .NumLicencia = "" & dRow("NUMERO_LICENCIA").ToString
                    .NombreFigura = "" & dRow("NOMBRE_FIGURA_TRANSPORTE").ToString
                    .NumRegIdTribFigura = "" & dRow("NUMERO_IDENTIFICACION_REGISTRO_FISCAL_EXTRANJERO").ToString
                    .ResidenciaFiscalFigura = "" & dRow("CODIGO_PAIS_SAT_RESIDENCIA_FISCAL").ToString

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    sSQL = "SELECT PT.CODIGO_PARTE_TRANSPORTE " &
                    "FROM CFDI_CARTA_PORTE_DETALLE_FIGURAS_TRANSPORTE D " &
                    "INNER JOIN CFDI_CARTA_PORTE_DETALLE_FIGURAS_TRANSPORTE_DETALLE_PARTES_TRANSPORTE PT ON(D.ID_CFDI_CARTA_PORTE_DETALLE_FIGURAS_TRANSPORTE=PT.ID_CFDI_CARTA_PORTE_DETALLE_FIGURAS_TRANSPORTE) " &
                    "WHERE PT.ID_CFDI_CARTA_PORTE_DETALLE_FIGURAS_TRANSPORTE=" & dRow("ID_CFDI_CARTA_PORTE_DETALLE_FIGURAS_TRANSPORTE").ToString & " " &
                    "ORDER BY PT.ID_CFDI_CARTA_PORTE_DETALLE_FIGURAS_TRANSPORTE_DETALLE_PARTES_TRANSPORTE"

                    da = New SqlDataAdapter(sSQL, Me._Conexion)
                    Dim dtFigurasPartesTransporte As New DataTable("")
                    da.Fill(dtFigurasPartesTransporte)
                    da.Dispose()

                    For Each dRowParte As DataRow In dtFigurasPartesTransporte.Rows
                        .PartesTransporte.Add(dRowParte("CODIGO_PARTE_TRANSPORTE").ToString)
                    Next

                    dtFigurasPartesTransporte.Dispose()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    With .Domicilio
                        .Calle = "" & dRow("CALLE").ToString
                        .NumeroExterior = "" & dRow("NUMERO_EXTERIOR").ToString
                        .NumeroInterior = "" & dRow("NUMERO_INTERIOR").ToString
                        .Colonia = "" & dRow("CODIGO_COLONIA").ToString
                        .Localidad = "" & dRow("CODIGO_LOCALIDAD").ToString
                        .Referencia = "" & dRow("REFERENCIA").ToString
                        .Municipio = "" & dRow("CODIGO_MUNICIPIO_SAT").ToString
                        .Estado = "" & dRow("CODIGO_ESTADO_SAT").ToString
                        .Pais = "" & dRow("CODIGO_PAIS_SAT_DOMICILIO").ToString
                        .CodigoPostal = "" & dRow("CODIGO_POSTAL").ToString
                    End With
                End With

                CCP.FiguraTransporte.TiposFigura.Add(oFigura)
            Next

            dtUbicaciones.Dispose()
            dtMercancias.Dispose()
            dtVehiculo.Dispose()
            dtRemolque1.Dispose()
            dtRemolque2.Dispose()
            dtFiguras.Dispose()

            CCP.ValoresComplementoCargados = True

        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, sProcedure, ex)
        End Try

        Return CCP
    End Function

    Public Function ObtenerDetalleParaCartaPorte() As DataTable
        Dim dTabla As New DataTable("detalle"), da As SqlDataAdapter
        Dim sSQL As String

        Try
            sSQL = "SELECT A.CODIGO_PRODUCTO_SERVICIO,A.DESCRIPCION,R.CANTIDAD,A.CODIGO_UNIDAD,U.NOMBRE_UNIDAD,R.UNIDAD_VENTA " &
                "FROM VENTA_DETALLE R " &
                "INNER JOIN CAT_ARTICULOS A ON(R.CODIGO_ARTICULO=A.CODIGO_ARTICULO) " &
                "INNER JOIN CFDI_CAT_UNIDADES U ON(A.CODIGO_UNIDAD=U.CODIGO_UNIDAD) " &
                "WHERE R.FOLIO_VENTA='" & Me._FOLIO_VENTA & "' AND R.CODIGO_ARTICULO<>'-' " &
                "ORDER BY R.ID_VENTA_DETALLE"

            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dTabla)
            da.Dispose()

        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "ObtenerDetalleParaCartaPorte", ex)
        End Try

        Return dTabla
    End Function
#End Region

End Class
