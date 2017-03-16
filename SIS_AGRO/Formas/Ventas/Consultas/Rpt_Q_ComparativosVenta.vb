Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class Rpt_Q_ComparativosVenta
    Private oClientes As New Class_CatClientes

    Public Enum enumComparativo
        VENTA
        CANTIDAD
        PRECIO_PROMEDIO
    End Enum

    Public ModoAgrupado As enumComparativo

    Private Sub Inicializa()
        'Me.TxtFolio.Text = ""
        'Me.LblStatus.Text = "N"
        'Me.LblPoliza.Text = ""
        'Me.dtFecha.Value = Date.Now
        'Me.TxtCodigoProveedor.Text = ""
        'Me.LblProveedor.Text = ""
        Me.CboZona.SelectedValue = "T"
        Me.cboPrecentacion.SelectedValue = "BTO"

        If Empresa_Sistema.Tipo_Contabilidad = "FN" Then
            Me.cboTemporada.Text = "MIXTA"
        Else
            Me.cboTemporada.Text = "ANUAL"
        End If
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

    Private Sub DesplegarPresentaciones()
        Dim oElementos As New Class_Ventas_Global
        With Me.cboPrecentacion
            .DisplayMember = "UNIDAD_VENTA"
            .ValueMember = "UNIDAD_VENTA"

            Dim dView As New Data.DataView(oElementos.ObtenerPresentaciones)
            dView.Sort = "UNIDAD_VENTA"
            .DataSource = dView
            .Text = "TODOS"
        End With
    End Sub

    Private Sub DesplegarMercado()
        Dim oElementos As New Class_CatTiposMercados
        With Me.cboMercado
            .DisplayMember = "NOMBRE_MERCADO"
            .ValueMember = "CODIGO_TIPO_MERCADO"
            Dim dView As New Data.DataView(oElementos.ObtenerTiposMercadosParaReportes())
            dView.Sort = "NOMBRE_MERCADO"
            .DataSource = dView
            .Text = "TODOS"
        End With
    End Sub

    Private Sub Rpt_Ventas_TopTenProductos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DesplegarCultivos()
        Me.DesplegarPresentaciones()
        Me.DesplegarZona()
        Me.DesplegarMercado()
        Me.cboCultivo.Focus()
        Me.Inicializa()

        If Me.ModoAgrupado = enumComparativo.VENTA Then
            Me.Text = Me.Text & " "
            Me.cboMostrar.Text = "VENTA"
        ElseIf Me.ModoAgrupado = enumComparativo.CANTIDAD Then
            Me.Text = Me.Text & " por cantidad "
            Me.cboMostrar.Text = "CANTIDAD"
        Else
            Me.Text = Me.Text & " por precio promedio"
            Me.cboMostrar.Text = "PRECIO_PROMEDIO"
        End If
    End Sub

    Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click
        Me.Imprimir()
    End Sub

    Private Sub Imprimir()
        Dim FormatoDeReporte As String = ""
        Dim Rpt As ReportDocument
        Rpt = New ReportDocument
        Dim oReporte As New Class_Reporte
        Try
            If txtLEN(Me.TxtCliente.Text) = True Then
                Me.oClientes = New Class_CatClientes(Me.TxtCliente.Text)
                If Me.oClientes.Existe = False Then
                    MsgBox("El cliente no existe.", MsgBoxStyle.Information, Me.Text)
                    Me.TxtCliente.Focus()
                    Exit Sub
                End If
            End If

            FormatoDeReporte = "RPT_Q_VENTAS_HISTORICAS_CLIENTE"

            oReporte = New Class_Reporte(FormatoDeReporte, Rpt)
            Rpt.SetParameterValue("@TEMPORADA", Me.cboTemporada.Text())
            Rpt.SetParameterValue("@CODIGO_CULTIVO", Me.cboCultivo.SelectedValue.ToString)
            Rpt.SetParameterValue("@UNIDAD_VENTA", IIf(Me.cboPrecentacion.Text = "TODOS", "", Me.cboPrecentacion.Text))
            Rpt.SetParameterValue("@CODIGO_ZONA", Me.CboZona.SelectedValue.ToString)
            Rpt.SetParameterValue("@CODIGO_TIPO_MERCADO", Me.cboMercado.SelectedValue)
            Rpt.SetParameterValue("@CODIGO_CLIENTE", Me.TxtCliente.Text)
            Rpt.SetParameterValue("@TIPO_CAMBIO", valorNumerico(Me.txtTipoCambio.Text))
            Rpt.SetParameterValue("@COLUMNA_DATOS_A_MOSTRAR", Me.cboMostrar.Text)

            Dim frm As New Reporte(Rpt)
            frm.CRViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            frm.Show()
        Catch ex As Exception
            HandleError(Me.Name, "Imprimir", ex)
        Finally
            oReporte = Nothing
        End Try
    End Sub

    Private Sub cboCultivo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboCultivo.KeyPress, TxtCliente.KeyPress, txtTipoCambio.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub cboCultivo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCultivo.KeyDown, txtTipoCambio.KeyDown
        txtTAB(e)
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub

    Private Sub TxtCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCliente.KeyDown
        Dim sText As String
        Select Case e.KeyCode
            Case Keys.F6
Buscar:
                sText = Me.oClientes.BusquedaVisual_PorDescripcionZona(Me.CboZona.SelectedValue)
                If txtLEN(sText) = True Then Me.TxtCliente.Text = sText
            Case Keys.Enter
                If txtLEN(Me.TxtCliente.Text) = False Then
                    Me.lblNombreCliente.Text = "" : Exit Sub
                End If

                Me.oClientes = New Class_CatClientes(Me.TxtCliente.Text)
                If Me.oClientes.Existe = False Then
                    Me.lblNombreCliente.Text = "" : GoTo Buscar : Exit Sub
                End If

                Me.lblNombreCliente.Text = Me.oClientes.NOMBRE_CLIENTE.ToString
                Me.txtTipoCambio.Focus()
        End Select
        Me.TxtCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    End Sub

    Private Sub txtTipoCambio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTipoCambio.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.tsbImprimir.PerformClick()
        End If
    End Sub

    Private Sub txtTipoCambio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTipoCambio.KeyPress
        Dim txt As TextBox = CType(sender, TextBox)
        txtSoloNumerosDecimales(e, txt.Text)
        txtNoBeep(e)
    End Sub
End Class