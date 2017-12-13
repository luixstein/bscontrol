Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class RptCentrosCostosNavegador

    Private FormatoDeReporte As String = "RPT_CENTROS_COSTOS_NAVEGADOR"
    Private sCuentaConcepto As String = ""

#Region "Columnas grid navegador"
    'Private iGyIdTrans As Short = 1
    'Private iGyCuenta As Short = 2
    'Private iGyNombreCuenta As Short = 3
    'Private iGyEsMayor As Short = 4
    'Private iGyEjercido As Short = 5
    'Private iGyParticipacion As Short = 6
    'Private iGyHectareas As Short = 7
    'Private iGyEjercidoHectareas As Short = 8
    Private iGyIdTrans As Short = 1
    Private iGyCuenta As Short = 2
    Private iGyTipo As Short = 3
    Private iGyNombreCuenta As Short = 4
    Private iGyEsMayor As Short = 5
    Private iGyEjercido As Short = 6
    Private iGyParticipacion As Short = 7
    Private iGyHectareas As Short = 8
    Private iGyEjercidoHectareas As Short = 9
#End Region

#Region "Columnas grid movimientos"
    Private iGyMovFolio As Short = 1
    Private iGyMovCodigoDocumento As Short = 2
    Private iGyMovFecha As Short = 3
    Private iGyMovCodigoCentroCosto As Short = 4
    Private iGyMovNombreCentroCosto As Short = 5
    Private iGyMovCodigoCategoria As Short = 6
    Private iGyMovNombreCategoria As Short = 7
    Private iGyMovCodigoConcepto As Short = 8
    Private iGyMovNombreConcepto As Short = 9
    Private iGyMovImporte As Short = 10
#End Region

#Region "Constructor y destructor"
    Public Sub New()
        InitializeComponent()

        Me.Limpiar()
        Me.ConsultaTemporadaActual()
        Me.Consultar()
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
#End Region

#Region "Opciones"
    Private Sub tsbSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub

    Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click
        Me.Imprimir()
    End Sub

    Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        'Me.btnSubeNivel_Click(sender, e)
        Me.Consultar()
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

    Private Sub txtKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCuenta1.KeyPress, DtFechaDesde.KeyPress, DtFechaHasta.KeyPress, TxtCodigoTemporada.KeyPress
        txtNoBeep(e)
        txtSoloNumerosEnteros(e)
    End Sub
#End Region

