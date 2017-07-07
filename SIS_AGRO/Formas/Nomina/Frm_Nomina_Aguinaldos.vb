Option Strict On

Imports CrystalDecisions.CrystalReports.Engine

Public Class Frm_Nomina_Aguinaldos
    Dim oTemporada As New Class_NominaTemporada

    Private igyCodigoPuntoPago As Short = 1
    Private igyNombrePuntoPago As Short = 2
    Private igyTotalPuntoPago As Short = 3

    Private igyIdPrestacionDetalle As Short = 1
    Private igyCodigoTrabajador As Short = 2
    Private igyNombreTrabajador As Short = 3
    Private igyDiasTrabajados As Short = 4
    Private igyAguinaldo As Short = 5
    Private igyDiaJornales As Short = 6

    Private igyColumna As Integer = 1, igyRenglon As Integer = 1

#Region "Opciones"

#End Region
#Region "Eventos de objetos"
#Region "Eventos"
    Private Sub Frm_Nomina_CapturaPercepciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Inicializa()
        Me.DesplegarSemanas()
        Me.DesplegarSemanas1()
        Me.DesplegarPuntoPago()
        Me.DesplegarPuntoPago1()

        Me.CboSemana2.Text = Plaza.oSisPlazaNomina.NOMINA_NUMERO_SEMANA_ACTUAL.ToString
        'Me.GridResumenTemporada.Cell(igyColumna, igyRenglon).SetFocus()
    End Sub

    Private Sub DtpFechas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtpFechaInicioSemana1.KeyDown, DtpFechaFinSemana1.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.Send("{TAB}")
        End Select
    End Sub

    Private Sub GridSemana_KeyDown(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridResumenTemporada.KeyDown
        'Me.GestionaGrid(e)
        'Me.FormateaGrid()
    End Sub
#End Region

#Region "Eventos Genericos"
    Private Sub txtTextoKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)  'txtFolioEmbarque.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub txtNumerosEnterosKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles GridResumenTemporada.KeyPress
        txtSoloNumerosEnteros(e)
        txtNoBeep(e)
    End Sub

    Private Sub txtNumerosDecimalKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim txt As TextBox = CType(sender, TextBox)
        txtSoloNumerosDecimales(e, txt.Text)
        txtNoBeep(e)
    End Sub

    Private Sub Cbo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CboSemana2.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.Send("{TAB}")
        End Select
    End Sub
#End Region

