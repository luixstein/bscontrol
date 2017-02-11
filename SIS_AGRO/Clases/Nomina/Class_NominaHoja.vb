Option Strict On
Imports System.Data
Imports System.Data.SqlClient

Public Class Class_NominaHoja

#Region "Campos"

#Region "Campos de la tabla"
    Private _ID_NOMINA_HOJA As Integer
    Private _ID_NOMINA_DIA As Integer
    Private _NUMERO_HOJA As Integer
    Private _CODIGO_CENTRO_COSTO As Integer
    Private _CODIGO_CULTIVO As String
    Private _CODIGO_MERCADO As String
    Private _CODIGO_LOTE As String
    Private _CODIGO_ACTIVIDAD As Integer
    Private _CODIGO_PUNTO_PAGO As Integer
    Private _CODIGO_TIPO_PERCEPCION As Integer
    Private _TOTAL_PERCEPCIONES As Double
    Private _HORAS_POR_TRABAJADOR As Double
    Private _TOTAL_JORNALES As Double
    Private _FECHA_SERVIDOR As Date
    Private _CODIGO_USUARIO_GRABO As Integer
    Private _NOMBRE_USUARIO_GRABO As String
    Private _TURNO As String
    Private _TOTAL_CAJAS_CORTADAS As Double
#End Region

#Region "Campos ligados a la tabla"
    Private _Existe As Boolean 'lectura
#End Region

#Region "Clase Detalle"
    Public oHojaPercepcion As New Class_NominaHojaPercepciones
#End Region

#Region "Campos públicos"

#End Region

#Region "Campos privados"

#End Region

#Region "Campos de sistema"
    Private _Nombre_Clase As String
    Private _Conexion As SqlConnection
    Private _QuerySelect As String
    Private _QueryOrder As String
#End Region
#End Region

#Region "Propiedades"

#Region "Propiedades Campos de la tabla"
    Public Property ID_NOMINA_HOJA() As Integer
        Get
            Return Me._ID_NOMINA_HOJA
        End Get
        Set(ByVal Value As Integer)
            Me._ID_NOMINA_HOJA = Value
        End Set
    End Property

    Public Property ID_NOMINA_DIA() As Integer
        Get
            Return Me._ID_NOMINA_DIA
        End Get
        Set(ByVal Value As Integer)
            Me._ID_NOMINA_DIA = Value
        End Set
    End Property

    Public Property NUMERO_HOJA() As Integer
        Get
            Return Me._NUMERO_HOJA
        End Get
        Set(ByVal Value As Integer)
            Me._NUMERO_HOJA = Value
        End Set
    End Property

    Public Property CODIGO_CENTRO_COSTO() As Integer
        Get
            Return Me._CODIGO_CENTRO_COSTO
        End Get
        Set(ByVal Value As Integer)
            Me._CODIGO_CENTRO_COSTO = Value
        End Set
    End Property

    Public Property CODIGO_CULTIVO() As String
        Get
            Return Me._CODIGO_CULTIVO
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_CULTIVO = Value
        End Set
    End Property

    Public Property CODIGO_MERCADO() As String
        Get
            Return Me._CODIGO_MERCADO
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_MERCADO = Value
        End Set
    End Property

    Public Property CODIGO_LOTE() As String
        Get
            Return Me._CODIGO_LOTE
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_LOTE = Value
        End Set
    End Property

    Public Property CODIGO_ACTIVIDAD() As Integer
        Get
            Return Me._CODIGO_ACTIVIDAD
        End Get
        Set(ByVal Value As Integer)
            Me._CODIGO_ACTIVIDAD = Value
        End Set
    End Property

    Public Property CODIGO_PUNTO_PAGO() As Integer
        Get
            Return Me._CODIGO_PUNTO_PAGO
        End Get
        Set(ByVal Value As Integer)
            Me._CODIGO_PUNTO_PAGO = Value
        End Set
    End Property

    Public Property CODIGO_TIPO_PERCEPCION() As Integer
        Get
            Return Me._CODIGO_TIPO_PERCEPCION
        End Get
        Set(ByVal Value As Integer)
            Me._CODIGO_TIPO_PERCEPCION = Value
        End Set
    End Property

    Public Property TOTAL_PERCEPCIONES() As Double
        Get
            Return Me._TOTAL_PERCEPCIONES
        End Get
        Set(ByVal value As Double)
            Me._TOTAL_PERCEPCIONES = value
        End Set
    End Property

    Public Property HORAS_POR_TRABAJADOR() As Double
        Get
            Return Me._HORAS_POR_TRABAJADOR
        End Get
        Set(ByVal value As Double)
            Me._HORAS_POR_TRABAJADOR = value
        End Set
    End Property

    Public Property TOTAL_JORNALES() As Double
        Get
            Return Me._TOTAL_JORNALES
        End Get
        Set(ByVal value As Double)
            Me._TOTAL_JORNALES = value
        End Set
    End Property

    Public Property FECHA_SERVIDOR() As Date
        Get
            Return Me._FECHA_SERVIDOR
        End Get
        Set(ByVal Value As Date)
            Me._FECHA_SERVIDOR = Value
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

    Public Property TURNO() As String
        Get
            Return Me._TURNO
        End Get
        Set(ByVal value As String)
            Me._TURNO = value
        End Set
    End Property

    Public Property TOTAL_CAJAS_CORTADAS() As Double
        Get
            Return Me._TOTAL_CAJAS_CORTADAS
        End Get
        Set(ByVal value As Double)
            Me._TOTAL_CAJAS_CORTADAS = value
        End Set
    End Property
