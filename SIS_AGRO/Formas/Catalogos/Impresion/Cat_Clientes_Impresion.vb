
Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class Cat_Clientes_Impresion
    Private oClientes As New Class_CatClientes

#Region "Constructor y destructor"
    Public Sub New()
        InitializeComponent()
        DesplegarPlazas()
        DesplegarGirosClientes()
        DesplegarTiposNegociaciones()
        Inicializa()
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
#End Region

#Region "Opciones"

    Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click
        Me.Imprimir()
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub
#End Region

#Region "Eventos Genericos"

    Private Sub txtTextoKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CboEstatus.KeyPress, CboPlazas.KeyPress, CboGiroCliente.KeyPress, CboTipoNegociacion.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub txtCodigoVendedorKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigoVendedor.KeyPress
        txtSoloNumerosEnteros(e)
        txtNoBeep(e)
    End Sub

#End Region

#Region "Métodos y procedimientos"

    Private Sub Inicializa()
        Me.RdbAgrupadoVendedor.Checked = True
        Me.txtCodigoVendedor.Text = ""
        Me.lblNombreVendedor.Text = ""
        Me.CboEstatus.SelectedIndex = 0
    End Sub

    Private Sub Imprimir()
        Dim FormatoDeReporte As String = ""
        Dim Rpt As ReportDocument
        Rpt = New ReportDocument
        Dim oReporte As Class_Reporte

        Try
            If Me.RdbNormal.Checked = True Then
                FormatoDeReporte = "RPT_CATALOGO_CLIENTES"
            Else
                FormatoDeReporte = "RPT_CATALOGO_CLIENTES_AGRUPADO_VENDEDOR"
            End If

            oReporte = New Class_Reporte(FormatoDeReporte, Rpt)

            Rpt.SetParameterValue("@ESTATUS", Strings.Left(Me.CboEstatus.Text, 1))
            Rpt.SetParameterValue("@CODIGO_PLAZA", Me.CboPlazas.SelectedValue.ToString)
            Rpt.SetParameterValue("@CODIGO_GIRO", Me.CboGiroCliente.SelectedValue.ToString)
            Rpt.SetParameterValue("@CODIGO_TIPO_NEGOCIACION", Me.CboTipoNegociacion.SelectedValue.ToString)

            If Me.RdbAgrupadoVendedor.Checked Then
                Rpt.SetParameterValue("@CODIGO_VENDEDOR", Me.txtCodigoVendedor.Text)
            End If

            Dim frm As New Reporte(Rpt)
            frm.CRViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            frm.Show()
        Catch ex As Exception
            HandleError(Me.Name, "Reporte de cxp", ex)
        Finally
            oReporte = Nothing
        End Try
    End Sub

    Private Sub DesplegarPlazas()
        Dim oElemento As New Class_SisPlazas

        With Me.CboPlazas
            .DisplayMember = "NOMBRE_PLAZA"
            .ValueMember = "CODIGO_PLAZA"
            Dim dView As New Data.DataView(oElemento.ObtenerElementosParaReporte())
            dView.Sort = "NOMBRE_PLAZA"
            .DataSource = dView
            .SelectedValue = 0
        End With
    End Sub

    Private Sub DesplegarGirosClientes()
        Dim oElemento As New Class_CatGirosClientes

        With Me.CboGiroCliente
            .DisplayMember = "NOMBRE_GIRO"
            .ValueMember = "CODIGO_GIRO"
            Dim dView As New Data.DataView(oElemento.ObtenerElementosParaReportes())
            dView.Sort = "NOMBRE_GIRO"
            .DataSource = dView
            .SelectedValue = -1
        End With
    End Sub

    Private Sub DesplegarTiposNegociaciones()
        Try
            Dim oElementos As New Class_CatTiposNegociaciones
            With Me.cboTipoNegociacion
                .DisplayMember = "NOMBRE_TIPO_NEGOCIACION"
                .ValueMember = "CODIGO_TIPO_NEGOCIACION"
                Dim dView As New Data.DataView(oElementos.ObtenerTiposNegociacionesParaReportes)
                dView.Sort = "NOMBRE_TIPO_NEGOCIACION"
                .DataSource = dView
                    .SelectedValue = "T"
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarTiposNegociaciones", ex)
        End Try
    End Sub

#End Region

    Private Sub txtCodigoVendedor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigoVendedor.KeyDown
        Dim sText As String
        Dim oVendedor As New Class_CatVendedores

        Select Case e.KeyCode
            Case Keys.F6
Buscar:
                sText = oVendedor.BusquedaVisual_PorDescripcion
                If txtLEN(sText) = True Then Me.txtCodigoVendedor.Text = sText
            Case Keys.Enter
                If txtLEN(Me.txtCodigoVendedor.Text) = False Then
                    Me.lblNombreVendedor.Text = ""
                    Exit Sub
                End If

                oVendedor = New Class_CatVendedores(Me.txtCodigoVendedor.Text)
                If oVendedor.Existe = False Then
                    Me.lblNombreVendedor.Text = "" : GoTo Buscar : Exit Sub
                End If

                Me.lblNombreVendedor.Text = oVendedor.NOMBRE_VENDEDOR
                Me.tsbImprimir.PerformClick()
        End Select
    End Sub

    Private Sub Rdb_CheckedChanged(sender As Object, e As EventArgs) Handles RdbNormal.CheckedChanged, RdbAgrupadoVendedor.CheckedChanged
        If Me.RdbAgrupadoVendedor.Checked Then
            Me.lblDisplayVendedor.Visible = True : Me.txtCodigoVendedor.Visible = True : Me.lblNombreVendedor.Visible = True
            Me.txtCodigoVendedor.Text = "" : lblNombreVendedor.Text = ""
        Else
            Me.lblDisplayVendedor.Visible = False : Me.txtCodigoVendedor.Visible = False : Me.lblNombreVendedor.Visible = False
        End If

    End Sub

End Class