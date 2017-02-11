
Imports System.Data
Imports System.Data.SqlClient

Public Class Class_CatEstatus

#Region "Campos de sistema"
    Private _Conexion As SqlConnection
    Private _QuerySelect As String
    Private _QueryOrder As String
#End Region

#Region "Propiedad Nombre de Clase"
    Private ReadOnly Property NombreClase()
        Get
            NombreClase = "Class_CatEstatus"
        End Get
    End Property
#End Region

#Region "Constructor y destructor"
    Public Sub New()
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
    End Sub                                                         'Inicializa al objeto.

    Protected Overrides Sub Finalize()
        'Me._Conexion.Dispose()
        MyBase.Finalize()
    End Sub
#End Region

#Region "Métodos y procedimientos"
    Public Function EstatusParaReportes() As System.Data.DataTable
        Dim dTable As New DataTable, dRow As DataRow
        Dim dsCaDocumentos As New SqlDataAdapter("SELECT CODIGO_ESTATUS,ESTATUS FROM CON_POLIZA_CAT_ESTATUS ORDER BY CODIGO_ESTATUS DESC, ESTATUS", Me._Conexion)
        Try
            dsCaDocumentos.Fill(dTable)
            dRow = dTable.NewRow
            dRow("CODIGO_ESTATUS") = "T"
            dRow("ESTATUS") = "TODOS"
            dTable.Rows.Add(dRow)

        Catch ex As Exception
            HandleError(Me.NombreClase, "EstatusParaReportes", ex)
        Finally
            dsCaDocumentos.Dispose()
        End Try
        EstatusParaReportes = dTable
    End Function
#End Region

End Class
