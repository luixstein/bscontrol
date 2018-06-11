Option Strict On

Imports CrystalDecisions.CrystalReports.Engine

Public Class Rpt_Nomina_Detalle

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
        Me.DesplegarSemanas()
        Me.DesplegarCentroCosto()
        Me.DesplegarConceptoActividad()
    End Sub

    Private Sub cboConceptoActividad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboConceptoActividad.SelectedIndexChanged
        Me.DesplegarSubactividades()
    End Sub

    Private Sub txtCodicoTrabajador_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodigoTrabajador.KeyDown
        Dim oTrabajador As New Class_CatTrabajadores
        Dim sText As String
        Select Case e.KeyCode
            Case Keys.F6
Buscar:
                sText = oTrabajador.BusquedaVisual_PorDescripcion
                If txtLEN(sText) = True Then Me.TxtCodigoTrabajador.Text = sText
            Case Keys.Enter
                If txtLEN(Me.TxtCodigoTrabajador.Text) = False Then
                    Me.LblNombreTrabajador.Text = ""
                    txtTAB(e)
                    Exit Sub
                End If

                oTrabajador = New Class_CatTrabajadores(Me.TxtCodigoTrabajador.Text, True)
                If oTrabajador.Existe = False Then
                    Me.LblNombreTrabajador.Text = "" : GoTo Buscar : Exit Sub
                End If

                Me.LblNombreTrabajador.Text = oTrabajador.NOMBRE_COMPLETO_NOMBRE
                txtTAB(e)
        End Select
    End Sub
#End Region

#Region "Eventos Genericos"
    Private Sub txtNumerosEnterosKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigoTrabajador.KeyPress
        txtSoloNumerosEnteros(e)
        txtNoBeep(e)
    End Sub

    Private Sub txtKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) 'Handles CboEmpaque.KeyPress, DtpFecha.KeyPress
        txtNoBeep(e)
    End Sub
#End Region

#End Region

#Region "Métodos y procedimientos"
    Private Sub DesplegarSemanas()
        Try
            Dim oElementos As New Class_NominaSemana

            Me.cboSemana1.Refresh()
            With Me.cboSemana1
                .DisplayMember = "NUMERO_SEMANA"
                .ValueMember = "ID_NOMINA_SEMANA"
                Dim dView As New Data.DataView(oElementos.ObtenerElementos())
                dView.Sort = "NUMERO_SEMANA"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedIndex = 0
                End If
            End With

            Me.cboSemana2.Refresh()
            With Me.cboSemana2
                .DisplayMember = "NUMERO_SEMANA"
                .ValueMember = "ID_NOMINA_SEMANA"
                Dim dView As New Data.DataView(oElementos.ObtenerElementos())
                dView.Sort = "NUMERO_SEMANA"
                .DataSource = dView
                If dView.Count > 0 Then
                    .Text = Plaza.oSisPlazaNomina.NOMINA_NUMERO_SEMANA_ACTUAL.ToString
                End If
            End With

        Catch ex As Exception
            HandleError(Me.Name, "DesplegarSemanas", ex)
        End Try
    End Sub

    Private Sub DesplegarCentroCosto()
        Try
            Dim oElementos As New Class_CatCentroCostos
            With Me.CboCentroCosto
                .DisplayMember = "NOMBRE_CENTRO_COSTO"
                .ValueMember = "CODIGO_CENTRO_COSTO"
                Dim dView As New Data.DataView(oElementos.ObtenerElementosParaReportes())
                dView.Sort = "NOMBRE_CENTRO_COSTO DESC"
                .DataSource = dView
                If dView.Count > 0 Then
                    '.SelectedIndex = -1
                    .SelectedValue = -1
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarPuntoPago", ex)
        End Try
    End Sub

    Private Sub DesplegarConceptoActividad()
        Try
            Dim oElementos As New Class_CatActividades
            With Me.cboConceptoActividad
                .DisplayMember = "NOMBRE_CONCEPTO_ACTIVIDAD"
                .ValueMember = "CODIGO_CONCEPTO_ACTIVIDAD"
                Dim dView As New Data.DataView(oElementos.ObtenerConceptosActividadesParaReportes())
                dView.Sort = "NOMBRE_CONCEPTO_ACTIVIDAD "
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedValue = "T"
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarPuntoPago", ex)
        End Try
    End Sub

    Private Sub DesplegarSubactividades()
        Try
            Dim oElementos As New Class_CatActividades
            With Me.cboSubactividad
                .DataSource = Nothing
                .DisplayMember = "NOMBRE_ACTIVIDAD"
                .ValueMember = "CODIGO_SUB_ACTIVIDAD"
                Dim dView As New Data.DataView(oElementos.ObtenerSubActividadesParaReportes(Me.cboConceptoActividad.SelectedValue.ToString))
                dView.Sort = "NOMBRE_ACTIVIDAD"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedValue = "T"
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarSubactividades", ex)
        End Try
    End Sub

    Private Sub Imprimir()
        Dim StrFiltros As String = ""
        Dim Rpt As New ReportDocument
        Dim oReporte As Class_Reporte
        Try
            oReporte = New Class_Reporte("RPT_NOMINA_DETALLE_DIA", Rpt)

            If Not oReporte.RptCargado Then
                Exit Sub
            End If

            Dim oTrabajador As New Class_CatTrabajadores
            If txtLEN(Me.TxtCodigoTrabajador.Text) = True Then
                oTrabajador = New Class_CatTrabajadores(Me.TxtCodigoTrabajador.Text, True)
                If oTrabajador.Existe = False Then
                    MsgBox("El trabajador no existe.", vbExclamation, Me.Name)
                    Return
                End If
            End If

            Rpt.SetParameterValue("@ID_NOMINA_SEMANA1", CInt(Me.cboSemana1.SelectedValue.ToString))
            Rpt.SetParameterValue("@ID_NOMINA_SEMANA2", CInt(Me.cboSemana2.SelectedValue.ToString))
            Rpt.SetParameterValue("@CODIGO_CENTRO_COSTO", Me.CboCentroCosto.SelectedValue.ToString)
            Rpt.SetParameterValue("@CODIGO_CONCEPTO_ACTIVIDAD", Me.cboConceptoActividad.SelectedValue.ToString)
            Rpt.SetParameterValue("@CODIGO_SUB_ACTIVIDAD", Me.cboSubactividad.SelectedValue.ToString)
            Rpt.SetParameterValue("@CODIGO_TRABAJADOR", IIf(oTrabajador.Existe = True, oTrabajador.CODIGO_TRABAJADOR, "").ToString) 'No se debe poner el código directo del texbox porque tiene el código de temporada(que se repite)

            Dim frm As New Reporte(Rpt)
            frm.CRViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            frm.Show()
        Catch ex As Exception
            HandleError(Me.Name, "Reporte de navegador de costos presupuestos", ex)
        Finally
            oReporte = Nothing
        End Try
    End Sub
#End Region


End Class