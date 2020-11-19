Option Strict On
Imports CrystalDecisions.CrystalReports.Engine

Public Class Frm_Contabilidad_Balanza_Analiticas_Mayor

#Region "Campos"
#Region "Campos privados"
    Private Enum enumEstados
        RelacionAnalitica
        BalanzaComprobacion
        AuxiliarMayor
    End Enum

    Private Estado As enumEstados
    Private FormatoDeReporte As String
#End Region
#End Region

#Region "Constructor y destructor"
    Public Sub New()
        InitializeComponent()
        Estado = enumEstados.RelacionAnalitica
        Me.Cambia_Estado()
        Inicializa()
        DesplegarEjercicios()
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
#End Region

#Region "Opciones"
    Private Sub tsbConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If ValidarCuentas() = True Then
        If Me.ValidarPeriodo() Then
            Me.Imprimir()
        End If
        'End If
    End Sub

    Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click
        If Me.ValidarPeriodo() Then
            Me.Imprimir()
        End If
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub
#End Region

#Region "Eventos de objetos"
    Private Sub Frm_Contabilidad_Balanza_Analiticas_Mayor_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim sql As Class_find
        sql = New Class_find("SELECT FECHA_INICIO,FECHA_FINAL FROM CON_EJERCICIOS WHERE ID_CON_EJERCICIO=" & Me.CmbEjercicio.SelectedValue.ToString)
        Me.DtFechaDesde.Value = CDate(sql.Result1)
        Me.DtFechaHasta.Value = CDate(sql.Result2)
    End Sub

