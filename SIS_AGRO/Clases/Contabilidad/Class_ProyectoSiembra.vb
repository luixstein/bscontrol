Imports System.Data
Imports System.Data.SqlClient

Public Class Class_ProyectoSiembra
    Inherits Class_Catalogos

#Region "Campos"

#Region "Campos de la tabla"
    Private _ID_CON_EJERCICIO As String
    Private _ORDEN As String
    Private _CODIGO_CULTIVO As String
    Private _FECHA_SIEMBRA As String
    Private _FECHA_CORTE As String
    Private _HECTAREAS_SEMBRADAS As String
    Private _PRODUCCION_ESTIMADA As String
    Private _PRESUPUESTO_TOTAL_POR_HECTAREA_DOLARES As String
    Private _PRESUPUESTO_COSTO_UNITARIO_PRODUCCION As String
    Private _PRESUPUESTO_COSTO_UNITARIO_CORTE_EMPAQUE_DOLARES As String
    Private _PRESUPUESTO_COSTO_UNITARIO_TOTAL As String
    Private _FECHA_FIN_TEMPORADA As String
    Private _ID_PROYECTO As String
    Private _CODIGO_CENTRO_COSTO As String
    Private _CODIGO_CENTRO_COSTO_ORIGEN As String
    Private _CODIGO_LOTE As String

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
    Public Property ID_CON_EJERCICIO() As String
        Get
            Return Me._ID_CON_EJERCICIO
        End Get
        Set(ByVal Value As String)
            Me._ID_CON_EJERCICIO = Value
        End Set
    End Property

    Public Property ORDEN() As String
        Get
            Return Me._ORDEN
        End Get
        Set(ByVal Value As String)
            Me._ORDEN = Value
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

    Public Property FECHA_SIEMBRA() As String
        Get
            Return Me._FECHA_SIEMBRA
        End Get
        Set(ByVal Value As String)
            Me._FECHA_SIEMBRA = Value
        End Set
    End Property

    Public Property FECHA_CORTE() As String
        Get
            Return Me._FECHA_CORTE
        End Get
        Set(ByVal Value As String)
            Me._FECHA_CORTE = Value
        End Set
    End Property

    Public Property HECTAREAS_SEMBRADAS() As String
        Get
            Return Me._HECTAREAS_SEMBRADAS
        End Get
        Set(ByVal Value As String)
            Me._HECTAREAS_SEMBRADAS = Value
        End Set
    End Property

    Public Property PRODUCCION_ESTIMADA() As String
        Get
            Return Me._PRODUCCION_ESTIMADA
        End Get
        Set(ByVal Value As String)
            Me._PRODUCCION_ESTIMADA = Value
        End Set
    End Property

    Public Property PRESUPUESTO_TOTAL_POR_HECTAREA_DOLARES() As String
        Get
            Return Me._PRESUPUESTO_TOTAL_POR_HECTAREA_DOLARES
        End Get
        Set(ByVal Value As String)
            Me._PRESUPUESTO_TOTAL_POR_HECTAREA_DOLARES = Value
        End Set
    End Property

    Public Property PRESUPUESTO_COSTO_UNITARIO_PRODUCCION() As String
        Get
            Return Me._PRESUPUESTO_COSTO_UNITARIO_PRODUCCION
        End Get
        Set(ByVal Value As String)
            Me._PRESUPUESTO_COSTO_UNITARIO_PRODUCCION = Value
        End Set
    End Property

    Public Property PRESUPUESTO_COSTO_UNITARIO_CORTE_EMPAQUE_DOLARES() As String
        Get
            Return Me._PRESUPUESTO_COSTO_UNITARIO_CORTE_EMPAQUE_DOLARES
        End Get
        Set(ByVal Value As String)
            Me._PRESUPUESTO_COSTO_UNITARIO_CORTE_EMPAQUE_DOLARES = Value
        End Set
    End Property

    Public Property PRESUPUESTO_COSTO_UNITARIO_TOTAL() As String
        Get
            Return Me._PRESUPUESTO_COSTO_UNITARIO_TOTAL
        End Get
        Set(ByVal Value As String)
            Me._PRESUPUESTO_COSTO_UNITARIO_TOTAL = Value
        End Set
    End Property

    Public Property FECHA_FIN_TEMPORADA() As String
        Get
            Return Me._FECHA_FIN_TEMPORADA
        End Get
        Set(ByVal Value As String)
            Me._FECHA_FIN_TEMPORADA = Value
        End Set
    End Property

    Public Property ID_PROYECTO() As String
        Get
            Return Me._ID_PROYECTO
        End Get
        Set(ByVal Value As String)
            Me._ID_PROYECTO = Value
        End Set
    End Property

    Public Property CODIGO_CENTRO_COSTO() As String
        Get
            Return Me._CODIGO_CENTRO_COSTO
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_CENTRO_COSTO = Value
        End Set
    End Property

    Public Property CODIGO_CENTRO_COSTO_ORIGEN() As String
        Get
            Return Me._CODIGO_CENTRO_COSTO_ORIGEN
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_CENTRO_COSTO_ORIGEN = Value
        End Set
    End Property

    Public Property CODIGO_LOTE() As String
        Get
            Return Me._CODIGO_LOTE
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_LOTE = Value
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
        Me._Nombre_Catalogo = "PROYECTO_SIEMBRA"
        Me._Nombre_Reporte = "RPT_PROYECTO_SIEMBRA"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "SELECT * FROM PROYECTO_SIEMBRA"
        Me._QueryOrder = " ORDER BY ID_PROYECTO"
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
            .CommandText = "MP_PROYECTO_SIEMBRA_GRABA"

            sqlParametro = .Parameters.Add("@ID_CON_EJERCICIO", SqlDbType.SmallInt) : sqlParametro.Value = CInt(Me._ID_CON_EJERCICIO)
            sqlParametro = .Parameters.Add("@ORDEN", SqlDbType.SmallInt) : sqlParametro.Value = CInt(Me._ORDEN)
            sqlParametro = .Parameters.Add("@CODIGO_CULTIVO", SqlDbType.SmallInt) : sqlParametro.Value = CInt(Me._CODIGO_CULTIVO)
            sqlParametro = .Parameters.Add("@FECHA_SIEMBRA", SqlDbType.DateTime) : sqlParametro.Value = CDate(Me._FECHA_SIEMBRA)
            sqlParametro = .Parameters.Add("@FECHA_CORTE", SqlDbType.DateTime) : sqlParametro.Value = CDate(Me._FECHA_CORTE)
            sqlParametro = .Parameters.Add("@HECTAREAS_SEMBRADAS", SqlDbType.Decimal) : sqlParametro.Value = CDec(Me._HECTAREAS_SEMBRADAS)
            sqlParametro = .Parameters.Add("@FECHA_FIN_TEMPORADA", SqlDbType.DateTime) : sqlParametro.Value = CDate(Me._FECHA_FIN_TEMPORADA)
            sqlParametro = .Parameters.Add("@ID_PROYECTO", SqlDbType.Int) : sqlParametro.Value = 0 'El Id se incrementa automaticamente en el stored
            sqlParametro = .Parameters.Add("@CODIGO_CENTRO_COSTO", SqlDbType.SmallInt) : sqlParametro.Value = CInt(Me._CODIGO_CENTRO_COSTO)
            sqlParametro = .Parameters.Add("@CODIGO_CENTRO_COSTO_ORIGEN", SqlDbType.SmallInt) : sqlParametro.Value = CInt(Me._CODIGO_CENTRO_COSTO_ORIGEN)
            sqlParametro = .Parameters.Add("@CODIGO_LOTE", SqlDbType.NVarChar, 2) : sqlParametro.Value = Me._CODIGO_LOTE
            sqlParametro = .Parameters.Add("@AGREGAR", SqlDbType.Char, 1) : sqlParametro.Value = "1"
            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                Insertar = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "Insertar", ex)
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
            .CommandText = "MP_PROYECTO_SIEMBRA_GRABA"

            sqlParametro = .Parameters.Add("@ID_CON_EJERCICIO", SqlDbType.SmallInt) : sqlParametro.Value = Me._ID_CON_EJERCICIO
            sqlParametro = .Parameters.Add("@ORDEN", SqlDbType.SmallInt) : sqlParametro.Value = Me._ORDEN
            sqlParametro = .Parameters.Add("@CODIGO_CULTIVO", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_CULTIVO
            sqlParametro = .Parameters.Add("@FECHA_SIEMBRA", SqlDbType.DateTime) : sqlParametro.Value = CDate(Me._FECHA_SIEMBRA)
            sqlParametro = .Parameters.Add("@FECHA_CORTE", SqlDbType.DateTime) : sqlParametro.Value = CDate(Me._FECHA_CORTE)
            sqlParametro = .Parameters.Add("@HECTAREAS_SEMBRADAS", SqlDbType.Decimal) : sqlParametro.Value = Me._HECTAREAS_SEMBRADAS
            sqlParametro = .Parameters.Add("@FECHA_FIN_TEMPORADA", SqlDbType.DateTime) : sqlParametro.Value = CDate(Me._FECHA_FIN_TEMPORADA)
            sqlParametro = .Parameters.Add("@ID_PROYECTO", SqlDbType.Int) : sqlParametro.Value = Me._ID_PROYECTO
            sqlParametro = .Parameters.Add("@CODIGO_CENTRO_COSTO", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_CENTRO_COSTO
            sqlParametro = .Parameters.Add("@CODIGO_CENTRO_COSTO_ORIGEN", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_CENTRO_COSTO_ORIGEN
            sqlParametro = .Parameters.Add("@CODIGO_LOTE", SqlDbType.NVarChar, 2) : sqlParametro.Value = Me._CODIGO_LOTE
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

    Public Function Eliminar() As Boolean
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter

        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_PROYECTO_SIEMBRA_ELIMINA"

            sqlParametro = .Parameters.Add("@ID_PROYECTO", SqlDbType.Int) : sqlParametro.Value = Me._ID_PROYECTO

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                Eliminar = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "Eliminar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
    End Function

    Public Overrides Function Consultar() As Boolean
        Dim cmd As New SqlCommand("Select * from PROYECTO_SIEMBRA WHERE ID_PROYECTO=" & Replace(Me._ID_PROYECTO, "'", "''") & "", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._ID_CON_EJERCICIO = "" & dReader("ID_CON_EJERCICIO")
                    Me._ORDEN = "" & dReader("ORDEN")
                    Me._CODIGO_CULTIVO = "" & dReader("CODIGO_CULTIVO")
                    Me._FECHA_SIEMBRA = "" & dReader("FECHA_SIEMBRA")
                    Me._FECHA_CORTE = "" & dReader("FECHA_CORTE")
                    Me._HECTAREAS_SEMBRADAS = "" & dReader("HECTAREAS_SEMBRADAS")
                    Me._PRODUCCION_ESTIMADA = "" & dReader("PRODUCCION_ESTIMADA")
                    Me._PRESUPUESTO_TOTAL_POR_HECTAREA_DOLARES = "" & dReader("PRESUPUESTO_TOTAL_POR_HECTAREA_DOLARES")
                    Me._PRESUPUESTO_COSTO_UNITARIO_PRODUCCION = "" & dReader("PRESUPUESTO_COSTO_UNITARIO_PRODUCCION")
                    Me._PRESUPUESTO_COSTO_UNITARIO_CORTE_EMPAQUE_DOLARES = "" & dReader("PRESUPUESTO_COSTO_UNITARIO_CORTE_EMPAQUE_DOLARES")
                    Me._PRESUPUESTO_COSTO_UNITARIO_TOTAL = "" & dReader("PRESUPUESTO_COSTO_UNITARIO_TOTAL")
                    Me._FECHA_FIN_TEMPORADA = "" & dReader("FECHA_FIN_TEMPORADA")
                    Me._ID_PROYECTO = "" & dReader("ID_PROYECTO")
                    Me._CODIGO_CENTRO_COSTO = "" & dReader("CODIGO_CENTRO_COSTO")
                    Me._CODIGO_CENTRO_COSTO_ORIGEN = "" & dReader("CODIGO_CENTRO_COSTO_ORIGEN")
                    Me._CODIGO_LOTE = "" & dReader("CODIGO_LOTE")

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

    Public Function ObtenerElementosGrid(ByVal Ejercicio As String) As System.Data.DataTable
        Dim dTable As New DataTable
        Dim ds As New SqlDataAdapter("SELECT C.ID_PROYECTO,C.ORDEN,C.CODIGO_CULTIVO, B.NOMBRE_CULTIVO, C.CODIGO_CENTRO_COSTO_ORIGEN,D.NOMBRE_CENTRO_COSTO AS NOMBRE_CENTRO_COSTO_ORIGEN, C.CODIGO_CENTRO_COSTO,A.NOMBRE_CENTRO_COSTO," & _
                                     "C.HECTAREAS_SEMBRADAS,C.CODIGO_LOTE,L.NOMBRE_LOTE,C.FECHA_SIEMBRA,C.FECHA_CORTE, C.FECHA_FIN_TEMPORADA FROM PROYECTO_SIEMBRA C " & _
                                     "LEFT JOIN CAT_CULTIVOS B ON(C.CODIGO_CULTIVO=B.CODIGO_CULTIVO) INNER JOIN NOMINA_CAT_CENTROS_COSTOS A ON(C.CODIGO_CENTRO_COSTO=A.CODIGO_CENTRO_COSTO) " & _
                                     "LEFT JOIN NOMINA_CAT_CENTROS_COSTOS D ON(C.CODIGO_CENTRO_COSTO_ORIGEN=D.CODIGO_CENTRO_COSTO) LEFT JOIN CAT_LOTES L ON(C.CODIGO_LOTE=L.CODIGO_LOTE) " & _
                                     "WHERE ID_CON_EJERCICIO='" & Ejercicio & "' ORDER BY ID_PROYECTO", Me._Conexion)
        Try
            ds.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementosGrid", ex)
        Finally
            ds.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerEjercicios() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim ds As New SqlDataAdapter("SELECT ID_CON_EJERCICIO, NOMBRE_EJERCICIO FROM CON_EJERCICIOS ORDER BY NOMBRE_EJERCICIO", Me._Conexion)
        Try
            ds.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementosGrid", ex)
        Finally
            ds.Dispose()
        End Try
        Return dTable
    End Function

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
#End Region

#Region "Eventos de objetos"

#Region "Eventos Genericos"

#End Region

#Region "Keydown específicos"

#End Region

#Region "Validating específicos"

#End Region

#End Region

End Class

