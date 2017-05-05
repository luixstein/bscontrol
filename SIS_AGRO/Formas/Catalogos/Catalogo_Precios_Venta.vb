Option Strict On

Public Class Catalogo_Precios_Venta
    Private oPrecios As New Class_CatPreciosVenta
    Private Running As Boolean = False

#Region "Columnas grid"
    Private igyCodigo As Short = 1
    Private igyDescripcion As Short = 2
    Private igyPrecio1 As Short = 3
    Private igyPrecio2 As Short = 4
    Private igyPrecio3 As Short = 5
    Private igyPrecio4 As Short = 6
    Private igyPrecio5 As Short = 7
#End Region

#Region "Eventos de objetos"
#Region "Eventos"
    Private Sub Catalogo_Precios_Venta_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.DesplegarLineas()
        Me.DesplegarFamilias()
        Me.Inicializa()
        Me.Running = True
    End Sub

    Private Sub TxtCodArticulo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigoArticulo.KeyDown
        Dim oArticulos As Class_CatArticulos
        Select Case e.KeyCode
            Case Keys.F6
buscar:
                oArticulos = New Class_CatArticulos
                Dim sArticulo As String = oArticulos.BusquedaVisual_PorDescripcion
                If txtLEN(sArticulo) = True Then
                    Me.txtCodigoArticulo.Text = sArticulo
                    Me.lblArticulo.Text = oArticulos.BuscarNombreArticulo(sArticulo)
                End If
            Case Keys.Enter
                If txtLEN(Me.txtCodigoArticulo.Text) = False Then
                    Me.lblArticulo.Text = ""
                    GoTo buscar : Exit Sub
                End If
                oArticulos = New Class_CatArticulos
                Me.lblArticulo.Text = oArticulos.BuscarNombreArticulo(Me.txtCodigoArticulo.Text)
                If txtLEN(Me.lblArticulo.Text) = False Then
                    'MsgBox("El articulo no existe.", MsgBoxStyle.Exclamation, Me.Text)
                    'Me.lblArticulo.Text = ""
                    'GoTo buscar
                    Exit Sub
                Else
                    txtTAB(e)
                End If
        End Select
    End Sub

    Private Sub txtCodigoArticulo_TextChanged(sender As Object, e As EventArgs) Handles txtCodigoArticulo.TextChanged
        Me.DesplegarElementos()
    End Sub

    Private Sub cboFamilia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFamilia.SelectedIndexChanged
        Me.DesplegarElementos()
    End Sub

    Private Sub cboLinea_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboLinea.SelectedIndexChanged
        Me.DesplegarElementos()
    End Sub

    Private Sub Grid_KeyDown(Sender As Object, e As KeyEventArgs) Handles Grid.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.Grabar()
        End If
    End Sub
#End Region

#Region "Eventos Genericos"
    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigoArticulo.KeyPress, cboLinea.KeyPress, cboFamilia.KeyPress
        txtNoBeep(e)
    End Sub
#End Region

#End Region

#Region "Opciones"
    Private Sub tsbNuevo_Click(sender As Object, e As EventArgs) Handles tsbNuevo.Click
        Me.Inicializa()
        Me.txtCodigoArticulo.Focus()
    End Sub

    Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
        Me.Imprimir()
    End Sub

    Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub
#End Region

