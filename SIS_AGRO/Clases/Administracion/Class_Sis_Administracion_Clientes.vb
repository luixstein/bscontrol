Imports System.Data
Imports System.Data.SqlClient

Public Class Class_Sis_Administracion_Clientes

#Region "Campos"
    Private _TOTAL_VENTA As Double = 0

#Region "Campos de la tabla"
    Private _CodigoCliente As String
    Private _NombreCliente As String
    Private _DiasCarteraVentaAntigua As String
    Private _DiasCarteraVentaReciente As String
    Private _EmpresaVentaAntigua As String
    Private _EmpresaVentaReciente As String
    Private _FechaUltimoDeposito As String
    Private _FechaVentaAntigua As String
    Private _FechaVentaReciente As String
    Private _FolioVentaAntigua As String
    Private _FolioVentaReciente As String
    Private _ImporteAutorizado As String
    Private _ImporteUltimoDeposito As String
    Private _Plaza As String
    Private _Saldo As String
    Private _SaldoVencido As String
    Private _SaldoVentaAntigua As String
    Private _SaldoVentaReciente As String
    Private _DIAS As Integer
    Private _CONCEPTO As String
    Private _FACTOR_RIESGO_PORCENTAJE As Double
    Private _FACTOR_RIESGO_PESOS As Double
    Private _ULTIMA_ACTUALIZACION_LIMITE_CREDITO As String
    Private _LIMITE_CREDITO As String
    Private _CREDITO_RESTANTE As String
    Private _PLAZO As String
    Private _ULTIMO_SEGUIMIENTO As String
    Private _FECHA_ULTIMO_SEGUIMIENTO_CXC As String
    Private _CODIGO_ULTIMO_SEGUIMIENTO As String
    Private _STATUS_REVISADO As String
    Private _CODIGO_RESULTADO_ACUERDO_ULTIMO_SEGUIMIENTO_CXC As String
    Private _CODIGO_TIPO_ACUERDO_ULTIMO_SEGUIMIENTO_CXC As String
    Private _VENTA_AUTORIZADA_POR_REGLA_CXC As String
    Private _TIENE_VENTAS_CONTADO_VENCIDAS As String

    Private _PLAZO_EXTRA As String
    Private _DIAS_EXTRA_VENTA As String
    Private _DIAS_CARTERA As String

    Private _TIENE_CREDITO_SUFICIENTE As String

#End Region

#Region "Campos ligados a la tabla"
    Private _Existe As Boolean
#End Region

#Region "Campos públicos"

#End Region

