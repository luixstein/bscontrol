Option Strict On

Imports Microsoft.VisualBasic
Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Data.Common
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Collections
Imports System.Collections.Generic
Imports CrystalDecisions.CrystalReports.Engine

Public Class Frm_Embarques_CapturaCajasProducidas

#Region "Columnas grid"
    Private igyID As Short = 1
    Private igyFolio As Short = 2
    Private igyFecha As Short = 3
    Private igyCodigoLote As Short = 4
    Private igyCodigoCultivo As Short = 5
    Private igyNumMalla As Short = 6
    Private igyNumRaca As Short = 7
    Private igyNumBin As Short = 8
    Private igyNumCajas As Short = 9
    Private igyPeso As Short = 10
    Private igyOperador As Short = 11
    Private igyUnidad As Short = 12
    Private igyPlacas As Short = 13
    Private igyHoraSalida As Short = 14
    Private igyFleteAcarreo As Short = 15
    Private igyFleteEntrega As Short = 16
#End Region

#Region "Propiedades"
#End Region

#Region "Opciones"
    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        Dim StrFiltros As String = ""
        Dim FormatoDeReporte As String = ""
        Dim Rpt As ReportDocument
        Rpt = New ReportDocument
        Dim oReporte As Class_Reporte
        Try

            FormatoDeReporte = "RPT_EMB_PRODUCCION_CAJAS"

            oReporte = New Class_Reporte(FormatoDeReporte, Rpt)
            If Not oReporte.RptCargado Then
                Exit Sub
            End If

            Rpt.SetParameterValue("@FECHA1", Format(Me.dtDesde.Value, "yyyy-dd-MM"))
            Rpt.SetParameterValue("@FECHA2", Format(Me.dtHasta.Value, "yyyy-dd-MM"))
            Rpt.SetParameterValue("@CODIGO_LOTE", Me.cboLoteRpt.SelectedValue.ToString)
            Rpt.SetParameterValue("@CODIGO_CULTIVO", Me.CboCultivoRpt.SelectedValue.ToString)

            Dim frm As New Reporte(Rpt)
            'frm.Text = Rpt.SummaryInfo.ReportTitle
            'frm.CRViewer.ReportSource = Rpt
            frm.CRViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            frm.Show()
        Catch ex As Exception
            HandleError(Me.Name, "btnImprimir", ex)
        Finally
            oReporte = Nothing
        End Try
    End Sub

    Private Sub btnDiaAnterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDiaAnterior.Click
        Me.NavegadorDias("Anterior")
    End Sub

    Private Sub btnDiaSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDiaSiguiente.Click
        Me.NavegadorDias("Siguiente")
    End Sub
#End Region

