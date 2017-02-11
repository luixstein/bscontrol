
Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class Rpt_Embarques_SinSalidaEmpaque
    Private Sub tsbConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbConsultar.Click
        Consultar()
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub

    Private Sub Consultar()
        Dim FormatoDeReporte As String = ""
        Dim Rpt As ReportDocument
        Rpt = New ReportDocument
        Dim oReporte As Class_Reporte
        Try

            FormatoDeReporte = "RPT_EMBARQUES_SIN_SALIDAS_EMPAQUE_GENERADAS"

            oReporte = New Class_Reporte(FormatoDeReporte, Rpt)
            Rpt.SetParameterValue("@TIPO_PALET", Me.cboTipoPalet.Text)
            Rpt.SetParameterValue("@CODIGO_PLAZA", Usuario.Codigo_Plaza)

            Dim frm As New Reporte(Rpt)
            frm.CRViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            frm.Show()
        Catch ex As Exception
            HandleError(Me.Name, "Consultar", ex)
        Finally
            oReporte = Nothing
        End Try
    End Sub

    Private Sub Rpt_Embarques_SinSalidaEmpaque_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.cboTipoPalet.Text = "TODOS"
        Me.cboTipoPalet.Focus()
    End Sub

    Private Sub cboTipoPalet_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTipoPalet.KeyDown
        Me.tsbConsultar.PerformClick()
    End Sub

End Class