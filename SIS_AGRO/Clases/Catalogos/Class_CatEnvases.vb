Imports System.Data
Imports System.Data.SqlClient

Public Class Class_CatEnvases
    Inherits Class_Catalogos

#Region "Campos"

#Region "Campos de la tabla"
    Private _Codigo_Envase As String
    Private _Nombre_Envase As String
    Private _CODIGO_TIPO_ENVASE As Integer
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
    Public Property Codigo_Envase() As String
        Get
            Return Me._Codigo_Envase
        End Get
        Set(ByVal Value As String)
            Me._Codigo_Envase = Value
        End Set
    End Property

    Public Property Nombre_Envase() As String
        Get
            Return Me._Nombre_Envase
        End Get
        Set(ByVal Value As String)
            Me._Nombre_Envase = Value
        End Set
    End Property

    Public Property CODIGO_TIPO_ENVASE() As Integer
        Get
            Return Me._CODIGO_TIPO_ENVASE
        End Get
        Set(ByVal Value As Integer)
            Me._CODIGO_TIPO_ENVASE = Value
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
        Me._Nombre_Catalogo = "CAT_ENVASES"
        Me._Nombre_Reporte = "RPT_CATALOGO_ENVACES"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "SELECT * FROM CAT_ENVASES"
        Me._QueryOrder = " ORDER BY NOMBRE_ENVASE"
    End Sub                                                         'Inicializa al objeto.

    Protected Overrides Sub Finalize()
        'Me._Conexion.Dispose()
        MyBase.Finalize()
    End Sub
#End Region

#Region "Opciones"

#End Region

#Region "Métodos y procedimientos"

    Public Overrides Function Insertar() As Boolean
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CAT_ENVASES_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_ENVASE", SqlDbType.Char, 2) : sqlParametro.Value = Me._Codigo_Envase
            sqlParametro = .Parameters.Add("@NOMBRE_ENVASE", SqlDbType.NVarChar, 80) : sqlParametro.Value = Me._Nombre_Envase.ToString.ToUpper
            'sqlParametro = .Parameters.Add("@CANTIDAD_BULTOS_POR_PALET", SqlDbType.SmallInt) : sqlParametro.Value = Me._Cantidad_Bultos_Por_Palet
            sqlParametro = .Parameters.Add("@CODIGO_TIPO_ENVASE", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_TIPO_ENVASE
            sqlParametro = .Parameters.Add("@ESTATUS", SqlDbType.Char, 1) : sqlParametro.Value = Me.Estatus.ToString.ToUpper
            sqlParametro = .Parameters.Add("@AGREGAR", SqlDbType.Char, 1) : sqlParametro.Value = "1"
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

    Public Overrides Function Actualizar() As Boolean
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CAT_ENVASES_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_ENVASE", SqlDbType.Char, 2) : sqlParametro.Value = Me._Codigo_Envase
            sqlParametro = .Parameters.Add("@NOMBRE_ENVASE", SqlDbType.NVarChar, 80) : sqlParametro.Value = Me._Nombre_Envase.ToString.ToUpper
            'sqlParametro = .Parameters.Add("@CANTIDAD_BULTOS_POR_PALET", SqlDbType.SmallInt) : sqlParametro.Value = Me._Cantidad_Bultos_Por_Palet
            sqlParametro = .Parameters.Add("@CODIGO_TIPO_ENVASE", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_TIPO_ENVASE
            sqlParametro = .Parameters.Add("@ESTATUS", SqlDbType.Char, 1) : sqlParametro.Value = Me.Estatus.ToString.ToUpper
            sqlParametro = .Parameters.Add("@AGREGAR", SqlDbType.Char, 1) : sqlParametro.Value = "0"

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
        Dim cmd As New SqlCommand("Select * from CAT_ENVASES WHERE CODIGO_ENVASE=" & Replace(Me._Codigo_Envase, "'", "''") & "", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._Codigo_Envase = "" & dReader("CODIGO_ENVASE")
                    Me._Nombre_Envase = Trim("" & dReader("NOMBRE_ENVASE").ToString)
                    'Me._Cantidad_Bultos_Por_Palet = CInt(dReader("CANTIDAD_BULTOS_POR_PALET"))
                    If IsDBNull(dReader("CODIGO_TIPO_ENVASE")) = False Then
                        Me._CODIGO_TIPO_ENVASE = CInt(dReader("CODIGO_TIPO_ENVASE"))
                    End If
                    Me.Estatus = "" & dReader("ESTATUS").ToString
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

    Public Overrides Function ObtenerElementos() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dsCat_Envases As New SqlDataAdapter("SELECT CODIGO_ENVASE,NOMBRE_ENVASE FROM CAT_ENVASES ORDER BY NOMBRE_ENVASE", Me._Conexion)
        Try
            dsCat_Envases.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementos", ex)
        Finally
            dsCat_Envases.Dispose()
        End Try
        Return dTable
    End Function    'Obtiene una lita completa de los elementos del catalogo en un datatable.

    Public Function ObtenerElementosFiltro(ByVal Filtro As String) As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dA As New SqlDataAdapter("SELECT CODIGO_ENVASE,NOMBRE_ENVASE FROM CAT_ENVASES WHERE NOMBRE_ENVASE LIKE '" & Filtro.ToString & "%' ORDER BY NOMBRE_ENVASE", Me._Conexion)
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
        f.Text = "Búsqueda de envases por codigo."
        f.sCampo = "CODIGO_ENVASE"
        f.sOrder = "NOMBRE_ENVASE"
        f.sTable = "CAT_ENVASES"
        f.sQl = "SELECT CODIGO_ENVASE,NOMBRE_ENVASE FROM CAT_ENVASES WHERE 1=1 AND "
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
        f.Text = "Búsqueda de envases por Descripción."
        f.sCampo = "NOMBRE_ENVASE"
        f.sOrder = "NOMBRE_ENVASE"
        f.sTable = "CAT_ENVASES"
        f.sQl = "Select CODIGO_ENVASE,NOMBRE_ENVASE FROM CAT_ENVASES Where 1=1 And"
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
        Dim iEnvase As Integer, sEnvase As String
        Dim Resultado As String = ""
        Try
            Dim sql As New Class_find("SELECT ISNULL(MAX(CODIGO_ENVASE),0)+1 FROM CAT_ENVASES ")
            iEnvase = CInt(sql.Result1)
            sEnvase = "00" + iEnvase.ToString
            Resultado = sEnvase.Substring(Len(sEnvase) - 2)
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
