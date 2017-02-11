Imports System.Data
Imports System.Data.SqlClient

Public Class Class_CatTamaños
    Inherits Class_Catalogos

#Region "Campos"

#Region "Campos de la tabla"
    Private _Codigo_Tamaño As String
    Private _Nombre_Tamaño As String
    Private _CODIGO_TIPO_TAMAÑO As Integer
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
    Public Property Codigo_Tamaño() As String
        Get
            Return Me._Codigo_Tamaño
        End Get
        Set(ByVal Value As String)
            Me._Codigo_Tamaño = Value
        End Set
    End Property

    Public Property Nombre_Tamaño() As String
        Get
            Return Me._Nombre_Tamaño
        End Get
        Set(ByVal Value As String)
            Me._Nombre_Tamaño = Value
        End Set
    End Property

    Public Property Codigo_tipo_Tamaño() As Integer
        Get
            Return Me._CODIGO_TIPO_TAMAÑO
        End Get
        Set(ByVal Value As Integer)
            Me._CODIGO_TIPO_TAMAÑO = Value
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
        Me._Nombre_Catalogo = "CAT_TAMAÑOS"
        Me._Nombre_Reporte = "RPT_CATALOGO_TAMAÑOS"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "SELECT CODIGO_TAMAÑO,NOMBRE_TAMAÑO FROM CAT_TAMAÑOS"
        Me._QueryOrder = " ORDER BY NOMBRE_TAMAÑO"
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
            .CommandText = "MP_CAT_TAMAÑOS_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_TAMAÑO", SqlDbType.Char, 3) : sqlParametro.Value = Me._Codigo_Tamaño
            sqlParametro = .Parameters.Add("@NOMBRE_TAMAÑO", SqlDbType.NVarChar, 80) : sqlParametro.Value = Me._Nombre_Tamaño.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_TIPO_TAMAÑO", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_TIPO_TAMAÑO
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
            .CommandText = "MP_CAT_TAMAÑOS_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_TAMAÑO", SqlDbType.Char, 3) : sqlParametro.Value = Me._Codigo_Tamaño
            sqlParametro = .Parameters.Add("@NOMBRE_TAMAÑO", SqlDbType.NVarChar, 80) : sqlParametro.Value = Me._Nombre_Tamaño.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_TIPO_TAMAÑO", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_TIPO_TAMAÑO
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
        Dim cmd As New SqlCommand("Select * from CAT_TAMAÑOS Where CODIGO_TAMAÑO=" & Replace(Me._Codigo_Tamaño, "'", "''") & "", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._Codigo_Tamaño = "" & dReader("CODIGO_TAMAÑO")
                    Me._Nombre_Tamaño = Trim("" & dReader("NOMBRE_TAMAÑO").ToString)
                    If IsDBNull(dReader("CODIGO_TIPO_TAMAÑO")) = False Then
                        Me._CODIGO_TIPO_TAMAÑO = CInt(dReader("CODIGO_TIPO_TAMAÑO"))
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
        Dim dsCat_Tamaños As New SqlDataAdapter("Select CODIGO_TAMAÑO,NOMBRE_TAMAÑO,CODIGO_TIPO_TAMAÑO FROM CAT_TAMAÑOS ORDER BY NOMBRE_TAMAÑO", Me._Conexion)
        Try
            dsCat_Tamaños.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementos", ex)
        Finally
            dsCat_Tamaños.Dispose()
        End Try
        Return dTable
    End Function    'Obtiene una lita completa de los elementos del catalogo en un datatable.

    Public Function ObtenerElementosFiltro(ByVal Filtro As String) As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dA As New SqlDataAdapter("SELECT CODIGO_TAMAÑO,NOMBRE_TAMAÑO FROM CAT_TAMAÑOS WHERE NOMBRE_TAMAÑO LIKE '" & Filtro.ToString & "%' ORDER BY NOMBRE_TAMAÑO", Me._Conexion)
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
        f.Text = "Búsqueda de tamaños por codigo."
        f.sCampo = "CODIGO_TAMAÑO"
        f.sOrder = "NOMBRE_TAMAÑO"
        f.sTable = "CAT_TAMAÑOS"
        f.sQl = "SELECT CODIGO_TAMAÑO,NOMBRE_TAMAÑO FROM CAT_TAMAÑOS WHERE 1=1 AND "
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
        f.Text = "Búsqueda de tamaños por Descripción."
        f.sCampo = "NOMBRE_TAMAÑO"
        f.sOrder = "NOMBRE_TAMAÑO"
        f.sTable = "CAT_TAMAÑOS"
        f.sQl = "Select CODIGO_TAMAÑO,NOMBRE_TAMAÑO FROM CAT_TAMAÑOS Where 1=1 And"
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
        Dim iTamaño As Integer, sTamaño As String
        Dim Resultado As String = ""
        Try
            Dim sql As New Class_find("SELECT ISNULL(MAX(CAST(CODIGO_TAMAÑO  AS SMALLINT)),0)+1 FROM CAT_TAMAÑOS ")
            iTamaño = CInt(sql.Result1)
            If iTamaño > 99 Then
                sTamaño = "000" + iTamaño.ToString
                Resultado = sTamaño.Substring(Len(sTamaño) - 3)
            Else
                sTamaño = "00" + iTamaño.ToString
                Resultado = sTamaño.Substring(Len(sTamaño) - 2)
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