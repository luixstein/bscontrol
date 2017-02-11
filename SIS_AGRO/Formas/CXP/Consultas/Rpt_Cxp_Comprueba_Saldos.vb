Option Strict On
Imports CrystalDecisions.CrystalReports.Engine

Public Class Rpt_Cxp_Comprueba_Saldos

    Private Sub tsbConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbConsultar.Click
        Consultar()
    End Sub

    Private Sub Consultar()
        Dim FormatoDeReporte As String = ""
        Dim Rpt As ReportDocument
        Rpt = New ReportDocument
        Dim oReporte As Class_Reporte

        Try
            oReporte = New Class_Reporte("RPT_CXP_COMPRUEBA_SALDOS_CONTRA_CONTABILIDAD", Rpt, True)
            If Not oReporte.RptCargado Then
                Exit Sub
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

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub
End Class