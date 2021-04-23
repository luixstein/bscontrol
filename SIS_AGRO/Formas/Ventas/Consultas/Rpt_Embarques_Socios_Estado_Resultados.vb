Imports CrystalDecisions.CrystalReports.Engine

Public Class Rpt_Embarques_Socios_Estado_Resultados

    Private oArticulos As New Class_CatArticulos

#Region "Opciones"
    Private Sub tsbConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbConsultar.Click
        If txtLEN(Me.TxtCodArticulo.Text) = False Then
            MsgBox("Asígne un artículo", MsgBoxStyle.Exclamation, Me.Text)
            Me.TxtCodArticulo.Focus()
            Exit Sub
        End If

        Me.Consultar()
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub

#End Region

#Region "Eventos"
    Private Sub TxtCodArticulo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodArticulo.KeyDown
        Select Case e.KeyCode
            Case Keys.F6, Keys.F7
                oArticulos = New Class_CatArticulos
                Dim sArticulo As String = ""

                If e.KeyCode = Keys.F6 Then
buscar:
                    sArticulo = oArticulos.BusquedaVisual_PorDescripcion
                Else
                    sArticulo = oArticulos.BusquedaVisualInventariables_PorCodigo
                End If

                If sArticulo.Length > 0 Then
                    Me.TxtCodArticulo.Text = sArticulo
                    Me.lblArticulo.Text = oArticulos.BuscarNombreArticulo(sArticulo)
                End If

            Case Keys.Enter
                If txtLEN(Me.TxtCodArticulo.Text) = False Then
                    Me.lblArticulo.Text = ""
                    GoTo buscar : Exit Sub
                End If

                Me.lblArticulo.Text = oArticulos.BuscarNombreArticulo(Me.TxtCodArticulo.Text)
                If txtLEN(Me.lblArticulo.Text) = False Then
                    MsgBox("El artículo no existe.", MsgBoxStyle.Exclamation, Me.Text)
                    Me.lblArticulo.Text = ""
                    GoTo buscar : Exit Sub
                End If

                Me.tsbConsultar.PerformClick()
        End Select
    End Sub
#End Region


#Region "Eventos genéricos"
    Private Sub txt_Enter(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim oTexBox As TextBox = CType(sender, TextBox)
        oTexBox.SelectAll()
    End Sub

    'Private Sub txt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles 
    'txtTAB(e)
    'End Sub

    Private Sub txtKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodArticulo.KeyPress
        txtNoBeep(e)
    End Sub
#End Region

#Region "Métodos y procedimientos"
    Private Sub Consultar()
        Dim StrFiltros As String = ""
        Dim FormatoDeReporte As String = ""
        Dim Rpt As New ReportDocument
        Dim oReporte As Class_Reporte
        Try
            FormatoDeReporte = "RPT_EMBARQUES_SOCIOS_ESTADO_RESULTADOS"
            oReporte = New Class_Reporte(FormatoDeReporte, Rpt)

            Rpt.SetParameterValue("@CODIGO_ARTICULO", Me.TxtCodArticulo.Text)
            Rpt.SetParameterValue("@FORMATO", "SOCIOS")
            Rpt.SetParameterValue("FORMATO_SUBREPORTE", "DETALLE")

            'Rpt.Subreports(0).SetParameterValue("@FORMATO", "DETALLE")

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