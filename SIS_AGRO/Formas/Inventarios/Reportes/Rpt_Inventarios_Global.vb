Imports CrystalDecisions.CrystalReports.Engine

Public Class Rpt_Inventarios_Global
    Private oDocumentos As New Class_Cat_tiposDocumentos

    Private Sub tsbConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbConsultar.Click
        Consultar()
    End Sub

    Private Sub Inventario_Existencias_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DesplegarAlmacenes()
        DesplegarDocumentos()
        DesplegarConceptosInventarios()
        DtFechaDesde.Value = Format(Date.Now, "01-MM-yyyy")
        DtFechaHasta.Value = Date.Now
        LlenaComboEstatus()
    End Sub

#Region "Métodos y procedimientos"

    Private Sub Consultar()
        Dim FormatoDeReporte As String = ""
        Dim Rpt As ReportDocument
        Dim oReporte As Class_Reporte

        Rpt = New ReportDocument

        Try
            If Me.ValidarPeriodo = False Then
                Exit Sub
            End If

            If Me.RdbMovimientosGlobales.Checked = True Then
                FormatoDeReporte = "RPT_INVENTARIO_MOVIMIENTOS_GLOBAL"
            ElseIf Me.RdbMovimientosDetallados.Checked = True Then
                FormatoDeReporte = "RPT_INVENTARIO_MOVIMIENTOS_DETALLE"
            ElseIf Me.RdbTotalesCultivo.Checked = True Then
                FormatoDeReporte = "RPT_INVENTARIO_MOVIMIENTOS_DETALLE_CULTIVO_TOTALES"
            ElseIf Me.RdbDetalleCultivo.Checked = True Then
                FormatoDeReporte = "RPT_INVENTARIO_MOVIMIENTOS_DETALLE_CULTIVO"
            End If

            oReporte = New Class_Reporte(FormatoDeReporte, Rpt)
            Rpt.SetParameterValue("@CODIGO_TIPO_DOCUMENTO", CmbDocumento.SelectedValue)
            Rpt.SetParameterValue("@ESTATUS", CboEstatus.Text)
            Rpt.SetParameterValue("@CODIGO_ALMACEN1", CmbAlmacen.SelectedValue.ToString())

            If oDocumentos.ES_TRANSFERENCIA = "1" Then
                Rpt.SetParameterValue("@CODIGO_ALMACEN2", CmbAlmacen2.SelectedValue.ToString())
            Else
                Rpt.SetParameterValue("@CODIGO_ALMACEN2", "T")
            End If

            Rpt.SetParameterValue("@FECHA_INICIO", Format(DtFechaDesde.Value, "yyyy-dd-MM"))
            Rpt.SetParameterValue("@FECHA_FIN", Format(DtFechaHasta.Value, "yyyy-dd-MM"))
            Rpt.SetParameterValue("@CODIGO_ARTICULO", Me.TxtCodArticulo.Text.ToUpper)
            Rpt.SetParameterValue("@CODIGO_USUARIO", Usuario.Codigo_Usuario)
            Rpt.SetParameterValue("@NATURALEZA_INVENTARIOS", "T")
            Rpt.SetParameterValue("@CODIGO_CONCEPTO_INVENTARIOS", IIf(Me.CboConceptoInventario.SelectedValue = -1, "T", Me.CboConceptoInventario.SelectedValue.ToString))
            Rpt.SetParameterValue("@CODIGO_CLIENTE", Me.TxtCodigoCliente.Text)

            If Me.RdbTotalesCultivo.Checked = True Or Me.RdbDetalleCultivo.Checked = True Then
                Rpt.SetParameterValue("@CODIGO_CULTIVO", "T")
                Rpt.SetParameterValue("@CODIGO_TAMAÑO", "T")
                Rpt.SetParameterValue("@CODIGO_ENVASE", "T")
                Rpt.SetParameterValue("@CODIGO_ETIQUETA", "T")
            End If

            Dim frm As New Reporte(Rpt)
            frm.CRViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            frm.Show()

        Catch ex As Exception
            HandleError(Me.Name, "Reporte de Movimientos Detallado", ex)
        Finally
            oReporte = Nothing
        End Try
    End Sub

    Private Sub DesplegarDocumentos()
        Dim oElementos As New Class_CatDocumentos
        With Me.CmbDocumento
            .DisplayMember = "NOMBRE_TIPO_DOCUMENTO"

            .ValueMember = "CODIGO_TIPO_DOCUMENTO"

            Dim dView As New Data.DataView(oElementos.ObtenerTipoDocumentos("INV", Usuario.Codigo_Plaza, " ESTATUS_DOCUMENTO='A'"))
            dView.Sort = "NOMBRE_TIPO_DOCUMENTO"
            .DataSource = dView
            If dView.Count > 0 Then
                .SelectedIndex = 0
            End If
        End With
    End Sub

    Private Function LlenaComboEstatus() As Boolean
        Me.CboEstatus.Items.Add("A")
        Me.CboEstatus.Items.Add("C")
        Me.CboEstatus.Items.Add("G")
        Me.CboEstatus.Items.Add("T")

        Me.CboEstatus.SelectedItem = "A"
    End Function

    Private Sub DesplegarAlmacenes()
        Dim oElementos As New Class_CatAlmacenes
        With Me.CmbAlmacen
            .DisplayMember = "NOMBRE_ALMACEN"

            .ValueMember = "CODIGO_ALMACEN"

            Dim dView As New Data.DataView(oElementos.ObtenerAlmacenesParaReportes)
            dView.Sort = "NOMBRE_ALMACEN"
            .DataSource = dView
            If dView.Count > 0 Then
                .SelectedIndex = 0
            End If
            .SelectedValue = Usuario.Codigo_Almacen
        End With
        With Me.CmbAlmacen2
            .DisplayMember = "NOMBRE_ALMACEN"

            .ValueMember = "CODIGO_ALMACEN"

            Dim dView As New Data.DataView(oElementos.ObtenerAlmacenesParaReportes)
            dView.Sort = "NOMBRE_ALMACEN"
            .DataSource = dView
            If dView.Count > 0 Then
                .SelectedIndex = 0
            End If
            .SelectedValue = Usuario.Codigo_Almacen
        End With
    End Sub

    Private Sub DesplegarConceptosInventarios()
        Dim oElementos As New Class_CatConceptosInventarios
        With Me.CboConceptoInventario
            .DisplayMember = "NOMBRE_CONCEPTO_INVENTARIOS"
            .ValueMember = "CODIGO_CONCEPTO_INVENTARIOS"

            Dim dView As New Data.DataView(oElementos.ObtenerElementosParaReportes)
            dView.Sort = "NOMBRE_CONCEPTO_INVENTARIOS"
            .DataSource = dView
            .SelectedValue = -1 'TODOS
        End With
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
        ValidarPeriodo = True
    End Function
