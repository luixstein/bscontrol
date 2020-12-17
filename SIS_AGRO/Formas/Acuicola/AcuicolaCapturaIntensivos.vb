Public Class AcuicolaCapturaIntensivos

#Region "Campos privados"
    Private Enum enumEstados
        NUEVO
        GRABADO
        CANCELADO
    End Enum

    Private Estado As enumEstados

    Private oIntensivos As New Class_Acuicola_Intensivos_Global
    Private oDocumento As Class_CatDocumentos

    Private bDocumentosCargados As Boolean = False
#End Region

#Region "Columnas grid"
    Private iGyIdCapturaIntensivosDetalle As Integer = 1
    Private iGyIDProyectoSiembra As Integer = 2
    Private iGyCodigoLote As Integer = 3
    Private iGyNombreLote As Integer = 4
    Private iGyHora As Integer = 5
    Private iGyRacionAlimento As Integer = 6
    Private iGyCodigoTipoAlimento As Integer = 7
    Private iGyNombreTipoAlimento As Integer = 8
    Private iGyCanastas As Integer = 9
    Private iGyAlimentoEnSifon As Integer = 10
    Private iGyVivos As Integer = 11
    Private iGyMuertos As Integer = 12
    Private iGyLastimados As Integer = 13
    Private iGyOxigeno As Integer = 14
    Private iGyTemperatura As Integer = 15
    Private iGyPh As Integer = 16
    Private iGySal As Integer = 17
    Private iGyCalcio As Integer = 18
    Private iGyPotasio As Integer = 19
    Private iGyMagnesio As Integer = 20
    Private iGyNitritos As Integer = 21
    Private iGyAmonio As Integer = 22
    Private iGyAlcalinidad As Integer = 23
    
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

    Private Sub tsbCancelar_Click(sender As Object, e As EventArgs) Handles tsbCancelar.Click
        If Me.Cancelar() = True Then
            Me.Consultar()
        End If
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
    Private Sub AcuicolaCapturaIntensivos_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Me.DesplegarDivisiones()
            Me.DesplegarTemporadas()

            Me.Inicializa()
            Me.Cambia_Estado(enumEstados.NUEVO)

        Catch ex As Exception
            HandleError(Me.Name, "AcuicolaCapturaIntensivos_Load", ex)
        End Try
    End Sub

    Private Sub CboDocumento_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Me.oDocumento = New Class_CatDocumentos("INT_ACU" & Plaza.CODIGO_PLAZA.ToString)
            Me.Inicializa()
            Me.Cambia_Estado(enumEstados.NUEVO)
        Catch ex As Exception
            HandleError(Me.Name, "CboDocumento_SelectedIndexChanged", ex)
        End Try
    End Sub

    Private Sub txtCiclo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCiclo.KeyDown
        If e.KeyCode = Keys.Return Then
            If txtLEN(Me.txtCiclo.Text) = True AndAlso CInt(Me.txtCiclo.Text) > 0 AndAlso Me.cboDivision.SelectedIndex <> -1 Then
                Me.Grid.Locked = False
                Me.Grid.Cell(1, Me.iGyNombreLote).SetFocus()
            End If
        End If
    End Sub

    Private Sub txtFolio_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFolio.KeyDown
        Dim sText As String
        Select Case e.KeyCode
            Case Keys.F6
                sText = Me.oIntensivos.BusquedaVisual_PorFolio()
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
        Me.GestionaGrid(e)
    End Sub

    Private Sub Grid_MouseClick(sender As Object, e As MouseEventArgs) Handles Grid.MouseClick
        If Me.cboDivision.SelectedIndex = -1 Then
            MsgBox("Seleccione una división.", MsgBoxStyle.Exclamation, Me.Name)
            Me.cboDivision.Focus()
            Exit Sub
        End If

        If txtLEN(Me.txtCiclo.Text) = False Then
            MsgBox("Capture el ciclo.", MsgBoxStyle.Exclamation, Me.Name)
            Me.txtCiclo.Focus()
            Exit Sub
        End If

        If Me.lblEstatus.Text <> "C" Then Me.Grid.Locked = False

    End Sub

#Region "Eventos Genericos"
    Private Sub txt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtFecha.KeyDown, cboDivision.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtNumerosEnterosKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCiclo.KeyPress
        txtSoloNumerosEnteros(e)
        txtNoBeep(e)
    End Sub

    Private Sub txtTextoKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFolio.KeyPress, dtFecha.KeyPress
        txtNoBeep(e)
    End Sub
