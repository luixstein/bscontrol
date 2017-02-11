Option Strict On
Option Explicit On

Imports System.Data.OleDb

Public Class Frm_Nomina_EdicionSUA
    Private igyNumRegistroIMSS As Short = 1
    Private igyCodigoTrabajador As Short = 2
    Private igyApellidoPaterno As Short = 3
    Private igyApellidoMaterno As Short = 4
    Private igyNombreTrabajador As Short = 5

    Private igyMovimientoNumRegistroIMSS As Short = 1
    Private igyMovimientoFecha As Short = 2
    Private igyMovimientoCodigoMovimiento As Short = 3
    Private igyMovimientoMovimiento As Short = 4
    Private igyMovimientoSueldoDI As Short = 5

    Private igyMovimientoTrabajadorFecha As Short = 1
    Private igyMovimientoTrabajadorMovimiento As Short = 2

    Private sCodigoTrabajador As String = ""
    Private sFechaMovimiento As String = ""

    Private Enum enumEstados
        NUEVO
        EDICION
        CONSULTA
    End Enum

    Private Estado As enumEstados
#Region "Opciones"

#End Region
#Region "Eventos de objetos"
#Region "Eventos"

    Private Sub Frm_Nomina_EdicionSUA_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Inicializa()
        Me.LlenaComboMovimientos()
    End Sub

    Private Sub btnFiltrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFiltrar.Click
        Me.Consultar()
    End Sub

    Private Sub btnBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrar.Click
        Me.txtNumeroIMSS.Text = ""
        Me.txtCodigoTrabajador.Text = ""
        Me.txtApellidoPaterno.Text = ""
        Me.txtApellidoMaterno.Text = ""
        Me.txtNombre.Text = ""
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If Me.GestionaGrabar() = True Then
            MsgBox("Movimiento grabado satisfactoriamente.", MsgBoxStyle.Information, Me.Text)
            Me.ConsultarMovimientos(sCodigoTrabajador)
        End If
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If Me.Eliminar() = True Then
            MsgBox("Movimiento eliminado satisfactoriamente.", MsgBoxStyle.Information, Me.Text)
            Me.ConsultarMovimientos(sCodigoTrabajador)
        End If
    End Sub
#End Region

#Region "Eventos Genericos"
    Private Sub txtTextoKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtApellidoPaterno.KeyPress, txtApellidoMaterno.KeyPress, txtNombre.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub txtNumerosEnterosKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumeroIMSS.KeyPress, txtCodigoTrabajador.KeyPress
        txtSoloNumerosEnteros(e)
        txtNoBeep(e)
    End Sub

    Private Sub txtNumerosDecimalKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSueldoDI.KeyPress
        Dim txt As TextBox = CType(sender, TextBox)
        txtSoloNumerosDecimales(e, txt.Text)
        txtNoBeep(e)
    End Sub

        Private Sub Cbo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtApellidoPaterno.KeyDown, txtApellidoMaterno.KeyDown, txtNombre.KeyDown, txtNumeroIMSS.KeyDown, txtCodigoTrabajador.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.Send("{TAB}")
                If txtLEN(Me.txtNumeroIMSS.Text) = True Or txtLEN(Me.txtCodigoTrabajador.Text) = True Or txtLEN(Me.txtApellidoPaterno.Text) = True Or txtLEN(Me.txtApellidoMaterno.Text) = True Or txtLEN(Me.txtNombre.Text) = True Then
                    Me.Consultar()
                End If
        End Select
    End Sub
#End Region

