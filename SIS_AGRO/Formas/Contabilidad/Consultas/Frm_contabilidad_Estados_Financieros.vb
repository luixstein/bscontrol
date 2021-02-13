Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class Frm_contabilidad_Estados_Financieros
    Private FormatoDeReporte As String

#Region "Constructor y destructor"
    Public Sub New()
        InitializeComponent()
        DesplegarEjercicios()
        DesplegarEjercicios2()
        'Me.CmbEjercicio.SelectedValue = EmpresaParametros.ID_CON_EJERCICIO
        Me.DtFechaDesde.Value = Plaza.FECHA_INICIO
        Me.DtFechaHasta.Value = Plaza.FECHA_FINAL
        Me.DtFechaDesde2.Value = Plaza.FECHA_INICIO
        Me.DtFechaHasta2.Value = Plaza.FECHA_FINAL
    End Sub
#End Region

#Region "Opciones"
    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub

    Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click
        Me.Imprimir()
    End Sub
#End Region

    Private Sub TxtCuenta1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCuenta1.KeyDown
        Select Case e.KeyCode
            Case Keys.F6
BusquedaVisual:
                Dim oCuenta As New Class_CatCuentas
                Dim sCuenta As String = oCuenta.BusquedaVisual_PorCodigoFiltrandoTipoOperacion(False)
                If sCuenta.Length > 0 Then
                    Me.TxtCuenta1.Text = sCuenta
                    sCuenta = Replace(sCuenta, "'", "''")
                    Dim sql As New Class_find("Select CUENTA_CONTABLE,NOMBRE_CUENTA From CON_CAT_CUENTAS Where CUENTA_CONTABLE='" & sCuenta & "'")
                    Me.TxtCuenta1.Text = sCuenta
                    Me.lblCuenta1.Text = sql.Result2
                    sql = Nothing
                End If

            Case Keys.F7
                Dim oId As New Class_CatCuentas
                Dim sIdCodigo As String = oId.BusquedaVisual_PorNombreFiltrandoTipoOperacion(False)
                If sIdCodigo.Length > 0 Then
                    Me.TxtCuenta1.Text = sIdCodigo
                    sIdCodigo = Replace(sIdCodigo, "'", "''")
                    Dim sql As New Class_find("Select CUENTA_CONTABLE,NOMBRE_CUENTA From CON_CAT_CUENTAS Where CUENTA_CONTABLE='" & sIdCodigo & "'")
                    Me.TxtCuenta1.Text = sql.Result1
                    Me.lblCuenta1.Text = sql.Result2
                    sql = Nothing
                End If

            Case Keys.Return
                If txtLEN(Me.TxtCuenta1.Text) = False Then
                    Me.lblCuenta1.Text = ""
                    txtTAB(e)
                    Exit Sub
                End If

                Dim sql As New Class_find("Select CUENTA_CONTABLE,NOMBRE_CUENTA From CON_CAT_CUENTAS Where CUENTA_CONTABLE='" & sReplace(Me.TxtCuenta1.Text) & "'")
                Me.lblCuenta1.Text = sql.Result2
                txtTAB(e)
                sql = Nothing
        End Select

    End Sub

    Private Sub TxtCuenta2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCuenta2.KeyDown
        Select Case e.KeyCode
            Case Keys.F6
