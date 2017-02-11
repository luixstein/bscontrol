Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Management

Public Class Class_Conciliacion_Bancaria

#Region "Campos privados"
    Private _Conexion As SqlConnection
    Private _QuerySelect As String
    Private _QueryOrder As String

    Private _Existe As Boolean 'lectura

    Private _ID_GLOBAL_CONCILIACION As Integer
    Private _ID_CUENTA_BANCARIA As Integer
    Private _NOMBRE_CUENTA_BANCARIA As String 'lectura
    Private _ESTATUS As String
    Private _ESTATUS_COMPLETO As String 'lectura
    Private _FECHA_1_EDO_CUENTA As Date
    Private _FECHA_2_EDO_CUENTA As Date
    Private _FECHA_1_AUX_MAYOR As Date
    Private _FECHA_2_AUX_MAYOR As Date
    Private _FECHA_ACTUALIZACION As Date 'lectura
    Private _ID_EJERCICIO As Integer 'lectura
    Private _CODIGO_USUARIO_GRABO As Integer
    Private _NOMBRE_USUARIO_GRABO As String
    Private _ID_CENTRO As Integer
    Private _NOMBRE_ARCHIVO_IMPORTADO As String
    Private _CODIGO_USUARIO_FINALIZO As Integer
    Private _NOMBRE_USUARIO_FINALIZO As String
    Private _FECHA_FINALIZO As Date 'lectura
    Private _CODIGO_USUARIO_CANCELO As Integer
    Private _NOMBRE_USUARIO_CANCELO As String
    Private _FECHA_CANCELO As Date 'lectura
    Private _dTablaEstadoCuentaImportado As DataTable

    Private _CoincidenciasEncontradas As Integer = 0
    Private _DuracionSegundosBusquedaCoincidencias As Integer = 0

    Public Enum FiltroCoincidencias
        Todas
        DiferenciasImporte
        DiferenciasFecha
    End Enum
#End Region

#Region "Propiedades"
    Public ReadOnly Property Nombre_Clase() As String
        Get
            Return "Class_Conciliacion_Bancaria"
        End Get
    End Property

    Public ReadOnly Property Existe() As Boolean
        Get
            Return Me._Existe
        End Get
    End Property

    Public ReadOnly Property ID_GLOBAL_CONCILIACION() As Integer
        Get
            Return Me._ID_GLOBAL_CONCILIACION
        End Get
    End Property

    Public Property ID_CUENTA_BANCARIA() As Integer
        Get
            Return Me._ID_CUENTA_BANCARIA
        End Get
        Set(ByVal Value As Integer)
            Me._ID_CUENTA_BANCARIA = Value
        End Set
    End Property

    Public ReadOnly Property NOMBRE_CUENTA_BANCARIA() As String
        Get
            Return Me._NOMBRE_CUENTA_BANCARIA
        End Get
    End Property

    Public Property ESTATUS() As String
        Get
            Return Me._ESTATUS
        End Get
        Set(ByVal Value As String)
            Me._ESTATUS = Value
        End Set
    End Property

    Public ReadOnly Property ESTATUS_COMPLETO() As String
        Get
            Return Me._ESTATUS_COMPLETO
        End Get
    End Property

    Public Property FECHA_1_EDO_CUENTA() As Date
        Get
            Return Me._FECHA_1_EDO_CUENTA
        End Get
        Set(ByVal Value As Date)
            Me._FECHA_1_EDO_CUENTA = Value
        End Set
    End Property

    Public Property FECHA_2_EDO_CUENTA() As Date
        Get
            Return Me._FECHA_2_EDO_CUENTA
        End Get
        Set(ByVal Value As Date)
            Me._FECHA_2_EDO_CUENTA = Value
        End Set
    End Property

    Public Property FECHA_1_AUX_MAYOR() As Date
        Get
            Return Me._FECHA_1_AUX_MAYOR
        End Get
        Set(ByVal Value As Date)
            Me._FECHA_1_AUX_MAYOR = Value
        End Set
    End Property

    Public Property FECHA_2_AUX_MAYOR() As Date
        Get
            Return Me._FECHA_2_AUX_MAYOR
        End Get
        Set(ByVal Value As Date)
            Me._FECHA_2_AUX_MAYOR = Value
        End Set
    End Property

    Public ReadOnly Property FECHA_ACTUALIZACION() As Date
        Get
            Return Me._FECHA_ACTUALIZACION
        End Get
    End Property

    Public ReadOnly Property ID_EJERCICIO() As Integer
        Get
            Return Me._ID_EJERCICIO
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

    Public Property ID_CENTRO() As Integer
        Get
            Return Me._ID_CENTRO
        End Get
        Set(ByVal Value As Integer)
            Me._ID_CENTRO = Value
        End Set
    End Property

    Public Property NOMBRE_ARCHIVO_IMPORTADO() As String
        Get
            Return Me._NOMBRE_ARCHIVO_IMPORTADO
        End Get
        Set(ByVal Value As String)
            Me._NOMBRE_ARCHIVO_IMPORTADO = Value
        End Set
    End Property

    Public Property CODIGO_USUARIO_FINALIZO() As Integer
        Get
            Return Me._CODIGO_USUARIO_FINALIZO
        End Get
        Set(ByVal Value As Integer)
            Me._CODIGO_USUARIO_FINALIZO = Value
        End Set
    End Property

    Public ReadOnly Property NOMBRE_USUARIO_FINALIZO() As String
        Get
            Return Me._NOMBRE_USUARIO_FINALIZO
        End Get
    End Property

    Public ReadOnly Property FECHA_FINALIZO() As Date
        Get
            Return Me._FECHA_FINALIZO
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

    Public ReadOnly Property FECHA_CANCELO() As Date
        Get
            Return Me._FECHA_CANCELO
        End Get
    End Property

    Public WriteOnly Property dTablaEstadoCuentaImportado() As DataTable
        Set(ByVal value As DataTable)
            Me._dTablaEstadoCuentaImportado = value
        End Set
    End Property

    Public ReadOnly Property CoincidenciasEncontradas() As Integer
        Get
            Return Me._CoincidenciasEncontradas
        End Get
    End Property

    Public ReadOnly Property DuracionSegundosBusquedaCoincidencias() As Integer
        Get
            Return Me._DuracionSegundosBusquedaCoincidencias
        End Get
    End Property
