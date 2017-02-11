Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class Rpt_Embarques_VentasNacionalesEstimadas
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

    Private Sub Rpt_Embarques_Empaque_Y_Embarque_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DesplegarCultivos()
        Me.DesplegarZona()

        Me.cboCultivo.Focus()
        Me.DtFechaDesde.Value = Format(Now, "01-MMM-yy")
        Me.DtFechaHasta.Value = Now

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
                FormatoDeReporte = "RPT_VENTAS_NACIONALES_AGRUPADAS_POR_CLIENTE"
            Else
                FormatoDeReporte = "RPT_VENTAS_NACIONALES_AGRUPADAS_POR_CULTIVO"
            End If

            oReporte = New Class_Reporte(FormatoDeReporte, Rpt)
            Rpt.SetParameterValue("@FECHA1", Format(Me.DtFechaDesde.Value, "yyyy-dd-MM"))
            Rpt.SetParameterValue("@FECHA2", Format(Me.DtFechaHasta.Value, "yyyy-dd-MM"))
            Rpt.SetParameterValue("@CODIGO_CULTIVO", Me.cboCultivo.SelectedValue.ToString())
            Rpt.SetParameterValue("@CODIGO_ZONA", Me.CboZona.SelectedValue.ToString)
            Rpt.SetParameterValue("@CODIGO_TIPO_MERCADO", "0002")
            Rpt.SetParameterValue("@CODIGO_CLIENTE", Me.TxtCliente.Text)
            Rpt.SetParameterValue("@AGRUPADO_POR", IIf(Me.RdbCliente.Checked = True, "CLIENTE", "CULTIVO"))
            Rpt.SetParameterValue("@UNIDAD_VENTA", "")

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

    Private Sub cboCultivo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DtFechaHasta.KeyPress, DtFechaDesde.KeyPress, _
    cboCultivo.KeyPress, CboZona.KeyPress, TxtCliente.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub cboCultivo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtFechaHasta.KeyDown, DtFechaDesde.KeyDown, _
    cboCultivo.KeyDown, CboZona.KeyDown
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
                sText = Me.oClientes.BusquedaVisual_PorDescripcionSinFiltroZona("0002")
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

End Class