#Region "Campos privados"

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
    Public Property CodigoCliente() As String
        Get
            Return Me._CodigoCliente
        End Get
        Set(ByVal Value As String)
            Me._CodigoCliente = Value
        End Set
    End Property

    Public Property NombreCliente() As String
        Get
            Return Me._NombreCliente
        End Get
        Set(ByVal Value As String)
            Me._NombreCliente = Value
        End Set
    End Property

    Public Property DiasCarteraVentaAntigua() As String
        Get
            Return Me._DiasCarteraVentaAntigua
        End Get
        Set(ByVal Value As String)
            Me._DiasCarteraVentaAntigua = Value
        End Set
    End Property

    Public Property DiasCarteraVentaReciente() As String
        Get
            Return Me._DiasCarteraVentaReciente
        End Get
        Set(ByVal Value As String)
            Me._DiasCarteraVentaReciente = Value
        End Set
    End Property

    Public Property EmpresaVentaAntigua() As String
        Get
            Return Me._EmpresaVentaAntigua
        End Get
        Set(ByVal Value As String)
            Me._EmpresaVentaAntigua = Value
        End Set
    End Property

    Public Property EmpresaVentaReciente() As String
        Get
            Return Me._EmpresaVentaReciente
        End Get
        Set(ByVal Value As String)
            Me._EmpresaVentaReciente = Value
        End Set
    End Property

    Public Property FechaUltimoDeposito() As String
        Get
            Return Me._FechaUltimoDeposito
        End Get
        Set(ByVal Value As String)
            Me._FechaUltimoDeposito = Value
        End Set
    End Property

    Public Property FechaVentaAntigua() As String
        Get
            Return Me._FechaVentaAntigua
        End Get
        Set(ByVal Value As String)
            Me._FechaVentaAntigua = Value
        End Set
    End Property

    Public Property FechaVentaReciente() As String
        Get
            Return Me._FechaVentaReciente
        End Get
        Set(ByVal Value As String)
            Me._FechaVentaReciente = Value
        End Set
    End Property

    Public Property FolioVentaAntigua() As String
        Get
            Return Me._FolioVentaAntigua
        End Get
        Set(ByVal Value As String)
            Me._FolioVentaAntigua = Value
        End Set
    End Property

    Public Property FolioVentaReciente() As String
        Get
            Return Me._FolioVentaReciente
        End Get
        Set(ByVal Value As String)
            Me._FolioVentaReciente = Value
        End Set
    End Property

    Public Property ImporteAutorizado() As String
        Get
            Return Me._ImporteAutorizado
        End Get
        Set(ByVal Value As String)
            Me._ImporteAutorizado = Value
        End Set
    End Property

    Public Property ImporteUltimoDeposito() As String
        Get
            Return Me._ImporteUltimoDeposito
        End Get
        Set(ByVal Value As String)
            Me._ImporteUltimoDeposito = Value
        End Set
    End Property

    Public Property Plaza() As String
        Get
            Return Me._Plaza
        End Get
        Set(ByVal Value As String)
            Me._Plaza = Value
        End Set
    End Property

    Public Property Saldo() As String
        Get
            Return Me._Saldo
        End Get
        Set(ByVal Value As String)
            Me._Saldo = Value
        End Set
    End Property

    Public Property SaldoVencido() As String
        Get
            Return Me._SaldoVencido
        End Get
        Set(ByVal Value As String)
            Me._SaldoVencido = Value
        End Set
    End Property

    Public Property SaldoVentaAntigua() As String
        Get
            Return Me._SaldoVentaAntigua
        End Get
        Set(ByVal Value As String)
            Me._SaldoVentaAntigua = Value
        End Set
    End Property

    Public Property SaldoVentaReciente() As String
        Get
            Return Me._SaldoVentaReciente
        End Get
        Set(ByVal Value As String)
            Me._SaldoVentaReciente = Value
        End Set
    End Property

    Public Property DIAS() As Integer
        Get
            Return Me._DIAS
        End Get
        Set(ByVal Value As Integer)
            Me._DIAS = Value
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

    Public Property FACTOR_RIESGO_PORCENTAJE() As Double
        Get
            Return Me._FACTOR_RIESGO_PORCENTAJE
        End Get
        Set(ByVal Value As Double)
            Me._FACTOR_RIESGO_PORCENTAJE = Value
        End Set
    End Property

    Public Property FACTOR_RIESGO_PESOS() As Double
        Get
            Return Me._FACTOR_RIESGO_PESOS
        End Get
        Set(ByVal Value As Double)
            Me._FACTOR_RIESGO_PESOS = Value
        End Set
    End Property

    Public Property ULTIMA_ACTUALIZACION_LIMITE_CREDITO() As String
        Get
            Return Me._ULTIMA_ACTUALIZACION_LIMITE_CREDITO
        End Get
        Set(ByVal Value As String)
            Me._ULTIMA_ACTUALIZACION_LIMITE_CREDITO = Value
        End Set
    End Property

    Public Property LIMITE_CREDITO() As String
        Get
            Return Me._LIMITE_CREDITO
        End Get
        Set(ByVal Value As String)
            Me._LIMITE_CREDITO = Value
        End Set
    End Property

    Public Property CREDITO_RESTANTE() As String
        Get
            Return Me._CREDITO_RESTANTE
        End Get
        Set(ByVal Value As String)
            Me._CREDITO_RESTANTE = Value
        End Set
    End Property

    Public Property PLAZO() As String
        Get
            Return Me._PLAZO
        End Get
        Set(ByVal Value As String)
            Me._PLAZO = Value
        End Set
    End Property

    Public Property ULTIMO_SEGUIMIENTO() As String
        Get
            Return Me._ULTIMO_SEGUIMIENTO
        End Get
        Set(ByVal Value As String)
            Me._ULTIMO_SEGUIMIENTO = Value
        End Set
    End Property

    Public Property FECHA_ULTIMO_SEGUIMIENTO_CXC() As String
        Get
            Return Me._FECHA_ULTIMO_SEGUIMIENTO_CXC
        End Get
        Set(ByVal Value As String)
            Me._FECHA_ULTIMO_SEGUIMIENTO_CXC = Value
        End Set
    End Property

    Public Property CODIGO_ULTIMO_SEGUIMIENTO() As String
        Get
            Return Me._CODIGO_ULTIMO_SEGUIMIENTO
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_ULTIMO_SEGUIMIENTO = Value
        End Set
    End Property

    Public Property STATUS_REVISADO() As String
        Get
            Return Me._STATUS_REVISADO
        End Get
        Set(ByVal Value As String)
            Me._STATUS_REVISADO = Value
        End Set
    End Property

    Public Property CODIGO_RESULTADO_ACUERDO_ULTIMO_SEGUIMIENTO_CXC() As String
        Get
            Return Me._CODIGO_RESULTADO_ACUERDO_ULTIMO_SEGUIMIENTO_CXC
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_RESULTADO_ACUERDO_ULTIMO_SEGUIMIENTO_CXC = Value
        End Set
    End Property

    Public Property CODIGO_TIPO_ACUERDO_ULTIMO_SEGUIMIENTO_CXC() As String
        Get
            Return Me._CODIGO_TIPO_ACUERDO_ULTIMO_SEGUIMIENTO_CXC
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_TIPO_ACUERDO_ULTIMO_SEGUIMIENTO_CXC = Value
        End Set
    End Property

    Public Property VENTA_AUTORIZADA_POR_REGLA_CXC() As String
        Get
            Return Me._VENTA_AUTORIZADA_POR_REGLA_CXC
        End Get
        Set(ByVal Value As String)
            Me._VENTA_AUTORIZADA_POR_REGLA_CXC = Value
        End Set
    End Property

    Public Property TIENE_VENTAS_CONTADO_VENCIDAS() As String
        Get
            Return Me._TIENE_VENTAS_CONTADO_VENCIDAS
        End Get
        Set(ByVal Value As String)
            Me._TIENE_VENTAS_CONTADO_VENCIDAS = Value
        End Set
    End Property

    Public Property PLAZO_EXTRA() As String
        Get
            Return Me._PLAZO_EXTRA
        End Get
        Set(ByVal Value As String)
            Me._PLAZO_EXTRA = Value
        End Set
    End Property

    Public Property DIAS_EXTRA_VENTA() As String
        Get
            Return Me._DIAS_EXTRA_VENTA
        End Get
        Set(ByVal Value As String)
            Me._DIAS_EXTRA_VENTA = Value
        End Set
    End Property

    Public Property DIAS_CARTERA() As String
        Get
            Return Me._DIAS_CARTERA
        End Get
        Set(ByVal Value As String)
            Me._DIAS_CARTERA = Value
        End Set
    End Property

    Public Property TIENE_CREDITO_SUFICIENTE() As String
        Get
            Return Me._TIENE_CREDITO_SUFICIENTE
        End Get
        Set(ByVal Value As String)
            Me._TIENE_CREDITO_SUFICIENTE = Value
        End Set
    End Property

    Public Property TOTAL_VENTA() As Double
        Get
            Return Me._TOTAL_VENTA
        End Get
        Set(ByVal Value As Double)
            Me._TOTAL_VENTA = Value
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

    Public ReadOnly Property Existe() As Boolean
        Get
            Return Me._Existe
        End Get
    End Property
