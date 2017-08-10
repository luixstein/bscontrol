Option Strict On

Imports System.Data.SqlClient

Public Class Frm_Nomina_CapturaHoja
    Private _ID_NOMINA_DIA As Integer
    Private _ID_NOMINA_HOJA As Integer

    Private oActividades As New Class_CatActividades
    Private oHoja As New Class_NominaHoja
    Private oFormaDeducciones As Frm_Nomina_Deducciones
    Dim oSemana As New Class_NominaSemana

    Private Estado As enumEstados
    Public ModoPercepcion As enumModoPercepcion

#Region "Columnas grid"
    Private igyCodigo As Short = 1
    Private igyDescripcion As Short = 2
    Private igyPercepcion As Short = 3
    Private igyCodigoPercepcion As Short = 4
    Private igyRembolsable As Short = 5
    Private igyImporte As Short = 6
    Private igyIdNominaPercepcion As Short = 7
    Private igyConfirmar As Short = 8
    Private igyJornales As Short = 9
    Private igyCajasCortadas As Short = 10
#End Region

    Private dImporteSubactividad As Double = 0

    Private Enum enumEstados
        NUEVO
        GRABADO
        GENERADA
    End Enum

    Public Enum enumModoPercepcion
        PERCECION
        OTRA_PERCEPCION
    End Enum

#Region "Propiedades"
    Public WriteOnly Property ID_NOMINA_HOJA() As Integer
        Set(ByVal Value As Integer)
            Me._ID_NOMINA_HOJA = Value
        End Set
    End Property

    Public WriteOnly Property ID_NOMINA_DIA() As Integer
        Set(ByVal Value As Integer)
            Me._ID_NOMINA_DIA = Value
        End Set
    End Property
#End Region

#Region "Opciones"
    Private Sub tsbNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbNuevo.Click
        Me.Cambia_Estado(enumEstados.NUEVO)
        Me.Inicializa()
        Me.DesplegarHojas(True)
    End Sub

    Private Sub tsbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGrabar.Click
        If Me.Grabar() = True Then
            Me.tsbNuevo.PerformClick()
        End If
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub

    Private Sub tsbEliminar_Click(sender As Object, e As EventArgs) Handles tsbEliminar.Click
        Me.Eliminar()
    End Sub

    Private Sub btnHojaAnterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHojaAnterior.Click
        Me.NavegadorHojas("Anterior")
    End Sub

    Private Sub btnHojaSiguiente_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHojaSiguiente.Click
        Me.NavegadorHojas("Siguiente")
    End Sub
#End Region

#Region "Eventos de objetos"

#Region "Eventos"

    Private Sub Frm_Nomina_CapturaHoja_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Me.DesplegarHojas()
        'Me.DesplegarCentroCosto()
        Me.DesplegarConceptoActividad()
        Me.DesplegarCultivos()
        Me.DesplegarMercados()
        Me.DesplegarLotes()
        Me.DesplegarTipoPercepcion()
        Me.DesplegarPuntoPago()
        Me.DesplegarHoras()

        Try
            oSemana = New Class_NominaSemana(CInt(Me.lblIdSemana.Text))

            If Me.ModoPercepcion = enumModoPercepcion.PERCECION Then
                Me.Inicializa()
                Me.Cambia_Estado(enumEstados.NUEVO)

                If Me._ID_NOMINA_HOJA.ToString <> "0" Then
                    Me.DesplegarHojas()
                    Me.cboHojas.SelectedValue = CInt(Me._ID_NOMINA_HOJA.ToString)
                    Me.Consultar()
                Else
                    Me.DesplegarHojas(True)
                End If
            Else
                Me.Inicializa()
                Me.Cambia_Estado(enumEstados.NUEVO)

                If Me._ID_NOMINA_HOJA.ToString <> "0" Then
                    Me.DesplegarHojas()
                    Me.cboHojas.SelectedValue = CInt(Me._ID_NOMINA_HOJA.ToString)
                    Me.Consultar()
                Else
                    Me.DesplegarHojas(True)
                End If

                Me.tsbGrabar.Visible = False

            End If

            If oSemana.NOMINA_GENERADA = "1" Then
                Me.Cambia_Estado(enumEstados.GENERADA)
            End If

        Catch ex As Exception
            HandleError(Me.Name, "Frm_Nomina_CapturaHoja_Load", ex)
        End Try
    End Sub

    Private Sub txtActividad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtActividad.KeyDown
        Try
            Dim sText As String

            Me.oActividades = New Class_CatActividades
            If txtLEN(Me.cboConceptoActividad.SelectedValue.ToString) = True Then
                Me.oActividades.CODIGO_CONCEPTO_ACTIVIDAD = Me.cboConceptoActividad.SelectedValue.ToString
            Else
                MsgBox("Favor de seleccionar una actividad.", MsgBoxStyle.Exclamation, Me.Text)
                Exit Sub
            End If

            Select Case e.KeyCode
                Case Keys.F6
