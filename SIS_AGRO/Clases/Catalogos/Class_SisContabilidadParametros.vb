Imports System.Data
Imports System.Data.SqlClient

Public Class Class_SisContabilidadParametros
#Region "Campos"

#Region "Campos de la tabla"
    Private _LEN_CUENTA_CONTABLE_NIVEL1 As Integer
    Private _LEN_CUENTA_CONTABLE_NIVEL2 As Integer
    Private _LEN_CUENTA_CONTABLE_NIVEL3 As Integer
    Private _LEN_CUENTA_CONTABLE_NIVEL4 As Integer
    Private _LEN_CUENTA_CONTABLE_NIVEL5 As Integer
    'Private _ID_CON_EJERCICIO As Integer
    'Private _FECHA_INICIO As Date
    'Private _FECHA_FINAL As Date
    Private _CUENTA_CONTABLE_CIERRE As String
    'Private _NOMBRE_EJERCICIO As String
#End Region

#Region "Campos de sistema"
    Private _Nombre_Catalogo As String
    Private _Conexion As SqlConnection
    Private _QuerySelect As String
#End Region

#End Region

#Region "Propiedades"

#Region "Propiedades Campos de la tabla"
    Public Property LEN_CUENTA_CONTABLE_NIVEL1() As Integer
        Get
            Return Me._LEN_CUENTA_CONTABLE_NIVEL1
        End Get
        Set(ByVal value As Integer)
            Me._LEN_CUENTA_CONTABLE_NIVEL1 = value
        End Set
    End Property
    Public Property LEN_CUENTA_CONTABLE_NIVEL2() As Integer
        Get
            Return Me._LEN_CUENTA_CONTABLE_NIVEL2
        End Get
        Set(ByVal value As Integer)
            Me._LEN_CUENTA_CONTABLE_NIVEL2 = value
        End Set
    End Property
    Public Property LEN_CUENTA_CONTABLE_NIVEL3() As Integer
        Get
            Return Me._LEN_CUENTA_CONTABLE_NIVEL3
        End Get
        Set(ByVal value As Integer)
            Me._LEN_CUENTA_CONTABLE_NIVEL3 = value
        End Set
    End Property
    Public Property LEN_CUENTA_CONTABLE_NIVEL4() As Integer
        Get
            Return Me._LEN_CUENTA_CONTABLE_NIVEL4
        End Get
        Set(ByVal value As Integer)
            Me._LEN_CUENTA_CONTABLE_NIVEL4 = value
        End Set
    End Property
    Public Property LEN_CUENTA_CONTABLE_NIVEL5() As Integer
        Get
            Return Me._LEN_CUENTA_CONTABLE_NIVEL5
        End Get
        Set(ByVal value As Integer)
            Me._LEN_CUENTA_CONTABLE_NIVEL5 = value
        End Set
    End Property
    'Public Property ID_CON_EJERCICIO() As Integer
    '    Get
    '        Return Me._ID_CON_EJERCICIO
    '    End Get
    '    Set(ByVal value As Integer)
    '        Me._ID_CON_EJERCICIO = value
    '    End Set
    'End Property
    'Public Property FECHA_INICIO() As Date
    '    Get
    '        Return Me._FECHA_INICIO
    '    End Get
    '    Set(ByVal value As Date)
    '        Me._FECHA_INICIO = value
    '    End Set
    'End Property
    'Public Property FECHA_FINAL() As Date
    '    Get
    '        Return Me._FECHA_FINAL
    '    End Get
    '    Set(ByVal value As Date)
    '        Me._FECHA_FINAL = value
    '    End Set
    'End Property

    Public Property CUENTA_CONTABLE_CIERRE() As String
        Get
            Return Me._CUENTA_CONTABLE_CIERRE
        End Get
        Set(ByVal value As String)
            Me._CUENTA_CONTABLE_CIERRE = value
        End Set
    End Property

    'Public ReadOnly Property NOMBRE_EJERCICIO() As String
    '    Get
    '        Return Me._NOMBRE_EJERCICIO
    '    End Get
    'End Property

#End Region

#Region "Propiedad Nombre de Clase"
    Public ReadOnly Property Nombre_Clase() As String
        Get
            Return "Class_SisContabilidadParametros"
        End Get
    End Property
#End Region

#End Region

#Region "Constructor y destructor"
    Public Sub New()
        Me._Nombre_Catalogo = "SIS_CONTABILIDAD_PARAMETROS"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        'Me._QuerySelect = "SELECT P.*,E.NOMBRE_EJERCICIO FROM SIS_CONTABILIDAD_PARAMETROS P INNER JOIN CON_EJERCICIOS E ON(P.ID_CON_EJERCICIO=E.ID_CON_EJERCICIO) "
        Me._QuerySelect = "SELECT P.* FROM SIS_CONTABILIDAD_PARAMETROS P "
        Me.Consultar()
    End Sub

    Public Sub New(ByVal bSinConexion As Boolean)
        Me._Nombre_Catalogo = "SIS_CONTABILIDAD_PARAMETROS"

    End Sub   'Inicializa al objeto.

    Protected Overrides Sub Finalize()
        'Me._Conexion.Dispose()
        MyBase.Finalize()
    End Sub
#End Region

