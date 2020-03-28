
Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class Rpt_CXP_SaldosProveedores
    Private oProveedores As New Class_CatProveedores

#Region "Constructor y destructor"
    Public Sub New()
        InitializeComponent()
        Inicializa()
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

    Private Sub txtTextoKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodicoProveedor.KeyPress
        txtNoBeep(e)
    End Sub

#End Region

#Region "Métodos y procedimientos"

    Private Sub Inicializa()
        Me.RdbGlobalCXP.Checked = True
        Me.txtCodicoProveedor.Focus()
    End Sub

    Private Sub Imprimir()
        Dim FormatoDeReporte As String = ""
        Dim Rpt As ReportDocument
        Rpt = New ReportDocument
        Dim oReporte As Class_Reporte

        Try
            If Me.RdbGlobalCXP.Checked = True Then
                FormatoDeReporte = "RPT_CXP_SALDOS_PROVEEDORES_GLOBAL"
            Else
                FormatoDeReporte = "RPT_CXP_SALDOS_PROVEEDORES_DETALLE"
            End If

            'If Not oReporte.RptCargado Then
            '    Exit Sub
            'End If
            oReporte = New Class_Reporte(FormatoDeReporte, Rpt)

            Rpt.SetParameterValue("@CODIGO_PROVEEDOR", "" & Me.txtCodicoProveedor.Text)

            If Me.RdbDetalleCXP.Checked Then
                Rpt.SetParameterValue("@ORDEN_FOLIO_PROVEEDOR", IIf(Me.rbtProveedor.Checked, "1", "0"))
            Else
                Rpt.SetParameterValue("@ORDEN_FOLIO_PROVEEDOR", "0")
            End If

            Dim frm As New Reporte(Rpt)
            frm.CRViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            frm.Show()
        Catch ex As Exception
            HandleError(Me.Name, "Reporte de cxp", ex)
        Finally
            oReporte = Nothing
        End Try
    End Sub
#End Region

    Private Sub txtCodicoCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodicoProveedor.KeyDown
        Dim sText As String
        Select Case e.KeyCode
            Case Keys.F6
Buscar:
                sText = Me.oProveedores.BusquedaVisual_PorDescripcion
                If txtLEN(sText) = True Then Me.txtCodicoProveedor.Text = sText
            Case Keys.Enter
                If txtLEN(Me.txtCodicoProveedor.Text) = False Then
                    Me.lblNombreProveedor.Text = ""
                    Exit Sub
                End If

                oProveedores = New Class_CatProveedores(Me.txtCodicoProveedor.Text)
                If Me.oProveedores.Existe = False Then
                    Me.lblNombreProveedor.Text = "" : GoTo Buscar : Exit Sub
                End If

                Me.lblNombreProveedor.Text = Me.oProveedores.Nombre_Proveedor
                Me.tsbImprimir.PerformClick()
        End Select
    End Sub

    Private Sub CboDocumentos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Return Then
            Me.tsbImprimir.PerformClick()
        End If
    End Sub

    Private Sub Rdb_CheckedChanged(sender As Object, e As EventArgs) Handles RdbGlobalCXP.CheckedChanged
        If Me.RdbDetalleCXP.Checked Then
            Me.GbOrden.Visible = True
        Else
            Me.GbOrden.Visible = False
        End If
    End Sub

End Class