#Region "Eventos específicos"
    Private Sub btnSubeNivel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubeNivel.Click
        Dim oParametros As New Class_SisContabilidadParametros
        Dim i As Integer
        Dim iLenParametos As Integer
        iLenParametos = 3

        i = Len(Me.TxtCuenta1.Text)

        If i < iLenParametos Then
            MsgBox("Es la raiz de las cuentas contables", MsgBoxStyle.Critical, "Validación de Cuentas Contables")
            Me.btnSubeNivel.Enabled = False
        ElseIf i = iLenParametos Then
            Me.TxtCuenta1.Text = "" 'Me.TxtCuenta1.Text.Substring(0, 1)
            Me.btnSubeNivel.Enabled = False
            Me.txtPresupuesto.Visible = True : Me.txtEjercido.Visible = True
        ElseIf i = iLenParametos + iLenParametos Then
            Me.TxtCuenta1.Text = Me.TxtCuenta1.Text.Substring(0, iLenParametos)
            Me.btnSubeNivel.Enabled = True
            Me.txtPresupuesto.Visible = False : Me.txtEjercido.Visible = False
        ElseIf i = iLenParametos + iLenParametos + iLenParametos Then
            Me.TxtCuenta1.Text = Me.TxtCuenta1.Text.Substring(0, iLenParametos + iLenParametos)
            Me.btnSubeNivel.Enabled = True
            Me.txtPresupuesto.Visible = False : Me.txtEjercido.Visible = False
        ElseIf i = iLenParametos + iLenParametos + iLenParametos + iLenParametos Then
            Me.TxtCuenta1.Text = Me.TxtCuenta1.Text.Substring(0, iLenParametos + iLenParametos + iLenParametos)
            Me.btnSubeNivel.Enabled = True
            Me.txtPresupuesto.Visible = False : Me.txtEjercido.Visible = False
        ElseIf i = iLenParametos + iLenParametos + iLenParametos + iLenParametos + iLenParametos Then
            Me.TxtCuenta1.Text = Me.TxtCuenta1.Text.Substring(0, iLenParametos + iLenParametos + iLenParametos + iLenParametos)
            Me.btnSubeNivel.Enabled = True
            Me.txtPresupuesto.Visible = False : Me.txtEjercido.Visible = False
        End If
        Me.TxtCuenta2.Text = Me.TxtCuenta1.Text
        Me.Consultar()
    End Sub

    Private Sub Grid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Grid.DoubleClick
        Try
            Dim Renglon As Integer = Me.Grid.Selection.FirstRow

            If Renglon = 0 Then
                Return
            End If

            If Me.Grid.Cell(Renglon, Me.iGyCuenta).Text.Length >= 9 Then
                'Me.Consultar(False)
                Me.sCuentaConcepto = Me.Grid.Cell(Renglon, Me.iGyCuenta).Text()
                Me.ConsultarGridMovimientos()
                Return
            End If

            Me.TxtCuenta1.Text = Me.Grid.Cell(Renglon, Me.iGyCuenta).Text
            Me.TxtCuenta2.Text = Me.Grid.Cell(Renglon, Me.iGyCuenta).Text

            If Len(Me.TxtCuenta1.Text) > 1 Then
                Me.btnSubeNivel.Enabled = True
                Me.txtPresupuesto.Visible = False : Me.txtEjercido.Visible = False
            End If

            Me.Consultar()
        Catch ex As Exception
            HandleError(Me.Name, "Grid_DoubleClick", ex)
        End Try
    End Sub

    Private Sub Grid_GotFocus(sender As Object, e As EventArgs) Handles Grid.GotFocus
        Me.GridMovimientos.Visible = False
    End Sub

    Private Sub GridMovimientos_Leave(sender As Object, e As EventArgs) Handles GridMovimientos.Leave
        Me.GridMovimientos.Visible = False
    End Sub

    Private Sub GridMovimientos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridMovimientos.DoubleClick
        Dim Renglon As Integer, sFolio As String = "", sCodigoDocumento As String = ""

        Try
            Renglon = Me.GridMovimientos.Selection.FirstRow

            sFolio = Me.GridMovimientos.Cell(Renglon, Me.iGyMovFolio).Text
            sCodigoDocumento = Me.GridMovimientos.Cell(Renglon, Me.iGyMovCodigoDocumento).Text

            If txtLEN(sFolio) = False Then
                Return
            End If

            Dim oCostos As New FrmCostosEdicion(sFolio, sCodigoDocumento)

            If oCostos.bMovimientoEncontrado = True Then
                oCostos.ShowDialog()
                oCostos.Dispose()

                'Refrescamos ambos grids
                Me.ConsultarGridMovimientos()
                Me.Consultar()
            End If

        Catch ex As Exception
            HandleError(Me.Name, "tsbEditar_Click", ex)
        End Try

    End Sub

    Private Sub TxtCodigoTemporada_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCodigoTemporada.KeyDown
        Dim oTemporada As New Class_NominaTemporada
        Dim sText As String
        Dim sql As Class_find

        Select Case e.KeyCode
            Case Keys.F6
Buscar:
                sText = oTemporada.BusquedaVisual
                If txtLEN(sText) = True Then Me.TxtCodigoTemporada.Text = sText

            Case Keys.Enter
                If txtLEN(Me.TxtCodigoTemporada.Text) = True Then
                    oTemporada.ID_NOMINA_TEMPORADA = CInt(Me.TxtCodigoTemporada.Text)

                    sql = New Class_find("SELECT CODIGO_TEMPORADA,NOMBRE_TEMPORADA,FECHA1,FECHA2 FROM NOMINA_TEMPORADAS WHERE CODIGO_TEMPORADA =" & Me.TxtCodigoTemporada.Text)

                    If txtLEN(sql.Result1) = False Then
                        GoTo Buscar
                    End If

                    Me.LblNombreTemporada.Text = sql.Result2
                    Me.DtFechaDesde.Value = CDate(sql.Result3)
                    Me.DtFechaHasta.Value = CDate(sql.Result4)

                Else
                    Me.LblNombreTemporada.Text = ""
                End If

                txtTAB(e)
        End Select

        

    End Sub

#End Region

#End Region

