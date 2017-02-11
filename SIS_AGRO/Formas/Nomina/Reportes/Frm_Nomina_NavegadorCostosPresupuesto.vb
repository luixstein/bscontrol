Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class Frm_Nomina_NavegadorCostosPresupuesto

    Private FormatoDeReporte As String = "RPT_NOMINA_NAVEGADOR_PRESUPUESTOS"

    Private iGyIdTrans As Short = 1
    Private iGyCuenta As Short = 2
    Private iGyNombreCuenta As Short = 3
    Private iGyEsMayor As Short = 4
    Private iGyJornales As Short = 5
    Private iGyEjercido As Short = 6
    Private iGyPresupuesto As Short = 7
    Private iGyHectareas As Short = 8
    Private iGyPresupuestoHectareas As Short = 9
    Private iGyEjercidoHectareas As Short = 10
    Private iGyAvance As Short = 11

    Private oSemana As Class_NominaSemana, dtSemanas As DataTable, IDSemana1 As Integer

#Region "Constructor y destructor"
    Public Sub New()
        InitializeComponent()

        Me.DesplegarSemanas()
        Me.CboSemana.Text = Plaza.oSisPlazaNomina.NOMINA_NUMERO_SEMANA_ACTUAL.ToString
        Me.Limpiar()
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
        Dim iLenParametos As Integer
        iLenParametos = 3

        i = Len(Me.TxtCuenta1.Text)

        If i < iLenParametos Then
            MsgBox("Es la raiz de las cuentas contables", MsgBoxStyle.Critical, "Validación de Cuentas Contables")
            Me.btnSubeNivel.Enabled = False
        ElseIf i = iLenParametos Then
            Me.TxtCuenta1.Text = Me.TxtCuenta1.Text.Substring(0, 1)
            Me.btnSubeNivel.Enabled = False
            Me.txtPresupuesto.Visible = True : Me.txtEjercido.Visible = True
        ElseIf i = iLenParametos + iLenParametos Then
            Me.TxtCuenta1.Text = Me.TxtCuenta1.Text.Substring(0, iLenParametos)
            Me.btnSubeNivel.Enabled = True
            Me.txtPresupuesto.Visible = False : Me.txtEjercido.Visible = False
        ElseIf i = iLenParametos + iLenParametos + iLenParametos Then
            Me.TxtCuenta1.Text = Me.TxtCuenta1.Text.Substring(0, iLenParametos + iLenParametos)
            Me.btnSubeNivel.Enabled = True
            Me.txtPresupuesto.Visible = False : Me.txtEjercido.Visible = False
        ElseIf i = iLenParametos + iLenParametos + iLenParametos + iLenParametos Then
            Me.TxtCuenta1.Text = Me.TxtCuenta1.Text.Substring(0, iLenParametos + iLenParametos + iLenParametos)
            Me.btnSubeNivel.Enabled = True
            Me.txtPresupuesto.Visible = False : Me.txtEjercido.Visible = False
        ElseIf i = iLenParametos + iLenParametos + iLenParametos + iLenParametos + iLenParametos Then
            Me.TxtCuenta1.Text = Me.TxtCuenta1.Text.Substring(0, iLenParametos + iLenParametos + iLenParametos + iLenParametos)
            Me.btnSubeNivel.Enabled = True
            Me.txtPresupuesto.Visible = False : Me.txtEjercido.Visible = False
        End If
        Me.TxtCuenta2.Text = Me.TxtCuenta1.Text
        Me.Consultar()
    End Sub

    Private Sub Grid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Grid.DoubleClick
        Dim Columna As Integer, Renglon As Integer

        Columna = Me.iGyCuenta
        Renglon = Me.Grid.Selection.FirstRow

        Me.TxtCuenta1.Text = Me.Grid.Cell(Renglon, Me.iGyCuenta).Text
        Me.TxtCuenta2.Text = Me.Grid.Cell(Renglon, Me.iGyCuenta).Text

        If Len(Me.TxtCuenta1.Text) > 1 Then
            Me.btnSubeNivel.Enabled = True
            Me.txtPresupuesto.Visible = False : Me.txtEjercido.Visible = False
        End If
        Me.Consultar()
    End Sub

