Imports System.Data
Imports System.Data.SqlClient

Public Class Class_SisTiposProveedores
    Inherits Class_Catalogos

#Region "Campos"

#Region "Campos de la tabla"
    Private _Codigo_Tipo_Proveedor As String
    Private _Nombre_Tipo_Proveedor As String
    Private _Cuenta_Contable As String
    Private _ELEGIBLE_CATALOGO_PROVEEDORES As Boolean
    Private _REALIZA_COMPRAS_GASTOS_PAGOS As Boolean
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
    Public Property Codigo_Tipo_Proveedor() As String
        Get
            Return Me._Codigo_Tipo_Proveedor
        End Get
        Set(ByVal Value As String)
            Me._Codigo_Tipo_Proveedor = Value
        End Set
    End Property

    Public Property Nombre_Tipo_Proveedor() As String
        Get
            Return Me._Nombre_Tipo_Proveedor
        End Get
        Set(ByVal Value As String)
            Me._Nombre_Tipo_Proveedor = Value
        End Set
    End Property

    Public Property Cuenta_Contable() As String
        Get
            Return Me._Cuenta_Contable
        End Get
        Set(ByVal Value As String)
            Me._Cuenta_Contable = Value
        End Set
    End Property

    Public ReadOnly Property ELEGIBLE_CATALOGO_PROVEEDORES() As Boolean
        Get
            Return Me._ELEGIBLE_CATALOGO_PROVEEDORES
        End Get
    End Property

    Public Property REALIZA_COMPRAS_GASTOS_PAGOS() As Boolean
        Get
            Return Me._REALIZA_COMPRAS_GASTOS_PAGOS
        End Get
        Set(ByVal Value As Boolean)
            Me._REALIZA_COMPRAS_GASTOS_PAGOS = Value
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
        Me._Nombre_Catalogo = "SIS_TIPOS_PROVEEDORES"
        Me._Nombre_Reporte = "RPT_CATALOGO_TIPOS_PROVEEDORES"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "SELECT CODIGO_TIPO_PROVEEDOR,NOMBRE_TIPO_PROVEEDOR FROM SIS_TIPOS_PROVEEDORES"
        Me._QueryOrder = " ORDER BY NOMBRE_TIPO_PROVEEDOR"
    End Sub

    Public Sub New(ByVal sCodigoTipoProveedor As String)
        Me.New()
        Try
            Me._Codigo_Tipo_Proveedor = sCodigoTipoProveedor
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

#Region "Métodos y procedimientos"

    Public Overrides Function Insertar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_SIS_TIPOS_PROVEEDORES_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_TIPO_PROVEEDOR", SqlDbType.Char) : sqlParametro.Value = Me._Codigo_Tipo_Proveedor.ToString
            sqlParametro = .Parameters.Add("@NOMBRE_TIPO_PROVEEDOR", SqlDbType.NVarChar, 100) : sqlParametro.Value = Me._Nombre_Tipo_Proveedor.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CUENTA_CONTABLE", SqlDbType.NVarChar, 40) : sqlParametro.Value = Me._Cuenta_Contable.ToString
            sqlParametro = .Parameters.Add("@REALIZA_COMPRAS_GASTOS_PAGOS", SqlDbType.Char) : sqlParametro.Value = IIf(Me._REALIZA_COMPRAS_GASTOS_PAGOS = True, "1", "0").ToString
            sqlParametro = .Parameters.Add("@ACCION", SqlDbType.NVarChar, 20) : sqlParametro.Value = "INSERTAR"
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
            .CommandText = "MP_SIS_TIPOS_PROVEEDORES_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_TIPO_PROVEEDOR", SqlDbType.Char) : sqlParametro.Value = Me._Codigo_Tipo_Proveedor.ToString
            sqlParametro = .Parameters.Add("@NOMBRE_TIPO_PROVEEDOR", SqlDbType.NVarChar, 100) : sqlParametro.Value = Me._Nombre_Tipo_Proveedor.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CUENTA_CONTABLE", SqlDbType.NVarChar, 40) : sqlParametro.Value = Me._Cuenta_Contable.ToString
            sqlParametro = .Parameters.Add("@REALIZA_COMPRAS_GASTOS_PAGOS", SqlDbType.Char) : sqlParametro.Value = IIf(Me._REALIZA_COMPRAS_GASTOS_PAGOS = True, "1", "0").ToString
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
        Dim cmd As New SqlCommand("Select * from SIS_TIPOS_PROVEEDORES Where Codigo_TIPO_PROVEEDOR='" & Replace(Me._Codigo_Tipo_Proveedor, "'", "''") & "'", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._Codigo_Tipo_Proveedor = "" & dReader("CODIGO_TIPO_PROVEEDOR").ToString
                    Me._Nombre_Tipo_Proveedor = Trim("" & dReader("NOMBRE_TIPO_PROVEEDOR").ToString)
                    Me._Cuenta_Contable = "" & dReader("CUENTA_CONTABLE")
                    Me._ELEGIBLE_CATALOGO_PROVEEDORES = CBool(dReader("ELEGIBLE_CATALOGO_PROVEEDORES"))
                    Me._REALIZA_COMPRAS_GASTOS_PAGOS = CBool(dReader("REALIZA_COMPRAS_GASTOS_PAGOS"))
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
        Dim dsCAT_Lineas As New SqlDataAdapter(Me._QuerySelect & Me._QueryOrder, Me._Conexion)
        Try
            dsCAT_Lineas.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementos", ex)
        Finally
            dsCAT_Lineas.Dispose()
        End Try
        Return dTable
    End Function    'Obtiene una lita completa de los elementos del catalogo en un datatable.

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
        Dim da As New SqlDataAdapter("SELECT CODIGO_TIPO_PROVEEDOR, NOMBRE_TIPO_PROVEEDOR FROM SIS_TIPOS_PROVEEDORES WHERE NOMBRE_TIPO_PROVEEDOR LIKE '" & Filtro.ToString & "%' ORDER BY NOMBRE_TIPO_PROVEEDOR", Me._Conexion)
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
        f.Text = "Búsqueda de tipo de proveedor por codigo."
        f.sCampo = "Codigo_TIPO_PROVEEDOR"
        f.sOrder = "Nombre_TIPO_PROVEEDOR"
        f.sTable = "SIS_TIPOS_PROVEEDORES"
        f.sQl = "Select Codigo_TIPO_PROVEEDOR,Nombre_TIPO_PROVEEDOR From SIS_TIPOS_PROVEEDORES Where 1=1 And"
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
        f.Text = "Búsqueda de tipos de proveedores por nombre."
        f.sCampo = "Nombre_TIPO_PROVEEDOR"
        f.sOrder = "Nombre_TIPO_PROVEEDOR"
        f.sTable = "SIS_TIPOS_PROVEEDORES"
        f.sQl = "Select Codigo_TIPO_PROVEEDOR,Nombre_TIPO_PROVEEDOR From SIS_TIPOS_PROVEEDORES Where 1=1 And"
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
        Dim iTipoProveedor As Integer
        Dim sql As New Class_find("SELECT MAX(CODIGO_TIPO_PROVEEDOR) FROM SIS_TIPOS_PROVEEDORES")
        Try

            iTipoProveedor = sql.Result1
            iTipoProveedor = iTipoProveedor + 1
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "CodigoSiguiente", ex)
        End Try
        Return iTipoProveedor
    End Function

#End Region

End Class