#Region "Keydown específicos"
    Private Sub GridResumenTemperada_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridResumenTemporada.Click
        'Dim Columna As Integer, Renglon As Integer, vdg As String
        'Dim dTabla As DataTable

        'Columna = Me.GridResumenTemperada.Selection.FirstCol
        'Renglon = Me.GridResumenTemperada.Selection.FirstRow

        'Me.igyColumna = Columna
        'Me.igyRenglon = Renglon

        'vdg = Me.GridResumenTemperada.Cell(Renglon, Me.igyCodigoPuntoPago).Text
        'If txtLEN(vdg) = False Then
        '    Me.InicializaGridDia()
        '    Exit Sub
        'End If

        'Me.oDia = New Class_NominaDia()
        'Me.oDia.ID_NOMINA_DIA = CInt(Me.GridResumenTemperada.Cell(Renglon, Me.igyCodigoPuntoPago).Text)
        'dTabla = Me.oDia.ObtenerDetalleHojas
        'Me.GridTrabajadores.Rows = 1
        'For Each dRow As DataRow In dTabla.Rows
        '    Me.GridTrabajadores.AddItem(dRow(0).ToString & Chr(9) & dRow(1).ToString & Chr(9) & dRow(2).ToString & Chr(9) & dRow(3).ToString & Chr(9) & dRow(4).ToString & Chr(9) & dRow(5).ToString & Chr(9))
        'Next
        'dTabla.Dispose()

        'If Me.GridTrabajadores.Rows = 1 Then
        '    Me.GridTrabajadores.Rows = 2
        'End If

        'Me.FormateaGridTrabajadores()
        'Me.Totales()
    End Sub

    Private Sub CboSemana1_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboSemana1.SelectedValueChanged
        Try
            If Me.CboSemana1.Text = "" Then
                Exit Sub
            End If
            Dim sql As New Class_find("SELECT DATEADD(DAY, (" & (CInt(Me.CboSemana1.Text) - 1).ToString & "*7),FECHA1),DATEADD(DAY," & (CInt(Me.CboSemana1.Text) - 1).ToString & "*7,FECHA1)+6 FROM NOMINA_TEMPORADAS WHERE ID_NOMINA_TEMPORADA=" & Plaza.oSisPlazaNomina.NOMINA_ID_NOMINA_TEMPORADA_ACTIVA)
            Me.DtpFechaInicioSemana1.Value = CDate(sql.Result1.ToString)
            Me.DtpFechaFinSemana1.Value = CDate(sql.Result2.ToString)

        Catch ex As Exception
            HandleError(Me.Name, "CboSemana", ex)
        End Try
    End Sub

    Private Sub CboSemana2_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboSemana2.SelectedValueChanged
        Try
            If Me.CboSemana2.Text = "" Then
                Exit Sub
            End If
            Dim sql As New Class_find("SELECT DATEADD(DAY, (" & (CInt(Me.CboSemana2.Text) - 1).ToString & "*7),FECHA1),DATEADD(DAY," & (CInt(Me.CboSemana2.Text) - 1).ToString & "*7,FECHA1)+6 FROM NOMINA_TEMPORADAS WHERE ID_NOMINA_TEMPORADA=" & Plaza.oSisPlazaNomina.NOMINA_ID_NOMINA_TEMPORADA_ACTIVA)
            Me.DtpFechaInicioSemana2.Value = CDate(sql.Result1.ToString)
            Me.DtpFechaFinSemana2.Value = CDate(sql.Result2.ToString)

        Catch ex As Exception
            HandleError(Me.Name, "CboSemana", ex)
        End Try
    End Sub

    Private Sub cboPuntoPago1_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPuntoPago1.SelectedValueChanged
        Try
            Me.Consultar(False)
        Catch ex As Exception
            HandleError(Me.Name, "CboSemana", ex)
        End Try
    End Sub
#End Region
#End Region

