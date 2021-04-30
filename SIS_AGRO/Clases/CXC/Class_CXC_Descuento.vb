Option Strict On

Imports System.Data.SqlClient
Imports System.Net
Imports System.Net.Mail
Imports System.Net.Security
Imports System.Security.Cryptography.X509Certificates
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class Class_CXC_Descuento

#Region "Campos"

#Region "Campos de la tabla"
    Private _ID_CXC_DESCUENTOS_GLOBAL As Integer
    Private _FOLIO_DESCUENTO As String
    Private _CODIGO_PLAZA As Integer
    Private _CODIGO_DOCUMENTO As String
    Private _CODIGO_CLIENTE As String
    Private _NOMBRE_CLIENTE As String
    Private _FECHA As Date
    Private _FECHA_SERVIDOR As Date
    Private _ESTATUS_DESCUENTO As String
    Private _CONCEPTO1 As String
    Private _CONCEPTO2 As String
    Private _FOLIO_POLIZA As String
    Private _CODIGO_USUARIO_GRABO As Integer
    Private _NOMBRE_USUARIO_GRABO As String
    Private _CODIGO_USUARIO_CANCELO As Integer
    Private _NOMBRE_USUARIO_CANCELO As String
    Private _FECHA_CANCELACION As Date
    Private _FECHA_CANCELACION_SERVIDOR As Date
    Private _TIPO_DE_CAMBIO As Double
    Private _SUBTOTAL As Double
    Private _IVA As Double
    Private _IEPS_DESGLOSADO As Double
    Private _IEPS_INCLUIDO As Double
    Private _TOTAL As Double
    Private _ES_COMPROBANTE_ELECTRONICO As String
    Private _FOLIO_NUMERICO As Integer
    Private _SERIE As String
    'Private _IDCATALOGO_FOLIO_FELECTRONICA As Integer
    Private _ID_SIS_CFD_CATALOGO_CERTIFICADOS As Integer
    Private _CADENA_ORIGINAL As String
    Private _SELLO_DIGITAL As String
    Private _ES_VENTA_PUBLICO_GENERAL As String
    Private _ES_POR_DEVOLUCION As String
    Private _IMPUESTO_PORCENTAJE As Double
    Private _RETENCION As Double
    Private _CODIGO_METODO_PAGO As String
    Private _CODIGO_REGIMEN_FISCAL As String
    Private _FOLIO_FISCAL_SAT As String
    Private _FECHA_TIMBRADO_SAT As String
    Private _NUMERO_SERIE_CERTIFICADO_SAT As String
    Private _SELLO_SAT As String
    Private _CBB_IMAGE As String
    Private _FOLIO_FISCAL_CANCELACION_SAT As String
    Private _TIMBRADO_CFDI As String
    Private _ESTATUS_CANCELACION_CFDI As String
    Private _TIMBRADO_DESCARTADO As String
    Private _VERSION_ESQUEMA_XML As String
    Private _CODIGO_METODO_PAGO_EVENTO As String
    Private _CODIGO_USO_CFDI As String
    Private _CODIGO_MONEDA_SAT As String
    Private _CODIGO_TIPO_RELACION_CFDI As String
    Private _RETENCION_IVA As Double
    Private _RETENCION_IVA_PORCENTAJE As Double
    Private _DIFERENCIA_CAMBIARIA As Decimal
    Private _SUBTOTAL_USD As Decimal
    Private _IVA_USD As Decimal
    Private _TOTAL_USD As Decimal
    Private _SUBTOTAL_MXN_ANTICIPO As Decimal
#End Region

#Region "Campos de control"

#End Region

#Region "Campos de sistema"
    Private _Nombre_Catalogo As String
    Private _Conexion As SqlConnection
    Private _QuerySelect As String
    Private _QueryOrder As String

    Private Declare Function IsNetworkAlive Lib "SENSAPI.DLL" (ByRef lpdwFlags As Long) As Long
#End Region

#Region "Campos ligados a la tabla"
    Private _Existe As Boolean 'lectura
    Private _Nombre_Formato As String
    Private _NOMBRE_METODO_PAGO As String
    Private _NOMBRE_REGIMEN_FISCAL As String
    Private _FELECTRONICA_CER As String
    Private _FELECTRONICA_KEY As String
    Private _FELECTRONICA_CONTRASENIA_CLAVE_PRIVADA As String
    Private _LISTA_DESCUENTOS As String
#End Region

#Region "Campos de privado"
    Private _oDocumento As Class_CatDocumentos
#End Region

#End Region