#Region "Eventos Genericos"
    Private Sub txt_Enter(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim oTexBox As TextBox = CType(sender, TextBox)
        oTexBox.SelectAll()
    End Sub

    Private Sub txt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtFechaDesde.KeyDown, DtFechaHasta.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtKeyCuentasPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCuenta1.KeyPress, TxtCuenta2.KeyPress
        txtNoBeep(e)
        If e.KeyChar = "%" Then
            'e.Handled = True
        Else
            txtSoloNumerosEnteros(e)
        End If
        'If e.KeyChar = Convert.ToChar(Keys.) Then
        'e.Handled = True
        'End If
        'txtSoloNumerosEnteros(e) Then
    End Sub

    Private Sub txtKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DtFechaDesde.KeyPress, DtFechaHasta.KeyPress
        txtNoBeep(e)
        txtSoloNumerosEnteros(e)
    End Sub
#End Region

#Region "Keydown específicos"
    Private Sub chk_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Return Then
            Me.tsbImprimir.PerformClick()
        End If
    End Sub

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
#End Region

#Region "CheckedChanged"
    Private Sub RdbRelacionAnalitica_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdbRelacionAnalitica.CheckedChanged
        If Me.RdbRelacionAnalitica.Checked = True Then
            Me.ChCuentasAfectacion.Visible = True
            Me.chkFiltrarSoloCuentasConMovimientos.Visible = False
        End If
    End Sub

    Private Sub RdbBalanzaComprobacion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdbBalanzaComprobacion.CheckedChanged
        If Me.RdbBalanzaComprobacion.Checked = True Then
            Me.ChCuentasAfectacion.Visible = False
            Me.chkFiltrarSoloCuentasConMovimientos.Visible = True
        End If
    End Sub

    Private Sub RdbBalanzaComprobacion2doNivel_CheckedChanged(sender As Object, e As EventArgs) Handles RdbBalanzaComprobacion2doNivel.CheckedChanged
        If Me.RdbBalanzaComprobacion2doNivel.Checked = True Then
            Me.ChCuentasAfectacion.Visible = False
            Me.chkFiltrarSoloCuentasConMovimientos.Visible = True
        End If
    End Sub

    Private Sub RdbAuxiliarMayor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdbAuxiliarMayor.CheckedChanged
        If Me.RdbAuxiliarMayor.Checked = True Then
            Me.ChCuentasAfectacion.Visible = False
            Me.chkFiltrarSoloCuentasConMovimientos.Visible = False
        End If
    End Sub
#End Region

#End Region

#Region "Métodos y procedimientos"
    Private Sub DesplegarEjercicios()
        Try
            Dim oElementos As New Class_Contabilidad_Ejercicios
            With Me.CmbEjercicio
                .DisplayMember = "NOMBRE_EJERCICIO"
                .ValueMember = "ID_CON_EJERCICIO"
                Dim dView As New Data.DataView(oElementos.ObtenerEjercicios)
                .DataSource = dView
                If dView.Count > 0 Then
                    'Dim Ejercicio As New Class_find("SELECT ID_CON_EJERCICIO FROM CON_EJERCICIOS WHERE '" & Format(Date.Now, "yyyy-dd-MM") & "' BETWEEN FECHA_INICIO AND FECHA_FINAL AND TIPO_CONTABILIDAD='FN'")
                    .SelectedValue = Plaza.ID_CON_EJERCICIO.ToString ' Ejercicio.Result1.ToString
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarEjercicios", ex)
        End Try
    End Sub

    Private Sub Cambia_Estado()
        Select Case Me.Estado
            Case enumEstados.RelacionAnalitica
            Case enumEstados.BalanzaComprobacion
            Case enumEstados.AuxiliarMayor
        End Select
        Application.DoEvents()
    End Sub

    Private Function ValidarCuentas() As Boolean
        Try
            Dim sql As Class_find
            If Me.TxtCuenta1.Text <> "" Then
                sql = New Class_find("SELECT NOMBRE_CUENTA FROM CON_CAT_CUENTAS WHERE CUENTA_CONTABLE='" & Me.TxtCuenta1.Text & "' ")
                If sql.Result1 = "" Then
                    MsgBox("La cuenta contable inicial que intenta buscar no existe, favor de intentar con otro codigo", MsgBoxStyle.Critical, "Validación de Cuentas Contables")
                    ValidarCuentas = False
                    Me.TxtCuenta1.Focus()
                    sql = Nothing
                    Return False
                End If
            End If
            If Me.TxtCuenta2.Text <> "" Then
                sql = New Class_find("SELECT NOMBRE_CUENTA FROM CON_CAT_CUENTAS WHERE CUENTA_CONTABLE='" & Me.TxtCuenta2.Text & "' ")
                If sql.Result1 = "" Then
                    MsgBox("La cuenta contable final que intenta buscar no existe, favor de intentar con otro codigo", MsgBoxStyle.Critical, "Validación de Cuentas Contables")
                    ValidarCuentas = False
                    Me.TxtCuenta2.Focus()
                    sql = Nothing
                    Return False
                End If
            End If

            Return True
        Catch ex As Exception
            HandleError(Me.Name, "ValidarCuentas", ex)
        End Try
    End Function

    Private Function ValidarPeriodo() As Boolean
        Try
            If Me.DtFechaDesde.Value > Me.DtFechaHasta.Value Then
                MsgBox("Rango de fechas inválidas.", MsgBoxStyle.Exclamation, Me.Name)
                Return False
            End If
            Dim sql As New Class_find("SELECT 1 FROM CON_EJERCICIOS WHERE (('" & Format(Me.DtFechaDesde.Value, "yyyy-dd-MM") & "' BETWEEN FECHA_INICIO AND FECHA_FINAL)) AND (('" & Format(Me.DtFechaHasta.Value, "yyyy-dd-MM") & "' BETWEEN FECHA_INICIO AND FECHA_FINAL)) AND ID_CON_EJERCICIO=" & Me.CmbEjercicio.SelectedValue.ToString)
            If sql.Result1.Length <= 0 Then
                MsgBox("El rango especificado esta fuera del rango del ejercicio.", MsgBoxStyle.Exclamation, Me.Name)
                Return False
            End If
            sql = Nothing

            Return True
        Catch ex As Exception
            HandleError(Me.Name, "ValidarPeriodo", ex)
        End Try
    End Function

    Private Sub CmbEjercicio_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbEjercicio.SelectedIndexChanged
        Try
            Dim sql As New Class_find("SELECT FECHA_INICIO,FECHA_FINAL FROM CON_EJERCICIOS WHERE ID_CON_EJERCICIO=" & Me.CmbEjercicio.SelectedValue.ToString)
            Me.DtFechaDesde.Value = CDate(sql.Result1)
            Me.DtFechaHasta.Value = CDate(sql.Result2)
            sql = Nothing
            ' Me.CmbEjercicio.SelectedValue = EmpresaParametros.ID_CON_EJERCICIO
        Catch ex As Exception
            HandleError(Me.Name, "CmbEjercicio_SelectedIndexChanged_1", ex)
        End Try
    End Sub

    Private Sub DtFechaDesde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtFechaDesde.ValueChanged
        Try
            If Me.Visible = False Then
                Return
            End If
            Dim sql As New Class_find("SELECT FECHA_INICIO,FECHA_FINAL FROM CON_EJERCICIOS WHERE ID_CON_EJERCICIO='" & Me.CmbEjercicio.SelectedValue.ToString & "'")
            If Me.DtFechaDesde.Value < CDate(sql.Result1) Then
                Me.DtFechaDesde.Value = CDate(sql.Result1)
            End If
            If Me.DtFechaDesde.Value > CDate(sql.Result2) Then
                Me.DtFechaDesde.Value = CDate(sql.Result2)
            End If
            sql = Nothing
        Catch ex As Exception
            HandleError(Me.Name, "DtFechaDesde_ValueChanged", ex)
        End Try
    End Sub

    Private Sub DtFechaHasta_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtFechaHasta.ValueChanged
        Try
            If Me.Visible = False Then
                Return
            End If
            Dim sql As New Class_find("SELECT FECHA_INICIO,FECHA_FINAL FROM CON_EJERCICIOS WHERE ID_CON_EJERCICIO='" & Me.CmbEjercicio.SelectedValue.ToString & "'")
            If Me.DtFechaHasta.Value < CDate(sql.Result1) Then
                Me.DtFechaHasta.Value = CDate(sql.Result1)
            End If
            If Me.DtFechaHasta.Value > CDate(sql.Result2) Then
                Me.DtFechaHasta.Value = CDate(sql.Result2)
            End If
            sql = Nothing
        Catch ex As Exception
            HandleError(Me.Name, "DtFechaHasta_ValueChanged", ex)
        End Try
    End Sub

    Private Sub Imprimir()
        Dim StrFiltros As String = ""
        Dim Rpt As New ReportDocument
        Dim oReporte As Class_Reporte
        Try
            If Me.RdbRelacionAnalitica.Checked = True Then
                FormatoDeReporte = "RPT_CONTABILIDAD_RELACIONES_ANALITICAS"
            ElseIf Me.RdbBalanzaComprobacion.Checked = True Or Me.RdbBalanzaComprobacion2doNivel.Checked = True Then
                FormatoDeReporte = "RPT_CONTABILIDAD_BALANZA_COMPROBACION"
            ElseIf Me.RdbAuxiliarMayor.Checked = True Then
                FormatoDeReporte = "RPT_CONTABILIDAD_AUXILIAR_DE_MAYOR"
            End If

            oReporte = New Class_Reporte(FormatoDeReporte, Rpt)

            Rpt.SetParameterValue("@CUENTA_CONTABLE1", "" & Me.TxtCuenta1.Text)
            Rpt.SetParameterValue("@CUENTA_CONTABLE2", "" & Me.TxtCuenta2.Text)
            Rpt.SetParameterValue("@FECHA1", Format(Me.DtFechaDesde.Value, "yyyy-dd-MM"))
            Rpt.SetParameterValue("@FECHA2", Format(Me.DtFechaHasta.Value, "yyyy-dd-MM"))
            Rpt.SetParameterValue("@ID_CON_EJERCICIO", Me.CmbEjercicio.SelectedValue)
            Rpt.SetParameterValue("@MOSTRAR_SOLO_CUENTAS_CON_SALDO_MAYOR_QUE_CERO", Convert.ToInt32(Me.ChCuentasSaldo.Checked))

            If Me.RdbRelacionAnalitica.Checked = True Then
                Rpt.SetParameterValue("@MOSTRAR_SOLO_CUENTAS_DE_AFECTACION", Convert.ToInt32(Me.ChCuentasAfectacion.Checked))
                Rpt.SetParameterValue("@FORMATO_PARA_COMPARATIVO", "0")
            ElseIf RdbBalanzaComprobacion.Checked = True Then
                Rpt.SetParameterValue("@FILTRAR_HASTA_NIVEL2", "0")
                Rpt.SetParameterValue("@FILTRAR_SOLO_CUENTAS_CON_MOVIMIENTOS", Convert.ToInt32(Me.chkFiltrarSoloCuentasConMovimientos.Checked))
            ElseIf RdbBalanzaComprobacion2doNivel.Checked = True Then
                Rpt.SetParameterValue("@FILTRAR_HASTA_NIVEL2", "1") 'Aquí intencionalmente se le pasa 1 para que si nos muestre las cuentas de 2do nivel.
                Rpt.SetParameterValue("@FILTRAR_SOLO_CUENTAS_CON_MOVIMIENTOS", Convert.ToInt32(Me.chkFiltrarSoloCuentasConMovimientos.Checked))
            ElseIf Me.RdbAuxiliarMayor.Checked = True Then
                Rpt.SetParameterValue("@FILTRO_CONTRAPOLIZAS", "0")
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

    Private Sub Inicializa()
        Try
            Me.TxtCuenta1.Text = ""
            Me.TxtCuenta2.Text = ""
            Me.CmbEjercicio.SelectedValue = Plaza.ID_CON_EJERCICIO
            Me.DtFechaDesde.Value = Plaza.FECHA_INICIO
            Me.DtFechaHasta.Value = Plaza.FECHA_FINAL
            Me.ChCuentasSaldo.Checked = False
            Me.ChCuentasAfectacion.Checked = False
        Catch ex As Exception
            HandleError(Me.Name, "Inicializa", ex)
        End Try
    End Sub

#End Region

End Class
