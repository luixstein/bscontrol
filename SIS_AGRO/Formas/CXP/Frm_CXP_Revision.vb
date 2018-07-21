Option Strict On

Imports CrystalDecisions.CrystalReports.Engine

Public Class Frm_CXP_Revision
    Private oDocumento As New Class_CatDocumentos
    Private oBancosCXP As New Class_Bancos_CXP
    Private oCompras As New Class_Compras_Global

    Dim _Fecha As String

#Region "Propiedades"
    Public ReadOnly Property Nombre_Modulo() As String
        Get
            Return "Revisión a Proveedores."
        End Get
    End Property
#End Region

    Private Estado As enumEstados

    Private Enum enumEstados
        NUEVO
        SINORDENCOMPRA
        CONORDENCOMPRA
        FLETEEMBARQUE
        PAGODIRECTO
        CONSULTA
    End Enum

#Region "Columnas grid compras"
    Private iGyFolioCO As Integer = 1
    Private iGyFolioOC As Integer = 2
    Private iGyEmbarque As Integer = 3
    Private iGyFecha As Integer = 4
    Private iGyFechaContraRecibo As Integer = 5
    Private iGyFechaProgamacion As Integer = 6
    Private iGyFacturaProveedor As Integer = 7
    Private iGyFechaProveedor As Integer = 8
    Private iGySaldo As Integer = 9
    Private iGySubtotal As Integer = 10
    Private iGyIVA As Integer = 11
    Private iGyRetencion As Integer = 12
    Private iGyTotal As Integer = 13
    Private iGyConcepto As Integer = 14
    Private iGyTipoPago As Integer = 15
    Private iGyContraRecibo As Integer = 16
    Private iGyPorcentaje As Integer = 17
#End Region

#Region "Columnas grid cuentas"
    Private iGyTipo As Integer = 1
    Private iGyCodigoCentroCosto As Integer = 2
    Private iGyNombreCentroCosto As Integer = 3
    Private iGyCodigoCategoria As Integer = 4
    Private iGyNombreCategoria As Integer = 5
    Private iGyCodigoConcepto As Integer = 6
    Private iGyNombreConcepto As Integer = 7
    Private iGyImporte As Integer = 8
    Private iGyCuentaContable As Integer = 9
#End Region

#Region "Columnas grid activos"
    Private iGyActivoCuentaContable As Integer = 1
    Private iGyActivoNombreCuenta As Integer = 2
    Private iGyActivoImporte As Integer = 3
#End Region

#Region "Columnas grid facturas relacionadas"
    Private iGyIdCentroCostosDetalleVentas As Integer = 1
    Private iGyCodigoCliente As Integer = 2
    Private iGyNombreCliente As Integer = 3
    Private iGyFolioVenta As Integer = 4
    Private iGyFechaVenta As Integer = 5
    Private iGyGasto As Integer = 6
#End Region

    Private sCodigoTipoDocumento As String = ""

#Region "Opciones"
    Private Sub tsbNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbNuevo.Click
        Me.Inicializa()
        Me.Cambia_Estado(enumEstados.NUEVO)
        Me.CboAlmacen.Focus()
        _Fecha = ""
        Me.TxtCodigoProveedor.Focus()
    End Sub

    Private Sub tsbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGrabar.Click
        If Me.GestionaGrabar() = True Then
            Me.CargaComprasConSaldo()
            Me.btnRegresar.PerformClick()
        End If
    End Sub

    Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click
        Dim Rpt As New ReportDocument
        Dim oReporte As Class_Reporte
        Try

            oReporte = New Class_Reporte("RPT_FORMATO_COMPRAS_NOTA_REVISION", Rpt, False)
            'MsgBox("Pendiente por realizar.", MsgBoxStyle.Exclamation, "Imprimir")
            'Exit Sub

            If Not oReporte.RptCargado Then
                Exit Sub
            End If

            If txtLEN(_Fecha) = False Then
                MsgBox("Favor de seleccionar algun contra-recibo con fecha de revisión.", MsgBoxStyle.Exclamation, "Imprimir")
                Exit Sub
            End If

            Rpt.SetParameterValue("@CODIGO_PROVEEDOR", Me.TxtCodigoProveedor.Text)
            Rpt.SetParameterValue("@FECHA_CONTRA_RECIBO", Me._Fecha)

            Dim frm As New Reporte(Rpt)
            frm.CRViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            frm.Show()
        Catch ex As Exception
            HandleError(Me.Name, "Imprimir", ex)
        Finally
            oReporte = Nothing
        End Try
    End Sub

    Private Sub tsbEditarCostos_Click(sender As Object, e As EventArgs) Handles tsbEditarCostos.Click
        Try
            Dim oCostos As New FrmCostosEdicion(Me.txtFolioCompra.Text, "CA" & Usuario.Codigo_Plaza)
            If oCostos.bMovimientoEncontrado = True Then
                oCostos.ShowDialog()
                oCostos.Dispose()
                Me.Consultar()
            End If
        Catch ex As Exception
            HandleError(Me.Name, "tsbEditarCostos_Click", ex)
        End Try
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub

    Private Sub btnRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegresar.Click
        If Me.Estado = enumEstados.CONORDENCOMPRA Or Me.Estado = enumEstados.FLETEEMBARQUE Then
            Me.gbCompras.Enabled = True
            Me.gbCompraProveedor.Enabled = False

            Me.txtFolioCompra.Text = ""
            Me.DtpFechaFacturaProveedor.Value = Date.Now

            If Now.DayOfWeek = DayOfWeek.Friday Then
                Me.dtpFechaVencimiento.Value = Now
            Else
                Dim fechaViernes As DateTime
                fechaViernes = DateAdd(DateInterval.Day, DayOfWeek.Friday - Weekday(Date.Now, FirstDayOfWeek.Monday), Date.Now)
                Me.dtpFechaVencimiento.Value = fechaViernes
            End If

            Me.txtEmbarque.Text = ""
            'Me.txtCuenta.Text = ""
            'Me.lblNombreCuenta.Text = ""
            Me.txtFolioProveedor.Text = ""
            Me.TxtConcepto.Text = ""
            Me.TxtSubTotal.Text = ""
            Me.TxtIVA.Text = ""
            Me.TxtRetencionIVA.Text = ""
            Me.txtPorciento.Text = ""
            Me.txtTotalCompra.Text = ""
        Else
            Me.gbCompras.Enabled = False
        End If
    End Sub

    Private Sub btnContinuar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContinuar.Click
        If txtLEN(Me.TxtCodigoProveedor.Text) = False Then
            MsgBox("Asigne un proveedor.", MsgBoxStyle.Exclamation, "Validación de Proveedores")
            Me.TxtCodigoProveedor.Focus()
            Exit Sub
        End If

        Dim oProveedor As New Class_CatProveedores(Me.TxtCodigoProveedor.Text)
        Me.LblProveedor.Text = oProveedor.Nombre_Proveedor
        Me.LblCuentaContableProveedor.Text = oProveedor.CUENTA_CONTABLE

        If enumEstados.PAGODIRECTO = CShort(Me.cboTipoGasto.SelectedValue.ToString) Then
            Me.Cambia_Estado(enumEstados.PAGODIRECTO)
        ElseIf enumEstados.CONORDENCOMPRA = CShort(Me.cboTipoGasto.SelectedValue.ToString) Then
            Me.Cambia_Estado(enumEstados.CONORDENCOMPRA)
        ElseIf enumEstados.FLETEEMBARQUE = CShort(Me.cboTipoGasto.SelectedValue.ToString) Then
            Me.Cambia_Estado(enumEstados.FLETEEMBARQUE)
        ElseIf enumEstados.SINORDENCOMPRA = CShort(Me.cboTipoGasto.SelectedValue.ToString) Then
            Me.Cambia_Estado(enumEstados.SINORDENCOMPRA)
        End If

        Me.CargaComprasConSaldo()
    End Sub

    Private Sub btnContinuarCompras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContinuarCompras.Click
        Dim Columna As Integer, Renglon As Integer ', vdg As String

        Columna = Me.GridCompras.Selection.FirstCol
        Renglon = Me.GridCompras.Selection.FirstRow

        Me.GridCompras.Cell(Renglon, Me.iGyTipoPago).SetFocus()

        'vdg = Me.Grid1.Cell(Renglon, Me.igyIdDia).Text
        If Me.GridCompras.Cell(Renglon, Me.iGyContraRecibo).Text = "0" And valorNumerico(Me.GridCompras.Cell(Renglon, Me.iGySaldo).Text) > 0 Then
            Me.txtFolioCompra.Text = Me.GridCompras.Cell(Renglon, Me.iGyFolioCO).Text()
            Me.txtEmbarque.Text = Me.GridCompras.Cell(Renglon, Me.iGyEmbarque).Text()
            Me.txtFolioProveedor.Text = Me.GridCompras.Cell(Renglon, Me.iGyFacturaProveedor).Text()
            If txtLEN(Me.GridCompras.Cell(Renglon, Me.iGyFechaProveedor).Text()) = True Then
                Me.DtpFechaFacturaProveedor.Value = CDate(Me.GridCompras.Cell(Renglon, Me.iGyFechaProveedor).Text())
            Else
                Me.DtpFechaFacturaProveedor.Value = Now
            End If
            Me.TxtConcepto.Text = Me.GridCompras.Cell(Renglon, Me.iGyConcepto).Text()
            Me.TxtSubTotal.Text = Me.GridCompras.Cell(Renglon, Me.iGySubtotal).Text()
            Me.TxtIVA.Text = Me.GridCompras.Cell(Renglon, Me.iGyIVA).Text()
            Me.txtPorciento.Text = Me.GridCompras.Cell(Renglon, Me.iGyPorcentaje).Text
            Me.TxtRetencionIVA.Text = Me.GridCompras.Cell(Renglon, Me.iGyRetencion).Text()
            Me.txtTotalCompra.Text = Me.GridCompras.Cell(Renglon, Me.iGyTotal).Text()

        Else
            'Me.gbCompraProveedor.Enabled = False
            Exit Sub
        End If

        If Estado = enumEstados.SINORDENCOMPRA Then
            'Me.txtCuenta.Focus()
        ElseIf Estado = enumEstados.CONORDENCOMPRA Or Estado = enumEstados.FLETEEMBARQUE Then
            Me.txtFolioProveedor.Focus()
            Me.gbCompras.Enabled = False
        End If
        Me.gbCompraProveedor.Enabled = True

    End Sub

    Private Sub btnImprimirPoliza_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimirPoliza.Click
        Dim Columna As Integer, Renglon As Integer, vdg As String
        Columna = Me.GridCompras.Selection.FirstCol
        Renglon = Me.GridCompras.Selection.FirstRow

        If Me.GridCompras.Selection.FirstRow <> Me.GridCompras.Selection.LastRow Then
            Exit Sub
        End If

        If Columna = iGyFolioCO Then
            vdg = Me.GridCompras.Cell(Renglon, Me.iGyFolioCO).Text
            If txtLEN(vdg) = False Then
                Exit Sub
            End If
            Me.Imprimir(vdg)
        End If
    End Sub

    Private Sub btnDocumentoAnterior_Click(sender As Object, e As EventArgs) Handles btnDocumentoAnterior.Click
        Me.Navegador("Anterior")
    End Sub

    Private Sub btnDocumentoSiguiente_Click(sender As Object, e As EventArgs) Handles btnDocumentoSiguiente.Click
        Me.Navegador("Siguiente")
    End Sub

    Private Sub btnActualizaConcepto_Click(sender As Object, e As EventArgs) Handles btnActualizaConcepto.Click
        Me.ActualizaConcepto()
    End Sub

    Private Sub btnGrabaDetalleVenta_Click(sender As Object, e As EventArgs) Handles btnGrabaDetalleVenta.Click
        If Me.GrabarVentasRelacionadas() = True Then
            MsgBox("Detalle de venta grabado correctamente.", MsgBoxStyle.Information, Me.Name)
            Me.Consultar()
        End If
    End Sub
#End Region

#Region "Eventos"
    Private Sub Frm_CXP_Revision_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If Me.Estado = enumEstados.NUEVO And Me.TxtCodigoProveedor.Enabled = True Then
            Me.TxtCodigoProveedor.Focus()
        End If
    End Sub

    Private Sub Frm_CXP_Revision_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.DesplegarAlmacenes()
        Me.DesplegarTipoGasto()
        Me.cboTipoGasto.Visible = False
        Me.Inicializa()
        Me.Cambia_Estado(enumEstados.NUEVO)
    End Sub

    Private Sub txtFolioCompra_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFolioCompra.KeyDown
        Select Case e.KeyCode
            Case Keys.F6
                '
            Case Keys.Enter
                Me.Consultar()
        End Select
    End Sub

    Private Sub TxtCodigoProveedor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodigoProveedor.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.F6
