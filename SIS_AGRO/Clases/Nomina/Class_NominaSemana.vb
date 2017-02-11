Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Public Class Class_NominaSemana

#Region "Campos"

#Region "Campos de la tabla"
    Private _ID_NOMINA_SEMANA As Integer
    Private _ID_NOMINA_TEMPORADA As Integer
    Private _NUMERO_SEMANA As Integer
    Private _ULTIMO_NUMERO_ARCHIVO_TXT_ALTAS As String
    Private _ULTIMO_NUMERO_ARCHIVO_TXT_BAJAS As String
    Private _NOMINA_GENERADA As String
    Private _FECHA_GENERACION_NOMINA As String
    Private _CODIGO_USUARIO_GENERO_NOMINA As Integer
    Private _ULTIMO_NUMERO_TXT_DISPERSION As String
    Private _FOLIO_POLIZA As String
    Private _POLIZA_GENERADA As Boolean
#End Region

#Region "Campos ligados a la tabla"
    Private _NOMBRE_USUARIO_GENERO_NOMINA As String
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
    Public Property ID_NOMINA_SEMANA() As Integer
        Get
            Return Me._ID_NOMINA_SEMANA
        End Get
        Set(ByVal Value As Integer)
            Me._ID_NOMINA_SEMANA = Value
        End Set
    End Property

    Public Property ID_NOMINA_TEMPORADA() As Integer
        Get
            Return Me._ID_NOMINA_TEMPORADA
        End Get
        Set(ByVal Value As Integer)
            Me._ID_NOMINA_TEMPORADA = Value
        End Set
    End Property

    Public Property NUMERO_SEMANA() As Integer
        Get
            Return Me._NUMERO_SEMANA
        End Get
        Set(ByVal Value As Integer)
            Me._NUMERO_SEMANA = Value
        End Set
    End Property

    Public Property ULTIMO_NUMERO_ARCHIVO_TXT_ALTAS() As String
        Get
            Return Me._ULTIMO_NUMERO_ARCHIVO_TXT_ALTAS
        End Get
        Set(ByVal Value As String)
            Me._ULTIMO_NUMERO_ARCHIVO_TXT_ALTAS = Value
        End Set
    End Property

    Public Property ULTIMO_NUMERO_ARCHIVO_TXT_BAJAS() As String
        Get
            Return Me._ULTIMO_NUMERO_ARCHIVO_TXT_BAJAS
        End Get
        Set(ByVal Value As String)
            Me._ULTIMO_NUMERO_ARCHIVO_TXT_BAJAS = Value
        End Set
    End Property

    Public Property NOMINA_GENERADA() As String
        Get
            Return Me._NOMINA_GENERADA
        End Get
        Set(ByVal Value As String)
            Me._NOMINA_GENERADA = Value
        End Set
    End Property

    Public Property FECHA_GENERACION_NOMINA() As String
        Get
            Return Me._FECHA_GENERACION_NOMINA
        End Get
        Set(ByVal Value As String)
            Me._FECHA_GENERACION_NOMINA = Value
        End Set
    End Property

    Public Property CODIGO_USUARIO_GENERO_NOMINA() As Integer
        Get
            Return Me._CODIGO_USUARIO_GENERO_NOMINA
        End Get
        Set(ByVal Value As Integer)
            Me._CODIGO_USUARIO_GENERO_NOMINA = Value
        End Set
    End Property

    Public Property ULTIMO_NUMERO_TXT_DISPERSION() As String
        Get
            Return Me._ULTIMO_NUMERO_TXT_DISPERSION
        End Get
        Set(ByVal Value As String)
            Me._ULTIMO_NUMERO_TXT_DISPERSION = Value
        End Set
    End Property

    Public Property POLIZA_GENERADA() As Boolean
        Get
            Return Me._POLIZA_GENERADA
        End Get
        Set(ByVal Value As Boolean)
            Me._POLIZA_GENERADA = Value
        End Set
    End Property

    Public Property FOLIO_POLIZA() As String
        Get
            Return Me._FOLIO_POLIZA
        End Get
        Set(ByVal Value As String)
            Me._FOLIO_POLIZA = Value
        End Set
    End Property
#End Region