#Region "Eventos de objetos"
#Region "Eventos"

    Private Sub Frm_Embarques_CapturaCajasProducidas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.DesplegarCultivos()
        Me.DesplegarLotes()
        Me.DesplegarEmpaques()
        Me.DesplegarCultivosRpt()
        Me.DesplegarLotesRpt()
        Me.DesplegarCentroCosto()
        Me.Inicializa()

        Dim sql As Class_find
        sql = New Class_find("SELECT FECHA_INICIO FROM CON_EJERCICIOS WHERE ID_CON_EJERCICIO=" & Plaza.ID_CON_EJERCICIO)
        Me.dtDesde.Value = CDate(sql.Result1.ToString)
    End Sub

    Private Sub CboLote_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CboLote.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.Send("{TAB}")
        End Select
    End Sub

    Private Sub DtpFecha_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtpFecha.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.Send("{TAB}")
        End Select
    End Sub

    Private Sub Grid_KeyPress(ByVal Sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Grid.KeyPress
        'txtSoloNumerosEnteros(e)
        txtNoBeep(e)
    End Sub

    Private Sub Grid_KeyDown(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Grid.KeyDown
        Me.GestionaGrid(e)
    End Sub

    Private Sub DtpFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtpFecha.ValueChanged
        If Me.DtpFecha.Value > Now Then
            Me.DtpFecha.Value = Now
        Else
            Me.Consultar()
        End If
    End Sub
#End Region

#Region "Eventos Genericos"
    Private Sub txtTextoKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        txtNoBeep(e)
    End Sub

    Private Sub txtNumerosEnterosKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        txtSoloNumerosEnteros(e)
        txtNoBeep(e)
    End Sub

    Private Sub cboCultivo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCultivo.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.Enter
                    If txtLEN(Me.cboCultivo.Text) = True And txtLEN(Me.CboLote.Text) = True Then
                        Me.Consultar()
                        Me.Grid.Cell(Me.Grid.Rows - 1, Me.igyFolio).SetFocus()

                    ElseIf txtLEN(Me.cboCultivo.Text) = False Then
                        MsgBox("Seleccione un cultivo. ", MsgBoxStyle.Exclamation, Me.Text)
                        Me.cboCultivo.Focus()
                        Exit Sub
                    ElseIf txtLEN(Me.CboLote.Text) = False Then
                        MsgBox("Seleccione un lote. ", MsgBoxStyle.Exclamation, Me.Text)
                        Me.CboLote.Focus()
                        Exit Sub
                    End If
            End Select
        Catch ex As Exception
            HandleError(Me.Name, "cboCultivo_KeyDown", ex)
        End Try
    End Sub

    Private Sub cboCultivo_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCultivo.SelectedValueChanged
        Try
            If Me.Grid.Locked = True And txtLEN(Me.cboCultivo.Text) = False And txtLEN(Me.CboLote.Text) = False Then
                Exit Sub
            Else
                If txtLEN(Me.cboEmpaque.Text) = True Then
                    If txtLEN(Me.CboCentroCosto.Text) = True Then 'If txtLEN(Me.cboCultivo.Text) = True Then
                        If txtLEN(Me.CboLote.Text) = True Then
                            Me.Grid.Locked = False
                            Me.Consultar()
                            Me.Grid.Cell(Me.Grid.Rows - 1, Me.igyFolio).SetFocus()
                        Else
                            Me.Grid.Locked = True
                            'MsgBox("Seleccione un lote. ", MsgBoxStyle.Exclamation, Me.Text)
                            Me.CboLote.Focus()
                        End If
                    Else
                        Me.Grid.Locked = True
                        'MsgBox("Seleccione un cultivo. ", MsgBoxStyle.Exclamation, Me.Text)
                        Me.CboCentroCosto.Focus() 'Me.cboCultivo.Focus()
                    End If
                End If
            End If
        Catch ex As Exception
            HandleError(Me.Name, "cboCultivo_SelectedValueChanged", ex)
        End Try
    End Sub

    Private Sub CboLote_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboLote.SelectedValueChanged
        Try
            If Me.Grid.Locked = True Then
                Exit Sub
            Else
                If txtLEN(Me.cboEmpaque.Text) = True Then
                    If txtLEN(Me.CboLote.Text) = True Then
                        If txtLEN(Me.CboCentroCosto.Text) = True Then 'If txtLEN(Me.cboCultivo.Text) = True Then
                            Me.Grid.Locked = False
                            Me.Consultar()
                            Me.Grid.Cell(Me.Grid.Rows - 1, Me.igyFolio).SetFocus()
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            HandleError(Me.Name, "CboLote_SelectedValueChanged", ex)
        End Try
    End Sub

    Private Sub cboEmpaque_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboEmpaque.SelectedValueChanged
        Try
            If Me.Grid.Locked = True Then
                Exit Sub
            Else
                If txtLEN(Me.cboEmpaque.Text) = True Then
                    If txtLEN(Me.CboLote.Text) = True Then
                        If txtLEN(Me.CboCentroCosto.Text) = True Then 'If txtLEN(Me.cboCultivo.Text) = True Then
                            Me.Grid.Locked = False
                            Me.Consultar()
                            Me.Grid.Cell(Me.Grid.Rows - 1, Me.igyFolio).SetFocus()
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            HandleError(Me.Name, "cboEmpaque_SelectedValueChanged", ex)
        End Try
    End Sub

    Private Sub CboCentroCosto_SelectedValueChanged(sender As Object, e As EventArgs) Handles CboCentroCosto.SelectedValueChanged
        Try
            If Me.Grid.Locked = True And txtLEN(Me.cboCultivo.Text) = False And txtLEN(Me.CboLote.Text) = False Then
                Exit Sub
            Else
                If txtLEN(Me.cboEmpaque.Text) = True Then
                    If txtLEN(Me.CboCentroCosto.Text) = True Then 'If txtLEN(Me.cboCultivo.Text) = True Then
                        If txtLEN(Me.CboLote.Text) = True Then
                            Me.Grid.Locked = False
                            Me.Consultar()
                            Me.Grid.Cell(Me.Grid.Rows - 1, Me.igyFolio).SetFocus()
                        Else
                            Me.Grid.Locked = True
                            'MsgBox("Seleccione un lote. ", MsgBoxStyle.Exclamation, Me.Text)
                            Me.CboLote.Focus()
                        End If
                    Else
                        Me.Grid.Locked = True
                        'MsgBox("Seleccione un cultivo. ", MsgBoxStyle.Exclamation, Me.Text)
                        Me.CboCentroCosto.Focus()
                    End If
                End If
            End If
        Catch ex As Exception
            HandleError(Me.Name, "CboCentroCosto_SelectedValueChanged", ex)
        End Try
    End Sub

    Private Sub txtKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DtpFecha.KeyPress, cboCultivo.KeyPress, CboLote.KeyPress
        txtNoBeep(e)
    End Sub
#End Region
#End Region

#Region "Métodos y procedimientos"
    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub Inicializa()
        Try
            Me.DtpFecha.Value = Now
            ' Me.dtDesde.Value = "" 'Empresa_Sistema
            Me.dtHasta.Value = Now
            Me.InicializaGrid()
            Me.Grid.Locked = True
            Me.CboLote.SelectedIndex = -1
            Me.cboCultivo.SelectedIndex = -1
            Me.CboCentroCosto.SelectedIndex = -1
            Me.txtTotalCajas.Text = ""
            Me.txtTotalFleteAcarreo.Text = ""
            Me.txtTotalFleteEntrega.Text = ""

        Catch ex As Exception
            HandleError(Me.Name, "Inicializa", ex)
        End Try
    End Sub

    Private Sub InicializaGrid()
        Me.Grid.DataSource = Nothing
        FG_Grid_Limpiar(Me.Grid)

        Me.Grid.Rows = 2
        Me.Grid.Cols = 17

        Me.FormateaGrid()
    End Sub

    Private Sub FormateaGrid()
        Try
            Me.Grid.Column(Me.igyID).Width = 100
            Me.Grid.Column(Me.igyFolio).Width = 70
            Me.Grid.Column(Me.igyCodigoCultivo).Width = 70
            Me.Grid.Column(Me.igyCodigoLote).Width = 70
            Me.Grid.Column(Me.igyFecha).Width = 70
            Me.Grid.Column(Me.igyNumCajas).Width = 70
            Me.Grid.Column(Me.igyNumMalla).Width = 70
            Me.Grid.Column(Me.igyNumRaca).Width = 70
            Me.Grid.Column(Me.igyNumBin).Width = 70
            Me.Grid.Column(Me.igyPeso).Width = 70
            Me.Grid.Column(Me.igyOperador).Width = 120
            Me.Grid.Column(Me.igyUnidad).Width = 70
            Me.Grid.Column(Me.igyPlacas).Width = 70
            Me.Grid.Column(Me.igyHoraSalida).Width = 120
            Me.Grid.Column(Me.igyFleteAcarreo).Width = 70
            Me.Grid.Column(Me.igyFleteEntrega).Width = 70

            Me.Grid.Cell(0, Me.igyID).Text = "Código"
            Me.Grid.Cell(0, Me.igyFolio).Text = "Folio"
            Me.Grid.Cell(0, Me.igyFecha).Text = "Fecha"
            Me.Grid.Cell(0, Me.igyCodigoLote).Text = "Codigo_lote"
            Me.Grid.Cell(0, Me.igyCodigoCultivo).Text = "Codigo_cultivo"
            Me.Grid.Cell(0, Me.igyNumMalla).Text = "#Malla"
            Me.Grid.Cell(0, Me.igyNumRaca).Text = "#Raca"
            Me.Grid.Cell(0, Me.igyNumBin).Text = "#Bin"
            Me.Grid.Cell(0, Me.igyNumCajas).Text = "Total Cajas"
            Me.Grid.Cell(0, Me.igyPeso).Text = "Peso b."
            Me.Grid.Cell(0, Me.igyOperador).Text = "Operador"
            Me.Grid.Cell(0, Me.igyUnidad).Text = "Unidad"
            Me.Grid.Cell(0, Me.igyPlacas).Text = "Placas"
            Me.Grid.Cell(0, Me.igyHoraSalida).Text = "Hora salida(24h)"
            Me.Grid.Cell(0, Me.igyFleteAcarreo).Text = "Flete acarreo"
            Me.Grid.Cell(0, Me.igyFleteEntrega).Text = "FleteEntrega"

            Me.Grid.Column(Me.igyNumMalla).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.igyNumMalla).DecimalLength = 0 'Empresa_Sistema.DECIMALES_CONTABILIDAD
            Me.Grid.Column(Me.igyNumMalla).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.igyNumCajas).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.igyNumCajas).DecimalLength = Empresa_Sistema.DECIMALES_PESO_BULTOS
            Me.Grid.Column(Me.igyNumCajas).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.igyPeso).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.igyPeso).DecimalLength = 2
            Me.Grid.Column(Me.igyPeso).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.igyHoraSalida).CellType = FlexCell.CellTypeEnum.Time
            'Me.Grid.Column(Me.igyFecha).FormatString = ("dd/MMM/yy")
            Me.Grid.Column(Me.igyFecha).FormatString = ("hh:mm tt")

            Me.Grid.Column(Me.igyFleteAcarreo).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.igyFleteAcarreo).DecimalLength = 2
            Me.Grid.Column(Me.igyFleteAcarreo).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.igyFleteEntrega).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.igyFleteEntrega).DecimalLength = 2
            Me.Grid.Column(Me.igyFleteEntrega).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.igyID).Visible = False
            Me.Grid.Column(Me.igyFolio).Locked = False
            Me.Grid.Column(Me.igyFecha).Visible = False
            Me.Grid.Column(Me.igyCodigoLote).Visible = False
            Me.Grid.Column(Me.igyCodigoCultivo).Visible = False
            Me.Grid.Column(Me.igyNumMalla).Locked = False
            Me.Grid.Column(Me.igyNumRaca).Locked = False
            Me.Grid.Column(Me.igyNumBin).Locked = False
            Me.Grid.Column(Me.igyNumCajas).Locked = False
            Me.Grid.Column(Me.igyPeso).Locked = False
            Me.Grid.Column(Me.igyOperador).Locked = False
            Me.Grid.Column(Me.igyUnidad).Locked = False
            Me.Grid.Column(Me.igyPlacas).Locked = False
            Me.Grid.Column(Me.igyHoraSalida).Locked = False
            Me.Grid.Column(Me.igyFleteAcarreo).Locked = False
            Me.Grid.Column(Me.igyFleteEntrega).Locked = False

        Catch ex As Exception
            HandleError(Me.Name, "FormateaGrid", ex)
        End Try
    End Sub

    Private Function Grabar(ByVal iRenglon As Integer) As Boolean
        Dim i As Integer = iRenglon
        Dim oProduccionCajas As New Class_Embarques_CajasProducidas

        If Me.Validar() = False Then
            Exit Function
        End If

        Try
            With oProduccionCajas
                If txtLEN(Me.Grid.Cell(i, Me.igyID).Text) = True Then
                    .ID_PRODUCCION = CInt(Me.Grid.Cell(i, Me.igyID).Text)
                End If

                .FOLIO_PRODUCCION = Me.Grid.Cell(i, Me.igyFolio).Text.ToUpper
                .FECHA = Me.DtpFecha.Value
                .CODIGO_LOTE = Me.CboLote.SelectedValue.ToString
                '.CODIGO_CULTIVO = Me.cboCultivo.SelectedValue.ToString
                .NUMERO_MALLA = Me.Grid.Cell(i, Me.igyNumMalla).Text.ToUpper
                .NUMERO_RACA = Me.Grid.Cell(i, Me.igyNumRaca).Text.ToUpper
                .NUMERO_BIN = Me.Grid.Cell(i, Me.igyNumBin).Text.ToUpper
                .NUMERO_CAJAS = CInt(Me.Grid.Cell(i, Me.igyNumCajas).Text)
                .PESO_BALDE = CInt(Me.Grid.Cell(i, Me.igyPeso).Text)
                .OPERADOR = Me.Grid.Cell(i, Me.igyOperador).Text.ToUpper
                .UNIDAD = Me.Grid.Cell(i, Me.igyUnidad).Text.ToUpper
                .PLACAS = Me.Grid.Cell(i, Me.igyPlacas).Text.ToUpper
                If txtLEN(Me.Grid.Cell(i, Me.igyHoraSalida).Text) = False Then
                    .HORA_SALIDA = Me.DtpFecha.Value
                Else
                    .HORA_SALIDA = CDate(Format(Me.DtpFecha.Value, "dd-MM-yyyy").ToString + " " + Me.Grid.Cell(i, Me.igyHoraSalida).Text)
                End If
                .CODIGO_EMPAQUE = Me.cboEmpaque.SelectedValue.ToString
                .FLETE_ACARREO = CInt(valorNumerico(Me.Grid.Cell(i, Me.igyFleteAcarreo).Text))
                .FLETE_ENTREGA = CInt(valorNumerico(Me.Grid.Cell(i, Me.igyFleteEntrega).Text))
                .CODIGO_CENTRO_COSTO = Me.CboCentroCosto.SelectedValue.ToString

                If txtLEN(Me.Grid.Cell(i, Me.igyID).Text) = False Then
                    'Dim oProCajas As New Class_Embarques_CajasProducidas(Me.Grid.Cell(i, Me.igyFolio).Text.ToUpper)
                    'If oProCajas.Existe = False Then
                    If .GrabarProduccion(True) = False Then
                        MsgBox("Error al tratar de insertar las cajas producidas.", MsgBoxStyle.Exclamation, Me.Text)

                        Me.Grid.Cell(i, Me.igyID).Text = ""
                        Me.Grid.Cell(i, Me.igyFolio).Text = ""
                        Me.Grid.Cell(i, Me.igyFecha).Text = ""
                        Me.Grid.Cell(i, Me.igyCodigoLote).Text = ""
                        Me.Grid.Cell(i, Me.igyCodigoCultivo).Text = ""
                        Me.Grid.Cell(i, Me.igyNumMalla).Text = ""
                        Me.Grid.Cell(i, Me.igyNumRaca).Text = ""
                        Me.Grid.Cell(i, Me.igyNumBin).Text = ""
                        Me.Grid.Cell(i, Me.igyPeso).Text = ""
                        Me.Grid.Cell(i, Me.igyNumCajas).Text = ""
                        Me.Grid.Cell(i, Me.igyOperador).Text = ""
                        Me.Grid.Cell(i, Me.igyUnidad).Text = ""
                        Me.Grid.Cell(i, Me.igyPlacas).Text = ""
                        Me.Grid.Cell(i, Me.igyHoraSalida).Text = ""
                        Me.Grid.Cell(i, Me.igyFleteAcarreo).Text = ""
                        Me.Grid.Cell(i, Me.igyFleteEntrega).Text = ""

                        Exit Function
                        '    End If
                        'Else
                        '    MsgBox("Error al tratar de insertar las cajas producidas.", MsgBoxStyle.Exclamation, Me.Text)
                        '    Exit Function
                    End If
                Else
                    If .GrabarProduccion(False) = False Then
                        Me.Consultar()
                        MsgBox("Error al tratar de actualizar las cajas producidas.", MsgBoxStyle.Exclamation, Me.Text)
                        Exit Function
                    End If
                End If

                Me.Grid.Cell(i, Me.igyID).Text = .ID_PRODUCCION.ToString
                Grabar = True
            End With

        Catch ex As Exception
            HandleError(Me.Name, "Grabar", ex)
        End Try
    End Function

    Private Function Consultar() As Boolean
        Dim bResultado As Boolean = False
        Dim dTabla As DataTable
        'Me.Inicializa()
        Dim oProduccionCajas As New Class_Embarques_CajasProducidas

        Try

            If Me.Validar(False) = False Then
                Exit Function
            End If

            oProduccionCajas = New Class_Embarques_CajasProducidas

            'dTabla = oProduccionCajas.ObtenerDetalle(Me.DtpFecha.Value, Me.CboLote.SelectedValue.ToString, Me.cboCultivo.SelectedValue.ToString, Me.cboEmpaque.SelectedValue.ToString)
            dTabla = oProduccionCajas.ObtenerDetalle(Me.DtpFecha.Value, Me.CboLote.SelectedValue.ToString, Me.CboCentroCosto.SelectedValue.ToString, Me.cboEmpaque.SelectedValue.ToString)
            Me.Grid.Rows = 1
            For Each dRow As DataRow In dTabla.Rows
                Me.Grid.AddItem(dRow(0).ToString & Chr(9) & dRow(1).ToString & Chr(9) & dRow(2).ToString & Chr(9) & dRow(3).ToString & Chr(9) & dRow(4).ToString & Chr(9) & _
                                dRow(5).ToString & Chr(9) & dRow(6).ToString & Chr(9) & dRow(7).ToString & Chr(9) & dRow(8).ToString & Chr(9) & dRow(9).ToString & Chr(9) & _
                                dRow(10).ToString & Chr(9) & dRow(11).ToString & Chr(9) & dRow(12).ToString & Chr(9) & Format(CDate(dRow(13).ToString), "hh:mm tt") & Chr(9) & _
                                 dRow(15).ToString & Chr(9) & dRow(16).ToString)
            Next

            Me.Grid.Rows = Me.Grid.Rows + 1

            dTabla.Dispose()
            Me.FormateaGrid()
            Me.Totales()

            bResultado = True

            'If Format(Me.DtpFecha.Value, Me.DtpFecha.Value.Year & "-" & Me.DtpFecha.Value.Month & "-" & Me.DtpFecha.Value.Day) <> Format(Now, Now.Year & "-" & Now.Month & "-" & Now.Day) Then
            '    Me.Grid.Locked = True
            'Else
            '    Me.Grid.Locked = False
            'End If
        Catch ex As Exception
            HandleError(Me.Name, "Consultar", ex)
        End Try

        Return bResultado
    End Function

    Private Function Validar(Optional ByVal bConfirmacion As Boolean = True) As Boolean
        Try
            If Plaza.ValidarPeriodoTrabajo(Me.DtpFecha.Value) = False Then
                Exit Function
            End If

            'Valia que se selecciono un lote o cualtivo
            If txtLEN(Me.CboLote.Text) = False Then
                If bConfirmacion = True Then
                    MsgBox("Seleccione un lote.", MsgBoxStyle.Exclamation, "Validar")
                End If
                Me.CboLote.Focus()
                Exit Function
            End If

            'If txtLEN(Me.cboCultivo.Text) = False Then
            '    If bConfirmacion = True Then
            '        MsgBox("Seleccione un cultivo.", MsgBoxStyle.Exclamation, "Validar")
            '    End If
            '    Me.cboCultivo.Focus()
            '    Exit Function
            'End If

            If txtLEN(Me.CboCentroCosto.Text) = False Then
                If bConfirmacion = True Then
                    MsgBox("Seleccione un centro de costo.", MsgBoxStyle.Exclamation, "Validar")
                End If
                Me.CboCentroCosto.Focus()
                Exit Function
            End If

            Return True
        Catch ex As Exception
            HandleError(Me.Name, "Validar", ex)
        End Try
    End Function

    Private Sub DesplegarEmpaques()
        Try
            Dim oElementos As New Class_CatEmpaques
            With Me.cboEmpaque
                .DisplayMember = "NOMBRE_EMPAQUE"
                .ValueMember = "CODIGO_EMPAQUE"
                Dim dView As New Data.DataView(oElementos.ObtenerElementos())
                dView.Sort = "NOMBRE_EMPAQUE DESC"
                .DataSource = dView
                If dView.Count > 0 Then
                    .Text = "EMPAQUE CUBA"
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarEmpaques", ex)
        End Try
    End Sub

    Private Sub DesplegarLotes()
        Try
            Dim oElementos As New Class_CatLotes
            With Me.CboLote
                .DisplayMember = "NOMBRE_LOTE"
                .ValueMember = "CODIGO_LOTE"
                Dim dView As New Data.DataView(oElementos.ObtenerElementosActivos())
                dView.Sort = "NOMBRE_LOTE DESC"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedIndex = -1
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarLotes", ex)
        End Try
    End Sub

    Private Sub DesplegarCultivos()
        Try
            Dim oElementos As New Class_CatCultivos
            With Me.cboCultivo
                .DisplayMember = "NOMBRE_CULTIVO"
                .ValueMember = "CODIGO_CULTIVO"
                Dim dView As New Data.DataView(oElementos.ObtenerElementos)
                dView.Sort = "NOMBRE_CULTIVO"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedIndex = -1
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarCultivos", ex)
        End Try
    End Sub

    Private Sub DesplegarCultivosRpt()
        Try
            Dim oElementos As New Class_CatCultivos
            With Me.CboCultivoRpt
                .DisplayMember = "NOMBRE_CULTIVO"
                .ValueMember = "CODIGO_CULTIVO"
                Dim dView As New Data.DataView(oElementos.ObtenerElementosParaReportes)
                dView.Sort = "NOMBRE_CULTIVO"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedValue = ""
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarCultivosRpt", ex)
        End Try
    End Sub

    Private Sub DesplegarLotesRpt()
        Try
            Dim oElementos As New Class_CatLotes
            With Me.cboLoteRpt
                .DisplayMember = "NOMBRE_LOTE"
                .ValueMember = "CODIGO_LOTE"
                Dim dView As New Data.DataView(oElementos.ObtenerElementosActivos())
                dView.Sort = "NOMBRE_LOTE DESC"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedValue = ""
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarLotesRpt", ex)
        End Try
    End Sub

    Private Sub DesplegarCentroCosto()
        Try
            Dim oElementos As New Class_CatCentroCostos
            With Me.CboCentroCosto
                .DisplayMember = "NOMBRE_CENTRO_COSTO"
                .ValueMember = "CODIGO_CENTRO_COSTO"
                Dim dView As New Data.DataView(oElementos.ObtenerElementosParaReportesActivos())
                dView.Sort = "NOMBRE_CENTRO_COSTO"
                .DataSource = dView
                If dView.Count > 0 Then
                    '.SelectedIndex = -1
                    .SelectedValue = -1
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarCentrosCostos", ex)
        End Try
    End Sub

    Private Sub Totales()
        Me.txtTotalCajas.Text = FormatNumber(FG_Grid_SumaCol(Me.Grid, Me.igyNumCajas).ToString, 0)
        Me.txtTotalFleteAcarreo.Text = FormatImporteContable(FG_Grid_SumaCol(Me.Grid, Me.igyFleteAcarreo))
        Me.txtTotalFleteEntrega.Text = FormatImporteContable(FG_Grid_SumaCol(Me.Grid, Me.igyFleteEntrega))
    End Sub

    Private Sub GestionaGrid(ByVal e As System.Windows.Forms.KeyEventArgs)
        Dim Columna As Integer, Renglon As Integer
        Dim StrCod As String ', dCantidad As Double, dPesoUnidadBulto As Double, dPrecioUnidadBulto As Double, dImporteBultos As Double
        Dim oArticulos As Class_CatArticulos

        Columna = Me.Grid.Selection.FirstCol
        Renglon = Me.Grid.Selection.FirstRow
        StrCod = Me.Grid.Cell(Renglon, Me.igyID).Text

        'If Me.Grid.Column(Columna).Locked = True Then
        '    If Columna = Me.igyNumCajas Then
        '        If Me.Grid.Rows = Renglon + 1 Then
        '            Me.Grid.Rows = Me.Grid.Rows + 1
        '        End If
        '    End If
        'End If

        Select Case e.KeyCode
            Case Keys.Enter
                Select Case Columna

                    Case Me.igyID
                        If txtLEN(StrCod) = False Then
                            GoTo BuscaArticulos
                            Exit Sub
                        End If
