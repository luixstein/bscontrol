Option Strict On

Imports Microsoft.VisualBasic
Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Data.Common
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Collections
Imports System.Collections.Generic
Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO
Imports System.Data.OleDb

Public Class Frm_Nomina_CapturaPercepciones
    Dim oSemana As Class_NominaSemana
    Dim oDia As New Class_NominaDia
    Dim oTemporada As New Class_NominaTemporada

    Private _RANGO As Integer = 100

#Region "Columnas grid semana"
    Private igyIdDia As Short = 1
    Private igyNumDia As Short = 2
    Private igyNombreDia As Short = 3
    Private igyFecha As Short = 4
    Private igyImporte As Short = 5
    Private igyJornales As Short = 6
#End Region

#Region "Columnas grid dia"
    Private igyDiaIdNominaHoja As Short = 1
    Private igyDiaCultivo As Short = 2 'cc
    Private igyDiaLote As Short = 3 'ca
    Private igyDiaActividad As Short = 4
    Private igyDiaImporte As Short = 5
    Private igyDiaJornales As Short = 6
#End Region

    Private igyColumna As Integer = 1, igyRenglon As Integer = 1

#Region "Opciones"
    Private Sub btnGeneraNomina_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGeneraNomina.Click
        Me.GenerarNomina()
    End Sub

    Private Sub btnPrenomina_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrenomina.Click
        Me.ImprimirPrenomina()
    End Sub

    Private Sub btnImprimirAlta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimirAlta.Click
        'If Me.ValidarNominaAlta = True Then
        Me.GeneraAltaTarjetas()
        'End If
    End Sub

    Private Sub BtnGeneraDispercion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDispersion.Click
        Me.GenerarDispersion()
    End Sub

    Private Sub btnImprimirReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimirReporte.Click
        Me.Imprimir()
    End Sub

    Private Sub btnGeneraPoliza_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGeneraPoliza.Click
        Me.GeneraPoliza()
    End Sub

    Private Sub btnImprimirListadoDiaPorCentroCosto_Click(sender As Object, e As EventArgs) Handles btnImprimirListadoDiaPorCentroCosto.Click
        Dim StrFiltros As String = ""
        Dim FormatoDeReporte As String = ""
        Dim Rpt As New ReportDocument
        Dim oReporte As Class_Reporte
        Try
            If Me.RdbReporteDia.Checked = True Then
                FormatoDeReporte = "RPT_NOMINA_DIARIA_AGRUPADO_CENTRO_COSTO"

                oReporte = New Class_Reporte(FormatoDeReporte, Rpt)
                If Not oReporte.RptCargado Then
                    Exit Sub
                End If

                Rpt.SetParameterValue("@ID_NOMINA_DIA", CInt(Me.GridSemana.Cell(Me.GridSemana.Selection.FirstRow, Me.igyIdDia).Text))

            ElseIf Me.RdbReporteRangoFechas.Checked = True Then
                FormatoDeReporte = "RPT_NOMINA_DIARIA_AGRUPADO_CENTRO_COSTO_RANGO_FECHAS"

                oReporte = New Class_Reporte(FormatoDeReporte, Rpt)
                If Not oReporte.RptCargado Then
                    Exit Sub
                End If

                Rpt.SetParameterValue("@FECHA1", Format(Me.dtFecha1_Reporte.Value, "yyyy-dd-MM"))
                Rpt.SetParameterValue("@FECHA2", Format(Me.dtFecha2_Reporte.Value, "yyyy-dd-MM"))

            ElseIf Me.RdbReporteSemana.Checked = True Then
                FormatoDeReporte = "RPT_NOMINA_DIARIA_AGRUPADO_CENTRO_COSTO_POR_SEMANA"

                oReporte = New Class_Reporte(FormatoDeReporte, Rpt)
                If Not oReporte.RptCargado Then
                    Exit Sub
                End If

                Rpt.SetParameterValue("@ID_NOMINA_SEMANA", Me.CboSemana.SelectedValue)

            End If

            Dim frm As New Reporte(Rpt)
            frm.CRViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            frm.Show()
        Catch ex As Exception
            HandleError(Me.Name, "btnImprimirListadoDiaPorCentroCosto", ex)
        Finally
            oReporte = Nothing
        End Try
    End Sub

    Private Sub btnImprimirListadoDiaPorLote_Click(sender As Object, e As EventArgs) Handles btnImprimirListadoDiaPorLote.Click
        Dim StrFiltros As String = ""
        Dim FormatoDeReporte As String = ""
        Dim Rpt As ReportDocument
        Rpt = New ReportDocument
        Dim oReporte As Class_Reporte
        Try
            If Me.RdbReporteDia.Checked = True Then
                FormatoDeReporte = "RPT_NOMINA_DIARIA_AGRUPADO_LOTE"

                oReporte = New Class_Reporte(FormatoDeReporte, Rpt)
                If Not oReporte.RptCargado Then
                    Exit Sub
                End If

                Rpt.SetParameterValue("@ID_NOMINA_DIA", CInt(Me.GridSemana.Cell(Me.GridSemana.Selection.FirstRow, Me.igyIdDia).Text))

            ElseIf Me.RdbReporteSemana.Checked = True Then
                FormatoDeReporte = "RPT_NOMINA_DIARIA_AGRUPADO_LOTE_POR_SEMANA"

                oReporte = New Class_Reporte(FormatoDeReporte, Rpt)
                If Not oReporte.RptCargado Then
                    Exit Sub
                End If

                Rpt.SetParameterValue("@ID_NOMINA_SEMANA", Me.CboSemana.SelectedValue)

            ElseIf Me.RdbReporteRangoFechas.Checked = True Then
                FormatoDeReporte = "RPT_NOMINA_DIARIA_AGRUPADO_LOTE_RANGO_FECHAS"

                oReporte = New Class_Reporte(FormatoDeReporte, Rpt)
                If Not oReporte.RptCargado Then
                    Exit Sub
                End If

                Rpt.SetParameterValue("@FECHA1", Format(Me.dtFecha1_Reporte.Value, "yyyy-dd-MM"))
                Rpt.SetParameterValue("@FECHA2", Format(Me.dtFecha2_Reporte.Value, "yyyy-dd-MM"))

            End If

            Dim frm As New Reporte(Rpt)
            frm.CRViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            frm.Show()
        Catch ex As Exception
            HandleError(Me.Name, "btnImprimirListadoDiaPorLote", ex)
        Finally
            oReporte = Nothing
        End Try
    End Sub

    Private Sub btnImprimirRendimientoCorte_Click(sender As Object, e As EventArgs) Handles btnImprimirRendimientoCorte.Click
        Dim StrFiltros As String = ""
        Dim FormatoDeReporte As String = ""
        Dim Rpt As ReportDocument
        Rpt = New ReportDocument
        Dim oReporte As Class_Reporte
        Try
            FormatoDeReporte = "RPT_NOMINA_RENDIMIENTO_CORTE"

            oReporte = New Class_Reporte(FormatoDeReporte, Rpt)
            If Not oReporte.RptCargado Then
                Exit Sub
            End If

            'If Me.RdbReporteRangoFechas.Checked = True Then
            '    Rpt.SetParameterValue("@FECHA1", Format(Me.dtFecha1_Reporte.Value, "yyyy-dd-MM"))
            '    Rpt.SetParameterValue("@FECHA2", Format(Me.dtFecha2_Reporte.Value, "yyyy-dd-MM"))
            'Else 'semana 'Nota, este reporte si se filtra por la semana, en vez de usar el id semana usa el rango de la semana seleccionada usas las fechas DtpFecha1/2 en vez de dtFecha1_Reporte
            '    Rpt.SetParameterValue("@FECHA1", Format(Me.DtpFecha1.Value, "yyyy-dd-MM"))
            '    Rpt.SetParameterValue("@FECHA2", Format(Me.DtpFecha2.Value, "yyyy-dd-MM"))
            'End If

            If Me.RdbReporteDia.Checked = True Then
                Dim sDia As String = Format(CDate(Me.GridSemana.Cell(Me.GridSemana.Selection.FirstRow, Me.igyFecha).Text), "yyyy-dd-MM")

                Rpt.SetParameterValue("@FECHA1", sDia)
                Rpt.SetParameterValue("@FECHA2", sDia)

            ElseIf Me.RdbReporteSemana.Checked = True Then
                Rpt.SetParameterValue("@FECHA1", Format(Me.DtpFecha1.Value, "yyyy-dd-MM"))
                Rpt.SetParameterValue("@FECHA2", Format(Me.DtpFecha2.Value, "yyyy-dd-MM"))

            ElseIf Me.RdbReporteRangoFechas.Checked = True Then
                Rpt.SetParameterValue("@FECHA1", Format(Me.dtFecha1_Reporte.Value, "yyyy-dd-MM"))
                Rpt.SetParameterValue("@FECHA2", Format(Me.dtFecha2_Reporte.Value, "yyyy-dd-MM"))

            End If

            Rpt.SetParameterValue("@FLETE_POR_PERSONA", valorNumerico(Me.txtImporteFlete.Text))

            Dim frm As New Reporte(Rpt)
            frm.CRViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            frm.Show()
        Catch ex As Exception
            HandleError(Me.Name, "btnImprimirRendimientoCorte", ex)
        Finally
            oReporte = Nothing
        End Try
    End Sub
