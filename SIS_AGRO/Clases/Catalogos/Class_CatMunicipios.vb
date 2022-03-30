Imports System.Data
Imports System.Data.SqlClient

Public Class Class_CatMunicipios

#Region "Campos"

#Region "Campos de la tabla"
    Private _CODIGO_MUNICIPIO As String
    Private _CODIGO_MUNICIPIO_SAT As String
    Private _NOMBRE_MUNICIPIO As String
    Private _CODIGO_ESTADO As String
    Private _ESTATUS As String
#End Region

#Region "Campos ligados a la tabla"
    Private _Existe As Boolean 'lectura
    Private _CODIGO_ESTADO_SAT As String
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
    Public Property CODIGO_MUNICIPIO() As String
        Get
            Return Me._CODIGO_MUNICIPIO
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_MUNICIPIO = Value
        End Set
    End Property

    Public ReadOnly Property CODIGO_MUNICIPIO_SAT() As String
        Get
            Return Me._CODIGO_MUNICIPIO_SAT
        End Get
    End Property

    Public Property NOMBRE_MUNICIPIO() As String
        Get
            Return Me._NOMBRE_MUNICIPIO
        End Get
        Set(ByVal Value As String)
            Me._NOMBRE_MUNICIPIO = Value
        End Set
    End Property

    Public ReadOnly Property CODIGO_ESTADO() As String
        Get
            Return Me._CODIGO_ESTADO
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
#End Region

#Region "Propiedades de campos ligados a la tabla"
    Public ReadOnly Property CODIGO_ESTADO_SAT() As String
        Get
            Return Me._CODIGO_ESTADO_SAT
        End Get
    End Property

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
        Me._Nombre_Catalogo = "CAT_MUNICIPIOS"
        Me._Nombre_Reporte = "RPT_CATALOGO_MUNICIPIOS"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = ""
        Me._QueryOrder = ""
    End Sub

    Public Sub New(ByVal sCodigo As String)
        Me.New()
        Try
            Me._CODIGO_MUNICIPIO = sCodigo
            If Me.Consultar = True Then
                Me._Existe = True
                'Throw New Exception("El artículo no existe.")
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
        Dim cmd As New SqlCommand("SELECT M.CODIGO_MUNICIPIO,M.CODIGO_MUNICIPIO_SAT,M.NOMBRE_MUNICIPIO,M.CODIGO_ESTADO,M.ESTATUS" & _
                                  "FROM CAT_MUNICIPIOS M " & _
                                  "INNER JOIN SIS_ESTADOS E ON(M.CODIGO_ESTADO=E.CODIGO_ESTADO)" & _
                                  "WHERE M.CODIGO_MUNICIPIO=" & Replace(Me._CODIGO_MUNICIPIO, "'", "''") & "", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._CODIGO_MUNICIPIO = "" & dReader("CODIGO_MUNICIPIO")
                    Me._CODIGO_MUNICIPIO_SAT = "" & dReader("CODIGO_MUNICIPIO_SAT")
                    Me._NOMBRE_MUNICIPIO = Trim("" & dReader("NOMBRE_MUNICIPIO").ToString)
                    Me._CODIGO_ESTADO = "" & dReader("CODIGO_ESTADO")
                    Me.ESTATUS = "" & dReader("ESTATUS").ToString
                    Me._CODIGO_ESTADO_SAT = "" & dReader("CODIGO_ESTADO_SAT")

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

    Public Function ObtenerElementos(ByVal sCodigoEstado As String) As System.Data.DataTable
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter("SELECT CODIGO_MUNICIPIO,NOMBRE_MUNICIPIO FROM CAT_MUNICIPIOS WHERE ESTATUS='A' AND CODIGO_ESTADO='" & sReplace(sCodigoEstado) & "'" & _
                                     "ORDER BY NOMBRE_MUNICIPIO", Me._Conexion)
        Try
            da.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementos", ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerElementosPorEstadoSAT(ByVal sCodigoEstadoSAT As String) As System.Data.DataTable
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter("SELECT M.CODIGO_MUNICIPIO,M.NOMBRE_MUNICIPIO FROM CAT_MUNICIPIOS M INNER JOIN SIS_ESTADOS E ON(M.CODIGO_ESTADO=E.CODIGO_ESTADO) WHERE M.ESTATUS='A' AND E.CODIGO_ESTADO_SAT='" & sReplace(sCodigoEstadoSAT) & "'" & _
                                     "ORDER BY M.NOMBRE_MUNICIPIO", Me._Conexion)
        Try
            da.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementos", ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

#End Region

End Class