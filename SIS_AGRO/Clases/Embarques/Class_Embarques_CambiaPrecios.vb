Imports System.Data
Imports System.Data.SqlClient

Public Class Class_Embarques_CambiaPrecios

#Region "Campos"

#Region "Campos de la tabla"
    Private _ID_EMB_EMBARQUES_CAMBIOS_PRECIOS As Integer
    Private _AÑO As Integer
    Private _NUMERO_SEMANA As Integer
    Private _CODIGO_CLIENTE As String
    Private _CODIGO_ARTICULO As String
    Private _CANTIDAD_EMBARCADA As Double
    Private _CANTIDAD_VENDIDA As Double
    Private _PRECIO_UNIDAD_BULTO As Double
    Private _IMPORTE_VENDIDO As Double
    Private _AJUSTES As Double
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
    Public ReadOnly Property ID_EMB_EMBARQUES_CAMBIOS_PRECIOS() As Integer
        Get
            Return Me._ID_EMB_EMBARQUES_CAMBIOS_PRECIOS
        End Get
    End Property

    Public Property AÑO() As Integer
        Get
            Return Me._AÑO
        End Get
        Set(ByVal Value As Integer)
            Me._AÑO = Value
        End Set
    End Property

    Public Property NUMERO_SEMANA() As Integer
        Get
            Return Me._NUMERO_SEMANA
        End Get
        Set(ByVal Value As Integer)
            Me._NUMERO_SEMANA = Value
        End Set
    End Property

    Public Property CODIGO_CLIENTE() As String
        Get
            Return Me._CODIGO_CLIENTE
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_CLIENTE = Value
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

    Public Property CANTIDAD_EMBARCADA() As Double
        Get
            Return Me._CANTIDAD_EMBARCADA
        End Get
        Set(ByVal Value As Double)
            Me._CANTIDAD_EMBARCADA = Value
        End Set
    End Property

    Public Property CANTIDAD_VENDIDA() As Double
        Get
            Return Me._CANTIDAD_VENDIDA
        End Get
        Set(ByVal Value As Double)
            Me._CANTIDAD_VENDIDA = Value
        End Set
    End Property

    Public Property PRECIO_UNIDAD_BULTO() As Double
        Get
            Return Me._PRECIO_UNIDAD_BULTO
        End Get
        Set(ByVal Value As Double)
            Me._PRECIO_UNIDAD_BULTO = Value
        End Set
    End Property

    Public Property IMPORTE_VENDIDO() As Double
        Get
            Return Me._IMPORTE_VENDIDO
        End Get
        Set(ByVal Value As Double)
            Me._IMPORTE_VENDIDO = Value
        End Set
    End Property

    Public Property AJUSTES() As Double
        Get
            Return Me._AJUSTES
        End Get
        Set(ByVal Value As Double)
            Me._AJUSTES = Value
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

#End Region

#Region "Propiedades de campos privados"

#End Region
#Region "Propiedades de campos de sistema"

#Region "Propiedad Nombre de Clase"
    Public ReadOnly Property Nombre_Clase() As String
        Get
            Return "Class_Embarques_MastronardiCambiaPrecios"
        End Get
    End Property
#End Region

#End Region

#End Region

#Region "Constructor y destructor"

    Public Sub New()
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "SELECT ID_EMB_EMBARQUES_CAMBIOS_PRECIOS,AÑO,NUMERO_SEMANA,CODIGO_CLIENTE,CODIGO_ARTICULO,CANTIDAD_VENDIDA,PRECIO_UNIDAD_BULTO,IMPORTE_VENDIDO,AJUSTES FROM EMB_EMBARQUES_CAMBIOS_PRECIOS"
        Me._QueryOrder = " Order by AÑO,NUMERO_SEMANA"
    End Sub                                                         'Inicializa al objeto.

    Protected Overrides Sub Finalize()
        'Me._Conexion.Dispose()
        MyBase.Finalize()
    End Sub