#End Region

#Region "Eventos Genericos"
    Private Sub txt_Enter(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim oTexBox As TextBox = CType(sender, TextBox)
        oTexBox.SelectAll()
    End Sub

    Private Sub txt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodArticulo.KeyPress, TxtCodigoCliente.KeyPress
        txtNoBeep(e)
    End Sub
#End Region

#Region "Keydown específicos"
    Private Sub chk_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Return Then
            Me.tsbConsultar.PerformClick()
        End If
    End Sub
#End Region

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub

    Private Sub TxtCodArticulo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodArticulo.KeyDown
        Dim oArticulos As New Class_CatArticulos
        Select Case e.KeyCode
            Case Keys.F6
                oArticulos = New Class_CatArticulos
                Dim sArticulo As String = oArticulos.BusquedaVisual_PorDescripcion
                If sArticulo.Length > 0 Then
                    Me.TxtCodArticulo.Text = sArticulo
                    Me.lblArticulo.Text = oArticulos.BuscarNombreArticulo(sArticulo)
                End If
            Case Keys.Enter
                Me.lblArticulo.Text = oArticulos.BuscarNombreArticulo(Me.TxtCodArticulo.Text)
                If txtLEN(Me.lblArticulo.Text) = False Then
                    MsgBox("El codigo de Articulo que intenta buscar no existe, favor de intentar con otro codigo.", MsgBoxStyle.Critical, "Validación de Articulos")
                    lblArticulo.Text = ""
                    TxtCodArticulo.Focus()
                    Exit Sub
                Else
                    lblArticulo.Focus()
                End If
            Case Keys.Escape
        End Select
    End Sub

    Private Sub TxtCodigoArticulo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodigoCliente.KeyDown
        Try
            Dim sText As String
            Dim oClientes As New Class_CatClientes

            Select Case e.KeyCode
                Case Keys.F6
Buscar:

                    If Empresa_Sistema.PERMITE_CLIENTES_MULTIPLAZA = True Then
                        sText = oClientes.BusquedaVisual_PorDescripcionSinFiltroZona
                    Else
                        sText = oClientes.BusquedaVisual_PorDescripcion
                    End If

                    If txtLEN(sText) = True Then Me.TxtCodigoCliente.Text = sText
                Case Keys.Enter
                    If txtLEN(Me.TxtCodigoCliente.Text) = False Then
                        Me.LblNombreCliente.Text = ""
                        txtTAB(e)
                        Return
                    End If
                    oClientes = New Class_CatClientes(Me.TxtCodigoCliente.Text)
                    If oClientes.Existe = False Then
                        Me.LblNombreCliente.Text = "" : GoTo Buscar : Exit Sub
                    End If
                    Me.LblNombreCliente.Text = oClientes.NOMBRE_CLIENTE
                    txtTAB(e)
            End Select
        Catch ex As Exception
            HandleError(Me.Name, "txtCodigoCliente_KeyDown", ex)
        End Try
    End Sub

    Private Sub CmbDocumento_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbDocumento.KeyDown
        txtTAB(e)
    End Sub

    Private Sub CmbDocumento_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbDocumento.SelectedIndexChanged
        If Me.CmbDocumento.SelectedValue <> "T" Then
            Me.oDocumentos = New Class_Cat_tiposDocumentos(Me.CmbDocumento.SelectedValue.ToString)
            If oDocumentos.ES_TRANSFERENCIA = "1" Then
                Me.lblDisplayAlmacen2.Visible = True
                Me.CmbAlmacen2.Visible = True
            Else
                Me.CmbAlmacen2.Visible = False
                Me.lblDisplayAlmacen2.Visible = False
            End If
        End If
    End Sub

    Private Sub CmbAlmacen2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtFechaHasta.KeyDown, DtFechaDesde.KeyDown, CmbAlmacen2.KeyDown, CmbAlmacen.KeyDown, CboEstatus.KeyDown
        txtTAB(e)
    End Sub

    Private Sub RdbMovimientosGlobales_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles RdbMovimientosGlobales.KeyDown, RdbMovimientosDetallados.KeyDown
        txtTAB(e)
    End Sub
End Class