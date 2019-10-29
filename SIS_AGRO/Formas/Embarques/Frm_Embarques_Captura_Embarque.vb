Option Strict On

Imports Microsoft.VisualBasic

Public Class Frm_Embarques_Captura_Embarque

    Private oEmbarque As New Class_Embarques_EmbarqueGlobal
    Private oDocumento As New Class_CatDocumentos

    Private oPalets As New Class_Embarques_PaletsGlobal
    Private oTransporte As New Class_CatTransportes
    Private oCajas As New Class_CatCajasTransportes
    Private oClientes As New Class_CatClientes
    Private oAduanales As New Class_CatAgenciaAduanales
    Private oChoferes As New Class_CatChoferes

#Region "Columnas grid"
    Private igyCodigoPalet As Short = 1
    Private igyBultos As Short = 2
    Private igyPeso As Short = 3
    Private igyImporte As Short = 4
    Private igySalida As Short = 5
    Private igyGenerarSalida As Short = 6
#End Region

    Private bDocumentosCargados As Boolean

    Private Estado As enumEstados

    Private Enum enumEstados
        NUEVO
        NUEVO_ADICIONAL
        APLICADO
        CANCELADO
        FACTURADO
    End Enum

#Region "Opciones"
    Private Sub tsbNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbNuevo.Click
        Me.Inicializa()
        Me.Cambia_Estado(enumEstados.NUEVO)
    End Sub

    Private Sub tsbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGrabar.Click
        If Me.Grabar() = True Then
            'Se quitó temporalmente para bi, luego se va retomar
            'If GeneraMarcaSalida() = False Then
            '    Exit Sub
            'End If
            Me.Consultar()
        End If
    End Sub

    Private Sub tsbCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCancelar.Click
        If Me.Cancelar = True Then
            Me.Consultar()
        End If
    End Sub

    Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click
        Dim Child As New Frm_Imprimir_Embarques
        Child.FolioEmbarque = Me.txtFolioEmbarque.Text
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()

        'Me.Imprimir()
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub

    Private Sub tsbGenerarTxtEnvio_Click(sender As Object, e As EventArgs) Handles tsbGenerarTxtEnvio.Click
        Dim sTXT As String = Me.oEmbarque.GeneraTXTEnvio()
        If txtLEN(sTXT) = True Then
            MsgBox("Archivo generado satisfactoriamente en : " & vbCrLf &
                sTXT)
        End If
    End Sub

    Private Sub btnFacturar_Click(sender As Object, e As EventArgs) Handles btnFacturar.Click
        Me.GestionaFactura()
    End Sub

    Private Sub btnCancelarFactura_Click(sender As Object, e As EventArgs) Handles btnCancelarFactura.Click
        Me.GestionaCancelarFactura()
    End Sub

    'Private Sub btnExportarXML_Click(sender As Object, e As EventArgs)
    '    Me.ExportarArchivosPDF()
    'End Sub

    Private Sub btnGrabarFolioPedimento_Click(sender As Object, e As EventArgs) Handles btnGrabarFolioPedimento.Click
        Me.GrabarFolioPedimento()
    End Sub

    Private Sub btnEmbarqueAnterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmbarqueAnterior.Click
        Me.NavegadorEmbarques("Anterior")
    End Sub

    Private Sub btnEmbarqueSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmbarqueSiguiente.Click
        Me.NavegadorEmbarques("Siguiente")
    End Sub

    Private Sub btnConsultarSalida_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultarSalida.Click
        Me.ConsultarSalida()
    End Sub

    Private Sub btnTimbrarFactura_Click(sender As Object, e As EventArgs) Handles btnTimbrarFactura.Click
        Me.TimbrarFactura()
    End Sub
#End Region

#Region "Eventos de objetos"

#Region "Eventos"
    Private Sub Frm_Embarques_Captura_Embarque_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.DesplegarDocumentos()
            Me.DesplegarDistribuidor()
            Me.DesplegarEmbarcardor()
            'Me.DesplegarChoferes()
            Me.DesplegarLugarEntrega()
            Me.DesplegarEstadoDestino()
            Me.DesplegarAlmacenes()
            Me.DesplegarEmpaques()

            Me.Inicializa()
            Me.Cambia_Estado(enumEstados.NUEVO)
        Catch ex As Exception
            HandleError(Me.Name, "Frm_Embarques_Captura_Embarque_Load", ex)
        End Try
    End Sub

    Private Sub CmbDocumento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDocumento.SelectedIndexChanged
        Me.oDocumento = New Class_CatDocumentos(Me.cboDocumento.SelectedValue.ToString)
        Me.OcultarControles()

        'Me.oCompras = New Class_Compras_Global(Me.cboDocumento.SelectedValue.ToString)
        'Me.oEmbarque = New Class_Embarques_EmbarqueGlobal()
        Me.Inicializa()

        Me.Cambia_Estado(enumEstados.NUEVO)
    End Sub

    Private Sub txtFolioEmbarque_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFolioEmbarque.KeyDown
        Select Case e.KeyCode
            Case Keys.F6
                If Me.oDocumento.CODIGO_MERCADO = "N" Then
                    Me.txtFolioEmbarque.Text = Me.oEmbarque.BusquedaVisual_Embarques_Extranjeros()
                Else
                    Me.txtFolioEmbarque.Text = Me.oEmbarque.BusquedaVisual_Embarques_Nacional()
                End If
            Case Keys.Enter
                Me.Consultar()
                If Me.oDocumento.CODIGO_MERCADO = "E" Then
                    Me.txtFolioAARC.Focus()
                Else
                    Me.CboDistribuidor.Focus()
                End If
        End Select
    End Sub

    Private Sub txtFolioViaje_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFolioViaje.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.txtFolioEmbarque.Text = Me.txtFolioViaje.Text '& "A"
            Me.Consultar()
        End If
    End Sub

    Private Sub txtFolioAARC_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFolioAARC.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If txtLEN(Me.txtFolioAARC.Text) = False Then
                    Me.GeneraFolioAARC()
                End If
                Me.CboDistribuidor.Focus()
        End Select
    End Sub

    Private Sub TxtClientes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCliente.KeyDown
        Dim sText As String, sCodigo_Tipo_Mercado As String
        Select Case e.KeyCode
            Case Keys.F6
Buscar:
                If Me.oDocumento.CODIGO_MERCADO = "E" Then
                    sCodigo_Tipo_Mercado = "0001"
                Else
                    sCodigo_Tipo_Mercado = "0002"
                End If
                sText = Me.oClientes.BusquedaVisual_PorDescripcionZona(sCodigo_Tipo_Mercado)
                If txtLEN(sText) = True Then Me.TxtCliente.Text = sText
            Case Keys.Enter
                If txtLEN(Me.TxtCliente.Text) = False Then
                    Me.lblNombreCliente.Text = "" : GoTo Buscar : Exit Sub
                End If

                Me.oClientes = New Class_CatClientes(Me.TxtCliente.Text)
                If Me.oClientes.Existe = False Then
                    Me.lblNombreCliente.Text = "" : GoTo Buscar : Exit Sub
                End If

                Me.lblNombreCliente.Text = Me.oClientes.NOMBRE_CLIENTE.ToString
                Me.cboEstado.Text = oClientes.ESTADO.ToString
                Me.txtCodigoTransporte.Focus()
        End Select
    End Sub

    Private Sub TxtChofer_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtChofer.KeyDown
        Dim sText As String
        Select Case e.KeyCode
            Case Keys.F6
Buscar:
                sText = Me.oChoferes.BusquedaVisual_PorDescripcion
                If txtLEN(sText) = True Then Me.TxtChofer.Text = sText
            Case Keys.Enter
                If txtLEN(Me.TxtChofer.Text) = False Then
                    Me.lblNombreChofer.Text = ""
                End If

                Me.oChoferes = New Class_CatChoferes(Me.TxtChofer.Text)
                If Me.oChoferes.Existe = False Then
                    Me.lblNombreChofer.Text = "" : GoTo Buscar : Exit Sub
                End If

                Me.lblNombreChofer.Text = Me.oChoferes.NOMBRE_CHOFER

                txtTAB(e)
        End Select
    End Sub

    Private Sub txtCodigoTransporte_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigoTransporte.KeyDown
        Dim sText As String
        Select Case e.KeyCode
            Case Keys.F6
Buscar:
                sText = Me.oTransporte.BusquedaVisual_PorDescripcion
                If txtLEN(sText) = True Then Me.txtCodigoTransporte.Text = sText
            Case Keys.Enter
                If txtLEN(Me.txtCodigoTransporte.Text) = False Then
                    Me.TxtMarca.Text = "" : Me.TxtModelo.Text = "" : Me.TxtPlacas.Text = "" : Me.txtLinea.Text = "" : GoTo Buscar : Exit Sub
                End If

                Me.oTransporte = New Class_CatTransportes(Me.txtCodigoTransporte.Text)
                If Me.oTransporte.Existe = False Then
                    Me.TxtModelo.Text = "" : GoTo Buscar : Exit Sub
                End If

                Me.TxtMarca.Text = Me.oTransporte.MARCA
                Me.TxtModelo.Text = Me.oTransporte.MODELO
                Me.TxtPlacas.Text = Me.oTransporte.PLACA
                Me.txtLinea.Text = Me.oTransporte.NOMBRE_LINEA_TRANSPORTE

                txtTAB(e)
        End Select
    End Sub

    Private Sub txtCaja_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCaja.KeyDown
        Dim sText As String
        Select Case e.KeyCode
            Case Keys.F6
Buscar:
                sText = Me.oCajas.BusquedaVisual_PorDescripcion
                If txtLEN(sText) = True Then Me.txtCaja.Text = sText
            Case Keys.Enter
                If txtLEN(Me.txtCaja.Text) = False Then
                    Me.lblNombreCaja.Text = "" : Me.TxtPlacasCaja.Text = "" : GoTo Buscar : Exit Sub
                End If

                Me.oCajas = New Class_CatCajasTransportes(Me.txtCaja.Text)
                If Me.oCajas.Existe = False Then
                    Me.lblNombreCaja.Text = "" : GoTo Buscar : Exit Sub
                End If

                Me.lblNombreCaja.Text = Me.oCajas.NOMBRE_CAJA
                Me.TxtPlacasCaja.Text = Me.oCajas.PLACA

                If Me.oDocumento.CODIGO_MERCADO = "N" Then
                    Me.TxtChofer.Focus()
                Else
                    Me.TxtAduanaExtranjera.Focus()
                End If
                'txtTAB(e)
        End Select
    End Sub

    Private Sub TxtAduanaExtranjera_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtAduanaExtranjera.KeyDown
        Dim sText As String
        Select Case e.KeyCode
            Case Keys.F6
Buscar:
                sText = Me.oAduanales.BusquedaVisual_PorDescripcion_AduanasExtranjeras
                If txtLEN(sText) = True Then Me.TxtAduanaExtranjera.Text = sText
            Case Keys.Enter
                If txtLEN(Me.TxtAduanaExtranjera.Text) = False Then
                    Me.lblNombrelblAduanaExtranjera.Text = "" : GoTo Buscar : Exit Sub
                End If

                Me.oAduanales = New Class_CatAgenciaAduanales(Me.TxtAduanaExtranjera.Text)
                If Me.oAduanales.Existe = False Then
                    Me.TxtModelo.Text = "" : GoTo Buscar : Exit Sub
                End If

                Me.lblNombrelblAduanaExtranjera.Text = Me.oAduanales.NOMBRE_AGENCIA_ADUANA
                Me.TxtAduanaNacional.Focus()
        End Select
    End Sub

    Private Sub TxtAduanaNacional_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtAduanaNacional.KeyDown
        Dim sText As String
        Dim oAduanales As New Class_CatAgenciaAduanales
        Select Case e.KeyCode
            Case Keys.F6
