Option Strict On
Imports System.Data
Imports System.Data.SqlClient

Public Class Class_Contabilidad_IVA_Acreditable_Global

#Region "Campos"

#Region "Campos de la tabla"
    Private _ID_CON_IVA_ACREDITABLE_GLOBAL As Integer
    Private _FOLIO_POLIZA As String
    Private _FECHA_POLIZA As Date
    Private _FECHA As Date
    Private _FECHA_SERVIDOR As Date
    Private _ESTATUS As String
    Private _CODIGO_USUARIO_GRABO As Integer
    Private _NOMBRE_USUARIO_GRABO As String
    Private _CONCEPTO As String
    Private _TOTAL_ACTOS_IVA_EXENTO As Double
    Private _TOTAL_ACTOS_AL_0 As Double
    Private _TOTAL_ACTOS_AL_8 As Double
    Private _TOTAL_ACTOS_AL_10 As Double
    Private _TOTAL_ACTOS_AL_15 As Double
    Private _TOTAL_ACTOS_AL_11 As Double
    Private _TOTAL_ACTOS_AL_16 As Double
    Private _TOTAL_ACTOS As Double
    Private _TOTAL_IVA_ACREDITABLE_AL_8 As Double
    Private _TOTAL_IVA_ACREDITABLE_AL_10 As Double
    Private _TOTAL_IVA_ACREDITABLE_AL_15 As Double
    Private _TOTAL_IVA_ACREDITABLE_AL_11 As Double
    Private _TOTAL_IVA_ACREDITABLE_AL_16 As Double
    Private _TOTAL_IVA_RETENIDO_AL_4 As Double
    Private _TOTAL_IVA_RETENIDO_AL_6 As Double
    Private _TOTAL_IVA_RETENIDO_AL_10 As Double
#End Region

#Region "Campos ligados a la tabla"
    Private _ExisteDocumentoIVA As Boolean
    Private _ExisteDocumentoPoliza As Boolean

    Private _IVAACubrirAl8 As Double
    Private _IVAACubrirAl10 As Double
    Private _IVAACubrirAl15 As Double
    Private _IVAACubrirAl11 As Double
    Private _IVAACubrirAl16 As Double
#End Region

#Region "Clase Detalle"
    Public oIVADetalle As Class_Contabilidad_IVA_Acreditable_Detalle
#End Region

#Region "Campos de sistema"
    Private _Conexion As SqlConnection
    Private _QuerySelect As String
#End Region

#End Region

#Region "Propiedades"

