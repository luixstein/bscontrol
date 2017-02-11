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

Public Class ProyectoSiembraEdicion

    Private Estado As enumEstados
    Private oProyectoSiembra As New Class_ProyectoSiembra
    Public Agregar As Boolean = False

    Private Enum enumEstados
        NUEVO
        EDICION
        CONSULTA
    End Enum

#Region "Propiedades"

#End Region

#Region "Opciones"
    Private Sub tsbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGrabar.Click
        Dim sMsg As String = ""
        Select Case Me.Estado
            Case enumEstados.EDICION
                sMsg = " grabar las modificaciones del proyecto de siembra : " & Me.txtIdProyecto.Text
            Case enumEstados.NUEVO
                sMsg = " agregar el proyecto de siembra"
        End Select
        sMsg = "Deseas " & sMsg & " ?"
        If MsgBox(sMsg, CType(CInt(MsgBoxStyle.Question) + CInt(MsgBoxStyle.YesNo), MsgBoxStyle)) = MsgBoxResult.Yes Then
            Me.Grabar_Elemento()
        End If
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub

#End Region

#Region "Eventos"
    Private Sub Prpoyecto_siembra_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Agregar = True Then
            Me.Inicializa()
            Me.Estado = enumEstados.NUEVO
            Me.Cambia_Estado()
        Else
            Dim oCentroCosto As New Class_CatCentroCostos

            If txtLEN(Me.TxtCodCentroCostoOrigen.Text) = True Then
                oCentroCosto.CODIGO_CENTRO_COSTO = CInt(Me.TxtCodCentroCostoOrigen.Text)
                oCentroCosto.Consultar()
                Me.LblCentroCostoOrigen.Text = oCentroCosto.NOMBRE_CENTRO_COSTO
            End If

            If txtLEN(Me.TxtCodCentroCosto.Text) = True Then
                oCentroCosto.CODIGO_CENTRO_COSTO = CInt(Me.TxtCodCentroCosto.Text)
                oCentroCosto.Consultar()
                Me.LblCentroCosto.Text = oCentroCosto.NOMBRE_CENTRO_COSTO
            End If
            Me.Estado = enumEstados.EDICION
            Me.Cambia_Estado()
        End If
        
    End Sub

    Private Sub CboEjercicio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboEjercicio.SelectedIndexChanged
        SendKeys.Send("{TAB}")
    End Sub

    Private Sub chkbFechaSiembra_CheckedChanged(sender As Object, e As EventArgs) Handles chkbFechaSiembra.CheckedChanged
        If Me.chkbFechaSiembra.Checked = True Then
            Me.dtFechaSiembra.Enabled = False
        Else
            Me.dtFechaSiembra.Enabled = True
        End If
    End Sub

    Private Sub ChkbFechaCorte_CheckedChanged(sender As Object, e As EventArgs) Handles ChkbFechaCorte.CheckedChanged
        If Me.ChkbFechaCorte.Checked = True Then
            Me.dtFechaCorte.Enabled = False
        Else
            Me.dtFechaCorte.Enabled = True
        End If
    End Sub

    Private Sub chkbFechaFin_CheckedChanged(sender As Object, e As EventArgs) Handles chkbFechaFin.CheckedChanged
        If Me.chkbFechaFin.Checked = True Then
            Me.dtFechaFin.Enabled = False
        Else
            Me.dtFechaFin.Enabled = True
        End If
    End Sub

#Region "Eventos genericos"
    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtHectareasSembradas.KeyPress
        Dim txt As TextBox = CType(sender, TextBox)
        txtSoloNumerosDecimales(e, txt.Text)
        txtNoBeep(e)
    End Sub

    Private Sub txtNumerosEnterosKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodCultivo.KeyPress, TxtCodCentroCosto.KeyPress, TxtCodCentroCostoOrigen.KeyPress, TxtOrden.KeyPress, txtCodLote.KeyPress
        txtSoloNumerosEnteros(e)
        txtNoBeep(e)
    End Sub

    Private Sub txtNoBeep_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtFechaSiembra.KeyPress, dtFechaCorte.KeyPress, dtFechaFin.KeyPress
        txtNoBeep(e)
    End Sub

