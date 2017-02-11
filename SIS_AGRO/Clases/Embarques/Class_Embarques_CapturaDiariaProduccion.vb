Option Strict On
Imports System.Data
Imports System.Data.SqlClient

Public Class Class_Embarques_CapturaDiariaProduccion

#Region "Campos"

#Region "Campos de la tabla"
    Private _ID_EMB_CAPTURA_DIARIA_PRODUCCION As Integer
    Private _FECHA As Date
    Private _CODIGO_CULTIVO As String
    Private _CODIGO_TIPO_TAMAÑO As Integer
    Private _CODIGO_TIPO_ENVASE As Integer
    Private _CODIGO_USUARIO_GRABO As Integer
    Private _NOMBRE_USUARIO_GRABO As String
    Private _CANTIDAD_BULTOS As Integer

#End Region

#Region "Campos ligados a la tabla"
    Private _Existe As Boolean 'lectura
#End Region

#Region "Campos públicos"
    'Public oEmbarqueDetalle As Class_Embarques_EmbarqueDetalle
#End Region

#Region "Campos privados"
    Private _oDocumento As Class_CatDocumentos
#End Region

#Region "Campos de sistema"
    Private _Nombre_Clase As String
    Private _Nombre_Formato As String
    Private _Nombre_Factura As String
    Private _Nombre_Manifiesto As String
    Private _Nombre_Control_Embarques As String
    Private _Conexion As SqlConnection
    Private _QuerySelect As String
    Private _QueryOrder As String
#End Region
#End Region

#Region "Propiedades"

#Region "Propiedades Campos de la tabla"
    Public Property ID_EMB_CAPTURA_DIARIA_PRODUCCION() As Integer
        Get
            Return Me._ID_EMB_CAPTURA_DIARIA_PRODUCCION
        End Get
        Set(ByVal Value As Integer)
            Me._ID_EMB_CAPTURA_DIARIA_PRODUCCION = Value
        End Set
    End Property

    Public Property FECHA() As Date
        Get
            Return Me._FECHA
        End Get
        Set(ByVal Value As Date)
            Me._FECHA = Value
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

    Public Property CODIGO_TIPO_TAMAÑO() As Integer
        Get
            Return Me._CODIGO_TIPO_TAMAÑO
        End Get
        Set(ByVal Value As Integer)
            Me._CODIGO_TIPO_TAMAÑO = Value
        End Set
    End Property

    Public Property CODIGO_TIPO_ENVASE() As Integer
        Get
            Return Me._CODIGO_TIPO_ENVASE
        End Get
        Set(ByVal Value As Integer)
            Me._CODIGO_TIPO_ENVASE = Value
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

    Public Property CANTIDAD_BULTOS() As Integer
        Get
            Return Me._CANTIDAD_BULTOS
        End Get
        Set(ByVal value As Integer)
            Me._CANTIDAD_BULTOS = value
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
    '        Return "EMB"
    '    End Get
    'End Property
#End Region

#Region "Propiedades de campos privados"

#End Region

#Region "Propiedades de campos de sistema"
    Public ReadOnly Property Nombre_Clase() As String
        Get
            Return Me._Nombre_Clase
        End Get
    End Property

    Public Property Nombre_Formato() As String
        Get
            Return Me._Nombre_Formato
        End Get
        Set(ByVal value As String)
            Me._Nombre_Formato = value
        End Set
    End Property

#End Region

#End Region

