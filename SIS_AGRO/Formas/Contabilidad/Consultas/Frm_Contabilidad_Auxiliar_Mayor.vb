Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class Frm_Contabilidad_Auxiliar_Mayor
    Private oPoliza As New Class_Contabilidad_Poliza_Global

    Private FormatoDeReporte As String = "RPT_CONTABILIDAD_AUXILIAR_DE_MAYOR"

#Region "Columnas grid"
    Private iGyCuentaContable As Integer = 1
    Private iGyNombreCuenta As Integer = 2
    Private iGyNaturaleza As Integer = 3
    Private iGyFolioPoliza As Integer = 4
    Private iGyFecha As Integer = 5
    Private iGyReferencia As Integer = 6
    Private iGyConcepto As Integer = 7
    Private iGyFacturasRecibidas As Integer = 8
    Private iGyCargo As Integer = 9
    Private iGyAbono As Integer = 10
    Private iGySaldo As Integer = 11
    Private iGyNombreListaFacturasRecibidas As Integer = 12
#End Region

#Region "Constructor y destructor"
    Public Sub New()
        InitializeComponent()

        Me.DesplegarEjercicios()
        Me.Limpiar()
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

#End Region

#Region "Opciones"
    Private Sub tsbConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbConsultar.Click
        If ValidarCuentaContable() And ValidarPeriodo() Then
            Me.Consultar()
        End If
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub

    Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click
        If ValidarCuentaContable() Then
            Me.Imprimir()
        End If
    End Sub
#End Region

#Region "Eventos de objetos"

