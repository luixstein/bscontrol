Option Strict On
Imports System.Data
Imports System.Data.SqlClient

Public Class Class_NominaDeduccionesDetalle

#Region "Campos"

#Region "Campos de la tabla"
    Private _ID_DEDUCCION_DETALLE As Integer
    Private _ID_DEDUCCION_GLOBAL As Integer
    Private _NUMERO_SEMANA As Integer
    Private _DESCUENTO As Double
    Private _AMORTIZACION As Double
    Private _ESTATUS_ABONADO As String
    Private _TEMPORADA As Integer
#End Region

#Region "Campos de sistema"
    Private _Nombre_Catalogo As String
    Private _Conexion As SqlConnection
    Private _QuerySelect As String
#End Region

#End Region

#Region "Propiedades"

#Region "Propiedades Campos de la tabla"
    Public Property ID_DEDUCCION_DETALLE() As Integer
        Get
            Return Me._ID_DEDUCCION_DETALLE
        End Get
        Set(ByVal value As Integer)
            Me._ID_DEDUCCION_DETALLE = value
        End Set
    End Property

    Public Property ID_DEDUCCION_GLOBAL() As Integer
        Get
            Return Me._ID_DEDUCCION_GLOBAL
        End Get
        Set(ByVal value As Integer)
            Me._ID_DEDUCCION_GLOBAL = value
        End Set
    End Property

    Public Property NUMERO_SEMANA() As Integer
        Get
            Return Me._NUMERO_SEMANA
        End Get
        Set(ByVal value As Integer)
            Me._NUMERO_SEMANA = value
        End Set
    End Property

    Public Property DESCUENTO() As Double
        Get
            Return Me._DESCUENTO
        End Get
        Set(ByVal value As Double)
            Me._DESCUENTO = value
        End Set
    End Property

    Public Property AMORTIZACION() As Double
        Get
            Return Me._AMORTIZACION
        End Get
        Set(ByVal value As Double)
            Me._AMORTIZACION = value
        End Set
    End Property

    Public Property ESTATUS_ABONADO() As String
        Get
            Return Me._ESTATUS_ABONADO
        End Get
        Set(ByVal value As String)
            Me._ESTATUS_ABONADO = value
        End Set
    End Property

    'Public Property TEMPORADA() As Integer
    '    Get
    '        Return Me._TEMPORADA
    '    End Get
    '    Set(ByVal value As Integer)
    '        Me._TEMPORADA = value
    '    End Set
    'End Property

#End Region

#Region "Propiedad Nombre de Clase"
    Public ReadOnly Property Nombre_Clase() As String
        Get
            Return "Class_NominaDeduccionesDetalle"
        End Get
    End Property
#End Region

#End Region

#Region "Constructor y destructor"
    Public Sub New()
        Me._Nombre_Catalogo = "NOMINA_DEDUCCIONES_DETALLE"
        Me._Conexion = New SqlConnection(Empresa_Sistema.conexion)
        Me._QuerySelect = "SELECT * FROM NOMINA_DEDUCCIONES_DETALLE"
    End Sub

    Protected Overrides Sub Finalize()
        'Me._Conexion.Dispose()
        MyBase.Finalize()
    End Sub
#End Region

#Region "Métodos y procedimientos"
    Public Function GrabaDetalleDeduccion(ByVal sAccion As String) As Boolean
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_NOMINA_DEDUCCIONES_DETALLE_GRABA"

            sqlParametro = .Parameters.Add("@ID_DEDUCCION_DETALLE", SqlDbType.Int) : sqlParametro.Value = Me._ID_DEDUCCION_DETALLE
            sqlParametro = .Parameters.Add("@ID_DEDUCCION_GLOBAL", SqlDbType.Int) : sqlParametro.Value = Me._ID_DEDUCCION_GLOBAL
            sqlParametro = .Parameters.Add("@NUMERO_SEMANA", SqlDbType.SmallInt) : sqlParametro.Value = Me._NUMERO_SEMANA
            sqlParametro = .Parameters.Add("@DESCUENTO", SqlDbType.Decimal) : sqlParametro.Value = Me._DESCUENTO
            sqlParametro = .Parameters.Add("@AMORTIZACION", SqlDbType.Decimal) : sqlParametro.Value = Me._AMORTIZACION
            sqlParametro = .Parameters.Add("@ESTATUS_ABONADO", SqlDbType.Char, 1) : sqlParametro.Value = Me._ESTATUS_ABONADO.ToString.ToUpper
            'sqlParametro = .Parameters.Add("@ID_NOMINA_TEMPORADA", SqlDbType.SmallInt) : sqlParametro.Value = Me._TEMPORADA.ToString.ToUpper
            sqlParametro = .Parameters.Add("@ACCION", SqlDbType.NVarChar, 10) : sqlParametro.Value = sAccion.ToString.ToUpper

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                GrabaDetalleDeduccion = True
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "GrabaDetalleDeduccion", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
    End Function
#End Region

End Class
