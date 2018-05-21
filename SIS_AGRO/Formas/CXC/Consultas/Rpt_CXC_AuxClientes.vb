Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class Rpt_CXC_AuxClientes
    Private oClientes As New Class_CatClientes
    Private oZona As New Class_CatZonas

#Region "Constructor y destructor"
    Public Sub New()
        InitializeComponent()
        Me.DesplegarDocumentos()
        'Me.DesplegarMercados()
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

    Private Sub txtTextoKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigoCliente.KeyPress, CboDocumentos.KeyPress, _
         DtFechaDesde.KeyPress, DtFechaHasta.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub txtNumerosEnterosKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigoPropietario.KeyPress
        txtSoloNumerosEnteros(e)
        txtNoBeep(e)
    End Sub

    Private Sub txtCodicoCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigoCliente.KeyDown
        Dim sText As String
        Select Case e.KeyCode
            Case Keys.F6
Buscar:

                If Empresa_Sistema.PERMITE_CLIENTES_MULTIPLAZA = True Then
                    sText = Me.oClientes.BusquedaVisual_PorDescripcionSinFiltroZona
                Else
                    sText = Me.oClientes.BusquedaVisual_PorDescripcion
                End If

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

    Private Sub txtCodigoPropietario_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodigoPropietario.KeyDown
        Dim sText As String
        Dim oPropietarios As New Class_CatPropietarios
        Select Case e.KeyCode
            Case Keys.F6
Buscar:
                sText = oPropietarios.BusquedaVisual_PorDescripcion
                If txtLEN(sText) = True Then Me.TxtCodigoPropietario.Text = sText
            Case Keys.Enter
                If txtLEN(Me.TxtCodigoPropietario.Text) = False Then
                    Me.LblNombrePropietario.Text = ""
                    Me.DtFechaDesde.Focus()
                    Exit Sub
                End If

                oPropietarios = New Class_CatPropietarios(Me.TxtCodigoPropietario.Text)
                If oPropietarios.Existe = False Then
                    Me.LblNombrePropietario.Text = "" : GoTo Buscar : Exit Sub
                End If

                Me.LblNombrePropietario.Text = oPropietarios.NOMBRE_PROPIETARIO
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
            Me.CboDocumentos.Focus()
        End If
    End Sub

    Private Sub CboDocumentos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CboDocumentos.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.tsbImprimir.PerformClick()
        End If
    End Sub

    Private Sub rbtAnalisis_CheckedChanged(sender As Object, e As EventArgs) Handles rbtAnalisis.CheckedChanged
        If Me.rbtAnalisis.Checked = True Then
            Me.TxtCodigoPropietario.Enabled = True
        Else
            Me.TxtCodigoPropietario.Enabled = False
            Me.TxtCodigoPropietario.Text = ""
            Me.LblNombrePropietario.Text = ""
        End If
    End Sub

#End Region

#Region "Métodos y procedimientos"

    Private Sub Inicializa()
        Me.DesplegarDocumentos()
        ' Me.DesplegarEstatus()
        Me.CboDocumentos.SelectedValue = "T"
        Me.DtFechaDesde.Value = CDate(Format(Date.Now, "01-MM-yyyy"))
        Me.DtFechaHasta.Value = Date.Now
        Me.TxtCodigoPropietario.Enabled = False
    End Sub

    Private Sub DesplegarDocumentos()
        Dim oElementos As New Class_CatDocumentos
        With Me.CboDocumentos
            .DisplayMember = "NOMBRE_TIPO_DOCUMENTO"
            .ValueMember = "CODIGO_TIPO_DOCUMENTO"
            Dim dView As New Data.DataView(oElementos.ObtenerTiposDocumentosParaReportes("VTA", Usuario.Codigo_Plaza.ToString, " AFECTA_CXC='1' "))
            dView.Sort = "NOMBRE_TIPO_DOCUMENTO"
            .DataSource = dView
            If dView.Count > 0 Then
                .SelectedIndex = 0
            End If
        End With
    End Sub

    Private Sub Imprimir()
        Dim StrFiltros As String = ""
        Dim Rpt As New ReportDocument
        Dim oReporte As Class_Reporte
        Dim FormatoReporte As String = ""
        Dim oPropietarios As Class_CatPropietarios
        Try

            oClientes = New Class_CatClientes(Me.txtCodigoCliente.Text)
            If Me.oClientes.Existe = False And txtLEN(Me.TxtCodigoPropietario.Text) = False Then
                MsgBox("El código de cliente que intenta buscar no existe o esta dado de Baja, favor de intentar con otro código.", MsgBoxStyle.Critical, "Validación de Cliente")
                Me.lblNombreCliente.Text = ""
                Me.txtCodigoCliente.Focus()
                Exit Sub
            End If

            If txtLEN(Me.TxtCodigoPropietario.Text) = True Then
                oPropietarios = New Class_CatPropietarios(Me.TxtCodigoPropietario.Text)
                If oPropietarios.Existe = False Then
                    MsgBox("El código de propietario que intenta buscar no existe o esta dado de Baja, favor de intentar con otro código.", MsgBoxStyle.Critical, "Validación de Propietario")
                    Me.LblNombrePropietario.Text = ""
                    Me.TxtCodigoPropietario.Focus()
                    Exit Sub
                End If
            End If

            If Me.ValidarPeriodo = False Then
                Exit Sub
            End If

            If Me.rbtAuxiliar.Checked Then
                FormatoReporte = "RPT_CXC_AUXILIAR_CLIENTES"
            End If

            If Me.rbtAnalisis.Checked Then
                FormatoReporte = "RPT_CXC_ANALISIS_SALDOS_CLIENTE"
            End If

            oReporte = New Class_Reporte(FormatoReporte, Rpt)

            If Not oReporte.RptCargado Then
                Exit Sub
            End If

            Rpt.SetParameterValue("@CODIGO_CLIENTE", "" & Me.txtCodigoCliente.Text)
            Rpt.SetParameterValue("@FECHA1", Format(Me.DtFechaDesde.Value, "yyyy-dd-MM"))
            Rpt.SetParameterValue("@FECHA2", "" & Format(Me.DtFechaHasta.Value, "yyyy-dd-MM"))
            Rpt.SetParameterValue("@CODIGO_DOCUMENTO", "" & Me.CboDocumentos.SelectedValue.ToString)
            If Me.rbtAnalisis.Checked = True Then
                If txtLEN(Me.TxtCodigoPropietario.Text) = True Then
                    Rpt.SetParameterValue("@CODIGO_PROPIETARIO", CInt(Me.TxtCodigoPropietario.Text))
                Else
                    Rpt.SetParameterValue("@CODIGO_PROPIETARIO", 0)
                End If

            End If

            Dim frm As New Reporte(Rpt)
            frm.CRViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            frm.Show()
        Catch ex As Exception
            HandleError(Me.Name, "Reporte de cxc", ex)
        Finally
            oReporte = Nothing
        End Try
    End Sub

    Private Function ValidarPeriodo() As Boolean
        Me.DtFechaDesde.Enabled = False
        Me.DtFechaDesde.Enabled = True
        Me.DtFechaHasta.Enabled = False
        Me.DtFechaHasta.Enabled = True

        If Me.DtFechaDesde.Value > Me.DtFechaHasta.Value Then
            MsgBox("Rango de fechas inválidas.", MsgBoxStyle.Exclamation, Me.Name)
            Exit Function
        End If

        ValidarPeriodo = True
    End Function
#End Region

End Class