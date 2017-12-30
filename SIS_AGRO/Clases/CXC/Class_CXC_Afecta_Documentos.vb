Option Strict On

Imports System.Data.SqlClient

Public Class Class_CXC_Afecta_Documentos

#Region "Campos"

#Region "Campos de la tabla"
    Private _FOLIO_CXC As String
    Private _FOLIO_POLIZA As String
    Private _CODIGO_CLIENTE As String
    Private _FECHA As Date
    Private _FOLIO_REFERENCIA As String
    Private _FOLIO_REFERENCIA_USUARIO As String
    Private _CONCEPTO1 As String
    Private _CONCEPTO2 As String
    Private _CODIGO_PLAZA As Integer
    Private _CODIGO_USUARIO_GRABO As Integer
    Private _TOTAL As Double
    Private _TIPO_DE_CAMBIO As Double
    'Private _MODULO As String
    Private _FOLIO_BANCO As String
    Private _ID_MEDIO_PAGO As Integer
    Private _CODIGO_BANCO As String
    Private _TOTAL_DOLARES As Double
    Private _ID_BANCOS_DETALLE As Long
    Private _IMPORTE_CAPTURADO As Double
    Private _FECHA_PAGO As Date
    Private _IMPORTE_MONEDA_VENTA As Double
    Private _SALDO_ANTERIOR_MONEDA_VENTA As Double
    Private _SALDO_ANTERIOR_MONEDA_PAGO As Double
#End Region

#Region "Campos de control"

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
    Public Property FOLIO_CXC() As String
        Get
            Return Me._FOLIO_CXC
        End Get
        Set(ByVal value As String)
            Me._FOLIO_CXC = value
        End Set
    End Property

    Public WriteOnly Property CODIGO_CLIENTE() As String
        Set(ByVal value As String)
            Me._CODIGO_CLIENTE = value
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

    Public WriteOnly Property TOTAL() As Double
        Set(ByVal value As Double)
            Me._TOTAL = value
        End Set
    End Property

    'Public WriteOnly Property ID_CUENTA_BANCARIA() As Integer
    '    Set(ByVal value As Integer)
    '        Me._ID_CUENTA_BANCARIA = value
    '    End Set
    'End Property
    Public WriteOnly Property FOLIO_POLIZA() As String
        Set(ByVal value As String)
            Me._FOLIO_POLIZA = value
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

    Public Property FOLIO_BANCO() As String
        Get
            Return Me._FOLIO_BANCO
        End Get
        Set(ByVal value As String)
            Me._FOLIO_BANCO = value
        End Set
    End Property

    Public Property ID_MEDIO_PAGO() As Integer
        Get
            Return Me._ID_MEDIO_PAGO
        End Get
        Set(ByVal value As Integer)
            Me._ID_MEDIO_PAGO = value
        End Set
    End Property

    Public Property CODIGO_BANCO() As String
        Get
            Return Me._CODIGO_BANCO
        End Get
        Set(ByVal value As String)
            Me._CODIGO_BANCO = value
        End Set
    End Property

    Public Property TOTAL_DOLARES() As Double
        Get
            Return Me._TOTAL_DOLARES
        End Get
        Set(ByVal value As Double)
            Me._TOTAL_DOLARES = value
        End Set
    End Property

    Public Property ID_BANCOS_DETALLE() As Long
        Get
            Return Me._ID_BANCOS_DETALLE
        End Get
        Set(ByVal value As Long)
            Me._ID_BANCOS_DETALLE = value
        End Set
    End Property

    Public Property IMPORTE_CAPTURADO() As Double
        Get
            Return Me._IMPORTE_CAPTURADO
        End Get
        Set(ByVal value As Double)
            Me._IMPORTE_CAPTURADO = value
        End Set
    End Property

    Public Property FECHA_PAGO() As Date
        Get
            Return Me._FECHA_PAGO
        End Get
        Set(ByVal value As Date)
            Me._FECHA_PAGO = value
        End Set
    End Property

    Public Property IMPORTE_MONEDA_VENTA() As Double
        Get
            Return Me._IMPORTE_MONEDA_VENTA
        End Get
        Set(ByVal value As Double)
            Me._IMPORTE_MONEDA_VENTA = value
        End Set
    End Property

    Public Property SALDO_ANTERIOR_MONEDA_VENTA() As Double
        Get
            Return Me._SALDO_ANTERIOR_MONEDA_VENTA
        End Get
        Set(ByVal value As Double)
            Me._SALDO_ANTERIOR_MONEDA_VENTA = value
        End Set
    End Property

    Public Property SALDO_ANTERIOR_MONEDA_PAGO() As Double
        Get
            Return Me._SALDO_ANTERIOR_MONEDA_PAGO
        End Get
        Set(ByVal value As Double)
            Me._SALDO_ANTERIOR_MONEDA_PAGO = value
        End Set
    End Property