#Region "Métodos y procedimientos"

    Public Function Consultar() As Boolean
        Dim cmd As New SqlCommand(Me._QuerySelect, Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()
                If dReader.Read Then
                    Me._LEN_CUENTA_CONTABLE_NIVEL1 = CType(dReader("LEN_CUENTA_CONTABLE_NIVEL1"), Integer)
                    Me._LEN_CUENTA_CONTABLE_NIVEL2 = CType(dReader("LEN_CUENTA_CONTABLE_NIVEL2"), Integer)
                    Me._LEN_CUENTA_CONTABLE_NIVEL3 = CType(dReader("LEN_CUENTA_CONTABLE_NIVEL3"), Integer)
                    Me._LEN_CUENTA_CONTABLE_NIVEL4 = CType(dReader("LEN_CUENTA_CONTABLE_NIVEL4"), Integer)
                    Me._LEN_CUENTA_CONTABLE_NIVEL5 = CType(dReader("LEN_CUENTA_CONTABLE_NIVEL5"), Integer)
                    'Me._ID_CON_EJERCICIO = CType(dReader("ID_CON_EJERCICIO"), Integer)
                    'Me._FECHA_INICIO = CType(dReader("FECHA_INICIO"), Date)
                    'Me._FECHA_FINAL = CType(dReader("FECHA_FINAL"), Date)
                    Me._CUENTA_CONTABLE_CIERRE = "" & dReader("CUENTA_CONTABLE_CIERRE").ToString
                    'Me._NOMBRE_EJERCICIO = CType(dReader("NOMBRE_EJERCICIO"), String)
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

    'Public Function ActualizaFechas() As Boolean
    '    Dim cmd As New SqlCommand
    '    Dim sqlParametro As SqlParameter
    '    With cmd
    '        .Connection = Me._Conexion
    '        .CommandTimeout = 0
    '        .CommandType = CommandType.StoredProcedure
    '        .CommandText = "MP_CONTABILIDAD_ACTUALIZA_FECHAS_PARAMETROS"

    '        sqlParametro = .Parameters.Add("@FECHA_INICIO", SqlDbType.DateTime) : sqlParametro.Value = Me._FECHA_INICIO
    '        sqlParametro = .Parameters.Add("@FECHA_FINAL", SqlDbType.DateTime) : sqlParametro.Value = Me._FECHA_FINAL
    '        sqlParametro = .Parameters.Add("@ID_CON_EJERCICIO", SqlDbType.SmallInt) : sqlParametro.Value = Me._ID_CON_EJERCICIO

    '        Try
    '            Me._Conexion.Open()
    '            .ExecuteNonQuery()
    '            ActualizaFechas = True
    '        Catch ex As Exception
    '            HandleError(Me.Nombre_Clase, "ActualizaFechas", ex)
    '        Finally
    '            Me._Conexion.Close()
    '            cmd.Dispose()
    '            sqlParametro = Nothing
    '        End Try
    '    End With
    'End Function

    'Private Sub ConsultaNombreEjercicio()
    '    Dim BuscaNombreEjercicio As New Class_find("SELECT NOMBRE_EJERCICIO FROM CON_EJERCICIOS WHERE ID_CON_EJERCICIO=" & EmpresaParametros.ID_CON_EJERCICIO)
    '    Me._NOMBRE_EJERCICIO = BuscaNombreEjercicio.Result1
    'End Sub

    'Public Function ValidarPeriodoTrabajo(ByVal dtFecha As Date) As Boolean
    '    Dim ValidaPeriodo As New Class_find("SELECT 1,ESTATUS_EJERCICIO,NOMBRE_EJERCICIO FROM CON_EJERCICIOS WHERE ID_CON_EJERCICIO=" & EmpresaParametros.ID_CON_EJERCICIO & _
    '            " AND (CAST('" & Format(dtFecha, "yyyy-dd-MM") & "' AS DATETIME) BETWEEN '" & Format(EmpresaParametros.FECHA_INICIO, "yyyy-dd-MM") & "' AND '" & Format(EmpresaParametros.FECHA_FINAL, "yyyy-dd-MM") & "')")
    '    'SE AGREGÓ EL CAST A LA FECHA PARA EVITAR LA COMPRACION DE STRING PORQUE EL SQL NO DISTINGUE QUE SE COMPARABA CON FECHAS

    '    If ValidaPeriodo.Result1.Length = 0 Then
    '        MsgBox("La fecha esta fuera del periodo de trabajo.", MsgBoxStyle.Exclamation, Me.Nombre_Clase)
    '        Exit Function
    '    End If

    '    If ValidaPeriodo.Result2.ToString <> "A" Then
    '        MsgBox("El ejercicio " & ValidaPeriodo.Result3.ToString & " no esta abierto .", MsgBoxStyle.Exclamation, Me.Nombre_Clase)
    '        Exit Function
    '    End If

    '    ValidarPeriodoTrabajo = True
    'End Function

    'Public Sub ActualizaNombreEjercicio()
    '    Dim sql As Class_find
    '    sql = New Class_find("SELECT NOMBRE_EJERCICIO FROM CON_EJERCICIOS WHERE ID_CON_EJERCICIO=" & Me.ID_CON_EJERCICIO)
    '    Me._NOMBRE_EJERCICIO = sql.Result1
    '    sql = Nothing
    'End Sub

#End Region

End Class
