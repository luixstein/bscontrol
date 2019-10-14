Imports System.Data
Imports System.Data.SqlClient

Public Class Class_TipoCambioDia
    Inherits Class_Catalogos

#Region "Campos"

#Region "Campos de la tabla"
    Private _ID As Integer
    Private _TIPO_CAMBIO As Decimal
    Private _FECHA_TIPO_CAMBIO As String
    Private _CODIGO_ULTIMO_USUARIO_MODIFICO As Integer
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
    Private _QuerySelect As String
    Private _QueryOrder As String

#End Region

#End Region

#Region "Propiedades"

#Region "Propiedades Campos de la tabla"
    Public Property ID() As Integer
        Get
            Return Me._ID
        End Get
        Set(ByVal Value As Integer)
            Me._ID = Value
        End Set
    End Property

    Public Property TIPO_CAMBIO() As Decimal
        Get
            Return Me._TIPO_CAMBIO
        End Get
        Set(ByVal Value As Decimal)
            Me._TIPO_CAMBIO = Value
        End Set
    End Property

    Public Property FECHA_TIPO_CAMBIO() As String
        Get
            Return Me._FECHA_TIPO_CAMBIO
        End Get
        Set(ByVal Value As String)
            Me._FECHA_TIPO_CAMBIO = Value
        End Set
    End Property

    Public Property CODIGO_ULTIMO_USUARIO_GRABO() As Integer
        Get
            Return Me._CODIGO_ULTIMO_USUARIO_MODIFICO
        End Get
        Set(ByVal Value As Integer)
            Me._CODIGO_ULTIMO_USUARIO_MODIFICO = Value
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
    'Public Property EStatus() As String
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
        Me._Nombre_Catalogo = "TipoCambioDia"
        Me._Nombre_Reporte = ""
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "Select * FROM TIPO_CAMBIO_DEL_DIA"
        Me._QueryOrder = " Order by ID"
    End Sub

    Public Sub New(ByVal sFechaTipoCambio As String)
        Me.New()
        Try
            Me._FECHA_TIPO_CAMBIO = sFechaTipoCambio
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

    Public Overrides Function Insertar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_TIPO_CAMBIO_DIA_GRABA"

            sqlParametro = .Parameters.Add("@ID", SqlDbType.Int) : sqlParametro.Value = 0
            sqlParametro = .Parameters.Add("@TIPO_CAMBIO", SqlDbType.Decimal) : sqlParametro.Value = Me._TIPO_CAMBIO
            sqlParametro = .Parameters.Add("@CODIGO_ULTIMO_USUARIO_MODIFICO", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_ULTIMO_USUARIO_MODIFICO
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
            .CommandText = "MP_TIPO_CAMBIO_DIA_GRABA"

            sqlParametro = .Parameters.Add("@ID", SqlDbType.Int) : sqlParametro.Value = Me._ID
            sqlParametro = .Parameters.Add("@TIPO_CAMBIO", SqlDbType.Decimal) : sqlParametro.Value = Me._TIPO_CAMBIO
            sqlParametro = .Parameters.Add("@CODIGO_ULTIMO_USUARIO_MODIFICO", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_ULTIMO_USUARIO_MODIFICO
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
        Dim cmd As New SqlCommand("SELECT * FROM TIPO_CAMBIO_DEL_DIA WHERE FECHA_TIPO_CAMBIO='" & sReplace(Me._FECHA_TIPO_CAMBIO) & "'", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._ID = dReader("ID")
                    Me._TIPO_CAMBIO = dReader("TIPO_CAMBIO")
                    Me._FECHA_TIPO_CAMBIO = dReader("FECHA_TIPO_CAMBIO")
                    Me._CODIGO_ULTIMO_USUARIO_MODIFICO = dReader("CODIGO_ULTIMO_USUARIO_MODIFICO")
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
        Dim da As New SqlDataAdapter("SELECT CODIGO_FAMILIA,NOMBRE_FAMILIA FROM CAT_FAMILIAS ORDER BY NOMBRE_FAMILIA", Me._Conexion)
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
        Dim da As New SqlDataAdapter("SELECT CODIGO_FAMILIA,NOMBRE_FAMILIA FROM CAT_FAMILIAS ORDER BY NOMBRE_FAMILIA", Me._Conexion)
        Try
            da.Fill(dTable)
            dTable.Rows.Add("T", "TODAS")
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementosParaReportes", ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

    Public Overrides Function BusquedaVisual_PorCodigo() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de familias por código."
        f.sCampo = "CODIGO_FAMILIA"
        f.sOrder = "NOMBRE_FAMILIA"
        f.sTable = "CAT_FAMILIAS"
        f.sQl = "Select CODIGO_FAMILIA,NOMBRE_FAMILIA From CAT_FAMILIAS Where 1=1 And"
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
        f.Text = "Búsqueda de familias por descripción."
        f.sCampo = "NOMBRE_FAMILIA"
        f.sOrder = "NOMBRE_FAMILIA"
        f.sTable = "CAT_FAMILIAS"
        f.sQl = "Select CODIGO_FAMILIA,NOMBRE_FAMILIA From CAT_FAMILIAS Where 1=1 And"
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