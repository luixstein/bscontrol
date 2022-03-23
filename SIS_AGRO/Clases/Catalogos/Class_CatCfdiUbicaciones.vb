Imports System.Data.SqlClient

Public Class Class_CatCfdiUbicaciones

#Region "Campos"

#Region "Campos de la tabla"
    Private _CODIGO_UBICACION As Integer
    Private _CODIGO_CLIENTE As String
    Private _TIPO_UBICACION As String
    Private _ID_UBICACION As String
    Private _RFC_REMITENTE_DESTINATARIO As String
    Private _NOMBRE_REMITENTE_DESTINATARIO As String
    Private _NUMERO_IDENTIFICACION_REGISTRO_FISCAL_EXTRANJERO As String
    Private _CODIGO_PAIS_SAT_RESIDENCIA_FISCAL As String
    Private _DISTANCIA_RECORRIDA As Decimal
    Private _CALLE As String
    Private _NUMERO_EXTERIOR As String
    Private _NUMERO_INTERIOR As String
    Private _ID_COLONIA As Integer
    Private _ID_LOCALIDAD As Integer
    Private _REFERENCIA As String
    Private _CODIGO_MUNICIPIO As Integer
    Private _CODIGO_ESTADO_SAT As String
    Private _CODIGO_PAIS_SAT_DOMICILIO As String
    Private _CODIGO_POSTAL As String
    Private _ESTATUS As String
    Private _CODIGO_USUARIO_CREO As String
    Private _FECHA_CREO As Date
    Private _CODIGO_USUARIO_MODIFICO As String
    Private _FECHA_MODIFICO As Date
#End Region

