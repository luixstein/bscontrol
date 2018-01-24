Imports System.Data
Imports System.Data.SqlClient

Public Class Class_CatFormulas
    Inherits Class_Catalogos

#Region "Campos"

#Region "Campos de la tabla"
    Private _CODIGO_FORMULA As String
    Private _NOMBRE_FORMULA As String
    Private _CODIGO_ARTICULO As String
#End Region

#Region "Campos ligados a la tabla"

#End Region

#Region "Campos públicos"
    Public oFormulasDetalle As Class_CatFormulas_Detalle
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
    Public Property CODIGO_FORMULA() As String
        Get
            Return Me._CODIGO_FORMULA
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_FORMULA = Value
        End Set
    End Property

    Public Property NOMBRE_FORMULA() As String
        Get
            Return Me._NOMBRE_FORMULA
        End Get
        Set(ByVal Value As String)
            Me._NOMBRE_FORMULA = Value
        End Set
    End Property

    Public Property CODIGO_ARTICULO() As String
        Get
            Return Me._CODIGO_ARTICULO
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_ARTICULO = Value
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

#End Region

#End Region

#Region "Constructor y destructor"

    Public Sub New()
        Me._Nombre_Catalogo = "CAT_FORMULAS"
        Me._Nombre_Reporte = "RPT_CATALOGO_FORMULAS"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySELECT = "SELECT CODIGO_FORMULA,NOMBRE_FORMULA,CODIGO_ARTICULO,ESTATUS FROM CAT_FORMULAS"
        Me._QueryOrder = " Order by NOMBRE_FORMULA"
    End Sub

    Public Sub New(ByVal sFormula As String)
        Me.New()
        Try
            Me.CODIGO_FORMULA = sFormula
            If Me.Consultar = False Then
                Throw New Exception("La fórmula no existe.")
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
            .CommandText = "MP_CAT_FORMULAS_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_FORMULA", SqlDbType.Int) : sqlParametro.Value = 0 'El codigo lo genera el stored al insertar
            sqlParametro = .Parameters.Add("@NOMBRE_FORMULA", SqlDbType.NVarChar, 50) : sqlParametro.Value = Me._NOMBRE_FORMULA.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_ARTICULO", SqlDbType.NVarChar, 16) : sqlParametro.Value = Me._CODIGO_ARTICULO.ToString
            sqlParametro = .Parameters.Add("@ESTATUS", SqlDbType.Char, 1) : sqlParametro.Value = Me.Estatus.ToString.ToUpper
            sqlParametro = .Parameters.Add("@AGREGAR", SqlDbType.Char, 1) : sqlParametro.Value = "1"

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
                Me._CODIGO_FORMULA = "" & .Parameters("@CODIGO_FORMULA").Value.ToString

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
            .CommandText = "MP_CAT_FORMULAS_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_FORMULA", SqlDbType.Int) : sqlParametro.Value = CInt(Me._CODIGO_FORMULA)
            sqlParametro = .Parameters.Add("@NOMBRE_FORMULA", SqlDbType.NVarChar, 50) : sqlParametro.Value = Me._NOMBRE_FORMULA.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_ARTICULO", SqlDbType.NVarChar, 16) : sqlParametro.Value = Me._CODIGO_ARTICULO.ToString
            sqlParametro = .Parameters.Add("@ESTATUS", SqlDbType.Char, 1) : sqlParametro.Value = Me.Estatus.ToString.ToUpper
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
        Dim cmd As New SqlCommand("SELECT * FROM CAT_FORMULAS WHERE CODIGO_FORMULA=" & Me._CODIGO_FORMULA, Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._CODIGO_FORMULA = "" & dReader("CODIGO_FORMULA").ToString
                    Me._NOMBRE_FORMULA = Trim("" & dReader("NOMBRE_FORMULA").ToString)
                    Me._CODIGO_ARTICULO = "" & dReader("CODIGO_ARTICULO").ToString
                    Me.Estatus = "" & dReader("ESTATUS").ToString
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

    Public Overrides Function ObtenerElementos() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dsCAT_FORMULAS As New SqlDataAdapter(Me._QuerySELECT & Me._QueryOrder, Me._Conexion)
        Try
            dsCAT_FORMULAS.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementos", ex)
        Finally
            dsCAT_FORMULAS.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerFormulasParaReportes() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter("SELECT CODIGO_FORMULAS,NOMBRE_FORMULA FROM CAT_FORMULAS WHERE ESTATUS='A'", Me._Conexion)
        Try
            da.Fill(dTable)
            dTable.Rows.Add("T", "TODAS")
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerFormulasParaReportes", ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerElementosFiltro(ByVal Filtro As String, ByVal Estatus As String) As System.Data.DataTable
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter("SELECT CODIGO_FORMULA,NOMBRE_FORMULA FROM CAT_FORMULAS WHERE NOMBRE_FORMULA LIKE '" & Filtro.ToString & "%' AND ESTATUS='" & Estatus & "' ORDER BY NOMBRE_FORMULA", Me._Conexion)
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
        f.Text = "Búsqueda de Metodos de Fórmulas por codigo."
        f.sCampo = "CODIGO_FORMULA"
        f.sOrder = "NOMBRE_FORMULA"
        f.sTable = "CAT_FORMULAS"
        f.sQl = "SELECT CODIGO_FORMULA,NOMBRE_FORMULA FROM CAT_FORMULAS WHERE 1=1 And"
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
        f.Text = "Búsqueda de Fórmulas por Descripción."
        f.sCampo = "NOMBRE_FORMULA"
        f.sOrder = "NOMBRE_FORMULA"
        f.sTable = "CAT_FORMULAS"
        f.sQl = "SELECT CODIGO_FORMULA,NOMBRE_FORMULA FROM CAT_FORMULAS WHERE 1=1 And"
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
            Dim sql As New Class_find("SELECT ISNULL(MAX(CODIGO_FORMULA) + 1,1) FROM CAT_FORMULAS")

            Resultado = sql.Result1.ToString

        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "CodigoSiguiente", ex)
        End Try
        Return Resultado
    End Function

    Public Sub NuevoRenglon()
        Me.oFormulasDetalle = New Class_CatFormulas_Detalle
    End Sub

    Public Function ObtenerDetalle(ByVal sCodigoFormula As String) As System.Data.DataTable
        Dim dTabla As New DataTable("detalle"), da As SqlDataAdapter
        Dim sSQL As String
        sSQL = "SELECT F.CODIGO_ARTICULO,A.DESCRIPCION,F.CANTIDAD,F.ID_FORMULA_DETALLE FROM CAT_FORMULAS_DETALLE F " & _
            "INNER JOIN CAT_ARTICULOS A ON(F.CODIGO_ARTICULO=A.CODIGO_ARTICULO) WHERE F.CODIGO_FORMULA =" & sCodigoFormula & " ORDER BY F.ID_FORMULA_DETALLE "
        Try
            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dTabla)
            da.Dispose()
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "ObtenerDetalleOrdenCompra", ex)
        End Try
        Return dTabla
    End Function
#End Region

End Class