#Region "Eventos Genericos"
    Private Sub txt_Enter(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim oTexBox As TextBox = CType(sender, TextBox)
        oTexBox.SelectAll()
    End Sub

    Private Sub txt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtFechaDesde.KeyDown, DtFechaHasta.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCuenta1.KeyPress, DtFechaDesde.KeyPress, DtFechaHasta.KeyPress
        txtNoBeep(e)
        txtSoloNumerosEnteros(e)
    End Sub
#End Region

#Region "Keydown específicos"

    Private Sub Grid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Grid.DoubleClick
        Dim Columna As Integer, Renglon As Integer, vdg As String

        Columna = Me.Grid.Selection.FirstCol
        Renglon = Me.Grid.Selection.FirstRow
        If Columna = Me.iGyFacturasRecibidas Then
            Exit Sub
        End If
        vdg = Me.Grid.Cell(Renglon, Me.iGyFolioPoliza).Text 'Grid.Rows(Renglon).Cell("FOLIO_POLIZA")
        Dim Child As New Frm_Contabilidad_Captura_Polizas()
        Child.FolioPolizaConsultaExterior = vdg.ToString
        Child.ShowDialog()
        Child.Dispose()
        Me.tsbConsultar.PerformClick()
    End Sub

    Private Sub Grid_ComboClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Grid.ComboClick
        Dim Columna As Integer, Renglon As Integer
        Columna = Me.Grid.Selection.FirstCol
        Renglon = Me.Grid.Selection.FirstRow

        Me.oPoliza = New Class_Contabilidad_Poliza_Global(Me.Grid.Cell(Renglon, Me.iGyFolioPoliza).Text)
        If oPoliza.CODIGO_TIPO_DOCUMENTO = "E" Then
            Dim sql = New Class_find("SELECT CODIGO_LISTA_FACTURAS_RECIBIDAS,NOMBRE_LISTA_FACTURAS_RECIBIDAS FROM CON_LISTA_FACTURAS_RECIBIDAS WHERE NOMBRE_LISTA_FACTURAS_RECIBIDAS='" & Me.Grid.Cell(Renglon, Me.iGyFacturasRecibidas).Text & "'")

            Me.oPoliza.CODIGO_LISTA_FACTURAS_RECIBIDAS = sql.Result1
            If Me.oPoliza.AsignaFacturasPoliza() = True Then
                'MsgBox("Se ha modificado las facturas recibidas satisfactoriamente.", MsgBoxStyle.Information, Me.Text)
            End If
        Else
            MsgBox("El documento no debe traer facturas recibidas.", MsgBoxStyle.Information, Me.Text)
            Me.tsbConsultar.PerformClick()
            Exit Sub
        End If
    End Sub

    Private Sub TxtCuenta1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCuenta1.KeyDown
        Select Case e.KeyCode
            Case Keys.F6
BusquedaVisual:
                Dim oCuenta As New Class_CatCuentas
                Dim sCuenta As String = oCuenta.BusquedaVisual_PorCodigoFiltrandoTipoOperacion()
                If sCuenta.Length > 0 Then
                    Me.TxtCuenta1.Text = sCuenta
                    sCuenta = Replace(sCuenta, "'", "''")
                    Dim sql As New Class_find("SELECT CUENTA_CONTABLE,NOMBRE_CUENTA FROM CON_CAT_CUENTAS WHERE CUENTA_CONTABLE='" & sCuenta & "'")
                    Me.TxtCuenta1.Text = sCuenta
                    Me.LblCuenta.Text = sql.Result2
                    sql = Nothing
                Else
                    Me.TxtCuenta1.Text = ""
                    Me.LblCuenta.Text = ""
                End If
            Case Keys.F7
                Dim oId As New Class_CatCuentas
                Dim sIdCodigo As String = oId.BusquedaVisual_PorNombreFiltrandoTipoOperacion()
                If sIdCodigo.Length > 0 Then
                    Me.TxtCuenta1.Text = sIdCodigo
                    sIdCodigo = Replace(sIdCodigo, "'", "''")
                    Dim sql As New Class_find("SELECT CUENTA_CONTABLE,NOMBRE_CUENTA FROM CON_CAT_CUENTAS WHERE CUENTA_CONTABLE='" & sIdCodigo & "'")
                    Me.TxtCuenta1.Text = sql.Result1
                    Me.LblCuenta.Text = sql.Result2
                    sql = Nothing
                Else
                    Me.TxtCuenta1.Text = ""
                    Me.LblCuenta.Text = ""
                End If
            Case Keys.Return
                Dim sql As New Class_find("SELECT CUENTA_CONTABLE,NOMBRE_CUENTA FROM CON_CAT_CUENTAS WHERE CUENTA_CONTABLE='" & Me.TxtCuenta1.Text & "' AND ESMAYOR=0 ")
                If sql.Result1 = "" Then
                    'MsgBox("La cuenta contable que intenta buscar es de mayor, favor de intentar con otro codigo", MsgBoxStyle.Critical, "Validación de Cuentas Contables")
                    GoTo BusquedaVisual
                Else
                    Me.LblCuenta.Text = sql.Result2
                    Me.tsbConsultar.PerformClick()
                End If
                sql = Nothing
                'SendKeys.Send("{TAB}")
        End Select
    End Sub

    Private Sub cbkMostrarContraPolizas_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbkFiltoContraPolizas.CheckedChanged
        If txtLEN(Me.TxtCuenta1.Text) = True Then
            If ValidarCuentaContable() And ValidarPeriodo() Then
                Me.Consultar()
            End If
        End If
    End Sub
#End Region

#End Region

#Region "Métodos y procedimientos"

    Private Function ValidarCuentaContable() As Boolean
        Try
            Dim sql As New Class_find("SELECT NOMBRE_CUENTA,ESMAYOR FROM CON_CAT_CUENTAS WHERE CUENTA_CONTABLE='" & "" & Me.TxtCuenta1.Text & "' ")
            If sql.Result1 = "" Then
                MsgBox("La cuenta contable que intenta buscar no existe, favor de intentar con otro codigo", MsgBoxStyle.Critical, "Validación de Cuentas Contables")
                Me.TxtCuenta1.Text = ""
                Me.LblCuenta.Text = ""
                Me.TxtCuenta1.Focus()
                sql = Nothing
                Return False
            End If
            If sql.Result2 = "1" Then
                MsgBox("La cuenta contable que intenta buscar es de mayor, favor de intentar con otro codigo", MsgBoxStyle.Critical, "Validación de Cuentas Contables")
                Me.TxtCuenta1.Text = ""
                Me.LblCuenta.Text = ""
                Me.TxtCuenta1.Focus()
                sql = Nothing
                Return False
            End If
            Return True
        Catch ex As Exception
            HandleError(Me.Name, "ValidarCuentaContable", ex)
        End Try
    End Function

    Private Function ValidarPeriodo() As Boolean
        Try
            Me.DtFechaDesde.Enabled = False
            Me.DtFechaDesde.Enabled = True
            Me.DtFechaHasta.Enabled = False
            Me.DtFechaHasta.Enabled = True

            If Me.DtFechaDesde.Value > Me.DtFechaHasta.Value Then
                MsgBox("Rango de fechas inválidas.", MsgBoxStyle.Exclamation, Me.Name)
                Return False
            End If
            Dim ValidaPeriodo As New Class_find("SELECT 1 FROM CON_EJERCICIOS WHERE (('" & Format(Me.DtFechaDesde.Value, "yyyy-dd-MM") & "' BETWEEN FECHA_INICIO AND FECHA_FINAL)) AND (('" & Format(Me.DtFechaHasta.Value, "yyyy-dd-MM") & "' BETWEEN FECHA_INICIO AND FECHA_FINAL)) AND ID_CON_EJERCICIO=" & Me.CmbEjercicio.SelectedValue.ToString)
            If ValidaPeriodo.Result1.Length <= 0 Then
                MsgBox("El rango especificado esta fuera del rango del ejercicio.", MsgBoxStyle.Exclamation, Me.Name)
                Return False
            End If
            Return True
        Catch ex As Exception
            HandleError(Me.Name, "ValidarPeriodo", ex)
        End Try
    End Function

    Private Sub Consultar()
        Try
            Dim StrSqlQuerry As String = ""
            Dim oReporte As New Class_AuxiliarMayor
            Dim dT As New DataTable

            If Me.ValidarPeriodo = False Then
                Exit Sub
            End If

            Me.Grid.AutoRedraw = False
            Me.Grid.Visible = False

            With oReporte
                .CUENTA_CONTABLE1 = Me.TxtCuenta1.Text
                .CUENTA_CONTABLE2 = Me.TxtCuenta1.Text
                .FECHA1 = Format(Me.DtFechaDesde.Value, "yyyy-dd-MM")
                .FECHA2 = Format(Me.DtFechaHasta.Value, "yyyy-dd-MM")
                .ID_CON_EJERCICIO = CInt(Me.CmbEjercicio.SelectedValue.ToString)
                .MOSTRAR_SOLO_CUENTAS_CON_SALDO_MAYOR_QUE_CERO = 0
                .FILTRO_CONTRAPOLIZAS = CInt(IIf(Me.cbkFiltoContraPolizas.Checked, "1", "0").ToString)
                dT = .Consultar

                If dT.Rows.Count > 0 Then
                    Me.txtTotalCargos.Text = FormatImporteContable(CDbl(dT.Rows(0)("CARGOS_GLOBAL")))
                    Me.txtTotalAbonos.Text = FormatImporteContable(CDbl(dT.Rows(0)("ABONOS_GLOBAL")))
                    Me.txtSaldoTotal.Text = FormatImporteContable(CDbl(dT.Rows(0)("SALDO_TOTAL")))
                End If

                dT.Columns.Remove("CARGOS_GLOBAL")
                dT.Columns.Remove("ABONOS_GLOBAL")
                dT.Columns.Remove("SALDO_TOTAL")
                Me.Grid.DataSource = dT

            End With
            oReporte = Nothing

            Me.Grid.AutoRedraw = True
            Me.Grid.Refresh()

            Me.FormateaGrid()

        Catch ex As Exception
            HandleError(Me.Name, "Consultar", ex)
        Finally
            Me.Grid.Visible = True
        End Try
    End Sub

    Private Sub Imprimir()
        Dim StrFiltros As String = ""
        Dim Rpt As New ReportDocument
        Dim oReporte As Class_Reporte
        Try
            oReporte = New Class_Reporte(FormatoDeReporte, Rpt)

            If Me.ValidarPeriodo = False Then
                Exit Sub
            End If

            If Not oReporte.RptCargado Then
                Exit Sub
            End If

            Rpt.SetParameterValue("@CUENTA_CONTABLE1", "" & Me.TxtCuenta1.Text)
            Rpt.SetParameterValue("@CUENTA_CONTABLE2", "" & Me.TxtCuenta1.Text)
            Rpt.SetParameterValue("@FECHA1", Format(DtFechaDesde.Value, "yyyy-dd-MM"))
            Rpt.SetParameterValue("@FECHA2", Format(DtFechaHasta.Value, "yyyy-dd-MM"))
            Rpt.SetParameterValue("@ID_CON_EJERCICIO", Me.CmbEjercicio.SelectedValue)
            Rpt.SetParameterValue("@MOSTRAR_SOLO_CUENTAS_CON_SALDO_MAYOR_QUE_CERO", 0)
            Rpt.SetParameterValue("@FILTRO_CONTRAPOLIZAS", CInt(IIf(Me.cbkFiltoContraPolizas.Checked, "1", "0").ToString).ToString)

            Dim frm As New Reporte(Rpt)
            frm.CRViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            frm.Show()
        Catch ex As Exception
            HandleError(Me.Name, "Imprimir", ex)
        Finally
            oReporte = Nothing
        End Try
    End Sub

    Private Sub InicializaGrid()
        Try
            Me.Grid.DataSource = Nothing
            FG_Grid_Limpiar(Grid)

            'Creamos el Grid
            Me.Grid.Rows = 2
            Me.Grid.Cols = 11
            Me.Grid.DisplayRowNumber = True

            Me.FormateaGrid()
        Catch ex As Exception
            HandleError(Me.Name, "InicializaGrid", ex)
        End Try
    End Sub

    Private Sub FormateaGrid()
        Try
            Me.Grid.AutoRedraw = False

            Me.Grid.DisplayFocusRect = False

            Me.Grid.Cell(0, Me.iGyCuentaContable).Text = "CUENTA"
            Me.Grid.Cell(0, Me.iGyNombreCuenta).Text = "NOMBRE DE CUENTA"
            Me.Grid.Cell(0, Me.iGyNaturaleza).Text = "N."
            Me.Grid.Cell(0, Me.iGyFolioPoliza).Text = "FOLIO"
            Me.Grid.Cell(0, Me.iGyFecha).Text = "FECHA"
            Me.Grid.Cell(0, Me.iGyReferencia).Text = "REFERENCIA"
            Me.Grid.Cell(0, Me.iGyConcepto).Text = "CONCEPTO"
            Me.Grid.Cell(0, Me.iGyFacturasRecibidas).Text = "FACT. RECIBIDAS"
            Me.Grid.Cell(0, Me.iGyCargo).Text = "CARGO"
            Me.Grid.Cell(0, Me.iGyAbono).Text = "ABONO"
            Me.Grid.Cell(0, Me.iGySaldo).Text = "SALDO"

            'Me.Grid.Column(Me.iGyCuentaContable).CellType = FlexCell.CellTypeEnum.HyperLink
            Me.Grid.Column(Me.iGyFecha).FormatString = ("dd/MMM/yy")
            Me.Grid.Column(Me.iGyCargo).FormatString = ("$ ###,###,###.00").ToString
            Me.Grid.Column(Me.iGyAbono).FormatString = ("$ ###,###,###.00").ToString
            Me.Grid.Column(Me.iGySaldo).FormatString = ("$ ###,###,###.00").ToString
            Me.Grid.Column(Me.iGyFacturasRecibidas).CellType = FlexCell.CellTypeEnum.ComboBox

            Dim dTabla As New DataTable("detalle"), da As SqlDataAdapter
            Dim sSQL As String = ("SELECT CODIGO_LISTA_FACTURAS_RECIBIDAS,NOMBRE_LISTA_FACTURAS_RECIBIDAS FROM CON_LISTA_FACTURAS_RECIBIDAS ORDER BY NOMBRE_LISTA_FACTURAS_RECIBIDAS")

            da = New SqlDataAdapter(sSQL, Empresa_Sistema.conexion)
            da.Fill(dTabla)
            da.Dispose()

            Me.Grid.Column(Me.iGyFacturasRecibidas).CellType = FlexCell.CellTypeEnum.ComboBox
            Me.Grid.ComboBox(Me.iGyFacturasRecibidas).DataSource = dTabla
            Me.Grid.ComboBox(Me.iGyFacturasRecibidas).DisplayMember = "NOMBRE_LISTA_FACTURAS_RECIBIDAS"
            Me.Grid.ComboBox(Me.iGyFacturasRecibidas).ValueMember = "CODIGO_LISTA_FACTURAS_RECIBIDAS"

            Dim i As Integer
            For i = 1 To Me.Grid.Rows - 1
                If txtLEN(Me.Grid.Cell(i, Me.iGyFacturasRecibidas).Text) = True Then
                    If txtLEN(Me.Grid.Cell(i, Me.iGyNombreListaFacturasRecibidas).Text) Then
                        'Me.Grid.ComboBox(Me.iGyFacturasRecibidas).DisplayMember = Me.Grid.Cell(i, Me.iGyNombreListaFacturasRecibidas).Text 'No es necesario este código hace que este ciclo sea muy lento
                        Me.Grid.Cell(i, Me.iGyFacturasRecibidas).Text = Me.Grid.Cell(i, Me.iGyNombreListaFacturasRecibidas).Text
                    End If
                    'Estaba así, y cada ciclo hacia una consulta, se cambio mejor el stored para que traiga el NOMBRE_LISTA_FACTURAS_RECIBIDAS
                    ' Dim sql As New Class_find("SELECT CODIGO_LISTA_FACTURAS_RECIBIDAS,NOMBRE_LISTA_FACTURAS_RECIBIDAS FROM CON_LISTA_FACTURAS_RECIBIDAS WHERE CODIGO_LISTA_FACTURAS_RECIBIDAS='" & Me.Grid.Cell(i, Me.iGyFacturasRecibidas).Text & "'")
                    'If txtLEN(sql.Result2) = True Then
                    '    Me.Grid.ComboBox(Me.iGyFacturasRecibidas).DisplayMember = sql.Result2.ToString
                    '    Me.Grid.Cell(i, Me.iGyFacturasRecibidas).Text = sql.Result2.ToString
                    'End If
                End If
            Next i

            Me.Grid.Column(Me.iGyFecha).Alignment = FlexCell.AlignmentEnum.CenterCenter
            Me.Grid.Column(Me.iGyAbono).Alignment = FlexCell.AlignmentEnum.RightCenter
            Me.Grid.Column(Me.iGyCargo).Alignment = FlexCell.AlignmentEnum.RightCenter
            Me.Grid.Column(Me.iGySaldo).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.iGyCuentaContable).Width = 100
            Me.Grid.Column(Me.iGyNombreCuenta).Width = 150
            Me.Grid.Column(Me.iGyNaturaleza).Width = 20
            Me.Grid.Column(Me.iGyFolioPoliza).Width = 80
            Me.Grid.Column(Me.iGyFecha).Width = 60
            Me.Grid.Column(Me.iGyReferencia).Width = 80
            Me.Grid.Column(Me.iGyConcepto).Width = 150
            Me.Grid.Column(Me.iGyFacturasRecibidas).Width = 100
            Me.Grid.Column(Me.iGyCargo).Width = 90
            Me.Grid.Column(Me.iGyAbono).Width = 90
            Me.Grid.Column(Me.iGySaldo).Width = 90
            Me.Grid.Column(Me.iGyNombreListaFacturasRecibidas).Visible = False

            Me.Grid.Column(Me.iGyCuentaContable).Locked = True
            Me.Grid.Column(Me.iGyNombreCuenta).Locked = True
            Me.Grid.Column(Me.iGyNaturaleza).Locked = True
            Me.Grid.Column(Me.iGyFolioPoliza).Locked = True
            Me.Grid.Column(Me.iGyFecha).Locked = True
            Me.Grid.Column(Me.iGyReferencia).Locked = True
            Me.Grid.Column(Me.iGyConcepto).Locked = True
            Me.Grid.Column(Me.iGyFacturasRecibidas).Locked = False
            Me.Grid.Column(Me.iGyCargo).Locked = True
            Me.Grid.Column(Me.iGyAbono).Locked = True
            Me.Grid.Column(Me.iGySaldo).Locked = True

            Me.Grid.AutoRedraw = True
            Me.Grid.Refresh()

        Catch ex As Exception
            HandleError(Me.Name, "FormateaGrid", ex)
        End Try
    End Sub

    Private Sub Limpiar()
        Me.TxtCuenta1.Text = ""
        Me.LblCuenta.Text = ""
        Me.CmbEjercicio.SelectedValue = Plaza.ID_CON_EJERCICIO
        Me.DtFechaDesde.Value = Plaza.FECHA_INICIO
        Me.DtFechaHasta.Value = Plaza.FECHA_FINAL
        Me.txtTotalCargos.Text = "0.00"
        Me.txtTotalAbonos.Text = "0.00"
        Me.txtSaldoTotal.Text = "0.00"
        'Me.Grid.Rows.Clear()
    End Sub

    Private Sub DesplegarEjercicios()
        Dim oElementos As New Class_Contabilidad_Ejercicios
        With Me.CmbEjercicio
            .DisplayMember = "NOMBRE_EJERCICIO"
            .ValueMember = "ID_CON_EJERCICIO"

            Dim dView As New Data.DataView(oElementos.ObtenerEjercicios)
            .DataSource = dView
            If dView.Count > 0 Then
                .SelectedIndex = 0
            End If
        End With
    End Sub

    Private Sub CmbEjercicio_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbEjercicio.SelectedIndexChanged
        Dim sql As New Class_find("SELECT FECHA_INICIO,FECHA_FINAL FROM CON_EJERCICIOS WHERE ID_CON_EJERCICIO=" & Me.CmbEjercicio.SelectedValue.ToString)
        Me.DtFechaDesde.Value = CDate(sql.Result1)
        Me.DtFechaHasta.Value = CDate(sql.Result2)
    End Sub

    Private Sub DtFechaHasta_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtFechaHasta.ValueChanged
        If Me.Visible = False Then
            Exit Sub
        End If
        Dim sql As New Class_find("SELECT FECHA_INICIO,FECHA_FINAL FROM CON_EJERCICIOS WHERE ID_CON_EJERCICIO='" & Me.CmbEjercicio.SelectedValue.ToString & "'")
        If Me.DtFechaHasta.Value < CDate(sql.Result1) Then
            Me.DtFechaHasta.Value = CDate(sql.Result1)
        End If
        If Me.DtFechaHasta.Value > CDate(sql.Result2) Then
            Me.DtFechaHasta.Value = CDate(sql.Result2)
        End If
    End Sub

    Private Sub DtFechaDesde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtFechaDesde.ValueChanged
        If Me.Visible = False Then
            Exit Sub
        End If
        Dim sql As New Class_find("SELECT FECHA_INICIO,FECHA_FINAL FROM CON_EJERCICIOS WHERE ID_CON_EJERCICIO='" & Me.CmbEjercicio.SelectedValue.ToString & "'")
        If Me.DtFechaDesde.Value < CDate(sql.Result1) Then
            Me.DtFechaDesde.Value = CDate(sql.Result1)
        End If
        If Me.DtFechaDesde.Value > CDate(sql.Result2) Then
            Me.DtFechaDesde.Value = CDate(sql.Result2)
        End If
    End Sub

#End Region

End Class