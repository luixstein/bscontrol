Public Class AcuicolaCapturaParametrosDetalle

#Region "Campos privados"
    Private Enum enumEstados
        NUEVO
        GRABADO
    End Enum

    Private Estado As enumEstados

    Private oParametros As New Class_Acuicola_Parametros_Global
    Private oDocumento As Class_CatDocumentos

    Private bDocumentosCargados As Boolean = False
#End Region

#Region "Columnas grid"
    Private iGyIdCapturaParametroDetalle As Integer = 1
    Private iGyIDProyectoSiembra As Integer = 2
    Private iGyCodigoLote As Integer = 3
    Private iGyNombreLote As Integer = 4
    Private iGyOxigeno As Integer = 5
    Private iGyTemperatura As Integer = 6
#End Region

#Region "Opciones"
    Private Sub tsbNuevo_Click(sender As Object, e As EventArgs) Handles tsbNuevo.Click
        Me.Inicializa()
        Me.Cambia_Estado(enumEstados.NUEVO)
    End Sub

    Private Sub tsbGrabar_Click(sender As Object, e As EventArgs) Handles tsbGrabar.Click
        If Me.Grabar = True Then
            Me.Consultar()
        End If
    End Sub

    Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
        'FALTA
    End Sub

    Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub

    Private Sub btnFolioAnterior_Click(sender As Object, e As EventArgs) Handles btnFolioAnterior.Click
        Me.Navegador("Anterior")
    End Sub

    Private Sub btnFolioSiguiente_Click(sender As Object, e As EventArgs) Handles btnFolioSiguiente.Click
        Me.Navegador("Siguiente")
    End Sub
#End Region

#Region "Eventos de objetos"
    Private Sub AcuicolaCapturaParametrosDetalle_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Me.DesplegarTurnos()
            Me.DesplegarDivisiones()

            Me.Inicializa()
            Me.Cambia_Estado(enumEstados.NUEVO)

        Catch ex As Exception
            HandleError(Me.Name, "AcuicolaCapturaParametrosDetalle_Load", ex)
        End Try
    End Sub

    Private Sub CboDocumento_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            'Me.oDocumento = New Class_CatDocumentos(Me.cboDocumento.SelectedValue.ToString)
            Me.oDocumento = New Class_CatDocumentos("PAR_ACU" & Plaza.CODIGO_PLAZA.ToString)
            Me.Inicializa()
            Me.Cambia_Estado(enumEstados.NUEVO)
        Catch ex As Exception
            HandleError(Me.Name, "CboDocumento_SelectedIndexChanged", ex)
        End Try
    End Sub

    Private Sub txtCiclo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCiclo.KeyDown
        If e.KeyCode = Keys.Return Then
            If txtLEN(Me.txtCiclo.Text) > 0 Then
                Me.Grid.Focus()
            End If
        End If
    End Sub

    Private Sub txtFolio_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFolio.KeyDown
        Dim sText As String
        Select Case e.KeyCode
            Case Keys.F6
                sText = Me.oParametros.BusquedaVisual_PorFolio()
                If txtLEN(sText) = True Then
                    Me.txtFolio.Text = sText
                    Me.Consultar()
                End If
            Case Keys.Return
                If txtLEN(Me.txtFolio.Text) = True Then
                    Me.Consultar()
                Else
                    Me.GeneraFolio()
                End If
        End Select
    End Sub

    Private Sub Grid_KeyDown(Sender As Object, e As KeyEventArgs) Handles Grid.KeyDown
        'Que el f6 de lotes(estanques) sólo cargue los del plan según la división y ciclo, y año
        Me.GestionaGrid(e)
    End Sub

#Region "Eventos Genericos"
    Private Sub txt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtFecha.KeyDown, cboTurno.KeyDown, cboDivision.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtNumerosEnterosKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCiclo.KeyPress
        txtSoloNumerosEnteros(e)
        txtNoBeep(e)
    End Sub

    Private Sub txtTextoKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFolio.KeyPress
        txtNoBeep(e)
    End Sub
#End Region

#End Region

