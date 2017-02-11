Option Strict On
Imports System.Data
Imports System.Data.SqlClient

Public Class Class_NominaTemporada

#Region "Campos"

#Region "Campos de la tabla"
    Private _ID_NOMINA_TEMPORADA As Integer
    Private _CODIGO_TEMPORADA As Integer
    Private _NOMBRE_TEMPORADA As String
    Private _FECHA1 As Date
    Private _FECHA2 As Date
    Private _NUMERO_SEMANAS As Integer
#End Region

#Region "Campos ligados a la tabla"

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

    Public Property ID_NOMINA_TEMPORADA() As Integer
        Get
            Return Me._ID_NOMINA_TEMPORADA
        End Get
        Set(ByVal Value As Integer)
            Me._ID_NOMINA_TEMPORADA = Value
        End Set
    End Property

    Public ReadOnly Property CODIGO_TEMPORADA() As Integer
        Get
            Return Me._CODIGO_TEMPORADA
        End Get
    End Property

    Public ReadOnly Property NOMBRE_TEMPORADA() As String
        Get
            Return Me._NOMBRE_TEMPORADA
        End Get
    End Property

    Public ReadOnly Property FECHA1() As Date
        Get
            Return Me._FECHA1
        End Get
    End Property

    Public ReadOnly Property FECHA2() As Date
        Get
            Return Me._FECHA2
        End Get
    End Property

    Public ReadOnly Property NUMERO_SEMANAS() As Integer
        Get
            Return Me._NUMERO_SEMANAS
        End Get
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

#End Region

#End Region

#Region "Constructor y destructor"
    Public Sub New()
        Me._Nombre_Catalogo = "NOMINA_TEMPORADAS"
        Me._Nombre_Reporte = "RPT_CATALOGO_NOMINA_TEMPORADAS.rpt"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "Select * From NOMINA_TEMPORADAS"
        Me._QueryOrder = " Order by ID_NOMINA_TEMPORADA"
    End Sub

    Public Sub New(ByVal iTemporada As Integer)
        Me.New()
        Try
            Me.ID_NOMINA_TEMPORADA = iTemporada
            If Me.Consultar = False Then
                Throw New Exception("La temporada no existe.")
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

#Region "Opciones"

#End Region

