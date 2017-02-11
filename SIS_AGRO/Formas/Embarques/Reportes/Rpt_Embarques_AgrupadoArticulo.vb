Imports CrystalDecisions.CrystalReports.Engine

Public Class Rpt_Embarques_AgrupadoArticulo
    Private oArticulos As New Class_CatArticulos
    Private oAduanales As New Class_CatAgenciaAduanales
    Private oClientes As New Class_CatClientes
    Private oCultivos As New Class_CatCultivos
    Private oTiposMercados As New Class_CatTiposMercados
    Private oLugarEntrega As New Class_CatLugaresEntrega
    Private oProductores As New Class_CatProductores

    Private Sub TxtCodigoArticulo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodigoArticulo.KeyDown
        Select Case e.KeyCode
            Case Keys.F6
                oArticulos = New Class_CatArticulos
buscar:
                Dim sArticulo As String = oArticulos.BusquedaVisualProductosAgricolas_PorDescripcion
                If sArticulo.Length > 0 Then
                    Me.TxtCodigoArticulo.Text = sArticulo
                    Me.lblNombreArticulo.Text = oArticulos.BuscarNombreArticulo(sArticulo)
                End If
            Case Keys.Enter
                If txtLEN(Me.TxtCodigoArticulo.Text) = False Then
                    txtTAB(e)
                    Exit Sub
                End If
                Me.lblNombreArticulo.Text = oArticulos.BuscarNombreArticulo(Me.TxtCodigoArticulo.Text)
                If txtLEN(Me.lblNombreArticulo.Text) = False Then
                    MsgBox("El articulo no existe.", MsgBoxStyle.Exclamation, Me.Text)
                    Me.lblNombreArticulo.Text = ""
                    GoTo buscar
                    Exit Sub
                Else
                    txtTAB(e)
                End If
        End Select
    End Sub

    Private Sub TxtCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCliente.KeyDown
        Dim sText As String, sZona As String
        Me.oTiposMercados = New Class_CatTiposMercados
        Select Case e.KeyCode
            Case Keys.F6
