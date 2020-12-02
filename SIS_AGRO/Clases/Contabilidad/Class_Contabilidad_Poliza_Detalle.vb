Option Strict On

Imports System.Data.SqlClient

Public Class Class_Contabilidad_Poliza_Detalle

#Region "Campos"

#Region "Campos de la tabla"
    Private _FOLIO_POLIZA As String
    Private _CUENTA_CONTABLE As String
    Private _CONCEPTO As String
    Private _CARGO As Double
    Private _ABONO As Double
    Private _CODIGO_CENTRO_COSTO As Integer = 0
    Private _CODIGO_CATEGORIA As Integer = 0
    Private _CODIGO_CONCEPTO As Integer = 0
#End Region

#Region "Campos de sistema"
    Private _Nombre_Catalogo As String
    Private _Conexion As SqlConnection
    Private _QuerySelect As String
#End Region

#End Region

#Region "Propiedades"

#Region "Propiedades Campos de la tabla"
    Public Property FOLIO_POLIZA() As String
        Get
            Return Me._FOLIO_POLIZA
        End Get
        Set(ByVal value As String)
            Me._FOLIO_POLIZA = value
        End Set
    End Property

    Public Property CUENTA_CONTABLE() As String
        Get
            Return Me._CUENTA_CONTABLE
        End Get
        Set(ByVal value As String)
            Me._CUENTA_CONTABLE = value
        End Set
    End Property

    Public Property CONCEPTO() As String
        Get
            Return Me._CONCEPTO
        End Get
        Set(ByVal value As String)
            Me._CONCEPTO = value
        End Set

    End Property
    Public Property CARGO() As Double
        Get
            Return Me._CARGO
        End Get
        Set(ByVal value As Double)
            Me._CARGO = value
        End Set
    End Property

    Public Property ABONO() As Double
        Get
            Return Me._ABONO
        End Get
        Set(ByVal value As Double)
            Me._ABONO = value
        End Set
    End Property

    Public Property CODIGO_CENTRO_COSTO() As Integer
        Get
            Return Me._CODIGO_CENTRO_COSTO
        End Get
        Set(ByVal value As Integer)
            Me._CODIGO_CENTRO_COSTO = value
        End Set
    End Property

    Public Property CODIGO_CATEGORIA() As Integer
        Get
            Return Me._CODIGO_CATEGORIA
        End Get
        Set(ByVal value As Integer)
            Me._CODIGO_CATEGORIA = value
        End Set
    End Property

    Public Property CODIGO_CONCEPTO() As Integer
        Get
            Return Me._CODIGO_CONCEPTO
        End Get
        Set(ByVal value As Integer)
            Me._CODIGO_CONCEPTO = value
        End Set
    End Property
#End Region

#Region "Propiedad Nombre de Clase"
    Public ReadOnly Property Nombre_Clase() As String
        Get
            Return "Class_Contabilidad_Detalle_Poliza"
        End Get
    End Property
#End Region

#End Region

#Region "Constructor y destructor"
    Public Sub New()
        Me._Nombre_Catalogo = "CON_POLIZAS_DETALLE"
        Me._Conexion = New SqlConnection(Empresa_Sistema.conexion)
        Me._QuerySelect = "SELECT * FROM CON_POLIZAS_DETALLE"
    End Sub

    Protected Overrides Sub Finalize()
        'Me._Conexion.Dispose()
        MyBase.Finalize()
    End Sub
#End Region

#Region "Métodos y procedimientos"
    Public Function GrabaDetallePoliza() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CONTABILIDAD_GRABA_DETALLE"

            sqlParametro = .Parameters.Add("@FOLIO_POLIZA", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_POLIZA
            sqlParametro = .Parameters.Add("@CUENTA_CONTABLE", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._CUENTA_CONTABLE
            sqlParametro = .Parameters.Add("@CARGO", SqlDbType.Money) : sqlParametro.Value = Me._CARGO
            sqlParametro = .Parameters.Add("@ABONO", SqlDbType.Money) : sqlParametro.Value = Me._ABONO
            sqlParametro = .Parameters.Add("@CONCEPTO", SqlDbType.NVarChar, 80) : sqlParametro.Value = Me._CONCEPTO
            sqlParametro = .Parameters.Add("@CODIGO_CENTRO_COSTO", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_CENTRO_COSTO
            sqlParametro = .Parameters.Add("@CODIGO_CATEGORIA", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_CATEGORIA
            sqlParametro = .Parameters.Add("@CODIGO_CONCEPTO", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_CONCEPTO

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "GrabaDetallePoliza", ex)
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