#Region "Propiedades Campos de la tabla"
    Public ReadOnly Property ID_CON_IVA_ACREDITABLE_GLOBAL() As Integer
        Get
            Return Me._ID_CON_IVA_ACREDITABLE_GLOBAL
        End Get
    End Property

    Public ReadOnly Property FOLIO_POLIZA() As String
        Get
            Return Me._FOLIO_POLIZA
        End Get
    End Property

    Public ReadOnly Property FECHA_SERVIDOR() As Date
        Get
            Return Me._FECHA_SERVIDOR
        End Get
    End Property

    Public ReadOnly Property ESTATUS() As String
        Get
            Return Me._ESTATUS
        End Get
    End Property

    Public Property CODIGO_USUARIO_GRABO() As Integer
        Get
            Return Me._CODIGO_USUARIO_GRABO
        End Get
        Set(ByVal value As Integer)
            Me._CODIGO_USUARIO_GRABO = value
        End Set
    End Property

    Public ReadOnly Property NOMBRE_USUARIO_GRABO() As String
        Get
            Return Me._NOMBRE_USUARIO_GRABO
        End Get
    End Property

    Public Property CONCEPTO() As String
        Get
            Return Me._CONCEPTO
        End Get
        Set(ByVal value As String)
            Me._CONCEPTO = value
        End Set
    End Property

    Public Property TOTAL_ACTOS_IVA_EXENTO() As Double
        Get
            Return Me._TOTAL_ACTOS_IVA_EXENTO
        End Get
        Set(ByVal value As Double)
            Me._TOTAL_ACTOS_IVA_EXENTO = value
        End Set
    End Property

    Public Property TOTAL_ACTOS_AL_0() As Double
        Get
            Return Me._TOTAL_ACTOS_AL_0
        End Get
        Set(ByVal value As Double)
            Me._TOTAL_ACTOS_AL_0 = value
        End Set
    End Property

    Public Property TOTAL_ACTOS_AL_8() As Double
        Get
            Return Me._TOTAL_ACTOS_AL_8
        End Get
        Set(ByVal value As Double)
            Me._TOTAL_ACTOS_AL_8 = value
        End Set
    End Property

    Public Property TOTAL_ACTOS_AL_10() As Double
        Get
            Return Me._TOTAL_ACTOS_AL_10
        End Get
        Set(ByVal value As Double)
            Me._TOTAL_ACTOS_AL_10 = value
        End Set
    End Property

    Public Property TOTAL_ACTOS_AL_15() As Double
        Get
            Return Me._TOTAL_ACTOS_AL_15
        End Get
        Set(ByVal value As Double)
            Me._TOTAL_ACTOS_AL_15 = value
        End Set
    End Property

    Public Property TOTAL_ACTOS_AL_11() As Double
        Get
            Return Me._TOTAL_ACTOS_AL_11
        End Get
        Set(ByVal value As Double)
            Me._TOTAL_ACTOS_AL_11 = value
        End Set
    End Property

    Public Property TOTAL_ACTOS_AL_16() As Double
        Get
            Return Me._TOTAL_ACTOS_AL_16
        End Get
        Set(ByVal value As Double)
            Me._TOTAL_ACTOS_AL_16 = value
        End Set
    End Property

    Public Property TOTAL_ACTOS() As Double
        Get
            Return Me._TOTAL_ACTOS
        End Get
        Set(ByVal value As Double)
            Me._TOTAL_ACTOS = value
        End Set
    End Property

    Public Property TOTAL_IVA_ACREDITABLE_AL_8() As Double
        Get
            Return Me._TOTAL_IVA_ACREDITABLE_AL_8
        End Get
        Set(ByVal value As Double)
            Me._TOTAL_IVA_ACREDITABLE_AL_8 = value
        End Set
    End Property

    Public Property TOTAL_IVA_ACREDITABLE_AL_10() As Double
        Get
            Return Me._TOTAL_IVA_ACREDITABLE_AL_10
        End Get
        Set(ByVal value As Double)
            Me._TOTAL_IVA_ACREDITABLE_AL_10 = value
        End Set
    End Property

    Public Property TOTAL_IVA_ACREDITABLE_AL_15() As Double
        Get
            Return Me._TOTAL_IVA_ACREDITABLE_AL_15
        End Get
        Set(ByVal value As Double)
            Me._TOTAL_IVA_ACREDITABLE_AL_15 = value
        End Set
    End Property

    Public Property TOTAL_IVA_ACREDITABLE_AL_11() As Double
        Get
            Return Me._TOTAL_IVA_ACREDITABLE_AL_11
        End Get
        Set(ByVal value As Double)
            Me._TOTAL_IVA_ACREDITABLE_AL_11 = value
        End Set
    End Property

    Public Property TOTAL_IVA_ACREDITABLE_AL_16() As Double
        Get
            Return Me._TOTAL_IVA_ACREDITABLE_AL_16
        End Get
        Set(ByVal value As Double)
            Me._TOTAL_IVA_ACREDITABLE_AL_16 = value
        End Set
    End Property

    Public Property TOTAL_IVA_RETENIDO_AL_4() As Double
        Get
            Return Me._TOTAL_IVA_RETENIDO_AL_4
        End Get
        Set(ByVal value As Double)
            Me._TOTAL_IVA_RETENIDO_AL_4 = value
        End Set
    End Property

    Public Property TOTAL_IVA_RETENIDO_AL_6() As Double
        Get
            Return Me._TOTAL_IVA_RETENIDO_AL_6
        End Get
        Set(ByVal value As Double)
            Me._TOTAL_IVA_RETENIDO_AL_6 = value
        End Set
    End Property

    Public Property TOTAL_IVA_RETENIDO_AL_10() As Double
        Get
            Return Me._TOTAL_IVA_RETENIDO_AL_10
        End Get
        Set(ByVal value As Double)
            Me._TOTAL_IVA_RETENIDO_AL_10 = value
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

