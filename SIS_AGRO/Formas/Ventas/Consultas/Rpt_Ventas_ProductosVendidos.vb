Option Strict On

Imports CrystalDecisions.CrystalReports.Engine

Public Class Rpt_Ventas_ProductosVendidos

    Private oArticulos As New Class_CatArticulos
    Private oClientes As New Class_CatClientes

    Private Sub TxtClientes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCliente.KeyDown
        Dim sText As String
        Select Case e.KeyCode
            Case Keys.F6
Buscar:
                sText = Me.oClientes.BusquedaVisual_PorDescripcion
                If txtLEN(sText) = True Then Me.TxtCliente.Text = sText
            Case Keys.Enter
                If txtLEN(Me.TxtCliente.Text) = False Then
                    Me.lblNombreCliente.Text = ""
                    Me.CkbFechaReferencia.Focus()
                    Exit Sub
                End If

                Me.oClientes = New Class_CatClientes(Me.TxtCliente.Text)
                If Me.oClientes.Existe = False Then
                    Me.lblNombreCliente.Text = "" : GoTo Buscar : Exit Sub
                End If

                Me.lblNombreCliente.Text = Me.oClientes.NOMBRE_CLIENTE
                txtTAB(e)
        End Select
    End Sub

    Private Sub TxtCodigoProducto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodigoProducto.KeyDown
        Dim sText As String
        Select Case e.KeyCode
            Case Keys.F6
