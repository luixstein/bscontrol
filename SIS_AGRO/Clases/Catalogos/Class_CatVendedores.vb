Imports System.Data
Imports System.Data.SqlClient

Public Class Class_CatVendedores
    Inherits Class_Catalogos

#Region "Campos"

#Region "Campos de la tabla"
    Private _Codigo_Vendedor As Integer
    Private _Nombre_Vendedor As String
    Private _Estatus As String
    Private _Codigo_Categoria As String
    Private _Agregar As String
#End Region

#Region "Campos ligados a la tabla"

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
    Public Property Codigo_Vendedor() As Integer
        Get
            Return Me._Codigo_Vendedor
        End Get
        Set(ByVal Value As Integer)
            Me._Codigo_Vendedor = Value
        End Set
    End Property

    Public Property Nombre_Vendedor() As String
        Get
            Return Me._Nombre_Vendedor
        End Get
        Set(ByVal Value As String)
            Me._Nombre_Vendedor = Value
        End Set
    End Property

    Public Property Codigo_Categoria() As String
        Get
            Return Me._Codigo_Categoria
        End Get
        Set(ByVal Value As String)
            Me._Codigo_Categoria = Value
        End Set
    End Property

    Public Property Agregar() As String
        Get
            Return Me._Agregar
        End Get
        Set(ByVal Value As String)
            Me._Agregar = Value
        End Set
    End Property

#End Region

#Region "Propiedades de campos ligados a la tabla"

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
    Public Property Status() As String
        Get
            Return Me._Estatus
        End Get
        Set(ByVal value As String)
            Me._Estatus = value
        End Set
    End Property
#End Region

#End Region

#Region "Constructor y destructor"

    Public Sub New()
        Me._Nombre_Catalogo = "Cat_Vendedores"
        Me._Nombre_Reporte = "RPT_Cat_Vendedores.rpt"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "Select codigo_Vendedor,Nombre_Vendedor From Cat_Vendedores"
        Me._QueryOrder = " Order by Nombre_Vendedor"
    End Sub                                                         'Inicializa al objeto.

    Protected Overrides Sub Finalize()
        'Me._Conexion.Dispose()
        MyBase.Finalize()
    End Sub
#End Region

#Region "Métodos y procedimientos"

    Public Overrides Function Actualizar() As Boolean
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CAT_VENDEDORES_GRABA"

            sqlParametro = .Parameters.Add("@codigo_Vendedor", SqlDbType.SmallInt, 2) : sqlParametro.Value = Me._Codigo_Vendedor
            sqlParametro = .Parameters.Add("@Nombre_Vendedor", SqlDbType.NVarChar, 50) : sqlParametro.Value = Me._Nombre_Vendedor.ToString.ToUpper
            sqlParametro = .Parameters.Add("@ESTATUS", SqlDbType.Char, 1) : sqlParametro.Value = Me._Estatus.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_CATEGORIA", SqlDbType.SmallInt) : sqlParametro.Value = CInt(Me._Codigo_Categoria)
            sqlParametro = .Parameters.Add("@AGREGAR", SqlDbType.NVarChar, 1) : sqlParametro.Value = Me._Agregar

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
        Dim cmd As New SqlCommand("Select * from Cat_Vendedores Where CODIGO_Vendedor=" & Replace(Me._Codigo_Vendedor, "'", "''") & "", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._Codigo_Vendedor = "" & dReader("codigo_Vendedor")
                    Me._Nombre_Vendedor = Trim("" & dReader("Nombre_Vendedor").ToString)
                    Me._Estatus = "" & dReader("ESTATUS").ToString
                    Me._Codigo_Categoria = "" & dReader("codigo_categoria")
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

    Public Overrides Function Insertar() As Boolean
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CAT_VENDEDORES_GRABA"

            sqlParametro = .Parameters.Add("@codigo_Vendedor", SqlDbType.SmallInt, 2) : sqlParametro.Value = Me._Codigo_Vendedor
            sqlParametro = .Parameters.Add("@Nombre_Vendedor", SqlDbType.NVarChar, 50) : sqlParametro.Value = Me._Nombre_Vendedor.ToString.ToUpper
            sqlParametro = .Parameters.Add("@ESTATUS", SqlDbType.Char, 1) : sqlParametro.Value = Me._Estatus.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_CATEGORIA", SqlDbType.SmallInt) : sqlParametro.Value = CInt(Me._Codigo_Categoria)
            sqlParametro = .Parameters.Add("@AGREGAR", SqlDbType.NVarChar, 1) : sqlParametro.Value = Me._Agregar

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                Insertar = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "Actualizar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try

        End With
    End Function                          'Inserta un elemento al catálogo.

    Public Overrides Function ObtenerElementos() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dsCat_Vendedores As New SqlDataAdapter("Select codigo_Vendedor,Nombre_Vendedor from Cat_Vendedores order by Nombre_Vendedor", Me._Conexion)
        Try
            dsCat_Vendedores.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementos", ex)
        Finally
            dsCat_Vendedores.Dispose()
        End Try
        Return dTable
    End Function    'Obtiene una lita completa de los elementos del catalogo en un datatable.

    Public Function ObtenerElementosFiltro(ByVal Filtro As String) As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dA As New SqlDataAdapter("SELECT CODIGO_VENDEDOR, NOMBRE_VENDEDOR FROM CAT_VENDEDORES WHERE NOMBRE_VENDEDOR LIKE '" & Filtro.ToString & "%' ORDER BY NOMBRE_VENDEDOR", Me._Conexion)
        Try
            dA.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementosFiltro", ex)
        Finally
            dA.Dispose()
        End Try
        Return dTable
    End Function

    Public Overrides Function BusquedaVisual_PorCodigo() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de Metodos de Vendedores por codigo."
        f.sCampo = "codigo_Vendedor"
        f.sOrder = "Nombre_Vendedor"
        f.sTable = "Cat_Vendedores"
        f.sQl = "Select Id_Vendedor,Nombre_Vendedor From Cat_Vendedores Where 1=1 And"
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
        f.Text = "Búsqueda de Metodos de Vendedores por Descripción."
        f.sCampo = "Nombre_Vendedor"
        f.sOrder = "Nombre_Vendedor"
        f.sTable = "Cat_Vendedores"
        f.sQl = "Select CODIGO_VENDEDOR,Nombre_Vendedor From Cat_Vendedores Where 1=1 And"
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

    Public Function codigoSiguiente() As Integer
        Dim iCodigo As Integer
        Dim sql As New Class_find("SELECT ISNULL(MAX(CODIGO_VENDEDOR),'') FROM CAT_VENDEDORES")

        iCodigo = CInt(sql.Result1) + 1
        Return iCodigo
    End Function
#End Region

End Class
