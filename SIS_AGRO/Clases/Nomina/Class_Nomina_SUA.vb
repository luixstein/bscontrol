Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class Class_Nomina_SUA

#Region "Campos de sistema"
    Private _Nombre_Catalogo As String
    Private _Nombre_Reporte As String
    Private _Conexion As SqlConnection
    Private _QuerySelect As String
    Private _QueryOrder As String
    Private _conexionMDB As OleDbConnection
#End Region

#Region "Propiedades"

#Region "Propiedades Campos de la tabla"

#End Region

#Region "Propiedades de campos ligados a la tabla"

#End Region

#Region "Propiedades públicos"

#End Region

#Region "Propiedades de campos privados"

#End Region

#Region "Propiedades de campos de sistema"

#End Region

#Region "Propiedad Nombre de Clase"
    Private ReadOnly Property NombreClase()
        Get
            NombreClase = "Class_Nomina_SUA"
        End Get
    End Property
#End Region
#End Region

#Region "Constructor y destructor"
    Public Sub New()
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._conexionMDB = New OleDbConnection(Plaza.oSisPlazaNomina.CONEXION_SUA_EVENTUALES)
    End Sub                                                         'Inicializa al objeto.

    Protected Overrides Sub Finalize()
        'Me._Conexion.Dispose()
        MyBase.Finalize()
    End Sub
