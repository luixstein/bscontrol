Option Strict On

Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class Class_CXC_Descuento

#Region "Campos"

#Region "Campos de la tabla"
    Private _ID_CXC_DESCUENTOS_GLOBAL As Integer
    Private _CODIGO_PLAZA As Integer
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
    Private _FOLIO_DESCUENTO As String
    Private _FECHA_CANCELACION As Date
    Private _FECHA_CANCELACION_SERVIDOR As Date
    Private _TIPO_DE_CAMBIO As Double
    Private _SUBTOTAL As Double
    Private _IVA As Double
    Private _TOTAL As Double
    Private _ES_COMPROBANTE_ELECTRONICO As String
    Private _FOLIO_NUMERICO As Integer
    Private _IDCATALOGO_FOLIO_FELECTRONICA As Integer
    Private _ID_SIS_CFD_CATALOGO_CERTIFICADOS As Integer
    Private _CADENA_ORIGINAL As String
    Private _SELLO_DIGITAL As String
    Private _ES_VENTA_PUBLICO_GENERAL As String
    Private _ES_POR_DEVOLUCION As String
    Private _IMPUESTO_PORCENTAJE As Double
    Private _RETENCION As Double
    'CFD
    Private _CODIGO_METODO_PAGO As String
    Private _CODIGO_REGIMEN_FISCAL As Integer

    'CFDi
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
    Private _SERIE As String

#End Region

#Region "Campos de control"

#End Region

#Region "Campos de sistema"
    Private _Nombre_Catalogo As String
    Private _Conexion As SqlConnection
    Private _QuerySelect As String
    Private _QueryOrder As String
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

    Public Property CODIGO_CLIENTE() As String
        Get
            Return Me._CODIGO_CLIENTE
        End Get
        Set(ByVal value As String)
            Me._CODIGO_CLIENTE = value
        End Set
    End Property
    Public Property NOMBRE_CLIENTE() As String
        Get
            Return Me._NOMBRE_CLIENTE
        End Get
        Set(ByVal value As String)
            Me._NOMBRE_CLIENTE = value
        End Set
    End Property

    Public Property FECHA() As Date
        Get
            Return Me._FECHA
        End Get
        Set(ByVal value As Date)
            Me._FECHA = value
        End Set
    End Property

    Public Property FECHA_SERVIDOR() As Date
        Get
            Return Me._FECHA_SERVIDOR
        End Get
        Set(ByVal value As Date)
            Me._FECHA_SERVIDOR = value
        End Set
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
        Set(ByVal value As Date)
            Me._FECHA_CANCELACION = value
        End Set
    End Property

    Public Property FECHA_CANCELACION_SERVIDOR() As Date
        Get
            Return Me._FECHA_CANCELACION_SERVIDOR
        End Get
        Set(ByVal value As Date)
            Me._FECHA_CANCELACION_SERVIDOR = value
        End Set
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

    Public WriteOnly Property IDCATALOGO_FOLIO_FELECTRONICA() As Integer
        Set(ByVal value As Integer)
            Me._IDCATALOGO_FOLIO_FELECTRONICA = value
        End Set
    End Property

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

    'CFD
    Public Property CODIGO_METODO_PAGO() As String
        Get
            Return Me._CODIGO_METODO_PAGO
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_METODO_PAGO = Value
        End Set
    End Property

    'CFD
    Public Property CODIGO_REGIMEN_FISCAL() As Integer
        Get
            Return Me._CODIGO_REGIMEN_FISCAL
        End Get
        Set(ByVal Value As Integer)
            Me._CODIGO_REGIMEN_FISCAL = Value
        End Set
    End Property

    'CFDi
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

    Public ReadOnly Property SERIE() As String
        Get
            Return Me._SERIE
        End Get
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
#End Region
#End Region

