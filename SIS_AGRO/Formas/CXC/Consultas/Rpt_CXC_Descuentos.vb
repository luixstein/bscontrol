Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class Rpt_CXC_Descuentos
    Private oClientes As New Class_CatClientes

#Region "Constructor y destructor"
    Public Sub New()
        InitializeComponent()
        Me.DesplegarEstatus()
        Me.Inicializa()
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

    Private Sub txtTextoKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigoCliente.KeyPress, _
         DtFechaDesde.KeyPress, DtFechaHasta.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub txtNumerosEnterosKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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
                    Me.DtFechaDesde.Focus()
                    Exit Sub
                End If

                oClientes = New Class_CatClientes(Me.txtCodigoCliente.Text)
                If Me.oClientes.Existe = False Then
                    Me.lblNombreCliente.Text = "" : GoTo Buscar : Exit Sub
                End If

                Me.lblNombreCliente.Text = Me.oClientes.NOMBRE_CLIENTE
                'Me.txtCodigoVendedor.Focus()
                Me.DtFechaDesde.Focus()
        End Select
    End Sub

    Private Sub dpFechaInicio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtFechaDesde.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.DtFechaHasta.Focus()
        End If
    End Sub

    Private Sub dpFechaFinal_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtFechaHasta.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.CboEstatus.Focus()
        End If
    End Sub

    Private Sub CboDocumentos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Return Then
            Me.tsbImprimir.PerformClick()
        End If
    End Sub

#End Region

#Region "Métodos y procedimientos"

    Private Sub Inicializa()
        Me.DesplegarEstatus()
        ' Me.DesplegarEstatus()
        Me.CboEstatus.SelectedValue = "T"
        Me.DtFechaDesde.Value = CDate(Format(Date.Now, "01-MM-yyyy"))
        Me.DtFechaHasta.Value = Date.Now
    End Sub

    Private Sub DesplegarEstatus()
        Try
            Dim oElementos As New Class_CXC_Descuento
            With Me.CboEstatus
                .DisplayMember = "NOMBRE_ESTATUS"
                .ValueMember = "CODIGO_ESTATUS"
                Dim dView As New Data.DataView(oElementos.ObtenerEstatusParaReportes())
                dView.Sort = "NOMBRE_ESTATUS"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedIndex = 0
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarEstatus", ex)
        End Try
    End Sub

    Private Sub Imprimir()
        Dim StrFiltros As String = ""
        Dim Rpt As New ReportDocument
        Dim oReporte As Class_Reporte
        Try

            'Es filtro opcional no debe validarse
            'oClientes = New Class_CatClientes(Me.txtCodigoCliente.Text)
            'If Me.oClientes.Existe = False Then
            '    MsgBox("El código de cliente que intenta buscar no existe o esta dado de Baja, favor de intentar con otro código.", MsgBoxStyle.Critical, "Validación de Cliente")
            '    Me.lblNombreCliente.Text = ""
            '    Me.txtCodigoCliente.Focus()
            '    Exit Sub
            'End If

            If Me.ValidarPeriodo = False Then
                Exit Sub
            End If

            oReporte = New Class_Reporte("RPT_CXC_DESCUENTOS", Rpt)

            If Not oReporte.RptCargado Then
                Exit Sub
            End If

            Rpt.SetParameterValue("@FECHA1", Format(Me.DtFechaDesde.Value, "yyyy-dd-MM"))
            Rpt.SetParameterValue("@FECHA2", Format(Me.DtFechaHasta.Value, "yyyy-dd-MM"))
            Rpt.SetParameterValue("@ESTATUS_DESCUENTO", Me.CboEstatus.SelectedValue.ToString)
            Rpt.SetParameterValue("@CODIGO_CLIENTE", Me.txtCodigoCliente.Text)

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
        If Me.DtFechaDesde.Value > Me.DtFechaHasta.Value Then
            MsgBox("Rango de fechas inválidas.", MsgBoxStyle.Exclamation, Me.Name)
            Exit Function
        End If
        Return True
    End Function

#End Region

End Class