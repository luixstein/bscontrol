Imports CrystalDecisions.CrystalReports.Engine

Public Class Rpt_Embarques_Socios_Estado_Resultados

    Private oArticulos As New Class_CatArticulos

#Region "Opciones"
    Private Sub tsbConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbConsultar.Click
        If rbtAnalisisEmbarque.Checked And txtLEN(Me.TxtCodArticulo.Text) = False Then
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

    Private Sub TxtCodigoSocio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodigoSocio.KeyDown
        Dim oUsuario As New Class_sisUsuarios
        Try
            Select Case e.KeyCode
                Case Keys.F6
Buscar:
                    Dim sUsuario As String = oUsuario.BusquedaVisual_PorDescripcion()
                    If txtLEN(sUsuario) = True Then
                        Me.TxtCodigoSocio.Text = sUsuario
                        GoTo Enter : Return
                    End If

                Case Keys.Enter
                    If txtLEN(Me.TxtCodigoSocio.Text) = False Then
                        Me.TxtCodigoSocio.Text = ""
                        GoTo Buscar : Return
                    End If
Enter:
                    oUsuario = New Class_sisUsuarios(CInt(valorNumerico(Me.TxtCodigoSocio.Text)))

                    If oUsuario.Existe = False Then
                        Me.LblNombreSocio.Text = ""
                        GoTo Buscar : Return
                    ElseIf oUsuario.ESTATUS = "B" Then
                        MsgBox("El usuario " & Me.TxtCodigoSocio.Text & " está dado de baja.", MsgBoxStyle.Exclamation, Me.Text)
                        GoTo Buscar : Return
                    End If

                    Me.LblNombreSocio.Text = oUsuario.Nombre_Usuario

                    txtTAB(e)
            End Select

        Catch ex As Exception
            HandleError(Me.Name, "TxtCodigoSocio_KeyDown", ex)
        End Try
    End Sub

    Private Sub Rpt_Embarques_Socios_Estado_Resultados_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.DtFechaDesde.Value = CDate("01/01/" & Year(Date.Now))
        Me.DtFechaHasta.Value = Date.Now
    End Sub

    Private Sub rbtAnalisisEmbarque_CheckedChanged(sender As Object, e As EventArgs) Handles rbtAnalisisEmbarque.CheckedChanged
        If Me.rbtAnalisisEmbarque.Checked Then
            Me.LblDisplayCodArticulo.Visible = True
            Me.lblArticulo.Visible = True
            Me.TxtCodArticulo.Visible = True
            Me.LblDisplaySocio.Visible = False
            Me.LblNombreSocio.Visible = False
            Me.TxtCodigoSocio.Visible = False
        Else
            Me.LblDisplayCodArticulo.Visible = False
            Me.lblArticulo.Visible = False
            Me.TxtCodArticulo.Visible = False
            Me.LblDisplaySocio.Visible = True
            Me.LblNombreSocio.Visible = True
            Me.TxtCodigoSocio.Visible = True
        End If

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
        Dim sCodigo, sParametro As String
        Try

            If rbtAnalisisEmbarque.Checked Then
                FormatoDeReporte = "RPT_EMBARQUES_SOCIOS_ESTADO_RESULTADOS"
                sParametro = "@CODIGO_ARTICULO"
                sCodigo = Me.TxtCodArticulo.Text

            Else 'Analsis por socio
                FormatoDeReporte = "RPT_EMBARQUES_SOCIOS_ANALISIS_RESULTADOS"
                sParametro = "@CODIGO_USUARIO_SOCIO"
                sCodigo = IIf(txtLEN(Me.TxtCodigoSocio.Text), Me.TxtCodigoSocio.Text, "0")
            End If

            oReporte = New Class_Reporte(FormatoDeReporte, Rpt)

            Rpt.SetParameterValue(sParametro, sCodigo)
            Rpt.SetParameterValue("@FECHA1", Format(Me.DtFechaDesde.Value, "yyyy-dd-MM"))
            Rpt.SetParameterValue("@FECHA2", Format(Me.DtFechaHasta.Value, "yyyy-dd-MM"))
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