#Region "Métodos y procedimientos"
    Private Sub Inicializa()
        Try
            Me.txtFolio.Text = ""
            Me.dtFecha.Value = Date.Now
            Me.cboTurno.SelectedIndex = 0
            Me.cboDivision.SelectedIndex = -1
            Me.txtCiclo.Text = ""
            Me.lblEstatus.Text = "N"

            Me.InicializaGrid()

            Me.tsslElaboro.Text = ""

            Me.GeneraFolio()
        Catch ex As Exception
            HandleError(Me.Name, "Inicializa", ex)
        End Try
    End Sub

    Private Sub InicializaGrid()
        Try
            Me.Grid.DataSource = Nothing
            FG_Grid_Limpiar(Grid)

            'Creamos el Grid
            Me.Grid.Rows = 2
            Me.Grid.Cols = 7
            Me.Grid.DisplayRowNumber = True

            Me.FormateaGrid()
        Catch ex As Exception
            HandleError(Me.Name, "InicializaGrid", ex)
        End Try
    End Sub

    Private Sub FormateaGrid()
        Try
            With Me.Grid
                .Column(Me.iGyIdCapturaParametroDetalle).Width = 80
                .Column(Me.iGyIDProyectoSiembra).Width = 80
                .Column(Me.iGyCodigoLote).Width = 80
                .Column(Me.iGyNombreLote).Width = 80
                .Column(Me.iGyOxigeno).Width = 80
                .Column(Me.iGyTemperatura).Width = 80

                .Cell(0, Me.iGyIdCapturaParametroDetalle).Text = "IdCapturaParametroDetalle"
                .Cell(0, Me.iGyIDProyectoSiembra).Text = "IDProyectoSiembra"
                .Cell(0, Me.iGyCodigoLote).Text = "CódigoLote"
                .Cell(0, Me.iGyNombreLote).Text = "#Estanque"
                .Cell(0, Me.iGyOxigeno).Text = "Oxígeno"
                .Cell(0, Me.iGyTemperatura).Text = "Temperatura"

                .Column(Me.iGyIdCapturaParametroDetalle).Locked = True
                .Column(Me.iGyIDProyectoSiembra).Locked = True
                .Column(Me.iGyCodigoLote).Locked = True

                .Column(Me.iGyIdCapturaParametroDetalle).Visible = False
                .Column(Me.iGyIDProyectoSiembra).Visible = False
                .Column(Me.iGyCodigoLote).Visible = False

                .Column(Me.iGyOxigeno).FormatString = "##0.00"
                .Column(Me.iGyOxigeno).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyOxigeno).DecimalLength = 2
                .Column(Me.iGyOxigeno).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGyTemperatura).FormatString = "##0.00"
                .Column(Me.iGyTemperatura).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyTemperatura).DecimalLength = 2

                .Locked = True
                .Refresh()
            End With

        Catch ex As Exception
            HandleError(Me.Name, "FormateaGrid", ex)
        End Try
    End Sub

    Private Sub GeneraFolio()
        Try
            'If Me.bDocumentosCargados = True Then
            Me.oParametros.CODIGO_DOCUMENTO = ("PAR_ACU" & Plaza.CODIGO_PLAZA.ToString) 'Me.cboDocumento.SelectedValue.ToString
            Me.txtFolio.Text = Me.oParametros.GeneraFolio
            'End If
        Catch ex As Exception
            HandleError(Me.Name, "GeneraFolio", ex)
        End Try
    End Sub

    Private Sub GestionaCambioEstado()
        Select Case Me.lblEstatus.Text
            Case "N"
                Me.Cambia_Estado(enumEstados.NUEVO)
            Case "G"
                Me.Cambia_Estado(enumEstados.GRABADO)
                'Case "A"
                '    Me.Cambia_Estado(enumEstados.APLICADO)
                'Case "C"
                '    Me.Cambia_Estado(enumEstados.CANCELADO)
        End Select
    End Sub

    Private Sub Cambia_Estado(ByVal pEstado As enumEstados)
        Try

            Me.Estado = pEstado
            Select Case Me.Estado
                Case enumEstados.NUEVO

                    Me.cboDivision.Enabled = True
                    Me.txtCiclo.Enabled = True

                    Me.tsslEstado.Text = "Estado: Agregando nuevo movimiento"
                    Me.tsslElaboro.Visible = False

                    If Me.Visible = True Then
                        Me.dtFecha.Focus()
                    End If

                Case enumEstados.GRABADO

                    Me.cboDivision.Enabled = False
                    Me.txtCiclo.Enabled = False

                    Me.tsslEstado.Text = "Estado: Consultando movimiento"
                    Me.tsslElaboro.Visible = True

            End Select

        Catch ex As Exception
            HandleError(Me.Name, "Cambia_Estado", ex)
        End Try
    End Sub

    'Private Sub DesplegarDocumentos()
    '    Try
    '        Dim oElementos As New Class_CatDocumentos
    '        With Me.cboDocumento
    '            .DisplayMember = "NOMBRE_TIPO_DOCUMENTO"
    '            .ValueMember = "CODIGO_DOCUMENTO"
    '            Dim dView As New Data.DataView(oElementos.ObtenerCodigosDocumentos("ACU", Usuario.Codigo_Plaza.ToString, " ESTATUS_DOCUMENTO='A'"))
    '            dView.Sort = "NOMBRE_TIPO_DOCUMENTO"
    '            .DataSource = dView
    '            If dView.Count > 0 Then
    '                .SelectedIndex = 0
    '                Me.bDocumentosCargados = True
    '            End If
    '        End With
    '    Catch ex As Exception
    '        HandleError(Me.Name, "DesplegarDocumentos", ex)
    '    End Try
    'End Sub

    Private Sub DesplegarTurnos()
        Try
            Me.cboTurno.Items.Clear()
            Me.cboTurno.Items.Add("M-Mañana")
            Me.cboTurno.Items.Add("T-Tarde")
            Me.cboTurno.Items.Add("N-Noche")
            Me.cboTurno.SelectedIndex = 0
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarTurnos", ex)
        End Try
    End Sub

    Private Sub DesplegarDivisiones()
        Dim oDivisiones As New Class_CatDivisionesAcuicola
        Try
            With Me.cboDivision
                .DisplayMember = "NOMBRE_DIVISION"
                .ValueMember = "CODIGO_DIVISION"
                Dim dView As New Data.DataView(oDivisiones.ObtenerElementosActivos)
                dView.Sort = "NOMBRE_DIVISION"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedIndex = -1
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarDivisiones", ex)
        End Try
    End Sub

    Private Function Consultar() As Boolean
        Dim bResultado As Boolean = False

        Dim sFolio As String = Me.txtFolio.Text

        Try
            Me.Inicializa()

            Me.oParametros = New Class_Acuicola_Parametros_Global(sFolio)

            Me.txtFolio.Enabled = False

            If Me.oParametros.Existe = False Then
                Me.GeneraFolio()
                Me.Cambia_Estado(enumEstados.NUEVO)
                Return False
            End If

            With Me.oParametros
                Me.dtFecha.Value = .FECHA
                MsgBox("FALTA llenar turno")
                'Me.cboTurno.Text =
                Me.cboDivision.SelectedValue = .CODIGO_DIVISION.ToString
                Me.txtCiclo.Text = .CICLO.ToString
                Me.txtConcepto.Text = .CONCEPTO
                Me.lblEstatus.Text = .ESTATUS

                'LLENAR GRID
                Me.Grid.DataSource = Me.oParametros.ObtenerDetalle

                Me.tsslElaboro.Text = "Elaboró: " + .NOMBRE_USUARIO_GRABO.ToUpper + " el " + Format(.FECHA_SERVIDOR, "dd/MMM/yy hh:mm tt").ToUpper
            End With

            Me.FormateaGrid()

            bResultado = True

            Me.GestionaCambioEstado()

        Catch ex As Exception
            HandleError(Me.Name, "Consultar", ex)
        End Try

        Return bResultado
    End Function

    Private Function Grabar() As Boolean
        Dim bResultado As Boolean = False

        Try
            Select Case Me.Estado
                Case enumEstados.NUEVO, enumEstados.GRABADO
                    'Continua
                Case Else
                    MsgBox("Estatus no válido para grabar.", MsgBoxStyle.Exclamation, Me.Name)
                    Return False
            End Select

            If Me.Validar = False Then
                Return False
            End If

            Me.GeneraFolio()

            Me.oParametros = New Class_Acuicola_Parametros_Global

            With Me.oParametros
                .FOLIO_PARAMETROS = Me.txtFolio.Text
                .CODIGO_DOCUMENTO = Me.oDocumento.CODIGO_DOCUMENTO
                .CICLO = Me.txtCiclo.Text
                .CODIGO_DIVISION = CInt(Me.cboDivision.SelectedValue)
                .FECHA = Me.dtFecha.Value
                .CONCEPTO = Me.txtConcepto.Text.ToUpper.Trim
                .TURNO = Me.cboTurno.Text.Substring(0, 1)

                If .GrabaParametrosGlobal(IIf(Me.Estado = enumEstados.NUEVO, "INSERTAR", "ACTUALIZAR").ToString) Then
                    Return False
                End If

                Me.txtFolio.Text = .FOLIO_PARAMETROS

                Dim i As Integer = 0

                For i = 1 To Me.Grid.Rows - 1
                    .NuevoRenglon()

                    .oDetalle.FOLIO_PARAMETROS = Me.txtFolio.Text

                Next

                MsgBox("FALTA GRABAR DETALLE GRID")
            End With

            bResultado = True

        Catch ex As Exception
            HandleError(Me.Name, "Grabar", ex)
        End Try

        Return bResultado
    End Function

    Private Function Validar() As Boolean
        Dim dResultado As Boolean = False
        Const sProcedure As String = "Validar"

        Try
            If Me.cboTurno.SelectedIndex = -1 Then
                MsgBox("Seleccione el turno.", vbExclamation, sProcedure)
                If Me.cboTurno.Enabled = True Then
                    Me.cboTurno.Focus()
                End If
                Return False
            End If

            If Me.cboDivision.SelectedIndex = -1 Then
                MsgBox("Seleccione la división.", vbExclamation, sProcedure)
                If Me.cboDivision.Enabled = True Then
                    Me.cboDivision.Focus()
                End If
                Return False
            End If

            If txtLEN(Me.txtCiclo.Text) = 0 Then
                MsgBox("Capture el ciclo.", vbExclamation, sProcedure)
                If Me.txtCiclo.Enabled = True Then
                    Me.txtCiclo.Focus()
                End If
                Return False
            End If

            MsgBox("FALTA validar que haya renglones(que haya al menos un renglón con datos.)")

            dResultado = True

        Catch ex As Exception
            HandleError(Me.Name, "Validar", ex)
        End Try

        Return dResultado
    End Function

    Private Sub GestionaGrid(ByVal e As System.Windows.Forms.KeyEventArgs)
        Dim sProcedure As String = "GestionaGrid"
        Try
            MsgBox("FALTA gestionar grid, f6 que busque lote en proyecot de siembra donde exista la divisoón")

            Dim Columna As Integer, Renglon As Integer, dCantidad As Decimal

            Columna = Me.Grid.Selection.FirstCol
            Renglon = Me.Grid.Selection.FirstRow
            '            dCantidad = CDec(valorNumerico(Me.Grid.Cell(Renglon, Me.igyCantidad).Text))

            '            Select Case e.KeyCode
            '                Case Keys.Enter
            '                    Select Case Columna
            '                        Case Me.igyCantidad
            '                            If dCantidad <= 0 Then
            '                                Me.Grid.Cell(Renglon, Me.igyCantidad).Text = "0"
            '                                Me.Grid.Refresh()
            '                                'MsgBox("La cantidad debe de ser mayor a 0.", MsgBoxStyle.Exclamation, sProcedure)
            '                                Me.Grid.Cell(Renglon, Me.igyDescripcion).SetFocus()
            '                                GoTo Sigue
            '                            End If
            '                            If Me.ValidarDisponible(Renglon) = False Then
            '                                Me.Grid.Cell(Renglon, Me.igyCantidad).Text = "0"
            '                                Me.Grid.Refresh() 'Si no se pone , no se refresca el 0 de inmediato, hasta que se mueva el foco al parecer.
            '                                Me.Grid.Cell(Renglon, Me.igyDescripcion).SetFocus()
            '                                GoTo Sigue
            '                            End If
            '                    End Select
            'Sigue:
            '                    Me.Totales()

            '                Case Keys.F6
            '                    'FALTA

            '            End Select

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Sub Navegador(ByVal sTipoDeBusqueda As String)
        Try
            Dim iFolio As Integer, sFolio As String
            If txtLEN(Me.txtFolio.Text) = False Then
                Me.txtFolio.Text = Me.oDocumento.GeneraFolio
            End If

            If sTipoDeBusqueda = "Anterior" Then
                sFolio = Me.txtFolio.Text.Substring(0, Me.txtFolio.Text.IndexOf("-"))
                iFolio = CInt(Strings.Right(Me.txtFolio.Text, Len(Me.txtFolio.Text) - (Len(sFolio) + 1))) ' Me.oVenta.FOLIO_NUMERICO
                iFolio = iFolio - 1
                sFolio = sFolio + "-" + iFolio.ToString

                Me.txtFolio.Text = sFolio

                If iFolio > 0 Then
                    Me.Consultar()
                Else
                    Me.Inicializa()
                    Me.Cambia_Estado(enumEstados.NUEVO)
                End If

            ElseIf sTipoDeBusqueda = "Siguiente" Then
                sFolio = Me.txtFolio.Text.Substring(0, Me.txtFolio.Text.IndexOf("-"))
                iFolio = CInt(Strings.Right(Me.txtFolio.Text, Len(Me.txtFolio.Text) - (Len(sFolio) + 1)))
                iFolio = iFolio + 1
                sFolio = sFolio + "-" + iFolio.ToString

                Me.txtFolio.Text = sFolio

                If iFolio > 0 Then
                    Me.Consultar()
                End If
            End If

        Catch ex As Exception
            HandleError(Me.Name, "NavegadorNotas", ex)
        End Try
    End Sub
#End Region

End Class