Buscar:
                    Dim Busqueda = New Busqueda_General("P.CODIGO_PROVEEDOR AS CODIGO,P.NOMBRE_PROVEEDOR AS NOMBRE", "Cat_Proveedores P INNER JOIN SIS_TIPOS_PROVEEDORES T ON(P.CODIGO_TIPO_PROVEEDOR=T.CODIGO_TIPO_PROVEEDOR)",
                                                        " 1=1 and P.Estatus='A' AND P.CODIGO_PLAZA=" & Usuario.Codigo_Plaza & "AND T.REALIZA_COMPRAS_GASTOS_PAGOS='1'", "Nombre", "Nombre_Proveedor")
                    Busqueda.ShowDialog()
                    Me.TxtCodigoProveedor.Text = "" & Busqueda.Tag.ToString
                    Busqueda.Dispose()

                Case Keys.Enter
                    If txtLEN(Me.TxtCodigoProveedor.Text) = False Then
                        Me.LblProveedor.Text = "" : Me.LblCuentaContableProveedor.Text = ""
                        Me.TxtCodigoProveedor.Focus()
                        GoTo Buscar
                        Exit Sub
                    End If
                    Dim sql As New Class_find("Select P.NOMBRE_PROVEEDOR,P.CUENTA_CONTABLE,P.CUENTA_CONTABLE_DOLARES From CAT_PROVEEDORES P INNER JOIN SIS_TIPOS_PROVEEDORES T ON(P.CODIGO_TIPO_PROVEEDOR=T.CODIGO_TIPO_PROVEEDOR) " &
                                              "Where P.CODIGO_PROVEEDOR='" & Me.TxtCodigoProveedor.Text & "' and P.Estatus='A' AND P.CODIGO_PLAZA=" & Usuario.Codigo_Plaza & " AND T.REALIZA_COMPRAS_GASTOS_PAGOS='1'")
                    If sql.Result1 = "" Then
                        MsgBox("El código de proveedor que intenta buscar no existe o esta dado de baja, favor de intentar con otro código.", MsgBoxStyle.Exclamation, "Validación de Proveedores")
                        Me.LblProveedor.Text = "" : Me.LblCuentaContableProveedor.Text = ""
                        GoTo Buscar : Exit Sub
                    Else
                        Me.LblProveedor.Text = sql.Result1
                        Me.LblCuentaContableProveedor.Text = sql.Result2

                        If txtLEN(sql.Result2) = False Then
                            MsgBox("El proveedor no tiene cuenta contable asignda, favor de asignarle una.", MsgBoxStyle.Exclamation, "Validación de Proveedores")
                            Exit Sub
                        End If

                        Me.CargaComprasConSaldo()
                        Me.cboTipoGasto.Focus()

                    End If
                    sql = Nothing

                Case Keys.F4
                    Dim Child As New Catalogo_Proveedores()
                    Child.tsbNuevo.PerformClick()
                    Child.ShowDialog()
                    Child.Dispose()
            End Select
        Catch ex As Exception
            HandleError(Me.Name, "TxtCodigoProveedor_KeyDown", ex)
        End Try
    End Sub

    Private Sub ckbSaldos_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ckbSaldos.CheckedChanged
        If txtLEN(Me.TxtCodigoProveedor.Text) = True Then
            Me.CargaComprasConSaldo()
        End If
    End Sub

    '    Private Sub txtCuenta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    '        Select Case e.KeyCode
    '            Case Keys.F6
    'BusquedaVisual:
    '                Dim oCuenta As New Class_CatCuentas
    '                Dim sCuenta As String = oCuenta.BusquedaVisual_PorCodigoFiltrandoTipoOperacion()
    '                If sCuenta.Length > 0 Then
    '                    'Me.txtCuenta.Text = sCuenta
    '                    sCuenta = Replace(sCuenta, "'", "''")
    '                    Dim sql As New Class_find("SELECT CUENTA_CONTABLE,NOMBRE_CUENTA FROM CON_CAT_CUENTAS WHERE CUENTA_CONTABLE='" & sCuenta & "'")
    '                    'Me.txtCuenta.Text = sCuenta
    '                    'Me.lblNombreCuenta.Text = sql.Result2
    '                    sql = Nothing
    '                    Me.txtFolioProveedor.Focus()
    '                Else
    '                    'Me.txtCuenta.Text = ""
    '                    'Me.lblNombreCuenta.Text = ""
    '                End If
    '            Case Keys.F7
    '                Dim oId As New Class_CatCuentas
    '                Dim sIdCodigo As String = oId.BusquedaVisual_PorNombreFiltrandoTipoOperacion()
    '                If sIdCodigo.Length > 0 Then
    '                    'Me.txtCuenta.Text = sIdCodigo
    '                    sIdCodigo = Replace(sIdCodigo, "'", "''")
    '                    Dim sql As New Class_find("SELECT CUENTA_CONTABLE,NOMBRE_CUENTA FROM CON_CAT_CUENTAS WHERE CUENTA_CONTABLE='" & sIdCodigo & "'")
    '                    'Me.txtCuenta.Text = sql.Result1
    '                    'Me.lblNombreCuenta.Text = sql.Result2
    '                    Me.txtFolioProveedor.Focus()
    '                    sql = Nothing
    '                Else
    '                    'Me.txtCuenta.Text = ""
    '                    'Me.lblNombreCuenta.Text = ""
    '                End If
    '            Case Keys.Return
    '                Dim sql As New Class_find("SELECT CUENTA_CONTABLE,NOMBRE_CUENTA FROM CON_CAT_CUENTAS WHERE CUENTA_CONTABLE='" & Me.txtCuenta.Text & "' AND ESMAYOR=0 ")
    '                If sql.Result1 = "" Then
    '                    'MsgBox("La cuenta contable que intenta buscar es de mayor, favor de intentar con otro codigo", MsgBoxStyle.Critical, "Validación de Cuentas Contables")
    '                    GoTo BusquedaVisual
    '                Else
    '                    'Me.lblNombreCuenta.Text = sql.Result2
    '                    'Me.tsbConsultar.PerformClick()
    '                    Me.txtFolioProveedor.Focus()
    '                End If
    '                sql = Nothing
    '        End Select
    '    End Sub

    Private Sub cboTipoGasto_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTipoGasto.SelectedValueChanged
        If txtLEN(Me.TxtCodigoProveedor.Text) = True Then
            Me.CargaComprasConSaldo()
        End If
    End Sub

    Private Sub cboTipoGasto_KeyDown(sender As Object, e As KeyEventArgs) Handles cboTipoGasto.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.btnContinuar.Focus()
        End If
    End Sub

    Private Sub GridCuentas_KeyDown(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridCuentas.KeyDown
        Me.GestionaGrid(e)

        'If e.KeyCode = Keys.Return Then
        '    Dim Renglon As Integer = GridCuentas.Selection.FirstRow
        '    Me.GridCuentas.Cell(Renglon, Me.iGyNombreConcepto).SetFocus()
        'End If
    End Sub

    Private Sub Grid1_Click(ByVal Sender As Object, ByVal e As System.EventArgs) Handles GridCompras.Click
        Dim Renglon As Integer, vdg As String

        Renglon = Me.GridCompras.Selection.FirstRow
        If txtLEN(Me.GridCompras.Cell(Renglon, Me.iGyFechaContraRecibo).Text) = True And Renglon > 0 Then
            vdg = Format(CDate(Me.GridCompras.Cell(Renglon, Me.iGyFechaContraRecibo).Text), "yyyy-dd-MM") 'Grid.Rows(Renglon).Cell("FOLIO_POLIZA")
            If txtLEN(vdg) = False Then
                Exit Sub
            Else
                Me._Fecha = vdg
            End If
        End If
    End Sub

    Private Sub Grid1_DoubleClick(ByVal Sender As Object, ByVal e As System.EventArgs) Handles GridCompras.DoubleClick
        Dim Columna As Integer, Renglon As Integer, vdg As String
        'Dim dTabla As DataTable

        Try
            Columna = Me.GridCompras.Selection.FirstCol
            Renglon = Me.GridCompras.Selection.FirstRow

            If Me.GridCompras.Selection.FirstRow <> Me.GridCompras.Selection.LastRow Then
                Exit Sub
            End If

            If Columna = iGyFolioCO Then
                vdg = Me.GridCompras.Cell(Renglon, Me.iGyFolioCO).Text
                If txtLEN(vdg) = False Then
                    Exit Sub
                End If

                Dim Child As New Compras_Movimientos()
                Child.StartPosition = FormStartPosition.CenterScreen
                Child.ConsultaExterior = True
                'Child.
                'Child.lstbElementos.SelectedValue = vdg.ToString
                'Child.tsbEditar.PerformClick()
                Child.txtFolioCompra.Text = vdg.ToString
                Child.ShowDialog()
                Child.Dispose()

                Me.CargaComprasConSaldo()
                Me.Totales()
            End If

        Catch ex As Exception
            HandleError(Me.Name, "Grid1_DoubleClick", ex)
        End Try
    End Sub

    Private Sub GridActivos_KeyDown(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridActivos.KeyDown
        Me.GestionaGridActivos(e)
    End Sub

    Private Sub txtTipoCambio_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTipoCambio.KeyDown
        If e.KeyCode = Keys.Return Then
            If valorNumerico(Me.txtTipoCambio.Text) < 0 Or valorNumerico(Me.txtTipoCambio.Text) > 20 Then
                MsgBox("Tipo de cambio incorrecto", MsgBoxStyle.Information, "Validación de tipo de cambio")
                Me.txtTipoCambio.Focus()
                Exit Sub
            Else
                Me.CalculaImporteDolares()
            End If

            Me.TxtSubTotal.Focus()
            'SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub ckbDolares_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckbDolares.CheckedChanged
        If Me.ckbDolares.Checked = True Then
            Me.txtTipoCambio.Enabled = True
            Me.lblDisplayTipoCambio.Enabled = True
            Me.txtTipoCambio.Focus()
        Else
            Me.txtTipoCambio.Enabled = False
            Me.txtTipoCambio.Text = ""
            Me.lblDisplayTipoCambio.Enabled = False
            Me.txtImporteDolares.Text = ""
        End If
    End Sub

    Private Sub TxtSubTotal_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtSubTotal.TextChanged
        Me.CalculaImporteDolares()
    End Sub

    Private Sub LblPoliza_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LblPoliza.LinkClicked
        Dim Child As New Frm_Contabilidad_Captura_Polizas()
        Child.FolioPolizaConsultaExterior = Me.LblPoliza.Text
        Child.ShowDialog()
        Child.Dispose()
    End Sub

    Private Sub GridFacturasRelacionadas_KeyDown(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridFacturasRelacionadas.KeyDown
        Me.GestionaGridFacturasRelacionadas(e)
    End Sub

#Region "Eventos Genericos"
    Private Sub txt_Enter(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim oTexBox As TextBox = CType(sender, TextBox)
        oTexBox.SelectAll()
    End Sub

    Private Sub txt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodigoProveedor.KeyDown, txtFolioProveedor.KeyDown, DtpFechaFacturaProveedor.KeyDown,
        TxtSubTotal.KeyDown, txtTotalCompra.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub ckbDolares_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ckbDolares.KeyDown
        If e.KeyCode = Keys.Return Then
            If Me.ckbDolares.Checked = True Then
                Me.txtTipoCambio.Focus()
            Else
                Me.TxtSubTotal.Focus()
            End If
        End If
    End Sub

    Private Sub TxtConcepto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtConcepto.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.dtpFechaVencimiento.Focus()
        End If
    End Sub

    Private Sub dtpFechaVencimiento_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpFechaVencimiento.KeyDown
        If e.KeyCode = Keys.Return Then
            'SendKeys.Send("{TAB}")
            Me.GridCuentas.Cell(1, Me.iGyNombreCentroCosto).SetFocus()
        End If
    End Sub

    Private Sub txtNumerosDecimalKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtRetencionIVA.KeyPress, TxtSubTotal.KeyPress, TxtIVA.KeyPress, txtTotalCompra.KeyPress, txtPorciento.KeyPress,
        txtTipoCambio.KeyPress, txtRetencionISR.KeyPress
        Dim txt As TextBox = CType(sender, TextBox)
        txtSoloNumerosDecimales(e, txt.Text)
        txtNoBeep(e)
    End Sub

    Private Sub txtTextoKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtConcepto.KeyPress, TxtCodigoProveedor.KeyPress, txtEmbarque.KeyPress, txtFolioProveedor.KeyPress,
        DtpFechaFacturaProveedor.KeyPress, dtpFechaVencimiento.KeyPress, ckbDolares.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub txtKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) ' Handles txtCuenta.KeyPress
        txtNoBeep(e)
        txtSoloNumerosEnteros(e)
    End Sub

    Private Sub TxtSubTotal_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtSubTotal.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If valorNumerico(Me.TxtSubTotal.Text) > 0 Then
                    Me.TxtSubTotal.Text = FormatImporteContable(CDbl(Me.TxtSubTotal.Text))
                    Me.txtTotalCompra.Text = FormatImporteContable(valorNumerico(Me.TxtSubTotal.Text) + valorNumerico(Me.TxtIVA.Text) - valorNumerico(Me.TxtRetencionIVA.Text))
                    Me.CalculaImporteDolares()
                End If
        End Select
    End Sub

    Private Sub TxtRetencionIVA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtRetencionIVA.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If valorNumerico(Me.TxtRetencionIVA.Text) > 0 Then
                    Me.TxtRetencionIVA.Text = FormatImporteContable(CDbl(Me.TxtRetencionIVA.Text))
                    'Me.txtTotalCompra.Text = FormatImporteContable(valorNumerico(Me.TxtSubTotal.Text) + valorNumerico(Me.TxtIVA.Text) - valorNumerico(Me.TxtRetencionIVA.Text))
                Else
                    Me.TxtRetencionIVA.Text = FormatImporteContable(0)
                    'Me.txtTotalCompra.Text = FormatImporteContable(valorNumerico(Me.TxtSubTotal.Text) + valorNumerico(Me.TxtIVA.Text) - valorNumerico(Me.TxtRetencionIVA.Text))
                End If
                'Me.CalculaImporteDolares()

                Me.TotalizaGridCentrosCostosyActivos()
                Me.txtRetencionISR.Focus()
        End Select
    End Sub

    Private Sub txtRetencionISR_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRetencionISR.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If valorNumerico(Me.txtRetencionISR.Text) > 0 Then
                    Me.txtRetencionISR.Text = FormatImporteContable(CDbl(Me.txtRetencionISR.Text))
                Else
                    Me.txtRetencionISR.Text = FormatImporteContable(0)
                End If

                Me.TotalizaGridCentrosCostosyActivos()
                Me.txtTotalCompra.Focus()
        End Select
    End Sub

    Private Sub TxtIVA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtIVA.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If valorNumerico(Me.TxtIVA.Text) > 0 Then
                    Me.TxtIVA.Text = FormatImporteContable(CDbl(Me.TxtIVA.Text))
                    Me.txtPorciento.Text = "16"
                    Me.txtTotalCompra.Text = FormatImporteContable(valorNumerico(Me.TxtSubTotal.Text) + valorNumerico(Me.TxtIVA.Text) - valorNumerico(Me.TxtRetencionIVA.Text))
                    Me.CalculaImporteDolares()
                    Me.txtPorciento.Focus()
                Else
                    Me.TxtIVA.Text = FormatImporteContable(0)
                    Me.txtTotalCompra.Text = FormatImporteContable(valorNumerico(Me.TxtSubTotal.Text) + valorNumerico(Me.TxtIVA.Text) - valorNumerico(Me.TxtRetencionIVA.Text))
                    Me.txtPorciento.Text = "0"
                    Me.CalculaImporteDolares()
                    Me.TxtRetencionIVA.Focus()
                End If
        End Select
    End Sub

    Private Sub txtPorciento_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPorciento.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If valorNumerico(Me.txtPorciento.Text) > 0 Then
                    Me.txtPorciento.Text = CDbl(Me.txtPorciento.Text).ToString
                    Me.txtTotalCompra.Text = FormatImporteContable(valorNumerico(Me.TxtSubTotal.Text) + valorNumerico(Me.TxtIVA.Text) - valorNumerico(Me.TxtRetencionIVA.Text))
                End If
                Me.TxtRetencionIVA.Focus()
        End Select
    End Sub

    Private Sub txtTotalCompra_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTotalCompra.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If valorNumerico(Me.txtTotalCompra.Text) > 0 Then
                    Me.txtTotalCompra.Text = FormatImporteContable(CDbl(Me.txtTotalCompra.Text))
                    Me.txtTotalCompra.Text = FormatImporteContable(valorNumerico(Me.TxtSubTotal.Text) + valorNumerico(Me.TxtIVA.Text) - valorNumerico(Me.TxtRetencionIVA.Text))
                End If
                Me.tsbGrabar.Select()
        End Select
    End Sub
#End Region

#End Region

#Region "Métodos y procedimientos"
    Private Sub DesplegarAlmacenes()
        Try
            Dim oAlmacenes As New Class_CatAlmacenes
            With Me.CboAlmacen
                .DisplayMember = "NOMBRE_ALMACEN"
                .ValueMember = "CODIGO_ALMACEN"
                Dim dView As New Data.DataView(oAlmacenes.ObtenerAlmacenes)
                dView.Sort = "NOMBRE_ALMACEN"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedValue = Plaza.CODIGO_ALMACEN_PRINCIPAL 'Usuario.Codigo_Almacen
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarAlmacenes", ex)
        End Try
    End Sub

    Private Sub DesplegarTipoGasto()
        Try
            Dim oGastos As New Class_Compras_Global
            With Me.cboTipoGasto
                .DisplayMember = "NOMBRE_TIPO_GASTO"
                .ValueMember = "CODIGO_TIPO_GASTO"
                Dim dView As New Data.DataView(oGastos.ObtenerTiposGastosParaRevision)
                dView.Sort = "NOMBRE_TIPO_GASTO"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedValue = 1 '1=SinOrdenCompra
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarTipoGasto", ex)
        End Try
    End Sub

    Private Sub Inicializa()
        Try
            Me.TxtCodigoProveedor.Text = ""
            Me.LblProveedor.Text = ""
            Me.LblCuentaContableProveedor.Text = ""
            Me.txtFolioCompra.Text = ""
            Me.LblPoliza.Text = ""
            Me.DtpFechaFacturaProveedor.Value = Date.Now

            If Now.DayOfWeek = DayOfWeek.Friday Then
                Me.dtpFechaVencimiento.Value = Now
            Else
                Dim fechaViernes As DateTime
                Dim DiaSemana = Weekday(Date.Now, FirstDayOfWeek.Monday)
                If (DiaSemana < DayOfWeek.Friday) Then
                    'fechaViernes = (Date.Now + (5 - DiaSemana))
                    fechaViernes = DateAdd(DateInterval.Day, (5 - DiaSemana), Date.Now)
                Else
                    fechaViernes = DateAdd(DateInterval.Day, (7 - (DiaSemana - 5)), Date.Now)
                End If

                'fechaViernes = DateAdd(DateInterval.Day, DayOfWeek.Friday + Weekday(Date.Now, FirstDayOfWeek.Monday), Date.Now)
                Me.dtpFechaVencimiento.Value = fechaViernes
            End If

            Me.txtEmbarque.Text = ""
            'Me.txtCuenta.Text = ""
            'Me.lblNombreCuenta.Text = ""
            Me.txtFolioProveedor.Text = ""
            Me.TxtConcepto.Text = ""
            Me.TxtSubTotal.Text = "0"
            Me.TxtIVA.Text = "0"
            Me.TxtRetencionIVA.Text = "0"
            Me.txtRetencionISR.Text = "0"
            Me.txtPorciento.Text = "0"
            Me.txtTotalCompra.Text = "0"
            Me.ckbSaldos.Checked = True
            Me.txtTotal.Text = ""
            Me.txtSaldo.Text = ""
            Me.ckbDolares.Checked = False
            Me.ckbDolares.Enabled = True
            Me.txtTipoCambio.Enabled = False
            Me.lblTotalFacturasRelacionadas.Text = "0"

            Me.InicializaGridCompras()
            Me.InicializaGridCuentas()
            Me.InicializaGridActivos()
            Me.InicializaGridFacturasRelacionadas()

            Me.oCompras = New Class_Compras_Global("CA" & Usuario.Codigo_Plaza)
            Me.txtFolioCompra.Text = Me.oCompras.GeneraFolio

        Catch ex As Exception
            HandleError(Me.Name, "Inicializa", ex)
        End Try
    End Sub

    Private Sub InicializaGridCompras()
        Try
            Me.GridCompras.DataSource = Nothing
            FG_Grid_Limpiar(Me.GridCompras)

            'Creamos el Grid
            Me.GridCompras.Rows = 2
            Me.GridCompras.Cols = 18
            Me.GridCompras.DisplayRowNumber = True

            Me.FormateaGridCompras()
        Catch ex As Exception
            HandleError(Me.Name, "InicializaGridCompras", ex)
        End Try
    End Sub

    Private Sub InicializaGridCuentas()
        Try
            Me.GridCuentas.DataSource = Nothing
            FG_Grid_Limpiar(Me.GridCuentas)

            'Creamos el Grid
            Me.GridCuentas.Rows = 2
            Me.GridCuentas.Cols = 10
            Me.GridCuentas.DisplayRowNumber = True

            Me.FormateaGridCuentas()
        Catch ex As Exception
            HandleError(Me.Name, "InicializaGridCuentas", ex)
        End Try
    End Sub

    Private Sub InicializaGridActivos()
        Try
            Me.GridActivos.DataSource = Nothing
            FG_Grid_Limpiar(Me.GridActivos)

            'Creamos el Grid
            Me.GridActivos.Rows = 2
            Me.GridActivos.Cols = 4
            Me.GridActivos.DisplayRowNumber = True

            Me.FormateaGridActivos()
        Catch ex As Exception
            HandleError(Me.Name, "InicializaGridActivos", ex)
        End Try
    End Sub

    Private Sub InicializaGridFacturasRelacionadas()
        Try
            Me.GridFacturasRelacionadas.DataSource = Nothing
            FG_Grid_Limpiar(Me.GridFacturasRelacionadas)
            Me.GridFacturasRelacionadas.Rows = 2
            Me.GridFacturasRelacionadas.Cols = 7
            Me.FormateaGridFacturasRelacionadas()
            Me.GridFacturasRelacionadas.Column(Me.iGyFolioVenta).Locked = True

        Catch ex As Exception
            HandleError(Me.Name, "InicializaGridFacturasRelacionadas", ex)
        End Try
    End Sub

    Private Sub FormateaGridCompras()
        Try
            Me.GridCompras.Column(Me.iGyFolioCO).Width = 70
            Me.GridCompras.Column(Me.iGyFolioOC).Width = 70
            Me.GridCompras.Column(Me.iGyEmbarque).Width = 70
            Me.GridCompras.Column(Me.iGyFecha).Width = 70
            Me.GridCompras.Column(Me.iGyFechaContraRecibo).Width = 100
            Me.GridCompras.Column(Me.iGyFechaProgamacion).Width = 70
            Me.GridCompras.Column(Me.iGyFacturaProveedor).Width = 70
            Me.GridCompras.Column(Me.iGyFechaProveedor).Width = 70
            Me.GridCompras.Column(Me.iGySubtotal).Width = 70
            Me.GridCompras.Column(Me.iGyIVA).Width = 70
            Me.GridCompras.Column(Me.iGyRetencion).Width = 70
            Me.GridCompras.Column(Me.iGyTotal).Width = 70
            Me.GridCompras.Column(Me.iGyConcepto).Width = 70
            Me.GridCompras.Column(Me.iGySaldo).Width = 70
            Me.GridCompras.Column(Me.iGyTipoPago).Width = 70
            Me.GridCompras.Column(Me.iGyContraRecibo).Width = 70

            Me.GridCompras.Cell(0, Me.iGyFolioCO).Text = "Folio(CO)"
            Me.GridCompras.Cell(0, Me.iGyFolioOC).Text = "Folio(OC)"
            Me.GridCompras.Cell(0, Me.iGyEmbarque).Text = "Embarque"
            Me.GridCompras.Cell(0, Me.iGyFecha).Text = "Fecha"
            Me.GridCompras.Cell(0, Me.iGyFechaContraRecibo).Text = "Fec.Contrarecibo"
            Me.GridCompras.Cell(0, Me.iGyFechaProgamacion).Text = "Fec.Prog."
            Me.GridCompras.Cell(0, Me.iGyFacturaProveedor).Text = "Fac. Prov. "
            Me.GridCompras.Cell(0, Me.iGyFechaProveedor).Text = "Fec.Prov."
            Me.GridCompras.Cell(0, Me.iGyTotal).Text = "Total"
            Me.GridCompras.Cell(0, Me.iGySaldo).Text = "Saldo"
            Me.GridCompras.Cell(0, Me.iGyTipoPago).Text = "TipoPago"
            Me.GridCompras.Cell(0, Me.iGyContraRecibo).Text = "ContraRecibo"

            Me.GridCompras.Column(Me.iGyFecha).CellType = FlexCell.CellTypeEnum.DateTime
            Me.GridCompras.Column(Me.iGyFecha).FormatString = "dd-MMM-yy"

            Me.GridCompras.Column(Me.iGyFechaContraRecibo).CellType = FlexCell.CellTypeEnum.DateTime
            Me.GridCompras.Column(Me.iGyFechaContraRecibo).FormatString = "dd-MMM-yy"

            Me.GridCompras.Column(Me.iGyFechaProgamacion).CellType = FlexCell.CellTypeEnum.DateTime
            Me.GridCompras.Column(Me.iGyFechaProgamacion).FormatString = "dd-MMM-yy"

            Me.GridCompras.Column(Me.iGyFechaProveedor).CellType = FlexCell.CellTypeEnum.DateTime
            Me.GridCompras.Column(Me.iGyFechaProveedor).FormatString = "dd-MMM-yy"


            Me.GridCompras.Column(Me.iGyTotal).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
            Me.GridCompras.Column(Me.iGyTotal).Mask = FlexCell.MaskEnum.Numeric
            Me.GridCompras.Column(Me.iGyTotal).DecimalLength = 2
            Me.GridCompras.Column(Me.iGyTotal).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.GridCompras.Column(Me.iGySaldo).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
            Me.GridCompras.Column(Me.iGySaldo).Mask = FlexCell.MaskEnum.Numeric
            Me.GridCompras.Column(Me.iGySaldo).DecimalLength = 2
            Me.GridCompras.Column(Me.iGySaldo).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.GridCompras.Refresh()

            Me.GridCompras.Column(Me.iGyFolioCO).Locked = True
            Me.GridCompras.Column(Me.iGyFolioOC).Locked = True
            Me.GridCompras.Column(Me.iGyEmbarque).Locked = True
            Me.GridCompras.Column(Me.iGyFecha).Locked = True
            Me.GridCompras.Column(Me.iGyFechaContraRecibo).Locked = True
            Me.GridCompras.Column(Me.iGyFechaProgamacion).Locked = True
            Me.GridCompras.Column(Me.iGyFacturaProveedor).Locked = True
            Me.GridCompras.Column(Me.iGyFechaProveedor).Locked = True
            Me.GridCompras.Column(Me.iGyTotal).Locked = True
            Me.GridCompras.Column(Me.iGySaldo).Locked = True
            Me.GridCompras.Column(Me.iGyTipoPago).Locked = True
            Me.GridCompras.Column(Me.iGyContraRecibo).Locked = True

            Me.GridCompras.Column(Me.iGyTipoPago).Visible = False
            Me.GridCompras.Column(Me.iGyContraRecibo).Visible = False
            Me.GridCompras.Column(Me.iGySubtotal).Visible = False
            Me.GridCompras.Column(Me.iGyIVA).Visible = False
            Me.GridCompras.Column(Me.iGyRetencion).Visible = False
            Me.GridCompras.Column(Me.iGyConcepto).Visible = False
            Me.GridCompras.Column(Me.iGyPorcentaje).Visible = False

        Catch ex As Exception
            HandleError(Me.Name, "FormateaGridCompras", ex)
        End Try
    End Sub

    Private Sub FormateaGridCuentas()
        Try
            Me.GridCuentas.Column(Me.iGyTipo).Visible = False
            Me.GridCuentas.Column(Me.iGyCodigoCentroCosto).Visible = False
            Me.GridCuentas.Column(Me.iGyNombreCentroCosto).Width = 220
            Me.GridCuentas.Column(Me.iGyCodigoCategoria).Visible = False
            Me.GridCuentas.Column(Me.iGyNombreCategoria).Width = 220
            Me.GridCuentas.Column(Me.iGyCodigoConcepto).Visible = False
            Me.GridCuentas.Column(Me.iGyNombreConcepto).Width = 220
            Me.GridCuentas.Column(Me.iGyImporte).Width = 100
            Me.GridCuentas.Column(Me.iGyCuentaContable).Width = 100

            Me.GridCuentas.Cell(0, Me.iGyCodigoCentroCosto).Text = "CCos"
            Me.GridCuentas.Cell(0, Me.iGyNombreCentroCosto).Text = "C.costo"
            Me.GridCuentas.Cell(0, Me.iGyCodigoCategoria).Text = "CCat"
            Me.GridCuentas.Cell(0, Me.iGyNombreCategoria).Text = "Categoria"
            Me.GridCuentas.Cell(0, Me.iGyCodigoConcepto).Text = "CCon"
            Me.GridCuentas.Cell(0, Me.iGyNombreConcepto).Text = "Concepto"
            Me.GridCuentas.Cell(0, Me.iGyImporte).Text = "Importe(MXP)"
            Me.GridCuentas.Cell(0, Me.iGyCuentaContable).Text = "Cuenta contable"

            Me.GridCuentas.Column(Me.iGyImporte).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
            Me.GridCuentas.Column(Me.iGyImporte).Mask = FlexCell.MaskEnum.Numeric
            Me.GridCuentas.Column(Me.iGyImporte).DecimalLength = 2
            Me.GridCuentas.Column(Me.iGyImporte).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.GridCuentas.Column(Me.iGyImporte).Locked = False 'Se habilita el importe
            Me.GridCuentas.Column(Me.iGyCuentaContable).Locked = True 'Se bloquea la cuenta

        Catch ex As Exception
            HandleError(Me.Name, "FormateaGridCuentas", ex)
        End Try
    End Sub

    Private Sub FormateaGridActivos()
        Try
            With Me.GridActivos
                .Column(Me.iGyActivoCuentaContable).Width = 100
                .Column(Me.iGyActivoNombreCuenta).Width = 600
                .Column(Me.iGyActivoImporte).Width = 100

                .Cell(0, Me.iGyActivoCuentaContable).Text = "Cuenta contable"
                .Cell(0, Me.iGyActivoNombreCuenta).Text = "Nombre cuenta"
                .Cell(0, Me.iGyActivoImporte).Text = "Importe(MXP)"

                .Column(Me.iGyActivoImporte).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
                .Column(Me.iGyActivoImporte).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyActivoImporte).DecimalLength = 2
                .Column(Me.iGyActivoImporte).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGyActivoImporte).Locked = False 'Se habilita 
                .Column(Me.iGyActivoNombreCuenta).Locked = True 'Se bloquea 
            End With
        Catch ex As Exception
            HandleError(Me.Name, "FormateaGridActivos", ex)
        End Try
    End Sub

    Private Sub FormateaGridFacturasRelacionadas()
        Try
            With Me.GridFacturasRelacionadas
                .Column(Me.iGyCodigoCliente).Width = 100
                .Column(Me.iGyNombreCliente).Width = 300
                .Column(Me.iGyFolioVenta).Width = 100
                .Column(Me.iGyFechaVenta).Width = 100
                .Column(Me.iGyGasto).Width = 100

                .Cell(0, Me.iGyCodigoCliente).Text = "Código cliente"
                .Cell(0, Me.iGyNombreCliente).Text = "Nombre cliente"
                .Cell(0, Me.iGyFolioVenta).Text = "Folio venta"
                .Cell(0, Me.iGyFechaVenta).Text = "Fecha venta"
                .Cell(0, Me.iGyGasto).Text = "Gasto"

                .Column(Me.iGyGasto).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
                .Column(Me.iGyGasto).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyGasto).DecimalLength = 4
                .Column(Me.iGyGasto).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGyFechaVenta).CellType = FlexCell.CellTypeEnum.DateTime
                .Column(Me.iGyFechaVenta).FormatString = "dd-MMM-yy"

                .Column(Me.iGyNombreCliente).Locked = True
                .Column(Me.iGyFechaVenta).Locked = True
                .Column(Me.iGyIdCentroCostosDetalleVentas).Visible = False

            End With
        Catch ex As Exception
            HandleError(Me.Name, "FormateaGridFacturasRelacionadas", ex)
        End Try
    End Sub

    Private Sub Cambia_Estado(ByVal pEstado As enumEstados)
        Try
            Me.Estado = pEstado

            Select Case Me.Estado
                Case enumEstados.NUEVO
                    Me.tsbGrabar.Enabled = False

                    Me.gbProveedor.Enabled = True
                    Me.txtFolioCompra.Enabled = True

                    Me.gbCompraProveedor.Enabled = False
                    Me.gbCompras.Enabled = False
                    'Me.txtCuenta.Enabled = False
                    Me.GridCuentas.Enabled = False
                    Me.GridActivos.Enabled = False
                    Me.LblMsn.Visible = False
                    Me.btnContinuarCompras.Enabled = False
                    Me.btnImprimirPoliza.Visible = False
                    Me.tsbEditarCostos.Enabled = False
                    Me.btnActualizaConcepto.Visible = False
                    Me.btnGrabaDetalleVenta.Enabled = False
                    Me.TxtCodigoProveedor.Enabled = True
                    Me.lblEstatus.Text = "NUEVO"

                    Me.tsslElaboro.Visible = False : Me.tsslElaboro.Text = ""
                    Me.tsslCancelo.Visible = False : Me.tsslCancelo.Text = ""

                Case enumEstados.CONSULTA
                    Me.tsbGrabar.Enabled = False

                    Me.gbProveedor.Enabled = True
                    Me.txtFolioCompra.Enabled = False
                    Me.TxtCodigoProveedor.Enabled = False
                    Me.cboTipoGasto.Enabled = False

                    Me.gbCompraProveedor.Enabled = False
                    Me.gbCompras.Enabled = False
                    'Me.txtCuenta.Enabled = False
                    Me.GridCuentas.Enabled = False
                    Me.GridActivos.Enabled = False
                    Me.LblMsn.Visible = False
                    Me.btnContinuarCompras.Enabled = False
                    Me.btnImprimirPoliza.Visible = False
                    Me.tsbEditarCostos.Enabled = False
                    Me.btnActualizaConcepto.Visible = False
                    Me.btnGrabaDetalleVenta.Enabled = True

                    Me.tsslElaboro.Visible = True : Me.tsslElaboro.Text = "Elaboró : " + Me.oCompras.NOMBRE_USUARIO_GRABO.ToString + " el " + Format(Me.DtpFechaFacturaProveedor.Value, "dd/MMM/yy").ToUpper

                    If Me.oCompras.ESTATUS = "C" Then
                        Me.tsslCancelo.Visible = True : Me.tsslCancelo.Text = "Canceló : " + Me.oCompras.NOMBRE_USUARIO_CANCELO.ToString + " el " + Format(Me.oCompras.FECHA_CANCELACION, "dd/MMM/yy").ToUpper
                    Else
                        Me.tsslCancelo.Visible = False : Me.tsslCancelo.Text = ""
                    End If

                Case enumEstados.PAGODIRECTO
                    Me.tsbGrabar.Enabled = False

                    Me.gbProveedor.Enabled = True
                    Me.gbCompraProveedor.Enabled = False
                    Me.gbCompras.Enabled = True
                    'Me.txtCuenta.Enabled = False
                    Me.GridCuentas.Enabled = False
                    Me.GridActivos.Enabled = False
                    Me.LblMsn.Visible = False
                    Me.btnContinuarCompras.Enabled = False
                    Me.btnRegresar.Enabled = False
                    Me.btnImprimirPoliza.Visible = False
                    Me.btnActualizaConcepto.Visible = False

                Case enumEstados.CONORDENCOMPRA
                    Me.tsbGrabar.Enabled = True

                    Me.gbProveedor.Enabled = False
                    Me.gbCompraProveedor.Enabled = False
                    Me.gbCompras.Enabled = True
                    Me.txtFolioCompra.Enabled = False
                    Me.txtFolioProveedor.Enabled = True
                    Me.txtEmbarque.Enabled = False
                    'Me.txtCuenta.Enabled = False
                    Me.GridCuentas.Enabled = False
                    Me.GridActivos.Enabled = False
                    Me.LblMsn.Visible = True

                    Me.TxtConcepto.Enabled = False
                    Me.TxtSubTotal.Enabled = False
                    Me.TxtIVA.Enabled = False
                    Me.TxtRetencionIVA.Enabled = False
                    Me.txtRetencionISR.Enabled = False
                    Me.txtPorciento.Enabled = False
                    Me.txtTotalCompra.Enabled = False
                    Me.btnContinuarCompras.Enabled = True
                    Me.btnRegresar.Enabled = True
                    Me.btnImprimirPoliza.Visible = False
                    Me.btnActualizaConcepto.Visible = False

                Case enumEstados.FLETEEMBARQUE
                    Me.tsbGrabar.Enabled = True
                    Me.gbProveedor.Enabled = False
                    Me.gbCompraProveedor.Enabled = False
                    Me.gbCompras.Enabled = True
                    Me.txtFolioCompra.Enabled = False
                    Me.txtFolioProveedor.Enabled = True
                    Me.txtEmbarque.Enabled = False
                    'Me.txtCuenta.Enabled = False

                    Me.LblMsn.Visible = True
                    Me.DtpFechaFacturaProveedor.Enabled = True
                    Me.dtpFechaVencimiento.Enabled = True
                    Me.GridCuentas.Enabled = False
                    Me.GridActivos.Enabled = False

                    Me.TxtConcepto.Enabled = False
                    Me.TxtSubTotal.Enabled = False
                    Me.TxtIVA.Enabled = False
                    Me.TxtRetencionIVA.Enabled = False
                    Me.txtRetencionISR.Enabled = False
                    Me.txtPorciento.Enabled = False
                    Me.txtTotalCompra.Enabled = False
                    Me.btnContinuarCompras.Enabled = True
                    Me.btnRegresar.Enabled = True
                    Me.btnImprimirPoliza.Visible = False
                    Me.btnActualizaConcepto.Visible = False

                Case enumEstados.SINORDENCOMPRA
                    If Me.oCompras.Existe = True Then
                        Me.tsbGrabar.Enabled = False
                    Else
                        Me.tsbGrabar.Enabled = True
                    End If

                    Me.gbProveedor.Enabled = True 'False
                    Me.gbCompraProveedor.Enabled = True
                    Me.gbCompras.Enabled = True
                    Me.txtFolioCompra.Enabled = False
                    Me.txtFolioProveedor.Enabled = True
                    Me.txtEmbarque.Enabled = False
                    Me.txtFolioProveedor.Focus()
                    Me.GridCuentas.Enabled = True
                    Me.GridActivos.Enabled = True

                    'Me.txtCuenta.Enabled = True
                    Me.TxtConcepto.Enabled = True
                    Me.TxtSubTotal.Enabled = True
                    Me.TxtIVA.Enabled = True
                    Me.TxtRetencionIVA.Enabled = True
                    Me.txtRetencionISR.Enabled = True
                    Me.txtPorciento.Enabled = True
                    Me.txtTotalCompra.Enabled = True
                    Me.LblMsn.Visible = False
                    Me.btnContinuarCompras.Enabled = False
                    Me.btnRegresar.Enabled = False
                    'Me.txtCuenta.Focus()
                    Me.gbCompras.Enabled = True
                    Me.btnImprimirPoliza.Visible = True
                    Me.btnActualizaConcepto.Visible = True

            End Select
        Catch ex As Exception
            HandleError(Me.Name, "Cambia_Estado", ex)
        End Try
    End Sub

    Private Function CargaComprasConSaldo() As Boolean
        Dim bResultado As Boolean = False
        Dim dTabla As DataTable
        Try
            dTabla = oCompras.CargaComprashechasProveedor(Me.TxtCodigoProveedor.Text, CInt(Me.cboTipoGasto.SelectedValue.ToString), Me.CboAlmacen.SelectedValue.ToString, Me.ckbSaldos.Checked)

            Me.GridCompras.AutoRedraw = False

            Me.GridCompras.Rows = 1
            'For Each dRow As DataRow In dTabla.Rows
            '    Me.Grid1.AddItem(dRow(0).ToString & Chr(9) & dRow(1).ToString & Chr(9) & dRow(2).ToString & Chr(9) & dRow(3).ToString & Chr(9) & dRow(4).ToString & Chr(9) & _
            '                     dRow(5).ToString & Chr(9) & dRow(6).ToString & Chr(9) & dRow(7).ToString & Chr(9) & dRow(8).ToString & Chr(9) & dRow(9).ToString & Chr(9) & dRow(10).ToString & Chr(9) & _
            '                     dRow(11).ToString & Chr(9) & dRow(12).ToString & Chr(9) & dRow(13).ToString & Chr(9) & dRow(14).ToString & Chr(9) & dRow(15).ToString & Chr(9) & dRow(16).ToString)
            'Next

            dTabla.DefaultView.AllowDelete = False
            dTabla.DefaultView.AllowNew = False

            Me.GridCompras.DataSource = dTabla
            'Me.Grid1.Rows += 1

            If dTabla.Rows.Count = 0 Then
                'MsgBox("El proveedor no tiene compras con saldo.", MsgBoxStyle.Information, Me.Text)
            Else
                If Me.ckbSaldos.Checked = True Then
                    Me.GridCompras.Cell(dTabla.Rows.Count, iGyFolioCO).SetFocus()
                Else
                    Dim i As Integer = 1
                    For i = 1 To Me.GridCompras.Rows - 1
                        If valorNumerico(Me.GridCompras.Cell(i, Me.iGySaldo).Text) = 0 Then
                            Me.GridCompras.Cell(i, iGyFolioCO).SetFocus()
                        End If
                    Next i
                End If
            End If

            bResultado = True

            Me.FormateaGridCompras()
            Me.Totales()

            Me.GridCompras.AutoRedraw = True
            Me.GridCompras.Refresh()

        Catch ex As Exception
            HandleError(Me.Name, "CargaComprasConSaldo", ex)
        End Try

        Return bResultado
    End Function

    Private Sub Totales()
        Me.txtSaldo.Text = FormatImporteContable(FG_Grid_SumaCol(Me.GridCompras, CShort(Me.iGySaldo)))
        Me.txtTotal.Text = FormatImporteContable(FG_Grid_SumaCol(Me.GridCompras, CShort(Me.iGyTotal)))
    End Sub

    Private Sub InicializaRenglonGridCuentas(ByVal iRenglon As Integer)
        Try
            For i As Integer = 1 To Me.GridCuentas.Cols - 1
                Me.GridCuentas.Cell(iRenglon, i).Text = ""
            Next
        Catch ex As Exception
            HandleError(Me.Name, "InicializaRenglonGridCuentas", ex)
        End Try
    End Sub

    Private Sub InicializaRenglonGridActivos(ByVal iRenglon As Integer)
        Try
            For i As Integer = 1 To Me.GridActivos.Cols - 1
                Me.GridActivos.Cell(iRenglon, i).Text = ""
            Next
        Catch ex As Exception
            HandleError(Me.Name, "InicializaRenglonGridActivos", ex)
        End Try
    End Sub

    Private Sub GestionaGrid(ByVal e As System.Windows.Forms.KeyEventArgs)

        Dim Columna As Integer, Renglon As Integer
        Dim StrCod As String = "" ', oCuenta As Class_CatCuentas
        Dim oCentroCosto As Class_CatCentroCostos 'Class_VwCatCentrosCostosyDeudoresDiversos
        Dim oCategoria As Class_CatCategorias, oConcepto As Class_CatConceptos
        Dim sCodigo As String = "", sTipo As String = ""

        Try
            Columna = Me.GridCuentas.Selection.FirstCol
            Renglon = Me.GridCuentas.Selection.FirstRow

            If Me.GridCuentas.Column(Columna).Locked = True Then
                Return
            End If

            Select Case e.KeyCode
                Case Keys.Tab
                    Me.ckbDolares.Focus()

                Case Keys.Return

                    Select Case Columna
                        'Case Me.iGyCuentaContable
                        '    StrCod = GridCuentas.Cell(Renglon, Me.iGyCuentaContable).Text
                        '    If txtLEN(StrCod) = False Then
                        '        GoTo busca_cuenta_contable
                        '        Return
                        '    End If
                        '    oCuenta = New Class_CatCuentas(StrCod)
                        '    If oCuenta._Existe = False Then
                        '        MsgBox("La cuenta contable que intenta buscar no existe, favor de intentar con otro código.", MsgBoxStyle.Critical, "Validación de Cuentas Contables")
                        '        Me.InicializaRenglonGridCuentas(Renglon)
                        '        Return
                        '    Else
                        '        If Renglon = 1 Then
                        '            '  Me.GridCuentas.Cell(Renglon, Me.iGyConcepto).Text = Me.TxtConcepto1.Text
                        '        Else
                        '            ' Me.GridCuentas.Cell(Renglon, Me.iGyConcepto).Text = Me.GridCuentas.Cell(1, Me.iGyConcepto).Text
                        '        End If
                        '        Me.GridCuentas.Cell(Renglon, Me.iGyNombreCuenta).Text = oCuenta.NOMBRE_CUENTA_NIVELES_COMPLETOS

                        '    End If
                        '    oCuenta = Nothing

                        Case Me.iGyNombreCentroCosto
                            If txtLEN(Me.GridCuentas.Cell(Renglon, Columna).Text) = False Then
                                GoTo busca_centro_costo
                                Return
                            End If

                            ''oCentroCosto = New Class_CatCentroCostos(CInt(Me.GridCuentas.Cell(Renglon, Me.iGyCodigoCentroCosto).Text))
                            sTipo = Me.GridCuentas.Cell(Renglon, Me.iGyTipo).Text
                            sCodigo = Me.GridCuentas.Cell(Renglon, Me.iGyCodigoCentroCosto).Text
                            If Me.EstableceCentroCosto(Renglon, Columna, e.KeyCode, sTipo, sCodigo) = False Then
                                GoTo busca_centro_costo
                                Return
                            End If

                            ''oCentroCosto = New Class_CatCentroCostos(CInt(Me.GridCuentas.Cell(Renglon, Me.iGyCodigoCentroCosto).Text))
                            'sTipo = Me.GridCuentas.Cell(Renglon, Me.iGyTipo).Text
                            'oCentroCosto = New Class_VwCatCentrosCostosyDeudoresDiversos(sTipo, Me.GridCuentas.Cell(Renglon, Me.iGyCodigoCentroCosto).Text)
                            'If oCentroCosto.EXISTE = True Then
                            '    Me.GridCuentas.Cell(Renglon, Me.iGyTipo).Text = oCentroCosto.TIPO
                            '    Me.GridCuentas.Cell(Renglon, Me.iGyCodigoCentroCosto).Text = oCentroCosto.CODIGO  'oCentroCosto.CODIGO_CENTRO_COSTO.ToString
                            '    Me.GridCuentas.Cell(Renglon, Me.iGyNombreCentroCosto).Text = oCentroCosto.NOMBRE  'oCentroCosto.NOMBRE_CENTRO_COSTO

                            '    Select Case sTipo
                            '        Case "DEUDOR_DIVERSO"
                            '            Me.GridCuentas.Cell(Renglon, Me.iGyCodigoCategoria).Text = ""
                            '            Me.GridCuentas.Cell(Renglon, Me.iGyNombreCategoria).Text = "NO APLICA"
                            '            Me.GridCuentas.Cell(Renglon, Me.iGyCodigoConcepto).Text = ""
                            '            Me.GridCuentas.Cell(Renglon, Me.iGyNombreConcepto).Text = "NO APLICA"
                            '            Me.GridCuentas.Cell(Renglon, Me.iGyCuentaContable).Text = oCentroCosto.CUENTA_CONTABLE
                            '            'e.SuppressKeyPress = True
                            '            'e.Handled = True
                            '            'e.SuppressKeyPress = True
                            '            'Me.GridCuentas.Cell(Renglon, Me.iGyImporte).SetFocus()
                            '            'e.Handled = False
                            '            'Me.GridCuentas.Refresh()

                            '            'Me.GridCuentas.Cell(1, 1).SetFocus()
                            '    End Select

                            'Else
                            '    Me.GridCuentas.Cell(Renglon, Me.iGyTipo).Text = ""
                            '    Me.GridCuentas.Cell(Renglon, Me.iGyCodigoCentroCosto).Text = ""
                            '    Me.GridCuentas.Cell(Renglon, Me.iGyNombreCentroCosto).Text = ""
                            '    GoTo busca_centro_costo
                            '    Return
                            'End If

                        Case Me.iGyNombreCategoria
                            If txtLEN(Me.GridCuentas.Cell(Renglon, Columna).Text) = False Then
                                GoTo busca_categoria
                                Return
                            End If

                            oCategoria = New Class_CatCategorias(Me.GridCuentas.Cell(Renglon, Me.iGyCodigoCategoria).Text)
                            If oCategoria.Existe = True Then
                                Me.GridCuentas.Cell(Renglon, Me.iGyCodigoCategoria).Text = oCategoria.CODIGO_CATEGORIA
                                Me.GridCuentas.Cell(Renglon, Me.iGyNombreCategoria).Text = oCategoria.NOMBRE_CATEGORIA
                                Me.GridCuentas.Cell(Renglon, Me.iGyCuentaContable).Text = oCategoria.CODIGO_TIPO_CATEGORIA
                            Else
                                Me.GridCuentas.Cell(Renglon, Me.iGyCodigoCategoria).Text = ""
                                Me.GridCuentas.Cell(Renglon, Me.iGyNombreCategoria).Text = ""
                                Me.GridCuentas.Cell(Renglon, Me.iGyCuentaContable).Text = ""
                                GoTo busca_categoria
                                Return
                            End If

                        Case Me.iGyNombreConcepto
                            If txtLEN(Me.GridCuentas.Cell(Renglon, Columna).Text) = False Then
                                GoTo busca_concepto
                                Return
                            End If

                            oConcepto = New Class_CatConceptos(Me.GridCuentas.Cell(Renglon, Me.iGyCodigoConcepto).Text)
                            If oConcepto.Existe = True Then
                                Me.GridCuentas.Cell(Renglon, Me.iGyCodigoConcepto).Text = oConcepto.Codigo_Concepto
                                Me.GridCuentas.Cell(Renglon, Me.iGyNombreConcepto).Text = oConcepto.Nombre_Concepto
                            Else
                                Me.GridCuentas.Cell(Renglon, Me.iGyCodigoConcepto).Text = ""
                                Me.GridCuentas.Cell(Renglon, Me.iGyNombreConcepto).Text = ""
                                GoTo busca_concepto
                                Return
                            End If

                        Case Me.iGyImporte
                            If valorNumerico(Me.GridCuentas.Cell(Renglon, Me.iGyImporte).Text) = 0 Then
                                e.Handled = True 'Con esto el importe si es 0 no se brinca a la siguiente columna, se queda el foco en el importe.
                                Return
                            End If
                            Me.SaltoColumnas(Renglon, Columna, Keys.KeyCode, sTipo)
                    End Select