#End Region

    Public Function ObtenerTrabajadoresEventuales(Optional ByVal sFiltro As String = "") As DataTable
        Dim DA As New OleDbDataAdapter("SELECT NUM_AFIL,NUMTRA,NOM_ASEG FROM ASEGURA WHERE 1=1 " & sFiltro & " ORDER BY NOM_ASEG", Plaza.oSisPlazaNomina.CONEXION_SUA_EVENTUALES)
        Dim dt As New DataTable

        Try
            DA.Fill(dt)

        Catch ex As Exception
            HandleError("Class_Nomina_SUA", "ObtenerTrabajadoresEventuales", ex)
        End Try
        ObtenerTrabajadoresEventuales = dt
    End Function

    Public Function ObtenerTrabajadoresMovimientos(ByVal sNumeroImssTrabajador As String) As DataTable
        Dim da As New OleDbDataAdapter("SELECT NUM_AFIL,FEC_INIC,TIP_MOVS, IIF(TIP_MOVS='02','BAJA','ALTA') AS MOVIMIENTO,	" & _
        "SAL_MOVT FROM MOVTOS WHERE NUM_AFIL = '" & sNumeroImssTrabajador & "' ORDER BY FEC_INIC,TIP_MOVS", Plaza.oSisPlazaNomina.CONEXION_SUA_EVENTUALES)
        Dim dt As New DataTable
        Try
            da.Fill(dt)

        Catch ex As Exception
            HandleError("Class_Nomina_SUA", "ObtenerTrabajadoresMovimientos", ex)
        End Try
        ObtenerTrabajadoresMovimientos = dt
    End Function

    Public Function ObtenerAfliacionSemanaAlta(ByVal iSemana As Integer, Optional ByVal bGeneraAlta As Boolean = False) As System.Data.DataTable
        Dim dt As New DataTable
        Try
            Dim da As New SqlDataAdapter("MP_NOMINA_AFILIACIONES_OBTIENE_SEMANA_ALTA", Me._Conexion)
            da.SelectCommand.CommandType = CommandType.StoredProcedure

            With da.SelectCommand
                .Parameters.Add("@ID_NOMINA_SEMANA", SqlDbType.Int).Value = iSemana
                '.Parameters.Add("@ACCION", SqlDbType.Char, 1).Value = Convert.ToInt32(bGeneraAlta).ToString
                .Parameters.Add("@INCLUIR_TRABAJADORES_NUEVOS_SIN_PERCEPCIONES", SqlDbType.Char, 1).Value = Convert.ToInt32(bGeneraAlta).ToString
            End With

            da.Fill(dt)
            'dt.Columns.Remove("ID")
        Catch ex As Exception
            HandleError("Class_Nomina_SUA", "ObtenerAfliacionSemanaAlta", ex)
        Finally

        End Try
        ObtenerAfliacionSemanaAlta = dt
    End Function

    Public Function ObtenerAfliacionSemanaBaja(ByVal iSemana As Integer, Optional ByVal bGeneraAlta As Boolean = False) As System.Data.DataTable
        Dim dt As New DataTable
        Try
            Dim da As New SqlDataAdapter("MP_NOMINA_AFILIACIONES_OBTIENE_SEMANA_BAJA", Me._Conexion)
            da.SelectCommand.CommandType = CommandType.StoredProcedure

            With da.SelectCommand
                .Parameters.Add("@ID_NOMINA_SEMANA", SqlDbType.Int).Value = iSemana
                '.Parameters.Add("@ACCION", SqlDbType.Char, 1).Value = Convert.ToInt32(bGeneraAlta).ToString
            End With

            da.Fill(dt)

        Catch ex As Exception
            HandleError("Class_Nomina_SUA", "ObtenerAfliacionSemanaBaja", ex)
        Finally

        End Try
        ObtenerAfliacionSemanaBaja = dt
    End Function

    Public Function ModificarFechaAfliacionSemanaAlta(ByVal iSemana As Integer, ByVal dFecha As Date, ByVal sTipo As String, ByVal sNombreTxt As String, ByVal SumarDia As Boolean) As System.Data.DataTable
        Dim dt As New DataTable
        Try
            Dim da As New SqlDataAdapter("MP_NOMINA_AFILIACIONES_SEMANA_FECHA_ACTUALIZA", Me._Conexion)
            da.SelectCommand.CommandType = CommandType.StoredProcedure

            With da.SelectCommand
                .Parameters.Add("@ID_NOMINA_SEMANA", SqlDbType.Int).Value = iSemana
                .Parameters.Add("@FECHA", SqlDbType.DateTime).Value = dFecha
                .Parameters.Add("@NOMBRE_ARCHIVO_TXT", SqlDbType.NVarChar, 225).Value = sNombreTxt
                .Parameters.Add("@TIPO", SqlDbType.NVarChar, 10).Value = sTipo
                .Parameters.Add("@SUMAR_DIA", SqlDbType.NVarChar, 1).Value = Convert.ToInt32(SumarDia).ToString
            End With

            da.Fill(dt)
            'dt.Columns.Remove("ID")
        Catch ex As Exception
            HandleError("Class_Nomina_SUA", "ModificarFechaAfliacionSemanaAlta", ex)
        Finally

        End Try
        ModificarFechaAfliacionSemanaAlta = dt
    End Function

    Public Function ObtenerTrabajadorAdicional(ByVal iSemana As Integer, ByVal sCodigoTrabajador As String, ByVal dFecha As Date, ByVal sTipoAdicional As String, Optional ByVal bAccion As Boolean = False) As System.Data.DataTable
        Dim dt As New DataTable
        Try
            Dim da As New SqlDataAdapter("MP_NOMINA_AFILIACIONES_TRABAJADOR_ADICIONAL", Me._Conexion)
            da.SelectCommand.CommandType = CommandType.StoredProcedure

            With da.SelectCommand
                .Parameters.Add("@ID_NOMINA_SEMANA", SqlDbType.Int).Value = iSemana
                .Parameters.Add("@CODIGO_TRABAJADOR", SqlDbType.NVarChar, 10).Value = sCodigoTrabajador
                .Parameters.Add("@FECHA", SqlDbType.DateTime).Value = dFecha
                '.Parameters.Add("@TIPO_ADICIONAL", SqlDbType.NVarChar, 10).Value = sTipoAdicional
                .Parameters.Add("@ACCION", SqlDbType.Char, 1).Value = Convert.ToInt32(bAccion).ToString
            End With

            da.Fill(dt)

        Catch ex As Exception
            HandleError("Class_Nomina_SUA", "ObtenerTrabajadorAdicional", ex)
        Finally

        End Try
        ObtenerTrabajadorAdicional = dt
    End Function

    Public Function ExisteAfiliacion(ByVal sCodigoTrabajador As String) As Boolean
        Dim sqlParametroMDB As OleDbParameter
        'Dim conexionMDB As New OleDbConnection(Empresa_Sistema.oSisEmpresaNomina.CONEXION_SUA_EVENTUALES)
        Dim oTrabajadores As New Class_CatTrabajadores
        oTrabajadores = New Class_CatTrabajadores(sCodigoTrabajador)

        Dim cmdMDB As New OleDbDataAdapter("SELECT 1 FROM AFILIACION WHERE REG_PATR=" & "@REG_PATR" & " AND NUM_AFIL=" & "@NUM_AFIL" & "", Me._conexionMDB)
        Try
            Me._conexionMDB.Open()

            With cmdMDB.SelectCommand
                sqlParametroMDB = .Parameters.Add("@REG_PATR", OleDbType.VarWChar) : sqlParametroMDB.Value = Plaza.oSisPlazaNomina.NOMINA_NUMERO_REGISTRO_PATRONAL.ToString
                sqlParametroMDB = .Parameters.Add("@NUM_AFIL", OleDbType.VarWChar) : sqlParametroMDB.Value = oTrabajadores.NUMERO_REGISTRO_IMSS.ToString

                .ExecuteNonQuery()
            End With

            Dim tabla As New DataTable
            cmdMDB.Fill(tabla)
            cmdMDB.Dispose()

            If tabla.Rows.Count > 0 Then
                Me._conexionMDB.Close()
                ExisteAfiliacion = True
                Exit Function
            End If

            Me._conexionMDB.Close()
            'conexionMDB.Dispose()

            ExisteAfiliacion = False
        Catch ex As Exception
            HandleError(Me.NombreClase, "ExisteAfiliacion", ex)
        End Try
    End Function

    Public Function ExisteAsegura(ByVal sCodigoTrabajador As String) As Boolean
        Dim sqlParametroMDB As OleDbParameter
        'Dim conexionMDB As New OleDbConnection(Empresa_Sistema.oSisEmpresaNomina.CONEXION_SUA_EVENTUALES)
        Dim oTrabajadores As New Class_CatTrabajadores
        oTrabajadores = New Class_CatTrabajadores(sCodigoTrabajador)

        Dim cmdMDB As New OleDbDataAdapter("SELECT 1 FROM ASEGURA WHERE REG_PATR=@REG_PATR AND NUM_AFIL=@NUM_AFIL ", Me._conexionMDB)
        Try
            Me._conexionMDB.Open()

            'cmdMDB.Parameters.Clear()
            With cmdMDB.SelectCommand
                sqlParametroMDB = .Parameters.Add("@REG_PATR", OleDbType.VarWChar) : sqlParametroMDB.Value = Plaza.oSisPlazaNomina.NOMINA_NUMERO_REGISTRO_PATRONAL.ToString
                sqlParametroMDB = .Parameters.Add("@NUM_AFIL", OleDbType.VarWChar) : sqlParametroMDB.Value = oTrabajadores.NUMERO_REGISTRO_IMSS.ToString

                .ExecuteNonQuery()
            End With

            Dim tabla As New DataTable
            cmdMDB.Fill(tabla)
            cmdMDB.Dispose()

            If tabla.Rows.Count > 0 Then
                Me._conexionMDB.Close()
                ExisteAsegura = True
                Exit Function
            End If

            Me._conexionMDB.Close()
            'conexionMDB.Dispose()

            ExisteAsegura = False
        Catch ex As Exception
            HandleError(Me.NombreClase, "ExisteAsegura", ex)
        End Try
    End Function

    Public Function ExisteMovimiento(ByVal sCodigoTrabajador As String, ByVal sFechaAlta As String, ByVal sTipoMovimiento As String) As Boolean
        Dim sqlParametroMDB As OleDbParameter
        'Dim conexionMDB As New OleDbConnection(Empresa_Sistema.oSisEmpresaNomina.CONEXION_SUA_EVENTUALES)
        Dim oTrabajadores As New Class_CatTrabajadores
        oTrabajadores = New Class_CatTrabajadores(sCodigoTrabajador)

        Dim cmdMDB As New OleDbDataAdapter("SELECT 1 FROM MOVTOS WHERE REG_PATR=@REG_PATR AND NUM_AFIL=@NUM_AFIL AND FEC_INIC=@FEC_INIC AND TIP_MOVS=@TIP_MOVS", Me._conexionMDB)
        Try
            Me._conexionMDB.Open()

            'cmdMDB.Parameters.Clear()
            With cmdMDB.SelectCommand
                sqlParametroMDB = .Parameters.Add("@REG_PATR", OleDbType.VarWChar) : sqlParametroMDB.Value = Plaza.oSisPlazaNomina.NOMINA_NUMERO_REGISTRO_PATRONAL.ToString
                sqlParametroMDB = .Parameters.Add("@NUM_AFIL", OleDbType.VarWChar) : sqlParametroMDB.Value = oTrabajadores.NUMERO_REGISTRO_IMSS.ToString
                sqlParametroMDB = .Parameters.Add("@FEC_INIC", OleDbType.DBDate) : sqlParametroMDB.Value = CDate(Format(CDate(sFechaAlta), "dd/MM/yyyy"))
                sqlParametroMDB = .Parameters.Add("@TIP_MOVS", OleDbType.VarWChar) : sqlParametroMDB.Value = sTipoMovimiento 'IIf(Me.cboTxtArchivos.SelectedValue.ToString = "ALTA", "08", "02")
                .ExecuteNonQuery()
            End With

            Dim tabla As New DataTable
            cmdMDB.Fill(tabla)
            cmdMDB.Dispose()

            If tabla.Rows.Count > 0 Then
                Me._conexionMDB.Close()
                ExisteMovimiento = True
                Exit Function
            End If

            Me._conexionMDB.Close()
            'Me._conexionMDB.Dispose()

            ExisteMovimiento = False
        Catch ex As Exception
            HandleError(Me.NombreClase, "ExisteMovimiento", ex)
        End Try
    End Function

    Public Function IntegraAfiliacion(ByVal sCodigoTrabajador As String) As Boolean
        Dim sqlParametroMDB As OleDbParameter
        'Dim conexionMDB As New OleDbConnection(Empresa_Sistema.oSisEmpresaNomina.CONEXION_SUA_EVENTUALES)
        Dim oTrabajadores As New Class_CatTrabajadores
        oTrabajadores = New Class_CatTrabajadores(sCodigoTrabajador)

        Dim cmdMDB As New OleDbCommand("INSERT INTO AFILIACION(REG_PATR,NUM_AFIL,CPP_TRAB,FEC_NAC,LUG_NAC,ENT_TRAB,UMF_TRAB,OCUPA,SEXO,TIP_SAL,CVE_MUN) " & _
                                       "VALUES(@REG_PATR,@NUM_AFIL,@CPP_TRAB,@FEC_NAC,@LUG_NAC,@ENT_TRAB,@UMF_TRAB,@OCUPA,@SEXO,@TIP_SAL,@CVE_MUN)", Me._conexionMDB)
        Try
            Me._conexionMDB.Open()

            'cmdMDB.Parameters.Clear()
            With cmdMDB
                sqlParametroMDB = .Parameters.Add("@REG_PATR", OleDbType.VarWChar) : sqlParametroMDB.Value = Plaza.oSisPlazaNomina.NOMINA_NUMERO_REGISTRO_PATRONAL.ToString
                sqlParametroMDB = .Parameters.Add("@NUM_AFIL", OleDbType.VarWChar) : sqlParametroMDB.Value = oTrabajadores.NUMERO_REGISTRO_IMSS.ToString
                sqlParametroMDB = .Parameters.Add("@CPP_TRAB", OleDbType.VarWChar) : sqlParametroMDB.Value = "80000"
                sqlParametroMDB = .Parameters.Add("@FEC_NAC", OleDbType.DBDate) : sqlParametroMDB.Value = CDate(Format(oTrabajadores.FECHA_NACIMIENTO, "dd/MM/yyyy"))
                Dim sql As New Class_find("SELECT CODIGO_ESTADO_NUMERICO,NOMBRE_ESTADO_SUA FROM SIS_ESTADOS WHERE CODIGO_ESTADO='" & oTrabajadores.CODIGO_ESTADO_NACIMIENTO.ToString & "'")
                sqlParametroMDB = .Parameters.Add("@LUG_NAC", OleDbType.VarWChar) : sqlParametroMDB.Value = sql.Result2.ToString
                'sqlParametroMDB = .Parameters.Add("@ENT_TRAB", OleDbType.VarWChar) : sqlParametroMDB.Value = oTrabajadores.CODIGO_ESTADO_NACIMIENTO.ToString
                sqlParametroMDB = .Parameters.Add("@ENT_TRAB", OleDbType.VarWChar) : sqlParametroMDB.Value = CInt(oTrabajadores.CODIGO_ESTADO_NACIMIENTO_NUMERICO.ToString)
                sqlParametroMDB = .Parameters.Add("@UMF_TRAB", OleDbType.VarWChar) : sqlParametroMDB.Value = oTrabajadores.CODIGO_UNIDAD_MEDICA_FAMILIAR.ToString
                sqlParametroMDB = .Parameters.Add("@OCUPA", OleDbType.VarWChar) : sqlParametroMDB.Value = "JORNALERO"
                sqlParametroMDB = .Parameters.Add("@SEXO", OleDbType.VarWChar) : sqlParametroMDB.Value = oTrabajadores.CODIGO_SEXO_SUA.ToString
                sqlParametroMDB = .Parameters.Add("@TIP_SAL", OleDbType.VarWChar) : sqlParametroMDB.Value = "0"
                sqlParametroMDB = .Parameters.Add("@CVE_MUN", OleDbType.VarWChar) : sqlParametroMDB.Value = Mid(Plaza.oSisPlazaNomina.NOMINA_NUMERO_REGISTRO_PATRONAL.ToString, 1, 3)
                ', los 3 primeros caracteres del numeroRegPatronal
                .ExecuteNonQuery()
            End With

            Me._conexionMDB.Close()

            IntegraAfiliacion = True
        Catch ex As Exception
            HandleError(Me.NombreClase, "IntegraAfiliacion", ex)
        End Try
    End Function

    Public Function IntegraAsegura(ByVal sCodigoTrabajador As String, ByVal sFecha As String) As Boolean
        Dim sqlParametroMDB As OleDbParameter
        'Dim conexionMDB As New OleDbConnection(Empresa_Sistema.oSisEmpresaNomina.CONEXION_SUA_EVENTUALES)
        Dim oTrabajadores As New Class_CatTrabajadores
        oTrabajadores = New Class_CatTrabajadores(sCodigoTrabajador)

        Dim cmdMDB As New OleDbCommand("INSERT INTO ASEGURA(REG_PATR,NUM_AFIL,CURP,RFC_CURP,NOM_ASEG,SAL_IMSS,FEC_ALT,TIP_TRA,SEM_JORD,VAL_DSC,CVE_UBC,TMP_NOM,TRA_PENIV,ESTADO,STATUS,NUMTRA,PUNTOPAGO) " & _
                                       "VALUES(@REG_PATR,@NUM_AFIL,@CURP,@RFC_CURP,@NOM_ASEG,@SAL_IMSS,@FEC_ALT,@TIP_TRA,@SEM_JORD,@VAL_DSC,@CVE_UBC,@TMP_NOM,@TRA_PENIV,@ESTADO,@STATUS,@NUMTRA,@PUNTOPAGO)", Me._conexionMDB)
        Try
            Me._conexionMDB.Open()

            'cmdMDB.Parameters.Clear()
            With cmdMDB
                sqlParametroMDB = .Parameters.Add("@REG_PATR", OleDbType.VarWChar) : sqlParametroMDB.Value = Plaza.oSisPlazaNomina.NOMINA_NUMERO_REGISTRO_PATRONAL.ToString
                sqlParametroMDB = .Parameters.Add("@NUM_AFIL", OleDbType.VarWChar) : sqlParametroMDB.Value = oTrabajadores.NUMERO_REGISTRO_IMSS.ToString
                sqlParametroMDB = .Parameters.Add("@CURP", OleDbType.VarWChar) : sqlParametroMDB.Value = oTrabajadores.CURP.ToString
                sqlParametroMDB = .Parameters.Add("@RFC_CURP", OleDbType.VarWChar) : sqlParametroMDB.Value = oTrabajadores.RFC.ToString
                sqlParametroMDB = .Parameters.Add("@NOM_ASEG", OleDbType.VarWChar) : sqlParametroMDB.Value = Trim(oTrabajadores.APELLIDO_PATERNO) + "$" + Trim(oTrabajadores.APELLIDO_MATERNO) + "$" + Trim(oTrabajadores.NOMBRE_TRABAJADOR)
                sqlParametroMDB = .Parameters.Add("@SAL_IMSS", OleDbType.Decimal) : sqlParametroMDB.Value = Plaza.oSisPlazaNomina.NOMINA_SUELDO_DIARIO
                sqlParametroMDB = .Parameters.Add("@FEC_ALT", OleDbType.DBDate) : sqlParametroMDB.Value = CDate(Format(CDate(sFecha), "dd/MM/yyyy"))
                sqlParametroMDB = .Parameters.Add("@TIP_TRA", OleDbType.VarWChar) : sqlParametroMDB.Value = "4"
                sqlParametroMDB = .Parameters.Add("@SEM_JORD", OleDbType.VarWChar) : sqlParametroMDB.Value = "0"
                sqlParametroMDB = .Parameters.Add("@VAL_DSC", OleDbType.Decimal) : sqlParametroMDB.Value = 0
                sqlParametroMDB = .Parameters.Add("@CVE_UBC", OleDbType.VarWChar) : sqlParametroMDB.Value = "I0224554"
                sqlParametroMDB = .Parameters.Add("@TMP_NOM", OleDbType.VarWChar) : sqlParametroMDB.Value = Trim(oTrabajadores.APELLIDO_PATERNO) + " " + Trim(oTrabajadores.APELLIDO_MATERNO) + " " + Trim(oTrabajadores.NOMBRE_TRABAJADOR)
                sqlParametroMDB = .Parameters.Add("@TRA_PENIV", OleDbType.VarWChar) : sqlParametroMDB.Value = 0
                sqlParametroMDB = .Parameters.Add("@ESTADO", OleDbType.VarWChar) : sqlParametroMDB.Value = "S"
                sqlParametroMDB = .Parameters.Add("@STATUS", OleDbType.VarWChar) : sqlParametroMDB.Value = 8
                Dim kt16 As String = String.Format("{0,5}", oTrabajadores.CODIGO_TRABAJADOR.ToString)
                sqlParametroMDB = .Parameters.Add("@NUMTRA", OleDbType.VarWChar) : sqlParametroMDB.Value = kt16.Replace(" ", "0")
                sqlParametroMDB = .Parameters.Add("@PUNTOPAGO", OleDbType.SmallInt) : sqlParametroMDB.Value = 1
                .ExecuteNonQuery()
            End With

            Me._conexionMDB.Close()

            IntegraAsegura = True

        Catch ex As Exception
            HandleError(Me.NombreClase, "IntegraAsegura", ex)
        End Try
    End Function

    Public Function IntegraAseguraFechaBaja(ByVal sCodigoTrabajador As String, ByVal sFechaBaja As String) As Boolean
        Dim sqlParametroMDB As OleDbParameter
        'Dim conexionMDB As New OleDbConnection(Empresa_Sistema.oSisEmpresaNomina.CONEXION_SUA_EVENTUALES)
        Dim oTrabajadores As New Class_CatTrabajadores
        oTrabajadores = New Class_CatTrabajadores(sCodigoTrabajador)

        If sFechaBaja <> "" Then
            sFechaBaja = Format(CDate(sFechaBaja), "dd/MM/yyyy")
        End If

        Dim cmdMDB As New OleDbCommand("UPDATE ASEGURA SET FEC_BAJ=@FEC_BAJ WHERE NUM_AFIL=@NUM_AFIL AND REG_PATR=@REG_PATR ", Me._conexionMDB)
        Try
            Me._conexionMDB.Open()

            'cmdMDB.Parameters.Clear()
            With cmdMDB
                sqlParametroMDB = .Parameters.Add("@REG_PATR", OleDbType.VarWChar) : sqlParametroMDB.Value = Plaza.oSisPlazaNomina.NOMINA_NUMERO_REGISTRO_PATRONAL.ToString
                sqlParametroMDB = .Parameters.Add("@NUM_AFIL", OleDbType.VarWChar) : sqlParametroMDB.Value = oTrabajadores.NUMERO_REGISTRO_IMSS.ToString
                sqlParametroMDB = .Parameters.Add("@FEC_BAJ", OleDbType.VarWChar) : sqlParametroMDB.Value = sFechaBaja

                .ExecuteNonQuery()
            End With

            Me._conexionMDB.Close()

            IntegraAseguraFechaBaja = True
        Catch ex As Exception
            HandleError(Me.NombreClase, "IntegraAseguraFechaBaja", ex)
        End Try
    End Function

    Public Function IntegraMovimientoBaja(ByVal sCodigoTrabajador As String, ByVal sFechaAlta As String) As Boolean
        Dim sqlParametroMDB As OleDbParameter
        'Dim conexionMDB As New OleDbConnection(Empresa_Sistema.oSisEmpresaNomina.CONEXION_SUA_EVENTUALES)
        Dim oTrabajadores As New Class_CatTrabajadores
        oTrabajadores = New Class_CatTrabajadores(sCodigoTrabajador)

        Dim cmdMDB As New OleDbCommand("INSERT INTO MOVTOS(REG_PATR,NUM_AFIL,TIP_MOVS,FEC_INIC,CON_SEC,SAL_MOVT," & _
                                       "CVE_MOVS,TIP_INC,EDO_MOV,ART_33,Status,NOMBRE,ORDEN,FEC_OPE) " & _
                                       "VALUES(@REG_PATR,@NUM_AFIL,@TIP_MOVS,@FEC_INIC,@CON_SEC,@SAL_MOVT, " & _
                                       "@CVE_MOVS,@TIP_INC,@EDO_MOV,@ART_33,@Status,@NOMBRE,@ORDEN,@FEC_OPE) ", Me._conexionMDB)
        Try
            Me._conexionMDB.Open()

            'cmdMDB.Parameters.Clear()
            With cmdMDB
                sqlParametroMDB = .Parameters.Add("@REG_PATR", OleDbType.VarWChar) : sqlParametroMDB.Value = Plaza.oSisPlazaNomina.NOMINA_NUMERO_REGISTRO_PATRONAL.ToString
                sqlParametroMDB = .Parameters.Add("@NUM_AFIL", OleDbType.VarWChar) : sqlParametroMDB.Value = oTrabajadores.NUMERO_REGISTRO_IMSS.ToString
                sqlParametroMDB = .Parameters.Add("@TIP_MOVS", OleDbType.VarWChar) : sqlParametroMDB.Value = "02"
                sqlParametroMDB = .Parameters.Add("@FEC_INIC", OleDbType.DBDate) : sqlParametroMDB.Value = CDate(Format(CDate(sFechaAlta), "dd/MM/yyyy"))
                sqlParametroMDB = .Parameters.Add("@CON_SEC", OleDbType.VarWChar) : sqlParametroMDB.Value = " "
                sqlParametroMDB = .Parameters.Add("@SAL_MOVT", OleDbType.Decimal) : sqlParametroMDB.Value = 0 'Empresa_Sistema.oSisEmpresaNomina.NOMINA_SUELDO_DIARIO
                sqlParametroMDB = .Parameters.Add("@CVE_MOVS", OleDbType.VarWChar) : sqlParametroMDB.Value = "B"
                sqlParametroMDB = .Parameters.Add("@TIP_INC", OleDbType.VarWChar) : sqlParametroMDB.Value = 1
                sqlParametroMDB = .Parameters.Add("@EDO_MOV", OleDbType.VarWChar) : sqlParametroMDB.Value = "0"
                sqlParametroMDB = .Parameters.Add("@ART_33", OleDbType.VarWChar) : sqlParametroMDB.Value = "N"
                sqlParametroMDB = .Parameters.Add("@Status", OleDbType.SmallInt) : sqlParametroMDB.Value = 2
                sqlParametroMDB = .Parameters.Add("@NOMBRE", OleDbType.VarWChar) : sqlParametroMDB.Value = Trim(oTrabajadores.APELLIDO_PATERNO) + " " + Trim(oTrabajadores.APELLIDO_MATERNO) + " " + Trim(oTrabajadores.NOMBRE_TRABAJADOR)
                sqlParametroMDB = .Parameters.Add("@ORDEN", OleDbType.SmallInt) : sqlParametroMDB.Value = 2
                sqlParametroMDB = .Parameters.Add("@FEC_OPE", OleDbType.DBDate) : sqlParametroMDB.Value = CDate(Format(Now(), "dd/MM/yyyy"))

                .ExecuteNonQuery()
            End With

            Me._conexionMDB.Close()
            'Me._conexionMDB.Dispose()

            IntegraMovimientoBaja = True
        Catch ex As Exception
            HandleError(Me.NombreClase, "IntegraMovimientoBaja", ex)
        End Try
    End Function

    Public Function IntegraMovimientoAlta(ByVal sCodigoTrabajador As String, ByVal sFechaAlta As String, ByVal iSemana As Integer) As Boolean
        Dim sqlParametroMDB As OleDbParameter
        'Dim conexionMDB As New OleDbConnection(Empresa_Sistema.oSisEmpresaNomina.CONEXION_SUA_EVENTUALES)
        Dim oTrabajadores As New Class_CatTrabajadores
        oTrabajadores = New Class_CatTrabajadores(sCodigoTrabajador)

        'Dim cmdMDB As New OleDbCommand("INSERT INTO NOMBRES_(NOMBRE) VALUES(@NOMBRE)", conexionMDB) NUM_AFIL=#RegistroImss, TIP_MOVS=CodigoMovimiento,FEC_INIC=Fecha
        Dim cmdMDB As New OleDbCommand("INSERT INTO MOVTOS(REG_PATR,NUM_AFIL,TIP_MOVS,FEC_INIC,CON_SEC,NUM_DIAS,SAL_MOVT,SAL_MOVT2,SAL_MOVT3," & _
                                       "CVE_MOVS,EDO_MOV,ART_33,Status,NOMBRE,ORDEN,FEC_OPE,PUNTOPAGO,NUMTRA,SEMANA) " & _
                                       "VALUES(@REG_PATR,@NUM_AFIL,@TIP_MOVS,@FEC_INIC,@CON_SEC,@NUM_DIAS,@SAL_MOVT,@SAL_MOVT2,@SAL_MOVT3, " & _
                                       "@CVE_MOVS,@EDO_MOV,@ART_33,@Status,@NOMBRE,@ORDEN,@FEC_OPE,@PUNTOPAGO,@NUMTRA,@SEMANA) ", Me._conexionMDB)
        '"WHERE NUM_AFIL = '" & oTrabajadores.NUMERO_REGISTRO_IMSS.ToString & "' AND FEC_INIC = #" & Format(CDate("2012-08-16"), "mm/dd/YYYY") & "# AND TIP_MOVS = '" & "08" & "'  "

        Try
            Me._conexionMDB.Open()

            'cmdMDB.Parameters.Clear()
            With cmdMDB

                sqlParametroMDB = .Parameters.Add("@REG_PATR", OleDbType.VarWChar) : sqlParametroMDB.Value = Plaza.oSisPlazaNomina.NOMINA_NUMERO_REGISTRO_PATRONAL.ToString
                sqlParametroMDB = .Parameters.Add("@NUM_AFIL", OleDbType.VarWChar) : sqlParametroMDB.Value = oTrabajadores.NUMERO_REGISTRO_IMSS.ToString
                sqlParametroMDB = .Parameters.Add("@TIP_MOVS", OleDbType.VarWChar) : sqlParametroMDB.Value = "08"
                sqlParametroMDB = .Parameters.Add("@FEC_INIC", OleDbType.DBDate) : sqlParametroMDB.Value = CDate(Format(CDate(sFechaAlta), "dd/MM/yyyy"))
                sqlParametroMDB = .Parameters.Add("@CON_SEC", OleDbType.VarWChar) : sqlParametroMDB.Value = " "
                sqlParametroMDB = .Parameters.Add("@NUM_DIAS", OleDbType.SmallInt) : sqlParametroMDB.Value = 0
                sqlParametroMDB = .Parameters.Add("@SAL_MOVT", OleDbType.Decimal) : sqlParametroMDB.Value = Plaza.oSisPlazaNomina.NOMINA_SUELDO_DIARIO
                sqlParametroMDB = .Parameters.Add("@SAL_MOVT2", OleDbType.Decimal) : sqlParametroMDB.Value = 0
                sqlParametroMDB = .Parameters.Add("@SAL_MOVT3", OleDbType.Decimal) : sqlParametroMDB.Value = 0
                sqlParametroMDB = .Parameters.Add("@CVE_MOVS", OleDbType.VarWChar) : sqlParametroMDB.Value = "H"
                sqlParametroMDB = .Parameters.Add("@EDO_MOV", OleDbType.VarWChar) : sqlParametroMDB.Value = "0"
                sqlParametroMDB = .Parameters.Add("@ART_33", OleDbType.VarWChar) : sqlParametroMDB.Value = "N"
                sqlParametroMDB = .Parameters.Add("@Status", OleDbType.SmallInt) : sqlParametroMDB.Value = 8
                sqlParametroMDB = .Parameters.Add("@NOMBRE", OleDbType.VarWChar) : sqlParametroMDB.Value = Trim(oTrabajadores.APELLIDO_PATERNO) + " " + Trim(oTrabajadores.APELLIDO_MATERNO) + " " + Trim(oTrabajadores.NOMBRE_TRABAJADOR)
                sqlParametroMDB = .Parameters.Add("@ORDEN", OleDbType.SmallInt) : sqlParametroMDB.Value = 1
                sqlParametroMDB = .Parameters.Add("@FEC_OPE", OleDbType.DBDate) : sqlParametroMDB.Value = CDate(Format(Now(), "dd/MM/yyyy"))
                sqlParametroMDB = .Parameters.Add("@PUNTOPAGO", OleDbType.SmallInt) : sqlParametroMDB.Value = 1
                Dim kt16 As String = String.Format("{0,5}", oTrabajadores.CODIGO_TRABAJADOR.ToString)
                sqlParametroMDB = .Parameters.Add("@NUMTRA", OleDbType.VarWChar) : sqlParametroMDB.Value = kt16.Replace(" ", "0")
                sqlParametroMDB = .Parameters.Add("@SEMANA", OleDbType.SmallInt) : sqlParametroMDB.Value = iSemana 'CInt(Me.CboSemana.Text)
                .ExecuteNonQuery()
            End With

            Me._conexionMDB.Close()
            'conexionMDB.Dispose()

            IntegraMovimientoAlta = True
        Catch ex As Exception
            HandleError(Me.NombreClase, "IntegraMovimientoAlta", ex)
        End Try
    End Function

    Public Function GrabarMovimiento(ByVal sCodigoTrabajador As String, ByVal sTipoMovimiento As String, ByVal sFechaActual As String, ByVal sFechaMovimiento As String, ByVal dSueldo As Double) As Boolean
        Dim sqlParametroMDB As OleDbParameter
        Dim oTrabajadores As New Class_CatTrabajadores
        oTrabajadores = New Class_CatTrabajadores(sCodigoTrabajador)

        Dim cmdMDB As New OleDbCommand("UPDATE MOVTOS SET FEC_INIC=@FEC_INIC,SAL_MOVT=@SAL_MOVT WHERE NUM_AFIL='" & oTrabajadores.NUMERO_REGISTRO_IMSS.ToString & "' AND TIP_MOVS='" & sTipoMovimiento.ToString & "' AND FEC_INIC=#" & sFechaActual & "#", Me._conexionMDB)

        Try
            Me._conexionMDB.Open()

            With cmdMDB
                sqlParametroMDB = .Parameters.Add("@FEC_INIC", OleDbType.DBDate) : sqlParametroMDB.Value = sFechaMovimiento
                sqlParametroMDB = .Parameters.Add("@SAL_MOVT", OleDbType.Decimal) : sqlParametroMDB.Value = dSueldo
                .ExecuteNonQuery()
            End With

            Me._conexionMDB.Close()

            GrabarMovimiento = True
        Catch ex As Exception
            HandleError(Me.NombreClase, "GrabarMovimiento", ex)
        End Try
    End Function

    Public Function EliminarMovimiento(ByVal sCodigoTrabajador As String, ByVal sTipoMovimiento As String, ByVal sFechaMovimiento As String, ByVal dSueldo As Double) As Boolean
        'Dim sqlParametroMDB As OleDbParameter
        Dim oTrabajadores As New Class_CatTrabajadores
        oTrabajadores = New Class_CatTrabajadores(sCodigoTrabajador)

        Dim cmdMDB As New OleDbCommand("DELETE FROM MOVTOS WHERE NUM_AFIL='" & oTrabajadores.NUMERO_REGISTRO_IMSS.ToString & "' AND TIP_MOVS='" & sTipoMovimiento.ToString & "' AND FEC_INIC=#" & Format(CDate(sFechaMovimiento), "dd-MM-yyyy").ToString & "#", Me._conexionMDB)
        Try
            Me._conexionMDB.Open()

            With cmdMDB
                .ExecuteNonQuery()
            End With

            Me._conexionMDB.Close()
            'conexionMDB.Dispose()

            EliminarMovimiento = True
        Catch ex As Exception
            HandleError(Me.NombreClase, "EliminarMovimiento", ex)
        End Try
    End Function

    Public Function ObtenerTrabajadoresSinIMSS() As DataTable
        Dim dTabla As New DataTable("detalle"), da As SqlDataAdapter
        Dim sSQL As String

        sSQL = "select T.CODIGO_TRABAJADOR,T.NOMBRE_TRABAJADOR,APELLIDO_PATERNO,APELLIDO_MATERNO,NOMBRE_SEXO,ISNULL(Convert(varchar(10),FECHA_NACIMIENTO, 103),'')  FECHA_NACIMIENTO,NOMBRE_ESTADO,AFILIABLE_IMSS " & _
               "from VW_NOMINA_CAT_TRABAJADORES_EXTENDIDA T RIGHT JOIN NOMINA_GENERADA_TRABAJADORES G ON(T.CODIGO_TRABAJADOR=G.CODIGO_TRABAJADOR) " & _
               "INNER JOIN NOMINA_SEMANA S ON (G.ID_NOMINA_SEMANA=S.ID_NOMINA_SEMANA) " & _
               "where NUMERO_REGISTRO_IMSS='' AND S.ID_NOMINA_TEMPORADA=" & Plaza.oSisPlazaNomina.NOMINA_ID_NOMINA_TEMPORADA_ACTIVA & " AND S.NUMERO_SEMANA>=1 " & _
               "AND T.CODIGO_PUNTO_PAGO NOT IN (4,6,999) " & _
               "GROUP BY T.CODIGO_TRABAJADOR,T.NOMBRE_TRABAJADOR,APELLIDO_PATERNO,APELLIDO_MATERNO,NOMBRE_SEXO,FECHA_NACIMIENTO,NOMBRE_ESTADO,AFILIABLE_IMSS "
        Try
            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dTabla)
            da.Dispose()

        Catch ex As Exception
            HandleError(Me.NombreClase, "ObtenerTrabajadoresSinIMSS", ex)
        End Try
        ObtenerTrabajadoresSinIMSS = dTabla
    End Function

End Class
