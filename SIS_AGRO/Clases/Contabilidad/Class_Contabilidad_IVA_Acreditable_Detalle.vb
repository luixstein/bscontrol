Option Strict On
Imports System.Data
Imports System.Data.SqlClient

Public Class Class_Contabilidad_IVA_Acreditable_Detalle
#Region "Campos"

#Region "Campos de la tabla"
    Private _ID_CON_IVA_ACREDITABLE_DETALLE As Integer
    Private _FOLIO_POLIZA As String
    Private _CODIGO_PROVEEDOR As String
    Private _FOLIO_PROVEEDOR As String
    Private _PERIODO As Integer
    Private _ANIO As Integer
    Private _OPERACIONES As Integer
    Private _ACTOS_IVA_EXENTO As Double
    Private _ACTOS_AL_0 As Double
    Private _ACTOS_AL_8 As Double
    Private _ACTOS_AL_10 As Double
    Private _ACTOS_AL_15 As Double
    Private _ACTOS_AL_11 As Double
    Private _ACTOS_AL_16 As Double
    Private _SUBTOTAL_ACTOS As Double
    Private _IVA_ACREDITABLE_AL_8 As Double
    Private _IVA_ACREDITABLE_AL_10 As Double
    Private _IVA_ACREDITABLE_AL_15 As Double
    Private _IVA_ACREDITABLE_AL_11 As Double
    Private _IVA_ACREDITABLE_AL_16 As Double
    Private _IVA_RETENIDO_AL_4 As Double
    Private _IVA_RETENIDO_AL_6 As Double
    Private _IVA_RETENIDO_AL_10 As Double
    Private _FOLIO_COMPRA As String
    Private _FECHA_FACTURA_PROVEEDOR As Date
    Private _CONCEPTO As String
#End Region

#Region "Campos ligados a la tabla"
#End Region

#Region "Campos de sistema"
    Private _Conexion As SqlConnection
    Private _QuerySelect As String
#End Region

#End Region

#Region "Propiedades"

