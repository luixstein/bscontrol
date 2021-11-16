Option Strict On

Public Class Catalogo_Precios_Venta
    Private oPrecios As New Class_CatPreciosVenta
    Private Running As Boolean = False

#Region "Columnas grid"
    Private igyCodigo As Short = 1
    Private igyDescripcion As Short = 2
    Private igyMargenUtilidad As Short = 3
    Private igyIEPSPtje As Short = 4
    Private igyPrecio1 As Short = 5
    Private igyPrecio1Ieps As Short = 6
    Private igyPrecio2 As Short = 7
    Private igyPrecio2Ieps As Short = 8
    Private igyPrecio3 As Short = 9
    Private igyPrecio3Ieps As Short = 10
    Private igyPrecio4 As Short = 11
    Private igyPrecio4Ieps As Short = 12
    Private igyPrecio5 As Short = 13
    Private igyPrecio5Ieps As Short = 14

#End Region

#Region "Eventos de objetos"
#Region "Eventos"
    Private Sub Catalogo_Precios_Venta_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.DesplegarLineas()
        Me.DesplegarFamilias()
        Me.DesplegarPlazas()
        Me.DesplegarAlmacenes()
        Me.Inicializa()

        If Empresa_Sistema.PRECIOS_VENTA_POR_ALMACEN = False Then
            Me.CboAlmacen.Visible = False
            Me.lblDisplayAlmacen.Visible = False
        End If

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

    Private Sub cboPlaza_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPlaza.SelectedIndexChanged
        Me.DesplegarElementos()
    End Sub

    Private Sub cboAlmacen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboAlmacen.SelectedIndexChanged
        Me.DesplegarElementos()
    End Sub

    Private Sub Grid_KeyDown(Sender As Object, e As KeyEventArgs) Handles Grid.KeyDown
        Dim Renglon As Integer = Me.Grid.Selection.FirstRow
        Dim Columna As Integer = Me.Grid.Selection.FirstCol
        If e.KeyCode = Keys.Return Then
            Me.Grabar()
            Me.Grid.Cell(Renglon, Me.igyPrecio1Ieps).Text = (valorNumericoD(Me.Grid.Cell(Renglon, Me.igyPrecio1).Text) * (1 + (valorNumericoD(Me.Grid.Cell(Renglon, Me.igyIEPSPtje).Text) / 100))).ToString
            Me.Grid.Cell(Renglon, Me.igyPrecio2Ieps).Text = (valorNumericoD(Me.Grid.Cell(Renglon, Me.igyPrecio2).Text) * (1 + (valorNumericoD(Me.Grid.Cell(Renglon, Me.igyIEPSPtje).Text) / 100))).ToString
            Me.Grid.Cell(Renglon, Me.igyPrecio3Ieps).Text = (valorNumericoD(Me.Grid.Cell(Renglon, Me.igyPrecio3).Text) * (1 + (valorNumericoD(Me.Grid.Cell(Renglon, Me.igyIEPSPtje).Text) / 100))).ToString
            Me.Grid.Cell(Renglon, Me.igyPrecio4Ieps).Text = (valorNumericoD(Me.Grid.Cell(Renglon, Me.igyPrecio4).Text) * (1 + (valorNumericoD(Me.Grid.Cell(Renglon, Me.igyIEPSPtje).Text) / 100))).ToString
            Me.Grid.Cell(Renglon, Me.igyPrecio5Ieps).Text = (valorNumericoD(Me.Grid.Cell(Renglon, Me.igyPrecio5).Text) * (1 + (valorNumericoD(Me.Grid.Cell(Renglon, Me.igyIEPSPtje).Text) / 100))).ToString
        End If
    End Sub
#End Region