salto_columna:
                    'If Me.GridCuentas.Rows = Renglon + 1 And Me.GridCuentas.Cell(Renglon, Me.iGyImporte).Locked = False Then
                    '    Me.GridCuentas.Rows = Me.GridCuentas.Rows + 1
                    'End If

                    'Select Case Columna
                    '    Case Me.iGyImporte
                    '        Me.GridCuentas.Cell(Renglon + 1, Me.iGyCodigoCentroCosto).SetFocus()
                    '    Case Else
                    '        Select Case sTipo
                    '            Case "DEUDOR_DIVERSO"
                    '                Me.GridCuentas.Cell(Renglon, Me.iGyNombreConcepto).SetFocus()
                    '            Case Else
                    '                Me.GridCuentas.Cell(Renglon, Columna).SetFocus()
                    '        End Select
                    'End Select

                Case Keys.F6
                    Select Case Columna
                        '                        Case Me.iGyCuentaContable
                        'busca_cuenta_contable:
                        '                            oCuenta = New Class_CatCuentas()
                        '                            Dim sCuenta As String = oCuenta.BusquedaVisual_PorCodigoFiltrandoTipoOperacion()
                        '                            If txtLEN(sCuenta) = True Then
                        '                                oCuenta = New Class_CatCuentas(sCuenta)
                        '                                Me.GridCuentas.Cell(Renglon, Me.iGyCuentaContable).Text = oCuenta.CUENTA_CONTABLE
                        '                                Me.GridCuentas.Cell(Renglon, Me.iGyNombreCuenta).Text = oCuenta.NOMBRE_CUENTA_NIVELES_COMPLETOS
                        '                                If Renglon = 1 Then
                        '                                    ' Me.GridCuentas.Cell(Renglon, Me.iGyConcepto).Text = Me.TxtConcepto1.Text
                        '                                Else
                        '                                    '  Me.GridCuentas.Cell(Renglon, Me.iGyConcepto).Text = Me.GridCuentas.Cell(1, Me.iGyConcepto).Text
                        '                                End If
                        '                            End If
                        '                            oCuenta = Nothing

                        Case Me.iGyNombreCentroCosto
