Imports CrystalDecisions.CrystalReports.Engine

Public Class Rpt_Inventario_Requisiciones_Global
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
            FormatoDeReporte = "RPT_INVENTARIOS_REQUISICIONES"
            oReporte = New Class_Reporte(FormatoDeReporte, Rpt)
            Rpt.SetParameterValue("@CODIGO_ALMACEN", Me.CmbAlmacen.SelectedValue.ToString())
            Rpt.SetParameterValue("@ESTATUS", Me.CboEstatus.Text.Substring(0, 1))
            Rpt.SetParameterValue("@CODIGO_ARTICULO", Me.TxtCodArticulo.Text.ToUpper)
            Rpt.SetParameterValue("@CODIGO_USUARIO_SOLICITO", Me.TxtCodigoUsuarioSolicito.Text)
            Rpt.SetParameterValue("@CODIGO_USUARIO_COMPRADOR", Me.TxtCodigoUsuarioComprador.Text)
            Rpt.SetParameterValue("@INCLUIR_CANCELADAS", IIf(Me.CkbIncluirCanceladas.Checked, "1", "0"))

            Dim frm As New Reporte(Rpt)
            frm.CRViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            frm.Show()
        Catch ex As Exception
            HandleError(Me.Name, "Reporte de requisiciones global", ex)
        Finally
            oReporte = Nothing
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

    Private Sub DesplegarEstatus()
        Try
            With Me.CboEstatus
                .Items.Clear()
                .Items.Add("T-TODAS")
                .Items.Add("G-GRABADO")
                .Items.Add("A-ENTREGADO")
                .Items.Add("L-SOLICITADO")
                .Items.Add("R-PARICALMENTE ENTREGADO")
                .Items.Add("C-CANCELADO")
                .SelectedItem = "T-TODAS"
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarEstatus", ex)
        End Try
    End Sub
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

    Private Sub txtKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodArticulo.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub txtCodigoUsuarioCompradorKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigoUsuarioComprador.KeyPress
        txtSoloNumerosEnteros(e)
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

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub

    Private Sub Inventario_Requisiciones_Solicitadas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DesplegarAlmacenes()
        Me.DesplegarEstatus()
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
                    Me.tsbConsultar.PerformClick()
                End If
            Case Keys.Escape
        End Select
    End Sub

    Private Sub TxtCodigoUsuarioComprador_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCodigoUsuarioComprador.KeyDown
        Dim oUsuario As New Class_sisUsuarios
        Try
            Select Case e.KeyCode
                Case Keys.F6
Buscar:
                    Dim sUsuario As String = oUsuario.BusquedaVisual_PorDescripcion("2") '2=COMPRAS, ESTE DEPARTAMENTO ES FIJO Y PROTEJIDO
                    If txtLEN(sUsuario) = True Then
                        Me.TxtCodigoUsuarioComprador.Text = sUsuario
                        GoTo Enter : Return
                    End If

                Case Keys.Enter
                    If txtLEN(Me.TxtCodigoUsuarioComprador.Text) = False Then
                        Me.LblNombreComprador.Text = ""
                        GoTo Buscar : Return
                    End If
Enter:
                    oUsuario = New Class_sisUsuarios(CInt(valorNumerico(Me.TxtCodigoUsuarioComprador.Text)))

                    If oUsuario.Existe = False Then
                        Me.LblNombreComprador.Text = ""
                        GoTo Buscar : Return
                    ElseIf oUsuario.ESTATUS = "B" Then
                        MsgBox("El usuario " & Me.TxtCodigoUsuarioComprador.Text & " está dado de baja.", MsgBoxStyle.Exclamation, Me.Text)
                        GoTo Buscar : Return
                    End If

                    Me.LblNombreComprador.Text = oUsuario.Nombre_Usuario

                    txtTAB(e)
            End Select

        Catch ex As Exception
            HandleError(Me.Name, "TxtCodigoUsuarioComprador_KeyDown", ex)
        End Try
    End Sub

    Private Sub TxtCodigoUsuarioSolicito_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCodigoUsuarioSolicito.KeyDown
        Dim oUsuario As New Class_sisUsuarios
        Try
            Select Case e.KeyCode
                Case Keys.F6
Buscar:
                    Dim sUsuario As String = oUsuario.BusquedaVisual_PorDescripcion()
                    If txtLEN(sUsuario) = True Then
                        Me.TxtCodigoUsuarioSolicito.Text = sUsuario
                        GoTo Enter : Return
                    End If

                Case Keys.Enter
                    If txtLEN(Me.TxtCodigoUsuarioSolicito.Text) = False Then
                        Me.LblNombreUsuarioSolicito.Text = ""
                        GoTo Buscar : Return
                    End If
Enter:
                    oUsuario = New Class_sisUsuarios(CInt(valorNumerico(Me.TxtCodigoUsuarioSolicito.Text)))

                    If oUsuario.Existe = False Then
                        Me.LblNombreUsuarioSolicito.Text = ""
                        GoTo Buscar : Return
                    ElseIf oUsuario.ESTATUS = "B" Then
                        MsgBox("El usuario " & Me.TxtCodigoUsuarioSolicito.Text & " está dado de baja.", MsgBoxStyle.Exclamation, Me.Text)
                        GoTo Buscar : Return
                    End If

                    Me.LblNombreUsuarioSolicito.Text = oUsuario.Nombre_Usuario

                    txtTAB(e)
            End Select

        Catch ex As Exception
            HandleError(Me.Name, "TxtCodigoUsuarioSolicito_KeyDown", ex)
        End Try
    End Sub

End Class