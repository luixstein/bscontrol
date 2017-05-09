Imports System.Data
Imports System.Data.SqlClient

Public Class Class_CatAlmacenes
    Inherits Class_Catalogos

#Region "Campos"

#Region "Campos de la tabla"
    Private _CODIGO_ALMACEN As String
    Private _NOMBRE_ALMACEN As String
    Private _CUENTA_CONTABLE As String
    Private _CODIGO_ZONA As String
    Private _CODIGO_CATEGORIA As String
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
    Private _QuerySELECT As String
    Private _QueryOrder As String

#End Region

#End Region

#Region "Propiedades"

#Region "Propiedades Campos de la tabla"
    Public Property CODIGO_ALMACEN() As String
        Get
            Return Me._CODIGO_ALMACEN
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_ALMACEN = Value
        End Set
    End Property

    Public Property NOMBRE_ALMACEN() As String
        Get
            Return Me._NOMBRE_ALMACEN
        End Get
        Set(ByVal Value As String)
            Me._NOMBRE_ALMACEN = Value
        End Set
    End Property

    Public ReadOnly Property CUENTA_CONTABLE() As String
        Get
            Return Me._CUENTA_CONTABLE
        End Get
    End Property

    Public Property CODIGO_ZONA() As String
        Get
            Return Me._CODIGO_ZONA
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_ZONA = Value
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

#End Region

#End Region

