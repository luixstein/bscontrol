Option Strict On

Imports CrystalDecisions.CrystalReports.Engine

Public Class Frm_CXP_Gastos

#Region "Campos privados"
    Private oDocumento As New Class_CatDocumentos
    Private oBancosCXP As New Class_Bancos_CXP
    Private oCompras As New Class_Compras_Global

    Dim _Fecha As String

    Private Estado As enumEstados

    Private Enum enumEstados
        NUEVO
        SINORDENCOMPRA
        CONORDENCOMPRA
        FLETEEMBARQUE
        PAGODIRECTO
        CONSULTA
    End Enum

    Private sCodigoTipoDocumento As String = ""
#End Region

#Region "Columnas grid cuentas"
    Private iGyCtasTipo As Integer = 1
    Private iGyCtasCodigoCentroCosto As Integer = 2
    Private iGyCtasNombreCentroCosto As Integer = 3
    Private iGyCtasCodigoCategoria As Integer = 4
    Private iGyCtasNombreCategoria As Integer = 5
    Private iGyCtasCodigoConcepto As Integer = 6
    Private iGyCtasNombreConcepto As Integer = 7
    Private iGyCtasImporte As Integer = 8
    Private iGyCtasIVA As Integer = 9
    Private iGyCtasRetencionIVA As Integer = 10
    Private iGyCtasRetencionISR As Integer = 11
    Private iGyCtasIEPS As Integer = 12
    Private iGyCtasTotal As Integer = 13
    Private iGyCuentaContable As Integer = 14
    Private iGyCtasUUID As Integer = 15
    Private iGyCtasXML As Integer = 16
    Private iGyCtasPDF As Integer = 17
    Private iGyCtasRutaXML As Integer = 18
    Private iGyCtasRutaPDF As Integer = 19
    Private iGyCtasIDCentroCostoDetalle As Integer = 20
    Private iGyCtasCuentaContableRetencionIVA As Integer = 21
    Private iGyCtasCuentaContableRetencionISR As Integer = 22
    Private iGyCtasCuentaContableIEPS As Integer = 23
    Private iGyCtasNombreEmisor As Integer = 24
    Private iGyCtasRFCEmisor As Integer = 25
#End Region

#Region "Columnas grid activos"
    Private iGyActivoCuentaContable As Integer = 1
    Private iGyActivoNombreCuenta As Integer = 2
    Private iGyActivoImporte As Integer = 3
    Private iGyActivoIVA As Integer = 4
    Private iGyActivoRetencionIVA As Integer = 5
    Private iGyActivoRetencionISR As Integer = 6
    Private iGyActivoIEPS As Integer = 7
    Private iGyActivoTotal As Integer = 8
    Private iGyActivoUUID As Integer = 9
    'Private iGyActivoNombrePDF As Integer = 7
    Private iGyActivoXML As Integer = 10
    Private iGyActivoPDF As Integer = 11
    Private iGyActivoRutaXML As Integer = 12
    Private iGyActivoRutaPDF As Integer = 13
    Private iGyActivoIDGastoDetalle As Integer = 14
    Private iGyActivoCuentaContableRetencionIVA As Integer = 15
    Private iGyActivoCuentaContableRetencionISR As Integer = 16
    Private iGyActivoCuentaContableIEPS As Integer = 17
    Private iGyActivoNombreEmisor As Integer = 18
    Private iGyActivoRFCEmisor As Integer = 19
#End Region

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

#Region "Columnas grid facturas relacionadas"
    Private iGyIdCentroCostosDetalleVentas As Integer = 1
    Private iGyCodigoCliente As Integer = 2
    Private iGyNombreCliente As Integer = 3
    Private iGyFolioVenta As Integer = 4
    Private iGyFechaVenta As Integer = 5
    Private iGyGasto As Integer = 6
#End Region

#Region "Opciones"
    Private Sub tsbNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbNuevo.Click
        Me.Inicializa()
        Me.Cambia_Estado(enumEstados.NUEVO)
        Me.TxtCodigoAlmacen.Focus()
        _Fecha = ""
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

    Private Sub tsbCancelar_Click(sender As Object, e As EventArgs) Handles tsbCancelar.Click
        If Me.CancelarCompra = True Then
            Me.Consultar()
        End If
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
            Me.txtSubTotal.Text = ""
            Me.txtIVA.Text = ""
            Me.txtRetencionIVA.Text = ""
            Me.txtPorciento.Text = ""
            Me.txtTotalCompra.Text = ""
        Else
            Me.gbCompras.Enabled = False
        End If
    End Sub

    Private Sub btnContinuar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContinuar.Click
        Dim oAlmacen As New Class_CatAlmacenes

        If txtLEN(Me.TxtCodigoAlmacen.Text) = False Then
            MsgBox("Asigne un almacén.", MsgBoxStyle.Exclamation, "Validación de almacén")
            Me.TxtCodigoAlmacen.Focus()
            Exit Sub
        End If

        oAlmacen.CODIGO_ALMACEN = Me.TxtCodigoAlmacen.Text

        If oAlmacen.Consultar() = False Then
            MsgBox("El código de almacén no existe.", MsgBoxStyle.Exclamation, "Validación de almacén")
            Me.TxtCodigoAlmacen.Focus()
            Exit Sub
        End If

        If oAlmacen.ESTATUS = "B" Then
            MsgBox("El almacén " & Me.TxtCodigoAlmacen.Text & " está dado de BAJA.", MsgBoxStyle.Exclamation, "Validación de almacén")
            Exit Sub
        End If

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
            Me.txtSubTotal.Text = Me.GridCompras.Cell(Renglon, Me.iGySubtotal).Text()
            Me.txtIVA.Text = Me.GridCompras.Cell(Renglon, Me.iGyIVA).Text()
            Me.txtPorciento.Text = Me.GridCompras.Cell(Renglon, Me.iGyPorcentaje).Text
            Me.txtRetencionIVA.Text = Me.GridCompras.Cell(Renglon, Me.iGyRetencion).Text()
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
        If Me.ValidaVentas = True Then 'Esta validación no se llama desde GrabarVentasRelacionadas, porque este grabar se manda también desde el GestionaGrabar y no queremos que ya que grabe el gasto pregunte sobre las ventas.
            If Me.GrabarVentasRelacionadas() = True Then
                MsgBox("Detalle de venta grabado correctamente.", MsgBoxStyle.Information, Me.Name)
                Me.Consultar()
            End If
        End If
    End Sub

    'Private Sub tsbAgregarXML_Click(sender As Object, e As EventArgs) Handles tsbAgregarXML.Click
    '    Me.AgregarXML()
    'End Sub

    'Private Sub tsbAgregarPDF_Click(sender As Object, e As EventArgs) Handles tsbAgregarPDF.Click
    '    Me.AgregarPDF()
    'End Sub
#End Region

#Region "Eventos"
    Private Sub Frm_CXP_Revision_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If Me.Estado = enumEstados.NUEVO And Me.TxtCodigoProveedor.Enabled = True Then
            Me.TxtCodigoAlmacen.Focus()
        End If
    End Sub

    Private Sub Frm_CXP_Revision_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.DesplegarTipoGasto()
        Me.DesplegarTemporadas()
        Me.cboTipoGasto.Visible = False
        Me.Inicializa()
        Me.Cambia_Estado(enumEstados.NUEVO)

        If Empresa_Sistema.ES_ACUICOLA = False Then
            Me.lblDisplayTemporada.Visible = False
            Me.cboTemporada.Visible = False
        End If
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

    Private Sub TxtCodigoAlmacen_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCodigoAlmacen.KeyDown
        Dim oAlmacen As New Class_CatAlmacenes
        Try
            Select Case e.KeyCode
                Case Keys.F6