#Region "Keydown específicos"

    Private Sub GridTrabajadores_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridTrabajadores.Click
        Dim Columna As Integer, Renglon As Integer, vdg As String
        sCodigoTrabajador = ""

        Columna = Me.GridTrabajadores.Selection.FirstCol
        Renglon = Me.GridTrabajadores.Selection.FirstRow
        sFechaMovimiento = ""

        vdg = Me.GridTrabajadores.Cell(Renglon, Me.igyNumRegistroIMSS).Text
        sCodigoTrabajador = Me.GridTrabajadores.Cell(Renglon, Me.igyCodigoTrabajador).Text
        If txtLEN(vdg) = False Then
            Exit Sub
        End If

        Me.ConsultarMovimientos(sCodigoTrabajador, vdg)

        Me.ConsultarMovimientosAgrinet(sCodigoTrabajador, vdg)
    End Sub

    Private Sub GridMovimientos_Click(ByVal Sender As Object, ByVal e As System.EventArgs) Handles GridMovimientos.Click
        Dim Columna As Integer, Renglon As Integer, vdg As String

        Columna = Me.GridMovimientos.Selection.FirstCol
        Renglon = Me.GridMovimientos.Selection.FirstRow

        If Renglon < 1 Then
            Exit Sub
        End If

        vdg = Me.GridMovimientos.Cell(Renglon, Me.igyMovimientoNumRegistroIMSS).Text
        If txtLEN(vdg) = False Then
            Exit Sub
        End If

        sFechaMovimiento = CDate(Me.GridMovimientos.Cell(Renglon, Me.igyMovimientoFecha).Text).ToString
        Me.DtpFecha1.Value = CDate(Me.GridMovimientos.Cell(Renglon, Me.igyMovimientoFecha).Text)
        'Me.txtCodigoMovimiento.Text = Me.GridMovimientos.Cell(Renglon, Me.igyMovimientoCodigoMovimiento).Text
        Me.cboMovimientos.Text = Me.GridMovimientos.Cell(Renglon, Me.igyMovimientoMovimiento).Text
        Me.txtSueldoDI.Text = Me.GridMovimientos.Cell(Renglon, Me.igyMovimientoSueldoDI).Text

        Me.Estado = enumEstados.EDICION
        Me.Cambia_Estado()

    End Sub

    Private Sub DtpFecha1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtpFecha1.KeyDown
         Select e.KeyCode
            Case Keys.Enter
                Me.txtSueldoDI.Focus()
        End Select
    End Sub

    Private Sub txtSueldoDI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSueldoDI.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.txtSueldoDI.Text = FormatImporteContable(CDbl(Me.txtSueldoDI.Text))
            SendKeys.Send("{TAB}")
        End If
    End Sub
#End Region
#End Region

