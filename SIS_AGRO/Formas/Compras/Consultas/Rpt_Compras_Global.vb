Option Strict On

Imports CrystalDecisions.CrystalReports.Engine

Public Class Rpt_Compras_Global
    Private oCompras As New Class_Compras_Global
    Private oProveedores As New Class_CatProveedores

#Region "Opciones"
    Private Sub tsbConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbConsultar.Click
        Imprimir()
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub
#End Region

#Region "Eventos"
    Private Sub Rpt_Compras_Global_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.DesplegarAlmacenes()
            Me.DesplegarDocumentos()
            Me.DesplegarFamilias()
            Me.DesplegarInventariables()
            Me.DesplegarMonedas()
            Me.DesplegarLineas()
            Me.DesplegarEsFiscal()

            Me.DtFechaDesde.Value = CDate(Format(Me.DtFechaDesde.Value, "01/MMM/yy"))
            Me.DtFechaHasta.Value = Date.Now
            Me.CboEstatus.SelectedItem = "APLICADO"
            Me.lblArticulo.Text = ""
            Me.lblProveedor.Text = ""
        Catch ex As Exception
            HandleError(Me.Name, "Rpt_Compras_Global_Load", ex)
        End Try
    End Sub

    Private Sub txtCodigoProveedor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigoProveedor.KeyDown
        Try
            Dim sText As String
            Select Case e.KeyCode
                Case Keys.F6
Buscar:
                    sText = Me.oProveedores.BusquedaVisual_PorDescripcion
                    If txtLEN(sText) = True Then Me.txtCodigoProveedor.Text = sText
                Case Keys.Enter
                    If txtLEN(Me.txtCodigoProveedor.Text) = False Then
                        Me.lblProveedor.Text = "" : txtTAB(e) : Exit Sub
                    End If

                    Me.oProveedores = New Class_CatProveedores(Me.txtCodigoProveedor.Text)
                    If Me.oProveedores.Existe = False Then
                        Me.lblProveedor.Text = "" : GoTo Buscar : Exit Sub
                    End If

                    Me.lblProveedor.Text = Me.oProveedores.Nombre_Proveedor
                    txtTAB(e)
            End Select
        Catch ex As Exception
            HandleError(Me.Name, "txtCodigoProveedor_KeyDown", ex)
        End Try
    End Sub

    Private Sub TxtCodigoArticulo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodigoArticulo.KeyDown
        Try
            Dim oArticulos As New Class_CatArticulos
            Select Case e.KeyCode
                Case Keys.F6
buscar:
                    Dim sArticulo As String = oArticulos.BusquedaVisual_PorDescripcion
                    If sArticulo.Length > 0 Then
                        Me.TxtCodigoArticulo.Text = sArticulo
                        Me.lblArticulo.Text = oArticulos.BuscarNombreArticulo(sArticulo)
                    End If
                Case Keys.Enter
                    Me.lblArticulo.Text = oArticulos.BuscarNombreArticulo(Me.TxtCodigoArticulo.Text)
                    If txtLEN(Me.lblArticulo.Text) = False Then
                        Me.lblArticulo.Text = ""
                        txtTAB(e)
                        Exit Sub
                    Else
                        txtTAB(e)
                    End If
                Case Keys.Escape
            End Select
        Catch ex As Exception
            HandleError(Me.Name, "TxtCodigoArticulo_KeyDown", ex)
        End Try
    End Sub

    Private Sub CboDocumento_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtFechaHasta.KeyDown, DtFechaDesde.KeyDown, chkMostrarSoloDocumentosSaldoMayorCero.KeyDown, CboEstatus.KeyDown, CboDocumento.KeyDown, CboAlmacen.KeyDown, CboFamilia.KeyDown
        txtTAB(e)
    End Sub

    Private Sub CboDocumento_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigoProveedor.KeyPress, TxtCodigoArticulo.KeyPress, DtFechaHasta.KeyPress, DtFechaDesde.KeyPress, chkMostrarSoloDocumentosSaldoMayorCero.KeyPress, CboEstatus.KeyPress, CboDocumento.KeyPress, CboAlmacen.KeyPress, CboFamilia.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub RadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles RbGlobal.CheckedChanged, RbAgrupadoFamilia.CheckedChanged, RbListadoDocumentos.CheckedChanged, RbDevoluciones.CheckedChanged, RbDescuentos.CheckedChanged
        Me.OcultarControles()
    End Sub

    'Private Sub RbAgrupadoFamilia_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbAgrupadoFamilia.CheckedChanged
    'If Me.RbAgrupadoFamilia.Checked = True Then
    '    Me.lblDisplayFamilia.Visible = True
    '    Me.CboFamilia.Visible = True

    '    Me.LblDisplayLinea.Visible = True
    '    Me.cboLineas.Visible = True
    'Else
    '    Me.lblDisplayFamilia.Visible = False
    '    Me.CboFamilia.Visible = False

    '    Me.LblDisplayLinea.Visible = False
    '    Me.cboLineas.Visible = False
    'End If
    'End Sub
