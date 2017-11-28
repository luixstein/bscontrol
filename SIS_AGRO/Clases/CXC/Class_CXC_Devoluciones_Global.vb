Option Strict On

Imports System.Data.SqlClient
Imports System.Net
Imports System.Net.Mail
Imports System.Net.Security
Imports System.Security.Cryptography.X509Certificates
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class Class_CXC_Devoluciones_Global

#Region "Campos"

#Region "Campos de la tabla"
    Private _ID_CXC_DEVOLUCION_GLOBAL As Integer
    Private _FOLIO_DEVOLUCION As String
    Private _FOLIO_VENTA As String
    Private _FOLIO_DESCUENTO_DEVOLUCION As String
    Private _FECHA As Date
    Private _FECHA_SERVIDOR As Date
    Private _CODIGO_DOCUMENTO As String
    Private _CODIGO_PLAZA As Integer
    Private _ESTATUS_DEVOLUCION As String
    Private _CONCEPTO As String
    Private _TIPO_DE_CAMBIO As Decimal
    Private _SUBTOTAL As Decimal
    Private _IMPUESTO As Decimal
    Private _TOTAL As Decimal
    Private _TOTAL_USD As Decimal
    Private _IEPS_DESGLOSADO As Decimal
    Private _IEPS_INCLUIDO As Decimal
    Private _IMPUESTO_PORCENTAJE As Decimal
    Private _COSTO As Decimal
    Private _FOLIO_POLIZA As String
    Private _CODIGO_USUARIO_GRABO As Integer
    Private _CODIGO_USUARIO_CANCELO As Integer
    Private _FECHA_CANCELACION As Date
    Private _FECHA_CANCELACION_SERVIDOR As Date

    Private _FOLIO_NUMERICO As String
    Private _ES_A_PUBLICO_GENERAL As String
    Private _ES_COMPROBANTE_ELECTRONICO As String
    Private _CODIGO_REGIMEN_FISCAL As String
    Private _CODIGO_METODO_PAGO As String
    Private _CODIGO_METODO_PAGO_EVENTO As String
    Private _CODIGO_USO_CFDI As String
    Private _CODIGO_MONEDA_SAT As String
    Private _CODIGO_TIPO_RELACION_CFDI As String

    Private _IDCATALOGO_FOLIO_FELECTRONICA As String
    Private _ID_SIS_CFD_CATALOGO_CERTIFICADOS As String
    Private _ENVIADA_POR_CORREO As Boolean
    Private _VERSION_ESQUEMA_XML As String
    Private _NUMERO_CERTIFICADO_DIGITAL As String
    Private _CADENA_ORIGINAL As String
    Private _SELLO_DIGITAL As String
    Private _TIMBRADO_CFDI As Boolean
    Private _TIMBRADO_DESCARTADO As Boolean
    Private _FOLIO_FISCAL_SAT As String
    Private _FECHA_TIMBRADO_SAT As String
    Private _NUMERO_SERIE_CERTIFICADO_SAT As String
    Private _SELLO_SAT As String
    Private _CBB_IMAGE As String
    Private _RFCPROVCERTIF As String
    Private _LEYENDA As String
    Private _FOLIO_FISCAL_CANCELACION_SAT As String
    Private _ESTATUS_CANCELACION_CFDI As Boolean

#End Region

#Region "Campos ligados a la tabla"
    Private _Existe As Boolean 'lectura
    Private _Nombre_Formato As String
    Private _CODIGO_CLIENTE As String
    Private _NOMBRE_CLIENTE As String
    Private _CODIGO_ALMACEN As String
    Private _NOMBRE_ALMACEN As String
    Private _NOMBRE_USUARIO_GRABO As String
    Private _NOMBRE_USUARIO_CANCELO As String
    Private _SERIE As String

    Private _FELECTRONICA_CER As String
    Private _FELECTRONICA_KEY As String
    Private _FELECTRONICA_CONTRASENIA_CLAVE_PRIVADA As String
#End Region

#Region "Campos públicos"
    Public oDetalle As Class_CXC_Devoluciones_Detalle
#End Region

#Region "Campos privados"

#End Region

#Region "Campos de sistema"
    Private _Conexion As SqlConnection

    Private Declare Function IsNetworkAlive Lib "SENSAPI.DLL" (ByRef lpdwFlags As Long) As Long
#End Region

#End Region