LlenaLinea:
                        oArticulos = New Class_CatArticulos(StrCod)
                        If oArticulos.Existe = False Then
                            Me.Grid.Cell(Renglon, Me.igyID).Text = ""
                            GoTo BuscaArticulos
                            Exit Sub
                        End If

                        Me.Totales()

                    Case Me.igyCodigoCultivo

                    Case Me.igyCodigoLote

                    Case Me.igyFecha
                        Me.Grid.Cell(Renglon, Me.igyFecha).Text = Format(Me.DtpFecha.Value, "dd-MMM-yyyy").ToString
                        Me.Grid.Cell(Renglon, Me.igyCodigoLote).Text = Me.CboLote.SelectedValue.ToString
                        Me.Grid.Cell(Renglon, Me.igyCodigoCultivo).Text = Me.cboCultivo.SelectedValue.ToString

                    Case Me.igyFolio
                        If txtLEN(Me.Grid.Cell(Renglon, Me.igyFolio).Text) = True Then
                            Me.Grid.Cell(Renglon, Me.igyFecha).Text = Format(Me.DtpFecha.Value, "dd-MMM-yyyy").ToString
                            If txtLEN(Me.Grid.Cell(Renglon, Me.igyHoraSalida).Text) = False Then
                                Me.Grid.Cell(Renglon, Me.igyHoraSalida).Text = Format(CDate(Me.DtpFecha.Value.Year & "-" & Me.DtpFecha.Value.Month & "-" & Me.DtpFecha.Value.Day & " 00:00:00"), "hh:mm tt")

                                Me.Grid.Cell(Renglon, Me.igyPeso).Text = "0"
                                'Dim sql As New Class_find("SELECT PESO from CAT_PESOS_CORTE WHERE CODIGO_CULTIVO='" & Me.cboCultivo.SelectedValue.ToString & "'")
                                'If txtLEN(sql.Result1) = False Then
                                '    Me.Grid.Cell(Renglon, Me.igyPeso).Text = "0"
                                'Else
                                '    Me.Grid.Cell(Renglon, Me.igyPeso).Text = sql.Result1.ToString
                                'End If
                            End If
                        Else
                            MsgBox("Asigne el folio de producción de cajas.", MsgBoxStyle.Exclamation, Me.Text)
                            Me.Grid.Cell(Renglon, Me.igyID).SetFocus()
                            Exit Sub
                        End If

                    Case Me.igyNumMalla

                    Case Me.igyNumCajas
                        ' If valorNumerico(Me.Grid.Cell(Renglon, Me.igyNumCajas).Text) > 0 Then
                        If Me.Grabar(Renglon) = True Then
                            If Me.Grid.Rows = Renglon + 1 Then
                                Me.Grid.Rows = Me.Grid.Rows + 1
                            End If
                        End If
                        'End If

                    Case Me.igyPeso
                        If Me.Grabar(Renglon) = True Then

                        End If

                    Case Me.igyOperador
                        If Me.Grabar(Renglon) = True Then

                        End If

                    Case Me.igyUnidad
                        If Me.Grabar(Renglon) = True Then

                        End If

                    Case Me.igyPlacas
                        If Me.Grabar(Renglon) = True Then

                        End If

                    Case Me.igyHoraSalida
                        'If txtLEN(Me.Grid.Cell(Renglon, Me.igyHoraSalida).Text) Then
                        If Me.Grabar(Renglon) = True Then
                            Me.Grid.Cell(Renglon, Me.igyHoraSalida).Text = Format(CDate(Me.Grid.Cell(Renglon, Me.igyHoraSalida).Text), "hh:mm tt")
                        End If

                    Case Me.igyFleteAcarreo
                        If Me.Grabar(Renglon) = True Then

                        End If

                    Case Me.igyFleteEntrega
                        If Me.Grabar(Renglon) = True Then

                        End If

                End Select

                Me.Totales()

            Case Keys.F6
