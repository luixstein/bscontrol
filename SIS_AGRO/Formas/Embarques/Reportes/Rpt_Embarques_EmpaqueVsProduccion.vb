Imports CrystalDecisions.CrystalReports.Engine

Public Class Rpt_Embarques_EmpaqueVsProduccion


    Private Sub DesplegarEmpaques()
        Try
            Dim oElementos As New Class_CatEmpaques
            With Me.CboEmpaque
                .DisplayMember = "NOMBRE_EMPAQUE"
                .ValueMember = "CODIGO_EMPAQUE"
                Dim dView As New Data.DataView(oElementos.ObtenerElementos)
                ' dView.Sort = "NOMBRE_EMPAQUE"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedIndex = 0
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarEmpaques", ex)
        End Try
    End Sub

    Private Sub Rpt_Embarques_EmpaqueVsProduccion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.DesplegarEmpaques()

        Dim sql As New Class_find("SELECT FECHA_INICIO FROM CON_EJERCICIOS WHERE ID_CON_EJERCICIO=" & Plaza.ID_CON_EJERCICIO)

        Me.DtFechaDesde.Value = CDate(sql.Result1.ToString)
        Me.DtFechaHasta.Value = Date.Now
    End Sub

    Private Function ValidarPeriodo() As Boolean
        Me.DtFechaDesde.Enabled = False
        Me.DtFechaDesde.Enabled = True

        Me.DtFechaHasta.Enabled = False
        Me.DtFechaHasta.Enabled = True

        If Me.DtFechaDesde.Value > Me.DtFechaHasta.Value Then
            MsgBox("Rango de fechas inválidas.", MsgBoxStyle.Exclamation, Me.Name)
            Me.DtFechaDesde.Focus()
            Exit Function
        End If
        ValidarPeriodo = True
    End Function

    Private Sub Consultar()
        Dim FormatoDeReporte As String = ""
        Dim Rpt As ReportDocument
        Rpt = New ReportDocument
        Dim oReporte As Class_Reporte
        Try
            If Me.ValidarPeriodo = False Then
                Exit Sub
            End If

            If Me.rdbCultivo.Checked = True Then
                FormatoDeReporte = "RPT_EMB_EMPAQUE_VS_PRODUCCION"
            Else
                FormatoDeReporte = "RPT_EMB_EMPAQUE_VS_PRODUCCION_DETALLE"
            End If

            oReporte = New Class_Reporte(FormatoDeReporte, Rpt)
            Rpt.SetParameterValue("@FECHA1", Format(Me.DtFechaDesde.Value, "yyyy-dd-MM"))
            Rpt.SetParameterValue("@FECHA2", Format(Me.DtFechaHasta.Value, "yyyy-dd-MM"))
            Rpt.SetParameterValue("@CODIGO_EMPAQUE", Me.CboEmpaque.SelectedValue.ToString)
            Rpt.SetParameterValue("@AGRUPADO", IIf(Me.rdbCultivo.Checked = True, "1", "0"))

            Dim frm As New Reporte(Rpt)
            frm.CRViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            frm.Show()
        Catch ex As Exception
            HandleError(Me.Name, "Consultar", ex)
        Finally
            oReporte = Nothing
        End Try
    End Sub

    Private Sub tsbConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbConsultar.Click
        If Me.ValidarPeriodo = True Then
            Me.Consultar()
        End If
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub

    Private Sub DtFechaHasta_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DtFechaHasta.KeyPress, DtFechaDesde.KeyPress, CboEmpaque.KeyPress
        txtNoBeep(e)
    End Sub
End Class