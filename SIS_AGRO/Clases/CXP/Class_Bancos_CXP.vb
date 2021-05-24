Option Strict On
Imports System.Data
Imports System.Data.SqlClient

Public Class Class_Bancos_CXP

#Region "Campos"
#Region "Campos de la tabla"
    Private _FOLIO_CXP As String
    Private _CODIGO_PROVEEDOR As String
    Private _NOMBRE_PROVEEDOR As String
    Private _CUENTA_CONTABLE_PESOS As String
    Private _CUENTA_CONTABLE_DOLARES As String

    Private _ID_TIPO_PAGO As Integer
    Private _REFERENCIA_DOCUMENTO As String
    Private _CODIGO_DOCUMENTO As String
    Private _REFERENCIA_PAGO As String
    Private _CONCEPTO1 As String
    Private _CONCEPTO2 As String
    Private _SALDO As Double
    Private _FOLIO_REFERENCIA As String
    Private _ESTATUS_CXP As String
    Private _CODIGO_PLAZA As Integer
    Private _SUBTOTAL As Double
    Private _IMPUESTO As Double
    Private _TOTAL As Double
    Private _TIPO_DE_CAMBIO As Double
    Private _TOTAL_DOLARES As Double

    Private _CODIGO_USUARIO_GRABO As Integer
    Private _NOMBRE_USUARIO_GRABO As String
    Private _FECHA As Date
    Private _FECHA_SERVIDOR As Date

    Private _FOLIO_POLIZA As String
    Private _CODIGO_USUARIO_CANCELO As Integer
    Private _NOMBRE_USUARIO_CANCELO As String
    Private _FECHA_DE_CANCELACION As Date
    Private _FECHA_DE_CANCELACION_SERVIDOR As Date

    Private _CODIGO_BANCO As String
    Private _FOLIO_BANCO As String
    Private _ESTATUS As String

    Private _ID_CUENTA_BANCARIA As Integer

    Private _CUENTA_BANCARIA_PESOS As String
    Private _CUENTA_BANCARIA_DOLARES As String
    Private _CODIGO_TIPO_DOCUMENTO As String

    Private _ABONO_CUENTA_BENEFICIARIO As String
    Private _CODIGO_MODULO As String
    Private _RETENCION As Double
    Private _CODIGO_CONCEPTO_PAGO_CXP As String

    Private _ES_PAGO_VENTAS_NO_FISCALES As Boolean
    Private _CUENTA_CONTABLE_ORIGEN_RECURSOS As String

#End Region

#Region "Campos de sistema"
    Private _Nombre_Catalogo As String
    Private _Nombre_Reporte As String
    Private _Conexion As SqlConnection
    Private _QuerySelect As String
    Private _QueryOrder As String
#End Region

#Region "Campos ligados a la tabla"
    Private _Existe As Boolean 'lectura
    Private _Nombre_Formato As String

    Private _NOMBRE_CUENTA_BANCARIA As String
    Private _CODIGO_MONEDA_SAT As String
    Private _NOMBRE_MONEDA As String
    Private _NOMBRE_CUENTA_CONTABLE_ORIGEN_RECURSOS As String
#End Region

#Region "Campos privados"

#End Region

#End Region

#Region "Propiedades"

