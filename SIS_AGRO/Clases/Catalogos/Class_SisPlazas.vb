Option Strict On
Imports System.Data
Imports System.Data.SqlClient

Public Class Class_SisPlazas
    Inherits Class_Catalogos


#Region "Campos"

#Region "Campos de la tabla"
    Private _CODIGO_PLAZA As Integer
    Private _NOMBRE_PLAZA As String
    'ESTATUS SE HEREDA
    Private _ESTATUS_PLAZA As String
    Private _Identificador As String
    Private _Impuesto_Porcentaje As Decimal
    Private _Codigo_Proveedor As String
    Private _PLAZO_VENTA_CONTADO As Integer
    Private _CUENTA_CONTABLE_VENTAS As String

    Private _CALLE As String
    Private _NUMERO_EXTERIOR As String
    Private _NUMERO_INTERIOR As String
    Private _COLONIA As String
    Private _LOCALIDAD As String
    Private _CIUDAD As String
    Private _ESTADO As String
    Private _PAIS As String
    Private _CODIGO_POSTAL As String
    Private _TELEFONO As String
    Private _VALIDAR_FECHA_VENTAS As String
    Private _CODIGO_COLONIA_SAT As String
    Private _CODIGO_LOCALIDAD_SAT As String
    Private _CODIGO_MUNICIPIO As String
    Private _CODIGO_ESTADO As String
    Private _CODIGO_PAIS_SAT As String

    Private _CODIGO_ESTADO_NUMERICO As Integer
    Private _CODIGO_CLIENTES_EXPORTACION As String
    Private _CODIGO_CLIENTES_NACIONAL As String
    Private _CUENTA_CONTABLE_MAYOR_EXPORTACION As String
    Private _CUENTA_CONTABLE_MAYOR_NACIONAL As String
    Private _CUENTA_CONTABLE_CONTADO_EXPORTACION As String
    Private _CUENTA_CONTABLE_CONTADO_NACIONAL As String
    Private _CODIGO_ALMACEN_PRINCIPAL As String
    Private _CODIGO_ZONA_PRINCIPAL As String

    Private _ID_CON_EJERCICIO As Integer
    Private _FECHA_INICIO As Date
    Private _FECHA_FINAL As Date
    Private _CUENTA_DESCUENTOS_REBAJAS_NACIONALES As String
#End Region

#Region "Campos ligados a la tabla"
    Private _NOMBRE_EJERCICIO As String
    Private _CODIGO_ESTADO_SAT As String
    Private _CODIGO_MUNICIPIO_SAT As String
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

#Region "Clase Detalle"
    Public oSisPlazaNomina As Class_SisEmpresaNomina
#End Region
#End Region

#Region "Propiedades"

