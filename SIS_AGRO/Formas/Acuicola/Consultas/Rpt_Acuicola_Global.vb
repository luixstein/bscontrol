Option Strict On
Imports CrystalDecisions.CrystalReports.Engine

Public Class Rpt_Acuicola_Global

    Private Sub Rpt_Compras_Global_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DesplegarDivisiones()
        Me.DtFecha.Value = Date.Now
    End Sub

    Private Sub tsbConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbConsultar.Click
        Imprimir()
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub

    Private Sub event_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DtFecha.KeyPress, CboDivision.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub event_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCiclo.KeyDown, DtFecha.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtTAB(e)
        End If
    End Sub

    Private Sub cboDivision_KeyDown(sender As Object, e As KeyEventArgs) Handles CboDivision.KeyDown
        If e.KeyCode = Keys.Enter Then
            tsbConsultar.PerformClick()
        End If
    End Sub

    Private Sub txtCiclo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCiclo.KeyPress
        txtSoloNumerosEnteros(e)
        txtNoBeep(e)
    End Sub

    Private Sub DesplegarDivisiones()
        Try
            Dim oDivisiones As New Class_CatDivisionesAcuicola
            With Me.CboDivision
                .DisplayMember = "NOMBRE_DIVISION"
                .ValueMember = "CODIGO_DIVISION"
                Dim dView As New Data.DataView(oDivisiones.ObtenerElementosParaReportes)
                dView.Sort = "NOMBRE_DIVISION"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedValue = -1
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarAlmacenes", ex)
        End Try
    End Sub

    Private Sub Imprimir()
        Dim FormatoDeReporte As String = ""
        Dim Rpt As ReportDocument
        Rpt = New ReportDocument
        Dim oReporte As Class_Reporte
        Try
            If Me.Validar = False Then
                Exit Sub
            End If

            If Me.RbAlimentacion.Checked = True Then
                oReporte = New Class_Reporte("RPT_ACUICOLA_FORMATO_DIARIO_ALIMENTACION", Rpt, True)
            ElseIf Me.RbBiometrias.Checked = True Then
                oReporte = New Class_Reporte("RPT_ACUICOLA_BIOMETRIAS", Rpt, True)
            ElseIf Me.rbtParametros.Checked = True Then
                oReporte = New Class_Reporte("RPT_ACUICOLA_PARAMETROS", Rpt, True)
            Else
                MsgBox("Formato no válido.", MsgBoxStyle.Exclamation, Me.Text)
                Exit Sub
            End If

            If Not oReporte.RptCargado Then
                Exit Sub
            End If

            Rpt.SetParameterValue("@CODIGO_DIVISION", Me.CboDivision.SelectedValue)
            Rpt.SetParameterValue("@FECHA", Format(Me.DtFecha.Value, "yyyy-dd-MM"))
            Rpt.SetParameterValue("@CICLO", Me.txtCiclo.Text)

            Dim frm As New Reporte(Rpt)
            frm.CRViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            frm.Show()

        Catch ex As Exception
            HandleError(Me.Name, "Imprimir", ex)
        Finally
            oReporte = Nothing
        End Try
    End Sub

    Private Function Validar() As Boolean
        If txtLEN(Me.txtCiclo.Text) = False Then
            MsgBox("Capture el ciclo.", MsgBoxStyle.Exclamation, Me.Name)
            Me.txtCiclo.Focus()
            Return False
        End If

        Return True
    End Function

End Class