BusquedaVisual:
                Dim oCuenta As New Class_CatCuentas
                Dim sCuenta As String = oCuenta.BusquedaVisual_PorCodigoFiltrandoTipoOperacion(False)
                If sCuenta.Length > 0 Then
                    Me.TxtCuenta2.Text = sCuenta
                    sCuenta = Replace(sCuenta, "'", "''")
                    Dim sql As New Class_find("Select CUENTA_CONTABLE,NOMBRE_CUENTA From CON_CAT_CUENTAS Where CUENTA_CONTABLE='" & sCuenta & "'")
                    Me.TxtCuenta2.Text = sCuenta
                    Me.lblCuenta2.Text = sql.Result2
                    sql = Nothing
                End If

            Case Keys.F7
                Dim oId As New Class_CatCuentas
                Dim sIdCodigo As String = oId.BusquedaVisual_PorNombreFiltrandoTipoOperacion(False)
                If sIdCodigo.Length > 0 Then
                    Me.TxtCuenta2.Text = sIdCodigo
                    sIdCodigo = Replace(sIdCodigo, "'", "''")
                    Dim sql As New Class_find("Select CUENTA_CONTABLE,NOMBRE_CUENTA From CON_CAT_CUENTAS Where CUENTA_CONTABLE='" & sIdCodigo & "'")
                    Me.TxtCuenta2.Text = sql.Result1
                    Me.lblCuenta2.Text = sql.Result2
                    sql = Nothing
                End If

            Case Keys.Return
                If txtLEN(Me.TxtCuenta2.Text) = False Then
                    Me.lblCuenta2.Text = Me.lblCuenta1.Text
                    Me.TxtCuenta2.Text = Me.TxtCuenta1.Text
                    txtTAB(e)
                    Exit Sub
                End If

                Dim sql As New Class_find("Select CUENTA_CONTABLE,NOMBRE_CUENTA From CON_CAT_CUENTAS Where CUENTA_CONTABLE='" & sReplace(Me.TxtCuenta2.Text) & "'")
                Me.lblCuenta2.Text = sql.Result2
                Me.tsbImprimir.PerformClick()
                sql = Nothing
        End Select

    End Sub
