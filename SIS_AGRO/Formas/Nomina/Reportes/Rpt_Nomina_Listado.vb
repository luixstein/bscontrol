Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class Rpt_Nomina_Listado

    Private Sub tsbConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbConsultar.Click
        Consultar()
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub

    Private Sub Consultar()
        Dim FormatoDeReporte As String = "RPT_NOMINA_LISTADO"
        Dim Rpt As ReportDocument
        Dim filtroFecha As String = "0"
        If Me.cbFiltro.Checked = True Then
            filtroFecha = "1"
        Else
            filtroFecha = "0"
        End If
        Rpt = New ReportDocument
        Dim oReporte As Class_Reporte
        Try
            oReporte = New Class_Reporte(FormatoDeReporte, Rpt)
            If Not oReporte.RptCargado Then
                Exit Sub
            End If
            Rpt.SetParameterValue("@FILTRO", filtroFecha)
            Rpt.SetParameterValue("@FECHA1", Format(Me.dtFechaDesde.Value, "yyyy-dd-MM").ToString)
            Rpt.SetParameterValue("@FECHA2", Format(Me.dtFechaHasta.Value, "yyyy-dd-MM").ToString)

            Dim frm As New Reporte(Rpt)
            frm.CRViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            frm.Show()
        Catch ex As Exception
            HandleError(Me.Name, "Consultar", ex)
        Finally
            oReporte = Nothing
        End Try
    End Sub

    Private Sub cbFiltro_CheckedChanged(sender As Object, e As EventArgs) Handles cbFiltro.CheckedChanged
        If Me.cbFiltro.Checked = True Then
            GroupBox1.Enabled = True
        Else
            Me.GroupBox1.Enabled = False
        End If
    End Sub
End Class