Imports System.Data
Imports System.Data.SqlClient

Public Class Class_CatVehiculos
    Inherits Class_Catalogos

#Region "Campos"

#Region "Campos de la tabla"
    Private _CODIGO_VEHICULO As String
    Private _Nombre_Vehiculo As String
    Private _Estatus As String
    Private _CODIGO_CATEGORIA As String
#End Region

#Region "Campos ligados a la tabla"
    Private _Existe As Boolean
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
    Public Property CODIGO_VEHICULO() As String
        Get
            Return Me._CODIGO_VEHICULO
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_VEHICULO = Value
        End Set
    End Property

    Public Property Nombre_Vehiculo() As String
        Get
            Return Me._Nombre_Vehiculo
        End Get
        Set(ByVal Value As String)
            Me._Nombre_Vehiculo = Value
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
    Public ReadOnly Property Existe() As Boolean
        Get
            Return Me._Existe
        End Get
    End Property

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
        Me._Nombre_Catalogo = "CAT_VEHICULOS"
        Me._Nombre_Reporte = "RPT_CAT_Vehiculo.rpt"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "Select * From CAT_VEHICULOS"
        Me._QueryOrder = " Order by Nombre_Vehiculo"
    End Sub                                                         'Inicializa al objeto.

    Public Sub New(ByVal sCodigoVehiculo As String)
        Me.New()
        Try
            Me._CODIGO_VEHICULO = sCodigoVehiculo
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
            .CommandText = "MP_CAT_VEHICULOS_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_VEHICULO", SqlDbType.SmallInt) : sqlParametro.Value = CInt(Me._CODIGO_VEHICULO) : sqlParametro.Direction = ParameterDirection.InputOutput
            sqlParametro = .Parameters.Add("@NOMBRE_VEHICULO", SqlDbType.NVarChar, 50) : sqlParametro.Value = Me._Nombre_Vehiculo.ToString.ToUpper
            sqlParametro = .Parameters.Add("@ESTATUS", SqlDbType.Char, 1) : sqlParametro.Value = Me._Estatus
            sqlParametro = .Parameters.Add("@CODIGO_CATEGORIA", SqlDbType.SmallInt) : sqlParametro.Value = CInt(valorNumerico(Me._CODIGO_CATEGORIA)) : sqlParametro.Direction = ParameterDirection.InputOutput
            sqlParametro = .Parameters.Add("@GENERAR_CATEGORIA", SqlDbType.Char, 1) : sqlParametro.Value = Convert.ToInt32(Me._GENERAR_CATEGORIA)
            sqlParametro = .Parameters.Add("@CODIGO_TIPO_CATEGORIA", SqlDbType.SmallInt) : sqlParametro.Value = CInt(valorNumerico(Me._CODIGO_TIPO_CATEGORIA))
            sqlParametro = .Parameters.Add("@ACCION", SqlDbType.NVarChar, 20) : sqlParametro.Value = "INSERTAR"
            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
                Me._CODIGO_VEHICULO = "" & .Parameters("@CODIGO_VEHICULO").Value.ToString
                Me._CODIGO_CATEGORIA = "" & .Parameters("@CODIGO_CATEGORIA").Value.ToString
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
            .CommandText = "MP_CAT_VEHICULOS_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_VEHICULO", SqlDbType.SmallInt) : sqlParametro.Value = CInt(Me._CODIGO_VEHICULO)
            sqlParametro = .Parameters.Add("@NOMBRE_VEHICULO", SqlDbType.NVarChar, 50) : sqlParametro.Value = Me._Nombre_Vehiculo.ToString.ToUpper
            sqlParametro = .Parameters.Add("@ESTATUS", SqlDbType.Char, 1) : sqlParametro.Value = Me._Estatus
            sqlParametro = .Parameters.Add("@CODIGO_CATEGORIA", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_CATEGORIA
            sqlParametro = .Parameters.Add("@GENERAR_CATEGORIA", SqlDbType.Char, 1) : sqlParametro.Value = "0"
            sqlParametro = .Parameters.Add("@CODIGO_TIPO_CATEGORIA", SqlDbType.SmallInt) : sqlParametro.Value = 0
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
        Dim cmd As New SqlCommand("Select * from CAT_VEHICULOS Where CODIGO_VEHICULO='" & sReplace(Me._CODIGO_VEHICULO) & "'", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._CODIGO_VEHICULO = "" & dReader("CODIGO_VEHICULO").ToString
                    Me._Nombre_Vehiculo = Trim("" & dReader("NOMBRE_VEHICULO").ToString)
                    Me._Estatus = "" & dReader("ESTATUS")
                    Me._CODIGO_CATEGORIA = "" & dReader("CODIGO_CATEGORIA").ToString
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
        Dim da As New SqlDataAdapter(Me._QuerySelect & Me._QueryOrder, Me._Conexion)
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
            dTable.Rows.Add("-1", "TODOS")
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementosParaReportes", ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerElementosFiltro(ByVal Filtro As String, ByVal ESTATUS As String) As System.Data.DataTable
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter("SELECT CODIGO_VEHICULO, NOMBRE_VEHICULO FROM CAT_VEHICULOS WHERE NOMBRE_VEHICULO LIKE '" & Filtro.ToString & "%' AND ESTATUS='" & ESTATUS & "' ORDER BY NOMBRE_VEHICULO", Me._Conexion)
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
        f.sCampo = "CODIGO_VEHICULO"
        f.sOrder = "Nombre_VEHICULO"
        f.sTable = "CAT_VEHICULOS"
        f.sQl = "Select CODIGO_VEHICULO,Nombre_VEHICULO From CAT_VEHICULOS Where 1=1 And"
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
        f.sCampo = "Nombre_VEHICULO"
        f.sOrder = "Nombre_VEHICULO"
        f.sTable = "CAT_VEHICULOS"
        f.sQl = "Select CODIGO_VEHICULO,Nombre_VEHICULO From CAT_VEHICULOS Where 1=1 And"
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
            Dim sql As New Class_find("SELECT ISNULL(MAX(CODIGO_VEHICULO),0) FROM CAT_VEHICULOS")
            Resultado = CType(sql.Result1, Integer) + 1
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "CodigoSiguiente", ex)
        End Try
        Return Resultado
    End Function
#End Region

#Region "Eventos de objetos"


#Region "Eventos de la lista de elementos"

#End Region

#Region " Eventos de TxtFiltro"

#End Region

#Region "Eventos Genericos"

#End Region


#Region "Keydown específicos"


#End Region

#Region "Validating específicos"

#End Region



#End Region

End Class