#End Region

#Region "Métodos"
    Public Sub New()
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "SELECT G.ID_GLOBAL_CONCILIACION,G.ID_CUENTA_BANCARIA,B.NOMBRE_CUENTA_BANCARIA,G.ESTATUS,ST.ESTATUS_DESCRIPCION,ST.ESTATUS_COMPLETO," & _
        "G.FECHA_1_EDO_CUENTA,G.FECHA_2_EDO_CUENTA,G.FECHA_1_AUX_MAYOR,G.FECHA_2_AUX_MAYOR,G.FECHA_ACTUALIZACION,G.ID_EJERCICIO," & _
        "G.CODIGO_USUARIO_GRABO,U1.NOMBRE_USUARIO NOMBRE_USUARIO_GRABO,G.ID_CENTRO,G.NOMBRE_ARCHIVO_IMPORTADO,G.CODIGO_USUARIO_FINALIZO," & _
        "U2.NOMBRE_USUARIO NOMBRE_USUARIO_FINALIZO,G.FECHA_FINALIZO," & _
        "G.CODIGO_USUARIO_CANCELO,U3.NOMBRE_USUARIO NOMBRE_USUARIO_CANCELO,G.FECHA_CANCELO " & _
        "FROM CONCILIACIONES_BANCARIAS_GLOBAL G " & _
        "INNER JOIN CAT_CUENTAS_BANCARIAS B ON(G.ID_CUENTA_BANCARIA=B.ID_CUENTA_BANCARIA) " & _
        "INNER JOIN SIS_USUARIOS U1 ON(G.CODIGO_USUARIO_GRABO=U1.CODIGO_USUARIO) " & _
        "LEFT JOIN SIS_USUARIOS U2 ON(G.CODIGO_USUARIO_FINALIZO=U2.CODIGO_USUARIO) " & _
        "LEFT JOIN SIS_USUARIOS U3 ON(G.CODIGO_USUARIO_CANCELO=U3.CODIGO_USUARIO) " & _
        "INNER JOIN CONCILIACIONES_BANCARIAS_CATALOGO_ESTATUS ST ON(G.ESTATUS=ST.ESTATUS) "
        Me._QueryOrder = ""
        Me._ESTATUS = "N"
        Me._ESTATUS_COMPLETO = "N - NUEVA"
    End Sub

    Public Sub New(ByVal IDGlobalConciliacion As Integer)
        Me.New()
        Me._ID_GLOBAL_CONCILIACION = IDGlobalConciliacion
        Try
            If Me.Consultar = True Then
                Me._Existe = True
            Else
                Throw New Exception("La conciliación no existe.")
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "New", ex)
        End Try
    End Sub

    Public Function Consultar() As Boolean
        Dim cmd As New SqlCommand(Me._QuerySelect & " WHERE G.ID_GLOBAL_CONCILIACION=" & Me._ID_GLOBAL_CONCILIACION, Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._ID_GLOBAL_CONCILIACION = "" & dReader("ID_GLOBAL_CONCILIACION").ToString
                    Me._ID_CUENTA_BANCARIA = "" & dReader("ID_CUENTA_BANCARIA").ToString
                    Me._NOMBRE_CUENTA_BANCARIA = "" & dReader("NOMBRE_CUENTA_BANCARIA").ToString
                    Me._ESTATUS = "" & dReader("ESTATUS").ToString
                    Me._ESTATUS_COMPLETO = "" & dReader("ESTATUS_COMPLETO").ToString
                    Me._FECHA_1_EDO_CUENTA = CDate(dReader("FECHA_1_EDO_CUENTA").ToString)
                    Me._FECHA_2_EDO_CUENTA = CDate(dReader("FECHA_2_EDO_CUENTA").ToString)
                    Me._FECHA_1_AUX_MAYOR = CDate(dReader("FECHA_1_AUX_MAYOR").ToString)
                    Me._FECHA_2_AUX_MAYOR = CDate(dReader("FECHA_2_AUX_MAYOR").ToString)
                    Me._FECHA_ACTUALIZACION = CDate(dReader("FECHA_ACTUALIZACION").ToString)
                    Me._ID_EJERCICIO = "" & dReader("ID_EJERCICIO").ToString
                    Me._CODIGO_USUARIO_GRABO = "" & dReader("CODIGO_USUARIO_GRABO").ToString
                    Me._NOMBRE_USUARIO_GRABO = "" & dReader("NOMBRE_USUARIO_GRABO").ToString
                    Me._ID_CENTRO = "" & dReader("ID_CENTRO").ToString
                    Me._NOMBRE_ARCHIVO_IMPORTADO = "" & dReader("NOMBRE_ARCHIVO_IMPORTADO").ToString
                    Me._CODIGO_USUARIO_FINALIZO = CInt("0" & dReader("CODIGO_USUARIO_FINALIZO").ToString)
                    Me._NOMBRE_USUARIO_FINALIZO = "" & dReader("NOMBRE_USUARIO_FINALIZO").ToString

                    If IsDBNull(dReader("FECHA_FINALIZO")) = False Then
                        Me._FECHA_FINALIZO = CDate(dReader("FECHA_FINALIZO").ToString)
                    End If

                    Me._CODIGO_USUARIO_CANCELO = CInt("0" & dReader("CODIGO_USUARIO_CANCELO").ToString)
                    Me._NOMBRE_USUARIO_CANCELO = "" & dReader("NOMBRE_USUARIO_CANCELO").ToString

                    If IsDBNull(dReader("FECHA_CANCELO")) = False Then
                        Me._FECHA_CANCELO = CDate(dReader("FECHA_CANCELO").ToString)
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

    Public Function Grabar() As Boolean
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CONCILIACIONES_BANCARIAS_GRABA_GLOBAL"

            sqlParametro = .Parameters.Add("@ID_GLOBAL_CONCILIACION", SqlDbType.Int) : sqlParametro.Value = Me._ID_GLOBAL_CONCILIACION : sqlParametro.Direction = ParameterDirection.Output
            sqlParametro = .Parameters.Add("@ID_CUENTA_BANCARIA", SqlDbType.SmallInt) : sqlParametro.Value = Me._ID_CUENTA_BANCARIA
            sqlParametro = .Parameters.Add("@FECHA_1_EDO_CUENTA", SqlDbType.DateTime) : sqlParametro.Value = Me._FECHA_1_EDO_CUENTA
            sqlParametro = .Parameters.Add("@FECHA_2_EDO_CUENTA", SqlDbType.DateTime) : sqlParametro.Value = Format(Me._FECHA_2_EDO_CUENTA, "yyyy-MM-dd 23:59:00") 'el formato para un parametro de sql asi es yyyyMMdd
            sqlParametro = .Parameters.Add("@FECHA_1_AUX_MAYOR", SqlDbType.DateTime) : sqlParametro.Value = Me._FECHA_1_AUX_MAYOR
            sqlParametro = .Parameters.Add("@FECHA_2_AUX_MAYOR", SqlDbType.DateTime) : sqlParametro.Value = Format(Me._FECHA_2_AUX_MAYOR, "yyyy-MM-dd 23:59:00")
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO_GRABO", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_USUARIO_GRABO
            sqlParametro = .Parameters.Add("@NOMBRE_ARCHIVO_IMPORTADO", SqlDbType.NVarChar, 255) : sqlParametro.Value = Me._NOMBRE_ARCHIVO_IMPORTADO
            sqlParametro = .Parameters.Add("@ID_CENTRO", SqlDbType.SmallInt) : sqlParametro.Value = Me._ID_CENTRO

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()

                Me._ID_GLOBAL_CONCILIACION = CInt(cmd.Parameters("@ID_GLOBAL_CONCILIACION").Value)

                'Graba detalle.
                If GrabarEstadoCuentaImportado() = True AndAlso GrabarAuxiliarMayor() = True Then
                    Grabar = True
                End If
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "Grabar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
    End Function

    Public Function GrabarEstadoCuentaImportado() As Boolean
        Dim dRow As DataRow
        Dim cmd As SqlCommand
        Dim sqlParametro As SqlParameter
        Try
            If Me._Conexion.State = ConnectionState.Closed Then
                Me._Conexion.Open()
            End If
            For Each dRow In Me._dTablaEstadoCuentaImportado.Rows
                cmd = New SqlCommand
                With cmd
                    .Connection = Me._Conexion
                    .CommandTimeout = 0
                    .CommandType = CommandType.StoredProcedure
                    .CommandText = "MP_CONCILIACIONES_BANCARIAS_GRABA_DETALLE_ESTADO_CUENTA"

                    sqlParametro = .Parameters.Add("@ID_GLOBAL_CONCILIACION", SqlDbType.Int) : sqlParametro.Value = Me._ID_GLOBAL_CONCILIACION
                    sqlParametro = .Parameters.Add("@ID_DETALLE_EDO_CUENTA", SqlDbType.Int) : sqlParametro.Value = 0
                    sqlParametro = .Parameters.Add("@FECHA", SqlDbType.DateTime) : sqlParametro.Value = dRow("FECHA")
                    sqlParametro = .Parameters.Add("@CONCEPTO", SqlDbType.NVarChar, 120) : sqlParametro.Value = dRow("CONCEPTO")
                    sqlParametro = .Parameters.Add("@CARGO", SqlDbType.Decimal) : sqlParametro.Value = dRow("CARGO")
                    sqlParametro = .Parameters.Add("@ABONO", SqlDbType.Decimal) : sqlParametro.Value = dRow("ABONO")
                    sqlParametro = .Parameters.Add("@SALDO", SqlDbType.Decimal) : sqlParametro.Value = dRow("SALDO")

                    .ExecuteNonQuery()
                End With
            Next
            GrabarEstadoCuentaImportado = True
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "GrabarEstadoCuentaImportado", ex)
        Finally
            Me._Conexion.Close()
            sqlParametro = Nothing
        End Try
    End Function

    Public Function GrabarAuxiliarMayor() As Boolean
        Dim cmd As SqlCommand
        Dim sqlParametro As SqlParameter
        Try
            If Me._Conexion.State = ConnectionState.Closed Then
                Me._Conexion.Open()
            End If

            cmd = New SqlCommand
            With cmd
                .Connection = Me._Conexion
                .CommandTimeout = 0
                .CommandType = CommandType.StoredProcedure
                .CommandText = "MP_CONCILIACIONES_BANCARIAS_GRABA_DETALLE_AUXILIAR_MAYOR"

                sqlParametro = .Parameters.Add("@ID_GLOBAL_CONCILIACION", SqlDbType.Int) : sqlParametro.Value = Me._ID_GLOBAL_CONCILIACION

                .ExecuteNonQuery()
            End With
            GrabarAuxiliarMayor = True
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "GrabarAuxiliarMayor", ex)
        Finally
            Me._Conexion.Close()
        End Try
    End Function

    Public Function Cancelar() As Boolean
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CONCILIACIONES_BANCARIAS_CANCELA"

            sqlParametro = .Parameters.Add("@ID_GLOBAL_CONCILIACION", SqlDbType.Int) : sqlParametro.Value = Me._ID_GLOBAL_CONCILIACION
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO_CANCELO", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_USUARIO_CANCELO

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()

                Cancelar = True
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "Cancelar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
    End Function

    Public Function EstadoCuentaImportadoCompleto() As DataTable
        Dim dTabla As New DataTable("EstadoCuentaImportado"), dA As SqlDataAdapter
        Try
            dA = New SqlDataAdapter("SELECT E.ID_DETALLE_EDO_CUENTA ID,DBO.FN_FORMAT_FECHA_CORTO(E.FECHA) FECHA,E.CONCEPTO,E.CARGO,E.ABONO,E.SALDO " & _
                                    "FROM CONCILIACIONES_BANCARIAS_DETALLE_ESTADO_CUENTA_IMPORTADO E " & _
                                    "WHERE E.ID_GLOBAL_CONCILIACION=" & Me._ID_GLOBAL_CONCILIACION.ToString & _
                                    "ORDER BY E.ID_DETALLE_EDO_CUENTA", Me._Conexion)
            dA.Fill(dTabla)
            dA.Dispose()
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "EstadoCuentaImportadoCompleto", ex)
        End Try
        EstadoCuentaImportadoCompleto = dTabla
    End Function

    Public Function EstadoCuentaPendiente(ByVal dtFechaCorte As Date, ByVal dImporte1 As Double, ByVal dImporte2 As Double) As DataTable
        Dim dTabla As New DataTable("EstadoCuentaImportado"), dA As SqlDataAdapter
        Dim sSQL As String, sSQL2 As String = ""

        sSQL = "SELECT E.ID_DETALLE_EDO_CUENTA ID,DBO.FN_FORMAT_FECHA_CORTO(E.FECHA) FECHA,E.CONCEPTO,E.IMPORTE " & _
                                    "FROM CONCILIACIONES_BANCARIAS_DETALLE_ESTADO_CUENTA_IMPORTADO E " & _
                                    "WHERE E.ID_GLOBAL_CONCILIACION=" & Me._ID_GLOBAL_CONCILIACION.ToString & " " & _
                                    "AND E.ID_DETALLE_EDO_CUENTA NOT IN" & _