Buscar:
                sText = Me.oAduanales.BusquedaVisual_PorDescripcion_AduanasNacionales
                If txtLEN(sText) = True Then Me.TxtAduanaNacional.Text = sText
            Case Keys.Enter
                If txtLEN(Me.TxtAduanaNacional.Text) = False Then
                    Me.lblNombrelblAduanaNacional.Text = "" : GoTo Buscar : Exit Sub
                End If

                Me.oAduanales = New Class_CatAgenciaAduanales(Me.TxtAduanaNacional.Text)
                If Me.oAduanales.Existe = False Then
                    Me.lblNombrelblAduanaNacional.Text = "" : GoTo Buscar : Exit Sub
                End If

                Me.lblNombrelblAduanaNacional.Text = Me.oAduanales.NOMBRE_AGENCIA_ADUANA
                Me.TxtChofer.Focus()
        End Select
    End Sub

    Private Sub DtpFechas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtpFecha.KeyDown, dtpFechaEntrega.KeyDown, DtpFechaSalida.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.Send("{TAB}")
        End Select
    End Sub

    Private Sub TxtObservaciones_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtObservaciones.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                Me.TxtTemperatura.Focus()
        End Select
    End Sub

    Private Sub TxtTemperatura_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtTemperatura.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                Me.TxtSellos.Focus()
        End Select
    End Sub

    Private Sub TxtSellos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtSellos.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                Me.Grid.Cell(1, 1).SetFocus()
        End Select
    End Sub

    Private Sub cboEstado_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboEstado.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                Me.cboAlmacen.Focus()
        End Select
    End Sub

    Private Sub cboAlmacen_KeyDown(sender As Object, e As KeyEventArgs) Handles cboAlmacen.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                Me.cboEmpaque.Focus()
        End Select
    End Sub

    Private Sub CboLugarEntrega_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CboLugarEntrega.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If Me.oDocumento.CODIGO_MERCADO = "E" Then
                    'Me.TxtObservaciones.Focus()
                    Me.cboAlmacen.Focus()
                Else
                    Me.cboEstado.Focus()
                End If
        End Select
    End Sub

    Private Sub Grid_KeyDown(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Grid.KeyDown
        Me.GestionaGrid(e)
        'Me.FormateaGrid()
    End Sub

    Private Sub cboEmpaque_KeyDown(sender As Object, e As KeyEventArgs) Handles cboEmpaque.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                Me.TxtObservaciones.Focus()
        End Select
    End Sub
#End Region

#Region "Eventos Genericos"
    Private Sub txtTextoKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFolioEmbarque.KeyPress, TxtCliente.KeyPress,
     txtCaja.KeyPress, DtpFecha.KeyPress, dtpFechaEntrega.KeyPress, DtpFechaSalida.KeyPress, TxtObservaciones.KeyPress, TxtSellos.KeyPress, txtFolioViaje.KeyPress, cboEstado.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub txtNumerosEnterosKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFolioAARC.KeyPress, Grid.KeyPress,
    txtCodigoTransporte.KeyPress, TxtAduanaNacional.KeyPress, TxtAduanaExtranjera.KeyPress, TxtTemperatura.KeyPress
        txtSoloNumerosEnteros(e)
        txtNoBeep(e)
    End Sub

    Private Sub txtNumerosDecimalKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFleteImporte.KeyPress
        Dim txt As TextBox = CType(sender, TextBox)
        txtSoloNumerosDecimales(e, txt.Text)
        txtNoBeep(e)
    End Sub

    Private Sub Cbo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CboDistribuidor.KeyDown, CboEmbarcador.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.Send("{TAB}")
        End Select
    End Sub
#End Region

#Region "Keydown específicos"
    Private Sub Grid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Grid.DoubleClick
        Try
            Dim Columna As Integer, Renglon As Integer, vdg As String

            Columna = Me.Grid.Selection.FirstCol
            Renglon = Me.Grid.Selection.FirstRow

            vdg = Me.Grid.Cell(Renglon, Me.igyCodigoPalet).Text 'Grid.Rows(Renglon).Cell("FOLIO_POLIZA")
            If txtLEN(vdg) = False Then
                Exit Sub
            End If
            Dim Child As New Frm_Embarques_ArmadoPalets()
            Child.FolioEmbarqueConsultaExterior = vdg.ToString
            Child.ShowDialog()
            Child.Dispose()
            Dim sql As New Class_find("SELECT CANTIDAD_TOTAL_PALET,PESO_TOTAL_PALET,IMPORTE_TOTAL_PALET,  " &
                    "CASE WHEN ISNULL( SALIDA_EMPAQUE_GENERADA,'0')='0' THEN 'NO' ELSE 'SI' END AS SALIDA_EMPAQUE_GENERADA     " &
                    "FROM EMB_PALETS_GLOBAL Where FOLIO_PALET='" & vdg & "'")

            Me.Grid.Cell(Renglon, Me.igyCodigoPalet).Text = vdg
            Me.Grid.Cell(Renglon, Me.igyBultos).Text = sql.Result1
            Me.Grid.Cell(Renglon, Me.igyPeso).Text = sql.Result2
            Me.Grid.Cell(Renglon, Me.igyImporte).Text = sql.Result3
            Me.Grid.Cell(Renglon, Me.igySalida).Text = sql.Result4
            Me.Totales()
        Catch ex As Exception
            HandleError(Me.Name, "Grid_DoubleClick", ex)
        End Try
    End Sub

    Private Sub btnEmbarqueAdicional_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmbarqueAdicional.Click
        Me.InicializaEmbarqueAdicional()
    End Sub

    Private Sub BtnGeneraFlete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGeneraFlete.Click
        If Me.Grabar(False) = True Then
            MsgBox("Se ha generado el flete del satisfactoriamente.", MsgBoxStyle.Information, Me.Text)
        Else
            MsgBox("El flete no se genero, puede revisarlo en el reporte de embarque que no generaron fletes", MsgBoxStyle.Exclamation, Me.Text)
        End If
        Me.Consultar()
    End Sub

    Private Sub BtnGeneraSalida_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGeneraSalida.Click
        If Me.GeneraSalida() = True Then
            Me.Consultar()
        End If
    End Sub

    Private Sub tsbImprimirEtiquetasPalets_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimirEtiquetasPalets.Click
        Dim Child As New Frm_Embarques_Etiquetas_Palets
        Child.FolioEmbarque = Me.txtFolioEmbarque.Text
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.ShowDialog()
        Child.Dispose()
    End Sub

    Private Sub btnCambiarPrecios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCambiarPrecios.Click
        Dim Child As New Frm_Embarques_CambiaPreciosPalets
        Child.txtFolioEmbarque.Text = Me.txtFolioEmbarque.Text
        Child.DtpFecha.Value = Me.DtpFecha.Value
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.ShowDialog()
        Child.Dispose()
        Me.Consultar()
    End Sub

    Private Sub txtFolioPedimento_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFolioPedimento.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.btnGrabarFolioPedimento.Focus()
        End If
    End Sub
#End Region

#End Region

#Region "Métodos y procedimientos"
    Private Sub Inicializa()
        Try
            Me.txtFolioViaje.Text = ""
            Me.txtFolioEmbarque.Text = ""
            Me.txtFolioAARC.Text = ""
            Me.TxtCliente.Text = "" : Me.lblNombreCliente.Text = ""
            Me.txtCodigoTransporte.Text = "" : Me.TxtMarca.Text = "" : Me.TxtModelo.Text = "" : Me.TxtPlacas.Text = ""
            Me.txtLinea.Text = ""
            Me.txtCaja.Text = "" : Me.lblNombreCaja.Text = "" : Me.TxtPlacasCaja.Text = ""
            Me.TxtAduanaExtranjera.Text = "" : Me.lblNombrelblAduanaExtranjera.Text = ""
            Me.TxtAduanaNacional.Text = "" : Me.lblNombrelblAduanaNacional.Text = ""
            Me.TxtChofer.Text = "" : Me.lblNombreChofer.Text = ""

            Me.DtpFecha.Value = Date.Now
            Me.dtpFechaEntrega.Value = Date.Now
            Me.DtpFechaSalida.Value = Date.Now

            Me.TxtTemperatura.Text = "45"
            Me.TxtSellos.Text = ""
            Me.TxtObservaciones.Text = ""

            Me.TxtTotalImporte.Text = "0"
            Me.TxtTotalPeso.Text = "0"
            Me.txtTotalBultos.Text = "0"
            Me.CboLugarEntrega.SelectedValue = 0
            Me.cboEstado.SelectedValue = 0
            Me.txtFolioFactura.Text = ""
            Me.cboAlmacen.SelectedValue = 0
            Me.lblFolioEntradaAlmacen.Text = ""

            Me.txtFleteImporte.Text = FormatImporteContable(0)

            Me.InicializaGrid()

            Me.oEmbarque = New Class_Embarques_EmbarqueGlobal(Me.cboDocumento.SelectedValue.ToString)

            Me.LblStatus.Text = "N"

            Me.GeneraFolio()

            Me.btnFacturar.Enabled = False
            Me.btnCancelarFactura.Enabled = False
            'Me.btnExportarArchivos.Enabled = False
            Me.btnTimbrarFactura.Enabled = False

            If Me.oDocumento.CODIGO_MERCADO = "E" Then
                Me.GeneraFolioAARC()
            End If

            Me.txtFolioPedimento.Text = ""

        Catch ex As Exception
            HandleError(Me.Name, "Inicializa", ex)
        End Try
    End Sub

    Private Sub InicializaGrid()
        Try
            Me.Grid.DataSource = Nothing
            FG_Grid_Limpiar(Me.Grid)
            Me.Grid.Rows = 2
            Me.Grid.Cols = 7
            Me.FormateaGrid()
        Catch ex As Exception
            HandleError(Me.Name, "InicializaGrid", ex)
        End Try
    End Sub

    Private Sub InicializaEmbarqueAdicional()
        Try
            Dim sFolioViaje As String = Me.txtFolioViaje.Text
            Dim sFolioEmbarqueAdicional As String = Me.oEmbarque.GeneraFolioEmbarqueAdicional
            Me.Inicializa()
            Me.Cambia_Estado(enumEstados.NUEVO_ADICIONAL)
            Me.txtFolioViaje.Text = sFolioViaje
            Me.txtFolioEmbarque.Text = sFolioEmbarqueAdicional
        Catch ex As Exception
            HandleError(Me.Name, "InicializaEmbarqueAdicional", ex)
        End Try
    End Sub

    Private Sub FormateaGrid()
        Try
            Dim i As Integer

            Me.Grid.Column(Me.igyCodigoPalet).Width = 90
            Me.Grid.Column(Me.igyBultos).Width = 100
            Me.Grid.Column(Me.igyPeso).Width = 100
            Me.Grid.Column(Me.igyImporte).Width = 100
            Me.Grid.Column(Me.igySalida).Width = 100
            Me.Grid.Column(Me.igyGenerarSalida).Width = 100

            Me.Grid.Cell(0, Me.igyCodigoPalet).Text = "CódigoPalet"
            Me.Grid.Cell(0, Me.igyBultos).Text = "Cantidad"
            Me.Grid.Cell(0, Me.igyPeso).Text = "Peso"
            Me.Grid.Cell(0, Me.igyImporte).Text = "Importe"
            Me.Grid.Cell(0, Me.igySalida).Text = "Salida"
            Me.Grid.Cell(0, Me.igyGenerarSalida).Text = "Generar Salida"

            Me.Grid.Column(Me.igyBultos).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.igyPeso).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.igyPeso).DecimalLength = Empresa_Sistema.DECIMALES_PESO_BULTOS
            Me.Grid.Column(Me.igyPeso).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.igyImporte).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
            Me.Grid.Column(Me.igyImporte).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.igyImporte).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
            Me.Grid.Column(Me.igyImporte).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.igySalida).Alignment = FlexCell.AlignmentEnum.CenterCenter

            Me.Grid.Column(Me.igyCodigoPalet).Locked = False
            Me.Grid.Column(Me.igyBultos).Locked = True
            Me.Grid.Column(Me.igyPeso).Locked = True
            Me.Grid.Column(Me.igyImporte).Locked = True
            Me.Grid.Column(Me.igySalida).Locked = True
            Me.Grid.Column(Me.igySalida).Visible = False
            Me.Grid.Column(Me.igyGenerarSalida).Locked = True
            Me.Grid.Column(Me.igyGenerarSalida).Visible = False

            For i = 1 To Me.Grid.Rows - 1
                If (txtLEN(Me.Grid.Cell(i, Me.igyCodigoPalet).Text) = True) And (txtLEN(Me.Grid.Cell(i, Me.igySalida).Text) = True) Then
                    If Me.Grid.Cell(i, Me.igySalida).Text = "1" Or Me.Grid.Cell(i, Me.igySalida).Text = "SI" Then
                        Me.Grid.Row(i).Locked = True
                    End If
                End If
            Next i

        Catch ex As Exception
            HandleError(Me.Name, "FormateaGrid", ex)
        End Try
    End Sub

    Private Sub Cambia_Estado(ByVal pEstado As enumEstados)
        Try
            Me.Estado = pEstado

            Select Case Me.Estado
                Case enumEstados.NUEVO
                    Me.tsbNuevo.Enabled = True
                    Me.tsbGrabar.Enabled = True
                    Me.tsbCancelar.Enabled = False
                    Me.tsbImprimir.Enabled = False
                    Me.btnEmbarqueAdicional.Enabled = False
                    Me.BtnGeneraFlete.Enabled = False
                    Me.BtnGeneraSalida.Enabled = False

                    Me.cboDocumento.Enabled = True
                    Me.CboDistribuidor.Enabled = True
                    Me.CboEmbarcador.Enabled = True
                    Me.TxtChofer.Enabled = True
                    Me.CboLugarEntrega.Enabled = True
                    Me.cboEstado.Enabled = True
                    Me.txtFolioViaje.Enabled = True
                    Me.txtFolioEmbarque.Enabled = True
                    Me.txtFolioAARC.Enabled = True
                    Me.TxtCliente.Enabled = True
                    Me.txtCodigoTransporte.Enabled = True
                    Me.txtCaja.Enabled = True
                    Me.TxtAduanaExtranjera.Enabled = True
                    Me.TxtAduanaNacional.Enabled = True
                    Me.TxtTemperatura.Enabled = True
                    Me.TxtSellos.Enabled = True
                    Me.DtpFecha.Enabled = True
                    Me.dtpFechaEntrega.Enabled = True
                    Me.DtpFechaSalida.Enabled = True
                    Me.TxtObservaciones.Enabled = True
                    Me.txtFolioFactura.Enabled = True
                    Me.Grid.Locked = False
                    Me.btnCambiarPrecios.Enabled = False
                    Me.txtFolioPedimento.Visible = False : Me.lblDisplayFolioPedimento.Visible = False : Me.btnGrabarFolioPedimento.Visible = False

                    Me.tsslEstado.Text = "Estado: Agregando nuevo movimiento"
                    Me.tsslElaboro.Visible = False : Me.tsslElaboro.Text = ""
                    Me.tsslCancelo.Visible = False : Me.tsslCancelo.Text = ""

                    If Me.Visible = True Then
                        Me.txtFolioEmbarque.Focus()
                    End If

                Case enumEstados.NUEVO_ADICIONAL
                    Me.tsbNuevo.Enabled = True
                    Me.tsbGrabar.Enabled = True
                    Me.tsbCancelar.Enabled = True
                    Me.tsbImprimir.Enabled = True
                    Me.btnEmbarqueAdicional.Enabled = True
                    Me.BtnGeneraFlete.Enabled = False
                    Me.BtnGeneraSalida.Enabled = False

                    Me.cboDocumento.Enabled = False
                    Me.CboDistribuidor.Enabled = True
                    Me.CboEmbarcador.Enabled = True
                    Me.TxtChofer.Enabled = True
                    Me.CboLugarEntrega.Enabled = True
                    Me.cboEstado.Enabled = True
                    Me.txtFolioViaje.Enabled = False
                    Me.txtFolioEmbarque.Enabled = False
                    Me.txtFolioAARC.Enabled = True
                    Me.TxtCliente.Enabled = True
                    Me.txtCodigoTransporte.Enabled = True
                    Me.txtCaja.Enabled = True
                    Me.TxtAduanaExtranjera.Enabled = True
                    Me.TxtAduanaNacional.Enabled = True
                    Me.TxtTemperatura.Enabled = True
                    Me.TxtSellos.Enabled = True
                    Me.DtpFecha.Enabled = True
                    Me.dtpFechaEntrega.Enabled = True
                    Me.DtpFechaSalida.Enabled = True
                    Me.TxtObservaciones.Enabled = True
                    Me.txtFolioFactura.Enabled = True
                    Me.Grid.Locked = False
                    Me.btnCambiarPrecios.Enabled = False
                    Me.txtFolioPedimento.Visible = False : Me.lblDisplayFolioPedimento.Visible = False : Me.btnGrabarFolioPedimento.Visible = False

                    Me.tsslEstado.Text = "Estado: Agregando embarque adicional"
                    Me.tsslElaboro.Visible = False : Me.tsslElaboro.Text = ""
                    Me.tsslCancelo.Visible = False : Me.tsslCancelo.Text = ""

                    Me.TxtObservaciones.Focus()

                Case enumEstados.APLICADO
                    Me.tsbNuevo.Enabled = True
                    Me.tsbGrabar.Enabled = True
                    Me.tsbCancelar.Enabled = True
                    Me.tsbImprimir.Enabled = True
                    Me.btnEmbarqueAdicional.Enabled = True
                    'Me.BtnGeneraFlete.Enabled = True
                    'Me.BtnGeneraSalida.Enabled = True

                    Me.cboDocumento.Enabled = False
                    Me.CboDistribuidor.Enabled = True
                    Me.CboEmbarcador.Enabled = True
                    Me.TxtChofer.Enabled = True
                    Me.CboLugarEntrega.Enabled = True
                    Me.cboEstado.Enabled = True
                    Me.txtFolioViaje.Enabled = False
                    Me.txtFolioEmbarque.Enabled = False
                    Me.txtFolioAARC.Enabled = True
                    Me.TxtCliente.Enabled = True
                    Me.txtCodigoTransporte.Enabled = True
                    Me.txtCaja.Enabled = True
                    Me.TxtAduanaExtranjera.Enabled = True
                    Me.TxtAduanaNacional.Enabled = True
                    Me.TxtTemperatura.Enabled = True
                    Me.TxtSellos.Enabled = True
                    Me.DtpFecha.Enabled = True
                    Me.dtpFechaEntrega.Enabled = True
                    Me.DtpFechaSalida.Enabled = True
                    Me.TxtObservaciones.Enabled = True
                    Me.txtFolioFactura.Enabled = True
                    Me.Grid.Locked = False
                    Me.btnCambiarPrecios.Enabled = True
                    Me.txtFolioPedimento.Visible = True : Me.lblDisplayFolioPedimento.Visible = True : Me.btnGrabarFolioPedimento.Visible = True

                    Me.tsslEstado.Text = "Estado: Consultando movimiento"
                    Me.tsslElaboro.Visible = True : Me.tsslElaboro.Text = "Elaboró: " + Me.oEmbarque.NOMBRE_USUARIO_GRABO.ToUpper + " el " + Format(Me.DtpFecha.Value, "dd/MMM/yy").ToUpper
                    Me.tsslCancelo.Visible = False : Me.tsslCancelo.Text = ""

                    Me.TxtObservaciones.Focus()

                Case enumEstados.CANCELADO
                    Me.tsbNuevo.Enabled = True
                    Me.tsbGrabar.Enabled = False
                    Me.tsbCancelar.Enabled = False
                    Me.tsbImprimir.Enabled = True
                    Me.btnEmbarqueAdicional.Enabled = False
                    Me.BtnGeneraFlete.Enabled = False
                    Me.BtnGeneraSalida.Enabled = False

                    Me.cboDocumento.Enabled = False
                    Me.CboDistribuidor.Enabled = False
                    Me.CboEmbarcador.Enabled = False
                    Me.TxtChofer.Enabled = False
                    Me.CboLugarEntrega.Enabled = False
                    Me.cboEstado.Enabled = False
                    Me.txtFolioViaje.Enabled = False
                    Me.txtFolioEmbarque.Enabled = False
                    Me.txtFolioAARC.Enabled = False
                    Me.TxtCliente.Enabled = False
                    Me.txtCodigoTransporte.Enabled = False
                    Me.txtCaja.Enabled = False
                    Me.TxtAduanaExtranjera.Enabled = False
                    Me.TxtAduanaNacional.Enabled = False
                    Me.TxtTemperatura.Enabled = False
                    Me.TxtSellos.Enabled = False
                    Me.DtpFecha.Enabled = False
                    Me.dtpFechaEntrega.Enabled = False
                    Me.DtpFechaSalida.Enabled = False
                    Me.TxtObservaciones.Enabled = False
                    Me.txtFolioFactura.Enabled = False
                    Me.Grid.Locked = True
                    Me.btnCambiarPrecios.Enabled = False
                    Me.txtFolioPedimento.Visible = False : Me.lblDisplayFolioPedimento.Visible = False : Me.btnGrabarFolioPedimento.Visible = False

                    Me.tsslEstado.Text = "Estado: Consultando movimiento"
                    Me.tsslElaboro.Visible = True : Me.tsslElaboro.Text = "Elaboró: " + Me.oEmbarque.NOMBRE_USUARIO_GRABO.ToUpper + " el " + Format(Me.DtpFecha.Value, "dd/MMM/yy").ToUpper
                    Me.tsslCancelo.Visible = True : Me.tsslCancelo.Text = "Canceló: " + Me.oEmbarque.NOMBRE_USUARIO_CANCELO.ToUpper + " el " + Format(Me.oEmbarque.FECHA_CANCELACION, "dd/MMM/yy").ToUpper

                    Dim i As Integer
                    For i = 1 To Me.Grid.Rows - 1
                        Me.Grid.Cell(i, Me.igySalida).Text = "NO"
                    Next i

                    Me.tsbImprimir.Select()

                Case enumEstados.FACTURADO
                    Me.tsbNuevo.Enabled = True
                    Me.tsbGrabar.Enabled = False
                    Me.tsbCancelar.Enabled = False
                    Me.tsbImprimir.Enabled = True
                    Me.btnEmbarqueAdicional.Enabled = False
                    'Me.BtnGeneraFlete.Enabled = False
                    'Me.BtnGeneraSalida.Enabled = False

                    Me.cboDocumento.Enabled = False
                    Me.CboDistribuidor.Enabled = False
                    Me.CboEmbarcador.Enabled = False
                    Me.TxtChofer.Enabled = False
                    Me.CboLugarEntrega.Enabled = False
                    Me.cboEstado.Enabled = False
                    Me.txtFolioViaje.Enabled = False
                    Me.txtFolioEmbarque.Enabled = False
                    Me.txtFolioAARC.Enabled = False
                    Me.TxtCliente.Enabled = False
                    Me.txtCodigoTransporte.Enabled = False
                    Me.txtCaja.Enabled = False
                    Me.TxtAduanaExtranjera.Enabled = False
                    Me.TxtAduanaNacional.Enabled = False
                    Me.TxtTemperatura.Enabled = False
                    Me.TxtSellos.Enabled = False
                    Me.DtpFecha.Enabled = False
                    Me.dtpFechaEntrega.Enabled = False
                    Me.DtpFechaSalida.Enabled = False
                    Me.TxtObservaciones.Enabled = False
                    Me.txtFolioFactura.Enabled = False
                    Me.Grid.Locked = True
                    Me.btnCambiarPrecios.Enabled = False
                    Me.txtFolioPedimento.Visible = False : Me.lblDisplayFolioPedimento.Visible = False : Me.btnGrabarFolioPedimento.Visible = False

                    Me.tsslEstado.Text = "Estado: Consultando movimiento"
                    Me.tsslElaboro.Visible = True : Me.tsslElaboro.Text = "Elaboró: " + Me.oEmbarque.NOMBRE_USUARIO_GRABO.ToUpper + " el " + Format(Me.DtpFecha.Value, "dd/MMM/yy").ToUpper
                    Me.tsbImprimir.Select()
            End Select

            Me.OcultarControles()

            Application.DoEvents()

        Catch ex As Exception
            HandleError(Me.Name, "Cambia_Estado", ex)
        End Try
    End Sub

    Function Grabar(Optional ByVal bConfirmacion As Boolean = True) As Boolean
        Dim bResultado As Boolean = False
        Dim i As Integer

        If bConfirmacion = True Then
            If MsgBox("Deseas grabar el " & Me.cboDocumento.Text & " con el folio : " & Me.txtFolioEmbarque.Text & " ?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "Grabar") = MsgBoxResult.No Then
                Exit Function
            End If
        End If

        'Validar permiso
        If Usuario.ValidaPermisoUsuarioDocumentoSinAfectacionInventarios(Me.cboDocumento.SelectedValue.ToString) = False Then
            MsgBox("El usuario " & Usuario.Nombre_Usuario & " no tiene permiso para realizar el movimiento.", MsgBoxStyle.Information, Me.Text)
            Exit Function
        End If

        Me.Totales()

        If Me.ValidarEmbarque() = False Then
            Exit Function
        End If

        'Validan que no se repitan(todos contra todos)
        Try
            With Me.oEmbarque
                .FOLIO_EMBARQUE = Me.txtFolioEmbarque.Text
                .CODIGO_DOCUMENTO = Me.cboDocumento.SelectedValue.ToString
                .CODIGO_MERCADO = Me.oDocumento.CODIGO_MERCADO
                .FOLIO_AARC = Me.txtFolioAARC.Text
                .FECHA = Me.DtpFecha.Value
                .FECHA_SALIDA = Me.DtpFechaSalida.Value
                .FECHA_ENTREGA = Me.dtpFechaEntrega.Value
                .CODIGO_DISTRIBUIDOR = Me.CboDistribuidor.SelectedValue.ToString
                .CODIGO_EMBARCADOR = Me.CboEmbarcador.SelectedValue.ToString
                .CODIGO_CLIENTE = Me.TxtCliente.Text
                .CODIGO_TRANSPORTE = Me.txtCodigoTransporte.Text
                .CODIGO_CHOFER = Me.TxtChofer.Text
                .CODIGO_CAJA = Me.txtCaja.Text
                .OBSERVACIONES = Me.TxtObservaciones.Text
                .CODIGO_ADUANA_EXTRANJERA = Me.TxtAduanaExtranjera.Text
                .CODIGO_ADUANA_NACIONAL = Me.TxtAduanaNacional.Text
                .TEMPERATURA = valorNumerico(Me.TxtTemperatura.Text)
                .SELLO = Me.TxtSellos.Text
                .TOTAL_BULTOS = CInt(Me.txtTotalBultos.Text)
                .TOTAL_PESO = valorNumerico(Me.TxtTotalPeso.Text)
                .TOTAL_DINERO = valorNumerico(Me.TxtTotalImporte.Text)
                .CODIGO_LUGAR_ENTREGA = CInt(Me.CboLugarEntrega.SelectedValue)
                If txtLEN(Me.cboEstado.Text) = True Then
                    .CODIGO_ESTADO_DESTINO = Me.cboEstado.SelectedValue.ToString()
                Else
                    .CODIGO_ESTADO_DESTINO = ""
                End If
                .FLETE_IMPORTE = valorNumerico(Me.txtFleteImporte.Text)
                .CODIGO_ALMACEN = Me.cboAlmacen.SelectedValue.ToString
                .CODIGO_EMPAQUE = Me.cboEmpaque.SelectedValue.ToString

                If Me.Estado = enumEstados.NUEVO Or Me.Estado = enumEstados.NUEVO_ADICIONAL Then
                    If .Insertar(IIf(Me.btnEmbarqueAdicional.Enabled = True, "INSERTAR_ADICIONAL", "INSERTAR_BASE").ToString) = False Then
                        MsgBox("Error al tratar de insertar el movimiento de embarques.", MsgBoxStyle.Exclamation, Me.Text)
                        Exit Function
                    End If
                    Me.txtFolioEmbarque.Text = .FOLIO_EMBARQUE
                Else
                    If Me.oEmbarque.IMPORTE_FLETE <> Me.oEmbarque.SALDO_FLETE Then
                        Exit Function
                    Else
                        If Me.ValidarFlete() = False Then
                            Exit Function
                        End If
                    End If

                    If .Actualizar() = False Then
                        MsgBox("Error al tratar de actualizar el movimiento de embarques.", MsgBoxStyle.Exclamation, Me.Text)
                        Exit Function
                    End If
                End If

                'SE GRABA EL DETALLE DE EMBARQUE
                For i = 1 To Me.Grid.Rows - 1
                    If txtLEN(Me.Grid.Cell(i, Me.igyCodigoPalet).Text) = True Then
                        .NuevoRenglon()
                        .oEmbarqueDetalle.FOLIO_EMBARQUE = Me.txtFolioEmbarque.Text
                        .oEmbarqueDetalle.FOLIO_PALET = Me.Grid.Cell(i, Me.igyCodigoPalet).Text.ToUpper
                        If .oEmbarqueDetalle.GrabaRenglonEmbarque() = False Then
                            MsgBox("Error al tratar de grabar el detalle.", MsgBoxStyle.Exclamation, Me.Text)
                            Exit Function
                        End If
                    End If
                Next

                Me.oEmbarque = New Class_Embarques_EmbarqueGlobal(Me.txtFolioEmbarque.Text, Me.cboDocumento.SelectedValue.ToString)
                If Me.oEmbarque.ENTRADA_ALMACEN_GENERADA = False Then
                    If Me.oEmbarque.GenerarEntradaInventario = True Then
                        MsgBox("Se generó la entrada de inventario.", MsgBoxStyle.Information, Me.Text)
                    End If
                End If

                If Me.txtFolioEmbarque.Text = Me.txtFolioViaje.Text Then
                    Me.oEmbarque = New Class_Embarques_EmbarqueGlobal(Me.txtFolioEmbarque.Text, Me.cboDocumento.SelectedValue.ToString)
                    If Me.oEmbarque.Existe = False Then
                        Exit Function
                    End If

                    If Me.oDocumento.CODIGO_MERCADO = "E" Then
                        'Se quitó temporalmente para bi luego se van a retomar las salidas
                        'If Me.GeneraFlete() = False And bConfirmacion = True Then
                        '    MsgBox("Movimiento de embarque ha sido grabado satisfactoriamente, sin generar flete y/o salida.", MsgBoxStyle.Information, Me.Text)
                        'ElseIf bConfirmacion = True Then
                        '    MsgBox("Movimiento de embarque ha sido grabado satisfactoriamente.", MsgBoxStyle.Information, Me.Text)
                        'End If
                        If bConfirmacion = True Then
                            MsgBox("Movimiento de embarque ha sido grabado satisfactoriamente.", MsgBoxStyle.Information, Me.Text)
                        End If

                    ElseIf bConfirmacion = True Then
                        MsgBox("Movimiento de embarque ha sido grabado satisfactoriamente.", MsgBoxStyle.Information, Me.Text)
                    End If
                Else
                    If bConfirmacion = True Then
                        MsgBox("Movimiento de embarque ha sido grabado satisfactoriamente.", MsgBoxStyle.Information, Me.Text)
                    End If
                End If
                bResultado = True
            End With
        Catch ex As Exception
            HandleError(Me.Name, "Grabar", ex)
        End Try
        Return bResultado
    End Function

    Private Function EliminarPaletSalida(ByVal sFolioPalet As String) As Boolean
        Dim bResultado As Boolean = False
        If MsgBox("Deseas eliminar el palet seleccionado ?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "eliminarPaletSalida") = MsgBoxResult.No Then
            Exit Function
        End If

        'Validar permiso
        If Usuario.ValidaPermisoUsuarioDocumentoSinAfectacionInventarios(Me.cboDocumento.SelectedValue.ToString) = False Then
            MsgBox("El usuario " & Usuario.Nombre_Usuario & " no tiene permiso para realizar el movimiento.", MsgBoxStyle.Information, Me.Text)
            Exit Function
        End If

        'SE GRABA EL DETALLE DE EMBARQUE
        Try
            With Me.oEmbarque
                .oEmbarqueDetalle.FOLIO_EMBARQUE = Me.txtFolioEmbarque.Text
                .oEmbarqueDetalle.FOLIO_PALET = sFolioPalet.ToUpper
                If .oEmbarqueDetalle.EliminaSalidaPalet() = False Then
                    MsgBox("Error al tratar de eliminar palet con salida.", MsgBoxStyle.Exclamation, Me.Text)
                    Exit Function
                End If

                bResultado = True
                MsgBox("Movimiento ha sido grabado satisfactoriamente.", MsgBoxStyle.Information, Me.Text)
                Me.Consultar()
            End With
        Catch ex As Exception
            HandleError(Me.Name, "EliminarPaletSalida", ex)
        End Try
        Return bResultado
    End Function

    Private Function Consultar() As Boolean
        Dim bResultado As Boolean = False

        Try
            Dim dTabla As DataTable
            Dim sEmbarque As String = Me.txtFolioEmbarque.Text
            Me.Inicializa()

            Me.oEmbarque = New Class_Embarques_EmbarqueGlobal(sEmbarque, Me.cboDocumento.SelectedValue.ToString)

            If Me.oEmbarque.Existe = False Then
                Me.Cambia_Estado(enumEstados.NUEVO)
                Me.txtFolioViaje.Enabled = False
                Me.txtFolioEmbarque.Enabled = False
                Exit Function
            Else
                Me.cboDocumento.SelectedValue = Me.oEmbarque.CODIGO_DOCUMENTO.ToString
                Me.oEmbarque = New Class_Embarques_EmbarqueGlobal(sEmbarque, Me.cboDocumento.SelectedValue.ToString)

                If Me.oDocumento.CODIGO_MERCADO = "E" Then
                    Me.txtFolioAARC.Text = Me.oEmbarque.FOLIO_AARC.ToString

                    Me.TxtAduanaExtranjera.Text = Me.oEmbarque.CODIGO_ADUANA_EXTRANJERA
                    Me.oAduanales = New Class_CatAgenciaAduanales(Me.oEmbarque.CODIGO_ADUANA_EXTRANJERA)
                    Me.lblNombrelblAduanaExtranjera.Text = Me.oAduanales.NOMBRE_AGENCIA_ADUANA

                    Me.TxtAduanaNacional.Text = Me.oEmbarque.CODIGO_ADUANA_NACIONAL
                    Me.oAduanales = New Class_CatAgenciaAduanales(Me.oEmbarque.CODIGO_ADUANA_NACIONAL)
                    Me.lblNombrelblAduanaNacional.Text = Me.oAduanales.NOMBRE_AGENCIA_ADUANA

                    If Me.oEmbarque.FLETE_GENERADO = "1" Then
                        Me.BtnGeneraFlete.Enabled = False
                    Else
                        Me.BtnGeneraFlete.Enabled = True
                    End If
                End If

                If Me.oEmbarque.SALIDA_EMPAQUE_GENERADA = "1" Then
                    Me.BtnGeneraSalida.Enabled = False
                Else
                    Me.BtnGeneraSalida.Enabled = True
                End If
                Me.CboEmbarcador.SelectedValue = Me.oEmbarque.CODIGO_EMBARCADOR
                Me.txtFolioViaje.Text = Me.oEmbarque.FOLIO_VIAJE.ToString.ToUpper
                Me.txtFolioEmbarque.Text = Me.oEmbarque.FOLIO_EMBARQUE.ToString.ToUpper
                Me.CboDistribuidor.SelectedValue = Me.oEmbarque.CODIGO_DISTRIBUIDOR
                Me.TxtCliente.Text = Me.oEmbarque.CODIGO_CLIENTE.ToString
                Me.oClientes = New Class_CatClientes(Me.oEmbarque.CODIGO_CLIENTE)
                Me.lblNombreCliente.Text = oClientes.NOMBRE_CLIENTE.ToUpper
                Me.LblStatus.Text = Me.oEmbarque.ESTATUS_EMBARQUE.ToString
                Me.TxtChofer.Text = Me.oEmbarque.CODIGO_CHOFER.ToUpper
                Me.oChoferes = New Class_CatChoferes(Me.oEmbarque.CODIGO_CHOFER)
                Me.lblNombreChofer.Text = Me.oChoferes.NOMBRE_CHOFER.ToUpper
                Me.TxtObservaciones.Text = Me.oEmbarque.OBSERVACIONES.ToString.ToUpper
                Me.txtCodigoTransporte.Text = Me.oEmbarque.CODIGO_TRANSPORTE.ToString
                Me.oTransporte = New Class_CatTransportes(Me.oEmbarque.CODIGO_TRANSPORTE)
                Me.TxtMarca.Text = oTransporte.MARCA.ToString
                Me.TxtModelo.Text = oTransporte.MODELO.ToString
                Me.TxtPlacas.Text = oTransporte.PLACA.ToString
                Me.txtLinea.Text = oTransporte.NOMBRE_LINEA_TRANSPORTE.ToString
                Me.txtCaja.Text = Me.oEmbarque.CODIGO_CAJA.ToString
                Me.oCajas = New Class_CatCajasTransportes(Me.oEmbarque.CODIGO_CAJA)
                Me.lblNombreCaja.Text = oCajas.NOMBRE_CAJA
                Me.TxtPlacasCaja.Text = oCajas.PLACA
                Me.TxtTemperatura.Text = CStr(Me.oEmbarque.TEMPERATURA)
                Me.TxtSellos.Text = Me.oEmbarque.SELLO
                Me.DtpFecha.Value = CDate(Me.oEmbarque.FECHA)
                Me.DtpFechaSalida.Value = CDate(Me.oEmbarque.FECHA_SALIDA)
                Me.dtpFechaEntrega.Value = CDate(Me.oEmbarque.FECHA_ENTREGA)
                Me.txtTotalBultos.Text = FormatNumber(Me.oEmbarque.TOTAL_BULTOS.ToString, 0)
                Me.TxtTotalImporte.Text = FormatImporteContable(CDbl(Me.oEmbarque.TOTAL_DINERO.ToString))
                Me.TxtTotalPeso.Text = FormatNumber(Me.oEmbarque.TOTAL_PESO.ToString, Empresa_Sistema.DECIMALES_PESO_BULTOS)
                Me.CboLugarEntrega.SelectedValue = Me.oEmbarque.CODIGO_LUGAR_ENTREGA
                Me.cboEstado.SelectedValue = Me.oEmbarque.CODIGO_ESTADO_DESTINO
                Me.txtFolioFactura.Text = Me.oEmbarque.FOLIO_VENTA
                Me.txtFleteImporte.Text = FormatImporteContable(Me.oEmbarque.FLETE_IMPORTE)
                Me.cboAlmacen.SelectedValue = Me.oEmbarque.CODIGO_ALMACEN
                Me.lblFolioEntradaAlmacen.Text = Me.oEmbarque.FOLIO_ENTRADA_ALMACEN
                Me.txtFolioPedimento.Text = Me.oEmbarque.FOLIO_PEDIMENTO
                Me.cboEmpaque.SelectedValue = Me.oEmbarque.CODIGO_EMPAQUE

                Me.txtFolioViaje.Enabled = False
                Me.txtFolioEmbarque.Enabled = False

                dTabla = Me.oEmbarque.ObtenerDetalle
                Me.Grid.AutoRedraw = False
                Me.Grid.Rows = 1
                For Each dRow As DataRow In dTabla.Rows
                    Me.Grid.AddItem(dRow(0).ToString & Chr(9) & dRow(1).ToString & Chr(9) & dRow(2).ToString & Chr(9) & dRow(3).ToString & Chr(9) & dRow(4).ToString & Chr(9) & dRow(5).ToString & Chr(9))
                Next

                If Me.Grid.Rows = 1 Then
                    Me.Grid.Rows = 2
                End If

                Me.FormateaGrid()

            End If

            Me.DtpFecha.Value = CDate(Me.oEmbarque.FECHA)

            Me.GestionaCambioEstado()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''Relacionado a facturación''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.btnFacturar.Text = "Facturar"
            Me.btnFacturar.Enabled = False
            Me.btnCancelarFactura.Enabled = False
            Me.btnTimbrarFactura.Enabled = False

            If Me.oEmbarque.FACTURA_GENERADA = True Then
                Me.btnFacturar.Enabled = True
                Me.btnFacturar.Text = "Ver factura"
                'Me.btnExportarArchivos.Enabled = True

                Dim oVenta As New Class_Ventas_Global(Me.oEmbarque.FOLIO_VENTA)

                If oVenta.TIMBRADO_CFDI = "0" Then
                    Me.btnTimbrarFactura.Enabled = True
                End If

                Me.Cambia_Estado(enumEstados.FACTURADO) 'Se bloquea con este modo al embarque(no se le pueden hacer modificaciones)
            End If

            If txtLEN(Me.oEmbarque.CODIGO_TIPO_DOCUMENTO_FACTURA_EMBARQUE_EXTRANJERO) = True Then 'Me.oEmbarque.ES_FACTURA_EMBARQUE_EXTRANJERO = True Then
                Me.btnFacturar.Enabled = True 'Tambien se habilita aquí porque puede ser un embarque extranjero que aún no esté facturado.

                If Me.oEmbarque.FACTURA_GENERADA = True Then
                    Me.btnCancelarFactura.Enabled = True
                End If
            End If
            'Nota, si es nacional y no esta facturada el botón facturar no sera enabled, porque en esta pantalla no se puede facturar naciones, esto se hace desde la pantalla de facturas nacionales.

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim sql1 As New Class_find("SELECT COUNT(*) " & _
                  "FROM VW_EMB_EMBARQUE_DETALLE_EXTENDIDO WHERE FOLIO_EMBARQUE='" & Me.oEmbarque.FOLIO_EMBARQUE & "' AND GENERARA_SALIDA=1 AND SALIDA_EMPAQUE_GENERADA=0")
            If valorNumerico(sql1.Result1) < 1 Then
                Me.BtnGeneraSalida.Enabled = False
            End If

            bResultado = True
            Me.txtFolioEmbarque.Enabled = False

        Catch ex As Exception
            HandleError(Me.Name, "Consultar", ex)
        Finally
            Me.Grid.AutoRedraw = True
            Me.Grid.Refresh()
        End Try

        Return bResultado
    End Function

    Private Function Cancelar() As Boolean
        Dim bResultado As Boolean = False, sProcedure As String = "Cancelar"
        'Dim oUtileriasCancela As New Class_UtileriasFirmaElectronicaCancelacion

        Try
            If MsgBox("Deseas cancelar el movimiento de " & Me.txtFolioEmbarque.Text & " ?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, sProcedure) = MsgBoxResult.No Then
                Return False
            End If

            'Validar permiso
            If Usuario.ValidaPermisoUsuarioDocumentoSinAfectacionInventarios(Me.cboDocumento.SelectedValue.ToString) = False Then
                MsgBox("El usuario " & Usuario.Nombre_Usuario & " no tiene permiso para realizar el movimiento.", MsgBoxStyle.Information, sProcedure)
                Return False
            End If

            If Plaza.ValidarPeriodoTrabajo(Me.DtpFecha.Value) = False Then
                Return False
            End If

            Select Case Me.LblStatus.Text
                Case "N"
                    MsgBox("El embarque no existe.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                Case "A"
                    'No hay restricciones
                Case "C"
                    MsgBox("Los embarques cancelados no se pueden volver a cancelar.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
            End Select

            If Me.txtFolioEmbarque.Text = Me.txtFolioViaje.Text Then
                Me.oEmbarque = New Class_Embarques_EmbarqueGlobal(Me.txtFolioEmbarque.Text, Me.cboDocumento.SelectedValue.ToString)
                If Me.oEmbarque.Existe = False Then
                    Return False
                End If

                If Me.oEmbarque.FLETE_GENERADO = "1" Then
                    If Me.oEmbarque.IMPORTE_FLETE <> Me.oEmbarque.SALDO_FLETE Then
                        MsgBox("El flete del embarque ya tiene pagos generados no es posible cancelar el embarque.", MsgBoxStyle.Exclamation, sProcedure)
                        Return False
                    End If
                End If
            End If

            If Me.oEmbarque.SALIDA_EMPAQUE_GENERADA = "1" Then
                MsgBox("La salida del empaque ya esta generada. Si quiere cancelar el embarque avíse al depto. de sistemas.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            If Me.CancelaSalidaPalets() = False Then
                MsgBox("Las salidas generadas no se pudieron cancelar.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            If Me.GeneraMarcaSalida() = False Then
                MsgBox("Error al tratar de generar la marca de salida del embarque " & Me.txtFolioEmbarque.Text & " ", MsgBoxStyle.Critical, sProcedure)
            End If

            'If Me.oEmbarque.FLETE_GENERADO = "0" Then
            Me.oEmbarque.FECHA_CANCELACION = Date.Now 'oUtileriasCancela.FECHA_CANCELACION

            If Me.oEmbarque.Cancela() = False Then
                MsgBox("Error al intentar cancelar el movimiento.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            bResultado = True

            If bResultado = True Then
                MsgBox("El embarque " & Me.txtFolioEmbarque.Text & " se canceló satisfactoriamente.", MsgBoxStyle.Information, sProcedure)
            End If
            Me.Consultar()
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    Private Function GeneraMarcaSalida() As Boolean
        Dim bResultado As Boolean = False
        Try
            Dim sql As New Class_find("SELECT 1 FROM VW_EMB_EMBARQUE_DETALLE_EXTENDIDO " &
            "WHERE FOLIO_EMBARQUE='" & Me.txtFolioEmbarque.Text & "' AND SALIDA_EMPAQUE_GENERADA='0'")

            If sql.Result1 = "1" Then
                oEmbarque.MarcaSalidaEmpaqueGenerada(False) 'se desmarca
                Me.BtnGeneraSalida.Enabled = True
            Else
                oEmbarque.MarcaSalidaEmpaqueGenerada(True) 'se marca
                Me.BtnGeneraSalida.Enabled = False
            End If
            bResultado = True
        Catch ex As Exception
            HandleError(Me.Name, "GeneraMarcaSalida", ex)
        End Try

        Return bResultado
    End Function

    Private Function GeneraSalida() As Boolean
        'MsgBox("funcionalidad pausada , avíse al depto de sistemas.", MsgBoxStyle.Exclamation, Me.Text)
        'Return False
        Dim bResultado As Boolean = False
        Try
            'If Me.Grabar(False) = False Then
            '    Exit Function
            'End If

            'Dim i As Integer

            If Me.oEmbarque.GrabarSalidaMaterialEmpaque = False Then
                Return False
            End If

            Dim oInventario As New Inventarios_Movimientos
            oInventario.StartPosition = FormStartPosition.CenterScreen

            oInventario.LlamdoExterior = True
            oInventario.CodigoDocumentoParaGrabar = "SEI"
            oInventario.FolioEmbarque = Me.txtFolioEmbarque.Text

            oInventario.ShowDialog()
            oInventario.Visible = False

            If oInventario.AplicadoExterior = True Then
                Me.oEmbarque.MarcaSalidaEmpaqueGenerada(True)
            End If

            oInventario.Dispose()

            'Así estaba cuando se aplicaba una salida por cada palet(17dic16)
            ''GENERAR SALIDAS DE LOS PALETS
            'For i = 1 To Me.Grid.Rows - 1 'Step CInt(Me.oInventario.Visible = True)
            '    If txtLEN(Me.Grid.Cell(i, Me.igyCodigoPalet).Text) = True Then

            '        Dim oPalet As New Class_Embarques_PaletsGlobal(Me.Grid.Cell(i, Me.igyCodigoPalet).Text)

            '        If oPalet.CODIGO_PRODUCTOR = Empresa_Sistema.CODIGO_PRODUCTOR_SALIDA_INVENTARIABLE_AUTOMATICA Then
            '            If oPalet.SALIDA_EMPAQUE_GENERADA = "0" And oPalet.GENERARA_SALIDA = "1" Then
            '                Dim oInventario As New Inventarios_Movimientos
            '                oInventario.StartPosition = FormStartPosition.CenterScreen

            '                oInventario.LlamdoExterior = True
            '                oInventario.CodigoDocumentoParaGrabar = Empresa_Sistema.CODIGO_TIPO_DOCUMENTO_SALIDA_EMPAQUE.ToString
            '                oInventario.TxtFolioReferencia.Text = Me.Grid.Cell(i, Me.igyCodigoPalet).Text
            '                oInventario.FolioEmbarque = Me.txtFolioEmbarque.Text

            '                oInventario.ShowDialog()
            '                oInventario.Visible = False
            '            End If
            '        ElseIf oPalet.CODIGO_PRODUCTOR = Empresa_Sistema.CODIGO_PRODUCTOR_HAPPY Then
            '            If oPalet.SALIDA_EMPAQUE_GENERADA = "0" And oPalet.GENERARA_SALIDA = "1" Then
            '                Dim oInventario As New Inventarios_Movimientos
            '                oInventario.StartPosition = FormStartPosition.CenterScreen

            '                oInventario.LlamdoExterior = True
            '                oInventario.CodigoDocumentoParaGrabar = "TEI".ToString
            '                oInventario.CodigoAlmacenHappy = "0004"
            '                oInventario.TxtFolioReferencia.Text = Me.Grid.Cell(i, Me.igyCodigoPalet).Text
            '                oInventario.FolioEmbarque = Me.txtFolioEmbarque.Text

            '                oInventario.ShowDialog()
            '                oInventario.Visible = False
            '            End If
            '        Else
            '            If oPalet.SALIDA_EMPAQUE_GENERADA = "0" And oPalet.GENERARA_SALIDA = "1" Then
            '                Dim oInventario As New Inventarios_Movimientos
            '                oInventario.StartPosition = FormStartPosition.CenterScreen

            '                oInventario.LlamdoExterior = True
            '                oInventario.CodigoDocumentoParaGrabar = Empresa_Sistema.CODIGO_TIPO_DOCUMENTO_SALIDA_EMPAQUE.ToString
            '                oInventario.TxtFolioReferencia.Text = Me.Grid.Cell(i, Me.igyCodigoPalet).Text
            '                oInventario.FolioEmbarque = Me.txtFolioEmbarque.Text

            '                oInventario.ShowDialog()
            '                oInventario.Visible = True
            '            Else
            '                'oPalet.SALIDA_EMPAQUE_GENERADA = "0" And oPalet.GENERARA_SALIDA = "0" 
            '                'Si Genera salida es =0 no generara salida de ninguna forma
            '            End If
            '        End If
            '    End If
            'Next

            'Dim sql2 As New Class_find("SELECT 1 FROM VW_EMB_EMBARQUE_DETALLE_EXTENDIDO " & _
            '"WHERE FOLIO_EMBARQUE='" & Me.txtFolioEmbarque.Text & "' AND SALIDA_EMPAQUE_GENERADA='0'")
            'If sql2.Result1 = "" Then
            '    oEmbarque.GeneraSalidaEmbarque()
            'End If

            'If Me.GeneraMarcaSalida() = False Then
            '    Exit Function
            'End If

            bResultado = True
        Catch ex As Exception
            HandleError(Me.Name, "GeneraSalida", ex)
        End Try

        Return bResultado
    End Function

    Private Function CancelaSalidaPalets() As Boolean
        Dim bResultado As Boolean = False
        Try
            Dim i As Integer

            'CANCELA LAS SALIDAS DE LOS PALETS
            For i = 1 To Me.Grid.Rows - 1
                If txtLEN(Me.Grid.Cell(i, Me.igyCodigoPalet).Text) = True Then
                    Dim oPalet = New Class_Embarques_PaletsGlobal(Me.Grid.Cell(i, Me.igyCodigoPalet).Text)
                    'Dim sql1 As New Class_find("SELECT SALIDA_EMPAQUE_GENERADA FROM EMB_PALETS_GLOBAL " & _
                    '    "WHERE FOLIO_PALET='" & Me.Grid.Cell(i, Me.igyCodigoPalet).Text & "'")

                    If oPalet.SALIDA_EMPAQUE_GENERADA.ToString = "1" Then
                        Dim sql2 As New Class_find("SELECT max(FOLIO_MOVIMIENTO_INVENTARIO)FOLIO_MOVIMIENTO_INVENTARIO from INVENTARIO_MOVIMIENTOS_GLOBAL WHERE FOLIO_REFERENCIA='" & Me.Grid.Cell(i, Me.igyCodigoPalet).Text & "'")

                        Dim oMovimientoInventario = New Class_Inventarios_Global(sql2.Result1)
                        oMovimientoInventario.FECHA_CANCELACION = Date.Now
                        oMovimientoInventario.Cancelar()
                        oPalet.MarcaSalidaPalet(False)
                    End If
                End If
            Next

            Dim sql As New Class_find("SELECT FOLIO_EMBARQUE from EMB_EMBARQUE_GLOBAL WHERE FOLIO_VIAJE='" & Me.oEmbarque.FOLIO_VIAJE.ToString & "' AND FOLIO_EMBARQUE<>'" & Me.oEmbarque.FOLIO_EMBARQUE.ToString & "'")
            If txtLEN(sql.Result1.ToString) = True Then
                Dim dTabla As DataTable
                Dim Embarque As New Class_Embarques_EmbarqueGlobal(sql.Result1.ToString, Me.cboDocumento.SelectedValue.ToString)
                If Embarque.Existe = True Then
                    dTabla = Embarque.ObtenerDetalle
                    Me.Grid.Rows = 1
                    For Each dRow As DataRow In dTabla.Rows
                        Dim oPalet = New Class_Embarques_PaletsGlobal(dRow(0).ToString)
                        If dRow(4).ToString = "SI" Then
                            Dim sql2 As New Class_find("SELECT max(FOLIO_MOVIMIENTO_INVENTARIO)FOLIO_MOVIMIENTO_INVENTARIO from INVENTARIO_MOVIMIENTOS_GLOBAL WHERE FOLIO_REFERENCIA='" & dRow(0).ToString & "'")
                            Dim oMovimientoInventario = New Class_Inventarios_Global(sql2.Result1)
                            oMovimientoInventario.FECHA_CANCELACION = Date.Now
                            oMovimientoInventario.Cancelar()
                            oPalet.MarcaSalidaPalet(False)
                        End If
                    Next
                End If
            End If
            ' Dim sql2 As New Class_find("SELECT 1 FROM VW_EMB_EMBARQUE_DETALLE_EXTENDIDO " & _
            '"WHERE FOLIO_EMBARQUE='" & Me.txtFolioEmbarque.Text & "' AND SALIDA_EMPAQUE_GENERADA='1'")

            ' If sql2.Result1 = "" Then
            '     oEmbarque.GeneraSalidaEmbarque(False)
            ' End If
            bResultado = True
        Catch ex As Exception
            HandleError(Me.Name, "CancelaSalidaPalets", ex)
        End Try

        Return bResultado
    End Function

    Private Sub GestionaCambioEstado()
        Select Case Me.LblStatus.Text
            Case "A"
                Me.Cambia_Estado(enumEstados.APLICADO)
            Case "C"
                Me.Cambia_Estado(enumEstados.CANCELADO)
        End Select
    End Sub

    Private Function ValidarEmbarque() As Boolean
        Try
            Dim bHayRenglones As Boolean = False
            Dim oPalets As Class_Embarques_PaletsGlobal

            If Plaza.ValidarPeriodoTrabajo(Me.DtpFecha.Value) = False Then
                Return False
            End If

            If Me.ValidarPalet() = False Then
                Return False
            End If

            If txtLEN(Me.txtFolioEmbarque.Text) = False Then
                MsgBox("Asígne un folio válido.", MsgBoxStyle.Exclamation, "ValidarEmbarque")
                Return False
            End If

            If Me.CboDistribuidor.SelectedIndex = -1 Then
                MsgBox("Seleccione un importador.", MsgBoxStyle.Exclamation, "ValidarEmbarque")
                Me.CboDistribuidor.Focus()
                Return False
            End If

            If Me.CboEmbarcador.SelectedIndex = -1 Then
                MsgBox("Seleccione un embarcador.", MsgBoxStyle.Exclamation, "ValidarEmbarque")
                Me.CboEmbarcador.Focus()
                Return False
            End If

            If txtLEN(Me.TxtCliente.Text) = False Then
                MsgBox("Asígne un cliente.", MsgBoxStyle.Exclamation, "ValidarEmbarque")
                Me.TxtCliente.Focus()
                Return False
            End If

            If txtLEN(Me.txtCodigoTransporte.Text) = False Then
                MsgBox("Asígne el transporte.", MsgBoxStyle.Exclamation, "ValidarEmbarque")
                Me.txtCodigoTransporte.Focus()
                Return False
            End If

            If txtLEN(Me.txtCaja.Text) = False Then
                MsgBox("Asígne la caja.", MsgBoxStyle.Exclamation, "ValidarEmbarque")
                Me.txtCaja.Focus()
                Return False
            End If

            If txtLEN(Me.CboLugarEntrega.Text) = False Then
                MsgBox("Asígne el lugar de entrega del embarque.", MsgBoxStyle.Exclamation, "ValidarEmbarque")
                Me.CboLugarEntrega.Focus()
                Return False
            End If

            If Me.oDocumento.CODIGO_MERCADO = "E" Then
                If txtLEN(Me.txtFolioAARC.Text) = False Then
                    MsgBox("Asígne el folio AARC.", MsgBoxStyle.Exclamation, "ValidarEmbarque")
                    Me.txtFolioAARC.Focus()
                    Return False
                End If

                If txtLEN(Me.TxtAduanaExtranjera.Text) = False Then
                    MsgBox("Asígne la aduana extranjera.", MsgBoxStyle.Exclamation, "ValidarEmbarque")
                    Me.TxtAduanaExtranjera.Focus()
                    Return False
                End If

                If txtLEN(Me.TxtAduanaNacional.Text) = False Then
                    MsgBox("Asígne la aduana nacional.", MsgBoxStyle.Exclamation, "ValidarEmbarque")
                    Me.TxtAduanaNacional.Focus()
                    Return False
                End If
            Else
                If txtLEN(Me.cboEstado.Text) = False Then
                    MsgBox("Asígne el estado de destino del embarque.", MsgBoxStyle.Exclamation, "ValidarEmbarque")
                    Me.cboEstado.Focus()
                    Return False
                End If
            End If

            If txtLEN(Me.cboAlmacen.Text) = False Then
                MsgBox("Asígne el almacén.", MsgBoxStyle.Exclamation, "ValidarEmbarque")
                Me.cboAlmacen.Focus()
                Return False
            End If

            If txtLEN(Me.cboEmpaque.Text) = False Then
                MsgBox("Asígne el empaque.", MsgBoxStyle.Exclamation, "ValidarEmbarque")
                Me.cboEmpaque.Focus()
                Return False
            End If

            Dim i As Integer
            For i = 1 To Me.Grid.Rows - 1
                If txtLEN(Me.Grid.Cell(i, Me.igyCodigoPalet).Text) = True Then
                    oPalets = New Class_Embarques_PaletsGlobal(Me.Grid.Cell(i, Me.igyCodigoPalet).Text)

                    If oPalets.Existe = False Then
                        MsgBox("El palet no existe.", MsgBoxStyle.Exclamation, "ValidarEmbarque")
                        Me.Grid.Cell(i, Me.igyCodigoPalet).SetFocus()
                        Return False
                    End If

                    If valorNumerico(Me.Grid.Cell(i, Me.igyBultos).Text) <= 0 Then
                        MsgBox("El bulto por palet debe de ser mayor a 0.", MsgBoxStyle.Exclamation, "ValidarEmbarque")
                        Me.Grid.Cell(i, Me.igyBultos).SetFocus()
                        Return False
                    End If

                    If valorNumerico(Me.Grid.Cell(i, Me.igyPeso).Text) <= 0 Then
                        MsgBox("El peso por palet debe de ser mayor a 0.", MsgBoxStyle.Exclamation, "ValidarEmbarque")
                        Me.Grid.Cell(i, Me.igyPeso).SetFocus()
                        Return False
                    End If

                    If valorNumerico(Me.Grid.Cell(i, Me.igyImporte).Text) <= 0 Then
                        MsgBox("El importe del palet debe de ser mayor a 0.", MsgBoxStyle.Exclamation, "ValidarEmbarque")
                        Me.Grid.Cell(i, Me.igyImporte).SetFocus()
                        Return False
                    End If

                    bHayRenglones = True
                End If
            Next i

            If Me.txtFolioEmbarque.Text = Me.txtFolioViaje.Text Then
                Me.oEmbarque = New Class_Embarques_EmbarqueGlobal(Me.txtFolioEmbarque.Text, Me.cboDocumento.SelectedValue.ToString)
                If Me.oEmbarque.Existe = True Then
                    If Me.oEmbarque.FLETE_GENERADO = "1" Then
                        If Me.oEmbarque.IMPORTE_FLETE <> Me.oEmbarque.SALDO_FLETE Then
                            MsgBox("El flete del embarque ya tiene pagos generados no es posible modificar el embarque.", MsgBoxStyle.Exclamation, Me.Text)
                            Return False
                        End If
                    End If
                End If
            End If

            If bHayRenglones = False Then
                MsgBox("Captúre el detalle del movimiento.", MsgBoxStyle.Exclamation, Me.Text)
                Return False
            End If

            Return True

        Catch ex As Exception
            HandleError(Me.Name, "ValidarEmbarque", ex)
        End Try
    End Function

    Private Sub DesplegarDocumentos()
        Try
            With Me.cboDocumento
                .DisplayMember = "NOMBRE_TIPO_DOCUMENTO"
                .ValueMember = "CODIGO_DOCUMENTO"
                Dim dView As New Data.DataView(Me.oDocumento.ObtenerCodigosDocumentos(Me.oEmbarque.CODIGO_MODULO, Usuario.Codigo_Plaza.ToString, " ESTATUS_DOCUMENTO='A' AND CODIGO_TIPO_DOCUMENTO IN('EMBE','EMBN')"))
                dView.Sort = "NOMBRE_TIPO_DOCUMENTO"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedIndex = 0
                    Me.bDocumentosCargados = True
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarDocumentos", ex)
        End Try
    End Sub

    Private Sub DesplegarDistribuidor()
        Try
            Dim oDistribuidores As New Class_CatDistribuidores
            With Me.CboDistribuidor
                .DisplayMember = "NOMBRE_DISTRIBUIDOR"
                .ValueMember = "CODIGO_DISTRIBUIDOR"
                Dim dView As New Data.DataView(oDistribuidores.ObtenerElementos)
                dView.Sort = "NOMBRE_DISTRIBUIDOR"
                .DataSource = dView
                If dView.Count > 0 Then
                    If Me.oDocumento.CODIGO_MERCADO = "E" Then
                        .SelectedValue = "0002"
                    Else
                        .SelectedValue = "0001"
                    End If
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarDistribuidor", ex)
        End Try
    End Sub

    Private Sub DesplegarEmbarcardor()
        Try
            Dim oEmbarcador As New Class_CatEmbarcadores
            With Me.CboEmbarcador
                .DisplayMember = "NOMBRE_EMBARCADOR"
                .ValueMember = "CODIGO_EMBARCADOR"
                Dim dView As New Data.DataView(oEmbarcador.ObtenerElementos)
                dView.Sort = "NOMBRE_EMBARCADOR"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedValue = Usuario.Codigo_Almacen
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarEmbarcardor", ex)
        End Try
    End Sub

    'Private Sub DesplegarChoferes()
    '    'Dim oChoferes As New Class_CatChoferes
    '    'Try
    '    '    With Me.CboChofer
    '    '        .DisplayMember = "NOMBRE_CHOFER"
    '    '        .ValueMember = "CODIGO_CHOFER"
    '    '        Dim dView As New Data.DataView(oChoferes.ObtenerElementos())
    '    '        dView.Sort = "NOMBRE_CHOFER DESC"
    '    '        .DataSource = dView
    '    '        If dView.Count > 0 Then
    '    '            .SelectedIndex = 0
    '    '        End If
    '    '    End With
    '    'Catch ex As Exception
    '    '    HandleError(Me.Name, "DesplegarChoferes", ex)
    '    'End Try
    'End Sub

    Private Sub DesplegarLugarEntrega()
        Dim oLugarEntrega As New Class_CatLugaresEntrega
        Try
            With Me.CboLugarEntrega
                .DisplayMember = "NOMBRE_LUGAR_ENTREGA"
                .ValueMember = "CODIGO_LUGAR_ENTREGA"
                Dim dView As New Data.DataView(oLugarEntrega.ObtenerElementos())
                dView.Sort = "NOMBRE_LUGAR_ENTREGA"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedIndex = -1
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarLugarEntrega", ex)
        End Try
    End Sub

    Private Sub DesplegarEstadoDestino()
        Try
            Dim oElementos As New Class_CatClientes
            With Me.cboEstado
                .DisplayMember = "NOMBRE_ESTADO"
                .ValueMember = "CODIGO_ESTADO"

                Dim dView As New Data.DataView(oElementos.ObtenerEstados)
                dView.Sort = "NOMBRE_ESTADO"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedIndex = -1 'oClientes.ESTADO
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarEstadoDestino", ex)
        End Try
    End Sub

    Private Sub DesplegarAlmacenes()
        Dim oElementos As New Class_CatAlmacenes
        With Me.cboAlmacen
            .DisplayMember = "NOMBRE_ALMACEN"
            .ValueMember = "CODIGO_ALMACEN"

            Dim dView As New Data.DataView(oElementos.ObtenerAlmacenes)
            dView.Sort = "NOMBRE_ALMACEN"
            .DataSource = dView
            If dView.Count > 0 Then
                .SelectedIndex = -1
            End If
        End With
    End Sub

    Private Sub Totales()
        'Dim I As Integer
        'Dim iBultos As Double, dImporte As Double
        'For I = 1 To Me.Grid.Rows - 1
        '    If txtLEN(Me.Grid.Cell(I, Me.igyBultos).Text) = True Then
        '        iBultos = valorNumerico(Me.Grid.Cell(I, Me.igyBultos).Text)
        '        dImporte = valorNumerico(Me.Grid.Cell(I, Me.igyImporte).Text)
        '        If iBultos > 0 Then
        '            dImporte = Redondear((dImporte * iBultos), Empresa_Sistema.DECIMALES_CONTABILIDAD)
        '            Me.Grid.Cell(I, Me.igyImporte).Text = dImporte.ToString
        '        Else
        '            Me.Grid.Cell(I, Me.igyImporte).Text = "0"
        '        End If
        '    End If
        'Next I

        Try
            Me.TxtTotalImporte.Text = FormatImporteContable(Redondear(FG_Grid_SumaCol(Me.Grid, Me.igyImporte), Empresa_Sistema.DECIMALES_CONTABILIDAD))
            Me.TxtTotalPeso.Text = FG_Grid_SumaCol(Me.Grid, Me.igyPeso).ToString
            Me.txtTotalBultos.Text = FG_Grid_SumaCol(Me.Grid, Me.igyBultos).ToString

        Catch ex As Exception
            HandleError(Me.Name, "Totales", ex)
        End Try
    End Sub

    Private Sub GeneraFolio()
        If Me.bDocumentosCargados = True Then
            Me.txtFolioViaje.Text = Me.oEmbarque.GeneraFolio
            Me.txtFolioEmbarque.Text = Me.txtFolioViaje.Text '& "A"
        End If
    End Sub

    Private Sub GeneraFolioAARC()
        Me.txtFolioAARC.Text = Me.oEmbarque.GeneraFolioAARC
    End Sub

    Private Sub GestionaGrid(ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            Dim Columna As Integer, Renglon As Integer
            Dim StrCod As String, iBultos As Double, dImporte As Double
            Dim oPalets As Class_Embarques_PaletsGlobal

            If Me.Estado = enumEstados.CANCELADO Then
                Exit Sub
            End If

            Columna = Me.Grid.Selection.FirstCol
            Renglon = Me.Grid.Selection.FirstRow
            StrCod = Me.Grid.Cell(Renglon, Me.igyCodigoPalet).Text
            iBultos = valorNumerico(Me.Grid.Cell(Renglon, Me.igyBultos).Text)
            dImporte = valorNumerico(Me.Grid.Cell(Renglon, Me.igyImporte).Text)


            Select Case e.KeyCode
                Case Keys.Enter
                    Select Case Columna
                        Case Me.igyCodigoPalet
                            'Se agregar el identifiacador al palet si la plaza no es C -CULIACAN
                            'If Plaza.Identificador <> "C" Then
                            '    'Busca si ya tiene un identificador de la plaza
                            '    StrCod = Plaza.Identificador + "-" + StrCod
                            'End If

                            If Me.Grid.Cell(Renglon, Me.igySalida).Text = "SI" Then

                                oPalets = New Class_Embarques_PaletsGlobal(StrCod)
                                If oPalets.Existe = False Then
                                    Me.Grid.Cell(Renglon, Me.igyCodigoPalet).Text = ""
                                    Me.Grid.Cell(Renglon, Me.igyBultos).Text = ""
                                    Me.Grid.Cell(Renglon, Me.igyPeso).Text = ""
                                    Me.Grid.Cell(Renglon, Me.igyImporte).Text = ""
                                    Me.Grid.Cell(Renglon, Me.igySalida).Text = ""
                                    Me.Grid.Cell(Renglon, Me.igyCodigoPalet).SetFocus()
                                End If
                                Exit Sub
                            End If

                            If txtLEN(StrCod) = False Then
                                GoTo BuscaPalet
                            End If
LlenaLinea:
                            oPalets = New Class_Embarques_PaletsGlobal(StrCod)
                            If oPalets.Existe = False Then
                                GoTo BuscaPalet
                            End If

                            Dim sql As New Class_find("SELECT CANTIDAD_TOTAL_PALET,PESO_TOTAL_PALET,IMPORTE_TOTAL_PALET, " &
                            "CASE WHEN ISNULL( SALIDA_EMPAQUE_GENERADA,'0')='0' THEN 'NO' ELSE 'SI' END AS SALIDA_EMPAQUE_GENERADA,GENERARA_SALIDA  " &
                            "FROM EMB_PALETS_GLOBAL Where FOLIO_PALET='" & StrCod & "'")

                            Me.Grid.Cell(Renglon, Me.igyCodigoPalet).Text = StrCod
                            Me.Grid.Cell(Renglon, Me.igyBultos).Text = sql.Result1
                            Me.Grid.Cell(Renglon, Me.igyPeso).Text = sql.Result2
                            Me.Grid.Cell(Renglon, Me.igyImporte).Text = sql.Result3
                            Me.Grid.Cell(Renglon, Me.igySalida).Text = sql.Result4
                            Me.Grid.Cell(Renglon, Me.igyGenerarSalida).Text = sql.Result5

                            If Me.ValidarPalet(Renglon, Me.Grid.Cell(Renglon, Me.igyCodigoPalet).Text) = False Then
                                Me.Totales() 'Se debe recalcular porque se eliminó el renglón repetido.
                                Exit Sub
                            End If

                            Me.Totales()
                            'If Me.Grid.Rows = Renglon + 1 Then
                            '    Me.Grid.Rows = Me.Grid.Rows + 1
                            'End If

                            'Me.Grid.Cell(Renglon, Me.igySalida).SetFocus()


                        Case Me.igyBultos
                            If iBultos <= 0 Then
                                MsgBox("La cantidad debe de ser mayor a 0.", MsgBoxStyle.Exclamation, Me.Text)
                                Me.Grid.Cell(Renglon, Me.igyBultos).SetFocus()
                                Exit Sub
                            End If

                        Case Me.igyImporte
                            If dImporte <= 0 Then
                                MsgBox("El importe debe de ser mayor a 0.", MsgBoxStyle.Exclamation, Me.Text)
                                Me.Grid.Cell(Renglon, Me.igyImporte).SetFocus()
                                Exit Sub
                            End If
                            If Me.Grid.Rows = Renglon + 1 Then
                                Me.Grid.Rows = Me.Grid.Rows + 1
                            End If

                        Case Me.igySalida
                            If Me.Grid.Rows = Renglon + 1 Then
                                Me.Grid.Rows = Me.Grid.Rows + 1
                            End If

                    End Select
                    Me.Totales()

                Case Keys.F6
                    If Me.Grid.Cell(Renglon, Me.igySalida).Text = "SI" Then
                        Exit Sub
                    End If
BuscaPalet:
                    If Columna = Me.igyCodigoPalet Then
                        oPalets = New Class_Embarques_PaletsGlobal
                        StrCod = oPalets.BusquedaVisual_Palets
                        If txtLEN(StrCod) = True Then
                            GoTo LlenaLinea
                        Else
                            Me.Grid.Cell(Renglon, Me.igyCodigoPalet).Text = ""
                            Me.Grid.Cell(Renglon, Me.igyBultos).Text = ""
                            Me.Grid.Cell(Renglon, Me.igyPeso).Text = ""
                            Me.Grid.Cell(Renglon, Me.igyImporte).Text = ""
                            Me.Grid.Cell(Renglon, Me.igySalida).Text = ""
                            Me.Grid.Cell(Renglon, Me.igyCodigoPalet).SetFocus()
                        End If
                    End If

                Case Keys.F8, Keys.Delete
                    If (Me.Estado = enumEstados.NUEVO Or Me.Estado = enumEstados.APLICADO) Then
                        If Me.Grid.Rows > 2 Then
                            If txtLEN(Me.Grid.Cell(Renglon, Me.igySalida).Text) = True Then
                                If Me.Grid.Cell(Renglon, Me.igySalida).Text = "SI" Then
                                    Me.EliminarPaletSalida(Me.Grid.Cell(Renglon, Me.igyCodigoPalet).Text)
                                    e.SuppressKeyPress = True
                                    Exit Sub
                                Else
                                    Me.Grid.Selection.DeleteByRow()
                                    e.SuppressKeyPress = True
                                End If
                            End If
                        Else
                            Me.Grid.Cell(Renglon, Me.igyCodigoPalet).Text = ""
                            Me.Grid.Cell(Renglon, Me.igyBultos).Text = ""
                            Me.Grid.Cell(Renglon, Me.igyPeso).Text = ""
                            Me.Grid.Cell(Renglon, Me.igyImporte).Text = ""
                            Me.Grid.Cell(Renglon, Me.igySalida).Text = ""
                        End If
                    End If
                    Me.Totales()
            End Select
        Catch ex As Exception
            HandleError(Me.Name, "GestionaGrid", ex)
        End Try
    End Sub

    Private Function ValidarPalet(Optional ByVal Renglon As Integer = 2, Optional ByVal Codigo As String = "") As Boolean
        Try
            Dim i As Integer, j As Integer
            Dim sCodigoPalet As String = ""

            For i = 1 To Me.Grid.Rows - 1
                If txtLEN(Me.Grid.Cell(i, Me.igyCodigoPalet).Text) = True Then
                    Dim sql As New Class_find("SELECT ESTA_EMBARCADO FROM EMB_PALETS_GLOBAL WHERE FOLIO_PALET='" & Me.Grid.Cell(i, Me.igyCodigoPalet).Text & "' AND ESTATUS='A'")
                    If sql.Result1 = "" Then
                        MsgBox("El palet que intenta introducir en el renglón: " & i & " no existe ó esta cancelado, favor de intentar con otro palet.", MsgBoxStyle.Exclamation, "Validación de palets")
                        Exit Function
                    ElseIf sql.Result1 = "1" Then
                        Dim sql1 As New Class_find("SELECT FOLIO_EMBARQUE FROM EMB_EMBARQUE_DETALLE WHERE FOLIO_PALET='" & Me.Grid.Cell(i, Me.igyCodigoPalet).Text & "'")
                        Dim sql2 As New Class_find("SELECT ESTATUS_EMBARQUE FROM EMB_EMBARQUE_GLOBAL WHERE FOLIO_EMBARQUE='" & sql1.Result1 & "'")
                        If sql2.Result1 = "A" Then
                            If sql1.Result1 <> Me.txtFolioEmbarque.Text Then
                                MsgBox("El palet que intenta introducir en el renglón: " & i & " ya esta embarcado en " & sql1.Result1.ToString & " , favor de intentar con otro palet.", MsgBoxStyle.Exclamation, "Validación de palets")
                                Me.Grid.Cell(i, Me.igyCodigoPalet).Text = ""
                                Me.Grid.Cell(i, Me.igyPeso).Text = ""
                                Me.Grid.Cell(i, Me.igyBultos).Text = ""
                                Me.Grid.Cell(i, Me.igyImporte).Text = ""
                                Me.Grid.Cell(i, Me.igySalida).Text = ""
                                Me.Grid.Cell(i, Me.igyCodigoPalet).SetFocus()
                                Exit Function
                            End If
                        End If
                    End If
                End If
            Next i

            If txtLEN(Codigo) = False Then
                For i = 1 To Me.Grid.Rows - 1
                    sCodigoPalet = Me.Grid.Cell(i, Me.igyCodigoPalet).Text
                    For j = i + 1 To Me.Grid.Rows - 1
                        If txtLEN(Me.Grid.Cell(j, Me.igyCodigoPalet).Text) = True Then
                            If sCodigoPalet = Me.Grid.Cell(j, Me.igyCodigoPalet).Text And Me.Grid.Rows > 2 Then
                                MsgBox("El palet que intenta introducir en el renglón:  " & i & " ya existe en el renglon " & j.ToString & ", favor de intentar con otro código.", MsgBoxStyle.Exclamation, "Validación de productos")
                                Me.Grid.Cell(i, Me.igyCodigoPalet).SetFocus()
                                Exit Function
                            End If
                        End If
                    Next j
                    'sCodigoProducto = Me.Grid.Cell(i, Me.igyCodigo).Text
                Next i
            Else
                sCodigoPalet = Codigo

                For j = 1 To Renglon - 1 'Me.Grid.Rows - 1
                    If txtLEN(Me.Grid.Cell(j, Me.igyCodigoPalet).Text) = True Then
                        If sCodigoPalet = Me.Grid.Cell(j, Me.igyCodigoPalet).Text And Me.Grid.Rows > 2 Then
                            MsgBox("El palet que intenta introducir en el renglón: " & Renglon & " ya existe, favor de intentar con otro palet.", MsgBoxStyle.Exclamation, "Validación de palets")
                            Me.Grid.Cell(Renglon, Me.igyCodigoPalet).Text = ""
                            Me.Grid.Cell(Renglon, Me.igyPeso).Text = ""
                            Me.Grid.Cell(Renglon, Me.igyBultos).Text = ""
                            Me.Grid.Cell(Renglon, Me.igyImporte).Text = ""
                            Me.Grid.Cell(Renglon, Me.igySalida).Text = ""
                            Me.Grid.Cell(Renglon, Me.igyCodigoPalet).SetFocus()
                            Exit Function
                        End If
                    End If
                Next j

                For j = Renglon + 1 To Me.Grid.Rows - 1
                    If txtLEN(Me.Grid.Cell(j, Me.igyCodigoPalet).Text) = True Then
                        If sCodigoPalet = Me.Grid.Cell(j, Me.igyCodigoPalet).Text And Me.Grid.Rows > 2 Then
                            MsgBox("El palet que intenta introducir en el renglón: " & Renglon & " ya existe, favor de intentar con otro palet.", MsgBoxStyle.Exclamation, "Validación de palets")
                            Me.Grid.Cell(Renglon, Me.igyCodigoPalet).Text = ""
                            Me.Grid.Cell(Renglon, Me.igyPeso).Text = ""
                            Me.Grid.Cell(Renglon, Me.igyBultos).Text = ""
                            Me.Grid.Cell(Renglon, Me.igyImporte).Text = ""
                            Me.Grid.Cell(Renglon, Me.igySalida).Text = ""
                            Me.Grid.Cell(Renglon, Me.igyCodigoPalet).SetFocus()
                            Exit Function
                        End If
                    End If
                Next j
            End If

            Return True

        Catch ex As Exception
            HandleError(Me.Name, "ValidarPalet", ex)
        End Try
    End Function

    Private Function ValidarFlete() As Boolean
        Try
            Dim oPoliza As New Class_Contabilidad_Poliza_Global(Me.txtFolioEmbarque.Text)

            Me.oEmbarque = New Class_Embarques_EmbarqueGlobal(Me.txtFolioEmbarque.Text, Me.cboDocumento.SelectedValue.ToString)
            If Me.oEmbarque.Existe = False Then
                Exit Function
            End If

            If oPoliza.Existe = True Then
                Dim sql As New Class_find("SELECT 1,TOTAL,SALDO FROM COMPRA_GLOBAL WHERE FOLIO_EMBARQUE='" & Me.oEmbarque.FOLIO_EMBARQUE & "'  AND ESTATUS='A'")
                If sql.Result2 <> sql.Result3 Then
                    MsgBox("El embarque tiene un flete con pago. Favor de verificar.", MsgBoxStyle.Exclamation, "Validación de fletes")
                    Exit Function
                End If

                oEmbarque.EliminarFlete()
            End If
            Return True
        Catch ex As Exception
            HandleError(Me.Name, "ValidarFlete", ex)
        End Try
    End Function

    Private Sub OcultarControles()
        If Me.oDocumento.CODIGO_MERCADO = "E" Then
            Me.txtFolioAARC.Visible = True : Me.lblDisplayFolioAARC.Visible = True
            Me.BtnGeneraFlete.Visible = True
            'Me.btnCambiarPrecios.Visible = False
            Me.lblAduanaExtranjera.Visible = True : Me.TxtAduanaExtranjera.Visible = True : Me.lblNombrelblAduanaExtranjera.Visible = True
            Me.lblAduanaNacional.Visible = True : Me.TxtAduanaNacional.Visible = True : Me.lblNombrelblAduanaNacional.Visible = True
            'Me.CboDistribuidor.SelectedValue = "0002"
            Me.lblDisplayEstado.Visible = False : Me.cboEstado.Visible = False
        ElseIf Me.oDocumento.CODIGO_MERCADO = "N" Then
            Me.BtnGeneraFlete.Visible = False
            'Me.btnCambiarPrecios.Visible = True
            Me.txtFolioAARC.Visible = False : Me.lblDisplayFolioAARC.Visible = False
            Me.lblAduanaExtranjera.Visible = False : Me.TxtAduanaExtranjera.Visible = False : Me.lblNombrelblAduanaExtranjera.Visible = False
            Me.lblAduanaNacional.Visible = False : Me.TxtAduanaNacional.Visible = False : Me.lblNombrelblAduanaNacional.Visible = False
            Me.CboDistribuidor.SelectedValue = "0001"
            Me.lblDisplayEstado.Visible = True : Me.cboEstado.Visible = True
        End If
    End Sub

    Private Function GeneraFlete() As Boolean
        Dim bResultado As Boolean = False
        Dim slineaTransporte As New Class_CatLineasTransportes
        Dim sTransporte As New Class_CatTransportes

        sTransporte = New Class_CatTransportes(Me.oEmbarque.CODIGO_TRANSPORTE)

        Dim sql As New Class_find("SELECT L.IMPORTE_FLETE,L.NOMBRE_LUGAR_ENTREGA FROM EMB_EMBARQUE_GLOBAL E INNER JOIN CAT_LUGARES_ENTREGA L ON (E.CODIGO_LUGAR_ENTREGA=L.CODIGO_LUGAR_ENTREGA) WHERE FOLIO_EMBARQUE='" & Me.oEmbarque.FOLIO_EMBARQUE & "'")
        If valorNumerico(sql.Result1) <= 0 Then
            MsgBox("El importe de flete de " & sql.Result2 & " debe ser mayor a 0.", MsgBoxStyle.Exclamation, "Validación de fletes")
            Exit Function
        End If

        Dim sql1 As New Class_find("SELECT CUENTA_CONTABLE_FLETERO,NOMBRE_LINEA_TRANSPORTE FROM VW_CAT_TRANSPORTES_EXTENDIDOS WHERE CODIGO_TRANSPORTE='" & Me.oEmbarque.CODIGO_TRANSPORTE & "'")
        If txtLEN(sql1.Result1) = False Then
            MsgBox("La línea de transporte " & sql1.Result2 & " no tiene cuenta contable.", MsgBoxStyle.Exclamation, "Validación de fletes")
            Exit Function
        End If

        Try
            With Me.oEmbarque
                If Me.oEmbarque.FLETE_GENERADO = "0" Then
                    .FOLIO_EMBARQUE = Me.txtFolioEmbarque.Text
                    If .GenerarFlete() = False Then
                        MsgBox("Error al tratar de generar el flete.", MsgBoxStyle.Critical, "Validación de fletes")
                        Exit Function
                    End If
                End If
            End With

            bResultado = True
        Catch ex As Exception
            HandleError(Me.Name, "GeneraFlete", ex)
        End Try

        Return bResultado
    End Function

    Private Sub NavegadorEmbarques(ByVal sTipoDeBusqueda As String)
        Try
            Dim iFolio As Integer, sFolio As String, sFolio1 As String
            If txtLEN(Me.txtFolioViaje.Text) = False Then
                Me.txtFolioViaje.Text = Me.oEmbarque.GeneraFolio
            End If

            If sTipoDeBusqueda = "Anterior" Then
                iFolio = CInt(Strings.Right(Me.txtFolioViaje.Text, 6))
                iFolio = iFolio - 1
                sFolio1 = "000000" + iFolio.ToString
                sFolio = Me.txtFolioViaje.Text.Substring(0, Me.txtFolioViaje.Text.IndexOf("-"))
                sFolio = sFolio + "-" + sFolio1.Substring(Len(sFolio1) - 6)

                Me.txtFolioViaje.Text = sFolio 'Me.oDocumento.CODIGO_MERCADO.ToString() + "-" + sFolio.Substring(Len(sFolio) - 6)
                'If Plaza.CODIGO_PLAZA <> 1 Then
                Me.txtFolioViaje.Text = sFolio ' Plaza.Identificador + Me.txtFolioViaje.Text
                'End If

                Me.txtFolioEmbarque.Text = Me.txtFolioViaje.Text
                If iFolio > 0 Then
                    Me.Consultar()
                Else
                    Me.Inicializa()
                    Me.Cambia_Estado(enumEstados.NUEVO)
                End If

            ElseIf sTipoDeBusqueda = "Siguiente" Then
                iFolio = CInt(Strings.Right(Me.txtFolioViaje.Text, 6))
                iFolio = iFolio + 1
                sFolio1 = "000000" + iFolio.ToString
                sFolio = Me.txtFolioViaje.Text.Substring(0, Me.txtFolioViaje.Text.IndexOf("-"))
                sFolio = sFolio + "-" + sFolio1.Substring(Len(sFolio1) - 6)

                Me.txtFolioViaje.Text = sFolio 'Me.oDocumento.CODIGO_MERCADO.ToString() + "-" + sFolio.Substring(Len(sFolio) - 6)

                'If Plaza.CODIGO_PLAZA <> 1 Then
                Me.txtFolioViaje.Text = sFolio 'Plaza.Identificador + Me.txtFolioViaje.Text
                'End If
                Me.txtFolioEmbarque.Text = Me.txtFolioViaje.Text

                If iFolio > 0 Then
                    If CInt(Strings.Right(Me.oEmbarque.GeneraFolio, 6)) <= iFolio Then
                        Me.Inicializa()
                        Me.Cambia_Estado(enumEstados.NUEVO)
                    Else
                        Me.Consultar()
                    End If
                End If
            End If

        Catch ex As Exception
            HandleError(Me.Name, "NavegadorEmbarques", ex)
        End Try
    End Sub

    Private Function GestionaFactura() As Boolean
        Dim bResultado As Boolean = False
        Dim oVenta As Class_Ventas_Global

        Try
            Me.oEmbarque = New Class_Embarques_EmbarqueGlobal(Me.txtFolioEmbarque.Text, Me.cboDocumento.SelectedValue.ToString)

            'Si el embarque ya esta facturado mostramos la impresión en pantalla de la factura.
            If Me.oEmbarque.FACTURA_GENERADA = True Then

                If txtLEN(Me.oEmbarque.FOLIO_VENTA) = False Then
                    MsgBox("El embarque no tiene registrado el folio de la factura.", MsgBoxStyle.Exclamation, Me.Text)
                    Return False
                End If

                oVenta = New Class_Ventas_Global(Me.oEmbarque.FOLIO_VENTA)

                If oVenta.TIMBRADO_CFDI = "0" Then
                    MsgBox("Advertencia. La factura no esta timbrada.", MsgBoxStyle.Exclamation, Me.Text)
                End If

                oVenta.Imprimir()
                oVenta = Nothing

                Return False  'Salimos
            End If

            'Por protección se valida esto(aunque el botón seguramente estará bloqueado desde el consultar).
            'If Me.oEmbarque.ES_FACTURA_EMBARQUE_EXTRANJERO = False Then
            If txtLEN(Me.oEmbarque.CODIGO_TIPO_DOCUMENTO_FACTURA_EMBARQUE_EXTRANJERO) = False Then
                MsgBox("Sólo embarques al extranjero se pueden facturar desde esta pantalla. " & vbCrLf & _
                       "Los nacionales se hacen directamente en la pantalla de facturación.", MsgBoxStyle.Exclamation, Me.Text)
                Return False
            End If

            Dim dTipoCambio As Double = valorNumerico(InputBox("Captúre el tipo de cambio del día ''anterior'' al embarque : ", "Tipo de cambio", "18.0000"))

            If dTipoCambio < 10 Then
                MsgBox("Capture un tipo de cambio válido.", MsgBoxStyle.Exclamation, Me.Text)
                Return False
            End If

            If Me.oEmbarque.ValidaEmbarqueFacturaExtanjero() = False Then
                Return False
            End If

            Dim oPantallaFactura As New Ventas_Movimientos
            oPantallaFactura.EsPorEmbarqueExtranjero = True
            oPantallaFactura.oEmbarqueExtranjero = Me.oEmbarque
            oPantallaFactura.TipoCambioPorEmbarqueExtranjero = dTipoCambio
            oPantallaFactura.ObservarcionesPorEmbarqueExtranjero = Me.TxtObservaciones.Text
            oPantallaFactura.ShowDialog()

            If oPantallaFactura.GrabadaFacturaEmbarqueExtranjero = True Then 'Si se grabó y timbró
                Me.Consultar() 'Se pone aqui porque si se pone luego de imprimir de algún modo el foco se pierde y se minimiza la impresión.

                oVenta = New Class_Ventas_Global(oPantallaFactura.txtFolio.Text)
                oVenta.Imprimir()

                'Me.ExportarArchivosPDF()

                bResultado = True
            End If

            oPantallaFactura.Dispose()
            oVenta = Nothing

        Catch ex As Exception
            HandleError(Me.Name, "GestionaFactura", ex)
        End Try

        Return bResultado
    End Function

    Private Function TimbrarFactura() As Boolean
        Dim bResultado As Boolean = False
        Dim sProcedure As String = "TimbrarFactura"
        Dim oVenta As Class_Ventas_Global

        Try
            Me.oEmbarque = New Class_Embarques_EmbarqueGlobal(Me.txtFolioEmbarque.Text, Me.cboDocumento.SelectedValue.ToString)

            'Si el embarque ya esta facturado mostramos la impresión en pantalla de la factura.
            If Me.oEmbarque.FACTURA_GENERADA = True Then

                If txtLEN(Me.oEmbarque.FOLIO_VENTA) = False Then
                    MsgBox("El embarque no tiene registrado el folio de la factura.", MsgBoxStyle.Exclamation, Me.Text)
                    Return False
                End If

                oVenta = New Class_Ventas_Global(Me.oEmbarque.FOLIO_VENTA)
                If oVenta.Existe = False Then
                    Return False
                End If

                If oVenta.TIMBRADO_CFDI = "1" Then
                    MsgBox("La factura ya esta timbrada.", vbExclamation, sProcedure)
                    Return False  'Salimos
                Else
                    bResultado = oVenta.GeneraFacturaElectronica(True, True)
                End If

                If bResultado = True Then
                    Me.btnTimbrarFactura.Enabled = False
                End If
            End If

        Catch ex As Exception
            HandleError(Me.Name, "TimbrarFactura", ex)
        End Try

        Return bResultado
    End Function

    Private Function GestionaCancelarFactura() As Boolean
        Dim bResultado As Boolean = False
        Dim oVenta As Class_Ventas_Global
        Try

            Me.oEmbarque = New Class_Embarques_EmbarqueGlobal(Me.txtFolioEmbarque.Text, Me.cboDocumento.SelectedValue.ToString)

            'Por protección se valida esto(aunque el botón seguramente estará bloqueado desde el consultar).
            'If Me.oEmbarque.ES_FACTURA_EMBARQUE_EXTRANJERO = False Then
            If txtLEN(Me.oEmbarque.CODIGO_TIPO_DOCUMENTO_FACTURA_EMBARQUE_EXTRANJERO) = False Then
                MsgBox("Sólo embarques al extranjero se les puede cancelar la facturar desde esta pantalla. " & vbCrLf & _
                       "Los nacionales se hacen directamente en la pantalla de facturación.", MsgBoxStyle.Exclamation, Me.Text)
                Return False
            End If

            'Si el embarque ya esta facturado mostramos la impresión en pantalla de la factura.
            If Me.oEmbarque.FACTURA_GENERADA = True Then

                If txtLEN(Me.oEmbarque.FOLIO_VENTA) = False Then
                    MsgBox("El embarque no tiene registrado el folio de la factura.", MsgBoxStyle.Exclamation, Me.Text)
                    Return False
                End If

                oVenta = New Class_Ventas_Global(Me.oEmbarque.FOLIO_VENTA)

                oVenta.FECHA_CANCELACION = Date.Now

                If DateDiff(DateInterval.Month, oVenta.FECHA, oVenta.FECHA_CANCELACION) >= 2 Then
                    MsgBox("La factura es de hace 2 meses, no se puede cancelar.", MsgBoxStyle.Exclamation, Me.Text)
                    Return False
                End If

                If oVenta.Cancelar() = True Then

                    oVenta.CancelarTimbre()

                    bResultado = Me.oEmbarque.GeneraMarcaFactura(Me.oEmbarque.FOLIO_VENTA, False) 'Desliga la factura del embarque.

                End If

                Me.Consultar()
            End If

            oVenta = Nothing

        Catch ex As Exception
            HandleError(Me.Name, "GestionaCancelarFactura", ex)
        End Try

        Return bResultado
    End Function

    Private Function GrabarFolioPedimento() As Boolean
        Try
            If Me.oEmbarque.GrabaFolioPedimento(Me.txtFolioPedimento.Text) = True Then
                MsgBox("Folio pedimento grabado satisfactoriamente.", vbInformation, Me.Text)
                Return True
            End If
        Catch ex As Exception
            HandleError(Me.Name, "GrabarFolioPedimento", ex)
        End Try
    End Function

    Private Sub ConsultarSalida()
        Try
            Dim oInventario As New Inventarios_Movimientos
            oInventario.StartPosition = FormStartPosition.CenterScreen

            oInventario.LlamdoExterior = True
            oInventario.CodigoDocumentoParaGrabar = "SEI"
            oInventario.FolioEmbarque = Me.txtFolioEmbarque.Text
            oInventario.ConsultaExteriorSalida = True

            oInventario.ShowDialog()
            oInventario.Visible = False


            'Asi era cuando era por palet
            'Dim Columna As Integer, Renglon As Integer, vdg As String

            'Columna = Me.Grid.Selection.FirstCol
            'Renglon = Me.Grid.Selection.FirstRow

            'vdg = Me.Grid.Cell(Renglon, Me.igyCodigoPalet).Text 'Grid.Rows(Renglon).Cell("FOLIO_POLIZA")
            'If txtLEN(vdg) = False Then
            '    Exit Sub
            'End If

            'If Me.Grid.Cell(Renglon, Me.igySalida).Text <> "SI" Then
            '    MsgBox("El palet no tiene salida generada. ", MsgBoxStyle.Exclamation, Me.Text)
            '    Exit Sub
            'End If

            'Dim oInventario As New Inventarios_Movimientos
            'oInventario.StartPosition = FormStartPosition.CenterScreen

            ''oInventario.LlamdoExterior = True
            'Dim sql As New Class_find("SELECT CODIGO_PRODUCTOR " &
            '                    "FROM EMB_PALETS_GLOBAL Where FOLIO_PALET='" & vdg & "'")
            'If sql.Result1 = Empresa_Sistema.CODIGO_PRODUCTOR_HAPPY Then
            '    oInventario.CodigoDocumentoParaGrabar = Empresa_Sistema.CODIGO_TIPO_DOCUMENTO_TRANSFERENCIA_EMPAQUE.ToString
            'Else
            '    oInventario.CodigoDocumentoParaGrabar = Empresa_Sistema.CODIGO_TIPO_DOCUMENTO_SALIDA_EMPAQUE.ToString
            'End If

            'oInventario.TxtFolioReferencia.Text = vdg
            'oInventario.FolioEmbarque = Me.txtFolioEmbarque.Text
            'oInventario.ConsultaExteriorSalida = True
            'oInventario.ShowDialog()
            'oInventario.Visible = False

        Catch ex As Exception
            HandleError(Me.Name, "ConsultarSalida", ex)
        End Try
    End Sub

    Private Sub DesplegarEmpaques()
        Try
            Dim oElementos As New Class_CatEmpaques
            With Me.CboEmpaque
                .DisplayMember = "NOMBRE_EMPAQUE"
                .ValueMember = "CODIGO_EMPAQUE"
                Dim dView As New Data.DataView(oElementos.ObtenerElementosParaCapturaPalets)
                ' dView.Sort = "NOMBRE_EMPAQUE"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedIndex = 0
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarEmpaques", ex)
        End Try
    End Sub

#End Region

End Class