Buscar:
                    Me.TxtCodigoAlmacen.Text = oAlmacen.BusquedaVisual_PorDescripcionSoloActivos()

                    oAlmacen = New Class_CatAlmacenes(Me.TxtCodigoAlmacen.Text)
                    Me.LblNombreAlmacen.Text = oAlmacen.NOMBRE_ALMACEN

                Case Keys.Enter
                    If txtLEN(Me.TxtCodigoAlmacen.Text) = False Then
                        Me.LblNombreAlmacen.Text = ""
                        GoTo Buscar : Return
                    Else
                        oAlmacen.CODIGO_ALMACEN = Me.TxtCodigoAlmacen.Text

                        If oAlmacen.Consultar() = False Then
                            GoTo Buscar : Return
                        ElseIf oAlmacen.ESTATUS = "B" Then
                            MsgBox("El almacén " & Me.TxtCodigoAlmacen.Text & " está dado de BAJA.", MsgBoxStyle.Exclamation, Me.Text)
                            GoTo Buscar : Return
                        End If

                        Me.LblNombreAlmacen.Text = oAlmacen.NOMBRE_ALMACEN
                    End If

                    txtTAB(e)
            End Select

        Catch ex As Exception
            HandleError(Me.Name, "TxtCodigoAlmacen_KeyDown", ex)
        End Try
    End Sub

    Private Sub TxtCodigoArticulo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodigoArticulo.KeyDown
        Dim oArticulos As New Class_CatArticulos

        Select Case e.KeyCode
            Case Keys.F6
                oArticulos = New Class_CatArticulos
                Dim sArticulo As String = oArticulos.BusquedaVisual_PorDescripcion
                If sArticulo.Length > 0 Then
                    Me.TxtCodigoArticulo.Text = sArticulo
                    Me.lblNombreArticulo.Text = oArticulos.BuscarNombreArticulo(sArticulo)
                End If
            Case Keys.Enter
                Me.lblNombreArticulo.Text = oArticulos.BuscarNombreArticulo(Me.TxtCodigoArticulo.Text)
                If txtLEN(Me.lblNombreArticulo.Text) = False Then
                    lblNombreArticulo.Text = ""
                    txtTAB(e)
                    Exit Sub
                End If

            Case Keys.Escape
        End Select

        oArticulos = Nothing
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
        Try
            Me.GestionaGridCuentas(e)

            Dim iRenglon As Integer = Me.GridCuentas.Rows - 1

            'Esto es por si quedaron renglones nuevos tengan la frase de una vez de agregar xml y pdf
            If Me.GridCuentas.Cell(iRenglon, Me.iGyCtasXML).Text = "" Then
                Me.GridCuentas.Cell(iRenglon, Me.iGyCtasXML).Text = "Agregar"
                Me.GridCuentas.Cell(iRenglon, Me.iGyCtasPDF).Text = "Agregar"
            End If

            'If e.KeyCode = Keys.Return Then
            '    Me.GridCuentas.Cell(iRenglon, Me.iGyNombreConcepto).SetFocus()
            'End If
        Catch ex As Exception
            HandleError(Me.Name, "GridCuentas_KeyDown", ex)
        End Try
    End Sub

    Private Sub GridCompras_Click(ByVal Sender As Object, ByVal e As System.EventArgs) Handles GridCompras.Click
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

    Private Sub GridCompras_DoubleClick(ByVal Sender As Object, ByVal e As System.EventArgs) Handles GridCompras.DoubleClick
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
            HandleError(Me.Name, "GridCompras_DoubleClick", ex)
        End Try
    End Sub

    Private Sub GridActivos_KeyDown(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridActivos.KeyDown
        Try
            Me.GestionaGridActivos(e)

            Dim iRenglon As Integer = Me.GridActivos.Rows - 1

            'Esto es por si quedaron renglones nuevos tengan la frase de una vez de agregar xml y pdf
            If Me.GridActivos.Cell(iRenglon, Me.iGyActivoXML).Text = "" Then
                Me.GridActivos.Cell(iRenglon, Me.iGyActivoXML).Text = "Agregar"
                Me.GridActivos.Cell(iRenglon, Me.iGyActivoPDF).Text = "Agregar"
            End If
        Catch ex As Exception
            HandleError(Me.Name, "GridActivos_KeyDown", ex)
        End Try
    End Sub

    Private Sub txtTipoCambio_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTipoCambio.KeyDown
        If e.KeyCode = Keys.Return Then
            If valorNumerico(Me.txtTipoCambio.Text) < 0 Or valorNumerico(Me.txtTipoCambio.Text) > 30 Then
                MsgBox("Tipo de cambio incorrecto", MsgBoxStyle.Exclamation, "Validación de tipo de cambio")
                Me.txtTipoCambio.Focus()
                Exit Sub
            Else
                Me.CalculaImporteDolares()
            End If

            Me.txtSubTotal.Focus()
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

    Private Sub TxtSubTotal_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSubTotal.TextChanged
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

    Private Sub GridCuentas_ButtonClick(ByVal Sender As System.Object, ByVal e As FlexCell.Grid.ButtonClickEventArgs) Handles GridCuentas.ButtonClick
        Me.ClickBotonGridCuentas()
    End Sub

    Private Sub GridActivos_ButtonClick(ByVal Sender As System.Object, ByVal e As FlexCell.Grid.ButtonClickEventArgs) Handles GridActivos.ButtonClick
        Me.ClickBotonGridActivos()
    End Sub

    Private Sub ckbDolares_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ckbDolares.KeyDown
        If e.KeyCode = Keys.Return Then
            If Me.ckbDolares.Checked = True Then
                Me.txtTipoCambio.Focus()
            Else
                Me.txtSubTotal.Focus()
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
            Me.GridCuentas.Cell(1, Me.iGyCtasNombreCentroCosto).SetFocus()
        End If
    End Sub

    Private Sub TxtSubTotal_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSubTotal.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If valorNumerico(Me.txtSubTotal.Text) > 0 Then
                    Me.txtSubTotal.Text = FormatImporteContable(CDbl(Me.txtSubTotal.Text))
                    Me.TotalizaGridCentrosCostosyActivos()
                End If
        End Select
    End Sub

    Private Sub TxtRetencionIVA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRetencionIVA.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If valorNumerico(Me.txtRetencionIVA.Text) > 0 Then
                    Me.txtRetencionIVA.Text = FormatImporteContable(CDbl(Me.txtRetencionIVA.Text))
                Else
                    Me.txtRetencionIVA.Text = FormatImporteContable(0)
                End If

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

    Private Sub TxtIVA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtIVA.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If valorNumerico(Me.txtIVA.Text) > 0 Then
                    Me.txtIVA.Text = FormatImporteContable(CDbl(Me.txtIVA.Text))
                    Me.txtPorciento.Text = "16"
                    Me.TotalizaGridCentrosCostosyActivos()
                    Me.txtPorciento.Focus()
                Else
                    Me.txtIVA.Text = FormatImporteContable(0)
                    Me.TotalizaGridCentrosCostosyActivos()
                    Me.txtPorciento.Text = "0"
                    Me.txtRetencionIVA.Focus()
                End If
        End Select
    End Sub

    Private Sub txtPorciento_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPorciento.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If valorNumerico(Me.txtPorciento.Text) > 0 Then
                    Me.txtPorciento.Text = CDbl(Me.txtPorciento.Text).ToString
                    Me.TotalizaGridCentrosCostosyActivos()
                End If
                Me.txtRetencionIVA.Focus()
        End Select
    End Sub

    Private Sub txtTotalCompra_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTotalCompra.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                Me.TotalizaGridCentrosCostosyActivos()
                Me.tsbGrabar.Select()
        End Select
    End Sub


#End Region

#Region "Eventos Genericos"
    Private Sub txt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodigoProveedor.KeyDown, txtFolioProveedor.KeyDown, DtpFechaFacturaProveedor.KeyDown,
        txtSubTotal.KeyDown, txtTotalCompra.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtNumerosEnterosKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigoAlmacen.KeyPress
        txtSoloNumerosEnteros(e)
        txtNoBeep(e)
    End Sub

    Private Sub txtNumerosDecimalKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRetencionIVA.KeyPress, txtSubTotal.KeyPress, txtIVA.KeyPress, txtTotalCompra.KeyPress, txtPorciento.KeyPress,
        txtTipoCambio.KeyPress, txtRetencionISR.KeyPress
        Dim txt As TextBox = CType(sender, TextBox)
        txtSoloNumerosDecimales(e, txt.Text)
        txtNoBeep(e)
    End Sub

    Private Sub txtTextoKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtConcepto.KeyPress, TxtCodigoProveedor.KeyPress, txtEmbarque.KeyPress, txtFolioProveedor.KeyPress,
        DtpFechaFacturaProveedor.KeyPress, dtpFechaVencimiento.KeyPress, ckbDolares.KeyPress, TxtCodigoAlmacen.KeyPress
        txtNoBeep(e)
    End Sub
#End Region

#Region "Métodos y procedimientos"
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

    Private Sub DesplegarTemporadas()
        Dim oTemporada As New Class_NominaTemporada
        Try
            With Me.cboTemporada
                .DisplayMember = "NOMBRE_TEMPORADA"
                .ValueMember = "ID_NOMINA_TEMPORADA"
                Dim dView As New Data.DataView(oTemporada.ObtenerTemporadas)
                dView.Sort = "NOMBRE_TEMPORADA"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedValue = Plaza.oSisPlazaNomina.NOMINA_ID_NOMINA_TEMPORADA_ACTIVA
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarTemporadas", ex)
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
            Me.TxtCodigoAlmacen.Text = ""
            Me.LblNombreAlmacen.Text = ""
            Me.TxtCodigoArticulo.Text = ""
            Me.lblNombreArticulo.Text = ""

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
            Me.txtSubTotal.Text = "0"
            Me.txtIVA.Text = "0"
            Me.txtRetencionIVA.Text = "0"
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

    Private Sub InicializaGridCuentas()
        Try
            Me.GridCuentas.DataSource = Nothing
            FG_Grid_Limpiar(Me.GridCuentas)

            'Creamos el Grid
            Me.GridCuentas.Rows = 2
            Me.GridCuentas.Cols = 26
            Me.GridCuentas.DisplayRowNumber = True

            Me.GridCuentas.Cell(1, Me.iGyCtasXML).Text = "Agregar"
            Me.GridCuentas.Cell(1, Me.iGyCtasPDF).Text = "Agregar"

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
            Me.GridActivos.Cols = 20
            Me.GridActivos.DisplayRowNumber = True

            Me.GridActivos.Cell(1, Me.iGyActivoXML).Text = "Agregar"
            Me.GridActivos.Cell(1, Me.iGyActivoPDF).Text = "Agregar"

            Me.FormateaGridActivos()
        Catch ex As Exception
            HandleError(Me.Name, "InicializaGridActivos", ex)
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

    Private Sub FormateaGridCuentas()
        Try
            With Me.GridCuentas
                .AutoRedraw = False

                .DisplayFocusRect = False
                '.DisplayDateTimeMask = True
                '.ExtendLastCol = True
                .DrawMode = FlexCell.DrawModeEnum.OwnerDraw
                .BorderStyle = FlexCell.BorderStyleEnum.FixedSingle
                .FixedRowColStyle = FlexCell.FixedRowColStyleEnum.Flat

                .Column(Me.iGyCtasTipo).Visible = False
                .Column(Me.iGyCtasCodigoCentroCosto).Visible = False
                .Column(Me.iGyCtasNombreCentroCosto).Width = 190
                .Column(Me.iGyCtasCodigoCategoria).Visible = False
                .Column(Me.iGyCtasNombreCategoria).Width = 190
                .Column(Me.iGyCtasCodigoConcepto).Visible = False
                .Column(Me.iGyCtasNombreConcepto).Width = 190
                .Column(Me.iGyCtasImporte).Width = 80
                .Column(Me.iGyCtasIVA).Width = 70
                .Column(Me.iGyCtasRetencionIVA).Width = 60
                .Column(Me.iGyCtasRetencionISR).Width = 60
                .Column(Me.iGyCtasIEPS).Width = 60
                .Column(Me.iGyCtasTotal).Width = 80
                .Column(Me.iGyCuentaContable).Width = 100
                .Column(Me.iGyCtasUUID).Width = 60
                '.Column(Me.iGyCtasNombrePDF).Width = 30
                .Column(Me.iGyCtasXML).Width = 60
                .Column(Me.iGyCtasPDF).Width = 60
                .Column(Me.iGyCtasRutaXML).Visible = False
                .Column(Me.iGyCtasRutaPDF).Visible = False
                .Column(Me.iGyCtasIDCentroCostoDetalle).Visible = False
                .Column(Me.iGyCtasCuentaContableRetencionIVA).Width = 60
                .Column(Me.iGyCtasCuentaContableRetencionISR).Width = 60
                .Column(Me.iGyCtasCuentaContableIEPS).Width = 60
                .Column(Me.iGyCtasNombreEmisor).Width = 130
                .Column(Me.iGyCtasRFCEmisor).Width = 100

                .Cell(0, Me.iGyCtasCodigoCentroCosto).Text = "CCos"
                .Cell(0, Me.iGyCtasNombreCentroCosto).Text = "C.costo"
                .Cell(0, Me.iGyCtasCodigoCategoria).Text = "CCat"
                .Cell(0, Me.iGyCtasNombreCategoria).Text = "Categoria"
                .Cell(0, Me.iGyCtasCodigoConcepto).Text = "CCon"
                .Cell(0, Me.iGyCtasNombreConcepto).Text = "Concepto"
                .Cell(0, Me.iGyCtasImporte).Text = "SubtotalMXN"
                .Cell(0, Me.iGyCtasIVA).Text = "IVA MXN"
                .Cell(0, Me.iGyCtasRetencionIVA).Text = "IVARetMXN"
                .Cell(0, Me.iGyCtasRetencionISR).Text = "ISRRetMXN"
                .Cell(0, Me.iGyCtasIEPS).Text = "IEPS MXN"
                .Cell(0, Me.iGyCtasTotal).Text = "Total MXN"
                .Cell(0, Me.iGyCuentaContable).Text = "Cuenta contable"
                .Cell(0, Me.iGyCtasUUID).Text = "UUID"
                '.Cell(0, Me.iGyCtasNombrePDF).Text = "NombrePDF"
                .Cell(0, Me.iGyCtasXML).Text = "XML"
                .Cell(0, Me.iGyCtasPDF).Text = "PDF"
                .Cell(0, Me.iGyCtasRutaXML).Text = "RutaXML"
                .Cell(0, Me.iGyCtasRutaXML).Text = "RutaPDF"
                .Cell(0, Me.iGyCtasIDCentroCostoDetalle).Text = "IDCentroCostoDetalle"
                .Cell(0, Me.iGyCtasCuentaContableRetencionIVA).Text = "CtaIVARet"
                .Cell(0, Me.iGyCtasCuentaContableRetencionISR).Text = "CtaISRRet"
                .Cell(0, Me.iGyCtasCuentaContableIEPS).Text = "CtaIEPS"
                .Cell(0, Me.iGyCtasNombreEmisor).Text = "Nombre Emisor"
                .Cell(0, Me.iGyCtasRFCEmisor).Text = "RFC Emisor"

                .Column(Me.iGyCtasImporte).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
                .Column(Me.iGyCtasImporte).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyCtasImporte).DecimalLength = 2
                .Column(Me.iGyCtasImporte).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGyCtasIVA).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
                .Column(Me.iGyCtasIVA).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyCtasIVA).DecimalLength = 2
                .Column(Me.iGyCtasIVA).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGyCtasRetencionIVA).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
                .Column(Me.iGyCtasRetencionIVA).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyCtasRetencionIVA).DecimalLength = 2
                .Column(Me.iGyCtasRetencionIVA).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGyCtasRetencionISR).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
                .Column(Me.iGyCtasRetencionISR).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyCtasRetencionISR).DecimalLength = 2
                .Column(Me.iGyCtasRetencionISR).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGyCtasIEPS).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
                .Column(Me.iGyCtasIEPS).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyCtasIEPS).DecimalLength = 2
                .Column(Me.iGyCtasIEPS).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGyCtasTotal).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
                .Column(Me.iGyCtasTotal).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyCtasTotal).DecimalLength = 2
                .Column(Me.iGyCtasTotal).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGyCtasImporte).Locked = False 'Se habilita el importe
                .Column(Me.iGyCuentaContable).Locked = True 'Se bloquea la cuenta

                .Column(Me.iGyCtasXML).CellType = FlexCell.CellTypeEnum.Button
                .Column(Me.iGyCtasPDF).CellType = FlexCell.CellTypeEnum.Button
            End With

        Catch ex As Exception
            HandleError(Me.Name, "FormateaGridCuentas", ex)
        Finally
            Me.GridCuentas.AutoRedraw = True
            Me.GridCuentas.Refresh()
        End Try
    End Sub

    Private Sub FormateaGridActivos()
        Try
            With Me.GridActivos
                .AutoRedraw = False

                .DisplayFocusRect = False
                '.DisplayDateTimeMask = True
                '.ExtendLastCol = True
                .DrawMode = FlexCell.DrawModeEnum.OwnerDraw
                .BorderStyle = FlexCell.BorderStyleEnum.FixedSingle
                .FixedRowColStyle = FlexCell.FixedRowColStyleEnum.Flat

                .Column(Me.iGyActivoCuentaContable).Width = 100
                .Column(Me.iGyActivoNombreCuenta).Width = 400
                .Column(Me.iGyActivoImporte).Width = 80
                .Column(Me.iGyActivoIVA).Width = 50
                .Column(Me.iGyActivoRetencionIVA).Width = 60
                .Column(Me.iGyActivoRetencionISR).Width = 60
                .Column(Me.iGyActivoIEPS).Width = 60
                .Column(Me.iGyActivoTotal).Width = 80
                .Column(Me.iGyActivoUUID).Width = 60
                .Column(Me.iGyActivoRutaXML).Visible = False
                .Column(Me.iGyActivoRutaPDF).Visible = False
                .Column(Me.iGyActivoIDGastoDetalle).Visible = False
                .Column(Me.iGyActivoCuentaContableRetencionIVA).Width = 60
                .Column(Me.iGyActivoCuentaContableRetencionISR).Width = 60
                .Column(Me.iGyActivoCuentaContableIEPS).Width = 60
                .Column(Me.iGyActivoNombreEmisor).Width = 130
                .Column(Me.iGyActivoRFCEmisor).Width = 100

                .Cell(0, Me.iGyActivoCuentaContable).Text = "Cuenta contable"
                .Cell(0, Me.iGyActivoNombreCuenta).Text = "Nombre cuenta"
                .Cell(0, Me.iGyActivoImporte).Text = "SubtotalMXN"
                .Cell(0, Me.iGyActivoIVA).Text = "IVA MXN"
                .Cell(0, Me.iGyActivoRetencionIVA).Text = "IVARetMXN"
                .Cell(0, Me.iGyActivoRetencionISR).Text = "ISRRetMXN"
                .Cell(0, Me.iGyActivoIEPS).Text = "IEPS MXN"
                .Cell(0, Me.iGyActivoTotal).Text = "Total MXN"
                .Cell(0, Me.iGyActivoUUID).Text = "UUID"
                '.Cell(0, Me.iGyActivoNombrePDF).Text = "NombrePDF"
                .Cell(0, Me.iGyActivoXML).Text = "XML"
                .Cell(0, Me.iGyActivoPDF).Text = "PDF"
                .Cell(0, Me.iGyActivoRutaXML).Text = "RutaXML"
                .Cell(0, Me.iGyActivoRutaPDF).Text = "RutaPDF"
                .Cell(0, Me.iGyActivoIDGastoDetalle).Text = "IDGastoDetalle"
                .Cell(0, Me.iGyActivoCuentaContableRetencionIVA).Text = "CtaIVARet"
                .Cell(0, Me.iGyActivoCuentaContableRetencionISR).Text = "CtaISRRet"
                .Cell(0, Me.iGyActivoCuentaContableIEPS).Text = "CtaIEPS"
                .Cell(0, Me.iGyActivoNombreEmisor).Text = "Nombre Emisor"
                .Cell(0, Me.iGyActivoRFCEmisor).Text = "RFC Emisor"

                .Column(Me.iGyActivoImporte).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
                .Column(Me.iGyActivoImporte).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyActivoImporte).DecimalLength = 2
                .Column(Me.iGyActivoImporte).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGyActivoIVA).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
                .Column(Me.iGyActivoIVA).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyActivoIVA).DecimalLength = 2
                .Column(Me.iGyActivoIVA).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGyActivoRetencionIVA).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
                .Column(Me.iGyActivoRetencionIVA).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyActivoRetencionIVA).DecimalLength = 2
                .Column(Me.iGyActivoRetencionIVA).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGyActivoRetencionISR).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
                .Column(Me.iGyActivoRetencionISR).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyActivoRetencionISR).DecimalLength = 2
                .Column(Me.iGyActivoRetencionISR).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGyActivoIEPS).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
                .Column(Me.iGyActivoIEPS).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyActivoIEPS).DecimalLength = 2
                .Column(Me.iGyActivoIEPS).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGyActivoTotal).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
                .Column(Me.iGyActivoTotal).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyActivoTotal).DecimalLength = 2
                .Column(Me.iGyActivoTotal).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGyActivoImporte).Locked = False 'Se habilita 
                .Column(Me.iGyActivoNombreCuenta).Locked = True 'Se bloquea 

                .Column(Me.iGyActivoXML).CellType = FlexCell.CellTypeEnum.Button
                .Column(Me.iGyActivoPDF).CellType = FlexCell.CellTypeEnum.Button
            End With
        Catch ex As Exception
            HandleError(Me.Name, "FormateaGridActivos", ex)
        Finally
            Me.GridActivos.AutoRedraw = True
            Me.GridActivos.Refresh()
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

            Me.tsbAgregarXML.Visible = False
            Me.tsbAgregarPDF.Visible = False

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
                    Me.TxtCodigoAlmacen.Enabled = True
                    Me.TxtCodigoProveedor.Enabled = True
                    Me.cboTemporada.Enabled = True
                    Me.TxtCodigoArticulo.Enabled = True
                    Me.lblEstatus.Text = "NUEVO"

                    Me.tsslElaboro.Visible = False : Me.tsslElaboro.Text = ""
                    Me.tsslCancelo.Visible = False : Me.tsslCancelo.Text = ""

                Case enumEstados.CONSULTA
                    Me.tsbGrabar.Enabled = False

                    Me.gbProveedor.Enabled = True
                    Me.txtFolioCompra.Enabled = False
                    Me.TxtCodigoAlmacen.Enabled = False
                    Me.TxtCodigoProveedor.Enabled = False
                    Me.cboTipoGasto.Enabled = False
                    Me.TxtCodigoArticulo.Enabled = False

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
                    Me.cboTemporada.Enabled = False
                    Me.TxtCodigoArticulo.Enabled = False

                    'Me.GridCuentas.Locked = False
                    'Me.GridCuentas.Column(Me.iGyCtasNombreCentroCosto).Locked = True

                    Me.tsslElaboro.Visible = True : Me.tsslElaboro.Text = "Elaboró : " + Me.oCompras.NOMBRE_USUARIO_GRABO.ToString + " el " + Format(Me.DtpFechaFacturaProveedor.Value, "dd/MMM/yy").ToUpper

                    If Me.oCompras.ESTATUS = "C" Then
                        Me.tsslCancelo.Visible = True : Me.tsslCancelo.Text = "Canceló : " + Me.oCompras.NOMBRE_USUARIO_CANCELO.ToString + " el " + Format(Me.oCompras.FECHA_CANCELACION, "dd/MMM/yy").ToUpper
                        Me.tsbCancelar.Enabled = False
                    Else
                        Me.tsslCancelo.Visible = False : Me.tsslCancelo.Text = ""
                        Me.tsbCancelar.Enabled = True
                    End If

                    'Me.tsbAgregarXML.Visible = True
                    'Me.tsbAgregarPDF.Visible = True

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
                    Me.txtSubTotal.Enabled = False
                    Me.txtIVA.Enabled = False
                    Me.txtRetencionIVA.Enabled = False
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
                    Me.txtSubTotal.Enabled = False
                    Me.txtIVA.Enabled = False
                    Me.txtRetencionIVA.Enabled = False
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

                        Me.txtFolioProveedor.Enabled = False
                        'Me.GridCuentas.Locked = True
                        'Me.GridActivos.Locked = True

                        'Ahora se permite en la consulta agregar xml/pdf de doctos ya grabados por eso bloqueamos las demás no editables en ambos grids.
                        Me.GridCuentas.Locked = False
                        Me.GridActivos.Locked = False
                        For i = 1 To Me.GridCuentas.Cols - 1
                            Me.GridCuentas.Column(i).Locked = True
                        Next
                        For i = 1 To Me.GridActivos.Cols - 1
                            Me.GridActivos.Column(i).Locked = True
                        Next
                        Me.GridCuentas.Column(Me.iGyCtasXML).Locked = False
                        Me.GridCuentas.Column(Me.iGyCtasPDF).Locked = False
                        Me.GridActivos.Column(Me.iGyActivoXML).Locked = False
                        Me.GridActivos.Column(Me.iGyActivoPDF).Locked = False
                    Else
                        Me.tsbGrabar.Enabled = True

                        Me.txtFolioProveedor.Enabled = True
                        Me.GridCuentas.Locked = False
                        Me.GridActivos.Locked = False
                    End If

                    Me.gbProveedor.Enabled = True 'False
                    Me.gbCompraProveedor.Enabled = True
                    Me.gbCompras.Enabled = True
                    Me.txtFolioCompra.Enabled = False

                    Me.txtEmbarque.Enabled = False
                    Me.txtFolioProveedor.Focus()
                    Me.GridCuentas.Enabled = True
                    Me.GridActivos.Enabled = True

                    'Me.txtCuenta.Enabled = True
                    Me.TxtConcepto.Enabled = True
                    Me.txtSubTotal.Enabled = True
                    Me.txtIVA.Enabled = True
                    Me.txtRetencionIVA.Enabled = True
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
                    Me.cboTemporada.Enabled = True

            End Select
        Catch ex As Exception
            HandleError(Me.Name, "Cambia_Estado", ex)
        End Try
    End Sub

    Private Function CargaComprasConSaldo() As Boolean
        Dim bResultado As Boolean = False
        Dim dTabla As DataTable
        Try
            dTabla = oCompras.CargaComprashechasProveedor(Me.TxtCodigoProveedor.Text, CInt(Me.cboTipoGasto.SelectedValue.ToString), Me.TxtCodigoAlmacen.Text, Me.ckbSaldos.Checked)

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
        Try
            Me.txtSaldo.Text = FormatImporteContable(FG_Grid_SumaCol(Me.GridCompras, CShort(Me.iGySaldo)))
            Me.txtTotal.Text = FormatImporteContable(FG_Grid_SumaCol(Me.GridCompras, CShort(Me.iGyTotal)))
        Catch ex As Exception
            HandleError(Me.Name, "Totales", ex)
        End Try
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

    Private Sub GestionaGridCuentas(ByVal e As System.Windows.Forms.KeyEventArgs)
        Const sProcedure As String = "GestionaGridCuentas"

        Dim Columna As Integer, Renglon As Integer
        Dim StrCod As String = "", oCuenta As Class_CatCuentas, sCuentaContable As String = ""
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

                        Case Me.iGyCtasNombreCentroCosto
                            If txtLEN(Me.GridCuentas.Cell(Renglon, Columna).Text) = False Then
                                GoTo busca_centro_costo
                                Return
                            End If

                            ''oCentroCosto = New Class_CatCentroCostos(CInt(Me.GridCuentas.Cell(Renglon, Me.iGyCodigoCentroCosto).Text))
                            sTipo = Me.GridCuentas.Cell(Renglon, Me.iGyCtasTipo).Text
                            sCodigo = Me.GridCuentas.Cell(Renglon, Me.iGyCtasCodigoCentroCosto).Text
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

                        Case Me.iGyCtasNombreCategoria
                            If txtLEN(Me.GridCuentas.Cell(Renglon, Columna).Text) = False Then
                                GoTo busca_categoria
                                Return
                            End If

                            oCategoria = New Class_CatCategorias(Me.GridCuentas.Cell(Renglon, Me.iGyCtasCodigoCategoria).Text)
                            If oCategoria.Existe = True Then
                                Me.GridCuentas.Cell(Renglon, Me.iGyCtasCodigoCategoria).Text = oCategoria.CODIGO_CATEGORIA
                                Me.GridCuentas.Cell(Renglon, Me.iGyCtasNombreCategoria).Text = oCategoria.NOMBRE_CATEGORIA
                                Me.GridCuentas.Cell(Renglon, Me.iGyCuentaContable).Text = oCategoria.CODIGO_TIPO_CATEGORIA
                            Else
                                Me.GridCuentas.Cell(Renglon, Me.iGyCtasCodigoCategoria).Text = ""
                                Me.GridCuentas.Cell(Renglon, Me.iGyCtasNombreCategoria).Text = ""
                                Me.GridCuentas.Cell(Renglon, Me.iGyCuentaContable).Text = ""
                                GoTo busca_categoria
                                Return
                            End If

                        Case Me.iGyCtasNombreConcepto
                            If txtLEN(Me.GridCuentas.Cell(Renglon, Columna).Text) = False Then
                                GoTo busca_concepto
                                Return
                            End If

                            oConcepto = New Class_CatConceptos(Me.GridCuentas.Cell(Renglon, Me.iGyCtasCodigoConcepto).Text)
                            If oConcepto.Existe = True Then
                                Me.GridCuentas.Cell(Renglon, Me.iGyCtasCodigoConcepto).Text = oConcepto.Codigo_Concepto
                                Me.GridCuentas.Cell(Renglon, Me.iGyCtasNombreConcepto).Text = oConcepto.Nombre_Concepto
                            Else
                                Me.GridCuentas.Cell(Renglon, Me.iGyCtasCodigoConcepto).Text = ""
                                Me.GridCuentas.Cell(Renglon, Me.iGyCtasNombreConcepto).Text = ""
                                GoTo busca_concepto
                                Return
                            End If

                        Case Me.iGyCtasImporte
                            If valorNumerico(Me.GridCuentas.Cell(Renglon, Me.iGyCtasImporte).Text) = 0 Then
                                e.Handled = True 'Con esto el importe si es 0 no se brinca a la siguiente columna, se queda el foco en el importe.
                                Return
                            End If
                            'Me.SaltoColumnas(Renglon, Columna, Keys.KeyCode, sTipo)

                        Case Me.iGyCtasIVA
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

                        Case Me.iGyCtasNombreCentroCosto
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

                        Case Me.iGyCtasNombreCategoria
