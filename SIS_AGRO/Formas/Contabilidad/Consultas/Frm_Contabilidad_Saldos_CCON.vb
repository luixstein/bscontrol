Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class Frm_Contabilidad_Saldos_CUENTA_CONTABLE_PESOS

#Region "Campos"
#Region "Campos privados"
    Private Enum enumEstados
        AuxiliarMAyor
    End Enum

    Private Estado As enumEstados
    Private FormatoDeReporte As String
#End Region
#Region "Campos de sistema"

#End Region
#End Region

#Region "Constructor y destructor"
    Public Sub New()
        InitializeComponent()
        Estado = enumEstados.AuxiliarMAyor
        'Me.Cambia_Estado()
        Me.DesplegarEjercicios()
        Me.Limpiar()
    End Sub
#End Region
#Region "Opciones"
    Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click
        If Validar() Then
            Me.Imprimir()
        End If
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub
#End Region

#Region "Eventos de objetos"

#Region "Eventos específicos"
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
                    Me.LblCuenta.Text = sql.Result2
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
                    Me.LblCuenta.Text = sql.Result2
                    sql = Nothing
                End If

            Case Keys.Return
                If txtLEN(Me.TxtCuenta1.Text) = False Then
                    Me.LblCuenta.Text = ""
                    GoTo BusquedaVisual : Exit Sub
                End If

                Dim sql As New Class_find("Select CUENTA_CONTABLE,NOMBRE_CUENTA From CON_CAT_CUENTAS Where CUENTA_CONTABLE='" & sReplace(Me.TxtCuenta1.Text) & "'")
                Me.LblCuenta.Text = sql.Result2
                If txtLEN(Me.LblCuenta.Text) = False Then
                    GoTo BusquedaVisual : Exit Sub
                End If
                sql = Nothing
                SendKeys.Send("{TAB}")
        End Select
    End Sub

    Private Sub CmbEjercicio_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbEjercicio.SelectedIndexChanged
        Dim sql As Class_find
        sql = New Class_find("SELECT FECHA_INICIO,FECHA_FINAL FROM CON_EJERCICIOS WHERE ID_CON_EJERCICIO=" & Me.CmbEjercicio.SelectedValue.ToString)
        Me.dtFechaDesde.Value = CDate(sql.Result1)
        Me.dtFechaHasta.Value = CDate(sql.Result2)
    End Sub

#End Region

