Option Strict On

Imports System.Data.SqlClient

Public Class Class_ComplementoINE_Detalle
#Region "Campos"
#Region "Campos de la tabla"
    Private _ID_DETALLE_ENTIDADES As Integer
    Private _FOLIO_VENTA As String
    Private _CODIGO_ENTIDAD As String
    Private _CODIGO_AMBITO As Integer

#End Region

#Region "Campos ligados a la tabla"
    Private _ID_DETALLE_CONTABILIDADES As Integer
    Private _ID_CONTABILIDAD As String
    Private _Existe As Boolean
    Private _Nombre_Formato As String
#End Region

#Region "Campos de sistema"
    Private _Conexion As SqlConnection
#End Region
#End Region

#Region "Propiedades"

#Region "Propiedades campos de la tabla"
    Public ReadOnly Property ID_DETALLE_ENTIDADES() As Integer
        Get
            Return Me._ID_DETALLE_ENTIDADES
        End Get
    End Property

    Public Property FOLIO_VENTA() As String
        Get
            Return Me._FOLIO_VENTA
        End Get
        Set(ByVal Value As String)
            Me._FOLIO_VENTA = Value
        End Set
    End Property

    Public Property CODIGO_ENTIDAD() As String
        Get
            Return Me._CODIGO_ENTIDAD
        End Get
        Set(value As String)
            Me._CODIGO_ENTIDAD = value
        End Set
    End Property

    Public Property CODIGO_AMBITO() As Integer
        Get
            Return Me._CODIGO_AMBITO
        End Get
        Set(value As Integer)
            Me._CODIGO_AMBITO = value
        End Set
    End Property

#End Region

#Region "Propiedades de campos ligados a la tabla"
    Public ReadOnly Property ID_DETALLE_CONTABILIDADES() As Integer
        Get
            Return Me._ID_DETALLE_CONTABILIDADES
        End Get
    End Property

    Public Property ID_CONTABILIDAD() As String
        Get
            Return Me._ID_CONTABILIDAD
        End Get
        Set(value As String)
            Me._ID_CONTABILIDAD = value
        End Set
    End Property

    Public ReadOnly Property Existe() As Boolean
        Get
            Return Me._Existe
        End Get
    End Property

    Public ReadOnly Property Nombre_Formato() As String
        Get
            Return Me._Nombre_Formato
        End Get
    End Property
#End Region

#Region "Propiedades de sistema"
    Private ReadOnly Property NombreClase() As String
        Get
            Return "Class_ComplementoINE_Detalle"
        End Get
    End Property
#End Region

#End Region

#Region "Constructor y destructor"
    Public Sub New()
        Me._Conexion = New SqlConnection(Empresa_Sistema.conexion)
    End Sub

    'Public Sub New()
    '    Me.New()
    '    Me._Conexion = New SqlConnection(Empresa_Sistema.conexion)
    '    'Try
    '    '    Me._FOLIO_VENTA = sFOLIO_VENTA
    '    '    If Me.Consultar() = True Then
    '    '        Me._Existe = True
    '    '    End If
    '    'Catch ex As Exception
    '    '    HandleError(Me.NombreClase, "New", ex)
    '    'End Try
    'End Sub

    Protected Overrides Sub Finalize()
        'Me._Conexion.Dispose()
        MyBase.Finalize()
    End Sub
#End Region

#Region "Métodos y procedimientos"
    Public Function GrabarDetalleEntidades() As Boolean
        Const sProcedure As String = "GrabarDetalleEntidades"
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter

        Try
            With cmd
                .Connection = Me._Conexion
                .CommandTimeout = 0
                .CommandType = CommandType.StoredProcedure
                .CommandText = "MP_VENTAS_COMPLEMENTO_INE_DETALLE_ENTIDADES_GRABA"

                sqlParametro = .Parameters.Add("@ID_DETALLE_ENTIDADES", SqlDbType.SmallInt) : sqlParametro.Value = 0 : sqlParametro.Direction = ParameterDirection.InputOutput
                sqlParametro = .Parameters.Add("@FOLIO_VENTA", SqlDbType.NVarChar, 14) : sqlParametro.Value = Me._FOLIO_VENTA
                sqlParametro = .Parameters.Add("@CODIGO_ENTIDAD", SqlDbType.NVarChar, 3) : sqlParametro.Value = Me._CODIGO_ENTIDAD
                sqlParametro = .Parameters.Add("@CODIGO_AMBITO", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_AMBITO

                Me._Conexion.Open()
                .ExecuteNonQuery()

                Me._ID_DETALLE_ENTIDADES = CInt(.Parameters("@ID_DETALLE_ENTIDADES").Value)

                bResultado = True
            End With

        Catch ex As Exception
            HandleError(Me.NombreClase, sProcedure, ex)
        Finally
            Me._Conexion.Close()
            cmd.Dispose()
            sqlParametro = Nothing
        End Try

        Return bResultado
    End Function

    Public Function GrabarDetalleContabilidades() As Boolean
        Const sProcedure As String = "GrabarDetalleContabilidades"
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter

        Try
            With cmd
                .Connection = Me._Conexion
                .CommandTimeout = 0
                .CommandType = CommandType.StoredProcedure
                .CommandText = "MP_VENTAS_COMPLEMENTO_INE_DETALLE_CONTABILIDADES_GRABA"

                sqlParametro = .Parameters.Add("@ID_DETALLE_ENTIDADES", SqlDbType.Int) : sqlParametro.Value = Me._ID_DETALLE_ENTIDADES
                sqlParametro = .Parameters.Add("@ID_CONTABILIDAD", SqlDbType.NVarChar, 6) : sqlParametro.Value = Me._ID_CONTABILIDAD

                Me._Conexion.Open()
                .ExecuteNonQuery()

                bResultado = True
            End With

        Catch ex As Exception
            HandleError(Me.NombreClase, sProcedure, ex)
        Finally
            Me._Conexion.Close()
            cmd.Dispose()
            sqlParametro = Nothing
        End Try

        Return bResultado
    End Function

#End Region

End Class
