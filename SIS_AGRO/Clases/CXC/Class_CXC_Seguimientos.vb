Option Strict On
Imports System.Data
Imports System.Data.SqlClient

Public Class Class_CXC_Seguimientos

#Region "Campos"

#Region "Campos de la tabla"
    Private _IDSEGUIMIENTO As Integer
    Private _FECHA As Date
    Private _SEGUIMIENTO As String
    Private _CODIGO_USUARIO As Integer
    Private _CODIGO_NEGOCIANTE As Integer
    Private _CONTACTADO_POR As String
    Private _ESTATUS_REVISADO As String
    Private _CODIGO_TIPO_ACUERDO As Integer
    Private _CODIGO_CLIENTE As String
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

#Region "Campos ligados a la tabla"
    Private _Existe As Boolean 'lectura
    Private _Nombre_Formato As String
#End Region

#Region "Campos de privado"
    Private _oDocumento As Class_CatDocumentos
#End Region

#End Region

#Region "Propiedades"
#Region "Propiedades Campos de la tabla"
    Public Property IDSEGUIMIENTO() As Integer
        Get
            Return Me._IDSEGUIMIENTO
        End Get
        Set(ByVal Value As Integer)
            Me._IDSEGUIMIENTO = Value
        End Set
    End Property

    Public Property FECHA() As Date
        Get
            Return Me._FECHA
        End Get
        Set(ByVal Value As Date)
            Me._FECHA = Value
        End Set
    End Property

    Public Property SEGUIMIENTO() As String
        Get
            Return Me._SEGUIMIENTO
        End Get
        Set(ByVal Value As String)
            Me._SEGUIMIENTO = Value
        End Set
    End Property

    Public Property CODIGO_USUARIO() As Integer
        Get
            Return Me._CODIGO_USUARIO
        End Get
        Set(ByVal Value As Integer)
            Me._CODIGO_USUARIO = Value
        End Set
    End Property

    Public Property CODIGO_NEGOCIANTE() As Integer
        Get
            Return Me._CODIGO_NEGOCIANTE
        End Get
        Set(ByVal Value As Integer)
            Me._CODIGO_NEGOCIANTE = Value
        End Set
    End Property

    Public Property CONTACTADO_POR() As String
        Get
            Return Me._CONTACTADO_POR
        End Get
        Set(ByVal Value As String)
            Me._CONTACTADO_POR = Value
        End Set
    End Property

    Public Property ESTATUS_REVISADO() As String
        Get
            Return Me._ESTATUS_REVISADO
        End Get
        Set(ByVal Value As String)
            Me._ESTATUS_REVISADO = Value
        End Set
    End Property

    Public Property CODIGO_TIPO_ACUERDO() As Integer
        Get
            Return Me._CODIGO_TIPO_ACUERDO
        End Get
        Set(ByVal Value As Integer)
            Me._CODIGO_TIPO_ACUERDO = Value
        End Set
    End Property

    Public Property CODIGO_CLIENTE() As String
        Get
            Return Me._CODIGO_CLIENTE
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_CLIENTE = Value
        End Set
    End Property

#End Region

#Region "Propiedad Nombre de Clase"
    Public ReadOnly Property Nombre_Clase() As String
        Get
            Return "Class_CXC_Descuentos"
        End Get
    End Property
#End Region

#Region "Propiedades de campos ligados a la tabla"
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
#End Region

#Region "Constructor y destructor"
    Public Sub New()
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        ' Me.oDocumento = New Class_CatDocumentos()
    End Sub                                                         'Inicializa al objeto.

    Public Sub New(ByVal folioDescuento As String)
        Me.New()
        'Me._FOLIO_DESCUENTO = folioDescuento

        Try
            'If Me.Consultar = True Then
            'Me._Existe = True
            'End If
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "New", ex)
        End Try
    End Sub

    Protected Overrides Sub Finalize()
        Me._Conexion.Dispose()
        MyBase.Finalize()
    End Sub
#End Region

#Region "Métodos y procedimientos"

    Public Function Insertar() As Boolean
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CXC_SEGUIMIENTO_GRABAR"

            sqlParametro = .Parameters.Add("@IDSEGUIMIENTO", SqlDbType.SmallInt) : sqlParametro.Direction = ParameterDirection.InputOutput
            sqlParametro = .Parameters.Add("@FECHA", SqlDbType.DateTime) : sqlParametro.Value = Me._FECHA
            sqlParametro = .Parameters.Add("@SEGUIMIENTO", SqlDbType.NVarChar, 300) : sqlParametro.Value = Me._SEGUIMIENTO
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_USUARIO
            sqlParametro = .Parameters.Add("@CODIGO_NEGOCIANTE", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_NEGOCIANTE
            sqlParametro = .Parameters.Add("@CONTACTADO_POR", SqlDbType.NVarChar, 10) : sqlParametro.Value = Me._CONTACTADO_POR
            sqlParametro = .Parameters.Add("@CODIGO_TIPO_ACUERDO", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_TIPO_ACUERDO
            sqlParametro = .Parameters.Add("@CODIGO_CLIENTE", SqlDbType.NVarChar, 8) : sqlParametro.Value = Me._CODIGO_CLIENTE

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                Me._IDSEGUIMIENTO = CInt(.Parameters("@IDSEGUIMIENTO").Value)
                Insertar = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "Insertar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
    End Function

    Public Function ObtenerTipoAcuerdo() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dsCat_TipoAcuerdo As New SqlDataAdapter("select CODIGO_TIPO_ACUERDO,NOMBRE_TIPO_ACUERDO from CXC_SEGUIMIENTOS_TIPOS_ACUERDOS WHERE CODIGO_TIPO_ACUERDO>1 ", Me._Conexion)
        Try
            dsCat_TipoAcuerdo.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementos", ex)
        Finally
            dsCat_TipoAcuerdo.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerNombreNegociante(ByVal sCodigoCliente As String) As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dsCat_TipoAcuerdo As New SqlDataAdapter("select CODIGO_NEGOCIANTE,NOMBRE_NEGOCIANTE FROM CXC_SEGUIMIENTOS_NEGOCIANTES WHERE CODIGO_CLIENTE='" & sCodigoCliente & "' ", Me._Conexion)
        Try
            dsCat_TipoAcuerdo.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementos", ex)
        Finally
            dsCat_TipoAcuerdo.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerUltimoSeguimiento(ByVal sCodigoCliente As String) As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dsCat_TipoAcuerdo As New SqlDataAdapter("select CODIGO_NEGOCIANTE,NOMBRE_NEGOCIANTE FROM CXC_SEGUIMIENTOS_NEGOCIANTES WHERE CODIGO_CLIENTE='" & sCodigoCliente & "' ", Me._Conexion)
        Try
            dsCat_TipoAcuerdo.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementos", ex)
        Finally
            dsCat_TipoAcuerdo.Dispose()
        End Try
        Return dTable
    End Function
#End Region

End Class
