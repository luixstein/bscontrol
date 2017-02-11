Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Public Class Class_CatTiposContabilidad

#Region "Campos"

#Region "Campos de la tabla"
#End Region

#Region "Campos ligados a la tabla"

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
#End Region

#End Region

#Region "Constructor y destructor"

    Public Sub New()
        Me._Nombre_Catalogo = "Class_CatTiposContabilidad"
        Me._Nombre_Reporte = ""
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "SELECT TIPO_CONTABILIDAD,NOMBRE_TIPO_CONTABILIDAD FROM CON_CAT_TIPOS_CONTABILIDAD"
        Me._QueryOrder = " ORDER BY NOMBRE_TIPO_CONTABILIDAD"
    End Sub

    Protected Overrides Sub Finalize()
        'Me._Conexion.Dispose()
        MyBase.Finalize()
    End Sub
#End Region

#Region "Métodos y procedimientos"
    Public Function ObtenerElementos() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dA As New SqlDataAdapter(Me._QuerySelect & Me._QueryOrder, Me._Conexion)
        Try
            dA.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementos", ex)
        Finally
            dA.Dispose()
        End Try
        ObtenerElementos = dTable
    End Function
#End Region

End Class
