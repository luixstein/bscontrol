Imports System.Data
Imports System.Data.SqlClient

Public Class Class_Contabilidad_ListaFacturasRecibidas

#Region "Campos de sistema"
    Private _Conexion As SqlConnection
    Private _QuerySelect As String
    Private _QueryOrder As String
#End Region

#Region "Propiedad Nombre de Clase"
    Private ReadOnly Property NombreClase()
        Get
            NombreClase = "Class_CatListaFacturasRecibidas"
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
    Public Function ListaFacturasRecibidas() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dsCaDocumentos As New SqlDataAdapter("SELECT CODIGO_LISTA_FACTURAS_RECIBIDAS,NOMBRE_LISTA_FACTURAS_RECIBIDAS FROM CON_LISTA_FACTURAS_RECIBIDAS ", Me._Conexion)
        Try
            dsCaDocumentos.Fill(dTable)
        Catch ex As Exception
            HandleError(Me.NombreClase, "ListaFacturasRecibidas", ex)
        Finally
            dsCaDocumentos.Dispose()
        End Try
        ListaFacturasRecibidas = dTable
    End Function

#End Region

End Class
