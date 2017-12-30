Option Strict On
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class Class_CatCultivos

#Region "Campos"

#Region "Campos de la tabla"
    Private _CODIGO_CULTIVO As String
    Private _NOMBRE_CULTIVO As String
    Private _CUENTA_CONTABLE_COSTOS_DIRECTOS_PRODUCCION As String
    Private _CUENTA_CONTABLE_PREDIO As String
    Private _ALIAS_NACIONAL As String
    Private _ALIAS_EXTRANJERO As String
    Private _CUENTA_CONTABLE_BASE As String
    Private _CODIGO_PLAZA As Integer
    Private _FRACCION_ARANCELARIA As String
    Private _CODIGO_PRODUCTO_SERVICIO As String
    Private _ESTATUS As String
#End Region

#Region "Campos ligados a la tabla"
    Private _ES_GENERICO As String
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
    Public Property CODIGO_CULTIVO() As String
        Get
            Return Me._CODIGO_CULTIVO
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_CULTIVO = Value
        End Set
    End Property

    Public Property NOMBRE_CULTIVO() As String
        Get
            Return Me._NOMBRE_CULTIVO
        End Get
        Set(ByVal Value As String)
            Me._NOMBRE_CULTIVO = Value
        End Set
    End Property

    Public Property CUENTA_CONTABLE_COSTOS_DIRECTOS_PRODUCCION() As String
        Get
            Return Me._CUENTA_CONTABLE_COSTOS_DIRECTOS_PRODUCCION
        End Get
        Set(ByVal Value As String)
            Me._CUENTA_CONTABLE_COSTOS_DIRECTOS_PRODUCCION = Value
        End Set
    End Property

    Public Property CUENTA_CONTABLE_PREDIO() As String
        Get
            Return Me._CUENTA_CONTABLE_PREDIO
        End Get
        Set(ByVal Value As String)
            Me._CUENTA_CONTABLE_PREDIO = Value
        End Set
    End Property

    Public Property ALIAS_NACIONAL() As String
        Get
            Return Me._ALIAS_NACIONAL
        End Get
        Set(ByVal Value As String)
            Me._ALIAS_NACIONAL = Value
        End Set
    End Property

    Public Property ALIAS_EXTRANJERO() As String
        Get
            Return Me._ALIAS_EXTRANJERO
        End Get
        Set(ByVal Value As String)
            Me._ALIAS_EXTRANJERO = Value
        End Set
    End Property

    Public Property CUENTA_CONTABLE_BASE() As String
        Get
            Return Me._CUENTA_CONTABLE_BASE
        End Get
        Set(ByVal Value As String)
            Me._CUENTA_CONTABLE_BASE = Value
        End Set
    End Property

    Public Property CODIGO_PLAZA() As Integer
        Get
            Return Me._CODIGO_PLAZA
        End Get
        Set(ByVal Value As Integer)
            Me._CODIGO_PLAZA = Value
        End Set
    End Property

    Public Property FRACCION_ARANCELARIA() As String
        Get
            Return Me._FRACCION_ARANCELARIA
        End Get
        Set(ByVal Value As String)
            Me._FRACCION_ARANCELARIA = Value
        End Set
    End Property

    Public Property CODIGO_PRODUCTO_SERVICIO() As String
        Get
            Return Me._CODIGO_PRODUCTO_SERVICIO
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_PRODUCTO_SERVICIO = Value
        End Set
    End Property

    Public Property ESTATUS() As String
        Get
            Return Me._ESTATUS
        End Get
        Set(ByVal value As String)
            Me._ESTATUS = value
        End Set
    End Property

#End Region

