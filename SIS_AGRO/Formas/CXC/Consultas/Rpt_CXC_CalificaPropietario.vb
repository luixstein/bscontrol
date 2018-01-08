Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class Rpt_CXC_CalificaPropietario
    Private oPropietarios As New Class_CatPropietarios

#Region "Constructor y destructor"
    Public Sub New()
        InitializeComponent()
        Me.Inicializa()
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
#End Region

#Region "Opciones"

    Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click
        Me.Imprimir()
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub
#End Region

#Region "Eventos Genericos"

    Private Sub txtTextoKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigoPropietario.KeyPress, DtFechaDesde.KeyPress, DtFechaHasta.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub txtNumerosEnterosKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        txtSoloNumerosEnteros(e)
        txtNoBeep(e)
    End Sub

    Private Sub txtCodicoPropietario_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigoPropietario.KeyDown
        Dim sText As String
        Select Case e.KeyCode
            Case Keys.F6
Buscar:
                sText = Me.oPropietarios.BusquedaVisual_PorDescripcion
                If txtLEN(sText) = True Then Me.txtCodigoPropietario.Text = sText
            Case Keys.Enter
                If txtLEN(Me.txtCodigoPropietario.Text) = False Then
                    Me.lblNombrePropietario.Text = ""
                    Me.DtFechaDesde.Focus()
                    Exit Sub
                End If

                oPropietarios = New Class_CatPropietarios(Me.txtCodigoPropietario.Text)
                If Me.oPropietarios.Existe = False Then
                    Me.lblNombrePropietario.Text = "" : GoTo Buscar : Exit Sub
                End If

                Me.lblNombrePropietario.Text = Me.oPropietarios.NOMBRE_PROPIETARIO
                Me.DtFechaDesde.Focus()
        End Select
    End Sub

    Private Sub dpFechaInicio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtFechaDesde.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.DtFechaHasta.Focus()
        End If
    End Sub

    Private Sub dpFechaFinal_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtFechaHasta.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.tsbImprimir.PerformClick()
        End If
    End Sub

#End Region

#Region "Métodos y procedimientos"

    Private Sub Inicializa()
        Me.DtFechaDesde.Value = CDate(Format(Date.Now, "01-MM-yyyy"))
        Me.DtFechaHasta.Value = Date.Now
    End Sub

    Private Sub Imprimir()
        Dim StrFiltros As String = ""
        Dim Rpt As New ReportDocument
        Dim oReporte As Class_Reporte
        Try

            If Me.ValidarPeriodo = False Then
                Exit Sub
            End If

            oReporte = New Class_Reporte("RPT_CALIFICA_PROPIETARIO", Rpt)

            If Not oReporte.RptCargado Then
                Exit Sub
            End If

            Rpt.SetParameterValue("@CODIGO_PROPIETARIO", Me.txtCodigoPropietario.Text)
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

    Private Function ValidarPeriodo() As Boolean
        If Me.DtFechaDesde.Value > Me.DtFechaHasta.Value Then
            MsgBox("Rango de fechas inválidas.", MsgBoxStyle.Exclamation, Me.Name)
            Exit Function
        End If
        Return True
    End Function

#End Region

End Class