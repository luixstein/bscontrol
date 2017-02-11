Option Strict On
Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmCostosEdicion

#Region "Columnas grid"
    Private iGyID As Integer = 1
    Private iGyDescripcionArticulo As Integer = 2
    Private iGyCodigoCentroCosto As Integer = 3
    Private iGyNombreCentroCosto As Integer = 4
    Private iGyCodigoCategoria As Integer = 5
    Private iGyNombreCategoria As Integer = 6
    Private iGyCodigoConcepto As Integer = 7
    Private iGyNombreConcepto As Integer = 8
    Private iGyCantidad As Integer = 9
    Private iGyImporte As Integer = 10
    Private iGyCuentaContable As Integer = 11
#End Region

    Private oCentroCosto As Class_Centros_Costos_Global
    Private _bMovimientoEncontrado As Boolean = False

    Public ReadOnly Property bMovimientoEncontrado As Boolean
        Get
            Return Me._bMovimientoEncontrado
        End Get
    End Property

#Region "Opciones"
    Private Sub tsbGrabar_Click(sender As Object, e As EventArgs) Handles tsbGrabar.Click
        Me.Grabar()
    End Sub

    Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
        Me.Imprimir()
    End Sub

    Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub
#End Region

#Region "Eventos"
    Private Sub GridCuentas_KeyDown(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridCuentas.KeyDown
        Me.GestionaGrid(e)
    End Sub

    Private Sub GridCuentas_DoubleClick(Sender As Object, e As EventArgs) Handles GridCuentas.DoubleClick
        'intentar poner funcionalidad de que con doble click simule el f6
    End Sub
#End Region

#Region "Métodos y procedimientos"
    Public Sub New(ByVal sFolio As String, ByVal sCodigoDocumento As String)
        InitializeComponent()

        Me.Inicializa()

        Me.txtFolio.Text = sFolio
        Me.lblCodigoDocumento.Text = sCodigoDocumento

        If Me.Consultar() = False Then
            Me.Close()
        Else
            Me._bMovimientoEncontrado = True
        End If
    End Sub

    Private Sub Inicializa()
        Try
            Me.txtFolio.Text = ""
            Me.lblCodigoDocumento.Text = ""
            Me.InicializaGridCuentas()
            Me.txtTotalImporte.Text = FormatImporteContable(0)
        Catch ex As Exception
            HandleError(Me.Name, "Inicializa", ex)
        End Try
    End Sub

    Private Sub InicializaGridCuentas()
        Try
            Me.GridCuentas.DataSource = Nothing
            FG_Grid_Limpiar(Me.GridCuentas)

            'Creamos el Grid
            Me.GridCuentas.Rows = 2
            Me.GridCuentas.Cols = 12
            Me.GridCuentas.DisplayRowNumber = True

            Me.FormateaGridCuentas()
        Catch ex As Exception
            HandleError(Me.Name, "InicializaGridCuentas", ex)
        End Try
    End Sub

    Private Sub FormateaGridCuentas()
        Try
            Me.GridCuentas.Column(Me.iGyID).Visible = False
            Me.GridCuentas.Column(Me.iGyDescripcionArticulo).Width = 100
            Me.GridCuentas.Column(Me.iGyCodigoCentroCosto).Visible = False
            Me.GridCuentas.Column(Me.iGyNombreCentroCosto).Width = 220
            Me.GridCuentas.Column(Me.iGyCodigoCategoria).Visible = False
            Me.GridCuentas.Column(Me.iGyNombreCategoria).Width = 220
            Me.GridCuentas.Column(Me.iGyCodigoConcepto).Visible = False
            Me.GridCuentas.Column(Me.iGyNombreConcepto).Width = 220
            Me.GridCuentas.Column(Me.iGyCantidad).Width = 100
            Me.GridCuentas.Column(Me.iGyImporte).Width = 100
            Me.GridCuentas.Column(Me.iGyCuentaContable).Visible = False '.Width = 100

            Me.GridCuentas.Cell(0, Me.iGyDescripcionArticulo).Text = "Artículo"
            Me.GridCuentas.Cell(0, Me.iGyCodigoCentroCosto).Text = "CCos"
            Me.GridCuentas.Cell(0, Me.iGyNombreCentroCosto).Text = "C.costo"
            Me.GridCuentas.Cell(0, Me.iGyCodigoCategoria).Text = "CCat"
            Me.GridCuentas.Cell(0, Me.iGyNombreCategoria).Text = "Categoria"
            Me.GridCuentas.Cell(0, Me.iGyCodigoConcepto).Text = "CCon"
            Me.GridCuentas.Cell(0, Me.iGyNombreConcepto).Text = "Concepto"
            Me.GridCuentas.Cell(0, Me.iGyCantidad).Text = "Cantidad"
            Me.GridCuentas.Cell(0, Me.iGyImporte).Text = "Importe(MXP)"
            Me.GridCuentas.Cell(0, Me.iGyCuentaContable).Text = "Cuenta contable"

            Me.GridCuentas.Column(Me.iGyImporte).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
            Me.GridCuentas.Column(Me.iGyImporte).Mask = FlexCell.MaskEnum.Numeric
            Me.GridCuentas.Column(Me.iGyImporte).DecimalLength = 2
            Me.GridCuentas.Column(Me.iGyImporte).Alignment = FlexCell.AlignmentEnum.RightCenter

            'Me.GridCuentas.Column(Me.iGyImporte).Locked = True
            'Me.GridCuentas.Column(Me.iGyCuentaContable).Locked = True

            Me.GridCuentas.Locked = True

        Catch ex As Exception
            HandleError(Me.Name, "FormateaGridCuentas", ex)
        End Try
    End Sub

    Private Function Consultar() As Boolean
        Dim bResultado As Boolean = False
        Try
            Dim dTotal As Double = 0
            'Me.oCentroCosto = New Class_Centros_Costos_Global(Me.txtFolio.Text, Me.lblCodigoDocumento.Text & Usuario.Codigo_Plaza)
            Me.oCentroCosto = New Class_Centros_Costos_Global(Me.txtFolio.Text, Me.lblCodigoDocumento.Text)

            If oCentroCosto.Existe = False Then
                MsgBox("El folio del movimiento no existe en costos.", MsgBoxStyle.Exclamation, Me.Name)
                Return False
            End If

            'Me.GridCuentas.DataSource = oCentroCosto.ObtenerDetalleCostos
            Dim dTabla As DataTable = oCentroCosto.ObtenerDetalleCostos
            Me.GridCuentas.Rows = 1
            Me.GridCuentas.AutoRedraw = False

            'sSQL = "SELECT R.ID_CENTRO_COSTOS_MOVIMIENTOS_DETALLE,R.CODIGO_CENTRO_COSTO,CC.NOMBRE_CENTRO_COSTO,R.CODIGO_CATEGORIA,CA.NOMBRE_CATEGORIA,R.CODIGO_CONCEPTO,CO.NOMBRE_CONCEPTO,R.IMPORTE,R.CUENTA_CONTABLE " & _
            For Each dRow As DataRow In dTabla.Rows
                Me.GridCuentas.AddItem(dRow("ID_CENTRO_COSTOS_MOVIMIENTOS_DETALLE").ToString & Chr(9) & dRow("DESCRIPCION_ARTICULO").ToString & Chr(9) & _
                                       dRow("CODIGO_CENTRO_COSTO").ToString & Chr(9) & dRow("NOMBRE_CENTRO_COSTO").ToString & Chr(9) & _
                                       dRow("CODIGO_CATEGORIA").ToString & Chr(9) & dRow("NOMBRE_CATEGORIA").ToString & Chr(9) & dRow("CODIGO_CONCEPTO").ToString & Chr(9) & dRow("NOMBRE_CONCEPTO").ToString & Chr(9) & _
                                       dRow("CANTIDAD").ToString & Chr(9) & dRow("IMPORTE").ToString & Chr(9) & dRow("CUENTA_CONTABLE").ToString & Chr(9))

                dTotal += valorNumerico(dRow("IMPORTE").ToString)
            Next
            dTabla.Dispose()

            Me.txtTotalImporte.Text = FormatImporteContable(dTotal)

            Me.FormateaGridCuentas()

            Me.GridCuentas.Row(Me.GridCuentas.Rows - 1).Locked = True

            bResultado = True
        Catch ex As Exception
            HandleError(Me.Name, "Consultar", ex)
        Finally
            Me.GridCuentas.AutoRedraw = True
            Me.GridCuentas.Refresh()
        End Try

        Return bResultado
    End Function

    Private Function Grabar() As Boolean
        Dim bResultado As Boolean = False
        Dim sCuentas As String = "", i As Integer
        Try

            For i = 1 To Me.GridCuentas.Rows - 1
                'If Me.GridCuentas.Cell(i, Me.iGyCuentaContable).Text <> "" And valorNumerico(Me.GridCuentas.Cell(i, Me.iGyImporte).Text) > 0 Then
                If txtLEN(Me.GridCuentas.Cell(i, Me.iGyID).Text) = True Then 'Aqui sin importar nada con que sea un id existente se habrá de actualizar las 3 clasificaciones, de momento el importe no, aunque si lo tenga la cadena.
                    sCuentas = sCuentas & i & "," & Me.GridCuentas.Cell(i, Me.iGyID).Text & "," & Me.GridCuentas.Cell(i, Me.iGyCodigoCentroCosto).Text & "," & Me.GridCuentas.Cell(i, Me.iGyCodigoCategoria).Text & "," & Me.GridCuentas.Cell(i, Me.iGyCodigoConcepto).Text & "," & _
                    Me.GridCuentas.Cell(i, Me.iGyImporte).Text & "," & Me.GridCuentas.Cell(i, Me.iGyCuentaContable).Text & "|"
                End If
            Next i

            If txtLEN(sCuentas) = False Then
                MsgBox("Falta introducir los centros de costos.", MsgBoxStyle.Exclamation, "Validación")
                Exit Function
            Else
                If txtLEN(sCuentas) = True Then
                    sCuentas = sCuentas.Substring(0, sCuentas.Length - 1) 'Para quitarle el último pipe que sale sobrando.
                End If
            End If

            If Me.oCentroCosto.ActualizaCostos(sCuentas) Then
                bResultado = True

                MsgBox("Movimiento grabado satisfactoriamente.", MsgBoxStyle.Information, Me.Text)
            End If

        Catch ex As Exception
            HandleError(Me.Name, "Grabar", ex)
        End Try

        Return bResultado
    End Function

    Private Sub Imprimir()
        Dim StrFiltros As String = ""
        Dim FormatoDeReporte As String
        Dim Rpt As New ReportDocument
        Dim oReporte As Class_Reporte
        Try
            FormatoDeReporte = "RPT_FORMATO_MOVIMIENTO_CENTRO_COSTO_DETALLE"
            oReporte = New Class_Reporte(FormatoDeReporte, Rpt, False)
            If Not oReporte.RptCargado Then
                Exit Sub
            End If
            Rpt.SetParameterValue("@FOLIO_MOVIMIENTO", Me.txtFolio.Text)

            Dim frm As New Reporte(Rpt)
            frm.CRViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            frm.Show()
        Catch ex As Exception
            HandleError(Me.Name, "Imprimir", ex)
        Finally
            oReporte = Nothing
        End Try
    End Sub

    Private Sub GestionaGrid(ByVal e As System.Windows.Forms.KeyEventArgs)

        Dim Columna As Integer, Renglon As Integer
        Dim StrCod As String = "" ', oCuenta As Class_CatCuentas
        Dim oCentroCosto As Class_CatCentroCostos 'Class_VwCatCentrosCostosyDeudoresDiversos
        Dim oCategoria As Class_CatCategorias, oConcepto As Class_CatConceptos
        Dim sCodigo As String = ""

        Try
            Columna = Me.GridCuentas.Selection.FirstCol
            Renglon = Me.GridCuentas.Selection.FirstRow

            If Me.GridCuentas.Column(Columna).Locked = True Then
                Return
            End If

            Select Case e.KeyCode
                Case Keys.Return

                    Select Case Columna

                        Case Me.iGyNombreCentroCosto
                            If txtLEN(Me.GridCuentas.Cell(Renglon, Columna).Text) = False Then
                                GoTo busca_centro_costo
                                Return
                            End If

                            sCodigo = Me.GridCuentas.Cell(Renglon, Me.iGyCodigoCentroCosto).Text
                            If Me.EstableceCentroCosto(Renglon, Columna, e.KeyCode, sCodigo) = False Then
                                GoTo busca_centro_costo
                                Return
                            End If

                        Case Me.iGyNombreCategoria
                            If txtLEN(Me.GridCuentas.Cell(Renglon, Columna).Text) = False Then
                                GoTo busca_categoria
                                Return
                            End If

                            oCategoria = New Class_CatCategorias(Me.GridCuentas.Cell(Renglon, Me.iGyCodigoCategoria).Text)
                            If oCategoria.Existe = True Then
                                Me.GridCuentas.Cell(Renglon, Me.iGyCodigoCategoria).Text = oCategoria.Codigo_Categoria
                                Me.GridCuentas.Cell(Renglon, Me.iGyNombreCategoria).Text = oCategoria.Nombre_Categoria
                                Me.GridCuentas.Cell(Renglon, Me.iGyCuentaContable).Text = oCategoria.Codigo_Tipo_Categoria
                            Else
                                Me.GridCuentas.Cell(Renglon, Me.iGyCodigoCategoria).Text = ""
                                Me.GridCuentas.Cell(Renglon, Me.iGyNombreCategoria).Text = ""
                                Me.GridCuentas.Cell(Renglon, Me.iGyCuentaContable).Text = ""
                                GoTo busca_categoria
                                Return
                            End If

                        Case Me.iGyNombreConcepto
                            If txtLEN(Me.GridCuentas.Cell(Renglon, Columna).Text) = False Then
                                GoTo busca_concepto
                                Return
                            End If

                            oConcepto = New Class_CatConceptos(Me.GridCuentas.Cell(Renglon, Me.iGyCodigoConcepto).Text)
                            If oConcepto.Existe = True Then
                                Me.GridCuentas.Cell(Renglon, Me.iGyCodigoConcepto).Text = oConcepto.Codigo_Concepto
                                Me.GridCuentas.Cell(Renglon, Me.iGyNombreConcepto).Text = oConcepto.Nombre_Concepto
                            Else
                                Me.GridCuentas.Cell(Renglon, Me.iGyCodigoConcepto).Text = ""
                                Me.GridCuentas.Cell(Renglon, Me.iGyNombreConcepto).Text = ""
                                GoTo busca_concepto
                                Return
                            End If

                        Case Me.iGyImporte
                            If valorNumerico(Me.GridCuentas.Cell(Renglon, Me.iGyImporte).Text) = 0 Then
                                e.Handled = True 'Con esto el importe si es 0 no se brinca a la siguiente columna, se queda el foco en el importe.
                                Return
                            End If
                            Me.SaltoColumnas(Renglon, Columna, Keys.KeyCode)
                    End Select

salto_columna:

                Case Keys.F6
                    Select Case Columna

                        Case Me.iGyNombreCentroCosto
busca_centro_costo:
                            'Otra ves ahora es solo centro de costos
                            oCentroCosto = New Class_CatCentroCostos
                            sCodigo = oCentroCosto.BusquedaVisual_PorDescripcion
                            If txtLEN(sCodigo) = True Then
                                Me.EstableceCentroCosto(Renglon, Columna, e.KeyCode, sCodigo)
                            End If

                        Case Me.iGyNombreCategoria
busca_categoria:
                            oCategoria = New Class_CatCategorias
                            sCodigo = oCategoria.BusquedaVisual_PorDescripcion

                            If txtLEN(sCodigo) = True Then
                                oCategoria = New Class_CatCategorias(sCodigo)
                                Me.GridCuentas.Cell(Renglon, Me.iGyCodigoCategoria).Text = oCategoria.Codigo_Categoria.ToString
                                Me.GridCuentas.Cell(Renglon, Me.iGyNombreCategoria).Text = oCategoria.Nombre_Categoria
                                Me.GridCuentas.Cell(Renglon, Me.iGyCuentaContable).Text = oCategoria.Codigo_Tipo_Categoria
                            End If

                        Case Me.iGyNombreConcepto
busca_concepto:
                            oConcepto = New Class_CatConceptos
                            sCodigo = oConcepto.BusquedaVisual_PorDescripcion

                            If txtLEN(sCodigo) = True Then
                                oConcepto = New Class_CatConceptos(sCodigo)
                                Me.GridCuentas.Cell(Renglon, Me.iGyCodigoConcepto).Text = oConcepto.Codigo_Concepto.ToString
                                Me.GridCuentas.Cell(Renglon, Me.iGyNombreConcepto).Text = oConcepto.Nombre_Concepto
                            End If

                    End Select


            End Select

            'Me.TotalizaGridCentrosCostosyActivos()

        Catch ex As Exception
            HandleError(Me.Name, "GestionaGrid", ex)
        End Try
    End Sub

    Private Function EstableceCentroCosto(ByVal Renglon As Integer, ByVal Columna As Integer, ByVal KeyCode As System.Windows.Forms.Keys, ByVal sCodigo As String) As Boolean
        Dim bResultado As Boolean = False
        Try
            Dim oCentroCosto As New Class_CatCentroCostos(CInt(sCodigo))

            If oCentroCosto.EXISTE = True Then
                Me.GridCuentas.Cell(Renglon, Me.iGyCodigoCentroCosto).Text = oCentroCosto.CODIGO_CENTRO_COSTO.ToString
                Me.GridCuentas.Cell(Renglon, Me.iGyNombreCentroCosto).Text = oCentroCosto.NOMBRE_CENTRO_COSTO
                bResultado = True
            Else
                Me.InicializaRenglonGridCuentas(Renglon)
            End If

            If bResultado = True Then
                Me.SaltoColumnas(Renglon, Columna, KeyCode)
            End If

        Catch ex As Exception
            HandleError(Me.Name, "EstableceCentroCosto", ex)
        End Try
        Return bResultado
    End Function

    Private Sub SaltoColumnas(ByVal Renglon As Integer, ByVal Columna As Integer, ByVal KeyCode As System.Windows.Forms.Keys)
        If Me.GridCuentas.Rows = Renglon + 1 And Me.GridCuentas.Cell(Renglon, Me.iGyImporte).Locked = False Then
            Me.GridCuentas.Rows = Me.GridCuentas.Rows + 1
        End If

        Select Case Columna
            Case Me.iGyImporte
                Me.GridCuentas.Cell(Renglon + 1, Me.iGyCodigoCentroCosto).SetFocus()
            Case Else
                If KeyCode = Keys.F6 Then
                    Select Case Columna
                        Case Me.iGyNombreCentroCosto
                            Columna = Me.iGyNombreCategoria
                    End Select
                End If
                Me.GridCuentas.Cell(Renglon, Columna).SetFocus()
        End Select
    End Sub

    Private Sub InicializaRenglonGridCuentas(ByVal iRenglon As Integer)
        Try
            For i As Integer = 1 To Me.GridCuentas.Cols - 1
                Me.GridCuentas.Cell(iRenglon, i).Text = ""
            Next
        Catch ex As Exception
            HandleError(Me.Name, "InicializaRenglonGridCuentas", ex)
        End Try
    End Sub

#End Region

End Class