#End Region

#Region "KeyDown especificos"
    Private Sub txtCodigoCultivo_keyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodCultivo.KeyDown
        Dim oCultivos As New Class_CatCultivos

        If e.KeyCode = Keys.F6 Then
            Dim resultado As String
            resultado = oCultivos.BusquedaVisual_PorDescripcion()
            Me.TxtCodCultivo.Text = resultado : GoTo Buscar : Exit Sub
        End If
        If e.KeyCode = Keys.Return Then
Buscar:
            If txtLEN(Me.TxtCodCultivo.Text) = True Then
                oCultivos.CODIGO_CULTIVO = Me.TxtCodCultivo.Text
                oCultivos.Consultar()
                Me.LblCultivo.Text = oCultivos.NOMBRE_CULTIVO
                SendKeys.Send("{TAB}")
            End If

        End If
    End Sub

    Private Sub txtCentroCosto_keyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodCentroCosto.KeyDown
        Dim oCentroCosto As New Class_CatCentroCostos

        If e.KeyCode = Keys.F6 Then
            Dim resultado As String
            resultado = oCentroCosto.BusquedaVisual_PorDescripcion()
            Me.TxtCodCentroCosto.Text = resultado : GoTo Buscar : Exit Sub
        End If
        If e.KeyCode = Keys.Return Then
Buscar:
            If txtLEN(Me.TxtCodCentroCosto.Text) = True Then
                oCentroCosto.CODIGO_CENTRO_COSTO = CInt(Me.TxtCodCentroCosto.Text)
                oCentroCosto.Consultar()
                Me.LblCentroCosto.Text = oCentroCosto.NOMBRE_CENTRO_COSTO
                SendKeys.Send("{TAB}")
            End If

        End If
    End Sub

    Private Sub txtCentroCostoOrigen_keyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodCentroCostoOrigen.KeyDown
        Dim oCentroCosto As New Class_CatCentroCostos

        If e.KeyCode = Keys.F6 Then
            Dim resultado As String
            resultado = oCentroCosto.BusquedaVisual_PorDescripcion()
            Me.TxtCodCentroCostoOrigen.Text = resultado : GoTo Buscar : Exit Sub
        End If
        If e.KeyCode = Keys.Return Then
Buscar:
            If txtLEN(Me.TxtCodCentroCostoOrigen.Text) = True Then
                oCentroCosto.CODIGO_CENTRO_COSTO = CInt(Me.TxtCodCentroCostoOrigen.Text)
                oCentroCosto.Consultar()
                Me.LblCentroCostoOrigen.Text = oCentroCosto.NOMBRE_CENTRO_COSTO
                SendKeys.Send("{TAB}")
            Else
                SendKeys.Send("{TAB}")
            End If

        End If
    End Sub

    Private Sub txtCodLote_keyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodLote.KeyDown
        Dim oLotes As New Class_CatLotes

        If e.KeyCode = Keys.F6 Then
            Dim resultado As String
            resultado = oLotes.BusquedaVisual_PorDescripcion()
            Me.txtCodLote.Text = resultado : GoTo Buscar : Exit Sub
        End If
        If e.KeyCode = Keys.Return Then
Buscar:
            If txtLEN(Me.TxtCodCultivo.Text) = True Then
                oLotes.Codigo_Lote = Me.txtCodLote.Text
                oLotes.Consultar()
                Me.lblNombreLote.Text = oLotes.Nombre_Lote
                SendKeys.Send("{TAB}")
            End If

        End If
    End Sub

    Private Sub txtOrden_keyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtOrden.KeyDown
        If e.KeyCode = Keys.Return Then
            If txtLEN(Me.TxtOrden.Text) Then
                SendKeys.Send("{TAB}")
            End If
        End If
    End Sub

    Private Sub dtFecha_keyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtFechaSiembra.KeyDown, dtFechaCorte.KeyDown, dtFechaFin.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtHectareasSembradas_keyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtHectareasSembradas.KeyDown
        If e.KeyCode = Keys.Return Then
            If txtLEN(Me.TxtHectareasSembradas.Text) Then
                SendKeys.Send("{TAB}")
            End If
        End If
    End Sub

    Private Sub chkbSiembra_keyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles chkbFechaSiembra.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.chkbFechaSiembra.Checked = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub chkbCorte_keyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ChkbFechaCorte.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.ChkbFechaCorte.Checked = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub chkbFin_keyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles chkbFechaFin.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.chkbFechaFin.Checked = True
            tsbGrabar.PerformClick()
        End If
    End Sub
