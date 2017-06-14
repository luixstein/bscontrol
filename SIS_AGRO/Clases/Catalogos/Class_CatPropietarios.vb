Imports System.Data
Imports System.Data.SqlClient

Public Class Class_CatPropietarios
    Inherits Class_Catalogos

#Region "Campos"

#Region "Campos de la tabla"
    Private _CODIGO_PROPIETARIO As Integer
    Private _NOMBRE_PROPIETARIO As String
    Private _LIMITE_CREDITO As Decimal
    Private _PLAZO As Integer
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
    Public Property CODIGO_PROPIETARIO() As Integer
        Get
            Return Me._CODIGO_PROPIETARIO
        End Get
        Set(ByVal Value As Integer)
            Me._CODIGO_PROPIETARIO = Value
        End Set
    End Property

    Public Property NOMBRE_PROPIETARIO() As String
        Get
            Return Me._NOMBRE_PROPIETARIO
        End Get
        Set(ByVal Value As String)
            Me._NOMBRE_PROPIETARIO = Value
        End Set
    End Property

    Public Property LIMITE_CREDITO() As Decimal
        Get
            Return Me._LIMITE_CREDITO
        End Get
        Set(ByVal Value As Decimal)
            Me._LIMITE_CREDITO = Value
        End Set
    End Property

    Public Property PLAZO() As Integer
        Get
            Return Me._PLAZO
        End Get
        Set(ByVal Value As Integer)
            Me._PLAZO = Value
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
        Me._Nombre_Catalogo = "CAT_PROPIETARIOS"
        'Me._Nombre_Reporte = "RPT_CATALOGO_EMPAQUES"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "SELECT * FROM CAT_PROPIETARIOS"
        Me._QueryOrder = " ORDER BY NOMBRE_PROPIETARIO"
    End Sub

    Public Sub New(ByVal sCodigoPropietario As String)
        Me.New()
        Try
            Me._CODIGO_PROPIETARIO = sCodigoPropietario
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
            .CommandText = "MP_CAT_PROPIETARIOS_GRABAR"

            sqlParametro = .Parameters.Add("@CODIGO_PROPIETARIO", SqlDbType.Int) : sqlParametro.Value = 0 'Me._CODIGO_PROPIETARIO
            sqlParametro = .Parameters.Add("@NOMBRE_PROPIETARIO", SqlDbType.NVarChar, 200) : sqlParametro.Value = Me._NOMBRE_PROPIETARIO.ToString.ToUpper
            sqlParametro = .Parameters.Add("@LIMITE_CREDITO", SqlDbType.Decimal) : sqlParametro.Value = Me._LIMITE_CREDITO
            sqlParametro = .Parameters.Add("@PLAZO", SqlDbType.Int) : sqlParametro.Value = Me._PLAZO
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
            .CommandText = "MP_CAT_PROPIETARIOS_GRABAR"

            sqlParametro = .Parameters.Add("@CODIGO_PROPIETARIO", SqlDbType.Int) : sqlParametro.Value = Me._CODIGO_PROPIETARIO
            sqlParametro = .Parameters.Add("@NOMBRE_PROPIETARIO", SqlDbType.NVarChar, 200) : sqlParametro.Value = Me._NOMBRE_PROPIETARIO.ToString.ToUpper
            sqlParametro = .Parameters.Add("@LIMITE_CREDITO", SqlDbType.Decimal) : sqlParametro.Value = Me._LIMITE_CREDITO
            sqlParametro = .Parameters.Add("@PLAZO", SqlDbType.Int) : sqlParametro.Value = Me._PLAZO
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
        Dim cmd As New SqlCommand("SELECT * FROM CAT_PROPIETARIOS WHERE CODIGO_PROPIETARIO=" & Me._CODIGO_PROPIETARIO, Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._CODIGO_PROPIETARIO = dReader("CODIGO_PROPIETARIO")
                    Me._NOMBRE_PROPIETARIO = Trim("" & dReader("NOMBRE_PROPIETARIO").ToString)
                    Me._LIMITE_CREDITO = dReader("LIMITE_CREDITO")
                    Me._PLAZO = dReader("PLAZO")
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
        Dim da As New SqlDataAdapter("SELECT CODIGO_PROPIETARIO,NOMBRE_PROPIETARIO FROM CAT_PROPIETARIOS " & Me._QueryOrder, Me._Conexion)
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
        Dim da As New SqlDataAdapter("SELECT CODIGO_PROPIETARIO,NOMBRE_PROPIETARIO FROM CAT_PROPIETARIOS WHERE NOMBRE_PROPIETARIO LIKE '" & Filtro.ToString & "%' ORDER BY NOMBRE_PROPIETARIO", Me._Conexion)
        Try
            da.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementosFiltro", ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerRelacionPropietariosClientes(ByVal sCodigoPropietario As String) As System.Data.DataTable
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter("SELECT R.CODIGO_CLIENTE,C.NOMBRE_CLIENTE FROM CAT_PROPIETARIOS_RELACION_CLIENTES R INNER JOIN CAT_CLIENTES C ON(R.CODIGO_CLIENTE=C.CODIGO_CLIENTE) " _
                                     & "WHERE R.CODIGO_PROPIETARIO =" & sCodigoPropietario & " ORDER BY C.NOMBRE_CLIENTE ", Me._Conexion)
        Try
            da.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerRelacionPropietariosClientes", ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

    Public Overrides Function BusquedaVisual_PorCodigo() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de propietario por codigo."
        f.sCampo = "CODIGO_PROPIETARIO"
        f.sOrder = "NOMBRE_PROPIETARIO"
        f.sTable = "CAT_PROPIETARIOS"
        f.sQl = "SELECT CODIGO_PROPIETARIO,NOMBRE_PROPIETARIO FROM CAT_PROPIETARIOS Where 1=1 And"
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
        f.Text = "Búsqueda de propietarios por nombre."
        f.sCampo = "NOMBRE_PROPIETARIO"
        f.sOrder = "NOMBRE_PROPIETARIO"
        f.sTable = "CAT_PROPIETARIOS"
        f.sQl = "SELECT CODIGO_PROPIETARIO,NOMBRE_PROPIETARIO FROM CAT_PROPIETARIOS Where 1=1 And"
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

    Public Function CodigoSiguiente() As Integer
        Dim iPropietarios As Integer
        Try
            Dim sql As New Class_find("SELECT MAX(CODIGO_PROPIETARIO) FROM CAT_PROPIETARIOS")
            If sql.Result1 = "" Then
                iPropietarios = 1
            Else
                iPropietarios = CType(sql.Result1, Integer) + 1
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "CodigoSiguiente", ex)
        End Try
        Return iPropietarios
    End Function
#End Region

End Class