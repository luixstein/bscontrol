Option Strict On

Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class Class_INE_CatAmbitos

#Region "Campos"
#Region "Campos de la tabla"
    Private _CODIGO_AMBITO As Integer
    Private _NOMBRE_AMBITO As String
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
    Public Property CODIGO_AMBITO() As Integer
        Get
            Return Me._CODIGO_AMBITO
        End Get
        Set(ByVal Value As Integer)
            Me._CODIGO_AMBITO = Value
        End Set
    End Property

    Public Property NOMBRE_AMBITO() As String
        Get
            Return Me._NOMBRE_AMBITO
        End Get
        Set(ByVal Value As String)
            Me._NOMBRE_AMBITO = Value
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
            Return "Class_INE_CatAmbitos"
        End Get
    End Property
#End Region

#End Region

#Region "Constructor y destructor"
    Public Sub New()
        Me._Conexion = New SqlConnection(Empresa_Sistema.conexion)
    End Sub

    Public Sub New(ByVal iCODIGO_AMBITO As Integer)
        Me.New()
        Try
            Me._CODIGO_AMBITO = iCODIGO_AMBITO
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

        sSQL = "SELECT CODIGO_AMBITO,NOMBRE_AMBITO FROM CFDI_INE_CAT_AMBITOS WHERE CODIGO_AMBITO  =" & Me._CODIGO_AMBITO.ToString

        Dim cmd As New SqlCommand(sSQL, Me._Conexion)

        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read = True Then
                    Me._CODIGO_AMBITO = CInt("" & dReader("CODIGO_AMBITO").ToString())
                    Me._NOMBRE_AMBITO = "" & dReader("NOMBRE_AMBITO").ToString()

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

    Public Function ObtenerAmbitos() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter("SELECT CODIGO_AMBITO,NOMBRE_AMBITO FROM CFDI_INE_CAT_AMBITOS", Me._Conexion)
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