Buscar:
                If Me.CboTipoMercado.SelectedValue.ToString <> "T" Then
                    If Me.CboTipoMercado.SelectedValue.ToString = "E" Then
                        sZona = "1"
                    Else
                        sZona = "2"
                    End If
                    sText = Me.oClientes.BusquedaVisual_PorDescripcionZona(sZona)
                Else
                    sText = Me.oClientes.BusquedaVisual_PorDescripcion
                End If

                If txtLEN(sText) = True Then Me.TxtCliente.Text = sText
            Case Keys.Enter
                If txtLEN(Me.TxtCliente.Text) = False Then
                    Me.lblNombreCliente.Text = ""
                    Me.CboAduanaExtranjera.Focus()
                    Exit Sub
                End If

                Me.oClientes = New Class_CatClientes(Me.TxtCliente.Text)
                If Me.oClientes.Existe = False Then
                    Me.lblNombreCliente.Text = "" : GoTo Buscar : Exit Sub
                End If

                Me.lblNombreCliente.Text = Me.oClientes.NOMBRE_CLIENTE.ToString
                Me.CboAduanaExtranjera.Focus()
        End Select
    End Sub

    Private Sub DesplegarCultivos()
        Me.oCultivos = New Class_CatCultivos
        Try
            With Me.cboCultivo
                .DisplayMember = "NOMBRE_CULTIVO"
                .ValueMember = "CODIGO_CULTIVO"

                Dim dView As New Data.DataView(Me.oCultivos.ObtenerElementosParaReportes)
                dView.Sort = "NOMBRE_CULTIVO"
                .DataSource = dView
                .Text = "TODOS"
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarCultivos", ex)
        End Try
    End Sub

    Private Sub DesplegarProductor()
        Me.oProductores = New Class_CatProductores
        Try
            With Me.CboProductor
                .DisplayMember = "NOMBRE_PRODUCTOR"
                .ValueMember = "CODIGO_PRODUCTOR"

                Dim dView As New Data.DataView(Me.oProductores.ObtenerElementosParaReportes)
                dView.Sort = "NOMBRE_PRODUCTOR"
                .DataSource = dView
                .Text = "TODOS"
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarCultivos", ex)
        End Try
    End Sub

    Private Sub DesplegarTiposMercados()
        Me.oTiposMercados = New Class_CatTiposMercados
        Try
            With Me.CboTipoMercado
                .DisplayMember = "NOMBRE_TIPO_MERCADO"
                .ValueMember = "CODIGO_TIPO_MERCADO"

                Dim dView As New Data.DataView(Me.oTiposMercados.ObtenerTiposMercadosParaReportes)
                dView.Sort = "NOMBRE_TIPO_MERCADO"
                .DataSource = dView
                .Text = "TODOS"
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarTiposMercados", ex)
        End Try
    End Sub

    Private Sub DesplegarLugarEntrega()
        Me.oLugarEntrega = New Class_CatLugaresEntrega
        Try
            With Me.CboLugarEntrega
                .DisplayMember = "NOMBRE_LUGAR_ENTREGA"
                .ValueMember = "CODIGO_LUGAR_ENTREGA"
                Dim dView As New Data.DataView(Me.oLugarEntrega.ObtenerElementosParaReportes())
                dView.Sort = "NOMBRE_LUGAR_ENTREGA"
                .DataSource = dView
                .Text = "TODOS"
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarLugarEntrega", ex)
        End Try
    End Sub

    Private Sub DesplegarAdunasExtranjeras()
        Me.oAduanales = New Class_CatAgenciaAduanales
        Try
            With Me.CboAduanaExtranjera
                .DisplayMember = "NOMBRE_AGENCIA_ADUANA"
                .ValueMember = "CODIGO_ADUANA"
                Dim dView As New Data.DataView(Me.oAduanales.ObtenerElementosExtranjerosParaReportes())
                dView.Sort = "NOMBRE_AGENCIA_ADUANA"
                .DataSource = dView
                .Text = "TODOS"
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarAdunasExtranjeras", ex)
        End Try
    End Sub

    Private Sub DesplegarAdunasNacionales()
        Me.oAduanales = New Class_CatAgenciaAduanales
        Try
            With Me.CboAduanaNacional
                .DisplayMember = "NOMBRE_AGENCIA_ADUANA"
                .ValueMember = "CODIGO_ADUANA"
                Dim dView As New Data.DataView(Me.oAduanales.ObtenerElementosNacionalesParaReportes())
                dView.Sort = "NOMBRE_AGENCIA_ADUANA"
                .DataSource = dView
                .Text = "TODOS"
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarAdunasNacionales", ex)
        End Try
    End Sub

    Private Sub Rpt_Embarques_Empaque_Y_Embarque_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DesplegarCultivos()
        Me.DesplegarTiposMercados()
        Me.DesplegarLugarEntrega()
        Me.DesplegarProductor()
        Me.DesplegarAdunasExtranjeras()
        Me.DesplegarAdunasNacionales()

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

            FormatoDeReporte = "RPT_EMBARQUES_AGRUPADOS_POR_EMBARQUE_ARTICULO"

            oReporte = New Class_Reporte(FormatoDeReporte, Rpt)
            Rpt.SetParameterValue("@FECHA1", Format(Me.DtFechaDesde.Value, "yyyy-dd-MM").ToString)
            Rpt.SetParameterValue("@FECHA2", Format(Me.DtFechaHasta.Value, "yyyy-dd-MM").ToString)
            Rpt.SetParameterValue("@CODIGO_CULTIVO", Me.cboCultivo.SelectedValue.ToString())
            Rpt.SetParameterValue("@CODIGO_ARTICULO", Me.TxtCodigoArticulo.Text)
            Rpt.SetParameterValue("@CODIGO_TIPO_MERCADO", Me.CboTipoMercado.SelectedValue.ToString)
            Rpt.SetParameterValue("@CODIGO_CLIENTE", Me.TxtCliente.Text)
            Rpt.SetParameterValue("@CODIGO_PRODUCTOR", Me.CboProductor.SelectedValue.ToString)
            Rpt.SetParameterValue("@CODIGO_ADUANA_EXTRANJERA", Me.CboAduanaExtranjera.SelectedValue.ToString)
            Rpt.SetParameterValue("@CODIGO_ADUANA_NACIONAL", Me.CboAduanaNacional.SelectedValue.ToString)
            Rpt.SetParameterValue("@CODIGO_LUGAR_ENTREGA", Me.CboLugarEntrega.SelectedValue.ToString)
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

    Private Sub CboLugarEntrega_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CboLugarEntrega.KeyDown
        Select Case e.KeyCode
            Case Keys.Return
                Me.tsbConsultar.PerformClick()
        End Select
    End Sub

    Private Sub TxtCodArticulo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DtFechaHasta.KeyPress, DtFechaDesde.KeyPress, _
    cboCultivo.KeyPress, CboAduanaExtranjera.KeyPress, CboAduanaNacional.KeyPress, CboLugarEntrega.KeyPress, CboProductor.KeyPress, CboTipoMercado.KeyPress, TxtCliente.KeyPress, TxtCodigoArticulo.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub cboCultivo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtFechaHasta.KeyDown, DtFechaDesde.KeyDown, cboCultivo.KeyDown, _
    CboAduanaExtranjera.KeyDown, CboAduanaNacional.KeyDown, CboProductor.KeyDown, CboTipoMercado.KeyDown
        txtTAB(e)
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub

End Class