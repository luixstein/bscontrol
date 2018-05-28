Imports System.Data
Imports System.Data.SqlClient

Public Class Class_CatProductos
    Inherits Class_Catalogos

#Region "Campos"

#Region "Campos de la tabla"
    Private _CODIGO_PRODUCTO As String
    Private _NOMBRE_PRODUCTO As String
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
    Public Property CODIGO_PRODUCTO() As String
        Get
            Return Me._CODIGO_PRODUCTO
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_PRODUCTO = Value
        End Set
    End Property

    Public Property NOMBRE_PRODUCTO() As String
        Get
            Return Me._NOMBRE_PRODUCTO
        End Get
        Set(ByVal Value As String)
            Me._NOMBRE_PRODUCTO = Value
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
    'Public Property Estatus() As String
    '    Get
    '        Return Me._Estatus
    '    End Get
    '    Set(ByVal value As String)
    '        Me._Estatus = value
    '    End Set
    'End Property

#End Region

#End Region

#Region "Constructor y destructor"

    Public Sub New()
        Me._Nombre_Catalogo = "CAT_PRODUCTOS"
        'Me._Nombre_Reporte = "RPT_CATALOGO_EMPAQUES"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "SELECT * FROM CAT_PRODUCTOS"
        Me._QueryOrder = " ORDER BY NOMBRE_PRODUCTO"
    End Sub

    Public Sub New(ByVal sCodigoProducto As String)
        Me.New()
        Try
            Me._CODIGO_PRODUCTO = sCodigoProducto
            If Me.Consultar = True Then
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
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CAT_PRODUCTOS_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_PRODUCTO", SqlDbType.Int) : sqlParametro.Value = 0
            sqlParametro = .Parameters.Add("@NOMBRE_PRODUCTO", SqlDbType.NVarChar, 50) : sqlParametro.Value = Me._NOMBRE_PRODUCTO.ToString.ToUpper
            sqlParametro = .Parameters.Add("@ESTATUS", SqlDbType.Char, 1) : sqlParametro.Value = Me.Estatus.ToUpper
            sqlParametro = .Parameters.Add("@AGREGAR", SqlDbType.Char, 1) : sqlParametro.Value = "1"
            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "Insertar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Overrides Function Actualizar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CAT_PRODUCTOS_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_PRODUCTO", SqlDbType.Int) : sqlParametro.Value = CInt(Me._CODIGO_PRODUCTO)
            sqlParametro = .Parameters.Add("@NOMBRE_PRODUCTO", SqlDbType.NVarChar, 50) : sqlParametro.Value = Me._NOMBRE_PRODUCTO.ToString.ToUpper
            sqlParametro = .Parameters.Add("@ESTATUS", SqlDbType.Char, 1) : sqlParametro.Value = Me.Estatus.ToUpper
            sqlParametro = .Parameters.Add("@AGREGAR", SqlDbType.Char, 1) : sqlParametro.Value = "0"
            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "Actualizar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Overrides Function Consultar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand("SELECT * FROM CAT_PRODUCTOS WHERE CODIGO_PRODUCTO=" & Me._CODIGO_PRODUCTO, Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._CODIGO_PRODUCTO = dReader("CODIGO_PRODUCTO")
                    Me._NOMBRE_PRODUCTO = Trim("" & dReader("NOMBRE_PRODUCTO").ToString)
                    Me.Estatus = dReader("ESTATUS")
                    bResultado = True
                End If
                dReader.Close()
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "Consultar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
            End Try
        End With
        Return bResultado
    End Function

    Public Function ObtenerRelacionProductosArticulos(ByVal sCodigoProducto As String) As System.Data.DataTable
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter("SELECT A.CODIGO_ARTICULO,A.DESCRIPCION FROM CAT_ARTICULOS A WHERE A.CODIGO_PRODUCTO =" & sCodigoProducto & " ORDER BY A.DESCRIPCION ", Me._Conexion)
        Try
            da.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerRelacionProductosArticulos", ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

    Public Overrides Function ObtenerElementos() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter("SELECT CODIGO_PRODUCTO,NOMBRE_PRODUCTO FROM CAT_PRODUCTOS " & Me._QueryOrder, Me._Conexion)
        Try
            da.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementos", ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerElementosParaReportes() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter(Me._QuerySelect & Me._QueryOrder, Me._Conexion)
        Try
            da.Fill(dTable)
            dTable.Rows.Add("T", "TODOS")
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementosParaReportes", ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerElementosFiltro(ByVal Filtro As String) As System.Data.DataTable
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter("SELECT CODIGO_PRODUCTO,NOMBRE_PRODUCTO FROM CAT_PRODUCTOS WHERE NOMBRE_PRODUCTO LIKE '" & Filtro.ToString & "%' ORDER BY NOMBRE_PRODUCTO", Me._Conexion)
        Try
            da.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementosFiltro", ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

    Public Overrides Function BusquedaVisual_PorCodigo() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de propietario por codigo."
        f.sCampo = "CODIGO_PRODUCTO"
        f.sOrder = "NOMBRE_PRODUCTO"
        f.sTable = "CAT_PRODUCTOS"
        f.sQl = "SELECT CODIGO_PRODUCTO,NOMBRE_PRODUCTO FROM CAT_PRODUCTOS Where 1=1 And"
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
        f.Text = "Búsqueda de propietarios por nombre."
        f.sCampo = "NOMBRE_PRODUCTO"
        f.sOrder = "NOMBRE_PRODUCTO"
        f.sTable = "CAT_PRODUCTOS"
        f.sQl = "SELECT CODIGO_PRODUCTO,NOMBRE_PRODUCTO FROM CAT_PRODUCTOS Where 1=1 And"
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

    Public Function CodigoSiguiente() As Integer
        Dim iPropietarios As Integer
        Try
            Dim sql As New Class_find("SELECT MAX(CODIGO_PRODUCTO) FROM CAT_PRODUCTOS")
            If sql.Result1 = "" Then
                iPropietarios = 1
            Else
                iPropietarios = CType(sql.Result1, Integer) + 1
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "CodigoSiguiente", ex)
        End Try
        Return iPropietarios
    End Function
#End Region

End Class