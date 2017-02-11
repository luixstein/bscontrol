Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine


Public Class Frm_Proyecto_presupuesto
    Private FormatoDeReporte As String = "RPT_PRESUPUESTO"

#Region "Constructor y destructor"
    Public Sub New()
        InitializeComponent()
        DesplegarEjercicios()

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

#End Region

#Region "Opciones"
    Private Sub tsbSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub

    Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click
        Me.Imprimir()
    End Sub
#End Region


#Region "Métodos y procedimientos"

    Private Sub Imprimir()
        Dim StrFiltros As String = ""
        Dim Rpt As ReportDocument
        Rpt = New ReportDocument
        Dim oReporte As Class_Reporte
        Try
            oReporte = New Class_Reporte(FormatoDeReporte, Rpt)

            If Not oReporte.RptCargado Then
                Exit Sub
            End If

            Rpt.SetParameterValue("@ID_EJERCICIO", Me.CmbEjercicio.SelectedValue)
            Rpt.SetParameterValue("@CODIGO_CULTIVO", Me.cboCultivo.SelectedValue)

            Dim frm As New Reporte(Rpt)
            frm.CRViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            frm.Show()

            'Rpt.SetParameterValue("@FILTRO_CONTRAPOLIZAS", CInt(IIf(Me.cbkFiltoContraPolizas.Checked, "1", "0").ToString).ToString)
        Catch ex As Exception
            HandleError(Me.Name, "Reporte de presupuestos", ex)
        Finally
            oReporte = Nothing
        End Try
    End Sub

    Private Sub DesplegarEjercicios()
        Dim oElementos As New Class_Contabilidad_Ejercicios
        With Me.CmbEjercicio
            .DisplayMember = "NOMBRE_EJERCICIO"
            .ValueMember = "ID_CON_EJERCICIO"
            Dim dView As New Data.DataView(oElementos.ObtenerEjercicios)
            'dView.Sort = "NOMBRE_EJERCICIO"
            .DataSource = dView
            If dView.Count > 0 Then
                .SelectedIndex = 0
            End If
        End With
    End Sub

    Private Sub DesplegarCultivos()
        Dim oElementos As New Class_CatCultivos
        With Me.cboCultivo
            .DisplayMember = "NOMBRE_CULTIVO"
            .ValueMember = "CODIGO_CULTIVO"

            Dim dView As New Data.DataView(oElementos.ObtenerElementosParaReportes)
            dView.Sort = "NOMBRE_CULTIVO"
            .DataSource = dView
            .Text = "TODOS"
        End With
    End Sub

    Private Sub CmbEjercicio_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbEjercicio.SelectedIndexChanged
        Dim sql As Class_find
        sql = New Class_find("SELECT FECHA_INICIO,FECHA_FINAL FROM CON_EJERCICIOS WHERE ID_CON_EJERCICIO=" & Me.CmbEjercicio.SelectedValue.ToString)
        Me.DtFechaDesde.Value = CDate(sql.Result1)
        Me.DtFechaHasta.Value = CDate(sql.Result2)
    End Sub
#End Region

#Region "Eventos Genericos"
    Private Sub txt_Enter(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim oTexBox As TextBox = CType(sender, TextBox)
        oTexBox.SelectAll()
    End Sub

    Private Sub txt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtFechaDesde.KeyDown, DtFechaHasta.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CmbEjercicio.KeyPress, cboCultivo.KeyPress, DtFechaDesde.KeyPress, DtFechaHasta.KeyPress
        txtNoBeep(e)
        txtSoloNumerosEnteros(e)
    End Sub
#End Region

    Private Sub Frm_Proyecto_presupuesto_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.DesplegarCultivos()
        Me.DesplegarEjercicios()
        Me.DtFechaDesde.Value = CDate(Format(Date.Now, "01-MM-yyyy"))
        Me.DtFechaHasta.Value = Date.Now
    End Sub
End Class