#Region "Propiedades de campos ligados a la tabla"
    Public Property NOMBRE_USUARIO_GENERO_NOMINA() As String
        Get
            Return Me._NOMBRE_USUARIO_GENERO_NOMINA
        End Get
        Set(ByVal Value As String)
            Me._NOMBRE_USUARIO_GENERO_NOMINA = Value
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
        Me._Nombre_Catalogo = "NOMINA_SEMANA"
        'Me._Nombre_Reporte = "RPT_CATALOGO_NOMINA_DIAS.rpt"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "Select S.*,U.NOMBRE_USUARIO AS NOMBRE_USUARIO_GENERO_NOMINA From NOMINA_SEMANA S LEFT JOIN SIS_USUARIOS U ON(S.CODIGO_USUARIO_GENERO_NOMINA=U.CODIGO_USUARIO)"
        Me._QueryOrder = " Order by S.ID_NOMINA_TEMPORADA,S.NUMERO_SEMANA"
    End Sub                                                         'Inicializa al objeto.

    Public Sub New(ByVal iSemana As Integer)
        Me.New()
        Try
            Me._ID_NOMINA_SEMANA = iSemana
            If Me.Consultar = False Then
                Throw New Exception("La semana no existe.")
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
    Public Function Consultar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand(Me._QuerySelect & " Where S.ID_NOMINA_SEMANA=" & Me._ID_NOMINA_SEMANA.ToString, Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._ID_NOMINA_SEMANA = CType(dReader("ID_NOMINA_SEMANA"), Integer)
                    Me._ID_NOMINA_TEMPORADA = CType(dReader("ID_NOMINA_TEMPORADA"), Integer)
                    Me._NUMERO_SEMANA = CInt(dReader("NUMERO_SEMANA"))
                    Me._ULTIMO_NUMERO_ARCHIVO_TXT_ALTAS = "" & dReader("ULTIMO_NUMERO_ARCHIVO_TXT_ALTAS").ToString
                    Me._ULTIMO_NUMERO_ARCHIVO_TXT_BAJAS = "" & dReader("ULTIMO_NUMERO_ARCHIVO_TXT_BAJAS").ToString
                    Me._NOMINA_GENERADA = "" & dReader("NOMINA_GENERADA").ToString
                    Me._FECHA_GENERACION_NOMINA = "" & dReader("FECHA_GENERACION_NOMINA").ToString
                    If txtLEN(dReader("CODIGO_USUARIO_GENERO_NOMINA").ToString) = True Then
                        Me._CODIGO_USUARIO_GENERO_NOMINA = CInt(dReader("CODIGO_USUARIO_GENERO_NOMINA"))
                        Me._NOMBRE_USUARIO_GENERO_NOMINA = "" & dReader("NOMBRE_USUARIO_GENERO_NOMINA").ToString
                    End If
                    Me._ULTIMO_NUMERO_TXT_DISPERSION = "" & dReader("ULTIMO_NUMERO_TXT_DISPERSION").ToString
                    Me._POLIZA_GENERADA = CBool(dReader("POLIZA_GENERADA").ToString)
                    Me._FOLIO_POLIZA = "" & dReader("FOLIO_POLIZA").ToString

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

    Public Function ObtieneDetalleSemana() As System.Data.DataTable
        Dim dt As New DataTable
        Try
            Dim da As New SqlDataAdapter("MP_NOMINA_DEDUCCIONES_GESTIONA_ABONOS", Me._Conexion)
            da.SelectCommand.CommandType = CommandType.StoredProcedure

            With da.SelectCommand
                .Parameters.Add("@ID_NOMINA_SEMANA", SqlDbType.SmallInt).Value = Me._ID_NOMINA_SEMANA
            End With

            da.Fill(dt)
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "ObtieneDetalleSemana", ex)
        Finally

        End Try
        Return dt
    End Function

    Public Function ObtenerElementos() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter("SELECT ID_NOMINA_SEMANA,NUMERO_SEMANA FROM NOMINA_SEMANA WHERE ID_NOMINA_TEMPORADA=" & Plaza.oSisPlazaNomina.NOMINA_ID_NOMINA_TEMPORADA_ACTIVA.ToString & " Order by ID_NOMINA_TEMPORADA,NUMERO_SEMANA", Me._Conexion)
        Try
            da.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementos", ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerTxtDispersiones() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter("SELECT DISTINCT(NOMBRE_TXT_DISPERSION) NOMBRE_TXT FROM NOMINA_GENERADA_TRABAJADORES WHERE LEN(NOMBRE_TXT_DISPERSION)>0 AND ID_NOMINA_SEMANA=" & Me._ID_NOMINA_SEMANA & " Order by NOMBRE_TXT_DISPERSION", Me._Conexion)
        Try
            da.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerTxtDispersiones", ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerTotalTrabajadoresTarjeta() As Integer
        Dim iTotalTarjetas As Integer = 0
        Dim sql As New Class_find("SELECT COUNT(*) FROM NOMINA_GENERADA_TRABAJADORES WHERE ID_NOMINA_SEMANA=" & Me._ID_NOMINA_SEMANA.ToString & " AND RECIBE_PAGO_TARJETA_BANCARIA='1'")
        Try
            iTotalTarjetas = CInt(sql.Result1)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerTotalTrabajadoresTarjeta", ex)
        Finally
        End Try
        Return iTotalTarjetas
    End Function

    Public Function ObtenerTotalTrabajadoresAltaTarjeta() As Integer
        Dim iTotalTarjetas As Integer = 0
        Dim sql As New Class_find("SELECT COUNT(*) FROM (SELECT P.CODIGO_TRABAJADOR FROM VW_NOMINA_HOJAS_PERCEPCIONES_EXTENDIDA P INNER JOIN NOMINA_CAT_TRABAJADORES T ON (P.CODIGO_TRABAJADOR=T.CODIGO_TRABAJADOR) " & _
                                  "WHERE P.ID_NOMINA_SEMANA=" & Me._ID_NOMINA_SEMANA.ToString & " AND T.RECIBE_PAGO_TARJETA_BANCARIA='1' GROUP BY P.CODIGO_TRABAJADOR) A")
        Try
            iTotalTarjetas = CInt(sql.Result1)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerTotalTrabajadoresAltaTarjeta", ex)
        Finally
        End Try
        Return iTotalTarjetas
    End Function

    Public Function AbonaDescuentosSemana(ByVal iIdDeduccionDetalle As Integer) As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = _Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_NOMINA_DEDUCCIONES_ABONA_DESCUENTO"

            sqlParametro = .Parameters.Add("@ID_DEDUCCION_DETALLE", SqlDbType.SmallInt) : sqlParametro.Value = iIdDeduccionDetalle.ToString
            sqlParametro = .Parameters.Add("@NUMERO_SEMANA_NUEVO", SqlDbType.SmallInt) : sqlParametro.Value = Me._NUMERO_SEMANA.ToString

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me.Nombre_Catalogo, "AbonaDescuentosSemana", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Function GeneraNomina() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = _Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_NOMINA_GENERA"

            sqlParametro = .Parameters.Add("@ID_NOMINA_SEMANA", SqlDbType.SmallInt) : sqlParametro.Value = Me._ID_NOMINA_SEMANA
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Usuario

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me.Nombre_Catalogo, "GeneraNomina", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Function DesaplicarNomina() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = _Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_NOMINA_DESAPLICA"

            sqlParametro = .Parameters.Add("@ID_NOMINA_SEMANA", SqlDbType.SmallInt) : sqlParametro.Value = Me._ID_NOMINA_SEMANA
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Usuario

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me.Nombre_Catalogo, "DesaplicarNomina", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Function GeneraNominaAlta(ByVal sAccion As Boolean, Optional ByVal iRango1 As Integer = 0, Optional ByVal iRango2 As Integer = 0) As System.Data.DataTable
        Dim dt As New DataTable
        Try
            Dim da As New SqlDataAdapter("MP_NOMINA_GENERA_ALTA", Me._Conexion)
            da.SelectCommand.CommandType = CommandType.StoredProcedure

            With da.SelectCommand
                .Parameters.Add("@ID_NOMINA_SEMANA", SqlDbType.Int).Value = Me._ID_NOMINA_SEMANA
                .Parameters.Add("@RANGO1", SqlDbType.SmallInt).Value = iRango1
                .Parameters.Add("@RANGO2", SqlDbType.SmallInt).Value = iRango2
                .Parameters.Add("@ACCION", SqlDbType.Char, 1).Value = Convert.ToInt32(sAccion).ToString
            End With

            da.Fill(dt)
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "GeneraNominaAlta", ex)
        Finally

        End Try
        Return dt
    End Function

    Public Function GeneraNominaPuntoPago() As System.Data.DataTable
        Dim dt As New DataTable
        Try
            Dim da As New SqlDataAdapter("MP_NOMINA_GENERA_VALIDA_PUNTOS_PAGO", Me._Conexion)
            da.SelectCommand.CommandType = CommandType.StoredProcedure

            With da.SelectCommand
                .Parameters.Add("@ID_NOMINA_SEMANA", SqlDbType.Int).Value = Me._ID_NOMINA_SEMANA
            End With

            da.Fill(dt)
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "GeneraNominaPuntoPago", ex)
        Finally

        End Try
        Return dt
    End Function

    'Public Function GeneraPolizaNomina() As Boolean
    '    Dim cmd As New SqlCommand
    '    Dim sqlParametro As SqlParameter
    '    With cmd
    '        .Connection = _Conexion
    '        .CommandTimeout = 0
    '        .CommandType = CommandType.StoredProcedure
    '        .CommandText = "MP_CONTABILIDAD_GENERA_POLIZA_NOMINA"

    '        sqlParametro = .Parameters.Add("@ID_NOMINA_SEMANA", SqlDbType.SmallInt) : sqlParametro.Value = Me._ID_NOMINA_SEMANA
    '        sqlParametro = .Parameters.Add("@CODIGO_USUARIO", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Usuario

    '        Try
    '            Me._Conexion.Open()
    '            .ExecuteNonQuery()
    '            GeneraPolizaNomina = True
    '        Catch ex As Exception
    '            HandleError(Me.Nombre_Catalogo, "GeneraNomina", ex)
    '        Finally
    '            Me._Conexion.Close()
    '            cmd.Dispose()
    '            sqlParametro = Nothing
    '        End Try

    '    End With
    'End Function

    Public Function ObtienePrepoliza() As System.Data.DataTable
        Dim dt As New DataTable
        Try
            Dim da As New SqlDataAdapter("MP_CONTABILIDAD_GENERA_POLIZA_NOMINA", Me._Conexion)
            da.SelectCommand.CommandType = CommandType.StoredProcedure

            With da.SelectCommand
                .Parameters.Add("@ID_NOMINA_SEMANA", SqlDbType.Int).Value = Me._ID_NOMINA_SEMANA
                .Parameters.Add("@CODIGO_USUARIO", SqlDbType.SmallInt).Value = Usuario.Codigo_Usuario
            End With

            da.Fill(dt)
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "ObtienePrepoliza", ex)
        Finally

        End Try
        Return dt
    End Function

    'Public Function GeneraNominaDispercion(ByVal sAccion As String, Optional ByVal sTxtDispersion As String = "", Optional ByVal iRango1 As Integer = 0, Optional ByVal iRango2 As Integer = 0) As System.Data.DataTable
    Public Function GeneraNominaDispercion(ByVal sAccion As String, Optional ByVal sTxtDispersion As String = "", Optional ByVal iConsecutivo As Integer = 0, Optional ByVal iRango As Integer = 0) As System.Data.DataTable
        Dim dt As New DataTable
        Try
            Dim da As New SqlDataAdapter("MP_NOMINA_GENERADA_DISPERSION", Me._Conexion)
            da.SelectCommand.CommandType = CommandType.StoredProcedure

            With da.SelectCommand
                .Parameters.Add("@ID_NOMINA_SEMANA", SqlDbType.Int).Value = Me._ID_NOMINA_SEMANA
                .Parameters.Add("@NOMBRE_TXT_DISPERSION", SqlDbType.NVarChar, 225).Value = sTxtDispersion
                '.Parameters.Add("@RANGO1", SqlDbType.SmallInt).Value = iRango1
                '.Parameters.Add("@RANGO2", SqlDbType.SmallInt).Value = iRango2
                .Parameters.Add("@CONSECUTIVO", SqlDbType.SmallInt).Value = iConsecutivo
                .Parameters.Add("@RANGO", SqlDbType.SmallInt).Value = iRango
                .Parameters.Add("@ACCION", SqlDbType.NVarChar, 50).Value = sAccion
            End With

            da.Fill(dt)
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "GeneraNominaDispercion", ex)
        Finally

        End Try
        Return dt
    End Function

    Public Function ConfirmaRechazaNominaDispercion(ByVal sCodigo As String, ByVal sTxtDispersion As String, ByVal bAccion As Boolean) As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = _Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_NOMINA_GENERADA_TRABAJADORES_DISPERSION_CONFIRMA_RECHAZA"

            sqlParametro = .Parameters.Add("@ID_NOMINA_SEMANA", SqlDbType.SmallInt) : sqlParametro.Value = Me._ID_NOMINA_SEMANA
            sqlParametro = .Parameters.Add("@CODIGO_TRABAJADOR", SqlDbType.NVarChar, 10) : sqlParametro.Value = sCodigo
            sqlParametro = .Parameters.Add("@NOMBRE_TXT_DISPERSION", SqlDbType.NVarChar, 225) : sqlParametro.Value = sTxtDispersion
            sqlParametro = .Parameters.Add("@ACCION", SqlDbType.NVarChar, 10) : sqlParametro.Value = Convert.ToInt32(bAccion)

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me.Nombre_Catalogo, "ConfirmaRechazaNominaDispercion", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Function AplicaNominaDispercionSemana() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = _Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_NOMINA_GENERADA_CONFIRMA_SEMANA_DISPERSION"

            sqlParametro = .Parameters.Add("@ID_NOMINA_SEMANA", SqlDbType.SmallInt) : sqlParametro.Value = Me._ID_NOMINA_SEMANA

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me.Nombre_Catalogo, "AplicaNominaDispercionSemana", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Function ActualizaUltimoNumeroTxtDispercionSemana() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = _Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_NOMINA_GENERADA_ACTUALIZA_ULTIMO_NUMERO_TXT_SEMANA_DISPERSION"

            sqlParametro = .Parameters.Add("@ID_NOMINA_SEMANA", SqlDbType.SmallInt) : sqlParametro.Value = Me._ID_NOMINA_SEMANA
            sqlParametro = .Parameters.Add("@ULTIMO_NUMERO_TXT_DISPERSION", SqlDbType.SmallInt) : sqlParametro.Value = Me._ULTIMO_NUMERO_TXT_DISPERSION

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me.Nombre_Catalogo, "ActualizaUltimoNumeroTxtDispercionSemana", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Function ActualizaUltimoNumeroTxtAltaSemana() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = _Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_NOMINA_GENERADA_ACTUALIZA_ULTIMO_NUMERO_ARCHIVO_TXT_ALTAS_SEMANA"

            sqlParametro = .Parameters.Add("@ID_NOMINA_SEMANA", SqlDbType.SmallInt) : sqlParametro.Value = Me._ID_NOMINA_SEMANA
            sqlParametro = .Parameters.Add("@ULTIMO_NUMERO_ARCHIVO_TXT_ALTAS", SqlDbType.SmallInt) : sqlParametro.Value = Me._ULTIMO_NUMERO_ARCHIVO_TXT_ALTAS
            'sqlParametro = .Parameters.Add("@ULTIMO_NUMERO_TXT_DISPERSION", SqlDbType.SmallInt) : sqlParametro.Value = Me._ULTIMO_NUMERO_ARCHIVO_TXT_ALTAS

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me.Nombre_Catalogo, "ActualizaUltimoNumeroTxtAltaSemana", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Function ConsultarNavegadoCostosPresupuesto(ByVal sCuenta1 As String, ByVal sCuenta2 As String) As System.Data.DataTable
        Dim dt As New DataTable
        Try
            Dim da As New SqlDataAdapter("MP_RPT_NOMINA_NAVEGADOR_PRESUPUESTOS", Me._Conexion)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            With da.SelectCommand
                .Parameters.Add("@ID_NOMINA_SEMANA", SqlDbType.NVarChar, 20) : .Parameters("@ID_NOMINA_SEMANA").Value = Me._ID_NOMINA_SEMANA
                .Parameters.Add("@CUENTA1", SqlDbType.NVarChar, 20) : .Parameters("@CUENTA1").Value = sCuenta1
                .Parameters.Add("@CUENTA2", SqlDbType.NVarChar, 20) : .Parameters("@CUENTA2").Value = sCuenta2
            End With
            da.Fill(dt)
            dt.Columns.Remove("EMPRESA_NOMBRE")
            dt.Columns.Remove("EMPRESA_DOMICILIO")
            dt.Columns.Remove("EMPRESA_CIUDAD")
            dt.Columns.Remove("EMPRESA_ESTADO")
            dt.Columns.Remove("EMPRESA_RFC")
            dt.Columns.Remove("EMPRESA_TELEFONO")
            'dt.Columns.Remove("NOMBRE_EJERCICIO")

        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "ConsultarNavegadoCostosPresupuesto", ex)
        Finally

        End Try
        Return dt
    End Function

    Public Function GrabaFolioPoliza(ByVal sFolioPoliza As String) As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = _Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CONTABILIDAD_NOMINA_GRABA_FOLIO_POLIZA"

            sqlParametro = .Parameters.Add("@ID_NOMINA_SEMANA", SqlDbType.SmallInt) : sqlParametro.Value = Me._ID_NOMINA_SEMANA
            sqlParametro = .Parameters.Add("@FOLIO_POLIZA", SqlDbType.NVarChar, 15) : sqlParametro.Value = sFolioPoliza

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True

                'Se carga el folio de la póliza recién creada
                Me._FOLIO_POLIZA = sFolioPoliza
            Catch ex As Exception
                HandleError(Me.Nombre_Catalogo, "GrabaFolioPoliza", ex)
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
