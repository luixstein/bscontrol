Imports System.Data
Imports System.Data.SqlClient

Public Class Class_CatEmpaques
    Inherits Class_Catalogos

#Region "Campos"

#Region "Campos de la tabla"
    Private _Codigo_Empaque As String
    Private _Nombre_Empaque As String
    Private _Codigo_Almacen As String
    Private _Codigo_Centro_Costo As String
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
    Public Property Codigo_Empaque() As String
        Get
            Return Me._Codigo_Empaque
        End Get
        Set(ByVal Value As String)
            Me._Codigo_Empaque = Value
        End Set
    End Property

    Public Property Nombre_Empaque() As String
        Get
            Return Me._Nombre_Empaque
        End Get
        Set(ByVal Value As String)
            Me._Nombre_Empaque = Value
        End Set
    End Property

    Public Property Codigo_Almacen() As String
        Get
            Return Me._Codigo_Almacen
        End Get
        Set(ByVal Value As String)
            Me._Codigo_Almacen = Value
        End Set
    End Property

    Public Property Codigo_Centro_Costo() As String
        Get
            Return Me._Codigo_Centro_Costo
        End Get
        Set(ByVal Value As String)
            Me._Codigo_Centro_Costo = Value
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
        Me._Nombre_Catalogo = "CAT_Empaques"
        Me._Nombre_Reporte = "RPT_CATALOGO_EMPAQUES"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "Select Codigo_Empaque,Nombre_Empaque From CAT_Empaques"
        Me._QueryOrder = " Order by Nombre_Empaque"
    End Sub

    Public Sub New(ByVal sCodigoEmpaque As String)
        Me.New()
        Try
            Me._Codigo_Empaque = sCodigoEmpaque
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
            .CommandText = "MP_CAT_EMPAQUES_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_EMPAQUE", SqlDbType.NVarChar, 2) : sqlParametro.Value = Me._Codigo_Empaque.ToUpper
            sqlParametro = .Parameters.Add("@NOMBRE_EMPAQUE", SqlDbType.NVarChar, 80) : sqlParametro.Value = Me._Nombre_Empaque.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_ALMACEN", SqlDbType.NVarChar, 80) : sqlParametro.Value = Me._Codigo_Almacen.ToString.ToUpper
            sqlParametro = .Parameters.Add("@Estatus", SqlDbType.Char, 1) : sqlParametro.Value = "A"
            sqlParametro = .Parameters.Add("@AGREGAR", SqlDbType.Char, 1) : sqlParametro.Value = "1"
            sqlParametro = .Parameters.Add("@CODIGO_CENTRO_COSTO", SqlDbType.SmallInt) : sqlParametro.Value = Me._Codigo_Centro_Costo
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
            .CommandText = "MP_CAT_EMPAQUES_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_EMPAQUE", SqlDbType.NVarChar, 4) : sqlParametro.Value = Me._Codigo_Empaque.ToUpper
            sqlParametro = .Parameters.Add("@NOMBRE_EMPAQUE", SqlDbType.NVarChar, 80) : sqlParametro.Value = Me._Nombre_Empaque.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_ALMACEN", SqlDbType.NVarChar, 80) : sqlParametro.Value = Me._Codigo_Almacen.ToString.ToUpper
            sqlParametro = .Parameters.Add("@ESTATUS", SqlDbType.Char, 1) : sqlParametro.Value = Me.Estatus.ToString.ToUpper
            sqlParametro = .Parameters.Add("@AGREGAR", SqlDbType.Char, 1) : sqlParametro.Value = "0"
            sqlParametro = .Parameters.Add("@CODIGO_CENTRO_COSTO", SqlDbType.SmallInt) : sqlParametro.Value = Me._Codigo_Centro_Costo
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
        Dim cmd As New SqlCommand("Select * from Cat_EMPAQUES Where Codigo_EMPAQUE='" & Replace(Me._Codigo_Empaque, "'", "''") & "'", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._Codigo_Empaque = "" & dReader("CODIGO_EMPAQUE").ToString
                    Me._Nombre_Empaque = Trim("" & dReader("NOMBRE_EMPAQUE").ToString)
                    Me._Codigo_Almacen = Trim("" & dReader("CODIGO_ALMACEN").ToString)
                    Me.Estatus = "" & dReader("ESTATUS").ToString
                    Me._Codigo_Centro_Costo = "" & dReader("CODIGO_CENTRO_COSTO").ToString
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
        Dim da As New SqlDataAdapter("Select Codigo_Empaque,Nombre_Empaque From CAT_Empaques WHERE ESTATUS='A' " & Me._QueryOrder, Me._Conexion)
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

    Public Function ObtenerElementosParaCapturaPalets() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter("SELECT E.CODIGO_EMPAQUE,E.NOMBRE_EMPAQUE " & _
                                     "FROM CAT_EMPAQUES E INNER JOIN CAT_ALMACENES A ON(E.CODIGO_ALMACEN=A.CODIGO_ALMACEN) " & _
                                    "INNER JOIN CAT_ZONAS Z ON(A.CODIGO_ZONA=Z.CODIGO_ZONA) " & _
                                    "WHERE E.ESTATUS='A' AND Z.CODIGO_PLAZA=" & Usuario.Codigo_Plaza, Me._Conexion)
        Try
            da.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementosParaCapturaPalets", ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerElementosFiltro(ByVal Filtro As String, ByVal Estatus As String) As System.Data.DataTable
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter("SELECT CODIGO_EMPAQUE, NOMBRE_EMPAQUE FROM CAT_EMPAQUES WHERE NOMBRE_EMPAQUE LIKE '" & Filtro.ToString & "%' AND ESTATUS='" & Estatus & "' ORDER BY NOMBRE_EMPAQUE", Me._Conexion)
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
        f.Text = "Búsqueda de empaque por codigo."
        f.sCampo = "Codigo_EMPAQUE"
        f.sOrder = "Nombre_EMPAQUE"
        f.sTable = "CAT_EMPAQUES"
        f.sQl = "Select Codigo_EMPAQUE,Nombre_EMPAQUE From CAT_EMPAQUES Where 1=1 And"
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
        f.Text = "Búsqueda de Lineas por Descripción."
        f.sCampo = "Nombre_EMPAQUE"
        f.sOrder = "Nombre_EMPAQUE"
        f.sTable = "CAT_EMPAQUES"
        f.sQl = "Select Codigo_EMPAQUE,Nombre_EMPAQUE From CAT_EMPAQUES Where 1=1 And"
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
        Dim iEMPAQUE As Integer, sEmpaque As String
        Dim Resultado As String = ""
        Try
            Dim sql As New Class_find("SELECT MAX(CODIGO_EMPAQUE) FROM CAT_EMPAQUES")
            If sql.Result1 = "" Then
                iEMPAQUE = 1
            Else
                iEMPAQUE = CType(sql.Result1, Integer) + 1
            End If
            sEmpaque = "00" + iEMPAQUE.ToString
            Resultado = sEmpaque.Substring(Len(sEmpaque) - 2)
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "BusquedaVisual_PorDescripcion", ex)
        End Try
        Return Resultado
    End Function
#End Region

End Class