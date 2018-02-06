Option Strict On

Imports System.Data.SqlClient

Public Class Class_CatBancos

#Region "Campos"

#Region "Campos de la tabla"
    Private _CODIGO_BANCO As String
    Private _NOMBRE_BANCO As String
    Private _NOMBRE_LARGO As String
    Private _ESTATUS_BANCO As String
    Private _PROTEGIDO As Boolean
    Private _RFC_BANCO As String
#End Region

#Region "Campos ligados a la tabla"
    Private _EXISTE As Boolean
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
    Public Property CODIGO_BANCO() As String
        Get
            Return Me._CODIGO_BANCO
        End Get
        Set(ByVal VALUE As String)
            Me._CODIGO_BANCO = VALUE
        End Set
    End Property

    Public Property NOMBRE_BANCO() As String
        Get
            Return Me._NOMBRE_BANCO
        End Get
        Set(ByVal VALUE As String)
            Me._NOMBRE_BANCO = VALUE
        End Set
    End Property

    Public Property NOMBRE_LARGO() As String
        Get
            Return Me._NOMBRE_LARGO
        End Get
        Set(ByVal VALUE As String)
            Me._NOMBRE_LARGO = VALUE
        End Set
    End Property

    Public Property ESTATUS_BANCO() As String
        Get
            Return Me._ESTATUS_BANCO
        End Get
        Set(ByVal VALUE As String)
            Me._ESTATUS_BANCO = VALUE
        End Set
    End Property

    Public Property PROTEGIDO() As Boolean
        Get
            Return Me._PROTEGIDO
        End Get
        Set(ByVal VALUE As Boolean)
            Me._PROTEGIDO = VALUE
        End Set
    End Property

    Public Property RFC_BANCO() As String
        Get
            Return Me._RFC_BANCO
        End Get
        Set(ByVal VALUE As String)
            Me._RFC_BANCO = VALUE
        End Set
    End Property
#End Region

#Region "Propiedades de campos ligados a la tabla"
    Public ReadOnly Property EXISTE() As Boolean
        Get
            Return Me._EXISTE
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
        Me._Nombre_Catalogo = "CAT_BANCOS"
        Me._Nombre_Reporte = "RPT_CATALOGO_BANCOS"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "SELECT * FROM CAT_BANCOS"
        Me._QueryOrder = " ORDER BY NOMBRE_BANCO"
    End Sub

    Public Sub New(ByVal sCodigoBanco As String)
        Me.New()
        Me._CODIGO_BANCO = sCodigoBanco
        Try
            If Me.Consultar = True Then
                Me._EXISTE = True
            Else
                Throw New Exception("El banco no existe.")
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "New", ex)
        End Try
    End Sub

    Protected Overrides Sub Finalize()
        'Me._Conexion.Dispose()
        MyBase.Finalize()
    End Sub
#End Region

#Region "Métodos y procedimientos"
    Public Function Insertar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CAT_BANCOS_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_BANCO", SqlDbType.NVarChar, 4) : sqlParametro.Value = Me._CODIGO_BANCO
            sqlParametro = .Parameters.Add("@NOMBRE_BANCO", SqlDbType.NVarChar, 30) : sqlParametro.Value = Me._NOMBRE_BANCO.ToUpper
            sqlParametro = .Parameters.Add("@ESTATUS_BANCO", SqlDbType.Char, 1) : sqlParametro.Value = "A" 'Me._ESTATUS
            sqlParametro = .Parameters.Add("@PROTEGIDO", SqlDbType.Char, 1) : sqlParametro.Value = "0"
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

    Public Function Actualizar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CAT_BANCOS_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_BANCO", SqlDbType.NVarChar, 4) : sqlParametro.Value = Me._CODIGO_BANCO
            sqlParametro = .Parameters.Add("@NOMBRE_BANCO", SqlDbType.NVarChar, 30) : sqlParametro.Value = Me._NOMBRE_BANCO.ToUpper
            sqlParametro = .Parameters.Add("@ESTATUS_BANCO", SqlDbType.Char, 1) : sqlParametro.Value = "A" 'Me._ESTATUS
            sqlParametro = .Parameters.Add("@PROTEGIDO", SqlDbType.Char, 1) : sqlParametro.Value = "0" 'Me._NOMBRE_BANCO
            sqlParametro = .Parameters.Add("@AGREGAR", SqlDbType.Char, 1) : sqlParametro.Value = "0" ' Me._ESTATUS

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

    Public Function Consultar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand(Me._QuerySelect & " WHERE CODIGO_BANCO='" & Replace(Me._CODIGO_BANCO, "'", "''") & "'", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._CODIGO_BANCO = "" & dReader("CODIGO_BANCO").ToString
                    Me._NOMBRE_BANCO = Trim("" & dReader("NOMBRE_BANCO").ToString)
                    Me._ESTATUS_BANCO = "" & dReader("ESTATUS_BANCO").ToString
                    Me._PROTEGIDO = CBool("" & dReader("PROTEGIDO").ToString)
                    Me._NOMBRE_LARGO = "" & dReader("NOMBRE_LARGO").ToString
                    Me._RFC_BANCO = "" & dReader("RFC_BANCO").ToString

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

    Public Function ObtenerElementosParaCatalogos() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter(Me._QuerySelect & " WHERE PROTEGIDO=0 " & Me._QueryOrder, Me._Conexion)
        Try
            da.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementosParaCatalogos", ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerElementosFiltro(ByVal Filtro As String) As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dA As New SqlDataAdapter("SELECT CODIGO_BANCO, NOMBRE_BANCO FROM CAT_BANCOS WHERE NOMBRE_BANCO LIKE '" & Filtro.ToString & "%' ORDER BY NOMBRE_BANCO", Me._Conexion)
        Try
            dA.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementosFiltro", ex)
        Finally
            dA.Dispose()
        End Try
        Return dTable
    End Function

    Public Function BusquedaVisual_PorCodigo() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de bancos por código."
        f.sCampo = "CODIGO_BANCO"
        f.sOrder = "NOMBRE_BANCO"
        f.sTable = "CAT_BANCOS"
        f.sQl = "SELECT CODIGO_BANCO,NOMBRE_BANCO,NOMBRE_LARGO FROM CAT_BANCOS WHERE 1=1 AND "
        f.arrayWidthColumns = New Integer() {100, 150, 400}
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

    Public Function BusquedaVisual_PorDescripcion() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de bancos por descripción."
        f.sCampo = "NOMBRE_BANCO"
        f.sOrder = "NOMBRE_BANCO"
        f.sTable = "CAT_BANCOS"
        f.sQl = "SELECT CODIGO_BANCO,NOMBRE_BANCO,NOMBRE_LARGO FROM CAT_BANCOS WHERE 1=1 AND "
        f.arrayWidthColumns = New Integer() {100, 150, 400}
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
            Dim sql As New Class_find("SELECT MAX(CAST(CODIGO_BANCO AS smallint)) FROM CAT_BANCOS WHERE CODIGO_BANCO <> 'NA'")
            iCodigo = CInt(sql.Result1) + 1
            Return iCodigo

        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "codigoSiguiente", ex)
        End Try

    End Function
#End Region

End Class



