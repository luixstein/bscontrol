Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class Rpt_Embarques_VentasEstimadaArticulo
    Private oClientes As New Class_CatClientes

#Region "Constructor y destructor"
    Public Sub New()
        InitializeComponent()
        Me.Inicializa()
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
#End Region

#Region "Opciones"

    Private Sub tsbSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub
#End Region

#Region "Métodos y procedimientos"

    Private Sub Inicializa()
        Me.DesplegarCultivos()
        Me.DesplegarSemana1()
        Me.DesplegarSemana2()
        Me.DesplegarZona()
        Me.DesplegarMercado()
        Me.DesplegarEjercicios()

        'Me.CboSemana1.Text = Format(EmpresaParametros.FECHA_INICIO, "yyyy-") & Format(CInt(DatePart("ww", EmpresaParametros.FECHA_INICIO, FirstDayOfWeek.Sunday, FirstWeekOfYear.FirstFullWeek).ToString), "00")
        Me.CboSemana2.Text = Format(Now, "yyyy-") & Format(CInt(DatePart("ww", Now, FirstDayOfWeek.Sunday, FirstWeekOfYear.FirstFullWeek).ToString) - 1, "00")
    End Sub

    Private Sub DesplegarEjercicios()
        Dim oElementos As New Class_Contabilidad_Ejercicios
        With Me.CmbEjercicio
            .DisplayMember = "NOMBRE_EJERCICIO"
            .ValueMember = "ID_CON_EJERCICIO"
            Dim dView As New Data.DataView(oElementos.ObtenerEjercicios)
            .DataSource = dView
            If dView.Count > 0 Then
                'Dim sSql As New Class_find("SELECT ID_CON_EJERCICIO,FECHA_INICIO FROM CON_EJERCICIOS WHERE '" & Format(Date.Now, "yyyy-dd-MM") & "' BETWEEN FECHA_INICIO AND FECHA_FINAL AND TIPO_CONTABILIDAD='FN'")
                .SelectedValue = Plaza.ID_CON_EJERCICIO.ToString ' sSql.Result1.ToString
            End If
        End With
    End Sub

    Private Sub DesplegarCultivos()
        Dim oElementos As New Class_CatCultivos
        With Me.cboCultivo
            .DisplayMember = "NOMBRE_CULTIVO"
            .ValueMember = "CODIGO_CULTIVO"

            Dim dView As New Data.DataView(oElementos.ObtenerElementosParaReportes)
            dView.Sort = "NOMBRE_CULTIVO"
            .DataSource = dView
            .Text = "TODOS"
        End With
    End Sub

    Private Sub DesplegarSemana1()
        Dim oElementos As New Class_CatCultivos
        With Me.CboSemana1
            .DisplayMember = "SEMANA"
            .ValueMember = "FECHA1"
            Dim dView As New Data.DataView(oElementos.ObtenerSemanas("1"))
            dView.Sort = "SEMANA"
            .DataSource = dView
        End With
    End Sub

    Private Sub DesplegarSemana2()
        Dim oElementos As New Class_CatCultivos
        With Me.CboSemana2
            .DisplayMember = "SEMANA"
            .ValueMember = "FECHA2"
            Dim dView As New Data.DataView(oElementos.ObtenerSemanas("2"))
            dView.Sort = "SEMANA"
            .DataSource = dView
        End With
    End Sub

    Private Sub DesplegarZona()
        Dim oElementos As New Class_CatZonas
        With Me.CboZona
            .DisplayMember = "NOMBRE_ZONA"
            .ValueMember = "CODIGO_ZONA"
            Dim dView As New Data.DataView(oElementos.ObtenerZonasParaReportes())
            dView.Sort = "NOMBRE_ZONA"
            .DataSource = dView
        End With
    End Sub

    Private Sub DesplegarMercado()
        Dim oElementos As New Class_CatTiposMercados
        With Me.cboMercado
            .DisplayMember = "NOMBRE_MERCADO"
            .ValueMember = "CODIGO_MERCADO"
            Dim dView As New Data.DataView(oElementos.ObtenerTiposMercadosParaReportes())
            dView.Sort = "NOMBRE_MERCADO"
            .DataSource = dView
            .Text = "TODOS"
        End With
    End Sub

    Private Sub CboSemana1_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboSemana1.SelectedValueChanged
        Dim sql As Class_find
        sql = New Class_find("SELECT FECHA1,FECHA2 FROM EMB_CAT_RANGOS_LOTES_MASTRONARDI " & _
        "WHERE REPLACE(LEFT(CAST(((NUMERO_SEMANA/100.00)+AÑO) AS NVARCHAR),7),'.','-')='" & Me.CboSemana1.Text.ToString & "'")
        If txtLEN(sql.Result1) = True Then
            Me.DtFechaDesde.Value = CDate(sql.Result1)
        End If
    End Sub

    Private Sub CboSemana2_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboSemana2.SelectedValueChanged
        Dim sql As Class_find
        sql = New Class_find("SELECT FECHA2 FROM EMB_CAT_RANGOS_LOTES_MASTRONARDI " & _
        "WHERE REPLACE(LEFT(CAST(((NUMERO_SEMANA/100.00)+AÑO) AS NVARCHAR),7),'.','-')='" & Me.CboSemana2.Text.ToString & "'")
        If txtLEN(sql.Result1) = True Then
            Me.DtFechaHasta.Value = CDate(sql.Result1)
        End If
    End Sub

    Private Sub CmbEjercicio_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbEjercicio.SelectedIndexChanged
        Dim sql As Class_find
        sql = New Class_find("SELECT FECHA_INICIO,FECHA_FINAL FROM CON_EJERCICIOS WHERE ID_CON_EJERCICIO=" & Me.CmbEjercicio.SelectedValue.ToString)
        Me.CboSemana1.Text = Format(CDate(sql.Result1), "yyyy-") & Format(CInt(DatePart("ww", CDate(sql.Result1), FirstDayOfWeek.Sunday, FirstWeekOfYear.FirstFullWeek).ToString), "00")
    End Sub

    Private Sub Consultar()
        Dim FormatoDeReporte As String = ""
        Dim Rpt As ReportDocument
        Rpt = New ReportDocument
        Dim oReporte As Class_Reporte
        Try
            
            If txtLEN(Me.TxtCliente.Text) = True Then
                Me.oClientes = New Class_CatClientes(Me.TxtCliente.Text)
                If Me.oClientes.Existe = False Then
                    MsgBox("El cliente no existe.", MsgBoxStyle.Information, Me.Text)
                    Me.TxtCliente.Focus()
                    Exit Sub
                End If
            End If

            If Me.ValidarPeriodo = False Then
                Exit Sub
            End If

            FormatoDeReporte = "RPT_EMB_VENTAS_ESTIMADAS_ARTICULO"

            oReporte = New Class_Reporte(FormatoDeReporte, Rpt)
            Rpt.SetParameterValue("@ID_CON_EJERCICIO", Me.CmbEjercicio.SelectedValue)
            Rpt.SetParameterValue("@FECHA1", Me.CboSemana1.Text)
            Rpt.SetParameterValue("@FECHA2", Me.CboSemana2.Text)
            Rpt.SetParameterValue("@CODIGO_CULTIVO", Me.cboCultivo.SelectedValue.ToString())
            Rpt.SetParameterValue("@CODIGO_ZONA", Me.CboZona.SelectedValue)
            Rpt.SetParameterValue("@CODIGO_MERCADO", Me.cboMercado.SelectedValue)
            Rpt.SetParameterValue("@CODIGO_CLIENTE", Me.TxtCliente.Text)

            Dim frm As New Reporte(Rpt)
            frm.CRViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            frm.Show()
        Catch ex As Exception
            HandleError(Me.Name, "Consultar", ex)
        Finally
            oReporte = Nothing
        End Try
    End Sub

    Private Function ValidarPeriodo() As Boolean
        Me.DtFechaDesde.Enabled = True
        Me.DtFechaDesde.Enabled = False

        Me.DtFechaHasta.Enabled = True
        Me.DtFechaHasta.Enabled = False

        If Me.DtFechaDesde.Value > Me.DtFechaHasta.Value Then
            MsgBox("Rango de fechas inválidas.", MsgBoxStyle.Exclamation, Me.Name)
            Me.CboSemana1.Focus()
            Exit Function
        End If
        ValidarPeriodo = True
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

    Private Sub txtKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        txtNoBeep(e)
    End Sub