#Region "Propiedades Campos de la tabla"
    Public Property FOLIO_CXP() As String
        Get
            Return _FOLIO_CXP
        End Get
        Set(ByVal value As String)
            Me._FOLIO_CXP = value
        End Set
    End Property

    Public Property CODIGO_PROVEEDOR() As String
        Get
            Return _CODIGO_PROVEEDOR
        End Get
        Set(ByVal value As String)
            Me._CODIGO_PROVEEDOR = value
        End Set
    End Property

    Public Property NOMBRE_PROVEEDOR() As String
        Get
            Return _NOMBRE_PROVEEDOR
        End Get
        Set(ByVal value As String)
            Me._NOMBRE_PROVEEDOR = value
        End Set
    End Property

    Public Property FECHA() As Date
        Get
            Return _FECHA
        End Get
        Set(ByVal value As Date)
            Me._FECHA = value
        End Set
    End Property

    Public Property CODIGO_DOCUMENTO() As String
        Get
            Return _CODIGO_DOCUMENTO
        End Get
        Set(ByVal value As String)
            Me._CODIGO_DOCUMENTO = value
        End Set
    End Property

    Public Property ID_TIPO_PAGO() As Integer
        Get
            Return _ID_TIPO_PAGO
        End Get
        Set(ByVal value As Integer)
            Me._ID_TIPO_PAGO = value
        End Set
    End Property

    Public Property FOLIO_REFERENCIA() As String
        Get
            Return _FOLIO_REFERENCIA
        End Get
        Set(ByVal value As String)
            Me._FOLIO_REFERENCIA = value
        End Set
    End Property

    Public Property REFERENCIA_DOCUMENTO() As String
        Get
            Return _REFERENCIA_DOCUMENTO
        End Get
        Set(ByVal value As String)
            Me._REFERENCIA_DOCUMENTO = value
        End Set
    End Property

    Public Property CONCEPTO1() As String
        Get
            Return _CONCEPTO1
        End Get
        Set(ByVal value As String)
            Me._CONCEPTO1 = value
        End Set
    End Property

    Public WriteOnly Property CONCEPTO2() As String
        Set(ByVal value As String)
            Me._CONCEPTO2 = value
        End Set
    End Property

    Public WriteOnly Property CODIGO_PLAZA() As Integer
        Set(ByVal value As Integer)
            Me._CODIGO_PLAZA = value
        End Set
    End Property

    Public Property ESTATUS() As String
        Get
            Return Me._ESTATUS
        End Get
        Set(ByVal value As String)
            Me._ESTATUS = value
        End Set
    End Property

    'Public Property TOTAL() As Double
    '    Get
    '        Return _TOTAL
    '    End Get
    '    Set(ByVal value As Double)
    '        Me._TOTAL = value
    '    End Set
    'End Property
    'Public WriteOnly Property BANCO() As String
    '    Set(ByVal value As String)
    '        Me._BANCO = value
    '    End Set
    'End Property

    Public Property ESTATUS_CXP() As String
        Get
            Return Me._ESTATUS_CXP
        End Get
        Set(ByVal value As String)
            Me._ESTATUS_CXP = value
        End Set
    End Property

    Public Property CODIGO_BANCO() As String
        Get
            Return Me._CODIGO_BANCO
        End Get
        Set(ByVal value As String)
            Me._CODIGO_BANCO = value
        End Set
    End Property

    Public Property FOLIO_BANCO() As String
        Get
            Return Me._FOLIO_BANCO
        End Get
        Set(ByVal value As String)
            Me._FOLIO_BANCO = value
        End Set
    End Property

    Public Property FOLIO_POLIZA() As String
        Get
            Return _FOLIO_POLIZA
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

    Public ReadOnly Property NOMBRE_USUARIO_CANCELO() As String
        Get
            Return Me._NOMBRE_USUARIO_CANCELO
        End Get
    End Property

    Public Property SUBTOTAL() As Double
        Get
            Return Me._SUBTOTAL
        End Get
        Set(ByVal value As Double)
            Me._SUBTOTAL = value
        End Set
    End Property

    Public Property IMPUESTO() As Double
        Get
            Return Me._IMPUESTO
        End Get
        Set(ByVal value As Double)
            Me._IMPUESTO = value
        End Set
    End Property

    Public Property TOTAL() As Double
        Get
            Return _TOTAL
        End Get
        Set(ByVal value As Double)
            Me._TOTAL = value
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

    Public Property ID_CUENTA_BANCARIA() As Integer
        Get
            Return _ID_CUENTA_BANCARIA
        End Get
        Set(ByVal value As Integer)
            Me._ID_CUENTA_BANCARIA = value
        End Set
    End Property

    Public Property CUENTA_CONTABLE_PESOS() As String
        Get
            Return _CUENTA_CONTABLE_PESOS
        End Get
        Set(ByVal value As String)
            Me._CUENTA_CONTABLE_PESOS = value
        End Set
    End Property

    Public Property CUENTA_CONTABLE_DOLARES() As String
        Get
            Return _CUENTA_CONTABLE_DOLARES
        End Get
        Set(ByVal value As String)
            Me._CUENTA_CONTABLE_DOLARES = value
        End Set
    End Property

    Public ReadOnly Property CUENTA_BANCARIA_PESOS() As String
        Get
            Return _CUENTA_BANCARIA_PESOS
        End Get
    End Property

    Public ReadOnly Property CUENTA_BANCARIA_DOLARES() As String
        Get
            Return _CUENTA_BANCARIA_DOLARES
        End Get
    End Property

    Public ReadOnly Property FECHA_SERVIDOR() As Date
        Get
            Return Me._FECHA_SERVIDOR
        End Get
    End Property

    Public Property FECHA_DE_CANCELACION() As Date
        Get
            Return Me._FECHA_DE_CANCELACION
        End Get
        Set(ByVal value As Date)
            Me._FECHA_DE_CANCELACION = value
        End Set
    End Property

    Public ReadOnly Property FECHA_DE_CANCELACION_SERVIDOR() As Date
        Get
            Return Me._FECHA_DE_CANCELACION_SERVIDOR
        End Get
    End Property
    Public Property USUARIO_CANCERLO() As Integer
        Get
            Return Me._CODIGO_USUARIO_CANCELO
        End Get
        Set(ByVal value As Integer)
            Me._CODIGO_USUARIO_CANCELO = value
        End Set
    End Property

    Public Property ABONO_CUENTA_BENEFICIARIO() As String
        Get
            Return _ABONO_CUENTA_BENEFICIARIO
        End Get
        Set(ByVal value As String)
            Me._ABONO_CUENTA_BENEFICIARIO = value
        End Set
    End Property
    Public Property CODIGO_MODULO() As String
        Get
            Return Me._CODIGO_MODULO
        End Get
        Set(ByVal value As String)
            Me._CODIGO_MODULO = value
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

    Public Property TOTAL_DOLARES() As Double
        Get
            Return Me._TOTAL_DOLARES
        End Get
        Set(ByVal value As Double)
            Me._TOTAL_DOLARES = value
        End Set
    End Property

    Public Property CODIGO_CONCEPTO_PAGO_CXP() As String
        Get
            Return Me._CODIGO_CONCEPTO_PAGO_CXP
        End Get
        Set(ByVal value As String)
            Me._CODIGO_CONCEPTO_PAGO_CXP = value
        End Set
    End Property

    Public Property ES_PAGO_VENTAS_NO_FISCALES() As Boolean
        Get
            Return Me._ES_PAGO_VENTAS_NO_FISCALES
        End Get
        Set(ByVal value As Boolean)
            Me._ES_PAGO_VENTAS_NO_FISCALES = value
        End Set
    End Property

    Public Property CUENTA_CONTABLE_ORIGEN_RECURSOS() As String
        Get
            Return Me._CUENTA_CONTABLE_ORIGEN_RECURSOS
        End Get
        Set(ByVal value As String)
            Me._CUENTA_CONTABLE_ORIGEN_RECURSOS = value
        End Set
    End Property