#Region "Eventos Genericos"
    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigoArticulo.KeyPress, cboLinea.KeyPress, cboFamilia.KeyPress, cboPlaza.KeyPress
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
            Me.cboPlaza.SelectedValue = Plaza.CODIGO_PLAZA
        Catch ex As Exception
            HandleError(Me.Name, "Inicializa", ex)
        End Try
    End Sub

    Private Sub FormateaGrid()
        Try
            Me.Grid.Cell(0, Me.igyCodigo).Text = "Código"
            Me.Grid.Cell(0, Me.igyDescripcion).Text = "Descripción"
            Me.Grid.Cell(0, Me.igyMargenUtilidad).Text = "% Utilidad min."
            Me.Grid.Cell(0, Me.igyIEPSPtje).Text = "ieps%"
            Me.Grid.Cell(0, Me.igyPrecio1).Text = "1"
            Me.Grid.Cell(0, Me.igyPrecio1Ieps).Text = "1 c/ieps"
            Me.Grid.Cell(0, Me.igyPrecio2).Text = "2"
            Me.Grid.Cell(0, Me.igyPrecio2Ieps).Text = "2 c/ieps"
            Me.Grid.Cell(0, Me.igyPrecio3).Text = "3"
            Me.Grid.Cell(0, Me.igyPrecio3Ieps).Text = "3 c/ieps"
            Me.Grid.Cell(0, Me.igyPrecio4).Text = "4"
            Me.Grid.Cell(0, Me.igyPrecio4Ieps).Text = "4 c/ieps"
            Me.Grid.Cell(0, Me.igyPrecio5).Text = "5"
            Me.Grid.Cell(0, Me.igyPrecio5Ieps).Text = "5 c/ieps"

            Me.Grid.Column(Me.igyCodigo).Width = 70
            Me.Grid.Column(Me.igyDescripcion).Width = 280
            Me.Grid.Column(Me.igyMargenUtilidad).Width = 75
            Me.Grid.Column(Me.igyIEPSPtje).Width = 40
            Me.Grid.Column(Me.igyPrecio1).Width = 75
            Me.Grid.Column(Me.igyPrecio2).Width = 75
            Me.Grid.Column(Me.igyPrecio3).Width = 75
            Me.Grid.Column(Me.igyPrecio4).Width = 75
            Me.Grid.Column(Me.igyPrecio5).Width = 75
            Me.Grid.Column(Me.igyPrecio1Ieps).Width = 75
            Me.Grid.Column(Me.igyPrecio2Ieps).Width = 75
            Me.Grid.Column(Me.igyPrecio3Ieps).Width = 75
            Me.Grid.Column(Me.igyPrecio4Ieps).Width = 75
            Me.Grid.Column(Me.igyPrecio5Ieps).Width = 75

            Me.Grid.Column(Me.igyPrecio1).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_PRECIO)
            Me.Grid.Column(Me.igyPrecio1).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.igyPrecio1).DecimalLength = Empresa_Sistema.DECIMALES_PRECIO
            Me.Grid.Column(Me.igyPrecio1).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.igyPrecio1Ieps).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_PRECIO)
            Me.Grid.Column(Me.igyPrecio1Ieps).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.igyPrecio1Ieps).DecimalLength = Empresa_Sistema.DECIMALES_PRECIO
            Me.Grid.Column(Me.igyPrecio1Ieps).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.igyPrecio2).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_PRECIO)
            Me.Grid.Column(Me.igyPrecio2).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.igyPrecio2).DecimalLength = Empresa_Sistema.DECIMALES_PRECIO
            Me.Grid.Column(Me.igyPrecio2).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.igyPrecio2Ieps).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_PRECIO)
            Me.Grid.Column(Me.igyPrecio2Ieps).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.igyPrecio2Ieps).DecimalLength = Empresa_Sistema.DECIMALES_PRECIO
            Me.Grid.Column(Me.igyPrecio2Ieps).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.igyPrecio3).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_PRECIO)
            Me.Grid.Column(Me.igyPrecio3).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.igyPrecio3).DecimalLength = Empresa_Sistema.DECIMALES_PRECIO
            Me.Grid.Column(Me.igyPrecio3).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.igyPrecio3Ieps).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_PRECIO)
            Me.Grid.Column(Me.igyPrecio3Ieps).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.igyPrecio3Ieps).DecimalLength = Empresa_Sistema.DECIMALES_PRECIO
            Me.Grid.Column(Me.igyPrecio3Ieps).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.igyPrecio4).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_PRECIO)
            Me.Grid.Column(Me.igyPrecio4).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.igyPrecio4).DecimalLength = Empresa_Sistema.DECIMALES_PRECIO
            Me.Grid.Column(Me.igyPrecio4).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.igyPrecio4Ieps).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_PRECIO)
            Me.Grid.Column(Me.igyPrecio4Ieps).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.igyPrecio4Ieps).DecimalLength = Empresa_Sistema.DECIMALES_PRECIO
            Me.Grid.Column(Me.igyPrecio4Ieps).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.igyPrecio5).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_PRECIO)
            Me.Grid.Column(Me.igyPrecio5).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.igyPrecio5).DecimalLength = Empresa_Sistema.DECIMALES_PRECIO
            Me.Grid.Column(Me.igyPrecio5).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.igyPrecio5Ieps).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_PRECIO)
            Me.Grid.Column(Me.igyPrecio5Ieps).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.igyPrecio5Ieps).DecimalLength = Empresa_Sistema.DECIMALES_PRECIO
            Me.Grid.Column(Me.igyPrecio5Ieps).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.igyMargenUtilidad).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.igyMargenUtilidad).DecimalLength = 2
            Me.Grid.Column(Me.igyMargenUtilidad).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.igyCodigo).Locked = True
            Me.Grid.Column(Me.igyDescripcion).Locked = True
            Me.Grid.Column(Me.igyIEPSPtje).Locked = True
            Me.Grid.Column(Me.igyPrecio1Ieps).Locked = True
            Me.Grid.Column(Me.igyPrecio2Ieps).Locked = True
            Me.Grid.Column(Me.igyPrecio3Ieps).Locked = True
            Me.Grid.Column(Me.igyPrecio4Ieps).Locked = True
            Me.Grid.Column(Me.igyPrecio5Ieps).Locked = True

            Me.Grid.Row(Me.Grid.Rows - 1).Locked = True
        Catch ex As Exception
            HandleError(Me.Name, "FormateaGrid", ex)
        End Try
    End Sub

    Private Sub Imprimir()
        oPrecios.Imprimir_Listado()
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

    Private Sub DesplegarPlazas()
        Try
            Dim oElementos As New Class_SisPlazas
            With Me.cboPlaza
                .DisplayMember = "NOMBRE_PLAZA"
                .ValueMember = "CODIGO_PLAZA"
                Dim dView As New Data.DataView(oElementos.ObtenerElementos)
                dView.Sort = "NOMBRE_PLAZA"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedValue = Plaza.CODIGO_PLAZA
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarPlazas", ex)
        End Try
    End Sub

    Private Sub DesplegarAlmacenes()
        Try
            Dim oAlmacenes As New Class_CatAlmacenes
            With Me.CboAlmacen
                .DisplayMember = "NOMBRE_ALMACEN"
                .ValueMember = "CODIGO_ALMACEN"
                Dim dView As New Data.DataView(oAlmacenes.ObtenerAlmacenes)
                dView.Sort = "NOMBRE_ALMACEN"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedValue = Plaza.CODIGO_ALMACEN_PRINCIPAL 'Usuario.Codigo_Almacen
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarAlmacenes", ex)
        End Try
    End Sub

    Private Function DesplegarElementos() As Boolean
        Try
            If Me.Running = True Then
                Me.Grid.AutoRedraw = False
                Me.Grid.DataSource = Me.oPrecios.ObtenerElementos(Me.txtCodigoArticulo.Text, Me.cboLinea.SelectedValue.ToString, Me.cboFamilia.SelectedValue.ToString, CInt(Me.cboPlaza.SelectedValue), Me.CboAlmacen.SelectedValue.ToString)
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

            If Not (Columna = igyPrecio1 Or Columna = igyPrecio2 Or Columna = igyPrecio3 Or Columna = igyPrecio4 Or Columna = igyPrecio5 Or Columna = igyMargenUtilidad) Then
                Return False
            End If

            If Renglon < 1 Or txtLEN(sArticulo) = False Then
                MsgBox("Seleccione un artículo por favor.", MsgBoxStyle.Exclamation, Me.Text)
                Return False
            End If

            If Me.ValidaPrecios(Renglon) = False Then
                Return False
            End If

            Me.oPrecios = New Class_CatPreciosVenta(sArticulo, CInt(Me.cboPlaza.SelectedValue))
            Me.oPrecios.PRECIO1 = valorNumericoD(Me.Grid.Cell(Renglon, Me.igyPrecio1).Text)
            Me.oPrecios.PRECIO2 = valorNumericoD(Me.Grid.Cell(Renglon, Me.igyPrecio2).Text)
            Me.oPrecios.PRECIO3 = valorNumericoD(Me.Grid.Cell(Renglon, Me.igyPrecio3).Text)
            Me.oPrecios.PRECIO4 = valorNumericoD(Me.Grid.Cell(Renglon, Me.igyPrecio4).Text)
            Me.oPrecios.PRECIO5 = valorNumericoD(Me.Grid.Cell(Renglon, Me.igyPrecio5).Text)
            Me.oPrecios.PORCENTAJE_MARGEN_UTILIDAD = valorNumericoD(Me.Grid.Cell(Renglon, Me.igyMargenUtilidad).Text)
            Me.oPrecios.CODIGO_ALMACEN = Me.CboAlmacen.SelectedValue.ToString
            Me.oPrecios.GrabarCambioPrecio()
            bResultado = True
        Catch ex As Exception
            HandleError(Me.Name, "Grabar", ex)
        End Try
        Return bResultado
    End Function

    Private Function ValidaPrecios(ByVal iRenglon As Integer) As Boolean
        Try
            'Valida que al menos un precio o el % utilidad sea > 0
            For i As Integer = 3 To Me.Grid.Cols - 1
                If valorNumericoD(Me.Grid.Cell(iRenglon, i).Text) > 0 Then
                    Return True
                End If
            Next

            Return False
        Catch ex As Exception
            HandleError(Me.Name, "ValidaPrecios", ex)
        End Try
    End Function

#End Region

End Class