#End Region

#End Region

#Region "Constructor y destructor"

    Public Sub New()
        Me._Nombre_Catalogo = "SIS_ADMINISTRACION_CLIENTES"
        Me._Nombre_Reporte = "RPT_SIS_ADMINISTRACION_CLIENTES.rpt"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "Select * FROM SIS_ADMINISTRACION_CLIENTES"
        Me._QueryOrder = " ORDER BY NOMBRE_CLIENTE"
    End Sub                                                         'Inicializa al objeto.

    Public Sub New(ByVal sCodigoCliente As String)
        Me.New()
        Me._CodigoCliente = sCodigoCliente
        Try
            If Me.Consultar = True Then
                Me._Existe = True
                'Else
                '    Throw New Exception("El PRODUCTOR no existe.")
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "New", ex)
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
    Public Function Consultar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim dReader As SqlDataReader
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CXC_UTILERIAS_OBTIENE_RESUMEN_CLIENTE"

            sqlParametro = .Parameters.Add("@CODIGO_CLIENTE", SqlDbType.NVarChar, 16) : sqlParametro.Value = Me._CodigoCliente
            sqlParametro = .Parameters.Add("@VENTA", SqlDbType.NVarChar, 80) : sqlParametro.Value = Me._TOTAL_VENTA
            sqlParametro = .Parameters.Add("@COSTO", SqlDbType.Char, 1) : sqlParametro.Value = 0
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read = True Then
                    Me._CodigoCliente = "" & dReader("CODIGO_CLIENTE")
                    Me._NombreCliente = "" & dReader("NOMBRE_CLIENTE")
                    Me._DiasCarteraVentaAntigua = "" & dReader("DIAS_CARTERA")
                    Me._DiasCarteraVentaReciente = "" & dReader("DIAS_VENTA_RECIENTE")
                    Me._EmpresaVentaAntigua = "" & dReader("EMPRESA_VENTA_ANTIGUA")
                    Me._EmpresaVentaReciente = "" & dReader("EMPRESA_VENTA_RECIENTE")
                    Me._FechaUltimoDeposito = "" & dReader("FECHA_ULTIMO_DEPOSITO")
                    Me._FechaVentaAntigua = "" & dReader("FECHA_VENTA_ANTIGUA")
                    Me._FechaVentaReciente = "" & dReader("FECHA_VENTA_RECIENTE")
                    Me._FolioVentaAntigua = "" & dReader("FOLIO_VENTA_ANTIGUA")
                    Me._FolioVentaReciente = "" & dReader("FOLIO_VENTA_RECIENTE")
                    Me._ImporteAutorizado = "" & dReader("IMPORTE_AUTORIZADO_POR_REGLAS_CXC")
                    Me._ImporteUltimoDeposito = "" & dReader("IMPORTE_ULTIMO_DEPOSITO")
                    Me._Plaza = ""
                    Me._Saldo = "" & dReader("SALDO")
                    Me._SaldoVencido = "" & dReader("SALDO_VENCIDO")
                    Me._SaldoVentaAntigua = "" & dReader("SALDO_VENTA_ANTIGUA")
                    Me._SaldoVentaReciente = "" & dReader("SALDO_VENTA_RECIENTE")
                    Me._FACTOR_RIESGO_PORCENTAJE = "" & dReader("FACTOR_RIESGO_PORCENTAJE")
                    Me._FACTOR_RIESGO_PESOS = "" & dReader("FACTOR_RIESGO_PESOS")
                    Me._ULTIMA_ACTUALIZACION_LIMITE_CREDITO = "" & dReader("ULTIMA_ACTUALIZACION_LIMITE_CREDITO")
                    Me._LIMITE_CREDITO = "" & dReader("LIMITE_CREDITO")
                    Me._CREDITO_RESTANTE = "" & dReader("CREDITO_RESTANTE")
                    Me._PLAZO = "" & dReader("PLAZO")
                    Me._ULTIMO_SEGUIMIENTO = "" & dReader("ULTIMO_SEGUIMIENTO_CXC")
                    Me._FECHA_ULTIMO_SEGUIMIENTO_CXC = "" & dReader("FECHA_ULTIMO_SEGUIMIENTO_CXC")
                    Me._CODIGO_ULTIMO_SEGUIMIENTO = "" & dReader("CODIGO_ULTIMO_SEGUIMIENTO")
                    Me._STATUS_REVISADO = "" & dReader("STATUS_REVISADO")
                    Me._CODIGO_RESULTADO_ACUERDO_ULTIMO_SEGUIMIENTO_CXC = "" & dReader("CODIGO_RESULTADO_ACUERDO_ULTIMO_SEGUIMIENTO_CXC")
                    Me._CODIGO_TIPO_ACUERDO_ULTIMO_SEGUIMIENTO_CXC = "" & dReader("CODIGO_TIPO_ACUERDO_ULTIMO_SEGUIMIENTO_CXC")
                    Me._VENTA_AUTORIZADA_POR_REGLA_CXC = "" & dReader("VENTA_AUTORIZADA_POR_REGLA_CXC")
                    Me._TIENE_VENTAS_CONTADO_VENCIDAS = "" & dReader("TIENE_VENTAS_CONTADO_VENCIDAS")

                    Me._PLAZO_EXTRA = "" & dReader("PLAZO_EXTRA")
                    Me._DIAS_EXTRA_VENTA = "" & dReader("DIAS_EXTRA_VENTA")

                    Me._DIAS_CARTERA = "" & dReader("DIAS_CARTERA")
                    Me._TIENE_CREDITO_SUFICIENTE = "" & dReader("TIENE_CREDITO_SUFICIENTE")

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
    End Function        'Consulta un elemento del catálogo.

    Public Function InsertarReglaCXC() As Boolean
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_SIS_ADMIN_CLIENTES_AGREGA_REGLA_CXC"

            sqlParametro = .Parameters.Add("@CODIGO_CLIENTE", SqlDbType.NVarChar, 16) : sqlParametro.Value = Me._CodigoCliente
            sqlParametro = .Parameters.Add("@DIAS", SqlDbType.SmallInt) : sqlParametro.Value = Me._DIAS
            sqlParametro = .Parameters.Add("@CONCEPTO", SqlDbType.Char, 300) : sqlParametro.Value = Me._CONCEPTO
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO", SqlDbType.NVarChar, 2) : sqlParametro.Value = Usuario.Codigo_Usuario
            sqlParametro = .Parameters.Add("@DIAS_CARTERA", SqlDbType.SmallInt) : sqlParametro.Value = Me._DiasCarteraVentaAntigua
            sqlParametro = .Parameters.Add("@FACTOR_RIESGO_PORCENTAJE", SqlDbType.Decimal) : sqlParametro.Value = Me._FACTOR_RIESGO_PORCENTAJE
            sqlParametro = .Parameters.Add("@FACTOR_RIESGO_PESOS", SqlDbType.Decimal) : sqlParametro.Value = Me._FACTOR_RIESGO_PESOS
            sqlParametro = .Parameters.Add("@IMPORTE_AUTORIZADO", SqlDbType.Decimal) : sqlParametro.Value = Me._ImporteAutorizado

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                InsertarReglaCXC = True
            Catch ex As Exception
                HandleError(Me.Nombre_Catalogo, "InsertarReglaCXC", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
    End Function

    Public Function ActualizaEstatusSeguimiento(ByVal iIdSeguimiento As Integer, ByVal iCodigoResultadoAcuerdo As Integer) As Boolean
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CXC_LIBERA_SEGUIMIENTO_CXC"

            sqlParametro = .Parameters.Add("@IDSEGUIMIENTO", SqlDbType.Int) : sqlParametro.Value = iIdSeguimiento
            sqlParametro = .Parameters.Add("@CODIGO_RESULTADO_ACUERDO", SqlDbType.SmallInt) : sqlParametro.Value = iCodigoResultadoAcuerdo

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                ActualizaEstatusSeguimiento = True
            Catch ex As Exception
                HandleError(Me.Nombre_Catalogo, "ActualizaEstatusSeguimiento", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
    End Function

    Public Function ActualizaTipoAcuerdoSeguimiento(ByVal iIdSeguimiento As Integer, ByVal iCodigoTipoAcuerdo As Integer) As Boolean
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CXC_ACTUALIZA_TIPO_ACUERDO_SEGUIMIENTO"

            sqlParametro = .Parameters.Add("@IDSEGUIMIENTO", SqlDbType.Int) : sqlParametro.Value = iIdSeguimiento
            sqlParametro = .Parameters.Add("@CODIGO_TIPO_ACUERDO", SqlDbType.SmallInt) : sqlParametro.Value = iCodigoTipoAcuerdo

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                ActualizaTipoAcuerdoSeguimiento = True
            Catch ex As Exception
                HandleError(Me.Nombre_Catalogo, "ActualizaEstatusSeguimiento", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
    End Function

    Public Function CancelarReglaCXC(ByVal iIdRegla As Integer) As Boolean
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_SIS_ADMIN_CLIENTES_CANCELA_REGLA_CXC"

            sqlParametro = .Parameters.Add("@ID_REGLA", SqlDbType.Int) : sqlParametro.Value = iIdRegla
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO_CANCELO", SqlDbType.NVarChar, 2) : sqlParametro.Value = Usuario.Codigo_Usuario

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                CancelarReglaCXC = True
            Catch ex As Exception
                HandleError(Me.Nombre_Catalogo, "CancelarReglaCXC", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
    End Function

    Public Function ObtenerReglasCXC(Optional ByVal bReglasActivas As Boolean = True) As DataTable
        Dim dTabla As New DataTable("detalle"), da As SqlDataAdapter
        Dim sSQL As String 'A.PRECIO

        sSQL = "SELECT C.ID_REGLA,C.ESTATUS,C.FECHA_CREACION,C.IMPORTE_AUTORIZADO,C.IMPORTE_RESTANTE " &
               "FROM  DBO.SIS_REGLAS_CXC C   " &
               "WHERE C.CODIGO_CLIENTE='" & Me._CodigoCliente.ToString & "' AND IMPORTE_AUTORIZADO>0  "

        If bReglasActivas = True Then
            sSQL = sSQL & " AND C.ESTATUS='A' AND C.IMPORTE_RESTANTE>0"
        End If

        sSQL = sSQL & "ORDER BY C.ID_REGLA"

        Try
            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dTabla)
            da.Dispose()
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "ObtenerReglasCXC", ex)
        End Try
        ObtenerReglasCXC = dTabla
    End Function

    Public Function ActualizaPlazo(Optional ByVal bRecaulcular As Boolean = True, Optional ByVal bRecaulcularFechas As Boolean = False, Optional ByVal dFechaInicial As String = "", Optional ByVal dFechaFinal As String = "") As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_SIS_ADMIN_CLIENTES_ACTUALIZA_DIAS_PLAZO"

            sqlParametro = .Parameters.Add("@CODIGO_CLIENTE", SqlDbType.NVarChar, 8) : sqlParametro.Value = Me._CodigoCliente
            sqlParametro = .Parameters.Add("@DIAS_PLAZO", SqlDbType.SmallInt) : sqlParametro.Value = Me._PLAZO
            sqlParametro = .Parameters.Add("@RECALCULAR_VENCIMIENTOS", SqlDbType.Char, 1) : sqlParametro.Value = Convert.ToInt32(bRecaulcular)
            sqlParametro = .Parameters.Add("@RECALCULAR_VENCIMIENTOS_USANDO_RANGO_FECHAS", SqlDbType.NVarChar, 2) : sqlParametro.Value = Convert.ToInt32(bRecaulcularFechas)
            sqlParametro = .Parameters.Add("@FECHA_INICIAL_RECALCULAR_VENCIMIENTOS", SqlDbType.NVarChar, 20) : sqlParametro.Value = dFechaInicial
            sqlParametro = .Parameters.Add("@FECHA_FINAL_RECALCULAR_VENCIMIENTOS", SqlDbType.NVarChar, 20) : sqlParametro.Value = dFechaFinal
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO", SqlDbType.Decimal) : sqlParametro.Value = Usuario.Codigo_Usuario

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me.Nombre_Catalogo, "ActualizaPlazo", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Function ConvertirContadoACredito(Optional ByVal sFolio As String = "") As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_SIS_ADMIN_CLIENTES_CONVIERTE_VENTA_CONTADO_A_CREDITO"

            sqlParametro = .Parameters.Add("@CODIGO_CLIENTE", SqlDbType.NVarChar, 16) : sqlParametro.Value = Me._CodigoCliente
            sqlParametro = .Parameters.Add("@FOLIO", SqlDbType.NVarChar, 15) : sqlParametro.Value = sFolio
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO", SqlDbType.NVarChar, 2) : sqlParametro.Value = Usuario.Codigo_Usuario

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me.Nombre_Catalogo, "ConvertirContadoACredito", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Function ConvertirCreditoAContado(Optional ByVal sFolio As String = "") As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_SIS_ADMIN_CLIENTES_CONVIERTE_VENTA_CREDITO_A_CONTADO"

            sqlParametro = .Parameters.Add("@CODIGO_CLIENTE", SqlDbType.NVarChar, 16) : sqlParametro.Value = Me._CodigoCliente
            sqlParametro = .Parameters.Add("@FOLIO", SqlDbType.NVarChar, 15) : sqlParametro.Value = sFolio
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO", SqlDbType.NVarChar, 2) : sqlParametro.Value = Usuario.Codigo_Usuario

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me.Nombre_Catalogo, "ConvertirContadoACredito", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Function ObservacionesNegociaciones(ByVal sObservaciones As String, ByVal bAccion As Boolean, ByVal iIdObservacion As Integer) As String
        Dim sResultado As String = ""
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        ObservacionesNegociaciones = ""
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_NEGOCIACIONES_CXC_GRABAR_OBSERVACIONES"

            sqlParametro = .Parameters.Add("@ACCION", SqlDbType.Char, 1) : sqlParametro.Value = Convert.ToInt32(bAccion)
            sqlParametro = .Parameters.Add("@ID_OBSERVACION_CLIENTE", SqlDbType.SmallInt, 1) : sqlParametro.Direction = ParameterDirection.InputOutput : sqlParametro.Value = iIdObservacion
            sqlParametro = .Parameters.Add("@CODIGO_CLIENTE", SqlDbType.NVarChar, 16) : sqlParametro.Value = Me._CodigoCliente
            sqlParametro = .Parameters.Add("@OBSERVACIONES", SqlDbType.NVarChar, 1000) : sqlParametro.Value = sObservaciones

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()

                sResultado = "" & .Parameters("@ID_OBSERVACION_CLIENTE").Value.ToString

            Catch ex As Exception
                HandleError(Me.Nombre_Catalogo, "ObservacionesNegociaciones", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return sResultado
    End Function
#End Region

#Region "Eventos de objetos"


#Region "Eventos de la lista de elementos"

#End Region

#Region " Eventos de TxtFiltro"

#End Region

#Region "Eventos Genericos"

#End Region


#Region "Keydown específicos"


#End Region

#Region "Validating específicos"

#End Region



#End Region
End Class
