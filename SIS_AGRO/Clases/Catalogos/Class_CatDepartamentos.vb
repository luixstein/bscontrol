Imports System.Data.SqlClient

Public Class Class_CatDepartamentos

#Region "Campos"

#Region "Campos de la tabla"
    Private _CODIGO_DEPARTAMENTO As Integer
    Private _NOMBRE_DEPARTAMENTO As String
    Private _ESTATUS As String
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
    Public Property CODIGO_DEPARTAMENTO() As Integer
        Get
            Return Me._CODIGO_DEPARTAMENTO
        End Get
        Set(value As Integer)
            Me._CODIGO_DEPARTAMENTO = value
        End Set
    End Property

    Public Property NOMBRE_DEPARTAMENTO() As String
        Get
            Return Me._NOMBRE_DEPARTAMENTO
        End Get
        Set(ByVal Value As String)
            Me._NOMBRE_DEPARTAMENTO = Value
        End Set
    End Property

    Public Property ESTATUS() As String
        Get
            Return Me._ESTATUS
        End Get
        Set(ByVal Value As String)
            Me._ESTATUS = Value
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
    Public ReadOnly Property Nombre_Catalogo() As String
        Get
            Return Me._Nombre_Catalogo
        End Get
    End Property

    Public Property Nombre_Reporte() As String
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
        Me._Nombre_Catalogo = "CAT_DEPARTAMENTOS"
        Me._Nombre_Reporte = "RPT_CAT_DEPARTAMENTOS"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "SELECT CODIGO_DEPARTAMENTO,NOMBRE_DEPARTAMENTO FROM CAT_DEPARTAMENTOS "
        Me._QueryOrder = " ORDER BY NOMBRE_DEPARTAMENTO"
    End Sub

    Public Sub New(ByVal sCodigo As String)
        Me.New()
        Try
            Me._CODIGO_DEPARTAMENTO = sCodigo
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
    Public Function Grabar(ByVal sAccion As String) As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CAT_DEPARTAMENTOS_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_DEPARTAMENTO", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_DEPARTAMENTO : sqlParametro.Direction = ParameterDirection.InputOutput
            sqlParametro = .Parameters.Add("@NOMBRE_DEPARTAMENTO", SqlDbType.NVarChar, 50) : sqlParametro.Value = Me._NOMBRE_DEPARTAMENTO.Trim.ToUpper
            sqlParametro = .Parameters.Add("@ESTATUS", SqlDbType.Char, 1) : sqlParametro.Value = Me._ESTATUS
            sqlParametro = .Parameters.Add("@ACCION", SqlDbType.NVarChar, 15) : sqlParametro.Value = sAccion
            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                Me._CODIGO_DEPARTAMENTO = .Parameters("@CODIGO_DEPARTAMENTO").Value.ToString
                bResultado = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "Grabar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Function Consultar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand("SELECT * FROM CAT_DEPARTAMENTOS WHERE CODIGO_DEPARTAMENTO=" & Me._CODIGO_DEPARTAMENTO.ToString, Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read = True Then
                    Me._CODIGO_DEPARTAMENTO = dReader("CODIGO_DEPARTAMENTO").ToString
                    Me._NOMBRE_DEPARTAMENTO = dReader("NOMBRE_DEPARTAMENTO").ToString
                    Me._ESTATUS = dReader("ESTATUS").ToString
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

    Public Function ObtenerElementos() As System.Data.DataTable
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

    'Public Function ObtenerElementosParaReportes() As System.Data.DataTable
    '    Dim dTable As New DataTable
    '    Dim da As New SqlDataAdapter(Me._QuerySelect & Me._QueryOrder, Me._Conexion)
    '    Try
    '        da.Fill(dTable)
    '        dTable.Rows.Add("-1", "TODOS")
    '    Catch ex As Exception
    '        HandleError(Me._Nombre_Catalogo, "ObtenerElementosParaReportes", ex)
    '    Finally
    '        da.Dispose()
    '    End Try
    '    Return dTable
    'End Function

    Public Function ObtenerElementosFiltro(ByVal Filtro As String) As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dA As New SqlDataAdapter("SELECT * FROM CAT_DEPARTAMENTOS WHERE NOMBRE_DEPARTAMENTO LIKE '" & Filtro.ToString & "%' ORDER BY NOMBRE_DEPARTAMENTO", Me._Conexion)
        Try
            dA.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementosFiltro", ex)
        Finally
            dA.Dispose()
        End Try
        Return dTable
    End Function

    Public Function BusquedaVisual_PorDescripcion() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de departamentos por nombre."
        f.sCampo = "NOMBRE_DEPARTAMENTO"
        f.sOrder = "NOMBRE_DEPARTAMENTO"
        f.sTable = "CAT_DEPARTAMENTOS"
        f.sQl = "SELECT CODIGO_DEPARTAMENTO,NOMBRE_DEPARTAMENTO From CAT_DEPARTAMENTOS WHERE ESTATUS='A' AND "
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
            Dim sql As New Class_find("SELECT MAX(CODIGO_DEPARTAMENTO) FROM CAT_DEPARTAMENTOS")
            Resultado = CType(sql.Result1, Integer) + 1
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "CodigoSiguiente", ex)
        End Try
        Return Resultado
    End Function
#End Region

End Class