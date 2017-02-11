Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class Contabilidad_Periodos

#Region "Constructor y destructor"
    Public Sub New()
        InitializeComponent()
        DesplegarEjercicios()
        'EmpresaParametros = New Class_SisContabilidadParametros
        Inicializa()
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
#End Region

#Region "Opciones"
    Private Sub tsbEjecutar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbEjecutar.Click
        Dim validaPass As New Frm_Contraseña_Cambio_Periodo
        validaPass.ShowDialog()
        validaPass.Dispose()
        If validaPass.bContraseñaValida = True Then
            Ejecutar()
        End If
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub
#End Region

#Region "Métodos y procedimientos"

    Private Sub Inicializa()
        Me.CmbEjercicio.SelectedValue = Plaza.ID_CON_EJERCICIO
        Me.DtFechaDesde.Value = Plaza.FECHA_INICIO
        Me.DtFechaHasta.Value = Plaza.FECHA_FINAL
    End Sub

    Private Function Ejecutar() As Boolean

        'If MsgBox("Desea grabar el ejercicio y periodo seleccionados ?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "Parametros de contabilidad") = MsgBoxResult.Yes Then
        EmpresaParametros = New Class_SisContabilidadParametros

        Try
            If ValidarPeriodo() = True Then
                Plaza.ID_CON_EJERCICIO = CInt(Me.CmbEjercicio.SelectedValue)
                Plaza.FECHA_INICIO = CDate(Format(Me.DtFechaDesde.Value, "yyyy-MM-dd 00:00:00"))
                Plaza.FECHA_FINAL = CDate(Format(Me.DtFechaHasta.Value, "yyyy-MM-dd 23:59:59"))
                Plaza.ActualizaNombreEjercicio()

                'Permanente
                If Me.Rdb2.Checked = True Then
                    If Plaza.ActualizaFechas() Then
                        MsgBox("Periodo de trabajo contable cambiado con éxito.", MsgBoxStyle.Information, "Parametros de Contabilidad")
                    End If
                End If
                EstableceDescripcionMenu()
                Me.Close()
            End If
        Catch ex As Exception
            HandleError(Me.Name, "Ejecutar", ex)
        End Try
        'End If

    End Function

    Private Function ValidarPeriodo() As Boolean
        If Me.DtFechaDesde.Value > Me.DtFechaHasta.Value Then
            MsgBox("Rango de fechas inválidas.", MsgBoxStyle.Exclamation, Me.Name)
            Exit Function
        End If
        Dim ValidaPeriodo As New Class_find("SELECT 1 FROM CON_EJERCICIOS WHERE (('" & Format(Me.DtFechaDesde.Value, "yyyy-dd-MM") & "' BETWEEN FECHA_INICIO AND FECHA_FINAL)) AND (('" & Format(Me.DtFechaHasta.Value, "yyyy-dd-MM") & "' BETWEEN FECHA_INICIO AND FECHA_FINAL)) AND ID_CON_EJERCICIO=" & Me.CmbEjercicio.SelectedValue.ToString)
        If ValidaPeriodo.Result1.Length <= 0 Then
            MsgBox("El rango especificado esta fuera del rango del ejercicio.", MsgBoxStyle.Exclamation, Me.Name)
            Exit Function
        End If
        ValidarPeriodo = True
    End Function

    Private Sub DesplegarEjercicios()
        Dim oElementos As New Class_Contabilidad_Ejercicios
        With Me.CmbEjercicio
            .DisplayMember = "NOMBRE_EJERCICIO"
            .ValueMember = "ID_CON_EJERCICIO"
            Dim dView As New Data.DataView(oElementos.ObtenerEjercicios)
            ' dView.Sort = "NOMBRE_EJERCICIO"
            .DataSource = dView
            If dView.Count > 0 Then
                .SelectedIndex = 0
            End If
        End With
    End Sub

    Private Sub CmbEjercicio_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbEjercicio.SelectedIndexChanged
        Dim sql As Class_find
        sql = New Class_find("SELECT FECHA_INICIO,FECHA_FINAL FROM CON_EJERCICIOS WHERE ID_CON_EJERCICIO=" & Me.CmbEjercicio.SelectedValue.ToString)
        Me.DtFechaDesde.Value = CDate(sql.Result1)
        Me.DtFechaHasta.Value = CDate(sql.Result2)
        ' Me.CmbEjercicio.SelectedValue = EmpresaParametros.ID_CON_EJERCICIO
    End Sub

    Private Sub DtFechaHasta_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtFechaHasta.ValueChanged
        Dim sql As Class_find
        sql = New Class_find("SELECT FECHA_INICIO,FECHA_FINAL FROM CON_EJERCICIOS WHERE ID_CON_EJERCICIO='" & Me.CmbEjercicio.SelectedValue.ToString & "'")
        If Me.DtFechaHasta.Value < CDate(sql.Result1) Then
            Me.DtFechaHasta.Value = CDate(sql.Result1)
        End If
        If Me.DtFechaHasta.Value > CDate(sql.Result2) Then
            Me.DtFechaHasta.Value = CDate(sql.Result2)
        End If
    End Sub

    Private Sub DtFechaDesde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtFechaDesde.ValueChanged
        Dim sql As Class_find
        sql = New Class_find("SELECT FECHA_INICIO,FECHA_FINAL FROM CON_EJERCICIOS WHERE ID_CON_EJERCICIO='" & Me.CmbEjercicio.SelectedValue.ToString & "'")
        If Me.DtFechaDesde.Value < CDate(sql.Result1) Then
            Me.DtFechaDesde.Value = CDate(sql.Result1)
        End If
        If Me.DtFechaDesde.Value > CDate(sql.Result2) Then
            Me.DtFechaDesde.Value = CDate(sql.Result2)
        End If
    End Sub

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
    Private Sub chk_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Return Then
            Me.tsbEjecutar.PerformClick()
        End If
    End Sub
#End Region

End Class