#Region "Métodos y procedimientos"
    Private Sub Inicializa()
        Try
            Me.DtpFecha1.Value = Date.Now

            Me.txtNumeroIMSS.Text = ""
            Me.txtCodigoTrabajador.Text = ""
            Me.txtNumeroIMSS.Text = ""
            Me.txtApellidoPaterno.Text = ""
            Me.txtApellidoMaterno.Text = ""
            Me.txtNombre.Text = ""

            Me.InicializaGrid()
            Me.InicializaGridMovimientos()
        Catch ex As Exception
            HandleError(Me.Name, "Inicializa", ex)
        End Try
    End Sub

    Private Sub InicializaGrid()
        Me.GridTrabajadores.DataSource = Nothing
        FG_Grid_Limpiar(Me.GridTrabajadores)
        Me.GridTrabajadores.Rows = 2
        Me.GridTrabajadores.Cols = 6
        Me.FormateaGrid()
    End Sub

    Private Sub InicializaGridMovimientos()
        Me.GridMovimientos.DataSource = Nothing
        FG_Grid_Limpiar(Me.GridMovimientos)
        Me.GridMovimientos.Rows = 2
        Me.GridMovimientos.Cols = 6
        Me.FormateaGridMovimientos()

        Me.DtpFecha1.Value = Date.Now
        Me.txtSueldoDI.Text = ""
        Me.btnNuevo.Enabled = False
        Me.btnRegresar.Enabled = False
        Me.btnGrabar.Enabled = False
        Me.btnEliminar.Enabled = False
    End Sub

    Private Sub InicializaGridMovimientosTrabajor()
        Me.GridMovimientosTrabajador.DataSource = Nothing
        FG_Grid_Limpiar(Me.GridMovimientosTrabajador)
        Me.GridMovimientosTrabajador.Rows = 2
        Me.GridMovimientosTrabajador.Cols = 3
        Me.FormateaGridMovimientosTrabajor()
    End Sub

    Private Sub FormateaGrid()
        Me.GridTrabajadores.Column(Me.igyNumRegistroIMSS).Width = 90
        Me.GridTrabajadores.Column(Me.igyCodigoTrabajador).Width = 90
        Me.GridTrabajadores.Column(Me.igyApellidoPaterno).Width = 125
        Me.GridTrabajadores.Column(Me.igyApellidoMaterno).Width = 125
        Me.GridTrabajadores.Column(Me.igyNombreTrabajador).Width = 125

        Me.GridTrabajadores.Cell(0, Me.igyNumRegistroIMSS).Text = "# IMSS"
        Me.GridTrabajadores.Cell(0, Me.igyCodigoTrabajador).Text = "Cód. trabajador"
        Me.GridTrabajadores.Cell(0, Me.igyApellidoPaterno).Text = "Apellido paterno"
        Me.GridTrabajadores.Cell(0, Me.igyApellidoMaterno).Text = "Apellido materno"
        Me.GridTrabajadores.Cell(0, Me.igyNombreTrabajador).Text = "Nombre trabajador"

        Me.GridTrabajadores.Column(Me.igyCodigoTrabajador).Locked = True
        Me.GridTrabajadores.Column(Me.igyNombreTrabajador).Locked = True
        Me.GridTrabajadores.Column(Me.igyApellidoPaterno).Locked = True
        Me.GridTrabajadores.Column(Me.igyApellidoMaterno).Locked = True
        Me.GridTrabajadores.Column(Me.igyNumRegistroIMSS).Locked = True
    End Sub

    Private Sub FormateaGridMovimientos()
        Me.GridMovimientos.Column(Me.igyMovimientoNumRegistroIMSS).Width = 80
        Me.GridMovimientos.Column(Me.igyMovimientoFecha).Width = 100
        Me.GridMovimientos.Column(Me.igyMovimientoCodigoMovimiento).Width = 80
        Me.GridMovimientos.Column(Me.igyMovimientoMovimiento).Width = 100
        Me.GridMovimientos.Column(Me.igyMovimientoSueldoDI).Width = 100

        Me.GridMovimientos.Cell(0, Me.igyMovimientoNumRegistroIMSS).Text = "# IMSS"
        Me.GridMovimientos.Cell(0, Me.igyMovimientoFecha).Text = "Fecha"
        Me.GridMovimientos.Cell(0, Me.igyMovimientoCodigoMovimiento).Text = "Cód. mov."
        Me.GridMovimientos.Cell(0, Me.igyMovimientoMovimiento).Text = "Movimiento"
        Me.GridMovimientos.Cell(0, Me.igyMovimientoSueldoDI).Text = "Sueldo D.I."

        Me.GridMovimientos.Column(Me.igyMovimientoSueldoDI).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
        Me.GridMovimientos.Column(Me.igyMovimientoSueldoDI).Mask = FlexCell.MaskEnum.Numeric
        Me.GridMovimientos.Column(Me.igyMovimientoSueldoDI).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
        Me.GridMovimientos.Column(Me.igyMovimientoSueldoDI).Alignment = FlexCell.AlignmentEnum.RightCenter

        Me.GridMovimientos.Column(Me.igyMovimientoFecha).Alignment = FlexCell.AlignmentEnum.CenterCenter
        Me.GridMovimientos.Column(Me.igyMovimientoCodigoMovimiento).Alignment = FlexCell.AlignmentEnum.CenterCenter
        Me.GridMovimientos.Column(Me.igyMovimientoMovimiento).Alignment = FlexCell.AlignmentEnum.CenterCenter
        Me.GridMovimientos.Column(Me.igyMovimientoSueldoDI).Alignment = FlexCell.AlignmentEnum.RightCenter

        Me.GridMovimientos.Column(Me.igyMovimientoNumRegistroIMSS).Locked = True
        Me.GridMovimientos.Column(Me.igyMovimientoNumRegistroIMSS).Visible = False
        Me.GridMovimientos.Column(Me.igyMovimientoFecha).Locked = True
        Me.GridMovimientos.Column(Me.igyMovimientoCodigoMovimiento).Locked = True
        Me.GridMovimientos.Column(Me.igyMovimientoMovimiento).Locked = True
        Me.GridMovimientos.Column(Me.igyMovimientoSueldoDI).Locked = True

    End Sub

    Private Sub FormateaGridMovimientosTrabajor()
        Me.GridMovimientosTrabajador.Column(Me.igyMovimientoTrabajadorFecha).Width = 80
        Me.GridMovimientosTrabajador.Column(Me.igyMovimientoTrabajadorMovimiento).Width = 100

        Me.GridMovimientosTrabajador.Cell(0, Me.igyMovimientoTrabajadorFecha).Text = "Fecha"
        Me.GridMovimientosTrabajador.Cell(0, Me.igyMovimientoTrabajadorMovimiento).Text = "Movimiento"

        Me.GridMovimientosTrabajador.Column(Me.igyMovimientoTrabajadorFecha).Alignment = FlexCell.AlignmentEnum.CenterCenter
        Me.GridMovimientosTrabajador.Column(Me.igyMovimientoTrabajadorMovimiento).Alignment = FlexCell.AlignmentEnum.CenterCenter

        Me.GridMovimientosTrabajador.Column(Me.igyMovimientoTrabajadorFecha).Locked = True
        Me.GridMovimientosTrabajador.Column(Me.igyMovimientoTrabajadorMovimiento).Locked = True
    End Sub

    Private Function Consultar() As Boolean
        Dim oSUA As New Class_Nomina_SUA
        Dim dTabla As DataTable, tabla() As String
        Dim sFiltro As String = ""

        If txtLEN(Me.txtNumeroIMSS.Text) = True Then
            sFiltro = sFiltro & "AND NUM_AFIL LIKE '" & Me.txtNumeroIMSS.Text & "%' "
        End If

        If txtLEN(Me.txtCodigoTrabajador.Text) = True Then
            sFiltro = sFiltro & "AND NUMTRA LIKE '" & Me.txtCodigoTrabajador.Text & "%' "
        End If

        sFiltro = sFiltro & "AND NOM_ASEG LIKE '" & Me.txtApellidoPaterno.Text & "%$" & Me.txtApellidoMaterno.Text & "%$" & Me.txtNombre.Text & "%' "

        Try

            dTabla = oSUA.ObtenerTrabajadoresEventuales(sFiltro)

            Me.InicializaGridMovimientos()
            Me.FormateaGrid()
            'Me.InicializaGridMovimientosTrabajor()
            'Me.FormateaGridMovimientosTrabajor()

            Me.GridTrabajadores.Rows = 1
            For Each drow As DataRow In dTabla.Rows
                tabla = Split(drow(2).ToString, "$")
                Me.GridTrabajadores.AddItem(drow(0).ToString & Chr(9) & drow(1).ToString & Chr(9) & tabla(0) & Chr(9) & tabla(1) & Chr(9) & tabla(2))
            Next

            Consultar = True

            Me.Estado = enumEstados.CONSULTA
            Me.Cambia_Estado()

        Catch ex As Exception
            HandleError(Me.Name, "Consultar", ex)
        End Try
    End Function

    Private Sub Cambia_Estado()
        Select Case Me.Estado
            Case enumEstados.NUEVO
                'Me.tssLabelEstado.Text = "Agregando nuevo " & Me.msgElemento
                'Me.TxtCodigoChofer.Enabled = False
                'Me.TxtNombreChofer.Enabled = True

                Me.cboMovimientos.Enabled = True
                Me.btnNuevo.Enabled = False
                Me.btnRegresar.Enabled = True
                Me.btnGrabar.Enabled = True
                Me.btnEliminar.Enabled = False
                Me.txtSueldoDI.Enabled = True
                Me.DtpFecha1.Enabled = True

            Case enumEstados.EDICION
                'Me.gBoxInformacion.Enabled = True
                'Me.gBoxBusquedaRapida.Enabled = False
                'Me.tssLabelEstado.Text = "Edición"

                'Me.TxtCodigoChofer.Enabled = False
                'Me.TxtNombreChofer.Enabled = True
                'Me.CboEstatus.Enabled = True

                Me.cboMovimientos.Enabled = False
                Me.btnNuevo.Enabled = False
                Me.btnRegresar.Enabled = False
                Me.btnGrabar.Enabled = True
                Me.btnEliminar.Enabled = True
                Me.txtSueldoDI.Enabled = True
                Me.DtpFecha1.Enabled = True

            Case enumEstados.CONSULTA
                Me.cboMovimientos.Enabled = False
                Me.btnNuevo.Enabled = True
                Me.btnRegresar.Enabled = False
                Me.btnGrabar.Enabled = False
                Me.btnEliminar.Enabled = False
                Me.DtpFecha1.Value = Now
                Me.DtpFecha1.Enabled = False
                Me.txtSueldoDI.Enabled = False

        End Select
        Application.DoEvents()
    End Sub

    Private Function ConsultarMovimientos(ByVal sCodigoTrabajador As String, Optional ByVal sNumRegistroIMSS As String = "") As Boolean
        Dim oSUA As New Class_Nomina_SUA
        Dim dTabla As DataTable
        Try
            Dim oTrabajador As New Class_CatTrabajadores(sCodigoTrabajador, sNumRegistroIMSS)

            If txtLEN(oTrabajador.NUMERO_REGISTRO_IMSS) = False Then
                dTabla = oSUA.ObtenerTrabajadoresMovimientos(sNumRegistroIMSS)
            Else
                dTabla = oSUA.ObtenerTrabajadoresMovimientos(oTrabajador.NUMERO_REGISTRO_IMSS.ToString)
            End If

            Me.InicializaGridMovimientos()

            Me.GridMovimientos.Rows = 1
            For Each drow As DataRow In dTabla.Rows
                Me.GridMovimientos.AddItem(drow(0).ToString & Chr(9) & Format(CDate(drow(1).ToString), "dd-MMM-yy") & Chr(9) & drow(2).ToString & Chr(9) & drow(3).ToString & Chr(9) & drow(4).ToString)
            Next

            Me.Estado = enumEstados.CONSULTA
            Me.Cambia_Estado()
        Catch ex As Exception
            HandleError(Me.Name, "ConsultarMovimientos", ex)
        End Try
    End Function

    Private Function ConsultarMovimientosAgrinet(ByVal sCodigoTrabajador As String, Optional ByVal sNumRegistroIMSS As String = "") As Boolean
        Dim oMovimientoSUA As New Class_NominaMovimientoSua
        Dim dTabla As DataTable
        Try
            Dim oTrabajador As New Class_CatTrabajadores(sCodigoTrabajador, sNumRegistroIMSS)

            If txtLEN(oTrabajador.NUMERO_REGISTRO_IMSS) = False Then
                dTabla = oMovimientoSUA.ObtenerMovimientosTrabajador(oTrabajador.CODIGO_TRABAJADOR)
            Else
                dTabla = oMovimientoSUA.ObtenerMovimientosTrabajador(oTrabajador.CODIGO_TRABAJADOR)
            End If

            'Me.InicializaGridMovimientos()
            Me.InicializaGridMovimientosTrabajor()
            'Me.FormateaGridMovimientosTrabajor()

            Me.GridMovimientosTrabajador.Rows = 1
            For Each drow As DataRow In dTabla.Rows
                Me.GridMovimientosTrabajador.AddItem(Format(CDate(drow(0).ToString), "dd-MMM-yy") & Chr(9) & drow(1).ToString & Chr(9))
            Next

            Me.Estado = enumEstados.CONSULTA
            Me.Cambia_Estado()
        Catch ex As Exception
            HandleError(Me.Name, "ConsultarMovimientos", ex)
        End Try
    End Function

    Private Function GestionaGrabar() As Boolean
        If Me.Estado = enumEstados.NUEVO Then
            If Me.GestionaIntegracion() = True Then
                GestionaGrabar = True
            End If
        ElseIf Me.Estado = enumEstados.EDICION Then
            If Me.Grabar() = True Then
                GestionaGrabar = True
            End If
        End If
    End Function

    Private Function Grabar() As Boolean
        'Dim sqlParametroMDB As OleDbParameter
        'Dim conexionMDB As New OleDbConnection(Empresa_Sistema.oSisEmpresaNomina.CONEXION_SUA_EVENTUALES)
        Dim oMovimientoSua As New Class_NominaMovimientoSua

        If MsgBox("Deseas grabar el movimiento de " & Me.cboMovimientos.Text & " ?", CType(vbYesNo + vbQuestion, MsgBoxStyle), "Grabar") = MsgBoxResult.No Then
            Exit Function
        End If
        Try
            Dim oSua As New Class_Nomina_SUA
            If oSua.GrabarMovimiento(sCodigoTrabajador, IIf(Me.cboMovimientos.Text = "ALTA", "08", "02").ToString, Format(CDate(sFechaMovimiento), "dd-MM-yyyy").ToString, Format(Me.DtpFecha1.Value, "dd-MM-yyyy").ToString, valorNumerico(Me.txtSueldoDI.Text)) = False Then
                MsgBox("No se grabo el movimiento.", MsgBoxStyle.Exclamation, "Grabar")
                Exit Function
            End If

            Dim sql As New Class_find("SELECT CODIGO_TRABAJADOR FROM NOMINA_CAT_TRABAJADORES WHERE NUMERO_REGISTRO_IMSS='" & Me.GridMovimientos.Cell(1, Me.igyMovimientoNumRegistroIMSS).Text & "'")
            If oMovimientoSua.EditaMovimientosIntegrados(Me.cboMovimientos.Text, Format(CDate(sFechaMovimiento), "yyyy-dd-MM").ToString, Format(Me.DtpFecha1.Value, "yyyy-dd-MM"), sql.Result1.ToString, "GRABA") = False Then
                MsgBox("No se grabo el movimiento.", MsgBoxStyle.Exclamation, "Grabar")
                Exit Function
            End If

            'Dim cmdMDB As New OleDbCommand("UPDATE MOVTOS SET FEC_INIC=@FEC_INIC, SAL_MOVT=@SAL_MOVT WHERE NUM_AFIL='" & Me.GridMovimientos.Cell(1, Me.igyMovimientoNumRegistroIMSS).Text & "' AND TIP_MOVS='" & Me.cboMovimientos.SelectedValue.ToString & "' AND FEC_INIC=#" & Format(CDate(sFechaMovimiento), "MM-dd-yyyy").ToString & "#", conexionMDB)
            'conexionMDB.Open()

            ''cmdMDB.Parameters.Clear()
            'With cmdMDB
            '    sqlParametroMDB = .Parameters.Add("@FEC_INIC", OleDbType.DBDate) : sqlParametroMDB.Value = Me.DtpFecha1.Value
            '    sqlParametroMDB = .Parameters.Add("@SAL_MOVT", OleDbType.Decimal) : sqlParametroMDB.Value = valorNumerico(Me.txtSueldoDI.Text)
            '    .ExecuteNonQuery()
            'End With

            'Me.ConsultarMovimientos(Me.GridMovimientos.Cell(1, Me.igyMovimientoNumRegistroIMSS).Text)

            Grabar = True
        Catch ex As Exception
            HandleError(Me.Name, "Grabar", ex)
        End Try
    End Function

    Private Function Eliminar() As Boolean
        Dim conexionMDB As New OleDbConnection(Plaza.oSisPlazaNomina.CONEXION_SUA_EVENTUALES)
        Dim oMovimientoSua As New Class_NominaMovimientoSua

        If MsgBox("Deseas eliminar el movimiento de " & Me.cboMovimientos.Text & " ?", CType(vbYesNo + vbQuestion, MsgBoxStyle), "Eliminar") = MsgBoxResult.No Then
            Exit Function
        End If
        Dim oTrabajador As New Class_CatTrabajadores()
        oTrabajador = New Class_CatTrabajadores(sCodigoTrabajador)

        Dim cmdMDB As New OleDbCommand("DELETE FROM MOVTOS WHERE NUM_AFIL='" & oTrabajador.NUMERO_REGISTRO_IMSS.ToString & "' AND TIP_MOVS='" & IIf(Me.cboMovimientos.Text = "ALTA", "08", "02").ToString & "' AND FEC_INIC=#" & Format(CDate(sFechaMovimiento), "MM-dd-yyyy").ToString & "#", conexionMDB)

        'Dim oSua As New Class_Nomina_SUA
        'If oSua.EliminarMovimiento(sCodigoTrabajador, Me.cboMovimientos.Text, Me.DtpFecha1.Value.ToString, valorNumerico(Me.txtSueldoDI.Text)) = False Then
        '    MsgBox("No se grabo el movimiento.", MsgBoxStyle.Exclamation, "Eliminar")
        '    Exit Function
        'End If

        Try
            Dim sql As New Class_find("SELECT CODIGO_TRABAJADOR FROM NOMINA_CAT_TRABAJADORES WHERE NUMERO_REGISTRO_IMSS='" & Me.GridMovimientos.Cell(1, Me.igyMovimientoNumRegistroIMSS).Text & "'")
            If oMovimientoSua.EditaMovimientosIntegrados(Me.cboMovimientos.Text, Format(CDate(sFechaMovimiento), "yyyy-dd-MM").ToString, Format(Me.DtpFecha1.Value, "yyyy-dd-MM"), sCodigoTrabajador, "ELIMINA") = False Then
                MsgBox("No se elimino el movimiento.", MsgBoxStyle.Exclamation, "Eliminar")
                Exit Function
            End If
            conexionMDB.Open()

            ''cmdMDB.Parameters.Clear()
            cmdMDB.ExecuteNonQuery()
            conexionMDB.Close()

            Eliminar = True
        Catch ex As Exception
            HandleError(Me.Name, "Eliminar", ex)
        End Try
        'Me.ConsultarMovimientos(Me.GridMovimientos.Cell(1, Me.igyMovimientoNumRegistroIMSS).Text)
    End Function

    '------------------------------------------AGREGAR MOVIMIENTOS ------------------------------------------------
    'Private Function IntegraMovimientoBaja(ByVal sCodigoTrabajador As String, ByVal sFechaAlta As String) As Boolean
    '    Dim sqlParametroMDB As OleDbParameter
    '    'Dim conexionMDB As New OleDbConnection(Empresa_Sistema.oSisEmpresaNomina.CONEXION_SUA_EVENTUALES)

    '    oTrabajadores = New Class_CatTrabajadores(sCodigoTrabajador)

    '    Dim cmdMDB As New OleDbCommand("INSERT INTO MOVTOS(REG_PATR,NUM_AFIL,TIP_MOVS,FEC_INIC,CON_SEC,SAL_MOVT," & _
    '                                   "CVE_MOVS,TIP_INC,EDO_MOV,ART_33,Status,NOMBRE,ORDEN,FEC_OPE) " & _
    '                                   "VALUES(@REG_PATR,@NUM_AFIL,@TIP_MOVS,@FEC_INIC,@CON_SEC,@SAL_MOVT, " & _
    '                                   "@CVE_MOVS,@TIP_INC,@EDO_MOV,@ART_33,@Status,@NOMBRE,@ORDEN,@FEC_OPE) ", conexionMDB)
    '    Try
    '        'conexionMDB.Open()

    '        cmdMDB.Parameters.Clear()
    '        With cmdMDB
    '            sqlParametroMDB = .Parameters.Add("@REG_PATR", OleDbType.VarWChar) : sqlParametroMDB.Value = Empresa_Sistema.oSisEmpresaNomina.NOMINA_NUMERO_REGISTRO_PATRONAL.ToString
    '            sqlParametroMDB = .Parameters.Add("@NUM_AFIL", OleDbType.VarWChar) : sqlParametroMDB.Value = oTrabajadores.NUMERO_REGISTRO_IMSS.ToString
    '            sqlParametroMDB = .Parameters.Add("@TIP_MOVS", OleDbType.VarWChar) : sqlParametroMDB.Value = "02"
    '            sqlParametroMDB = .Parameters.Add("@FEC_INIC", OleDbType.DBDate) : sqlParametroMDB.Value = CDate(Format(CDate(sFechaAlta), "dd/MM/yyyy"))
    '            sqlParametroMDB = .Parameters.Add("@CON_SEC", OleDbType.VarWChar) : sqlParametroMDB.Value = " "
    '            sqlParametroMDB = .Parameters.Add("@SAL_MOVT", OleDbType.Decimal) : sqlParametroMDB.Value = 0 'Empresa_Sistema.oSisEmpresaNomina.NOMINA_SUELDO_DIARIO
    '            sqlParametroMDB = .Parameters.Add("@CVE_MOVS", OleDbType.VarWChar) : sqlParametroMDB.Value = "B"
    '            sqlParametroMDB = .Parameters.Add("@TIP_INC", OleDbType.VarWChar) : sqlParametroMDB.Value = 1
    '            sqlParametroMDB = .Parameters.Add("@EDO_MOV", OleDbType.VarWChar) : sqlParametroMDB.Value = "0"
    '            sqlParametroMDB = .Parameters.Add("@ART_33", OleDbType.VarWChar) : sqlParametroMDB.Value = "N"
    '            sqlParametroMDB = .Parameters.Add("@Status", OleDbType.SmallInt) : sqlParametroMDB.Value = 2
    '            sqlParametroMDB = .Parameters.Add("@NOMBRE", OleDbType.VarWChar) : sqlParametroMDB.Value = Trim(oTrabajadores.APELLIDO_PATERNO) + " " + Trim(oTrabajadores.APELLIDO_MATERNO) + " " + Trim(oTrabajadores.NOMBRE_TRABAJADOR)
    '            sqlParametroMDB = .Parameters.Add("@ORDEN", OleDbType.SmallInt) : sqlParametroMDB.Value = 2
    '            sqlParametroMDB = .Parameters.Add("@FEC_OPE", OleDbType.DBDate) : sqlParametroMDB.Value = CDate(Format(Now(), "dd/MM/yyyy"))

    '            .ExecuteNonQuery()
    '        End With

    '        'conexionMDB.Close()
    '        'conexionMDB.Dispose()

    '        IntegraMovimientoBaja = True
    '    Catch ex As Exception
    '        HandleError(Me.Name, "IntegraMovimientoBaja", ex)
    '    End Try
    'End Function

    Private Function GestionaIntegracion() As Boolean
        If MsgBox("Deseas grabar el movimiento ?", CType(vbYesNo + vbQuestion, MsgBoxStyle), "Integración") = MsgBoxResult.No Then
            Exit Function
        End If

        Dim oSua As New Class_Nomina_SUA
        Try
            If Me.cboMovimientos.Text = "ALTA" Then
                If oSua.ExisteAfiliacion(sCodigoTrabajador) = False Then
                    If oSua.IntegraAfiliacion(sCodigoTrabajador) = False Then
                        MsgBox("No se pudo integrar el archivo. ", MsgBoxStyle.Exclamation, Me.Text)
                        Exit Function
                    End If
                End If
                If oSua.ExisteAsegura(sCodigoTrabajador) = False Then
                    If oSua.IntegraAsegura(sCodigoTrabajador, Me.DtpFecha1.Value.ToString) = False Then
                        MsgBox("No se pudo integrar el archivo. ", MsgBoxStyle.Exclamation, Me.Text)
                        Exit Function
                    End If
                End If
                If oSua.ExisteMovimiento(sCodigoTrabajador, Me.DtpFecha1.Value.ToString, IIf(Me.cboMovimientos.Text = "ALTA", "08", "02").ToString) = False Then
                    If oSua.IntegraMovimientoAlta(sCodigoTrabajador, Me.DtpFecha1.Value.ToString, 99) = False Then
                        MsgBox("No se pudo integrar el archivo. ", MsgBoxStyle.Exclamation, Me.Text)
                        Exit Function
                    End If
                End If

            ElseIf Me.cboMovimientos.Text = "BAJA" Then
                If oSua.ExisteMovimiento(sCodigoTrabajador, Me.DtpFecha1.Value.ToString, IIf(Me.cboMovimientos.Text = "ALTA", "08", "02").ToString) = False Then
                    If oSua.IntegraMovimientoBaja(sCodigoTrabajador, Me.DtpFecha1.Value.ToString) = False Then
                        MsgBox("No se pudo integrar el archivo. ", MsgBoxStyle.Exclamation, Me.Text)
                        Exit Function
                    End If
                Else
                    MsgBox("EL movimiento del trabajador ya esta integrado. ", MsgBoxStyle.Exclamation, Me.Text)
                    Exit Function
                End If

            End If
            GestionaIntegracion = True
        Catch ex As Exception
            HandleError(Me.Name, "GestionaIntegracion", ex)
        End Try
    End Function

    Private Function LlenaComboMovimientos() As Boolean
        Me.cboMovimientos.Items.Add("ALTA")
        Me.cboMovimientos.Items.Add("BAJA")

        Me.cboMovimientos.SelectedItem = "ALTA"
    End Function

#End Region

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Me.Estado = enumEstados.NUEVO
        Me.Cambia_Estado()
    End Sub

    Private Sub btnRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegresar.Click
        Me.Estado = enumEstados.CONSULTA
        Me.Cambia_Estado()
    End Sub
End Class