#Region "Propiedades Campos de la tabla"

    Public Property CODIGO_PLAZA() As Integer
        Get
            Return Me._CODIGO_PLAZA
        End Get
        Set(ByVal Value As Integer)
            Me._CODIGO_PLAZA = Value
        End Set
    End Property

    Public Property NOMBRE_PLAZA() As String
        Get
            Return Me._NOMBRE_PLAZA
        End Get
        Set(ByVal Value As String)
            Me._NOMBRE_PLAZA = Value
        End Set
    End Property

    Public Property ESTATUS_PLAZA() As String
        Get
            Return Me._ESTATUS_PLAZA
        End Get
        Set(ByVal Value As String)
            Me._ESTATUS_PLAZA = Value
        End Set
    End Property

    Public Property Identificador() As String
        Get
            Return Me._Identificador
        End Get
        Set(ByVal value As String)
            Me._Identificador = value
        End Set
    End Property

    Public Property Impuesto_Porcentaje() As Decimal
        Get
            Return Me._Impuesto_Porcentaje
        End Get
        Set(ByVal value As Decimal)
            Me._Impuesto_Porcentaje = value
        End Set
    End Property

    Public ReadOnly Property Codigo_Proveedor() As String
        Get
            Return Me._Codigo_Proveedor
        End Get
    End Property

    Public ReadOnly Property CALLE() As String
        Get
            Return Me._CALLE
        End Get
    End Property

    Public ReadOnly Property NUMERO_EXTERIOR() As String
        Get
            Return Me._NUMERO_EXTERIOR
        End Get
    End Property

    Public ReadOnly Property NUMERO_INTERIOR() As String
        Get
            Return Me._NUMERO_INTERIOR
        End Get
    End Property

    Public ReadOnly Property COLONIA() As String
        Get
            Return Me._COLONIA
        End Get
    End Property

    Public ReadOnly Property LOCALIDAD() As String
        Get
            Return Me._LOCALIDAD
        End Get
    End Property

    Public ReadOnly Property CIUDAD() As String
        Get
            Return Me._CIUDAD
        End Get
    End Property

    Public ReadOnly Property ESTADO() As String
        Get
            Return Me._ESTADO
        End Get
    End Property

    Public ReadOnly Property PAIS() As String
        Get
            Return Me._PAIS
        End Get
    End Property

    Public ReadOnly Property CODIGO_POSTAL() As String
        Get
            Return Me._CODIGO_POSTAL
        End Get
    End Property

    Public ReadOnly Property TELEFONO() As String
        Get
            Return Me._TELEFONO
        End Get
    End Property

    Public ReadOnly Property CUENTA_CONTABLE_VENTAS() As String
        Get
            Return Me._CUENTA_CONTABLE_VENTAS
        End Get
    End Property

    Public ReadOnly Property PLAZO_VENTA_CONTADO() As Integer
        Get
            Return Me._PLAZO_VENTA_CONTADO
        End Get
    End Property

    Public ReadOnly Property VALIDAR_FECHA_VENTAS() As String
        Get
            Return Me._VALIDAR_FECHA_VENTAS
        End Get
    End Property
    Public ReadOnly Property CODIGO_COLONIA_SAT() As String
        Get
            Return Me._CODIGO_COLONIA_SAT
        End Get
    End Property

    Public ReadOnly Property CODIGO_LOCALIDAD_SAT() As String
        Get
            Return Me._CODIGO_LOCALIDAD_SAT
        End Get
    End Property

    Public ReadOnly Property CODIGO_MUNICIPIO() As String
        Get
            Return Me._CODIGO_MUNICIPIO
        End Get
    End Property

    Public ReadOnly Property CODIGO_ESTADO() As String
        Get
            Return Me._CODIGO_ESTADO
        End Get
    End Property

    Public ReadOnly Property CODIGO_PAIS_SAT() As String
        Get
            Return Me._CODIGO_PAIS_SAT
        End Get
    End Property

    Public ReadOnly Property CODIGO_ESTADO_NUMERICO() As Integer
        Get
            Return Me._CODIGO_ESTADO_NUMERICO
        End Get
    End Property

    Public ReadOnly Property CODIGO_ALMACEN_PRINCIPAL() As String
        Get
            Return Me._CODIGO_ALMACEN_PRINCIPAL
        End Get
    End Property

    Public ReadOnly Property CODIGO_ZONA_PRINCIPAL() As String
        Get
            Return Me._CODIGO_ZONA_PRINCIPAL
        End Get
    End Property

    Public Property ID_CON_EJERCICIO() As Integer
        Get
            Return Me._ID_CON_EJERCICIO
        End Get
        Set(ByVal value As Integer)
            Me._ID_CON_EJERCICIO = value
        End Set
    End Property

    Public Property FECHA_INICIO() As Date
        Get
            Return Me._FECHA_INICIO
        End Get
        Set(ByVal value As Date)
            Me._FECHA_INICIO = value
        End Set
    End Property

    Public Property FECHA_FINAL() As Date
        Get
            Return Me._FECHA_FINAL
        End Get
        Set(ByVal value As Date)
            Me._FECHA_FINAL = value
        End Set
    End Property

    Public ReadOnly Property CUENTA_DESCUENTOS_REBAJAS_NACIONALES() As String
        Get
            Return Me._CUENTA_DESCUENTOS_REBAJAS_NACIONALES
        End Get
    End Property
#End Region

