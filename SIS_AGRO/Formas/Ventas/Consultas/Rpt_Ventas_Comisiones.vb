Imports CrystalDecisions.CrystalReports.Engine

Public Class Rpt_Ventas_Comisiones

#Region "Opciones"
    Private Sub tsbConsultar_Click(sender As Object, e As EventArgs) Handles tsbConsultar.Click
        Me.Consultar()
    End Sub

    Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub
#End Region

#Region "Eventos"
    Private Sub Rpt_Ventas_Comisiones_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.DtFechaDesde.Value = FechaActualINI()
        Me.DtFechaHasta.Value = Date.Now

        Me.DesplegarVendedores()
    End Sub
#End Region

#Region "Eventos Genéricos"
    Private Sub txt_KeyDown(sender As Object, e As KeyEventArgs) Handles DtFechaDesde.KeyDown, DtFechaHasta.KeyDown, cboVendedor.KeyDown, txtComision6.KeyDown, txtComision37.KeyDown,
            txtComision60.KeyDown, txtComisionMas90.KeyDown
        txtTAB(e)
    End Sub

    Private Sub txtSoloNumericos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtComision6.KeyPress, txtComision37.KeyPress, txtComision60.KeyPress, txtComision75.KeyPress,
    txtComision90.KeyPress, txtComisionMas90.KeyPress
        txtSoloNumerosDecimales(e, Me.txtComisionMas90.Text)
    End Sub
#End Region

#Region "Métodos y procedimientos"
    Private Sub DesplegarVendedores()
        Dim oVendedores As New Class_CatVendedores
        Try
            With Me.cboVendedor
                .DisplayMember = "NOMBRE_VENDEDOR"
                .ValueMember = "CODIGO_VENDEDOR"
                Dim dView As New Data.DataView(oVendedores.ObtenerVendedoresParaReportes())
                dView.Sort = "NOMBRE_VENDEDOR"
                .DataSource = dView
                .SelectedValue = 0
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarVendedores", ex)
        End Try
    End Sub

    Private Sub Consultar()
        Dim FormatoDeReporte As String = ""
        Dim Rpt As New ReportDocument
        Dim oReporte As Class_Reporte
        Try
            FormatoDeReporte = "RPT_VENTAS_COMISIONES"

            'If Me.RbtFormatoGlobal.Checked Then
            '    FormatoDeReporte = "RPT_VENTAS_COMISIONES"
            'Else
            '    FormatoDeReporte = "RPT_VENTAS_COMISIONES_DETALLADO"
            'End If


            oReporte = New Class_Reporte(FormatoDeReporte, Rpt)

            Rpt.SetParameterValue("@FECHA1", Format(Me.DtFechaDesde.Value, "yyyy-dd-MM"))
            Rpt.SetParameterValue("@FECHA2", Format(Me.DtFechaHasta.Value, "yyyy-dd-MM"))
            Rpt.SetParameterValue("@CODIGO_VENDEDOR", Me.cboVendedor.SelectedValue)
            Rpt.SetParameterValue("@PTAJE_COMISION_6", valorNumericoD(Me.txtComision6.Text))
            Rpt.SetParameterValue("@PTAJE_COMISION_37", valorNumericoD(Me.txtComision37.Text))
            Rpt.SetParameterValue("@PTAJE_COMISION_60", valorNumericoD(Me.txtComision60.Text))
            Rpt.SetParameterValue("@PTAJE_COMISION_75", valorNumericoD(Me.txtComision75.Text))
            Rpt.SetParameterValue("@PTAJE_COMISION_90", valorNumericoD(Me.txtComision90.Text))
            Rpt.SetParameterValue("@PTAJE_COMISION_MAS90", valorNumericoD(Me.txtComisionMas90.Text))

            Dim frm As New Reporte(Rpt)
            frm.CRViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            frm.Show()
        Catch ex As Exception
            HandleError(Me.Name, "Consultar", ex)
        Finally
            oReporte = Nothing
        End Try
    End Sub

#End Region

End Class