Buscar:
                    sText = Me.oActividades.BusquedaVisual_PorDescripcion
                    If txtLEN(sText) = True Then Me.txtActividad.Text = sText

                Case Keys.Enter
                    If txtLEN(Me.txtActividad.Text) = False Then
                        Me.lblNombreActividad.Text = "" : GoTo Buscar : Exit Sub
                    End If

                    Me.oActividades = New Class_CatActividades
                    Me.oActividades.CODIGO_ACTIVIDAD = CInt(Me.txtActividad.Text)

                    If Me.oActividades.Consultar = False Then
                        Me.lblNombreActividad.Text = "" : GoTo Buscar : Exit Sub
                    End If

                    If Me.oActividades.ESTATUS_ACTIVIDAD = "B" Then
                        Me.lblNombreActividad.Text = ""
                        Me.txtActividad.Text = "" : GoTo Buscar : Exit Sub
                    End If

                    Me.cboConceptoActividad.SelectedValue = Me.oActividades.CODIGO_CONCEPTO_ACTIVIDAD.ToString
                    Me.lblNombreActividad.Text = Me.oActividades.NOMBRE_ACTIVIDAD

                    'If Me.txtActividad.Text = "388" Then 'Corte
                    '    Me.GridPercepciones.Column(Me.igyCajasCortadas).Visible = True
                    'Else
                    '    Me.GridPercepciones.Column(Me.igyCajasCortadas).Visible = False
                    'End If

                    txtTAB(e)
            End Select

        Catch ex As Exception
            HandleError(Me.Name, "txtActividad_KeyDown", ex)
        End Try
    End Sub

    Private Sub CboLote_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CboLote.KeyDown, _
     CboCultivo.KeyDown, CboMercado.KeyDown, cboHojas.KeyDown, CboPuntoPago.KeyDown, CboTipoPercepcion.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.Send("{TAB}")
        End Select
    End Sub

    Private Sub CboHoras_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CboHoras.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                Me.GridPercepciones.Cell(1, 1).SetFocus()
        End Select
    End Sub

    Private Sub DtpFecha_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtpFecha.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.Send("{TAB}")
        End Select
    End Sub

    Private Sub Grid_CellChange(ByVal Sender As Object, ByVal e As FlexCell.Grid.CellChangeEventArgs) Handles GridPercepciones.CellChange
        If Me.GridPercepciones.ActiveCell.Col = Me.igyPercepcion Then
            Me.Totales()
        ElseIf Me.GridPercepciones.ActiveCell.Col = Me.igyConfirmar Then
            If Me.GridPercepciones.Cell(Me.GridPercepciones.ActiveCell.Row, Me.igyConfirmar).Text = "1" Then
                If Me.GestionaGrabar(Me.GridPercepciones.ActiveCell.Row) = False Then
                    Me.GridPercepciones.Cell(Me.GridPercepciones.ActiveCell.Row, Me.igyConfirmar).Text = "0"
                    Exit Sub
                End If

                Dim iHoja As Integer
                iHoja = CInt(Me.cboHojas.Text)

                Me.oSemana = New Class_NominaSemana(CInt(Me.lblIdSemana.Text))
                Me.cboHojas.Refresh()
                Me.DesplegarHojas()

                Me.cboHojas.Text = iHoja.ToString

                Me.Consultar()

                Me.GridPercepciones.Rows = Me.GridPercepciones.Rows + 1
                Me.GridPercepciones.Cell(Me.GridPercepciones.Rows - 1, Me.igyCodigo).SetFocus()

            ElseIf Me.GridPercepciones.Cell(Me.GridPercepciones.ActiveCell.Row, Me.igyConfirmar).Text = "0" Or Me.GridPercepciones.Cell(Me.GridPercepciones.ActiveCell.Row, Me.igyConfirmar).Text = "" Then 'Si se esta marcando
                Me.GridPercepciones.Cell(Me.GridPercepciones.ActiveCell.Row, Me.igyPercepcion).Locked = False
                Me.GridPercepciones.Cell(Me.GridPercepciones.ActiveCell.Row, Me.igyImporte).Locked = False
            End If
        End If
    End Sub

    Private Sub Grid_KeyPress(ByVal Sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles GridPercepciones.KeyPress, DtpFecha.KeyPress
        If Me.GridPercepciones.ActiveCell.Col = Me.igyPercepcion Then
            txtSoloNumerosEnteros(e)
        End If
        txtNoBeep(e)
    End Sub

    Private Sub Grid_KeyDown(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridPercepciones.KeyDown
        Me.GestionaGridPercepciones(e)
    End Sub

    Private Sub cboHojas_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboHojas.SelectedValueChanged
        Try
            Me.Consultar()
        Catch ex As Exception
            HandleError(Me.Name, "cboHojas", ex)
        End Try
    End Sub

    Private Sub GridPrecepciones_ComboClick(ByVal Sender As Object, ByVal e As FlexCell.Grid.ComboClickEventArgs) Handles GridPercepciones.ComboClick
        Dim renglon As Integer = Me.GridPercepciones.ActiveCell.Row
        Dim sql As New Class_find("SELECT CODIGO_PERCEPCION,REEMBOLSABLE FROM NOMINA_CAT_PERCEPCIONES WHERE NOMBRE='" & Me.GridPercepciones.Cell(renglon, Me.igyPercepcion).Text & "'")
        If txtLEN(sql.Result1) = True Then
            Me.GridPercepciones.Cell(renglon, Me.igyCodigoPercepcion).Text = sql.Result1.ToString
            Me.GridPercepciones.Cell(renglon, Me.igyRembolsable).Text = sql.Result2.ToString
        End If
    End Sub

    Private Sub GridPrecepciones_Click(ByVal Sender As Object, ByVal e As System.EventArgs) Handles GridPercepciones.Click
        If Me.GridPercepciones.ActiveCell.Col = Me.igyConfirmar Then
            'If Me.GridPrecepciones.Cell(Me.GridPrecepciones.ActiveCell.Row, Me.igyConfirmar).Text = "1" Then 'Si se esta desmarcando
            '    'Desbloquear renglon
            '    Me.GridPrecepciones.Cell(Me.GridPrecepciones.ActiveCell.Row, Me.igyPercepcion).Locked = False
            '    Me.GridPrecepciones.Cell(Me.GridPrecepciones.ActiveCell.Row, Me.igyImporte).Locked = False
            '    'Exit Sub
            'ElseIf Me.GridPrecepciones.Cell(Me.GridPrecepciones.ActiveCell.Row, Me.igyConfirmar).Text = "0" Or Me.GridPrecepciones.Cell(Me.GridPrecepciones.ActiveCell.Row, Me.igyConfirmar).Text = "" Then 'Si se esta marcando
            '    If Me.GestionaGrabar(Me.GridPrecepciones.ActiveCell.Row) = False Then
            '        Me.GridPrecepciones.Cell(Me.GridPrecepciones.ActiveCell.Row, Me.igyConfirmar).Text = "1"
            '        Exit Sub
            '    End If
            '    Me.Consultar()
            '    'Bloquear renglon
            'End If
        End If
    End Sub

    'Private Sub CboCentroCosto_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Try
    '        If Me.CboCentroCosto.Text = "" Then
    '            Exit Sub
    '        End If
    '        Dim sql As New Class_find("select CODIGO_CULTIVO from NOMINA_CAT_CENTROS_COSTOS WHERE CODIGO_CENTRO_COSTO=" & Me.CboCentroCosto.SelectedValue.ToString)
    '        If txtLEN(sql.Result1.ToString) = True Then
    '            Me.CboCultivo.SelectedValue = sql.Result1.ToString
    '        Else
    '            Me.CboCultivo.SelectedIndex = -1
    '        End If

    '    Catch ex As Exception
    '        HandleError(Me.Name, "CboCentroCosto_SelectedValueChanged", ex)
    '    End Try
    'End Sub

    Private Sub txtCentroCosto_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCentroCosto.KeyDown
        Try
            Dim sText As String, oCentroCosto As Class_CatCentroCostos

            Select Case e.KeyCode
                Case Keys.F6
Buscar:
                    oCentroCosto = New Class_CatCentroCostos
                    sText = oCentroCosto.BusquedaVisual_PorDescripcion
                    If txtLEN(sText) = True Then
                        Me.txtCentroCosto.Text = sText
                        GoTo Enter : Return
                    End If

                Case Keys.Enter
Enter:
                    If txtLEN(Me.txtCentroCosto.Text) = False Then
                        Me.lblCentroCosto.Text = "" : GoTo Buscar : Exit Sub
                    End If

                    oCentroCosto = New Class_CatCentroCostos(CInt(Me.txtCentroCosto.Text))

                    If oCentroCosto.EXISTE = True Then
                        Me.txtCentroCosto.Text = oCentroCosto.CODIGO_CENTRO_COSTO.ToString
                        Me.lblCentroCosto.Text = oCentroCosto.NOMBRE_CENTRO_COSTO

                        If txtLEN(oCentroCosto.CODIGO_CULTIVO) = True Then
                            Me.CboCultivo.SelectedValue = oCentroCosto.CODIGO_CULTIVO
                        Else
                            Me.CboCultivo.SelectedIndex = -1
                        End If

                    Else
                        Me.lblCentroCosto.Text = ""
                        Me.CboCultivo.SelectedIndex = -1
                        GoTo Buscar : Exit Sub
                    End If

                    txtTAB(e)
            End Select

        Catch ex As Exception
            HandleError(Me.Name, "txtCentroCosto_KeyDown", ex)
        End Try
    End Sub
#End Region

#Region "Eventos Genericos"
    Private Sub txtTextoKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CboLote.KeyPress, _
     CboCultivo.KeyPress, CboMercado.KeyPress, cboHojas.KeyPress, CboPuntoPago.KeyPress, CboTipoPercepcion.KeyPress, _
    txtActividad.KeyPress, txtTotalJornales.KeyPress, txtTotalPercepcion.KeyPress, txtCentroCosto.KeyPress
        txtNoBeep(e)
    End Sub
    '
    Private Sub txtNumerosEnterosKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) ' Handles txtCantidadPalets.KeyPress, TxtFolio.KeyPress, TxtTotalPeso.KeyPress, txtFolioPalet1Etiquetas.KeyPress, txtFolioPalet2Etiquetas.KeyPress
        txtSoloNumerosEnteros(e)
        txtNoBeep(e)
    End Sub

    Private Sub txtKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) 'Handles CboEmpaque.KeyPress, DtpFecha.KeyPress
        txtNoBeep(e)
    End Sub
#End Region

#End Region

