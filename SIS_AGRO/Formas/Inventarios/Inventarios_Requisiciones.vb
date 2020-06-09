Option Strict On

Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine

Public Class Inventarios_Requisiciones

#Region "Campos privados"
    Private Estado As enumEstados
    Private oRequisiciones As New Class_Requisiciones_Global
    Private oDocumentos As Class_Cat_tiposDocumentos
    Private oArticulos As New Class_CatArticulos

    Private Enum enumEstados
        NUEVO
        GRABADO
        SOLICITADO
        APLICADO
        CANCELADO
    End Enum
#End Region

#Region "Columnas grid"
    Private iGyCodigo As Integer = 1
    Private iGyDescripcion As Integer = 2
    Private iGyCantidad As Integer = 3
    Private iGyUnidad As Integer = 4
    Private iGyDisponible As Integer = 5
    Private iGyCantidadAnulada As Integer = 6
    Private iGyCantidadAnular As Integer = 7

#End Region

#Region "Propiedades"

#End Region

#Region "Opciones"
    Private Sub tsbNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbNuevo.Click
        Me.Inicializa()
        Me.Cambia_Estado(enumEstados.NUEVO)
    End Sub

    Private Sub tsbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGrabar.Click
        If txtLEN(Me.TxtFolio.Text) = True Then
            If Me.Grabar() = True Then
                Me.Consultar()
            End If
        End If
    End Sub

    Private Sub tsbSolicitar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSolicitar.Click
        If Me.Solicitar() Then
            Me.Consultar()
        End If
    End Sub

    Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click
        Me.Imprimir()
    End Sub

    Private Sub tsbCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCancelar.Click
        If Me.Cancelar() = True Then
            Me.Consultar()
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

#End Region