"(SELECT C.ID_DETALLE_EDO_CUENTA FROM CONCILIACIONES_BANCARIAS_DETALLE_COINCIDENCIAS C WHERE C.ID_GLOBAL_CONCILIACION=" & Me._ID_GLOBAL_CONCILIACION.ToString & ") "

        sSQL2 = " AND E.FECHA<='" & Format(dtFechaCorte, "yyyy/dd/MM") & " 23:59:00'"

        If dImporte1 <> 0 Or dImporte2 <> 0 Then
            sSQL2 = sSQL2 & " AND ABS(E.IMPORTE) BETWEEN " & dImporte1.ToString & " AND " & dImporte2.ToString & " "
        End If

        sSQL = sSQL & sSQL2 & " ORDER BY E.ID_DETALLE_EDO_CUENTA"

        Try
            dA = New SqlDataAdapter(sSQL, Me._Conexion)
            dA.Fill(dTabla)
            dA.Dispose()
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "EstadoCuentaPendiente", ex)
        End Try
        EstadoCuentaPendiente = dTabla
    End Function

    Public Function AuxiliarMayorPendiente(ByVal dtFechaCorte As Date, ByVal dImporte1 As Double, ByVal dImporte2 As Double, ByVal bMostrarDescartados As Boolean) As DataTable
        Dim dTabla As New DataTable("AuxiliarMayorPendiente"), dA As SqlDataAdapter
        Dim sSQL As String, sSQL2 As String = ""

        sSQL = "SELECT A.ID_DETALLE_AUX_MAYOR ID,DBO.FN_FORMAT_FECHA_CORTO(A.FECHA) FECHA,A.CONCEPTO,A.IMPORTE,A.ESTATUS " & _
                                    "FROM CONCILIACIONES_BANCARIAS_DETALLE_AUXILIAR_MAYOR A " & _
                                    "WHERE A.ID_GLOBAL_CONCILIACION=" & Me._ID_GLOBAL_CONCILIACION.ToString & " " & _
                                    "AND A.ID_DETALLE_AUX_MAYOR NOT IN" & _