#End Region

#Region "Propiedad Nombre de Clase"
    Public ReadOnly Property Nombre_Clase() As String
        Get
            Return "Class_CxpGlobal"
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

    Public ReadOnly Property NOMBRE_CUENTA_BANCARIA() As String
        Get
            Return _NOMBRE_CUENTA_BANCARIA
        End Get
    End Property

    Public ReadOnly Property CODIGO_MONEDA_SAT() As String
        Get
            Return _CODIGO_MONEDA_SAT
        End Get
    End Property

    Public ReadOnly Property NOMBRE_MONEDA() As String
        Get
            Return _NOMBRE_MONEDA
        End Get
    End Property

    Public ReadOnly Property NOMBRE_CUENTA_CONTABLE_ORIGEN_RECURSOS() As String
        Get
            Return _NOMBRE_CUENTA_CONTABLE_ORIGEN_RECURSOS
        End Get
    End Property

#End Region

#End Region

    Public oDocumento As New Class_CatDocumentos

#Region "Constructor y destructor"
    Public Sub New()
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
    End Sub

    Public Sub New(ByVal folioBanco As String)
        Me.New()
        Me._FOLIO_BANCO = folioBanco

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
    Public Function Inserta_Global() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_BANCOS_CXP_GRABA_GLOBAL"

            sqlParametro = .Parameters.Add("@FOLIO_BANCO", SqlDbType.NVarChar, 15) : sqlParametro.Direction = ParameterDirection.InputOutput : sqlParametro.Value = Me._FOLIO_BANCO
            sqlParametro = .Parameters.Add("@ID_CUENTA_BANCARIA", SqlDbType.SmallInt) : sqlParametro.Value = Me._ID_CUENTA_BANCARIA
            sqlParametro = .Parameters.Add("@TOTAL", SqlDbType.Money) : sqlParametro.Value = Me._TOTAL
            sqlParametro = .Parameters.Add("@CODIGO_DOCUMENTO", SqlDbType.NVarChar, 10) : sqlParametro.Value = Me._CODIGO_DOCUMENTO
            sqlParametro = .Parameters.Add("@FECHA", SqlDbType.DateTime) : sqlParametro.Value = Me._FECHA
            sqlParametro = .Parameters.Add("@CONCEPTO", SqlDbType.NVarChar, 100) : sqlParametro.Value = Me._CONCEPTO1
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO_GRABO", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Usuario
            sqlParametro = .Parameters.Add("@CODIGO_PLAZA", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_PLAZA
            sqlParametro = .Parameters.Add("@TIPO_DE_CAMBIO", SqlDbType.Decimal) : sqlParametro.Value = Me._TIPO_DE_CAMBIO
            sqlParametro = .Parameters.Add("@TOTAL_DOLARES", SqlDbType.Decimal) : sqlParametro.Value = Me._TOTAL_DOLARES
            sqlParametro = .Parameters.Add("@ABONO_CUENTA_BENEFICIARIO", SqlDbType.NVarChar, 1) : sqlParametro.Value = Me._ABONO_CUENTA_BENEFICIARIO
            sqlParametro = .Parameters.Add("@CODIGO_CONCEPTO_PAGO_CXP", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_CONCEPTO_PAGO_CXP
            sqlParametro = .Parameters.Add("@ES_PAGO_VENTAS_NO_FISCALES", SqlDbType.Bit) : sqlParametro.Value = Convert.ToInt32(Me._ES_PAGO_VENTAS_NO_FISCALES)
            sqlParametro = .Parameters.Add("@CUENTA_CONTABLE_ORIGEN_RECURSOS", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._CUENTA_CONTABLE_ORIGEN_RECURSOS

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                Me._FOLIO_BANCO = "" & .Parameters("@FOLIO_BANCO").Value.ToString
                bResultado = True
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "Inserta_Global", ex)
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
        'VW_BANCOS_GLOBAL_CON_CXP_GLOBAL Where FOLIO_BANCO=
        Dim cmd As New SqlCommand("SELECT V.*, CD.NOMBRE_FORMATO AS NOMBRE_FORMATO_DOCUMENTO,CB.NOMBRE_FORMATO AS NOMBRE_FORMATO_CHEQUE,S.CODIGO_MODULO " &
                                  "FROM VW_BANCOS_GLOBAL_CON_CXP_GLOBAL V " &
                                  "INNER JOIN SIS_CAT_DOCUMENTOS CD ON (V.CODIGO_DOCUMENTO=CD.CODIGO_DOCUMENTO) " &
                                  "INNER JOIN SIS_TIPOS_DOCUMENTOS S on(CD.CODIGO_TIPO_DOCUMENTO=S.CODIGO_TIPO_DOCUMENTO) " &
                                  "INNER JOIN CAT_CUENTAS_BANCARIAS CB ON (V.ID_CUENTA_BANCARIA=CB.ID_CUENTA_BANCARIA) " &
                                  "WHERE V.FOLIO_BANCO='" & Me._FOLIO_BANCO & "' AND V.CODIGO_PLAZA= " & Plaza.CODIGO_PLAZA & " ", Me._Conexion)
        Dim dReader As SqlDataReader

        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read = True Then
                    Me._FOLIO_BANCO = CType(dReader("FOLIO_BANCO"), String)
                    Me._ID_CUENTA_BANCARIA = CType(dReader("ID_CUENTA_BANCARIA"), Integer)
                    Me._NOMBRE_CUENTA_BANCARIA = CType(dReader("NOMBRE_CUENTA_BANCARIA"), String)
                    Me._CUENTA_CONTABLE_ORIGEN_RECURSOS = "" & dReader("CUENTA_CONTABLE_ORIGEN_RECURSOS").ToString 'Este campo se creó en oct/20, los movs anteriores tendrán la cuenta en null
                    Me._NOMBRE_CUENTA_CONTABLE_ORIGEN_RECURSOS = "" & dReader("NOMBRE_CUENTA_CONTABLE_ORIGEN_RECURSOS").ToString
                    Me._CODIGO_BANCO = CType(dReader("CODIGO_BANCO"), String)
                    Me._CUENTA_BANCARIA_PESOS = CType(dReader("CUENTA_BANCARIA_PESOS"), String)
                    Me._CUENTA_BANCARIA_DOLARES = "" & dReader("CUENTA_BANCARIA_DOLARES").ToString
                    Me._TOTAL = CType(dReader("TOTAL_PAGO"), Double) 'NOTA, ANTES AQUI USABA EL CAMPO TOTAL LO CUAL ES INCORRECTO PORQUE SE REFIERE A CXP Y NO BANCOS GLOBAL. 
                    Me._CODIGO_DOCUMENTO = CType(dReader("CODIGO_DOCUMENTO"), String)
                    Me._CONCEPTO1 = CType(dReader("CONCEPTO"), String)
                    Me._FOLIO_POLIZA = "" & dReader("FOLIO_POLIZA").ToString
                    Me._ESTATUS = CType(dReader("ESTATUS"), String)
                    Me._CODIGO_PROVEEDOR = CType(dReader("CODIGO_PROVEEDOR"), String)
                    Me._NOMBRE_PROVEEDOR = CType(dReader("NOMBRE_PROVEEDOR"), String)
                    Me._CUENTA_CONTABLE_PESOS = CType(dReader("CUENTA_CONTABLE"), String)
                    Me._CUENTA_CONTABLE_DOLARES = "" & dReader("CUENTA_CONTABLE_DOLARES").ToString
                    Me._FECHA = CType(dReader("FECHA"), Date)
                    Me._FECHA_SERVIDOR = CType(dReader("FECHA_SERVIDOR"), Date)
                    Me._CODIGO_USUARIO_GRABO = CType(dReader("CODIGO_USUARIO_GRABO"), Integer)
                    Me._NOMBRE_USUARIO_GRABO = CType(dReader("NOMBRE_USUARIO_GRABO"), String)
                    Me._Nombre_Formato = IIf(txtLEN(dReader("NOMBRE_FORMATO_DOCUMENTO").ToString), dReader("NOMBRE_FORMATO_DOCUMENTO").ToString, dReader("NOMBRE_FORMATO_CHEQUE").ToString).ToString
                    Me._CODIGO_MODULO = CType(dReader("CODIGO_MODULO"), String)
                    Me._ABONO_CUENTA_BENEFICIARIO = CType(dReader("ABONO_CUENTA_BENEFICIARIO"), String)
                    Me._TIPO_DE_CAMBIO = CType(dReader("TIPO_DE_CAMBIO"), Double)
                    Me._TOTAL_DOLARES = CType(dReader("TOTAL_DOLARES"), Double)
                    Me._RETENCION = CType(dReader("RETENCION"), Double)
                    If Me._ESTATUS = "C" Then
                        Me._CODIGO_USUARIO_CANCELO = CType(dReader("CODIGO_USUARIO_CANCELO"), Integer)
                        Me._NOMBRE_USUARIO_CANCELO = CType(dReader("NOMBRE_USUARIO_CANCELO"), String)
                        Me._FECHA_DE_CANCELACION = CType(dReader("FECHA_DE_CANCELACION"), Date)
                        Me._FECHA_DE_CANCELACION_SERVIDOR = CType(dReader("FECHA_DE_CANCELACION_SERVIDOR"), Date)
                    End If
                    Me._CODIGO_CONCEPTO_PAGO_CXP = CType(dReader("CODIGO_CONCEPTO_PAGO_CXP"), String)
                    Me._CODIGO_MONEDA_SAT = CType(dReader("CODIGO_MONEDA_SAT"), String)
                    Me._NOMBRE_MONEDA = CType(dReader("NOMBRE_MONEDA"), String)
                    Me._ES_PAGO_VENTAS_NO_FISCALES = CBool(dReader("ES_PAGO_VENTAS_NO_FISCALES"))

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

    Public Function ActualizaFolioPoliza() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_BANCOS_CXP_ACTUALIZA_FOLIO_POLIZA"

            sqlParametro = .Parameters.Add("@FOLIO_BANCO", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_BANCO

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                Me._FOLIO_POLIZA = Me._FOLIO_BANCO
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

    Public Function ObtenerDetalle() As DataTable
        Dim dTabla As New DataTable("detalle"), da As SqlDataAdapter
        Dim sSQL As String

        'CargaFacturasPagadas()
        'sSQL = "SELECT B.FOLIO_REFERENCIA_USUARIO,ISNULL(Convert(varchar(10),B.FECHA, 103),'') FECHA,B.FOLIO_REFERENCIA,B.NOMBRE_MONEDA_CO,B.TIPO_DE_CAMBIO_CO,B.IMPUESTO_USD_COMPRA,B.TOTAL_COMPRA_DOLARES,B.SALDO_USD_CO,B.CONCEPTO_COMPRA," &
        '       "B.IMPUESTO_COMPRA,B.TOTAL_COMPRA,B.SALDO_COMPRA,0 SALDO_IMPUESTO,B.RETENCION_IVA,B.TOTAL_DETALLE_IMPUESTO,B.TOTAL_DETALLE,B.TOTAL_DETALLE_DOLARES,0,B.CODIGO_DOCUMENTO_COMPRA,'' " &
        '       "FROM VW_BANCOS_CXP_DETALLE B " &
        '       "WHERE B.FOLIO_BANCO='" & Me._FOLIO_BANCO & "' AND B.CODIGO_PLAZA= " & Plaza.CODIGO_PLAZA & " " &
        '       "ORDER BY FECHA"

        sSQL = "SELECT B.FOLIO_REFERENCIA_USUARIO,ISNULL(Convert(varchar(10),B.FECHA, 103),'') FECHA,B.FOLIO_REFERENCIA,B.CODIGO_MONEDA_SAT_CO,B.TIPO_DE_CAMBIO_CO,B.SUBTOTAL_USD_CO,B.IMPUESTO_USD_CO,B.TOTAL_COMPRA_DOLARES,B.SALDO_USD_CO,B.CONCEPTO_COMPRA," &
               "B.IMPUESTO_COMPRA,B.TOTAL_COMPRA," &
               "CASE When B.CODIGO_MONEDA_SAT_CO='USD' THEN ROUND(B.SALDO_COMPRA_DOLARES*B.TIPO_DE_CAMBIO,2) ELSE B.SALDO_COMPRA END SALDO_MXN_TP_PAGO,B.SALDO_COMPRA SALDO_CXP," &
               "0 SALDO_IMPUESTO,B.RETENCION_IVA,B.IVA_PAGADO_CXP,B.IVA_PENDIENTE_PAGO," &
               "B.PAGO_MXN_BANCOS_CXP,B.TOTAL_DETALLE CXP_TOTAL," &
               "B.TOTAL_DETALLE_DOLARES,0 SELECCION,B.CODIGO_DOCUMENTO_COMPRA,'' AUTORIZADO," &
               "B.SUBTOTAL_CXP,B.SUBTOTAL_PAGADO_CXP,B.DIFERENCIA_CAMBIARIA_CXP " &
               "FROM VW_BANCOS_CXP_DETALLE B " &
               "WHERE B.FOLIO_BANCO='" & Me._FOLIO_BANCO & "' AND B.CODIGO_PLAZA= " & Plaza.CODIGO_PLAZA & " " &
               "ORDER BY B.ID_CXP_GLOBAL"

        Try
            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dTabla)
            da.Dispose()
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "ObtenerDetalle", ex)
        End Try
        Return dTabla
    End Function

    Public Function CargaComprasProveedorConSaldo(ByVal CodigoProveedor As String, Optional ByVal dTipoCambioPago As Decimal = CDec(0)) As DataTable
        Dim dTabla As New DataTable("detalle"), da As SqlDataAdapter ',IMPUESTO_PORCENTAJE

        'Dim sSQL As String = ("SELECT FOLIO_PROVEEDOR,ISNULL(Convert(varchar(10),G.FECHA, 103),'') FECHA,G.FOLIO_COMPRA,M.ABREVIACION NOMBRE_MONEDA_CO,G.TIPO_DE_CAMBIO,G.IMPUESTO_USD,G.TOTAL_DOLARES,G.SALDO_DOLARES,LEFT(CONCEPTO,40) CONCEPTO, " &
        '                      "G.IMPUESTO,G.TOTAL,G.SALDO,SALDO_IMPUESTO,RETENCION_IVA,0 PAGAR_IMPUESTO,ISNULL(A.IMPORTE_AUTORIZADO,0) PAGAR,0 PAGO_USD, " &
        '                      "CASE WHEN G.SALDO=ISNULL(A.IMPORTE_AUTORIZADO,0) THEN 1 ELSE 0 END SELECCION, CODIGO_DOCUMENTO,ISNULL(Convert(varchar(10),A.FECHA_AUTORIZACION, 103),'') AUTORIZADO " &
        '                      "FROM COMPRA_GLOBAL G " &
        '                      "INNER JOIN CAT_PROVEEDORES P ON(G.CODIGO_PROVEEDOR=P.CODIGO_PROVEEDOR)  " &
        '                      "LEFT JOIN CXP_PAGOS_AUTORIZADOS A ON(G.FOLIO_COMPRA=A.FOLIO_COMPRA AND A.ESTATUS_AUTORIZACION_USADA='0') " &
        '                      "INNER JOIN CATALOGO_MONEDAS M ON(G.CODIGO_MONEDA=M.CODIGO_MONEDA)" &
        '                      "WHERE G.CODIGO_PROVEEDOR='" & sReplace(CodigoProveedor) & "' AND G.SALDO<>0 AND G.CODIGO_PLAZA=" & Plaza.CODIGO_PLAZA & " ORDER BY CAST(G.FECHA AS DATETIME)")

        Dim sSQL As String = ("SELECT FOLIO_PROVEEDOR,ISNULL(Convert(varchar(10),G.FECHA, 103),'') FECHA,G.FOLIO_COMPRA,M.CODIGO_MONEDA_SAT,G.TIPO_DE_CAMBIO," &
                              "G.SUBTOTAL_USD,G.IMPUESTO_USD,G.TOTAL_DOLARES,LEFT(CONCEPTO,40) CONCEPTO, " &
                              "G.IMPUESTO,G.TOTAL,G.SALDO,SALDO_IMPUESTO,RETENCION_IVA,0 PAGAR_IMPUESTO,ISNULL(A.IMPORTE_AUTORIZADO,0) PAGAR,0 PAGO_USD, " &
                              "CASE WHEN G.SALDO=ISNULL(A.IMPORTE_AUTORIZADO,0) THEN 1 ELSE 0 END SELECCION, CODIGO_DOCUMENTO,ISNULL(Convert(varchar(10),A.FECHA_AUTORIZACION, 103),'') AUTORIZADO, " &
                              "CASE WHEN G.CODIGO_MONEDA='2'/*1=MXN,2=USD*/ THEN ROUND(G.SALDO_DOLARES*" & dTipoCambioPago.ToString & ",2) ELSE G.SALDO END SALDO_MXN_TP_PAGO,G.SALDO SALDO_CXP," &
                              "CASE WHEN G.CODIGO_MONEDA='2'/*1=MXN,2=USD*/ THEN G.SALDO_DOLARES ELSE ROUND(G.SALDO/" & dTipoCambioPago.ToString & ",2) END SALDO_DOLARES " &
                              "FROM COMPRA_GLOBAL G " &
                              "INNER JOIN CAT_PROVEEDORES P ON(G.CODIGO_PROVEEDOR=P.CODIGO_PROVEEDOR)  " &
                              "LEFT JOIN CXP_PAGOS_AUTORIZADOS A ON(G.FOLIO_COMPRA=A.FOLIO_COMPRA AND A.ESTATUS_AUTORIZACION_USADA='0') " &
                              "INNER JOIN CATALOGO_MONEDAS M ON(G.CODIGO_MONEDA=M.CODIGO_MONEDA)" &
                              "WHERE G.CODIGO_PROVEEDOR='" & sReplace(CodigoProveedor) & "' AND G.SALDO<>0 AND G.CODIGO_PLAZA=" & Plaza.CODIGO_PLAZA & " ORDER BY CAST(G.FECHA AS DATETIME)")
        Try
            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dTabla)
            da.Dispose()

        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "CargaComprasProveedorConSaldo", ex)
        End Try
        Return dTabla
    End Function

    Public Function SiTieneComprasProveedorConSaldoUSD(ByVal CodigoProveedor As String) As Boolean
        Dim bResultado As Boolean = False
        Dim sSQL As String = ("SELECT TOP 1 '1' HAY_COMPRAS_EN_USD " &
                              "FROM COMPRA_GLOBAL G " &
                              "INNER JOIN CAT_PROVEEDORES P ON(G.CODIGO_PROVEEDOR=P.CODIGO_PROVEEDOR)  " &
                              "INNER JOIN CATALOGO_MONEDAS M ON(G.CODIGO_MONEDA=M.CODIGO_MONEDA)" &
                              "WHERE G.CODIGO_PROVEEDOR='" & sReplace(CodigoProveedor) & "' AND G.SALDO<>0 AND G.CODIGO_PLAZA=" & Plaza.CODIGO_PLAZA & " AND G.CODIGO_MONEDA='2'") '--1=MXN,2=USD
        Try
            Dim oFind As New Class_find(sSQL)
            If oFind.Result1 = "1" Then
                bResultado = True
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "SiTieneComprasProveedorConSaldoUSD", ex)
        End Try
        Return bResultado
    End Function

    Public Function CargaComprasProveedorConSaldoParaDescuentos(ByVal CodigoProveedor As String) As DataTable
        Dim dTabla As New DataTable("detalle"), da As SqlDataAdapter ',IMPUESTO_PORCENTAJE
        Dim sSQL As String = ("SELECT FOLIO_PROVEEDOR,ISNULL(Convert(varchar(10),G.FECHA, 103),'') FECHA,G.FOLIO_COMPRA,CONCEPTO, " & _
                              "TOTAL,G.SALDO,0 DESCUENTO_SUBTOTAL, 0 DESCUENTO_IVA, CODIGO_DOCUMENTO, IMPUESTO_PORCENTAJE TIENE_IVA " & _
                              "FROM COMPRA_GLOBAL G " & _
                              "INNER JOIN CAT_PROVEEDORES P ON(G.CODIGO_PROVEEDOR=P.CODIGO_PROVEEDOR)  " & _
                              "WHERE G.CODIGO_PROVEEDOR='" & sReplace(CodigoProveedor) & "' AND G.SALDO<>0 AND G.CODIGO_PLAZA=" & Plaza.CODIGO_PLAZA & " ORDER BY CAST(G.FECHA AS DATETIME)")
        Try
            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dTabla)
            da.Dispose()

        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "CargaComprasProveedorConSaldoParaDescuentos", ex)
        End Try
        Return dTabla
    End Function

    Public Function CargaFacturasPagadas(ByVal CodigoProveedor As String, ByVal Folio As String) As DataTable
        Dim dTabla As New DataTable("detalle"), da As SqlDataAdapter
        Dim sSQL As String

        sSQL = ("SELECT FOLIO_PROVEEDOR,FECHA,FOLIO_COMPRA,CONCEPTO,TOTAL,SALDO,0,FOLIO_CXP " & _
        "FROM VW_BANCOS_CXP_DETALLE WHERE CODIGO_PROVEEDOR='" & sReplace(CodigoProveedor) & "' " & _
        "AND FOLIO_BANCO='" & sReplace(Folio) & "' ORDER BY FECHA")

        Try
            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dTabla)
            da.Dispose()
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "CargaFacturasPagadas", ex)
        End Try
        Return dTabla
    End Function

    Public Function GeneraFolio() As String
        Me.oDocumento.CODIGO_DOCUMENTO = Me._CODIGO_DOCUMENTO
        Me.oDocumento.GeneraFolio()
        Return Me.oDocumento.FOLIO
    End Function

    Public Function GeneraFolioCheque(ByVal CuentaBancaria As Integer) As String
        Return Me.oDocumento.GeneraFolioCheque(CuentaBancaria)
    End Function

    Public Function ExisteDocumento(ByVal sFolio As String) As Boolean
        Try
            Dim sql As New Class_find("SELECT 1 FROM BANCOS_GLOBAL WHERE FOLIO_BANCO='" & sReplace(sFolio) & "'")
            If sql.Result1.Length > 0 Then
                Return True
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "ExisteDocumento", ex)
        End Try
    End Function

    Public Function ConsultarCxp(ByVal sFolio As String) As Boolean
        Dim bResultado As Boolean = False
        Dim sql As String = "SELECT FOLIO_CXP,D.ESTATUS_CXP,D.FECHA,D.CODIGO_DOCUMENTO_CXP,T.NOMBRE_TIPO_DOCUMENTO,D.CODIGO_PROVEEDOR,D.NOMBRE_PROVEEDOR," & _
                            "FOLIO_REFERENCIA,D.FOLIO_BANCO,D.TOTAL,D.TOTAL_PAGO,D.CONCEPTO,D.NOMBRE_USUARIO_GRABO  " & _
                            "FROM VW_BANCOS_GLOBAL_CON_CXP_GLOBAL D INNER JOIN SIS_TIPOS_DOCUMENTOS T ON (D.CODIGO_TIPO_DOCUMENTO=T.CODIGO_TIPO_DOCUMENTO)" & _
                            "WHERE D.FOLIO_CXP='" & sFolio & "' AND D.CODIGO_PLAZA= " & Plaza.CODIGO_PLAZA & " "

        Dim Conexion As New SqlConnection(Empresa_Sistema.conexion)
        Dim cmd As New SqlCommand(sql, Conexion)
        Dim dReader As SqlDataReader

        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Conexion.Open()
                dReader = .ExecuteReader()
                If dReader.Read = True Then
                    Me._FOLIO_CXP = CType(dReader("FOLIO_CXP"), String)
                    Me._ESTATUS_CXP = CType(dReader("ESTATUS_CXP"), String)
                    Me._FECHA = CType(dReader("FECHA"), Date)
                    Me._CODIGO_DOCUMENTO = CType(dReader("CODIGO_DOCUMENTO_CXP"), String)
                    Me._Nombre_Formato = CType(dReader("NOMBRE_TIPO_DOCUMENTO"), String)
                    Me._TOTAL = CType(dReader("TOTAL"), Double)
                    Me._CODIGO_PROVEEDOR = CType(dReader("CODIGO_PROVEEDOR"), String)
                    Me._NOMBRE_PROVEEDOR = CType(dReader("NOMBRE_PROVEEDOR"), String)
                    Me._FOLIO_BANCO = CType(dReader("FOLIO_BANCO"), String)
                    Me._FOLIO_REFERENCIA = "" & dReader("FOLIO_REFERENCIA").ToString
                    Me._CONCEPTO1 = CType(dReader("CONCEPTO"), String)
                    Me._NOMBRE_USUARIO_GRABO = CType(dReader("NOMBRE_USUARIO_GRABO"), String)

                    bResultado = True
                End If
                dReader.Close()
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "ConsultarCxp", ex)
            Finally
                Conexion.Close()
                cmd.Dispose()
            End Try
        End With

        Return bResultado
    End Function

    Public Function CancelaBancosCxp() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_BANCOS_CXP_CANCELA"

            sqlParametro = .Parameters.Add("@FOLIO_BANCO", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_BANCO
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO_CANCELO", SqlDbType.NVarChar, 2) : sqlParametro.Value = Usuario.Codigo_Usuario
            sqlParametro = .Parameters.Add("@FECHA_CANCELACION", SqlDbType.DateTime) : sqlParametro.Value = Me.FECHA_DE_CANCELACION

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                Me._FOLIO_POLIZA = Me._FOLIO_BANCO
                bResultado = True
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "CancelaBancosCxp", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Function ConsultarBancosCXPFletes(ByVal sFolio As String) As Boolean
        Try
            Dim sql As New Class_find("SELECT 1 FROM BANCOS_CXP_FLETES_RELACION WHERE FOLIO_BANCO='" & sReplace(sFolio) & "'")
            If sql.Result1.Length > 0 Then
                Return True
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "ConsultarBancosCXPFletes", ex)
        End Try
    End Function

    Public Function ObtenerDetalleBancosCXPFletes() As DataTable
        Dim dTabla As New DataTable("detalle"), da As SqlDataAdapter
        Dim sSQL As String

        'CargaFacturasPagadas()
        sSQL = "SELECT F.FOLIO_EMBARQUE,P.CONCEPTO1,E.IMPORTE_FLETE,E.SALDO_FLETE,0 FROM BANCOS_CXP_FLETES_RELACION F " & _
        "INNER JOIN BANCOS_GLOBAL B ON(F.FOLIO_BANCO=B.FOLIO_BANCO) INNER JOIN EMB_EMBARQUE_GLOBAL E ON(F.FOLIO_EMBARQUE=E.FOLIO_EMBARQUE)" & _
        "INNER JOIN CON_POLIZAS_GLOBAL P ON(P.FOLIO_POLIZA=E.FOLIO_EMBARQUE) WHERE B.FOLIO_BANCO='" & Me.FOLIO_BANCO.ToString & "'"

        Try
            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dTabla)

            da.Dispose()
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "ObtenerDetalleBancosCXPFletes", ex)
        End Try
        Return dTabla
    End Function

    Public Function CancelaBancosCxpFletes() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_BANCOS_CXP_FLETES_CANCELA"

            sqlParametro = .Parameters.Add("@FOLIO_BANCO", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_BANCO

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                Me._FOLIO_POLIZA = Me._FOLIO_BANCO
                bResultado = True
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "CancelaBancosCxpFletes", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Function ObtienePagosGestionCobrados(ByVal bMostrarCobradosMes As Boolean, ByVal sFechaCobradosMes As String) As DataTable
        Dim dt As New DataTable
        Try
            Using da As New SqlDataAdapter("MP_BANCOS_OBTIENE_PAGOS_PARA_GESTION_COBRADOS", Me._Conexion)
                da.SelectCommand.CommandType = CommandType.StoredProcedure

                With da.SelectCommand
                    .Parameters.Add("@MOSTRAR_COBRADOS_MES", SqlDbType.Char, 1).Value = Convert.ToInt32(bMostrarCobradosMes)
                    .Parameters.Add("@FECHA_COBRADOS_MES", SqlDbType.NVarChar, 20).Value = sFechaCobradosMes
                End With

                da.Fill(dt)
                'dt.Columns.Remove("ID")
            End Using
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "ObtienePagosGestionCobrados", ex)
        End Try
        Return dt
    End Function

    Public Function GrabaPagoEstaCobrado(ByVal bEstaCobrado As Boolean, ByVal bFechaCobro As Date) As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_BANCOS_GRABA_ESTA_COBRADO"

            sqlParametro = .Parameters.Add("@FOLIO_BANCO", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_BANCO
            sqlParametro = .Parameters.Add("@ESTA_COBRADO", SqlDbType.Char, 1) : sqlParametro.Value = Convert.ToInt32(bEstaCobrado)
            sqlParametro = .Parameters.Add("@FECHA_COBRO", SqlDbType.NVarChar, 15) : sqlParametro.Value = bFechaCobro

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "GrabaPagoEstaCobrado", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Function GeneraPoliza(ByVal sCodigoListaFacturasRecibidas As String) As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CONTABILIDAD_ASIENTO_REPETITIVO_PAGO_BANCO"

            sqlParametro = .Parameters.Add("@FOLIO_BANCO", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_BANCO
            sqlParametro = .Parameters.Add("@CODIGO_LISTA_FACTURAS_RECIBIDAS", SqlDbType.NVarChar, 2) : sqlParametro.Value = sCodigoListaFacturasRecibidas

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "GeneraPoliza", ex)
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