#Region "Constructor y destructor"
    Public Sub New()
        Me._Nombre_Clase = "EMB_CAPTURA_DIARIA_PRODUCCION"
        ' Me._Nombre_Control_Embarques = "RPT_FORMATO_EMBARQUES_DISTRIBUCION_CARGA"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "SELECT G.*,U1.NOMBRE_USUARIO NOMBRE_USUARIO_GRABO FROM EMB_CAPTURA_DIARIA_PRODUCCION G " & _
                          "INNER JOIN SIS_USUARIOS U1 ON(G.CODIGO_USUARIO_GRABO=U1.CODIGO_USUARIO) "
        Me._QueryOrder = " ORDER BY G.CODIGO_CULTIVO "
    End Sub

    Public Sub New(ByVal sFecha As Date, ByVal sCodigoCultivo As String)
        Me.New()
        Try
            Me._FECHA = sFecha
            Me._CODIGO_CULTIVO = sCodigoCultivo
            If Me.Consultar = True Then
                Me._Existe = True
            End If
        Catch ex As Exception
            HandleError(Me._Nombre_Clase, "New", ex)
        End Try
    End Sub

    Protected Overrides Sub Finalize()
        'Me._Conexion.Dispose()
        MyBase.Finalize()
    End Sub
#End Region

