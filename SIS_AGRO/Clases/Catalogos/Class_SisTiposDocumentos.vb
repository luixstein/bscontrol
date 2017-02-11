Imports System.Data
Imports System.Data.SqlClient

Public Class Class_SisTiposDocumentos

#Region "Campos de sistema"
    Private _Conexion As SqlConnection
    Private _QuerySelect As String
    Private _QueryOrder As String
#End Region

#Region "Propiedad Nombre de Clase"
    Private ReadOnly Property NombreClase()
        Get
            NombreClase = "Class_SisTiposDocumentos"
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
    Public Function ObtenerTiposDocumentosContabilidaParaReporte() As System.Data.DataTable
        Dim dTable As New DataTable, dRow As DataRow
        Dim dsCaDocumentos As New SqlDataAdapter("SELECT CODIGO_TIPO_DOCUMENTO,NOMBRE_TIPO_DOCUMENTO FROM SIS_TIPOS_DOCUMENTOS WHERE CODIGO_MODULO='CON' AND CODIGO_TIPO_DOCUMENTO<>'O' ORDER BY NOMBRE_TIPO_DOCUMENTO", Me._Conexion)
        Try
            dsCaDocumentos.Fill(dTable)
            dRow = dTable.NewRow
            dRow("CODIGO_TIPO_DOCUMENTO") = "T"
            dRow("NOMBRE_TIPO_DOCUMENTO") = "TODOS"
            dTable.Rows.Add(dRow)
        Catch ex As Exception
            HandleError(Me.NombreClase, "ObtenerTiposDocumentosContabilidaParaReporte", ex)
        Finally
            dsCaDocumentos.Dispose()
        End Try
        Return dTable
    End Function    'Obtiene una liSta completa de los elementos del catalogo en un datatable.

    Public Function ObtenerTiposDocumentosContabilida() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dsCaDocumentos As New SqlDataAdapter("SELECT CODIGO_TIPO_DOCUMENTO,NOMBRE_TIPO_DOCUMENTO FROM SIS_TIPOS_DOCUMENTOS WHERE CODIGO_MODULO='CON' AND CODIGO_TIPO_DOCUMENTO<>'O' ORDER BY NOMBRE_TIPO_DOCUMENTO", Me._Conexion)
        Try
            dsCaDocumentos.Fill(dTable)
        Catch ex As Exception
            HandleError(Me.NombreClase, "ObtenerTiposDocumentosContabilida", ex)
        Finally
            dsCaDocumentos.Dispose()
        End Try
        Return dTable
    End Function    'Obtiene una liSta completa de los elementos del catalogo en un datatable.

    Public Function ObtenerTiposDocumentosCxpParaReporte() As System.Data.DataTable
        Dim dTable As New DataTable, dRow As DataRow
        Dim dsCaDocumentos As New SqlDataAdapter("SELECT CODIGO_TIPO_DOCUMENTO,NOMBRE_TIPO_DOCUMENTO FROM SIS_TIPOS_DOCUMENTOS WHERE CODIGO_MODULO='BAN' AND CODIGO_TIPO_DOCUMENTO<>'O' ORDER BY NOMBRE_TIPO_DOCUMENTO", Me._Conexion)
        Try
            dsCaDocumentos.Fill(dTable)
            dRow = dTable.NewRow
            dRow("CODIGO_TIPO_DOCUMENTO") = "T"
            dRow("NOMBRE_TIPO_DOCUMENTO") = "TODOS"
            dTable.Rows.Add(dRow)
        Catch ex As Exception
            HandleError(Me.NombreClase, "ObtenerTiposDocumentosCxpParaReporte", ex)
        Finally
            dsCaDocumentos.Dispose()
        End Try
        Return dTable
    End Function
#End Region

End Class


