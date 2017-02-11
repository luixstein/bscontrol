Imports System.Data
Imports System.Data.SqlClient

Public Class Class_CatAddenda
    Inherits Class_Catalogos

#Region "Campos"

#Region "Campos de la tabla"
    Private _CODIGO_PROVEEDOR_SORIANA As Integer
    Private _FOLIO_VENTA As String
    Private _CODIGO_TIENDA_SORIANA As String
    Private _TIPO_MONEDA As Integer
    Private _TIPO_BULTO As Integer
    Private _CANTIDAD_BULTOS As Integer
    Private _FECHA_ENTREGA As DateTime
    Private _CITA As String
    Private _FOLIO_PEDIDO As String
    Private _FOLIO_NOTA_ENTRADA As String
    Private _ENVIADA_CORRECTAMENTE As Boolean
    Private _TIPO_ADDENDA As String
#End Region

#Region "Campos ligados a la tabla"
    Private _Existe As Boolean
#End Region

#Region "Campos públicos"

#End Region

#Region "Campos privados"

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
    Public Property CODIGO_PROVEEDOR_SORIANA() As Integer
        Get
            Return Me._CODIGO_PROVEEDOR_SORIANA
        End Get
        Set(ByVal Value As Integer)
            Me._CODIGO_PROVEEDOR_SORIANA = Value
        End Set
    End Property

    Public Property FOLIO_VENTA() As String
        Get
            Return Me._FOLIO_VENTA
        End Get
        Set(ByVal Value As String)
            Me._FOLIO_VENTA = Value
        End Set
    End Property

    Public Property TIPO_MONEDA() As Integer
        Get
            Return Me._TIPO_MONEDA
        End Get
        Set(ByVal Value As Integer)
            Me._TIPO_MONEDA = Value
        End Set
    End Property

    Public Property TIPO_BULTO() As Integer
        Get
            Return Me._TIPO_BULTO
        End Get
        Set(ByVal Value As Integer)
            Me._TIPO_BULTO = Value
        End Set
    End Property

    Public Property CANTIDAD_BULTOS() As Integer
        Get
            Return Me._CANTIDAD_BULTOS
        End Get
        Set(ByVal Value As Integer)
            Me._CANTIDAD_BULTOS = Value
        End Set
    End Property

    Public Property CODIGO_TIENDA_SORIANA() As String
        Get
            Return Me._CODIGO_TIENDA_SORIANA
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_TIENDA_SORIANA = Value
        End Set
    End Property

    Public Property CITA() As String
        Get
            Return Me._CITA
        End Get
        Set(ByVal Value As String)
            Me._CITA = Value
        End Set
    End Property

    Public Property FOLIO_PEDIDO() As String
        Get
            Return Me._FOLIO_PEDIDO
        End Get
        Set(ByVal Value As String)
            Me._FOLIO_PEDIDO = Value
        End Set
    End Property

    Public Property FECHA_ENTREGA() As DateTime
        Get
            Return Me._FECHA_ENTREGA
        End Get
        Set(ByVal Value As DateTime)
            Me._FECHA_ENTREGA = Value
        End Set
    End Property

    Public Property FOLIO_NOTA_ENTRADA() As String
        Get
            Return Me._FOLIO_NOTA_ENTRADA
        End Get
        Set(ByVal Value As String)
            Me._FOLIO_NOTA_ENTRADA = Value
        End Set
    End Property

    Public Property ENVIADA_CORRECTAMENTE() As Boolean
        Get
            Return Me._ENVIADA_CORRECTAMENTE
        End Get
        Set(ByVal Value As Boolean)
            Me._ENVIADA_CORRECTAMENTE = Value
        End Set
    End Property

    Public Property TIPO_ADDENDA() As String
        Get
            Return Me._TIPO_ADDENDA
        End Get
        Set(ByVal Value As String)
            Me._TIPO_ADDENDA = Value
        End Set
    End Property
#End Region

#Region "Propiedades de campos ligados a la tabla"

    Public ReadOnly Property Existe() As Boolean
        Get
            Return Me._Existe
        End Get
    End Property
#End Region

#Region "Propiedades públicos"

#End Region

#Region "Propiedades de campos privados"