#Region "Propiedades de campos ligados a la tabla"
    Public WriteOnly Property ES_GENERICO() As String
        Set(ByVal Value As String)
            Me._ES_GENERICO = Value
        End Set
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
        Me._Nombre_Catalogo = "CAT_CULTIVOS"
        Me._Nombre_Reporte = "RPT_CATALOGO_CULTIVOS"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "SELECT CODIGO_CULTIVO,NOMBRE_CULTIVO,CUENTA_CONTABLE_COSTOS_DIRECTOS_PRODUCCION,CUENTA_CONTABLE_PREDIO," &
        "ALIAS_NACIONAL,ALIAS_EXTRANJERO, CUENTA_CONTABLE_BASE,CODIGO_PLAZA,FRACCION_ARANCELARIA FROM CAT_CULTIVOS"
        Me._QueryOrder = " ORDER BY NOMBRE_CULTIVO"
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
            .CommandText = "MP_CAT_CULTIVOS_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_CULTIVO", SqlDbType.NVarChar, 4) : sqlParametro.Direction = ParameterDirection.InputOutput : sqlParametro.Value = Me._CODIGO_CULTIVO
            sqlParametro = .Parameters.Add("@NOMBRE_CULTIVO", SqlDbType.NVarChar, 120) : sqlParametro.Value = Me._NOMBRE_CULTIVO.ToUpper
            sqlParametro = .Parameters.Add("@CUENTA_CONTABLE_PREDIO", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._CUENTA_CONTABLE_PREDIO.ToUpper
            sqlParametro = .Parameters.Add("@ALIAS_NACIONAL", SqlDbType.NVarChar, 80) : sqlParametro.Value = Me._ALIAS_NACIONAL.ToUpper
            sqlParametro = .Parameters.Add("@ALIAS_EXTRANJERO", SqlDbType.NVarChar, 50) : sqlParametro.Value = Me._ALIAS_EXTRANJERO.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_PLAZA", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Plaza
            sqlParametro = .Parameters.Add("@ES_GENERICO", SqlDbType.Char, 1) : sqlParametro.Value = Me._ES_GENERICO.ToString
            sqlParametro = .Parameters.Add("@FRACCION_ARANCELARIA", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._FRACCION_ARANCELARIA.ToUpper
            sqlParametro = .Parameters.Add("@AGREGAR", SqlDbType.Char, 1) : sqlParametro.Value = "1"

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                Me._CODIGO_CULTIVO = .Parameters("@CODIGO_CULTIVO").Value.ToString
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
            .CommandText = "MP_CAT_CULTIVOS_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_CULTIVO", SqlDbType.NVarChar, 4) : sqlParametro.Direction = ParameterDirection.InputOutput : sqlParametro.Value = Me._CODIGO_CULTIVO
            sqlParametro = .Parameters.Add("@NOMBRE_CULTIVO", SqlDbType.NVarChar, 120) : sqlParametro.Value = Me._NOMBRE_CULTIVO.ToUpper
            sqlParametro = .Parameters.Add("@CUENTA_CONTABLE_PREDIO", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._CUENTA_CONTABLE_PREDIO.ToUpper
            sqlParametro = .Parameters.Add("@ALIAS_NACIONAL", SqlDbType.NVarChar, 80) : sqlParametro.Value = Me._ALIAS_NACIONAL.ToUpper
            sqlParametro = .Parameters.Add("@ALIAS_EXTRANJERO", SqlDbType.NVarChar, 50) : sqlParametro.Value = Me._ALIAS_EXTRANJERO.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_PLAZA", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Plaza
            sqlParametro = .Parameters.Add("@ES_GENERICO", SqlDbType.Char, 1) : sqlParametro.Value = Me._ES_GENERICO.ToString
            sqlParametro = .Parameters.Add("@FRACCION_ARANCELARIA", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._FRACCION_ARANCELARIA.ToUpper
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

    Public Function Consultar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand(Me._QuerySelect & " Where CODIGO_CULTIVO='" & Me._CODIGO_CULTIVO.ToString & "' AND CODIGO_PLAZA=" & Usuario.Codigo_Plaza.ToString, Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._CODIGO_CULTIVO = dReader("CODIGO_CULTIVO").ToString()
                    Me._NOMBRE_CULTIVO = "" & dReader("NOMBRE_CULTIVO").ToString()
                    Me._CUENTA_CONTABLE_PREDIO = "" & dReader("CUENTA_CONTABLE_PREDIO").ToString()
                    Me._ALIAS_NACIONAL = "" & dReader("ALIAS_NACIONAL").ToString()
                    Me._ALIAS_EXTRANJERO = "" & dReader("ALIAS_EXTRANJERO").ToString()
                    Me._CUENTA_CONTABLE_COSTOS_DIRECTOS_PRODUCCION = "" & dReader("CUENTA_CONTABLE_COSTOS_DIRECTOS_PRODUCCION").ToString()
                    Me._CODIGO_PLAZA = CInt(dReader("CODIGO_PLAZA").ToString)
                    Me._FRACCION_ARANCELARIA = "" & dReader("FRACCION_ARANCELARIA").ToString()
                    Me._CODIGO_PRODUCTO_SERVICIO = "" & dReader("CODIGO_PRODUCTO_SERVICIO").ToString()
                    Me._ESTATUS = dReader("ESTATUS").ToString()

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
        Dim da As New SqlDataAdapter("Select CODIGO_CULTIVO,CASE WHEN LEN(ALIAS_NACIONAL)>0 THEN ALIAS_NACIONAL ELSE NOMBRE_CULTIVO END NOMBRE_CULTIVO FROM CAT_CULTIVOS WHERE CODIGO_PLAZA=" & Usuario.Codigo_Plaza.ToString & " ORDER BY NOMBRE_CULTIVO ", Me._Conexion)
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
        Dim da As New SqlDataAdapter("Select CODIGO_CULTIVO,NOMBRE_CULTIVO FROM CAT_CULTIVOS WHERE CODIGO_PLAZA=" & Usuario.Codigo_Plaza.ToString & " ORDER BY NOMBRE_CULTIVO ", Me._Conexion)
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

    Public Function ObtenerElementosParaCatalogos() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter("Select CODIGO_CULTIVO,CASE WHEN LEN(ALIAS_NACIONAL)>0 THEN ALIAS_NACIONAL ELSE NOMBRE_CULTIVO END NOMBRE_CULTIVO FROM CAT_CULTIVOS WHERE CODIGO_PLAZA=" & Usuario.Codigo_Plaza.ToString & " ORDER BY NOMBRE_CULTIVO ", Me._Conexion)
        Try
            da.Fill(dTable)
            dTable.Rows.Add("", "")
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementosParaCatalogos", ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerElementosFiltro(ByVal Filtro As String) As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dA As New SqlDataAdapter("Select CODIGO_CULTIVO,CASE WHEN LEN(ALIAS_NACIONAL)>0 THEN ALIAS_NACIONAL ELSE NOMBRE_CULTIVO END NOMBRE_CULTIVO FROM CAT_CULTIVOS WHERE CODIGO_PLAZA=" & Usuario.Codigo_Plaza.ToString & " AND NOMBRE_CULTIVO LIKE '" & Filtro.ToString & "%' ORDER BY NOMBRE_CULTIVO", Me._Conexion)
        Try
            dA.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementosFiltro", ex)
        Finally
            dA.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerSemanas(ByVal sSemana As String) As System.Data.DataTable
        Dim dTable As New DataTable
        Dim sSql As String
        If sSemana = "1" Then
            sSql = "SELECT REPLACE(LEFT(CAST(((NUMERO_SEMANA/100.00)+AÑO) AS NVARCHAR),7),'.','-') SEMANA,FECHA1,FECHA2  FROM EMB_CAT_RANGOS_LOTES_MASTRONARDI order by REPLACE(LEFT(CAST(((NUMERO_SEMANA/100.00)+AÑO) AS NVARCHAR),7),'.','-')"
        Else
            sSql = "SELECT REPLACE(LEFT(CAST(((NUMERO_SEMANA/100.00)+AÑO) AS NVARCHAR),7),'.','-') SEMANA,FECHA2 FROM EMB_CAT_RANGOS_LOTES_MASTRONARDI order by REPLACE(LEFT(CAST(((NUMERO_SEMANA/100.00)+AÑO) AS NVARCHAR),7),'.','-')"
        End If
        Dim da As New SqlDataAdapter(sSql, Me._Conexion)
        Try
            da.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerSemanas", ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

    Public Function CodigoSiguiente() As String
        Dim iCultivo As Integer, sCultivo As String
        Dim Resultado As String = ""
        Try
            Dim sql As New Class_find("SELECT MAX(CAST(CODIGO_CULTIVO AS INT)) FROM CAT_CULTIVOS")
            If sql.Result1 = "" Then
                iCultivo = 1
            Else
                iCultivo = CType(sql.Result1, Integer) + 1
            End If
            sCultivo = "0000" + iCultivo.ToString
            Resultado = sCultivo.Substring(Len(sCultivo) - 4)

        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "CodigoSiguiente", ex)
        End Try
        Return Resultado
    End Function

    Public Function BusquedaVisual_PorCodigo() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de cultivos por Código."
        f.sCampo = "CODIGO_CULTIVO"
        f.sOrder = "NOMBRE_CULTIVO"
        f.sTable = "CAT_CULTIVOS"
        f.sQl = "SELECT CODIGO_CULTIVO, NOMBRE_CULTIVO FROM CAT_CULTIVOS WHERE 1=1 AND CODIGO_PLAZA=" & Usuario.Codigo_Plaza.ToString & " AND"
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
        f.Text = "Búsqueda de cultivos por Nombre."
        f.sCampo = "NOMBRE_CULTIVO"
        f.sOrder = "NOMBRE_CULTIVO"
        f.sTable = "CAT_CULTIVOS"
        f.sQl = "SELECT CODIGO_CULTIVO, NOMBRE_CULTIVO FROM CAT_CULTIVOS WHERE 1=1 AND CODIGO_PLAZA=" & Usuario.Codigo_Plaza.ToString & " AND"
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

    Public Sub Imprimir_Listado()   'Función para ver la búsqueda visual por descripción.
        If Len(Nombre_Reporte) > 0 Then
            Dim Rpt As New ReportDocument
            Dim oReporte As Class_Reporte
            Try
                oReporte = New Class_Reporte(Nombre_Reporte, Rpt)

                Dim frm As New Reporte(Rpt)
                frm.CRViewer.ShowGroupTreeButton = False
                frm.CRViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                frm.Show()

            Catch ex As Exception
                HandleError(Me.Nombre_Catalogo, " Impresión del listado :" + Me.Nombre_Catalogo, ex)
            Finally
                oReporte = Nothing
                'Rpt.Dispose()
            End Try
        Else
            MsgBox("El nombre del reporte no ha sido especificado, no hay nada que imprimir.", MsgBoxStyle.Critical, Me.Nombre_Catalogo)
        End If
    End Sub
#End Region

End Class