BuscaArticulos:
                If Columna = Me.igyID Then 'Columna del Codigo de Articulo
                    oArticulos = New Class_CatArticulos
                    StrCod = oArticulos.BusquedaVisualProductosAgricolas_PorDescripcion()
                    If txtLEN(StrCod) = True Then
                        Me.Grid.Cell(Renglon, Me.igyID).Text = StrCod
                        GoTo LlenaLinea

                    End If
                End If

            Case Keys.F8, Keys.Delete
                Dim oCajasProducidas As New Class_Embarques_CajasProducidas
                If valorNumerico(Me.Grid.Cell(Renglon, Me.igyID).Text) > 0 Then
                    oCajasProducidas = New Class_Embarques_CajasProducidas(CInt(Me.Grid.Cell(Renglon, Me.igyID).Text))
                    If oCajasProducidas.Existe = True Then
                        If MsgBox("Deseas eliminar el " & Me.cboCultivo.Text & " con el folio : " & Me.Grid.Cell(Renglon, Me.igyFolio).Text & " ?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "Eliminar") = MsgBoxResult.No Then
                            e.SuppressKeyPress = True
                            Exit Sub
                        End If

                        If oCajasProducidas.EliminaProduccion(CInt(Me.Grid.Cell(Renglon, Me.igyID).Text)) = True Then
                            If Me.Grid.Rows > 2 Then
                                Me.Grid.Selection.DeleteByRow()
                                e.SuppressKeyPress = True
                                Exit Sub
                            End If
                        Else
                            e.SuppressKeyPress = True
                            Exit Sub
                            'Me.Grid.Cell(Renglon, Me.igyID).Text = ""
                            'Me.Grid.Cell(Renglon, Me.igyFolio).Text = ""
                            'Me.Grid.Cell(Renglon, Me.igyFecha).Text = ""
                            'Me.Grid.Cell(Renglon, Me.igyCodigoLote).Text = ""
                            'Me.Grid.Cell(Renglon, Me.igyCodigoCultivo).Text = ""
                            'Me.Grid.Cell(Renglon, Me.igyNumMalla).Text = ""
                            'Me.Grid.Cell(Renglon, Me.igyNumCajas).Text = ""
                            'Me.Grid.Cell(Renglon, Me.igyOperador).Text = ""
                            'Me.Grid.Cell(Renglon, Me.igyUnidad).Text = ""
                            'Me.Grid.Cell(Renglon, Me.igyPlacas).Text = ""
                            'Me.Grid.Cell(Renglon, Me.igyHoraSalida).Text = ""
                        End If
                    End If
                Else
                    Me.Grid.Cell(Renglon, Me.igyID).Text = ""
                    Me.Grid.Cell(Renglon, Me.igyFolio).Text = ""
                    Me.Grid.Cell(Renglon, Me.igyFecha).Text = ""
                    Me.Grid.Cell(Renglon, Me.igyCodigoLote).Text = ""
                    Me.Grid.Cell(Renglon, Me.igyCodigoCultivo).Text = ""
                    Me.Grid.Cell(Renglon, Me.igyNumMalla).Text = ""
                    Me.Grid.Cell(Renglon, Me.igyNumRaca).Text = ""
                    Me.Grid.Cell(Renglon, Me.igyNumBin).Text = ""
                    Me.Grid.Cell(Renglon, Me.igyNumCajas).Text = ""
                    Me.Grid.Cell(Renglon, Me.igyPeso).Text = ""
                    Me.Grid.Cell(Renglon, Me.igyOperador).Text = ""
                    Me.Grid.Cell(Renglon, Me.igyUnidad).Text = ""
                    Me.Grid.Cell(Renglon, Me.igyPlacas).Text = ""
                    Me.Grid.Cell(Renglon, Me.igyHoraSalida).Text = ""
                    Me.Grid.Cell(Renglon, Me.igyFleteAcarreo).Text = ""
                    Me.Grid.Cell(Renglon, Me.igyFleteEntrega).Text = ""
                End If
                Me.Totales()

        End Select
    End Sub

    Private Sub NavegadorDias(ByVal sTipoDeBusqueda As String)
        Try

            If txtLEN(Me.cboEmpaque.Text) = True Then
                If txtLEN(Me.cboCultivo.Text) = True Then
                    If txtLEN(Me.CboLote.Text) = True Then
                        Me.Grid.Locked = False

                        If sTipoDeBusqueda = "Anterior" Then
                            Me.DtpFecha.Value = Me.DtpFecha.Value.AddDays(-1)
                        Else
                            Me.DtpFecha.Value = Me.DtpFecha.Value.AddDays(1)
                        End If

                        Me.Consultar()
                        Me.Grid.Cell(Me.Grid.Rows - 1, Me.igyFolio).SetFocus()
                    Else
                        Me.Grid.Locked = True
                        MsgBox("Seleccione un lote. ", MsgBoxStyle.Exclamation, Me.Text)
                        Me.CboLote.Focus()
                        Exit Sub
                    End If
                Else
                    Me.Grid.Locked = True
                    MsgBox("Seleccione un cultivo. ", MsgBoxStyle.Exclamation, Me.Text)
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            HandleError(Me.Name, "NavegadorDias", ex)
        End Try
    End Sub
#End Region


End Class