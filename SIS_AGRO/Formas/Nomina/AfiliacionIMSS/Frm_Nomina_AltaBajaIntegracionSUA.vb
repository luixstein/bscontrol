Option Strict On
Option Explicit On

Imports System.IO
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
Imports System.Data.OleDb

Public Class Frm_Nomina_AltaBajaIntegracionSUA
    'Dim conexionMDB As New OleDbConnection(Empresa_Sistema.oSisEmpresaNomina.CONEXION_SUA_EVENTUALES)

    Dim oSUA As New Class_Nomina_SUA
    Dim oTrabajadores As New Class_CatTrabajadores
    Dim oTemporada As New Class_NominaTemporada

    Private igyCodigoTrabajador As Short = 1
    Private igyNombreTrabajador As Short = 2
    Private igyCURP As Short = 3
    Private igyUnidadMedicaFamiliar As Short = 4
    Private igyNumRegistroIMSS As Short = 5
    Private igyUltimaFechaAlta As Short = 6
    Private igyFechaAlta As Short = 7
    Private igyFechaBaja As Short = 8
    Private igyValidacionIMSS As Short = 9
    Private igyClaveValidacionesIMSS As Short = 10
    Private igyPercepciones As Short = 11
    Private igyAdicional As Short = 12
    Private igyTrabajo As Short = 13
    Private igyDiferenciaDias As Short = 14
    Private igyValidacionesControl As Short = 15
    Private igyIdMovimiento As Short = 16

    Private igyIntegracionCodigoTrabajador As Short = 1
    Private igyIntegracionNombreTrabajador As Short = 2
    Private igyIntegracionFechaAlta As Short = 3
    Private igyIntegracionNombreTxtAlta As Short = 4
    Private igyIntegracionIntegracionSuaAlta As Short = 5
    Private igyIntegracionEstatusBaja As Short = 6
    Private igyIntegracionFechaBaja As Short = 7
    Private igyIntegracionNombreTxtBaja As Short = 8
    Private igyIntegracionIntegracionSuaBaja As Short = 9
    Private igyIntegracionRechasados As Short = 10

    Dim sMovimiento As String = ""
    Dim bConsultando As Boolean

    Private Estado As enumEstados

    Private Enum enumEstados
        NUEVO
        ALTA
        BAJA
    End Enum

#Region "Opciones"