#Region "Métodos y procedimientos"
    Private Sub Consultar()
        Try
            Dim dt As New DataTable

            Me.Grid.AutoRedraw = False
            Me.InicializaGrid()

            Me.Grid.Rows = dt.Rows.Count + 1
            Me.Grid.Row(0).Visible = True

            Me.Grid.SelectionMode = FlexCell.SelectionModeEnum.ByRow
            Me.Grid.DisplayFocusRect = False
            Me.Grid.ExtendLastCol = False
            Me.Grid.LockButton = True
            Me.Grid.ReadonlyFocusRect = FlexCell.FocusRectEnum.Solid
            Me.Grid.BorderStyle = FlexCell.BorderStyleEnum.Light3D
            Me.Grid.ScrollBars = FlexCell.ScrollBarsEnum.Vertical
            Me.Grid.DefaultFont = New Font("Tahoma", 8)

            Dim oCentroCosto As New Class_Centros_Costos_Global
            dt = oCentroCosto.ObtieneNavegador(Format(Me.DtFechaDesde.Value, "yyyy-dd-MM"), Format(Me.DtFechaHasta.Value, "yyyy-dd-MM"), Me.TxtCuenta1.Text, Me.TxtCuenta2.Text)

            Me.Grid.DataSource = dt

            'Dim i As Integer = 1
            'Me.Grid.Rows = 1
            'For Each dRow As DataRow In dt.Rows
            '    Me.Grid.AddItem(dRow("IDTRANS").ToString & Chr(9) & dRow("CUENTA").ToString & Chr(9) & dRow("NOMBRE_CUENTA").ToString & Chr(9) & dRow("ESMAYOR").ToString & Chr(9) &
            '                    FormatImporteContable(CDbl(dRow("EJERCIDO"))).ToString & Chr(9) &
            '                    Format(dRow("POR_PARTICIPACION"), "###.#0") & "%" & Chr(9) & dRow("HECTAREAS_SEMBRADAS").ToString & Chr(9) & dRow("EJERCIDO_POR_HECTAREA").ToString)
            '    'Format(dRow("POR_PARTICIPACION"), "###.#0") & "%" & Chr(9) & dRow("HECTAREAS_SEMBRADAS").ToString & Chr(9) & FormatImporteContable(CDbl(dRow("EJERCIDO_POR_HECTAREA").ToString)))
            '    i = i + 1
            'Next

            Me.FormateaGrid()
            Me.Totales()

        Catch ex As Exception
            HandleError(Me.Name, "Consultar", ex)
        Finally
            'oReporte = Nothing
            Me.Grid.AutoRedraw = True
            Me.Grid.Refresh()
        End Try
    End Sub

    Private Sub ConsultarGridMovimientos()
        Try
            Dim dt As New DataTable
            With Me.GridMovimientos

                .AutoRedraw = False
                Me.InicializaGridMovimientos()

                .Rows = dt.Rows.Count + 1
                .Row(0).Visible = True

                .SelectionMode = FlexCell.SelectionModeEnum.Free 'ByRow
                .DisplayFocusRect = False
                .ExtendLastCol = False
                .LockButton = True
                .ReadonlyFocusRect = FlexCell.FocusRectEnum.Solid
                .BorderStyle = FlexCell.BorderStyleEnum.Light3D
                .ScrollBars = FlexCell.ScrollBarsEnum.Vertical
                .DefaultFont = New Font("Tahoma", 8)

                Dim oCentroCosto As New Class_Centros_Costos_Global
                dt = oCentroCosto.ObtieneReporteMovimientos(Format(Me.DtFechaDesde.Value, "yyyy-dd-MM"), Format(Me.DtFechaHasta.Value, "yyyy-dd-MM"), sCuentaConcepto.Substring(0, 3), sCuentaConcepto.Substring(3, 3), sCuentaConcepto.Substring(6, 3))

                'FOLIO_MOVIMIENTO	CODIGO_DOCUMENTO	FECHA	                CODIGO_CENTRO_COSTO	NOMBRE_CENTRO_COSTO	CODIGO_CATEGORIA	NOMBRE_CATEGORIA	CODIGO_CONCEPTO	NOMBRE_CONCEPTO	IMPORTE
                'S0001-000640	    SAI1	            2016-08-08 13:34:00.000	8	                ADMINISTRACIÓN	    18	                ALMACEN QUIMICOS	3	            ACTUALIZACIONES	200.00

                .DataSource = dt
                .Row(.Rows - 1).Locked = True

                'Dim i As Integer = 1
                '.Rows = 1
                'For Each dRow As DataRow In dt.Rows
                '    .AddItem(dRow("FOLIO_MOVIMIENTO").ToString & Chr(9) & dRow("CODIGO_DOCUMENTO").ToString & Chr(9) & dRow("FECHA").ToString & Chr(9) & dRow("CODIGO_CENTRO_COSTO").ToString & Chr(9) & _
                '            dRow("NOMBRE_CENTRO_COSTO").ToString & Chr(9) & dRow("CODIGO_CATEGORIA").ToString & Chr(9) & dRow("NOMBRE_CATEGORIA").ToString & Chr(9) & dRow("CODIGO_CONCEPTO").ToString & Chr(9) & _
                '                     dRow("NOMBRE_CONCEPTO").ToString & Chr(9) & FormatImporteContable(CDbl(dRow("IMPORTE"))).ToString & Chr(9))
                '    i = i + 1
                'Next

                Me.FormateaGridMovimientos()

                .Visible = True
                .BringToFront()
                .Focus()
            End With
        Catch ex As Exception
            HandleError(Me.Name, "ConsultarGridMovimientos", ex)
        Finally
            'oReporte = Nothing
            Me.GridMovimientos.AutoRedraw = True
            Me.GridMovimientos.Refresh()
        End Try
    End Sub

    Private Sub Imprimir()
        Dim StrFiltros As String = ""
        Dim Rpt As New ReportDocument
        Dim oReporte As Class_Reporte
        Try
            oReporte = New Class_Reporte(FormatoDeReporte, Rpt)

            If Not oReporte.RptCargado Then
                Exit Sub
            End If

            Rpt.SetParameterValue("@CUENTA1", Me.TxtCuenta1.Text)
            Rpt.SetParameterValue("@CUENTA2", Me.TxtCuenta2.Text)
            Rpt.SetParameterValue("@FECHA1", Format(Me.DtFechaDesde.Value, "yyyy-dd-MM"))
            Rpt.SetParameterValue("@FECHA2", Format(Me.DtFechaHasta.Value, "yyyy-dd-MM"))

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
            Me.Grid.Cols = 9
            Me.Grid.DisplayRowNumber = True

            'Me.FormateaGrid()
        Catch ex As Exception
            HandleError(Me.Name, "InicializaGrid", ex)
        End Try
    End Sub

    Private Sub InicializaGridMovimientos()
        Try
            Me.GridMovimientos.DataSource = Nothing
            FG_Grid_Limpiar(GridMovimientos)

            'Creamos el Grid
            Me.GridMovimientos.Rows = 2
            Me.GridMovimientos.Cols = 11
            Me.GridMovimientos.DisplayRowNumber = True

            Me.FormateaGridMovimientos()
        Catch ex As Exception
            HandleError(Me.Name, "InicializaGridMovimientos", ex)
        End Try
    End Sub

    Private Sub ConsultaTemporadaActual()
        Dim oTemporada As New Class_NominaTemporada

        Try
            If oTemporada.Consultar() = False Then
                MsgBox("Error al consultar el codigo de la temporada actual.", MsgBoxStyle.Exclamation, Me.Text)
                Exit Sub
            End If

            Me.TxtCodigoTemporada.Text = oTemporada.CODIGO_TEMPORADA.ToString
            Me.LblNombreTemporada.Text = oTemporada.NOMBRE_TEMPORADA
            Me.DtFechaDesde.Value = CDate(oTemporada.FECHA1)
            Me.DtFechaHasta.Value = CDate(oTemporada.FECHA2)

        Catch ex As Exception
            HandleError(Me.Name, "ConsultaTemporadaActual", ex)
        End Try
    End Sub

    Private Sub FormateaGrid()
        Try
            Me.Grid.Cell(0, Me.iGyIdTrans).Text = "id"
            Me.Grid.Cell(0, Me.iGyCuenta).Text = "Cuenta"
            Me.Grid.Cell(0, Me.iGyNombreCuenta).Text = "Descripción"
            Me.Grid.Cell(0, Me.iGyEsMayor).Text = "EsMayor"
            Me.Grid.Cell(0, Me.iGyEjercido).Text = "Ejercido"
            Me.Grid.Cell(0, Me.iGyParticipacion).Text = "Part. %"
            Me.Grid.Cell(0, Me.iGyHectareas).Text = "Ha."
            Me.Grid.Cell(0, Me.iGyEjercidoHectareas).Text = "Ejercido x Ha."

            Me.Grid.Column(Me.iGyEjercido).Alignment = FlexCell.AlignmentEnum.RightCenter
            Me.Grid.Column(Me.iGyParticipacion).Alignment = FlexCell.AlignmentEnum.RightCenter
            Me.Grid.Column(Me.iGyHectareas).Alignment = FlexCell.AlignmentEnum.RightCenter
            Me.Grid.Column(Me.iGyEjercidoHectareas).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.iGyCuenta).Width = 120
            Me.Grid.Column(Me.iGyNombreCuenta).Width = 280
            Me.Grid.Column(Me.iGyEjercido).Width = 110
            Me.Grid.Column(Me.iGyParticipacion).Width = 110
            Me.Grid.Column(Me.iGyHectareas).Width = 110
            Me.Grid.Column(Me.iGyEjercidoHectareas).Width = 110

            Me.Grid.Column(Me.iGyIdTrans).Visible = False
            Me.Grid.Column(Me.iGyCuenta).Locked = True
            Me.Grid.Column(Me.iGyTipo).Visible = False
            Me.Grid.Column(Me.iGyNombreCuenta).Locked = True
            Me.Grid.Column(Me.iGyEsMayor).Visible = False
            Me.Grid.Column(Me.iGyEjercido).Locked = True
            Me.Grid.Column(Me.iGyParticipacion).Locked = True
            Me.Grid.Column(Me.iGyHectareas).Locked = True
            Me.Grid.Column(Me.iGyEjercidoHectareas).Locked = True

            Me.Grid.Column(Me.iGyEjercido).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
            'Me.Grid.Column(Me.iGyParticipacion).FormatString = "%" '"##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD) & " %" ' no  pude formatear porque con % sale un numero muy alto
            Me.Grid.Column(Me.iGyEjercidoHectareas).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)

        Catch ex As Exception
            HandleError(Me.Name, "FormateaGrid", ex)
        End Try
    End Sub

    Private Sub FormateaGridMovimientos()
        Try

            'FOLIO_MOVIMIENTO	CODIGO_DOCUMENTO	FECHA	                CODIGO_CENTRO_COSTO	NOMBRE_CENTRO_COSTO	CODIGO_CATEGORIA	NOMBRE_CATEGORIA	CODIGO_CONCEPTO	NOMBRE_CONCEPTO	IMPORTE
            With Me.GridMovimientos
                .Cell(0, Me.iGyMovFolio).Text = "Folio"
                .Cell(0, Me.iGyMovCodigoDocumento).Text = "Código doc"
                .Cell(0, Me.iGyMovFecha).Text = "Fecha"
                .Cell(0, Me.iGyMovCodigoCentroCosto).Text = "Código centro costo"
                .Cell(0, Me.iGyMovNombreCentroCosto).Text = "Nombre centro costo"
                .Cell(0, Me.iGyMovCodigoCategoria).Text = "Código categoria"
                .Cell(0, Me.iGyMovNombreCategoria).Text = "Nombre categoria"
                .Cell(0, Me.iGyMovCodigoConcepto).Text = "Código concepto"
                .Cell(0, Me.iGyMovNombreConcepto).Text = "Nombre concepto"
                .Cell(0, Me.iGyMovImporte).Text = "Importe"

                .Column(Me.iGyMovImporte).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGyMovFecha).FormatString = ("dd/MMM/yy")

                .Column(Me.iGyMovFolio).Locked = False : .Column(Me.iGyMovFolio).Width = 100
                .Column(Me.iGyMovCodigoDocumento).Visible = False
                .Column(Me.iGyMovFecha).Locked = True : .Column(Me.iGyMovFecha).Width = 100
                .Column(Me.iGyMovCodigoCentroCosto).Visible = False
                .Column(Me.iGyMovNombreCentroCosto).Visible = False
                .Column(Me.iGyMovCodigoCategoria).Visible = False
                .Column(Me.iGyMovNombreCategoria).Visible = False
                .Column(Me.iGyMovCodigoConcepto).Visible = False
                .Column(Me.iGyMovNombreConcepto).Locked = True : .Column(Me.iGyMovNombreConcepto).Width = 200
                .Column(Me.iGyMovImporte).Locked = True : .Column(Me.iGyMovImporte).Width = 150
            End With
        Catch ex As Exception
            HandleError(Me.Name, "FormateaGridMovimientos", ex)
        End Try
    End Sub

    Private Sub Limpiar()
        Me.txtPresupuesto.Text = "0.00"
        Me.txtEjercido.Text = "0.00"
        Me.DtFechaDesde.Value = Plaza.FECHA_INICIO
        Me.DtFechaHasta.Value = Date.Now
    End Sub

    Private Sub Totales()
        Try
            'Me.txtPresupuesto.Text = FormatImporteContable(Redondear(FG_Grid_SumaCol(Me.Grid, Me.iGyPresupuesto), Empresa_Sistema.DECIMALES_CONTABILIDAD))
            Me.txtEjercido.Text = FormatImporteContable(Redondear(FG_Grid_SumaCol(Me.Grid, Me.iGyEjercido), Empresa_Sistema.DECIMALES_CONTABILIDAD))
        Catch ex As Exception
            HandleError(Me.Name, "Totales", ex)
        End Try
    End Sub

#End Region

End Class