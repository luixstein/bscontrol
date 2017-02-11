Imports System.Data
Imports System.Data.SqlClient

Public Class Class_CatCentroCostos
    Inherits Class_Catalogos

#Region "Campos"

#Region "Campos de la tabla"
    Private _CODIGO_CENTRO_COSTO As Integer
    Private _NOMBRE_CENTRO_COSTO As String
    Private _CUENTA_CONTABLE As String
    Private _CODIGO_CULTIVO As String
    Private _CONTABILIZAR_POR_ACTIVIDAD As Boolean

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
    Public Property CODIGO_CENTRO_COSTO() As Integer
        Get
            Return Me._CODIGO_CENTRO_COSTO
        End Get
        Set(ByVal Value As Integer)
            Me._CODIGO_CENTRO_COSTO = Value
        End Set
    End Property

    Public Property NOMBRE_CENTRO_COSTO() As String
        Get
            Return Me._NOMBRE_CENTRO_COSTO
        End Get
        Set(ByVal Value As String)
            Me._NOMBRE_CENTRO_COSTO = Value
        End Set
    End Property

    Public Property CUENTA_CONTABLE() As String
        Get
            Return Me._CUENTA_CONTABLE
        End Get
        Set(ByVal Value As String)
            Me._CUENTA_CONTABLE = Value
        End Set
    End Property

    Public Property CODIGO_CULTIVO() As String
        Get
            Return Me._CODIGO_CULTIVO
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_CULTIVO = Value
        End Set
    End Property

    Public Property CONTABILIZAR_POR_ACTIVIDAD() As Boolean
        Get
            Return Me._CONTABILIZAR_POR_ACTIVIDAD
        End Get
        Set(ByVal Value As Boolean)
            Me._CONTABILIZAR_POR_ACTIVIDAD = Value
        End Set
    End Property
#End Region

#Region "Propiedades de campos ligados a la tabla"
    Public ReadOnly Property EXISTE() As Boolean
        Get
            Return Me._EXISTE
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
#End Region

#End Region