#Region "Constructor y destructor"
    Public Sub New()
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        ' Me.oDocumento = New Class_CatDocumentos()
    End Sub                                                         'Inicializa al objeto.

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

    Public Function InsertarDescuentos() As Boolean
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
            sqlParametro = .Parameters.Add("@CODIGO_CLIENTE", SqlDbType.NVarChar, 8) : sqlParametro.Value = Me._CODIGO_CLIENTE
            sqlParametro = .Parameters.Add("@SUBTOTAL", SqlDbType.Decimal) : sqlParametro.Value = Me._SUBTOTAL
            sqlParametro = .Parameters.Add("@IVA", SqlDbType.Decimal) : sqlParametro.Value = Me._IVA
            sqlParametro = .Parameters.Add("@TOTAL", SqlDbType.Decimal) : sqlParametro.Value = Me._TOTAL
            sqlParametro = .Parameters.Add("@FECHA", SqlDbType.DateTime) : sqlParametro.Value = Me._FECHA
            sqlParametro = .Parameters.Add("@CONCEPTO", SqlDbType.NVarChar, 80) : sqlParametro.Value = Me._CONCEPTO1
            sqlParametro = .Parameters.Add("@CONCEPTO2", SqlDbType.NVarChar, 80) : sqlParametro.Value = Me._CONCEPTO2
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO_GRABO", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Usuario
            sqlParametro = .Parameters.Add("@TIPO_DE_CAMBIO", SqlDbType.Decimal) : sqlParametro.Value = Me._TIPO_DE_CAMBIO
            sqlParametro = .Parameters.Add("@ES_POR_DEVOLUCION", SqlDbType.Char, 1) : sqlParametro.Value = Me._ES_POR_DEVOLUCION
            sqlParametro = .Parameters.Add("@ES_COMPROBANTE_ELECTRONICO", SqlDbType.Char, 1) : sqlParametro.Value = Me._ES_COMPROBANTE_ELECTRONICO
            sqlParametro = .Parameters.Add("@ES_VENTA_PUBLICO_GENERAL", SqlDbType.Char, 1) : sqlParametro.Value = Me._ES_VENTA_PUBLICO_GENERAL

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
                Me._FOLIO_DESCUENTO = "" & .Parameters("@FOLIO_DESCUENTO").Value.ToString
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "InsertarDescuentos", ex)
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

        'Dim cmd As New SqlCommand("SELECT V.* " & _
        '                          "FROM VW_CXC_DESCUENTOS_GLOBAL_CON_CXC_GLOBAL V, " & _
        '                          "SIS_CAT_DOCUMENTOS DOC " & _
        '                          "WHERE V.FOLIO_DESCUENTO='" & Me._FOLIO_DESCUENTO & "'" & _
        '                            "AND DOC.CODIGO_DOCUMENTO='NCG_CXC'+CAST(CXC.CODIGO_PLAZA AS NVARCHAR) ", Me._Conexion) 'La tabla no tiene codigo de documento por eso lo creamos

        Dim cmd As New SqlCommand("SELECT V.* " & _
                          "FROM VW_CXC_DESCUENTOS_GLOBAL_CON_CXC_GLOBAL V " & _
                          "WHERE V.FOLIO_DESCUENTO='" & Me._FOLIO_DESCUENTO & "'", Me._Conexion)


        Dim dReader As SqlDataReader

        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then

                    Me._ID_CXC_DESCUENTOS_GLOBAL = CType(dReader("ID_CXC_DESCUENTOS_GLOBAL"), Integer)
                    Me._FOLIO_DESCUENTO = CType(dReader("FOLIO_DESCUENTO"), String)
                    Me._CODIGO_PLAZA = CType(dReader("CODIGO_PLAZA"), Integer)
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
                    Me._IVA = CType(dReader("IVA"), Double)
                    Me._TOTAL = CType(dReader("TOTAL"), Double)
                    Me._IMPUESTO_PORCENTAJE = CType(dReader("IMPUESTO_PORCENTAJE"), Double)
                    Me._RETENCION = CType(dReader("RETENCION"), Double)
                    Me._ES_COMPROBANTE_ELECTRONICO = CType(dReader("ES_COMPROBANTE_ELECTRONICO"), String)
                    Me._FOLIO_NUMERICO = CType(dReader("FOLIO_NUMERICO"), Integer)
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
                        'Me._FECHA_CANCELACION_SERVIDOR = CType(dReader("FECHA_CANCELACION_SERVIDOR"), Date)
                    End If
                    Me._CODIGO_METODO_PAGO = dReader("CODIGO_METODO_PAGO").ToString
                    Me._CODIGO_REGIMEN_FISCAL = CType(dReader("CODIGO_REGIMEN_FISCAL"), Integer)
                    Me._NOMBRE_METODO_PAGO = "" & dReader("NOMBRE_METODO_PAGO").ToString
                    Me._NOMBRE_REGIMEN_FISCAL = "" & dReader("NOMBRE_REGIMEN_FISCAL").ToString
                    Me._FELECTRONICA_CER = "" & dReader("FELECTRONICA_CER").ToString
                    Me._FELECTRONICA_KEY = "" & dReader("FELECTRONICA_KEY").ToString
                    Me._FELECTRONICA_CONTRASENIA_CLAVE_PRIVADA = IIf(txtLEN("" & dReader("CONTRASEÑA").ToString) = True, Decrypt("" & dReader("CONTRASEÑA").ToString, "r7"), "").ToString
                    'CFDi
                    Me._FOLIO_FISCAL_SAT = "" & dReader("FOLIO_FISCAL_SAT").ToString
                    Me._FECHA_TIMBRADO_SAT = "" & dReader("FECHA_TIMBRADO_SAT").ToString
                    Me._NUMERO_SERIE_CERTIFICADO_SAT = "" & dReader("NUMERO_SERIE_CERTIFICADO_SAT").ToString
                    Me._SELLO_SAT = IIf(txtLEN("" & dReader("SELLO_SAT").ToString) = True, "" & dReader("SELLO_SAT").ToString, "").ToString
                    If txtLEN("" & dReader("CBB_IMAGE").ToString) = True Then
                        Me._CBB_IMAGE = "" & dReader("CBB_IMAGE").ToString
                    Else
                        Me._CBB_IMAGE = "" '& dReader("CBB_IMAGE").ToString
                    End If
                    'Me._FOLIO_FISCAL_CANCELACION_SAT = "" & dReader("FOLIO_FISCAL_CANCELACION_SAT").ToString
                    Me._TIMBRADO_CFDI = "" & dReader("TIMBRADO_CFDI").ToString
                    Me._ESTATUS_CANCELACION_CFDI = "" & dReader("ESTATUS_CANCELACION_CFDI").ToString
                    Me._TIMBRADO_DESCARTADO = "" & dReader("TIMBRADO_DESCARTADO").ToString
                    Me._VERSION_ESQUEMA_XML = "" & dReader("VERSION_ESQUEMA_XML").ToString
                    Me._SERIE = "" & Trim(dReader("SERIE").ToString)

                    Me._Nombre_Formato = "" & Trim(dReader("NOMBRE_FORMATO").ToString)

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

        sSQL = "SELECT MAX( V.FOLIO_VENTA),MAX(V.FECHA),MAX(V.SALDO),P.CODIGO_CULTIVO,P.NOMBRE_CULTIVO, " & _
        "(SELECT SUM(VD.IMPORTE) IMPORTE FROM VENTA_GLOBAL VG INNER JOIN VENTA_DETALLE VD ON(VG.FOLIO_VENTA=VD.FOLIO_VENTA) " & _
        "LEFT JOIN CAT_ARTICULOS PA ON(VD.CODIGO_ARTICULO=PA.CODIGO_ARTICULO) " & _
        "WHERE(VG.FOLIO_VENTA = G.FOLIO_REFERENCIA And PA.CODIGO_CULTIVO = P.CODIGO_CULTIVO) GROUP BY PA.CODIGO_CULTIVO) IMPORTE, " & _
        "(SELECT ISNULL(MAX(IMPORTE_DESCUENTO) ,0) FROM CXC_DESCUENTOS_DETALLE_CULTIVOS WHERE CODIGO_CULTIVO=ISNULL(P.CODIGO_CULTIVO,'00') AND FOLIO_CXC=D.FOLIO_CXC) DESCUENTO,'','','' " & _
        "FROM  CXC_DESCUENTOS_GLOBAL DG " & _
        "INNER JOIN CXC_DESCUENTOS_DETALLE D ON(DG.FOLIO_DESCUENTO=D.FOLIO_DESCUENTO) " & _
        "INNER JOIN CXC_DESCUENTOS_DETALLE_CULTIVOS C ON(D.FOLIO_CXC=C.FOLIO_CXC) " & _
        "INNER JOIN CXC_GLOBAL G ON(C.FOLIO_CXC=G.FOLIO_CXC) " & _
        "INNER JOIN VENTA_GLOBAL V  ON(G.FOLIO_REFERENCIA=V.FOLIO_VENTA ) " & _
        "INNER JOIN VENTA_DETALLE R ON(V.FOLIO_VENTA=R.FOLIO_VENTA) " & _
        "LEFT JOIN VW_CAT_PRODUCTOS_AGRICOLAS P ON(R.CODIGO_ARTICULO=P.CODIGO_ARTICULO) " & _
        "WHERE DG.FOLIO_DESCUENTO='" & Me._FOLIO_DESCUENTO & "'  " & _
        "GROUP BY P.CODIGO_CULTIVO,P.NOMBRE_CULTIVO,D.FOLIO_CXC,G.FOLIO_REFERENCIA " & _
        "ORDER BY D.FOLIO_CXC "

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
        Finally

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

#End Region

End Class