#End Region

#Region "Propiedades de campos ligados a la tabla"
    Public ReadOnly Property ExisteDocumentoIVA() As Boolean
        Get
            Return Me._ExisteDocumentoIVA
        End Get
    End Property

    Public ReadOnly Property ExisteDocumentoPoliza() As Boolean
        Get
            Return Me._ExisteDocumentoPoliza
        End Get
    End Property

    Public ReadOnly Property FECHA_POLIZA() As Date
        Get
            Return Me._FECHA_POLIZA
        End Get
    End Property

    Public ReadOnly Property IVAACubrirAl8() As Double
        Get
            Return Me._IVAACubrirAl8
        End Get
    End Property

    Public ReadOnly Property IVAACubrirAl10() As Double
        Get
            Return Me._IVAACubrirAl10
        End Get
    End Property

    Public ReadOnly Property IVAACubrirAl15() As Double
        Get
            Return Me._IVAACubrirAl15
        End Get
    End Property

    Public ReadOnly Property IVAACubrirAl11() As Double
        Get
            Return Me._IVAACubrirAl11
        End Get
    End Property

    Public ReadOnly Property IVAACubrirAl16() As Double
        Get
            Return Me._IVAACubrirAl16
        End Get
    End Property
#End Region

#Region "Propiedad Nombre de Clase"
    Public ReadOnly Property Nombre_Clase() As String
        Get
            Return "Class_Contabilidad_IVA_Acreditable_Global"
        End Get
    End Property
#End Region

#End Region