#Region "Propiedades"
#Region "Propiedades Campos de la tabla"
    Public ReadOnly Property ID_CXC_DESCUENTOS_GLOBAL() As Integer
        Get
            Return Me._ID_CXC_DESCUENTOS_GLOBAL
        End Get
    End Property

    Public Property FOLIO_DESCUENTO() As String
        Get
            Return Me._FOLIO_DESCUENTO
        End Get
        Set(ByVal value As String)
            Me._FOLIO_DESCUENTO = value
        End Set
    End Property

    Public Property CODIGO_PLAZA() As Integer
        Get
            Return Me._CODIGO_PLAZA
        End Get
        Set(ByVal value As Integer)
            Me._CODIGO_PLAZA = value
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

    Public Property CODIGO_CLIENTE() As String
        Get
            Return Me._CODIGO_CLIENTE
        End Get
        Set(ByVal value As String)
            Me._CODIGO_CLIENTE = value
        End Set
    End Property

    Public ReadOnly Property NOMBRE_CLIENTE() As String
        Get
            Return Me._NOMBRE_CLIENTE
        End Get
    End Property

    Public Property FECHA() As Date
        Get
            Return Me._FECHA
        End Get
        Set(ByVal value As Date)
            Me._FECHA = value
        End Set
    End Property

    Public ReadOnly Property FECHA_SERVIDOR() As Date
        Get
            Return Me._FECHA_SERVIDOR
        End Get
    End Property

    Public Property ESTATUS_DESCUENTO() As String
        Get
            Return Me._ESTATUS_DESCUENTO
        End Get
        Set(ByVal value As String)
            Me._ESTATUS_DESCUENTO = value
        End Set
    End Property

    Public Property CONCEPTO1() As String
        Get
            Return Me._CONCEPTO1
        End Get
        Set(ByVal value As String)
            Me._CONCEPTO1 = value
        End Set
    End Property

    Public Property CONCEPTO2() As String
        Get
            Return Me._CONCEPTO2
        End Get
        Set(ByVal value As String)
            Me._CONCEPTO2 = value
        End Set
    End Property

    Public Property FOLIO_POLIZA() As String
        Get
            Return Me._FOLIO_POLIZA
        End Get
        Set(ByVal value As String)
            Me._FOLIO_POLIZA = value
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

    Public ReadOnly Property NOMBRE_USUARIO_GRABO() As String
        Get
            Return Me._NOMBRE_USUARIO_GRABO
        End Get
    End Property

    Public Property CODIGO_USUARIO_CANCELO() As Integer
        Get
            Return Me._CODIGO_USUARIO_CANCELO
        End Get
        Set(ByVal value As Integer)
            Me._CODIGO_USUARIO_CANCELO = value
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
        Set(ByVal value As Date)
            Me._FECHA_CANCELACION = value
        End Set
    End Property

    Public ReadOnly Property FECHA_CANCELACION_SERVIDOR() As Date
        Get
            Return Me._FECHA_CANCELACION_SERVIDOR
        End Get
    End Property

    Public Property TIPO_DE_CAMBIO() As Double
        Get
            Return Me._TIPO_DE_CAMBIO
        End Get
        Set(ByVal value As Double)
            Me._TIPO_DE_CAMBIO = value
        End Set
    End Property

    Public Property SUBTOTAL() As Double
        Get
            Return Me._SUBTOTAL
        End Get
        Set(ByVal value As Double)
            Me._SUBTOTAL = value
        End Set
    End Property

    Public Property IVA() As Double
        Get
            Return Me._IVA
        End Get
        Set(ByVal value As Double)
            Me._IVA = value
        End Set
    End Property

    Public Property IMPUESTO_PORCENTAJE() As Double
        Get
            Return Me._IMPUESTO_PORCENTAJE
        End Get
        Set(ByVal value As Double)
            Me._IMPUESTO_PORCENTAJE = value
        End Set
    End Property

    Public Property RETENCION() As Double
        Get
            Return Me._RETENCION
        End Get
        Set(ByVal value As Double)
            Me._RETENCION = value
        End Set
    End Property

    Public Property IEPS_DESGLOSADO() As Double
        Get
            Return Me._IEPS_DESGLOSADO
        End Get
        Set(ByVal value As Double)
            Me._IEPS_DESGLOSADO = value
        End Set
    End Property

    Public Property IEPS_INCLUIDO() As Double
        Get
            Return Me._IEPS_INCLUIDO
        End Get
        Set(ByVal value As Double)
            Me._IEPS_INCLUIDO = value
        End Set
    End Property

    Public Property TOTAL() As Double
        Get
            Return Me._TOTAL
        End Get
        Set(ByVal value As Double)
            Me._TOTAL = value
        End Set
    End Property

    Public WriteOnly Property ES_COMPROBANTE_ELECTRONICO() As String
        Set(ByVal value As String)
            Me._ES_COMPROBANTE_ELECTRONICO = value
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

    'Public WriteOnly Property IDCATALOGO_FOLIO_FELECTRONICA() As Integer
    '    Set(ByVal value As Integer)
    '        Me._IDCATALOGO_FOLIO_FELECTRONICA = value
    '    End Set
    'End Property

    Public Property ID_SIS_CFD_CATALOGO_CERTIFICADOS() As Integer
        Get
            Return Me._ID_SIS_CFD_CATALOGO_CERTIFICADOS
        End Get
        Set(ByVal value As Integer)
            Me._ID_SIS_CFD_CATALOGO_CERTIFICADOS = value
        End Set
    End Property

    Public Property CADENA_ORIGINAL() As String
        Get
            Return Me._CADENA_ORIGINAL
        End Get
        Set(ByVal value As String)
            Me._CADENA_ORIGINAL = value
        End Set
    End Property

    Public Property ES_VENTA_PUBLICO_GENERAL() As String
        Get
            Return Me._ES_VENTA_PUBLICO_GENERAL
        End Get
        Set(ByVal value As String)
            Me._ES_VENTA_PUBLICO_GENERAL = value
        End Set
    End Property

    Public Property ES_POR_DEVOLUCION() As String
        Get
            Return Me._ES_POR_DEVOLUCION
        End Get
        Set(ByVal value As String)
            Me._ES_POR_DEVOLUCION = value
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

    Public Property CODIGO_REGIMEN_FISCAL() As String
        Get
            Return Me._CODIGO_REGIMEN_FISCAL
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_REGIMEN_FISCAL = Value
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

    Public ReadOnly Property FOLIO_FISCAL_CANCELACION_SAT() As String
        Get
            Return Me._FOLIO_FISCAL_CANCELACION_SAT
        End Get
    End Property

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

    Public Property RETENCION_IVA() As Double
        Get
            Return Me._RETENCION_IVA
        End Get
        Set(ByVal Value As Double)
            Me._RETENCION_IVA = Value
        End Set
    End Property

    Public Property RETENCION_IVA_PORCENTAJE() As Double
        Get
            Return Me._RETENCION_IVA_PORCENTAJE
        End Get
        Set(ByVal Value As Double)
            Me._RETENCION_IVA_PORCENTAJE = Value
        End Set
    End Property

    Public Property DIFERENCIA_CAMBIARIA() As Decimal
        Get
            Return Me._DIFERENCIA_CAMBIARIA
        End Get
        Set(ByVal Value As Decimal)
            Me._DIFERENCIA_CAMBIARIA = Value
        End Set
    End Property

    Public Property SUBTOTAL_USD() As Decimal
        Get
            Return Me._SUBTOTAL_USD
        End Get
        Set(ByVal Value As Decimal)
            Me._SUBTOTAL_USD = Value
        End Set
    End Property

    Public Property IVA_USD() As Decimal
        Get
            Return Me._IVA_USD
        End Get
        Set(ByVal Value As Decimal)
            Me._IVA_USD = Value
        End Set
    End Property

    Public Property TOTAL_USD() As Decimal
        Get
            Return Me._TOTAL_USD
        End Get
        Set(ByVal Value As Decimal)
            Me._TOTAL_USD = Value
        End Set
    End Property

    Public Property SUBTOTAL_MXN_ANTICIPO() As Decimal
        Get
            Return Me._SUBTOTAL_MXN_ANTICIPO
        End Get
        Set(ByVal Value As Decimal)
            Me._SUBTOTAL_MXN_ANTICIPO = Value
        End Set
    End Property