"(SELECT C.ID_DETALLE_AUX_MAYOR FROM CONCILIACIONES_BANCARIAS_DETALLE_COINCIDENCIAS C WHERE C.ID_GLOBAL_CONCILIACION=" & Me._ID_GLOBAL_CONCILIACION.ToString & ") "

        If bMostrarDescartados = False Then
            sSQL2 = " AND A.ESTATUS='A' "
        End If

        sSQL2 = sSQL2 & " AND A.FECHA<='" & Format(dtFechaCorte, "yyyy/dd/MM") & " 23:59:00'"

        If dImporte1 <> 0 Or dImporte2 <> 0 Then
            sSQL2 = sSQL2 & " AND ABS(A.IMPORTE) BETWEEN " & dImporte1.ToString & " AND " & dImporte2.ToString & " "
        End If

        sSQL = sSQL & sSQL2 & "ORDER BY A.ESTATUS,A.ID_DETALLE_AUX_MAYOR"

        Try
            dA = New SqlDataAdapter(sSQL, Me._Conexion)
            dA.Fill(dTabla)
            dA.Dispose()
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "AuxiliarMayorPendiente", ex)
        End Try
        AuxiliarMayorPendiente = dTabla
    End Function

    Public Function CoincidenciasDetalle(ByVal filtro As FiltroCoincidencias) As DataTable
        Dim dTabla As New DataTable("Coincidencias"), dA As SqlDataAdapter, sQl As String
        Try
            dTabla.Columns.Add("ID", GetType(Integer))
            dTabla.Columns.Add("ID_DETALLE_EDO_CUENTA", GetType(Integer))
            dTabla.Columns.Add("FECHA1", GetType(String))
            dTabla.Columns.Add("CONCEPTO1", GetType(String))
            dTabla.Columns.Add("IMPORTE1", GetType(Double))
            dTabla.Columns.Add("FECHA2", GetType(String))
            dTabla.Columns.Add("CONCEPTO2", GetType(String))
            dTabla.Columns.Add("IMPORTE2", GetType(Double))
            dTabla.Columns.Add("I", GetType(Boolean))
            dTabla.Columns.Add("F", GetType(Boolean))

            sQl = "SELECT C.ID_COINCIDENCIA ID,C.ID_DETALLE_EDO_CUENTA," & _
            "DBO.FN_FORMAT_FECHA_CORTO(EC.FECHA) FECHA1,EC.CONCEPTO CONCEPTO1,EC.IMPORTE IMPORTE1," & _
            "DBO.FN_FORMAT_FECHA_CORTO(A.FECHA) FECHA2,A.CONCEPTO CONCEPTO2,A.IMPORTE IMPORTE2, " & _
            "CASE WHEN C.COINDICENCIA_CON_DIFERENCIA_IMPORTE='1' THEN 'TRUE' ELSE 'FALSE' END I," & _
            "CASE WHEN C.COINDICENCIA_CON_DIFERENCIA_FECHA='1' THEN 'TRUE' ELSE 'FALSE' END F " & _
            "FROM CONCILIACIONES_BANCARIAS_DETALLE_COINCIDENCIAS C " & _
            "INNER JOIN CONCILIACIONES_BANCARIAS_DETALLE_ESTADO_CUENTA_IMPORTADO EC ON(C.ID_DETALLE_EDO_CUENTA=EC.ID_DETALLE_EDO_CUENTA) " & _
            "INNER JOIN CONCILIACIONES_BANCARIAS_DETALLE_AUXILIAR_MAYOR A ON(C.ID_DETALLE_AUX_MAYOR=A.ID_DETALLE_AUX_MAYOR) " & _
            "WHERE C.ID_GLOBAL_CONCILIACION=" & Me._ID_GLOBAL_CONCILIACION & " "

            Select Case filtro
                Case FiltroCoincidencias.DiferenciasImporte
                    sQl &= " AND C.COINDICENCIA_CON_DIFERENCIA_IMPORTE='1' "
                Case FiltroCoincidencias.DiferenciasFecha
                    sQl &= " AND C.COINDICENCIA_CON_DIFERENCIA_FECHA='1' "
            End Select

            sQl &= "ORDER BY EC.ID_DETALLE_EDO_CUENTA"

            dA = New SqlDataAdapter(sQl, Me._Conexion)
            dA.Fill(dTabla)
            dA.Dispose()
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "CoincidenciasDetalle", ex)
        End Try
        CoincidenciasDetalle = dTabla
    End Function

    Public Function BusquedaVisualPorNombreBanco() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de conciliaciones bancarias por nombre de banco."
        f.sCampo = "B.NOMBRE_CUENTA_BANCARIA"
        f.sOrder = "G.FECHA_1_EDO_CUENTA"
        f.sTable = "CONCILIACIONES_BANCARIAS_GLOBAL" 'Tabla en el servidor.

        f.sQl = "SELECT G.ID_GLOBAL_CONCILIACION ID,G.ID_CUENTA_BANCARIA CUENTA,B.NOMBRE_CUENTA_BANCARIA BANCO,ST.ESTATUS_COMPLETO ESTATUS, " & _
        "DBO.FN_FORMAT_FECHA_CORTO(G.FECHA_1_EDO_CUENTA) FECHA_1_EDO_CUENTA,DBO.FN_FORMAT_FECHA_CORTO(G.FECHA_2_EDO_CUENTA) FECHA_2_EDO_CUENTA " & _
        "FROM CONCILIACIONES_BANCARIAS_GLOBAL G " & _
        "INNER JOIN CAT_CUENTAS_BANCARIAS B ON(G.ID_CUENTA_BANCARIA=B.ID_CUENTA_BANCARIA) " & _
        "INNER JOIN CONCILIACIONES_BANCARIAS_CATALOGO_ESTATUS ST ON(G.ESTATUS=ST.ESTATUS) " & _
        "WHERE 1=1 AND "

        f.arrayWidthColumns = New Integer() {40, 70, 100, 100, 150, 150}

        f.Inicia("")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "BusquedaVisualPorNombreBanco", ex)
        End Try
        Return Resultado
    End Function

    Public Function CambiaStatusMovimientoAuxiliarMayor(ByVal iIDDetalleAuxMayor As Integer, ByVal sActivarDescartar As String) As Boolean
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CONCILIACIONES_BANCARIAS_CAMBIA_ESTATUS_AUXILIAR_MAYOR"

            sqlParametro = .Parameters.Add("@ID_DETALLE_AUX_MAYOR", SqlDbType.Int) : sqlParametro.Value = iIDDetalleAuxMayor
            sqlParametro = .Parameters.Add("@ACTIVAR_DESCARTAR", SqlDbType.Char, 1) : sqlParametro.Value = sActivarDescartar

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()

                CambiaStatusMovimientoAuxiliarMayor = True

            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "CambiaStatusMovimientoAuxiliarMayor", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
    End Function

    Public Function EliminarTodasCoincidencias() As Boolean
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CONCILIACIONES_BANCARIAS_ELIMINA_DETALLE_COINCIDENCIAS_COMPLETO"

            sqlParametro = .Parameters.Add("@ID_GLOBAL_CONCILIACION", SqlDbType.Int) : sqlParametro.Value = Me._ID_GLOBAL_CONCILIACION

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()

                EliminarTodasCoincidencias = True

            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "EliminarTodasCoincidencias", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
    End Function

    Public Function EliminarUnaCoincidencia(ByVal iIDDetalleEdoCuenta As Integer) As Boolean
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CONCILIACIONES_BANCARIAS_ELIMINA_DETALLE_COINCIDENCIAS_RENGLON"

            sqlParametro = .Parameters.Add("@ID_GLOBAL_CONCILIACION", SqlDbType.Int) : sqlParametro.Value = Me._ID_GLOBAL_CONCILIACION
            sqlParametro = .Parameters.Add("@ID_DETALLE_EDO_CUENTA", SqlDbType.Int) : sqlParametro.Value = iIDDetalleEdoCuenta

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()

                EliminarUnaCoincidencia = True

            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "EliminarUnaCoincidencia", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
    End Function

    Public Function GeneraCoincidencias() As Boolean
        Dim dInicio As DateTime = Date.Now

        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CONCILIACIONES_BANCARIAS_GENERA_COINCIDENCIAS"

            sqlParametro = .Parameters.Add("@ID_GLOBAL_CONCILIACION", SqlDbType.Int) : sqlParametro.Value = Me._ID_GLOBAL_CONCILIACION
            sqlParametro = .Parameters.Add("@COINCIDENCIAS_REALIZADAS", SqlDbType.Int) : sqlParametro.Value = 0 : sqlParametro.Direction = ParameterDirection.Output

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()

                GeneraCoincidencias = True
                Me._CoincidenciasEncontradas = CInt(cmd.Parameters("@COINCIDENCIAS_REALIZADAS").Value)
                Me._DuracionSegundosBusquedaCoincidencias = DateDiff(DateInterval.Second, dInicio, Date.Now)

            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "GeneraCoincidencias", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
    End Function

    Public Function GeneraCoincidencia(ByVal iIDDetalleEdoCuenta As Integer, ByVal iIDDetalleAuxMayor As Integer) As Integer
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CONCILIACIONES_BANCARIAS_GRABA_DETALLE_COINCIDENCIAS"

            sqlParametro = .Parameters.Add("@ID_GLOBAL_CONCILIACION", SqlDbType.Int) : sqlParametro.Value = Me._ID_GLOBAL_CONCILIACION
            sqlParametro = .Parameters.Add("@ID_COINCIDENCIA", SqlDbType.Int) : sqlParametro.Value = 0 : sqlParametro.Direction = ParameterDirection.Output
            sqlParametro = .Parameters.Add("@ID_DETALLE_EDO_CUENTA", SqlDbType.Int) : sqlParametro.Value = iIDDetalleEdoCuenta
            sqlParametro = .Parameters.Add("@ID_DETALLE_AUX_MAYOR", SqlDbType.Int) : sqlParametro.Value = iIDDetalleAuxMayor

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()

                GeneraCoincidencia = CInt(cmd.Parameters("@ID_COINCIDENCIA").Value)

            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "GeneraCoincidencia", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
    End Function

    Public Function ImportarConciliacion(ByVal iUsuarioGrabo As Integer, ByVal IIDCentro As Integer) As Boolean
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CONCILIACIONES_BANCARIAS_IMPORTA_CONCILIACION"

            sqlParametro = .Parameters.Add("@ID_GLOBAL_CONCILIACION_A_IMPORTAR", SqlDbType.Int) : sqlParametro.Value = Me._ID_GLOBAL_CONCILIACION
            sqlParametro = .Parameters.Add("@ID_GLOBAL_CONCILIACION_NUEVA", SqlDbType.Int) : sqlParametro.Value = 0 : sqlParametro.Direction = ParameterDirection.Output
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO_GRABO", SqlDbType.SmallInt) : sqlParametro.Value = iUsuarioGrabo
            sqlParametro = .Parameters.Add("@ID_CENTRO", SqlDbType.SmallInt) : sqlParametro.Value = IIDCentro

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()

                Me._ID_GLOBAL_CONCILIACION = CInt(cmd.Parameters("@ID_GLOBAL_CONCILIACION_NUEVA").Value)

                ImportarConciliacion = True

            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "ImportarConciliacion", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
    End Function

    Public Function Finalizar() As Boolean
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CONCILIACIONES_BANCARIAS_FINALIZA_CONCILIACION"

            sqlParametro = .Parameters.Add("@ID_GLOBAL_CONCILIACION", SqlDbType.Int) : sqlParametro.Value = Me._ID_GLOBAL_CONCILIACION
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO_FINALIZO", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_USUARIO_FINALIZO

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()

                Finalizar = True

            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "Finalizar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
    End Function

    Public Function Imprimir() As Boolean
        Dim Rpt As New ReportDocument
        Dim oReporte As Class_Reporte
        Dim sFormato As String = "RPT_FORMATO_CONCILIACIONES_BANCARIAS.rpt"
        Try
            oReporte = New Class_Reporte(sFormato, Rpt, True)

            Rpt.SetParameterValue("@ID_GLOBAL_CONCILIACION", Me.ID_GLOBAL_CONCILIACION)

            Dim frm As New Reporte(Rpt)
            frm.CRViewer.ShowGroupTreeButton = False
            frm.Show()
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "Imprimir", ex)
        End Try
    End Function

    Public Function ImprimirMovimientosPendientes(ByVal dFechaCorte As Date, ByVal dImporte1 As Double, ByVal dImporte2 As Double) As Boolean
        Dim Rpt As New ReportDocument
        Dim oReporte As Class_Reporte
        Dim sFormato As String = "RPT_CONCILIACIONES_BANCARIAS_ESTADO_CUENTA_PENDIENTE_Y_AUXILIAR_MAYOR_PENDIENTE.rpt"
        Try
            oReporte = New Class_Reporte(sFormato, Rpt, True)

            Rpt.SetParameterValue("@ID_GLOBAL_CONCILIACION", Me.ID_GLOBAL_CONCILIACION)
            Rpt.SetParameterValue("@FECHA_CORTE", Format(dFechaCorte, "yyyy-dd-MM"))
            Rpt.SetParameterValue("@IMPORTE1", dImporte1)
            Rpt.SetParameterValue("@IMPORTE2", dImporte2)

            Dim frm As New Reporte(Rpt)
            'frm.Text = Rpt.SummaryInfo.ReportTitle
            'frm.CRViewer.ReportSource = Rpt
            frm.CRViewer.ShowGroupTreeButton = False
            frm.Show()
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "ImprimirMovimientosPendientes", ex)
        End Try
    End Function

#End Region

End Class
