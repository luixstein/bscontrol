Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class Frm_Contabilidad_NavegadorPresupuestos

    Private FormatoDeReporte As String = "RPT_NAVEGADOR_PRESUPUESTOS"

    Private iGyCuentaContable As Short = 1
    Private iGyNombreCuenta As Short = 2
    Private iGyHectareas As Short = 3
    Private iGyPresupuesto As Short = 4
    Private iGyPresupuestoHectareas As Short = 5
    Private iGyEjercido As Short = 6
    Private iGyEjercidoHectareas As Short = 7
    Private iGyAvance As Short = 8

#Region "Constructor y destructor"
    Public Sub New()
        InitializeComponent()

        DesplegarEjercicios()
        Limpiar()
        Me.Consultar()
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

#End Region

#Region "Opciones"
    'Private Sub tsbConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbConsultar.Click
    '    If ValidarCuentaContable() And ValidarPeriodo() Then
    '        Me.Consultar()
    '    End If
    'End Sub

    Private Sub tsbSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub

    Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click
        Me.Imprimir()
    End Sub
#End Region

#Region "Métodos y procedimientos"

    Private Function ValidarCuentaContable() As Boolean
        Dim sql As Class_find
        sql = New Class_find("SELECT NOMBRE_CUENTA,ESMAYOR FROM CON_CAT_CUENTAS WHERE CUENTA_CONTABLE='" & "" & Me.TxtCuenta1.Text & "' ")
        If sql.Result1 = "" Then
            MsgBox("La cuenta contable que intenta buscar no existe, favor de intentar con otro codigo", MsgBoxStyle.Critical, "Validación de Cuentas Contables")
            Me.TxtCuenta1.Text = ""
            Me.TxtCuenta1.Focus()
            ValidarCuentaContable = False
            sql = Nothing
            Exit Function
        End If
        If sql.Result2 = "1" Then
            MsgBox("La cuenta contable que intenta buscar es de mayor, favor de intentar con otro codigo", MsgBoxStyle.Critical, "Validación de Cuentas Contables")
            Me.TxtCuenta1.Text = ""
            Me.TxtCuenta1.Focus()
            ValidarCuentaContable = False
            sql = Nothing
            Exit Function
        End If
        ValidarCuentaContable = True
    End Function

    Private Function ValidarPeriodo() As Boolean
        Me.DtFechaDesde.Enabled = False
        Me.DtFechaDesde.Enabled = True
        Me.DtFechaHasta.Enabled = False
        Me.DtFechaHasta.Enabled = True

        If Me.DtFechaDesde.Value > Me.DtFechaHasta.Value Then
            MsgBox("Rango de fechas inválidas.", MsgBoxStyle.Exclamation, Me.Name)
            Exit Function
        End If
        Dim ValidaPeriodo As New Class_find("SELECT 1 FROM CON_EJERCICIOS WHERE (('" & Format(Me.DtFechaDesde.Value, "yyyy-dd-MM") & "' BETWEEN FECHA_INICIO AND FECHA_FINAL)) AND (('" & Format(Me.DtFechaHasta.Value, "yyyy-dd-MM") & "' BETWEEN FECHA_INICIO AND FECHA_FINAL)) AND ID_CON_EJERCICIO=" & Me.CmbEjercicio.SelectedValue.ToString)
        If ValidaPeriodo.Result1.Length <= 0 Then
            MsgBox("El rango especificado esta fuera del rango del ejercicio.", MsgBoxStyle.Exclamation, Me.Name)
            Exit Function
        End If
        Return True
    End Function

    Private Sub Consultar()
        Dim oReporteMostrar As Class_Reporte
        Try
            Dim dt As New DataTable

            If Me.TxtCuenta1.TextLength = 12 Then
                Dim StrFiltros As String = ""
                Dim Rpt As New ReportDocument
                oReporteMostrar = New Class_Reporte("RPT_CONTABILIDAD_AUXILIAR_DE_MAYOR", Rpt)

                If Me.ValidarPeriodo = False Then
                    Exit Sub
                End If

                If Not oReporteMostrar.RptCargado Then
                    Exit Sub
                End If

                Rpt.SetParameterValue("@CUENTA_CONTABLE1", Me.TxtCuenta1.Text)
                Rpt.SetParameterValue("@CUENTA_CONTABLE2", Me.TxtCuenta1.Text)
                Rpt.SetParameterValue("@FECHA1", Format(DtFechaDesde.Value, "yyyy-dd-MM"))
                Rpt.SetParameterValue("@FECHA2", Format(DtFechaHasta.Value, "yyyy-dd-MM"))
                Rpt.SetParameterValue("@ID_CON_EJERCICIO", Me.CmbEjercicio.SelectedValue)
                Rpt.SetParameterValue("@MOSTRAR_SOLO_CUENTAS_CON_SALDO_MAYOR_QUE_CERO", 0)
                Rpt.SetParameterValue("@FILTRO_CONTRAPOLIZAS", 0)

                Dim frm As New Reporte(Rpt)
                frm.CRViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                frm.Show()

            Else
                Dim oReporte As New Class_AuxiliarMayor
                Me.InicializaGrid()

                Grid.Rows = dt.Rows.Count + 1
                Grid.Row(0).Visible = True

                Grid.SelectionMode = FlexCell.SelectionModeEnum.ByRow
                Grid.DisplayFocusRect = False
                Grid.ExtendLastCol = False
                Grid.LockButton = True
                Grid.ReadonlyFocusRect = FlexCell.FocusRectEnum.Solid
                Grid.BorderStyle = FlexCell.BorderStyleEnum.Light3D
                Grid.ScrollBars = FlexCell.ScrollBarsEnum.Vertical
                Grid.DefaultFont = New Font("Tahoma", 8)
                'Grid.AllowUserToAddRows = False

                With oReporte
                    .CUENTA_CONTABLE1 = Me.TxtCuenta1.Text
                    .CUENTA_CONTABLE2 = Me.TxtCuenta1.Text
                    .FECHA1 = Format(Me.DtFechaDesde.Value, "yyyy-dd-MM")
                    .FECHA2 = Format(Me.DtFechaHasta.Value, "yyyy-dd-MM")
                    .ID_CON_EJERCICIO = CInt(Me.CmbEjercicio.SelectedValue.ToString)
                    dt = .ConsultarNavegadoPresupuesto
                    'Me.Grid.DataSource = dt

                    Dim i As Integer = 1
                    Me.Grid.Rows = 1
                    For Each dRow As DataRow In dt.Rows
                        Me.Grid.AddItem(dRow("CUENTA_CONTABLE").ToString & Chr(9) & dRow("NOMBRE_CUENTA").ToString & Chr(9) & _
                                        CDbl(dRow("HECTAREAS_SEMBRADAS").ToString) & Chr(9) & FormatImporteContable(CDbl(dRow("PRESUPUESTO"))).ToString & Chr(9) & FormatImporteContable(CDbl(dRow("PRESUPUESTO_POR_HECTAREA"))).ToString & Chr(9) & _
                                        FormatImporteContable(CDbl(dRow("EJERCIDO"))).ToString & Chr(9) & FormatImporteContable(CDbl(dRow("EJERCIDO_POR_HECTAREA"))).ToString & _
                                       Chr(9) & dRow("PTJE_EJERCIDO_PRESUPUESTO").ToString)
                        i = i + 1
                    Next
                End With

                oReporte = Nothing
                Me.FormateaGrid()
                Me.Totales()
            End If
        Catch ex As Exception
            HandleError(Me.Name, "Consultar", ex)
        Finally
            oReporteMostrar = Nothing
        End Try
        
    End Sub

    Private Sub Imprimir()
        Dim StrFiltros As String = ""
        Dim Rpt As ReportDocument
        Rpt = New ReportDocument
        Dim oReporte As Class_Reporte
        Try
            oReporte = New Class_Reporte(FormatoDeReporte, Rpt)

            If Me.ValidarPeriodo = False Then
                Exit Sub
            End If

            If Not oReporte.RptCargado Then
                Exit Sub
            End If

            Rpt.SetParameterValue("@CUENTA_CONTABLE1", "" & Me.TxtCuenta1.Text)
            Rpt.SetParameterValue("@CUENTA_CONTABLE2", "" & Me.TxtCuenta1.Text)
            Rpt.SetParameterValue("@FECHA1", Format(DtFechaDesde.Value, "yyyy-dd-MM"))
            Rpt.SetParameterValue("@FECHA2", Format(DtFechaHasta.Value, "yyyy-dd-MM"))
            Rpt.SetParameterValue("@ID_CON_EJERCICIO", Me.CmbEjercicio.SelectedValue)

            Dim frm As New Reporte(Rpt)
            frm.CRViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            frm.Show()
        Catch ex As Exception
            HandleError(Me.Name, "Reporte de navegador de presupuestos", ex)
        Finally
            oReporte = Nothing
        End Try
    End Sub

    Private Sub InicializaGrid()
        Me.Grid.DataSource = Nothing
        FG_Grid_Limpiar(Grid)

        'Creamos el Grid
        Me.Grid.Rows = 2
        Me.Grid.Cols = 9
        Me.Grid.DisplayRowNumber = True

        Me.FormateaGrid()
    End Sub

    Private Sub FormateaGrid()
        Me.Grid.Cell(0, Me.iGyCuentaContable).Text = "Cuenta"
        Me.Grid.Cell(0, Me.iGyNombreCuenta).Text = "Nombre de cuenta"
        Me.Grid.Cell(0, Me.iGyHectareas).Text = "Has."
        Me.Grid.Cell(0, Me.iGyPresupuesto).Text = "Presupuesto"
        Me.Grid.Cell(0, Me.iGyPresupuestoHectareas).Text = "P. por Hectareas"
        Me.Grid.Cell(0, Me.iGyEjercido).Text = "Ejercido"
        Me.Grid.Cell(0, Me.iGyEjercidoHectareas).Text = "E. por Hectareas"
        Me.Grid.Cell(0, Me.iGyAvance).Text = "Avance"

        'Me.Grid.Column(Me.iGyPresupuesto).FormatString = ("$ ###,###,###.00").ToString
        'Me.Grid.Column(Me.iGyPresupuestoHectareas).FormatString = ("$ ###,###,###.00").ToString
        'Me.Grid.Column(Me.iGyEjercido).FormatString = ("$ ###,###,###.00").ToString
        'Me.Grid.Column(Me.iGyEjercidoHectareas).FormatString = ("$ ###,###,###.00").ToString

        Me.Grid.Column(Me.iGyPresupuesto).Alignment = FlexCell.AlignmentEnum.RightCenter
        Me.Grid.Column(Me.iGyPresupuestoHectareas).Alignment = FlexCell.AlignmentEnum.RightCenter
        Me.Grid.Column(Me.iGyEjercido).Alignment = FlexCell.AlignmentEnum.RightCenter
        Me.Grid.Column(Me.iGyEjercidoHectareas).Alignment = FlexCell.AlignmentEnum.RightCenter
        Me.Grid.Column(Me.iGyAvance).Alignment = FlexCell.AlignmentEnum.RightCenter
        Me.Grid.Column(Me.iGyHectareas).Alignment = FlexCell.AlignmentEnum.RightCenter

        Me.Grid.Column(Me.iGyCuentaContable).Width = 120
        Me.Grid.Column(Me.iGyNombreCuenta).Width = 280
        Me.Grid.Column(Me.iGyHectareas).Width = 50
        Me.Grid.Column(Me.iGyPresupuesto).Width = 110
        Me.Grid.Column(Me.iGyPresupuestoHectareas).Width = 110
        Me.Grid.Column(Me.iGyEjercido).Width = 110
        Me.Grid.Column(Me.iGyEjercidoHectareas).Width = 110
        Me.Grid.Column(Me.iGyAvance).Width = 100

        Me.Grid.Column(Me.iGyCuentaContable).Locked = True
        Me.Grid.Column(Me.iGyNombreCuenta).Locked = True
        Me.Grid.Column(Me.iGyHectareas).Locked = True
        Me.Grid.Column(Me.iGyPresupuesto).Locked = True
        Me.Grid.Column(Me.iGyPresupuestoHectareas).Locked = True
        Me.Grid.Column(Me.iGyEjercido).Locked = True
        Me.Grid.Column(Me.iGyEjercidoHectareas).Locked = True
        Me.Grid.Column(Me.iGyAvance).Locked = True
    End Sub

    Private Sub Limpiar()
        Me.CmbEjercicio.SelectedValue = Plaza.ID_CON_EJERCICIO
        Me.DtFechaDesde.Value = Plaza.FECHA_INICIO
        Me.DtFechaHasta.Value = Plaza.FECHA_FINAL
        Me.txtPresupuesto.Text = "0.00"
        Me.txtEjercido.Text = "0.00"
    End Sub

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

    Private Sub CmbEjercicio_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbEjercicio.SelectedIndexChanged
        Dim sql As Class_find
        sql = New Class_find("SELECT FECHA_INICIO,FECHA_FINAL FROM CON_EJERCICIOS WHERE ID_CON_EJERCICIO=" & Me.CmbEjercicio.SelectedValue.ToString)
        Me.DtFechaDesde.Value = CDate(sql.Result1)
        Me.DtFechaHasta.Value = CDate(sql.Result2)
        Me.Consultar()
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

    Private Sub Totales()
        Me.txtPresupuesto.Text = FormatImporteContable(Redondear(FG_Grid_SumaCol(Me.Grid, Me.iGyPresupuesto), Empresa_Sistema.DECIMALES_CONTABILIDAD))
        Me.txtEjercido.Text = FormatImporteContable(Redondear(FG_Grid_SumaCol(Me.Grid, Me.iGyEjercido), Empresa_Sistema.DECIMALES_CONTABILIDAD))
    End Sub
