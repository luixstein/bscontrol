Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class Frm_Contabilidad_Costos_Produccion
    Private FormatoDeReporte As String = "RPT_PROYECTO_SIEMBRA_COSTOS_PRODUCCION"

#Region "Constructor y destructor"
    Public Sub New()
        InitializeComponent()
        DesplegarEjercicios()
        'Me.CmbEjercicio.SelectedValue = EmpresaParametros.ID_CON_EJERCICIO
        Me.DtFechaDesde.Value = Plaza.FECHA_INICIO
        Me.DtFechaHasta.Value = Plaza.FECHA_FINAL
    End Sub
#End Region

#Region "Opciones"
    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub

    Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click
        If Me.txtTipoCambio.Text = "" Then
            MsgBox("Tiene que introducir un tipo de cambio", MsgBoxStyle.Exclamation, "Tipo cambio")
        Else
            Me.Imprimir()
        End If
    End Sub

    Private Sub txttxtTipoCambioKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        txtSoloNumerosEnteros(e)
        txtNoBeep(e)
    End Sub
#End Region

#Region "Eventos de objetos"

#Region "Eventos"
    Private Sub Frm_Contabilidad_Costos_Produccion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sql As New Class_find("SELECT FECHA_INICIO,FECHA_FINAL FROM CON_EJERCICIOS WHERE ID_CON_EJERCICIO=" & Me.CmbEjercicio.SelectedValue.ToString)
        Me.DtFechaDesde.Value = CDate(sql.Result1)
        Me.DtFechaHasta.Value = CDate(sql.Result2)
        If Usuario.Nombre_Usuario = "ROSARIO" Then
            Me.RdbTarriba.Checked = True
            Me.RdbTotalEmpresa.Visible = False
            Me.RdbPresupuesto.Visible = False
        Else
            Me.RdbTarriba.Checked = False
            Me.RdbTotalEmpresa.Visible = True
            Me.RdbPresupuesto.Visible = True
        End If
    End Sub

    Private Sub txtTipoCambio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTipoCambio.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.tsbImprimir.PerformClick()
        End If
    End Sub

    Private Sub txtTipoCambio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTipoCambio.KeyPress
        Dim txt As TextBox = CType(sender, TextBox)
        txtSoloNumerosDecimales(e, txt.Text)
        txtNoBeep(e)
    End Sub

    Private Sub CmbEjercicio_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbEjercicio.SelectedIndexChanged
        Dim sql As New Class_find("SELECT FECHA_INICIO,FECHA_FINAL FROM CON_EJERCICIOS WHERE ID_CON_EJERCICIO=" & Me.CmbEjercicio.SelectedValue.ToString)
        Me.DtFechaDesde.Value = CDate(sql.Result1)
        Me.DtFechaHasta.Value = CDate(sql.Result2)
    End Sub

    Private Sub DtFechaHasta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtFechaHasta.KeyDown, DtFechaDesde.KeyDown, CmbEjercicio.KeyDown
        txtTAB(e)
    End Sub

    Private Sub DtFechaHasta_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtFechaHasta.ValueChanged
        If Me.Visible = False Then
            Exit Sub
        End If
        Dim sql As New Class_find("SELECT FECHA_INICIO,FECHA_FINAL FROM CON_EJERCICIOS WHERE ID_CON_EJERCICIO='" & Me.CmbEjercicio.SelectedValue.ToString & "'")
        If Me.DtFechaHasta.Value < CDate(sql.Result1) Then
            Me.DtFechaHasta.Value = CDate(sql.Result1)
        End If
        If Me.DtFechaHasta.Value > CDate(sql.Result2) Then
            Me.DtFechaHasta.Value = CDate(sql.Result2)
        End If
    End Sub

    Private Sub DtFechaDesde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtFechaDesde.ValueChanged
        If Me.Visible = False Then
            Exit Sub
        End If
        Dim sql As New Class_find("SELECT FECHA_INICIO,FECHA_FINAL FROM CON_EJERCICIOS WHERE ID_CON_EJERCICIO='" & Me.CmbEjercicio.SelectedValue.ToString & "'")
        If Me.DtFechaDesde.Value < CDate(sql.Result1) Then
            Me.DtFechaDesde.Value = CDate(sql.Result1)
        End If
        If Me.DtFechaDesde.Value > CDate(sql.Result2) Then
            Me.DtFechaDesde.Value = CDate(sql.Result2)
        End If
    End Sub