#Region "Métodos y procedimientos"
    Public Function Consultar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand(Me._QuerySelect & " Where ID_NOMINA_TEMPORADA=" & Plaza.oSisPlazaNomina.NOMINA_ID_NOMINA_TEMPORADA_ACTIVA.ToString, Me._Conexion) '
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._ID_NOMINA_TEMPORADA = CType(dReader("ID_NOMINA_TEMPORADA"), Integer)
                    Me._CODIGO_TEMPORADA = CType(dReader("CODIGO_TEMPORADA"), Integer)
                    Me._NOMBRE_TEMPORADA = Trim("" & dReader("NOMBRE_TEMPORADA").ToString)
                    Me._FECHA1 = CDate(dReader("FECHA1").ToString)
                    Me._FECHA2 = CDate(dReader("FECHA2").ToString)
                    Me._NUMERO_SEMANAS = CInt(dReader("NUMERO_SEMANAS"))

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

    Public Function ObtenerSemanaActiva() As Integer 'Antes se llamaba ObtenerSemanaActual, pero no se usaba
        Dim iTemporada As Integer = 0
        Try
            'Dim sql As New Class_find("SELECT (DATEDIFF(DAY,FECHA1,GETDATE())/7) NUMERO_SEMANA_ACTUAL " & _
            '                      "FROM NOMINA_TEMPORADAS WHERE ID_NOMINA_TEMPORADA=" & Plaza.oSisPlazaNomina.NOMINA_ID_NOMINA_TEMPORADA_ACTIVA.ToString)

            'Regresa la semana mas vieja sin generar(si todas estan generadas entonces deberia de regresar la semana actual)
            Dim sql As New Class_find("SELECT ID_NOMINA_SEMANA FROM NOMINA_SEMANA S WHERE ID_NOMINA_TEMPORADA=" & Me.ID_NOMINA_TEMPORADA.ToString & " AND NUMERO_SEMANA=" & _
            "(SELECT MIN(NUMERO_SEMANA) FROM NOMINA_SEMANA WHERE ID_NOMINA_TEMPORADA=S.ID_NOMINA_TEMPORADA AND NOMINA_GENERADA='0')")

            iTemporada = CInt(sql.Result1)

        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "ObtenerSemanaActiva", ex)
        End Try

        Return iTemporada
    End Function

    Public Function ObtenerClavesValidaciones(ByVal sTipoValidacion As String) As System.Data.DataTable
        Dim dTabla As New DataTable("detalle"), da As SqlDataAdapter
        Dim sSQL As String
        If sTipoValidacion = "IMSS" Then
            sSQL = "SELECT CODIGO_VALIDACION,(CAST(CODIGO_VALIDACION AS NVARCHAR(2)) + '.- ' + NOMBRE_VALIDACION) NOMBRE_VALIDACION  FROM NOMINA_CAT_CLAVES_VALIDACIONES_ISDE WHERE TIPO_VALIDACION='IMSS' ORDER BY CODIGO_VALIDACION ASC "
        Else
            sSQL = "SELECT NOMBRE_VALIDACION FROM NOMINA_CAT_CLAVES_VALIDACIONES_ISDE WHERE TIPO_VALIDACION='CONTROL' ORDER BY CODIGO_VALIDACION ASC "
        End If
        Try
            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dTabla)
            da.Dispose()
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "ObtenerClavesValidaciones", ex)
        End Try
        Return dTabla
    End Function

    Public Function ObtieneAgunaldos(ByVal iPuntoPago As Integer, ByVal dFactor As Double, ByVal iPrestacion As Integer, ByVal iIdSemana1 As Integer, ByVal iIdSemana2 As Integer, ByVal bAccion As Boolean) As System.Data.DataTable
        Dim dt As New DataTable
        Try
            Dim da As New SqlDataAdapter("MP_NOMINA_GENERA_AGUINALDO_PRESTACIONES", Me._Conexion)
            da.SelectCommand.CommandType = CommandType.StoredProcedure

            With da.SelectCommand
                .Parameters.Add("@ID_NOMINA_TEMPORADA", SqlDbType.SmallInt).Value = Plaza.oSisPlazaNomina.NOMINA_ID_NOMINA_TEMPORADA_ACTIVA.ToString
                .Parameters.Add("@CODIGO_PUNTO_PAGO", SqlDbType.SmallInt).Value = iPuntoPago
                .Parameters.Add("@FACTOR", SqlDbType.Decimal).Value = dFactor
                .Parameters.Add("@CODIGO_TIPO_PRESTACION", SqlDbType.SmallInt).Value = iPrestacion
                .Parameters.Add("@ID_NOMINA_SEMANA1", SqlDbType.SmallInt).Value = iIdSemana1
                .Parameters.Add("@ID_NOMINA_SEMANA2", SqlDbType.SmallInt).Value = iIdSemana2
                .Parameters.Add("@ACCION", SqlDbType.Char, 1).Value = Convert.ToInt32(bAccion)
            End With

            da.Fill(dt)
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "ObtieneAgunaldos", ex)
        End Try
        Return dt
    End Function

    Public Function ObtieneResumenAgunaldo() As System.Data.DataTable
        Dim dt As New DataTable, da As SqlDataAdapter
        Dim sSQL As String

        sSQL = "SELECT ISNULL(G.ID_NOMINA_PRESTACIONES_GLOBAL,0) ID_NOMINA_PRESTACIONES_GLOBAL,P.CODIGO_PUNTO_PAGO,P.NOMBRE_PUNTO_PAGO,ISNULL(G.TOTAL,0) TOTAL_PUNTO_PAGO,G.FACTOR " & _
               "FROM NOMINA_PRESTACIONES_GLOBAL G RIGHT JOIN NOMINA_CAT_PUNTOS_PAGO P ON(G.CODIGO_PUNTO_PAGO=P.CODIGO_PUNTO_PAGO) " & _
               "WHERE P.PROTEGIDO='0' AND P.CODIGO_PLAZA=" & Plaza.CODIGO_PLAZA.ToString & " AND G.ID_NOMINA_TEMPORADA=" & Plaza.oSisPlazaNomina.NOMINA_ID_NOMINA_TEMPORADA_ACTIVA.ToString & " ORDER BY P.CODIGO_PUNTO_PAGO"
        'AND G.ID_NOMINA_TEMPORADA=2 
        Try
            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dt)
            da.Dispose()

        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "ObtieneResumenAgunaldo", ex)
        End Try
        Return dt
    End Function

    Public Function ObtenerElementos(ByVal sCodigoPlaza As String) As System.Data.DataTable
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter("SELECT ID_NOMINA_TEMPORADA,NOMBRE_TEMPORADA FROM NOMINA_TEMPORADAS  WHERE CODIGO_PLAZA=" & sCodigoPlaza, Me._Conexion)
        Try
            da.Fill(dTable)
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "ObtenerElementos", ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

    Public Function GrabaAgunaldo(ByVal iIdPrestacion As Integer, ByVal dAguinaldo As Double, ByVal bAccion As Boolean, Optional ByVal sCodigoTrabajador As String = "", Optional ByVal iDiasTrabajados As Integer = 0) As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_NOMINA_AGUINALDO_PRESTACIONES_GRABA_DETALLE"

            'sqlParametro = .Parameters.Add("@ID_NOMINA_PRESTACIONES_DETALLE", SqlDbType.SmallInt) : sqlParametro.Value = iIdPrestacion
            sqlParametro = .Parameters.Add("@ID_NOMINA_PRESTACIONES_GLOBAL", SqlDbType.SmallInt) : sqlParametro.Value = iIdPrestacion
            sqlParametro = .Parameters.Add("@CODIGO_TRABAJADOR", SqlDbType.NVarChar, 10) : sqlParametro.Value = sCodigoTrabajador
            sqlParametro = .Parameters.Add("@DIAS_TRABAJADOS", SqlDbType.SmallInt) : sqlParametro.Value = iDiasTrabajados
            sqlParametro = .Parameters.Add("@PRESTACIONES", SqlDbType.Decimal) : sqlParametro.Value = dAguinaldo
            sqlParametro = .Parameters.Add("@ACCION", SqlDbType.Char, 1) : sqlParametro.Value = Convert.ToInt32(bAccion)

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me.Nombre_Catalogo, "GrabaAgunaldo", ex)
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
