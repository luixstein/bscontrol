Option Strict On

Imports System.Data.SqlClient

Public Class Class_CatCfdiIncoterm

#Region "Campos"
#Region "Campos de la tabla"
    Private _CODIGO_INCOTERM As String
    Private _NOMBRE_INCOTERM As String
#End Region

#Region "Campos ligados a la tabla"
    Private _Existe As Boolean
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
    Public Property CODIGO_INCOTERM() As String
        Get
            Return Me._CODIGO_INCOTERM
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_INCOTERM = Value
        End Set
    End Property

    Public Property NOMBRE_INCOTERM() As String
        Get
            Return Me._NOMBRE_INCOTERM
        End Get
        Set(ByVal Value As String)
            Me._NOMBRE_INCOTERM = Value
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
        Me._Nombre_Catalogo = "CFDI_CAT_INCOTERM"
        Me._Nombre_Reporte = "RPT_CATALOGO_CFDI_FIGURAS_TRANSPORTE"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "Select * From CFDI_CAT_INCOTERM"
        Me._QueryOrder = " Order by NOMBRE_INCOTERM"
    End Sub

    Public Sub New(ByVal sCodigoIncoterm As String)
        Me.New()
        Try
            Me._CODIGO_INCOTERM = sCodigoIncoterm
            If Me.Consultar = True Then
                Me._Existe = True
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

#Region "Métodos y procedimientos"

    Public Function Consultar() As Boolean
        Const sProcedure As String = "Consultar"
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand(
            "SELECT * " &
            "FROM CFDI_CAT_INCOTERM F " &
            "WHERE F.CODIGO_INCOTERM='" & sReplace(Me._CODIGO_INCOTERM) & "'", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read = True Then
                    Me._CODIGO_INCOTERM = "" & dReader("CODIGO_INCOTERM").ToString
                    Me._NOMBRE_INCOTERM = "" & dReader("NOMBRE_INCOTERM").ToString

                    bResultado = True
                End If
                dReader.Close()
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, sProcedure, ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
            End Try
        End With
        Return bResultado
    End Function

    Public Function ObtenerElementos() As System.Data.DataTable
        Const sProcedure As String = "ObtenerElementos"
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter("SELECT CODIGO_INCOTERM,CODIGO_INCOTERM+'-'+NOMBRE_INCOTERM NOMBRE_INCOTERM FROM CFDI_CAT_INCOTERM ORDER BY NOMBRE_INCOTERM", Me._Conexion)
        Try
            da.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, sProcedure, ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

#End Region

End Class