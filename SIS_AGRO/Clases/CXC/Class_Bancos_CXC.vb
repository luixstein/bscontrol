Option Strict On
Imports System.Data
Imports System.Data.SqlClient

Public Class Class_Bancos_CXC
#Region "Campos"
#Region "Campos de la tabla"

    Private _FOLIO_CXC As String
    Private _CODIGO_Cliente As String
    Private _NOMBRE_Cliente As String
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
    Private _ESTATUS_CXC As String
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
    Private _NOMBRE_CUENTA_BANCARIA As String

    Private _CUENTA_BANCARIA_PESOS As String
    Private _CUENTA_BANCARIA_DOLARES As String
    Private _CODIGO_TIPO_DOCUMENTO As String

    'Private _ABONO_CUENTA_BENEFICIARIO As String
    Private _CODIGO_MODULO As String

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
#End Region

#Region "Campos privados"

#End Region

#End Region

#Region "Propiedades"
#Region "Propiedades Campos de la tabla"
    Public Property FOLIO_CXC() As String
        Get
            Return _FOLIO_CXC
        End Get
        Set(ByVal value As String)
            Me._FOLIO_CXC = value
        End Set
    End Property
    Public Property CODIGO_Cliente() As String
        Get
            Return _CODIGO_Cliente
        End Get
        Set(ByVal value As String)
            Me._CODIGO_Cliente = value
        End Set
    End Property
    Public Property NOMBRE_Cliente() As String
        Get
            Return _NOMBRE_Cliente
        End Get
        Set(ByVal value As String)
            Me._NOMBRE_Cliente = value
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
    Public Property ESTATUS_CXC() As String
        Get
            Return Me._ESTATUS_CXC
        End Get
        Set(ByVal value As String)
            Me._ESTATUS_CXC = value
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
    Public Property ID_CUENTA_BANCARIA() As Integer
        Get
            Return _ID_CUENTA_BANCARIA
        End Get
        Set(ByVal value As Integer)
            Me._ID_CUENTA_BANCARIA = value
        End Set
    End Property
    Public Property NOMBRE_CUENTA_BANCARIA() As String
        Get
            Return _NOMBRE_CUENTA_BANCARIA
        End Get
        Set(ByVal value As String)
            Me._NOMBRE_CUENTA_BANCARIA = value
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
    'Private _CODIGO_TIPO_DOCUMENTO As String
    'NOMBRE_USUARIO
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

    'Public Property ABONO_CUENTA_BENEFICIARIO() As String
    '    Get
    '        Return _ABONO_CUENTA_BENEFICIARIO
    '    End Get
    '    Set(ByVal value As String)
    '        Me._ABONO_CUENTA_BENEFICIARIO = value
    '    End Set
    'End Property
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

#End Region

#Region "Propiedad Nombre de Clase"
    Public ReadOnly Property Nombre_Clase() As String
        Get
            Return "Class_Bancos_CXC"
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

#End Region
#End Region

    Public oDocumento As New Class_CatDocumentos

