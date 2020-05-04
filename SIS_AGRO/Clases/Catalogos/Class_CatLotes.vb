Imports System.Data
Imports System.Data.SqlClient

Public Class Class_CatLotes
    Inherits Class_Catalogos

#Region "Campos"

#Region "Campos de la tabla"
    Private _Codigo_Lote As String
    Private _Nombre_Lote As String
    Private _Colindancia As String
    Private _Hectareas As String
    Private _Latitud As String
    Private _Longitud As String
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
    Public Property Codigo_Lote() As String
        Get
            Return Me._Codigo_Lote
        End Get
        Set(ByVal Value As String)
            Me._Codigo_Lote = Value
        End Set
    End Property

    Public Property Nombre_Lote() As String
        Get
            Return Me._Nombre_Lote
        End Get
        Set(ByVal Value As String)
            Me._Nombre_Lote = Value
        End Set
    End Property

    Public Property Colindancia() As String
        Get
            Return Me._Colindancia
        End Get
        Set(ByVal Value As String)
            Me._Colindancia = Value
        End Set
    End Property

    Public Property Hectareas() As String
        Get
            Return Me._Hectareas
        End Get
        Set(ByVal Value As String)
            Me._Hectareas = Value
        End Set
    End Property

    Public Property Latitud() As String
        Get
            Return Me._Latitud
        End Get
        Set(ByVal Value As String)
            Me._Latitud = Value
        End Set
    End Property

    Public Property Longitud() As String
        Get
            Return Me._Longitud
        End Get
        Set(ByVal Value As String)
            Me._Longitud = Value
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
        Me._Nombre_Catalogo = "CAT_LOTES"
        Me._Nombre_Reporte = "RPT_CATALOGO_LOTES"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "SELECT * FROM CAT_LOTES"
        Me._QueryOrder = " Order by NOMBRE_LOTE"
    End Sub                                                         'Inicializa al objeto.

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
            .CommandText = "MP_CAT_LOTES_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_LOTE", SqlDbType.NVarChar, 2) : sqlParametro.Value = Me._Codigo_Lote.ToUpper
            sqlParametro = .Parameters.Add("@NOMBRE_LOTE", SqlDbType.NVarChar, 80) : sqlParametro.Value = Me._Nombre_Lote.ToString.ToUpper
            sqlParametro = .Parameters.Add("@ESTATUS", SqlDbType.Char, 1) : sqlParametro.Value = "A"
            sqlParametro = .Parameters.Add("@CODIGO_PLAZA", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Plaza
            sqlParametro = .Parameters.Add("@COLINDANCIA", SqlDbType.NVarChar, 200) : sqlParametro.Value = Me._Colindancia.ToString.ToUpper
            sqlParametro = .Parameters.Add("@HECTAREAS", SqlDbType.Decimal) : sqlParametro.Value = Me._Hectareas.ToString.ToUpper
            sqlParametro = .Parameters.Add("@LATITUD", SqlDbType.Decimal) : sqlParametro.Value = Me._Latitud.ToString.ToString
            sqlParametro = .Parameters.Add("@LONGITUD", SqlDbType.Decimal) : sqlParametro.Value = Me._Longitud.ToString
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
            .CommandText = "MP_CAT_LOTES_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_LOTE", SqlDbType.NVarChar, 4) : sqlParametro.Value = Me._Codigo_Lote.ToUpper
            sqlParametro = .Parameters.Add("@NOMBRE_LOTE", SqlDbType.NVarChar, 80) : sqlParametro.Value = Me._Nombre_Lote.ToString.ToUpper
            sqlParametro = .Parameters.Add("@ESTATUS", SqlDbType.Char, 1) : sqlParametro.Value = Me.Estatus.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_PLAZA", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Plaza
            sqlParametro = .Parameters.Add("@COLINDANCIA", SqlDbType.NVarChar, 200) : sqlParametro.Value = Me._Colindancia.ToString.ToUpper
            sqlParametro = .Parameters.Add("@HECTAREAS", SqlDbType.Decimal) : sqlParametro.Value = Me._Hectareas.ToString.ToUpper
            sqlParametro = .Parameters.Add("@LATITUD", SqlDbType.Decimal) : sqlParametro.Value = Me._Latitud.ToString.ToString
            sqlParametro = .Parameters.Add("@LONGITUD", SqlDbType.Decimal) : sqlParametro.Value = Me._Longitud.ToString
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
        Dim cmd As New SqlCommand("Select * from CAT_LOTES Where Codigo_LOTE='" & Replace(Me._Codigo_Lote, "'", "''") & "'  AND CODIGO_PLAZA=" & Plaza.CODIGO_PLAZA.ToString, Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._Codigo_Lote = "" & dReader("CODIGO_LOTE").ToString
                    Me._Nombre_Lote = Trim("" & dReader("NOMBRE_LOTE").ToString)
                    Me.Estatus = "" & dReader("ESTATUS").ToString
                    Me._Colindancia = Trim("" & dReader("COLINDANCIA").ToString)
                    Me._Hectareas = "" & dReader("HECTAREAS")
                    Me._Latitud = "" & dReader("LATITUD")
                    Me._Longitud = "" & dReader("LONGITUD")
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
        Dim da As New SqlDataAdapter(Me._QuerySelect & " WHERE CODIGO_PLAZA=" & Plaza.CODIGO_PLAZA & Me._QueryOrder, Me._Conexion)
        Try
            da.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementos", ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerElementosActivos() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter("Select CODIGO_LOTE,NOMBRE_LOTE FROM CAT_LOTES WHERE CODIGO_PLAZA=" & Plaza.CODIGO_PLAZA & " AND ESTATUS='A' ORDER BY NOMBRE_LOTE ", Me._Conexion)
        Try
            da.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementosActivos", ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerElementosParaReportes() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter("Select CODIGO_LOTE,NOMBRE_LOTE FROM CAT_LOTES WHERE CODIGO_PLAZA=" & Plaza.CODIGO_PLAZA & " ORDER BY NOMBRE_LOTE ", Me._Conexion)
        Try
            da.Fill(dTable)
            dTable.Rows.Add("", "TODOS")
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementosParaReportes", ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerElementosFiltro(ByVal Filtro As String, ByVal Estatus As String) As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dA As New SqlDataAdapter("Select CODIGO_LOTE,NOMBRE_LOTE FROM CAT_LOTES WHERE CODIGO_PLAZA=" & Plaza.CODIGO_PLAZA & " AND NOMBRE_LOTE LIKE '" & Filtro.ToString & "%' AND ESTATUS='" & Estatus & "' ORDER BY NOMBRE_LOTE", Me._Conexion)
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
        f.Text = "Búsqueda de LOTES por codigo."
        f.sCampo = "Codigo_LOTE"
        f.sOrder = "Nombre_LOTE"
        f.sTable = "CAT_LOTES"
        f.sQl = "Select Codigo_LOTE,Nombre_LOTE From CAT_LOTES  WHERE 1=1 AND CODIGO_PLAZA=" & Plaza.CODIGO_PLAZA & "  And"
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
        f.Text = "Búsqueda de LOTES por Descripción."
        f.sCampo = "Nombre_LOTE"
        f.sOrder = "Nombre_LOTE"
        f.sTable = "CAT_LOTES"
        f.sQl = "Select Codigo_LOTE,Nombre_LOTE From CAT_LOTES Where 1=1 AND CODIGO_PLAZA=" & Plaza.CODIGO_PLAZA & "  And"
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
        Dim iLote As Integer, sLote As String
        Dim Resultado As String = ""
        Try
            Dim sql As New Class_find("SELECT MAX(CODIGO_LOTE) FROM CAT_LOTES")
            If sql.Result1 = "" Then
                iLote = 1
            Else
                iLote = CType(sql.Result1, Integer) + 1
            End If
            sLote = "00" + iLote.ToString
            Resultado = sLote.Substring(Len(sLote) - 2)
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
