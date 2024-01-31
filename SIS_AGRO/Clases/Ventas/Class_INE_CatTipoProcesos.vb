Option Strict On

Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class Class_INE_CatTipoProcesos

#Region "Campos"
#Region "Campos de la tabla"
    Private _CODIGO_PROCESO As Integer
    Private _NOMBRE_PROCESO As String
#End Region

#Region "Campos ligados a la tabla"
    Private _Existe As Boolean
    Private _Nombre_Formato As String
#End Region

#Region "Campos de sistema"
    Private _Conexion As SqlConnection
#End Region
#End Region

#Region "Propiedades"

#Region "Propiedades campos de la tabla"
    Public Property CODIGO_PROCESO() As Integer
        Get
            Return Me._CODIGO_PROCESO
        End Get
        Set(ByVal Value As Integer)
            Me._CODIGO_PROCESO = Value
        End Set
    End Property

    Public Property NOMBRE_PROCESO() As String
        Get
            Return Me._NOMBRE_PROCESO
        End Get
        Set(ByVal Value As String)
            Me._NOMBRE_PROCESO = Value
        End Set
    End Property
#End Region

#Region "Propiedades de campos ligados a la tabla"
    Public ReadOnly Property Existe() As Boolean
        Get
            Return Me._Existe
        End Get
    End Property

    Public ReadOnly Property Nombre_Formato() As String
        Get
            Return Me._Nombre_Formato
        End Get
    End Property
#End Region

#Region "Propiedades de sistema"
    Private ReadOnly Property NombreClase() As String
        Get
            Return "Class_INE_CatTipoProcesos"
        End Get
    End Property
#End Region

#End Region

#Region "Constructor y destructor"
    Public Sub New()
        Me._Conexion = New SqlConnection(Empresa_Sistema.conexion)
    End Sub

    Public Sub New(ByVal iCODIGO_PROCESO As Integer)
        Me.New()
        Try
            Me._CODIGO_PROCESO = iCODIGO_PROCESO
            If Me.Consultar() = True Then
                Me._Existe = True
            End If
        Catch ex As Exception
            HandleError(Me.NombreClase, "New", ex)
        End Try
    End Sub

    Protected Overrides Sub Finalize()
        'Me._Conexion.Dispose()
        MyBase.Finalize()
    End Sub
#End Region

#Region "Métodos y procedimientos"
    Private Function Consultar() As Boolean
        Const sProcedure As String = "Consultar"
        Dim bResultado As Boolean = False
        Dim dReader As SqlDataReader, sSQL As String = ""

        sSQL = "SELECT CODIGO_PROCESO,NOMBRE_PROCESO FROM CFDI_INE_CAT_TIPOS_PROCESOS WHERE CODIGO_PROCESO  =" & Me._CODIGO_PROCESO.ToString

        Dim cmd As New SqlCommand(sSQL, Me._Conexion)

        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read = True Then
                    Me._CODIGO_PROCESO = CInt("" & dReader("CODIGO_PROCESO").ToString())
                    Me._NOMBRE_PROCESO = "" & dReader("NOMBRE_PROCESO").ToString()

                    bResultado = True
                End If
                dReader.Close()
            Catch ex As Exception
                HandleError(Me.NombreClase, sProcedure, ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
            End Try
        End With

        Return bResultado
    End Function

    Public Function ObtenerTipoProcesos() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter("SELECT CODIGO_PROCESO,NOMBRE_PROCESO FROM CFDI_INE_CAT_TIPOS_PROCESOS", Me._Conexion)
        Try
            da.Fill(dTable)
        Catch ex As Exception
            HandleError(Me.NombreClase, "ObtenerAmbitos", ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function
#End Region

End Class
