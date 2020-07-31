Option Strict On

Imports CrystalDecisions.CrystalReports.Engine

Public Class Rpt_CXC_Documentos
    Private oClientes As New Class_CatClientes

#Region "Opciones"
    Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click
        Me.Imprimir()
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub
#End Region

#Region "Eventos"
#Region "Eventos Genericos"
    Private Sub txtTextoKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigoCliente.KeyPress, txtCodigoVendedor.KeyPress, CboDocumentos.KeyPress, CboTipoMercado.KeyPress,
         CboEstatus.KeyPress, dpFechaInicio.KeyPress, dpFechaFinal.KeyPress, txtCuentaBancaria.KeyPress, CboZona.KeyPress, rbtDocumentoVenta.KeyPress, rbtCobranzaAnticipo.KeyPress, rbtPropietariosConAnticipos.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub txtNumerosEnterosKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCuentaBancaria.KeyPress, CboZona.KeyPress, txtPropietario.KeyPress, txtCodigoUsuario.KeyPress
        txtSoloNumerosEnteros(e)
        txtNoBeep(e)
    End Sub

    Private Sub txtSoloNumericosKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTipoCambio.KeyPress
        Dim txt As TextBox = CType(sender, TextBox)
        txtSoloNumerosDecimales(e, txt.Text)
        txtNoBeep(e)
    End Sub
#End Region

    Private Sub Rpt_CXC_Documentos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Inicializa()
    End Sub

    Private Sub txtCodigoCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigoCliente.KeyDown
        Try
            Dim sText As String
            Select Case e.KeyCode
                Case Keys.F6
Buscar:

                    If Empresa_Sistema.PERMITE_CLIENTES_MULTIPLAZA = True Then
                        sText = Me.oClientes.BusquedaVisual_PorDescripcionSinFiltroZona
                    Else
                        sText = Me.oClientes.BusquedaVisual_PorDescripcion
                    End If

                    If txtLEN(sText) = True Then Me.txtCodigoCliente.Text = sText
                Case Keys.Enter
                    If txtLEN(Me.txtCodigoCliente.Text) = False Then
                        Me.lblNombreCliente.Text = ""
                        txtTAB(e)
                        Return
                    End If
                    oClientes = New Class_CatClientes(Me.txtCodigoCliente.Text)
                    If Me.oClientes.Existe = False Then
                        Me.lblNombreCliente.Text = "" : GoTo Buscar : Exit Sub
                    End If
                    Me.lblNombreCliente.Text = Me.oClientes.NOMBRE_CLIENTE
                    txtTAB(e)
            End Select
        Catch ex As Exception
            HandleError(Me.Name, "txtCodicoCliente_KeyDown", ex)
        End Try
    End Sub

    Private Sub txtCodigoVendedor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigoVendedor.KeyDown
        Try
            Dim sText As String, oVendedor As New Class_CatVendedores
            Select Case e.KeyCode
                Case Keys.F6
Buscar:
                    oVendedor = New Class_CatVendedores
                    sText = oVendedor.BusquedaVisual_PorDescripcion
                    If txtLEN(sText) = True Then Me.txtCodigoVendedor.Text = sText
                Case Keys.Return
                    If txtLEN(Me.txtCodigoVendedor.Text) = False Then
                        Me.lblNombreVendedor.Text = ""
                        txtTAB(e)
                        Return
                    Else
                        oVendedor = New Class_CatVendedores(Me.txtCodigoVendedor.Text)
                        If oVendedor.Existe = False Then
                            Me.txtCodigoVendedor.Text = "" : Me.lblNombreVendedor.Text = ""
                            GoTo Buscar : Exit Sub
                        End If
                        Me.lblNombreVendedor.Text = oVendedor.NOMBRE_VENDEDOR
                    End If
                    txtTAB(e)
            End Select
        Catch ex As Exception
            HandleError(Me.Name, "txtCodigoVendedor_KeyDown", ex)
        End Try
    End Sub

    Private Sub txtCuentaBancaria_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCuentaBancaria.KeyDown
        Try
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
        Catch ex As Exception
            HandleError(Me.Name, "txtCuentaBancaria_KeyDown", ex)
        End Try
    End Sub

    Private Sub txtCodigoUsuario_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigoUsuario.KeyDown
        Try
            Dim sText As String, oUsuario As New Class_sisUsuarios
            Select Case e.KeyCode
                Case Keys.F6
