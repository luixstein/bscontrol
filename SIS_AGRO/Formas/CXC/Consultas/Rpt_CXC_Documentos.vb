Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class Rpt_CXC_Documentos
    Private oClientes As New Class_CatClientes
    'Private oZona As New Class_CatZonas

#Region "Opciones"

    Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click
        Me.Imprimir()
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub
#End Region

#Region "Eventos Genericos"
    Private Sub Rpt_CXC_Documentos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Inicializa()
    End Sub

    Private Sub txtTextoKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigoCliente.KeyPress, txtCodigoVendedor.KeyPress, CboDocumentos.KeyPress, CboTipoMercado.KeyPress, _
         CboEstatus.KeyPress, dpFechaInicio.KeyPress, dpFechaFinal.KeyPress, txtCuentaBancaria.KeyPress, CboZona.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub txtNumerosEnterosKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCuentaBancaria.KeyPress, CboZona.KeyPress
        txtSoloNumerosEnteros(e)
        txtNoBeep(e)
    End Sub

    Private Sub txtCodicoCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigoCliente.KeyDown
        Dim sText As String
        Select Case e.KeyCode
            Case Keys.F6
Buscar:
                sText = Me.oClientes.BusquedaVisual_PorDescripcion
                If txtLEN(sText) = True Then Me.txtCodigoCliente.Text = sText
            Case Keys.Enter
                If txtLEN(Me.txtCodigoCliente.Text) = False Then
                    Me.lblNombreCliente.Text = ""
                    'GoTo Buscar : Exit Sub
                    'Me.tsbImprimir.PerformClick()
                    If Me.RdbDetalleDepositos.Checked = False Then
                        Me.txtCodigoVendedor.Focus()
                    Else
                        Me.dpFechaInicio.Focus()
                    End If
                    Exit Sub
                End If

                oClientes = New Class_CatClientes(Me.txtCodigoCliente.Text)
                If Me.oClientes.Existe = False Then
                    Me.lblNombreCliente.Text = "" : GoTo Buscar : Exit Sub
                End If

                Me.lblNombreCliente.Text = Me.oClientes.NOMBRE_CLIENTE
                'Me.txtCodigoVendedor.Focus()
                If Me.RdbDetalleDepositos.Checked = False Then
                    Me.txtCodigoVendedor.Focus()
                Else
                    Me.dpFechaInicio.Focus()
                End If
        End Select
    End Sub

    Private Sub txtCodigoVendedor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigoVendedor.KeyDown
        Select Case e.KeyCode
            Case Keys.F6
busqueda_Visual:
                Dim oCodigoVendedor As New Class_CatVendedores
                Dim sCodigoVendedor As String = oCodigoVendedor.BusquedaVisual_PorDescripcion
                If txtLEN(sCodigoVendedor) = True Then
                    Me.txtCodigoVendedor.Text = sCodigoVendedor
                    sCodigoVendedor = Replace(sCodigoVendedor, "'", "''")
                    Dim sql As New Class_find("Select NOMBRE_VENDEDOR From CAT_VENDEDORES Where CODIGO_VENDEDOR=" & sCodigoVendedor & "")
                    Me.txtCodigoVendedor.Text = sCodigoVendedor.ToString
                    Me.lblNombreVendedor.Text = sql.Result1
                End If

            Case Keys.Return
                Dim sql As New Class_find("Select NOMBRE_VENDEDOR From CAT_VENDEDORES Where CODIGO_VENDEDOR=" & valorNumerico(Me.txtCodigoVendedor.Text) & "")
                If sql.Result1 = "" Then
                    Me.lblNombreVendedor.Text = ""
                Else
                    Me.lblNombreVendedor.Text = sql.Result1
                End If
                sql = Nothing
        End Select
        Me.CboDocumentos.Focus()
    End Sub

    Private Sub txtCuentaBancaria_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCuentaBancaria.KeyDown
        Select Case e.KeyCode
            Case Keys.F6
