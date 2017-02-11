Imports System.Data
Imports System.Data.SqlClient

Public Class Class_CatTiposNegociaciones
    Public Function ObtenerElementos() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dsCatTiposNegociaciones As New SqlDataAdapter("select CODIGO_TIPO_NEGOCIACION,NOMBRE_TIPO_NEGOCIACION from VENTAS_CAT_TIPOS_NEGOCIACION", Empresa_Sistema.conexion)
        Try
            dsCatTiposNegociaciones.Fill(dTable)
        Catch ex As Exception
            HandleError("Class_CatTiposNegociaciones", "ObtenerElementos", ex)
        Finally
            dsCatTiposNegociaciones.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerTiposNegociacionesParaReportes() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dsCatTiposMercados As New SqlDataAdapter("SELECT CAST(CODIGO_TIPO_NEGOCIACION AS NVARCHAR) AS CODIGO_TIPO_NEGOCIACION,NOMBRE_TIPO_NEGOCIACION from VENTAS_CAT_TIPOS_NEGOCIACION", Empresa_Sistema.conexion)
        Try
            dsCatTiposMercados.Fill(dTable)
            dTable.Rows.Add("T", "TODOS")
        Catch ex As Exception
            HandleError("Class_CatTiposNegociaciones", "ObtenerTiposNegociacionParaReportes", ex)
        Finally
            dsCatTiposMercados.Dispose()
        End Try
        ObtenerTiposNegociacionesParaReportes = dTable
    End Function
End Class