#Region "Métodos y procedimientos"

    Public Function Actualizar() As Boolean
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_EMB_CAPTURA_DIARIA_PRODUCCION_GRABA"

            sqlParametro = .Parameters.Add("@FECHA", SqlDbType.DateTime) : sqlParametro.Value = "" & Me._FECHA
            sqlParametro = .Parameters.Add("@CODIGO_CULTIVO", SqlDbType.NVarChar, 4) : sqlParametro.Value = "" & Me._CODIGO_CULTIVO
            sqlParametro = .Parameters.Add("@CODIGO_TIPO_TAMAÑO", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_TIPO_TAMAÑO
            sqlParametro = .Parameters.Add("@CODIGO_TIPO_ENVASE", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_TIPO_ENVASE
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO_GRABO", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Usuario
            sqlParametro = .Parameters.Add("@CANTIDAD_BULTOS", SqlDbType.Int) : sqlParametro.Value = Me._CANTIDAD_BULTOS
            sqlParametro = .Parameters.Add("@ACCION", SqlDbType.NVarChar, 20) : sqlParametro.Value = "ACTUALIZAR"

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                Actualizar = True
            Catch ex As Exception
                HandleError(Me._Nombre_Clase, "ActualizarOrdenCompra", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try

        End With
    End Function

    Public Function Insertar() As Boolean
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_EMB_CAPTURA_DIARIA_PRODUCCION_GRABA"

            sqlParametro = .Parameters.Add("@FECHA", SqlDbType.DateTime) : sqlParametro.Value = "" & Me._FECHA
            sqlParametro = .Parameters.Add("@CODIGO_CULTIVO", SqlDbType.NVarChar, 4) : sqlParametro.Value = "" & Me._CODIGO_CULTIVO
            sqlParametro = .Parameters.Add("@CODIGO_TIPO_TAMAÑO", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_TIPO_TAMAÑO
            sqlParametro = .Parameters.Add("@CODIGO_TIPO_ENVASE", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_TIPO_ENVASE
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO_GRABO", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Usuario
            sqlParametro = .Parameters.Add("@CANTIDAD_BULTOS", SqlDbType.Int) : sqlParametro.Value = Me._CANTIDAD_BULTOS
            sqlParametro = .Parameters.Add("@ACCION", SqlDbType.NVarChar, 20) : sqlParametro.Value = "INSERTAR"
            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                Insertar = True
            Catch ex As Exception
                HandleError(Me._Nombre_Clase, "Insertar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try

        End With
    End Function

    Public Function Consultar() As Boolean
        Dim cmd As New SqlCommand(Me._QuerySelect & " WHERE G.FECHA ='" & sReplace(Me._FECHA.ToString) & "' AND CULTIVO=" & sReplace(Me._CODIGO_CULTIVO.ToString), Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()
                If dReader.Read Then
                    Me._ID_EMB_CAPTURA_DIARIA_PRODUCCION = CInt(dReader("ID_EMB_CAPTURA_DIARIA_PRODUCCION"))
                    Me._FECHA = CDate(dReader("FECHA"))
                    Me._CODIGO_CULTIVO = dReader("CODIGO_CULTIVO").ToString
                    Me._CODIGO_TIPO_TAMAÑO = CInt(dReader("CODIGO_TIPO_TAMAÑO"))
                    Me._CODIGO_TIPO_ENVASE = CInt(dReader("CODIGO_TIPO_ENVASE"))
                    Me._CODIGO_USUARIO_GRABO = CInt(dReader("CODIGO_USUARIO_GRABO"))
                    Me._NOMBRE_USUARIO_GRABO = dReader("NOMBRE_USUARIO_GRABO").ToString
                    If txtLEN("" & dReader("CANTIDAD_BULTOS").ToString) = False Then
                        Me._CANTIDAD_BULTOS = 0
                    Else
                        Me._CANTIDAD_BULTOS = CInt(dReader("CANTIDAD_BULTOS").ToString)
                    End If
                    Consultar = True
                End If
                dReader.Close()
            Catch ex As Exception
                HandleError(Me._Nombre_Clase, "Consultar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
            End Try
        End With
    End Function

    Public Function Eliminar() As Boolean
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_EMB_CAPTURA_DIARIA_PRODUCCION_GRABA"

            sqlParametro = .Parameters.Add("@FECHA", SqlDbType.DateTime) : sqlParametro.Value = "" & Me._FECHA
            sqlParametro = .Parameters.Add("@CODIGO_CULTIVO", SqlDbType.NVarChar, 4) : sqlParametro.Value = "" & Me._CODIGO_CULTIVO
            sqlParametro = .Parameters.Add("@CODIGO_TIPO_TAMAÑO", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_TIPO_TAMAÑO
            sqlParametro = .Parameters.Add("@CODIGO_TIPO_ENVASE", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_TIPO_ENVASE
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO_GRABO", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Usuario
            sqlParametro = .Parameters.Add("@CANTIDAD_BULTOS", SqlDbType.Int) : sqlParametro.Value = Me._CANTIDAD_BULTOS
            sqlParametro = .Parameters.Add("@ACCION", SqlDbType.NVarChar, 20) : sqlParametro.Value = "ELIMINAR"

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                Eliminar = True
            Catch ex As Exception
                HandleError(Me._Nombre_Clase, "Eliminar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try

        End With
    End Function

    Public Function ObtenerDetalle(ByVal sCodigoCultivo As String, ByVal sFecha As String) As DataTable
        Dim dTabla As New DataTable("detalle"), da As SqlDataAdapter
        Dim sSQL As String
        'sSQL = "SELECT CODIGO_TIPO_TAMAÑO,NOMBRE_TIPO_TAMAÑO,CODIGO_TIPO_ENVASE,NOMBRE_TIPO_ENVASE, '' PRODUCCION FROM VW_CAT_PRODUCTOS_AGRICOLAS_PRODUCCION WHERE CODIGO_CULTIVO='" & sCodigoCultivo & "' " & _
        '" ORDER BY NOMBRE_TIPO_TAMAÑO "

        sSQL = "SELECT DISTINCT A.CODIGO_TIPO_TAMAÑO,A.NOMBRE_TIPO_TAMAÑO,A.CODIGO_TIPO_ENVASE,A.NOMBRE_TIPO_ENVASE, " & _
               "CASE WHEN ISNULL((SELECT CANTIDAD_BULTOS FROM EMB_CAPTURA_DIARIA_PRODUCCION " & _
               "WHERE CODIGO_CULTIVO='" & sCodigoCultivo.ToString & "' AND CODIGO_TIPO_TAMAÑO=D.CODIGO_TIPO_TAMAÑO AND CODIGO_TIPO_ENVASE=D.CODIGO_TIPO_ENVASE AND FECHA='" & sFecha.ToString & "'),'0')<>0 THEN " & _
               "(SELECT CANTIDAD_BULTOS FROM EMB_CAPTURA_DIARIA_PRODUCCION WHERE CODIGO_CULTIVO='" & sCodigoCultivo.ToString & "' " & _
               "AND CODIGO_TIPO_TAMAÑO=D.CODIGO_TIPO_TAMAÑO AND CODIGO_TIPO_ENVASE=D.CODIGO_TIPO_ENVASE AND FECHA='" & sFecha.ToString & "') END AS PRODUCCION " & _
               "FROM VW_CAT_PRODUCTOS_AGRICOLAS_PRODUCCION A " & _
               "LEFT JOIN EMB_CAPTURA_DIARIA_PRODUCCION D " & _
               "ON( A.CODIGO_TIPO_TAMAÑO=D.CODIGO_TIPO_TAMAÑO AND A.CODIGO_TIPO_ENVASE=D.CODIGO_TIPO_ENVASE )" & _
               "WHERE  A.CODIGO_CULTIVO='" & sCodigoCultivo.ToString & "' " & _
               "ORDER BY A.NOMBRE_TIPO_TAMAÑO "
        Try
            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dTabla)
            da.Dispose()
        Catch ex As Exception
            HandleError(Me._Nombre_Clase, "ObtenerDetalle", ex)
        End Try
        ObtenerDetalle = dTabla
    End Function

    'Public Function BusquedaVisual_Embarques_Nacional() As String
    '    Dim f As New BusquedaVisual
    '    Dim Resultado As String = ""
    '    f.Text = "Búsqueda de embarques nacional por folio."
    '    f.sCampo = "FOLIO_EMBARQUE"
    '    f.sOrder = "FECHA"
    '    f.sTable = "EMB_CAPTURA_DIARIA_PRODUCCION"
    '    f.sQl = "SELECT G.FOLIO_EMBARQUE,G.FOLIO_AARC,P.NOMBRE_PRODUCTOR,G.FECHA,G.ESTATUS_EMBARQUE FROM EMB_CAPTURA_DIARIA_PRODUCCION G  " & _
    '    "INNER JOIN CAT_PRODUCTORES P ON(G.CODIGO_PRODUCTOR =P.CODIGO_PRODUCTOR) " & _
    '    "INNER JOIN VW_SIS_CAT_DOCUMENTOS_EXTENDIDO T ON(G.CODIGO_DOCUMENTO=T.CODIGO_DOCUMENTO) " & _
    '    "WHERE T.CODIGO_DOCUMENTO='EMBN1' AND "

    '    f.Inicia("")
    '    f.ShowDialog()
    '    Try
    '        If f.iRows > 0 Then
    '            Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
    '        End If
    '    Catch ex As Exception
    '        HandleError(Me._Nombre_Clase, "BusquedaVisual_Embarques_Nacional", ex)
    '    End Try
    '    Return Resultado
    'End Function

    Public Function CargaProduccionDiaria(ByVal Fecha As Date, ByVal CodigoColtivo As String) As DataTable
        Dim dTabla As New DataTable("detalle"), da As SqlDataAdapter
        Dim sSQL As String = ("SELECT C.CODIGO_TIPO_TAMAÑO,T.NOMBRE_TIPO_TAMAÑO,C.CODIGO_TIPO_ENVASE,E.NOMBRE_TIPO_ENVASE,C.CANTIDAD_BULTOS PRODUCCION " & _
                              "FROM EMB_CAPTURA_DIARIA_PRODUCCION C " & _
                              "INNER JOIN CAT_TIPOS_TAMAÑOS T ON(C.CODIGO_TIPO_TAMAÑO=T.CODIGO_TIPO_TAMAÑO) " & _
                              "INNER JOIN CAT_TIPOS_ENVASES E ON(C.CODIGO_TIPO_ENVASE=E.CODIGO_TIPO_ENVASE) " & _
                              "WHERE C.FECHA='" & Format(Fecha, "yyyy-dd-MM").ToString & "' AND C.CODIGO_CULTIVO='" & CodigoColtivo.ToString & "' ORDER BY T.NOMBRE_TIPO_TAMAÑO")
        Try
            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dTabla)
            da.Dispose()

        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "CargaProduccionDiaria", ex)
        End Try
        CargaProduccionDiaria = dTabla
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