#End Region
#Region "Propiedades de campos de sistema"

    Public Overrides ReadOnly Property Nombre_Catalogo() As String
        Get
            Return Me._Nombre_Catalogo
        End Get
    End Property

    Public Overrides Property Nombre_Reporte() As String
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
        Me._Nombre_Catalogo = "VENTAS_ADDENDAS"
        Me._Nombre_Reporte = ""
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "Select * From VENTAS_ADDENDAS"
        Me._QueryOrder = " Order by FOLIO_VENTA"
    End Sub                                                         'Inicializa al objeto.

    Public Sub New(ByVal sfolioVenta As String)
        Me.New()
        Try
            Me._FOLIO_VENTA = sfolioVenta
            If Me.Consultar = False Then
                'Throw New Exception("El documento de venta no existe.")
            Else
                Me._Existe = True
            End If
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "New", ex)
        End Try

    End Sub
    Protected Overrides Sub Finalize()
        'Me._Conexion.Dispose()
        MyBase.Finalize()
    End Sub
#End Region

#Region "Opciones"

#End Region

#Region "Métodos y procedimientos"

    Public Overrides Function Insertar() As Boolean
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_VENTAS_GRABA_ADDENDA"

            sqlParametro = .Parameters.Add("@CODIGO_PROVEEDOR_SORIANA", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._CODIGO_PROVEEDOR_SORIANA
            sqlParametro = .Parameters.Add("@FOLIO_VENTA", SqlDbType.NVarChar, 14) : sqlParametro.Value = Me._FOLIO_VENTA
            sqlParametro = .Parameters.Add("@CODIGO_TIENDA_SORIANA", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_TIENDA_SORIANA
            sqlParametro = .Parameters.Add("@TIPO_MONEDA", SqlDbType.SmallInt, 2) : sqlParametro.Value = Me._TIPO_MONEDA
            sqlParametro = .Parameters.Add("@TIPO_BULTO", SqlDbType.SmallInt, 2) : sqlParametro.Value = Me._TIPO_BULTO
            sqlParametro = .Parameters.Add("@CANTIDAD_BULTOS", SqlDbType.Int) : sqlParametro.Value = Me._CANTIDAD_BULTOS
            sqlParametro = .Parameters.Add("@FECHA_ENTREGA", SqlDbType.DateTime) : sqlParametro.Value = Me._FECHA_ENTREGA
            sqlParametro = .Parameters.Add("@CITA", SqlDbType.NVarChar, 18) : sqlParametro.Value = Me._CITA
            sqlParametro = .Parameters.Add("@FOLIO_PEDIDO", SqlDbType.NVarChar, 18) : sqlParametro.Value = Me._FOLIO_PEDIDO
            sqlParametro = .Parameters.Add("@FOLIO_NOTA_ENTRADA", SqlDbType.NVarChar, 18) : sqlParametro.Value = Me._FOLIO_NOTA_ENTRADA
            sqlParametro = .Parameters.Add("@TIPO_ADDENDA", SqlDbType.Char, 1) : sqlParametro.Value = Me._TIPO_ADDENDA
            sqlParametro = .Parameters.Add("@AGREGAR", SqlDbType.Char, 1) : sqlParametro.Value = "1"

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
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

    Public Overrides Function Actualizar() As Boolean
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_VENTAS_GRABA_ADDENDA"

            sqlParametro = .Parameters.Add("@CODIGO_PROVEEDOR_SORIANA", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._CODIGO_PROVEEDOR_SORIANA
            sqlParametro = .Parameters.Add("@FOLIO_VENTA", SqlDbType.NVarChar, 14) : sqlParametro.Value = Me._FOLIO_VENTA
            sqlParametro = .Parameters.Add("@CODIGO_TIENDA_SORIANA", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_TIENDA_SORIANA
            sqlParametro = .Parameters.Add("@TIPO_MONEDA", SqlDbType.SmallInt, 2) : sqlParametro.Value = Me._TIPO_MONEDA
            sqlParametro = .Parameters.Add("@TIPO_BULTO", SqlDbType.SmallInt, 2) : sqlParametro.Value = Me._TIPO_BULTO
            sqlParametro = .Parameters.Add("@CANTIDAD_BULTOS", SqlDbType.Int) : sqlParametro.Value = Me._CANTIDAD_BULTOS
            sqlParametro = .Parameters.Add("@FECHA_ENTREGA", SqlDbType.DateTime) : sqlParametro.Value = Me._FECHA_ENTREGA
            sqlParametro = .Parameters.Add("@CITA", SqlDbType.NVarChar, 14) : sqlParametro.Value = Me._CITA
            sqlParametro = .Parameters.Add("@FOLIO_PEDIDO", SqlDbType.NVarChar, 18) : sqlParametro.Value = Me._FOLIO_PEDIDO
            sqlParametro = .Parameters.Add("@FOLIO_NOTA_ENTRADA", SqlDbType.NVarChar, 18) : sqlParametro.Value = Me._FOLIO_NOTA_ENTRADA
            sqlParametro = .Parameters.Add("@TIPO_ADDENDA", SqlDbType.Char, 1) : sqlParametro.Value = Me._TIPO_ADDENDA
            sqlParametro = .Parameters.Add("@AGREGAR", SqlDbType.Char, 1) : sqlParametro.Value = "0"

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                Actualizar = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "Actualizar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try

        End With
    End Function                        'Actualiza un elemento del catálogo.

    Public Overrides Function Consultar() As Boolean
        Dim cmd As New SqlCommand(Me._QuerySelect & " Where FOLIO_VENTA='" & Me._FOLIO_VENTA & "'", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._CODIGO_PROVEEDOR_SORIANA = "" & dReader("CODIGO_PROVEEDOR_SORIANA")
                    Me._FOLIO_VENTA = Trim("" & dReader("FOLIO_VENTA").ToString)
                    Me._CODIGO_TIENDA_SORIANA = "" & dReader("CODIGO_TIENDA_SORIANA").ToString
                    Me._TIPO_MONEDA = CInt(dReader("TIPO_MONEDA").ToString)
                    Me._TIPO_BULTO = CInt(dReader("TIPO_BULTO").ToString)
                    Me._CANTIDAD_BULTOS = CInt(dReader("CANTIDAD_BULTOS").ToString)
                    Me._FECHA_ENTREGA = CDate(dReader("FECHA_ENTREGA").ToString)
                    Me._CITA = "" & dReader("CITA").ToString
                    Me._FOLIO_PEDIDO = "" & dReader("FOLIO_PEDIDO").ToString
                    Me._FOLIO_NOTA_ENTRADA = "" & dReader("FOLIO_NOTA_ENTRADA").ToString
                    Me._ENVIADA_CORRECTAMENTE = CBool(dReader("ENVIADA_CORRECTAMENTE").ToString)
                    Me._TIPO_ADDENDA = "" & dReader("TIPO_ADDENDA").ToString
                    Consultar = True
                End If
                dReader.Close()
            Catch ex As Exception
                HandleError(Me.Nombre_Catalogo, "Consultar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
            End Try
        End With

    End Function        'Consulta un elemento del catálogo.


    Public Function Graba_Aperak(ByVal Aperak As String, ByVal bEnviadaCorrectamente As Boolean) As Boolean
        Dim Aperak1 As String = ""
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_VENTAS_GRABA_ADDENDA_APERAK"
            Aperak1 = Replace(Aperak, "<?xml version=""1.0"" encoding=""UTF-8""?>", "")

            sqlParametro = .Parameters.Add("@FOLIO_VENTA", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_VENTA
            sqlParametro = .Parameters.Add("@ENVIADA_CORRECTAMENTE", SqlDbType.Char, 1) : sqlParametro.Value = Convert.ToInt32(bEnviadaCorrectamente)
            sqlParametro = .Parameters.Add("@APERAK", SqlDbType.Xml) : sqlParametro.Value = Aperak1

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                Graba_Aperak = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "Graba_Aperak", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try

        End With
    End Function

    Public Overrides Function ObtenerElementos() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dsSIS_IVAS As New SqlDataAdapter("select * from VENTAS_ADDENDAS", Me._Conexion)
        Try
            dsSIS_IVAS.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementos", ex)
        Finally
            dsSIS_IVAS.Dispose()
        End Try
        Return dTable
    End Function    'Obtiene una lita completa de los elementos del catalogo en un datatable.

    Public Overrides Function BusquedaVisual_PorCodigo() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de ADDENDA por codigo."
        f.sCampo = "CITA"
        f.sOrder = "FOLIO_VENTA"
        f.sTable = "VENTAS_ADDENDAS"
        f.sQl = "Select FOLIO_VENTA,CITA From VENTAS_ADDENDAS Where 1=1 And"
        f.Inicia("")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "BusquedaVisual_PorCodigo", ex)
        End Try
        Return Resultado
    End Function

    Public Overrides Function BusquedaVisual_PorDescripcion() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de ADDENDA por Descripción."
        f.sCampo = "FOLIO_VENTA"
        f.sOrder = "FOLIO_VENTA"
        f.sTable = "VENTAS_ADDENDAS"
        f.sQl = "Select * From VENTAS_ADDENDAS Where 1=1 And"
        f.Inicia("")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "BusquedaVisual_PorDescripcion", ex)
        End Try
        Return Resultado
    End Function
#End Region

End Class