busca_centro_costo:
                            'oCentroCosto = New Class_CatCentroCostos
                            'sCodigo = oCentroCosto.BusquedaVisual_PorDescripcion

                            'If txtLEN(sCodigo) = True Then
                            '    oCentroCosto = New Class_CatCentroCostos(CInt(sCodigo))
                            '    Me.GridCuentas.Cell(Renglon, Me.iGyCodigoCentroCosto).Text = oCentroCosto.CODIGO_CENTRO_COSTO.ToString
                            '    Me.GridCuentas.Cell(Renglon, Me.iGyNombreCentroCosto).Text = oCentroCosto.NOMBRE_CENTRO_COSTO
                            '    'Else
                            '    '    GoTo busca_centro_costo
                            '    '    Return
                            'End If



                            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''ESTA ERA LA FORMA DE USAR CC Y DEUDORES JUNTOS
                            'oCentroCosto = New Class_VwCatCentrosCostosyDeudoresDiversos
                            'sCodigo = oCentroCosto.BusquedaVisual_PorDescripcion 'Vienen dos campos contatenados, falta separarlos
                            'If txtLEN(sCodigo) = True Then
                            '    sTipo = Split(sCodigo, "|")(0)
                            '    sCodigo = Split(sCodigo, "|")(1)
                            '    Me.EstableceCentroCosto(Renglon, Columna, e.KeyCode, sTipo, sCodigo)
                            'End If
                            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''ESTA ERA LA FORMA DE USAR CC Y DEUDORES JUNTOS

                            'Otra ves ahora es solo centro de costos
                            oCentroCosto = New Class_CatCentroCostos
                            sCodigo = oCentroCosto.BusquedaVisual_PorDescripcion
                            If txtLEN(sCodigo) = True Then
                                Me.EstableceCentroCosto(Renglon, Columna, e.KeyCode, "CENTRO_COSTO", sCodigo)
                            End If

                        Case Me.iGyNombreCategoria
