Imports System.Data
Imports System.Data.SqlClient

Public Class Class_CatLineas
    Inherits Class_Catalogos

#Region "Campos"

#Region "Campos de la tabla"
    Private _CODIGO_LINEA As String
    Private _NOMBRE_LINEA As String
    Private _CODIGO_CONCEPTO As String
#End Region

#Region "Campos ligados a la tabla"
    Private _GENERAR_CONCEPTO As Boolean
#End Region

#Region "Campos públicos"

#End Region

#Region "Campos privados"

#End Region

#Region "Campos de sistema"
    Private _Nombre_Catalogo As String
    Private _Nombre_Reporte As String
    Private _Conexion As SqlConnection
    Private _QuerySELECT As String
    Private _QueryOrder As String

#End Region

#End Region

#Region "Propiedades"

#Region "Propiedades Campos de la tabla"
    Public Property CODIGO_LINEA() As String
        Get
            Return Me._CODIGO_LINEA
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_LINEA = Value
        End Set
    End Property

    Public Property NOMBRE_LINEA() As String
        Get
            Return Me._NOMBRE_LINEA
        End Get
        Set(ByVal Value As String)
            Me._NOMBRE_LINEA = Value
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

    Public WriteOnly Property GENERAR_CONCEPTO() As Boolean
        Set(ByVal Value As Boolean)
            Me._GENERAR_CONCEPTO = Value
        End Set
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
        Me._Nombre_Catalogo = "CAT_LINEAS"
        Me._Nombre_Reporte = "RPT_CATALOGO_LINEAS"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySELECT = "SELECT CODIGO_LINEA,NOMBRE_LINEA From CAT_LINEAS"
        Me._QueryOrder = " Order by NOMBRE_LINEA"
    End Sub

    Public Sub New(ByVal sCodigoLinea As String)
        Me.New()
        Try
            Me.CODIGO_LINEA = sCodigoLinea
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

            sqlParametro = .Parameters.Add("@CODIGO_LINEA", SqlDbType.NVarChar, 4) : sqlParametro.Value = Me._CODIGO_LINEA.ToUpper : sqlParametro.Direction = ParameterDirection.InputOutput
            sqlParametro = .Parameters.Add("@NOMBRE_LINEA", SqlDbType.NVarChar, 30) : sqlParametro.Value = Me._NOMBRE_LINEA.ToString.ToUpper
            sqlParametro = .Parameters.Add("@ESTATUS", SqlDbType.Char, 1) : sqlParametro.Value = "A"
            sqlParametro = .Parameters.Add("@CODIGO_CONCEPTO", SqlDbType.SmallInt) : sqlParametro.Value = CInt(valorNumerico(Me._CODIGO_CONCEPTO)) : sqlParametro.Direction = ParameterDirection.InputOutput
            sqlParametro = .Parameters.Add("@GENERAR_CONCEPTO", SqlDbType.Char, 1) : sqlParametro.Value = Convert.ToInt32(Me._GENERAR_CONCEPTO)
            sqlParametro = .Parameters.Add("@AGREGAR", SqlDbType.Char, 1) : sqlParametro.Value = "1"

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
                Me._CODIGO_LINEA = "" & .Parameters("@CODIGO_LINEA").Value.ToString
                Me._CODIGO_CONCEPTO = "" & .Parameters("@CODIGO_CONCEPTO").Value.ToString
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

            sqlParametro = .Parameters.Add("@CODIGO_LINEA", SqlDbType.NVarChar, 4) : sqlParametro.Value = Me._CODIGO_LINEA.ToUpper
            sqlParametro = .Parameters.Add("@NOMBRE_LINEA", SqlDbType.NVarChar, 30) : sqlParametro.Value = Me._NOMBRE_LINEA.ToString.ToUpper
            sqlParametro = .Parameters.Add("@ESTATUS", SqlDbType.Char, 1) : sqlParametro.Value = Me.Estatus.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_CONCEPTO", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_CONCEPTO
            sqlParametro = .Parameters.Add("@GENERAR_CONCEPTO", SqlDbType.Char, 1) : sqlParametro.Value = "0"
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
        Dim cmd As New SqlCommand("SELECT * from CAT_LINEAS WHERE CODIGO_LINEA='" & sReplace(Me._CODIGO_LINEA) & "'", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._CODIGO_LINEA = "" & dReader("CODIGO_LINEA").ToString
                    Me._NOMBRE_LINEA = Trim("" & dReader("NOMBRE_LINEA").ToString)
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
        Dim da As New SqlDataAdapter(Me._QuerySELECT & " WHERE ESTATUS='A' " & Me._QueryOrder, Me._Conexion)
        Try
            da.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementos", ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerElementosFiltro(ByVal Filtro As String, ByVal Estatus As String) As System.Data.DataTable
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter("SELECT CODIGO_LINEA,NOMBRE_LINEA FROM CAT_LINEAS WHERE NOMBRE_LINEA LIKE '" & Filtro.ToString & "%' AND ESTATUS='" & Estatus & "' ORDER BY NOMBRE_LINEA", Me._Conexion)
        Try
            da.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementosFiltro", ex)
        Finally
            dA.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerElementosParaReportes() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter(Me._QuerySELECT & Me._QueryOrder, Me._Conexion)
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
        f.Text = "Búsqueda de Metodos de Tipos de Socios por codigo."
        f.sCampo = "CODIGO_LINEA"
        f.sOrder = "NOMBRE_LINEA"
        f.sTable = "CAT_LINEAS"
        f.sQl = "SELECT CODIGO_LINEA,NOMBRE_LINEA From CAT_LINEAS WHERE 1=1 And"
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
        f.sCampo = "NOMBRE_LINEA"
        f.sOrder = "NOMBRE_LINEA"
        f.sTable = "CAT_LINEAS"
        f.sQl = "SELECT CODIGO_LINEA,NOMBRE_LINEA From CAT_LINEAS WHERE 1=1 And"
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