#End Region

#Region "Propiedad Nombre de Clase"
    Public ReadOnly Property Nombre_Clase() As String
        Get
            Return "Class_CXC_Descuentos"
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

    Public ReadOnly Property NOMBRE_METODO_PAGO() As String
        Get
            Return Me._NOMBRE_METODO_PAGO
        End Get
    End Property

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

    Public Property LISTA_DESCUENTOS() As String
        Get
            Return Me._LISTA_DESCUENTOS
        End Get
        Set(value As String)
            Me._LISTA_DESCUENTOS = value
        End Set
    End Property
#End Region

#End Region

#Region "Constructor y destructor"
    Public Sub New()
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._oDocumento = New Class_CatDocumentos()
    End Sub

    Public Sub New(ByVal folioDescuento As String)
        Me.New()
        Me._FOLIO_DESCUENTO = folioDescuento

        Try
            If Me.Consultar = True Then
                Me._Existe = True
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "New", ex)
        End Try
    End Sub

    Protected Overrides Sub Finalize()
        Me._Conexion.Dispose()
        MyBase.Finalize()
    End Sub
#End Region

#Region "Métodos y procedimientos"

    Public Function Grabar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = _Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CXC_DESCUENTOS_GRABA_GLOBAL"

            sqlParametro = .Parameters.Add("@FOLIO_DESCUENTO", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_DESCUENTO : sqlParametro.Direction = ParameterDirection.InputOutput
            sqlParametro = .Parameters.Add("@CODIGO_PLAZA", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_PLAZA
            sqlParametro = .Parameters.Add("@CODIGO_DOCUMENTO", SqlDbType.NVarChar, 10) : sqlParametro.Value = Me._CODIGO_DOCUMENTO
            sqlParametro = .Parameters.Add("@CODIGO_CLIENTE", SqlDbType.NVarChar, 8) : sqlParametro.Value = Me._CODIGO_CLIENTE
            sqlParametro = .Parameters.Add("@SUBTOTAL", SqlDbType.Decimal) : sqlParametro.Value = Me._SUBTOTAL
            sqlParametro = .Parameters.Add("@IEPS_DESGLOSADO", SqlDbType.Decimal) : sqlParametro.Value = Me._IEPS_DESGLOSADO
            sqlParametro = .Parameters.Add("@IEPS_INCLUIDO", SqlDbType.Decimal) : sqlParametro.Value = Me._IEPS_INCLUIDO
            sqlParametro = .Parameters.Add("@IVA", SqlDbType.Decimal) : sqlParametro.Value = Me._IVA
            sqlParametro = .Parameters.Add("@TOTAL", SqlDbType.Decimal) : sqlParametro.Value = Me._TOTAL
            sqlParametro = .Parameters.Add("@FECHA", SqlDbType.DateTime) : sqlParametro.Value = Me._FECHA
            sqlParametro = .Parameters.Add("@CONCEPTO", SqlDbType.NVarChar, 200) : sqlParametro.Value = Me._CONCEPTO1
            sqlParametro = .Parameters.Add("@CONCEPTO2", SqlDbType.NVarChar, 200) : sqlParametro.Value = Me._CONCEPTO2
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO_GRABO", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Usuario
            sqlParametro = .Parameters.Add("@TIPO_DE_CAMBIO", SqlDbType.Decimal) : sqlParametro.Value = Me._TIPO_DE_CAMBIO
            sqlParametro = .Parameters.Add("@ES_POR_DEVOLUCION", SqlDbType.Char, 1) : sqlParametro.Value = Me._ES_POR_DEVOLUCION
            sqlParametro = .Parameters.Add("@ES_COMPROBANTE_ELECTRONICO", SqlDbType.Char, 1) : sqlParametro.Value = Me._ES_COMPROBANTE_ELECTRONICO
            sqlParametro = .Parameters.Add("@ES_VENTA_PUBLICO_GENERAL", SqlDbType.Char, 1) : sqlParametro.Value = Me._ES_VENTA_PUBLICO_GENERAL
            sqlParametro = .Parameters.Add("@LISTA_DESCUENTOS", SqlDbType.NVarChar, -1) : sqlParametro.Value = Me._LISTA_DESCUENTOS
            sqlParametro = .Parameters.Add("@CODIGO_METODO_PAGO", SqlDbType.NVarChar, 2) : sqlParametro.Value = Me._CODIGO_METODO_PAGO
            sqlParametro = .Parameters.Add("@CODIGO_METODO_PAGO_EVENTO", SqlDbType.NVarChar, 3) : sqlParametro.Value = Me._CODIGO_METODO_PAGO_EVENTO
            sqlParametro = .Parameters.Add("@CODIGO_USO_CFDI", SqlDbType.NVarChar, 4) : sqlParametro.Value = Me._CODIGO_USO_CFDI
            sqlParametro = .Parameters.Add("@CODIGO_MONEDA_SAT", SqlDbType.NVarChar, 3) : sqlParametro.Value = Me._CODIGO_MONEDA_SAT
            sqlParametro = .Parameters.Add("@IMPUESTO_PORCENTAJE", SqlDbType.Decimal) : sqlParametro.Value = Me._IMPUESTO_PORCENTAJE
            sqlParametro = .Parameters.Add("@CODIGO_TIPO_RELACION_CFDI", SqlDbType.NVarChar, 2) : sqlParametro.Value = Me._CODIGO_TIPO_RELACION_CFDI
            sqlParametro = .Parameters.Add("@CODIGO_REGIMEN_FISCAL", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_REGIMEN_FISCAL

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
                Me._FOLIO_DESCUENTO = "" & .Parameters("@FOLIO_DESCUENTO").Value.ToString
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "Grabar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Function InsertaDescuentoDetalle(ByVal sFolio As String) As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = _Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CXC_DESCUENTOS_GRABA_RELACION_DETALLE"

            sqlParametro = .Parameters.Add("@FOLIO_CXC", SqlDbType.NVarChar, 15) : sqlParametro.Value = sFolio
            sqlParametro = .Parameters.Add("@FOLIO_DESCUENTO", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_DESCUENTO

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "InsertaDescuentoDetalle", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Function InsertaDescuentoCultivoDetalle(ByVal sFolio As String, ByVal dImporteDescuento As Double, Optional ByVal sCodigoCultivo As String = "") As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = _Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CXC_DESCUENTOS_DETALLE_CULTIVOS_GRABA"

            sqlParametro = .Parameters.Add("@FOLIO_CXC", SqlDbType.NVarChar, 15) : sqlParametro.Value = sFolio
            sqlParametro = .Parameters.Add("@CODIGO_CULTIVO", SqlDbType.NVarChar, 4) : sqlParametro.Value = sCodigoCultivo
            sqlParametro = .Parameters.Add("@IMPORTE_DESCUENTO", SqlDbType.Decimal) : sqlParametro.Value = dImporteDescuento

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "InsertaDescuentoCultivoDetalle", ex)
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

        Dim cmd As New SqlCommand("SELECT V.* " &
                          "FROM VW_CXC_DESCUENTOS_GLOBAL_CON_CXC_GLOBAL V " &
                          "WHERE V.FOLIO_DESCUENTO='" & Me._FOLIO_DESCUENTO & "' AND V.CODIGO_PLAZA=" & Plaza.CODIGO_PLAZA, Me._Conexion)

        Dim dReader As SqlDataReader

        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read = True Then
                    Me._ID_CXC_DESCUENTOS_GLOBAL = CType(dReader("ID_CXC_DESCUENTOS_GLOBAL"), Integer)
                    Me._FOLIO_DESCUENTO = CType(dReader("FOLIO_DESCUENTO"), String)
                    Me._CODIGO_PLAZA = CType(dReader("CODIGO_PLAZA"), Integer)
                    Me._CODIGO_DOCUMENTO = CType(dReader("CODIGO_DOCUMENTO"), String)
                    Me._CODIGO_CLIENTE = CType(dReader("CODIGO_CLIENTE"), String)
                    Me._NOMBRE_CLIENTE = CType(dReader("NOMBRE_CLIENTE"), String)
                    Me._FOLIO_POLIZA = "" & dReader("FOLIO_POLIZA").ToString
                    Me._FECHA = CType(dReader("FECHA"), Date)
                    Me._FECHA_SERVIDOR = CType(dReader("FECHA_SERVIDOR"), Date)
                    Me._ESTATUS_DESCUENTO = CType(dReader("ESTATUS_DESCUENTO"), String)
                    Me._CONCEPTO1 = CType(dReader("CONCEPTO"), String)
                    Me._CONCEPTO2 = CType(dReader("CONCEPTO2"), String)
                    Me._CODIGO_USUARIO_GRABO = CType(dReader("CODIGO_USUARIO_GRABO"), Integer)
                    Me._NOMBRE_USUARIO_GRABO = CType(dReader("NOMBRE_USUARIO_GRABO"), String)
                    Me._TIPO_DE_CAMBIO = CType(dReader("TIPO_DE_CAMBIO"), Double)
                    Me._SUBTOTAL = CType(dReader("SUBTOTAL"), Double)
                    Me._IEPS_DESGLOSADO = CType(dReader("IEPS_DESGLOSADO"), Double)
                    Me._IEPS_INCLUIDO = CType(dReader("IEPS_INCLUIDO"), Double)
                    Me._IVA = CType(dReader("IVA"), Double)
                    Me._TOTAL = CType(dReader("TOTAL"), Double)
                    Me._IMPUESTO_PORCENTAJE = CType(dReader("IMPUESTO_PORCENTAJE"), Double)
                    Me._RETENCION = CType(dReader("RETENCION"), Double)
                    Me._ES_COMPROBANTE_ELECTRONICO = CType(dReader("ES_COMPROBANTE_ELECTRONICO"), String)
                    Me._FOLIO_NUMERICO = CType(dReader("FOLIO_NUMERICO"), Integer)
                    Me._SERIE = "" & Trim(dReader("SERIE").ToString)
                    'Me._IDCATALOGO_FOLIO_FELECTRONICA = CType(dReader("IDCATALOGO_FOLIO_FELECTRONICA"), Integer)
                    'Me._ID_SIS_CFD_CATALOGO_CERTIFICADOS = CType(dReader("ID_SIS_CFD_CATALOGO_CERTIFICADOS"), Integer)
                    'Me._CADENA_ORIGINAL = CType(dReader("CADENA_ORIGINAL"), String)
                    'Me._SELLO_DIGITAL = CType(dReader("SELLO_DIGITAL"), String)
                    Me._ES_VENTA_PUBLICO_GENERAL = "" & dReader("ES_VENTA_PUBLICO_GENERAL").ToString
                    Me._ES_POR_DEVOLUCION = CType(dReader("ES_POR_DEVOLUCION"), String)
                    If Me._ESTATUS_DESCUENTO = "C" Then
                        Me._CODIGO_USUARIO_CANCELO = CType(dReader("CODIGO_USUARIO_CANCELO"), Integer)
                        Me._NOMBRE_USUARIO_CANCELO = CType(dReader("NOMBRE_USUARIO_CANCELO"), String)
                        Me._FECHA_CANCELACION = CType(dReader("FECHA_CANCELACION"), Date)
                        Me._FECHA_CANCELACION_SERVIDOR = CType(dReader("FECHA_CANCELACION_SERVIDOR"), Date)
                    End If
                    Me._CODIGO_METODO_PAGO = dReader("CODIGO_METODO_PAGO").ToString
                    Me._CODIGO_REGIMEN_FISCAL = "" & dReader("CODIGO_REGIMEN_FISCAL").ToString
                    Me._NOMBRE_METODO_PAGO = "" & dReader("NOMBRE_METODO_PAGO").ToString
                    Me._NOMBRE_REGIMEN_FISCAL = "" & dReader("NOMBRE_REGIMEN_FISCAL").ToString
                    Me._FELECTRONICA_CER = "" & dReader("FELECTRONICA_CER").ToString
                    Me._FELECTRONICA_KEY = "" & dReader("FELECTRONICA_KEY").ToString
                    Me._FELECTRONICA_CONTRASENIA_CLAVE_PRIVADA = IIf(txtLEN("" & dReader("CONTRASEÑA").ToString) = True, Decrypt("" & dReader("CONTRASEÑA").ToString, "r7"), "").ToString
                    Me._FOLIO_FISCAL_SAT = "" & dReader("FOLIO_FISCAL_SAT").ToString
                    Me._FECHA_TIMBRADO_SAT = "" & dReader("FECHA_TIMBRADO_SAT").ToString
                    Me._NUMERO_SERIE_CERTIFICADO_SAT = "" & dReader("NUMERO_SERIE_CERTIFICADO_SAT").ToString
                    Me._SELLO_SAT = IIf(txtLEN("" & dReader("SELLO_SAT").ToString) = True, "" & dReader("SELLO_SAT").ToString, "").ToString
                    If txtLEN("" & dReader("CBB_IMAGE").ToString) = True Then
                        Me._CBB_IMAGE = "" & dReader("CBB_IMAGE").ToString
                    Else
                        Me._CBB_IMAGE = "" '& dReader("CBB_IMAGE").ToString
                    End If
                    Me._TIMBRADO_CFDI = dReader("TIMBRADO_CFDI").ToString
                    Me._ESTATUS_CANCELACION_CFDI = dReader("ESTATUS_CANCELACION_CFDI").ToString
                    Me._TIMBRADO_DESCARTADO = dReader("TIMBRADO_DESCARTADO").ToString
                    Me._VERSION_ESQUEMA_XML = "" & dReader("VERSION_ESQUEMA_XML").ToString
                    Me._Nombre_Formato = "" & Trim(dReader("NOMBRE_FORMATO").ToString)
                    Me._CODIGO_METODO_PAGO_EVENTO = "" & dReader("CODIGO_METODO_PAGO_EVENTO").ToString
                    Me._CODIGO_USO_CFDI = "" & dReader("CODIGO_USO_CFDI").ToString
                    Me._CODIGO_MONEDA_SAT = "" & dReader("CODIGO_MONEDA_SAT").ToString
                    Me._CODIGO_TIPO_RELACION_CFDI = "" & dReader("CODIGO_TIPO_RELACION_CFDI").ToString
                    Me._RETENCION_IVA = CType(dReader("RETENCION_IVA"), Double)
                    Me._RETENCION_IVA_PORCENTAJE = CType(dReader("RETENCION_IVA_PORCENTAJE"), Double)
                    Me._DIFERENCIA_CAMBIARIA = CType(dReader("DIFERENCIA_CAMBIARIA"), Decimal)
                    'Nota estos 3 campos siguientes en usd sólo estan grabados si es un descuento por anticipo en usd
                    'Si fuera un descuento normal en usd están en 0 y se calculan manualmente a la hora de timbrar o imprimir formatos.
                    Me._SUBTOTAL_USD = CType(dReader("SUBTOTAL_USD"), Decimal)
                    Me._IVA_USD = CType(dReader("IVA_USD"), Decimal)
                    Me._TOTAL_USD = CType(dReader("TOTAL_USD"), Decimal)
                    Me._SUBTOTAL_MXN_ANTICIPO = CType(dReader("SUBTOTAL_MXN_ANTICIPO"), Decimal)

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

    Public Function ObtenerDetalle() As DataTable
        Dim dTabla As New DataTable("detalle"), da As SqlDataAdapter
        Dim sSQL As String
        '"INNER JOIN CAT_ARTICULOS P ON(R.CODIGO_ARTICULO=P.CODIGO_ARTICULO AND C.CODIGO_CULTIVO=P.CODIGO_CULTIVO) " & _
        '        "LEFT JOIN CAT_CULTIVOS PC ON(P.CODIGO_CULTIVO=PC.CODIGO_CULTIVO) " & _

        'sSQL = "SELECT MAX( V.FOLIO_VENTA),MAX(V.FECHA),MAX(V.SALDO),P.CODIGO_CULTIVO,P.NOMBRE_CULTIVO, " &
        '"(SELECT SUM(VD.IMPORTE) IMPORTE FROM VENTA_GLOBAL VG INNER JOIN VENTA_DETALLE VD ON(VG.FOLIO_VENTA=VD.FOLIO_VENTA) " &
        '"LEFT JOIN CAT_ARTICULOS PA ON(VD.CODIGO_ARTICULO=PA.CODIGO_ARTICULO) " &
        '"WHERE(VG.FOLIO_VENTA = G.FOLIO_REFERENCIA And PA.CODIGO_CULTIVO = P.CODIGO_CULTIVO) GROUP BY PA.CODIGO_CULTIVO) IMPORTE, " &
        '"(SELECT ISNULL(MAX(IMPORTE_DESCUENTO) ,0) FROM CXC_DESCUENTOS_DETALLE_CULTIVOS WHERE CODIGO_CULTIVO=ISNULL(P.CODIGO_CULTIVO,'00') AND FOLIO_CXC=D.FOLIO_CXC) DESCUENTO,'','','' " &
        '"FROM  CXC_DESCUENTOS_GLOBAL DG " &
        '"INNER JOIN CXC_DESCUENTOS_DETALLE D ON(DG.FOLIO_DESCUENTO=D.FOLIO_DESCUENTO) " &
        '"INNER JOIN CXC_DESCUENTOS_DETALLE_CULTIVOS C ON(D.FOLIO_CXC=C.FOLIO_CXC) " &
        '"INNER JOIN CXC_GLOBAL G ON(C.FOLIO_CXC=G.FOLIO_CXC) " &
        '"INNER JOIN VENTA_GLOBAL V  ON(G.FOLIO_REFERENCIA=V.FOLIO_VENTA ) " &
        '"INNER JOIN VENTA_DETALLE R ON(V.FOLIO_VENTA=R.FOLIO_VENTA) " &
        '"LEFT JOIN VW_CAT_PRODUCTOS_AGRICOLAS P ON(R.CODIGO_ARTICULO=P.CODIGO_ARTICULO) " &
        '"WHERE DG.FOLIO_DESCUENTO='" & Me._FOLIO_DESCUENTO & "'  " &
        '"GROUP BY P.CODIGO_CULTIVO,P.NOMBRE_CULTIVO,D.FOLIO_CXC,G.FOLIO_REFERENCIA " &
        '"ORDER BY D.FOLIO_CXC "

        sSQL = "SELECT P.FOLIO_VENTA,VG.FECHA,VG.TIPO_DE_CAMBIO,VG.TOTAL,VG.SALDO,P.TOTAL DESCUENTO " &
        "FROM CXC_DESCUENTOS_GLOBAL G " &
        "INNER JOIN CXC_DESCUENTOS_DETALLE_PREVIO P ON(g.FOLIO_DESCUENTO=P.FOLIO_DESCUENTO) " &
        "INNER JOIN VENTA_GLOBAL VG ON(P.FOLIO_VENTA=VG.FOLIO_VENTA) " &
        "WHERE G.FOLIO_DESCUENTO='" & Me._FOLIO_DESCUENTO & "' " &
        "ORDER BY P.ID"

        Try
            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dTabla)

            da.Dispose()
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "ObtenerDetalle", ex)
        End Try

        Return dTabla
    End Function

    Public Function CancelaDescuentoCXC() As Boolean
        Dim bResultado As Boolean = False
        Dim Conexion As New SqlConnection(Empresa_Sistema.conexion), Error1 As String = ""

        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter

        With cmd
            .Connection = Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CXC_DESCUENTOS_CANCELA"

            sqlParametro = .Parameters.Add("@FOLIO_DESCUENTO", SqlDbType.NVarChar, 15) : sqlParametro.Value = "" & Me._FOLIO_DESCUENTO
            sqlParametro = .Parameters.Add("@CODIGO_PLAZA", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Plaza
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO_CANCELO", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Usuario
            sqlParametro = .Parameters.Add("@FECHA_CANCELACION", SqlDbType.DateTime) : sqlParametro.Value = Me._FECHA_CANCELACION
            sqlParametro = .Parameters.Add("@CANCELADO_DESDE_INTERFAZ_DESCUENTOS", SqlDbType.Char) : sqlParametro.Value = "1"

            Try
                Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "CancelaDescuentoCXC", ex)
            Finally
                Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Function AplicaDocumentoCXC() As Boolean
        'Dim cmd As New SqlCommand
        'Dim sqlParametro As SqlParameter
        'With cmd
        '    .Connection = _Conexion
        '    .CommandTimeout = 0
        '    .CommandType = CommandType.StoredProcedure
        '    .CommandText = "MP_CXC_APLICA_DOCUMENTO"

        '    sqlParametro = .Parameters.Add("@FOLIO_DESCUENTO", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_DESCUENTO
        '    sqlParametro = .Parameters.Add("@FOLIO_REFERENCIA", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_REFERENCIA
        '    sqlParametro = .Parameters.Add("@CODIGO_PLAZA", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_PLAZA
        '    sqlParametro = .Parameters.Add("@CODIGO_USUARIO", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Usuario

        '    Try
        '        Me._Conexion.Open()
        '        .ExecuteNonQuery()
        '        AplicaDocumentoCXC = True
        '    Catch ex As Exception
        '        HandleError(Me.Nombre_Clase, "AplicaDocumentoCXC", ex)
        '    Finally
        '        Me._Conexion.Close()
        '        cmd.Dispose()
        '        sqlParametro = Nothing
        '    End Try

        'End With
    End Function

    Public Function ActualizaFolioPoliza() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_DESCUENTO_CXC_ACTUALIZA_FOLIO_POLIZA"

            sqlParametro = .Parameters.Add("@FOLIO_DESCUENTO", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_DESCUENTO

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                Me._FOLIO_POLIZA = Me._FOLIO_DESCUENTO
                bResultado = True
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "ActualizaFolioPoliza", ex)
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
            Me._oDocumento.CODIGO_DOCUMENTO = "NCG_CXC" & Usuario.Codigo_Plaza
            Me._oDocumento.GeneraFolio()
            sResultado = Me._oDocumento.FOLIO
            Me._FOLIO_DESCUENTO = _oDocumento.FOLIO
            Me._FOLIO_NUMERICO = CInt(_oDocumento.FOLIO_NUMERICO)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "New", ex)
        End Try
        Return sResultado
    End Function

    Public Function DistribucionDescuentos(ByVal sFolioCxc As String, ByVal dImporteDescuento As Double) As System.Data.DataTable
        Dim dt As New DataTable
        Try
            Dim da As New SqlDataAdapter("MP_CXC_DESCUENTOS_PROMEDIA_DESCUENTO", Me._Conexion)
            da.SelectCommand.CommandType = CommandType.StoredProcedure

            With da.SelectCommand
                .Parameters.Add("@FOLIO_VENTA", SqlDbType.NVarChar, 15) : .Parameters("@FOLIO_VENTA").Value = sFolioCxc
                .Parameters.Add("@IMPORTE_DESCUENTO", SqlDbType.Decimal) : .Parameters("@IMPORTE_DESCUENTO").Value = dImporteDescuento
            End With

            da.Fill(dt)
            dt.Columns.Remove("ID")
            dt.Columns.Remove("SALDO")
            dt.Columns.Remove("IMPORTE")
            dt.Columns.Remove("SUBIMPORTE")

        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "DistribucionDescuentos", ex)
        End Try

        Return dt
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

    Public Function RecuperaXML(ByVal sRutaXML As String) As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        Dim docXml As Xml.XmlDocument = New Xml.XmlDocument

        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CXC_DESCUENTOS_CFD_RECUPERA_CADENA_XM"

            sqlParametro = .Parameters.Add("@FOLIO_DESCUENTO", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_DESCUENTO
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
        Dim docXml As Xml.XmlDocument = New Xml.XmlDocument

        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CXC_DESCUENTOS_CFD_RECUPERA_CADENA_XM"

            sqlParametro = .Parameters.Add("@FOLIO_DESCUENTO", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_DESCUENTO
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

                sResultado = docXml.InnerXml

            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "RecuperaXML", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With

        Return sResultado
    End Function

    Public Sub Imprimir()
        Dim Rpt As New ReportDocument
        Dim oReporte As Class_Reporte

        Try
            If Me._VERSION_ESQUEMA_XML >= "3.2" Or txtLEN(Me._VERSION_ESQUEMA_XML) = False Then 'Se pregunta por vacio por si no se ha cargado la versión en el objecto.
                oReporte = New Class_Reporte(Me._Nombre_Formato, Rpt, False)
            Else
                oReporte = New Class_Reporte(Me._Nombre_Formato & "_CFD", Rpt, False)
            End If

            If Not oReporte.RptCargado Then
                Exit Sub
            End If

            Rpt.SetParameterValue("@FOLIO_DESCUENTO", Me._FOLIO_DESCUENTO)

            Dim frm As New Reporte(Rpt)
            frm.CRViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            frm.Show()

        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "Imprimir", ex)
        Finally
            oReporte = Nothing
        End Try
    End Sub

    Public Function ExportarAPdf(Optional ByVal sRutaPDF As String = "") As Boolean
        Dim bResultado As Boolean = False
        Dim Rpt As New ReportDocument
        Dim oReporte As Class_Reporte

        Try
            If txtLEN(sRutaPDF) = False Then 'Si no trae un nombre en especifico lo crea con el nombre del folio
                sRutaPDF = sFelectronicaCarpetaXMLPDF & "\" & Me._FOLIO_DESCUENTO.ToString & ".PDF"
            End If

            If Me.VERSION_ESQUEMA_XML >= "3.2" Or txtLEN(Me._VERSION_ESQUEMA_XML) = False Then 'Se pregunta por vacio por si no se ha cargado la versión en el objecto.
                oReporte = New Class_Reporte(Me._Nombre_Formato, Rpt, False)
            Else
                oReporte = New Class_Reporte(Me._Nombre_Formato & "_CFD", Rpt, False)
            End If

            Rpt.SetParameterValue("@FOLIO_DESCUENTO", Me._FOLIO_DESCUENTO)

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

    Public Function ObtenerEstatusParaReportes() As DataTable
        Dim dTable As New DataTable
        'Dim dRow As DataRow
        Try
            dTable.Columns.Add("CODIGO_ESTATUS", GetType(String))
            dTable.Columns.Add("NOMBRE_ESTATUS", GetType(String))

            'dRow = dTable.NewRow
            dTable.Rows.Add("A", "APLICADOS")
            dTable.Rows.Add("C", "CANCELADOS")
            dTable.Rows.Add("T", "TODOS")
            dTable.AcceptChanges()
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerEstatusParaReportes", ex)
        End Try
        Return dTable
    End Function

    Public Function ObtieneVentasConSaldo(ByVal CodigoCliente As String, ByVal Moneda As String, ByVal VentaPublicoGeneral As Boolean, ByVal CodigoTipoDocumento As String) As DataTable
        Dim dt As New DataTable, sSQLDocs As String = ""
        Try
            Select Case CodigoTipoDocumento
                Case "NCG_CXC"
                    sSQLDocs = "AND V.CODIGO_DOCUMENTO LIKE 'F%'"
                Case "NRG_CXC"
                    sSQLDocs = "AND V.CODIGO_DOCUMENTO LIKE 'R%'"
            End Select

            Using da As New SqlDataAdapter("SELECT V.FOLIO_VENTA,V.FECHA,V.TIPO_DE_CAMBIO,V.TOTAL,V.SALDO " &
                                           "FROM VENTA_GLOBAL V " &
                                           "INNER JOIN VW_SIS_CAT_DOCUMENTOS_EXTENDIDO D ON (V.CODIGO_DOCUMENTO=D.CODIGO_DOCUMENTO)  " &
                                           "WHERE V.CODIGO_CLIENTE=@CODIGO_CLIENTE AND SALDO>0 AND V.CODIGO_PLAZA=" & Usuario.Codigo_Plaza.ToString & " " &
                                           "AND V.CODIGO_MONEDA_SAT=@CODIGO_MONEDA_SAT " &
                                           "AND V.ES_VENTA_PUBLICO_GENERAL=" & IIf(VentaPublicoGeneral = True, "1", "0").ToString & " " &
                                           sSQLDocs &
                                           "ORDER BY V.FECHA", Me._Conexion)
                '                           IIf(Moneda = "MXN", "V.TIPO_DE_CAMBIO<=1", "V.TIPO_DE_CAMBIO>1").ToString & " " &
                da.SelectCommand.CommandType = CommandType.Text

                With da.SelectCommand
                    .Parameters.Add("@CODIGO_CLIENTE", SqlDbType.NVarChar, 8).Value = CodigoCliente
                    .Parameters.Add("@CODIGO_MONEDA_SAT", SqlDbType.NVarChar, 3).Value = Moneda
                End With

                da.Fill(dt)
            End Using

        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtieneVentasConSaldo", ex)
        End Try
        Return dt
    End Function

    Public Function GeneraNotaCreditoElectronica(ByVal bMensajes As Boolean, ByVal bGenerarPDF As Boolean) As Boolean
        Dim bResultado As Boolean = False
        Dim sProcedure As String = "GeneraNotaCreditoElectronica"
        Dim sRutaXML As String

        Try
            sRutaXML = sFelectronicaCarpetaXMLPDF & "\" & Me._FOLIO_DESCUENTO & ".xml"

            If Me._TIMBRADO_CFDI = "0" Then
                If Empresa_Sistema.VERSION_ESQUEMA_CFD <= "3.2" Then
                    bResultado = GeneraNotaCreditoCXCElectronica(Me, bMensajes, sRutaXML)
                Else
                    bResultado = GeneraNotaCreditoCXCElectronica33(Me, bMensajes, sRutaXML)
                End If

                If bResultado = False Then
                    MsgBox("Los datos digitales del documento no fueron generados correctamente. Avíse al depto. de sistemas.", vbExclamation, sProcedure)
                Else
                    If bGenerarPDF = True Then
                        Me.ExportarAPdf()
                    End If
                End If
                'Else
                '    Me.RecuperarFacturaElectronicaLocal(bMensajes)
            Else
                MsgBox("El documento ya esta timbrado.", vbExclamation, sProcedure)
            End If
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, sProcedure, ex)
        End Try
        Return bResultado
    End Function

    Public Function RecuperarXMLyPDF() As Boolean
        Dim sProcedure As String = "RecuperarXMLyPDF"
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
                        sNombreXmlTimbrado = Empresa_Sistema.RFC & Format(Me._FOLIO_DESCUENTO, "yyyyddMM") & Me._SERIE & Me._FOLIO_NUMERICO
                End Select
            Else
                sNombreXmlTimbrado = Me._FOLIO_DESCUENTO
            End If

            sRutaXML = sFelectronicaCarpetaXmlsTimbrados & "\" & sNombreXmlTimbrado & ".xml"
            sRutaPDF = archivos.ToString & sNombreXmlTimbrado & ".PDF"

            If Me.RecuperaXML(sRutaXML) = True Then
                Process.Start(sRutaXML) 'Para abrir el xml
                If Me.ExportarAPdf(sRutaPDF) = False Then
                    MsgBox("Se logró recuperar el XML pero no se logró generar el PDF del documento : " & Me._FOLIO_DESCUENTO & ". Avíse al depto. de sistemas.", vbExclamation, sProcedure)
                    Return False
                Else
                    bResultado = True
                End If
            Else
                MsgBox("No se logró recuperar el XML y PDF del documento : " & Me._FOLIO_DESCUENTO & ". Avíse al depto. de sistemas.", vbExclamation, sProcedure)
                Return False
            End If

        Catch ex As Exception
            HandleError(Me.Nombre_Clase, sProcedure, ex)
        End Try

        Return bResultado
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
            MyMailMsg.Body = "DEVOLUCION " & Me._FOLIO_DESCUENTO

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
                        sNombreXmlTimbrado = Empresa_Sistema.RFC & Format(Me._FOLIO_DESCUENTO, "yyyyddMM") & Me._SERIE & Me._FOLIO_NUMERICO
                End Select
            Else
                sNombreXmlTimbrado = Me._FOLIO_DESCUENTO
            End If

            sRutaXML = sFelectronicaCarpetaXmlsTimbrados & "\" & sNombreXmlTimbrado & ".xml"
            sRutaPDF = archivos.ToString & sNombreXmlTimbrado & ".PDF"

            If Me.RecuperaXML(sRutaXML) = True Then
                If Me.ExportarAPdf(sRutaPDF) = False Then
                    MsgBox("No se logró generar el PDF del documento : " & Me._FOLIO_DESCUENTO & ". Avíse al depto. de sistemas.", vbExclamation, sProcedure)
                    Return False
                End If
            Else
                MsgBox("No se logró recuperar el XML del documento : " & Me._FOLIO_DESCUENTO & ". Avíse al depto. de sistemas.", vbExclamation, sProcedure)
                Return False
            End If

            Me.MarcaEnviadoxCorreo(Me._FOLIO_DESCUENTO)

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
            .CommandText = "MP_CXC_DESCUENTOS_MARCA_CORREO_ENVIADO"

            sqlParametro = .Parameters.Add("@FOLIO_DESCUENTO", SqlDbType.NVarChar, 15) : sqlParametro.Value = sFolio

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

    Public Function ObtieneFacturasRelacionadas() As DataTable
        Dim dTabla As New DataTable("detalle"), da As SqlDataAdapter
        Dim sSQL As String

        sSQL = "SELECT F.FOLIO_VENTA,F.FOLIO_FISCAL_SAT " &
                "FROM CXC_DESCUENTOS_GLOBAL DG INNER JOIN CXC_DESCUENTOS_DETALLE DR ON(DG.FOLIO_DESCUENTO=DR.FOLIO_DESCUENTO) " &
                "INNER JOIN CXC_GLOBAL C ON(DR.FOLIO_CXC=C.FOLIO_CXC) " &
                "INNER JOIN VENTA_GLOBAL F ON(C.FOLIO_REFERENCIA=F.FOLIO_VENTA) " &
                "WHERE DG.FOLIO_DESCUENTO='" & Me.FOLIO_DESCUENTO & "'" &
                "ORDER BY C.ID_CXC_GLOBAL"

        Try
            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dTabla)

            da.Dispose()
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "ObtieneFacturasRelacionadas", ex)
        End Try

        Return dTabla
    End Function

    Public Function ObtieneDetalleIEPS() As DataTable
        Dim dTabla As New DataTable("detalle"), da As SqlDataAdapter
        Dim sSQL As String

        sSQL = "SELECT IEPS_PORCENTAJE,IEPS_IMPORTE " &
                "FROM CXC_DESCUENTOS_DETALLE_IEPS " &
                "WHERE FOLIO_DESCUENTO='" & Me.FOLIO_DESCUENTO & "'" &
                "ORDER BY IEPS_PORCENTAJE"

        Try
            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dTabla)

            da.Dispose()
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "ObtieneDetalleIEPS", ex)
        End Try

        Return dTabla
    End Function

    Public Function CancelarTimbre() As Boolean
        Dim bResultado As Boolean = False
        Dim sProcedure As String = "CancelarTimbre"
        Try
            If Me.Consultar() = False Then 'Refrescamos el documento para tener los datos mas nuevos.
                Return False
            End If

            If txtLEN(Me._FOLIO_FISCAL_SAT) = False Then
                MsgBox("El documento no tiene UUID(posiblemente no este timbrado).", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            If Me._ESTATUS_DESCUENTO <> "C" Then
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

            bResultado = CancelarCFDI(Me.FOLIO_DESCUENTO, Me.SERIE, Me.FOLIO_NUMERICO, Me.FOLIO_FISCAL_SAT, Me.TIMBRADO_CFDI, TipoComprobante.NOTA_CREDITO_CXC, sCadenaXML)

        Catch ex As Exception
            HandleError(Me.Nombre_Clase, sProcedure, ex)
        End Try

        Return bResultado
    End Function
#End Region

End Class
