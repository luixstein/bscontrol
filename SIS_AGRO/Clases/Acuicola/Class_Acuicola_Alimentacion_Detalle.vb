Option Strict On

Imports System.Data.SqlClient

Public Class Class_Acuicola_Alimentacion_Detalle

#Region "Campos"
#Region "Campos de la tabla"
    Private _ID_ACUICOLA_ALIMENTACION_DETALLE As Integer
    Private _FOLIO_ALIMENTACION As String
    Private _ID_PROYECTO_SIEMBRA As Integer
    Private _CODIGO_LOTE As String
    Private _ALIMENTO As Decimal
    Private _CANASTAS As String
    Private _MUERTOS As Decimal
    Private _OXIGENO As Decimal
    Private _TEMPERATURA As Decimal
    Private _CODIGO_TIPO_ALIMENTO As String
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
    Public Property ID_ACUICOLA_ALIMENTACION_DETALLE() As Integer
        Get
            Return Me._ID_ACUICOLA_ALIMENTACION_DETALLE
        End Get
        Set(ByVal value As Integer)
            Me._ID_ACUICOLA_ALIMENTACION_DETALLE = value
        End Set
    End Property

    Public Property FOLIO_ALIMENTACION() As String
        Get
            Return Me._FOLIO_ALIMENTACION
        End Get
        Set(ByVal value As String)
            Me._FOLIO_ALIMENTACION = value
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

    Public Property ALIMENTO() As Decimal
        Get
            Return Me._ALIMENTO
        End Get
        Set(ByVal value As Decimal)
            Me._ALIMENTO = value
        End Set
    End Property

    Public Property CANASTAS() As String
        Get
            Return Me._CANASTAS
        End Get
        Set(ByVal value As String)
            Me._CANASTAS = value
        End Set
    End Property

    Public Property MUERTOS() As Decimal
        Get
            Return Me._MUERTOS
        End Get
        Set(ByVal value As Decimal)
            Me._MUERTOS = value
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

    Public Property CODIGO_TIPO_ALIMENTO() As String
        Get
            Return Me._CODIGO_TIPO_ALIMENTO
        End Get
        Set(value As String)
            Me._CODIGO_TIPO_ALIMENTO = value
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
            Return "Class_Acuicola_Alimentacion_Detalle"
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
            .CommandText = "MP_ACUICOLA_ALIMENTACION_DETALLE_GRABA"

            sqlParametro = .Parameters.Add("@ID_ACUICOLA_ALIMENTACION_DETALLE", SqlDbType.Int) : sqlParametro.Value = 0 : sqlParametro.Direction = ParameterDirection.InputOutput
            sqlParametro = .Parameters.Add("@FOLIO_ALIMENTACION", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_ALIMENTACION
            sqlParametro = .Parameters.Add("@ID_PROYECTO_SIEMBRA", SqlDbType.SmallInt) : sqlParametro.Value = Me._ID_PROYECTO_SIEMBRA
            sqlParametro = .Parameters.Add("@CODIGO_LOTE", SqlDbType.NVarChar, 2) : sqlParametro.Value = Me._CODIGO_LOTE
            sqlParametro = .Parameters.Add("@ALIMENTO", SqlDbType.Decimal) : sqlParametro.Value = Me._ALIMENTO
            'sqlParametro = .Parameters.Add("@CANASTAS", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._CANASTAS
            'sqlParametro = .Parameters.Add("@MUERTOS", SqlDbType.Decimal) : sqlParametro.Value = Me._MUERTOS
            'sqlParametro = .Parameters.Add("@OXIGENO", SqlDbType.Decimal) : sqlParametro.Value = Me._OXIGENO
            'sqlParametro = .Parameters.Add("@TEMPERATURA", SqlDbType.Decimal) : sqlParametro.Value = Me._TEMPERATURA
            sqlParametro = .Parameters.Add("@CODIGO_TIPO_ALIMENTO", SqlDbType.NVarChar, 16) : sqlParametro.Value = Me._CODIGO_TIPO_ALIMENTO

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True

                Me._ID_ACUICOLA_ALIMENTACION_DETALLE = CInt("" & .Parameters("@ID_ACUICOLA_ALIMENTACION_DETALLE").Value.ToString)

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