busqueda_Visual:
                Dim oCuentaBancaria As New Class_CatCuentasBancarias
                Dim sCuentaBancaria As String = oCuentaBancaria.BusquedaVisual_PorDescripcion
                If txtLEN(sCuentaBancaria) = True Then
                    Me.txtCuentaBancaria.Text = sCuentaBancaria
                    sCuentaBancaria = Replace(sCuentaBancaria, "'", "''")
                    Dim sql As New Class_find("Select NOMBRE_CUENTA_BANCARIA From CAT_CUENTAS_BANCARIAS Where ID_CUENTA_BANCARIA=" & sCuentaBancaria & "")
                    Me.txtCuentaBancaria.Text = sCuentaBancaria.ToString
                    Me.lblCuentaBancaria.Text = sql.Result1
                    Me.tsbImprimir.PerformClick()
                End If

            Case Keys.Return
                Dim sql As New Class_find("Select NOMBRE_CUENTA_BANCARIA From CAT_CUENTAS_BANCARIAS Where ID_CUENTA_BANCARIA=" & valorNumerico(Me.txtCuentaBancaria.Text) & "")
                If sql.Result1 = "" Then
                    Me.lblCuentaBancaria.Text = ""
                    Me.tsbImprimir.PerformClick()
                Else
                    Me.lblCuentaBancaria.Text = sql.Result1
                    Me.tsbImprimir.PerformClick()
                End If
                sql = Nothing
        End Select
    End Sub

    Private Sub CboDocumentos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CboDocumentos.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.CboZona.Focus()
        End If
    End Sub

    Private Sub CboZona_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CboZona.KeyDown
        If e.KeyCode = Keys.Return Then
            If Me.RdbDetalleDepositos.Checked = False Then
                Me.CboTipoMercado.Focus()
            Else
                Me.txtCuentaBancaria.Focus()
            End If
        End If
    End Sub

    '    Private Sub TxtZona_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    '        Dim sText As String
    '        Select Case e.KeyCode
    '            Case Keys.F6
    'Buscar:
    '                sText = Me.oZona.BusquedaVisual_PorDescripcion
    '                If txtLEN(sText) = True Then Me.TxtZona.Text = sText
    '            Case Keys.Enter
    '                If txtLEN(Me.TxtZona.Text) = False Then
    '                    Me.lblZona.Text = ""
    '                    'GoTo Buscar : Exit Sub
    '                    'Me.tsbImprimir.PerformClick()

    '                    If Me.RdbDetalleDepositos.Checked = False Then
    '                        Me.CboTipoMercado.Focus()
    '                    Else
    '                        Me.txtCuentaBancaria.Focus()
    '                    End If
    '                    Exit Sub
    '                End If


    '                Dim sql As New Class_find("Select NOMBRE_ZONA From CAT_ZONAS Where CODIGO_ZONA=" & Me.TxtZona.Text & "")
    '                If sql.Result1 = "" Then
    '                    Me.TxtZona.Text = ""
    '                    Me.lblZona.Text = "" ': GoTo Buscar : Exit Sub
    '                Else
    '                    Me.lblZona.Text = Me.oZona.Nombre_Zona
    '                End If

    '                If Me.RdbDetalleDepositos.Checked = False Then
    '                    Me.CboTipoMercado.Focus()
    '                Else
    '                    Me.txtCuentaBancaria.Focus()
    '                End If
    '        End Select
    '    End Sub

    Private Sub CboTipoMercado_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CboTipoMercado.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.tsbImprimir.PerformClick()
        End If
    End Sub

    Private Sub dpFechaFinal_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dpFechaFinal.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.CboEstatus.Focus()
        End If
    End Sub

    Private Sub CboEstatus_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CboEstatus.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.CboZona.Focus()
        End If
    End Sub

    Private Sub Rdb_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RdbGlobalCXC.CheckedChanged, RdbDetalleCXC.CheckedChanged, RdbDetalleDepositos.CheckedChanged
        Me.OcultarControles()
    End Sub
#End Region

