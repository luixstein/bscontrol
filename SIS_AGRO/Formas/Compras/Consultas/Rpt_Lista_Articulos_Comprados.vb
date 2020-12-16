Imports CrystalDecisions.CrystalReports.Engine

Public Class Rpt_Lista_Articulos_Comprados

    Private Sub TxtCodArticulo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodArticulo.KeyDown
        Dim oArticulos As New Class_CatArticulos
        Select Case e.KeyCode
            Case Keys.F6, Keys.F7
                oArticulos = New Class_CatArticulos
                Dim sArticulo As String = ""

                If e.KeyCode = Keys.F6 Then
                    sArticulo = oArticulos.BusquedaVisualInventariables_PorDescripcion
                ElseIf e.KeyCode = Keys.F7 Then
                    sArticulo = oArticulos.BusquedaVisualInventariables_PorCodigo
                End If

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

    Private Sub TxtCodigoProveedor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodigoProveedor.KeyDown
        Dim sText As String
        Dim oProveedor As New Class_CatProveedores
        Select Case e.KeyCode
            Case Keys.F6
Buscar:
                sText = oProveedor.BusquedaVisual_PorDescripcion
                If txtLEN(sText) = True Then
                    Me.TxtCodigoProveedor.Text = sText
                    GoTo Enter : Exit Sub
                End If

            Case Keys.Enter
                If txtLEN(Me.TxtCodigoProveedor.Text) = False Then
                    Me.LblNombreProveedor.Text = "" : GoTo Buscar : Exit Sub
                End If
Enter:
                oProveedor = New Class_CatProveedores(Me.TxtCodigoProveedor.Text)
                If oProveedor.Existe = False Then
                    Me.LblNombreProveedor.Text = "" : GoTo Buscar : Exit Sub
                End If

                Me.LblNombreProveedor.Text = oProveedor.Nombre_Proveedor

                txtTAB(e)
        End Select
    End Sub

#Region "Métodos y procedimientos"

    Private Sub Consultar()
        Dim StrFiltros As String = ""
        Dim FormatoDeReporte As String = ""
        Dim Rpt As New ReportDocument
        Dim oReporte As Class_Reporte

        Try
            If Me.ValidarPeriodo = False Then
                Exit Sub
            End If

            FormatoDeReporte = "RPT_COMPRAS_LISTA_ARTICULOS"

            oReporte = New Class_Reporte(FormatoDeReporte, Rpt)
            Rpt.SetParameterValue("@CODIGO_ARTICULO", Me.TxtCodArticulo.Text)
            Rpt.SetParameterValue("@CODIGO_ALMACEN", Me.CmbAlmacen.SelectedValue.ToString())
            Rpt.SetParameterValue("@CODIGO_PROVEEDOR", Me.TxtCodigoProveedor.Text)
            Rpt.SetParameterValue("@CODIGO_USUARIO", Usuario.Codigo_Usuario)
            Rpt.SetParameterValue("@FECHA_1", Format(Me.DtFechaDesde.Value, "yyyy-dd-MM"))
            Rpt.SetParameterValue("@FECHA_2", Format(Me.DtFechaHasta.Value, "yyyy-dd-MM"))
            

            Dim frm As New Reporte(Rpt)
            frm.CRViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            frm.Show()
        Catch ex As Exception
            HandleError(Me.Name, "Consultar", ex)
        Finally
            oReporte = Nothing
        End Try
    End Sub

    Private Sub DesplegarAlmacenes()
        Try
            Dim oElementos As New Class_CatAlmacenes
            With Me.CmbAlmacen
                .DisplayMember = "NOMBRE_ALMACEN"
                .ValueMember = "CODIGO_ALMACEN"
                Dim dView As New Data.DataView(oElementos.ObtenerAlmacenesParaReportes)
                dView.Sort = "NOMBRE_ALMACEN"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedValue = "T"
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarAlmacenes", ex)
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

    Private Sub txtKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodArticulo.KeyPress, TxtCodigoProveedor.KeyPress, DtFechaDesde.KeyPress, DtFechaHasta.KeyPress, CmbAlmacen.KeyPress
        txtNoBeep(e)
    End Sub
#End Region

#Region "Keydown específicos"

#End Region

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub

    Private Sub Inventario_Existencias_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DesplegarAlmacenes()
        Me.DtFechaDesde.Value = Format(Date.Now, "01-MM-yyyy")
        Me.DtFechaHasta.Value = Date.Now
    End Sub

    Private Sub tsbConsultar_Click(sender As Object, e As EventArgs) Handles tsbConsultar.Click
        Me.Consultar()
    End Sub
End Class