#Region "Campos ligados a la tabla"
    Private _Existe As Boolean
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
    Public Property CODIGO_UBICACION() As Integer
        Get
            Return Me._CODIGO_UBICACION
        End Get
        Set(ByVal Value As Integer)
            Me._CODIGO_UBICACION = Value
        End Set
    End Property

    Public Property CODIGO_CLIENTE() As String
        Get
            Return Me._CODIGO_CLIENTE
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_CLIENTE = Value
        End Set
    End Property

    Public Property TIPO_UBICACION() As String
        Get
            Return Me._TIPO_UBICACION
        End Get
        Set(ByVal Value As String)
            Me._TIPO_UBICACION = Value
        End Set
    End Property

    Public Property ID_UBICACION() As String
        Get
            Return Me._ID_UBICACION
        End Get
        Set(value As String)
            Me._ID_UBICACION = value
        End Set
    End Property

    Public Property RFC_REMITENTE_DESTINATARIO() As String
        Get
            Return Me._RFC_REMITENTE_DESTINATARIO
        End Get
        Set(value As String)
            Me._RFC_REMITENTE_DESTINATARIO = value
        End Set
    End Property

    Public Property NOMBRE_REMITENTE_DESTINATARIO() As String
        Get
            Return Me._NOMBRE_REMITENTE_DESTINATARIO
        End Get
        Set(value As String)
            Me._NOMBRE_REMITENTE_DESTINATARIO = value
        End Set
    End Property

    Public Property NUMERO_IDENTIFICACION_REGISTRO_FISCAL_EXTRANJERO() As String
        Get
            Return Me._NUMERO_IDENTIFICACION_REGISTRO_FISCAL_EXTRANJERO
        End Get
        Set(value As String)
            Me._NUMERO_IDENTIFICACION_REGISTRO_FISCAL_EXTRANJERO = value
        End Set
    End Property

    Public Property CODIGO_PAIS_SAT_RESIDENCIA_FISCAL() As String
        Get
            Return Me._CODIGO_PAIS_SAT_RESIDENCIA_FISCAL
        End Get
        Set(value As String)
            Me._CODIGO_PAIS_SAT_RESIDENCIA_FISCAL = value
        End Set
    End Property

    Public Property DISTANCIA_RECORRIDA() As Decimal
        Get
            Return Me._DISTANCIA_RECORRIDA
        End Get
        Set(value As Decimal)
            Me._DISTANCIA_RECORRIDA = value
        End Set
    End Property

    Public Property CALLE() As String
        Get
            Return Me._CALLE
        End Get
        Set(value As String)
            Me._CALLE = value
        End Set
    End Property

    Public Property NUMERO_EXTERIOR() As String
        Get
            Return Me._NUMERO_EXTERIOR
        End Get
        Set(value As String)
            Me._NUMERO_EXTERIOR = value
        End Set
    End Property

    Public Property NUMERO_INTERIOR() As String
        Get
            Return Me._NUMERO_INTERIOR
        End Get
        Set(value As String)
            Me._NUMERO_INTERIOR = value
        End Set
    End Property

    Public Property ID_COLONIA() As Integer
        Get
            Return Me._ID_COLONIA
        End Get
        Set(value As Integer)
            Me._ID_COLONIA = value
        End Set
    End Property

    Public Property ID_LOCALIDAD() As Integer
        Get
            Return Me._ID_LOCALIDAD
        End Get
        Set(value As Integer)
            Me._ID_LOCALIDAD = value
        End Set
    End Property

    Public Property REFERENCIA() As String
        Get
            Return Me._REFERENCIA
        End Get
        Set(value As String)
            Me._REFERENCIA = value
        End Set
    End Property

    Public Property CODIGO_MUNICIPIO() As Integer
        Get
            Return Me._CODIGO_MUNICIPIO
        End Get
        Set(value As Integer)
            Me._CODIGO_MUNICIPIO = value
        End Set
    End Property

    Public Property CODIGO_ESTADO_SAT() As String
        Get
            Return Me._CODIGO_ESTADO_SAT
        End Get
        Set(value As String)
            Me._CODIGO_ESTADO_SAT = value
        End Set
    End Property

    Public Property CODIGO_PAIS_SAT_DOMICILIO() As String
        Get
            Return Me._CODIGO_PAIS_SAT_DOMICILIO
        End Get
        Set(value As String)
            Me._CODIGO_PAIS_SAT_DOMICILIO = value
        End Set
    End Property

    Public Property CODIGO_POSTAL() As String
        Get
            Return Me._CODIGO_POSTAL
        End Get
        Set(value As String)
            Me._CODIGO_POSTAL = value
        End Set
    End Property

    Public Property ESTATUS() As String
        Get
            Return Me._ESTATUS
        End Get
        Set(value As String)
            Me._ESTATUS = value
        End Set
    End Property

    Public Property CODIGO_USUARIO_CREO() As String
        Get
            Return Me._CODIGO_USUARIO_CREO
        End Get
        Set(value As String)
            Me._CODIGO_USUARIO_CREO = value
        End Set
    End Property

    Public Property FECHA_CREO() As Date
        Get
            Return Me._FECHA_CREO
        End Get
        Set(value As Date)
            Me._FECHA_CREO = value
        End Set
    End Property

    Public Property CODIGO_USUARIO_MODIFICO() As String
        Get
            Return Me._CODIGO_USUARIO_MODIFICO
        End Get
        Set(value As String)
            Me._CODIGO_USUARIO_MODIFICO = value
        End Set
    End Property

    Public Property FECHA_MODIFICO() As Date
        Get
            Return Me._FECHA_MODIFICO
        End Get
        Set(value As Date)
            Me._FECHA_MODIFICO = value
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
        Me._Nombre_Catalogo = "CFDI_CAT_UBICACIONES"
        Me._Nombre_Reporte = "RPT_CATALOGO_CFDI_UBICACIONES"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "Select * From CFDI_CAT_UBICACIONES"
        Me._QueryOrder = " Order by ID_UBICACION"
    End Sub

    Public Sub New(ByVal sCodigoUbicacion As String)
        Me.New()
        Try
            Me._CODIGO_UBICACION = sCodigoUbicacion
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