#Region "Constructor y destructor"

    Public Sub New()
        Me._Nombre_Catalogo = "CAT_ALMACENES"
        Me._Nombre_Reporte = "RPT_CATALOGO_ALMACENES"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySELECT = "SELECT CODIGO_ALMACEN,NOMBRE_ALMACEN FROM CAT_ALMACENES"
        Me._QueryOrder = " Order by NOMBRE_ALMACEN"
    End Sub

    Public Sub New(ByVal sAlmacen As String)
        Me.New()
        Try
            Me.CODIGO_ALMACEN = sAlmacen
            If Me.Consultar = False Then
                Throw New Exception("El almacén no existe.")
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
            .CommandText = "MP_CAT_ALMACENES_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_ALMACEN", SqlDbType.NVarChar, 4) : sqlParametro.Value = Me._CODIGO_ALMACEN.ToUpper
            sqlParametro = .Parameters.Add("@NOMBRE_ALMACEN", SqlDbType.NVarChar, 30) : sqlParametro.Value = Me._NOMBRE_ALMACEN.ToString.ToUpper
            sqlParametro = .Parameters.Add("@Estatus", SqlDbType.Char, 1) : sqlParametro.Value = Me.Estatus.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_PLAZA", SqlDbType.Char, 1) : sqlParametro.Value = Usuario.Codigo_Plaza
            sqlParametro = .Parameters.Add("@CODIGO_ZONA", SqlDbType.NVarChar, 2) : sqlParametro.Value = Me._CODIGO_ZONA
            sqlParametro = .Parameters.Add("@CODIGO_CATEGORIA", SqlDbType.SmallInt) : sqlParametro.Value = CInt(valorNumerico(Me._CODIGO_CATEGORIA))
            sqlParametro = .Parameters.Add("@GENERAR_CATEGORIA", SqlDbType.Char, 1) : sqlParametro.Value = Convert.ToInt32(Me._GENERAR_CATEGORIA)
            sqlParametro = .Parameters.Add("@CODIGO_TIPO_CATEGORIA", SqlDbType.SmallInt) : sqlParametro.Value = CInt(valorNumerico(Me._CODIGO_TIPO_CATEGORIA))
            sqlParametro = .Parameters.Add("@Agregar", SqlDbType.Char, 1) : sqlParametro.Value = "1"

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
            .CommandText = "MP_CAT_ALMACENES_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_ALMACEN", SqlDbType.NVarChar, 4) : sqlParametro.Value = Me._CODIGO_ALMACEN.ToUpper
            sqlParametro = .Parameters.Add("@NOMBRE_ALMACEN", SqlDbType.NVarChar, 30) : sqlParametro.Value = Me._NOMBRE_ALMACEN.ToString.ToUpper
            sqlParametro = .Parameters.Add("@ESTATUS", SqlDbType.Char, 1) : sqlParametro.Value = Me.Estatus.ToString.ToUpper
            'sqlParametro = .Parameters.Add("@CUENTA_CONTABLE", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._CUENTA_CONTABLE
            sqlParametro = .Parameters.Add("@CODIGO_PLAZA", SqlDbType.Char, 1) : sqlParametro.Value = Usuario.Codigo_Plaza
            sqlParametro = .Parameters.Add("@CODIGO_ZONA", SqlDbType.NVarChar, 2) : sqlParametro.Value = Me._CODIGO_ZONA
            sqlParametro = .Parameters.Add("@CODIGO_CATEGORIA", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_CATEGORIA
            sqlParametro = .Parameters.Add("@GENERAR_CATEGORIA", SqlDbType.Char, 1) : sqlParametro.Value = "0"
            sqlParametro = .Parameters.Add("@CODIGO_TIPO_CATEGORIA", SqlDbType.SmallInt) : sqlParametro.Value = 0
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
        Dim cmd As New SqlCommand("SELECT * FROM CAT_ALMACENES WHERE CODIGO_ALMACEN='" & Replace(Me._CODIGO_ALMACEN, "'", "''") & "'", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._CODIGO_ALMACEN = "" & dReader("CODIGO_ALMACEN").ToString
                    Me._NOMBRE_ALMACEN = Trim("" & dReader("NOMBRE_ALMACEN").ToString)
                    Me._CUENTA_CONTABLE = Trim("" & dReader("CUENTA_CONTABLE").ToString)
                    Me.Estatus = "" & dReader("ESTATUS").ToString
                    Me._CODIGO_ZONA = "" & dReader("CODIGO_ZONA").ToString
                    Me._CODIGO_CATEGORIA = "" & dReader("CODIGO_CATEGORIA").ToString
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
        Dim dsCAT_ALMACENES As New SqlDataAdapter(Me._QuerySELECT & Me._QueryOrder, Me._Conexion)
        Try
            dsCAT_ALMACENES.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementos", ex)
        Finally
            dsCAT_ALMACENES.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerAlmacenes() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter("SELECT CODIGO_ALMACEN,NOMBRE_ALMACEN FROM CAT_ALMACENES WHERE ESTATUS='A'", Me._Conexion)
        Try
            da.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerAlmacenes", ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerAlmacenesParaReportes() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter("SELECT CODIGO_ALMACEN,NOMBRE_ALMACEN FROM CAT_ALMACENES WHERE ESTATUS='A'", Me._Conexion)
        Try
            da.Fill(dTable)
            dTable.Rows.Add("T", "TODOS")
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerAlmacenesParaReportes", ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

    Public Sub ObtenerAlmacenesUsuarios(ByRef LST As ListBox)
        Dim cmd As New SqlCommand("SELECT CODIGO_ALMACEN,NOMBRE_ALMACEN FROM VW_CAT_REL_ALMACENES_USUARIOS WHERE CODIGO_USUARIO='" & Replace(Usuario.Codigo_Usuario, "'", "''") & "'", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.HasRows Then
                    While dReader.Read()
                        LST.Items.Add(dReader("NOMBRE_ALMACEN").ToString)
                    End While
                End If
                dReader.Close()
            Catch ex As Exception
                HandleError(Me.Nombre_Catalogo, "ObtenerAlmacenesUsuarios", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
            End Try
        End With
    End Sub

    Public Function ObtenerElementosFiltro(ByVal Filtro As String, ByVal Estatus As String) As System.Data.DataTable
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter("SELECT CODIGO_ALMACEN,NOMBRE_ALMACEN FROM CAT_ALMACENES WHERE NOMBRE_ALMACEN LIKE '" & Filtro.ToString & "%' AND ESTATUS='" & Estatus & "' ORDER BY NOMBRE_ALMACEN", Me._Conexion)
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
        f.Text = "Búsqueda de Metodos de Almacenes por codigo."
        f.sCampo = "CODIGO_ALMACEN"
        f.sOrder = "NOMBRE_ALMACEN"
        f.sTable = "CAT_ALMACENES"
        f.sQl = "SELECT CODIGO_ALMACEN,NOMBRE_ALMACEN FROM CAT_ALMACENES WHERE 1=1 And"
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
        f.Text = "Búsqueda de Almacenes por Descripción."
        f.sCampo = "NOMBRE_ALMACEN"
        f.sOrder = "NOMBRE_ALMACEN"
        f.sTable = "CAT_ALMACENES"
        f.sQl = "SELECT CODIGO_ALMACEN,NOMBRE_ALMACEN FROM CAT_ALMACENES WHERE 1=1 And"
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
        Dim iAlmacen As Integer, sAlmacen As String
        Dim Resultado As String = ""
        Try
            iAlmacen = Empresa_Sistema.CODIGO_ALMACEN
            iAlmacen = iAlmacen + 1
            sAlmacen = "0000" + iAlmacen.ToString
            Resultado = sAlmacen.Substring(Len(sAlmacen) - 4)
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "CodigoSiguiente", ex)
        End Try
        Return Resultado
    End Function
#End Region

End Class