#End Region

#Region "Eventos de objetos"

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

    Private Sub txtKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCuenta1.KeyPress, DtFechaDesde.KeyPress, DtFechaHasta.KeyPress
        txtNoBeep(e)
        txtSoloNumerosEnteros(e)
    End Sub
#End Region

#Region "Keydown específicos"
    Private Sub btnSubeNivel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubeNivel.Click
        Dim oParametros As New Class_SisContabilidadParametros
        Dim i As Integer
        i = Len(Me.TxtCuenta1.Text)

        If i < oParametros.LEN_CUENTA_CONTABLE_NIVEL1 Then
            MsgBox("Es la raiz de las cuentas contables", MsgBoxStyle.Critical, "Validación de Cuentas Contables")
            Me.btnSubeNivel.Enabled = False
        ElseIf i = oParametros.LEN_CUENTA_CONTABLE_NIVEL1 Then
            Me.TxtCuenta1.Text = Me.TxtCuenta1.Text.Substring(0, 1)
            Me.btnSubeNivel.Enabled = False
            Me.txtPresupuesto.Visible = True : Me.txtEjercido.Visible = True
        ElseIf i = oParametros.LEN_CUENTA_CONTABLE_NIVEL1 + oParametros.LEN_CUENTA_CONTABLE_NIVEL2 Then
            Me.TxtCuenta1.Text = Me.TxtCuenta1.Text.Substring(0, oParametros.LEN_CUENTA_CONTABLE_NIVEL1)
            Me.btnSubeNivel.Enabled = True
            Me.txtPresupuesto.Visible = False : Me.txtEjercido.Visible = False
        ElseIf i = oParametros.LEN_CUENTA_CONTABLE_NIVEL1 + oParametros.LEN_CUENTA_CONTABLE_NIVEL2 + oParametros.LEN_CUENTA_CONTABLE_NIVEL3 Then
            Me.TxtCuenta1.Text = Me.TxtCuenta1.Text.Substring(0, oParametros.LEN_CUENTA_CONTABLE_NIVEL1 + oParametros.LEN_CUENTA_CONTABLE_NIVEL2)
            Me.btnSubeNivel.Enabled = True
            Me.txtPresupuesto.Visible = False : Me.txtEjercido.Visible = False
        ElseIf i = oParametros.LEN_CUENTA_CONTABLE_NIVEL1 + oParametros.LEN_CUENTA_CONTABLE_NIVEL2 + oParametros.LEN_CUENTA_CONTABLE_NIVEL3 + oParametros.LEN_CUENTA_CONTABLE_NIVEL4 Then
            Me.TxtCuenta1.Text = Me.TxtCuenta1.Text.Substring(0, oParametros.LEN_CUENTA_CONTABLE_NIVEL1 + oParametros.LEN_CUENTA_CONTABLE_NIVEL2 + oParametros.LEN_CUENTA_CONTABLE_NIVEL3)
            Me.btnSubeNivel.Enabled = True
            Me.txtPresupuesto.Visible = False : Me.txtEjercido.Visible = False
        ElseIf i = oParametros.LEN_CUENTA_CONTABLE_NIVEL1 + oParametros.LEN_CUENTA_CONTABLE_NIVEL2 + oParametros.LEN_CUENTA_CONTABLE_NIVEL3 + oParametros.LEN_CUENTA_CONTABLE_NIVEL4 + oParametros.LEN_CUENTA_CONTABLE_NIVEL5 Then
            Me.TxtCuenta1.Text = Me.TxtCuenta1.Text.Substring(0, oParametros.LEN_CUENTA_CONTABLE_NIVEL1 + oParametros.LEN_CUENTA_CONTABLE_NIVEL2 + oParametros.LEN_CUENTA_CONTABLE_NIVEL3 + oParametros.LEN_CUENTA_CONTABLE_NIVEL4)
            Me.btnSubeNivel.Enabled = True
            Me.txtPresupuesto.Visible = False : Me.txtEjercido.Visible = False
        End If
        Me.TxtCuenta2.Text = Me.TxtCuenta1.Text
        Me.Consultar()
    End Sub

    Private Sub Grid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Grid.DoubleClick
        Dim Columna As Integer, Renglon As Integer

        Columna = Me.iGyCuentaContable
        Renglon = Me.Grid.Selection.FirstRow

        Me.TxtCuenta1.Text = Me.Grid.Cell(Renglon, Me.iGyCuentaContable).Text
        Me.TxtCuenta2.Text = Me.Grid.Cell(Renglon, Me.iGyCuentaContable).Text

        Dim sql As New Class_find("SELECT CUENTA_CONTABLE,NOMBRE_CUENTA FROM CON_CAT_CUENTAS WHERE CUENTA_CONTABLE='" & Me.TxtCuenta1.Text & "' AND ESMAYOR=0 ")
        If sql.Result1 = "" Then
            Me.btnSubeNivel.Enabled = True
            Me.txtPresupuesto.Visible = False : Me.txtEjercido.Visible = False
        End If
        Me.Consultar()
    End Sub

    Private Sub TxtCuenta1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCuenta1.KeyDown
        Select Case e.KeyCode
            Case Keys.F6
