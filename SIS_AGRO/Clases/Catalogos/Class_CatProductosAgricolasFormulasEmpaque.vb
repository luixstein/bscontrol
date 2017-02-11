Option Strict On
Imports System.Data
Imports System.Data.SqlClient

Public Class Class_CatProductosAgricolasFormulasEmpaque

#Region "Campos"

#Region "Campos de la tabla"
    Private _ID_CAT_PRODUCTOS_AGRICOLAS_FORMULAS_EMPAQUE As Integer
    Private _CODIGO_PRODUCTO As String
    Private _CLAVE As String
    Private _CODIGO_EMPAQUE As String
    Private _CANTIDAD As Double
    Private _UNIDAD_BASE As String
    Private _COSTO_UNITARIO As Double
#End Region

#Region "Campos ligados a la tabla"
    Private _Existe As Boolean 'lectura
#End Region

#Region "Campos públicos"
    'Public oEmbarqueDetalle As Class_Embarques_EmbarqueDetalle
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
    Public Property ID_CAT_PRODUCTOS_AGRICOLAS_FORMULAS_EMPAQUE() As Integer
        Get
            Return Me._ID_CAT_PRODUCTOS_AGRICOLAS_FORMULAS_EMPAQUE
        End Get
        Set(ByVal Value As Integer)
            Me._ID_CAT_PRODUCTOS_AGRICOLAS_FORMULAS_EMPAQUE = Value
        End Set
    End Property

    Public Property CODIGO_PRODUCTO() As String
        Get
            Return Me._CODIGO_PRODUCTO
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_PRODUCTO = Value
        End Set
    End Property

    Public Property CLAVE() As String
        Get
            Return Me._CLAVE
        End Get
        Set(ByVal Value As String)
            Me._CLAVE = Value
        End Set
    End Property

    Public Property CODIGO_EMPAQUE() As String
        Get
            Return Me._CODIGO_EMPAQUE
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_EMPAQUE = Value
        End Set
    End Property

    Public Property CANTIDAD() As Double
        Get
            Return Me._CANTIDAD
        End Get
        Set(ByVal value As Double)
            Me._CANTIDAD = value
        End Set
    End Property

    Public Property UNIDAD_BASE() As String
        Get
            Return Me._UNIDAD_BASE
        End Get
        Set(ByVal value As String)
            Me._UNIDAD_BASE = value
        End Set
    End Property

    Public Property COSTO_UNITARIO() As Double
        Get
            Return Me._COSTO_UNITARIO
        End Get
        Set(ByVal value As Double)
            Me._COSTO_UNITARIO = value
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
        Me._Nombre_Clase = "CAT_PRODUCTOS_AGRICOLAS_FORMULAS_EMPAQUE"

        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "SELECT G.* FROM CAT_PRODUCTOS_AGRICOLAS_FORMULAS_EMPAQUE G "
        '& _
        '"LEFT JOIN EMB_CONFIGURACION_PLANTILLA_BASE_FORMULA_EMPAQUE U1 ON(G.CODIGO_USUARIO_GRABO=U1.CODIGO_USUARIO) "
        Me._QueryOrder = " ORDER BY G.CODIGO_PRODUCTO "
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
            .CommandText = "MP_EMB_CAT_PRODUCTOS_AGRICOLAS_FORMULAS_EMPAQUE_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_PRODUCTO", SqlDbType.NVarChar, 16) : sqlParametro.Value = "" & Me._CODIGO_PRODUCTO
            sqlParametro = .Parameters.Add("@CLAVE", SqlDbType.NVarChar, 30) : sqlParametro.Value = Me._CLAVE
            sqlParametro = .Parameters.Add("@CODIGO_EMPAQUE", SqlDbType.NVarChar, 16) : sqlParametro.Value = Me._CODIGO_EMPAQUE
            sqlParametro = .Parameters.Add("@CANTIDAD", SqlDbType.Decimal) : sqlParametro.Value = Me._CANTIDAD
            sqlParametro = .Parameters.Add("@UNIDAD_BASE", SqlDbType.NVarChar, 30) : sqlParametro.Value = Me._UNIDAD_BASE
            sqlParametro = .Parameters.Add("@COSTO_UNITARIO", SqlDbType.Decimal) : sqlParametro.Value = Me._COSTO_UNITARIO
            sqlParametro = .Parameters.Add("@ACCION", SqlDbType.NVarChar, 20) : sqlParametro.Value = "ACTUALIZAR"

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                Actualizar = True
            Catch ex As Exception
                HandleError(Me._Nombre_Clase, "Actualizar", ex)
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
            .CommandText = "MP_EMB_CAT_PRODUCTOS_AGRICOLAS_FORMULAS_EMPAQUE_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_PRODUCTO", SqlDbType.NVarChar, 16) : sqlParametro.Value = "" & Me._CODIGO_PRODUCTO
            sqlParametro = .Parameters.Add("@CLAVE", SqlDbType.NVarChar, 30) : sqlParametro.Value = Me._CLAVE
            sqlParametro = .Parameters.Add("@CODIGO_EMPAQUE", SqlDbType.NVarChar, 16) : sqlParametro.Value = Me._CODIGO_EMPAQUE
            sqlParametro = .Parameters.Add("@CANTIDAD", SqlDbType.Decimal) : sqlParametro.Value = Me._CANTIDAD
            sqlParametro = .Parameters.Add("@UNIDAD_BASE", SqlDbType.NVarChar, 30) : sqlParametro.Value = Me._UNIDAD_BASE
            sqlParametro = .Parameters.Add("@COSTO_UNITARIO", SqlDbType.Decimal) : sqlParametro.Value = Me._COSTO_UNITARIO
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
        Dim cmd As New SqlCommand(Me._QuerySelect & " WHERE CODIGO_PRODUCTO=" & sReplace(Me._CODIGO_PRODUCTO.ToString), Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()
                If dReader.Read Then
                    Me._ID_CAT_PRODUCTOS_AGRICOLAS_FORMULAS_EMPAQUE = CInt(dReader("ID_CAT_PRODUCTOS_AGRICOLAS_FORMULAS_EMPAQUE"))
                    Me._CODIGO_PRODUCTO = dReader("CODIGO_PRODUCTO").ToString
                    Me._CLAVE = dReader("CLAVE").ToString
                    Me._CODIGO_EMPAQUE = dReader("CODIGO_EMPAQUE").ToString
                    Me._CANTIDAD = CInt(dReader("CANTIDAD"))
                    Me._UNIDAD_BASE = dReader("UNIDAD_BASE").ToString
                    Me._COSTO_UNITARIO = CDbl(dReader("COSTO_UNITARIO").ToString)
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
            .CommandText = "MP_EMB_CAT_PRODUCTOS_AGRICOLAS_FORMULAS_EMPAQUE_ELIMINA"

            sqlParametro = .Parameters.Add("@CODIGO_PRODUCTO", SqlDbType.NVarChar, 16) : sqlParametro.Value = "" & Me._CODIGO_PRODUCTO

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

    Public Function ObtenerDetalle(Optional ByVal sCodigoArticulo As String = "") As DataTable
        Dim dTabla As New DataTable("detalle"), da As SqlDataAdapter
        Dim sSQL As String
        sSQL = "SELECT PL.CLAVE,ISNULL(F.CODIGO_EMPAQUE,PL.CODIGO_EMPAQUE) CODIGO_EMPAQUE," & _
        "(SELECT DESCRIPCION FROM CAT_ARTICULOS WHERE CODIGO_ARTICULO=ISNULL(F.CODIGO_EMPAQUE,PL.CODIGO_EMPAQUE)) DESCRIPCION, " & _
        "ISNULL(F.CANTIDAD,PL.CANTIDAD)CANTIDAD,PL.UNIDAD_BASE,PL.EDITABLE,PL.ES_POR_MILLARES,ISNULL(F.COSTO_UNITARIO,PL.COSTO_UNITARIO)COSTO_UNITARIO,A.UNIDAD_VENTA " & _
        "FROM EMB_CONFIGURACION_PLANTILLA_BASE_FORMULA_EMPAQUE PL " & _
        "LEFT JOIN CAT_PRODUCTOS_AGRICOLAS_FORMULAS_EMPAQUE F ON (PL.CLAVE=F.CLAVE AND F.CODIGO_PRODUCTO='" & sCodigoArticulo & "') " & _
        "LEFT JOIN CAT_ARTICULOS A ON(F.CODIGO_EMPAQUE=A.CODIGO_ARTICULO) " & _
        "ORDER BY PL.ID_EMB_CONFIGURACION_PLANTILLA_BASE_FORMULA_EMPAQUE "

        Try
            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dTabla)
            da.Dispose()
        Catch ex As Exception
            HandleError(Me._Nombre_Clase, "ObtenerDetalle", ex)
        End Try
        Return dTabla
    End Function

    Public Function CargaProduccionDiaria(ByVal Fecha As Date, ByVal CodigoColtivo As String) As DataTable
        Dim dTabla As New DataTable("detalle"), da As SqlDataAdapter
        Dim sSQL As String = ("SELECT C.CODIGO_TIPO_TAMAÑO,T.NOMBRE_TIPO_TAMAÑO,C.CODIGO_EMPAQUE,E.NOMBRE_TIPO_ENVASE,C.CANTIDAD_BULTOS PRODUCCION " & _
                              "FROM EMB_CAPTURA_DIARIA_PRODUCCION C " & _
                              "INNER JOIN CAT_TIPOS_TAMAÑOS T ON(C.CODIGO_TIPO_TAMAÑO=T.CODIGO_TIPO_TAMAÑO) " & _
                              "INNER JOIN CAT_TIPOS_ENVASES E ON(C.CODIGO_EMPAQUE=E.CODIGO_EMPAQUE) " & _
                              "WHERE C.FECHA='" & Format(Fecha, "yyyy-dd-MM").ToString & "' AND C.CODIGO_PRODUCTO='" & CodigoColtivo.ToString & "' ORDER BY T.NOMBRE_TIPO_TAMAÑO")
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
