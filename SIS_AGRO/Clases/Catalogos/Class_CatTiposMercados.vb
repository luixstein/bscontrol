Imports System.Data
Imports System.Data.SqlClient

Public Class Class_CatTiposMercados

    Public Function ObtenerElementos() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dsCatTiposMercados As New SqlDataAdapter("SELECT CODIGO_MERCADO,NOMBRE_MERCADO,E.CODIGO_TIPO_MERCADO,V.NOMBRE_TIPO_MERCADO " & _
                                                     "FROM EMB_CAT_MERCADOS E INNER JOIN VENTAS_CAT_TIPOS_MERCADO V ON(E.CODIGO_TIPO_MERCADO=V.CODIGO_TIPO_MERCADO)", Empresa_Sistema.conexion)
        Try
            dsCatTiposMercados.Fill(dTable)
        Catch ex As Exception
            HandleError("Class_CatTiposMercados", "ObtenerElementos", ex)
        Finally
            dsCatTiposMercados.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerTiposMercadosParaReportes() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dsCatTiposMercados As New SqlDataAdapter("SELECT CODIGO_MERCADO,NOMBRE_MERCADO,E.CODIGO_TIPO_MERCADO,V.NOMBRE_TIPO_MERCADO " & _
                                                     "FROM EMB_CAT_MERCADOS E INNER JOIN VENTAS_CAT_TIPOS_MERCADO V ON(E.CODIGO_TIPO_MERCADO=V.CODIGO_TIPO_MERCADO)", Empresa_Sistema.conexion)
        Try
            dsCatTiposMercados.Fill(dTable)
            dTable.Rows.Add("T", "TODOS", "T", "TODOS")
        Catch ex As Exception
            HandleError("Class_CatTiposMercados", "ObtenerTiposMercadosParaReportes", ex)
        Finally
            dsCatTiposMercados.Dispose()
        End Try
        ObtenerTiposMercadosParaReportes = dTable
    End Function
End Class