#End Region

#End Region

#Region "Métodos y procedimientos"

    Private Sub Cambia_Estado()
        Try
            Select Case Me.Estado
                Case enumEstados.NUEVO
                    Me.tsbGrabar.Enabled = True
                    Me.txtIdProyecto.Enabled = False
                    DesplegarEjercicios()
                    Inicializa()
                    Me.txtIdProyecto.Text = IdSiguiente()
                    Me.CboEjercicio.SelectedValue = Plaza.ID_CON_EJERCICIO

                Case enumEstados.EDICION
                    Me.tsbGrabar.Enabled = True
                    Me.txtIdProyecto.Enabled = False

                Case enumEstados.CONSULTA
                    Me.tsbGrabar.Enabled = False

            End Select
            Application.DoEvents()

        Catch ex As Exception
            HandleError(Me.Name, "Cambia_Estado", ex)
        End Try
    End Sub

    Public Sub DesplegarEjercicios()
        Try
            With Me.CboEjercicio
                .DisplayMember = "NOMBRE_EJERCICIO"
                .ValueMember = "ID_CON_EJERCICIO"
                Dim dView As New Data.DataView(oProyectoSiembra.ObtenerEjercicios)
                dView.Sort = "NOMBRE_EJERCICIO"
                .DataSource = dView

            End With
        Catch ex As Exception
            HandleError(Me.Name, "Desplegarejercicios", ex)
        End Try
    End Sub

    Private Sub Inicializa()
        Try
            Me.txtIdProyecto.Text = ""
            Me.TxtOrden.Text = ""
            Me.TxtCodCultivo.Text = ""
            Me.TxtCodCentroCostoOrigen.Text = ""
            Me.TxtCodCentroCosto.Text = ""
            Me.TxtHectareasSembradas.Text = ""
            Me.txtCodLote.Text = ""

        Catch ex As Exception
            HandleError(Me.Name, "Inicializa", ex)
        End Try
    End Sub

    'Public Sub LlenaElemento(ByVal id_Proyecto As String)
    '    Me.oProyectoSiembra.ID_PROYECTO = id_Proyecto
    '    If Me.oProyectoSiembra.Consultar Then
    '        With Me.oProyectoSiembra
    '            'Me.txtIdProyecto.Text = .ID_PROYECTO.ToString
    '            Me.CboEjercicio.SelectedValue = CInt(.ID_CON_EJERCICIO)
    '            Me.TxtOrden.Text = .ORDEN
    '            Me.TxtCodCultivo.Text = .CODIGO_CULTIVO
    '            Me.TxtCodCentroCostoOrigen.Text = .CODIGO_CENTRO_COSTO_ORIGEN
    '            Me.TxtCodCentroCosto.Text = .CODIGO_CENTRO_COSTO
    '            Me.TxtHectareasSembradas.Text = .HECTAREAS_SEMBRADAS

    '            If txtLEN(.FECHA_SIEMBRA.ToString) Then
    '                Me.dtFechaSiembra.Value = CDate(.FECHA_SIEMBRA)
    '            Else
    '                Me.chkbFechaSiembra.Checked = True
    '            End If

    '            If txtLEN(.FECHA_CORTE.ToString) Then
    '                Me.dtFechaCorte.Value = CDate(.FECHA_CORTE)
    '            Else
    '                Me.ChkbFechaCorte.Checked = True
    '            End If

    '            If txtLEN(.FECHA_FIN_TEMPORADA.ToString) Then
    '                Me.dtFechaFin.Value = CDate(.FECHA_FIN_TEMPORADA)
    '            Else
    '                Me.chkbFechaFin.Checked = True
    '            End If


    '        End With
    '    End If
    'End Sub

    Private Sub Grabar_Elemento()
        Dim Grabado As Boolean = False

        If Validar() = False Then
            Exit Sub
        End If

        Select Case Me.Estado
            Case enumEstados.NUEVO, enumEstados.EDICION
                Try
                    With Me.oProyectoSiembra
                        .ID_PROYECTO = Me.txtIdProyecto.Text
                        .ID_CON_EJERCICIO = Me.CboEjercicio.SelectedValue.ToString
                        .ORDEN = Me.TxtOrden.Text

                        If txtLEN(Me.TxtCodCultivo.Text) Then
                            .CODIGO_CULTIVO = Me.TxtCodCultivo.Text
                        Else
                            .CODIGO_CULTIVO = "-1"
                        End If

                        .CODIGO_CENTRO_COSTO = Me.TxtCodCentroCosto.Text
                        .HECTAREAS_SEMBRADAS = Me.TxtHectareasSembradas.Text

                        If Me.chkbFechaSiembra.Checked Then
                            .FECHA_SIEMBRA = CDate("01/01/1900")
                        Else
                            .FECHA_SIEMBRA = Me.dtFechaSiembra.Value
                        End If

                        If Me.ChkbFechaCorte.Checked Then
                            .FECHA_CORTE = CDate("01/01/1900")
                        Else
                            .FECHA_CORTE = Me.dtFechaCorte.Value
                        End If

                        If Me.chkbFechaFin.Checked Then
                            .FECHA_FIN_TEMPORADA = CDate("01/01/1900")
                        Else
                            .FECHA_FIN_TEMPORADA = Me.dtFechaFin.Value
                        End If

                        If Len(Me.TxtCodCentroCostoOrigen.Text) < 1 Then
                            .CODIGO_CENTRO_COSTO_ORIGEN = "-1"
                        Else
                            .CODIGO_CENTRO_COSTO_ORIGEN = Me.TxtCodCentroCostoOrigen.Text
                        End If

                        If Len(Me.txtCodLote.Text) < 1 Then
                            .CODIGO_LOTE = "-1"
                        Else
                            .CODIGO_LOTE = Me.txtCodLote.Text
                        End If

                        Select Case Me.Estado
                            Case enumEstados.NUEVO

                                If .Insertar() Then
                                    Grabado = True
                                End If

                            Case enumEstados.EDICION
                                If .Actualizar() Then
                                    Grabado = True
                                End If
                        End Select

                        If Grabado = True Then
                            MsgBox(" Grabado satisfactoriamente.", MsgBoxStyle.Information, Me.Name)
                            Me.Close()
                        End If

                    End With
                Catch ex As Exception
                    HandleError(Me.Name, "Grabar", ex)
                Finally

                End Try
        End Select
    End Sub

    Private Function Validar() As Boolean
        Dim bResultado As Boolean = False

        If txtLEN(Me.TxtOrden.Text) = False Then
            MsgBox("Agregue un orden.", MsgBoxStyle.Exclamation)
            Me.TxtOrden.Focus()
            Return bResultado
        End If

        If txtLEN(Me.TxtCodCentroCosto.Text) = False Then
            MsgBox("Agregue un centro de costo.", MsgBoxStyle.Exclamation)
            Me.TxtCodCentroCosto.Focus()
            Return bResultado
        End If

        If txtLEN(Me.TxtHectareasSembradas.Text) = False Then
            MsgBox("Agregue un numero de hectareas sembradas.", MsgBoxStyle.Exclamation)
            Me.TxtHectareasSembradas.Focus()
            Return bResultado
        End If

        bResultado = True

        Return bResultado

    End Function

    Private Function IdSiguiente() As String
        Dim iResultado As String
        Dim sql As New Class_find("SELECT MAX(ID_PROYECTO) FROM PROYECTO_SIEMBRA")
        iResultado = (CInt(sql.Result1) + 1).ToString
        Return iResultado

    End Function

#End Region
End Class