Option Strict On
Option Explicit On

Imports System.Data.SqlClient

Public Class Class_sisEmpresas

#Region "Campos"

#Region "Campos de la tabla"
    Private _ID_SIS_CAT_EMPRESAS As String
    Private _ALIAS_EMPRESA As String
    Private _NOMBRE_DB As String
    Private _RFC As String
#End Region

#Region "Campos ligados a la tabla"

#End Region

#Region "Campos públicos"

#End Region

#Region "Campos privados"

#End Region

#Region "Campos de sistema"
    Private _Nombre_Catalogo As String
    Private _Conexion As String
    Private _Existe As Boolean
#End Region

#End Region

#Region "Propiedades"

#Region "Propiedades Campos de la tabla"
    Public ReadOnly Property ID_SIS_CAT_EMPRESAS() As String
        Get
            Return _ID_SIS_CAT_EMPRESAS
        End Get
        'Set(ByVal value As String)
        '    Me._ID_SIS_CAT_EMPRESAS = value
        'End Set
    End Property

    Public ReadOnly Property ALIAS_EMPRESA() As String
        Get
            Return _ALIAS_EMPRESA
        End Get
    End Property

    Public ReadOnly Property NOMBRE_DB() As String
        Get
            Return _NOMBRE_DB
        End Get
    End Property

    Public ReadOnly Property RFC() As String
        Get
            Return _RFC
        End Get
    End Property
#End Region

#Region "Propiedades públicos"

#End Region

#Region "Propiedades de campos privados"

#End Region

#Region "Propiedades Campos de sistema"
    Public ReadOnly Property Conexion() As String
        Get
            Return _Conexion
        End Get
    End Property

    Public ReadOnly Property Existe() As Boolean
        Get
            Return Me._Existe
        End Get
    End Property
#End Region

#Region "Propiedad Nombre de Clase"
    Public ReadOnly Property Nombre_Clase() As String
        Get
            Return "Class_sisEmpresas"
        End Get
    End Property
#End Region

#End Region

#Region "Constructor y destructor"
    Public Sub New(ByVal sBaseDatos As String, ByVal sServidor As String, ByVal RFC As String)
        Try
            Me._Conexion = "Data Source=" & sServidor & ";Initial Catalog=" & sBaseDatos & ";" & "User ID=" & sCongif1 & ";Password=" & sCongif2
            Me._RFC = RFC
            If Me.Consultar = False Then
                Finaliza(False)
            Else
                Me._Existe = True
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "New", ex, sServidor, sBaseDatos)
            Finaliza(False)
        End Try
    End Sub
#End Region

#Region "Métodos y procedimientos"
    Private Function Consultar() As Boolean
        Dim bResultado As Boolean = False
        Dim cn As New SqlConnection(_Conexion)
        Dim cmd As New SqlCommand("SELECT ID_SIS_CAT_EMPRESAS,ALIAS_EMPRESA,NOMBRE_DB,RFC FROM SIS_CAT_EMPRESAS WHERE RFC='" & sReplace(Me._RFC) & "'", cn)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                cn.Open()
                dReader = .ExecuteReader()

                If dReader.Read = True Then
                    Me._ID_SIS_CAT_EMPRESAS = "" & dReader("ID_SIS_CAT_EMPRESAS").ToString
                    Me._ALIAS_EMPRESA = "" & dReader("ALIAS_EMPRESA").ToString
                    Me._NOMBRE_DB = "" & dReader("NOMBRE_DB").ToString
                    Me._RFC = "" & dReader("RFC").ToString

                    dReader.Close()
                    bResultado = True
                End If

            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "Consultar", ex)
            Finally
                cmd.Dispose()
                cn.Close()
                cn.Dispose()
            End Try
        End With

        Return bResultado
    End Function
#End Region

End Class
