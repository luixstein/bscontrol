Public Class Frm_CXC_Devoluciones

#Region "Campos privados"
    Private oDevolucion As New Class_CXC_Devoluciones_Global
    Private oVenta As New Class_Ventas_Global
    Private oDocumento As New Class_CatDocumentos
    Private oCliente As New Class_CatClientes
    Private oCuentas As New Class_CatCuentas

    Private Estado As enumEstados

    Private dPorcentajeIVAGlobal As Double = 0

    Private Enum enumEstados
        NUEVO
        GRABADO
        APLICADO
        CANCELADO
    End Enum

    Private dTablaMetodosPago As DataTable
    Private dtSeries As DataTable
#End Region

#Region "Columnas grid ventas"
    Private igyCodigo As Short = 1
    Private igyTipoControlInventariable As Short = 2
    Private igyDescripcion As Short = 3
    Private igyCantidad As Short = 4
    Private igyPrecio As Short = 5
    Private igyPRECIO_TOTAL As Short = 6
    Private igyUnidad As Short = 7
    Private igyImpuestoPorcentaje As Short = 10
    Private igyImporte As Short = 11
    Private igyCuentaContable As Short = 13
    Private igyImpuestoImporte As Short = 14
    Private igyIdOrigen As Short = 15
    Private igyIEPS_PORCENTAJE As Short = 21
    Private igyIEPS_UNITARIO As Short = 22
    Private igyIEPS_IMPORTE As Short = 23
    Private igyBASE_IEPS As Short = 24
    Private igyBASE_IVA As Short = 25
    Private igyCosto As Short = 26
#End Region

#Region "Columnas grid series"
    Private igySeriePosicion As Short = 1
    Private igySerieCodigo As Short = 2
    Private igySerieDescripcion As Short = 3
    Private igySerieIdInventarioLotesCostos As Short = 4
    Private igySerieNumeroSerie As Short = 5
#End Region

#Region "Opciones"
    Private Sub tsbNuevo_Click(sender As Object, e As EventArgs) Handles tsbNuevo.Click
        Me.Inicializa()
        Me.Cambia_Estado(enumEstados.NUEVO)
    End Sub

    Private Sub tsbGrabar_Click(sender As Object, e As EventArgs) Handles tsbGrabar.Click
        If Me.Grabar = True Then
            Me.Consultar
        End If
    End Sub

    Private Sub tsbCancelar_Click(sender As Object, e As EventArgs) Handles tsbCancelar.Click
        If Me.Cancelar = True Then
            Me.Consultar
        End If
    End Sub

    Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
        Me.Imprimir
    End Sub

    Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub

#End Region

#Region "Eventos de objetos"
    Private Sub Frm_CXC_Devoluciones_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.oDocumento = New Class_CatDocumentos("DEVV" & Usuario.Codigo_Plaza.ToString)
            Me.Inicializa()
            Me.Cambia_Estado(enumEstados.NUEVO)
        Catch ex As Exception
            HandleError(Me.Name, "Frm_CXC_Devoluciones_Load", ex)
        End Try
    End Sub

    Private Sub txtFolioDevolucion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFolioDevolucion.KeyDown
        Dim sText As String
        Select Case e.KeyCode
            Case Keys.F6
                sText = Me.oDevolucion.BusquedaVisual_PorDescripcion()
                If txtLEN(sText) = True Then
                    Me.txtFolioDevolucion.Text = sText
                    Me.Consultar()
                End If
            Case Keys.Return
                If txtLEN(Me.txtFolioDevolucion.Text) = True Then
                    Me.Consultar()
                Else
                    Me.GeneraFolio()
                End If
        End Select
    End Sub
#End Region