#Region "Métodos y procedimientos"
    Public Function Grabar(ByVal sAccion As String) As Boolean
        Const sProcedure As String = "Grabar"
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CFDI_CAT_UBICACIONES_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_UBICACION", SqlDbType.Int) : sqlParametro.Value = Me._CODIGO_UBICACION : sqlParametro.Direction = ParameterDirection.InputOutput
            sqlParametro = .Parameters.Add("@CODIGO_CLIENTE", SqlDbType.NVarChar, 8) : sqlParametro.Value = Me._CODIGO_CLIENTE.ToString.ToUpper
            sqlParametro = .Parameters.Add("@ESTATUS", SqlDbType.Char, 1) : sqlParametro.Value = Me._ESTATUS.ToUpper
            sqlParametro = .Parameters.Add("@TIPO_UBICACION", SqlDbType.NVarChar, 10) : sqlParametro.Value = Me._TIPO_UBICACION.ToString.ToUpper
            sqlParametro = .Parameters.Add("@ID_UBICACION", SqlDbType.NVarChar, 8) : sqlParametro.Value = Me._ID_UBICACION.ToString.ToUpper
            sqlParametro = .Parameters.Add("@RFC_REMITENTE_DESTINATARIO", SqlDbType.NVarChar, 13) : sqlParametro.Value = Me._RFC_REMITENTE_DESTINATARIO.ToString.ToUpper
            sqlParametro = .Parameters.Add("@NOMBRE_REMITENTE_DESTINATARIO", SqlDbType.NVarChar, 254) : sqlParametro.Value = Me._NOMBRE_REMITENTE_DESTINATARIO.ToUpper
            sqlParametro = .Parameters.Add("@NUMERO_IDENTIFICACION_REGISTRO_FISCAL_EXTRANJERO", SqlDbType.NVarChar, 40) : sqlParametro.Value = Me._NUMERO_IDENTIFICACION_REGISTRO_FISCAL_EXTRANJERO.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_PAIS_SAT_RESIDENCIA_FISCAL", SqlDbType.NVarChar, 4) : sqlParametro.Value = Me._CODIGO_PAIS_SAT_RESIDENCIA_FISCAL.ToUpper
            sqlParametro = .Parameters.Add("@DISTANCIA_RECORRIDA", SqlDbType.Decimal) : sqlParametro.Value = valorNumericoD(Me._DISTANCIA_RECORRIDA)
            sqlParametro = .Parameters.Add("@CALLE", SqlDbType.NVarChar, 100) : sqlParametro.Value = Me._CALLE.ToUpper
            sqlParametro = .Parameters.Add("@NUMERO_EXTERIOR", SqlDbType.NVarChar, 55) : sqlParametro.Value = Me._NUMERO_EXTERIOR.ToUpper
            sqlParametro = .Parameters.Add("@NUMERO_INTERIOR", SqlDbType.NVarChar, 55) : sqlParametro.Value = Me._NUMERO_INTERIOR.ToUpper
            sqlParametro = .Parameters.Add("@ID_COLONIA", SqlDbType.Int) : sqlParametro.Value = CInt(Me._ID_COLONIA)
            sqlParametro = .Parameters.Add("@ID_LOCALIDAD", SqlDbType.Int) : sqlParametro.Value = CInt(Me._ID_LOCALIDAD)
            sqlParametro = .Parameters.Add("@REFERENCIA", SqlDbType.NVarChar, 250) : sqlParametro.Value = Me._REFERENCIA.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_MUNICIPIO", SqlDbType.SmallInt) : sqlParametro.Value = CInt(Me._CODIGO_MUNICIPIO)
            sqlParametro = .Parameters.Add("@CODIGO_ESTADO_SAT", SqlDbType.NVarChar, 4) : sqlParametro.Value = Me._CODIGO_ESTADO_SAT.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_PAIS_SAT_DOMICILIO", SqlDbType.NVarChar, 4) : sqlParametro.Value = Me._CODIGO_PAIS_SAT_DOMICILIO.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_POSTAL", SqlDbType.NVarChar, 12) : sqlParametro.Value = Me._CODIGO_POSTAL.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO_CREO", SqlDbType.SmallInt) : sqlParametro.Value = CInt(Me._CODIGO_USUARIO_CREO)
            sqlParametro = .Parameters.Add("@FECHA_CREO", SqlDbType.DateTime) : sqlParametro.Value = Me._FECHA_CREO
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO_MODIFICO", SqlDbType.SmallInt) : sqlParametro.Value = CInt(Me._CODIGO_USUARIO_MODIFICO)
            sqlParametro = .Parameters.Add("@FECHA_MODIFICO", SqlDbType.DateTime) : sqlParametro.Value = Me._FECHA_MODIFICO
            sqlParametro = .Parameters.Add("@ACCION", SqlDbType.NVarChar, 20) : sqlParametro.Value = "INSERTAR"
            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
                If sAccion = "INSERTAR" Then
                    Me._CODIGO_UBICACION = "" & .Parameters("@CODIGO_UBICACION").Value.ToString
                End If
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, sProcedure, ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Function Consultar() As Boolean
        Const sProcedure As String = "Consultar"
        Dim bResultado As Boolean = False

        Dim cmd As New SqlCommand("SELECT * FROM CFDI_CAT_UBICACIONES WHERE CODIGO_UBICACION='" & sReplace(Me._CODIGO_UBICACION) & "'", Me._Conexion)
        Dim dReader As SqlDataReader

        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read = True Then
                    Me._CODIGO_UBICACION = CType(dReader("CODIGO_UBICACION").ToString, Integer)
                    Me._CODIGO_CLIENTE = "" & dReader("CODIGO_CLIENTE").ToString
                    Me._ESTATUS = "" & dReader("ESTATUS")
                    Me._TIPO_UBICACION = "" & dReader("TIPO_UBICACION").ToString
                    Me._ID_UBICACION = "" & dReader("ID_UBICACION").ToString
                    Me._RFC_REMITENTE_DESTINATARIO = "" & dReader("RFC_REMITENTE_DESTINATARIO").ToString
                    Me._NOMBRE_REMITENTE_DESTINATARIO = "" & dReader("NOMBRE_REMITENTE_DESTINATARIO").ToString
                    Me._NUMERO_IDENTIFICACION_REGISTRO_FISCAL_EXTRANJERO = "" & dReader("NUMERO_IDENTIFICACION_REGISTRO_FISCAL_EXTRANJERO").ToString
                    Me._CODIGO_PAIS_SAT_RESIDENCIA_FISCAL = "" & dReader("CODIGO_PAIS_SAT_RESIDENCIA_FISCAL").ToString
                    Me._DISTANCIA_RECORRIDA = valorNumericoD(dReader("DISTANCIA_RECORRIDA").ToString)
                    Me._CALLE = "" & dReader("CALLE").ToString
                    Me._NUMERO_EXTERIOR = "" & dReader("NUMERO_EXTERIOR").ToString
                    Me._NUMERO_INTERIOR = "" & dReader("NUMERO_INTERIOR").ToString
                    If txtLEN(dReader("ID_COLONIA").ToString) = True Then Me._ID_COLONIA = CType(dReader("ID_COLONIA").ToString, Integer)
                    If txtLEN(dReader("ID_LOCALIDAD").ToString) = True Then Me._ID_COLONIA = CType(dReader("ID_LOCALIDAD").ToString, Integer)
                    Me._REFERENCIA = "" & dReader("REFERENCIA").ToString
                    If txtLEN(dReader("CODIGO_MUNICIPIO").ToString) = True Then Me._ID_COLONIA = CType(dReader("CODIGO_MUNICIPIO").ToString, Integer)
                    Me._CODIGO_ESTADO_SAT = "" & dReader("CODIGO_ESTADO_SAT").ToString
                    Me._CODIGO_PAIS_SAT_DOMICILIO = "" & dReader("CODIGO_PAIS_SAT_DOMICILIO").ToString
                    Me._CODIGO_POSTAL = "" & dReader("CODIGO_POSTAL").ToString
                    Me._ESTATUS = "" & dReader("ESTATUS").ToString
                    Me._CODIGO_USUARIO_CREO = "" & dReader("CODIGO_USUARIO_CREO").ToString
                    Me._FECHA_CREO = CDate(dReader("FECHA_CREO").ToString)
                    Me._CODIGO_USUARIO_MODIFICO = "" & dReader("CODIGO_USUARIO_MODIFICO").ToString
                    If Not (IsDBNull(dReader("FECHA_MODIFICO"))) Then Me._FECHA_MODIFICO = CDate(dReader("FECHA_MODIFICO").ToString)

                    bResultado = True
                End If
                dReader.Close()
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, sProcedure, ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
            End Try
        End With
        Return bResultado
    End Function

    Public Function ObtenerElementos() As System.Data.DataTable
        Const sProcedure As String = "ObtenerElementos"
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter(Me._QuerySelect & Me._QueryOrder, Me._Conexion)
        Try
            da.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, sProcedure, ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerElementosParaReportes() As System.Data.DataTable
        Const sProcedure As String = "ObtenerElementosParaReportes"
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter(Me._QuerySelect & Me._QueryOrder, Me._Conexion)
        Try
            da.Fill(dTable)
            dTable.Rows.Add("-1", "TODOS")
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, sProcedure, ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerElementosFiltro(ByVal Filtro As String, ByVal ESTATUS As String) As System.Data.DataTable
        Const sProcedure As String = "ObtenerElementosFiltro"
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter("SELECT CODIGO_UBICACION, ID_UBICACION FROM CFDI_CAT_UBICACIONES WHERE ID_UBICACION LIKE '" & Filtro.ToString & "%' AND ESTATUS='" & ESTATUS & "' ORDER BY ID_UBICACION", Me._Conexion)
        Try
            da.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, sProcedure, ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

    Public Function BusquedaVisual_PorCodigo() As String
        Const sProcedure As String = "BusquedaVisual_PorCodigo"
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de ubicaciones por código."
        f.sCampo = "CODIGO_UBICACION"
        f.sOrder = "NOMBRE_REMITENTE_DESTINATARIO"
        f.sTable = "CFDI_CAT_UBICACIONES"
        f.sQl = "SELECT CODIGO_UBICACION,TIPO_UBICACION,RFC_REMITENTE_DESTINATARIO RFC,NOMBRE_REMITENTE_DESTINATARIO NOMBRE FROM CFDI_CAT_UBICACIONES WHERE 1=1 AND "
        f.arrayWidthColumns = New Integer() {100, 100, 100, 300}
        f.Inicia("")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, sProcedure, ex)
        End Try
        Return Resultado
    End Function

    Public Function BusquedaVisual_PorDescripcion() As String
        Const sProcedure As String = "BusquedaVisual_PorDescripcion"
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de ubicaciones por descripción."
        f.sCampo = "NOMBRE_REMITENTE_DESTINATARIO"
        f.sOrder = "NOMBRE_REMITENTE_DESTINATARIO"
        f.sTable = "CFDI_CAT_UBICACIONES"
        f.sQl = "SELECT CODIGO_UBICACION,TIPO_UBICACION,RFC_REMITENTE_DESTINATARIO RFC,NOMBRE_REMITENTE_DESTINATARIO NOMBRE FROM CFDI_CAT_UBICACIONES WHERE 1=1 AND "
        f.arrayWidthColumns = New Integer() {100, 100, 100, 300}
        f.Inicia("")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, sProcedure, ex)
        End Try
        Return Resultado
    End Function

    Public Function CodigoSiguiente() As String
        Const sProcedure As String = "CodigoSiguiente"
        Dim Resultado As Integer
        Try
            Dim sql As New Class_find("SELECT ISNULL(MAX(CODIGO_UBICACION),0) FROM CFDI_CAT_UBICACIONES")
            Resultado = CType(sql.Result1, Integer) + 1
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, sProcedure, ex)
        End Try
        Return Resultado
    End Function
#End Region

End Class