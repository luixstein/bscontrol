Imports System.Data
Imports System.Data.SqlClient

Public Class Class_CatParametrosAcuicola
    Inherits Class_Catalogos

#Region "Campos"

#Region "Campos de la tabla"
    Private _Codigo_Parametro As String
    Private _Nombre_Parametro As String
    Private _Tipo_dato As String
    Private _Tipo_Informacion As String
    Private _Estatus As String
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
    Public Property Codigo_Parametro() As String
        Get
            Return Me._Codigo_Parametro
        End Get
        Set(ByVal Value As String)
            Me._Codigo_Parametro = Value
        End Set
    End Property

    Public Property Nombre_Parametro() As String
        Get
            Return Me._Nombre_Parametro
        End Get
        Set(ByVal Value As String)
            Me._Nombre_Parametro = Value
        End Set
    End Property

    Public Property Tipo_Dato() As String
        Get
            Return Me._Tipo_dato
        End Get
        Set(ByVal Value As String)
            Me._Tipo_dato = Value
        End Set
    End Property

    Public Property Tipo_Informacion() As String
        Get
            Return Me._Tipo_Informacion
        End Get
        Set(ByVal Value As String)
            Me._Tipo_Informacion = Value
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
        Me._Nombre_Catalogo = "CAT_PARAMETROS"
        Me._Nombre_Reporte = "RPT_CATALOGO_PARAMETROS"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "Select * From CAT_PARAMETROS_ACUICOLA"
        Me._QueryOrder = " Order by Nombre_Parametro"
    End Sub                                                         'Inicializa al objeto.

    Public Sub New(ByVal sCodigoParametro As String)
        Me.New()
        Try
            Me._Codigo_Parametro = sCodigoParametro
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
            .CommandText = "MP_CAT_PARAMETROS_ACUICOLA_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_PARAMETRO", SqlDbType.SmallInt) : sqlParametro.Value = CInt(Me._Codigo_Parametro)
            sqlParametro = .Parameters.Add("@NOMBRE_PARAMETRO", SqlDbType.NVarChar, 100) : sqlParametro.Value = Me._Nombre_Parametro.ToUpper
            sqlParametro = .Parameters.Add("@TIPO_DATO", SqlDbType.Char, 1) : sqlParametro.Value = Me._Tipo_dato.ToString.ToUpper
            sqlParametro = .Parameters.Add("@TIPO_INFORMACION", SqlDbType.Char, 1) : sqlParametro.Value = Me._Tipo_Informacion.ToString.ToUpper
            sqlParametro = .Parameters.Add("@ESTATUS", SqlDbType.Char, 1) : sqlParametro.Value = Me.Estatus.ToString.ToUpper
            sqlParametro = .Parameters.Add("@AGREGAR", SqlDbType.Char, 1) : sqlParametro.Value = "1"
            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                Me._Codigo_Parametro = .Parameters("@CODIGO_PARAMETRO").Value.ToString
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
            .CommandText = "MP_CAT_PARAMETROS_ACUICOLA_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_PARAMETRO", SqlDbType.SmallInt) : sqlParametro.Value = CInt(Me._Codigo_Parametro)
            sqlParametro = .Parameters.Add("@NOMBRE_PARAMETRO", SqlDbType.NVarChar, 100) : sqlParametro.Value = Me._Nombre_Parametro.ToUpper
            sqlParametro = .Parameters.Add("@TIPO_DATO", SqlDbType.Char, 1) : sqlParametro.Value = Me._Tipo_dato.ToString.ToUpper
            sqlParametro = .Parameters.Add("@TIPO_INFORMACION", SqlDbType.Char, 1) : sqlParametro.Value = Me._Tipo_Informacion.ToString.ToUpper
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
        Dim cmd As New SqlCommand("Select * from Cat_Parametros_Acuicola Where Codigo_Parametros='" & Replace(Me._Codigo_Parametro, "'", "''") & "'", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._Codigo_Parametro = "" & dReader("CODIGO_PARAMETRO").ToString
                    Me._Nombre_Parametro = Trim("" & dReader("NOMBRE_PARAMETRO").ToString)
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

    Public Function ObtenerElementosFiltro(ByVal Filtro As String) As System.Data.DataTable
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter("SELECT CODIGO_PARAMETRO, NOMBRE_PARAMETRO, TIPO_DATO, TIPO_INFORMACION FROM CAT_PARAMETROS_ACUICOLA WHERE NOMBRE_PARAMETRO LIKE '" & Filtro.ToString & "%' ORDER BY NOMBRE_PARAMETRO", Me._Conexion)
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
        f.Text = "Búsqueda de parametros por codigo."
        f.sCampo = "Codigo_PARAMETRO"
        f.sOrder = "Nombre_PARAMETRO"
        f.sTable = "CAT_PARAMETROS_ACUICOLA"
        f.sQl = "Select Codigo_PARAMETRO,Nombre_PARAMETRO From CAT_PARAMETROS_ACUICOLA Where 1=1 And"
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
        f.Text = "Búsqueda de parametros por nombre."
        f.sCampo = "Nombre_PARAMETRO"
        f.sOrder = "Nombre_PARAMETRO"
        f.sTable = "CAT_PARAMETROS_ACUICOLA"
        f.sQl = "Select Codigo_PARAMETRO,Nombre_PARAMETRO From CAT_PARAMETROS_ACUICOLA Where 1=1 And ESTATUS='A' AND "
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
            Dim sql As New Class_find("SELECT ISNULL(MAX(CODIGO_PARAMETRO),0) FROM CAT_PARAMETROS_ACUICOLA")
            Resultado = CType(sql.Result1, Integer) + 1
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "CodigoSiguiente", ex)
        End Try
        Return Resultado
    End Function
#End Region

End Class
