Option Strict On
Imports CrystalDecisions.CrystalReports.Engine

Public Class Rpt_Acuicola_AlimentacionDetalle

    Private Sub Rpt_Acuicola_AlimentacionDetalle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DesplegarDivisiones()
        Me.DtFecha1.Value = CDate(Format(Me.DtFecha1.Value, "01/01/" & Date.Now.Year))
        Me.DtFecha2.Value = Date.Now
        Me.CboLote.Enabled = False
    End Sub

    Private Sub tsbConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbConsultar.Click
        Imprimir()
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub

    Private Sub event_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DtFecha1.KeyPress, CboDivision.KeyPress, CboLote.KeyPress, DtFecha2.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub event_KeyDown(sender As Object, e As KeyEventArgs) Handles CboDivision.KeyDown, CboLote.KeyDown, DtFecha1.KeyDown, txtCiclo.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtTAB(e)
        End If
    End Sub

    Private Sub txtCiclo_KeyDown(sender As Object, e As KeyEventArgs) Handles DtFecha2.KeyDown
        If e.KeyCode = Keys.Enter Then
            tsbConsultar.PerformClick()
        End If
    End Sub

    Private Sub txtCiclo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCiclo.KeyPress
        txtSoloNumerosEnteros(e)
        txtNoBeep(e)
    End Sub

    Private Sub CboDivision_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboDivision.SelectedIndexChanged
        If Me.CboDivision.SelectedIndex <> -1 Then
            Me.CboLote.Enabled = True
            Me.DesplegarLotes(Me.CboDivision.SelectedValue.ToString)
        End If
    End Sub

    Private Sub CkbCiclo_CheckedChanged(sender As Object, e As EventArgs) Handles CkbCiclo.CheckedChanged
        If Me.CkbCiclo.Checked = True Then
            Me.gbCiclo.Enabled = True
        Else
            Me.gbCiclo.Enabled = False
        End If
    End Sub

    Private Sub DesplegarDivisiones()
        Try
            Dim oDivisiones As New Class_CatDivisionesAcuicola
            With Me.CboDivision
                .DisplayMember = "NOMBRE_DIVISION"
                .ValueMember = "CODIGO_DIVISION"
                Dim dView As New Data.DataView(oDivisiones.ObtenerElementosActivos)
                dView.Sort = "NOMBRE_DIVISION"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedValue = -1
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarDivisiones", ex)
        End Try
    End Sub

    Private Sub DesplegarLotes(ByVal sCodigoDivision As String)
        Try
            Dim oParametrosDetalle As New Class_CatParametrosAcuicolaDetalle
            With Me.CboLote
                .DisplayMember = "NOMBRE_LOTE"
                .ValueMember = "CODIGO_LOTE"
                Dim dView As New Data.DataView(oParametrosDetalle.ObtenerEstanquesPorDivision(sCodigoDivision))
                dView.Sort = "NOMBRE_LOTE"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedValue = -1
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarLotes", ex)
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

            oReporte = New Class_Reporte("RPT_ACUICOLA_ALIMENTACION_DETALLE", Rpt, True)

            If Not oReporte.RptCargado Then
                Exit Sub
            End If

            Rpt.SetParameterValue("@CODIGO_DIVISION", Me.CboDivision.SelectedValue)
            Rpt.SetParameterValue("@CODIGO_LOTE", Me.CboLote.SelectedValue)
            Rpt.SetParameterValue("@FECHA1", Format(Me.DtFecha1.Value, "yyyy-dd-MM"))
            Rpt.SetParameterValue("@FECHA2", Format(Me.DtFecha2.Value, "yyyy-dd-MM"))
            Rpt.SetParameterValue("@CICLO", IIf(Me.CkbCiclo.Checked, Me.txtCiclo.Text, 0))

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
        If Me.CboDivision.SelectedIndex = -1 Then
            MsgBox("Seleccione una división", MsgBoxStyle.Exclamation, Me.Text)
            Me.CboDivision.Focus()
            Return False
        End If

        If Me.CboLote.SelectedIndex = -1 Then
            MsgBox("Seleccione un estanque", MsgBoxStyle.Exclamation, Me.Text)
            Me.CboLote.Focus()
            Return False
        End If

        If CkbCiclo.Checked = True AndAlso txtLEN(Me.txtCiclo.Text) = False Then
            MsgBox("Capture el ciclo.", MsgBoxStyle.Exclamation, Me.Name)
            Me.txtCiclo.Focus()
            Return False
        End If

        Return True
    End Function

End Class