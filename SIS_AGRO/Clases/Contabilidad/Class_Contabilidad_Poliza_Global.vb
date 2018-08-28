Option Strict On
Imports System.Data
Imports System.Data.SqlClient

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

#End Region

End Class