#End Region

#Region "Eventos de objetos"
#Region "Eventos"
    Private Sub Frm_Nomina_CapturaPercepciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Inicializa()
        Me.DesplegarSemanas()
        Me.DesplegarPuntoPago()
        Me.DesplegarTipoPago()

        'Dim sql As New Class_find("SELECT DATEADD(DAY,((DATEDIFF(DAY,FECHA1,GETDATE())/7))*7,FECHA1),DATEADD(DAY,((DATEDIFF(DAY,FECHA1,GETDATE())/7))*7,FECHA1)+6, (DATEDIFF(DAY,FECHA1,GETDATE())/7)+1 FROM NOMINA_TEMPORADAS WHERE ID_NOMINA_TEMPORADA=" & Plaza.NOMINA_ID_NOMINA_TEMPORADA_ACTIVA)
        'Me.CboSemana.Text = sql.Result3.ToString
        'Me.DtpFecha1.Value = CDate(Sql.Result1.ToString)
        'Me.DtpFecha2.Value = CDate(sql.Result2.ToString)

        'Me.CboSemana.Text = Plaza.oSisPlazaNomina.NOMINA_NUMERO_SEMANA_ACTUAL.ToString
        'Me.CboSemana.SelectedValue = 0

        Me.GridSemana.Cell(igyColumna, igyRenglon).SetFocus()
    End Sub

    Private Sub DtpFechas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtpFecha1.KeyDown, DtpFecha2.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.Send("{TAB}")
        End Select
    End Sub

    Private Sub GridSemana_KeyDown(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridSemana.KeyDown
        'Me.GestionaGrid(e)
        'Me.FormateaGrid()
    End Sub

    Private Sub btnEmbarqueAnterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSemanaAnterior.Click
        Me.NavegadorSemanas("Anterior")
    End Sub

    Private Sub btnEmbarqueSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSemanaSiguiente.Click
        Me.NavegadorSemanas("Siguiente")
    End Sub

    Private Sub rdbSobres_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbSobres.CheckedChanged
        If Me.rdbSobres.Checked = True Then
            Me.cboTipoPago.Visible = True
            Me.lblDisplayTipoPago.Visible = True
        Else
            Me.cboTipoPago.Visible = False
            Me.lblDisplayTipoPago.Visible = False
        End If
    End Sub

    Private Sub rdbCostosPresupuestos_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbCostosPresupuestos.CheckedChanged, RdbDeducciones.CheckedChanged, RdbTotales.CheckedChanged, _
    RdbDistribucionEfectivo.CheckedChanged, rdbEmisionCosto.CheckedChanged, rdbMultiPuntoPagos.CheckedChanged
        If Me.rdbCostosPresupuestos.Checked = True Or Me.RdbDeducciones.Checked = True Or Me.RdbTotales.Checked = True Or RdbDistribucionEfectivo.Checked = True Or Me.rdbEmisionCosto.Checked = True Or rdbMultiPuntoPagos.Checked = True Then
            Me.cboPuntoPago.Visible = False
            Me.lblDisplayPuntoPago.Visible = False
        Else
            Me.cboPuntoPago.Visible = True
            Me.lblDisplayPuntoPago.Visible = True
        End If
    End Sub

    Private Sub RdbReporteDia_CheckedChanged(sender As Object, e As EventArgs) Handles RdbReporteDia.CheckedChanged
        If Me.RdbReporteDia.Checked = True Then
            Me.dtFecha1_Reporte.Visible = False
            Me.dtFecha2_Reporte.Visible = False
        End If
    End Sub

    Private Sub RdbReporteRangoFechas_CheckedChanged(sender As Object, e As EventArgs) Handles RdbReporteRangoFechas.CheckedChanged
        If Me.RdbReporteRangoFechas.Checked = True Then
            Me.dtFecha1_Reporte.Visible = True
            Me.dtFecha2_Reporte.Visible = True
        End If
    End Sub

    Private Sub RdbReporteSemana_CheckedChanged(sender As Object, e As EventArgs) Handles RdbReporteSemana.CheckedChanged
        If Me.RdbReporteSemana.Checked = True Then
            Me.dtFecha1_Reporte.Visible = False
            Me.dtFecha2_Reporte.Visible = False
        End If
    End Sub
#End Region

#Region "Eventos Genericos"
    Private Sub txtTextoKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)  'txtFolioEmbarque.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub txtNumerosEnterosKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles GridSemana.KeyPress, txtConsecutivo.KeyPress, txtRango.KeyPress
        txtSoloNumerosEnteros(e)
        txtNoBeep(e)
    End Sub

    Private Sub txtNumerosDecimalKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim txt As TextBox = CType(sender, TextBox)
        txtSoloNumerosDecimales(e, txt.Text)
        txtNoBeep(e)
    End Sub

    Private Sub Cbo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CboSemana.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.Send("{TAB}")
        End Select
    End Sub
#End Region

#Region "Keydown específicos"
    Private Sub GridSemana_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridSemana.Click
        Me.CambiaDiaSemana()
    End Sub

    Private Sub GridDia_DoubleClick(ByVal Sender As Object, ByVal e As System.EventArgs) Handles GridDia.DoubleClick
        Me.AbrirHoja()
    End Sub

    Private Sub btnAgregaHoja_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregaHoja.Click
        Me.AgregarHoja()
    End Sub

    Private Sub CboSemana_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboSemana.SelectedValueChanged
        Try
            If Me.CboSemana.Text = "" Then
                Exit Sub
            End If

            'Dim sql As New Class_find("SELECT DATEADD(DAY, (" & (CInt(Me.CboSemana.Text) - 1).ToString & "*7),FECHA1),DATEADD(DAY," & (CInt(Me.CboSemana.Text) - 1).ToString & "*7,FECHA1)+6 " & _
            '                          "FROM NOMINA_TEMPORADAS WHERE ID_NOMINA_TEMPORADA=" & Plaza.oSisPlazaNomina.NOMINA_ID_NOMINA_TEMPORADA_ACTIVA)

            Dim sql As New Class_find("SELECT MIN(FECHA) F1,MAX(FECHA) F2 " & _
                          "FROM VW_NOMINA_DIAS_EXTENDIDA WHERE ID_NOMINA_TEMPORADA=" & Plaza.oSisPlazaNomina.NOMINA_ID_NOMINA_TEMPORADA_ACTIVA & " AND NUMERO_SEMANA=" & Me.CboSemana.Text)

            Me.DtpFecha1.Value = CDate(sql.Result1.ToString)
            Me.DtpFecha2.Value = CDate(sql.Result2.ToString)

            Me.Consultar()

            Me.lblIDSemana.Text = CboSemana.SelectedValue.ToString
        Catch ex As Exception
            HandleError(Me.Name, "CboSemana", ex)
        End Try
    End Sub