#End Region

#Region "Propiedades de campos ligados a la tabla"
    Public ReadOnly Property Existe() As Boolean
        Get
            Return Me._Existe
        End Get
    End Property
#End Region

#Region "Propiedades públicos"
    'Public ReadOnly Property CODIGO_MODULO() As String
    '    Get
    '        Return "" 'NOMINA
    '    End Get
    'End Property
#End Region

#Region "Propiedades de campos privados"

#End Region

#Region "Propiedades de campos de sistema"
    Public ReadOnly Property Nombre_Clase() As String
        Get
            Me._Nombre_Clase = "Class_NominaHoja"
            Return Me._Nombre_Clase
        End Get
    End Property
#End Region
#End Region

#Region "Constructor y destructor"
    Public Sub New()
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "SELECT H.*,U.NOMBRE_USUARIO NOMBRE_USUARIO_GRABO FROM NOMINA_HOJAS H " & _
        "INNER JOIN SIS_USUARIOS U ON(H.CODIGO_USUARIO_GRABO=U.CODIGO_USUARIO) "
        Me._QueryOrder = " ORDER BY H.ID_NOMINA_HOJA "

        Me.oHojaPercepcion = New Class_NominaHojaPercepciones
    End Sub

    Public Sub New(ByVal iIdHoja As Integer)
        Me.New()
        Me._ID_NOMINA_HOJA = iIdHoja
        Try
            If Me.Consultar = True Then
                Me._Existe = True
                'Else
                '   Throw New Exception("La cuenta bancaria no existe.")
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "New", ex)
        End Try
    End Sub

    Protected Overrides Sub Finalize()
        'Me._Conexion.Dispose()
        MyBase.Finalize()
    End Sub
#End Region

