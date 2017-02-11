Imports CrystalDecisions.CrystalReports.Engine

Public Class Rpt_Inventario_Lotes_Costos
    Private oArticulos As New Class_CatArticulos

    Private Sub tsbConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbConsultar.Click
        Me.Consultar()
    End Sub
#Region "Métodos y procedimientos"

    Private Sub Consultar()
        Dim StrFiltros As String = ""
        Dim FormatoDeReporte As String = ""
        Dim Rpt As ReportDocument
        Rpt = New ReportDocument
        Dim oReporte As Class_Reporte
        Try
            FormatoDeReporte = "RPT_INVENTARIO_MOVIMIENTOS_LOTES_COSTOS"
            oReporte = New Class_Reporte(FormatoDeReporte, Rpt)
            Rpt.SetParameterValue("@CODIGO_ARTICULO", Me.TxtCodArticulo.Text.ToUpper)
            Rpt.SetParameterValue("@CODIGO_ALMACEN", Me.CmbAlmacen.SelectedValue.ToString())

            Dim frm As New Reporte(Rpt)
            frm.CRViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            frm.Show()
        Catch ex As Exception
            HandleError(Me.Name, "Reporte de Movimientos Detallado", ex)
        Finally
            oReporte = Nothing
            'Rpt.Dispose()
        End Try
    End Sub

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
    End Sub
#End Region

#Region "Eventos de la lista de elementos"

#End Region

#Region " Eventos de TxtFiltro"

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

    Private Sub txtKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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

#Region "Validating específicos"

#End Region
#Region "CheckedChanged"

#End Region

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub

    Private Sub Inventario_Existencias_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DesplegarAlmacenes()
    End Sub

    Private Sub TxtCodArticulo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodArticulo.KeyDown
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
                    lblArticulo.Text = ""
                    txtTAB(e)
                    Exit Sub
                Else
                    txtTAB(e)
                End If
            Case Keys.Escape
        End Select
    End Sub
End Class