#Region "Constructor y destructor"
    Public Sub New()
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
    End Sub                                                         'Inicializa al objeto.

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
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_BANCOS_CXC_GRABA_GLOBAL"

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
            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                Me._FOLIO_BANCO = "" & .Parameters("@FOLIO_BANCO").Value.ToString
                Inserta_Global = True
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "Inserta_Global", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
    End Function

    Public Function Consultar() As Boolean
        'VW_BANCOS_GLOBAL_CON_CXC_GLOBAL Where FOLIO_BANCO=
        Dim cmd As New SqlCommand("SELECT V.*, CD.NOMBRE_FORMATO AS NOMBRE_FORMATO_DOCUMENTO,CB.NOMBRE_FORMATO AS NOMBRE_FORMATO_CHEQUE, S.CODIGO_MODULO " & _
                                  "FROM VW_BANCOS_GLOBAL_CON_CXC_GLOBAL V " & _
                                  "INNER JOIN SIS_CAT_DOCUMENTOS CD ON (V.BAN_CODIGO_DOCUMENTO=CD.CODIGO_DOCUMENTO) " & _
                                  "INNER JOIN SIS_TIPOS_DOCUMENTOS S on(CD.CODIGO_TIPO_DOCUMENTO=S.CODIGO_TIPO_DOCUMENTO) " & _
                                  "INNER JOIN CAT_CUENTAS_BANCARIAS CB ON (V.BAN_ID_CUENTA_BANCARIA=CB.ID_CUENTA_BANCARIA) " & _
                                  "WHERE V.BAN_FOLIO_BANCO='" & Me._FOLIO_BANCO & "'", Me._Conexion)
        Dim dReader As SqlDataReader

        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then

                    Me._FOLIO_BANCO = CType(dReader("BAN_FOLIO_BANCO"), String)
                    Me._ID_CUENTA_BANCARIA = CType(dReader("BAN_ID_CUENTA_BANCARIA"), Integer)
                    Me._NOMBRE_CUENTA_BANCARIA = CType(dReader("BAN_NOMBRE_CUENTA_BANCARIA"), String)
                    Me._CODIGO_BANCO = CType(dReader("BAN_CODIGO_BANCO"), String)
                    Me._CUENTA_BANCARIA_PESOS = CType(dReader("BAN_CUENTA_CONTABLE_PESOS"), String)
                    Me._CUENTA_BANCARIA_DOLARES = "" & dReader("BAN_CUENTA_CONTABLE_DOLARES").ToString
                    Me._TOTAL = CType(dReader("BAN_TOTAL"), Double)
                    Me._CODIGO_DOCUMENTO = CType(dReader("BAN_CODIGO_DOCUMENTO"), String)
                    Me._CONCEPTO1 = CType(dReader("BAN_CONCEPTO"), String)
                    Me._FOLIO_POLIZA = "" & dReader("BAN_FOLIO_POLIZA").ToString
                    Me._ESTATUS = CType(dReader("BAN_ESTATUS"), String)
                    Me._CODIGO_Cliente = CType(dReader("CXC_CODIGO_CLIENTE"), String)
                    Me._NOMBRE_Cliente = CType(dReader("CXC_NOMBRE_CLIENTE"), String)
                    Me._CUENTA_CONTABLE_PESOS = CType(dReader("CXC_CUENTA_CONTABLE_CLIENTE"), String)
                    Me._CUENTA_CONTABLE_DOLARES = "" & dReader("CXC_CUENTA_CONTABLE_DOLARES_CLIENTE").ToString
                    Me._FECHA = CType(dReader("BAN_FECHA"), Date)
                    Me._FECHA_SERVIDOR = CType(dReader("BAN_FECHA_SERVIDOR"), Date)
                    Me._CODIGO_USUARIO_GRABO = CType(dReader("BAN_CODIGO_USUARIO_GRABO"), Integer)
                    Me._NOMBRE_USUARIO_GRABO = CType(dReader("BAN_NOMBRE_USUARIO_GRABO"), String)
                    Me._Nombre_Formato = IIf(txtLEN(dReader("NOMBRE_FORMATO_DOCUMENTO").ToString), dReader("NOMBRE_FORMATO_DOCUMENTO").ToString, dReader("NOMBRE_FORMATO_CHEQUE").ToString).ToString
                    Me._CODIGO_MODULO = CType(dReader("CODIGO_MODULO"), String)
                    'Me._ABONO_CUENTA_BENEFICIARIO = CType(dReader("ABONO_CUENTA_BENEFICIARIO"), String)
                    Me._TIPO_DE_CAMBIO = CType(dReader("BAN_TIPO_DE_CAMBIO"), Double)
                    Me._TOTAL_DOLARES = CType(dReader("BAN_TOTAL_DOLARES"), Double)

                    If Me._ESTATUS = "C" Then
                        Me._CODIGO_USUARIO_CANCELO = CType(dReader("BAN_CODIGO_USUARIO_CANCELO"), Integer)
                        Me._NOMBRE_USUARIO_CANCELO = CType(dReader("BAN_NOMBRE_USUARIO_CANCELO"), String)
                        Me._FECHA_DE_CANCELACION = CType(dReader("BAN_FECHA_DE_CANCELACION"), Date)
                        Me._FECHA_DE_CANCELACION_SERVIDOR = CType(dReader("BAN_FECHA_DE_CANCELACION_SERVIDOR"), Date)
                    End If

                    Consultar = True

                End If
                dReader.Close()
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "Consultar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
            End Try
        End With
    End Function

    Public Function ActualizaFolioPoliza() As Boolean
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_BANCOS_CXC_ACTUALIZA_FOLIO_POLIZA"

            sqlParametro = .Parameters.Add("@FOLIO_BANCO", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_BANCO

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                Me._FOLIO_POLIZA = Me._FOLIO_BANCO
                ActualizaFolioPoliza = True
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "ActualizaFolioPoliza", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
    End Function

    Public Function ObtenerDetalle() As DataTable
        Dim dTabla As New DataTable("detalle"), da As SqlDataAdapter
        Dim sSQL As String

        'CargaFacturasPagadas()---FOLIO_REFERENCIA_USUARIO no va
        sSQL = "SELECT D.CODIGO_CLIENTE,c.NOMBRE_CLIENTE,D.FECHA, D.FOLIO_REFERENCIA, D.NOMBRE_MEDIO_PAGO,D.NOMBRE_BANCO,TOTAL_VENTA,SALDO_VENTA, " & _
               "TOTAL_VENTA_DOLARES,SALDO_VENTA_DOLARES,CASE WHEN(TOTAL_DETALLE_DOLARES>0) THEN TOTAL_DETALLE_DOLARES ELSE TOTAL_DETALLE END PAGADO,0,0,D.FOLIO_REFERENCIA_USUARIO,0 ,0" & _
               "FROM VW_BANCOS_CXC_DETALLE D INNER JOIN CAT_CLIENTES C ON (D.CODIGO_CLIENTE=C.CODIGO_CLIENTE) " & _
               "WHERE FOLIO_BANCO='" & Me._FOLIO_BANCO & "' ORDER BY FECHA"

        Try
            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dTabla)

            da.Dispose()
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "ObtenerDetalle", ex)
        End Try
        ObtenerDetalle = dTabla
    End Function

    Public Function CargaVentasClienteConSaldo(ByVal CodigoCliente As String) As DataTable
        Dim dTabla As New DataTable("detalle"), da As SqlDataAdapter
        Dim sSQL As String = ("SELECT FOLIO_Cliente,FECHA,FOLIO_VENTA,CONCEPTO,TOTAL,SALDO,0 PAGAR,0 SELECCION, CODIGO_DOCUMENTO " & _
                              "FROM VENTA_GLOBAL WHERE CODIGO_Cliente='" & sReplace(CodigoCliente) & "' AND SALDO>0 and CODIGO_PLAZA=" & Plaza.CODIGO_PLAZA & " ORDER BY FECHA")
        Try
            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dTabla)
            da.Dispose()

        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "CargaVentasClienteConSaldo", ex)
        End Try
        CargaVentasClienteConSaldo = dTabla
    End Function

    Public Function CargaFacturaClienteConSaldo(ByVal CodigoCliente As String, ByVal sFolioVenta As String) As DataTable
        Dim dTabla As New DataTable("detalle"), da As SqlDataAdapter
        Dim sSQL As String
        ''"LEFT JOIN VW_CAT_PRODUCTOS_AGRICOLAS P ON(R.CODIGO_ARTICULO=P.CODIGO_ARTICULO) " & _
        '"LEFT JOIN CAT_ARTICULOS P ON(R.CODIGO_ARTICULO=P.CODIGO_ARTICULO) LEFT JOIN CAT_CULTIVOS C ON(P.CODIGO_CULTIVO=C.CODIGO_CULTIVO) " & _
        'sSQL = ("SELECT  G.FOLIO_VENTA,MAX(G.FECHA) FECHA,MAX(G.SALDO) SALDO,P.CODIGO_CULTIVO,MAX(P.NOMBRE_CULTIVO) CULTIVO, " & _
        sSQL = ("SELECT  G.FOLIO_VENTA,MAX(G.FECHA) FECHA,MAX(G.SALDO) SALDO,ISNULL(P.CODIGO_CULTIVO,'00')CODIGO_CULTIVO,MAX(P.NOMBRE_CULTIVO) CULTIVO, " & _
        "SUM(R.IMPORTE),'' DESCUENTO   " & _
        "FROM VENTA_GLOBAL G INNER JOIN VENTA_DETALLE R ON(G.FOLIO_VENTA=R.FOLIO_VENTA) " & _
        "LEFT JOIN VW_CAT_PRODUCTOS_AGRICOLAS P ON(R.CODIGO_ARTICULO=P.CODIGO_ARTICULO) " & _
        "INNER JOIN VW_SIS_CAT_DOCUMENTOS_EXTENDIDO D ON (G.CODIGO_DOCUMENTO=D.CODIGO_DOCUMENTO)" & _
        "WHERE G.SALDO>0 AND G.CODIGO_CLIENTE='" & sReplace(CodigoCliente) & "' AND G.FOLIO_VENTA='" & sReplace(sFolioVenta) & "'  AND D.AFECTA_CONTABILIDAD='1' and G.CODIGO_PLAZA=" & Plaza.CODIGO_PLAZA & " " & _
        "GROUP BY G.FOLIO_VENTA,P.CODIGO_CULTIVO ORDER BY G.FOLIO_VENTA ")

        Try
            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dTabla)

            da.Dispose()
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "CargaFacturaClienteConSaldo", ex)
        End Try
        CargaFacturaClienteConSaldo = dTabla

    End Function

    Public Function BusquedaVisual_FacturasClienteSaldo(Optional ByVal sCodigoCliente As String = "") As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de ventas del cliente."
        f.sCampo = "CODIGO_CLIENTE"
        f.sOrder = "FECHA "
        f.sTable = "VENTA_GLOBAL"
        '"INNER JOIN VENTA_DETALLE R ON(V.FOLIO_VENTA=R.FOLIO_VENTA)  " & _
        '"LEFT JOIN VW_CAT_PRODUCTOS_AGRICOLAS P ON(R.CODIGO_ARTICULO=P.CODIGO_ARTICULO) " & _
        f.sQl = "SELECT V.FOLIO_VENTA,FECHA,TOTAL,SALDO,V.CODIGO_DOCUMENTO FROM VENTA_GLOBAL V " & _
                "INNER JOIN VW_SIS_CAT_DOCUMENTOS_EXTENDIDO D ON (V.CODIGO_DOCUMENTO=D.CODIGO_DOCUMENTO)" & _
                "WHERE SALDO>0 AND CODIGO_CLIENTE='" & sCodigoCliente.ToString & "'  AND D.AFECTA_CONTABILIDAD='1' and V.CODIGO_PLAZA=" & Plaza.CODIGO_PLAZA & " AND "

        f.arrayWidthColumns = New Integer() {150, 140, 140, 140, 140}

        f.Inicia("")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "BusquedaVisual_FacturasClienteSaldo", ex)
        End Try
        Return Resultado
    End Function

    Public Function CargaFacturasPagadas(ByVal CodigoCliente As String, ByVal Folio As String) As DataTable
        Dim dTabla As New DataTable("detalle"), da As SqlDataAdapter
        Dim sSQL As String

        sSQL = ("SELECT FOLIO_Cliente,FECHA,FOLIO_VENTA,CONCEPTO,TOTAL,SALDO,0,FOLIO_CXC " & _
        "FROM VW_BANCOS_CXC_DETALLE WHERE CODIGO_Cliente='" & sReplace(CodigoCliente) & "' " & _
        "AND FOLIO_BANCO='" & sReplace(Folio) & "' ORDER BY FECHA")

        Try
            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dTabla)

            da.Dispose()
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "CargaFacturasPagadas", ex)
        End Try
        CargaFacturasPagadas = dTabla

    End Function

    Public Function GeneraFolio() As String
        Me.oDocumento.CODIGO_DOCUMENTO = Me._CODIGO_DOCUMENTO
        Me.oDocumento.GeneraFolio()
        GeneraFolio = Me.oDocumento.FOLIO
    End Function

    Public Function ExisteDocumento(ByVal sFolio As String) As Boolean
        Try
            Dim sql As New Class_find("SELECT 1 FROM BANCOS_GLOBAL WHERE FOLIO_BANCO='" & sReplace(sFolio) & "'")
            If sql.Result1.Length > 0 Then
                ExisteDocumento = True
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "ExisteDocumento", ex)
        End Try
    End Function

    Public Function ConsultarCXC(ByVal sFolio As String) As Boolean
        'CXC.TOTAL_PAGO,,FOLIO_REFERENCIA
        Dim sql As String = "SELECT  CXC.CXC_FOLIO_CXC,CXC.CXC_ESTATUS_CXC,CXC.CXC_CODIGO_DOCUMENTO,T.NOMBRE_TIPO_DOCUMENTO,CXC.CXC_TOTAL,CXC.CXC_CODIGO_CLIENTE,CXC.CXC_NOMBRE_CLIENTE," & _
                            "CXC.CXC_TOTAL,CXC.CXC_FOLIO_REFERENCIA,CXC.BAN_NOMBRE_USUARIO_GRABO,CXC.BAN_FOLIO_BANCO,BAN_FECHA,CXC.BAN_CONCEPTO  " & _
                            "FROM VW_BANCOS_GLOBAL_CON_CXC_GLOBAL CXC INNER JOIN SIS_TIPOS_DOCUMENTOS T ON (CXC.CXC_CODIGO_TIPO_DOCUMENTO=T.CODIGO_TIPO_DOCUMENTO)" & _
                            "WHERE CXC.CXC_FOLIO_CXC='" & sFolio & "' "

        Dim Conexion As New SqlConnection(Empresa_Sistema.conexion)
        Dim cmd As New SqlCommand(sql, Conexion)
        Dim dReader As SqlDataReader

        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Conexion.Open()
                dReader = .ExecuteReader()
                If dReader.Read Then
                    Me._FOLIO_CXC = CType(dReader("CXC_FOLIO_CXC"), String)
                    Me._ESTATUS_CXC = CType(dReader("CXC_ESTATUS_CXC"), String)
                    Me._FECHA = CType(dReader("BAN_FECHA"), Date)
                    Me._CODIGO_DOCUMENTO = CType(dReader("CXC_CODIGO_DOCUMENTO"), String)
                    Me._Nombre_Formato = CType(dReader("NOMBRE_TIPO_DOCUMENTO"), String)
                    Me._TOTAL = CType(dReader("CXC_TOTAL"), Double)
                    Me._CODIGO_Cliente = CType(dReader("CXC_CODIGO_CLIENTE"), String)
                    Me._NOMBRE_Cliente = CType(dReader("CXC_NOMBRE_CLIENTE"), String)
                    Me._FOLIO_BANCO = CType(dReader("BAN_FOLIO_BANCO"), String)
                    Me._FOLIO_REFERENCIA = "" & dReader("CXC_FOLIO_REFERENCIA").ToString
                    Me._CONCEPTO1 = CType(dReader("BAN_CONCEPTO"), String)
                    Me._NOMBRE_USUARIO_GRABO = CType(dReader("BAN_NOMBRE_USUARIO_GRABO"), String)

                    ConsultarCXC = True

                End If
                dReader.Close()
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "Consultar", ex)
            Finally
                Conexion.Close()
                cmd.Dispose()
            End Try
        End With
    End Function

    Public Function CancelaBancosCXC() As Boolean
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_BANCOS_CXC_CANCELA"

            sqlParametro = .Parameters.Add("@FOLIO_BANCO", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_BANCO
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO_CANCELO", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Usuario
            sqlParametro = .Parameters.Add("@FECHA_CANCELACION", SqlDbType.DateTime) : sqlParametro.Value = Me.FECHA_DE_CANCELACION

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                Me._FOLIO_POLIZA = Me._FOLIO_BANCO
                CancelaBancosCXC = True
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "CancelaBancosCXC", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With

    End Function

#End Region

End Class