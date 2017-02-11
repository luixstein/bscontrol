Option Strict On
Imports System.Data
Imports System.Data.SqlClient

Public Class Class_CXP_Afecta_Documentos

#Region "Campos"

#Region "Campos de la tabla"
    Private _FOLIO_CXP As String
    Private _CODIGO_PROVEEDOR As String
    Private _FECHA As Date
    'Private _ID_TIPO_PAGO As Integer
    'Private _CODIGO_DOCUMENTO As String 'se calcula en el store
    Private _FOLIO_REFERENCIA As String
    Private _FOLIO_REFERENCIA_USUARIO As String
    Private _CONCEPTO1 As String
    Private _CONCEPTO2 As String
    Private _CODIGO_PLAZA As Integer
    Private _CODIGO_USUARIO_GRABO As Integer
    Private _SUBTOTAL As Double
    Private _IMPUESTO As Double
    Private _TOTAL As Double
    Private _RETENCION As Double
    Private _TIPO_DE_CAMBIO As Double
    Private _MODULO As String
    Private _FOLIO_BANCO As String
    Private _CODIGO_MONEDA As Integer = 1
    Private _TOTAL_USD As Double
#End Region

#Region "Campos de control"
    Public Enum enumModoPago
        ACREEDOR
        PROVEEDOR
    End Enum

    Public ModoPago As enumModoPago

#End Region

#Region "Campos de sistema"
    Private _Nombre_Catalogo As String
    Private _Nombre_Reporte As String
    Private _Conexion As SqlConnection
    Private _QuerySelect As String
    Private _QueryOrder As String
#End Region

#Region "Campos de privado"
    Private _oDocumento As String
#End Region

#End Region

#Region "Propiedades"
#Region "Propiedades Campos de la tabla"
    Public Property FOLIO_CXP() As String
        Get
            Return Me._FOLIO_CXP
        End Get
        Set(ByVal value As String)
            Me._FOLIO_CXP = value
        End Set
    End Property

    Public WriteOnly Property CODIGO_PROVEEDOR() As String
        Set(ByVal value As String)
            Me._CODIGO_PROVEEDOR = value
        End Set
    End Property

    Public WriteOnly Property FECHA() As Date
        Set(ByVal value As Date)
            Me._FECHA = value
        End Set
    End Property

    'Public WriteOnly Property CODIGO_DOCUMENTO() As String
    '    Set(ByVal value As String)
    '        Me._CODIGO_DOCUMENTO = value
    '    End Set

    'End Property

    'Public WriteOnly Property ID_TIPO_PAGO() As Integer
    '    Set(ByVal value As Integer)
    '        Me._ID_TIPO_PAGO = value
    '    End Set
    'End Property

    Public WriteOnly Property FOLIO_REFERENCIA() As String
        Set(ByVal value As String)
            Me._FOLIO_REFERENCIA = value
        End Set
    End Property

    Public WriteOnly Property FOLIO_REFERENCIA_USUARIO() As String
        Set(ByVal value As String)
            Me._FOLIO_REFERENCIA_USUARIO = value
        End Set
    End Property

    Public WriteOnly Property CONCEPTO1() As String
        Set(ByVal value As String)
            Me._CONCEPTO1 = value
        End Set
    End Property

    Public WriteOnly Property CONCEPTO2() As String
        Set(ByVal value As String)
            Me._CONCEPTO2 = value
        End Set
    End Property

    Public WriteOnly Property CODIGO_PLAZA() As Integer
        Set(ByVal value As Integer)
            Me._CODIGO_PLAZA = value
        End Set
    End Property

    Public WriteOnly Property SUBTOTAL() As Double
        Set(ByVal value As Double)
            Me._SUBTOTAL = value
        End Set
    End Property

    Public WriteOnly Property IMPUESTO() As Double
        Set(ByVal value As Double)
            Me._IMPUESTO = value
        End Set
    End Property

    Public WriteOnly Property TOTAL() As Double
        Set(ByVal value As Double)
            Me._TOTAL = value
        End Set
    End Property

    Public WriteOnly Property RETENCION() As Double
        Set(ByVal value As Double)
            Me._RETENCION = value
        End Set
    End Property

    Public WriteOnly Property MODULO() As String
        Set(ByVal value As String)
            Me._MODULO = value
        End Set
    End Property

    Public Property FOLIO_BANCO() As String
        Get
            Return Me._FOLIO_BANCO
        End Get
        Set(ByVal value As String)
            Me._FOLIO_BANCO = value
        End Set
    End Property

    Public Property CODIGO_USUARIO_GRABO() As Integer
        Get
            Return Me._CODIGO_USUARIO_GRABO
        End Get
        Set(ByVal value As Integer)
            Me._CODIGO_USUARIO_GRABO = value
        End Set
    End Property

    Public Property TIPO_DE_CAMBIO() As Double
        Get
            Return Me._TIPO_DE_CAMBIO
        End Get
        Set(ByVal value As Double)
            Me._TIPO_DE_CAMBIO = value
        End Set
    End Property

    Public WriteOnly Property CODIGO_MONEDA As Integer
        Set(value As Integer)
            Me._CODIGO_MONEDA = value
        End Set
    End Property

    Public WriteOnly Property TOTAL_USD As Double
        Set(value As Double)
            Me._TOTAL_USD = value
        End Set
    End Property

