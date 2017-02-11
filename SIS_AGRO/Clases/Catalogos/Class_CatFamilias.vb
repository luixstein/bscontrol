Imports System.Data
Imports System.Data.SqlClient

Public Class Class_CatFamilias
    Inherits Class_Catalogos

#Region "Campos"

#Region "Campos de la tabla"
    Private _Codigo_Familia As String
    Private _Nombre_Familia As String
    'Private _Codigo_Concepto_Costos_Produccion As String
    Private _CODIGO_CATEGORIA As String
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
    Public Property Codigo_Familia() As String
        Get
            Return Me._Codigo_Familia
        End Get
        Set(ByVal Value As String)
            Me._Codigo_Familia = Value
        End Set
    End Property

    Public Property Nombre_Familia() As String
        Get
            Return Me._Nombre_Familia
        End Get
        Set(ByVal Value As String)
            Me._Nombre_Familia = Value
        End Set
    End Property

    'Public Property Codigo_Concepto_Costos_Produccion() As String
    '    Get
    '        Return Me._Codigo_Concepto_Costos_Produccion
    '    End Get
    '    Set(ByVal Value As String)
    '        Me._Codigo_Concepto_Costos_Produccion = Value
    '    End Set
    'End Property

    Public Property CODIGO_CATEGORIA() As String
        Get
            Return Me._CODIGO_CATEGORIA
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_CATEGORIA = Value
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
        Me._Nombre_Catalogo = "Cat_Familias"
        Me._Nombre_Reporte = "RPT_CATALOGO_FAMILIAS"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "Select CODIGO_FAMILIA,NOMBRE_FAMILIA FROM CAT_FAMILIAS"
        Me._QueryOrder = " Order by NOMBRE_FAMILIA"
    End Sub

    Public Sub New(ByVal sCodigoFamilia As String)
        Me.New()
        Try
            Me.Codigo_Familia = sCodigoFamilia
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
            .CommandText = "MP_CAT_FAMILIAS_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_FAMILIA", SqlDbType.NVarChar, 4) : sqlParametro.Value = Me._Codigo_Familia
            sqlParametro = .Parameters.Add("@NOMBRE_FAMILIA", SqlDbType.NVarChar, 30) : sqlParametro.Value = Me._Nombre_Familia.ToString.ToUpper
            sqlParametro = .Parameters.Add("@ESTATUS", SqlDbType.Char, 1) : sqlParametro.Value = Me.Estatus.ToString.ToUpper
            sqlParametro = .Parameters.Add("@AGREGAR", SqlDbType.Char, 1) : sqlParametro.Value = "1"
            'sqlParametro = .Parameters.Add("@CODIGO_CONCEPTO_COSTO_PRODUCCION", SqlDbType.NVarChar, 4) : sqlParametro.Value = ""
            sqlParametro = .Parameters.Add("@CODIGO_CATEGORIA", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_CATEGORIA
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
            .CommandText = "MP_CAT_FAMILIAS_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_FAMILIA", SqlDbType.NVarChar, 4) : sqlParametro.Value = Me._Codigo_Familia
            sqlParametro = .Parameters.Add("@NOMBRE_FAMILIA", SqlDbType.NVarChar, 30) : sqlParametro.Value = Me._Nombre_Familia.ToString.ToUpper
            sqlParametro = .Parameters.Add("@ESTATUS", SqlDbType.Char, 1) : sqlParametro.Value = Me.Estatus.ToString.ToUpper
            sqlParametro = .Parameters.Add("@AGREGAR", SqlDbType.Char, 1) : sqlParametro.Value = "0"
            'sqlParametro = .Parameters.Add("@CODIGO_CONCEPTO_COSTO_PRODUCCION", SqlDbType.NVarChar, 4) : sqlParametro.Value = ""
            sqlParametro = .Parameters.Add("@CODIGO_CATEGORIA", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_CATEGORIA

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
        Dim cmd As New SqlCommand("Select * from CAT_FAMILIAS Where CODIGO_FAMILIA=" & Replace(Me._Codigo_Familia, "'", "''") & "", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._Codigo_Familia = "" & dReader("CODIGO_FAMILIA")
                    Me._Nombre_Familia = Trim("" & dReader("NOMBRE_FAMILIA").ToString)
                    Me.Estatus = "" & dReader("ESTATUS").ToString
                    'Me._Codigo_Concepto_Costos_Produccion = "" & dReader("CODIGO_CONCEPTO_COSTO_PRODUCCION")
                    Me._Codigo_Categoria = "" & dReader("CODIGO_CATEGORIA")
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
        Dim da As New SqlDataAdapter("Select CODIGO_FAMILIA,NOMBRE_FAMILIA from CAT_FAMILIAS order by NOMBRE_FAMILIA", Me._Conexion)
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
        Dim da As New SqlDataAdapter("Select CODIGO_FAMILIA,NOMBRE_FAMILIA from CAT_FAMILIAS order by NOMBRE_FAMILIA", Me._Conexion)
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

    Public Function ObtenerElementosFiltro(ByVal Filtro As String, ByVal Estatus As String) As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dA As New SqlDataAdapter("SELECT CODIGO_FAMILIA,NOMBRE_FAMILIA from CAT_FAMILIAS WHERE NOMBRE_FAMILIA LIKE '" & Filtro.ToString & "%' AND ESTATUS ='" & Estatus & "' ORDER BY NOMBRE_FAMILIA", Me._Conexion)
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

    Public Function CodigoSiguiente() As String
        Dim iFamilia As Integer, sFamilia As String
        Dim Resultado As String = ""
        Try
            iFamilia = Empresa_Sistema.CODIGO_FAMILIA
            iFamilia = iFamilia + 1
            sFamilia = "0000" + iFamilia.ToString
            Resultado = sFamilia.Substring(Len(sFamilia) - 4)
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "CodigoSiguiente", ex)
        End Try
        Return Resultado
    End Function
#End Region

End Class