#Region "Propiedades de campos ligados a la tabla"

    Public ReadOnly Property NOMBRE_EJERCICIO() As String
        Get
            Return Me._NOMBRE_EJERCICIO
        End Get
    End Property
    Public ReadOnly Property CODIGO_ESTADO_SAT() As String
        Get
            Return Me._CODIGO_ESTADO_SAT
        End Get
    End Property

    Public ReadOnly Property CODIGO_MUNICIPIO_SAT() As String
        Get
            Return Me._CODIGO_MUNICIPIO_SAT
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
    Public Sub New(ByVal bAbrirConexion As Boolean, ByVal bLogin As Boolean)
        Me._Nombre_Catalogo = "SIS_PLAZAS"
    End Sub

    Public Sub New()
        Me._Nombre_Catalogo = "SIS_PLAZAS"
        Me._Nombre_Reporte = "RPT_CATALOGO_PLAZAS.rpt"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        'Me._QuerySelect = "Select * From SIS_PLAZAS"
        Me._QuerySelect = "SELECT P.*,E.NOMBRE_EJERCICIO FROM SIS_PLAZAS P INNER JOIN CON_EJERCICIOS E ON(P.ID_CON_EJERCICIO=E.ID_CON_EJERCICIO) "
        Me._QueryOrder = " Order by NOMBRE_PLAZA"

        Me.oSisPlazaNomina = New Class_SisEmpresaNomina(Empresa_Sistema.conexion)
    End Sub

    Public Sub New(ByVal iCODPlaza As Integer)
        Me.New()
        Try
            Me.CODIGO_PLAZA = iCODPlaza
            If Me.Consultar = False Then
                Throw New Exception("La Plaza no existe.")
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

    Public Overrides Function Actualizar() As Boolean
        MsgBox("No desarrollado.", MsgBoxStyle.Exclamation, Me.Nombre_Catalogo)
    End Function

    Public Overrides Function Consultar() As Boolean
        Dim bResultado As Boolean = False
        'Dim cmd As New SqlCommand(Me._QuerySelect & " Where P.CODIGO_PLAZA=" & CODIGO_PLAZA, Me._Conexion)

        Dim cmd As New SqlCommand("SELECT P.*,J.NOMBRE_EJERCICIO,E.CODIGO_ESTADO_SAT,M.CODIGO_MUNICIPIO_SAT " & _
                                  "FROM SIS_PLAZAS P " & _
                                  "INNER JOIN CON_EJERCICIOS J ON(P.ID_CON_EJERCICIO=J.ID_CON_EJERCICIO) " & _
                                  "LEFT JOIN SIS_ESTADOS E ON(P.CODIGO_ESTADO=E.CODIGO_ESTADO) " & _
                                  "LEFT JOIN CAT_MUNICIPIOS M ON(P.CODIGO_MUNICIPIO=M.CODIGO_MUNICIPIO) " & _
                                  "WHERE P.CODIGO_PLAZA=" & CODIGO_PLAZA, Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._CODIGO_PLAZA = CType(dReader("CODIGO_PLAZA"), Integer)
                    Me._NOMBRE_PLAZA = Trim("" & dReader("NOMBRE_PLAZA").ToString)
                    'Me.ESTATUS_EJERCICIO = "" & dReader("ESTATUS_EJERCICIO").ToString
                    Me._ESTATUS_PLAZA = Trim("" & dReader("ESTATUS_PLAZA").ToString)
                    Me._Identificador = "" & dReader("IDENTIFICADOR").ToString
                    Me._Impuesto_Porcentaje = CDec(dReader("IMPUESTO_PORCENTAJE"))
                    Me._Codigo_Proveedor = "" & dReader("Codigo_Proveedor").ToString
                    Me._PLAZO_VENTA_CONTADO = CInt(dReader("PLAZO_VENTA_CONTADO"))
                    Me._CUENTA_CONTABLE_VENTAS = "" & dReader("CUENTA_CONTABLE_VENTAS").ToString

                    Me._CALLE = "" & dReader("CALLE").ToString
                    Me._NUMERO_EXTERIOR = "" & dReader("NUMERO_EXTERIOR").ToString
                    Me._NUMERO_INTERIOR = "" & dReader("NUMERO_INTERIOR").ToString
                    Me._COLONIA = "" & dReader("COLONIA").ToString
                    Me._LOCALIDAD = "" & dReader("LOCALIDAD").ToString
                    Me._CIUDAD = "" & dReader("CIUDAD").ToString
                    Me._ESTADO = "" & dReader("ESTADO").ToString
                    Me._PAIS = "" & dReader("PAIS").ToString
                    Me._CODIGO_POSTAL = "" & dReader("CODIGO_POSTAL").ToString
                    Me._TELEFONO = "" & dReader("TELEFONO").ToString
                    Me._CODIGO_COLONIA_SAT = "" & dReader("CODIGO_COLONIA_SAT").ToString
                    Me._CODIGO_LOCALIDAD_SAT = "" & dReader("CODIGO_LOCALIDAD_SAT").ToString
                    Me._CODIGO_MUNICIPIO = "" & dReader("CODIGO_MUNICIPIO").ToString
                    Me._CODIGO_ESTADO = "" & dReader("CODIGO_ESTADO").ToString
                    Me._CODIGO_PAIS_SAT = "" & dReader("CODIGO_PAIS_SAT").ToString

                    Me._CODIGO_ESTADO_SAT = "" & dReader("CODIGO_ESTADO_SAT").ToString
                    Me._CODIGO_MUNICIPIO_SAT = "" & dReader("CODIGO_MUNICIPIO_SAT").ToString

                    Me._VALIDAR_FECHA_VENTAS = "" & dReader("VALIDAR_FECHA_VENTAS").ToString
                    Me._CODIGO_ESTADO_NUMERICO = CInt(dReader("CODIGO_ESTADO_NUMERICO"))
                    Me._CODIGO_ALMACEN_PRINCIPAL = "" & dReader("CODIGO_ALMACEN_PRINCIPAL").ToString
                    Me._CODIGO_ZONA_PRINCIPAL = "" & dReader("CODIGO_ZONA_PRINCIPAL").ToString

                    Me._ID_CON_EJERCICIO = CInt(dReader("ID_CON_EJERCICIO").ToString)
                    Me._FECHA_INICIO = CDate(dReader("FECHA_INICIO").ToString)
                    Me._FECHA_FINAL = CDate(dReader("FECHA_FINAL").ToString)
                    Me._NOMBRE_EJERCICIO = "" & dReader("NOMBRE_EJERCICIO").ToString
                    Me._CUENTA_DESCUENTOS_REBAJAS_NACIONALES = "" & dReader("CUENTA_DESCUENTOS_REBAJAS_NACIONALES").ToString

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

    Public Overrides Function Insertar() As Boolean
        MsgBox("No desarrollado.", MsgBoxStyle.Exclamation, Me.Nombre_Catalogo)
    End Function

    ''' <summary>
    ''' Devuelve un datatable con todos los registros de la tabla
    ''' </summary>
    Public Overrides Function ObtenerElementos() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dsCat As New SqlDataAdapter(Me._QuerySelect & Me._QueryOrder, Me._Conexion)
        Try
            dsCat.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementos", ex)
        Finally
            dsCat.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerElementosParaReporte() As System.Data.DataTable
        Dim dTable As New DataTable, dRow As DataRow
        Dim da As New SqlDataAdapter(Me._QuerySelect & Me._QueryOrder, Me._Conexion)
        Try
            da.Fill(dTable)
            dRow = dTable.NewRow
            dRow("CODIGO_PLAZA") = 0
            dRow("NOMBRE_PLAZA") = "TODOS"
            dTable.Rows.Add(dRow)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementosParaReporte", ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

    ''' <summary>
    ''' Devuelve un datatable con todos los registros de la tabla que conicidan para 
    ''' el id de usuario.
    ''' </summary>
    Public Function ObtenerPlazasPorUsuario() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dsCat As New SqlDataAdapter("SELECT CODIGO_PLAZA,NOMBRE_PLAZA FROM VW_SIS_RELACION_USUARIOS_PLAZAS_EXTENDIDO WHERE CODIGO_USUARIO=" & Usuario.Codigo_Usuario & "", Me._Conexion)
        Try
            dsCat.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerPlazasPorUsuario", ex)
        Finally
            dsCat.Dispose()
        End Try
        Return dTable
    End Function

    ''' <summary>
    ''' Despliega la búsqueda visual por código.
    ''' </summary>
    Public Overrides Function BusquedaVisual_PorCodigo() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de plazas por Código."
        f.sCampo = "CODIGO_PLAZA"
        f.sOrder = "NOMBRE_PLAZA"
        f.sTable = "SIS_PLAZAS"
        f.sQl = "Select CODIGO_PLAZA,NOMBRE_PLAZA From SIS_PLAZAS Where 1=1 And"
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

    ''' <summary>
    ''' Despliega la búsqueda visual por descripción.
    ''' </summary>
    Public Overrides Function BusquedaVisual_PorDescripcion() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de plazas por Descripción."
        f.sCampo = "NOMBRE_PLAZA"
        f.sOrder = "NOMBRE_PLAZA"
        f.sTable = "SIS_PLAZAS"
        f.sQl = "Select CODIGO_PLAZA,NOMBRE_PLAZA From SIS_PLAZAS Where 1=1 And"
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

    Public Function ValidarPeriodoTrabajo(ByVal dtFecha As Date) As Boolean
        Try
            Dim ValidaPeriodo As New Class_find("SELECT 1,ESTATUS_EJERCICIO,NOMBRE_EJERCICIO FROM CON_EJERCICIOS WHERE ID_CON_EJERCICIO=" & Plaza.ID_CON_EJERCICIO & _
                    " AND (CAST('" & Format(dtFecha, "yyyy-dd-MM") & "' AS DATETIME) BETWEEN '" & Format(Plaza.FECHA_INICIO, "yyyy-dd-MM") & "' AND '" & Format(Plaza.FECHA_FINAL, "yyyy-dd-MM") & "')")
            'SE AGREGÓ EL CAST A LA FECHA PARA EVITAR LA COMPRACION DE STRING PORQUE EL SQL NO DISTINGUE QUE SE COMPARABA CON FECHAS

            If ValidaPeriodo.Result1.Length = 0 Then
                MsgBox("La fecha esta fuera del periodo de trabajo.", MsgBoxStyle.Exclamation, Me.Nombre_Catalogo)
                Return False
            End If

            If ValidaPeriodo.Result2.ToString <> "A" Then
                MsgBox("El ejercicio " & ValidaPeriodo.Result3.ToString & " no esta abierto .", MsgBoxStyle.Exclamation, Me.Nombre_Catalogo)
                Return False
            End If

            Return True
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "ValidarPeriodoTrabajo", ex)
        End Try
    End Function

    Public Sub ActualizaNombreEjercicio()
        Dim sql As New Class_find("SELECT NOMBRE_EJERCICIO FROM CON_EJERCICIOS WHERE ID_CON_EJERCICIO=" & Me.ID_CON_EJERCICIO)
        Me._NOMBRE_EJERCICIO = sql.Result1
        sql = Nothing
    End Sub

    Public Function ActualizaFechas() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CONTABILIDAD_ACTUALIZA_FECHAS_PLAZA"

            sqlParametro = .Parameters.Add("@FECHA_INICIO", SqlDbType.DateTime) : sqlParametro.Value = Me._FECHA_INICIO
            sqlParametro = .Parameters.Add("@FECHA_FINAL", SqlDbType.DateTime) : sqlParametro.Value = Me._FECHA_FINAL
            sqlParametro = .Parameters.Add("@ID_CON_EJERCICIO", SqlDbType.SmallInt) : sqlParametro.Value = Me._ID_CON_EJERCICIO
            sqlParametro = .Parameters.Add("@CODIGO_PLAZA", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Plaza

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me.Nombre_Catalogo, "ActualizaFechas", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

#End Region

End Class


