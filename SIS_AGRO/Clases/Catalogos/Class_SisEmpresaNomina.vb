Option Strict On

Imports System.Data.SqlClient
Imports System.Data

Public Class Class_SisEmpresaNomina

#Region "Campos"

#Region "Campos de la tabla"

    Private _ID_SIS_EMPRESA_NOMINA As Integer
    'Private _CODIGO_EMPRESA As Integer
    Private _NOMINA_SUELDO_DIARIO As Double
    Private _NOMINA_NUMERO_REGISTRO_PATRONAL As String
    Private _NOMINA_NUMERO_SEMANA_ACTUAL As Integer
    Private _NOMINA_EQUIVALENCIA_JORNAL_HORAS As Integer
    Private _NOMINA_EDAD_MINIMA_TRABAJADORES As Double
    Private _NOMINA_RUTA_FOTOS_TRABAJADORES As String
    Private _NOMINA_RUTA_IDSE As String
    Private _RUTA_ALTAS_DISPERSIONES As String
    Private _NOMINA_TIPO_TRABAJADOR As String
    Private _NOMINA_TIPO_SALARIO As String
    Private _NOMINA_REDUCCION_TIPO_PAGO As String
    Private _NOMINA_GUIA As String
    Private _NOMINA_IDENTIFICADOR_FORMATO As String
    Private _IMPORTE_PUNTUALIDAD_DESPENSA As Double
    Private _NOMINA_DIA_INICIO_SEMANA As Integer
    Private _NOMINA_ID_NOMINA_TEMPORADA_ACTIVA As Integer
    Private _MOSTRAR_CULTIVO As String

#End Region

#Region "Campos ligados a la tabla"
    Private _CODIGO_PLAZA As Integer
    Private _CONEXION_SUA_EVENTUALES As String
#End Region

#Region "Campos públicos"

#End Region

#Region "Campos privados"

#End Region

#Region "Campos de sistema"
    Private _Nombre_Catalogo As String
    Private _Conexion As SqlConnection
    Private _QuerySelect As String
#End Region


#End Region

#Region "Propiedades"