#Region "Métodos y procedimientos"
    Private Sub Inicializa()
        Try
            Me.DtpFechaInicioSemana1.Value = Date.Now
            Me.DtpFechaFinSemana1.Value = Date.Now
            Me.DtpFechaInicioSemana2.Value = Date.Now
            Me.DtpFechaFinSemana2.Value = Date.Now
            Me.CboSemana2.SelectedValue = 0
            Me.CboSemana2.SelectedValue = 0
            Me.txtFactor.Text = "4.0875"
            Me.txtTotalImporte.Text = "0"
            Me.RdbNominaPuntoPago.Checked = True

            Me.InicializaGrid()
            Me.InicializaGridTrabajadores()
        Catch ex As Exception
            HandleError(Me.Name, "Inicializa", ex)
        End Try
    End Sub

    Private Sub InicializaGrid()
        Me.GridResumenTemporada.DataSource = Nothing
        FG_Grid_Limpiar(Me.GridResumenTemporada)
        Me.GridResumenTemporada.Rows = 3
        Me.GridResumenTemporada.Cols = 4
        Me.FormateaGrid()
    End Sub

    Private Sub InicializaGridTrabajadores()
        Me.GridResumenTemporada.DataSource = Nothing
        FG_Grid_Limpiar(Me.GridTrabajadores)
        Me.GridTrabajadores.Rows = 2
        Me.GridTrabajadores.Cols = 6
        Me.FormateaGridTrabajadores()
    End Sub

    Private Sub FormateaGrid()
        Me.GridResumenTemporada.Column(Me.igyCodigoPuntoPago).Width = 80
        Me.GridResumenTemporada.Column(Me.igyNombrePuntoPago).Width = 80
        Me.GridResumenTemporada.Column(Me.igyTotalPuntoPago).Width = 120

        Me.GridResumenTemporada.Cell(0, Me.igyCodigoPuntoPago).Text = "Cód."
        Me.GridResumenTemporada.Cell(0, Me.igyNombrePuntoPago).Text = "Nombre"
        Me.GridResumenTemporada.Cell(0, Me.igyTotalPuntoPago).Text = "Importe"

        Me.GridResumenTemporada.Column(Me.igyTotalPuntoPago).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
        Me.GridResumenTemporada.Column(Me.igyTotalPuntoPago).Mask = FlexCell.MaskEnum.Numeric
        Me.GridResumenTemporada.Column(Me.igyTotalPuntoPago).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
        Me.GridResumenTemporada.Column(Me.igyTotalPuntoPago).Alignment = FlexCell.AlignmentEnum.RightCenter

        Me.GridResumenTemporada.Column(Me.igyCodigoPuntoPago).Locked = True
        Me.GridResumenTemporada.Column(Me.igyCodigoPuntoPago).Visible = False
        Me.GridResumenTemporada.Column(Me.igyNombrePuntoPago).Locked = True
        Me.GridResumenTemporada.Column(Me.igyNombrePuntoPago).Visible = True
        Me.GridResumenTemporada.Column(Me.igyTotalPuntoPago).Locked = True
    End Sub

    Private Sub FormateaGridTrabajadores()
        Me.GridTrabajadores.Column(Me.igyIdPrestacionDetalle).Width = 60
        Me.GridTrabajadores.Column(Me.igyCodigoTrabajador).Width = 100
        Me.GridTrabajadores.Column(Me.igyNombreTrabajador).Width = 250
        Me.GridTrabajadores.Column(Me.igyDiasTrabajados).Width = 50
        Me.GridTrabajadores.Column(Me.igyAguinaldo).Width = 100

        Me.GridTrabajadores.Cell(0, Me.igyCodigoTrabajador).Text = "Cód. Trabajador"
        Me.GridTrabajadores.Cell(0, Me.igyNombreTrabajador).Text = "Nombre"
        Me.GridTrabajadores.Cell(0, Me.igyDiasTrabajados).Text = "Dias"
        Me.GridTrabajadores.Cell(0, Me.igyAguinaldo).Text = "Aguinaldo"

        Me.GridTrabajadores.Column(Me.igyDiasTrabajados).Mask = FlexCell.MaskEnum.Numeric
        Me.GridTrabajadores.Column(Me.igyDiasTrabajados).Alignment = FlexCell.AlignmentEnum.RightCenter

        Me.GridTrabajadores.Column(Me.igyAguinaldo).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
        Me.GridTrabajadores.Column(Me.igyAguinaldo).Mask = FlexCell.MaskEnum.Numeric
        Me.GridTrabajadores.Column(Me.igyAguinaldo).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
        Me.GridTrabajadores.Column(Me.igyAguinaldo).Alignment = FlexCell.AlignmentEnum.RightCenter

        Me.GridTrabajadores.Column(Me.igyIdPrestacionDetalle).Locked = False
        Me.GridTrabajadores.Column(Me.igyIdPrestacionDetalle).Visible = False
        Me.GridTrabajadores.Column(Me.igyCodigoTrabajador).Locked = True
        Me.GridTrabajadores.Column(Me.igyNombreTrabajador).Locked = True
        Me.GridTrabajadores.Column(Me.igyDiasTrabajados).Locked = True
        Me.GridTrabajadores.Column(Me.igyAguinaldo).Locked = False
    End Sub

    Private Function Consultar(Optional ByVal bAccion As Boolean = False) As Boolean
        Dim iSemana1 As Integer = CInt(Me.CboSemana1.SelectedValue), iSemana2 As Integer = CInt(Me.CboSemana2.SelectedValue) ', vdg As String
        Dim dTabla As DataTable

        Try
            Me.oTemporada = New Class_NominaTemporada

            If valorNumerico(Me.txtFactor.Text) <= 0 Then
                Exit Function
            End If

            dTabla = Me.oTemporada.ObtieneAgunaldos(CInt(Me.cboPuntoPago1.SelectedValue), valorNumerico(Me.txtFactor.Text), 1, iSemana1, iSemana2, bAccion)
            Me.GridTrabajadores.Rows = 1
            For Each dRow As DataRow In dTabla.Rows
                Me.lblIdPrestacionGlobal.Text = dRow(0).ToString
                Me.txtFactor.Text = dRow(4).ToString
                Me.GridTrabajadores.AddItem(dRow(6).ToString & Chr(9) & dRow(8).ToString & Chr(9) & dRow(11).ToString & Chr(9) & dRow(9).ToString & Chr(9) & dRow(10).ToString & Chr(9))
            Next
            dTabla.Dispose()

            If Me.GridTrabajadores.Rows = 1 Then
                Me.GridTrabajadores.Rows = 2
            End If

            Me.FormateaGridTrabajadores()
            Me.Totales()

            dTabla = Me.oTemporada.ObtieneResumenAgunaldo
            Me.GridResumenTemporada.Rows = 1
            For Each dRow As DataRow In dTabla.Rows
                Me.GridResumenTemporada.AddItem(dRow(1).ToString & Chr(9) & dRow(2).ToString & Chr(9) & dRow(3).ToString & Chr(9))
            Next
            dTabla.Dispose()

            Me.Totales()
            Consultar = True
        Catch ex As Exception
            HandleError(Me.Name, "Consultar", ex)
        End Try
    End Function

    Private Sub DesplegarSemanas1()
        Try
            Dim oElementos As New Class_NominaSemana
            Dim oTemperada As New Class_NominaTemporada
            oElementos = New Class_NominaSemana
            oTemperada = New Class_NominaTemporada
            oTemperada.Consultar()
            With Me.CboSemana1
                .DisplayMember = "NUMERO_SEMANA"
                .ValueMember = "ID_NOMINA_SEMANA"
                Dim dView As New Data.DataView(oElementos.ObtenerElementos())
                dView.Sort = "NUMERO_SEMANA"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedIndex = 0
                End If
            End With

        Catch ex As Exception
            HandleError(Me.Name, "DesplegarSemanas1", ex)
        End Try
    End Sub

    Private Sub DesplegarSemanas()
        Try
            Dim oElementos As New Class_NominaSemana
            Dim oTemperada As New Class_NominaTemporada
            oElementos = New Class_NominaSemana
            oTemperada = New Class_NominaTemporada
            oTemperada.Consultar()
            With Me.CboSemana2
                .DisplayMember = "NUMERO_SEMANA"
                .ValueMember = "ID_NOMINA_SEMANA"
                Dim dView As New Data.DataView(oElementos.ObtenerElementos())
                dView.Sort = "NUMERO_SEMANA"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedIndex = 0
                End If
            End With

            Me.lblTemporadaPlaza.Text = oTemperada.NOMBRE_TEMPORADA.ToString & ", " & Plaza.NOMBRE_PLAZA
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarSemanas2", ex)
        End Try
    End Sub

    Private Sub DesplegarPuntoPago()
        Try
            Dim oPuntoPago As New Class_NominaTemporada
            With Me.cboPuntoPago
                .DisplayMember = "NOMBRE_PUNTO_PAGO"
                .ValueMember = "ID_NOMINA_PRESTACIONES_GLOBAL"
                Dim dView As New Data.DataView(oPuntoPago.ObtieneResumenAgunaldo)
                dView.Sort = "NOMBRE_PUNTO_PAGO"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedValue = 1
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarPuntoPago", ex)
        End Try
    End Sub

    Private Sub DesplegarPuntoPago1()
        Try
            Dim oPuntoPago As New Class_CatPuntoPago
            With Me.cboPuntoPago1
                .DisplayMember = "NOMBRE_PUNTO_PAGO"
                .ValueMember = "CODIGO_PUNTO_PAGO"
                Dim dView As New Data.DataView(oPuntoPago.ObtenerElementos)
                dView.Sort = "NOMBRE_PUNTO_PAGO"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedValue = 1
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarPuntoPago1", ex)
        End Try
    End Sub

    Private Sub Totales()
        Me.txtTotalImporte.Text = FormatImporteContable(Redondear(FG_Grid_SumaCol(Me.GridResumenTemporada, Me.igyTotalPuntoPago), Empresa_Sistema.DECIMALES_CONTABILIDAD))
        Me.TxtTotalTrabajadores.Text = FormatImporteContable(Redondear(FG_Grid_SumaCol(Me.GridTrabajadores, Me.igyAguinaldo), Empresa_Sistema.DECIMALES_CONTABILIDAD))
    End Sub

    Public Function ValidarNominaPuntosPago() As Boolean

        ValidarNominaPuntosPago = True
    End Function

    Private Sub GestionaGrid(ByVal e As System.Windows.Forms.KeyEventArgs)
        Dim Columna As Integer, Renglon As Integer
        Dim StrCod As String

        Columna = Me.GridTrabajadores.Selection.FirstCol
        Renglon = Me.GridTrabajadores.Selection.FirstRow
        StrCod = Me.GridTrabajadores.Cell(Renglon, Me.igyCodigoTrabajador).Text

        Select Case e.KeyCode
            Case Keys.Enter
                Select Case Columna

                    Case Me.igyAguinaldo
                        If txtLEN(Me.GridTrabajadores.Cell(Renglon, Me.igyCodigoTrabajador).Text) = True Then
                            If valorNumerico(Me.GridTrabajadores.Cell(Renglon, Me.igyAguinaldo).Text) <= 0 Then
                                MsgBox("El aguinaldo debe de ser mayor a 0.", MsgBoxStyle.Exclamation, Me.Text)
                                Me.GridTrabajadores.Cell(Renglon, Me.igyAguinaldo).SetFocus()
                                e.SuppressKeyPress = True
                                Exit Sub
                            End If
                        Else
                            Me.GridTrabajadores.Cell(Renglon, Me.igyAguinaldo).Text = ""
                        End If

                        If Me.GridTrabajadores.Rows > Renglon + 1 Then
                            Me.GridTrabajadores.Cell(Renglon + 1, Me.igyDiasTrabajados).SetFocus()
                        End If
                End Select

            Case Keys.F8, Keys.Delete
                If Me.GridTrabajadores.Rows > 2 Then
                    If valorNumerico(Me.GridTrabajadores.Cell(Renglon, Me.igyCodigoTrabajador).Text) > 0 Then
                        'If Me.oTemporada.GrabaAgunaldo(CInt(Me.GridTrabajadores.Cell(Renglon, Me.igyCodigoTrabajador).Text), valorNumerico(Me.GridTrabajadores.Cell(Renglon, Me.igyAguinaldo).Text), False) = True Then
                        Me.GridTrabajadores.Selection.DeleteByRow()
                        e.SuppressKeyPress = True
                        Me.Totales()
                        Exit Sub
                        'Else
                        '    e.SuppressKeyPress = True
                        '    Exit Sub
                        'End If
                    Else
                        Me.GridTrabajadores.Selection.DeleteByRow()
                    End If
                    e.SuppressKeyPress = True
                    Me.Totales()
                End If
        End Select

        Me.Totales()
    End Sub