#Region "Métodos y procedimientos"

    Private Sub Inicializa()
        Me.DesplegarMercado()
        Me.DesplegarDocumentos()
        Me.DesplegarZona()

        ' Me.DesplegarEstatus()
        Me.CboTipoMercado.SelectedValue = "T"
        Me.CboDocumentos.SelectedValue = "T"
        Me.CboZona.SelectedValue = Plaza.CODIGO_ZONA_PRINCIPAL
        Me.CboEstatus.Text = "APLICADOS"
        Me.RdbGlobalCXC.Checked = True
        'Me.ocultarcontroles()
        Me.dpFechaInicio.Value = CDate(Format(Date.Now, "01-MM-yyyy"))
        Me.dpFechaFinal.Value = Date.Now
    End Sub

    Private Sub DesplegarDocumentos()
        Dim oElementos As New Class_CatDocumentos
        With Me.CboDocumentos
            .DisplayMember = "NOMBRE_TIPO_DOCUMENTO"
            .ValueMember = "CODIGO_TIPO_DOCUMENTO"
            Dim dView As New Data.DataView(oElementos.ObtenerTiposDocumentosParaReportes("VTA", Usuario.Codigo_Plaza.ToString, " AFECTA_CXC='1' "))
            dView.Sort = "NOMBRE_TIPO_DOCUMENTO"
            .DataSource = dView
            If dView.Count > 0 Then
                .SelectedIndex = 0
            End If
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

    Private Sub DesplegarMercado()
        Dim oElementos As New Class_TiposMercados
        With Me.CboTipoMercado
            .DisplayMember = "NOMBRE_TIPO_MERCADO"
            .ValueMember = "CODIGO_TIPO_MERCADO"

            Dim dView As New Data.DataView(oElementos.ObtenerTiposMercadosParaReportes)
            dView.Sort = "NOMBRE_TIPO_MERCADO"
            .DataSource = dView
            If dView.Count > 0 Then
                .SelectedIndex = 0
            End If
        End With
    End Sub

    'Private Sub DesplegarEstatus()
    '    Dim oElementos As New Class_CatEstatus
    '    With Me.CboEstatus
    '        .DisplayMember = "ESTATUS"
    '        .ValueMember = "CODIGO_ESTATUS"
    '        Dim dView As New Data.DataView(oElementos.EstatusParaReportes)
    '        dView.Sort = "ESTATUS"
    '        .DataSource = dView
    '        If dView.Count > 0 Then
    '            .SelectedIndex = 0
    '        End If
    '    End With
    'End Sub
    Private Sub Imprimir()
        Dim StrFiltros As String = ""
        Dim Rpt As New ReportDocument
        Dim oReporte As Class_Reporte
        Try
            If Me.RdbGlobalCXC.Checked = True Then
                oReporte = New Class_Reporte("RPT_CXC_COBRANZA_GLOBAL", Rpt)
            ElseIf Me.RdbDetalleCXC.Checked = True Then
                oReporte = New Class_Reporte("RPT_CXC_COBRANZA_DETALLE", Rpt)
            ElseIf Me.RdbDetalleDepositos.Checked = True Then
                oReporte = New Class_Reporte("RPT_CXC_DETALLE_DEPOSITOS", Rpt)
            Else
                oReporte = New Class_Reporte("RPT_CXC_DETALLE_DEPOSITOS_BULTOS", Rpt)
            End If

            If Not oReporte.RptCargado Then
                Exit Sub
            End If

            If Me.RdbGlobalCXC.Checked = True Or Me.RdbDetalleCXC.Checked = True Then
                Rpt.SetParameterValue("@CODIGO_CLIENTE", Me.txtCodigoCliente.Text)
                Rpt.SetParameterValue("@CODIGO_VENDEDOR", Me.txtCodigoVendedor.Text)
                Rpt.SetParameterValue("@CODIGO_TIPO_DOCUMENTO", Me.CboDocumentos.SelectedValue.ToString)
                Rpt.SetParameterValue("@CODIGO_ZONA", Me.CboZona.SelectedValue.ToString)
                Rpt.SetParameterValue("@CODIGO_TIPO_MERCADO", Me.CboTipoMercado.SelectedValue.ToString)
            ElseIf Me.RdbDetalleDepositos.Checked = True Then
                Rpt.SetParameterValue("@CODIGO_CLIENTE", Me.txtCodigoCliente.Text)
                Rpt.SetParameterValue("@FECHA1", Format(Me.dpFechaInicio.Value, "yyyy-dd-MM"))
                Rpt.SetParameterValue("@FECHA2", Format(Me.dpFechaFinal.Value, "yyyy-dd-MM"))
                Rpt.SetParameterValue("@ESTATUS", Me.CboEstatus.Text.Substring(0, Len(Me.CboEstatus.Text) - (Len(Me.CboEstatus.Text) - 1)))
                Rpt.SetParameterValue("@CUENTA_BANCARIA", Me.txtCuentaBancaria.Text)
                Rpt.SetParameterValue("@CODIGO_ZONA", Me.CboZona.SelectedValue.ToString)
                Rpt.SetParameterValue("@MOSTRAR_BULTOS", "0")
            Else
                Rpt.SetParameterValue("@CODIGO_CLIENTE", Me.txtCodigoCliente.Text)
                Rpt.SetParameterValue("@FECHA1", Format(Me.dpFechaInicio.Value, "yyyy-dd-MM"))
                Rpt.SetParameterValue("@FECHA2", Format(Me.dpFechaFinal.Value, "yyyy-dd-MM"))
                Rpt.SetParameterValue("@ESTATUS", Me.CboEstatus.Text.Substring(0, Len(Me.CboEstatus.Text) - (Len(Me.CboEstatus.Text) - 1)))
                Rpt.SetParameterValue("@CUENTA_BANCARIA", Me.txtCuentaBancaria.Text)
                Rpt.SetParameterValue("@CODIGO_ZONA", Me.CboZona.SelectedValue.ToString)
                Rpt.SetParameterValue("@MOSTRAR_BULTOS", "1")
            End If

            Dim frm As New Reporte(Rpt)
            frm.CRViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            frm.Show()
        Catch ex As Exception
            HandleError(Me.Name, "Reporte de cxc", ex)
        Finally
            oReporte = Nothing
        End Try
    End Sub

    Private Sub OcultarControles()
        If RdbGlobalCXC.Checked = True Or RdbDetalleCXC.Checked = True Then
            Me.lblDisplayFechaInicio.Visible = False : Me.dpFechaInicio.Visible = False
            Me.LblDisplayFechaFinal.Visible = False : Me.dpFechaFinal.Visible = False
            Me.lblDisplayEstatus.Visible = False : Me.CboEstatus.Visible = False
            Me.lblDisplayCuentaBancaria.Visible = False : Me.txtCuentaBancaria.Visible = False : Me.lblCuentaBancaria.Visible = False
            Me.lblDisplayVendedor.Visible = True : Me.txtCodigoVendedor.Visible = True : Me.lblNombreVendedor.Visible = True
            Me.LblDisplayDocumento.Visible = True : Me.CboDocumentos.Visible = True
            Me.LblDisplayTipoMercado.Visible = True : Me.CboTipoMercado.Visible = True
        Else
            Me.lblDisplayFechaInicio.Visible = True : Me.lblDisplayFechaInicio.Location = New Point(4, 54) : Me.dpFechaInicio.Visible = True : Me.dpFechaInicio.Location = New Point(88, 51)
            Me.LblDisplayFechaFinal.Visible = True : Me.LblDisplayFechaFinal.Location = New Point(215, 54) : Me.dpFechaFinal.Visible = True : Me.dpFechaFinal.Location = New Point(265, 50)
            Me.lblDisplayEstatus.Visible = True : Me.lblDisplayEstatus.Location = New Point(4, 80) : Me.CboEstatus.Visible = True : Me.CboEstatus.Location = New Point(88, 80)
            Me.lblDisplayCuentaBancaria.Visible = True : Me.lblDisplayCuentaBancaria.Location = New Point(4, 140) : Me.txtCuentaBancaria.Visible = True : Me.txtCuentaBancaria.Location = New Point(88, 140)
            Me.lblCuentaBancaria.Visible = True : Me.lblCuentaBancaria.Location = New Point(140, 142)
            Me.lblDisplayVendedor.Visible = False : Me.txtCodigoVendedor.Visible = False : Me.lblNombreVendedor.Visible = False
            Me.LblDisplayDocumento.Visible = False : Me.CboDocumentos.Visible = False
            Me.LblDisplayTipoMercado.Visible = False : Me.CboTipoMercado.Visible = False
        End If
    End Sub
#End Region

End Class