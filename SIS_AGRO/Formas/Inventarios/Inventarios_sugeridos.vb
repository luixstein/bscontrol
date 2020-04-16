Option Strict On

Public Class Inventarios_sugeridos

    Dim oInventariosSugeridos As Class_Inventarios_Sugeridos

#Region "Columnas grid"
    Private iGyCodigoArticulo As Integer = 1
    Private iGyDescripcion As Integer = 2
    Private iGyMaximo As Integer = 3
    Private iGyMinimo As Integer = 4
#End Region

    '#Region "Constructor y destructor"
    '    'Inicializa al objeto.
    '    Sub New()

    '        ' This call is required by the Windows Form Designer.
    '        InitializeComponent()
    '        ' Add any initialization after the InitializeComponent() call.

    '        Try
    '            Me.Run = False
    '            'Me.InicializaElemento()
    '            Me.Run = True
    '        Catch ex As Exception
    '            HandleError(Me.Name, "New", ex)
    '        End Try

    '    End Sub

    '    Protected Overrides Sub Finalize()
    '        'Me._Conexion.Dispose()
    '        MyBase.Finalize()
    '    End Sub


    '#End Region

#Region "Eventso genericos"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigoAlmacen.KeyPress, TxtFiltro.KeyPress
        txtNoBeep(e)
    End Sub

#End Region

#Region "Eventos"

    Private Sub Inventarios_sugeridos_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Inicializa()
    End Sub

    Private Sub TxtCodigoAlmacen_TextChanged(sender As Object, e As EventArgs) Handles TxtCodigoAlmacen.TextChanged
        Me.InicializaGrid()
        Me.GbArticulos.Enabled = False
    End Sub

    Private Sub TxtCodigoAlmacen_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCodigoAlmacen.KeyDown
        Dim oAlmacenes As New Class_CatAlmacenes
        Select Case e.KeyCode
            Case Keys.F6
busca:
                Me.TxtCodigoAlmacen.Text = oAlmacenes.BusquedaVisual_PorDescripcion
            Case Keys.Enter
                oAlmacenes.CODIGO_ALMACEN = Me.TxtCodigoAlmacen.Text
                If oAlmacenes.Consultar() = False Then
                    GoTo busca
                End If

                Me.LblNombreAlmacen.Text = oAlmacenes.NOMBRE_ALMACEN
                Me.ConsultarArticulos()

        End Select
        txtTAB(e)
    End Sub

    Private Sub GridArticulos_KeyDown(Sender As Object, e As KeyEventArgs) Handles GridArticulos.KeyDown
        Me.GestionaGrid(e)
    End Sub

    Private Sub TxtFiltro_TextChanged(sender As Object, e As EventArgs) Handles TxtFiltro.TextChanged
        Me.GridArticulos.DataSource = Nothing
        Me.ConsultarArticulos(Me.TxtFiltro.Text)
    End Sub


#End Region

