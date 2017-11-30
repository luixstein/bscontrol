Option Strict On

Imports System.Data.SqlClient

Public Class Class_CatClientesCuentasBancarias

#Region "Campos"

#Region "Campos de la tabla"
    Private _ID_CUENTA As String
    Private _CUENTA As String
    Private _CODIGO_CLIENTE As String
    Private _CODIGO_METODO_PAGO As String
    Private _RFC_EMISOR As String
    Private _CODIGO_BANCO As String
    Private _ESTATUS As String
#End Region

#Region "Campos ligados a la tabla"
    Private _Existe As Boolean
    Private _NOMBRE_BANCO As String
#End Region

#Region "Campos de sistema"
    Private _Nombre_Catalogo As String
    Private _Nombre_Reporte As String
    Private _Conexion As SqlConnection
    Private _QuerySelect As String
    Private _QueryOrder As String
#End Region

#End Region

#Region "Propiedades"

#Region "Propiedades Campos de la tabla"

    Public Property ID_CUENTA() As String
        Get
            Return Me._ID_CUENTA
        End Get
        Set(ByVal Value As String)
            Me._ID_CUENTA = Value
        End Set
    End Property

    Public Property CUENTA() As String
        Get
            Return Me._CUENTA
        End Get
        Set(ByVal Value As String)
            Me._CUENTA = Value
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

    Public Property CODIGO_METODO_PAGO() As String
        Get
            Return Me._CODIGO_METODO_PAGO
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_METODO_PAGO = Value
        End Set
    End Property

    Public Property RFC_EMISOR() As String
        Get
            Return Me._RFC_EMISOR
        End Get
        Set(ByVal Value As String)
            Me._RFC_EMISOR = Value
        End Set
    End Property

    Public Property CODIGO_BANCO() As String
        Get
            Return Me._CODIGO_BANCO
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_BANCO = Value
        End Set
    End Property

    Public ReadOnly Property NOMBRE_BANCO() As String
        Get
            Return Me._NOMBRE_BANCO
        End Get
    End Property
#End Region

#Region "Propiedades de campos ligados a la tabla"
    Public ReadOnly Property Existe() As Boolean
        Get
            Return Me._Existe
        End Get
    End Property
#End Region

#Region "Propiedades de campos de sistema"
    Public ReadOnly Property Nombre_Catalogo() As String
        Get
            Return Me._Nombre_Catalogo
        End Get
    End Property

    Public Property Nombre_Reporte() As String
        Get
            Return Me._Nombre_Reporte
        End Get
        Set(ByVal value As String)
            Me._Nombre_Reporte = value
        End Set
    End Property

#End Region
#End Region

#Region "Constructor y destructor"
    Public Sub New()
        Me._Nombre_Catalogo = "CAT_CLIENTES_CUENTAS_BANCARIAS"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "SELECT C.*,B.NOMBRE_BANCO FROM CAT_CLIENTES_CUENTAS_BANCARIAS C INNER JOIN CAT_BANCOS B ON(C.CODIGO_BANCO=B.CODIGO_BANCO) "
        Me._QueryOrder = " ORDER BY C.CODIGO_CLIENTE"
    End Sub

    Public Sub New(ByVal sIDCuenta As String)
        Me.New()
        Me._ID_CUENTA = sIDCuenta
        Try
            If Me.Consultar = True Then
                Me._Existe = True
                'Else
                '    Throw New Exception("El PRODUCTOR no existe.")
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "New", ex)
        End Try
    End Sub

    Protected Overrides Sub Finalize()
        'Me._Conexion.Dispose()
        MyBase.Finalize()
    End Sub
#End Region

#Region "Métodos y procedimientos"

    Public Function Grabar(ByVal sAccion As String) As Boolean '1=Insertar,0=Actualizar
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CAT_CLIENTES_GRABA_CUENTAS_BANCARIAS"

            sqlParametro = .Parameters.Add("@ID_CUENTA", SqlDbType.Int) : sqlParametro.Value = Me._ID_CUENTA : sqlParametro.Direction = ParameterDirection.InputOutput
            sqlParametro = .Parameters.Add("@CUENTA", SqlDbType.NVarChar, 18) : sqlParametro.Value = Me._CUENTA.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_CLIENTE", SqlDbType.NVarChar, 8) : sqlParametro.Value = Me._CODIGO_CLIENTE.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_METODO_PAGO", SqlDbType.NVarChar, 2) : sqlParametro.Value = Me._CODIGO_METODO_PAGO.ToUpper
            sqlParametro = .Parameters.Add("@RFC_EMISOR", SqlDbType.NVarChar, 13) : sqlParametro.Value = Me._RFC_EMISOR.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_BANCO", SqlDbType.NVarChar, 3) : sqlParametro.Value = Me._CODIGO_BANCO.ToUpper
            sqlParametro = .Parameters.Add("@AGREGAR", SqlDbType.Char, 1) : sqlParametro.Value = sAccion

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                Me._ID_CUENTA = .Parameters("@ID_CUENTA").Value.ToString
                bResultado = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "Grabar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Function Consultar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand(Me._QuerySelect & " WHERE ID_CUENTA='" & sReplace(Me._ID_CUENTA) & "'", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._ID_CUENTA = dReader("ID_CUENTA").ToString()
                    Me._CUENTA = dReader("CUENTA").ToString()
                    Me._CODIGO_CLIENTE = dReader("CODIGO_CLIENTE").ToString()
                    Me._CODIGO_METODO_PAGO = dReader("CODIGO_METODO_PAGO").ToString()
                    Me._RFC_EMISOR = dReader("RFC_EMISOR").ToString()
                    Me._CODIGO_BANCO = dReader("CODIGO_BANCO").ToString()
                    Me._NOMBRE_BANCO = dReader("NOMBRE_BANCO").ToString()

                    bResultado = True
                End If
                dReader.Close()
            Catch ex As Exception
                HandleError(Me.Nombre_Catalogo, "Consultar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
            End Try
        End With
        Return bResultado
    End Function

    Public Function ObtenerElementos(ByVal sCodigoCliente As String) As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dsCat As New SqlDataAdapter("SELECT C.ID_CUENTA,C.CUENTA+'-'+M.NOMBRE_METODO_PAGO+'-'+B.NOMBRE_BANCO CUENTA_CLIENTE " &
            "FROM CAT_CLIENTES_CUENTAS_BANCARIAS C " &
            "INNER JOIN CFD_CAT_METODOS_PAGO M ON(C.CODIGO_METODO_PAGO=M.CODIGO_METODO_PAGO)  " &
            "INNER JOIN CAT_BANCOS B ON(C.CODIGO_BANCO=B.CODIGO_BANCO) " &
            "WHERE C.CODIGO_CLIENTE='" & sReplace(sCodigoCliente) & "' ORDER BY M.NOMBRE_METODO_PAGO", Me._Conexion)
        Try
            dsCat.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementos", ex)
        Finally
            dsCat.Dispose()
        End Try
        Return dTable
    End Function

#End Region

End Class