busca_categoria:
                            oCategoria = New Class_CatCategorias
                            sCodigo = oCategoria.BusquedaVisual_PorDescripcion

                            If txtLEN(sCodigo) = True Then
                                oCategoria = New Class_CatCategorias(sCodigo)
                                Me.GridCuentas.Cell(Renglon, Me.iGyCtasCodigoCategoria).Text = oCategoria.CODIGO_CATEGORIA.ToString
                                Me.GridCuentas.Cell(Renglon, Me.iGyCtasNombreCategoria).Text = oCategoria.NOMBRE_CATEGORIA
                                Me.GridCuentas.Cell(Renglon, Me.iGyCuentaContable).Text = oCategoria.CODIGO_TIPO_CATEGORIA
                                'Else
                                '    GoTo busca_categoria
                                '    Return
                            End If

                        Case Me.iGyCtasNombreConcepto
busca_concepto:
                            oConcepto = New Class_CatConceptos
                            sCodigo = oConcepto.BusquedaVisual_PorDescripcion

                            If txtLEN(sCodigo) = True Then
                                oConcepto = New Class_CatConceptos(sCodigo)
                                Me.GridCuentas.Cell(Renglon, Me.iGyCtasCodigoConcepto).Text = oConcepto.Codigo_Concepto.ToString
                                Me.GridCuentas.Cell(Renglon, Me.iGyCtasNombreConcepto).Text = oConcepto.Nombre_Concepto
                                'Else
                                '    GoTo busca_concepto
                                '    Return
                            End If

                        Case Me.iGyCtasCuentaContableRetencionIVA
                            oCuenta = New Class_CatCuentas()
                            sCuentaContable = oCuenta.BusquedaVisual_PorCodigoFiltrandoTipoOperacion()
                            If txtLEN(sCuentaContable) = True Then
                                oCuenta = New Class_CatCuentas(sCuentaContable)
                                Me.GridCuentas.Cell(Renglon, Me.iGyCtasCuentaContableRetencionIVA).Text = oCuenta.CUENTA_CONTABLE
                            End If
                            oCuenta = Nothing

                        Case Me.iGyCtasCuentaContableRetencionISR
                            oCuenta = New Class_CatCuentas()
                            sCuentaContable = oCuenta.BusquedaVisual_PorCodigoFiltrandoTipoOperacion()
                            If txtLEN(sCuentaContable) = True Then
                                oCuenta = New Class_CatCuentas(sCuentaContable)
                                Me.GridCuentas.Cell(Renglon, Me.iGyCtasCuentaContableRetencionISR).Text = oCuenta.CUENTA_CONTABLE
                            End If
                            oCuenta = Nothing

                        Case Me.iGyCtasCuentaContableIEPS
                            oCuenta = New Class_CatCuentas()
                            sCuentaContable = oCuenta.BusquedaVisual_PorCodigoFiltrandoTipoOperacion()
                            If txtLEN(sCuentaContable) = True Then
                                oCuenta = New Class_CatCuentas(sCuentaContable)
                                Me.GridCuentas.Cell(Renglon, Me.iGyCtasCuentaContableIEPS).Text = oCuenta.CUENTA_CONTABLE
                            End If
                            oCuenta = Nothing

                    End Select

                Case Keys.F7
                    Select Case Columna
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

                        Case Me.iGyCtasCuentaContableRetencionIVA
                            oCuenta = New Class_CatCuentas()
                            sCuentaContable = oCuenta.BusquedaVisual_PorNombreFiltrandoTipoOperacion()
                            If txtLEN(sCuentaContable) = True Then
                                oCuenta = New Class_CatCuentas(sCuentaContable)
                                Me.GridCuentas.Cell(Renglon, Me.iGyCtasCuentaContableRetencionIVA).Text = oCuenta.CUENTA_CONTABLE
                            End If
                            oCuenta = Nothing

                        Case Me.iGyCtasCuentaContableRetencionISR
                            oCuenta = New Class_CatCuentas()
                            sCuentaContable = oCuenta.BusquedaVisual_PorNombreFiltrandoTipoOperacion()
                            If txtLEN(sCuentaContable) = True Then
                                oCuenta = New Class_CatCuentas(sCuentaContable)
                                Me.GridCuentas.Cell(Renglon, Me.iGyCtasCuentaContableRetencionISR).Text = oCuenta.CUENTA_CONTABLE
                            End If
                            oCuenta = Nothing

                        Case Me.iGyCtasCuentaContableIEPS
                            oCuenta = New Class_CatCuentas()
                            sCuentaContable = oCuenta.BusquedaVisual_PorNombreFiltrandoTipoOperacion()
                            If txtLEN(sCuentaContable) = True Then
                                oCuenta = New Class_CatCuentas(sCuentaContable)
                                Me.GridCuentas.Cell(Renglon, Me.iGyCtasCuentaContableIEPS).Text = oCuenta.CUENTA_CONTABLE
                            End If
                            oCuenta = Nothing

                    End Select

                Case Keys.F8

                    If Renglon = 1 Then
                        For i = 1 To Me.GridCuentas.Cols - 1
                            Me.GridCuentas.Cell(Renglon, i).Text = ""
                        Next

                        Me.GridCuentas.Cell(Renglon, Me.iGyCtasXML).Text = "Agregar"
                        Me.GridCuentas.Cell(Renglon, Me.iGyCtasPDF).Text = "Agregar"
                    Else
                        Me.GridCuentas.Selection.DeleteByRow()
                    End If

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
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Sub GestionaGridActivos(ByVal e As System.Windows.Forms.KeyEventArgs)
        Const sProcedure As String = "GestionaGridActivos"

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

                                    'Antes sólo se permitian cuentas tipo 1(activos)
                                    'ElseIf sCuentaContable.StartsWith("1") = False Then
                                    '    .Cell(Renglon, Me.iGyActivoCuentaContable).Text = ""
                                    '    .Cell(Renglon, Me.iGyActivoNombreCuenta).Text = ""
                                    '    MsgBox("La cuenta contable del renglón : " & Renglon & " debe ser del rango de las miles(que empiezen con 1).", MsgBoxStyle.Exclamation, sProcedure)
                                    '    Return
                                End If

                                oCuenta = New Class_CatCuentas(sCuentaContable)
                                If oCuenta._Existe = False Then
                                    MsgBox("La cuenta contable que intenta buscar no existe, favor de intentar con otro código.", MsgBoxStyle.Exclamation, sProcedure)
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
                            Case Me.iGyActivoIVA
                                .Cell(Renglon + 1, 0).SetFocus()
                            Case Else
                                .Cell(Renglon, Columna).SetFocus()
                        End Select

                    Case Keys.F6
                        Select Case Columna
                            Case Me.iGyActivoCuentaContable
