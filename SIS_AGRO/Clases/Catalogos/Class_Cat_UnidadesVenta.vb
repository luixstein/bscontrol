Imports System.Data
Imports System.Data.SqlClient

Public Class Class_CatUnidadesVenta
    Inherits Class_Catalogos

#Region "Campos"

#Region "Campos de la tabla"
    Private _Id_Unidad_Venta
    Private _Codigo_Unidad_Venta As String
    Private _Nombre_Unidad_Venta As String

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
    Public Property Id_Unidad_Venta() As Integer
        Get
            Return Me._Id_Unidad_Venta
        End Get
        Set(ByVal Value As Integer)
            Me._Id_Unidad_Venta = Value
        End Set
    End Property
    Public Property Codigo_Unidad_Venta() As String
        Get
            Return Me._Codigo_Unidad_Venta
        End Get
        Set(ByVal Value As String)
            Me._Codigo_Unidad_Venta = Value
        End Set
    End Property

    Public Property Nombre_Unidad_Venta() As String
        Get
            Return Me._Nombre_Unidad_Venta
        End Get
        Set(ByVal Value As String)
            Me._Nombre_Unidad_Venta = Value
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
        Me._Nombre_Catalogo = "CAT_UNIDADES_VENTA"
        Me._Nombre_Reporte = "RPT_CAT_Unidades_Venta.rpt"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "Select Id_Unidad_Venta,Codigo_Unidad_Venta,Nombre_Unidad_Venta From CAT_UNIDADES_VENTA"
        Me._QueryOrder = " Order by Nombre_Unidad_Venta"
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
            .CommandText = "MP_CAT_UNIDADES_VENTA_GRABA"

            sqlParametro = .Parameters.Add("@ID_UNIDAD_VENTA", SqlDbType.Int) : sqlParametro.Value = 0
            sqlParametro = .Parameters.Add("@CODIGO_UNIDAD_VENTA", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._Codigo_Unidad_Venta.ToString.ToUpper
            sqlParametro = .Parameters.Add("@NOMBRE_UNIDAD_VENTA", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._Nombre_Unidad_Venta.ToString.ToUpper
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
            .CommandText = "MP_CAT_UNIDADES_VENTA_GRABA"

            sqlParametro = .Parameters.Add("@ID_UNIDAD_VENTA", SqlDbType.Int) : sqlParametro.Value = Me._Id_Unidad_Venta
            sqlParametro = .Parameters.Add("@CODIGO_UNIDAD_VENTA", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._Codigo_Unidad_Venta.ToString.ToUpper
            sqlParametro = .Parameters.Add("@NOMBRE_UNIDAD_VENTA", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._Nombre_Unidad_Venta.ToString.ToUpper
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
        Dim cmd As New SqlCommand("Select * from CAT_UNIDADES_VENTA Where Codigo_Unidad_Venta='" & Replace(Me._Codigo_Unidad_Venta, "'", "''") & "'", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._Id_Unidad_Venta = dReader("ID_UNIDAD_VENTA")
                    Me._Codigo_Unidad_Venta = Trim("" & dReader("CODIGO_UNIDAD_VENTA").ToString)
                    Me._Nombre_Unidad_Venta = Trim("" & dReader("NOMBRE_UNIDAD_VENTA").ToString)
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
        Dim da As New SqlDataAdapter("Select Codigo_Unidad_Venta,Nombre_Unidad_Venta From CAT_UNIDADES_VENTA " & Me._QueryOrder, Me._Conexion)
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
        Dim da As New SqlDataAdapter("SELECT CODIGO_UNIDAD_VENTA, NOMBRE_UNIDAD_VENTA FROM CAT_UNIDADES_VENTA WHERE NOMBRE_UNIDAD_VENTA LIKE '" & Filtro.ToString & "%' ORDER BY NOMBRE_UNIDAD_VENTA", Me._Conexion)
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
        f.Text = "Búsqueda de unidad por codigo."
        f.sCampo = "Codigo_Unidad_Venta"
        f.sOrder = "Nombre_Unidad_Venta"
        f.sTable = "CAT_UNIDADES_VENTA"
        f.sQl = "Select Codigo_Unidad_Venta,Nombre_Unidad_Venta From CAT_UNIDADES_VENTA Where 1=1 And"
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
        f.Text = "Búsqueda de unidades por Descripción."
        f.sCampo = "Nombre_Unidad_Venta"
        f.sOrder = "Nombre_Unidad_Venta"
        f.sTable = "CAT_UNIDADES_VENTA"
        f.sQl = "Select Codigo_Unidad_Venta,Nombre_Unidad_Venta From CAT_UNIDADES_VENTA Where 1=1 And"
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