#Region "Métodos y procedimientos"
    Private Sub Inicializa()
        Try
            Me.InicializaGrid()
            'Me.DesplegarHojas()
            Me.cboHojas.Focus()
            Me.txtActividad.Text = ""
            Me.lblNombreActividad.Text = ""
            'Me.CboCentroCosto.SelectedIndex = -1
            Me.txtCentroCosto.Text = "" : Me.lblCentroCosto.Text = ""
            Me.cboConceptoActividad.SelectedIndex = -1
            Me.CboCultivo.SelectedIndex = -1
            Me.CboLote.SelectedIndex = -1
            Me.CboMercado.SelectedIndex = -1 '.SelectedValue = "N"
            Me.CboHoras.SelectedValue = Plaza.oSisPlazaNomina.NOMINA_EQUIVALENCIA_JORNAL_HORAS
            Me.txtTotalJornales.Text = ""
            Me.txtTotalPercepcion.Text = ""
            Me.txtTotalCajasCortadas.Text = ""
            Me.CboPuntoPago.SelectedValue = 1
            Me.CboTipoPercepcion.SelectedValue = 1

            If Plaza.oSisPlazaNomina.MOSTRAR_CULTIVO = "1" Then
                Me.CboCultivo.Visible = True
            Else
                Me.CboCultivo.Visible = False
            End If

            Me.cboTurno.Text = "MAÑANA"

        Catch ex As Exception
            HandleError(Me.Name, "Inicializa", ex)
        End Try
    End Sub

    Private Sub InicializaGrid()
        Me.GridPercepciones.DataSource = Nothing
        FG_Grid_Limpiar(Me.GridPercepciones)

        Me.GridPercepciones.Rows = 2
        Me.GridPercepciones.Cols = 11

        Me.FormateaGrid()
    End Sub

    Private Sub FormateaGrid()
        Try
            Dim dTabla As New DataTable("detalle"), da As SqlDataAdapter
            Dim sSQL As String = ("SELECT CODIGO_PERCEPCION,NOMBRE FROM NOMINA_CAT_PERCEPCIONES WHERE OCULTO='0' ORDER BY NOMBRE")

            Me.GridPercepciones.Column(Me.igyCodigo).Width = 100
            Me.GridPercepciones.Column(Me.igyDescripcion).Width = 360
            Me.GridPercepciones.Column(Me.igyImporte).Width = 100
            Me.GridPercepciones.Column(Me.igyJornales).Width = 70
            Me.GridPercepciones.Column(Me.igyCajasCortadas).Width = 100

            Me.GridPercepciones.Cell(0, Me.igyCodigo).Text = "Código"
            Me.GridPercepciones.Cell(0, Me.igyDescripcion).Text = "Nombre"
            Me.GridPercepciones.Cell(0, Me.igyImporte).Text = "Importe"
            Me.GridPercepciones.Cell(0, Me.igyPercepcion).Text = "Percepción"
            Me.GridPercepciones.Cell(0, Me.igyCodigoPercepcion).Text = "Cod. Percepción"
            Me.GridPercepciones.Cell(0, Me.igyRembolsable).Text = "Rembolsable"
            Me.GridPercepciones.Cell(0, Me.igyIdNominaPercepcion).Text = "IdNominaPercepcion"
            Me.GridPercepciones.Cell(0, Me.igyConfirmar).Text = "Confirmar"
            Me.GridPercepciones.Cell(0, Me.igyJornales).Text = "Jornales"
            Me.GridPercepciones.Cell(0, Me.igyCajasCortadas).Text = "Tareas completadas"

            Me.GridPercepciones.Column(Me.igyDescripcion).Locked = True
            Me.GridPercepciones.Column(Me.igyCodigoPercepcion).Visible = False

            Me.GridPercepciones.Column(Me.igyImporte).Mask = FlexCell.MaskEnum.Numeric
            Me.GridPercepciones.Column(Me.igyImporte).DecimalLength = Empresa_Sistema.DECIMALES_PRECIO
            Me.GridPercepciones.Column(Me.igyImporte).Alignment = FlexCell.AlignmentEnum.RightCenter
            Me.GridPercepciones.Column(Me.igyJornales).Locked = True

            'Me.GridPercepciones.Column(Me.igyCajasCortadas).Visible = False
            Me.GridPercepciones.Column(Me.igyCajasCortadas).Mask = FlexCell.MaskEnum.Numeric

            If Me.ModoPercepcion = enumModoPercepcion.PERCECION Then
                Me.GridPercepciones.Column(Me.igyPercepcion).Locked = True
                Me.GridPercepciones.Column(Me.igyPercepcion).Visible = False
                Me.GridPercepciones.Column(Me.igyRembolsable).Locked = True
                Me.GridPercepciones.Column(Me.igyRembolsable).Visible = False
                Me.GridPercepciones.Column(Me.igyImporte).Locked = False
                Me.GridPercepciones.Column(Me.igyIdNominaPercepcion).Locked = True
                Me.GridPercepciones.Column(Me.igyIdNominaPercepcion).Visible = False
                Me.GridPercepciones.Column(Me.igyConfirmar).Locked = True
                Me.GridPercepciones.Column(Me.igyConfirmar).Visible = False

                'If Me.txtActividad.Text = "388" Then
                '    Me.GridPercepciones.Column(Me.igyCajasCortadas).Visible = True
                'End If

            Else
                Me.GridPercepciones.Column(Me.igyCodigo).Width = 70
                Me.GridPercepciones.Column(Me.igyDescripcion).Width = 200
                Me.GridPercepciones.Column(Me.igyPercepcion).Width = 130
                Me.GridPercepciones.Column(Me.igyRembolsable).Width = 100
                Me.GridPercepciones.Column(Me.igyImporte).Width = 100
                Me.GridPercepciones.Column(Me.igyIdNominaPercepcion).Width = 100
                Me.GridPercepciones.Column(Me.igyConfirmar).Width = 70

                da = New SqlDataAdapter(sSQL, Empresa_Sistema.conexion)
                da.Fill(dTabla)
                da.Dispose()

                Me.GridPercepciones.Column(Me.igyPercepcion).CellType = FlexCell.CellTypeEnum.ComboBox
                Me.GridPercepciones.ComboBox(Me.igyPercepcion).DataSource = dTabla
                Me.GridPercepciones.ComboBox(Me.igyPercepcion).DisplayMember = "NOMBRE"
                Me.GridPercepciones.ComboBox(Me.igyPercepcion).ValueMember = "CODIGO_PERCEPCION"

                Me.GridPercepciones.Column(Me.igyConfirmar).CellType = FlexCell.CellTypeEnum.CheckBox

                Me.GridPercepciones.Column(Me.igyImporte).Mask = FlexCell.MaskEnum.Numeric
                Me.GridPercepciones.Column(Me.igyImporte).DecimalLength = Empresa_Sistema.DECIMALES_PRECIO
                Me.GridPercepciones.Column(Me.igyImporte).Alignment = FlexCell.AlignmentEnum.RightCenter

                Me.GridPercepciones.Column(Me.igyRembolsable).Locked = True
                Me.GridPercepciones.Column(Me.igyRembolsable).Visible = False
                Me.GridPercepciones.Column(Me.igyImporte).Locked = False
                Me.GridPercepciones.Column(Me.igyIdNominaPercepcion).Locked = True
                Me.GridPercepciones.Column(Me.igyIdNominaPercepcion).Visible = False
                Me.GridPercepciones.Column(Me.igyConfirmar).Locked = False

                For i As Integer = 1 To Me.GridPercepciones.Rows - 1
                    If Me.GridPercepciones.Cell(i, Me.igyConfirmar).Text = "1" Then
                        Me.GridPercepciones.Cell(i, Me.igyCodigo).Locked = True
                        Me.GridPercepciones.Cell(i, Me.igyDescripcion).Locked = True
                        Me.GridPercepciones.Cell(i, Me.igyPercepcion).Locked = True
                        Me.GridPercepciones.Cell(i, Me.igyImporte).Locked = True
                        Me.GridPercepciones.Cell(i, Me.igyConfirmar).Locked = False
                        Me.GridPercepciones.Cell(i, Me.igyJornales).Locked = True
                    End If
                Next i
            End If

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
                    Me.GridPercepciones.Locked = False

                    Me.tsslEstado.Text = "Estado: Agregando nuevo movimiento"
                    Me.tssElaboro.Visible = False : Me.tssElaboro.Text = ""

                Case enumEstados.GRABADO
                    Me.tsbNuevo.Enabled = True
                    Me.tsbGrabar.Enabled = True
                    Me.GridPercepciones.Locked = False

                    Me.tsslEstado.Text = "Estado: Consultando movimiento"
                    Me.tssElaboro.Visible = True

                Case enumEstados.GENERADA
                    Me.tsbNuevo.Enabled = False
                    Me.tsbGrabar.Enabled = False

                    Me.cboHojas.Focus()
                    'Me.CboCentroCosto.Enabled = False
                    Me.txtCentroCosto.Enabled = False
                    Me.cboConceptoActividad.Enabled = False
                    Me.txtActividad.Enabled = False
                    Me.CboCultivo.Enabled = False
                    Me.CboLote.Enabled = False
                    Me.CboMercado.Enabled = False
                    Me.CboHoras.Enabled = False
                    Me.txtTotalJornales.Enabled = False
                    Me.txtTotalPercepcion.Enabled = False
                    Me.CboTipoPercepcion.Enabled = False
                    Me.CboPuntoPago.Enabled = False
                    Me.cboTurno.Enabled = False

                    Me.GridPercepciones.Locked = True

            End Select

            Application.DoEvents()

        Catch ex As Exception
            HandleError(Me.Name, "Cambia_Estado", ex)
        End Try
    End Sub

    Private Function GestionaGrabar(Optional ByVal iRenglon As Integer = 0) As Boolean
        Dim bResultado As Boolean = False
        Dim i As Integer
        i = iRenglon
        Try
            Me.Totales()

            If Me.ValidarHoja() = False Then
                Return False
            End If

            If Me.ValidarTrabajador() = False Then
                Return False
            End If

            If Me.ModoPercepcion = enumModoPercepcion.OTRA_PERCEPCION Then
                If txtLEN(Me.GridPercepciones.Cell(i, Me.igyCodigo).Text) = True Then
                    If Me.GridPercepciones.Cell(i, Me.igyRembolsable).Text = "1" Then
                        If Me.ValidarDeduccion(i) = False Then
                            Return False
                        End If
                    End If
                End If
            End If

            If Me.Grabar(iRenglon) = True Then
                If Me.ModoPercepcion = enumModoPercepcion.OTRA_PERCEPCION Then
                    If txtLEN(Me.GridPercepciones.Cell(i, Me.igyCodigo).Text) = True Then
                        If Me.GridPercepciones.Cell(i, Me.igyRembolsable).Text = "1" Then
                            If Me.oFormaDeducciones.Grabar(False) = True Then
                                'MsgBox("Movimiento grabado satisfactoriamente.", MsgBoxStyle.Information, Me.Text)
                                bResultado = True
                            Else
                                Me.GridPercepciones.Cell(i, Me.igyConfirmar).Text = "0"
                                Return False
                                ' MsgBox("Movimiento grabado sin la deducción.", MsgBoxStyle.Information, Me.Text)
                            End If
                        Else
                            bResultado = True
                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            HandleError(Me.Name, "GestionaGrabar", ex)
        End Try

        Return bResultado

    End Function

    Private Function Grabar(Optional ByVal iRenglon As Integer = 0) As Boolean
        Dim bResultado As Boolean = False
        Dim i As Integer

        Try
            'Me.RecalculaJornales()
            Me.Totales()

            If Me.ValidarHoja() = False Then
                Return False
            End If

            With Me.oHoja
                .ID_NOMINA_DIA = Me._ID_NOMINA_DIA

                If txtLEN(Me.cboHojas.Text) = True Then
                    .NUMERO_HOJA = CInt(Me.cboHojas.Text)
                Else
                    .NUMERO_HOJA = 1
                End If

                '.CODIGO_CENTRO_COSTO = CInt(Me.CboCentroCosto.SelectedValue.ToString)
                .CODIGO_CENTRO_COSTO = CInt(Me.txtCentroCosto.Text)

                If Me.CboCultivo.SelectedIndex <> -1 Then
                    If Me.CboCultivo.Text <> "" Then
                        .CODIGO_CULTIVO = "" & Me.CboCultivo.SelectedValue.ToString
                    Else
                        .CODIGO_CULTIVO = ""
                    End If
                Else
                    .CODIGO_CULTIVO = ""
                End If

                If Me.CboMercado.SelectedIndex <> -1 Then
                    If Me.CboMercado.Text <> "" Then
                        .CODIGO_MERCADO = Me.CboMercado.Text.Substring(0, Me.CboMercado.Text.Length - 1 - (Me.CboMercado.Text.Length - 2))
                    Else
                        .CODIGO_MERCADO = ""
                    End If
                Else
                    .CODIGO_MERCADO = ""
                End If

                If Me.CboLote.SelectedIndex <> -1 Then
                    If Me.CboLote.Text <> "" Then
                        .CODIGO_LOTE = "" & Me.CboLote.SelectedValue.ToString
                    Else
                        .CODIGO_LOTE = ""
                    End If
                Else
                    .CODIGO_LOTE = ""
                End If

                .CODIGO_ACTIVIDAD = CInt(Me.txtActividad.Text)
                .CODIGO_PUNTO_PAGO = CInt(Me.CboPuntoPago.SelectedValue)
                .CODIGO_TIPO_PERCEPCION = CInt(Me.CboTipoPercepcion.SelectedValue)
                .TOTAL_PERCEPCIONES = CDbl(Me.txtTotalPercepcion.Text)
                .HORAS_POR_TRABAJADOR = CDbl(Me.CboHoras.Text)
                .TOTAL_JORNALES = CDbl(Me.txtTotalJornales.Text)
                .TOTAL_CAJAS_CORTADAS = valorNumerico(Me.txtTotalCajasCortadas.Text)
                .TURNO = Me.cboTurno.Text

                If Me.Estado = enumEstados.NUEVO Then
                    If .Insertar() = False Then
                        MsgBox("Error al tratar de insertar la hoja.", MsgBoxStyle.Exclamation, Me.Text)
                        Return False
                    End If
                Else
                    If .Actualizar(IIf(Me.ModoPercepcion = enumModoPercepcion.PERCECION, "1", "0").ToString) = False Then
                        MsgBox("Error al tratar de actualizar la hoja.", MsgBoxStyle.Exclamation, Me.Text)
                        Return False
                    End If
                End If

                Dim oTrabajador As Class_CatTrabajadores

                'se graba el detalle
                If Me.ModoPercepcion = enumModoPercepcion.PERCECION Then
                    For i = 1 To Me.GridPercepciones.Rows - 1
                        If txtLEN(Me.GridPercepciones.Cell(i, Me.igyCodigo).Text) = True And valorNumerico(Me.GridPercepciones.Cell(i, Me.igyImporte).Text) > 0 Then
                            oTrabajador = New Class_CatTrabajadores(Me.GridPercepciones.Cell(i, Me.igyCodigo).Text, True)
                            .oHojaPercepcion.ID_NOMINA_PERCEPCION = 0
                            .oHojaPercepcion.ID_NOMINA_HOJA = .ID_NOMINA_HOJA
                            .oHojaPercepcion.CODIGO_TRABAJADOR = oTrabajador.CODIGO_TRABAJADOR
                            .oHojaPercepcion.PERCEPCION = valorNumerico(Me.GridPercepciones.Cell(i, Me.igyImporte).Text)
                            .oHojaPercepcion.CODIGO_PERCEPCION = 1
                            .oHojaPercepcion.CAJAS_CORTADAS = valorNumerico(Me.GridPercepciones.Cell(i, Me.igyCajasCortadas).Text)

                            If .oHojaPercepcion.GrabaDetallePercepcion("INSERTAR") = False Then
                                MsgBox("Error al tratar de grabar el detalle de la hoja.", MsgBoxStyle.Exclamation, Me.Text)
                                Return False
                            End If
                        End If
                    Next
                Else
                    If iRenglon <> 0 Then
                        i = iRenglon
                        If txtLEN(Me.GridPercepciones.Cell(i, Me.igyIdNominaPercepcion).Text) = True Then 'SI YA EXISTE LA PERCEPCION
                            Dim sql As New Class_find("SELECT ID_DEDUCCION_GLOBAL FROM NOMINA_DEDUCCIONES_GLOBAL WHERE ID_NOMINA_PERCEPCION=" & Me.GridPercepciones.Cell(i, Me.igyIdNominaPercepcion).Text)
                            If txtLEN(sql.Result1) = True Then
                                Dim oDeducciones As New Class_NominaDeduccionesGlobal(CInt(sql.Result1))
                                If oDeducciones.EliminaDeduccion() = False Then
                                    Return False
                                End If
                            End If
                        End If
                        If txtLEN(Me.GridPercepciones.Cell(i, Me.igyCodigo).Text) = True Then
                            oTrabajador = New Class_CatTrabajadores(Me.GridPercepciones.Cell(i, Me.igyCodigo).Text, True)
                            .oHojaPercepcion.ID_NOMINA_HOJA = .ID_NOMINA_HOJA
                            .oHojaPercepcion.CODIGO_TRABAJADOR = oTrabajador.CODIGO_TRABAJADOR
                            .oHojaPercepcion.PERCEPCION = valorNumerico(Me.GridPercepciones.Cell(i, Me.igyImporte).Text)
                            .oHojaPercepcion.CODIGO_PERCEPCION = CInt(Me.GridPercepciones.Cell(i, Me.igyCodigoPercepcion).Text)
                            .oHojaPercepcion.CAJAS_CORTADAS = 0 'Es 0 porque ni esta visible esta columna en este modo

                            If txtLEN(Me.GridPercepciones.Cell(i, Me.igyIdNominaPercepcion).Text) = True Then
                                .oHojaPercepcion.ID_NOMINA_PERCEPCION = CInt(Me.GridPercepciones.Cell(i, Me.igyIdNominaPercepcion).Text)
                                If .oHojaPercepcion.GrabaDetallePercepcion("ACTUALIZAR") = False Then
                                    MsgBox("Error al tratar de grabar el detalle de la hoja.", MsgBoxStyle.Exclamation, Me.Text)
                                    Return False
                                End If
                            Else
                                .oHojaPercepcion.ID_NOMINA_PERCEPCION = 0
                                If .oHojaPercepcion.GrabaDetallePercepcion("INSERTAR") = False Then
                                    MsgBox("Error al tratar de grabar el detalle de la hoja.", MsgBoxStyle.Exclamation, Me.Text)
                                    Return False
                                End If
                            End If

                            If Me.GridPercepciones.Cell(i, Me.igyRembolsable).Text = "1" Then
                                Me.oFormaDeducciones.ID_NOMINA_PERCEPCION = .oHojaPercepcion.ID_NOMINA_PERCEPCION
                            End If
                        End If
                    End If
                End If

                bResultado = True
                'MsgBox("Hoja grabada satisfactoriamente.", MsgBoxStyle.Information, Me.Text)

            End With
        Catch ex As Exception
            HandleError(Me.Name, "Grabar", ex)
        End Try

        Return bResultado
    End Function

    Private Function Consultar() As Boolean
        Dim bResultado As Boolean = False
        Dim dTabla As DataTable
        Me.oHoja = New Class_NominaHoja(CInt(Me.cboHojas.SelectedValue))
        Dim oActividad As Class_CatActividades, oCentroCosto As Class_CatCentroCostos

        Try
            If Me.oHoja.Existe = False Then
                Me.Inicializa()
                Me.Cambia_Estado(enumEstados.NUEVO)
                Exit Function
            Else
                Me.cboHojas.SelectedValue = Me.oHoja.ID_NOMINA_HOJA

                'Me.CboCentroCosto.SelectedValue = Me.oHoja.CODIGO_CENTRO_COSTO.ToString
                Me.txtCentroCosto.Text = Me.oHoja.CODIGO_CENTRO_COSTO.ToString
                oCentroCosto = New Class_CatCentroCostos(CInt(Me.txtCentroCosto.Text))
                Me.lblCentroCosto.Text = oCentroCosto.NOMBRE_CENTRO_COSTO

                Me.CboCultivo.SelectedValue = Me.oHoja.CODIGO_CULTIVO.ToString
                Me.CboMercado.SelectedValue = Me.oHoja.CODIGO_MERCADO.ToString
                Me.CboLote.SelectedValue = Me.oHoja.CODIGO_LOTE.ToString

                Me.txtActividad.Text = Me.oHoja.CODIGO_ACTIVIDAD.ToString
                oActividad = New Class_CatActividades(CInt(Me.oHoja.CODIGO_ACTIVIDAD))
                Me.lblNombreActividad.Text = oActividad.NOMBRE_ACTIVIDAD
                Me.cboConceptoActividad.SelectedValue = oActividad.CODIGO_CONCEPTO_ACTIVIDAD

                Me.CboTipoPercepcion.SelectedValue = Me.oHoja.CODIGO_TIPO_PERCEPCION.ToString
                Me.CboPuntoPago.SelectedValue = Me.oHoja.CODIGO_PUNTO_PAGO.ToString
                Me.CboHoras.Text = CInt(Me.oHoja.HORAS_POR_TRABAJADOR).ToString
                Me.txtTotalPercepcion.Text = FormatImporteContable(Me.oHoja.TOTAL_PERCEPCIONES)
                Me.txtTotalJornales.Text = Me.oHoja.TOTAL_JORNALES.ToString
                Me.txtTotalCajasCortadas.Text = Format(Me.oHoja.TOTAL_CAJAS_CORTADAS, "###,###")
                Me.cboTurno.Text = Me.oHoja.TURNO

                dTabla = Me.oHoja.ObtenerDetalle
                Me.GridPercepciones.Rows = 1

                'Private igyCodigo As Short = 1
                'Private igyDescripcion As Short = 2
                'Private igyPercepcion As Short = 3
                'Private igyCodigoPercepcion As Short = 4
                'Private igyRembolsable As Short = 5
                'Private igyImporte As Short = 6
                'Private igyIdNominaPercepcion As Short = 7
                'Private igyConfirmar As Short = 8
                'Private igyJornales As Short = 9
                'Private igyCajasCortadas As Short = 10

                For Each dRow As DataRow In dTabla.Rows
                    Me.GridPercepciones.AddItem(dRow("CODIGO_X_TEMPORADA").ToString & Chr(9) & dRow("NOMBRE_TRABAJADOR").ToString & " " & dRow("APELLIDO_PATERNO").ToString & " " & dRow("APELLIDO_MATERNO").ToString & Chr(9) &
                                                dRow("NOMBRE").ToString & Chr(9) & dRow("CODIGO_PERCEPCION").ToString & Chr(9) & dRow("REEMBOLSABLE").ToString & Chr(9) &
                                                dRow("PERCEPCION").ToString & Chr(9) & dRow("ID_NOMINA_PERCEPCION").ToString & Chr(9) & dRow("CONFIRMAR").ToString & Chr(9) &
                                                dRow("JORNALES").ToString & Chr(9) & dRow("CAJAS_CORTADAS").ToString & Chr(9))
                Next
                dTabla.Dispose()

                Me.FormateaGrid()
            End If

            If Me.GridPercepciones.Rows = 1 Then
                Me.GridPercepciones.Rows = 2
            End If

            Me.tssElaboro.Text = "Ultima modificación :  " & Format(Me.oHoja.FECHA_SERVIDOR, "dd/MMM/yyyy hh:mm tt") & " por " & Me.oHoja.NOMBRE_USUARIO_GRABO.ToString
            Me.Cambia_Estado(enumEstados.GRABADO)

            If Me.oSemana.NOMINA_GENERADA = "1" Then
                Me.Cambia_Estado(enumEstados.GENERADA)
            End If

            bResultado = True
        Catch ex As Exception
            HandleError(Me.Name, "Consultar", ex)
        End Try

        Return bResultado
    End Function

    Private Function ValidarHoja() As Boolean
        Dim bResultado As Boolean = False
        ''Semana generada

        ''Valida que se asigne una Actividad
        If txtLEN(Me.txtActividad.Text) = True Then
            Me.oActividades = New Class_CatActividades(CInt(Me.txtActividad.Text))
            If Me.oActividades._Existe = False Or Me.oActividades.Estatus = "B" Then
                MsgBox("La actividad no existe o esta dada de Baja.", MsgBoxStyle.Exclamation, "ValidarHoja")
                Me.txtActividad.Focus()
                Return False
            End If
        Else
            MsgBox("Asigne una actividad.", MsgBoxStyle.Exclamation, "ValidarHoja")
            Me.txtActividad.Focus()
            Return False
        End If

        'If Me.CboCentroCosto.SelectedIndex = -1 Then
        '    MsgBox("Seleccione un centro de costo.", MsgBoxStyle.Exclamation, "ValidarHoja")
        '    Me.CboCentroCosto.Focus()
        '    Return False
        'End If
        If txtLEN(Me.txtCentroCosto.Text) = False Then
            MsgBox("Seleccione un centro de costo.", MsgBoxStyle.Exclamation, "ValidarHoja")
            Me.txtCentroCosto.Focus()
            Return False
        End If

        'Validar si esta dado de baja
        'Dim oCentroCosto As New Class_CatCentroCostos(CInt(Me.CboCentroCosto.SelectedValue))
        Dim oCentroCosto As New Class_CatCentroCostos(CInt(Me.txtCentroCosto.Text))
        If oCentroCosto.Estatus = "B" Then
            MsgBox("El centro de costo esta dado de baja.", MsgBoxStyle.Exclamation, "ValidarHoja")
            Me.txtCentroCosto.Focus()
            Return False
        End If

        If Me.cboTurno.SelectedIndex = -1 Then
            MsgBox("Seleccione un turno.", MsgBoxStyle.Exclamation, "ValidarHoja")
            Me.cboTurno.Focus()
            Return False
        End If

        Try
            Dim i As Integer
            Dim oTrabajador As Class_CatTrabajadores
            For i = 1 To Me.GridPercepciones.Rows - 1
                If txtLEN(Me.GridPercepciones.Cell(i, Me.igyCodigo).Text) = True Then
                    oTrabajador = New Class_CatTrabajadores(Me.GridPercepciones.Cell(i, Me.igyCodigo).Text, True)
                    If oTrabajador.Existe() = False Then
                        MsgBox("El trabajador no existe.", MsgBoxStyle.Exclamation, Me.Text)
                        Me.GridPercepciones.Cell(i, Me.igyCodigo).SetFocus()
                        Return False
                    End If
                    If valorNumerico(Me.GridPercepciones.Cell(i, Me.igyImporte).Text) <= 0 Then
                        MsgBox("Asigne un importe al trabajador.", MsgBoxStyle.Exclamation, Me.Text)
                        Me.GridPercepciones.Cell(i, Me.igyImporte).SetFocus()
                        Return False
                    End If
                    If Me.ModoPercepcion = enumModoPercepcion.OTRA_PERCEPCION Then
                        If txtLEN(Me.GridPercepciones.Cell(i, Me.igyPercepcion).Text) = False Then
                            MsgBox("Seleccione una percepción valida.", MsgBoxStyle.Exclamation, Me.Text)
                            Me.GridPercepciones.Cell(i, Me.igyPercepcion).SetFocus()
                            Return False
                        Else
                            Dim sql As New Class_find("SELECT CODIGO_PERCEPCION,NOMBRE,REEMBOLSABLE FROM NOMINA_CAT_PERCEPCIONES WHERE NOMBRE='" & Me.GridPercepciones.Cell(i, Me.igyPercepcion).Text & "'")
                            If txtLEN(sql.Result1) = True Then
                                ' Me.GridPrecepciones.Cell(1, Me.igyRembolsable).Text = sql.Result3.ToString
                            Else
                                MsgBox("Seleccione una percepción valida.", MsgBoxStyle.Exclamation, Me.Text)
                                Return False
                            End If
                        End If
                    End If
                End If
            Next i

            bResultado = True
        Catch ex As Exception
            HandleError(Me.Name, "ValidarHoja", ex)
        End Try

        Return bResultado
    End Function

    Private Sub DesplegarHojas(Optional ByVal bAgregarHoja As Boolean = False)
        Try
            Dim oElementos As New Class_NominaHoja
            Dim dt As DataTable
            With Me.cboHojas
                .DisplayMember = "NUMERO_HOJA"
                .ValueMember = "ID_NOMINA_HOJA"
                dt = oElementos.ObtenerElementos(Me._ID_NOMINA_DIA)

                Dim dView As New Data.DataView(dt)
                dView.Sort = "ID_NOMINA_HOJA"
                .DataSource = dView

                If bAgregarHoja = True Then
                    'dt.Rows.Add(-1, dView.Count + 1)
                    dt.Rows.Add(-1, CInt("0" & dt.Compute("MAX(NUMERO_HOJA)", "").ToString) + 1)
                    dView = New Data.DataView(dt)
                    .DataSource = dView
                    .SelectedValue = -1
                Else
                    .SelectedIndex = 0
                End If
            End With

        Catch ex As Exception
            HandleError(Me.Name, "DesplegarHojas", ex)
        End Try
    End Sub

    'Private Sub DesplegarCentroCosto()
    '    Try
    '        Dim oElementos As New Class_CatCentroCostos
    '        With Me.CboCentroCosto
    '            .DisplayMember = "NOMBRE_CENTRO_COSTO"
    '            .ValueMember = "CODIGO_CENTRO_COSTO"
    '            Dim dView As New Data.DataView(oElementos.ObtenerElementosActivos())
    '            dView.Sort = "NOMBRE_CENTRO_COSTO DESC"
    '            .DataSource = dView
    '            If dView.Count > 0 Then
    '                .SelectedIndex = -1
    '            End If
    '        End With
    '    Catch ex As Exception
    '        HandleError(Me.Name, "DesplegarCentroCosto", ex)
    '    End Try
    'End Sub

    Private Sub DesplegarConceptoActividad()
        Try
            Dim oElementos As New Class_CatActividades
            With Me.cboConceptoActividad
                .DisplayMember = "NOMBRE_CONCEPTO_ACTIVIDAD"
                .ValueMember = "CODIGO_CONCEPTO_ACTIVIDAD"
                Dim dView As New Data.DataView(oElementos.ObtenerElementosActividad())
                dView.Sort = "NOMBRE_CONCEPTO_ACTIVIDAD "
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedIndex = -1
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarConceptoActividad", ex)
        End Try
    End Sub

    Private Sub DesplegarCultivos()
        Try
            Dim oElementos As New Class_CatCultivos
            Dim dt As DataTable
            dt = oElementos.ObtenerElementos()
            dt.Rows.Add("", "")

            With Me.CboCultivo
                .DisplayMember = "NOMBRE_CULTIVO"
                .ValueMember = "CODIGO_CULTIVO"
                Dim dView As New Data.DataView(dt)
                dView.Sort = "NOMBRE_CULTIVO DESC"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedIndex = -1
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarCultivos", ex)
        End Try
    End Sub

    Private Sub DesplegarMercados()
        Dim oTiposMercados As New Class_CatTiposMercados
        oTiposMercados = New Class_CatTiposMercados
        Dim dt As DataTable
        dt = oTiposMercados.ObtenerElementos()
        dt.Rows.Add("", "")

        Try
            With Me.CboMercado
                .DisplayMember = "NOMBRE_MERCADO"
                .ValueMember = "CODIGO_MERCADO"
                Dim dView As New Data.DataView(dt)
                dView.Sort = "NOMBRE_MERCADO"
                .DataSource = dView
                If dView.Count > 0 Then
                    '.SelectedValue = "N"
                    .SelectedIndex = -1
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarMercados", ex)
        End Try
    End Sub

    Private Sub DesplegarLotes()
        Try
            Dim oElementos As New Class_CatLotes
            Dim dt As DataTable
            dt = oElementos.ObtenerElementosActivos()
            'dt.Rows.Add("", "")

            With Me.CboLote
                .DisplayMember = "NOMBRE_LOTE"
                .ValueMember = "CODIGO_LOTE"
                Dim dView As New Data.DataView(dt)
                dView.Sort = "NOMBRE_LOTE DESC"
                .DataSource = dView
                If dView.Count > 0 Then
                    '.SelectedIndex = -1
                    .SelectedIndex = 0
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarLotes", ex)
        End Try
    End Sub

    Private Sub DesplegarTipoPercepcion()
        Try
            Dim oElementos As New Class_CatTipoPercepcion
            With Me.CboTipoPercepcion
                .DisplayMember = "NOMBRE_TIPO_PERCEPCION"
                .ValueMember = "CODIGO_TIPO_PERCEPCION"
                Dim dView As New Data.DataView(oElementos.ObtenerElementos)
                ' dView.Sort = "NOMBRE_EMPAQUE"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedIndex = 1
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarTipoPercepcion", ex)
        End Try
    End Sub

    Private Sub DesplegarPuntoPago()
        Try
            Dim oElementos As New Class_CatPuntoPago
            With Me.CboPuntoPago
                .DisplayMember = "NOMBRE_PUNTO_PAGO"
                .ValueMember = "CODIGO_PUNTO_PAGO"
                Dim dView As New Data.DataView(oElementos.ObtenerElementos())
                dView.Sort = "NOMBRE_PUNTO_PAGO DESC"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedValue = 1
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarPuntoPago", ex)
        End Try
    End Sub

    Private Sub DesplegarHoras()
        Dim i As Integer
        Try
            For i = 1 To CInt(Plaza.oSisPlazaNomina.NOMINA_EQUIVALENCIA_JORNAL_HORAS)
                Me.CboHoras.Items.Add(i)
            Next i
            Me.CboHoras.SelectedIndex = CInt(Plaza.oSisPlazaNomina.NOMINA_EQUIVALENCIA_JORNAL_HORAS) - 1

        Catch ex As Exception
            HandleError(Me.Name, "DesplegarHoras", ex)
        End Try
    End Sub

    'Private Sub RecalculaJornales()
    '    Dim Renglon As Integer = 0, i As Integer, StrCod As String, dPercepcion As Double
    '    Dim oTrabajadores As Class_CatTrabajadores
    '    Try

    '        For i = 1 To Me.GridPercepciones.Rows - 1
    '            If txtLEN(Me.GridPercepciones.Cell(i, Me.igyCodigo).Text) = True And valorNumerico(Me.GridPercepciones.Cell(i, Me.igyImporte).Text) > 0 Then
    '                StrCod = Me.GridPercepciones.Cell(i, Me.igyCodigo).Text
    '                dPercepcion = valorNumerico(Me.GridPercepciones.Cell(i, Me.igyImporte).Text)
    '                oTrabajadores = New Class_CatTrabajadores(StrCod,true)
    '                If oTrabajadores.Existe = False Then
    '                    Me.GridPercepciones.Cell(Renglon, Me.igyCodigo).Text = ""
    '                    'GoTo BuscaTrabajadores
    '                    'Exit Sub
    '                End If

    '                'If Me.ValidarTrabajador(Renglon, Me.GridPercepciones.Cell(Renglon, Me.igyCodigo).Text) = False Then
    '                '    Exit Sub
    '                'End If

    '                'Me.GridPercepciones.Cell(Renglon, Me.igyDescripcion).Text = oTrabajadores.NOMBRE_TRABAJADOR.ToString & " " & oTrabajadores.APELLIDO_PATERNO & " " & oTrabajadores.APELLIDO_MATERNO
    '                'Me.GridPercepciones.Cell(Renglon, Me.igyImporte).Text = Me.oActividades.COSTO_JORNAL.ToString   'CDbl(oTrabajadores.SUELDO_DIARIO).ToString
    '                'Me.GridPrecepciones.Cell(Renglon, Me.igyJornales).Text = "1"

    '                Dim sql2 As New Class_find("SELECT ISNULL(ACT.COSTO_JORNAL,0) FROM NOMINA_CAT_ACTIVIDADES ACT WHERE ACT.CODIGO_ACTIVIDAD=" & Me.txtActividad.Text.ToString)

    '                If txtLEN(sql2.Result1) = True Then
    '                    If CDbl(sql2.Result1) > 0 Then
    '                        'Me.GridPrecepciones.Cell(Renglon, Me.igyJornales).Text = CStr(CDbl(oTrabajadores.SUELDO_DIARIO) / CDbl(sql2.Result1))
    '                        'Me.GridPercepciones.Cell(Renglon, Me.igyJornales).Text = CStr(Me.oActividades.COSTO_JORNAL / CDbl(sql2.Result1))
    '                        Me.GridPercepciones.Cell(Renglon, Me.igyJornales).Text = CStr(dPercepcion / CDbl(sql2.Result1))
    '                    Else
    '                        Me.GridPercepciones.Cell(Renglon, Me.igyJornales).Text = "0"
    '                    End If
    '                End If
    '            End If
    '        Next
    '    Catch ex As Exception
    '        HandleError(Me.Name, "RecalculaJornales", ex)
    '    End Try
    'End Sub

    Private Sub Totales()
        Try
            Dim i As Integer, iTrabajadores As Integer = 0, dJornales As Double = 0
            Me.txtTotalPercepcion.Text = FormatImporteContable(CDbl(FG_Grid_SumaCol(Me.GridPercepciones, Me.igyImporte).ToString))
            For i = 1 To Me.GridPercepciones.Rows - 1
                If txtLEN(Me.GridPercepciones.Cell(i, Me.igyCodigo).Text) = True And valorNumerico(Me.GridPercepciones.Cell(i, Me.igyImporte).Text) > 0 Then
                    iTrabajadores = iTrabajadores + 1
                    dJornales = dJornales + CDbl(Me.GridPercepciones.Cell(i, Me.igyJornales).Text)
                End If
            Next
            'Me.txtTotalJornales.Text = ((iTrabajadores * valorNumerico(Me.CboHoras.Text)) / Plaza.oSisPlazaNomina.NOMINA_EQUIVALENCIA_JORNAL_HORAS).ToString
            Me.txtTotalJornales.Text = dJornales.ToString

            Me.txtTotalCajasCortadas.Text = Format(FG_Grid_SumaCol(Me.GridPercepciones, Me.igyCajasCortadas), "###,###")
        Catch ex As Exception
            HandleError(Me.Name, "Totales", ex)
        End Try
    End Sub

    Private Sub GestionaGridPercepciones(ByVal e As System.Windows.Forms.KeyEventArgs)
        Try

            Dim Columna As Integer, Renglon As Integer
            Dim StrCod As String, dPercipcion As Double
            Dim oTrabajadores As Class_CatTrabajadores

            Columna = Me.GridPercepciones.Selection.FirstCol
            Renglon = Me.GridPercepciones.Selection.FirstRow
            StrCod = Me.GridPercepciones.Cell(Renglon, Me.igyCodigo).Text

            If Me.GridPercepciones.Cell(Renglon, Me.igyConfirmar).Text = "1" And Columna = 8 Then
                Exit Sub
            End If

            If Me.Estado = enumEstados.GENERADA Then
                e.SuppressKeyPress = True
                Exit Sub
            End If

            Select Case e.KeyCode
                Case Keys.Enter, Keys.Tab, Keys.Down, Keys.Up, Keys.Left, Keys.Right
                    Select Case Columna

                        Case Me.igyCodigo
                            If txtLEN(StrCod) = False Then
                                GoTo BuscaTrabajadores
                                Exit Sub
                            End If