#End Region

#End Region

#Region "Métodos y procedimientos"
    Private Sub Inicializa()
        Try
            Me.DtpFecha1.Value = Date.Now
            Me.DtpFecha2.Value = Date.Now
            Me.CboSemana.SelectedValue = 0
            Me.txtTotalImporte.Text = "0"
            Me.txtTotalJornales.Text = "0"
            Me.RdbNominaPuntoPago.Checked = True

            Me.InicializaGrid()
            Me.InicializaGridDia()

            Me.dtFecha1_Reporte.Value = FechaActualINI()
            Me.dtFecha2_Reporte.Value = Date.Now
        Catch ex As Exception
            HandleError(Me.Name, "Inicializa", ex)
        End Try
    End Sub

    Private Sub InicializaGrid()
        Me.GridSemana.DataSource = Nothing
        FG_Grid_Limpiar(Me.GridSemana)
        Me.GridSemana.Rows = 9
        Me.GridSemana.Cols = 7
        Me.FormateaGrid()
    End Sub

    Private Sub InicializaGridDia()
        Me.GridSemana.DataSource = Nothing
        FG_Grid_Limpiar(Me.GridDia)
        Me.GridDia.Rows = 2
        Me.GridDia.Cols = 7
        Me.FormateaGridDia()
    End Sub

    Private Sub FormateaGrid()
        Try
            With Me.GridSemana
                .AutoRedraw = False

                .Column(Me.igyNumDia).Width = 80
                .Column(Me.igyNombreDia).Width = 120
                .Column(Me.igyFecha).Width = 80
                .Column(Me.igyImporte).Width = 100
                .Column(Me.igyJornales).Width = 100

                .Cell(0, Me.igyNombreDia).Text = "Día"
                .Cell(0, Me.igyFecha).Text = "Fecha"
                .Cell(0, Me.igyImporte).Text = "Importe"
                .Cell(0, Me.igyJornales).Text = "Jornales"

                .Column(Me.igyFecha).CellType = FlexCell.CellTypeEnum.DateTime
                .Column(Me.igyFecha).FormatString = "dd-MMM-yy"

                .Column(Me.igyImporte).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
                .Column(Me.igyImporte).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.igyImporte).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
                .Column(Me.igyImporte).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.igyJornales).Alignment = FlexCell.AlignmentEnum.CenterCenter

                .Column(Me.igyIdDia).Locked = False
                .Column(Me.igyIdDia).Visible = False
                .Column(Me.igyNumDia).Locked = False
                .Column(Me.igyNumDia).Visible = False
                .Column(Me.igyNombreDia).Locked = True
                .Column(Me.igyFecha).Locked = True
                .Column(Me.igyImporte).Locked = True
                .Column(Me.igyJornales).Locked = True
            End With
        Catch ex As Exception
            HandleError(Me.Name, "FormateaGrid", ex)
        Finally
            Me.GridSemana.AutoRedraw = True
            Me.GridSemana.Refresh()
        End Try
    End Sub

    Private Sub FormateaGridDia()
        Try
            With Me.GridDia
                .AutoRedraw = False

                .Column(Me.igyDiaIdNominaHoja).Width = 60
                .Column(Me.igyDiaCultivo).Width = 80
                .Column(Me.igyDiaLote).Width = 100
                .Column(Me.igyDiaActividad).Width = 100
                .Column(Me.igyDiaImporte).Width = 100
                .Column(Me.igyDiaJornales).Width = 90

                .Cell(0, Me.igyDiaCultivo).Text = "Centro Costo"
                .Cell(0, Me.igyDiaLote).Text = "Actividad"
                .Cell(0, Me.igyDiaActividad).Text = "Sub-Actividad"
                .Cell(0, Me.igyDiaImporte).Text = "Importe"
                .Cell(0, Me.igyDiaJornales).Text = "Jornales"

                .Column(Me.igyDiaImporte).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
                .Column(Me.igyDiaImporte).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.igyDiaImporte).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
                .Column(Me.igyDiaImporte).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.igyDiaJornales).Alignment = FlexCell.AlignmentEnum.CenterCenter

                .Column(Me.igyDiaIdNominaHoja).Locked = False
                .Column(Me.igyDiaIdNominaHoja).Visible = False
                .Column(Me.igyDiaCultivo).Locked = True
                .Column(Me.igyDiaLote).Locked = True
                .Column(Me.igyDiaActividad).Locked = True
                .Column(Me.igyDiaImporte).Locked = True
                .Column(Me.igyDiaJornales).Locked = True
            End With
        Catch ex As Exception
            HandleError(Me.Name, "FormateaGridDia", ex)
        Finally
            Me.GridDia.AutoRedraw = True
            Me.GridDia.Refresh()
        End Try
    End Sub

    Private Function Consultar() As Boolean
        Dim bResultado As Boolean = False
        Dim iSemana As Integer = CInt(Me.CboSemana.SelectedValue), vdg As String
        Dim dTabla As DataTable

        Try
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.oDia = New Class_NominaDia()

            dTabla = Me.oDia.ObtieneDetalleSemana(iSemana)

            Me.GridSemana.AutoRedraw = False
            Me.GridSemana.Rows = 1

            For Each dRow As DataRow In dTabla.Rows
                Me.GridSemana.AddItem(dRow(0).ToString & Chr(9) & dRow(1).ToString & Chr(9) & dRow(2).ToString & Chr(9) & dRow(3).ToString & Chr(9) & dRow(4).ToString & Chr(9) & dRow(5).ToString & Chr(9))
            Next
            dTabla.Dispose()

            Me.FormateaGrid()

            Me.GridSemana.AutoRedraw = True
            Me.GridSemana.Refresh()

            vdg = Me.GridSemana.Cell(Me.igyRenglon, Me.igyIdDia).Text
            If txtLEN(vdg) = False Then
                Me.InicializaGridDia()
                Me.Totales()
                Return True
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.oDia.ID_NOMINA_DIA = CInt(Me.GridSemana.Cell(Me.igyRenglon, Me.igyIdDia).Text)
            dTabla = Me.oDia.ObtenerDetalleHojas

            Me.GridDia.AutoRedraw = False
            Me.GridDia.Rows = 1

            For Each dRow As DataRow In dTabla.Rows
                Me.GridDia.AddItem(dRow(0).ToString & Chr(9) & dRow(1).ToString & Chr(9) & dRow(2).ToString & Chr(9) & dRow(3).ToString & Chr(9) & dRow(4).ToString & Chr(9) & dRow(5).ToString & Chr(9))
            Next
            dTabla.Dispose()

            If Me.GridDia.Rows = 1 Then
                Me.GridDia.Rows = 2
            End If

            Me.FormateaGridDia()

            Me.GridDia.AutoRedraw = True
            Me.GridDia.Refresh()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.Totales()

            Me.oSemana = New Class_NominaSemana(CInt(Me.CboSemana.SelectedValue.ToString))

            If Me.oSemana.NOMINA_GENERADA = "1" Then
                Me.btnAgregaHoja.Enabled = False
                Me.btnPrenomina.Enabled = False

                'Me.btnGeneraNomina.Enabled = False
                Me.btnGeneraNomina.Text = "Desaplicar nómina"

                Me.BtnDispersion.Enabled = True
                Me.lblEstatus.Text = "Generada el día " & Format(CDate(Me.oSemana.FECHA_GENERACION_NOMINA), "dd-MMM-yyyy hh:mm tt") & " por " & Me.oSemana.NOMBRE_USUARIO_GENERO_NOMINA
                Me.rdbCostos.Enabled = True
                Me.rdbEmisionCosto.Enabled = True
                Me.rdbCostosPresupuestos.Enabled = True
                Me.rdbSobres.Enabled = True
                Me.rdbMultiPuntoPagos.Enabled = True
                Me.RdbDistribucionEfectivo.Enabled = True
                Me.RdbTotales.Enabled = True
                Me.RdbDeducciones.Enabled = True
                Me.RdbNominaPuntoPago.Checked = True
                Me.btnGeneraPoliza.Enabled = True
            Else
                Me.btnAgregaHoja.Enabled = True
                Me.btnPrenomina.Enabled = True

                'Me.btnGeneraNomina.Enabled = True
                Me.btnGeneraNomina.Text = "Generar nómina"

                Me.BtnDispersion.Enabled = False
                Me.lblEstatus.Text = "Abierta"
                Me.rdbCostos.Enabled = False
                Me.rdbEmisionCosto.Enabled = False
                Me.rdbCostosPresupuestos.Enabled = False
                Me.rdbSobres.Enabled = False
                Me.rdbMultiPuntoPagos.Enabled = False
                Me.RdbDistribucionEfectivo.Enabled = False
                Me.RdbTotales.Enabled = False
                Me.RdbDeducciones.Enabled = False
                Me.RdbNominaPuntoPago.Checked = True
                Me.txtConsecutivo.Text = Me.oSemana.ULTIMO_NUMERO_TXT_DISPERSION.ToString
                Me.btnGeneraPoliza.Enabled = False
            End If

            Me.GridSemana.Cell(Me.igyRenglon, Me.igyColumna).SetFocus()

            bResultado = True
        Catch ex As Exception
            HandleError(Me.Name, "Consultar", ex)
        End Try

        Application.DoEvents()

        Return bResultado
    End Function

    Private Sub DesplegarSemanas()
        Try
            Dim oElementos As New Class_NominaSemana
            Dim oTemporada As New Class_NominaTemporada
            oTemporada.Consultar()
            Me.CboSemana.Refresh()
            With Me.CboSemana
                .DisplayMember = "NUMERO_SEMANA"
                .ValueMember = "ID_NOMINA_SEMANA"
                Dim dView As New Data.DataView(oElementos.ObtenerElementos())
                dView.Sort = "NUMERO_SEMANA"
                .DataSource = dView
                If dView.Count > 0 Then
                    '.DisplayMember = Plaza.oSisPlazaNomina.NOMINA_NUMERO_SEMANA_ACTUAL.ToString
                    Dim oNomina As New Class_NominaTemporada(Plaza.oSisPlazaNomina.NOMINA_ID_NOMINA_TEMPORADA_ACTIVA)
                    .SelectedValue = oNomina.ObtenerSemanaActiva
                End If
            End With
            Me.lblTemporadaPlaza.Text = oTemporada.NOMBRE_TEMPORADA.ToString & ", " & Plaza.NOMBRE_PLAZA
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarSemanas", ex)
        End Try
    End Sub

    Private Sub DesplegarPuntoPago()
        Try
            Dim oPuntoPago As New Class_CatPuntoPago
            With Me.cboPuntoPago
                .DisplayMember = "NOMBRE_PUNTO_PAGO"
                .ValueMember = "CODIGO_PUNTO_PAGO"
                Dim dView As New Data.DataView(oPuntoPago.ObtenerElementosParaReportes)
                dView.Sort = "NOMBRE_PUNTO_PAGO"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedValue = 1
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarPuntoPago", ex)
        End Try
    End Sub

    Private Sub DesplegarTipoPago()
        Try
            Me.cboTipoPago.Items.Add("EFECTIVO")
            Me.cboTipoPago.Items.Add("TARJETA")
            Me.cboTipoPago.Text = "TARJETA"
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarTipoPago", ex)
        End Try
    End Sub

    Private Sub Totales()
        Me.txtTotalImporte.Text = FormatImporteContable(Redondear(FG_Grid_SumaCol(Me.GridSemana, Me.igyImporte), Empresa_Sistema.DECIMALES_CONTABILIDAD))
        Me.txtTotalJornales.Text = FG_Grid_SumaCol(Me.GridSemana, Me.igyJornales).ToString
    End Sub

    Private Sub NavegadorSemanas(ByVal sTipoDeBusqueda As String)
        Try
            Dim iSemana As Integer

            If sTipoDeBusqueda = "Anterior" Then
                iSemana = CInt(Me.CboSemana.Text)
                iSemana = iSemana - 1

                If iSemana > 0 Then
                    Me.CboSemana.Text = iSemana.ToString
                    'Me.CboSemana.SelectedValue = iSemana
                End If
            Else
                If sTipoDeBusqueda = "Siguiente" Then
                    iSemana = CInt(Me.CboSemana.Text)
                    iSemana = iSemana + 1
                    oTemporada = New Class_NominaTemporada()
                    oTemporada.Consultar()
                    If iSemana <= CInt(oTemporada.NUMERO_SEMANAS.ToString) Then
                        Me.CboSemana.Text = iSemana.ToString
                        'Me.CboSemana.SelectedValue = iSemana
                    End If
                End If
            End If
        Catch ex As Exception
            HandleError(Me.Name, "NavegadorSemanas", ex)
        End Try
    End Sub

    Private Sub ImprimirPrenomina()
        Dim StrFiltros As String = ""
        Dim FormatoDeReporte As String
        Dim Rpt As New ReportDocument
        Dim oReporte As Class_Reporte
        Try
            FormatoDeReporte = "RPT_NOMINA_PRENOMINA"
            oReporte = New Class_Reporte(FormatoDeReporte, Rpt)
            If Not oReporte.RptCargado Then
                Exit Sub
            End If

            Rpt.SetParameterValue("@ID_NOMINA_SEMANA", Me.CboSemana.SelectedValue)

            Dim frm As New Reporte(Rpt)
            frm.CRViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            frm.Show()
        Catch ex As Exception
            HandleError(Me.Name, "ImprimirPrenomina", ex)
        Finally
            oReporte = Nothing
        End Try
    End Sub

    Public Function ValidarNominaPuntosPago() As Boolean
        Dim bResultado As Boolean = False

        Dim dTable As DataTable
        Dim oSemana As New Class_NominaSemana(CInt(Me.CboSemana.SelectedValue))
        dTable = oSemana.GeneraNominaPuntoPago()

        'If dTable.Rows.Count > 0 Then
        Dim StrFiltros As String = ""
        Dim Rpt As New ReportDocument
        Dim oReporte As Class_Reporte
        Try
            oReporte = New Class_Reporte("RPT_NOMINA_GENERA_VALIDA_PUNTOS_PAGO", Rpt)
            If Not oReporte.RptCargado Then
                Return False
            End If
            Rpt.SetParameterValue("@ID_NOMINA_SEMANA", CInt(Me.CboSemana.SelectedValue))

            Dim frm As New Reporte(Rpt)
            frm.CRViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            frm.Show()

            'bResultado = False
        Catch ex As Exception
            HandleError(Me.Name, "ValidarNominaPuntosPagos", ex)
        Finally
            oReporte = Nothing
        End Try
        'Exit Function
        'Else
        bResultado = True
        'End If

        Return bResultado
    End Function

    Public Function ValidarNominaAlta() As Boolean
        Dim bResultado As Boolean = False
        Dim StrFiltros As String = ""
        Dim Rpt As New ReportDocument
        Dim oReporte As Class_Reporte
        Dim dTable As DataTable

        Try
            Dim oSemana As New Class_NominaSemana(CInt(Me.CboSemana.SelectedValue))
            dTable = oSemana.GeneraNominaAlta(False)

            If dTable.Rows.Count > 0 Then
                MsgBox("Se encontraron trabajadores con datos incorrectos.", MsgBoxStyle.Exclamation, "ValidarNominaAlta")

                oReporte = New Class_Reporte("RPT_NOMINA_GENERA_ALTA", Rpt)
                If Not oReporte.RptCargado Then
                    Return False
                End If
                Rpt.SetParameterValue("@ID_NOMINA_SEMANA", CInt(Me.CboSemana.SelectedValue))
                Rpt.SetParameterValue("@RANGO1", 0)
                Rpt.SetParameterValue("@RANGO2", 0)
                Rpt.SetParameterValue("@ACCION", "0")

                Dim frm As New Reporte(Rpt)
                frm.CRViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                frm.Show()
                bResultado = False
            Else
                bResultado = True
            End If

        Catch ex As Exception
            HandleError(Me.Name, "ValidarNominaAlta", ex)
        Finally
            oReporte = Nothing
        End Try

        Return bResultado
    End Function

    Private Function GeneraAltaTarjetas() As Boolean
        Dim bResultado As Boolean = False
        Dim sProcedure As String = "GeneraAltaTarjetas"

        Dim dTabla As DataTable
        Dim sRenglon As String = Nothing
        Dim strStreamW As Stream = Nothing
        Dim strStreamWriter As StreamWriter = Nothing
        ' Donde guardamos los paths de los archivos que vamos a estar utilizando ..
        Dim PathArchivo As String = "", sCarpeta As String = ""
        'Dim sTotalRegistros As String
        Dim iRango1 As Integer = 0, iRango2 As Integer = 0
        Dim iTotalTrabajadores As Integer = 0 'Total de trabajadores con tarjetas de la semana para poder dividirlo entre el rango, para hacer los archivos
        Dim iFolio As Integer
        Dim sNombreTxt As String = ""

        Try
            Dim oSemana As New Class_NominaSemana(CInt(Me.CboSemana.SelectedValue))

            sCarpeta = Plaza.oSisPlazaNomina.RUTA_ALTAS_DISPERSIONES & "SEM" & oSemana.NUMERO_SEMANA.ToString

            If Directory.Exists(sCarpeta) = False Then ' si no existe la carpeta se crea
                Directory.CreateDirectory(sCarpeta)
            Else
                'Elimina todos los txt que empiezan con la palabra ALTA_
                For Each fichero As String In Directory.GetFiles(sCarpeta, "ALTA_*.txt")
                    File.Delete(fichero)
                Next
            End If

            iTotalTrabajadores = oSemana.ObtenerTotalTrabajadoresAltaTarjeta()

            'Dim x As Double = 0
            Dim iTotalesArchivos As Integer = 0
            Dim k As Integer = 0

            If txtLEN(Me.txtRango.Text) = True Then
                Me._RANGO = CInt(Me.txtRango.Text)
            Else
                MsgBox("Favor de capturar el rango de trabajadores.", MsgBoxStyle.Exclamation, sProcedure)
                Exit Function
            End If

            iTotalesArchivos = CInt(-Int(-(iTotalTrabajadores / Me._RANGO)))

            For k = 0 To iTotalesArchivos - 1
                'sNombreTxt = "ALTA_" & Format(Now(), "ddMMyyyy") & "_"
                sNombreTxt = "NI00136"
                iRango1 = iRango2
                iRango2 = iRango2 + Me._RANGO

                '    'procedimiento para imprimnir
                'Dim sql As New Class_find("SELECT ULTIMO_NUMERO_TXT_DISPERSION FROM NOMINA_SEMANA WHERE ID_NOMINA_TEMPORADA=" & Plaza.NOMINA_ID_NOMINA_TEMPORADA_ACTIVA & " AND NUMERO_SEMANA=" & Me.CboSemana.Text)

                'procedimiento para imprimnir
                If Me.txtConsecutivo.Text = valorNumerico(oSemana.ULTIMO_NUMERO_ARCHIVO_TXT_ALTAS.ToString).ToString Then
                    iFolio = CInt(valorNumerico(oSemana.ULTIMO_NUMERO_ARCHIVO_TXT_ALTAS))
                    If iFolio = 0 Then
                        iFolio += 1
                    End If
                    iFolio = iFolio + k
                Else
                    If CInt(Me.txtConsecutivo.Text) <= 0 Then
                        MsgBox("El consecutivo del archivo debe ser mayor a 0.", MsgBoxStyle.Exclamation, sProcedure)
                        Exit Function
                    End If
                    iFolio = CInt(Me.txtConsecutivo.Text)
                    iFolio = iFolio + k
                    'Ahi que actualizar el consecutivo de la semana

                End If

                sNombreTxt = sNombreTxt & Microsoft.VisualBasic.Right("0" & iFolio.ToString, 2) & ".alt"

                PathArchivo = sCarpeta & "\" & sNombreTxt

                If isExisteArchivo(PathArchivo) = True Then
                    'If MsgBox("El archivo correspondiente ya existe, desea sobreescribirlo?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "GeneraArchivoAltas") = MsgBoxResult.No Then
                    '    MsgBox("No se generó el archivo.", MsgBoxStyle.Exclamation, "GeneraArchivoAltas")
                    '    Exit Function
                    'Else
                    ''Se cambio porque agregaba al final del archivo
                    'strStreamW = File.Open(PathArchivo, FileMode.Open) 'Abrimos el archivo
                    'End If
                    File.Delete(PathArchivo)
                    strStreamW = File.Create(PathArchivo)
                Else
                    strStreamW = File.Create(PathArchivo)
                End If

                strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default) ' tipo de codificacion para escritura

                dTabla = oSemana.GeneraNominaAlta(True, iRango1, iRango2)

                If dTabla.Rows.Count < 1 Then
                    MsgBox("No se encontraron trabajadores con pago con tarjeta.", MsgBoxStyle.Exclamation, sProcedure)
                    strStreamWriter.Close()
                    File.Delete(PathArchivo)
                    Exit Function
                End If

                For Each drow As DataRow In dTabla.Rows
                    strStreamWriter.WriteLine(Replace(drow("TEXTO").ToString, "|", ""))
                Next

                ''-------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                ''FileOpen(NúmeroArchivo, "REING_" & iFolio.ToString & ".txt", OpenMode.Output)
                'sTotalRegistros = String.Format("{0,6}", dTabla.Rows.Count.ToString)
                'sTotalRegistros = sTotalRegistros.Replace(" ", "0")

                ''Tipo de registro =1 ; Núm. de cliente; Fecha de alta=formato AA/MM/DD;
                ''Secuencia del archivo;Total de altas ;filler=460 --total de caracteres de la linea 491
                'strStreamWriter.WriteLine("1" & String.Format("{0,12}", Empresa_Sistema.NUMERO_CLIENTE_BANCO.ToString) & String.Format("{0,08}", Format(Now(), "yyyyMMdd")) & _
                '                          String.Format("{0,4}", iFolio).Replace(" ", "0").ToString & sTotalRegistros & String.Format("{0,460}", ""))
                ''-------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                'For Each drow As DataRow In dTabla.Rows
                '    Dim kt1 As String = String.Format("{0,1}", "2")  'Tipo de registro
                '    Dim kt2 As String = String.Format("{0,1}", "1")  'Tipo de producto
                '    Dim kt3 As String = String.Format("{0,1}", "1")  'Tipo de entrega
                '    Dim Kt4 As String = String.Format("{0,16}", "1") 'Número de unidad de trabajo
                '    Kt4 = Kt4.Replace(" ", "0")
                '    Dim kt5 As String = String.Format("{0,2}", "01") 'Tipo de persona 01=Física
                '    Dim kt6 As String = String.Format("{0,-55}", drow(3).ToString & "," & drow(1).ToString & "/" & drow(2).ToString)
                '    kt6 = kt6.Replace("Ñ", "@")                      'Nombre trabajador (Nombre,ApPaterno/ApMaterno)
                '    Dim kt7 As String = String.Format("{0,8}", Format(CDate(drow(4).ToString), "yyyyMMdd")) 'Fecha nacimiento
                '    Dim kt8 As String = String.Format("{0,-36}", Empresa_Sistema.CALLE.Replace(".", "").ToString & " " & Empresa_Sistema.NUMERO_EXTERIOR.ToString) 'Calle y número
                '    Dim kt9 As String = String.Format("{0,-24}", Empresa_Sistema.COLONIA.ToString) '
                '    Dim kt10 As String = String.Format("{0,6}", Empresa_Sistema.CODIGO_POSTAL.ToString) '
                '    kt10 = kt10.Replace(" ", "0")
                '    Dim kt11 As String = String.Format("{0,-20}", Empresa_Sistema.Ciudad.ToString)
                '    Dim kt12 As String = String.Format("{0,2}", Plaza.CODIGO_ESTADO_NUMERICO.ToString)
                '    kt12 = kt12.Replace(" ", "0")
                '    Dim kt13 As String = String.Format("{0,16}", drow(5).ToString) 'Número de tarjera
                '    Dim kt14 As String = String.Format("{0,1}", "2") 'Forma de pago 0 = Por transacción | 1 = Por renta mensual 
                '    Dim kt15 As String = String.Format("{0,1}", "0") 'Asignación de Pago 0 = Empleado | 1 = Empresas 
                '    Dim kt16 As String = String.Format("{0,4}", "0001") 'Nacionalidad  0001 = Mexicano 
                '    Dim kt17 As String = String.Format("{0,297}", "") 'Filler

                '    strStreamWriter.WriteLine(kt1.ToString & kt2.ToString & kt3.ToString & Kt4.ToString & kt5.ToString & kt6.ToString & _
                '                              kt7.ToString & kt8.ToString & kt9.ToString & kt10.ToString & kt11.ToString & kt12.ToString & _
                '                              kt13.ToString & kt14.ToString & kt15.ToString & kt16.ToString & kt17.ToString)
                '    'escribimos en el archivo
                'Next

                strStreamWriter.Close() 'Cerramos
                bResultado = True
            Next

            MsgBox("El archivo fue generado con éxito en la ruta: " & PathArchivo, MsgBoxStyle.Information, sProcedure)

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    Public Function ValidarNominaDispersion() As Boolean
        Dim bResultado As Boolean = False
        Dim dTable As DataTable
        Dim StrFiltros As String = ""
        Dim Rpt As New ReportDocument
        Dim oReporte As Class_Reporte

        Try
            Dim oSemana As New Class_NominaSemana(CInt(Me.CboSemana.SelectedValue))
            dTable = oSemana.GeneraNominaDispercion("VALIDAR_DISPERSION", "")

            If dTable.Rows.Count > 0 Then
                MsgBox("Se encontraron trabajadores con datos incorrectos.", MsgBoxStyle.Exclamation, "ValidarNominaDispersion")

                oReporte = New Class_Reporte("RPT_NOMINA_GENERA_DISPERSION", Rpt)
                If Not oReporte.RptCargado Then
                    Return False
                End If
                Rpt.SetParameterValue("@ID_NOMINA_SEMANA", CInt(Me.CboSemana.SelectedValue))
                Rpt.SetParameterValue("@NOMBRE_TXT_DISPERSION", "")
                Rpt.SetParameterValue("@CONSECUTIVO", "1")
                Rpt.SetParameterValue("@RANGO", "100")
                Rpt.SetParameterValue("@ACCION", "VALIDAR_DISPERSION")

                Dim frm As New Reporte(Rpt)
                frm.CRViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                frm.Show()
            Else
                bResultado = True
            End If

        Catch ex As Exception
            HandleError(Me.Name, "ValidarNominaDispersion", ex)
        Finally
            oReporte = Nothing
        End Try

        Return bResultado
    End Function

    Private Sub Imprimir()
        Dim StrFiltros As String = ""
        Dim FormatoDeReporte As String = ""
        Dim Rpt As New ReportDocument
        Dim oReporte As Class_Reporte
        Try
            If Me.RdbNominaPuntoPago.Checked = True Then
                FormatoDeReporte = "RPT_NOMINA_GENERADA_POR_PUNTO_PAGO"
            ElseIf Me.rdbCostos.Checked = True Then
                FormatoDeReporte = "RPT_NOMINA_GENERADA_EMISION_COSTOS" 'viejo
            ElseIf Me.rdbEmisionCosto.Checked = True Then
                FormatoDeReporte = "RPT_NOMINA_GENERADA_COSTOS"
            ElseIf Me.rdbCostosPresupuestos.Checked = True Then
                FormatoDeReporte = "RPT_NOMINA_GENERADA_EMISION_COSTOS_Y_PRESUPUESTOS"
            ElseIf Me.RdbDistribucionEfectivo.Checked = True Then
                FormatoDeReporte = "RPT_NOMINA_GENERADA_EFECTIVO_Y_TOTALES_EFECTIVO"
            ElseIf Me.RdbTotales.Checked = True Then
                FormatoDeReporte = "RPT_NOMINA_GENERADA_EFECTIVO_Y_TOTALES"
            ElseIf Me.RdbDeducciones.Checked = True Then
                FormatoDeReporte = "RPT_NOMINA_GENERADA_DEDUCCIONES"
            ElseIf Me.rdbSobres.Checked = True Then
                FormatoDeReporte = "RPT_FORMATO_NOMINA_GENERA_SOBRES"
            ElseIf Me.rdbMultiPuntoPagos.Checked = True Then
                Me.ValidarNominaPuntosPago()
                Exit Sub
            ElseIf Me.rdbFirma.Checked = True Then
                FormatoDeReporte = "RPT_NOMINA_SEMANAL_LISTADO"
                'FormatoDeReporte = "RPT_NOMINA_GENERADA_POR_PUNTO_PAGO"
            ElseIf Me.rdbFletesPersonal.Checked = True Then
                FormatoDeReporte = "RPT_NOMINA_GENERADA_POR_PUNTO_PAGO_FLETES"
            End If

            oReporte = New Class_Reporte(FormatoDeReporte, Rpt)
            If Not oReporte.RptCargado Then
                Exit Sub
            End If

            Rpt.SetParameterValue("@ID_NOMINA_SEMANA", Me.CboSemana.SelectedValue)

            If Me.RdbNominaPuntoPago.Checked = True Or Me.rdbCostos.Checked = True Or rdbFirma.Checked = True Then
                Rpt.SetParameterValue("@CODIGO_PUNTO_PAGO", Me.cboPuntoPago.SelectedValue)
            ElseIf Me.RdbDistribucionEfectivo.Checked = True Or Me.RdbTotales.Checked = True Then
                Rpt.SetParameterValue("@CODIGO_PUNTO_PAGO", 0)
            ElseIf Me.rdbSobres.Checked = True Then
                Rpt.SetParameterValue("@CODIGO_PUNTO_PAGO", Me.cboPuntoPago.SelectedValue)
                Rpt.SetParameterValue("@RECIBE_PAGO_TARJETA_BANCARIA", IIf(Me.cboTipoPago.Text = "EFECTIVO", "0", "1").ToString)
            End If

            If Me.rdbFletesPersonal.Checked = True Then
                Rpt.SetParameterValue("@CODIGO_PUNTO_PAGO", Me.cboPuntoPago.SelectedValue)
                Rpt.SetParameterValue("@IMPORTE_FLETE", valorNumerico(Me.txtImporteFlete.Text))
            ElseIf Me.RdbNominaPuntoPago.Checked = True Then
                Rpt.SetParameterValue("@IMPORTE_FLETE", valorNumerico(Me.txtImporteFlete.Text))
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

    Private Function GeneraPoliza() As Boolean
        Dim bResultado As Boolean = False

        'Me.oSemana = New Class_NominaSemana(CInt(Me.CboSemana.SelectedValue.ToString))
        'Me.oSemana.Consultar()
        'If Me.oSemana.NOMINA_GENERADA = "1" Then

        '    Try
        '        If txtLEN(Me.oSemana.FOLIO_POLIZA.ToString) = False Then
        '            Me.oSemana.GeneraPolizaNomina()
        '            Me.oSemana.Consultar()
        '        End If

        '        Dim Child As New Frm_Contabilidad_Captura_Polizas()
        '        Child.FolioPolizaConsultaExterior = Me.oSemana.FOLIO_POLIZA.ToString()
        '        Child.ShowDialog()
        '        Child.Dispose()
        '        Me.Consultar()

        '        'ValidaPrePoliza = oFormaPoliza.FormaValidaParaGrabarLlamadoExterior
        '    Catch ex As Exception
        '        HandleError(Me.Text, "btnGeneraPoliza", ex)
        '    Finally

        '    End Try
        'End If

        Try

            Me.oSemana = New Class_NominaSemana(CInt(Me.CboSemana.SelectedValue.ToString))
            'Me.oSemana.Consultar()

            If Me.oSemana.NOMINA_GENERADA = "0" Then
                MsgBox("La nómina no esta cerrada, no es posible generar la póliza.", MsgBoxStyle.Exclamation, Me.Text)
                Exit Function
            End If

            'If txtLEN(Me.oSemana.FOLIO_POLIZA.ToString) = False Then
            '    Me.oSemana.GeneraPolizaNomina()
            '    Me.oSemana.Consultar()
            'End If
            Dim Child As New Frm_Contabilidad_Captura_Polizas(), dTabla As DataTable, i As Integer = 1, bPolizaAplicada As Boolean = False
            With Child
                If Me.oSemana.POLIZA_GENERADA = True Then

                    dTabla = oSemana.ObtienePrepoliza 'Se forza a regenerarla con esta linea

                    Dim oPoliza As New Class_Contabilidad_Poliza_Global(oSemana.FOLIO_POLIZA)

                    If oPoliza.ESTATUS_POLIZA = "A" Then
                        .FolioPolizaConsultaExterior = oSemana.FOLIO_POLIZA
                        .ShowDialog()
                        .Dispose()
                    Else
                        GoTo RegenerarPoliza
                    End If
                Else