#End Region

#End Region

#Region "Métodos y procedimientos"
    Private Sub Inicializa()
        Try
            Me.txtFolio.Text = ""
            Me.dtFecha.Value = Date.Now
            Me.cboDivision.SelectedIndex = -1
            Me.txtCiclo.Text = ""
            Me.lblEstatus.Text = "N"
            Me.oDocumento = New Class_CatDocumentos("INT_ACU" & Plaza.CODIGO_PLAZA.ToString)

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
            Me.Grid.Cols = 24
            Me.Grid.DisplayRowNumber = True

            Me.FormateaGrid()
            Me.Grid.Locked = True
            Me.Grid.Cell(1, Me.iGyIdCapturaIntensivosDetalle).Text = "0"
        Catch ex As Exception
            HandleError(Me.Name, "InicializaGrid", ex)
        End Try
    End Sub

    Private Sub FormateaGrid()
        Try
            With Me.Grid
                .AutoRedraw = False
                .Cols = 24

                .Column(Me.iGyIdCapturaIntensivosDetalle).Width = 80
                .Column(Me.iGyIDProyectoSiembra).Width = 80
                .Column(Me.iGyCodigoLote).Width = 80
                .Column(Me.iGyNombreLote).Width = 80
                .Column(Me.iGyHora).Width = 65
                .Column(Me.iGyRacionAlimento).Width = 80
                .Column(Me.iGyCodigoTipoAlimento).Width = 50
                .Column(Me.iGyNombreTipoAlimento).Width = 220
                .Column(Me.iGyCanastas).Width = 110
                .Column(Me.iGyAlimentoEnSifon).Width = 70
                .Column(Me.iGyVivos).Width = 55
                .Column(Me.iGyMuertos).Width = 55
                .Column(Me.iGyLastimados).Width = 70
                .Column(Me.iGyOxigeno).Width = 60
                .Column(Me.iGyTemperatura).Width = 80
                .Column(Me.iGyPh).Width = 40
                .Column(Me.iGySal).Width = 40
                .Column(Me.iGyCalcio).Width = 40
                .Column(Me.iGyPotasio).Width = 40
                .Column(Me.iGyMagnesio).Width = 40
                .Column(Me.iGyNitritos).Width = 40
                .Column(Me.iGyAmonio).Width = 40
                .Column(Me.iGyAlcalinidad).Width = 60

                .Cell(0, Me.iGyIdCapturaIntensivosDetalle).Text = "IdCapturaIntensivosDetalle"
                .Cell(0, Me.iGyIDProyectoSiembra).Text = "IDProyectoSiembra"
                .Cell(0, Me.iGyCodigoLote).Text = "CódigoLote"
                .Cell(0, Me.iGyNombreLote).Text = "#Estanque"
                .Cell(0, Me.iGyHora).Text = "Hora"
                .Cell(0, Me.iGyRacionAlimento).Text = " Cant. alimento"
                .Cell(0, Me.iGyCodigoTipoAlimento).Text = "Codigo articulo"
                .Cell(0, Me.iGyNombreTipoAlimento).Text = "Tipo de alimento"
                .Cell(0, Me.iGyCanastas).Text = "Canastas"
                .Cell(0, Me.iGyAlimentoEnSifon).Text = "A. en sifoneo"
                .Cell(0, Me.iGyVivos).Text = "Vivos"
                .Cell(0, Me.iGyMuertos).Text = "Muertos"
                .Cell(0, Me.iGyLastimados).Text = "Lastimados"
                .Cell(0, Me.iGyOxigeno).Text = "Oxígeno"
                .Cell(0, Me.iGyTemperatura).Text = "Temperatura"
                .Cell(0, Me.iGyPh).Text = "PH"
                .Cell(0, Me.iGySal).Text = "Sal"
                .Cell(0, Me.iGyCalcio).Text = "Ca"
                .Cell(0, Me.iGyPotasio).Text = "K"
                .Cell(0, Me.iGyMagnesio).Text = "Mg"
                .Cell(0, Me.iGyNitritos).Text = "Nitritos"
                .Cell(0, Me.iGyAmonio).Text = "Amonio"
                .Cell(0, Me.iGyAlcalinidad).Text = "Alcalinidad"

                .Column(Me.iGyAlimentoEnSifon).CellType = FlexCell.CellTypeEnum.CheckBox

                .Column(Me.iGyHora).CellType = FlexCell.CellTypeEnum.Time

                .Column(Me.iGyIdCapturaIntensivosDetalle).Locked = True
                .Column(Me.iGyIDProyectoSiembra).Locked = True
                .Column(Me.iGyCodigoLote).Locked = True

                .Column(Me.iGyIdCapturaIntensivosDetalle).Visible = False
                .Column(Me.iGyIDProyectoSiembra).Visible = False
                .Column(Me.iGyCodigoLote).Visible = False
                .Column(Me.iGyCodigoTipoAlimento).Visible = False

                .Column(Me.iGyRacionAlimento).FormatString = "##0.00"
                .Column(Me.iGyRacionAlimento).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyRacionAlimento).DecimalLength = 2

                .Column(Me.iGyCanastas).Mask = FlexCell.MaskEnum.Digital
                .Column(Me.iGyCanastas).DecimalLength = 0

                .Column(Me.iGyVivos).FormatString = "##0"
                .Column(Me.iGyVivos).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyVivos).DecimalLength = 0

                .Column(Me.iGyMuertos).FormatString = "##0"
                .Column(Me.iGyMuertos).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyMuertos).DecimalLength = 0

                .Column(Me.iGyLastimados).FormatString = "##0"
                .Column(Me.iGyLastimados).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyLastimados).DecimalLength = 0

                .Column(Me.iGyOxigeno).FormatString = "##0.00"
                .Column(Me.iGyOxigeno).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyOxigeno).DecimalLength = 2
                .Column(Me.iGyOxigeno).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGyTemperatura).FormatString = "##0.00"
                .Column(Me.iGyTemperatura).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyTemperatura).DecimalLength = 2

                .Column(Me.iGyPh).FormatString = "##0.00"
                .Column(Me.iGyPh).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyPh).DecimalLength = 2

                .Column(Me.iGySal).FormatString = "##0.00"
                .Column(Me.iGySal).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGySal).DecimalLength = 2

                .Column(Me.iGyCalcio).FormatString = "##0.00"
                .Column(Me.iGyCalcio).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyCalcio).DecimalLength = 2

                .Column(Me.iGyPotasio).FormatString = "##0.00"
                .Column(Me.iGyPotasio).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyPotasio).DecimalLength = 2

                .Column(Me.iGyMagnesio).FormatString = "##0.00"
                .Column(Me.iGyMagnesio).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyMagnesio).DecimalLength = 2

                .Column(Me.iGyNitritos).FormatString = "##0.00"
                .Column(Me.iGyNitritos).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyNitritos).DecimalLength = 2

                .Column(Me.iGyAmonio).FormatString = "##0.00"
                .Column(Me.iGyAmonio).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyAmonio).DecimalLength = 2

                .Column(Me.iGyAlcalinidad).FormatString = "##0.00"
                .Column(Me.iGyAlcalinidad).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyAlcalinidad).DecimalLength = 2

                .Locked = False
                .AutoRedraw = True
                .Refresh()
            End With

        Catch ex As Exception
            HandleError(Me.Name, "FormateaGrid", ex)
        End Try
    End Sub

    Private Sub GeneraFolio()
        Try
            Me.oIntensivos.CODIGO_DOCUMENTO = ("INT_ACU" & Plaza.CODIGO_PLAZA.ToString) 'Me.cboDocumento.SelectedValue.ToString
            Me.txtFolio.Text = Me.oIntensivos.GeneraFolio

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
            Case "C"
                Me.Cambia_Estado(enumEstados.CANCELADO)
                'Case "A"
                '    Me.Cambia_Estado(enumEstados.APLICADO)

        End Select
    End Sub

    Private Sub Cambia_Estado(ByVal pEstado As enumEstados)
        Try

            Me.Estado = pEstado
            Select Case Me.Estado
                Case enumEstados.NUEVO

                    Me.tsbGrabar.Enabled = True
                    Me.tsbCancelar.Enabled = False
                    Me.cboDivision.Enabled = True
                    Me.txtCiclo.Enabled = True
                    Me.cboTemporada.Enabled = True

                    Me.tsslEstado.Text = "Estado: Agregando nuevo movimiento"
                    Me.tsslElaboro.Visible = False

                    If Me.Visible = True Then
                        Me.dtFecha.Focus()
                    End If

                Case enumEstados.GRABADO

                    Me.tsbGrabar.Enabled = True
                    Me.tsbCancelar.Enabled = True
                    Me.cboDivision.Enabled = False
                    Me.txtCiclo.Enabled = False
                    Me.cboTemporada.Enabled = False

                    Me.tsslEstado.Text = "Estado: Consultando movimiento"
                    Me.tsslElaboro.Visible = True

                Case enumEstados.CANCELADO

                    Me.tsbGrabar.Enabled = False
                    Me.tsbCancelar.Enabled = False
                    Me.cboDivision.Enabled = False
                    Me.txtCiclo.Enabled = False
                    Me.cboTemporada.SelectedValue = False
                    Me.Grid.Locked = True

                    Me.tsslEstado.Text = "Estado: Cancelado"
                    Me.tsslElaboro.Visible = True

            End Select

        Catch ex As Exception
            HandleError(Me.Name, "Cambia_Estado", ex)
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

    Private Sub DesplegarTemporadas()
        Dim oTemporada As New Class_NominaTemporada
        Try
            With Me.cboTemporada
                .DisplayMember = "NOMBRE_TEMPORADA"
                .ValueMember = "ID_NOMINA_TEMPORADA"
                Dim dView As New Data.DataView(oTemporada.ObtenerTemporadas)
                dView.Sort = "NOMBRE_TEMPORADA"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedValue = Plaza.oSisPlazaNomina.NOMINA_ID_NOMINA_TEMPORADA_ACTIVA
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarTemporadas", ex)
        End Try
    End Sub

    Private Function Consultar() As Boolean
        Dim bResultado As Boolean = False

        Dim sFolio As String = Me.txtFolio.Text

        Try
            Me.Inicializa()

            Me.oIntensivos = New Class_Acuicola_Intensivos_Global(sFolio)

            Me.txtFolio.Enabled = False

            If Me.oIntensivos.Existe = False Then
                Me.GeneraFolio()
                Me.Cambia_Estado(enumEstados.NUEVO)
                Return False
            End If

            With Me.oIntensivos
                Me.txtFolio.Text = .FOLIO_INTENSIVOS
                Me.dtFecha.Value = .FECHA
                Me.cboDivision.SelectedValue = .CODIGO_DIVISION.ToString
                Me.txtCiclo.Text = .CICLO.ToString
                Me.txtConcepto.Text = .CONCEPTO
                Me.lblEstatus.Text = .ESTATUS
                Me.cboTemporada.SelectedValue = .ID_NOMINA_TEMPORADA
                Me.tsslElaboro.Text = "Elaboró: " + .NOMBRE_USUARIO_GRABO.ToUpper + " el " + Format(.FECHA_SERVIDOR, "dd/MMM/yy hh:mm tt").ToUpper
            End With

            'LLENAR GRID
            Dim dTabla As DataTable = Me.oIntensivos.ObtenerDetalle
            Me.Grid.Rows = 1
            For Each dRow As DataRow In dTabla.Rows
                Me.Grid.AddItem(dRow("ID_ACUICOLA_INTENSIVOS_DETALLE").ToString & Chr(9) & dRow("ID_PROYECTO_SIEMBRA").ToString & Chr(9) & dRow("CODIGO_LOTE").ToString & Chr(9) & _
                                 dRow("NOMBRE_LOTE").ToString & Chr(9) & dRow("HORA").ToString & Chr(9) & dRow("RACION_ALIMENTO").ToString & Chr(9) & dRow("CODIGO_TIPO_ALIMENTO").ToString & Chr(9) & dRow("DESCRIPCION") & Chr(9) & _
                                 dRow("CANASTAS").ToString & Chr(9) & dRow("ALIMENTO_EN_SIFONEO").ToString & Chr(9) & dRow("VIVOS").ToString & Chr(9) & dRow("MUERTOS").ToString & Chr(9) & dRow("LASTIMADOS").ToString & Chr(9) & _
                                 dRow("OXIGENO").ToString & Chr(9) & dRow("TEMPERATURA").ToString & Chr(9) & dRow("PH").ToString & Chr(9) & dRow("SAL").ToString & Chr(9) & _
                                 dRow("CALCIO").ToString & Chr(9) & dRow("POTASIO").ToString & Chr(9) & dRow("MAGNESIO").ToString & Chr(9) & dRow("NITRITOS").ToString & Chr(9) & _
                                 dRow("AMONIO").ToString & Chr(9) & dRow("ALCALINIDAD").ToString & Chr(9))
            Next
            Me.FormateaGrid()
            Me.Grid.Rows = Me.Grid.Rows + 1
            Me.Grid.Cell(Me.Grid.Rows - 1, Me.iGyIdCapturaIntensivosDetalle).Text = "0"

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

            If lblEstatus.Text <> "G" Then
                Me.GeneraFolio()
            End If

            Me.oIntensivos = New Class_Acuicola_Intensivos_Global

            With Me.oIntensivos
                .FOLIO_INTENSIVOS = Me.txtFolio.Text
                .CODIGO_DOCUMENTO = Me.oDocumento.CODIGO_DOCUMENTO
                .CICLO = Me.txtCiclo.Text
                .CODIGO_DIVISION = CInt(Me.cboDivision.SelectedValue)
                .FECHA = Me.dtFecha.Value
                .CONCEPTO = Me.txtConcepto.Text.ToUpper.Trim
                .ID_NOMINA_TEMPORADA = Me.cboTemporada.SelectedValue

                If .GrabaAlimentacionGlobal(IIf(Me.Estado = enumEstados.NUEVO, "INSERTAR", "ACTUALIZAR").ToString) = False Then
                    MsgBox("Error al tratar de grabar los estanques intensivos.", MsgBoxStyle.Exclamation, Me.Name)
                    Return False
                End If

                Me.txtFolio.Text = .FOLIO_INTENSIVOS

                Dim i As Integer = 0

                For i = 1 To Me.Grid.Rows - 1
                    If Me.Grid.Cell(i, Me.iGyIdCapturaIntensivosDetalle).Text <> "0" Then
                        .NuevoRenglon()
                        .oDetalle.FOLIO_INTENSIVOS = Me.txtFolio.Text
                        .oDetalle.ID_ACUICOLA_INTENSIVOS_DETALLE = Me.Grid.Cell(i, Me.iGyIdCapturaIntensivosDetalle).Text
                        .oDetalle.ID_PROYECTO_SIEMBRA = Me.Grid.Cell(i, Me.iGyIDProyectoSiembra).Text
                        .oDetalle.CODIGO_LOTE = Me.Grid.Cell(i, Me.iGyCodigoLote).Text
                        .oDetalle.HORA = Me.Grid.Cell(i, Me.iGyHora).Text
                        .oDetalle.RACION_ALIMENTO = Me.Grid.Cell(i, Me.iGyRacionAlimento).Text
                        .oDetalle.CODIGO_TIPO_ALIMENTO = "" & Me.Grid.Cell(i, Me.iGyCodigoTipoAlimento).Text
                        .oDetalle.ALIMENTO_EN_SIFONEO = IIf(Me.Grid.Cell(i, Me.iGyAlimentoEnSifon).Text = "1", "1", "0")
                        .oDetalle.CANASTAS = Me.Grid.Cell(i, Me.iGyCanastas).Text
                        .oDetalle.VIVOS = Me.Grid.Cell(i, Me.iGyVivos).Text
                        .oDetalle.MUERTOS = Me.Grid.Cell(i, Me.iGyMuertos).Text
                        .oDetalle.LASTIMADOS = Me.Grid.Cell(i, Me.iGyLastimados).Text
                        .oDetalle.OXIGENO = Me.Grid.Cell(i, Me.iGyOxigeno).Text
                        .oDetalle.TEMPERATURA = Me.Grid.Cell(i, Me.iGyTemperatura).Text
                        .oDetalle.PH = Me.Grid.Cell(i, Me.iGyPh).Text
                        .oDetalle.SAL = Me.Grid.Cell(i, Me.iGySal).Text
                        .oDetalle.CALCIO = Me.Grid.Cell(i, Me.iGyCalcio).Text
                        .oDetalle.POTASIO = Me.Grid.Cell(i, Me.iGyPotasio).Text
                        .oDetalle.MAGNESIO = Me.Grid.Cell(i, Me.iGyMagnesio).Text
                        .oDetalle.NITRITOS = Me.Grid.Cell(i, Me.iGyNitritos).Text
                        .oDetalle.AMONIO = Me.Grid.Cell(i, Me.iGyAmonio).Text
                        .oDetalle.ALCALINIDAD = Me.Grid.Cell(i, Me.iGyAlcalinidad).Text

                        If .oDetalle.GrabaRenglon() = False Then
                            MsgBox("Error al tratar de grabar el detalle.", MsgBoxStyle.Exclamation, Me.Name)
                            Return False
                        End If

                    End If
                Next
            End With

            bResultado = True
            MsgBox("Estanques intensivos grabados satisfactoriamente.", MsgBoxStyle.Information, Me.Name)

        Catch ex As Exception
            HandleError(Me.Name, "Grabar", ex)
        End Try

        Return bResultado
    End Function

    Private Function Cancelar() As Boolean
        Dim bResultado As Boolean = False

        Try

            If MsgBox("Desea cancelar la captura de estanques intensivos " & Me.txtFolio.Text & " ?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, Me.Text) = MsgBoxResult.No Then
                Return False
            End If

            Select Case Me.Estado
                Case enumEstados.GRABADO
                    'Continua
                Case Else
                    MsgBox("Estatus no válido para cancelar.", MsgBoxStyle.Exclamation, Me.Name)
                    Return False
            End Select

            Me.oIntensivos = New Class_Acuicola_Intensivos_Global

            With Me.oIntensivos
                .FOLIO_INTENSIVOS = Me.txtFolio.Text
                .CODIGO_DOCUMENTO = "INT_ACU" & Plaza.CODIGO_PLAZA.ToString

                If .Cancelar() = False Then
                    MsgBox("Error al tratar de cancelar la captura de estanques intensivos.", MsgBoxStyle.Exclamation, Me.Name)
                    Return False
                End If

            End With

            bResultado = True
            MsgBox("Captura de estanques intensivos cancelada.", MsgBoxStyle.Information, Me.Name)

        Catch ex As Exception
            HandleError(Me.Name, "Cancelar", ex)
        End Try

        Return bResultado
    End Function

    Private Function Validar() As Boolean
        Dim dResultado As Boolean = False
        Const sProcedure As String = "Validar"
        Dim i As Integer

        Try

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

            If Me.Grid.Rows = 2 And Me.Grid.Cell(1, Me.iGyIdCapturaIntensivosDetalle).Text = "0" Then
                MsgBox("Capture el detalle de la captura de estanques intensivos.", MsgBoxStyle.Exclamation, Me.Name)
                Me.Grid.Cell(1, Me.iGyNombreLote).SetFocus()
                Return False
            End If

            Dim oParametroDetalle As Class_CatParametrosAcuicolaDetalle

            For i = 1 To Me.Grid.Rows - 1
                If Me.Grid.Cell(i, Me.iGyIdCapturaIntensivosDetalle).Text <> "0" Then

                    If txtLEN(Me.Grid.Cell(i, Me.iGyHora).Text) = False Then
                        MsgBox("Capture la hora del renglón " & i.ToString & ".", MsgBoxStyle.Exclamation, Me.Name)
                        Me.Grid.Cell(i, Me.iGyRacionAlimento).SetFocus()
                        Return False
                    End If

                    If txtLEN(Me.Grid.Cell(i, Me.iGyRacionAlimento).Text) = False Then
                        MsgBox("Capture el cantidad de alimento del renglón " & i.ToString & ".", MsgBoxStyle.Exclamation, Me.Name)
                        Me.Grid.Cell(i, Me.iGyRacionAlimento).SetFocus()
                        Return False
                    End If

                    If txtLEN(Me.Grid.Cell(i, Me.iGyCanastas).Text) = False Then
                        MsgBox("Capture las canastas del renglón " & i.ToString & ".", MsgBoxStyle.Exclamation, Me.Name)
                        Me.Grid.Cell(i, Me.iGyCanastas).SetFocus()
                        Return False
                    End If

                    oParametroDetalle = New Class_CatParametrosAcuicolaDetalle(Me.cboDivision.SelectedValue, Me.Grid.Cell(i, Me.iGyCodigoLote).Text)

                    If oParametroDetalle.Existe = True Then
                        If Len(Me.Grid.Cell(i, Me.iGyCanastas).Text) <> oParametroDetalle.Numero_Canastas Then
                            MsgBox("Las canastas permitidas para el estanque #" & Me.Grid.Cell(i, Me.iGyNombreLote).Text & " debe ser " & oParametroDetalle.Numero_Canastas, MsgBoxStyle.Exclamation, Me.Name)
                            Me.Grid.Cell(i, Me.iGyCanastas).SetFocus()
                            Return False
                        End If
                    Else
                        MsgBox("Las canastas para el estanque #" & Me.Grid.Cell(i, Me.iGyNombreLote).Text & " de la división " & Me.cboDivision.Text & " no han sido definidas en el catalogo.", MsgBoxStyle.Exclamation, Me.Name)
                        Return False
                    End If

                    If txtLEN(Me.Grid.Cell(i, Me.iGyVivos).Text) = False Then
                        MsgBox("Capture los vivos del renglón " & i.ToString & ".", MsgBoxStyle.Exclamation, Me.Name)
                        Me.Grid.Cell(i, Me.iGyVivos).SetFocus()
                        Return False
                    End If

                    If txtLEN(Me.Grid.Cell(i, Me.iGyMuertos).Text) = False Then
                        MsgBox("Capture los muertos del renglón " & i.ToString & ".", MsgBoxStyle.Exclamation, Me.Name)
                        Me.Grid.Cell(i, Me.iGyMuertos).SetFocus()
                        Return False
                    End If

                    If txtLEN(Me.Grid.Cell(i, Me.iGyLastimados).Text) = False Then
                        MsgBox("Capture los lastimados del renglón " & i.ToString & ".", MsgBoxStyle.Exclamation, Me.Name)
                        Me.Grid.Cell(i, Me.iGyLastimados).SetFocus()
                        Return False
                    End If

                    If txtLEN(Me.Grid.Cell(i, Me.iGyOxigeno).Text) = False Then
                        MsgBox("Capture el oxígeno del renglón " & i.ToString & ".", MsgBoxStyle.Exclamation, Me.Name)
                        Me.Grid.Cell(i, Me.iGyOxigeno).SetFocus()
                        Return False
                    End If

                    If txtLEN(Me.Grid.Cell(i, Me.iGyTemperatura).Text) = False Then
                        MsgBox("Capture la temperatura del renglón " & i.ToString & ".", MsgBoxStyle.Exclamation, Me.Name)
                        Me.Grid.Cell(i, Me.iGyOxigeno).SetFocus()
                        Return False
                    End If

                    If txtLEN(Me.Grid.Cell(i, Me.iGyPh).Text) = False Then
                        MsgBox("Capture el pH del renglón " & i.ToString & ".", MsgBoxStyle.Exclamation, Me.Name)
                        Me.Grid.Cell(i, Me.iGyPh).SetFocus()
                        Return False
                    End If

                    If valorNumerico(Me.Grid.Cell(i, Me.iGyPh).Text) < 0 Or valorNumerico(Me.Grid.Cell(i, Me.iGyPh).Text) > 14 Then
                        MsgBox("El pH del renglón " & i.ToString & " debe estar un rango de 0 a 14.", MsgBoxStyle.Exclamation, Me.Text)
                        Me.Grid.Cell(i, Me.iGyPh).SetFocus()
                        Return False
                    End If

                    If txtLEN(Me.Grid.Cell(i, Me.iGySal).Text) = False Then
                        MsgBox("Capture la sal del renglón " & i.ToString & ".", MsgBoxStyle.Exclamation, Me.Name)
                        Me.Grid.Cell(i, Me.iGySal).SetFocus()
                        Return False
                    End If

                    If txtLEN(Me.Grid.Cell(i, Me.iGyLastimados).Text) = False Then
                        MsgBox("Capture el calcio del renglón " & i.ToString & ".", MsgBoxStyle.Exclamation, Me.Name)
                        Me.Grid.Cell(i, Me.iGyCalcio).SetFocus()
                        Return False
                    End If

                    If txtLEN(Me.Grid.Cell(i, Me.iGyLastimados).Text) = False Then
                        MsgBox("Capture el potasio del renglón " & i.ToString & ".", MsgBoxStyle.Exclamation, Me.Name)
                        Me.Grid.Cell(i, Me.iGyPotasio).SetFocus()
                        Return False
                    End If

                    If txtLEN(Me.Grid.Cell(i, Me.iGyLastimados).Text) = False Then
                        MsgBox("Capture el magnesio del renglón " & i.ToString & ".", MsgBoxStyle.Exclamation, Me.Name)
                        Me.Grid.Cell(i, Me.iGyMagnesio).SetFocus()
                        Return False
                    End If

                    If txtLEN(Me.Grid.Cell(i, Me.iGyLastimados).Text) = False Then
                        MsgBox("Capture los nitritos del renglón " & i.ToString & ".", MsgBoxStyle.Exclamation, Me.Name)
                        Me.Grid.Cell(i, Me.iGyNitritos).SetFocus()
                        Return False
                    End If

                    If txtLEN(Me.Grid.Cell(i, Me.iGyLastimados).Text) = False Then
                        MsgBox("Capture el amonio del renglón " & i.ToString & ".", MsgBoxStyle.Exclamation, Me.Name)
                        Me.Grid.Cell(i, Me.iGyAmonio).SetFocus()
                        Return False
                    End If

                    If txtLEN(Me.Grid.Cell(i, Me.iGyLastimados).Text) = False Then
                        MsgBox("Capture la alcalinidad del renglón " & i.ToString & ".", MsgBoxStyle.Exclamation, Me.Name)
                        Me.Grid.Cell(i, Me.iGyAlcalinidad).SetFocus()
                        Return False
                    End If
                End If
            Next

            dResultado = True

        Catch ex As Exception
            HandleError(Me.Name, "Validar", ex)
        End Try

        Return dResultado
    End Function

    Private Sub GestionaGrid(ByVal e As System.Windows.Forms.KeyEventArgs)
        Dim sProcedure As String = "GestionaGrid"
        Try

            Dim sql As Class_find
            Dim oArticulo As New Class_CatArticulos
            Dim Columna As Integer, Renglon As Integer, sCodigo As String

            Columna = Me.Grid.Selection.FirstCol
            Renglon = Me.Grid.Selection.FirstRow

            Select Case e.KeyCode
                Case Keys.Enter
                    Select Case Columna
                        Case Me.iGyNombreLote
                            If txtLEN(Me.Grid.Cell(Renglon, Me.iGyNombreLote).Text) = False Or txtLEN(Me.Grid.Cell(Renglon, Me.iGyIDProyectoSiembra).Text) = False Then
                                GoTo Busqueda
                            End If

                        Case Me.iGyAlcalinidad

                            If Me.Grid.Rows - 1 = Renglon Then
                                Me.Grid.Rows = Me.Grid.Rows + 1
                                Me.Grid.Cell(Renglon + 1, Me.iGyIdCapturaIntensivosDetalle).Text = "0"
                            End If

                    End Select

                Case Keys.F6
                    Select Case Columna
                        Case Me.iGyNombreLote

Busqueda:
                            sCodigo = oIntensivos.BusquedaVisual_Lote_ProyectoSiembra_PorNombre(Me.cboDivision.SelectedValue.ToString, Me.txtCiclo.Text, Me.cboTemporada.SelectedValue.ToString)
                            Me.Grid.Cell(Renglon, Me.iGyIDProyectoSiembra).Text = sCodigo

                            For i = Renglon + 1 To Me.Grid.Rows - 1
                                If Me.Grid.Cell(i, Me.iGyIDProyectoSiembra).Text = sCodigo Then
                                    MsgBox("El estanque #" & Me.Grid.Cell(i, Me.iGyNombreLote).Text & " ya se encuentra capturado en el renglón " & i.ToString & ".", MsgBoxStyle.Exclamation, Me.Name)
                                    Me.Grid.Cell(Renglon, Me.iGyIDProyectoSiembra).Text = ""
                                    Me.Grid.Cell(Renglon, Me.iGyCodigoLote).SetFocus()
                                    Exit Sub
                                End If
                            Next

                            sql = New Class_find("SELECT P.CODIGO_LOTE,L.NOMBRE_LOTE FROM PROYECTO_SIEMBRA_ACUICOLA P INNER JOIN CAT_LOTES L ON(P.CODIGO_LOTE=L.CODIGO_LOTE) WHERE P.ID_PROYECTO_SIEMBRA =" & sCodigo)
                            Me.Grid.Cell(Renglon, Me.iGyCodigoLote).Text = sql.Result1
                            Me.Grid.Cell(Renglon, Me.iGyNombreLote).Text = sql.Result2

                            If Me.Grid.Rows > 2 Then
                                Me.Grid.Cell(Renglon, Me.iGyIdCapturaIntensivosDetalle).Text = CInt(Me.Grid.Cell(Renglon - 1, Me.iGyIdCapturaIntensivosDetalle).Text) + 1
                            Else
                                Me.Grid.Cell(Renglon, Me.iGyIdCapturaIntensivosDetalle).Text = CInt(Me.Grid.Cell(Renglon, Me.iGyIdCapturaIntensivosDetalle).Text) + 1
                            End If

                        Case Me.iGyNombreTipoAlimento
BusquedaArticulo:

                            sCodigo = oArticulo.BusquedaVisual_PorDescripcion
                            Me.Grid.Cell(Renglon, Me.iGyCodigoTipoAlimento).Text = sCodigo

                            oArticulo = New Class_CatArticulos(Me.Grid.Cell(Renglon, Me.iGyCodigoTipoAlimento).Text)

                            If oArticulo.Existe Then
                                Me.Grid.Cell(Renglon, Me.iGyNombreTipoAlimento).Text = oArticulo.DESCRIPCION
                            End If


                    End Select

                Case Keys.F8, Keys.Delete
                    Me.Grid.Selection.DeleteByRow()

            End Select


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