#End Region
#Region "Eventos de objetos"
#Region "Eventos"
    Private Sub Frm_Nomina_CapturaPercepciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Inicializa()
        Me.DesplegarSemanas()
        Me.DesplegarValidaciones()
        Me.DesplegarValidacionesControl()

        Me.CboSemana.SelectedValue = Plaza.oSisPlazaNomina.NOMINA_NUMERO_SEMANA_ACTUAL 'sql.Result3.ToString
        'Dim sql As New Class_find("SELECT DATEADD(DAY, (" & (CInt(Me.CboSemana.SelectedValue) - 1).ToString & "*7),FECHA1),DATEADD(DAY, (" & (CInt(Me.CboSemana.SelectedValue) - 1).ToString & "*7),FECHA1)+6 FROM NOMINA_TEMPORADAS WHERE ID_NOMINA_TEMPORADA=" & Plaza.NOMINA_ID_NOMINA_TEMPORADA_ACTIVA)
        'Me.DtpFecha1.Value = CDate(sql.Result1.ToString)
        'Me.DtpFecha2.Value = CDate(sql.Result2.ToString)

        Me.txtSueldoDiario.Text = FormatImporteContable(Plaza.oSisPlazaNomina.NOMINA_SUELDO_DIARIO, True)
        Me.tbAltaBaja.SelectedIndex = 0
    End Sub

    Private Sub DtpFechas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtpFecha1.KeyDown, DtpFecha2.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.Send("{TAB}")
        End Select
    End Sub

    Private Sub GridSemanaTrabajadores_CellChange(ByVal Sender As Object, ByVal e As FlexCell.Grid.CellChangeEventArgs) Handles GridSemanaTrabajadores.CellChange
        'e.Col
        If bConsultando = True Or e.Row = 0 Then
            Exit Sub
        End If

        Dim Columna As Integer, Renglon As Integer

        Columna = e.Col
        Renglon = e.Row

        Me.validarFechasAltaBaja(Columna, Renglon)
    End Sub

    Private Sub validarFechasAltaBaja(ByVal Columna As Integer, ByVal Renglon As Integer)

        If Columna = Me.igyFechaAlta Then
            If txtLEN(Me.GridSemanaTrabajadores.Cell(Renglon, Me.igyUltimaFechaAlta).Text) Then
                If CDate(Me.GridSemanaTrabajadores.Cell(Renglon, Me.igyFechaAlta).Text) < CDate(Me.GridSemanaTrabajadores.Cell(Renglon, Me.igyUltimaFechaAlta).Text) Then
                    MsgBox("La fecha de alta debe ser mayor o igual a la ultima fecha de alta.", MsgBoxStyle.Exclamation, "validarFechasAltaBaja")
                    Me.GridSemanaTrabajadores.Cell(Renglon, Me.igyFechaAlta).Text = Now.ToString
                    Me.GridSemanaTrabajadores.Cell(Renglon, Me.igyUltimaFechaAlta).SetFocus()
                    Exit Sub
                Else
                    If CDate(Me.GridSemanaTrabajadores.Cell(Renglon, Me.igyFechaAlta).Text) < Me.DtpFecha1.Value Then
                        MsgBox("La fecha de alta debe ser mayor o igual a la fecha de inicio de la semana.", MsgBoxStyle.Exclamation, "validarFechasAltaBaja")
                        Me.GridSemanaTrabajadores.Cell(Renglon, Me.igyFechaAlta).Text = Now.ToString
                        Me.GridSemanaTrabajadores.Cell(Renglon, Me.igyUltimaFechaAlta).SetFocus()
                        Exit Sub
                    End If
                End If
            Else
                If CDate(Me.GridSemanaTrabajadores.Cell(Renglon, Me.igyFechaAlta).Text) < Me.DtpFecha1.Value Then
                    MsgBox("La fecha de alta debe ser mayor o igual a la fecha de inicio de la semana.", MsgBoxStyle.Exclamation, "validarFechasAltaBaja")
                    'bConsultando = True
                    Me.GridSemanaTrabajadores.Cell(Renglon, Me.igyFechaAlta).Text = Now.ToString
                    Me.GridSemanaTrabajadores.Cell(Renglon, Me.igyUltimaFechaAlta).SetFocus()
                    'bConsultando = False
                    Exit Sub
                End If
            End If

        ElseIf Columna = Me.igyFechaBaja Then
            If Me.GridSemanaTrabajadores.Cell(Renglon, Me.igyFechaBaja).Text = "" Then
                Me.GridSemanaTrabajadores.Cell(Renglon, Me.igyFechaAlta).SetFocus()
                Exit Sub
            End If
            If CDate(Me.GridSemanaTrabajadores.Cell(Renglon, Me.igyFechaBaja).Text) < CDate(Me.GridSemanaTrabajadores.Cell(Renglon, Me.igyFechaAlta).Text) Then
                MsgBox("La fecha de baja debe ser mayor o igual a la de alta.", MsgBoxStyle.Exclamation, "validarFechasAltaBaja")
                Me.GridSemanaTrabajadores.Cell(Renglon, Me.igyFechaBaja).Text = Me.GridSemanaTrabajadores.Cell(Renglon, Me.igyFechaAlta).Text
                Me.GridSemanaTrabajadores.Cell(Renglon, Me.igyFechaBaja).SetFocus()
                Exit Sub
            End If
            Me.GridSemanaTrabajadores.Cell(Renglon, Me.igyDiferenciaDias).Text = DateDiff(DateInterval.Day, CDate(Me.GridSemanaTrabajadores.Cell(Renglon, Me.igyFechaAlta).Text), CDate(Me.GridSemanaTrabajadores.Cell(Renglon, Me.igyFechaBaja).Text), FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1).ToString
        End If
    End Sub

    Private Sub GridSemanaTrabajadores_Click(ByVal Sender As Object, ByVal e As System.EventArgs) Handles GridSemanaTrabajadores.Click
        Dim Columna As Integer, Renglon As Integer

        Columna = Me.GridSemanaTrabajadores.ActiveCell.Col
        Renglon = Me.GridSemanaTrabajadores.ActiveCell.Row

        If Columna = Me.igyFechaAlta Then
            If Me.GridSemanaTrabajadores.Cell(Renglon, Me.igyFechaAlta).Text = "" Then
                Me.GridSemanaTrabajadores.Cell(Renglon, Me.igyFechaAlta).SetFocus()
                Exit Sub
            End If
            If txtLEN(Me.GridSemanaTrabajadores.Cell(Renglon, Me.igyUltimaFechaAlta).Text) Then
                If CDate(Me.GridSemanaTrabajadores.Cell(Renglon, Me.igyFechaAlta).Text) < CDate(Me.GridSemanaTrabajadores.Cell(Renglon, Me.igyUltimaFechaAlta).Text) Then
                    MsgBox("La fecha de baja debe ser mayor o igual a la ultima fecha de alta.", MsgBoxStyle.Exclamation, "GeneraArchivoAltas")
                    Me.GridSemanaTrabajadores.Cell(Renglon, Me.igyFechaAlta).SetFocus()
                    Exit Sub
                End If
            End If

        ElseIf Columna = Me.igyFechaBaja Then

            If Me.GridSemanaTrabajadores.Cell(Renglon, Me.igyFechaBaja).Text = "" Then
                Me.GridSemanaTrabajadores.Cell(Renglon, Me.igyFechaAlta).SetFocus()
                Exit Sub
            End If
            If CDate(Me.GridSemanaTrabajadores.Cell(Renglon, Me.igyFechaBaja).Text) < CDate(Me.GridSemanaTrabajadores.Cell(Renglon, Me.igyFechaAlta).Text) Then
                MsgBox("La fecha de baja debe ser mayor o igual a la de alta.", MsgBoxStyle.Exclamation, "GeneraArchivoAltas")
                Me.GridSemanaTrabajadores.Cell(Renglon, Me.igyFechaBaja).SetFocus()
                Exit Sub
            End If
            Me.GridSemanaTrabajadores.Cell(Renglon, Me.igyDiferenciaDias).Text = DateDiff(DateInterval.Day, CDate(Me.GridSemanaTrabajadores.Cell(Renglon, Me.igyFechaAlta).Text), CDate(Me.GridSemanaTrabajadores.Cell(Renglon, Me.igyFechaBaja).Text), FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1).ToString

        End If
    End Sub

    Private Sub GridSemanaTrabajadores_KeyDown(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridSemanaTrabajadores.KeyDown
        Me.GestionaGrid(e)
        'Me.FormateaGrid()
    End Sub

    Private Sub btnSemanaAnterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSemanaAnterior.Click
        NavegadorSemanas("Anterior")
    End Sub

    Private Sub btnSemanaSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSemanaSiguiente.Click
        NavegadorSemanas("Siguiente")
    End Sub

    Private Sub btnConfirmar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfirmar.Click
        If MsgBox("Deseas generar el movimiento de " & sMovimiento & " de la semana " & Me.CboSemana.Text & " ?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "Confirmar") = MsgBoxResult.No Then
            Exit Sub
        End If

        'Me.Consultar()

        If Me.Validar() = False Then
            Exit Sub
        End If
        If Me.sMovimiento = "ALTA" Then
            If Me.GeneraArchivoAltas() = True Then
                Me.tbAltaBaja.SelectedIndex = 1
                Me.DesplegarArchivos()
            End If
        Else
            If Me.GeneraArchivoBajas() = True Then
                Me.tbAltaBaja.SelectedIndex = 1
                Me.DesplegarArchivos()
            End If
        End If
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If txtLEN(Me.cboTxtArchivos.Text) = True Then
            If MsgBox("Deseas eliminar el " & Me.cboTxtArchivos.Text & " ?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "Eliminar") = MsgBoxResult.No Then
                Exit Sub
            End If

            If Me.EliminaArchivo() = False Then
                Exit Sub
            Else
                Me.InicializaGridIntegracion()
                Me.cboTxtArchivos.Refresh()
                Me.cboTxtArchivos.DataSource = Nothing
                Me.tbAltaBaja.SelectedIndex = 0
                Me.DesplegarArchivos()
            End If
        Else
            MsgBox("Seleccione un archivo. ", MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If
    End Sub

    Private Sub cmbTxtArchivos_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTxtArchivos.SelectedValueChanged
        Me.ConsultarArchivo()
    End Sub

    Private Sub btnRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegresar.Click
        Me.Inicializa()
    End Sub

    Private Sub btnRegresarIntegracion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegresarIntegracion.Click
        Me.InicializaGridIntegracion()
        Me.cboTxtArchivos.Refresh()
        Me.cboTxtArchivos.DataSource = Nothing
        Me.tbAltaBaja.SelectedIndex = 0
    End Sub

    Private Sub CboSemana_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboSemana.SelectedValueChanged
        Try
            If Me.CboSemana.Text = "" Then
                Exit Sub
            End If

            Dim sql As New Class_find("SELECT DATEADD(DAY, (" & (CInt(Me.CboSemana.Text) - 1).ToString & "*7),FECHA1),DATEADD(DAY," & (CInt(Me.CboSemana.Text) - 1).ToString & "*7,FECHA1)+6 FROM NOMINA_TEMPORADAS WHERE ID_NOMINA_TEMPORADA=" & Plaza.oSisPlazaNomina.NOMINA_ID_NOMINA_TEMPORADA_ACTIVA)
            Me.DtpFecha1.Value = CDate(sql.Result1.ToString)
            Me.DtpFecha2.Value = CDate(sql.Result2.ToString)

            Me.lblModo.Text = ""
            Me.InicializaGrid()
            Me.Cambia_Estado(enumEstados.NUEVO)

            Me.DesplegarArchivos()
            'Me.Consultar()
        Catch ex As Exception
            HandleError(Me.Name, "CboSemana", ex)
        End Try
    End Sub

    Private Sub btnGenerarAltas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGenerarAltas.Click
        Me.btnConfirmar.Enabled = True
        Me.btnRegresar.Enabled = True
        Me.btnAltaAdicional.Enabled = True
        'Me.sMovimiento = "ALTA"
        'Me.lblModo.Text = Me.sMovimiento
        Me.Cambia_Estado(enumEstados.ALTA)
        'Me.btnIntegrar.Enabled = True

        Me.Consultar()
        Me.Totales()
    End Sub

    Private Sub btnGenerarBaja_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGenerarBajas.Click
        Me.btnConfirmar.Enabled = True
        Me.btnRegresar.Enabled = True
        Me.btnAltaAdicional.Enabled = True
        'Me.sMovimiento = "BAJA"
        'Me.lblModo.Text = Me.sMovimiento
        Me.Cambia_Estado(enumEstados.BAJA)
        'Me.btnIntegrar.Enabled = True
        Me.Consultar()
        Me.Totales()
    End Sub

    Private Sub CkbMarcarTodo_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CkbMarcarTodo.CheckedChanged
        Dim i As Integer, sMarcar As String = "0"

        If Me.CkbMarcarTodo.Checked = True Then
            sMarcar = "1"
        End If

        For i = 1 To Me.GridIngracion.Rows - 1
            If txtLEN(Me.GridIngracion.Cell(i, Me.igyIntegracionRechasados).Text) = True Then
                Me.GridIngracion.Cell(i, Me.igyIntegracionRechasados).Text = sMarcar
            Else
                Me.GridIngracion.Cell(i, Me.igyIntegracionRechasados).Text = sMarcar
            End If
        Next i
        Me.Totales()
    End Sub

    Private Sub btnIntegrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIntegrar.Click
        Me.GestionaIntegracion()
    End Sub
#End Region

#Region "Eventos Genericos"
    Private Sub txtTextoKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)  'txtFolioEmbarque.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub txtNumerosEnterosKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles GridSemanaTrabajadores.KeyPress
        txtSoloNumerosEnteros(e)
        txtNoBeep(e)
    End Sub

    Private Sub txtNumerosDecimalKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim txt As TextBox = CType(sender, TextBox)
        txtSoloNumerosDecimales(e, txt.Text)
        txtNoBeep(e)
    End Sub

    Private Sub Cbo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CboSemana.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.Send("{TAB}")
        End Select
    End Sub
#End Region

#Region "Keydown específicos"

    Private Sub GridSemanaTrabajadores_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridSemanaTrabajadores.DoubleClick
        Dim Columna As Integer, Renglon As Integer, vdg As String
        Dim dTabla As DataTable
       
        Columna = Me.GridSemanaTrabajadores.Selection.FirstCol
        Renglon = Me.GridSemanaTrabajadores.Selection.FirstRow

        If Me.GridSemanaTrabajadores.Selection.FirstRow <> Me.GridSemanaTrabajadores.Selection.LastRow Then
            Exit Sub
        End If

        If Columna = igyCodigoTrabajador Then
            vdg = Me.GridSemanaTrabajadores.Cell(Renglon, Me.igyCodigoTrabajador).Text
            If txtLEN(vdg) = False Then
                Exit Sub
            End If

            Dim Child As New Cat_Nomina_Trabajadores()
            Child.StartPosition = FormStartPosition.CenterScreen
            'Child.lstbElementos.SelectedValue = vdg.ToString
            'Child.tsbEditar.PerformClick()
            Child.CODIGO_TRABAJADOR = vdg.ToString
            Child.ShowDialog()
            Child.Dispose()

            Dim oNominaMovimientos As New Class_NominaMovimientoSua
            dTabla = oNominaMovimientos.ValidaInformacionIMSSTrabajador(vdg, CInt(Me.CboSemana.SelectedValue))

            For Each drow As DataRow In dTabla.Rows
                'Me.GridSemanaTrabajadores.AddItem(drow(0).ToString & Chr(9) & drow(0).ToString & Chr(9))
                Me.GridSemanaTrabajadores.Cell(Renglon, Me.igyValidacionIMSS).Text = drow(0).ToString
                Me.GridSemanaTrabajadores.Cell(Renglon, Me.igyClaveValidacionesIMSS).Text = drow(1).ToString
            Next

            Me.Totales()
        End If
    End Sub
#End Region
#End Region

#Region "Métodos y procedimientos"
    Private Sub Inicializa()
        Try
            Me.DtpFecha1.Value = Date.Now
            Me.DtpFecha2.Value = Date.Now
            Me.dtFechaActualizar.Value = CDate(Date.Now.ToShortDateString) : Me.dtFechaActualizar.Enabled = False

            Me.txtTotalImporte.Text = "0"
            Me.txtTotalJornales.Text = "0"
            'Me.CboSemana.SelectedValue = Empresa_Sistema.oSisEmpresaNomina.NOMINA_NUMERO_SEMANA_ACTUAL
            Me.CboSemana.SelectedValue = 0
            Me.lblModo.Text = ""
            Me.InicializaGrid()
            Me.InicializaGridIntegracion()
        Catch ex As Exception
            HandleError(Me.Name, "Inicializa", ex)
        End Try
    End Sub

    Private Sub InicializaGrid()
        Me.GridSemanaTrabajadores.DataSource = Nothing
        FG_Grid_Limpiar(Me.GridSemanaTrabajadores)
        Me.GridSemanaTrabajadores.Rows = 2
        Me.GridSemanaTrabajadores.Cols = 17
        Me.FormateaGrid()
    End Sub

    Private Sub InicializaGridIntegracion()
        Me.GridIngracion.DataSource = Nothing
        FG_Grid_Limpiar(Me.GridIngracion)
        Me.GridIngracion.Rows = 2
        Me.GridIngracion.Cols = 11
        Me.FormateaGridIntegracion()
    End Sub

    Private Sub FormateaGrid()
        Me.GridSemanaTrabajadores.AutoRedraw = False
        Me.GridSemanaTrabajadores.DisplayFocusRect = False
        Me.GridSemanaTrabajadores.DisplayDateTimeMask = True
        Me.GridSemanaTrabajadores.AllowUserSort = True

        Me.GridSemanaTrabajadores.Column(Me.igyCodigoTrabajador).Width = 45
        Me.GridSemanaTrabajadores.Column(Me.igyNombreTrabajador).Width = 180
        Me.GridSemanaTrabajadores.Column(Me.igyCURP).Width = 80
        Me.GridSemanaTrabajadores.Column(Me.igyUnidadMedicaFamiliar).Width = 80
        Me.GridSemanaTrabajadores.Column(Me.igyNumRegistroIMSS).Width = 80
        Me.GridSemanaTrabajadores.Column(Me.igyUltimaFechaAlta).Width = 70
        Me.GridSemanaTrabajadores.Column(Me.igyFechaAlta).Width = 90
        Me.GridSemanaTrabajadores.Column(Me.igyFechaBaja).Width = 90
        Me.GridSemanaTrabajadores.Column(Me.igyValidacionIMSS).Width = 60
        Me.GridSemanaTrabajadores.Column(Me.igyClaveValidacionesIMSS).Width = 100
        Me.GridSemanaTrabajadores.Column(Me.igyPercepciones).Width = 90
        Me.GridSemanaTrabajadores.Column(Me.igyTrabajo).Width = 70
        Me.GridSemanaTrabajadores.Column(Me.igyDiferenciaDias).Width = 65
        Me.GridSemanaTrabajadores.Column(Me.igyValidacionesControl).Width = 80
        Me.GridSemanaTrabajadores.Column(Me.igyIdMovimiento).Width = 60

        Me.GridSemanaTrabajadores.Cell(0, Me.igyCodigoTrabajador).Text = "Cod."
        Me.GridSemanaTrabajadores.Cell(0, Me.igyNombreTrabajador).Text = "Nombre trabajador"
        Me.GridSemanaTrabajadores.Cell(0, Me.igyCURP).Text = "CURP"
        Me.GridSemanaTrabajadores.Cell(0, Me.igyUnidadMedicaFamiliar).Text = "U.M.F."
        Me.GridSemanaTrabajadores.Cell(0, Me.igyNumRegistroIMSS).Text = "Num. Registro IMSS"
        Me.GridSemanaTrabajadores.Cell(0, Me.igyFechaAlta).Text = "Ultima Fecha alta"
        Me.GridSemanaTrabajadores.Cell(0, Me.igyFechaAlta).Text = "Fecha alta"
        Me.GridSemanaTrabajadores.Cell(0, Me.igyFechaBaja).Text = "Fecha baja"
        Me.GridSemanaTrabajadores.Cell(0, Me.igyValidacionIMSS).Text = "Es válido?"
        Me.GridSemanaTrabajadores.Cell(0, Me.igyClaveValidacionesIMSS).Text = "Clave validación"
        Me.GridSemanaTrabajadores.Cell(0, Me.igyPercepciones).Text = "Percepción"
        Me.GridSemanaTrabajadores.Cell(0, Me.igyAdicional).Text = "Adicional"
        Me.GridSemanaTrabajadores.Cell(0, Me.igyTrabajo).Text = "Trabajo?"
        Me.GridSemanaTrabajadores.Cell(0, Me.igyDiferenciaDias).Text = "Días"
        Me.GridSemanaTrabajadores.Cell(0, Me.igyValidacionesControl).Text = "Validaciones"
        Me.GridSemanaTrabajadores.Cell(0, Me.igyIdMovimiento).Text = "Id Movimiento"

        Me.GridSemanaTrabajadores.Column(Me.igyValidacionIMSS).CellType = FlexCell.CellTypeEnum.CheckBox

        Me.GridSemanaTrabajadores.Column(Me.igyFechaAlta).CellType = FlexCell.CellTypeEnum.Calendar
        Me.GridSemanaTrabajadores.Column(Me.igyFechaBaja).CellType = FlexCell.CellTypeEnum.Calendar

        Me.GridSemanaTrabajadores.Column(Me.igyCodigoTrabajador).Locked = True
        Me.GridSemanaTrabajadores.Column(Me.igyNombreTrabajador).Locked = True
        Me.GridSemanaTrabajadores.Column(Me.igyCURP).Visible = False
        Me.GridSemanaTrabajadores.Column(Me.igyUnidadMedicaFamiliar).Visible = False
        Me.GridSemanaTrabajadores.Column(Me.igyNumRegistroIMSS).Visible = False
        Me.GridSemanaTrabajadores.Column(Me.igyFechaAlta).Visible = True
        Me.GridSemanaTrabajadores.Column(Me.igyUltimaFechaAlta).Visible = False
        Me.GridSemanaTrabajadores.Column(Me.igyTrabajo).Locked = True
        Me.GridSemanaTrabajadores.Column(Me.igyValidacionesControl).Locked = True
        Me.GridSemanaTrabajadores.Column(Me.igyIdMovimiento).Visible = False
        Me.GridSemanaTrabajadores.Column(Me.igyIdMovimiento).Locked = True

        If Me.Estado = enumEstados.ALTA Then
            'Me.GridSemanaTrabajadores.Column(Me.igyFechaAlta).FormatString = ("dd/MMM/yy")
            Me.GridSemanaTrabajadores.Column(Me.igyFechaAlta).Locked = False
            Me.GridSemanaTrabajadores.Column(Me.igyFechaBaja).Visible = False
            Me.GridSemanaTrabajadores.Column(Me.igyDiferenciaDias).Visible = False
        Else
            Me.GridSemanaTrabajadores.Column(Me.igyFechaAlta).FormatString = ("dd/MMM/yy")
            Me.GridSemanaTrabajadores.Column(Me.igyFechaBaja).FormatString = ("dd/MMM/yy")
            Me.GridSemanaTrabajadores.Column(Me.igyFechaAlta).Locked = True
            Me.GridSemanaTrabajadores.Column(Me.igyFechaBaja).Visible = True
            Me.GridSemanaTrabajadores.Column(Me.igyDiferenciaDias).Visible = True
        End If
        Me.GridSemanaTrabajadores.Column(Me.igyValidacionIMSS).Locked = True
        Me.GridSemanaTrabajadores.Column(Me.igyClaveValidacionesIMSS).Locked = True
        Me.GridSemanaTrabajadores.Column(Me.igyPercepciones).Visible = False
        Me.GridSemanaTrabajadores.Column(Me.igyAdicional).Visible = False

        Me.GridSemanaTrabajadores.AutoRedraw = True
        Me.GridSemanaTrabajadores.Refresh()
    End Sub

    Private Sub FormateaGridIntegracion()
        Me.GridIngracion.AllowUserSort = True

        Me.GridIngracion.Column(Me.igyIntegracionCodigoTrabajador).Width = 50
        Me.GridIngracion.Column(Me.igyIntegracionNombreTrabajador).Width = 160
        Me.GridIngracion.Column(Me.igyIntegracionFechaAlta).Width = 90
        Me.GridIngracion.Column(Me.igyIntegracionNombreTxtAlta).Width = 100
        Me.GridIngracion.Column(Me.igyIntegracionIntegracionSuaAlta).Width = 60
        Me.GridIngracion.Column(Me.igyIntegracionEstatusBaja).Width = 50
        Me.GridIngracion.Column(Me.igyIntegracionFechaBaja).Width = 70
        Me.GridIngracion.Column(Me.igyIntegracionNombreTxtBaja).Width = 90
        Me.GridIngracion.Column(Me.igyIntegracionIntegracionSuaBaja).Width = 60
        Me.GridIngracion.Column(Me.igyIntegracionRechasados).Width = 70

        Me.GridIngracion.Cell(0, Me.igyIntegracionCodigoTrabajador).Text = "Cod."
        Me.GridIngracion.Cell(0, Me.igyIntegracionNombreTrabajador).Text = "Nombre trabajador"
        Me.GridIngracion.Cell(0, Me.igyIntegracionFechaAlta).Text = "Fecha alta"
        Me.GridIngracion.Cell(0, Me.igyIntegracionNombreTxtAlta).Text = "Nombre txt alta"
        Me.GridIngracion.Cell(0, Me.igyIntegracionIntegracionSuaAlta).Text = "Int. alta"
        Me.GridIngracion.Cell(0, Me.igyIntegracionEstatusBaja).Text = "Ets. baja"
        Me.GridIngracion.Cell(0, Me.igyIntegracionFechaBaja).Text = "Fecha baja"
        Me.GridIngracion.Cell(0, Me.igyIntegracionNombreTxtBaja).Text = "Nombre txt baja"
        Me.GridIngracion.Cell(0, Me.igyIntegracionIntegracionSuaBaja).Text = "Int. baja"
        Me.GridIngracion.Cell(0, Me.igyIntegracionRechasados).Text = "Rechazados"

        Me.GridIngracion.Column(Me.igyIntegracionRechasados).CellType = FlexCell.CellTypeEnum.CheckBox
        Me.GridIngracion.Column(Me.igyIntegracionIntegracionSuaAlta).CellType = FlexCell.CellTypeEnum.CheckBox
        Me.GridIngracion.Column(Me.igyIntegracionIntegracionSuaBaja).CellType = FlexCell.CellTypeEnum.CheckBox

        Me.GridIngracion.Column(Me.igyIntegracionCodigoTrabajador).Locked = True
        Me.GridIngracion.Column(Me.igyIntegracionNombreTrabajador).Locked = True
        Me.GridIngracion.Column(Me.igyIntegracionFechaAlta).Locked = True
        Me.GridIngracion.Column(Me.igyIntegracionNombreTxtAlta).Locked = True
        Me.GridIngracion.Column(Me.igyIntegracionIntegracionSuaAlta).Locked = True
        Me.GridIngracion.Column(Me.igyIntegracionEstatusBaja).Locked = True
        Me.GridIngracion.Column(Me.igyIntegracionFechaBaja).Locked = True
        Me.GridIngracion.Column(Me.igyIntegracionNombreTxtBaja).Locked = True
        Me.GridIngracion.Column(Me.igyIntegracionIntegracionSuaBaja).Locked = True
        Me.GridIngracion.Column(Me.igyIntegracionRechasados).Locked = False

        If Me.cboTxtArchivos.SelectedValue Is Nothing Then
            Exit Sub
        End If
        'Me.btnIntegrar.Enabled = True
        'Me.btnEliminar.Enabled = True
        'Me.CkbMarcarTodo.Enabled = True
        'Me.gbFecha.Enabled = True
        'Me.dtFechaActualizar.Enabled = True

        If Me.cboTxtArchivos.SelectedValue.ToString = "ALTA" Then
            Me.GridIngracion.Column(Me.igyIntegracionNombreTxtAlta).Visible = False
            Me.GridIngracion.Column(Me.igyIntegracionIntegracionSuaAlta).Visible = False
            Me.GridIngracion.Column(Me.igyIntegracionEstatusBaja).Visible = False
            Me.GridIngracion.Column(Me.igyIntegracionFechaBaja).Visible = False
            Me.GridIngracion.Column(Me.igyIntegracionNombreTxtBaja).Visible = False
            Me.GridIngracion.Column(Me.igyIntegracionIntegracionSuaBaja).Visible = False
            Dim i As Integer
            For i = 1 To Me.GridIngracion.Rows - 1
                If Me.GridIngracion.Cell(i, Me.igyIntegracionIntegracionSuaAlta).Text = "1" Then
                    Me.GridIngracion.Column(Me.igyIntegracionIntegracionSuaAlta).Visible = True
                    Me.GridIngracion.Row(i).Locked = True
                    'Me.btnIntegrar.Enabled = False
                    'Me.btnEliminar.Enabled = False
                    'Me.CkbMarcarTodo.Enabled = False
                    'Me.gbFecha.Enabled = False
                End If
            Next i
        Else
            Me.GridIngracion.Column(Me.igyIntegracionNombreTxtAlta).Visible = False
            Me.GridIngracion.Column(Me.igyIntegracionIntegracionSuaAlta).Visible = True
            Me.GridIngracion.Column(Me.igyIntegracionEstatusBaja).Visible = False
            Me.GridIngracion.Column(Me.igyIntegracionFechaBaja).Visible = True
            Me.GridIngracion.Column(Me.igyIntegracionNombreTxtBaja).Visible = False
            Me.GridIngracion.Column(Me.igyIntegracionIntegracionSuaBaja).Visible = False

            Dim i As Integer
            For i = 1 To Me.GridIngracion.Rows - 1
                If Me.GridIngracion.Cell(i, Me.igyIntegracionIntegracionSuaBaja).Text = "1" Then
                    Me.GridIngracion.Column(Me.igyIntegracionIntegracionSuaAlta).Visible = True
                    Me.GridIngracion.Row(i).Locked = True
                    'Me.btnIntegrar.Enabled = False
                    'Me.btnEliminar.Enabled = False
                    'Me.CkbMarcarTodo.Enabled = False
                End If
            Next i
        End If
    End Sub

    Private Function Consultar() As Boolean
        Dim iSemana As Integer = CInt(Me.CboSemana.SelectedValue) ', vdg As String
        Dim dTabla As DataTable
        bConsultando = True

        Try
            Dim oSUA As New Class_Nomina_SUA
            oSUA = New Class_Nomina_SUA
            If sMovimiento = "ALTA" Then
                dTabla = oSUA.ObtenerAfliacionSemanaAlta(iSemana, Me.ckbNuevos.Checked)
            Else
                dTabla = oSUA.ObtenerAfliacionSemanaBaja(iSemana, Me.ckbNuevos.Checked)
            End If

            Me.InicializaGrid()
            Me.GridSemanaTrabajadores.Rows = 1
            'igyCodigoTrabajador,igyNombreTrabajador,igyCURP,
            'igyUnidadMEdiacaFamiliar, igyNumRegistroIMSS, igyUltimaFechaAlta, igyFechaAlta, igyFechaBaja
            'igyValidacionIMSS,igyClaveValidacionesIMSS,igyPercepciones,igyAdicional,igyTrabajo,igyDiferenciaDias
            For Each dRow As DataRow In dTabla.Rows
                Me.GridSemanaTrabajadores.AddItem(dRow(0).ToString & Chr(9) & dRow(1).ToString & " " & dRow(2).ToString & " " & dRow(3).ToString & Chr(9) & dRow(4).ToString & Chr(9) & _
                                                  dRow(5).ToString & Chr(9) & dRow(6).ToString & Chr(9) & dRow(7).ToString & Chr(9) & dRow(8).ToString & Chr(9) & dRow(9).ToString & Chr(9) & _
                                                  dRow(10).ToString & Chr(9) & dRow(11).ToString & Chr(9) & dRow(13).ToString & Chr(9) & "0".ToString & Chr(9) & dRow(14).ToString & Chr(9) & _
                                                  dRow(15).ToString & Chr(9) & dRow(16).ToString & Chr(9) & dRow(17).ToString)
            Next
            dTabla.Dispose()
            'ISNULL(Convert(varchar(10),FECHA_FACTURA_PROVEEDOR, 103),'')

            Me.FormateaGrid()
            Me.Totales()

            Consultar = True
            bConsultando = False

        Catch ex As Exception
            HandleError(Me.Name, "Consultar", ex)
            bConsultando = False
        End Try
    End Function

    Private Function ConsultarArchivo() As Boolean
        Dim dTabla As DataTable
        Dim oNominaMovimientos As New Class_NominaMovimientoSua
        oNominaMovimientos.ID_NOMINA_SEMANA = CInt(Me.CboSemana.SelectedValue)
        Dim sArchivo As String = Me.cboTxtArchivos.Text
        sArchivo = sArchivo.Replace(" INTEGRADO", "")

        Try
            dTabla = oNominaMovimientos.ObtenerDetalle(sArchivo)
            Me.InicializaGridIntegracion()

            Me.GridIngracion.Rows = 1
            For Each drow As DataRow In dTabla.Rows
                Dim sFecha As String
                If drow(8).ToString Is Nothing Or drow(8).ToString = "" Then
                    sFecha = ""
                Else
                    sFecha = Format(CDate(drow(8).ToString), "dd-MMM-yy")
                End If
                Me.GridIngracion.AddItem(drow(0).ToString & Chr(9) & drow(1).ToString & " " & drow(2).ToString & " " & drow(3).ToString & Chr(9) & Format(CDate(drow(4).ToString), "dd-MMM-yy") & Chr(9) & drow(5).ToString & Chr(9) & _
                                         drow(6).ToString & Chr(9) & drow(7).ToString & Chr(9) & sFecha.ToString & Chr(9) & drow(9).ToString & Chr(9) & drow(10).ToString & Chr(9))
            Next

            Me.FormateaGridIntegracion()
            Me.Totales()
        Catch ex As Exception
            HandleError(Me.Name, "cmbTxtArchivos_SelectedValueChanged", ex)
        End Try
    End Function

    Private Sub DesplegarValidaciones()
        Try
            With Me.lstbValidaciones
                .DisplayMember = "NOMBRE_VALIDACION"
                .ValueMember = "CODIGO_VALIDACION"
                Dim dView As New Data.DataView(Me.oTemporada.ObtenerClavesValidaciones("IMSS"))
                dView.Sort = "NOMBRE_VALIDACION"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedIndex = 0
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarValidaciones", ex)
        End Try
    End Sub

    Private Sub DesplegarValidacionesControl()
        Try
            With Me.lbstValidacionesControl
                .DisplayMember = "NOMBRE_VALIDACION"
                '.ValueMember = "CODIGO_VALIDACION"
                Dim dView As New Data.DataView(Me.oTemporada.ObtenerClavesValidaciones("CONTROL"))
                dView.Sort = "NOMBRE_VALIDACION"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedIndex = 0
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarValidacionesControl", ex)
        End Try
    End Sub

    Private Sub DesplegarSemanas()
        Try
            Dim oElementos As New Class_NominaSemana
            Dim oTemperada As New Class_NominaTemporada
            oElementos = New Class_NominaSemana
            oTemperada = New Class_NominaTemporada
            oTemperada.Consultar()
            With Me.CboSemana
                .DisplayMember = "NUMERO_SEMANA"
                .ValueMember = "ID_NOMINA_SEMANA"
                Dim dView As New Data.DataView(oElementos.ObtenerElementos())
                dView.Sort = "NUMERO_SEMANA"
                .DataSource = dView
                If dView.Count > 0 Then
                    .DisplayMember = Plaza.oSisPlazaNomina.NOMINA_NUMERO_SEMANA_ACTUAL.ToString
                End If
            End With

            Me.lblTemporadaPlaza.Text = oTemperada.NOMBRE_TEMPORADA.ToString & ", " & Plaza.NOMBRE_PLAZA
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarSemanas", ex)
        End Try
    End Sub

    Private Sub DesplegarArchivos()
        Try
            Dim oNominaMovimientos As New Class_NominaMovimientoSua
            oNominaMovimientos.ID_NOMINA_SEMANA = CInt(Me.CboSemana.SelectedValue)

            Me.InicializaGridIntegracion()
            Me.cboTxtArchivos.Refresh()
            Me.cboTxtArchivos.DataSource = Nothing
            With Me.cboTxtArchivos
                .DisplayMember = "NOMBRE_TXT"
                .ValueMember = "TIPO_MOVIMIENTO"
                Dim dView As New Data.DataView(oNominaMovimientos.ObtenerElementos())
                dView.Sort = "NOMBRE_TXT"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedIndex = 0
                End If
            End With

        Catch ex As Exception
            HandleError(Me.Name, "DesplegarArchivos", ex)
        End Try
    End Sub

    Private Sub GestionaGrid(ByVal e As System.Windows.Forms.KeyEventArgs)
        Dim Columna As Integer, Renglon As Integer
        Dim StrCod As String

        Columna = Me.GridSemanaTrabajadores.Selection.FirstCol
        Renglon = Me.GridSemanaTrabajadores.Selection.FirstRow
        StrCod = Me.GridSemanaTrabajadores.Cell(Renglon, Me.igyCodigoTrabajador).Text

        Select Case e.KeyCode
            Case Keys.Enter

                'Select Case Columna
                '    'Case Me.igyFechaAlta
                '    '    If Me.GridSemanaTrabajadores.Cell(Renglon, Me.igyFechaAlta).Text = "" Then
                '    '        Me.GridSemanaTrabajadores.Cell(Renglon, Me.igyUltimaFechaAlta).SetFocus()
                '    '        Exit Sub
                '    '    End If
                '    '    If txtLEN(Me.GridSemanaTrabajadores.Cell(Renglon, Me.igyUltimaFechaAlta).Text) Then
                '    '        If CDate(Me.GridSemanaTrabajadores.Cell(Renglon, Me.igyFechaAlta).Text) < CDate(Me.GridSemanaTrabajadores.Cell(Renglon, Me.igyUltimaFechaAlta).Text) Then
                '    '            MsgBox("La fecha de baja debe ser mayor o igual a la ultima fecha de alta.", MsgBoxStyle.Exclamation, "GeneraArchivoAltas")
                '    '            Me.GridSemanaTrabajadores.Cell(Renglon, Me.igyUltimaFechaAlta).SetFocus()
                '    '            Exit Sub
                '    '        End If
                '    '    End If
                '    '    Me.GridSemanaTrabajadores.Cell(Renglon + 1, Me.igyUltimaFechaAlta).SetFocus()

                '    'Case Me.igyFechaBaja
                '    '    If Me.GridSemanaTrabajadores.Cell(Renglon, Me.igyFechaBaja).Text = "" Then
                '    '        Me.GridSemanaTrabajadores.Cell(Renglon, Me.igyFechaAlta).SetFocus()
                '    '        Exit Sub
                '    '    End If
                '    '    If CDate(Me.GridSemanaTrabajadores.Cell(Renglon, Me.igyFechaBaja).Text) < CDate(Me.GridSemanaTrabajadores.Cell(Renglon, Me.igyFechaAlta).Text) Then
                '    '        MsgBox("La fecha de baja debe ser mayor o igual a la de alta.", MsgBoxStyle.Exclamation, "GeneraArchivoAltas")
                '    '        Me.GridSemanaTrabajadores.Cell(Renglon, Me.igyFechaAlta).SetFocus()
                '    '        Exit Sub
                '    '    End If
                '    '    Me.GridSemanaTrabajadores.Cell(Renglon, Me.igyDiferenciaDias).Text = DateDiff(DateInterval.Day, CDate(Me.GridSemanaTrabajadores.Cell(Renglon, Me.igyFechaAlta).Text), CDate(Me.GridSemanaTrabajadores.Cell(Renglon, Me.igyFechaBaja).Text), FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1).ToString

                '    '    Me.GridSemanaTrabajadores.Cell(Renglon + 1, Me.igyFechaAlta).SetFocus()
                'End Select

            Case Keys.F8, Keys.Delete
                If Me.GridSemanaTrabajadores.Rows > 1 Then
                    Me.GridSemanaTrabajadores.Selection.DeleteByRow()
                    e.SuppressKeyPress = True
                End If
                Me.Totales()
        End Select
    End Sub

    Private Sub Totales()
        Dim i As Integer
        Me.txtTotalImporte.Text = "0"
        Me.txtTotalJornales.Text = "0"
        Me.txtAceptados.Text = "0"
        Me.txtRechazados.Text = "0"
        Me.txtTotalTrabajadores.Text = "0"

        For i = 1 To Me.GridSemanaTrabajadores.Rows - 1
            If txtLEN(Me.GridSemanaTrabajadores.Cell(i, Me.igyCodigoTrabajador).Text) = True Then
                If Me.GridSemanaTrabajadores.Cell(i, Me.igyValidacionIMSS).Text = "1" Then
                    Me.txtTotalImporte.Text = FormatImporteContable(valorNumerico(Me.txtTotalImporte.Text) + valorNumerico(Me.GridSemanaTrabajadores.Cell(i, Me.igyPercepciones).Text), True)
                    Me.txtTotalJornales.Text = (valorNumerico(Me.txtTotalJornales.Text) + 1).ToString
                End If
            End If
        Next i

        For i = 1 To Me.GridIngracion.Rows - 1
            If Me.GridIngracion.Cell(i, Me.igyIntegracionRechasados).Text = "0" Or Me.GridIngracion.Cell(i, Me.igyIntegracionRechasados).Text = "" Then
                Me.txtAceptados.Text = (valorNumerico(Me.txtAceptados.Text) + 1).ToString
                Me.GridIngracion.Cell(i, Me.igyIntegracionRechasados).Text = "0"
            Else
                Me.txtRechazados.Text = (valorNumerico(Me.txtRechazados.Text) + 1).ToString
            End If
        Next

        Me.txtTotalTrabajadores.Text = (Me.GridIngracion.Rows - 1).ToString
        'Me.txtTotalImporte.Text = FormatImporteContable(Redondear(FG_Grid_SumaCol(Me.GridSemanaTrabajadores, Me.igyPercepciones), Empresa_Sistema.DECIMALES_CONTABILIDAD))
        'Me.txtTotalJornales.Text = FG_Grid_SumaCol(Me.GridSemanaTrabajadores, Me.igyCodigoTrabajador).ToString
    End Sub

    Private Function NavegadorSemanas(ByVal sTipoDeBusqueda As String) As Boolean
        Try
            Dim iSemana As Integer

            If sTipoDeBusqueda = "Anterior" Then
                iSemana = CInt(Me.CboSemana.Text)
                iSemana = iSemana - 1

                If iSemana > 0 Then
                    Me.CboSemana.Text = iSemana.ToString
                    'Me.CboSemana.SelectedValue = iSemana.ToString
                End If
            Else
                If sTipoDeBusqueda = "Siguiente" Then
                    iSemana = CInt(Me.CboSemana.Text)
                    iSemana = iSemana + 1
                    oTemporada = New Class_NominaTemporada()
                    oTemporada.Consultar()
                    If iSemana <= CInt(oTemporada.NUMERO_SEMANAS.ToString) Then
                        Me.CboSemana.Text = iSemana.ToString
                        'Me.CboSemana.SelectedValue = iSemana.ToString
                    End If
                End If
            End If
            Me.Cambia_Estado(enumEstados.NUEVO)

            NavegadorSemanas = True
        Catch ex As Exception
            HandleError(Me.Name, "NavegadorSemanas", ex)
        End Try
    End Function

    Public Function GeneraArchivoAltas() As Boolean
        'Dim dTabla As DataTable
        Dim sRenglon As String = Nothing
        Dim strStreamW As Stream = Nothing
        Dim strStreamWriter As StreamWriter = Nothing
        ' Donde guardamos los paths de los archivos que vamos a estar utilizando ..
        Dim PathArchivo As String
        Dim sTotalRegingresos As String

        Try
            Me.oSUA = New Class_Nomina_SUA

            If Me.TrabajadorAdicional = False Then
                MsgBox("No se generó el trabajador adicional.", MsgBoxStyle.Exclamation, "GeneraArchivoAltas")
                Exit Function
            End If

            If Directory.Exists(Plaza.oSisPlazaNomina.NOMINA_RUTA_IDSE & "SEM" & Me.CboSemana.Text) = False Then ' si no existe la carpeta se crea
                Directory.CreateDirectory(Plaza.oSisPlazaNomina.NOMINA_RUTA_IDSE & "SEM" & Me.CboSemana.Text)
            End If

            '    'procedimiento para imprimnir
            'NúmeroArchivo = FreeFile() ' Obtiene un número de archivo que no se ha utilizado.

            Dim sql As New Class_find("SELECT ULTIMO_NUMERO_ARCHIVO_TXT_ALTAS FROM NOMINA_SEMANA WHERE ID_NOMINA_TEMPORADA=" & Plaza.oSisPlazaNomina.NOMINA_ID_NOMINA_TEMPORADA_ACTIVA & " AND NUMERO_SEMANA=" & Me.CboSemana.Text)
            Dim iFolio As Integer
            iFolio = CInt("0" & sql.Result1.ToString)
            iFolio = iFolio + 1

            PathArchivo = Plaza.oSisPlazaNomina.NOMINA_RUTA_IDSE & "SEM" & Me.CboSemana.Text & "\REING_" & iFolio.ToString & ".txt"

            If isExisteArchivo(PathArchivo) = True Then
                MsgBox("El archivo correspondiente ya existe", MsgBoxStyle.Exclamation, "GeneraArchivoAltas")
                Exit Function
            Else
                strStreamW = File.Create(PathArchivo)
            End If

            '---------------INSERTAR MOVIMIENTOS EN AGRINET----------------------------------------
            Dim i As Integer
            Dim oNominaMovimientos As New Class_NominaMovimientoSua
            oNominaMovimientos.ID_NOMINA_SEMANA = CInt(Me.CboSemana.SelectedValue)

            For i = 1 To Me.GridSemanaTrabajadores.Rows - 1
                If txtLEN(Me.GridSemanaTrabajadores.Cell(i, Me.igyCodigoTrabajador).Text) = True Then
                    If Me.GridSemanaTrabajadores.Cell(i, Me.igyValidacionIMSS).Text = "1" Then
                        If oNominaMovimientos.InsertaMovimientosImss("ALTA", Me.GridSemanaTrabajadores.Cell(i, Me.igyFechaAlta).Text, "REING_" & iFolio.ToString & ".TXT", Me.GridSemanaTrabajadores.Cell(i, Me.igyCodigoTrabajador).Text, Me.GridSemanaTrabajadores.Cell(i, Me.igyValidacionesControl).Text) = False Then
                            MsgBox("No se pudo integrar el archivo. ", MsgBoxStyle.Exclamation, Me.Text)
                            Exit Function
                        End If
                    End If
                End If
            Next i
            '--------------------------------------------------------------------------------------

            'dTabla = Me.oSUA.ObtenerAfliacionSemanaAlta(CInt(Me.CboSemana.SelectedValue), True)
            strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default) ' tipo de codificacion para escritura

            'Me.GridIngracion.Rows = 1
            'For Each drow As DataRow In dTabla.Rows
            '    Dim kt1 As String = String.Format("{0,-11}", Plaza.oSisPlazaNomina.NOMINA_NUMERO_REGISTRO_PATRONAL.ToString)
            '    Dim kt2 As String = String.Format("{0,-11}", drow(6).ToString)
            '    Dim kt3 As String = String.Format("{0,-27}", drow(1).ToString)
            '    Dim Kt4 As String = String.Format("{0,-27}", drow(2).ToString)
            '    Dim kt5 As String = String.Format("{0,-27}", drow(3).ToString)
            '    Dim kt6 As String = String.Format("{0,6}", (Plaza.oSisPlazaNomina.NOMINA_SUELDO_DIARIO * 100))
            '    kt6 = kt6.Replace(" ", "0")
            '    Dim kt7 As String = String.Format("{0,6}", "")
            '    Dim kt8 As String = String.Format("{0,1}", Plaza.oSisPlazaNomina.NOMINA_TIPO_TRABAJADOR.ToString)
            '    Dim kt9 As String = String.Format("{0,1}", Plaza.oSisPlazaNomina.NOMINA_TIPO_SALARIO.ToString)
            '    Dim kt10 As String = String.Format("{0,1}", Plaza.oSisPlazaNomina.NOMINA_REDUCCION_TIPO_PAGO.ToString)
            '    Dim kt11 As String = String.Format("{0,8}", Format(CDate(drow(7).ToString), "ddMMyyyy"))
            '    Dim kt12 As String = String.Format("{0,3}", drow(5).ToString)
            '    kt12 = kt12.Replace(" ", "0")
            '    Dim kt13 As String = String.Format("{0,2}", "")
            '    Dim kt14 As String = String.Format("{0,2}", "08")
            '    Dim kt15 As String = String.Format("{0,5}", Plaza.oSisPlazaNomina.NOMINA_GUIA.ToString)
            '    kt15 = kt15.Replace(" ", "0")
            '    Dim kt16 As String = String.Format("{0,10}", drow(0).ToString.Substring(2))
            '    kt16 = kt16.Replace(" ", "0")
            '    Dim kt17 As String = String.Format("{0,1}", "")
            '    Dim kt18 As String = String.Format("{0,18}", drow(4).ToString)
            '    Dim kt19 As String = String.Format("{0,1}", Plaza.oSisPlazaNomina.NOMINA_IDENTIFICADOR_FORMATO.ToString)

            '    strStreamWriter.WriteLine(kt1.ToString & kt2.ToString & kt3.ToString & Kt4.ToString & kt5.ToString & _
            '                              kt6.ToString & kt7.ToString & kt8.ToString & kt9.ToString & kt10.ToString & _
            '                              kt11.ToString & kt12.ToString & kt13.ToString & kt14.ToString & kt15.ToString & _
            '                              kt16.ToString & kt17.ToString & kt18.ToString & kt19.ToString)
            '    'escribimos en el archivo
            '    Me.GridIngracion.AddItem(drow(0).ToString & Chr(9) & drow(1).ToString & " " & drow(2).ToString & " " & drow(3).ToString & Chr(9) & Format(CDate(drow(7).ToString), "dd-MM-yy") & Chr(9) & drow(8).ToString & Chr(9) & _
            '                             drow(9).ToString & Chr(9) & drow(10).ToString & Chr(9) & drow(11).ToString & Chr(9) & drow(12).ToString & Chr(9) & drow(13).ToString & Chr(9))

            'Next


            For i = 1 To Me.GridSemanaTrabajadores.Rows - 1
                If txtLEN(Me.GridSemanaTrabajadores.Cell(i, Me.igyCodigoTrabajador).Text) = True Then
                    If Me.GridSemanaTrabajadores.Cell(i, Me.igyValidacionIMSS).Text = "1" And Me.GridSemanaTrabajadores.Cell(i, Me.igyValidacionesControl).Text = "" Then

                        Dim oTrabajador As New Class_CatTrabajadores
                        oTrabajador = New Class_CatTrabajadores(Me.GridSemanaTrabajadores.Cell(i, Me.igyCodigoTrabajador).Text)

                        Dim kt1 As String = String.Format("{0,-11}", Plaza.oSisPlazaNomina.NOMINA_NUMERO_REGISTRO_PATRONAL.ToString)
                        Dim kt2 As String = String.Format("{0,-11}", Me.GridSemanaTrabajadores.Cell(i, Me.igyNumRegistroIMSS).Text)
                        Dim kt3 As String = String.Format("{0,-27}", oTrabajador.APELLIDO_PATERNO)
                        Dim Kt4 As String = String.Format("{0,-27}", oTrabajador.APELLIDO_MATERNO)
                        Dim kt5 As String = String.Format("{0,-27}", oTrabajador.NOMBRE_TRABAJADOR)
                        Dim kt6 As String = String.Format("{0,6}", (Plaza.oSisPlazaNomina.NOMINA_SUELDO_DIARIO * 100))
                        kt6 = kt6.Replace(" ", "0")
                        Dim kt7 As String = String.Format("{0,6}", "")
                        Dim kt8 As String = String.Format("{0,1}", Plaza.oSisPlazaNomina.NOMINA_TIPO_TRABAJADOR.ToString)
                        Dim kt9 As String = String.Format("{0,1}", Plaza.oSisPlazaNomina.NOMINA_TIPO_SALARIO.ToString)
                        Dim kt10 As String = String.Format("{0,1}", Plaza.oSisPlazaNomina.NOMINA_REDUCCION_TIPO_PAGO.ToString)

                        Dim kt11 As String = String.Format("{0,8}", Format(CDate(Me.GridSemanaTrabajadores.Cell(i, Me.igyFechaAlta).Text), "ddMMyyyy"))
                        Dim kt12 As String = String.Format("{0,3}", Me.GridSemanaTrabajadores.Cell(i, Me.igyUnidadMedicaFamiliar).Text)
                        kt12 = kt12.Replace(" ", "0")
                        Dim kt13 As String = String.Format("{0,2}", "")
                        Dim kt14 As String = String.Format("{0,2}", "08")
                        Dim kt15 As String = String.Format("{0,5}", Plaza.oSisPlazaNomina.NOMINA_GUIA.ToString)
                        kt15 = kt15.Replace(" ", "0")
                        Dim kt16 As String = String.Format("{0,10}", Me.GridSemanaTrabajadores.Cell(i, Me.igyCodigoTrabajador).Text)
                        kt16 = kt16.Replace(" ", "0")
                        Dim kt17 As String = String.Format("{0,1}", "")
                        Dim kt18 As String = String.Format("{0,18}", Me.GridSemanaTrabajadores.Cell(i, Me.igyCURP).Text)
                        Dim kt19 As String = String.Format("{0,1}", Plaza.oSisPlazaNomina.NOMINA_IDENTIFICADOR_FORMATO.ToString)

                        strStreamWriter.WriteLine(kt1.ToString & kt2.ToString & kt3.ToString & Kt4.ToString & kt5.ToString & _
                                                  kt6.ToString & kt7.ToString & kt8.ToString & kt9.ToString & kt10.ToString & _
                                                  kt11.ToString & kt12.ToString & kt13.ToString & kt14.ToString & kt15.ToString & _
                                                  kt16.ToString & kt17.ToString & kt18.ToString & kt19.ToString)
                        'escribimos en el archivo
                        'Me.GridIngracion.AddItem(drow(0).ToString & Chr(9) & drow(1).ToString & " " & drow(2).ToString & " " & drow(3).ToString & Chr(9) & Format(CDate(drow(7).ToString), "dd-MM-yy") & Chr(9) & drow(8).ToString & Chr(9) & _
                        '                         drow(9).ToString & Chr(9) & drow(10).ToString & Chr(9) & drow(11).ToString & Chr(9) & drow(12).ToString & Chr(9) & drow(13).ToString & Chr(9))

                    End If
                End If
            Next i
            '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            sTotalRegingresos = String.Format("{0,6}", Me.txtTotalJornales.Text)
            sTotalRegingresos = sTotalRegingresos.Replace(" ", "0")

            strStreamWriter.WriteLine("*************" & String.Format("{0,43}", " ") & sTotalRegingresos & _
                          String.Format("{0,71}", " ") & _
                          Plaza.oSisPlazaNomina.NOMINA_GUIA.ToString & _
                          String.Format("{0,29}", " ") & _
                          Plaza.oSisPlazaNomina.NOMINA_IDENTIFICADOR_FORMATO.ToString)


            strStreamWriter.Close() ' cerramos

            Dim oSemana As New Class_NominaSemana
            oSemana.ID_NOMINA_SEMANA = oNominaMovimientos.ID_NOMINA_SEMANA
            oSemana.ULTIMO_NUMERO_ARCHIVO_TXT_ALTAS = iFolio.ToString
            oSemana.ActualizaUltimoNumeroTxtAltaSemana()

            GeneraArchivoAltas = True


            MsgBox("El archivo fue generado con éxito en la ruta: " & PathArchivo, MsgBoxStyle.Information, "Generar Altas")

            Exit Function
        Catch ex As Exception
            HandleError(Me.Name, "GeneraArchivoAltas", ex)
        End Try
    End Function

    Public Function GeneraArchivoBajas() As Boolean
        'Dim dTabla As DataTable
        Dim sRenglon As String = Nothing
        Dim strStreamW As Stream = Nothing
        Dim strStreamWriter As StreamWriter = Nothing
        ' Donde guardamos los paths de los archivos que vamos a estar utilizando ..
        Dim PathArchivo As String
        Dim sTotalRegingresos As String
        Dim sNombreArchivo As String

        Try
            Me.oSUA = New Class_Nomina_SUA

            If Me.TrabajadorAdicional = False Then
                MsgBox("No se generó el trabajador adicional.", MsgBoxStyle.Exclamation, "GeneraArchivoAltas")
                Exit Function
            End If

            'dTabla = Me.oSUA.ObtenerAfliacionSemanaBaja(CInt(Me.CboSemana.Text), True)

            If Directory.Exists(Plaza.oSisPlazaNomina.NOMINA_RUTA_IDSE & "SEM" & Me.CboSemana.Text) = False Then ' si no existe la carpeta se crea
                Directory.CreateDirectory(Plaza.oSisPlazaNomina.NOMINA_RUTA_IDSE & "SEM" & Me.CboSemana.Text)
            End If

            '    'procedimiento para imprimnir
            'NúmeroArchivo = FreeFile() ' Obtiene un número de archivo que no se ha utilizado.

            Dim sql As New Class_find("SELECT ULTIMO_NUMERO_ARCHIVO_TXT_BAJAS FROM NOMINA_SEMANA WHERE ID_NOMINA_TEMPORADA=" & Plaza.oSisPlazaNomina.NOMINA_ID_NOMINA_TEMPORADA_ACTIVA & " AND NUMERO_SEMANA=" & Me.CboSemana.Text)
            'Dim iFolio As Integer
            'iFolio = CInt(sql.Result1.ToString)
            'iFolio = iFolio + 1

            'PathArchivo = Plaza.oSisPlazaNomina.NOMINA_RUTA_IDSE & "SEM" & Me.CboSemana.Text & "\BAJA_" & iFolio.ToString & ".txt"
            sNombreArchivo = "BAJA_" & Format(Now, "ddMMMyy").ToUpper & "_" & Format(Now, "hhmmss") & ".txt"
            PathArchivo = Plaza.oSisPlazaNomina.NOMINA_RUTA_IDSE & "SEM" & Me.CboSemana.Text & "\" & sNombreArchivo

            If isExisteArchivo(PathArchivo) = True Then
                If MsgBox("El archivo correspondiente ya existe, desea sobreescribirlo?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "GeneraArchivoAltas") = MsgBoxResult.No Then
                    MsgBox("No se generó el archivo.", MsgBoxStyle.Exclamation, "GeneraArchivoAltas")
                    Exit Function
                End If
            Else
                strStreamW = File.Create(PathArchivo)
            End If

            'FileOpen(NúmeroArchivo, "REING_" & iFolio.ToString & ".txt", OpenMode.Output)

            'strStreamW = File.Open(PathArchivo, FileMode.Open) 'Abrimos el archivo
            strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default) ' tipo de codificacion para escritura

            '---------------INSERTAR MOVIMIENTOS EN AGRINET----------------------------------------
            Dim i As Integer
            Dim oNominaMovimientos As New Class_NominaMovimientoSua
            oNominaMovimientos.ID_NOMINA_SEMANA = CInt(Me.CboSemana.SelectedValue)

            For i = 1 To Me.GridSemanaTrabajadores.Rows - 1
                If txtLEN(Me.GridSemanaTrabajadores.Cell(i, Me.igyCodigoTrabajador).Text) = True Then
                    If Me.GridSemanaTrabajadores.Cell(i, Me.igyValidacionIMSS).Text = "1" Then
                        If oNominaMovimientos.InsertaMovimientosImss("BAJA", Me.GridSemanaTrabajadores.Cell(i, Me.igyFechaBaja).Text, sNombreArchivo, Me.GridSemanaTrabajadores.Cell(i, Me.igyCodigoTrabajador).Text, Me.GridSemanaTrabajadores.Cell(i, Me.igyIdMovimiento).Text) = False Then
                            MsgBox("No se pudo integrar el archivo. ", MsgBoxStyle.Exclamation, Me.Text)
                            Exit Function
                        End If
                    End If
                End If
            Next i
            '--------------------------------------------------------------------------------------
            '    'escribimos en el archivo
            '    Me.GridIngracion.AddItem(drow(0).ToString & Chr(9) & drow(1).ToString & " " & drow(2).ToString & " " & drow(3).ToString & Chr(9) & Format(CDate(drow(5).ToString), "dd-MM-yy") & Chr(9) & drow(6).ToString & Chr(9) & _
            '                             drow(7).ToString & Chr(9) & drow(8).ToString & Chr(9) & Format(CDate(drow(9).ToString), "dd-MM-yy") & Chr(9) & drow(10).ToString & Chr(9) & drow(11).ToString & Chr(9))
            'Next

            '------------------------------------------------
            'Dim i As Integer
            For i = 1 To Me.GridSemanaTrabajadores.Rows - 1
                If txtLEN(Me.GridSemanaTrabajadores.Cell(i, Me.igyCodigoTrabajador).Text) = True Then
                    Dim oTrabajador As New Class_CatTrabajadores
                    oTrabajador = New Class_CatTrabajadores(Me.GridSemanaTrabajadores.Cell(i, Me.igyCodigoTrabajador).Text)

                    If Me.GridSemanaTrabajadores.Cell(i, Me.igyValidacionIMSS).Text = "1" And Me.GridSemanaTrabajadores.Cell(i, Me.igyValidacionesControl).Text = "" Then
                        Dim kt1 As String = String.Format("{0,-11}", Plaza.oSisPlazaNomina.NOMINA_NUMERO_REGISTRO_PATRONAL.ToString)
                        Dim kt2 As String = String.Format("{0,-11}", Me.GridSemanaTrabajadores.Cell(i, Me.igyNumRegistroIMSS).Text)
                        Dim kt3 As String = String.Format("{0,-27}", oTrabajador.APELLIDO_PATERNO)
                        Dim Kt4 As String = String.Format("{0,-27}", oTrabajador.APELLIDO_MATERNO)
                        Dim kt5 As String = String.Format("{0,-27}", oTrabajador.NOMBRE_TRABAJADOR)
                        Dim kt6 As String = String.Format("{0,15}", "")
                        kt6 = kt6.Replace(" ", "0")
                        Dim kt7 As String = String.Format("{0,8}", Format(CDate(Me.GridSemanaTrabajadores.Cell(i, Me.igyFechaBaja).Text), "ddMMyyyy"))
                        Dim kt8 As String = String.Format("{0,5}", "")
                        Dim kt9 As String = String.Format("{0,2}", "02")
                        Dim kt10 As String = String.Format("{0,5}", Plaza.oSisPlazaNomina.NOMINA_GUIA.ToString)
                        kt10 = kt10.Replace(" ", "0")
                        Dim kt11 As String = String.Format("{0,10}", Me.GridSemanaTrabajadores.Cell(i, Me.igyCodigoTrabajador).Text)
                        kt11 = kt11.Replace(" ", "0")
                        Dim kt12 As String = String.Format("{0,1}", "2")
                        Dim kt13 As String = String.Format("{0,18}", "")
                        Dim kt14 As String = String.Format("{0,1}", Plaza.oSisPlazaNomina.NOMINA_IDENTIFICADOR_FORMATO.ToString)

                        strStreamWriter.WriteLine(kt1.ToString & kt2.ToString & kt3.ToString & Kt4.ToString & kt5.ToString & _
                                                  kt6.ToString & kt7.ToString & kt8.ToString & kt9.ToString & kt10.ToString & _
                                                  kt11.ToString & kt12.ToString & kt13.ToString & kt14.ToString)

                        'escribimos en el archivo
                        'Me.GridIngracion.AddItem(drow(0).ToString & Chr(9) & drow(1).ToString & " " & drow(2).ToString & " " & drow(3).ToString & Chr(9) & Format(CDate(drow(5).ToString), "dd-MM-yy") & Chr(9) & drow(6).ToString & Chr(9) & _
                        '                         drow(7).ToString & Chr(9) & drow(8).ToString & Chr(9) & Format(CDate(drow(9).ToString), "dd-MM-yy") & Chr(9) & drow(10).ToString & Chr(9) & drow(11).ToString & Chr(9))
                    End If
                End If
            Next

            '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            sTotalRegingresos = String.Format("{0,6}", Me.txtTotalJornales.Text)
            sTotalRegingresos = sTotalRegingresos.Replace(" ", "0")
            strStreamWriter.WriteLine("*************" & String.Format("{0,43}", " ") & sTotalRegingresos & _
                                      String.Format("{0,71}", " ") & _
                                      Plaza.oSisPlazaNomina.NOMINA_GUIA.ToString & _
                                      String.Format("{0,29}", " ") & _
                                      Plaza.oSisPlazaNomina.NOMINA_IDENTIFICADOR_FORMATO.ToString)

            strStreamWriter.Close() ' cerramos
            GeneraArchivoBajas = True

            MsgBox("El archivo fue generado con éxito en la ruta: " & PathArchivo, MsgBoxStyle.Information, "Generar Altas")

            Exit Function
        Catch ex As Exception
            HandleError(Me.Name, "GeneraArchivoBajas", ex)
        End Try
    End Function

    Public Function ModificaFechaMovimientos() As Boolean
        Dim dTabla As DataTable
        Dim sRenglon As String = Nothing
        Dim strStreamW As Stream = Nothing
        Dim strStreamWriter As StreamWriter = Nothing
        ' Donde guardamos los paths de los archivos que vamos a estar utilizando ..
        Dim PathArchivo As String
        Dim sTotalRegingresos As String

        Try
            If Me.rdbFechaEspecifica.Checked = True Then
                If Me.dtFechaActualizar.Value < Me.DtpFecha1.Value Or Me.dtFechaActualizar.Value > Me.DtpFecha2.Value Then
                    MsgBox("La fecha a modificar está fuera del rango de la semana.", MsgBoxStyle.Exclamation, "ModificaFechaMovimientos")
                    Exit Function
                End If
            End If

            Me.oSUA = New Class_Nomina_SUA

            If Me.TrabajadorAdicional = False Then
                MsgBox("No se generó el trabajador adicional.", MsgBoxStyle.Exclamation, "GeneraArchivoAltas")
                Exit Function
            End If

            dTabla = Me.oSUA.ModificarFechaAfliacionSemanaAlta(CInt(Me.CboSemana.SelectedValue), Me.dtFechaActualizar.Value, Me.cboTxtArchivos.SelectedValue.ToString, Me.cboTxtArchivos.Text, Me.rdbSumaDia.Checked)

            If Directory.Exists(Plaza.oSisPlazaNomina.NOMINA_RUTA_IDSE & "SEM" & Me.CboSemana.Text) = False Then ' si no existe la carpeta se crea
                Directory.CreateDirectory(Plaza.oSisPlazaNomina.NOMINA_RUTA_IDSE & "SEM" & Me.CboSemana.Text)
            End If

            PathArchivo = Plaza.oSisPlazaNomina.NOMINA_RUTA_IDSE & "SEM" & Me.CboSemana.Text & "\" & Me.cboTxtArchivos.Text

            If isExisteArchivo(PathArchivo) = True Then
                File.Delete(PathArchivo)
                strStreamW = File.Create(PathArchivo)
            Else
                strStreamW = File.Create(PathArchivo)
            End If

            strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default) ' tipo de codificacion para escritura
            If Me.cboTxtArchivos.SelectedValue.ToString = "ALTA" Then
                Me.GridIngracion.Rows = 1
                For Each drow As DataRow In dTabla.Rows
                    Dim kt1 As String = String.Format("{0,-11}", Plaza.oSisPlazaNomina.NOMINA_NUMERO_REGISTRO_PATRONAL.ToString)
                    Dim kt2 As String = String.Format("{0,-11}", drow(6).ToString)
                    Dim kt3 As String = String.Format("{0,-27}", drow(1).ToString)
                    Dim Kt4 As String = String.Format("{0,-27}", drow(2).ToString)
                    Dim kt5 As String = String.Format("{0,-27}", drow(3).ToString)
                    Dim kt6 As String = String.Format("{0,6}", (Plaza.oSisPlazaNomina.NOMINA_SUELDO_DIARIO * 100))
                    kt6 = kt6.Replace(" ", "0")
                    Dim kt7 As String = String.Format("{0,6}", "")
                    Dim kt8 As String = String.Format("{0,1}", Plaza.oSisPlazaNomina.NOMINA_TIPO_TRABAJADOR.ToString)
                    Dim kt9 As String = String.Format("{0,1}", Plaza.oSisPlazaNomina.NOMINA_TIPO_SALARIO.ToString)
                    Dim kt10 As String = String.Format("{0,1}", Plaza.oSisPlazaNomina.NOMINA_REDUCCION_TIPO_PAGO.ToString)
                    Dim kt11 As String = String.Format("{0,8}", Format(CDate(drow(7).ToString), "ddMMyyyy"))
                    Dim kt12 As String = String.Format("{0,3}", drow(5).ToString)
                    kt12 = kt12.Replace(" ", "0")
                    Dim kt13 As String = String.Format("{0,2}", "")
                    Dim kt14 As String = String.Format("{0,2}", "08")
                    Dim kt15 As String = String.Format("{0,5}", Plaza.oSisPlazaNomina.NOMINA_GUIA.ToString)
                    kt15 = kt15.Replace(" ", "0")
                    Dim kt16 As String = String.Format("{0,10}", drow(0).ToString.Substring(2))
                    kt16 = kt16.Replace(" ", "0")
                    Dim kt17 As String = String.Format("{0,1}", "")
                    Dim kt18 As String = String.Format("{0,18}", drow(4).ToString)
                    Dim kt19 As String = String.Format("{0,1}", Plaza.oSisPlazaNomina.NOMINA_IDENTIFICADOR_FORMATO.ToString)

                    strStreamWriter.WriteLine(kt1.ToString & kt2.ToString & kt3.ToString & Kt4.ToString & kt5.ToString & _
                                              kt6.ToString & kt7.ToString & kt8.ToString & kt9.ToString & kt10.ToString & _
                                              kt11.ToString & kt12.ToString & kt13.ToString & kt14.ToString & kt15.ToString & _
                                              kt16.ToString & kt17.ToString & kt18.ToString & kt19.ToString)
                    'escribimos en el archivo
                    Me.GridIngracion.AddItem(drow(0).ToString & Chr(9) & drow(1).ToString & " " & drow(2).ToString & " " & drow(3).ToString & Chr(9) & Format(CDate(drow(7).ToString), "dd-MM-yy") & Chr(9) & drow(8).ToString & Chr(9) & _
                                             drow(9).ToString & Chr(9) & drow(10).ToString & Chr(9) & drow(11).ToString & Chr(9) & drow(12).ToString & Chr(9) & drow(13).ToString & Chr(9))

                Next
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                sTotalRegingresos = String.Format("{0,6}", dTabla.Rows.Count.ToString)
                sTotalRegingresos = sTotalRegingresos.Replace(" ", "0")

                strStreamWriter.WriteLine("*************" & String.Format("{0,43}", " ") & sTotalRegingresos & _
                              String.Format("{0,71}", " ") & _
                              Plaza.oSisPlazaNomina.NOMINA_GUIA.ToString & _
                              String.Format("{0,29}", " ") & _
                              Plaza.oSisPlazaNomina.NOMINA_IDENTIFICADOR_FORMATO.ToString)
            ElseIf Me.cboTxtArchivos.SelectedValue.ToString = "BAJA" Then
                Me.GridIngracion.Rows = 1
                For Each drow As DataRow In dTabla.Rows
                    Dim kt1 As String = String.Format("{0,-11}", Plaza.oSisPlazaNomina.NOMINA_NUMERO_REGISTRO_PATRONAL.ToString)
                    Dim kt2 As String = String.Format("{0,-11}", drow(4).ToString)
                    Dim kt3 As String = String.Format("{0,-27}", drow(1).ToString)
                    Dim Kt4 As String = String.Format("{0,-27}", drow(2).ToString)
                    Dim kt5 As String = String.Format("{0,-27}", drow(3).ToString)
                    Dim kt6 As String = String.Format("{0,15}", "")
                    kt6 = kt6.Replace(" ", "0")
                    Dim kt7 As String = String.Format("{0,8}", Format(CDate(drow(9).ToString), "ddMMyyyy"))
                    Dim kt8 As String = String.Format("{0,5}", "")
                    Dim kt9 As String = String.Format("{0,2}", "02")
                    Dim kt10 As String = String.Format("{0,5}", Plaza.oSisPlazaNomina.NOMINA_GUIA.ToString)
                    kt10 = kt10.Replace(" ", "0")
                    Dim kt11 As String = String.Format("{0,10}", drow(0).ToString.Substring(2))
                    kt11 = kt11.Replace(" ", "0")
                    Dim kt12 As String = String.Format("{0,1}", "2")
                    Dim kt13 As String = String.Format("{0,18}", "")
                    Dim kt14 As String = String.Format("{0,1}", Plaza.oSisPlazaNomina.NOMINA_IDENTIFICADOR_FORMATO.ToString)

                    strStreamWriter.WriteLine(kt1.ToString & kt2.ToString & kt3.ToString & Kt4.ToString & kt5.ToString & _
                                              kt6.ToString & kt7.ToString & kt8.ToString & kt9.ToString & kt10.ToString & _
                                              kt11.ToString & kt12.ToString & kt13.ToString & kt14.ToString)

                    'escribimos en el archivo
                    Me.GridIngracion.AddItem(drow(0).ToString & Chr(9) & drow(1).ToString & " " & drow(2).ToString & " " & drow(3).ToString & Chr(9) & Format(CDate(drow(5).ToString), "dd-MM-yy") & Chr(9) & drow(6).ToString & Chr(9) & _
                                             drow(7).ToString & Chr(9) & drow(8).ToString & Chr(9) & Format(CDate(drow(9).ToString), "dd-MM-yy") & Chr(9) & drow(10).ToString & Chr(9) & drow(11).ToString & Chr(9))
                Next
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                sTotalRegingresos = String.Format("{0,6}", dTabla.Rows.Count.ToString)
                sTotalRegingresos = sTotalRegingresos.Replace(" ", "0")
                strStreamWriter.WriteLine("*************" & String.Format("{0,43}", " ") & sTotalRegingresos & _
                                          String.Format("{0,71}", " ") & _
                                          Plaza.oSisPlazaNomina.NOMINA_GUIA.ToString & _
                                          String.Format("{0,29}", " ") & _
                                          Plaza.oSisPlazaNomina.NOMINA_IDENTIFICADOR_FORMATO.ToString)

            End If

            strStreamWriter.Close() ' cerramos

            MsgBox("El archivo fue modificado con éxito en la ruta: " & PathArchivo, MsgBoxStyle.Information, "Generar Altas")
            Me.ConsultarArchivo()

            Exit Function
        Catch ex As Exception
            HandleError(Me.Name, "ModificarFecha", ex)
        End Try

    End Function

    Private Function Validar() As Boolean
        Dim i As Integer, j As Integer, sCodigoTrbajador As String = ""

        For i = 1 To Me.GridSemanaTrabajadores.Rows - 1
            If txtLEN(Me.GridSemanaTrabajadores.Cell(i, Me.igyCodigoTrabajador).Text) = True Then
                If Me.GridSemanaTrabajadores.Cell(i, Me.igyValidacionIMSS).Text = "1" Then
                    Validar = True
                End If
            End If
        Next i

        If Validar = False Then
            MsgBox("No hay trabajadores que cumplan todas las validaciónes, favor de verificar.", MsgBoxStyle.Exclamation, "Confirmar")
            Exit Function
        End If

        For i = 1 To Me.GridSemanaTrabajadores.Rows - 1
            If txtLEN(Me.GridSemanaTrabajadores.Cell(i, Me.igyCodigoTrabajador).Text) = True Then
                If txtLEN(Me.GridSemanaTrabajadores.Cell(i, Me.igyValidacionesControl).Text) = True Then
                    MsgBox("Revisar validaciones de control.", MsgBoxStyle.Exclamation, "Validación de trabajadores")
                    Validar = False
                    Exit Function
                End If
            End If
        Next i

        For i = 1 To Me.GridSemanaTrabajadores.Rows - 1
            If txtLEN(Me.GridSemanaTrabajadores.Cell(i, Me.igyCodigoTrabajador).Text) = True Then
                sCodigoTrbajador = Me.GridSemanaTrabajadores.Cell(i, Me.igyCodigoTrabajador).Text
                For j = i + 1 To Me.GridSemanaTrabajadores.Rows - 1
                    If txtLEN(Me.GridSemanaTrabajadores.Cell(j, Me.igyCodigoTrabajador).Text) = True Then
                        If sCodigoTrbajador = Me.GridSemanaTrabajadores.Cell(j, Me.igyCodigoTrabajador).Text And Me.GridSemanaTrabajadores.Rows > 2 Then
                            MsgBox("El trabajador que intenta introducir ya existe, favor de intentar con otro trabajador.", MsgBoxStyle.Exclamation, "Validación de trabajadores")
                            Me.GridSemanaTrabajadores.Cell(i, Me.igyCodigoTrabajador).SetFocus()
                            Me.GridSemanaTrabajadores.Selection.DeleteByRow()
                            Validar = False
                            Exit Function
                        End If
                    End If
                Next j
            End If
        Next i

        Validar = True

    End Function

    Private Function TrabajadorAdicional() As Boolean
        Dim i As Integer

        Try
            For i = 1 To Me.GridSemanaTrabajadores.Rows - 1
                If Me.GridSemanaTrabajadores.Cell(i, Me.igyAdicional).Text = "1" And Me.GridSemanaTrabajadores.Cell(i, Me.igyValidacionIMSS).Text = "1" Then
                    Me.oSUA.ObtenerTrabajadorAdicional(CInt(Me.CboSemana.Text), Me.GridSemanaTrabajadores.Cell(i, Me.igyCodigoTrabajador).Text, CDate(Me.GridSemanaTrabajadores.Cell(i, Me.igyFechaAlta).Text), sMovimiento, True)
                End If
            Next
            TrabajadorAdicional = True
        Catch ex As Exception
            HandleError(Me.Name, "TrabajadorAdicional", ex)
        End Try
    End Function

    Private Function EliminaArchivo() As Boolean
        Dim PathArchivo As String

        PathArchivo = Plaza.oSisPlazaNomina.NOMINA_RUTA_IDSE & "SEM" & Me.CboSemana.Text & "\" & Me.cboTxtArchivos.Text
        Try

            If isExisteArchivo(PathArchivo) = True Then
                Dim oNominaMovimientos As New Class_NominaMovimientoSua
                oNominaMovimientos.ID_NOMINA_SEMANA = CInt(Me.CboSemana.SelectedValue)

                If oNominaMovimientos.EliminaElementos(Me.cboTxtArchivos.Text, Me.cboTxtArchivos.SelectedValue.ToString) = False Then
                    Exit Function
                End If

                File.Delete(PathArchivo)
                EliminaArchivo = True

                MsgBox("El archivo se eliminó correctamente. ", MsgBoxStyle.Information, Me.Text)
            Else
                MsgBox("No se encontro el archivo. ", MsgBoxStyle.Exclamation, Me.Text)
                Exit Function
            End If

        Catch ex As Exception
            HandleError(Me.Name, "EliminaArchivo", ex)
        End Try
    End Function

    Private Function GestionaIntegracion() As Boolean
        Dim i As Integer
        Dim sArchivo As String

        sArchivo = Me.cboTxtArchivos.Text

        If txtLEN(Me.cboTxtArchivos.Text.ToString) = False Then
            MsgBox("No se encontro el archivo. ", MsgBoxStyle.Exclamation, Me.Text)
            Exit Function
        End If

        Dim oNominaMovimientos As New Class_NominaMovimientoSua
        oNominaMovimientos.ID_NOMINA_SEMANA = CInt(Me.CboSemana.SelectedValue)

        If MsgBox("Deseas grabar el integrar el archivo " & Me.cboTxtArchivos.Text & " ?", CType(vbYesNo + vbQuestion, MsgBoxStyle), "Integración") = MsgBoxResult.No Then
            Exit Function
        End If
        Try
            'ELIMINA RECHAZADOS
            For i = 1 To Me.GridIngracion.Rows - 1
                If txtLEN(Me.GridIngracion.Cell(i, Me.igyIntegracionCodigoTrabajador).Text) = True Then
                    If Me.GridIngracion.Cell(i, Me.igyIntegracionRechasados).Text = "1" Then
                        'ELIMINA RECHAZADOS
                        If oNominaMovimientos.EliminarMovimientoRechazado(Me.GridIngracion.Cell(i, Me.igyIntegracionCodigoTrabajador).Text, Me.cboTxtArchivos.Text, Me.cboTxtArchivos.SelectedValue.ToString) = False Then
                            MsgBox("No se pudo integrar el archivo. ", MsgBoxStyle.Exclamation, Me.Text)
                            Exit Function
                        End If
                    End If
                End If
            Next

            'conexionMDB.Open()
            Dim oSua As New Class_Nomina_SUA

            If Me.cboTxtArchivos.SelectedValue.ToString = "ALTA" Then
                For i = 1 To Me.GridIngracion.Rows - 1
                    If txtLEN(Me.GridIngracion.Cell(i, Me.igyIntegracionCodigoTrabajador).Text) = True Then
                        If Me.GridIngracion.Cell(i, Me.igyIntegracionRechasados).Text <> "1" Then
                            If oSua.ExisteAfiliacion(Me.GridIngracion.Cell(i, Me.igyIntegracionCodigoTrabajador).Text) = False Then
                                If oSua.IntegraAfiliacion(Me.GridIngracion.Cell(i, Me.igyIntegracionCodigoTrabajador).Text) = False Then
                                    MsgBox("No se pudo integrar el archivo. ", MsgBoxStyle.Exclamation, Me.Text)
                                    Exit Function
                                End If
                            End If
                            If oSua.ExisteAsegura(Me.GridIngracion.Cell(i, Me.igyIntegracionCodigoTrabajador).Text) = False Then
                                If oSua.IntegraAsegura(Me.GridIngracion.Cell(i, Me.igyIntegracionCodigoTrabajador).Text, Me.GridIngracion.Cell(i, Me.igyIntegracionFechaAlta).Text) = False Then
                                    MsgBox("No se pudo integrar el archivo. ", MsgBoxStyle.Exclamation, Me.Text)
                                    Exit Function
                                End If
                            End If
                            If oSua.ExisteMovimiento(Me.GridIngracion.Cell(i, Me.igyIntegracionCodigoTrabajador).Text, Me.GridIngracion.Cell(i, Me.igyIntegracionFechaAlta).Text, IIf(Me.cboTxtArchivos.SelectedValue.ToString = "ALTA", "08", "02").ToString) = False Then
                                If oSua.IntegraMovimientoAlta(Me.GridIngracion.Cell(i, Me.igyIntegracionCodigoTrabajador).Text, Me.GridIngracion.Cell(i, Me.igyIntegracionFechaAlta).Text, CInt(Me.CboSemana.Text)) = False Then
                                    MsgBox("No se pudo integrar el archivo. ", MsgBoxStyle.Exclamation, Me.Text)
                                    Exit Function
                                Else
                                    oSua.IntegraAseguraFechaBaja(Me.GridIngracion.Cell(i, Me.igyIntegracionCodigoTrabajador).Text, "")
                                End If
                            End If
                        End If
                    End If
                Next i
            ElseIf Me.cboTxtArchivos.SelectedValue.ToString = "BAJA" Then
                For i = 1 To Me.GridIngracion.Rows - 1
                    If txtLEN(Me.GridIngracion.Cell(i, Me.igyIntegracionCodigoTrabajador).Text) = True Then
                        If Me.GridIngracion.Cell(i, Me.igyIntegracionRechasados).Text <> "1" Then
                            If oSua.ExisteMovimiento(Me.GridIngracion.Cell(i, Me.igyIntegracionCodigoTrabajador).Text, Me.GridIngracion.Cell(i, Me.igyIntegracionFechaBaja).Text, IIf(Me.cboTxtArchivos.SelectedValue.ToString = "ALTA", "08", "02").ToString) = False Then
                                If oSua.IntegraMovimientoBaja(Me.GridIngracion.Cell(i, Me.igyIntegracionCodigoTrabajador).Text, Me.GridIngracion.Cell(i, Me.igyIntegracionFechaBaja).Text) = False Then
                                    MsgBox("No se pudo integrar el archivo. ", MsgBoxStyle.Exclamation, Me.Text)
                                    Exit Function
                                Else
                                    oSua.IntegraAseguraFechaBaja(Me.GridIngracion.Cell(i, Me.igyIntegracionCodigoTrabajador).Text, Me.GridIngracion.Cell(i, Me.igyIntegracionFechaBaja).Text)
                                End If
                            Else
                                MsgBox("EL movimiento del trabajador " & Me.GridIngracion.Cell(i, Me.igyIntegracionCodigoTrabajador).Text & " ya esta integrado. ", MsgBoxStyle.Exclamation, Me.Text)
                                'Exit Function
                            End If
                        End If
                    End If
                Next i
            End If

            'conexionMDB.Close()
            'conexionMDB.Dispose()

            If oNominaMovimientos.IntegraMovimientos(Me.cboTxtArchivos.Text, Me.cboTxtArchivos.SelectedValue.ToString) = False Then
                MsgBox("No se pudo integrar el archivo. ", MsgBoxStyle.Exclamation, Me.Text)
                Exit Function
            End If

            GestionaIntegracion = True
            MsgBox("Se integro el archivo satisfactoriamente. ", MsgBoxStyle.Information, Me.Text)

            Me.cboTxtArchivos.Dispose()
            Me.ConsultarArchivo()
            Me.cboTxtArchivos.Text = ""
        Catch ex As Exception
            HandleError(Me.Name, "GestionaIntegracion", ex)
        End Try
    End Function

    Private Sub Imprimir()
        Dim StrFiltros As String = ""
        Dim FormatoDeReporte As String
        Dim Rpt As ReportDocument
        Rpt = New ReportDocument
        Dim oReporte As Class_Reporte
        Try
            FormatoDeReporte = "RPT_NOMINA_AFILIACIONES_OBTIENE_SEMANA_ALTA_TRABAJADORES_EXCLUIDOS"
            oReporte = New Class_Reporte(FormatoDeReporte, Rpt)
            If Not oReporte.RptCargado Then
                Exit Sub
            End If

            Rpt.SetParameterValue("@ID_NOMINA_SEMANA", Me.CboSemana.SelectedValue)

            Dim frm As New Reporte(Rpt)
            frm.CRViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            frm.Show()
        Catch ex As Exception
            HandleError(Me.Name, "Impresión de trabajadores excluidos", ex)
        Finally
            oReporte = Nothing
        End Try
    End Sub

    Private Sub Cambia_Estado(ByVal pEstado As enumEstados)
        Me.Estado = pEstado

        Select Case Me.Estado
            Case enumEstados.NUEVO
                Me.btnConfirmar.Enabled = False
                Me.btnRegresar.Enabled = False
                Me.btnAltaAdicional.Enabled = False
                Me.BtnReporte.Enabled = False
                Me.lblModo.Text = ""

            Case enumEstados.ALTA
                Me.btnConfirmar.Enabled = True
                Me.btnRegresar.Enabled = True
                Me.btnAltaAdicional.Enabled = True
                Me.BtnReporte.Enabled = True
                Me.lblModo.Text = "ALTA"
                Me.sMovimiento = "ALTA"

            Case enumEstados.BAJA
                Me.btnConfirmar.Enabled = True
                Me.btnRegresar.Enabled = True
                Me.btnAltaAdicional.Enabled = False
                Me.BtnReporte.Enabled = False
                Me.lblModo.Text = "BAJA"
                Me.sMovimiento = "BAJA"
        End Select

        Application.DoEvents()
    End Sub

#End Region

    Private Sub GridIngracion_CellChange(ByVal Sender As Object, ByVal e As FlexCell.Grid.CellChangeEventArgs) Handles GridIngracion.CellChange
        If Me.GridIngracion.ActiveCell.Col = Me.igyIntegracionRechasados Then
            Me.Totales()
        End If
    End Sub

    Private Sub GridIngracion_Click(ByVal Sender As Object, ByVal e As System.EventArgs) Handles GridIngracion.Click
        If Me.GridIngracion.ActiveCell.Col = Me.igyIntegracionRechasados Then
            Me.Totales()
        End If
    End Sub

    Private Sub btnAltaAdicional_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAltaAdicional.Click
        Dim Child As New Frm_Nomina_TrabajadorAdicional
        Dim oTrabajador As New Class_CatTrabajadores
        Dim dTabla As DataTable

        Child.txtCodigoTrabajador.Text = ""
        Child.dtFecha.Value = Now
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.NUMERO_SEMANA = CInt(Me.CboSemana.Text)
        Child.ShowDialog()

        If txtLEN(Child.CODIGO_TRABAJADOR.ToString) = False Then
            Exit Sub
        End If
        dTabla = Me.oSUA.ObtenerTrabajadorAdicional(CInt(Me.CboSemana.SelectedValue), Child.CODIGO_TRABAJADOR, Child.FECHA, sMovimiento, False)

        'Me.GridSemanaTrabajadores.Rows = Me.GridSemanaTrabajadores.Rows + 1

        For Each dRow As DataRow In dTabla.Rows
            'Me.GridSemanaTrabajadores.AddItem(dRow(0).ToString & Chr(9) & dRow(1).ToString & " " & dRow(2).ToString & " " & dRow(3).ToString & Chr(9) & _
            '                            dRow(4).ToString & Chr(9) & dRow(5).ToString & Chr(9) & dRow(6).ToString & Chr(9) & dRow(7).ToString & Chr(9) & _
            '                            dRow(8).ToString & Chr(9) & dRow(9).ToString & Chr(9) & dRow(10).ToString & Chr(9) & "1".ToString & Chr(9))
            Me.GridSemanaTrabajadores.AddItem(dRow(0).ToString & Chr(9) & dRow(1).ToString & " " & dRow(2).ToString & " " & dRow(3).ToString & Chr(9) & dRow(4).ToString & Chr(9) & _
                                  dRow(5).ToString & Chr(9) & dRow(6).ToString & Chr(9) & dRow(7).ToString & Chr(9) & dRow(8).ToString & Chr(9) & dRow(9).ToString & Chr(9) & _
                                  dRow(10).ToString & Chr(9) & dRow(11).ToString & Chr(9) & dRow(13).ToString & Chr(9) & "0".ToString & Chr(9) & dRow(14).ToString & Chr(9) & _
                                  dRow(15).ToString & Chr(9) & dRow(16).ToString & Chr(9) & dRow(17).ToString)
        Next

        dTabla.Dispose()

        Me.Validar()
        Me.Totales()
        Child.Dispose()
    End Sub

    Private Sub GridIngracion_KeyPress(ByVal Sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles GridIngracion.KeyPress
        If Me.GridIngracion.ActiveCell.Col = Me.igyIntegracionRechasados Then
            'Me.GridIngracion.Cell(Me.GridIngracion.ActiveCell.Row, Me.igyIntegracionCodigoTrabajador).SetFocus()
            Me.Totales()
        End If
    End Sub

    Private Sub BtnReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReporte.Click
        Me.Imprimir()
    End Sub

    Private Sub btnModificarFecha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificarFecha.Click
        If MsgBox("Deseas cambiar la fecha a todos los trabajadores del movimiento de " & sMovimiento & " de la semana " & Me.CboSemana.Text & " ?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "Confirmar") = MsgBoxResult.No Then
            Exit Sub
        End If

        If txtLEN(Me.cboTxtArchivos.Text) = False Then
            MsgBox("No se encontro el archivo. ", MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        Else
            Me.ModificaFechaMovimientos()
        End If
    End Sub

    Private Sub rdbFechaEspecifica_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbFechaEspecifica.CheckedChanged
        If rdbFechaEspecifica.Checked = True Then
            Me.dtFechaActualizar.Enabled = True
        Else
            Me.dtFechaActualizar.Enabled = False
        End If
    End Sub

    Private Sub rdbSumaDia_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbSumaDia.CheckedChanged
        If rdbSumaDia.Checked = True Then
            Me.dtFechaActualizar.Enabled = False
        Else
            Me.dtFechaActualizar.Enabled = True
        End If
    End Sub

    Private Sub gbSemanas_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gbSemanas.Enter

    End Sub
End Class