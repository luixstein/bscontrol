Imports System.Data
Imports System.Data.SqlClient

Public Class Class_CatBancos
    Inherits Class_Catalogos

#Region "Campos"

#Region "Campos de la tabla"

    Private _CODIGO_BANCO As String
    Private _NOMBRE_BANCO As String
    Private _ESTATUS As String
    Private _EXISTE As Boolean 'LECTURA

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

    Public ReadOnly Property EXISTE() As Boolean
        Get
            Return Me._EXISTE
        End Get
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
    Public Property Status() As String
        Get
            Return Me._Estatus
        End Get
        Set(ByVal value As String)
            Me._Estatus = value
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
    End Sub                                                         'Inicializa al objeto.

    Public Sub New(ByVal sCodigoBanco As String)
        Me.New()
        Me._Codigo_Banco = sCodigoBanco
        Try
            If Me.Consultar = True Then
                Me._Existe = True
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

#Region "Opciones"

#End Region

#Region "Métodos y procedimientos"

    Public Overrides Function Actualizar() As Boolean
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
                Actualizar = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "Actualizar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try

        End With
    End Function                        'Actualiza un elemento del catálogo.

    Public Overrides Function Consultar() As Boolean
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
                    Me._ESTATUS = "" & dReader("ESTATUS_BANCO").ToString
                    Consultar = True
                End If
                dReader.Close()
            Catch ex As Exception
                HandleError(Me.Nombre_Catalogo, "Consultar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
            End Try
        End With
    End Function        'Consulta un elemento del catálogo.

    Public Overrides Function Insertar() As Boolean
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
                Insertar = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "Insertar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try

        End With
    End Function                          'Inserta un elemento al catálogo.

    Public Overrides Function ObtenerElementos() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dsCAT_BANCOS As New SqlDataAdapter(Me._QuerySelect & Me._QueryOrder, Me._Conexion)
        Try
            dsCAT_BANCOS.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementos", ex)
        Finally
            dsCAT_BANCOS.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerElementosParaCatalogos() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dsCAT_BANCOS As New SqlDataAdapter(Me._QuerySelect & " WHERE PROTEGIDO=0 " & Me._QueryOrder, Me._Conexion)
        Try
            dsCAT_BANCOS.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementosParaCatalogos", ex)
        Finally
            dsCAT_BANCOS.Dispose()
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

    Public Overrides Function BusquedaVisual_PorCodigo() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de Metodos de Tipos de Socios por codigo."
        f.sCampo = "Codigo_Banco"
        f.sOrder = "Nombre_Banco"
        f.sTable = "CAT_BANCOS"
        f.sQl = "Select Codigo_Banco,Nombre_Banco From CAT_BANCOS Where 1=1 And"
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
        f.Text = "Búsqueda de Bancos por Descripción."
        f.sCampo = "Nombre_Banco"
        f.sOrder = "Nombre_Banco"
        f.sTable = "CAT_BANCOS"
        f.sQl = "Select Codigo_Banco,Nombre_Banco From CAT_BANCOS Where 1=1 And"
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