#Region "Métodos y procedimientos"
    Private Sub Inicializa()
        Try
            Me.txtCodigoArticulo.Text = ""
            Me.lblArticulo.Text = ""
            Me.cboLinea.SelectedValue = "T"
            Me.cboFamilia.SelectedValue = "T"
        Catch ex As Exception
            HandleError(Me.Name, "Inicializa", ex)
        End Try
    End Sub

    Private Sub FormateaGrid()
        Try
            Me.Grid.Column(Me.igyCodigo).Locked = True
            Me.Grid.Column(Me.igyDescripcion).Locked = True

            Me.Grid.Cell(0, Me.igyCodigo).Text = "Código"
            Me.Grid.Cell(0, Me.igyDescripcion).Text = "Descripción"
            Me.Grid.Cell(0, Me.igyPrecio1).Text = "Precio1"
            Me.Grid.Cell(0, Me.igyPrecio2).Text = "Precio2"
            Me.Grid.Cell(0, Me.igyPrecio3).Text = "Precio3"
            Me.Grid.Cell(0, Me.igyPrecio4).Text = "Precio4"
            Me.Grid.Cell(0, Me.igyPrecio5).Text = "Precio5"

            Me.Grid.Column(Me.igyCodigo).Width = 100
            Me.Grid.Column(Me.igyDescripcion).Width = 290
            Me.Grid.Column(Me.igyPrecio1).Width = 80
            Me.Grid.Column(Me.igyPrecio2).Width = 80
            Me.Grid.Column(Me.igyPrecio3).Width = 80
            Me.Grid.Column(Me.igyPrecio4).Width = 80
            Me.Grid.Column(Me.igyPrecio5).Width = 80

            Me.Grid.Row(Me.Grid.Rows - 1).Locked = True
        Catch ex As Exception
            HandleError(Me.Name, "FormateaGrid", ex)
        End Try
    End Sub

    Private Sub Imprimir()
        '
    End Sub

    Private Sub DesplegarLineas()
        Try
            Dim oElementos As New Class_CatLineas
            With Me.cboLinea
                .DisplayMember = "NOMBRE_LINEA"
                .ValueMember = "CODIGO_LINEA"
                Dim dView As New Data.DataView(oElementos.ObtenerElementosParaReportes)
                dView.Sort = "NOMBRE_LINEA"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedIndex = 0
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarLineas", ex)
        End Try
    End Sub

    Private Sub DesplegarFamilias()
        Try
            Dim oElementos As New Class_CatFamilias
            With Me.cboFamilia
                .DisplayMember = "NOMBRE_FAMILIA"
                .ValueMember = "CODIGO_FAMILIA"
                Dim dView As New Data.DataView(oElementos.ObtenerElementosParaReportes)
                dView.Sort = "NOMBRE_FAMILIA"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedIndex = 0
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarFamilias", ex)
        End Try
    End Sub

    Private Function DesplegarElementos() As Boolean
        Try
            If Me.Running = True Then
                Me.Grid.AutoRedraw = False
                Me.Grid.DataSource = Me.oPrecios.ObtenerElementos(Me.txtCodigoArticulo.Text, Me.cboLinea.SelectedValue.ToString, Me.cboFamilia.SelectedValue.ToString)
                Me.FormateaGrid()
            End If
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarElementos", ex)
        Finally
            Me.Grid.AutoRedraw = True
            Me.Grid.Refresh()
        End Try
    End Function

    Private Function Grabar() As Boolean
        Dim bResultado As Boolean = False
        Dim sArticulo As String = "", Renglon As Integer = 0, Columna As Integer = 0
        Try
            Columna = Me.Grid.Selection.FirstCol
            Renglon = Me.Grid.Selection.FirstRow
            sArticulo = Me.Grid.Cell(Renglon, Me.igyCodigo).Text

            If Not (Columna = igyPrecio1 Or Columna = igyPrecio2 Or Columna = igyPrecio3 Or Columna = igyPrecio4 Or Columna = igyPrecio5) Then
                Return False
            End If

            If Renglon < 1 Or txtLEN(sArticulo) = False Then
                MsgBox("Seleccione un artículo por favor.", MsgBoxStyle.Exclamation, Me.Text)
                Return False
            End If

            Me.oPrecios = New Class_CatPreciosVenta(sArticulo)
            Me.oPrecios.PRECIO1 = valorNumerico(Me.Grid.Cell(Renglon, Me.igyPrecio1).Text)
            Me.oPrecios.PRECIO2 = valorNumerico(Me.Grid.Cell(Renglon, Me.igyPrecio2).Text)
            Me.oPrecios.PRECIO3 = valorNumerico(Me.Grid.Cell(Renglon, Me.igyPrecio3).Text)
            Me.oPrecios.PRECIO4 = valorNumerico(Me.Grid.Cell(Renglon, Me.igyPrecio4).Text)
            Me.oPrecios.PRECIO5 = valorNumerico(Me.Grid.Cell(Renglon, Me.igyPrecio5).Text)
            Me.oPrecios.GrabarCambioPrecio()
            bResultado = True
        Catch ex As Exception
            HandleError(Me.Name, "Grabar", ex)
        End Try
        Return bResultado
    End Function

#End Region

End Class