#Region "Métodos y procedimientos"

    Public Function Actualizar(Optional ByVal sEliminaDetalle As String = "1") As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_NOMINA_PERCEPCIONES_GRABA_HOJA"

            sqlParametro = .Parameters.Add("@ID_NOMINA_HOJA", SqlDbType.Int) : sqlParametro.Value = Me._ID_NOMINA_HOJA
            sqlParametro = .Parameters.Add("@ID_NOMINA_DIA", SqlDbType.Int) : sqlParametro.Value = Me._ID_NOMINA_DIA
            sqlParametro = .Parameters.Add("@NUMERO_HOJA", SqlDbType.SmallInt) : sqlParametro.Value = Me._NUMERO_HOJA
            sqlParametro = .Parameters.Add("@CODIGO_CENTRO_COSTO", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_CENTRO_COSTO
            sqlParametro = .Parameters.Add("@CODIGO_CULTIVO", SqlDbType.NVarChar, 4) : sqlParametro.Value = "" & Me._CODIGO_CULTIVO
            sqlParametro = .Parameters.Add("@CODIGO_MERCADO", SqlDbType.Char, 1) : sqlParametro.Value = "" & Me._CODIGO_MERCADO
            sqlParametro = .Parameters.Add("@CODIGO_LOTE", SqlDbType.NVarChar, 2) : sqlParametro.Value = "" & Me._CODIGO_LOTE
            sqlParametro = .Parameters.Add("@CODIGO_ACTIVIDAD", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_ACTIVIDAD
            sqlParametro = .Parameters.Add("@CODIGO_PUNTO_PAGO", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_PUNTO_PAGO
            sqlParametro = .Parameters.Add("@CODIGO_TIPO_PERCEPCION", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_TIPO_PERCEPCION
            sqlParametro = .Parameters.Add("@TOTAL_PERCEPCIONES", SqlDbType.Money) : sqlParametro.Value = Me._TOTAL_PERCEPCIONES
            sqlParametro = .Parameters.Add("@HORAS_POR_TRABAJADOR", SqlDbType.Money) : sqlParametro.Value = Me._HORAS_POR_TRABAJADOR
            sqlParametro = .Parameters.Add("@TOTAL_JORNALES", SqlDbType.Money) : sqlParametro.Value = Me._TOTAL_JORNALES
            sqlParametro = .Parameters.Add("@TOTAL_CAJAS_CORTADAS", SqlDbType.Decimal) : sqlParametro.Value = Me._TOTAL_CAJAS_CORTADAS
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO_GRABO", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Usuario
            sqlParametro = .Parameters.Add("@ACCION", SqlDbType.NVarChar, 20) : sqlParametro.Value = "ACTUALIZAR"
            sqlParametro = .Parameters.Add("@ELIMINA_DETALLE", SqlDbType.Char, 1) : sqlParametro.Value = sEliminaDetalle
            sqlParametro = .Parameters.Add("@TURNO", SqlDbType.NVarChar, 50) : sqlParametro.Value = "" & Me._TURNO

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "Actualizar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With

        Return bResultado
    End Function

    Public Function Insertar(Optional ByVal bGenerarSiguienteHoja As Boolean = False) As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_NOMINA_PERCEPCIONES_GRABA_HOJA"

            sqlParametro = .Parameters.Add("@ID_NOMINA_HOJA", SqlDbType.Int) : sqlParametro.Direction = ParameterDirection.InputOutput : sqlParametro.Value = Me._ID_NOMINA_HOJA
            sqlParametro = .Parameters.Add("@ID_NOMINA_DIA", SqlDbType.Int) : sqlParametro.Value = Me._ID_NOMINA_DIA
            sqlParametro = .Parameters.Add("@NUMERO_HOJA", SqlDbType.SmallInt) : sqlParametro.Direction = ParameterDirection.InputOutput : sqlParametro.Value = Me._NUMERO_HOJA
            sqlParametro = .Parameters.Add("@CODIGO_CENTRO_COSTO", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_CENTRO_COSTO
            sqlParametro = .Parameters.Add("@CODIGO_CULTIVO", SqlDbType.NVarChar, 4) : sqlParametro.Value = "" & Me._CODIGO_CULTIVO
            sqlParametro = .Parameters.Add("@CODIGO_MERCADO", SqlDbType.Char, 1) : sqlParametro.Value = "" & Me._CODIGO_MERCADO
            sqlParametro = .Parameters.Add("@CODIGO_LOTE", SqlDbType.NVarChar, 2) : sqlParametro.Value = "" & Me._CODIGO_LOTE
            sqlParametro = .Parameters.Add("@CODIGO_ACTIVIDAD", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_ACTIVIDAD
            sqlParametro = .Parameters.Add("@CODIGO_PUNTO_PAGO", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_PUNTO_PAGO
            sqlParametro = .Parameters.Add("@CODIGO_TIPO_PERCEPCION", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_TIPO_PERCEPCION
            sqlParametro = .Parameters.Add("@TOTAL_PERCEPCIONES", SqlDbType.Money) : sqlParametro.Value = Me._TOTAL_PERCEPCIONES
            sqlParametro = .Parameters.Add("@HORAS_POR_TRABAJADOR", SqlDbType.Money) : sqlParametro.Value = Me._HORAS_POR_TRABAJADOR
            sqlParametro = .Parameters.Add("@TOTAL_JORNALES", SqlDbType.Money) : sqlParametro.Value = Me._TOTAL_JORNALES
            sqlParametro = .Parameters.Add("@TOTAL_CAJAS_CORTADAS", SqlDbType.Decimal) : sqlParametro.Value = Me._TOTAL_CAJAS_CORTADAS
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO_GRABO", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Usuario
            sqlParametro = .Parameters.Add("@ACCION", SqlDbType.NVarChar, 20) : sqlParametro.Value = "INSERTAR"
            sqlParametro = .Parameters.Add("@ELIMINA_DETALLE", SqlDbType.Char, 1) : sqlParametro.Value = "0"
            sqlParametro = .Parameters.Add("@TURNO", SqlDbType.NVarChar, 50) : sqlParametro.Value = "" & Me._TURNO
            If bGenerarSiguienteHoja = True Then
                sqlParametro = .Parameters.Add("@GENERAR_SIGUIENTE_NUMERO_HOJA", SqlDbType.Char, 1) : sqlParametro.Value = "1"
            Else
                sqlParametro = .Parameters.Add("@GENERAR_SIGUIENTE_NUMERO_HOJA", SqlDbType.Char, 1) : sqlParametro.Value = "0"
            End If

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
                Me._ID_NOMINA_HOJA = CInt(.Parameters("@ID_NOMINA_HOJA").Value)
                Me._NUMERO_HOJA = CInt(.Parameters("@NUMERO_HOJA").Value)
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "Insertar", ex)
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
        Dim cmd As New SqlCommand(Me._QuerySelect & " WHERE H.ID_NOMINA_HOJA=" & Me._ID_NOMINA_HOJA.ToString & " ", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()
                If dReader.Read Then
                    Me._ID_NOMINA_HOJA = CInt(dReader("ID_NOMINA_HOJA"))
                    Me._ID_NOMINA_DIA = CInt(dReader("ID_NOMINA_DIA"))
                    Me._NUMERO_HOJA = CInt(dReader("NUMERO_HOJA"))
                    Me._CODIGO_CENTRO_COSTO = CInt(dReader("CODIGO_CENTRO_COSTO"))
                    Me._CODIGO_CULTIVO = "" & dReader("CODIGO_CULTIVO").ToString
                    Me._CODIGO_MERCADO = "" & dReader("CODIGO_MERCADO").ToString
                    Me._CODIGO_LOTE = "" & dReader("CODIGO_LOTE").ToString
                    Me._CODIGO_ACTIVIDAD = CInt(dReader("CODIGO_ACTIVIDAD"))
                    Me._CODIGO_PUNTO_PAGO = CInt(dReader("CODIGO_PUNTO_PAGO"))
                    Me._CODIGO_TIPO_PERCEPCION = CInt(dReader("CODIGO_TIPO_PERCEPCION"))
                    Me._TOTAL_PERCEPCIONES = CDbl(dReader("TOTAL_PERCEPCIONES"))
                    Me._HORAS_POR_TRABAJADOR = CDbl(dReader("HORAS_POR_TRABAJADOR"))
                    Me._TOTAL_JORNALES = CDbl(dReader("TOTAL_JORNALES"))
                    Me._FECHA_SERVIDOR = CDate(dReader("FECHA_SERVIDOR"))
                    Me._CODIGO_USUARIO_GRABO = CInt(dReader("CODIGO_USUARIO_GRABO"))
                    Me._NOMBRE_USUARIO_GRABO = dReader("NOMBRE_USUARIO_GRABO").ToString
                    Me._TURNO = dReader("TURNO").ToString
                    Me._TOTAL_CAJAS_CORTADAS = CDbl(dReader("TOTAL_CAJAS_CORTADAS"))

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

    Public Function Eliminar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_NOMINA_PERCEPCIONES_ELIMINAR_HOJA"

            sqlParametro = .Parameters.Add("@ID_NOMINA_HOJA", SqlDbType.Int) : sqlParametro.Value = Me._ID_NOMINA_HOJA

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "Eliminar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With

        Return bResultado
    End Function

    'Public Function GrabaPercepcion(ByVal sCodigoTrabajador As String, ByVal dPercepcion As Double, ByVal iCodigoPercepcion As Integer, ByVal sAccion As String, Optional ByVal iIdPercepcion As Integer = 0) As Boolean
    '    Dim cmd As New SqlCommand
    '    Dim sqlParametro As SqlParameter
    '    With cmd
    '        .Connection = Me._Conexion
    '        .CommandTimeout = 0
    '        .CommandType = CommandType.StoredProcedure
    '        .CommandText = "MP_NOMINA_PERCEPCIONES_GRABA_PERCEPCION"

    '        sqlParametro = .Parameters.Add("@ID_NOMINA_PERCEPCION", SqlDbType.Int) : sqlParametro.Value = iIdPercepcion
    '        sqlParametro = .Parameters.Add("@ID_NOMINA_HOJA", SqlDbType.Int) : sqlParametro.Value = Me._ID_NOMINA_HOJA
    '        sqlParametro = .Parameters.Add("@CODIGO_TRABAJADOR", SqlDbType.NVarChar, 10) : sqlParametro.Value = "" & sCodigoTrabajador
    '        sqlParametro = .Parameters.Add("@PERCEPCION", SqlDbType.Money) : sqlParametro.Value = dPercepcion
    '        sqlParametro = .Parameters.Add("@CODIGO_PERCEPCION", SqlDbType.SmallInt) : sqlParametro.Value = iCodigoPercepcion
    '        sqlParametro = .Parameters.Add("@ACCION", SqlDbType.NVarChar, 10) : sqlParametro.Value = sAccion
    '        Try
    '            Me._Conexion.Open()
    '            .ExecuteNonQuery()
    '            GrabaPercepcion = True
    '        Catch ex As Exception
    '            HandleError(Me.Nombre_Clase, "GrabaPercepcion", ex)
    '        Finally
    '            Me._Conexion.Close()
    '            cmd.Dispose()
    '            sqlParametro = Nothing
    '        End Try

    '    End With
    'End Function

    Public Function ObtenerDetalle() As DataTable
        Dim dTabla As New DataTable("detalle"), da As SqlDataAdapter
        Dim sSQL As String
        sSQL = "SELECT P.CODIGO_TRABAJADOR,T.NOMBRE_TRABAJADOR,T.APELLIDO_PATERNO,T.APELLIDO_MATERNO,E.NOMBRE,P.CODIGO_PERCEPCION,E.REEMBOLSABLE,P.PERCEPCION,P.ID_NOMINA_PERCEPCION,'1' CONFIRMAR,P.JORNALES,P.CAJAS_CORTADAS " & _
        "FROM NOMINA_HOJAS_PERCEPCIONES P " & _
        "INNER JOIN NOMINA_CAT_TRABAJADORES T ON(P.CODIGO_TRABAJADOR=T.CODIGO_TRABAJADOR) " & _
        "INNER JOIN NOMINA_CAT_PERCEPCIONES E ON(P.CODIGO_PERCEPCION=E.CODIGO_PERCEPCION) " & _
        "WHERE ID_NOMINA_HOJA= " & Me._ID_NOMINA_HOJA & _
        " ORDER BY P.ID_NOMINA_PERCEPCION "
        Try
            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dTabla)
            da.Dispose()
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "ObtenerDetalle", ex)
        End Try
        Return dTabla
    End Function

    Public Function ObtenerElementos(ByVal iIdDida As Integer) As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dsNominaHojas As New SqlDataAdapter("SELECT ISNULL(H.ID_NOMINA_HOJA,1) ID_NOMINA_HOJA, ISNULL(H.NUMERO_HOJA,1) NUMERO_HOJA FROM NOMINA_HOJAS H WHERE H.ID_NOMINA_DIA=" & iIdDida.ToString & Me._QueryOrder, Me._Conexion)
        Try
            dsNominaHojas.Fill(dTable)
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "ObtenerElementos", ex)
        Finally
            dsNominaHojas.Dispose()
        End Try
        Return dTable
    End Function

#End Region

End Class