#Region "Constructor y destructor"
    Public Sub New(ByVal sFolioPoliza As String)
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "SELECT G.*,U.NOMBRE_USUARIO NOMBRE_USUARIO_GRABO,PG.FECHA FECHA_POLIZA " & _
        "FROM CON_IVA_ACREDITABLE_GLOBAL G " & _
        "INNER JOIN SIS_USUARIOS U ON(G.CODIGO_USUARIO_GRABO=U.CODIGO_USUARIO) " & _
        "INNER JOIN CON_POLIZAS_GLOBAL PG ON(G.FOLIO_POLIZA=PG.FOLIO_POLIZA) "
        Me.oIVADetalle = New Class_Contabilidad_IVA_Acreditable_Detalle(sFolioPoliza)

        Me._FOLIO_POLIZA = sFolioPoliza

        'Me.oPolizaDetalle = New Class_Contabilidad_Detalle_Poliza
        Try
            If Me.Consultar = True Then
                Me._ExisteDocumentoIVA = True
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
        Dim cmd As New SqlCommand(Me._QuerySelect & " WHERE G.FOLIO_POLIZA='" & Me._FOLIO_POLIZA & "'", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()

                dReader = .ExecuteReader()
                If dReader.Read Then
                    Me._ID_CON_IVA_ACREDITABLE_GLOBAL = CType(dReader("ID_CON_IVA_ACREDITABLE_GLOBAL"), Integer)
                    Me._FOLIO_POLIZA = dReader("FOLIO_POLIZA").ToString
                    Me._FECHA_POLIZA = CDate(dReader("FECHA_POLIZA"))
                    Me._FECHA = CDate(dReader("FECHA"))
                    Me._FECHA_SERVIDOR = CDate(dReader("FECHA_SERVIDOR"))
                    Me._ESTATUS = dReader("ESTATUS").ToString
                    Me._CODIGO_USUARIO_GRABO = CType(dReader("CODIGO_USUARIO_GRABO"), Integer)
                    Me._NOMBRE_USUARIO_GRABO = dReader("NOMBRE_USUARIO_GRABO").ToString
                    Me._CONCEPTO = dReader("CONCEPTO").ToString
                    Me._TOTAL_ACTOS_IVA_EXENTO = valorNumerico(dReader("TOTAL_ACTOS_IVA_EXENTO").ToString)
                    Me._TOTAL_ACTOS_AL_0 = valorNumerico(dReader("TOTAL_ACTOS_AL_0").ToString)
                    Me._TOTAL_ACTOS_AL_8 = valorNumerico(dReader("TOTAL_ACTOS_AL_8").ToString)
                    Me._TOTAL_ACTOS_AL_10 = valorNumerico(dReader("TOTAL_ACTOS_AL_10").ToString)
                    Me._TOTAL_ACTOS_AL_15 = valorNumerico(dReader("TOTAL_ACTOS_AL_15").ToString)
                    Me._TOTAL_ACTOS_AL_11 = valorNumerico(dReader("TOTAL_ACTOS_AL_11").ToString)
                    Me._TOTAL_ACTOS_AL_16 = valorNumerico(dReader("TOTAL_ACTOS_AL_16").ToString)
                    Me._TOTAL_ACTOS = valorNumerico(dReader("TOTAL_ACTOS").ToString)
                    Me._TOTAL_IVA_ACREDITABLE_AL_8 = valorNumerico(dReader("TOTAL_IVA_ACREDITABLE_AL_8").ToString)
                    Me._TOTAL_IVA_ACREDITABLE_AL_10 = valorNumerico(dReader("TOTAL_IVA_ACREDITABLE_AL_10").ToString)
                    Me._TOTAL_IVA_ACREDITABLE_AL_15 = valorNumerico(dReader("TOTAL_IVA_ACREDITABLE_AL_15").ToString)
                    Me._TOTAL_IVA_ACREDITABLE_AL_11 = valorNumerico(dReader("TOTAL_IVA_ACREDITABLE_AL_11").ToString)
                    Me._TOTAL_IVA_ACREDITABLE_AL_16 = valorNumerico(dReader("TOTAL_IVA_ACREDITABLE_AL_16").ToString)
                    Me._TOTAL_IVA_RETENIDO_AL_4 = valorNumerico(dReader("TOTAL_IVA_RETENIDO_AL_4").ToString)
                    Me._TOTAL_IVA_RETENIDO_AL_6 = valorNumerico(dReader("TOTAL_IVA_RETENIDO_AL_6").ToString)
                    Me._TOTAL_IVA_RETENIDO_AL_10 = valorNumerico(dReader("TOTAL_IVA_RETENIDO_AL_10").ToString)

                    Consultar = True
                End If
                dReader.Close()

                Dim sql As New Class_find("SELECT 1,FECHA FROM CON_POLIZAS_GLOBAL WHERE FOLIO_POLIZA='" & Me._FOLIO_POLIZA & "'")
                Me._ExisteDocumentoPoliza = CBool(IIf(txtLEN(sql.Result1) = True, True, False))
                If Me._ExisteDocumentoPoliza Then
                    Me._FECHA_POLIZA = CDate(sql.Result2)
                End If
                sql = Nothing

                If Me._ExisteDocumentoPoliza = True Then
                    Me.ObtieneTotalesIvaAcreditablePoliza()
                End If

            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "Consultar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
            End Try
        End With
    End Function

    Private Function ObtieneTotalesIvaAcreditablePoliza() As Boolean
        Dim dTabla As New DataTable("detalle"), da As SqlDataAdapter
        Dim sSQL As String = "EXEC DBO.MP_CONTABILIDAD_IVA_ACREDITABLE_OBTIENE_TOTALES_IVA_ACREDITABLE_POLIZA @FOLIO_POLIZA='" & Me._FOLIO_POLIZA & "'"
        Try
            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dTabla)
            da.Dispose()

            If dTabla.Rows.Count > 0 Then
                Me._IVAACubrirAl10 = CDbl(dTabla.Rows(0)("IVA_10"))
                Me._IVAACubrirAl15 = CDbl(dTabla.Rows(0)("IVA_15"))
                Me._IVAACubrirAl11 = CDbl(dTabla.Rows(0)("IVA_11"))
                Me._IVAACubrirAl16 = CDbl(dTabla.Rows(0)("IVA_16"))
                Me._IVAACubrirAl8 = CDbl(dTabla.Rows(0)("IVA_8"))
                ObtieneTotalesIvaAcreditablePoliza = True
            End If

            dTabla.Dispose()

        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "ObtieneTotalesIvaAcreditablePoliza", ex)
        End Try
    End Function

    Public Function GrabaIVAAcreditableGlobal() As Boolean
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CONTABILIDAD_IVA_ACREDITABLE_GRABA_GLOBAL"

            sqlParametro = .Parameters.Add("@FOLIO_POLIZA", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_POLIZA
            sqlParametro = .Parameters.Add("@FECHA", SqlDbType.DateTime) : sqlParametro.Value = Me._FECHA
            sqlParametro = .Parameters.Add("@TOTAL_ACTOS_AL_0", SqlDbType.Money) : sqlParametro.Value = Me._TOTAL_ACTOS_AL_0
            sqlParametro = .Parameters.Add("@TOTAL_ACTOS_AL_8", SqlDbType.Money) : sqlParametro.Value = Me._TOTAL_ACTOS_AL_8
            sqlParametro = .Parameters.Add("@TOTAL_ACTOS_AL_10", SqlDbType.Money) : sqlParametro.Value = Me._TOTAL_ACTOS_AL_10
            sqlParametro = .Parameters.Add("@TOTAL_ACTOS_AL_15", SqlDbType.Money) : sqlParametro.Value = Me._TOTAL_ACTOS_AL_15
            sqlParametro = .Parameters.Add("@TOTAL_ACTOS_AL_11", SqlDbType.Money) : sqlParametro.Value = Me._TOTAL_ACTOS_AL_11
            sqlParametro = .Parameters.Add("@TOTAL_ACTOS_AL_16", SqlDbType.Money) : sqlParametro.Value = Me._TOTAL_ACTOS_AL_16
            sqlParametro = .Parameters.Add("@TOTAL_ACTOS_IVA_EXENTO", SqlDbType.Money) : sqlParametro.Value = Me._TOTAL_ACTOS_IVA_EXENTO
            sqlParametro = .Parameters.Add("@TOTAL_ACTOS", SqlDbType.Money) : sqlParametro.Value = Me._TOTAL_ACTOS
            sqlParametro = .Parameters.Add("@TOTAL_IVA_ACREDITABLE_AL_8", SqlDbType.Money) : sqlParametro.Value = Me._TOTAL_IVA_ACREDITABLE_AL_8
            sqlParametro = .Parameters.Add("@TOTAL_IVA_ACREDITABLE_AL_10", SqlDbType.Money) : sqlParametro.Value = Me._TOTAL_IVA_ACREDITABLE_AL_10
            sqlParametro = .Parameters.Add("@TOTAL_IVA_ACREDITABLE_AL_15", SqlDbType.Money) : sqlParametro.Value = Me._TOTAL_IVA_ACREDITABLE_AL_15
            sqlParametro = .Parameters.Add("@TOTAL_IVA_ACREDITABLE_AL_11", SqlDbType.Money) : sqlParametro.Value = Me._TOTAL_IVA_ACREDITABLE_AL_11
            sqlParametro = .Parameters.Add("@TOTAL_IVA_ACREDITABLE_AL_16", SqlDbType.Money) : sqlParametro.Value = Me._TOTAL_IVA_ACREDITABLE_AL_16
            sqlParametro = .Parameters.Add("@TOTAL_IVA_RETENIDO_AL_4", SqlDbType.Money) : sqlParametro.Value = Me._TOTAL_IVA_RETENIDO_AL_4
            sqlParametro = .Parameters.Add("@TOTAL_IVA_RETENIDO_AL_6", SqlDbType.Money) : sqlParametro.Value = Me._TOTAL_IVA_RETENIDO_AL_6
            sqlParametro = .Parameters.Add("@TOTAL_IVA_RETENIDO_AL_10", SqlDbType.Money) : sqlParametro.Value = Me._TOTAL_IVA_RETENIDO_AL_10
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO_GRABO", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_USUARIO_GRABO
            sqlParametro = .Parameters.Add("@CONCEPTO", SqlDbType.NVarChar, 80) : sqlParametro.Value = Me._CONCEPTO.ToUpper

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                GrabaIVAAcreditableGlobal = True
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "GrabaIVAAcreditableGlobal", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
    End Function

    Public Function AplicaIVAAcreditable(Optional ByVal bRegenera As Boolean = True) As Boolean
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CONTABILIDAD_IVA_ACREDITABLE_APLICA"

            sqlParametro = .Parameters.Add("@FOLIO_POLIZA", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_POLIZA

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                AplicaIVAAcreditable = True
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "AplicaIVAAcreditable", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
    End Function

    Public Function CancelaIVAAcreditable(Optional ByVal bRegenera As Boolean = True) As Boolean
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CONTABILIDAD_IVA_ACREDITABLE_CANCELA"

            sqlParametro = .Parameters.Add("@FOLIO_POLIZA", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_POLIZA

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                CancelaIVAAcreditable = True
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "CancelaIVAAcreditable", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
    End Function

    Public Function ReactivaIVAAcreditable(Optional ByVal bRegenera As Boolean = True) As Boolean
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CONTABILIDAD_IVA_ACREDITABLE_REACTIVA"

            sqlParametro = .Parameters.Add("@FOLIO_POLIZA", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_POLIZA

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                ReactivaIVAAcreditable = True
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "ReactivaIVAAcreditable", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
    End Function

    Public Function ObtenerDetalle() As DataTable
        'Dim dTabla As New DataTable("detalle"), da As SqlDataAdapter
        'Dim sSQL As String
        'sSQL = "SELECT D.FOLIO_COMPRA,D.CODIGO_PROVEEDOR,P.NOMBRE_PROVEEDOR,D.FOLIO_PROVEEDOR,D.PERIODO,D.ANIO,D.OPERACIONES," & _
        '        "D.ACTOS_AL_0,D.ACTOS_AL_11,D.ACTOS_AL_16,D.SUBTOTAL_ACTOS," & _
        '        "D.IVA_ACREDITABLE_AL_11,D.IVA_ACREDITABLE_AL_16," & _
        '        "D.IVA_RETENIDO_AL_4,D.IVA_RETENIDO_AL_10,D.ID_CON_IVA_ACREDITABLE_DETALLE " & _
        '        "FROM CON_IVA_ACREDITABLE_DETALLE D " & _
        '        "INNER JOIN CAT_PROVEEDORES P ON(D.CODIGO_PROVEEDOR=P.CODIGO_PROVEEDOR) " & _
        '        "WHERE D.FOLIO_POLIZA='" & Me._FOLIO_POLIZA & "' " & _
        '        "ORDER BY D.ID_CON_IVA_ACREDITABLE_DETALLE"
        'Try
        '    da = New SqlDataAdapter(sSQL, Me._Conexion)
        '    da.Fill(dTabla)
        '    da.Dispose()
        'Catch ex As Exception
        '    HandleError(Me.Nombre_Clase, "ObtenerDetalle", ex)
        'End Try
        'ObtenerDetalle = dTabla

        Dim dt As New DataTable
        Try
            Using da As New SqlDataAdapter("MP_CONTABILIDAD_IVA_ACREDITABLE_OBTIENE_DETALLE", Me._Conexion)
                da.SelectCommand.CommandType = CommandType.StoredProcedure

                With da.SelectCommand
                    .Parameters.Add("@FOLIO_POLIZA", SqlDbType.NVarChar, 15).Value = Me._FOLIO_POLIZA
                End With

                da.Fill(dt)
                'dt.Columns.Remove("ID")
            End Using

        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "ObtenerDetalle", ex)
        Finally

        End Try
        ObtenerDetalle = dt

    End Function

    Public Sub NuevoRenglon()
        Me.oIVADetalle = New Class_Contabilidad_IVA_Acreditable_Detalle(Me._FOLIO_POLIZA)
    End Sub
#End Region

End Class
