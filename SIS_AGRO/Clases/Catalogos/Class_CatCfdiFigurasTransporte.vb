Option Strict On

Imports System.Data.SqlClient

Public Class Class_CatCfdiFigurasTransporte

#Region "Campos"
#Region "Campos de la tabla"
    Private _CODIGO_FIGURA_TRANSPORTE As String
    Private _NOMBRE_FIGURA_TRANSPORTE As String
    Private _CODIGO_TIPO_FIGURA_TRANSPORTE As String
    Private _RFC As String
    Private _NUMERO_LICENCIA As String
    Private _NUMERO_IDENTIFICACION_REGISTRO_FISCAL_EXTRANJERO As String
    Private _CODIGO_PAIS_SAT_RESIDENCIA_FISCAL As String
    Private _CALLE As String
    Private _NUMERO_EXTERIOR As String
    Private _NUMERO_INTERIOR As String
    Private _ID_COLONIA As String ' Integer
    Private _ID_LOCALIDAD As String ' Integer
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
    Private _DOMICILIO_COMPLETO As String
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
    Public Property CODIGO_FIGURA_TRANSPORTE() As String
        Get
            Return Me._CODIGO_FIGURA_TRANSPORTE
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_FIGURA_TRANSPORTE = Value
        End Set
    End Property

    Public Property NOMBRE_FIGURA_TRANSPORTE() As String
        Get
            Return Me._NOMBRE_FIGURA_TRANSPORTE
        End Get
        Set(ByVal Value As String)
            Me._NOMBRE_FIGURA_TRANSPORTE = Value
        End Set
    End Property

    Public Property CODIGO_TIPO_FIGURA_TRANSPORTE() As String
        Get
            Return Me._CODIGO_TIPO_FIGURA_TRANSPORTE
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_TIPO_FIGURA_TRANSPORTE = Value
        End Set
    End Property

    Public Property RFC() As String
        Get
            Return Me._RFC
        End Get
        Set(value As String)
            Me._RFC = value
        End Set
    End Property

    Public Property NUMERO_LICENCIA() As String
        Get
            Return Me._NUMERO_LICENCIA
        End Get
        Set(value As String)
            Me._NUMERO_LICENCIA = value
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

    Public Property ID_COLONIA() As String
        Get
            Return Me._ID_COLONIA
        End Get
        Set(value As String)
            Me._ID_COLONIA = value
        End Set
    End Property

    Public Property ID_LOCALIDAD() As String
        Get
            Return Me._ID_LOCALIDAD
        End Get
        Set(value As String)
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

    Public ReadOnly Property DOMICILIO_COMPLETO() As String
        Get
            Return Me._DOMICILIO_COMPLETO
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
        Me._Nombre_Catalogo = "CFDI_CAT_FIGURAS_TRANSPORTE"
        Me._Nombre_Reporte = "RPT_CATALOGO_CFDI_FIGURAS_TRANSPORTE"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "Select * From CFDI_CAT_FIGURAS_TRANSPORTE"
        Me._QueryOrder = " Order by NOMBRE_FIGURA_TRANSPORTE"
    End Sub

    Public Sub New(ByVal sCodigoFiguraTransporte As String)
        Me.New()
        Try
            Me._CODIGO_FIGURA_TRANSPORTE = sCodigoFiguraTransporte
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
            .CommandText = "MP_CFDI_CAT_FIGURAS_TRANSPORTE_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_FIGURA_TRANSPORTE", SqlDbType.Int) : sqlParametro.Value = Me._CODIGO_FIGURA_TRANSPORTE : sqlParametro.Direction = ParameterDirection.InputOutput
            sqlParametro = .Parameters.Add("@NOMBRE_FIGURA_TRANSPORTE", SqlDbType.NVarChar, 254) : sqlParametro.Value = Me._NOMBRE_FIGURA_TRANSPORTE.ToUpper
            sqlParametro = .Parameters.Add("@ESTATUS", SqlDbType.Char, 1) : sqlParametro.Value = Me._ESTATUS.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_TIPO_FIGURA_TRANSPORTE", SqlDbType.NVarChar, 2) : sqlParametro.Value = Me._CODIGO_TIPO_FIGURA_TRANSPORTE.ToString.ToUpper
            sqlParametro = .Parameters.Add("@RFC", SqlDbType.NVarChar, 13) : sqlParametro.Value = Me._RFC.ToString.ToUpper
            sqlParametro = .Parameters.Add("@NUMERO_LICENCIA", SqlDbType.NVarChar, 16) : sqlParametro.Value = Me._NUMERO_LICENCIA.ToString.ToUpper
            sqlParametro = .Parameters.Add("@NUMERO_IDENTIFICACION_REGISTRO_FISCAL_EXTRANJERO", SqlDbType.NVarChar, 40) : sqlParametro.Value = Me._NUMERO_IDENTIFICACION_REGISTRO_FISCAL_EXTRANJERO.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_PAIS_SAT_RESIDENCIA_FISCAL", SqlDbType.NVarChar, 4) : sqlParametro.Value = Me._CODIGO_PAIS_SAT_RESIDENCIA_FISCAL.ToUpper
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
            sqlParametro = .Parameters.Add("@ACCION", SqlDbType.NVarChar, 20) : sqlParametro.Value = sAccion
            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
                If sAccion = "INSERTAR" Then
                    Me._CODIGO_FIGURA_TRANSPORTE = "" & .Parameters("@CODIGO_FIGURA_TRANSPORTE").Value.ToString
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
        Dim cmd As New SqlCommand(
            "SELECT UPPER( " &
            "CASE WHEN LEN(F.CALLE)>0 THEN F.CALLE ELSE '' END + CASE WHEN LEN(F.NUMERO_EXTERIOR)>0 THEN ' ' + F.NUMERO_EXTERIOR ELSE '' END + CASE WHEN LEN(F.NUMERO_INTERIOR)>0 THEN ' ' + F.NUMERO_INTERIOR ELSE '' END + " &
            "CASE WHEN LEN(COL.NOMBRE_COLONIA)>0 THEN ' ' + COL.NOMBRE_COLONIA ELSE '' END + CASE WHEN LEN(LOC.NOMBRE_LOCALIDAD)>0 THEN ' ' + LOC.NOMBRE_LOCALIDAD ELSE '' END + " &
            "CASE WHEN M.NOMBRE_MUNICIPIO IS NOT NULL THEN ' ' + M.NOMBRE_MUNICIPIO ELSE '' END + ' ' + E.NOMBRE_ESTADO + ' ' + P.NOMBRE_PAIS + ' ' + F.CODIGO_POSTAL) DOMICILIO_COMPLETO," &
            "F.* " &
            "FROM CFDI_CAT_FIGURAS_TRANSPORTE F " &
            "INNER JOIN CAT_PAISES P ON(F.CODIGO_PAIS_SAT_DOMICILIO=P.CODIGO_PAIS_SAT) " &
            "INNER JOIN SIS_ESTADOS E ON(F.CODIGO_ESTADO_SAT=E.CODIGO_ESTADO_SAT) " &
            "LEFT JOIN CAT_MUNICIPIOS M ON(F.CODIGO_MUNICIPIO=M.CODIGO_MUNICIPIO) " &
            "LEFT JOIN CFDI_CAT_COLONIAS COL ON(F.ID_COLONIA=COL.ID_COLONIA) " &
            "LEFT JOIN CFDI_CAT_LOCALIDADES LOC ON(F.ID_LOCALIDAD=LOC.ID_LOCALIDAD)" &
            "WHERE F.CODIGO_FIGURA_TRANSPORTE='" & sReplace(Me._CODIGO_FIGURA_TRANSPORTE) & "'", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read = True Then
                    Me._CODIGO_FIGURA_TRANSPORTE = "" & dReader("CODIGO_FIGURA_TRANSPORTE").ToString
                    Me._NOMBRE_FIGURA_TRANSPORTE = "" & dReader("NOMBRE_FIGURA_TRANSPORTE").ToString
                    Me._CODIGO_TIPO_FIGURA_TRANSPORTE = "" & dReader("CODIGO_TIPO_FIGURA_TRANSPORTE").ToString
                    Me._RFC = "" & dReader("RFC").ToString
                    Me._NUMERO_LICENCIA = "" & dReader("NUMERO_LICENCIA").ToString
                    Me._NUMERO_IDENTIFICACION_REGISTRO_FISCAL_EXTRANJERO = "" & dReader("NUMERO_IDENTIFICACION_REGISTRO_FISCAL_EXTRANJERO").ToString
                    Me._CODIGO_PAIS_SAT_RESIDENCIA_FISCAL = "" & dReader("CODIGO_PAIS_SAT_RESIDENCIA_FISCAL").ToString
                    Me._CALLE = "" & dReader("CALLE").ToString
                    Me._NUMERO_EXTERIOR = "" & dReader("NUMERO_EXTERIOR").ToString
                    Me._NUMERO_INTERIOR = "" & dReader("NUMERO_INTERIOR").ToString
                    Me._ID_COLONIA = "" & dReader("ID_COLONIA").ToString
                    Me._ID_LOCALIDAD = "" & dReader("ID_LOCALIDAD").ToString
                    Me._REFERENCIA = "" & dReader("REFERENCIA").ToString
                    If txtLEN(dReader("CODIGO_MUNICIPIO").ToString) = True Then Me._CODIGO_MUNICIPIO = CType(dReader("CODIGO_MUNICIPIO").ToString, Integer)
                    Me._CODIGO_ESTADO_SAT = "" & dReader("CODIGO_ESTADO_SAT").ToString
                    Me._CODIGO_PAIS_SAT_DOMICILIO = "" & dReader("CODIGO_PAIS_SAT_DOMICILIO").ToString
                    Me._CODIGO_POSTAL = "" & dReader("CODIGO_POSTAL").ToString
                    Me._ESTATUS = "" & dReader("ESTATUS").ToString
                    Me._CODIGO_USUARIO_CREO = "" & dReader("CODIGO_USUARIO_CREO").ToString
                    Me._FECHA_CREO = CDate(dReader("FECHA_CREO").ToString)
                    If Not (IsDBNull(dReader("CODIGO_USUARIO_MODIFICO"))) Then Me._CODIGO_USUARIO_MODIFICO = "" & dReader("CODIGO_USUARIO_MODIFICO").ToString
                    If Not (IsDBNull(dReader("FECHA_MODIFICO"))) Then Me._FECHA_MODIFICO = CDate(dReader("FECHA_MODIFICO"))
                    Me._DOMICILIO_COMPLETO = "" & dReader("DOMICILIO_COMPLETO").ToString

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
        Dim da As New SqlDataAdapter("SELECT CODIGO_FIGURA_TRANSPORTE,NOMBRE_FIGURA_TRANSPORTE " &
                                     "FROM CFDI_CAT_FIGURAS_TRANSPORTE WHERE NOMBRE_FIGURA_TRANSPORTE LIKE '" & Filtro.ToString & "%' AND ESTATUS='" & ESTATUS & "' ORDER BY NOMBRE_FIGURA_TRANSPORTE", Me._Conexion)
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
        f.Text = "Búsqueda de figuras de transporte por código."
        f.sCampo = "CODIGO_FIGURA_TRANSPORTE"
        f.sOrder = "NOMBRE_FIGURA_TRANSPORTE"
        f.sTable = "CFDI_CAT_FIGURAS_TRANSPORTE"
        f.sQl = "SELECT CODIGO_FIGURA_TRANSPORTE,NOMBRE_FIGURA_TRANSPORTE From CFDI_CAT_FIGURAS_TRANSPORTE WHERE 1=1 AND "
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
        f.Text = "Búsqueda de figuras de transporte por nombre."
        f.sCampo = "NOMBRE_FIGURA_TRANSPORTE"
        f.sOrder = "NOMBRE_FIGURA_TRANSPORTE"
        f.sTable = "CFDI_CAT_FIGURAS_TRANSPORTE"
        f.sQl = "SELECT F.CODIGO_FIGURA_TRANSPORTE,F.NOMBRE_FIGURA_TRANSPORTE,T.NOMBRE_TIPO_FIGURA_TRANSPORTE " &
            "FROM CFDI_CAT_FIGURAS_TRANSPORTE F " &
            "INNER JOIN CFDI_CAT_TIPOS_FIGURAS_TRANSPORTE T ON(F.CODIGO_TIPO_FIGURA_TRANSPORTE=T.CODIGO_TIPO_FIGURA_TRANSPORTE) " &
            "WHERE 1=1 AND "
        f.Inicia("%")
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
        Dim Resultado As String = ""
        Try
            Dim sql As New Class_find("SELECT ISNULL(MAX(CODIGO_FIGURA_TRANSPORTE),0) FROM CFDI_CAT_FIGURAS_TRANSPORTE")
            Resultado = (CType(sql.Result1, Integer) + 1).ToString
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, sProcedure, ex)
        End Try
        Return Resultado
    End Function
#End Region

End Class