LlenaLinea:
                            oTrabajadores = New Class_CatTrabajadores(StrCod, True)
                            If oTrabajadores.Existe = False Then
                                Me.GridPercepciones.Cell(Renglon, Me.igyCodigo).Text = ""
                                GoTo BuscaTrabajadores
                                Exit Sub
                            End If

                            If Me.ValidarTrabajador(Renglon, Me.GridPercepciones.Cell(Renglon, Me.igyCodigo).Text) = False Then
                                Exit Sub
                            End If

                            Me.GridPercepciones.Cell(Renglon, Me.igyDescripcion).Text = oTrabajadores.NOMBRE_TRABAJADOR.ToString & " " & oTrabajadores.APELLIDO_PATERNO & " " & oTrabajadores.APELLIDO_MATERNO
                            Me.GridPercepciones.Cell(Renglon, Me.igyImporte).Text = Me.oActividades.COSTO_JORNAL.ToString   'CDbl(oTrabajadores.SUELDO_DIARIO).ToString
                            'Me.GridPrecepciones.Cell(Renglon, Me.igyJornales).Text = "1"

                            Dim sql2 As New Class_find("SELECT ISNULL(ACT.COSTO_JORNAL,0) FROM NOMINA_CAT_ACTIVIDADES ACT WHERE ACT.CODIGO_ACTIVIDAD=" & Me.txtActividad.Text.ToString)

                            If txtLEN(sql2.Result1) = True Then
                                If CDbl(sql2.Result1) > 0 Then
                                    'Me.GridPrecepciones.Cell(Renglon, Me.igyJornales).Text = CStr(CDbl(oTrabajadores.SUELDO_DIARIO) / CDbl(sql2.Result1))
                                    Me.GridPercepciones.Cell(Renglon, Me.igyJornales).Text = CStr(Me.oActividades.COSTO_JORNAL / CDbl(sql2.Result1))
                                Else
                                    Me.GridPercepciones.Cell(Renglon, Me.igyJornales).Text = "0"
                                End If
                            End If

                            Me.GridPercepciones.Cell(Renglon, Me.igyDescripcion).SetFocus()
                            Me.Totales()

                        Case Me.igyPercepcion
                            If txtLEN(Me.GridPercepciones.Cell(Renglon, Me.igyPercepcion).Text) = True Then
                                Dim sql As New Class_find("SELECT CODIGO_PERCEPCION,NOMBRE,REEMBOLSABLE FROM NOMINA_CAT_PERCEPCIONES WHERE NOMBRE='" & Me.GridPercepciones.Cell(Renglon, Me.igyPercepcion).Text & "'")
                                If txtLEN(sql.Result1) = True Then
                                    Me.GridPercepciones.Cell(1, Me.igyRembolsable).Text = sql.Result3.ToString
                                Else
                                    MsgBox("Seleccione una percepción valida.", MsgBoxStyle.Exclamation, Me.Text)
                                    Me.GridPercepciones.Cell(Renglon, Me.igyDescripcion).SetFocus()
                                    Exit Sub
                                End If
                            Else
                                MsgBox("Seleccione una percepción.", MsgBoxStyle.Exclamation, Me.Text)
                                Me.GridPercepciones.Cell(Renglon, Me.igyDescripcion).SetFocus()
                                Exit Sub
                            End If

                        Case Me.igyImporte
                            dPercipcion = valorNumerico(Me.GridPercepciones.Cell(Renglon, Me.igyImporte).Text)

                            If dPercipcion <= 0 Then
                                MsgBox("La cantidad debe de ser mayor a 0.", MsgBoxStyle.Exclamation, Me.Text)
                                Me.GridPercepciones.Cell(Renglon, Me.igyRembolsable).SetFocus()
                                Exit Sub
                            End If

                            'dPercipcion = valorNumerico(Me.GridPrecepciones.Cell(Renglon, Me.igyPercepcion).Text)

                            Dim sql2 As New Class_find("SELECT ISNULL(ACT.COSTO_JORNAL,0) FROM NOMINA_CAT_ACTIVIDADES ACT WHERE ACT.CODIGO_ACTIVIDAD=" & Me.txtActividad.Text.ToString)


                            If txtLEN(sql2.Result1) = True Then
                                If CDbl(sql2.Result1) > 0 Then
                                    Me.GridPercepciones.Cell(Renglon, Me.igyJornales).Text = CStr(dPercipcion / CDbl(sql2.Result1))
                                Else
                                    Me.GridPercepciones.Cell(Renglon, Me.igyJornales).Text = "0"
                                End If
                            End If


                            If Me.GridPercepciones.Rows = Renglon + 1 Then
                                Me.GridPercepciones.Rows = Me.GridPercepciones.Rows + 1
                            End If
                    End Select

                    Me.Totales()

                Case Keys.F6