busca_categoria:
                            oCategoria = New Class_CatCategorias
                            sCodigo = oCategoria.BusquedaVisual_PorDescripcion

                            If txtLEN(sCodigo) = True Then
                                oCategoria = New Class_CatCategorias(sCodigo)
                                Me.GridCuentas.Cell(Renglon, Me.iGyCodigoCategoria).Text = oCategoria.CODIGO_CATEGORIA.ToString
                                Me.GridCuentas.Cell(Renglon, Me.iGyNombreCategoria).Text = oCategoria.NOMBRE_CATEGORIA
                                Me.GridCuentas.Cell(Renglon, Me.iGyCuentaContable).Text = oCategoria.CODIGO_TIPO_CATEGORIA
                                'Else
                                '    GoTo busca_categoria
                                '    Return
                            End If

                        Case Me.iGyNombreConcepto
busca_concepto:
                            oConcepto = New Class_CatConceptos
                            sCodigo = oConcepto.BusquedaVisual_PorDescripcion

                            If txtLEN(sCodigo) = True Then
                                oConcepto = New Class_CatConceptos(sCodigo)
                                Me.GridCuentas.Cell(Renglon, Me.iGyCodigoConcepto).Text = oConcepto.Codigo_Concepto.ToString
                                Me.GridCuentas.Cell(Renglon, Me.iGyNombreConcepto).Text = oConcepto.Nombre_Concepto
                                'Else
                                '    GoTo busca_concepto
                                '    Return
                            End If

                    End Select

                    'Case Keys.F7
                    '    Select Case Columna
                    '        Case Me.iGyCuentaContable
                    '            oCuenta = New Class_CatCuentas()
                    '            Dim sCuenta As String = oCuenta.BusquedaVisual_PorCodigoFiltrandoTipoOperacion()
                    '            If txtLEN(sCuenta) = True Then
                    '                GridCuentas.Cell(Renglon, Me.iGyCuentaContable).Text = sCuenta
                    '                Me.GridCuentas.Cell(Renglon, Me.iGyCuentaContable).Text = oCuenta.CUENTA_CONTABLE
                    '                Me.GridCuentas.Cell(Renglon, Me.iGyNombreCuenta).Text = oCuenta.NOMBRE_CUENTA_NIVELES_COMPLETOS
                    '                'If Renglon = 1 Then
                    '                '    Me.GridCuentas.Cell(Renglon, Me.iGyConcepto).Text = Me.TxtConcepto.Text
                    '                'Else
                    '                '    Me.GridCuentas.Cell(Renglon, Me.iGyConcepto).Text = Me.TxtConcepto.Text
                    '                'End If
                    '            End If
                    '            oCuenta = Nothing
                    '    End Select

                Case Keys.F8
                    Me.GridCuentas.Selection.DeleteByRow()

                    'Case Keys.Insert
                    '    If Columna = Me.iGyCuentaContable Then 'Columna de cuenta contable

                    '        Dim iRow As Integer, iCol As Integer, i As Integer

                    '        Me.GridCuentas.Rows = Me.GridCuentas.Rows + 1

                    '        iRow = Me.GridCuentas.Rows - 2
                    '        For i = 1 To Me.GridCuentas.Rows - 1 - Renglon
                    '            For iCol = 1 To GridCuentas.Cols - 1
                    '                Me.GridCuentas.Cell(iRow + 1, iCol).Text = Me.GridCuentas.Cell(iRow, iCol).Text
                    '                If iRow = Renglon Then
                    '                    Me.GridCuentas.Cell(iRow, iCol).Text = "" 'Make the current row empty 
                    '                End If
                    '            Next
                    '            iRow = iRow - 1
                    '        Next
                    '    End If
            End Select

            Me.TotalizaGridCentrosCostosyActivos()

        Catch ex As Exception
            HandleError(Me.Name, "GestionaGrid", ex)
        End Try
    End Sub

    Private Sub GestionaGridActivos(ByVal e As System.Windows.Forms.KeyEventArgs)
        Dim sProcedure As String = "GestionaGridActivos"
        Dim Columna As Integer, Renglon As Integer
        Dim sCuentaContable As String = "", oCuenta As Class_CatCuentas

        With Me.GridActivos
            Try
                Columna = .Selection.FirstCol
                Renglon = .Selection.FirstRow

                If .Column(Columna).Locked = True Then
                    Return
                End If

                Select Case e.KeyCode
                    Case Keys.Return
                        Select Case Columna
                            Case Me.iGyActivoCuentaContable
                                sCuentaContable = .Cell(Renglon, Columna).Text
                                If txtLEN(sCuentaContable) = False Then
                                    GoTo busca_cuenta_contable
                                    Return
                                ElseIf sCuentaContable.StartsWith("1") = False Then
                                    .Cell(Renglon, Me.iGyActivoCuentaContable).Text = ""
                                    .Cell(Renglon, Me.iGyActivoNombreCuenta).Text = ""
                                    MsgBox("La cuenta contable del renglón : " & Renglon & " debe ser del rango de las miles(que empiezen con 1).", MsgBoxStyle.Exclamation, sProcedure)
                                    Return
                                End If

                                oCuenta = New Class_CatCuentas(sCuentaContable)
                                If oCuenta._Existe = False Then
                                    MsgBox("La cuenta contable que intenta buscar no existe, favor de intentar con otro código.", MsgBoxStyle.Critical, sProcedure)
                                    Me.InicializaRenglonGridActivos(Renglon)
                                    Return
                                Else
                                    .Cell(Renglon, Me.iGyActivoNombreCuenta).Text = oCuenta.NOMBRE_CUENTA_NIVELES_COMPLETOS
                                End If
                                oCuenta = Nothing

                            Case Me.iGyActivoImporte
                                If valorNumerico(.Cell(Renglon, Me.iGyActivoImporte).Text) = 0 Then
                                    e.Handled = True 'Con esto el importe si es 0 no se brinca a la siguiente columna, se queda el foco en el importe.
                                    Return
                                End If
                        End Select

salto_columna:
                        If .Rows = Renglon + 1 And .Cell(Renglon, Me.iGyActivoImporte).Locked = False Then
                            .Rows = .Rows + 1
                        End If

                        Select Case Columna
                            Case Me.iGyActivoImporte
                                .Cell(Renglon + 1, 0).SetFocus()
                            Case Else
                                .Cell(Renglon, Columna).SetFocus()
                        End Select

                    Case Keys.F6
                        Select Case Columna
                            Case Me.iGyActivoCuentaContable
