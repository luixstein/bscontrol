Imports System.Data
Imports System.Data.SqlClient

Public Class Class_CatVendedores
    Inherits Class_Catalogos

#Region "Campos"

#Region "Campos de la tabla"
    Private _CODIGO_VENDEDOR As Integer
    Private _NOMBRE_VENDEDOR As String
    Private _Estatus As String
    Private _CODIGO_CATEGORIA As String
    Private _CODIGO_CENTRO_COSTO As Integer
    Private _Agregar As String
#End Region

#Region "Campos ligados a la tabla"
    Private _GENERAR_CATEGORIA As Boolean
    Private _CODIGO_TIPO_CATEGORIA As String
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
    Public Property CODIGO_VENDEDOR() As Integer
        Get
            Return Me._CODIGO_VENDEDOR
        End Get
        Set(ByVal Value As Integer)
            Me._CODIGO_VENDEDOR = Value
        End Set
    End Property

    Public Property NOMBRE_VENDEDOR() As String
        Get
            Return Me._NOMBRE_VENDEDOR
        End Get
        Set(ByVal Value As String)
            Me._NOMBRE_VENDEDOR = Value
        End Set
    End Property

    Public Property CODIGO_CATEGORIA() As String
        Get
            Return Me._CODIGO_CATEGORIA
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_CATEGORIA = Value
        End Set
    End Property

    Public Property CODIGO_CENTRO_COSTO() As Integer
        Get
            Return Me._CODIGO_CENTRO_COSTO
        End Get
        Set(ByVal Value As Integer)
            Me._CODIGO_CENTRO_COSTO = Value
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
    Public WriteOnly Property GENERAR_CATEGORIA() As Boolean
        Set(ByVal Value As Boolean)
            Me._GENERAR_CATEGORIA = Value
        End Set
    End Property

    Public WriteOnly Property CODIGO_TIPO_CATEGORIA() As String
        Set(ByVal Value As String)
            Me._CODIGO_TIPO_CATEGORIA = Value
        End Set
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
        Me._Nombre_Catalogo = "CAT_VENDEDORES"
        Me._Nombre_Reporte = "RPT_CATALOGO_VENDEDORES"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "Select CODIGO_VENDEDOR,NOMBRE_VENDEDOR From CAT_VENDEDORES"
        Me._QueryOrder = " Order by NOMBRE_VENDEDOR"
    End Sub

    Protected Overrides Sub Finalize()
        'Me._Conexion.Dispose()
        MyBase.Finalize()
    End Sub
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
            .CommandText = "MP_CAT_VENDEDORES_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_VENDEDOR", SqlDbType.SmallInt, 2) : sqlParametro.Value = Me._CODIGO_VENDEDOR : sqlParametro.Direction = ParameterDirection.InputOutput
            sqlParametro = .Parameters.Add("@NOMBRE_VENDEDOR", SqlDbType.NVarChar, 50) : sqlParametro.Value = Me._NOMBRE_VENDEDOR.ToString.ToUpper
            sqlParametro = .Parameters.Add("@ESTATUS", SqlDbType.Char, 1) : sqlParametro.Value = Me._Estatus.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_CATEGORIA", SqlDbType.SmallInt) : sqlParametro.Value = CInt(valorNumerico(Me._CODIGO_CATEGORIA)) : sqlParametro.Direction = ParameterDirection.InputOutput
            sqlParametro = .Parameters.Add("@GENERAR_CATEGORIA", SqlDbType.Char, 1) : sqlParametro.Value = Convert.ToInt32(Me._GENERAR_CATEGORIA)
            sqlParametro = .Parameters.Add("@CODIGO_TIPO_CATEGORIA", SqlDbType.SmallInt) : sqlParametro.Value = CInt(valorNumerico(Me._CODIGO_TIPO_CATEGORIA))
            sqlParametro = .Parameters.Add("@CODIGO_CENTRO_COSTO", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_CENTRO_COSTO
            sqlParametro = .Parameters.Add("@AGREGAR", SqlDbType.NVarChar, 1) : sqlParametro.Value = Me._Agregar

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
                Me._CODIGO_VENDEDOR = "" & .Parameters("@CODIGO_VENDEDOR").Value.ToString
                Me._CODIGO_CATEGORIA = "" & .Parameters("@CODIGO_CATEGORIA").Value.ToString
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

    Public Overrides Function Actualizar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CAT_VENDEDORES_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_VENDEDOR", SqlDbType.SmallInt, 2) : sqlParametro.Value = Me._CODIGO_VENDEDOR
            sqlParametro = .Parameters.Add("@NOMBRE_VENDEDOR", SqlDbType.NVarChar, 50) : sqlParametro.Value = Me._NOMBRE_VENDEDOR.ToString.ToUpper
            sqlParametro = .Parameters.Add("@ESTATUS", SqlDbType.Char, 1) : sqlParametro.Value = Me._Estatus.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_CATEGORIA", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_CATEGORIA
            sqlParametro = .Parameters.Add("@GENERAR_CATEGORIA", SqlDbType.Char, 1) : sqlParametro.Value = "0"
            sqlParametro = .Parameters.Add("@CODIGO_TIPO_CATEGORIA", SqlDbType.SmallInt) : sqlParametro.Value = 0
            sqlParametro = .Parameters.Add("@CODIGO_CENTRO_COSTO", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_CENTRO_COSTO
            sqlParametro = .Parameters.Add("@AGREGAR", SqlDbType.NVarChar, 1) : sqlParametro.Value = Me._Agregar

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
        Dim cmd As New SqlCommand("SELECT * FROM CAT_VENDEDORES WHERE CODIGO_VENDEDOR=" & Replace(Me._CODIGO_VENDEDOR, "'", "''") & "", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._CODIGO_VENDEDOR = "" & dReader("CODIGO_VENDEDOR")
                    Me._NOMBRE_VENDEDOR = Trim("" & dReader("NOMBRE_VENDEDOR").ToString)
                    Me._Estatus = "" & dReader("ESTATUS").ToString
                    Me._CODIGO_CATEGORIA = "" & dReader("CODIGO_CATEGORIA")
                    Me._CODIGO_CENTRO_COSTO = "" & dReader("CODIGO_CENTRO_COSTO")
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
        Dim da As New SqlDataAdapter("SELECT CODIGO_VENDEDOR,NOMBRE_VENDEDOR FROM CAT_VENDEDORES ORDER BY NOMBRE_VENDEDOR", Me._Conexion)
        Try
            da.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementos", ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerElementosFiltro(ByVal Filtro As String) As System.Data.DataTable
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter("SELECT CODIGO_VENDEDOR,NOMBRE_VENDEDOR FROM CAT_VENDEDORES WHERE NOMBRE_VENDEDOR LIKE '" & Filtro.ToString & "%' ORDER BY NOMBRE_VENDEDOR", Me._Conexion)
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
        f.Text = "Búsqueda de Metodos de Vendedores por codigo."
        f.sCampo = "CODIGO_VENDEDOR"
        f.sOrder = "NOMBRE_VENDEDOR"
        f.sTable = "CAT_VENDEDORES"
        f.sQl = "SELECT Id_Vendedor,NOMBRE_VENDEDOR FROM CAT_VENDEDORES WHERE 1=1 AND"
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
        f.sCampo = "NOMBRE_VENDEDOR"
        f.sOrder = "NOMBRE_VENDEDOR"
        f.sTable = "CAT_VENDEDORES"
        f.sQl = "SELECT CODIGO_VENDEDOR,NOMBRE_VENDEDOR FROM CAT_VENDEDORES WHERE 1=1 AND"
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
        Try
            Dim sql As New Class_find("SELECT ISNULL(MAX(CODIGO_VENDEDOR),0) FROM CAT_VENDEDORES")

            iCodigo = CInt(sql.Result1) + 1
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "codigoSiguiente", ex)
        End Try
        Return iCodigo
    End Function
#End Region

End Class
