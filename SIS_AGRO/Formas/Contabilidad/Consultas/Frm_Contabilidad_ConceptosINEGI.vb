Option Strict On
Imports CrystalDecisions.CrystalReports.Engine

Public Class Frm_Contabilidad_ConceptosINEGI
    Private FormatoDeReporte As String

#Region "Constructor y destructor"
    Public Sub New()
        InitializeComponent()
        Me.DesplegarEjercicios()
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
#End Region


#Region "Opciones"
    Private Sub tsbConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If ValidarCuentas() = True Then
        If Me.ValidarPeriodo() Then
            Me.Imprimir()
        End If
        'End If
    End Sub

    Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click
        If Me.ValidarPeriodo() Then
            Me.Imprimir()
        End If
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub
#End Region

#Region "Métodos y procedimientos"
    Private Sub DesplegarEjercicios()
        Dim oElementos As New Class_Contabilidad_Ejercicios
        With Me.CmbEjercicio
            .DisplayMember = "NOMBRE_EJERCICIO"
            .ValueMember = "ID_CON_EJERCICIO"

            Dim dView As New Data.DataView(oElementos.ObtenerEjercicios)
            .DataSource = dView
            If dView.Count > 0 Then
                'Dim Ejercicio As New Class_find("SELECT ID_CON_EJERCICIO FROM CON_EJERCICIOS WHERE '" & Format(Date.Now, "yyyy-dd-MM") & "' BETWEEN FECHA_INICIO AND FECHA_FINAL AND TIPO_CONTABILIDAD='FN'")
                .SelectedValue = Plaza.ID_CON_EJERCICIO.ToString 'Ejercicio.Result1.ToString
            End If
        End With
    End Sub

    Private Function ValidarPeriodo() As Boolean
        Me.DtFechaDesde.Enabled = False
        Me.DtFechaDesde.Enabled = True
        Me.DtFechaHasta.Enabled = False
        Me.DtFechaHasta.Enabled = True

        If Me.DtFechaDesde.Value > Me.DtFechaHasta.Value Then
            MsgBox("Rango de fechas inválidas.", MsgBoxStyle.Exclamation, Me.Name)
            Exit Function
        End If

        Dim ValidaPeriodo As New Class_find("SELECT 1 FROM CON_EJERCICIOS WHERE (('" & Format(Me.DtFechaDesde.Value, "yyyy-dd-MM") & "' BETWEEN FECHA_INICIO AND FECHA_FINAL)) AND (('" & Format(Me.DtFechaHasta.Value, "yyyy-dd-MM") & "' BETWEEN FECHA_INICIO AND FECHA_FINAL)) AND ID_CON_EJERCICIO=" & Me.CmbEjercicio.SelectedValue.ToString)
        If ValidaPeriodo.Result1.Length <= 0 Then
            MsgBox("El rango especificado esta fuera del rango del ejercicio.", MsgBoxStyle.Exclamation, Me.Name)
            Exit Function
        End If
        ValidarPeriodo = True
    End Function

    Private Sub CmbEjercicio_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbEjercicio.SelectedIndexChanged
        Dim sql As Class_find
        sql = New Class_find("SELECT FECHA_INICIO,FECHA_FINAL FROM CON_EJERCICIOS WHERE ID_CON_EJERCICIO=" & Me.CmbEjercicio.SelectedValue.ToString)
        Me.DtFechaDesde.Value = CDate(sql.Result1)
        Me.DtFechaHasta.Value = CDate(sql.Result2)
        ' Me.CmbEjercicio.SelectedValue = EmpresaParametros.ID_CON_EJERCICIO
    End Sub

    Private Sub DtFechaDesde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtFechaDesde.ValueChanged
        If Me.Visible = False Then
            Exit Sub
        End If
        Dim sql As Class_find
        sql = New Class_find("SELECT FECHA_INICIO,FECHA_FINAL FROM CON_EJERCICIOS WHERE ID_CON_EJERCICIO='" & Me.CmbEjercicio.SelectedValue.ToString & "'")
        If Me.DtFechaDesde.Value < CDate(sql.Result1) Then
            Me.DtFechaDesde.Value = CDate(sql.Result1)
        End If
        If Me.DtFechaDesde.Value > CDate(sql.Result2) Then
            Me.DtFechaDesde.Value = CDate(sql.Result2)
        End If
    End Sub

    Private Sub DtFechaHasta_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtFechaHasta.ValueChanged
        If Me.Visible = False Then
            Exit Sub
        End If
        Dim sql As Class_find
        sql = New Class_find("SELECT FECHA_INICIO,FECHA_FINAL FROM CON_EJERCICIOS WHERE ID_CON_EJERCICIO='" & Me.CmbEjercicio.SelectedValue.ToString & "'")
        If Me.DtFechaHasta.Value < CDate(sql.Result1) Then
            Me.DtFechaHasta.Value = CDate(sql.Result1)
        End If
        If Me.DtFechaHasta.Value > CDate(sql.Result2) Then
            Me.DtFechaHasta.Value = CDate(sql.Result2)
        End If
    End Sub

    Private Sub Imprimir()
        Dim StrFiltros As String = ""
        Dim Rpt As ReportDocument
        Rpt = New ReportDocument
        Dim oReporte As Class_Reporte
        Try
            If Me.ValidarPeriodo = False Then
                Exit Sub
            End If

            If RdbDetalle.Checked = True Then
                FormatoDeReporte = "RPT_CONTABILIDAD_CONCEPTOS_INEGI_DETALLE"
            Else
                FormatoDeReporte = "RPT_CONTABILIDAD_CONCEPTOS_INEGI_RESUMEN"
            End If

            oReporte = New Class_Reporte(FormatoDeReporte, Rpt)

            Rpt.SetParameterValue("@FECHA1", Format(Me.DtFechaDesde.Value, "yyyy-dd-MM"))
            Rpt.SetParameterValue("@FECHA2", Format(Me.DtFechaHasta.Value, "yyyy-dd-MM"))
            Rpt.SetParameterValue("@ID_CON_EJERCICIO", Me.CmbEjercicio.SelectedValue)
            Rpt.SetParameterValue("@FORMATO", IIf(Me.RdbDetalle.Checked = True, "DETALLE", "RESUMEN"))

            Dim frm As New Reporte(Rpt)
            frm.CRViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            frm.Show()
        Catch ex As Exception
            HandleError(Me.Name, "Imprimir", ex)
        Finally
            oReporte = Nothing
        End Try
    End Sub
#End Region

End Class