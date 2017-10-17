Option Strict On

Imports CrystalDecisions.CrystalReports.Engine

Public Class Rpt_Ventas_LotesCostos

    Private oArticulos As New Class_CatArticulos
    Private oClientes As New Class_CatClientes
    Private oProveedores As New Class_CatProveedores

    Private Sub TxtClientes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCliente.KeyDown
        Dim sText As String
        Select Case e.KeyCode
            Case Keys.F6
Buscar:
                sText = Me.oClientes.BusquedaVisual_PorDescripcion
                If txtLEN(sText) = True Then Me.TxtCliente.Text = sText
            Case Keys.Enter
                If txtLEN(Me.TxtCliente.Text) = False Then
                    Me.lblNombreCliente.Text = ""
                    txtTAB(e)
                    Exit Sub
                End If

                Me.oClientes = New Class_CatClientes(Me.TxtCliente.Text)
                If Me.oClientes.Existe = False Then
                    Me.lblNombreCliente.Text = "" : GoTo Buscar : Exit Sub
                End If

                Me.lblNombreCliente.Text = Me.oClientes.NOMBRE_CLIENTE
                txtTAB(e)
        End Select
    End Sub

    Private Sub TxtProveedores_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtProveedor.KeyDown
        Dim sText As String
        Select Case e.KeyCode
            Case Keys.F6
Buscar:
                sText = Me.oProveedores.BusquedaVisual_PorDescripcion
                If txtLEN(sText) = True Then Me.TxtProveedor.Text = sText
            Case Keys.Enter
                If txtLEN(Me.TxtProveedor.Text) = False Then
                    Me.LblNombreProveedor.Text = ""
                    txtTAB(e)
                    Exit Sub
                End If

                Me.oProveedores = New Class_CatProveedores(Me.TxtProveedor.Text)
                If Me.oProveedores.Existe = False Then
                    Me.LblNombreProveedor.Text = "" : GoTo Buscar : Exit Sub
                End If

                Me.LblNombreProveedor.Text = Me.oProveedores.Nombre_Proveedor
                txtTAB(e)
        End Select
    End Sub

    Private Sub TxtFolioCompra_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtFolioCompra.KeyDown
        Dim oCompras As New Class_Compras_Global
        Dim sText As String
        Select Case e.KeyCode
            Case Keys.F6
                sText = oCompras.BusquedaVisual_Compras
                If txtLEN(sText) = True Then Me.TxtFolioCompra.Text = sText
            Case Keys.Enter
                txtTAB(e)
        End Select
    End Sub

    Private Sub TxtFolioVenta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtFolioVenta.KeyDown
        Dim oVentas As New Class_Ventas_Global
        Dim sText As String
        Select Case e.KeyCode
            Case Keys.F6
                sText = oVentas.BusquedaVisual_PorFolio
                If txtLEN(sText) = True Then Me.TxtFolioVenta.Text = sText
            Case Keys.Enter
                txtTAB(e)
        End Select
    End Sub

    Private Sub DtFechaDesde_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtFechaDesde.KeyDown
        txtTAB(e)
    End Sub

    Private Sub DtFechaHasta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtFechaHasta.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.tsbConsultar.PerformClick()
        End If
    End Sub

    Private Sub txtTextoKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFolioCompra.KeyPress, TxtFolioVenta.KeyPress, TxtCliente.KeyPress, TxtProveedor.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub Rpt_Embarques_Empaque_Y_Embarque_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DtFechaDesde.Value = FechaActualINI()
        Me.DtFechaHasta.Value = Date.Now
    End Sub

    Private Sub tsbConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbConsultar.Click
        Consultar()
    End Sub

    Private Sub Consultar()
        Dim FormatoDeReporte As String = ""
        Dim Rpt As ReportDocument
        Rpt = New ReportDocument
        Dim oReporte As Class_Reporte
        Try
            If Me.ValidarPeriodo = False Then
                Exit Sub
            End If

            FormatoDeReporte = "RPT_VENTAS_POR_LOTES_COSTOS"

            oReporte = New Class_Reporte(FormatoDeReporte, Rpt)
            Rpt.SetParameterValue("@FECHA1", Format(Me.DtFechaDesde.Value, "yyyy-dd-MM"))
            Rpt.SetParameterValue("@FECHA2", Format(Me.DtFechaHasta.Value, "yyyy-dd-MM"))
            Rpt.SetParameterValue("@FOLIO_VENTA", Me.TxtFolioVenta.Text)
            Rpt.SetParameterValue("@FOLIO_COMPRA", Me.TxtFolioCompra.Text)
            Rpt.SetParameterValue("@CODIGO_CLIENTE", Me.TxtCliente.Text)
            Rpt.SetParameterValue("@CODIGO_PROVEEDOR", Me.TxtProveedor.Text)

            Dim frm As New Reporte(Rpt)
            frm.CRViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            frm.Show()
        Catch ex As Exception
            HandleError(Me.Name, "Consultar", ex)
        Finally
            oReporte = Nothing
        End Try
    End Sub

    Private Function ValidarPeriodo() As Boolean
        Me.DtFechaDesde.Enabled = False
        Me.DtFechaHasta.Enabled = False
        Me.DtFechaDesde.Enabled = True
        Me.DtFechaHasta.Enabled = True

        If Me.DtFechaDesde.Value > Me.DtFechaHasta.Value Then
            MsgBox("Rango de fechas inválidas.", MsgBoxStyle.Exclamation, Me.Name)
            Me.DtFechaDesde.Focus()
            Exit Function
        End If
        ValidarPeriodo = True
    End Function

    Private Sub TxtCodArticulo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCliente.KeyPress, _
      DtFechaHasta.KeyPress, DtFechaDesde.KeyPress, DtFechaHasta.KeyPress, DtFechaDesde.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
End Class