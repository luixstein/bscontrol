Imports CrystalDecisions.CrystalReports.Engine

Public Class Rpt_Embarques_Empaque_Y_Embarque
    Private oArticulos As New Class_CatArticulos
    Private oProductores As New Class_CatProductores

    Private Sub TxtCodArticulo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodArticulo.KeyDown
        Select Case e.KeyCode
            Case Keys.F6
                oArticulos = New Class_CatArticulos
buscar:
                Dim sArticulo As String = oArticulos.BusquedaVisualProductosAgricolas_PorDescripcion
                If sArticulo.Length > 0 Then
                    Me.TxtCodArticulo.Text = sArticulo
                    Me.lblArticulo.Text = oArticulos.BuscarNombreArticulo(sArticulo)
                End If
            Case Keys.Enter
                If txtLEN(Me.TxtCodArticulo.Text) = False Then
                    GoTo buscar
                End If
                Me.lblArticulo.Text = oArticulos.BuscarNombreArticulo(Me.TxtCodArticulo.Text)
                If txtLEN(Me.lblArticulo.Text) = False Then
                    MsgBox("El producto no existe.", MsgBoxStyle.Exclamation, Me.Text)
                    lblArticulo.Text = ""
                    GoTo buscar
                    Exit Sub
                Else
                    txtTAB(e)
                End If
            Case Keys.Escape
        End Select
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

    Private Sub DesplegarEmpaques()
        Try
            Dim oElementos As New Class_CatEmpaques
            With Me.CboEmpaque
                .DisplayMember = "NOMBRE_EMPAQUE"
                .ValueMember = "CODIGO_EMPAQUE"
                Dim dView As New Data.DataView(oElementos.ObtenerElementosParaReportes)
                ' dView.Sort = "NOMBRE_EMPAQUE"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedIndex = 0
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarEmpaques", ex)
        End Try
    End Sub

    Private Sub DesplegarProductores()
        Try
            With Me.CboProductor
                .DisplayMember = "NOMBRE_PRODUCTOR"
                .ValueMember = "CODIGO_PRODUCTOR"
                Dim dView As New Data.DataView(Me.oProductores.ObtenerElementosParaReportes())
                dView.Sort = "NOMBRE_PRODUCTOR DESC"
                .DataSource = dView
                .Text = "TODOS"
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarProductores", ex)
        End Try
    End Sub

    Private Sub Rpt_Embarques_Empaque_Y_Embarque_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DesplegarCultivos()
        Me.DesplegarEmpaques()
        Me.DesplegarProductores()
        Me.DtFechaDesde.Value = Format(Date.Now, "01-MM-yyyy")
        Me.DtFechaHasta.Value = Date.Now
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
            If Me.ValidarPeriodo = False Then
                Exit Sub
            End If

            If Me.rdbCompleto.Checked = True Then
                FormatoDeReporte = "RPT_EMB_EMPAQUE_EMBARQUE"
            Else
                FormatoDeReporte = "RPT_EMB_EMPAQUE_EMBARQUE_TOTALES"
            End If

            Me.DtFechaDesde.Enabled = False
            Me.DtFechaDesde.Enabled = True
            Me.DtFechaHasta.Enabled = False
            Me.DtFechaHasta.Enabled = True

            oReporte = New Class_Reporte(FormatoDeReporte, Rpt)
            Rpt.SetParameterValue("@FECHA1", Format(Me.DtFechaDesde.Value, "yyyy-dd-MM"))
            Rpt.SetParameterValue("@FECHA2", Format(Me.DtFechaHasta.Value, "yyyy-dd-MM"))
            Rpt.SetParameterValue("@CODIGO_CULTIVO", Me.cboCultivo.SelectedValue.ToString)
            Rpt.SetParameterValue("@CODIGO_ARTICULO", Me.TxtCodArticulo.Text)
            Rpt.SetParameterValue("@CODIGO_PRODUCTOR", Me.CboProductor.SelectedValue.ToString)
            Rpt.SetParameterValue("@CODIGO_EMPAQUE", Me.CboEmpaque.SelectedValue.ToString)
            Rpt.SetParameterValue("@CODIGO_PLAZA", Usuario.Codigo_Plaza)

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

    Private Sub TxtCodArticulo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodArticulo.KeyPress, DtFechaHasta.KeyPress, DtFechaDesde.KeyPress, cboCultivo.KeyPress, _
    CboEmpaque.KeyPress, CboProductor.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub cboCultivo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtFechaHasta.KeyDown, DtFechaDesde.KeyDown, cboCultivo.KeyDown, CboEmpaque.KeyDown, CboProductor.KeyDown
        txtTAB(e)
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub
End Class