busca_cuenta_contable:
                                oCuenta = New Class_CatCuentas()
                                Dim sCuenta As String = oCuenta.BusquedaVisual_PorCodigoConLike("1")
                                If txtLEN(sCuenta) = True Then
                                    oCuenta = New Class_CatCuentas(sCuenta)
                                    .Cell(Renglon, Me.iGyActivoCuentaContable).Text = oCuenta.CUENTA_CONTABLE
                                    .Cell(Renglon, Me.iGyActivoNombreCuenta).Text = oCuenta.NOMBRE_CUENTA_NIVELES_COMPLETOS
                                End If
                                oCuenta = Nothing
                        End Select

                    Case Keys.F7
                        Select Case Columna
                            Case Me.iGyActivoCuentaContable
                                oCuenta = New Class_CatCuentas()
                                Dim sCuenta As String = oCuenta.BusquedaVisual_PorDescripcionConLike("1")
                                If txtLEN(sCuenta) = True Then
                                    oCuenta = New Class_CatCuentas(sCuenta)
                                    .Cell(Renglon, Me.iGyActivoCuentaContable).Text = oCuenta.CUENTA_CONTABLE
                                    .Cell(Renglon, Me.iGyActivoNombreCuenta).Text = oCuenta.NOMBRE_CUENTA_NIVELES_COMPLETOS
                                End If
                                oCuenta = Nothing
                        End Select

                    Case Keys.F8
                        .Selection.DeleteByRow()

                End Select

                Me.TotalizaGridCentrosCostosyActivos()

            Catch ex As Exception
                HandleError(Me.Name, "GestionaGridActivos", ex)
            End Try

        End With
    End Sub

    Private Sub GestionaGridFacturasRelacionadas(ByVal e As System.Windows.Forms.KeyEventArgs)
        Dim sProcedure As String = "GestionaGridFacturasRelacionadas"
        Dim Columna As Integer, Renglon As Integer
        Dim StrCod As String = ""
        Dim sCodigo As String = "", sTipo As String = ""
        Dim oCliente As New Class_CatClientes
        Dim oVenta As New Class_Ventas_Global

        With Me.GridFacturasRelacionadas
            Try
                Columna = .Selection.FirstCol
                Renglon = .Selection.FirstRow

                If .Column(Columna).Locked = True Then
                    Return
                End If

                Select Case e.KeyCode
                    Case Keys.Return
                        Select Case Columna
                            Case Me.iGyCodigoCliente
                                sCodigo = .Cell(Renglon, Columna).Text
                                If txtLEN(sCodigo) = False Then
                                    GoTo BuscaCliente
                                    Return
                                End If

                                oCliente = New Class_CatClientes(sCodigo)
                                If oCliente.Existe = False Then
                                    MsgBox("El código de cliente no existe o esta dado de baja.", MsgBoxStyle.Critical, sProcedure)
                                    Return
                                Else
                                    .Cell(Renglon, Columna).Text = sCodigo.ToUpper
                                    .Cell(Renglon, Me.iGyNombreCliente).Text = oCliente.NOMBRE_CLIENTE
                                    .Column(Me.iGyFolioVenta).Locked = False
                                End If
                                sCodigo = Nothing

                            Case Me.iGyFolioVenta
                                If txtLEN(.Cell(Renglon, Me.iGyCodigoCliente).Text) = False Then
                                    MsgBox("Asígne un código de cliente.", MsgBoxStyle.Exclamation, sProcedure)
                                    .Cell(Renglon, Columna).Text = ""
                                    .Cell(Renglon, Me.iGyCodigoCliente).SetFocus()
                                    Return
                                End If

                                sCodigo = .Cell(Renglon, Columna).Text
                                If txtLEN(sCodigo) = False Then
                                    GoTo BuscaVenta
                                    Return
                                End If

                                oVenta = New Class_Ventas_Global(sCodigo)
                                If oVenta.Existe = False Then
                                    MsgBox("El folio de venta no existe.", MsgBoxStyle.Critical, sProcedure)
                                    Return
                                Else
                                    If Me.ValidaFolioVenta(sCodigo, Renglon) = False Then
                                        .Cell(Renglon, Me.iGyFolioVenta).Text = ""
                                        Exit Sub
                                    End If

                                    .Cell(Renglon, Me.iGyFolioVenta).Text = sCodigo.ToUpper
                                    .Cell(Renglon, Me.iGyFechaVenta).Text = oVenta.FECHA.ToString

                                    If Me.chkPromediarGasto.Checked Then
                                        Me.PromediarGastoGridVentas()
                                    End If
                                    Me.TotalGridFacturasRelacionadas()
                                End If
                                sCodigo = Nothing

                            Case Me.iGyGasto
                                If txtLEN(.Cell(Renglon, Me.iGyCodigoCliente).Text) = False Then
                                    MsgBox("Asígne un código de cliente.", MsgBoxStyle.Exclamation, sProcedure)
                                    .Cell(Renglon, Columna).Text = ""
                                    Return
                                End If

                                If txtLEN(.Cell(Renglon, Me.iGyFolioVenta).Text) = False Then
                                    MsgBox("Asígne un folio de venta." + .Cell(Renglon, Me.iGyCodigoCliente).Text, MsgBoxStyle.Exclamation, sProcedure)
                                    .Cell(Renglon, Columna).Text = ""
                                    Return
                                End If

                                Me.TotalGridFacturasRelacionadas()

                        End Select

                        If .Rows = Renglon + 1 And txtLEN(.Cell(Renglon, Me.iGyCodigoCliente).Text) = True And txtLEN(.Cell(Renglon, Me.iGyGasto).Text) = True Then
                            .Rows = .Rows + 1
                        End If

                        Select Case Columna
                            Case Me.iGyGasto
                                .Cell(Renglon + 1, 0).SetFocus()
                            Case Else
                                .Cell(Renglon, Columna).SetFocus()
                        End Select

                    Case Keys.F6
                        Select Case Columna
                            Case Me.iGyCodigoCliente
BuscaCliente:
                                sCodigo = oCliente.BusquedaVisual_PorDescripcion
                                If txtLEN(sCodigo) = True Then
                                    oCliente = New Class_CatClientes(sCodigo)
                                    .Cell(Renglon, Me.iGyCodigoCliente).Text = sCodigo
                                    .Cell(Renglon, iGyNombreCliente).Text = oCliente.NOMBRE_CLIENTE
                                    .Column(Me.iGyFolioVenta).Locked = False
                                End If
                                sCodigo = Nothing

                            Case Me.iGyFolioVenta
                                If txtLEN(.Cell(Renglon, Me.iGyCodigoCliente).Text) = True Then