busca_cuenta_contable:
                                oCuenta = New Class_CatCuentas()
                                'Dim sCuenta As String = oCuenta.BusquedaVisual_PorCodigoConLike("1")'Antes sólo se permitian cuentas tipo 1(activos)
                                Dim sCuenta As String = oCuenta.BusquedaVisual_PorCodigoFiltrandoTipoOperacion()
                                If txtLEN(sCuenta) = True Then
                                    oCuenta = New Class_CatCuentas(sCuenta)
                                    .Cell(Renglon, Me.iGyActivoCuentaContable).Text = oCuenta.CUENTA_CONTABLE
                                    .Cell(Renglon, Me.iGyActivoNombreCuenta).Text = oCuenta.NOMBRE_CUENTA_NIVELES_COMPLETOS
                                End If
                                oCuenta = Nothing

                            Case Me.iGyActivoCuentaContableRetencionIVA
                                oCuenta = New Class_CatCuentas()
                                Dim sCuenta As String = oCuenta.BusquedaVisual_PorCodigoFiltrandoTipoOperacion()
                                If txtLEN(sCuenta) = True Then
                                    oCuenta = New Class_CatCuentas(sCuenta)
                                    .Cell(Renglon, Me.iGyActivoCuentaContableRetencionIVA).Text = oCuenta.CUENTA_CONTABLE
                                End If
                                oCuenta = Nothing

                            Case Me.iGyActivoCuentaContableRetencionISR
                                oCuenta = New Class_CatCuentas()
                                Dim sCuenta As String = oCuenta.BusquedaVisual_PorCodigoFiltrandoTipoOperacion()
                                If txtLEN(sCuenta) = True Then
                                    oCuenta = New Class_CatCuentas(sCuenta)
                                    .Cell(Renglon, Me.iGyActivoCuentaContableRetencionISR).Text = oCuenta.CUENTA_CONTABLE
                                End If
                                oCuenta = Nothing

                            Case Me.iGyActivoCuentaContableIEPS
                                oCuenta = New Class_CatCuentas()
                                Dim sCuenta As String = oCuenta.BusquedaVisual_PorCodigoFiltrandoTipoOperacion()
                                If txtLEN(sCuenta) = True Then
                                    oCuenta = New Class_CatCuentas(sCuenta)
                                    .Cell(Renglon, Me.iGyActivoCuentaContableIEPS).Text = oCuenta.CUENTA_CONTABLE
                                End If
                                oCuenta = Nothing

                        End Select

                    Case Keys.F7
                        Select Case Columna
                            Case Me.iGyActivoCuentaContable
                                oCuenta = New Class_CatCuentas()
                                'Dim sCuenta As String = oCuenta.BusquedaVisual_PorDescripcionConLike("1")'Antes sólo se permitian cuentas tipo 1(activos)
                                Dim sCuenta As String = oCuenta.BusquedaVisual_PorNombreFiltrandoTipoOperacion
                                If txtLEN(sCuenta) = True Then
                                    oCuenta = New Class_CatCuentas(sCuenta)
                                    .Cell(Renglon, Me.iGyActivoCuentaContable).Text = oCuenta.CUENTA_CONTABLE
                                    .Cell(Renglon, Me.iGyActivoNombreCuenta).Text = oCuenta.NOMBRE_CUENTA_NIVELES_COMPLETOS
                                End If
                                oCuenta = Nothing

                            Case Me.iGyActivoCuentaContableRetencionIVA
                                oCuenta = New Class_CatCuentas()
                                Dim sCuenta As String = oCuenta.BusquedaVisual_PorNombreFiltrandoTipoOperacion()
                                If txtLEN(sCuenta) = True Then
                                    oCuenta = New Class_CatCuentas(sCuenta)
                                    .Cell(Renglon, Me.iGyActivoCuentaContableRetencionIVA).Text = oCuenta.CUENTA_CONTABLE
                                End If
                                oCuenta = Nothing

                            Case Me.iGyActivoCuentaContableRetencionISR
                                oCuenta = New Class_CatCuentas()
                                Dim sCuenta As String = oCuenta.BusquedaVisual_PorNombreFiltrandoTipoOperacion()
                                If txtLEN(sCuenta) = True Then
                                    oCuenta = New Class_CatCuentas(sCuenta)
                                    .Cell(Renglon, Me.iGyActivoCuentaContableRetencionISR).Text = oCuenta.CUENTA_CONTABLE
                                End If
                                oCuenta = Nothing

                            Case Me.iGyActivoCuentaContableIEPS
                                oCuenta = New Class_CatCuentas()
                                Dim sCuenta As String = oCuenta.BusquedaVisual_PorNombreFiltrandoTipoOperacion()
                                If txtLEN(sCuenta) = True Then
                                    oCuenta = New Class_CatCuentas(sCuenta)
                                    .Cell(Renglon, Me.iGyActivoCuentaContableIEPS).Text = oCuenta.CUENTA_CONTABLE
                                End If
                                oCuenta = Nothing

                        End Select

                    Case Keys.F8
                        If Renglon = 1 Then
                            For i = 1 To .Cols - 1
                                .Cell(Renglon, i).Text = ""
                            Next

                            .Cell(Renglon, Me.iGyActivoXML).Text = "Agregar"
                            .Cell(Renglon, Me.iGyActivoPDF).Text = "Agregar"
                        Else
                            .Selection.DeleteByRow()
                        End If

                End Select

                Me.TotalizaGridCentrosCostosyActivos()

            Catch ex As Exception
                HandleError(Me.Name, sProcedure, ex)
            End Try

        End With
    End Sub

    Private Sub GestionaGridFacturasRelacionadas(ByVal e As System.Windows.Forms.KeyEventArgs)
        Const sProcedure As String = "GestionaGridFacturasRelacionadas"

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
                                    sCodigo = oVenta.BusquedaVisualFacturasCliente(.Cell(Renglon, Me.iGyCodigoCliente).Text)

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
            For i = 1 To Me.GridCuentas.Rows - 1
                Me.GridCuentas.Cell(i, Me.iGyCtasTotal).Text = RedondearD(
                    valorNumericoD(Me.GridCuentas.Cell(i, Me.iGyCtasImporte).Text) + valorNumericoD(Me.GridCuentas.Cell(i, Me.iGyCtasIVA).Text) -
                    valorNumericoD(Me.GridCuentas.Cell(i, Me.iGyCtasRetencionIVA).Text) - valorNumericoD(Me.GridCuentas.Cell(i, Me.iGyCtasRetencionISR).Text) + valorNumericoD(Me.GridCuentas.Cell(i, Me.iGyCtasIEPS).Text),
                    2).ToString
            Next

            For i = 1 To Me.GridActivos.Rows - 1
                Me.GridActivos.Cell(i, Me.iGyActivoTotal).Text = RedondearD(
                    valorNumericoD(Me.GridActivos.Cell(i, Me.iGyActivoImporte).Text) + valorNumericoD(Me.GridActivos.Cell(i, Me.iGyActivoIVA).Text) -
                    valorNumericoD(Me.GridActivos.Cell(i, Me.iGyActivoRetencionIVA).Text) - valorNumericoD(Me.GridActivos.Cell(i, Me.iGyActivoRetencionISR).Text) + valorNumericoD(Me.GridActivos.Cell(i, Me.iGyActivoIEPS).Text),
                    2).ToString
            Next

            Me.txtSubTotal.Text = FormatImporteContable(FG_Grid_SumaCol(Me.GridCuentas, CShort(Me.iGyCtasImporte)) + FG_Grid_SumaCol(Me.GridActivos, CShort(Me.iGyActivoImporte)))

            Me.txtIVA.Text = FormatImporteContable(FG_Grid_SumaCol(Me.GridCuentas, CShort(Me.iGyCtasIVA)) + FG_Grid_SumaCol(Me.GridActivos, CShort(Me.iGyActivoIVA)))

            Me.txtRetencionIVA.Text = FormatImporteContable(FG_Grid_SumaCol(Me.GridCuentas, CShort(Me.iGyCtasRetencionIVA)) + FG_Grid_SumaCol(Me.GridActivos, CShort(Me.iGyActivoRetencionIVA)))

            Me.txtRetencionISR.Text = FormatImporteContable(FG_Grid_SumaCol(Me.GridCuentas, CShort(Me.iGyCtasRetencionISR)) + FG_Grid_SumaCol(Me.GridActivos, CShort(Me.iGyActivoRetencionISR)))

            Me.txtIEPS.Text = FormatImporteContable(FG_Grid_SumaCol(Me.GridCuentas, CShort(Me.iGyCtasIEPS)) + FG_Grid_SumaCol(Me.GridActivos, CShort(Me.iGyActivoIEPS)))

            Me.txtTotalCompra.Text = FormatImporteContable(valorNumerico(Me.txtSubTotal.Text) + valorNumerico(Me.txtIVA.Text) - valorNumerico(Me.txtRetencionIVA.Text) - valorNumerico(Me.txtRetencionISR.Text) + valorNumerico(Me.txtIEPS.Text))

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
                Me.GridCuentas.Cell(Renglon, Me.iGyCtasTipo).Text = oCentroCosto.TIPO
                Me.GridCuentas.Cell(Renglon, Me.iGyCtasCodigoCentroCosto).Text = oCentroCosto.CODIGO
                Me.GridCuentas.Cell(Renglon, Me.iGyCtasNombreCentroCosto).Text = oCentroCosto.NOMBRE
                Select Case sTipo
                    Case "DEUDOR_DIVERSO"
                        Me.GridCuentas.Cell(Renglon, Me.iGyCtasCodigoCategoria).Text = ""
                        Me.GridCuentas.Cell(Renglon, Me.iGyCtasNombreCategoria).Text = "NO APLICA"
                        Me.GridCuentas.Cell(Renglon, Me.iGyCtasCodigoConcepto).Text = ""
                        Me.GridCuentas.Cell(Renglon, Me.iGyCtasNombreConcepto).Text = "NO APLICA"
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
        If Me.GridCuentas.Rows = Renglon + 1 And Me.GridCuentas.Cell(Renglon, Me.iGyCtasImporte).Locked = False Then
            Me.GridCuentas.Rows = Me.GridCuentas.Rows + 1
        End If

        Select Case Columna
            Case Me.iGyCtasImporte, Me.iGyCtasIVA
                Me.GridCuentas.Cell(Renglon + 1, Me.iGyCtasCodigoCentroCosto).SetFocus()
            Case Else
                Select Case sTipo
                    Case "DEUDOR_DIVERSO"
                        Select Case KeyCode
                            Case Keys.Return
                                Me.GridCuentas.Cell(Renglon, Me.iGyCtasNombreConcepto).SetFocus() 'Se pone una antes para quese vaya al importe, porque el enter por si mismo va forzar brincar otra vez
                            Case Keys.F6
                                Me.GridCuentas.Cell(Renglon, Me.iGyCtasImporte).SetFocus()
                        End Select
                    Case Else
                        If KeyCode = Keys.F6 Then
                            Select Case Columna
                                Case Me.iGyCtasNombreCentroCosto
                                    Columna = Me.iGyCtasNombreCategoria
                            End Select
                        End If
                        Me.GridCuentas.Cell(Renglon, Columna).SetFocus()
                End Select
        End Select
    End Sub

    Private Function GestionaGrabar() As Boolean
        Const sProcedure As String = "GestionaGrabar"
        Dim bResultado As Boolean = False
        Dim sCuentas As String = "", sListaActivos As String = ""
        Dim i As Integer
        Dim sProveedor As String = Me.TxtCodigoProveedor.Text

        If MsgBox("Deseas grabar el Gasto con el folio : " & Me.txtFolioCompra.Text & " ?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "Grabar") = MsgBoxResult.No Then
            Return False
        End If

        Me.TotalizaGridCentrosCostosyActivos()
        'Me.Totales()

        If Me.ValidarCompra = False Then
            Return False
        End If

        If Estado = enumEstados.SINORDENCOMPRA Then
            If Me.ValidaCuentasContables = False Then
                Return False
            End If
        End If

        Try
            Dim oAlmacen As New Class_CatAlmacenes(Me.TxtCodigoAlmacen.Text)

            If Estado = enumEstados.SINORDENCOMPRA Then
                With Me.oCompras
                    .FOLIO_COMPRA = Me.txtFolioCompra.Text
                    .CODIGO_DOCUMENTO = sCodigoTipoDocumento & Usuario.Codigo_Plaza.ToString
                    .CODIGO_ALMACEN = Me.TxtCodigoAlmacen.Text
                    .CODIGO_PLAZA = Plaza.CODIGO_PLAZA
                    '.FECHA = Me.DtpFecha.Value
                    .FECHA_FACTURA_PROVEEDOR = Me.DtpFechaFacturaProveedor.Value
                    .FOLIO_OC = ""
                    .FOLIO_PROVEEDOR = Me.txtFolioProveedor.Text
                    .CODIGO_PROVEEDOR = Me.TxtCodigoProveedor.Text
                    .PLAZO = 0
                    .FECHA_VENCIMIENTO = Me.dtpFechaVencimiento.Value
                    .SUBTOTAL = valorNumerico(Me.txtSubTotal.Text)
                    .IMPUESTO = valorNumerico(Me.txtIVA.Text)
                    .TOTAL = valorNumerico(Me.txtTotalCompra.Text)
                    .RETENCION_IVA = valorNumerico(Me.txtRetencionIVA.Text)
                    .RETENCION_ISR = valorNumerico(Me.txtRetencionISR.Text)
                    .IEPS_TOTAL_DESGLOSADO = valorNumerico(Me.txtIEPS.Text)
                    .IMPUESTO_PORCENTAJE = CDbl(Me.txtPorciento.Text)
                    .TIPO_DE_CAMBIO = valorNumerico(Me.txtTipoCambio.Text)
                    .CONCEPTO = Me.TxtConcepto.Text
                    .FOLIO_EMBARQUE = Me.txtEmbarque.Text
                    .FECHA_PROGRAMACION = Me.dtpFechaVencimiento.Value
                    .ID_NOMINA_TEMPORADA = CInt(Me.cboTemporada.SelectedValue)
                    .CODIGO_ARTICULO_GASTOS = Me.TxtCodigoArticulo.Text

                    For i = 1 To Me.GridCuentas.Rows - 1
                        If Me.GridCuentas.Cell(i, Me.iGyCuentaContable).Text <> "" And valorNumerico(Me.GridCuentas.Cell(i, Me.iGyCtasImporte).Text) > 0 Then
                            sCuentas = sCuentas & i & "," & Me.GridCuentas.Cell(i, Me.iGyCtasTipo).Text & "," &
                            Me.GridCuentas.Cell(i, Me.iGyCtasCodigoCentroCosto).Text & "," & Me.GridCuentas.Cell(i, Me.iGyCtasCodigoCategoria).Text & "," & Me.GridCuentas.Cell(i, Me.iGyCtasCodigoConcepto).Text & "," &
                            valorNumerico(Me.GridCuentas.Cell(i, Me.iGyCtasImporte).Text).ToString & "," & Me.GridCuentas.Cell(i, Me.iGyCuentaContable).Text & "," &
                            valorNumerico(Me.GridCuentas.Cell(i, Me.iGyCtasIVA).Text).ToString & "," & valorNumerico(Me.GridCuentas.Cell(i, Me.iGyCtasTotal).Text).ToString & "," & Me.GridCuentas.Cell(i, Me.iGyCtasUUID).Text & "," &
                            valorNumerico(Me.GridCuentas.Cell(i, Me.iGyCtasRetencionIVA).Text).ToString & "," & valorNumerico(Me.GridCuentas.Cell(i, Me.iGyCtasRetencionISR).Text).ToString & "," & valorNumerico(Me.GridCuentas.Cell(i, Me.iGyCtasIEPS).Text).ToString & "," &
                            Me.GridCuentas.Cell(i, Me.iGyCtasCuentaContableRetencionIVA).Text & "," & Me.GridCuentas.Cell(i, Me.iGyCtasCuentaContableRetencionISR).Text & "," & Me.GridCuentas.Cell(i, Me.iGyCtasCuentaContableIEPS).Text & "," &
                             Me.GridCuentas.Cell(i, Me.iGyCtasNombreEmisor).Text.Replace(",", ".") & "," & Me.GridCuentas.Cell(i, Me.iGyCtasRFCEmisor).Text & "|"
                        End If
                    Next i

                    For i = 1 To Me.GridActivos.Rows - 1
                        If Me.GridActivos.Cell(i, Me.iGyActivoCuentaContable).Text <> "" And valorNumerico(Me.GridActivos.Cell(i, Me.iGyActivoImporte).Text) > 0 Then
                            sListaActivos = sListaActivos & i & "," & Me.GridActivos.Cell(i, Me.iGyActivoCuentaContable).Text & "," & Me.GridActivos.Cell(i, Me.iGyActivoImporte).Text & "," &
                            valorNumerico(Me.GridActivos.Cell(i, Me.iGyActivoIVA).Text).ToString & "," & valorNumerico(Me.GridActivos.Cell(i, Me.iGyActivoTotal).Text).ToString & "," & Me.GridActivos.Cell(i, Me.iGyActivoUUID).Text & "," &
                            valorNumerico(Me.GridActivos.Cell(i, Me.iGyActivoRetencionIVA).Text).ToString & "," & valorNumerico(Me.GridActivos.Cell(i, Me.iGyActivoRetencionISR).Text).ToString & "," & valorNumerico(Me.GridActivos.Cell(i, Me.iGyActivoIEPS).Text).ToString & "," &
                            Me.GridActivos.Cell(i, Me.iGyActivoCuentaContableRetencionIVA).Text & "," & Me.GridActivos.Cell(i, Me.iGyActivoCuentaContableRetencionISR).Text & "," & Me.GridActivos.Cell(i, Me.iGyActivoCuentaContableIEPS).Text & "," &
                            Me.GridActivos.Cell(i, Me.iGyActivoNombreEmisor).Text.Replace(",", ".") & "," & Me.GridActivos.Cell(i, Me.iGyActivoRFCEmisor).Text & "|"
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
                        MsgBox("Falta introducir los centros de costos o activos.", MsgBoxStyle.Exclamation, sProcedure)
                        Return False
                    Else
                        If txtLEN(sCuentas) = True Then
                            sCuentas = sCuentas.Substring(0, sCuentas.Length - 1) 'Para quitarle el último pipe que sale sobrando.
                        End If
                        If txtLEN(sListaActivos) = True Then
                            sListaActivos = sListaActivos.Substring(0, sListaActivos.Length - 1) 'Para quitarle el último pipe que sale sobrando.
                        End If
                    End If

                    .ES_FISCAL = oAlmacen.ES_FISCAL

                    If .GrabaCompraGlobalSinOrden(sCuentas, sListaActivos) = False Then
                        MsgBox("Error al tratar de aplicar el movimiento de compras.", MsgBoxStyle.Exclamation, sProcedure)
                        Return False
                    End If
                    Me.txtFolioCompra.Text = .FOLIO_COMPRA

                    If valorNumerico(Me.lblTotalFacturasRelacionadas.Text) > 0 Then
                        If Me.GrabarVentasRelacionadas = False Then
                            MsgBox("Error al tratar de grabar facturas relacionadas.", MsgBoxStyle.Exclamation, sProcedure)
                            Return False
                        End If
                    End If

                    Dim oPoliza As New Class_Contabilidad_Poliza_Global(Me.txtFolioCompra.Text)

                    If oPoliza.Existe = True Then
                        Dim sUUID As String = "", sRutaXML As String = "", sRutaPDF As String = ""

                        For i = 1 To Me.GridCuentas.Rows - 1
                            sUUID = Me.GridCuentas.Cell(i, Me.iGyCtasUUID).Text
                            sRutaXML = Me.GridCuentas.Cell(i, Me.iGyCtasRutaXML).Text
                            sRutaPDF = Me.GridCuentas.Cell(i, Me.iGyCtasRutaPDF).Text

                            If txtLEN(sUUID) = False Then
                                Continue For
                            End If

                            If txtLEN(sRutaXML) = True Then
                                If oPoliza.TieneRelacionadoUUID(sUUID) = False Then 'Si la póliza no tiene relacionado todavia el uuid si se relaciona, si ya lo tiene no porque marcaria error(el xml ya existirá en el repositorio y relacionado).
                                    bResultado = oPoliza.AgregarXMLPDF(sRutaXML, sRutaPDF) 'sRutaPDF pudiera venir vacio y no grabará el pdf
                                End If
                            End If
                        Next

                        For i = 1 To Me.GridActivos.Rows - 1
                            sUUID = Me.GridActivos.Cell(i, Me.iGyActivoUUID).Text
                            sRutaXML = Me.GridActivos.Cell(i, Me.iGyActivoRutaXML).Text
                            sRutaPDF = Me.GridActivos.Cell(i, Me.iGyActivoRutaPDF).Text

                            If txtLEN(sUUID) = False Then
                                Continue For
                            End If

                            If txtLEN(sRutaXML) = True Then
                                If oPoliza.TieneRelacionadoUUID(sUUID) = False Then 'Si la póliza no tiene relacionado todavia el uuid si se relaciona, si ya lo tiene no porque marcaria error(el xml ya existirá en el repositorio y relacionado).
                                    bResultado = oPoliza.AgregarXMLPDF(sRutaXML, sRutaPDF) 'sRutaPDF pudiera venir vacio y no grabará el pdf
                                End If
                            End If
                        Next
                    End If

                    MsgBox("Movimiento de gasto grabado satisfactoriamente.", MsgBoxStyle.Information, sProcedure)

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

                MsgBox("Movimiento de compras se actualizó satisfactoriamente.", MsgBoxStyle.Information, sProcedure)
            End If

            Me.Inicializa()
            Me.TxtCodigoProveedor.Text = sProveedor

            bResultado = True

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    Private Function ValidaVentas() As Boolean
        Const sProcedure As String = "ValidaVentas"
        Dim bResultado As Boolean = False
        Try
            If valorNumerico(Me.lblTotalFacturasRelacionadas.Text) > 0 Then
                If valorNumerico(Me.lblTotalFacturasRelacionadas.Text) > valorNumerico(Me.txtTotalCompra.Text) Then
                    MsgBox("El total de las ventas es mayor que el del gasto.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If

                If valorNumerico(Me.lblTotalFacturasRelacionadas.Text) < valorNumerico(Me.txtTotalCompra.Text) Then
                    If MsgBox("El total de las ventas es menor que el del gasto, seguro desea continuar? ", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, sProcedure) = MsgBoxResult.No Then
                        Return False
                    End If
                End If
            End If

            bResultado = True
        Catch ex As Exception
            HandleError(Me.Name, "ValidaVentas", ex)
        End Try

        Return bResultado
    End Function

    Private Function GrabarVentasRelacionadas() As Boolean
        Const sProcedure As String = "GrabarVentasRelacionadas"
        Dim bResultado As Boolean = False
        Dim i As Integer
        Dim oDetalleVentas As New Class_Centros_Costos_Detalle_Ventas

        Try

            'Nota aquí no hay validaciones , se hacen por fuera.

            'Eliminamos todas las ventas(si es que hay previamente grabadas)
            If oDetalleVentas.EliminaCentroCostosDetalleVentas(Me.txtFolioCompra.Text) = False Then
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
                            MsgBox("Error al insertar el renglón " & i, MsgBoxStyle.Exclamation, sProcedure)
                            Return False
                        End If
                    End If
                Next

                bResultado = True
            End With

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
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

            Dim oAlmacen As New Class_CatAlmacenes
            oAlmacen.CODIGO_ALMACEN = Me.TxtCodigoAlmacen.Text

            If oAlmacen.Consultar() = False Then
                MsgBox("El código de almacén no existe.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            If oAlmacen.ESTATUS = "B" Then
                MsgBox("El almacén " & Me.TxtCodigoAlmacen.Text & " está dado de BAJA.", MsgBoxStyle.Exclamation, sProcedure)
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

                If valorNumerico(Me.txtSubTotal.Text) <= 0 Then
                    MsgBox("Captúre los renglones.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If

                Dim dSumaGridCuentas As Double = Redondear(FG_Grid_SumaCol(Me.GridCuentas, CShort(Me.iGyCtasImporte)), 2)
                Dim dSumaGridActivos As Double = Redondear(FG_Grid_SumaCol(Me.GridActivos, CShort(Me.iGyActivoImporte)), 2)
                Dim dSumaRenglones As Double = Redondear(dSumaGridCuentas + dSumaGridActivos, 2)

                If dSumaRenglones <> valorNumerico(Me.txtSubTotal.Text) Then
                    MsgBox("La suma de los renglones $ " & dSumaRenglones & "no cuadra con el subtotal $ " & valorNumerico(Me.txtSubTotal.Text), MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If

                If valorNumerico(Me.txtTotalCompra.Text) <> CDbl(FormatNumber((valorNumerico(Me.txtSubTotal.Text) + valorNumerico(Me.txtIVA.Text) - valorNumerico(Me.txtRetencionIVA.Text) - valorNumerico(Me.txtRetencionISR.Text) + valorNumericoD(Me.txtIEPS.Text)), 2)) Then
                    MsgBox("El total no esta correcto, favor de verificar.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If

                'Me.txtTotalCompra.Text = (valorNumerico(Me.TxtSubTotal.Text) + valorNumerico(Me.TxtIVA.Text) - valorNumerico(Me.TxtRetencion.Text)).ToString
                If valorNumerico(Me.txtIVA.Text) <> 0 Or txtLEN(Me.txtIVA.Text) = False Then
                    If valorNumerico(Me.txtPorciento.Text) = 0 Or txtLEN(Me.txtPorciento.Text) = False Then
                        MsgBox("No ha capturado el porcentaje del IVA, favor de verificar.", MsgBoxStyle.Exclamation, sProcedure)
                        Me.txtPorciento.Focus()
                        Return False
                    End If
                ElseIf valorNumerico(Me.txtPorciento.Text) <> 0 Or txtLEN(Me.txtPorciento.Text) = False Then
                    If valorNumerico(Me.txtIVA.Text) = 0 Or txtLEN(Me.txtIVA.Text) = False Then
                        MsgBox("No ha capturado el total del IVA, favor de verificar.", MsgBoxStyle.Exclamation, sProcedure)
                        Me.txtIVA.Focus()
                        Return False
                    End If
                End If

                If txtLEN(Me.txtFolioProveedor.Text) = False Then
                    MsgBox("Favor de asignar el folio de la factura del proveedor.", MsgBoxStyle.Exclamation, sProcedure)
                    Me.txtFolioProveedor.Focus()
                    Return False
                End If

                If txtLEN(Me.TxtCodigoArticulo.Text) Then
                    Dim oArticulo As New Class_CatArticulos(Me.TxtCodigoArticulo.Text)

                    If oArticulo.Existe = False Then
                        MsgBox("El artículo no existe en el catalogo.", MsgBoxStyle.Exclamation, sProcedure)
                        Return False
                    ElseIf oArticulo.ESTATUS = "B" Then
                        MsgBox("El artículo esta dado de baja en el catalogo.", MsgBoxStyle.Exclamation, sProcedure)
                        Return False
                    End If

                    oArticulo = Nothing
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

            If Me.ValidaVentas = False Then
                Return False
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
        Dim sCuentaContable As String = "", oCuenta As New Class_CatCuentas, sCuentaContableRetencionIVA As String = "", sCuentaContableRetencionISR As String = "", sCuentaContableIEPS As String = ""
        Dim dRetencionIVA As Decimal = 0, dRetencionISR As Decimal = 0, dIEPS As Decimal = 0

        Try
            ''''''''''''''''''''''''''''''''''''''''''''''''
            With Me.GridCuentas
                For i = 1 To .Rows - 1

                    sCuentaContable = .Cell(i, Me.iGyCuentaContable).Text
                    sCuentaContableRetencionIVA = .Cell(i, Me.iGyCtasCuentaContableRetencionIVA).Text
                    sCuentaContableRetencionISR = .Cell(i, Me.iGyCtasCuentaContableRetencionISR).Text
                    sCuentaContableIEPS = .Cell(i, Me.iGyCtasCuentaContableIEPS).Text
                    dRetencionIVA = valorNumericoD(.Cell(i, Me.iGyCtasRetencionIVA).Text)
                    dRetencionISR = valorNumericoD(.Cell(i, Me.iGyCtasRetencionISR).Text)
                    dIEPS = valorNumericoD(.Cell(i, Me.iGyCtasIEPS).Text)

                    If valorNumerico(.Cell(i, Me.iGyCtasImporte).Text) <> 0 Then 'Si capturaron algún importe.
                        If txtLEN(sCuentaContable) = False Then
                            MsgBox("Falta introducir la cuenta contable del renglón: " & i & ".", MsgBoxStyle.Exclamation, sProcedure)
                            .Cell(i, Me.iGyCuentaContable).SetFocus()
                            Return False
                        End If
                    End If

                    If txtLEN(sCuentaContable) = True Then
                        oCuenta = New Class_CatCuentas(sCuentaContable)
                        If oCuenta._Existe = False Then
                            MsgBox("La cuenta contable del renglón: " & i & " no existe, favor de intentar con otra.", MsgBoxStyle.Exclamation, sProcedure)
                            .Cell(i, Me.iGyCuentaContable).SetFocus()
                            Return False
                        ElseIf oCuenta.ESMAYOR = "1" Then
                            MsgBox("La cuenta contable del renglón: " & i & " es de mayor, favor de intentar con otra.", MsgBoxStyle.Exclamation, sProcedure)
                            .Cell(i, Me.iGyCuentaContable).SetFocus()
                            Return False
                        ElseIf Microsoft.VisualBasic.Left(sCuentaContable, 1) = "5" Then
                            If .Cell(i, Me.iGyCtasTipo).Text <> "CENTRO_COSTO" Then
                                MsgBox("La cuenta contable del renglón: " & i & " es 5 mil , y el tipo no es centro de costos.", MsgBoxStyle.Exclamation, sProcedure)
                                Return False
                            End If
                            If txtLEN(.Cell(i, Me.iGyCtasCodigoCentroCosto).Text) = False Or .Cell(i, Me.iGyCtasCodigoCentroCosto).Text = "0" Then
                                MsgBox("La cuenta contable  del renglón: " & i & " es 5 mil , favor de asignar un centro de costo.", MsgBoxStyle.Exclamation, sProcedure)
                                .Cell(i, Me.iGyCtasCodigoCentroCosto).SetFocus()
                                Return False
                            End If
                        ElseIf Microsoft.VisualBasic.Left(sCuentaContable, 1) = "1" Then
                            If .Cell(i, Me.iGyCtasTipo).Text <> "DEUDOR_DIVERSO" Then
                                MsgBox("La cuenta contable del renglón: " & i & " es 1 mil , y el tipo no es deudor diverso.", MsgBoxStyle.Exclamation, sProcedure)
                                Return False
                            End If
                        ElseIf valorNumerico(.Cell(i, Me.iGyCtasImporte).Text) = 0 Then
                            MsgBox("Falta introducir el importe del renglón: " & i & ".", MsgBoxStyle.Exclamation, sProcedure)
                            .Cell(i, Me.iGyCtasImporte).SetFocus()
                            Return False
                        End If
                        bHayCuentasContables = True
                    End If

                    If dRetencionIVA > 0 Then
                        If txtLEN(sCuentaContableRetencionIVA) = False Then
                            MsgBox("Falta introducir la cuenta contable del IVA retenido del renglón: " & i & ".", MsgBoxStyle.Exclamation, sProcedure)
                            .Cell(i, Me.iGyCtasCuentaContableRetencionIVA).SetFocus()
                            Return False
                        End If

                        oCuenta = New Class_CatCuentas(sCuentaContableRetencionIVA)
                        If oCuenta._Existe = False Then
                            MsgBox("La cuenta contable del IVA retenido del renglón: " & i & " no existe, favor de intentar con otra.", MsgBoxStyle.Exclamation, sProcedure)
                            .Cell(i, Me.iGyCtasCuentaContableRetencionIVA).SetFocus()
                            Return False
                        ElseIf oCuenta.ESMAYOR = "1" Then
                            MsgBox("La cuenta contable del IVA retenido del renglón: " & i & " es de mayor, favor de intentar con otra.", MsgBoxStyle.Exclamation, sProcedure)
                            .Cell(i, Me.iGyCtasCuentaContableRetencionIVA).SetFocus()
                            Return False
                        End If
                    End If

                    If dRetencionISR > 0 Then
                        If txtLEN(sCuentaContableRetencionISR) = False Then
                            MsgBox("Falta introducir la cuenta contable del ISR retenido del renglón: " & i & ".", MsgBoxStyle.Exclamation, sProcedure)
                            .Cell(i, Me.iGyCtasCuentaContableRetencionISR).SetFocus()
                            Return False
                        End If

                        oCuenta = New Class_CatCuentas(sCuentaContableRetencionISR)
                        If oCuenta._Existe = False Then
                            MsgBox("La cuenta contable del ISR retenido del renglón: " & i & " no existe, favor de intentar con otra.", MsgBoxStyle.Exclamation, sProcedure)
                            .Cell(i, Me.iGyCtasCuentaContableRetencionISR).SetFocus()
                            Return False
                        ElseIf oCuenta.ESMAYOR = "1" Then
                            MsgBox("La cuenta contable del ISR retenido del renglón: " & i & " es de mayor, favor de intentar con otra.", MsgBoxStyle.Exclamation, sProcedure)
                            .Cell(i, Me.iGyCtasCuentaContableRetencionISR).SetFocus()
                            Return False
                        End If
                    End If

                    If dIEPS > 0 Then
                        If txtLEN(sCuentaContableIEPS) = False Then
                            MsgBox("Falta introducir la cuenta contable del IEPS del renglón: " & i & ".", MsgBoxStyle.Exclamation, sProcedure)
                            .Cell(i, Me.iGyCtasCuentaContableIEPS).SetFocus()
                            Return False
                        End If

                        oCuenta = New Class_CatCuentas(sCuentaContableIEPS)
                        If oCuenta._Existe = False Then
                            MsgBox("La cuenta contable del IEPS del renglón: " & i & " no existe, favor de intentar con otra.", MsgBoxStyle.Exclamation, sProcedure)
                            .Cell(i, Me.iGyCtasCuentaContableIEPS).SetFocus()
                            Return False
                        ElseIf oCuenta.ESMAYOR = "1" Then
                            MsgBox("La cuenta contable del IEPS del renglón: " & i & " es de mayor, favor de intentar con otra.", MsgBoxStyle.Exclamation, sProcedure)
                            .Cell(i, Me.iGyCtasCuentaContableIEPS).SetFocus()
                            Return False
                        End If
                    End If
                Next i

                For i = 1 To .Rows - 1
                    If valorNumerico(.Cell(i, Me.iGyCtasImporte).Text) <> 0 Then 'Si capturaron algún importe.
                        If Len(.Cell(i, Me.iGyCuentaContable).Text) = 0 Then
                            MsgBox("Falta introducir la cuenta contable del renglón: " & i & ".", MsgBoxStyle.Exclamation, sProcedure)
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
                    sCuentaContableRetencionIVA = .Cell(i, Me.iGyActivoCuentaContableRetencionIVA).Text
                    sCuentaContableRetencionISR = .Cell(i, Me.iGyActivoCuentaContableRetencionISR).Text
                    sCuentaContableIEPS = .Cell(i, Me.iGyActivoCuentaContableIEPS).Text
                    dRetencionIVA = valorNumericoD(.Cell(i, Me.iGyActivoRetencionIVA).Text)
                    dRetencionISR = valorNumericoD(.Cell(i, Me.iGyActivoRetencionISR).Text)
                    dIEPS = valorNumericoD(.Cell(i, Me.iGyActivoIEPS).Text)

                    If valorNumerico(.Cell(i, Me.iGyActivoImporte).Text) <> 0 Then 'Si capturaron algún importe.
                        If txtLEN(sCuentaContable) = False Then
                            MsgBox("Falta introducir la cuenta contable del renglón: " & i & ".", MsgBoxStyle.Exclamation, sProcedure)
                            .Cell(i, Me.iGyActivoCuentaContable).SetFocus()
                            Return False
                        End If
                    End If

                    If txtLEN(sCuentaContable) = True Then
                        oCuenta = New Class_CatCuentas(sCuentaContable)

                        If oCuenta._Existe = False Then
                            MsgBox("La cuenta contable(de los activos) del renglón: " & i & " no existe, favor de intentar con otra.", MsgBoxStyle.Exclamation, sProcedure)
                            .Cell(i, Me.iGyActivoCuentaContable).SetFocus()
                            Return False
                        ElseIf oCuenta.ESMAYOR = "1" Then
                            MsgBox("La cuenta contable(de los activos) del renglón: " & i & " es de mayor, favor de intentar con otra.", MsgBoxStyle.Exclamation, sProcedure)
                            .Cell(i, Me.iGyActivoCuentaContable).SetFocus()
                            Return False
                            'ElseIf sCuentaContable.StartsWith("1") = False Then 'Si no empieza con 1 'Antes sólo se permitian cuentas tipo 1(activos)
                            '    MsgBox("La cuenta contable del renglón : " & i & " debe ser del rango de las miles(que empiezen con 1).", MsgBoxStyle.Exclamation, sProcedure)
                            '    Return False
                        End If
                        bHayCuentasContables = True
                    End If

                    If dRetencionIVA > 0 Then
                        If txtLEN(sCuentaContableRetencionIVA) = False Then
                            MsgBox("Falta introducir la cuenta contable(de los activos) del IVA retenido del renglón: " & i & ".", MsgBoxStyle.Exclamation, sProcedure)
                            .Cell(i, Me.iGyActivoCuentaContableRetencionIVA).SetFocus()
                            Return False
                        End If

                        oCuenta = New Class_CatCuentas(sCuentaContableRetencionIVA)
                        If oCuenta._Existe = False Then
                            MsgBox("La cuenta contable(de los activos) del IVA retenido del renglón: " & i & " no existe, favor de intentar con otra.", MsgBoxStyle.Exclamation, sProcedure)
                            .Cell(i, Me.iGyActivoCuentaContableRetencionIVA).SetFocus()
                            Return False
                        ElseIf oCuenta.ESMAYOR = "1" Then
                            MsgBox("La cuenta contable(de los activos) del IVA retenido del renglón: " & i & " es de mayor, favor de intentar con otra.", MsgBoxStyle.Exclamation, sProcedure)
                            .Cell(i, Me.iGyActivoCuentaContableRetencionIVA).SetFocus()
                            Return False
                        End If
                    End If

                    If dRetencionISR > 0 Then
                        If txtLEN(sCuentaContableRetencionISR) = False Then
                            MsgBox("Falta introducir la cuenta contable(de los activos) del ISR retenido del renglón: " & i & ".", MsgBoxStyle.Exclamation, sProcedure)
                            .Cell(i, Me.iGyActivoCuentaContableRetencionISR).SetFocus()
                            Return False
                        End If

                        oCuenta = New Class_CatCuentas(sCuentaContableRetencionISR)
                        If oCuenta._Existe = False Then
                            MsgBox("La cuenta contable del ISR retenido del renglón: " & i & " no existe, favor de intentar con otra.", MsgBoxStyle.Exclamation, sProcedure)
                            .Cell(i, Me.iGyActivoCuentaContableRetencionISR).SetFocus()
                            Return False
                        ElseIf oCuenta.ESMAYOR = "1" Then
                            MsgBox("La cuenta contable del ISR retenido del renglón: " & i & " es de mayor, favor de intentar con otra.", MsgBoxStyle.Exclamation, sProcedure)
                            .Cell(i, Me.iGyActivoCuentaContableRetencionISR).SetFocus()
                            Return False
                        End If
                    End If

                    If dIEPS > 0 Then
                        If txtLEN(sCuentaContableIEPS) = False Then
                            MsgBox("Falta introducir la cuenta contable del IEPS del renglón: " & i & ".", MsgBoxStyle.Exclamation, sProcedure)
                            .Cell(i, Me.iGyActivoCuentaContableIEPS).SetFocus()
                            Return False
                        End If

                        oCuenta = New Class_CatCuentas(sCuentaContableIEPS)
                        If oCuenta._Existe = False Then
                            MsgBox("La cuenta contable del IEPS del renglón: " & i & " no existe, favor de intentar con otra.", MsgBoxStyle.Exclamation, sProcedure)
                            .Cell(i, Me.iGyActivoCuentaContableIEPS).SetFocus()
                            Return False
                        ElseIf oCuenta.ESMAYOR = "1" Then
                            MsgBox("La cuenta contable del IEPS del renglón: " & i & " es de mayor, favor de intentar con otra.", MsgBoxStyle.Exclamation, sProcedure)
                            .Cell(i, Me.iGyActivoCuentaContableIEPS).SetFocus()
                            Return False
                        End If
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
                    MsgBox("El folio " & sFolio & " ya está capturado en el renglón " & i.ToString, MsgBoxStyle.Exclamation, Me.Name)
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

            Me.oCompras = New Class_Compras_Global(sFolio, "CA" & Usuario.Codigo_Plaza.ToString)

            If Me.oCompras.Existe = False Then
                Me.Cambia_Estado(enumEstados.NUEVO)
                Return False
            End If

            Me.txtFolioCompra.Text = Me.oCompras.FOLIO_COMPRA
            Me.LblPoliza.Text = Me.oCompras.FOLIO_POLIZA

            Me.TxtCodigoAlmacen.Text = Me.oCompras.CODIGO_ALMACEN
            Dim sql As New Class_find("SELECT NOMBRE_ALMACEN FROM CAT_ALMACENES WHERE CODIGO_ALMACEN='" & Me.TxtCodigoAlmacen.Text & "' ")
            Me.LblNombreAlmacen.Text = sql.Result1

            Me.TxtCodigoProveedor.Text = Me.oCompras.CODIGO_PROVEEDOR

            Dim oProveedor As New Class_CatProveedores(Me.TxtCodigoProveedor.Text)
            Me.LblProveedor.Text = oProveedor.Nombre_Proveedor.ToUpper
            Me.LblCuentaContableProveedor.Text = oProveedor.CUENTA_CONTABLE

            Me.TxtCodigoArticulo.Text = Me.oCompras.CODIGO_ARTICULO_GASTOS

            If txtLEN(Me.TxtCodigoArticulo.Text) Then
                sql = New Class_find("SELECT DESCRIPCION FROM CAT_ARTICULOS WHERE CODIGO_ARTICULO='" & Me.TxtCodigoArticulo.Text & "' ")
                Me.lblNombreArticulo.Text = sql.Result1
            End If

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

            Me.txtSubTotal.Text = FormatImporteContable(Me.oCompras.SUBTOTAL)
            Me.txtIVA.Text = FormatImporteContable(Me.oCompras.IMPUESTO)
            Me.txtPorciento.Text = Me.oCompras.IMPUESTO_PORCENTAJE.ToString
            Me.txtRetencionIVA.Text = FormatImporteContable(Me.oCompras.RETENCION_IVA)
            Me.txtRetencionISR.Text = FormatImporteContable(Me.oCompras.RETENCION_ISR)
            Me.txtTotalCompra.Text = FormatImporteContable(Me.oCompras.TOTAL)
            Me.txtImporteDolares.Text = FormatImporteContable(Me.oCompras.TOTAL_DOLARES)

            Me.cboTemporada.SelectedValue = Me.oCompras.ID_NOMINA_TEMPORADA

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

            Dim sUUID As String = Me.oCompras.UUID

            If txtLEN(sUUID) = True Then
                Me.tsbAgregarXML.Text = "Ver XML"

                Dim oPoliza As New Class_Contabilidad_Poliza_Global(Me.txtFolioCompra.Text)
                If oPoliza.Existe = False Then
                    Return False
                End If

                If oPoliza.TienePDF(sUUID) = True Then
                    Me.tsbAgregarPDF.Text = "Ver PDF"
                Else
                    Me.tsbAgregarPDF.Text = "Agregar PDF"
                End If

                oPoliza = Nothing
            Else
                Me.tsbAgregarXML.Text = "Agregar XML"
                Me.tsbAgregarPDF.Text = "Agregar PDF"
            End If

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

    Private Function CancelarCompra() As Boolean
        Const sProcedure As String = "CancelarCompra"
        Dim bResultado As Boolean = False

        Dim oFirmaElectronica = New UtileriasFirmaElectronicaCancelacionMovimientosFueraPeriodo
        Dim oUtileriasCancela As New Class_UtileriasFirmaElectronicaCancelacion
        Dim oPoliza As New Class_Contabilidad_Poliza_Global
        Dim oDetalleVentas As New Class_Centros_Costos_Detalle_Ventas
        Dim sConceptoCancelacion As String = ""

        If MsgBox("Deseas cancelar el gasto " & Me.txtFolioCompra.Text & " ?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, sProcedure) = MsgBoxResult.No Then
            Return False
        End If

        If Usuario.ValidaPermisoUsuarioDocumentoConAfectacionInventarios("CO" & Plaza.CODIGO_PLAZA.ToString, Me.TxtCodigoAlmacen.Text) = False Then
            MsgBox("El usuario " & Usuario.Nombre_Usuario & " no tiene permiso para realizar el movimiento de inventarios.", MsgBoxStyle.Exclamation, sProcedure)
            Return False
        End If

        'If Me.oCompras.ValidaExistencias() = False Then
        '    return false
        'End If

        Try
            oUtileriasCancela.FOLIO_DOCUMENTO = Me.txtFolioCompra.Text.ToUpper
            oUtileriasCancela.MODULO = Me.oCompras.CODIGO_MODULO
            oUtileriasCancela.CODIGO_PLAZA = Usuario.Codigo_Plaza

            If oUtileriasCancela.GestionaCancelacion() = False Then
                Return False
            End If

            If oUtileriasCancela.CANCELA_DIRECTO = True Then
                Me.oCompras.FECHA_CANCELACION = Date.Now

                sConceptoCancelacion = InputBox("Ingrese un concepto de cancelación :", "Concepto de cancelación")
                Me.oCompras.CONCEPTO_CANCELACION = sConceptoCancelacion

                If Me.oCompras.CancelaCompra() = False Then
                    Return False
                End If
            Else
                oUtileriasCancela = New Class_UtileriasFirmaElectronicaCancelacion
                oUtileriasCancela.FOLIO_DOCUMENTO = Me.txtFolioCompra.Text
                oUtileriasCancela.FOLIO_POLIZA = Me.oCompras.FOLIO_POLIZA
                oUtileriasCancela.CODIGO_DOCUMENTO = "CA" & Usuario.Codigo_Plaza.ToString
                oUtileriasCancela.CODIGO_PLAZA = Usuario.Codigo_Plaza
                oUtileriasCancela.MODULO = Me.oCompras.CODIGO_MODULO

                If oUtileriasCancela.AutorizaCancelacionMovimientosFueraPeriodo() = False Then
                    'MsgBox("Error al tratar de autorizar la cancelación fuera del periodo.", MsgBoxStyle.Exclamation, Me.Text)
                    Return False
                End If

                sConceptoCancelacion = oUtileriasCancela.CANCELACION_CONCEPTO
                Me.oCompras.CONCEPTO_CANCELACION = sConceptoCancelacion

                'si no se autorizo
                If oUtileriasCancela.CANCELACION_AUTORIZO = False Then
                    MsgBox("No se autorizó la cancelación de movimiento.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If

                If oUtileriasCancela.GestionaCancelacionConInterfaz() = False Then
                    MsgBox("Error al gestionar la cancelacion con interfaz", MsgBoxStyle.Information, sProcedure)
                    Return False
                Else
                    If oUtileriasCancela.ES_FECHA_CANCELACION_VALIDA = "0" Then
                        MsgBox("La fecha de cancelación debe de ser mayor o igual a la fecha del documento y debe estar en el mismo ejercicio.", vbExclamation, sProcedure)
                        Return False
                    End If

                    Me.oCompras.FECHA_CANCELACION = oUtileriasCancela.FECHA_CANCELACION

                    If Me.oCompras.CancelaCompra() = False Then
                        MsgBox("Error al intentar cancelar el movimiento de inventario.", MsgBoxStyle.Exclamation, sProcedure)
                        Return False
                    End If
                End If
            End If

            If oDetalleVentas.EliminaCentroCostosDetalleVentas(Me.txtFolioCompra.Text) = False Then
                MsgBox("Error al eliminar las facturas relacionadas, avise al departamento de sistemas.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            MsgBox("Gasto cancelado satisfactoriamente.", MsgBoxStyle.Information, sProcedure)

            bResultado = True

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    'Private Function AgregarXML() As Boolean
    '    Dim bResultado As Boolean = False
    '    Dim sProcedure As String = "AgregarXML"
    '    Dim oPoliza As Class_Contabilidad_Poliza_Global

    '    Try
    '        oPoliza = New Class_Contabilidad_Poliza_Global(Me.txtFolioCompra.Text)
    '        If oPoliza.Existe = False Then
    '            Return False
    '        End If

    '        Select Case Me.tsbAgregarXML.Text
    '            Case "Agregar XML"
    '                Dim sRutaXML As String = oPoliza.BuscarXML(New Class_CatProveedores(Me.TxtCodigoProveedor.Text).RFC, True)

    '                If txtLEN(sRutaXML) = True Then
    '                    bResultado = oPoliza.AgregarXMLPDF(sRutaXML, "") 'Mandamos sin pdf
    '                End If

    '                If bResultado = True Then
    '                    Me.tsbAgregarXML.Text = "Ver XML"
    '                End If

    '            Case "Ver XML"
    '                Dim sUUID As String = Me.oCompras.UUID

    '                If txtLEN(sUUID) = False Then
    '                    MsgBox("No se encontró el UUID de la compra", MsgBoxStyle.Exclamation, sProcedure)
    '                    Return False
    '                End If

    '                bResultado = oPoliza.AbrirXML(sUUID)

    '        End Select

    '    Catch ex As Exception
    '        HandleError(Me.Name, sProcedure, ex)
    '    Finally
    '        oPoliza = Nothing
    '        Application.DoEvents()
    '    End Try

    '    Return bResultado
    'End Function

    'Private Function AgregarPDF() As Boolean
    '    Dim bResultado As Boolean = False
    '    Dim sProcedure As String = "AgregarPDF"
    '    Dim oPoliza As Class_Contabilidad_Poliza_Global

    '    Try
    '        Dim sUUID As String = Me.oCompras.UUID
    '        Dim sRutaPDF As String = ""

    '        If txtLEN(sUUID) = False Then
    '            MsgBox("Esta compra no tiene relacionado ningún XML.", vbExclamation, sProcedure)
    '            Return False
    '        End If

    '        oPoliza = New Class_Contabilidad_Poliza_Global(Me.txtFolioCompra.Text)
    '        If oPoliza.Existe = False Then
    '            Return False
    '        End If

    '        Select Case Me.tsbAgregarPDF.Text
    '            Case "Agregar PDF"
    '                sRutaPDF = oPoliza.BuscarPDF()

    '                If txtLEN(sRutaPDF) = True Then
    '                    bResultado = oPoliza.AgregarPDF(sUUID, sRutaPDF)
    '                End If

    '                If bResultado = True Then
    '                    Me.tsbAgregarPDF.Text = "Ver PDF"
    '                End If

    '                oPoliza = Nothing

    '            Case "Ver PDF"
    '                oPoliza.AbrirPDF(sUUID)
    '        End Select

    '    Catch ex As Exception
    '        HandleError(Me.Name, sProcedure, ex)
    '    Finally
    '        oPoliza = Nothing
    '        Application.DoEvents()
    '    End Try

    '    Return bResultado
    'End Function

    Private Sub ClickBotonGridCuentas()
        Dim bResultado As Boolean = False
        Dim sProcedure As String = "ClickBotonGridCuentas"
        Try
            Dim iRenglon As Integer = 0, iColumna As Integer = 0, sUUID As String = "", sRutaXML As String = "", sRutaPDF As String = ""
            Dim oPoliza As New Class_Contabilidad_Poliza_Global()
            Dim iIDCentroCostoDetalle As Integer = 0

            iRenglon = Me.GridCuentas.ActiveCell.Row
            iColumna = Me.GridCuentas.ActiveCell.Col
            sUUID = Me.GridCuentas.Cell(iRenglon, Me.iGyCtasUUID).Text
            iIDCentroCostoDetalle = CInt(valorNumerico(Me.GridCuentas.Cell(iRenglon, Me.iGyCtasIDCentroCostoDetalle).Text))

            Select Case iColumna
                Case Me.iGyCtasXML
                    Select Case Me.GridCuentas.Cell(iRenglon, Me.iGyCtasXML).Text
                        Case "Agregar", "" 'Nota1 Si esta en blanco significa que es un docto que ya existe y se esta consultando y se le quiere ya sea agregar un xml que nunca se le puso, o quieren sobreescribirlo.

                            'Ver Nota1, debe existir el renglón para poder actualizarle el xml/pdf
                            If txtLEN(Me.GridCuentas.Cell(iRenglon, Me.iGyCtasXML).Text) = False Then
                                If iIDCentroCostoDetalle = 0 Then
                                    MsgBox("Este renglón no tiene permitido agregar xml/pdf porque se esta consultando un documento y deberia tener IDCentroCostoDetalle.", MsgBoxStyle.Exclamation, Me.Text)
                                    Return
                                End If
                            End If

                            sRutaXML = oPoliza.BuscarXML("", True) 'Aún no tenemos la póliza por eso lo pasamos sin folio de póliza

                            'If txtLEN(sRutaXML) = True Then
                            ' bResultado = oPoliza.AgregarXMLPDF(sRutaXML, "") 'Mandamos sin pdf
                            ' End If

                            If txtLEN(sRutaXML) = False Then
                                Return
                            End If

                            Dim oCFDI As New CFDIXML.ClassCFDI(sRutaXML, True) 'Internamente: ya se valida que este timbrado

                            If oCFDI.XMLCargado = False Then
                                Return
                            End If

                            If oCFDI.Comprobante.Moneda <> "MXN" Then
                                MsgBox("Aviso, este xml está en USD, cada uno los valores que el sistema muestra de momento usted debe modificarlos a MXN o quedarian incorrectos al mostrar cifras en USD.", vbExclamation, sProcedure)
                            End If

                            'Sólo cuando es un renglón nuevo se cargan los valores, cuando ya existe no porque sólo liga el xml aunque los valores no correspondan porque de momento si se permite.
                            If iIDCentroCostoDetalle = 0 Then
                                Dim index As Integer = 0, dISR_Retenido As Decimal = 0, dIVA_Retenido As Decimal = 0, dIEPS As Decimal = 0, dSubTotal As Decimal = 0
                                If IsNothing(oCFDI.Impuestos.Retenciones) = False Then
                                    While index < oCFDI.Impuestos.Retenciones.Count
                                        Select Case oCFDI.Impuestos.Retenciones(index).impuesto
                                            Case "001"  'ISR
                                                dISR_Retenido += CDec(oCFDI.Impuestos.Retenciones(index).importe)
                                            Case "002" 'IVA
                                                dIVA_Retenido += CDec(oCFDI.Impuestos.Retenciones(index).importe)
                                        End Select

                                        index += 1
                                    End While
                                End If

                                If IsNothing(oCFDI.Impuestos.Traslados) = False Then
                                    While index < oCFDI.Impuestos.Traslados.Count
                                        If oCFDI.Impuestos.Traslados(index).impuesto = "003" Then 'IEPS
                                            dIEPS += CDec(oCFDI.Impuestos.Traslados(index).importe)
                                        End If

                                        index += 1
                                    End While
                                End If

                                'Debug.Print("Total Ret " & oCFDI.Impuestos.totalImpuestosRetenidos.ToString & vbCrLf & "ISR Ret " & dISR_Retenido.ToString & vbCrLf & "IVA Ret " & dIVA_Retenido.ToString & vbCrLf & "IEPS " & dIEPS.ToString)

                                If oCFDI.Comprobante.SubTotalManipulado <> oCFDI.Comprobante.SubTotal Then
                                    If dIEPS = 0 Then
                                        dIEPS = CDec(oCFDI.Impuestos.totalImpuestosTrasladadosIEPSGasolina)
                                    Else
                                        MsgBox("Este XML parece tener conceptos de gasolina, pero no se pudo determinar el ieps porque tiene tanto ieps explícito como implícito, usted teclee ""todos los importes correctos"" por favor.", MsgBoxStyle.Exclamation, sProcedure)
                                    End If
                                    dSubTotal = CDec(oCFDI.Comprobante.SubTotalManipulado)
                                Else
                                    dSubTotal = CDec(oCFDI.Comprobante.SubTotal)
                                End If

                                'Me.GridCuentas.Cell(iRenglon, Me.iGyCtasImporte).Text = oCFDI.Comprobante.SubTotal.ToString
                                Me.GridCuentas.Cell(iRenglon, Me.iGyCtasImporte).Text = dSubTotal.ToString
                                Me.GridCuentas.Cell(iRenglon, Me.iGyCtasIVA).Text = oCFDI.Impuestos.totalImpuestosTrasladadosIVA.ToString
                                Me.GridCuentas.Cell(iRenglon, Me.iGyCtasRetencionIVA).Text = dIVA_Retenido.ToString
                                Me.GridCuentas.Cell(iRenglon, Me.iGyCtasRetencionISR).Text = dISR_Retenido.ToString
                                Me.GridCuentas.Cell(iRenglon, Me.iGyCtasIEPS).Text = dIEPS.ToString
                                Me.GridCuentas.Cell(iRenglon, Me.iGyCtasTotal).Text = Redondear(dSubTotal + oCFDI.Impuestos.totalImpuestosTrasladadosIVA - dIVA_Retenido - dISR_Retenido + dIEPS, 2).ToString
                                Me.GridCuentas.Cell(iRenglon, Me.iGyCtasNombreEmisor).Text = oCFDI.Emisor.nombre
                                Me.GridCuentas.Cell(iRenglon, Me.iGyCtasRFCEmisor).Text = oCFDI.Emisor.rfc
                            Else
                                Dim oCentroCosto As New Class_Centros_Costos_Global

                                If oCentroCosto.ActualizaUUID_Detalle(iIDCentroCostoDetalle, oCFDI.ComplementoTFD.UUID) = True Then
                                    oPoliza = New Class_Contabilidad_Poliza_Global(Me.txtFolioCompra.Text)
                                    If oPoliza.Existe = True Then
                                        If txtLEN(sRutaXML) = True Then
                                            If oPoliza.TieneRelacionadoUUID(oCFDI.ComplementoTFD.UUID) = False Then 'Si la póliza no tiene relacionado todavia el uuid si se relaciona, si ya lo tiene no porque marcaria error(el xml ya existirá en el repositorio y relacionado).
                                                bResultado = oPoliza.AgregarXMLPDF(sRutaXML, sRutaPDF) 'sRutaPDF pudiera venir vacio y no grabará el pdf
                                            End If
                                        End If
                                    End If
                                End If

                            End If

                            Me.GridCuentas.Cell(iRenglon, Me.iGyCtasUUID).Text = oCFDI.ComplementoTFD.UUID
                            Me.GridCuentas.Cell(iRenglon, Me.iGyCtasXML).Text = "Ver"
                            Me.GridCuentas.Cell(iRenglon, Me.iGyCtasRutaXML).Text = sRutaXML

                        Case "Ver"
                            Process.Start(Me.GridCuentas.Cell(iRenglon, Me.iGyCtasRutaXML).Text) 'Para abrir el xml

                    End Select

                Case Me.iGyCtasPDF
                    If txtLEN(sUUID) = False Then
                        MsgBox("Debe primero subir el XML.", MsgBoxStyle.Exclamation, sProcedure)
                        Return
                    End If

                    Select Case Me.GridCuentas.Cell(iRenglon, Me.iGyCtasPDF).Text
                        Case "Agregar", "" 'Nota1 Si esta en blanco significa que es un docto que ya existe y se esta consultando y se le quiere ya sea agregar un xml que nunca se le puso, o quieren sobreescribirlo.
                            sRutaPDF = oPoliza.BuscarPDF() 'Note que aún no tenemos la póliza 

                            'Ver Nota1, debe existir el renglón para poder actualizarle el xml/pdf
                            If txtLEN(Me.GridCuentas.Cell(iRenglon, Me.iGyCtasPDF).Text) = False Then
                                If iIDCentroCostoDetalle = 0 Then
                                    MsgBox("Este renglón no tiene permitido agregar xml/pdf porque se esta consultando un documento y deberia tener IDCentroCostoDetalle.", MsgBoxStyle.Exclamation, Me.Text)
                                    Return
                                End If

                                'Estamos dentro un docto ya grabado por eso este código va aqui y afuera no porque cuando es nuevo la propia función grabar graba los xml/pdf
                                bResultado = oPoliza.AgregarPDF(sUUID, sRutaPDF) 'sRutaPDF pudiera venir vacio y no grabará el pdf
                            End If

                            If txtLEN(sRutaPDF) = True Then
                                Me.GridCuentas.Cell(iRenglon, Me.iGyCtasPDF).Text = "Ver"
                                Me.GridCuentas.Cell(iRenglon, Me.iGyCtasRutaPDF).Text = sRutaPDF
                            End If

                        Case "Ver"
                            Process.Start(Me.GridCuentas.Cell(iRenglon, Me.iGyCtasRutaPDF).Text) 'Para abrir el pdf
                    End Select

            End Select

            Me.TotalizaGridCentrosCostosyActivos()

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Sub ClickBotonGridActivos()
        Dim bResultado As Boolean = False
        Dim sProcedure As String = "ClickBotonGridActivos"

        Try
            Dim iRenglon As Integer = 0, iColumna As Integer = 0, sUUID As String = "", sRutaXML As String = "", sRutaPDF As String = "", iIDGastoDetalle As Integer = 0
            Dim oPoliza As New Class_Contabilidad_Poliza_Global()

            iRenglon = Me.GridActivos.ActiveCell.Row
            iColumna = Me.GridActivos.ActiveCell.Col
            sUUID = Me.GridActivos.Cell(iRenglon, Me.iGyActivoUUID).Text
            iIDGastoDetalle = CInt(valorNumerico(Me.GridActivos.Cell(iRenglon, Me.iGyActivoIDGastoDetalle).Text))

            Select Case iColumna
                Case Me.iGyActivoXML
                    Select Case Me.GridActivos.Cell(iRenglon, Me.iGyActivoXML).Text
                        Case "Agregar", "" 'Nota1 Si esta en blanco significa que es un docto que ya existe y se esta consultando y se le quiere ya sea agregar un xml que nunca se le puso, o quieren sobreescribirlo.

                            'Ver Nota1, debe existir el renglón para poder actualizarle el xml/pdf
                            If txtLEN(Me.GridActivos.Cell(iRenglon, Me.iGyActivoXML).Text) = False Then
                                If iIDGastoDetalle = 0 Then
                                    MsgBox("Este renglón no tiene permitido agregar xml/pdf porque se esta consultando un documento y deberia tener IDCentroCostoDetalle.", MsgBoxStyle.Exclamation, Me.Text)
                                    Return
                                End If
                            End If

                            sRutaXML = oPoliza.BuscarXML("", True) 'Aún no tenemos la póliza por eso lo pasamos sin folio de póliza

                            'If txtLEN(sRutaXML) = True Then
                            ' bResultado = oPoliza.AgregarXMLPDF(sRutaXML, "") 'Mandamos sin pdf
                            ' End If

                            If txtLEN(sRutaXML) = True Then
                                Dim oCFDI As New CFDIXML.ClassCFDI(sRutaXML, True) 'Internamente: ya se valida que este timbrado

                                If oCFDI.XMLCargado = False Then
                                    Return
                                End If

                                'Sólo cuando es un renglón nuevo se cargan los valores, cuando ya existe no porque sólo liga el xml aunque los valores no correspondan porque de momento si se permite.
                                If iIDGastoDetalle = 0 Then

                                    Dim index As Integer = 0, dISR_Retenido As Decimal = 0, dIVA_Retenido As Decimal = 0, dIEPS As Decimal = 0
                                    If IsNothing(oCFDI.Impuestos.Retenciones) = False Then
                                        While index < oCFDI.Impuestos.Retenciones.Count
                                            Select Case oCFDI.Impuestos.Retenciones(index).impuesto
                                                Case "001"  'ISR
                                                    dISR_Retenido += CDec(oCFDI.Impuestos.Retenciones(index).importe)
                                                Case "002" 'IVA
                                                    dIVA_Retenido += CDec(oCFDI.Impuestos.Retenciones(index).importe)
                                            End Select

                                            index += 1
                                        End While
                                    End If

                                    If IsNothing(oCFDI.Impuestos.Traslados) = False Then
                                        While index < oCFDI.Impuestos.Traslados.Count
                                            If oCFDI.Impuestos.Traslados(index).impuesto = "003" Then 'IEPS
                                                dIEPS += CDec(oCFDI.Impuestos.Traslados(index).importe)
                                            End If

                                            index += 1
                                        End While
                                    End If

                                    'Debug.Print("Total Ret " & oCFDI.Impuestos.totalImpuestosRetenidos.ToString & vbCrLf & "ISR Ret " & dISR_Retenido.ToString & vbCrLf & "IVA Ret " & dIVA_Retenido.ToString & vbCrLf & "IEPS " & dIEPS.ToString)

                                    Me.GridActivos.Cell(iRenglon, Me.iGyActivoImporte).Text = oCFDI.Comprobante.SubTotal.ToString
                                    Me.GridActivos.Cell(iRenglon, Me.iGyActivoIVA).Text = oCFDI.Impuestos.totalImpuestosTrasladadosIVA.ToString
                                    Me.GridActivos.Cell(iRenglon, Me.iGyActivoRetencionIVA).Text = dIVA_Retenido.ToString
                                    Me.GridActivos.Cell(iRenglon, Me.iGyActivoRetencionISR).Text = dISR_Retenido.ToString
                                    Me.GridActivos.Cell(iRenglon, Me.iGyActivoIEPS).Text = dIEPS.ToString
                                    Me.GridActivos.Cell(iRenglon, Me.iGyActivoTotal).Text = Redondear(oCFDI.Comprobante.SubTotal + oCFDI.Impuestos.totalImpuestosTrasladadosIVA - dIVA_Retenido - dISR_Retenido + dIEPS, 2).ToString
                                    Me.GridActivos.Cell(iRenglon, Me.iGyActivoNombreEmisor).Text = oCFDI.Emisor.nombre
                                    Me.GridActivos.Cell(iRenglon, Me.iGyActivoRFCEmisor).Text = oCFDI.Emisor.rfc

                                Else
                                    Dim oActivo As New Class_Gastos_Detalle

                                    If oActivo.ActualizaUUID_Detalle(iIDGastoDetalle, oCFDI.ComplementoTFD.UUID) = True Then
                                        oPoliza = New Class_Contabilidad_Poliza_Global(Me.txtFolioCompra.Text)
                                        If oPoliza.Existe = True Then
                                            If txtLEN(sRutaXML) = True Then
                                                If oPoliza.TieneRelacionadoUUID(oCFDI.ComplementoTFD.UUID) = False Then 'Si la póliza no tiene relacionado todavia el uuid si se relaciona, si ya lo tiene no porque marcaria error(el xml ya existirá en el repositorio y relacionado).
                                                    bResultado = oPoliza.AgregarXMLPDF(sRutaXML, sRutaPDF) 'sRutaPDF pudiera venir vacio y no grabará el pdf
                                                End If
                                            End If
                                        End If
                                    End If

                                End If

                                Me.GridActivos.Cell(iRenglon, Me.iGyActivoUUID).Text = oCFDI.ComplementoTFD.UUID
                                Me.GridActivos.Cell(iRenglon, Me.iGyActivoXML).Text = "Ver"
                                Me.GridActivos.Cell(iRenglon, Me.iGyActivoRutaXML).Text = sRutaXML

                            End If

                        Case "Ver"
                            Process.Start(Me.GridActivos.Cell(iRenglon, Me.iGyActivoRutaXML).Text) 'Para abrir el xml

                    End Select

                Case Me.iGyActivoPDF
                    If txtLEN(sUUID) = False Then
                        MsgBox("Debe primero subir el XML.", MsgBoxStyle.Exclamation, sProcedure)
                        Return
                    End If

                    Select Case Me.GridActivos.Cell(iRenglon, Me.iGyActivoPDF).Text
                        Case "Agregar", "" 'Nota1 Si esta en blanco significa que es un docto que ya existe y se esta consultando y se le quiere ya sea agregar un xml que nunca se le puso, o quieren sobreescribirlo.
                            sRutaPDF = oPoliza.BuscarPDF() 'Note que aún no tenemos la póliza 

                            'Ver Nota1, debe existir el renglón para poder actualizarle el xml/pdf
                            If txtLEN(Me.GridActivos.Cell(iRenglon, Me.iGyActivoPDF).Text) = False Then
                                If iIDGastoDetalle = 0 Then
                                    MsgBox("Este renglón no tiene permitido agregar xml/pdf porque se esta consultando un documento y deberia tener IDGastoDetalle.", MsgBoxStyle.Exclamation, Me.Text)
                                    Return
                                End If

                                'Estamos dentro un docto ya grabado por eso este código va aqui y afuera no porque cuando es nuevo la propia función grabar graba los xml/pdf
                                bResultado = oPoliza.AgregarPDF(sUUID, sRutaPDF) 'sRutaPDF pudiera venir vacio y no grabará el pdf
                            End If

                            If txtLEN(sRutaPDF) = True Then
                                Me.GridActivos.Cell(iRenglon, Me.iGyActivoPDF).Text = "Ver"
                                Me.GridActivos.Cell(iRenglon, Me.iGyActivoRutaPDF).Text = sRutaPDF
                            End If

                        Case "Ver"
                            Process.Start(Me.GridActivos.Cell(iRenglon, Me.iGyActivoRutaPDF).Text) 'Para abrir el pdf
                    End Select

            End Select

            Me.TotalizaGridCentrosCostosyActivos()

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

#End Region

End Class