#Region "Métodos y procedimientos"
    Private Sub Inicializa()
        Try
            Me.txtFolioDevolucion.Text = ""
            Me.txtFolioVenta.Text = ""
            Me.txtCliente.Text = ""
            Me.txtConcepto.Text = ""
            Me.chkVentaPublicoGeneral.Checked = False
            Me.chkImprimirDolares.Checked = False

            Me.lblCliente.Text = ""
            Me.lblEstatus.Text = "N"
            Me.lblPoliza.Text = ""
            Me.txtTipoCambio.Text = "0"
            Me.lblSubtotalDolares.Text = FormatImporteContable(0)
            Me.lblImpuestoDolares.Text = FormatImporteContable(0)
            Me.lblTotalDolares.Text = FormatImporteContable(0)
            Me.lblSubtotal.Text = FormatImporteContable(0)
            Me.lblImpuesto.Text = FormatImporteContable(0)
            Me.lblTotal.Text = FormatImporteContable(0)

            Me.dtFecha.Value = Date.Now

            Me.InicializaGrid()
            Me.InicializaGridSeries()

            Me.oDevolucion.CODIGO_DOCUMENTO = "DEVV" & Usuario.Codigo_Plaza
            Me.GeneraFolio()

            Me.dtSeries = New DataTable("Series")

            Me.TabControl1.SelectedIndex = 0

        Catch ex As Exception
            HandleError(Me.Name, "Inicializa", ex)
        End Try
    End Sub

    Private Sub InicializaGrid()
        Try
            Me.Grid.DataSource = Nothing
            FG_Grid_Limpiar(Me.Grid)
            Me.Grid.Rows = 2
            Me.FormateaGrid()
        Catch ex As Exception
            HandleError(Me.Name, "InicializaGrid", ex)
        End Try
    End Sub

    Private Sub InicializaGridSeries()
        Try
            Me.GridSeries.DataSource = Nothing
            FG_Grid_Limpiar(Me.GridSeries)
            Me.GridSeries.Rows = 2
            Me.GridSeries.Cols = 6
            Me.FormateaGridSeries()
            'Me.Grid.Cell(1, Me.iGyIDAdicional).Text = "1"
        Catch ex As Exception
            HandleError(Me.Name, "InicializaGridSeries", ex)
        End Try
    End Sub

    Private Sub FormateaGrid()
        Try
            Me.Grid.AutoRedraw = False
            Me.Grid.Cols = 27

            Me.Grid.Column(Me.igyCodigo).Width = 75
            Me.Grid.Column(Me.igyDescripcion).Width = 250
            Me.Grid.Column(Me.igyTipoControlInventariable).Width = 25
            Me.Grid.Column(Me.igyCantidad).Width = 90
            Me.Grid.Column(Me.igyPrecio).Width = 100
            Me.Grid.Column(Me.igyUnidad).Width = 75
            Me.Grid.Column(Me.igyImpuestoPorcentaje).Width = 70
            Me.Grid.Column(Me.igyImporte).Width = 100
            Me.Grid.Column(Me.igyCuentaContable).Width = 100
            Me.Grid.Column(Me.igyImpuestoImporte).Width = 100
            Me.Grid.Column(Me.igyIdOrigen).Width = 100

            Me.Grid.Cell(0, Me.igyCodigo).Text = "Código"
            Me.Grid.Cell(0, Me.igyDescripcion).Text = "Descripción"
            Me.Grid.Cell(0, Me.igyTipoControlInventariable).Text = "Inv"
            Me.Grid.Cell(0, Me.igyCantidad).Text = "Cantidad"
            Me.Grid.Cell(0, Me.igyPrecio).Text = "Precio"
            Me.Grid.Cell(0, Me.igyPRECIO_TOTAL).Text = "Precio total"
            Me.Grid.Cell(0, Me.igyUnidad).Text = "Unidad"
            Me.Grid.Cell(0, Me.igyImpuestoPorcentaje).Text = "IVA %"
            Me.Grid.Cell(0, Me.igyImporte).Text = "Importe"
            Me.Grid.Cell(0, Me.igyCuentaContable).Text = "Cuenta Contable"
            Me.Grid.Cell(0, Me.igyImpuestoImporte).Text = "IVA"
            Me.Grid.Cell(0, Me.igyIdOrigen).Text = "Id Articulo"

            Me.Grid.Column(Me.igyCantidad).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.igyCantidad).DecimalLength = Empresa_Sistema.DECIMALES_CANTIDAD
            Me.Grid.Column(Me.igyCantidad).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.igyPrecio).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_PRECIO)
            Me.Grid.Column(Me.igyPrecio).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.igyPrecio).DecimalLength = Empresa_Sistema.DECIMALES_PRECIO
            Me.Grid.Column(Me.igyPrecio).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.igyPRECIO_TOTAL).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_PRECIO)
            Me.Grid.Column(Me.igyPRECIO_TOTAL).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.igyPRECIO_TOTAL).DecimalLength = Empresa_Sistema.DECIMALES_PRECIO
            Me.Grid.Column(Me.igyPRECIO_TOTAL).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.igyImpuestoPorcentaje).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.igyImpuestoPorcentaje).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
            Me.Grid.Column(Me.igyImpuestoPorcentaje).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.igyImporte).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
            Me.Grid.Column(Me.igyImporte).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.igyImporte).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
            Me.Grid.Column(Me.igyImporte).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.igyCuentaContable).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.igyImpuestoImporte).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.igyImpuestoImporte).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
            Me.Grid.Column(Me.igyImpuestoImporte).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.igyIdOrigen).Mask = FlexCell.MaskEnum.Numeric

            Me.Grid.Column(Me.igyDescripcion).Locked = True
            Me.Grid.Column(Me.igyTipoControlInventariable).Locked = True
            Me.Grid.Column(Me.igyImporte).Locked = True
            Me.Grid.Column(Me.igyImpuestoImporte).Visible = False
            Me.Grid.Column(Me.igyIdOrigen).Visible = False
            Me.Grid.Column(Me.igyUnidad).Locked = True
            Me.Grid.Column(Me.igyCosto).Visible = False
            Me.Grid.Column(Me.igyIEPS_PORCENTAJE).Visible = False
            Me.Grid.Column(Me.igyIEPS_UNITARIO).Visible = False
            Me.Grid.Column(Me.igyIEPS_IMPORTE).Visible = False
            Me.Grid.Column(Me.igyBASE_IEPS).Visible = False
            Me.Grid.Column(Me.igyBASE_IVA).Visible = False
            Me.Grid.Column(Me.igyPRECIO_TOTAL).Locked = True
            Me.Grid.Column(Me.igyPrecio).Locked = True

        Catch ex As Exception
            HandleError(Me.Name, "FormateaGrid", ex)
        Finally
            Me.Grid.AutoRedraw = True
            Me.Grid.Refresh()
        End Try
    End Sub

    Private Sub FormateaGridSeries()
        Try
            With Me.GridSeries
                .AutoRedraw = False

                '.DefaultFont = New Font("Tahoma", 8)
                .DisplayFocusRect = False
                '.DisplayDateTimeMask = True
                '.ExtendLastCol = True
                .DrawMode = FlexCell.DrawModeEnum.OwnerDraw
                .BorderStyle = FlexCell.BorderStyleEnum.FixedSingle
                .FixedRowColStyle = FlexCell.FixedRowColStyleEnum.Flat

                .Column(Me.igySeriePosicion).Visible = False
                .Column(Me.igySerieCodigo).Width = 130
                .Column(Me.igySerieDescripcion).Width = 450
                .Column(Me.igySerieIdInventarioLotesCostos).Visible = False
                .Column(Me.igySerieNumeroSerie).Width = 250

                .Cell(0, Me.igySeriePosicion).Text = "Posición"
                .Cell(0, Me.igySerieCodigo).Text = "Código"
                .Cell(0, Me.igySerieDescripcion).Text = "Descripción"
                .Cell(0, Me.igySerieIdInventarioLotesCostos).Text = "Id lote"
                .Cell(0, Me.igySerieNumeroSerie).Text = "Número de serie"

                .Column(Me.igySeriePosicion).Locked = True
                .Column(Me.igySerieCodigo).Locked = True
                .Column(Me.igySerieDescripcion).Locked = True
                .Column(Me.igySerieIdInventarioLotesCostos).Locked = True
                .Column(Me.igySerieNumeroSerie).Locked = True

                .AutoRedraw = True
                .Refresh()

                .Row(.Rows - 1).Locked = True 'Para bloquear la edición del último renglón
            End With
        Catch ex As Exception
            HandleError(Me.Name, "FormateaGridSeries", ex)
        End Try
    End Sub

    Private Sub GestionaCambioEstado()
        Select Case Me.lblEstatus.Text
            Case "N"
                Me.Cambia_Estado(enumEstados.NUEVO)
            Case "G"
                Me.Cambia_Estado(enumEstados.GRABADO)
            Case "A"
                Me.Cambia_Estado(enumEstados.APLICADO)
            Case "C"
                Me.Cambia_Estado(enumEstados.CANCELADO)
        End Select
    End Sub

    Private Sub Cambia_Estado(ByVal pEstado As enumEstados)
        Try
            Me.Estado = pEstado

            Select Case Me.Estado
                Case enumEstados.NUEVO
                    Me.tsbNuevo.Enabled = True
                    Me.tsbCancelar.Enabled = False
                    Me.tsbImprimir.Enabled = False
                    Me.tsbGrabar.Enabled = True
                    Me.tsbEnviarCorreo.Enabled = False

                    Me.frmDatos.Enabled = True
                    Me.Grid.Locked = False

                    Me.GridSeries.Locked = True
                    If Me.oDocumento.AFECTA_INVENTARIOS = True Then
                        Me.GridSeries.Locked = False
                        Me.btnSeries.Visible = True
                    End If

                    Me.tssEstado.Text = "Estado: Agregando nuevo movimiento"
                    Me.tssElaboro.Visible = False : Me.tssElaboro.Text = ""
                    Me.tssCancelo.Visible = False : Me.tssCancelo.Text = ""

                    Me.txtFolioVenta.Enabled = True
                    Me.txtCliente.Enabled = True
                    Me.txtConcepto.Enabled = True
                    Me.chkVentaPublicoGeneral.Enabled = True
                    Me.chkImprimirDolares.Enabled = True
                    Me.dtFecha.Enabled = True
                    Me.txtFolioDevolucion.Enabled = True

                    If Me.Visible = True Then
                        Me.txtFolioDevolucion.Focus()
                    End If

                    Me.tsbSellar.Visible = False
                    Me.tsbCancelarTimbre.Visible = False

                Case enumEstados.GRABADO
                    Me.tsbNuevo.Enabled = True
                    Me.tsbGrabar.Enabled = True
                    Me.tsbCancelar.Enabled = True
                    Me.tsbImprimir.Enabled = True
                    Me.tsbEnviarCorreo.Enabled = False

                    Me.frmDatos.Enabled = True
                    Me.Grid.Locked = False
                    Me.GridSeries.Locked = True

                    Me.btnSeries.Visible = False

                    Me.tssEstado.Text = "Estado: Consultando movimiento"
                    Me.tssElaboro.Visible = True : Me.tssElaboro.Text = "Elaboró: " + Me.oVenta.NOMBRE_USUARIO.ToUpper + " el " + Format(Me.dtFecha.Value, "dd/MMM/yy").ToUpper
                    Me.tssCancelo.Visible = False : Me.tssCancelo.Text = ""

                    Me.txtConcepto.Focus()

                    Me.tsbSellar.Visible = False
                    Me.tsbCancelarTimbre.Visible = False

                Case enumEstados.APLICADO
                    Me.tsbNuevo.Enabled = True
                    Me.tsbGrabar.Enabled = False
                    Me.tsbCancelar.Enabled = True
                    Me.tsbImprimir.Enabled = True
                    Me.tsbEnviarCorreo.Enabled = True

                    'Me.frmDatos.Enabled = False
                    Me.Grid.Locked = True
                    Me.GridSeries.Locked = True

                    Me.txtFolioDevolucion.Enabled = False
                    Me.txtFolioVenta.Enabled = False
                    Me.txtCliente.Enabled = False
                    Me.txtConcepto.Enabled = False
                    Me.chkVentaPublicoGeneral.Enabled = False
                    Me.chkImprimirDolares.Enabled = False
                    Me.dtFecha.Enabled = False

                    If Empresa_Sistema.FELECTRONICA_ACTIVA = True And oDocumento.TIMBRA_DOCUMENTO = True Then
                        If Me.oVenta.VERSION_ESQUEMA_XML >= "3.2" Or Me.oVenta.VERSION_ESQUEMA_XML = "" Then
                            If Me.oVenta.TIMBRADO_CFDI = "0" And Me.oVenta.TIMBRADO_DESCARTADO = "0" Then
                                Me.tsbSellar.Visible = True
                                Me.tsbCancelarTimbre.Visible = False
                            Else
                                Me.tsbSellar.Visible = False
                            End If
                        Else
                            Me.tsbSellar.Visible = False
                            Me.tsbCancelarTimbre.Visible = False
                        End If
                    End If

                    Me.btnSeries.Visible = False

                    Me.tssEstado.Text = "Estado: Consultando movimiento"
                    Me.tssElaboro.Visible = True : Me.tssElaboro.Text = "Elaboró: " + Me.oDevolucion.NOMBRE_USUARIO.ToUpper + " el " + Format(Me.dtFecha.Value, "dd/MMM/yy").ToUpper
                    Me.tssCancelo.Visible = False : Me.tssCancelo.Text = ""

                    Me.tsbImprimir.Select()

                Case enumEstados.CANCELADO
                    Me.tsbNuevo.Enabled = True
                    Me.tsbGrabar.Enabled = False
                    Me.tsbCancelar.Enabled = False
                    Me.tsbImprimir.Enabled = True
                    Me.tsbEnviarCorreo.Enabled = True

                    'Me.frmDatos.Enabled = False
                    Me.Grid.Locked = True
                    Me.GridSeries.Locked = True

                    Me.btnSeries.Visible = False

                    Me.tssEstado.Text = "Estado: Consultando movimiento"
                    Me.tssElaboro.Visible = True : Me.tssElaboro.Text = "Elaboró: " + Me.oDevolucion.NOMBRE_USUARIO.ToUpper + " el " + Format(Me.dtFecha.Value, "dd/MMM/yy").ToUpper
                    Me.tssCancelo.Visible = True : Me.tssCancelo.Text = "Canceló: " + Me.oDevolucion.NOMBRE_USUARIO_CANCELO.ToUpper + " el " + Format(Me.oDevolucion.FECHA_CANCELACION, "dd/MMM/yy").ToUpper

                    Me.tsbImprimir.Select()

                    Me.txtFolioDevolucion.Enabled = False
                    Me.txtFolioVenta.Enabled = False
                    Me.txtCliente.Enabled = False
                    Me.txtConcepto.Enabled = False
                    Me.chkVentaPublicoGeneral.Enabled = False
                    Me.chkImprimirDolares.Enabled = False
                    Me.dtFecha.Enabled = False

                    If Me.oVenta.VERSION_ESQUEMA_XML >= "3.2" Or Me.oVenta.VERSION_ESQUEMA_XML = "" Then
                        If Me.oVenta.TIMBRADO_CFDI = "1" Then
                            If Me.oVenta.TIMBRADO_DESCARTADO = "0" Then
                                If Me.oVenta.ESTATUS_CANCELACION_CFDI = "0" Then
                                    Me.tsbCancelarTimbre.Visible = True
                                Else
                                    Me.tsbCancelarTimbre.Visible = False
                                End If
                            Else
                                Me.tsbCancelarTimbre.Visible = False
                            End If
                        Else
                            Me.tsbCancelarTimbre.Visible = False
                        End If
                    Else
                        Me.tsbSellar.Visible = False
                        Me.tsbCancelarTimbre.Visible = False
                    End If

            End Select

            'Me.tsbSellarFacturaElectronica.Visible = False

            Application.DoEvents()

        Catch ex As Exception
            HandleError(Me.Name, "Cambia_Estado", ex)
        End Try
    End Sub

    Private Sub GeneraFolio()
        'If Me.bDocumentosCargados = True Then
        Me.txtFolioDevolucion.Text = Me.oVenta.GeneraFolioVentas
        'End If
    End Sub

    Private Function Consultar() As Boolean

    End Function

    Private Function Grabar() As Boolean

    End Function

    Private Function Cancelar() As Boolean

    End Function

    Private Sub Imprimir()

    End Sub
#End Region

End Class