Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class Frm_Imprimir_Embarques

    Private _FolioEmbarque As String = ""
    Private oEmbarque As New Class_Embarques_EmbarqueGlobal

    Public WriteOnly Property FolioEmbarque() As String
        Set(ByVal Value As String)
            Me._FolioEmbarque = Value
        End Set
    End Property

    Private Sub Imprimir()
        Dim Rpt As ReportDocument
        Rpt = New ReportDocument
        Dim oReporte As Class_Reporte
        Try

            If Me.RdbCartaRespectiva.Checked = True Then
                oReporte = New Class_Reporte(Me.oEmbarque.Nombre_Formato, Rpt, False)
            ElseIf Me.RdbFactura.Checked = True Then
                oReporte = New Class_Reporte(Me.oEmbarque.Nombre_Factura, Rpt, False)
            ElseIf Me.RdbManifiestoAduana.Checked = True Then
                oReporte = New Class_Reporte(Me.oEmbarque.Nombre_Manifiesto, Rpt, False)
            Else
                oReporte = New Class_Reporte(Me.oEmbarque.Nombre_Control_Embarques, Rpt, False)
                'MsgBox("Pendiente por realizar.", MsgBoxStyle.Exclamation, "Imprimir")
                'Exit Sub
            End If
            If Not oReporte.RptCargado Then
                Exit Sub
            End If
            Rpt.SetParameterValue("@FOLIO_EMBARQUE", Me._FolioEmbarque.ToString)
            Dim frm As New Reporte(Rpt)
            frm.CRViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            frm.Show()
        Catch ex As Exception
            HandleError(Me.Name, "Imprimir", ex)
        Finally
            oReporte = Nothing
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click

        Me.Imprimir()

    End Sub
End Class