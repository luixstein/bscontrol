Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class Frm_Contabilidad_Polizas_Egresos

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
        Limpiar()
    End Sub

    Protected Overrides Sub Finalize()

        MyBase.Finalize()
    End Sub
#End Region

#Region "Opciones"
    Private Sub tsbConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbConsultar.Click
        If Validar() Then
            Me.Consultar()
        End If
    End Sub

    Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click
        If Validar() Then
            Me.Imprimir()
        End If
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub
#End Region

#Region "Métodos y procedimientos"

    Private Sub DesplegarEjercicios()
        Dim oElementos As New Class_Contabilidad_Ejercicios
        With Me.CmbEjercicio
            .DisplayMember = "NOMBRE_EJERCICIO"
            .ValueMember = "ID_CON_EJERCICIO"
            Dim dView As New Data.DataView(oElementos.ObtenerEjercicios)
            dView.Sort = "NOMBRE_EJERCICIO"
            .DataSource = dView
            If dView.Count > 0 Then
                .SelectedIndex = 0
            End If
        End With
    End Sub

    Private Sub Cambia_Estado()
        Select Case Me.Estado
            Case enumEstados.AuxiliarMAyor
        End Select
        Application.DoEvents()
    End Sub

    Private Function Validar() As Boolean
        Dim sql As Class_find
        If Me.TxtCuenta1.Text <> "" Then
            sql = New Class_find("Select NOMBRE_CUENTA From CON_CAT_CUENTAS Where CUENTA_CONTABLE='" & Me.TxtCuenta1.Text & "' ")
            If sql.Result1 = "" Then
                MsgBox("La cuenta contable inicial que intenta buscar no existe, favor de intentar con otro codigo", MsgBoxStyle.Critical, "Validación de Cuentas Contables")
                Validar = False
                Me.TxtCuenta1.Focus()
                sql = Nothing
                Exit Function
            End If
        End If

        If Me.TxtCuenta2.Text <> "" Then
            sql = New Class_find("Select NOMBRE_CUENTA From CON_CAT_CUENTAS Where CUENTA_CONTABLE='" & Me.TxtCuenta2.Text & "' ")
            If sql.Result1 = "" Then
                MsgBox("La cuenta contable inicial que intenta buscar no existe, favor de intentar con otro codigo", MsgBoxStyle.Critical, "Validación de Cuentas Contables")
                Validar = False
                Me.TxtCuenta2.Focus()
                sql = Nothing
                Exit Function
            End If
        End If
        Validar = True
    End Function

    Private Sub Consultar()
        Dim StrSqlQuerry As String = ""
        Dim oReporte As New Class_AuxiliarMayor
        With oReporte
            .CUENTA_CONTABLE1 = Me.TxtCuenta1.Text
            .CUENTA_CONTABLE2 = Me.TxtCuenta2.Text
            .FECHA1 = Me.DtFechaDesde.Value
            .FECHA2 = Me.DtFechaHasta.Value
            .ID_CON_EJERCICIO = Me.CmbEjercicio.SelectedValue
            Me.Grid.DataSource = .ConsultarEgresos
        End With
        oReporte = Nothing
        Me.FormateaGrid()
    End Sub

    Private Sub FormateaGrid()

        Me.Grid.Columns("CUENTA_CONTABLE").HeaderText = "CUENTA"
        Me.Grid.Columns("FOLIO_POLIZA").HeaderText = "FOLIO"
        Me.Grid.Columns("FECHA").HeaderText = "FECHA"
        Me.Grid.Columns("CONCEPTO").HeaderText = "CONCEPTO"
        Me.Grid.Columns("ABONO").HeaderText = "ABONO"
        Me.Grid.Columns("ID_CON_EJERCICIO").HeaderText = "EJERCICIO"
        'Me.Grid.Columns("PROVEEDOR").HeaderText = "PROVEEDOR"

        Me.Grid.Columns("FECHA").DefaultCellStyle.Format = "dd/MMM/yy"
        Me.Grid.Columns("ABONO").DefaultCellStyle.Format = "$ ###,###,###.00"
        'Me.Grid.Columns("SALDO").DefaultCellStyle.Format = "$ ###,###,###.00"
        Me.Grid.Columns("ABONO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'Me.Grid.Columns("SALDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

    End Sub

    Private Function Filtros() As String
        Dim sFiltros As String


        sFiltros = ""
        Filtros = sFiltros

    End Function

    Private Sub Limpiar()
        Me.TxtCuenta1.Text = ""
        Me.LblCuenta.Text = ""
        Me.DtFechaDesde.Value = Date.Now
        Me.DtFechaHasta.Value = Date.Now
        'Me.CmbEjercicio.SelectedValue = Empresa_Sistema.ID_CON_EJERCICIO
        Me.TxtComentario.Text = ""
        Me.Grid.Rows.Clear()
    End Sub

    Private Sub Imprimir()
        Dim StrFiltros As String = ""
        Dim Rpt As ReportDocument
        Rpt = New ReportDocument
        Dim oReporte As Class_Reporte
        Try
            FormatoDeReporte = "RPT_CONTABILIDAD_EGRESOS.rpt"
            oReporte = New Class_Reporte(FormatoDeReporte, Rpt)

            Rpt.SetParameterValue("@CUENTA_CONTABLE1", "" & Me.TxtCuenta1.Text)
            Rpt.SetParameterValue("@CUENTA_CONTABLE2", "" & Me.TxtCuenta2.Text)
            Rpt.SetParameterValue("@FECHA_INICIO", Format(DtFechaDesde.Value, "yyyy-dd-MM"))
            Rpt.SetParameterValue("@FECHA_FIN", Format(DtFechaHasta.Value, "yyyy-dd-MM"))
            Rpt.SetParameterValue("@ID_CON_EJERCICIO", Me.CmbEjercicio.SelectedValue)

            Dim frm As New Reporte(Rpt)
            'frm.CRViewer.DisplayGroupTree = False
            frm.CRViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            frm.Show()
        Catch ex As Exception
            HandleError(Me.Name, "Reporte de Relaciones Analiticas", ex)
        Finally
            oReporte = Nothing
        End Try
    End Sub

#End Region

#Region "Eventos de objetos"

#Region "Eventos Genericos"
    Private Sub txt_Enter(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim oTexBox As TextBox = CType(sender, TextBox)
        oTexBox.SelectAll()
    End Sub

    Private Sub txt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtComentario.KeyDown, DtFechaDesde.KeyDown, DtFechaHasta.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCuenta1.KeyPress, TxtComentario.KeyPress, DtFechaDesde.KeyPress, DtFechaHasta.KeyPress
        txtNoBeep(e)
    End Sub
#End Region

#Region "Keydown específicos"
    Private Sub chk_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Return Then
            Me.tsbConsultar.PerformClick()
        End If
    End Sub

    Private Sub TxtCuenta1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCuenta1.KeyDown
        Select Case e.KeyCode
            Case Keys.F6
busqueda_Visual:
                Dim oCuenta As New Class_CatCuentas
                Dim sCuenta As String = oCuenta.BusquedaVisual_PorDescripcion
                If sCuenta.Length > 0 Then
                    Me.TxtCuenta1.Text = sCuenta
                    sCuenta = Replace(sCuenta, "'", "''")
                    Dim sql As New Class_find("Select NOMBRE_CUENTA From CON_CAT_CUENTAS Where CUENTA_CONTABLE='" & sCuenta & "' ")
                    Me.TxtCuenta1.Text = sCuenta
                    Me.LblCuenta.Text = sql.Result1
                    sql = Nothing
                End If
            Case Keys.F7
                Dim oCuenta As New Class_CatCuentas
                Dim sCuenta As String = oCuenta.BusquedaVisual_PorNombreFiltrandoTipoOperacion()
                If sCuenta.Length > 0 Then
                    Me.TxtCuenta1.Text = sCuenta
                    sCuenta = Replace(sCuenta, "'", "''")
                    Dim sql As New Class_find("Select CUENTA_CONTABLE,NOMBRE_CUENTA From CON_CAT_CUENTAS Where NOMBRE_CUENTA='" & sCuenta & "'   AND ID_CON_EJERCICIO='" & Me.CmbEjercicio.SelectedValue & "'")
                    Me.TxtCuenta1.Text = sql.Result1
                    Me.LblCuenta.Text = sql.Result2
                    sql = Nothing
                End If
            Case Keys.Return
                Dim sql As New Class_find("Select NOMBRE_CUENTA From CON_CAT_CUENTAS Where CUENTA_CONTABLE='" & Me.TxtCuenta2.Text & "'  AND ID_CON_EJERCICIO='" & Me.CmbEjercicio.SelectedValue & "'")
                If sql.Result1 = "" Then
                    GoTo busqueda_Visual
                End If
                sql = Nothing
                SendKeys.Send("{TAB}")
        End Select
    End Sub

    Private Sub TxtCuenta2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCuenta2.KeyDown
        Select Case e.KeyCode
            Case Keys.F6
busqueda_Visual:
                Dim oCuenta As New Class_CatCuentas
                Dim sCuenta As String = oCuenta.BusquedaVisual_PorDescripcion
                If sCuenta.Length > 0 Then
                    Me.TxtCuenta2.Text = sCuenta
                    sCuenta = Replace(sCuenta, "'", "''")
                    Dim sql As New Class_find("Select CUENTA_CONTABLE,NOMBRE_CUENTA From CON_CAT_CUENTAS Where CUENTA_CONTABLE='" & sCuenta & "'  AND ID_CON_EJERCICIO='" & Me.CmbEjercicio.SelectedValue & "'")
                    Me.TxtCuenta2.Text = sCuenta
                    Me.LblCuenta2.Text = sql.Result2
                    sql = Nothing
                End If
            Case Keys.F7
                Dim oCuenta As New Class_CatCuentas
                Dim sCuenta As String = oCuenta.BusquedaVisual_PorNombreFiltrandoTipoOperacion()
                If sCuenta.Length > 0 Then
                    Me.TxtCuenta2.Text = sCuenta
                    sCuenta = Replace(sCuenta, "'", "''")
                    Dim sql As New Class_find("Select CUENTA_CONTABLE,NOMBRE_CUENTA From CON_CAT_CUENTAS Where NOMBRE_CUENTA='" & sCuenta & "'   AND ID_CON_EJERCICIO='" & Me.CmbEjercicio.SelectedValue & "'")
                    Me.TxtCuenta2.Text = sql.Result1
                    Me.LblCuenta2.Text = sql.Result2
                    sql = Nothing
                End If
            Case Keys.Return
                Dim sql As New Class_find("Select NOMBRE_CUENTA From CON_CAT_CUENTAS Where CUENTA_CONTABLE='" & Me.TxtCuenta2.Text & "'  AND ID_CON_EJERCICIO='" & Me.CmbEjercicio.SelectedValue & "'")
                If sql.Result1 = "" Then
                    GoTo busqueda_Visual
                Else
                    Me.LblCuenta2.Text = sql.Result1
                End If
                sql = Nothing
                SendKeys.Send("{TAB}")
        End Select
    End Sub
#End Region

#Region "Validating específicos"
    Private Sub Grid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Grid.DoubleClick
        Dim Columna As Integer, Renglon As Integer, vdg As DataGridViewCell
        Columna = Convert.ToInt16(Grid.CurrentCell.ColumnIndex)
        Renglon = Convert.ToInt16(Grid.CurrentCell.RowIndex)
        vdg = Grid.Rows(Renglon).Cells("FOLIO_POLIZA")
        Dim Child As New Frm_Contabilidad_Captura_Polizas
        Child.TxtFolio.Text = "" & vdg.Value
        Child.ShowDialog()
        Child.Dispose()
    End Sub
    Private Sub Grid_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Grid.KeyDown
        Dim Columna As Integer, Renglon As Integer, vdg As DataGridViewCell
        Columna = Convert.ToInt16(Grid.CurrentCell.ColumnIndex)
        Renglon = Convert.ToInt16(Grid.CurrentCell.RowIndex)
        Select Case e.KeyCode
            Case Keys.F6
                vdg = Grid.Rows(Renglon).Cells("FOLIO_POLIZA")
                Dim Child As New Frm_Contabilidad_Captura_Polizas
                Child.TxtFolio.Text = "" & vdg.Value
                Child.ShowDialog()
                Child.Dispose()
        End Select

    End Sub
#End Region
#End Region

    Private Sub TxtCuenta2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCuenta2.KeyPress, TxtCuenta1.KeyPress
        txtSoloNumerosEnteros(e)
        txtNoBeep(e)
    End Sub
End Class