#Region "Propiedades"
#Region "Propiedades Campos de la tabla"
    Public ReadOnly Property ID_CXC_DEVOLUCION_GLOBAL() As Integer
        Get
            Return Me._ID_CXC_DEVOLUCION_GLOBAL
        End Get
    End Property

    Public Property FOLIO_DEVOLUCION() As String
        Get
            Return Me._FOLIO_DEVOLUCION
        End Get
        Set(ByVal Value As String)
            Me._FOLIO_DEVOLUCION = Value
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

    Public Property FOLIO_DESCUENTO_DEVOLUCION() As String
        Get
            Return Me._FOLIO_DESCUENTO_DEVOLUCION
        End Get
        Set(ByVal Value As String)
            Me._FOLIO_DESCUENTO_DEVOLUCION = Value
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

    Public ReadOnly Property FECHA_SERVIDOR() As Date
        Get
            Return Me._FECHA_SERVIDOR
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

    Public ReadOnly Property CODIGO_PLAZA() As Integer
        Get
            Return Me._CODIGO_PLAZA
        End Get
    End Property

    Public ReadOnly Property ESTATUS_DEVOLUCION() As String
        Get
            Return Me._ESTATUS_DEVOLUCION
        End Get
    End Property

    Public ReadOnly Property CODIGO_USUARIO_GRABO() As Integer
        Get
            Return Me._CODIGO_USUARIO_GRABO
        End Get
    End Property

    Public ReadOnly Property CODIGO_USUARIO_CANCELO() As Integer
        Get
            Return Me._CODIGO_USUARIO_CANCELO
        End Get
    End Property

    Public Property CONCEPTO() As String
        Get
            Return Me._CONCEPTO
        End Get
        Set(ByVal Value As String)
            Me._CONCEPTO = Value
        End Set
    End Property

    Public Property TIPO_DE_CAMBIO() As Decimal
        Get
            Return Me._TIPO_DE_CAMBIO
        End Get
        Set(ByVal Value As Decimal)
            Me._TIPO_DE_CAMBIO = Value
        End Set
    End Property

    Public Property SUBTOTAL() As Decimal
        Get
            Return Me._SUBTOTAL
        End Get
        Set(ByVal Value As Decimal)
            Me._SUBTOTAL = Value
        End Set
    End Property

    Public Property IMPUESTO() As Decimal
        Get
            Return Me._IMPUESTO
        End Get
        Set(ByVal Value As Decimal)
            Me._IMPUESTO = Value
        End Set
    End Property

    Public Property TOTAL() As Decimal
        Get
            Return Me._TOTAL
        End Get
        Set(ByVal Value As Decimal)
            Me._TOTAL = Value
        End Set
    End Property

    Public Property IEPS_DESGLOSADO() As Decimal
        Get
            Return Me._IEPS_DESGLOSADO
        End Get
        Set(ByVal Value As Decimal)
            Me._IEPS_DESGLOSADO = Value
        End Set
    End Property

    Public Property IEPS_INCLUIDO() As Decimal
        Get
            Return Me._IEPS_INCLUIDO
        End Get
        Set(ByVal Value As Decimal)
            Me._IEPS_INCLUIDO = Value
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

    Public Property COSTO() As Decimal
        Get
            Return Me._COSTO
        End Get
        Set(ByVal Value As Decimal)
            Me._COSTO = Value
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

    Public ReadOnly Property FOLIO_NUMERICO() As String
        Get
            Return Me._FOLIO_NUMERICO
        End Get
    End Property

    Public Property ES_A_PUBLICO_GENERAL() As String
        Get
            Return Me._ES_A_PUBLICO_GENERAL
        End Get
        Set(ByVal Value As String)
            Me._ES_A_PUBLICO_GENERAL = Value
        End Set
    End Property

    Public ReadOnly Property CODIGO_REGIMEN_FISCAL() As String
        Get
            Return Me._CODIGO_REGIMEN_FISCAL
        End Get
    End Property

    Public Property ES_COMPROBANTE_ELECTRONICO() As String
        Get
            Return Me._ES_COMPROBANTE_ELECTRONICO
        End Get
        Set(ByVal Value As String)
            Me._ES_COMPROBANTE_ELECTRONICO = Value
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

    Public Property CODIGO_MONEDA_SAT() As String
        Get
            Return Me._CODIGO_MONEDA_SAT
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_MONEDA_SAT = Value
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

    ''''''''''''''''''''''''''

    Public ReadOnly Property IDCATALOGO_FOLIO_FELECTRONICA() As String
        Get
            Return Me._IDCATALOGO_FOLIO_FELECTRONICA
        End Get
    End Property

    Public ReadOnly Property ID_SIS_CFD_CATALOGO_CERTIFICADOS() As String
        Get
            Return Me._ID_SIS_CFD_CATALOGO_CERTIFICADOS
        End Get
    End Property

    Public ReadOnly Property ENVIADA_POR_CORREO() As Boolean
        Get
            Return Me._ENVIADA_POR_CORREO
        End Get
    End Property

    Public ReadOnly Property VERSION_ESQUEMA_XML() As String
        Get
            Return Me._VERSION_ESQUEMA_XML
        End Get
    End Property

    Public ReadOnly Property NUMERO_CERTIFICADO_DIGITAL() As String
        Get
            Return Me._NUMERO_CERTIFICADO_DIGITAL
        End Get
    End Property

    Public ReadOnly Property CADENA_ORIGINAL() As String
        Get
            Return Me._CADENA_ORIGINAL
        End Get
    End Property

    Public ReadOnly Property SELLO_DIGITAL() As String
        Get
            Return Me._SELLO_DIGITAL
        End Get
    End Property

    Public ReadOnly Property TIMBRADO_CFDI() As Boolean
        Get
            Return Me._TIMBRADO_CFDI
        End Get
    End Property

    Public ReadOnly Property TIMBRADO_DESCARTADO() As Boolean
        Get
            Return Me._TIMBRADO_DESCARTADO
        End Get
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

    Public ReadOnly Property ESTATUS_CANCELACION_CFDI() As Boolean
        Get
            Return Me._ESTATUS_CANCELACION_CFDI
        End Get
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
            Return "DEVV"
        End Get
    End Property

    Public ReadOnly Property CODIGO_CLIENTE() As String
        Get
            Return Me._CODIGO_CLIENTE
        End Get
    End Property

    Public ReadOnly Property NOMBRE_CLIENTE() As String
        Get
            Return Me._NOMBRE_CLIENTE
        End Get
    End Property

    Public ReadOnly Property CODIGO_ALMACEN() As String
        Get
            Return Me._CODIGO_ALMACEN
        End Get
    End Property

    Public ReadOnly Property NOMBRE_ALMACEN() As String
        Get
            Return Me._NOMBRE_ALMACEN
        End Get
    End Property

    Public ReadOnly Property NOMBRE_USUARIO_GRABO() As String
        Get
            Return Me._NOMBRE_USUARIO_GRABO
        End Get
    End Property

    Public ReadOnly Property NOMBRE_USUARIO_CANCELO() As String
        Get
            Return Me._NOMBRE_USUARIO_GRABO
        End Get
    End Property

    Public ReadOnly Property SERIE() As String
        Get
            Return Me._SERIE
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
#End Region

