Option Strict On
Imports System.Data.SqlClient

Public Class Class_CFDCatTiposRegimenesFiscales

#Region "Campos"

#Region "Campos de la tabla"
    Private _CODIGO_REGIMEN_FISCAL As String
    Private _NOMBRE_REGIMEN_FISCAL As String
    Private _APLICA_TIPO_FISICA As Boolean
    Private _APLICA_TIPO_MORAL As Boolean
    Private _PERMITE_SELECCION As Boolean
#End Region

#Region "Campos ligados a la tabla"
    Private _EXISTE As Boolean
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
    Public ReadOnly Property CODIGO_REGIMEN_FISCAL() As String
        Get
            Return Me._CODIGO_REGIMEN_FISCAL
        End Get
    End Property

    Public ReadOnly Property NOMBRE_REGIMEN_FISCAL() As String
        Get
            Return Me._NOMBRE_REGIMEN_FISCAL
        End Get
    End Property

    Public ReadOnly Property APLICA_TIPO_FISICA() As Boolean
        Get
            Return Me._APLICA_TIPO_FISICA
        End Get
    End Property

    Public ReadOnly Property APLICA_TIPO_MORAL() As Boolean
        Get
            Return Me._APLICA_TIPO_MORAL
        End Get
    End Property

    Public ReadOnly Property PERMITE_SELECCION() As Boolean
        Get
            Return Me._PERMITE_SELECCION
        End Get
    End Property
#End Region

#Region "Propiedades de campos ligados a la tabla"
    Public ReadOnly Property EXISTE() As Boolean
        Get
            Return Me._EXISTE
        End Get
    End Property
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
        Me._Nombre_Catalogo = "CDF_CAT_TIPOS_REGIMENES_FISCALES"
        Me._Nombre_Reporte = ".rpt"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "SELECT * FROM CDF_CAT_TIPOS_REGIMENES_FISCALES"
        Me._QueryOrder = " ORDER BY CODIGO_REGIMEN_FISCAL"
    End Sub

    Protected Overrides Sub Finalize()
        'Me._Conexion.Dispose()
        MyBase.Finalize()
    End Sub
#End Region

#Region "Métodos y procedimientos"

    Public Function Consultar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand(Me._QuerySelect & " WHERE CODIGO_REGIMEN_FISCAL=" & sReplace(Me._CODIGO_REGIMEN_FISCAL.ToString), Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read = True Then
                    Me._CODIGO_REGIMEN_FISCAL = dReader("CODIGO_REGIMEN_FISCAL").ToString
                    Me._NOMBRE_REGIMEN_FISCAL = dReader("NOMBRE_REGIMEN_FISCAL").ToString
                    Me._APLICA_TIPO_FISICA = CBool(dReader("APLICA_TIPO_FISICA").ToString)
                    Me._APLICA_TIPO_MORAL = CBool(dReader("APLICA_TIPO_MORAL").ToString)
                    Me._PERMITE_SELECCION = CBool(dReader("PERMITE_SELECCION").ToString)
                    bResultado = True
                End If
                dReader.Close()
            Catch ex As Exception
                HandleError(Me.Nombre_Catalogo, "Consultar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
            End Try
        End With
        Return bResultado
    End Function        '

    Public Function ObtenerElementos() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter("SELECT * FROM CDF_CAT_TIPOS_REGIMENES_FISCALES ORDER BY CODIGO_REGIMEN_FISCAL", Me._Conexion)
        Try
            da.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementos", ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerElementosSeleccionables() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter("SELECT * FROM CDF_CAT_TIPOS_REGIMENES_FISCALES WHERE PERMITE_SELECCION='1' ORDER BY CODIGO_REGIMEN_FISCAL", Me._Conexion)
        Try
            da.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementosSeleccionables", ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function
#End Region

End Class

