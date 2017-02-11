Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class Rpt_VentasNetasPorCultivo
    Private oClientes As New Class_CatClientes

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

    Private Sub DesplegarZona()
        Dim oElementos As New Class_CatZonas
        With Me.CboZona
            .DisplayMember = "NOMBRE_ZONA"
            .ValueMember = "CODIGO_ZONA"
            Dim dView As New Data.DataView(oElementos.ObtenerZonasParaReportes())
            dView.Sort = "NOMBRE_ZONA"
            .DataSource = dView
        End With
    End Sub

    Private Sub DesplegarSemana1()
        Dim oElementos As New Class_CatCultivos
        With Me.CboSemana1
            .DisplayMember = "SEMANA"
            .ValueMember = "FECHA1"
            Dim dView As New Data.DataView(oElementos.ObtenerSemanas("1"))
            dView.Sort = "SEMANA"
            .DataSource = dView
        End With
    End Sub

    Private Sub DesplegarSemana2()
        Dim oElementos As New Class_CatCultivos
        With Me.CboSemana2
            .DisplayMember = "SEMANA"
            .ValueMember = "FECHA2"
            Dim dView As New Data.DataView(oElementos.ObtenerSemanas("2"))
            dView.Sort = "SEMANA"
            .DataSource = dView
        End With
    End Sub

    Private Sub Rpt_Embarques_Empaque_Y_Embarque_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DesplegarCultivos()
        Me.DesplegarZona()
        Me.DesplegarSemana1()
        Me.DesplegarSemana2()

        Me.CboSemana1.Text = "2011-26" '& DatePart("ww", TemporadaActiva.FECHA1, FirstDayOfWeek.Sunday, FirstWeekOfYear.FirstFullWeek).ToString
        Me.CboSemana2.Text = Format(Now, "yyyy-") & Format(CInt(DatePart("ww", Now, FirstDayOfWeek.Sunday, FirstWeekOfYear.FirstFullWeek).ToString) - 1, "00")
        Me.cboCultivo.Focus()

        Me.CboZona.SelectedValue = Plaza.CODIGO_ZONA_PRINCIPAL
    End Sub

    Private Sub tsbConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbConsultar.Click
        Consultar()
    End Sub

    Private Sub Consultar()
        Dim FormatoDeReporte As String = ""
        Dim Rpt As ReportDocument
        Rpt = New ReportDocument
        Dim oReporte As Class_Reporte
        Try
            'FormatoDeReporte = "RPT_VENTAS_NETAS_POR_CULTIVO"
            'oReporte = New Class_Reporte(FormatoDeReporte, Rpt)
            'Rpt.SetParameterValue("@FECHA1", Format(Me.DtFechaDesde.Value, "yyyy-dd-MM"))
            'Rpt.SetParameterValue("@FECHA2", Format(Me.DtFechaHasta.Value, "yyyy-dd-MM"))
            'Rpt.SetParameterValue("@CODIGO_CULTIVO", Me.cboCultivo.SelectedValue.ToString())

            If txtLEN(Me.TxtCliente.Text) = True Then
                Me.oClientes = New Class_CatClientes(Me.TxtCliente.Text)
                If Me.oClientes.Existe = False Then
                    MsgBox("El cliente no existe.", MsgBoxStyle.Information, Me.Text)
                    Me.TxtCliente.Focus()
                    Exit Sub
                End If
            End If

            If Me.ValidarPeriodo = False Then
                Exit Sub
            End If

            If Me.RdbCliente.Checked = True Then
                FormatoDeReporte = "RPT_EMBARQUES_VENTAS_ESTIMADAS_POR_CLIENTE"
            Else
                FormatoDeReporte = "RPT_EMBARQUES_VENTAS_ESTIMADAS_POR_CULTIVO"
            End If

            oReporte = New Class_Reporte(FormatoDeReporte, Rpt)
            Rpt.SetParameterValue("@FECHA1", Me.CboSemana1.Text)
            Rpt.SetParameterValue("@FECHA2", Me.CboSemana2.Text)
            Rpt.SetParameterValue("@CODIGO_CULTIVO", Me.cboCultivo.SelectedValue.ToString())
            Rpt.SetParameterValue("@CODIGO_ZONA", Me.CboZona.SelectedValue.ToString)
            Rpt.SetParameterValue("@CODIGO_MERCADO", "E") 'Se pasa fijo extranjeros ya que se buscan sólo embarques extranjeros
            Rpt.SetParameterValue("@CODIGO_CLIENTE", Me.TxtCliente.Text)
            Rpt.SetParameterValue("@AGRUPADO_POR", IIf(Me.RdbCliente.Checked = True, "CLIENTE", "CULTIVO"))

            Dim frm As New Reporte(Rpt)
            frm.CRViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            frm.Show()
        Catch ex As Exception
            HandleError(Me.Name, "Consultar", ex)
        Finally
            oReporte = Nothing
        End Try
    End Sub

    Private Function ValidarPeriodo() As Boolean
        Me.DtFechaDesde.Enabled = True
        Me.DtFechaDesde.Enabled = False

        Me.DtFechaHasta.Enabled = True
        Me.DtFechaHasta.Enabled = False

        If Me.DtFechaDesde.Value > Me.DtFechaHasta.Value Then
            MsgBox("Rango de fechas inválidas.", MsgBoxStyle.Exclamation, Me.Name)
            Me.DtFechaDesde.Focus()
            Exit Function
        End If
        ValidarPeriodo = True
    End Function

    Private Sub cboCultivo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DtFechaHasta.KeyPress, DtFechaDesde.KeyPress, _
    cboCultivo.KeyPress, CboZona.KeyPress, TxtCliente.KeyPress, CboSemana1.KeyPress, CboSemana2.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub cboCultivo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtFechaHasta.KeyDown, DtFechaDesde.KeyDown, _
    cboCultivo.KeyDown, CboZona.KeyDown, CboSemana1.KeyDown, CboSemana2.KeyDown
        txtTAB(e)
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub

    Private Sub TxtCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCliente.KeyDown
        Dim sText As String
        Select Case e.KeyCode
            Case Keys.F6
