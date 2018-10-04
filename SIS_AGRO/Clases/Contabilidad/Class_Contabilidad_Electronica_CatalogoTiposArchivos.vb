Option Strict On
Imports System.Data
Imports System.Data.SqlClient


Public Class Class_Contabilidad_Electronica_CatalogoTiposArchivos

#Region "Campos"

#Region "Campos de la tabla"
    Private _CODIGO_TIPO_ARCHIVO As String
    Private _NOMBRE_TIPO_ARCHIVO As String
    Private _CODIGO_TIPO_SAT As String
    Private _DESCRIPCION_TIPO_SAT As String
    Private _TERMINACION_NOMBRE_ARCHIVO_XML As String
    Private _EXISTE As Boolean 'LECTURA
#End Region

#Region "Campos de sistema"
    Private _Nombre_Catalogo As String
    Private _Conexion As SqlConnection
#End Region
#End Region

#Region "Propiedades"
#Region "Propiedades Campos de la tabla"
    Public ReadOnly Property CODIGO_TIPO_ARCHIVO() As String
        Get
            Return Me._CODIGO_TIPO_ARCHIVO
        End Get
    End Property

    Public ReadOnly Property NOMBRE_TIPO_ARCHIVO() As String
        Get
            Return Me._NOMBRE_TIPO_ARCHIVO
        End Get
    End Property

    Public ReadOnly Property CODIGO_TIPO_SAT() As String
        Get
            Return Me._CODIGO_TIPO_SAT
        End Get
    End Property

    Public ReadOnly Property DESCRIPCION_TIPO_SAT() As String
        Get
            Return Me._DESCRIPCION_TIPO_SAT
        End Get
    End Property

    Public ReadOnly Property TERMINACION_NOMBRE_ARCHIVO_XML() As String
        Get
            Return Me._TERMINACION_NOMBRE_ARCHIVO_XML
        End Get
    End Property

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
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
    End Sub

    Public Sub New(ByVal sCodigoTipoArchivo As String)
        Me.New()
        Me._CODIGO_TIPO_ARCHIVO = sCodigoTipoArchivo
        Try
            If Me.Consultar = True Then
                Me._EXISTE = True
            Else
                Throw New Exception("El tipo de archivo no existe.")
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "New", ex)
        End Try
    End Sub

    Protected Overrides Sub Finalize()
        'Me._Conexion.Dispose()
        MyBase.Finalize()
    End Sub
#End Region

#Region "Métodos y procedimientos"
    Public Function Consultar() As Boolean
        Dim cmd As New SqlCommand("SELECT * FROM CONTABILIDAD_ELECTRONICA_CATALOGO_TIPOS_ARCHIVO WHERE CODIGO_TIPO_ARCHIVO='" & Replace(Me._CODIGO_TIPO_ARCHIVO, "'", "''") & "'", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._CODIGO_TIPO_ARCHIVO = "" & dReader("CODIGO_TIPO_ARCHIVO").ToString
                    Me._NOMBRE_TIPO_ARCHIVO = "" & dReader("NOMBRE_TIPO_ARCHIVO").ToString
                    Me._CODIGO_TIPO_SAT = "" & dReader("CODIGO_TIPO_SAT").ToString
                    Me._DESCRIPCION_TIPO_SAT = "" & dReader("DESCRIPCION_TIPO_SAT").ToString
                    Me._TERMINACION_NOMBRE_ARCHIVO_XML = "" & dReader("TERMINACION_NOMBRE_ARCHIVO_XML").ToString
                    Consultar = True
                End If
                dReader.Close()
            Catch ex As Exception
                HandleError(Me.Nombre_Catalogo, "Consultar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
            End Try
        End With
    End Function
#End Region

End Class