RegenerarPoliza:
                    dTabla = oSemana.ObtienePrepoliza
                    Me.oSemana = New Class_NominaSemana(CInt(Me.CboSemana.SelectedValue.ToString))

                    Dim oPoliza As New Class_Contabilidad_Poliza_Global(oSemana.FOLIO_POLIZA)
                    .FolioPolizaConsultaExterior = oSemana.FOLIO_POLIZA
                    .ShowDialog()
                    .Dispose()

                    '.StartPosition = FormStartPosition.CenterScreen
                    '.ChildParaGrabar = True
                    '.CodigoDocumentoParaGrabar = "D"
                    '.DtpFecha.Value = Me.DtpFecha2.Value

                    '.TxtConcepto1.Text = IIf(dTabla.Rows.Count > 0, dTabla(0)("CONCEPTO").ToString, "").ToString
                    ''.lblFolioOrigen.Text = Me.TxtFolio.Text
                    '.TxtFolio.Text = IIf(dTabla.Rows.Count > 0, dTabla(0)("FOLIO_NOMINA").ToString, "").ToString
                    '.Grid1.Rows = 2
                    '.Grid1.Cols = 7
                    '.lblEstatus.Text = "N"

                    'For Each dRow As DataRow In dTabla.Rows
                    '    .Grid1.Cell(i, 1).Text = dRow("CUENTA_CONTABLE").ToString
                    '    .Grid1.Cell(i, 2).Text = dRow("NOMBRE_CUENTA").ToString
                    '    .Grid1.Cell(i, 3).Text = dRow("CONCEPTO").ToString
                    '    .Grid1.Cell(i, 4).Text = dRow("NATURALEZA_CONTABLE").ToString
                    '    .Grid1.Cell(i, 5).Text = dRow("CARGO").ToString
                    '    .Grid1.Cell(i, 6).Text = dRow("ABONO").ToString

                    '    i += 1
                    '    .Grid1.Rows = .Grid1.Rows + 1
                    'Next

                    '.ShowDialog()

                    'If .FormaValidaParaGrabarLlamadoExterior = True Then
                    '    bPolizaAplicada = .Aplicar(False, False)
                    '    If bPolizaAplicada = True Then
                    '        bResultado = Me.oSemana.GrabaFolioPoliza(.TxtFolio.Text)
                    '    End If
                    'End If

                    '.Dispose()
                End If

            End With

            'Dim Child As New Frm_Contabilidad_Captura_Polizas()
            'Child.FolioPolizaConsultaExterior = Me.oSemana.FOLIO_POLIZA.ToString()
            'Child.ShowDialog()
            'Child.Dispose()
            'Me.Consultar()

            'ValidaPrePoliza = oFormaPoliza.FormaValidaParaGrabarLlamadoExterior

        Catch ex As Exception
            HandleError(Me.Text, "GeneraPoliza", ex)
        Finally

        End Try
        Return bResultado
    End Function

    Private Sub GenerarNomina()
        Try
            Select Case Me.btnGeneraNomina.Text
                Case "Generar nómina"
                    ' If Me.ValidarNominaPuntosPago = True Then
                    Dim Child As New Frm_Nomina_Generada()
                    Child.ID_NOMINA_SEMANA = CInt(Me.CboSemana.SelectedValue.ToString)
                    Child.StartPosition = FormStartPosition.CenterScreen
                    Child.TcNomina.SelectedIndex = 0
                    Child.TcNomina.TabPages(0).Enabled = True
                    Child.TcNomina.TabPages(1).Enabled = False

                    Child.ShowDialog()
                    Child.Dispose()

                Case "Desaplicar nómina"
                    If MsgBox("Esta seguro de querer desaplicar la nómina?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then
                        Exit Sub
                    End If
                    Me.oSemana.DesaplicarNomina()
            End Select

            Me.Consultar()
            'End If
        Catch ex As Exception
            HandleError(Me.Name, "GenerarNomina", ex)
        End Try
    End Sub

    Private Sub GenerarDispersion()
        Try
            Dim sAccion As String = ""

            If Me.ValidarNominaDispersion() = True Then
                sAccion = "GENERAR_DISPERSION"

                Dim Child As New Frm_Nomina_Generada()

                Child.ID_NOMINA_SEMANA = CInt(Me.CboSemana.SelectedValue)
                Child.ACCION = sAccion
                Child.StartPosition = FormStartPosition.CenterScreen
                Child.TcNomina.SelectedIndex = 1
                Child.TcNomina.TabPages(1).Enabled = True
                Child.TcNomina.TabPages(0).Enabled = False
                Child.cboTxtArchivos.Text = ""
                Child.ShowDialog()
                Child.Dispose()
            End If
        Catch ex As Exception
            HandleError(Me.Name, "GenerarDispersion", ex)
        End Try
    End Sub

    Private Sub CambiaDiaSemana()
        Try
            Dim Columna As Integer, Renglon As Integer, vdg As String
            Dim dTabla As DataTable

            Columna = Me.GridSemana.Selection.FirstCol
            Renglon = Me.GridSemana.Selection.FirstRow

            Me.igyColumna = Columna
            Me.igyRenglon = Renglon

            vdg = Me.GridSemana.Cell(Renglon, Me.igyIdDia).Text
            If txtLEN(vdg) = False Then
                Me.InicializaGridDia()
                Exit Sub
            End If

            Me.oDia = New Class_NominaDia()
            Me.oDia.ID_NOMINA_DIA = CInt(Me.GridSemana.Cell(Renglon, Me.igyIdDia).Text)
            dTabla = Me.oDia.ObtenerDetalleHojas

            Me.GridDia.AutoRedraw = False

            Me.GridDia.Rows = 1
            For Each dRow As DataRow In dTabla.Rows
                Me.GridDia.AddItem(dRow(0).ToString & Chr(9) & dRow(1).ToString & Chr(9) & dRow(2).ToString & Chr(9) & dRow(3).ToString & Chr(9) & dRow(4).ToString & Chr(9) & dRow(5).ToString & Chr(9))
            Next
            dTabla.Dispose()

            If Me.GridDia.Rows = 1 Then
                Me.GridDia.Rows = 2
            End If

            Me.FormateaGridDia()
            Me.Totales()

            Me.GridDia.AutoRedraw = True
            Me.GridDia.Refresh()
        Catch ex As Exception
            HandleError(Me.Name, "CambiaDiaSemana", ex)
        End Try
    End Sub

    Private Sub AbrirHoja()
        Try
            Dim DColumna As Integer, DRenglon As Integer, vdg As String
            Dim Child As New Frm_Nomina_CapturaHoja(), Renglon As Integer

            DColumna = Me.GridDia.Selection.FirstCol
            DRenglon = Me.GridDia.Selection.FirstRow
            Renglon = Me.GridSemana.Selection.FirstRow

            If DColumna = 0 Or DRenglon = 0 Then
                DColumna = 1
                DRenglon = 1
                Me.GridDia.Cell(DRenglon, Me.igyDiaIdNominaHoja).SetFocus()
            End If

            vdg = Me.GridDia.Cell(DRenglon, Me.igyDiaIdNominaHoja).Text 'Grid.Rows(Renglon).Cell("FOLIO_POLIZA")
            If txtLEN(vdg) = False Then
                Exit Sub
            End If

            Child.ID_NOMINA_DIA = Me.oDia.ID_NOMINA_DIA
            Child.ID_NOMINA_HOJA = CInt(vdg)
            Child.txtSemana.Text = Me.CboSemana.Text
            Child.lblIdSemana.Text = Me.CboSemana.SelectedValue.ToString 'Me.CboSemana.SelectionLength.ToString 
            Child.DtpFecha.Value = CDate(Me.GridSemana.Cell(igyRenglon, Me.igyFecha).Text())
            Child.txtDia.Text = Me.GridSemana.Cell(igyRenglon, Me.igyNumDia).Text()
            If Renglon = 8 Then
                Child.ModoPercepcion = Frm_Nomina_CapturaHoja.enumModoPercepcion.OTRA_PERCEPCION
            Else
                Child.ModoPercepcion = Frm_Nomina_CapturaHoja.enumModoPercepcion.PERCECION
            End If
            Child.txtNombreDia.Text = Me.GridSemana.Cell(igyRenglon, Me.igyNombreDia).Text()
            Child.StartPosition = FormStartPosition.CenterScreen
            Child.ShowDialog()
            Child.Dispose()
            Me.Consultar()

            Me.GridSemana.Cell(igyRenglon, igyColumna).SetFocus()

        Catch ex As Exception
            HandleError(Me.Name, "AbrirHoja", ex)
        End Try
    End Sub

    Private Sub AgregarHoja()
        Try
            Dim Child As New Frm_Nomina_CapturaHoja()
            Dim Columna As Integer, Renglon As Integer, vdg As String

            Columna = Me.GridSemana.Selection.FirstCol
            Renglon = Me.GridSemana.Selection.FirstRow

            Me.igyColumna = Columna
            Me.igyRenglon = Renglon

            If Columna = 0 Or Renglon = 0 Then
                Columna = 1
                Renglon = 1
                Me.GridSemana.Cell(Renglon, Me.igyNumDia).SetFocus()
            End If

            vdg = Me.GridSemana.Cell(Renglon, Me.igyIdDia).Text 'Grid.Rows(Renglon).Cell("FOLIO_POLIZA")
            If txtLEN(vdg) = False Then
                oDia.NUMERO_DIA = CInt(Me.GridSemana.Cell(Renglon, Me.igyNumDia).Text())
                'oDia.NUMERO_SEMANA = CInt(Me.CboSemana.Text)
                oDia.FECHA = Format(CDate(Me.GridSemana.Cell(Renglon, Me.igyFecha).Text().ToString), "yyyy-dd-MM").ToString
                'oDia.CrearDia()
                Me.GridSemana.Cell(Renglon, Me.igyIdDia).Text() = oDia.ID_NOMINA_DIA.ToString
                vdg = oDia.ID_NOMINA_DIA.ToString
            End If

            Child.ID_NOMINA_DIA = CInt(vdg)
            Child.ID_NOMINA_HOJA = 0
            Child.txtSemana.Text = Me.CboSemana.Text
            Child.lblIdSemana.Text = Me.CboSemana.SelectedValue.ToString
            Child.DtpFecha.Value = CDate(Me.GridSemana.Cell(Renglon, Me.igyFecha).Text())
            Child.txtDia.Text = Me.GridSemana.Cell(Renglon, Me.igyNumDia).Text()
            Child.txtNombreDia.Text = Me.GridSemana.Cell(Renglon, Me.igyNombreDia).Text()
            If Renglon = 8 Then
                Child.ModoPercepcion = Frm_Nomina_CapturaHoja.enumModoPercepcion.OTRA_PERCEPCION
            Else
                Child.ModoPercepcion = Frm_Nomina_CapturaHoja.enumModoPercepcion.PERCECION
            End If
            Child.StartPosition = FormStartPosition.CenterScreen
            Child.ShowDialog()
            Child.Dispose()
            Me.Consultar()

            Me.GridSemana.Cell(igyRenglon, igyColumna).SetFocus()
        Catch ex As Exception
            HandleError(Me.Name, "AgregarHoja", ex)
        End Try
    End Sub

#End Region

End Class