#End Region

#Region "Propiedad Nombre de Clase"
    Public ReadOnly Property Nombre_Clase() As String
        Get
            Return "Class_CXC_Afecta_Documentos"
        End Get
    End Property
#End Region

#End Region

#Region "Constructor y destructor"
    Public Sub New()
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        ' Me.oDocumento = New Class_CatDocumentos()
    End Sub

    Protected Overrides Sub Finalize()
        Me._Conexion.Dispose()
        MyBase.Finalize()
    End Sub
#End Region

#Region "Métodos y procedimientos"
    Public Function InsertarPagosClientes() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = _Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_BANCOS_CXC_GRABA_DETALLE_PAGOS"

            sqlParametro = .Parameters.Add("@FOLIO_CXC", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_CXC : sqlParametro.Direction = ParameterDirection.Output
            sqlParametro = .Parameters.Add("@CODIGO_CLIENTE", SqlDbType.NVarChar, 8) : sqlParametro.Value = Me._CODIGO_CLIENTE
            sqlParametro = .Parameters.Add("@FECHA", SqlDbType.DateTime) : sqlParametro.Value = Me._FECHA
            sqlParametro = .Parameters.Add("@FOLIO_REFERENCIA", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_REFERENCIA
            sqlParametro = .Parameters.Add("@FOLIO_REFERENCIA_USUARIO", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_REFERENCIA_USUARIO
            sqlParametro = .Parameters.Add("@CONCEPTO1", SqlDbType.NVarChar, 80) : sqlParametro.Value = Me._CONCEPTO1
            sqlParametro = .Parameters.Add("@CONCEPTO2", SqlDbType.NVarChar, 80) : sqlParametro.Value = Me._CONCEPTO2
            sqlParametro = .Parameters.Add("@CODIGO_PLAZA", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_PLAZA
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO_GRABO", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Usuario
            sqlParametro = .Parameters.Add("@TOTAL", SqlDbType.Decimal) : sqlParametro.Value = Me._TOTAL
            sqlParametro = .Parameters.Add("@TIPO_DE_CAMBIO", SqlDbType.Decimal) : sqlParametro.Value = Me._TIPO_DE_CAMBIO
            sqlParametro = .Parameters.Add("@FOLIO_BANCO", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_BANCO
            sqlParametro = .Parameters.Add("@ID_MEDIO_PAGO", SqlDbType.SmallInt) : sqlParametro.Value = Me._ID_MEDIO_PAGO
            sqlParametro = .Parameters.Add("@CODIGO_BANCO", SqlDbType.NVarChar, 3) : sqlParametro.Value = Me._CODIGO_BANCO
            sqlParametro = .Parameters.Add("@TOTAL_DOLARES", SqlDbType.Decimal) : sqlParametro.Value = Me._TOTAL_DOLARES
            sqlParametro = .Parameters.Add("@ID_BANCOS_DETALLE", SqlDbType.Int) : sqlParametro.Value = Me._ID_BANCOS_DETALLE
            sqlParametro = .Parameters.Add("@IMPORTE_CAPTURADO", SqlDbType.Decimal) : sqlParametro.Value = Me._IMPORTE_CAPTURADO
            sqlParametro = .Parameters.Add("@FECHA_PAGO", SqlDbType.DateTime) : sqlParametro.Value = Me._FECHA_PAGO
            sqlParametro = .Parameters.Add("@IMPORTE_MONEDA_VENTA", SqlDbType.Decimal) : sqlParametro.Value = Me._IMPORTE_MONEDA_VENTA
            sqlParametro = .Parameters.Add("@SALDO_ANTERIOR_MONEDA_VENTA", SqlDbType.Decimal) : sqlParametro.Value = Me._SALDO_ANTERIOR_MONEDA_VENTA
            sqlParametro = .Parameters.Add("@SALDO_ANTERIOR_MONEDA_PAGO", SqlDbType.Decimal) : sqlParametro.Value = Me._SALDO_ANTERIOR_MONEDA_PAGO

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                Me._FOLIO_CXC = "" & .Parameters("@FOLIO_CXC").Value.ToString
                bResultado = True
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "InsertarPagosClientes", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Function CancelaPagosCXC() As Boolean
        Dim bResultado As Boolean = False
        Dim Conexion As New SqlConnection(Empresa_Sistema.conexion), Error1 As String = ""

        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter

        With cmd
            .Connection = Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_BANCOS_CXC_CANCELA"

            sqlParametro = .Parameters.Add("@FOLIO_BANCO", SqlDbType.NVarChar, 15) : sqlParametro.Value = "" & Me._FOLIO_BANCO
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO", SqlDbType.NVarChar, 80) : sqlParametro.Value = Usuario.Codigo_Usuario
            sqlParametro = .Parameters.Add("@FECHA_CANCELACION", SqlDbType.SmallDateTime, 4) : sqlParametro.Value = Date.Now

            Try
                Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "CancelaPagosCXC", ex)
            Finally
                Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Function AplicaDocumentoCXC() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = _Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CXC_APLICA_DOCUMENTO"

            sqlParametro = .Parameters.Add("@FOLIO_CXC", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_CXC
            sqlParametro = .Parameters.Add("@FOLIO_REFERENCIA", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_REFERENCIA
            sqlParametro = .Parameters.Add("@CODIGO_PLAZA", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_PLAZA
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Usuario

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "AplicaDocumentoCXC", ex)
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
            .CommandText = "MP_CXC_AFECTA_DOCUMENTO"

            sqlParametro = .Parameters.Add("@FOLIO_CXC", SqlDbType.NVarChar, 15) : sqlParametro.Direction = ParameterDirection.InputOutput : sqlParametro.Value = Me._FOLIO_CXC
            sqlParametro = .Parameters.Add("@CODIGO_CLIENTE", SqlDbType.NVarChar, 8) : sqlParametro.Value = Me._CODIGO_CLIENTE
            sqlParametro = .Parameters.Add("@FECHA", SqlDbType.DateTime) : sqlParametro.Value = Me._FECHA
            sqlParametro = .Parameters.Add("@CODIGO_DOCUMENTO", SqlDbType.NVarChar, 10) : sqlParametro.Value = "NCD_CXC" & Usuario.Codigo_Plaza
            sqlParametro = .Parameters.Add("@CODIGO_PLAZA", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_PLAZA
            sqlParametro = .Parameters.Add("@FOLIO_REFERENCIA", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_REFERENCIA
            sqlParametro = .Parameters.Add("@FOLIO_REFERENCIA_USUARIO", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_REFERENCIA_USUARIO
            sqlParametro = .Parameters.Add("@ID_MEDIO_PAGO", SqlDbType.SmallInt) : sqlParametro.Value = Me._ID_MEDIO_PAGO
            sqlParametro = .Parameters.Add("@CODIGO_BANCO", SqlDbType.NVarChar, 3) : sqlParametro.Value = Me._CODIGO_BANCO
            sqlParametro = .Parameters.Add("@CONCEPTO1", SqlDbType.NVarChar, 80) : sqlParametro.Value = Me._CONCEPTO1
            sqlParametro = .Parameters.Add("@CONCEPTO2", SqlDbType.NVarChar, 80) : sqlParametro.Value = Me._CONCEPTO2
            sqlParametro = .Parameters.Add("@TOTAL", SqlDbType.Decimal) : sqlParametro.Value = Me._TOTAL
            sqlParametro = .Parameters.Add("@TIPO_DE_CAMBIO", SqlDbType.Decimal) : sqlParametro.Value = Me._TIPO_DE_CAMBIO
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO_GRABO", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Usuario
            sqlParametro = .Parameters.Add("@CODIGO_MODULO", SqlDbType.NVarChar, 4) : sqlParametro.Value = "CXC"
            sqlParametro = .Parameters.Add("@TOTAL_DOLARES", SqlDbType.Decimal) : sqlParametro.Value = Me._TOTAL_DOLARES
            sqlParametro = .Parameters.Add("@AFECTA_SALDO_CATALOGOS", SqlDbType.Char, 1) : sqlParametro.Value = "1"

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                Me._FOLIO_CXC = "" & .Parameters("@FOLIO_CXC").Value.ToString
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