Buscar:
                    oUsuario = New Class_sisUsuarios
                    sText = oUsuario.BusquedaVisual_PorDescripcion
                    If txtLEN(sText) = True Then Me.txtCodigoUsuario.Text = sText
                Case Keys.Return
                    If txtLEN(Me.txtCodigoUsuario.Text) = False Then
                        Me.LblNombreUsuario.Text = ""
                        txtTAB(e)
                        Return
                    Else
                        oUsuario = New Class_sisUsuarios(CInt(Me.txtCodigoUsuario.Text))
                        If oUsuario.Existe = False Then
                            Me.txtCodigoUsuario.Text = "" : Me.LblNombreUsuario.Text = ""
                            GoTo Buscar : Exit Sub
                        End If
                        Me.LblNombreUsuario.Text = oUsuario.Nombre_Usuario
                    End If
                    txtTAB(e)
            End Select
        Catch ex As Exception
            HandleError(Me.Name, "txtCodigoUsuario_KeyDown", ex)
        End Try
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

    Private Sub CboPlaza_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPlaza.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.CboZona.Focus()
        End If
    End Sub

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

    Private Sub Rdb_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RdbGlobalCXC.CheckedChanged, RdbDetalleCXC.CheckedChanged, RdbDetalleDepositos.CheckedChanged,
        rdbGlobalCxcPropietario.CheckedChanged, rbtCobranzaAnticipo.CheckedChanged
        Me.OcultarControles()
    End Sub

    Private Sub txtPropietario_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPropietario.KeyDown
        Dim sText As String, oPropietarios As Class_CatPropietarios
        Select Case e.KeyCode
            Case Keys.F6
Buscar:
                oPropietarios = New Class_CatPropietarios
                sText = oPropietarios.BusquedaVisual_PorDescripcion
                If txtLEN(sText) = True Then Me.txtPropietario.Text = sText
            Case Keys.Enter
                If txtLEN(Me.txtPropietario.Text) = False Then
                    Me.lblPropietario.Text = ""
                Else
                    oPropietarios = New Class_CatPropietarios(Me.txtPropietario.Text)
                    If oPropietarios.Existe = False Then
                        Me.txtPropietario.Text = "" : Me.lblPropietario.Text = ""
                        GoTo Buscar : Exit Sub
                    End If
                    Me.lblPropietario.Text = oPropietarios.NOMBRE_PROPIETARIO
                End If
                txtTAB(e)
        End Select
    End Sub

#End Region

