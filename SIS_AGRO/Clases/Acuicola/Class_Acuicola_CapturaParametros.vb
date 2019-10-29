Option Strict On

Imports System.Data.SqlClient

Public Class Class_Acuicola_CapturaParametros

#Region "Campos"
#Region "Campos de la tabla"
    Private _ID_CAPTURA_PARAMETROS_DETALLE As Integer
    Private _POSICION_REGISTRO As Integer
    Private _CODIGO_DOCUMENTO As String
    Private _FOLIO_ACUICOLA As String
    Private _FECHA As Date
    Private _TURNO As String
    Private _FECHA_SERVIDOR As Date
    Private _CODIGO_USUARIO_GRABO As Integer
    Private _ID_PROYECTO_SIEMBRA As Integer
    Private _CODIGO_PARAMETRO As Integer
    Private _VALOR As String

#End Region

#Region "Campos de sistema"
    Private _Nombre_Catalogo As String
    Private _Conexion As SqlConnection
#End Region

#Region "Campos ligados a la tabla"
    Private _Existe As Boolean 'lectura
    Public oDocumento As New Class_CatDocumentos
#End Region

#End Region

#Region "Propiedades"
#Region "Propiedades Campos de la tabla"
    Public Property ID_CAPTURA_PARAMETROS_DETALLE() As Integer
        Get
            Return _ID_CAPTURA_PARAMETROS_DETALLE
        End Get
        Set(ByVal value As Integer)
            Me._ID_CAPTURA_PARAMETROS_DETALLE = value
        End Set
    End Property

    Public ReadOnly Property POSICION_REGISTRO() As Integer
        Get
            Return _POSICION_REGISTRO
        End Get
    End Property

    Public Property CODIGO_DOCUMENTO() As String
        Get
            Return _CODIGO_DOCUMENTO
        End Get
        Set(ByVal value As String)
            Me._CODIGO_DOCUMENTO = value
        End Set
    End Property

    Public Property FOLIO_ACUICOLA() As String
        Get
            Return _FOLIO_ACUICOLA
        End Get
        Set(ByVal value As String)
            Me._FOLIO_ACUICOLA = value
        End Set
    End Property

    Public Property FECHA() As Date
        Get
            Return _FECHA
        End Get
        Set(ByVal value As Date)
            Me._FECHA = value
        End Set
    End Property

    Public Property TURNO() As String
        Get
            Return _TURNO
        End Get
        Set(ByVal value As String)
            Me._TURNO = value
        End Set
    End Property

    Public ReadOnly Property FECHA_SERVIDOR() As Date
        Get
            Return _FECHA_SERVIDOR
        End Get
    End Property

    Public ReadOnly Property CODIGO_USUARIO_GRABO() As Integer
        Get
            Return _CODIGO_USUARIO_GRABO
        End Get
    End Property

    Public Property ID_PROYECTO_SIEMBRA() As Integer
        Get
            Return _ID_PROYECTO_SIEMBRA
        End Get
        Set(ByVal value As Integer)
            Me._ID_PROYECTO_SIEMBRA = value
        End Set
    End Property

    Public Property CODIGO_PARAMETRO() As Integer
        Get
            Return _CODIGO_PARAMETRO
        End Get
        Set(ByVal value As Integer)
            Me._CODIGO_PARAMETRO = value
        End Set
    End Property

    Public Property VALOR() As String
        Get
            Return _VALOR
        End Get
        Set(ByVal value As String)
            Me._VALOR = value
        End Set
    End Property
#End Region

#Region "Propiedades internas"
    Public ReadOnly Property Nombre_Clase() As String
        Get
            Return "Class_Acuicola_CapturaParametros"
        End Get
    End Property

    Public ReadOnly Property Existe() As Boolean
        Get
            Return Me._Existe
        End Get
    End Property
#End Region

#End Region

#Region "Constructor y destructor"
    Public Sub New()
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
    End Sub

    Public Sub New(ByVal folioAcuicola As String)
        Me.New()
        Me._FOLIO_ACUICOLA = folioAcuicola

        Try
            If Me.Consultar = True Then
                Me._Existe = True
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "New", ex)
        End Try
    End Sub

    Protected Overrides Sub Finalize()
        'Me._Conexion.Dispose()
        MyBase.Finalize()
    End Sub
#End Region

#Region "Métodos y procedimientos"
    Public Function Consultar() As Boolean
        Dim bResultado As Boolean = False

        Dim cmd As New SqlCommand("")

        With cmd
            Try

            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "Consultar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
            End Try
        End With

        Return bResultado
    End Function

    Public Function GeneraFolio() As String
        Me.oDocumento.CODIGO_DOCUMENTO = Me._CODIGO_DOCUMENTO
        Me.oDocumento.GeneraFolio()
        Return Me.oDocumento.FOLIO
    End Function
#End Region

End Class
