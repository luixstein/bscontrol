Option Strict On

Public Class Frm_Nomina_Deducciones
    Private _ChildParaGrabar As Boolean
    Private _FormaValidaParaGrabarLlamadoExterior As Boolean = False
    Private _NumeroSemana As Integer
    Private _ID_NOMINA_PERCEPCION As Integer = 0
    Private _ID_DEDUCCION As Integer = 0

    'Private oHoja As New Class_NominaHoja
    Private oDeducciones As New Class_NominaDeduccionesGlobal

    Private Estado As enumEstados

#Region "Columnas grid plan abonos"
    Private igyIdDeduccionDetalle As Short = 1
    Private igySemana As Short = 2
    Private igyDescuento As Short = 3
    Private igySaldo As Short = 4
    Private igyAbonado As Short = 5
    Private igyTemporada As Short = 6
#End Region

#Region "Columnas grid historial"
    Private igyHistorialIdDeduccion As Short = 1
    Private igyHistorialSemana As Short = 2
    Private igyHistorialFecha As Short = 3
    Private igyHistorialImporte As Short = 4
    Private igyHistorialSaldo As Short = 5
#End Region

#Region "Columnas grid trabajadores"
    Private igyCodigoTrabajador As Short = 1
    Private igyNombreTrabajador As Short = 2
    Private igyDeduccion As Short = 3
    Private igyImporteTrabajador As Short = 4
    Private igySaldoTrabajador As Short = 5
#End Region

    Private clicGrid As Boolean = False

    Private Enum enumEstados
        NUEVO
        GRABADO
        GENERADO
    End Enum

#Region "Propiedades"
    Public WriteOnly Property ID_NOMINA_PERCEPCION() As Integer
        Set(ByVal Value As Integer)
            Me._ID_NOMINA_PERCEPCION = Value
        End Set
    End Property
    Public WriteOnly Property ChildParaGrabar() As Boolean
        Set(ByVal Value As Boolean)
            Me._ChildParaGrabar = Value
        End Set
    End Property
    Public WriteOnly Property NumeroSemana() As Integer
        Set(ByVal Value As Integer)
            Me._NumeroSemana = Value
        End Set
    End Property
    Public ReadOnly Property FormaValidaParaGrabarLlamadoExterior() As Boolean
        Get
            Return Me._FormaValidaParaGrabarLlamadoExterior
        End Get
    End Property
    Public WriteOnly Property ID_DEDUCCION() As Integer
        Set(ByVal Value As Integer)
            Me._ID_DEDUCCION = Value
        End Set
    End Property
#End Region

#Region "Opciones"
    Private Sub tsbNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbNuevo.Click
        Me.Cambia_Estado(enumEstados.NUEVO)
        Me.Inicializa()
        Me.txtCodigoTrabajador.Focus()
    End Sub

    Private Sub tsbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGrabar.Click
        If Me._ChildParaGrabar = True Then
            If Me.ValidarDeduccion() = False Then
                Exit Sub
            End If
            Me._FormaValidaParaGrabarLlamadoExterior = True
            Me.Visible = False
        Else
            If Me.Grabar() = True Then
                Me.ConsultarTrabajador()
                Me.GridHistorialDeducciones.Cell(1, Me.igyHistorialSemana).SetFocus()
            End If
        End If
    End Sub

    Private Sub tsbEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbEliminar.Click
        If Me.Eliminar() = True Then
            Me.ConsultarTrabajador()
        End If
    End Sub

    Private Sub tsbAplicar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSaldar.Click
        If Me.SaldarPrestamo() = True Then
            Me.ConsultarTrabajador()
        End If
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub
#End Region

#Region "Eventos de objetos"
#Region "Eventos"

    Private Sub Frm_Nomina_Deducciones_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Me._ChildParaGrabar = True Then
            Me.inicializaChild()
            If txtLEN(Me._ID_DEDUCCION.ToString) = True And Me._ID_DEDUCCION.ToString <> "0" Then
                Me.Cambia_Estado(enumEstados.GRABADO)
            Else
                Me.ObentenIdSemana()
                Me.LlenaFechasSemana(Plaza.oSisPlazaNomina.NOMINA_ID_NOMINA_TEMPORADA_ACTIVA)
            End If

            'And Me._ID_NOMINA_PERCEPCION.ToString <> "0" Then
            'Me.Consultar(Me._ID_DEDUCCION)
            'Me.ConsultarTrabajador()
            'End If
            Me.GroupBox1.Visible = False
            Me.Size = New Size(612, 712)

        Else
            'Me.DesplegarSemanas()
            If Me._ChildParaGrabar = True Then
                Me.DesplegarTipoDeduccion(True)
            Else
                Me.DesplegarTipoDeduccion(False)
            End If

            Me.Inicializa()
            Me.InicializaGridTrabajadores()
            Me.GroupBox1.Visible = True
            Me.DesplegarDeducciones()
            Me.Cambia_Estado(enumEstados.NUEVO)

            If Usuario.Nombre_Usuario = "DBO" Then
                Me.btnExtenderTemporada.Visible = True
            Else
                Me.btnExtenderTemporada.Visible = False
            End If
        End If
    End Sub

    Private Sub CboLote_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigoTrabajador.KeyDown,
    CboSemana.KeyDown, cboTipoDeduccion.KeyDown ', CboMercado.KeyDown, cboHojas.KeyDown, CboPuntoPago.KeyDown, CboTipoPercepcion.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.Send("{TAB}")
        End Select
    End Sub

    Private Sub txtCodigoTrabajador_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigoTrabajador.KeyDown
        Dim sText As String
        Dim oTrabajadores As New Class_CatTrabajadores

        Select Case e.KeyCode
            Case Keys.F6