#End Region

#Region "Opciones"

#End Region

#Region "Métodos y procedimientos"

    Public Function CambiaPrecios() As Boolean
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_EMBARQUES_GRABA_CAMBIO_PRECIO"

            sqlParametro = .Parameters.Add("@AÑO", SqlDbType.SmallInt) : sqlParametro.Value = Me._AÑO
            sqlParametro = .Parameters.Add("@NUMERO_SEMANA", SqlDbType.SmallInt) : sqlParametro.Value = Me._NUMERO_SEMANA
            sqlParametro = .Parameters.Add("@CODIGO_CLIENTE", SqlDbType.NVarChar, 8) : sqlParametro.Value = Me._CODIGO_CLIENTE
            sqlParametro = .Parameters.Add("@CODIGO_ARTICULO", SqlDbType.NVarChar, 16) : sqlParametro.Value = Me._CODIGO_ARTICULO.ToString
            sqlParametro = .Parameters.Add("@CANTIDAD_EMBARCADA", SqlDbType.NVarChar, 8) : sqlParametro.Value = Me._CANTIDAD_EMBARCADA
            sqlParametro = .Parameters.Add("@CANTIDAD_VENDIDA", SqlDbType.NVarChar, 8) : sqlParametro.Value = Me._CANTIDAD_VENDIDA
            sqlParametro = .Parameters.Add("@PRECIO_UNIDAD_BULTO", SqlDbType.Decimal) : sqlParametro.Value = Me._PRECIO_UNIDAD_BULTO
            sqlParametro = .Parameters.Add("@IMPORTE_VENDIDO", SqlDbType.Decimal) : sqlParametro.Value = Me._IMPORTE_VENDIDO
            sqlParametro = .Parameters.Add("@AJUSTES", SqlDbType.Decimal) : sqlParametro.Value = Me._AJUSTES

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                CambiaPrecios = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "CambiaPrecios", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
    End Function

    Public Function EliminaCambioPrecio(ByVal iID_EMB_EMBARQUES_CAMBIOS_PRECIOS As Integer) As Boolean
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_EMBARQUES_ELIMINA_CAMBIO_PRECIO"

            sqlParametro = .Parameters.Add("@ID_EMB_EMBARQUES_CAMBIOS_PRECIOS", SqlDbType.Int) : sqlParametro.Value = iID_EMB_EMBARQUES_CAMBIOS_PRECIOS

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                EliminaCambioPrecio = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "EliminaCambioPrecio", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
    End Function

    Public Function ObtenerDetalle() As System.Data.DataTable
        Dim dt As New DataTable
        Try
            Dim da As New SqlDataAdapter("MP_RPT_EMBARQUES_PARA_CAPTURA_PRECIOS", Me._Conexion)
            da.SelectCommand.CommandType = CommandType.StoredProcedure

            With da.SelectCommand
                .Parameters.Add("@AÑO", SqlDbType.SmallInt).Value = Me._AÑO
                .Parameters.Add("@NUMERO_SEMANA", SqlDbType.SmallInt).Value = Me._NUMERO_SEMANA
                .Parameters.Add("@CODIGO_CLIENTE", SqlDbType.NVarChar, 8).Value = Me._CODIGO_CLIENTE
            End With

            da.Fill(dt)
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "ObtenerDetalle", ex)
        Finally

        End Try
        ObtenerDetalle = dt
    End Function

    Public Function ObtenerSemanas(ByVal sAño As String) As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dsCat_Semanas As New SqlDataAdapter("select NUMERO_SEMANA,FECHA1,FECHA2 from EMB_CAT_RANGOS_LOTES_MASTRONARDI where AÑO='" & sAño & "' " & "order by NUMERO_SEMANA", Me._Conexion)
        Try
            dsCat_Semanas.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerSemanas", ex)
        Finally
            dsCat_Semanas.Dispose()
        End Try
        Return dTable
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