#Region "Métodos y procedimientos"

    Private Sub Inicializa()
        Try
            Me.DesplegarMercado()
            Me.DesplegarDocumentos()
            Me.DesplegarZona()
            Me.DesplegarPlaza()
            Me.DesplegarMonedas()
            ' Me.DesplegarEstatus()
            Me.CboTipoMercado.SelectedValue = "T"
            Me.CboDocumentos.SelectedValue = "T"
            Me.cboPlaza.SelectedValue = 0
            Me.CboZona.SelectedValue = "T" 'Plaza.CODIGO_ZONA_PRINCIPAL
            Me.CboEstatus.Text = "APLICADOS"
            'Me.ocultarcontroles()
            Me.chkClientesSaldoVencido.Checked = False
            Me.dpFechaInicio.Value = CDate(Format(Date.Now, "01-MM-yyyy"))
            Me.dpFechaFinal.Value = Date.Now
        Catch ex As Exception
            HandleError(Me.Name, "Inicializa", ex)
        End Try
    End Sub

    Private Sub DesplegarDocumentos()
        Try
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
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarDocumentos", ex)
        End Try
    End Sub

    Private Sub DesplegarZona()
        Try
            Dim oElementos As New Class_CatZonas
            With Me.CboZona
                .DisplayMember = "NOMBRE_ZONA"
                .ValueMember = "CODIGO_ZONA"
                Dim dView As New Data.DataView(oElementos.ObtenerZonasParaReportes())
                dView.Sort = "NOMBRE_ZONA"
                .DataSource = dView
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarZona", ex)
        End Try
    End Sub

    Private Sub DesplegarMercado()
        Try
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
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarMercado", ex)
        End Try
    End Sub

    Private Sub DesplegarPlaza()
        Try
            Dim oElementos As New Class_SisPlazas
            With Me.cboPlaza
                .DisplayMember = "NOMBRE_PLAZA"
                .ValueMember = "CODIGO_PLAZA"
                Dim dView As New Data.DataView(oElementos.ObtenerElementosParaReporte)
                dView.Sort = "NOMBRE_PLAZA"
                .DataSource = dView
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarPlaza", ex)
        End Try
    End Sub

    Private Sub DesplegarMonedas()
        With Me.CboMoneda
            .Items.Add("MXN")
            .Items.Add("USD")
            .Items.Add("TODAS")
            .SelectedItem = "TODAS"
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

                If Me.rbFormato1EdoCtaGlobal.Checked = True Then
                    oReporte = New Class_Reporte("RPT_CXC_COBRANZA_GLOBAL", Rpt)
                Else
                    oReporte = New Class_Reporte("RPT_CXC_COBRANZA_GLOBAL_MES_CARTERA", Rpt)
                End If

            ElseIf Me.RdbDetalleCXC.Checked = True Then
                oReporte = New Class_Reporte("RPT_CXC_COBRANZA_DETALLE", Rpt)
            ElseIf Me.RdbDetalleDepositos.Checked = True Then
                oReporte = New Class_Reporte("RPT_CXC_DETALLE_DEPOSITOS", Rpt)
            ElseIf Me.rdbGlobalCxcPropietario.Checked = True Then
                oReporte = New Class_Reporte("RPT_CXC_COBRANZA_GLOBAL_PROPIETARIOS", Rpt)
            ElseIf Me.rdbDetalleBultos.Checked = True Then
                oReporte = New Class_Reporte("RPT_CXC_DETALLE_DEPOSITOS_BULTOS", Rpt)
            ElseIf Me.rbtCobranzaAnticipo.Checked = True Then
                oReporte = New Class_Reporte("RPT_CXC_COBRANZA_CON_ANTICIPOS", Rpt)
            Else
                oReporte = New Class_Reporte("RPT_CXC_COBRANZA_PROPIETARIOS_CON_ANTICIPOS", Rpt)
            End If

            If Not oReporte.RptCargado Then
                Exit Sub
            End If

            If Me.RdbGlobalCXC.Checked = True Or Me.RdbDetalleCXC.Checked = True Or Me.rdbGlobalCxcPropietario.Checked = True Then
                Rpt.SetParameterValue("@CODIGO_CLIENTE", Me.txtCodigoCliente.Text)
                Rpt.SetParameterValue("@CODIGO_VENDEDOR", Me.txtCodigoVendedor.Text)
                Rpt.SetParameterValue("@CODIGO_TIPO_DOCUMENTO", Me.CboDocumentos.SelectedValue.ToString)
                Rpt.SetParameterValue("@CODIGO_ZONA", Me.CboZona.SelectedValue.ToString)
                Rpt.SetParameterValue("@CODIGO_TIPO_MERCADO", Me.CboTipoMercado.SelectedValue.ToString)
                Rpt.SetParameterValue("@CODIGO_PROPIETARIO", valorNumerico(Me.txtPropietario.Text))
                Rpt.SetParameterValue("@CODIGO_USUARIO_GRABO", IIf(txtLEN(Me.txtCodigoUsuario.Text) = True, Me.txtCodigoUsuario.Text, 0))
                Rpt.SetParameterValue("@SOLO_CON_SALDO_VENCIDO", IIf(Me.chkClientesSaldoVencido.Checked = True, "1", "0"))
                Rpt.SetParameterValue("@CODIGO_MONEDA", Me.CboMoneda.Text)

            ElseIf Me.RdbDetalleDepositos.Checked = True Then
                Rpt.SetParameterValue("@CODIGO_CLIENTE", Me.txtCodigoCliente.Text)
                Rpt.SetParameterValue("@FECHA1", Format(Me.dpFechaInicio.Value, "yyyy-dd-MM"))
                Rpt.SetParameterValue("@FECHA2", Format(Me.dpFechaFinal.Value, "yyyy-dd-MM"))
                Rpt.SetParameterValue("@ESTATUS", Me.CboEstatus.Text.Substring(0, Len(Me.CboEstatus.Text) - (Len(Me.CboEstatus.Text) - 1)))
                Rpt.SetParameterValue("@CUENTA_BANCARIA", Me.txtCuentaBancaria.Text)
                Rpt.SetParameterValue("@CODIGO_ZONA", Me.CboZona.SelectedValue.ToString)
                Rpt.SetParameterValue("@MOSTRAR_BULTOS", "0")
                Rpt.SetParameterValue("@CODIGO_PROPIETARIO", valorNumerico(Me.txtPropietario.Text))
                Rpt.SetParameterValue("@CODIGO_PLAZA", Me.cboPlaza.SelectedValue.ToString)
                Rpt.SetParameterValue("@FILTRAR_POR_FECHA_SERVIDOR", IIf(Me.rbtFechaServidor.Checked = True, "1", "0"))
                Rpt.SetParameterValue("@CODIGO_USUARIO_GRABO", IIf(txtLEN(Me.txtCodigoUsuario.Text) = True, Me.txtCodigoUsuario.Text, 0))
                Rpt.SetParameterValue("@FILTRAR_POR_FECHA_VENTA", IIf(Me.rbtDocumentoVenta.Checked = True, "1", "0"))
                Rpt.SetParameterValue("@CODIGO_VENDEDOR", Me.txtCodigoVendedor.Text)
                Rpt.SetParameterValue("@CODIGO_TIPO_DOCUMENTO_VENTA", Me.CboDocumentos.SelectedValue.ToString)
            ElseIf Me.rbtCobranzaAnticipo.Checked = True Or Me.rbtPropietariosConAnticipos.Checked Then
                Rpt.SetParameterValue("@CODIGO_CLIENTE", Me.txtCodigoCliente.Text)
                Rpt.SetParameterValue("@CODIGO_VENDEDOR", Me.txtCodigoVendedor.Text)
                Rpt.SetParameterValue("@CODIGO_TIPO_DOCUMENTO", Me.CboDocumentos.SelectedValue.ToString)
                Rpt.SetParameterValue("@CODIGO_ZONA", Me.CboZona.SelectedValue.ToString)
                Rpt.SetParameterValue("@CODIGO_TIPO_MERCADO", Me.CboTipoMercado.SelectedValue.ToString)
                Rpt.SetParameterValue("@CODIGO_PROPIETARIO", valorNumerico(Me.txtPropietario.Text))
                Rpt.SetParameterValue("@CODIGO_USUARIO_GRABO", IIf(txtLEN(Me.txtCodigoUsuario.Text) = True, Me.txtCodigoUsuario.Text, 0))
                If txtLEN(Me.txtTipoCambio.Text) = True Then
                    Rpt.SetParameterValue("@TIPO_CAMBIO", valorNumerico(Me.txtTipoCambio.Text))
                Else
                    MsgBox("Capture un tipo de cambio", MsgBoxStyle.Exclamation, Me.Text)
                    Me.txtTipoCambio.Focus()
                    Exit Sub
                End If

            Else 'Depositos x bulto
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
            HandleError(Me.Name, "Imprimir", ex)
        Finally
            oReporte = Nothing
        End Try
    End Sub

    Private Sub OcultarControles()
        Try
            Me.gbFormatoEdoCtaGlobal.Visible = False

            If Me.RdbGlobalCXC.Checked = True Or Me.RdbDetalleCXC.Checked = True Or Me.rdbGlobalCxcPropietario.Checked = True Then
                Me.lblDisplayFechaInicio.Visible = False : Me.dpFechaInicio.Visible = False
                Me.LblDisplayFechaFinal.Visible = False : Me.dpFechaFinal.Visible = False
                Me.lblDisplayEstatus.Visible = False : Me.CboEstatus.Visible = False
                Me.lblDisplayCuentaBancaria.Visible = False : Me.txtCuentaBancaria.Visible = False : Me.lblCuentaBancaria.Visible = False
                Me.lblDisplayVendedor.Visible = True : Me.txtCodigoVendedor.Visible = True : Me.lblNombreVendedor.Visible = True
                Me.LblDisplayDocumento.Visible = True : Me.CboDocumentos.Visible = True
                Me.LblDisplayTipoMercado.Visible = True : Me.CboTipoMercado.Visible = True
                Me.LblDisplayPlaza.Visible = False : Me.cboPlaza.Visible = False
                Me.gpFiltroFecha.Visible = False
                Me.chkClientesSaldoVencido.Visible = True
                Me.lblTipoCambio.Visible = False : Me.txtTipoCambio.Visible = False
                Me.LblMoneda.Visible = True : Me.CboMoneda.Visible = True
                If Me.RdbGlobalCXC.Checked = True Then
                    Me.gbFormatoEdoCtaGlobal.Visible = True
                End If

            ElseIf Me.rbtCobranzaAnticipo.Checked = True Or Me.rbtPropietariosConAnticipos.Checked = True Then
                Me.lblDisplayFechaInicio.Visible = False : Me.dpFechaInicio.Visible = False
                Me.LblDisplayFechaFinal.Visible = False : Me.dpFechaFinal.Visible = False
                Me.lblDisplayEstatus.Visible = False : Me.CboEstatus.Visible = False
                Me.lblDisplayCuentaBancaria.Visible = False : Me.txtCuentaBancaria.Visible = False : Me.lblCuentaBancaria.Visible = False
                Me.lblDisplayVendedor.Visible = True : Me.txtCodigoVendedor.Visible = True : Me.lblNombreVendedor.Visible = True
                Me.LblDisplayDocumento.Visible = True : Me.CboDocumentos.Visible = True
                Me.LblDisplayTipoMercado.Visible = True : Me.CboTipoMercado.Visible = True
                Me.LblDisplayPlaza.Visible = False : Me.cboPlaza.Visible = False
                Me.gpFiltroFecha.Visible = False
                Me.lblTipoCambio.Visible = True : Me.txtTipoCambio.Visible = True
                Me.chkClientesSaldoVencido.Visible = False
                Me.LblMoneda.Visible = False : Me.CboMoneda.Visible = False

            Else
                Me.lblDisplayFechaInicio.Visible = True : Me.dpFechaInicio.Visible = True ': Me.lblDisplayFechaInicio.Location = New Point(4, 54) :  : Me.dpFechaInicio.Location = New Point(88, 51)
                Me.LblDisplayFechaFinal.Visible = True : Me.dpFechaFinal.Visible = True ': Me.LblDisplayFechaFinal.Location = New Point(215, 54)  : Me.dpFechaFinal.Location = New Point(265, 50)
                Me.lblDisplayEstatus.Visible = True : Me.CboEstatus.Visible = True ': Me.lblDisplayEstatus.Location = New Point(4, 80) : Me.CboEstatus.Location = New Point(88, 80)
                Me.lblDisplayCuentaBancaria.Visible = True : Me.txtCuentaBancaria.Visible = True ': Me.lblDisplayCuentaBancaria.Location = New Point(4, 140)  : Me.txtCuentaBancaria.Location = New Point(88, 140)
                Me.lblCuentaBancaria.Visible = True ': Me.lblCuentaBancaria.Location = New Point(140, 142)
                Me.lblDisplayVendedor.Visible = True : Me.txtCodigoVendedor.Visible = True : Me.lblNombreVendedor.Visible = True
                Me.LblDisplayDocumento.Visible = True : Me.CboDocumentos.Visible = True
                Me.LblDisplayTipoMercado.Visible = False : Me.CboTipoMercado.Visible = False
                Me.LblDisplayPlaza.Visible = True : Me.cboPlaza.Visible = True
                Me.gpFiltroFecha.Visible = True
                Me.chkClientesSaldoVencido.Visible = False
                Me.lblTipoCambio.Visible = False : Me.txtTipoCambio.Visible = False
                Me.LblMoneda.Visible = False : Me.CboMoneda.Visible = False
            End If

        Catch ex As Exception
            HandleError(Me.Name, "OcultarControles", ex)
        End Try
    End Sub

#End Region

End Class