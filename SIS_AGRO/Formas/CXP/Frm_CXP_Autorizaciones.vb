Option Strict On
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient

Public Class Frm_CXP_Autorizaciones
    Private dt As New DataTable

    Private oCompras As New Class_Compras_Global

    Private iGyCodigoProveedor As Integer = 1
    Private iGyProveedorNombre As Integer = 2
    Private iGyTotal As Integer = 3
    Private iGySaldo As Integer = 4
    Private iGyPagar As Integer = 5

    Private _iRenglonSeleccionado As Integer
    Private _CODIGO_PROVEEDOR As String

#Region "Propiedades"
    Public Property CODIGO_PROVEEDOR() As String
        Get
            Return _CODIGO_PROVEEDOR
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_PROVEEDOR = Value
        End Set
    End Property
    Public Property iRenglonSeleccionado() As Integer
        Get
            Return _iRenglonSeleccionado
        End Get
        Set(ByVal Value As Integer)
            Me._iRenglonSeleccionado = Value
        End Set
    End Property

#End Region

    Private Sub InicializaGrid()
        Me.Grid1.DataSource = Nothing
        FG_Grid_Limpiar(Grid1)

        'Creamos el Grid
        Me.Grid1.Rows = 2
        Me.Grid1.Cols = 6
        Me.Grid1.DisplayRowNumber = True

        Me.FormateaGrid()
    End Sub

    Public Function SiguienteProveedor() As String
        Dim sResultado As String = ""
        Try
            sResultado = ""
        Catch ex As Exception
            HandleError(Me.Name, "SiguienteProveedor", ex)
        End Try
        Return sResultado
    End Function

    Private Sub Frm_CXP_Autorizaciones_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.txtAutorizado.Text = "0"
        Me.txtTotal.Text = "0"
        Me.txtSaldo.Text = "0"

        Me.consultar()
        Me.totales()
    End Sub

    Private Function consultar() As Boolean
        Dim dTabla As DataTable
        Try
            dTabla = oCompras.CargaComprashechas("", "T", "", "1")

            'Me.Grid1.DataSource = Nothing
            'dTabla = oCompras.CargaComprashechas(Me.txtCodigoProveedor.Text, Me.cboTipoGasto.SelectedValue.ToString, Me.CboAlmacen.SelectedValue.ToString)
            'Me.Grid1.Rows = 1
            'For Each dRow As DataRow In dTabla.Rows
            '    Me.Grid1.AddItem(dRow(0).ToString & Chr(9) & dRow(1).ToString & Chr(9) & dRow(2).ToString & Chr(9) & dRow(3).ToString & Chr(9) & dRow(4).ToString & Chr(9) & dRow(5).ToString & Chr(9))
            'Next

            dt = New DataTable
            dt = dTabla

            Me.InicializaGrid()

            If dTabla.Rows.Count > 0 Then
                Me.LlenaGrid()
            End If

            If dTabla.Rows.Count > 0 Then
                Me.Grid1.Cell(dTabla.Rows.Count, iGyCodigoProveedor).SetFocus()
            End If

            Me.FormateaGrid()

        Catch ex As Exception
            HandleError(Me.Name, "CargaComprasConSaldo", ex)
        End Try
    End Function

    Private Sub FormateaGrid()
        Me.Grid1.Column(Me.iGyCodigoProveedor).Width = 100
        Me.Grid1.Column(Me.iGyProveedorNombre).Width = 330
        Me.Grid1.Column(Me.iGyTotal).Width = 100
        Me.Grid1.Column(Me.iGySaldo).Width = 100
        Me.Grid1.Column(Me.iGyPagar).Width = 100

        Me.Grid1.Cell(0, Me.iGyCodigoProveedor).Text = "Cód. Prov."
        Me.Grid1.Cell(0, Me.iGyProveedorNombre).Text = "Nombre proveedor"
        Me.Grid1.Cell(0, Me.iGyTotal).Text = "Total"
        Me.Grid1.Cell(0, Me.iGySaldo).Text = "Saldo"
        Me.Grid1.Cell(0, Me.iGyPagar).Text = "Autorizado"

        Me.Grid1.Column(Me.iGyTotal).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
        Me.Grid1.Column(Me.iGyTotal).Mask = FlexCell.MaskEnum.Numeric
        Me.Grid1.Column(Me.iGyTotal).DecimalLength = 2
        Me.Grid1.Column(Me.iGyTotal).Alignment = FlexCell.AlignmentEnum.RightCenter

        Me.Grid1.Column(Me.iGySaldo).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
        Me.Grid1.Column(Me.iGySaldo).Mask = FlexCell.MaskEnum.Numeric
        Me.Grid1.Column(Me.iGySaldo).DecimalLength = 2
        Me.Grid1.Column(Me.iGySaldo).Alignment = FlexCell.AlignmentEnum.RightCenter

        Me.Grid1.Column(Me.iGyPagar).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
        Me.Grid1.Column(Me.iGyPagar).Mask = FlexCell.MaskEnum.Numeric
        Me.Grid1.Column(Me.iGyPagar).DecimalLength = 2
        Me.Grid1.Column(Me.iGyPagar).Alignment = FlexCell.AlignmentEnum.RightCenter

        Me.Grid1.Refresh()

        Me.Grid1.Column(Me.iGyCodigoProveedor).Locked = True
        Me.Grid1.Column(Me.iGyProveedorNombre).Locked = True
        Me.Grid1.Column(Me.iGyTotal).Locked = True
        Me.Grid1.Column(Me.iGySaldo).Locked = True
        Me.Grid1.Column(Me.iGyPagar).Locked = False
    End Sub

    Private Sub LlenaGrid()
        'Grid1.Rows = 1
        'Grid1.Cols = 6
        Grid1.Rows = Me.dt.Rows.Count + 1

        Grid1.Row(0).Visible = True
   
        Grid1.SelectionMode = FlexCell.SelectionModeEnum.ByCell
        Grid1.DisplayFocusRect = False
        Grid1.ExtendLastCol = False
        Grid1.LockButton = True
        Grid1.ReadonlyFocusRect = FlexCell.FocusRectEnum.Solid
        Grid1.BorderStyle = FlexCell.BorderStyleEnum.Light3D
        Grid1.ScrollBars = FlexCell.ScrollBarsEnum.Vertical
        Grid1.BackColorBkg = SystemColors.Control
        Grid1.DefaultFont = New Font("Tahoma", 8)


        Dim j As Integer = 1
        For Each dRow As DataRow In dt.Rows
            Me.Grid1.Cell(j, Me.iGyCodigoProveedor).Text = dRow("CODIGO_PROVEEDOR").ToString
            Me.Grid1.Cell(j, Me.iGyProveedorNombre).Text = dRow("NOMBRE_PROVEEDOR").ToString
            Me.Grid1.Cell(j, Me.iGyTotal).Text = dRow("TOTAL").ToString
            Me.Grid1.Cell(j, Me.iGySaldo).Text = dRow("SALDO").ToString
            Me.Grid1.Cell(j, Me.iGyPagar).Text = dRow("PAGAR").ToString

            j += 1
        Next

        'Refresh
        Grid1.AutoRedraw = True
        Grid1.Refresh()
    End Sub

    Private Sub totales()
        Me.txtTotal.Text = FormatImporteContable(FG_Grid_SumaCol(Me.Grid1, CShort(Me.iGyTotal)))
        Me.txtSaldo.Text = FormatImporteContable(FG_Grid_SumaCol(Me.Grid1, CShort(Me.iGySaldo)))
        Me.txtAutorizado.Text = FormatImporteContable(FG_Grid_SumaCol(Me.Grid1, CShort(Me.iGyPagar)))
    End Sub

    Private Sub btnRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefrescar.Click
        Me.InicializaGrid()
        Me.consultar()
        Me.totales()
    End Sub

    Private Sub Grid1_Click(ByVal Sender As Object, ByVal e As System.EventArgs) Handles Grid1.Click
        Dim Renglon As Integer

        'Provedor = Me.Grid1.Cell(Renglon, Me.iGyCodigoProveedor).Text
        Renglon = Me.Grid1.ActiveCell.Row()
        iRenglonSeleccionado = Renglon
        'If Me.Grid1.Cell(Renglon, Me.iGyCodigoProveedor).Text <> "" Then
        '    Me._CODIGO_PROVEEDOR = Me.Grid1.Cell(Renglon, Me.iGyCodigoProveedor).Text
        'End If

    End Sub

    Private Sub btnSeleccionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSeleccionar.Click

        If txtLEN(Me.Grid1.Cell(iRenglonSeleccionado, Me.iGyCodigoProveedor).Text) = True Then
            Me._CODIGO_PROVEEDOR = Me.Grid1.Cell(iRenglonSeleccionado, Me.iGyCodigoProveedor).Text
        End If
        Me.Visible = False
    End Sub

    Private Sub btnRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegresar.Click
        Me._CODIGO_PROVEEDOR = ""
        Me.Visible = False
    End Sub
End Class