#End Region

#Region "Métodos y procedimientos"
    Private Sub DesplegarDocumentos()
        Try
            Dim oDocumento As New Class_CatDocumentos
            With Me.CboDocumento
                .DisplayMember = "NOMBRE_TIPO_DOCUMENTO"
                .ValueMember = "CODIGO_DOCUMENTO"
                Dim dView As New Data.DataView(oDocumento.ObtenerCodigosDocumentosParaReportes(Me.oCompras.CODIGO_MODULO))
                dView.Sort = "NOMBRE_TIPO_DOCUMENTO DESC"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedValue = "CO1"
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarDocumentos", ex)
        End Try
    End Sub

    Private Sub DesplegarAlmacenes()
        Try
            Dim oAlmacenes As New Class_CatAlmacenes
            With Me.CboAlmacen
                .DisplayMember = "NOMBRE_ALMACEN"
                .ValueMember = "CODIGO_ALMACEN"
                Dim dView As New Data.DataView(oAlmacenes.ObtenerAlmacenesParaReportes)
                dView.Sort = "NOMBRE_ALMACEN"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedValue = Usuario.Codigo_Almacen
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarAlmacenes", ex)
        End Try
    End Sub

    Private Sub DesplegarFamilias()
        Try
            Dim oElementos As New Class_CatFamilias
            With Me.CboFamilia
                .DisplayMember = "Nombre_Familia"
                .ValueMember = "codigo_Familia"
                Dim dView As New Data.DataView(oElementos.ObtenerElementosParaReportes)
                dView.Sort = "Nombre_Familia"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedValue = "T"
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarFamilias", ex)
        End Try
    End Sub

    Private Sub DesplegarInventariables()
        Try
            With Me.cboInventariables
                .Items.Clear()
                .Items.Add("INVENTARIABLES")
                .Items.Add("NO INVENTARIABLES")
                .Items.Add("TODOS")
                .SelectedItem = "TODOS"
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarInventariables", ex)
        End Try
    End Sub

    Private Sub DesplegarMonedas()
        Try
            With Me.cboMoneda
                .Items.Clear()
                .Items.Add("NACIONAL")
                .Items.Add("EXTRANJERA")
                .Items.Add("TODAS")
                .SelectedItem = "TODAS"
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarMonedas", ex)
        End Try
    End Sub

    Private Sub DesplegarLineas()
        Try
            Dim oLineas As New Class_CatLineas
            With Me.cboLineas
                .DisplayMember = "Nombre_Linea"
                .ValueMember = "codigo_linea"
                Dim dView As New Data.DataView(oLineas.ObtenerElementosParaReportes)
                dView.Sort = "Nombre_linea"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedValue = "T"
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarLineas", ex)
        End Try
    End Sub

    Private Sub DesplegarEsFiscal()
        Try
            With Me.cboEsFiscal
                .Items.Clear()
                .Items.Add("0-NO FISCAL")
                .Items.Add("1-FISCAL")
                .Items.Add("T-TODAS")
                .SelectedItem = "T-TODAS"
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarEsFiscal", ex)
        End Try
    End Sub

    Private Sub Imprimir()
        Dim FormatoDeReporte As String = ""
        Dim Rpt As New ReportDocument
        Dim oReporte As Class_Reporte
        Try
            If Me.ValidarPeriodo = False Then
                Return
            End If

            If Me.RbGlobal.Checked = True Then
                oReporte = New Class_Reporte("RPT_COMPRA_GLOBAL", Rpt, True)
            ElseIf Me.RbAgrupadoFamilia.Checked = True Then
                oReporte = New Class_Reporte("RPT_COMPRA_AGRUPADO_POR_FAMILIA", Rpt, True)
            ElseIf Me.RbListadoDocumentos.Checked = True Then
                oReporte = New Class_Reporte("RPT_COMPRA_LISTADO", Rpt, True)
            ElseIf Me.RbDevoluciones.Checked = True Then
                oReporte = New Class_Reporte("RPT_CXP_DEVOLUCIONES", Rpt, True)
            ElseIf Me.RbDescuentos.Checked = True Then
                oReporte = New Class_Reporte("RPT_CXP_DESCUENTOS", Rpt, True)
            Else
                MsgBox("Formato no válido.", MsgBoxStyle.Exclamation, Me.Text)
                Return
            End If

            If Not oReporte.RptCargado = True Then
                Return
            End If

            Rpt.SetParameterValue("@CODIGO_PROVEEDOR", Me.txtCodigoProveedor.Text.ToUpper)
            Rpt.SetParameterValue("@ESTATUS", Me.CboEstatus.SelectedItem.ToString.Substring(0, 1))
            Rpt.SetParameterValue("@CODIGO_PLAZA", Usuario.Codigo_Plaza)
            Rpt.SetParameterValue("@FECHA1", Format(Me.DtFechaDesde.Value, "yyyy-dd-MM"))
            Rpt.SetParameterValue("@FECHA2", Format(Me.DtFechaHasta.Value, "yyyy-dd-MM"))

            If Me.RbDescuentos.Checked = False Then
                Rpt.SetParameterValue("@CODIGO_ARTICULO", Me.TxtCodigoArticulo.Text.ToUpper)
                Rpt.SetParameterValue("@CODIGO_ALMACEN", Me.CboAlmacen.SelectedValue.ToString())
            End If
            
            If Me.RbDescuentos.Checked = False And Me.RbDevoluciones.Checked = False Then
                Rpt.SetParameterValue("@CODIGO_DOCUMENTO", Me.CboDocumento.SelectedValue.ToString())
                Rpt.SetParameterValue("@FILTRO_SALDO", IIf(Me.chkMostrarSoloDocumentosSaldoMayorCero.Checked = True, "1", "0"))
                Rpt.SetParameterValue("@CODIGO_FAMILIA", Me.CboFamilia.SelectedValue.ToString)
                Rpt.SetParameterValue("@INVENTARIABLES", Me.cboInventariables.Text)
                Rpt.SetParameterValue("@MONEDA", Me.cboMoneda.Text)
                Rpt.SetParameterValue("@CODIGO_LINEA", Me.cboLineas.SelectedValue.ToString)
                Rpt.SetParameterValue("@ES_FISCAL", Me.cboEsFiscal.Text.Substring(0, 1))
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

    Private Function ValidarPeriodo() As Boolean
        Me.DtFechaDesde.Enabled = False
        Me.DtFechaHasta.Enabled = False
        Me.DtFechaDesde.Enabled = True
        Me.DtFechaHasta.Enabled = True

        If Me.DtFechaDesde.Value > Me.DtFechaHasta.Value Then
            MsgBox("Rango de fechas inválidas.", MsgBoxStyle.Exclamation, Me.Name)
            Me.DtFechaDesde.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub OcultarControles()
        If Me.RbDevoluciones.Checked Or Me.RbDescuentos.Checked Then
            Me.chkMostrarSoloDocumentosSaldoMayorCero.Visible = False
            Me.CboDocumento.Visible = False
            Me.cboEsFiscal.Visible = False
            Me.cboMoneda.Visible = False
            Me.cboLineas.Visible = False
            Me.CboFamilia.Visible = False
            Me.cboInventariables.Visible = False
            Me.CboEstatus.Visible = False

            Me.LblDocumento.Visible = False
            Me.lblDisplayEsFiscal.Visible = False
            Me.LblMoneda.Visible = False
            Me.LblDisplayLinea.Visible = False
            Me.lblDisplayFamilia.Visible = False
            Me.lblinventariables.Visible = False
            Me.LblEstatus.Visible = False

            If Me.RbDescuentos.Checked Then
                Me.CboAlmacen.Visible = False
                Me.TxtCodigoArticulo.Visible = False
                Me.lblArticulo.Visible = False
                Me.CboEstatus.Visible = True

                Me.LblAlmacen.Visible = False
                Me.LblEstatus.Visible = True
            End If

        Else
            Me.CboAlmacen.Visible = True
            Me.TxtCodigoArticulo.Visible = True
            Me.lblArticulo.Visible = True
            Me.chkMostrarSoloDocumentosSaldoMayorCero.Visible = True
            Me.CboDocumento.Visible = True
            Me.cboEsFiscal.Visible = True
            Me.cboMoneda.Visible = True
            Me.cboLineas.Visible = True
            Me.CboFamilia.Visible = True
            Me.cboInventariables.Visible = True
            Me.CboEstatus.Visible = True

            Me.LblDocumento.Visible = True
            Me.lblDisplayEsFiscal.Visible = True
            Me.LblMoneda.Visible = True
            Me.LblDisplayLinea.Visible = True
            Me.lblDisplayFamilia.Visible = True
            Me.lblinventariables.Visible = True
            Me.LblEstatus.Visible = True
            Me.LblAlmacen.Visible = True
            Me.LblEstatus.Visible = True
        End If
    End Sub

#End Region

End Class