BusquedaVisual:
                Dim oCuenta As New Class_CatCuentas
                Dim sCuenta As String = oCuenta.BusquedaVisual_PorCodigoFiltrandoTipoOperacion()
                If sCuenta.Length > 0 Then
                    Me.TxtCuenta1.Text = sCuenta
                    sCuenta = Replace(sCuenta, "'", "''")
                    Dim sql As New Class_find("SELECT CUENTA_CONTABLE,NOMBRE_CUENTA FROM CON_CAT_CUENTAS WHERE CUENTA_CONTABLE='" & sCuenta & "'")
                    Me.TxtCuenta1.Text = sCuenta
                    'Me.LblCuenta.Text = sql.Result2
                    sql = Nothing
                Else
                    Me.TxtCuenta1.Text = ""
                End If
            Case Keys.F7
                Dim oId As New Class_CatCuentas
                Dim sIdCodigo As String = oId.BusquedaVisual_PorNombreFiltrandoTipoOperacion()
                If sIdCodigo.Length > 0 Then
                    Me.TxtCuenta1.Text = sIdCodigo
                    sIdCodigo = Replace(sIdCodigo, "'", "''")
                    Dim sql As New Class_find("SELECT CUENTA_CONTABLE,NOMBRE_CUENTA FROM CON_CAT_CUENTAS WHERE CUENTA_CONTABLE='" & sIdCodigo & "'")
                    Me.TxtCuenta1.Text = sql.Result1
                    'Me.LblCuenta.Text = sql.Result2
                    sql = Nothing
                Else
                    Me.TxtCuenta1.Text = ""
                End If
            Case Keys.Return
                Dim sql As New Class_find("SELECT CUENTA_CONTABLE,NOMBRE_CUENTA FROM CON_CAT_CUENTAS WHERE CUENTA_CONTABLE='" & Me.TxtCuenta1.Text & "' AND ESMAYOR=0 ")
                If sql.Result1 = "" Then
                    'MsgBox("La cuenta contable que intenta buscar es de mayor, favor de intentar con otro codigo", MsgBoxStyle.Critical, "Validación de Cuentas Contables")
                    GoTo BusquedaVisual
                Else
                    'Me.LblCuenta.Text = sql.Result2
                    'Me.tsbConsultar.PerformClick()
                End If
                sql = Nothing
        End Select
    End Sub
#End Region

#End Region
End Class