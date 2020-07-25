Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

Public Class Class_Contabilidad_Poliza_Global

#Region "Campos"

#Region "Campos de la tabla"
    Private _FOLIO_POLIZA As String
    Private _CODIGO_PLAZA As Integer
    Private _CODIGO_USUARIO_GRABO As Integer
    Private _NOMBRE_USUARIO_GRABO As String
    Private _CODIGO_TIPO_DOCUMENTO As String
    Private _ESTATUS_POLIZA As String
    Private _ESTATUS As String
    Private _FECHA As Date
    Private _FECHA_SERVIDOR As Date
    Private _CONCEPTO1 As String
    Private _CONCEPTO2 As String
    Private _CARGO As Double
    Private _ABONO As Double
    Private _FOLIO_ORIGEN As String
    Private _TIPO_CONTABILIDAD As String
    Private _CODIGO_USUARIO_CANCELO As Integer
    Private _NOMBRE_USUARIO_CANCELO As String
    Private _FECHA_CANCELACION As Date
    Private _FECHA_CANCELACION_SERVIDOR As Date
    Private _CODIGO_USUARIO_REACTIVO As Integer
    Private _NOMBRE_USUARIO_REACTIVO As String
    Private _FECHA_REACTIVACION_SERVIDOR As Date
    Private _CODIGO_LISTA_FACTURAS_RECIBIDAS As String
    Private _FOLIO_CONTRAPOLIZA As String
#End Region

#Region "Campos ligados a la tabla"
    Private _Existe As Boolean 'lectura
#End Region

#Region "Clase Detalle"
    Public oPolizaDetalle As New Class_Contabilidad_Poliza_Detalle
#End Region

#Region "Campos de sistema"
    Private _Nombre_Catalogo As String
    Private _Conexion As SqlConnection
    Private _QuerySelect As String
#End Region

#End Region

#Region "Propiedades"

#Region "Propiedades Campos de la tabla"
    Public Property FOLIO_POLIZA() As String
        Get
            Return Me._FOLIO_POLIZA
        End Get
        Set(ByVal value As String)
            Me._FOLIO_POLIZA = value
        End Set
    End Property

    Public Property CODIGO_PLAZA() As Integer
        Get
            Return Me._CODIGO_PLAZA
        End Get
        Set(ByVal value As Integer)
            Me._CODIGO_PLAZA = value
        End Set
    End Property

    Public Property CODIGO_USUARIO_GRABO() As Integer
        Get
            Return Me._CODIGO_USUARIO_GRABO
        End Get
        Set(ByVal value As Integer)
            Me._CODIGO_USUARIO_GRABO = value
        End Set
    End Property

    Public Property NOMBRE_USUARIO_GRABO() As String
        Get
            Return Me._NOMBRE_USUARIO_GRABO
        End Get
        Set(ByVal value As String)
            Me._NOMBRE_USUARIO_GRABO = value
        End Set
    End Property

    Public Property CODIGO_TIPO_DOCUMENTO() As String
        Get
            Return Me._CODIGO_TIPO_DOCUMENTO
        End Get
        Set(ByVal value As String)
            Me._CODIGO_TIPO_DOCUMENTO = value
        End Set
    End Property

    Public Property ESTATUS_POLIZA() As String
        Get
            Return Me._ESTATUS_POLIZA
        End Get
        Set(ByVal value As String)
            Me._ESTATUS_POLIZA = value
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

    Public Property FECHA() As Date
        Get
            Return Me._FECHA
        End Get
        Set(ByVal value As Date)
            Me._FECHA = value
        End Set
    End Property

    Public ReadOnly Property FECHA_SERVIDOR() As Date
        Get
            Return Me._FECHA_SERVIDOR
        End Get
    End Property

    Public Property CONCEPTO1() As String
        Get
            Return Me._CONCEPTO1
        End Get
        Set(ByVal value As String)
            Me._CONCEPTO1 = value
        End Set
    End Property

    Public Property CONCEPTO2() As String
        Get
            Return Me._CONCEPTO2
        End Get
        Set(ByVal value As String)
            Me._CONCEPTO2 = value
        End Set
    End Property

    Public Property CARGO() As Double
        Get
            Return Me._CARGO
        End Get
        Set(ByVal value As Double)
            Me._CARGO = value
        End Set
    End Property

    Public Property ABONO() As Double
        Get
            Return Me._ABONO
        End Get
        Set(ByVal value As Double)
            Me._ABONO = value
        End Set
    End Property

    Public Property FOLIO_ORIGEN() As String
        Get
            Return Me._FOLIO_ORIGEN
        End Get
        Set(ByVal value As String)
            Me._FOLIO_ORIGEN = value
        End Set
    End Property

    Public Property TIPO_CONTABILIDAD() As String
        Get
            Return Me._TIPO_CONTABILIDAD
        End Get
        Set(ByVal value As String)
            Me._TIPO_CONTABILIDAD = value
        End Set
    End Property

    Public ReadOnly Property CODIGO_USUARIO_CANCELO() As Integer
        Get
            Return Me._CODIGO_USUARIO_CANCELO
        End Get
    End Property

    Public Property NOMBRE_USUARIO_CANCELO() As String
        Get
            Return Me._NOMBRE_USUARIO_CANCELO
        End Get
        Set(ByVal value As String)
            Me._NOMBRE_USUARIO_CANCELO = value
        End Set
    End Property

    Public Property FECHA_CANCELACION() As Date
        Get
            Return Me._FECHA_CANCELACION
        End Get
        Set(ByVal value As Date)
            Me._FECHA_CANCELACION = value
        End Set
    End Property

    Public ReadOnly Property FECHA_CANCELACION_SERVIDOR() As Date
        Get
            Return Me._FECHA_CANCELACION_SERVIDOR
        End Get
    End Property

    Public Property CODIGO_USUARIO_REACTIVO() As Integer
        Get
            Return Me._CODIGO_USUARIO_REACTIVO
        End Get
        Set(ByVal value As Integer)
            Me._CODIGO_USUARIO_REACTIVO = value
        End Set
    End Property

    Public ReadOnly Property NOMBRE_USUARIO_REACTIVO() As String
        Get
            Return Me._NOMBRE_USUARIO_REACTIVO
        End Get
    End Property

    Public ReadOnly Property FECHA_REACTIVACION_SERVIDOR() As Date
        Get
            Return Me._FECHA_REACTIVACION_SERVIDOR
        End Get
    End Property

    Public Property CODIGO_LISTA_FACTURAS_RECIBIDAS() As String
        Get
            Return Me._CODIGO_LISTA_FACTURAS_RECIBIDAS
        End Get
        Set(ByVal value As String)
            Me._CODIGO_LISTA_FACTURAS_RECIBIDAS = value
        End Set
    End Property

    Public Property FOLIO_CONTRAPOLIZA() As String
        Get
            Return Me._FOLIO_CONTRAPOLIZA
        End Get
        Set(ByVal value As String)
            Me._FOLIO_CONTRAPOLIZA = value
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

