Imports CrystalDecisions.CrystalReports.Engine

Public Class Rpt_Embarques_Embarque

    Private oArticulos As New Class_CatArticulos
    Private oClientes As New Class_CatClientes
    'Private oAduanales As New Class_CatAgenciaAduanales

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

    Private Sub TxtClientes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCliente.KeyDown
        Dim sText As String
        Select Case e.KeyCode
            Case Keys.F6
Buscar:
                sText = Me.oClientes.BusquedaVisual_PorDescripcion
                If txtLEN(sText) = True Then Me.TxtCliente.Text = sText
            Case Keys.Enter
                If txtLEN(Me.TxtCliente.Text) = False Then
                    Me.lblNombreCliente.Text = "" : GoTo Buscar : Exit Sub
                End If

                Me.oClientes = New Class_CatClientes(Me.TxtCliente.Text)
                If Me.oClientes.Existe = False Then
                    Me.lblNombreCliente.Text = "" : GoTo Buscar : Exit Sub
                End If

                Me.lblNombreCliente.Text = Me.oClientes.NOMBRE_CLIENTE
                txtTAB(e)
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

    Private Sub DesplegarLugarEntrega()
        Dim oLugarEntrega As New Class_CatLugaresEntrega
        Try
            With Me.CboLugarEntrega
                .DisplayMember = "NOMBRE_LUGAR_ENTREGA"
                .ValueMember = "CODIGO_LUGAR_ENTREGA"

                Dim dView As New Data.DataView(oLugarEntrega.ObtenerElementosParaReportes())
                dView.Sort = "NOMBRE_LUGAR_ENTREGA"
                .DataSource = dView
                .Text = "TODOS"
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarLugarEntrega", ex)
        End Try
    End Sub

    Private Sub DesplegarAduanaExtranjera()
        Dim oAduanales As New Class_CatAgenciaAduanales
        Try
            With Me.CboAdunaExtranjera
                .DisplayMember = "NOMBRE_AGENCIA_ADUANA"
                .ValueMember = "CODIGO_ADUANA"

                Dim dView As New Data.DataView(oAduanales.ObtenerElementosExtranjerosParaReportes())
                dView.Sort = "NOMBRE_AGENCIA_ADUANA"
                .DataSource = dView
                .Text = "TODOS"
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarAduanaExtranjera", ex)
        End Try
    End Sub

    Private Sub DesplegarAduanaNacional()
        Dim oAduanales As New Class_CatAgenciaAduanales
        Try
            With Me.CboAduanaNacional
                .DisplayMember = "NOMBRE_AGENCIA_ADUANA"
                .ValueMember = "CODIGO_ADUANA"

                Dim dView As New Data.DataView(oAduanales.ObtenerElementosNacionalesParaReportes())
                dView.Sort = "NOMBRE_AGENCIA_ADUANA"
                .DataSource = dView
                .Text = "TODOS"
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarAduanaNacional", ex)
        End Try
    End Sub

    Private Sub DesplegarEstatusEmbarque()
        Dim oEmbarques As New Class_Embarques_EmbarqueGlobal
        Try
            With Me.CboEstatus
                .DisplayMember = "ESTATUS_COMPLETO"
                .ValueMember = "ESTATUS_EMBARQUE"

                Dim dView As New Data.DataView(oEmbarques.ObtenerEstatusEmbarques())
                dView.Sort = "ESTATUS_COMPLETO"
                .DataSource = dView
                .Text = "APLICADO"
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarEstatusEmbarque", ex)
        End Try
    End Sub


    Private Sub Rpt_Embarques_Empaque_Y_Embarque_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DesplegarCultivos()
        Me.DesplegarLugarEntrega()
        Me.DesplegarAduanaExtranjera()
        Me.DesplegarAduanaNacional()
        Me.DesplegarEstatusEmbarque()

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

            FormatoDeReporte = "RPT_EMB_EMBARQUES"
            oReporte = New Class_Reporte(FormatoDeReporte, Rpt)
            Rpt.SetParameterValue("@FECHA1", Format(Me.DtFechaDesde.Value, "yyyy-dd-MM"))
            Rpt.SetParameterValue("@FECHA2", Format(Me.DtFechaHasta.Value, "yyyy-dd-MM"))
            Rpt.SetParameterValue("@CODIGO_CULTIVO", Me.cboCultivo.SelectedValue.ToString())
            Rpt.SetParameterValue("@CODIGO_ARTICULO", Me.TxtCodArticulo.Text)
            Rpt.SetParameterValue("@CODIGO_CLIENTE", Me.TxtCliente.Text)
            Rpt.SetParameterValue("@CODIGO_ADUANA_EXTRANJERA", Me.CboAdunaExtranjera.SelectedValue.ToString)
            Rpt.SetParameterValue("@CODIGO_ADUANA_NACIONAL", Me.CboAduanaNacional.SelectedValue.ToString)
            Rpt.SetParameterValue("@CODIGO_LUGAR_ENTREGA", Me.CboLugarEntrega.SelectedValue)
            Rpt.SetParameterValue("@ESTATUS_EMBARQUE", Me.CboEstatus.SelectedValue)
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


    Private Sub TxtCodArticulo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodArticulo.KeyPress, DtFechaHasta.KeyPress, DtFechaDesde.KeyPress, cboCultivo.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub cboCultivo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtFechaHasta.KeyDown, DtFechaDesde.KeyDown, cboCultivo.KeyDown, CboLugarEntrega.KeyDown, _
        CboAduanaNacional.KeyDown, CboAdunaExtranjera.KeyDown
        txtTAB(e)
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub
End Class