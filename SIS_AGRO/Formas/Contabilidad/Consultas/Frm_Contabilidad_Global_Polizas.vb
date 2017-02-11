Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class Frm_Contabilidad_Global_Polizas

#Region "Campos"

#Region "Campos privados"

    Private Enum enumEstados
        AuxiliarMAyor
    End Enum

    Private Estado As enumEstados
    Private FormatoDeReporte As String

#End Region

#End Region

#Region "Constructor y destructor"

    Public Sub New()
        InitializeComponent()
        Estado = enumEstados.AuxiliarMAyor
        Me.Cambia_Estado()
        DesplegarEjercicios()
        DesplegarTipoDocumento()
        DesplegarPlazas()
        Limpiar()
        Me.rbtnReporteGlobal.Checked = True
        Me.CboEjercicio.SelectedValue = Plaza.ID_CON_EJERCICIO
        Me.DtFechaDesde.Value = Plaza.FECHA_INICIO
        Me.DtFechaHasta.Value = Plaza.FECHA_FINAL
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

#End Region

#Region "Opciones"

    Private Sub tsbConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbConsultar.Click
        Me.Consultar()
    End Sub

    Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimirListado.Click
        Me.Imprimir()
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub

#End Region

#Region "Métodos y procedimientos"

    Private Sub DesplegarEjercicios()
        Dim oElementos As New Class_Contabilidad_Ejercicios
        With Me.CboEjercicio
            .DisplayMember = "NOMBRE_EJERCICIO"
            .ValueMember = "ID_CON_EJERCICIO"

            Dim dView As New Data.DataView(oElementos.ObtenerEjercicios)
            'dView.Sort = "NOMBRE_EJERCICIO"
            .DataSource = dView
            If dView.Count > 0 Then
                .SelectedIndex = 0
            End If
        End With
    End Sub

    Private Sub DesplegarTipoDocumento()
        Dim oElementos As New Class_SisTiposDocumentos
        With Me.CboDocumento
            .DisplayMember = "NOMBRE_TIPO_DOCUMENTO"
            .ValueMember = "CODIGO_TIPO_DOCUMENTO"

            Dim dView As New Data.DataView(oElementos.ObtenerTiposDocumentosContabilidaParaReporte)
            dView.Sort = "NOMBRE_TIPO_DOCUMENTO"
            .DataSource = dView
            If dView.Count > 0 Then
                .SelectedIndex = 0
            End If
        End With
    End Sub

    Private Sub DesplegarPlazas()
        Dim oElementos As New Class_SisPlazas
        With Me.cboPlaza
            .DisplayMember = "NOMBRE_PLAZA"
            .ValueMember = "CODIGO_PLAZA"

            Dim dView As New Data.DataView(oElementos.ObtenerElementosParaReporte)
            dView.Sort = "NOMBRE_PLAZA"
            .DataSource = dView
            If dView.Count > 0 Then
                .SelectedValue = 0
            End If
        End With
    End Sub

    Private Sub Cambia_Estado()
        Select Case Me.Estado
            Case enumEstados.AuxiliarMAyor
        End Select
        Application.DoEvents()
    End Sub

    Private Sub Consultar()
        Dim StrSqlQuerry As String = ""
        Dim oReporte As New Class_Contabilidad_Reportes

        If Me.ValidarPeriodo = False Then
            Exit Sub
        End If

        With oReporte
            .FECHA1 = Me.DtFechaDesde.Value
            .FECHA2 = Me.DtFechaHasta.Value
            .ID_CON_EJERCICIO = Me.CboEjercicio.SelectedValue
            .ESTATUS_POLIZA = Me.CboEstatus.Text
            .CODIGO_TIPO_DOCUMENTO = Me.CboDocumento.Text
            .CODIGO_PLAZA = Me.cboPlaza.SelectedValue

            Me.Grid.DataSource = .ReporteGlobalPolizasDatatable
        End With
        oReporte = Nothing
        Me.FormateaGrid()
    End Sub

    Private Sub FormateaGrid()
        Me.Grid.Columns("G_FOLIO_POLIZA").HeaderText = "FOLIO"
        Me.Grid.Columns("G_CODIGO_TIPO_DOCUMENTO").HeaderText = "TIPO DOCUMENTO"
        Me.Grid.Columns("G_FECHA").HeaderText = "FECHA"
        Me.Grid.Columns("G_CONCEPTO1").HeaderText = "CONCEPTO"
        Me.Grid.Columns("G_ESTATUS_POLIZA").HeaderText = "ESTATUS"
        Me.Grid.Columns("G_CARGO").HeaderText = "CARGO"
        Me.Grid.Columns("G_ABONO").HeaderText = "ABONO"
        Me.Grid.Columns("NOMBRE_EJERCICIO").HeaderText = "EJERCICIO"

        Me.Grid.Columns("G_FECHA").DefaultCellStyle.Format = "dd/MMM/yy"
        Me.Grid.Columns("G_CARGO").DefaultCellStyle.Format = "$ ###,###,###.00"
        Me.Grid.Columns("G_ABONO").DefaultCellStyle.Format = "$ ###,###,###.00"
        Me.Grid.Columns("G_CARGO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.Grid.Columns("G_ABONO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.Grid.Columns("G_FECHA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.Grid.Columns("G_ESTATUS_POLIZA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        Me.Grid.Columns("G_FOLIO_POLIZA").Width = 80
        Me.Grid.Columns("G_FECHA").Width = 70
        Me.Grid.Columns("G_CONCEPTO1").Width = 190
        Me.Grid.Columns("G_ESTATUS_POLIZA").Width = 60
        Me.Grid.Columns("NOMBRE_EJERCICIO").Width = 80

    End Sub

    Private Sub Imprimir()
        Dim StrFiltros As String = ""
        Dim Rpt As New ReportDocument
        Dim oReporte As Class_Reporte
        Try
            If Me.ValidarPeriodo = False Then
                Exit Sub
            End If

            If Me.rbtnReporteDetalle.Checked = True Then
                FormatoDeReporte = "RPT_CONTABILIDAD_DETALLE_POLIZAS"
                oReporte = New Class_Reporte(FormatoDeReporte, Rpt)
            ElseIf Me.rbtnReporteGlobal.Checked = True Then
                FormatoDeReporte = "RPT_CONTABILIDAD_GLOBAL_POLIZAS"
                oReporte = New Class_Reporte(FormatoDeReporte, Rpt)
            End If

            Rpt.SetParameterValue("@FECHA1", Format(Me.DtFechaDesde.Value, "yyyy-dd-MM"))
            Rpt.SetParameterValue("@FECHA2", Format(Me.DtFechaHasta.Value, "yyyy-dd-MM"))
            Rpt.SetParameterValue("@ID_CON_EJERCICIO", Me.CboEjercicio.SelectedValue)
            Rpt.SetParameterValue("@ESTATUS_POLIZA", Me.CboEstatus.Text)
            Rpt.SetParameterValue("@CODIGO_TIPO_DOCUMENTO", Me.CboDocumento.SelectedValue)
            Rpt.SetParameterValue("@CODIGO_PLAZA", Me.cboPlaza.SelectedValue)

            Dim frm As New Reporte(Rpt)
            frm.CRViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            frm.Show()
        Catch ex As Exception
            HandleError(Me.Name, "Imprimir", ex)
        Finally
            oReporte = Nothing
        End Try
    End Sub

    Private Function Filtros() As String
        Dim sFiltros As String

        sFiltros = ""
        Filtros = sFiltros
    End Function

    Private Sub Limpiar()
        Me.DtFechaDesde.Value = Date.Now
        Me.DtFechaHasta.Value = Date.Now
        Me.CboEstatus.Text = "A"
        Me.CboDocumento.Text = "T - TODOS"
        Me.CboDocumento.SelectedIndex = 0
        Me.CboEstatus.SelectedIndex = 0
        Me.Grid.Rows.Clear()
    End Sub

    Private Function ValidarPeriodo() As Boolean
        Me.DtFechaDesde.Enabled = False
        Me.DtFechaDesde.Enabled = True

        Me.DtFechaHasta.Enabled = False
        Me.DtFechaHasta.Enabled = True

        If Me.DtFechaDesde.Value > Me.DtFechaHasta.Value Then
            MsgBox("Rango de fechas inválidas.", MsgBoxStyle.Exclamation, Me.Name)
            Me.DtFechaDesde.Focus()
            Exit Function
        End If
        ValidarPeriodo = True
    End Function

#End Region

#Region "Eventos de objetos"

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

    Private Sub CboEjercicio_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboEjercicio.SelectedIndexChanged
        Dim sql As Class_find
        sql = New Class_find("SELECT FECHA_INICIO,FECHA_FINAL FROM CON_EJERCICIOS WHERE ID_CON_EJERCICIO=" & Me.CboEjercicio.SelectedValue.ToString)
        Me.DtFechaDesde.Value = CDate(sql.Result1)
        Me.DtFechaHasta.Value = CDate(sql.Result2)
    End Sub

    Private Sub DtFechaHasta_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Me.Visible = False Then
            Exit Sub
        End If
        Dim sql As Class_find
        sql = New Class_find("SELECT FECHA_INICIO,FECHA_FINAL FROM CON_EJERCICIOS WHERE ID_CON_EJERCICIO='" & Me.CboEjercicio.SelectedValue.ToString & "'")
        If Me.DtFechaHasta.Value < CDate(sql.Result1) Then
            Me.DtFechaHasta.Value = CDate(sql.Result1)
        End If
        If Me.DtFechaHasta.Value > CDate(sql.Result2) Then
            Me.DtFechaHasta.Value = CDate(sql.Result2)
        End If
    End Sub

    Private Sub DtFechaDesde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Me.Visible = False Then
            Exit Sub
        End If
        Dim sql As Class_find
        sql = New Class_find("SELECT FECHA_INICIO,FECHA_FINAL FROM CON_EJERCICIOS WHERE ID_CON_EJERCICIO='" & Me.CboEjercicio.SelectedValue.ToString & "'")
        If Me.DtFechaDesde.Value < CDate(sql.Result1) Then
            Me.DtFechaDesde.Value = CDate(sql.Result1)
        End If
        If Me.DtFechaDesde.Value > CDate(sql.Result2) Then
            Me.DtFechaDesde.Value = CDate(sql.Result2)
        End If
    End Sub

#End Region

#Region "Keydown específicos"
    Private Sub Grid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Grid.DoubleClick
        Dim Columna As Integer, Renglon As Integer, vdg As DataGridViewCell
        Columna = Convert.ToInt16(Grid.CurrentCell.ColumnIndex)
        Renglon = Convert.ToInt16(Grid.CurrentCell.RowIndex)
        vdg = Grid.Rows(Renglon).Cells("G_FOLIO_POLIZA")
        Dim Child As New Frm_Contabilidad_Captura_Polizas()
        Child.FolioPolizaConsultaExterior = vdg.Value.ToString()
        Child.ShowDialog()
        Child.Dispose()
    End Sub
    Private Sub Grid_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Grid.KeyDown
        If e.KeyCode = Keys.Return Then
            Dim Columna As Integer, Renglon As Integer, vdg As DataGridViewCell
            Columna = Convert.ToInt16(Grid.CurrentCell.ColumnIndex)
            Renglon = Convert.ToInt16(Grid.CurrentCell.RowIndex)
            vdg = Grid.Rows(Renglon).Cells("G_FOLIO_POLIZA")
            Dim Child As New Frm_Contabilidad_Captura_Polizas()
            Child.FolioPolizaConsultaExterior = vdg.Value.ToString()
            Child.ShowDialog()
            Child.Dispose()
        Else
            Exit Sub
        End If
    End Sub
    Private Sub chk_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Return Then
            Me.tsbConsultar.PerformClick()
        End If
    End Sub

#End Region

#End Region

End Class