#End Region

#Region "Keydown específicos"
    Private Sub TxtCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCliente.KeyDown
        Dim sText As String
        Select Case e.KeyCode
            Case Keys.F6
Buscar:
                If Me.CboZona.SelectedValue.ToString <> "T" Then
                    sText = Me.oClientes.BusquedaVisual_PorDescripcionZona(Me.CboZona.SelectedValue.ToString)
                Else
                    sText = Me.oClientes.BusquedaVisual_PorDescripcion()
                End If

                If txtLEN(sText) = True Then Me.TxtCliente.Text = sText
            Case Keys.Enter
                If txtLEN(Me.TxtCliente.Text) = False Then
                    Me.lblNombreCliente.Text = "" : Me.tsbConsultar.PerformClick() : Exit Sub
                End If

                Me.oClientes = New Class_CatClientes(Me.TxtCliente.Text)
                If Me.oClientes.Existe = False Then
                    Me.lblNombreCliente.Text = "" : GoTo Buscar : Exit Sub
                End If

                Me.lblNombreCliente.Text = Me.oClientes.NOMBRE_CLIENTE.ToString
                Me.tsbConsultar.PerformClick()
        End Select
    End Sub

#End Region

    Private Sub tsbConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbConsultar.Click
        Me.Consultar()
    End Sub
End Class