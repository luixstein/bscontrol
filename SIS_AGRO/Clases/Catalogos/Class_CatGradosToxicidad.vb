Option Strict On
Option Explicit On

Imports System.Data
Imports System.Data.SqlClient

Public Class Class_CatGradosToxicidad

#Region "Campos"

#Region "Campos de la tabla"
    Private _GRADO_TOXICIDAD As String
    Private _IEPS_PORCENTAJE As Double
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
    Public Property GRADO_TOXICIDAD() As String
        Get
            Return Me._GRADO_TOXICIDAD
        End Get
        Set(ByVal Value As String)
            Me._GRADO_TOXICIDAD = Value
        End Set
    End Property

    Public Property IEPS_PORCENTAJE() As Double
        Get
            Return Me._IEPS_PORCENTAJE
        End Get
        Set(ByVal Value As Double)
            Me._IEPS_PORCENTAJE = Value
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
        Me._Nombre_Catalogo = "CAT_GRADOS_TOXICIDAD"
        Me._Nombre_Reporte = "RPTCAT_GRADOS_TOXICIDAD"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = ""
        Me._QueryOrder = ""
    End Sub

    Public Sub New(ByVal sCodigo As String)
        Me.New()
        Try
            Me._GRADO_TOXICIDAD = sCodigo
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
        Dim cmd As New SqlCommand("SELECT GRADO_TOXICIDAD,IEPS_PORCENTAJE FROM CAT_GRADOS_TOXICIDAD WHERE GRADO_TOXICIDAD='" & sReplace(Me._GRADO_TOXICIDAD) & "'", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._GRADO_TOXICIDAD = dReader("GRADO_TOXICIDAD").ToString
                    Me._IEPS_PORCENTAJE = CDbl(Trim("" & dReader("IEPS_PORCENTAJE").ToString))
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

    Public Function ObtenerElementos() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter("SELECT GRADO_TOXICIDAD,CAST(GRADO_TOXICIDAD AS NVARCHAR) + '-' + CAST(IEPS_PORCENTAJE AS NVARCHAR) + '%' DESCRIPCION,IEPS_PORCENTAJE FROM CAT_GRADOS_TOXICIDAD ORDER BY GRADO_TOXICIDAD", Me._Conexion)
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
