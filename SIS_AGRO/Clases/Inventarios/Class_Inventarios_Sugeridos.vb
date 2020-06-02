Option Strict On
Imports System.Data.SqlClient

Public Class Class_Inventarios_Sugeridos

#Region "Campos"

#Region "Campos de la tabla"
    Private _ID_INVENTARIOS_SUGERIDOS As String
    Private _CODIGO_ALMACEN As String
    Private _CODIGO_ARTICULO As String
    Private _CLASIFICACION_IMPORTANCIA As String
    Private _TIEMPO_ENTREGA_DIAS As Integer
    Private _MAXIMO As Decimal
    'Private _REORDEN As Decimal
    Private _MINIMO As Decimal
#End Region

#Region "Campos ligados a la tabla"
    Private _Existe As Boolean 'lectura
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

    Public Property ID_INVENTARIOS_SUGERIDOS() As String
        Get
            Return Me._ID_INVENTARIOS_SUGERIDOS
        End Get
        Set(ByVal Value As String)
            Me._ID_INVENTARIOS_SUGERIDOS = Value
        End Set
    End Property

    Public Property CODIGO_ALMACEN() As String
        Get
            Return Me._CODIGO_ALMACEN
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_ALMACEN = Value
        End Set
    End Property

    Public Property CODIGO_ARTICULO() As String
        Get
            Return Me._CODIGO_ARTICULO
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_ARTICULO = Value
        End Set
    End Property

    Public Property CLASIFICACION_IMPORTANCIA() As String
        Get
            Return Me._CLASIFICACION_IMPORTANCIA
        End Get
        Set(ByVal Value As String)
            Me._CLASIFICACION_IMPORTANCIA = Value
        End Set
    End Property

    Public Property TIEMPO_ENTREGA_DIAS() As Integer
        Get
            Return Me._TIEMPO_ENTREGA_DIAS
        End Get
        Set(value As Integer)
            Me._TIEMPO_ENTREGA_DIAS = value
        End Set
    End Property

    Public Property MAXIMO() As Decimal
        Get
            Return Me._MAXIMO
        End Get
        Set(value As Decimal)
            Me._MAXIMO = value
        End Set
    End Property

    'Public Property REORDEN() As Decimal
    '    Get
    '        Return Me._REORDEN
    '    End Get
    '    Set(value As Decimal)
    '        Me._REORDEN = value
    '    End Set
    'End Property

    Public Property MINIMO() As Decimal
        Get
            Return Me._MINIMO
        End Get
        Set(value As Decimal)
            Me._MINIMO = value
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

#End Region

#End Region

#Region "Constructor y destructor"
    Public Sub New()
        Me._Nombre_Catalogo = "INVENTARIOS_SUGERIDOS"
        Me._Nombre_Reporte = ""
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "Select * FROM INVENTARIOS_SUGERIDOS WHERE "
        Me._QueryOrder = " Order by ID_INVENTARIOS_SUGERIDOS"
    End Sub

    Public Sub New(ByVal sIdInventariosSugeridos As String)
        Me.New()
        'Try
        '    Me.ID_INVENTARIOS_SUGERIDOS = sIdInventariosSugeridos
        '    If Me.Consultar = False Then
        '        Throw New Exception("El id de inventario sugerido no existe.")
        '    Else
        '        Me._Existe = True
        '    End If
        'Catch ex As Exception
        '    HandleError(Me._Nombre_Catalogo, "New", ex)
        'End Try
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

#End Region

#Region "Métodos y procedimientos"

    Public Function Grabar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_INVENTARIOS_SUGERIDOS_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_ALMACEN", SqlDbType.NVarChar, 4) : sqlParametro.Value = Me._CODIGO_ALMACEN
            sqlParametro = .Parameters.Add("@CODIGO_ARTICULO", SqlDbType.NVarChar, 16) : sqlParametro.Value = Me._CODIGO_ARTICULO
            sqlParametro = .Parameters.Add("@CLASIFICACION_IMPORTANCIA", SqlDbType.Char, 1) : sqlParametro.Value = Me._CLASIFICACION_IMPORTANCIA
            sqlParametro = .Parameters.Add("@TIEMPO_ENTREGA_DIAS", SqlDbType.SmallInt) : sqlParametro.Value = Me._TIEMPO_ENTREGA_DIAS
            sqlParametro = .Parameters.Add("@MAXIMO", SqlDbType.Decimal) : sqlParametro.Value = Me._MAXIMO
            'sqlParametro = .Parameters.Add("@REORDEN", SqlDbType.Decimal) : sqlParametro.Value = Me._REORDEN
            sqlParametro = .Parameters.Add("@MINIMO", SqlDbType.Decimal) : sqlParametro.Value = Me._MINIMO

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "Grabar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Function ObtenerElementos(ByVal sCodigoAlmacen As String) As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dsArticulosInv As New SqlDataAdapter("EXEC MP_INVENTARIOS_SUGERIDOS_OBTIENE_DETALLE @CODIGO_ALMACEN='" & sCodigoAlmacen & "', @FILTRO='%' ", Me._Conexion)
        Try
            dsArticulosInv.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementos", ex)
        Finally
            dsArticulosInv.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerElementosFiltro(ByVal sCodigoAlmacen As String, ByVal sFiltro As String) As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dsArticulosInv As New SqlDataAdapter("EXEC MP_INVENTARIOS_SUGERIDOS_OBTIENE_DETALLE @CODIGO_ALMACEN='" & sCodigoAlmacen & "', @FILTRO='" & sFiltro & "' ", Me._Conexion)
        Try
            dsArticulosInv.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementosFiltro", ex)
        Finally
            dsArticulosInv.Dispose()
        End Try
        Return dTable
    End Function

#End Region

End Class