#Region "Propiedades Campos de la tabla"
    Public ReadOnly Property ID_CON_IVA_ACREDITABLE_DETALLE() As Integer
        Get
            Return Me._ID_CON_IVA_ACREDITABLE_DETALLE
        End Get
    End Property

    Public ReadOnly Property FOLIO_POLIZA() As String
        Get
            Return Me._FOLIO_POLIZA
        End Get
    End Property

    Public Property CODIGO_PROVEEDOR() As String
        Get
            Return Me._CODIGO_PROVEEDOR
        End Get
        Set(ByVal value As String)
            Me._CODIGO_PROVEEDOR = value
        End Set
    End Property

    Public Property FOLIO_PROVEEDOR() As String
        Get
            Return Me._FOLIO_PROVEEDOR
        End Get
        Set(ByVal value As String)
            Me._FOLIO_PROVEEDOR = value
        End Set
    End Property

    Public Property PERIODO() As Integer
        Get
            Return Me._PERIODO
        End Get
        Set(ByVal value As Integer)
            Me._PERIODO = value
        End Set
    End Property

    Public Property ANIO() As Integer
        Get
            Return Me._ANIO
        End Get
        Set(ByVal value As Integer)
            Me._ANIO = value
        End Set
    End Property

    Public Property OPERACIONES() As Integer
        Get
            Return Me._OPERACIONES
        End Get
        Set(ByVal value As Integer)
            Me._OPERACIONES = value
        End Set
    End Property

    Public Property ACTOS_IVA_EXENTO() As Double
        Get
            Return Me._ACTOS_IVA_EXENTO
        End Get
        Set(ByVal value As Double)
            Me._ACTOS_IVA_EXENTO = value
        End Set
    End Property

    Public Property ACTOS_AL_0() As Double
        Get
            Return Me._ACTOS_AL_0
        End Get
        Set(ByVal value As Double)
            Me._ACTOS_AL_0 = value
        End Set
    End Property

    Public Property ACTOS_AL_8() As Double
        Get
            Return Me._ACTOS_AL_8
        End Get
        Set(ByVal value As Double)
            Me._ACTOS_AL_8 = value
        End Set
    End Property

    Public Property ACTOS_AL_10() As Double
        Get
            Return Me._ACTOS_AL_10
        End Get
        Set(ByVal value As Double)
            Me._ACTOS_AL_10 = value
        End Set
    End Property

    Public Property ACTOS_AL_15() As Double
        Get
            Return Me._ACTOS_AL_15
        End Get
        Set(ByVal value As Double)
            Me._ACTOS_AL_15 = value
        End Set
    End Property

    Public Property ACTOS_AL_11() As Double
        Get
            Return Me._ACTOS_AL_11
        End Get
        Set(ByVal value As Double)
            Me._ACTOS_AL_11 = value
        End Set
    End Property

    Public Property ACTOS_AL_16() As Double
        Get
            Return Me._ACTOS_AL_16
        End Get
        Set(ByVal value As Double)
            Me._ACTOS_AL_16 = value
        End Set
    End Property

    Public Property SUBTOTAL_ACTOS() As Double
        Get
            Return Me._SUBTOTAL_ACTOS
        End Get
        Set(ByVal value As Double)
            Me._SUBTOTAL_ACTOS = value
        End Set
    End Property

    Public Property IVA_ACREDITABLE_AL_8() As Double
        Get
            Return Me._IVA_ACREDITABLE_AL_8
        End Get
        Set(ByVal value As Double)
            Me._IVA_ACREDITABLE_AL_8 = value
        End Set
    End Property

    Public Property IVA_ACREDITABLE_AL_10() As Double
        Get
            Return Me._IVA_ACREDITABLE_AL_10
        End Get
        Set(ByVal value As Double)
            Me._IVA_ACREDITABLE_AL_10 = value
        End Set
    End Property

    Public Property IVA_ACREDITABLE_AL_15() As Double
        Get
            Return Me._IVA_ACREDITABLE_AL_15
        End Get
        Set(ByVal value As Double)
            Me._IVA_ACREDITABLE_AL_15 = value
        End Set
    End Property

    Public Property IVA_ACREDITABLE_AL_11() As Double
        Get
            Return Me._IVA_ACREDITABLE_AL_11
        End Get
        Set(ByVal value As Double)
            Me._IVA_ACREDITABLE_AL_11 = value
        End Set
    End Property

    Public Property IVA_ACREDITABLE_AL_16() As Double
        Get
            Return Me._IVA_ACREDITABLE_AL_16
        End Get
        Set(ByVal value As Double)
            Me._IVA_ACREDITABLE_AL_16 = value
        End Set
    End Property

    Public Property IVA_RETENIDO_AL_4() As Double
        Get
            Return Me._IVA_RETENIDO_AL_4
        End Get
        Set(ByVal value As Double)
            Me._IVA_RETENIDO_AL_4 = value
        End Set
    End Property

    Public Property IVA_RETENIDO_AL_6() As Double
        Get
            Return Me._IVA_RETENIDO_AL_6
        End Get
        Set(ByVal value As Double)
            Me._IVA_RETENIDO_AL_6 = value
        End Set
    End Property

    Public Property IVA_RETENIDO_AL_10() As Double
        Get
            Return Me._IVA_RETENIDO_AL_10
        End Get
        Set(ByVal value As Double)
            Me._IVA_RETENIDO_AL_10 = value
        End Set
    End Property

    Public Property FOLIO_COMPRA() As String
        Get
            Return Me._FOLIO_COMPRA
        End Get
        Set(ByVal value As String)
            Me._FOLIO_COMPRA = value
        End Set
    End Property

    Public Property FECHA_FACTURA_PROVEEDOR() As Date
        Get
            Return Me._FECHA_FACTURA_PROVEEDOR
        End Get
        Set(ByVal value As Date)
            Me._FECHA_FACTURA_PROVEEDOR = value
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
#End Region

#Region "Propiedades de campos ligados a la tabla"

#End Region

#Region "Propiedad Nombre de Clase"
    Public ReadOnly Property Nombre_Clase() As String
        Get
            Return "Class_Contabilidad_IVA_Acreditable_Global"
        End Get
    End Property
#End Region

#End Region

#Region "Constructor y destructor"
    Public Sub New(ByVal sFolioPoliza As String)
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = ""

        Me._FOLIO_POLIZA = sFolioPoliza
    End Sub

    Protected Overrides Sub Finalize()
        'Me._Conexion.Dispose()
        MyBase.Finalize()
    End Sub
#End Region