#End Region

    'Private Sub CmbEjercicio_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbEjercicio.SelectedIndexChanged
    '    Dim sql As Class_find
    '    sql = New Class_find("SELECT FECHA_INICIO,FECHA_FINAL FROM CON_EJERCICIOS WHERE ID_CON_EJERCICIO=" & Me.CmbEjercicio.SelectedValue.ToString)
    '    Me.DtFechaDesde.Value = CDate(sql.Result1)
    '    Me.DtFechaHasta.Value = CDate(sql.Result2)
    '    Me.Consultar()
    'End Sub

    Private Sub CboSemana_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboSemana.SelectedValueChanged
        Try
            If Me.CboSemana.Text = "" Then
                Exit Sub
            End If
            Dim sql As New Class_find("SELECT FECHA1,DATEADD(DAY," & (CInt(Me.CboSemana.Text) - 1).ToString & "*7,FECHA1)+6 FROM NOMINA_TEMPORADAS WHERE ID_NOMINA_TEMPORADA=" & Plaza.oSisPlazaNomina.NOMINA_ID_NOMINA_TEMPORADA_ACTIVA)
            'Dim sql As New Class_find("SELECT DATEADD(DAY, (" & (CInt(Me.CboSemana.Text) - 1).ToString & "*7),FECHA1),DATEADD(DAY," & (CInt(Me.CboSemana.Text) - 1).ToString & "*7,FECHA1)+6 FROM NOMINA_TEMPORADAS WHERE ID_NOMINA_TEMPORADA=" & Plaza.oSisPlazaNomina.NOMINA_ID_NOMINA_TEMPORADA_ACTIVA)
            Me.DtFechaDesde.Value = CDate(sql.Result1.ToString)
            Me.DtFechaHasta.Value = CDate(sql.Result2.ToString)

            Me.Consultar()
        Catch ex As Exception
            HandleError(Me.Name, "CboSemana", ex)
        End Try
    End Sub

    'Private Sub DtFechaHasta_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtFechaHasta.ValueChanged
    '    If Me.Visible = False Then
    '        Exit Sub
    '    End If
    '    Dim sql As Class_find
    '    sql = New Class_find("SELECT FECHA_INICIO,FECHA_FINAL FROM CON_EJERCICIOS WHERE ID_CON_EJERCICIO='" & Me.CmbEjercicio.SelectedValue.ToString & "'")
    '    If Me.DtFechaHasta.Value < CDate(sql.Result1) Then
    '        Me.DtFechaHasta.Value = CDate(sql.Result1)
    '    End If
    '    If Me.DtFechaHasta.Value > CDate(sql.Result2) Then
    '        Me.DtFechaHasta.Value = CDate(sql.Result2)
    '    End If
    'End Sub

    'Private Sub DtFechaDesde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtFechaDesde.ValueChanged
    '    If Me.Visible = False Then
    '        Exit Sub
    '    End If
    '    Dim sql As Class_find
    '    sql = New Class_find("SELECT FECHA_INICIO,FECHA_FINAL FROM CON_EJERCICIOS WHERE ID_CON_EJERCICIO='" & Me.CmbEjercicio.SelectedValue.ToString & "'")
    '    If Me.DtFechaDesde.Value < CDate(sql.Result1) Then
    '        Me.DtFechaDesde.Value = CDate(sql.Result1)
    '    End If
    '    If Me.DtFechaDesde.Value > CDate(sql.Result2) Then
    '        Me.DtFechaDesde.Value = CDate(sql.Result2)
    '    End If
    'End Sub

#End Region

