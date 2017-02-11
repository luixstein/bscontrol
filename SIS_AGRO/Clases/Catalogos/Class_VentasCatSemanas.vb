Option Strict On
Imports System.Data
Imports System.Data.SqlClient

Public Class Class_VentasCatSemanas
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

#Region "Constructor y destructor"
    Public Sub New()
        Me._Nombre_Catalogo = "VENTAS_CAT_SEMANAS"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "SELECT ID_SEMANA,DBO.FN_FORMAT_FECHA_CORTO(FECHA1) FECHA1,DBO.FN_FORMAT_FECHA_CORTO(FECHA2) FECHA2,FECHA1 FECHA1_ORIGINAL FROM VENTAS_CAT_SEMANAS "
        Me._QueryOrder = " ORDER BY FECHA1_ORIGINAL"
    End Sub

    Protected Overrides Sub Finalize()
        'Me._Conexion.Dispose()
        MyBase.Finalize()
    End Sub
#End Region

#Region "Métodos y procedimientos"
    Public Function ObtenerElementos() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dsCAT_Lineas As New SqlDataAdapter(Me._QuerySelect & Me._QueryOrder, Me._Conexion)
        Try
            dsCAT_Lineas.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementos", ex)
        Finally
            dsCAT_Lineas.Dispose()
        End Try
        Return dTable
    End Function
#End Region
End Class