Buscar:
                sText = Me.oClientes.BusquedaVisual_PorDescripcionSinFiltroZona("0001")
                If txtLEN(sText) = True Then Me.TxtCliente.Text = sText
            Case Keys.Enter
                If txtLEN(Me.TxtCliente.Text) = False Then
                    Me.lblNombreCliente.Text = "" : Me.tsbConsultar.PerformClick() : Exit Sub
                End If

                Me.oClientes = New Class_CatClientes(Me.TxtCliente.Text)
                If Me.oClientes.Existe = False Then
                    Me.lblNombreCliente.Text = "" : GoTo Buscar : Exit Sub
                End If

                Me.lblNombreCliente.Text = Me.oClientes.NOMBRE_CLIENTE.ToString
                Me.tsbConsultar.PerformClick()
        End Select
    End Sub

    Private Sub CboSemana1_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboSemana1.SelectedValueChanged
        Dim sql As Class_find
        sql = New Class_find("SELECT FECHA1,FECHA2 FROM EMB_CAT_RANGOS_LOTES_MASTRONARDI " & _
        "WHERE REPLACE(LEFT(CAST(((NUMERO_SEMANA/100.00)+AÑO) AS NVARCHAR),7),'.','-')='" & Me.CboSemana1.Text.ToString & "'")
        If txtLEN(sql.Result1) = True Then
            Me.DtFechaDesde.Value = CDate(sql.Result1)
        End If
    End Sub

    Private Sub CboSemana2_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboSemana2.SelectedValueChanged
        Dim sql As Class_find
        sql = New Class_find("SELECT FECHA2 FROM EMB_CAT_RANGOS_LOTES_MASTRONARDI " & _
        "WHERE REPLACE(LEFT(CAST(((NUMERO_SEMANA/100.00)+AÑO) AS NVARCHAR),7),'.','-')='" & Me.CboSemana2.Text.ToString & "'")
        If txtLEN(sql.Result1) = True Then
            Me.DtFechaHasta.Value = CDate(sql.Result1)
        End If
    End Sub
End Class