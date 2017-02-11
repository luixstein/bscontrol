Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class Frm_Contabilidad_Estado_Resultados

#Region "Campos"
#Region "Campos de la tabla"

#End Region
#Region "Campos ligados a la tabla"

#End Region
#Region "Campos públicos"

#End Region
#Region "Campos privados"
    Private Enum enumEstados
        AuxiliarMAyor
    End Enum

    Private Estado As enumEstados
    Private FormatoDeReporte As String
#End Region
#Region "Campos de sistema"

#End Region
#End Region

#Region "Propiedades"

#Region "Propiedades Campos de la tabla"
#End Region

#Region "Propiedades de campos ligados a la tabla"

#End Region

#Region "Propiedades públicos"

#End Region

#Region "Propiedades de campos privados"

#End Region

#Region "Propiedades de campos de sistema"


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
    Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click
        Me.Imprimir()
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub
#End Region

#Region "Métodos y procedimientos"

    Private Sub Cambia_Estado()
        Select Case Me.Estado
            Case enumEstados.AuxiliarMAyor
        End Select
        Application.DoEvents()
    End Sub

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

    Private Sub Imprimir()
        Dim StrFiltros As String = ""
        Dim Rpt As ReportDocument
        Rpt = New ReportDocument
        Dim oReporte As Class_Reporte
        Try
            Dim StrNombre As String

            StrNombre = "RPT_FORMATO_ESTADO_RESULTADOS"

            FormatoDeReporte = StrNombre
            'oReporte = New Class_Reporte(FormatoDeReporte, Rpt, False)
            'If Not oReporte.RptCargado Then
            '    Exit Sub
            'End If
            'Rpt.SetParameterValue("@ID_CON_PERIODO1", FG_Meses(Me.CmbPeriodo1.Text, 0))
            'Rpt.SetParameterValue("@ID_CON_PERIODO2", FG_Meses(Me.CmbPeriodo2.Text, 0))
            Rpt.SetParameterValue("@ID_CON_EJERCICIO", Me.CmbEjercicio.SelectedValue)

            Dim frm As New Reporte(Rpt)
            frm.CRViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            frm.Show()
        Catch ex As Exception
            HandleError(Me.Name, "Reporte de Estado de Resultados", ex)
        Finally
            oReporte = Nothing
        End Try
    End Sub

    Private Function Filtros() As String
        Dim sFiltros As String


        sFiltros = ""
        Filtros = sFiltros

    End Function

    Private Sub Limpiar()
        Me.CmbPeriodo1.Text = FG_Meses(1, 1)
        Me.CmbPeriodo2.Text = FG_Meses(13, 1)
        'Me.CmbEjercicio.SelectedValue = Empresa_Sistema.ID_CON_EJERCICIO
        'Grid.Rows.Clear()
    End Sub
#End Region

#Region "Eventos de objetos"

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
#End Region
End Class


