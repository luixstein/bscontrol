Option Strict On

Imports CrystalDecisions.CrystalReports.Engine

Public Class Rpt_CentroCostos

#Region "Opciones"
    Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
        Me.Imprimir()
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub
#End Region

#Region "Eventos de objetos"
#Region "Eventos"
    Private Sub Frm_Nomina_CapturaHoja_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.DesplegarCentroCosto()
        Me.DesplegarCategorias()
        Me.DesplegarConceptos()
        Me.DtFechaDesde.Value = CDate("01/" & Now.Month & "/" & Now.Year)
    End Sub
#End Region

#Region "Eventos Genericos"
    Private Sub txtTextoKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) ' Handles 
        txtNoBeep(e)
    End Sub
    '
    Private Sub txtNumerosEnterosKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) ' Handles txtCantidadPalets.KeyPress, TxtFolio.KeyPress, TxtTotalPeso.KeyPress, txtFolioPalet1Etiquetas.KeyPress, txtFolioPalet2Etiquetas.KeyPress
        txtSoloNumerosEnteros(e)
        txtNoBeep(e)
    End Sub

    Private Sub txtKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) 'Handles CboEmpaque.KeyPress, DtpFecha.KeyPress
        txtNoBeep(e)
    End Sub
#End Region

#End Region

#Region "Métodos y procedimientos"

    Private Sub DesplegarCentroCosto()
        Try
            Dim oElementos As New Class_CatCentroCostos
            With Me.CboCentroCosto
                .DisplayMember = "NOMBRE_CENTRO_COSTO"
                .ValueMember = "CODIGO_CENTRO_COSTO"
                Dim dView As New Data.DataView(oElementos.ObtenerElementosParaReportes())
                dView.Sort = "NOMBRE_CENTRO_COSTO"
                .DataSource = dView
                If dView.Count > 0 Then
                    '.SelectedIndex = -1
                    .SelectedValue = -1
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarCentrosCostos", ex)
        End Try
    End Sub

    Private Sub DesplegarConceptos()
        Try
            Dim oElementos As New Class_CatConceptos
            With Me.cboConcepto
                .DisplayMember = "NOMBRE_CONCEPTO"
                .ValueMember = "CODIGO_CONCEPTO"
                Dim dView As New Data.DataView(oElementos.ObtenerElementosParaReportes())
                dView.Sort = "NOMBRE_CONCEPTO"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedValue = -1
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarConceptos", ex)
        End Try
    End Sub

    Private Sub DesplegarCategorias()
        Try
            Dim oElementos As New Class_CatCategorias
            With Me.cboCategoria
                .DataSource = Nothing
                .DisplayMember = "NOMBRE_CATEGORIA"
                .ValueMember = "CODIGO_CATEGORIA"
                Dim dView As New Data.DataView(oElementos.ObtenerElementosParaReportes())
                dView.Sort = "NOMBRE_CATEGORIA"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedValue = -1
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarCategorias", ex)
        End Try
    End Sub

    Private Sub Imprimir()
        Dim formato As String
        If Me.RbtAgrupado.Checked = True Then
            formato = "RPT_CENTRO_COSTOS_AGRUPADO"
        Else
            formato = "RPT_CENTRO_COSTOS_DETALLADO"
        End If
        Dim StrFiltros As String = ""
        Dim Rpt As New ReportDocument
        Dim oReporte As Class_Reporte
        Try
            oReporte = New Class_Reporte(formato, Rpt)

            If Not oReporte.RptCargado Then
                Exit Sub
            End If
            Rpt.SetParameterValue("@FECHA1", Format(Me.DtFechaDesde.Value, "yyyy-dd-MM"))
            Rpt.SetParameterValue("@FECHA2", Format(Me.DtFechaHasta.Value, "yyyy-dd-MM"))
            Rpt.SetParameterValue("@CODIGO_CENTRO_COSTO", Me.CboCentroCosto.SelectedValue.ToString)
            Rpt.SetParameterValue("@CODIGO_CATEGORIA", Me.cboCategoria.SelectedValue.ToString)
            Rpt.SetParameterValue("@CODIGO_CONCEPTO", Me.cboConcepto.SelectedValue.ToString)

            Dim frm As New Reporte(Rpt)
            frm.CRViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            frm.Show()
        Catch ex As Exception
            HandleError(Me.Name, "Reporte centros de costos", ex)
        Finally
            oReporte = Nothing
        End Try
    End Sub
#End Region


End Class