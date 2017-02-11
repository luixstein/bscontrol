Imports System.Data
Imports System.Data.SqlClient

Public Class Class_CatLineas
    Inherits Class_Catalogos

#Region "Campos"

#Region "Campos de la tabla"
    Private _Codigo_Linea As String
    Private _Nombre_Linea As String
    Private _CODIGO_CONCEPTO As String
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
    Public Property Codigo_Linea() As String
        Get
            Return Me._Codigo_Linea
        End Get
        Set(ByVal Value As String)
            Me._Codigo_Linea = Value
        End Set
    End Property

    Public Property Nombre_Linea() As String
        Get
            Return Me._Nombre_Linea
        End Get
        Set(ByVal Value As String)
            Me._Nombre_Linea = Value
        End Set
    End Property

    Public Property CODIGO_CONCEPTO() As String
        Get
            Return Me._CODIGO_CONCEPTO
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_CONCEPTO = Value
        End Set
    End Property

#End Region

#Region "Propiedades de campos ligados a la tabla"
    Private _Existe As Boolean 'lectura
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
        Me._Nombre_Catalogo = "CAT_Lineas"
        Me._Nombre_Reporte = "RPT_CATALOGO_LINEAS"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "Select Codigo_Linea,Nombre_Linea From CAT_Lineas"
        Me._QueryOrder = " Order by Nombre_Linea"
    End Sub

    Public Sub New(ByVal sCodigoLinea As String)
        Me.New()
        Try
            Me.Codigo_Linea = sCodigoLinea
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
            .CommandText = "MP_CAT_LINEAS_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_LINEA", SqlDbType.NVarChar, 4) : sqlParametro.Value = Me._Codigo_Linea.ToUpper
            sqlParametro = .Parameters.Add("@NOMBRE_LINEA", SqlDbType.NVarChar, 30) : sqlParametro.Value = Me._Nombre_Linea.ToString.ToUpper
            sqlParametro = .Parameters.Add("@Estatus", SqlDbType.Char, 1) : sqlParametro.Value = "A"
            sqlParametro = .Parameters.Add("@AGREGAR", SqlDbType.Char, 1) : sqlParametro.Value = "1"
            sqlParametro = .Parameters.Add("@CODIGO_CONCEPTO", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_CONCEPTO
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
            .CommandText = "MP_CAT_LINEAS_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_LINEA", SqlDbType.NVarChar, 4) : sqlParametro.Value = Me._Codigo_Linea.ToUpper
            sqlParametro = .Parameters.Add("@NOMBRE_LINEA", SqlDbType.NVarChar, 30) : sqlParametro.Value = Me._Nombre_Linea.ToString.ToUpper
            sqlParametro = .Parameters.Add("@ESTATUS", SqlDbType.Char, 1) : sqlParametro.Value = Me.Estatus.ToString.ToUpper
            sqlParametro = .Parameters.Add("@AGREGAR", SqlDbType.Char, 1) : sqlParametro.Value = "0"
            sqlParametro = .Parameters.Add("@CODIGO_CONCEPTO", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_CONCEPTO
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
        Dim cmd As New SqlCommand("Select * from Cat_Lineas Where Codigo_Linea='" & Replace(Me._Codigo_Linea, "'", "''") & "'", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._Codigo_Linea = "" & dReader("CODIGO_LINEA").ToString
                    Me._Nombre_Linea = Trim("" & dReader("NOMBRE_LINEA").ToString)
                    Me.Estatus = "" & dReader("ESTATUS").ToString
                    Me._CODIGO_CONCEPTO = "" & dReader("CODIGO_CONCEPTO").ToString
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
        Dim dsCAT_Lineas As New SqlDataAdapter(Me._QuerySelect & Me._QueryOrder, Me._Conexion)
        Try
            dsCAT_Lineas.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementos", ex)
        Finally
            dsCAT_Lineas.Dispose()
        End Try
        Return dTable
    End Function    'Obtiene una lita completa de los elementos del catalogo en un datatable.

    Public Function ObtenerElementosFiltro(ByVal Filtro As String, ByVal Estatus As String) As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dA As New SqlDataAdapter("SELECT CODIGO_LINEA, NOMBRE_LINEA FROM CAT_LINEAS WHERE NOMBRE_LINEA LIKE '" & Filtro.ToString & "%' AND ESTATUS='" & Estatus & "' ORDER BY NOMBRE_LINEA", Me._Conexion)
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
        f.sCampo = "Codigo_Linea"
        f.sOrder = "Nombre_Linea"
        f.sTable = "CAT_Lineas"
        f.sQl = "Select Codigo_Linea,Nombre_Linea From CAT_Lineas Where 1=1 And"
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
        f.sCampo = "Nombre_Linea"
        f.sOrder = "Nombre_Linea"
        f.sTable = "CAT_Lineas"
        f.sQl = "Select Codigo_Linea,Nombre_Linea From CAT_Lineas Where 1=1 And"
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
        Dim iLinea As Integer, sLinea As String
        Dim Resultado As String = ""
        Try
            iLinea = Empresa_Sistema.CODIGO_LINEA
            iLinea = iLinea + 1
            sLinea = "0000" + iLinea.ToString
            Resultado = sLinea.Substring(Len(sLinea) - 4)
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "CodigoSiguiente", ex)
        End Try
        Return Resultado
    End Function
#End Region

End Class



