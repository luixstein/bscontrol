Option Strict On
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class Class_CatCuentas

    Public Enum FiltroCuenta
        CODIGO_CUENTA
        NOMBRE_CUENTA
    End Enum

#Region "Campos"

#Region "Campos de la tabla"
    Private _NIVEL1 As String
    Private _NIVEL2 As String
    Private _NIVEL3 As String
    Private _NIVEL4 As String
    Private _NIVEL5 As String
    Private _NOMBRE_CUENTA As String
    Private _NATURALEZA_CONTABLE As String
    Private _TIPO_CONTABILIDAD As String
    Private _ESMAYOR As String
    Private _CUENTA_CONTABLE As String
    Private _PROTEGIDO As String
    Private _CODIGO_PLAZA As Integer
    Private _CODIGO_AGRUPADOR As String
    Private _SUBCUENTADE As String
    Private _NIVEL As Integer
    Private _ESTATUS As String
#End Region

#Region "Campos de sistema"
    Private _Nombre_Catalogo As String
    Private _Nombre_Reporte As String
    Private _Conexion As SqlConnection
    Private _QuerySelect As String
    Private _QueryOrder As String
#End Region

#Region "Campos ligados a la tabla"
    Public _Existe As Boolean 'lectura
    Private _NOMBRE_CUENTA_SAT As String
    Private _CLONAR_CODIGO_AGRUPADOR_MISMO_NIVEL As String = "0"
    Private _NOMBRE_CUENTA_NIVELES_COMPLETOS As String
#End Region

#End Region

#Region "Propiedades"

#Region "Propiedades Campos de la tabla"
    Public Property NIVEL1() As String
        Get
            Return Me._NIVEL1
        End Get
        Set(ByVal Value As String)
            Me._NIVEL1 = Value
        End Set
    End Property

    Public Property NIVEL2() As String
        Get
            Return Me._NIVEL2
        End Get
        Set(ByVal Value As String)
            Me._NIVEL2 = Value
        End Set
    End Property

    Public Property NIVEL3() As String
        Get
            Return Me._NIVEL3
        End Get
        Set(ByVal Value As String)
            Me._NIVEL3 = Value
        End Set
    End Property

    Public Property NIVEL4() As String
        Get
            Return Me._NIVEL4
        End Get
        Set(ByVal Value As String)
            Me._NIVEL4 = Value
        End Set
    End Property

    Public Property NIVEL5() As String
        Get
            Return Me._NIVEL5
        End Get
        Set(ByVal Value As String)
            Me._NIVEL5 = Value
        End Set
    End Property

    Public Property NOMBRE_CUENTA() As String
        Get
            Return Me._NOMBRE_CUENTA
        End Get
        Set(ByVal Value As String)
            Me._NOMBRE_CUENTA = Value
        End Set
    End Property

    Public Property NATURALEZA_CONTABLE() As String
        Get
            Return Me._NATURALEZA_CONTABLE
        End Get
        Set(ByVal value As String)
            Me._NATURALEZA_CONTABLE = value
        End Set
    End Property

    Public Property ESMAYOR() As String
        Get
            Return Me._ESMAYOR
        End Get
        Set(ByVal value As String)
            Me._ESMAYOR = value
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

    Public Property CUENTA_CONTABLE() As String
        Get
            Return Me._CUENTA_CONTABLE
        End Get
        Set(ByVal value As String)
            Me._CUENTA_CONTABLE = value
        End Set
    End Property

    Public ReadOnly Property PROTEGIDO() As String
        Get
            Return Me._PROTEGIDO
        End Get
    End Property

    Public Property CODIGO_PLAZA() As Integer
        Get
            Return Me._CODIGO_PLAZA
        End Get
        Set(ByVal value As Integer)
            Me._CODIGO_PLAZA = value
        End Set
    End Property

    Public Property CODIGO_AGRUPADOR() As String
        Get
            Return Me._CODIGO_AGRUPADOR
        End Get
        Set(ByVal value As String)
            Me._CODIGO_AGRUPADOR = value
        End Set
    End Property

    Public ReadOnly Property SUBCUENTADE() As String
        Get
            Return Me._SUBCUENTADE
        End Get
    End Property

    Public ReadOnly Property NIVEL() As Integer
        Get
            Return Me._NIVEL
        End Get
    End Property

    Public Property ESTATUS() As String
        Get
            Return Me._ESTATUS
        End Get
        Set(ByVal Value As String)
            Me._ESTATUS = Value
        End Set
    End Property