Buscar:
                sText = oTrabajadores.BusquedaVisual_PorDescripcion
                If txtLEN(sText) = True Then Me.txtCodigoTrabajador.Text = sText
            Case Keys.Enter
                If txtLEN(Me.txtCodigoTrabajador.Text) = False Then
                    Me.txtCodigoTrabajador.Enabled = True
                    Me.lblNombreTrabajador.Text = "" : GoTo Buscar : Exit Sub
                End If

                oTrabajadores = New Class_CatTrabajadores(Me.txtCodigoTrabajador.Text, True)
                If oTrabajadores.Existe = False Then
                    Me.lblNombreTrabajador.Text = "" : GoTo Buscar : Exit Sub
                End If

                Me.ConsultarTrabajador()
                Me.txtCodigoTrabajador.Enabled = False
        End Select
    End Sub

    Private Sub Grid_CellChange(ByVal Sender As Object, ByVal e As FlexCell.Grid.CellChangeEventArgs) Handles GridHistorialDeducciones.CellChange
        Me.Totales()
    End Sub

    Private Sub Grid_KeyPress(ByVal Sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles GridHistorialDeducciones.KeyPress
        'txtSoloNumerosEnteros(e)
        txtNoBeep(e)
        Me.Totales()
    End Sub

    Private Sub GridHistorialDeducciones_KeyDown(ByVal Sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridHistorialDeducciones.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub GridPlanAbonos_Click(ByVal Sender As Object, ByVal e As System.EventArgs) Handles GridPlanAbonos.Click
        'If Me.GridPlanAbonos.ActiveCell.Col = Me.igyAbonado Then
        '    Me.GridPlanAbonos.Cell(Me.GridPlanAbonos.ActiveCell.Row, Me.igyModificado).Text = "1"
        '    If Me.GridPlanAbonos.Cell(Me.GridPlanAbonos.ActiveCell.Row, Me.igyAbonado).Text = "1" Then 'Si se esta desmarcando
        '        'Desbloquear renglon
        '        Me.GridPlanAbonos.Cell(Me.GridPlanAbonos.ActiveCell.Row, Me.igyDescuento).Locked = False
        '        'Recalcular saldos
        '        'Me.GridPlanAbonos.Cell(Me.GridPlanAbonos.ActiveCell.Row, Me.igyImporte).Locked = False
        '        Me.Totales()
        '        Me.FormateaGridPlanAbonos()
        '        Exit Sub
        '    ElseIf Me.GridPlanAbonos.Cell(Me.GridPlanAbonos.ActiveCell.Row, Me.igyAbonado).Text = "0" Or Me.GridPlanAbonos.Cell(Me.GridPlanAbonos.ActiveCell.Row, Me.igyAbonado).Text = "" Then 'Si se esta marcando
        '        Me.GridPlanAbonos.Cell(Me.GridPlanAbonos.ActiveCell.Row, Me.igyDescuento).Locked = True
        '        'Bloquear renglon
        '    End If
        'Me.Totales()
        'Me.FormateaGridPlanAbonos()
        'End If
    End Sub

    Private Sub Grid_KeyDown(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridPlanAbonos.KeyDown
        Me.GestionaGrid(e)
    End Sub

    Private Sub CboSemana_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboSemana.SelectedValueChanged
        'Se cambio combo por textbox
        'Try
        '    If Me.CboSemana.Text = "" Then
        '        Exit Sub
        '    End If
        '    Dim sql As New Class_find("SELECT DATEADD(DAY, (" & (CInt(Me.CboSemana.SelectedValue) - 1).ToString & "*7),FECHA1),DATEADD(DAY," & (CInt(Me.CboSemana.SelectedValue) - 1).ToString & "*7,FECHA1)+6 FROM NOMINA_TEMPORADAS WHERE ID_NOMINA_TEMPORADA=" & Plaza.oSisPlazaNomina.NOMINA_ID_NOMINA_TEMPORADA_ACTIVA)
        '    Me.DtpFecha1.Value = CDate(sql.Result1.ToString)
        '    Me.DtpFecha2.Value = CDate(sql.Result2.ToString)
        'Catch ex As Exception
        '    HandleError(Me.Name, "CboSemana", ex)
        'End Try
    End Sub

    Private Sub btnGeneraPlanAbonos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGeneraPlanAbonos.Click
        Dim dSemanas As Double

        If txtLEN(Me.txtCodigoTrabajador.Text) = False Then
            MsgBox("Seleccione un trabajador.", MsgBoxStyle.Exclamation, Me.Text)
            Me.txtCodigoTrabajador.Focus()
            Exit Sub
        End If

        If txtLEN(Me.TxtImporte.Text) = False Then
            MsgBox("Capture importe de la deducción.", MsgBoxStyle.Exclamation, Me.Text)
            Me.TxtImporte.Focus()
            Exit Sub
        End If

        If txtLEN(Me.TxtDescuento.Text) = False Then
            MsgBox("Capture descuento semanal.", MsgBoxStyle.Exclamation, Me.Text)
            Me.TxtDescuento.Focus()
            Exit Sub
        Else
            If valorNumerico(Me.TxtDescuento.Text) > valorNumerico(Me.TxtImporte.Text) Then
                MsgBox("El descuento semanal es mayor al importe.", MsgBoxStyle.Exclamation, Me.Text)
                Exit Sub
            Else
                dSemanas = valorNumerico(Me.TxtImporte.Text) / valorNumerico(Me.TxtDescuento.Text)

                Dim oTemporada As New Class_NominaTemporada(Plaza.oSisPlazaNomina.NOMINA_ID_NOMINA_TEMPORADA_ACTIVA)

                If valorNumerico(Me.txtNumeroSemana.Text) + CInt(-Int(-dSemanas)) > oTemporada.NUMERO_SEMANAS Then
                    'MsgBox("El número de semanas generadas pasan del número de las semanas de la temporada actual .", MsgBoxStyle.Exclamation, Me.Text)
                    'Exit Sub
                    Me.GridPlanAbonos.Rows = CInt(oTemporada.NUMERO_SEMANAS - valorNumerico(Me.txtNumeroSemana.Text) + 1)
                    Dim dSaldo As Double = valorNumerico(Me.TxtImporte.Text)
                    Dim iSemana As Double = valorNumerico(Me.txtNumeroSemana.Text)

                    If Me.rdbMismaSemana.Checked = True Then
                        iSemana = iSemana - 1
                        Me.GridPlanAbonos.Rows = Me.GridPlanAbonos.Rows + 1
                    End If

                    For i As Integer = 1 To Me.GridPlanAbonos.Rows - 1
                        Me.GridPlanAbonos.Cell(i, Me.igyIdDeduccionDetalle).Text = ""
                        iSemana = iSemana + 1
                        If oTemporada.NUMERO_SEMANAS > (iSemana) Then
                            Me.GridPlanAbonos.Cell(i, Me.igySemana).Text = (iSemana).ToString
                            If dSaldo < valorNumerico(Me.TxtDescuento.Text) And dSaldo > 0 Then
                                Me.GridPlanAbonos.Cell(i, Me.igyDescuento).Text = "" & FormatImporteContable(dSaldo)
                                dSaldo = dSaldo - dSaldo
                            Else
                                Me.GridPlanAbonos.Cell(i, Me.igyDescuento).Text = "" & FormatImporteContable(valorNumerico(Me.TxtDescuento.Text))
                                dSaldo = dSaldo - valorNumerico(Me.GridPlanAbonos.Cell(i, Me.igyDescuento).Text)
                            End If
                            Me.GridPlanAbonos.Cell(i, Me.igySaldo).Text = "" & FormatImporteContable(dSaldo)
                            Me.GridPlanAbonos.Cell(i, Me.igyAbonado).Text = "0"
                            Me.GridPlanAbonos.Cell(i, Me.igyTemporada).Text = Plaza.oSisPlazaNomina.NOMINA_ID_NOMINA_TEMPORADA_ACTIVA.ToString

                        ElseIf oTemporada.NUMERO_SEMANAS = (valorNumerico(Me.GridPlanAbonos.Cell(i - 1, Me.igySemana).Text) + 1) Then
                            Me.GridPlanAbonos.Cell(i, Me.igySemana).Text = oTemporada.NUMERO_SEMANAS.ToString
                            Me.GridPlanAbonos.Cell(i, Me.igySaldo).Text = FormatImporteContable(0)
                            Me.GridPlanAbonos.Cell(i, Me.igyAbonado).Text = "0"
                            Me.GridPlanAbonos.Cell(i, Me.igyDescuento).Text = "" & FormatImporteContable(dSaldo)
                        ElseIf oTemporada.NUMERO_SEMANAS = iSemana Then
                            Me.GridPlanAbonos.Cell(i, Me.igySemana).Text = oTemporada.NUMERO_SEMANAS.ToString
                            Me.GridPlanAbonos.Cell(i, Me.igySaldo).Text = FormatImporteContable(0)
                            Me.GridPlanAbonos.Cell(i, Me.igyAbonado).Text = "0"
                            Me.GridPlanAbonos.Cell(i, Me.igyDescuento).Text = "" & FormatImporteContable(dSaldo)
                            Me.GridPlanAbonos.Cell(i, Me.igyTemporada).Text = Plaza.oSisPlazaNomina.NOMINA_ID_NOMINA_TEMPORADA_ACTIVA.ToString
                        End If
                    Next i

                    Me.FormateaGridPlanAbonos()
                Else
                    Me.GridPlanAbonos.Rows = CInt(-Int(-dSemanas)) + 1
                    Dim dSaldo As Double = valorNumerico(Me.TxtImporte.Text)
                    Dim iSemana As Double = valorNumerico(Me.txtNumeroSemana.Text)

                    If Me.rdbMismaSemana.Checked = True Then
                        iSemana = iSemana - 1
                    End If

                    For i As Integer = 1 To Me.GridPlanAbonos.Rows - 1
                        Me.GridPlanAbonos.Cell(i, Me.igyIdDeduccionDetalle).Text = ""
                        Me.GridPlanAbonos.Cell(i, Me.igySemana).Text = (iSemana + i).ToString
                        If dSaldo < valorNumerico(Me.TxtDescuento.Text) And dSaldo > 0 Then
                            Me.GridPlanAbonos.Cell(i, Me.igyDescuento).Text = "" & FormatImporteContable(dSaldo)
                            dSaldo = dSaldo - dSaldo
                        Else
                            Me.GridPlanAbonos.Cell(i, Me.igyDescuento).Text = "" & FormatImporteContable(valorNumerico(Me.TxtDescuento.Text))
                            dSaldo = dSaldo - valorNumerico(Me.TxtDescuento.Text)
                        End If
                        Me.GridPlanAbonos.Cell(i, Me.igySaldo).Text = "" & FormatImporteContable(dSaldo)
                        Me.GridPlanAbonos.Cell(i, Me.igyAbonado).Text = "0"
                        Me.GridPlanAbonos.Cell(i, Me.igyTemporada).Text = Plaza.oSisPlazaNomina.NOMINA_ID_NOMINA_TEMPORADA_ACTIVA.ToString
                    Next i
                End If


                '    If valorNumerico(Me.GridPlanAbonos.Cell(Renglon - 1, Me.igySemana).Text) + CInt(-Int(-dSemanas)) > oTemporada.NUMERO_SEMANAS Then
                '        'MsgBox("El número de semanas generadas pasan del número de las semanas de la temporada actual .", MsgBoxStyle.Exclamation, Me.Text)
                '        'Exit Sub
                '    Else
                '        Me.GridPlanAbonos.Rows = Renglon + CInt(-Int(-dSemanas))
                '        dSaldo = valorNumerico(Me.GridPlanAbonos.Cell(Renglon - 1, Me.igySaldo).Text)
                '        iSemana = valorNumerico(Me.GridPlanAbonos.Cell(Renglon - 1, Me.igySemana).Text)

                '        For i As Integer = Renglon To Me.GridPlanAbonos.Rows - 1
                '            Me.GridPlanAbonos.Cell(i, Me.igyIdDeduccionDetalle).Text = ""
                '            Me.GridPlanAbonos.Cell(i, Me.igySemana).Text = (valorNumerico(Me.GridPlanAbonos.Cell(i - 1, Me.igySemana).Text) + 1).ToString
                '            If dSaldo < valorNumerico(Me.GridPlanAbonos.Cell(Renglon, Me.igyDescuento).Text) And dSaldo > 0 Then
                '                Me.GridPlanAbonos.Cell(i, Me.igyDescuento).Text = "" & FormatImporteContable(dSaldo)
                '                dSaldo = dSaldo - dSaldo
                '            Else
                '                Me.GridPlanAbonos.Cell(i, Me.igyDescuento).Text = "" & FormatImporteContable(valorNumerico(Me.GridPlanAbonos.Cell(Renglon, Me.igyDescuento).Text))
                '                dSaldo = dSaldo - valorNumerico(Me.GridPlanAbonos.Cell(Renglon, Me.igyDescuento).Text)
                '            End If
                '            Me.GridPlanAbonos.Cell(i, Me.igySaldo).Text = "" & FormatImporteContable(dSaldo)
                '            Me.GridPlanAbonos.Cell(i, Me.igyAbonado).Text = "0"
                '        Next i

                '        Me.FormateaGridPlanAbonos()
                '    End If
                'End If
                Me.FormateaGridPlanAbonos()
                Me.Totales()
            End If
        End If
    End Sub

    Private Sub BtnAgregarSemana_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregarSemana.Click
        Dim oTemporada As New Class_NominaTemporada(Plaza.oSisPlazaNomina.NOMINA_ID_NOMINA_TEMPORADA_ACTIVA)
        Dim iSemana As Integer

        If (Me.GridPlanAbonos.Rows < 2) Then
            iSemana = CInt(Me.txtNumeroSemana.Text)
        Else
            iSemana = CInt(Me.GridPlanAbonos.Cell(Me.GridPlanAbonos.Rows - 1, Me.igySemana).Text)
        End If

        If CInt(iSemana + 1) > oTemporada.NUMERO_SEMANAS Then
            MsgBox("El número de semanas generadas pasan del número de las semanas de la temporada actual .", MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If

        Me.GridPlanAbonos.Rows = Me.GridPlanAbonos.Rows + 1

        Me.GridPlanAbonos.Cell(Me.GridPlanAbonos.Rows - 1, Me.igyIdDeduccionDetalle).Text = ""
        Me.GridPlanAbonos.Cell(Me.GridPlanAbonos.Rows - 1, Me.igySemana).Text = (iSemana + 1).ToString
        Me.GridPlanAbonos.Cell(Me.GridPlanAbonos.Rows - 1, Me.igyDescuento).Text = "" & FormatImporteContable(0)
        Me.GridPlanAbonos.Cell(Me.GridPlanAbonos.Rows - 1, Me.igySaldo).Text = "" & FormatImporteContable(0)
        Me.GridPlanAbonos.Cell(Me.GridPlanAbonos.Rows - 1, Me.igyAbonado).Text = "0"
    End Sub

    Private Sub BtnBorrarSemana_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBorrarSemana.Click
        If Me.GridPlanAbonos.Cell(Me.GridPlanAbonos.Rows - 1, Me.igyAbonado).Text = "1" Then
            Exit Sub
        Else
            'If txtLEN(Me.GridPlanAbonos.Cell(Me.GridPlanAbonos.Rows - 1, Me.igyIdDeduccionDetalle).Text) Then
            ' Me.GridPlanAbonos.Row(Me.GridPlanAbonos.Rows - 1).Visible = False
            'Else
            If Me.GridPlanAbonos.Rows > 2 Then
                If Me.GridPlanAbonos.Cell(Me.GridPlanAbonos.Rows - 2, Me.igyAbonado).Text = "1" Then

                Else
                    Me.GridPlanAbonos.Cell(Me.GridPlanAbonos.Rows - 2, Me.igyDeduccion).Text = (valorNumerico(Me.GridPlanAbonos.Cell(Me.GridPlanAbonos.Rows - 2, Me.igyDeduccion).Text) + valorNumerico(Me.GridPlanAbonos.Cell(Me.GridPlanAbonos.Rows - 1, Me.igyDeduccion).Text)).ToString
                    Me.GridPlanAbonos.Cell(Me.GridPlanAbonos.Rows - 2, Me.igySaldo).Text = "0"
                    Me.GridPlanAbonos.Row(Me.GridPlanAbonos.Rows - 1).Delete()
                End If

            End If
            'End If
        End If
        Me.Totales()
    End Sub

    Private Sub BtnRecorrerSemana_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRecorrerSemana.Click
        Dim oTemporada As New Class_NominaTemporada(Plaza.oSisPlazaNomina.NOMINA_ID_NOMINA_TEMPORADA_ACTIVA)
        Dim iSemana As Integer
        Dim Columna As Integer, Renglon As Integer

        'Dim dPercipcion As Double
        Dim i As Integer
        Try

            Renglon = Me.GridPlanAbonos.Selection.FirstRow
            iSemana = CInt(Me.GridPlanAbonos.Cell(Renglon, Me.igySemana).Text)

            If Me.GridPlanAbonos.Cell(Renglon, Me.igyAbonado).Text = "1" Then
                MsgBox("Favor de seleccionar una semanas que no este generada.", MsgBoxStyle.Exclamation, Me.Text)
                Exit Sub
            End If
            Columna = CInt(Me.GridPlanAbonos.Cell(Me.GridPlanAbonos.Rows - 1, Me.igySemana).Text) + 1
            If iSemana = oTemporada.NUMERO_SEMANAS Then
                'MsgBox("El número de semanas generadas pasan del número de las semanas de la temporada actual .", MsgBoxStyle.Exclamation, Me.Text)
                'Exit Sub
                If MsgBox("Deseas pasar las deducciónes generadas a la siguiente temporada ?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "Grabar") = MsgBoxResult.No Then
                    Exit Sub
                End If

                Dim sql As New Class_find("SELECT ISNULL(MIN(ID_NOMINA_TEMPORADA),0),MAX(NUMERO_SEMANAS) FROM NOMINA_TEMPORADAS WHERE ID_NOMINA_TEMPORADA>" & Plaza.oSisPlazaNomina.NOMINA_ID_NOMINA_TEMPORADA_ACTIVA.ToString & " AND CODIGO_PLAZA=" & Usuario.Codigo_Plaza.ToString)
                Dim iTemporadaSig As Integer
                iTemporadaSig = CInt(sql.Result1)
                Dim numSem As Integer = 0

                For i = Renglon To Me.GridPlanAbonos.Rows - 1
                    If Me.GridPlanAbonos.Cell(i, Me.igyAbonado).Text = "0" Then
                        numSem = numSem + 1
                        Me.GridPlanAbonos.Cell(Renglon, Me.igySemana).Text = (numSem).ToString
                        Me.GridPlanAbonos.Cell(Renglon, Me.igyTemporada).Text = (iTemporadaSig).ToString
                        Renglon = Renglon + 1
                    End If
                Next
                '
            Else
                For i = Renglon To Me.GridPlanAbonos.Rows - 1
                    If Me.GridPlanAbonos.Cell(i, Me.igyAbonado).Text = "0" Then
                        iSemana = iSemana + 1
                        Me.GridPlanAbonos.Cell(Renglon, Me.igySemana).Text = (iSemana).ToString
                        Renglon = Renglon + 1
                    End If
                Next
            End If
            'Me.GridPlanAbonos.Cell(Me.GridPlanAbonos.Rows - 1, Me.igySemana).Text = (iSemana + 1).ToString

        Catch ex As Exception
            HandleError(Me.Name, "BtnRecorrerSemana", ex)
        End Try
    End Sub

    Private Sub GridHistorialDeducciones_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridHistorialDeducciones.Click
        Dim DColumna As Integer, DRenglon As Integer, vdg As String
        Dim Renglon As Integer

        DColumna = Me.GridHistorialDeducciones.Selection.FirstCol
        DRenglon = Me.GridHistorialDeducciones.Selection.FirstRow
        Renglon = Me.GridHistorialDeducciones.Selection.FirstRow

        If DColumna = 0 Or DRenglon = 0 Then
            DColumna = 1
            DRenglon = 1
            Me.GridHistorialDeducciones.Cell(DRenglon, Me.igyHistorialIdDeduccion).SetFocus()
        End If

        vdg = Me.GridHistorialDeducciones.Cell(DRenglon, Me.igyHistorialIdDeduccion).Text 'Grid.Rows(Renglon).Cell("FOLIO_POLIZA")
        If txtLEN(vdg) = False Then
            Exit Sub
        End If

        Me.Consultar(CInt(vdg))
        'Exit Sub
    End Sub

    Private Sub GridTrabajadores_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridTrabajadores.Click
        Dim DColumna As Integer, DRenglon As Integer, vdg As String
        Dim Renglon As Integer

        DColumna = Me.GridTrabajadores.Selection.FirstCol
        DRenglon = Me.GridTrabajadores.Selection.FirstRow
        Renglon = Me.GridTrabajadores.Selection.FirstRow

        If DColumna = 0 Or DRenglon = 0 Then
            DColumna = 1
            DRenglon = 1
            Me.GridTrabajadores.Cell(DRenglon, Me.igyCodigoTrabajador).SetFocus()
        End If

        vdg = Me.GridTrabajadores.Cell(DRenglon, Me.igyCodigoTrabajador).Text 'Grid.Rows(Renglon).Cell("FOLIO_POLIZA")
        If txtLEN(vdg) = False Then
            Exit Sub
        End If

        Me.txtCodigoTrabajador.Text = vdg
        Me.ConsultarTrabajador()
        'Exit Sub
    End Sub

    Public Function ExternderSemanasSiguienteTemporada() As Boolean
        Dim oTemporada As New Class_NominaTemporada(Plaza.oSisPlazaNomina.NOMINA_ID_NOMINA_TEMPORADA_ACTIVA)
        Dim iSemana As Integer
        Dim dSemanas As Double
        Dim iTemporadaSig As Integer
        Dim dSaldo As Double
        Dim dDescuento As Double

        Dim sql As New Class_find("SELECT ISNULL(MIN(ID_NOMINA_TEMPORADA),0),MAX(NUMERO_SEMANAS) FROM NOMINA_TEMPORADAS WHERE ID_NOMINA_TEMPORADA>" & Plaza.oSisPlazaNomina.NOMINA_ID_NOMINA_TEMPORADA_ACTIVA.ToString & " AND CODIGO_PLAZA=" & Usuario.Codigo_Plaza.ToString)
        If CInt(sql.Result1) = 0 Then
            MsgBox("No existe una temporada siguiente, favor de verificar.", MsgBoxStyle.Exclamation, Me.Text)
            Exit Function
        Else
            iTemporadaSig = CInt(sql.Result1)
        End If

        If (Me.GridPlanAbonos.Rows < 2) Then
            iSemana = CInt(Me.txtNumeroSemana.Text)
        Else
            iSemana = CInt(Me.GridPlanAbonos.Cell(Me.GridPlanAbonos.Rows - 1, Me.igySemana).Text)
        End If

        If iSemana = oTemporada.NUMERO_SEMANAS Then
            dSaldo = valorNumerico(Me.GridPlanAbonos.Cell(Me.GridPlanAbonos.Rows - 2, Me.igySaldo).Text)
            dDescuento = valorNumerico(Me.GridPlanAbonos.Cell(Me.GridPlanAbonos.Rows - 2, Me.igyDeduccion).Text)

            Me.GridPlanAbonos.Cell(Me.GridPlanAbonos.Rows - 1, Me.igyIdDeduccionDetalle).Text = ""
            Me.GridPlanAbonos.Cell(Me.GridPlanAbonos.Rows - 1, Me.igySemana).Text = (iSemana).ToString
            If dSaldo < dDescuento And dSaldo > 0 Then
                Me.GridPlanAbonos.Cell(Me.GridPlanAbonos.Rows - 1, Me.igyDescuento).Text = "" & FormatImporteContable(dSaldo)
                dSaldo = dSaldo - dSaldo
            Else
                Me.GridPlanAbonos.Cell(Me.GridPlanAbonos.Rows - 1, Me.igyDescuento).Text = "" & FormatImporteContable(valorNumerico(Me.GridPlanAbonos.Cell(Me.GridPlanAbonos.Rows - 2, Me.igyDescuento).Text))
                dSaldo = dSaldo - valorNumerico(Me.GridPlanAbonos.Cell(Me.GridPlanAbonos.Rows - 2, Me.igyDescuento).Text)
            End If
            Me.GridPlanAbonos.Cell(Me.GridPlanAbonos.Rows - 1, Me.igySaldo).Text = "" & FormatImporteContable(dSaldo)
            Me.GridPlanAbonos.Cell(Me.GridPlanAbonos.Rows - 1, Me.igyAbonado).Text = "0"
            Me.GridPlanAbonos.Cell(Me.GridPlanAbonos.Rows - 1, Me.igyTemporada).Text = oTemporada.ID_NOMINA_TEMPORADA.ToString

            dSemanas = dSaldo / valorNumerico(Me.GridPlanAbonos.Cell(Me.GridPlanAbonos.Rows - 1, Me.igyDescuento).Text)
            For i As Integer = 1 To CInt(-Int(-dSemanas)) '+ 1
                Me.GridPlanAbonos.Rows = Me.GridPlanAbonos.Rows + 1

                Me.GridPlanAbonos.Cell(Me.GridPlanAbonos.Rows - 1, Me.igyIdDeduccionDetalle).Text = ""
                Me.GridPlanAbonos.Cell(Me.GridPlanAbonos.Rows - 1, Me.igySemana).Text = (i).ToString
                If dSaldo < dDescuento And dSaldo > 0 Then
                    Me.GridPlanAbonos.Cell(Me.GridPlanAbonos.Rows - 1, Me.igyDescuento).Text = "" & FormatImporteContable(dSaldo)
                    dSaldo = dSaldo - dSaldo
                Else
                    Me.GridPlanAbonos.Cell(Me.GridPlanAbonos.Rows - 1, Me.igyDescuento).Text = "" & FormatImporteContable(valorNumerico(Me.GridPlanAbonos.Cell(Me.GridPlanAbonos.Rows - 2, Me.igyDescuento).Text))
                    dSaldo = dSaldo - valorNumerico(Me.GridPlanAbonos.Cell(Me.GridPlanAbonos.Rows - 2, Me.igyDescuento).Text)
                End If
                Me.GridPlanAbonos.Cell(Me.GridPlanAbonos.Rows - 1, Me.igySaldo).Text = "" & FormatImporteContable(dSaldo)
                Me.GridPlanAbonos.Cell(Me.GridPlanAbonos.Rows - 1, Me.igyAbonado).Text = "0"
                Me.GridPlanAbonos.Cell(Me.GridPlanAbonos.Rows - 1, Me.igyTemporada).Text = iTemporadaSig.ToString
                'i = i + 1
            Next i
        End If

        Me.FormateaGridPlanAbonos()
        Me.Totales()

    End Function
#End Region

#Region "Eventos Genericos"

    Private Sub TxtImporte_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtImporte.KeyDown
        If e.KeyCode = Keys.Return Then
            If valorNumerico(Me.TxtImporte.Text) > 0 Then
                Me.TxtImporte.Text = FormatImporteContable(CDbl(Me.TxtImporte.Text))
            End If
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtDescuento_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDescuento.KeyDown
        If e.KeyCode = Keys.Return Then
            If valorNumerico(Me.TxtDescuento.Text) > 0 Then
                Me.TxtDescuento.Text = FormatImporteContable(CDbl(Me.TxtDescuento.Text))
            End If
            Me.btnGeneraPlanAbonos.Focus()
        End If
    End Sub

    Private Sub txtTextoKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CboSemana.KeyPress, cboTipoDeduccion.KeyPress,
        txtCodigoTrabajador.KeyPress, TxtImporte.KeyPress, txtSumaImportes.KeyPress, txtSumaSaldos.KeyPress, TxtDescuento.KeyPress, TxtSaldo.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub TxtConcepto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtConcepto.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub txtNumerosEnterosKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        txtSoloNumerosEnteros(e)
        txtNoBeep(e)
    End Sub

    Private Sub txtNumerosDecimalKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtImporte.KeyPress, TxtDescuento.KeyPress
        Dim txt As TextBox = CType(sender, TextBox)
        txtSoloNumerosDecimales(e, txt.Text)
        txtNoBeep(e)
    End Sub

    Private Sub txtKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) 'Handles CboEmpaque.KeyPress, DtpFecha.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub txt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtConcepto.KeyDown
        If e.KeyCode = Keys.Return Then
            'SendKeys.Send("{TAB}")
            If Me._ChildParaGrabar = True Then
                Me.TxtDescuento.Focus()
            Else
                If Me.rdbSiguienteSemana.Checked = True Then
                    Me.rdbSiguienteSemana.Focus()
                Else
                    Me.rdbMismaSemana.Focus()
                End If
            End If

            Me.TxtConcepto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        End If
    End Sub

    Private Sub rdbMismaSemana_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles rdbMismaSemana.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub rdbSiguienteSemana_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles rdbSiguienteSemana.KeyDown
        If e.KeyCode = Keys.Return Then
            If Me._ChildParaGrabar = True Then
                Me.TxtDescuento.Focus()
            Else
                Me.TxtImporte.Focus()
            End If
            'SendKeys.Send("{TAB}")
        End If
    End Sub

#End Region
#End Region

#Region "Métodos y procedimientos"
    Private Sub Inicializa()
        Try
            Me.DesplegarTipoDeduccion(False)
            Me.InicializaGridPlan()
            Me.InicializaGridhistorial()

            Me.txtNumeroSemana.Focus()
            Me.txtCodigoTrabajador.Text = "" : Me.txtCodigoTrabajador.Enabled = True
            Me.lblNombreTrabajador.Text = ""
            Me.TxtConcepto.Text = ""
            Me.TxtImporte.Text = ""
            Me.TxtDescuento.Text = ""
            Me.TxtSaldo.Text = ""
            Me.txtSuma.Text = ""
            Me.txtSumaImportes.Text = ""
            Me.txtSumaSaldos.Text = ""
            'Me.CboSemana.SelectedValue = Plaza.oSisPlazaNomina.NOMINA_NUMERO_SEMANA_ACTUAL
            Me.txtNumeroSemana.Text = Plaza.oSisPlazaNomina.NOMINA_NUMERO_SEMANA_ACTUAL.ToString
            Me.ObentenIdSemana()
            Me.LlenaFechasSemana(Plaza.oSisPlazaNomina.NOMINA_ID_NOMINA_TEMPORADA_ACTIVA)
            Me.cboTipoDeduccion.SelectedIndex = -1
            Me.LblId_Percepcion.Text = "0"

        Catch ex As Exception
            HandleError(Me.Name, "Inicializa", ex)
        End Try
    End Sub

    Private Sub inicializaChild()
        Me.oDeducciones = New Class_NominaDeduccionesGlobal(Me._ID_DEDUCCION)
        Me.DesplegarTipoDeduccion(True)
        'Me.DesplegarSemanas()

        Me.txtNumeroSemana.Text = Me._NumeroSemana.ToString
        Me.Cambia_Estado(enumEstados.NUEVO)

        Me.txtCodigoTrabajador.Enabled = False
        Me.CboSemana.Enabled = False
        Me.txtNumeroSemana.Enabled = False
        Me.cboTipoDeduccion.Enabled = False
        Me.TxtImporte.Enabled = False
        Me.LlenaFechasSemana(Plaza.oSisPlazaNomina.NOMINA_ID_NOMINA_TEMPORADA_ACTIVA)
        Me.cboTipoDeduccion.SelectedValue = 1

        Me.InicializaGridPlan()
        Me.InicializaGridhistorial()

        Me.tsbNuevo.Enabled = False
        Me.tsbGrabar.Visible = True
        Me.tsbEliminar.Enabled = False

    End Sub

    Private Sub DesplegarSemanas()
        Try
            Dim oElementos As New Class_NominaSemana
            oElementos = New Class_NominaSemana
            With Me.CboSemana
                .DisplayMember = "NUMERO_SEMANA"
                .ValueMember = "ID_NOMINA_SEMANA"
                Dim dView As New Data.DataView(oElementos.ObtenerElementos())
                dView.Sort = "NUMERO_SEMANA"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedIndex = 0
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarSemanas", ex)
        End Try
    End Sub

    Private Sub ObentenIdSemana()
        Try
            Dim sql As New Class_find("SELECT ID_NOMINA_SEMANA FROM NOMINA_SEMANA WHERE NUMERO_SEMANA=" & Plaza.oSisPlazaNomina.NOMINA_NUMERO_SEMANA_ACTUAL.ToString & " AND ID_NOMINA_TEMPORADA=" & Plaza.oSisPlazaNomina.NOMINA_ID_NOMINA_TEMPORADA_ACTIVA.ToString)
            If sql.Result1 <> "" Then
                Me.txtIdSemana.Text = sql.Result1.ToString
            End If
        Catch ex As Exception
            HandleError(Me.Name, "ObentenIdSemana", ex)
        End Try
    End Sub

    Private Sub DesplegarTipoDeduccion(ByVal bOculto As Boolean)
        'Private Sub DesplegarTipoDeduccion()
        Try
            Dim oElementos As New Class_CatTipoDeducciones
            With Me.cboTipoDeduccion
                .DisplayMember = "NOMBRE_TIPO_DEDUCCION"
                .ValueMember = "CODIGO_TIPO_DEDUCCION"
                'Dim dView As New Data.DataView(oElementos.ObtenerElementos())
                Dim dView As New Data.DataView(oElementos.ObtenerElementosDeduciones(bOculto))
                dView.Sort = "NOMBRE_TIPO_DEDUCCION DESC"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedIndex = -1
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarTipoDeduccion", ex)
        End Try
    End Sub

    Private Sub DesplegarDeducciones()
        Dim dTabla As DataTable
        Try
            Dim oElementos As New Class_NominaDeduccionesGlobal
            Me.InicializaGridTrabajadores()

            dTabla = oElementos.ObtenerElementos

            'Private igyCodigoTrabajador As Short = 1
            'Private igyNombreTrabajador As Short = 2
            'Private igyDeduccion As Short = 3
            'Private igyImporteTrabajador As Short = 4
            'Private igySaldoTrabajador As Short = 5

            Me.GridTrabajadores.Rows = 1
            For Each dRow As DataRow In dTabla.Rows
                Me.GridTrabajadores.AddItem(dRow("CODIGO_X_TEMPORADA").ToString & Chr(9) & dRow("NOMBRE_COMPLETO_APELLIDO").ToString & Chr(9) & dRow("NOMBRE_TIPO_DEDUCCION").ToString & Chr(9) &
                                            Format(CDate(dRow("FECHA_SERVIDOR").ToString), "dd-MMM-yy") & Chr(9) & dRow("IMPORTE").ToString & Chr(9) & dRow("SALDO").ToString & Chr(9))
            Next
            dTabla.Dispose()

            Me.FormateaGridTrabajadores()
            If Me.GridTrabajadores.Rows <= 1 Then
                Me.GridTrabajadores.Rows = 2
            Else
                'Me.GridTrabajadores.Cell(1, 1).SetFocus()
            End If

        Catch ex As Exception
            HandleError(Me.Name, "DesplegarDeducciones", ex)
        End Try
    End Sub

    Private Sub InicializaGridPlan()
        Me.GridPlanAbonos.DataSource = Nothing
        FG_Grid_Limpiar(Me.GridPlanAbonos)

        Me.GridPlanAbonos.Rows = 2
        Me.GridPlanAbonos.Cols = 7

        Me.FormateaGridPlanAbonos()
    End Sub

    Private Sub InicializaGridhistorial()
        Me.GridHistorialDeducciones.DataSource = Nothing
        FG_Grid_Limpiar(Me.GridHistorialDeducciones)

        Me.GridHistorialDeducciones.Rows = 2
        Me.GridHistorialDeducciones.Cols = 6

        Me.FormateaGrid()
    End Sub

    Private Sub InicializaGridTrabajadores()
        Me.GridTrabajadores.DataSource = Nothing
        FG_Grid_Limpiar(Me.GridTrabajadores)

        Me.GridTrabajadores.Rows = 2
        Me.GridTrabajadores.Cols = 7

        Me.FormateaGridTrabajadores()
    End Sub

    Private Sub FormateaGridPlanAbonos()
        Me.GridPlanAbonos.Column(Me.igyIdDeduccionDetalle).Width = 70
        Me.GridPlanAbonos.Column(Me.igySemana).Width = 65
        Me.GridPlanAbonos.Column(Me.igyDescuento).Width = 100
        Me.GridPlanAbonos.Column(Me.igySaldo).Width = 100
        Me.GridPlanAbonos.Column(Me.igyAbonado).Width = 70
        Me.GridPlanAbonos.Column(Me.igyTemporada).Width = 70

        Me.GridPlanAbonos.Cell(0, Me.igyIdDeduccionDetalle).Text = "IdDetalle"
        Me.GridPlanAbonos.Cell(0, Me.igySemana).Text = "#Semana"
        Me.GridPlanAbonos.Cell(0, Me.igyDescuento).Text = "Descuento"
        Me.GridPlanAbonos.Cell(0, Me.igySaldo).Text = "Saldo"
        Me.GridPlanAbonos.Cell(0, Me.igyAbonado).Text = "Abonado"
        Me.GridPlanAbonos.Cell(0, Me.igyTemporada).Text = "Temporada"

        Me.GridPlanAbonos.Column(Me.igySemana).Alignment = FlexCell.AlignmentEnum.CenterCenter
        Me.GridPlanAbonos.Column(Me.igyAbonado).CellType = FlexCell.CellTypeEnum.CheckBox

        Me.GridPlanAbonos.Column(Me.igyDescuento).FormatString = ("$ ###,###,###.00").ToString
        Me.GridPlanAbonos.Column(Me.igyDescuento).Mask = FlexCell.MaskEnum.Numeric
        Me.GridPlanAbonos.Column(Me.igyDescuento).DecimalLength = Empresa_Sistema.DECIMALES_PRECIO
        Me.GridPlanAbonos.Column(Me.igyDescuento).Alignment = FlexCell.AlignmentEnum.RightCenter

        Me.GridPlanAbonos.Column(Me.igySaldo).FormatString = ("$ ###,###,###.00").ToString
        Me.GridPlanAbonos.Column(Me.igySaldo).Mask = FlexCell.MaskEnum.Numeric
        Me.GridPlanAbonos.Column(Me.igySaldo).DecimalLength = Empresa_Sistema.DECIMALES_PRECIO
        Me.GridPlanAbonos.Column(Me.igySaldo).Alignment = FlexCell.AlignmentEnum.RightCenter

        Me.GridPlanAbonos.Column(Me.igyIdDeduccionDetalle).Locked = True
        Me.GridPlanAbonos.Column(Me.igyIdDeduccionDetalle).Visible = False
        Me.GridPlanAbonos.Column(Me.igySemana).Locked = True
        Me.GridPlanAbonos.Column(Me.igyDescuento).Locked = False
        Me.GridPlanAbonos.Column(Me.igySaldo).Locked = True
        Me.GridPlanAbonos.Column(Me.igyAbonado).Locked = True
        Me.GridPlanAbonos.Column(Me.igyTemporada).Locked = True
        Me.GridPlanAbonos.Column(Me.igyTemporada).Visible = False

        If Estado = enumEstados.GRABADO Or Estado = enumEstados.GENERADO Then
            For i As Integer = 1 To Me.GridPlanAbonos.Rows - 1
                If Me.GridPlanAbonos.Cell(i, Me.igyAbonado).Text = "1" Then
                    Me.GridPlanAbonos.Cell(i, Me.igyDescuento).Locked = True
                End If
            Next i
        End If
    End Sub

    Private Sub FormateaGrid()
        Me.GridHistorialDeducciones.Column(0).Width = 15
        Me.GridHistorialDeducciones.Column(Me.igyHistorialSemana).Width = 40
        Me.GridHistorialDeducciones.Column(Me.igyHistorialFecha).Width = 63
        Me.GridHistorialDeducciones.Column(Me.igyHistorialImporte).Width = 70
        Me.GridHistorialDeducciones.Column(Me.igyHistorialSaldo).Width = 70

        Me.GridHistorialDeducciones.Cell(0, Me.igyHistorialSemana).Text = "#Sem"
        Me.GridHistorialDeducciones.Cell(0, Me.igyHistorialFecha).Text = "Fecha"
        Me.GridHistorialDeducciones.Cell(0, Me.igyHistorialImporte).Text = "Importe"
        Me.GridHistorialDeducciones.Cell(0, Me.igyHistorialSaldo).Text = "Saldo"

        Me.GridHistorialDeducciones.Column(Me.igyHistorialImporte).FormatString = ("$ ###,###,###.00").ToString
        Me.GridHistorialDeducciones.Column(Me.igyHistorialImporte).Mask = FlexCell.MaskEnum.Numeric
        Me.GridHistorialDeducciones.Column(Me.igyHistorialImporte).DecimalLength = Empresa_Sistema.DECIMALES_PRECIO
        Me.GridHistorialDeducciones.Column(Me.igyHistorialImporte).Alignment = FlexCell.AlignmentEnum.RightCenter

        Me.GridHistorialDeducciones.Column(Me.igyHistorialSaldo).FormatString = ("$ ###,###,###.00").ToString
        Me.GridHistorialDeducciones.Column(Me.igyHistorialSaldo).Mask = FlexCell.MaskEnum.Numeric
        Me.GridHistorialDeducciones.Column(Me.igyHistorialSaldo).DecimalLength = Empresa_Sistema.DECIMALES_PRECIO
        Me.GridHistorialDeducciones.Column(Me.igyHistorialSaldo).Alignment = FlexCell.AlignmentEnum.RightCenter

        Me.GridHistorialDeducciones.Column(Me.igyHistorialIdDeduccion).Visible = False
        Me.GridHistorialDeducciones.Column(Me.igyHistorialIdDeduccion).Locked = True
        Me.GridHistorialDeducciones.Column(Me.igyHistorialSemana).Locked = True
        Me.GridHistorialDeducciones.Column(Me.igyHistorialFecha).Locked = True
        Me.GridHistorialDeducciones.Column(Me.igyHistorialImporte).Locked = True
        Me.GridHistorialDeducciones.Column(Me.igyHistorialSaldo).Locked = True

    End Sub

    Private Sub FormateaGridTrabajadores()
        Me.GridTrabajadores.Column(0).Width = 20
        Me.GridTrabajadores.Column(1).Width = 50
        Me.GridTrabajadores.Column(2).Width = 80
        Me.GridTrabajadores.Column(3).Width = 80
        Me.GridTrabajadores.Column(4).Width = 55
        Me.GridTrabajadores.Column(5).Width = 70
        Me.GridTrabajadores.Column(6).Width = 70

        Me.GridTrabajadores.Cell(0, 1).Text = "Cód"
        Me.GridTrabajadores.Cell(0, 2).Text = "Nombre"
        Me.GridTrabajadores.Cell(0, 3).Text = "Deducción"
        Me.GridTrabajadores.Cell(0, 4).Text = "Fecha"
        Me.GridTrabajadores.Cell(0, 5).Text = "Importe"
        Me.GridTrabajadores.Cell(0, 6).Text = "Saldo"

        Me.GridTrabajadores.Column(5).FormatString = ("$ ###,###,###.00").ToString
        Me.GridTrabajadores.Column(5).Mask = FlexCell.MaskEnum.Numeric
        Me.GridTrabajadores.Column(5).Alignment = FlexCell.AlignmentEnum.RightCenter

        Me.GridTrabajadores.Column(6).FormatString = ("$ ###,###,###.00").ToString
        Me.GridTrabajadores.Column(6).Mask = FlexCell.MaskEnum.Numeric
        Me.GridTrabajadores.Column(6).Alignment = FlexCell.AlignmentEnum.RightCenter

        If Me.GridTrabajadores.Rows >= 2 Then
            Me.txtTotalImportePrestaciones.Text = FormatImporteContable(CDbl(FG_Grid_SumaCol(Me.GridTrabajadores, 5).ToString))
            Me.txtTotalSaldoPrestaciones.Text = FormatImporteContable(CDbl(FG_Grid_SumaCol(Me.GridTrabajadores, 6).ToString))
        End If
    End Sub

    Private Sub Cambia_Estado(ByVal pEstado As enumEstados)
        Me.Estado = pEstado

        Select Case Me.Estado
            Case enumEstados.NUEVO
                Me.tsbNuevo.Enabled = True
                Me.tsbGrabar.Enabled = True
                Me.tsbEliminar.Enabled = False
                Me.tsbSaldar.Enabled = False

                Me.CboSemana.Enabled = False
                Me.cboTipoDeduccion.Enabled = True
                Me.lblDisplaySaldo.Visible = False
                Me.TxtSaldo.Visible = False

                If Me._ChildParaGrabar = False Then
                    Me.TxtImporte.Enabled = True
                    Me.TxtDescuento.Enabled = True
                End If

                Me.BtnAgregarSemana.Enabled = False
                Me.BtnBorrarSemana.Enabled = False
                Me.BtnRecorrerSemana.Enabled = False
                Me.btnExtenderTemporada.Enabled = False

                Me.gbDeducciones.Enabled = True
                Me.gbPlanAbonos.Enabled = True
                Me.gbHistorialDeducciones.Enabled = False
                Me.GridHistorialDeducciones.Locked = True

                Me.tsslEstado.Text = "Estado: Agregando nuevo movimiento"
                Me.tssElaboro.Visible = False : Me.tssElaboro.Text = ""


            Case enumEstados.GRABADO
                Me.tsbNuevo.Enabled = True
                Me.tsbGrabar.Enabled = True
                Me.tsbEliminar.Enabled = True
                Me.tsbSaldar.Enabled = False

                Me.CboSemana.Enabled = False
                Me.cboTipoDeduccion.Enabled = False
                Me.lblDisplaySaldo.Visible = True
                Me.TxtSaldo.Visible = True

                'Me.gbDeducciones.Enabled = False
                Me.gbPlanAbonos.Enabled = True
                Me.gbHistorialDeducciones.Enabled = True

                Me.GridHistorialDeducciones.Locked = False

                If Me.oDeducciones.SALDO > 0 Then
                    Me.TxtSaldo.Visible = True
                    Me.lblDisplaySaldo.Visible = True
                    Me.BtnAgregarSemana.Enabled = True
                    Me.BtnBorrarSemana.Enabled = True
                    Me.BtnRecorrerSemana.Enabled = True
                    Me.btnExtenderTemporada.Enabled = False
                    Me.tsbGrabar.Enabled = True
                Else
                    Me.TxtSaldo.Visible = False
                    Me.lblDisplaySaldo.Visible = False
                    Me.BtnAgregarSemana.Enabled = False
                    Me.BtnBorrarSemana.Enabled = False
                    Me.BtnRecorrerSemana.Enabled = False
                    Me.btnExtenderTemporada.Enabled = False
                    Me.tsbGrabar.Enabled = False
                End If

                Me.tsslEstado.Text = "Estado: Consultando movimiento"
                Me.tssElaboro.Visible = True

            Case enumEstados.GENERADO
                Me.tsbNuevo.Enabled = True
                Me.tsbGrabar.Enabled = False
                Me.tsbEliminar.Enabled = False
                Me.tsbSaldar.Enabled = False

                Me.CboSemana.Enabled = False
                Me.cboTipoDeduccion.Enabled = False
                Me.lblDisplaySaldo.Visible = True
                Me.TxtSaldo.Visible = True

                Me.gbDeducciones.Enabled = False
                Me.gbPlanAbonos.Enabled = True
                Me.gbHistorialDeducciones.Enabled = True

                Me.GridHistorialDeducciones.Locked = False

                Me.tsslEstado.Text = "Estado: Consultando movimiento"
                Me.tssElaboro.Visible = True

                If Me.oDeducciones.SALDO > 0 Then
                    Me.TxtSaldo.Visible = True
                    Me.lblDisplaySaldo.Visible = True
                    Me.BtnAgregarSemana.Enabled = True
                    Me.BtnBorrarSemana.Enabled = True
                    Me.BtnRecorrerSemana.Enabled = True
                    Me.btnExtenderTemporada.Enabled = True
                    Me.tsbGrabar.Enabled = True
                    Me.tsbSaldar.Enabled = True
                Else
                    Me.TxtSaldo.Visible = False
                    Me.lblDisplaySaldo.Visible = False
                    Me.BtnAgregarSemana.Enabled = False
                    Me.BtnBorrarSemana.Enabled = False
                    Me.BtnRecorrerSemana.Enabled = False
                    Me.btnExtenderTemporada.Enabled = False
                    Me.tsbGrabar.Enabled = False
                    Me.tsbSaldar.Enabled = False
                End If
        End Select

        Application.DoEvents()
    End Sub

    Public Function Grabar(Optional ByVal bConfirmacion As Boolean = True) As Boolean
        Dim bResultado As Boolean = False
        Dim i As Integer, oTrabajador As Class_CatTrabajadores

        Try
            If bConfirmacion = True Then
            If MsgBox("Deseas grabar la deducción?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "Grabar") = MsgBoxResult.No Then
                Return False
            End If
        End If

            If Me.ValidarDeduccion() = False Then
                Return False
            End If

            Me.Totales()

            oTrabajador = New Class_CatTrabajadores(Me.txtCodigoTrabajador.Text, True)

            With Me.oDeducciones
                .CODIGO_TIPO_DEDUCCION = CInt(Me.cboTipoDeduccion.SelectedValue)
                .CODIGO_TRABAJADOR = oTrabajador.CODIGO_TRABAJADOR
                .ID_NOMINA_SEMANA = CInt(Me.txtIdSemana.Text)
                .IMPORTE = CDbl(Me.TxtImporte.Text)
                .SALDO = CDbl(Me.TxtSaldo.Text)
                .DESCUENTO_SEMANAL = CDbl(Me.TxtDescuento.Text)
                .CONCEPTO = Me.TxtConcepto.Text
                .ID_NOMIA_PERCEPCION = Me._ID_NOMINA_PERCEPCION ' CInt(Me.LblId_Percepcion.Text)
                If Me._ChildParaGrabar = True Then
                    If .Insertar() = False Then
                        MsgBox("Error al tratar de insertar la hoja.", MsgBoxStyle.Exclamation, Me.Text)
                        Return False
                    End If
                Else
                    If Me.Estado = enumEstados.NUEVO Then
                        If .Insertar() = False Then
                            MsgBox("Error al tratar de insertar la hoja.", MsgBoxStyle.Exclamation, Me.Text)
                            Return False
                        End If
                    Else
                        If .Actualizar() = False Then
                            MsgBox("Error al tratar de actualizar la hoja.", MsgBoxStyle.Exclamation, Me.Text)
                            Return False
                        End If
                    End If
                End If

                'se graba el detalle
                For i = 1 To Me.GridPlanAbonos.Rows - 1
                    If valorNumerico(Me.GridPlanAbonos.Cell(i, Me.igyDescuento).Text) <= 0 Then
                        MsgBox("El descuento tiene que ser mayor a 0.", MsgBoxStyle.Exclamation, Me.Text)
                        Return False
                    End If
                    If Me.GridPlanAbonos.Cell(i, Me.igyAbonado).Text = "0" Then
                        .oDeduccionDetalle.ID_DEDUCCION_GLOBAL = .ID_DEDUCCION_GLOBAL
                        .oDeduccionDetalle.NUMERO_SEMANA = CInt(Me.GridPlanAbonos.Cell(i, Me.igySemana).Text)
                        .oDeduccionDetalle.DESCUENTO = valorNumerico(Me.GridPlanAbonos.Cell(i, Me.igyDescuento).Text)
                        .oDeduccionDetalle.AMORTIZACION = valorNumerico(Me.GridPlanAbonos.Cell(i, Me.igySaldo).Text)
                        .oDeduccionDetalle.ESTATUS_ABONADO = Me.GridPlanAbonos.Cell(i, Me.igyAbonado).Text
                        '.oDeduccionDetalle.TEMPORADA = CInt(Me.GridPlanAbonos.Cell(i, Me.igyTemporada).Text)
                        .oDeduccionDetalle.ID_DEDUCCION_DETALLE = 0

                        If .oDeduccionDetalle.GrabaDetalleDeduccion("INSERTAR") = False Then
                            MsgBox("Error al tratar de grabar el detalle de la deducción.", MsgBoxStyle.Exclamation, Me.Text)
                            Return False
                        End If
                    End If
                Next

                bResultado = True

                If bConfirmacion = True And bResultado = True Then
                    MsgBox("Deducción grabada satisfactoriamente.", MsgBoxStyle.Information, Me.Text)
                End If

            End With
        Catch ex As Exception
            HandleError(Me.Name, "Grabar", ex)
        End Try

        Return bResultado
    End Function

    Public Function Eliminar(Optional ByVal bConfirmacion As Boolean = True) As Boolean
        Dim bResultado As Boolean = False
        Try
            If bConfirmacion = True Then
                If MsgBox("Deseas eliminar la deducción?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "Eliminar") = MsgBoxResult.No Then
                    Return False
                End If
            End If

            If Me._ID_DEDUCCION > 0 Then
                Dim oDeducciones As New Class_NominaDeduccionesGlobal(Me._ID_DEDUCCION)

                If oDeducciones.ID_NOMIA_PERCEPCION.ToString <> "0" Then
                    If oDeducciones.IMPORTE <> oDeducciones.SALDO Then
                        MsgBox("La deduccion ya tiene abonos no se puede eliminar.", MsgBoxStyle.Exclamation, Me.Text)
                        Return False
                    End If

                    Dim sql As New Class_find("SELECT NOMINA_GENERADA FROM NOMINA_SEMANA WHERE ID_NOMINA_SEMANA=" & Me.CboSemana.SelectedValue.ToString)
                    If sql.Result1 = "1" Then
                        MsgBox("La semana ya esta generada.", MsgBoxStyle.Exclamation, Me.Text)
                        Return False
                    End If
                    If oDeducciones.EliminaDeduccion() = True Then
                        Dim oHoja As New Class_NominaHoja
                        oHoja.oHojaPercepcion.ID_NOMINA_PERCEPCION = oDeducciones.ID_NOMIA_PERCEPCION
                        If oHoja.oHojaPercepcion.EliminaDetallePercepcion() = True Then
                            bResultado = True
                        End If
                    End If
                Else
                    If oDeducciones.EliminaDeduccion() = True Then
                        bResultado = True
                        'MsgBox("Se elimino correctamente.", MsgBoxStyle.Information, Me.Text)
                        Me.ConsultarTrabajador()
                    Else
                        MsgBox("No se puedo eliminar.", MsgBoxStyle.Information, Me.Text)
                        Return False
                    End If
                End If
            End If

            MsgBox("Se eliminó correctamente.", MsgBoxStyle.Information, Me.Text)

        Catch ex As Exception
            HandleError(Me.Name, "Eliminar", ex)
        End Try

        Return bResultado
    End Function

    Public Function Consultar(ByVal iDeduccion As Integer) As Boolean
        Dim bResultado As Boolean = False
        Dim dTabla As DataTable
        Me.oDeducciones = New Class_NominaDeduccionesGlobal(iDeduccion)

        Try
            If Me.oDeducciones.Existe = False Then
                Me.Inicializa()
                Me.Cambia_Estado(enumEstados.NUEVO)
                Return False
            Else
                Me.DesplegarTipoDeduccion(True)

                Dim oTrabajador As New Class_CatTrabajadores(Me.oDeducciones.CODIGO_X_TEMPORADA, True)
                Dim oSemana As New Class_NominaSemana(Me.oDeducciones.ID_NOMINA_SEMANA)

                Me.cboTipoDeduccion.SelectedValue = Me.oDeducciones.CODIGO_TIPO_DEDUCCION
                Me.txtCodigoTrabajador.Text = Me.oDeducciones.CODIGO_X_TEMPORADA.ToString
                Me.lblNombreTrabajador.Text = oTrabajador.NOMBRE_COMPLETO_APELLIDO
                'Me.CboSemana.SelectedValue = Me.oDeducciones.ID_NOMINA_SEMANA
                Me.txtIdSemana.Text = Me.oDeducciones.ID_NOMINA_SEMANA.ToString
                Me.txtNumeroSemana.Text = oSemana.NUMERO_SEMANA.ToString
                Me.LlenaFechasSemana(oSemana.ID_NOMINA_TEMPORADA)
                'Me.CboSemana.Text = Me.oDeducciones.NUMERO_SEMANA.ToString
                Me.TxtImporte.Text = FormatImporteContable(Me.oDeducciones.IMPORTE)
                Me.TxtSaldo.Text = FormatImporteContable(Me.oDeducciones.SALDO)
                Me.TxtDescuento.Text = FormatImporteContable(oDeducciones.DESCUENTO_SEMANAL)
                Me.TxtConcepto.Text = oDeducciones.CONCEPTO.ToString.ToUpper
                Me._ID_DEDUCCION = oDeducciones.ID_DEDUCCION_GLOBAL
                Me.LblId_Percepcion.Text = oDeducciones.ID_NOMIA_PERCEPCION.ToString
                Me._ID_NOMINA_PERCEPCION = oDeducciones.ID_NOMIA_PERCEPCION

                dTabla = Me.oDeducciones.ObtenerDetalle

                Me.InicializaGridPlan()

                Me.GridPlanAbonos.Rows = 1
                For Each dRow As DataRow In dTabla.Rows
                    Me.GridPlanAbonos.AddItem(dRow("ID_DEDUCCION_DETALLE").ToString & Chr(9) & dRow("NUMERO_SEMANA").ToString & Chr(9) & dRow("DESCUENTO").ToString & Chr(9) & dRow("AMORTIZACION").ToString & Chr(9) &
                                              dRow("ESTATUS_ABONADO").ToString & Chr(9) & dRow(5).ToString & Chr(9) & "".ToString & Chr(9))
                Next
                dTabla.Dispose()

                Me.FormateaGridPlanAbonos()
            End If

            Me.tssElaboro.Text = "Ultima modificación : " & Format(Me.oDeducciones.FECHA_SERVIDOR, "dd/MMM/yyyy hh:mm tt") & " por " & Me.oDeducciones.NOMBRE_USUARIO_GRABO.ToString

            Me.Cambia_Estado(enumEstados.GRABADO)

            Me.Totales()
            bResultado = True

            Dim sql As New Class_find("SELECT NOMINA_GENERADA FROM NOMINA_SEMANA WHERE ID_NOMINA_SEMANA=" & Me.oDeducciones.ID_NOMINA_SEMANA.ToString)
            If sql.Result1 = "1" Then
                Me.Cambia_Estado(enumEstados.GENERADO)
            End If

            Me.FormateaGridPlanAbonos()

        Catch ex As Exception
            HandleError(Me.Name, "Consultar", ex)
        End Try

        Return bResultado
    End Function

    Public Function ConsultarTrabajador() As Boolean
        Dim bResultado As Boolean = False
        Try
            Dim dTabla As DataTable
            Dim oTrabajador As New Class_CatTrabajadores(Me.txtCodigoTrabajador.Text, True)
            Me.Inicializa()

            If oTrabajador.Existe = False Then
                Me.lblNombreTrabajador.Text = ""
                Return False
            End If

            Me.txtCodigoTrabajador.Text = oTrabajador.CODIGO_X_TEMPORADA
            Me.lblNombreTrabajador.Text = oTrabajador.NOMBRE_COMPLETO_APELLIDO
            Me.txtCodigoTrabajador.Enabled = False

            dTabla = oTrabajador.ObtenerHistorialDeducciones
            Me.GridHistorialDeducciones.Rows = 1
            For Each dRow As DataRow In dTabla.Rows
                Me.GridHistorialDeducciones.AddItem(dRow("ID_DEDUCCION_GLOBAL").ToString & Chr(9) & dRow("NUMERO_SEMANA").ToString & Chr(9) & Format(CDate(dRow("FECHA_SERVIDOR").ToString), "dd-MMM-yy") & Chr(9) &
                                                    dRow("IMPORTE").ToString & Chr(9) & dRow("SALDO").ToString & Chr(9))
            Next
            dTabla.Dispose()

            bResultado = True

            Me.FormateaGrid()
            If Me.GridHistorialDeducciones.Rows <= 1 Then
                Me.GridHistorialDeducciones.Rows = 2
            Else
                Me.GridHistorialDeducciones.Cell(1, 1).SetFocus()
            End If
            Me.CboSemana.Focus()
            Me.gbDeducciones.Enabled = True
            Me.gbHistorialDeducciones.Enabled = True
            Me.GridHistorialDeducciones.Locked = False
            Me.gbPlanAbonos.Enabled = True
            Me.DesplegarDeducciones()
            Me.Totales()

        Catch ex As Exception
            HandleError(Me.Name, "ConsultarTrabajador", ex)
        End Try

        Return bResultado
    End Function

    Private Function ValidarDeduccion() As Boolean
        Dim bResultado As Boolean = False

        Try
            Dim i As Integer
            Dim oTrabajador As New Class_CatTrabajadores(Me.txtCodigoTrabajador.Text, True)
            If oTrabajador.Existe = False Then
                MsgBox("El trabajador no existe.", MsgBoxStyle.Exclamation, Me.Text)
                Return False
            End If

            Dim oSemana As New Class_NominaSemana(CInt(Me.txtIdSemana.Text))

            'If oSemana.NOMINA_GENERADA = "1" Then
            '    MsgBox("La semana ya fue generada, no es posible crear una deducción. Favor de verificar.", MsgBoxStyle.Exclamation, Me.Text)
            '    return false
            'End If

            If valorNumerico(Me.TxtSaldo.Text) < 0 Then
                MsgBox("El prestamo no tiene un saldo activo. Favor de verificar.", MsgBoxStyle.Exclamation, Me.Text)
                Return False
            End If

            For i = 1 To Me.GridPlanAbonos.Rows - 1
                If valorNumerico(Me.GridPlanAbonos.Cell(i, Me.igyDescuento).Text) <= 0 Then
                    MsgBox("No debe haber descuentos en ceros. Favor de verificar.", MsgBoxStyle.Exclamation, Me.Text)
                    Return False
                End If
            Next i

            If txtLEN(Me.TxtConcepto.Text) = False Then
                MsgBox("Favor de capturar un concepto a la deducción.", MsgBoxStyle.Exclamation, Me.Text)
                Me.TxtConcepto.Focus()
                Return False
            End If

            If valorNumerico(Me.GridPlanAbonos.Cell(Me.GridPlanAbonos.Rows - 1, Me.igySaldo).Text) <> 0 Then
                MsgBox("El Último saldo del plan de pagos deber ser en ceros. Favor de verificar.", MsgBoxStyle.Exclamation, Me.Text)
                Return False
            End If

            If valorNumerico(Me.txtSuma.Text) <> valorNumerico(Me.TxtImporte.Text) Then
                MsgBox("La suma de los descuentos no es igual al importe. Favor de verificar.", MsgBoxStyle.Exclamation, Me.Text)
                Return False
            End If

            bResultado = True
        Catch ex As Exception
            HandleError(Me.Name, "ValidarDeduccion", ex)
        End Try

        Return bResultado
    End Function

    Private Sub Totales()
        Dim i As Integer
        Me.TxtSaldo.Text = FormatImporteContable(valorNumerico(Me.TxtImporte.Text))

        For i = 1 To Me.GridPlanAbonos.Rows - 1
            If Me.GridPlanAbonos.Cell(i, Me.igyAbonado).Text = "1" Then
                Me.TxtSaldo.Text = FormatImporteContable(valorNumerico(Me.TxtSaldo.Text) - valorNumerico(Me.GridPlanAbonos.Cell(i, Me.igyDescuento).Text))
            End If
        Next

        Me.txtSuma.Text = FormatImporteContable(CDbl(FG_Grid_SumaCol(Me.GridPlanAbonos, Me.igyDescuento).ToString))

        If Me.GridHistorialDeducciones.Rows >= 2 Then
            Me.txtSumaImportes.Text = FormatImporteContable(CDbl(FG_Grid_SumaCol(Me.GridHistorialDeducciones, Me.igyHistorialImporte).ToString))
            Me.txtSumaSaldos.Text = FormatImporteContable(CDbl(FG_Grid_SumaCol(Me.GridHistorialDeducciones, Me.igyHistorialSaldo).ToString))
        End If
    End Sub

    Private Sub GestionaGrid(ByVal e As System.Windows.Forms.KeyEventArgs)
        Dim Columna As Integer, Renglon As Integer
        Dim dPercipcion As Double
        Dim dSemanas As Double
        Dim dSaldo As Double
        Dim iSemana As Double
        Try
            Columna = Me.GridPlanAbonos.Selection.FirstCol
            Renglon = Me.GridPlanAbonos.Selection.FirstRow

            Select Case e.KeyCode
                Case Keys.Enter
                    Select Case Columna
                        Case Me.igyDescuento
                            dPercipcion = valorNumerico(Me.GridPlanAbonos.Cell(Renglon, Me.igyDescuento).Text)

                            If dPercipcion <= 0 Then
                                MsgBox("La cantidad debe de ser mayor a 0.", MsgBoxStyle.Exclamation, Me.Text)
                                Me.GridPlanAbonos.Cell(Renglon, Me.igySemana).SetFocus()
                                Exit Sub
                            End If

                            If txtLEN(dPercipcion.ToString) = True Then
                                If Renglon = 1 Then
                                    If valorNumerico(Me.GridPlanAbonos.Cell(Renglon, Me.igyDescuento).Text) > valorNumerico(Me.TxtDescuento.Text) Then
                                        MsgBox("El descuento semanal principal es mayor al descuento.", MsgBoxStyle.Exclamation, Me.Text)
                                        Me.GridPlanAbonos.Cell(Renglon, Me.igyDescuento).Text = ""
                                        Me.GridPlanAbonos.Cell(Renglon, Me.igySemana).SetFocus()
                                        Exit Sub
                                    Else
                                        If valorNumerico(Me.GridPlanAbonos.Cell(Renglon, Me.igyDescuento).Text) > valorNumerico(Me.TxtSaldo.Text) Then
                                            MsgBox("El descuento semanal es mayor al saldo.", MsgBoxStyle.Exclamation, Me.Text)
                                        Else
                                            Me.TxtDescuento.Text = Me.GridPlanAbonos.Cell(Renglon, Me.igyDescuento).Text
                                        End If
                                    End If
                                Else
                                    If valorNumerico(Me.GridPlanAbonos.Cell(Renglon, Me.igyDescuento).Text) > valorNumerico(Me.GridPlanAbonos.Cell(Renglon - 1, Me.igySaldo).Text) Then
                                        MsgBox("El descuento semanal es mayor al importe.", MsgBoxStyle.Exclamation, Me.Text)
                                        Me.GridPlanAbonos.Cell(Renglon, Me.igyDescuento).Text = ""
                                        Me.GridPlanAbonos.Cell(Renglon, Me.igySemana).SetFocus()
                                        Exit Sub
                                    Else
                                        dSemanas = valorNumerico(Me.GridPlanAbonos.Cell(Renglon - 1, Me.igySaldo).Text) / dPercipcion

                                        Dim oTemporada As New Class_NominaTemporada(Plaza.oSisPlazaNomina.NOMINA_ID_NOMINA_TEMPORADA_ACTIVA)
                                        If valorNumerico(Me.GridPlanAbonos.Cell(Renglon, Me.igySemana).Text) + CInt(-Int(-dSemanas)) > oTemporada.NUMERO_SEMANAS Then
                                            dSaldo = valorNumerico(Me.GridPlanAbonos.Cell(Renglon - 1, Me.igySaldo).Text)
                                            iSemana = valorNumerico(Me.GridPlanAbonos.Cell(Renglon, Me.igySemana).Text)
                                            'Me.GridPlanAbonos.Rows = CInt(oTemporada.NUMERO_SEMANAS - valorNumerico(Me.GridPlanAbonos.Cell(Renglon, Me.igySemana).Text)) + 2
                                            Me.GridPlanAbonos.Rows = Renglon + oTemporada.NUMERO_SEMANAS - 1

                                            For i As Integer = Renglon To Me.GridPlanAbonos.Rows - 1
                                                Me.GridPlanAbonos.Cell(i, Me.igyIdDeduccionDetalle).Text = ""
                                                If oTemporada.NUMERO_SEMANAS > iSemana Then
                                                    Me.GridPlanAbonos.Cell(i, Me.igySemana).Text = iSemana.ToString
                                                    If dSaldo < valorNumerico(Me.GridPlanAbonos.Cell(Renglon, Me.igyDescuento).Text) And dSaldo > 0 Then
                                                        Me.GridPlanAbonos.Cell(i, Me.igyDescuento).Text = "" & FormatImporteContable(dSaldo)
                                                        dSaldo = dSaldo - dSaldo
                                                    Else
                                                        Me.GridPlanAbonos.Cell(i, Me.igyDescuento).Text = "" & FormatImporteContable(valorNumerico(Me.GridPlanAbonos.Cell(Renglon, Me.igyDescuento).Text))
                                                        dSaldo = dSaldo - valorNumerico(Me.GridPlanAbonos.Cell(Renglon, Me.igyDescuento).Text)
                                                    End If
                                                    Me.GridPlanAbonos.Cell(i, Me.igySaldo).Text = "" & FormatImporteContable(dSaldo)
                                                    Me.GridPlanAbonos.Cell(i, Me.igyAbonado).Text = "0"
                                                    Me.GridPlanAbonos.Cell(i, Me.igyTemporada).Text = Plaza.oSisPlazaNomina.NOMINA_ID_NOMINA_TEMPORADA_ACTIVA.ToString
                                                ElseIf oTemporada.NUMERO_SEMANAS = iSemana Then
                                                    Me.GridPlanAbonos.Cell(i, Me.igySemana).Text = oTemporada.NUMERO_SEMANAS.ToString
                                                    Me.GridPlanAbonos.Cell(i, Me.igySaldo).Text = FormatImporteContable(0)
                                                    Me.GridPlanAbonos.Cell(i, Me.igyAbonado).Text = "0"
                                                    Me.GridPlanAbonos.Cell(i, Me.igyDescuento).Text = "" & FormatImporteContable(dSaldo)
                                                    Me.GridPlanAbonos.Cell(i, Me.igyTemporada).Text = Plaza.oSisPlazaNomina.NOMINA_ID_NOMINA_TEMPORADA_ACTIVA.ToString
                                                End If
                                                iSemana = iSemana + 1
                                            Next i

                                            Me.FormateaGridPlanAbonos()
                                        Else
                                            Me.GridPlanAbonos.Rows = Renglon + CInt(-Int(-dSemanas))
                                            dSaldo = valorNumerico(Me.GridPlanAbonos.Cell(Renglon - 1, Me.igySaldo).Text)
                                            iSemana = valorNumerico(Me.GridPlanAbonos.Cell(Renglon, Me.igySemana).Text)

                                            For i As Integer = Renglon To Me.GridPlanAbonos.Rows - 1
                                                Me.GridPlanAbonos.Cell(i, Me.igyIdDeduccionDetalle).Text = ""
                                                Me.GridPlanAbonos.Cell(i, Me.igySemana).Text = ((iSemana - 1) + 1).ToString

                                                If dSaldo < valorNumerico(Me.GridPlanAbonos.Cell(Renglon, Me.igyDescuento).Text) And dSaldo > 0 Then
                                                    Me.GridPlanAbonos.Cell(i, Me.igyDescuento).Text = "" & FormatImporteContable(dSaldo)
                                                    dSaldo = dSaldo - dSaldo
                                                Else
                                                    Me.GridPlanAbonos.Cell(i, Me.igyDescuento).Text = "" & FormatImporteContable(valorNumerico(Me.GridPlanAbonos.Cell(Renglon, Me.igyDescuento).Text))
                                                    dSaldo = dSaldo - valorNumerico(Me.GridPlanAbonos.Cell(Renglon, Me.igyDescuento).Text)
                                                End If
                                                Me.GridPlanAbonos.Cell(i, Me.igySaldo).Text = "" & FormatImporteContable(dSaldo)
                                                Me.GridPlanAbonos.Cell(i, Me.igyAbonado).Text = "0"
                                                Me.GridPlanAbonos.Cell(i, Me.igyTemporada).Text = oTemporada.ID_NOMINA_TEMPORADA.ToString
                                                iSemana = iSemana + 1
                                            Next i

                                            Me.FormateaGridPlanAbonos()
                                        End If

                                        'If valorNumerico(Me.GridPlanAbonos.Cell(Renglon - 1, Me.igySemana).Text) + CInt(-Int(-dSemanas)) > oTemporada.NUMERO_SEMANAS And valorNumerico(Me.GridPlanAbonos.Cell(Renglon - 1, Me.igyTemporada).Text) <> Plaza.oSisPlazaNomina.NOMINA_ID_NOMINA_TEMPORADA_ACTIVA Then
                                        '    'MsgBox("El número de semanas generadas pasan del número de las semanas de la temporada actual .", MsgBoxStyle.Exclamation, Me.Text)
                                        '    'Exit Sub
                                        '    dSaldo = valorNumerico(Me.GridPlanAbonos.Cell(Renglon - 1, Me.igySaldo).Text)
                                        '    iSemana = valorNumerico(Me.GridPlanAbonos.Cell(Renglon - 1, Me.igySemana).Text)
                                        '    Me.GridPlanAbonos.Rows = CInt(oTemporada.NUMERO_SEMANAS - valorNumerico(Me.GridPlanAbonos.Cell(1, Me.igySemana).Text)) + 2

                                        '    For i As Integer = Renglon To Me.GridPlanAbonos.Rows - 1
                                        '        Me.GridPlanAbonos.Cell(i, Me.igyIdDeduccionDetalle).Text = ""
                                        '        If oTemporada.NUMERO_SEMANAS > (valorNumerico(Me.GridPlanAbonos.Cell(i - 1, Me.igySemana).Text) + 1) Then
                                        '            Me.GridPlanAbonos.Cell(i, Me.igySemana).Text = (valorNumerico(Me.GridPlanAbonos.Cell(i - 1, Me.igySemana).Text) + 1).ToString
                                        '            If dSaldo < valorNumerico(Me.GridPlanAbonos.Cell(Renglon, Me.igyDescuento).Text) And dSaldo > 0 Then
                                        '                Me.GridPlanAbonos.Cell(i, Me.igyDescuento).Text = "" & FormatImporteContable(dSaldo)
                                        '                dSaldo = dSaldo - dSaldo
                                        '            Else
                                        '                Me.GridPlanAbonos.Cell(i, Me.igyDescuento).Text = "" & FormatImporteContable(valorNumerico(Me.GridPlanAbonos.Cell(Renglon, Me.igyDescuento).Text))
                                        '                dSaldo = dSaldo - valorNumerico(Me.GridPlanAbonos.Cell(Renglon, Me.igyDescuento).Text)
                                        '            End If
                                        '            Me.GridPlanAbonos.Cell(i, Me.igySaldo).Text = "" & FormatImporteContable(dSaldo)
                                        '            Me.GridPlanAbonos.Cell(i, Me.igyAbonado).Text = "0"
                                        '            Me.GridPlanAbonos.Cell(i, Me.igyTemporada).Text = Plaza.oSisPlazaNomina.NOMINA_ID_NOMINA_TEMPORADA_ACTIVA.ToString
                                        '        ElseIf oTemporada.NUMERO_SEMANAS = (valorNumerico(Me.GridPlanAbonos.Cell(i - 1, Me.igySemana).Text) + 1) Then
                                        '            Me.GridPlanAbonos.Cell(i, Me.igySemana).Text = oTemporada.NUMERO_SEMANAS.ToString
                                        '            Me.GridPlanAbonos.Cell(i, Me.igySaldo).Text = FormatImporteContable(0)
                                        '            Me.GridPlanAbonos.Cell(i, Me.igyAbonado).Text = "0"
                                        '            Me.GridPlanAbonos.Cell(i, Me.igyDescuento).Text = "" & FormatImporteContable(dSaldo)
                                        '            Me.GridPlanAbonos.Cell(i, Me.igyTemporada).Text = Plaza.oSisPlazaNomina.NOMINA_ID_NOMINA_TEMPORADA_ACTIVA.ToString
                                        '        End If
                                        '    Next i

                                        '    Me.FormateaGridPlanAbonos()
                                        'Else
                                        '    Me.GridPlanAbonos.Rows = Renglon + CInt(-Int(-dSemanas))
                                        '    dSaldo = valorNumerico(Me.GridPlanAbonos.Cell(Renglon - 1, Me.igySaldo).Text)
                                        '    iSemana = valorNumerico(Me.GridPlanAbonos.Cell(Renglon - 1, Me.igySemana).Text)

                                        '    For i As Integer = Renglon To Me.GridPlanAbonos.Rows - 1
                                        '        Me.GridPlanAbonos.Cell(i, Me.igyIdDeduccionDetalle).Text = ""
                                        '        Me.GridPlanAbonos.Cell(i, Me.igySemana).Text = (valorNumerico(Me.GridPlanAbonos.Cell(i - 1, Me.igySemana).Text) + 1).ToString
                                        '        If dSaldo < valorNumerico(Me.GridPlanAbonos.Cell(Renglon, Me.igyDescuento).Text) And dSaldo > 0 Then
                                        '            Me.GridPlanAbonos.Cell(i, Me.igyDescuento).Text = "" & FormatImporteContable(dSaldo)
                                        '            dSaldo = dSaldo - dSaldo
                                        '        Else
                                        '            Me.GridPlanAbonos.Cell(i, Me.igyDescuento).Text = "" & FormatImporteContable(valorNumerico(Me.GridPlanAbonos.Cell(Renglon, Me.igyDescuento).Text))
                                        '            dSaldo = dSaldo - valorNumerico(Me.GridPlanAbonos.Cell(Renglon, Me.igyDescuento).Text)
                                        '        End If
                                        '        Me.GridPlanAbonos.Cell(i, Me.igySaldo).Text = "" & FormatImporteContable(dSaldo)
                                        '        Me.GridPlanAbonos.Cell(i, Me.igyAbonado).Text = "0"
                                        '        Me.GridPlanAbonos.Cell(i, Me.igyTemporada).Text = oTemporada.ID_NOMINA_TEMPORADA.ToString
                                        '    Next i

                                        '    Me.FormateaGridPlanAbonos()
                                        'End If
                                    End If
                                End If
                            End If
                    End Select

                    Me.Totales()
            End Select
        Catch ex As Exception
            HandleError(Me.Name, "GestionaGrid", ex)
        End Try
    End Sub

    Public Function SaldarPrestamo() As Boolean
        If MsgBox("Deseas saldar la deducción?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "Grabar") = MsgBoxResult.No Then
            Exit Function
        End If

        If Me.ValidarDeduccion() = False Then
            Exit Function
        End If

        Me.Totales()

        If Me._ID_DEDUCCION > 0 Then
            Dim oDeducciones As New Class_NominaDeduccionesGlobal(Me._ID_DEDUCCION)
            If oDeducciones.SALDO <= 0 Then
                MsgBox("El prestamo debe tener un saldo que liquidar.", MsgBoxStyle.Information, Me.Text)
                SaldarPrestamo = False
                Exit Function
            End If

            If oDeducciones.IMPORTE <> oDeducciones.SALDO Then
                If oDeducciones.SaldarDeducciones() = True Then
                    'MsgBox("Se elimino correctamente.", MsgBoxStyle.Information, Me.Text)
                    Me.ConsultarTrabajador()
                Else
                    MsgBox("No se puedo saldar el prestamo.", MsgBoxStyle.Information, Me.Text)
                    SaldarPrestamo = False
                    Exit Function
                End If
            Else
                MsgBox("No se puedo saldar el prestamo.", MsgBoxStyle.Information, Me.Text)
                SaldarPrestamo = False
                Exit Function
            End If
        Else
            Exit Function
        End If
        SaldarPrestamo = True
        MsgBox("El prestamo se saldo correctamente.", MsgBoxStyle.Information, Me.Text)
    End Function

    Private Sub LlenaFechasSemana(ByVal iTemporadaDeduccion As Integer)
        Try
            If Me.txtIdSemana.Text = "" Then
                Exit Sub
            End If
            Dim sql As New Class_find("SELECT DATEADD(DAY, (" & (CInt(Me.txtNumeroSemana.Text) - 1).ToString & "*7),FECHA1),DATEADD(DAY," & (CInt(Me.txtNumeroSemana.Text) - 1).ToString & "*7,FECHA1)+6 FROM NOMINA_TEMPORADAS WHERE ID_NOMINA_TEMPORADA=" & iTemporadaDeduccion)
            Me.DtpFecha1.Value = CDate(sql.Result1.ToString)
            Me.DtpFecha2.Value = CDate(sql.Result2.ToString)
        Catch ex As Exception
            HandleError(Me.Name, "LlenaFechasSemana", ex)
        End Try
    End Sub

#End Region

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim x As New VoiceCode
        'Debug.Print(x.Compute("10850510002011", "46587443HG234", CDate("2012-12-22")))
        'Debug.Print(VoiceCodex("10850510002011", "46587443HG234", CDate("2012-12-22")))
        'Debug.Print(VoiceCodex.compute("10850510002011", "46587443HG234", CDate("2012-12-22")))
        'Dim xx As New PTI_dll.VoiceCode("", "", CDate("2012-12-22"))
        'x.
        'M'e.TextBox3.Text = VoiceCode("10850510002011", "46587443HG234", CDate("2012-12-22")) 'VoiceCode("", "", "")
        'Me.TextBox3.Text = PTI_dll.VoiceCode.compute("10850510002011", "46587443HG234", CDate("2012-12-22"))
    End Sub

    Private Sub btnExtenderTemporada_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExtenderTemporada.Click
        Me.ExternderSemanasSiguienteTemporada()
    End Sub
End Class