Option Strict On
Imports CrystalDecisions.CrystalReports.Engine

Public Class Rpt_Cxp_Auxiliar_proveedor
    Private oProveedores As New Class_CatProveedores

    Private Sub TxtProveedor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtProveedor.KeyDown
        Dim sText As String
        Select Case e.KeyCode
            Case Keys.F6
Buscar:
                sText = Me.oProveedores.BusquedaVisual_PorDescripcion
                If txtLEN(sText) = True Then Me.TxtProveedor.Text = sText
            Case Keys.Enter
                If txtLEN(Me.TxtProveedor.Text) = False Then
                    Me.LblProveedor.Text = "" : GoTo Buscar : Exit Sub
                End If

                Me.oProveedores = New Class_CatProveedores(Me.TxtProveedor.Text)
                If Me.oProveedores.Existe = False Then
                    Me.LblProveedor.Text = "" : GoTo Buscar : Exit Sub
                End If

                Me.LblProveedor.Text = Me.oProveedores.Nombre_Proveedor
                txtTAB(e)
        End Select
    End Sub

    Private Sub DtFechaDesde_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtFechaDesde.KeyDown
        txtTAB(e)
    End Sub

    Private Sub DtFechaHasta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtFechaHasta.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.tsbConsultar.PerformClick()
        End If
    End Sub

    Private Sub tsbConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbConsultar.Click
        Consultar()
    End Sub

    Private Sub Consultar()
        Dim FormatoDeReporte As String = ""
        Dim Rpt As ReportDocument
        Rpt = New ReportDocument
        Dim oReporte As Class_Reporte

        If txtLEN(Me.TxtProveedor.Text) = False Then
            MsgBox("Asígne un proveedor", MsgBoxStyle.Exclamation, Me.Text)
            Me.TxtProveedor.Focus()
            Exit Sub
        End If

        Me.oProveedores = New Class_CatProveedores(Me.TxtProveedor.Text)
        If Me.oProveedores.Existe = False Then
            MsgBox("Asígne un proveedor valido", MsgBoxStyle.Exclamation, Me.Text)
            Me.TxtProveedor.Focus()
            Exit Sub
        End If

        If Me.ValidarPeriodo = False Then
            Exit Sub
        End If

        If Me.rbtAuxiliarSaldos.Checked = True Then
            FormatoDeReporte = "RPT_CXP_AUXILIAR_PROVEEDOR"
        ElseIf Me.rbtAnalisisSaldos.Checked = True Then
            FormatoDeReporte = "RPT_CXP_ANALISIS_SALDOS_PROVEEDOR"
        End If

        Try
            oReporte = New Class_Reporte(FormatoDeReporte, Rpt, True)
            If Not oReporte.RptCargado Then
                Exit Sub
            End If

            Rpt.SetParameterValue("@CODIGO_PROVEEDOR", Me.TxtProveedor.Text.ToUpper)
            Rpt.SetParameterValue("@FECHA_INICIO", Format(Me.DtFechaDesde.Value, "yyyy-dd-MM"))
            Rpt.SetParameterValue("@FECHA_FIN", Format(Me.DtFechaHasta.Value, "yyyy-dd-MM"))

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
            Exit Function
        End If
        ValidarPeriodo = True
    End Function

    Private Sub Rpt_Cxp_Auxiliar_proveedor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.LblProveedor.Text = ""
        Me.DtFechaDesde.Value = CDate(Format(Date.Now, "01-MM-yyyy"))
        Me.DtFechaHasta.Value = Date.Now
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub
End Class