#Region "Propiedades Campos de la tabla"

    Public Property ID_SIS_EMPRESA_NOMINA() As Integer
        Get
            Return Me._ID_SIS_EMPRESA_NOMINA
        End Get
        Set(ByVal Value As Integer)
            Me._ID_SIS_EMPRESA_NOMINA = Value
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

    Public Property NOMINA_SUELDO_DIARIO() As Double
        Get
            Return Me._NOMINA_SUELDO_DIARIO
        End Get
        Set(ByVal Value As Double)
            Me._NOMINA_SUELDO_DIARIO = Value
        End Set
    End Property

    Public Property NOMINA_NUMERO_REGISTRO_PATRONAL() As String
        Get
            Return Me._NOMINA_NUMERO_REGISTRO_PATRONAL
        End Get
        Set(ByVal Value As String)
            Me._NOMINA_NUMERO_REGISTRO_PATRONAL = Value
        End Set
    End Property

    Public Property NOMINA_NUMERO_SEMANA_ACTUAL() As Integer
        Get
            Return Me._NOMINA_NUMERO_SEMANA_ACTUAL
        End Get
        Set(ByVal Value As Integer)
            Me._NOMINA_NUMERO_SEMANA_ACTUAL = Value
        End Set
    End Property

    Public Property NOMINA_EQUIVALENCIA_JORNAL_HORAS() As Integer
        Get
            Return Me._NOMINA_EQUIVALENCIA_JORNAL_HORAS
        End Get
        Set(ByVal Value As Integer)
            Me._NOMINA_EQUIVALENCIA_JORNAL_HORAS = Value
        End Set
    End Property

    Public Property NOMINA_EDAD_MINIMA_TRABAJADORES() As Double
        Get
            Return Me._NOMINA_EDAD_MINIMA_TRABAJADORES
        End Get
        Set(ByVal Value As Double)
            Me._NOMINA_EDAD_MINIMA_TRABAJADORES = Value
        End Set
    End Property

    Public Property NOMINA_RUTA_FOTOS_TRABAJADORES() As String
        Get
            Return Me._NOMINA_RUTA_FOTOS_TRABAJADORES
        End Get
        Set(ByVal Value As String)
            Me._NOMINA_RUTA_FOTOS_TRABAJADORES = Value
        End Set
    End Property

    Public Property NOMINA_RUTA_IDSE() As String
        Get
            Return Me._NOMINA_RUTA_IDSE
        End Get
        Set(ByVal Value As String)
            Me._NOMINA_RUTA_IDSE = Value
        End Set
    End Property

    Public Property RUTA_ALTAS_DISPERSIONES() As String
        Get
            Return Me._RUTA_ALTAS_DISPERSIONES
        End Get
        Set(ByVal Value As String)
            Me._RUTA_ALTAS_DISPERSIONES = Value
        End Set
    End Property

    Public Property NOMINA_TIPO_TRABAJADOR() As String
        Get
            Return Me._NOMINA_TIPO_TRABAJADOR
        End Get
        Set(ByVal value As String)
            Me._NOMINA_TIPO_TRABAJADOR = value
        End Set
    End Property

    Public Property NOMINA_TIPO_SALARIO() As String
        Get
            Return Me._NOMINA_TIPO_SALARIO
        End Get
        Set(ByVal value As String)
            Me._NOMINA_TIPO_SALARIO = value
        End Set
    End Property

    Public Property NOMINA_REDUCCION_TIPO_PAGO() As String
        Get
            Return Me._NOMINA_REDUCCION_TIPO_PAGO
        End Get
        Set(ByVal value As String)
            Me._NOMINA_REDUCCION_TIPO_PAGO = value
        End Set
    End Property

    Public Property NOMINA_GUIA() As String
        Get
            Return Me._NOMINA_GUIA
        End Get
        Set(ByVal value As String)
            Me._NOMINA_GUIA = value
        End Set
    End Property

    Public Property NOMINA_IDENTIFICADOR_FORMATO() As String
        Get
            Return Me._NOMINA_IDENTIFICADOR_FORMATO
        End Get
        Set(ByVal value As String)
            Me._NOMINA_IDENTIFICADOR_FORMATO = value
        End Set
    End Property

    Public Property IMPORTE_PUNTUALIDAD_DESPENSA() As Double
        Get
            Return Me._IMPORTE_PUNTUALIDAD_DESPENSA
        End Get
        Set(ByVal Value As Double)
            Me._IMPORTE_PUNTUALIDAD_DESPENSA = Value
        End Set
    End Property

    Public ReadOnly Property NOMINA_DIA_INICIO_SEMANA() As Integer
        Get
            Return Me._NOMINA_DIA_INICIO_SEMANA
        End Get
    End Property

    Public Property NOMINA_ID_NOMINA_TEMPORADA_ACTIVA() As Integer
        Get
            Return Me._NOMINA_ID_NOMINA_TEMPORADA_ACTIVA
        End Get

        Set(ByVal value As Integer)
            Me._NOMINA_ID_NOMINA_TEMPORADA_ACTIVA = value
        End Set
    End Property
    Public ReadOnly Property MOSTRAR_CULTIVO() As String
        Get
            Return Me._MOSTRAR_CULTIVO
        End Get
    End Property
#End Region

#Region "Propiedades de campos ligados a la tabla"
    Public ReadOnly Property CONEXION_SUA_EVENTUALES() As String
        Get
            Return Me._CONEXION_SUA_EVENTUALES
        End Get
    End Property
#End Region

#Region "Propiedades públicos"

#End Region

#Region "Propiedades de campos privados"

#End Region

#Region "Propiedades Campos de sistema"

#End Region

#End Region

#Region "Constructor y destructor"
    Public Sub New(Optional ByVal sConexion As String = "") 'Utilizado unicamente para la configuración de la empresa.
        If txtLEN(sConexion) = False Then
            Exit Sub
        End If

        If Not IsNothing(Empresa_Sistema) Then
            Me._Conexion = New SqlConnection(sConexion)

            Me._QuerySelect = "Select *,S.RUTA_DB RUTA_DB_EVENTUALES " & _
            "From SIS_EMPRESA_NOMINA E " & _
            "INNER JOIN SIS_EMPRESA_NOMINA_LISTA_DBS_SUA S ON(E.CODIGO_PLAZA=S.CODIGO_PLAZA AND S.NOMBRE='EVENTUALES' ) "

            If Me.Consultar() = False Then
                MsgBox("Faltan datos de la nomina. Contácte a su administrador de sistemas.", MsgBoxStyle.Critical)
                Finaliza(False)
            End If
        End If
    End Sub