#Region "Métodos y procedimientos"
    Public Function GrabaIVAAcreditableDetalle() As Boolean
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CONTABILIDAD_IVA_ACREDITABLE_GRABA_DETALLE"

            sqlParametro = .Parameters.Add("@FOLIO_POLIZA", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_POLIZA
            sqlParametro = .Parameters.Add("@CODIGO_PROVEEDOR", SqlDbType.NVarChar, 8) : sqlParametro.Value = Me._CODIGO_PROVEEDOR
            sqlParametro = .Parameters.Add("@FOLIO_PROVEEDOR", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_PROVEEDOR
            sqlParametro = .Parameters.Add("@PERIODO", SqlDbType.SmallInt) : sqlParametro.Value = Me._PERIODO
            sqlParametro = .Parameters.Add("@ANIO", SqlDbType.SmallInt) : sqlParametro.Value = Me._ANIO
            sqlParametro = .Parameters.Add("@OPERACIONES", SqlDbType.SmallInt) : sqlParametro.Value = Me._OPERACIONES
            sqlParametro = .Parameters.Add("@ACTOS_AL_0", SqlDbType.Money) : sqlParametro.Value = Me._ACTOS_AL_0
            sqlParametro = .Parameters.Add("@ACTOS_AL_8", SqlDbType.Money) : sqlParametro.Value = Me._ACTOS_AL_8
            sqlParametro = .Parameters.Add("@ACTOS_AL_10", SqlDbType.Money) : sqlParametro.Value = Me._ACTOS_AL_10
            sqlParametro = .Parameters.Add("@ACTOS_AL_15", SqlDbType.Money) : sqlParametro.Value = Me._ACTOS_AL_15
            sqlParametro = .Parameters.Add("@ACTOS_AL_11", SqlDbType.Money) : sqlParametro.Value = Me._ACTOS_AL_11
            sqlParametro = .Parameters.Add("@ACTOS_AL_16", SqlDbType.Money) : sqlParametro.Value = Me._ACTOS_AL_16
            sqlParametro = .Parameters.Add("@ACTOS_IVA_EXENTO", SqlDbType.Money) : sqlParametro.Value = Me._ACTOS_IVA_EXENTO
            sqlParametro = .Parameters.Add("@SUBTOTAL_ACTOS", SqlDbType.Money) : sqlParametro.Value = Me._SUBTOTAL_ACTOS
            sqlParametro = .Parameters.Add("@IVA_ACREDITABLE_AL_8", SqlDbType.Money) : sqlParametro.Value = Me._IVA_ACREDITABLE_AL_8
            sqlParametro = .Parameters.Add("@IVA_ACREDITABLE_AL_10", SqlDbType.Money) : sqlParametro.Value = Me._IVA_ACREDITABLE_AL_10
            sqlParametro = .Parameters.Add("@IVA_ACREDITABLE_AL_15", SqlDbType.Money) : sqlParametro.Value = Me._IVA_ACREDITABLE_AL_15
            sqlParametro = .Parameters.Add("@IVA_ACREDITABLE_AL_11", SqlDbType.Money) : sqlParametro.Value = Me._IVA_ACREDITABLE_AL_11
            sqlParametro = .Parameters.Add("@IVA_ACREDITABLE_AL_16", SqlDbType.Money) : sqlParametro.Value = Me._IVA_ACREDITABLE_AL_16
            sqlParametro = .Parameters.Add("@IVA_RETENIDO_AL_4", SqlDbType.Money) : sqlParametro.Value = Me._IVA_RETENIDO_AL_4
            sqlParametro = .Parameters.Add("@IVA_RETENIDO_AL_6", SqlDbType.Money) : sqlParametro.Value = Me._IVA_RETENIDO_AL_6
            sqlParametro = .Parameters.Add("@IVA_RETENIDO_AL_10", SqlDbType.Money) : sqlParametro.Value = Me._IVA_RETENIDO_AL_10
            sqlParametro = .Parameters.Add("@FOLIO_COMPRA", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_COMPRA
            sqlParametro = .Parameters.Add("@FECHA_FACTURA_PROVEEDOR", SqlDbType.DateTime) : sqlParametro.Value = Me._FECHA_FACTURA_PROVEEDOR
            sqlParametro = .Parameters.Add("@CONCEPTO", SqlDbType.NVarChar, 200) : sqlParametro.Value = Me._CONCEPTO

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                GrabaIVAAcreditableDetalle = True
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "GrabaIVAAcreditableDetalle", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
    End Function

#End Region

End Class
