Option Strict On

Imports CrystalDecisions.CrystalReports.Engine

Public Class Rpt_Ventas_Calificas

#Region "Opciones"
    Private Sub tsbConsultar_Click(sender As Object, e As EventArgs) Handles tsbConsultar.Click
        Me.Consultar()
    End Sub

    Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub
#End Region

#Region "Eventos de objetos"

#Region "Eventos Genericos"
    Private Sub txtKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DtFechaDesde.KeyPress, DtFechaHasta.KeyPress, txtCliente.KeyPress, txtCodigoArticulo.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub txtKeyPressSoloNumerosEnteros(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigoZona.KeyPress, txtTop.KeyPress
        txtNoBeep(e)
        txtSoloNumerosEnteros(e)
    End Sub
#End Region

    Private Sub Rpt_Ventas_Calificas_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.DtFechaDesde.Value = FechaActualINI()
        Me.DtFechaHasta.Value = Date.Now
    End Sub

    Private Sub txtCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCliente.KeyDown
        Try
            Dim sText As String, oCliente As New Class_CatClientes
            Select Case e.KeyCode
                Case Keys.F6
Buscar:
                    sText = oCliente.BusquedaVisual_PorDescripcion
                    If txtLEN(sText) = True Then Me.txtCliente.Text = sText

                Case Keys.Enter
                    If txtLEN(Me.txtCliente.Text) = False Then
                        Me.lblNombreCliente.Text = ""
                    Else
                        oCliente = New Class_CatClientes(Me.txtCliente.Text)
                        If oCliente.Existe = False Then
                            Me.lblNombreCliente.Text = "" : GoTo Buscar : Exit Sub
                        End If

                        Me.lblNombreCliente.Text = oCliente.NOMBRE_CLIENTE
                    End If

                    txtTAB(e)
            End Select
        Catch ex As Exception
            HandleError(Me.Name, "txtCliente_KeyDown", ex)
        End Try
    End Sub

    Private Sub txtCodigoZona_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCodigoZona.KeyDown
        Try
            Dim sText As String, oZona As New Class_CatZonas
            Select Case e.KeyCode
                Case Keys.F6
Buscar:
                    sText = oZona.BusquedaVisual_PorDescripcion
                    If txtLEN(sText) = True Then Me.txtCodigoZona.Text = sText

                Case Keys.Enter
                    If txtLEN(Me.txtCodigoZona.Text) = False Then
                        Me.lblNombreZona.Text = ""
                    Else
                        oZona = New Class_CatZonas(Me.txtCodigoZona.Text)
                        If oZona.Existe = False Then
                            Me.lblNombreZona.Text = "" : GoTo Buscar : Exit Sub
                        End If

                        Me.lblNombreZona.Text = oZona.NOMBRE_ZONA
                    End If

                    txtTAB(e)
            End Select
        Catch ex As Exception
            HandleError(Me.Name, "txtCodigoZona_KeyDown", ex)
        End Try
    End Sub

    Private Sub txtCodigoArticulo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCodigoArticulo.KeyDown
        Try
            Dim sText As String, oArticulo As New Class_CatArticulos
            Select Case e.KeyCode
                Case Keys.F6
Buscar:
                    sText = oArticulo.BusquedaVisual_PorDescripcion
                    If txtLEN(sText) = True Then Me.txtCodigoArticulo.Text = sText

                Case Keys.Enter
                    If txtLEN(Me.txtCodigoArticulo.Text) = False Then
                        Me.lblNombreArticulo.Text = ""
                    Else
                        oArticulo = New Class_CatArticulos(Me.txtCodigoArticulo.Text)
                        If oArticulo.Existe = False Then
                            Me.lblNombreArticulo.Text = "" : GoTo Buscar : Exit Sub
                        End If

                        Me.lblNombreArticulo.Text = oArticulo.DESCRIPCION
                    End If

                    txtTAB(e)
            End Select
        Catch ex As Exception
            HandleError(Me.Name, "txtCodigoArticulo_KeyDown", ex)
        End Try
    End Sub

    Private Sub txtTop_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTop.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.tsbConsultar.PerformClick()
        End If
    End Sub
#End Region

#Region "Métodos y procedimientos"
    Private Sub Consultar()
        Dim FormatoDeReporte As String = ""
        Dim Rpt As New ReportDocument
        Dim oReporte As Class_Reporte
        Try
            If Me.rdnCalificaProductoFlujo.Checked = True Then
                FormatoDeReporte = "RPT_Q_CALIFICA_PRODUCTOS_FLUJO_HORIZONTAL"
                'ElseIf Me.algo.Checked= True Then
                'FormatoDeReporte = ""
            End If

            oReporte = New Class_Reporte(FormatoDeReporte, Rpt)

            Rpt.SetParameterValue("@CODIGO_ARTICULO", Me.txtCodigoArticulo.Text)
            Rpt.SetParameterValue("@CODIGO_CLIENTE", Me.txtCliente.Text)
            Rpt.SetParameterValue("@CODIGO_ZONA", Me.txtCodigoZona.Text)
            Rpt.SetParameterValue("@FECHA1", Format(Me.DtFechaDesde.Value, "yyyy-dd-MM"))
            Rpt.SetParameterValue("@FECHA2", Format(Me.DtFechaHasta.Value, "yyyy-dd-MM"))
            Rpt.SetParameterValue("@FECHA_CORTE", Format(Me.DtFechaHasta.Value, "yyyy-dd-MM"))
            Rpt.SetParameterValue("@TOP_#", Me.txtTop.Text)

            Dim frm As New Reporte(Rpt)
            frm.CRViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            frm.Show()
        Catch ex As Exception
            HandleError(Me.Name, "Consultar", ex)
        Finally
            oReporte = Nothing
        End Try
    End Sub

#End Region

End Class