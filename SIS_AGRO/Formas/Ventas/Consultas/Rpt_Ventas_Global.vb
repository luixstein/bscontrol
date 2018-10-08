Option Strict On

Imports CrystalDecisions.CrystalReports.Engine

Public Class Rpt_Ventas_Global

    Private oArticulos As New Class_CatArticulos
    Private oClientes As New Class_CatClientes
    'Private oAduanales As New Class_CatAgenciaAduanales

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

    Private Sub DesplegarAlmacen()
        Dim oAlmacen As New Class_CatAlmacenes
        Try
            With Me.CboAlmacen
                .DisplayMember = "NOMBRE_ALMACEN"
                .ValueMember = "CODIGO_ALMACEN"

                Dim dView As New Data.DataView(oAlmacen.ObtenerAlmacenesParaReportes())
                dView.Sort = "NOMBRE_ALMACEN"
                .DataSource = dView
                .Text = "TODOS"
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarAlmacen", ex)
        End Try
    End Sub

    Private Sub DesplegarTiposDocumentos()
        Dim oDocumentos As New Class_CatDocumentos
        Try
            With Me.CboTipoDocumento
                .DisplayMember = "NOMBRE_TIPO_DOCUMENTO"
                .ValueMember = "CODIGO_TIPO_DOCUMENTO"

                Dim dView As New Data.DataView(oDocumentos.ObtenerTiposDocumentosParaReportes("", "0", "CODIGO_MODULO='VTA' AND AFECTA_CXC='1' AND AFECTA_INVENTARIOS='1' "))
                dView.Sort = "NOMBRE_TIPO_DOCUMENTO"
                .DataSource = dView
                .Text = "TODOS"
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarAlmacen", ex)
        End Try
    End Sub

    Private Sub DesplegarNegociacion()
        Dim oNegociacion As New Class_CatTiposNegociaciones
        Try
            With Me.CboNegociacion
                .DisplayMember = "NOMBRE_TIPO_NEGOCIACION"
                .ValueMember = "CODIGO_TIPO_NEGOCIACION"

                Dim dView As New Data.DataView(oNegociacion.ObtenerTiposNegociacionesParaReportes())
                dView.Sort = "NOMBRE_TIPO_NEGOCIACION"
                .DataSource = dView
                .Text = "TODOS"
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarNegociacion", ex)
        End Try
    End Sub

    Private Sub DesplegarMercados()
        Dim oMercados As New Class_CatTiposMercados
        Try
            With Me.CboMercado
                .DisplayMember = "NOMBRE_TIPO_MERCADO"
                .ValueMember = "CODIGO_TIPO_MERCADO"

                Dim dView As New Data.DataView(oMercados.ObtenerTiposMercadosParaReportes())
                dView.Sort = "NOMBRE_TIPO_MERCADO"
                .DataSource = dView
                .Text = "TODOS"
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarMercados", ex)
        End Try
    End Sub

    Private Sub DesplegarEstatusVentas()
        Dim oEstatusVentas As New Class_CatEstatusVentas
        Try
            With Me.CboEstatus
                .DisplayMember = "ESTATUS_COMPLETO"
                .ValueMember = "ESTATUS_VENTA"

                Dim dView As New Data.DataView(oEstatusVentas.EstatusVentasParaReportes())
                dView.Sort = "ESTATUS_COMPLETO"
                .DataSource = dView
                .Text = "APLICADA"
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarEstatusEmbarque", ex)
        End Try
    End Sub

    Private Sub DesplegarZonas()
        Dim oZonas As New Class_CatZonas()
        Try
            With Me.CboZona
                .DisplayMember = "NOMBRE_ZONA"
                .ValueMember = "CODIGO_ZONA"

                Dim dView As New Data.DataView(oZonas.ObtenerZonasParaReportes())
                dView.Sort = "NOMBRE_ZONA"
                .DataSource = dView
                .SelectedValue = "T"
                '.Text = "TODOS"
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarZonas", ex)
        End Try
    End Sub

    Private Sub DesplegarVendedores()
        Dim oVendedores As New Class_CatVendedores
        Try
            With Me.CboVendedores
                .DisplayMember = "NOMBRE_VENDEDOR"
                .ValueMember = "CODIGO_VENDEDOR"

                Dim dView As New Data.DataView(oVendedores.ObtenerVendedoresParaReportes)
                dView.Sort = "NOMBRE_VENDEDOR"
                .DataSource = dView
                .SelectedValue = 0
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarVendedores", ex)
        End Try
    End Sub

    Private Sub DesplegarPlazas()
        Dim oPlazas As New Class_SisPlazas
        Try
            With Me.cboPlaza
                .DisplayMember = "NOMBRE_PLAZA"
                .ValueMember = "CODIGO_PLAZA"

                Dim dView As New Data.DataView(oPlazas.ObtenerElementosParaReporte)
                dView.Sort = "NOMBRE_PLAZA"
                .DataSource = dView
                .SelectedValue = 0
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarPlazas", ex)
        End Try
    End Sub

    Private Sub Rpt_Embarques_Empaque_Y_Embarque_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DesplegarAlmacen()
        Me.DesplegarEstatusVentas()
        Me.DesplegarTiposDocumentos()
        Me.DesplegarNegociacion()
        Me.DesplegarMercados()
        Me.DesplegarZonas()
        Me.DesplegarVendedores()
        Me.DesplegarPlazas()

        Me.CboEstatus.SelectedValue = "A"
        Me.DtFechaDesde.Value = FechaActualINI()
        Me.DtFechaHasta.Value = Date.Now

        Me.CboVendedores.Visible = False
        Me.LblVendedor.Visible = False
    End Sub

    Private Sub tsbConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbConsultar.Click
        Me.Consultar()
    End Sub

    'Private Sub Consultar()
    '    Dim FormatoDeReporte As String = ""
    '    Dim Rpt As ReportDocument
    '    Rpt = New ReportDocument
    '    Dim oReporte As Class_Reporte
    '    Try

    '        FormatoDeReporte = "RPT_VENTAS"

    '        oReporte = New Class_Reporte(FormatoDeReporte, Rpt)
    '        Rpt.SetParameterValue("@CODIGO_CLIENTE", "CN0120")

    '        Dim frm As New Reporte(Rpt)
    '        frm.CRViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
    '        frm.Show()
    '    Catch ex As Exception
    '        HandleError(Me.Name, "Consultar", ex)
    '    Finally
    '        oReporte = Nothing
    '    End Try
    'End Sub

    Private Sub Consultar()
        Dim FormatoDeReporte As String = ""
        Dim Rpt As New ReportDocument
        Dim oReporte As Class_Reporte
        Try

            If Me.ValidarPeriodo = False Then
                Exit Sub
            End If

            If Me.RdnListadoDesagrupado.Checked = True Then
                FormatoDeReporte = "RPT_VENTAS_LISTADO_DOCUMENTOS_VENTAS"
            ElseIf Me.RdnPorCliente.Checked = True Then
                FormatoDeReporte = "RPT_VENTAS_AGRUPADO_CLIENTE"
            Else
                FormatoDeReporte = "RPT_VENTAS_TOTALIZADAS_CLIENTE"
            End If

            oReporte = New Class_Reporte(FormatoDeReporte, Rpt)
            Rpt.SetParameterValue("@FECHA1", Format(Me.DtFechaDesde.Value, "yyyy-dd-MM"))
            Rpt.SetParameterValue("@FECHA2", Format(Me.DtFechaHasta.Value, "yyyy-dd-MM"))
            Rpt.SetParameterValue("@CODIGO_CLIENTE", Me.TxtCliente.Text)
            Rpt.SetParameterValue("@CODIGO_ALMACEN", Me.CboAlmacen.SelectedValue.ToString)
            Rpt.SetParameterValue("@CODIGO_TIPO_DOCUMENTO", Me.CboTipoDocumento.SelectedValue.ToString)
            Rpt.SetParameterValue("@ESTATUS_VENTA", Me.CboEstatus.SelectedValue.ToString)
            Rpt.SetParameterValue("@CODIGO_ZONA", Me.CboZona.SelectedValue.ToString)
            Rpt.SetParameterValue("@CODIGO_TIPO_MERCADO", Me.CboMercado.SelectedValue.ToString)
            Rpt.SetParameterValue("@CODIGO_TIPO_NEGOCIACION", Me.CboNegociacion.SelectedValue.ToString)
            Rpt.SetParameterValue("@MOSTAR_CON_SALDO", IIf(Me.CkbSaldo.Checked = True, "1", "0"))
            Rpt.SetParameterValue("@CODIGO_VENDEDOR", Me.CboVendedores.SelectedValue)
            Rpt.SetParameterValue("@CODIGO_PLAZA", Me.cboPlaza.SelectedValue)

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
        Me.DtFechaHasta.Enabled = False
        Me.DtFechaDesde.Enabled = True
        Me.DtFechaHasta.Enabled = True

        If Me.DtFechaDesde.Value > Me.DtFechaHasta.Value Then
            MsgBox("Rango de fechas inválidas.", MsgBoxStyle.Exclamation, Me.Name)
            Me.DtFechaDesde.Focus()
            Exit Function
        End If

        Return True
    End Function

    Private Sub TxtCodArticulo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DtFechaHasta.KeyPress, DtFechaDesde.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub cboCultivo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtFechaHasta.KeyDown, DtFechaDesde.KeyDown, CboTipoDocumento.KeyDown, CboAlmacen.KeyDown
        txtTAB(e)
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub

    Private Sub RdnPorCliente_CheckedChanged(sender As Object, e As EventArgs) Handles RdnPorCliente.CheckedChanged
        If Me.RdnPorCliente.Checked = True Then
            Me.CboVendedores.Visible = True
            Me.LblVendedor.Visible = True
        Else
            Me.CboVendedores.Visible = False
            Me.LblVendedor.Visible = False
        End If

    End Sub

End Class