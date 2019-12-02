Option Strict On

Imports CrystalDecisions.CrystalReports.Engine

Public Class Inventarios_Movimientos
    Private _LlamdoExterior As Boolean
    Private _CodigoDocumentoParaGrabar As String
    Private _AplicadoExterior As Boolean
    Private _FolioEmbarque As String
    Private _ConsultaExteriorSalida As Boolean
    Private _CodigoAlmacenHappy As String

    Private Estado As enumEstados
    Private oInventarios As New Class_Inventarios_Global
    Private oDocumentos As Class_Cat_tiposDocumentos
    Private oArticulos As New Class_CatArticulos
    Private dtSeries As DataTable

#Region "Columnas grid"
    Private iGyCodigo As Integer = 1
    Private iGyDescripcion As Integer = 2
    Private iGyCantidad As Integer = 3
    Private iGyCosto As Integer = 4
    Private iGyImporte As Integer = 5
    Private iGyBoton As Integer = 6
    Private iGyCuentaContable As Integer = 7
    Private iGyNombreCuentaContable As Integer = 8
    Private iGyIDAdicional As Integer = 9
#End Region

#Region "Columnas grid series"
    Private igySeriePosicion As Short = 1
    Private igySerieCodigo As Short = 2
    Private igySerieDescripcion As Short = 3
    Private igySerieIdInventarioLotesCostos As Short = 4
    Private igySerieNumeroSerie As Short = 5
#End Region

    Private bAplicando As Boolean

    Private oPalet As Class_Embarques_PaletsGlobal

    Private oFormaDetalleCuentas As InventariosDetalleCuentasContables

    Private Enum enumEstados
        NUEVO
        GRABADO
        APLICADO
        CANCELADO
    End Enum

#Region "Propiedades"
    Public WriteOnly Property LlamdoExterior() As Boolean
        Set(ByVal Value As Boolean)
            Me._LlamdoExterior = Value
        End Set
    End Property

    Public WriteOnly Property CodigoDocumentoParaGrabar() As String
        Set(ByVal Value As String)
            Me._CodigoDocumentoParaGrabar = Value
        End Set
    End Property

    Public ReadOnly Property AplicadoExterior() As Boolean
        Get
            Return Me._AplicadoExterior
        End Get
    End Property

    Public Property FolioEmbarque() As String
        Get
            Return Me._FolioEmbarque
        End Get
        Set(ByVal value As String)
            Me._FolioEmbarque = value
        End Set
    End Property

    Public WriteOnly Property ConsultaExteriorSalida() As Boolean
        Set(ByVal value As Boolean)
            Me._ConsultaExteriorSalida = value
        End Set
    End Property

    Public WriteOnly Property CodigoAlmacenHappy() As String
        Set(ByVal Value As String)
            Me._CodigoAlmacenHappy = Value
        End Set
    End Property

#End Region

#Region "Opciones"
    Private Sub tsbNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbNuevo.Click
        Me.Inicializa()
        Me.Cambia_Estado(enumEstados.NUEVO)
    End Sub

    Private Sub tsbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGrabar.Click
        Me.bAplicando = False
        If txtLEN(Me.TxtFolio.Text) = True Then
            If Me.Grabar() = True Then
                If Me.Consultar() = True Then
                    'Me.Cambia_Estado(enumEstados.GRABADO)
                End If
            End If
        End If
    End Sub

    Private Sub tsbAplicar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbAplicar.Click
        If Me.Estado = enumEstados.NUEVO Then
            If Me.Grabar() = True Then
                Me.Consultar()
                Me.GestionaAplicacion()
            End If
        Else
            Me.GestionaAplicacion()
        End If
    End Sub

    Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click
        Me.Imprimir()
    End Sub

    Private Sub tsbCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCancelar.Click
        If Me.oInventarios.CODIGO_TIPO_DOCUMENTO = "ENI" Or Me.oInventarios.CODIGO_TIPO_DOCUMENTO = "SAI" Then
            Me.Cancelar()
        End If
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub

    Private Sub btnDocumentoAnterior_Click(sender As Object, e As EventArgs) Handles btnDocumentoAnterior.Click
        Me.Navegador("Anterior")
    End Sub

    Private Sub btnDocumentoSiguiente_Click(sender As Object, e As EventArgs) Handles btnDocumentoSiguiente.Click
        Me.Navegador("Siguiente")
    End Sub

    Private Sub tsbEditarCostos_Click(sender As Object, e As EventArgs) Handles tsbEditarCostos.Click
        Try
            Dim oCostos As New FrmCostosEdicion(Me.TxtFolio.Text, Me.CboDocumento.SelectedValue.ToString & Usuario.Codigo_Plaza)
            If oCostos.bMovimientoEncontrado = True Then
                oCostos.ShowDialog()
                oCostos.Dispose()
                Me.Consultar()
            End If
        Catch ex As Exception
            HandleError(Me.Name, "tsbEditarCostos_Click", ex)
        End Try
    End Sub
#End Region