#Region "Eventos"
    Private Sub Requisiciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Inicializa()
        Me.DesplegarAlmacenes()
        Me.Cambia_Estado(enumEstados.NUEVO)
    End Sub

    Private Sub Grid1_KeyDown(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Grid1.KeyDown
        Me.GestionaGrid(e)
    End Sub

    Private Sub CmbDocumento_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        txtTAB(e)
    End Sub

    Private Sub CmbAlmacen_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CboAlmacen.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.Send("{TAB}")
            Case Keys.Escape
                'Me.CboDocumento.Focus()
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

    Private Sub TxtConcepto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtConcepto.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                Me.Grid1.Cell(1, 1).SetFocus()
            Case Keys.Escape
                'Me.TxtFolioReferencia.Focus()
        End Select
    End Sub

    Private Sub TxtFolio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtFolio.KeyDown
        Select Case e.KeyCode
            Case Keys.F6
                Me.TxtFolio.Text = BusquedaVisual_PorDescripcion()
            Case Keys.Enter
                If Consultar() = False Then
                    Me.GeneraFolio()
                End If
            Case Keys.Escape
                Me.CboAlmacen.Focus()
        End Select
    End Sub

#Region "Eventos Genericos"
    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DtpFecha.KeyPress, TxtConcepto.KeyPress, TxtFolio.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub txtSoloNumerosDecimales_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim txt As TextBox = CType(sender, TextBox)
        txtSoloNumerosDecimales(e, txt.Text)
        txtNoBeep(e)
    End Sub
#End Region

#End Region

#Region "Métodos y procedimientos"

    Private Sub Cambia_Estado(ByVal pEstado As enumEstados)
        Const sProcedure As String = "Cambia_Estado"
        Try
            Me.Estado = pEstado

            Select Case Me.Estado
                Case enumEstados.NUEVO
                    Me.tsslEstado.Text = "ESTADO: AGREGANDO NUEVO MOVIMIENTO"
                    Me.tsslElaboro.Text = ""
                    Me.tsslCancelo.Text = ""
                    Me.tsbNuevo.Enabled = True
                    Me.tsbGrabar.Enabled = True
                    Me.tsbSolicitar.Enabled = True
                    Me.tsbCancelar.Enabled = False
                    Me.tsbImprimir.Enabled = False
                    Me.DtpFecha.Enabled = True
                    Me.CboAlmacen.Enabled = True
                    Me.TxtFolio.Enabled = True
                    Me.TxtConcepto.Enabled = True
                    Me.Grid1.Locked = False

                    If Me.Visible = True Then
                        Me.TxtFolio.Focus()
                    End If

                Case enumEstados.GRABADO
                    Me.tsslEstado.Text = "ESTADO: CONSULTANDO MOVIMIENTO"
                    Me.tsslCancelo.Text = ""
                    Me.tsbNuevo.Enabled = True
                    Me.tsbGrabar.Enabled = True
                    Me.tsbSolicitar.Enabled = True
                    Me.tsbCancelar.Enabled = True
                    Me.tsbImprimir.Enabled = True
                    Me.DtpFecha.Enabled = False
                    Me.CboAlmacen.Enabled = False
                    Me.TxtFolio.Enabled = False
                    Me.TxtConcepto.Enabled = True
                    Me.Grid1.Locked = False

                    Me.TxtConcepto.Focus()

                Case enumEstados.SOLICITADO
                    Me.tsslEstado.Text = "ESTADO: CONSULTANDO MOVIMIENTO"
                    Me.tsslCancelo.Text = ""
                    Me.tsbNuevo.Enabled = True
                    Me.tsbGrabar.Enabled = False
                    Me.tsbSolicitar.Enabled = False
                    Me.tsbCancelar.Enabled = True
                    Me.tsbImprimir.Enabled = True
                    Me.DtpFecha.Enabled = False
                    Me.CboAlmacen.Enabled = False
                    Me.TxtFolio.Enabled = False
                    Me.TxtConcepto.Enabled = False
                    Me.Grid1.Locked = True

                Case enumEstados.APLICADO


                Case enumEstados.CANCELADO
                    Me.tsslEstado.Text = "ESTADO: CONSULTANDO MOVIMIENTO"
                    Me.tsbNuevo.Enabled = True
                    Me.tsbGrabar.Enabled = False
                    Me.tsbSolicitar.Enabled = False
                    Me.tsbCancelar.Enabled = False
                    Me.tsbImprimir.Enabled = True
                    Me.DtpFecha.Enabled = False
                    Me.CboAlmacen.Enabled = False
                    Me.TxtFolio.Enabled = False
                    Me.TxtConcepto.Enabled = False
                    Me.Grid1.Locked = True

            End Select
            Application.DoEvents()

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Sub Inicializa()
        Const sProcedure As String = "Inicializa"
        Try
            Me.TxtFolio.Text = ""
            Me.TxtConcepto.Text = ""
            Me.DtpFecha.Value = Date.Now
            Me.Grid1.DataSource = Nothing

            Me.InicializaGrid()

            Me.DtpFecha.Value = Date.Now
            Me.TxtConcepto.Text = ""
            Me.lblStatus.Text = ""

            Me.GeneraFolio()

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Sub InicializaGrid()
        Const sProcedure As String = "InicializaGrid"
        Try
            FG_Grid_Limpiar(Me.Grid1)
            Me.Grid1.Rows = 2
            Me.FormateaGrid()

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Sub GestionaGrid(ByVal e As System.Windows.Forms.KeyEventArgs)
        Const sProcedure As String = "GestionaGrid"
        Try
            Dim Columna As Integer, Renglon As Integer
            Dim StrCod As String, sCodArticulo As String, sCantidad As String

            Me.oArticulos = New Class_CatArticulos

            Columna = Me.Grid1.Selection.FirstCol
            Renglon = Me.Grid1.Selection.FirstRow
            StrCod = Me.Grid1.Cell(Renglon, iGyCodigo).Text

            Select Case e.KeyCode
                Case Keys.Enter
                    sCantidad = Me.Grid1.Cell(Renglon, iGyCantidad).Text

                    Me.oArticulos.CODIGO_ARTICULO = StrCod
                    If Me.oArticulos.Consultar() = False Then
                        Me.Grid1.Cell(Renglon, iGyCodigo).Text = ""
                        GoTo BuscaArticulos
                        Return
                    End If

                    If oArticulos.ESTATUS = "B" Then
                        MsgBox("Este artículo esta dado de baja.", vbExclamation, sProcedure)
                        oArticulos.CODIGO_ARTICULO = ""
                        oArticulos.DESCRIPCION = ""
                    End If

                    Select Case Columna
                        Case Me.iGyCodigo
                            If Me.oArticulos.DESCRIPCION = "" Then
                                MsgBox("El código de artículo que intenta buscar no existe o esta dado de baja, favor de intentar con otro código.", MsgBoxStyle.Exclamation, sProcedure)
                                Me.Grid1.Cell(Renglon, iGyCodigo).SetFocus()
                                Return
                            Else
                                Me.Grid1.Cell(Renglon, Me.iGyDescripcion).Text = Me.oArticulos.DESCRIPCION


                            End If
                            Me.oArticulos = Nothing

                        Case Me.iGyCantidad


                    End Select

                    If Me.Grid1.Rows = Renglon + 1 Then 'Si se está en el último renglón, se agrega un renglón más.
                        Me.Grid1.Rows = Me.Grid1.Rows + 1
                    End If


                Case Keys.F6, Keys.F7

                    Select Case Columna
                        Case Me.iGyCodigo
                            If e.KeyCode = Keys.F6 Then
BuscaArticulos:
                                sCodArticulo = Me.oArticulos.BusquedaVisualInventariablesConExistencia_PorDescripcion(Me.CboAlmacen.SelectedValue.ToString)
                                If Len(sCodArticulo) > 0 Then
                                    Me.Grid1.Cell(Renglon, Me.iGyDescripcion).Text = Me.oArticulos.BuscarNombreArticulo(sCodArticulo)
                                    Me.Grid1.Cell(Renglon, Me.iGyCodigo).Text = sCodArticulo
                                End If
                                Me.Grid1.Cell(Renglon, iGyCodigo).SetFocus()

                            ElseIf e.KeyCode = Keys.F7 Then

                                sCodArticulo = Me.oArticulos.BusquedaVisualInventariablesConExistencia_PorCodigo(Me.CboAlmacen.SelectedValue.ToString)
                                If Len(sCodArticulo) > 0 Then
                                    Me.Grid1.Cell(Renglon, Me.iGyDescripcion).Text = Me.oArticulos.BuscarNombreArticulo(sCodArticulo)
                                    Me.Grid1.Cell(Renglon, Me.iGyCodigo).Text = sCodArticulo

                                End If
                                Me.Grid1.Cell(Renglon, iGyCodigo).SetFocus()

                            End If

                    End Select

                Case Keys.F8, Keys.Delete

                    If (Me.Estado = enumEstados.NUEVO Or Me.Estado = enumEstados.GRABADO) Then
                        Me.Grid1.Selection.DeleteByRow()
                        e.SuppressKeyPress = True

                        If Me.Grid1.Rows = 1 Then
                            Me.InicializaGrid() 'Para que reestablesca el idAdicional desde el 1
                        End If

                    End If
            End Select

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Function Grabar(Optional ByVal bMensaje As Boolean = True) As Boolean
        Const sProcedure As String = "Grabar"
        Dim bResultado As Boolean = False
        Dim i As Integer

      
        'If Usuario.ValidaPermisoUsuarioTiposDocumentosConAfectaInventarios(Me.CboDocumento.SelectedValue.ToString, Me.CboAlmacen.SelectedValue.ToString, "") = False Then
        '    'MsgBox("El usuario " & Usuario.Nombre_Usuario & " no tiene permiso para realizar el movimiento de inventarios.", MsgBoxStyle.Information, sProcedure)
        '    Return False
        'End If
        
        If bMensaje = True Then
            If MsgBox("Deseas grabar la requisición?", CType(vbYesNo + vbQuestion, MsgBoxStyle), sProcedure) = MsgBoxResult.No Then
                Return False
            End If
        End If

        If Plaza.ValidarPeriodoTrabajo(Me.DtpFecha.Value) = False Then 'Para grabar se valida con la fecha que el usuario tiene en el datepicker
            Return False
        End If

        If Me.SiTieneRenglones() = False Then
            MsgBox("Asígne los artículos del movimiento.", MsgBoxStyle.Exclamation, sProcedure)
            Return False
        End If

        If Me.SiTieneCantidad() = False Then
            MsgBox("La cantidad de los artículos debe de ser mayor a cero.", MsgBoxStyle.Exclamation, sProcedure)
            Return False
        End If

        Select Case Me.Estado
            Case enumEstados.NUEVO, enumEstados.GRABADO
                Me.oRequisiciones = New Class_Requisiciones_Global
                Try
                    With oRequisiciones
                        .FOLIO_REQUISICION = Me.TxtFolio.Text.ToUpper
                        .FECHA = Me.DtpFecha.Value
                        .CODIGO_ALMACEN = "" & Me.CboAlmacen.SelectedValue.ToString()
                        .CODIGO_PLAZA = Usuario.Codigo_Plaza
                        .CODIGO_DOCUMENTO = ""
                        .CONCEPTO = "" & Me.TxtConcepto.Text

                        Select Case Me.Estado
                            Case enumEstados.NUEVO
                                If .Grabar("INSERTAR") = False Then
                                    MsgBox("Error al tratar de agregar la requisición de inventario.", MsgBoxStyle.Exclamation, sProcedure)
                                    Return False
                                End If
                                Me.TxtFolio.Text = .FOLIO_REQUISICION

                            Case enumEstados.GRABADO
                                If .Grabar("ACTUALIZAR") = False Then
                                    MsgBox("Error al tratar de actualizar la requisición de inventario.", MsgBoxStyle.Exclamation, sProcedure)
                                    Return False
                                End If
                        End Select

                        'se graba el detalle
                        For i = 1 To Me.Grid1.Rows - 1
                            If txtLEN(Me.Grid1.Cell(i, Me.iGyCodigo).Text) = True Then
                                .NuevoRenglon()

                                .oRequisicionDetalle.FOLIO_REQUISICION = .FOLIO_REQUISICION
                                .oRequisicionDetalle.CODIGO_ARTICULO = Me.Grid1.Cell(i, Me.iGyCodigo).Text
                                .oRequisicionDetalle.CANTIDAD = valorNumerico(Me.Grid1.Cell(i, Me.iGyCantidad).Text)

                                If .oRequisicionDetalle.GrabaRenglon() = False Then
                                    MsgBox("Error al tratar de grabar el detalle.", MsgBoxStyle.Exclamation, sProcedure)
                                    Return False
                                End If

                            End If
                        Next

                        bResultado = True

                        If bMensaje = True Then
                            MsgBox("Requisición de inventario grabada satisfactoriamente.", MsgBoxStyle.Information, sProcedure)
                        End If
                    End With

                Catch ex As Exception
                    HandleError(Me.Name, sProcedure, ex)
                    Me.Consultar()
                Finally
                    Me.oRequisiciones = Nothing
                End Try
        End Select

        Return bResultado
    End Function

    Function Solicitar() As Boolean
        Const sProcedure As String = "Solicitar"
        Dim bResultado As Boolean = False
        Try

            Me.oRequisiciones = New Class_Requisiciones_Global(Me.TxtFolio.Text)
            bResultado = Me.oRequisiciones.Solicita()

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    Private Function Cancelar() As Boolean
        Const sProcedure As String = "Cancelar"
        Dim bResultado As Boolean = False

        Dim oFirmaElectronica As New UtileriasFirmaElectronicaCancelacionMovimientosFueraPeriodo
        Dim oUtileriasCancela As New Class_UtileriasFirmaElectronicaCancelacion


        If Me.oRequisiciones.ESTATUS <> "G" Then
            MsgBox("Este documento sólo se puede cancelar si esta en estatus de GRABADO.", MsgBoxStyle.Exclamation, sProcedure)
            Return False
        End If


        'If Usuario.ValidaPermisoUsuarioTiposDocumentosConAfectaInventarios(Me.CboDocumento.SelectedValue.ToString, Me.CboAlmacen.SelectedValue.ToString, "") = False Then
        '    Return False
        'End If


        If MsgBox("Deseas cancelar la requisición de inventario ?", CType(vbYesNo + vbQuestion, MsgBoxStyle), sProcedure) = MsgBoxResult.No Then
            Return False
        End If

        'If PLAZA.ValidarPeriodoTrabajo(Date.Now) = False Then 'Para cancelar se valida con la fecha de la maquina
        '    return false
        'End If

        Try
            oUtileriasCancela.FOLIO_DOCUMENTO = Me.TxtFolio.Text.ToUpper
            oUtileriasCancela.MODULO = Me.oRequisiciones.CODIGO_MODULO
            oUtileriasCancela.CODIGO_PLAZA = Usuario.Codigo_Plaza

            If oUtileriasCancela.GestionaCancelacion() = False Then
                Return False
            End If

            If oUtileriasCancela.CANCELA_DIRECTO = True Then
                Me.oRequisiciones.FECHA_CANCELACION = Date.Now

                If Me.oRequisiciones.Cancelar() = False Then
                    Return False
                End If
            Else
                oUtileriasCancela = New Class_UtileriasFirmaElectronicaCancelacion
                oUtileriasCancela.FOLIO_DOCUMENTO = Me.TxtFolio.Text
                'oUtileriasCancela.CODIGO_DOCUMENTO = Me.CboDocumento.SelectedValue.ToString
                oUtileriasCancela.CODIGO_PLAZA = Usuario.Codigo_Plaza
                oUtileriasCancela.MODULO = Me.oRequisiciones.CODIGO_MODULO

                If oUtileriasCancela.AutorizaCancelacionMovimientosFueraPeriodo() = False Then
                    Return False
                End If

                'si no se autorizo
                If oUtileriasCancela.CANCELACION_AUTORIZO = False Then
                    MsgBox("No se autorizó la cancelación de movimiento.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If

                If oUtileriasCancela.GestionaCancelacionConInterfaz() = False Then
                    MsgBox("Error al gestionar la cancelacion con interfaz", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                Else
                    If oUtileriasCancela.ES_FECHA_CANCELACION_VALIDA = "0" Then
                        MsgBox("La fecha de cancelación debe de ser mayor o igual a la fecha del documento y debe estar en el mismo ejercicio.", vbExclamation, sProcedure)
                        Return False
                    End If

                    Me.oRequisiciones.FECHA_CANCELACION = oUtileriasCancela.FECHA_CANCELACION  

                    If Me.oRequisiciones.Cancelar() = False Then
                        MsgBox("Error al intentar cancelar el movimiento de inventario.", MsgBoxStyle.Exclamation, sProcedure)
                        Return False
                    End If
                End If
            End If

            MsgBox("Requisición de inventario cancelado satisfactoriamente.", MsgBoxStyle.Information, sProcedure)
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
            
            FormatoDeReporte = "RPT_FORMATO"

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

        Catch ex As Exception
            HandleError(Me.Name, "DesplegarAlmacenes", ex)
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
            'Dim sFolio As String = ""
            'If Me.CboAlmacen.Items.Count = 0 Or Me.CboDocumento.Items.Count = 0 Then
            '    Exit Function
            'End If

            'Me.oInventarios = New Class_Inventarios_Global
            'Me.oInventarios.CODIGO_TIPO_DOCUMENTO = Me.CboDocumento.SelectedValue.ToString
            'Me.oInventarios.CODIGO_ALMACEN1 = Me.CboAlmacen.SelectedValue.ToString

            'Me.TxtFolio.Text = Me.oInventarios.GeneraFolioInventarios()
        Catch ex As Exception
            HandleError(Me.Name, "GeneraFolio", ex)
        End Try
    End Function

    Private Function Consultar() As Boolean
        Dim bResultado As Boolean = False
        Try

            Me.oRequisiciones = New Class_Requisiciones_Global()
            Dim sFolio As String = Me.TxtFolio.Text

            Me.Inicializa()

            Me.oRequisiciones.FOLIO_REQUISICION = sFolio

            If Me.oRequisiciones.Consultar = False Then
                Me.Cambia_Estado(enumEstados.NUEVO)
                Return False
            End If

            'If Me.CboDocumento.SelectedValue.ToString <> oInventarios.CODIGO_TIPO_DOCUMENTO Then
            '    Me.GeneraFolio()
            '    Return False
            'End If

            Me.TxtFolio.Text = oRequisiciones.FOLIO_REQUISICION.ToUpper
            Me.lblStatus.Text = oRequisiciones.ESTATUS.ToUpper
            Me.CboAlmacen.SelectedValue = oRequisiciones.CODIGO_ALMACEN.ToUpper
            Me.TxtConcepto.Text = oRequisiciones.CONCEPTO.ToUpper
            Me.DtpFecha.Value = CDate(oRequisiciones.FECHA)

            'Consulta datos detalle
            Dim dTabla As DataTable = Me.oRequisiciones.ObtenerDetalle
            Me.Grid1.AutoRedraw = False
            Me.Grid1.Rows = 1 'Trae dos porque en docs nuevos se pone un row en blanco, y si se dejan aqui dos agrega a partir del 3 y queda un hueco
            For Each dRow As DataRow In dTabla.Rows
                Me.Grid1.AddItem(dRow("CODIGO_ARTICULO").ToString & Chr(9) &
                                 dRow("DESCRIPCION").ToString & Chr(9) &
                                 dRow("CANTIDAD").ToString & Chr(9) &
                                 dRow("DISPONIBLE").ToString & Chr(9) &
                                 dRow("CANTIDAD_ANULADA").ToString & Chr(9) &
                                 "0" & Chr(9)) 'cantidad a anular
            Next

            If Me.lblStatus.Text = "G" Then Me.Grid1.Rows = Me.Grid1.Rows + 1

            Me.Grid1.AutoRedraw = True
            Me.Grid1.Refresh()
            Me.FormateaGrid()

            bResultado = True

            If Me.lblStatus.Text = "G" Then
                Me.Estado = enumEstados.GRABADO
            ElseIf Me.lblStatus.Text = "A" Then
                Me.Estado = enumEstados.APLICADO
            ElseIf Me.lblStatus.Text = "L" Then
                Me.Estado = enumEstados.SOLICITADO
            ElseIf Me.lblStatus.Text = "C" Then
                Me.Estado = enumEstados.CANCELADO
            End If

            Me.Cambia_Estado(Me.Estado)

            Me.tsslElaboro.Text = "ELABORO: " + Me.oRequisiciones.NOMBRE_USUARIO_GRABO.ToUpper + " EL " + Format(Me.DtpFecha.Value, "dd/MMM/yy")

            If Me.lblStatus.Text = "L" Or Me.lblStatus.Text = "R" Then
                Me.tsslSolicito.Text = "SOLICITO: " + Me.oRequisiciones.NOMBRE_USUARIO_SOLICITO.ToUpper + " EL " + Format(Me.oRequisiciones.FECHA_SOLICITO, "dd/MMM/yy")
            End If

            If Me.lblStatus.Text = "C" Then
                Me.tsslCancelo.Text = "CANCELO: " + Me.oRequisiciones.NOMBRE_USUARIO_CANCELO.ToUpper + " EL " + Format(Me.oRequisiciones.FECHA_CANCELACION, "dd/MMM/yy")
            End If

        Catch ex As Exception
            HandleError(Me.Name, "Consultar", ex)
        End Try

        Return bResultado
    End Function

    Private Sub FormateaGrid()
        Try
            With Me.Grid1
                .AutoRedraw = False
                .Cols = 8
                .DisplayFocusRect = False

                .DrawMode = FlexCell.DrawModeEnum.OwnerDraw
                .BorderStyle = FlexCell.BorderStyleEnum.FixedSingle
                .FixedRowColStyle = FlexCell.FixedRowColStyleEnum.Flat

                .BackColor1 = Color.FromArgb(231, 235, 247)
                .BackColor2 = Color.FromArgb(239, 243, 255)
                .CellBorderColorFixed = Color.Black
                .GridColor = Color.FromArgb(148, 190, 231)

                .Cell(0, Me.iGyCodigo).Text = "Codigo"
                .Cell(0, Me.iGyDescripcion).Text = "Descripcion"
                .Cell(0, Me.iGyCantidad).Text = "Cantidad"
                .Cell(0, Me.iGyUnidad).Text = "Unidad"
                .Cell(0, Me.iGyDisponible).Text = "Pendiente pedir"
                .Cell(0, Me.iGyCantidadAnulada).Text = "Cantidad anulada"
                .Cell(0, Me.iGyCantidadAnular).Text = "Cantidad anular"

                .Column(Me.iGyCantidad).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyCantidad).DecimalLength = Empresa_Sistema.DECIMALES_CANTIDAD
                .Column(Me.iGyCantidad).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGyDisponible).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyDisponible).DecimalLength = Empresa_Sistema.DECIMALES_CANTIDAD
                .Column(Me.iGyDisponible).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGyCantidadAnulada).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyCantidadAnulada).DecimalLength = Empresa_Sistema.DECIMALES_CANTIDAD
                .Column(Me.iGyCantidadAnulada).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGyCantidadAnular).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyCantidadAnular).DecimalLength = Empresa_Sistema.DECIMALES_CANTIDAD
                .Column(Me.iGyCantidadAnular).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGyDescripcion).Locked = True
                .Column(Me.iGyDisponible).Locked = True
                .Column(Me.iGyUnidad).Locked = True
                .Column(Me.iGyCantidadAnulada).Locked = True

                .Column(Me.iGyCodigo).Width = 100
                .Column(Me.iGyDescripcion).Width = 190
                .Column(Me.iGyCantidad).Width = 80
                .Column(Me.iGyUnidad).Width = 80
                .Column(Me.iGyCantidadAnulada).Width = 80
                .Column(iGyCantidadAnular).Width = 80

            End With

        Catch ex As Exception
            HandleError(Me.Name, "FormateaGrid", ex)
        Finally
            Me.Grid1.AutoRedraw = True
            Me.Grid1.Refresh()
        End Try
    End Sub

    Private Function SiTieneRenglones() As Boolean
        Const sProcedure As String = "SiTieneRenglones"
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
            HandleError(Me.Name, sProcedure, ex)
        End Try
        Return bResultado
    End Function

    Private Function SiTieneCantidad() As Boolean
        Const sProcedure As String = "SiTieneCantidad"
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
            HandleError(Me.Name, sProcedure, ex)
        End Try
        Return bResultado
    End Function

    Private Sub Navegador(ByVal sTipoDeBusqueda As String)
        Const sProcedure As String = "Navegador"
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
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

#End Region

End Class