Buscar:
                sText = Me.oArticulos.BusquedaVisual_PorDescripcion
                If txtLEN(sText) = True Then Me.TxtCodigoProducto.Text = sText
            Case Keys.Enter
                If txtLEN(Me.TxtCodigoProducto.Text) = False Then
                    Me.LblNombreProducto.Text = ""
                    Me.CboAlmacen.Focus()
                    Exit Sub
                End If

                Me.oArticulos = New Class_CatArticulos(Me.TxtCodigoProducto.Text)
                If Me.oArticulos.Existe = False Then
                    Me.LblNombreProducto.Text = "" : GoTo Buscar : Exit Sub
                End If

                Me.LblNombreProducto.Text = Me.oArticulos.DESCRIPCION
                txtTAB(e)
        End Select
    End Sub

    Private Sub Rdn_CheckedChanged(sender As Object, e As EventArgs) Handles RdnVentasPorCultivo.CheckedChanged, RdnVentasPorFacturas.CheckedChanged, RdnDevoluciones.CheckedChanged
        If Me.RdnDevoluciones.Checked = True Then
            Me.CboTipoDocumento.Visible = False
            Me.lblDocumentos.Visible = False
            Me.CkbFechaReferencia.Visible = False
            Me.CboMercado.Visible = False
            Me.CboCultivoAgricola.Visible = False
            Me.LblDisplayMercado.Visible = False
            Me.lblCultivoAgricola.Visible = False
            Me.cboVendedor.Visible = False
        Else
            Me.CboTipoDocumento.Visible = True
            Me.lblDocumentos.Visible = True
            Me.CkbFechaReferencia.Visible = True
            Me.CboMercado.Visible = True
            Me.CboCultivoAgricola.Visible = True
            Me.LblDisplayMercado.Visible = True
            Me.lblCultivoAgricola.Visible = True
            Me.cboVendedor.Visible = True
        End If
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

    Private Sub DesplegarLineas()
        Dim oLinea As New Class_CatLineas
        Try
            With Me.CboLinea
                .DisplayMember = "NOMBRE_LINEA"
                .ValueMember = "CODIGO_LINEA"

                Dim dView As New Data.DataView(oLinea.ObtenerElementosParaReportes)
                dView.Sort = "NOMBRE_LINEA"
                .DataSource = dView
                .Text = "TODAS"
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarLineas", ex)
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

    Private Sub DesplegarFamilias()
        Dim oFamilia As New Class_CatFamilias
        Try
            With Me.CboFamilia
                .DisplayMember = "NOMBRE_FAMILIA"
                .ValueMember = "CODIGO_FAMILIA"

                Dim dView As New Data.DataView(oFamilia.ObtenerElementosParaReportes())
                dView.Sort = "NOMBRE_FAMILIA"
                .DataSource = dView
                .Text = "TODAS"
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarFamilias", ex)
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
                .Text = "TODOS"
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarZonas", ex)
        End Try
    End Sub

    Private Sub DesplegarCultivos()
        Dim oCultivos As New Class_CatCultivos
        Try
            With Me.CboCultivoAgricola
                .DisplayMember = "NOMBRE_CULTIVO"
                .ValueMember = "CODIGO_CULTIVO"

                Dim dView As New Data.DataView(oCultivos.ObtenerElementosParaReportes())
                dView.Sort = "NOMBRE_CULTIVO"
                .DataSource = dView
                .Text = "TODOS"
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarCultivos", ex)
        End Try
    End Sub

    Private Sub DesplegarVendedores()
        Dim oVendedores As New Class_CatVendedores
        Try
            With Me.cboVendedor
                .DisplayMember = "NOMBRE_VENDEDOR"
                .ValueMember = "CODIGO_VENDEDOR"

                Dim dView As New Data.DataView(oVendedores.ObtenerVendedoresParaReportes())
                dView.Sort = "NOMBRE_VENDEDOR"
                .DataSource = dView
                .SelectedValue = 0
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarVendedores", ex)
        End Try
    End Sub

    Private Sub Rpt_Embarques_Empaque_Y_Embarque_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DesplegarTiposDocumentos()
        Me.DesplegarZonas()
        Me.DesplegarAlmacen()
        Me.DesplegarMercados()
        Me.DesplegarLineas()
        Me.DesplegarFamilias()
        Me.DesplegarCultivos()
        Me.DesplegarVendedores()

        Me.DtFechaDesde.Value = FechaActualINI()
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

            If Me.RdnVentasPorFacturas.Checked = True Then
                FormatoDeReporte = "RPT_VENTAS_AGRUPADO_FACTURA"
            ElseIf Me.RdnVentasPorCultivo.Checked = True Then
                FormatoDeReporte = "RPT_VENTAS_AGRUPADO_CULTIVO"
            Else
                FormatoDeReporte = "RPT_CXC_DEVOLUCIONES"
            End If

            oReporte = New Class_Reporte(FormatoDeReporte, Rpt)
            Rpt.SetParameterValue("@FECHA1", Format(Me.DtFechaDesde.Value, "yyyy-dd-MM"))
            Rpt.SetParameterValue("@FECHA2", Format(Me.DtFechaHasta.Value, "yyyy-dd-MM"))
            Rpt.SetParameterValue("@CODIGO_CLIENTE", Me.TxtCliente.Text)
            Rpt.SetParameterValue("@CODIGO_ZONA", Me.CboZona.SelectedValue.ToString)
            Rpt.SetParameterValue("@CODIGO_ARTICULO", Me.TxtCodigoProducto.Text)
            Rpt.SetParameterValue("@CODIGO_ALMACEN", Me.CboAlmacen.SelectedValue.ToString)
            Rpt.SetParameterValue("@CODIGO_LINEA", Me.CboLinea.SelectedValue.ToString)
            Rpt.SetParameterValue("@CODIGO_FAMILIA", Me.CboFamilia.SelectedValue.ToString)
            Rpt.SetParameterValue("@CODIGO_USUARIO", Usuario.Codigo_Usuario.ToString)
            Rpt.SetParameterValue("@CODIGO_VENDEDOR", Me.cboVendedor.SelectedValue)

            If Me.RdnDevoluciones.Checked = False Then
                Rpt.SetParameterValue("@CODIGO_TIPO_DOCUMENTO", Me.CboTipoDocumento.SelectedValue.ToString)
                Rpt.SetParameterValue("@FILTRAR_FECHA_REFERENCIA", IIf(Me.CkbFechaReferencia.Checked = True, "1", "0"))
                Rpt.SetParameterValue("@CODIGO_TIPO_MERCADO", Me.CboMercado.SelectedValue.ToString)
                Rpt.SetParameterValue("@CODIGO_CULTIVO", IIf(txtLEN(Me.CboCultivoAgricola.SelectedValue.ToString) = True, Me.CboCultivoAgricola.SelectedValue.ToString, "T"))
                Rpt.SetParameterValue("@SOLO_CON_UTILIDAD_NEGATIVA", IIf(Me.chkSoloUtilidadNegativa.Checked = True, "1", "0"))
            End If

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
        ValidarPeriodo = True
    End Function

    Private Sub TxtCodArticulo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CboTipoDocumento.KeyPress, CboZona.KeyPress, TxtCliente.KeyPress, CkbFechaReferencia.KeyPress, _
    TxtCodigoProducto.KeyPress, CboAlmacen.KeyPress, CboMercado.KeyPress, CboLinea.KeyPress, CboFamilia.KeyPress, CboCultivoAgricola.KeyPress, DtFechaHasta.KeyPress, DtFechaDesde.KeyPress, DtFechaHasta.KeyPress, DtFechaDesde.KeyPress, cboVendedor.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub cboCultivo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CboTipoDocumento.KeyDown, CboZona.KeyDown, TxtCliente.KeyDown, CkbFechaReferencia.KeyDown, _
    TxtCodigoProducto.KeyDown, CboAlmacen.KeyDown, CboMercado.KeyDown, CboLinea.KeyDown, CboFamilia.KeyDown, CboCultivoAgricola.KeyDown, DtFechaHasta.KeyDown, DtFechaDesde.KeyDown, cboVendedor.KeyDown
        txtTAB(e)
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

End Class