#End Region

#Region "Eventos Genericos"

#End Region

#End Region

#Region "Métodos y procedimientos"
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
        Dim ValidaPeriodo As New Class_find("SELECT 1 FROM CON_EJERCICIOS WHERE (('" & Format(Me.DtFechaDesde.Value, "yyyy-dd-MM") & "' BETWEEN FECHA_INICIO AND FECHA_FINAL)) AND (('" & Format(Me.DtFechaHasta.Value, "yyyy-dd-MM") & "' BETWEEN FECHA_INICIO AND FECHA_FINAL)) AND ID_CON_EJERCICIO=" & Me.CmbEjercicio.SelectedValue.ToString)
        If ValidaPeriodo.Result1.Length <= 0 Then
            MsgBox("El rango especificado esta fuera del rango del ejercicio.", MsgBoxStyle.Exclamation, Me.Name)
            Exit Function
        End If
        ValidarPeriodo = True
    End Function

    Private Sub DesplegarEjercicios()
        Dim oElementos As New Class_Contabilidad_Ejercicios
        With Me.CmbEjercicio
            .DisplayMember = "NOMBRE_EJERCICIO"
            .ValueMember = "ID_CON_EJERCICIO"

            Dim dView As New Data.DataView(oElementos.ObtenerEjercicios)
            .DataSource = dView
            If dView.Count > 0 Then
                'Dim Ejercicio As New Class_find("SELECT ID_CON_EJERCICIO FROM CON_EJERCICIOS WHERE '" & Format(Date.Now, "yyyy-dd-MM") & "' BETWEEN FECHA_INICIO AND FECHA_FINAL AND TIPO_CONTABILIDAD='FN'")
                .SelectedValue = Plaza.ID_CON_EJERCICIO.ToString ' Ejercicio.Result1.ToString
            End If
        End With
    End Sub

    Private Sub Imprimir()
        Dim StrFiltros As String = ""
        Dim Rpt As New ReportDocument
        Dim oReporte As Class_Reporte
        Try
            If Me.ValidarPeriodo = False Then
                Exit Sub
            End If

            'If Me.RdbTotalEmpresa.Checked = True Then
            '    oReporte = New Class_Reporte(FormatoDeReporte, Rpt)
            'ElseIf Me.RdbTarriba.Checked = True Then
            '    oReporte = New Class_Reporte("RPT_PROYECTO_SIEMBRA_COSTOS_PRODUCCION_TARRIBA_" & Me.CmbEjercicio.Text, Rpt)
            'ElseIf Me.RdbPresupuesto.Checked = True Then
            '    oReporte = New Class_Reporte("RPT_PROYECTO_SIEMBRA_COSTOS_PRODUCCION_PRESUPUESTO", Rpt)
            'End If

            If Me.rbFormatoDetallado.Checked = True Then
                Me.FormatoDeReporte = "RPT_PROYECTO_SIEMBRA_COSTOS_PRODUCCION"
            ElseIf Me.rbFormatoAgrupado.Checked = True Then
                Me.FormatoDeReporte = "RPT_PROYECTO_SIEMBRA_COSTOS_PRODUCCION_AGRUPADO"
            End If

            oReporte = New Class_Reporte(FormatoDeReporte, Rpt)

            Rpt.SetParameterValue("@ID_CON_EJERCICIO", Me.CmbEjercicio.SelectedValue)
            Rpt.SetParameterValue("@FECHA1", Format(DtFechaDesde.Value, "yyyy-dd-MM"))
            Rpt.SetParameterValue("@FECHA2", Format(DtFechaHasta.Value, "yyyy-dd-MM"))
            Rpt.SetParameterValue("@TIPO_CAMBIO", Me.txtTipoCambio.Text)
            Rpt.SetParameterValue("@ID_PROYECTO", 0)

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