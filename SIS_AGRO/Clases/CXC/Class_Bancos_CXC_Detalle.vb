Option Explicit On
Option Strict On

Imports System.Data.SqlClient

Public Class Class_Bancos_CXC_Detalle

#Region "Campos"

#Region "Campos de la tabla"
    Private _ID_BANCOS_DETALLE As String
    Private _FOLIO_BANCO As String
    Private _CODIGO_METODO_PAGO As String
    Private _FOLIO_DETALLE As String
    Private _CODIGO_BANCO_EMISOR_NACIONAL As String
    Private _CUENTA_EMISOR As String
    Private _CODIGO_BANCO_DESTINO_NACIONAL As String
    Private _CUENTA_DESTINO As String
    Private _FECHA As Date
    Private _BENEFICIARIO As String
    Private _RFC_EMISOR As String
    Private _MONTO As Decimal
    Private _CODIGO_MONEDA_SAT As String
    Private _TIPO_CAMBIO As Decimal
#End Region

#Region "Campos de sistema"
    Private _Conexion As SqlConnection
#End Region

#Region "Campos ligados a la tabla"
    Private _EXISTE As Boolean 'lectura
#End Region

#End Region

#Region "Propiedades"
#Region "Propiedades Campos de la tabla"
    Public ReadOnly Property ID_BANCOS_DETALLE() As String
        Get
            Return Me._ID_BANCOS_DETALLE
        End Get
    End Property

    Public ReadOnly Property FOLIO_BANCO() As String
        Get
            Return Me._FOLIO_BANCO
        End Get
    End Property

    Public ReadOnly Property CODIGO_METODO_PAGO() As String
        Get
            Return Me._CODIGO_METODO_PAGO
        End Get
    End Property

    Public ReadOnly Property FOLIO_DETALLE() As String
        Get
            Return Me._FOLIO_DETALLE
        End Get
    End Property

    Public ReadOnly Property CODIGO_BANCO_EMISOR_NACIONAL() As String
        Get
            Return Me._CODIGO_BANCO_EMISOR_NACIONAL
        End Get
    End Property

    Public ReadOnly Property CUENTA_EMISOR() As String
        Get
            Return Me._CUENTA_EMISOR
        End Get
    End Property

    Public ReadOnly Property CODIGO_BANCO_DESTINO_NACIONAL() As String
        Get
            Return Me._CODIGO_BANCO_DESTINO_NACIONAL
        End Get
    End Property

    Public ReadOnly Property CUENTA_DESTINO() As String
        Get
            Return Me._CUENTA_DESTINO
        End Get
    End Property

    Public ReadOnly Property FECHA() As Date
        Get
            Return Me._FECHA
        End Get
    End Property

    Public ReadOnly Property BENEFICIARIO() As String
        Get
            Return Me._BENEFICIARIO
        End Get
    End Property

    Public ReadOnly Property RFC_EMISOR() As String
        Get
            Return Me._RFC_EMISOR
        End Get
    End Property

    Public ReadOnly Property MONTO() As Decimal
        Get
            Return Me._MONTO
        End Get
    End Property

    Public ReadOnly Property CODIGO_MONEDA_SAT() As String
        Get
            Return Me._CODIGO_MONEDA_SAT
        End Get
    End Property

    Public ReadOnly Property TIPO_CAMBIO() As Decimal
        Get
            Return Me._TIPO_CAMBIO
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
    Public ReadOnly Property Nombre_Clase() As String
        Get
            Return "Class_Bancos_CXC_Detalle"
        End Get
    End Property
#End Region

#End Region

#Region "Constructor y destructor"
    Public Sub New()
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
    End Sub

    Public Sub New(ByVal folioBanco As String)
        Me.New()
        Me._FOLIO_BANCO = folioBanco
        Try
            If Me.Consultar = True Then
                Me._EXISTE = True
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "New", ex)
        End Try
    End Sub

    Protected Overrides Sub Finalize()
        Me._Conexion.Dispose()
        MyBase.Finalize()
    End Sub
#End Region

#Region "Métodos y procedimientos"
    Public Function Consultar() As Boolean
        Dim bResultado As Boolean = False

        Dim sSQL As String = ""

        sSQL = "SELECT G.* " &
        "" &
        "FROM BANCOS_DETALLE G " &
        "WHERE G.FOLIO_BANCOS_GLOBAL='" & sReplace(Me._FOLIO_BANCO) & "' "

        Dim cmd As New SqlCommand(sSQL, Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read = True Then
                    Me._ID_BANCOS_DETALLE = dReader("ID_BANCOS_DETALLE").ToString
                    Me._FOLIO_BANCO = dReader("FOLIO_BANCOS_GLOBAL").ToString
                    Me._CODIGO_METODO_PAGO = dReader("CODIGO_METODO_PAGO").ToString
                    Me._FOLIO_DETALLE = dReader("FOLIO_DETALLE").ToString
                    Me._CODIGO_BANCO_EMISOR_NACIONAL = dReader("CODIGO_BANCO_EMISOR_NACIONAL").ToString
                    Me._CUENTA_EMISOR = dReader("CUENTA_EMISOR").ToString
                    Me._CODIGO_BANCO_DESTINO_NACIONAL = dReader("CODIGO_BANCO_DESTINO_NACIONAL").ToString
                    Me._CUENTA_DESTINO = dReader("CUENTA_DESTINO").ToString
                    Me._FECHA = CDate(dReader("FECHA"))
                    Me._BENEFICIARIO = dReader("BENEFICIARIO").ToString
                    Me._RFC_EMISOR = dReader("RFC_EMISOR").ToString
                    Me._MONTO = CDec(dReader("MONTO").ToString)
                    Me._CODIGO_MONEDA_SAT = dReader("CODIGO_MONEDA_SAT").ToString
                    Me._TIPO_CAMBIO = CDec(dReader("TIPO_CAMBIO").ToString)

                    bResultado = True
                End If
                dReader.Close()
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "Consultar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
            End Try
        End With

        Return bResultado
    End Function
#End Region

End Class
