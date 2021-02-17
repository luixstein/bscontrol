Option Strict On

Imports System.Data.SqlClient

Public Class Class_Acuicola_Parametria_Detalle

#Region "Campos"
#Region "Campos de la tabla"
    Private _ID_ACUICOLA_PARAMETRIA_DETALLE As Integer
    Private _FOLIO_PARAMETRIA As String
    Private _ID_PROYECTO_SIEMBRA As Integer
    Private _CODIGO_LOTE As String
    Private _PESO As Decimal
    Private _ORGANISMOS As Decimal
    Private _GRAMAJE As Decimal
    Private _INCREMENTO As Decimal
    Private _TARRALLAZOS As Decimal
    Private _MUERTOS As Decimal
    Private _PORCENTAJE_SUPERVIVENCIA_ESTIMADO As Decimal
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
    Public Property ID_ACUICOLA_PARAMETRIA_DETALLE() As Integer
        Get
            Return Me._ID_ACUICOLA_PARAMETRIA_DETALLE
        End Get
        Set(ByVal value As Integer)
            Me._ID_ACUICOLA_PARAMETRIA_DETALLE = value
        End Set
    End Property

    Public Property FOLIO_PARAMETRIA() As String
        Get
            Return Me._FOLIO_PARAMETRIA
        End Get
        Set(ByVal value As String)
            Me._FOLIO_PARAMETRIA = value
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

    Public Property PESO() As Decimal
        Get
            Return Me._PESO
        End Get
        Set(ByVal value As Decimal)
            Me._PESO = value
        End Set
    End Property

    Public Property ORGANISMOS() As Decimal
        Get
            Return Me._ORGANISMOS
        End Get
        Set(ByVal value As Decimal)
            Me._ORGANISMOS = value
        End Set
    End Property

    Public Property GRAMAJE() As Decimal
        Get
            Return Me._GRAMAJE
        End Get
        Set(ByVal value As Decimal)
            Me._GRAMAJE = value
        End Set
    End Property

    Public Property INCREMENTO() As Decimal
        Get
            Return Me._INCREMENTO
        End Get
        Set(ByVal value As Decimal)
            Me._INCREMENTO = value
        End Set
    End Property

    Public Property TARRALLAZOS() As Decimal
        Get
            Return Me._TARRALLAZOS
        End Get
        Set(ByVal value As Decimal)
            Me._TARRALLAZOS = value
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

    Public Property PORCENTAJE_SUPERVIVENCIA_ESTIMADO() As Decimal
        Get
            Return Me._PORCENTAJE_SUPERVIVENCIA_ESTIMADO
        End Get
        Set(value As Decimal)
            Me._PORCENTAJE_SUPERVIVENCIA_ESTIMADO = value
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
            Return "Class_Acuicola_Parametria_Detalle"
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
            .CommandText = "MP_ACUICOLA_PARAMETRIA_DETALLE_GRABA"

            sqlParametro = .Parameters.Add("@ID_ACUICOLA_PARAMETRIA_DETALLE", SqlDbType.Int) : sqlParametro.Value = 0 : sqlParametro.Direction = ParameterDirection.InputOutput
            sqlParametro = .Parameters.Add("@FOLIO_PARAMETRIA", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_PARAMETRIA
            sqlParametro = .Parameters.Add("@ID_PROYECTO_SIEMBRA", SqlDbType.SmallInt) : sqlParametro.Value = Me._ID_PROYECTO_SIEMBRA
            sqlParametro = .Parameters.Add("@CODIGO_LOTE", SqlDbType.NVarChar, 2) : sqlParametro.Value = Me._CODIGO_LOTE
            sqlParametro = .Parameters.Add("@PESO", SqlDbType.Decimal) : sqlParametro.Value = Me._PESO
            sqlParametro = .Parameters.Add("@ORGANISMOS", SqlDbType.Decimal) : sqlParametro.Value = Me._ORGANISMOS
            'sqlParametro = .Parameters.Add("@GRAMAJE", SqlDbType.Decimal) : sqlParametro.Value = Me._GRAMAJE
            'sqlParametro = .Parameters.Add("@INCREMENTO", SqlDbType.Decimal) : sqlParametro.Value = Me._INCREMENTO
            sqlParametro = .Parameters.Add("@TARRALLAZOS", SqlDbType.Decimal) : sqlParametro.Value = Me._TARRALLAZOS
            sqlParametro = .Parameters.Add("@MUERTOS", SqlDbType.Decimal) : sqlParametro.Value = Me._MUERTOS
            sqlParametro = .Parameters.Add("@PORCENTAJE_SUPERVIVENCIA_ESTIMADO", SqlDbType.Decimal) : sqlParametro.Value = Me._PORCENTAJE_SUPERVIVENCIA_ESTIMADO

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True

                Me._ID_ACUICOLA_PARAMETRIA_DETALLE = CInt("" & .Parameters("@ID_ACUICOLA_PARAMETRIA_DETALLE").Value.ToString)

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