#Region "Constructor y destructor"

    Public Sub New()
        Me._Nombre_Catalogo = "NOMINA_CAT_CENTROS_COSTOS"
        Me._Nombre_Reporte = "RPT_CATALOGO_NOMINA_CENTROS_COSTOS"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "SELECT CODIGO_CENTRO_COSTO,NOMBRE_CENTRO_COSTO,CUENTA_CONTABLE FROM NOMINA_CAT_CENTROS_COSTOS"
        Me._QueryOrder = " ORDER BY NOMBRE_CENTRO_COSTO"
    End Sub

    Public Sub New(ByVal iCodigo As Integer)
        Me.New()
        Me._CODIGO_CENTRO_COSTO = iCodigo
        Try
            If Me.Consultar = True Then
                Me._Existe = True
                'Else
                'Throw New Exception("La actividad no existe.")
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
    Public Overrides Function Insertar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_NOMINA_CAT_CENTRO_COSTO_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_CENTRO_COSTO", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_CENTRO_COSTO
            sqlParametro = .Parameters.Add("@NOMBRE_CENTRO_COSTO", SqlDbType.NVarChar, 80) : sqlParametro.Value = Me._NOMBRE_CENTRO_COSTO.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CUENTA_CONTABLE", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._CUENTA_CONTABLE.ToString.ToUpper
            sqlParametro = .Parameters.Add("@ESTATUS_CENTRO_COSTO", SqlDbType.Char, 1) : sqlParametro.Value = "A"
            sqlParametro = .Parameters.Add("@ACCION", SqlDbType.NVarChar, 15) : sqlParametro.Value = "INSERTAR"
            sqlParametro = .Parameters.Add("@CODIGO_CULTIVO", SqlDbType.NVarChar, 4) : sqlParametro.Value = Me._CODIGO_CULTIVO.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CONTABILIZAR_POR_ACTIVIDAD", SqlDbType.Char, 1) : sqlParametro.Value = Convert.ToInt32(Me._CONTABILIZAR_POR_ACTIVIDAD).ToString.ToUpper

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
            .CommandText = "MP_NOMINA_CAT_CENTRO_COSTO_GRABA" ' MP_NOMINA_CAT_CENTROS_COSTOS_GRABA

            sqlParametro = .Parameters.Add("@CODIGO_CENTRO_COSTO", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_CENTRO_COSTO
            sqlParametro = .Parameters.Add("@NOMBRE_CENTRO_COSTO", SqlDbType.NVarChar, 80) : sqlParametro.Value = Me._NOMBRE_CENTRO_COSTO.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CUENTA_CONTABLE", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._CUENTA_CONTABLE.ToString.ToUpper
            sqlParametro = .Parameters.Add("@ESTATUS_CENTRO_COSTO", SqlDbType.Char, 1) : sqlParametro.Value = Me.Estatus.ToString.ToUpper
            sqlParametro = .Parameters.Add("@ACCION", SqlDbType.NVarChar, 15) : sqlParametro.Value = "ACTUALIZAR"
            sqlParametro = .Parameters.Add("@CODIGO_CULTIVO", SqlDbType.NVarChar, 4) : sqlParametro.Value = Me._CODIGO_CULTIVO.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CONTABILIZAR_POR_ACTIVIDAD", SqlDbType.Char, 1) : sqlParametro.Value = Convert.ToInt32(Me._CONTABILIZAR_POR_ACTIVIDAD).ToString.ToUpper

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
        Dim cmd As New SqlCommand("SELECT * FROM NOMINA_CAT_CENTROS_COSTOS WHERE CODIGO_CENTRO_COSTO=" & Me._CODIGO_CENTRO_COSTO & "", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._CODIGO_CENTRO_COSTO = "" & dReader("CODIGO_CENTRO_COSTO").ToString
                    Me._NOMBRE_CENTRO_COSTO = Trim("" & dReader("NOMBRE_CENTRO_COSTO").ToString)
                    Me._CUENTA_CONTABLE = Trim("" & dReader("CUENTA_CONTABLE").ToString)
                    Me._CODIGO_CULTIVO = Trim("" & dReader("CODIGO_CULTIVO").ToString)
                    Me.Estatus = "" & dReader("ESTATUS_CENTRO_COSTO").ToString
                    Me._CONTABILIZAR_POR_ACTIVIDAD = CBool(dReader("CONTABILIZAR_POR_ACTIVIDAD").ToString)

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
        'Dim dsCat_CentroCosto As New SqlDataAdapter(Me._QuerySelect & " where ESTATUS_CENTRO_COSTO='A' " & Me._QueryOrder, Me._Conexion)
        'Activar y desactivar la otra linea despues de reprocesar centros de costos
        Dim da As New SqlDataAdapter("SELECT CODIGO_CENTRO_COSTO,NOMBRE_CENTRO_COSTO FROM NOMINA_CAT_CENTROS_COSTOS " & Me._QueryOrder, Me._Conexion)
        Try
            da.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementos", ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerElementosEstatus(ByVal Estatus As String) As System.Data.DataTable
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter("SELECT CODIGO_CENTRO_COSTO,NOMBRE_CENTRO_COSTO FROM NOMINA_CAT_CENTROS_COSTOS WHERE ESTATUS_CENTRO_COSTO='" & Estatus & "' " & Me._QueryOrder, Me._Conexion)
        Try
            da.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementosEstatus", ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerElementosParaReportes() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter("SELECT CODIGO_CENTRO_COSTO,NOMBRE_CENTRO_COSTO FROM NOMINA_CAT_CENTROS_COSTOS " & Me._QueryOrder, Me._Conexion)
        Try
            da.Fill(dTable)
            dTable.Rows.Add("-1", "TODOS")
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementosParaReportes", ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerElementosParaReportesActivos() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter("SELECT CODIGO_CENTRO_COSTO,NOMBRE_CENTRO_COSTO FROM NOMINA_CAT_CENTROS_COSTOS WHERE ESTATUS_CENTRO_COSTO='A' " & Me._QueryOrder, Me._Conexion)
        Try
            da.Fill(dTable)
            dTable.Rows.Add("-1", "TODOS")
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementosParaReportesActivos", ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerElementosFiltro(ByVal Filtro As String, ByVal estatus As String) As System.Data.DataTable
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter("SELECT CODIGO_CENTRO_COSTO,NOMBRE_CENTRO_COSTO FROM NOMINA_CAT_CENTROS_COSTOS WHERE NOMBRE_CENTRO_COSTO LIKE '" & Filtro.ToString & "%' AND ESTATUS_CENTRO_COSTO='" & estatus & "' ORDER BY NOMBRE_CENTRO_COSTO", Me._Conexion)
        Try
            da.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementosFiltro", ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

    Public Function CodigoSiguiente() As String
        Dim iPuntoPago As Integer, sPuntoPago As String
        Dim Resultado As String = ""
        Try
            Dim sql As New Class_find("SELECT ISNULL(MAX(CODIGO_CENTRO_COSTO),0)+1 FROM NOMINA_CAT_CENTROS_COSTOS")
            iPuntoPago = CInt(sql.Result1)
            sPuntoPago = "000" + iPuntoPago.ToString
            Resultado = sPuntoPago.Substring(Len(sPuntoPago) - 3)
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "CodigoSiguiente", ex)
        End Try
        Return Resultado
    End Function

    Public Overrides Function BusquedaVisual_PorCodigo() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de centros de costos por codigo."
        f.sCampo = "CODIGO_CENTRO_COSTO"
        f.sOrder = "NOMBRE_CENTRO_COSTO"
        f.sTable = "NOMINA_CAT_CENTROS_COSTOS"
        f.sQl = "SELECT CODIGO_CENTRO_COSTO,NOMBRE_CENTRO_COSTO FROM NOMINA_CAT_CENTROS_COSTOS WHERE 1=1 AND ESTATUS_CENTRO_COSTO='A' AND "
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
        f.Text = "Búsqueda de centros de costos por descripción."
        f.sCampo = "NOMBRE_CENTRO_COSTO"
        f.sOrder = "NOMBRE_CENTRO_COSTO"
        f.sTable = "NOMINA_CAT_CENTROS_COSTOS"
        f.sQl = "SELECT CODIGO_CENTRO_COSTO,NOMBRE_CENTRO_COSTO FROM NOMINA_CAT_CENTROS_COSTOS WHERE 1=1 AND ESTATUS_CENTRO_COSTO='A' AND "
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

    Public Function BusquedaVisual_PorDescripcion_en_Grid() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de centros de costos por descripción."
        f.sCampo = "NOMBRE_CENTRO_COSTO"
        f.sOrder = "NOMBRE_CENTRO_COSTO"
        f.sTable = "NOMINA_CAT_CENTROS_COSTOS"
        f.sQl = "SELECT CODIGO_CENTRO_COSTO,NOMBRE_CENTRO_COSTO FROM NOMINA_CAT_CENTROS_COSTOS WHERE 1=1 AND ESTATUS_CENTRO_COSTO='A' AND "
        f.Inicia("")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 1), String)
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "BusquedaVisual_PorDescripcion", ex)
        End Try
        Return Resultado
    End Function

    Public Function BusquedaVisualPorProyectoSiembraActivo() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de centros de costos por descripción."
        f.sCampo = "CC.NOMBRE_CENTRO_COSTO"
        f.sOrder = "CC.NOMBRE_CENTRO_COSTO"
        f.sTable = "NOMINA_CAT_CENTROS_COSTOS"
        f.sQl = "SELECT CC.CODIGO_CENTRO_COSTO,CC.NOMBRE_CENTRO_COSTO FROM VW_PROYECTO_SIEMBRA_EXTENDIDO P INNER JOIN NOMINA_CAT_CENTROS_COSTOS CC ON(P.CODIGO_CENTRO_COSTO=CC.CODIGO_CENTRO_COSTO) " & _
            "WHERE CC.ESTATUS_CENTRO_COSTO='A' AND P.ID_CON_EJERCICIO=" & Plaza.ID_CON_EJERCICIO & " AND "
        f.Inicia("%")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "BusquedaVisualPorProyectoSiembraActivo", ex)
        End Try
        Return Resultado
    End Function

    Public Function EsCentroCostoProyectoSiembraActivo(ByVal sCodigoCentroCosto As String) As Boolean
        Dim bResultado As Boolean = False
        Try
            Dim sSQL As String =
                "SELECT 1 " & _
                "FROM VW_PROYECTO_SIEMBRA_EXTENDIDO P INNER JOIN NOMINA_CAT_CENTROS_COSTOS CC ON(P.CODIGO_CENTRO_COSTO=CC.CODIGO_CENTRO_COSTO) " & _
                "WHERE CC.ESTATUS_CENTRO_COSTO='A' AND P.ID_CON_EJERCICIO=" & Plaza.ID_CON_EJERCICIO & " AND CC.CODIGO_CENTRO_COSTO='" & sReplace(sCodigoCentroCosto) & "' "

            Dim sql As New Class_find(sSQL)

            If sql.Result1 = "1" Then
                bResultado = True
            End If

        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "EsCentroCostoProyectoSiembraActivo", ex)
        End Try

        Return bResultado
    End Function

#End Region

End Class