#End Region

#Region "Propiedad Nombre de Clase"
    Public ReadOnly Property Nombre_Clase() As String
        Get
            Return "Class_CXP_Afecta_Documentos"
        End Get
    End Property
#End Region
#End Region

#Region "Constructor y destructor"
    Public Sub New()
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.Conexion
        ' Me.oDocumento = New Class_CatDocumentos()
    End Sub

    Protected Overrides Sub Finalize()
        Me._Conexion.Dispose()
        MyBase.Finalize()
    End Sub
#End Region

#Region "Métodos y procedimientos"

    Public Function InsertarPagosProveedoresAcreedores(ByVal m As enumModoPago) As Boolean
        Dim bResultado As Boolean = False
        Me.ModoPago = m
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = _Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_BANCOS_CXP_GRABA_DETALLE_PAGOS_PROVEEDORES_O_ACREEDORES"

            sqlParametro = .Parameters.Add("@FOLIO_CXP", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_CXP : sqlParametro.Direction = ParameterDirection.InputOutput
            sqlParametro = .Parameters.Add("@CODIGO_PROVEEDOR", SqlDbType.NVarChar, 8) : sqlParametro.Value = Me._CODIGO_PROVEEDOR
            sqlParametro = .Parameters.Add("@FECHA", SqlDbType.DateTime) : sqlParametro.Value = Me._FECHA
            sqlParametro = .Parameters.Add("@FOLIO_REFERENCIA", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_REFERENCIA
            sqlParametro = .Parameters.Add("@FOLIO_REFERENCIA_USUARIO", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_REFERENCIA_USUARIO
            sqlParametro = .Parameters.Add("@CONCEPTO1", SqlDbType.NVarChar, 80) : sqlParametro.Value = Me._CONCEPTO1
            sqlParametro = .Parameters.Add("@CONCEPTO2", SqlDbType.NVarChar, 80) : sqlParametro.Value = Me._CONCEPTO2
            sqlParametro = .Parameters.Add("@CODIGO_PLAZA", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_PLAZA
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO_GRABO", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Usuario
            sqlParametro = .Parameters.Add("@TOTAL", SqlDbType.Decimal) : sqlParametro.Value = Me._TOTAL
            sqlParametro = .Parameters.Add("@RETENCION", SqlDbType.Decimal) : sqlParametro.Value = Me._RETENCION
            sqlParametro = .Parameters.Add("@TIPO_DE_CAMBIO", SqlDbType.Decimal) : sqlParametro.Value = Me._TIPO_DE_CAMBIO
            sqlParametro = .Parameters.Add("@FOLIO_BANCO", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_BANCO
            sqlParametro = .Parameters.Add("@ES_PROVEEDOR", SqlDbType.Char, 1) : sqlParametro.Value = IIf(Me.ModoPago = enumModoPago.PROVEEDOR, "1", "0")
            sqlParametro = .Parameters.Add("@CODIGO_MONEDA", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_MONEDA
            sqlParametro = .Parameters.Add("@TOTAL_USD", SqlDbType.Decimal) : sqlParametro.Value = Me._TOTAL_USD

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                Me._FOLIO_CXP = "" & .Parameters("@FOLIO_CXP").Value.ToString
                bResultado = True
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "InsertarPagosProveedoresAcreedores", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Function AplicaDocumentoCXP() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = _Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CXP_APLICA_DOCUMENTO"

            sqlParametro = .Parameters.Add("@FOLIO_CXP", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_CXP
            sqlParametro = .Parameters.Add("@FOLIO_REFERENCIA", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_REFERENCIA
            sqlParametro = .Parameters.Add("@CODIGO_PLAZA", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_PLAZA
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Usuario

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "AplicaDocumentoCXP", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Function AplicaRelacionBancosCXPFletes(ByVal sFolioEmbarque As String, ByVal dImporte As Double) As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = _Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_BANCOS_CXP_FLETES_RELACION_GRABA"

            sqlParametro = .Parameters.Add("@FOLIO_BANCO", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_BANCO
            sqlParametro = .Parameters.Add("@FOLIO_EMBARQUE", SqlDbType.NVarChar, 15) : sqlParametro.Value = sFolioEmbarque
            sqlParametro = .Parameters.Add("@IMPORTE", SqlDbType.Decimal) : sqlParametro.Value = dImporte

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "AplicaRelacionBancosCXPFletes", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Function AfectaDocumentos() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = _Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CXP_AFECTA_DOCUMENTO"

            sqlParametro = .Parameters.Add("@FOLIO_CXP", SqlDbType.NVarChar, 15) : sqlParametro.Direction = ParameterDirection.InputOutput : sqlParametro.Value = Me._FOLIO_CXP
            sqlParametro = .Parameters.Add("@CODIGO_PROVEEDOR", SqlDbType.NVarChar, 8) : sqlParametro.Value = Me._CODIGO_PROVEEDOR
            sqlParametro = .Parameters.Add("@FECHA", SqlDbType.DateTime) : sqlParametro.Value = Me._FECHA
            sqlParametro = .Parameters.Add("@CODIGO_DOCUMENTO", SqlDbType.NVarChar, 10) : sqlParametro.Value = "NCD_CXP" & Usuario.Codigo_Plaza
            sqlParametro = .Parameters.Add("@FOLIO_REFERENCIA", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_REFERENCIA
            sqlParametro = .Parameters.Add("@FOLIO_REFERENCIA_USUARIO", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_REFERENCIA_USUARIO
            sqlParametro = .Parameters.Add("@CONCEPTO1", SqlDbType.NVarChar, 80) : sqlParametro.Value = Me._CONCEPTO1
            sqlParametro = .Parameters.Add("@CONCEPTO2", SqlDbType.NVarChar, 80) : sqlParametro.Value = Me._CONCEPTO2
            sqlParametro = .Parameters.Add("@CODIGO_PLAZA", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_PLAZA
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO_GRABO", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Usuario
            sqlParametro = .Parameters.Add("@SUBTOTAL", SqlDbType.Decimal) : sqlParametro.Value = Me._SUBTOTAL
            sqlParametro = .Parameters.Add("@IMPUESTO", SqlDbType.Decimal) : sqlParametro.Value = Me._IMPUESTO
            sqlParametro = .Parameters.Add("@TOTAL", SqlDbType.Decimal) : sqlParametro.Value = Me._TOTAL
            sqlParametro = .Parameters.Add("@RETENCION", SqlDbType.Decimal) : sqlParametro.Value = Me._RETENCION
            sqlParametro = .Parameters.Add("@TIPO_DE_CAMBIO", SqlDbType.Decimal) : sqlParametro.Value = Me._TIPO_DE_CAMBIO
            sqlParametro = .Parameters.Add("@CODIGO_MODULO", SqlDbType.NVarChar, 4) : sqlParametro.Value = "CXP"
            sqlParametro = .Parameters.Add("@AFECTA_SALDO_CATALOGOS", SqlDbType.Char, 1) : sqlParametro.Value = "1"
            sqlParametro = .Parameters.Add("@CODIGO_MONEDA", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_MONEDA
            sqlParametro = .Parameters.Add("@TOTAL_USD", SqlDbType.Decimal) : sqlParametro.Value = Me._TOTAL_USD

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                Me._FOLIO_CXP = "" & .Parameters("@FOLIO_CXP").Value.ToString
                bResultado = True
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "AfectaDocumentos", ex)
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