#Region "Eventos"
    Private Sub Inventarios_Movimientos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim dTabla As DataTable
        'Dim dCajaCarton As Boolean

        If Me._LlamdoExterior = True Then

            Me.InicializaExterno()

            Me.TxtFolio.Text = Me._FolioEmbarque
            Me.Consultar()

            If Me.LblStatus.Text = "A" Then
                Me.tsbEditarCostos.Enabled = True
            End If

            Return

            'Este era el código que estba cuando se hacia una salida por cada palet.
            'Me.InicializaExterno()
            'Dim oPalet = New Class_Embarques_PaletsGlobal(Me.TxtFolioReferencia.Text)

            'Dim sql As New Class_find("SELECT count(CODIGO_ARTICULO) articulos,max(CODIGO_ARTICULO) FROM EMB_PALETS_DETALLE " & _
            '            "WHERE FOLIO_PALET='" & Me.TxtFolioReferencia.Text & "'")

            'If sql.Result1 = "1" Then
            '    Dim sql1 As New Class_find("SELECT 1 FROM CAT_PRODUCTOS_AGRICOLAS_FORMULAS_EMPAQUE WHERE CLAVE='CAJA_CARTON' AND CODIGO_PRODUCTO='" & sql.Result2 & "'")

            '    If sql1.Result1 = "1" Then
            '        dCajaCarton = True
            '    Else
            '        MsgBox("El producto no tiene configurado el material de empaque.", MsgBoxStyle.Information, "Aplicando Movimientos de Inventarios")
            '    End If

            '    dTabla = oPalet.ObtenerDetalleSalidaInventario(Me._FolioEmbarque) '.Rows.Count
            '    Me.Grid1.Rows = 1
            '    For Each dRow As DataRow In dTabla.Rows
            '        Me.Grid1.AddItem(dRow(0).ToString & Chr(9) & dRow(1).ToString & Chr(9) & dRow(2).ToString & Chr(9) & dRow(3).ToString & Chr(9) & dRow(4).ToString & Chr(9) & _
            '                        dRow(5).ToString & Chr(9))
            '    Next
            'End If

            'Me.FormateaGrid()

            'If Me.Grid1.Rows = 1 Then
            '    InicializaGrid()
            'End If

            'Me.Totales()
            'Me.Grid1.Focus()
            'Me.Visible = False

            'If dCajaCarton = True Then
            '    Me.tsbAplicar.PerformClick()
            'Else
            '    Me.Visible = True
            'End If


        ElseIf Me._ConsultaExteriorSalida = True Then
            Me.InicializaExterno()
            Dim sql As New Class_find("SELECT MAX(FOLIO_MOVIMIENTO_INVENTARIO)FOLIO_MOVIMIENTO_INVENTARIO FROM INVENTARIO_MOVIMIENTOS_GLOBAL WHERE FOLIO_REFERENCIA='" & Me.TxtFolioReferencia.Text & "' AND ESTA_CANCELADO='0'")
            Me.TxtFolio.Text = sql.Result1.ToString
            Me.Consultar()
            Me.tsbNuevo.Enabled = False
            Me.tsbCancelar.Enabled = False
        Else
            Me.Inicializa()
            Me.DesplegarDocumentos()
            Me.DesplegarAlmacenes()
            Me.DesplegarConceptosInventarios()
            Me.Cambia_Estado(enumEstados.NUEVO)
        End If
    End Sub

    Private Sub Grid1_KeyDown(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Grid1.KeyDown
        Me.GestionaGrid(e)
    End Sub

    Private Sub GridSeries_KeyDown(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridSeries.KeyDown
        Me.GestionaGridSeries(e)
    End Sub

    Private Sub BtnSeries_Click(sender As Object, e As EventArgs) Handles BtnSeries.Click
        Me.PrepararSeries()
    End Sub

    Private Sub Grid_ButtonClick(ByVal Sender As System.Object, ByVal e As FlexCell.Grid.ButtonClickEventArgs) Handles Grid1.ButtonClick
        Me.GestionaDetalleCuentas()
    End Sub

    Private Sub CmbAlmacenDestino_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CboAlmacenDestino.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.Send("{TAB}")
            Case Keys.Escape
                Me.CboAlmacen.Focus()
        End Select
    End Sub

    Private Sub cboCentros_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        txtTAB(e)
    End Sub

    Private Sub CmbDocumento_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CboDocumento.KeyDown
        txtTAB(e)
    End Sub

    Private Sub CmbDocumento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboDocumento.SelectedIndexChanged
        Me.OcultaControles()
        Me.GeneraFolio()
    End Sub

    Private Sub CmbAlmacen_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CboAlmacen.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.Send("{TAB}")
            Case Keys.Escape
                Me.CboDocumento.Focus()
        End Select
    End Sub

    Private Sub CmbAlmacen_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboAlmacen.SelectedIndexChanged
        Me.GeneraFolio()
    End Sub

    Private Sub DtpFecha_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtpFecha.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.Send("{TAB}")
            Case Keys.Escape
                Me.CboAlmacen.Focus()
        End Select
    End Sub

    Private Sub TxtFolioReferencia_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtFolioReferencia.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.Send("{TAB}")
            Case Keys.Escape
                Me.DtpFecha.Focus()
        End Select
    End Sub

    Private Sub TxtConcepto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtConcepto.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                Me.Grid1.Cell(1, 1).SetFocus()
            Case Keys.Escape
                Me.TxtFolioReferencia.Focus()
        End Select
    End Sub

    Private Sub TxtFolio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtFolio.KeyDown
        Select Case e.KeyCode
            Case Keys.F6
                Me.TxtFolio.Text = BusquedaVisual_PorDescripcion()
            Case Keys.Enter
                If Consultar() = False Then
                    Me.GeneraFolio()
                    Me.TxtFolioReferencia.Focus()
                End If
            Case Keys.Escape
                Me.CboAlmacen.Focus()
        End Select
    End Sub

    Private Sub txtFolioEmbarque_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFolioEmbarque.KeyDown
        Try
            Dim oEmbarque As Class_Embarques_EmbarqueGlobal

            Select Case e.KeyCode
                Case Keys.F6
busca:
                    oEmbarque = New Class_Embarques_EmbarqueGlobal
                    Me.txtFolioEmbarque.Text = oEmbarque.BusquedaVisual_Embarques_Nacional
                Case Keys.Enter
                    If txtLEN(Me.txtFolioEmbarque.Text) = False Then
                        GoTo busca : Exit Sub
                    Else
                        If Me.ValidaEmbarque = False Then
                            Me.txtFolioEmbarque.Text = ""
                            GoTo busca : Exit Sub
                        End If
                    End If
            End Select
        Catch ex As Exception
            HandleError(Me.Name, "txtFolioEmbarque_KeyDown", ex)
        End Try
    End Sub

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DtpFecha.KeyPress, TxtConcepto.KeyPress, TxtFolio.KeyPress, TxtFolioReferencia.KeyPress, txtFolioEmbarque.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub LblPoliza_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LblPoliza.LinkClicked
        Dim Child As New Frm_Contabilidad_Captura_Polizas()
        Child.FolioPolizaConsultaExterior = Me.LblPoliza.Text
        Child.ShowDialog()
        Child.Dispose()
    End Sub

#End Region

#Region "Métodos y procedimientos"

    Private Sub Cambia_Estado(ByVal pEstado As enumEstados)
        Try
            Me.Estado = pEstado

            Select Case Me.Estado
                Case enumEstados.NUEVO
                    Me.tsslEstado.Text = "ESTADO: AGREGANDO NUEVO MOVIMIENTO"
                    Me.tsslElaboro.Text = ""
                    Me.tsslCancelo.Text = ""
                    Me.tsbNuevo.Enabled = True
                    Me.tsbGrabar.Enabled = True
                    Me.tsbAplicar.Enabled = True
                    Me.tsbCancelar.Enabled = False
                    Me.tsbImprimir.Enabled = False
                    Me.tsbEditarCostos.Visible = False
                    Me.CboDocumento.Enabled = True
                    Me.DtpFecha.Enabled = True
                    Me.CboAlmacen.Enabled = True
                    Me.TxtFolio.Enabled = True
                    Me.TxtFolioReferencia.Enabled = True
                    Me.TxtConcepto.Enabled = True
                    Me.CboDocumento.Enabled = True
                    Me.CboAlmacenDestino.Enabled = True
                    Me.txtFolioEmbarque.Enabled = True
                    Me.Grid1.Locked = False
                    Me.GridSeries.Locked = False
                    Me.BtnSeries.Enabled = True
                    Me.CboConceptoInventario.Enabled = True

                    Me.OcultaControles()

                    If Me.Visible = True Then
                        Me.TxtFolio.Focus()
                    End If

                Case enumEstados.GRABADO
                    If Me._LlamdoExterior = True And txtLEN(Me.FolioEmbarque) = True Then
                        Return 'Los controles ya se activaron/desactivaron en el inicializaExterno
                    End If

                    Me.tsslEstado.Text = "ESTADO: CONSULTANDO MOVIMIENTO"
                    Me.tsslElaboro.Text = "ELABORO: " + Me.oInventarios.NOMBRE_USUARIO.ToUpper + " EL " + Format(Me.DtpFecha.Value, "dd/MMM/yy")
                    Me.tsslCancelo.Text = ""
                    Me.tsbNuevo.Enabled = True
                    Me.tsbGrabar.Enabled = True
                    Me.tsbAplicar.Enabled = True
                    Me.tsbCancelar.Enabled = True
                    Me.tsbImprimir.Enabled = True
                    Me.tsbEditarCostos.Visible = False
                    Me.CboDocumento.Enabled = False
                    Me.DtpFecha.Enabled = False
                    Me.CboAlmacen.Enabled = False
                    Me.TxtFolio.Enabled = False
                    Me.TxtFolioReferencia.Enabled = True
                    Me.TxtConcepto.Enabled = True
                    Me.CboDocumento.Enabled = False
                    Me.CboAlmacenDestino.Enabled = False
                    Me.txtFolioEmbarque.Enabled = True
                    Me.Grid1.Locked = False
                    Me.GridSeries.Locked = False
                    Me.BtnSeries.Enabled = True
                    Me.CboConceptoInventario.Enabled = False

                    Me.OcultaControles()

                    Me.TxtConcepto.Focus()

                Case enumEstados.APLICADO
                    Me.tsslEstado.Text = "ESTADO: CONSULTANDO MOVIMIENTO"
                    Me.tsslElaboro.Text = "ELABORO: " + Me.oInventarios.NOMBRE_USUARIO.ToUpper + " EL " + Format(Me.DtpFecha.Value, "dd/MMM/yy")
                    Me.tsslCancelo.Text = ""
                    Me.tsbNuevo.Enabled = True
                    Me.tsbGrabar.Enabled = False
                    Me.tsbAplicar.Enabled = False
                    Me.tsbCancelar.Enabled = True
                    Me.tsbImprimir.Enabled = True
                    Me.tsbEditarCostos.Visible = True
                    Me.DtpFecha.Enabled = False
                    Me.CboAlmacen.Enabled = False
                    Me.TxtFolio.Enabled = False
                    Me.TxtFolioReferencia.Enabled = False
                    Me.TxtConcepto.Enabled = False
                    Me.CboDocumento.Enabled = False
                    Me.CboAlmacenDestino.Enabled = False
                    Me.txtFolioEmbarque.Enabled = False
                    Me.Grid1.Locked = True
                    Me.BtnSeries.Enabled = False
                    Me.GridSeries.Locked = True
                    Me.CboConceptoInventario.Enabled = False

                    Me.tsbImprimir.Select()

                Case enumEstados.CANCELADO
                    Me.tsslEstado.Text = "ESTADO: CONSULTANDO MOVIMIENTO"
                    Me.tsslElaboro.Text = "ELABORO: " + Me.oInventarios.NOMBRE_USUARIO.ToUpper + " EL " + Format(Me.DtpFecha.Value, "dd/MMM/yy")
                    Me.tsslCancelo.Text = "CANCELO: " + Me.oInventarios.NOMBRE_USUARIO_CANCELO.ToUpper + " EL " + Format(Me.oInventarios.FECHA_CANCELACION, "dd/MMM/yy")
                    Me.tsbNuevo.Enabled = True
                    Me.tsbGrabar.Enabled = False
                    Me.tsbAplicar.Enabled = False
                    Me.tsbCancelar.Enabled = False
                    Me.tsbImprimir.Enabled = True
                    Me.tsbEditarCostos.Visible = False
                    Me.DtpFecha.Enabled = False
                    Me.CboAlmacen.Enabled = False
                    Me.TxtFolio.Enabled = False
                    Me.TxtFolioReferencia.Enabled = False
                    Me.TxtConcepto.Enabled = False
                    Me.CboDocumento.Enabled = False
                    Me.CboAlmacenDestino.Enabled = False
                    Me.txtFolioEmbarque.Enabled = False
                    Me.Grid1.Locked = True
                    Me.BtnSeries.Enabled = False
                    Me.GridSeries.Locked = False
                    Me.CboConceptoInventario.Enabled = False

                    Me.tsbImprimir.Select()
            End Select
            Application.DoEvents()

        Catch ex As Exception
            HandleError(Me.Name, "Cambia_Estado", ex)
        End Try
    End Sub

    Private Sub Inicializa()
        Try
            Me.TxtFolio.Text = ""
            Me.txtTotal.Text = ""
            Me.txtTotalCantidad.Text = ""
            Me.TxtFolioReferencia.Text = ""
            Me.TxtConcepto.Text = ""
            Me.DtpFecha.Value = Date.Now
            Me.Grid1.DataSource = Nothing
            Me.LblPoliza.Text = ""

            Me.InicializaGrid()
            Me.InicializaGridSeries()

            Me.DtpFecha.Value = Date.Now
            Me.TxtConcepto.Text = ""
            Me.LblStatus.Text = ""

            Me.txtFolioEmbarque.Text = ""

            Me.GeneraFolio()

            Me.TxtFolioReferencia.Focus()

            Me.oFormaDetalleCuentas = Nothing 'New InventariosDetalleCuentasContables

            Me.dtSeries = New DataTable("Series")

            Me.TabControl1.SelectedIndex = 0

        Catch ex As Exception
            HandleError(Me.Name, "Inicializa", ex)
        End Try
    End Sub

    Private Sub InicializaExterno()
        Try
            Me.DesplegarDocumentos(False)
            Me.DesplegarAlmacenes()
            Me.DesplegarConceptosInventarios()

            Me.CboDocumento.SelectedValue = Me._CodigoDocumentoParaGrabar.ToString

            'Me.oPalet = New Class_Embarques_PaletsGlobal(Me.TxtFolioReferencia.Text) 'El folio de la referencia desde afuera se lleno con el folio de palet
            'Me.CboAlmacen.SelectedValue = oPalet.CODIGO_ALMACEN
            'Me.DtpFecha.Value = oPalet.FECHA

            If txtLEN(Me._CodigoAlmacenHappy) = True Then
                Me.TxtConcepto.Text = "TRANSFERENCIA EMPAQUE PALET " & Me.TxtFolioReferencia.Text
                Me.CboAlmacenDestino.Visible = True
            Else
                Me.TxtConcepto.Text = "SALIDA EMPAQUE PALET " & Me.TxtFolioReferencia.Text
                Me.CboAlmacenDestino.Visible = False
            End If

            Me.LblPoliza.Text = ""

            Me.InicializaGrid()

            Me.tsbNuevo.Enabled = False
            Me.tsbGrabar.Enabled = False
            Me.tsbAplicar.Enabled = True
            Me.tsbCancelar.Enabled = False
            Me.tsbImprimir.Enabled = False
            Me.tsbEditarCostos.Enabled = False

            Me.DtpFecha.Enabled = False
            Me.CboAlmacen.Enabled = False
            Me.TxtFolio.Enabled = False
            Me.TxtFolioReferencia.Enabled = False
            Me.CboDocumento.Enabled = False
            Me.CboAlmacenDestino.Enabled = False
            Me.Grid1.Locked = False
            Me.tsslEstado.Text = "ESTADO: AGREGANDO NUEVO MOVIMIENTO"
            Me.tsslElaboro.Text = ""
            Me.tsslCancelo.Visible = False
        Catch ex As Exception
            HandleError(Me.Name, "InicializaExterno", ex)
        End Try
    End Sub

    Private Sub InicializaGrid()
        Try
            FG_Grid_Limpiar(Me.Grid1)
            Me.Grid1.Rows = 2
            Me.FormateaGrid()
            Me.Totales()

            Me.Grid1.Cell(1, Me.iGyIDAdicional).Text = "1"
        Catch ex As Exception
            HandleError(Me.Text, "InicializaGrid", ex)
        End Try
    End Sub

    Private Sub GestionaGrid(ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            Dim Columna As Integer, Renglon As Integer
            Dim StrCod As String, DCosto As Double, sCuentaContable As String, sCodArticulo As String, sNaturalezaInventarios As String, dExistencia As Double, sCantidad As String
            Dim oCuentas As New Class_CatCuentas 'Class_VWCatDeudoresDiversos

            Me.oArticulos = New Class_CatArticulos

            Select Case e.KeyCode
                Case Keys.Enter
                    Columna = Me.Grid1.Selection.FirstCol
                    Renglon = Me.Grid1.Selection.FirstRow
                    StrCod = Me.Grid1.Cell(Renglon, iGyCodigo).Text
                    sCantidad = Me.Grid1.Cell(Renglon, iGyCantidad).Text

                    Me.oArticulos.CODIGO_ARTICULO = StrCod
                    If Me.oArticulos.Consultar() = False Then
                        GoTo BuscaArticulos
                    End If

                    If oArticulos.ESTATUS = "B" Then
                        oArticulos.CODIGO_ARTICULO = ""
                        oArticulos.DESCRIPCION = ""
                    End If
                    sNaturalezaInventarios = oInventarios.NaturalezaInventarios(Me.CboDocumento.SelectedValue.ToString)

                    Select Case Columna
                        Case Me.iGyCodigo
                            If Me.oArticulos.DESCRIPCION = "" Then
                                MsgBox("El código de artículo que intenta buscar no existe o esta dado de baja, favor de intentar con otro código.", MsgBoxStyle.Exclamation, "Validación de artículos")
                                Me.Grid1.Cell(Renglon, iGyCodigo).SetFocus()
                                Exit Sub
                            Else
                                DCosto = 0
                                If sNaturalezaInventarios = "SA" Then
                                    Me.Grid1.Column(Me.iGyCosto).Locked = True
                                    DCosto = Me.oInventarios.oInventariosDetalle.Obtener_Costo(StrCod, Me.CboAlmacen.SelectedValue.ToString, 1)
                                Else
                                    Me.Grid1.Column(Me.iGyCosto).Locked = False
                                End If
                                Me.Grid1.Cell(Renglon, Me.iGyDescripcion).Text = Me.oArticulos.DESCRIPCION
                                Me.Grid1.Cell(Renglon, Me.iGyCosto).Text = DCosto.ToString
                                If Me._LlamdoExterior = False Then
                                    Me.Grid1.Cell(Renglon, Me.iGyImporte).Text = "0"
                                    Me.Grid1.Cell(Renglon, Me.iGyCantidad).Text = "0"
                                End If
                            End If
                            Me.oArticulos = Nothing

                        Case Me.iGyCantidad
                            If sNaturalezaInventarios = "SA" Then
                                'Dim sql3 As New Class_find("Select Existencia From INVENTARIO_EXISTENCIA_ARTICULOS Where CODIGO_Articulo='" & Grid1.Cell(Renglon, iGyCodigo).Text & "' and Codigo_Almacen='" & CboAlmacen.SelectedValue.ToString & "'")
                                'If valorNumerico(sql3.Result1) < valorNumerico(StrCod) Then
                                If Me.oArticulos.INVENTARIABLE <> "0" Then
                                    dExistencia = oInventarios.Existencia(Me.Grid1.Cell(Renglon, Me.iGyCodigo).Text, Me.CboAlmacen.SelectedValue.ToString)
                                    If valorNumerico(sCantidad) > valorNumerico(dExistencia.ToString) Then 'if capturaron>existencia
                                        Dim dDiferencia As Double = valorNumerico(sCantidad) - dExistencia
                                        MsgBox("El artículo que intenta agregar no tiene suficiente existencia." & vbCrLf & _
                                                "Existencia " & Format(dExistencia, "###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CANTIDAD)) & ", faltan " & Format(dDiferencia, "###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CANTIDAD)), MsgBoxStyle.Exclamation, "Validación de existencias")
                                        'Me.Grid1.Cell(Renglon, Me.iGyCantidad).Text = "0"
                                        'Me.Grid1.Cell(Renglon, Me.iGyDescripcion).SetFocus()
                                        'Me.Totales()
                                    End If
                                End If
                            End If
                            DCosto = valorNumerico(Me.oInventarios.oInventariosDetalle.Obtener_Costo(Me.Grid1.Cell(Renglon, Me.iGyCodigo).Text, Me.CboAlmacen.SelectedValue.ToString, valorNumerico(Me.Grid1.Cell(Renglon, Me.iGyCantidad).Text)).ToString)
                            Me.Grid1.Cell(Renglon, Me.iGyCosto).Text = DCosto.ToString

                        Case Me.iGyCuentaContable 'Enter
                            If Me.oDocumentos.ES_TRANSFERENCIA <> "1" Then
                                sCuentaContable = Me.Grid1.Cell(Renglon, Me.iGyCuentaContable).Text

                                'If sCuentaContable.StartsWith("1") = False Then
                                '    Me.Grid1.Cell(Renglon, Me.iGyCuentaContable).Text = ""
                                '    Me.Grid1.Cell(Renglon, Me.iGyNombreCuentaContable).Text = ""
                                '    MsgBox("La cuenta contable del renglón : " & Renglon & " debe ser del rango de las miles(que empiezen con 1).", MsgBoxStyle.Exclamation, Me.Name)
                                '    Return
                                'End If

                                oCuentas = New Class_CatCuentas(sCuentaContable) 'Class_VWCatDeudoresDiversos(sCuentaContable) 

                                If oCuentas._Existe = True Then
                                    Me.Grid1.Cell(Renglon, Me.iGyCuentaContable).Text = oCuentas.CUENTA_CONTABLE
                                    Me.Grid1.Cell(Renglon, Me.iGyNombreCuentaContable).Text = oCuentas.NOMBRE_CUENTA
                                Else
                                    Me.Grid1.Cell(Renglon, Me.iGyCuentaContable).Text = ""
                                    Me.Grid1.Cell(Renglon, Me.iGyNombreCuentaContable).Text = ""
                                    GoTo BuscarCuentas : Exit Sub
                                End If

                            End If

                    End Select

                    If Me.Grid1.Rows = Renglon + 1 Then 'Si se está en el último renglón, se agrega un renglón más.
                        Me.Grid1.Rows = Me.Grid1.Rows + 1
                        Me.Grid1.Cell(Renglon + 1, Me.iGyIDAdicional).Text = (CInt(Me.Grid1.Cell(Renglon, Me.iGyIDAdicional).Text) + 1).ToString
                    End If

                    'Select Case Columna
                    '    Case Me.iGyCodigo
                    '        Me.Grid1.Cell(Renglon, Me.iGyDescripcion).SetFocus()
                    '    Case Me.iGyCuentaContable
                    '        Me.Grid1.Cell(Renglon + 1, iGyCodigo).SetFocus()
                    '    Case Else
                    '        Me.Grid1.Cell(Renglon, Columna).SetFocus()
                    'End Select

                    Me.Totales()

                Case Keys.F6, Keys.F7

                    Columna = Me.Grid1.Selection.FirstCol
                    Renglon = Me.Grid1.Selection.FirstRow

                    Select Case Columna
                        Case Me.iGyCodigo
                            If e.KeyCode = Keys.F6 Then
BuscaArticulos:
                                sCodArticulo = Me.oArticulos.BusquedaVisualInventariablesConExistencia_PorDescripcion(Me.CboAlmacen.SelectedValue.ToString)
                                If Len(sCodArticulo) > 0 Then
                                    Me.Grid1.Cell(Renglon, Me.iGyDescripcion).Text = Me.oArticulos.BuscarNombreArticulo(sCodArticulo)
                                    Me.Grid1.Cell(Renglon, Me.iGyCodigo).Text = sCodArticulo
                                    Me.Grid1.Cell(Renglon, Me.iGyCosto).Text = DCosto.ToString
                                    If Me._LlamdoExterior = False Then
                                        Me.Grid1.Cell(Renglon, Me.iGyImporte).Text = "0"
                                        Me.Grid1.Cell(Renglon, Me.iGyCantidad).Text = "0"
                                    End If
                                End If
                                Me.Grid1.Cell(Renglon, iGyCodigo).SetFocus()

                            ElseIf e.KeyCode = Keys.F7 Then

                                sCodArticulo = Me.oArticulos.BusquedaVisualInventariablesConExistencia_PorCodigo(Me.CboAlmacen.SelectedValue.ToString)
                                If Len(sCodArticulo) > 0 Then
                                    Me.Grid1.Cell(Renglon, Me.iGyDescripcion).Text = Me.oArticulos.BuscarNombreArticulo(sCodArticulo)
                                    Me.Grid1.Cell(Renglon, Me.iGyCodigo).Text = sCodArticulo
                                    Me.Grid1.Cell(Renglon, Me.iGyCosto).Text = DCosto.ToString
                                    If Me._LlamdoExterior = False Then
                                        Me.Grid1.Cell(Renglon, Me.iGyImporte).Text = "0"
                                        Me.Grid1.Cell(Renglon, Me.iGyCantidad).Text = "0"
                                    End If
                                End If
                                Me.Grid1.Cell(Renglon, iGyCodigo).SetFocus()

                            End If

                        Case Me.iGyCuentaContable
                            If Me.oDocumentos.ES_TRANSFERENCIA = "1" Then
                                Exit Sub
                            Else
BuscarCuentas:
                                'If e.KeyCode = Keys.F6 Then
                                '    sCuentaContable = oCuentas.BusquedaVisual_PorCodigoConLike("1")
                                'Else 'F7
                                '    sCuentaContable = oCuentas.BusquedaVisual_PorDescripcionConLike("1")
                                'End If

                                If e.KeyCode = Keys.F6 Then
                                    sCuentaContable = oCuentas.BusquedaVisual_PorCodigo
                                Else 'F7
                                    sCuentaContable = oCuentas.BusquedaVisual_PorDescripcion
                                End If
                            End If

                            If sCuentaContable = "" Then
                                Return
                            End If

                            If txtLEN(sCuentaContable) = True Then
                                'oCuentas = New Class_VWCatDeudoresDiversos(sCuentaContable)
                                oCuentas = New Class_CatCuentas(sCuentaContable)
                                If oCuentas._Existe = True Then
                                    Me.Grid1.Cell(Renglon, Me.iGyCuentaContable).Text = oCuentas.CUENTA_CONTABLE
                                    Me.Grid1.Cell(Renglon, Me.iGyNombreCuentaContable).Text = oCuentas.NOMBRE_CUENTA
                                    Me.Grid1.Cell(Renglon + 1, iGyCodigo).SetFocus()
                                End If
                            End If
                    End Select

                    '            Case Keys.F7
                    'BuscarCuentas:
                    '                Columna = Me.Grid1.Selection.FirstCol
                    '                Renglon = Me.Grid1.Selection.FirstRow

                    '                If Me.oDocumentos.ES_TRANSFERENCIA = "1" Then
                    '                    Exit Sub
                    '                Else
                    '                    sCuentaContable = Me.oCuentas.BusquedaVisual_PorCodigoFiltrandoTipoOperacion()
                    '                    If txtLEN(sCuentaContable) = True Then
                    '                        Me.oCuentas = New Class_CatCuentas(sCuentaContable)
                    '                        If Me.oCuentas._Existe = True Then
                    '                            Me.Grid1.Cell(Renglon, Me.iGyCuentaContable).Text = Me.oCuentas.CUENTA_CONTABLE
                    '                            Me.Grid1.Cell(Renglon, Me.iGyNombreCuentaContable).Text = Me.oCuentas.NOMBRE_CUENTA_NIVELES_COMPLETOS
                    '                            Me.Grid1.Cell(Renglon + 1, iGyCodigo).SetFocus()
                    '                        End If
                    '                    End If
                    '                End If

                Case Keys.F8, Keys.Delete
                    Renglon = Me.Grid1.Selection.FirstRow

                    If Me._LlamdoExterior = True Then
                        MsgBox("No se permiten eliminar renglones en las salidas de empaque de embarques.", MsgBoxStyle.Exclamation, Me.Text)
                        e.SuppressKeyPress = True
                        Return
                    End If

                    If (Me.Estado = enumEstados.NUEVO Or Me.Estado = enumEstados.GRABADO) Then
                        Dim IDAdicional As Integer = CInt(Me.Grid1.Cell(Renglon, Me.iGyIDAdicional).Text)

                        Me.Grid1.Selection.DeleteByRow()
                        e.SuppressKeyPress = True
                        Me.Totales()
                        If Me.Grid1.Rows = 1 Then
                            Me.InicializaGrid() 'Para que reestablesca el idAdicional desde el 1
                        End If

                        Me.EliminaDetalleCuentasContables(IDAdicional)
                    End If
            End Select

        Catch ex As Exception
            HandleError(Me.Name, "GestionaGrid", ex)
        End Try
    End Sub

    Function Grabar() As Boolean
        Dim bResultado As Boolean = False
        Dim i As Integer
        Dim sListaSeries As String = ""

        If Me.oDocumentos.ES_TRANSFERENCIA = "1" Then
            If Usuario.ValidaPermisoUsuarioTiposDocumentosConAfectaInventarios(Me.CboDocumento.SelectedValue.ToString, Me.CboAlmacen.SelectedValue.ToString, Me.CboAlmacenDestino.SelectedValue.ToString) = False Then
                'MsgBox("El usuario " & Usuario.Nombre_Usuario & " no tiene permiso para realizar la transferencia.", MsgBoxStyle.Information, Me.Text)
                Exit Function
            End If
        Else
            If Usuario.ValidaPermisoUsuarioTiposDocumentosConAfectaInventarios(Me.CboDocumento.SelectedValue.ToString, Me.CboAlmacen.SelectedValue.ToString, "") = False Then
                'MsgBox("El usuario " & Usuario.Nombre_Usuario & " no tiene permiso para realizar el movimiento de inventarios.", MsgBoxStyle.Information, Me.Text)
                Exit Function
            End If
        End If

        If Me.bAplicando = False Then
            If MsgBox("Deseas grabar el movimiento de " & CboDocumento.Text & "?", CType(vbYesNo + vbQuestion, MsgBoxStyle), "Grabando movimientos de inventarios") = MsgBoxResult.No Then
                Exit Function
            End If
        End If

        If Plaza.ValidarPeriodoTrabajo(Me.DtpFecha.Value) = False Then 'Para grabar se valida con la fecha que el usuario tiene en el datepicker
            Exit Function
        End If

        If SiTieneRenglones() = False Then
            MsgBox("Asígne los artículos del movimiento.", MsgBoxStyle.Exclamation, Me.Text)
            Exit Function
        End If

        If txtLEN(Me.txtFolioEmbarque.Text) = True Then
            If Me.ValidaEmbarque = False Then
                Me.txtFolioEmbarque.Focus()
                Exit Function
            End If
        End If

        If Me.oDocumentos.ES_TRANSFERENCIA <> "1" Then
            If Me.ValidaCuentasContable = False Then
                Exit Function
            End If
        End If

        If Me.SiTieneCantidad() = False Then
            MsgBox("La cantidad de los artículos debe de ser mayor a cero.", MsgBoxStyle.Exclamation, Me.Text)
            Exit Function
        End If

        If Me.ValidaNumerosSerie() = False Then
            Exit Function
        End If

        If Me.HaySeriesRepetidas = True Then
            Exit Function
        End If

        Me.Totales()

        'Me.oInventarios = New Class_Inventarios_Global

        Select Case Me.Estado
            Case enumEstados.NUEVO, enumEstados.GRABADO
                Me.oInventarios = New Class_Inventarios_Global
                Try
                    With oInventarios
                        .FOLIO_MOVIMIENTO_INVENTARIO = Me.TxtFolio.Text.ToUpper
                        .CODIGO_TIPO_DOCUMENTO = "" & Me.CboDocumento.SelectedValue.ToString()
                        .FOLIO_REFERENCIA = Me.TxtFolioReferencia.Text
                        .CODIGO_ALMACEN1 = "" & Me.CboAlmacen.SelectedValue.ToString()
                        If Me.oDocumentos.ES_TRANSFERENCIA = "1" Then
                            .CODIGO_ALMACEN2 = "" & Me.CboAlmacenDestino.SelectedValue.ToString()
                        End If
                        .FECHA = Me.DtpFecha.Value
                        .CONCEPTO = "" & Me.TxtConcepto.Text
                        .CODIGO_USUARIO = CInt("" & Usuario.Codigo_Usuario)
                        .CODIGO_PLAZA = Usuario.Codigo_Plaza
                        .TOTAL = valorNumerico(Me.txtTotal.Text)
                        .FOLIO_EMBARQUE = Me.txtFolioEmbarque.Text
                        .CODIGO_CONCEPTO_INVENTARIOS = CInt(Me.CboConceptoInventario.SelectedValue)

                        Select Case Me.Estado
                            Case enumEstados.NUEVO
                                If .Insertar() = False Then
                                    MsgBox("Error al tratar de insertar el movimiento de inventario.", MsgBoxStyle.Exclamation, Me.Text)
                                    Exit Function
                                End If
                                Me.TxtFolio.Text = .FOLIO_MOVIMIENTO_INVENTARIO

                            Case enumEstados.GRABADO
                                If Me.oInventarios.Actualizar() = False Then
                                    MsgBox("Error al tratar de actualizar el movimiento de inventario.", MsgBoxStyle.Exclamation, Me.Text)
                                    Exit Function
                                End If
                        End Select

                        'se graba el detalle
                        For i = 1 To Me.Grid1.Rows - 1
                            If txtLEN(Me.Grid1.Cell(i, Me.iGyCodigo).Text) = True Then
                                .NuevoRenglon()
                                .oInventariosDetalle.FOLIO_MOVIMIENTO_INVENTARIO = .FOLIO_MOVIMIENTO_INVENTARIO
                                .oInventariosDetalle.CODIGO_ARTICULO = Me.Grid1.Cell(i, Me.iGyCodigo).Text
                                .oInventariosDetalle.CANTIDAD = valorNumerico(Me.Grid1.Cell(i, Me.iGyCantidad).Text)
                                .oInventariosDetalle.COSTO = valorNumerico(Me.Grid1.Cell(i, Me.iGyCosto).Text)
                                .oInventariosDetalle.CUENTA_CONTABLE = Me.Grid1.Cell(i, Me.iGyCuentaContable).Text.ToString
                                .oInventariosDetalle.IMPORTE = CDec(valorNumerico(Me.Grid1.Cell(i, Me.iGyImporte).Text.ToString))
                                .oInventariosDetalle.ID_ADICIONAL = CInt(valorNumerico(Me.Grid1.Cell(i, Me.iGyIDAdicional).Text))

                                If Me.dtSeries.Rows.Count > 0 Then
                                    For Each dRow In Me.dtSeries.Select("POSICION='" & i.ToString & "'")
                                        sListaSeries = sListaSeries & dRow("POSICION").ToString & "," & dRow("CODIGO_ARTICULO").ToString & "," & dRow("ID_INVENTARIO_LOTES_COSTOS").ToString & "," & dRow("NUMERO_SERIE").ToString & "|"
                                    Next

                                    If txtLEN(sListaSeries) = True Then
                                        sListaSeries = sListaSeries.Substring(0, sListaSeries.Length - 1) 'Para quitarle el último pipe que sale sobrando.
                                    End If
                                End If

                                .oInventariosDetalle.LISTA_SERIES = sListaSeries

                                If .oInventariosDetalle.GrabaRenglon() = False Then
                                    MsgBox("Error al tratar de grabar el detalle.", MsgBoxStyle.Exclamation, Me.Text)
                                    Exit Function
                                End If

                                sListaSeries = ""
                            End If
                        Next

                        Dim sListaCuentas As String = ""

                        If IsNothing(Me.oFormaDetalleCuentas) = False Then 'Si no esta vacia, osea si existe
                            Me.oFormaDetalleCuentas.FolioMovimientoInventario = Me.TxtFolio.Text 'Hasta aqui la forma auxuliar no tenia el folio
                            sListaCuentas = Me.oFormaDetalleCuentas.ObtieneListaDetalleCuentas()
                        End If

                        If txtLEN(sListaCuentas) = True Then
                            .oInventariosDetalle.GrabaDetalleCentroCostos(sListaCuentas, Me.CboDocumento.SelectedValue.ToString & Usuario.Codigo_Plaza, Me.DtpFecha.Value, CBool(IIf(Me.oDocumentos.NATURALEZA_INVENTARIOS = "EN", True, False)))
                        End If

                        bResultado = True
                        If Me.bAplicando = False Then
                            MsgBox("Movimiento de inventario grabado satisfactoriamente.", MsgBoxStyle.Information, Me.Text)
                        End If
                    End With
                Catch ex As Exception
                    HandleError(Me.Name, "Grabar", ex)
                    Me.Consultar()
                Finally
                    Me.oInventarios = Nothing
                End Try
        End Select

        Return bResultado
    End Function

    Function Aplicar() As Boolean
        Dim bResultado As Boolean = False
        Try

            If Me._LlamdoExterior = False Then
                If MsgBox("Deseas aplicar el movimiento de " & CboDocumento.Text & "?", CType(vbYesNo + vbQuestion, MsgBoxStyle), "Grabando movimientos de inventarios") = MsgBoxResult.No Then
                    Exit Function
                End If

                If Me.Grabar() = False Then 'Razón no identificada de porque cuando se trata de exterior lo graba despues de validar, y cuando es normal lo graba antes de validar
                    Exit Function
                End If
            End If

            'If SiTieneCuentaContable() = False Then
            '    MsgBox("Asígne la cuenta contable de todos los renglones.", MsgBoxStyle.Exclamation, Me.Text)
            '    Exit Function
            'End If

            If Me.ValidaCuentasContable = False Then
                Exit Function
            End If

            'If Me.SiTieneImporte() = False Then
            '    MsgBox("El importe de los renglones debe de ser mayor a cero.", MsgBoxStyle.Exclamation, Me.Text)
            '    Exit Function
            'End If

            Me.Totales()

            'If valorNumerico(Me.txtTotal.Text) = 0 Then
            '    MsgBox("El importe total debe de ser mayor a cero.", MsgBoxStyle.Exclamation, Me.Text)
            '    Exit Function
            'End If

            If Me._LlamdoExterior = True Then
                If Me.Grabar() = False Then 'Razón no identificada de porque cuando se trata de exterior lo graba despues de validar, y cuando es normal lo graba antes de validar
                    Exit Function
                End If
            Else
                If Me.oDocumentos.ES_TRANSFERENCIA = "1" Then
                    If EstableceCuentaContableAlmacenDestino() = False Then
                        MsgBox("Error al tratar de asígnar la cuenta contable del almacen destino.", MsgBoxStyle.Exclamation, Me.Text)
                        Exit Function
                    End If
                End If
            End If

            Me.oInventarios = New Class_Inventarios_Global(Me.TxtFolio.Text)

            bResultado = Me.oInventarios.Aplicar()
            If bResultado = True Then
                If Me.oInventarios.AplicarPoliza() = False Then
                    MsgBox("Error al intentar aplicar la poliza.", MsgBoxStyle.Exclamation, Me.Text)
                End If
            Else
                MsgBox("Error al intentar aplicar el movimiento de inventario.", MsgBoxStyle.Exclamation, Me.Text)
            End If
        Catch ex As Exception
            HandleError(Me.Name, "Aplicar", ex)
        End Try

        Return bResultado
    End Function

    Private Function Cancelar() As Boolean
        Dim oFirmaElectronica = New UtileriasFirmaElectronicaCancelacionMovimientosFueraPeriodo
        Dim oUtileriasCancela As New Class_UtileriasFirmaElectronicaCancelacion
        Dim oPoliza As New Class_Contabilidad_Poliza_Global

        If Me.oDocumentos.ES_CANCELABLE = "0" Then
            MsgBox("Este documento no se puede cancelar directamente por el usuario.", MsgBoxStyle.Exclamation, Me.Text)
            Exit Function
        ElseIf Me.oDocumentos.ES_CANCELABLE = "2" Then
            If Me.oInventarios.ESTATUS <> "G" Then
                MsgBox("Este documento sólo se puede cancelar si esta en estatus de GRABADO.", MsgBoxStyle.Exclamation, Me.Text)
                Exit Function
            End If
        End If

        If Me.CboDocumento.Text = "ENTRADA" And Me.GridSeries.Rows > 1 Then
            MsgBox("La cancelación de ENTRADAS con series no esta soportada, debe hacerse una salida manualmente.", MsgBoxStyle.Exclamation, Me.Text)
            Exit Function
        End If

        If Me.oDocumentos.ES_TRANSFERENCIA = "1" Then
            If Usuario.ValidaPermisoUsuarioTiposDocumentosConAfectaInventarios(Me.CboDocumento.SelectedValue.ToString, Me.CboAlmacen.SelectedValue.ToString, Me.CboAlmacenDestino.SelectedValue.ToString) = False Then
                MsgBox("El usuario " & Usuario.Nombre_Usuario & " no tiene permiso para realizar la transferencia.", MsgBoxStyle.Exclamation, Me.Text)
                Exit Function
            End If
        Else
            If Usuario.ValidaPermisoUsuarioTiposDocumentosConAfectaInventarios(Me.CboDocumento.SelectedValue.ToString, Me.CboAlmacen.SelectedValue.ToString, "") = False Then
                'MsgBox("El usuario " & Usuario.Nombre_Usuario & " no tiene permiso para realizar el movimiento de inventarios.", MsgBoxStyle.Exclamation, Me.Text)
                Exit Function
            End If
        End If

        If Me.oInventarios.CODIGO_TIPO_DOCUMENTO = "ENI" And Me.oInventarios.ESTATUS = "A" Then
            If Me.ValidarExistencias() = False Then
                Exit Function
            End If
        End If

        If MsgBox("Deseas cancelar el movimiento de " & CboDocumento.Text & "?", CType(vbYesNo + vbQuestion, MsgBoxStyle), "cancelando movimientos de inventarios") = MsgBoxResult.No Then
            Exit Function
        End If

        'If PLAZA.ValidarPeriodoTrabajo(Date.Now) = False Then 'Para cancelar se valida con la fecha de la maquina
        '    Exit Function
        'End If

        Try
            oUtileriasCancela.FOLIO_DOCUMENTO = Me.TxtFolio.Text.ToUpper
            oUtileriasCancela.MODULO = Me.oInventarios.CODIGO_MODULO
            oUtileriasCancela.CODIGO_PLAZA = Usuario.Codigo_Plaza

            If oUtileriasCancela.GestionaCancelacion() = False Then
                Exit Function
            End If

            If oUtileriasCancela.CANCELA_DIRECTO = True Then
                Me.oInventarios.FECHA_CANCELACION = Date.Now

                If Me.oInventarios.Cancelar() = False Then
                    Exit Function
                End If
            Else
                oUtileriasCancela = New Class_UtileriasFirmaElectronicaCancelacion
                oUtileriasCancela.FOLIO_DOCUMENTO = Me.TxtFolio.Text
                oUtileriasCancela.FOLIO_POLIZA = Me.oInventarios.FOLIO_POLIZA
                oUtileriasCancela.CODIGO_DOCUMENTO = Me.CboDocumento.SelectedValue.ToString
                oUtileriasCancela.CODIGO_PLAZA = Usuario.Codigo_Plaza
                oUtileriasCancela.MODULO = Me.oInventarios.CODIGO_MODULO

                If oUtileriasCancela.AutorizaCancelacionMovimientosFueraPeriodo() = False Then
                    'MsgBox("Error al tratar de autorizar la cancelación fuera del periodo.", MsgBoxStyle.Exclamation, Me.Text)
                    Exit Function
                End If

                'si no se autorizo
                If oUtileriasCancela.CANCELACION_AUTORIZO = False Then
                    MsgBox("No se autorizó la cancelación de movimiento.", MsgBoxStyle.Exclamation, Me.Text)
                    Exit Function
                End If

                If oUtileriasCancela.GestionaCancelacionConInterfaz() = False Then
                    MsgBox("Error al gestionar la cancelacion con interfaz", MsgBoxStyle.Information, Me.Text)
                    Exit Function
                Else
                    If oUtileriasCancela.ES_FECHA_CANCELACION_VALIDA = "0" Then
                        MsgBox("La fecha de cancelación debe de ser mayor o igual a la fecha del documento y debe estar en el mismo ejercicio.", vbExclamation, Me.Text)
                        Exit Function
                    End If

                    Me.oInventarios.FECHA_CANCELACION = oUtileriasCancela.FECHA_CANCELACION  'CDate(Format(oUtileriasCancela.CANCELACION_NUEVA_FECHA_CANCELACION, "dd/MM/yyyy")) + " " + CDate(Format(Now, "hh:mm"))
                    'oPoliza.ID_CON_PERIODO = oUtileriasCancela.PERIODO_CANCELACION_INTERFAZ

                    If Me.oInventarios.Cancelar() = False Then
                        MsgBox("Error al intentar cancelar el movimiento de inventario.", MsgBoxStyle.Exclamation, Me.Text)
                        Exit Function
                    End If
                End If
            End If

            MsgBox("Movimiento de inventario cancelado.", MsgBoxStyle.Information, Me.Text)
            Cancelar = True
            Me.Consultar()
        Catch ex As Exception
            HandleError(Me.Name, "Cancelar", ex)
        End Try
    End Function

    Private Function ValidarExistencias() As Boolean
        Const sProcedure As String = "Validación de existencias de Articulos"
        Dim bResultado As Boolean = False
        Dim dCantidadSumadaPorArticulos As Double, dExistencia As Double
        Dim i As Integer, sCodigoArticulo As String = ""

        Try
            'If oInventarios.NATURALEZA_INVENTARIOS = "EN" Then
            '    ValidarExistencias = True
            '    Exit Function
            'End If

            'Este método ya no funciona porque le grid no se llena con datasource sino con ciclo, porque con datasource ya no funciona el f8, no borra
            'Dim dt As DataTable = DirectCast(Me.Grid1.DataSource, DataTable)

            For i = 1 To Me.Grid1.Rows - 1
                sCodigoArticulo = Me.Grid1.Cell(i, Me.iGyCodigo).Text
                If txtLEN(sCodigoArticulo) = True Then
                    Me.oArticulos = New Class_CatArticulos(sCodigoArticulo)
                    If Me.oArticulos.INVENTARIABLE <> "0" Then
                        dExistencia = oInventarios.Existencia(sCodigoArticulo, Me.CboAlmacen.SelectedValue.ToString)
                        If dExistencia <= 0 Then
                            Me.Show()
                            MsgBox("El artículo " & Me.Grid1.Cell(i, Me.iGyDescripcion).Text & " que intenta agregar no tiene existencia. ", MsgBoxStyle.Exclamation, sProcedure)
                            Exit Function
                        Else
                            If Me._LlamdoExterior = False Then
                                'dCantidadSumadaPorArticulos = CDbl(dt.Compute("sum(CANTIDAD)", "CODIGO_ARTICULO='" & Me.Grid1.Cell(i, Me.iGyCodigo).Text & "'"))
                                dCantidadSumadaPorArticulos = FG_Grid_ComputeCol(Me.Grid1, sCodigoArticulo, Me.iGyCodigo, Me.iGyCantidad)
                            Else
                                dCantidadSumadaPorArticulos = CDbl(Me.Grid1.Cell(i, Me.iGyCantidad).Text)
                            End If

                            If valorNumerico(dCantidadSumadaPorArticulos.ToString) > valorNumerico(dExistencia.ToString) Then
                                Me.Show()
                                MsgBox("El Artículo " & Me.Grid1.Cell(i, Me.iGyDescripcion).Text & " no tiene suficiente existencia.", MsgBoxStyle.Exclamation, sProcedure)
                                Exit Function
                            End If
                        End If
                    End If
                End If
            Next i

            bResultado = True
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    Private Sub Imprimir()
        Dim StrFiltros As String = ""
        Dim FormatoDeReporte As String
        Dim Rpt As New ReportDocument
        Dim oReporte As Class_Reporte
        Try
            FormatoDeReporte = "RPT_FORMATO_MOVIMIENTO_INVENTARIO"
            oReporte = New Class_Reporte(FormatoDeReporte, Rpt, False)
            If Not oReporte.RptCargado Then
                Exit Sub
            End If
            Rpt.SetParameterValue("@FOLIO_MOVIMIENTO_INVENTARIO", Me.TxtFolio.Text)

            Dim frm As New Reporte(Rpt)
            frm.CRViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            frm.Show()
        Catch ex As Exception
            HandleError(Me.Name, "Imprimir", ex)
        Finally
            oReporte = Nothing
        End Try
    End Sub

    Private Sub DesplegarDocumentos(Optional ByVal bAccesibileUsuarios As Boolean = True)
        Try
            Dim oElementos As New Class_CatDocumentos
            With Me.CboDocumento
                .DisplayMember = "NOMBRE_TIPO_DOCUMENTO"
                .ValueMember = "CODIGO_TIPO_DOCUMENTO"

                Dim dView As New Data.DataView(oElementos.ObtenerTipoDocumentos("INV", Usuario.Codigo_Plaza.ToString, IIf(bAccesibileUsuarios = True, " ESTATUS_DOCUMENTO='A' AND ACCESIBLE_USUARIO='1' ", " ESTATUS_DOCUMENTO='A' ").ToString))
                dView.Sort = "NOMBRE_TIPO_DOCUMENTO"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedIndex = 0
                End If
                '.SelectedValue = Usuario.Codigo_Almacen
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarDocumentos", ex)
        End Try
    End Sub

    Private Sub DesplegarAlmacenes()
        Try
            Dim oElementos As New Class_CatAlmacenes
            With Me.CboAlmacen
                .DisplayMember = "NOMBRE_ALMACEN"

                .ValueMember = "CODIGO_ALMACEN"

                Dim dView As New Data.DataView(oElementos.ObtenerAlmacenes)
                dView.Sort = "NOMBRE_ALMACEN"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedIndex = 0
                End If
                .SelectedValue = Usuario.Codigo_Almacen
            End With

            With Me.CboAlmacenDestino
                .DisplayMember = "NOMBRE_ALMACEN"
                .ValueMember = "CODIGO_ALMACEN"

                Dim dView As New Data.DataView(oElementos.ObtenerAlmacenes)
                dView.Sort = "NOMBRE_ALMACEN"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedIndex = 0
                End If
                .SelectedValue = Usuario.Codigo_Almacen
            End With

            Me.GeneraFolio()
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarAlmacenes", ex)
        End Try
    End Sub

    Private Sub DesplegarConceptosInventarios()
        Try
            Dim oElementos As New Class_CatConceptosInventarios
            With Me.CboConceptoInventario
                .DisplayMember = "NOMBRE_CONCEPTO_INVENTARIOS"
                .ValueMember = "CODIGO_CONCEPTO_INVENTARIOS"

                Dim dView As New Data.DataView(oElementos.ObtenerElementos)
                dView.Sort = "NOMBRE_CONCEPTO_INVENTARIOS"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedIndex = 0
                End If
                .SelectedValue = 0
            End With

            Me.GeneraFolio()
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarConceptosInventarios", ex)
        End Try
    End Sub

    Private Function BusquedaVisual_PorDescripcion() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de Inventarios."
        f.sCampo = "FOLIO_MOVIMIENTO_INVENTARIO"
        f.sOrder = "FOLIO_MOVIMIENTO_INVENTARIO"
        f.sTable = "INVENTARIO_MOVIMIENTOS_GLOBAL"
        f.sQl = "Select FOLIO_MOVIMIENTO_INVENTARIO AS FOLIO,CODIGO_TIPO_DOCUMENTO AS DOCUMENTO,TOTAL From INVENTARIO_MOVIMIENTOS_GLOBAL Where 1=1 And CODIGO_TIPO_DOCUMENTO IN (select CODIGO_TIPO_DOCUMENTO from sis_tipos_documentos WHERE CODIGO_MODULO='INV') AND "
        f.Inicia("")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            End If
        Catch ex As Exception
            HandleError(Me.Name, "BusquedaVisual_PorDescripcion", ex)
        End Try
        Return Resultado
    End Function

    Private Function GeneraFolio() As Boolean
        Try
            Dim sFolio As String = ""
            If Me.CboAlmacen.Items.Count = 0 Or Me.CboDocumento.Items.Count = 0 Then
                Exit Function
            End If

            If Me._LlamdoExterior = True And Me._ConsultaExteriorSalida = False Then
                'Dim sCaracter As String = "", VarString As String = ""
                'Dim sql As New Class_find("select max(FOLIO_MOVIMIENTO_INVENTARIO)FOLIO_MOVIMIENTO_INVENTARIO from INVENTARIO_MOVIMIENTOS_GLOBAL where  FOLIO_REFERENCIA='" & Me.TxtFolioReferencia.Text & "'")
                'sFolio = Me.TxtFolioReferencia.Text
                'If InStr(sFolio, "-") > 0 Then
                '    sFolio = Strings.Right(Me.TxtFolioReferencia.Text, 6)
                'End If

                'If txtLEN(sql.Result1) = True Then

                '    VarString = sql.Result1.ToString
                '    sCaracter = VarString.Substring(3, 1)
                '    If txtLEN(sCaracter) = False And IsNumeric(sCaracter) = True Then
                '        sCaracter = "A"
                '    Else
                '        sCaracter = Chr(Asc(sCaracter) + 1)
                '    End If
                'End If
                ''Me.TxtFolio.Text = Empresa_Sistema.CODIGO_TIPO_DOCUMENTO_SALIDA_EMPAQUE.ToString & sCaracter & Me.CboAlmacen.SelectedValue.ToString & "-" & sFolio
                'Me.TxtFolio.Text = _CodigoDocumentoParaGrabar.ToString & sCaracter & Me.CboAlmacen.SelectedValue.ToString & "-" & sFolio

            ElseIf Me._LlamdoExterior = False And Me._ConsultaExteriorSalida = False Then
                Me.oInventarios = New Class_Inventarios_Global
                Me.oInventarios.CODIGO_TIPO_DOCUMENTO = Me.CboDocumento.SelectedValue.ToString
                Me.oInventarios.CODIGO_ALMACEN1 = Me.CboAlmacen.SelectedValue.ToString

                Me.TxtFolio.Text = Me.oInventarios.GeneraFolioInventarios()
            End If
        Catch ex As Exception
            HandleError(Me.Name, "GeneraFolio", ex)
        End Try
    End Function

    Private Function Consultar() As Boolean
        Dim bResultado As Boolean = False
        Try

            Me.oInventarios = New Class_Inventarios_Global()
            Dim sFolio As String = Me.TxtFolio.Text

            If Me._LlamdoExterior = True And txtLEN(Me.FolioEmbarque) = True Then
                'No debe inicializar, ya se ejecutó el inicializaExterno
            Else
                Me.Inicializa()
            End If

            Me.oInventarios.FOLIO_MOVIMIENTO_INVENTARIO = sFolio

            If Me.oInventarios.Consultar = False Then
                Me.Cambia_Estado(enumEstados.NUEVO)
                Exit Function
            Else
                If Me.CboDocumento.SelectedValue.ToString <> oInventarios.CODIGO_TIPO_DOCUMENTO Then
                    Me.GeneraFolio()
                    Exit Function
                End If

                Me.TxtFolio.Text = oInventarios.FOLIO_MOVIMIENTO_INVENTARIO.ToString.ToUpper
                Me.CboDocumento.SelectedValue = oInventarios.CODIGO_TIPO_DOCUMENTO.ToString.ToUpper

                Me.LblStatus.Text = oInventarios.ESTATUS.ToUpper
                Me.CboAlmacen.SelectedValue = oInventarios.CODIGO_ALMACEN1.ToString.ToUpper

                If oInventarios.CODIGO_TIPO_DOCUMENTO.ToString.ToUpper = "TRI" Then
                    Me.CboAlmacenDestino.SelectedValue = oInventarios.CODIGO_ALMACEN2.ToString.ToUpper
                End If
                Me.TxtFolioReferencia.Text = oInventarios.FOLIO_REFERENCIA.ToString.ToUpper
                Me.TxtConcepto.Text = oInventarios.CONCEPTO.ToString.ToUpper
                Me.txtTotal.Text = FormatImporteContable(oInventarios.TOTAL)
                Me.LblPoliza.Text = oInventarios.FOLIO_POLIZA
                Me.DtpFecha.Value = CDate(oInventarios.FECHA)
                Me.txtFolioEmbarque.Text = oInventarios.FOLIO_EMBARQUE
                Me.CboConceptoInventario.SelectedValue = oInventarios.CODIGO_CONCEPTO_INVENTARIOS

                'Consulta datos detalle
                'Me.Grid1.DataSource = Me.oInventarios.ObtenerDetalle
                Dim dTabla As DataTable = Me.oInventarios.ObtenerDetalle
                Me.Grid1.AutoRedraw = False
                Me.Grid1.Rows = 1 'Trae dos porque en docs nuevos se pone un row en blanco, y si se dejan aqui dos agrega a partir del 3 y queda un hueco
                For Each dRow As DataRow In dTabla.Rows
                    Me.Grid1.AddItem(dRow("CODIGO_ARTICULO").ToString & Chr(9) & dRow("DESCRIPCION").ToString & Chr(9) & dRow("CANTIDAD").ToString & Chr(9) & dRow("COSTO_DETALLE").ToString & Chr(9) & dRow("IMPORTE").ToString & Chr(9) & _
                                    dRow("Boton").ToString & Chr(9) & dRow("CUENTA_CONTABLE").ToString & Chr(9) & dRow("NOMBRE_CUENTA").ToString & Chr(9) & dRow("ID_ADICIONAL").ToString & Chr(9))
                Next

                If Me.LblStatus.Text = "G" Then
                    Me.Grid1.Rows = Me.Grid1.Rows + 1

                    Me.Grid1.Cell(Me.Grid1.Rows - 1, Me.iGyIDAdicional).Text = (CInt(Me.Grid1.Cell(Me.Grid1.Rows - 2, Me.iGyIDAdicional).Text) + 1).ToString
                End If

                Me.Grid1.AutoRedraw = True
                Me.Grid1.Refresh()
                Me.FormateaGrid()

                Me.dtSeries = oInventarios.ObtenerDetalleSeries(Me.TxtFolio.Text)
                Me.GridSeries.DataSource = dtSeries
                Me.FormateaGridSeries()


                'Me.Totales() 'Nota, no debemos totalizar al consultar porque pudieramos ocultar errores de grabado si es que los hay, como nos pasó cuando no actualizabamos el importe de salidas aplicadas

                Me.txtTotalCantidad.Text = FormatCantidad(FG_Grid_SumaCol(Me.Grid1, CShort(Me.iGyCantidad))) 'Esta valor no se graba en el total, por eso se calcula aquí

                Me.oFormaDetalleCuentas = New InventariosDetalleCuentasContables(Me.TxtFolio.Text)

                If Me.oFormaDetalleCuentas.dTablaPrepoliza.Rows.Count = 0 Then
                    Me.oFormaDetalleCuentas = Nothing 'Forza para dejarla vacia
                Else
                    'Consultar

                End If
            End If

            bResultado = True

            If Me.LblStatus.Text = "G" Then
                Me.Estado = enumEstados.GRABADO
            ElseIf Me.LblStatus.Text = "A" Then
                Me.Estado = enumEstados.APLICADO
            ElseIf Me.LblStatus.Text = "C" Then
                Me.Estado = enumEstados.CANCELADO
            End If

            Me.Cambia_Estado(Me.Estado)
        Catch ex As Exception
            HandleError(Me.Name, "Consultar", ex)
        End Try

        Return bResultado

    End Function

    'Private Sub FormateaGrid()
    '    Try
    '        Me.Grid1.Cols = 8

    '        Me.Grid1.Column(Me.iGyCodigo).Width = 100
    '        Me.Grid1.Column(Me.iGyDescripcion).Width = 190
    '        Me.Grid1.Column(Me.iGyCantidad).Width = 80
    '        Me.Grid1.Column(Me.iGyCosto).Width = 100
    '        Me.Grid1.Column(Me.iGyImporte).Width = 100
    '        Me.Grid1.Column(Me.iGyCuentaContable).Width = 110
    '        Me.Grid1.Column(Me.iGyNombreCuentaContable).Width = 220

    '        Me.Grid1.Cell(0, Me.iGyCodigo).Text = "Codigo"
    '        Me.Grid1.Cell(0, Me.iGyDescripcion).Text = "Descripcion"
    '        Me.Grid1.Cell(0, Me.iGyCantidad).Text = "Cantidad"
    '        Me.Grid1.Cell(0, Me.iGyCosto).Text = "Costo"
    '        Me.Grid1.Cell(0, Me.iGyImporte).Text = "Total"
    '        Me.Grid1.Cell(0, Me.iGyCuentaContable).Text = "CuentaContable"
    '        Me.Grid1.Cell(0, Me.iGyNombreCuentaContable).Text = "Nombre cuenta"

    '        Me.Grid1.Column(Me.iGyCantidad).Mask = FlexCell.MaskEnum.Numeric
    '        Me.Grid1.Column(Me.iGyCantidad).DecimalLength = Empresa_Sistema.DECIMALES_CANTIDAD
    '        Me.Grid1.Column(Me.iGyCantidad).Alignment = FlexCell.AlignmentEnum.RightCenter

    '        Me.Grid1.Column(Me.iGyCosto).Mask = FlexCell.MaskEnum.Numeric
    '        Me.Grid1.Column(Me.iGyCosto).DecimalLength = Empresa_Sistema.DECIMALES_PRECIO
    '        Me.Grid1.Column(Me.iGyCosto).Alignment = FlexCell.AlignmentEnum.RightCenter

    '        Me.Grid1.Column(Me.iGyImporte).Mask = FlexCell.MaskEnum.Numeric
    '        Me.Grid1.Column(Me.iGyImporte).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
    '        Me.Grid1.Column(Me.iGyImporte).Alignment = FlexCell.AlignmentEnum.RightCenter

    '        Me.Grid1.Column(Me.iGyCuentaContable).Alignment = FlexCell.AlignmentEnum.RightCenter
    '        Me.Grid1.Column(Me.iGyDescripcion).Locked = True
    '        Me.Grid1.Column(Me.iGyImporte).Locked = True

    '    Catch ex As Exception
    '        HandleError(Me.Name, "FormateaGrid", ex)
    '    End Try
    'End Sub

    Private Sub FormateaGrid()
        Try
            With Me.Grid1
                .AutoRedraw = False

                '.Cols = 1
                .Cols = 10

                '.DefaultFont = New Font("Tahoma", 8)
                .DisplayFocusRect = False
                '.DisplayDateTimeMask = True
                '.ExtendLastCol = True
                .DrawMode = FlexCell.DrawModeEnum.OwnerDraw
                .BorderStyle = FlexCell.BorderStyleEnum.FixedSingle
                .FixedRowColStyle = FlexCell.FixedRowColStyleEnum.Flat

                '.BackColorFixed = Color.FromArgb(90, 158, 214)
                '.BackColorFixedSel = Color.FromArgb(110, 180, 230)
                '.BackColorBkg = Color.FromArgb(90, 158, 214)
                .BackColor1 = Color.FromArgb(231, 235, 247)
                .BackColor2 = Color.FromArgb(239, 243, 255)
                .CellBorderColorFixed = Color.Black
                .GridColor = Color.FromArgb(148, 190, 231)

                .Cell(0, Me.iGyCodigo).Text = "Codigo"
                .Cell(0, Me.iGyDescripcion).Text = "Descripcion"
                .Cell(0, Me.iGyCantidad).Text = "Cantidad"
                .Cell(0, Me.iGyCosto).Text = "Costo"
                .Cell(0, Me.iGyImporte).Text = "Total"
                .Cell(0, Me.iGyCuentaContable).Text = "CuentaContable"
                .Cell(0, Me.iGyNombreCuentaContable).Text = "Nombre cuenta"
                .Cell(0, Me.iGyBoton).Text = "Costos"

                .Column(Me.iGyCantidad).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyCantidad).DecimalLength = Empresa_Sistema.DECIMALES_CANTIDAD
                .Column(Me.iGyCantidad).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGyCosto).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyCosto).DecimalLength = Empresa_Sistema.DECIMALES_PRECIO
                .Column(Me.iGyCosto).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGyImporte).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyImporte).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
                .Column(Me.iGyImporte).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGyCuentaContable).Alignment = FlexCell.AlignmentEnum.RightCenter
                .Column(Me.iGyDescripcion).Locked = True
                .Column(Me.iGyImporte).Locked = True
                .Column(Me.iGyNombreCuentaContable).Locked = True

                .Column(Me.iGyBoton).CellType = FlexCell.CellTypeEnum.Button

                .Column(Me.iGyCodigo).Width = 100
                .Column(Me.iGyDescripcion).Width = 190
                .Column(Me.iGyCantidad).Width = 80
                .Column(Me.iGyCosto).Width = 100
                .Column(Me.iGyImporte).Width = 100
                .Column(Me.iGyCuentaContable).Width = 110
                .Column(Me.iGyNombreCuentaContable).Width = 220
                .Column(Me.iGyIDAdicional).Visible = False

                .AutoRedraw = True
                .Refresh()
            End With

        Catch ex As Exception
            HandleError(Me.Name, "FormateaGrid", ex)
        End Try
    End Sub

    Private Sub Totales()
        Try
            Dim I As Integer
            Dim Dcantidad As Double, DPrecio As Double, dImporte As Double
            For I = 1 To Me.Grid1.Rows - 1
                If Len("" & Me.Grid1.Cell(I, Me.iGyCantidad).Text) > 0 Then
                    Dcantidad = Val(0 & Me.Grid1.Cell(I, Me.iGyCantidad).Text)
                    DPrecio = Val(0 & Me.Grid1.Cell(I, Me.iGyCosto).Text)

                    If Dcantidad > 0 Then
                        dImporte = (DPrecio * Dcantidad)
                        dImporte = Redondear(dImporte)
                        Me.Grid1.Cell(I, Me.iGyImporte).Text = dImporte.ToString
                    End If
                End If
            Next I

            Me.txtTotalCantidad.Text = FG_Grid_SumaCol(Me.Grid1, CShort(Me.iGyCantidad)).ToString

            Me.txtTotal.Text = FormatImporteContable(FG_Grid_SumaCol(Me.Grid1, CShort(Me.iGyImporte))).ToString
        Catch ex As Exception
            HandleError(Me.Name, "Totales", ex)
        End Try
    End Sub

    Private Function GrabarPoliza() As Boolean
        Dim Bgrabado As Boolean = False
        Dim Error1 As String = ""

        If oInventarios.NATURALEZA_INVENTARIOS <> "EN" Then
            If Me.ValidarExistencias = False Then
                Exit Function
            End If
        End If

        Me.Totales()

        Select Case Me.Estado
            Case enumEstados.NUEVO, enumEstados.GRABADO
                Try
                    If oInventarios.AplicarPoliza() = True Then
                        MsgBox("La póliza fue grabada y contabilizada con éxito.", MsgBoxStyle.Information, "Contabilidad")
                    Else
                        MsgBox("La póliza no pudo grabarse.", MsgBoxStyle.Exclamation, "Contabilización de pólizas.")
                    End If

                Catch ex As Exception
                    HandleError(Me.Name, "GrabarPoliza", ex)
                    Me.Estado = enumEstados.NUEVO
                    Me.Cambia_Estado(Me.Estado)
                Finally
                    'oPoliza = Nothing
                End Try
        End Select
    End Function

    Private Function EstableceCuentaContableAlmacenDestino() As Boolean
        Dim bResultado As Boolean = False
        Dim i As Integer
        Try
            Dim oAlmacenes = New Class_CatAlmacenes(Me.CboAlmacenDestino.SelectedValue.ToString)
            Dim oArticulos = New Class_CatArticulos

            For I = 1 To Me.Grid1.Rows - 1
                If txtLEN(Me.Grid1.Cell(I, Me.iGyCodigo).Text) = True Then
                    Me.Grid1.Cell(i, Me.iGyCuentaContable).Text = oAlmacenes.Cuenta_Contable.ToString + oArticulos.ObtenerFamiliaArticulo(Me.Grid1.Cell(i, Me.iGyCodigo).Text).ToString
                End If
            Next
            bResultado = True
        Catch ex As Exception
            HandleError(Me.Name, "EstableceCuentaContableAlmacenDestino", ex)
        End Try
        Return bResultado
    End Function

    Private Function SiTieneRenglones() As Boolean
        Dim bResultado As Boolean = False
        Dim i As Integer
        Try
            For i = 1 To Me.Grid1.Rows - 1
                If txtLEN(Me.Grid1.Cell(i, Me.iGyCodigo).Text) = True Then
                    Return True
                End If
            Next
            bResultado = False
        Catch ex As Exception
            HandleError(Me.Name, "SiTieneRenglones", ex)
        End Try
        Return bResultado
    End Function

    'Private Function SiTieneCuentaContable() As Boolean
    '    Dim i As Integer
    '    For i = 1 To Me.Grid1.Rows - 1
    '        If txtLEN(Me.Grid1.Cell(i, Me.iGyCodigo).Text) = True Then
    '            If txtLEN(Me.Grid1.Cell(i, Me.iGyCuentaContable).Text) = False Then
    '                SiTieneCuentaContable = False
    '                Exit Function
    '            End If
    '        End If
    '    Next
    '    SiTieneCuentaContable = True
    'End Function

    'Private Function ValidaCuentaContable() As Boolean
    '    Dim i As Integer
    '    Me.oCuentas = New Class_CatCuentas

    '    For i = 1 To Me.Grid1.Rows - 1
    '        If txtLEN(Me.Grid1.Cell(i, Me.iGyCodigo).Text) = True Then
    '            Me.oCuentas.CUENTA_CONTABLE = Me.Grid1.Cell(i, Me.iGyCuentaContable).Text
    '            If Me.oCuentas.Consultar = False Then
    '                MsgBox("La cuenta contable del renglón : " & i & " no existe.", MsgBoxStyle.Exclamation, Me.Name)
    '                Exit Function
    '            Else
    '                If Me.oCuentas.isCuentaContableValida(Me.Grid1.Cell(i, Me.iGyCuentaContable).Text.ToString) = False Then
    '                    MsgBox("La cuenta contable del renglón : " & i & " es inválida para poder usarse.", MsgBoxStyle.Exclamation, Me.Name)
    '                    ValidaCuentaContable = False
    '                    Exit Function
    '                End If
    '            End If
    '        End If
    '    Next
    '    ValidaCuentaContable = True
    'End Function

    Private Function ValidaCuentasContable() As Boolean
        Dim bResultado As Boolean = False
        Dim i As Integer, sCuentaContable As String = ""
        Try
            Dim oCuentas = New Class_CatCuentas

            For i = 1 To Me.Grid1.Rows - 1
                If txtLEN(Me.Grid1.Cell(i, Me.iGyCodigo).Text) = True Then

                    'If IsNothing(Me.oFormaDetalleCuentas) = True Then
                    '    MsgBox("vacio Me.oFormaDetalleCuentas ???")
                    'End If

                    sCuentaContable = Me.Grid1.Cell(i, Me.iGyCuentaContable).Text

                    If IsNothing(Me.oFormaDetalleCuentas) = False AndAlso Me.oFormaDetalleCuentas.ValidaCuentaTengaDetalle(CInt(Me.Grid1.Cell(i, Me.iGyIDAdicional).Text)) = True Then 'Si es que tiene detalle de cuenta en la otra forma

                        'No bajar la segunda validacion despues del andalso porque si no no va entrar al else si e sun renglón que tien su cuenta en el grid normal y no el oculto
                        'Si es que tiene detalle de cuenta en la otra forma y si tambien se haya el id del renglon(puede haber renglones que no tengan, esos que no tienen no entran aqui si se tiene que preguntar)
                        'No hay que hacer
                        'MsgBox("andale")

                        If txtLEN(sCuentaContable) = True Then
                            MsgBox("Quite la cuenta contable del renglón : " & i & " , no se puede tener cuenta directa y también en detalle(la que se establece con el botón).", MsgBoxStyle.Exclamation, Me.Text)
                            Return False
                        End If

                    Else
                        If txtLEN(sCuentaContable) = False Then
                            MsgBox("Asígne la cuenta contable del renglón : " & i & " .", MsgBoxStyle.Exclamation, Me.Text)
                            Return False
                        End If

                        'If sCuentaContable.StartsWith("1") = False Then
                        '    MsgBox("La cuenta contable del renglón : " & i & " debe ser del rango de las miles(que empiezen con 1)." & vbCrLf & _
                        '    "O debe en vez de poner cuenta, detallar con el botón de centros de costos.", MsgBoxStyle.Exclamation, Me.Name)
                        '    Return False
                        'End If

                        oCuentas = New Class_CatCuentas(sCuentaContable)

                        If oCuentas._Existe = False Then
                            MsgBox("La cuenta contable del renglón : " & i & " no existe.", MsgBoxStyle.Exclamation, Me.Name)
                            Return False
                        ElseIf oCuentas.ESMAYOR = "1" Then
                            MsgBox("La cuenta contable del renglón : " & i & " es de mayor.", MsgBoxStyle.Exclamation, Me.Name)
                            Return False
                        End If

                    End If

                End If
            Next
            bResultado = True
        Catch ex As Exception
            HandleError(Me.Name, "ValidaCuentasContable", ex)
        End Try
        Return bResultado
    End Function

    Private Function SiTieneImporte() As Boolean
        Dim bResultado As Boolean = False
        Try
            Dim i As Integer
            For i = 1 To Me.Grid1.Rows - 1
                If txtLEN(Me.Grid1.Cell(i, Me.iGyCodigo).Text) = True Then
                    If valorNumerico(Me.Grid1.Cell(i, Me.iGyImporte).Text) = 0 Then
                        Return False
                    End If
                End If
            Next
            bResultado = True
        Catch ex As Exception
            HandleError(Me.Name, "SiTieneImporte", ex)
        End Try
        Return bResultado
    End Function

    Private Function SiTieneCantidad() As Boolean
        Dim bResultado As Boolean = False
        Try
            Dim i As Integer
            For i = 1 To Me.Grid1.Rows - 1
                If txtLEN(Me.Grid1.Cell(i, Me.iGyCodigo).Text) = True Then
                    If valorNumerico(Me.Grid1.Cell(i, Me.iGyCantidad).Text) = 0 Then
                        Return False
                    End If
                End If
            Next
            bResultado = True
        Catch ex As Exception
            HandleError(Me.Name, "SiTieneCantidad", ex)
        End Try
        Return bResultado
    End Function

    Private Sub OcultaControles()
        Me.oDocumentos = New Class_Cat_tiposDocumentos(Me.CboDocumento.SelectedValue.ToString)
        If Me.oDocumentos.ES_TRANSFERENCIA = "1" Then
            Me.CboAlmacenDestino.Visible = True
            Me.lblAlmacenDestino.Visible = True
            Me.lblCodigoAlmacen2.Visible = True
            If Me._LlamdoExterior = False And Me._ConsultaExteriorSalida = False Then
                Me.Grid1.Column(Me.iGyCuentaContable).Locked = True
                Me.Grid1.Column(Me.iGyImporte).Locked = True
            End If
            If txtLEN(Me._CodigoAlmacenHappy) = True Then
                Me.CboAlmacenDestino.SelectedValue = Me._CodigoAlmacenHappy
            End If
            Me.tsbCancelar.Visible = False
            Me.txtFolioEmbarque.Visible = True : Me.lblDisplayFolioEmbarque.Visible = True
            Me.GridSeries.Column(Me.igySerieNumeroSerie).Locked = True

        Else
            Me.CboAlmacenDestino.Visible = False
            Me.lblAlmacenDestino.Visible = False
            Me.lblCodigoAlmacen2.Visible = False
            If Me._LlamdoExterior = False And Me._ConsultaExteriorSalida = False Then
                Me.Grid1.Column(Me.iGyCuentaContable).Locked = False
            End If
            Me.tsbCancelar.Visible = True
            Me.txtFolioEmbarque.Text = "" 'Se forza a blanco por si tenia algo capturado.
            Me.txtFolioEmbarque.Visible = False : Me.lblDisplayFolioEmbarque.Visible = False
            Me.GridSeries.Column(Me.igySerieNumeroSerie).Locked = True
        End If
    End Sub

    Private Function ValidaEmbarque() As Boolean
        Dim bResultado As Boolean = False
        Try
            Dim oEmbarque As New Class_Embarques_EmbarqueGlobal(Me.txtFolioEmbarque.Text, True)
            If oEmbarque.Existe = False Then
                MsgBox("El folio de embarque no existe.", MsgBoxStyle.Exclamation, Me.Name)
            Else
                Dim oSql As New Class_find("SELECT 1 FROM INVENTARIO_MOVIMIENTOS_GLOBAL WHERE FOLIO_EMBARQUE='" & sReplace(Me.txtFolioEmbarque.Text) & "' AND FOLIO_MOVIMIENTO_INVENTARIO<>'" & sReplace(Me.TxtFolio.Text) & "'")
                If txtLEN(oSql.Result1) = True Then
                    MsgBox("El folio de embarque ya fue usado en otro movimiento, no es posible repetirlo.", MsgBoxStyle.Exclamation, Me.Name)
                Else
                    bResultado = True
                End If
            End If
            oEmbarque = Nothing
        Catch ex As Exception
            HandleError(Me.Name, "ValidaEmbarque", ex)
        End Try
        Return bResultado
    End Function

    Private Sub Navegador(ByVal sTipoDeBusqueda As String)
        Try
            Dim iFolio As Integer, sFolio As String, iPosicion As Integer, sFolioParte2 As String
            If txtLEN(Me.TxtFolio.Text) = False Then
                If GeneraFolio() = False OrElse txtLEN(Me.TxtFolio.Text) = False Then
                    Exit Sub
                End If
            End If

            If sTipoDeBusqueda = "Anterior" Then
                iPosicion = Me.TxtFolio.Text.IndexOf("-")
                sFolio = Me.TxtFolio.Text.Substring(0, iPosicion)
                iFolio = CInt(Strings.Right(Me.TxtFolio.Text, Len(Me.TxtFolio.Text) - (Len(sFolio) + 1))) ' Me.oVenta.FOLIO_NUMERICO
                iFolio = iFolio - 1
                sFolioParte2 = Format(iFolio, New String(CChar("0"), Me.TxtFolio.Text.Substring(3, Me.TxtFolio.TextLength - iPosicion - 1).Length))
                sFolio = sFolio + "-" + sFolioParte2 'sFolio + "-" + iFolio.ToString
                Me.TxtFolio.Text = sFolio

                If txtLEN(sFolio) = True Then
                    Me.Consultar()
                Else
                    Me.Inicializa()
                    Me.Cambia_Estado(enumEstados.NUEVO)
                    Me.GeneraFolio()
                    Me.TxtFolio.Focus()
                End If

            ElseIf sTipoDeBusqueda = "Siguiente" Then
                iPosicion = Me.TxtFolio.Text.IndexOf("-")
                sFolio = Me.TxtFolio.Text.Substring(0, iPosicion)
                iFolio = CInt(Strings.Right(Me.TxtFolio.Text, Len(Me.TxtFolio.Text) - (Len(sFolio) + 1))) ' Me.oVenta.FOLIO_NUMERICO
                iFolio = iFolio + 1
                sFolioParte2 = Format(iFolio, New String(CChar("0"), Me.TxtFolio.Text.Substring(3, Me.TxtFolio.TextLength - iPosicion - 1).Length))
                sFolio = sFolio + "-" + sFolioParte2 'sFolio + "-" + iFolio.ToString
                Me.TxtFolio.Text = sFolio

                If txtLEN(sFolio) = True Then
                    Me.Consultar()
                Else
                    Me.Inicializa()
                    Me.Cambia_Estado(enumEstados.NUEVO)
                    Me.GeneraFolio()
                    Me.TxtFolio.Focus()
                End If
            End If
        Catch ex As Exception
            HandleError(Me.Name, "Navegador", ex)
        End Try
    End Sub

    Private Sub GestionaDetalleCuentas()
        Dim iRenglon As Integer = 0
        Try
            iRenglon = Me.Grid1.ActiveCell.Row 'Me.Grid1.Selection.FirstRow
            'iRenglon = CInt(Me.Grid1.Cell(Me.Grid1.ActiveCell.Row, Me.iGyIDAdicional).Text)

            If valorNumerico(Me.Grid1.Cell(iRenglon, Me.iGyImporte).Text) = 0 Then
                MsgBox("No ha capturado el artículo con su cantidad y precio.", MsgBoxStyle.Exclamation, Me.Text)
                Exit Sub
            End If

            'Solo si esta vacia la crea, para que siga existiendo en memoria ( con hide se oculta en la forma secundaria, para seguir trabajando con ella al volver el control a esta forma)
            If IsNothing(Me.oFormaDetalleCuentas) = True Then
                Me.oFormaDetalleCuentas = New InventariosDetalleCuentasContables(Me.TxtFolio.Text)
            End If

            With Me.oFormaDetalleCuentas
                .IDAdicional = CInt(Me.Grid1.Cell(iRenglon, Me.iGyIDAdicional).Text) 'iRenglon
                .Importe = valorNumerico(Me.Grid1.Cell(iRenglon, Me.iGyImporte).Text)
                .txtArticulo.Text = Me.Grid1.Cell(iRenglon, Me.iGyDescripcion).Text
                .txtCantidad.Text = Me.Grid1.Cell(iRenglon, Me.iGyCantidad).Text
                .txtCosto.Text = Me.Grid1.Cell(iRenglon, Me.iGyCosto).Text
                .txtImporte.Text = FormatImporteContable(.Importe, False)
                .CodigoArticulo = Me.Grid1.Cell(iRenglon, Me.iGyCodigo).Text
                .ShowDialog()

                'If .TieneDetalleCuentas = True Then
                'If .GestionoRenglon = True Then
                If .ValidaCuentaTengaDetalle(.IDAdicional) Then
                    Me.Grid1.Cell(iRenglon, Me.iGyCuentaContable).Text = ""
                    Me.Grid1.Cell(iRenglon, Me.iGyNombreCuentaContable).Text = "Tiene detalle -->>"
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "GestionaDetalleCuentas", ex)
        End Try
    End Sub

    Private Function EliminaDetalleCuentasContables(ByVal IDAdicional As Integer) As Integer
        Try
            If IsNothing(Me.oFormaDetalleCuentas) = False Then 'Si no esta vacia, osea si existe
                Me.oFormaDetalleCuentas.EliminaRelacion(IDAdicional)
            End If
        Catch ex As Exception
            HandleError(Me.Name, "EliminaDetalleCuentasContables", ex)
        End Try
    End Function

    Private Sub GestionaAplicacion()
        Try
            Me.bAplicando = True

            If Me.oInventarios.NATURALEZA_INVENTARIOS <> "EN" Then
                If Me.ValidarExistencias() = False Then
                    Exit Sub
                End If
            End If

            'Me.oDocumentos = New Class_Cat_tiposDocumentos(Me.CboDocumento.SelectedValue.ToString)
            If Me.oDocumentos.ES_TRANSFERENCIA = "1" Then
                If Me.EstableceCuentaContableAlmacenDestino() = False Then
                    MsgBox("Error al tratar de asígnar la cuenta contable del almacen destino.", MsgBoxStyle.Exclamation, Me.Text)
                    Exit Sub
                End If
            End If

            If Me.Aplicar() = True Then
                If Me._LlamdoExterior = True Then

                    'Se quitó 17dic16 porque ahora se hace una sola salida para todo el embarque y se marca desde el mismo embarque
                    'Me.oPalet.MarcaSalidaPalet()

                    Me._AplicadoExterior = True
                    'MsgBox("El movimiento de Inventario fue Aplicado con exito", MsgBoxStyle.Information, "Aplicando Movimientos de Inventarios")
                    Me.Close()
                    Exit Sub
                End If

                MsgBox("El movimiento de Inventario fue Aplicado con éxito", MsgBoxStyle.Information, "Aplicando Movimientos de Inventarios")
                Me.Consultar()

            Else
                If Me._LlamdoExterior = False Then
                    Me.Consultar()
                Else
                    Me.Visible = True
                End If
            End If
        Catch ex As Exception
            HandleError(Me.Name, "GestionaAplicacion", ex)
        End Try
    End Sub

    Private Sub PrepararSeries()
        Try
            'Dim iUnidades As Integer

            If IsNothing(Me.dtSeries) = False AndAlso Me.dtSeries.Rows.Count > 0 Then
                If MsgBox("Hay series ya especificadas, si continua tendrá que recapturar todas." & vbCrLf & "Esta seguro de continuar ?", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    Return
                End If
            End If

            Me.dtSeries.Clear()
            Me.dtSeries = New DataTable("Series")
            With Me.dtSeries
                .Columns.Add("POSICION", GetType(String))
                .Columns.Add("CODIGO_ARTICULO", GetType(String))
                .Columns.Add("DESCRIPCION", GetType(String))
                .Columns.Add("ID_INVENTARIO_LOTES_COSTOS", GetType(String))
                .Columns.Add("NUMERO_SERIE", GetType(String))
            End With
            Me.dtSeries.AcceptChanges()

            Dim dRow As DataRow

            For i = 1 To Me.Grid1.Rows - 1
                If txtLEN(Me.Grid1.Cell(i, Me.iGyCodigo).Text) = True AndAlso Me.Grid1.Cell(i, Me.iGyCodigo).Text <> "-" AndAlso CInt(Me.Grid1.Cell(i, Me.iGyCantidad).Text) > 0 Then
                    Dim oArticulo As New Class_CatArticulos(Me.Grid1.Cell(i, Me.iGyCodigo).Text)
                    If oArticulo.Existe = True AndAlso oArticulo.ES_SERIALIZABLE = True AndAlso oArticulo.INVENTARIABLE = "1" Then
                        For j = 1 To CInt(Me.Grid1.Cell(i, Me.iGyCantidad).Text)
                            dRow = Me.dtSeries.NewRow

                            dRow("POSICION") = i
                            dRow("CODIGO_ARTICULO") = Me.Grid1.Cell(i, Me.iGyCodigo).Text
                            dRow("DESCRIPCION") = Me.Grid1.Cell(i, Me.iGyDescripcion).Text
                            dRow("ID_INVENTARIO_LOTES_COSTOS") = ""
                            dRow("NUMERO_SERIE") = ""

                            Me.dtSeries.Rows.Add(dRow)
                        Next
                    End If
                End If
            Next

            Me.dtSeries.AcceptChanges()

            Me.GridSeries.DataSource = Me.dtSeries

            Me.FormateaGridSeries()

            'If Me.CboDocumento.Text = "ENTRADA" Then
            If Me.CboDocumento.SelectedValue.ToString = "EN" Or Me.CboDocumento.SelectedValue.ToString = "ER" Then
                Me.GridSeries.Column(Me.igySerieNumeroSerie).Locked = False
            End If

            Me.TabControl1.SelectedIndex = 1

        Catch ex As Exception
            HandleError(Me.Name, "PrepararSeries", ex)
        End Try
    End Sub

    Private Sub FormateaGridSeries()
        Try
            With Me.GridSeries
                .AutoRedraw = False

                .DisplayFocusRect = False
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

    Private Sub GestionaGridSeries(ByVal e As System.Windows.Forms.KeyEventArgs)
        Dim sLote As String = "", sCodigoArticulo As String = ""
        Dim oSerie As Class_Inventarios_Lotes_Series
        Try
            With Me.GridSeries
                Dim Renglon As Integer = .Selection.FirstRow
                Dim Columna As Integer = .Selection.FirstCol

                If Me.CboDocumento.Text = "ENTRADA" Then
                    Exit Sub
                End If

                Select Case e.KeyCode
                    Case Keys.Return
                        If Columna = Me.igySerieNumeroSerie AndAlso txtLEN(.Cell(Renglon, Me.igySeriePosicion).Text) = True Then
                            sLote = .Cell(Renglon, Me.igySerieIdInventarioLotesCostos).Text
                            If txtLEN(sLote) = False Then
                                GoTo busca_serie
                                Return
                            End If

                            If Me.EstableceSerie(Renglon, sLote) = True Then
                                If Renglon + 1 < .Rows Then
                                    .Cell(Renglon + 1, Me.igySerieDescripcion).SetFocus()
                                Else
                                    .Cell(1, Me.igySerieDescripcion).SetFocus()
                                End If
                            End If
                        End If

                    Case Keys.F6
                        If Columna = Me.igySerieNumeroSerie AndAlso txtLEN(.Cell(Renglon, Me.igySeriePosicion).Text) = True Then
busca_serie:
                            oSerie = New Class_Inventarios_Lotes_Series
                            sCodigoArticulo = .Cell(Renglon, Me.igySerieCodigo).Text
                            sLote = oSerie.BusquedaVisual(sCodigoArticulo, Me.CboAlmacen.SelectedValue.ToString)
                            If txtLEN(sLote) = True Then
                                If RepiteSerie(Renglon, sLote) = False Then
                                    Me.EstableceSerie(Renglon, sLote)
                                End If
                            End If
                        End If

                    Case Keys.F7
                        If Columna = Me.igySerieNumeroSerie AndAlso txtLEN(.Cell(Renglon, Me.igySeriePosicion).Text) = True Then
                            oSerie = New Class_Inventarios_Lotes_Series
                            sCodigoArticulo = .Cell(Renglon, Me.igySerieCodigo).Text
                            If txtLEN(sCodigoArticulo) = False Then
                                Return
                            End If

                            Dim lote As New Class_Inventarios_Lotes_Series.Lote
                            lote = oSerie.BusquedaVisualSeriesMultiplesFolio(sCodigoArticulo, Me.CboAlmacen.SelectedValue.ToString)

                            If txtLEN(lote.FolioMovimiento) = True Then

                                Dim dtSeries As DataTable = oSerie.ObtieneRenglonesSeriesFolio(lote.FolioMovimiento, sCodigoArticulo)
                                If dtSeries.Rows.Count = 0 Then
                                    MsgBox("No se encontraron series disponibles del artículo " & sCodigoArticulo & " del folio " & lote.FolioMovimiento, MsgBoxStyle.Exclamation, Me.Text)
                                    Return
                                End If

                                Dim i As Integer, iArticulosPendientes As Integer = Me.CantidadArticulosPendientesSerie(sCodigoArticulo) 'iArticulosEncontrados As Integer
                                Dim iSeriesUsadas As Double = lote.Cantidad, iRowEncontrado As Integer = 0
                                For i = 1 To Me.GridSeries.Rows - 1
                                    If iArticulosPendientes <= 0 Or iSeriesUsadas <= 0 Then
                                        Exit For
                                    End If
                                    If Me.GridSeries.Cell(i, Me.igySerieCodigo).Text = sCodigoArticulo AndAlso txtLEN(Me.GridSeries.Cell(i, Me.igySerieIdInventarioLotesCostos).Text) = False Then
                                        iArticulosPendientes -= 1
                                        iSeriesUsadas -= 1
                                        Me.GridSeries.Cell(i, Me.igySerieIdInventarioLotesCostos).Text = dtSeries.Rows(iRowEncontrado)("ID_INVENTARIO_LOTES_COSTOS").ToString
                                        Me.GridSeries.Cell(i, Me.igySerieNumeroSerie).Text = dtSeries.Rows(iRowEncontrado)("NUMERO_SERIE").ToString
                                        iRowEncontrado += 1 'empieza desde el 0
                                    End If
                                Next


                            End If
                        End If

                    Case Keys.Delete
                        e.SuppressKeyPress = True
                End Select

            End With

        Catch ex As Exception
            HandleError(Me.Name, "GestionaGridSeries", ex)
        End Try
    End Sub

    Private Function EstableceSerie(ByVal Renglon As Integer, ByVal ID_INVENTARIO_LOTES_COSTOS As String) As Boolean
        Try
            Dim oSerie As New Class_Inventarios_Lotes_Series(ID_INVENTARIO_LOTES_COSTOS)
            If oSerie.Existe = True Then
                Me.GridSeries.Cell(Renglon, Me.igySerieIdInventarioLotesCostos).Text = oSerie.ID_INVENTARIO_LOTES_COSTOS
                Me.GridSeries.Cell(Renglon, Me.igySerieNumeroSerie).Text = oSerie.NUMERO_SERIE
                Return True
            End If
        Catch ex As Exception
            HandleError(Me.Name, "EstableceSerie", ex)
        End Try
    End Function

    Private Function RepiteSerie(ByVal Renglon As Integer, ByVal ID_INVENTARIO_LOTES_COSTOS As String) As Boolean
        Dim RenglonRepetido As Integer
        Try
            Me.dtSeries.AcceptChanges()

            For i = 1 To Me.GridSeries.Rows - 1
                If i <> Renglon Then
                    If txtLEN(Me.GridSeries.Cell(i, Me.igySerieCodigo).Text) = True Then
                        If ID_INVENTARIO_LOTES_COSTOS = Me.GridSeries.Cell(i, Me.igySerieIdInventarioLotesCostos).Text Then
                            RenglonRepetido = i

                            MsgBox("La serie " & Me.GridSeries.Cell(RenglonRepetido, igySerieNumeroSerie).Text & _
                                   " del artículo " & Me.GridSeries.Cell(RenglonRepetido, igySerieCodigo).Text & " esta repetida en el renglón " & RenglonRepetido & "." & vbCrLf & _
                                   "", MsgBoxStyle.Exclamation)
                            Me.GridSeries.Cell(RenglonRepetido, Me.igySerieNumeroSerie).SetFocus()

                            Return True

                        End If

                    End If
                End If

            Next
        Catch ex As Exception
            HandleError(Me.Name, "RepiteSerie", ex)
        End Try
    End Function

    Private Function CantidadArticulosPendientesSerie(ByVal sCodigoArticulo As String) As Integer
        Dim iArticulosEncontrados As Integer = 0
        Try
            For i = 1 To Me.GridSeries.Rows - 1
                If Me.GridSeries.Cell(i, Me.igySerieCodigo).Text = sCodigoArticulo AndAlso Me.GridSeries.Cell(i, Me.iGyCodigo).Text <> "-" AndAlso txtLEN(Me.GridSeries.Cell(i, Me.igySerieIdInventarioLotesCostos).Text) = False Then
                    iArticulosEncontrados += 1
                End If
            Next
        Catch ex As Exception
            HandleError(Me.Name, "CantidadArticulosPendientesSerie", ex)
        End Try
        Return iArticulosEncontrados
    End Function

    Private Function ValidaNumerosSerie() As Boolean
        Try
            Dim dtSeriesTemp As New DataTable("Series")
            With dtSeriesTemp
                .Columns.Add("POSICION", GetType(String))
                .Columns.Add("CODIGO_ARTICULO", GetType(String))
                .Columns.Add("DESCRIPCION", GetType(String))
            End With
            dtSeriesTemp.AcceptChanges()

            Dim dRow As DataRow, i As Integer

            For i = 1 To Me.Grid1.Rows - 1
                If txtLEN(Me.Grid1.Cell(i, Me.iGyCodigo).Text) = True AndAlso Me.Grid1.Cell(i, Me.iGyCodigo).Text <> "-" AndAlso CInt(Me.Grid1.Cell(i, Me.iGyCantidad).Text) > 0 Then
                    Dim oArticulo As New Class_CatArticulos(Me.Grid1.Cell(i, Me.iGyCodigo).Text)
                    If oArticulo.Existe = True AndAlso oArticulo.ES_SERIALIZABLE = True AndAlso oArticulo.INVENTARIABLE = "1" Then
                        For j = 1 To CInt(Me.Grid1.Cell(i, Me.iGyCantidad).Text)
                            dRow = dtSeriesTemp.NewRow

                            dRow("POSICION") = i
                            dRow("CODIGO_ARTICULO") = Me.Grid1.Cell(i, Me.iGyCodigo).Text
                            dRow("DESCRIPCION") = Me.Grid1.Cell(i, Me.iGyDescripcion).Text

                            dtSeriesTemp.Rows.Add(dRow)
                        Next
                    End If
                End If
            Next

            dtSeriesTemp.AcceptChanges()

            If Me.dtSeries.Rows.Count <> dtSeriesTemp.Rows.Count Then
                MsgBox("Tiene que volver a detallar todas las series porque no corresponden los artículos.", MsgBoxStyle.Exclamation)
                Return False
            End If

            i = 0
            For Each d As DataRow In dtSeriesTemp.Rows
                If d("POSICION").ToString <> Me.dtSeries.Rows(i)("POSICION").ToString Then
                    MsgBox("Tiene que volver a detallar todas las series porque no corresponden los artículos.", MsgBoxStyle.Exclamation)
                    Return False
                ElseIf d("CODIGO_ARTICULO").ToString <> Me.dtSeries.Rows(i)("CODIGO_ARTICULO").ToString Then
                    MsgBox("Tiene que volver a detallar todas las series porque no corresponden los artículos.", MsgBoxStyle.Exclamation)
                    Return False
                End If
                i += 1
            Next

            For Each d As DataRow In Me.dtSeries.Rows
                If txtLEN(d("NUMERO_SERIE").ToString) = False Then
                    MsgBox("Faltan de capturar series, favor de revisar.", MsgBoxStyle.Exclamation)
                    Return False
                End If
            Next

            Return True
        Catch ex As Exception
            HandleError(Me.Name, "ValidaNumerosSerie", ex)
        End Try
    End Function

    Private Function HaySeriesRepetidas() As Boolean
        Dim RenglonRepetido As Integer

        Try
            Me.dtSeries.AcceptChanges()

            If Me.CboDocumento.Text = "ENTRADA" Then 'Compara numeros de serie
                For i = 1 To Me.GridSeries.Rows - 1
                    If txtLEN(Me.GridSeries.Cell(i, Me.igySerieCodigo).Text) = True Then
                        For z = i + 1 To Me.GridSeries.Rows - 1
                            If Me.GridSeries.Cell(i, Me.igySerieNumeroSerie).Text = Me.GridSeries.Cell(z, Me.igySerieNumeroSerie).Text Then
                                RenglonRepetido = z

                                MsgBox("La serie " & Me.GridSeries.Cell(RenglonRepetido, igySerieNumeroSerie).Text & _
                                       " del artículo " & Me.GridSeries.Cell(RenglonRepetido, igySerieCodigo).Text & " esta repetida en el renglón " & RenglonRepetido & "." & vbCrLf & _
                                       "", MsgBoxStyle.Exclamation)
                                Me.GridSeries.Cell(RenglonRepetido, Me.igySerieNumeroSerie).SetFocus()

                                Return True

                            End If
                        Next
                    End If
                Next
            Else 'Compara Id inventarios lotes costos
                For i = 1 To Me.GridSeries.Rows - 1
                    If txtLEN(Me.GridSeries.Cell(i, Me.igySerieCodigo).Text) = True Then
                        For z = i + 1 To Me.GridSeries.Rows - 1
                            If Me.GridSeries.Cell(i, Me.igySerieIdInventarioLotesCostos).Text = Me.GridSeries.Cell(z, Me.igySerieIdInventarioLotesCostos).Text Then
                                RenglonRepetido = z

                                MsgBox("La serie " & Me.GridSeries.Cell(RenglonRepetido, igySerieNumeroSerie).Text & _
                                       " del artículo " & Me.GridSeries.Cell(RenglonRepetido, igySerieCodigo).Text & " esta repetida en el renglón " & RenglonRepetido & "." & vbCrLf & _
                                       "", MsgBoxStyle.Exclamation)
                                Me.GridSeries.Cell(RenglonRepetido, Me.igySerieNumeroSerie).SetFocus()

                                Return True

                            End If
                        Next
                    End If
                Next
            End If
        Catch ex As Exception
            HandleError(Me.Name, "HaySeriesRepetidas", ex)
        End Try

        Return False
    End Function

#End Region

End Class