#End Region

    Private Sub btnGenerar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        If Me.GridTrabajadores.Rows > 2 Then
            If MsgBox("Los aguinaldos generados podrian perderse, Desea continuar?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "Generar") = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        Me.Consultar(True)
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        Me.Grabar
    End Sub

    Private Sub btnImprimirReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimirReporte.Click
        Dim StrFiltros As String = ""
        Dim FormatoDeReporte As String = ""
        Dim Rpt As ReportDocument
        Rpt = New ReportDocument
        Dim oReporte As Class_Reporte
        Try
            If Me.RdbNominaPuntoPago.Checked = True Then
                FormatoDeReporte = "RPT_NOMINA_PRESTACIONES_POR_PUNTO_PAGO"
            ElseIf Me.RdbDistribucionEfectivo.Checked = True Then
                FormatoDeReporte = "RPT_NOMINA_PRESTACIONES_EFECTIVO_Y_TOTALES"
            ElseIf Me.rdbSobres.Checked = True Then
                FormatoDeReporte = "RPT_NOMINA_PRESTACIONES_SOBRES"
            End If

            oReporte = New Class_Reporte(FormatoDeReporte, Rpt)
            If Not oReporte.RptCargado Then
                Exit Sub
            End If

            Rpt.SetParameterValue("@ID_NOMINA_TEMPORADA", 2)
            'If Me.RdbNominaPuntoPago.Checked = True Then
            '    Rpt.SetParameterValue("@ID_NOMINA_PRESTACIONES_GLOBAL", CInt(Me.cboPuntoPago.SelectedValue))
            If Me.RdbDistribucionEfectivo.Checked = True Then
                Rpt.SetParameterValue("@CODIGO_PUNTO_PAGO", 0)
            Else
                Rpt.SetParameterValue("@CODIGO_PUNTO_PAGO", CInt(Me.cboPuntoPago.SelectedValue))
            End If

            Dim frm As New Reporte(Rpt)
            frm.CRViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            frm.Show()
        Catch ex As Exception
            HandleError(Me.Name, "btnImprimirReporte", ex)
        Finally
            oReporte = Nothing
        End Try
    End Sub

    Private Sub GridTrabajadores_KeyDown(ByVal Sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridTrabajadores.KeyDown
        Me.GestionaGrid(e)
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        If txtLEN(Me.txtCodigoTrabajador.Text) = True Then
            Me.ValidarTrabajador()
        End If
    End Sub

    Private Sub txtCodigoTrabajador_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigoTrabajador.KeyDown
        Dim sText As String
        Dim oTrabajadores As New Class_CatTrabajadores

        Select Case e.KeyCode
            Case Keys.F6
Buscar:
                sText = oTrabajadores.BusquedaVisual_PorDescripcion_PuntoPago(CInt(Me.cboPuntoPago1.SelectedValue))
                If txtLEN(sText) = True Then Me.txtCodigoTrabajador.Text = sText
            Case Keys.Enter
                If txtLEN(Me.txtCodigoTrabajador.Text) = False Then
                    GoTo Buscar : Exit Sub
                End If

                oTrabajadores = New Class_CatTrabajadores(Me.txtCodigoTrabajador.Text, True)
                If oTrabajadores.Existe = False Then
                    GoTo Buscar : Exit Sub
                End If

                'Me.GridTrabajadores.Rows = 1
                'For Each dRow As DataRow In dTabla.Rows
                'Me.lblIdPrestacionGlobal.Text = dRow(0).ToString
                'Me.GridTrabajadores.AddItem(oTrabajadores.CODIGO_TRABAJADOR.ToString & Chr(9) & oTrabajadores.APELLIDO_PATERNO + " " + oTrabajadores.APELLIDO_MATERNO + " " + oTrabajadores.NOMBRE_TRABAJADOR & Chr(9) & dRow(11).ToString & Chr(9) & dRow(9).ToString & Chr(9) & dRow(10).ToString & Chr(9))
                'Next

        End Select
    End Sub

    Private Function ValidarTrabajador() As Boolean
        Dim bResultado As Boolean = False
        Try
            Dim oTrabajadores As New Class_CatTrabajadores(Me.txtCodigoTrabajador.Text, True)
            If oTrabajadores.Existe = False Then
                MsgBox("El trabajador no existe", MsgBoxStyle.Exclamation, "ValidarTrabajador")
                Exit Function
            End If

            If oTrabajadores.CODIGO_PUNTO_PAGO <> CInt(Me.cboPuntoPago1.SelectedValue) Then
                MsgBox("El trabajador no tiene el punto de pago " & Me.cboPuntoPago1.Text & ", favor de verificar.", MsgBoxStyle.Exclamation, "ValidarTrabajador")
                Exit Function
            End If

            Dim i As Integer
            Dim sCodigoTrabajador As String = Me.txtCodigoTrabajador.Text

            For i = 1 To Me.GridTrabajadores.Rows - 1
                If txtLEN(sCodigoTrabajador) = True Then
                    If sCodigoTrabajador = Me.GridTrabajadores.Cell(i, Me.igyCodigoTrabajador).Text Then
                        MsgBox("El trabajador ya esta agregado, favor de verificar.", MsgBoxStyle.Exclamation, "Validación")
                        Exit Function
                    End If
                End If
            Next i

            MsgBox("temporada fija a 2, avise al depto de sistemas.")
            Return False

            Dim sql As New Class_find("SELECT P.CODIGO_TRABAJADOR,COUNT(*),(COUNT(*)* " & Me.txtFactor.Text & ") IMPORTE " &
                                   "FROM VW_NOMINA_HOJAS_PERCEPCIONES_EXTENDIDA P " &
                                   "INNER JOIN NOMINA_CAT_TRABAJADORES T ON (P.CODIGO_TRABAJADOR=T.CODIGO_TRABAJADOR) " &
                                   "WHERE P.ID_NOMINA_DIA BETWEEN (SELECT ID_NOMINA_DIA FROM VW_NOMINA_DIAS_EXTENDIDA WHERE NUMERO_SEMANA=1 AND NUMERO_DIA=1 AND ID_NOMINA_TEMPORADA=P.ID_NOMINA_TEMPORADA) AND  " &
              "(SELECT ID_NOMINA_DIA FROM VW_NOMINA_DIAS_EXTENDIDA WHERE ID_NOMINA_SEMANA=" & CInt(Me.CboSemana2.SelectedValue) & " AND NUMERO_DIA=7 AND ID_NOMINA_TEMPORADA=P.ID_NOMINA_TEMPORADA) AND P.NUMERO_DIA<8   " &
                                   "AND P.ID_NOMINA_TEMPORADA=2 AND P.CODIGO_TRABAJADOR='" & Me.txtCodigoTrabajador.Text & "' GROUP BY P.CODIGO_TRABAJADOR")


            Me.GridTrabajadores.AddItem("0" & Chr(9) & oTrabajadores.CODIGO_X_TEMPORADA.ToString & Chr(9) & oTrabajadores.APELLIDO_PATERNO + " " + oTrabajadores.APELLIDO_MATERNO + " " + oTrabajadores.NOMBRE_TRABAJADOR & Chr(9) &
                                        sql.Result2.ToString & Chr(9) & sql.Result3.ToString & Chr(9))

            bResultado = True

            Me.FormateaGridTrabajadores()
            Me.Totales()

        Catch ex As Exception
            HandleError(Me.Name, "ValidarTrabajador", ex)
        End Try
    End Function

    Private Function Grabar() As Boolean
        Dim bResultado As Boolean = False, sCodigoTrabajador As String = ""
        Try
            Dim i As Integer, oTrabajador As Class_CatTrabajadores

            If MsgBox("Deseas grabar la modificación de los aguinaldo de los trabajadores?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "Grabar") = MsgBoxResult.No Then
                Return False
            End If

            If Me.oTemporada.GrabaAguinaldo(CInt(Me.lblIdPrestacionGlobal.Text), valorNumerico(Me.GridTrabajadores.Cell(1, Me.igyAguinaldo).Text), False) = False Then
                Return False
            End If

            For i = 1 To Me.GridTrabajadores.Rows - 1
                sCodigoTrabajador = Me.GridTrabajadores.Cell(i, Me.igyCodigoTrabajador).Text
                If sCodigoTrabajador <> "" Then
                    oTrabajador = New Class_CatTrabajadores(sCodigoTrabajador, True)
                    If oTrabajador.Existe = False Then
                        MsgBox("El trabajador " & sCodigoTrabajador & " no existe.", vbExclamation, Me.Text)
                        Return False
                    End If
                    If Me.oTemporada.GrabaAguinaldo(CInt(Me.lblIdPrestacionGlobal.Text), valorNumerico(Me.GridTrabajadores.Cell(i, Me.igyAguinaldo).Text), True, oTrabajador.CODIGO_TRABAJADOR,
                                                    CInt(Me.GridTrabajadores.Cell(i, Me.igyDiasTrabajados).Text)) = False Then
                        Return False
                    End If
                End If
            Next i

            bResultado = True
            MsgBox("Los aguinaldos se grabaron satisfactoriamente. ", MsgBoxStyle.Information, Me.Text)
            Me.Consultar()

        Catch ex As Exception
            HandleError(Me.Name, "Grabar", ex)
        End Try

        Return bResultado
    End Function
End Class