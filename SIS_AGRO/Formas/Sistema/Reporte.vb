Option Strict On

Imports CrystalDecisions.CrystalReports.Engine

Public Class Reporte

    Private _Rpt As New ReportDocument

#Region "Constructor y destructor"
    Public Sub New(ByVal Rpt As ReportDocument)
        InitializeComponent()
        Try
            Me._Rpt = Rpt
            Me.CRViewer.ReportSource = Me._Rpt
            'Me.Text = Me._Rpt.SummaryInfo.ReportTitle
            Me.Text = Me._Rpt.FileName

        Catch ex As Exception
            HandleError("Reporte", "New", ex)
        End Try
    End Sub
#End Region

    Private Sub Reporte_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me._Rpt.Dispose()
        Me.CRViewer.Dispose()
    End Sub
End Class