#Region "Métodos y procedimientos"

    Private Function ValidarPeriodo() As Boolean
        Me.DtFechaDesde.Enabled = False
        Me.DtFechaDesde.Enabled = True

        Me.DtFechaHasta.Enabled = False
        Me.DtFechaHasta.Enabled = True

        If Me.DtFechaDesde.Value > Me.DtFechaHasta.Value Then
            MsgBox("Rango de fechas inválidas.", MsgBoxStyle.Exclamation, Me.Name)
            Me.DtFechaDesde.Focus()
            Exit Function
        End If

        Dim ValidaPeriodo As New Class_find("SELECT 1 FROM CON_EJERCICIOS WHERE (('" & Format(Me.DtFechaDesde.Value, "yyyy-dd-MM") & "' BETWEEN FECHA_INICIO AND FECHA_FINAL)) AND (('" & Format(Me.DtFechaHasta.Value, "yyyy-dd-MM") & "' BETWEEN FECHA_INICIO AND FECHA_FINAL)) AND ID_CON_EJERCICIO=" & Me.CmbEjercicio.SelectedValue.ToString)
        If ValidaPeriodo.Result1.Length <= 0 Then
            MsgBox("El rango especificado esta fuera del rango del ejercicio.", MsgBoxStyle.Exclamation, Me.Name)
            Exit Function
        End If
        ValidarPeriodo = True
    End Function

    Private Function ValidarPeriodo2() As Boolean
        Me.DtFechaDesde2.Enabled = False
        Me.DtFechaDesde2.Enabled = True

        Me.DtFechaHasta2.Enabled = False
        Me.DtFechaHasta2.Enabled = True

        If Me.DtFechaDesde2.Value > Me.DtFechaHasta2.Value Then
            MsgBox("Rango de fechas inválidas.", MsgBoxStyle.Exclamation, Me.Name)
            Exit Function
        End If
        Dim ValidaPeriodo As New Class_find("SELECT 1 FROM CON_EJERCICIOS WHERE (('" & Format(Me.DtFechaDesde2.Value, "yyyy-dd-MM") & "' BETWEEN FECHA_INICIO AND FECHA_FINAL)) AND (('" & Format(Me.DtFechaHasta2.Value, "yyyy-dd-MM") & "' BETWEEN FECHA_INICIO AND FECHA_FINAL)) AND ID_CON_EJERCICIO=" & Me.CmbEjercicio2.SelectedValue.ToString)
        If ValidaPeriodo.Result1.Length <= 0 Then
            MsgBox("El rango especificado esta fuera del rango del ejercicio.", MsgBoxStyle.Exclamation, Me.Name)
            Exit Function
        End If
        ValidarPeriodo2 = True
    End Function

    Private Sub DesplegarEjercicios()
        Dim oElementos As New Class_Contabilidad_Ejercicios
        With Me.CmbEjercicio
            .DisplayMember = "NOMBRE_EJERCICIO"
            .ValueMember = "ID_CON_EJERCICIO"

            Dim dView As New Data.DataView(oElementos.ObtenerEjercicios)
            .DataSource = dView
            If dView.Count > 0 Then
                'Dim Ejercicio As New Class_find("SELECT ID_CON_EJERCICIO FROM CON_EJERCICIOS WHERE '" & Format(Date.Now, "yyyy-dd-MM") & "' BETWEEN FECHA_INICIO AND FECHA_FINAL AND TIPO_CONTABILIDAD='FN'")
                .SelectedValue = Plaza.ID_CON_EJERCICIO.ToString 'Ejercicio.Result1.ToString
            End If
        End With
    End Sub

    Private Sub DesplegarEjercicios2()
        Dim oElementos As New Class_Contabilidad_Ejercicios
        With Me.CmbEjercicio2
            .DisplayMember = "NOMBRE_EJERCICIO"
            .ValueMember = "ID_CON_EJERCICIO"

            Dim dView As New Data.DataView(oElementos.ObtenerEjercicios)
            .DataSource = dView
            If dView.Count > 0 Then
                'Dim Ejercicio As New Class_find("SELECT ID_CON_EJERCICIO FROM CON_EJERCICIOS WHERE '" & Format(Date.Now, "yyyy-dd-MM") & "' BETWEEN FECHA_INICIO AND FECHA_FINAL AND TIPO_CONTABILIDAD='FN'")
                .SelectedValue = Plaza.ID_CON_EJERCICIO.ToString ' Ejercicio.Result1.ToString
            End If
        End With
    End Sub

    Private Sub CmbEjercicio_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbEjercicio.SelectedIndexChanged
        Dim sql As Class_find
        sql = New Class_find("SELECT FECHA_INICIO,FECHA_FINAL,ESTATUS_EJERCICIO,'PC.' + NOMBRE_EJERCICIO FOLIO_POLIZA, " & _
                             "ISNULL((SELECT ESTATUS_POLIZA FROM CON_POLIZAS_GLOBAL WHERE FOLIO_POLIZA='PC.' + NOMBRE_EJERCICIO),'' ) ESTATUS_POLIZA " & _
                             "FROM CON_EJERCICIOS WHERE(ID_CON_EJERCICIO = " & Me.CmbEjercicio.SelectedValue.ToString & ")")
        Me.DtFechaDesde.Value = CDate(sql.Result1)
        Me.DtFechaHasta.Value = CDate(sql.Result2)

        If sql.Result3 = "A" And sql.Result5 = "A" Then
            Me.LblNota.Visible = True
            Me.btnPolizaNoCuadra.Enabled = False
        Else
            Me.LblNota.Visible = False
            Me.btnPolizaNoCuadra.Enabled = False
        End If
    End Sub

    Private Sub CmbEjercicio2_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbEjercicio2.SelectedIndexChanged
        Dim sql As Class_find
        sql = New Class_find("SELECT FECHA_INICIO,FECHA_FINAL FROM CON_EJERCICIOS WHERE ID_CON_EJERCICIO=" & Me.CmbEjercicio2.SelectedValue.ToString)
        Me.DtFechaDesde2.Value = CDate(sql.Result1)
        Me.DtFechaHasta2.Value = CDate(sql.Result2)
        ' Me.CmbEjercicio.SelectedValue = EmpresaParametros.ID_CON_EJERCICIO
    End Sub

    Private Sub DtFechaHasta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtFechaHasta.KeyDown, DtFechaDesde.KeyDown, CmbEjercicio.KeyDown, DtFechaDesde2.KeyDown, DtFechaHasta2.KeyDown, CmbEjercicio2.KeyDown
        txtTAB(e)
    End Sub

    Private Sub DtFechaHasta_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtFechaHasta.ValueChanged
        If Me.Visible = False Then
            Exit Sub
        End If
        Dim sql As Class_find
        sql = New Class_find("SELECT FECHA_INICIO,FECHA_FINAL FROM CON_EJERCICIOS WHERE ID_CON_EJERCICIO='" & Me.CmbEjercicio.SelectedValue.ToString & "'")
        If Me.DtFechaHasta.Value < CDate(sql.Result1) Then
            Me.DtFechaHasta.Value = CDate(sql.Result1)
        End If
        If Me.DtFechaHasta.Value > CDate(sql.Result2) Then
            Me.DtFechaHasta.Value = CDate(sql.Result2)
        End If
        Me.ValidarPolizas()
    End Sub

    Private Sub DtFechaHasta2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtFechaHasta2.ValueChanged
        If Me.Visible = False Then
            Exit Sub
        End If
        Dim sql As Class_find
        sql = New Class_find("SELECT FECHA_INICIO,FECHA_FINAL FROM CON_EJERCICIOS WHERE ID_CON_EJERCICIO='" & Me.CmbEjercicio2.SelectedValue.ToString & "'")
        If Me.DtFechaHasta2.Value < CDate(sql.Result1) Then
            Me.DtFechaHasta2.Value = CDate(sql.Result1)
        End If
        If Me.DtFechaHasta2.Value > CDate(sql.Result2) Then
            Me.DtFechaHasta2.Value = CDate(sql.Result2)
        End If
    End Sub

    Private Sub DtFechaDesde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtFechaDesde.ValueChanged
        If Me.Visible = False Then
            Exit Sub
        End If
        Dim sql As Class_find
        sql = New Class_find("SELECT FECHA_INICIO,FECHA_FINAL FROM CON_EJERCICIOS WHERE ID_CON_EJERCICIO='" & Me.CmbEjercicio.SelectedValue.ToString & "'")
        If Me.DtFechaDesde.Value < CDate(sql.Result1) Then
            Me.DtFechaDesde.Value = CDate(sql.Result1)
        End If
        If Me.DtFechaDesde.Value > CDate(sql.Result2) Then
            Me.DtFechaDesde.Value = CDate(sql.Result2)
        End If
    End Sub

    Private Sub DtFechaDesde2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtFechaDesde2.ValueChanged
        If Me.Visible = False Then
            Exit Sub
        End If
        Dim sql As Class_find
        sql = New Class_find("SELECT FECHA_INICIO,FECHA_FINAL FROM CON_EJERCICIOS WHERE ID_CON_EJERCICIO='" & Me.CmbEjercicio2.SelectedValue.ToString & "'")
        If Me.DtFechaDesde2.Value < CDate(sql.Result1) Then
            Me.DtFechaDesde2.Value = CDate(sql.Result1)
        End If
        If Me.DtFechaDesde2.Value > CDate(sql.Result2) Then
            Me.DtFechaDesde2.Value = CDate(sql.Result2)
        End If
    End Sub

    Public Function ValidarPolizas() As Boolean
        Dim dTable As DataTable
        Dim oEjercicios As Class_Contabilidad_Ejercicios
        oEjercicios = New Class_Contabilidad_Ejercicios(CInt(Me.CmbEjercicio.SelectedValue))
        dTable = oEjercicios.ValidarPolizas(CInt(Me.CmbEjercicio.SelectedValue), "VALIDAR")

        If dTable.Rows.Count > 0 Then
            MsgBox("Se encontraron pólizas con datos incorrectos.", MsgBoxStyle.Exclamation, "ImprimirDispersion")
            Me.btnPolizaNoCuadra.Enabled = False

            Dim StrFiltros As String = ""
            Dim Rpt As New ReportDocument
            Dim oReporte As Class_Reporte
            Try
                oReporte = New Class_Reporte("RPT_CONTABILIDAD_VALIDAR_POLIZA_EJERCICIO", Rpt)
                If Not oReporte.RptCargado Then
                    Exit Function
                End If
                Rpt.SetParameterValue("@ID_CON_EJERCICIO", CInt(Me.CmbEjercicio.SelectedValue))
                Rpt.SetParameterValue("@ACCION", "REPORTE")

                Dim frm As New Reporte(Rpt)
                frm.CRViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                frm.Show()
                ValidarPolizas = False
            Catch ex As Exception
                HandleError(Me.Name, "Impresión de Trabajadores", ex)
            Finally
                oReporte = Nothing
            End Try
            Exit Function
        Else
            ValidarPolizas = True
            Me.btnPolizaNoCuadra.Enabled = False
        End If
    End Function

    Private Sub Imprimir()
        Dim StrFiltros As String = ""
        Dim Rpt As New ReportDocument
        Dim oReporte As Class_Reporte
        Try
            If Me.ValidarPeriodo = False Then
                Exit Sub
            End If

            If Me.rdbEstadoResultados.Checked = True Then
                Me.FormatoDeReporte = "RPT_CONTABILIDAD_ESTADO_RESULTADOS"
                'ElseIf Me.rdbTotales.Checked = True Then
                '    Me.FormatoDeReporte = "RPT_CONTABILIDAD_ESTADO_RESULTADOS_TOTALES"
            ElseIf Me.RdnBalanceGeneral.Checked = True Then
                Me.FormatoDeReporte = "RPT_CONTABILIDAD_BALANCE_GENERAL"
                'ElseIf Me.RdbRelacionAnalitica.Checked = True Then
                '    Me.FormatoDeReporte = "RPT_CONTABILIDAD_RELACIONES_ANALITICAS_COMPARATIVAS"
                'ElseIf RdbEstadoSituacion.Checked = True Then
                '    Me.FormatoDeReporte = "RPT_CONTABILIDAD_ESTADO_CAMBIOS_SITUACION_FINANCIERA"
            End If

            oReporte = New Class_Reporte(FormatoDeReporte, Rpt)

            'If Me.rdbEstadoResultados.Checked = True Or Me.RdnBalanceGeneral.Checked = True Or Me.rdbTotales.Checked = True Then
            '    Rpt.SetParameterValue("@ID_CON_EJERCICIO", Me.CmbEjercicio.SelectedValue)
            '    Rpt.SetParameterValue("@FECHA1", Format(Me.DtFechaDesde.Value, "yyyy-dd-MM"))
            '    Rpt.SetParameterValue("@FECHA2", Format(Me.DtFechaHasta.Value, "yyyy-dd-MM"))
            '    If Me.RdnBalanceGeneral.Checked = True Then
            '        Rpt.SetParameterValue("@FORMATO_PARA_COMPARATIVO", "0")
            '    End If

            '    If Me.rdbEstadoResultados.Checked = True Then
            '        Rpt.SetParameterValue("@TIPO_CAMBIO", 0)
            '        Rpt.SetParameterValue("@ID_PROYECTO", 0)
            '    End If

            'Else
            '    Rpt.SetParameterValue("@FECHA1_A", Format(Me.DtFechaDesde.Value, "yyyy-dd-MM"))
            '    Rpt.SetParameterValue("@FECHA2_A", Format(Me.DtFechaHasta.Value, "yyyy-dd-MM"))
            '    Rpt.SetParameterValue("@ID_CON_EJERCICIO_A", Me.CmbEjercicio.SelectedValue)
            '    Rpt.SetParameterValue("@FECHA1_B", Format(Me.DtFechaDesde2.Value, "yyyy-dd-MM"))
            '    Rpt.SetParameterValue("@FECHA2_B", Format(Me.DtFechaHasta2.Value, "yyyy-dd-MM"))
            '    Rpt.SetParameterValue("@ID_CON_EJERCICIO_B", Me.CmbEjercicio2.SelectedValue)

            '    If RdbRelacionAnalitica.Checked = True Then
            '        Rpt.SetParameterValue("@CUENTA_CONTABLE1", "" & Me.TxtCuenta1.Text)
            '        Rpt.SetParameterValue("@CUENTA_CONTABLE2", "" & Me.TxtCuenta2.Text)
            '    End If
            'End If

            If Me.rdbEstadoResultados.Checked = True Then
                Rpt.SetParameterValue("@FECHA1", Format(Me.DtFechaDesde.Value, "yyyy-dd-MM"))
                Rpt.SetParameterValue("@FECHA2", Format(Me.DtFechaHasta.Value, "yyyy-dd-MM"))

            ElseIf Me.RdnBalanceGeneral.Checked = True Then
                Rpt.SetParameterValue("@ID_CON_EJERCICIO", Me.CmbEjercicio.SelectedValue)
                Rpt.SetParameterValue("@FECHA1", Format(Me.DtFechaDesde.Value, "yyyy-dd-MM"))
                Rpt.SetParameterValue("@FECHA2", Format(Me.DtFechaHasta.Value, "yyyy-dd-MM"))
                If Me.RdnBalanceGeneral.Checked = True Then
                    Rpt.SetParameterValue("@FORMATO_PARA_COMPARATIVO", "0")
                End If

                If Me.rdbEstadoResultados.Checked = True Then
                    Rpt.SetParameterValue("@TIPO_CAMBIO", 0)
                    Rpt.SetParameterValue("@ID_PROYECTO", 0)
                End If
            End If

            Dim frm As New Reporte(Rpt)
            frm.CRViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            frm.Show()
        Catch ex As Exception
            HandleError(Me.Name, "Imprimir", ex)
        Finally
            oReporte = Nothing
        End Try
    End Sub

    Private Function ValidarCuentas() As Boolean
        Dim sql As Class_find
        If Me.TxtCuenta1.Text <> "" Then
            sql = New Class_find("SELECT NOMBRE_CUENTA FROM CON_CAT_CUENTAS WHERE CUENTA_CONTABLE='" & Me.TxtCuenta1.Text & "' ")
            If sql.Result1 = "" Then
                MsgBox("La cuenta contable inicial que intenta buscar no existe, favor de intentar con otro codigo", MsgBoxStyle.Critical, "Validación de Cuentas Contables")
                ValidarCuentas = False
                Me.TxtCuenta1.Focus()
                sql = Nothing
                Exit Function
            End If
        End If
        If Me.TxtCuenta2.Text <> "" Then
            sql = New Class_find("SELECT NOMBRE_CUENTA FROM CON_CAT_CUENTAS WHERE CUENTA_CONTABLE='" & Me.TxtCuenta2.Text & "' ")
            If sql.Result1 = "" Then
                MsgBox("La cuenta contable final que intenta buscar no existe, favor de intentar con otro codigo", MsgBoxStyle.Critical, "Validación de Cuentas Contables")
                ValidarCuentas = False
                Me.TxtCuenta2.Focus()
                sql = Nothing
                Exit Function
            End If
        End If
        sql = Nothing
        ValidarCuentas = True
    End Function
