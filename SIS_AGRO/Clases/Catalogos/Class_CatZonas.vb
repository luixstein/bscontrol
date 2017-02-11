Imports System.Data
Imports System.Data.SqlClient

Public Class Class_CatZonas
    Inherits Class_Catalogos

#Region "Campos"


#Region "Campos de la tabla"
    Private _Codigo_Zona As Integer
    Private _Nombre_Zona As String
    Private _Codigo_Plaza As Integer
    Private _Agregar As String
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
    Public Property Codigo_Zona() As Integer
        Get
            Return Me._Codigo_Zona
        End Get
        Set(ByVal Value As Integer)
            Me._Codigo_Zona = Value
        End Set
    End Property

    Public Property Nombre_Zona() As String
        Get
            Return Me._Nombre_Zona
        End Get
        Set(ByVal Value As String)
            Me._Nombre_Zona = Value
        End Set
    End Property

    Public Property Codigo_Plaza() As Integer
        Get
            Return Me._Codigo_Plaza
        End Get
        Set(ByVal Value As Integer)
            Me._Codigo_Plaza = Value
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
        Me._Nombre_Catalogo = "Cat_Zonas"
        Me._Nombre_Reporte = "RPT_Cat_Zonas.rpt"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "SELECT CODIGO_ZONA,NOMBRE_ZONA,CODIGO_PLAZA FROM CAT_ZONAS"
        Me._QueryOrder = " Order by NOMBRE_ZONA"
    End Sub                                                         'Inicializa al objeto.

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
            .CommandText = "MP_CAT_ZONAS_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_ZONA", SqlDbType.SmallInt, 2) : sqlParametro.Value = Me._Codigo_Zona
            sqlParametro = .Parameters.Add("@NOMBRE_ZONA", SqlDbType.NVarChar, 50) : sqlParametro.Value = Me._Nombre_Zona.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_PLAZA", SqlDbType.SmallInt, 2) : sqlParametro.Value = Me._Codigo_Plaza
            sqlParametro = .Parameters.Add("@AGREGAR", SqlDbType.NVarChar, 1) : sqlParametro.Value = Me._Agregar.ToString
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
        Dim cmd As New SqlCommand("Select * from Cat_ZONAS Where CODIGO_ZONA=" & Replace(Me._Codigo_Zona, "'", "''") & " and codigo_plaza=" & Plaza.CODIGO_PLAZA.ToString, Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._Codigo_Zona = "" & dReader("CODIGO_ZONA")
                    Me._Nombre_Zona = Trim("" & dReader("NOMBRE_ZONA").ToString)
                    Me._Codigo_Plaza = "" & dReader("CODIGO_PLAZA").ToString
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
            .CommandText = "MP_CAT_ZONAS_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_ZONA", SqlDbType.SmallInt, 2) : sqlParametro.Value = Me._Codigo_Zona
            sqlParametro = .Parameters.Add("@NOMBRE_ZONA", SqlDbType.NVarChar, 50) : sqlParametro.Value = Me._Nombre_Zona.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_PLAZA", SqlDbType.SmallInt, 2) : sqlParametro.Value = Me._Codigo_Plaza
            sqlParametro = .Parameters.Add("@AGREGAR", SqlDbType.NVarChar, 1) : sqlParametro.Value = Me._Agregar.ToString

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                Insertar = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "Actualizar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try

        End With
    End Function                          'Inserta un elemento al catálogo.

    Public Overrides Function ObtenerElementos() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dsCat_Vendedores As New SqlDataAdapter("Select CODIGO_ZONA,NOMBRE_ZONA from CAT_ZONAS Where CODIGO_PLAZA=" & Plaza.CODIGO_PLAZA & "  order by NOMBRE_ZONA", Me._Conexion)
        Try
            dsCat_Vendedores.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementos", ex)
        Finally
            dsCat_Vendedores.Dispose()
        End Try
        Return dTable
    End Function    'Obtiene una lita completa de los elementos del catalogo en un datatable.

    Public Function ObtenerZonasParaReportes() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dsCatTiposMercados As New SqlDataAdapter("SELECT CODIGO_ZONA,NOMBRE_ZONA from CAT_ZONAS", Empresa_Sistema.conexion)
        Try
            dsCatTiposMercados.Fill(dTable)
            dTable.Rows.Add("T", "TODOS")
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerZonasParaReportes", ex)
        Finally
            dsCatTiposMercados.Dispose()
        End Try
        ObtenerZonasParaReportes = dTable
    End Function

    Public Function ObtenerElementosFiltro(ByVal Filtro As String) As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dA As New SqlDataAdapter("Select CODIGO_ZONA,NOMBRE_ZONA from CAT_ZONAS Where CODIGO_PLAZA=" & Plaza.CODIGO_PLAZA & " AND NOMBRE_ZONA LIKE '" & Filtro.ToString & "%' ORDER BY NOMBRE_ZONA", Me._Conexion)
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
        f.Text = "Búsqueda de ZONAS por codigo."
        f.sCampo = "CODIGO_ZONA"
        f.sOrder = "NOMBRE_ZONA"
        f.sTable = "CAT_ZONAS"
        f.sQl = "Select CODIGO_ZONA,NOMBRE_ZONA From CAT_ZONAS Where 1=1 And"
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
        f.sQl = "Select CODIGO_ZONA,NOMBRE_ZONA From CAT_ZONAS Where 1=1 And"
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
