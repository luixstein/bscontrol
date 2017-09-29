Imports System.Data
Imports System.Data.SqlClient

Public Class Class_CatTiposCreditos
    Public Function ObtenerElementos() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dsCatTiposCreditos As New SqlDataAdapter("SELECT CODIGO_TIPO_CREDITO,NOMBRE_TIPO_CREDITO FROM CAT_TIPOS_CREDITO WHERE CODIGO_TIPO_CREDITO <> 'NA' ", Empresa_Sistema.conexion)
        Try
            dsCatTiposCreditos.Fill(dTable)
        Catch ex As Exception
            HandleError("Class_CatTiposCreditos", "ObtenerElementos", ex)
        Finally
            dsCatTiposCreditos.Dispose()
        End Try
        Return dTable
    End Function

End Class
