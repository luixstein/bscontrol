Option Strict On

Imports System.Data.SqlClient

Public Class Class_CFD_CatTiposRelacionCFDI

#Region "Campos"

#Region "Campos de la tabla"
    Private _CODIGO_TIPO_RELACION_CFDI As String
    Private _NOMBRE_TIPO_RELACION_CFDI As String
    Private _ESTATUS As String
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
    Public ReadOnly Property CODIGO_TIPO_RELACION_CFDI() As String
        Get
            Return Me._CODIGO_TIPO_RELACION_CFDI
        End Get
    End Property

    Public ReadOnly Property NOMBRE_TIPO_RELACION_CFDI() As String
        Get
            Return Me._NOMBRE_TIPO_RELACION_CFDI
        End Get
    End Property

    Public ReadOnly Property ESTATUS() As String
        Get
            Return Me._ESTATUS
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

    Public Property Nombre_Reporte() As String
        Get
            Return Me._Nombre_Reporte
        End Get
        Set(ByVal value As String)
            Me._Nombre_Reporte = value
        End Set
    End Property
#End Region

#End Region

#Region "Constructor y destructor"
    Public Sub New()
        Me._Nombre_Catalogo = "Class_CFD_CatTiposRelacionCFDI"
        Me._Nombre_Reporte = "RPT_CFDI_CAT_TIPOS_RELACIONES"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "SELECT * FROM CFDI_CAT_TIPOS_RELACIONES"
        Me._QueryOrder = " ORDER BY NOMBRE_TIPO_RELACION_CFDI"
    End Sub

    Public Sub New(ByVal sCodigo As String)
        Me.New()
        Me._CODIGO_TIPO_RELACION_CFDI = sCodigo
        Try
            If Me.Consultar = True Then
                Me._EXISTE = True
            Else
                Throw New Exception("El tipo de relación CFDI no existe.")
            End If
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "New", ex)
        End Try
    End Sub

    Protected Overrides Sub Finalize()
        'Me._Conexion.Dispose()
        MyBase.Finalize()
    End Sub
#End Region

#Region "Métodos y procedimientos"
    Public Function ObtenerElementos() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter("SELECT CODIGO_TIPO_RELACION_CFDI,CODIGO_TIPO_RELACION_CFDI + ' - ' + NOMBRE_TIPO_RELACION_CFDI NOMBRE_TIPO_RELACION_CFDI FROM CFDI_CAT_TIPOS_RELACIONES WHERE ESTATUS='A' ORDER BY CODIGO_TIPO_RELACION_CFDI", Empresa_Sistema.conexion)
        Try
            da.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementos", ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

    Public Function Consultar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand(Me._QuerySelect & " WHERE CODIGO_TIPO_RELACION_CFDI='" & Me._CODIGO_TIPO_RELACION_CFDI & "'", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._CODIGO_TIPO_RELACION_CFDI = dReader("CODIGO_TIPO_RELACION_CFDI").ToString
                    Me._NOMBRE_TIPO_RELACION_CFDI = Trim("" & dReader("NOMBRE_TIPO_RELACION_CFDI").ToString)
                    Me._ESTATUS = dReader("ESTATUS").ToString

                    bResultado = True
                End If
                dReader.Close()
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "Consultar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
            End Try
        End With
        Return bResultado
    End Function

#End Region

End Class
