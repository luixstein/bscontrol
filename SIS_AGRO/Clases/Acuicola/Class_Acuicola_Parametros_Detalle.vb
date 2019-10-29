Option Strict On

Imports System.Data.SqlClient

Public Class Class_Acuicola_Parametros_Detalle

#Region "Campos"
#Region "Campos de la tabla"
    Private _ID_ACUICOLA_PARAMETROS_DETALLE As Integer
    Private _FOLIO_PARAMETROS As String
    Private _ID_PROYECTO_SIEMBRA As Integer
    Private _CODIGO_LOTE As String
    Private _OXIGENO As Decimal
    Private _TEMPERATURA As Decimal
#End Region

#Region "Campos ligados a la tabla"
#End Region

#Region "Campos de sistema"
    Private _Nombre_Catalogo As String
    Private _Conexion As SqlConnection
#End Region

#End Region

#Region "Propiedades"
#Region "Propiedades Campos de la tabla"
    Public Property ID_ACUICOLA_PARAMETROS_DETALLE() As Integer
        Get
            Return Me._ID_ACUICOLA_PARAMETROS_DETALLE
        End Get
        Set(ByVal value As Integer)
            Me._ID_ACUICOLA_PARAMETROS_DETALLE = value
        End Set
    End Property

    Public Property FOLIO_PARAMETROS() As String
        Get
            Return Me._FOLIO_PARAMETROS
        End Get
        Set(ByVal value As String)
            Me._FOLIO_PARAMETROS = value
        End Set
    End Property

    Public Property ID_PROYECTO_SIEMBRA() As Integer
        Get
            Return Me._ID_PROYECTO_SIEMBRA
        End Get
        Set(ByVal value As Integer)
            Me._ID_PROYECTO_SIEMBRA = value
        End Set
    End Property

    Public Property CODIGO_LOTE() As String
        Get
            Return Me._CODIGO_LOTE
        End Get
        Set(ByVal value As String)
            Me._CODIGO_LOTE = value
        End Set
    End Property

    Public Property OXIGENO() As Decimal
        Get
            Return Me._OXIGENO
        End Get
        Set(ByVal value As Decimal)
            Me._OXIGENO = value
        End Set
    End Property

    Public Property TEMPERATURA() As Decimal
        Get
            Return Me._TEMPERATURA
        End Get
        Set(ByVal value As Decimal)
            Me._TEMPERATURA = value
        End Set
    End Property

#End Region

#Region "Propiedades de campos ligados a la tabla"
    'Public ReadOnly Property Existe() As Boolean
    '    Get
    '        Return Me._Existe
    '    End Get
    'End Property
#End Region

#Region "Propiedades de campos de sistema"
    Public ReadOnly Property Nombre_Clase() As String
        Get
            Return "Class_Acuicola_CapturaParametros"
        End Get
    End Property

#End Region

#End Region

#Region "Constructor y destructor"
    Public Sub New()
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
    End Sub

    Protected Overrides Sub Finalize()
        'Me._Conexion.Dispose()
        MyBase.Finalize()
    End Sub
#End Region

#Region "Métodos y procedimientos"
    Public Function GrabaRenglon() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter

        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_ACUICOLA_PARAMETROS_DETALLE_GRABA"

            sqlParametro = .Parameters.Add("@ID_ACUICOLA_PARAMETROS_DETALLE", SqlDbType.Int) : sqlParametro.Value = 0 : sqlParametro.Direction = ParameterDirection.InputOutput
            sqlParametro = .Parameters.Add("@FOLIO_PARAMETROS", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_PARAMETROS
            sqlParametro = .Parameters.Add("@ID_PROYECTO_SIEMBRA", SqlDbType.SmallInt) : sqlParametro.Value = Me._ID_PROYECTO_SIEMBRA
            sqlParametro = .Parameters.Add("@CODIGO_LOTE", SqlDbType.NVarChar, 2) : sqlParametro.Value = Me._CODIGO_LOTE
            sqlParametro = .Parameters.Add("@OXIGENO", SqlDbType.Decimal) : sqlParametro.Value = Me._OXIGENO
            sqlParametro = .Parameters.Add("@TEMPERATURA", SqlDbType.Decimal) : sqlParametro.Value = Me._TEMPERATURA

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True

                Me._ID_ACUICOLA_PARAMETROS_DETALLE = CInt("" & .Parameters("@ID_ACUICOLA_PARAMETROS_DETALLE").Value.ToString)

            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "GrabaRenglon", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function
#End Region

End Class
