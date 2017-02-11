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

Public Class ProyectoSiembra

    Private Estado As enumEstados
    Private oProyectoSiembra As New Class_ProyectoSiembra

    Private Enum enumEstados
        NUEVO
        GRABADO
        CONSULTA
    End Enum

#Region "Propiedades"

#End Region

#Region "Opciones"
    Private Sub tsbNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbNuevo.Click
        Dim agregar As Boolean = True
        Dim oProyectoSiembraEdicion As New ProyectoSiembraEdicion("Nuevo", agregar)
        oProyectoSiembraEdicion.ShowDialog()
        oProyectoSiembraEdicion.Dispose()
        Me.DesplegarElementosGrid()

    End Sub

    Private Sub tsbEditar_Click(sender As Object, e As EventArgs) Handles tsbEditar.Click
        AbrirEditorProyecto()
    End Sub

    Private Sub tsbEliminar_Click(sender As Object, e As EventArgs) Handles tsbEliminar.Click
        Dim idProyecto As String = Me.Grid1.CurrentRow.Cells("ID_PROYECTO").Value.ToString
        If MsgBox("¿Desea eliminar el proyecto de siembra " & idProyecto & "?", CType(CInt(MsgBoxStyle.Question) + CInt(MsgBoxStyle.YesNo), MsgBoxStyle)) = MsgBoxResult.Yes Then
            Me.Elimina()
        End If
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub

#End Region

#Region "Eventos"
    Private Sub Prpoyecto_siembra_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Inicializa()
        Me.Cambia_Estado(enumEstados.NUEVO)
        Me.CboEjercicio.SelectedValue = Plaza.ID_CON_EJERCICIO
        Me.Grid1.Focus()
    End Sub

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        txtNoBeep(e)
    End Sub

    Private Sub CboEjercicio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboEjercicio.SelectedIndexChanged
        DesplegarElementosGrid()
    End Sub

    Private Sub Grid_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grid1.CellDoubleClick
        AbrirEditorProyecto()
    End Sub

    Private Sub Grid1_KeyDown(sender As Object, e As KeyEventArgs) Handles Grid1.KeyDown
        If e.KeyCode = Keys.Delete Then
            tsbEliminar.PerformClick()
        End If
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If

    End Sub

#End Region

#Region "Métodos y procedimientos"
    Private Sub Cambia_Estado(ByVal pEstado As enumEstados)
        Try
            Me.Estado = pEstado

            Select Case Me.Estado
                Case enumEstados.NUEVO
                    Me.tsbNuevo.Enabled = True
                    Me.CboEjercicio.Enabled = True

                Case enumEstados.GRABADO
                    Me.tsbNuevo.Enabled = True
                    Me.CboEjercicio.Enabled = False

                Case enumEstados.CONSULTA

            End Select
            Application.DoEvents()

        Catch ex As Exception
            HandleError(Me.Name, "Cambia_Estado", ex)
        End Try
    End Sub

    Private Sub Inicializa()
        Try
            Me.Grid1.DataSource = Nothing
            Me.DesplegarEjercicios()
            Me.DesplegarElementosGrid()

        Catch ex As Exception
            HandleError(Me.Name, "Inicializa", ex)
        End Try
    End Sub

    Private Sub DesplegarElementosGrid()
        With Me.Grid1
            .DataSource = Me.oProyectoSiembra.ObtenerElementosGrid(Me.CboEjercicio.SelectedValue.ToString)
            .Columns("ID_PROYECTO").Width = 30
            .Columns("ORDEN").Width = 30
            .Columns("CODIGO_CULTIVO").Width = 30
            .Columns("NOMBRE_CULTIVO").Width = 200
            .Columns("CODIGO_CENTRO_COSTO_ORIGEN").Width = 30
            .Columns("NOMBRE_CENTRO_COSTO_ORIGEN").Width = 190
            .Columns("CODIGO_CENTRO_COSTO").Width = 30
            .Columns("NOMBRE_CENTRO_COSTO").Width = 190
            .Columns("CODIGO_LOTE").Width = 30
            .Columns("NOMBRE_LOTE").Width = 120
            .Columns("HECTAREAS_SEMBRADAS").Width = 65
            .Columns("FECHA_SIEMBRA").Width = 80
            .Columns("FECHA_CORTE").Width = 80
            .Columns("FECHA_FIN_TEMPORADA").Width = 80
        End With
    End Sub

    Private Sub DesplegarEjercicios()
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

    Private Sub AbrirEditorProyecto()
        Dim agregar As Boolean = False
        Dim oProyectoSiembraEdicion As New ProyectoSiembraEdicion(Me.Grid1.CurrentRow.Cells("ID_PROYECTO").Value.ToString, agregar)
        oProyectoSiembraEdicion.ShowDialog()
        oProyectoSiembraEdicion.Dispose()
        Me.DesplegarElementosGrid()
    End Sub

    Private Sub Elimina()
        Dim Eliminado As Boolean = False
        Try
            With oProyectoSiembra
                .ID_PROYECTO = Me.Grid1.CurrentRow.Cells("ID_PROYECTO").Value.ToString

                If .Eliminar Then
                    Eliminado = True
                End If

            End With

            If Eliminado = True Then
                MsgBox("Proyecto eliminado correctamente.", MsgBoxStyle.Information)
                DesplegarElementosGrid()
            End If
        Catch ex As Exception
            HandleError(Me.Name, "Elimina", ex)
        End Try
    End Sub

#End Region
End Class