#Region "Eventos Genericos"
    Private Sub txt_Enter(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim oTexBox As TextBox = CType(sender, TextBox)
        oTexBox.SelectAll()
    End Sub

    Private Sub txt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbEjercicio.KeyDown, dtFechaDesde.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCuenta1.KeyPress
        txtNoBeep(e)
        txtSoloNumerosEnteros(e)
    End Sub
#End Region

#End Region

#Region "Métodos y procedimientos"

    'Private Sub Cambia_Estado()
    '    Select Case Me.Estado
    '        Case enumEstados.AuxiliarMAyor
    '    End Select
    '    Application.DoEvents()
    'End Sub

    Private Sub DesplegarEjercicios()
        Dim oElementos As New Class_Contabilidad_Ejercicios
        With Me.CmbEjercicio
            .DisplayMember = "NOMBRE_EJERCICIO"
            .ValueMember = "ID_CON_EJERCICIO"

            Dim dView As New Data.DataView(oElementos.ObtenerEjercicios)
            .DataSource = dView
            If dView.Count > 0 Then
                .SelectedIndex = 0
            End If
        End With
    End Sub

    Private Function Validar() As Boolean
        Dim sql As Class_find
        If txtLEN(TxtCuenta1.Text) = False Then
            MsgBox("Asigne la cuenta contable.", MsgBoxStyle.Critical, "Validación de Cuentas Contables")
            Validar = False
            Me.TxtCuenta1.Focus()
            Exit Function
        End If

        sql = New Class_find("Select NOMBRE_CUENTA From CON_CAT_CUENTAS Where CUENTA_CONTABLE='" & Me.TxtCuenta1.Text & "' ")
        If sql.Result1 = "" Then
            MsgBox("La cuenta contable inicial que intenta buscar no existe, favor de intentar con otro codigo", MsgBoxStyle.Critical, "Validación de Cuentas Contables")
            Validar = False
            Me.TxtCuenta1.Focus()
            sql = Nothing
            Exit Function
        End If

        Validar = True
    End Function

    Private Sub Consultar()
        'Dim StrSqlQuerry As String = ""
        'Dim Auxiliar As New Class_Contabilidad_Saldos_Cuentas
        'Auxiliar.CUENTA_CONTABLE = Me.TxtCuenta1.Text
        'Auxiliar.ID_CON_PERIODO1 = FG_Meses(Me.CmbPeriodo1.Text, 0)
        'Auxiliar.ID_CON_PERIODO2 = FG_Meses(Me.CmbPeriodo2.Text, 0)
        'Auxiliar.ID_CON_EJERCICIO = Empresa_Sistema.ID_CON_EJERCICIO
        'Me.Grid.DataSource = Auxiliar.Consultar
        ''r.CUENTA_CONTABLE_PESOS,r.PERIODO,r.CARGOS,r.ABONOS,r.SALDO,ACUMULADO 
        'If Grid.Rows.Count > 0 Then
        '    Grid.Columns(0).Visible = False
        '    Grid.Columns(1).Visible = False
        '    Grid.Columns(2).Visible = False
        '    Grid.Columns(3).Visible = False
        '    Grid.Columns(4).Visible = False
        '    Grid.Columns(5).Visible = False
        '    Grid.Columns(6).Width = 100 'CUENTA
        '    Grid.Columns(7).Width = 100 'PERIODO
        '    Grid.Columns(8).Width = 100 'CARGO
        '    Grid.Columns(9).Width = 100 'ABONO
        '    Grid.Columns(10).Width = 100 'SALDO
        '    Grid.Columns(11).Width = 100 'AACUMULADO
        '    Auxiliar = Nothing
        'End If
    End Sub

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
        ValidarPeriodo = True
    End Function

    Private Sub Imprimir()
        Dim StrFiltros As String = ""
        Dim Rpt As ReportDocument
        Rpt = New ReportDocument
        Dim oReporte As Class_Reporte
        Try
            If Me.ValidarPeriodo = False Then
                Exit Sub
            End If

            FormatoDeReporte = "RPT_CONTABILIDAD_SALDOS_POR_MES_CUENTA_CONTABLE"
            oReporte = New Class_Reporte(FormatoDeReporte, Rpt)
            If Not oReporte.RptCargado Then
                Exit Sub
            End If
            ' Rpt.SetParameterValue("@FOLIO_POLIZA", TxtFolio.Text)
            Rpt.SetParameterValue("@CUENTA_CONTABLE", Me.TxtCuenta1.Text)
            Rpt.SetParameterValue("@PERIODO1", Format(Me.dtFechaDesde.Value, "yyyy-dd-MM"))
            Rpt.SetParameterValue("@PERIODO2", Format(Me.dtFechaHasta.Value, "yyyy-dd-MM"))
            Rpt.SetParameterValue("@ID_CON_EJERCICIO", Me.CmbEjercicio.SelectedValue)

            Dim frm As New Reporte(Rpt)
            'frm.CRViewer.DisplayGroupTree = False
            frm.CRViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            frm.Show()
        Catch ex As Exception
            HandleError(Me.Name, "Imprimir ", ex)
        Finally
            oReporte = Nothing
        End Try
    End Sub

    Private Function Filtros() As String
        Dim sFiltros As String
        sFiltros = ""
        Filtros = sFiltros
    End Function

    Private Sub Limpiar()
        Me.TxtCuenta1.Text = ""
        Me.LblCuenta.Text = ""
        Me.CmbEjercicio.SelectedValue = Plaza.ID_CON_EJERCICIO
        Me.dtFechaDesde.Value = Plaza.FECHA_INICIO
        Me.dtFechaHasta.Value = Plaza.FECHA_FINAL
    End Sub

    Private Sub dtFechaDesde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtFechaDesde.ValueChanged
        Dim sql As Class_find
        sql = New Class_find("SELECT FECHA_INICIO,FECHA_FINAL FROM CON_EJERCICIOS WHERE ID_CON_EJERCICIO='" & Me.CmbEjercicio.SelectedValue.ToString & "'")
        'Me.dtFechaDesde.Value = 1
        If Me.dtFechaDesde.Value < CDate(sql.Result1) Then
            Me.dtFechaDesde.Value = CDate(sql.Result1)
        End If
        If Me.dtFechaDesde.Value > CDate(sql.Result2) Then
            Me.dtFechaDesde.Value = CDate(sql.Result2)
        End If
    End Sub

    Private Sub dtFechaHasta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtFechaHasta.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.tsbImprimir.PerformClick()
        End If
    End Sub

    Private Sub dtFechaHasta_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtFechaHasta.ValueChanged
        Dim sql As Class_find
        sql = New Class_find("SELECT FECHA_INICIO,FECHA_FINAL FROM CON_EJERCICIOS WHERE ID_CON_EJERCICIO='" & Me.CmbEjercicio.SelectedValue.ToString & "'")
        If Me.dtFechaHasta.Value < CDate(sql.Result1) Then
            Me.dtFechaHasta.Value = CDate(sql.Result1)
        End If
        If Me.dtFechaHasta.Value > CDate(sql.Result2) Then
            Me.dtFechaHasta.Value = CDate(sql.Result2)
        End If
    End Sub

#End Region

End Class


