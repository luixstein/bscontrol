Option Strict On

Imports System.Data.SqlClient

Public Class Class_Cat_tiposDocumentos

#Region "Campos"

#Region "Campos de la tabla"
    Private _CODIGO_TIPO_DOCUMENTO As String
    Private _NOMBRE_TIPO_DOCUMENTO As String
    Private _CODIGO_MODULO As String
    Private _AFECTA_CXC As String
    Private _NATURALEZA_CXC As String
    Private _AFECTA_CONTABILIDAD As String
    Private _AFECTA_INVENTARIOS As String
    Private _NATURALEZA_INVENTARIOS As String
    Private _AFECTA_CXP As String
    Private _NATURALEZA_CXP As String
    Private _ES_CANCELABLE As String
    Private _ES_TRANSFERENCIA As String
    Private _AFECTA_LOTES_SELECCIONADOS As Boolean
#End Region

#Region "Campos ligados a la tabla"

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
    Public Property CODIGO_TIPO_DOCUMENTO() As String
        Get
            Return Me._CODIGO_TIPO_DOCUMENTO
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_TIPO_DOCUMENTO = Value
        End Set
    End Property

    Public Property NOMBRE_TIPO_DOCUMENTO() As String
        Get
            Return Me._NOMBRE_TIPO_DOCUMENTO
        End Get
        Set(ByVal Value As String)
            Me._NOMBRE_TIPO_DOCUMENTO = Value
        End Set
    End Property

    Public Property CODIGO_MODULO() As String
        Get
            Return Me._CODIGO_MODULO
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_MODULO = Value
        End Set
    End Property

    Public Property AFECTA_CXC() As String
        Get
            Return Me._AFECTA_CXC
        End Get
        Set(ByVal Value As String)
            Me._AFECTA_CXC = Value
        End Set
    End Property

    Public Property NATURALEZA_CXC() As String
        Get
            Return Me._NATURALEZA_CXC
        End Get
        Set(ByVal Value As String)
            Me._NATURALEZA_CXC = Value
        End Set
    End Property

    Public Property AFECTA_CONTABILIDAD() As String
        Get
            Return Me._AFECTA_CONTABILIDAD
        End Get
        Set(ByVal Value As String)
            Me._AFECTA_CONTABILIDAD = Value
        End Set
    End Property

    Public Property AFECTA_INVENTARIOS() As String
        Get
            Return Me._AFECTA_INVENTARIOS
        End Get
        Set(ByVal Value As String)
            Me._AFECTA_INVENTARIOS = Value
        End Set
    End Property

    Public Property NATURALEZA_INVENTARIOS() As String
        Get
            Return Me._NATURALEZA_INVENTARIOS
        End Get
        Set(ByVal Value As String)
            Me._NATURALEZA_INVENTARIOS = Value
        End Set
    End Property

    Public Property AFECTA_CXP() As String
        Get
            Return Me._AFECTA_CXP
        End Get
        Set(ByVal Value As String)
            Me._AFECTA_CXP = Value
        End Set
    End Property

    Public Property NATURALEZA_CXP() As String
        Get
            Return Me._NATURALEZA_CXP
        End Get
        Set(ByVal Value As String)
            Me._NATURALEZA_CXP = Value
        End Set
    End Property

    Public Property ES_CANCELABLE() As String
        Get
            Return Me._ES_CANCELABLE
        End Get
        Set(ByVal Value As String)
            Me._ES_CANCELABLE = Value
        End Set
    End Property

    Public Property ES_TRANSFERENCIA() As String
        Get
            Return Me._ES_TRANSFERENCIA
        End Get
        Set(ByVal Value As String)
            Me._ES_TRANSFERENCIA = Value
        End Set
    End Property

    Public ReadOnly Property AFECTA_LOTES_SELECCIONADOS() As Boolean
        Get
            Return Me._AFECTA_LOTES_SELECCIONADOS
        End Get
    End Property

#End Region

#Region "Propiedades de campos ligados a la tabla"

#End Region

#Region "Propiedades públicos"

#End Region

#Region "Propiedades de campos privados"

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
        Me._Nombre_Catalogo = "SIS_TIPOS_DOCUMENTOS"
        Me._Nombre_Reporte = "RPT_SIS_TIPOS_DOCUMENTOS.rpt"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "Select * from SIS_TIPOS_DOCUMENTOS where "
        Me._QueryOrder = " Order by CODIGO_TIPO_DOCUMENTO"
    End Sub                                                         'Inicializa al objeto.

    Public Sub New(ByVal sCodigoTipoDocumento As String)
        Me.New()
        Try
            Me.CODIGO_TIPO_DOCUMENTO = sCodigoTipoDocumento
            If Me.Consultar = False Then
                Throw New Exception("El tipo de documento no existe.")
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
    Public Function Consultar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand(Me._QuerySelect & " CODIGO_TIPO_DOCUMENTO='" & Replace(Me.CODIGO_TIPO_DOCUMENTO, "'", "''") & "'", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._NOMBRE_TIPO_DOCUMENTO = "" & dReader("NOMBRE_TIPO_DOCUMENTO").ToString()
                    Me._CODIGO_MODULO = Trim("" & dReader("CODIGO_MODULO").ToString())
                    Me._AFECTA_CXC = Trim("" & dReader("AFECTA_CXC").ToString())
                    Me._NATURALEZA_CXC = "" & dReader("NATURALEZA_CXC").ToString()
                    Me._AFECTA_CONTABILIDAD = "" & dReader("AFECTA_CONTABILIDAD").ToString()
                    Me._AFECTA_INVENTARIOS = "" & dReader("AFECTA_INVENTARIOS").ToString()
                    Me._NATURALEZA_INVENTARIOS = "" & dReader("NATURALEZA_INVENTARIOS").ToString()
                    Me._AFECTA_CXP = "" & dReader("AFECTA_CXP").ToString()
                    Me._NATURALEZA_CXP = "" & dReader("NATURALEZA_CXP").ToString()
                    Me._ES_CANCELABLE = "" & dReader("ES_CANCELABLE").ToString()
                    Me._ES_TRANSFERENCIA = "" & dReader("ES_TRANSFERENCIA").ToString()
                    Me._AFECTA_LOTES_SELECCIONADOS = CBool(dReader("AFECTA_LOTES_SELECCIONADOS").ToString())

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
    End Function

#End Region

End Class