BuscaTrabajadores:
                    If Columna = Me.igyCodigo Then 'Columna del Codigo de Trabajador
                        oTrabajadores = New Class_CatTrabajadores
                        StrCod = oTrabajadores.BusquedaVisual_PorDescripcion()
                        If txtLEN(StrCod) = True Then
                            Me.GridPercepciones.Cell(Renglon, Me.igyCodigo).Text = StrCod
                            GoTo LlenaLinea
                        End If
                    End If

                Case Keys.F8, Keys.Delete
                    If (Me.Estado = enumEstados.NUEVO Or Me.Estado = enumEstados.GRABADO) Then
                        If Me.ModoPercepcion = enumModoPercepcion.PERCECION Then
                            If Me.GridPercepciones.Rows > 2 Then
                                Me.GridPercepciones.Selection.DeleteByRow()
                                e.SuppressKeyPress = True
                            Else
                                Me.GridPercepciones.Cell(Renglon, Me.igyCodigo).Text = ""
                                Me.GridPercepciones.Cell(Renglon, Me.igyDescripcion).Text = ""
                                Me.GridPercepciones.Cell(Renglon, Me.igyPercepcion).Text = ""
                                Me.GridPercepciones.Cell(Renglon, Me.igyCodigoPercepcion).Text = "1"
                                Me.GridPercepciones.Cell(Renglon, Me.igyRembolsable).Text = "0"
                                Me.GridPercepciones.Cell(Renglon, Me.igyImporte).Text = ""
                                Me.GridPercepciones.Cell(Renglon, Me.igyIdNominaPercepcion).Text = ""
                                Me.GridPercepciones.Cell(Renglon, Me.igyConfirmar).Text = "0"
                                Me.GridPercepciones.Cell(Renglon, Me.igyJornales).Text = "1"
                            End If
                        Else
                            If Me.GridPercepciones.Cell(Renglon, Me.igyConfirmar).Text = "0" Or Me.GridPercepciones.Cell(Renglon, Me.igyConfirmar).Text = "" Then
                                If MsgBox("Deseas eliminar la deducción?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "Grabar") = MsgBoxResult.No Then
                                    Exit Sub
                                End If

                                If Me.GridPercepciones.Cell(Renglon, Me.igyRembolsable).Text = "0" Then
                                    Me.oHoja.oHojaPercepcion.ID_NOMINA_PERCEPCION = CInt(Me.GridPercepciones.Cell(Renglon, Me.igyIdNominaPercepcion).Text)
                                    Me.oHoja.oHojaPercepcion.EliminaDetallePercepcion()
                                Else
                                    Dim sql As New Class_find("SELECT ID_DEDUCCION_GLOBAL FROM NOMINA_DEDUCCIONES_GLOBAL WHERE ID_NOMINA_PERCEPCION=" & Me.GridPercepciones.Cell(Renglon, Me.igyIdNominaPercepcion).Text)
                                    If txtLEN(sql.Result1) = True Then
                                        Dim oDeducciones As New Class_NominaDeduccionesGlobal(CInt(sql.Result1))
                                        If oDeducciones.EliminaDeduccion() = False Then
                                            e.SuppressKeyPress = True
                                            Exit Sub
                                        Else
                                            MsgBox("La deducción se a eliminado correctamente.", MsgBoxStyle.Information, Me.Text)
                                        End If
                                        Me.oHoja.oHojaPercepcion.ID_NOMINA_PERCEPCION = CInt(Me.GridPercepciones.Cell(Renglon, Me.igyIdNominaPercepcion).Text)
                                        Me.oHoja.oHojaPercepcion.EliminaDetallePercepcion()
                                    Else
                                        e.SuppressKeyPress = True
                                        Exit Sub
                                    End If
                                End If

                                If Me.GridPercepciones.Rows > 2 Then
                                    Me.GridPercepciones.Selection.DeleteByRow()
                                    e.SuppressKeyPress = True
                                Else
                                    Me.GridPercepciones.Cell(Renglon, Me.igyCodigo).Text = ""
                                    Me.GridPercepciones.Cell(Renglon, Me.igyDescripcion).Text = ""
                                    Me.GridPercepciones.Cell(Renglon, Me.igyPercepcion).Text = ""
                                    Me.GridPercepciones.Cell(Renglon, Me.igyRembolsable).Text = ""
                                    Me.GridPercepciones.Cell(Renglon, Me.igyImporte).Text = ""
                                    Me.GridPercepciones.Cell(Renglon, Me.igyIdNominaPercepcion).Text = ""
                                    Me.GridPercepciones.Cell(Renglon, Me.igyConfirmar).Text = "0"
                                    Me.GridPercepciones.Cell(Renglon, Me.igyJornales).Text = ""
                                End If
                                Me.Totales()
                                Me.Grabar()
                            Else
                                e.SuppressKeyPress = True
                            End If
                        End If
                        Me.Totales()
                    End If
            End Select
        Catch ex As Exception
            HandleError(Me.Name, "GestionaGridPercepciones", ex)
        End Try
    End Sub

    Private Function ValidarTrabajador(Optional ByVal Renglon As Integer = 2, Optional ByVal Codigo As String = "") As Boolean
        Dim bResultado As Boolean = False
        Try
            Dim i As Integer, j As Integer
            Dim sCodigoTrabajador As String = ""

            For i = 1 To Me.GridPercepciones.Rows - 1
                If txtLEN(Me.GridPercepciones.Cell(i, Me.igyCodigo).Text) = True Then
                    Dim oTrabajador As New Class_CatTrabajadores(Me.GridPercepciones.Cell(i, Me.igyCodigo).Text, True)
                    If oTrabajador.Existe = False Then
                        MsgBox("El trabajador que intenta introducir en el renglón: " & i & " no existe, favor de intentar con otro código.", MsgBoxStyle.Exclamation, "Validación de trabajadores")
                        Me.GridPercepciones.Cell(i, Me.igyCodigo).Text = ""
                        Me.GridPercepciones.Cell(i, Me.igyDescripcion).Text = ""
                        Me.GridPercepciones.Cell(i, Me.igyJornales).Text = ""
                        Me.GridPercepciones.Cell(i, Me.igyCodigo).SetFocus()
                        Return False
                    End If
                End If
            Next i

            If txtLEN(Codigo) = False Then
                For i = 1 To Me.GridPercepciones.Rows - 1
                    sCodigoTrabajador = Me.GridPercepciones.Cell(i, Me.igyCodigo).Text
                    For j = i + 1 To Me.GridPercepciones.Rows - 1
                        If txtLEN(Me.GridPercepciones.Cell(j, Me.igyCodigo).Text) = True Then
                            If sCodigoTrabajador = Me.GridPercepciones.Cell(j, Me.igyCodigo).Text And Me.GridPercepciones.Rows > 2 Then
                                MsgBox("El trabajador que intenta introducir en el renglón:  " & i & " ya existe en el renglon " & j.ToString & ", favor de intentar con otro código.", MsgBoxStyle.Exclamation, "Validación de trabajadores")
                                Me.GridPercepciones.Cell(i, Me.igyCodigo).SetFocus()
                                Return False
                            End If
                        End If
                    Next j
                Next i
            Else
                sCodigoTrabajador = Codigo

                For j = 1 To Renglon - 1 'Me.Grid.Rows - 1
                    If txtLEN(Me.GridPercepciones.Cell(j, Me.igyCodigo).Text) = True Then
                        If sCodigoTrabajador = Me.GridPercepciones.Cell(j, Me.igyCodigo).Text And Me.GridPercepciones.Rows > 2 Then
                            MsgBox("El trabajador que intenta introducir en el renglón: " & Renglon & " ya existe en el renglon " & j.ToString & ", favor de intentar con otro código.", MsgBoxStyle.Exclamation, "Validación de trabajadores")
                            Me.GridPercepciones.Cell(Renglon, Me.igyCodigo).Text = ""
                            Me.GridPercepciones.Cell(Renglon, Me.igyDescripcion).Text = ""
                            Me.GridPercepciones.Cell(Renglon, Me.igyPercepcion).Text = ""
                            Me.GridPercepciones.Cell(Renglon, Me.igyJornales).Text = ""
                            Me.GridPercepciones.Cell(Renglon, Me.igyCodigo).SetFocus()
                            Return False
                        End If
                    End If
                Next j

                For j = Renglon + 1 To Me.GridPercepciones.Rows - 1
                    If txtLEN(Me.GridPercepciones.Cell(j, Me.igyCodigo).Text) = True Then
                        If sCodigoTrabajador = Me.GridPercepciones.Cell(j, Me.igyCodigo).Text And Me.GridPercepciones.Rows > 2 Then
                            MsgBox("El artículo que intenta introducir en el renglón: " & Renglon & " ya existe en el renglon " & j.ToString & ", favor de intentar con otro código.", MsgBoxStyle.Exclamation, "Validación de trabajadores")
                            Me.GridPercepciones.Cell(Renglon, Me.igyCodigo).Text = ""
                            Me.GridPercepciones.Cell(Renglon, Me.igyDescripcion).Text = ""
                            Me.GridPercepciones.Cell(Renglon, Me.igyPercepcion).Text = ""
                            Me.GridPercepciones.Cell(Renglon, Me.igyJornales).Text = ""
                            Me.GridPercepciones.Cell(Renglon, Me.igyCodigo).SetFocus()
                            Return False
                        End If
                    End If
                Next j
            End If
            bResultado = True
        Catch ex As Exception
            HandleError(Me.Name, "ValidarTrabajador", ex)
        End Try

        Return bResultado
    End Function

    Private Function ValidarDeduccion(ByVal iRenglon As Integer) As Boolean
        Dim bResultado As Boolean = False
        Try
            Dim i As Integer = iRenglon

            If txtLEN(Me.GridPercepciones.Cell(i, Me.igyCodigo).Text) = True Then

                Dim sCodigoTrabajador As String = Me.GridPercepciones.Cell(i, Me.igyCodigo).Text

                If Me.GridPercepciones.Cell(i, Me.igyRembolsable).Text = "1" Then
                    Me.oFormaDeducciones = New Frm_Nomina_Deducciones()
                    Me.oFormaDeducciones.StartPosition = FormStartPosition.CenterScreen
                    oFormaDeducciones.ChildParaGrabar = True

                    oFormaDeducciones.CboSemana.Text = Me.txtSemana.Text
                    oFormaDeducciones.txtCodigoTrabajador.Text = sCodigoTrabajador

                    If txtLEN(Me.GridPercepciones.Cell(i, Me.igyIdNominaPercepcion).Text) = True Then
                        If Me.Estado = enumEstados.NUEVO Then
                            oFormaDeducciones.ID_NOMINA_PERCEPCION = 0
                        Else
                            oFormaDeducciones.ID_NOMINA_PERCEPCION = CInt(Me.GridPercepciones.Cell(i, Me.igyIdNominaPercepcion).Text)
                            Dim sql As New Class_find("SELECT ID_DEDUCCION_GLOBAL FROM NOMINA_DEDUCCIONES_GLOBAL WHERE ID_NOMINA_PERCEPCION=" & Me.GridPercepciones.Cell(iRenglon, Me.igyIdNominaPercepcion).Text)
                            If txtLEN(sql.Result1) = True Then
                                oFormaDeducciones.ID_DEDUCCION = CInt(sql.Result1)
                                oFormaDeducciones.ConsultarTrabajador()
                                oFormaDeducciones.Consultar(CInt(sql.Result1))
                                If valorNumerico(Me.GridPercepciones.Cell(i, Me.igyImporte).Text) <> valorNumerico(oFormaDeducciones.TxtImporte.Text) Then
                                    If valorNumerico(oFormaDeducciones.TxtImporte.Text) <> valorNumerico(oFormaDeducciones.TxtSaldo.Text) Then
                                        MsgBox("La deducción ya tiene abonos, no es posible cambiar el importe.", MsgBoxStyle.Exclamation, Me.Text)
                                        Me.GridPercepciones.Cell(i, Me.igyImporte).Text = FormatImporteContable(valorNumerico(oFormaDeducciones.TxtImporte.Text))
                                        Return False
                                    End If
                                    oFormaDeducciones.GridPlanAbonos.Rows = 1
                                End If
                            End If
                        End If
                    Else
                        oFormaDeducciones.ID_NOMINA_PERCEPCION = 0
                        oFormaDeducciones.ConsultarTrabajador()
                    End If

                    oFormaDeducciones.LblId_Percepcion.Text = Me.GridPercepciones.Cell(iRenglon, Me.igyIdNominaPercepcion).Text
                    oFormaDeducciones.TxtImporte.Text = FormatImporteContable(CDbl(Me.GridPercepciones.Cell(i, Me.igyImporte).Text))
                    oFormaDeducciones.TxtSaldo.Text = FormatImporteContable(CDbl(Me.GridPercepciones.Cell(i, Me.igyImporte).Text))
                    oFormaDeducciones.NumeroSemana = CInt(Me.txtSemana.Text)

                    oFormaDeducciones.StartPosition = FormStartPosition.CenterScreen
                    oFormaDeducciones.ShowDialog()

                    If oFormaDeducciones.FormaValidaParaGrabarLlamadoExterior = True Then
                        bResultado = True
                    Else
                        Me.GridPercepciones.Cell(i, Me.igyConfirmar).Text = "0"
                        'Me.FormateaGrid()
                        Return False
                    End If
                Else
                    'checar si era rembolsable

                End If
            End If

        Catch ex As Exception
            HandleError(Me.Name, "ValidarDeduccion", ex)
        End Try

        Return bResultado
    End Function

    Private Function NavegadorHojas(ByVal sTipoDeBusqueda As String) As Boolean
        Dim bResultado As Boolean = False
        Try
            Dim iHoja As Integer
            iHoja = CInt(Me.cboHojas.Text)

            Me.oSemana = New Class_NominaSemana(CInt(Me.lblIdSemana.Text))

            If sTipoDeBusqueda = "Anterior" Then
                iHoja = iHoja - 1

                If iHoja > 0 Then
                    Me.cboHojas.SelectedIndex = Me.cboHojas.SelectedIndex - 1 'iHoja.ToString
                    'Me.Consultar()
                End If
            ElseIf sTipoDeBusqueda = "Siguiente" Then
                iHoja = iHoja + 1

                If iHoja > 0 Then
                    If CInt(Me.cboHojas.Items.Count) <= iHoja Then
                        Me.cboHojas.Text = iHoja.ToString
                        If Me.oSemana.NOMINA_GENERADA.ToString = "0" Then
                            Me.tsbNuevo.PerformClick()
                        End If
                    Else
                        Me.cboHojas.SelectedIndex = Me.cboHojas.SelectedIndex + 1
                    End If
                End If
            End If

            bResultado = True
        Catch ex As Exception
            HandleError(Me.Name, "NavegadorHojas", ex)
        End Try

        Return bResultado
    End Function

    Private Function Eliminar() As Boolean
        Dim bResultado As Boolean = False
        Dim sProcedure As String = "Eliminar"
        Try
            Select Case Me.Estado
                Case enumEstados.NUEVO
                    MsgBox("La hoja es nueva, no se puede eliminar.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                Case enumEstados.GENERADA
                    MsgBox("La nómina ya esta generada, no se pueden eliminar hojas.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
            End Select

            If MsgBox("Esta seguro de eliminar la hoja seleccionada ?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, sProcedure) = MsgBoxResult.No Then
                Return False
            End If

            If Me.oHoja.Eliminar = True Then
                MsgBox("Hoja eliminada satisfactoriamente.", MsgBoxStyle.Information, sProcedure)
                bResultado = True
                Me.DesplegarHojas()
            End If
        Catch ex As Exception
            HandleError(Me.Name, "Eliminar", ex)
        End Try

        Return bResultado
    End Function
#End Region

End Class