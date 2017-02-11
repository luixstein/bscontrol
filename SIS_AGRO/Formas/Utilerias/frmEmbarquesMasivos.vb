Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient

Public Class frmEmbarquesMasivos

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Imprimir()
    End Sub

    Private Sub Imprimir()
        Dim sFolioEmbarque As String = "", _Conexion As New SqlConnection(Empresa_Sistema.conexion)
        Try

            Dim dTable As New DataTable
            Dim ds As New SqlDataAdapter("SELECT G.FOLIO_EMBARQUE FROM EMB_EMBARQUE_GLOBAL G INNER JOIN CAT_CLIENTES C ON(G.CODIGO_CLIENTE=C.CODIGO_CLIENTE) " & _
                        "WHERE G.ESTATUS_EMBARQUE='A'  ", _Conexion)
            ds.Fill(dTable)

            For Each dRow In dTable.Rows
                sFolioEmbarque = dRow("FOLIO_EMBARQUE").ToString

                Dim Rpt As New ReportDocument
                Dim oReporte As New Class_Reporte("RPT_FORMATO_EMBARQUES_FACTURA", Rpt, False)

                If Not oReporte.RptCargado Then
                    Exit Sub
                End If
                Rpt.SetParameterValue("@FOLIO_EMBARQUE", sFolioEmbarque)

                Rpt.ExportToDisk(ExportFormatType.PortableDocFormat, "C:\Embarques bi\" & sFolioEmbarque & ".PDF")

                oReporte = Nothing
                Rpt.Dispose()
            Next

            MsgBox("Proceso terminado.", MsgBoxStyle.Information, Me.Text)

        Catch ex As Exception
            MsgBox(sFolioEmbarque)
            HandleError(Me.Name, "Imprimir", ex)
        End Try


    End Sub


End Class