#End Region

#Region "Métodos y procedimientos"
    Public Function Actualizar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_SIS_EMPRESA_NOMINA_GRABA"

            sqlParametro = .Parameters.Add("@ID_SIS_EMPRESA_NOMINA", SqlDbType.SmallInt) : sqlParametro.Direction = ParameterDirection.InputOutput : sqlParametro.Value = Me._ID_SIS_EMPRESA_NOMINA
            sqlParametro = .Parameters.Add("@CODIGO_PLAZA", SqlDbType.SmallInt) : sqlParametro.Value = Empresa_Sistema.CODIGO_EMPRESA.ToString
            sqlParametro = .Parameters.Add("@NOMINA_SUELDO_DIARIO_INTEGRADO", SqlDbType.Money) : sqlParametro.Value = Me._NOMINA_SUELDO_DIARIO
            sqlParametro = .Parameters.Add("@NOMINA_NUMERO_REGISTRO_PATRONAL", SqlDbType.NVarChar, 11) : sqlParametro.Value = Me._NOMINA_NUMERO_REGISTRO_PATRONAL.ToUpper
            sqlParametro = .Parameters.Add("@NOMINA_NUMERO_SEMANA_ACTUAL", SqlDbType.SmallInt) : sqlParametro.Value = Me._NOMINA_NUMERO_SEMANA_ACTUAL
            sqlParametro = .Parameters.Add("@NOMINA_EQUIVALENCIA_JORNAL_HORAS", SqlDbType.SmallInt) : sqlParametro.Value = Me._NOMINA_EQUIVALENCIA_JORNAL_HORAS
            sqlParametro = .Parameters.Add("@NOMINA_EDAD_MINIMA_TRABAJADORES", SqlDbType.SmallInt) : sqlParametro.Value = Me._NOMINA_EDAD_MINIMA_TRABAJADORES
            sqlParametro = .Parameters.Add("@NOMINA_RUTA_FOTOS_TRABAJADORES", SqlDbType.NVarChar, 150) : sqlParametro.Value = Me._NOMINA_RUTA_FOTOS_TRABAJADORES.ToUpper
            sqlParametro = .Parameters.Add("@NOMINA_RUTA_IDSE", SqlDbType.NVarChar, 150) : sqlParametro.Value = Me._NOMINA_RUTA_IDSE.ToUpper
            sqlParametro = .Parameters.Add("@NOMINA_TIPO_TRABAJADOR", SqlDbType.Char, 1) : sqlParametro.Value = Me._NOMINA_TIPO_TRABAJADOR.ToUpper
            sqlParametro = .Parameters.Add("@NOMINA_TIPO_SALARIO", SqlDbType.Char, 1) : sqlParametro.Value = Me._NOMINA_TIPO_SALARIO.ToUpper
            sqlParametro = .Parameters.Add("@NOMINA_REDUCCION_TIPO_PAGO", SqlDbType.Char, 1) : sqlParametro.Value = Me._NOMINA_REDUCCION_TIPO_PAGO.ToUpper
            sqlParametro = .Parameters.Add("@NOMINA_GUIA", SqlDbType.NVarChar, 5) : sqlParametro.Value = Me._NOMINA_GUIA.ToUpper
            sqlParametro = .Parameters.Add("@NOMINA_IDENTIFICADOR_FORMATO", SqlDbType.Char, 1) : sqlParametro.Value = Me._NOMINA_IDENTIFICADOR_FORMATO.ToUpper
            sqlParametro = .Parameters.Add("@NOMINA_ID_NOMINA_TEMPORADA_ACTIVA", SqlDbType.SmallInt) : sqlParametro.Value = Me._NOMINA_ID_NOMINA_TEMPORADA_ACTIVA
            sqlParametro = .Parameters.Add("@ACCION", SqlDbType.NVarChar, 15) : sqlParametro.Value = "ACTUALIZAR".ToUpper

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                Me._ID_SIS_EMPRESA_NOMINA = CInt(.Parameters("@ID_SIS_EMPRESA_NOMINA").Value)
                bResultado = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "Actualizar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With

        Return bResultado
    End Function

    Public Function Insertar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_SIS_EMPRESA_NOMINA_GRABA"

            sqlParametro = .Parameters.Add("@ID_SIS_EMPRESA_NOMINA", SqlDbType.SmallInt) : sqlParametro.Direction = ParameterDirection.InputOutput : sqlParametro.Value = Me._ID_SIS_EMPRESA_NOMINA
            sqlParametro = .Parameters.Add("@CODIGO_PLAZA", SqlDbType.SmallInt) : sqlParametro.Value = Empresa_Sistema.CODIGO_EMPRESA.ToString
            sqlParametro = .Parameters.Add("@NOMINA_SUELDO_DIARIO_INTEGRADO", SqlDbType.Money) : sqlParametro.Value = Me._NOMINA_SUELDO_DIARIO
            sqlParametro = .Parameters.Add("@NOMINA_NUMERO_REGISTRO_PATRONAL", SqlDbType.NVarChar, 11) : sqlParametro.Value = Me._NOMINA_NUMERO_REGISTRO_PATRONAL
            sqlParametro = .Parameters.Add("@NOMINA_NUMERO_SEMANA_ACTUAL", SqlDbType.SmallInt) : sqlParametro.Value = Me._NOMINA_NUMERO_SEMANA_ACTUAL
            sqlParametro = .Parameters.Add("@NOMINA_EQUIVALENCIA_JORNAL_HORAS", SqlDbType.SmallInt) : sqlParametro.Value = Me._NOMINA_EQUIVALENCIA_JORNAL_HORAS
            sqlParametro = .Parameters.Add("@NOMINA_EDAD_MINIMA_TRABAJADORES", SqlDbType.SmallInt) : sqlParametro.Value = Me._NOMINA_EDAD_MINIMA_TRABAJADORES
            sqlParametro = .Parameters.Add("@NOMINA_RUTA_FOTOS_TRABAJADORES", SqlDbType.NVarChar, 150) : sqlParametro.Value = Me._NOMINA_RUTA_FOTOS_TRABAJADORES.ToUpper
            sqlParametro = .Parameters.Add("@NOMINA_RUTA_IDSE", SqlDbType.NVarChar, 150) : sqlParametro.Value = Me._NOMINA_RUTA_IDSE.ToUpper
            sqlParametro = .Parameters.Add("@NOMINA_TIPO_TRABAJADOR", SqlDbType.Char, 1) : sqlParametro.Value = Me._NOMINA_TIPO_TRABAJADOR.ToUpper
            sqlParametro = .Parameters.Add("@NOMINA_TIPO_SALARIO", SqlDbType.Char, 1) : sqlParametro.Value = Me._NOMINA_TIPO_SALARIO.ToUpper
            sqlParametro = .Parameters.Add("@NOMINA_REDUCCION_TIPO_PAGO", SqlDbType.Char, 1) : sqlParametro.Value = Me._NOMINA_REDUCCION_TIPO_PAGO.ToUpper
            sqlParametro = .Parameters.Add("@NOMINA_GUIA", SqlDbType.NVarChar, 5) : sqlParametro.Value = Me._NOMINA_GUIA.ToUpper
            sqlParametro = .Parameters.Add("@NOMINA_IDENTIFICADOR_FORMATO", SqlDbType.Char, 1) : sqlParametro.Value = Me._NOMINA_IDENTIFICADOR_FORMATO.ToUpper
            'sqlParametro = .Parameters.Add("@NOMINA_ID_NOMINA_TEMPORADA_ACTIVA", SqlDbType.SmallInt) : sqlParametro.Value = Me._NOMINA_ID_NOMINA_TEMPORADA_ACTIVA
            sqlParametro = .Parameters.Add("@ACCION", SqlDbType.NVarChar, 15) : sqlParametro.Value = "INSERTAR".ToUpper

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                Me._ID_SIS_EMPRESA_NOMINA = CInt(.Parameters("@ID_SIS_EMPRESA_NOMINA").Value)
                bResultado = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "Insertar", ex)
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
        Dim iCodigoPlaza As Integer
        If Usuario.Codigo_Plaza = 0 Then
            iCodigoPlaza = 1
        Else
            iCodigoPlaza = Usuario.Codigo_Plaza
        End If
        Dim cmd As New SqlCommand(Me._QuerySelect & " WHERE E.CODIGO_PLAZA=" & iCodigoPlaza, Me._Conexion)
        Dim dReader As SqlDataReader

        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()

                dReader = .ExecuteReader()
                If dReader.Read Then
                    Me._ID_SIS_EMPRESA_NOMINA = CInt(dReader("ID_SIS_EMPRESA_NOMINA"))
                    Me._CODIGO_PLAZA = CInt(dReader("CODIGO_PLAZA"))
                    Me._NOMINA_SUELDO_DIARIO = CDbl(dReader("NOMINA_SUELDO_DIARIO_INTEGRADO"))
                    Me._NOMINA_NUMERO_REGISTRO_PATRONAL = "" & dReader("NOMINA_NUMERO_REGISTRO_PATRONAL").ToString
                    Me._NOMINA_NUMERO_SEMANA_ACTUAL = CInt(dReader("NOMINA_NUMERO_SEMANA_ACTUAL"))
                    Me._NOMINA_EQUIVALENCIA_JORNAL_HORAS = CInt(dReader("NOMINA_EQUIVALENCIA_JORNAL_HORAS"))
                    Me._NOMINA_RUTA_FOTOS_TRABAJADORES = "" & dReader("NOMINA_RUTA_FOTOS_TRABAJADORES").ToString
                    Me._NOMINA_EDAD_MINIMA_TRABAJADORES = CInt(dReader("NOMINA_EDAD_MINIMA_TRABAJADORES"))
                    Me._NOMINA_RUTA_IDSE = "" & dReader("NOMINA_RUTA_IDSE").ToString
                    Me._NOMINA_TIPO_TRABAJADOR = "" & dReader("NOMINA_TIPO_TRABAJADOR").ToString
                    Me._NOMINA_TIPO_SALARIO = "" & dReader("NOMINA_TIPO_SALARIO").ToString
                    Me._NOMINA_REDUCCION_TIPO_PAGO = "" & dReader("NOMINA_REDUCCION_TIPO_PAGO").ToString
                    Me._NOMINA_GUIA = "" & dReader("NOMINA_GUIA").ToString
                    Me._NOMINA_IDENTIFICADOR_FORMATO = "" & dReader("NOMINA_IDENTIFICADOR_FORMATO").ToString
                    Me._RUTA_ALTAS_DISPERSIONES = "" & dReader("RUTA_ALTAS_DISPERSIONES").ToString
                    Me._CONEXION_SUA_EVENTUALES = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & dReader("RUTA_DB_EVENTUALES").ToString & ";Persist Security Info=False;Jet OLEDB:Database Password=S5@N52V49;"
                    Me._IMPORTE_PUNTUALIDAD_DESPENSA = CDbl(dReader("IMPORTE_PUNTUALIDAD_DESPENSA").ToString)
                    Me._NOMINA_DIA_INICIO_SEMANA = CInt(dReader("NOMINA_DIA_INICIO_SEMANA"))
                    Me._NOMINA_ID_NOMINA_TEMPORADA_ACTIVA = CInt(dReader("NOMINA_ID_NOMINA_TEMPORADA_ACTIVA"))
                    Me._MOSTRAR_CULTIVO = "" & dReader("MOSTRAR_CULTIVO").ToString
                    dReader.Close()
                    bResultado = True
                End If

            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "Consultar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
            End Try
        End With

        Return bResultado
    End Function

    Public Function ObtenerRutaSua() As DataTable
        Dim dTable As New DataTable("detalle"), da As SqlDataAdapter
        Dim sSQL As String
        sSQL = "SELECT NOMBRE, RUTA_DB FROM SIS_EMPRESA_NOMINA_LISTA_DBS_SUA WHERE CODIGO_PLAZA= " & Plaza.CODIGO_PLAZA.ToString

        Try
            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dTable)
            da.Dispose()
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerRutaSua", ex)
        End Try

        Return dTable
    End Function

    'Public Function ObtenerTemporadas() As DataTable
    '    Dim dTable As New DataTable("detalle"), da As SqlDataAdapter
    '    Dim sSQL As String
    '    sSQL = "SELECT ID_NOMINA_TEMPORADA,NOMBRE_TEMPORADA FROM NOMINA_TEMPORADAS WHERE CODIGO_PLAZA= " & Plaza.CODIGO_PLAZA.ToString

    '    Try
    '        da = New SqlDataAdapter(sSQL, Me._Conexion)
    '        da.Fill(dTable)
    '        da.Dispose()
    '    Catch ex As Exception
    '        HandleError(Me._Nombre_Catalogo, "ObtenerTemporadas", ex)
    '    End Try

    '    ObtenerTemporadas = dTable
    'End Function
#End Region

End Class

