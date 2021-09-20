Option Strict On

Imports System.Data.SqlClient

Public Class Class_Acuicola_Intensivos_Detalle

#Region "Campos"
#Region "Campos de la tabla"
    Private _ID_ACUICOLA_INTENSIVOS_DETALLE As Integer
    Private _FOLIO_INTENSIVOS As String
    Private _ID_PROYECTO_SIEMBRA As Integer
    Private _CODIGO_LOTE As String
    Private _HORA As String
    Private _RACION_ALIMENTO As Decimal
    Private _CODIGO_TIPO_ALIMENTO As String
    Private _CANASTAS As String
    Private _ALIMENTO_EN_SIFONEO As String
    Private _VIVOS As Decimal
    Private _MUERTOS As Decimal
    Private _LASTIMADOS As Decimal
    Private _OXIGENO As Decimal
    Private _TEMPERATURA As Decimal
    Private _PH As Decimal
    Private _SAL As Decimal
    Private _CALCIO As Decimal
    Private _POTASIO As Decimal
    Private _MAGNESIO As Decimal
    Private _NITRITOS As Decimal
    Private _AMONIO As Decimal
    Private _ALCALINIDAD As Decimal

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
    Public Property ID_ACUICOLA_INTENSIVOS_DETALLE() As Integer
        Get
            Return Me._ID_ACUICOLA_INTENSIVOS_DETALLE
        End Get
        Set(ByVal value As Integer)
            Me._ID_ACUICOLA_INTENSIVOS_DETALLE = value
        End Set
    End Property

    Public Property FOLIO_INTENSIVOS() As String
        Get
            Return Me._FOLIO_INTENSIVOS
        End Get
        Set(ByVal value As String)
            Me._FOLIO_INTENSIVOS = value
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

    Public Property HORA() As String
        Get
            Return Me._HORA
        End Get
        Set(ByVal value As String)
            Me._HORA = value
        End Set
    End Property

    Public Property RACION_ALIMENTO() As Decimal
        Get
            Return Me._RACION_ALIMENTO
        End Get
        Set(ByVal value As Decimal)
            Me._RACION_ALIMENTO = value
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

    Public Property CANASTAS() As String
        Get
            Return Me._CANASTAS
        End Get
        Set(ByVal value As String)
            Me._CANASTAS = value
        End Set
    End Property

    Public Property ALIMENTO_EN_SIFONEO() As String
        Get
            Return Me._ALIMENTO_EN_SIFONEO
        End Get
        Set(value As String)
            Me._ALIMENTO_EN_SIFONEO = value
        End Set
    End Property

    Public Property VIVOS() As Decimal
        Get
            Return Me._VIVOS
        End Get
        Set(ByVal value As Decimal)
            Me._VIVOS = value
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

    Public Property LASTIMADOS() As Decimal
        Get
            Return Me._LASTIMADOS
        End Get
        Set(ByVal value As Decimal)
            Me._LASTIMADOS = value
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

    Public Property PH() As Decimal
        Get
            Return Me._PH
        End Get
        Set(ByVal value As Decimal)
            Me._PH = value
        End Set
    End Property

    Public Property SAL() As Decimal
        Get
            Return Me._SAL
        End Get
        Set(ByVal value As Decimal)
            Me._SAL = value
        End Set
    End Property

    Public Property CALCIO() As Decimal
        Get
            Return Me._CALCIO
        End Get
        Set(ByVal value As Decimal)
            Me._CALCIO = value
        End Set
    End Property

    Public Property POTASIO() As Decimal
        Get
            Return Me._POTASIO
        End Get
        Set(ByVal value As Decimal)
            Me._POTASIO = value
        End Set
    End Property

    Public Property MAGNESIO() As Decimal
        Get
            Return Me._MAGNESIO
        End Get
        Set(ByVal value As Decimal)
            Me._MAGNESIO = value
        End Set
    End Property

    Public Property NITRITOS() As Decimal
        Get
            Return Me._NITRITOS
        End Get
        Set(ByVal value As Decimal)
            Me._NITRITOS = value
        End Set
    End Property

    Public Property AMONIO() As Decimal
        Get
            Return Me._AMONIO
        End Get
        Set(ByVal value As Decimal)
            Me._AMONIO = value
        End Set
    End Property

    Public Property ALCALINIDAD() As Decimal
        Get
            Return Me._ALCALINIDAD
        End Get
        Set(ByVal value As Decimal)
            Me._ALCALINIDAD = value
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
            Return "Class_Acuicola_INTENSIVOS_Detalle"
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
            .CommandText = "MP_ACUICOLA_INTENSIVOS_DETALLE_GRABA"

            sqlParametro = .Parameters.Add("@ID_ACUICOLA_INTENSIVOS_DETALLE", SqlDbType.Int) : sqlParametro.Value = 0 : sqlParametro.Direction = ParameterDirection.InputOutput
            sqlParametro = .Parameters.Add("@FOLIO_INTENSIVOS", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_INTENSIVOS
            sqlParametro = .Parameters.Add("@ID_PROYECTO_SIEMBRA", SqlDbType.SmallInt) : sqlParametro.Value = Me._ID_PROYECTO_SIEMBRA
            sqlParametro = .Parameters.Add("@CODIGO_LOTE", SqlDbType.NVarChar, 2) : sqlParametro.Value = Me._CODIGO_LOTE
            sqlParametro = .Parameters.Add("@HORA", SqlDbType.Time) : sqlParametro.Value = Me._HORA
            sqlParametro = .Parameters.Add("@RACION_ALIMENTO", SqlDbType.Decimal) : sqlParametro.Value = Me._RACION_ALIMENTO
            sqlParametro = .Parameters.Add("@CODIGO_TIPO_ALIMENTO", SqlDbType.NVarChar, 16) : sqlParametro.Value = Me._CODIGO_TIPO_ALIMENTO
            sqlParametro = .Parameters.Add("@CANASTAS", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._CANASTAS
            sqlParametro = .Parameters.Add("@ALIMENTO_EN_SIFONEO", SqlDbType.Char) : sqlParametro.Value = Me._ALIMENTO_EN_SIFONEO
            sqlParametro = .Parameters.Add("@VIVOS", SqlDbType.Decimal) : sqlParametro.Value = Me._VIVOS
            sqlParametro = .Parameters.Add("@MUERTOS", SqlDbType.Decimal) : sqlParametro.Value = Me._MUERTOS
            sqlParametro = .Parameters.Add("@LASTIMADOS", SqlDbType.Decimal) : sqlParametro.Value = Me._LASTIMADOS
            sqlParametro = .Parameters.Add("@OXIGENO", SqlDbType.Decimal) : sqlParametro.Value = Me._OXIGENO
            sqlParametro = .Parameters.Add("@TEMPERATURA", SqlDbType.Decimal) : sqlParametro.Value = Me._TEMPERATURA
            'sqlParametro = .Parameters.Add("@PH", SqlDbType.Decimal) : sqlParametro.Value = Me._PH
            'sqlParametro = .Parameters.Add("@SAL", SqlDbType.Decimal) : sqlParametro.Value = Me._SAL
            'sqlParametro = .Parameters.Add("@CALCIO", SqlDbType.Decimal) : sqlParametro.Value = Me._CALCIO
            'sqlParametro = .Parameters.Add("@POTASIO", SqlDbType.Decimal) : sqlParametro.Value = Me._POTASIO
            'sqlParametro = .Parameters.Add("@MAGNESIO", SqlDbType.Decimal) : sqlParametro.Value = Me._MAGNESIO
            'sqlParametro = .Parameters.Add("@NITRITOS", SqlDbType.Decimal) : sqlParametro.Value = Me._NITRITOS
            'sqlParametro = .Parameters.Add("@AMONIO", SqlDbType.Decimal) : sqlParametro.Value = Me._AMONIO
            'sqlParametro = .Parameters.Add("@ALCALINIDAD", SqlDbType.Decimal) : sqlParametro.Value = Me._ALCALINIDAD


            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True

                Me._ID_ACUICOLA_INTENSIVOS_DETALLE = CInt("" & .Parameters("@ID_ACUICOLA_INTENSIVOS_DETALLE").Value.ToString)

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
