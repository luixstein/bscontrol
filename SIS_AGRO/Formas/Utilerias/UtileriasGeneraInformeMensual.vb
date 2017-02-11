Option Strict On
Imports CrystalDecisions.CrystalReports.Engine

Public Class UtileriasGeneraInformeMensual
    Dim sRutaArchivo As String

    Private Sub btnGenerarInforme_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerarInforme.Click
        sRutaArchivo = Me.txtRuta.Text
        GeneraInformeMensual(sRutaArchivo, CShort(Me.dtpMes.Value.Month), CShort(Me.dtpAño.Value.Year))
    End Sub

    Private Sub UtileriasGeneraInformeMensual_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.dtpAño.Value = Now
        Me.dtpMes.Value = Now
        Me.cboEstado.Text = "ACTIVOS"
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Imprimir()
    End Sub

    Private Sub Imprimir()
        Dim Rpt As ReportDocument
        Rpt = New ReportDocument
        Dim oReporte As Class_Reporte
        Try
            oReporte = New Class_Reporte("RPT_VENTAS_INFORME_MENSUAL_FACTURACION_ELECTRONICA", Rpt, True)

            If Not oReporte.RptCargado Then
                Exit Sub
            End If

            Rpt.SetParameterValue("@ANIO", Me.dtpAño.Value.Year)
            Rpt.SetParameterValue("@MES", Me.dtpMes.Value.Month)
            Rpt.SetParameterValue("@STATUS", Me.cboEstado.Text.Substring(0, 1))

            Dim frm As New Reporte(Rpt)
            frm.CRViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            frm.ShowDialog()
        Catch ex As Exception
            HandleError(Me.Name, "Imprimir", ex)
        Finally
            oReporte = Nothing
        End Try
    End Sub
End Class