'Option Strict On

Public Class BusquedaCatalogoProductosServicios

    Public iRows As Integer
    'Public bIsRowSelected As Boolean

    Private Sub CatalogoProductosServicios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Me.CargarDivisiones()
    End Sub

    Private Sub CargarDivisiones()
        Try
            Dim oElementos As New Class_CFD_CatProductosServicios
            With Me.cboNivel1
                .DisplayMember = "NOMBRE_PRODUCTO_SERVICIO"
                .ValueMember = "CODIGO_PRODUCTO_SERVICIO"
                Dim dView As New Data.DataView(oElementos.ObtenerElementosporNivel(Me.cboTipo.Text, 1))
                dView.Sort = "NOMBRE_PRODUCTO_SERVICIO"
                .DataSource = dView
                .SelectedIndex = -1
            End With
        Catch ex As Exception
            HandleError(Me.Name, "CargarDivisiones", ex)
        End Try
    End Sub

    Private Sub CargarGrupos()
        Try
            Dim oElementos As New Class_CFD_CatProductosServicios
            With Me.cboNivel2
                .DisplayMember = "NOMBRE_PRODUCTO_SERVICIO"
                .ValueMember = "CODIGO_PRODUCTO_SERVICIO"
                Dim dView As New Data.DataView(oElementos.ObtenerElementosporNivel(Me.cboTipo.Text, 2, Me.cboNivel1.SelectedValue)) '.ToString))
                dView.Sort = "NOMBRE_PRODUCTO_SERVICIO"
                .DataSource = dView
                .SelectedIndex = -1
            End With
        Catch ex As Exception
            HandleError(Me.Name, "CargarGrupos", ex)
        End Try
    End Sub

    Private Sub CargarClase()
        Try
            Dim oElementos As New Class_CFD_CatProductosServicios
            With Me.cboNivel3
                .DisplayMember = "NOMBRE_PRODUCTO_SERVICIO"
                .ValueMember = "CODIGO_PRODUCTO_SERVICIO"
                Dim dView As New Data.DataView(oElementos.ObtenerElementosporNivel(Me.cboTipo.Text, 3, Me.cboNivel2.SelectedValue)) '.ToString))
                dView.Sort = "NOMBRE_PRODUCTO_SERVICIO"
                .DataSource = dView
                .SelectedIndex = -1
            End With
        Catch ex As Exception
            HandleError(Me.Name, "CargarClase", ex)
        End Try
    End Sub

    Private Sub cboTipo_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboTipo.SelectedValueChanged
        Me.CargarDivisiones()
    End Sub

    Private Sub cboNivel1_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboNivel1.SelectedValueChanged
        Me.CargarGrupos()
    End Sub

    Private Sub cboNivel2_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboNivel2.SelectedValueChanged
        Me.CargarClase()
    End Sub

    Private Sub cboNivel3_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboNivel3.SelectedValueChanged
        Me.Grid.DataSource = ""
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim sCodigo As String
        Dim iNivel As Integer
        If (Me.cboNivel2.Text = "") Then
            sCodigo = Me.cboNivel1.SelectedValue.ToString
            iNivel = 1
        ElseIf (Me.cboNivel3.Text = "") Then
            sCodigo = Me.cboNivel2.SelectedValue.ToString
            iNivel = 2
        Else
            sCodigo = Me.cboNivel3.SelectedValue.ToString
            iNivel = 3
        End If
        Me.CargarValoresGrid(iNivel, sCodigo)
    End Sub

    Private Sub CargarValoresGrid(iNivel As Integer, sCodigo As String)
        Try
            Dim oElementos As New Class_CFD_CatProductosServicios
            With Me.Grid
                '.AutoRedraw = False
                '.DisplayMember = "NOMBRE_PRODUCTO_SERVICIO"
                '.ValueMember = "CODIGO_PRODUCTO_SERVICIO"
                Dim dView As New Data.DataView(oElementos.ObtenerElementospoFiltro(cboTipo.Text, iNivel, sCodigo))
                'dView.Sort = "NOMBRE_PRODUCTO_SERVICIO"
                .DataSource = dView
                iRows = .Rows.Count
                'iRows = dView.Count
                '.SelectedIndex = -1
                '.AutoRedraw = True
                '.Refresh()
            End With
        Catch ex As Exception
            HandleError(Me.Name, "CargarValoresGrid", ex)
        End Try
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        iRows = 0
        Me.Grid.DataSource = ""
    End Sub

    Private Sub Grid_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Grid.MouseDoubleClick
        Me.Close()
    End Sub

    Private Sub Grid_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles Grid.DataBindingComplete
        Me.Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        'Me.Grid.Refresh()
    End Sub

End Class