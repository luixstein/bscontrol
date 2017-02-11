Option Strict On
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class Frm_Embarques_CambiaPreciosPalets
    Private igyCodigo As Short = 1
    Private igyDescripcion As Short = 2
    Private igyCantidad As Short = 3
    Private igyPrecio As Short = 4
    Private igyUnidad As Short = 5
    Private igyCantidadKilos As Short = 6
    Private igyPrecioKilos As Short = 7
    Private igyImpuestoPorcentaje As Short = 8
    Private igyImporte As Short = 9
    Private igyImporteKilos As Short = 10
    Private igyCodigoCultivo As Short = 11

#Region "Opciones"

    Private Sub tsbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGrabar.Click
        Me.Totales()
        If Me.Validar() = False Then
            Exit Sub
        End If

        If Me.CambiaPrecios() = True Then
            MsgBox("Los cambios de precio del embarque ha sido grabados satisfactoriamente.", MsgBoxStyle.Information, Me.Text)
        End If

        Me.Close()
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub
#End Region

#Region "Eventos de objetos"
#Region "Eventos"
    Private Sub Frm_Embarques_CambiaPreciosPaletsNacional_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.txtFolioEmbarque.Enabled = False
        Me.Detalle()
        Me.Totales()
    End Sub

    Private Sub Grid_KeyDown(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Grid.KeyDown
        Me.GestionaGrid(e)
    End Sub

    Private Sub txtNumerosDecimalKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Grid.KeyPress
        txtSoloNumerosDecimales(e, "")
        txtNoBeep(e)
    End Sub

#End Region
#End Region

#Region "Métodos y procedimientos"
    Private Sub InicializaGrid()
        Me.Grid.DataSource = Nothing
        FG_Grid_Limpiar(Me.Grid)
        Me.Grid.Rows = 2
        Me.FormateaGrid()
    End Sub

    Private Sub FormateaGrid()

        Me.Grid.Cols = 12

        Me.Grid.AllowUserSort = True

        Me.Grid.SelectionMode = FlexCell.SelectionModeEnum.ByCell
        Me.Grid.DisplayFocusRect = False
        Me.Grid.ExtendLastCol = False
        Me.Grid.LockButton = True
        Me.Grid.ReadonlyFocusRect = FlexCell.FocusRectEnum.Solid
        Me.Grid.BorderStyle = FlexCell.BorderStyleEnum.Light3D
        Me.Grid.ScrollBars = FlexCell.ScrollBarsEnum.Vertical
        Me.Grid.BackColorBkg = SystemColors.Control
        Me.Grid.DefaultFont = New Font("Tahoma", 8)

        Me.Grid.Column(Me.igyCodigo).Width = 70
        Me.Grid.Column(Me.igyDescripcion).Width = 300
        Me.Grid.Column(Me.igyCantidad).Width = 75
        Me.Grid.Column(Me.igyPrecio).Width = 75
        Me.Grid.Column(Me.igyUnidad).Width = 50
        Me.Grid.Column(Me.igyImporte).Width = 100

        Me.Grid.Cell(0, Me.igyCodigo).Text = "Código"
        Me.Grid.Cell(0, Me.igyDescripcion).Text = "Descripción"
        Me.Grid.Cell(0, Me.igyCantidad).Text = "Cantidad"
        Me.Grid.Cell(0, Me.igyPrecio).Text = "Precio"
        Me.Grid.Cell(0, Me.igyUnidad).Text = "Unidad"
        Me.Grid.Cell(0, Me.igyImporte).Text = "Importe"

        Me.Grid.Column(Me.igyCantidad).Mask = FlexCell.MaskEnum.Numeric
        Me.Grid.Column(Me.igyCantidad).DecimalLength = Empresa_Sistema.DECIMALES_CANTIDAD
        Me.Grid.Column(Me.igyCantidad).Alignment = FlexCell.AlignmentEnum.RightCenter

        Me.Grid.Column(Me.igyPrecio).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_PRECIO)
        Me.Grid.Column(Me.igyPrecio).Mask = FlexCell.MaskEnum.Numeric
        Me.Grid.Column(Me.igyPrecio).DecimalLength = Empresa_Sistema.DECIMALES_PRECIO
        Me.Grid.Column(Me.igyPrecio).Alignment = FlexCell.AlignmentEnum.RightCenter

        Me.Grid.Column(Me.igyImporte).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
        Me.Grid.Column(Me.igyImporte).Mask = FlexCell.MaskEnum.Numeric
        Me.Grid.Column(Me.igyImporte).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
        Me.Grid.Column(Me.igyImporte).Alignment = FlexCell.AlignmentEnum.RightCenter

        Me.Grid.Column(Me.igyCodigo).Locked = True
        Me.Grid.Column(Me.igyDescripcion).Locked = True
        Me.Grid.Column(Me.igyCantidad).Locked = True
        Me.Grid.Column(Me.igyPrecio).Locked = False
        Me.Grid.Column(Me.igyImporte).Locked = True
        Me.Grid.Column(Me.igyUnidad).Locked = True

        Me.Grid.Column(Me.igyCodigo).Visible = True
        Me.Grid.Column(Me.igyDescripcion).Visible = True
        Me.Grid.Column(Me.igyCantidad).Visible = True
        Me.Grid.Column(Me.igyPrecio).Visible = True
        Me.Grid.Column(Me.igyUnidad).Visible = True
        Me.Grid.Column(Me.igyCantidadKilos).Visible = False
        Me.Grid.Column(Me.igyPrecioKilos).Visible = False
        Me.Grid.Column(Me.igyImpuestoPorcentaje).Visible = False
        Me.Grid.Column(Me.igyImporte).Visible = True
        Me.Grid.Column(Me.igyImporteKilos).Visible = False
        Me.Grid.Column(Me.igyCodigoCultivo).Visible = False

        Me.Grid.Refresh()
    End Sub

    Private Function Detalle() As Boolean
        Dim oEmbarques As New Class_Embarques_EmbarqueGlobal, dTabla As DataTable

        If txtLEN(Me.txtFolioEmbarque.Text) = True Then
            oEmbarques.FOLIO_EMBARQUE = Me.txtFolioEmbarque.Text
            If oEmbarques.Consultar() = True Then
                dTabla = oEmbarques.ObtenerDetalleFactura() '.Rows.Count

                Me.InicializaGrid()
                Me.Grid.Rows = 1
                For Each dRow As DataRow In dTabla.Rows
                    Me.Grid.AddItem(dRow(0).ToString & Chr(9) & dRow(1).ToString & Chr(9) & dRow(2).ToString & Chr(9) & dRow(3).ToString & Chr(9) & dRow(4).ToString & Chr(9) & _
                                                      dRow(5).ToString & Chr(9) & dRow(6).ToString & Chr(9) & dRow(7).ToString & Chr(9) & dRow(8).ToString & Chr(9) & dRow(9).ToString & Chr(9) & _
                                                      dRow(10).ToString & Chr(9))
                Next
                dTabla.Dispose()

                Me.FormateaGrid()
                ' Me.Totales()
            End If
        End If
    End Function

    Private Sub Totales()
        Me.TxtTotalImporte.Text = FormatImporteContable(Redondear(FG_Grid_SumaCol(Me.Grid, Me.igyImporte), Empresa_Sistema.DECIMALES_CONTABILIDAD))
        Me.txtTotalBultos.Text = FG_Grid_SumaCol(Me.Grid, Me.igyCantidad).ToString
    End Sub

    Private Sub GestionaGrid(ByVal e As System.Windows.Forms.KeyEventArgs)
        Dim Columna As Integer, Renglon As Integer
        Dim StrCod As String, iBultos As Double, dImporte As Double

        Columna = Me.Grid.Selection.FirstCol
        Renglon = Me.Grid.Selection.FirstRow
        StrCod = Me.Grid.Cell(Renglon, Me.igyCodigo).Text
        iBultos = valorNumerico(Me.Grid.Cell(Renglon, Me.igyCantidad).Text)
        dImporte = valorNumerico(Me.Grid.Cell(Renglon, Me.igyPrecio).Text)

        Select Case e.KeyCode
            Case Keys.Enter
                Select Case Columna

                    Case Me.igyPrecio
                        If dImporte <= 0 Then
                            MsgBox("El importe debe de ser mayor a 0.", MsgBoxStyle.Exclamation, Me.Text)
                            Me.Grid.Cell(Renglon, Me.igyCantidad).SetFocus()
                            Exit Sub
                        End If
                        If Renglon < Me.Grid.Rows - 1 Then
                            Me.Grid.Cell(Renglon + 1, Me.igyCantidad).SetFocus()
                        Else
                            Me.tsbGrabar.Select()
                        End If
                        Me.Grid.Cell(Renglon, Me.igyImporte).Text = (valorNumerico(Me.Grid.Cell(Renglon, Me.igyCantidad).Text) * dImporte).ToString
                End Select
                Me.Totales()

        End Select
    End Sub

    Private Function CambiaPrecios() As Boolean
        Try

            Dim i As Integer

            For i = 1 To Me.Grid.Rows - 1
                If txtLEN(Me.Grid.Cell(i, Me.igyCodigo).Text) = True Then

                    Dim oArticulos As New Class_CatArticulos(Me.Grid.Cell(i, Me.igyCodigo).Text)
                    Dim oEmbarques As New Class_Embarques_EmbarqueGlobal

                    If oArticulos.Existe = True Then
                        oEmbarques.FOLIO_EMBARQUE = Me.txtFolioEmbarque.Text
                        oEmbarques.CambiarPrecios(oArticulos.CODIGO_ARTICULO.ToString, valorNumerico(Me.Grid.Cell(i, Me.igyPrecio).Text))
                    End If
                End If
            Next

            CambiaPrecios = True
        Catch ex As Exception
            HandleError(Me.Name, "CambiaPrecios", ex)
        End Try

    End Function

    Private Function Validar() As Boolean
        Dim oEmbarque As New Class_Embarques_EmbarqueGlobal
        oEmbarque = New Class_Embarques_EmbarqueGlobal()

        oEmbarque.FOLIO_EMBARQUE = Me.txtFolioEmbarque.Text
        oEmbarque.Consultar()

        Dim i As Integer

        If MsgBox("Deseas grabar los nuevos precios del embarque con el folio : " & Me.txtFolioEmbarque.Text & " ?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "Grabar") = MsgBoxResult.No Then
            Exit Function
        End If

        If Usuario.ValidaPermisoUsuarioDocumentoSinAfectacionInventarios(oEmbarque.CODIGO_DOCUMENTO) = False Then
            MsgBox("El usuario " & Usuario.Nombre_Usuario & " no tiene permiso para realizar el movimiento.", MsgBoxStyle.Information, Me.Text)
            Exit Function
        End If

        If Plaza.ValidarPeriodoTrabajo(Me.DtpFecha.Value) = False Then
            Exit Function
        End If

        For i = 1 To Me.Grid.Rows - 1
            If txtLEN(Me.Grid.Cell(i, Me.igyPrecio).Text) = True Then
                If valorNumerico(Me.Grid.Cell(i, Me.igyPrecio).Text) < 0 Then
                    MsgBox("El precio del articulo " + Me.Grid.Cell(i, Me.igyCodigo).Text + " debe ser mayor a 0.", MsgBoxStyle.Information, Me.Text)
                    Exit Function
                End If
            End If
        Next

        Validar = True
    End Function

#End Region
End Class