#End Region

    Private Sub txtTipoCambio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            Me.tsbImprimir.PerformClick()
        End If
    End Sub

    Private Sub txtTipoCambio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim txt As TextBox = CType(sender, TextBox)
        txtSoloNumerosDecimales(e, txt.Text)
        txtNoBeep(e)
    End Sub

    Private Sub Frm_Contabilidad_Costos_Produccion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sql As New Class_find("SELECT FECHA_INICIO,FECHA_FINAL FROM CON_EJERCICIOS WHERE ID_CON_EJERCICIO=" & Me.CmbEjercicio.SelectedValue.ToString)
        Me.DtFechaDesde.Value = CDate(sql.Result1)
        Me.DtFechaHasta.Value = CDate(sql.Result2)

        Me.rdbEstadoResultados.Checked = True
        Me.RdnBalanceGeneral.Visible = True
        Me.rdbEstadoResultados.Visible = True
        'Me.RdbEstadoSituacion.Visible = True
        'Me.RdbRelacionAnalitica.Visible = True
        'Me.rdbTotales.Visible = True
    End Sub

    Private Sub RdbRelacionAnalitica_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdbRelacionAnalitica.CheckedChanged
        If Me.RdbRelacionAnalitica.Checked = True Then
            Me.LblDisplayDeLaCuenta.Visible = True
            Me.lblDisplayALaCuenta.Visible = True
            Me.TxtCuenta1.Visible = True
            Me.TxtCuenta2.Visible = True
            Me.lblCuenta1.Visible = True
            Me.lblCuenta2.Visible = True
            Me.GroupBox3.Enabled = True
        Else
            Me.LblDisplayDeLaCuenta.Visible = False
            Me.lblDisplayALaCuenta.Visible = False
            Me.TxtCuenta1.Visible = False
            Me.TxtCuenta2.Visible = False
            Me.lblCuenta1.Visible = False
            Me.lblCuenta2.Visible = False
            Me.GroupBox3.Enabled = False
        End If
    End Sub

    Private Sub RdbEstadoSituacion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdbEstadoSituacion.CheckedChanged
        If Me.RdbEstadoSituacion.Checked = True Then
            Me.LblDisplayDeLaCuenta.Visible = False
            Me.lblDisplayALaCuenta.Visible = False
            Me.TxtCuenta1.Visible = False
            Me.TxtCuenta2.Visible = False
            Me.lblCuenta1.Visible = False
            Me.lblCuenta2.Visible = False
            Me.GroupBox3.Enabled = True
        Else
            Me.GroupBox3.Enabled = False
        End If
    End Sub
End Class