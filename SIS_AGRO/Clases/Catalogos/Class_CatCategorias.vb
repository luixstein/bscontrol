Imports System.Data
Imports System.Data.SqlClient

Public Class Class_CatCategorias
    Inherits Class_Catalogos

#Region "Campos"

#Region "Campos de la tabla"
    Private _CODIGO_CATEGORIA As String
    Private _NOMBRE_CATEGORIA As String
    Private _CODIGO_TIPO_CATEGORIA As String
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
    Private _QuerySELECT As String
    Private _QueryOrder As String

#End Region

#End Region

#Region "Propiedades"

#Region "Propiedades Campos de la tabla"
    Public Property CODIGO_CATEGORIA() As String
        Get
            Return Me._CODIGO_CATEGORIA
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_CATEGORIA = Value
        End Set
    End Property

    Public Property NOMBRE_CATEGORIA() As String
        Get
            Return Me._NOMBRE_CATEGORIA
        End Get
        Set(ByVal Value As String)
            Me._NOMBRE_CATEGORIA = Value
        End Set
    End Property

    Public Property CODIGO_TIPO_CATEGORIA() As String
        Get
            Return Me._CODIGO_TIPO_CATEGORIA
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_TIPO_CATEGORIA = Value
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
        Me._Nombre_Catalogo = "CAT_CATEGORIAS"
        Me._Nombre_Reporte = "RPT_CATALOGO_CATEGORIAS"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySELECT = "SELECT CODIGO_CATEGORIA,NOMBRE_CATEGORIA FROM CAT_CATEGORIAS"
        Me._QueryOrder = " Order by NOMBRE_CATEGORIA"
    End Sub                                                         'Inicializa al objeto.

    Public Sub New(ByVal sCodigoCategoria As String)
        Me.New()
        Try
            Me._CODIGO_CATEGORIA = sCodigoCategoria
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
            .CommandText = "MP_CAT_CATEGORIAS_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_CATEGORIA", SqlDbType.SmallInt) : sqlParametro.Value = CInt(Me._CODIGO_CATEGORIA) : sqlParametro.Direction = ParameterDirection.InputOutput
            sqlParametro = .Parameters.Add("@NOMBRE_CATEGORIA", SqlDbType.NVarChar, 200) : sqlParametro.Value = Me._NOMBRE_CATEGORIA.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_TIPO_CATEGORIA", SqlDbType.SmallInt) : sqlParametro.Value = CInt(Me._CODIGO_TIPO_CATEGORIA)
            sqlParametro = .Parameters.Add("@ESTATUS", SqlDbType.Char, 1) : sqlParametro.Value = Me.Estatus.ToString.ToUpper
            sqlParametro = .Parameters.Add("@ACCION", SqlDbType.NVarChar, 20) : sqlParametro.Value = "INSERTAR"
            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                Me._CODIGO_CATEGORIA = .Parameters("@CODIGO_CATEGORIA").Value.ToString
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
            .CommandText = "MP_CAT_CATEGORIAS_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_CATEGORIA", SqlDbType.SmallInt) : sqlParametro.Value = CInt(Me._CODIGO_CATEGORIA)
            sqlParametro = .Parameters.Add("@NOMBRE_CATEGORIA", SqlDbType.NVarChar, 200) : sqlParametro.Value = Me._NOMBRE_CATEGORIA.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_TIPO_CATEGORIA", SqlDbType.SmallInt) : sqlParametro.Value = CInt(Me._CODIGO_TIPO_CATEGORIA)
            sqlParametro = .Parameters.Add("@ESTATUS", SqlDbType.Char, 1) : sqlParametro.Value = Me.Estatus.ToString.ToUpper
            sqlParametro = .Parameters.Add("@ACCION", SqlDbType.NVarChar, 20) : sqlParametro.Value = "ACTUALIZAR"
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
        Dim cmd As New SqlCommand("SELECT * FROM CAT_CATEGORIAS Where CODIGO_CATEGORIA='" & Replace(Me._CODIGO_CATEGORIA, "'", "''") & "'", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._CODIGO_CATEGORIA = "" & dReader("CODIGO_CATEGORIA").ToString
                    Me._NOMBRE_CATEGORIA = Trim("" & dReader("NOMBRE_CATEGORIA").ToString)
                    Me._CODIGO_TIPO_CATEGORIA = Trim("" & dReader("CODIGO_TIPO_CATEGORIA").ToString)
                    Me.Estatus = "" & dReader("ESTATUS").ToString
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

    Public Overrides Function ObtenerElementos() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter(Me._QuerySELECT & Me._QueryOrder, Me._Conexion)
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
        Dim da As New SqlDataAdapter(Me._QuerySELECT & Me._QueryOrder, Me._Conexion)
        Try
            da.Fill(dTable)
            dTable.Rows.Add("-1", "TODOS")
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementosParaReportes", ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerElementosFiltro(ByVal Filtro As String, ByVal Estatus As String) As System.Data.DataTable
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter("SELECT C.CODIGO_CATEGORIA,C.NOMBRE_CATEGORIA,T.NOMBRE_TIPO_CATEGORIA " & _
                                     "FROM CAT_CATEGORIAS C INNER JOIN CAT_TIPOS_CATEGORIAS T ON(C.CODIGO_TIPO_CATEGORIA=T.CODIGO_TIPO_CATEGORIA)" & _
                                     "WHERE C.NOMBRE_CATEGORIA LIKE '" & Filtro.ToString & "%' AND C.ESTATUS='" & Estatus & "' ORDER BY C.NOMBRE_CATEGORIA", Me._Conexion)
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
        f.Text = "Búsqueda de categoria por codigo."
        f.sCampo = "CODIGO_CATEGORIA"
        f.sOrder = "NOMBRE_CATEGORIA"
        f.sTable = "CAT_CATEGORIAS"
        f.sQl = "SELECT CODIGO_CATEGORIA,NOMBRE_CATEGORIA FROM CAT_CATEGORIAS Where 1=1 And"
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
        f.Text = "Búsqueda de categorias por nombre."
        f.sCampo = "NOMBRE_CATEGORIA"
        f.sOrder = "NOMBRE_CATEGORIA"
        f.sTable = "CAT_CATEGORIAS"
        f.sQl = "SELECT CODIGO_CATEGORIA,NOMBRE_CATEGORIA FROM CAT_CATEGORIAS Where 1=1 AND ESTATUS='A' And"
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

    Public Function CodigoSiguiente() As String
        Dim Resultado As Integer
        Try
            Dim sql As New Class_find("SELECT ISNULL(MAX(CODIGO_CATEGORIA),0) FROM CAT_CATEGORIAS")
            Resultado = CType(sql.Result1, Integer) + 1
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "CodigoSiguiente", ex)
        End Try
        Return Resultado
    End Function
#End Region

End Class