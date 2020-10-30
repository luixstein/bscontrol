Option Strict On

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
        PARCIALMENTE_SOLICITADO
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
        If txtLEN(Me.txtFolio.Text) = True Then
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

    Private Sub tsbAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbAnular.Click
        If Me.Anular() Then
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
        Me.Cambia_Estado(enumEstados.NUEVO)
    End Sub

    Private Sub Grid1_KeyDown(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Grid1.KeyDown
        Me.GestionaGrid(e)
    End Sub

    Private Sub DtpFecha_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtFechaEntrega.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.Send("{TAB}")
        End Select
    End Sub

    Private Sub TxtConcepto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtConcepto.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                Me.Grid1.Cell(1, 1).SetFocus()
        End Select
    End Sub

    Private Sub TxtFolio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFolio.KeyDown
        Select Case e.KeyCode
            Case Keys.F6
                Dim oRequisicion As New Class_Requisiciones_Global
                Dim sFolio As String = oRequisicion.BusquedaVisual_PorDescripcion()
                If txtLEN(sFolio) = True Then
                    Me.txtFolio.Text = sFolio
                    GoTo Enter : Return
                End If

            Case Keys.Enter
Enter:
                If Me.Consultar() = False Then
                    Me.GeneraFolio()
                End If
        End Select
    End Sub

    Private Sub txtAlmacen_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAlmacen.KeyDown
        Dim oAlmacen As New Class_CatAlmacenes
        Try
            Select Case e.KeyCode
                Case Keys.F6
Buscar:
                    Dim sAlmacen As String = oAlmacen.BusquedaVisual_PorDescripcionSoloActivos()
                    If txtLEN(sAlmacen) = True Then
                        Me.txtAlmacen.Text = sAlmacen
                        GoTo Enter : Return
                    End If

                Case Keys.Enter
                    If txtLEN(Me.txtAlmacen.Text) = False Then
                        Me.lblAlmacen.Text = ""
                        GoTo Buscar : Return
                    End If
Enter:
                    oAlmacen = New Class_CatAlmacenes(Me.txtAlmacen.Text)

                    If oAlmacen.Existe = False Then
                        Me.lblAlmacen.Text = ""
                        GoTo Buscar : Return
                    ElseIf oAlmacen.ESTATUS = "B" Then
                        MsgBox("El almacén " & Me.txtAlmacen.Text & " está dado de baja.", MsgBoxStyle.Exclamation, Me.Text)
                        GoTo Buscar : Return
                    End If

                    Me.lblAlmacen.Text = oAlmacen.NOMBRE_ALMACEN

                    txtTAB(e)
            End Select

        Catch ex As Exception
            HandleError(Me.Name, "txtAlmacen_KeyDown", ex)
        End Try
    End Sub

    Private Sub txtComprador_KeyDown(sender As Object, e As KeyEventArgs) Handles txtComprador.KeyDown
        Dim oUsuario As New Class_sisUsuarios
        Try
            Select Case e.KeyCode
                Case Keys.F6
Buscar:
                    Dim sUsuario As String = oUsuario.BusquedaVisual_PorDescripcion
                    If txtLEN(sUsuario) = True Then
                        Me.txtComprador.Text = sUsuario
                        GoTo Enter : Return
                    End If

                Case Keys.Enter
                    If txtLEN(Me.txtComprador.Text) = False Then
                        Me.lblComprador.Text = ""
                        GoTo Buscar : Return
                    End If
Enter:
                    oUsuario = New Class_sisUsuarios(CInt(valorNumerico(Me.txtComprador.Text)))

                    If oUsuario.Existe = False Then
                        Me.lblComprador.Text = ""
                        GoTo Buscar : Return
                    ElseIf oUsuario.ESTATUS = "B" Then
                        MsgBox("El usuario " & Me.txtComprador.Text & " está dado de baja.", MsgBoxStyle.Exclamation, Me.Text)
                        GoTo Buscar : Return
                    End If

                    Me.lblComprador.Text = oUsuario.Nombre_Usuario

                    txtTAB(e)
            End Select

        Catch ex As Exception
            HandleError(Me.Name, "txtComprador_KeyDown", ex)
        End Try
    End Sub

#End Region

#Region "Eventos Genericos"
    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtFechaEntrega.KeyPress, txtConcepto.KeyPress, txtFolio.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub txtNumerosEnterosKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAlmacen.KeyPress, txtComprador.KeyPress
        txtSoloNumerosEnteros(e)
        txtNoBeep(e)
    End Sub
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
                    Me.tsslSolicito.Text = ""
                    Me.tsslCancelo.Text = ""

                    Me.tsbNuevo.Enabled = True
                    Me.tsbGrabar.Enabled = True
                    Me.tsbSolicitar.Enabled = False
                    Me.tsbAnular.Enabled = False
                    Me.tsbCancelar.Enabled = False
                    Me.tsbImprimir.Enabled = False

                    Me.dtFechaEntrega.Enabled = True
                    Me.txtAlmacen.Enabled = True
                    Me.txtComprador.Enabled = True
                    Me.txtFolio.Enabled = True
                    Me.txtConcepto.Enabled = True
                    Me.Grid1.Locked = False
                    Me.Grid1.Column(Me.iGyCodigo).Locked = False
                    Me.Grid1.Column(Me.iGyCantidad).Locked = False
                    Me.Grid1.Column(Me.iGyCantidadAnular).Locked = True
                    Me.lblNombreEstatus.Text = "NUEVO"

                    If Me.Visible = True Then
                        Me.txtFolio.Focus()
                    End If

                Case enumEstados.GRABADO
                    Me.tsslEstado.Text = "ESTADO: CONSULTANDO MOVIMIENTO"
                    Me.tsslSolicito.Text = ""
                    Me.tsslCancelo.Text = ""

                    Me.tsbNuevo.Enabled = True
                    Me.tsbGrabar.Enabled = True
                    Me.tsbSolicitar.Enabled = True
                    Me.tsbAnular.Enabled = False
                    Me.tsbCancelar.Enabled = True
                    Me.tsbImprimir.Enabled = True

                    Me.dtFechaEntrega.Enabled = False
                    Me.txtAlmacen.Enabled = False
                    Me.txtComprador.Enabled = False
                    Me.txtFolio.Enabled = False
                    Me.txtConcepto.Enabled = True
                    Me.Grid1.Locked = False
                    Me.Grid1.Column(Me.iGyCodigo).Locked = False
                    Me.Grid1.Column(Me.iGyCantidad).Locked = False
                    Me.Grid1.Column(Me.iGyCantidadAnular).Locked = True
                    Me.lblNombreEstatus.Text = "GRABADO"

                    Me.txtConcepto.Focus()

                Case enumEstados.SOLICITADO, enumEstados.PARCIALMENTE_SOLICITADO
                    Me.tsslEstado.Text = "ESTADO: CONSULTANDO MOVIMIENTO"
                    Me.tsslCancelo.Text = ""

                    Me.tsbNuevo.Enabled = True
                    Me.tsbGrabar.Enabled = False
                    Me.tsbSolicitar.Enabled = False
                    Me.tsbAnular.Enabled = True
                    Me.tsbCancelar.Enabled = False
                    Me.tsbImprimir.Enabled = True

                    If Me.Estado = enumEstados.SOLICITADO Then
                        Me.tsbCancelar.Enabled = True
                    End If

                    Me.dtFechaEntrega.Enabled = False
                    Me.txtAlmacen.Enabled = False
                    Me.txtComprador.Enabled = False
                    Me.txtFolio.Enabled = False
                    Me.txtConcepto.Enabled = False
                    Me.Grid1.Locked = False
                    Me.Grid1.Column(Me.iGyCodigo).Locked = True
                    Me.Grid1.Column(Me.iGyCantidad).Locked = True
                    Me.Grid1.Column(Me.iGyCantidadAnular).Locked = False

                    If Me.Estado = enumEstados.SOLICITADO Then
                        Me.lblNombreEstatus.Text = "SOLICITADO"
                    Else
                        Me.lblNombreEstatus.Text = "PARCIALMENTE PEDIDO"
                    End If

                Case enumEstados.APLICADO
                    Me.tsslEstado.Text = "ESTADO: CONSULTANDO MOVIMIENTO"
                    Me.tsslCancelo.Text = ""

                    Me.tsbNuevo.Enabled = True
                    Me.tsbGrabar.Enabled = False
                    Me.tsbSolicitar.Enabled = False
                    Me.tsbAnular.Enabled = False
                    Me.tsbCancelar.Enabled = False
                    Me.tsbImprimir.Enabled = True

                    Me.dtFechaEntrega.Enabled = False
                    Me.txtAlmacen.Enabled = False
                    Me.txtComprador.Enabled = False
                    Me.txtFolio.Enabled = False
                    Me.txtConcepto.Enabled = False
                    Me.Grid1.Locked = True
                    Me.lblNombreEstatus.Text = "APLICADO"

                Case enumEstados.CANCELADO
                    Me.tsslEstado.Text = "ESTADO: CONSULTANDO MOVIMIENTO"
                    Me.tsslSolicito.Text = ""

                    Me.tsbNuevo.Enabled = True
                    Me.tsbGrabar.Enabled = False
                    Me.tsbSolicitar.Enabled = False
                    Me.tsbAnular.Enabled = False
                    Me.tsbCancelar.Enabled = False
                    Me.tsbImprimir.Enabled = True

                    Me.dtFechaEntrega.Enabled = False
                    Me.txtAlmacen.Enabled = False
                    Me.txtComprador.Enabled = False
                    Me.txtFolio.Enabled = False
                    Me.txtConcepto.Enabled = False
                    Me.Grid1.Locked = True
                    Me.lblNombreEstatus.Text = "CANCELADO"

            End Select
            Application.DoEvents()

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Sub Inicializa()
        Const sProcedure As String = "Inicializa"
        Try
            Me.txtFolio.Text = ""
            Me.txtConcepto.Text = ""
            Me.dtFechaEntrega.Value = Date.Now
            Me.txtConcepto.Text = ""
            Me.lblStatus.Text = ""
            'Me.txtAlmacen.Text ="":Me.lblAlmacen.Text =""
            'Me.txtComprador.Text ="":Me.lblComprador.Text =""

            Me.Grid1.DataSource = Nothing
            Me.InicializaGrid()

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
            Dim StrCod As String, sCodArticulo As String = "", sCantidad As String

            Me.oArticulos = New Class_CatArticulos

            Columna = Me.Grid1.Selection.FirstCol
            Renglon = Me.Grid1.Selection.FirstRow
            StrCod = Me.Grid1.Cell(Renglon, iGyCodigo).Text

            If Me.Estado = enumEstados.NUEVO Or Me.Estado = enumEstados.GRABADO Then
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
                                    Me.Grid1.Cell(Renglon, Me.iGyUnidad).Text = Me.oArticulos.UNIDAD_VENTA
                                End If
                                Me.oArticulos = Nothing

                        End Select

                        If Me.Grid1.Rows = Renglon + 1 Then 'Si se está en el último renglón, se agrega un renglón más.
                            Me.Grid1.Rows = Me.Grid1.Rows + 1
                        End If


                    Case Keys.F6, Keys.F7
                        Select Case Columna
                            Case Me.iGyCodigo
                                If e.KeyCode = Keys.F6 Then
BuscaArticulos:
                                    sCodArticulo = Me.oArticulos.BusquedaVisualInventariablesConExistencia_PorDescripcion(Me.txtAlmacen.Text)
                                ElseIf e.KeyCode = Keys.F7 Then
                                    sCodArticulo = Me.oArticulos.BusquedaVisualInventariablesConExistencia_PorCodigo(Me.txtAlmacen.Text)
                                End If

                                If Len(sCodArticulo) > 0 Then
                                    Me.oArticulos.CODIGO_ARTICULO = sCodArticulo
                                    Me.oArticulos.Consultar()

                                    Me.Grid1.Cell(Renglon, Me.iGyCodigo).Text = sCodArticulo
                                    Me.Grid1.Cell(Renglon, Me.iGyDescripcion).Text = Me.oArticulos.DESCRIPCION
                                    Me.Grid1.Cell(Renglon, Me.iGyUnidad).Text = Me.oArticulos.UNIDAD_VENTA

                                End If
                                Me.Grid1.Cell(Renglon, iGyCodigo).SetFocus()

                        End Select

                    Case Keys.F8, Keys.Delete
                        Me.Grid1.Selection.DeleteByRow()
                        e.SuppressKeyPress = True

                        If Me.Grid1.Rows = 1 Then
                            Me.InicializaGrid()
                        End If

                End Select

            End If

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Function Grabar() As Boolean
        Const sProcedure As String = "Grabar"
        Dim bResultado As Boolean = False
        Dim i As Integer

        If Usuario.ValidaPermisoUsuarioDocumentoSinAfectacionInventarios("RQ" & Plaza.CODIGO_PLAZA.ToString) = False Then
            MsgBox("El usuario " & Usuario.Nombre_Usuario & " no tiene permiso grabar la requisición de inventario.", MsgBoxStyle.Information, sProcedure)
            Return False
        End If

        If MsgBox("Deseas grabar la requisición de inventario ?", CType(vbYesNo + vbQuestion, MsgBoxStyle), sProcedure) = MsgBoxResult.No Then
            Return False
        End If

        ''''''''''''''''Valida almacén
        If txtLEN(Me.txtAlmacen.Text) = False Then
            MsgBox("Asígne el almacén por favor.", MsgBoxStyle.Exclamation, Me.Text)
            Return False
        End If

        Dim oAlmacen As New Class_CatAlmacenes(Me.txtAlmacen.Text)

        If oAlmacen.Existe = False Then
            MsgBox("El almacén asignado no existe.", MsgBoxStyle.Exclamation, Me.Text)
            Return False
        ElseIf oAlmacen.ESTATUS = "B" Then
            MsgBox("El almacén asignado esta dado de baja.", MsgBoxStyle.Exclamation, Me.Text)
            Return False
        End If
        ''''''''''''''''''''''''''''''''

        ''''''''''''''''Valida comprador
        If txtLEN(Me.txtComprador.Text) = False Then
            MsgBox("Asígne el comprador por favor.", MsgBoxStyle.Exclamation, Me.Text)
            Return False
        End If

        Dim oComprador As New Class_sisUsuarios(CInt(valorNumerico(Me.txtComprador.Text)))

        If oComprador.Existe = False Then
            MsgBox("El comprador asignado no existe.", MsgBoxStyle.Exclamation, Me.Text)
            Return False
        ElseIf oComprador.ESTATUS = "B" Then
            MsgBox("El comprador asignado esta dado de baja.", MsgBoxStyle.Exclamation, Me.Text)
            Return False
        End If
        ''''''''''''''''''''''''''''''''

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
                        .FOLIO_REQUISICION = Me.txtFolio.Text.ToUpper
                        .FECHA_ENTREGA = Me.dtFechaEntrega.Value
                        .CODIGO_ALMACEN = Me.txtAlmacen.Text
                        .CODIGO_USUARIO_COMPRADOR = Me.txtComprador.Text
                        .CODIGO_PLAZA = Usuario.Codigo_Plaza
                        .CODIGO_DOCUMENTO = "RQ" & Plaza.CODIGO_PLAZA.ToString
                        .CONCEPTO = "" & Me.txtConcepto.Text

                        Select Case Me.Estado
                            Case enumEstados.NUEVO
                                If .Grabar("INSERTAR") = False Then
                                    MsgBox("Error al tratar de agregar la requisición de inventario.", MsgBoxStyle.Exclamation, sProcedure)
                                    Return False
                                End If
                                Me.txtFolio.Text = .FOLIO_REQUISICION

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
                        MsgBox("Requisición de inventario grabada satisfactoriamente.", MsgBoxStyle.Information, sProcedure)

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

    Private Function Solicitar() As Boolean
        Const sProcedure As String = "Solicitar"
        Dim bResultado As Boolean = False

        If Usuario.ValidaPermisoUsuarioDocumentoSinAfectacionInventarios("RQ" & Plaza.CODIGO_PLAZA.ToString) = False Then
            MsgBox("El usuario " & Usuario.Nombre_Usuario & " no tiene permiso solicitar la requisición de inventario.", MsgBoxStyle.Information, sProcedure)
            Return False
        End If

        Try
            Me.oRequisiciones = New Class_Requisiciones_Global(Me.txtFolio.Text)
            Me.oRequisiciones.FECHA_SOLICITO = Date.Now

            If Me.oRequisiciones.Solicita() = False Then
                MsgBox("Error al solicitar la requisición de inventario.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            bResultado = True
            MsgBox("Requisición de inventario solicitada satisfactoriamente.", MsgBoxStyle.Information, sProcedure)

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    Private Function Anular() As Boolean
        Const sProcedure As String = "Anular"
        Dim bResultado As Boolean = False

        If Usuario.ValidaPermisoUsuarioDocumentoSinAfectacionInventarios("RQ" & Plaza.CODIGO_PLAZA.ToString) = False Then
            MsgBox("El usuario " & Usuario.Nombre_Usuario & " no tiene permiso anular la requisición de inventario.", MsgBoxStyle.Information, sProcedure)
            Return False
        End If

        If MsgBox("Deseas anular cantidades de la requisición de solicitada ?", CType(vbYesNo + vbQuestion, MsgBoxStyle), sProcedure) = MsgBoxResult.No Then
            Return False
        End If

        If Me.ValidaCantidadesAnular() = False Then
            Return False
        End If

        Try
            With oRequisiciones
                .FOLIO_REQUISICION = Me.txtFolio.Text

                'se graba el detalle
                For i = 1 To Me.Grid1.Rows - 1
                    If txtLEN(Me.Grid1.Cell(i, Me.iGyCodigo).Text) = True Then
                        .NuevoRenglon()

                        .oRequisicionDetalle.FOLIO_REQUISICION = .FOLIO_REQUISICION
                        .oRequisicionDetalle.CODIGO_ARTICULO = Me.Grid1.Cell(i, Me.iGyCodigo).Text
                        .oRequisicionDetalle.CANTIDAD_ANULADA = valorNumerico(Me.Grid1.Cell(i, Me.iGyCantidadAnular).Text)

                        If .oRequisicionDetalle.AnularRenglon() = False Then
                            MsgBox("Error al tratar de grabar el detalle de la anulación.", MsgBoxStyle.Exclamation, sProcedure)
                            Return False
                        End If

                    End If
                Next

                'Despues de grabar el detalle actualizar el estado segun los nuevos disponibles
                If .Anular() = False Then
                    MsgBox("Error al actualizar el estado de la requisición despues de la anulación")
                    Return False
                End If

                bResultado = True
                MsgBox("Anulación realizada satisfactoriamente.", MsgBoxStyle.Information, sProcedure)

            End With

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

        Select Case Me.oRequisiciones.ESTATUS
            Case "C", "R", "A"
                MsgBox("Este documento sólo se puede cancelar si esta en estatus GRABADO o SOLICITADO.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
        End Select

        If Usuario.ValidaPermisoUsuarioDocumentoSinAfectacionInventarios("RQ" & Plaza.CODIGO_PLAZA.ToString) = False Then
            MsgBox("El usuario " & Usuario.Nombre_Usuario & " no tiene permiso cancelar la requisición de inventario.", MsgBoxStyle.Information, sProcedure)
            Return False
        End If

        If MsgBox("Deseas cancelar la requisición de inventario ?", CType(vbYesNo + vbQuestion, MsgBoxStyle), sProcedure) = MsgBoxResult.No Then
            Return False
        End If

        Try
            Me.oRequisiciones.FECHA_CANCELACION = Date.Now

            If Me.oRequisiciones.Cancelar() = False Then
                MsgBox("Error al cancelar la requisición de inventario.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
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
            FormatoDeReporte = "RPT_FORMATO_INVENTARIO_REQUISICION"

            oReporte = New Class_Reporte(FormatoDeReporte, Rpt)
            If Not oReporte.RptCargado Then
                Exit Sub
            End If
            Rpt.SetParameterValue("@FOLIO_REQUISICION", Me.txtFolio.Text)

            Dim frm As New Reporte(Rpt)
            frm.CRViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            frm.Show()
        Catch ex As Exception
            HandleError(Me.Name, "Imprimir", ex)
        Finally
            oReporte = Nothing
        End Try
    End Sub

    Private Function GeneraFolio() As Boolean
        Try
            Me.oRequisiciones = New Class_Requisiciones_Global
            Me.oRequisiciones.CODIGO_DOCUMENTO = "RQ" & Plaza.CODIGO_PLAZA.ToString
            Me.txtFolio.Text = Me.oRequisiciones.GeneraFolio()

        Catch ex As Exception
            HandleError(Me.Name, "GeneraFolio", ex)
        End Try
    End Function

    Private Function Consultar() As Boolean
        Dim bResultado As Boolean = False
        Try
            Me.oRequisiciones = New Class_Requisiciones_Global()
            Dim sFolio As String = Me.txtFolio.Text

            Me.Inicializa()

            Me.oRequisiciones.FOLIO_REQUISICION = sFolio

            If Me.oRequisiciones.Consultar = False Then
                Me.Cambia_Estado(enumEstados.NUEVO)
                Me.txtFolio.Enabled = False
                Return False
            End If

            Me.txtFolio.Text = oRequisiciones.FOLIO_REQUISICION
            Me.lblStatus.Text = oRequisiciones.ESTATUS
            Me.txtAlmacen.Text = oRequisiciones.CODIGO_ALMACEN
            Me.lblAlmacen.Text = New Class_CatAlmacenes(Me.txtAlmacen.Text).NOMBRE_ALMACEN
            Me.txtComprador.Text = oRequisiciones.CODIGO_USUARIO_COMPRADOR
            Me.lblComprador.Text = oRequisiciones.NOMBRE_COMPRADOR
            Me.txtConcepto.Text = oRequisiciones.CONCEPTO
            Me.dtFechaEntrega.Value = oRequisiciones.FECHA_ENTREGA

            'Consulta datos detalle
            Dim dTabla As DataTable = Me.oRequisiciones.ObtenerDetalle
            Me.Grid1.AutoRedraw = False
            Me.Grid1.Rows = 1 'Trae dos porque en docs nuevos se pone un row en blanco, y si se dejan aqui dos agrega a partir del 3 y queda un hueco
            For Each dRow As DataRow In dTabla.Rows
                Me.Grid1.AddItem(dRow("CODIGO_ARTICULO").ToString & Chr(9) &
                                 dRow("DESCRIPCION").ToString & Chr(9) &
                                 dRow("CANTIDAD").ToString & Chr(9) &
                                 dRow("UNIDAD_VENTA").ToString & Chr(9) &
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
            ElseIf Me.lblStatus.Text = "R" Then
                Me.Estado = enumEstados.PARCIALMENTE_SOLICITADO
            ElseIf Me.lblStatus.Text = "C" Then
                Me.Estado = enumEstados.CANCELADO
            End If

            Me.Cambia_Estado(Me.Estado)

            Me.tsslElaboro.Text = "ELABORO: " + Me.oRequisiciones.NOMBRE_USUARIO_GRABO.ToUpper + " EL " + Format(Me.dtFechaEntrega.Value, "dd/MMM/yy")

            If Me.lblStatus.Text = "L" Or Me.lblStatus.Text = "R" Or Me.lblStatus.Text = "A" Then
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

                .Cell(0, Me.iGyCodigo).Text = "Código"
                .Cell(0, Me.iGyDescripcion).Text = "Descripción"
                .Cell(0, Me.iGyCantidad).Text = "Cantidad"
                .Cell(0, Me.iGyUnidad).Text = "Unidad"
                .Cell(0, Me.iGyDisponible).Text = "Pendiente pedir"
                .Cell(0, Me.iGyCantidadAnulada).Text = "Cantidad anulada"
                .Cell(0, Me.iGyCantidadAnular).Text = "Cantidad a anular"

                .Column(Me.iGyCodigo).Width = 100
                .Column(Me.iGyDescripcion).Width = 190
                .Column(Me.iGyCantidad).Width = 80
                .Column(Me.iGyUnidad).Width = 80
                .Column(Me.iGyDisponible).Width = 90
                .Column(Me.iGyCantidadAnulada).Width = 90
                .Column(Me.iGyCantidadAnular).Width = 100

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

                .Cell(0, Me.iGyCodigo).Alignment = FlexCell.AlignmentEnum.LeftCenter
                .Cell(0, Me.iGyDescripcion).Alignment = FlexCell.AlignmentEnum.LeftCenter
                .Cell(0, Me.iGyCantidad).Alignment = FlexCell.AlignmentEnum.LeftCenter
                .Cell(0, Me.iGyUnidad).Alignment = FlexCell.AlignmentEnum.LeftCenter
                .Cell(0, Me.iGyDisponible).Alignment = FlexCell.AlignmentEnum.LeftCenter
                .Cell(0, Me.iGyCantidadAnulada).Alignment = FlexCell.AlignmentEnum.LeftCenter
                .Cell(0, Me.iGyCantidadAnular).Alignment = FlexCell.AlignmentEnum.LeftCenter

                .Column(Me.iGyDescripcion).Locked = True
                .Column(Me.iGyDisponible).Locked = True
                .Column(Me.iGyUnidad).Locked = True
                .Column(Me.iGyCantidadAnulada).Locked = True

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

    Private Function ValidaCantidadesAnular() As Boolean
        Const sProcedure As String = "ValidaCantidadesAnular"
        Dim bResultado As Boolean = False
        Try
            Dim i As Integer
            For i = 1 To Me.Grid1.Rows - 1
                If txtLEN(Me.Grid1.Cell(i, Me.iGyCodigo).Text) = True Then
                    If valorNumerico(Me.Grid1.Cell(i, Me.iGyDisponible).Text) < valorNumerico(Me.Grid1.Cell(i, iGyCantidadAnular).Text) Then
                        MsgBox("La cantidad para anular del renglón " & i.ToString & " es mayor al disponible.", MsgBoxStyle.Exclamation, sProcedure)
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
            If txtLEN(Me.txtFolio.Text) = False Then
                If GeneraFolio() = False OrElse txtLEN(Me.txtFolio.Text) = False Then
                    Exit Sub
                End If
            End If

            If sTipoDeBusqueda = "Anterior" Then
                iPosicion = Me.txtFolio.Text.IndexOf("-")
                sFolio = Me.txtFolio.Text.Substring(0, iPosicion)
                iFolio = CInt(Strings.Right(Me.txtFolio.Text, Len(Me.txtFolio.Text) - (Len(sFolio) + 1))) ' Me.oVenta.FOLIO_NUMERICO
                iFolio = iFolio - 1
                sFolioParte2 = Format(iFolio, New String(CChar("0"), Me.txtFolio.Text.Substring(3, Me.txtFolio.TextLength - iPosicion - 1).Length))
                sFolio = sFolio + "-" + sFolioParte2 'sFolio + "-" + iFolio.ToString
                Me.txtFolio.Text = sFolio

                If txtLEN(sFolio) = True Then
                    Me.Consultar()
                Else
                    Me.Inicializa()
                    Me.Cambia_Estado(enumEstados.NUEVO)
                    Me.GeneraFolio()
                    Me.txtFolio.Focus()
                End If

            ElseIf sTipoDeBusqueda = "Siguiente" Then
                iPosicion = Me.txtFolio.Text.IndexOf("-")
                sFolio = Me.txtFolio.Text.Substring(0, iPosicion)
                iFolio = CInt(Strings.Right(Me.txtFolio.Text, Len(Me.txtFolio.Text) - (Len(sFolio) + 1))) ' Me.oVenta.FOLIO_NUMERICO
                iFolio = iFolio + 1
                sFolioParte2 = Format(iFolio, New String(CChar("0"), Me.txtFolio.Text.Substring(3, Me.txtFolio.TextLength - iPosicion - 1).Length))
                sFolio = sFolio + "-" + sFolioParte2 'sFolio + "-" + iFolio.ToString
                Me.txtFolio.Text = sFolio

                If txtLEN(sFolio) = True Then
                    Me.Consultar()
                Else
                    Me.Inicializa()
                    Me.Cambia_Estado(enumEstados.NUEVO)
                    Me.GeneraFolio()
                    Me.txtFolio.Focus()
                End If
            End If
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

#End Region

End Class