#Region "Métodos y procedimientos"
    Private Sub Consultar()
        Dim oReporte As New Class_Reporte
        Try
            Dim dt As New DataTable

            If Me.TxtCuenta1.TextLength = 9 Then

                Dim Rpt As New ReportDocument
                oReporte = New Class_Reporte("RPT_NOMINA_DETALLE_DIA_CENTRO_COSTO", Rpt)

                If Not oReporte.RptCargado Then
                    Exit Sub
                End If

                Rpt.SetParameterValue("@ID_NOMINA_SEMANA1", IDSemana1) 'Este dato se obtuvo desde que se abrió la forma
                Rpt.SetParameterValue("@ID_NOMINA_SEMANA2", CInt(Me.CboSemana.SelectedValue.ToString))
                Rpt.SetParameterValue("@CODIGO_CENTRO_COSTO", Me.TxtCuenta1.Text.Substring(0, 3))
                Rpt.SetParameterValue("@CODIGO_CONCEPTO_ACTIVIDAD", Me.TxtCuenta1.Text.Substring(3, 3))
                Rpt.SetParameterValue("@CODIGO_SUB_ACTIVIDAD", Me.TxtCuenta1.Text.Substring(6, 3))

                Dim frm As New Reporte(Rpt)
                frm.CRViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                frm.Show()

            Else
                Dim oSemana As New Class_NominaSemana

                Me.Grid.AutoRedraw = False
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

                With oSemana
                    .ID_NOMINA_SEMANA = CInt(Me.CboSemana.SelectedValue.ToString)
                    dt = .ConsultarNavegadoCostosPresupuesto(Me.TxtCuenta1.Text, Me.TxtCuenta2.Text)

                    Me.Grid.DataSource = dt

                    Dim i As Integer = 1
                    Me.Grid.Rows = 1
                    For Each dRow As DataRow In dt.Rows
                        Me.Grid.AddItem(dRow("IDTRANS").ToString & Chr(9) & dRow("CUENTA").ToString & Chr(9) & dRow("NOMBRE_CUENTA").ToString & Chr(9) & dRow("ESMAYOR").ToString & Chr(9) &
                                        dRow("JORNALES").ToString & Chr(9) & FormatImporteContable(CDbl(dRow("EJERCIDO"))).ToString & Chr(9) &
                                        FormatImporteContable(CDbl(dRow("PRESUPUESTO"))).ToString & Chr(9) & CDbl(dRow("HECTAREAS_SEMBRADAS").ToString) & Chr(9) &
                                        FormatImporteContable(CDbl(dRow("PRESUPUESTO_POR_HECTAREA"))).ToString & Chr(9) & FormatImporteContable(CDbl(dRow("EJERCIDO_POR_HECTAREA"))).ToString &
                                        Chr(9) & dRow("PTJE_EJERCIDO_PRESUPUESTO").ToString)
                        i = i + 1
                    Next
                End With

                Me.FormateaGrid()
                Me.Totales()

                Me.Grid.AutoRedraw = True
                Me.Grid.Refresh()

                oSemana = Nothing
            End If

        Catch ex As Exception
            HandleError(Me.Name, "Consultar", ex)
        Finally
            oReporte = Nothing
        End Try
    End Sub

    Private Sub Imprimir()
        Dim StrFiltros As String = ""
        Dim Rpt As New ReportDocument
        Dim oReporte As Class_Reporte
        Try
            oReporte = New Class_Reporte(FormatoDeReporte, Rpt)

            If Not oReporte.RptCargado Then
                Exit Sub
            End If

            Rpt.SetParameterValue("@CUENTA1", "" & Me.TxtCuenta1.Text)
            Rpt.SetParameterValue("@CUENTA2", "" & Me.TxtCuenta2.Text)
            Rpt.SetParameterValue("@ID_NOMINA_SEMANA", CInt(Me.CboSemana.SelectedValue.ToString))

            Dim frm As New Reporte(Rpt)
            frm.CRViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            frm.Show()
        Catch ex As Exception
            HandleError(Me.Name, "Imprimir", ex)
        Finally
            oReporte = Nothing
        End Try
    End Sub

    Private Sub InicializaGrid()
        Me.Grid.DataSource = Nothing
        FG_Grid_Limpiar(Grid)

        'Creamos el Grid
        Me.Grid.Rows = 2
        Me.Grid.Cols = 12
        Me.Grid.DisplayRowNumber = True

        Me.FormateaGrid()
    End Sub

    Private Sub FormateaGrid()
        Try
            Me.Grid.Cell(0, Me.iGyIdTrans).Text = "id"
            Me.Grid.Cell(0, Me.iGyCuenta).Text = "Cuenta"
            Me.Grid.Cell(0, Me.iGyNombreCuenta).Text = "Descripción"
            Me.Grid.Cell(0, Me.iGyEsMayor).Text = "EsMayor"
            Me.Grid.Cell(0, Me.iGyJornales).Text = "Jornales"
            Me.Grid.Cell(0, Me.iGyHectareas).Text = "Ha."
            Me.Grid.Cell(0, Me.iGyPresupuesto).Text = "Presupuesto"
            Me.Grid.Cell(0, Me.iGyPresupuestoHectareas).Text = "Presupuesto x Ha."
            Me.Grid.Cell(0, Me.iGyEjercido).Text = "Ejercido"
            Me.Grid.Cell(0, Me.iGyEjercidoHectareas).Text = "Ejercido x Ha."
            Me.Grid.Cell(0, Me.iGyAvance).Text = "Avance %"

            Me.Grid.Column(Me.iGyPresupuesto).Alignment = FlexCell.AlignmentEnum.RightCenter
            Me.Grid.Column(Me.iGyPresupuestoHectareas).Alignment = FlexCell.AlignmentEnum.RightCenter
            Me.Grid.Column(Me.iGyEjercido).Alignment = FlexCell.AlignmentEnum.RightCenter
            Me.Grid.Column(Me.iGyEjercidoHectareas).Alignment = FlexCell.AlignmentEnum.RightCenter
            Me.Grid.Column(Me.iGyAvance).Alignment = FlexCell.AlignmentEnum.RightCenter
            Me.Grid.Column(Me.iGyHectareas).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.iGyCuenta).Width = 120
            Me.Grid.Column(Me.iGyNombreCuenta).Width = 280
            Me.Grid.Column(Me.iGyHectareas).Width = 50
            Me.Grid.Column(Me.iGyPresupuesto).Width = 110
            Me.Grid.Column(Me.iGyPresupuestoHectareas).Width = 110
            Me.Grid.Column(Me.iGyEjercido).Width = 110
            Me.Grid.Column(Me.iGyEjercidoHectareas).Width = 110
            Me.Grid.Column(Me.iGyAvance).Width = 100

            Me.Grid.Column(Me.iGyCuenta).Locked = True
            Me.Grid.Column(Me.iGyNombreCuenta).Locked = True
            Me.Grid.Column(Me.iGyHectareas).Locked = True
            Me.Grid.Column(Me.iGyPresupuesto).Locked = True
            Me.Grid.Column(Me.iGyPresupuestoHectareas).Locked = True
            Me.Grid.Column(Me.iGyEjercido).Locked = True
            Me.Grid.Column(Me.iGyEjercidoHectareas).Locked = True
            Me.Grid.Column(Me.iGyAvance).Locked = True
            Me.Grid.Column(Me.iGyIdTrans).Visible = False
            Me.Grid.Column(Me.iGyEsMayor).Visible = False
            Me.Grid.Column(Me.iGyJornales).Visible = False

        Catch ex As Exception
            HandleError(Me.Name, "FormateaGrid", ex)
        End Try
    End Sub

    Private Sub Limpiar()
        'Me.CboSemana.SelectedValue = Plaza.ID_CON_EJERCICIO
        'Me.DtFechaDesde.Value = Plaza.FECHA_INICIO
        'Me.DtFechaHasta.Value = Plaza.FECHA_FINAL
        Me.txtPresupuesto.Text = "0.00"
        Me.txtEjercido.Text = "0.00"
    End Sub

    'Private Sub DesplegarEjercicios()
    '    Dim oElementos As New Class_Contabilidad_Ejercicios
    '    With Me.CmbEjercicio
    '        .DisplayMember = "NOMBRE_EJERCICIO"
    '        .ValueMember = "ID_CON_EJERCICIO"

    '        Dim dView As New Data.DataView(oElementos.ObtenerEjercicios)
    '        .DataSource = dView
    '        If dView.Count > 0 Then
    '            .SelectedIndex = 0
    '        End If
    '    End With
    'End Sub

    Private Sub DesplegarSemanas()
        Try
            Me.oSemana = New Class_NominaSemana
            Me.dtSemanas = Me.oSemana.ObtenerElementos()

            IDSemana1 = CInt(Me.dtSemanas.Select("NUMERO_SEMANA='1'")(0)("ID_NOMINA_SEMANA"))

            With Me.CboSemana
                .DisplayMember = "NUMERO_SEMANA"
                .ValueMember = "ID_NOMINA_SEMANA"
                Dim dView As New Data.DataView(Me.dtSemanas)
                dView.Sort = "NUMERO_SEMANA"
                .DataSource = dView
                If dView.Count > 0 Then
                    .DisplayMember = Plaza.oSisPlazaNomina.NOMINA_NUMERO_SEMANA_ACTUAL.ToString
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarSemanas", ex)
        End Try
    End Sub

    Private Sub Totales()
        Try
            Me.txtPresupuesto.Text = FormatImporteContable(Redondear(FG_Grid_SumaCol(Me.Grid, Me.iGyPresupuesto), Empresa_Sistema.DECIMALES_CONTABILIDAD))
            Me.txtEjercido.Text = FormatImporteContable(Redondear(FG_Grid_SumaCol(Me.Grid, Me.iGyEjercido), Empresa_Sistema.DECIMALES_CONTABILIDAD))
        Catch ex As Exception
            HandleError(Me.Name, "Totales", ex)
        End Try
    End Sub
#End Region

End Class