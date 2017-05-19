Imports System.Data
Imports System.Data.SqlClient

Public Class Class_CatZonas
    Inherits Class_Catalogos

#Region "Campos"

#Region "Campos de la tabla"
    Private _CODIGO_ZONA As Integer
    Private _NOMBRE_ZONA As String
    Private _CODIGO_PLAZA As Integer
    Private _Agregar As String
#End Region

#Region "Campos ligados a la tabla"
    Private _Existe As Boolean 'lectura
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
    Public Property CODIGO_ZONA() As Integer
        Get
            Return Me._CODIGO_ZONA
        End Get
        Set(ByVal Value As Integer)
            Me._CODIGO_ZONA = Value
        End Set
    End Property

    Public Property NOMBRE_ZONA() As String
        Get
            Return Me._NOMBRE_ZONA
        End Get
        Set(ByVal Value As String)
            Me._NOMBRE_ZONA = Value
        End Set
    End Property

    Public Property CODIGO_PLAZA() As Integer
        Get
            Return Me._CODIGO_PLAZA
        End Get
        Set(ByVal Value As Integer)
            Me._CODIGO_PLAZA = Value
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
#End Region

#End Region

#Region "Constructor y destructor"

    Public Sub New()
        Me._Nombre_Catalogo = "CAT_ZONAS"
        Me._Nombre_Reporte = "RPT_CATALOGO_ZONAS"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySELECT = "SELECT CODIGO_ZONA,NOMBRE_ZONA,CODIGO_PLAZA FROM CAT_ZONAS"
        Me._QueryOrder = " ORDER BY NOMBRE_ZONA"
    End Sub

    Public Sub New(ByVal sCodigoZona As String)
        Me.New()
        Try
            Me.CODIGO_ZONA = sCodigoZona
            If Me.Consultar = True Then
                Me._Existe = True
                'Throw New Exception("El artículo no existe.")
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

    Public Overrides Function Actualizar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CAT_ZONAS_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_ZONA", SqlDbType.SmallInt, 2) : sqlParametro.Value = Me._CODIGO_ZONA
            sqlParametro = .Parameters.Add("@NOMBRE_ZONA", SqlDbType.NVarChar, 50) : sqlParametro.Value = Me._NOMBRE_ZONA.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_PLAZA", SqlDbType.SmallInt, 2) : sqlParametro.Value = Me._CODIGO_PLAZA
            sqlParametro = .Parameters.Add("@AGREGAR", SqlDbType.NVarChar, 1) : sqlParametro.Value = Me._Agregar.ToString
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
        Dim cmd As New SqlCommand("SELECT * FROM CAT_ZONAS WHERE CODIGO_ZONA=" & sReplace(Me._CODIGO_ZONA) & " AND CODIGO_PLAZA=" & Plaza.CODIGO_PLAZA.ToString, Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._CODIGO_ZONA = "" & dReader("CODIGO_ZONA")
                    Me._NOMBRE_ZONA = Trim("" & dReader("NOMBRE_ZONA").ToString)
                    Me._CODIGO_PLAZA = "" & dReader("CODIGO_PLAZA").ToString
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

    Public Overrides Function Insertar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CAT_ZONAS_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_ZONA", SqlDbType.SmallInt, 2) : sqlParametro.Value = Me._CODIGO_ZONA
            sqlParametro = .Parameters.Add("@NOMBRE_ZONA", SqlDbType.NVarChar, 50) : sqlParametro.Value = Me._NOMBRE_ZONA.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_PLAZA", SqlDbType.SmallInt, 2) : sqlParametro.Value = Me._CODIGO_PLAZA
            sqlParametro = .Parameters.Add("@AGREGAR", SqlDbType.NVarChar, 1) : sqlParametro.Value = Me._Agregar.ToString

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

    Public Overrides Function ObtenerElementos() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter("SELECT CODIGO_ZONA,NOMBRE_ZONA FROM CAT_ZONAS WHERE CODIGO_PLAZA=" & Plaza.CODIGO_PLAZA & "  ORDER BY NOMBRE_ZONA", Me._Conexion)
        Try
            da.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementos", ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerZonasParaReportes() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter("SELECT CODIGO_ZONA,NOMBRE_ZONA FROM CAT_ZONAS", Empresa_Sistema.conexion)
        Try
            da.Fill(dTable)
            dTable.Rows.Add("T", "TODOS")
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerZonasParaReportes", ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerElementosFiltro(ByVal Filtro As String) As System.Data.DataTable
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter("SELECT CODIGO_ZONA,NOMBRE_ZONA FROM CAT_ZONAS WHERE CODIGO_PLAZA=" & Plaza.CODIGO_PLAZA & " AND NOMBRE_ZONA LIKE '" & Filtro.ToString & "%' ORDER BY NOMBRE_ZONA", Me._Conexion)
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
        f.Text = "Búsqueda de ZONAS por codigo."
        f.sCampo = "CODIGO_ZONA"
        f.sOrder = "NOMBRE_ZONA"
        f.sTable = "CAT_ZONAS"
        f.sQl = "SELECT CODIGO_ZONA,NOMBRE_ZONA FROM CAT_ZONAS WHERE 1=1 AND "
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
        f.Text = "Búsqueda de ZONAS por Descripción."
        f.sCampo = "NOMBRE_ZONA"
        f.sOrder = "NOMBRE_ZONA"
        f.sTable = "CAT_ZONAS"
        f.sQl = "SELECT CODIGO_ZONA,NOMBRE_ZONA FROM CAT_ZONAS WHERE 1=1 AND "
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
