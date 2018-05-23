Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Public Class Class_Centros_Costos_Detalle_Ventas

#Region "Campos"

#Region "Campos de la tabla"
    Private _ID_CENTRO_COSTOS_DETALLE_VENTAS As String
    Private _FOLIO_MOVIMIENTO As String
    Private _FOLIO_VENTA As String
    Private _IMPORTE As Double
#End Region

#Region "Campos ligados a la tabla"
    Private _Existe As Boolean
#End Region

#Region "Campos públicos"

#End Region

#Region "Campos privados"

#End Region

#Region "Campos de sistema"
    Private _Conexion As SqlConnection
#End Region

#End Region

#Region "Propiedades"
    Public Property ID_CENTRO_COSTOS_DETALLE_VENTAS() As String
        Get
            Return Me._ID_CENTRO_COSTOS_DETALLE_VENTAS
        End Get
        Set(ByVal Value As String)
            Me._ID_CENTRO_COSTOS_DETALLE_VENTAS = Value
        End Set
    End Property

    Public Property FOLIO_MOVIMIENTO() As String
        Get
            Return Me._FOLIO_MOVIMIENTO
        End Get
        Set(ByVal Value As String)
            Me._FOLIO_MOVIMIENTO = Value
        End Set
    End Property

    Public Property FOLIO_VENTA() As String
        Get
            Return Me._FOLIO_VENTA
        End Get
        Set(ByVal Value As String)
            Me._FOLIO_VENTA = Value
        End Set
    End Property

    Public Property IMPORTE() As Double
        Get
            Return Me._IMPORTE
        End Get
        Set(ByVal Value As Double)
            Me._IMPORTE = Value
        End Set
    End Property
#Region "Propiedades Campos de la tabla"

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
    Public ReadOnly Property Nombre_Clase() As String
        Get
            Return "Class_Centros_Costos_Detalle_Ventas"
        End Get
    End Property
#End Region

#End Region

#Region "Constructor y destructor"
    Public Sub New()
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
    End Sub

    Public Sub New(ByVal sFolio As String)
        Me.New()
        Try
            Me._ID_CENTRO_COSTOS_DETALLE_VENTAS = sFolio
            If Me.Consultar = True Then
                Me._Existe = True
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
    Public Function Consultar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand("SELECT * FROM CENTRO_COSTOS_DETALLE_VENTAS G WHERE G.ID_CENTRO_COSTOS_DETALLE_VENTAS='" & sReplace(Me._ID_CENTRO_COSTOS_DETALLE_VENTAS) & "'", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()
                If dReader.Read Then
                    Me._ID_CENTRO_COSTOS_DETALLE_VENTAS = dReader("ID_CENTRO_COSTOS_DETALLE_VENTAS").ToString
                    Me._FOLIO_MOVIMIENTO = dReader("FOLIO_MOVIMIENTO").ToString
                    Me._FOLIO_VENTA = dReader("FOLIO_VENTA").ToString
                    Me._IMPORTE = CDbl(dReader("IMPORTE"))

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

    Public Function ObtenerDetalleVentas(ByVal sFolio As String) As DataTable
        Dim dTabla As New DataTable("detalle"), da As SqlDataAdapter
        Dim sSQL As String

        sSQL = "SELECT D.ID_CENTRO_COSTOS_DETALLE_VENTAS,V.CODIGO_CLIENTE,C.NOMBRE_CLIENTE,D.FOLIO_VENTA,V.FECHA,D.IMPORTE " & _
                "FROM CENTRO_COSTOS_DETALLE_VENTAS D " & _
                "INNER JOIN VENTA_GLOBAL V ON(D.FOLIO_VENTA=V.FOLIO_VENTA) " & _
                "INNER JOIN CAT_CLIENTES C ON(V.CODIGO_CLIENTE=C.CODIGO_CLIENTE) " & _
                "WHERE D.FOLIO_MOVIMIENTO = '" & sFolio & "' " & _
                "ORDER BY D.ID_CENTRO_COSTOS_DETALLE_VENTAS "
        Try
            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dTabla)
            da.Dispose()
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "ObtenerDetalleVentas", ex)
        End Try
        Return dTabla
    End Function

    Public Function GrabaCentroCostosDetalleVentas(ByVal Agregar As String) As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CENTRO_COSTOS_DETALLE_VENTAS_GRABA"

            If txtLEN(Me._ID_CENTRO_COSTOS_DETALLE_VENTAS) = True Then
                sqlParametro = .Parameters.Add("@ID_CENTRO_COSTOS_DETALLE_VENTAS", SqlDbType.Int) : sqlParametro.Value = CInt(Me._ID_CENTRO_COSTOS_DETALLE_VENTAS)
            Else
                sqlParametro = .Parameters.Add("@ID_CENTRO_COSTOS_DETALLE_VENTAS", SqlDbType.Int) : sqlParametro.Value = 0 'Inserta nuevo renglon
            End If
            sqlParametro = .Parameters.Add("@FOLIO_MOVIMIENTO", SqlDbType.NVarChar, 15) : sqlParametro.Value = "" & Me._FOLIO_MOVIMIENTO
            sqlParametro = .Parameters.Add("@FOLIO_VENTA", SqlDbType.NVarChar, 15) : sqlParametro.Value = "" & Me._FOLIO_VENTA
            sqlParametro = .Parameters.Add("@IMPORTE", SqlDbType.Decimal) : sqlParametro.Value = Me._IMPORTE
            sqlParametro = .Parameters.Add("@AGREGAR", SqlDbType.Char) : sqlParametro.Value = Agregar ' 1 = insertar , 0 = actualizar

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "ActualizaCostos", ex)
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