#Region "Propiedades de campos privados"

#End Region

#Region "Propiedades de campos de sistema"
    Public ReadOnly Property Nombre_Clase() As String
        Get
            Return "Class_CXC_Descuentos"
        End Get
    End Property
#End Region
#End Region

#Region "Constructor y destructor"
    Public Sub New()
        Me._Conexion = New SqlConnection(Empresa_Sistema.conexion)
        oDetalle = New Class_CXC_Devoluciones_Detalle
    End Sub

    Public Sub New(ByVal FolioDevolucion As String)
        Me.New()
        Try
            Me._FOLIO_DEVOLUCION = FolioDevolucion
            If Me.Consultar = False Then
                'Throw New Exception("El documento de venta no existe.")
            Else
                Me._Existe = True
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "New", ex)
        End Try
    End Sub
#End Region

#Region "Métodos y procedimientos"
    Public Function GrabaDevolucionGlobal() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = _Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CXC_DEVOLUCIONES_GRABA_GLOBAL"

            Try
                sqlParametro = .Parameters.Add("@FOLIO_DEVOLUCION", SqlDbType.NVarChar, 15) : sqlParametro.Value = "" : sqlParametro.Direction = ParameterDirection.InputOutput
                sqlParametro = .Parameters.Add("@FOLIO_VENTA", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_VENTA
                sqlParametro = .Parameters.Add("@FOLIO_DESCUENTO_DEVOLUCION_APLICADO", SqlDbType.NVarChar, 15) : sqlParametro.Value = "" : sqlParametro.Direction = ParameterDirection.InputOutput
                sqlParametro = .Parameters.Add("@FECHA", SqlDbType.DateTime) : sqlParametro.Value = Me._FECHA
                sqlParametro = .Parameters.Add("@CODIGO_DOCUMENTO", SqlDbType.NVarChar, 10) : sqlParametro.Value = Me._CODIGO_DOCUMENTO
                sqlParametro = .Parameters.Add("@CODIGO_PLAZA", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Plaza
                sqlParametro = .Parameters.Add("@CONCEPTO", SqlDbType.NVarChar, 200) : sqlParametro.Value = Me._CONCEPTO.ToUpper
                sqlParametro = .Parameters.Add("@TIPO_DE_CAMBIO", SqlDbType.Decimal) : sqlParametro.Value = Me._TIPO_DE_CAMBIO
                sqlParametro = .Parameters.Add("@SUBTOTAL", SqlDbType.Decimal) : sqlParametro.Value = Me._SUBTOTAL
                sqlParametro = .Parameters.Add("@IMPUESTO", SqlDbType.Decimal) : sqlParametro.Value = Me._IMPUESTO
                sqlParametro = .Parameters.Add("@TOTAL", SqlDbType.Decimal) : sqlParametro.Value = Me._TOTAL
                sqlParametro = .Parameters.Add("@IEPS_DESGLOSADO", SqlDbType.Decimal) : sqlParametro.Value = Me._IEPS_DESGLOSADO
                sqlParametro = .Parameters.Add("@IEPS_INCLUIDO", SqlDbType.Decimal) : sqlParametro.Value = Me._IEPS_INCLUIDO
                sqlParametro = .Parameters.Add("@IMPUESTO_PORCENTAJE", SqlDbType.Decimal) : sqlParametro.Value = Me._IMPUESTO_PORCENTAJE
                sqlParametro = .Parameters.Add("@CODIGO_USUARIO_GRABO", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Usuario
                sqlParametro = .Parameters.Add("@ES_COMPROBANTE_ELECTRONICO", SqlDbType.NVarChar, 1) : sqlParametro.Value = Me._ES_COMPROBANTE_ELECTRONICO
                sqlParametro = .Parameters.Add("@ES_A_PUBLICO_GENERAL", SqlDbType.NVarChar, 1) : sqlParametro.Value = Me._ES_A_PUBLICO_GENERAL
                sqlParametro = .Parameters.Add("@CODIGO_METODO_PAGO", SqlDbType.NVarChar, 2) : sqlParametro.Value = Me._CODIGO_METODO_PAGO
                sqlParametro = .Parameters.Add("@CODIGO_METODO_PAGO_EVENTO", SqlDbType.NVarChar, 4) : sqlParametro.Value = Me._CODIGO_METODO_PAGO_EVENTO
                sqlParametro = .Parameters.Add("@CODIGO_USO_CFDI", SqlDbType.NVarChar, 4) : sqlParametro.Value = Me._CODIGO_USO_CFDI
                sqlParametro = .Parameters.Add("@CODIGO_MONEDA_SAT", SqlDbType.NVarChar, 3) : sqlParametro.Value = Me._CODIGO_MONEDA_SAT

                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True

                Me._FOLIO_DEVOLUCION = "" & .Parameters("@FOLIO_DEVOLUCION").Value.ToString
                Me._FOLIO_DESCUENTO_DEVOLUCION = "" & .Parameters("@FOLIO_DESCUENTO_DEVOLUCION_APLICADO").Value.ToString
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "GrabaDevolucionGlobal", ex)
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
        Dim cmd As New SqlCommand("SELECT DG.*," &
                                  "S1.NOMBRE_USUARIO NOMBRE_USUARIO_GRABO," &
                                    "DOC.NOMBRE_FORMATO,S2.NOMBRE_USUARIO NOMBRE_USUARIO_CANCELO," &
                                    "VG.CODIGO_ALMACEN,ALM.NOMBRE_ALMACEN,VG.CODIGO_CLIENTE,CTE.NOMBRE_CLIENTE," &
                                    "CFD.FELECTRONICA_CER,CFD.FELECTRONICA_KEY,CFD.CONTRASEÑA,CFFE.SERIE " &
                                    "FROM CXC_DEVOLUCION_GLOBAL DG " &
                                    "INNER JOIN SIS_USUARIOS S1 ON(DG.CODIGO_USUARIO_GRABO=S1.CODIGO_USUARIO) " &
                                    "LEFT JOIN SIS_USUARIOS S2 ON(DG.CODIGO_USUARIO_CANCELO=S2.CODIGO_USUARIO) " &
                                    "INNER JOIN VENTA_GLOBAL VG ON(DG.FOLIO_VENTA=VG.FOLIO_VENTA) " &
                                    "INNER JOIN CAT_ALMACENES ALM ON(VG.CODIGO_ALMACEN=ALM.CODIGO_ALMACEN) " &
                                    "INNER JOIN CAT_CLIENTES CTE ON(VG.CODIGO_CLIENTE=CTE.CODIGO_CLIENTE) " &
                                    "INNER JOIN VW_SIS_CAT_DOCUMENTOS_EXTENDIDO DOC ON(DG.CODIGO_DOCUMENTO=DOC.CODIGO_DOCUMENTO) " &
                                    "LEFT JOIN SIS_CFD_CATALOGO_CERTIFICADOS CFD ON(DG.ID_SIS_CFD_CATALOGO_CERTIFICADOS=CFD.ID_SIS_CFD_CATALOGO_CERTIFICADOS) " &
                                    "LEFT JOIN CATALOGO_FOLIOS_FACTURAS_ELECTRONICAS CFFE ON(DG.IDCATALOGO_FOLIO_FELECTRONICA=CFFE.IDCATALOGO_FOLIO_FELECTRONICA)" &
                                    "WHERE DG.FOLIO_DEVOLUCION='" & sReplace(Me._FOLIO_DEVOLUCION) & "' AND DG.CODIGO_PLAZA=" & Plaza.CODIGO_PLAZA.ToString, Me._Conexion)

        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read = True Then
                    Me._ID_CXC_DEVOLUCION_GLOBAL = CInt(dReader("ID_CXC_DEVOLUCION_GLOBAL"))
                    Me._FOLIO_DEVOLUCION = "" & dReader("FOLIO_DEVOLUCION").ToString()
                    Me._FOLIO_VENTA = "" & dReader("FOLIO_VENTA").ToString()
                    Me._FOLIO_DESCUENTO_DEVOLUCION = "" & dReader("FOLIO_DESCUENTO_DEVOLUCION").ToString()
                    Me._FECHA = CDate(dReader("FECHA"))
                    Me._FECHA_SERVIDOR = CDate(dReader("FECHA_SERVIDOR"))
                    Me._CODIGO_DOCUMENTO = "" & dReader("CODIGO_DOCUMENTO").ToString()
                    Me._CODIGO_PLAZA = CInt(dReader("CODIGO_PLAZA"))
                    Me._ESTATUS_DEVOLUCION = "" & dReader("ESTATUS_DEVOLUCION").ToString()
                    Me._CONCEPTO = "" & dReader("CONCEPTO").ToString()
                    Me._TIPO_DE_CAMBIO = CDec(dReader("TIPO_DE_CAMBIO"))
                    Me._SUBTOTAL = CDec(dReader("SUBTOTAL"))
                    Me._IMPUESTO = CDec(dReader("IMPUESTO"))
                    Me._TOTAL = CDec(dReader("TOTAL"))
                    Me._TOTAL_USD = CDec(dReader("TOTAL_USD"))
                    Me._IEPS_DESGLOSADO = CDec(dReader("IEPS_DESGLOSADO"))
                    Me._IEPS_INCLUIDO = CDec(dReader("IEPS_INCLUIDO"))
                    Me._IMPUESTO_PORCENTAJE = CDec(dReader("IMPUESTO_PORCENTAJE"))
                    Me._COSTO = CDec(dReader("COSTO"))
                    Me._FOLIO_POLIZA = "" & dReader("FOLIO_POLIZA").ToString()
                    Me._CODIGO_USUARIO_GRABO = CInt(dReader("CODIGO_USUARIO_GRABO"))

                    If Me._ESTATUS_DEVOLUCION = "C" Then
                        Me._CODIGO_USUARIO_CANCELO = CInt(dReader("CODIGO_USUARIO_CANCELO"))
                        Me._NOMBRE_USUARIO_CANCELO = "" & dReader("NOMBRE_USUARIO_CANCELO").ToString
                        Me._FECHA_CANCELACION = CDate(dReader("FECHA_CANCELACION"))
                        Me._FECHA_CANCELACION_SERVIDOR = CDate(dReader("FECHA_CANCELACION_SERVIDOR"))
                    End If

                    Me._Nombre_Formato = "" & Trim(dReader("NOMBRE_FORMATO").ToString)

                    Me._CODIGO_CLIENTE = "" & dReader("CODIGO_CLIENTE").ToString()
                    Me._NOMBRE_CLIENTE = "" & dReader("NOMBRE_CLIENTE").ToString()
                    Me._NOMBRE_USUARIO_GRABO = "" & dReader("NOMBRE_USUARIO_GRABO").ToString()
                    Me._CODIGO_ALMACEN = "" & dReader("CODIGO_ALMACEN").ToString()
                    Me._NOMBRE_ALMACEN = "" & dReader("NOMBRE_ALMACEN").ToString()

                    Me._FOLIO_NUMERICO = "" & dReader("FOLIO_NUMERICO").ToString()
                    Me._ES_A_PUBLICO_GENERAL = "" & dReader("ES_A_PUBLICO_GENERAL").ToString()
                    Me._ES_COMPROBANTE_ELECTRONICO = "" & dReader("ES_COMPROBANTE_ELECTRONICO").ToString()
                    Me._CODIGO_REGIMEN_FISCAL = "" & dReader("CODIGO_REGIMEN_FISCAL").ToString()
                    Me._CODIGO_METODO_PAGO = "" & dReader("CODIGO_METODO_PAGO").ToString()
                    Me._CODIGO_METODO_PAGO_EVENTO = "" & dReader("CODIGO_METODO_PAGO_EVENTO").ToString()
                    Me._CODIGO_USO_CFDI = "" & dReader("CODIGO_USO_CFDI").ToString()
                    Me._CODIGO_MONEDA_SAT = "" & dReader("CODIGO_MONEDA_SAT").ToString()
                    Me._CODIGO_TIPO_RELACION_CFDI = "" & dReader("CODIGO_TIPO_RELACION_CFDI").ToString()

                    Me._IDCATALOGO_FOLIO_FELECTRONICA = "" & dReader("IDCATALOGO_FOLIO_FELECTRONICA").ToString()
                    Me._ID_SIS_CFD_CATALOGO_CERTIFICADOS = "" & dReader("ID_SIS_CFD_CATALOGO_CERTIFICADOS").ToString()
                    Me._ENVIADA_POR_CORREO = CBool(dReader("ENVIADA_POR_CORREO").ToString())
                    Me._VERSION_ESQUEMA_XML = "" & dReader("VERSION_ESQUEMA_XML").ToString()
                    Me._NUMERO_CERTIFICADO_DIGITAL = "" & dReader("NUMERO_CERTIFICADO_DIGITAL").ToString()
                    Me._CADENA_ORIGINAL = "" & dReader("CADENA_ORIGINAL").ToString()
                    Me._SELLO_DIGITAL = "" & dReader("SELLO_DIGITAL").ToString()
                    Me._TIMBRADO_CFDI = CBool(dReader("TIMBRADO_CFDI").ToString())
                    Me._TIMBRADO_DESCARTADO = CBool(dReader("TIMBRADO_DESCARTADO").ToString())
                    Me._FOLIO_FISCAL_SAT = "" & dReader("FOLIO_FISCAL_SAT").ToString()
                    Me._FECHA_TIMBRADO_SAT = "" & dReader("FECHA_TIMBRADO_SAT").ToString()
                    Me._NUMERO_SERIE_CERTIFICADO_SAT = "" & dReader("NUMERO_SERIE_CERTIFICADO_SAT").ToString()
                    Me._SELLO_SAT = "" & dReader("SELLO_SAT").ToString()
                    Me._CBB_IMAGE = "" & dReader("CBB_IMAGE").ToString()
                    Me._RFCPROVCERTIF = "" & dReader("RFCPROVCERTIF").ToString()
                    Me._LEYENDA = "" & dReader("LEYENDA").ToString()
                    Me._FOLIO_FISCAL_CANCELACION_SAT = "" & dReader("FOLIO_FISCAL_CANCELACION_SAT").ToString()
                    Me._ESTATUS_CANCELACION_CFDI = CBool(dReader("ESTATUS_CANCELACION_CFDI").ToString())

                    Me._SERIE = "" & Trim(dReader("SERIE").ToString)
                    Me._FELECTRONICA_CER = "" & dReader("FELECTRONICA_CER").ToString
                    Me._FELECTRONICA_KEY = "" & dReader("FELECTRONICA_KEY").ToString
                    Me._FELECTRONICA_CONTRASENIA_CLAVE_PRIVADA = IIf(txtLEN("" & dReader("CONTRASEÑA").ToString) = True, Decrypt("" & dReader("CONTRASEÑA").ToString, "r7"), "").ToString

                    bResultado = True
                End If
                dReader.Close()
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "Consultar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
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
            .CommandText = "MP_CXC_DEVOLUCIONES_CANCELA"

            sqlParametro = .Parameters.Add("@FOLIO_DEVOLUCION", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_DEVOLUCION
            sqlParametro = .Parameters.Add("@CODIGO_DOCUMENTO", SqlDbType.NVarChar, 10) : sqlParametro.Value = Me._CODIGO_DOCUMENTO
            sqlParametro = .Parameters.Add("@CODIGO_PLAZA", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Plaza
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Usuario
            sqlParametro = .Parameters.Add("@FECHA_CANCELACION", SqlDbType.DateTime) : sqlParametro.Value = Me._FECHA_CANCELACION
            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "Cancelar", ex)
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
            .CommandText = "MP_CXC_DEVOLUCIONES_AFECTA_INVENTARIOS"

            sqlParametro = .Parameters.Add("@FOLIO_DEVOLUCION", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_DEVOLUCION
            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "AfectaInventarios", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Function BusquedaVisual_PorFolio() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de devoluciones en CXC."
        f.sCampo = "DG.FOLIO_DEVOLUCION"
        f.sOrder = "DG.FOLIO_DEVOLUCION"
        f.sTable = "CXC_DEVOLUCION_GLOBAL"
        f.sQl = "SELECT DG.FOLIO_DEVOLUCION,DG.TOTAL,DBO.FN_FORMAT_FECHA_CORTO(DG.FECHA) FECHA,CTE.NOMBRE_CLIENTE,VG.CONCEPTO FROM CXC_DEVOLUCION_GLOBAL DG " &
            "INNER JOIN VENTA_GLOBAL VG ON(DG.FOLIO_VENTA=VG.FOLIO_VENTA) INNER JOIN CAT_CLIENTES CTE ON(VG.CODIGO_CLIENTE=CTE.CODIGO_CLIENTE) " &
            "WHERE DG.CODIGO_PLAZA='" & Usuario.Codigo_Plaza & "' AND "
        f.Inicia("")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "BusquedaVisual_PorFolio", ex)
        End Try
        Return Resultado
    End Function

    Public Function ObtenerDetalle() As DataTable
        Dim dTabla As New DataTable("detalle"), da As SqlDataAdapter
        Dim sSQL As String

        sSQL = "SELECT DR.CODIGO_ARTICULO," &
            "CASE WHEN ART.ES_SERIALIZABLE = '1' THEN 'SER' WHEN ART.INVENTARIABLE= '1' THEN 'INV' ELSE 'NIV' END TIPO_CONTROL_INVENTARIO," &
            "VR.DESCRIPCION,DR.CANTIDAD,DR.PRECIO,DR.PRECIO_TOTAL,VR.UNIDAD_VENTA,DR.IMPUESTO_PORCENTAJE,DR.IMPORTE,DR.IMPUESTO_IMPORTE,DR.ID_VENTA_DETALLE,DR.IEPS_PORCENTAJE,DR.IEPS_UNITARIO,DR.IEPS_IMPORTE,DR.BASE_IEPS,DR.BASE_IVA " &
            "FROM CXC_DEVOLUCION_DETALLE DR " &
            "INNER JOIN CAT_ARTICULOS ART ON(DR.CODIGO_ARTICULO=ART.CODIGO_ARTICULO) " &
            "INNER JOIN VENTA_DETALLE VR ON(DR.ID_VENTA_DETALLE=VR.ID_VENTA_DETALLE) " &
            "WHERE DR.FOLIO_DEVOLUCION='" & sReplace(Me._FOLIO_DEVOLUCION) & "' " &
            "ORDER BY DR.ID_CXC_DEVOLUCION_DETALLE"

        Try
            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dTabla)

            da.Dispose()
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "ObtenerDetalle", ex)
        End Try

        Return dTabla
    End Function

    Public Sub NuevoRenglon()
        Me.oDetalle = New Class_CXC_Devoluciones_Detalle
    End Sub

    Public Sub Imprimir()
        Dim Rpt As New ReportDocument
        Dim oReporte As Class_Reporte

        Try
            oReporte = New Class_Reporte(Me._Nombre_Formato, Rpt, False)

            If Not oReporte.RptCargado Then
                Exit Sub
            End If

            Rpt.SetParameterValue("@FOLIO_DEVOLUCION", Me._FOLIO_DEVOLUCION)

            Dim frm As New Reporte(Rpt)
            frm.CRViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            frm.Show()

        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "Imprimir", ex)
        Finally
            oReporte = Nothing
        End Try
    End Sub

    Public Function GeneraDevolucionElectronica(ByVal bMensajes As Boolean, ByVal bGenerarPDF As Boolean) As Boolean
        Dim bResultado As Boolean = False
        Dim sProcedure As String = "GeneraDevolucionElectronica"
        Dim sRutaXML As String

        Try
            sRutaXML = sFelectronicaCarpetaXMLPDF & "\" & Me._FOLIO_DEVOLUCION & ".xml"

            If Me._TIMBRADO_CFDI = False Then
                bResultado = FacturacionElectronica33.GeneraDevolucionElectronica33(Me, bMensajes, sRutaXML)

                If bResultado = False Then
                    MsgBox("Los datos digitales del documento no fueron generados correctamente. Avíse al depto. de sistemas.", vbExclamation, sProcedure)
                Else
                    bResultado = True
                    If bGenerarPDF = True Then
                        Me.ExportarAPdf()
                    End If
                End If
                'Else
                '    Me.RecuperarFacturaElectronicaLocal(bMensajes)
            Else
                MsgBox("La devolución ya esta timbrada.", vbExclamation, sProcedure)
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, sProcedure, ex)
        End Try
        Return bResultado
    End Function

    Public Function ExportarAPdf(Optional ByVal sRutaPDF As String = "") As Boolean
        Dim bResultado As Boolean = False
        Dim Rpt As New ReportDocument
        Dim oReporte As Class_Reporte

        Try
            If txtLEN(sRutaPDF) = False Then 'Si no trae un nombre en especifico lo crea con el nombre del folio
                sRutaPDF = sFelectronicaCarpetaXMLPDF & "\" & Me._FOLIO_DEVOLUCION.ToString & ".PDF"
            End If

            oReporte = New Class_Reporte(Me._Nombre_Formato, Rpt, False)

            Rpt.SetParameterValue("@FOLIO_DEVOLUCION", Me._FOLIO_DEVOLUCION)

            If Not oReporte.RptCargado Then
                Exit Function
            End If

            Rpt.ExportToDisk(ExportFormatType.PortableDocFormat, sRutaPDF)

            Rpt.Dispose()

            bResultado = True

        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "ExportarAPdf", ex)
        Finally
            oReporte = Nothing
        End Try

        Return bResultado
    End Function

    Public Function ObtenerDetalleParaCFDI(Optional ByVal bSinComentarios As Boolean = True) As DataTable
        Dim dTabla As New DataTable("detalle"), da As SqlDataAdapter
        Dim sSQL As String

        Try
            sSQL = "SELECT R.CODIGO_ARTICULO,VR.DESCRIPCION,R.CANTIDAD,R.PRECIO,R.PRECIO_TOTAL,VR.UNIDAD_VENTA,R.IMPUESTO_PORCENTAJE,R.IMPORTE," &
                "R.IMPUESTO_IMPORTE,R.ID_CXC_DEVOLUCION_DETALLE," &
                "A.CODIGO_PRODUCTO_SERVICIO,A.CODIGO_UNIDAD,R.IEPS_PORCENTAJE,R.IEPS_UNITARIO,R.IEPS_IMPORTE,R.BASE_IEPS,R.BASE_IVA,R.PRECIO_TOTAL " &
                "FROM CXC_DEVOLUCION_DETALLE R " &
                "INNER JOIN CAT_ARTICULOS A ON(R.CODIGO_ARTICULO=A.CODIGO_ARTICULO) " &
                "INNER JOIN VENTA_DETALLE VR ON(R.ID_VENTA_DETALLE=VR.ID_VENTA_DETALLE) " &
                "WHERE R.FOLIO_DEVOLUCION='" & Me._FOLIO_DEVOLUCION & "' " &
                IIf(bSinComentarios = True, " AND R.CODIGO_ARTICULO<>'-' ", " ").ToString &
                "ORDER BY R.ID_CXC_DEVOLUCION_DETALLE"

            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dTabla)
            da.Dispose()

        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "ObtenerDetalleParaCFDI", ex)
        End Try

        Return dTabla
    End Function

    Public Function EnviarCorreo() As Boolean
        Dim sProcedure As String = "EnviarCorreo"
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

            MyMailMsg.Subject = "CFDI DE DEVOLUCION A " & Empresa_Sistema.NOMBRE_EMPRESA

            For n = 0 To UBound(tabla, 1)
                MyMailMsg.To.Add(tabla(n))
            Next

            MyMailMsg.From = New MailAddress(Usuario.CORREO_USUARIO.ToString)
            MyMailMsg.Priority = MailPriority.Normal
            MyMailMsg.Body = "DEVOLUCION " & Me._FOLIO_DEVOLUCION

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
                        sNombreXmlTimbrado = Empresa_Sistema.RFC & "-" & Me._SERIE & "-" & Me._FOLIO_NUMERICO
                    Case "RFCemisor-Fecha-SerieFolio"
                        sNombreXmlTimbrado = Empresa_Sistema.RFC & Format(Me._FOLIO_DEVOLUCION, "yyyyddMM") & Me._SERIE & Me._FOLIO_NUMERICO
                End Select
            Else
                sNombreXmlTimbrado = Me._FOLIO_DEVOLUCION
            End If

            sRutaXML = sFelectronicaCarpetaXmlsTimbrados & "\" & sNombreXmlTimbrado & ".xml"
            sRutaPDF = archivos.ToString & sNombreXmlTimbrado & ".PDF"

            If Me.RecuperaXML(sRutaXML) = True Then
                If Me.ExportarAPdf(sRutaPDF) = False Then
                    MsgBox("No se logró generar el PDF del documento : " & Me._FOLIO_DEVOLUCION & ". Avíse al depto. de sistemas.", vbExclamation, sProcedure)
                    Return False
                End If
            Else
                MsgBox("No se logró recuperar el XML del documento : " & Me._FOLIO_DEVOLUCION & ". Avíse al depto. de sistemas.", vbExclamation, sProcedure)
                Return False
            End If

            Me.MarcaEnviadoxCorreo(Me._FOLIO_DEVOLUCION)

            Dim msa As New Attachment(sRutaPDF)
            MyMailMsg.Attachments.Add(msa)
            msa = New Attachment(sRutaXML)
            MyMailMsg.Attachments.Add(msa)

            ServicePointManager.ServerCertificateValidationCallback = Function(s As Object, certificate As X509Certificate, chain As X509Chain, sslPolicyErrors As SslPolicyErrors) True

            SMTP.Send(MyMailMsg)

            MsgBox("Tu E-Mail se ha enviado exitosamente.", MsgBoxStyle.Information, sProcedure)

            Return True

        Catch ex As Exception
            HandleError(Me.Nombre_Clase, sProcedure, ex)
        End Try
    End Function

    Private Function MarcaEnviadoxCorreo(ByVal sFolio As String) As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CFDI_DEVOLUCIONES_CXC_MARCA_CORREO_ENVIADO"

            sqlParametro = .Parameters.Add("@FOLIO_DEVOLUCION", SqlDbType.NVarChar, 15) : sqlParametro.Value = sFolio

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "MarcaEnviadoxCorreo", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With

        Return bResultado
    End Function

    Private Function RecuperaXML(ByVal sRutaXML As String) As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        Dim docXml As Xml.XmlDocument = New Xml.XmlDocument

        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CFDI_DEVOLUCIONES_CXC_RECUPERA_CADENA_XML"

            sqlParametro = .Parameters.Add("@FOLIO_DEVOLUCION", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_DEVOLUCION
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
                HandleError(Me.Nombre_Clase, "RecuperaXML", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With

        Return bResultado
    End Function

    Public Function RecuperaXMLyPDF() As Boolean
        Dim sProcedure As String = "EnviarCorreo"
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
                        sNombreXmlTimbrado = Empresa_Sistema.RFC & Format(Me._FOLIO_DEVOLUCION, "yyyyddMM") & Me._SERIE & Me._FOLIO_NUMERICO
                End Select
            Else
                sNombreXmlTimbrado = Me._FOLIO_DEVOLUCION
            End If

            sRutaXML = sFelectronicaCarpetaXmlsTimbrados & "\" & sNombreXmlTimbrado & ".xml"
            sRutaPDF = archivos.ToString & sNombreXmlTimbrado & ".PDF"

            If Me.RecuperaXML(sRutaXML) = True Then
                If Me.ExportarAPdf(sRutaPDF) = False Then
                    MsgBox("Se logró recuperar el XML pero no se logró generar el PDF del documento : " & Me._FOLIO_DEVOLUCION & ". Avíse al depto. de sistemas.", vbExclamation, sProcedure)
                    Return False
                Else
                    bResultado = True
                End If
            Else
                MsgBox("No se logró recuperar el XML y PDF del documento : " & Me._FOLIO_DEVOLUCION & ". Avíse al depto. de sistemas.", vbExclamation, sProcedure)
                Return False
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    Public Function CancelarTimbre() As Boolean
        Dim bResultado As Boolean = False
        Dim sProcedure As String = "CancelarTimbre"
        Try
            If Me.Consultar() = False Then 'Refrescamos la factura para tener los datos mas nuevos.
                Return False
            End If

            If Me._ESTATUS_DEVOLUCION <> "C" Then
                MsgBox("El documento no esta cancelado.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            If Me._TIMBRADO_DESCARTADO = True Then
                MsgBox("El timbre esta descartado.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            If Me._ESTATUS_CANCELACION_CFDI = True Then
                MsgBox("El timbre ya esta cancelado.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            bResultado = CancelarCFDI(Me._FOLIO_DEVOLUCION, Me._SERIE, CInt(Me._FOLIO_NUMERICO), Me._FOLIO_FISCAL_SAT, Convert.ToInt32(Me._TIMBRADO_CFDI).ToString, TipoComprobante.DEVOLUCION_CXC)

        Catch ex As Exception
            HandleError(Me.Nombre_Clase, sProcedure, ex)
        End Try

        Return bResultado
    End Function


#End Region

End Class