BuscaVenta:                         'Se usa esta busqueda visual porque trae las facturas de un cliente especifico y deja buscarlas por codigo
                                    sCodigo = oVenta.BusquedaVisualFacturasClienteParaRelacionarCFDIs(.Cell(Renglon, Me.iGyCodigoCliente).Text)

                                    If txtLEN(sCodigo) = True Then
                                        If Me.ValidaFolioVenta(sCodigo, Renglon) = False Then
                                            .Cell(Renglon, Me.iGyFolioVenta).Text = ""
                                            Exit Sub
                                        End If
                                        oVenta = New Class_Ventas_Global(sCodigo)
                                        .Cell(Renglon, Me.iGyFolioVenta).Text = sCodigo
                                        .Cell(Renglon, Me.iGyFechaVenta).Text = oVenta.FECHA.ToString

                                        If Me.chkPromediarGasto.Checked Then
                                            Me.PromediarGastoGridVentas()
                                        End If
                                        Me.TotalGridFacturasRelacionadas()

                                    End If
                                    sCodigo = Nothing
                                End If

                        End Select

                    Case Keys.F8, Keys.Delete
                        If Renglon = 1 Then
                            For i = 1 To Me.GridFacturasRelacionadas.Cols - 1
                                Me.GridFacturasRelacionadas.Cell(Renglon, i).Text = ""
                            Next
                        Else
                            .Selection.DeleteByRow()
                        End If

                        Me.TotalGridFacturasRelacionadas()

                End Select
            Catch ex As Exception
                HandleError(Me.Name, sProcedure, ex)
            End Try
        End With
    End Sub

    Private Sub TotalizaGridCentrosCostosyActivos()
        Try
            Me.TxtSubTotal.Text = FormatImporteContable(FG_Grid_SumaCol(Me.GridCuentas, CShort(Me.iGyImporte)) + FG_Grid_SumaCol(Me.GridActivos, CShort(Me.iGyActivoImporte)))
            Me.txtTotalCompra.Text = FormatImporteContable(valorNumerico(Me.TxtSubTotal.Text) + valorNumerico(Me.TxtIVA.Text) - valorNumerico(Me.TxtRetencionIVA.Text) - valorNumerico(Me.txtRetencionISR.Text))
            Me.CalculaImporteDolares()
        Catch ex As Exception
            HandleError(Me.Name, "TotalizaGridCentrosCostosyActivos", ex)
        End Try
    End Sub

    Private Sub TotalGridFacturasRelacionadas()
        Try
            Me.lblTotalFacturasRelacionadas.Text = "$ " & FG_Grid_SumaCol(Me.GridFacturasRelacionadas, CShort(Me.iGyGasto))
        Catch ex As Exception
            HandleError(Me.Name, "TotalGridFacturasRelacionadas", ex)
        End Try
    End Sub

    Private Sub PromediarGastoGridVentas()
        Dim i, columnas As Integer
        Dim GastoPromedio As Decimal
        Try
            columnas = 0
            For i = 1 To Me.GridFacturasRelacionadas.Rows - 1
                If txtLEN(Me.GridFacturasRelacionadas.Cell(i, Me.iGyFolioVenta).Text) = True Then
                    columnas = columnas + 1
                End If
            Next

            GastoPromedio = CDec(Me.txtTotalCompra.Text) / columnas

            For i = 1 To Me.GridFacturasRelacionadas.Rows - 1
                If txtLEN(Me.GridFacturasRelacionadas.Cell(i, Me.iGyFolioVenta).Text) = True Then
                    Me.GridFacturasRelacionadas.Cell(i, Me.iGyGasto).Text = GastoPromedio.ToString
                End If
            Next

        Catch ex As Exception
            HandleError(Me.Name, "PromediarGastoGridVentas", ex)
        End Try
    End Sub


    Private Function EstableceCentroCosto(ByVal Renglon As Integer, ByVal Columna As Integer, ByVal KeyCode As System.Windows.Forms.Keys, ByVal sTipo As String, ByVal sCodigo As String) As Boolean
        Dim bResultado As Boolean = False
        Try
            Dim oCentroCosto As New Class_VwCatCentrosCostosyDeudoresDiversos(sTipo, sCodigo)

            If oCentroCosto.EXISTE = True Then
                Me.GridCuentas.Cell(Renglon, Me.iGyTipo).Text = oCentroCosto.TIPO
                Me.GridCuentas.Cell(Renglon, Me.iGyCodigoCentroCosto).Text = oCentroCosto.CODIGO
                Me.GridCuentas.Cell(Renglon, Me.iGyNombreCentroCosto).Text = oCentroCosto.NOMBRE
                Select Case sTipo
                    Case "DEUDOR_DIVERSO"
                        Me.GridCuentas.Cell(Renglon, Me.iGyCodigoCategoria).Text = ""
                        Me.GridCuentas.Cell(Renglon, Me.iGyNombreCategoria).Text = "NO APLICA"
                        Me.GridCuentas.Cell(Renglon, Me.iGyCodigoConcepto).Text = ""
                        Me.GridCuentas.Cell(Renglon, Me.iGyNombreConcepto).Text = "NO APLICA"
                        Me.GridCuentas.Cell(Renglon, Me.iGyCuentaContable).Text = oCentroCosto.CUENTA_CONTABLE
                End Select
                bResultado = True
            Else
                Me.InicializaRenglonGridCuentas(Renglon)
            End If

            If bResultado = True Then
                Me.SaltoColumnas(Renglon, Columna, KeyCode, sTipo)
            End If

        Catch ex As Exception
            HandleError(Me.Name, "EstableceCentroCosto", ex)
        End Try
        Return bResultado
    End Function

    Private Sub SaltoColumnas(ByVal Renglon As Integer, ByVal Columna As Integer, ByVal KeyCode As System.Windows.Forms.Keys, ByVal sTipo As String)
        If Me.GridCuentas.Rows = Renglon + 1 And Me.GridCuentas.Cell(Renglon, Me.iGyImporte).Locked = False Then
            Me.GridCuentas.Rows = Me.GridCuentas.Rows + 1
        End If

        Select Case Columna
            Case Me.iGyImporte
                Me.GridCuentas.Cell(Renglon + 1, Me.iGyCodigoCentroCosto).SetFocus()
            Case Else
                Select Case sTipo
                    Case "DEUDOR_DIVERSO"
                        Select Case KeyCode
                            Case Keys.Return
                                Me.GridCuentas.Cell(Renglon, Me.iGyNombreConcepto).SetFocus() 'Se pone una antes para quese vaya al importe, porque el enter por si mismo va forzar brincar otra vez
                            Case Keys.F6
                                Me.GridCuentas.Cell(Renglon, Me.iGyImporte).SetFocus()
                        End Select
                    Case Else
                        If KeyCode = Keys.F6 Then
                            Select Case Columna
                                Case Me.iGyNombreCentroCosto
                                    Columna = Me.iGyNombreCategoria
                            End Select
                        End If
                        Me.GridCuentas.Cell(Renglon, Columna).SetFocus()
                End Select
        End Select
    End Sub

    Private Function GestionaGrabar() As Boolean
        Dim bResultado As Boolean = False
        Dim sCuentas As String = "", sListaActivos As String = ""
        Dim i As Integer
        Dim sProveedor As String = Me.TxtCodigoProveedor.Text

        If Me.ValidarCompra = False Then
            Return False
        End If

        If Estado = enumEstados.SINORDENCOMPRA Then
            If Me.ValidaCuentasContables = False Then
                Return False
            End If
        End If

        Try
            If Estado = enumEstados.SINORDENCOMPRA Then
                With Me.oCompras
                    .FOLIO_COMPRA = Me.txtFolioCompra.Text
                    .CODIGO_DOCUMENTO = sCodigoTipoDocumento & Usuario.Codigo_Plaza.ToString
                    .CODIGO_ALMACEN = Me.CboAlmacen.SelectedValue.ToString
                    .CODIGO_PLAZA = Plaza.CODIGO_PLAZA
                    '.FECHA = Me.DtpFecha.Value
                    .FECHA_FACTURA_PROVEEDOR = Me.DtpFechaFacturaProveedor.Value
                    .FOLIO_OC = ""
                    .FOLIO_PROVEEDOR = Me.txtFolioProveedor.Text
                    .CODIGO_PROVEEDOR = Me.TxtCodigoProveedor.Text
                    .PLAZO = 0
                    .FECHA_VENCIMIENTO = Me.dtpFechaVencimiento.Value
                    .SUBTOTAL = valorNumerico(Me.TxtSubTotal.Text)
                    .IMPUESTO = valorNumerico(Me.TxtIVA.Text)
                    .TOTAL = valorNumerico(Me.txtTotalCompra.Text)
                    .RETENCION = valorNumerico(Me.TxtRetencionIVA.Text)
                    .RETENCION_ISR = valorNumerico(Me.txtRetencionISR.Text)
                    .IMPUESTO_PORCENTAJE = CDbl(Me.txtPorciento.Text)
                    .TIPO_DE_CAMBIO = valorNumerico(Me.txtTipoCambio.Text)
                    .CONCEPTO = Me.TxtConcepto.Text
                    .FOLIO_EMBARQUE = Me.txtEmbarque.Text
                    .FECHA_PROGRAMACION = Me.dtpFechaVencimiento.Value

                    For i = 1 To Me.GridCuentas.Rows - 1
                        If Me.GridCuentas.Cell(i, Me.iGyCuentaContable).Text <> "" And valorNumerico(Me.GridCuentas.Cell(i, Me.iGyImporte).Text) > 0 Then
                            sCuentas = sCuentas & i & "," & Me.GridCuentas.Cell(i, Me.iGyTipo).Text & "," & Me.GridCuentas.Cell(i, Me.iGyCodigoCentroCosto).Text & "," & Me.GridCuentas.Cell(i, Me.iGyCodigoCategoria).Text & "," & Me.GridCuentas.Cell(i, Me.iGyCodigoConcepto).Text & "," &
                            valorNumerico(Me.GridCuentas.Cell(i, Me.iGyImporte).Text).ToString & "," & Me.GridCuentas.Cell(i, Me.iGyCuentaContable).Text & "|"
                        End If
                    Next i

                    For i = 1 To Me.GridActivos.Rows - 1
                        If Me.GridActivos.Cell(i, Me.iGyActivoCuentaContable).Text <> "" And valorNumerico(Me.GridActivos.Cell(i, Me.iGyActivoImporte).Text) > 0 Then
                            sListaActivos = sListaActivos & i & "," & Me.GridActivos.Cell(i, Me.iGyActivoCuentaContable).Text & "," & Me.GridActivos.Cell(i, Me.iGyActivoImporte).Text & "|"
                        End If
                    Next i

                    'Estructura anterior
                    'For i = 1 To Me.GridCuentas.Rows - 1
                    '    If Me.GridCuentas.Cell(i, Me.iGyCuentaContable).Text <> "" And valorNumerico(Me.GridCuentas.Cell(i, Me.iGyImporte).Text) > 0 Then
                    '        sCuentas = sCuentas & Me.GridCuentas.Cell(i, Me.iGyCuentaContable).Text & "," & Me.GridCuentas.Cell(i, Me.iGyImporte).Text & "," & Me.GridCuentas.Cell(i, Me.iGyCodigoCentroCosto).Text & "|"
                    '    End If
                    'Next i

                    'Esto era cuando se usaba otro método INSERT #RENGLONES(CUENTA_CONTABLE,IMPORTE) SELECT * FROM dbo.FN_CONVIERTE_TEXT_TABLE(@CUENTA_CONTABLE,'|',2)
                    'For i = 1 To Me.GridCuentas.Rows - 1
                    '    If i = 1 Then
                    '        If Me.GridCuentas.Cell(i, Me.iGyCuentaContable).Text <> "" And valorNumerico(Me.GridCuentas.Cell(i, Me.iGyImporte).Text) > 0 Then
                    '            sCuentas = Me.GridCuentas.Cell(i, Me.iGyCuentaContable).Text & "|" & Me.GridCuentas.Cell(i, Me.iGyImporte).Text
                    '        End If
                    '    Else
                    '        If Me.GridCuentas.Cell(i, Me.iGyCuentaContable).Text <> "" And valorNumerico(Me.GridCuentas.Cell(i, Me.iGyImporte).Text) > 0 Then
                    '            sCuentas = sCuentas & "|" & Me.GridCuentas.Cell(i, Me.iGyCuentaContable).Text & "|" & Me.GridCuentas.Cell(i, Me.iGyImporte).Text
                    '        End If
                    '    End If
                    'Next i

                    If txtLEN(sCuentas) = False And txtLEN(sListaActivos) = False Then
                        MsgBox("Falta introducir los centros de costos o activos.", MsgBoxStyle.Exclamation, "Validación")
                        Return False
                    Else
                        If txtLEN(sCuentas) = True Then
                            sCuentas = sCuentas.Substring(0, sCuentas.Length - 1) 'Para quitarle el último pipe que sale sobrando.
                        End If
                        If txtLEN(sListaActivos) = True Then
                            sListaActivos = sListaActivos.Substring(0, sListaActivos.Length - 1) 'Para quitarle el último pipe que sale sobrando.
                        End If
                    End If

                    If .GrabaCompraGlobalSinOrden(sCuentas, sListaActivos) = False Then
                        MsgBox("Error al tratar de aplicar el movimiento de compras.", MsgBoxStyle.Exclamation, Me.Text)
                        Return False
                    End If
                    Me.txtFolioCompra.Text = .FOLIO_COMPRA

                    If valorNumerico(Me.lblTotalFacturasRelacionadas.Text) > 0 Then
                        If Me.GrabarVentasRelacionadas = False Then
                            MsgBox("Error al tratar de grabar facturas relacionadas.", MsgBoxStyle.Exclamation, Me.Name)
                            Return False
                        End If
                    End If

                    'Aplicar = True
                    MsgBox("Movimiento de gasto grabado satisfactoriamente.", MsgBoxStyle.Information, Me.Text)

                End With

            ElseIf Estado = enumEstados.CONORDENCOMPRA Or Estado = enumEstados.FLETEEMBARQUE Then
                Dim sFolioProv As String
                sFolioProv = Me.txtFolioProveedor.Text
                If String.IsNullOrEmpty(sFolioProv) Then
                    Return False
                Else
                    Me.oCompras.FOLIO_COMPRA = Me.txtFolioCompra.Text
                    Me.oCompras.FOLIO_PROVEEDOR = sFolioProv
                    Me.oCompras.FECHA_FACTURA_PROVEEDOR = Me.DtpFechaFacturaProveedor.Value
                    Me.oCompras.FECHA_PROGRAMACION = Me.dtpFechaVencimiento.Value
                    Me.oCompras.ActualizaDatosContraRecibos()
                End If

                MsgBox("Movimiento de compras se actualizó satisfactoriamente.", MsgBoxStyle.Information, Me.Text)
            End If

            Me.Inicializa()
            Me.TxtCodigoProveedor.Text = sProveedor

            bResultado = True
        Catch ex As Exception
            HandleError(Me.Name, "GestionaGrabar", ex)
        End Try

        Return bResultado
    End Function

    Private Function GrabarVentasRelacionadas() As Boolean
        Dim bResultado As Boolean = False
        Dim i As Integer
        Dim oDetalleVentas As New Class_Centros_Costos_Detalle_Ventas

        Try
            'Eliminamos todas las ventas(si es que hay previamente grabadas)
            If oDetalleVentas.EliminaCentroCostosDetalleVentas(Me.txtFolioCompra.Text) = False Then
                Return False
            End If

            If valorNumerico(Me.txtTotalCompra.Text) <> valorNumerico(Me.lblTotalFacturasRelacionadas.Text) Then
                MsgBox("El total del gasto es distinto del gasto de las facturas.", MsgBoxStyle.Exclamation, Me.Name)
                Return False
            End If

            With oDetalleVentas
                For i = 1 To Me.GridFacturasRelacionadas.Rows - 1
                    If txtLEN(Me.GridFacturasRelacionadas.Cell(i, Me.iGyCodigoCliente).Text) = True AndAlso txtLEN(Me.GridFacturasRelacionadas.Cell(i, Me.iGyFolioVenta).Text) = True _
                    AndAlso txtLEN(Me.GridFacturasRelacionadas.Cell(i, Me.iGyGasto).Text) = True AndAlso valorNumerico(Me.GridFacturasRelacionadas.Cell(i, Me.iGyGasto).Text) > 0 Then
                        .ID_CENTRO_COSTOS_DETALLE_VENTAS = Me.GridFacturasRelacionadas.Cell(i, Me.iGyIdCentroCostosDetalleVentas).Text
                        .FOLIO_MOVIMIENTO = Me.txtFolioCompra.Text
                        .FOLIO_VENTA = Me.GridFacturasRelacionadas.Cell(i, Me.iGyFolioVenta).Text
                        .IMPORTE = valorNumerico(Me.GridFacturasRelacionadas.Cell(i, Me.iGyGasto).Text)

                        If .GrabaCentroCostosDetalleVentas = False Then
                            MsgBox("Error al insertar el renglon " & i, MsgBoxStyle.Exclamation)
                            Return False
                        End If
                    End If
                Next

                bResultado = True
            End With

        Catch ex As Exception
            HandleError(Me.Name, "GrabarVentasRelacionadas", ex)
        End Try

        Return bResultado
    End Function

    Private Function ValidarCompra() As Boolean
        Dim bResultado As Boolean = False
        Dim sProcedure As String = "ValidarCompra"

        Try
            If Plaza.ValidarPeriodoTrabajo(Me.dtpFechaVencimiento.Value) = False Then
                Return False
            End If

            If Estado = enumEstados.PAGODIRECTO Then
                sCodigoTipoDocumento = "CA"

            ElseIf Estado = enumEstados.CONORDENCOMPRA Then
                sCodigoTipoDocumento = "CO"
                If txtLEN(Me.txtFolioCompra.Text) = False Then
                    MsgBox("Favor de seleccionar una compra.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If

            ElseIf Estado = enumEstados.FLETEEMBARQUE Then
                sCodigoTipoDocumento = "CA"
                If txtLEN(Me.txtFolioCompra.Text) = False Then
                    MsgBox("Favor de seleccionar una compra.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If

            ElseIf Estado = enumEstados.SINORDENCOMPRA Then
                sCodigoTipoDocumento = "CA"

                'If MsgBox("Deseas agregar la compra ?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, sProcedure) = MsgBoxResult.No Then
                '    return false
                'End If

                'If Usuario.ValidaPermisoUsuarioDocumentoConAfectacionInventarios("CO" & Usuario.Codigo_Plaza.ToString, Me.CboAlmacen.SelectedValue.ToString) = False Then
                '    MsgBox("El usuario " & Usuario.Nombre_Usuario & " no tiene permiso para realizar el movimiento.", MsgBoxStyle.Information, sProcedure)
                '    return false
                'End If

                'Validar que hayan capturado todos los datos del frame2 requeridos(ver cuales son en el comentario de Continuar1)*racalco la cuentacontable
                'Validar que el total cuadre=Subtotal+IVA-Retenciones
                'Validar que si capturan IVA en $, también capturen el IVA en %
                'If txtLEN(Me.txtCuenta.Text) = False Then
                '    MsgBox("Falta introducir la cuenta contrable, favor de asignarle una.", MsgBoxStyle.Exclamation, "Validación")
                '    return false
                'Else
                '    Dim oCuenta As New Class_CatCuentas
                '    oCuenta = New Class_CatCuentas(Me.txtCuenta.Text)
                '    If oCuenta._Existe = False Then
                '        MsgBox("La cuenta contable que intenta grabar no existe favor de intentar con otro código.", MsgBoxStyle.Exclamation)
                '        return false
                '    ElseIf oCuenta.ESMAYOR = "1" Then
                '        MsgBox("La cuenta contable no existe, favor de intentar con otro código.", MsgBoxStyle.Exclamation)
                '        return false
                '    End If
                'End If

                If valorNumerico(Me.TxtSubTotal.Text) <= 0 Then
                    MsgBox("Captúre los renglones.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If
                Dim dSumaGridCuentas As Double = Redondear(FG_Grid_SumaCol(Me.GridCuentas, CShort(Me.iGyImporte)), 2)
                Dim dSumaGridActivos As Double = Redondear(FG_Grid_SumaCol(Me.GridActivos, CShort(Me.iGyActivoImporte)), 2)
                Dim dSumaRenglones As Double = Redondear(dSumaGridCuentas + dSumaGridActivos, 2)

                If dSumaRenglones <> valorNumerico(Me.TxtSubTotal.Text) Then
                    MsgBox("La suma de los renglones $ " & dSumaRenglones & "no cuadra con el subtotal $ " & valorNumerico(Me.TxtSubTotal.Text), MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If

                If valorNumerico(Me.txtTotalCompra.Text) <> CDbl(FormatNumber((valorNumerico(Me.TxtSubTotal.Text) + valorNumerico(Me.TxtIVA.Text) - valorNumerico(Me.TxtRetencionIVA.Text) - valorNumerico(Me.txtRetencionISR.Text)), 2)) Then
                    MsgBox("El total no esta correcto, favor de verificar.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If

                'Me.txtTotalCompra.Text = (valorNumerico(Me.TxtSubTotal.Text) + valorNumerico(Me.TxtIVA.Text) - valorNumerico(Me.TxtRetencion.Text)).ToString
                If valorNumerico(Me.TxtIVA.Text) <> 0 Or txtLEN(Me.TxtIVA.Text) = False Then
                    If valorNumerico(Me.txtPorciento.Text) = 0 Or txtLEN(Me.txtPorciento.Text) = False Then
                        MsgBox("No ha capturado el porcentaje del IVA, favor de verificar.", MsgBoxStyle.Exclamation, sProcedure)
                        Me.txtPorciento.Focus()
                        Return False
                    End If
                ElseIf valorNumerico(Me.txtPorciento.Text) <> 0 Or txtLEN(Me.txtPorciento.Text) = False Then
                    If valorNumerico(Me.TxtIVA.Text) = 0 Or txtLEN(Me.TxtIVA.Text) = False Then
                        MsgBox("No ha capturado el total del IVA, favor de verificar.", MsgBoxStyle.Exclamation, sProcedure)
                        Me.TxtIVA.Focus()
                        Return False
                    End If
                End If

                If txtLEN(Me.txtFolioProveedor.Text) = False Then
                    MsgBox("Favor de asignar el folio de la factura del proveedor.", MsgBoxStyle.Exclamation, sProcedure)
                    Me.txtFolioProveedor.Focus()
                    Return False
                End If
            End If

            If Me.ckbDolares.Checked = True Then
                Dim oProveedor As New Class_CatProveedores(Me.TxtCodigoProveedor.Text)

                Me.CalculaImporteDolares()
                If txtLEN(oProveedor.CUENTA_CONTABLE_DOLARES) = False Then
                    MsgBox("El proveedor no tiene una cuenta contable en dólares.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If

                If valorNumerico(Me.txtTipoCambio.Text) <= 0 Then
                    MsgBox("Favor de asignar el tipo de cambio.", MsgBoxStyle.Exclamation, sProcedure)
                    Me.txtTipoCambio.Focus()
                    Return False
                End If
            End If

            If valorNumerico(Me.lblTotalFacturasRelacionadas.Text) > 0 Then
                If valorNumerico(Me.txtTotalCompra.Text) <> valorNumerico(Me.lblTotalFacturasRelacionadas.Text) Then
                    MsgBox("El total del gasto es distinto del gasto de las facturas.", MsgBoxStyle.Exclamation, Me.Name)
                    Return False
                End If
            End If

            bResultado = True

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    Private Function ValidaCuentasContables() As Boolean
        Dim bResultado As Boolean = False
        Dim sProcedure As String = "ValidaCuentasContables"
        Dim i As Integer, bHayCuentasContables As Boolean = False
        Dim sCuentaContable As String = "", oCuenta As New Class_CatCuentas

        Try
            ''''''''''''''''''''''''''''''''''''''''''''''''
            With Me.GridCuentas
                For i = 1 To .Rows - 1
                    sCuentaContable = .Cell(i, Me.iGyCuentaContable).Text
                    If txtLEN(sCuentaContable) = True Then
                        oCuenta = New Class_CatCuentas(sCuentaContable)
                        If oCuenta._Existe = False Then
                            MsgBox("La cuenta contable del renglón: " & i & " no existe, favor de intentar con otro código.", MsgBoxStyle.Exclamation, sProcedure)
                            .Cell(i, Me.iGyCuentaContable).SetFocus()
                            Return False
                        ElseIf oCuenta.ESMAYOR = "1" Then
                            MsgBox("La cuenta contable del renglón: " & i & " es de mayor, favor de intentar con otro código.", MsgBoxStyle.Exclamation, sProcedure)
                            .Cell(i, Me.iGyCuentaContable).SetFocus()
                            Return False
                        ElseIf Microsoft.VisualBasic.Left(sCuentaContable, 1) = "5" Then
                            If .Cell(i, Me.iGyTipo).Text <> "CENTRO_COSTO" Then
                                MsgBox("La cuenta contable del renglón: " & i & " es 5 mil , y el tipo no es centro de costos.", MsgBoxStyle.Exclamation, sProcedure)
                                Return False
                            End If
                            If txtLEN(.Cell(i, Me.iGyCodigoCentroCosto).Text) = False Or .Cell(i, Me.iGyCodigoCentroCosto).Text = "0" Then
                                MsgBox("La cuenta contable  del renglón: " & i & " es 5 mil , favor de asignar un centro de costo.", MsgBoxStyle.Exclamation, sProcedure)
                                .Cell(i, Me.iGyCodigoCentroCosto).SetFocus()
                                Return False
                            End If
                        ElseIf Microsoft.VisualBasic.Left(sCuentaContable, 1) = "1" Then
                            If .Cell(i, Me.iGyTipo).Text <> "DEUDOR_DIVERSO" Then
                                MsgBox("La cuenta contable del renglón: " & i & " es 1 mil , y el tipo no es deudor diverso.", MsgBoxStyle.Exclamation, sProcedure)
                                Return False
                            End If
                        ElseIf valorNumerico(.Cell(i, Me.iGyImporte).Text) = 0 Then
                            MsgBox("Falta introducir el importe del renglón: " & i & ".", MsgBoxStyle.Exclamation, sProcedure)
                            .Cell(i, Me.iGyImporte).SetFocus()
                            Return False
                        End If
                        bHayCuentasContables = True
                    End If
                Next i

                For i = 1 To .Rows - 1
                    If valorNumerico(.Cell(i, Me.iGyImporte).Text) <> 0 Then 'Si capturaron algún importe.
                        If Len(.Cell(i, Me.iGyCuentaContable).Text) = 0 Then
                            MsgBox("Falta introducir la cuenta contrable del renglón: " & i & ".", MsgBoxStyle.Exclamation, sProcedure)
                            .Cell(i, Me.iGyCuentaContable).SetFocus()
                            Return False
                        End If
                    End If
                Next i

            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''
            With Me.GridActivos
                For i = 1 To .Rows - 1
                    sCuentaContable = .Cell(i, Me.iGyActivoCuentaContable).Text
                    If txtLEN(sCuentaContable) = True Then
                        oCuenta = New Class_CatCuentas(sCuentaContable)

                        If oCuenta._Existe = False Then
                            MsgBox("La cuenta contable(de los activos) del renglón: " & i & " no existe, favor de intentar con otro código.", MsgBoxStyle.Exclamation, sProcedure)
                            .Cell(i, Me.iGyActivoCuentaContable).SetFocus()
                            Return False
                        ElseIf oCuenta.ESMAYOR = "1" Then
                            MsgBox("La cuenta contable(de los activos) del renglón: " & i & " es de mayor, favor de intentar con otro código.", MsgBoxStyle.Exclamation, sProcedure)
                            .Cell(i, Me.iGyActivoCuentaContable).SetFocus()
                            Return False
                        ElseIf sCuentaContable.StartsWith("1") = False Then 'Si no empieza con 1
                            MsgBox("La cuenta contable del renglón : " & i & " debe ser del rango de las miles(que empiezen con 1).", MsgBoxStyle.Exclamation, sProcedure)
                            Return False
                        End If
                        bHayCuentasContables = True
                    End If
                Next i
            End With
            ''''''''''''''''''''''''''''''''''''''''''''''''

            If bHayCuentasContables = False Then
                MsgBox("Captúre el detalle de la póliza.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            bResultado = True

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    Private Function ValidaFolioVenta(ByVal sFolio As String, ByVal row As Integer) As Boolean
        Dim bResultado As Boolean = False
        Dim i As Integer
        Try
            For i = 1 To row - 1
                If Me.GridFacturasRelacionadas.Cell(i, Me.iGyFolioVenta).Text = sFolio Then
                    MsgBox("El folio " & sFolio & " ya está capturado en el renglón " & i, MsgBoxStyle.Exclamation, Me.Name)
                    Return bResultado
                End If
            Next

            bResultado = True
        Catch ex As Exception
            HandleError(Me.Name, "ValidaFolioVenta", ex)
        End Try
        Return bResultado
    End Function

    Private Sub CalculaImporteDolares()
        Try
            If txtLEN(Me.txtTotalCompra.Text) = True And valorNumerico(Me.txtTotalCompra.Text) > 0 Then
                Me.txtTipoCambio.Text = valorNumerico(Me.txtTipoCambio.Text).ToString
                Me.txtTipoCambio.Text = Redondear(valorNumerico(Me.txtTipoCambio.Text), 4).ToString
                Me.txtImporteDolares.Text = (valorNumerico(Me.txtTotalCompra.Text) / valorNumerico(Me.txtTipoCambio.Text)).ToString
                Me.txtImporteDolares.Text = valorNumerico(Me.txtImporteDolares.Text).ToString
                Me.txtImporteDolares.Text = Redondear(valorNumerico(Me.txtImporteDolares.Text), 2).ToString
            Else
                Me.txtTipoCambio.Text = valorNumerico(Me.txtTipoCambio.Text).ToString
                Me.txtTipoCambio.Text = Redondear(valorNumerico(Me.txtTipoCambio.Text), 4).ToString
                Me.txtImporteDolares.Text = "0"
                Me.txtImporteDolares.Text = valorNumerico(Me.txtImporteDolares.Text).ToString
                Me.txtImporteDolares.Text = Redondear(valorNumerico(Me.txtImporteDolares.Text), 2).ToString
            End If
        Catch ex As Exception
            HandleError(Me.Name, "CalculaImporteDolares", ex)
        End Try
    End Sub

    Private Sub Imprimir(ByVal folioPoliza As String)
        Dim StrFiltros As String = ""
        Dim FormatoDeReporte As String
        Dim Rpt As New ReportDocument
        Dim oReporte As Class_Reporte
        Try
            FormatoDeReporte = "RPT_FORMATO_CONTABILIDAD_POLIZA"
            oReporte = New Class_Reporte(FormatoDeReporte, Rpt, False)
            If Not oReporte.RptCargado Then
                Exit Sub
            End If
            Rpt.SetParameterValue("@FOLIO_POLIZA", folioPoliza)
            Dim frm As New Reporte(Rpt)
            frm.CRViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            frm.Show()
        Catch ex As Exception
            HandleError(Me.Name, "Imprimir", ex)
        Finally
            oReporte = Nothing
        End Try
    End Sub

    Private Function Navegador(ByVal sTipoDeBusqueda As String) As Boolean
        Dim bResultado As Boolean = False
        Try
            Dim iFolio As Integer, sFolio As String, iPosicion As Integer, sFolioParte2 As String
            If txtLEN(Me.txtFolioCompra.Text) = False Then
                If txtLEN(Me.txtFolioCompra.Text) = False Then
                    Exit Function
                End If
            End If

            If sTipoDeBusqueda = "Anterior" Then
                iPosicion = Me.txtFolioCompra.Text.IndexOf("-")
                sFolio = Me.txtFolioCompra.Text.Substring(0, iPosicion)
                iFolio = CInt(Strings.Right(Me.txtFolioCompra.Text, Len(Me.txtFolioCompra.Text) - (Len(sFolio) + 1))) ' Me.oVenta.FOLIO_NUMERICO
                iFolio = iFolio - 1
                sFolioParte2 = Format(iFolio, New String(CChar("0"), Me.txtFolioCompra.Text.Substring(3, Me.txtFolioCompra.TextLength - iPosicion - 1).Length))
                sFolio = sFolio + "-" + sFolioParte2 'sFolio + "-" + iFolio.ToString
                Me.txtFolioCompra.Text = sFolio

                If txtLEN(sFolio) = True Then
                    Me.Consultar()
                Else
                    Me.Inicializa()
                    Me.Cambia_Estado(enumEstados.NUEVO)
                    Me.txtFolioCompra.Focus()
                End If

            ElseIf sTipoDeBusqueda = "Siguiente" Then
                iPosicion = Me.txtFolioCompra.Text.IndexOf("-")
                sFolio = Me.txtFolioCompra.Text.Substring(0, iPosicion)
                iFolio = CInt(Strings.Right(Me.txtFolioCompra.Text, Len(Me.txtFolioCompra.Text) - (Len(sFolio) + 1))) ' Me.oVenta.FOLIO_NUMERICO
                iFolio = iFolio + 1
                sFolioParte2 = Format(iFolio, New String(CChar("0"), Me.txtFolioCompra.Text.Substring(3, Me.txtFolioCompra.TextLength - iPosicion - 1).Length))
                sFolio = sFolio + "-" + sFolioParte2 'sFolio + "-" + iFolio.ToString
                Me.txtFolioCompra.Text = sFolio

                If txtLEN(sFolio) = True Then
                    Me.Consultar()
                Else
                    Me.Inicializa()
                    Me.Cambia_Estado(enumEstados.NUEVO)
                    Me.txtFolioCompra.Focus()
                End If
            End If

            bResultado = True
        Catch ex As Exception
            HandleError(Me.Name, "Navegador", ex)
        End Try

        Return bResultado
    End Function

    Private Function Consultar() As Boolean
        Dim bResultado As Boolean = False
        Try
            Dim sFolio As String = Me.txtFolioCompra.Text

            Me.Inicializa()

            Me.oCompras = New Class_Compras_Global(sFolio, "CA" & Usuario.Codigo_Plaza)

            If Me.oCompras.Existe = False Then
                Me.Cambia_Estado(enumEstados.NUEVO)
                Return False
            End If

            Me.txtFolioCompra.Text = Me.oCompras.FOLIO_COMPRA
            Me.LblPoliza.Text = Me.oCompras.FOLIO_POLIZA

            Me.CboAlmacen.SelectedValue = Me.oCompras.CODIGO_ALMACEN
            Me.TxtCodigoProveedor.Text = Me.oCompras.CODIGO_PROVEEDOR

            Dim oProveedor As New Class_CatProveedores(Me.TxtCodigoProveedor.Text)
            Me.LblProveedor.Text = oProveedor.Nombre_Proveedor.ToUpper
            Me.LblCuentaContableProveedor.Text = oProveedor.CUENTA_CONTABLE

            Select Case oCompras.ESTATUS
                Case "A"
                    Me.lblEstatus.Text = "APLICADO"
                Case "C"
                    Me.lblEstatus.Text = "CANCELADO"
            End Select

            Me.TxtConcepto.Text = Me.oCompras.CONCEPTO
            Me.DtpFechaFacturaProveedor.Value = Me.oCompras.FECHA

            If Year(Me.oCompras.FECHA_PROGRAMACION) > 1 Then
                Me.dtpFechaVencimiento.Value = Me.oCompras.FECHA_PROGRAMACION
            End If

            Me.txtFolioProveedor.Text = Me.oCompras.FOLIO_PROVEEDOR

            Me.txtTipoCambio.Text = Me.oCompras.TIPO_DE_CAMBIO.ToString
            If Me.oCompras.TIPO_DE_CAMBIO > 0 Then
                Me.ckbDolares.Checked = True
            End If

            Me.TxtSubTotal.Text = FormatImporteContable(Me.oCompras.SUBTOTAL)
            Me.TxtIVA.Text = FormatImporteContable(Me.oCompras.IMPUESTO)
            Me.txtPorciento.Text = Me.oCompras.IMPUESTO_PORCENTAJE.ToString
            Me.TxtRetencionIVA.Text = FormatImporteContable(Me.oCompras.RETENCION)
            Me.txtRetencionISR.Text = FormatImporteContable(Me.oCompras.RETENCION_ISR)
            Me.txtTotalCompra.Text = FormatImporteContable(Me.oCompras.TOTAL)
            Me.txtImporteDolares.Text = FormatImporteContable(Me.oCompras.TOTAL_DOLARES)

            'Renglones centros costos
            Me.GridCuentas.DataSource = Me.oCompras.ObtenerDetalleCostos
            Me.FormateaGridCuentas()

            'Renglones activos
            Me.GridActivos.DataSource = Me.oCompras.ObtenerDetalleGastosActivos()
            Me.FormateaGridActivos()

            'Renglones facturas relacionadas
            Dim oDetalleVentas As New Class_Centros_Costos_Detalle_Ventas
            Dim dTabla As DataTable = oDetalleVentas.ObtenerDetalleVentas(Me.txtFolioCompra.Text)
            'Me.GridFacturasRelacionadas.AutoRedraw = False
            If dTabla.Rows.Count > 0 Then
                Me.GridFacturasRelacionadas.Rows = 1
            End If

            For Each dRow As DataRow In dTabla.Rows
                Me.GridFacturasRelacionadas.AddItem(dRow("ID_CENTRO_COSTOS_DETALLE_VENTAS").ToString & Chr(9) & dRow("CODIGO_CLIENTE").ToString & Chr(9) & dRow("NOMBRE_CLIENTE").ToString & Chr(9) &
                dRow("FOLIO_VENTA").ToString & Chr(9) & dRow("FECHA").ToString & Chr(9) & dRow("IMPORTE").ToString & Chr(9))
            Next

            Me.FormateaGridFacturasRelacionadas()
            Me.lblTotalFacturasRelacionadas.Text = "$ " & FG_Grid_SumaCol(Me.GridFacturasRelacionadas, CShort(Me.iGyGasto))

            'Me.Cambia_Estado(enumEstados.SINORDENCOMPRA)
            Me.tsbEditarCostos.Enabled = True
            Me.Cambia_Estado(enumEstados.CONSULTA)


            bResultado = True
        Catch ex As Exception
            HandleError(Me.Name, "Navegador", ex)
        End Try

        Return bResultado
    End Function

    Private Function ActualizaConcepto() As Boolean
        Try
            'If Usuario.ValidaPermisoUsuarioDocumentoConAfectacionInventarios(Me.CboDocumento.SelectedValue.ToString, Me.CboAlmacen.SelectedValue.ToString) = False Then
            '    MsgBox("El usuario " & Usuario.Nombre_Usuario & " no tiene permiso para realizar el movimiento.", MsgBoxStyle.Information, Me.Text)
            '    Exit Function
            'End If

            Me.oCompras.CONCEPTO = Me.TxtConcepto.Text.ToUpper
            If Me.oCompras.ActualizaConcepto = True Then
                MsgBox("Concepto actualizado satisfactoramente.", MsgBoxStyle.Information, Me.Text)
                Return True
            End If

        Catch ex As Exception
            HandleError(Me.Name, "ActualizaConcepto", ex)
        End Try
    End Function
#End Region

End Class