#Region "Propiedad Nombre de Clase"
    Public ReadOnly Property Nombre_Clase() As String
        Get
            Return "Class_Contabilidad_Global_Polizas"
        End Get
    End Property
#End Region

#End Region

#Region "Constructor y destructor"
    Public Sub New()
        Me._Nombre_Catalogo = "CON_POLIZAS_GLOBAL"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion

        Me._QuerySelect = "SELECT G.*,U1.NOMBRE_USUARIO NOMBRE_USUARIO_GRABO,U2.NOMBRE_USUARIO NOMBRE_USUARIO_CANCELO,U3.NOMBRE_USUARIO NOMBRE_USUARIO_REACTIVO,E.ESTATUS ESTATUS " & _
                            "FROM CON_POLIZAS_GLOBAL G " & _
                            "INNER JOIN CON_POLIZA_CAT_ESTATUS E ON(G.ESTATUS_POLIZA=E.CODIGO_ESTATUS) " & _
                            "INNER JOIN SIS_USUARIOS U1 ON(G.CODIGO_USUARIO_GRABO=U1.CODIGO_USUARIO) " & _
                            "LEFT JOIN SIS_USUARIOS U2 ON(G.CODIGO_USUARIO_CANCELO=U2.CODIGO_USUARIO) " & _
                            "LEFT JOIN SIS_USUARIOS U3 ON(G.CODIGO_USUARIO_REACTIVO=U3.CODIGO_USUARIO) "
        Me.oPolizaDetalle = New Class_Contabilidad_Poliza_Detalle
    End Sub

    Public Sub New(ByVal folioPoliza As String)
        Me.New()
        Me._FOLIO_POLIZA = folioPoliza
        'Me.oPolizaDetalle = New Class_Contabilidad_Detalle_Poliza
        Try
            If Me.Consultar = True Then
                Me._Existe = True
                'Else
                '   Throw New Exception("La cuenta bancaria no existe.")
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "New", ex)
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
        Dim cmd As New SqlCommand(Me._QuerySelect & " WHERE G.FOLIO_POLIZA='" & Me._FOLIO_POLIZA & "' ", Me._Conexion)
        Dim dReader As SqlDataReader
        'Dim sqlParametro As SqlParameter
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()

                dReader = .ExecuteReader()
                If dReader.Read Then

                    Me._FOLIO_POLIZA = CType(dReader("FOLIO_POLIZA"), String)
                    Me._CODIGO_PLAZA = CType(dReader("CODIGO_PLAZA"), Integer)
                    Me._CODIGO_USUARIO_GRABO = CType(dReader("CODIGO_USUARIO_GRABO"), Integer)
                    Me._NOMBRE_USUARIO_GRABO = CType(dReader("NOMBRE_USUARIO_GRABO"), String)
                    Me._CODIGO_TIPO_DOCUMENTO = Trim("" & dReader("CODIGO_TIPO_DOCUMENTO").ToString)
                    Me._FECHA = CDate(dReader("FECHA"))
                    Me._FECHA_SERVIDOR = CDate(dReader("FECHA_SERVIDOR"))
                    Me._CONCEPTO1 = Trim("" & dReader("CONCEPTO1").ToString)
                    Me._CONCEPTO2 = Trim("" & dReader("CONCEPTO2").ToString)
                    Me._TIPO_CONTABILIDAD = Trim("" & dReader("TIPO_CONTABILIDAD").ToString)

                    Me._CARGO = valorNumerico(dReader("CARGO").ToString)
                    Me._ABONO = valorNumerico(dReader("ABONO").ToString)
                    Me._FOLIO_ORIGEN = Trim("" & dReader("FOLIO_ORIGEN").ToString)
                    Me._ESTATUS_POLIZA = CType(dReader("ESTATUS_POLIZA"), String)
                    Me._ESTATUS = CType(dReader("ESTATUS"), String)

                    Select Case Me._ESTATUS_POLIZA
                        Case "G"
                            If ("" & dReader("FECHA_REACTIVACION_SERVIDOR").ToString).ToString.Length > 0 Then
                                Me._CODIGO_USUARIO_REACTIVO = CType(dReader("CODIGO_USUARIO_REACTIVO"), Integer)
                                Me._NOMBRE_USUARIO_REACTIVO = CType(dReader("NOMBRE_USUARIO_REACTIVO"), String)
                                Me._FECHA_REACTIVACION_SERVIDOR = CDate(dReader("FECHA_REACTIVACION_SERVIDOR"))
                            End If
                        Case "C"
                            Me._CODIGO_USUARIO_CANCELO = CType(dReader("CODIGO_USUARIO_CANCELO"), Integer)
                            Me._NOMBRE_USUARIO_CANCELO = CType(dReader("NOMBRE_USUARIO_CANCELO"), String)
                            Me._FECHA_CANCELACION = CDate(dReader("FECHA_CANCELACION"))
                            Me._FECHA_CANCELACION_SERVIDOR = CDate(dReader("FECHA_CANCELACION_SERVIDOR"))
                    End Select

                    If Me._CODIGO_TIPO_DOCUMENTO = "E" Then
                        Me._CODIGO_LISTA_FACTURAS_RECIBIDAS = Trim("" & dReader("CODIGO_LISTA_FACTURAS_RECIBIDAS").ToString)
                    End If
                    Me._FOLIO_CONTRAPOLIZA = Trim("" & dReader("FOLIO_CONTRAPOLIZA").ToString)
                    bResultado = True
                End If
                dReader.Close()
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "Consultar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
            End Try
        End With

        Return bResultado
    End Function

    Public Function Insertar(Optional ByVal bRegenera As Boolean = True) As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CONTABILIDAD_GRABA_GLOBAL"

            sqlParametro = .Parameters.Add("@CODIGO_PLAZA", SqlDbType.Int) : sqlParametro.Value = Me._CODIGO_PLAZA
            sqlParametro = .Parameters.Add("@FOLIO_POLIZA", SqlDbType.NVarChar, 15) : sqlParametro.Direction = ParameterDirection.InputOutput : sqlParametro.Value = Me._FOLIO_POLIZA
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO_GRABO", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_USUARIO_GRABO
            sqlParametro = .Parameters.Add("@CODIGO_TIPO_DOCUMENTO", SqlDbType.NVarChar, 5) : sqlParametro.Value = Me._CODIGO_TIPO_DOCUMENTO
            sqlParametro = .Parameters.Add("@FECHA", SqlDbType.DateTime) : sqlParametro.Value = Me._FECHA
            sqlParametro = .Parameters.Add("@CONCEPTO1", SqlDbType.NVarChar, 80) : sqlParametro.Value = Me._CONCEPTO1
            sqlParametro = .Parameters.Add("@CONCEPTO2", SqlDbType.NVarChar, 80) : sqlParametro.Value = Me._CONCEPTO2
            sqlParametro = .Parameters.Add("@CARGO", SqlDbType.Money) : sqlParametro.Value = Me._CARGO
            sqlParametro = .Parameters.Add("@ABONO", SqlDbType.Money) : sqlParametro.Value = Me._ABONO
            sqlParametro = .Parameters.Add("@FOLIO_ORIGEN", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_ORIGEN
            sqlParametro = .Parameters.Add("@TIPO_CONTABILIDAD", SqlDbType.NVarChar, 2) : sqlParametro.Value = Me._TIPO_CONTABILIDAD
            sqlParametro = .Parameters.Add("@ACCION", SqlDbType.NVarChar, 15) : sqlParametro.Value = "INSERTAR"
            sqlParametro = .Parameters.Add("@REGENERA_FOLIO", SqlDbType.NVarChar, 1) : sqlParametro.Value = Convert.ToInt32(bRegenera)

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                Me._FOLIO_POLIZA = "" & .Parameters("@FOLIO_POLIZA").Value.ToString
                bResultado = True
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "Insertar", ex)
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
            .CommandText = "MP_CONTABILIDAD_GRABA_GLOBAL"

            sqlParametro = .Parameters.Add("@FOLIO_POLIZA", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_POLIZA

            sqlParametro = .Parameters.Add("@CODIGO_PLAZA", SqlDbType.Int) : sqlParametro.Value = Me._CODIGO_PLAZA
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO_GRABO", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_USUARIO_GRABO
            sqlParametro = .Parameters.Add("@CODIGO_TIPO_DOCUMENTO", SqlDbType.NVarChar, 5) : sqlParametro.Value = Me._CODIGO_TIPO_DOCUMENTO
            sqlParametro = .Parameters.Add("@FECHA", SqlDbType.DateTime) : sqlParametro.Value = Me._FECHA
            sqlParametro = .Parameters.Add("@CONCEPTO1", SqlDbType.NVarChar, 80) : sqlParametro.Value = Me._CONCEPTO1
            sqlParametro = .Parameters.Add("@CONCEPTO2", SqlDbType.NVarChar, 80) : sqlParametro.Value = Me._CONCEPTO2
            sqlParametro = .Parameters.Add("@CARGO", SqlDbType.Money) : sqlParametro.Value = Me._CARGO
            sqlParametro = .Parameters.Add("@ABONO", SqlDbType.Money) : sqlParametro.Value = Me._ABONO
            sqlParametro = .Parameters.Add("@FOLIO_ORIGEN", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_ORIGEN
            sqlParametro = .Parameters.Add("@TIPO_CONTABILIDAD", SqlDbType.NVarChar, 2) : sqlParametro.Value = Me._TIPO_CONTABILIDAD
            sqlParametro = .Parameters.Add("@ACCION", SqlDbType.NVarChar, 15) : sqlParametro.Value = "ACTUALIZAR"
            sqlParametro = .Parameters.Add("@REGENERA_FOLIO", SqlDbType.NVarChar, 1) : sqlParametro.Value = "0"

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                Me._FOLIO_POLIZA = "" & .Parameters("@FOLIO_POLIZA").Value.ToString
                bResultado = True
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "Actualizar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With

        Return bResultado
    End Function

    Public Function Aplicar() As Boolean
        Dim bResultado As Boolean = False
        Dim Conexion As New SqlConnection
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        Conexion.ConnectionString = Empresa_Sistema.conexion

        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CONTABILIDAD_APLICA_POLIZA"

            sqlParametro = .Parameters.Add("@FOLIO_POLIZA", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_POLIZA
            sqlParametro = .Parameters.Add("@APLICAR", SqlDbType.Char, 1) : sqlParametro.Value = "1"

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "Aplicar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With

        Return bResultado
    End Function

    Public Function Desaplicar() As Boolean
        Dim bResultado As Boolean = False
        Dim Conexion As New SqlConnection
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        Conexion.ConnectionString = Empresa_Sistema.conexion
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CONTABILIDAD_APLICA_POLIZA"

            sqlParametro = .Parameters.Add("@FOLIO_POLIZA", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_POLIZA
            sqlParametro = .Parameters.Add("@APLICAR", SqlDbType.Char, 1) : sqlParametro.Value = "0"

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "Desaplicar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With

        Return bResultado
    End Function

    Public Function Cancelar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CONTABILIDAD_CANCELA_POLIZA"

            sqlParametro = .Parameters.Add("@FOLIO_POLIZA", SqlDbType.NVarChar, 15) : sqlParametro.Value = "" & Me._FOLIO_POLIZA
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Usuario
            sqlParametro = .Parameters.Add("@FECHA_CANCELACION", SqlDbType.DateTime) : sqlParametro.Value = Me._FECHA

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "Cancelar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With

        Return bResultado
    End Function

    Public Function GestionaCancelar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CONTABILIDAD_GESTIONA_CANCELACION_DE_POLIZA"

            sqlParametro = .Parameters.Add("@FOLIO_POLIZA", SqlDbType.NVarChar, 15) : sqlParametro.Value = "" & Me._FOLIO_POLIZA
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO_CANCELO", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Usuario
            sqlParametro = .Parameters.Add("@FECHA_CANCELACION", SqlDbType.DateTime) : sqlParametro.Value = Me._FECHA

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "GestionaCancelar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With

        Return bResultado
    End Function

    Public Function Reactiva() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CONTABILIDAD_REACTIVA_POLIZA"

            sqlParametro = .Parameters.Add("@FOLIO_POLIZA", SqlDbType.NVarChar, 15) : sqlParametro.Value = "" & Me._FOLIO_POLIZA
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO", SqlDbType.SmallInt) : sqlParametro.Value = Me.CODIGO_USUARIO_GRABO

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "Reactiva", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With

        Return bResultado
    End Function

    Public Function GeneraNuevoFolioPoliza() As String
        Dim sResultado As String = ""
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CONTABILIDAD_GENERA_FOLIO_POLIZA"

            sqlParametro = .Parameters.Add("@FOLIO_POLIZA", SqlDbType.NVarChar, 15) : sqlParametro.Direction = ParameterDirection.Output
            sqlParametro = .Parameters.Add("@CODIGO_TIPO_DOCUMENTO", SqlDbType.NVarChar, 10) : sqlParametro.Value = Me._CODIGO_TIPO_DOCUMENTO
            sqlParametro = .Parameters.Add("@FECHA", SqlDbType.DateTime) : sqlParametro.Value = Me._FECHA

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                Me._FOLIO_POLIZA = "" & .Parameters("@FOLIO_POLIZA").Value.ToString
                sResultado = "" & .Parameters("@FOLIO_POLIZA").Value.ToString
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "GeneraNuevoFolioPoliza", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With

        Return sResultado
    End Function

    Public Function ObtenerDetalle() As DataTable
        Dim dTabla As New DataTable("detalle"), da As SqlDataAdapter
        Dim sSQL As String
        ',R.CODIGO_CENTRO_COSTO,CC.NOMBRE_CENTRO_COSTO " & _
        sSQL = "SELECT C.CUENTA_CONTABLE,DBO.FN_CONTABILIDAD_NOMBRE_CUENTA_NIVELES_COMPLETOS(C.CUENTA_CONTABLE) NOMBRE_CUENTA,R.CONCEPTO,C.NATURALEZA_CONTABLE,R.CARGO,R.ABONO " & _
               "FROM CON_POLIZAS_DETALLE R " & _
               "INNER JOIN CON_CAT_CUENTAS C ON(R.CUENTA_CONTABLE=C.CUENTA_CONTABLE) " & _
               "LEFT JOIN NOMINA_CAT_CENTROS_COSTOS CC ON(R.CODIGO_CENTRO_COSTO=CC.CODIGO_CENTRO_COSTO) " & _
               "WHERE R.FOLIO_POLIZA='" & Me._FOLIO_POLIZA & "' " & _
               "ORDER BY R.ID_CON_POLIZAS_DETALLE"
        Try
            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dTabla)
            da.Dispose()
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "ObtenerDetalle", ex)
        End Try
        Return dTabla
    End Function

    Public Sub InicializaDetalle()
        Me.oPolizaDetalle = New Class_Contabilidad_Poliza_Detalle
    End Sub

    Public Function ConsiderarParaControlIVAAcreditable() As Boolean
        Dim bResultado As Boolean = False
        Dim dTabla As New DataTable("detalle"), da As SqlDataAdapter
        Dim sSQL As String = "EXEC DBO.MP_CONTABILIDAD_IVA_ACREDITABLE_OBTIENE_TOTALES_IVA_ACREDITABLE_POLIZA @FOLIO_POLIZA='" & Me._FOLIO_POLIZA & "'"
        Try
            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dTabla)
            da.Dispose()

            '1-Busca si la póliza tiene alguna cuenta de iva acreditable.
            If dTabla.Rows.Count > 0 Then
                If CDbl(dTabla.Rows(0)("IVA_10")) > 0 Or CDbl(dTabla.Rows(0)("IVA_15")) > 0 Or _
                   CDbl(dTabla.Rows(0)("IVA_11")) > 0 Or CDbl(dTabla.Rows(0)("IVA_16")) > 0 Then
                    bResultado = True
                End If
            End If

            dTabla.Dispose()

            '2-Si no, entonces busca si es una póliza de egresos que afectó a bancos, tenga o no cuentas de iva. Para grabar actos al cero de polizas de egresos directas.
            If bResultado = False Then
                Dim sql As New Class_find("SELECT DBO.FN_CONTABILIDAD_SI_ES_POLIZA_EGRESO_AFECTA_BANCOS('" & Me._FOLIO_POLIZA & "')")
                If sql.Result1 = "1" Then
                    bResultado = True
                End If
                sql = Nothing
            End If

        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "ConsiderarParaControlIVAAcreditable", ex)
        End Try

        Return bResultado
    End Function

    Public Function AsignaFacturasPoliza() As Boolean
        Dim bResultado As Boolean = False
        Dim Conexion As New SqlConnection
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        Conexion.ConnectionString = Empresa_Sistema.conexion

        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CONTABILIDAD_GRABA_FACTURAS_RECIBIDAS"

            sqlParametro = .Parameters.Add("@FOLIO_POLIZA", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_POLIZA
            sqlParametro = .Parameters.Add("@CODIGO_LISTA_FACTURAS_RECIBIDAS", SqlDbType.NVarChar, 2) : sqlParametro.Value = Me._CODIGO_LISTA_FACTURAS_RECIBIDAS

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "AsignaFacturasPoliza", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With

        Return bResultado
    End Function

    Public Function ObtenerDetalleCostos() As DataTable
        Dim dTabla As New DataTable("detalle"), da As SqlDataAdapter
        Dim sSQL As String

        sSQL = "SELECT R.CODIGO_CENTRO_COSTO,CC.NOMBRE_CENTRO_COSTO,R.CODIGO_CATEGORIA,CA.NOMBRE_CATEGORIA,R.CODIGO_CONCEPTO,CO.NOMBRE_CONCEPTO,R.IMPORTE,R.CUENTA_CONTABLE " & _
                "FROM CENTRO_COSTOS_MOVIMIENTOS_DETALLE R " & _
                "INNER JOIN NOMINA_CAT_CENTROS_COSTOS CC ON(R.CODIGO_CENTRO_COSTO=CC.CODIGO_CENTRO_COSTO) " & _
                "INNER JOIN CAT_CATEGORIAS CA ON(R.CODIGO_CATEGORIA=CA.CODIGO_CATEGORIA) " & _
                "INNER JOIN CAT_CONCEPTOS CO ON(R.CODIGO_CONCEPTO=CO.CODIGO_CONCEPTO) " & _
                "WHERE R.FOLIO_MOVIMIENTO = '" & Me._FOLIO_POLIZA & "' " & _
                "ORDER BY R.ID_CENTRO_COSTOS_MOVIMIENTOS_DETALLE "
        Try
            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dTabla)
            da.Dispose()
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "ObtenerDetalleCostos", ex)
        End Try
        Return dTabla
    End Function

    Public Function ObtenerDetalleGastosActivos() As DataTable
        Dim dTabla As New DataTable("detalle"), da As SqlDataAdapter
        Dim sSQL As String

        sSQL = "SELECT R.CUENTA_CONTABLE,DBO.FN_CONTABILIDAD_NOMBRE_CUENTA_NIVELES_COMPLETOS(R.CUENTA_CONTABLE) NOMBRE_CUENTA_NIVELES_COMPLETOS,R.IMPORTE " & _
                "FROM GASTOS_DETALLE R " & _
                "LEFT JOIN CON_CAT_CUENTAS C ON(R.CUENTA_CONTABLE=C.CUENTA_CONTABLE) " & _
                "WHERE R.FOLIO_MOVIMIENTO = '" & Me._FOLIO_POLIZA & "' " & _
                "ORDER BY R.ID_GASTOS_DETALLE "
        Try
            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dTabla)
            da.Dispose()
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "ObtenerDetalleGastosActivos", ex)
        End Try
        Return dTabla
    End Function

    Public Function GrabarPolizaCosto(ByVal sListaActivos As String, ByVal sListaCostos As String, ByVal sAccion As String) As Boolean
        Dim bResultado As Boolean = False
        Try
            Dim cmd As New SqlCommand
            Dim sqlParametro As SqlParameter
            With cmd
                .Connection = Me._Conexion
                .CommandTimeout = 0
                .CommandType = CommandType.StoredProcedure
                .CommandText = "MP_CONTABILIDAD_POLIZA_COSTO_GRABA"

                sqlParametro = .Parameters.Add("@FOLIO_POLIZA", SqlDbType.NVarChar, 15) : sqlParametro.Direction = ParameterDirection.InputOutput : sqlParametro.Value = Me._FOLIO_POLIZA
                sqlParametro = .Parameters.Add("@FECHA", SqlDbType.DateTime) : sqlParametro.Value = Me._FECHA
                sqlParametro = .Parameters.Add("@CODIGO_PLAZA", SqlDbType.Int) : sqlParametro.Value = Me._CODIGO_PLAZA
                sqlParametro = .Parameters.Add("@CODIGO_TIPO_DOCUMENTO", SqlDbType.NVarChar, 5) : sqlParametro.Value = Me._CODIGO_TIPO_DOCUMENTO
                sqlParametro = .Parameters.Add("@CODIGO_USUARIO_GRABO", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Usuario
                sqlParametro = .Parameters.Add("@CONCEPTO", SqlDbType.NVarChar, 80) : sqlParametro.Value = Me._CONCEPTO1
                sqlParametro = .Parameters.Add("@LISTA_ACTIVOS", SqlDbType.NVarChar, -1) : sqlParametro.Value = sListaActivos
                sqlParametro = .Parameters.Add("@LISTA_COSTOS", SqlDbType.NVarChar, -1) : sqlParametro.Value = sListaCostos
                sqlParametro = .Parameters.Add("@ACCION", SqlDbType.NVarChar, 15) : sqlParametro.Value = sAccion

                Try
                    Me._Conexion.Open()
                    .ExecuteNonQuery()
                    Me._FOLIO_POLIZA = "" & .Parameters("@FOLIO_POLIZA").Value.ToString
                    bResultado = True
                Catch ex As Exception
                    HandleError(Me.Nombre_Clase, "GrabarPolizaCosto", ex)
                Finally
                    Me._Conexion.Close()
                    cmd.Dispose()
                    sqlParametro = Nothing
                End Try
            End With
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "GrabarPolizaCosto", ex)
        End Try

        Return bResultado
    End Function

    Public Function CancelarPolizaCosto() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CONTABILIDAD_POLIZA_COSTO_CANCELA"

            sqlParametro = .Parameters.Add("@FOLIO_POLIZA", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_POLIZA
            sqlParametro = .Parameters.Add("@CODIGO_PLAZA", SqlDbType.Int) : sqlParametro.Value = Me._CODIGO_PLAZA
            sqlParametro = .Parameters.Add("@CODIGO_TIPO_DOCUMENTO", SqlDbType.NVarChar, 5) : sqlParametro.Value = Me._CODIGO_TIPO_DOCUMENTO
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO_CANCELO", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Usuario
            sqlParametro = .Parameters.Add("@FECHA_CANCELACION", SqlDbType.DateTime) : sqlParametro.Value = Me._FECHA

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "CancelarPolizaCosto", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With

        Return bResultado
    End Function

    Public Function BuscarXML(Optional ByVal sRFC_Proveedor As String = "", Optional bValidarTipoComprobanteIngreso As Boolean = False) As String
        Dim sResultado As String = ""
        Dim sProcedure As String = "BuscarXML"
        Dim Dialog As New OpenFileDialog
        Dim sRutaXML As String = "", sNombreArchivoXML As String = ""

        Try
            With Dialog
                .Filter = "XML files (*.XML)|*.XML"
                .RestoreDirectory = True
                .FileName = ""
                .Multiselect = False
                .DefaultExt = ".XML"

                If .ShowDialog() = DialogResult.OK Then
                    sRutaXML = .FileName
                End If
            End With

            If txtLEN(sRutaXML) = False Then
                Return ""
            End If

            sNombreArchivoXML = Path.GetFileName(sRutaXML)

            sNombreArchivoXML = sNombreArchivoXML.Substring(0, sNombreArchivoXML.Length() - 4) 'Le quita la extensión .xml al nombre del archivo, no se usa Path.GetFileNameWithoutExtension porque no funciona debidamente cuando trae puntos extras.

            If (sNombreArchivoXML.IndexOf(".") > 0 Or sNombreArchivoXML.IndexOf(",") > 0) Then 'Si el nombre de archivo(ya sin extensión) tiene algún punto/coma debemos quitarlo.
                sNombreArchivoXML = sNombreArchivoXML.Replace(".", "")
                sNombreArchivoXML = sNombreArchivoXML.Replace(",", "")
                sNombreArchivoXML = sNombreArchivoXML + ".xml"

                My.Computer.FileSystem.RenameFile(sRutaXML, sNombreArchivoXML) 'Renombramos físicamente al archivo para que ya no tenga esos caracteres extras.

                sRutaXML = Path.Combine(Path.GetDirectoryName(sRutaXML), sNombreArchivoXML) 'Regenera la ruta luego de remover y renombrar el archivo quitándole los caracteres extras.
            End If

            Dim oCFDI As New CFDIXML.ClassCFDI(sRutaXML, True) 'Internamente: ya se valida que este timbrado

            If oCFDI.XMLCargado = False Then
                Return ""
            End If

            If oCFDI.Receptor.rfc <> Empresa_Sistema.RFC Then
                MsgBox("En el XML el RFC del receptor es " & vbCrLf &
                        oCFDI.Receptor.rfc & " y el de esta empresa es " & vbCrLf &
                        Empresa_Sistema.RFC & vbCrLf &
                        "No es posible agregar este XML.", MsgBoxStyle.Exclamation, sProcedure)
                Return ""
            End If

            If txtLEN(sRFC_Proveedor) = True Then
                If oCFDI.Emisor.rfc <> sRFC_Proveedor Then
                    If MsgBox("En el XML el RFC del emisor es " & vbCrLf &
                               oCFDI.Emisor.rfc & IIf(oCFDI.Emisor.nombre.Length > 0, "  " & oCFDI.Emisor.nombre, "").ToString & vbCrLf &
                               "y el del proveedor en el sistema es " & vbCrLf &
                               sRFC_Proveedor & vbCrLf &
                               "Esta seguro de querer relacionarlo de todas formas ?", vbQuestion Or MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.No Then
                        Return ""
                    End If
                End If
            End If

            If bValidarTipoComprobanteIngreso = True Then
                If oCFDI.Comprobante.TipoDeComprobante <> "I" Then
                    MsgBox("Esta agregando un xml con el tipo comprobante " & oCFDI.Comprobante.TipoDeComprobante & " ." & vbCrLf &
                           "Sólo se permite tipo I=Ingreso, si quiere agregar de otro tipo abra la póliza y desde ahí lo agrega.", vbExclamation, sProcedure)
                    Return ""
                End If
            End If

            sResultado = sRutaXML

            oCFDI = Nothing

        Catch ex As Exception
            HandleError(Me.Nombre_Clase, sProcedure, ex)
        Finally
            Dialog.Dispose()
        End Try

        Return sResultado
    End Function

    Public Function BuscarPDF() As String
        Dim sResultado As String = ""
        Dim sProcedure As String = "BuscarPDF"
        Dim Dialog As New OpenFileDialog
        Dim sRutaPDF As String = "", sNombreArchivoPDF As String = ""

        Try
            With Dialog
                .Filter = "PDF files (*.PDF)|*.PDF"
                .RestoreDirectory = True
                .FileName = ""
                .Multiselect = False
                .DefaultExt = ".PDF"

                If .ShowDialog() = DialogResult.OK Then
                    sRutaPDF = .FileName
                End If
            End With

            If txtLEN(sRutaPDF) = False Then
                Return ""
            End If

            sNombreArchivoPDF = Path.GetFileName(sRutaPDF)

            sNombreArchivoPDF = sNombreArchivoPDF.Substring(0, sNombreArchivoPDF.Length() - 4) 'Le quita la extensión .pdf al nombre del archivo, no se usa Path.GetFileNameWithoutExtension porque no funciona debidamente cuando trae puntos extras.

            If (sNombreArchivoPDF.IndexOf(".") > 0 Or sNombreArchivoPDF.IndexOf(",") > 0) Then 'Si el nombre de archivo(ya sin extensión) tiene algún punto/coma debemos quitarlo.
                sNombreArchivoPDF = sNombreArchivoPDF.Replace(".", "")
                sNombreArchivoPDF = sNombreArchivoPDF.Replace(",", "")
                sNombreArchivoPDF = sNombreArchivoPDF + ".pdf"

                My.Computer.FileSystem.RenameFile(sRutaPDF, sNombreArchivoPDF) 'Renombramos físicamente al archivo para que ya no tenga esos caracteres extras.

                sRutaPDF = Path.Combine(Path.GetDirectoryName(sRutaPDF), sNombreArchivoPDF) 'Regenera la ruta luego de remover y renombrar el archivo quitándole los caracteres extras.
            End If

            sResultado = sRutaPDF

        Catch ex As Exception
            HandleError(Me.Nombre_Clase, sProcedure, ex)
        Finally
            Dialog.Dispose()
        End Try

        Return sResultado
    End Function

    Public Function AgregarXMLPDF(ByVal sRutaXML As String, ByVal sRutaPDF As String) As Boolean
        Dim bResultado As Boolean = False
        Dim sProcedure As String = "AgregarXML"
        Dim ArchivoPDF As Byte() = Nothing, sNombrePDF As String = ""

        Try
            If txtLEN(sRutaPDF) = True Then
                ArchivoPDF = ArchivoToByte(sRutaPDF)
                sNombrePDF = Path.GetFileName(sRutaPDF)
            End If

            Dim oCFDI As New CFDIXML.ClassCFDI(sRutaXML, True) 'Internamente: ya se valida que este timbrado

            If oCFDI.XMLCargado = False Then
                Return False
            End If

            Dim cmd As New SqlCommand
            Dim sqlParametro As SqlParameter
            With cmd
                .Connection = Me._Conexion
                .CommandTimeout = 0
                .CommandType = CommandType.StoredProcedure
                .CommandText = "MP_CONTABILIDAD_SUBIR_XML_PDF"

                sqlParametro = .Parameters.Add("@FOLIO_POLIZA", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_POLIZA
                sqlParametro = .Parameters.Add("@CADENA_XML", SqlDbType.Xml) : sqlParametro.Value = oCFDI.XMLSinDeclaracion
                sqlParametro = .Parameters.Add("@PDF_ARCHIVO", SqlDbType.Image) : sqlParametro.Value = IIf(txtLEN(sRutaPDF) = True, ArchivoPDF, DBNull.Value)
                sqlParametro = .Parameters.Add("@PDF_NOMBRE", SqlDbType.NVarChar, 100) : sqlParametro.Value = sNombrePDF

                Try
                    Me._Conexion.Open()
                    .ExecuteNonQuery()
                    bResultado = True
                Catch ex As Exception
                    HandleError(Me.Nombre_Clase, sProcedure, ex)
                Finally
                    Me._Conexion.Close()
                    cmd.Dispose()
                    sqlParametro = Nothing
                End Try
            End With

            oCFDI = Nothing

        Catch ex As Exception
            HandleError(Me.Nombre_Clase, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    Public Function AgregarPDF(ByVal sUUID As String, ByVal sRutaPDF As String) As Boolean
        Dim bResultado As Boolean = False
        Dim sProcedure As String = "AgregarPDF"
        Dim ArchivoPDF As Byte() = Nothing, sNombrePDF As String = ""

        Try
            If txtLEN(sRutaPDF) = False Then
                MsgBox("No indicó la ruta del archivo PDF.", vbExclamation, sProcedure)
                Return False
            End If

            ArchivoPDF = ArchivoToByte(sRutaPDF)
            sNombrePDF = Path.GetFileName(sRutaPDF)

            Dim cmd As New SqlCommand
            Dim sqlParametro As SqlParameter
            With cmd
                .Connection = Me._Conexion
                .CommandTimeout = 0
                .CommandType = CommandType.StoredProcedure
                .CommandText = "MP_CONTABILIDAD_SUBIR_PDF"

                sqlParametro = .Parameters.Add("@UUID", SqlDbType.NVarChar, 36) : sqlParametro.Value = sUUID
                sqlParametro = .Parameters.Add("@PDF_ARCHIVO", SqlDbType.Image) : sqlParametro.Value = ArchivoPDF ' DBNull.Value    
                sqlParametro = .Parameters.Add("@PDF_NOMBRE", SqlDbType.NVarChar, 100) : sqlParametro.Value = sNombrePDF

                Try
                    Me._Conexion.Open()
                    .ExecuteNonQuery()
                    bResultado = True
                Catch ex As Exception
                    HandleError(Me.Nombre_Clase, sProcedure, ex)
                Finally
                    Me._Conexion.Close()
                    cmd.Dispose()
                    sqlParametro = Nothing
                End Try
            End With

        Catch ex As Exception
            HandleError(Me.Nombre_Clase, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    Public Function AbrirXML(ByVal sUUID As String) As Boolean
        Const sProcedure As String = "AbrirXML"
        Dim bResultado As Boolean = False

        Try
            Dim sRutaXML As String = Path.Combine(Path.GetTempPath, sUUID & ".xml")
            Dim docXml As Xml.XmlDocument = New Xml.XmlDocument
            Dim sCadenaXML As String = New Class_find("SELECT CADENA_XML FROM EXPEDIENTES_BS..XML_REPOSITORIO_GLOBAL WHERE UUID='" & sReplace(sUUID) & "'").Result1

            If txtLEN(sCadenaXML) = False Then
                MsgBox("No se encontró la cadena del XML del UUID.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            'Agrega al documento XML la cadena que ya esta grabada
            docXml.LoadXml(sCadenaXML)
            'Crea el nodo principal o primera linea <?xml version="1.0"?>
            Dim Nodo As Xml.XmlDeclaration
            Nodo = docXml.CreateXmlDeclaration("1.0", "utf-8", Nothing)
            'Agrega el nodo al documento
            Dim root As Xml.XmlElement = docXml.DocumentElement
            docXml.InsertBefore(Nodo, root)

            docXml.Save(sRutaXML)
            ConvierteXMLUTF8(sRutaXML)

            Process.Start(sRutaXML) 'Para abrir el xml

            bResultado = True

        Catch ex As Exception
            HandleError(Me.Nombre_Clase, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    Public Function AbrirPDF(ByVal sUUID As String) As Boolean
        Const sProcedure As String = "AbrirPDF"
        Dim bResultado As Boolean = False

        Dim Archivo As New Class_Archivo()
        Dim cn As New SqlConnection(Empresa_Sistema.conexion)
        Dim cmd As New SqlCommand()
        Try
            cn.Open()

            cmd.Connection = cn
            cmd.CommandText = "SELECT PDF_ARCHIVO,PDF_NOMBRE FROM EXPEDIENTES_BS..XML_REPOSITORIO_GLOBAL " +
                                     "WHERE UUID='" & sReplace(sUUID) & "'"

            Dim dReader As SqlDataReader = cmd.ExecuteReader
            Dim obj As New Object, sFileName As String = ""

            If dReader.Read = True Then
                Archivo.NombreArchivo = "" & dReader("PDF_NOMBRE").ToString

                If txtLEN(Archivo.NombreArchivo) = True Then 'Si no tiene nombre de archivopdf es porque no se le ha grabado un pdf.
                    Archivo.Archivo = CType(dReader("PDF_ARCHIVO"), Byte())

                    AbrirArchivo(Archivo)

                    bResultado = True
                Else
                    MsgBox("Este xml no tiene archivo PDF.", vbExclamation, sProcedure)
                End If

            End If
            dReader.Close()

        Catch ex As Exception
            HandleError(Me.Nombre_Clase, sProcedure, ex)
        Finally
            cn.Close()
            cn.Dispose()
            cmd.Dispose()
        End Try

        Return bResultado
    End Function

    Public Function TienePDF(ByVal sUUID As String) As Boolean
        Const sProcedure As String = "TienePDF"
        Dim bResultado As Boolean = False

        Try
            If txtLEN(New Class_find("SELECT 1 FROM EXPEDIENTES_BS..XML_REPOSITORIO_GLOBAL WHERE UUID='" & sReplace(sUUID) & "' AND PDF_ARCHIVO IS NOT NULL").Result1) = True Then
                bResultado = True
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    Public Function ObtienePDFNombre(ByVal sUUID As String) As String
        Const sProcedure As String = "ObtienePDFNombre"
        Dim sResultado As String = ""

        Try
            sResultado = New Class_find("SELECT PDF_NOMBRE FROM EXPEDIENTES_BS..XML_REPOSITORIO_GLOBAL WHERE UUID='" & sReplace(sUUID) & "' AND PDF_ARCHIVO IS NOT NULL").Result1
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, sProcedure, ex)
        End Try

        Return sResultado
    End Function

    Public Function ObtieneXMLs() As DataTable
        Dim sProcedure As String = "ObtieneXMLs"
        Dim dTabla As New DataTable("detalle"), da As SqlDataAdapter
        Dim sSQL As String
        'sSQL = "SELECT R.UUID,X.CADENA_XML,X.PDF_NOMBRE " &
        sSQL = "SELECT X.* " &
               "FROM CONTABILIDAD_POLIZA_RELACION_XML R " &
               "INNER JOIN EXPEDIENTES_BS..XML_REPOSITORIO_GLOBAL X ON(R.UUID=X.UUID) " &
               "WHERE R.FOLIO_POLIZA='" & Me._FOLIO_POLIZA & "' " &
               "ORDER BY R.ID_POLIZA_RELACION_XML"
        Try
            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dTabla)
            da.Dispose()
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, sProcedure, ex)
        End Try
        Return dTabla
    End Function

    Public Function EliminarRelacionTodosXMLs() As Boolean
        Dim bResultado As Boolean = False
        Dim sProcedure As String = "EliminarRelacionTodosXMLs"

        Try
            Dim cmd As New SqlCommand
            Dim sqlParametro As SqlParameter
            With cmd
                .Connection = Me._Conexion
                .CommandTimeout = 0
                .CommandType = CommandType.StoredProcedure
                .CommandText = "MP_CONTABILIDAD_ELIMINA_RELACION_TODOS_XMLS"

                sqlParametro = .Parameters.Add("@FOLIO_POLIZA", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_POLIZA

                Try
                    Me._Conexion.Open()
                    .ExecuteNonQuery()
                    bResultado = True
                Catch ex As Exception
                    HandleError(Me.Nombre_Clase, sProcedure, ex)
                Finally
                    Me._Conexion.Close()
                    cmd.Dispose()
                    sqlParametro = Nothing
                End Try
            End With

        Catch ex As Exception
            HandleError(Me.Nombre_Clase, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    Public Function EliminarRelacionUnXML(ByVal sUUID As String) As Boolean 'Realmente no se borran los xml's porque pueden estarse usando en otros documentos.
        Dim bResultado As Boolean = False
        Dim sProcedure As String = "EliminarRelacionUnXML"

        Try
            Dim cmd As New SqlCommand
            Dim sqlParametro As SqlParameter
            With cmd
                .Connection = Me._Conexion
                .CommandTimeout = 0
                .CommandType = CommandType.StoredProcedure
                .CommandText = "MP_CONTABILIDAD_ELIMINA_RELACION_UN_XML"

                sqlParametro = .Parameters.Add("@FOLIO_POLIZA", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_POLIZA
                sqlParametro = .Parameters.Add("@UUID", SqlDbType.NVarChar, 36) : sqlParametro.Value = sUUID

                Try
                    Me._Conexion.Open()
                    .ExecuteNonQuery()
                    bResultado = True
                Catch ex As Exception
                    HandleError(Me.Nombre_Clase, sProcedure, ex)
                Finally
                    Me._Conexion.Close()
                    cmd.Dispose()
                    sqlParametro = Nothing
                End Try
            End With

        Catch ex As Exception
            HandleError(Me.Nombre_Clase, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    Public Function TieneRelacionadoUUID(ByVal sUUID As String) As Boolean
        Const sProcedure As String = "TieneRelacionadoUUID"
        Dim bResultado As Boolean = False

        Try
            If txtLEN(New Class_find("SELECT 1 FROM CONTABILIDAD_POLIZA_RELACION_XML WHERE FOLIO_POLIZA='" & Me._FOLIO_POLIZA & "' AND UUID='" & sReplace(sUUID) & "'").Result1) = True Then
                bResultado = True
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, sProcedure, ex)
        End Try

        Return bResultado
    End Function
#End Region

End Class




