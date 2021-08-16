Imports CrystalDecisions.CrystalReports.Engine

Public Class Rpt_Inventario_Existencias

    Private Sub tsbConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbConsultar.Click
        Me.Consultar()
    End Sub

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

    Private Sub txtCodigoSocio_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCodigoSocio.KeyDown
        Dim oUsuario As New Class_sisUsuarios
        Try
            Select Case e.KeyCode
                Case Keys.F6
Buscar:
                    Dim sUsuario As String = oUsuario.BusquedaVisual_PorDescripcion()
                    If txtLEN(sUsuario) = True Then
                        Me.txtCodigoSocio.Text = sUsuario
                        GoTo Enter : Return
                    End If

                Case Keys.Enter
                    If txtLEN(Me.txtCodigoSocio.Text) = False Then
                        Me.txtCodigoSocio.Text = ""
                        GoTo Buscar : Return
                    End If
Enter:
                    oUsuario = New Class_sisUsuarios(CInt(valorNumerico(Me.txtCodigoSocio.Text)))

                    If oUsuario.Existe = False Then
                        Me.lblNombreSocio.Text = ""
                        GoTo Buscar : Return
                    ElseIf oUsuario.ESTATUS = "B" Then
                        MsgBox("El usuario " & Me.txtCodigoSocio.Text & " está dado de baja.", MsgBoxStyle.Exclamation, Me.Text)
                        GoTo Buscar : Return
                    End If

                    Me.lblNombreSocio.Text = oUsuario.Nombre_Usuario

                    txtTAB(e)
            End Select

        Catch ex As Exception
            HandleError(Me.Name, "TxtCodigoSocio_KeyDown", ex)
        End Try
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

            If (Me.rbtnParaInventario.Checked = True) Then
                FormatoDeReporte = "RPT_INVENTARIO_EXISTENCIAS_TOMA_INVENTARIO"
            End If
            If (Me.rbtnPorFamilias.Checked = True) Then
                FormatoDeReporte = "RPT_INVENTARIO_EXISTENCIAS_AGRUPADO_FAMILIAS"
            End If
            If (Me.rbtnConCostos.Checked = True) Then
                FormatoDeReporte = "RPT_INVENTARIO_EXISTENCIAS_ACTUALES"
            End If
            If (Me.rbtnSeries.Checked = True) Then
                FormatoDeReporte = "RPT_INVENTARIO_EXISTENCIAS_SERIES"
            End If
            If (Me.rbtnSocio.Checked = True) Then
                FormatoDeReporte = "RPT_INVENTARIO_EXISTENCIAS_POR_SOCIO"
            End If

            oReporte = New Class_Reporte(FormatoDeReporte, Rpt)
            Rpt.SetParameterValue("@CODIGO_ARTICULO", Me.TxtCodArticulo.Text)
            Rpt.SetParameterValue("@CODIGO_ALMACEN", Me.CmbAlmacen.SelectedValue.ToString())
            Rpt.SetParameterValue("@OCULTAR_ARTICULOS_CON_EXISTENCIA_EN_CERO", Convert.ToInt32(Me.CHSoloExistencia.Checked))
            Rpt.SetParameterValue("@FILTRAR_POR_MOVIMIENTOS_EN_RANGO_DE_FECHAS", Convert.ToInt32(Me.ChkFechas.Checked))
            Rpt.SetParameterValue("@FECHA_MOVIMIENTO_1", Format(Me.DtFechaDesde.Value, "yyyy-dd-MM"))
            Rpt.SetParameterValue("@FECHA_MOVIMIENTO_2", Format(Me.DtFechaHasta.Value, "yyyy-dd-MM"))

            If rbtnSocio.Checked = False Then
                Rpt.SetParameterValue("@CODIGO_USUARIO", Usuario.Codigo_Usuario)

                If Me.CboFamilia.Text = "TODAS" Then
                    Rpt.SetParameterValue("@CODIGO_FAMILIA", "T")
                Else
                    Rpt.SetParameterValue("@CODIGO_FAMILIA", Me.CboFamilia.SelectedValue.ToString)
                End If
                Rpt.SetParameterValue("@EXCLUIR_FAMILIA", Convert.ToInt32(Me.chkExcluirfamilia.Checked))

            Else
                Rpt.SetParameterValue("@CODIGO_USUARIO_SOCIO", CInt(valorNumerico(Me.txtCodigoSocio.Text)))
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
                    .SelectedIndex = 0
                End If
                .SelectedValue = Usuario.Codigo_Almacen
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarAlmacenes", ex)
        End Try
    End Sub

    Private Sub DesplegarFamilias()
        Try
            Dim oElementos As New Class_CatFamilias
            With Me.CboFamilia
                .DisplayMember = "NOMBRE_FAMILIA"
                .ValueMember = "CODIGO_FAMILIA"
                Dim dView As New Data.DataView(oElementos.ObtenerElementosParaReportes)
                dView.Sort = "NOMBRE_FAMILIA"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedValue = "T"
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarFamilias", ex)
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

#Region "Eventos de la lista de elementos"

#End Region

#Region "Eventos de TxtFiltro"

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

    Private Sub txtKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodArticulo.KeyPress, txtCodigoSocio.KeyPress
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
        Me.DtFechaDesde.Value = Format(Date.Now, "01-MM-yyyy")
        Me.DtFechaHasta.Value = Date.Now
        Me.DesplegarFamilias()
        Me.rbtnConCostos.Checked = True
        Me.lblDisplaySocio.Visible = False
        Me.txtCodigoSocio.Visible = False
        Me.lblNombreSocio.Visible = False
    End Sub

    Private Sub ChkFechas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkFechas.CheckedChanged
        Me.DtFechaDesde.Enabled = Me.ChkFechas.Checked
        Me.DtFechaHasta.Enabled = Me.ChkFechas.Checked
    End Sub

    Private Sub CHSoloExistencia_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtFechaHasta.KeyDown, DtFechaDesde.KeyDown, CmbAlmacen.KeyDown, CHSoloExistencia.KeyDown, ChkFechas.KeyDown
        txtTAB(e)
    End Sub

    Private Sub CboFamilia_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CboFamilia.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.tsbConsultar.PerformClick()
        End If
    End Sub

    Private Sub rbtnSocio_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnSocio.CheckedChanged
        If rbtnSocio.Checked Then
            Me.lblDisplaySocio.Visible = True
            Me.txtCodigoSocio.Visible = True
            Me.lblNombreSocio.Visible = True
            Me.CboFamilia.Visible = False
            Me.chkExcluirfamilia.Visible = False
        Else
            Me.lblDisplaySocio.Visible = False
            Me.txtCodigoSocio.Visible = False
            Me.lblNombreSocio.Visible = False
            Me.CboFamilia.Visible = True
            Me.chkExcluirfamilia.Visible = True
        End If
    End Sub
End Class