#Region "Métodos y procedimientos"

    Private Sub Inicializa()
        Me.TxtCodigoAlmacen.Text = ""
        Me.LblNombreAlmacen.Text = ""
        Me.TxtFiltro.Text = ""
        Me.InicializaGrid()
        Me.GbArticulos.Enabled = False
    End Sub

    Private Sub ConsultarArticulos(Optional ByVal sFiltro As String = "")
        oInventariosSugeridos = New Class_Inventarios_Sugeridos

        If txtLEN(Me.TxtCodigoAlmacen.Text) = False Then
            MsgBox("Capture un código de almacén", MsgBoxStyle.Exclamation, Me.Text)
            Me.TxtCodigoAlmacen.Focus()
            Exit Sub
        End If


        Dim dTabla As DataTable = oInventariosSugeridos.ObtenerElementosFiltro(Me.TxtCodigoAlmacen.Text, sFiltro)

        Me.GridArticulos.AutoRedraw = False
        Me.GridArticulos.Rows = 1
        For Each dRow As DataRow In dTabla.Rows
            Me.GridArticulos.AddItem(dRow("CODIGO_ARTICULO").ToString & Chr(9) & dRow("DESCRIPCION").ToString & Chr(9) & dRow("MAXIMO").ToString & Chr(9) & dRow("MINIMO").ToString & Chr(9))
        Next

        Me.FormateaGrid()

        Me.GbArticulos.Enabled = True
    End Sub

    Private Function Grabar(ByVal sCodigoArticulo As String, ByVal dMax As Double, ByVal dMin As Double) As Boolean
        oInventariosSugeridos = New Class_Inventarios_Sugeridos

        If txtLEN(Me.TxtCodigoAlmacen.Text) = False Then
            MsgBox("Capture un codigo de almacén", MsgBoxStyle.Exclamation, Me.Text)
            Me.TxtCodigoAlmacen.Focus()
            Return False
        End If

        If txtLEN(sCodigoArticulo) = False Then
            MsgBox("No hay código de artículo", MsgBoxStyle.Exclamation, Me.Text)
            Return False
        End If

        If dMax < 0 Or dMin < 0 Then
            MsgBox("No se pueden grabar cantidades negativas", MsgBoxStyle.Exclamation, Me.Text)
            Return False
        End If

        Try

            With oInventariosSugeridos
                .CODIGO_ALMACEN = Me.TxtCodigoAlmacen.Text
                .CODIGO_ARTICULO = sCodigoArticulo
                .MAXIMO = CDec(dMax)
                .MINIMO = CDec(dMin)

                If oInventariosSugeridos.Grabar() = False Then
                    MsgBox("Error al grabar el artículo " & sCodigoArticulo, MsgBoxStyle.Exclamation, Me.Text)
                    Return False
                End If
            End With

        Catch ex As Exception
            HandleError(Me.Name, "Grabar", ex)
        End Try
    End Function

    Private Sub GestionaGrid(ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            Dim Columna As Integer, Renglon As Integer
            Dim sCodigoArticulo As String, dMaximo As Double, dMinimo As Double

            Columna = Me.GridArticulos.Selection.FirstCol
            Renglon = Me.GridArticulos.Selection.FirstRow
            sCodigoArticulo = Me.GridArticulos.Cell(Renglon, Me.iGyCodigoArticulo).Text
            dMaximo = valorNumerico(Me.GridArticulos.Cell(Renglon, Me.iGyMaximo).Text)
            dMinimo = valorNumerico(Me.GridArticulos.Cell(Renglon, Me.iGyMinimo).Text)

            oInventariosSugeridos = New Class_Inventarios_Sugeridos

            Select Case e.KeyCode
                Case Keys.Enter

                    Select Case Columna
                        Case Me.iGyMaximo, Me.iGyMinimo
                            Me.Grabar(sCodigoArticulo, dMaximo, dMinimo)
                            Me.ConsultarArticulos(Me.TxtFiltro.Text)

                            If Columna = Me.iGyMaximo Then
                                Me.GridArticulos.Cell(Renglon, Me.iGyMaximo).SetFocus()
                            Else
                                Me.GridArticulos.Cell(Renglon + 1, Me.iGyDescripcion).SetFocus()
                            End If

                    End Select

            End Select

        Catch ex As Exception
            HandleError(Me.Name, "GestionaGrid", ex)
        End Try
    End Sub

    Private Sub InicializaGrid()
        Try
            FG_Grid_Limpiar(Me.GridArticulos)
            Me.GridArticulos.Rows = 2
            Me.FormateaGrid()

        Catch ex As Exception
            HandleError(Me.Text, "InicializaGrid", ex)
        End Try
    End Sub

    Private Sub FormateaGrid()
        Try
            With Me.GridArticulos
                .AutoRedraw = False

                .Cols = 5

                .DisplayFocusRect = False
                .DrawMode = FlexCell.DrawModeEnum.OwnerDraw
                .BorderStyle = FlexCell.BorderStyleEnum.FixedSingle
                .FixedRowColStyle = FlexCell.FixedRowColStyleEnum.Flat

                .BackColor1 = Color.FromArgb(231, 235, 247)
                .BackColor2 = Color.FromArgb(239, 243, 255)
                .CellBorderColorFixed = Color.Black
                .GridColor = Color.FromArgb(148, 190, 231)

                .Cell(0, Me.iGyCodigoArticulo).Text = "Código"
                .Cell(0, Me.iGyDescripcion).Text = "Descripción"
                .Cell(0, Me.iGyMaximo).Text = "Maximo"
                .Cell(0, Me.iGyMinimo).Text = "Minimo"

                .Column(Me.iGyMaximo).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyMaximo).DecimalLength = Empresa_Sistema.DECIMALES_CANTIDAD
                .Column(Me.iGyMaximo).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGyMinimo).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyMinimo).DecimalLength = Empresa_Sistema.DECIMALES_CANTIDAD
                .Column(Me.iGyMinimo).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGyCodigoArticulo).Width = 70
                .Column(Me.iGyDescripcion).Width = 300
                .Column(Me.iGyMaximo).Width = 100
                .Column(Me.iGyMinimo).Width = 100

                .Column(Me.iGyCodigoArticulo).Locked = True
                .Column(Me.iGyDescripcion).Locked = True

                .AutoRedraw = True
                .Refresh()
            End With

        Catch ex As Exception
            HandleError(Me.Name, "FormateaGrid", ex)
        End Try
    End Sub

#End Region

End Class