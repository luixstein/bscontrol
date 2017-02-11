Imports System.Data
Imports System.Data.SqlClient

Public Class Class_TiposMercados
    Public Function ObtenerElementos() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dsCatTiposMercados As New SqlDataAdapter("select CODIGO_TIPO_MERCADO,NOMBRE_TIPO_MERCADO FROM VENTAS_CAT_TIPOS_MERCADO", Empresa_Sistema.conexion)
        Try
            dsCatTiposMercados.Fill(dTable)
        Catch ex As Exception
            HandleError("dsCatTiposMercados", "ObtenerElementos", ex)
        Finally
            dsCatTiposMercados.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerTiposMercadosParaReportes() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dsCatTiposMercados As New SqlDataAdapter("select CODIGO_TIPO_MERCADO,NOMBRE_TIPO_MERCADO FROM VENTAS_CAT_TIPOS_MERCADO", Empresa_Sistema.conexion)
        Try
            dsCatTiposMercados.Fill(dTable)
            dTable.Rows.Add("T", "TODOS")
        Catch ex As Exception
            HandleError("dsCatTiposMercados", "ObtenerTiposMercadosParaReportes", ex)
        Finally
            dsCatTiposMercados.Dispose()
        End Try
        ObtenerTiposMercadosParaReportes = dTable
    End Function
End Class