#End Region

#Region "Propiedades de campos ligados a la tabla"
    Public ReadOnly Property NOMBRE_CUENTA_SAT() As String
        Get
            Return Me._NOMBRE_CUENTA_SAT
        End Get
    End Property

    Public WriteOnly Property CLONAR_CODIGO_AGRUPADOR_MISMO_NIVEL As String
        Set(value As String)
            Me._CLONAR_CODIGO_AGRUPADOR_MISMO_NIVEL = value
        End Set
    End Property

    Public ReadOnly Property NOMBRE_CUENTA_NIVELES_COMPLETOS() As String
        Get
            Return Me._NOMBRE_CUENTA_NIVELES_COMPLETOS
        End Get
    End Property

    Public ReadOnly Property EXISTE() As Boolean
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
        Me._Nombre_Catalogo = "CON_CAT_CUENTAS"
        Me._Nombre_Reporte = "RPT_CATALOGO_CUENTAS_CONTABLES"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "SELECT C.*,S.NOMBRE_CUENTA_SAT,dbo.FN_CONTABILIDAD_NOMBRE_CUENTA_NIVELES_COMPLETOS(CUENTA_CONTABLE) NOMBRE_CUENTA_NIVELES_COMPLETOS " &
            "FROM CON_CAT_CUENTAS C " &
            "LEFT JOIN CAT_CUENTAS_SAT S ON(C.CODIGO_AGRUPADOR=S.CODIGO_AGRUPADOR) "
        Me._QueryOrder = " ORDER BY C.NIVEL1,C.NIVEL2,C.NIVEL3,C.NIVEL4,C.NIVEL5"
    End Sub

    Public Sub New(ByVal sCuenta As String)
        Me.New()
        Try
            Me.CUENTA_CONTABLE = sCuenta
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
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CAT_CUENTAS_GRABA"

            sqlParametro = .Parameters.Add("@NIVEL1", SqlDbType.NVarChar, 4) : sqlParametro.Value = Me._NIVEL1
            sqlParametro = .Parameters.Add("@NIVEL2", SqlDbType.NVarChar, 4) : sqlParametro.Value = Me._NIVEL2
            sqlParametro = .Parameters.Add("@NIVEL3", SqlDbType.NVarChar, 4) : sqlParametro.Value = Me._NIVEL3
            sqlParametro = .Parameters.Add("@NIVEL4", SqlDbType.NVarChar, 4) : sqlParametro.Value = Me._NIVEL4
            sqlParametro = .Parameters.Add("@NIVEL5", SqlDbType.NVarChar, 4) : sqlParametro.Value = Me._NIVEL5
            sqlParametro = .Parameters.Add("@NOMBRE_CUENTA", SqlDbType.NVarChar, 120) : sqlParametro.Value = Me._NOMBRE_CUENTA.ToUpper
            sqlParametro = .Parameters.Add("@TIPO_CONTABILIDAD", SqlDbType.NVarChar, 2) : sqlParametro.Value = Me._TIPO_CONTABILIDAD.ToUpper
            sqlParametro = .Parameters.Add("@PROTEGIDO", SqlDbType.Char, 1) : sqlParametro.Value = "0"
            sqlParametro = .Parameters.Add("@CODIGO_PLAZA", SqlDbType.SmallInt) : sqlParametro.Value = Me.CODIGO_PLAZA
            sqlParametro = .Parameters.Add("@CODIGO_AGRUPADOR", SqlDbType.NVarChar, 10) : sqlParametro.Value = Me._CODIGO_AGRUPADOR
            sqlParametro = .Parameters.Add("@CLONAR_CODIGO_AGRUPADOR_MISMO_NIVEL", SqlDbType.Char, 1) : sqlParametro.Value = Me._CLONAR_CODIGO_AGRUPADOR_MISMO_NIVEL
            sqlParametro = .Parameters.Add("@ACCION", SqlDbType.NVarChar, 15) : sqlParametro.Value = sAccion 'INSERTAR,ACTUALIZAR
            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "Grabar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With

        Return bResultado
    End Function

    ''' <summary>
    ''' Carga al objeto con todos los datos del registro.
    ''' </summary>
    Public Function Consultar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand(Me._QuerySelect & " WHERE CUENTA_CONTABLE='" & Me._CUENTA_CONTABLE & "' ", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._NIVEL1 = Trim("" & dReader("NIVEL1").ToString)
                    Me._NIVEL2 = Trim("" & dReader("NIVEL2").ToString)
                    Me._NIVEL3 = Trim("" & dReader("NIVEL3").ToString)
                    Me._NIVEL4 = Trim("" & dReader("NIVEL4").ToString)
                    Me._NIVEL5 = Trim("" & dReader("NIVEL5").ToString)
                    Me._NOMBRE_CUENTA = Trim("" & dReader("NOMBRE_CUENTA").ToString)
                    Me._NATURALEZA_CONTABLE = Trim("" & dReader("NATURALEZA_CONTABLE").ToString)
                    Me._ESMAYOR = Trim("" & dReader("ESMAYOR").ToString)
                    Me._TIPO_CONTABILIDAD = Trim("" & dReader("TIPO_CONTABILIDAD").ToString)
                    Me._CUENTA_CONTABLE = Trim("" & dReader("CUENTA_CONTABLE").ToString)
                    Me._PROTEGIDO = Trim("" & dReader("PROTEGIDO").ToString)
                    Me._CODIGO_PLAZA = CInt(dReader("CODIGO_PLAZA").ToString)
                    Me._CODIGO_AGRUPADOR = Trim("" & dReader("CODIGO_AGRUPADOR").ToString)
                    Me._NOMBRE_CUENTA_SAT = Trim("" & dReader("NOMBRE_CUENTA_SAT").ToString)
                    Me._SUBCUENTADE = Trim("" & dReader("SUBCUENTADE").ToString)
                    Me._NIVEL = CInt(dReader("NIVEL").ToString)
                    Me._NOMBRE_CUENTA_NIVELES_COMPLETOS = Trim("" & dReader("NOMBRE_CUENTA_NIVELES_COMPLETOS").ToString)
                    Me._ESTATUS = "" & dReader("ESTATUS").ToString

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

    Public Function Eliminar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CAT_CUENTAS_ELIMINA"
            sqlParametro = .Parameters.Add("@CUENTA_CONTABLE", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._CUENTA_CONTABLE
            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "Eliminar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With

        Return bResultado
    End Function

    ''' <summary>
    ''' Devuelve un datatable con todos los registros de la tabla
    ''' </summary>
    Public Function ObtenerElementos() As System.Data.DataTable
        Dim dTable As New DataTable

        'Dim DSCAT As New SqlDataAdapter("SELECT CUENTA_CONTABLE,(LEFT(CAST(CUENTA_CONTABLE AS NVARCHAR(20)) + '                   ',20) + ' ' + NOMBRE_CUENTA) AS NOMBRE_CUENTA FROM CON_CAT_CUENTAS ORDER BY CUENTA_CONTABLE", Me._Conexion)
        Dim dA As New SqlDataAdapter("SELECT C.CUENTA_CONTABLE,C.NOMBRE_CUENTA,P.NOMBRE_PLAZA " &
                                     "FROM CON_CAT_CUENTAS C INNER JOIN SIS_PLAZAS P ON(C.CODIGO_PLAZA=P.CODIGO_PLAZA) " &
                                     "" &
                                     "ORDER BY C.CUENTA_CONTABLE", Me._Conexion)
        Try
            dA.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementos", ex)
        Finally
            dA.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerElementosN(ByVal TipoBusqueda As FiltroCuenta, ByVal sFiltro As String, ByVal sCodigoAgrupador As String, Optional ByVal sPlaza As String = "") As System.Data.DataTable
        Dim dTable As New DataTable
        Dim sWhere As String = ""

        If txtLEN(sFiltro) = True Then
            Select Case TipoBusqueda
                Case FiltroCuenta.CODIGO_CUENTA
                    sWhere = " AND C.CUENTA_CONTABLE LIKE '" & sReplace(sFiltro) & "%' "
                Case FiltroCuenta.NOMBRE_CUENTA
                    sWhere = " AND C.NOMBRE_CUENTA LIKE '" & sReplace(sFiltro) & "%' "
            End Select
        End If

        If txtLEN(sCodigoAgrupador) = True And sCodigoAgrupador <> "TODAS" Then
            Select Case sCodigoAgrupador
                Case "SIN CODIGO AGRUPADOR"
                    sWhere = sWhere & " AND C.CODIGO_AGRUPADOR IS NULL AND NIVEL IN(1,2) "
                Case "CON CODIGO AGRUPADOR"
                    sWhere = sWhere & " AND C.CODIGO_AGRUPADOR IS NOT NULL AND NIVEL IN(1,2) "
            End Select
        End If

        If txtLEN(sPlaza) = True Then
            sWhere = sWhere & " AND C.CODIGO_PLAZA=" & sReplace(sPlaza) & " "
        End If

        Dim dA As New SqlDataAdapter("SELECT C.CUENTA_CONTABLE,C.NOMBRE_CUENTA,P.NOMBRE_PLAZA,C.CODIGO_AGRUPADOR,S.NOMBRE_CUENTA_SAT " &
                                     "FROM CON_CAT_CUENTAS C INNER JOIN SIS_PLAZAS P ON(C.CODIGO_PLAZA=P.CODIGO_PLAZA) " &
                                     "LEFT JOIN CAT_CUENTAS_SAT S ON(C.CODIGO_AGRUPADOR=S.CODIGO_AGRUPADOR)" &
                                     "WHERE 1=1 " & sWhere &
                                     "ORDER BY C.CUENTA_CONTABLE", Me._Conexion)
        Try
            dA.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementosN", ex)
        Finally
            dA.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerElementosFiltro(ByVal Filtro As String) As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dA As New SqlDataAdapter("SELECT CUENTA_CONTABLE,NOMBRE_CUENTA FROM CON_CAT_CUENTAS where NOMBRE_CUENTA LIKE '%" & Filtro.ToString & "%' ORDER BY CUENTA_CONTABLE", Me._Conexion)
        Try
            dA.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementosFiltro", ex)
        Finally
            dA.Dispose()
        End Try
        Return dTable
    End Function

    Public Function BusquedaVisual_PorCodigo() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de Cuenta Contable por Código."
        f.sCampo = "C.CUENTA_CONTABLE"
        f.sOrder = "C.CUENTA_CONTABLE"
        f.sTable = "CON_CAT_CUENTAS"
        f.sQl = "Select C.CUENTA_CONTABLE,C.NOMBRE_CUENTA,P.NOMBRE_PLAZA FROM CON_CAT_CUENTAS C INNER JOIN SIS_PLAZAS P ON(C.CODIGO_PLAZA=P.CODIGO_PLAZA) WHERE 1=1 AND "
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

    Public Function BusquedaVisual_PorCodigoConLike(ByVal sLike As String) As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de Cuentas Contables por Código."
        f.sCampo = "C.CUENTA_CONTABLE"
        f.sOrder = "C.CUENTA_CONTABLE"
        f.sTable = "CON_CAT_CUENTAS"
        f.sQl = "SELECT C.CUENTA_CONTABLE,C.NOMBRE_CUENTA,P.NOMBRE_PLAZA FROM CON_CAT_CUENTAS C INNER JOIN SIS_PLAZAS P ON(C.CODIGO_PLAZA=P.CODIGO_PLAZA) " & _
            "WHERE C.CUENTA_CONTABLE LIKE '" & sReplace(sLike) & "%' AND "
        f.Inicia("")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "BusquedaVisual_PorCodigoConLike", ex)
        End Try
        Return Resultado
    End Function

    ''' <summary>
    ''' Despliega la búsqueda visual por descripción.
    ''' </summary>
    Public Function BusquedaVisual_PorDescripcion() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de Cuentas Contables por Descripción."
        f.sCampo = "C.NOMBRE_CUENTA"
        f.sOrder = "C.CUENTA_CONTABLE"
        f.sTable = "CON_CAT_CUENTAS"
        f.sQl = "Select C.CUENTA_CONTABLE,C.NOMBRE_CUENTA,P.NOMBRE_PLAZA FROM CON_CAT_CUENTAS C INNER JOIN SIS_PLAZAS P ON(C.CODIGO_PLAZA=P.CODIGO_PLAZA) WHERE 1=1 AND "
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

    Public Function BusquedaVisual_PorDescripcionConLike(ByVal sLike As String) As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de Cuentas Contables por Descripción."
        f.sCampo = "C.NOMBRE_CUENTA"
        f.sOrder = "C.CUENTA_CONTABLE"
        f.sTable = "CON_CAT_CUENTAS"
        f.sQl = "SELECT C.CUENTA_CONTABLE,C.NOMBRE_CUENTA,P.NOMBRE_PLAZA FROM CON_CAT_CUENTAS C INNER JOIN SIS_PLAZAS P ON(C.CODIGO_PLAZA=P.CODIGO_PLAZA) " & _
            "WHERE C.CUENTA_CONTABLE LIKE '" & sReplace(sLike) & "%' AND "
        f.Inicia("")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "BusquedaVisual_PorDescripcionConLike", ex)
        End Try
        Return Resultado
    End Function

    Public Function BusquedaVisual_PorCodigoFiltrandoTipoOperacion(Optional ByVal bFiltraCuentasOperacion As Boolean = True, Optional ByVal sDefault As String = "") As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = "", sFiltro As String
        f.Text = "Búsqueda de cuenta contable por Código."
        f.sCampo = "C.CUENTA_CONTABLE"
        f.sOrder = "C.CUENTA_CONTABLE"
        f.sTable = "CON_CAT_CUENTAS"
        f.sQl = "Select C.CUENTA_CONTABLE,C.NOMBRE_CUENTA,P.NOMBRE_PLAZA FROM CON_CAT_CUENTAS C INNER JOIN SIS_PLAZAS P ON(C.CODIGO_PLAZA=P.CODIGO_PLAZA) WHERE 1=1 AND "
        f.Inicia(sDefault)
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            Else
                Return Resultado
                Exit Function
            End If

            If bFiltraCuentasOperacion = True Then
                sFiltro = " AND ESMAYOR='0' "
            Else
                sFiltro = ""
            End If

            Dim sql As New Class_find("SELECT CUENTA_CONTABLE FROM CON_CAT_CUENTAS WHERE CUENTA_CONTABLE='" & Resultado & "' " & sFiltro)
            If sql.Result1 = "" Then
                Resultado = ""
                MsgBox("La cuenta contable que intenta buscar es de mayor, favor de intentar con otro código.", MsgBoxStyle.Exclamation, "Validación de Cuentas Contables")
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "BusquedaVisual_PorCodigoFiltrandoTipoOperacion", ex)
        End Try
        Return Resultado
    End Function

    Public Function BusquedaVisual_PorNombreFiltrandoTipoOperacion(Optional ByVal bFiltraCuentasOperacion As Boolean = True) As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = "", sFiltro As String
        f.Text = "Búsqueda de cuenta contable por Nombre."
        f.sCampo = "C.NOMBRE_CUENTA"
        f.sOrder = "C.CUENTA_CONTABLE"
        f.sTable = "CON_CAT_CUENTAS"
        f.sQl = "Select C.CUENTA_CONTABLE,C.NOMBRE_CUENTA,P.NOMBRE_PLAZA FROM CON_CAT_CUENTAS C INNER JOIN SIS_PLAZAS P ON(C.CODIGO_PLAZA=P.CODIGO_PLAZA) WHERE 1=1 AND "
        f.Inicia("")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            Else
                Return Resultado
                Exit Function
            End If

            If bFiltraCuentasOperacion = True Then
                sFiltro = " AND ESMAYOR='0' "
            Else
                sFiltro = ""
            End If

            Dim sql As New Class_find("SELECT CUENTA_CONTABLE FROM CON_CAT_CUENTAS WHERE CUENTA_CONTABLE='" & Resultado & "' " & sFiltro)
            If sql.Result1 = "" Then
                Resultado = ""
                MsgBox("La cuenta contable que intenta buscar es de mayor, favor de intentar con otro código.", MsgBoxStyle.Exclamation, "Validación de Cuentas Contables")
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "BusquedaVisual_PorNombreFiltrandoTipoOperacion", ex)
        End Try
        Return Resultado
    End Function

    Public Function BusquedaVisual_PorCodigoFiltrandoTipoOperacionMayor(Optional ByVal bFiltraCuentasOperacion As Boolean = True) As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = "", sFiltro As String
        f.Text = "Búsqueda de PLAZAS por Código."
        f.sCampo = "C.CUENTA_CONTABLE"
        f.sOrder = "C.CUENTA_CONTABLE"
        f.sTable = "CON_CAT_CUENTAS"
        f.sQl = "Select C.CUENTA_CONTABLE,C.NOMBRE_CUENTA,P.NOMBRE_PLAZA FROM CON_CAT_CUENTAS C INNER JOIN SIS_PLAZAS P ON(C.CODIGO_PLAZA=P.CODIGO_PLAZA) WHERE 1=1 AND "
        f.Inicia("")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            Else
                Return Resultado
                Exit Function
            End If

            If bFiltraCuentasOperacion = True Then
                sFiltro = " AND ESMAYOR='1' "
            Else
                sFiltro = "  "
            End If

            Dim sql As New Class_find("Select CUENTA_CONTABLE From CON_CAT_CUENTAS WHERE CUENTA_CONTABLE='" & Resultado & "' " & sFiltro)
            If sql.Result1 = "" Then
                Resultado = ""
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "BusquedaVisual_PorCodigoFiltrandoTipoOperacionMayor", ex)
        End Try
        Return Resultado
    End Function

    Public Function BusquedaVisual_PorNombreFiltrandoTipoOperacionMayor(Optional ByVal bFiltraCuentasOperacion As Boolean = True) As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = "", sFiltro As String
        f.Text = "Búsqueda de PLAZAS por Nombre."
        f.sCampo = "C.NOMBRE_CUENTA"
        f.sOrder = "C.NOMBRE_CUENTA"
        f.sTable = "CON_CAT_CUENTAS"
        f.sQl = "Select C.CUENTA_CONTABLE,C.NOMBRE_CUENTA,P.NOMBRE_PLAZA FROM CON_CAT_CUENTAS C INNER JOIN SIS_PLAZAS P ON(C.CODIGO_PLAZA=P.CODIGO_PLAZA) WHERE 1=1 AND "
        f.Inicia("")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            Else
                Return Resultado
                Exit Function
            End If

            If bFiltraCuentasOperacion = True Then
                sFiltro = " AND ESMAYOR='1' "
            Else
                sFiltro = ""
            End If

            Dim sql As New Class_find("Select CUENTA_CONTABLE From CON_CAT_CUENTAS WHERE CUENTA_CONTABLE='" & Resultado & "' " & sFiltro & "ORDER BY CUENTA_CONTABLE")
            If sql.Result1 = "" Then
                Resultado = ""
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "BusquedaVisual_PorNombreFiltrandoTipoOperacionMayor", ex)
        End Try
        Return Resultado
    End Function

    Public Function BusquedaVisual_PorCodigoFiltro(ByVal Filtro As String) As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de Cuenta Contable por Código."
        f.sCampo = "CUENTA_CONTABLE"
        f.sOrder = "CUENTA_CONTABLE"
        f.sTable = "CON_CAT_CUENTAS"
        f.sQl = "Select CUENTA_CONTABLE,NOMBRE_CUENTA From CON_CAT_CUENTAS Where CUENTA_CONTABLE LIKE '" & Filtro.ToString & "%' AND "
        f.Inicia("")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "BusquedaVisual_PorCodigoFiltro", ex)
        End Try
        Return Resultado
    End Function

    Public Function isCuentaContableValida(ByVal sCuentaContable As String, Optional ByVal bFiltraCuentasOperacion As Boolean = True) As Boolean
        Dim bResultado As Boolean = False
        Dim sFiltro As String
        Try
            If bFiltraCuentasOperacion = True Then
                sFiltro = " AND ESMAYOR='0' "
            Else
                sFiltro = " AND ESMAYOR='1' "
            End If

            Dim sql As New Class_find("SELECT CUENTA_CONTABLE FROM CON_CAT_CUENTAS WHERE CUENTA_CONTABLE='" & sCuentaContable & "' " & sFiltro)
            If sql.Result1 = "" Then
                bResultado = False
            Else
                bResultado = True
            End If

        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "isCuentaContableValida", ex)
        End Try

        Return bResultado
    End Function

    Public Function ObtenerElementosFiltroCuenta(ByVal Filtro As String) As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dA As New SqlDataAdapter("SELECT CUENTA_CONTABLE,NOMBRE_CUENTA FROM CON_CAT_CUENTAS WHERE CUENTA_CONTABLE LIKE '" & Filtro.ToString & "%' ORDER BY CUENTA_CONTABLE", Me._Conexion)
        Try
            dA.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementosFiltroCuenta", ex)
        Finally
            dA.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerElementosFiltroNombreCuenta(ByVal Filtro As String) As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dA As New SqlDataAdapter("SELECT CUENTA_CONTABLE,NOMBRE_CUENTA FROM CON_CAT_CUENTAS WHERE NOMBRE_CUENTA LIKE '%" & Filtro.ToString & "%' ORDER BY CUENTA_CONTABLE", Me._Conexion)
        Try
            dA.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementosFiltroNombreCuenta", ex)
        Finally
            dA.Dispose()
        End Try
        Return dTable
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
                HandleError(Me.Nombre_Catalogo, "Imprimir_Listado", ex)
            Finally
                oReporte = Nothing
                'Rpt.Dispose()
            End Try
        Else
            MsgBox("El nombre del reporte no ha sido especificado.", MsgBoxStyle.Exclamation, Me.Nombre_Catalogo)
        End If
    End Sub
#End Region

End Class


